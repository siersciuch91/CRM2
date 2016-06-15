using APP.CRM;
using System;
using System.Windows.Forms;
using System.Threading;

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
            frmInbox.Show();
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
            while(1==1)
            {
                //int time = 100;
                Thread.Sleep(2000);
                MessageBox.Show("aa");
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
    }
}
