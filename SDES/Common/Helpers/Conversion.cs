using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ForensicsCourseToolkit.Common.Helpers
{
    public static class Conversion
    {
        static Dictionary<char,string> hexToBinDictionary = new Dictionary<char, string>{
            { '0', "0000"},
            { '1', "0001"},
            { '2', "0010"},
            { '3', "0011"},

            { '4', "0100"},
            { '5', "0101"},
            { '6', "0110"},
            { '7', "0111"},

            { '8', "1000"},
            { '9', "1001"},
            { 'A', "1010"},
            { 'B', "1011"},

            { 'C', "1100"},
            { 'D', "1101"},
            { 'E', "1110"},
            { 'F', "1111"}};
        public static char ToSafeAscii(int b)
        {
            if (b > 32 && b <= 126)
            {
                return (char) b;
            }
            return '.';
        }


        public static string FlipHexValueAsBytes(string hexValue)
        {
            var arr=HexToByteArray(hexValue);
            Array.Reverse(arr);
            return ByteArrayToString(arr);

        }
        public static string HexToAscii(string hexString)
        {
            var SafeString = "";
            for (var d = 0; d < hexString.Length; d += 2)
            {
                var val = int.Parse(hexString.Substring(d, 2), NumberStyles.HexNumber);
                var safe = ToSafeAscii(val);
                SafeString += safe;
            }

            return SafeString.Trim();
        }

        public static string AsciiToHex(string asciiString)
        {
            var charValues = asciiString.ToCharArray();
            var hexOutput = "";
            foreach (var c in charValues)
            {
                var value = Convert.ToInt32(c);
                hexOutput += string.Format("{0:X2}", value);
            }
            return hexOutput;
        }

        public static byte[] HexToByteArray(string hex)
        {
            if (hex.Length%2 == 1)
                hex = "0" + hex;
            return Enumerable.Range(0, hex.Length)
                .Where(x => x%2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }

        public static string ByteArrayToString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length*2);
            foreach (var b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static string ConvertLittleEndianToBigEndianandViceVersa(string hexValue)
        {
            var array = HexToByteArray(hexValue);
            Array.Reverse(array);
            var reversedString = ByteArrayToString(array);
            return reversedString;
        }

        public static string IntToHexLittleEndian(int value)
        {
            var bigEndian = value.ToString("X2");
            var array = HexToByteArray(bigEndian);
            Array.Reverse(array);
            var littleEndian = ByteArrayToString(array);
            return littleEndian;
        }

        public static int HexLittleEndianToInt(string hexValue)
        {
            var value = int.Parse(ConvertLittleEndianToBigEndianandViceVersa(hexValue), NumberStyles.HexNumber);
            return value;
        }

        public static bool OnlyHexInString(string test)
        {
            // For C-style hex notation (0xFF) you can use @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z"
            return Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        public static string HexToBinaryLittleEndian(string hexString)
        {
            string flippedHex = FlipHexValueAsBytes(hexString).ToUpper();
            return string.Join("", from character in flippedHex
                                   select hexToBinDictionary[character]);
        }

        public static string ReverseString(string aString)
        {
            var arr = aString.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        public static int BinaryToInt(string binaryString)
        {
            return Convert.ToInt32(binaryString, 2);
        }

        public static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}