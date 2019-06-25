using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Assembler.Instructions;
using CiscSimulator.Assembler.Interfaces;
using CiscSimulator.Common.Enums;
using CiscSimulator.Sequencer.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Sequencer.UnitTests.SequencerUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SequencerPublicMethodsUnitTests
    {
        private Sequencer sequencer;

        [TestInitialize]
        public void Setup()
        {
            sequencer = new Sequencer();
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
        [ExpectedException(typeof(ArgumentException))]
        public void LoadInstructionsInMemoryThrowsArgumentExceptionForInstructionListWithTooManyDataEntries()
        {
            var instructionList = new List<IInstruction>();
            var memoryEntryLimit = 1 + CiscSimulator.Sequencer.Constants.MemoryInstructionEndAddress - CiscSimulator.Sequencer.Constants.MemoryInstructionStartAddress;
            for (int i = 0; i < memoryEntryLimit + 1; i++)
            {
                instructionList.Add(new B4Instruction());
            }

            sequencer.LoadInstructionsInMemory(instructionList);
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

        [TestMethod]
        public void NextStepPutsMpmDataFoundInMpmMemoryAtAddressFromMpmAddressRegisterInMpmInstructionRegisterIfStepIsFetch()
        {
            Assert.AreEqual(Step.Fetch, sequencer.Step);

            var expectedMpmData = sequencer.MpmMemory[sequencer.MpmAddressRegister.Data.Value];
            sequencer.NextStep();

            Assert.AreEqual(expectedMpmData.Value, sequencer.MpmInstructionRegister.MpmData.Value);
        }

        [TestMethod]
        public void UpdatingValueDisplayModeWillUpdateValueDisplayModeForExpectedControls()
        {
            sequencer.ValueDisplayMode = ValueDisplayMode.Decimal;

            Assert.AreEqual(ValueDisplayMode.Decimal, sequencer.GeneralRegisters.ValueDisplayMode);
            Assert.AreEqual(ValueDisplayMode.Decimal, sequencer.MemoryAddressRegister.ValueDisplayMode);
            Assert.AreEqual(ValueDisplayMode.Decimal, sequencer.MemoryDataRegister.ValueDisplayMode);
            Assert.AreEqual(ValueDisplayMode.Decimal, sequencer.InstructionRegister.ValueDisplayMode);
            Assert.AreEqual(ValueDisplayMode.Decimal, sequencer.StackPointerRegister.ValueDisplayMode);
            Assert.AreEqual(ValueDisplayMode.Decimal, sequencer.TemporaryRegister.ValueDisplayMode);
            Assert.AreEqual(ValueDisplayMode.Decimal, sequencer.ProgramCounterRegister.ValueDisplayMode);
            Assert.AreEqual(ValueDisplayMode.Decimal, sequencer.InterruptVectorRegister.ValueDisplayMode);
            Assert.AreEqual(ValueDisplayMode.Decimal, sequencer.FlagRegister.ValueDisplayMode);

            Assert.AreEqual(ValueDisplayMode.Decimal, sequencer.SBus.ValueDisplayMode);
            Assert.AreEqual(ValueDisplayMode.Decimal, sequencer.DBus.ValueDisplayMode);
            Assert.AreEqual(ValueDisplayMode.Decimal, sequencer.RBus.ValueDisplayMode);

            Assert.AreEqual(ValueDisplayMode.Decimal, sequencer.MpmAddressRegister.ValueDisplayMode);
        }
    }
}
