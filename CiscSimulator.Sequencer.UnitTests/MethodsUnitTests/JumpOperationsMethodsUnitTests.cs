using System;
using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Sequencer.Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Sequencer.UnitTests.MethodsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class JumpOperationsMethodsUnitTests
    {
        private Sequencer sequencer;

        [TestInitialize]
        public void Setup()
        {
            sequencer = new Sequencer();
        }

        [TestMethod]
        public void StepIncrementsMpmAddressRegisterValue()
        {
            var mpmAddressRegisterValueBeforeStep = sequencer.MpmAddressRegister.Data.Value;
            JumpOperationsMethods.Step(sequencer);
            var mpmAddressRegisterValueAfterStep = sequencer.MpmAddressRegister.Data.Value;

            Assert.AreEqual(mpmAddressRegisterValueBeforeStep + 1, mpmAddressRegisterValueAfterStep);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void JumpThrowsNotImplementedException()
        {
            JumpOperationsMethods.Jump(sequencer);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void JumpIThrowsNotImplementedException()
        {
            JumpOperationsMethods.JumpI(sequencer);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void B1ThrowsNotImplementedException()
        {
            JumpOperationsMethods.B1(sequencer);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void AdThrowsNotImplementedException()
        {
            JumpOperationsMethods.Ad(sequencer);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ZThrowsNotImplementedException()
        {
            JumpOperationsMethods.Z(sequencer);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CThrowsNotImplementedException()
        {
            JumpOperationsMethods.C(sequencer);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void VThrowsNotImplementedException()
        {
            JumpOperationsMethods.V(sequencer);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void SThrowsNotImplementedException()
        {
            JumpOperationsMethods.S(sequencer);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void IntrThrowsNotImplementedException()
        {
            JumpOperationsMethods.Intr(sequencer);
        }
    }
}
