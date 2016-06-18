namespace CRM.GUI.Mail
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txtTittle = new System.Windows.Forms.TextBox();
            this.btnClient = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.lvAttachments = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnZalacz = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(153, 12);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(337, 20);
            this.txtAddress.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(508, 267);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Wyślij";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtTittle
            // 
            this.txtTittle.Location = new System.Drawing.Point(153, 38);
            this.txtTittle.Name = "txtTittle";
            this.txtTittle.Size = new System.Drawing.Size(430, 20);
            this.txtTittle.TabIndex = 2;
            // 
            // btnClient
            // 
            this.btnClient.Location = new System.Drawing.Point(545, 12);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(38, 20);
            this.btnClient.TabIndex = 1;
            this.btnClient.Text = "...";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(153, 64);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(430, 128);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.Text = "";
            // 
            // lvAttachments
            // 
            this.lvAttachments.Location = new System.Drawing.Point(153, 198);
            this.lvAttachments.MultiSelect = false;
            this.lvAttachments.Name = "lvAttachments";
            this.lvAttachments.Size = new System.Drawing.Size(430, 63);
            this.lvAttachments.TabIndex = 5;
            this.lvAttachments.UseCompatibleStateImageBehavior = false;
            this.lvAttachments.View = System.Windows.Forms.View.SmallIcon;
            this.lvAttachments.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvAttachments_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Adres:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Temat:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Treść:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Treść:";
            // 
            // btnZalacz
            // 
            this.btnZalacz.Location = new System.Drawing.Point(24, 238);
            this.btnZalacz.Name = "btnZalacz";
            this.btnZalacz.Size = new System.Drawing.Size(75, 23);
            this.btnZalacz.TabIndex = 4;
            this.btnZalacz.Text = "Załącz plik";
            this.btnZalacz.UseVisualStyleBackColor = true;
            this.btnZalacz.Click += new System.EventHandler(this.btnZalacz_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // frmSendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(598, 299);
            this.Controls.Add(this.btnZalacz);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvAttachments);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.txtTittle);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtAddress);
            this.Name = "frmSendMail";
            this.Text = "Wyślij wiadomość";
            this.Load += new System.EventHandler(this.frmSendMail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtTittle;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.ListView lvAttachments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnZalacz;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}