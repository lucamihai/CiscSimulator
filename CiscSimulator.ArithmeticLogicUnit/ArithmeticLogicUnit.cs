using System;
using System.Windows.Forms;
using CiscSimulator.ArithmeticLogicUnit.Enums;
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
        }
    }
}
