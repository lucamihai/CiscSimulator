using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows.Forms;

namespace CiscSimulator
{
    [ExcludeFromCodeCoverage]
    public partial class MainWindow : Form
    {
        private Assembler.Assembler assembler;
        private Sequencer.Sequencer sequencer;

        public MainWindow()
        {
            InitializeComponent();
            InitializeAssembler();
            InitializeSequencer();
        }

        private void InitializeAssembler()
        {
            assembler = new Assembler.Assembler();
        }

        private void InitializeSequencer()
        {
            sequencer = new Sequencer.Sequencer();
        }

        private void LoadAsmFile(object sender, System.EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Browse json file";
                openFileDialog.DefaultExt = "asm";
                openFileDialog.Filter = "asm files (*.asm) | *.asm";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileStream = openFileDialog.OpenFile();

                    using (var streamReader = new StreamReader(fileStream))
                    {
                        var fileContents = streamReader.ReadToEnd();
                        textBoxLoadedAsmFile.Text = fileContents;

                        assembler.ParseText(fileContents);
                    }
                }
            }

            UpdateTextBoxParsedFile();
        }

        private void UpdateTextBoxParsedFile()
        {
            if (assembler.Lines.Count == 0)
            {
                textBoxParsedCode.Text = "File couldn't be parsed";
            }

            var text = string.Empty;
            foreach (var line in assembler.Lines)
            {
                text += $"{line}{Environment.NewLine}";
            }

            textBoxParsedCode.Text = text;
        }
    }
}
