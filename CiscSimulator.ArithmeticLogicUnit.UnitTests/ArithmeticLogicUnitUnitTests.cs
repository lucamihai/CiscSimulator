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
            Assert.AreEqual(AluOperator.Undefined, arithmeticLogicUnit.Operator);
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
            arithmeticLogicUnit.Operator = AluOperator.Add;

            arithmeticLogicUnit.PerformOperation();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PerformOperationThrowsInvalidOperationExceptionIfOperand2IsNull()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = null;
            arithmeticLogicUnit.Operator = AluOperator.Add;

            arithmeticLogicUnit.PerformOperation();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PerformOperationThrowsInvalidOperationExceptionIfOperatorIsUndefined()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = AluOperator.Undefined;

            arithmeticLogicUnit.PerformOperation();
        }

        [TestMethod]
        public void PerformOperationDoesNotThrowAnyExceptionIfBothOperandsAreProvidedAndOperatorIsNotUndefined()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = AluOperator.Add;

            arithmeticLogicUnit.PerformOperation();
        }

        [TestMethod]
        public void PerformOperationInitializedResultForOperationAdd()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = AluOperator.Add;

            arithmeticLogicUnit.PerformOperation();

            Assert.IsNotNull(arithmeticLogicUnit.Result);
        }

        [TestMethod]
        public void PerformOperationInitializedResultForOperationSubtract()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = AluOperator.Subtract;

            arithmeticLogicUnit.PerformOperation();

            Assert.IsNotNull(arithmeticLogicUnit.Result);
        }

        [TestMethod]
        public void PerformOperationInitializedResultForOperationAnd()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = AluOperator.And;

            arithmeticLogicUnit.PerformOperation();

            Assert.IsNotNull(arithmeticLogicUnit.Result);
        }

        [TestMethod]
        public void PerformOperationInitializedResultForOperationOr()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = AluOperator.Or;

            arithmeticLogicUnit.PerformOperation();

            Assert.IsNotNull(arithmeticLogicUnit.Result);
        }

        [TestMethod]
        public void PerformOperationInitializedResultForOperationExclusiveOr()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = AluOperator.ExclusiveOr;

            arithmeticLogicUnit.PerformOperation();

            Assert.IsNotNull(arithmeticLogicUnit.Result);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void PerformOperationThrowsNotImplementedExceptionForOperationNegate()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = AluOperator.Negate;

            arithmeticLogicUnit.PerformOperation();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void PerformOperationThrowsNotImplementedExceptionForOperationArithmeticShiftRight()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = AluOperator.ArithmeticShiftRight;

            arithmeticLogicUnit.PerformOperation();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void PerformOperationThrowsNotImplementedExceptionForOperationArithmeticShiftLeft()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = AluOperator.ArithmeticShiftLeft;

            arithmeticLogicUnit.PerformOperation();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void PerformOperationThrowsNotImplementedExceptionForOperationLogicalShiftRight()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = AluOperator.LogicalShiftRight;

            arithmeticLogicUnit.PerformOperation();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void PerformOperationThrowsNotImplementedExceptionForOperationLogicalShiftLeft()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = AluOperator.LogicalShiftLeft;

            arithmeticLogicUnit.PerformOperation();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void PerformOperationThrowsNotImplementedExceptionForOperationRotateRight()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = AluOperator.RotateRight;

            arithmeticLogicUnit.PerformOperation();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void PerformOperationThrowsNotImplementedExceptionForOperationRotateLeft()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = AluOperator.RotateLeft;

            arithmeticLogicUnit.PerformOperation();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void PerformOperationThrowsNotImplementedExceptionForOperationRotateRightThroughCarry()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = AluOperator.RotateRightThroughCarry;

            arithmeticLogicUnit.PerformOperation();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void PerformOperationThrowsNotImplementedExceptionForOperationRotateLeftThroughCarry()
        {
            arithmeticLogicUnit.Operand1 = new Data();
            arithmeticLogicUnit.Operand2 = new Data();
            arithmeticLogicUnit.Operator = AluOperator.RotateLeftThroughCarry;

            arithmeticLogicUnit.PerformOperation();
        }
    }
}
