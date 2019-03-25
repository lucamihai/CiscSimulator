namespace CiscSimulator.UserControls
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
        private void InitializeComponent()
        {
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.labelRegisterName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(38, 1);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.ReadOnly = true;
            this.textBoxValue.Size = new System.Drawing.Size(105, 20);
            this.textBoxValue.TabIndex = 0;
            this.textBoxValue.Text = "0000000000000000";
            this.textBoxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelRegisterName
            // 
            this.labelRegisterName.AutoSize = true;
            this.labelRegisterName.Location = new System.Drawing.Point(3, 4);
            this.labelRegisterName.Name = "labelRegisterName";
            this.labelRegisterName.Size = new System.Drawing.Size(21, 13);
            this.labelRegisterName.TabIndex = 1;
            this.labelRegisterName.Text = "R1";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelRegisterName);
            this.Controls.Add(this.textBoxValue);
            this.Name = "Register";
            this.Size = new System.Drawing.Size(148, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Label labelRegisterName;
    }
}
