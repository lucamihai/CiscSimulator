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
            this.labelRegisterName = new System.Windows.Forms.Label();
            this.textBoxHiByte = new System.Windows.Forms.TextBox();
            this.textBoxLoByte = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
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
            // textBoxHiByte
            // 
            this.textBoxHiByte.Location = new System.Drawing.Point(44, 1);
            this.textBoxHiByte.Name = "textBoxHiByte";
            this.textBoxHiByte.ReadOnly = true;
            this.textBoxHiByte.Size = new System.Drawing.Size(65, 20);
            this.textBoxHiByte.TabIndex = 2;
            // 
            // textBoxLoByte
            // 
            this.textBoxLoByte.Location = new System.Drawing.Point(115, 1);
            this.textBoxLoByte.Name = "textBoxLoByte";
            this.textBoxLoByte.ReadOnly = true;
            this.textBoxLoByte.Size = new System.Drawing.Size(65, 20);
            this.textBoxLoByte.TabIndex = 3;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.textBoxLoByte);
            this.Controls.Add(this.textBoxHiByte);
            this.Controls.Add(this.labelRegisterName);
            this.Name = "Register";
            this.Size = new System.Drawing.Size(200, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelRegisterName;
        private System.Windows.Forms.TextBox textBoxHiByte;
        private System.Windows.Forms.TextBox textBoxLoByte;
    }
}
