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
    public partial class frmClient: Form
    {
        public bool trybReturns = false;//gdy zmieni na true ma byc możliwośc dwukkliku
        public string returnsMail = "";
        public int returnId = 0;
        public cEnum.tryb tryb = 0;
        private cClient modifyClient = null; 

        public string addWhere = "";

        public frmClient()
        {
            InitializeComponent();
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            this.BringToFront();

            lvClient.View = View.Details;
            lvClient.Columns.Add("Imie", 200, HorizontalAlignment.Left);
            lvClient.Columns.Add("Nazwisko", 200, HorizontalAlignment.Left);
            lvClient.Columns.Add("Firma", 200, HorizontalAlignment.Left);
            lvClient.Columns.Add("Telefon", 200, HorizontalAlignment.Left);
            lvClient.Columns.Add("Mail", 200, HorizontalAlignment.Left);
            lvClient.FullRowSelect = true;

            loadList();

            if (tryb == cEnum.tryb.view && lvClient.Items.Count > 0)
            {
                this.lvClient.Items[0].Focused = true;
                this.lvClient.Items[0].Selected = true;
            }
            lvClient.Focus();
        }

        /// <summary>
        /// Zaladowanie listy uzytkownikow do ListView
        /// </summary>
        private void loadList()
        {
            List<cClient> listClient = cClient.getClient(addWhere);
            foreach (cClient c in listClient)
                addClientToListView(c);
        }

        /// <summary>
        /// Dodaje pojedynczego klienta do ListView
        /// </summary>
        /// <param name="c">Klient</param>
        private void addClientToListView(cClient c)
        {
            ListViewItem lvItem = new ListViewItem(c.name);
            lvItem.SubItems.Add(c.secondName);
            lvItem.SubItems.Add(cCompany.getNameById(c.companyId));
            lvItem.SubItems.Add(c.tel);
            lvItem.SubItems.Add(c.mail);
            lvItem.Tag = c;

            lvClient.Items.Add(lvItem);
        }

        private void lvCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            //przeładowanie kontrolek
            if (lvClient.SelectedItems.Count == 0)
                return;

            cClient tempCompany = lvClient.SelectedItems[0].Tag as cClient;
            txtImie.Text = tempCompany.name;
            txtFirmaId.Text = tempCompany.companyId.ToString();
            txtNazwisko.Text = tempCompany.secondName;
            txtTelefon.Text = tempCompany.tel;
            txtMail.Text = tempCompany.mail;

            txtFirma.Text = cCompany.getNameById(tempCompany.companyId);
        }

        private void lvClient_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!trybReturns)
                return;

            if (lvClient.SelectedItems.Count == 0)
                return;

            cClient tempClient = lvClient.SelectedItems[0].Tag as cClient;

            returnsMail = tempClient.mail;
            returnId = tempClient.id;

            this.Hide();
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            frmCompany frmTemp = new frmCompany();
            frmTemp.trybReturns = 1;
            frmTemp.ShowDialog();
            if (frmTemp.idCompany > 0)
                this.txtFirmaId.Value = frmTemp.idCompany;

            frmTemp.Close();
        }
        /// <summary>
        /// Przygotowanie nowego rekordu
        /// </summary>
        public void prepareNew()
        {
            tryb = cEnum.tryb.add;
            txtImie.Text = "";
            txtNazwisko.Text = "";
            txtFirmaId.Value = 0;
            txtTelefon.Text = "";
            txtMail.Text = "";
            txtImie.Focus();
            changeEnabled(true);
        }
        /// <summary>
        /// Przygotowanie rekordu do modyfikacji
        /// </summary>
        public void prepareModify()
        {
            if (lvClient.SelectedItems.Count == 0)
                return;

            modifyClient = lvClient.SelectedItems[0].Tag as cClient;
            tryb = cEnum.tryb.modify;
            changeEnabled(true);
        }

        private void btnZatwierdz_Click(object sender, EventArgs e)
        {
            if (tryb == cEnum.tryb.add)
            {
                cClient tempClient = new cClient();
                tempClient.name = txtImie.Text;
                tempClient.secondName = txtNazwisko.Text;
                tempClient.companyId = (int)txtFirmaId.Value;
                tempClient.tel = txtTelefon.Text;
                tempClient.mail = txtMail.Text;
                if (!tempClient.addUser())
                {
                    MessageBox.Show("Nie udało się dodać klienta", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                addClientToListView(tempClient);
            }
            if (tryb == cEnum.tryb.modify)
            {
                modifyClient.name = txtImie.Text;
                modifyClient.secondName = txtNazwisko.Text;
                modifyClient.companyId = (int)txtFirmaId.Value;
                modifyClient.tel = txtTelefon.Text;
                modifyClient.mail = txtMail.Text;
                if (!modifyClient.modifyUser())
                {
                    MessageBox.Show("Nie udało się dodać klienta", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                lvClient.SelectedItems[0].Text = modifyClient.name;
                lvClient.SelectedItems[0].SubItems[0].Text = modifyClient.name;
                lvClient.SelectedItems[0].SubItems[1].Text = modifyClient.secondName;
                lvClient.SelectedItems[0].SubItems[2].Text = modifyClient.tel;
                lvClient.SelectedItems[0].SubItems[3].Text = modifyClient.mail;
                lvClient.SelectedItems[0].Tag = modifyClient;
            }
            tryb = cEnum.tryb.view;
            changeEnabled(false);
            modifyClient = null;
        }
        /// <summary>
        /// Zmiana aktywnosci kotnrolek
        /// </summary>
        /// <param name="val"></param>
        private void changeEnabled(bool val)
        {
            lvClient.Enabled = !val;
            groupBox1.Enabled = val;
            btnZatwierdz.Visible = val;
            btnZrezygnuj.Visible = val;
        }

        private void btnZrezygnuj_Click(object sender, EventArgs e)
        {
            tryb = cEnum.tryb.view;
            changeEnabled(false);
            modifyClient = null;
        }
        /// <summary>
        /// Odswierzenie listy, pobranie na nowo z BD
        /// </summary>
        public void refreshList()
        {
            lvClient.Items.Clear();
            loadList();
        }
        /// <summary>
        /// Ustawienie kontrolki z mailem
        /// </summary>
        /// <param name="value"></param>
        public void setEmail(string value)
        {
            txtMail.Text = value;
        }
        /// <summary>
        /// Funkcja zwracajaca id klienta z listy
        /// </summary>
        /// <returns></returns>
        public int returnClientId()
        {
            if (lvClient.SelectedItems.Count == 0)
                return 0;

            cClient tempClient = lvClient.SelectedItems[0].Tag as cClient;
            return tempClient.id;
        }
        /// <summary>
        /// Dezaktywacja klienta
        /// </summary>
        public void deleteClient()
        {
            if (lvClient.SelectedItems.Count == 0)
                return;

            cClient tempClient = lvClient.SelectedItems[0].Tag as cClient;

            if ((MessageBox.Show("Czy na pewno chcesz usunąć klienta " + tempClient.name + " " + tempClient.secondName + "?","Uwaga!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No)
                return;

            if (!tempClient.deleteClient())
            {
                MessageBox.Show("Nie udało się usunąć klienta", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            lvClient.Items.Remove(lvClient.SelectedItems[0]);
        }

        private void txtFirmaId_ValueChanged(object sender, EventArgs e)
        {
            this.txtFirmaId.Text = cCompany.getNameById(int.Parse(txtFirmaId.Text));
        }
    }
}
