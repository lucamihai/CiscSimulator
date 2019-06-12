using System.Collections.Generic;

namespace CiscSimulator.Sequencer
{
    public class MpmMemory
    {
        private Dictionary<short, MpmData> mpmDataDictionary;

        public MpmMemory()
        {
            mpmDataDictionary = new Dictionary<short, MpmData>();
        }
    }
}
