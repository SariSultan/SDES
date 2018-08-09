using ForensicsCourseToolkit.Framework_Project.Security;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForensicsCourseToolkit.Common.Helpers;
using ForensicsCourseToolkit.Framework_Project.Quizez;
using ForensicsCourseToolkit.Framework_Project.Serialization;

namespace ForensicsCourseToolkit.Framework_Project.Examination
{
    public partial class ExamServer : Form
    {
        Logger aLogger;
        Exam anExam;
        public ExamServer()
        {
            InitializeComponent();
            aLogger = new Logger(ref rtb);
            rtb.TextChanged += (s, ee) =>
            { // set the current caret position to the end
                rtb.SelectionStart = rtb.Text.Length;
                // scroll it automatically
                rtb.ScrollToCaret();
            };

            this.FormClosed += (s, e) => { try { server.Stop(); } catch (Exception ex) { } };
            this.FormClosing += (s, e) => { try { server.Stop(); } catch (Exception ex) { } };

            Disposed += ExamServer_Disposed;
        }

        private void ExamServer_Disposed(object sender, EventArgs e)
        {
            try
            {
                server.Stop();
            }
            catch (Exception ex)
            {

            }
        }



        byte[] examStringEncrypted;
        private void openExamBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opendialog = new OpenFileDialog();
                opendialog.Filter = "FCT Exam File (*.FCTEX)|*.FCTEX";
                opendialog.DefaultExt = "FCTEX";
                opendialog.AddExtension = true;

                if (opendialog.ShowDialog() == DialogResult.OK)
                {
                    examStringEncrypted = ExamHelper.GetExamFileAsBytes(opendialog.FileName);

                    anExam = ExamHelper.GetExamFromFile(opendialog.FileName, studentPassTxtBox.Text, "", FilterationSecurityLevel.Moderate);
                    foreach (var q in anExam.QuestionsList)
                    {
                        QuizHelper.AddQuestionTortb(ref rtb, q.QuestionNumber, q, true, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        IScsServiceApplication server;
        NetworkExamService aService;
        private void startServerBtn_Click(object sender, EventArgs e)
        {
            ExaminationStudentsFilter firewall = new ExaminationStudentsFilter(checkBox1.Checked ? FilterationSecurityLevel.High : FilterationSecurityLevel.Moderate,
               studentPassTxtBox.Text, instructorPassTxtBox.Text,  FirewallRules);
            server = ScsServiceBuilder.CreateService(new ScsTcpEndPoint(int.Parse(portTxtBox.Text)));
            aService = new NetworkExamService(anExam, studentPassTxtBox.Text, ref aLogger, UpdateDetails, firewall);
            //Add Phone Book Service to service application
            server.AddService<INetworkExamService,
                       NetworkExamService>(aService);

            //Start server
            server.Start();

            //Wait user to stop server by pressing Enter
            aLogger.LogMessage(
                "Server Started Successfully", LogMsgType.Verbose);
            //Console.ReadLine();

            //Stop server
            //server.Stop();
        }

        private void UpdateDetails(List<ExamStatusUpdate> list)
        {
            if (dgview.InvokeRequired)
            {
                //MessageBox.Show("Called Invoke");
                dgview.BeginInvoke(new Action<List<ExamStatusUpdate>>(UpdateDetails), list);
                return;
            }
            lock (dgview)
            {
                dgview.Rows.Clear();

                for (int i = 0; i < list.Count; i++)
                {
                    var index = dgview.Rows.Add();

                    dgview.Rows[index].Cells["serialCol"].Value = i + 1;
                    var id = list[i].Details.StudentID; ;
                    dgview.Rows[index].Cells["idCol"].Value = id;
                    dgview.Rows[index].Cells["nameCol"].Value = list[i].Details.StudentName;
                    dgview.Rows[index].Cells["rcvdCol"].Value = list[i].sent ? "Yes" : "No";
                    dgview.Rows[index].Cells["submittedCol"].Value = list[i].submitted ? "Yes" : "No";
                    if (list[i].submitted)
                    {
                        if (checkBox1.Checked) {
                            if (FirewallRules.ContainsKey(list[i].Details.StudentID))
                            {
                                dgview.Rows[index].Cells["gradeCol"].Value =
                                                               ExamHelper.GetExamFromByteArray(aService.submittedFiles[id], studentPassTxtBox.Text,
                                                              list[i].Details.SharedKeyIS, FilterationSecurityLevel.High).GetExamGrade(instructorPassTxtBox.Text);
                            }
                            else
                            {
                                aLogger.LogMessage($"Wrong Exam Submission for stdID [{list[i].Details.StudentID}]",LogMsgType.Error);
                            }
                        }
                        else
                        {
                            dgview.Rows[index].Cells["gradeCol"].Value =
                                ExamHelper.GetExamFromByteArray(aService.submittedFiles[id], studentPassTxtBox.Text, "", FilterationSecurityLevel.Moderate).GetExamGrade(instructorPassTxtBox.Text);
                        }
                    }
                }


            }
        }
        private void showPasswordChkBox_CheckedChanged(object sender, EventArgs e)
        {
            studentPassTxtBox.UseSystemPasswordChar = !showPasswordChkBox.Checked;
        }

        private void stopServerBtn_Click(object sender, EventArgs e)
        {
            server.Stop();
        }

        private void reportBtn_Click(object sender, EventArgs e)
        {

            GradingExamHelper.GradeExamsAndGenerateReportFromEncrypted(ref rtb, eventLogChkBox.Checked, studentPassTxtBox.Text, instructorPassTxtBox.Text
                , aService.submittedFiles,FirewallRules,checkBox1.Checked);
            //rtb.Clear();
            //bool includeLogs = addLogs;

            //var studnetPassword = studentPassTxtBox.Text;
            //var instructorPassword = instructorPassTxtBox.Text;

            //var list = aService.ExamSubmissionZippedStringList;

            //for (int i = 0; i < aService.ExamSubmissionZippedStringList.Count; i++)
            //{

            //    var id = Crypto.AESGCM.SimpleDecryptWithPassword(list[i].Details.StudentID, studentPassTxtBox.Text);
            //    var name = Crypto.AESGCM.SimpleDecryptWithPassword(list[i].Details.StudentName, studentPassTxtBox.Text);
            //    var examFile = ExamHelper.GetExamFromByteArray(aService.submittedFiles[id], studentPassTxtBox.Text);


            //    rtb.AppendText($"{anExam.ExamDescription}\n", new System.Drawing.Font("Courier New", 16, System.Drawing.FontStyle.Bold));
            //    rtb.AppendText($"Student Name: {name}\n", new System.Drawing.Font("Courier New", 16, System.Drawing.FontStyle.Bold));
            //    rtb.AppendText($"Student ID: {id}\n", new System.Drawing.Font("Courier New", 16, System.Drawing.FontStyle.Bold));
            //    rtb.AppendText($"Grade: {examFile.GetExamGrade(instructorPassword)}\n", new System.Drawing.Font("Courier New", 18, System.Drawing.FontStyle.Underline));
            //    rtb.AppendText($"Exam Sent to Student Date and Comment:{list[i].weSentHimExamDateAndDetails}", new System.Drawing.Font("Courier New", 12, System.Drawing.FontStyle.Italic));
            //    rtb.AppendText($"Student Exam Submission Date And Comment:{list[i].weSentHimExamDateAndDetails}", new System.Drawing.Font("Courier New", 12, System.Drawing.FontStyle.Italic));

            //    foreach (var q in examFile.QuestionsList)
            //    {
            //        QuizHelper.AddGradedQuestionToRtb(ref rtb, q.QuestionNumber, q, instructorPassword, true, true);
            //    }

            //    if (includeLogs)
            //    {
            //        rtb.AppendText(System.Environment.NewLine);
            //        rtb.AppendText($"***** Student Exam Logs *****\n", new System.Drawing.Font("Courier New", 18, System.Drawing.FontStyle.Italic));

            //        foreach (var s in examFile?.ExamLog)
            //        {
            //            rtb.AppendText($"{s}\n", new System.Drawing.Font("Courier New", 8, System.Drawing.FontStyle.Regular));
            //        }
            //    }
            //    rtb.AppendText($"***** END OF STUDENT {name} EXAM *****\n", new System.Drawing.Font("Courier New", 18, System.Drawing.FontStyle.Italic));
            //    rtb.AddNewPage();

            //}



            //var tst = rtb.Rtf.Replace("[NEW_PAGE_AUTOMATIC_HERE]", "\\par \\page");

            //SaveFileDialog sdlg = new SaveFileDialog();
            //sdlg.FileName = $"StudentExamGradesAnswers";
            //sdlg.Filter = "RTF File (*.rtf)|*.rtf";
            //sdlg.DefaultExt = "rtf";
            //sdlg.ShowDialog();
            //File.WriteAllText(sdlg.FileName, tst);




        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            openFirewallRules.Visible = checkBox1.Checked;
        }

        SortedList<string, ExaminationFilterRule> FirewallRules;
        private void openFirewallRules_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opendialog = new OpenFileDialog();
                opendialog.Filter = "FCT Firewall Configuration File (*.FCTFirewall)|*.FCTFirewall";
                opendialog.DefaultExt = "FCTFirewall";
                opendialog.AddExtension = true;

                if (opendialog.ShowDialog() == DialogResult.OK)
                {
                    var fileText = File.ReadAllLines(opendialog.FileName).ToList();
                    StringBuilder Errorlog = new StringBuilder();

                    FirewallRules = new SortedList<string, ExaminationFilterRule>();

                    string format = @"ID,Name, SharedKey, EnableIPFilter <YES or NO> , IPList <seperatedwith ; or ANY> \\
                         Example of valid line is \\
                            123456, John Doe, pasSw0rD, Yes, 192.168.1.100";
                    foreach (var line in fileText)
                    {
                        if (line.Trim() == "") continue;
                        if (line.Trim()[0] == '#') continue;

                        var lst = line.Split(',').ToList();
                        if (lst.Count < 5)
                        {
                            Errorlog.AppendLine($"[ERROR] Line [{line}] ignored because it is not formatted as [{format}]");
                            continue;
                        }

                        var r = new ExaminationFilterRule(lst[0].Trim(), lst[1].Trim(), lst[2].Trim(), (lst[3].Trim() == "YES"), lst[4].Trim().Split(';').ToList());
                        FirewallRules.Add(lst[0], r);
                        rtb.AppendText($"[ADDED] {r} \n");
                    }

                    rtb.AppendText(Errorlog.ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opendialog = new OpenFileDialog();
                opendialog.Filter = "FCT Exam File Template (*.XML)|*.XML";
                opendialog.DefaultExt = "XML";
                opendialog.AddExtension = true;

                if (opendialog.ShowDialog() == DialogResult.OK)
                {


                    anExam = SerializationHelper.DeserializeXML<Exam>(File.ReadAllText(opendialog.FileName));
                    
                    foreach (var q in anExam.QuestionsList)
                    {
                        QuizHelper.AddQuestionTortb(ref rtb, q.QuestionNumber, q, true, true);
                    }
                    anExam.EncryptAnswerandExplanation(instructorPassTxtBox.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
