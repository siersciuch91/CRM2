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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessage));
            this.txtMailAddressFrom = new System.Windows.Forms.TextBox();
            this.txtTittle = new System.Windows.Forms.TextBox();
            this.txtMessText = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMailAddressTo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMailAddressFrom
            // 
            this.txtMailAddressFrom.Location = new System.Drawing.Point(80, 12);
            this.txtMailAddressFrom.Name = "txtMailAddressFrom";
            this.txtMailAddressFrom.Size = new System.Drawing.Size(664, 20);
            this.txtMailAddressFrom.TabIndex = 0;
            // 
            // txtTittle
            // 
            this.txtTittle.Location = new System.Drawing.Point(80, 71);
            this.txtTittle.Name = "txtTittle";
            this.txtTittle.Size = new System.Drawing.Size(664, 20);
            this.txtTittle.TabIndex = 1;
            // 
            // txtMessText
            // 
            this.txtMessText.Location = new System.Drawing.Point(80, 97);
            this.txtMessText.Multiline = true;
            this.txtMessText.Name = "txtMessText";
            this.txtMessText.Size = new System.Drawing.Size(664, 230);
            this.txtMessText.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(80, 333);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(664, 97);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Od:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Załączniki:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Treść:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Temat:";
            // 
            // btnAddClient
            // 
            this.btnAddClient.Image = global::CRM.GUI.Properties.Resources.addUser;
            this.btnAddClient.Location = new System.Drawing.Point(2, 145);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(76, 76);
            this.btnAddClient.TabIndex = 14;
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Do:";
            // 
            // txtMailAddressTo
            // 
            this.txtMailAddressTo.Location = new System.Drawing.Point(80, 38);
            this.txtMailAddressTo.Name = "txtMailAddressTo";
            this.txtMailAddressTo.Size = new System.Drawing.Size(664, 20);
            this.txtMailAddressTo.TabIndex = 15;
            // 
            // frmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 442);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMailAddressTo);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtMessText);
            this.Controls.Add(this.txtTittle);
            this.Controls.Add(this.txtMailAddressFrom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMessage";
            this.Text = "Wiadomość";
            this.Load += new System.EventHandler(this.frmMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMailAddressFrom;
        private System.Windows.Forms.TextBox txtTittle;
        private System.Windows.Forms.TextBox txtMessText;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMailAddressTo;
    }
}