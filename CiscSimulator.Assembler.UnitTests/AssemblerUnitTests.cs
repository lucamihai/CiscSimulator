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
        public void LinesContainingOnlyCommentsAreRemoved()
        {
            assembler.ParseText(Resources.Text1);

            Assert.AreEqual(6, assembler.LineCount);
        }
    }
}
