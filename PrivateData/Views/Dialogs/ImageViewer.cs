using PrivateData.ViewModels;
using System.Drawing;
using System.Windows.Forms;

namespace PrivateData.Views.Dialogs
{
    public partial class ImageViewer : Form
    {
        DataManager dm;
        Bitmap image;
        public ImageViewer(Bitmap image, DataManager dm)
        {
            InitializeComponent();
            pictureBox.Image = image;
            this.dm = dm;
            this.image = image;
        }

        private void Btn_remove_Click(object sender, System.EventArgs e)
        {
            dm.RemoveImage(image);
            this.Close();
        }
    }
}
