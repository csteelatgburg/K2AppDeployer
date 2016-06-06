namespace K2AppDeployer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.K2HostName = new System.Windows.Forms.TextBox();
            this.K2SAMBAPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "K2 Hostname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "SAMBA Password";
            // 
            // K2HostName
            // 
            this.K2HostName.Location = new System.Drawing.Point(268, 32);
            this.K2HostName.Name = "K2HostName";
            this.K2HostName.Size = new System.Drawing.Size(407, 31);
            this.K2HostName.TabIndex = 2;
            // 
            // K2SAMBAPass
            // 
            this.K2SAMBAPass.Location = new System.Drawing.Point(269, 88);
            this.K2SAMBAPass.Name = "K2SAMBAPass";
            this.K2SAMBAPass.PasswordChar = '*';
            this.K2SAMBAPass.Size = new System.Drawing.Size(405, 31);
            this.K2SAMBAPass.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 624);
            this.Controls.Add(this.K2SAMBAPass);
            this.Controls.Add(this.K2HostName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "K2 App Deployer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox K2HostName;
        private System.Windows.Forms.TextBox K2SAMBAPass;
    }
}

