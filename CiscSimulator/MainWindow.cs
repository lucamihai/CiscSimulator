using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CiscSimulator
{
    [ExcludeFromCodeCoverage]
    public partial class MainWindow : Form
    {
        private Assembler.Assembler assembler;
        private Sequencer.Sequencer sequencer;

        private readonly Panel panelExtension;

        private readonly Button buttonCloseExtenstion;

        public MainWindow()
        {
            InitializeComponent();
            InitializeAssembler();
            InitializeSequencer();

            panelExtension = new Panel();

            buttonCloseExtenstion = new Button();
            buttonCloseExtenstion.Click += CloseExtension;
            buttonCloseExtenstion.Text = "Close extension";
            buttonCloseExtenstion.Size = new Size(100, 25);
            buttonCloseExtenstion.Location = new Point(590, 25);
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

        private void ObserveInstructions(object sender, EventArgs e)
        {
            this.Size = new Size(1024, 1024);
            DisableExtensionButtons();

            Controls.Add(buttonCloseExtenstion);

            Controls.Add(panelExtension);
            panelExtension.Location = new Point(590, 67);

            //TODO
        }

        private void LoadInstructionsInSequencer(object sender, EventArgs e)
        {
            //TODO
        }

        private void ObserveSequencer(object sender, EventArgs e)
        {
            this.Size = new Size(1920, 1024);
            DisableExtensionButtons();

            Controls.Add(buttonCloseExtenstion);

            Controls.Add(panelExtension);
            panelExtension.Location = new Point(590, 67);
            panelExtension.Controls.Add(sequencer);
            sequencer.BorderStyle = BorderStyle.Fixed3D;
        }

        private void CloseExtension(object sender, EventArgs e)
        {
            this.Size = Constants.MainWindowInitialSize;
            panelExtension.Controls.Clear();

            EnableExtensionButtons();
        }

        private void DisableExtensionButtons()
        {
            buttonObserveInstructions.Enabled = false;
            buttonObserveSequencer.Enabled = false;
        }

        private void EnableExtensionButtons()
        {
            buttonObserveInstructions.Enabled = true;
            buttonObserveSequencer.Enabled = true;
        }
    }
}
