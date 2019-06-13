using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Sequencer.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MpmMemoryUnitTests
    {
        private MpmMemory mpmMemory;

        [TestInitialize]
        public void Setup()
        {
            mpmMemory = new MpmMemory();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MpmDataGetterThrowsInvalidOperationExceptionForAddressTooSmall()
        {
            var mpmData = mpmMemory[mpmMemory.MinimumAddress - 1];
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MpmDataGetterThrowsInvalidOperationExceptionForAddressTooBig()
        {
            var mpmData = mpmMemory[mpmMemory.MaximumAddress + 1];
        }

        [TestMethod]
        public void MpmDataEntriesAreNotNull()
        {
            for (int address = mpmMemory.MinimumAddress; address <= mpmMemory.MaximumAddress; address++)
            {
                Assert.IsNotNull(mpmMemory[address]);
            }
        }
    }
}
