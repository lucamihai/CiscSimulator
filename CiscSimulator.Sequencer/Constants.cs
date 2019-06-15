using System.Diagnostics.CodeAnalysis;

namespace CiscSimulator.Sequencer
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public const ushort MemoryMinimumAddress = 0;
        public const ushort MemoryMaximumAddress = 10000;

        public const ushort MemoryInstructionStartAddress = 5000;
        public const ushort MemoryInstructionEndAddress = MemoryMaximumAddress;
    }
}
