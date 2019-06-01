using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Common;

namespace CiscSimulator.ArithmeticLogicUnit.UnitTests
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public static Data Operand1 => new Data {Value = 125};
        public static Data Operand2 => new Data {Value = 25};

        public static Data ExpectedResultSum => new Data {Value = 150};
        public static Data ExpectedResultSubtract => new Data {Value = 100};
    }
}
