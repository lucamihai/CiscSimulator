using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Common;

namespace CiscSimulator.ArithmeticLogicUnit.UnitTests
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public static Data Operand1 => new Data {Value = 125};
        public static Data Operand2 => new Data {Value = 3};

        public static Data ExpectedResultSum => new Data {Value = 128};
        public static Data ExpectedResultSubtract => new Data {Value = 122};

        public static Data ExpectedResultAnd => new Data {Value = 1};
        public static Data ExpectedResultOr => new Data {Value = 127};
        public static Data ExpectedResultExclusiveOr => new Data {Value = 126};
    }
}
