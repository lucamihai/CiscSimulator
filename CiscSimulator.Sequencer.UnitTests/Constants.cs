using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CiscSimulator.ArithmeticLogicUnit.Enums;
using CiscSimulator.Assembler.Enums;
using CiscSimulator.Assembler.Instructions;
using CiscSimulator.Assembler.Interfaces;
using CiscSimulator.Common;
using CiscSimulator.Sequencer.Enums;

namespace CiscSimulator.Sequencer.UnitTests
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public static SBusDBusOperations SBusOperation => SBusDBusOperations.PD0;
        public static SBusDBusOperations DBusOperation => SBusDBusOperations.PdAdr;
        public static AluOperator AluOperator => AluOperator.Add;
        public static RBusOperations RBusOperation => RBusOperations.PmIVR;
        public static OtherOperations OtherOperation => OtherOperations.CLS;
        public static MemoryOperations MemoryOperation => MemoryOperations.Read;
        public static JumpOperations JumpOperation => JumpOperations.B1;
        public const byte JumpLocation = 0;
        public static Indexes JumpIndex => Indexes.Index1;

        // 0x408A8A6011
        public const long ExpectedValue1 = 277202231313;
        public static MpmData MpmData1 => new MpmData
        {
            SBusOperation = SBusDBusOperations.PdPc,
            DBusOperation = SBusDBusOperations.PD0,
            AluOperator = AluOperator.Add,
            RBusOperation = RBusOperations.PmAdr,
            OtherOperation = OtherOperations.IncrementPC,
            MemoryOperation = MemoryOperations.IfCh,
            JumpOperation = JumpOperations.JUMPI,
            JumpLocation = 1,
            JumpIndex = Indexes.Index1
        };

        // 0x108B0060D3
        public const long ExpectedValue2 = 71051534547;
        public static MpmData MpmData2 => new MpmData
        {
            SBusOperation = SBusDBusOperations.PdRG,
            DBusOperation = SBusDBusOperations.PD0,
            AluOperator = AluOperator.Add,
            RBusOperation = RBusOperations.PmT,
            OtherOperation = OtherOperations.None,
            MemoryOperation = MemoryOperations.None,
            JumpOperation = JumpOperations.JUMPI,
            JumpLocation = 13,
            JumpIndex = Indexes.Index3
        };

        public static List<IInstruction> InstructionList1 =>
            new List<IInstruction>
            {
                B1Instruction1,
                B1Instruction2
            };

        public static List<IInstruction> InstructionList2 =>
            new List<IInstruction>
            {
                B1Instruction1
            };

        private static B1Instruction B1Instruction1 =>
            new B1Instruction
            {
                Destination = new Data {Value = 10 },
                DestinationAddressMode = AddressMode.Direct,
                Source = new Data {Value = 2},
                SourceAddressMode = AddressMode.Direct,
                InstructionNumber = 1
            };

        private static B1Instruction B1Instruction2 =>
            new B1Instruction
            {
                Destination = new Data { Value = 10 },
                DestinationAddressMode = AddressMode.Direct,
                Source = new Data { Value = 0 },
                SourceAddressMode = AddressMode.Immediate,
                SourceDataExtension = new Data { Value = 200 },
                InstructionNumber = 1
            };

        public const byte Value1 = 10;
        public const byte Value2 = 123;

        public const string DisplayedValueBinary1 = "000000000000000000000000000000000001010";
        public const string DisplayedValueBinary2 = "000000000000000000000000000000001111011";

        public const string DisplayedValueDecimal1 = "10";
        public const string DisplayedValueDecimal2 = "123";

        public const string DisplayedValueHexadecimal1 = "0xA";
        public const string DisplayedValueHexadecimal2 = "0x7B";
    }
}
