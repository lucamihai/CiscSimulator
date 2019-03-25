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

            // General registers - properties test
            generalRegisters.R0.LoByte = 25;
            generalRegisters.R0.HiByte = 50;

            // General registers - [] operator test
            generalRegisters[1].LoByte = 2;
            generalRegisters[1].HiByte = 4;

        }
    }
}
