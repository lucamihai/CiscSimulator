﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Assembler.UnitTests
{
    [TestClass]
    public class ArgumentAnalyzerUnitTests
    {
        private string argumentAddressModeImmediate1 = "10";
        private string argumentAddressModeImmediate2 = "15";

        private string argumentAddressModeDirect1 = "r5";
        private string argumentAddressModeDirect2 = "r6";

        private string argumentAddressModeIndirect1 = "(r1)";
        private string argumentAddressModeIndirect2 = "(r2)";

        private string argumentAddressModeIndexed1 = "(r1)1";
        private string argumentAddressModeIndexed2 = "(r2)13";

        private string argumentAddressModeNotRecognized1 = "-10";
        private string argumentAddressModeNotRecognized2 = "rr";
        private string argumentAddressModeNotRecognized3 = "(10)";
        private string argumentAddressModeNotRecognized4 = "(r1)r2";

        [TestMethod]
        public void GetAddressModeBasedOnArgumentReturnsAddressModeImmediate1()
        {
            var addressMode = ArgumentAnalyzer.GetAddressModeBasedOnArgument(argumentAddressModeImmediate1);
            Assert.AreEqual(AddressMode.Immediate, addressMode);
        }

        [TestMethod]
        public void GetAddressModeBasedOnArgumentReturnsAddressModeImmediate2()
        {
            var addressMode = ArgumentAnalyzer.GetAddressModeBasedOnArgument(argumentAddressModeImmediate2);
            Assert.AreEqual(AddressMode.Immediate, addressMode);
        }

        [TestMethod]
        public void GetAddressModeBasedOnArgumentReturnsAddressModeDirect1()
        {
            var addressMode = ArgumentAnalyzer.GetAddressModeBasedOnArgument(argumentAddressModeDirect1);
            Assert.AreEqual(AddressMode.Direct, addressMode);
        }

        [TestMethod]
        public void GetAddressModeBasedOnArgumentReturnsAddressModeDirect2()
        {
            var addressMode = ArgumentAnalyzer.GetAddressModeBasedOnArgument(argumentAddressModeDirect2);
            Assert.AreEqual(AddressMode.Direct, addressMode);
        }

        [TestMethod]
        public void GetAddressModeBasedOnArgumentReturnsAddressModeIndirect1()
        {
            var addressMode = ArgumentAnalyzer.GetAddressModeBasedOnArgument(argumentAddressModeIndirect1);
            Assert.AreEqual(AddressMode.Indirect, addressMode);
        }

        [TestMethod]
        public void GetAddressModeBasedOnArgumentReturnsAddressModeIndirect2()
        {
            var addressMode = ArgumentAnalyzer.GetAddressModeBasedOnArgument(argumentAddressModeIndirect2);
            Assert.AreEqual(AddressMode.Indirect, addressMode);
        }

        [TestMethod]
        public void GetAddressModeBasedOnArgumentReturnsAddressModeIndexed1()
        {
            var addressMode = ArgumentAnalyzer.GetAddressModeBasedOnArgument(argumentAddressModeIndexed1);
            Assert.AreEqual(AddressMode.Indexed, addressMode);
        }

        [TestMethod]
        public void GetAddressModeBasedOnArgumentReturnsAddressModeIndexed2()
        {
            var addressMode = ArgumentAnalyzer.GetAddressModeBasedOnArgument(argumentAddressModeIndexed2);
            Assert.AreEqual(AddressMode.Indexed, addressMode);
        }

        [TestMethod]
        public void GetAddressModeBasedOnArgumentReturnsAddressModeNotRecognized1()
        {
            var addressMode = ArgumentAnalyzer.GetAddressModeBasedOnArgument(argumentAddressModeNotRecognized1);
            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
        }

        [TestMethod]
        public void GetAddressModeBasedOnArgumentReturnsAddressModeNotRecognized2()
        {
            var addressMode = ArgumentAnalyzer.GetAddressModeBasedOnArgument(argumentAddressModeNotRecognized2);
            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
        }

        [TestMethod]
        public void GetAddressModeBasedOnArgumentReturnsAddressModeNotRecognized3()
        {
            var addressMode = ArgumentAnalyzer.GetAddressModeBasedOnArgument(argumentAddressModeNotRecognized3);
            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
        }

        [TestMethod]
        public void GetAddressModeBasedOnArgumentReturnsAddressModeNotRecognized4()
        {
            var addressMode = ArgumentAnalyzer.GetAddressModeBasedOnArgument(argumentAddressModeNotRecognized4);
            Assert.AreEqual(AddressMode.NotRecognized, addressMode);
        }
    }
}
