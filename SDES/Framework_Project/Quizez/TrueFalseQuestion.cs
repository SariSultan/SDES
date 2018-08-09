using System;
using System.Collections.Generic;

namespace ForensicsCourseToolkit.Framework_Project.Quizez
{
    [Serializable]
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion()
        {

        }
        public int RandomChoice { get; set; }

        public TrueFalseQuestion(string questionDescription, string questionAsset, string correctAnswer, string answerDescription,
            List<string> questionchoices, double questionGrade, QuizHelper.QuestionDifficulty questionDifficulty
        ) : base(questionDescription, questionAsset, correctAnswer, answerDescription, questionchoices, questionGrade, questionDifficulty)
        {
            Random rnd = new Random();
            RandomChoice = rnd.Next(Choices.Count);
        //    QuestionAltenativesDescription = $"A. True\t\t B. False";
        }


        public override string ToString()
        {
            return $"[True/False]: {base.ToString()} is {Choices[RandomChoice]} ?";
        }
    }
}