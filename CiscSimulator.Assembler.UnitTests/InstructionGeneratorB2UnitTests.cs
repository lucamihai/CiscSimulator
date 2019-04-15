using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Assembler.UnitTests
{
    [TestClass]
    public class InstructionGeneratorB2UnitTests
    {
        private InstructionGenerator instructionGenerator;

        private const string LineInstructionB2WithTooFewArguments = "inc";
        private const string LineInstructionB2WithTooManyArguments = "inc r0, r1";
        private const string LineInstructionIncR1 = "inc r1";
        private const string LineInstructionAslIndirectR2 = "asl (r2)";

        [TestInitialize]
        public void Setup()
        {
            instructionGenerator = new InstructionGenerator();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateInstructionFromLineThrowsArgumentExceptionForB2InstructionWithTooFewArguments()
        {
            var instruction =
                instructionGenerator.GenerateInstructionFromLine(LineInstructionB2WithTooFewArguments);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateInstructionFromLineThrowsArgumentExceptionForB2InstructionWithTooManyArguments()
        {
            var instruction =
                instructionGenerator.GenerateInstructionFromLine(LineInstructionB2WithTooManyArguments);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsExpectedB2Instruction1()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(LineInstructionIncR1);
            var instructionIsB2 = instruction is B2Instruction;
            Assert.AreEqual(true, instructionIsB2);

            if (instructionIsB2)
            {
                var b1Instruction = instruction as B2Instruction;

                Assert.AreEqual(AddressMode.Direct, b1Instruction.AddressMode);
                Assert.AreEqual(1, b1Instruction.Value);
            }
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsExpectedB2Instruction2()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(LineInstructionAslIndirectR2);
            var instructionIsB2 = instruction is B2Instruction;
            Assert.AreEqual(true, instructionIsB2);

            if (instructionIsB2)
            {
                var b1Instruction = instruction as B2Instruction;

                Assert.AreEqual(AddressMode.Indirect, b1Instruction.AddressMode);
                Assert.AreEqual(2, b1Instruction.Value);
            }
        }
    }
}
