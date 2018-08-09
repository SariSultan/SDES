using Hik.Communication.Scs.Communication.EndPoints;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ForensicsCourseToolkit.Framework_Project
{
    [Serializable]
    public class ExamStatusUpdate
    {
        public ExamStatusUpdate()
        {

        }

        public ExamStatusUpdate(RequiredDetails details)
        {
            Details = details;
            sent = false;
            submitted = false;
        }
        public RequiredDetails Details { get; set; }
        public bool sent { get; set; }
        public string weSentHimExamDateAndDetails { get; set; }
        public string submittedExamDateandDetails { get; set; }
        public bool submitted { get; set; }
        public string ExamSubmission { get; set; }


        public void UpdateSendInfo(string sendInfo)
        {
            sent = true;
            weSentHimExamDateAndDetails = sendInfo;
        }

        public void UpdateSubmitInfo(string examSubmission, string submissionInfo)
        {
            submitted = true;
            ExamSubmission = examSubmission;
            submittedExamDateandDetails = submissionInfo;
        }
    }
}
