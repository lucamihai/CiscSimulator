using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Assembler.UnitTests
{
    [TestClass]
    public class ArgumentAnalyzerUnitTests
    {
        private const string ArgumentAddressModeImmediate1 = "10";
        private const string ArgumentAddressModeImmediate2 = "15";

        private const string ArgumentAddressModeDirect1 = "r5";
        private const string ArgumentAddressModeDirect2 = "r6";

        private const string ArgumentAddressModeIndirect1 = "(r1)";
        private const string ArgumentAddressModeIndirect2 = "(r2)";

        private const string ArgumentAddressModeIndexed1 = "(r1)1";
        private const string ArgumentAddressModeIndexed2 = "(r2)13";

        private const string ArgumentAddressModeNotRecognized1 = "-10";
        private const string ArgumentAddressModeNotRecognized2 = "rr";
        private const string ArgumentAddressModeNotRecognized3 = "(10)";
        private const string ArgumentAddressModeNotRecognized4 = "(r1)r2";


        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeImmediate1()
        {
            var argument = ArgumentAddressModeImmediate1;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.Immediate, addressMode);
            Assert.AreEqual(10, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeImmediate2()
        {
            var argument = ArgumentAddressModeImmediate2;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.Immediate, addressMode);
            Assert.AreEqual(15, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeDirect1()
        {
            var argument = ArgumentAddressModeDirect1;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.Direct, addressMode);
            Assert.AreEqual(5, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeDirect2()
        {
            var argument = ArgumentAddressModeDirect2;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.Direct, addressMode);
            Assert.AreEqual(6, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeIndirect1()
        {
            var argument = ArgumentAddressModeIndirect1;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.Indirect, addressMode);
            Assert.AreEqual(1, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeIndirect2()
        {
            var argument = ArgumentAddressModeIndirect2;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.Indirect, addressMode);
            Assert.AreEqual(2, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeIndexed1()
        {
            var argument = ArgumentAddressModeIndexed1;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.Indexed, addressMode);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeIndexed2()
        {
            var argument = ArgumentAddressModeIndexed2;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.Indexed, addressMode);
            Assert.AreEqual(2, value);
            Assert.AreEqual(13, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeNotRecognized1()
        {
            var argument = ArgumentAddressModeNotRecognized1;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
            Assert.AreEqual(0, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeNotRecognized2()
        {
            var argument = ArgumentAddressModeNotRecognized2;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
            Assert.AreEqual(0, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeNotRecognized3()
        {
            var argument = ArgumentAddressModeNotRecognized3;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
            Assert.AreEqual(0, value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeNotRecognized4()
        {
            var argument = ArgumentAddressModeNotRecognized4;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
            Assert.AreEqual(0, value);
            Assert.AreEqual(0, extendedData.Value);
        }
    }
}