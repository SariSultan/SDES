using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ForensicsCourseToolkit.Framework_Project;

namespace ForensicsCourseToolkit.Common.Helpers
{
    public static class Printer
    {
        private static readonly char LineSeperator = '-';
        private static readonly int padRight = 10;
        private static readonly int padRightLittle = 6;
        private static readonly int padRightLarge = 30;
        private static readonly int parallelLineLength = 80;


        private static Logger _logger;

        public static void PrintEmptyStructure<T>(ref Logger aLogger, ref RichTextBox rtb)
            where T : IHaveStructure, new()
        {

            _logger = aLogger;
            var instance = Activator.CreateInstance<T>();

            PrintHorizentalLine(ref rtb, parallelLineLength, LineSeperator, true);

            //if (instance is IHaveReservedAreaBeforeStructure)
            //{
            //    rtb.AppendText(
            //        $"NOTE:: first {(instance as IHaveReservedAreaBeforeStructure).GetReservedAreaSizeInBytes()} bytes are reserved. \n",
            //        Color.Aqua);
            //}
            rtb.AppendText("bytes(d)".PadRight(padRight) + "Order".PadRight(padRightLittle) +
                           "Description".PadRight(padRightLarge) + "Start".PadRight(padRight) + "End".PadRight(padRight) +
                           "Size(0x)".PadRight(padRight) + "Size(d)".PadRight(padRight) + "\n");
            //+ "Size(bytes)".PadRight(padRight)
            PrintHorizentalLine(ref rtb, parallelLineLength, LineSeperator, true);
            foreach (var u in instance.Structure)
            {
                var description = "";
                if (u.UnitDescription.Length > padRightLarge)
                {
                    description = u.UnitDescription.Substring(0, padRightLarge - 1);
                }
                else
                {
                    description = u.UnitDescription;
                }
                rtb.AppendText(
                    $"{(u.UnitStartLocationInt + "->" + u.UnitEndLocationInt).PadRight(padRight)}{u.Order.ToString().PadRight(padRightLittle)} {description.PadRight(padRightLarge)}{u.UnitStartLocationHex.PadRight(padRight)}{u.UnitEndLocationHex.PadRight(padRight)}{u.UnitSize.ToString("X4").PadRight(padRight)}{u.UnitSize.ToString().PadRight(padRight)}\n",
                    u.UnitColor); //{(u.UnitSize*Filesystems.Common.blockSizeInBytes).ToString().PadRight(padRight)}
            }
            PrintHorizentalLine(ref rtb, parallelLineLength, LineSeperator, true);
        }

        public static void PrintStructureValues(List<StructureUnit> Structure, ref RichTextBox rtb, ref Logger aLogger)
        {
            _logger = aLogger;
            foreach (var unit in Structure)
            {
                var description = "";
                if (unit.UnitDescription.Length > padRightLarge)
                {
                    description = unit.UnitDescription.Substring(0, padRightLarge - 1);
                }
                else
                {
                    description = unit.UnitDescription;
                }

                rtb.AppendText(
                    $"{unit.Order.ToString().PadRight(padRightLittle)}{description.PadRight(padRightLarge)}:{unit.Value}",
                    unit.UnitColor);

                ProcessUnitType(unit, ref rtb);

                rtb.AppendText("\n");
            }
        }

        private static void ProcessUnitType(StructureUnit unit, ref RichTextBox rtb)
        {

            switch (unit.Type)
            {
                case UnitType.Default:
                    break;
                case UnitType.Vbr:
                    break;
                case UnitType.SizeInSectorsLittleEndian:
                    ProcessUnitType_SizeInSectorsLittleEndian(ref unit, ref rtb);
                    break;
                case UnitType.LittleEndianHex:
                    ProcessUnitType_LittleEndianHex(ref unit, ref rtb);
                    break;
                case UnitType.Ascii:
                    ProcessUnitType_Ascii(ref unit, ref rtb);
                    break;
                case UnitType.TimeTenthofSeconds:
                    ProcessUnitType_TimeTenthofSeconds(ref unit, ref rtb);
                    break;
                case UnitType.TimeHms:
                    ProcessUnitType_TimeHms(ref unit, ref rtb);
                    break;
                case UnitType.Day:
                    ProcessUnitType_Date(ref unit, ref rtb);
                    break;
                case UnitType.SizeInBytes:
                    ProcessUnitType_SizeInBytes(ref unit, ref rtb);
                    break;
                case UnitType.FatDirectoryEntryAttributes:
                    ProcessUnitType_FatDirectoryEntryAttributes(ref unit, ref rtb);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private static void ProcessUnitType_FatDirectoryEntryAttributes(ref StructureUnit unit, ref RichTextBox rtb)
        {
            rtb.AppendText("\n");
            rtb.AppendText($"\t\tFlags[", unit.UnitColor);
            string toPrint = "";
            foreach (var anAttribute in Enum.GetValues(typeof (FileAttribute)))
            {
                //_logger.LogMessage($"{at.ToString()} : {at} : {(byte)at}",LogMsgType.Debug);

                byte val = Conversion.HexToByteArray(unit.Value)[0];
                var mask = ((byte) anAttribute & val);
                if (mask == (byte) anAttribute)
                {
                    if (!string.IsNullOrEmpty(toPrint)) toPrint += "+";
                    toPrint += anAttribute;
                }
            }
            rtb.AppendText($"{toPrint}]", unit.UnitColor);

            //List<Tuple<byte, string>> masksList = new List<Tuple<byte, string>>
            //{
            //    new Tuple<byte, string>(0x01, "Read Only"),
            //    new Tuple<byte, string>(0x02, "Hidden File"),
            //    new Tuple<byte, string>(0x04, "System File"),
            //    new Tuple<byte, string>(0x08, "Volume Label"),
            //    new Tuple<byte, string>(0x0f, "Long File Name"),
            //    new Tuple<byte, string>(0x10, "Directory"),
            //    new Tuple<byte, string>(0x20, "Archive")
            //};
            //rtb.AppendText("\n");
            //rtb.AppendText($"\t\tFlags[",unit.UnitColor);
            //foreach (var tuple in masksList)
            //{
            //    byte val= Conversion.HexToByteArray(unit.Value)[0];
            //    var mask = (tuple.Item1 & val);
            //    if (mask == tuple.Item1)
            //    {
            //        rtb.AppendText($"{tuple.Item2}+",unit.UnitColor);
            //    }
            //}
        }

        private static void ProcessUnitType_SizeInBytes(ref StructureUnit unit, ref RichTextBox rtb)
        {


            var bigEndian = Conversion.ConvertLittleEndianToBigEndianandViceVersa(unit.Value);
            var valueDecimal = Conversion.HexLittleEndianToInt(unit.Value);
            rtb.AppendText("\n");
            rtb.AppendText($"\t\tSize in Bytes:\t" +
                           $"0x{bigEndian} == {valueDecimal} (D)", unit.UnitColor);
        }

        private static void ProcessUnitType_Date(ref StructureUnit unit, ref RichTextBox rtb)
        {
            string binary = Helpers.Conversion.HexToBinaryLittleEndian(unit.Value);

            var day = (Helpers.Conversion.BinaryToInt(binary.Substring(16 - 5, 5))).ToString();
            var month = Helpers.Conversion.BinaryToInt(binary.Substring(16 - 9, 4));
            var year = (1980 + Helpers.Conversion.BinaryToInt(binary.Substring(0, 7))).ToString();
            rtb.AppendText("\n");
            rtb.AppendText($"\t\t Day/Month/Year = {day}/{month}/{year}", unit.UnitColor);
        }

        private static void ProcessUnitType_TimeHms(ref StructureUnit unit, ref RichTextBox rtb)
        {
            string binary = Helpers.Conversion.HexToBinaryLittleEndian(unit.Value);

            var second = (2*Helpers.Conversion.BinaryToInt(binary.Substring(16 - 5, 5))).ToString();
            var minute = Helpers.Conversion.BinaryToInt(binary.Substring(16 - 5 - 6, 6));
            var hour = (Helpers.Conversion.BinaryToInt(binary.Substring(16 - 5 - 6 - 5, 5))).ToString();
            rtb.AppendText("\n");
            rtb.AppendText($"\t\t Hour:Minute:Second = {hour}:{minute}:{second}", unit.UnitColor);
        }

        private static void ProcessUnitType_TimeTenthofSeconds(ref StructureUnit unit, ref RichTextBox rtb)
        {
            var valueDecimal = Conversion.HexLittleEndianToInt(unit.Value);
            rtb.AppendText("\n");
            rtb.AppendText($"\t\tValue in Tenth of Seconds:".PadRight(padRightLittle) +
                           $"{valueDecimal}", unit.UnitColor);
        }

        private static void ProcessUnitType_Ascii(ref StructureUnit unit, ref RichTextBox rtb)
        {

            rtb.AppendText("\n");
            rtb.AppendText($"\t\tASCII representation:".PadRight(padRightLarge) +
                           $"{Conversion.HexToAscii(unit.Value)}", unit.UnitColor);
            //rtb.AppendText("\n");
        }

        private static void ProcessUnitType_LittleEndianHex(ref StructureUnit unit, ref RichTextBox rtb)
        {
            rtb.AppendText("\n");
            PrintLittleEndianConversion(ref rtb, unit.Value, unit.UnitColor);
        }

        private static void ProcessUnitType_SizeInSectorsLittleEndian(ref StructureUnit unit, ref RichTextBox rtb)
        {
            PrintLittleEndianConversion(ref rtb, unit.Value, unit.UnitColor);

            var valueDecimal = Conversion.HexLittleEndianToInt(unit.Value);
            var location = valueDecimal*Common.BlockSizeInBytes;
            rtb.AppendText($"\n\t\tMultiply by sector size({Common.BlockSizeInBytes} bytes):".PadRight(padRightLarge)
                           + $"0x{location.ToString("X8")} == {location} (D) ",
                unit.UnitColor);
        }

        private static void PrintLittleEndianConversion(ref RichTextBox rtb, string hexVal, Color aColor)
        {
            var bigEndian = Conversion.ConvertLittleEndianToBigEndianandViceVersa(hexVal);
            var valueDecimal = Conversion.HexLittleEndianToInt(hexVal);
            rtb.AppendText("\n");
            rtb.AppendText($"\t\tBig Endian Value:".PadRight(padRightLarge) +
                           $"0x{bigEndian} == {valueDecimal} (D)", aColor);

            // rtb.AppendText("\n");
        }

        public static void PrintHorizentalLine(ref RichTextBox rtb, int len, char symbol, bool newline)
        {
            for (var i = 0; i < len; i++)
            {
                rtb.AppendText(symbol.ToString(), (rtb.BackColor == Color.Black) ? Color.White : Color.Silver);
            }
            if (newline)
                rtb.AppendText("\n");
        }

        public static void PrintVbrListWithBootSectors(string fileName,ref List<Vbr> vbrList, ref Logger aLogger, ref RichTextBox rtb, bool printHex)
        {
            foreach (var vbr in vbrList)
            {
                var bs = Common.GetUnit<BootSector>(fileName, ref aLogger, vbr.BootSectorStartLocationByte(), $"Boot sector {vbr.Description}", null);
                if (vbr.IsEmptyPartition())
                {
                    rtb.AppendText($"Printing {bs.Description}", Color.DarkCyan, true);
                }
                else
                {
                    Printer.PrintHorizentalLine(ref rtb, 80, '-', true);
                    rtb.AppendText($"Printing {bs.Description}", Color.DarkCyan, true);
                    rtb.AppendText("\n");
                    Printer.PrintHorizentalLine(ref rtb, 80, '-', true);

                    if (!vbr.IsEmptyPartition())
                        Printer.PrintStructureValues(bs.Structure, ref rtb, ref aLogger);

                    if (printHex) { 
                    var aHexPrinter = new HexPrinter(ref rtb, 32, bs.StartAddress, ref aLogger);
                    aHexPrinter.PrintColoredStructure(bs);
                    }
                }
                rtb.AppendText("\n");

            }
        }

       
    }
}
