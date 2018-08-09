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
    public partial class ExaminationWindowFromFile : Form
    {
        Logger aLogger;
        Exam anExam;
        Timer myTimer = new Timer();
        RequiredDetails requiredDetails;
        int RemainingExamTime = 0; //in seconds
        List<string> ExamLog = new List<string>();
        public ExaminationWindowFromFile()
        {
            InitializeComponent();
            aLogger = new Logger(ref rtb);
            rtb.TextChanged += (s, ee) =>
            { // set the current caret position to the end
                rtb.SelectionStart = rtb.Text.Length;
                // scroll it automatically
                rtb.ScrollToCaret();
            };           
        }



        private void showPasswordChkBox_CheckedChanged(object sender, EventArgs e)
        {
            studentPassTxtBox.UseSystemPasswordChar = !showPasswordChkBox.Checked;
        }

        private void openExamBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Random r = new Random();
                OpenFileDialog opendialog = new OpenFileDialog();
                opendialog.Filter = "FCT Exam File (*.FCTEX)|*.FCTEX";
                opendialog.DefaultExt = "FCTEX";
                opendialog.AddExtension = true;
                requiredDetails = new RequiredDetails(studentNameTxtBox.Text, studentIDTxtBox.Text, studentPassTxtBox.Text,"TODO");
                if (opendialog.ShowDialog() == DialogResult.OK)
                {
                    var examStringEncrypted = ExamHelper.GetExamFileAsBytes(opendialog.FileName);                   
                    anExam = ExamHelper.GetExamFromFile(opendialog.FileName, studentPassTxtBox.Text,"",Security.FilterationSecurityLevel.Moderate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            if (anExam == null)
            {                
                MessageBox.Show("Invalid Exam");
                return;
            }

            PrepareExamEnvironment();
        }


        private void PrepareExamEnvironment()
        {
            studentIDTxtBox.Enabled = false;
            studentNameTxtBox.Enabled = false;
           
            openExamBtn.Enabled = false;
           
            studentPassTxtBox.Enabled = false;
            showPasswordChkBox.Enabled = false;


            remainingtimeLbl.Visible = true;
            startExamBtn.Visible = true;
            RemainingExamTime = anExam.ExamDuration * 60;
            UpdateRemainingExamTime();
        }

      

        
        private void startExamBtn_Click(object sender, EventArgs e)
        {
            ExamLog.Add($"[{DateTime.Now}] Exam Started");
            startExamBtn.Enabled = false;
            myTimer.Interval = 1000;
            myTimer.Tick += (s, ee) => { RemainingExamTime -= 1; UpdateRemainingExamTime(); };
            myTimer.Start();

            submitExamBtn.Visible = true;

            ExaminationFlowLayoutHelper.AddQuestionToFlowLayout(ref flowlayout, ref aLogger, ref anExam,
                ref assetsrtb, ref ExamLog);

        }

        private void UpdateRemainingExamTime(bool test = false)
        {
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

            while (!saved)
            {
                try
                {
                    if (MessageBox.Show("(Required) Please save your answers file to disk.", "Important Notice", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
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
                            anExam.RequiredStudentDetails = requiredDetails;
                            ExamHelper.SaveExamToFile(anExam, studentPassTxtBox.Text, adialog.FileName);
                            aLogger.LogMessage($"[Student Saved Exam On Disk] [File Location: ({adialog.FileName})]", LogMsgType.Verbose);

                            MessageBox.Show("Done, closing now.");
                            this.Close();
                        }
                    }
                    else
                    {
                        ExamLog.Add($"[{DateTime.Now}] [Student did not save file to disk. You should save it.]");
                    }
                    saved = true;
                }
                catch (Exception ex)
                {
                    ExamLog.Add($"[{DateTime.Now}] [Student Saved Exam On Disk (Process Failed) (exception: {ex.Message}] ");
                    MessageBox.Show("[ERROR] File Did Not Save Correctly, please retry! \n" + ex.Message );
                }
            }
        }
    }

    
}
