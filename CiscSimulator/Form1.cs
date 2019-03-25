using System.Drawing;
using System.Windows.Forms;
using CiscSimulator.UserControls;

namespace CiscSimulator
{
    public partial class Form1 : Form
    {
        private GeneralRegisters generalRegisters;

        public Form1()
        {
            InitializeComponent();

            generalRegisters = new GeneralRegisters {Location = new Point(25, 25)};
            Controls.Add(generalRegisters);
        }
    }
}
