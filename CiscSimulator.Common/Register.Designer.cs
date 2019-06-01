using System.Diagnostics.CodeAnalysis;

namespace CiscSimulator.Common
{
    partial class Register
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
            this.textBoxLoByte = new System.Windows.Forms.TextBox();
            this.textBoxHiByte = new System.Windows.Forms.TextBox();
            this.labelRegisterName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxLoByte
            // 
            this.textBoxLoByte.Location = new System.Drawing.Point(120, 1);
            this.textBoxLoByte.Name = "textBoxLoByte";
            this.textBoxLoByte.ReadOnly = true;
            this.textBoxLoByte.Size = new System.Drawing.Size(65, 20);
            this.textBoxLoByte.TabIndex = 6;
            // 
            // textBoxHiByte
            // 
            this.textBoxHiByte.Location = new System.Drawing.Point(49, 1);
            this.textBoxHiByte.Name = "textBoxHiByte";
            this.textBoxHiByte.ReadOnly = true;
            this.textBoxHiByte.Size = new System.Drawing.Size(65, 20);
            this.textBoxHiByte.TabIndex = 5;
            // 
            // labelRegisterName
            // 
            this.labelRegisterName.AutoSize = true;
            this.labelRegisterName.Location = new System.Drawing.Point(8, 4);
            this.labelRegisterName.Name = "labelRegisterName";
            this.labelRegisterName.Size = new System.Drawing.Size(21, 13);
            this.labelRegisterName.TabIndex = 4;
            this.labelRegisterName.Text = "R0";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxLoByte);
            this.Controls.Add(this.textBoxHiByte);
            this.Controls.Add(this.labelRegisterName);
            this.Name = "Register";
            this.Size = new System.Drawing.Size(200, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLoByte;
        private System.Windows.Forms.TextBox textBoxHiByte;
        private System.Windows.Forms.Label labelRegisterName;
    }
}
