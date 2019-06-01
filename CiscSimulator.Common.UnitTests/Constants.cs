using System.Diagnostics.CodeAnalysis;

namespace CiscSimulator.Common.UnitTests
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public static Data Data1 => new Data {HiByte = 0, LoByte = 5};
        public static Data Data2 => new Data {HiByte = 2, LoByte = 4};

        public const string ExpectedDataString1 = "00000000 00000101";
        public const string ExpectedDataString2 = "00000010 00000100";

        public const ushort ExpectedValue1 = 5;
        public const ushort ExpectedValue2 = 516;
    }
}
