namespace CRM.GUI.Mail
{
    partial class frmMessages
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
            this.lvInbox = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvInbox
            // 
            this.lvInbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvInbox.Location = new System.Drawing.Point(0, 0);
            this.lvInbox.Name = "lvInbox";
            this.lvInbox.Size = new System.Drawing.Size(1064, 425);
            this.lvInbox.TabIndex = 1;
            this.lvInbox.UseCompatibleStateImageBehavior = false;
            this.lvInbox.DoubleClick += new System.EventHandler(this.lvInbox_DoubleClick);
            // 
            // frmMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 425);
            this.Controls.Add(this.lvInbox);
            this.Name = "frmMessages";
            this.Text = "Konwersacja";
            this.Load += new System.EventHandler(this.frmMessages_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView lvInbox;
    }
}