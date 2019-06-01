using System;
using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Assembler.Instructions;
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

            Assert.AreEqual(Constants.InstructionB1ExpectedInstructionNumber1, b1Instruction.InstructionNumber);

            Assert.AreEqual(Constants.InstructionB1ExpectedDestinationAddressMode1, b1Instruction.DestinationAddressMode);
            Assert.AreEqual(Constants.InstructionB1ExpectedSourceAddressMode1, b1Instruction.SourceAddressMode);

            Assert.AreEqual(Constants.InstructionB1ExpectedDestination1, b1Instruction.Destination.Value);
            Assert.AreEqual(Constants.InstructionB1ExpectedSource1, b1Instruction.Source.Value);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsB1InstructionWithExpectedNumberOfDataElements1()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB1Valid1);
            var b1Instruction = instruction as B1Instruction;

            Assert.IsNotNull(b1Instruction);

            Assert.AreEqual(Constants.InstructionB1ExpectedDataList1.Count, instruction.Data.Count);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsB1InstructionWithExpectedDataList1()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB1Valid1);
            var b1Instruction = instruction as B1Instruction;

            Assert.IsNotNull(b1Instruction);

            var expectedDataList = Constants.InstructionB1ExpectedDataList1;
            Assert.IsTrue(Methods.DataListsAreTheSame(expectedDataList, b1Instruction.Data));
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsExpectedB2Instruction2()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB1Valid2);
            var b1Instruction = instruction as B1Instruction;

            Assert.IsNotNull(b1Instruction);

            Assert.AreEqual(Constants.InstructionB1ExpectedInstructionNumber2, b1Instruction.InstructionNumber);

            Assert.AreEqual(Constants.InstructionB1ExpectedDestinationAddressMode2, b1Instruction.DestinationAddressMode);
            Assert.AreEqual(Constants.InstructionB1ExpectedSourceAddressMode2, b1Instruction.SourceAddressMode);

            Assert.AreEqual(Constants.InstructionB1ExpectedDestination2, b1Instruction.Destination.Value);
            Assert.AreEqual(Constants.InstructionB1ExpectedSource2, b1Instruction.Source.Value);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsB1InstructionWithExpectedNumberOfDataElements2()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB1Valid2);
            var b1Instruction = instruction as B1Instruction;

            Assert.IsNotNull(b1Instruction);

            Assert.AreEqual(Constants.InstructionB1ExpectedDataList2.Count, instruction.Data.Count);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsB1InstructionWithExpectedDataList2()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB1Valid2);
            var b1Instruction = instruction as B1Instruction;

            Assert.IsNotNull(b1Instruction);

            var expectedDataList = Constants.InstructionB1ExpectedDataList2;
            Assert.IsTrue(Methods.DataListsAreTheSame(expectedDataList, b1Instruction.Data));
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsExpectedB2Instruction3()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB1Valid3);
            var b1Instruction = instruction as B1Instruction;

            Assert.IsNotNull(b1Instruction);

            Assert.AreEqual(Constants.InstructionB1ExpectedInstructionNumber3, b1Instruction.InstructionNumber);

            Assert.AreEqual(Constants.InstructionB1ExpectedDestinationAddressMode3, b1Instruction.DestinationAddressMode);
            Assert.AreEqual(Constants.InstructionB1ExpectedSourceAddressMode3, b1Instruction.SourceAddressMode);

            Assert.AreEqual(Constants.InstructionB1ExpectedDestination3, b1Instruction.Destination.Value);
            Assert.AreEqual(Constants.InstructionB1ExpectedSource3, b1Instruction.Source.Value);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsB1InstructionWithExpectedNumberOfDataElements3()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB1Valid3);
            var b1Instruction = instruction as B1Instruction;

            Assert.IsNotNull(b1Instruction);

            Assert.AreEqual(Constants.InstructionB1ExpectedDataList3.Count, instruction.Data.Count);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsB1InstructionWithExpectedDataList3()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB1Valid3);
            var b1Instruction = instruction as B1Instruction;

            Assert.IsNotNull(b1Instruction);

            var expectedDataList = Constants.InstructionB1ExpectedDataList3;
            Assert.IsTrue(Methods.DataListsAreTheSame(expectedDataList, b1Instruction.Data));
        }
    }
}
