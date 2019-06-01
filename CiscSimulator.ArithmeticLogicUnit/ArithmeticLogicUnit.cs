using System;
using System.Windows.Forms;
using CiscSimulator.ArithmeticLogicUnit.Enums;
using CiscSimulator.ArithmeticLogicUnit.Operations;
using CiscSimulator.Common;

namespace CiscSimulator.ArithmeticLogicUnit
{
    public partial class ArithmeticLogicUnit : UserControl
    {
        public Data Operand1 { get; set; }
        public Data Operand2 { get; set; }
        public Operator Operator { get; set; }
        public Data Result { get; set; }

        public ArithmeticLogicUnit()
        {
            InitializeComponent();

            Result = new Data();
            Operator = Operator.Undefined;
        }

        public void PerformOperation()
        {
            if (Operand1 == null)
            {
                throw new InvalidOperationException($"Can't perform operation if {nameof(Operand1)} is null");
            }

            if (Operand2 == null)
            {
                throw new InvalidOperationException($"Can't perform operation if {nameof(Operand2)} is null");
            }

            if (Operator == Operator.Undefined)
            {
                throw new InvalidOperationException($"Can't perform operation if {nameof(Operator)} is undefined");
            }

            switch (Operator)
            {
                case Operator.Add:
                    ArithmeticOperations.Add(Result, Operand1, Operand2);
                    break;
                case Operator.Subtract:
                    ArithmeticOperations.Subtract(Result, Operand1, Operand2);
                    break;
                case Operator.And:
                    BitWiseOperations.And(Result, Operand1, Operand2);
                    break;
                case Operator.Or:
                    BitWiseOperations.Or(Result, Operand1, Operand2);
                    break;
                case Operator.ExclusiveOr:
                    BitWiseOperations.ExclusiveOr(Result, Operand1, Operand2);
                    break;
                case Operator.Negate:
                    break;
                case Operator.ArithmeticShiftRight:
                    break;
                case Operator.ArithmeticShiftLeft:
                    break;
                case Operator.LogicalShiftRight:
                    break;
                case Operator.LogicalShiftLeft:
                    break;
                case Operator.RotateRight:
                    break;
                case Operator.RotateLeft:
                    break;
                case Operator.RotateRightThroughCarry:
                    break;
                case Operator.RotateLeftThroughCarry:
                    break;
            }
        }
    }
}
