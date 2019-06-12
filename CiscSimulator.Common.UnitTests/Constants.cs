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

        public const byte Byte1 = 10;
        public const byte Byte2 = 123;

        public const string ByteStringRepresentation1 = "00001010";
        public const string ByteStringRepresentation2 = "01111011";

        public const string String1 = "something";
        public const int StringSliceBegin1 = 4;
        public const int StringSliceEnd1 = 9;
        public const string SlicedString1 = "thing";

        public const string String2 = "interesting";
        public const int StringSliceBegin2 = 0;
        public const int StringSliceEnd2 = 8;
        public const string SlicedString2 = "interest";

        public const string String3 = "IDEA";
        public const int StringSliceBegin3 = 0;
        public const int StringSliceEnd3 = -1;
        public const string SlicedString3 = "IDE";

        public const string BinaryStringContainingOtherCharacters = "101e10001m";
        public const string BinaryStringTooLong = "1010100101010101001010101001010100101010010101001";
    }
}
