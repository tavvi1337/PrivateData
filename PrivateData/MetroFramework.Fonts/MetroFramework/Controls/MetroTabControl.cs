using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;
using MetroFramework.Drawing;
using MetroFramework.Native;

namespace MetroFramework.Controls
{
	// Token: 0x02000034 RID: 52
	[ToolboxBitmap(typeof(TabControl))]
	[Designer("MetroFramework.Design.MetroTabControlDesigner, MetroFramework.Design, Version=1.2.0.3, Culture=neutral, PublicKeyToken=5f91a84759bf584a")]
	public class MetroTabControl : MetroTabControlBase
	{
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600025C RID: 604 RVA: 0x00008A86 File Offset: 0x00006C86
		// (set) Token: 0x0600025D RID: 605 RVA: 0x00008A8E File Offset: 0x00006C8E
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

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600025E RID: 606 RVA: 0x00008A97 File Offset: 0x00006C97
		// (set) Token: 0x0600025F RID: 607 RVA: 0x00008A9F File Offset: 0x00006C9F
		[Category("Metro Appearance")]
		[DefaultValue(MetroTabControlSize.Medium)]
		public MetroTabControlSize FontSize
		{
			get
			{
				return this.metroLabelSize;
			}
			set
			{
				this.metroLabelSize = value;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000260 RID: 608 RVA: 0x00008AA8 File Offset: 0x00006CA8
		// (set) Token: 0x06000261 RID: 609 RVA: 0x00008AB0 File Offset: 0x00006CB0
		[Category("Metro Appearance")]
		[DefaultValue(MetroTabControlWeight.Light)]
		public MetroTabControlWeight FontWeight
		{
			get
			{
				return this.metroLabelWeight;
			}
			set
			{
				this.metroLabelWeight = value;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000262 RID: 610 RVA: 0x00008AB9 File Offset: 0x00006CB9
		// (set) Token: 0x06000263 RID: 611 RVA: 0x00008AC1 File Offset: 0x00006CC1
		[DefaultValue(ContentAlignment.MiddleLeft)]
		[Category("Metro Appearance")]
		public ContentAlignment TextAlign
		{
			get
			{
				return this.textAlign;
			}
			set
			{
				this.textAlign = value;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000264 RID: 612 RVA: 0x00008ACA File Offset: 0x00006CCA
		[Editor("MetroFramework.Design.MetroTabPageCollectionEditor, MetroFramework.Design, Version=1.2.0.3, Culture=neutral, PublicKeyToken=5f91a84759bf584a", typeof(UITypeEditor))]
		public new TabControl.TabPageCollection TabPages
		{
			get
			{
				return base.TabPages;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00008AD2 File Offset: 0x00006CD2
		// (set) Token: 0x06000266 RID: 614 RVA: 0x00008ADA File Offset: 0x00006CDA
		[DefaultValue(false)]
		[Category("Metro Appearance")]
		public new bool IsMirrored
		{
			get
			{
				return this.isMirrored;
			}
			set
			{
				if (this.isMirrored == value)
				{
					return;
				}
				this.isMirrored = value;
				base.UpdateStyles();
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000267 RID: 615 RVA: 0x00008AF3 File Offset: 0x00006CF3
		// (set) Token: 0x06000268 RID: 616 RVA: 0x00008AFB File Offset: 0x00006CFB
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

		// Token: 0x06000269 RID: 617 RVA: 0x00008B04 File Offset: 0x00006D04
		public MetroTabControl()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
			base.Padding = new Point(6, 8);
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00008B34 File Offset: 0x00006D34
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Color color = this.useCustomBackground ? this.BackColor : MetroPaint.BackColor.Form(base.Theme);
			e.Graphics.Clear(color);
			for (int i = 0; i < this.TabPages.Count; i++)
			{
				if (i != base.SelectedIndex)
				{
					this.DrawTab(i, e.Graphics);
				}
			}
			if (base.SelectedIndex <= -1)
			{
				return;
			}
			this.DrawTabBottomBorder(base.SelectedIndex, e.Graphics);
			this.DrawTab(base.SelectedIndex, e.Graphics);
			this.DrawTabSelected(base.SelectedIndex, e.Graphics);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00008BDC File Offset: 0x00006DDC
		private void DrawTabBottomBorder(int index, Graphics graphics)
		{
			using (Brush brush = new SolidBrush(MetroPaint.BorderColor.TabControl.Normal(base.Theme)))
			{
				Rectangle rect = new Rectangle(this.DisplayRectangle.X, this.GetTabRect(index).Bottom + 2 - 3, this.DisplayRectangle.Width, 3);
				graphics.FillRectangle(brush, rect);
			}
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00008C58 File Offset: 0x00006E58
		private void DrawTabSelected(int index, Graphics graphics)
		{
			using (Brush brush = new SolidBrush(MetroPaint.GetStyleColor(base.Style)))
			{
				Rectangle tabRect = this.GetTabRect(index);
				graphics.FillRectangle(brush, new Rectangle
				{
					X = -2 + tabRect.X + this.DisplayRectangle.X,
					Y = tabRect.Bottom + 2 - 3,
					Width = tabRect.Width + 2,
					Height = 3
				});
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00008CF4 File Offset: 0x00006EF4
		private Size MeasureText(string text)
		{
			Size result;
			using (Graphics graphics = base.CreateGraphics())
			{
				Size proposedSize = new Size(int.MaxValue, int.MaxValue);
				result = TextRenderer.MeasureText(graphics, text, MetroFonts.TabControl(this.metroLabelSize, this.metroLabelWeight), proposedSize, MetroPaint.GetTextFormatFlags(this.TextAlign) | TextFormatFlags.NoPadding);
			}
			return result;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00008D64 File Offset: 0x00006F64
		private void DrawTab(int index, Graphics graphics)
		{
			Color color = (base.Parent != null) ? base.Parent.BackColor : MetroPaint.BackColor.Form(base.Theme);
			TabPage tabPage = this.TabPages[index];
			Rectangle tabRect = this.GetTabRect(index);
			Color foreColor;
			if (!base.Enabled)
			{
				foreColor = MetroPaint.ForeColor.Label.Disabled(base.Theme);
			}
			else
			{
				foreColor = ((!this.useStyleColors) ? MetroPaint.ForeColor.TabControl.Normal(base.Theme) : MetroPaint.GetStyleColor(base.Style));
			}
			if (index == 0)
			{
				tabRect.X = this.DisplayRectangle.X;
			}
			Rectangle rect = tabRect;
			tabRect.Width += 20;
			using (Brush brush = new SolidBrush(color))
			{
				graphics.FillRectangle(brush, rect);
			}
			TextRenderer.DrawText(graphics, tabPage.Text, MetroFonts.TabControl(this.metroLabelSize, this.metroLabelWeight), tabRect, foreColor, color, MetroPaint.GetTextFormatFlags(this.TextAlign));
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00008E68 File Offset: 0x00007068
		[SecuritySafeCritical]
		private void DrawUpDown(Graphics graphics)
		{
			Color color = (base.Parent != null) ? base.Parent.BackColor : MetroPaint.BackColor.Form(base.Theme);
			RECT rect = default(RECT);
			WinApi.GetClientRect(this.scUpDown.Handle, ref rect);
			graphics.CompositingQuality = CompositingQuality.HighQuality;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.Clear(color);
			using (Brush brush = new SolidBrush(MetroPaint.BorderColor.TabControl.Normal(base.Theme)))
			{
				GraphicsPath graphicsPath = new GraphicsPath(FillMode.Winding);
				PointF[] points = new PointF[]
				{
					new PointF(6f, 6f),
					new PointF(16f, 0f),
					new PointF(16f, 12f)
				};
				graphicsPath.AddLines(points);
				graphics.FillPath(brush, graphicsPath);
				graphicsPath.Reset();
				PointF[] points2 = new PointF[]
				{
					new PointF((float)(rect.Width - 15), 0f),
					new PointF((float)(rect.Width - 5), 6f),
					new PointF((float)(rect.Width - 15), 12f)
				};
				graphicsPath.AddLines(points2);
				graphics.FillPath(brush, graphicsPath);
				graphicsPath.Dispose();
			}
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00009004 File Offset: 0x00007204
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			base.Invalidate();
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00009013 File Offset: 0x00007213
		protected override void OnParentBackColorChanged(EventArgs e)
		{
			base.OnParentBackColorChanged(e);
			base.Invalidate();
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00009022 File Offset: 0x00007222
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Invalidate();
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00009031 File Offset: 0x00007231
		[SecuritySafeCritical]
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (!base.DesignMode)
			{
				WinApi.ShowScrollBar(base.Handle, 3, 0);
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000274 RID: 628 RVA: 0x00009050 File Offset: 0x00007250
		protected override CreateParams CreateParams
		{
			[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
			get
			{
				CreateParams createParams = base.CreateParams;
				if (this.isMirrored)
				{
					createParams.ExStyle = (createParams.ExStyle | 4194304 | 1048576);
				}
				return createParams;
			}
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00009088 File Offset: 0x00007288
		private new Rectangle GetTabRect(int index)
		{
			if (index < 0)
			{
				return default(Rectangle);
			}
			return base.GetTabRect(index);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x000090AC File Offset: 0x000072AC
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			if (base.SelectedIndex != -1 && !this.TabPages[base.SelectedIndex].Focused)
			{
				bool flag = false;
				foreach (object obj in this.TabPages[base.SelectedIndex].Controls)
				{
					Control control = (Control)obj;
					if (control.Focused)
					{
						flag = true;
						return;
					}
				}
				if (!flag)
				{
					this.TabPages[base.SelectedIndex].Select();
					this.TabPages[base.SelectedIndex].Focus();
				}
			}
			base.OnMouseWheel(e);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000917C File Offset: 0x0000737C
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			this.FindUpDown();
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000918A File Offset: 0x0000738A
		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);
			this.FindUpDown();
			this.UpdateUpDown();
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000919F File Offset: 0x0000739F
		protected override void OnControlRemoved(ControlEventArgs e)
		{
			base.OnControlRemoved(e);
			this.FindUpDown();
			this.UpdateUpDown();
		}

		// Token: 0x0600027A RID: 634 RVA: 0x000091B4 File Offset: 0x000073B4
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			base.OnSelectedIndexChanged(e);
			this.UpdateUpDown();
			base.Invalidate();
		}

		// Token: 0x0600027B RID: 635 RVA: 0x000091CC File Offset: 0x000073CC
		[SecuritySafeCritical]
		private void FindUpDown()
		{
			bool flag = false;
			IntPtr window = WinApi.GetWindow(base.Handle, 5);
			while (window != IntPtr.Zero)
			{
				char[] array = new char[33];
				int className = WinApi.GetClassName(window, array, 32);
				string a = new string(array, 0, className);
				if (a == "msctls_updown32")
				{
					flag = true;
					if (!this.bUpDown)
					{
						this.scUpDown = new SubClass(window, true);
						this.scUpDown.SubClassedWndProc += this.scUpDown_SubClassedWndProc;
						this.bUpDown = true;
						break;
					}
					break;
				}
				else
				{
					window = WinApi.GetWindow(window, 2);
				}
			}
			if (!flag && this.bUpDown)
			{
				this.bUpDown = false;
			}
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00009274 File Offset: 0x00007474
		[SecuritySafeCritical]
		private void UpdateUpDown()
		{
			if (this.bUpDown && WinApi.IsWindowVisible(this.scUpDown.Handle))
			{
				RECT rect = default(RECT);
				WinApi.GetClientRect(this.scUpDown.Handle, ref rect);
				WinApi.InvalidateRect(this.scUpDown.Handle, ref rect, true);
			}
		}

		// Token: 0x0600027D RID: 637 RVA: 0x000092CC File Offset: 0x000074CC
		[SecuritySafeCritical]
		private int scUpDown_SubClassedWndProc(ref Message m)
		{
			int msg = m.Msg;
			if (msg == 15)
			{
				IntPtr windowDC = WinApi.GetWindowDC(this.scUpDown.Handle);
				Graphics graphics = Graphics.FromHdc(windowDC);
				this.DrawUpDown(graphics);
				graphics.Dispose();
				WinApi.ReleaseDC(this.scUpDown.Handle, windowDC);
				m.Result = IntPtr.Zero;
				RECT rect = default(RECT);
				WinApi.GetClientRect(this.scUpDown.Handle, ref rect);
				WinApi.ValidateRect(this.scUpDown.Handle, ref rect);
				return 1;
			}
			return 0;
		}

		// Token: 0x040000AA RID: 170
		private const int TabBottomBorderHeight = 3;

		// Token: 0x040000AB RID: 171
		private SubClass scUpDown;

		// Token: 0x040000AC RID: 172
		private bool bUpDown;

		// Token: 0x040000AD RID: 173
		private bool useStyleColors;

		// Token: 0x040000AE RID: 174
		private MetroTabControlSize metroLabelSize = MetroTabControlSize.Medium;

		// Token: 0x040000AF RID: 175
		private MetroTabControlWeight metroLabelWeight;

		// Token: 0x040000B0 RID: 176
		private ContentAlignment textAlign = ContentAlignment.MiddleLeft;

		// Token: 0x040000B1 RID: 177
		private bool isMirrored;

		// Token: 0x040000B2 RID: 178
		private bool useCustomBackground;
	}
}
