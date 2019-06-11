using PrivateData.ViewModels;
using PrivateData.Views.Dialogs;
using System.Drawing;
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
                    importedPath = $"{path}\\{dm.Title}.ptxt";
                    importedPass = pass;
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

            pic_margain = 20;
            pic_location_X = 5;
            pic_location_Y = 5;
            tab_pictures.Controls.Clear();

            foreach (Bitmap image in dm.Images)
            {
                AddImageToUI(image);
            }
        }

        int pic_margain = 20;
        int pic_location_X = 5;
        int pic_location_Y = 5;
        void AddImageToUI(Bitmap image)
        {
            PictureBox pic_box = new PictureBox()
            {
                Location = new Point(pic_location_X, pic_location_Y),
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(image.Width, image.Height)
            };

            pic_box.Click += (s, e) => { new ImageViewer(image, dm).ShowDialog(); UpdateUI(); };
            pic_location_Y += pic_box.Height + pic_margain;

            tab_pictures.Controls.Add(pic_box);
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
            frm_askPasswordNoConfirm askPassword = new frm_askPasswordNoConfirm();
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

        private void Btn_importImage_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    dm.AddImage(ofd.FileNames[i]);
                }
                UpdateUI();
            }
        }
    }
}
