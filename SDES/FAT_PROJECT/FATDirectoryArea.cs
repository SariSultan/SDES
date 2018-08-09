using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ForensicsCourseToolkit.Common;
using ForensicsCourseToolkit.Common.Helpers;
using ForensicsCourseToolkit.Framework_Project;

namespace ForensicsCourseToolkit.FAT_PROJECT
{

    public class FatDirectoryArea : IHaveStartAddress, IHaveStructure, IHaveExactSize,IHaveCommonProps
    {
        public List<FatDirectoryArea> ChildrenList=new List<FatDirectoryArea>();//this is the children of this directory area 
        public List<FatDirectoryArea> LongFileNames=new List<FatDirectoryArea>();//if any
          
        public bool GetAttributeStatus(StructureUnit aUnitWithAttributes, FileAttribute attribute)
        {
            byte val = Conversion.HexToByteArray(aUnitWithAttributes.Value)[0];
            var mask = ((byte)attribute & val);
            return (mask == (byte) attribute);
        }

        private StructureUnit GetStructureUnitThatHasAttributes()
        {
            return (from x in Structure where x.Type == UnitType.FatDirectoryEntryAttributes select x).First();
        }

        public bool IsThisEntryaDirectory ()
        {
            return GetAttributeStatus(GetStructureUnitThatHasAttributes(), FileAttribute.Directory);
        }
        public bool IsThisEntryanArchive()
        {
            return GetAttributeStatus(GetStructureUnitThatHasAttributes(), FileAttribute.Archive);
        }
        public bool IsThisEntryaLongFileName()
        {
            return GetAttributeStatus(GetStructureUnitThatHasAttributes(), FileAttribute.LongFileName);
        }

        public string GetEntryName()
        {
            string name = "";
            if (IsThisEntryaLongFileName())
            {
                foreach (var area in LongFileNames)
                {
                    name += Conversion.HexToAscii(Structure[1].Value) + Conversion.HexToAscii(Structure[5].Value) +
                            Conversion.HexToAscii(Structure[7].Value);
                }
            }
            else
            {
                name = Conversion.HexToAscii(Structure[0].Value) + Conversion.HexToAscii(Structure[1].Value);
            }
            return name;
        }
        public bool IsEmpty => Structure[0].Value=="00";

        public Logger Logger { get; set; }
        public string RawValue { get; set; }
        public int Size { get; } = Common.Common.FatDirectoryAreaSizeBytes;
        public string Description { get; set; }

        #region VARIABLES FOR CALCULATING DATA LOCATION

        public int RootDirectoryStartAddress;
        public int SectorsPerCluster;
        public int MaxNumofRootDirectories;
#endregion

        public List<List<StructureUnit>> Units=new List<List<StructureUnit>>(); //TODO:: do it

   
        public FatDirectoryArea()
        {
        }

       

        public int GetFirstClusterAddress()
        {
            return Conversion.HexLittleEndianToInt(Structure[11].Value);
        }

        public int GetDataLocation()
        {
            int rootDirectoryStartSector = (RootDirectoryStartAddress/Common.Common.BootSectorSizeBytes);
            int maxRootDirectoriesSectors = (MaxNumofRootDirectories*32/Common.Common.BlockSizeInBytes);
            int val= (rootDirectoryStartSector + maxRootDirectoriesSectors + SectorsPerCluster * (GetFirstClusterAddress() - 2)) * Common.Common.BlockSizeInBytes;
            
            Logger.LogMessage($"Find Date Equation(D)= ({rootDirectoryStartSector}+{maxRootDirectoriesSectors}+{SectorsPerCluster}*({GetFirstClusterAddress()}-2)) * blockSize = {val}",LogMsgType.Verbose);
            Logger.LogMessage($"Find Date Equation(HEX)= ({rootDirectoryStartSector.ToString("X4")}+{maxRootDirectoriesSectors.ToString("X4")}+{SectorsPerCluster.ToString("X4")}*({GetFirstClusterAddress().ToString("X4") }- 2)) * blockSize = {val.ToString("X4")}", LogMsgType.Verbose);

            return val;
        }

        public int StartAddress { get; set; }
        public List<StructureUnit> LongFileNameStructure { get; set; } = new List<StructureUnit>
        {
            new StructureUnit
            {
                Order = 1, //Sequence number of the LFN structures; Last entry is OR’edwith 0x40; Deleted is 0xe5
                UnitDescription = "Sequence number of the LFN structures; Last entry is OR’edwith 0x40; Deleted is 0xe5",
                FixedValue = false,
                UnitColor = Color.Aqua,
                Type = UnitType.Ascii,
                MicrosoftFiledCode = "",
                OffsetByte = 0,
                SizeBytes = 1,
            },
            new StructureUnit
            {
                Order = 2,
                UnitDescription = "First 5 (Unicode) file name characters",
                FixedValue = false,
                UnitColor = Color.IndianRed,
                Type = UnitType.Ascii,
                OffsetByte = 1,
                SizeBytes=10,
            },
            new StructureUnit
            {
                Order = 3,
                UnitDescription = "File attributes",
                FixedValue = false,
                UnitColor = Color.Goldenrod,
                Type = UnitType.FatDirectoryEntryAttributes,
                MicrosoftFiledCode = "DIR_Attr",
                OffsetByte = 11,
                SizeBytes=1,
            },
            new StructureUnit
            {
                Order = 4,
                UnitDescription = "Reserved",
                FixedValue = false,
                UnitColor = Color.DodgerBlue,
                OffsetByte = 12,
                SizeBytes=1,
            },
            new StructureUnit
            {
                Order =5,
                UnitDescription = "Checksum",
                FixedValue = false,
                UnitColor = Color.DarkViolet,
                OffsetByte = 13,
                SizeBytes=1,
            },
            new StructureUnit
            {
                Order = 6,
                UnitDescription = "Characters 6 –11 (Unicode)",
                FixedValue = false,
                UnitColor = Color.DarkSlateGray,
                Type = UnitType.Ascii,
                OffsetByte = 14,
                SizeBytes=12,
            },
            new StructureUnit
            {
                Order = 7,
                UnitDescription = "Reserved",
                FixedValue = false,
                UnitColor = Color.DarkRed,
                OffsetByte = 26,
                SizeBytes=2,
            },
            new StructureUnit
            {
                Order =8,
                UnitDescription = "Characters 12 –13 (Unicode)",
                //UnitStartLocationHex = "0012", //18
                //UnitEndLocationHex = "0013", //19
                FixedValue = false,
                UnitColor = Color.DarkGoldenrod,
                Type = UnitType.Ascii,
                OffsetByte = 28,
                SizeBytes=4,
            },
        };
        public List<StructureUnit> Structure { get; set; }= new List<StructureUnit>
        {
            new StructureUnit
            {
                Order = 1, //THIS IS REDUNDANT FIELD TO MATCH COURSE SLIDES and show the first char by itself
                UnitDescription = "First Character of file nmae in ASCII 0x5E or 0x00 empty, 0x2E subdirectory",
                //UnitStartLocationHex = "0000",
                //UnitEndLocationHex = "0000",
                FixedValue = false,
                UnitColor = Color.Aqua,
                Type = UnitType.Ascii,
                MicrosoftFiledCode = "",
                OffsetByte = 0,
                SizeBytes = 1,
            },
            new StructureUnit
            {
                Order = 2,
                UnitDescription = "Characters 2 –11 of file SHORT name in ASCII.",
                //UnitStartLocationHex = "0001",
                //UnitEndLocationHex = "000A",
                FixedValue = false,
                UnitColor = Color.IndianRed,
                Type = UnitType.Ascii,
                MicrosoftFiledCode = "DIR_Name",
                OffsetByte = 1,
                SizeBytes=10,

            },
            new StructureUnit
            {
                Order = 3,
                UnitDescription = "File attributes",
                //UnitStartLocationHex = "000B",
                //UnitEndLocationHex = "000B",
                FixedValue = false,
                UnitColor = Color.Goldenrod,
                Type = UnitType.FatDirectoryEntryAttributes,
                MicrosoftFiledCode = "DIR_Attr",
                OffsetByte = 11,
                SizeBytes=1,
            },
            new StructureUnit
            {
                Order = 4,
                UnitDescription = "Reserved",
                //UnitStartLocationHex = "000C",
                //UnitEndLocationHex = "000C",
                FixedValue = false,
                UnitColor = Color.DodgerBlue,
                MicrosoftFiledCode = "DIR_NTRes",
                OffsetByte = 12,
                SizeBytes=1,
            },
            new StructureUnit
            {
                Order =5,
                UnitDescription = "Create time (tenths of second)",
                //UnitStartLocationHex = "000D",
                //UnitEndLocationHex = "000D",
                FixedValue = false,
                UnitColor = Color.DarkViolet,
                Type = UnitType.TimeTenthofSeconds,
                MicrosoftFiledCode = "DIR_CrtTimeTenth",
                OffsetByte = 13,
                SizeBytes=1,
            },
            new StructureUnit
            {
                Order = 6,
                UnitDescription = "Create time ( hours, minutes, seconds)",
                //UnitStartLocationHex = "000E",
                //UnitEndLocationHex = "000F",
                FixedValue = false,
                UnitColor = Color.DarkSlateGray,
                Type = UnitType.TimeHms,
                MicrosoftFiledCode = "DIR_CrtTime",
                OffsetByte = 14,
                SizeBytes=2,
            },
            new StructureUnit
            {
                Order = 7,
                UnitDescription = "Create day",
                //UnitStartLocationHex = "0010",
                //UnitEndLocationHex = "0011",
                FixedValue = false,
                UnitColor = Color.DarkRed,
                Type = UnitType.Day,
                 MicrosoftFiledCode = "DIR_CrtDate",
                OffsetByte = 16,
                SizeBytes=2,
            },
            new StructureUnit
            {
                Order =8,
                UnitDescription = "Access day",
                //UnitStartLocationHex = "0012", //18
                //UnitEndLocationHex = "0013", //19
                FixedValue = false,
                UnitColor = Color.DarkGoldenrod,
                Type = UnitType.Day,
                 MicrosoftFiledCode = "DIR_LstAccDate",
                OffsetByte = 18,
                SizeBytes=2,
            },
            new StructureUnit
            { //always zero for FAT12,16
                Order = 9,
                UnitDescription = "High 2 bytes of first cluster address (0 for FAT12/16)",
                //UnitStartLocationHex = "0014", //20
                //UnitEndLocationHex = "0015", //21
                FixedValue = false,
                UnitColor = Color.Cornsilk,
                MicrosoftFiledCode = "DIR_FstClusHI",
                OffsetByte = 20,
                SizeBytes=2,
            },
            new StructureUnit
            {
                Order = 10,
                UnitDescription = "Write time (( hours, minutes, seconds)",
                //UnitStartLocationHex = "0016", //22
                //UnitEndLocationHex = "0017", //23
                FixedValue = false,
                UnitColor = Color.Coral,
                Type = UnitType.TimeHms,
                MicrosoftFiledCode = "DIR_WrtTime",
                OffsetByte = 22,
                SizeBytes=2,
            },
            new StructureUnit
            {
                Order = 11,
                UnitDescription = "Write day",
                //UnitStartLocationHex = "0018", //24
                //UnitEndLocationHex = "0019", //25
                FixedValue = false,
                UnitColor = Color.CadetBlue,
                Type = UnitType.Day,
                MicrosoftFiledCode = "DIR_WrtDate",
                OffsetByte = 24,
                SizeBytes=2,
            },
            new StructureUnit
            {
                Order = 12, //COUPLED
                UnitDescription = "Low 2 bytes of first cluster address from start of data area",
                //UnitStartLocationHex = "001A", //26
                //UnitEndLocationHex = "001B", //27
                FixedValue = false,
                UnitColor = Color.Brown,
                MicrosoftFiledCode = "DIR_FstClusLO",
                OffsetByte = 26,
                SizeBytes=2,
            },
            new StructureUnit
            {
                Order = 13,
                UnitDescription = "Size of file (0 for directories) in bytes",
                //UnitStartLocationHex = "001C", //28
                //UnitEndLocationHex = "001F", //31
                FixedValue = false,
                UnitColor = Color.BlueViolet,
                Type = UnitType.SizeInBytes,
                MicrosoftFiledCode = "DIR_FileSize",
                OffsetByte = 28,
                SizeBytes=4,
            },
        };

        public int GetExpectedSize()
        {
            return Common.Common.FatDirectoryAreaSizeBytes;
        }
    }
}
