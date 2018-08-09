using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using ForensicsCourseToolkit.Framework_Project.Security.Crypto;

namespace ForensicsCourseToolkit.Framework_Project.Quizez
{
    [Serializable]
    [XmlInclude(typeof(MultipleChoiceQuestion))]
    [XmlInclude(typeof(TrueFalseQuestion))]
    [XmlInclude(typeof(ValueInputQuestion))]
    public class Question
    {
        public int QuestionNumber { get; set; }
        public Question()
        {

        }

        public string QuestionAltenativesDescription
        {
            get
            {
                var x = "";
                for (int i = 0; i < Choices.Count; i++)
                {
                    x += $" {QuizHelper.letters[i]}. {Choices[i]} \t";
                }
                return x;
            }
        }

        //-------------------
        public string Description { get; set; }
        public string Asset { get; set; }
        public string Answer { get; set; }
        public string AnswerExplanation { get; set; }
        public List<string> Choices { get; set; }
        public double Grades { get; set; }
        public QuizHelper.QuestionDifficulty Difficulty { get; set; }

        public string StudentAnswer { get; set; }

        public virtual bool StudentAnsweredCorrectly(string intructorPassword)
        {
            var correctAnswer = AESGCM.SimpleDecryptWithPassword(Answer, intructorPassword);
            if (this.GetType() == typeof(TrueFalseQuestion))
            {
                int option = ((TrueFalseQuestion)this).RandomChoice;
                if (Choices[option] == correctAnswer)
                    return (StudentAnswer == true.ToString());
                else
                    return (StudentAnswer == false.ToString());
            }
            // else if (this.GetType() == typeof(MultipleChoiceQuestion))
            {
                return correctAnswer == StudentAnswer;
            }

        }
        public Question(string questionDescription, string questionAsset, string correctAnswer, string answerDescription,
            List<string> questionchoices, double questionGrade, QuizHelper.QuestionDifficulty questionDifficulty
        )
        {
            Description = questionDescription;
            Asset = questionAsset;
            Answer = correctAnswer;
            AnswerExplanation = answerDescription;
            Choices = questionchoices;
            Choices.Shuffle();
            Grades = questionGrade;
            Difficulty = questionDifficulty;

            if (questionchoices.Count <= 1)
            {
                throw new Exception($"[EXCEPTION] Number of choices for this questions i <=1, you need to provide more choices.");
            }
        }


        public override string ToString()
        {
            return $"{Description}";
        }
    }
}