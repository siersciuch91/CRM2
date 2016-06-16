using APP.CRM;
using System;
using System.Windows.Forms;
using System.Threading;
using APP.CRM.Mail;

namespace CRM.GUI
{
    public partial class frmCRM : Form
    {
        Thread thread;
        public frmCRM()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mail.frmInbox frmInbox = new Mail.frmInbox();
            frmInbox.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mail.frmSendMail frmSendMail = new Mail.frmSendMail();
            frmSendMail.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //, "Politechnika*2016"
            frmLogin frmTemp = new frmLogin();
            frmTemp.ShowDialog();
            if (frmTemp.loginState)
            {

               // login = "adrian.kasia.pk2106@gmail.com";
                //pass = "Politechnika*2016";
            }
            frmTemp.Close();
            //conn.Open(connString, "", "", -1);
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
    }
}
