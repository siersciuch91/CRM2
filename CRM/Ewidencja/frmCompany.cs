using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM.GUI.Ewidencja
{
    public partial class frmCompany : Form
    {
        public bool trybReturns = false;//gdy zmieni na true ma byc możliwośc dwukkliku
        public string returnsMail = "";
        public frmCompany()
        {
            InitializeComponent();
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }
        public string returnClientIdFromFirm()
        {
            return "";
        }
    }
}
