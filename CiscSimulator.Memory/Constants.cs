using CiscSimulator.Common;

namespace CiscSimulator.Memory
{
    public static class Constants
    {
        public static readonly Data MinimumAddress = new Data {LoByte = 10, HiByte = 0};
        public static readonly Data MaximumAddress = new Data {LoByte = 0, HiByte = 10};
    }
}
