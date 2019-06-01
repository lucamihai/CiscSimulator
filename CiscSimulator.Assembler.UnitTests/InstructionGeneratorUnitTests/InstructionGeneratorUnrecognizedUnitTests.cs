using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.Assembler.UnitTests.InstructionGeneratorUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class InstructionGeneratorUnrecognizedUnitTests
    {
        private InstructionGenerator instructionGenerator;

        [TestInitialize]
        public void Setup()
        {
            instructionGenerator = new InstructionGenerator();
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsNullIfInstructionIsUnrecognized1()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionUnrecognized1);

            Assert.IsNull(instruction);
        }

        [TestMethod]
        public void GenerateInstructionFromLineReturnsNullIfInstructionIsUnrecognized2()
        {
            var instruction = instructionGenerator.GenerateInstructionFromLine(Constants.LineInstructionUnrecognized2);

            Assert.IsNull(instruction);
        }
    }
}
