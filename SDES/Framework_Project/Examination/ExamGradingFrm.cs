using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForensicsCourseToolkit.Common.Helpers;
using ForensicsCourseToolkit.Framework_Project.Quizez;

namespace ForensicsCourseToolkit.Framework_Project.Examination
{
    public partial class ExamGradingFrm : Form
    {
        List<Exam> ExamsToGrade;
        Logger aLogger;
        public ExamGradingFrm()
        {
            InitializeComponent();
            ExamsToGrade = new List<Exam>();
            aLogger = new Logger(ref richTextBox1);
        }

        private void showPasswordChkBox_CheckedChanged(object sender, EventArgs e)
        {
            studentPassTxtBox.UseSystemPasswordChar = !showPasswordChkBox.Checked;
        }

        private void showInstructorPassChkBox_CheckedChanged(object sender, EventArgs e)
        {
            instructorPassTxtBox.UseSystemPasswordChar = !showInstructorPassChkBox.Checked;
        }

        private void openExamBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opendialog = new OpenFileDialog();
                opendialog.Filter = "FCT Exam File (*.FCTANS)|*.FCTANS";
                opendialog.DefaultExt = "FCTANS";
                opendialog.AddExtension = true;

                if (opendialog.ShowDialog() == DialogResult.OK)
                {
                  //  var examStringEncrypted = ExamHelper.GetExamFileAsBytes(opendialog.FileName);
                    ExamsToGrade.Add(ExamHelper.GetExamFromFile(opendialog.FileName, studentPassTxtBox.Text,"",Security.FilterationSecurityLevel.Moderate));
                    aLogger.LogMessage($" Added Exam File from [{opendialog.FileName}]", LogMsgType.Verbose);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            if(ExamsToGrade?.Count==0)
            {
                MessageBox.Show("There are no exams loaded to grade.");
                return;
            }
            GradingExamHelper.GradeExamsAndGenerateReport(ref richTextBox1, eventLogChkBox.Checked, studentPassTxtBox.Text, instructorPassTxtBox.Text
                  , ExamsToGrade);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var ext = new List<string> { "fctans" };
                
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        var myFiles = Directory.GetFiles(fbd.SelectedPath, "*.fctans", SearchOption.AllDirectories).ToList();

                       // var myFiles = Directory.GetFiles(fbd.SelectedPath, "*.*", SearchOption.AllDirectories)
                           //            .Where(s => ext.Contains(Path.GetExtension(s))).ToList();
                        int cnt = 0;
                        foreach (var file in myFiles)
                        {
                            try { 
                            ExamsToGrade.Add(ExamHelper.GetExamFromFile(file, studentPassTxtBox.Text,"",Security.FilterationSecurityLevel.Moderate));
                            aLogger.LogMessage($" Added Exam File from [{file}]", LogMsgType.Verbose);
                                cnt++;
                            }
                            catch(Exception ex)
                            {
                                aLogger.LogMessage($"Failed to get file name [{file}], possibly its an invalid exam file (Execption msg: {ex.Message})",LogMsgType.Error);
                            }
                        }

                        aLogger.LogMessage($" TOTAL OF {cnt} exams are loaded correctly, click on Grade files to get the report", LogMsgType.Verbose);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
