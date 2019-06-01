using System;
using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Memory.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MemoryUnitTests
    {
        private Memory memory;

        [TestInitialize]
        public void Initialize()
        {
            memory = new Memory();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetDataThrowsArgumentExceptionForAddressTooSmall()
        {
            var addressTooSmall = (Data)CiscSimulator.Memory.Constants.MinimumAddress.Clone();
            addressTooSmall.LoByte--;

            var data = memory[addressTooSmall.Value];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetDataThrowsArgumentExceptionForAddressTooBig()
        {
            var addressTooBig = (Data)CiscSimulator.Memory.Constants.MaximumAddress.Clone();
            addressTooBig.LoByte++;

            var data = memory[addressTooBig.Value];
        }

        [TestMethod]
        public void GetDataDoesNotThrowAnyExceptionsForValidAddress()
        {
            var address = (Data)CiscSimulator.Memory.Constants.MinimumAddress.Clone();
            address.LoByte++;

            var data = memory[address.Value];
        }
    }
}
