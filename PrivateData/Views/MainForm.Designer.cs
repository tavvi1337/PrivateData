using System.Windows.Forms;

namespace PrivateData
{
    partial class frm_main
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (!saved)
            {
                if (MessageBox.Show("Вы не сохранили изменения, выйти?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_main));
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tab_text = new MetroFramework.Controls.MetroTabPage();
            this.txtbx_content = new MetroFramework.Controls.MetroTextBox();
            this.tab_pictures = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtbx_name = new MetroFramework.Controls.MetroTextBox();
            this.btn_save = new MetroFramework.Controls.MetroButton();
            this.btn_load = new MetroFramework.Controls.MetroButton();
            this.btn_importImage = new MetroFramework.Controls.MetroButton();
            this.btn_settings = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1.SuspendLayout();
            this.tab_text.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabControl1.Controls.Add(this.tab_text);
            this.metroTabControl1.Controls.Add(this.tab_pictures);
            this.metroTabControl1.Location = new System.Drawing.Point(12, 97);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.Padding = new System.Drawing.Point(6, 8);
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(702, 330);
            this.metroTabControl1.TabIndex = 14;
            // 
            // tab_text
            // 
            this.tab_text.Controls.Add(this.txtbx_content);
            this.tab_text.Enabled = true;
            this.tab_text.HorizontalScrollbarBarColor = true;
            this.tab_text.Location = new System.Drawing.Point(4, 35);
            this.tab_text.Name = "tab_text";
            this.tab_text.Size = new System.Drawing.Size(694, 291);
            this.tab_text.TabIndex = 0;
            this.tab_text.Text = "Текст";
            this.tab_text.VerticalScrollbarBarColor = true;
            this.tab_text.Visible = true;
            // 
            // txtbx_content
            // 
            this.txtbx_content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbx_content.Location = new System.Drawing.Point(3, 3);
            this.txtbx_content.Multiline = true;
            this.txtbx_content.Name = "txtbx_content";
            this.txtbx_content.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbx_content.Size = new System.Drawing.Size(688, 285);
            this.txtbx_content.TabIndex = 2;
            // 
            // tab_pictures
            // 
            this.tab_pictures.AutoScroll = true;
            this.tab_pictures.Enabled = true;
            this.tab_pictures.HorizontalScrollbar = true;
            this.tab_pictures.HorizontalScrollbarBarColor = true;
            this.tab_pictures.Location = new System.Drawing.Point(4, 35);
            this.tab_pictures.Name = "tab_pictures";
            this.tab_pictures.Size = new System.Drawing.Size(694, 291);
            this.tab_pictures.TabIndex = 1;
            this.tab_pictures.Text = "Изображения";
            this.tab_pictures.VerticalScrollbar = true;
            this.tab_pictures.VerticalScrollbarBarColor = true;
            this.tab_pictures.Visible = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(19, 68);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(71, 19);
            this.metroLabel1.TabIndex = 15;
            this.metroLabel1.Text = "Название:";
            // 
            // txtbx_name
            // 
            this.txtbx_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbx_name.Location = new System.Drawing.Point(94, 68);
            this.txtbx_name.Name = "txtbx_name";
            this.txtbx_name.Size = new System.Drawing.Size(616, 23);
            this.txtbx_name.TabIndex = 16;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Location = new System.Drawing.Point(606, 433);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(108, 30);
            this.btn_save.TabIndex = 17;
            this.btn_save.Text = "Сохранить";
            this.btn_save.Click += new System.EventHandler(this.Btn_save_Click);
            // 
            // btn_load
            // 
            this.btn_load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_load.Location = new System.Drawing.Point(492, 433);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(108, 30);
            this.btn_load.TabIndex = 18;
            this.btn_load.Text = "Загрузить файл";
            this.btn_load.Click += new System.EventHandler(this.Btn_load_Click);
            // 
            // btn_importImage
            // 
            this.btn_importImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_importImage.Location = new System.Drawing.Point(326, 433);
            this.btn_importImage.Name = "btn_importImage";
            this.btn_importImage.Size = new System.Drawing.Size(160, 30);
            this.btn_importImage.TabIndex = 19;
            this.btn_importImage.Text = "Добавить изображения";
            this.btn_importImage.Click += new System.EventHandler(this.Btn_importImage_Click);
            // 
            // btn_settings
            // 
            this.btn_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_settings.Location = new System.Drawing.Point(212, 433);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Size = new System.Drawing.Size(108, 30);
            this.btn_settings.TabIndex = 20;
            this.btn_settings.Text = "Настройки";
            this.btn_settings.Click += new System.EventHandler(this.Btn_settings_Click);
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 473);
            this.Controls.Add(this.btn_settings);
            this.Controls.Add(this.btn_importImage);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txtbx_name);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_main";
            this.Text = "Private data";
            this.Shown += new System.EventHandler(this.Frm_main_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Frm_main_MouseDown);
            this.metroTabControl1.ResumeLayout(false);
            this.tab_text.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage tab_text;
        private MetroFramework.Controls.MetroTextBox txtbx_content;
        private MetroFramework.Controls.MetroTabPage tab_pictures;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtbx_name;
        private MetroFramework.Controls.MetroButton btn_save;
        private MetroFramework.Controls.MetroButton btn_load;
        private MetroFramework.Controls.MetroButton btn_importImage;
        private MetroFramework.Controls.MetroButton btn_settings;
    }
}

