using APP.CRM;
using System;
using System.Windows.Forms;
using System.Threading;
using APP.CRM.Mail;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;

namespace CRM.GUI
{
    public partial class frmCRM : RibbonForm
    {
        Mail.frmInbox frmInbox;
        Mail.frmSendBox frmSendBox;
        Mail.frmSendMail frmSendMail;
        Ewidencja.frmCompany frmCompany;
        Ewidencja.frmClient frmClient;

        public frmCRM()
        {
            InitializeComponent();
            backgroundWorker.WorkerSupportsCancellation = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //ustawienie połączenia
                if (cConnection.setConnection(@"SIERSCIUCH-NB\SQL2014", "CRM", true, "", ""))//"sa", "Politechnika*2016");
                {
                    MessageBox.Show("Nie udało sie ustanowić połączeniam, nastąpi zamknięcie programu", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                //ekran logowania i powrot zmiennej ze statusem logowania
                frmLogin frmlogin = new frmLogin();
                frmlogin.ShowDialog();
                bool success = frmlogin.loginState;
                frmlogin.Close();
                //zamkniecie programu gdy brak zalogowania
                if (!success)
                {
                    MessageBox.Show("Nie udało sie zalogować");
                    this.Close();
                    return;
                }
                //ustawienie zmiennej w katalogu temp gdzie beda trzymane pliki
                cSession.tempPath = Path.GetTempPath() + "\\CRM_KA\\" + cSession.userId;
                backgroundWorker.RunWorkerAsync();
            }
            catch
            {
                MessageBox.Show("Nastąpił nieoczekiwany błąd programu, zostanie on zakknięty", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkNewMail()
        {
            List<cMail> listMail = new List<cMail>();
            int newMailCount = cMail.getNewMail(ref listMail);
            //gdy dostaniemy nową wiadomość pokaże się komunikat
            if (newMailCount == 1)
                notifyCRM.ShowBalloonTip(1000, "Masz nową wiadomość", "Masz nową wiadomość", ToolTipIcon.Info);
            else if (newMailCount > 1)
                notifyCRM.ShowBalloonTip(1000, "Masz nowe wiadomości", "Masz " + newMailCount + " nowych wiadomości", ToolTipIcon.Info);
            else
                return;

            if (frmInbox != null)
                frmInbox.insertNewMailList(listMail);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (backgroundWorker.WorkerSupportsCancellation == true)
                backgroundWorker.CancelAsync();

            cSession.inbox = null;

            if (cSession.tempPath != null)
            {
                DirectoryInfo directory = new DirectoryInfo(cSession.tempPath);
                if (directory.Exists)
                {
                    foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
                    foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
                    directory.Delete(true);
                }
            }

            if (cConnection.conn.State != 0)
                cConnection.conn.Close();

        }

        private void frmCRM_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.Hide();
        }

        private void cmOpen_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void cmInbox_Click(object sender, EventArgs e)
        {
            this.Show();
            btnInbox_Click(null, null);
        }

        private void cmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInbox_Click(object sender, EventArgs e)
        {
            frmInbox = new Mail.frmInbox();
            frmInbox.MdiParent = this;
            frmInbox.Show();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmSendMail = new Mail.frmSendMail();
            frmSendMail.ShowDialog();
            if (frmSendMail.mail != null)
            {
                if (frmSendBox != null)
                    frmSendBox.insertNewMail(frmSendMail.mail);

                MessageBox.Show("Wysłano wiadomość");
            }
            frmSendMail.Close();
        }

        private void btnFirm_Click(object sender, EventArgs e)
        {
            frmCompany = new Ewidencja.frmCompany();
            frmCompany.MdiParent = this;
            frmCompany.ControlBox = false;
            frmCompany.WindowState = FormWindowState.Maximized;
            frmCompany.Show();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            frmClient = new Ewidencja.frmClient();
            frmClient.MdiParent = this;
            frmClient.ControlBox = false;
            frmClient.WindowState = FormWindowState.Maximized;
            frmClient.Show();
        }

        private void btnNowy_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;

            if (activeChild == null)
                return;

            if (activeChild == frmClient)
                frmClient.prepareNew();
            else if (activeChild == frmCompany)
                frmCompany.prepareNew();
        }

        private void btnModyfikuj_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;

            if (activeChild == null)
                return;

            if (activeChild == frmClient)
                frmClient.prepareModify();
            else if (activeChild == frmCompany)
                frmCompany.prepareModify();
        }

        private void btnSendBox_Click(object sender, EventArgs e)
        {
            frmSendBox = new Mail.frmSendBox();
            frmSendBox.MdiParent = this;
            frmSendBox.Show();
        }

        private void notifyCRM_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            checkNewMail();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Form tempForm = this.ActiveMdiChild;
            if (tempForm == null)
                return;

            if (MessageBox.Show("Czy napewno chcesz usunąć tą wiadomość?", "CRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (tempForm == frmSendBox)
                {
                    frmSendBox.deleteMessage();
                }
                else if (tempForm == frmInbox)
                {
                    frmInbox.deleteMessage();
                }

                MessageBox.Show("Usunięto wiadomość", "CRM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmCRM_MdiChildActivate(object sender, EventArgs e)
        {
            Form tempForm = this.ActiveMdiChild;
            if (tempForm == null)
                return;

            if (tempForm == frmSendMail)
                btnDelete.Enabled = false;
            else
                btnDelete.Enabled = true;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            cSession.inbox = new cMailBox("imap.gmail.com",
                          993,
                          true,
                          cSession.login, cSession.passwordUser);

            //pętla która chodzi cały czas ze sleepem, sprawdzanie maili
            while (true)
            {
                checkNewMail();
                Thread.Sleep(300000);//co 5 minut   
            }
        }

        private void btnRibbonRefresh_Click(object sender, EventArgs e)
        {
            Form tempForm = this.ActiveMdiChild;

            if (tempForm == frmClient)
                frmClient.refreshList();
            else if (tempForm == frmCompany)
                frmCompany.refreshList();
            else
                checkNewMail();
        }

        private void rbBtnCon_Click(object sender, EventArgs e)
        {
            Mail.frmMessages frmTemp;
            Form tempForm = this.ActiveMdiChild;

            if (tempForm == null)
                return;

            if (tempForm == frmClient)
            {
                frmTemp = new Mail.frmMessages();
                int tempId = frmClient.returnClientId();
                if (tempId == 0)
                    return;

                frmTemp.clientId = tempId;
                frmTemp.ShowDialog();
            }
            else if (tempForm == frmCompany)
            {
                frmTemp = new Mail.frmMessages();
                int tempId = frmCompany.returnCompanyId();
                if (tempId == 0)
                    return;

                frmTemp.companyId = tempId;
                frmTemp.ShowDialog();
            }
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            Form tempForm = this.ActiveMdiChild;

            if (tempForm == null)
                return;

            if (tempForm == frmClient)
                frmClient.deleteClient();
            else if (tempForm == frmCompany)
                frmCompany.deleteCompany();
        }
    }
}
