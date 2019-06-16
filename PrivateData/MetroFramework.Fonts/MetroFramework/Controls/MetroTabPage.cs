using System;
using System.ComponentModel;
using System.Drawing;
using System.Security;
using System.Windows.Forms;
using MetroFramework.Drawing;
using MetroFramework.Native;

namespace MetroFramework.Controls
{
	// Token: 0x02000035 RID: 53
	[ToolboxItem(false)]
	[Designer("MetroFramework.Design.MetroTabPageDesigner, MetroFramework.Design, Version=1.2.0.3, Culture=neutral, PublicKeyToken=5f91a84759bf584a")]
	public class MetroTabPage : MetroTabPageBase
	{
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600027E RID: 638 RVA: 0x00009358 File Offset: 0x00007558
		// (set) Token: 0x0600027F RID: 639 RVA: 0x00009360 File Offset: 0x00007560
		[Category("Metro Appearance")]
		[DefaultValue(false)]
		public bool HorizontalScrollbar
		{
			get
			{
				return this.showHorizontalScrollbar;
			}
			set
			{
				this.showHorizontalScrollbar = value;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000280 RID: 640 RVA: 0x00009369 File Offset: 0x00007569
		// (set) Token: 0x06000281 RID: 641 RVA: 0x00009376 File Offset: 0x00007576
		[DefaultValue(10)]
		[Category("Metro Appearance")]
		public int HorizontalScrollbarSize
		{
			get
			{
				return this.horizontalScrollbar.ScrollbarSize;
			}
			set
			{
				this.horizontalScrollbar.ScrollbarSize = value;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000282 RID: 642 RVA: 0x00009384 File Offset: 0x00007584
		// (set) Token: 0x06000283 RID: 643 RVA: 0x00009391 File Offset: 0x00007591
		[DefaultValue(false)]
		[Category("Metro Appearance")]
		public bool HorizontalScrollbarBarColor
		{
			get
			{
				return this.horizontalScrollbar.UseBarColor;
			}
			set
			{
				this.horizontalScrollbar.UseBarColor = value;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000284 RID: 644 RVA: 0x0000939F File Offset: 0x0000759F
		// (set) Token: 0x06000285 RID: 645 RVA: 0x000093AC File Offset: 0x000075AC
		[Category("Metro Appearance")]
		[DefaultValue(false)]
		public bool HorizontalScrollbarHighlightOnWheel
		{
			get
			{
				return this.horizontalScrollbar.HighlightOnWheel;
			}
			set
			{
				this.horizontalScrollbar.HighlightOnWheel = value;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000286 RID: 646 RVA: 0x000093BA File Offset: 0x000075BA
		// (set) Token: 0x06000287 RID: 647 RVA: 0x000093C2 File Offset: 0x000075C2
		[Category("Metro Appearance")]
		[DefaultValue(false)]
		public bool VerticalScrollbar
		{
			get
			{
				return this.showVerticalScrollbar;
			}
			set
			{
				this.showVerticalScrollbar = value;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000288 RID: 648 RVA: 0x000093CB File Offset: 0x000075CB
		// (set) Token: 0x06000289 RID: 649 RVA: 0x000093D8 File Offset: 0x000075D8
		[Category("Metro Appearance")]
		[DefaultValue(10)]
		public int VerticalScrollbarSize
		{
			get
			{
				return this.verticalScrollbar.ScrollbarSize;
			}
			set
			{
				this.verticalScrollbar.ScrollbarSize = value;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600028A RID: 650 RVA: 0x000093E6 File Offset: 0x000075E6
		// (set) Token: 0x0600028B RID: 651 RVA: 0x000093F3 File Offset: 0x000075F3
		[DefaultValue(false)]
		[Category("Metro Appearance")]
		public bool VerticalScrollbarBarColor
		{
			get
			{
				return this.verticalScrollbar.UseBarColor;
			}
			set
			{
				this.verticalScrollbar.UseBarColor = value;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600028C RID: 652 RVA: 0x00009401 File Offset: 0x00007601
		// (set) Token: 0x0600028D RID: 653 RVA: 0x0000940E File Offset: 0x0000760E
		[Category("Metro Appearance")]
		[DefaultValue(false)]
		public bool VerticalScrollbarHighlightOnWheel
		{
			get
			{
				return this.verticalScrollbar.HighlightOnWheel;
			}
			set
			{
				this.verticalScrollbar.HighlightOnWheel = value;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600028E RID: 654 RVA: 0x0000941C File Offset: 0x0000761C
		// (set) Token: 0x0600028F RID: 655 RVA: 0x00009424 File Offset: 0x00007624
		[Category("Metro Appearance")]
		public new bool AutoScroll
		{
			get
			{
				return base.AutoScroll;
			}
			set
			{
				if (value)
				{
					this.showHorizontalScrollbar = true;
					this.showVerticalScrollbar = true;
				}
				base.AutoScroll = value;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000290 RID: 656 RVA: 0x0000943E File Offset: 0x0000763E
		// (set) Token: 0x06000291 RID: 657 RVA: 0x00009446 File Offset: 0x00007646
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

		// Token: 0x06000292 RID: 658 RVA: 0x00009450 File Offset: 0x00007650
		public MetroTabPage()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.Controls.Add(this.verticalScrollbar);
			base.Controls.Add(this.horizontalScrollbar);
			this.verticalScrollbar.UseBarColor = true;
			this.horizontalScrollbar.UseBarColor = true;
			this.verticalScrollbar.Scroll += this.VerticalScrollbarScroll;
			this.horizontalScrollbar.Scroll += this.HorizontalScrollbarScroll;
		}

		// Token: 0x06000293 RID: 659 RVA: 0x000094EF File Offset: 0x000076EF
		private void HorizontalScrollbarScroll(object sender, ScrollEventArgs e)
		{
			base.AutoScrollPosition = new Point(e.NewValue, this.verticalScrollbar.Value);
			this.UpdateScrollBarPositions();
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00009513 File Offset: 0x00007713
		private void VerticalScrollbarScroll(object sender, ScrollEventArgs e)
		{
			base.AutoScrollPosition = new Point(this.horizontalScrollbar.Value, e.NewValue);
			this.UpdateScrollBarPositions();
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00009538 File Offset: 0x00007738
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Color color = MetroPaint.BackColor.Form(base.Theme);
			if (this.useCustomBackground)
			{
				color = this.BackColor;
			}
			e.Graphics.Clear(color);
			if (base.DesignMode)
			{
				this.horizontalScrollbar.Visible = false;
				this.verticalScrollbar.Visible = false;
				return;
			}
			this.UpdateScrollBarPositions();
			if (this.HorizontalScrollbar)
			{
				this.horizontalScrollbar.Visible = base.HorizontalScroll.Visible;
			}
			if (base.HorizontalScroll.Visible)
			{
				this.horizontalScrollbar.Minimum = base.HorizontalScroll.Minimum;
				this.horizontalScrollbar.Maximum = base.HorizontalScroll.Maximum;
				this.horizontalScrollbar.SmallChange = base.HorizontalScroll.SmallChange;
				this.horizontalScrollbar.LargeChange = base.HorizontalScroll.LargeChange;
			}
			if (this.VerticalScrollbar)
			{
				this.verticalScrollbar.Visible = base.VerticalScroll.Visible;
			}
			if (base.VerticalScroll.Visible)
			{
				this.verticalScrollbar.Minimum = base.VerticalScroll.Minimum;
				this.verticalScrollbar.Maximum = base.VerticalScroll.Maximum;
				this.verticalScrollbar.SmallChange = base.VerticalScroll.SmallChange;
				this.verticalScrollbar.LargeChange = base.VerticalScroll.LargeChange;
			}
		}

		// Token: 0x06000296 RID: 662 RVA: 0x000096A0 File Offset: 0x000078A0
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			this.verticalScrollbar.Value = base.VerticalScroll.Value;
			this.horizontalScrollbar.Value = base.HorizontalScroll.Value;
		}

		// Token: 0x06000297 RID: 663 RVA: 0x000096D5 File Offset: 0x000078D5
		[SecuritySafeCritical]
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (!base.DesignMode)
			{
				WinApi.ShowScrollBar(base.Handle, 3, 0);
			}
		}

		// Token: 0x06000298 RID: 664 RVA: 0x000096F4 File Offset: 0x000078F4
		private void UpdateScrollBarPositions()
		{
			if (base.DesignMode)
			{
				return;
			}
			if (!this.AutoScroll)
			{
				this.verticalScrollbar.Visible = false;
				this.horizontalScrollbar.Visible = false;
				return;
			}
			if (this.VerticalScrollbar)
			{
				if (base.VerticalScroll.Visible)
				{
					this.verticalScrollbar.Location = new Point(base.ClientRectangle.Width - this.verticalScrollbar.Width, base.ClientRectangle.Y);
					this.verticalScrollbar.Height = base.ClientRectangle.Height;
				}
			}
			else
			{
				this.verticalScrollbar.Visible = false;
			}
			if (this.HorizontalScrollbar)
			{
				if (base.HorizontalScroll.Visible)
				{
					this.horizontalScrollbar.Location = new Point(base.ClientRectangle.X, base.ClientRectangle.Height - this.horizontalScrollbar.Height);
					this.horizontalScrollbar.Width = base.ClientRectangle.Width;
					return;
				}
			}
			else
			{
				this.horizontalScrollbar.Visible = false;
			}
		}

		// Token: 0x040000B3 RID: 179
		private MetroScrollBar verticalScrollbar = new MetroScrollBar(MetroScrollOrientation.Vertical);

		// Token: 0x040000B4 RID: 180
		private MetroScrollBar horizontalScrollbar = new MetroScrollBar(MetroScrollOrientation.Horizontal);

		// Token: 0x040000B5 RID: 181
		private bool showHorizontalScrollbar;

		// Token: 0x040000B6 RID: 182
		private bool showVerticalScrollbar;

		// Token: 0x040000B7 RID: 183
		private bool useCustomBackground;
	}
}
