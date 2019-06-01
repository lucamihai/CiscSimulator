using System.Diagnostics.CodeAnalysis;
using CiscSimulator.ArithmeticLogicUnit.Operations;
using CiscSimulator.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.ArithmeticLogicUnit.UnitTests.OperationsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BitWiseOperationsUnitTests
    {
        [TestMethod]
        public void AndWorksAsExpected()
        {
            var operand1 = Constants.Operand1;
            var operand2 = Constants.Operand2;
            var result = new Data();

            BitWiseOperations.And(result, operand1, operand2);

            Assert.AreEqual(Constants.ExpectedResultAnd.Value, result.Value);
        }

        [TestMethod]
        public void OrWorksAsExpected()
        {
            var operand1 = Constants.Operand1;
            var operand2 = Constants.Operand2;
            var result = new Data();

            BitWiseOperations.Or(result, operand1, operand2);

            Assert.AreEqual(Constants.ExpectedResultOr.Value, result.Value);
        }

        [TestMethod]
        public void ExclusiveOrWorksAsExpected()
        {
            var operand1 = Constants.Operand1;
            var operand2 = Constants.Operand2;
            var result = new Data();

            BitWiseOperations.ExclusiveOr(result, operand1, operand2);

            Assert.AreEqual(Constants.ExpectedResultExclusiveOr.Value, result.Value);
        }
    }
}
