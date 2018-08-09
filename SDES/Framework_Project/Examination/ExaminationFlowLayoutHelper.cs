using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForensicsCourseToolkit.Common.Helpers;
using ForensicsCourseToolkit.Framework_Project.Quizez;

namespace ForensicsCourseToolkit.Framework_Project.Examination
{
    public static class ExaminationFlowLayoutHelper
    {
        public static void AddQuestionToFlowLayout(ref FlowLayoutPanel flowlayout, ref Logger logger, ref Exam anExam,
            ref RichTextBox assetsrtb, ref List<string> anexamLog)
        {
            Logger aLogger = logger;
            List<string> ExamLog = anexamLog;
            for (int i = 0; i < anExam.QuestionsList.Count; i++)
            {
                var question = anExam.QuestionsList[i];
                var questionNumber = question.QuestionNumber;
                QuizHelper.AddQuestionTortb(ref assetsrtb, questionNumber, question, true, false);

                Label question1Lbl = new Label();
                question1Lbl.Text = $"Q{questionNumber}. " + question.ToString();
                question1Lbl.AutoSize = true;
                question1Lbl.Font = new Font("Courier New", 12, FontStyle.Bold);

                flowlayout.Controls.Add(question1Lbl);
                if (question.GetType() == typeof(MultipleChoiceQuestion))
                {
                    GroupBox gb = new GroupBox();
                    gb.Location = new Point(5, 20);
                    gb.MinimumSize = new Size(100, 30);
                    gb.AutoSize = true;
                    gb.AutoSizeMode = AutoSizeMode.GrowOnly;
                    gb.Text = "Choices";
                    gb.Tag = questionNumber;

                    int lastpos = 0;
                    for (int j = 0; j < question.Choices.Count; j++)
                    {
                        var option = question.Choices[j];

                        RadioButton rb = new RadioButton();
                        rb.Location = new Point(7, lastpos += 20);
                        rb.AutoSize = true;
                        rb.Text = option;
                        rb.Font = new Font("Courier New", 12, FontStyle.Bold);
                        rb.CheckedChanged += (s, ee) =>
                        {
                            var rbb = s as RadioButton;
                            if (rbb == null) return;
                            if (rbb.Checked)
                            {
                                question.StudentAnswer = rbb.Text;
                                aLogger.LogMessage($"[Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}", LogMsgType.Verbose);
                                ExamLog.Add($"[{DateTime.Now}] [Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}");
                            }

                        };

                        gb.Controls.Add(rb);
                    }
                    flowlayout.Controls.Add(gb);
                    flowlayout.SetFlowBreak(gb, true);
                }
                else if (question.GetType() == typeof(TrueFalseQuestion))
                {
                    GroupBox gb = new GroupBox();
                    gb.Location = new Point(5, 20);
                    gb.MinimumSize = new Size(100, 50);
                    gb.AutoSize = true;
                    gb.AutoSizeMode = AutoSizeMode.GrowOnly;
                    gb.Text = "Choices";


                    RadioButton rbt = new RadioButton();
                    rbt.Location = new Point(7, 20);
                    rbt.AutoSize = true;
                    rbt.Text = true.ToString();
                    rbt.Font = new Font("Courier New", 12, FontStyle.Bold);

                    rbt.CheckedChanged += (s, ee) =>
                    {
                        var rbb = s as RadioButton;
                        if (rbb == null) return;
                        if (rbb.Checked)
                        {
                            question.StudentAnswer = rbb.Text;
                            aLogger.LogMessage($"[Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}", LogMsgType.Verbose);
                            ExamLog.Add($"[{DateTime.Now}] [Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}");
                        }

                    };

                    gb.Controls.Add(rbt);

                    RadioButton rbf = new RadioButton();
                    rbf.Location = new Point(7, 40);
                    rbf.AutoSize = true;
                    rbf.Text = false.ToString();
                    rbf.Font = new Font("Courier New", 12, FontStyle.Bold);
                    rbf.CheckedChanged += (s, ee) =>
                    {
                        var rbb = s as RadioButton;
                        if (rbb == null) return;
                        if (rbb.Checked)
                        {
                            question.StudentAnswer = rbb.Text;
                            aLogger.LogMessage($"[Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}", LogMsgType.Verbose);
                            ExamLog.Add($"[{DateTime.Now}] [Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}");
                        }

                    };
                    gb.Controls.Add(rbf);


                    flowlayout.Controls.Add(gb);
                    flowlayout.SetFlowBreak(gb, true);

                }
                else if (question.GetType() == typeof(ValueInputQuestion))
                {
                    TextBox tb = new TextBox();
                    tb.Width = 100;
                    tb.TextChanged += (s, ee) =>
                    {
                        question.StudentAnswer = tb.Text;
                        aLogger.LogMessage($"[Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}", LogMsgType.Verbose);
                        ExamLog.Add($"[{DateTime.Now}] [Answer Update for Question {questionNumber}.] [{question.ToString()}]  updated,  student answer = {question.StudentAnswer.ToString()}");
                    };
                    flowlayout.Controls.Add(tb);
                    flowlayout.SetFlowBreak(tb, true);
                }
            }
        }
    }
}
