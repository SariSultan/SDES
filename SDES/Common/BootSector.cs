using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using ForensicsCourseToolkit.Common.Helpers;
using ForensicsCourseToolkit.FAT_PROJECT;
using ForensicsCourseToolkit.Framework_Project;

namespace ForensicsCourseToolkit.Common
{
    public class BootSector : IHaveStructure, IHaveStartAddress, IHaveExactSize, IHaveCommonProps
    {
        public List<StructureUnit> Structure { get; set; } = new List<StructureUnit>
        {
            new StructureUnit
            {
                Order = 1,
                UnitDescription = "Jump Boot Code",
                //UnitStartLocationHex = "0000",
                //UnitEndLocationHex = "0002",
                FixedValue = false,
                UnitColor = Color.Aqua,
                MicrosoftFiledCode = "BS_jmpBoot",
                OffsetByte = 0,
                SizeBytes = 3,
            },
            new StructureUnit
            {
                Order = 2,
                UnitDescription = "Name in ASCII",
                //UnitStartLocationHex = "0003",
                //UnitEndLocationHex = "000A",
                FixedValue = false,
                UnitColor = Color.Beige,
                Type = UnitType.Ascii,
                MicrosoftFiledCode = "BS_OEMName",
                OffsetByte = 3,
                SizeBytes = 8,
            },
            new StructureUnit
            {
                Order = 3,
                UnitDescription = "Bytes per Sector",
                //UnitStartLocationHex = "000B",
                //UnitEndLocationHex = "000C",
                FixedValue = false,
                UnitColor = Color.Blue,
                Type = UnitType.LittleEndianHex,
                MicrosoftFiledCode = "BPB_BytsPerSec",
                OffsetByte = 0x0B, //11
                SizeBytes = 2,
            },
            new StructureUnit
            {
                Order = 4,
                UnitDescription = "Sectors per Cluster",
                //UnitStartLocationHex = "000D",
                //UnitEndLocationHex = "000D",
                FixedValue = false,
                UnitColor = Color.BlueViolet,
                MicrosoftFiledCode = "BPB_SecPerClus",
                OffsetByte = 0x0D, // 13
                SizeBytes = 1,
            },
            new StructureUnit
            {
                Order = 5,
                UnitDescription = "Size of reserved area (in sectors)", //COUPLED DO NOT CHANGE ORDER
                //UnitStartLocationHex = "000E",
                //UnitEndLocationHex = "000F",
                FixedValue = false,
                UnitColor = Color.BurlyWood,
                Type = UnitType.SizeInSectorsLittleEndian,
                MicrosoftFiledCode = "BPB_RsvdSecCnt",
                OffsetByte = 0x0E, //14
                SizeBytes = 2,
            },
            new StructureUnit
            {
                Order = 6,
                UnitDescription = "Number of FATs",
                //UnitStartLocationHex = "0010",
                //UnitEndLocationHex = "0010",
                FixedValue = false,
                UnitColor = Color.Chartreuse,
                MicrosoftFiledCode = "BPB_NumFATs",
                OffsetByte = 0x10, // 16
                SizeBytes = 1,

            },
            new StructureUnit
            {
                Order = 7,
                UnitDescription = "Max # of root directory entries",
                //UnitStartLocationHex = "0011",
                //UnitEndLocationHex = "0012",
                FixedValue = false,
                UnitColor = Color.Coral,
                MicrosoftFiledCode = "BPB_RootEntCnt",
                OffsetByte = 0x11, //17
                SizeBytes = 2,

            },
            new StructureUnit
            {
                Order = 8,
                UnitDescription = "16 bit value of number of sectors in file system",
                //UnitStartLocationHex = "0013",
                //UnitEndLocationHex = "0014",
                FixedValue = false,
                UnitColor = Color.Crimson
                ,
                MicrosoftFiledCode = "BPB_TotSec16",
                OffsetByte = 0x13 ,// 19
                SizeBytes = 2
            },
            new StructureUnit
            {
                Order = 9,
                UnitDescription = "Media type 0xf8 fixed, 0xf0 removable",
                //UnitStartLocationHex = "0015",
                //UnitEndLocationHex = "0015",
                FixedValue = false,
                UnitColor = Color.DarkCyan
                ,
                MicrosoftFiledCode = "BPB_Media",
                OffsetByte = 0x15, // 21
                SizeBytes = 1,
            },
            new StructureUnit
            {
                Order = 10,
                UnitDescription = "16-bit size in sectors of each FAT",
                //UnitStartLocationHex = "0016",
                //UnitEndLocationHex = "0017",
                FixedValue = false,
                UnitColor = Color.DarkGray,
                MicrosoftFiledCode = "BPB_FATSz16",
                OffsetByte = 0x16, // 22 
                SizeBytes = 2

            },
            new StructureUnit
            {
                Order = 11,
                UnitDescription = "Sectors per track",
                //UnitStartLocationHex = "0018",
                //UnitEndLocationHex = "0019",
                FixedValue = false,
                UnitColor = Color.DarkKhaki,
                MicrosoftFiledCode = "BPB_SecPerTrk",
                OffsetByte = 0x18, //24
                SizeBytes = 2
            },
            new StructureUnit
            {
                Order = 12,
                UnitDescription = "Number of Heads",
                //UnitStartLocationHex = "001A",
                //UnitEndLocationHex = "001B",
                FixedValue = false,
                UnitColor = Color.Yellow,
                MicrosoftFiledCode = "BPB_NumHeads",
                OffsetByte = 0x1A, //26
                SizeBytes = 2,
            },
            new StructureUnit
            {
                Order = 13,
                UnitDescription = "Number of hidden sectors (0)",
                //UnitStartLocationHex = "001C", //28
                //UnitEndLocationHex = "001F", //31
                FixedValue = false,
                UnitColor = Color.DarkRed,
                MicrosoftFiledCode = "BPB_HiddSec",
                OffsetByte = 0x1C,//28
                SizeBytes = 4
            },
            new StructureUnit
            {
                Order = 14,
                UnitDescription = "Total number of sectors in the filesystem",
                //UnitStartLocationHex = "0020", //32
                //UnitEndLocationHex = "0023", //35
                FixedValue = false,
                UnitColor = Color.DarkSeaGreen,
                MicrosoftFiledCode = "BPB_TotSec32 ",
                OffsetByte = 0x20, //32
                SizeBytes = 4
            },
            //TODO:: Here is the problem starts
            // because FAT12,FAT16 table is different than FAT32 table
           
        };
        public int StartAddress { get; set; }
        public int GetExpectedSize()
        {
            return Common.BootSectorSizeBytes;
        }

        public Logger Logger { get; set; }
        public string RawValue { get; set; }
        public int Size => Common.BootSectorSizeBytes;
        public string Description { get; set; }

        #region STRUCTURE EXTENSION
        public List<StructureUnit> Fat12And16ExtensionList = new List<StructureUnit>()
        {
            new StructureUnit
            {
                Order = 15,
                UnitDescription = "Drive Number",
                FixedValue = false,
                UnitColor = Color.LightSalmon,
                MicrosoftFiledCode = "BS_DrvNum",
                OffsetByte = 36,
                SizeBytes = 1,
            },
             new StructureUnit
            {
                Order = 16,
                UnitDescription = "Reserved by WinNT",
                FixedValue = false,
                UnitColor = Color.Purple,
                MicrosoftFiledCode = "BS_Reserved1",
                OffsetByte = 37,
                SizeBytes = 1
            },
            new StructureUnit
            {
                Order = 17,
                UnitDescription = "Boot Signature",
                FixedValue = false,
                UnitColor = Color.SandyBrown,
                MicrosoftFiledCode = "BS_BootSig",
                OffsetByte = 38,
                SizeBytes = 1
            },
            new StructureUnit
            {
                Order = 18,
                UnitDescription = "Volume Serial Number",
                FixedValue = false,
                UnitColor = Color.Sienna,
                MicrosoftFiledCode = "BS_VolID",
                OffsetByte = 39,
                SizeBytes = 4
            },
            new StructureUnit
            {
                Order = 19,
                UnitDescription = "Volume label",
                FixedValue = false,
                UnitColor = Color.SteelBlue,
                MicrosoftFiledCode = "BS_VolLab",
                OffsetByte = 43,
                SizeBytes = 11,
            },
            new StructureUnit
            { //microsoft document says this does not necessarily mean it is correct, so if it says FAT16 here it migh not be correct and should be recalculated
                Order = 20,
                UnitDescription = "FileSystem type",
                FixedValue = false,
                UnitColor = Color.Thistle,
                OffsetByte = 54,
                SizeBytes = 8
            },
                        new StructureUnit
            { 
                Order = 21,
                UnitDescription = "RESERVED",
                FixedValue = false,
                UnitColor = Color.Green,
                OffsetByte = 54+8,
                SizeBytes = Common.BootSectorSizeBytes-54-8-2
            },
                         new StructureUnit
            {
                Order = 22,
                UnitDescription = "Signature",
                //UnitStartLocationHex = "01FE",
                //UnitEndLocationHex = "01FF",
                FixedValue = true,
                Value = "55AA",
                UnitColor = Color.DarkTurquoise,
                MicrosoftFiledCode = "",
                OffsetByte = 0x1FE,
                SizeBytes = 2
            }
        };

        /// <summary>
        /// this list will be merged dynamically based on the FAT type 
        /// because there is a difference based on MS documentation
        /// the first unit should start at loc=36(d) offset
        /// </summary>
        public List<StructureUnit> Fat32ExtensionList = new List<StructureUnit>()
        {
            new StructureUnit
            {
                Order = 15,
                UnitDescription = "Sectors per FAT",
                //UnitStartLocationHex = "0024", //36
                //UnitEndLocationHex = "0027", //39
                FixedValue = false,
                UnitColor = Color.LightSalmon,
                MicrosoftFiledCode = "BPB_FATSz32",
                OffsetByte = 36,
                SizeBytes = 4
            },
            new StructureUnit
            {
                Order = 16,
                UnitDescription = "Mirror flags", //TODO
                //bits 0-3 number of active FAT (if bit 7 is 1)
                // bits 4-6: reserved
                //bit 7 one: single active fat, zero all FATs are updated at runtime
                //bits 8-15:reserved
                //UnitStartLocationHex = "0028", //40
                //UnitEndLocationHex = "0029", //41
                FixedValue = false,
                UnitColor = Color.Purple,
                MicrosoftFiledCode = "BPB_ExtFlags",
                OffsetByte = 40,
                SizeBytes = 2
            },
            new StructureUnit
            {
                Order = 17,
                UnitDescription = "Filesystem version",
                //UnitStartLocationHex = "002A", //42
                //UnitEndLocationHex = "002B", //43
                FixedValue = false,
                UnitColor = Color.SandyBrown,
                MicrosoftFiledCode = "BPB_FSVer",
                OffsetByte = 42,
                SizeBytes = 2

            },
            new StructureUnit
            {
                Order = 18,
                UnitDescription = "First cluster of root directory (usually 2)",
                //UnitStartLocationHex = "002C", //44
                //UnitEndLocationHex = "002F", //47
                FixedValue = false,
                UnitColor = Color.Sienna,
                MicrosoftFiledCode = "BPB_RootClus",
                OffsetByte = 44,
                SizeBytes = 4
            },
            new StructureUnit
            {
                Order = 19,
                UnitDescription = "sector number in FAT32 reserved area (usually 1)",
                //UnitStartLocationHex = "0030", //48
                //UnitEndLocationHex = "0031", //49
                FixedValue = false,
                UnitColor = Color.SteelBlue,
                MicrosoftFiledCode = "BPB_FSInfo",
                OffsetByte = 48,
                SizeBytes = 2
            },
            new StructureUnit
            {
                Order = 20,
                UnitDescription = "Backup boot sector location or 0 or 0xffff if none (usually 6)",
                //UnitStartLocationHex = "0032", //50
                //UnitEndLocationHex = "0033", //51
                FixedValue = false,
                UnitColor = Color.Thistle,
                MicrosoftFiledCode = "BPB_BkBootSec",
                OffsetByte = 50,
                SizeBytes = 2
            },
            new StructureUnit
            {
                Order = 20,
                UnitDescription = "Reserved",
                //UnitStartLocationHex = "0034", //52
                //UnitEndLocationHex = "003F", //63
                FixedValue = false,
                UnitColor = Color.YellowGreen,
                MicrosoftFiledCode = "BPB_Reserved",
                OffsetByte = 52,
                SizeBytes = 12
            },
            new StructureUnit
            {
                Order = 20,
                UnitDescription = "Logical Drive Number (e.g. 0 or 0x80)",
                //UnitStartLocationHex = "0040", //64
                //UnitEndLocationHex = "0040", //64
                FixedValue = false,
                UnitColor = Color.LightCyan,
                MicrosoftFiledCode = "BS_DrvNum",
                OffsetByte = 64,
                SizeBytes = 1

            },
            new StructureUnit
            {
                Order = 21,
                UnitDescription = "Reserved -used to be Current Head (used by Windows NT)",
                //UnitStartLocationHex = "0041", //65
                //UnitEndLocationHex = "0041", //65
                FixedValue = false,
                UnitColor = Color.Indigo,
                MicrosoftFiledCode = "BS_Reserved1",
                OffsetByte = 65,
                SizeBytes = 1
            },
            new StructureUnit
            {
                Order = 22,
                UnitDescription = "Extended signature (0x29)",
                //UnitStartLocationHex = "0042", //66
                //UnitEndLocationHex = "0042", //66
                FixedValue = false,
                UnitColor = Color.IndianRed,
                MicrosoftFiledCode = "BS_BootSig",
                OffsetByte = 66,
                SizeBytes = 1
            },
            new StructureUnit
            {
                Order = 23,
                UnitDescription = "Serial number of partition",
                //UnitStartLocationHex = "0043", //66
                //UnitEndLocationHex = "0046", //70
                FixedValue = false,
                UnitColor = Color.Goldenrod,
                MicrosoftFiledCode = "BS_VolID",
                OffsetByte = 67,
                SizeBytes = 1
            },
            new StructureUnit
            {
                Order = 24,
                UnitDescription = "Volume label",
                //UnitStartLocationHex = "0047", //71
                //UnitEndLocationHex = "0051", //81
                FixedValue = false,
                UnitColor = Color.ForestGreen,
                MicrosoftFiledCode = "BS_VolLab",
                OffsetByte = 71,
                SizeBytes = 11
            },
            new StructureUnit
            {
                //this has nothing to do with file type determination
                Order = 25,
                UnitDescription = "Filesystem type (e.g., FAT, FAT32)",
                //UnitStartLocationHex = "0052", //82
                //UnitEndLocationHex = "0059", //89
                FixedValue = false,
                UnitColor = Color.Firebrick,
                MicrosoftFiledCode = "BS_FilSysType",
                OffsetByte = 82,
                SizeBytes = 8
            },
            new StructureUnit
            {
                Order = 26,
                UnitDescription = "Not used",
                //UnitStartLocationHex = "005A", //90
                //UnitEndLocationHex = "01FD", //509
                FixedValue = false,
                UnitColor = Color.DarkViolet,
                MicrosoftFiledCode = "",
                OffsetByte = 90,
                SizeBytes = 420
            },
            new StructureUnit
            {
                Order = 27,
                UnitDescription = "Signature",
                //UnitStartLocationHex = "01FE",
                //UnitEndLocationHex = "01FF",
                FixedValue = true,
                Value = "55AA",
                UnitColor = Color.DarkTurquoise,
                MicrosoftFiledCode = "",
                OffsetByte = 0x1FE,
                SizeBytes = 2
            }
        };
        #endregion STRUCTURE

        public BootSector()
        {
        }


        public int GetMaxNumberOfRootDirectories()
        {
            return Conversion.HexLittleEndianToInt(Structure[6].Value);
        }

        public int GetNumberOfSectorsPerCluser()
        {
            return Conversion.HexLittleEndianToInt(Structure[3].Value);
        }

        private int _fatSize = 0;
        public int GetNumberOfSectorsPerFat()
        {
            return _fatSize;
        }

        public int FatSizeInBytes()
        {
            return GetNumberOfSectorsPerFat()*BytesPerSector();
        }

        public int GetNumberOfFats()
        {
            return Conversion.HexLittleEndianToInt(Structure[5].Value);
        }

        private int GetReservedAreaSizeByte()
        {
            if (Structure == null)
            {
                throw new Exception("Cannot find boot sector start location before loading the structure");
            }
            return Conversion.HexLittleEndianToInt(Structure[4].Value) * Common.BlockSizeInBytes;
        }

        public int GetRootDirectoryStartByte()
        {
            return GetRootDirectoryStartSector() * Common.BlockSizeInBytes;
        }

        public int GetRootDirectoryStartSector()
        {
            int numberOfFats = GetNumberOfFats();
            int numberOfSectorsPerFat = GetNumberOfSectorsPerFat();

            var val = StartAddress/BytesPerSector() + GetReservedAreaSizeByte()/ BytesPerSector() + (numberOfFats*numberOfSectorsPerFat);
            return val;
        }

        public int GetFatTableStartByte(int fatNumberZeroIndexed)
        {
            if (fatNumberZeroIndexed > GetNumberOfFats()-1)//because zero indexed
            {
                Logger.LogMessage($"in {MethodBase.GetCurrentMethod().Name}.. Number of fats {GetNumberOfFats()}, but you try to access fat number {fatNumberZeroIndexed}, Operation Terminated",LogMsgType.Fatal);
            }
            int numOfSectorsperFat = GetNumberOfSectorsPerFat();
            return (GetFatTableStartSector() + (fatNumberZeroIndexed * numOfSectorsperFat)) * BytesPerSector();
        }

        public int GetFatTableStartSector()
        {
            return StartAddress/ BytesPerSector() + GetReservedAreaSizeByte()/ BytesPerSector();
        }

        public int BytesPerSector()
        {
            return GetFieldValueasIntbyMicrosoftCode("BPB_BytsPerSec", Structure);
        }
        public int RootDirSectors()
        {
            int bytesPerSecotr = BytesPerSector();
            return (((GetFieldValueasIntbyMicrosoftCode("BPB_RootEntCnt", Structure)*32) + (bytesPerSecotr - 1))/
                    bytesPerSecotr);
        }

        public int FirstDataSectorByte()
        {
            return FirstDataSector()*BytesPerSector();
        }
        public int FirstDataSector()
        {
            return (StartAddress/BytesPerSector()+GetFieldValueasIntbyMicrosoftCode("BPB_RsvdSecCnt", Structure) +
                   (GetFieldValueasIntbyMicrosoftCode("BPB_NumFATs", Structure)* GetNumberOfSectorsPerFat() ) + RootDirSectors());
        }

        public StructureUnit GetFieldByMicrosoftCode(string microsoftCode,  List<StructureUnit> structure )
        {
          return  (from x in Structure where x.MicrosoftFiledCode.Trim().ToLower() == microsoftCode.Trim().ToLower() select x).First();
        }

        public int GetFieldValueasIntbyMicrosoftCode(string microsoftCode, List<StructureUnit> structure)
        {
            return Helpers.Conversion.HexLittleEndianToInt(GetFieldByMicrosoftCode(microsoftCode, structure).Value);
        }


        private int _totalSectors = 0;
        public void DetermineFatType()
        {
            var intVal = GetFieldValueasIntbyMicrosoftCode("BPB_FATSz16", Structure);
            if (intVal != 0) //this means that the system is FAT12 or FAT16
            {
                Logger.LogMessage($"in {MethodBase.GetCurrentMethod().Name}.. BPB_FATSz16=[{intVal.ToString("X4")}], It is FAT12 or FAT16", LogMsgType.Debug);
                

                Logger.LogMessage($"in {MethodBase.GetCurrentMethod().Name}.. MERGING FAT12,16 EXTENSION LIST <START>", LogMsgType.Debug);
                Common.ParseStructureUnits(Fat12And16ExtensionList,RawValue, Logger);
                Logger.LogMessage($"in {MethodBase.GetCurrentMethod().Name}.. MERGING FAT12,16 EXTENSION LIST <Done Successfully>", LogMsgType.Debug);
                Structure.AddRange(Fat12And16ExtensionList);

                _fatSize = intVal;
            }
            else // this means that the file system is FAT32
            {
                Logger.LogMessage($"in {MethodBase.GetCurrentMethod().Name}.. MERGING FAT32 EXTENSION LIST <START>", LogMsgType.Debug);
                Common.ParseStructureUnits(Fat32ExtensionList, RawValue, Logger);
                Structure.AddRange(Fat32ExtensionList);
                Logger.LogMessage($"in {MethodBase.GetCurrentMethod().Name}.. MERGING FAT32 EXTENSION LIST <Done Successfully>", LogMsgType.Debug);

                int actualSize= GetFieldValueasIntbyMicrosoftCode("BPB_FATSz32", Structure);
                Logger.LogMessage($"in {MethodBase.GetCurrentMethod().Name}.. BPB_FATSz16=[{intVal.ToString("X4")}], It is FAT12 or FAT16\n Actual size BPB_FATSz32[{actualSize.ToString("X4")}]", LogMsgType.Debug);

                _fatSize = actualSize;
            }

            
            var rtDirSectors = RootDirSectors();
            Logger.LogMessage($"in {MethodBase.GetCurrentMethod().Name}.. Secotrs occupied by root dir = {rtDirSectors} sectors, (always zero for FAT32)", LogMsgType.Debug);

            Logger.LogMessage($"in {MethodBase.GetCurrentMethod().Name}.. Start of Root Dir= {GetRootDirectoryStartByte().ToString("X8")} (d), (always zero for FAT32)", LogMsgType.Debug);

            var frstDataSector = FirstDataSector();
            Logger.LogMessage($"in {MethodBase.GetCurrentMethod().Name}.. First Data Sector = {frstDataSector.ToString("X8")} (d), (absolute not relative)", LogMsgType.Debug);



            var totSecotrs = GetFieldValueasIntbyMicrosoftCode("BPB_TotSec16", Structure);
            if (totSecotrs != 0)
            {
                _totalSectors = totSecotrs;
                Logger.LogMessage($"in {MethodBase.GetCurrentMethod().Name}..Total Sectors:: BPB_TotSec16=[{totSecotrs.ToString("X4")}], setted as FAT12,16 because val is not zero", LogMsgType.Debug);
            }
            else
            {
                _totalSectors= GetFieldValueasIntbyMicrosoftCode("BPB_TotSec32", Structure);
                Logger.LogMessage($"in {MethodBase.GetCurrentMethod().Name}..Total Sectors:: BPB_TotSec16=[{totSecotrs.ToString("X4")}], setted as 32==>[{_totalSectors.ToString("X8")} because val is not zero", LogMsgType.Debug);
            }

            var DataSec = _totalSectors - (GetFieldValueasIntbyMicrosoftCode("BPB_RsvdSecCnt", Structure) + (GetNumberOfFats() * GetNumberOfSectorsPerFat()) + RootDirSectors());

            Logger.LogMessage($"in {MethodBase.GetCurrentMethod().Name}.. Data Sectors = {DataSec.ToString("X8")} (d), ", LogMsgType.Debug);
            var countOfClusters = DataSec/GetNumberOfSectorsPerCluser();
            Logger.LogMessage($"in {MethodBase.GetCurrentMethod().Name}.. Count of Clusters = {countOfClusters.ToString("X8") }== {countOfClusters} (d), ", LogMsgType.Debug);

            if (countOfClusters < 4085)
            {
                Logger.LogMessage($"in {MethodBase.GetCurrentMethod().Name}.. FAT TYPE IS FAT12 Based on counter of clusters {countOfClusters} (d)< 4085, ", LogMsgType.Debug);
                FatType=FatType.Fat12;
                
            }
            else if (countOfClusters < 65525)
            {
                Logger.LogMessage($"in {MethodBase.GetCurrentMethod().Name}.. FAT TYPE IS FAT16 Based on counter of clusters {countOfClusters} (d)< 65525, ", LogMsgType.Debug);
                FatType=FatType.Fat16;
            }
            else
            {
                Logger.LogMessage($"in {MethodBase.GetCurrentMethod().Name}.. FAT TYPE IS FAT32 Based on counter of clusters {countOfClusters} (d)> 65525, ", LogMsgType.Debug);
                FatType = FatType.Fat32;
            }

        }

        public FatType FatType { get; set; }

    }
}