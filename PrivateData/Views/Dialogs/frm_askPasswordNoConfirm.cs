using System;
using System.Windows.Forms;

namespace PrivateData.Views.Dialogs
{
    public partial class frm_askPasswordNoConfirm : Form
    {
        public string Password { get; set; }
        public frm_askPasswordNoConfirm()
        {
            InitializeComponent();
        }

        private void Btn_done_Click(object sender, EventArgs e)
        {
            Password = textBox1.Text;

            DialogResult = DialogResult.OK;
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btn_done_Click(btn_done, new EventArgs());
            }
        }
    }
}
