using System;
using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Sequencer.Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Sequencer.UnitTests.MethodsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class RBusOperationsMethodsUnitTests
    {
        private Sequencer sequencer;

        [TestInitialize]
        public void Setup()
        {
            sequencer = new Sequencer();
            sequencer.RBus.Data.Value = Constants.Value1;
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void PmRgThrowsNotImplementedException()
        {
            RBusOperationsMethods.PmRg(sequencer);
        }

        [TestMethod]
        public void PmIrPutsValueFromRBusToInstructionRegister()
        {
            RBusOperationsMethods.PmIr(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.InstructionRegister.Data.Value);
        }

        [TestMethod]
        public void PmMdrPutsValueFromRBusToMemoryDataRegister()
        {
            RBusOperationsMethods.PmMdr(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.MemoryDataRegister.Data.Value);
        }

        [TestMethod]
        public void PmSpPutsValueFromRBusToStackPointerRegister()
        {
            RBusOperationsMethods.PmSp(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.StackPointerRegister.Data.Value);
        }

        [TestMethod]
        public void PmAdrPutsValueFromRBusToMemoryAddressRegister()
        {
            RBusOperationsMethods.PmAdr(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.MemoryAddressRegister.Data.Value);
        }

        [TestMethod]
        public void PmTPutsValueFromRBusToTemporaryRegister()
        {
            RBusOperationsMethods.PmT(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.TemporaryRegister.Data.Value);
        }

        [TestMethod]
        public void PmPcPutsValueFromRBusToProgramCounterRegister()
        {
            RBusOperationsMethods.PmPc(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.ProgramCounterRegister.Data.Value);
        }

        [TestMethod]
        public void PmIvrPutsValueFromRBusToInterruptVectorRegisterRegister()
        {
            RBusOperationsMethods.PmIvr(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.InterruptVectorRegister.Data.Value);
        }

        [TestMethod]
        public void PmFlagPutsValueFromRBusToFlagRegisterRegister()
        {
            RBusOperationsMethods.PmFlag(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.FlagRegister.Data.Value);
        }
    }
}
