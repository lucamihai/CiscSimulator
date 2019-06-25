namespace CiscSimulator
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLoadAsmFile = new System.Windows.Forms.Button();
            this.textBoxLoadedAsmFile = new System.Windows.Forms.TextBox();
            this.textBoxParsedCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelParsedContents = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonLoadAsmFile
            // 
            this.buttonLoadAsmFile.Location = new System.Drawing.Point(15, 25);
            this.buttonLoadAsmFile.Name = "buttonLoadAsmFile";
            this.buttonLoadAsmFile.Size = new System.Drawing.Size(95, 23);
            this.buttonLoadAsmFile.TabIndex = 0;
            this.buttonLoadAsmFile.Text = "Load .asm file";
            this.buttonLoadAsmFile.UseVisualStyleBackColor = true;
            this.buttonLoadAsmFile.Click += new System.EventHandler(this.LoadAsmFile);
            // 
            // textBoxLoadedAsmFile
            // 
            this.textBoxLoadedAsmFile.Location = new System.Drawing.Point(12, 67);
            this.textBoxLoadedAsmFile.Multiline = true;
            this.textBoxLoadedAsmFile.Name = "textBoxLoadedAsmFile";
            this.textBoxLoadedAsmFile.ReadOnly = true;
            this.textBoxLoadedAsmFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLoadedAsmFile.Size = new System.Drawing.Size(331, 371);
            this.textBoxLoadedAsmFile.TabIndex = 1;
            // 
            // textBoxParsedCode
            // 
            this.textBoxParsedCode.Location = new System.Drawing.Point(364, 67);
            this.textBoxParsedCode.Multiline = true;
            this.textBoxParsedCode.Name = "textBoxParsedCode";
            this.textBoxParsedCode.ReadOnly = true;
            this.textBoxParsedCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxParsedCode.Size = new System.Drawing.Size(331, 371);
            this.textBoxParsedCode.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "File contents";
            // 
            // labelParsedContents
            // 
            this.labelParsedContents.AutoSize = true;
            this.labelParsedContents.Location = new System.Drawing.Point(361, 51);
            this.labelParsedContents.Name = "labelParsedContents";
            this.labelParsedContents.Size = new System.Drawing.Size(84, 13);
            this.labelParsedContents.TabIndex = 5;
            this.labelParsedContents.Text = "Parsed contents";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelParsedContents);
            this.Controls.Add(this.textBoxParsedCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLoadedAsmFile);
            this.Controls.Add(this.buttonLoadAsmFile);
            this.Name = "MainWindow";
            this.Text = "Cisc Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadAsmFile;
        private System.Windows.Forms.TextBox textBoxLoadedAsmFile;
        private System.Windows.Forms.TextBox textBoxParsedCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelParsedContents;
    }
}

