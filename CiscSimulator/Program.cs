using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace CiscSimulator
{
    static class Program
    {
        [STAThread]
        [ExcludeFromCodeCoverage]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
