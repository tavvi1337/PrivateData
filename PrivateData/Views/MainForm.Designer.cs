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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_main));
            this.tabControl_ = new VisualPlus.Toolkit.Controls.Navigation.VisualTabControl();
            this.tab_text_ = new VisualPlus.Toolkit.Child.VisualTabPage();
            this.txtbx_content_ = new VisualPlus.Toolkit.Controls.Editors.VisualRichTextBox();
            this.tab_pictures_ = new VisualPlus.Toolkit.Child.VisualTabPage();
            this.btn_save_ = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.btn_load_ = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.btn_importImage_ = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.btn_settings_ = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.visualLabel1 = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.txtbx_name_ = new VisualPlus.Toolkit.Controls.Editors.VisualTextBox();
            this.tabControl_.SuspendLayout();
            this.tab_text_.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_
            // 
            this.tabControl_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_.Controls.Add(this.tab_text_);
            this.tabControl_.Controls.Add(this.tab_pictures_);
            this.tabControl_.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl_.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl_.ItemSize = new System.Drawing.Size(100, 25);
            this.tabControl_.Location = new System.Drawing.Point(9, 62);
            this.tabControl_.MinimumSize = new System.Drawing.Size(144, 85);
            this.tabControl_.Name = "tabControl_";
            this.tabControl_.SelectedIndex = 0;
            this.tabControl_.SelectorAlignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl_.SelectorSpacing = 10;
            this.tabControl_.SelectorThickness = 5;
            this.tabControl_.SelectorType = VisualPlus.Toolkit.Controls.Navigation.VisualTabControl.SelectorTypes.Arrow;
            this.tabControl_.SelectorVisible = true;
            this.tabControl_.Separator = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tabControl_.SeparatorSpacing = 2;
            this.tabControl_.SeparatorThickness = 2F;
            this.tabControl_.Size = new System.Drawing.Size(693, 317);
            this.tabControl_.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_.State = VisualPlus.Enumerators.MouseStates.Normal;
            this.tabControl_.TabIndex = 7;
            this.tabControl_.TabMenu = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.tabControl_.TabSelector = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.tabControl_.TextRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // tab_text_
            // 
            this.tab_text_.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.tab_text_.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tab_text_.Border.Rounding = 6;
            this.tab_text_.Border.Thickness = 1;
            this.tab_text_.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rectangle;
            this.tab_text_.Border.Visible = false;
            this.tab_text_.Controls.Add(this.txtbx_content_);
            this.tab_text_.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(181)))), ((int)(((byte)(187)))));
            this.tab_text_.HeaderImage = null;
            this.tab_text_.Image = null;
            this.tab_text_.ImageSize = new System.Drawing.Size(16, 16);
            this.tab_text_.Location = new System.Drawing.Point(4, 29);
            this.tab_text_.Name = "tab_text_";
            this.tab_text_.Rectangle = new System.Drawing.Rectangle(2, 2, 100, 25);
            this.tab_text_.Size = new System.Drawing.Size(685, 284);
            this.tab_text_.TabHover = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(38)))));
            this.tab_text_.TabIndex = 0;
            this.tab_text_.TabNormal = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.tab_text_.TabSelected = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(76)))), ((int)(((byte)(88)))));
            this.tab_text_.Text = "Текст";
            this.tab_text_.TextAlignment = System.Drawing.StringAlignment.Center;
            this.tab_text_.TextImageRelation = VisualPlus.Toolkit.Child.VisualTabPage.TextImageRelations.Text;
            this.tab_text_.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.tab_text_.TextSelected = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(220)))), ((int)(((byte)(227)))));
            // 
            // txtbx_content_
            // 
            this.txtbx_content_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbx_content_.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.txtbx_content_.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.txtbx_content_.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtbx_content_.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.txtbx_content_.Border.HoverVisible = true;
            this.txtbx_content_.Border.Rounding = 6;
            this.txtbx_content_.Border.Thickness = 1;
            this.txtbx_content_.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.txtbx_content_.Border.Visible = true;
            this.txtbx_content_.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtbx_content_.Location = new System.Drawing.Point(3, 3);
            this.txtbx_content_.MaxLength = 2147483647;
            this.txtbx_content_.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.txtbx_content_.Name = "txtbx_content_";
            this.txtbx_content_.ReadOnly = false;
            this.txtbx_content_.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.txtbx_content_.ShowSelectionMargin = false;
            this.txtbx_content_.Size = new System.Drawing.Size(679, 278);
            this.txtbx_content_.TabIndex = 0;
            this.txtbx_content_.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.txtbx_content_.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtbx_content_.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtbx_content_.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtbx_content_.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.txtbx_content_.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.txtbx_content_.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // tab_pictures_
            // 
            this.tab_pictures_.AutoScroll = true;
            this.tab_pictures_.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.tab_pictures_.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tab_pictures_.Border.Rounding = 6;
            this.tab_pictures_.Border.Thickness = 1;
            this.tab_pictures_.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rectangle;
            this.tab_pictures_.Border.Visible = false;
            this.tab_pictures_.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(181)))), ((int)(((byte)(187)))));
            this.tab_pictures_.HeaderImage = null;
            this.tab_pictures_.Image = null;
            this.tab_pictures_.ImageSize = new System.Drawing.Size(16, 16);
            this.tab_pictures_.Location = new System.Drawing.Point(4, 29);
            this.tab_pictures_.Name = "tab_pictures_";
            this.tab_pictures_.Rectangle = new System.Drawing.Rectangle(102, 2, 100, 25);
            this.tab_pictures_.Size = new System.Drawing.Size(685, 284);
            this.tab_pictures_.TabHover = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(38)))));
            this.tab_pictures_.TabIndex = 1;
            this.tab_pictures_.TabNormal = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.tab_pictures_.TabSelected = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(76)))), ((int)(((byte)(88)))));
            this.tab_pictures_.Text = "Изображения";
            this.tab_pictures_.TextAlignment = System.Drawing.StringAlignment.Center;
            this.tab_pictures_.TextImageRelation = VisualPlus.Toolkit.Child.VisualTabPage.TextImageRelations.Text;
            this.tab_pictures_.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.tab_pictures_.TextSelected = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(220)))), ((int)(((byte)(227)))));
            // 
            // btn_save_
            // 
            this.btn_save_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save_.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_save_.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btn_save_.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_save_.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_save_.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btn_save_.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.btn_save_.Border.HoverVisible = true;
            this.btn_save_.Border.Rounding = 6;
            this.btn_save_.Border.Thickness = 1;
            this.btn_save_.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.btn_save_.Border.Visible = true;
            this.btn_save_.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_save_.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_save_.Image = null;
            this.btn_save_.Location = new System.Drawing.Point(589, 385);
            this.btn_save_.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.btn_save_.Name = "btn_save_";
            this.btn_save_.Size = new System.Drawing.Size(113, 30);
            this.btn_save_.TabIndex = 8;
            this.btn_save_.Text = "Сохранить";
            this.btn_save_.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btn_save_.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.btn_save_.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_save_.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_save_.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_save_.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btn_save_.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.btn_save_.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btn_save_.Click += new System.EventHandler(this.Btn_save_Click);
            // 
            // btn_load_
            // 
            this.btn_load_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_load_.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_load_.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btn_load_.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_load_.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_load_.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btn_load_.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.btn_load_.Border.HoverVisible = true;
            this.btn_load_.Border.Rounding = 6;
            this.btn_load_.Border.Thickness = 1;
            this.btn_load_.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.btn_load_.Border.Visible = true;
            this.btn_load_.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_load_.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_load_.Image = null;
            this.btn_load_.Location = new System.Drawing.Point(470, 385);
            this.btn_load_.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.btn_load_.Name = "btn_load_";
            this.btn_load_.Size = new System.Drawing.Size(113, 30);
            this.btn_load_.TabIndex = 9;
            this.btn_load_.Text = "Загрузить файл";
            this.btn_load_.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btn_load_.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.btn_load_.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_load_.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_load_.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_load_.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btn_load_.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.btn_load_.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btn_load_.Click += new System.EventHandler(this.Btn_load_Click);
            // 
            // btn_importImage_
            // 
            this.btn_importImage_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_importImage_.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_importImage_.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btn_importImage_.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_importImage_.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_importImage_.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btn_importImage_.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.btn_importImage_.Border.HoverVisible = true;
            this.btn_importImage_.Border.Rounding = 6;
            this.btn_importImage_.Border.Thickness = 1;
            this.btn_importImage_.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.btn_importImage_.Border.Visible = true;
            this.btn_importImage_.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_importImage_.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_importImage_.Image = null;
            this.btn_importImage_.Location = new System.Drawing.Point(351, 385);
            this.btn_importImage_.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.btn_importImage_.Name = "btn_importImage_";
            this.btn_importImage_.Size = new System.Drawing.Size(113, 30);
            this.btn_importImage_.TabIndex = 10;
            this.btn_importImage_.Text = "Добавить изображения";
            this.btn_importImage_.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btn_importImage_.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.btn_importImage_.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_importImage_.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_importImage_.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_importImage_.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btn_importImage_.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.btn_importImage_.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btn_importImage_.Click += new System.EventHandler(this.Btn_importImage_Click);
            // 
            // btn_settings_
            // 
            this.btn_settings_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_settings_.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_settings_.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btn_settings_.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_settings_.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_settings_.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btn_settings_.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.btn_settings_.Border.HoverVisible = true;
            this.btn_settings_.Border.Rounding = 6;
            this.btn_settings_.Border.Thickness = 1;
            this.btn_settings_.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.btn_settings_.Border.Visible = true;
            this.btn_settings_.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_settings_.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_settings_.Image = null;
            this.btn_settings_.Location = new System.Drawing.Point(232, 385);
            this.btn_settings_.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.btn_settings_.Name = "btn_settings_";
            this.btn_settings_.Size = new System.Drawing.Size(113, 30);
            this.btn_settings_.TabIndex = 11;
            this.btn_settings_.Text = "Настройки";
            this.btn_settings_.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btn_settings_.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.btn_settings_.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_settings_.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_settings_.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_settings_.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btn_settings_.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.btn_settings_.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btn_settings_.Click += new System.EventHandler(this.Btn_settings_Click);
            // 
            // visualLabel1
            // 
            this.visualLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.visualLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel1.Location = new System.Drawing.Point(9, 33);
            this.visualLabel1.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.visualLabel1.Name = "visualLabel1";
            this.visualLabel1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.visualLabel1.Outline = false;
            this.visualLabel1.OutlineColor = System.Drawing.Color.Red;
            this.visualLabel1.OutlineLocation = new System.Drawing.Point(0, 0);
            this.visualLabel1.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel1.ReflectionSpacing = 0;
            this.visualLabel1.ShadowColor = System.Drawing.Color.Black;
            this.visualLabel1.ShadowDirection = 315;
            this.visualLabel1.ShadowLocation = new System.Drawing.Point(0, 0);
            this.visualLabel1.ShadowOpacity = 100;
            this.visualLabel1.Size = new System.Drawing.Size(114, 23);
            this.visualLabel1.TabIndex = 12;
            this.visualLabel1.Text = "Название: ";
            this.visualLabel1.TextAlignment = System.Drawing.StringAlignment.Near;
            this.visualLabel1.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.visualLabel1.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.visualLabel1.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel1.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel1.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel1.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.visualLabel1.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.visualLabel1.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // txtbx_name_
            // 
            this.txtbx_name_.AlphaNumeric = false;
            this.txtbx_name_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbx_name_.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtbx_name_.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.txtbx_name_.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtbx_name_.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.txtbx_name_.Border.HoverVisible = true;
            this.txtbx_name_.Border.Rounding = 6;
            this.txtbx_name_.Border.Thickness = 1;
            this.txtbx_name_.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.txtbx_name_.Border.Visible = true;
            this.txtbx_name_.ButtonBorder.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtbx_name_.ButtonBorder.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.txtbx_name_.ButtonBorder.HoverVisible = true;
            this.txtbx_name_.ButtonBorder.Rounding = 6;
            this.txtbx_name_.ButtonBorder.Thickness = 1;
            this.txtbx_name_.ButtonBorder.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.txtbx_name_.ButtonBorder.Visible = true;
            this.txtbx_name_.ButtonColor.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtbx_name_.ButtonColor.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtbx_name_.ButtonColor.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtbx_name_.ButtonColor.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtbx_name_.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtbx_name_.ButtonIndent = 3;
            this.txtbx_name_.ButtonText = "visualButton";
            this.txtbx_name_.ButtonVisible = false;
            this.txtbx_name_.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtbx_name_.Image = null;
            this.txtbx_name_.ImageSize = new System.Drawing.Size(16, 16);
            this.txtbx_name_.ImageVisible = false;
            this.txtbx_name_.ImageWidth = 35;
            this.txtbx_name_.Location = new System.Drawing.Point(74, 33);
            this.txtbx_name_.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.txtbx_name_.Name = "txtbx_name_";
            this.txtbx_name_.PasswordChar = '\0';
            this.txtbx_name_.ReadOnly = false;
            this.txtbx_name_.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbx_name_.Size = new System.Drawing.Size(628, 23);
            this.txtbx_name_.TabIndex = 13;
            this.txtbx_name_.TextBoxWidth = 618;
            this.txtbx_name_.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.txtbx_name_.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtbx_name_.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtbx_name_.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtbx_name_.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.txtbx_name_.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.txtbx_name_.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtbx_name_.Watermark.Active = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtbx_name_.Watermark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtbx_name_.Watermark.Inactive = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.txtbx_name_.Watermark.Text = "Watermark text";
            this.txtbx_name_.Watermark.Visible = false;
            this.txtbx_name_.WordWrap = true;
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.Border.HoverVisible = true;
            this.Border.Rounding = 6;
            this.Border.Thickness = 3;
            this.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rectangle;
            this.Border.Visible = true;
            this.ClientSize = new System.Drawing.Size(712, 423);
            // 
            // 
            // 
            this.ControlBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlBox.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.ControlBox.HelpButton.BackColorState.Disabled = System.Drawing.Color.Transparent;
            this.ControlBox.HelpButton.BackColorState.Enabled = System.Drawing.Color.Transparent;
            this.ControlBox.HelpButton.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.ControlBox.HelpButton.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.HelpButton.BoxType = VisualPlus.Toolkit.VisualBase.ControlBoxButton.ControlBoxType.Default;
            this.ControlBox.HelpButton.ForeColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.HelpButton.ForeColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.HelpButton.ForeColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.HelpButton.ForeColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.HelpButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.ControlBox.HelpButton.Location = new System.Drawing.Point(0, 0);
            this.ControlBox.HelpButton.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.ControlBox.HelpButton.Name = "";
            this.ControlBox.HelpButton.OffsetLocation = new System.Drawing.Point(0, 1);
            this.ControlBox.HelpButton.Size = new System.Drawing.Size(24, 25);
            this.ControlBox.HelpButton.TabIndex = 0;
            this.ControlBox.HelpButton.Text = "s";
            this.ControlBox.HelpButton.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.ControlBox.HelpButton.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.HelpButton.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.HelpButton.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.HelpButton.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ControlBox.HelpButton.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.ControlBox.HelpButton.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ControlBox.HelpButton.Visible = false;
            this.ControlBox.Location = new System.Drawing.Point(232, 4);
            // 
            // 
            // 
            this.ControlBox.MaximizeButton.BackColorState.Disabled = System.Drawing.Color.Transparent;
            this.ControlBox.MaximizeButton.BackColorState.Enabled = System.Drawing.Color.Transparent;
            this.ControlBox.MaximizeButton.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.ControlBox.MaximizeButton.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.MaximizeButton.BoxType = VisualPlus.Toolkit.VisualBase.ControlBoxButton.ControlBoxType.Default;
            this.ControlBox.MaximizeButton.ForeColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.MaximizeButton.ForeColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MaximizeButton.ForeColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MaximizeButton.ForeColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MaximizeButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.ControlBox.MaximizeButton.Location = new System.Drawing.Point(24, 0);
            this.ControlBox.MaximizeButton.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.ControlBox.MaximizeButton.Name = "";
            this.ControlBox.MaximizeButton.OffsetLocation = new System.Drawing.Point(1, 1);
            this.ControlBox.MaximizeButton.Size = new System.Drawing.Size(24, 25);
            this.ControlBox.MaximizeButton.TabIndex = 2;
            this.ControlBox.MaximizeButton.Text = "1";
            this.ControlBox.MaximizeButton.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.ControlBox.MaximizeButton.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.MaximizeButton.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.MaximizeButton.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.MaximizeButton.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ControlBox.MaximizeButton.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.ControlBox.MaximizeButton.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // 
            // 
            this.ControlBox.MinimizeButton.BackColorState.Disabled = System.Drawing.Color.Transparent;
            this.ControlBox.MinimizeButton.BackColorState.Enabled = System.Drawing.Color.Transparent;
            this.ControlBox.MinimizeButton.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.ControlBox.MinimizeButton.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.MinimizeButton.BoxType = VisualPlus.Toolkit.VisualBase.ControlBoxButton.ControlBoxType.Default;
            this.ControlBox.MinimizeButton.ForeColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.MinimizeButton.ForeColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MinimizeButton.ForeColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MinimizeButton.ForeColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MinimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.ControlBox.MinimizeButton.Location = new System.Drawing.Point(0, 0);
            this.ControlBox.MinimizeButton.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.ControlBox.MinimizeButton.Name = "";
            this.ControlBox.MinimizeButton.OffsetLocation = new System.Drawing.Point(2, 0);
            this.ControlBox.MinimizeButton.Size = new System.Drawing.Size(24, 25);
            this.ControlBox.MinimizeButton.TabIndex = 1;
            this.ControlBox.MinimizeButton.Text = "0";
            this.ControlBox.MinimizeButton.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.ControlBox.MinimizeButton.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.MinimizeButton.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.MinimizeButton.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.MinimizeButton.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ControlBox.MinimizeButton.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.ControlBox.MinimizeButton.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ControlBox.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.ControlBox.Name = "";
            this.ControlBox.Size = new System.Drawing.Size(72, 25);
            this.ControlBox.TabIndex = 0;
            this.ControlBox.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.ControlBox.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ControlBox.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ControlBox.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.ControlBox.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.Controls.Add(this.txtbx_name_);
            this.Controls.Add(this.visualLabel1);
            this.Controls.Add(this.btn_settings_);
            this.Controls.Add(this.btn_importImage_);
            this.Controls.Add(this.btn_load_);
            this.Controls.Add(this.btn_save_);
            this.Controls.Add(this.tabControl_);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Image.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Image.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.Image.Border.HoverVisible = false;
            this.Image.Border.Rounding = 6;
            this.Image.Border.Thickness = 1;
            this.Image.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.Image.Border.Visible = false;
            this.Image.Image = ((System.Drawing.Bitmap)(resources.GetObject("resource.Image3")));
            this.Image.Point = new System.Drawing.Point(5, 7);
            this.Image.Size = new System.Drawing.Size(16, 16);
            this.Image.Visible = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "frm_main";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Private data";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.WindowTitleBarVisible = false;
            this.Shown += new System.EventHandler(this.Frm_main_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Frm_main_MouseDown);
            this.tabControl_.ResumeLayout(false);
            this.tab_text_.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private VisualPlus.Toolkit.Controls.Navigation.VisualTabControl tabControl_;
        private VisualPlus.Toolkit.Child.VisualTabPage tab_text_;
        private VisualPlus.Toolkit.Child.VisualTabPage tab_pictures_;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualButton btn_save_;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualButton btn_load_;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualButton btn_importImage_;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualButton btn_settings_;
        private VisualPlus.Toolkit.Controls.Editors.VisualRichTextBox txtbx_content_;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualLabel visualLabel1;
        private VisualPlus.Toolkit.Controls.Editors.VisualTextBox txtbx_name_;
    }
}

