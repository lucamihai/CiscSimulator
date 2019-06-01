using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Assembler.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AssemblerUnitTests
    {
        private Assembler assembler;

        [TestInitialize]
        public void Initialize()
        {
            assembler = new Assembler();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseTextThrowsArgumentExceptionForNullString()
        {
            assembler.ParseText(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseTextThrowsArgumentExceptionForEmptyString()
        {
            assembler.ParseText(string.Empty);
        }

        [TestMethod]
        public void ParseTextRemoveLinesContainingOnlyComments()
        {
            assembler.ParseText(Resources.Text1);

            Assert.AreEqual(6, assembler.LineCount);
        }
    }
}
