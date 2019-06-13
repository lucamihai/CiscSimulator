using CiscSimulator.ArithmeticLogicUnit.Enums;
using CiscSimulator.Common;
using CiscSimulator.Sequencer.Enums;

namespace CiscSimulator.Sequencer
{
    public class MpmData
    {
        public MpmData(long value = 0)
        {
            Value = value;
        }

        public SBusDBusOperations SBusOperation
        {
            get => (SBusDBusOperations)(Value >> 35);
            set => Value += (long)value << 35;
        }

        public SBusDBusOperations DBusOperation
        {
            get
            {
                var binaryRepresentation = this.ToString();
                var stringValue = binaryRepresentation.GetBitsFromSpecifiedPositions(34, 31);

                return (SBusDBusOperations)Utilities.GetValueFromBinaryStringRepresentation(stringValue);
            }
            set => Value += (long)value << 31;
        }

        public AluOperator AluOperator
        {
            get
            {
                var binaryRepresentation = this.ToString();
                var stringValue = binaryRepresentation.GetBitsFromSpecifiedPositions(30, 27);

                return (AluOperator)Utilities.GetValueFromBinaryStringRepresentation(stringValue);
            }
            set => Value += (long)value << 27;
        }

        public RBusOperations RBusOperation
        {
            get
            {
                var binaryRepresentation = this.ToString();
                var stringValue = binaryRepresentation.GetBitsFromSpecifiedPositions(26, 23);

                return (RBusOperations)Utilities.GetValueFromBinaryStringRepresentation(stringValue);
            }
            set => Value += (long)value << 23;
        }

        public OtherOperations OtherOperation
        {
            get
            {
                var binaryRepresentation = this.ToString();
                var stringValue = binaryRepresentation.GetBitsFromSpecifiedPositions(22, 19);

                return (OtherOperations)Utilities.GetValueFromBinaryStringRepresentation(stringValue);
            }
            set => Value += (long)value << 19;
        }

        public MemoryOperations MemoryOperation
        {
            get
            {
                var binaryRepresentation = this.ToString();
                var stringValue = binaryRepresentation.GetBitsFromSpecifiedPositions(18, 17);

                return (MemoryOperations)Utilities.GetValueFromBinaryStringRepresentation(stringValue);
            }
            set => Value += (long)value << 17;
        }

        public JumpOperations JumpOperation
        {
            get
            {
                var binaryRepresentation = this.ToString();
                var stringValue = binaryRepresentation.GetBitsFromSpecifiedPositions(16, 13);

                return (JumpOperations)Utilities.GetValueFromBinaryStringRepresentation(stringValue);
            }
            set => Value += (long)value << 13;
        }

        public byte JumpLocation
        {
            get
            {
                var binaryRepresentation = this.ToString();
                var stringValue = binaryRepresentation.GetBitsFromSpecifiedPositions(11, 4);

                return (byte)Utilities.GetValueFromBinaryStringRepresentation(stringValue);
            }
            set => Value += (long)value << 4;
        }

        public Indexes JumpIndex
        {
            get
            {
                var binaryRepresentation = this.ToString();
                var stringValue = binaryRepresentation.GetBitsFromSpecifiedPositions(3, 0);

                return (Indexes)Utilities.GetValueFromBinaryStringRepresentation(stringValue);
            }
            set => Value += (long)value;
        }

        public long Value { get; private set; }

        public override string ToString()
        {
            return Utilities.GetBinaryStringRepresentation(Value, 39);
        }
    }
}
