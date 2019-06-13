using System.Windows.Forms;

namespace CiscSimulator.Sequencer
{
    public partial class Sequencer : UserControl
    {
        public MpmMemory MpmMemory { get; private set; }

        public Sequencer()
        {
            InitializeComponent();
            InitializeMpmMemory();
        }

        private void InitializeMpmMemory()
        {
            MpmMemory = new MpmMemory();
        }
    }
}
