using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CiscSimulator.Common;
using CiscSimulator.Common.Enums;

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
            sequencer.BorderStyle = BorderStyle.FixedSingle;
        }

        private void LoadAsmFile(object sender, EventArgs e)
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
                        UpdateTextBoxLoadedAsmFile(fileContents);
                        assembler.ParseText(fileContents);
                    }
                }
            }

            UpdateTextBoxParsedFile();
        }

        private void UpdateTextBoxLoadedAsmFile(string fileContents)
        {
            var lines = fileContents.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );

            textBoxLoadedAsmFile.Text = string.Empty;

            for (int index = 0; index < lines.Length; index++)
            {
                var line = lines[index];
                var lineNumber = index + 1;

                textBoxLoadedAsmFile.Text += $"{lineNumber}. {line}{Environment.NewLine}";
            }
        }

        private void UpdateTextBoxParsedFile()
        {
            if (assembler.Lines.Count == 0)
            {
                textBoxParsedCode.Text = "File couldn't be parsed";
            }

            textBoxParsedCode.Text = string.Empty;

            for (int index = 0; index < assembler.Lines.Count; index++)
            {
                var line = assembler.Lines[index].ToUpper();
                var lineNumber = index + 1;

                textBoxParsedCode.Text += $"{lineNumber}. {line}{Environment.NewLine}";
            }
        }

        private void ObserveInstructions(object sender, EventArgs e)
        {
            this.Size = new Size(1024, Constants.MainWindowInitialSize.Height);
            DisableExtensionButtons();

            Controls.Add(buttonCloseExtenstion);

            var textBoxInstructionData = new TextBox();
            textBoxInstructionData.Size = new Size(250, 375);
            textBoxInstructionData.ReadOnly = true;
            textBoxInstructionData.Multiline = true;
            textBoxInstructionData.Font = new Font(FontFamily.GenericSerif, 11f);
            textBoxInstructionData.Text = GetInstructionDataStringRepresentation();
            textBoxInstructionData.ScrollBars = ScrollBars.Both;

            Controls.Add(panelExtension);
            panelExtension.Location = new Point(590, 67);
            panelExtension.Size = textBoxInstructionData.Size;

            panelExtension.Controls.Add(textBoxInstructionData);
        }

        private string GetInstructionDataStringRepresentation()
        {
            var stringRepresentation = string.Empty;

            for (var index = 0; index < assembler.Instructions.Count; index++)
            {
                var instruction = assembler.Instructions[index];
                var instructionNumber = index + 1;
                stringRepresentation += $"{instructionNumber}-----------------------{Environment.NewLine}";

                foreach (var data in instruction.Data)
                {
                    stringRepresentation += $"{data}{Environment.NewLine}";
                }

                stringRepresentation += $"{Environment.NewLine}";
            }

            return stringRepresentation;
        }

        private void LoadInstructionsInSequencer(object sender, EventArgs e)
        {
            sequencer.LoadInstructionsInMemory(assembler.Instructions);
        }

        private void ObserveSequencer(object sender, EventArgs e)
        {
            this.Size = new Size(1920, 1024);
            DisableExtensionButtons();

            Controls.Add(buttonCloseExtenstion);

            Controls.Add(panelExtension);
            panelExtension.Size = sequencer.Size;
            panelExtension.Location = new Point(590, 67);
            panelExtension.Controls.Add(sequencer);

            var panelForSelectingValueDisplayModeForSequencer = GetPanelForSelectingValueDisplayModeForSequencer();
            panelForSelectingValueDisplayModeForSequencer.Location = new Point(panelExtension.Location.X + panelExtension.Width, panelExtension.Location.Y);
            this.Controls.Add(panelForSelectingValueDisplayModeForSequencer);

            var buttonForSequencerNextStep = GetButtonForSequencerNextStep();
            buttonForSequencerNextStep.Location = new Point(
                panelForSelectingValueDisplayModeForSequencer.Location.X, 
                panelForSelectingValueDisplayModeForSequencer.Location.Y + panelForSelectingValueDisplayModeForSequencer.Height
            );
            this.Controls.Add(buttonForSequencerNextStep);
        }

        private Panel GetPanelForSelectingValueDisplayModeForSequencer()
        {
            var panel = new Panel();

            var radioButtonValueDisplayModeBinary = new RadioButton();
            radioButtonValueDisplayModeBinary.Text = "Binary";
            radioButtonValueDisplayModeBinary.Location = new Point(0, 0);
            radioButtonValueDisplayModeBinary.Checked = true;
            radioButtonValueDisplayModeBinary.CheckedChanged += (sender, args) =>
            {
                if (radioButtonValueDisplayModeBinary.Checked)
                    sequencer.ValueDisplayMode = ValueDisplayMode.Binary;
            };

            var radioButtonValueDisplayModeDecimal = new RadioButton();
            radioButtonValueDisplayModeDecimal.Text = "Decimal";
            radioButtonValueDisplayModeDecimal.Location = new Point(0, 20);
            radioButtonValueDisplayModeDecimal.CheckedChanged += (sender, args) =>
            {
                if (radioButtonValueDisplayModeDecimal.Checked)
                    sequencer.ValueDisplayMode = ValueDisplayMode.Decimal;
            };

            var radioButtonValueDisplayModeHexadecimal = new RadioButton();
            radioButtonValueDisplayModeHexadecimal.Text = "Hexadecimal";
            radioButtonValueDisplayModeHexadecimal.Location = new Point(0, 40);
            radioButtonValueDisplayModeHexadecimal.CheckedChanged += (sender, args) =>
            {
                if (radioButtonValueDisplayModeHexadecimal.Checked)
                    sequencer.ValueDisplayMode = ValueDisplayMode.Hexadecimal;
            };

            panel.Controls.Add(radioButtonValueDisplayModeBinary);
            panel.Controls.Add(radioButtonValueDisplayModeDecimal);
            panel.Controls.Add(radioButtonValueDisplayModeHexadecimal);

            return panel;
        }

        private Button GetButtonForSequencerNextStep()
        {
            var button = new Button();
            button.Text = "Next step";
            button.Click += (sender, args) => sequencer.NextStep();

            return button;
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
