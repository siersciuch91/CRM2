using APP.CRM;
using System;
using System.Windows.Forms;
using System.Threading;
using APP.CRM.Mail;
using System.IO;

namespace CRM.GUI
{
    public partial class frmCRM : RibbonForm
    {
        Thread thread;
        public frmCRM()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mail.frmInbox frmInbox = new Mail.frmInbox();
            frmInbox.Show();
            frmInbox.MdiParent = this;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mail.frmSendMail frmSendMail = new Mail.frmSendMail();
            frmSendMail.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                cConnection.setConnection(@"SIERSCIUCH-NB\SQL2014", "CRM", true, "", ""); //"sa", "Politechnika*2016");

                frmLogin frmlogin = new frmLogin();
                frmlogin.ShowDialog();

                bool success = frmlogin.loginState;

                frmlogin.Close();

                if (!success)
                {
                    MessageBox.Show("Nie udało sie zalogować");
                    this.Close();
                    return;
                }

                cSession.tempPath = Path.GetTempPath() + "\\CRM_KA\\" + cSession.userId;

                thread = new Thread(new ThreadStart(getEmail));
                thread.Start();
            }
            catch (Exception ex)
            {
            }
        }

        private void getEmail()
        {
            cSession.inbox = new cMailBox("imap.gmail.com",
                          993,
                          true,
                          cSession.login, cSession.passwordUser);

            while (1==1)
            {
                Thread.Sleep(2000);
                int newMailCount =cMail.getNewMail();

                if (newMailCount > 0)
                    notifyCRM.ShowBalloonTip(1000, "Masz nowe wiadomości", "Masz " + newMailCount + "nowych wiadomości", ToolTipIcon.Info);
                    //MessageBox.Show("Otrzymana nowe maila: " + newMailCount.ToString());
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //thread.R
            if (thread != null && thread.ThreadState == ThreadState.Running)
                thread.Abort();


            if (Directory.Exists(cSession.tempPath))
            {
                DirectoryInfo directory = new DirectoryInfo(cSession.tempPath);
                foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
                foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
                directory.Delete(true);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cConnection.setConnection(@"SIERSCIUCH-NB\SQL2014", "CRM", true, "", ""); //"sa", "Politechnika*2016");

            MessageBox.Show(cConnection.conn.State.ToString());

            cUser user = new cUser();
            user.getListUsers();
        }

        private void frmCRM_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void cmOpen_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void cmInbox_Click(object sender, EventArgs e)
        {
            Mail.frmInbox frmInbox = new Mail.frmInbox();
            frmInbox.ShowDialog();
        }

        private void cmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInbox_Click(object sender, EventArgs e)
        {
            Mail.frmInbox frmInbox = new Mail.frmInbox();
            frmInbox.MdiParent = this;
            frmInbox.Show();
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Mail.frmSendMail frmSendMail = new Mail.frmSendMail();
            frmSendMail.MdiParent = this;
            frmSendMail.Show();
        }

        private void btnFirm_Click(object sender, EventArgs e)
        {

        }

        private void btnClient_Click(object sender, EventArgs e)
        {

        }

        private void btnNowy_Click(object sender, EventArgs e)
        {

        }

        private void btnModyfikuj_Click(object sender, EventArgs e)
        {

        }

        private void btnSendBox_Click(object sender, EventArgs e)
        {

        }
    }
}
