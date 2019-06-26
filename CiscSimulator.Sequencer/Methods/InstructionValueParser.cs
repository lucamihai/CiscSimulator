using CiscSimulator.Assembler.Enums;
using CiscSimulator.Common;

namespace CiscSimulator.Sequencer.Methods
{
    public static class InstructionValueParser
    {
        public static InstructionClass GetInstructionClass(ushort instructionValue)
        {
            var instructionClassValue = instructionValue >> 13;

            if (instructionClassValue == 0)
                return InstructionClass.B1;

            if (instructionClassValue == 4)
                return InstructionClass.B2;

            if (instructionClassValue == 6)
                return InstructionClass.B3;

            if (instructionClassValue == 7)
                return InstructionClass.B4;

            return InstructionClass.NotRecognized;
        }

        public static AddressMode GetAddressModeSource(ushort instructionValue)
        {
            var binaryStringRepresentation = Utilities.GetBinaryStringRepresentation(instructionValue, 16);
            var addressModeSourceBits = binaryStringRepresentation.GetBitsFromSpecifiedPositions(11, 10);
            var addressModeSourceValue = Utilities.GetValueFromBinaryStringRepresentation(addressModeSourceBits);

            return (AddressMode)addressModeSourceValue;
        }

        public static AddressMode GetAddressModeDestination(ushort instructionValue)
        {
            var binaryStringRepresentation = Utilities.GetBinaryStringRepresentation(instructionValue, 16);
            var addressModeSourceBits = binaryStringRepresentation.GetBitsFromSpecifiedPositions(5, 4);
            var addressModeSourceValue = Utilities.GetValueFromBinaryStringRepresentation(addressModeSourceBits);

            return (AddressMode)addressModeSourceValue;
        }

        public static byte GetInstructionNumberB1(ushort instructionValue)
        {
            var binaryStringRepresentation = Utilities.GetBinaryStringRepresentation(instructionValue, 16);
            var instructionNumberBits = binaryStringRepresentation.GetBitsFromSpecifiedPositions(14, 12);
            var instructionNumber = (byte)Utilities.GetValueFromBinaryStringRepresentation(instructionNumberBits);

            return instructionNumber;
        }

        public static byte GetInstructionNumberB2(ushort instructionValue)
        {
            var binaryStringRepresentation = Utilities.GetBinaryStringRepresentation(instructionValue, 16);
            var instructionNumberBits = binaryStringRepresentation.GetBitsFromSpecifiedPositions(12, 6);
            var instructionNumber = (byte)Utilities.GetValueFromBinaryStringRepresentation(instructionNumberBits);

            return instructionNumber;
        }

        public static byte GetInstructionNumberB3(ushort instructionValue)
        {
            var binaryStringRepresentation = Utilities.GetBinaryStringRepresentation(instructionValue, 16);
            var instructionNumberBits = binaryStringRepresentation.GetBitsFromSpecifiedPositions(12, 8);
            var instructionNumber = (byte)Utilities.GetValueFromBinaryStringRepresentation(instructionNumberBits);

            return instructionNumber;
        }

        public static byte GetInstructionNumberB4(ushort instructionValue)
        {
            var binaryStringRepresentation = Utilities.GetBinaryStringRepresentation(instructionValue, 16);
            var instructionNumberBits = binaryStringRepresentation.GetBitsFromSpecifiedPositions(12, 0);
            var instructionNumber = (byte)Utilities.GetValueFromBinaryStringRepresentation(instructionNumberBits);

            return instructionNumber;
        }

        public static byte GetRegisterNumberSourceB1(ushort instructionValue)
        {
            var binaryStringRepresentation = Utilities.GetBinaryStringRepresentation(instructionValue, 16);
            var instructionNumberBits = binaryStringRepresentation.GetBitsFromSpecifiedPositions(9, 6);
            var registerNumber = (byte)Utilities.GetValueFromBinaryStringRepresentation(instructionNumberBits);

            return registerNumber;
        }

        public static byte GetRegisterNumberDestinationB1(ushort instructionValue)
        {
            var binaryStringRepresentation = Utilities.GetBinaryStringRepresentation(instructionValue, 16);
            var instructionNumberBits = binaryStringRepresentation.GetBitsFromSpecifiedPositions(3, 0);
            var registerNumber = (byte)Utilities.GetValueFromBinaryStringRepresentation(instructionNumberBits);

            return registerNumber;
        }

        public static byte GetRegisterNumberDestinationB2(ushort instructionValue)
        {
            var binaryStringRepresentation = Utilities.GetBinaryStringRepresentation(instructionValue, 16);
            var instructionNumberBits = binaryStringRepresentation.GetBitsFromSpecifiedPositions(3, 0);
            var registerNumber = (byte)Utilities.GetValueFromBinaryStringRepresentation(instructionNumberBits);

            return registerNumber;
        }
    }
}
