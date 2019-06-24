namespace CiscSimulator.Common
{
    public class FlagRegister : Register
    {
        public FlagRegister() : base("FLAG") { }

        public bool CarryFlag
        {
            get
            {
                var result = this.Data.Value & Constants.CarryFlagMask;

                return result == Constants.CarryFlagMask;
            }

            set =>
                this.Data.Value = value 
                    ? (ushort)(this.Data.Value | Constants.CarryFlagMask) 
                    : (ushort)(this.Data.Value & ~Constants.CarryFlagMask);
        }

        public bool ParityFlag
        {
            get
            {
                var result = this.Data.Value & Constants.ParityFlagMask;

                return result == Constants.ParityFlagMask;
            }

            set =>
                this.Data.Value = value
                    ? (ushort)(this.Data.Value | Constants.ParityFlagMask)
                    : (ushort)(this.Data.Value & ~Constants.ParityFlagMask);
        }

        public bool AdjustFlag
        {
            get
            {
                var result = this.Data.Value & Constants.AdjustFlagMask;

                return result == Constants.AdjustFlagMask;
            }

            set =>
                this.Data.Value = value
                    ? (ushort)(this.Data.Value | Constants.AdjustFlagMask)
                    : (ushort)(this.Data.Value & ~Constants.AdjustFlagMask);
        }

        public bool ZeroFlag
        {
            get
            {
                var result = this.Data.Value & Constants.ZeroFlagMask;

                return result == Constants.ZeroFlagMask;
            }

            set =>
                this.Data.Value = value
                    ? (ushort)(this.Data.Value | Constants.ZeroFlagMask)
                    : (ushort)(this.Data.Value & ~Constants.ZeroFlagMask);
        }

        public bool SignFlag
        {
            get
            {
                var result = this.Data.Value & Constants.SignFlagMask;

                return result == Constants.SignFlagMask;
            }

            set =>
                this.Data.Value = value
                    ? (ushort)(this.Data.Value | Constants.SignFlagMask)
                    : (ushort)(this.Data.Value & ~Constants.SignFlagMask);
        }

        public bool TrapFlag
        {
            get
            {
                var result = this.Data.Value & Constants.TrapFlagMask;

                return result == Constants.TrapFlagMask;
            }

            set =>
                this.Data.Value = value
                    ? (ushort)(this.Data.Value | Constants.TrapFlagMask)
                    : (ushort)(this.Data.Value & ~Constants.TrapFlagMask);
        }

        public bool InterruptEnableFlag
        {
            get
            {
                var result = this.Data.Value & Constants.InterruptEnableFlagMask;

                return result == Constants.InterruptEnableFlagMask;
            }

            set =>
                this.Data.Value = value
                    ? (ushort)(this.Data.Value | Constants.InterruptEnableFlagMask)
                    : (ushort)(this.Data.Value & ~Constants.InterruptEnableFlagMask);
        }

        public bool DirectionFlag
        {
            get
            {
                var result = this.Data.Value & Constants.DirectionFlagMask;

                return result == Constants.DirectionFlagMask;
            }

            set =>
                this.Data.Value = value
                    ? (ushort)(this.Data.Value | Constants.DirectionFlagMask)
                    : (ushort)(this.Data.Value & ~Constants.DirectionFlagMask);
        }

        public bool OverflowFlag
        {
            get
            {
                var result = this.Data.Value & Constants.OverflowFlagMask;

                return result == Constants.OverflowFlagMask;
            }

            set =>
                this.Data.Value = value
                    ? (ushort)(this.Data.Value | Constants.OverflowFlagMask)
                    : (ushort)(this.Data.Value & ~Constants.OverflowFlagMask);
        }
    }
}
