using System;
using System.Windows.Forms;

namespace CRM.GUI
{
    public partial class Form1 : Form
    {
        public static string connString = "Provider=SQLOLEDB.1;Persist Security Info=True;User ID=sa;Initial Catalog=CRM;Data Source=SIERSCIUCH-NB\\SQL2014;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Use Encryption for Data=False;Tag with column collation when possible=False;Password=Politechnika*2016";
        public static ADODB.Connection conn = new ADODB.Connection();
        public static int userId;
        public static string login = "";
        public static string pass = "";

        public Form1()
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

                login = "adrian.kasia.pk2106@gmail.com";
                pass = "Politechnika*2016";
            }
            frmTemp.Close();
            //conn.Open(connString, "", "", -1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open(connString, "", "", -1);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Wystąpił błąd:" + ex.Message, "CRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State != 0)
                conn.Close();
        }
    }
}
