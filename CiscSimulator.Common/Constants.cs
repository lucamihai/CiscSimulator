using System.Drawing;

namespace CiscSimulator.Common
{
    public static class Constants
    {
        public static readonly Color LineInactiveColor = Color.Black;
        public static readonly Color LineActiveColor = Color.Red;

        public const int CarryFlagMask = 0x0001;
        public const int ParityFlagMask = 0x0004;
        public const int AdjustFlagMask = 0x0010;
        public const int ZeroFlagMask = 0x0040;
        public const int SignFlagMask = 0x0080;
        public const int TrapFlagMask = 0x0100;
        public const int InterruptEnableFlagMask = 0x0200;
        public const int DirectionFlagMask = 0x0400;
        public const int OverflowFlagMask = 0x0800;
    }
}
