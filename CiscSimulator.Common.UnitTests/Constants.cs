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

        public const byte Value1 = 10;
        public const byte Value2 = 123;
        public const int Value3 = 891;
        public const long Value4 = 99999999;

        public const string BinaryStringRepresentation1 = "00001010";
        public const string BinaryStringRepresentation2 = "01111011";
        public const string BinaryStringRepresentation3 = "001101111011";
        public const string BinaryStringRepresentation4 = "101111101011110000011111111";

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
        public const string BinaryStringTooLong = "101010010101010100101010100101010010101001010100101010010101010010101001010101001";

        public const int HighPosition1 = 4;
        public const int LowPosition1 = 3;
        public const string ExpectedBits1 = "01";

        public const int HighPosition2 = 6;
        public const int LowPosition2 = 5;
        public const string ExpectedBits2 = "11";

        public const int HighPosition3 = 11;
        public const int LowPosition3 = 5;
        public const string ExpectedBits3 = "0011011";

        public const int HighPosition4 = 2;
        public const int LowPosition4 = 2;
        public const string ExpectedBits4 = "1";
    }
}
