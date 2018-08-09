using System;
using System.Collections.Generic;

namespace ForensicsCourseToolkit.Framework_Project.Quizez
{
    [Serializable]
    public class ValueInputQuestion : Question
    {
        public ValueInputQuestion()
        {

        }
        private QuizHelper.InputValueType InputType { get; set; }
        public ValueInputQuestion(string questionDescription, string questionAsset, string correctAnswer, string answerDescription,
            List<string> questionchoices, double questionGrade, QuizHelper.QuestionDifficulty questionDifficulty, QuizHelper.InputValueType inputtype
        ) : base(questionDescription, questionAsset, correctAnswer, answerDescription, questionchoices, questionGrade, questionDifficulty)
        {
            InputType = inputtype;

          //  QuestionAltenativesDescription += $"_____________";
        }

        public override string ToString()
        {
            return $"[Input Value]: {base.ToString()}?";
        }
    }
}