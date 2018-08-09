using System;
using System.Collections.Generic;

namespace ForensicsCourseToolkit.Framework_Project.Security
{
    [Serializable]
    public class ExaminationFilterRule
    {
        public ExaminationFilterRule()
        {

        }
        public string StdID { get; set; }
        public string StdName { get; set; }


        public bool AllowSpecificIPs { get; set; }
        public List<string> AllowedIPs { get; set; } // includes parsing subnets 
        public string SharedKeyIS { get; set; }

        public ExaminationFilterRule(string stdID, string stdName, string sharedKeyIS, bool allowSpecificIPs, List<string> allowedIPs)
        {
            StdID = stdID;
            StdName = stdName;
            AllowSpecificIPs = allowSpecificIPs;
            AllowedIPs = allowedIPs;
            SharedKeyIS = sharedKeyIS;
        }

        public override string ToString()
        {
            string allowedIPs = "AllowedIPS=[";
            foreach (var ip in AllowedIPs)
            {
                allowedIPs += ip + ";";
            }
            allowedIPs += "]";

            return $"StdID=[{StdID}], StdName=[{StdName}],SharedKey=[{SharedKeyIS}], IP Filteration Allowed=[{AllowSpecificIPs.ToString()}], IPsList=[{allowedIPs}]";
        }
    }
}