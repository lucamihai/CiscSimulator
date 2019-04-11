using System;
using System.Drawing;
using CiscSimulator.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Memory.Tests
{
    [TestClass]
    public class MemoryUnitTests
    {
        private Line lineDataIn;
        private Line lineDataOut;
        private Line lineAddress;
        private Memory memory;

        private readonly Data dataToBeInserted1 = new Data {HiByte = 2, LoByte = 3};
        private readonly Data dataToBeInserted2 = new Data {HiByte = 1, LoByte = 9};

        [TestInitialize]
        public void Initialize()
        {
            lineDataIn = new Line(new Point(), new Point());
            lineDataOut = new Line(new Point(), new Point());
            lineAddress = new Line(new Point(), new Point());

            memory = new Memory(lineDataIn, lineDataOut, lineAddress, false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetDataThrowsArgumentExceptionForLineAddressTooSmall()
        {
            var addressTooSmall = (Data)Constants.MinimumAddress.Clone();
            addressTooSmall.LoByte--;
            memory.LineAddress.Data = addressTooSmall;

            var data = memory.Data;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetDataThrowsArgumentExceptionForLineAddressTooBig()
        {
            var addressTooBig = (Data)Constants.MaximumAddress.Clone();
            addressTooBig.LoByte++;
            memory.LineAddress.Data = addressTooBig;

            var data = memory.Data;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddDataFromDataInToSpecifiedAddressThrowsArgumentExceptionForLineAddressDataTooSmall()
        {
            var addressTooSmall = (Data)Constants.MinimumAddress.Clone();
            addressTooSmall.LoByte--;
            memory.LineAddress.Data = addressTooSmall;

            lineDataIn.Data = dataToBeInserted1;
            memory.AddDataFromDataInToSpecifiedAddress();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddDataFromDataInToSpecifiedAddressThrowsArgumentExceptionForLineAddressDataTooBig()
        {
            var addressTooBig = (Data)Constants.MaximumAddress.Clone();
            addressTooBig.LoByte++;
            memory.LineAddress.Data = addressTooBig;

            lineDataIn.Data = dataToBeInserted1;
            memory.AddDataFromDataInToSpecifiedAddress();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PutDataFromSpecifiedAddressInDataOutThrowsArgumentExceptionForLineAddressTooSmall()
        {
            var addressTooSmall = (Data)Constants.MinimumAddress.Clone();
            addressTooSmall.LoByte--;
            memory.LineAddress.Data = addressTooSmall;
            Assert.AreNotEqual(dataToBeInserted1, memory.Data);

            lineDataIn.Data = dataToBeInserted1;
            memory.AddDataFromDataInToSpecifiedAddress();
            memory.PutDataFromSpecifiedAddressInDataOut();

            Assert.AreEqual(dataToBeInserted1, memory.Data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PutDataFromSpecifiedAddressInDataOutThrowsArgumentExceptionForLineAddressTooBig()
        {
            var addressTooSmall = (Data)Constants.MaximumAddress.Clone();
            addressTooSmall.LoByte++;
            memory.LineAddress.Data = addressTooSmall;
            Assert.AreNotEqual(dataToBeInserted1, memory.Data);

            lineDataIn.Data = dataToBeInserted1;
            memory.AddDataFromDataInToSpecifiedAddress();
            memory.PutDataFromSpecifiedAddressInDataOut();

            Assert.AreEqual(dataToBeInserted1, memory.Data);
        }

        [TestMethod]
        public void AddDataFromDataInToSpecifiedAddressWorks()
        {
            memory.LineAddress.Data = (Data)Constants.MinimumAddress.Clone();
            Assert.AreNotEqual(dataToBeInserted1, memory.Data);

            lineDataIn.Data = dataToBeInserted1;
            memory.AddDataFromDataInToSpecifiedAddress();

            Assert.AreEqual(dataToBeInserted1, memory.Data);
        }

        [TestMethod]
        public void DataIsAddedCorrectlyForDifferentAddresses()
        {
            lineAddress.Data = (Data)Constants.MinimumAddress.Clone();

            lineDataIn.Data = dataToBeInserted1;
            memory.AddDataFromDataInToSpecifiedAddress();

            lineAddress.Data.LoByte++;
            lineDataIn.Data = dataToBeInserted2;
            memory.AddDataFromDataInToSpecifiedAddress();

            var lastInsertedData = memory.Data;

            lineAddress.Data.LoByte--;
            var firstInsertedData = memory.Data;

            Assert.AreEqual(dataToBeInserted1, firstInsertedData);
            Assert.AreEqual(dataToBeInserted2, lastInsertedData);
        }

        [TestMethod]
        public void DataIsOverridenIfSameAddressIsUsed()
        {
            lineAddress.Data = (Data)Constants.MinimumAddress.Clone();

            lineDataIn.Data = dataToBeInserted1;
            memory.AddDataFromDataInToSpecifiedAddress();
            var firstInsertedData = memory.Data;

            lineDataIn.Data = dataToBeInserted2;
            memory.AddDataFromDataInToSpecifiedAddress();
            var lastInsertedData = memory.Data;

            Assert.AreEqual(dataToBeInserted1, firstInsertedData);
            Assert.AreEqual(dataToBeInserted2, lastInsertedData);
            Assert.AreNotEqual(firstInsertedData, lastInsertedData);
        }

        [TestMethod]
        public void PutDataFromSpecifiedAddressInDataOutWorks()
        {
            memory.LineAddress.Data = (Data)Constants.MinimumAddress.Clone();
            Assert.AreNotEqual(dataToBeInserted1, memory.Data);

            lineDataIn.Data = dataToBeInserted1;
            memory.AddDataFromDataInToSpecifiedAddress();
            memory.PutDataFromSpecifiedAddressInDataOut();

            Assert.AreEqual(dataToBeInserted1, memory.Data);
        }
    }
}
