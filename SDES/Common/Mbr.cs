using System.Collections.Generic;
using System.Drawing;
using ForensicsCourseToolkit.Common.Helpers;

namespace ForensicsCourseToolkit.Common
{
    public class Mbr : IHaveStructure, IHaveStartAddress, IHaveExactSize, IHaveCommonProps
    {
        public Mbr()
        {
        }

        public int GetExpectedSize()
        {
            return Common.MbrSizeBytes;
        }

        public Logger Logger { get; set; }
        public string RawValue { get; set; }

        public int Size => Common.MbrSizeBytes;
        public string Description { get; set; }

        /*** MBR structure (SLIDE 42, COMPUTER FOUNDATION.PDF) 
            START   END     DESCRIPTION
            000     1BD     bootstrap code (MBR) 
            1BE     1CD     1ST PARTITION ENTRY
            1CE     1DD     2ND PARTITION ENTRY
            1DE     1ED     3RD PARTITION ENTRY
            1EE     1FD     4TH PARTITION ENTRY
            1FE     1FF     DISK SIGNATURE/ TIME STAMP 
            */
        public List<StructureUnit> Structure { get; set; } = new List<StructureUnit>
        {
            new StructureUnit
            {
                Order = 1,
                UnitDescription = "Bootstrap code MBR",
               // //UnitStartLocationHex = "0000",
               // //UnitEndLocationHex = "01BD",
                FixedValue = false,
                UnitColor = Color.Green,
                Type = UnitType.Default,
                OffsetByte = 0,
                SizeBytes = 446,

            },
            new StructureUnit
            {
                Order = 2,
                UnitDescription = "1st Partition Entry",
                //UnitStartLocationHex = "01BE",
                //UnitEndLocationHex = "01CD",
                FixedValue = false,
                UnitColor = Color.Red,
                Type = UnitType.Vbr,
                OffsetByte = 0x1BE,
                SizeBytes = Common.VbrSizeBytes,
            },
            new StructureUnit
            {
                Order = 3,
                UnitDescription = "2nd Partition Entry",
                //UnitStartLocationHex = "01CE",
                //UnitEndLocationHex = "01DD",
                FixedValue = false,
                UnitColor = Color.Blue,
                Type = UnitType.Vbr,
                OffsetByte = 0x1CE,
                SizeBytes = Common.VbrSizeBytes,
            },
            new StructureUnit
            {
                Order = 4,
                UnitDescription = "3rd Partition Entry",
                //UnitStartLocationHex = "01DE",
                //UnitEndLocationHex = "01ED",
                FixedValue = false,
                UnitColor = Color.Magenta,
                Type = UnitType.Vbr,
                OffsetByte = 0x1DE,
                SizeBytes = Common.VbrSizeBytes,
            },
            new StructureUnit
            {
                Order = 5,
                UnitDescription = "4th Partition Entry",
                //UnitStartLocationHex = "01EE",
                //UnitEndLocationHex = "01FD",
                FixedValue = false,
                UnitColor = Color.DarkKhaki,
                Type = UnitType.Vbr,
                OffsetByte = 0x1EE,
                SizeBytes = Common.VbrSizeBytes,
            },
            new StructureUnit
            {
                Order = 6,
                UnitDescription = "Disk Signature",
                //UnitStartLocationHex = "01FE",
                //UnitEndLocationHex = "01FF",
                FixedValue = true,
                Value = "55AA",
                UnitColor = Color.Orange,
                Type = UnitType.Default,
                OffsetByte = 0x1FE,
                SizeBytes = 2
            }
        };

        public int StartAddress { get; set; } = 0;
    }
}