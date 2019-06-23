using System;
using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Sequencer.Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Sequencer.UnitTests.MethodsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SBusOperationsMethodsUnitTests
    {
        private Sequencer sequencer;

        [TestInitialize]
        public void Setup()
        {
            sequencer = new Sequencer();
        }

        [TestMethod]
        public void Pd0PutsValue0ToSBus()
        {
            SBusOperationsMethods.Pd0(sequencer);

            Assert.AreEqual(0, sequencer.SBus.Data.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void PdRgThrowsNotImplementedException()
        {
            SBusOperationsMethods.PdRg(sequencer);
        }

        [TestMethod]
        public void PdIrPutsValueFromInstructionRegisterToSBus()
        {
            sequencer.InstructionRegister.Data.Value = Constants.Value1;

            SBusOperationsMethods.PdIr(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.SBus.Data.Value);
        }

        [TestMethod]
        public void PdMdrPutsValueFromMemoryDataRegisterToSBus()
        {
            sequencer.MemoryDataRegister.Data.Value = Constants.Value1;

            SBusOperationsMethods.PdMdr(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.SBus.Data.Value);
        }

        [TestMethod]
        public void PdSpPutsValueFromStackPointerRegisterToSBus()
        {
            sequencer.StackPointerRegister.Data.Value = Constants.Value1;

            SBusOperationsMethods.PdSp(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.SBus.Data.Value);
        }

        [TestMethod]
        public void PdAdrPutsValueFromMemoryAddressRegisterToSBus()
        {
            sequencer.MpmAddressRegister.Data.Value = Constants.Value1;

            SBusOperationsMethods.PdAdr(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.SBus.Data.Value);
        }

        [TestMethod]
        public void PdTPutsValueFromTemporaryRegisterToSBus()
        {
            sequencer.TemporaryRegister.Data.Value = Constants.Value1;

            SBusOperationsMethods.PdT(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.SBus.Data.Value);
        }

        [TestMethod]
        public void PdPcPutsValueFromProgramCounterRegisterToSBus()
        {
            sequencer.ProgramCounterRegister.Data.Value = Constants.Value1;

            SBusOperationsMethods.PdPc(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.SBus.Data.Value);
        }

        [TestMethod]
        public void PdIvrPutsValueFromInterruptVectorRegisterToSBus()
        {
            sequencer.InterruptVectorRegister.Data.Value = Constants.Value1;

            SBusOperationsMethods.PdIvr(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.SBus.Data.Value);
        }

        [TestMethod]
        public void PdFlagPutsValueFromFlagRegisterToSBus()
        {
            sequencer.FlagRegister.Data.Value = Constants.Value1;

            SBusOperationsMethods.PdFlag(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.SBus.Data.Value);
        }

        [TestMethod]
        public void Pd1PositivePutsValue1ToSBus()
        {
            SBusOperationsMethods.Pd1Positive(sequencer);

            Assert.AreEqual(1, sequencer.SBus.Data.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Pd1NegativeThrowsNotImplementedException()
        {
            SBusOperationsMethods.Pd1Negative(sequencer);
        }
    }
}
