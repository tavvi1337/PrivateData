using System;
using System.Windows.Forms;

namespace PrivateData.Views.Dialogs
{
    public partial class frm_AskPassword : Form
    {
        public string Password { get; private set; }
        public frm_AskPassword()
        {
            InitializeComponent();
        }

        private void Btn_done_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("Пароли не совпадают", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Password = textBox1.Text;

            DialogResult = DialogResult.OK;
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Select();
            }
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btn_done_Click(btn_done, new EventArgs());
            }
        }
    }
}
