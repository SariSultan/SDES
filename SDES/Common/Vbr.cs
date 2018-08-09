using System;
using System.Collections.Generic;
using System.Drawing;
using ForensicsCourseToolkit.Common.Helpers;

namespace ForensicsCourseToolkit.Common
{
    public class Vbr : IHaveStructure,IHaveExactSize,IHaveStartAddress,IHaveCommonProps
    {
        private Logger _aLogger;
        /*** MBR structure (SLIDE 44, COMPUTER FOUNDATION.PDF) 
            START   END     DESCRIPTION
            00      00     Bootable Flag 0x80 - bootable, 0x00 - not bootable
            01      03     STARTING CHS ADDRESS
            04      04     PARTITION TYPE - 0X084=LINUX, 0X82=SWAP
            05      07     END CHS ADDRESS
            08      0B     STARTING LBA ADDRESS
            0C      0F     SIZE IN SECTORS
        */

      
        public string VbrRawValue;

        //public Vbr(string vbrBytesInHex, string vbrDescription, ref Logger aLogger)
        //{
        //    if (!CheckVbrSize(vbrBytesInHex))
        //    {
        //        throw new Exception($"{MethodBase.GetCurrentMethod().Name}::ERROR 0x00 0x01 -- VBR IS NOT CORRECT SIZE");
        //    }

        //    if (Structure == null)
        //    {
        //        Structure = new List<StructureUnit>();
        //    }
        //    VbrRawValue = vbrBytesInHex;
        //    ParseVbrStructureFromRaw(vbrBytesInHex, ref Structure);
        //    VbrDescription = vbrDescription + ((IsEmptyPartition()) ? "--EMPTY" : "");
        //    _aLogger = aLogger;
        //}

        /// <summary>
        ///     only use to get the file structure
        /// </summary>
        public Vbr()
        {
        }

        public IList<StructureUnit> GetStructure()
        {
            return Structure;
        }

        private bool CheckVbrSize(string mbrBytes)
        {
            return mbrBytes.Length == Common.VbrSizeBytes;
        }

        //private void ParseVbrStructureFromRaw(string vbrBytes, ref List<StructureUnit> aStructure)
        //{
        //    foreach (var unit in aStructure)
        //    {
        //        try
        //        {
        //            var temp = Common.CutBytes(vbrBytes, unit.//UnitStartLocationHex, unit.//UnitEndLocationHex);
        //            if (unit.FixedValue)
        //            {
        //                if (unit.Value != temp.ToUpper())
        //                {
        //                    throw new Exception(
        //                        $"{MethodBase.GetCurrentMethod().Name}::ERROR 0x00 0x02 -- vbr unit [{unit.UnitDescription}] from loc=[{unit.//UnitStartLocationHex}] to [{unit.//UnitEndLocationHex}] the value should equal {unit.Value} but it is {temp}");
        //                }
        //            }
        //            unit.Value = temp;
        //        }
        //        catch
        //        {
        //            throw new Exception(
        //                $"{MethodBase.GetCurrentMethod().Name}::ERROR 0x00 0x03 -- Unable to parse vbr unit [{unit.UnitDescription}] from loc=[{unit.//UnitStartLocationHex}] to [{unit.//UnitEndLocationHex}]");
        //        }
        //    }
        //}

        public bool IsEmptyPartition()
        {
            if (Structure == null)
            {
                throw new Exception("Cannot find boot sector start location before loading the structure");
            }

            if (BootSectorStartLocationByte() == 0)
                return true;
            return false;
        }

        public int BootSectorStartLocationByte()
        {
            if (Structure == null)
            {
                throw new Exception("Cannot find boot sector start location before loading the structure");
            }
            return Conversion.HexLittleEndianToInt(Structure[4].Value)*Common.BlockSizeInBytes;
        }

        public List<StructureUnit> Structure { get; set; }= new List<StructureUnit>
        {
            new StructureUnit
            {
                Order = 1,
                UnitDescription = "Bootable flag",
                //UnitStartLocationHex = "0000",
                //UnitEndLocationHex = "0000",
                FixedValue = false,
                UnitColor = Color.Green,
                OffsetByte = 0,
                SizeBytes = 1,
            },
            new StructureUnit
            {
                Order = 2,
                UnitDescription = "Start CHS Address",
                //UnitStartLocationHex = "0001",
                //UnitEndLocationHex = "0003",
                FixedValue = false,
                UnitColor = Color.Red,
                OffsetByte = 1,
                SizeBytes = 3,
            },
            new StructureUnit
            {
                Order = 3,
                UnitDescription = "Partition Type",
                //UnitStartLocationHex = "0004",
                //UnitEndLocationHex = "0004",
                FixedValue = false,
                UnitColor = Color.Brown,
                OffsetByte = 4,
                SizeBytes = 1,
            },
            new StructureUnit
            {
                Order = 4,
                UnitDescription = "Ending CHS Address",
                //UnitStartLocationHex = "0005",
                //UnitEndLocationHex = "0007",
                FixedValue = false,
                UnitColor = Color.Blue,
                OffsetByte = 5,
                SizeBytes = 3,

            },
            new StructureUnit
            {
                Order = 5,
                UnitDescription = "Starting LBA Address",
                //UnitStartLocationHex = "0008",
                //UnitEndLocationHex = "000B",
                FixedValue = false,
                UnitColor = Color.Magenta,
                Type = UnitType.SizeInSectorsLittleEndian,
                OffsetByte = 8,
                SizeBytes = 4,
            },
            new StructureUnit
            {
                Order = 6,
                UnitDescription = "Size in Secotrs",
                //UnitStartLocationHex = "000C",
                //UnitEndLocationHex = "000F",
                FixedValue = false,
                UnitColor = Color.Orange,
                Type = UnitType.SizeInSectorsLittleEndian,
                OffsetByte = 0x0C,
                SizeBytes = 4,
            }
        };

        public int GetExpectedSize()
        {
            return Common.VbrSizeBytes;
        }


        

        public int StartAddress { get; set; }
        public Logger Logger { get; set; }
        public string RawValue { get; set; }
       public int Size { get
            {
                if (Structure == null)
                {
                    throw new Exception("Cannot find boot sector start location before loading the structure");
                }
                return Conversion.HexLittleEndianToInt(Structure[5].Value) * Common.BlockSizeInBytes;
            } }
        public string Description { get; set; }
    }
}