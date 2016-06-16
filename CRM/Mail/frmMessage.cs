using APP.CRM;
using System.Windows.Forms;

namespace CRM.GUI.Mail
{
    public partial class frmMessage : Form
    {
        public cMail mail;
        public frmMessage()
        {
            
            InitializeComponent();
        }

        private void frmMessage_Load(object sender, System.EventArgs e)
        {
            txtMailAddress.Text = mail.address;
            txtTittle.Text = mail.tittle;
            txtMessText.Text = mail.text;
        }
    }
}
