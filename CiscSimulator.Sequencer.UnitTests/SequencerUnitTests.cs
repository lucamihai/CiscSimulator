using System.Diagnostics.CodeAnalysis;
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
