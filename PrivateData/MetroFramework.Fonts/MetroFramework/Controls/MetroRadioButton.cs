using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MetroFramework.Drawing;

namespace MetroFramework.Controls
{
	// Token: 0x02000030 RID: 48
	[ToolboxBitmap(typeof(RadioButton))]
	public class MetroRadioButton : MetroRadioButtonBase
	{
		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000205 RID: 517 RVA: 0x0000736C File Offset: 0x0000556C
		// (set) Token: 0x06000206 RID: 518 RVA: 0x00007374 File Offset: 0x00005574
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

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000207 RID: 519 RVA: 0x0000737D File Offset: 0x0000557D
		// (set) Token: 0x06000208 RID: 520 RVA: 0x00007385 File Offset: 0x00005585
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

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000209 RID: 521 RVA: 0x0000738E File Offset: 0x0000558E
		// (set) Token: 0x0600020A RID: 522 RVA: 0x00007396 File Offset: 0x00005596
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

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600020B RID: 523 RVA: 0x0000739F File Offset: 0x0000559F
		// (set) Token: 0x0600020C RID: 524 RVA: 0x000073A7 File Offset: 0x000055A7
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

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600020D RID: 525 RVA: 0x000073B0 File Offset: 0x000055B0
		// (set) Token: 0x0600020E RID: 526 RVA: 0x000073B8 File Offset: 0x000055B8
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

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600020F RID: 527 RVA: 0x000073C1 File Offset: 0x000055C1
		// (set) Token: 0x06000210 RID: 528 RVA: 0x000073C9 File Offset: 0x000055C9
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

		// Token: 0x06000211 RID: 529 RVA: 0x000073D2 File Offset: 0x000055D2
		public MetroRadioButton()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000212 RID: 530 RVA: 0x000073F0 File Offset: 0x000055F0
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
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			using (Pen pen = new Pen(color2))
			{
				Rectangle rect = new Rectangle(0, base.Height / 2 - 6, 12, 12);
				e.Graphics.DrawEllipse(pen, rect);
			}
			if (base.Checked)
			{
				Color styleColor = MetroPaint.GetStyleColor(base.Style);
				using (SolidBrush solidBrush = new SolidBrush(styleColor))
				{
					Rectangle rect2 = new Rectangle(3, base.Height / 2 - 3, 6, 6);
					e.Graphics.FillEllipse(solidBrush, rect2);
				}
			}
			e.Graphics.SmoothingMode = SmoothingMode.Default;
			Rectangle bounds = new Rectangle(16, 0, base.Width - 16, base.Height);
			TextRenderer.DrawText(e.Graphics, this.Text, MetroFonts.Link(this.metroLinkSize, this.metroLinkWeight), bounds, foreColor, color, MetroPaint.GetTextFormatFlags(this.TextAlign));
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00007670 File Offset: 0x00005870
		protected override void OnGotFocus(EventArgs e)
		{
			this.isFocused = true;
			base.Invalidate();
			base.OnGotFocus(e);
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00007686 File Offset: 0x00005886
		protected override void OnLostFocus(EventArgs e)
		{
			this.isFocused = false;
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLostFocus(e);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x000076AA File Offset: 0x000058AA
		protected override void OnEnter(EventArgs e)
		{
			this.isFocused = true;
			base.Invalidate();
			base.OnEnter(e);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x000076C0 File Offset: 0x000058C0
		protected override void OnLeave(EventArgs e)
		{
			this.isFocused = false;
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLeave(e);
		}

		// Token: 0x06000217 RID: 535 RVA: 0x000076E4 File Offset: 0x000058E4
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

		// Token: 0x06000218 RID: 536 RVA: 0x0000770B File Offset: 0x0000590B
		protected override void OnKeyUp(KeyEventArgs e)
		{
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnKeyUp(e);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00007728 File Offset: 0x00005928
		protected override void OnMouseEnter(EventArgs e)
		{
			this.isHovered = true;
			base.Invalidate();
			base.OnMouseEnter(e);
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000773E File Offset: 0x0000593E
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.isPressed = true;
				base.Invalidate();
			}
			base.OnMouseDown(e);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00007761 File Offset: 0x00005961
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.isPressed = false;
			base.Invalidate();
			base.OnMouseUp(e);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00007777 File Offset: 0x00005977
		protected override void OnMouseLeave(EventArgs e)
		{
			this.isHovered = false;
			base.Invalidate();
			base.OnMouseLeave(e);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000778D File Offset: 0x0000598D
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			base.Invalidate();
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000779C File Offset: 0x0000599C
		protected override void OnCheckedChanged(EventArgs e)
		{
			base.OnCheckedChanged(e);
			base.Invalidate();
		}

		// Token: 0x0600021F RID: 543 RVA: 0x000077AC File Offset: 0x000059AC
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

		// Token: 0x0400007F RID: 127
		private bool useStyleColors;

		// Token: 0x04000080 RID: 128
		private MetroLinkSize metroLinkSize;

		// Token: 0x04000081 RID: 129
		private MetroLinkWeight metroLinkWeight = MetroLinkWeight.Regular;

		// Token: 0x04000082 RID: 130
		private bool useCustomBackground;

		// Token: 0x04000083 RID: 131
		private bool useCustomForeColor;

		// Token: 0x04000084 RID: 132
		private bool isHovered;

		// Token: 0x04000085 RID: 133
		private bool isPressed;

		// Token: 0x04000086 RID: 134
		private bool isFocused;
	}
}
