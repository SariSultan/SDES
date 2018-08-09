using System;

namespace ForensicsCourseToolkit.Framework_Project.Quizez
{
    public class InvalidInstructorPasswordException : Exception
    {
        public InvalidInstructorPasswordException()
        {
        }

        public InvalidInstructorPasswordException(string message)
            : base(message)
        {
        }

        public InvalidInstructorPasswordException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}