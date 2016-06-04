using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APP.CRM;
using APP.CRM.Mail;


namespace CRM
{
    public partial class Form1 : Form
    {
        public string connString = "Provider=SQLOLEDB.1;Persist Security Info=True;User ID=sa;Initial Catalog=CRM;Data Source=SIERSCIUCH-NB\\SQL2014;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Use Encryption for Data=False;Tag with column collation when possible=False;Password=Politechnika*2016";
        public static ADODB.Connection conn = new ADODB.Connection();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            conn.Open(connString, "", "", -1);
        }
    }
}
