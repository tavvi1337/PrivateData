using System;
using System.ComponentModel;
using System.Drawing;
using System.Security;
using System.Windows.Forms;
using MetroFramework.Drawing;
using MetroFramework.Native;

namespace MetroFramework.Controls
{
	// Token: 0x0200002A RID: 42
	[Designer("MetroFramework.Design.MetroLabelDesigner, MetroFramework.Design, Version=1.2.0.3, Culture=neutral, PublicKeyToken=5f91a84759bf584a")]
	[ToolboxBitmap(typeof(Label))]
	public class MetroLabel : MetroLabelBase
	{
		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000183 RID: 387 RVA: 0x00005A0D File Offset: 0x00003C0D
		// (set) Token: 0x06000184 RID: 388 RVA: 0x00005A15 File Offset: 0x00003C15
		[DefaultValue(false)]
		[Category("Metro Appearance")]
		public bool UseStyleColors
		{
			get
			{
				return this.useStyleColors;
			}
			set
			{
				this.useStyleColors = value;
				this.Refresh();
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00005A24 File Offset: 0x00003C24
		// (set) Token: 0x06000186 RID: 390 RVA: 0x00005A2C File Offset: 0x00003C2C
		[Category("Metro Appearance")]
		[DefaultValue(MetroLabelSize.Medium)]
		public MetroLabelSize FontSize
		{
			get
			{
				return this.metroLabelSize;
			}
			set
			{
				this.metroLabelSize = value;
				this.Refresh();
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000187 RID: 391 RVA: 0x00005A3B File Offset: 0x00003C3B
		// (set) Token: 0x06000188 RID: 392 RVA: 0x00005A43 File Offset: 0x00003C43
		[Category("Metro Appearance")]
		[DefaultValue(MetroLabelWeight.Light)]
		public MetroLabelWeight FontWeight
		{
			get
			{
				return this.metroLabelWeight;
			}
			set
			{
				this.metroLabelWeight = value;
				this.Refresh();
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000189 RID: 393 RVA: 0x00005A52 File Offset: 0x00003C52
		// (set) Token: 0x0600018A RID: 394 RVA: 0x00005A5A File Offset: 0x00003C5A
		[Category("Metro Appearance")]
		[DefaultValue(MetroLabelMode.Default)]
		public MetroLabelMode LabelMode
		{
			get
			{
				return this.labelMode;
			}
			set
			{
				this.labelMode = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600018B RID: 395 RVA: 0x00005A63 File Offset: 0x00003C63
		// (set) Token: 0x0600018C RID: 396 RVA: 0x00005A6B File Offset: 0x00003C6B
		[DefaultValue(false)]
		[Category("Metro Appearance")]
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

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600018D RID: 397 RVA: 0x00005A74 File Offset: 0x00003C74
		// (set) Token: 0x0600018E RID: 398 RVA: 0x00005A7C File Offset: 0x00003C7C
		[DefaultValue(false)]
		[Category("Metro Appearance")]
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

		// Token: 0x0600018F RID: 399 RVA: 0x00005A88 File Offset: 0x00003C88
		public MetroLabel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.baseTextBox = new MetroLabel.DoubleBufferedTextBox();
			this.baseTextBox.Visible = false;
			base.Controls.Add(this.baseTextBox);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00005AE0 File Offset: 0x00003CE0
		protected override void OnPaint(PaintEventArgs e)
		{
			Color color;
			if (this.useCustomBackground)
			{
				color = this.BackColor;
			}
			else
			{
				color = MetroPaint.BackColor.Form(base.Theme);
				if (base.Parent is MetroTile)
				{
					color = MetroPaint.GetStyleColor(base.Style);
				}
			}
			Color foreColor;
			if (this.useCustomForeColor)
			{
				foreColor = this.ForeColor;
			}
			else if (!base.Enabled)
			{
				if (base.Parent != null)
				{
					if (base.Parent is MetroTile)
					{
						foreColor = MetroPaint.ForeColor.Tile.Disabled(base.Theme);
					}
					else
					{
						foreColor = MetroPaint.ForeColor.Label.Normal(base.Theme);
					}
				}
				else
				{
					foreColor = MetroPaint.ForeColor.Label.Disabled(base.Theme);
				}
			}
			else if (base.Parent != null)
			{
				if (base.Parent is MetroTile)
				{
					foreColor = MetroPaint.ForeColor.Tile.Normal(base.Theme);
				}
				else if (this.useStyleColors)
				{
					foreColor = MetroPaint.GetStyleColor(base.Style);
				}
				else
				{
					foreColor = MetroPaint.ForeColor.Label.Normal(base.Theme);
				}
			}
			else if (this.useStyleColors)
			{
				foreColor = MetroPaint.GetStyleColor(base.Style);
			}
			else
			{
				foreColor = MetroPaint.ForeColor.Label.Normal(base.Theme);
			}
			e.Graphics.Clear(color);
			if (this.LabelMode == MetroLabelMode.Selectable)
			{
				this.CreateBaseTextBox();
				this.UpdateBaseTextBox();
				if (!this.baseTextBox.Visible)
				{
					TextRenderer.DrawText(e.Graphics, this.Text, MetroFonts.Label(this.metroLabelSize, this.metroLabelWeight), base.ClientRectangle, foreColor, color, MetroPaint.GetTextFormatFlags(this.TextAlign));
					return;
				}
			}
			else
			{
				this.DestroyBaseTextbox();
				TextRenderer.DrawText(e.Graphics, this.Text, MetroFonts.Label(this.metroLabelSize, this.metroLabelWeight), base.ClientRectangle, foreColor, color, MetroPaint.GetTextFormatFlags(this.TextAlign));
			}
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00005C89 File Offset: 0x00003E89
		public override void Refresh()
		{
			if (this.LabelMode == MetroLabelMode.Selectable)
			{
				this.UpdateBaseTextBox();
			}
			base.Refresh();
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00005CA0 File Offset: 0x00003EA0
		public override Size GetPreferredSize(Size proposedSize)
		{
			base.GetPreferredSize(proposedSize);
			Size result;
			using (Graphics graphics = base.CreateGraphics())
			{
				proposedSize = new Size(int.MaxValue, int.MaxValue);
				result = TextRenderer.MeasureText(graphics, this.Text, MetroFonts.Label(this.metroLabelSize, this.metroLabelWeight), proposedSize, MetroPaint.GetTextFormatFlags(this.TextAlign));
			}
			return result;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00005D14 File Offset: 0x00003F14
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			base.Invalidate();
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00005D23 File Offset: 0x00003F23
		protected override void OnResize(EventArgs e)
		{
			if (this.LabelMode == MetroLabelMode.Selectable)
			{
				this.HideBaseTextBox();
			}
			base.OnResize(e);
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00005D3B File Offset: 0x00003F3B
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if (this.LabelMode == MetroLabelMode.Selectable)
			{
				this.ShowBaseTextBox();
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00005D54 File Offset: 0x00003F54
		private void CreateBaseTextBox()
		{
			if (this.baseTextBox.Visible && !this.firstInitialization)
			{
				return;
			}
			if (!this.firstInitialization)
			{
				return;
			}
			this.firstInitialization = false;
			if (!base.DesignMode)
			{
				Form form = base.FindForm();
				if (form != null)
				{
					form.ResizeBegin += this.parentForm_ResizeBegin;
					form.ResizeEnd += this.parentForm_ResizeEnd;
				}
			}
			this.baseTextBox.Visible = true;
			this.baseTextBox.BorderStyle = BorderStyle.None;
			this.baseTextBox.Font = MetroFonts.Label(this.metroLabelSize, this.metroLabelWeight);
			this.baseTextBox.Location = new Point(1, 0);
			this.baseTextBox.Text = this.Text;
			this.baseTextBox.ReadOnly = true;
			this.baseTextBox.Size = this.GetPreferredSize(Size.Empty);
			this.baseTextBox.Multiline = true;
			this.baseTextBox.DoubleClick += this.BaseTextBoxOnDoubleClick;
			this.baseTextBox.Click += this.BaseTextBoxOnClick;
			base.Controls.Add(this.baseTextBox);
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00005E81 File Offset: 0x00004081
		private void parentForm_ResizeEnd(object sender, EventArgs e)
		{
			if (this.LabelMode == MetroLabelMode.Selectable)
			{
				this.ShowBaseTextBox();
			}
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00005E92 File Offset: 0x00004092
		private void parentForm_ResizeBegin(object sender, EventArgs e)
		{
			if (this.LabelMode == MetroLabelMode.Selectable)
			{
				this.HideBaseTextBox();
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00005EA4 File Offset: 0x000040A4
		private void DestroyBaseTextbox()
		{
			if (!this.baseTextBox.Visible)
			{
				return;
			}
			this.baseTextBox.DoubleClick -= this.BaseTextBoxOnDoubleClick;
			this.baseTextBox.Click -= this.BaseTextBoxOnClick;
			this.baseTextBox.Visible = false;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00005EFC File Offset: 0x000040FC
		private void UpdateBaseTextBox()
		{
			if (!this.baseTextBox.Visible)
			{
				return;
			}
			base.SuspendLayout();
			this.baseTextBox.SuspendLayout();
			if (this.useCustomBackground)
			{
				this.baseTextBox.BackColor = this.BackColor;
			}
			else
			{
				this.baseTextBox.BackColor = MetroPaint.BackColor.Form(base.Theme);
			}
			if (!base.Enabled)
			{
				if (base.Parent != null)
				{
					if (base.Parent is MetroTile)
					{
						this.baseTextBox.ForeColor = MetroPaint.ForeColor.Tile.Disabled(base.Theme);
					}
					else if (this.useStyleColors)
					{
						this.baseTextBox.ForeColor = MetroPaint.GetStyleColor(base.Style);
					}
					else
					{
						this.baseTextBox.ForeColor = MetroPaint.ForeColor.Label.Disabled(base.Theme);
					}
				}
				else if (this.useStyleColors)
				{
					this.baseTextBox.ForeColor = MetroPaint.GetStyleColor(base.Style);
				}
				else
				{
					this.baseTextBox.ForeColor = MetroPaint.ForeColor.Label.Disabled(base.Theme);
				}
			}
			else if (base.Parent != null)
			{
				if (base.Parent is MetroTile)
				{
					this.baseTextBox.ForeColor = MetroPaint.ForeColor.Tile.Normal(base.Theme);
				}
				else if (this.useStyleColors)
				{
					this.baseTextBox.ForeColor = MetroPaint.GetStyleColor(base.Style);
				}
				else
				{
					this.baseTextBox.ForeColor = MetroPaint.ForeColor.Label.Normal(base.Theme);
				}
			}
			else if (this.useStyleColors)
			{
				this.baseTextBox.ForeColor = MetroPaint.GetStyleColor(base.Style);
			}
			else
			{
				this.baseTextBox.ForeColor = MetroPaint.ForeColor.Label.Normal(base.Theme);
			}
			this.baseTextBox.Font = MetroFonts.Label(this.metroLabelSize, this.metroLabelWeight);
			this.baseTextBox.Text = this.Text;
			this.baseTextBox.BorderStyle = BorderStyle.None;
			base.Size = this.GetPreferredSize(Size.Empty);
			this.baseTextBox.ResumeLayout();
			base.ResumeLayout();
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00006106 File Offset: 0x00004306
		private void HideBaseTextBox()
		{
			this.baseTextBox.Visible = false;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00006114 File Offset: 0x00004314
		private void ShowBaseTextBox()
		{
			this.baseTextBox.Visible = true;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00006122 File Offset: 0x00004322
		[SecuritySafeCritical]
		private void BaseTextBoxOnClick(object sender, EventArgs eventArgs)
		{
			WinCaret.HideCaret(this.baseTextBox.Handle);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00006135 File Offset: 0x00004335
		[SecuritySafeCritical]
		private void BaseTextBoxOnDoubleClick(object sender, EventArgs eventArgs)
		{
			this.baseTextBox.SelectAll();
			WinCaret.HideCaret(this.baseTextBox.Handle);
		}

		// Token: 0x04000058 RID: 88
		private MetroLabel.DoubleBufferedTextBox baseTextBox;

		// Token: 0x04000059 RID: 89
		private bool useStyleColors;

		// Token: 0x0400005A RID: 90
		private MetroLabelSize metroLabelSize = MetroLabelSize.Medium;

		// Token: 0x0400005B RID: 91
		private MetroLabelWeight metroLabelWeight;

		// Token: 0x0400005C RID: 92
		private MetroLabelMode labelMode;

		// Token: 0x0400005D RID: 93
		private bool useCustomBackground;

		// Token: 0x0400005E RID: 94
		private bool useCustomForeColor;

		// Token: 0x0400005F RID: 95
		private bool firstInitialization = true;

		// Token: 0x0200002B RID: 43
		private class DoubleBufferedTextBox : TextBox
		{
			// Token: 0x0600019F RID: 415 RVA: 0x00006153 File Offset: 0x00004353
			public DoubleBufferedTextBox()
			{
				base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			}
		}
	}
}
