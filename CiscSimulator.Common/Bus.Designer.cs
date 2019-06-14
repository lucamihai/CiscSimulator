using System.Diagnostics.CodeAnalysis;

namespace CiscSimulator.Common
{
    partial class Bus
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
            this.labelBusName = new System.Windows.Forms.Label();
            this.textBoxLoByte = new System.Windows.Forms.TextBox();
            this.textBoxHiByte = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelBusName
            // 
            this.labelBusName.AutoSize = true;
            this.labelBusName.Location = new System.Drawing.Point(52, 6);
            this.labelBusName.Name = "labelBusName";
            this.labelBusName.Size = new System.Drawing.Size(54, 13);
            this.labelBusName.TabIndex = 0;
            this.labelBusName.Text = "Bus name";
            // 
            // textBoxLoByte
            // 
            this.textBoxLoByte.Location = new System.Drawing.Point(82, 22);
            this.textBoxLoByte.Name = "textBoxLoByte";
            this.textBoxLoByte.ReadOnly = true;
            this.textBoxLoByte.Size = new System.Drawing.Size(65, 20);
            this.textBoxLoByte.TabIndex = 8;
            // 
            // textBoxHiByte
            // 
            this.textBoxHiByte.Location = new System.Drawing.Point(11, 22);
            this.textBoxHiByte.Name = "textBoxHiByte";
            this.textBoxHiByte.ReadOnly = true;
            this.textBoxHiByte.Size = new System.Drawing.Size(65, 20);
            this.textBoxHiByte.TabIndex = 7;
            // 
            // Bus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxLoByte);
            this.Controls.Add(this.textBoxHiByte);
            this.Controls.Add(this.labelBusName);
            this.Name = "Bus";
            this.Size = new System.Drawing.Size(164, 53);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBusName;
        private System.Windows.Forms.TextBox textBoxLoByte;
        private System.Windows.Forms.TextBox textBoxHiByte;
    }
}
