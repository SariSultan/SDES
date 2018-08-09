using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using ForensicsCourseToolkit.Common.Helpers;
using ForensicsCourseToolkit.Framework_Project;

namespace ForensicsCourseToolkit.Common
{
    public partial class CovertersFrm : Form
    {
        public enum ConvertType
        {
            Int,
            HexLittleEndian,
            HexBigEndian
        }

        private readonly Logger aLogger;

        public CovertersFrm()
        {
            InitializeComponent();
            aLogger = new Logger(ref richTextBox1);
            fromLittleEndianRadioBrn.Checked = true;
            toIntRadioBtn.Checked = true;
        }

        private void convertBtn_Click(object sender, EventArgs e)
        {
            var valueToConvert = fromTxtBox.Text;
            if (string.IsNullOrWhiteSpace(valueToConvert))
            {
                aLogger.LogMessage("Please add the value you want to convert!", LogMsgType.Error);
                return;
            }

            ConvertType convertFrom, convertTo;

            if (fromIntRadioBtn.Checked)
            {
                convertFrom = ConvertType.Int;
            }
            else if (fromLittleEndianRadioBrn.Checked)
            {
                convertFrom = ConvertType.HexLittleEndian;
            }
            else if (fromBigEndianRadioBtn.Checked)
            {
                convertFrom = ConvertType.HexBigEndian;
            }
            else
            {
                aLogger.LogMessage("The type to convert from is not selected", LogMsgType.Error);
                return;
            }


            if (toIntRadioBtn.Checked)
            {
                convertTo = ConvertType.Int;
            }
            else if (toLittleEndianRadioBtn.Checked)
            {
                convertTo = ConvertType.HexLittleEndian;
            }
            else if (toBigEndianRadioBtn.Checked)
            {
                convertTo = ConvertType.HexBigEndian;
            }
            else
            {
                aLogger.LogMessage("The type to convert TO is not selected", LogMsgType.Error);
                return;
            }
            try
            {
                var convertedValue = doConverter(convertFrom, convertTo, valueToConvert);
                if (convertedValue == string.Empty)
                {
                    aLogger.LogMessage("convertedValue=string.empty, something wrong happened!", LogMsgType.Warning);
                    return;
                }

                richTextBox1.AppendText($"Convert from {convertFrom}".PadRight(30) + $", Value=[{valueToConvert}]");
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText($"Coverted to   {convertTo}".PadRight(30) + $", Result =[{convertedValue}]");
                richTextBox1.AppendText("\n\n");
            }
            catch (Exception ex)
            {
                aLogger.LogMessage(ex.Message, LogMsgType.Fatal);
            }
        }

        private string doConverter(ConvertType convertFrom, ConvertType convertTo, string valueToConvert)
        {
            if (convertFrom == convertTo)
            {
                aLogger.LogMessage($"Cannot convert from {convertFrom} to {convertTo}", LogMsgType.Error);
                return string.Empty;
            }

            switch (convertFrom)
            {
                case ConvertType.Int:
                    return ConvertIntToType(convertTo, valueToConvert);
                    break;

                case ConvertType.HexLittleEndian:
                    return ConvertHexLittleEndianToType(convertTo, valueToConvert);
                    break;

                case ConvertType.HexBigEndian:
                    return ConvertHexBigEndianToType(convertTo, valueToConvert);
                    break;
            }
            return string.Empty;
        }

        private string ConvertHexLittleEndianToType(ConvertType convertTo, string valueToConvert)
        {
            if (!Conversion.OnlyHexInString(valueToConvert))
            {
                aLogger.LogMessage($"The value {valueToConvert} is not a corrent hex! Opearation stopped!",
                    LogMsgType.Error);
                return string.Empty;
            }

            switch (convertTo)
            {
                case ConvertType.Int:
                    return Conversion.HexLittleEndianToInt(valueToConvert).ToString();
                    break;
                case ConvertType.HexBigEndian:
                    return Conversion.ConvertLittleEndianToBigEndianandViceVersa(valueToConvert);
                    break;
                default:
                    return string.Empty;
                    aLogger.LogMessage($"Reached default cased in{MethodBase.GetCurrentMethod().Name}", LogMsgType.Fatal);
                    return string.Empty;
                    break;
            }
        }

        private string ConvertHexBigEndianToType(ConvertType convertTo, string valueToConvert)
        {
            if (!Conversion.OnlyHexInString(valueToConvert))
            {
                aLogger.LogMessage($"The value {valueToConvert} is not a corrent hex! Opearation stopped!",
                    LogMsgType.Error);
                return string.Empty;
            }

            switch (convertTo)
            {
                case ConvertType.Int:
                    return int.Parse(valueToConvert, NumberStyles.HexNumber).ToString();
                    break;
                case ConvertType.HexLittleEndian:
                    return Conversion.ConvertLittleEndianToBigEndianandViceVersa(valueToConvert);
                    break;
                default:
                    return string.Empty;
                    aLogger.LogMessage($"Reached default cased in{MethodBase.GetCurrentMethod().Name}", LogMsgType.Fatal);
                    return string.Empty;
                    break;
            }
        }

        private string ConvertIntToType(ConvertType convertTo, string valueToConvert)
        {
            int testValue;
            if (!int.TryParse(valueToConvert, out testValue))
            {
                aLogger.LogMessage($"The value {valueToConvert} is not a corrent integer! Opearation stopped!",
                    LogMsgType.Error);
                return string.Empty;
            }

            switch (convertTo)
            {
                case ConvertType.HexBigEndian:
                    var converted = testValue.ToString("X2");
                    if (converted.Length%2 == 1)
                        converted = "0" + converted;
                    return converted;
                    break;
                case ConvertType.HexLittleEndian:
                    return Conversion.IntToHexLittleEndian(testValue);
                    break;
                default:
                    return string.Empty;
                    aLogger.LogMessage($"Reached default cased in{MethodBase.GetCurrentMethod().Name}", LogMsgType.Fatal);
                    return string.Empty;
                    break;
            }
        }

        private void parseBtn_Click(object sender, EventArgs e)
        {
            var
            directoryEntryText = directoryEntryTxtBox.Text;

        }
    }
}