using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using MetroFramework.Drawing;

namespace MetroFramework.Controls
{
	// Token: 0x02000038 RID: 56
	[Designer("MetroFramework.Design.MetroTileDesigner, MetroFramework.Design, Version=1.2.0.3, Culture=neutral, PublicKeyToken=5f91a84759bf584a")]
	[ToolboxBitmap(typeof(Button))]
	public class MetroTile : MetroButtonBase, IContainerControl
	{
		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x0000A026 File Offset: 0x00008226
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x0000A02E File Offset: 0x0000822E
		[DefaultValue(null)]
		[Browsable(false)]
		public Control ActiveControl
		{
			get
			{
				return this.activeControl;
			}
			set
			{
				this.activeControl = value;
			}
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000A037 File Offset: 0x00008237
		public bool ActivateControl(Control ctrl)
		{
			if (base.Controls.Contains(ctrl))
			{
				ctrl.Select();
				this.activeControl = ctrl;
				return true;
			}
			return false;
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x0000A057 File Offset: 0x00008257
		// (set) Token: 0x060002E4 RID: 740 RVA: 0x0000A05F File Offset: 0x0000825F
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

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x0000A068 File Offset: 0x00008268
		// (set) Token: 0x060002E6 RID: 742 RVA: 0x0000A070 File Offset: 0x00008270
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

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x0000A079 File Offset: 0x00008279
		// (set) Token: 0x060002E8 RID: 744 RVA: 0x0000A081 File Offset: 0x00008281
		[Category("Metro Appearance")]
		[DefaultValue(true)]
		public bool PaintTileCount
		{
			get
			{
				return this.paintTileCount;
			}
			set
			{
				this.paintTileCount = value;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x0000A08A File Offset: 0x0000828A
		// (set) Token: 0x060002EA RID: 746 RVA: 0x0000A092 File Offset: 0x00008292
		[DefaultValue(0)]
		public int TileCount
		{
			get
			{
				return this.tileCount;
			}
			set
			{
				this.tileCount = value;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060002EB RID: 747 RVA: 0x0000A09B File Offset: 0x0000829B
		// (set) Token: 0x060002EC RID: 748 RVA: 0x0000A0A3 File Offset: 0x000082A3
		[DefaultValue(ContentAlignment.BottomLeft)]
		public new ContentAlignment TextAlign
		{
			get
			{
				return base.TextAlign;
			}
			set
			{
				base.TextAlign = value;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060002ED RID: 749 RVA: 0x0000A0AC File Offset: 0x000082AC
		// (set) Token: 0x060002EE RID: 750 RVA: 0x0000A0B4 File Offset: 0x000082B4
		[Category("Metro Appearance")]
		[DefaultValue(null)]
		public Image TileImage
		{
			get
			{
				return this.tileImage;
			}
			set
			{
				this.tileImage = value;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060002EF RID: 751 RVA: 0x0000A0BD File Offset: 0x000082BD
		// (set) Token: 0x060002F0 RID: 752 RVA: 0x0000A0C5 File Offset: 0x000082C5
		[Category("Metro Appearance")]
		[DefaultValue(false)]
		public bool UseTileImage
		{
			get
			{
				return this.useTileImage;
			}
			set
			{
				this.useTileImage = value;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060002F1 RID: 753 RVA: 0x0000A0CE File Offset: 0x000082CE
		// (set) Token: 0x060002F2 RID: 754 RVA: 0x0000A0D6 File Offset: 0x000082D6
		[DefaultValue(ContentAlignment.TopLeft)]
		[Category("Metro Appearance")]
		public ContentAlignment TileImageAlign
		{
			get
			{
				return this.tileImageAlign;
			}
			set
			{
				this.tileImageAlign = value;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x0000A0DF File Offset: 0x000082DF
		// (set) Token: 0x060002F4 RID: 756 RVA: 0x0000A0E7 File Offset: 0x000082E7
		[DefaultValue(MetroTileTextSize.Medium)]
		[Category("Metro Appearance")]
		public MetroTileTextSize TileTextFontSize
		{
			get
			{
				return this.tileTextFontSize;
			}
			set
			{
				this.tileTextFontSize = value;
				this.Refresh();
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x0000A0F6 File Offset: 0x000082F6
		// (set) Token: 0x060002F6 RID: 758 RVA: 0x0000A0FE File Offset: 0x000082FE
		[Category("Metro Appearance")]
		[DefaultValue(MetroTileTextWeight.Light)]
		public MetroTileTextWeight TileTextFontWeight
		{
			get
			{
				return this.tileTextFontWeight;
			}
			set
			{
				this.tileTextFontWeight = value;
				this.Refresh();
			}
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0000A10D File Offset: 0x0000830D
		public MetroTile()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.TextAlign = ContentAlignment.BottomLeft;
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0000A144 File Offset: 0x00008344
		protected override void OnPaint(PaintEventArgs e)
		{
			Color color = MetroPaint.GetStyleColor(base.Style);
			if (this.useCustomBackground)
			{
				color = this.BackColor;
			}
			Color foreColor;
			if (this.isHovered && !this.isPressed && base.Enabled)
			{
				foreColor = MetroPaint.ForeColor.Tile.Hover(base.Theme);
			}
			else if (this.isHovered && this.isPressed && base.Enabled)
			{
				foreColor = MetroPaint.ForeColor.Tile.Press(base.Theme);
			}
			else if (!base.Enabled)
			{
				foreColor = MetroPaint.ForeColor.Tile.Disabled(base.Theme);
			}
			else
			{
				foreColor = MetroPaint.ForeColor.Tile.Normal(base.Theme);
			}
			if (this.useCustomForeColor)
			{
				foreColor = this.ForeColor;
			}
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
			if (!this.isPressed)
			{
				e.Graphics.Clear(color);
			}
			else
			{
				e.Graphics.Clear(MetroPaint.BackColor.Form(base.Theme));
				using (SolidBrush solidBrush = new SolidBrush(color))
				{
					Point[] points = new Point[]
					{
						new Point(0, 0),
						new Point(base.Width - 1, 2),
						new Point(base.Width - 1, base.Height - 2),
						new Point(0, base.Height)
					};
					e.Graphics.FillPolygon(solidBrush, points);
				}
			}
			if (this.useTileImage && this.tileImage != null)
			{
				ContentAlignment contentAlignment = this.tileImageAlign;
				Rectangle rect;
				if (contentAlignment <= ContentAlignment.MiddleCenter)
				{
					switch (contentAlignment)
					{
					case ContentAlignment.TopLeft:
						rect = new Rectangle(new Point(0, 0), new Size(this.TileImage.Width, this.TileImage.Height));
						goto IL_4A7;
					case ContentAlignment.TopCenter:
						rect = new Rectangle(new Point(base.Width / 2 - this.TileImage.Width / 2, 0), new Size(this.TileImage.Width, this.TileImage.Height));
						goto IL_4A7;
					case (ContentAlignment)3:
						break;
					case ContentAlignment.TopRight:
						rect = new Rectangle(new Point(base.Width - this.TileImage.Width, 0), new Size(this.TileImage.Width, this.TileImage.Height));
						goto IL_4A7;
					default:
						if (contentAlignment == ContentAlignment.MiddleLeft)
						{
							rect = new Rectangle(new Point(0, base.Height / 2 - this.TileImage.Height / 2), new Size(this.TileImage.Width, this.TileImage.Height));
							goto IL_4A7;
						}
						if (contentAlignment == ContentAlignment.MiddleCenter)
						{
							rect = new Rectangle(new Point(base.Width / 2 - this.TileImage.Width / 2, base.Height / 2 - this.TileImage.Height / 2), new Size(this.TileImage.Width, this.TileImage.Height));
							goto IL_4A7;
						}
						break;
					}
				}
				else if (contentAlignment <= ContentAlignment.BottomLeft)
				{
					if (contentAlignment == ContentAlignment.MiddleRight)
					{
						rect = new Rectangle(new Point(base.Width - this.TileImage.Width, base.Height / 2 - this.TileImage.Height / 2), new Size(this.TileImage.Width, this.TileImage.Height));
						goto IL_4A7;
					}
					if (contentAlignment == ContentAlignment.BottomLeft)
					{
						rect = new Rectangle(new Point(0, base.Height - this.TileImage.Height), new Size(this.TileImage.Width, this.TileImage.Height));
						goto IL_4A7;
					}
				}
				else
				{
					if (contentAlignment == ContentAlignment.BottomCenter)
					{
						rect = new Rectangle(new Point(base.Width / 2 - this.TileImage.Width / 2, base.Height - this.TileImage.Height), new Size(this.TileImage.Width, this.TileImage.Height));
						goto IL_4A7;
					}
					if (contentAlignment == ContentAlignment.BottomRight)
					{
						rect = new Rectangle(new Point(base.Width - this.TileImage.Width, base.Height - this.TileImage.Height), new Size(this.TileImage.Width, this.TileImage.Height));
						goto IL_4A7;
					}
				}
				rect = new Rectangle(new Point(0, 0), new Size(this.TileImage.Width, this.TileImage.Height));
				IL_4A7:
				e.Graphics.DrawImage(this.TileImage, rect);
			}
			if (this.TileCount > 0 && this.paintTileCount)
			{
				Size size = TextRenderer.MeasureText(this.TileCount.ToString(), MetroFonts.TileCount);
				e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
				TextRenderer.DrawText(e.Graphics, this.TileCount.ToString(), MetroFonts.TileCount, new Point(base.Width - size.Width, 0), foreColor);
				e.Graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
			}
			TextRenderer.MeasureText(this.Text, MetroFonts.Tile(this.tileTextFontSize, this.tileTextFontWeight));
			TextFormatFlags textFormatFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.LeftAndRightPadding;
			Rectangle clientRectangle = base.ClientRectangle;
			ContentAlignment textAlign = this.TextAlign;
			if (textAlign <= ContentAlignment.MiddleCenter)
			{
				switch (textAlign)
				{
				case ContentAlignment.TopLeft:
					textFormatFlags = textFormatFlags;
					textFormatFlags = textFormatFlags;
					goto IL_634;
				case ContentAlignment.TopCenter:
					textFormatFlags = textFormatFlags;
					textFormatFlags |= TextFormatFlags.HorizontalCenter;
					goto IL_634;
				case (ContentAlignment)3:
					break;
				case ContentAlignment.TopRight:
					textFormatFlags = textFormatFlags;
					textFormatFlags |= TextFormatFlags.Right;
					goto IL_634;
				default:
					if (textAlign == ContentAlignment.MiddleLeft)
					{
						textFormatFlags |= TextFormatFlags.VerticalCenter;
						textFormatFlags = textFormatFlags;
						goto IL_634;
					}
					if (textAlign == ContentAlignment.MiddleCenter)
					{
						textFormatFlags |= TextFormatFlags.VerticalCenter;
						textFormatFlags |= TextFormatFlags.HorizontalCenter;
						goto IL_634;
					}
					break;
				}
			}
			else if (textAlign <= ContentAlignment.BottomLeft)
			{
				if (textAlign == ContentAlignment.MiddleRight)
				{
					textFormatFlags |= TextFormatFlags.VerticalCenter;
					textFormatFlags |= TextFormatFlags.Right;
					goto IL_634;
				}
				if (textAlign != ContentAlignment.BottomLeft)
				{
				}
			}
			else
			{
				if (textAlign == ContentAlignment.BottomCenter)
				{
					textFormatFlags |= TextFormatFlags.Bottom;
					textFormatFlags |= TextFormatFlags.HorizontalCenter;
					goto IL_634;
				}
				if (textAlign == ContentAlignment.BottomRight)
				{
					textFormatFlags |= TextFormatFlags.Bottom;
					textFormatFlags |= TextFormatFlags.Right;
					goto IL_634;
				}
			}
			textFormatFlags |= TextFormatFlags.Bottom;
			textFormatFlags = textFormatFlags;
			IL_634:
			TextRenderer.DrawText(e.Graphics, this.Text, MetroFonts.Tile(this.tileTextFontSize, this.tileTextFontWeight), clientRectangle, foreColor, textFormatFlags);
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0000A7BC File Offset: 0x000089BC
		protected override void OnGotFocus(EventArgs e)
		{
			this.isFocused = true;
			base.Invalidate();
			base.OnGotFocus(e);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x0000A7D2 File Offset: 0x000089D2
		protected override void OnLostFocus(EventArgs e)
		{
			this.isFocused = false;
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLostFocus(e);
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0000A7F6 File Offset: 0x000089F6
		protected override void OnEnter(EventArgs e)
		{
			this.isFocused = true;
			base.Invalidate();
			base.OnEnter(e);
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0000A80C File Offset: 0x00008A0C
		protected override void OnLeave(EventArgs e)
		{
			this.isFocused = false;
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLeave(e);
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0000A830 File Offset: 0x00008A30
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

		// Token: 0x060002FE RID: 766 RVA: 0x0000A857 File Offset: 0x00008A57
		protected override void OnKeyUp(KeyEventArgs e)
		{
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnKeyUp(e);
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0000A874 File Offset: 0x00008A74
		protected override void OnMouseEnter(EventArgs e)
		{
			this.isHovered = true;
			base.Invalidate();
			base.OnMouseEnter(e);
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0000A88A File Offset: 0x00008A8A
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.isPressed = true;
				base.Invalidate();
			}
			base.OnMouseDown(e);
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0000A8AD File Offset: 0x00008AAD
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.isPressed = false;
			base.Invalidate();
			base.OnMouseUp(e);
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0000A8C3 File Offset: 0x00008AC3
		protected override void OnMouseLeave(EventArgs e)
		{
			this.isHovered = false;
			base.Invalidate();
			base.OnMouseLeave(e);
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000A8D9 File Offset: 0x00008AD9
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			base.Invalidate();
		}

		// Token: 0x040000C3 RID: 195
		private Control activeControl;

		// Token: 0x040000C4 RID: 196
		private bool useCustomBackground;

		// Token: 0x040000C5 RID: 197
		private bool useCustomForeColor;

		// Token: 0x040000C6 RID: 198
		private bool paintTileCount = true;

		// Token: 0x040000C7 RID: 199
		private int tileCount;

		// Token: 0x040000C8 RID: 200
		private Image tileImage;

		// Token: 0x040000C9 RID: 201
		private bool useTileImage;

		// Token: 0x040000CA RID: 202
		private ContentAlignment tileImageAlign = ContentAlignment.TopLeft;

		// Token: 0x040000CB RID: 203
		private MetroTileTextSize tileTextFontSize = MetroTileTextSize.Medium;

		// Token: 0x040000CC RID: 204
		private MetroTileTextWeight tileTextFontWeight;

		// Token: 0x040000CD RID: 205
		private bool isHovered;

		// Token: 0x040000CE RID: 206
		private bool isPressed;

		// Token: 0x040000CF RID: 207
		private bool isFocused;
	}
}
