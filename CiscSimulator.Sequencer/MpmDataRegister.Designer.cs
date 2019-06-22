using System.Diagnostics.CodeAnalysis;

namespace CiscSimulator.Sequencer
{
    partial class MpmDataRegister
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        [ExcludeFromCodeCoverage]
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [ExcludeFromCodeCoverage]
        private void InitializeComponent()
        {
            this.labelRegisterName = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelRegisterName
            // 
            this.labelRegisterName.AutoSize = true;
            this.labelRegisterName.Location = new System.Drawing.Point(3, 5);
            this.labelRegisterName.Name = "labelRegisterName";
            this.labelRegisterName.Size = new System.Drawing.Size(27, 13);
            this.labelRegisterName.TabIndex = 5;
            this.labelRegisterName.Text = "MIR";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(36, 2);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.ReadOnly = true;
            this.textBoxValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxValue.Size = new System.Drawing.Size(361, 20);
            this.textBoxValue.TabIndex = 6;
            // 
            // MpmDataRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.labelRegisterName);
            this.Name = "MpmDataRegister";
            this.Size = new System.Drawing.Size(400, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRegisterName;
        private System.Windows.Forms.TextBox textBoxValue;
    }
}
