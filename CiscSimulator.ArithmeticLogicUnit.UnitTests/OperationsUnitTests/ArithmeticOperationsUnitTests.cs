using System.Diagnostics.CodeAnalysis;
using CiscSimulator.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.ArithmeticLogicUnit.UnitTests.OperationsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ArithmeticOperationsUnitTests
    {
        [TestMethod]
        public void AddWorksAsExpected()
        {
            var operand1 = Constants.Operand1;
            var operand2 = Constants.Operand2;
            var result = new Data();

            Operations.ArithmeticOperations.Add(result, operand1, operand2);

            Assert.AreEqual(Constants.ExpectedResultSum.Value, result.Value);
        }

        [TestMethod]
        public void SubtractWorksAsExpected()
        {
            var operand1 = Constants.Operand1;
            var operand2 = Constants.Operand2;
            var result = new Data();

            Operations.ArithmeticOperations.Subtract(result, operand1, operand2);

            Assert.AreEqual(Constants.ExpectedResultSubtract.Value, result.Value);
        }
    }
}
