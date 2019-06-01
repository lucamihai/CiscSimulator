using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Assembler.UnitTests.InstructionsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class B1InstructionUnitTests
    {
        [TestMethod]
        public void DataPropertyReturnsExpectedData1()
        {
            var instruction = Constants.B1Instruction1;
            var expectedData = Constants.B1Instruction1ExpectedData;

            Assert.AreEqual(expectedData, instruction.Data);
        }

        [TestMethod]
        public void DataPropertyReturnsExpectedData2()
        {
            var instruction = Constants.B1Instruction2;
            var expectedData = Constants.B1Instruction2ExpectedData;

            Assert.AreEqual(expectedData, instruction.Data);
        }
    }
}
