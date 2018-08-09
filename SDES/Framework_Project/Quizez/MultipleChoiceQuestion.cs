using System;
using System.Collections.Generic;

namespace ForensicsCourseToolkit.Framework_Project.Quizez
{
    [Serializable]
    public class MultipleChoiceQuestion : Question
    {
        public MultipleChoiceQuestion()
        {

        }
        private int RandomChoice { get; set; }
        public MultipleChoiceQuestion(string questionDescription, string questionAsset, string correctAnswer, string answerDescription,
            List<string> questionchoices, double questionGrade, QuizHelper.QuestionDifficulty questionDifficulty
        ) : base(questionDescription, questionAsset, correctAnswer, answerDescription, questionchoices, questionGrade, questionDifficulty)
        {
            Random rnd = new Random();
            RandomChoice = rnd.Next(Choices.Count);

            //for (int i = 0; i < Choices.Count; i++)
            //{
            //    QuestionAltenativesDescription = $"{QuestionAltenativesDescription} {QuizHelper.letters[i]}. {Choices[i]} \t";
            //}

        }

        public override string ToString()
        {
            return $"[Multiple Choice]: {base.ToString()}?";
        }
    }
}