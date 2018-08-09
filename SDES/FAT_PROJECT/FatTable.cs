using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ForensicsCourseToolkit.Common;
using ForensicsCourseToolkit.Common.Helpers;
using ForensicsCourseToolkit.Framework_Project;

namespace ForensicsCourseToolkit.FAT_PROJECT
{
    public class FatTable:IHaveStartAddress,IHaveCommonProps,IHaveExactSize, IHaveBootSectorParent
    {
      public  List<string> ParsedEntries=new List<string>(); 
        public FatTable(string fileName,BootSector parentBootSector, string description, int fatTableNumber)
        {
            Description = description;

            ParentBootSector = parentBootSector;
            Logger = ParentBootSector.Logger;
            StartAddress = ParentBootSector.GetFatTableStartByte(fatTableNumber);

            var aLogger = Logger;//to avoid var as ref
           RawValue= Common.Common.ReadBytesFromImageAsHex(fileName, StartAddress, ParentBootSector.FatSizeInBytes(), ref aLogger);
            Size = RawValue.Length/2;

            if (Size != GetExpectedSize())
            {
                var err =
                    $"in {MethodBase.GetCurrentMethod().Name}.. Actual size of read Fat[{Size}] != Expected size [{GetExpectedSize()}]... Operation terminated";
                Logger.LogMessage(err, LogMsgType.Fatal);
                throw new Exception(err);
            }

            if (parentBootSector.FatType == FatType.Fat12)
            {
                //I already have the value as Hex so read only 3 hex no need to treat it as bytes
                ParsedEntries= Conversion.Split(RawValue, 6).ToList();
            }
        }
        public int StartAddress { get; set; }
        public Logger Logger { get; set; }
        public string RawValue { get; set; }
        public int Size { get; }
        public string Description { get; set; }
        public int GetExpectedSize()
        {
            return ParentBootSector.FatSizeInBytes();
        }

        public BootSector ParentBootSector { get; set; }
    }
}
