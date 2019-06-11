namespace PrivateData
{
    partial class frm_main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
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
            this.txtbx_content = new System.Windows.Forms.RichTextBox();
            this.txtbx_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab_text = new System.Windows.Forms.TabPage();
            this.tab_pictures = new System.Windows.Forms.TabPage();
            this.btn_importImage = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tab_text.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbx_content
            // 
            this.txtbx_content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbx_content.Location = new System.Drawing.Point(3, 6);
            this.txtbx_content.Name = "txtbx_content";
            this.txtbx_content.Size = new System.Drawing.Size(541, 210);
            this.txtbx_content.TabIndex = 0;
            this.txtbx_content.Text = "";
            // 
            // txtbx_name
            // 
            this.txtbx_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbx_name.Location = new System.Drawing.Point(84, 12);
            this.txtbx_name.Name = "txtbx_name";
            this.txtbx_name.Size = new System.Drawing.Size(579, 20);
            this.txtbx_name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название: ";
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Location = new System.Drawing.Point(556, 363);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(119, 23);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "Сохранить";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.Btn_save_Click);
            // 
            // btn_load
            // 
            this.btn_load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_load.Location = new System.Drawing.Point(452, 362);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(98, 23);
            this.btn_load.TabIndex = 4;
            this.btn_load.Text = "Загрузить файл";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.Btn_load_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tab_text);
            this.tabControl.Controls.Add(this.tab_pictures);
            this.tabControl.Location = new System.Drawing.Point(2, 38);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(673, 319);
            this.tabControl.TabIndex = 5;
            // 
            // tab_text
            // 
            this.tab_text.Controls.Add(this.txtbx_content);
            this.tab_text.Location = new System.Drawing.Point(4, 22);
            this.tab_text.Name = "tab_text";
            this.tab_text.Padding = new System.Windows.Forms.Padding(3);
            this.tab_text.Size = new System.Drawing.Size(552, 222);
            this.tab_text.TabIndex = 0;
            this.tab_text.Text = "Текст";
            this.tab_text.UseVisualStyleBackColor = true;
            // 
            // tab_pictures
            // 
            this.tab_pictures.AutoScroll = true;
            this.tab_pictures.Location = new System.Drawing.Point(4, 22);
            this.tab_pictures.Name = "tab_pictures";
            this.tab_pictures.Padding = new System.Windows.Forms.Padding(3);
            this.tab_pictures.Size = new System.Drawing.Size(665, 293);
            this.tab_pictures.TabIndex = 1;
            this.tab_pictures.Text = "Изображения";
            this.tab_pictures.UseVisualStyleBackColor = true;
            // 
            // btn_importImage
            // 
            this.btn_importImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_importImage.Location = new System.Drawing.Point(303, 363);
            this.btn_importImage.Name = "btn_importImage";
            this.btn_importImage.Size = new System.Drawing.Size(143, 22);
            this.btn_importImage.TabIndex = 0;
            this.btn_importImage.Text = "Добавить изображения";
            this.btn_importImage.UseVisualStyleBackColor = true;
            this.btn_importImage.Click += new System.EventHandler(this.Btn_importImage_Click);
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 388);
            this.Controls.Add(this.btn_importImage);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbx_name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_main";
            this.Text = "Private data";
            this.Shown += new System.EventHandler(this.Frm_main_Shown);
            this.tabControl.ResumeLayout(false);
            this.tab_text.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtbx_content;
        private System.Windows.Forms.TextBox txtbx_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tab_text;
        private System.Windows.Forms.TabPage tab_pictures;
        private System.Windows.Forms.Button btn_importImage;
    }
}

