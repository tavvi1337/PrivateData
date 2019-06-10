using PrivateData.ViewModels;
using PrivateData.Views.Dialogs;
using System.Windows.Forms;

namespace PrivateData
{
    public partial class frm_main : Form
    {
        string[] args;
        DataManager dm = new DataManager("", "");
        string importedPath = "";
        string importedPass = "";
        public frm_main(string[] args)
        {
            InitializeComponent();
            if (!FileAssociation.IsAssociated)
            {
                try
                {
                    FileAssociation.Associate("Зашифрованные данные", null);
                }
                catch { MessageBox.Show("Не удалось установить ассоциацию для файлов, пожалуйста запустите программу от имени администратора", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            this.args = args;
        }

        private void Frm_main_Shown(object sender, System.EventArgs e)
        {
            if (args.Length > 0)
            {
                LoadData(args[0]);
            }
        }

        private void Btn_save_Click(object sender, System.EventArgs e)
        {
            if (importedPath == "")//nothing imported
            {
                string path = AskSavePath();
                if (path == null)
                {
                    return;
                }
                string pass = AskConfirmPass();
                if (pass != null)
                {
                    dm = new DataManager(txtbx_name.Text, txtbx_content.Text);
                    dm.SaveData($"{path}\\{dm.Title}.ptxt", pass);
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtbx_name.Text))
                {
                    MessageBox.Show("Пожалуйста введите имя файла", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dm = new DataManager(txtbx_name.Text, txtbx_content.Text);
                dm.SaveData(importedPath, importedPass);
            }
        }

        void UpdateUI()
        {
            txtbx_name.Text = dm.Title;
            txtbx_content.Text = dm.Contents;
        }

        string AskSavePath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                return fbd.SelectedPath;
            }
            return null;
        }

        string AskConfirmPass()
        {
            frm_AskPassword askPassword = new frm_AskPassword();
            if (askPassword.ShowDialog() == DialogResult.OK)
            {
                return askPassword.Password;
            }
            return null;
        }

        string AskNoConfimPass()
        {
            var askPassword = new frm_askPasswordNoConfirm();
            if (askPassword.ShowDialog() == DialogResult.OK)
            {
                return askPassword.Password;
            }
            return null;
        }

        void LoadData(string pathToFile)
        {
            string pass = AskNoConfimPass();
            if (pass == null)
            {
                return;
            }

            try
            {
                dm.LoadData(pathToFile, pass);
                UpdateUI();
                importedPath = pathToFile;
                importedPass = pass;
            }
            catch
            {
                MessageBox.Show("Не верный пароль", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_load_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Private text | *.ptxt"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string file = ofd.FileName;

                LoadData(file);

                UpdateUI();
            }
        }
    }
}
