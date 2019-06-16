using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Drawing;

namespace MetroFramework.Controls
{
	// Token: 0x02000036 RID: 54
	[Designer("MetroFramework.Design.MetroTextBoxDesigner, MetroFramework.Design, Version=1.2.0.3, Culture=neutral, PublicKeyToken=5f91a84759bf584a")]
	public class MetroTextBox : MetroControlBase
	{
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000299 RID: 665 RVA: 0x00009814 File Offset: 0x00007A14
		// (set) Token: 0x0600029A RID: 666 RVA: 0x0000981C File Offset: 0x00007A1C
		[Category("Metro Appearance")]
		[DefaultValue(false)]
		public bool UseStyleColors
		{
			get
			{
				return this.useStyleColors;
			}
			set
			{
				this.useStyleColors = value;
				this.UpdateBaseTextBox();
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600029B RID: 667 RVA: 0x0000982B File Offset: 0x00007A2B
		// (set) Token: 0x0600029C RID: 668 RVA: 0x00009833 File Offset: 0x00007A33
		[DefaultValue(MetroTextBoxSize.Small)]
		[Category("Metro Appearance")]
		public MetroTextBoxSize FontSize
		{
			get
			{
				return this.metroTextBoxSize;
			}
			set
			{
				this.metroTextBoxSize = value;
				this.UpdateBaseTextBox();
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600029D RID: 669 RVA: 0x00009842 File Offset: 0x00007A42
		// (set) Token: 0x0600029E RID: 670 RVA: 0x0000984A File Offset: 0x00007A4A
		[DefaultValue(MetroTextBoxWeight.Regular)]
		[Category("Metro Appearance")]
		public MetroTextBoxWeight FontWeight
		{
			get
			{
				return this.metroTextBoxWeight;
			}
			set
			{
				this.metroTextBoxWeight = value;
				this.UpdateBaseTextBox();
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600029F RID: 671 RVA: 0x00009859 File Offset: 0x00007A59
		// (set) Token: 0x060002A0 RID: 672 RVA: 0x00009861 File Offset: 0x00007A61
		[Category("Metro Appearance")]
		[DefaultValue(false)]
		public bool CustomBackground
		{
			get
			{
				return this.useCustomBackground;
			}
			set
			{
				this.useCustomBackground = value;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x0000986A File Offset: 0x00007A6A
		// (set) Token: 0x060002A2 RID: 674 RVA: 0x00009872 File Offset: 0x00007A72
		[Category("Metro Appearance")]
		[DefaultValue(false)]
		public bool CustomForeColor
		{
			get
			{
				return this.useCustomForeColor;
			}
			set
			{
				this.useCustomForeColor = value;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x0000987B File Offset: 0x00007A7B
		// (set) Token: 0x060002A4 RID: 676 RVA: 0x00009888 File Offset: 0x00007A88
		[DefaultValue("")]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Category("Metro Appearance")]
		public string PromptText
		{
			get
			{
				return this.baseTextBox.PromptText;
			}
			set
			{
				this.baseTextBox.PromptText = value;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x00009896 File Offset: 0x00007A96
		// (set) Token: 0x060002A6 RID: 678 RVA: 0x000098A3 File Offset: 0x00007AA3
		public override ContextMenu ContextMenu
		{
			get
			{
				return this.baseTextBox.ContextMenu;
			}
			set
			{
				this.ContextMenu = value;
				this.baseTextBox.ContextMenu = value;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x000098B8 File Offset: 0x00007AB8
		// (set) Token: 0x060002A8 RID: 680 RVA: 0x000098C5 File Offset: 0x00007AC5
		public override ContextMenuStrip ContextMenuStrip
		{
			get
			{
				return this.baseTextBox.ContextMenuStrip;
			}
			set
			{
				this.ContextMenuStrip = value;
				this.baseTextBox.ContextMenuStrip = value;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060002A9 RID: 681 RVA: 0x000098DA File Offset: 0x00007ADA
		// (set) Token: 0x060002AA RID: 682 RVA: 0x000098E7 File Offset: 0x00007AE7
		[DefaultValue(false)]
		public bool Multiline
		{
			get
			{
				return this.baseTextBox.Multiline;
			}
			set
			{
				this.baseTextBox.Multiline = value;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060002AB RID: 683 RVA: 0x000098F5 File Offset: 0x00007AF5
		// (set) Token: 0x060002AC RID: 684 RVA: 0x00009902 File Offset: 0x00007B02
		public override string Text
		{
			get
			{
				return this.baseTextBox.Text;
			}
			set
			{
				this.baseTextBox.Text = value;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060002AD RID: 685 RVA: 0x00009910 File Offset: 0x00007B10
		// (set) Token: 0x060002AE RID: 686 RVA: 0x0000991D File Offset: 0x00007B1D
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string SelectedText
		{
			get
			{
				return this.baseTextBox.SelectedText;
			}
			set
			{
				this.baseTextBox.Text = value;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060002AF RID: 687 RVA: 0x0000992B File Offset: 0x00007B2B
		// (set) Token: 0x060002B0 RID: 688 RVA: 0x00009938 File Offset: 0x00007B38
		[DefaultValue(false)]
		public bool ReadOnly
		{
			get
			{
				return this.baseTextBox.ReadOnly;
			}
			set
			{
				this.baseTextBox.ReadOnly = value;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x00009946 File Offset: 0x00007B46
		// (set) Token: 0x060002B2 RID: 690 RVA: 0x00009953 File Offset: 0x00007B53
		[DefaultValue('\0')]
		public char PasswordChar
		{
			get
			{
				return this.baseTextBox.PasswordChar;
			}
			set
			{
				this.baseTextBox.PasswordChar = value;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x00009961 File Offset: 0x00007B61
		// (set) Token: 0x060002B4 RID: 692 RVA: 0x0000996E File Offset: 0x00007B6E
		[DefaultValue(false)]
		public bool UseSystemPasswordChar
		{
			get
			{
				return this.baseTextBox.UseSystemPasswordChar;
			}
			set
			{
				this.baseTextBox.UseSystemPasswordChar = value;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x0000997C File Offset: 0x00007B7C
		// (set) Token: 0x060002B6 RID: 694 RVA: 0x00009989 File Offset: 0x00007B89
		[DefaultValue(HorizontalAlignment.Left)]
		public HorizontalAlignment TextAlign
		{
			get
			{
				return this.baseTextBox.TextAlign;
			}
			set
			{
				this.baseTextBox.TextAlign = value;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x00009997 File Offset: 0x00007B97
		// (set) Token: 0x060002B8 RID: 696 RVA: 0x000099A4 File Offset: 0x00007BA4
		[DefaultValue(true)]
		public new bool TabStop
		{
			get
			{
				return this.baseTextBox.TabStop;
			}
			set
			{
				this.baseTextBox.TabStop = value;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x000099B2 File Offset: 0x00007BB2
		// (set) Token: 0x060002BA RID: 698 RVA: 0x000099BF File Offset: 0x00007BBF
		[DefaultValue(32767)]
		public int MaxLength
		{
			get
			{
				return this.baseTextBox.MaxLength;
			}
			set
			{
				this.baseTextBox.MaxLength = value;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060002BB RID: 699 RVA: 0x000099CD File Offset: 0x00007BCD
		// (set) Token: 0x060002BC RID: 700 RVA: 0x000099DA File Offset: 0x00007BDA
		[DefaultValue(ScrollBars.None)]
		public ScrollBars ScrollBars
		{
			get
			{
				return this.baseTextBox.ScrollBars;
			}
			set
			{
				this.baseTextBox.ScrollBars = value;
			}
		}

		// Token: 0x060002BD RID: 701 RVA: 0x000099E8 File Offset: 0x00007BE8
		public MetroTextBox()
		{
			base.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
			base.TabStop = false;
			this.CreateBaseTextBox();
			this.UpdateBaseTextBox();
			this.AddEventHandler();
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060002BE RID: 702 RVA: 0x00009A1C File Offset: 0x00007C1C
		// (remove) Token: 0x060002BF RID: 703 RVA: 0x00009A54 File Offset: 0x00007C54
		public event EventHandler AcceptsTabChanged;

		// Token: 0x060002C0 RID: 704 RVA: 0x00009A89 File Offset: 0x00007C89
		private void BaseTextBoxAcceptsTabChanged(object sender, EventArgs e)
		{
			if (this.AcceptsTabChanged != null)
			{
				this.AcceptsTabChanged(this, e);
			}
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00009AA0 File Offset: 0x00007CA0
		private void BaseTextBoxSizeChanged(object sender, EventArgs e)
		{
			base.OnSizeChanged(e);
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00009AA9 File Offset: 0x00007CA9
		private void BaseTextBoxCursorChanged(object sender, EventArgs e)
		{
			base.OnCursorChanged(e);
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x00009AB2 File Offset: 0x00007CB2
		private void BaseTextBoxContextMenuStripChanged(object sender, EventArgs e)
		{
			base.OnContextMenuStripChanged(e);
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00009ABB File Offset: 0x00007CBB
		private void BaseTextBoxContextMenuChanged(object sender, EventArgs e)
		{
			base.OnContextMenuChanged(e);
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00009AC4 File Offset: 0x00007CC4
		private void BaseTextBoxClientSizeChanged(object sender, EventArgs e)
		{
			base.OnClientSizeChanged(e);
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x00009ACD File Offset: 0x00007CCD
		private void BaseTextBoxClick(object sender, EventArgs e)
		{
			base.OnClick(e);
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00009AD6 File Offset: 0x00007CD6
		private void BaseTextBoxChangeUiCues(object sender, UICuesEventArgs e)
		{
			base.OnChangeUICues(e);
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x00009ADF File Offset: 0x00007CDF
		private void BaseTextBoxCausesValidationChanged(object sender, EventArgs e)
		{
			base.OnCausesValidationChanged(e);
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00009AE8 File Offset: 0x00007CE8
		private void BaseTextBoxKeyUp(object sender, KeyEventArgs e)
		{
			base.OnKeyUp(e);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00009AF1 File Offset: 0x00007CF1
		private void BaseTextBoxKeyPress(object sender, KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x00009AFA File Offset: 0x00007CFA
		private void BaseTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			base.OnKeyDown(e);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00009B03 File Offset: 0x00007D03
		private void BaseTextBoxTextChanged(object sender, EventArgs e)
		{
			base.OnTextChanged(e);
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00009B0C File Offset: 0x00007D0C
		public void Select(int start, int length)
		{
			this.baseTextBox.Select(start, length);
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00009B1B File Offset: 0x00007D1B
		public void SelectAll()
		{
			this.baseTextBox.SelectAll();
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00009B28 File Offset: 0x00007D28
		public void Clear()
		{
			this.baseTextBox.Clear();
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00009B35 File Offset: 0x00007D35
		public void AppendText(string text)
		{
			this.baseTextBox.AppendText(text);
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00009B44 File Offset: 0x00007D44
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (this.useCustomBackground)
			{
				e.Graphics.Clear(this.BackColor);
				this.baseTextBox.BackColor = this.BackColor;
			}
			else
			{
				e.Graphics.Clear(MetroPaint.BackColor.Button.Normal(base.Theme));
				this.baseTextBox.BackColor = MetroPaint.BackColor.Button.Normal(base.Theme);
			}
			if (this.useCustomForeColor)
			{
				this.baseTextBox.ForeColor = this.ForeColor;
			}
			else
			{
				this.baseTextBox.ForeColor = MetroPaint.ForeColor.Button.Normal(base.Theme);
			}
			Color color = MetroPaint.BorderColor.Button.Normal(base.Theme);
			if (this.useStyleColors)
			{
				color = MetroPaint.GetStyleColor(base.Style);
			}
			using (Pen pen = new Pen(color))
			{
				e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
			}
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00009C48 File Offset: 0x00007E48
		public override void Refresh()
		{
			base.Refresh();
			this.UpdateBaseTextBox();
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00009C56 File Offset: 0x00007E56
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.UpdateBaseTextBox();
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00009C68 File Offset: 0x00007E68
		private void CreateBaseTextBox()
		{
			if (this.baseTextBox != null)
			{
				return;
			}
			this.baseTextBox = new MetroTextBox.PromptedTextBox();
			this.baseTextBox.BorderStyle = BorderStyle.None;
			this.baseTextBox.Font = MetroFonts.TextBox(this.metroTextBoxSize, this.metroTextBoxWeight);
			this.baseTextBox.Location = new Point(3, 3);
			this.baseTextBox.Size = new Size(base.Width - 6, base.Height - 6);
			base.Size = new Size(this.baseTextBox.Width + 6, this.baseTextBox.Height + 6);
			this.baseTextBox.TabStop = true;
			base.Controls.Add(this.baseTextBox);
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x00009D28 File Offset: 0x00007F28
		private void AddEventHandler()
		{
			this.baseTextBox.AcceptsTabChanged += this.BaseTextBoxAcceptsTabChanged;
			this.baseTextBox.CausesValidationChanged += this.BaseTextBoxCausesValidationChanged;
			this.baseTextBox.ChangeUICues += this.BaseTextBoxChangeUiCues;
			this.baseTextBox.Click += this.BaseTextBoxClick;
			this.baseTextBox.ClientSizeChanged += this.BaseTextBoxClientSizeChanged;
			this.baseTextBox.ContextMenuChanged += this.BaseTextBoxContextMenuChanged;
			this.baseTextBox.ContextMenuStripChanged += this.BaseTextBoxContextMenuStripChanged;
			this.baseTextBox.CursorChanged += this.BaseTextBoxCursorChanged;
			this.baseTextBox.KeyDown += this.BaseTextBoxKeyDown;
			this.baseTextBox.KeyPress += this.BaseTextBoxKeyPress;
			this.baseTextBox.KeyUp += this.BaseTextBoxKeyUp;
			this.baseTextBox.SizeChanged += this.BaseTextBoxSizeChanged;
			this.baseTextBox.TextChanged += this.BaseTextBoxTextChanged;
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00009E60 File Offset: 0x00008060
		private void UpdateBaseTextBox()
		{
			if (this.baseTextBox == null)
			{
				return;
			}
			this.baseTextBox.Font = MetroFonts.TextBox(this.metroTextBoxSize, this.metroTextBoxWeight);
			this.baseTextBox.Location = new Point(3, 3);
			this.baseTextBox.Size = new Size(base.Width - 6, base.Height - 6);
		}

		// Token: 0x040000B8 RID: 184
		private MetroTextBox.PromptedTextBox baseTextBox;

		// Token: 0x040000B9 RID: 185
		private bool useStyleColors;

		// Token: 0x040000BA RID: 186
		private MetroTextBoxSize metroTextBoxSize;

		// Token: 0x040000BB RID: 187
		private MetroTextBoxWeight metroTextBoxWeight = MetroTextBoxWeight.Regular;

		// Token: 0x040000BC RID: 188
		private bool useCustomBackground;

		// Token: 0x040000BD RID: 189
		private bool useCustomForeColor;

		// Token: 0x02000037 RID: 55
		private class PromptedTextBox : TextBox
		{
			// Token: 0x170000BC RID: 188
			// (get) Token: 0x060002D7 RID: 727 RVA: 0x00009EC4 File Offset: 0x000080C4
			// (set) Token: 0x060002D8 RID: 728 RVA: 0x00009ECC File Offset: 0x000080CC
			[EditorBrowsable(EditorBrowsableState.Always)]
			[Browsable(true)]
			[DefaultValue("")]
			public string PromptText
			{
				get
				{
					return this.promptText;
				}
				set
				{
					this.promptText = value.Trim();
					base.Invalidate();
				}
			}

			// Token: 0x060002D9 RID: 729 RVA: 0x00009EE0 File Offset: 0x000080E0
			private void DrawTextPrompt()
			{
				using (Graphics graphics = base.CreateGraphics())
				{
					this.DrawTextPrompt(graphics);
				}
			}

			// Token: 0x060002DA RID: 730 RVA: 0x00009F18 File Offset: 0x00008118
			private void DrawTextPrompt(Graphics g)
			{
				TextFormatFlags textFormatFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding;
				Rectangle clientRectangle = base.ClientRectangle;
				switch (base.TextAlign)
				{
				case HorizontalAlignment.Left:
					clientRectangle.Offset(1, 1);
					break;
				case HorizontalAlignment.Right:
					textFormatFlags |= TextFormatFlags.Right;
					clientRectangle.Offset(0, 1);
					break;
				case HorizontalAlignment.Center:
					textFormatFlags |= TextFormatFlags.HorizontalCenter;
					clientRectangle.Offset(0, 1);
					break;
				}
				TextRenderer.DrawText(g, this.promptText, this.Font, clientRectangle, SystemColors.GrayText, this.BackColor, textFormatFlags);
			}

			// Token: 0x060002DB RID: 731 RVA: 0x00009F93 File Offset: 0x00008193
			protected override void OnPaint(PaintEventArgs e)
			{
				base.OnPaint(e);
				if (this.drawPrompt)
				{
					this.DrawTextPrompt(e.Graphics);
				}
			}

			// Token: 0x060002DC RID: 732 RVA: 0x00009FB0 File Offset: 0x000081B0
			protected override void OnTextAlignChanged(EventArgs e)
			{
				base.OnTextAlignChanged(e);
				base.Invalidate();
			}

			// Token: 0x060002DD RID: 733 RVA: 0x00009FBF File Offset: 0x000081BF
			protected override void OnTextChanged(EventArgs e)
			{
				base.OnTextChanged(e);
				this.drawPrompt = (this.Text.Length == 0);
			}

			// Token: 0x060002DE RID: 734 RVA: 0x00009FDC File Offset: 0x000081DC
			protected override void WndProc(ref Message m)
			{
				base.WndProc(ref m);
				if ((m.Msg == 15 || m.Msg == 8465) && this.drawPrompt && !base.GetStyle(ControlStyles.UserPaint))
				{
					this.DrawTextPrompt();
				}
			}

			// Token: 0x040000BF RID: 191
			private const int OCM_COMMAND = 8465;

			// Token: 0x040000C0 RID: 192
			private const int WM_PAINT = 15;

			// Token: 0x040000C1 RID: 193
			private bool drawPrompt;

			// Token: 0x040000C2 RID: 194
			private string promptText = "";
		}
	}
}
