using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Drawing;

namespace MetroFramework.Controls
{
	// Token: 0x0200001C RID: 28
	[ToolboxBitmap(typeof(CheckBox))]
	public class MetroCheckBox : MetroCheckBoxBase
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x000046E0 File Offset: 0x000028E0
		// (set) Token: 0x060000DA RID: 218 RVA: 0x000046E8 File Offset: 0x000028E8
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
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000DB RID: 219 RVA: 0x000046F1 File Offset: 0x000028F1
		// (set) Token: 0x060000DC RID: 220 RVA: 0x000046F9 File Offset: 0x000028F9
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

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00004702 File Offset: 0x00002902
		// (set) Token: 0x060000DE RID: 222 RVA: 0x0000470A File Offset: 0x0000290A
		[DefaultValue(MetroLinkWeight.Regular)]
		[Category("Metro Appearance")]
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

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00004713 File Offset: 0x00002913
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x0000471B File Offset: 0x0000291B
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

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00004724 File Offset: 0x00002924
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x0000472C File Offset: 0x0000292C
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

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00004735 File Offset: 0x00002935
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x0000473D File Offset: 0x0000293D
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

		// Token: 0x060000E5 RID: 229 RVA: 0x00004746 File Offset: 0x00002946
		public MetroCheckBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00004764 File Offset: 0x00002964
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
			if (this.useCustomForeColor)
			{
				foreColor = this.ForeColor;
				if (this.isHovered && !this.isPressed && base.Enabled)
				{
					color2 = MetroPaint.BorderColor.CheckBox.Hover(base.Theme);
				}
				else if (this.isHovered && this.isPressed && base.Enabled)
				{
					color2 = MetroPaint.BorderColor.CheckBox.Press(base.Theme);
				}
				else if (!base.Enabled)
				{
					color2 = MetroPaint.BorderColor.CheckBox.Disabled(base.Theme);
				}
				else
				{
					color2 = MetroPaint.BorderColor.CheckBox.Normal(base.Theme);
				}
			}
			else if (this.isHovered && !this.isPressed && base.Enabled)
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
				Rectangle rect = new Rectangle(0, base.Height / 2 - 6, 12, 12);
				e.Graphics.DrawRectangle(pen, rect);
			}
			if (base.Checked)
			{
				Color color3 = (base.CheckState == CheckState.Indeterminate) ? color2 : MetroPaint.GetStyleColor(base.Style);
				using (SolidBrush solidBrush = new SolidBrush(color3))
				{
					Rectangle rect2 = new Rectangle(2, base.Height / 2 - 4, 9, 9);
					e.Graphics.FillRectangle(solidBrush, rect2);
				}
			}
			Rectangle bounds = new Rectangle(16, 0, base.Width - 16, base.Height);
			TextRenderer.DrawText(e.Graphics, this.Text, MetroFonts.Link(this.metroLinkSize, this.metroLinkWeight), bounds, foreColor, color, MetroPaint.GetTextFormatFlags(this.TextAlign));
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000049D8 File Offset: 0x00002BD8
		protected override void OnGotFocus(EventArgs e)
		{
			this.isFocused = true;
			base.Invalidate();
			base.OnGotFocus(e);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000049EE File Offset: 0x00002BEE
		protected override void OnLostFocus(EventArgs e)
		{
			this.isFocused = false;
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLostFocus(e);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00004A12 File Offset: 0x00002C12
		protected override void OnEnter(EventArgs e)
		{
			this.isFocused = true;
			base.Invalidate();
			base.OnEnter(e);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00004A28 File Offset: 0x00002C28
		protected override void OnLeave(EventArgs e)
		{
			this.isFocused = false;
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLeave(e);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00004A4C File Offset: 0x00002C4C
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

		// Token: 0x060000EC RID: 236 RVA: 0x00004A73 File Offset: 0x00002C73
		protected override void OnKeyUp(KeyEventArgs e)
		{
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnKeyUp(e);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00004A90 File Offset: 0x00002C90
		protected override void OnMouseEnter(EventArgs e)
		{
			this.isHovered = true;
			base.Invalidate();
			base.OnMouseEnter(e);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00004AA6 File Offset: 0x00002CA6
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.isPressed = true;
				base.Invalidate();
			}
			base.OnMouseDown(e);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00004AC9 File Offset: 0x00002CC9
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.isPressed = false;
			base.Invalidate();
			base.OnMouseUp(e);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00004ADF File Offset: 0x00002CDF
		protected override void OnMouseLeave(EventArgs e)
		{
			this.isHovered = false;
			base.Invalidate();
			base.OnMouseLeave(e);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00004AF5 File Offset: 0x00002CF5
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			base.Invalidate();
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00004B04 File Offset: 0x00002D04
		protected override void OnCheckedChanged(EventArgs e)
		{
			base.OnCheckedChanged(e);
			base.Invalidate();
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00004B14 File Offset: 0x00002D14
		public override Size GetPreferredSize(Size proposedSize)
		{
			base.GetPreferredSize(proposedSize);
			Size result;
			using (Graphics graphics = base.CreateGraphics())
			{
				proposedSize = new Size(int.MaxValue, int.MaxValue);
				result = TextRenderer.MeasureText(graphics, this.Text, MetroFonts.Link(this.metroLinkSize, this.metroLinkWeight), proposedSize, MetroPaint.GetTextFormatFlags(this.TextAlign));
				result.Width += 16;
			}
			return result;
		}

		// Token: 0x0400003C RID: 60
		private bool useStyleColors;

		// Token: 0x0400003D RID: 61
		private MetroLinkSize metroLinkSize;

		// Token: 0x0400003E RID: 62
		private MetroLinkWeight metroLinkWeight = MetroLinkWeight.Regular;

		// Token: 0x0400003F RID: 63
		private bool useCustomBackground;

		// Token: 0x04000040 RID: 64
		private bool useCustomForeColor;

		// Token: 0x04000041 RID: 65
		private bool isHovered;

		// Token: 0x04000042 RID: 66
		private bool isPressed;

		// Token: 0x04000043 RID: 67
		private bool isFocused;
	}
}
