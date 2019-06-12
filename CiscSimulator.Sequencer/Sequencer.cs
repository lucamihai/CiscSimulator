using System.Windows.Forms;

namespace CiscSimulator.Sequencer
{
    public partial class Sequencer : UserControl
    {
        public Memory.Memory MemoryMpm { get; private set; }

        public Sequencer()
        {
            InitializeComponent();
            InitializeMemoryMpm();
        }

        private void InitializeMemoryMpm()
        {
            MemoryMpm = new Memory.Memory(0, 200 * 3, true);

        }
    }
}
