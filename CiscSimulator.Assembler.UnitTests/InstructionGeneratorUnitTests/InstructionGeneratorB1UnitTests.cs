using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Assembler.UnitTests.InstructionGeneratorUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class InstructionGeneratorB1UnitTests
    {
        private InstructionGenerator instructionGenerator;

        [TestInitialize]
        public void Setup()
        {
            instructionGenerator = new InstructionGenerator();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GenerateInstructionFromLineThrowsInvalidOperationExceptionForB1InstructionWithDestinationImmediateValue()
        {
            instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB1WithDestinationImmediateValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateInstructionFromLineThrowsArgumentExceptionForB1InstructionWithTooFewArguments()
        {
            instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB1WithTooFewArguments);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateInstructionFromLineThrowsArgumentExceptionForB1InstructionWithTooManyArguments()
        {
            instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB1WithTooManyArguments);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsExpectedB1Instruction1()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB1Valid1);
            var b1Instruction = instruction as B1Instruction;

            Assert.IsNotNull(b1Instruction);

            Assert.AreEqual(Constants.InstructionB1ExpectedDestinationAddressMode1, b1Instruction.DestinationAddressMode);
            Assert.AreEqual(Constants.InstructionB1ExpectedSourceAddressMode1, b1Instruction.SourceAddressMode);

            Assert.AreEqual(Constants.InstructionB1ExpectedDestination1, b1Instruction.Destination);
            Assert.AreEqual(Constants.InstructionB1ExpectedSource1, b1Instruction.Source);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsExpectedB2Instruction2()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB1Valid2);
            var b1Instruction = instruction as B1Instruction;

            Assert.IsNotNull(b1Instruction);
            
            Assert.AreEqual(Constants.InstructionB1ExpectedDestinationAddressMode2, b1Instruction.DestinationAddressMode);
            Assert.AreEqual(Constants.InstructionB1ExpectedSourceAddressMode2, b1Instruction.SourceAddressMode);

            Assert.AreEqual(Constants.InstructionB1ExpectedDestination2, b1Instruction.Destination);
            Assert.AreEqual(Constants.InstructionB1ExpectedSource2, b1Instruction.Source);
        }

    }
}
