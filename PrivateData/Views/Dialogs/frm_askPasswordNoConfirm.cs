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
    }
}
