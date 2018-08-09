using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ForensicsCourseToolkit.Framework_Project;

namespace ForensicsCourseToolkit.Common.Helpers
{
    public class HexPrinter
    {
        private const int PadRightSpacesLeft = 10;
        private const int PadRightSpacesMiddle = 4;
        private readonly Logger aLogger;
        private readonly int BlockSize; // in hex == bytes *2 
        private readonly RichTextBox rtb;
        private readonly string outputString;
        private string BufferedAscii = "";
        //   string smallTab = "    ";
        private int currentAddress;
        private int StartAddress;

        public HexPrinter(ref RichTextBox aRichTextBox, int blockSizeInHex, int startingAddress, ref Logger aLogger)
        {
            rtb = aRichTextBox;
            BlockSize = blockSizeInHex;
            StartAddress = startingAddress*2;
            currentAddress = startingAddress*2;
            this.aLogger = aLogger;
        }

        public void Initialize()
        {
            rtb.AppendText("        ".PadRight(PadRightSpacesLeft));
            for (var col = 0; col < BlockSize/2; col++)
            {
                rtb.AppendText($"{col.ToString("X2").Trim().PadRight(PadRightSpacesMiddle)}", FontStyle.Bold);
            }
            //  rtb.AppendText("\n");
            //  PrintNextAddress();
        }

        public void PrintValue(string aValue, Color aColor)
        {
            while (aValue.Length > 0)
            {
                if (currentAddress%BlockSize == 0)
                {
                    if (BufferedAscii.Length > 0)
                    {
                        FlushBuffer();
                    }
                    rtb.AppendText(Environment.NewLine);
                    PrintNextAddress();
                }

                var remainder = currentAddress%BlockSize;
                int lengthToCut;
                //First case if it is in a start of a line 
                if (remainder == 0)
                {
                    if (aValue.Length > BlockSize)
                    {
                        lengthToCut = BlockSize;
                    }
                    else
                    {
                        lengthToCut = aValue.Length;
                    }
                }
                // 2nd case, we are already in a line
                else
                {
                    lengthToCut = BlockSize - remainder;
                    if (aValue.Length < lengthToCut)
                    {
                        lengthToCut = aValue.Length;
                    }
                }

                var valueToPrint = aValue.Substring(0, lengthToCut);
                PrintNextNBytes(valueToPrint, aColor);
                currentAddress += lengthToCut;

                if (aValue.Length == lengthToCut)
                {
                    break;
                }
                aValue = aValue.Substring(lengthToCut, aValue.Length - lengthToCut);
            }
        }

        private void PrintNextNBytes(string aValue, Color aColor)
        {
            for (var i = 0; i < aValue.Length; i += 2)
            {
                rtb.AppendText(aValue.Substring(i, 2).Trim().PadRight(PadRightSpacesMiddle), aColor);
            }
            if (aValue.Length < BlockSize)
            {
                BufferedAscii += $"{Conversion.HexToAscii(aValue)}";
            }
            else
            {
                rtb.AppendText($"{BufferedAscii}{Conversion.HexToAscii(aValue)}".PadLeft(4));
                BufferedAscii = "";
            }

            if (BufferedAscii.Length >= BlockSize/2)
            {
                rtb.AppendText($"{BufferedAscii}".PadLeft(4));
                BufferedAscii = "";
            }
        }

        private void FlushBuffer()
        {
            rtb.AppendText($"{BufferedAscii}".PadLeft(4));
            BufferedAscii = "";
        }

        private void PrintNextAddress()
        {
            rtb.AppendText((currentAddress/2).ToString("X8").Trim().PadRight(PadRightSpacesLeft), FontStyle.Bold);
        }

        public void PrintColoredStructure(IHaveStructure anEntityWithStructure)
        {
            aLogger.LogMessage($"Entered: {MethodBase.GetCurrentMethod().Name}", LogMsgType.Debug);
            Initialize();
            var i = 1;
            foreach (var unit in anEntityWithStructure.Structure)
            {
               
                if (unit.Value == "000000")
                {
                    int dx = 100;
                }
                PrintValue(unit.Value, unit.UnitColor);
            }
            rtb.AppendText(Environment.NewLine);
            aLogger.LogMessage($"Exited: {MethodBase.GetCurrentMethod().Name}", LogMsgType.Debug);
        }
    }
}