using System;

namespace CiscSimulator.Common
{
    public static class Utilities
    {
        public static string GetBinaryStringRepresentation(byte value)
        {
            return Convert.ToString(value, 2).PadLeft(8, '0');
        }
    }
}
