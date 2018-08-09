using ForensicsCourseToolkit.Framework_Project.Security;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.Scs.Communication.Messages;
using Hik.Communication.Scs.Communication.Protocols;
using Hik.Communication.Scs.Communication.Protocols.BinarySerialization;
using Hik.Communication.Scs.Server;
using Hik.Communication.ScsServices.Client;
using Hik.Communication.ScsServices.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForensicsCourseToolkit.Common.Helpers;
using ForensicsCourseToolkit.Framework_Project.Quizez;

namespace ForensicsCourseToolkit.Framework_Project.Examination
{

    public partial class PerformanceTesting : Form
    {

        private readonly int NumberOfStudetnInit = 10;
        private readonly int NumberOfStudentsMax = 50;
        private readonly int StudentsStep = 10;

        private readonly int NumberOfQuestionsInit = 10;
        private readonly int NumberOfQuestionsMax = 100;
        private readonly int QuestionsStep = 10;

        public PerformanceTesting()
        {
            InitializeComponent();
            aLogger = new Logger(ref richTextBox1);
            FormClosed += PerformanceTesting_FormClosed;
        }

        private void PerformanceTesting_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                serviceApplication.Stop();
            }
            catch (Exception ex)
            {

            }
        }

        Logger aLogger;
        private void startServerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                startServerProcesses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        IScsServiceApplication serviceApplication;
        NetworkExamServicePerformanceTesting aService;

        public static class BetterEnumerable
        {
            public static IEnumerable<int> SteppedRange(int fromInclusive, int toInclusive, int step)
            {
                for (var i = fromInclusive; i <= toInclusive; i += step)
                {
                    yield return i;
                }
            }
        }
        private SortedList<int, ExaminationStudentsFilter> GetFirewalls(int numberofStdsInit, int MaxStdNum,
            string studentPassword, string instructorPassword, int step, FilterationSecurityLevel secLevel)
        {
            SortedList<int, ExaminationStudentsFilter> ret = new SortedList<int, ExaminationStudentsFilter>();

            Parallel.ForEach(BetterEnumerable.SteppedRange(numberofStdsInit, MaxStdNum, step), (index) =>
            {
                SortedList<string, ExaminationFilterRule> rules = new SortedList<string, ExaminationFilterRule>();
                for (int i = 0; i < index; i++)
                {
                    rules.Add($"Std{i}", new ExaminationFilterRule
                    {
                        StdID = $"Std{i}",
                        StdName = $"StdName{i}",
                        AllowSpecificIPs = false,
                        AllowedIPs = new List<string>
                    {
                        "ANY",
                    },
                        SharedKeyIS = $"Keyyyyyyy{i}",
                    });
                }
                lock (ret)
                {
                    ret.Add(index, new ExaminationStudentsFilter(secLevel,
                    studentPassword, instructorPassword, rules));
                }
            });

            return ret;
        }

        private SortedList<int, Exam> GetExams(int numberOfInitiaQuestions, int maxNumOfQuestions, int step = 10)
        {
            SortedList<int, Exam> ret = new SortedList<int, Exam>();

            Parallel.ForEach(BetterEnumerable.SteppedRange(numberOfInitiaQuestions, maxNumOfQuestions, step), (index) =>
            {
                var x = ExamHelper.GetRandomExamforTesting(index);
                lock (ret)
                {
                    ret.Add(index, x);
                }
            });

            //int tempInit = numberOfInitiaQuestions;
            //while (tempInit < maxNumOfQuestions)
            //{
            //    ret.Add(tempInit, ExamHelper.GetRandomExamforTesting(tempInit));
            //    tempInit += step;
            //}
            return ret;
        }
        private void startServerProcesses()
        {
            // var examStringEncrypted = ExamHelper.GetRandomExamforTesting(int.Parse(numberOfQuestionsTxtBox.Text));
            // var anExam = ExamHelper.GetExamFromByteArray(examStringEncrypted, "123456", "", FilterationSecurityLevel.Moderate);
            // aLogger.LogMessage($"Load Exam the contains {anExam.QuestionsList.Count} Questions. [File Size= {(Math.Round(examStringEncrypted.Length / 1024.00, 2)).ToString()} KB]", LogMsgType.Verbose);

            var exams = GetExams(NumberOfQuestionsInit, NumberOfQuestionsMax, QuestionsStep);
            var firewalls = GetFirewalls(NumberOfStudetnInit, NumberOfStudentsMax, "123456", "123456", StudentsStep, highSecChkBox.Checked ? FilterationSecurityLevel.High : FilterationSecurityLevel.Moderate);
            aService = new NetworkExamServicePerformanceTesting(exams, "123456", UpdateDetails, firewalls);

            foreach (var exam in exams)
            {
                aLogger.LogMessage($"[EXAM GENERATED: ==> details], NumberOfQs=[{exam.Key}]", LogMsgType.Verbose);
            }

            foreach (var firewall in firewalls)
            {
                aLogger.LogMessage($"[Firewall GENERATED: ==> details], NumberOfStudentsRules=[{firewall.Key}]", LogMsgType.Verbose);
            }


            //Create a service application that runs on 10083 TCP port
            serviceApplication = ScsServiceBuilder.CreateService(new ScsTcpEndPoint(int.Parse(portTxtBox.Text)));
            aLogger.LogMessage($"Server Started", LogMsgType.Verbose);
            //Create a CalculatorService and add it to service application
            //serviceApplication.AddService<ICalculatorService, CalculatorService>(new CalculatorService());

            //Add Phone Book Service to service application
            serviceApplication.AddService<INetworkExamServiceTesting,
                       NetworkExamServicePerformanceTesting>(aService);

            //Start service application
            serviceApplication.Start();

            aLogger.LogMessage("Server Started", LogMsgType.Verbose);

        }



        private void UpdateDetails(List<ExamStatusUpdate> list)
        {

        }

        private void stopServerBtn_Click(object sender, EventArgs e)
        {
            serviceApplication.Stop();
            aLogger.LogMessage("Server Stopped...\n", LogMsgType.Verbose);

        }

        //  RequiredDetails requiredDetails;

        public enum TestType : short
        {
            GetExam = 1,
            SubmitExam,
            Both,
        }

        public class TestParameters
        {
            //public long AvgBytesSent { get; set; }
            //public long AvgKBSent { get { return AvgBytesSent / 1024; } }
            //public long AvgBytesReceived { get; set; }
            //public long AvgKBReceived { get { return AvgBytesReceived / 1024; } }
            public Stopwatch TimeRequired { get; set; }
            public int MethodCallCount { get; set; }
            public int NumberOfQuestions { get; set; }
            public int NumberOfStudent { get; set; }
            public int DroppedMessages { get; set; }
            public double Throughput
            {
                get
                {
                    return Math.Round(MethodCallCount / TimeRequired.Elapsed.TotalSeconds, 2);
                }
            }

            public double Latency
            {
                get
                {
                    return Math.Round(TimeRequired.Elapsed.TotalMilliseconds / MethodCallCount, 2);
                }
            }

            public double TotalTimeMilliSeconds
            {
                get
                {
                    return Math.Round((double)TimeRequired.ElapsedMilliseconds, 2);
                }
            }
        }

        //private void UpdateNetworkUsage(ref TestParameters param)
        //{
        //    if (!NetworkInterface.GetIsNetworkAvailable())
        //        return;

        //    NetworkInterface[] interfaces
        //        = NetworkInterface.GetAllNetworkInterfaces();

        //    foreach (NetworkInterface ni in interfaces)
        //    {
        //        lock (param)
        //        {
        //            param.AvgBytesReceived = (param.AvgBytesReceived + ni.GetIPv4Statistics().BytesReceived) / 2;
        //            param.AvgBytesSent = (param.AvgBytesSent + ni.GetIPv4Statistics().BytesSent) / 2;
        //        }
        //    }
        //}
        List<TestParameters> ReceivingResults = new List<TestParameters>();
        List<TestParameters> SubmissionResults = new List<TestParameters>();
        private void PerformTest(TestType type, int numOfQ, int numOfStd)
        {
            TestParameters submitParam = new TestParameters();
            TestParameters receiveParam = new TestParameters();
            submitParam.MethodCallCount = int.Parse(numberOfTimesTxtBox.Text);
            submitParam.NumberOfQuestions = numOfQ;
            submitParam.NumberOfStudent = numOfStd;

            receiveParam.MethodCallCount = int.Parse(numberOfTimesTxtBox.Text);
            receiveParam.NumberOfQuestions = numOfQ;
            receiveParam.NumberOfStudent = numOfStd;

            var secucirytLevel = highSecChkBox.Checked ? FilterationSecurityLevel.High : FilterationSecurityLevel.Moderate;
            var endpoint = new ScsTcpEndPoint(ipTxtBox.Text, int.Parse(portTxtBox.Text));
            SortedList<string, string> ExamsReceived = new SortedList<string, string>();

            var stopwatchReceiving = Stopwatch.StartNew();
            Parallel.For(0, numOfStd, index =>
            {
                using (var client = ScsServiceClientBuilder.CreateClient<INetworkExamServiceTesting>(endpoint))
                {
                    var val = index % numOfStd;
                    var keyUsed = $"Keyyyyyyy{val}";
                    //STEP 1 -- Only get exam copy
                    client.Connect();
                    var requiredDetails = new RequiredDetails($"StdName{val}", $"Std{val}", "123456", keyUsed, 1);
                    try
                    {
                        var copy = client.ServiceProxy.GetExamCopyEncryptedZipped(requiredDetails, numOfQ, numOfStd);
                        lock (ExamsReceived)
                        {
                            if (!ExamsReceived.Keys.Contains(keyUsed))
                            {
                                ExamsReceived.Add(keyUsed, copy);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lock (receiveParam)
                        {
                            receiveParam.DroppedMessages += 1;
                        }
                    }
                }

            });
            List<Task> tasksReq = new List<Task>();
            Parallel.For(0, receiveParam.MethodCallCount - numOfStd, index =>
            //  for (int index = 0; index < param.MethodCallCount; index++)
            {
                var t = Task.Run(() =>
                {
                    using (var client = ScsServiceClientBuilder.CreateClient<INetworkExamServiceTesting>(endpoint))
                    {
                        var val = index % numOfStd;
                        var keyUsed = $"Keyyyyyyy{val}";
                        //STEP 1 -- Only get exam copy
                        client.Connect();
                        var requiredDetails = new RequiredDetails($"StdName{val}", $"Std{val}", "123456", keyUsed, 1);
                        try
                        {
                            var copy = client.ServiceProxy.GetExamCopyEncryptedZipped(requiredDetails, numOfQ, numOfStd);

                        }
                        catch (Exception ex)
                        {
                            lock (receiveParam)
                            {
                                receiveParam.DroppedMessages += 1;
                            }
                        }
                    }
                });
                lock (tasksReq)
                {
                    tasksReq.Add(t);
                }
            }
            );
            Task.WaitAll(tasksReq.ToArray());
            stopwatchReceiving.Stop();
            receiveParam.TimeRequired = stopwatchReceiving;
            ReceivingResults.Add(receiveParam);


            SortedList<string, KeyValuePair<RequiredDetails, string>> ExamsToSubmit = new SortedList<string, KeyValuePair<RequiredDetails, string>>();

            if (type == TestType.SubmitExam || type == TestType.Both) // we need to answer and submit aswell 
            {
                //  List<KeyValuePair<RequiredDetails, string>> ExamsToSubmit = new List<KeyValuePair<RequiredDetails, string>>();
                Parallel.For(0, numOfStd, index =>
                {
                    var val = index % numOfStd;
                    var keyUsed = $"Keyyyyyyy{val}";
                    //STEP 2 : Answering the EXAM (assuming all students will have the same answers)
                    var examCopyUnencrypted = ExamHelper.GetExamFromByteArray(ExamsReceived[keyUsed], "123456", keyUsed, secucirytLevel);
                    examCopyUnencrypted.ExamLog = new List<string>();
                    examCopyUnencrypted.RequiredStudentDetails.SequenceNumber = (long.Parse(examCopyUnencrypted.RequiredStudentDetails.SequenceNumber) + 1).ToString();
                    var rD = examCopyUnencrypted.RequiredStudentDetails;
                    var examEncrypted = ExamHelper.GetExamFileWithoutSave(examCopyUnencrypted, "123456", keyUsed, secucirytLevel);
                    rD.EncryptDetails();
                    lock (ExamsToSubmit)
                    {
                        if (!ExamsToSubmit.Keys.Contains(keyUsed))
                        {

                            ExamsToSubmit.Add(keyUsed, new KeyValuePair<RequiredDetails, string>(rD, examEncrypted));
                        }
                    }
                });


                ExamsReceived = null;
                var stopwatchSubmitting = Stopwatch.StartNew();
                //step 3 Submit (we want to measure only this


                List<Task> tasks = new List<Task>();


                Parallel.For(0, submitParam.MethodCallCount, index =>
                  {
                      var t = Task.Run(() =>
                        {
                            var val = index % numOfStd;
                            var keyUsed = $"Keyyyyyyy{val}";
                            try
                            {
                                using (var clientSubmit = ScsServiceClientBuilder.CreateClient<INetworkExamServiceTesting>(endpoint))
                                {
                                    clientSubmit.Connect();
                                    clientSubmit.ServiceProxy.SubmitExamEncryptedZipped(ExamsToSubmit[keyUsed].Value, ExamsToSubmit[keyUsed].Key, numOfQ, numOfStd);
                                }
                            }
                            catch (Exception ex)
                            {
                                lock (submitParam)
                                {
                                    submitParam.DroppedMessages += 1;
                                }
                            }
                        });
                      lock (tasks)
                      {
                          tasks.Add(t);
                      }

                  });

                Task.WaitAll(tasks.ToArray());
                stopwatchSubmitting.Stop();
                submitParam.TimeRequired = stopwatchSubmitting;
                SubmissionResults.Add(submitParam);
            }
        }
        //static async void SendExam(ScsTcpEndPoint endpoint, string X, RequiredDetails Y, int Z, int W)
        //{
        //    await Task.Run(() =>
        //   {
        //       using (var clientSubmit = ScsServiceClientBuilder.CreateClient<INetworkExamServiceTesting>(endpoint))
        //       {
        //           clientSubmit.Connect();
        //           clientSubmit.ServiceProxy.SubmitExamEncryptedZipped(X, Y, Z, W);
        //       }
        //   });
        //}
        private void PerformTest(TestType type)
        {
            ReceivingResults.Clear();
            SubmissionResults.Clear();
            try
            {
                for (int nS = NumberOfStudetnInit; nS <= NumberOfStudentsMax; nS += StudentsStep)
                {
                    for (int nQ = NumberOfQuestionsInit; nQ <= NumberOfQuestionsMax; nQ += QuestionsStep)
                    {
                        aLogger.LogMessage($"Currently Testing nS=[{nS}/{NumberOfStudentsMax}], nQ=[{nQ}/{NumberOfQuestionsMax}]", LogMsgType.Debug);
                        richTextBox1.ScrollToCaret();
                        Application.DoEvents();
                        PerformTest(type, nQ, nS);
                    }
                }
            }
            catch (Exception ex)
            {
                aLogger.LogMessage("Couldn't continue ... [inner]" + ex.ToString(), LogMsgType.Fatal);
            }
            finally
            {

                richTextBox1.AppendText("TestSize,numOfStds,numOfQs,TotalDurationms,ExamsPerSecond,AvgLatencyms,DroppedMessages");
                foreach (var r in ReceivingResults)
                {
                    richTextBox1.AppendText($"{numberOfTimesTxtBox.Text},{r.NumberOfStudent},{r.NumberOfQuestions},{Math.Round((double)r.TimeRequired.ElapsedMilliseconds, 1)},{r.Throughput},{r.Latency},{r.DroppedMessages}\n");
                    aLogger.LogMessage($"##Time={numberOfTimesTxtBox.Text},nS={r.NumberOfStudent},nQ={r.NumberOfQuestions},TotalTime={r.TotalTimeMilliSeconds},Throughput={r.Throughput},Latency={r.Latency},DroppedMessage={r.DroppedMessages}", LogMsgType.Verbose);
                }
                if (type == TestType.SubmitExam || type == TestType.Both)
                {
                    foreach (var r in SubmissionResults)
                    {
                        richTextBox1.AppendText($"{numberOfTimesTxtBox.Text},{r.NumberOfStudent},{r.NumberOfQuestions},{Math.Round((double)r.TimeRequired.ElapsedMilliseconds, 1)},{r.Throughput},{r.Latency},{r.DroppedMessages}\n");
                        aLogger.LogMessage($"##Time={numberOfTimesTxtBox.Text},nS={r.NumberOfStudent},nQ={r.NumberOfQuestions},TotalTime={r.TotalTimeMilliSeconds},Throughput={r.Throughput},Latency={r.Latency},DroppedMessage={r.DroppedMessages}", LogMsgType.Verbose);
                    }
                }

                try
                {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            string selectedPath = fbd.SelectedPath;
                            string securitySetting = (highSecChkBox.Checked) ? "High" : "Moderate";
                            string fileExtension = ".csv";
                            string fileHeader = "TestSize,numOfStds,numOfQs,TotalDurationms,ExamsPerSecond,AvgLatencyms,DroppedMessages";
                            string latexFilePathRcvLatency = Path.Combine(selectedPath, $"{securitySetting}_Get_Latency.tex");
                            string latexFilePathSubmitLatency = Path.Combine(selectedPath, $"{securitySetting}_Submit_Latency.tex");
                            string latexFilePathRcvThrougput = Path.Combine(selectedPath, $"{securitySetting}_Get_Througput.tex");
                            string latexFilePathSubmitThrougput = Path.Combine(selectedPath, $"{securitySetting}_Submit_Througput.tex");

                            StringBuilder TempTeXRcvLatency = new StringBuilder();
                            StringBuilder TempTeXSubmitLatency = new StringBuilder();

                            StringBuilder TempTeXRcvThrougput = new StringBuilder();
                            StringBuilder TempTeXSubmitThrougput = new StringBuilder();

                            var groupedReceivedResults = ReceivingResults.GroupBy(x => x.NumberOfStudent);
                            foreach (var sR in groupedReceivedResults)
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.AppendLine(fileHeader);
                                foreach (var r in sR)
                                {
                                    sb.AppendLine($"{numberOfTimesTxtBox.Text},{r.NumberOfStudent},{r.NumberOfQuestions},{Math.Round((double)r.TimeRequired.ElapsedMilliseconds, 1)},{r.Throughput},{r.Latency},{r.DroppedMessages}");
                                }
                                var temp = $"{securitySetting}_Get_{sR.Key}Stds{fileExtension}";
                                var fileName = Path.Combine(selectedPath, temp);
                                File.WriteAllText(fileName, sb.ToString());
                                TempTeXRcvLatency.AppendLine("\\addplot +[smooth,thick] table [col sep=comma, x=numOfQs,y=AvgLatencyms] {Results/FCT/" + temp + "};");
                                TempTeXRcvLatency.AppendLine("\\addlegendentry{N =" + sR.Key + ",SL=" + securitySetting + "}");

                                TempTeXRcvThrougput.AppendLine("\\addplot +[smooth,thick] table [col sep=comma, x=numOfQs,y=ExamsPerSecond] {Results/FCT/" + temp + "};");
                                TempTeXRcvThrougput.AppendLine("\\addlegendentry{N =" + sR.Key + ",SL=" + securitySetting + "}");
                            }
                            File.WriteAllText(latexFilePathRcvLatency, TempTeXRcvLatency.ToString());
                            File.WriteAllText(latexFilePathRcvThrougput, TempTeXRcvThrougput.ToString());

                            if (type == TestType.SubmitExam || type == TestType.Both)
                            {
                                var groupedSubmitResults = SubmissionResults.GroupBy(x => x.NumberOfStudent);
                                foreach (var sR in groupedSubmitResults)
                                {
                                    StringBuilder sb = new StringBuilder();
                                    sb.AppendLine(fileHeader);
                                    foreach (var r in sR)
                                    {
                                        sb.AppendLine($"{numberOfTimesTxtBox.Text},{r.NumberOfStudent},{r.NumberOfQuestions},{Math.Round((double)r.TimeRequired.ElapsedMilliseconds, 1)},{r.Throughput},{r.Latency},{r.DroppedMessages}");
                                    }
                                    var temp = $"{securitySetting}_Submit_{sR.Key}Stds{fileExtension}";
                                    var fileName = Path.Combine(selectedPath, temp);
                                    File.WriteAllText(fileName, sb.ToString());
                                    TempTeXSubmitLatency.AppendLine("\\addplot +[smooth,thick] table [col sep=comma, x=numOfQs,y=AvgLatencyms] {Results/FCT/" + temp + "};");
                                    TempTeXSubmitLatency.AppendLine("\\addlegendentry{N =" + sR.Key + ",SL=" + securitySetting + "}");

                                    TempTeXSubmitThrougput.AppendLine("\\addplot +[smooth,thick] table [col sep=comma, x=numOfQs,y=ExamsPerSecond] {Results/FCT/" + temp + "};");
                                    TempTeXSubmitThrougput.AppendLine("\\addlegendentry{N =" + sR.Key + ",SL=" + securitySetting + "}");
                                }
                                File.WriteAllText(latexFilePathSubmitLatency, TempTeXSubmitLatency.ToString());
                                File.WriteAllText(latexFilePathSubmitThrougput, TempTeXSubmitThrougput.ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Couldnt write results to files..." + ex.ToString());
                }

            }
            aLogger.LogMessage("DONE", LogMsgType.Debug);
        }


        private void startClientBtn_Click(object sender, EventArgs e)
        {
            PerformTest(TestType.GetExam);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PerformTest(TestType.Both);
        }
    }






}
