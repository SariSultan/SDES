using System;
using System.Collections.Generic;
using ForensicsCourseToolkit.Framework_Project.Quizez;
using ForensicsCourseToolkit.Framework_Project.Security;
using Hik.Communication.ScsServices.Service;

namespace ForensicsCourseToolkit.Framework_Project
{
    public class NetworkExamServicePerformanceTesting : ScsService, INetworkExamServiceTesting
    {
        //----------------------------VARS
        private SortedList<int, ExaminationStudentsFilter> Firewalls;
        public SortedList<string, string> submittedFiles;
        public List<ExamStatusUpdate> ExamSubmissionZippedStringList { get; set; }
        private UpdateStatusDelegate UpdateMethod { get; set; }
        private SortedList<int, Exam> OriginalExamWithNoStdDetails { get; set; }
        private string ExamKey { get; set; }
        //private string InstructorPassword { get; set; }
        //public Logger aLogger { get; set; }


        //-------------------------------CTOR
        public NetworkExamServicePerformanceTesting(SortedList<int, Exam> examEmptyCopies, string examKey,
            UpdateStatusDelegate method, SortedList<int, ExaminationStudentsFilter> firewalls)
        {
            OriginalExamWithNoStdDetails = examEmptyCopies;

            ExamKey = examKey;

            ExamSubmissionZippedStringList = new List<ExamStatusUpdate>();

            //   aLogger = logger;
            UpdateMethod = method;

            submittedFiles = new SortedList<string, string>();

            Firewalls = firewalls;
        }


        //------------------------ NETWORK INTERFACE METHODS

        private string GetIP()
        {
            var ip = CurrentClient.RemoteEndPoint.ToString();
            ip = ip.Replace("tcp://", "");
            ip = ip.Substring(0, ip.IndexOf(':'));
            return ip;
        }
        public string GetExamCopyEncryptedZipped(RequiredDetails details, int numberOfQuestions, int numberOfStds)
        {
            try
            {
                var ret = Firewalls[numberOfStds].GenerateExamCopyForSendingToStudent(OriginalExamWithNoStdDetails[numberOfQuestions], details, GetIP());

                if (ret.Decision != FilterationResult.Accepted)
                {

                    //  aLogger.LogMessage($"Invalid Student Is Asking for Copy from [IP:] {this.CurrentClient.RemoteEndPoint} [ClientID:] {CurrentClient.ClientId} | CONNECTION WILL BE DROPPED. [Reason:] {ret.Decision.ToString()} ", LogMsgType.Verbose);
                    //   this.CurrentClient.Disconnect();

                    return null;
                }
                else
                {
                    return ret.ExamToSendForStudent; // this should include now V updated details
                }
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
                //  aLogger.LogMessage(ex.Message + $"Used Details Are: StdID=[{details.StudentID}], SrcIP=[{CurrentClient.RemoteEndPoint}], ExamKey=[{details.ExamKey}], SharedKey=[{details.SharedKeyIS}]", LogMsgType.Warning);


            }

        }
        public bool SubmitExamEncryptedZipped(string anExamSubmission, RequiredDetails details, int numberofQuestions, int numberOfStudents)
        {
       

            var ret = Firewalls[numberOfStudents].IsValidSubmission(details, GetIP());

            if (ret != FilterationResult.Accepted)
            {
                //    aLogger.LogMessage($"Invalid Student Is Trying To Submit from [IP:] {this.CurrentClient.RemoteEndPoint} [ClientID:] {CurrentClient.ClientId} | CONNECTION WILL BE DROPPED. ", LogMsgType.Verbose);
                // this.CurrentClient.Disconnect();
                return false;
            }




            //var s = ExamSubmissionZippedStringList.
            //    Where(x => x.Details.StudentID
            //     == details.StudentID).FirstOrDefault();
            //if (s == null)
            // {
            //    ExamSubmissionZippedStringList.Add(s = new ExamStatusUpdate(details));
            // }
            // s.UpdateSubmitInfo(anExamSubmission, $"[{DateTime.Now}]a copy of the exam sent to [IP:] {this.CurrentClient.RemoteEndPoint} [StudentName:] {details.StudentName}, [ID:] {details.StudentID}");


            //   try
            //   {
            //       submittedFiles.Add(details.StudentID, anExamSubmission);
            //  aLogger.LogMessage($"Exam Was Submitted By [StudentName:] {details.StudentName}, [ID:] {details.StudentID}", LogMsgType.Verbose);
            //     }
            //    catch (Exception ex)
            //     {
            //  aLogger.LogMessage($"STUDENT TRYING TO SUBMIT TWICE (EXAM DROPPED) [StudentName:] {details.StudentName}, [ID:] {details.StudentID}", LogMsgType.Error);
            //    }
            //UpdateMethod(ExamSubmissionZippedStringList);
            return true;
        }

    }
}