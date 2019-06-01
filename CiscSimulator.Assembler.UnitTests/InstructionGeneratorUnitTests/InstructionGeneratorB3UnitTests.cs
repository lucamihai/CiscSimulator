using System;
using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Assembler.Instructions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Assembler.UnitTests.InstructionGeneratorUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class InstructionGeneratorB3UnitTests
    {
        private InstructionGenerator instructionGenerator;

        [TestInitialize]
        public void Setup()
        {
            instructionGenerator = new InstructionGenerator();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateInstructionFromLineThrowsArgumentExceptionForLineInstructionB3WithTooFewArguments()
        {
            instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB3WithTooFewArguments);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateInstructionFromLineThrowsArgumentExceptionForLineInstructionB3WithTooManyArguments()
        {
            instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB3WithTooManyArguments);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnExpectedB3Instruction()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB3Valid1);
            var b3Instruction = instruction as B3Instruction;

            Assert.IsNotNull(b3Instruction);
            Assert.AreEqual(Constants.InstructionB3ExpectedInstructionNumber1, b3Instruction.InstructionNumber);
            Assert.AreEqual(Constants.InstructionB3ExpectedOffset1, b3Instruction.Offset);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsB3InstructionWithExpectedNumberOfDataElements1()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB3Valid1);
            var b3Instruction = instruction as B3Instruction;

            Assert.IsNotNull(b3Instruction);

            Assert.AreEqual(Constants.InstructionB3ExpectedDataList1.Count, instruction.Data.Count);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsB3InstructionWithExpectedDataList1()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB3Valid1);
            var b3Instruction = instruction as B3Instruction;

            Assert.IsNotNull(b3Instruction);

            var expectedDataList = Constants.InstructionB3ExpectedDataList1;
            Assert.IsTrue(Methods.DataListsAreTheSame(expectedDataList, b3Instruction.Data));
        }
    }
}
