using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Assembler.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Assembler.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ArgumentAnalyzerUnitTests
    {
        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeImmediate1()
        {
            var argument = Constants.ArgumentAddressModeImmediate1;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.Immediate, addressMode);
            Assert.AreEqual(10, value.Value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeImmediate2()
        {
            var argument = Constants.ArgumentAddressModeImmediate2;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.Immediate, addressMode);
            Assert.AreEqual(15, value.Value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeDirect1()
        {
            var argument = Constants.ArgumentAddressModeDirect1;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.Direct, addressMode);
            Assert.AreEqual(5, value.Value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeDirect2()
        {
            var argument = Constants.ArgumentAddressModeDirect2;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.Direct, addressMode);
            Assert.AreEqual(6, value.Value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeIndirect1()
        {
            var argument = Constants.ArgumentAddressModeIndirect1;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.Indirect, addressMode);
            Assert.AreEqual(1, value.Value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeIndirect2()
        {
            var argument = Constants.ArgumentAddressModeIndirect2;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.Indirect, addressMode);
            Assert.AreEqual(2, value.Value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeIndexed1()
        {
            var argument = Constants.ArgumentAddressModeIndexed1;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.Indexed, addressMode);
            Assert.AreEqual(1, value.Value);
            Assert.AreEqual(1, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeIndexed2()
        {
            var argument = Constants.ArgumentAddressModeIndexed2;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.Indexed, addressMode);
            Assert.AreEqual(2, value.Value);
            Assert.AreEqual(13, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeNotRecognized2()
        {
            var argument = Constants.ArgumentAddressModeNotRecognized2;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
            Assert.AreEqual(0, value.Value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeNotRecognized3()
        {
            var argument = Constants.ArgumentAddressModeNotRecognized3;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
            Assert.AreEqual(0, value.Value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeNotRecognized4()
        {
            var argument = Constants.ArgumentAddressModeNotRecognized4;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
            Assert.AreEqual(0, value.Value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeNotRecognized5()
        {
            var argument = Constants.ArgumentAddressModeNotRecognized5;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
            Assert.AreEqual(0, value.Value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeNotRecognized6()
        {
            var argument = Constants.ArgumentAddressModeNotRecognized6;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
            Assert.AreEqual(0, value.Value);
            Assert.AreEqual(0, extendedData.Value);
        }

        [TestMethod]
        public void GetInformationFromArgumentWorksOkForAddressModeNotRecognized7()
        {
            var argument = Constants.ArgumentAddressModeNotRecognized7;

            ArgumentAnalyzer.GetInformationFromArgument(
                argument,
                out var addressMode,
                out var value,
                out var extendedData
            );

            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
            Assert.AreEqual(0, value.Value);
            Assert.AreEqual(0, extendedData.Value);
        }
    }
}