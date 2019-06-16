using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Drawing;

namespace MetroFramework.Controls
{
	// Token: 0x0200002C RID: 44
	[ToolboxBitmap(typeof(LinkLabel))]
	[Designer("MetroFramework.Design.MetroLinkDesigner, MetroFramework.Design, Version=1.2.0.3, Culture=neutral, PublicKeyToken=5f91a84759bf584a")]
	[DefaultEvent("Click")]
	public class MetroLink : MetroButtonBase
	{
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x00006167 File Offset: 0x00004367
		// (set) Token: 0x060001A1 RID: 417 RVA: 0x0000616F File Offset: 0x0000436F
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

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00006178 File Offset: 0x00004378
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x00006180 File Offset: 0x00004380
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

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x00006189 File Offset: 0x00004389
		// (set) Token: 0x060001A5 RID: 421 RVA: 0x00006191 File Offset: 0x00004391
		[Category("Metro Appearance")]
		[DefaultValue(MetroLinkWeight.Bold)]
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

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x0000619A File Offset: 0x0000439A
		// (set) Token: 0x060001A7 RID: 423 RVA: 0x000061A2 File Offset: 0x000043A2
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

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x000061AB File Offset: 0x000043AB
		// (set) Token: 0x060001A9 RID: 425 RVA: 0x000061B3 File Offset: 0x000043B3
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

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001AA RID: 426 RVA: 0x000061BC File Offset: 0x000043BC
		// (set) Token: 0x060001AB RID: 427 RVA: 0x000061C4 File Offset: 0x000043C4
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

		// Token: 0x060001AC RID: 428 RVA: 0x000061CD File Offset: 0x000043CD
		public MetroLink()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060001AD RID: 429 RVA: 0x000061E8 File Offset: 0x000043E8
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
			if (this.useCustomForeColor)
			{
				foreColor = this.ForeColor;
			}
			else if (this.isHovered && !this.isPressed && base.Enabled)
			{
				foreColor = MetroPaint.ForeColor.Link.Hover(base.Theme);
			}
			else if (this.isHovered && this.isPressed && base.Enabled)
			{
				foreColor = MetroPaint.ForeColor.Link.Press(base.Theme);
			}
			else if (!base.Enabled)
			{
				foreColor = MetroPaint.ForeColor.Link.Disabled(base.Theme);
			}
			else
			{
				foreColor = ((!this.useStyleColors) ? MetroPaint.ForeColor.Link.Normal(base.Theme) : MetroPaint.GetStyleColor(base.Style));
			}
			e.Graphics.Clear(color);
			TextRenderer.DrawText(e.Graphics, this.Text, MetroFonts.Link(this.metroLinkSize, this.metroLinkWeight), base.ClientRectangle, foreColor, color, MetroPaint.GetTextFormatFlags(this.TextAlign));
		}

		// Token: 0x060001AE RID: 430 RVA: 0x000062EA File Offset: 0x000044EA
		protected override void OnGotFocus(EventArgs e)
		{
			this.isFocused = true;
			base.Invalidate();
			base.OnGotFocus(e);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00006300 File Offset: 0x00004500
		protected override void OnLostFocus(EventArgs e)
		{
			this.isFocused = false;
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLostFocus(e);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00006324 File Offset: 0x00004524
		protected override void OnEnter(EventArgs e)
		{
			this.isFocused = true;
			base.Invalidate();
			base.OnEnter(e);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0000633A File Offset: 0x0000453A
		protected override void OnLeave(EventArgs e)
		{
			this.isFocused = false;
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLeave(e);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0000635E File Offset: 0x0000455E
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

		// Token: 0x060001B3 RID: 435 RVA: 0x00006385 File Offset: 0x00004585
		protected override void OnKeyUp(KeyEventArgs e)
		{
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnKeyUp(e);
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x000063A2 File Offset: 0x000045A2
		protected override void OnMouseEnter(EventArgs e)
		{
			this.isHovered = true;
			base.Invalidate();
			base.OnMouseEnter(e);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x000063B8 File Offset: 0x000045B8
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.isPressed = true;
				base.Invalidate();
			}
			base.OnMouseDown(e);
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x000063DB File Offset: 0x000045DB
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.isPressed = false;
			base.Invalidate();
			base.OnMouseUp(e);
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x000063F1 File Offset: 0x000045F1
		protected override void OnMouseLeave(EventArgs e)
		{
			this.isHovered = false;
			base.Invalidate();
			base.OnMouseLeave(e);
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x00006407 File Offset: 0x00004607
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			base.Invalidate();
		}

		// Token: 0x04000060 RID: 96
		private bool useStyleColors;

		// Token: 0x04000061 RID: 97
		private MetroLinkSize metroLinkSize;

		// Token: 0x04000062 RID: 98
		private MetroLinkWeight metroLinkWeight = MetroLinkWeight.Bold;

		// Token: 0x04000063 RID: 99
		private bool useCustomBackground;

		// Token: 0x04000064 RID: 100
		private bool useCustomForeColor;

		// Token: 0x04000065 RID: 101
		private bool isHovered;

		// Token: 0x04000066 RID: 102
		private bool isPressed;

		// Token: 0x04000067 RID: 103
		private bool isFocused;
	}
}
