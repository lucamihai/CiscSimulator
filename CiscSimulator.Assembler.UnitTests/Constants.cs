namespace CiscSimulator.Assembler.UnitTests
{
    public static class Constants
    {
        public const string LineInstructionB1WithDestinationImmediateValue = "add 10, r1";
        public const string LineInstructionB1WithTooFewArguments = "add r0";
        public const string LineInstructionB1WithTooManyArguments = "add r0, r1, r2";

        public const string LineInstructionB1Valid1 = "add r0, 2";
        public const byte InstructionB1ExpectedDestination1 = 0;
        public const byte InstructionB1ExpectedSource1 = 2;
        public const AddressMode InstructionB1ExpectedDestinationAddressMode1 = AddressMode.Direct;
        public const AddressMode InstructionB1ExpectedSourceAddressMode1 = AddressMode.Immediate;

        public const string LineInstructionB1Valid2 = "add r0, r1";
        public const byte InstructionB1ExpectedDestination2 = 0;
        public const byte InstructionB1ExpectedSource2 = 1;
        public const AddressMode InstructionB1ExpectedDestinationAddressMode2 = AddressMode.Direct;
        public const AddressMode InstructionB1ExpectedSourceAddressMode2 = AddressMode.Direct;

        // =====

        public const string LineInstructionB2WithTooFewArguments = "inc";
        public const string LineInstructionB2WithTooManyArguments = "inc r0, r1";

        public const string LineInstructionB2Valid1 = "inc r1";
        public const byte InstructionB2ExpectedValue1 = 1;
        public const AddressMode InstructionB2ExpectedAddressMode1 = AddressMode.Direct;

        public const string LineInstructionB2Valid2 = "asl (r2)";
        public const byte InstructionB2ExpectedValue2 = 2;
        public const AddressMode InstructionB2ExpectedAddressMode2 = AddressMode.Indirect;

        // =====

        public const string LineInstructionB3WithTooFewArguments = "br";
        public const string LineInstructionB3WithTooManyArguments = "br 10, 10";

        public const string LineInstructionB3Valid1 = "br 20";
        public const byte InstructionB3ExpectedOffset1 = 20;
    }
}
