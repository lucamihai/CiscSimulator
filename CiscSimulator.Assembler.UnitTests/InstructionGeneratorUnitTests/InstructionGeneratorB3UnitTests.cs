﻿using System;
using System.Diagnostics.CodeAnalysis;
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
            Assert.AreEqual(Constants.InstructionB3ExpectedOffset1, b3Instruction.Offset);
        }
    }
}
