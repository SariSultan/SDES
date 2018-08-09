using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ForensicsCourseToolkit.Common.Helpers;
using ForensicsCourseToolkit.Framework_Project.Security.Crypto;

namespace ForensicsCourseToolkit.Framework_Project.Quizez
{
    public static class QuizHelper
    {
        public static int questionNumber = 1;
        private static bool addAnswers = true;
        private static bool addAssets = true;

        private static List<Question> FinalQuestions;

        public static void SetAddAnswers(bool value)
        {
            addAnswers = value;
        }
        public static void SetAddAssets(bool value)
        {
            addAssets = value;
        }
        public static void AddQuestionsToFlowLayout(List<QuestionForms> questionsList, ref FlowLayoutPanel flowLayout, ref RichTextBox rtb, ref Logger aLogger, ref List<Question> finalQuestions)
        {
            FinalQuestions = finalQuestions;
            RichTextBox aRtb = rtb;
            //int aquestionCounter = questionCounte;r
            foreach (var forms in questionsList)
            {
                Label generalDescriptionLabel = new Label();
                generalDescriptionLabel.Text = forms.questions[0].Description;
                generalDescriptionLabel.Font = new Font("Courier New", 14, FontStyle.Bold);
                generalDescriptionLabel.AutoSize = true;

                flowLayout.Controls.Add(generalDescriptionLabel);
                flowLayout.SetFlowBreak(generalDescriptionLabel, true);
                foreach (var question in forms.questions)
                {
                    Button question1Btn = new Button();
                    question1Btn.Tag = question;
                    question1Btn.AutoSize = true;
                    question1Btn.Text = "<- Add";
                    question1Btn.Click += (s, ee) =>
                    {
                        QuizHelper.AddQuestionTortb(ref aRtb, questionNumber++, (Question)((Button)s).Tag, addAssets, addAnswers);
                        FinalQuestions.Add((Question)((Button)s).Tag);

                    };
                    Label question1Lbl = new Label();
                    question1Lbl.Text = question.ToString();
                    question1Lbl.AutoSize = true;
                    Label question1Answer = new Label();
                    question1Answer.Text = question.Answer;
                    question1Answer.BackColor = Color.Green;
                    question1Answer.AutoSize = true;


                    flowLayout.Controls.Add(question1Btn);

                    flowLayout.Controls.Add(question1Lbl);

                    flowLayout.Controls.Add(question1Answer);
                    flowLayout.SetFlowBreak(question1Answer, true);
                }

            }
        }

        //public delegate string AnswerFunction( );
        //public delegate string QuestionAsset();
        public static char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K' };
        public enum InputValueType : int
        {
            Integer = 1,
            Double,
            HexVlaue,
            String,
        }

        public enum QuestionDifficulty : int
        {
            Easy = 1,
            Medium,
            Hard,
        }


        public static void AddQuestionTortb(ref RichTextBox rtb, int counter, Question aQuestion, bool addsrcMaterial = false, bool addAnswer = false)
        {
            int padright = 30;
            // 
            rtb.AppendText(System.Environment.NewLine);
            rtb.AppendText($"Question. {counter} [{aQuestion.Grades} " + ((aQuestion.Grades == 1) ? "Point" : "Points") + $"]:", new System.Drawing.Font("Courier New", 16, System.Drawing.FontStyle.Bold));
            rtb.AppendText(System.Environment.NewLine);
            if (addsrcMaterial)
            {
                rtb.AppendText(aQuestion.Asset, new System.Drawing.Font("Courier New", 8));
                rtb.AppendText(System.Environment.NewLine);
            }
            rtb.AppendText(aQuestion.ToString(), new System.Drawing.Font("Courier New", 12, FontStyle.Bold));
            rtb.AppendText(System.Environment.NewLine);

            rtb.AppendText($"{aQuestion.QuestionAltenativesDescription}".PadRight(padright));


            if (addAnswer)
            {
                rtb.AppendText(System.Environment.NewLine);
                rtb.AppendText($"[Answer:] {aQuestion.Answer} [Explanation:] {aQuestion.AnswerExplanation}", System.Drawing.Color.Green);
            }

            rtb.AppendText(System.Environment.NewLine);
        }

        public static void AddGradedQuestionToRtb(ref RichTextBox rtb, int counter, Question aQuestion,string instructorPassword, bool addAnswer = true, bool addExplanation=true)
        {
            bool correctAnswer = false;
            int padright = 30;
            // 
            rtb.AppendText(System.Environment.NewLine);
            rtb.AppendText($"Question. {counter} [{aQuestion.Grades} " + ((aQuestion.Grades == 1) ? "Point" : "Points") + $"]:", new System.Drawing.Font("Courier New", 16, System.Drawing.FontStyle.Bold));
            if (aQuestion.StudentAnsweredCorrectly(instructorPassword))
            {
                correctAnswer = true;
                rtb.AppendText($"(Correct)", new System.Drawing.Font("Courier New", 16, System.Drawing.FontStyle.Bold), Color.Green);
            }
            else
            {
                rtb.AppendText($"(Wrong)", new System.Drawing.Font("Courier New", 16, System.Drawing.FontStyle.Bold), Color.Red);
            }
            rtb.AppendText(System.Environment.NewLine);

            rtb.AppendText(aQuestion.ToString(), new System.Drawing.Font("Courier New", 12, FontStyle.Bold));
            rtb.AppendText(System.Environment.NewLine);

            rtb.AppendText($"{aQuestion.QuestionAltenativesDescription}".PadRight(padright));

            
            var cA = AESGCM.SimpleDecryptWithPassword(aQuestion.Answer, instructorPassword);
            var studentAns = "";
            if (aQuestion.GetType() == typeof(TrueFalseQuestion))
            {
                int option = ((TrueFalseQuestion)aQuestion).RandomChoice;
                
                var correctAnsTrueFalse = (aQuestion.Choices[option] != cA).ToString();

                studentAns = (aQuestion.StudentAnswer == correctAnsTrueFalse).ToString();
                rtb.AppendText(System.Environment.NewLine);
                rtb.AppendText($"[Student Answer:] {studentAns} ", new System.Drawing.Font("Courier New", 12, FontStyle.Bold), (correctAnswer ? Color.Green : Color.Red));
            }
            else
            {
                rtb.AppendText(System.Environment.NewLine);
                rtb.AppendText($"[Student Answer:] {aQuestion.StudentAnswer} ", new System.Drawing.Font("Courier New", 12, FontStyle.Bold), (correctAnswer ? Color.Green : Color.Red));
            }
           

            if (addAnswer && !correctAnswer)
            {
                rtb.AppendText(System.Environment.NewLine);
                rtb.AppendText($"[Correct Answer:] {AESGCM.SimpleDecryptWithPassword(aQuestion.Answer,instructorPassword)} ", System.Drawing.Color.Green);


            }
            if (addExplanation && !correctAnswer)
            {
                rtb.AppendText(System.Environment.NewLine);
                rtb.AppendText($"[Explanation:] {AESGCM.SimpleDecryptWithPassword(aQuestion.AnswerExplanation, instructorPassword)}", Color.Green);
            }


            rtb.AppendText(System.Environment.NewLine);
        }
    }
}
