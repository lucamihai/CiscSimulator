using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Sequencer.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Sequencer.UnitTests.SequencerUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SequencerInitializationUnitTests
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
        public void FlagRegisterIsInitialized()
        {
            Assert.IsNotNull(sequencer.FlagRegister);
        }

        [TestMethod]
        public void TemporaryRegisterIsInitialized()
        {
            Assert.IsNotNull(sequencer.TemporaryRegister);
        }

        [TestMethod]
        public void IVRIsInitialized()
        {
            Assert.IsNotNull(sequencer.IVR);
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
    }
}
