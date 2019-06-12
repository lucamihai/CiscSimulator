using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Sequencer.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MpmDataUnitTests
    {
        private MpmData mpmData;

        [TestInitialize]
        public void Setup()
        {
            mpmData = new MpmData
            {
                SBusOperation = Constants.SBusOperation,
                DBusOperation = Constants.DBusOperation,
                AluOperator = Constants.AluOperator,
                RBusOperation = Constants.RBusOperation,
                OtherOperation = Constants.OtherOperation,
                MemoryOperation = Constants.MemoryOperation,
                JumpOperation = Constants.JumpOperation,
                JumpLocation = Constants.JumpLocation,
                JumpIndex = Constants.JumpIndex
            };
        }

        [TestMethod]
        public void SBusOperationGetterReturnsExpectedValue()
        {
            Assert.AreEqual(Constants.SBusOperation, mpmData.SBusOperation);
        }

        [TestMethod]
        public void DBusOperationGetterReturnsExpectedValue()
        {
            Assert.AreEqual(Constants.DBusOperation, mpmData.DBusOperation);
        }

        [TestMethod]
        public void AluOperatorGetterReturnsExpectedValue()
        {
            Assert.AreEqual(Constants.AluOperator, mpmData.AluOperator);
        }

        [TestMethod]
        public void RBusOperationGetterReturnsExpectedValue()
        {
            Assert.AreEqual(Constants.RBusOperation, mpmData.RBusOperation);
        }

        [TestMethod]
        public void OtherOperationGetterReturnsExpectedValue()
        {
            Assert.AreEqual(Constants.OtherOperation, mpmData.OtherOperation);
        }

        [TestMethod]
        public void MemoryOperationGetterReturnsExpectedValue()
        {
            Assert.AreEqual(Constants.MemoryOperation, mpmData.MemoryOperation);
        }

        [TestMethod]
        public void JumpOperationGetterReturnsExpectedValue()
        {
            Assert.AreEqual(Constants.JumpOperation, mpmData.JumpOperation);
        }

        [TestMethod]
        public void JumpLocationGetterReturnsExpectedValue()
        {
            Assert.AreEqual(Constants.JumpLocation, mpmData.JumpLocation);
        }

        [TestMethod]
        public void JumpIndexGetterReturnsExpectedValue()
        {
            Assert.AreEqual(Constants.JumpIndex, mpmData.JumpIndex);
        }
    }
}
