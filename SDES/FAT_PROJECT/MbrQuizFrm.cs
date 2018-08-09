using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ForensicsCourseToolkit.Common;
using ForensicsCourseToolkit.Common.Helpers;
using ForensicsCourseToolkit.Framework_Project;
using ForensicsCourseToolkit.Framework_Project.Quizez;
using ForensicsCourseToolkit.Framework_Project.Security.Crypto;

namespace ForensicsCourseToolkit.FAT_PROJECT
{
    public partial class MbrQuizFrm : Form
    {
        #region VARIABLES


        private Logger aLogger;
        private Mbr anMbr;



        private string fileName = "";

        #endregion
        public MbrQuizFrm()
        {
            InitializeComponent();

            richTextBox1.WordWrap = false;

            aLogger = new Logger(ref richTextBox1);
        }

        #region RTB EVENTS

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //click event
                //MessageBox.Show("you got it!");
                var contextMenu = new ContextMenu();
                var menuItem = new MenuItem("Cut");
                menuItem.Click += RtbExtensions.CutAction;
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Copy");
                menuItem.Click += RtbExtensions.CopyAction;
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Paste");
                menuItem.Click += RtbExtensions.PasteAction;
                contextMenu.MenuItems.Add(menuItem);

                menuItem = new MenuItem("Covert Value to Int (Little Endian)");
                menuItem.Click += RtbExtensions.LittleEndiaCovert;
                contextMenu.MenuItems.Add(menuItem);


                richTextBox1.ContextMenu = contextMenu;
            }
        }

        #endregion RTB EVENTS

        private bool ReadImage(string fileName)
        {
            aLogger.LogMessage($" Opening file [{fileName}]", LogMsgType.Verbose);

            //anMbr = Mbr.ParseMbr(fileName, ref aLogger);
            anMbr = Common.Common.GetUnit<Mbr>(fileName, ref aLogger, 0, "MBR", null);
            if (anMbr == null)
            {
                aLogger.LogMessage($"Unable to read MBR from file [{fileName}], Operation Terminated!", LogMsgType.Error);
                return false;
            }
            aLogger.LogMessage($"Image [{fileName}], Loaded Successfully.", LogMsgType.Verbose);
            return true;
        }
        private void EnableAfterImageLoad()
        {
            listQuestionsBtn.Visible = true;
            //listQuestionsBtn.Text = $"Step {StepsCounter}";

            //printMbrValsBtn.Visible = true;
        }



        #region BUTTONS EVENTS 
        private void openImageBtn_Click(object sender, EventArgs e)
        {

            listQuestionsBtn.Visible = false;
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                aLogger.LogMessage("Did not select a file!", LogMsgType.Debug);
                anMbr = null;

                return;
            }

            fileName = openFileDialog.FileName;
            if (!ReadImage(fileName))
                return;

            EnableAfterImageLoad();
            //PrintColoredMBR(anMbr);
        }
        private void clearBtn_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            QuizHelper.questionNumber = 1;
            FinalQuestions.Clear();
        }

        #endregion


        List<Question> FinalQuestions = new List<Question>();

        private void listQuestionsBtn_Click(object sender, EventArgs e)
        {
            Label stat = new Label { Text = "----------- S T A T I C - Q U E S T I O N S -------------", AutoSize = true };
            flowLayout.Controls.Add(stat);
            flowLayout.SetFlowBreak(stat, true);

            FATFileSystemExamTemplate aFatTemplate = new FATFileSystemExamTemplate(aLogger, ref anMbr);
            QuizHelper.AddQuestionsToFlowLayout(aFatTemplate.GetStaticFATQuestions, ref flowLayout, ref richTextBox1, ref aLogger, ref FinalQuestions);

            Label dyn = new Label { Text = "----------- D Y N A M I C - Q U E S T I O N S -------------", AutoSize = true };
            flowLayout.Controls.Add(dyn);
            flowLayout.SetFlowBreak(dyn, true);
            QuizHelper.AddQuestionsToFlowLayout(aFatTemplate.GetDynamicFATQuestions, ref flowLayout, ref richTextBox1, ref aLogger, ref FinalQuestions);


            addanswersChkBox.CheckedChanged += (o, ee) =>
            {
                QuizHelper.SetAddAnswers(addanswersChkBox.Checked);
            };

            addquestionMaterialChkBox.CheckedChanged += (o, ee) =>
            {
                QuizHelper.SetAddAssets(addquestionMaterialChkBox.Checked);
            };



        }


        private void exportExamBtn_Click(object sender, EventArgs e)
        {
            try
            {
                examDescriptionTxtBox.Text = examDescriptionTxtBox.Text.Trim();
                instructorPassTxtBox.Text = instructorPassTxtBox.Text.Trim();
                studentPassTxtBox.Text = studentPassTxtBox.Text.Trim();
                var errorMSg = "";
                bool error = false;
                if (FinalQuestions.Count == 0)
                {
                    errorMSg += "* Please select some questions first! \n";
                    error = true;
                }
                if (studentPassTxtBox.Text.Length < 6 || instructorPassTxtBox.Text.Length < 6)
                {
                    errorMSg += $"* You should select Instructor and Student passwords. (length at least {AESGCM.MinPasswordLength} chars)\n";
                    error = true;
                }
                if (examDescriptionTxtBox.Text.Trim().Length == 0)
                {
                    errorMSg += "* Please select exam description \n";
                    error = true;
                }
                int examDuration = 0;
                if (!int.TryParse(examDurationTxtBox.Text, out examDuration))
                {
                    errorMSg += "* Selected valid exam duration as integer value in minutes";
                    error = true;
                }

                if (error)
                {
                    MessageBox.Show(errorMSg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                SaveFileDialog adialog = new SaveFileDialog();
                adialog.Filter = "FCT Exam File (*.FCTEX)|*.FCTEX";
                adialog.DefaultExt = "FCTEX";
                adialog.AddExtension = true;
                if (adialog.ShowDialog() == DialogResult.OK)
                {
                    ExamHelper.CreateExamAndSafeToFile(FinalQuestions, examDescriptionTxtBox.Text, examDuration, instructorPassTxtBox.Text, studentPassTxtBox.Text, adialog.FileName);
                    MessageBox.Show("Done, check the file location!");
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void studentPasswordLbl_Click(object sender, EventArgs e)
        {

        }

        private void studentPassTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveXMLBtn_Click(object sender, EventArgs e)
        {
            try
            {
                examDescriptionTxtBox.Text = examDescriptionTxtBox.Text.Trim();
                instructorPassTxtBox.Text = instructorPassTxtBox.Text.Trim();
                studentPassTxtBox.Text = studentPassTxtBox.Text.Trim();
                var errorMSg = "";
                bool error = false;
                if (FinalQuestions.Count == 0)
                {
                    errorMSg += "* Please select some questions first! \n";
                    error = true;
                }
                if (studentPassTxtBox.Text.Length < 6 || instructorPassTxtBox.Text.Length < 6)
                {
                    errorMSg += $"* You should select Instructor and Student passwords. (length at least {AESGCM.MinPasswordLength} chars)\n";
                    error = true;
                }
                if (examDescriptionTxtBox.Text.Trim().Length == 0)
                {
                    errorMSg += "* Please select exam description \n";
                    error = true;
                }
                int examDuration = 0;
                if (!int.TryParse(examDurationTxtBox.Text, out examDuration))
                {
                    errorMSg += "* Selected valid exam duration as integer value in minutes";
                    error = true;
                }

                if (error)
                {
                    MessageBox.Show(errorMSg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                SaveFileDialog adialog = new SaveFileDialog();
                adialog.Filter = "FCT Exam File Template (*.XML)|*.XML";
                adialog.DefaultExt = "XML";
                adialog.AddExtension = true;
                if (adialog.ShowDialog() == DialogResult.OK)
                {
                    ExamHelper.CreateExamAndSafeXMLToFile(FinalQuestions, examDescriptionTxtBox.Text, examDuration, instructorPassTxtBox.Text, studentPassTxtBox.Text, adialog.FileName);
                    MessageBox.Show("Done, check the file location!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void loadXMLBtn_Click(object sender, EventArgs e)
        {

        }

    }


}
