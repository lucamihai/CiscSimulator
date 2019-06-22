﻿using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Sequencer.Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Sequencer.UnitTests.MethodsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MemoryOperationsMethodsUnitTests
    {
        private Sequencer sequencer;

        [TestInitialize]
        public void Setup()
        {
            sequencer = new Sequencer();

            sequencer.Memory[Constants.MemoryAddress1].Value = Constants.MemoryValue1;
            sequencer.Memory[Constants.MemoryAddress2].Value = Constants.MemoryValue2;

            sequencer.Memory[Constants.MemoryInstructionAddress1].Value = Constants.MemoryInstructionValue1;
            sequencer.Memory[Constants.MemoryInstructionAddress2].Value = Constants.MemoryInstructionValue2;
        }

        [TestMethod]
        public void IfChLoadsInstructionRegisterWithValueFoundInMemoryAtProgramCounter1()
        {
            sequencer.ProgramCounterRegister.Data.Value = Constants.MemoryInstructionAddress1;

            MemoryOperationsMethods.IfCh(sequencer);

            Assert.AreEqual(Constants.MemoryInstructionValue1, sequencer.InstructionRegister.Data.Value);
        }

        [TestMethod]
        public void IfChLoadsInstructionRegisterWithValueFoundInMemoryAtProgramCounter2()
        {
            sequencer.ProgramCounterRegister.Data.Value = Constants.MemoryInstructionAddress2;

            MemoryOperationsMethods.IfCh(sequencer);

            Assert.AreEqual(Constants.MemoryInstructionValue2, sequencer.InstructionRegister.Data.Value);
        }

        [TestMethod]
        public void ReadLoadsMemoryDataRegisterWithValueFoundInMemoryAtMemoryAddressRegister1()
        {
            sequencer.MemoryAddressRegister.Data.Value = Constants.MemoryAddress1;

            MemoryOperationsMethods.Read(sequencer);

            Assert.AreEqual(Constants.MemoryValue1, sequencer.MemoryDataRegister.Data.Value);
        }

        [TestMethod]
        public void ReadLoadsMemoryDataRegisterWithValueFoundInMemoryAtMemoryAddressRegister2()
        {
            sequencer.MemoryAddressRegister.Data.Value = Constants.MemoryAddress2;

            MemoryOperationsMethods.Read(sequencer);

            Assert.AreEqual(Constants.MemoryValue2, sequencer.MemoryDataRegister.Data.Value);
        }

        [TestMethod]
        public void WriteLoadsInMemoryAtMemoryAddressRegisterValueFoundInMemoryDataRegister1()
        {
            sequencer.MemoryAddressRegister.Data.Value = Constants.MemoryAddress1;
            sequencer.MemoryDataRegister.Data.Value = Constants.ValueToWrite1;

            MemoryOperationsMethods.Write(sequencer);

            Assert.AreEqual(Constants.ValueToWrite1, sequencer.Memory[sequencer.MemoryAddressRegister.Data.Value].Value);
        }

        [TestMethod]
        public void WriteLoadsInMemoryAtMemoryAddressRegisterValueFoundInMemoryDataRegister2()
        {
            sequencer.MemoryAddressRegister.Data.Value = Constants.MemoryAddress2;
            sequencer.MemoryDataRegister.Data.Value = Constants.ValueToWrite2;

            MemoryOperationsMethods.Write(sequencer);

            Assert.AreEqual(Constants.ValueToWrite2, sequencer.Memory[sequencer.MemoryAddressRegister.Data.Value].Value);
        }
    }
}
