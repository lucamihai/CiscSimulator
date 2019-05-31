using System;
using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Assembler.Instructions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Assembler.UnitTests.InstructionGeneratorUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class InstructionGeneratorB4UnitTests
    {
        private InstructionGenerator instructionGenerator;

        [TestInitialize]
        public void Setup()
        {
            instructionGenerator = new InstructionGenerator();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateInstructionFromLineThrowsArgumentExceptionForLineInstructionB4WithTooManyArguments()
        {
            instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB4WithTooManyArguments);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnExpectedB4Instruction1()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB4Valid1);
            var b4Instruction = instruction as B4Instruction;

            Assert.IsNotNull(b4Instruction);
            Assert.AreEqual(Constants.InstructionB4ExpectedInstructionNumber1, b4Instruction.InstructionNumber);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnExpectedB4Instruction2()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB4Valid2);
            var b4Instruction = instruction as B4Instruction;

            Assert.IsNotNull(b4Instruction);
            Assert.AreEqual(Constants.InstructionB4ExpectedInstructionNumber2, b4Instruction.InstructionNumber);
        }
    }
}
