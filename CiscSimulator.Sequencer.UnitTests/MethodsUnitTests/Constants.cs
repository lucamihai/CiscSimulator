using System.Diagnostics.CodeAnalysis;

namespace CiscSimulator.Sequencer.UnitTests.MethodsUnitTests
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public const ushort ValueToWrite1 = 100;
        public const ushort ValueToWrite2 = 101;

        public const ushort MemoryValue1 = 3;
        public const ushort MemoryAddress1 = CiscSimulator.Sequencer.Constants.MemoryInstructionStartAddress + 40;

        public const ushort MemoryValue2 = 7;
        public const ushort MemoryAddress2 = CiscSimulator.Sequencer.Constants.MemoryInstructionStartAddress + 41;

        public const ushort MemoryInstructionValue1 = 1;
        public const ushort MemoryInstructionAddress1 = CiscSimulator.Sequencer.Constants.MemoryInstructionStartAddress;

        public const ushort MemoryInstructionValue2 = 2;
        public const ushort MemoryInstructionAddress2 = CiscSimulator.Sequencer.Constants.MemoryInstructionStartAddress + 1;
    }
}
