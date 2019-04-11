using CiscSimulator.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Assembler.UnitTests
{
    [TestClass]
    public class ArgumentAnalyzerUnitTests
    {
        private const string argumentAddressModeImmediate1 = "10";
        private const string argumentAddressModeImmediate2 = "15";

        private const string argumentAddressModeDirect1 = "r5";
        private const string argumentAddressModeDirect2 = "r6";

        private const string argumentAddressModeIndirect1 = "(r1)";
        private const string argumentAddressModeIndirect2 = "(r2)";

        private const string argumentAddressModeIndexed1 = "(r1)1";
        private const string argumentAddressModeIndexed2 = "(r2)13";

        private const string argumentAddressModeNotRecognized1 = "-10";
        private const string argumentAddressModeNotRecognized2 = "rr";
        private const string argumentAddressModeNotRecognized3 = "(10)";
        private const string argumentAddressModeNotRecognized4 = "(r1)r2";


        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeImmediate1()
        {
            var argument = argumentAddressModeImmediate1;

            AddressMode addressMode;
            byte value;
            Data extendedData;
            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out addressMode,
                out value,
                out extendedData
            );

            Assert.AreEqual(AddressMode.Immediate, addressMode);
            Assert.AreEqual(10, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeImmediate2()
        {
            var argument = argumentAddressModeImmediate2;

            AddressMode addressMode;
            byte value;
            Data extendedData;
            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out addressMode,
                out value,
                out extendedData
            );

            Assert.AreEqual(AddressMode.Immediate, addressMode);
            Assert.AreEqual(15, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeDirect1()
        {
            var argument = argumentAddressModeDirect1;

            AddressMode addressMode;
            byte value;
            Data extendedData;
            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out addressMode,
                out value,
                out extendedData
            );

            Assert.AreEqual(AddressMode.Direct, addressMode);
            Assert.AreEqual(5, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeDirect2()
        {
            var argument = argumentAddressModeDirect2;

            AddressMode addressMode;
            byte value;
            Data extendedData;
            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out addressMode,
                out value,
                out extendedData
            );

            Assert.AreEqual(AddressMode.Direct, addressMode);
            Assert.AreEqual(6, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeIndirect1()
        {
            var argument = argumentAddressModeIndirect1;

            AddressMode addressMode;
            byte value;
            Data extendedData;
            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out addressMode,
                out value,
                out extendedData
            );

            Assert.AreEqual(AddressMode.Indirect, addressMode);
            Assert.AreEqual(1, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeIndirect2()
        {
            var argument = argumentAddressModeIndirect2;

            AddressMode addressMode;
            byte value;
            Data extendedData;
            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out addressMode,
                out value,
                out extendedData
            );

            Assert.AreEqual(AddressMode.Indirect, addressMode);
            Assert.AreEqual(2, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeIndexed1()
        {
            var argument = argumentAddressModeIndexed1;

            AddressMode addressMode;
            byte value;
            Data extendedData;
            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out addressMode,
                out value,
                out extendedData
            );

            Assert.AreEqual(AddressMode.Indexed, addressMode);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeIndexed2()
        {
            var argument = argumentAddressModeIndexed2;

            AddressMode addressMode;
            byte value;
            Data extendedData;
            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out addressMode,
                out value,
                out extendedData
            );

            Assert.AreEqual(AddressMode.Indexed, addressMode);
            Assert.AreEqual(2, value);
            Assert.AreEqual(13, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeNotRecognized1()
        {
            var argument = argumentAddressModeNotRecognized1;

            AddressMode addressMode;
            byte value;
            Data extendedData;
            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out addressMode,
                out value,
                out extendedData
            );

            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
            Assert.AreEqual(0, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeNotRecognized2()
        {
            var argument = argumentAddressModeNotRecognized2;

            AddressMode addressMode;
            byte value;
            Data extendedData;
            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out addressMode,
                out value,
                out extendedData
            );

            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
            Assert.AreEqual(0, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeNotRecognized3()
        {
            var argument = argumentAddressModeNotRecognized3;

            AddressMode addressMode;
            byte value;
            Data extendedData;
            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out addressMode,
                out value,
                out extendedData
            );

            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
            Assert.AreEqual(0, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeNotRecognized4()
        {
            var argument = argumentAddressModeNotRecognized4;

            AddressMode addressMode;
            byte value;
            Data extendedData;
            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out addressMode,
                out value,
                out extendedData
            );

            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
            Assert.AreEqual(0, value);
            Assert.AreEqual(0, extendedData.Value);
        }
    }
}
