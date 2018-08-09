using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForensicsCourseToolkit.Framework_Project.Quizez;

namespace ForensicsCourseToolkit.Framework_Project.Security
{
    [Serializable]
    public class ExaminationStudentsFilter
    {
        // SortedList<string, TrackingEntry> TrackingList; //key is stdID WE REMOVE THIS TO MAKE THE SERVER STATELESS
        SortedList<string, ExaminationFilterRule> Rules { get; set; } ////key is stdID
        FilterationSecurityLevel SecurityLevel { get; set; }


        string InstructorPassword { get; set; }
        string ExamKey { get; set; }
   
        public ExaminationStudentsFilter(FilterationSecurityLevel securityLevel, string examKey, string instPassword, SortedList<string, ExaminationFilterRule> rules = null)
        {
            SecurityLevel = securityLevel;
            ExamKey = examKey;
            InstructorPassword = instPassword;
            Rules = rules;
            
        }

        public FilterationResult IsValidRequest(RequiredDetails details, string srcIP)
        {

            if (SecurityLevel == FilterationSecurityLevel.Moderate)
            {
                return ModerateFilterationProcessRequest(details);
            }
            else if (SecurityLevel == FilterationSecurityLevel.High)
            {
                return HighFilterationProcessRequest(details, srcIP);
            }
            return  FilterationResult.DroppedUnknown; //Fail Safe
        }

        public FilterationResult IsValidSubmission(RequiredDetails details, string srcIP)
        {
            details.DecryptDetails(ExamKey);
           

            if (SecurityLevel == FilterationSecurityLevel.Moderate)
            {
                return ModerateFilterationProcessSubmit(details);
            }
            else if (SecurityLevel == FilterationSecurityLevel.High)
            {
                return HighFilterationProcessRequestSubmit(details, srcIP);
            }


            return FilterationResult.DroppedUnknown; //Fail Safe
        }


        private bool IsValidExamKey(RequiredDetails details)
        {
            return (details.ExamKey == ExamKey);
        }

        //private void AddEntryToTrackingList(RequiredDetailsForSendingExam details)
        //{
        //    try {

        //        var iV = new InstructorValidationData(details.StudentID, Guid.NewGuid(), DateTime.Now, int.Parse(details.SequenceNumber) + 1);
        //    TrackingEntry entry = new TrackingEntry(details.StudentID, details.SequenceNumber,iV);

        //    lock (TrackingList)
        //    {
        //        TrackingList.Add(details.StudentID, entry);
        //    }
        //    }
        //    catch(Exception ex)
        //    {
        //        aLogger.LogMessage(ex.Message + "[exception in AddEntryToTrackingList]", LogMsgType.Error);
        //        throw ex;
        //    }
        //}

        private InstructorValidationData GetIV(RequiredDetails details)
        {
            try
            {
                Random r = new Random();

                var iV = new InstructorValidationData(details.StudentID, 
                    DateTime.Now, int.Parse(details.SequenceNumber), int.Parse(details.SequenceNumber)+1);
            //    TrackingEntry entry = new TrackingEntry(details.StudentID, details.SequenceNumber, iV);
                return iV;

            }
            catch (Exception ex)
            {
              //  aLogger.LogMessage(ex.Message + "[exception in GetIV]", LogMsgType.Error);
                throw ex;
            }
        }
        #region MODERATE FILTERATION

        private FilterationResult ModerateFilterationProcessRequest(RequiredDetails details)
        {
            if (!IsValidExamKey(details))
            {

                return FilterationResult.InvalidSharedExamKey;
            }

            //AddEntryToTrackingList(details); // to be checked in submision phase, WE REMOVE THIS TO MAKE TEH SERVER STATELESS


            return FilterationResult.Accepted;
        }

        private FilterationResult ValidateIV(RequiredDetails details)
        {
            var ReceivedV = details.GetV(InstructorPassword);
            if (ReceivedV == null)
            {
                return FilterationResult.InvalidSubmissionInstructorValidation;
            }

            //if(ReceivedV.GetNonce ==  )//Nonce is not needed because now stateless

            if (ReceivedV.StdID != details.StudentID)
            {
                return FilterationResult.InvalidStdID_ImpersonationAttack;
            }

            if (int.Parse(details.SequenceNumber) != ReceivedV.GetIncrementedSN + 1)
            {
                return FilterationResult.InvalidSequenceNumber;
            }

            return FilterationResult.Accepted;
        }
        private FilterationResult ModerateFilterationProcessSubmit(RequiredDetails details)
        {

                var basicFilteration = ModerateFilterationProcessRequest(details);
                if (basicFilteration != FilterationResult.Accepted)
                {
                    return basicFilteration;
                }



                var ivFel = ValidateIV(details);
                if (ivFel != FilterationResult.Accepted)
                {

                    return ivFel;
                }



            return FilterationResult.Accepted;
        }

        #endregion MODERATE FILTERATION




        #region HIGH FILTERATION


        private bool IsValidSharedKeyIS(RequiredDetails details, ExaminationFilterRule rule)
        {

            details.DecryptSharedKey(rule.SharedKeyIS);
  
            return (details.SharedKeyIS == rule.SharedKeyIS);
        }
        /// <summary>
        /// this method protects against impersonation
        /// </summary>
        /// <param name="details"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        private bool IsValidStudentID(RequiredDetails details, ExaminationFilterRule rule)
        {
            return (details.StudentID == details.StudentID);
        }

        private bool IsValidSrcIP(RequiredDetails details, ExaminationFilterRule rule, string srcIP)
        {

            if (rule.AllowSpecificIPs == false) //no filteration required
            {
                return true;
            }

            foreach (var ipRule in rule.AllowedIPs)
            {
                if (srcIP == ipRule) // TODO:: implement subnets filteration
                {
                    return true;
                }
            }
            return false;
        }

        private void throwFirewallException(FilterationResult result,string extraMsg="")
        {

            if (result == FilterationResult.InvalidSharedExamKey)
            {
                throw new Exception($"Exception[{result}]: Ivalid Exam Key, Please check with your instructor for the correct exam key. [{extraMsg}]");
            }
            if (result == FilterationResult.StudentIsNotListedInFirewallRules)
            {
                throw new Exception($"Exception[{result}]: Student Not Listed in the Firewall Setting, Please check with your instructor to list you in the firewall settings.");
            }
            if (result == FilterationResult.InvalidSharedStudentKeyIS)
            {
                throw new Exception($"Exception[{result}]: Ivalid Shared Key (student password, unique for the student), Please check with your instructor for your password.  [{extraMsg}]");
            }
            if (result == FilterationResult.InvalidStdID_ImpersonationAttack)
            {
                throw new Exception($"Exception[{result}]: Invalid Student ID, are you trying impersonation attack?.  [{extraMsg}]");
            }
            if (result == FilterationResult.InvalidSrcIP)
            {
                throw new Exception($"Exception[{result}]: You IP address is not allowed for your student ID, check with the instructor to change firewall rule for your id.  [{extraMsg}]");
            }
            if (result == FilterationResult.InvalidSequenceNumber)
            {
                throw new Exception($"Exception[{result}]: Invalid sequence number, are you trying to forge a fake submission?.  [{extraMsg}]");
            }
            if (result == FilterationResult.InvalidSubmissionInstructorValidation)
            {
                throw new Exception($"Exception[{result}]: Submission Not Valid.  [{extraMsg}]");
            }
            if (result == FilterationResult.SubmissionTimeOutinInstructorV)
            {
                throw new Exception($"Exception[{result}]: You exceeded the time required for submission, or used an old exam copy.  [{extraMsg}]");
            }
            if (result == FilterationResult.DroppedUnknown)
            {
                throw new Exception($"Exception[{result}]: Dropped for unknown reason!.  [{extraMsg}]");
            }


        }
        private FilterationResult HighFilterationProcessRequest(RequiredDetails details, string srcIP)
        {


            // Valid Exam Key by decripting the request message details 
            if (!IsValidExamKey(details))
            {
                
                return FilterationResult.InvalidSharedExamKey;
            }

            //Check if the studnet is listed in the firewall list



            if (!Rules.ContainsKey(details.StudentID) ) //this means student is not listed, the fail safe drop it
            {
                
                return FilterationResult.StudentIsNotListedInFirewallRules;
            }

            //find the specific filteration rule for that student based on ID
            var specificRule = Rules[details.StudentID];

            //check if it is a valid KeyIS
            if (!IsValidSharedKeyIS(details, specificRule))
            {
               
                return FilterationResult.InvalidSharedStudentKeyIS;
            }


            if (!IsValidSrcIP(details, specificRule, srcIP))
            {
               
                return FilterationResult.InvalidSrcIP;
            }

            //AddEntryToTrackingList(details); // to be checked in submision phase


            return FilterationResult.Accepted;
        }


        private FilterationResult HighFilterationProcessRequestSubmit(RequiredDetails details, string srcIP)
        {
            var basicFilteration = HighFilterationProcessRequest(details, srcIP);
            if (basicFilteration != FilterationResult.Accepted)
            {
                return basicFilteration;
            }

            var ivFel = ValidateIV(details);
            if (ivFel != FilterationResult.Accepted)
            {
               
                return ivFel;
            }

            return FilterationResult.Accepted;
        }

        #endregion MODERATE FILTERATION



        #region EXAM Preparation

        public FilterationRequestResult GenerateExamCopyForSendingToStudent(Exam orgExamCopyEmpty, RequiredDetails details, string srcIP)
        {
            details.DecryptDetails(ExamKey);




            var filterResult = IsValidRequest(details, srcIP);

            if (filterResult != FilterationResult.Accepted)
            {
                throwFirewallException(filterResult,$"IP:{srcIP}");
                return new FilterationRequestResult(filterResult, null);
            }
            var v = GetIV(details);
            details.SequenceNumber = (long.Parse(details.SequenceNumber) + 1).ToString();
            details.VEncryptedWithKI = ExamHelper.GetVAsByteArray(v, InstructorPassword);
            
            var examInstance = orgExamCopyEmpty;
            examInstance.RequiredStudentDetails = details; //we received this from the student

    
           // examInstance.RequiredStudentDetails.SetV_CompressedEncryptedWithKI(v, InstructorPassword);

            //if(examInstance.RequiredStudentDetails.VEncryptedWithKI== null)
            //{
            //    MessageBox.Show("Set To Null");
            //}
            //else
            //{
            //    MessageBox.Show("examInstance.RequiredStudentDetails.VEncryptedWithKI");
            //}

            return new FilterationRequestResult(filterResult, ExamHelper.GetExamFileWithoutSave(examInstance, ExamKey,details.SharedKeyIS,SecurityLevel));

        }

        //public Exam GetExamCopyFromSubmission(byte[] submission)
        //{
        //    if (SecurityLevel == FilterationSecurityLevel.Moderate)
        //    {
        //        var exam = ExamHelper.GetExamFromByteArray(submission, ExamKey,"",FilterationSecurityLevel.Moderate);
        //        exam.RequiredStudentDetails.DecryptDetails(ExamKey);

        //    }
        //    else if (SecurityLevel == FilterationSecurityLevel.High)
        //    {
        //        //encrypt everything using K_IS, then concat StdID then encrypt Again with K_E
        //    }

        //    return null;
        //}

        #endregion


    }

}
