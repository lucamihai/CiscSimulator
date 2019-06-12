using System.Windows.Forms;

namespace CiscSimulator.Sequencer
{
    public partial class Sequencer : UserControl
    {
        public Memory.Memory memoryMpm { get; }

        public Sequencer()
        {
            InitializeComponent();
        }
    }
}
