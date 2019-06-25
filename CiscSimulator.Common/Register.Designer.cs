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
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.labelRegisterName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(36, 0);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.ReadOnly = true;
            this.textBoxValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxValue.Size = new System.Drawing.Size(148, 20);
            this.textBoxValue.TabIndex = 5;
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
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.labelRegisterName);
            this.Name = "Register";
            this.Size = new System.Drawing.Size(190, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Label labelRegisterName;
    }
}
