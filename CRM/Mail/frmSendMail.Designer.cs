namespace CRM.Mail
{
    partial class frmSendMail
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
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtMailText = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtTittle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(75, 31);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(100, 20);
            this.txtAddress.TabIndex = 0;
            // 
            // txtMailText
            // 
            this.txtMailText.Location = new System.Drawing.Point(60, 125);
            this.txtMailText.Multiline = true;
            this.txtMailText.Name = "txtMailText";
            this.txtMailText.Size = new System.Drawing.Size(388, 159);
            this.txtMailText.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(607, 152);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "btnSend";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtTittle
            // 
            this.txtTittle.Location = new System.Drawing.Point(75, 67);
            this.txtTittle.Name = "txtTittle";
            this.txtTittle.Size = new System.Drawing.Size(100, 20);
            this.txtTittle.TabIndex = 3;
            // 
            // frmSendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 387);
            this.Controls.Add(this.txtTittle);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMailText);
            this.Controls.Add(this.txtAddress);
            this.Name = "frmSendMail";
            this.Text = "SendMail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtMailText;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtTittle;
    }
}