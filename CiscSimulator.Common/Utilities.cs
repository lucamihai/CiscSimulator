using System;
using System.Text.RegularExpressions;

namespace CiscSimulator.Common
{
    public static class Utilities
    {
        public static string GetBinaryStringRepresentationFromByte(byte value)
        {
            return Convert.ToString(value, 2).PadLeft(8, '0');
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

        public static int GetValueFromBinaryStringRepresentation(string binaryStringRepresentation)
        {
            var trimmedString = binaryStringRepresentation.Trim();
            ValidateBinaryStringRepresentation(trimmedString);

            int value = 0;
            for (int index = 0; index < trimmedString.Length; index++)
            {
                if (trimmedString[index] == '0')
                    continue;

                int power = trimmedString.Length - 1 - index;
                value += (int)Math.Pow(2, power);
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
