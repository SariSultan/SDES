using System;
using System.Collections.Generic;
using ForensicsCourseToolkit.Framework_Project.Security.Crypto;

namespace ForensicsCourseToolkit.Framework_Project.Quizez
{
    [Serializable]
    public class Exam
    {
        public Exam()
        {

        }
        public RequiredDetails RequiredStudentDetails { get; set; }
        public List<Question> QuestionsList { get; set; }
        public string ExamDescription { get; set; }
        public int ExamDuration { get; set; }

        public List<string> ExamLog { get; set; }

        public Exam(List<Question> questions, string instructorPassword, string examDescription, int examDurationsMins, bool dontEncrypt=false)
        {
            QuestionsList = questions;
            ExamDescription = examDescription;
            ExamDuration = examDurationsMins;

            try
            {
                if (!dontEncrypt)
                    EncryptAnswerandExplanation(instructorPassword);
            }
            catch (Exception ex)
            {
                throw new Exception("[Exception while encryption answers] + [inner] " + ex.ToString());
            }

            int qnCnt = 1;
            foreach (var q in questions)
            {
                q.QuestionNumber = qnCnt++;
            }
        }

        public void EncryptAnswerandExplanation(string instructorPassword)
        {
            foreach (var q in QuestionsList)
            {
                q.Answer = AESGCM.SimpleEncryptWithPassword(q.Answer, instructorPassword);
                q.AnswerExplanation = AESGCM.SimpleEncryptWithPassword(q.AnswerExplanation, instructorPassword);
            }
        }
        public string GetExamGrade(string instructorPassword)
        {
            double grade = 0;
            double maxGrade = 0;

            foreach (var q in QuestionsList)
            {
                maxGrade += q.Grades;
                grade += (q.StudentAnsweredCorrectly(instructorPassword)) ? q.Grades : 0;
            }
            return $"{grade}/{maxGrade}";
        }
    }
}