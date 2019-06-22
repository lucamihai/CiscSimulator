using System;
using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Sequencer.Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Sequencer.UnitTests.MethodsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DBusOperationsMethodsUnitTests
    {
        private Sequencer sequencer;

        [TestInitialize]
        public void Setup()
        {
            sequencer = new Sequencer();
        }

        [TestMethod]
        public void Pd0PutsValue0ToDBus()
        {
            DBusOperationsMethods.Pd0(sequencer);

            Assert.AreEqual(0, sequencer.DBus.Data.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void PdRgThrowsNotImplementedException()
        {
            DBusOperationsMethods.PdRg(sequencer);
        }

        [TestMethod]
        public void PdIrPutsValueFromInstructionRegisterToDBus()
        {
            sequencer.InstructionRegister.Data.Value = Constants.Value1;

            DBusOperationsMethods.PdIr(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.DBus.Data.Value);
        }

        [TestMethod]
        public void PdMdrPutsValueFromMemoryDataRegisterToDBus()
        {
            sequencer.MemoryDataRegister.Data.Value = Constants.Value1;

            DBusOperationsMethods.PdMdr(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.DBus.Data.Value);
        }

        [TestMethod]
        public void PdSpPutsValueFromStackPointerRegisterToDBus()
        {
            sequencer.StackPointerRegister.Data.Value = Constants.Value1;

            DBusOperationsMethods.PdSp(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.DBus.Data.Value);
        }

        [TestMethod]
        public void PdAdrPutsValueFromMemoryAddressRegisterToDBus()
        {
            sequencer.MemoryAddressRegister.Data.Value = Constants.Value1;

            DBusOperationsMethods.PdAdr(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.DBus.Data.Value);
        }

        [TestMethod]
        public void PdTPutsValueFromTemporaryRegisterToDBus()
        {
            sequencer.TemporaryRegister.Data.Value = Constants.Value1;

            DBusOperationsMethods.PdT(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.DBus.Data.Value);
        }

        [TestMethod]
        public void PdPcPutsValueFromProgramCounterRegisterToDBus()
        {
            sequencer.ProgramCounterRegister.Data.Value = Constants.Value1;

            DBusOperationsMethods.PdPc(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.DBus.Data.Value);
        }

        [TestMethod]
        public void PdIvrPutsValueFromInterruptVectorRegisterToDBus()
        {
            sequencer.InterruptVectorRegister.Data.Value = Constants.Value1;

            DBusOperationsMethods.PdIvr(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.DBus.Data.Value);
        }

        [TestMethod]
        public void PdFlagPutsValueFromFlagRegisterToDBus()
        {
            sequencer.FlagRegister.Data.Value = Constants.Value1;

            DBusOperationsMethods.PdFlag(sequencer);

            Assert.AreEqual(Constants.Value1, sequencer.DBus.Data.Value);
        }

        [TestMethod]
        public void Pd1PositivePutsValue1ToDBus()
        {
            DBusOperationsMethods.Pd1Positive(sequencer);

            Assert.AreEqual(1, sequencer.DBus.Data.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Pd1NegativeThrowsNotImplementedException()
        {
            DBusOperationsMethods.Pd1Negative(sequencer);
        }
    }
}
