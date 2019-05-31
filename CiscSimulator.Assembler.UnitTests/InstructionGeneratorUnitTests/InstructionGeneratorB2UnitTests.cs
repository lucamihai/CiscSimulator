﻿using System;
using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Assembler.Instructions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Assembler.UnitTests.InstructionGeneratorUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class InstructionGeneratorB2UnitTests
    {
        private InstructionGenerator instructionGenerator;

        [TestInitialize]
        public void Setup()
        {
            instructionGenerator = new InstructionGenerator();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateInstructionFromLineThrowsArgumentExceptionForB2InstructionWithTooFewArguments()
        {
            instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB2WithTooFewArguments);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateInstructionFromLineThrowsArgumentExceptionForB2InstructionWithTooManyArguments()
        {
            instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB2WithTooManyArguments);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsExpectedB2Instruction1()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB2Valid1);
            var b2Instruction = instruction as B2Instruction;

            Assert.IsNotNull(b2Instruction);
            Assert.AreEqual(Constants.InstructionB2ExpectedInstructionNumber1, b2Instruction.InstructionNumber);
            Assert.AreEqual(Constants.InstructionB2ExpectedAddressMode1, b2Instruction.AddressMode);
            Assert.AreEqual(Constants.InstructionB2ExpectedValue1, b2Instruction.Value);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsExpectedB2Instruction2()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionB2Valid2);
            var b2Instruction = instruction as B2Instruction;

            Assert.IsNotNull(b2Instruction);
            Assert.AreEqual(Constants.InstructionB2ExpectedInstructionNumber2, b2Instruction.InstructionNumber);
            Assert.AreEqual(Constants.InstructionB2ExpectedAddressMode2, b2Instruction.AddressMode);
            Assert.AreEqual(Constants.InstructionB2ExpectedValue2, b2Instruction.Value);
        }
    }
}
