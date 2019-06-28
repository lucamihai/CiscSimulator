using System;
using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.GeneralRegisters.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class GeneralRegistersUnitTests
    {
        private GeneralRegisters generalRegisters;

        [TestInitialize]
        public void Setup()
        {
            generalRegisters = new GeneralRegisters();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UsingRegisterNumberTooSmallThrowsArgumentException()
        {
            var register = generalRegisters[Constants.MinimumRegisterNumber - 1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UsingRegisterNumberTooBigThrowsArgumentException()
        {
            var register = generalRegisters[Constants.MaximumRegisterNumber + 1];
        }

        [TestMethod]
        public void UsingValidRegisterNumberDoesNotThrowAnyExceptions()
        {
            var register = generalRegisters[Constants.MinimumRegisterNumber + 1];
        }

        [TestMethod]
        public void AllRegistersAreInitialized()
        {
            for (int registerNumber = Constants.MinimumRegisterNumber; registerNumber <= Constants.MaximumRegisterNumber; registerNumber++)
            {
                Assert.IsNotNull(generalRegisters[registerNumber]);
            }
        }

        [TestMethod]
        public void AllRegistersHaveExpectedDataValue()
        {
            for (int registerNumber = Constants.MinimumRegisterNumber; registerNumber <= Constants.MaximumRegisterNumber; registerNumber++)
            {
                var expectedDataValue = registerNumber;
                Assert.AreEqual(expectedDataValue, generalRegisters[registerNumber].Data.Value);
            }
        }

        [TestMethod]
        public void RegisterPropertiesPointToExpectedRegisters()
        {
            Assert.AreEqual(generalRegisters.R0, generalRegisters[0]);
            Assert.AreEqual(generalRegisters.R1, generalRegisters[1]);
            Assert.AreEqual(generalRegisters.R2, generalRegisters[2]);
            Assert.AreEqual(generalRegisters.R3, generalRegisters[3]);
            Assert.AreEqual(generalRegisters.R4, generalRegisters[4]);
            Assert.AreEqual(generalRegisters.R5, generalRegisters[5]);
            Assert.AreEqual(generalRegisters.R6, generalRegisters[6]);
            Assert.AreEqual(generalRegisters.R7, generalRegisters[7]);
            Assert.AreEqual(generalRegisters.R8, generalRegisters[8]);
            Assert.AreEqual(generalRegisters.R9, generalRegisters[9]);
            Assert.AreEqual(generalRegisters.R10, generalRegisters[10]);
            Assert.AreEqual(generalRegisters.R11, generalRegisters[11]);
            Assert.AreEqual(generalRegisters.R12, generalRegisters[12]);
            Assert.AreEqual(generalRegisters.R13, generalRegisters[13]);
            Assert.AreEqual(generalRegisters.R14, generalRegisters[14]);
            Assert.AreEqual(generalRegisters.R15, generalRegisters[15]);
        }

        [TestMethod]
        public void UpdatingValueDisplayModeWillUpdateValueDisplayModeForEveryRegister()
        {
            generalRegisters.ValueDisplayMode = ValueDisplayMode.Hexadecimal;

            for (int registerNumber = Constants.MinimumRegisterNumber; registerNumber <= Constants.MaximumRegisterNumber; registerNumber++)
            {
                Assert.AreEqual(ValueDisplayMode.Hexadecimal, generalRegisters[registerNumber].ValueDisplayMode);
            }
        }
    }
}
