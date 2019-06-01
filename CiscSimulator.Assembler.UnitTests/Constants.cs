using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Assembler.Enums;
using CiscSimulator.Common;

namespace CiscSimulator.Assembler.UnitTests
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public const string LineInstructionB1WithDestinationImmediateValue = "add 10, r1";
        public const string LineInstructionB1WithTooFewArguments = "add r0";
        public const string LineInstructionB1WithTooManyArguments = "add r0, r1, r2";

        public const string LineInstructionB1Valid1 = "add r0, 2";
        public const byte InstructionB1ExpectedInstructionNumber1 = 1;
        public const byte InstructionB1ExpectedDestination1 = 0;
        public const byte InstructionB1ExpectedSource1 = 2;
        public const AddressMode InstructionB1ExpectedDestinationAddressMode1 = AddressMode.Direct;
        public const AddressMode InstructionB1ExpectedSourceAddressMode1 = AddressMode.Immediate;
        public static List<Data> InstructionB1ExpectedDataList1 =>
            new List<Data>
            {
                new Data {Value = 4112}, // 00010000 00010000
                new Data {Value = 2},    // 00000000 00000010
            };

        public const string LineInstructionB1Valid2 = "add r0, r1";
        public const byte InstructionB1ExpectedInstructionNumber2 = 1;
        public const byte InstructionB1ExpectedDestination2 = 0;
        public const byte InstructionB1ExpectedSource2 = 1;
        public const AddressMode InstructionB1ExpectedDestinationAddressMode2 = AddressMode.Direct;
        public const AddressMode InstructionB1ExpectedSourceAddressMode2 = AddressMode.Direct;
        public static List<Data> InstructionB1ExpectedDataList2 =>
            new List<Data>
            {
                new Data {Value = 5200} // 00010100 01010000
            };

        public const string LineInstructionB1Valid3 = "and (r3)10, (r4)2";
        public const byte InstructionB1ExpectedInstructionNumber3 = 4;
        public const byte InstructionB1ExpectedDestination3 = 3;
        public const byte InstructionB1ExpectedSource3 = 4;
        public const AddressMode InstructionB1ExpectedDestinationAddressMode3 = AddressMode.Indexed;
        public const AddressMode InstructionB1ExpectedSourceAddressMode3 = AddressMode.Indexed;
        public static List<Data> InstructionB1ExpectedDataList3 =>
            new List<Data>
            {
                new Data {Value = 19763}, // 01001101 00110011
                new Data {Value = 2},    // 00000000 00000010
                new Data {Value = 10}    // 00000000 00001010
            };

        // =====

        public const string LineInstructionB2WithTooFewArguments = "inc";
        public const string LineInstructionB2WithTooManyArguments = "inc r0, r1";

        public const string LineInstructionB2Valid1 = "inc r1";
        public const byte InstructionB2ExpectedInstructionNumber1 = 2;
        public const byte InstructionB2ExpectedValue1 = 1;
        public const AddressMode InstructionB2ExpectedAddressMode1 = AddressMode.Direct;
        public static List<Data> InstructionB2ExpectedDataList1 =>
            new List<Data>
            {
                new Data {Value = 32913} // 10000000 10010001
            };

        public const string LineInstructionB2Valid2 = "asl (r2)";
        public const byte InstructionB2ExpectedInstructionNumber2 = 4;
        public const byte InstructionB2ExpectedValue2 = 2;
        public const AddressMode InstructionB2ExpectedAddressMode2 = AddressMode.Indirect;
        public static List<Data> InstructionB2ExpectedDataList2 =>
            new List<Data>
            {
                new Data {Value = 33058} // 10000001 00100010
            };

        // =====

        public const string LineInstructionB3WithTooFewArguments = "br";
        public const string LineInstructionB3WithTooManyArguments = "br 10, 10";

        public const string LineInstructionB3Valid1 = "br 20";
        public const byte InstructionB3ExpectedInstructionNumber1 = 0;
        public const byte InstructionB3ExpectedOffset1 = 20;
        public static List<Data> InstructionB3ExpectedDataList1 =>
            new List<Data>
            {
                new Data {Value = 49172}, // 11000000 00010100
                new Data()
            };

        // =====

        public const string LineInstructionB4WithTooManyArguments = "clc r1";

        public const string LineInstructionB4Valid1 = "clc";
        public const byte InstructionB4ExpectedInstructionNumber1 = 0;
        public static List<Data> InstructionB4ExpectedDataList1 =>
            new List<Data>
            {
                new Data {Value = 57344} // 11100000 00000000
            };

        public const string LineInstructionB4Valid2 = "wait";
        public const byte InstructionB4ExpectedInstructionNumber2 = 14;
        public static List<Data> InstructionB4ExpectedDataList2 =>
            new List<Data>
            {
                new Data {Value = 57358} // 11100000 00001110
            };

        // =====

        public const string LineInstructionUnrecognized1 = "move r1, r2";
        public const string LineInstructionUnrecognized2 = "addi r1, r2";
    }
}
