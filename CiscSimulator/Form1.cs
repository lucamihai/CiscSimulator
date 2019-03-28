using System.Drawing;
using System.Windows.Forms;
using CiscSimulator.Common;

namespace CiscSimulator
{
    public partial class Form1 : Form
    {
        private Timer timerDraw;

        private Line lineDataIn;
        private Line lineDataOut;
        private Line lineAddress;
        private Memory.Memory memory;

        public Form1()
        {
            InitializeComponent();

            timerDraw = new Timer();
            timerDraw.Interval = 100;
            timerDraw.Tick += TimerDrawTick;
            timerDraw.Start();

            lineDataIn = new Line(new Point(10, 10), new Point(100, 10));
            lineDataOut = new Line(new Point(250, 10), new Point(340, 10));
            lineAddress = new Line(new Point(10, 100), new Point(100, 100));

            memory = new Memory.Memory(lineDataIn, lineDataOut, lineAddress);
            memory.Location = new Point(100, 10);
            Controls.Add(memory);

            lineDataIn.Data.LoByte = 10;
            lineDataIn.Data.HiByte = 15;
        }

        private void TimerDrawTick(object sender, System.EventArgs e)
        {
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            lineDataIn.Draw(e);
            lineDataOut.Draw(e);
            lineAddress.Draw(e);
        }
    }
}
