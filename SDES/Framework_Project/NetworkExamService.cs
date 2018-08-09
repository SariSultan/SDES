using System;
using System.Collections.Generic;
using System.Linq;
using ForensicsCourseToolkit.Common.Helpers;
using ForensicsCourseToolkit.Framework_Project.Quizez;
using ForensicsCourseToolkit.Framework_Project.Security;
using Hik.Communication.ScsServices.Service;

namespace ForensicsCourseToolkit.Framework_Project
{
    public class NetworkExamService : ScsService, INetworkExamService
    {
        //----------------------------VARS
        private ExaminationStudentsFilter Firewall;
        public SortedList<string, string> submittedFiles;
        public List<ExamStatusUpdate> ExamSubmissionZippedStringList { get; set; }
        private UpdateStatusDelegate UpdateMethod { get; set; }
        private Exam OriginalExamWithNoStdDetails { get; set; }
        private string ExamKey { get; set; }
        //private string InstructorPassword { get; set; }
        public Logger aLogger { get; set; }


        //-------------------------------CTOR
        public NetworkExamService(Exam examEmptyCopy, string examKey,
            ref Logger logger, UpdateStatusDelegate method, ExaminationStudentsFilter firewall)
        {
            OriginalExamWithNoStdDetails = examEmptyCopy;

            ExamKey = examKey;

            ExamSubmissionZippedStringList = new List<ExamStatusUpdate>();

            aLogger = logger;
            UpdateMethod = method;

            submittedFiles = new SortedList<string, string>();

            Firewall = firewall;
        }


        //------------------------ NETWORK INTERFACE METHODS

        private string GetIP()
        {
            var ip = CurrentClient.RemoteEndPoint.ToString();
            ip = ip.Replace("tcp://", "");
            ip = ip.Substring(0, ip.IndexOf(':'));
            return ip;
        }
        public string GetExamCopyEncryptedZipped(RequiredDetails details)
        {
            try
            {

                var ret = Firewall.GenerateExamCopyForSendingToStudent(OriginalExamWithNoStdDetails, details, GetIP());

                if (ret.Decision != FilterationResult.Accepted)
                {
                    aLogger.LogMessage($"Invalid Student Is Asking for Copy from [IP:] {this.CurrentClient.RemoteEndPoint} [ClientID:] {CurrentClient.ClientId} | CONNECTION WILL BE DROPPED. [Reason:] {ret.Decision.ToString()} ", LogMsgType.Verbose);
                    this.CurrentClient.Disconnect();

                    return null;
                }
                else
                {

                    var s = ExamSubmissionZippedStringList.
                        Where(x => x.Details.StudentID == details.StudentID).FirstOrDefault();
                    if (s == null)
                    {
                        lock (ExamSubmissionZippedStringList)
                        {
                            ExamSubmissionZippedStringList.Add(s = new ExamStatusUpdate(details));
                        }
                    }
                    lock (s)
                    {
                        s.UpdateSendInfo($"[{DateTime.Now}]a copy of the exam sent to [IP:] {this.CurrentClient.RemoteEndPoint} [StudentName:] {details.StudentName}, [ID:] {details.StudentID}");
                    }
                    aLogger.LogMessage($"a copy of the exam sent to [IP:] {this.CurrentClient.RemoteEndPoint} [StudentName:] {details.StudentName}, [ID:] {details.StudentID}", LogMsgType.Verbose);

                    UpdateMethod(ExamSubmissionZippedStringList);


                    return ret.ExamToSendForStudent; // this should include now V updated details
                }
            }
            catch (Exception ex)
            {
                aLogger.LogMessage(ex.Message + $"Used Details Are: StdID=[{details.StudentID}], SrcIP=[{CurrentClient.RemoteEndPoint}], ExamKey=[{details.ExamKey}], SharedKey=[{details.SharedKeyIS}]", LogMsgType.Warning);
                return null;
            }

        }
        public bool SubmitExamEncryptedZipped(string anExamSubmission, RequiredDetails details)
        {
          

            var ret = Firewall.IsValidSubmission(details, GetIP());

            if (ret != FilterationResult.Accepted)
            {
                aLogger.LogMessage($"Invalid Student Is Trying To Submit from [IP:] {this.CurrentClient.RemoteEndPoint} [ClientID:] {CurrentClient.ClientId} | CONNECTION WILL BE DROPPED. ", LogMsgType.Verbose);
                this.CurrentClient.Disconnect();
                return false;
            }


            var s = ExamSubmissionZippedStringList.
                Where(x => x.Details.StudentID
                           == details.StudentID).FirstOrDefault();
            if (s == null)
            {
                ExamSubmissionZippedStringList.Add(s = new ExamStatusUpdate(details));
            }
            s.UpdateSubmitInfo(anExamSubmission, $"[{DateTime.Now}]a copy of the exam sent to [IP:] {this.CurrentClient.RemoteEndPoint} [StudentName:] {details.StudentName}, [ID:] {details.StudentID}");


            try
            {
                submittedFiles.Add(details.StudentID, anExamSubmission);
                aLogger.LogMessage($"Exam Was Submitted By [StudentName:] {details.StudentName}, [ID:] {details.StudentID}", LogMsgType.Verbose);
            }
            catch (Exception ex)
            {
                aLogger.LogMessage($"STUDENT TRYING TO SUBMIT TWICE (EXAM DROPPED) [StudentName:] {details.StudentName}, [ID:] {details.StudentID}", LogMsgType.Error);
            }
            UpdateMethod(ExamSubmissionZippedStringList);
            return true;
        }

    }
}