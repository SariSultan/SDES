using System;
using System.Collections.Generic;

namespace ForensicsCourseToolkit.Framework_Project.Quizez
{
    [Serializable]
    public class QuestionForms
    {
        public QuestionForms()
        {

        }
        public List<Question> questions { get; set; }
        private TrueFalseQuestion aTrueFalseQuestion { get; set; }
        private MultipleChoiceQuestion aMultipleChoiceQuestion { get; set; }
        private ValueInputQuestion aValueInputQuestion { get; set; }
        public QuestionForms(Question aQuestion, QuizHelper.InputValueType inputvaluetype)
        {
            aTrueFalseQuestion = new TrueFalseQuestion(aQuestion.Description, aQuestion.Asset, aQuestion.Answer, aQuestion.AnswerExplanation, aQuestion.Choices, aQuestion.Grades, aQuestion.Difficulty);
            aMultipleChoiceQuestion = new MultipleChoiceQuestion(aQuestion.Description, aQuestion.Asset, aQuestion.Answer, aQuestion.AnswerExplanation, aQuestion.Choices, aQuestion.Grades, aQuestion.Difficulty);
            aValueInputQuestion = new ValueInputQuestion(aQuestion.Description, aQuestion.Asset, aQuestion.Answer, aQuestion.AnswerExplanation, aQuestion.Choices, aQuestion.Grades, aQuestion.Difficulty, inputvaluetype);


            questions = new List<Question>()
            {
                aTrueFalseQuestion,
                aMultipleChoiceQuestion,
                aValueInputQuestion,
            };
        }
    }
}