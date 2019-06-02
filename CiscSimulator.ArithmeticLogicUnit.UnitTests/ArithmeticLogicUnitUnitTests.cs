using System;
using System.Diagnostics.CodeAnalysis;
using CiscSimulator.ArithmeticLogicUnit.Enums;
using CiscSimulator.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CiscSimulator.ArithmeticLogicUnit.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ArithmeticLogicUnitUnitTests
    {
        private ArithmeticLogicUnit arithmeticLogicUnit;

        [TestInitialize]
        public void Setup()
        {
            arithmeticLogicUnit = new ArithmeticLogicUnit();
        }

        [TestMethod]
        public void InitializedArithmeticLogicUnitHasOperandsSetToNull()
        {
            Assert.IsNull(arithmeticLogicUnit.Operand1);
            Assert.IsNull(arithmeticLogicUnit.Operand2);
        }

        [TestMethod]
        public void InitializedArithmeticLogicUnitHasOperatorSetToUndefined()
        {
            Assert.AreEqual(Operator.Undefined, arithmeticLogicUnit.Operator);
        }

        [TestMethod]
        public void InitializedArithmeticLogicUnitHasResultSetToNull()
        {
            Assert.IsNull(arithmeticLogicUnit.Result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PerformOperationThrowsInvalidOperationExceptionIfOperand1IsNull()
        {
            arithmeticLogicUnit.Operand1 = null;
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = Operator.Add;

            arithmeticLogicUnit.PerformOperation();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PerformOperationThrowsInvalidOperationExceptionIfOperand2IsNull()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = null;
            arithmeticLogicUnit.Operator = Operator.Add;

            arithmeticLogicUnit.PerformOperation();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PerformOperationThrowsInvalidOperationExceptionIfOperatorIsUndefined()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = Operator.Undefined;

            arithmeticLogicUnit.PerformOperation();
        }

        [TestMethod]
        public void PerformOperationDoesNotThrowAnyExceptionIfBothOperandsAreProvidedAndOperatorIsNotUndefined()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = Operator.Add;

            arithmeticLogicUnit.PerformOperation();
        }
    }
}
