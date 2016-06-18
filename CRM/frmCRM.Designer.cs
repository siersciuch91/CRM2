namespace CRM.GUI
{
    partial class frmCRM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCRM));
            this.notifyCRM = new System.Windows.Forms.NotifyIcon(this.components);
            this.conMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.cmInbox = new System.Windows.Forms.ToolStripMenuItem();
            this.cmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonOrbMenuItem1 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbon = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnInbox = new System.Windows.Forms.RibbonButton();
            this.btnSendBox = new System.Windows.Forms.RibbonButton();
            this.btnNew = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonEwidencja = new System.Windows.Forms.RibbonTab();
            this.ribbonForm = new System.Windows.Forms.RibbonPanel();
            this.btnFirm = new System.Windows.Forms.RibbonButton();
            this.btnClient = new System.Windows.Forms.RibbonButton();
            this.ribbonAkcje = new System.Windows.Forms.RibbonPanel();
            this.btnNowy = new System.Windows.Forms.RibbonButton();
            this.btnModyfikuj = new System.Windows.Forms.RibbonButton();
            this.btnUsun = new System.Windows.Forms.RibbonButton();
            this.rbnFunMail = new System.Windows.Forms.RibbonPanel();
            this.btnRefresh = new System.Windows.Forms.RibbonButton();
            this.btnDelete = new System.Windows.Forms.RibbonButton();
            this.conMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyCRM
            // 
            this.notifyCRM.ContextMenuStrip = this.conMenu;
            this.notifyCRM.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyCRM.Icon")));
            this.notifyCRM.Text = "CRM KA";
            this.notifyCRM.Visible = true;
            this.notifyCRM.DoubleClick += new System.EventHandler(this.notifyCRM_DoubleClick);
            // 
            // conMenu
            // 
            this.conMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmOpen,
            this.cmInbox,
            this.cmExit});
            this.conMenu.Name = "conMenu";
            this.conMenu.Size = new System.Drawing.Size(169, 70);
            // 
            // cmOpen
            // 
            this.cmOpen.Name = "cmOpen";
            this.cmOpen.Size = new System.Drawing.Size(168, 22);
            this.cmOpen.Text = "Otwórz";
            this.cmOpen.Click += new System.EventHandler(this.cmOpen_Click);
            // 
            // cmInbox
            // 
            this.cmInbox.Name = "cmInbox";
            this.cmInbox.Size = new System.Drawing.Size(168, 22);
            this.cmInbox.Text = "Skrzynka obiorcza";
            this.cmInbox.Click += new System.EventHandler(this.cmInbox_Click);
            // 
            // cmExit
            // 
            this.cmExit.Name = "cmExit";
            this.cmExit.Size = new System.Drawing.Size(168, 22);
            this.cmExit.Text = "Zamknij";
            this.cmExit.Click += new System.EventHandler(this.cmExit_Click);
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonOrbMenuItem1);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 116);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            // 
            // 
            // 
            this.ribbon1.QuickAcessToolbar.Items.Add(this.ribbonButton1);
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1054, 189);
            this.ribbon1.TabIndex = 5;
            this.ribbon1.Tabs.Add(this.ribbon);
            this.ribbon1.Tabs.Add(this.ribbonEwidencja);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // ribbonOrbMenuItem1
            // 
            this.ribbonOrbMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.Image")));
            this.ribbonOrbMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.SmallImage")));
            this.ribbonOrbMenuItem1.Text = "ribbonOrbMenuItem1";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "ribbonButton1";
            // 
            // ribbon
            // 
            this.ribbon.Panels.Add(this.ribbonPanel1);
            this.ribbon.Panels.Add(this.rbnFunMail);
            this.ribbon.Text = "Poczta";
            this.ribbon.ToolTipImage = ((System.Drawing.Image)(resources.GetObject("ribbon.ToolTipImage")));
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.btnInbox);
            this.ribbonPanel1.Items.Add(this.btnSendBox);
            this.ribbonPanel1.Items.Add(this.btnNew);
            this.ribbonPanel1.Text = "Poczta";
            // 
            // btnInbox
            // 
            this.btnInbox.Image = ((System.Drawing.Image)(resources.GetObject("btnInbox.Image")));
            this.btnInbox.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnInbox.SmallImage")));
            this.btnInbox.Text = "Skrzynka odbiorcza";
            this.btnInbox.Click += new System.EventHandler(this.btnInbox_Click);
            // 
            // btnSendBox
            // 
            this.btnSendBox.Image = ((System.Drawing.Image)(resources.GetObject("btnSendBox.Image")));
            this.btnSendBox.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnSendBox.SmallImage")));
            this.btnSendBox.Text = "Skrzynka nadawcza";
            this.btnSendBox.Click += new System.EventHandler(this.btnSendBox_Click);
            // 
            // btnNew
            // 
            this.btnNew.DropDownItems.Add(this.ribbonButton2);
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnNew.SmallImage")));
            this.btnNew.Text = "Nowa wiadomość";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "ribbonButton2";
            // 
            // ribbonEwidencja
            // 
            this.ribbonEwidencja.Panels.Add(this.ribbonForm);
            this.ribbonEwidencja.Panels.Add(this.ribbonAkcje);
            this.ribbonEwidencja.Text = "Ewidencja";
            // 
            // ribbonForm
            // 
            this.ribbonForm.Items.Add(this.btnFirm);
            this.ribbonForm.Items.Add(this.btnClient);
            this.ribbonForm.Text = "Ewidencja";
            // 
            // btnFirm
            // 
            this.btnFirm.Image = ((System.Drawing.Image)(resources.GetObject("btnFirm.Image")));
            this.btnFirm.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnFirm.SmallImage")));
            this.btnFirm.Text = "Firmy";
            this.btnFirm.Click += new System.EventHandler(this.btnFirm_Click);
            // 
            // btnClient
            // 
            this.btnClient.Image = ((System.Drawing.Image)(resources.GetObject("btnClient.Image")));
            this.btnClient.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnClient.SmallImage")));
            this.btnClient.Text = "Klienci";
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // ribbonAkcje
            // 
            this.ribbonAkcje.Items.Add(this.btnNowy);
            this.ribbonAkcje.Items.Add(this.btnModyfikuj);
            this.ribbonAkcje.Items.Add(this.btnUsun);
            this.ribbonAkcje.Text = "Edycja";
            // 
            // btnNowy
            // 
            this.btnNowy.Image = ((System.Drawing.Image)(resources.GetObject("btnNowy.Image")));
            this.btnNowy.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnNowy.SmallImage")));
            this.btnNowy.Text = "Nowy";
            this.btnNowy.Click += new System.EventHandler(this.btnNowy_Click);
            // 
            // btnModyfikuj
            // 
            this.btnModyfikuj.Image = ((System.Drawing.Image)(resources.GetObject("btnModyfikuj.Image")));
            this.btnModyfikuj.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnModyfikuj.SmallImage")));
            this.btnModyfikuj.Text = "Modyfikuj";
            this.btnModyfikuj.Click += new System.EventHandler(this.btnModyfikuj_Click);
            // 
            // btnUsun
            // 
            this.btnUsun.Image = ((System.Drawing.Image)(resources.GetObject("btnUsun.Image")));
            this.btnUsun.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnUsun.SmallImage")));
            this.btnUsun.Text = "Usuń";
            // 
            // rbnFunMail
            // 
            this.rbnFunMail.Items.Add(this.btnRefresh);
            this.rbnFunMail.Items.Add(this.btnDelete);
            this.rbnFunMail.Text = "Funkcje poczta";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.SmallImage")));
            this.btnRefresh.Text = "Odśwież";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.SmallImage")));
            this.btnDelete.Text = "Usuń wiadomość";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmCRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 364);
            this.Controls.Add(this.ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmCRM";
            this.Text = "CRM KA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmCRM_MdiChildActivate);
            this.Move += new System.EventHandler(this.frmCRM_Move);
            this.conMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyCRM;
        private System.Windows.Forms.ContextMenuStrip conMenu;
        private System.Windows.Forms.ToolStripMenuItem cmOpen;
        private System.Windows.Forms.ToolStripMenuItem cmInbox;
        private System.Windows.Forms.ToolStripMenuItem cmExit;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonTab ribbon;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton btnNew;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem1;
        private System.Windows.Forms.RibbonButton btnSendBox;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonButton btnInbox;
        private System.Windows.Forms.RibbonTab ribbonEwidencja;
        private System.Windows.Forms.RibbonPanel ribbonForm;
        private System.Windows.Forms.RibbonButton btnFirm;
        private System.Windows.Forms.RibbonButton btnClient;
        private System.Windows.Forms.RibbonPanel ribbonAkcje;
        private System.Windows.Forms.RibbonButton btnNowy;
        private System.Windows.Forms.RibbonButton btnModyfikuj;
        private System.Windows.Forms.RibbonButton btnUsun;
        private System.Windows.Forms.RibbonPanel rbnFunMail;
        private System.Windows.Forms.RibbonButton btnRefresh;
        private System.Windows.Forms.RibbonButton btnDelete;
    }
}

