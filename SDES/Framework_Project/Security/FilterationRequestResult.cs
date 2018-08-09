using System;

namespace ForensicsCourseToolkit.Framework_Project.Security
{
    [Serializable]
    public class FilterationRequestResult
    {
        public FilterationRequestResult()
        {

        }
        public FilterationRequestResult(FilterationResult d, string examCopyToSentBack)
        {
            Decision = d;
            ExamToSendForStudent = examCopyToSentBack;
        }

        public FilterationResult Decision { get; }
        public string ExamToSendForStudent { get; }


    }
}