namespace CiscSimulator.Sequencer
{
    public static class Locations
    {
        public const int FirstColumn = 0;
        public const int SecondColumn = 450;
        public const int ThirdColumn = 900;

        public const int SBusColumn = (FirstColumn + SecondColumn) / 2 - 10;
        public const int DBusColumn = (FirstColumn + SecondColumn) / 2 + 10;
    }
}
