namespace CiscSimulator
{
    partial class Form1
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
            this.buttonChangeLine1State = new System.Windows.Forms.Button();
            this.buttonChangeLine2State = new System.Windows.Forms.Button();
            this.buttonChangeLine3State = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonChangeLine1State
            // 
            this.buttonChangeLine1State.Location = new System.Drawing.Point(65, 364);
            this.buttonChangeLine1State.Name = "buttonChangeLine1State";
            this.buttonChangeLine1State.Size = new System.Drawing.Size(115, 23);
            this.buttonChangeLine1State.TabIndex = 0;
            this.buttonChangeLine1State.Text = "Change Line 1 State";
            this.buttonChangeLine1State.UseVisualStyleBackColor = true;
            this.buttonChangeLine1State.Click += new System.EventHandler(this.buttonChangeLine1State_Click);
            // 
            // buttonChangeLine2State
            // 
            this.buttonChangeLine2State.Location = new System.Drawing.Point(208, 364);
            this.buttonChangeLine2State.Name = "buttonChangeLine2State";
            this.buttonChangeLine2State.Size = new System.Drawing.Size(115, 23);
            this.buttonChangeLine2State.TabIndex = 1;
            this.buttonChangeLine2State.Text = "Change Line 2 State";
            this.buttonChangeLine2State.UseVisualStyleBackColor = true;
            this.buttonChangeLine2State.Click += new System.EventHandler(this.buttonChangeLine2State_Click);
            // 
            // buttonChangeLine3State
            // 
            this.buttonChangeLine3State.Location = new System.Drawing.Point(344, 364);
            this.buttonChangeLine3State.Name = "buttonChangeLine3State";
            this.buttonChangeLine3State.Size = new System.Drawing.Size(115, 23);
            this.buttonChangeLine3State.TabIndex = 2;
            this.buttonChangeLine3State.Text = "Change Line 3 State";
            this.buttonChangeLine3State.UseVisualStyleBackColor = true;
            this.buttonChangeLine3State.Click += new System.EventHandler(this.buttonChangeLine3State_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Testing purposes only, will be removed";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonChangeLine3State);
            this.Controls.Add(this.buttonChangeLine2State);
            this.Controls.Add(this.buttonChangeLine1State);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonChangeLine1State;
        private System.Windows.Forms.Button buttonChangeLine2State;
        private System.Windows.Forms.Button buttonChangeLine3State;
        private System.Windows.Forms.Label label1;
    }
}

