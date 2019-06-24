using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Assembler.Enums;

namespace CiscSimulator.Sequencer.UnitTests.MethodsUnitTests
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public const ushort Value1 = 100;
        public const ushort Value2 = 101;

        public const ushort MemoryValue1 = 3;
        public const ushort MemoryAddress1 = CiscSimulator.Sequencer.Constants.MemoryInstructionStartAddress + 40;

        public const ushort MemoryValue2 = 7;
        public const ushort MemoryAddress2 = CiscSimulator.Sequencer.Constants.MemoryInstructionStartAddress + 41;

        public const ushort MemoryInstructionValue1 = 1;
        public const ushort MemoryInstructionAddress1 = CiscSimulator.Sequencer.Constants.MemoryInstructionStartAddress;

        public const ushort MemoryInstructionValue2 = 2;
        public const ushort MemoryInstructionAddress2 = CiscSimulator.Sequencer.Constants.MemoryInstructionStartAddress + 1;

        // 00010000 00010000
        public const ushort InstructionValue1 = 4112;
        public const InstructionClass ExpectedInstructionClass1 = InstructionClass.B1;
        public const AddressMode ExpectedDestinationAddressMode1 = AddressMode.Direct;
        public const AddressMode ExpectedSourceAddressMode1 = AddressMode.Immediate;
        public const byte ExpectedInstructionNumber1 = 1;

        // 10000000 10010001
        public const ushort InstructionValue2 = 32913;
        public const InstructionClass ExpectedInstructionClass2 = InstructionClass.B2;
        public const AddressMode ExpectedDestinationAddressMode2 = AddressMode.Direct;
        public const byte ExpectedInstructionNumber2 = 2;

        // 11000000 00010100
        public const ushort InstructionValue3 = 49172;
        public const InstructionClass ExpectedInstructionClass3 = InstructionClass.B3;
        public const byte ExpectedInstructionNumber3 = 0;

        // 11100000 00001110
        public const ushort InstructionValue4 = 57358;
        public const InstructionClass ExpectedInstructionClass4 = InstructionClass.B4;
        public const byte ExpectedInstructionNumber4 = 14;
    }
}
