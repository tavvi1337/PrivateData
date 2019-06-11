using PrivateData.ViewModels;
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
    public partial class frm_settings : Form
    {
        public frm_settings()
        {
            InitializeComponent();
        }

        private void Btn_associate_Click(object sender, EventArgs e)
        {
            FileAssociation.Associate("Зашифрованные данные", null);
        }
    }
}
