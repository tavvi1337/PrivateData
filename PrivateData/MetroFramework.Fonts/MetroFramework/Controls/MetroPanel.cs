using System;
using System.ComponentModel;
using System.Drawing;
using System.Security;
using System.Windows.Forms;
using MetroFramework.Drawing;
using MetroFramework.Native;

namespace MetroFramework.Controls
{
	// Token: 0x0200002D RID: 45
	[ToolboxBitmap(typeof(Panel))]
	public class MetroPanel : MetroPanelBase
	{
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00006416 File Offset: 0x00004616
		// (set) Token: 0x060001BA RID: 442 RVA: 0x0000641E File Offset: 0x0000461E
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

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00006427 File Offset: 0x00004627
		// (set) Token: 0x060001BC RID: 444 RVA: 0x00006434 File Offset: 0x00004634
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

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00006442 File Offset: 0x00004642
		// (set) Token: 0x060001BE RID: 446 RVA: 0x0000644F File Offset: 0x0000464F
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

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001BF RID: 447 RVA: 0x0000645D File Offset: 0x0000465D
		// (set) Token: 0x060001C0 RID: 448 RVA: 0x0000646A File Offset: 0x0000466A
		[Category("Metro Appearance")]
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

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00006478 File Offset: 0x00004678
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x00006480 File Offset: 0x00004680
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

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00006489 File Offset: 0x00004689
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x00006496 File Offset: 0x00004696
		[Category("Metro Appearance")]
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

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x000064A4 File Offset: 0x000046A4
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x000064B1 File Offset: 0x000046B1
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

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x000064BF File Offset: 0x000046BF
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x000064CC File Offset: 0x000046CC
		[Category("Metro Appearance")]
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

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x000064DA File Offset: 0x000046DA
		// (set) Token: 0x060001CA RID: 458 RVA: 0x000064E2 File Offset: 0x000046E2
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

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001CB RID: 459 RVA: 0x000064FC File Offset: 0x000046FC
		// (set) Token: 0x060001CC RID: 460 RVA: 0x00006504 File Offset: 0x00004704
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

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001CD RID: 461 RVA: 0x0000650D File Offset: 0x0000470D
		// (set) Token: 0x060001CE RID: 462 RVA: 0x00006515 File Offset: 0x00004715
		[Category("Metro Appearance")]
		[DefaultValue(MetroBorderStyle.None)]
		[Browsable(true)]
		public new MetroBorderStyle BorderStyle
		{
			get
			{
				return this._borderStyle;
			}
			set
			{
				this._borderStyle = value;
			}
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00006520 File Offset: 0x00004720
		public MetroPanel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
			base.BorderStyle = System.Windows.Forms.BorderStyle.None;
			base.Controls.Add(this.verticalScrollbar);
			base.Controls.Add(this.horizontalScrollbar);
			this.verticalScrollbar.UseBarColor = true;
			this.horizontalScrollbar.UseBarColor = true;
			this.verticalScrollbar.Scroll += this.VerticalScrollbarScroll;
			this.horizontalScrollbar.Scroll += this.HorizontalScrollbarScroll;
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x000065C6 File Offset: 0x000047C6
		private void HorizontalScrollbarScroll(object sender, ScrollEventArgs e)
		{
			base.AutoScrollPosition = new Point(e.NewValue, this.verticalScrollbar.Value);
			this.UpdateScrollBarPositions();
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x000065EA File Offset: 0x000047EA
		private void VerticalScrollbarScroll(object sender, ScrollEventArgs e)
		{
			base.AutoScrollPosition = new Point(this.horizontalScrollbar.Value, e.NewValue);
			this.UpdateScrollBarPositions();
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000660E File Offset: 0x0000480E
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			base.Invalidate();
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00006620 File Offset: 0x00004820
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Color color = MetroPaint.BackColor.Form(base.Theme);
			if (this.useCustomBackground)
			{
				color = this.BackColor;
			}
			e.Graphics.Clear(color);
			if (this.BorderStyle != MetroBorderStyle.None)
			{
				Color color2 = MetroPaint.BorderColor.Form(base.Theme);
				using (Pen pen = new Pen(color2))
				{
					e.Graphics.DrawLines(pen, new Point[]
					{
						new Point(0, 0),
						new Point(0, base.Height - 1),
						new Point(base.Width - 1, base.Height - 1),
						new Point(base.Width - 1, 0),
						new Point(0, 0)
					});
				}
			}
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

		// Token: 0x060001D4 RID: 468 RVA: 0x00006854 File Offset: 0x00004A54
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			this.verticalScrollbar.Value = base.VerticalScroll.Value;
			this.horizontalScrollbar.Value = base.HorizontalScroll.Value;
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00006889 File Offset: 0x00004A89
		[SecuritySafeCritical]
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (!base.DesignMode)
			{
				WinApi.ShowScrollBar(base.Handle, 3, 0);
			}
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x000068A8 File Offset: 0x00004AA8
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
			int num = (this.BorderStyle != MetroBorderStyle.None) ? 1 : 0;
			if (this.VerticalScrollbar)
			{
				if (base.VerticalScroll.Visible)
				{
					this.verticalScrollbar.Location = new Point(base.ClientRectangle.Width - this.verticalScrollbar.Width - num, base.ClientRectangle.Y + num);
					this.verticalScrollbar.Height = base.ClientRectangle.Height - 2 * num;
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
					this.horizontalScrollbar.Location = new Point(base.ClientRectangle.X + num, base.ClientRectangle.Height - this.horizontalScrollbar.Height - num);
					this.horizontalScrollbar.Width = base.ClientRectangle.Width - 2 * num;
					return;
				}
			}
			else
			{
				this.horizontalScrollbar.Visible = false;
			}
		}

		// Token: 0x04000068 RID: 104
		private MetroScrollBar verticalScrollbar = new MetroScrollBar(MetroScrollOrientation.Vertical);

		// Token: 0x04000069 RID: 105
		private MetroScrollBar horizontalScrollbar = new MetroScrollBar(MetroScrollOrientation.Horizontal);

		// Token: 0x0400006A RID: 106
		private bool showHorizontalScrollbar;

		// Token: 0x0400006B RID: 107
		private bool showVerticalScrollbar;

		// Token: 0x0400006C RID: 108
		private bool useCustomBackground;

		// Token: 0x0400006D RID: 109
		private MetroBorderStyle _borderStyle;
	}
}
