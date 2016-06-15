namespace CRM.GUI.Mail
{
    partial class frmInbox
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
            this.components = new System.ComponentModel.Container();
            this.cRMDataSet = new global::CRM.GUI.CRMDataSet();
            this.uSERSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSERSTableAdapter = new global::CRM.GUI.CRMDataSetTableAdapters.USERSTableAdapter();
            this.lvInbox = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.cRMDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSERSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cRMDataSet
            // 
            this.cRMDataSet.DataSetName = "CRMDataSet";
            this.cRMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSERSBindingSource
            // 
            this.uSERSBindingSource.DataMember = "USERS";
            this.uSERSBindingSource.DataSource = this.cRMDataSet;
            // 
            // uSERSTableAdapter
            // 
            this.uSERSTableAdapter.ClearBeforeFill = true;
            // 
            // lvInbox
            // 
            this.lvInbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvInbox.Location = new System.Drawing.Point(0, 0);
            this.lvInbox.Name = "lvInbox";
            this.lvInbox.Size = new System.Drawing.Size(815, 316);
            this.lvInbox.TabIndex = 0;
            this.lvInbox.UseCompatibleStateImageBehavior = false;
            this.lvInbox.DoubleClick += new System.EventHandler(this.lvInbox_DoubleClick);
            // 
            // frmInbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 316);
            this.Controls.Add(this.lvInbox);
            this.Name = "frmInbox";
            this.Text = "Skrzynka odbiorcza";
            this.Load += new System.EventHandler(this.Inbox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cRMDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSERSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CRMDataSet cRMDataSet;
        private System.Windows.Forms.BindingSource uSERSBindingSource;
        private CRMDataSetTableAdapters.USERSTableAdapter uSERSTableAdapter;
        private System.Windows.Forms.ListView lvInbox;
    }
}