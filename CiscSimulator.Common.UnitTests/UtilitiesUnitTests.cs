using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Common.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UtilitiesUnitTests
    {
        [TestMethod]
        public void GetBinaryRepresentationReturnsExpectedString1()
        {
            var binaryRepresentation = Utilities.GetBinaryStringRepresentation(Constants.Byte1);

            Assert.AreEqual(Constants.ByteStringRepresentation1, binaryRepresentation);
        }

        [TestMethod]
        public void GetBinaryRepresentationReturnsExpectedString2()
        {
            var binaryRepresentation = Utilities.GetBinaryStringRepresentation(Constants.Byte2);

            Assert.AreEqual(Constants.ByteStringRepresentation2, binaryRepresentation);
        }

        [TestMethod]
        public void SliceReturnsExpectedString1()
        {
            var slicedString = Constants.String1.Slice(Constants.StringSliceBegin1, Constants.StringSliceEnd1);

            Assert.AreEqual(Constants.SlicedString1, slicedString);
        }

        [TestMethod]
        public void SliceReturnsExpectedString2()
        {
            var slicedString = Constants.String2.Slice(Constants.StringSliceBegin2, Constants.StringSliceEnd2);

            Assert.AreEqual(Constants.SlicedString2, slicedString);
        }

        [TestMethod]
        public void SliceReturnsExpectedStringIfProvidedNegativeEnd()
        {
            var slicedString = Constants.String3.Slice(Constants.StringSliceBegin3, Constants.StringSliceEnd3);

            Assert.AreEqual(Constants.SlicedString3, slicedString);
        }
    }
}
