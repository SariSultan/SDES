using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForensicsCourseToolkit.Common.Helpers;
using ForensicsCourseToolkit.Framework_Project.Quizez;

namespace ForensicsCourseToolkit.Framework_Project.Examination
{
    public partial class ExaminationWindow : Form
    {
        Logger aLogger;
        Exam anExam;
        Timer myTimer = new Timer();
        int RemainingExamTime = 0; //in seconds
        List<string> ExamLog = new List<string>();
        public ExaminationWindow()
        {
            InitializeComponent();
            aLogger = new Logger(ref rtb);
            rtb.TextChanged += (s, ee) =>
            { // set the current caret position to the end
                rtb.SelectionStart = rtb.Text.Length;
                // scroll it automatically
                rtb.ScrollToCaret();
            };

            Disposed += ExaminationWindow_Disposed;
        }

        private void ExaminationWindow_Disposed(object sender, EventArgs e)
        {
            try
            {
                client.Disconnect();
            }
            catch (Exception ex)
            {

            }
        }

        private void showPasswordChkBox_CheckedChanged(object sender, EventArgs e)
        {
            examKeyTxtBox.UseSystemPasswordChar = !showPasswordChkBox.Checked;
        }

        private void openExamBtn_Click(object sender, EventArgs e)
        {
            GetExamCopy();
            if (anExam == null) return;

            PrepareExamEnvironment();
        }


        private void PrepareExamEnvironment()
        {
            studentIDTxtBox.Enabled = false;
            studentNameTxtBox.Enabled = false;
            ipTxtBox.Enabled = false;
            openExamBtn.Enabled = false;
            portTxtBox.Enabled = false;
            examKeyTxtBox.Enabled = false;
            showPasswordChkBox.Enabled = false;


            remainingtimeLbl.Visible = true;
            startExamBtn.Visible = true;
            RemainingExamTime = anExam.ExamDuration * 60;
            UpdateRemainingExamTime();
        }
       
        IScsServiceClient<INetworkExamService> client;
        bool HighSecurity;
        public void GetExamCopy()
        {
          //  try
            {
                HighSecurity = highSecChkBox.Checked;
                //Create a client to connecto to phone book service on local server and
                //10048 TCP port.
                client = ScsServiceClientBuilder.CreateClient<INetworkExamService>(
                    new ScsTcpEndPoint(ipTxtBox.Text, int.Parse(portTxtBox.Text)));

                // client.Timeout = 3;
                aLogger.LogMessage($"Trying to connect to the server (timeout {client.Timeout} Seconds)", LogMsgType.Verbose);
                //Connect to the server
                client.Connect();

                aLogger.LogMessage("Connected to server", LogMsgType.Verbose);


                RequiredDetails requiredDetails = new RequiredDetails(studentNameTxtBox.Text, studentIDTxtBox.Text, examKeyTxtBox.Text,(HighSecurity? sharedKeyISTxtBox.Text:"Low Security Settings Selected"));
                //Add some persons
                var copy = client.ServiceProxy.GetExamCopyEncryptedZipped(requiredDetails);
                requiredDetails.DecryptDetails(examKeyTxtBox.Text);
                if (!ExamHelper.ValidateExamCopy(copy, examKeyTxtBox.Text, aLogger, sharedKeyISTxtBox.Text,
                     (highSecChkBox.Checked ? Security.FilterationSecurityLevel.High : Security.FilterationSecurityLevel.Moderate), requiredDetails.SequenceNumber))
                    return;

                aLogger.LogMessage("Received Exam Copy", LogMsgType.Verbose);

                aLogger.LogMessage("Checking Exam Copy...", LogMsgType.Verbose);

                var exam = Quizez.ExamHelper.GetExamFromByteArray(copy, examKeyTxtBox.Text,sharedKeyISTxtBox.Text,
                    (highSecChkBox.Checked?Security.FilterationSecurityLevel.High:Security.FilterationSecurityLevel.Moderate));

                aLogger.LogMessage("Exam Checked Correcly ...", LogMsgType.Verbose);

                //Disconnect from server
             //   client.Disconnect();

              //  aLogger.LogMessage("Disconnected from server", LogMsgType.Verbose);

                anExam = exam;
               
            }
           // catch (Exception ex)
            {
              //  aLogger.LogMessage(ex.Message, LogMsgType.Error);

            }
        }

        private void startExamBtn_Click(object sender, EventArgs e)
        {
            ExamLog.Add($"[{DateTime.Now}] Exam Started");
            startExamBtn.Enabled = false;
            myTimer.Interval = 1000;
            myTimer.Tick += (s, ee) => { RemainingExamTime -= 1; UpdateRemainingExamTime(); };
            myTimer.Start();

            submitExamBtn.Visible = true;

            ExaminationFlowLayoutHelper.AddQuestionToFlowLayout(ref flowlayout, ref aLogger, ref anExam, ref assetsrtb, ref ExamLog);
            return;
            // Prepare Questions 

            //for (int i = 0; i < anExam.QuestionsList.Count; i++)
            //{
            //    var question = anExam.QuestionsList[i];
            //    var questionNumber = question.QuestionNumber;
            //    QuizHelper.AddQuestionTortb(ref assetsrtb, questionNumber, question, true, false);


            //    //Button question1Btn = new Button();
            //    //question1Btn.Tag = question;
            //    //question1Btn.AutoSize = true;
            //    //question1Btn.Text = "<- Add";
            //    //question1Btn.Click += (s, ee) =>
            //    //{
            //    //    QuizHelper.AddQuestionTortb(ref aRtb, questionNumber++, (Question)((Button)s).Tag, addAssets, addAnswers);
            //    //    FinalQuestions.Add((Question)((Button)s).Tag);

            //    //};

            //    Label question1Lbl = new Label();
            //    question1Lbl.Text = $"Q{questionNumber}. " + question.ToString();
            //    question1Lbl.AutoSize = true;
            //    question1Lbl.Font = new Font("Courier New", 12, FontStyle.Bold);

            //    flowlayout.Controls.Add(question1Lbl);
            //    // flowlayout.SetFlowBreak(question1Lbl, true);
            //    if (question.GetType() == typeof(MultipleChoiceQuestion))
            //    {
            //        GroupBox gb = new GroupBox();
            //        gb.Location = new Point(5, 20);
            //        gb.MinimumSize = new Size(100, 30);
            //        gb.AutoSize = true;
            //        gb.AutoSizeMode = AutoSizeMode.GrowOnly;
            //        gb.Text = "Choices";
            //        gb.Tag = questionNumber;

            //        int lastpos = 0;
            //        for (int j = 0; j < question.Choices.Count; j++)
            //        {
            //            var option = question.Choices[j];

            //            RadioButton rb = new RadioButton();
            //            rb.Location = new Point(7, lastpos += 20);
            //            rb.AutoSize = true;
            //            rb.Text = option;
            //            rb.Font = new Font("Courier New", 12, FontStyle.Bold);
            //            rb.CheckedChanged += (s, ee) =>
            //            {
            //                var rbb = s as RadioButton;
            //                if (rbb == null) return;
            //                //var selectedRb = gb.Controls.OfType<RadioButton>()
            //                //           .FirstOrDefault(r => r.Checked);
            //                if (rbb.Checked)
            //                {
            //                    question.StudentAnswer = rbb.Text;
            //                    aLogger.LogMessage($"[Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}", LogMsgType.Verbose);
            //                    ExamLog.Add($"[{DateTime.Now}] [Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}");
            //                }

            //            };

            //            gb.Controls.Add(rb);
            //        }
            //        flowlayout.Controls.Add(gb);
            //        flowlayout.SetFlowBreak(gb, true);
            //    }
            //    else if (question.GetType() == typeof(TrueFalseQuestion))
            //    {
            //        GroupBox gb = new GroupBox();
            //        gb.Location = new Point(5, 20);
            //        gb.MinimumSize = new Size(100, 50);
            //        gb.AutoSize = true;
            //        gb.AutoSizeMode = AutoSizeMode.GrowOnly;
            //        gb.Text = "Choices";


            //        RadioButton rbt = new RadioButton();
            //        rbt.Location = new Point(7, 20);
            //        rbt.AutoSize = true;
            //        rbt.Text = true.ToString();
            //        rbt.Font = new Font("Courier New", 12, FontStyle.Bold);

            //        rbt.CheckedChanged += (s, ee) =>
            //        {
            //            var rbb = s as RadioButton;
            //            if (rbb == null) return;
            //                //var selectedRb = gb.Controls.OfType<RadioButton>()
            //                //           .FirstOrDefault(r => r.Checked);
            //                if (rbb.Checked)
            //            {
            //                question.StudentAnswer = rbb.Text;
            //                aLogger.LogMessage($"[Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}", LogMsgType.Verbose);
            //                ExamLog.Add($"[{DateTime.Now}] [Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}");
            //            }

            //        };

            //        gb.Controls.Add(rbt);

            //        RadioButton rbf = new RadioButton();
            //        rbf.Location = new Point(7, 40);
            //        rbf.AutoSize = true;
            //        rbf.Text = false.ToString();
            //        rbf.Font = new Font("Courier New", 12, FontStyle.Bold);
            //        rbf.CheckedChanged += (s, ee) =>
            //        {
            //            var rbb = s as RadioButton;
            //            if (rbb == null) return;
            //            //var selectedRb = gb.Controls.OfType<RadioButton>()
            //            //           .FirstOrDefault(r => r.Checked);
            //            if (rbb.Checked)
            //            {
            //                question.StudentAnswer = rbb.Text;
            //                aLogger.LogMessage($"[Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}", LogMsgType.Verbose);
            //                ExamLog.Add($"[{DateTime.Now}] [Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}");
            //            }

            //        };
            //        gb.Controls.Add(rbf);


            //        flowlayout.Controls.Add(gb);
            //        flowlayout.SetFlowBreak(gb, true);

            //    }
            //    else if (question.GetType() == typeof(ValueInputQuestion))
            //    {
            //        TextBox tb = new TextBox();
            //        tb.Width = 100;
            //        //tb.MouseLeave += (s, ee) =>
            //        //{
            //        //    question.StudentAnswer = tb.Text;
            //        //    aLogger.LogMessage($"[Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}", LogMsgType.Verbose);
            //        //    ExamLog.Add($"[{DateTime.Now}] [Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}");
            //        //};
            //        tb.TextChanged += (s, ee) =>
            //        {
            //            if (_typingTimer == null)
            //            {
            //                /* WinForms: */
            //                _typingTimer = new Timer();
            //                _typingTimer.Interval = 1000;
            //                /* WPF: 
            //                _typingTimer = new DispatcherTimer();
            //                _typingTimer.Interval = TimeSpan.FromMilliseconds(300);
            //                */

            //                _typingTimer.Tick += handleTypingTimerTimeout;
            //            }
            //            _typingTimer.Stop(); // Resets the timer
            //            question.StudentAnswer = tb.Text;
            //            aLogger.LogMessage($"[Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}", LogMsgType.Verbose);
            //            ExamLog.Add($"[{DateTime.Now}] [Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}");
            //            // _typingTimer.Tag = (sender as TextBox).Text; // This should be done with EventArgs
            //            _typingTimer.Start();
            //        };
            //        flowlayout.Controls.Add(tb);
            //        flowlayout.SetFlowBreak(tb, true);
            //    }
           // }
        }

        //Timer _typingTimer; // WinForms
        //private void handleTypingTimerTimeout(object sender, EventArgs e)
        //{
        //    var timer = sender as Timer; // WinForms
        //                                 // var timer = sender as DispatcherTimer; // WPF
        //    if (timer == null)
        //    {
        //        return;
        //    }

        //    // Testing - updates window title
        //    // var isbn = timer.Tag.ToString();


        //    // The timer must be stopped! We want to act only once per keystroke.
        //    timer.Stop();
        //}
        private void UpdateRemainingExamTime(bool test = false)
        {
            //if (remainingtimeLbl.InvokeRequired)
            //{
            //    //MessageBox.Show("Called Invoke");
            //    remainingtimeLbl.BeginInvoke(new Action<bool>(UpdateRemainingExamTime),true);
            //    return;
            //}
            TimeSpan t = TimeSpan.FromSeconds(RemainingExamTime);
            remainingtimeLbl.Text = $"Duration:" + t.ToString(@"hh\:mm\:ss");

            if (RemainingExamTime == 0)
            {
                myTimer.Stop();
            }
        }

        private void submitExamBtn_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            bool error = false;

            string remainingTime = remainingtimeLbl.Text;

            ExamLog.Add($"[{DateTime.Now}] [Student Tried to Submit SUBMIT EXAM] [Remaing time: {remainingTime}]");
            foreach (var q in anExam.QuestionsList)
            {
                if (q.StudentAnswer == string.Empty || q.StudentAnswer == null)
                {
                    error = true;
                    errMsg = errMsg + $" Q{q.QuestionNumber}. ";
                }
            }
            if (error)
            {
                MessageBox.Show("Please provide answers for the following questions before you submit the exam" + errMsg);
                return;
            }

            bool saved = false;

            anExam.RequiredStudentDetails.SequenceNumber = (long.Parse(anExam.RequiredStudentDetails.SequenceNumber) + 1).ToString();
            
            while (!saved)
            {
                try
                {
                    if (MessageBox.Show("(Recommended) Please save file to disk before submitting on network.", "Important Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        SaveFileDialog adialog = new SaveFileDialog();
                        adialog.Filter = "FCT Exam File (*.FCTANS)|*.FCTANS";
                        adialog.DefaultExt = "FCTANS";
                        adialog.FileName = $"{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}-Submission-{studentIDTxtBox.Text}";
                        adialog.AddExtension = true;
                        if (adialog.ShowDialog() == DialogResult.OK)
                        {
                            ExamLog.Add($"[{DateTime.Now}] [Student Saved Exam On Disk] [File Location: ({adialog.FileName})]");
                            anExam.ExamLog = ExamLog;
                            //anExam.RequiredStudentDetails = requiredDetails;
                            ExamHelper.SaveExamToFile(anExam, examKeyTxtBox.Text, adialog.FileName);
                            aLogger.LogMessage($"[Student Saved Exam On Disk] [File Location: ({adialog.FileName})]", LogMsgType.Verbose);
                        }
                    }
                    else
                    {
                        ExamLog.Add($"[{DateTime.Now}] [Student Did not Select To Save File To Disk]");
                    }
                    saved = true;
                }
                catch (Exception ex)
                {
                    ExamLog.Add($"[{DateTime.Now}] [Student Saved Exam On Disk (Process Failed) (exception: {ex.Message}] ");
                    MessageBox.Show("File Did Not Save Correctly, please retry!");
                }
            }

            var reqDetailsEnc = anExam.RequiredStudentDetails;
            reqDetailsEnc.EncryptDetails();

            aLogger.LogMessage("Submitting Exam Through Network ... (Started)", LogMsgType.Verbose);
            anExam.ExamLog = ExamLog;
          //  anExam.RequiredStudentDetails = requiredDetails;
            if (  client.ServiceProxy.SubmitExamEncryptedZipped(ExamHelper.GetExamFileWithoutSave(anExam, examKeyTxtBox.Text, sharedKeyISTxtBox.Text,
                    (highSecChkBox.Checked ? Security.FilterationSecurityLevel.High : Security.FilterationSecurityLevel.Moderate)), reqDetailsEnc))
            {
                aLogger.LogMessage("Submitting Exam Through Network ... (Done Succesfully.)", LogMsgType.Verbose);
                MessageBox.Show("Exam Submitted Correctly. Closing...");
               
                client.Disconnect();
                aLogger.LogMessage("Disconnected from server", LogMsgType.Verbose);
                this.Close();
            }
            else
            {
                aLogger.LogMessage("Submitting Exam Through Network ... (Process Failed)", LogMsgType.Verbose);
                MessageBox.Show("ERROR: Submission Failed. ");
            }
        }

        private void showKeySharedISChkBox_CheckedChanged(object sender, EventArgs e)
        {
            sharedKeyISTxtBox.UseSystemPasswordChar = !showKeySharedISChkBox.Checked;
        }

        private void highSecChkBox_CheckedChanged(object sender, EventArgs e)
        {
            stdPassLbl.Visible = highSecChkBox.Checked;
            sharedKeyISTxtBox.Visible = highSecChkBox.Checked;
            showKeySharedISChkBox.Visible = highSecChkBox.Checked;
        }
    }
}
