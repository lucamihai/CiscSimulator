using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Assembler.Interfaces;
using CiscSimulator.Sequencer.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Sequencer.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SequencerUnitTests
    {
        private Sequencer sequencer;

        [TestInitialize]
        public void Setup()
        {
            sequencer = new Sequencer();
        }

        [TestMethod]
        public void MemoryIsInitialized()
        {
            Assert.IsNotNull(sequencer.Memory);
        }

        [TestMethod]
        public void MpmMemoryIsInitialized()
        {
            Assert.IsNotNull(sequencer.MpmMemory);
        }

        [TestMethod]
        public void GeneralRegistersObjectIsInitialized()
        {
            Assert.IsNotNull(sequencer.GeneralRegisters);
        }

        [TestMethod]
        public void MemoryAddressRegisterIsInitialized()
        {
            Assert.IsNotNull(sequencer.MemoryAddressRegister);
        }

        [TestMethod]
        public void MpmMemoryInstructionRegisterIsInitialized()
        {
            Assert.IsNotNull(sequencer.MemoryInstructionRegister);
        }

        [TestMethod]
        public void SBusIsInitialized()
        {
            Assert.IsNotNull(sequencer.SBus);
        }

        [TestMethod]
        public void DBusIsInitialized()
        {
            Assert.IsNotNull(sequencer.DBus);
        }

        [TestMethod]
        public void RBusIsInitialized()
        {
            Assert.IsNotNull(sequencer.RBus);
        }

        [TestMethod]
        public void ArithmeticLogicUnitIsInitialized()
        {
            Assert.IsNotNull(sequencer.ArithmeticLogicUnit);
        }

        [TestMethod]
        public void StepIsInitialedToFetch()
        {
            Assert.AreEqual(Step.Fetch, sequencer.Step);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadInstructionsInMemoryThrowsArgumentNullExceptionForNullInstructionList()
        {
            sequencer.LoadInstructionsInMemory(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LoadInstructionsInMemoryThrowsArgumentExceptionForEmptyInstructionList()
        {
            sequencer.LoadInstructionsInMemory(new List<IInstruction>());
        }

        [TestMethod]
        public void LoadInstructionsInMemoryLoadsExpectedDataInMemory()
        {
            var instructionList = Constants.InstructionList1;
            sequencer.LoadInstructionsInMemory(instructionList);

            var address = CiscSimulator.Sequencer.Constants.MemoryInstructionStartAddress;
            foreach (var instruction in instructionList)
            {
                foreach (var instructionData in instruction.Data)
                {
                    var instructionMemory = sequencer.Memory[address];
                    address++;

                    Assert.AreEqual(instructionData, instructionMemory);
                }
            }
        }

        [TestMethod]
        public void LoadInstructionsInMemoryClearsDataFromPreviouslyLoadedInstructionsTest()
        {
            var address = CiscSimulator.Sequencer.Constants.MemoryInstructionStartAddress;
            address++;

            sequencer.LoadInstructionsInMemory(Constants.InstructionList1);

            // instruction list contains more than 1 instruction
            // so memory[address + 1] should contain value > 0
            Assert.IsTrue(sequencer.Memory[address].Value > 0);

            sequencer.LoadInstructionsInMemory(Constants.InstructionList2);

            // instruction list should contain 1 instruction with 1 data entry
            // so memory[address + 1] should contain value = 0
            Assert.AreEqual(sequencer.Memory[address].Value, 0);
        }

        [TestMethod]
        public void NextStepSetsStepToExecuteIfItWasSetToFetch()
        {
            Assert.AreEqual(Step.Fetch, sequencer.Step);

            sequencer.NextStep();

            Assert.AreEqual(Step.Execute, sequencer.Step);
        }

        [TestMethod]
        public void NextStepSetsStepToFetchIfItWasSetToExecute()
        {
            sequencer.NextStep();
            Assert.AreEqual(Step.Execute, sequencer.Step);

            sequencer.NextStep();

            Assert.AreEqual(Step.Fetch, sequencer.Step);
        }
    }
}
