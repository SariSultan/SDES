using System;
using System.Globalization;

namespace ForensicsCourseToolkit.Framework_Project.Security
{
    [Serializable]
    public class InstructorValidationData
    {
        public InstructorValidationData()
        {

        }
        public string StdID { get; set; }
        // private string Nonce { get; set; }
        public string TimeStamp { get; set; }


        public string OriginalSN { get; set; }
        public string IncrementedSN { get; set; }

        public InstructorValidationData(string stdID,  DateTime timeStamp, int orgSN, int SNIncremented)
        {
            StdID = stdID;
            // Nonce = nonce.ToString();
            TimeStamp = timeStamp.ToString("yyyyMMdd-HHMMss");
            IncrementedSN = SNIncremented.ToString();
            OriginalSN = orgSN.ToString();
            //EncryptDetails(instructorPassword); should be handled at upper level before sending encrypt or serialize it all
        }

        //private void EncryptDetails(string instructorPassword)
        //{
        //    StdID = Crypto.AESGCM.SimpleEncryptWithPassword(StdID, instructorPassword);
        //    Nonce = Crypto.AESGCM.SimpleEncryptWithPassword(Nonce.ToString(), instructorPassword);
        //    TimeStamp = Crypto.AESGCM.SimpleEncryptWithPassword(TimeStamp, instructorPassword);
        //    IncrementedSN = Crypto.AESGCM.SimpleEncryptWithPassword(IncrementedSN, instructorPassword);
        //}

        //public void DecryptDetails(string instructorPassword)
        //{
        //    return;
        //    //StdID = Crypto.AESGCM.SimpleDecryptWithPassword(StdID, instructorPassword);
        //    //Nonce = Crypto.AESGCM.SimpleDecryptWithPassword(Nonce.ToString(), instructorPassword);
        //    //TimeStamp = Crypto.AESGCM.SimpleDecryptWithPassword(TimeStamp, instructorPassword);
        //    //IncrementedSN = Crypto.AESGCM.SimpleDecryptWithPassword(IncrementedSN, instructorPassword);
        //}
        public DateTime GetTimeStamp()
        {
            string format = "yyyyMMdd-HHMMss";
            DateTime dateTime;
            if (DateTime.TryParseExact(TimeStamp, format, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out dateTime))
            {
                return dateTime;
            }
            else
                throw new Exception("Cannot convert time stamp");
        }

        //   public Guid GetNonce { get { return Guid.Parse(Nonce); } }

        public int GetIncrementedSN { get { return int.Parse(IncrementedSN); } }

        public int GetOriginalSN { get { return int.Parse(OriginalSN); } }
    }
}