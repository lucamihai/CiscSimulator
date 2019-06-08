using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Common.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DataUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoByteSetterThrowsInvalidOperationExceptionForReadOnlyTrue()
        {
            var data = new Data(true);
            data.LoByte = 1;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void HiByteSetterThrowsInvalidOperationExceptionForReadOnlyTrue()
        {
            var data = new Data(true);
            data.HiByte = 1;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ValueSetterThrowsInvalidOperationExceptionForReadOnlyTrue()
        {
            var data = new Data(true);
            data.Value = 1;
        }

        [TestMethod]
        public void LoByteSetterDoesNotThrowAnyExceptionForReadOnlyFalse()
        {
            var data = new Data();
            data.LoByte = 1;
        }

        [TestMethod]
        public void HiByteSetterDoesNotThrowAnyExceptionForReadOnlyFalse()
        {
            var data = new Data();
            data.HiByte = 1;
        }

        [TestMethod]
        public void ValueSetterDoesNotThrowAnyExceptionForReadOnlyFalse()
        {
            var data = new Data();
            data.Value = 1;
        }


        [TestMethod]
        public void ToStringWorks1()
        {
            Assert.AreEqual(Constants.ExpectedDataString1, Constants.Data1.ToString());
        }

        [TestMethod]
        public void ToStringWorks2()
        {
            Assert.AreEqual(Constants.ExpectedDataString2, Constants.Data2.ToString());
        }

        [TestMethod]
        public void ValuePropertyWorks1()
        {
            Assert.IsTrue(Constants.ExpectedValue1 == Constants.Data1.Value);
        }

        [TestMethod]
        public void ValuePropertyWorks2()
        {
            Assert.IsTrue(Constants.ExpectedValue2 == Constants.Data2.Value);
        }

        [TestMethod]
        public void CloneWorks1()
        {
            Assert.AreEqual(Constants.Data1, (Data)Constants.Data1.Clone());
        }

        [TestMethod]
        public void CloneWorks2()
        {
            Assert.AreEqual(Constants.Data2, (Data)Constants.Data2.Clone());
        }

        [TestMethod]
        public void EqualsReturnsTrueForEqualData()
        {
            var data1Clone = (Data)Constants.Data1.Clone();
            Assert.AreEqual(true, Constants.Data1.Equals(data1Clone));
        }

        [TestMethod]
        public void EqualsReturnsFalseForDifferentData()
        {
            Assert.AreEqual(false, Constants.Data1.Equals(Constants.Data2));
        }

        [TestMethod]
        public void EqualsReturnsFalseForDifferentObject()
        {
            Assert.AreEqual(false, Constants.Data1.Equals(new object()));
        }

        [TestMethod]
        public void Data1IsSmallerThanData2()
        {
            Assert.AreEqual(true, Constants.Data1.Value < Constants.Data2.Value);
        }
    }
}
