using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APP.CRM.Ewidencja;

namespace CRM.GUI.Ewidencja
{
    public partial class frmCompany : Form
    {
        public int trybReturns = 0;//gdy zmieni 1 zwracamy id firmy gdy 2 zwracamy adres mailowy klienta z firmy
        public string returnsMail = "";
        public int idCompany = 0;
        public int idClient = 0;
        public frmCompany()
        {
            InitializeComponent();
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            this.BringToFront();

            List<cCompany> listComapny = cCompany.getCompany();

            lvCompany.View = View.Details;
            lvCompany.Columns.Add("Nazwa", 400, HorizontalAlignment.Left);
            lvCompany.Columns.Add("Street ID", 200, HorizontalAlignment.Left);
            lvCompany.Columns.Add("Numer domu", 200, HorizontalAlignment.Left);
            lvCompany.Columns.Add("NIP", 300, HorizontalAlignment.Left);
            lvCompany.Columns.Add("Telefon", 200, HorizontalAlignment.Left);
            lvCompany.Columns.Add("Mail", 200, HorizontalAlignment.Left);

  
            lvCompany.FullRowSelect = true;

            foreach (cCompany c in listComapny)
            {
                ListViewItem lvItem = new ListViewItem(c.name);
                lvItem.SubItems.Add(c.streetId.ToString());
                lvItem.SubItems.Add(c.houseNo);
                lvItem.SubItems.Add(c.NIP);
                lvItem.SubItems.Add(c.tel);
                lvItem.SubItems.Add(c.mail);

                lvItem.Tag = c;

                lvCompany.Items.Add(lvItem);
            }
        }
        public string returnClientIdFromFirm()
        {
            return "";
        }

        private void lvCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            //przeładowanie kontrolek
            if (lvCompany.SelectedItems.Count == 0)
                return;

            cCompany tempCompany = lvCompany.SelectedItems[0].Tag as cCompany;
            txtNazwa.Text = tempCompany.name;
            txtAddressId.Text = tempCompany.streetId.ToString();
            txtNip.Text = tempCompany.NIP;
            txtTelefon.Text = tempCompany.tel;
            txtMail.Text = tempCompany.mail;

        }

        private void lvCompany_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvCompany.SelectedItems.Count == 0)
                return;

            if (trybReturns == 1)
            {
                cCompany tempCompany = lvCompany.SelectedItems[0].Tag as cCompany;
                idCompany = tempCompany.id;
                this.Hide();
            }
            else if(trybReturns == 2)
            {
                frmClient frmTemp = new frmClient();
                frmTemp.trybReturns = true;
                frmTemp.ShowDialog();
                returnsMail = frmTemp.returnsMail;
                idClient = frmTemp.returnId;
                frmTemp.Close();
                this.Hide();
            }
        }
    }
}
