using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ForensicsCourseToolkit.Framework_Project.Quizez;
using ForensicsCourseToolkit.Framework_Project.Security;
using ForensicsCourseToolkit.Framework_Project.Security.Crypto;

namespace ForensicsCourseToolkit.Framework_Project.Examination
{
    public static class GradingExamHelper
    {
        private static void GradeExamQuestion(ref RichTextBox rtb, bool addLogs, string studentPass, string instructorPassword, Exam anExam)
        {
            var id = AESGCM.SimpleDecryptWithPassword(anExam.RequiredStudentDetails.StudentID, studentPass);
            var name = AESGCM.SimpleDecryptWithPassword(anExam.RequiredStudentDetails.StudentName, studentPass);

            rtb.AppendText($"{anExam.ExamDescription}\n", new System.Drawing.Font("Courier New", 16, System.Drawing.FontStyle.Bold));
            rtb.AppendText($"Student Name: {name}\n", new System.Drawing.Font("Courier New", 16, System.Drawing.FontStyle.Bold));
            rtb.AppendText($"Student ID: {id}\n", new System.Drawing.Font("Courier New", 16, System.Drawing.FontStyle.Bold));
            rtb.AppendText($"Grade: {anExam.GetExamGrade(instructorPassword)}\n", new System.Drawing.Font("Courier New", 18, System.Drawing.FontStyle.Underline));
            // rtb.AppendText($"Exam Sent to Student Date and Comment:{list[i].weSentHimExamDateAndDetails}", new System.Drawing.Font("Courier New", 12, System.Drawing.FontStyle.Italic));
            // rtb.AppendText($"Student Exam Submission Date And Comment:{list[i].weSentHimExamDateAndDetails}", new System.Drawing.Font("Courier New", 12, System.Drawing.FontStyle.Italic));

            foreach (var q in anExam.QuestionsList)
            {
                QuizHelper.AddGradedQuestionToRtb(ref rtb, q.QuestionNumber, q, instructorPassword, true, true);
            }

            if (addLogs)
            {
                rtb.AppendText(System.Environment.NewLine);
                rtb.AppendText($"***** Student Exam Logs *****\n", new System.Drawing.Font("Courier New", 18, System.Drawing.FontStyle.Italic));

                foreach (var s in anExam?.ExamLog)
                {
                    rtb.AppendText($"{s}\n", new System.Drawing.Font("Courier New", 8, System.Drawing.FontStyle.Regular));
                }
            }
            rtb.AppendText($"***** END OF STUDENT {name} EXAM *****\n", new System.Drawing.Font("Courier New", 18, System.Drawing.FontStyle.Italic));
            rtb.AddNewPage();
        }
        public static void GradeExamsAndGenerateReportFromEncrypted(ref RichTextBox rtb, bool addLogs, string studentPass, string instructorPass, SortedList<string, string> encryptedExamFiles,SortedList<string,ExaminationFilterRule> FirewallRules,bool highSecurity)
        {
            rtb.Clear();
            bool includeLogs = addLogs;


            foreach (var item in encryptedExamFiles)
            {
                if (highSecurity)
                {
                    if (FirewallRules.ContainsKey(item.Key))
                    {

                        var examFile = ExamHelper.GetExamFromByteArray(item.Value, studentPass,
                            FirewallRules[item.Key].SharedKeyIS, FilterationSecurityLevel.High);
                        GradeExamQuestion(ref rtb, addLogs, studentPass, instructorPass, examFile);
                    }
                    else
                    {
                        rtb.AppendText($" \n CANNOT GRADE stdID because no shared key available [{item.Key}] \n");
                    }
                }
                else
                {
                    var examFile = ExamHelper.GetExamFromByteArray(item.Value, studentPass, "", FilterationSecurityLevel.Moderate);
                    GradeExamQuestion(ref rtb, addLogs, studentPass, instructorPass, examFile);
                }
            }

            // var list = examsStatusUpdateList;
            //var ExamsEncryptedList = encryptedExamFiles.Select(x => x.Value).ToList();
            //for (int i = 0; i < ExamsEncryptedList.Count; i++)
            //{
                

               
            //}


            var tst = rtb.Rtf.Replace("[NEW_PAGE_AUTOMATIC_HERE]", "\\par \\page");

            SaveFileDialog sdlg = new SaveFileDialog();
            sdlg.FileName = $"StudentExamGradesAnswers";
            sdlg.Filter = "RTF File (*.rtf)|*.rtf";
            sdlg.DefaultExt = "rtf";
            sdlg.ShowDialog();
            File.WriteAllText(sdlg.FileName, tst);
        }

        public static void GradeExamsAndGenerateReport(ref RichTextBox rtb, bool addLogs, string studentPass, string instructorPass, List<Exam> exams)
        {
            rtb.Clear();
            bool includeLogs = addLogs;


            foreach (var examFile in exams)
            {
                GradeExamQuestion(ref rtb, addLogs, studentPass, instructorPass, examFile);
            }


            var tst = rtb.Rtf.Replace("[NEW_PAGE_AUTOMATIC_HERE]", "\\par \\page");

            SaveFileDialog sdlg = new SaveFileDialog();
            sdlg.FileName = $"StudentExamGradesAnswers";
            sdlg.Filter = "RTF File (*.rtf)|*.rtf";
            sdlg.DefaultExt = "rtf";
            sdlg.ShowDialog();
            File.WriteAllText(sdlg.FileName, tst);
        }
    }
}