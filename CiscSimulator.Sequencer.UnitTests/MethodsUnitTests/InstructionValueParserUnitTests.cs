using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Sequencer.Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Sequencer.UnitTests.MethodsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class InstructionValueParserUnitTests
    {
        [TestMethod]
        public void GetInstructionClassReturnsExpectedInstructionClass1()
        {
            var instructionClass = InstructionValueParser.GetInstructionClass(Constants.InstructionValue1);

            Assert.AreEqual(Constants.ExpectedInstructionClass1, instructionClass);
        }

        [TestMethod]
        public void GetAddressModeSourceReturnsExpectedAddressMode1()
        {
            var addressMode = InstructionValueParser.GetAddressModeSource(Constants.InstructionValue1);

            Assert.AreEqual(Constants.ExpectedSourceAddressMode1, addressMode);
        }

        [TestMethod]
        public void GetAddressModeDestinationReturnsExpectedAddressMode1()
        {
            var addressMode = InstructionValueParser.GetAddressModeDestination(Constants.InstructionValue1);

            Assert.AreEqual(Constants.ExpectedDestinationAddressMode1, addressMode);
        }

        [TestMethod]
        public void GetInstructionClassReturnsExpectedInstructionClass2()
        {
            var instructionClass = InstructionValueParser.GetInstructionClass(Constants.InstructionValue2);

            Assert.AreEqual(Constants.ExpectedInstructionClass2, instructionClass);
        }

        [TestMethod]
        public void GetAddressModeDestinationReturnsExpectedAddressMode2()
        {
            var addressMode = InstructionValueParser.GetAddressModeDestination(Constants.InstructionValue2);

            Assert.AreEqual(Constants.ExpectedDestinationAddressMode2, addressMode);
        }

        [TestMethod]
        public void GetInstructionClassReturnsExpectedInstructionClass3()
        {
            var instructionClass = InstructionValueParser.GetInstructionClass(Constants.InstructionValue3);

            Assert.AreEqual(Constants.ExpectedInstructionClass3, instructionClass);
        }

        [TestMethod]
        public void GetInstructionClassReturnsExpectedInstructionClass4()
        {
            var instructionClass = InstructionValueParser.GetInstructionClass(Constants.InstructionValue4);

            Assert.AreEqual(Constants.ExpectedInstructionClass4, instructionClass);
        }

        [TestMethod]
        public void GetInstructionNumberB1ReturnsExpectedInstructionNumber1()
        {
            var instructionNumber = InstructionValueParser.GetInstructionNumberB1(Constants.InstructionValue1);

            Assert.AreEqual(Constants.ExpectedInstructionNumber1, instructionNumber);
        }

        [TestMethod]
        public void GetInstructionNumberB2ReturnsExpectedInstructionNumber1()
        {
            var instructionNumber = InstructionValueParser.GetInstructionNumberB2(Constants.InstructionValue2);

            Assert.AreEqual(Constants.ExpectedInstructionNumber2, instructionNumber);
        }

        [TestMethod]
        public void GetInstructionNumberB3ReturnsExpectedInstructionNumber1()
        {
            var instructionNumber = InstructionValueParser.GetInstructionNumberB3(Constants.InstructionValue3);

            Assert.AreEqual(Constants.ExpectedInstructionNumber3, instructionNumber);
        }

        [TestMethod]
        public void GetInstructionNumberB4ReturnsExpectedInstructionNumber1()
        {
            var instructionNumber = InstructionValueParser.GetInstructionNumberB4(Constants.InstructionValue4);

            Assert.AreEqual(Constants.ExpectedInstructionNumber4, instructionNumber);
        }

        [TestMethod]
        public void GetRegisterNumberSourceB1ReturnsExpectedRegisterNumber1()
        {
            var registerNumber = InstructionValueParser.GetRegisterNumberSourceB1(Constants.InstructionValue1);

            Assert.AreEqual(Constants.ExpectedRegisterNumberSource1, registerNumber);
        }

        [TestMethod]
        public void GetRegisterNumberDestinationB1ReturnsExpectedRegisterNumber1()
        {
            var registerNumber = InstructionValueParser.GetRegisterNumberDestinationB1(Constants.InstructionValue1);

            Assert.AreEqual(Constants.ExpectedRegisterNumberDestination1, registerNumber);
        }

        [TestMethod]
        public void GetRegisterNumberDestinationB2ReturnsExpectedRegisterNumber1()
        {
            var registerNumber = InstructionValueParser.GetRegisterNumberDestinationB2(Constants.InstructionValue2);

            Assert.AreEqual(Constants.ExpectedRegisterNumberDestination2, registerNumber);
        }
    }
}
