using System;

namespace ForensicsCourseToolkit.Framework_Project.Security
{
    [Serializable]
    public class TrackingEntry
    {
        public TrackingEntry()
        {

        }
        public string StdID { get; set; }
        public int SN { get; set; }
        public InstructorValidationData V { get; set; }
        public TrackingEntry(string stdID, string sn, InstructorValidationData v)
        {
            StdID = stdID;
            SN = int.Parse(sn);
            V = v;
        }
    }
}