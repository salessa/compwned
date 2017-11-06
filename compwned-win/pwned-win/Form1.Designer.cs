namespace pwned_win
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
            this.textPass = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textPass
            // 
            this.textPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPass.Location = new System.Drawing.Point(15, 38);
            this.textPass.Name = "textPass";
            this.textPass.PasswordChar = '*';
            this.textPass.Size = new System.Drawing.Size(505, 32);
            this.textPass.TabIndex = 1;
            this.textPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textPass.TextChanged += new System.EventHandler(this.textPass_TextChanged);
            this.textPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPass_KeyPress);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(534, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Check";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelResult
            // 
            this.labelResult.BackColor = System.Drawing.Color.RoyalBlue;
            this.labelResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult.ForeColor = System.Drawing.Color.White;
            this.labelResult.Location = new System.Drawing.Point(0, 99);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(641, 109);
            this.labelResult.TabIndex = 3;
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel.LinkColor = System.Drawing.Color.Azure;
            this.linkLabel.Location = new System.Drawing.Point(236, 156);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(169, 18);
            this.linkLabel.TabIndex = 5;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "haveibeenpwned.com";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Password:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(641, 208);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textPass);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ComPWNED Desktop (Beta)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.Label label1;
    }
}

