using System.Drawing;

namespace ForensicsCourseToolkit.Common
{
    public class StructureUnit
    {
        
        public int Order { get; set; }
        public string UnitDescription { get; set; }
        public string UnitStartLocationHex => (OffsetByte.ToString("X2"));

        public int UnitStartLocationInt => OffsetByte;

        public string UnitEndLocationHex => (OffsetByte + SizeBytes).ToString("X2");

        public int UnitEndLocationInt => OffsetByte+SizeBytes;

        public int UnitSize => UnitEndLocationInt - UnitStartLocationInt ;

        public string Value { get; set; }
        public bool FixedValue { get; set; }
        public Color UnitColor { get; set; }
        public UnitType Type { get; set; }



        public string MicrosoftFiledCode { get; set; } 
        public int OffsetByte { get; set; }
        public int SizeBytes { get; set; }
    }
}