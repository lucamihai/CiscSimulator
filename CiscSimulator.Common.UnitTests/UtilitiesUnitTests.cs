using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Common.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UtilitiesUnitTests
    {
        [TestMethod]
        public void GetBinaryStringRepresentationReturnsExpectedString1()
        {
            var binaryRepresentation = Utilities.GetBinaryStringRepresentation(Constants.Value1);

            Assert.AreEqual(Constants.BinaryStringRepresentation1, binaryRepresentation);
        }

        [TestMethod]
        public void GetBinaryStringRepresentationReturnsExpectedString2()
        {
            var binaryRepresentation = Utilities.GetBinaryStringRepresentation(Constants.Value2);

            Assert.AreEqual(Constants.BinaryStringRepresentation2, binaryRepresentation);
        }

        [TestMethod]
        public void GetBinaryStringRepresentationReturnsExpectedString3()
        {
            var binaryRepresentation = Utilities.GetBinaryStringRepresentation(Constants.Value3, 12);

            Assert.AreEqual(Constants.BinaryStringRepresentation3, binaryRepresentation);
        }

        [TestMethod]
        public void GetBinaryStringRepresentationReturnsExpectedString4()
        {
            var binaryRepresentation = Utilities.GetBinaryStringRepresentation(Constants.Value4);

            Assert.AreEqual(Constants.BinaryStringRepresentation4, binaryRepresentation);
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

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetValueFromBinaryStringRepresentationThrowsInvalidOperationExceptionForStringContainingOtherCharactersBesides1sAnd0s()
        {
            var value = Utilities.GetValueFromBinaryStringRepresentation(Constants.BinaryStringContainingOtherCharacters);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetValueFromBinaryStringRepresentationThrowsInvalidOperationExceptionForStringTooLong()
        {
            var value = Utilities.GetValueFromBinaryStringRepresentation(Constants.BinaryStringTooLong);
        }

        [TestMethod]
        public void GetValueFromBinaryStringRepresentationReturnsExpectedValue1()
        {
            var value = Utilities.GetValueFromBinaryStringRepresentation(Constants.BinaryStringRepresentation1);

            Assert.AreEqual(Constants.Value1, value);
        }

        [TestMethod]
        public void GetValueFromBinaryStringRepresentationReturnsExpectedValue2()
        {
            var value = Utilities.GetValueFromBinaryStringRepresentation(Constants.BinaryStringRepresentation2);

            Assert.AreEqual(Constants.Value2, value);
        }

        [TestMethod]
        public void GetValueFromBinaryStringRepresentationReturnsExpectedValue3()
        {
            var value = Utilities.GetValueFromBinaryStringRepresentation(Constants.BinaryStringRepresentation3);

            Assert.AreEqual(Constants.Value3, value);
        }

        [TestMethod]
        public void GetValueFromBinaryStringRepresentationReturnsExpectedValue4()
        {
            var value = Utilities.GetValueFromBinaryStringRepresentation(Constants.BinaryStringRepresentation4);

            Assert.AreEqual(Constants.Value4, value);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetBitsFromSpecifiedPositionsThrowsInvalidOperationExceptionForStringContainingOtherCharactersBesides1sAnd0s()
        {
            var bits = Constants.BinaryStringContainingOtherCharacters.GetBitsFromSpecifiedPositions(2, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetBitsFromSpecifiedPositionsThrowsInvalidOperationExceptionForStringTooLong()
        {
            var bits = Constants.BinaryStringTooLong.GetBitsFromSpecifiedPositions(2, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetBitsFromSpecifiedPositionsThrowsInvalidOperationExceptionForHighPositionSmallerThanLowPosition()
        {
            var bits = Constants.BinaryStringTooLong.GetBitsFromSpecifiedPositions(3, 4);
        }

        [TestMethod]
        public void GetBitsFromSpecifiedPositionsReturnsExpectedBits1()
        {
            var bits = Constants.BinaryStringRepresentation1.GetBitsFromSpecifiedPositions(Constants.HighPosition1, Constants.LowPosition1);

            Assert.AreEqual(Constants.ExpectedBits1, bits);
        }

        [TestMethod]
        public void GetBitsFromSpecifiedPositionsReturnsExpectedBits2()
        {
            var bits = Constants.BinaryStringRepresentation2.GetBitsFromSpecifiedPositions(Constants.HighPosition2, Constants.LowPosition2);

            Assert.AreEqual(Constants.ExpectedBits2, bits);
        }

        [TestMethod]
        public void GetBitsFromSpecifiedPositionsReturnsExpectedBits3()
        {
            var bits = Constants.BinaryStringRepresentation3.GetBitsFromSpecifiedPositions(Constants.HighPosition3, Constants.LowPosition3);

            Assert.AreEqual(Constants.ExpectedBits3, bits);
        }

        [TestMethod]
        public void GetBitsFromSpecifiedPositionsReturnsExpectedBits4()
        {
            var bits = Constants.BinaryStringRepresentation4.GetBitsFromSpecifiedPositions(Constants.HighPosition4, Constants.LowPosition4);

            Assert.AreEqual(Constants.ExpectedBits4, bits);
        }
    }
}
