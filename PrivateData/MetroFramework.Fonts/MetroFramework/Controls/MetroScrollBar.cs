using System;
using System.ComponentModel;
using System.Drawing;
using System.Security;
using System.Windows.Forms;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;
using MetroFramework.Native;

namespace MetroFramework.Controls
{
	// Token: 0x02000032 RID: 50
	[DefaultProperty("Value")]
	[Designer("MetroFramework.Design.MetroScrollBarDesigner, MetroFramework.Design, Version=1.2.0.3, Culture=neutral, PublicKeyToken=5f91a84759bf584a")]
	[DefaultEvent("Scroll")]
	public class MetroScrollBar : MetroControlBase, IMetroControl, IMetroComponent, IDisposable
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000220 RID: 544 RVA: 0x00007830 File Offset: 0x00005A30
		// (remove) Token: 0x06000221 RID: 545 RVA: 0x00007868 File Offset: 0x00005A68
		public event ScrollEventHandler Scroll;

		// Token: 0x06000222 RID: 546 RVA: 0x000078A0 File Offset: 0x00005AA0
		private void OnScroll(ScrollEventType type, int oldValue, int newValue, ScrollOrientation orientation)
		{
			if (this.Scroll == null)
			{
				return;
			}
			if (orientation == ScrollOrientation.HorizontalScroll)
			{
				if (type != ScrollEventType.EndScroll && this.isFirstScrollEventHorizontal)
				{
					type = ScrollEventType.First;
				}
				else if (!this.isFirstScrollEventHorizontal && type == ScrollEventType.EndScroll)
				{
					this.isFirstScrollEventHorizontal = true;
				}
			}
			else if (type != ScrollEventType.EndScroll && this.isFirstScrollEventVertical)
			{
				type = ScrollEventType.First;
			}
			else if (!this.isFirstScrollEventHorizontal && type == ScrollEventType.EndScroll)
			{
				this.isFirstScrollEventVertical = true;
			}
			this.Scroll(this, new ScrollEventArgs(type, oldValue, newValue, orientation));
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000223 RID: 547 RVA: 0x0000791A File Offset: 0x00005B1A
		// (set) Token: 0x06000224 RID: 548 RVA: 0x00007922 File Offset: 0x00005B22
		[DefaultValue(10)]
		public int MouseWheelBarPartitions
		{
			get
			{
				return this.mouseWheelBarPartitions;
			}
			set
			{
				if (value > 0)
				{
					this.mouseWheelBarPartitions = value;
					return;
				}
				throw new ArgumentOutOfRangeException("value", "MouseWheelBarPartitions has to be greather than zero");
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000225 RID: 549 RVA: 0x0000793F File Offset: 0x00005B3F
		// (set) Token: 0x06000226 RID: 550 RVA: 0x00007947 File Offset: 0x00005B47
		[Category("Metro Appearance")]
		[DefaultValue(false)]
		public bool UseBarColor
		{
			get
			{
				return this.useBarColor;
			}
			set
			{
				this.useBarColor = value;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000227 RID: 551 RVA: 0x00007950 File Offset: 0x00005B50
		// (set) Token: 0x06000228 RID: 552 RVA: 0x00007968 File Offset: 0x00005B68
		[Category("Metro Appearance")]
		[DefaultValue(10)]
		public int ScrollbarSize
		{
			get
			{
				if (this.Orientation != MetroScrollOrientation.Vertical)
				{
					return base.Height;
				}
				return base.Width;
			}
			set
			{
				if (this.Orientation == MetroScrollOrientation.Vertical)
				{
					base.Width = value;
					return;
				}
				base.Height = value;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000229 RID: 553 RVA: 0x00007982 File Offset: 0x00005B82
		// (set) Token: 0x0600022A RID: 554 RVA: 0x0000798A File Offset: 0x00005B8A
		[Category("Metro Appearance")]
		[DefaultValue(false)]
		public bool HighlightOnWheel
		{
			get
			{
				return this.highlightOnWheel;
			}
			set
			{
				this.highlightOnWheel = value;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600022B RID: 555 RVA: 0x00007993 File Offset: 0x00005B93
		// (set) Token: 0x0600022C RID: 556 RVA: 0x0000799C File Offset: 0x00005B9C
		public MetroScrollOrientation Orientation
		{
			get
			{
				return this.metroOrientation;
			}
			set
			{
				if (value == this.metroOrientation)
				{
					return;
				}
				this.metroOrientation = value;
				if (value == MetroScrollOrientation.Vertical)
				{
					this.scrollOrientation = ScrollOrientation.VerticalScroll;
				}
				else
				{
					this.scrollOrientation = ScrollOrientation.HorizontalScroll;
				}
				base.Size = new Size(base.Height, base.Width);
				this.SetupScrollBar();
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600022D RID: 557 RVA: 0x000079EB File Offset: 0x00005BEB
		// (set) Token: 0x0600022E RID: 558 RVA: 0x000079F4 File Offset: 0x00005BF4
		[DefaultValue(0)]
		public int Minimum
		{
			get
			{
				return this.minimum;
			}
			set
			{
				if (this.minimum == value || value < 0 || value >= this.maximum)
				{
					return;
				}
				this.minimum = value;
				if (this.curValue < value)
				{
					this.curValue = value;
				}
				if (this.largeChange > this.maximum - this.minimum)
				{
					this.largeChange = this.maximum - this.minimum;
				}
				this.SetupScrollBar();
				if (this.curValue < value)
				{
					this.dontUpdateColor = true;
					this.Value = value;
					return;
				}
				this.ChangeThumbPosition(this.GetThumbPosition());
				this.Refresh();
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600022F RID: 559 RVA: 0x00007A87 File Offset: 0x00005C87
		// (set) Token: 0x06000230 RID: 560 RVA: 0x00007A90 File Offset: 0x00005C90
		[DefaultValue(100)]
		public int Maximum
		{
			get
			{
				return this.maximum;
			}
			set
			{
				if (value == this.maximum || value < 1 || value <= this.minimum)
				{
					return;
				}
				this.maximum = value;
				if (this.largeChange > this.maximum - this.minimum)
				{
					this.largeChange = this.maximum - this.minimum;
				}
				this.SetupScrollBar();
				if (this.curValue > value)
				{
					this.dontUpdateColor = true;
					this.Value = this.maximum;
					return;
				}
				this.ChangeThumbPosition(this.GetThumbPosition());
				this.Refresh();
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000231 RID: 561 RVA: 0x00007B18 File Offset: 0x00005D18
		// (set) Token: 0x06000232 RID: 562 RVA: 0x00007B20 File Offset: 0x00005D20
		[DefaultValue(1)]
		public int SmallChange
		{
			get
			{
				return this.smallChange;
			}
			set
			{
				if (value == this.smallChange || value < 1 || value >= this.largeChange)
				{
					return;
				}
				this.smallChange = value;
				this.SetupScrollBar();
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000233 RID: 563 RVA: 0x00007B46 File Offset: 0x00005D46
		// (set) Token: 0x06000234 RID: 564 RVA: 0x00007B50 File Offset: 0x00005D50
		[DefaultValue(10)]
		public int LargeChange
		{
			get
			{
				return this.largeChange;
			}
			set
			{
				if (value == this.largeChange || value < this.smallChange || value < 2)
				{
					return;
				}
				if (value > this.maximum - this.minimum)
				{
					this.largeChange = this.maximum - this.minimum;
				}
				else
				{
					this.largeChange = value;
				}
				this.SetupScrollBar();
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000235 RID: 565 RVA: 0x00007BA6 File Offset: 0x00005DA6
		// (set) Token: 0x06000236 RID: 566 RVA: 0x00007BB0 File Offset: 0x00005DB0
		[Browsable(false)]
		[DefaultValue(0)]
		public int Value
		{
			get
			{
				return this.curValue;
			}
			set
			{
				if (this.curValue == value || value < this.minimum || value > this.maximum)
				{
					return;
				}
				this.curValue = value;
				this.ChangeThumbPosition(this.GetThumbPosition());
				this.OnScroll(ScrollEventType.ThumbPosition, -1, value, this.scrollOrientation);
				if (!this.dontUpdateColor && this.highlightOnWheel)
				{
					if (!this.isHovered)
					{
						this.isHovered = true;
					}
					if (this.autoHoverTimer == null)
					{
						this.autoHoverTimer = new Timer();
						this.autoHoverTimer.Interval = 1000;
						this.autoHoverTimer.Tick += this.autoHoverTimer_Tick;
						this.autoHoverTimer.Start();
					}
					else
					{
						this.autoHoverTimer.Stop();
						this.autoHoverTimer.Start();
					}
				}
				else
				{
					this.dontUpdateColor = false;
				}
				this.Refresh();
			}
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00007C86 File Offset: 0x00005E86
		private void autoHoverTimer_Tick(object sender, EventArgs e)
		{
			this.isHovered = false;
			base.Invalidate();
			this.autoHoverTimer.Stop();
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00007CA0 File Offset: 0x00005EA0
		public MetroScrollBar()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.Width = 10;
			base.Height = 200;
			this.SetupScrollBar();
			this.progressTimer.Interval = 20;
			this.progressTimer.Tick += this.ProgressTimerTick;
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00007D49 File Offset: 0x00005F49
		public MetroScrollBar(MetroScrollOrientation orientation) : this()
		{
			this.Orientation = orientation;
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00007D58 File Offset: 0x00005F58
		public MetroScrollBar(MetroScrollOrientation orientation, int width) : this(orientation)
		{
			base.Width = width;
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00007D68 File Offset: 0x00005F68
		public bool HitTest(Point point)
		{
			return this.thumbRectangle.Contains(point);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00007D76 File Offset: 0x00005F76
		[SecuritySafeCritical]
		public void BeginUpdate()
		{
			WinApi.SendMessage(base.Handle, 11, false, 0);
			this.inUpdate = true;
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00007D8F File Offset: 0x00005F8F
		[SecuritySafeCritical]
		public void EndUpdate()
		{
			WinApi.SendMessage(base.Handle, 11, true, 0);
			this.inUpdate = false;
			this.SetupScrollBar();
			this.Refresh();
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00007DB4 File Offset: 0x00005FB4
		protected override void OnPaintBackground(PaintEventArgs e)
		{
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00007DB8 File Offset: 0x00005FB8
		protected override void OnPaint(PaintEventArgs e)
		{
			Color color;
			if (base.Parent != null)
			{
				if (base.Parent is IMetroControl)
				{
					color = MetroPaint.BackColor.Form(base.Theme);
				}
				else
				{
					color = base.Parent.BackColor;
				}
			}
			else
			{
				color = MetroPaint.BackColor.Form(base.Theme);
			}
			Color thumbColor;
			Color barColor;
			if (this.isHovered && !this.isPressed && base.Enabled)
			{
				thumbColor = MetroPaint.BackColor.ScrollBar.Thumb.Hover(base.Theme);
				barColor = MetroPaint.BackColor.ScrollBar.Bar.Hover(base.Theme);
			}
			else if (this.isHovered && this.isPressed && base.Enabled)
			{
				thumbColor = MetroPaint.BackColor.ScrollBar.Thumb.Press(base.Theme);
				barColor = MetroPaint.BackColor.ScrollBar.Bar.Press(base.Theme);
			}
			else if (!base.Enabled)
			{
				thumbColor = MetroPaint.BackColor.ScrollBar.Thumb.Disabled(base.Theme);
				barColor = MetroPaint.BackColor.ScrollBar.Bar.Disabled(base.Theme);
			}
			else
			{
				thumbColor = MetroPaint.BackColor.ScrollBar.Thumb.Normal(base.Theme);
				barColor = MetroPaint.BackColor.ScrollBar.Bar.Normal(base.Theme);
			}
			e.Graphics.Clear(color);
			this.DrawScrollBar(e.Graphics, color, thumbColor, barColor);
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00007EBC File Offset: 0x000060BC
		private void DrawScrollBar(Graphics g, Color backColor, Color thumbColor, Color barColor)
		{
			if (this.useBarColor)
			{
				using (SolidBrush solidBrush = new SolidBrush(barColor))
				{
					g.FillRectangle(solidBrush, base.ClientRectangle);
				}
			}
			using (SolidBrush solidBrush2 = new SolidBrush(backColor))
			{
				Rectangle rect = new Rectangle(this.thumbRectangle.X - 1, this.thumbRectangle.Y - 1, this.thumbRectangle.Width + 2, this.thumbRectangle.Height + 2);
				g.FillRectangle(solidBrush2, rect);
			}
			using (SolidBrush solidBrush3 = new SolidBrush(thumbColor))
			{
				g.FillRectangle(solidBrush3, this.thumbRectangle);
			}
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00007F90 File Offset: 0x00006190
		protected override void OnGotFocus(EventArgs e)
		{
			base.Invalidate();
			base.OnGotFocus(e);
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00007F9F File Offset: 0x0000619F
		protected override void OnLostFocus(EventArgs e)
		{
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLostFocus(e);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00007FBC File Offset: 0x000061BC
		protected override void OnEnter(EventArgs e)
		{
			base.Invalidate();
			base.OnEnter(e);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00007FCB File Offset: 0x000061CB
		protected override void OnLeave(EventArgs e)
		{
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLeave(e);
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00007FE8 File Offset: 0x000061E8
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			int num = e.Delta / 120 * (this.maximum - this.minimum) / this.mouseWheelBarPartitions;
			if (this.Orientation == MetroScrollOrientation.Vertical)
			{
				this.Value -= num;
				return;
			}
			this.Value += num;
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00008044 File Offset: 0x00006244
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.isPressed = true;
				base.Invalidate();
			}
			base.OnMouseDown(e);
			base.Focus();
			if (e.Button != MouseButtons.Left)
			{
				if (e.Button == MouseButtons.Right)
				{
					this.trackPosition = ((this.metroOrientation == MetroScrollOrientation.Vertical) ? e.Y : e.X);
				}
				return;
			}
			Point location = e.Location;
			if (this.thumbRectangle.Contains(location))
			{
				this.thumbClicked = true;
				this.thumbPosition = ((this.metroOrientation == MetroScrollOrientation.Vertical) ? (location.Y - this.thumbRectangle.Y) : (location.X - this.thumbRectangle.X));
				base.Invalidate(this.thumbRectangle);
				return;
			}
			this.trackPosition = ((this.metroOrientation == MetroScrollOrientation.Vertical) ? location.Y : location.X);
			if (this.trackPosition < ((this.metroOrientation == MetroScrollOrientation.Vertical) ? this.thumbRectangle.Y : this.thumbRectangle.X))
			{
				this.topBarClicked = true;
			}
			else
			{
				this.bottomBarClicked = true;
			}
			this.ProgressThumb(true);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00008174 File Offset: 0x00006374
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.isPressed = false;
			base.OnMouseUp(e);
			if (e.Button == MouseButtons.Left)
			{
				if (this.thumbClicked)
				{
					this.thumbClicked = false;
					this.OnScroll(ScrollEventType.EndScroll, -1, this.curValue, this.scrollOrientation);
				}
				else if (this.topBarClicked)
				{
					this.topBarClicked = false;
					this.StopTimer();
				}
				else if (this.bottomBarClicked)
				{
					this.bottomBarClicked = false;
					this.StopTimer();
				}
				base.Invalidate();
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x000081F3 File Offset: 0x000063F3
		protected override void OnMouseEnter(EventArgs e)
		{
			this.isHovered = true;
			base.Invalidate();
			base.OnMouseEnter(e);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00008209 File Offset: 0x00006409
		protected override void OnMouseLeave(EventArgs e)
		{
			this.isHovered = false;
			base.Invalidate();
			base.OnMouseLeave(e);
			this.ResetScrollStatus();
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00008228 File Offset: 0x00006428
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (e.Button == MouseButtons.Left)
			{
				if (this.thumbClicked)
				{
					int num = this.curValue;
					int num2 = (this.metroOrientation == MetroScrollOrientation.Vertical) ? e.Location.Y : e.Location.X;
					int num3 = (this.metroOrientation == MetroScrollOrientation.Vertical) ? (num2 / base.Height / this.thumbHeight) : (num2 / base.Width / this.thumbWidth);
					if (num2 <= this.thumbTopLimit + this.thumbPosition)
					{
						this.ChangeThumbPosition(this.thumbTopLimit);
						this.curValue = this.minimum;
						base.Invalidate();
					}
					else if (num2 >= this.thumbBottomLimitTop + this.thumbPosition)
					{
						this.ChangeThumbPosition(this.thumbBottomLimitTop);
						this.curValue = this.maximum;
						base.Invalidate();
					}
					else
					{
						this.ChangeThumbPosition(num2 - this.thumbPosition);
						int num4;
						int num5;
						if (this.Orientation == MetroScrollOrientation.Vertical)
						{
							num4 = base.Height - num3;
							num5 = this.thumbRectangle.Y;
						}
						else
						{
							num4 = base.Width - num3;
							num5 = this.thumbRectangle.X;
						}
						float num6 = 0f;
						if (num4 != 0)
						{
							num6 = (float)num5 / (float)num4;
						}
						this.curValue = Convert.ToInt32(num6 * (float)(this.maximum - this.minimum) + (float)this.minimum);
					}
					if (num != this.curValue)
					{
						this.OnScroll(ScrollEventType.ThumbTrack, num, this.curValue, this.scrollOrientation);
						this.Refresh();
						return;
					}
				}
			}
			else
			{
				if (!base.ClientRectangle.Contains(e.Location))
				{
					this.ResetScrollStatus();
					return;
				}
				if (e.Button == MouseButtons.None)
				{
					if (this.thumbRectangle.Contains(e.Location))
					{
						base.Invalidate(this.thumbRectangle);
						return;
					}
					if (base.ClientRectangle.Contains(e.Location))
					{
						base.Invalidate();
					}
				}
			}
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00008417 File Offset: 0x00006617
		protected override void OnKeyDown(KeyEventArgs e)
		{
			this.isHovered = true;
			this.isPressed = true;
			base.Invalidate();
			base.OnKeyDown(e);
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00008434 File Offset: 0x00006634
		protected override void OnKeyUp(KeyEventArgs e)
		{
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnKeyUp(e);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00008451 File Offset: 0x00006651
		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			base.SetBoundsCore(x, y, width, height, specified);
			if (base.DesignMode)
			{
				this.SetupScrollBar();
			}
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000846E File Offset: 0x0000666E
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			this.SetupScrollBar();
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00008480 File Offset: 0x00006680
		protected override bool ProcessDialogKey(Keys keyData)
		{
			Keys keys = Keys.Up;
			Keys keys2 = Keys.Down;
			if (this.Orientation == MetroScrollOrientation.Horizontal)
			{
				keys = Keys.Left;
				keys2 = Keys.Right;
			}
			if (keyData == keys)
			{
				this.Value -= this.smallChange;
				return true;
			}
			if (keyData == keys2)
			{
				this.Value += this.smallChange;
				return true;
			}
			if (keyData == Keys.Prior)
			{
				this.Value = this.GetValue(false, true);
				return true;
			}
			if (keyData == Keys.Next)
			{
				if (this.curValue + this.largeChange > this.maximum)
				{
					this.Value = this.maximum;
				}
				else
				{
					this.Value += this.largeChange;
				}
				return true;
			}
			if (keyData == Keys.Home)
			{
				this.Value = this.minimum;
				return true;
			}
			if (keyData == Keys.End)
			{
				this.Value = this.maximum;
				return true;
			}
			return base.ProcessDialogKey(keyData);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00008552 File Offset: 0x00006752
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			base.Invalidate();
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00008564 File Offset: 0x00006764
		private void SetupScrollBar()
		{
			if (this.inUpdate)
			{
				return;
			}
			if (this.Orientation == MetroScrollOrientation.Vertical)
			{
				this.thumbWidth = ((base.Width > 0) ? base.Width : 10);
				this.thumbHeight = this.GetThumbSize();
				this.clickedBarRectangle = base.ClientRectangle;
				this.clickedBarRectangle.Inflate(-1, -1);
				this.thumbRectangle = new Rectangle(base.ClientRectangle.X, base.ClientRectangle.Y, this.thumbWidth, this.thumbHeight);
				this.thumbPosition = this.thumbRectangle.Height / 2;
				this.thumbBottomLimitBottom = base.ClientRectangle.Bottom;
				this.thumbBottomLimitTop = this.thumbBottomLimitBottom - this.thumbRectangle.Height;
				this.thumbTopLimit = base.ClientRectangle.Y;
			}
			else
			{
				this.thumbHeight = ((base.Height > 0) ? base.Height : 10);
				this.thumbWidth = this.GetThumbSize();
				this.clickedBarRectangle = base.ClientRectangle;
				this.clickedBarRectangle.Inflate(-1, -1);
				this.thumbRectangle = new Rectangle(base.ClientRectangle.X, base.ClientRectangle.Y, this.thumbWidth, this.thumbHeight);
				this.thumbPosition = this.thumbRectangle.Width / 2;
				this.thumbBottomLimitBottom = base.ClientRectangle.Right;
				this.thumbBottomLimitTop = this.thumbBottomLimitBottom - this.thumbRectangle.Width;
				this.thumbTopLimit = base.ClientRectangle.X;
			}
			this.ChangeThumbPosition(this.GetThumbPosition());
			this.Refresh();
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000872C File Offset: 0x0000692C
		private void ResetScrollStatus()
		{
			this.bottomBarClicked = (this.topBarClicked = false);
			this.StopTimer();
			this.Refresh();
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00008755 File Offset: 0x00006955
		private void ProgressTimerTick(object sender, EventArgs e)
		{
			this.ProgressThumb(true);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00008760 File Offset: 0x00006960
		private int GetValue(bool smallIncrement, bool up)
		{
			int num;
			if (up)
			{
				num = this.curValue - (smallIncrement ? this.smallChange : this.largeChange);
				if (num < this.minimum)
				{
					num = this.minimum;
				}
			}
			else
			{
				num = this.curValue + (smallIncrement ? this.smallChange : this.largeChange);
				if (num > this.maximum)
				{
					num = this.maximum;
				}
			}
			return num;
		}

		// Token: 0x06000255 RID: 597 RVA: 0x000087C8 File Offset: 0x000069C8
		private int GetThumbPosition()
		{
			if (this.thumbHeight == 0 || this.thumbWidth == 0)
			{
				return 0;
			}
			int num = (this.metroOrientation == MetroScrollOrientation.Vertical) ? (this.thumbPosition / base.Height / this.thumbHeight) : (this.thumbPosition / base.Width / this.thumbWidth);
			int num2;
			if (this.Orientation == MetroScrollOrientation.Vertical)
			{
				num2 = base.Height - num;
			}
			else
			{
				num2 = base.Width - num;
			}
			int num3 = this.maximum - this.minimum;
			float num4 = 0f;
			if (num3 != 0)
			{
				num4 = ((float)this.curValue - (float)this.minimum) / (float)num3;
			}
			return Math.Max(this.thumbTopLimit, Math.Min(this.thumbBottomLimitTop, Convert.ToInt32(num4 * (float)num2)));
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00008884 File Offset: 0x00006A84
		private int GetThumbSize()
		{
			int num = (this.metroOrientation == MetroScrollOrientation.Vertical) ? base.Height : base.Width;
			if (this.maximum == 0 || this.largeChange == 0)
			{
				return num;
			}
			float val = (float)this.largeChange * (float)num / (float)this.maximum;
			return Convert.ToInt32(Math.Min((float)num, Math.Max(val, 10f)));
		}

		// Token: 0x06000257 RID: 599 RVA: 0x000088E5 File Offset: 0x00006AE5
		private void EnableTimer()
		{
			if (!this.progressTimer.Enabled)
			{
				this.progressTimer.Interval = 600;
				this.progressTimer.Start();
				return;
			}
			this.progressTimer.Interval = 10;
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000891D File Offset: 0x00006B1D
		private void StopTimer()
		{
			this.progressTimer.Stop();
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000892A File Offset: 0x00006B2A
		private void ChangeThumbPosition(int position)
		{
			if (this.Orientation == MetroScrollOrientation.Vertical)
			{
				this.thumbRectangle.Y = position;
				return;
			}
			this.thumbRectangle.X = position;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00008950 File Offset: 0x00006B50
		private void ProgressThumb(bool enableTimer)
		{
			int num = this.curValue;
			ScrollEventType type = ScrollEventType.First;
			int num2;
			int num3;
			if (this.Orientation == MetroScrollOrientation.Vertical)
			{
				num2 = this.thumbRectangle.Y;
				num3 = this.thumbRectangle.Height;
			}
			else
			{
				num2 = this.thumbRectangle.X;
				num3 = this.thumbRectangle.Width;
			}
			if (this.bottomBarClicked && num2 + num3 < this.trackPosition)
			{
				type = ScrollEventType.LargeIncrement;
				this.curValue = this.GetValue(false, false);
				if (this.curValue == this.maximum)
				{
					this.ChangeThumbPosition(this.thumbBottomLimitTop);
					type = ScrollEventType.Last;
				}
				else
				{
					this.ChangeThumbPosition(Math.Min(this.thumbBottomLimitTop, this.GetThumbPosition()));
				}
			}
			else if (this.topBarClicked && num2 > this.trackPosition)
			{
				type = ScrollEventType.LargeDecrement;
				this.curValue = this.GetValue(false, true);
				if (this.curValue == this.minimum)
				{
					this.ChangeThumbPosition(this.thumbTopLimit);
					type = ScrollEventType.First;
				}
				else
				{
					this.ChangeThumbPosition(Math.Max(this.thumbTopLimit, this.GetThumbPosition()));
				}
			}
			if (num != this.curValue)
			{
				this.OnScroll(type, num, this.curValue, this.scrollOrientation);
				base.Invalidate();
				if (enableTimer)
				{
					this.EnableTimer();
				}
			}
		}

		// Token: 0x0400008A RID: 138
		internal const int SCROLLBAR_DEFAULT_SIZE = 10;

		// Token: 0x0400008C RID: 140
		private bool isFirstScrollEventVertical = true;

		// Token: 0x0400008D RID: 141
		private bool isFirstScrollEventHorizontal = true;

		// Token: 0x0400008E RID: 142
		private bool inUpdate;

		// Token: 0x0400008F RID: 143
		private Rectangle clickedBarRectangle;

		// Token: 0x04000090 RID: 144
		private Rectangle thumbRectangle;

		// Token: 0x04000091 RID: 145
		private bool topBarClicked;

		// Token: 0x04000092 RID: 146
		private bool bottomBarClicked;

		// Token: 0x04000093 RID: 147
		private bool thumbClicked;

		// Token: 0x04000094 RID: 148
		private int thumbWidth = 6;

		// Token: 0x04000095 RID: 149
		private int thumbHeight;

		// Token: 0x04000096 RID: 150
		private int thumbBottomLimitBottom;

		// Token: 0x04000097 RID: 151
		private int thumbBottomLimitTop;

		// Token: 0x04000098 RID: 152
		private int thumbTopLimit;

		// Token: 0x04000099 RID: 153
		private int thumbPosition;

		// Token: 0x0400009A RID: 154
		private int trackPosition;

		// Token: 0x0400009B RID: 155
		private readonly Timer progressTimer = new Timer();

		// Token: 0x0400009C RID: 156
		private int mouseWheelBarPartitions = 10;

		// Token: 0x0400009D RID: 157
		private bool isHovered;

		// Token: 0x0400009E RID: 158
		private bool isPressed;

		// Token: 0x0400009F RID: 159
		private bool useBarColor;

		// Token: 0x040000A0 RID: 160
		private bool highlightOnWheel;

		// Token: 0x040000A1 RID: 161
		private MetroScrollOrientation metroOrientation = MetroScrollOrientation.Vertical;

		// Token: 0x040000A2 RID: 162
		private ScrollOrientation scrollOrientation = ScrollOrientation.VerticalScroll;

		// Token: 0x040000A3 RID: 163
		private int minimum;

		// Token: 0x040000A4 RID: 164
		private int maximum = 100;

		// Token: 0x040000A5 RID: 165
		private int smallChange = 1;

		// Token: 0x040000A6 RID: 166
		private int largeChange = 10;

		// Token: 0x040000A7 RID: 167
		private bool dontUpdateColor;

		// Token: 0x040000A8 RID: 168
		private int curValue;

		// Token: 0x040000A9 RID: 169
		private Timer autoHoverTimer;
	}
}
