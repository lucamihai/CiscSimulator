using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Common.UnitTests
{
    [TestClass]
    public class DataUnitTests
    {
        private Data data1;
        private Data data2;

        private string expectedDataString1;
        private string expectedDataString2;

        private short expectedValue1;
        private short expectedValue2;

        [TestInitialize]
        public void Initialize()
        {
            data1 = new Data {HiByte = 0, LoByte = 5};
            data2 = new Data {HiByte = 2, LoByte = 4};

            expectedDataString1 = "00000000 00000101";
            expectedDataString2 = "00000010 00000100";

            expectedValue1 = 5;
            expectedValue2 = 516;
        }

        [TestMethod]
        public void ToStringWorks1()
        {
            Assert.AreEqual(expectedDataString1, data1.ToString());
        }

        [TestMethod]
        public void ToStringWorks2()
        {
            Assert.AreEqual(expectedDataString2, data2.ToString());
        }

        [TestMethod]
        public void ValuePropertyWorks1()
        {
            Assert.AreEqual(expectedValue1, data1.Value);
        }

        [TestMethod]
        public void ValuePropertyWorks2()
        {
            Assert.AreEqual(expectedValue2, data2.Value);
        }
    }
}
