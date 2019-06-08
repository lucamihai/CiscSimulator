using System.Diagnostics.CodeAnalysis;

namespace CiscSimulator.Memory.Tests
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public const ushort MinimumAddress = 10;
        public const ushort MaximumAddress = 100;

        public const bool ReadOnlyFalse = false;
        public const bool ReadOnlyTrue = true;
    }
}
