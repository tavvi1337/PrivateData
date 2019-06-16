using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Drawing;
using MetroFramework.Localization;

namespace MetroFramework.Controls
{
	// Token: 0x02000039 RID: 57
	[ToolboxBitmap(typeof(CheckBox))]
	public class MetroToggle : MetroCheckBoxBase
	{
		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000304 RID: 772 RVA: 0x0000A8E8 File Offset: 0x00008AE8
		// (set) Token: 0x06000305 RID: 773 RVA: 0x0000A8F0 File Offset: 0x00008AF0
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
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000306 RID: 774 RVA: 0x0000A8F9 File Offset: 0x00008AF9
		// (set) Token: 0x06000307 RID: 775 RVA: 0x0000A901 File Offset: 0x00008B01
		[Category("Metro Appearance")]
		[DefaultValue(MetroLinkSize.Small)]
		public MetroLinkSize FontSize
		{
			get
			{
				return this.metroLinkSize;
			}
			set
			{
				this.metroLinkSize = value;
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000308 RID: 776 RVA: 0x0000A90A File Offset: 0x00008B0A
		// (set) Token: 0x06000309 RID: 777 RVA: 0x0000A912 File Offset: 0x00008B12
		[Category("Metro Appearance")]
		[DefaultValue(MetroLinkWeight.Regular)]
		public MetroLinkWeight FontWeight
		{
			get
			{
				return this.metroLinkWeight;
			}
			set
			{
				this.metroLinkWeight = value;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600030A RID: 778 RVA: 0x0000A91B File Offset: 0x00008B1B
		// (set) Token: 0x0600030B RID: 779 RVA: 0x0000A923 File Offset: 0x00008B23
		[DefaultValue(true)]
		[Category("Metro Appearance")]
		public bool DisplayStatus
		{
			get
			{
				return this.displayStatus;
			}
			set
			{
				this.displayStatus = value;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600030C RID: 780 RVA: 0x0000A92C File Offset: 0x00008B2C
		// (set) Token: 0x0600030D RID: 781 RVA: 0x0000A934 File Offset: 0x00008B34
		[Browsable(false)]
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600030E RID: 782 RVA: 0x0000A93D File Offset: 0x00008B3D
		// (set) Token: 0x0600030F RID: 783 RVA: 0x0000A945 File Offset: 0x00008B45
		[Browsable(false)]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000310 RID: 784 RVA: 0x0000A94E File Offset: 0x00008B4E
		[Browsable(false)]
		public override string Text
		{
			get
			{
				if (base.Checked)
				{
					return this.metroLocalize.translate("StatusOn");
				}
				return this.metroLocalize.translate("StatusOff");
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000311 RID: 785 RVA: 0x0000A979 File Offset: 0x00008B79
		// (set) Token: 0x06000312 RID: 786 RVA: 0x0000A981 File Offset: 0x00008B81
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

		// Token: 0x06000313 RID: 787 RVA: 0x0000A98A File Offset: 0x00008B8A
		public MetroToggle()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.Name = "MetroToggle";
			this.metroLocalize = new MetroLocalize(this);
		}

		// Token: 0x06000314 RID: 788 RVA: 0x0000A9C4 File Offset: 0x00008BC4
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
			}
			Color foreColor;
			Color color2;
			if (this.isHovered && !this.isPressed && base.Enabled)
			{
				foreColor = MetroPaint.ForeColor.CheckBox.Hover(base.Theme);
				color2 = MetroPaint.BorderColor.CheckBox.Hover(base.Theme);
			}
			else if (this.isHovered && this.isPressed && base.Enabled)
			{
				foreColor = MetroPaint.ForeColor.CheckBox.Press(base.Theme);
				color2 = MetroPaint.BorderColor.CheckBox.Press(base.Theme);
			}
			else if (!base.Enabled)
			{
				foreColor = MetroPaint.ForeColor.CheckBox.Disabled(base.Theme);
				color2 = MetroPaint.BorderColor.CheckBox.Disabled(base.Theme);
			}
			else
			{
				foreColor = ((!this.useStyleColors) ? MetroPaint.ForeColor.CheckBox.Normal(base.Theme) : MetroPaint.GetStyleColor(base.Style));
				color2 = MetroPaint.BorderColor.CheckBox.Normal(base.Theme);
			}
			e.Graphics.Clear(color);
			using (Pen pen = new Pen(color2))
			{
				Rectangle rect = new Rectangle(this.DisplayStatus ? 30 : 0, 0, base.ClientRectangle.Width - (this.DisplayStatus ? 31 : 1), base.ClientRectangle.Height - 1);
				e.Graphics.DrawRectangle(pen, rect);
			}
			Color color3 = base.Checked ? MetroPaint.GetStyleColor(base.Style) : MetroPaint.BorderColor.CheckBox.Normal(base.Theme);
			using (SolidBrush solidBrush = new SolidBrush(color3))
			{
				Rectangle rect2 = new Rectangle(this.DisplayStatus ? 32 : 2, 2, base.ClientRectangle.Width - (this.DisplayStatus ? 34 : 4), base.ClientRectangle.Height - 4);
				e.Graphics.FillRectangle(solidBrush, rect2);
			}
			using (SolidBrush solidBrush2 = new SolidBrush(color))
			{
				int x = base.Checked ? (base.Width - 11) : (this.DisplayStatus ? 30 : 0);
				Rectangle rect3 = new Rectangle(x, 0, 11, base.ClientRectangle.Height);
				e.Graphics.FillRectangle(solidBrush2, rect3);
			}
			using (SolidBrush solidBrush3 = new SolidBrush(MetroPaint.BorderColor.CheckBox.Hover(base.Theme)))
			{
				int x2 = base.Checked ? (base.Width - 10) : (this.DisplayStatus ? 30 : 0);
				Rectangle rect4 = new Rectangle(x2, 0, 10, base.ClientRectangle.Height);
				e.Graphics.FillRectangle(solidBrush3, rect4);
			}
			if (this.DisplayStatus)
			{
				Rectangle bounds = new Rectangle(0, 0, 30, base.ClientRectangle.Height);
				TextRenderer.DrawText(e.Graphics, this.Text, MetroFonts.Link(this.metroLinkSize, this.metroLinkWeight), bounds, foreColor, color, MetroPaint.GetTextFormatFlags(this.TextAlign));
			}
		}

		// Token: 0x06000315 RID: 789 RVA: 0x0000ACF4 File Offset: 0x00008EF4
		protected override void OnGotFocus(EventArgs e)
		{
			this.isFocused = true;
			base.Invalidate();
			base.OnGotFocus(e);
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0000AD0A File Offset: 0x00008F0A
		protected override void OnLostFocus(EventArgs e)
		{
			this.isFocused = false;
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLostFocus(e);
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0000AD2E File Offset: 0x00008F2E
		protected override void OnEnter(EventArgs e)
		{
			this.isFocused = true;
			base.Invalidate();
			base.OnEnter(e);
		}

		// Token: 0x06000318 RID: 792 RVA: 0x0000AD44 File Offset: 0x00008F44
		protected override void OnLeave(EventArgs e)
		{
			this.isFocused = false;
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLeave(e);
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0000AD68 File Offset: 0x00008F68
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				this.isHovered = true;
				this.isPressed = true;
				base.Invalidate();
			}
			base.OnKeyDown(e);
		}

		// Token: 0x0600031A RID: 794 RVA: 0x0000AD8F File Offset: 0x00008F8F
		protected override void OnKeyUp(KeyEventArgs e)
		{
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnKeyUp(e);
		}

		// Token: 0x0600031B RID: 795 RVA: 0x0000ADAC File Offset: 0x00008FAC
		protected override void OnMouseEnter(EventArgs e)
		{
			this.isHovered = true;
			base.Invalidate();
			base.OnMouseEnter(e);
		}

		// Token: 0x0600031C RID: 796 RVA: 0x0000ADC2 File Offset: 0x00008FC2
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.isPressed = true;
				base.Invalidate();
			}
			base.OnMouseDown(e);
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0000ADE5 File Offset: 0x00008FE5
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.isPressed = false;
			base.Invalidate();
			base.OnMouseUp(e);
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0000ADFB File Offset: 0x00008FFB
		protected override void OnMouseLeave(EventArgs e)
		{
			this.isHovered = false;
			base.Invalidate();
			base.OnMouseLeave(e);
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0000AE11 File Offset: 0x00009011
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			base.Invalidate();
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0000AE20 File Offset: 0x00009020
		protected override void OnCheckedChanged(EventArgs e)
		{
			base.OnCheckedChanged(e);
			base.Invalidate();
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0000AE30 File Offset: 0x00009030
		public override Size GetPreferredSize(Size proposedSize)
		{
			Size preferredSize = base.GetPreferredSize(proposedSize);
			preferredSize.Width = (this.DisplayStatus ? 80 : 50);
			return preferredSize;
		}

		// Token: 0x040000D0 RID: 208
		private MetroLocalize metroLocalize;

		// Token: 0x040000D1 RID: 209
		private bool useStyleColors;

		// Token: 0x040000D2 RID: 210
		private MetroLinkSize metroLinkSize;

		// Token: 0x040000D3 RID: 211
		private MetroLinkWeight metroLinkWeight = MetroLinkWeight.Regular;

		// Token: 0x040000D4 RID: 212
		private bool displayStatus = true;

		// Token: 0x040000D5 RID: 213
		private bool useCustomBackground;

		// Token: 0x040000D6 RID: 214
		private bool isHovered;

		// Token: 0x040000D7 RID: 215
		private bool isPressed;

		// Token: 0x040000D8 RID: 216
		private bool isFocused;
	}
}
