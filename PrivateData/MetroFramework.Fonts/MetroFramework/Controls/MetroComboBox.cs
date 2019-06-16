using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Drawing;

namespace MetroFramework.Controls
{
	// Token: 0x0200001E RID: 30
	[ToolboxBitmap(typeof(MetroPaint.BorderColor.ComboBox))]
	public class MetroComboBox : MetroComboBoxBase
	{
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00004C74 File Offset: 0x00002E74
		// (set) Token: 0x06000100 RID: 256 RVA: 0x00004C77 File Offset: 0x00002E77
		[Browsable(false)]
		[DefaultValue(DrawMode.OwnerDrawFixed)]
		public new DrawMode DrawMode
		{
			get
			{
				return DrawMode.OwnerDrawFixed;
			}
			set
			{
				base.DrawMode = DrawMode.OwnerDrawFixed;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00004C80 File Offset: 0x00002E80
		// (set) Token: 0x06000102 RID: 258 RVA: 0x00004C83 File Offset: 0x00002E83
		[Browsable(false)]
		[DefaultValue(ComboBoxStyle.DropDownList)]
		public new ComboBoxStyle DropDownStyle
		{
			get
			{
				return ComboBoxStyle.DropDownList;
			}
			set
			{
				base.DropDownStyle = ComboBoxStyle.DropDownList;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000103 RID: 259 RVA: 0x00004C8C File Offset: 0x00002E8C
		// (set) Token: 0x06000104 RID: 260 RVA: 0x00004C94 File Offset: 0x00002E94
		[DefaultValue(MetroLinkSize.Medium)]
		[Category("Metro Appearance")]
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

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00004C9D File Offset: 0x00002E9D
		// (set) Token: 0x06000106 RID: 262 RVA: 0x00004CA5 File Offset: 0x00002EA5
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

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00004CAE File Offset: 0x00002EAE
		[Browsable(false)]
		public override Color BackColor
		{
			get
			{
				return MetroPaint.BackColor.Form(base.Theme);
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00004CBB File Offset: 0x00002EBB
		// (set) Token: 0x06000109 RID: 265 RVA: 0x00004CC3 File Offset: 0x00002EC3
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

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600010A RID: 266 RVA: 0x00004CCC File Offset: 0x00002ECC
		// (set) Token: 0x0600010B RID: 267 RVA: 0x00004CD4 File Offset: 0x00002ED4
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

		// Token: 0x0600010C RID: 268 RVA: 0x00004CDD File Offset: 0x00002EDD
		public MetroComboBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.DrawMode = DrawMode.OwnerDrawFixed;
			base.DropDownStyle = ComboBoxStyle.DropDownList;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00004D10 File Offset: 0x00002F10
		protected override void OnPaint(PaintEventArgs e)
		{
			base.ItemHeight = this.GetPreferredSize(Size.Empty).Height;
			Color color;
			if (base.Parent != null)
			{
				color = base.Parent.BackColor;
			}
			else
			{
				color = MetroPaint.BackColor.Form(base.Theme);
			}
			Color color2;
			Color color3;
			if (this.isHovered && !this.isPressed && base.Enabled)
			{
				color2 = MetroPaint.ForeColor.ComboBox.Hover(base.Theme);
				color3 = MetroPaint.BorderColor.ComboBox.Hover(base.Theme);
			}
			else if (this.isHovered && this.isPressed && base.Enabled)
			{
				color2 = MetroPaint.ForeColor.ComboBox.Press(base.Theme);
				color3 = MetroPaint.BorderColor.ComboBox.Press(base.Theme);
			}
			else if (!base.Enabled)
			{
				color2 = MetroPaint.ForeColor.ComboBox.Disabled(base.Theme);
				color3 = MetroPaint.BorderColor.ComboBox.Disabled(base.Theme);
			}
			else
			{
				color2 = MetroPaint.ForeColor.ComboBox.Normal(base.Theme);
				color3 = MetroPaint.BorderColor.ComboBox.Normal(base.Theme);
			}
			e.Graphics.Clear(color);
			using (Pen pen = new Pen(color3))
			{
				Rectangle rect = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
				e.Graphics.DrawRectangle(pen, rect);
			}
			using (SolidBrush solidBrush = new SolidBrush(color2))
			{
				e.Graphics.FillPolygon(solidBrush, new Point[]
				{
					new Point(base.Width - 20, base.Height / 2 - 2),
					new Point(base.Width - 9, base.Height / 2 - 2),
					new Point(base.Width - 15, base.Height / 2 + 4)
				});
			}
			Rectangle bounds = new Rectangle(2, 2, base.Width - 20, base.Height - 4);
			TextRenderer.DrawText(e.Graphics, this.Text, MetroFonts.Link(this.metroLinkSize, this.metroLinkWeight), bounds, color2, color, TextFormatFlags.VerticalCenter);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00004F38 File Offset: 0x00003138
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			if (e.Index >= 0)
			{
				Color color;
				Color foreColor;
				if (e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect) || e.State == DrawItemState.None)
				{
					color = MetroPaint.BackColor.Form(base.Theme);
					foreColor = MetroPaint.ForeColor.Link.Normal(base.Theme);
				}
				else
				{
					color = MetroPaint.GetStyleColor(base.Style);
					foreColor = MetroPaint.ForeColor.Tile.Normal(base.Theme);
				}
				using (SolidBrush solidBrush = new SolidBrush(color))
				{
					e.Graphics.FillRectangle(solidBrush, new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height));
				}
				Rectangle bounds = new Rectangle(0, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height);
				TextRenderer.DrawText(e.Graphics, base.GetItemText(base.Items[e.Index]), MetroFonts.Link(this.metroLinkSize, this.metroLinkWeight), bounds, foreColor, color, TextFormatFlags.VerticalCenter);
				return;
			}
			base.OnDrawItem(e);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000507C File Offset: 0x0000327C
		protected override void OnGotFocus(EventArgs e)
		{
			this.isFocused = true;
			base.Invalidate();
			base.OnGotFocus(e);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00005092 File Offset: 0x00003292
		protected override void OnLostFocus(EventArgs e)
		{
			this.isFocused = false;
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLostFocus(e);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000050B6 File Offset: 0x000032B6
		protected override void OnEnter(EventArgs e)
		{
			this.isFocused = true;
			base.Invalidate();
			base.OnEnter(e);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000050CC File Offset: 0x000032CC
		protected override void OnLeave(EventArgs e)
		{
			this.isFocused = false;
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLeave(e);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000050F0 File Offset: 0x000032F0
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

		// Token: 0x06000114 RID: 276 RVA: 0x00005117 File Offset: 0x00003317
		protected override void OnKeyUp(KeyEventArgs e)
		{
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnKeyUp(e);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00005134 File Offset: 0x00003334
		protected override void OnMouseEnter(EventArgs e)
		{
			this.isHovered = true;
			base.Invalidate();
			base.OnMouseEnter(e);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000514A File Offset: 0x0000334A
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.isPressed = true;
				base.Invalidate();
			}
			base.OnMouseDown(e);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000516D File Offset: 0x0000336D
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.isPressed = false;
			base.Invalidate();
			base.OnMouseUp(e);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00005183 File Offset: 0x00003383
		protected override void OnMouseLeave(EventArgs e)
		{
			this.isHovered = false;
			base.Invalidate();
			base.OnMouseLeave(e);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000519C File Offset: 0x0000339C
		public override Size GetPreferredSize(Size proposedSize)
		{
			base.GetPreferredSize(proposedSize);
			Size result;
			using (Graphics graphics = base.CreateGraphics())
			{
				string text = (this.Text.Length > 0) ? this.Text : "MeasureText";
				proposedSize = new Size(int.MaxValue, int.MaxValue);
				result = TextRenderer.MeasureText(graphics, text, MetroFonts.Link(this.metroLinkSize, this.metroLinkWeight), proposedSize, TextFormatFlags.VerticalCenter | TextFormatFlags.LeftAndRightPadding);
				result.Height += 4;
			}
			return result;
		}

		// Token: 0x04000045 RID: 69
		private MetroLinkSize metroLinkSize = MetroLinkSize.Medium;

		// Token: 0x04000046 RID: 70
		private MetroLinkWeight metroLinkWeight = MetroLinkWeight.Regular;

		// Token: 0x04000047 RID: 71
		private bool isHovered;

		// Token: 0x04000048 RID: 72
		private bool isPressed;

		// Token: 0x04000049 RID: 73
		private bool isFocused;
	}
}
