using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
