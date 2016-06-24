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
        public cEnum.tryb tryb = 0;
        private cCompany modifyCompany = null;

        public frmCompany()
        {
            InitializeComponent();
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            this.BringToFront();

            lvCompany.View = View.Details;
            lvCompany.Columns.Add("Nazwa", 400, HorizontalAlignment.Left);
            lvCompany.Columns.Add("Street ID", 200, HorizontalAlignment.Left);
            lvCompany.Columns.Add("Numer domu", 200, HorizontalAlignment.Left);
            lvCompany.Columns.Add("NIP", 300, HorizontalAlignment.Left);
            lvCompany.Columns.Add("Telefon", 200, HorizontalAlignment.Left);
            lvCompany.Columns.Add("Mail", 200, HorizontalAlignment.Left);
            lvCompany.FullRowSelect = true;

            loadList();

            if (lvCompany.Items.Count > 0)
            {
                this.lvCompany.Items[0].Focused = true;
                this.lvCompany.Items[0].Selected = true;
            }
        }

        private void loadList()
        {
            List<cCompany> listComapny = cCompany.getCompany();

            if (listComapny == null)
            {
                MessageBox.Show("Nie udało się pobrać listy firm", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (cCompany c in listComapny)
                addCompanyToListView(c);
        }

        private void addCompanyToListView(cCompany c)
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

        private void lvCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
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

            cCompany tempCompany = lvCompany.SelectedItems[0].Tag as cCompany;

            if (trybReturns == 1)
            {
                idCompany = tempCompany.id;
                this.Hide();
            }
            else if(trybReturns == 2)
            {
                frmClient frmTemp = new frmClient();
                frmTemp.trybReturns = true;
                frmTemp.addWhere = " and id_company = " + tempCompany.id;
                frmTemp.ShowDialog();
                returnsMail = frmTemp.returnsMail;
                idClient = frmTemp.returnId;
                frmTemp.Close();
                this.Hide();
            }
        }

        public void prepareNew()
        {
            tryb = cEnum.tryb.add;
            txtNazwa.Text = "";
            txtAddressId.Text = "";
            txtAdres.Text = "";
            txtNip.Text = "";
            txtTelefon.Text = "";
            txtMail.Text = "";
            changeEnabled(true);
        }

        private void changeEnabled(bool val)
        {
            lvCompany.Enabled = !val;
            groupBox1.Enabled = val;
            btnZatwierdz.Visible = val;
            btnZrezygnuj.Visible = val;
        }

        private void btnZatwierdz_Click(object sender, EventArgs e)
        {
            if (tryb == cEnum.tryb.add)
            {
                cCompany tempCompany = new cCompany();
                tempCompany.name = txtNazwa.Text;
                tempCompany.streetId = (int)txtAddressId.Value;
                tempCompany.mail = txtMail.Text;
                tempCompany.tel = txtTelefon.Text;
                tempCompany.NIP = txtNip.Text;
                tempCompany.houseNo = "0";
                if (!tempCompany.addCompany())
                {
                    MessageBox.Show("Nie udało się dodać firmy", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                addCompanyToListView(tempCompany);
            }
            if (tryb == cEnum.tryb.modify)
            {
                txtNazwa.Text = modifyCompany.name;
                txtAddressId.Value = modifyCompany.streetId;
                txtMail.Text = modifyCompany.mail;
                txtTelefon.Text = modifyCompany.tel;
                txtNip.Text = modifyCompany.NIP;

                if(!modifyCompany.modifyCompany())
                {
                    MessageBox.Show("Nie udało się dodać firmy", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                lvCompany.SelectedItems[0].Text = modifyCompany.name;
                lvCompany.SelectedItems[0].SubItems[0].Text = modifyCompany.streetId.ToString();
                lvCompany.SelectedItems[0].SubItems[1].Text = modifyCompany.houseNo;
                lvCompany.SelectedItems[0].SubItems[2].Text = modifyCompany.NIP;
                lvCompany.SelectedItems[0].SubItems[2].Text = modifyCompany.tel;
                lvCompany.SelectedItems[0].SubItems[3].Text = modifyCompany.mail;
                lvCompany.SelectedItems[0].Tag = modifyCompany;

            }
            tryb = cEnum.tryb.view;
            changeEnabled(false);
            modifyCompany = null;
        }

        private void btnZrezygnuj_Click(object sender, EventArgs e)
        {
            tryb = cEnum.tryb.view;
            changeEnabled(false);
            modifyCompany = null;
        }

        public void prepareModify()
        {
            if (lvCompany.SelectedItems.Count == 0)
                return;

            modifyCompany = lvCompany.SelectedItems[0].Tag as cCompany;
            tryb = cEnum.tryb.modify;
            changeEnabled(true);
        }
        public void refreshList()
        {
            lvCompany.Items.Clear();
            loadList();
        }

        public int returnCompanyId()
        {
            if (lvCompany.SelectedItems.Count == 0)
                return 0;

            cCompany tempComany = lvCompany.SelectedItems[0].Tag as cCompany;
            return tempComany.id;
        }

        public void deleteCompany()
        {
            if (lvCompany.SelectedItems.Count == 0)
                return;

            cCompany tempComany = lvCompany.SelectedItems[0].Tag as cCompany;

            if ((MessageBox.Show("Czy na pewno chcesz usunąć firmę " + tempComany.name + " i wszystkich klientów związanych z tą firmą?", "Uwaga!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No)
                return;
            
            if (!tempComany.deleteCompany())
            {
                MessageBox.Show("Nie udało się usunąć firmy", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            lvCompany.Items.Remove(lvCompany.SelectedItems[0]);

        }

        private void btnStreet_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Niedokonczono ;(");
        }
    }
}
