using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Assembler.UnitTests
{
    [TestClass]
    public class InstructionGeneratorUnitTests
    {
        private InstructionGenerator instructionGenerator;

        private const string LineInstructionB1WithDestinationImmediateValue = "add 10, r1";

        private const string LineInstructionB1WithTooFewArguments = "add r0";
        private const string LineInstructionB1WithTooManyArguments = "add r0, r1, r2";

        private const string LineInstructionAddR0ImmediateValue2 = "add r0, 2";
        private const string LineInstructionAddR0R1 = "add r0, r1";


        [TestInitialize]
        public void Setup()
        {
            instructionGenerator = new InstructionGenerator();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GenerateInstructionFromLineThrowsInvalidOperationExceptionForB1InstructionWithDestinationImmediateValue()
        {
            var instruction =
                instructionGenerator.GenerateInstructionFromLine(LineInstructionB1WithDestinationImmediateValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateInstructionFromLineThrowsArgumentExceptionForB1InstructionWithTooFewArguments()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(LineInstructionB1WithTooFewArguments);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateInstructionFromLineThrowsArgumentExceptionForB1InstructionWithTooManyArguments()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(LineInstructionB1WithTooManyArguments);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsExpectedInstruction1()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(LineInstructionAddR0ImmediateValue2);
            var instructionIsB1 = instruction is B1Instruction;
            Assert.AreEqual(true, instructionIsB1);

            if (instructionIsB1)
            {
                var b1Instruction = instruction as B1Instruction;

                Assert.AreEqual(AddressMode.Direct, b1Instruction.DestinationAddressMode);
                Assert.AreEqual(AddressMode.Immediate, b1Instruction.SourceAddressMode);

                Assert.AreEqual(0, b1Instruction.Destination);
                Assert.AreEqual(2, b1Instruction.Source);
            }
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsExpectedInstruction2()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(LineInstructionAddR0R1);
            var instructionIsB1 = instruction is B1Instruction;
            Assert.AreEqual(true, instructionIsB1);

            if (instructionIsB1)
            {
                var b1Instruction = instruction as B1Instruction;

                Assert.AreEqual(AddressMode.Direct, b1Instruction.DestinationAddressMode);
                Assert.AreEqual(AddressMode.Direct, b1Instruction.SourceAddressMode);

                Assert.AreEqual(0, b1Instruction.Destination);
                Assert.AreEqual(1, b1Instruction.Source);
            }
        }
    }
}
