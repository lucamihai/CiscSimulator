using System.Drawing;
using System.Windows.Forms;
using CiscSimulator.Common;
using CiscSimulator.Common.Enums;

namespace CiscSimulator
{
    public partial class Form1 : Form
    {
        private Timer timerDraw;

        private Line lineDataIn;
        private Line lineDataOut;
        private Line lineAddress;
        private Memory.Memory memory;

        private Register registerBinaryTest;
        private Register registerDecimalTest;

        public Form1()
        {
            InitializeComponent();
            InitializeTimer();

            lineDataIn = new Line(new Point(10, 10), new Point(100, 10));
            lineDataOut = new Line(new Point(250, 10), new Point(340, 10));
            lineAddress = new Line(new Point(10, 100), new Point(100, 100));

            memory = new Memory.Memory(0, 10);
            memory.Location = new Point(100, 10);
            Controls.Add(memory);

            registerBinaryTest = new Register("R0");
            registerBinaryTest.ValueDisplayMode = ValueDisplayMode.Binary;
            registerBinaryTest.Location = new Point(200, 200);
            Controls.Add(registerBinaryTest);

            registerDecimalTest = new Register("R1");
            registerDecimalTest.ValueDisplayMode = ValueDisplayMode.Decimal;
            registerDecimalTest.Location = new Point(200, 225);
            Controls.Add(registerDecimalTest);

            timerDraw.Start();
        }

        private void InitializeTimer()
        {
            timerDraw = new Timer();
            timerDraw.Interval = 100;
            timerDraw.Tick += TimerDrawTick;
        }

        private void TimerDrawTick(object sender, System.EventArgs e)
        {
            Refresh();
            registerBinaryTest.Data.Value++;
            registerDecimalTest.Data.Value++;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            lineDataIn.Draw(e);
            lineDataOut.Draw(e);
            lineAddress.Draw(e);
        }
    }
}
