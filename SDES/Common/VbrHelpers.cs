using System.Collections.Generic;
using System.Linq;
using ForensicsCourseToolkit.Common.Helpers;
using ForensicsCourseToolkit.Framework_Project;

namespace ForensicsCourseToolkit.Common
{
    public static class VbrHelpers
    {
        public static List<Vbr> GetVBRListFromMBR(Mbr anMbr,ref Logger aLogger)
        {
            var vbrRAWList = (from u in anMbr.Structure
                where u.Type == UnitType.Vbr
                select u).ToList();

            if (vbrRAWList.Count == 0)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return null;
            }

            var vbrsList = new List<Vbr>();
            foreach (var v in vbrRAWList)
            {
                //var aVbr = new Vbr(v.Value, $"VBR[{(v.Order - 1).ToString("X2")}]", ref aLogger);
                var aVbr = Common.GetUnit<Vbr>(v.Value, ref aLogger, -1, $"VBR[{(v.Order - 1).ToString("X2")}]", null);
                vbrsList.Add(aVbr);
            }

            return vbrsList;
        }
    }
}