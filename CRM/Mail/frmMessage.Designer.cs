namespace CRM.GUI.Mail
{
    partial class frmMessage
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
            this.txtMailAddress = new System.Windows.Forms.TextBox();
            this.txtTittle = new System.Windows.Forms.TextBox();
            this.txtMessText = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // txtMailAddress
            // 
            this.txtMailAddress.Location = new System.Drawing.Point(43, 12);
            this.txtMailAddress.Name = "txtMailAddress";
            this.txtMailAddress.Size = new System.Drawing.Size(689, 20);
            this.txtMailAddress.TabIndex = 0;
            // 
            // txtTittle
            // 
            this.txtTittle.Location = new System.Drawing.Point(43, 38);
            this.txtTittle.Name = "txtTittle";
            this.txtTittle.Size = new System.Drawing.Size(689, 20);
            this.txtTittle.TabIndex = 1;
            // 
            // txtMessText
            // 
            this.txtMessText.Location = new System.Drawing.Point(43, 64);
            this.txtMessText.Multiline = true;
            this.txtMessText.Name = "txtMessText";
            this.txtMessText.Size = new System.Drawing.Size(689, 230);
            this.txtMessText.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(43, 300);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(689, 97);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // frmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 404);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtMessText);
            this.Controls.Add(this.txtTittle);
            this.Controls.Add(this.txtMailAddress);
            this.Name = "frmMessage";
            this.Text = "frmMessage";
            this.Load += new System.EventHandler(this.frmMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMailAddress;
        private System.Windows.Forms.TextBox txtTittle;
        private System.Windows.Forms.TextBox txtMessText;
        private System.Windows.Forms.ListView listView1;
    }
}