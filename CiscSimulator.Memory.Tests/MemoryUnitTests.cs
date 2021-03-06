﻿using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Memory.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MemoryUnitTests
    {
        private Memory memory;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorThrowsArgumentExceptionForMinimumAddressEqualToMaximumAddress()
        {
            memory = new Memory(Constants.MinimumAddress, Constants.MinimumAddress);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorThrowsArgumentExceptionForMinimumAddressBiggerThanMaximumAddress()
        {
            memory = new Memory(Constants.MinimumAddress + 1, Constants.MinimumAddress);
        }

        [TestMethod]
        public void ConstructorDoesNotThrowArgumentExceptionForMinimumAddressSmallerThanMaximumAddress()
        {
            memory = new Memory(Constants.MinimumAddress, Constants.MaximumAddress);
        }

        [TestMethod]
        public void ConstructorWithReadOnlyFalseSetsEachDataReadOnlyToFalse()
        {
            memory = new Memory(Constants.MinimumAddress, Constants.MaximumAddress, Constants.ReadOnlyFalse);

            for (var address = Constants.MinimumAddress; address <= Constants.MaximumAddress; address++)
            {
                Assert.IsFalse(memory[address].ReadOnly);
            }
        }

        [TestMethod]
        public void ConstructorWithReadOnlyTrueSetsEachDataReadOnlyToTrue()
        {
            memory = new Memory(Constants.MinimumAddress, Constants.MaximumAddress, Constants.ReadOnlyTrue);

            for (var address = Constants.MinimumAddress; address <= Constants.MaximumAddress; address++)
            {
                Assert.IsTrue(memory[address].ReadOnly);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetDataThrowsArgumentExceptionForAddressTooSmall()
        {
            memory = new Memory(Constants.MinimumAddress, Constants.MaximumAddress);

            var addressTooSmall = Constants.MinimumAddress;
            addressTooSmall--;

            var data = memory[addressTooSmall];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetDataThrowsArgumentExceptionForAddressTooBig()
        {
            memory = new Memory(Constants.MinimumAddress, Constants.MaximumAddress);

            var addressTooBig = Constants.MaximumAddress;
            addressTooBig++;

            var data = memory[addressTooBig];
        }

        [TestMethod]
        public void GetDataDoesNotThrowAnyExceptionsForValidAddress()
        {
            memory = new Memory(Constants.MinimumAddress, Constants.MaximumAddress);

            var address = Constants.MinimumAddress;
            address++;

            var data = memory[address];
        }
    }
}
