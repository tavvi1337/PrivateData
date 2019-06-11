namespace PrivateData.Views.Dialogs
{
    partial class frm_settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_settings));
            this.btn_associate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_associate
            // 
            this.btn_associate.Location = new System.Drawing.Point(111, 23);
            this.btn_associate.Name = "btn_associate";
            this.btn_associate.Size = new System.Drawing.Size(135, 23);
            this.btn_associate.TabIndex = 0;
            this.btn_associate.Text = "Обновить ассоциацию";
            this.btn_associate.UseVisualStyleBackColor = true;
            this.btn_associate.Click += new System.EventHandler(this.Btn_associate_Click);
            // 
            // frm_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 264);
            this.Controls.Add(this.btn_associate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_associate;
    }
}