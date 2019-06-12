using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;

namespace CiscSimulator.Common
{
    public static class Utilities
    {
        public static string GetBinaryStringRepresentationFromByte(long value, int maxLength = 8)
        {
            return Convert.ToString(value, 2).PadLeft(maxLength, '0');
        }

        public static string Slice(this string source, int start, int end)
        {
            if (end < 0) // Keep this for negative end support
            {
                end = source.Length + end;
            }
            int len = end - start;               // Calculate length
            return source.Substring(start, len); // Return Substring of length
        }

        public static string GetBitsFromSpecifiedPositions(this string binaryRepresentation, int highPosition, int lowPosition)
        {
            var difference = highPosition - lowPosition;
            var begin = binaryRepresentation.Length - highPosition - 1;

            return binaryRepresentation.Substring(begin, difference + 1);
        }

        public static long GetValueFromBinaryStringRepresentation(string binaryStringRepresentation)
        {
            var trimmedString = binaryStringRepresentation.Trim();
            ValidateBinaryStringRepresentation(trimmedString);

            long value = 0;
            for (int index = 0; index < trimmedString.Length; index++)
            {
                if (trimmedString[index] == '0')
                    continue;

                int power = trimmedString.Length - 1 - index;
                value += (long)Math.Pow(2, power);
            }

            return value;
        }

        private static void ValidateBinaryStringRepresentation(string binaryStringRepresentation)
        {
            var regex = new Regex("^[0-1]+$");
            var match = regex.IsMatch(binaryStringRepresentation);

            if (!match)
            {
                throw new InvalidOperationException("Binary string representation should contain only whitespaces + 1s and 0s");
            }

            if (binaryStringRepresentation.Length > 16)
            {
                throw new InvalidOperationException("Maximum 16 bits are allowed");
            }
        }
    }
}
