using System.Diagnostics.CodeAnalysis;

namespace CiscSimulator.ArithmeticLogicUnit
{
    partial class ArithmeticLogicUnit
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
            this.labelS = new System.Windows.Forms.Label();
            this.labelD = new System.Windows.Forms.Label();
            this.labelR = new System.Windows.Forms.Label();
            this.labelALU = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelS
            // 
            this.labelS.AutoSize = true;
            this.labelS.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelS.Location = new System.Drawing.Point(3, 9);
            this.labelS.Name = "labelS";
            this.labelS.Size = new System.Drawing.Size(18, 19);
            this.labelS.TabIndex = 0;
            this.labelS.Text = "S";
            // 
            // labelD
            // 
            this.labelD.AutoSize = true;
            this.labelD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelD.Location = new System.Drawing.Point(3, 61);
            this.labelD.Name = "labelD";
            this.labelD.Size = new System.Drawing.Size(21, 19);
            this.labelD.TabIndex = 1;
            this.labelD.Text = "D";
            // 
            // labelR
            // 
            this.labelR.AutoSize = true;
            this.labelR.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR.Location = new System.Drawing.Point(99, 33);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(21, 19);
            this.labelR.TabIndex = 2;
            this.labelR.Text = "R";
            // 
            // labelALU
            // 
            this.labelALU.AutoSize = true;
            this.labelALU.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelALU.Location = new System.Drawing.Point(37, 33);
            this.labelALU.Name = "labelALU";
            this.labelALU.Size = new System.Drawing.Size(41, 19);
            this.labelALU.TabIndex = 3;
            this.labelALU.Text = "ALU";
            // 
            // ArithmeticLogicUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelALU);
            this.Controls.Add(this.labelR);
            this.Controls.Add(this.labelD);
            this.Controls.Add(this.labelS);
            this.Name = "ArithmeticLogicUnit";
            this.Size = new System.Drawing.Size(124, 88);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelS;
        private System.Windows.Forms.Label labelD;
        private System.Windows.Forms.Label labelR;
        private System.Windows.Forms.Label labelALU;
    }
}
