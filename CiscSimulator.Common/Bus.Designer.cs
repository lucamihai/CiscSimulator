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
            this.textBoxValue = new System.Windows.Forms.TextBox();
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
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(12, 22);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.ReadOnly = true;
            this.textBoxValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxValue.Size = new System.Drawing.Size(137, 20);
            this.textBoxValue.TabIndex = 7;
            // 
            // Bus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.labelBusName);
            this.Name = "Bus";
            this.Size = new System.Drawing.Size(164, 53);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBusName;
        private System.Windows.Forms.TextBox textBoxValue;
    }
}
