using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Drawing;

namespace MetroFramework.Controls
{
	// Token: 0x0200003A RID: 58
	[ToolboxBitmap(typeof(TrackBar))]
	[DefaultEvent("Scroll")]
	public class MetroTrackBar : MetroControlBase
	{
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000322 RID: 802 RVA: 0x0000AE5C File Offset: 0x0000905C
		// (remove) Token: 0x06000323 RID: 803 RVA: 0x0000AE94 File Offset: 0x00009094
		public event EventHandler ValueChanged;

		// Token: 0x06000324 RID: 804 RVA: 0x0000AEC9 File Offset: 0x000090C9
		private void OnValueChanged()
		{
			if (this.ValueChanged != null)
			{
				this.ValueChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000325 RID: 805 RVA: 0x0000AEE4 File Offset: 0x000090E4
		// (remove) Token: 0x06000326 RID: 806 RVA: 0x0000AF1C File Offset: 0x0000911C
		public event ScrollEventHandler Scroll;

		// Token: 0x06000327 RID: 807 RVA: 0x0000AF51 File Offset: 0x00009151
		private void OnScroll(ScrollEventType scrollType, int newValue)
		{
			if (this.Scroll != null)
			{
				this.Scroll(this, new ScrollEventArgs(scrollType, newValue));
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000328 RID: 808 RVA: 0x0000AF6E File Offset: 0x0000916E
		// (set) Token: 0x06000329 RID: 809 RVA: 0x0000AF76 File Offset: 0x00009176
		[DefaultValue(50)]
		public int Value
		{
			get
			{
				return this.trackerValue;
			}
			set
			{
				if (value >= this.barMinimum & value <= this.barMaximum)
				{
					this.trackerValue = value;
					this.OnValueChanged();
					base.Invalidate();
					return;
				}
				throw new ArgumentOutOfRangeException("Value is outside appropriate range (min, max)");
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600032A RID: 810 RVA: 0x0000AFB1 File Offset: 0x000091B1
		// (set) Token: 0x0600032B RID: 811 RVA: 0x0000AFBC File Offset: 0x000091BC
		[DefaultValue(0)]
		public int Minimum
		{
			get
			{
				return this.barMinimum;
			}
			set
			{
				if (value < this.barMaximum)
				{
					this.barMinimum = value;
					if (this.trackerValue < this.barMinimum)
					{
						this.trackerValue = this.barMinimum;
						if (this.ValueChanged != null)
						{
							this.ValueChanged(this, new EventArgs());
						}
					}
					base.Invalidate();
					return;
				}
				throw new ArgumentOutOfRangeException("Minimal value is greather than maximal one");
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600032C RID: 812 RVA: 0x0000B01D File Offset: 0x0000921D
		// (set) Token: 0x0600032D RID: 813 RVA: 0x0000B028 File Offset: 0x00009228
		[DefaultValue(100)]
		public int Maximum
		{
			get
			{
				return this.barMaximum;
			}
			set
			{
				if (value > this.barMinimum)
				{
					this.barMaximum = value;
					if (this.trackerValue > this.barMaximum)
					{
						this.trackerValue = this.barMaximum;
						if (this.ValueChanged != null)
						{
							this.ValueChanged(this, new EventArgs());
						}
					}
					base.Invalidate();
					return;
				}
				throw new ArgumentOutOfRangeException("Maximal value is lower than minimal one");
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600032E RID: 814 RVA: 0x0000B089 File Offset: 0x00009289
		// (set) Token: 0x0600032F RID: 815 RVA: 0x0000B091 File Offset: 0x00009291
		[DefaultValue(1)]
		public int SmallChange
		{
			get
			{
				return this.smallChange;
			}
			set
			{
				this.smallChange = value;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000330 RID: 816 RVA: 0x0000B09A File Offset: 0x0000929A
		// (set) Token: 0x06000331 RID: 817 RVA: 0x0000B0A2 File Offset: 0x000092A2
		[DefaultValue(5)]
		public int LargeChange
		{
			get
			{
				return this.largeChange;
			}
			set
			{
				this.largeChange = value;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000332 RID: 818 RVA: 0x0000B0AB File Offset: 0x000092AB
		// (set) Token: 0x06000333 RID: 819 RVA: 0x0000B0B3 File Offset: 0x000092B3
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
				throw new ArgumentOutOfRangeException("MouseWheelBarPartitions has to be greather than zero");
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000334 RID: 820 RVA: 0x0000B0CB File Offset: 0x000092CB
		// (set) Token: 0x06000335 RID: 821 RVA: 0x0000B0D3 File Offset: 0x000092D3
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

		// Token: 0x06000336 RID: 822 RVA: 0x0000B0DC File Offset: 0x000092DC
		public MetroTrackBar(int min, int max, int value)
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.BackColor = Color.Transparent;
			this.Minimum = min;
			this.Maximum = max;
			this.Value = value;
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0000B141 File Offset: 0x00009341
		public MetroTrackBar() : this(0, 100, 50)
		{
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0000B150 File Offset: 0x00009350
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
			Color thumbColor;
			Color barColor;
			if (this.isHovered && !this.isPressed && base.Enabled)
			{
				thumbColor = MetroPaint.BackColor.TrackBar.Thumb.Hover(base.Theme);
				barColor = MetroPaint.BackColor.TrackBar.Bar.Hover(base.Theme);
			}
			else if (this.isHovered && this.isPressed && base.Enabled)
			{
				thumbColor = MetroPaint.BackColor.TrackBar.Thumb.Press(base.Theme);
				barColor = MetroPaint.BackColor.TrackBar.Bar.Press(base.Theme);
			}
			else if (!base.Enabled)
			{
				thumbColor = MetroPaint.BackColor.TrackBar.Thumb.Disabled(base.Theme);
				barColor = MetroPaint.BackColor.TrackBar.Bar.Disabled(base.Theme);
			}
			else
			{
				thumbColor = MetroPaint.BackColor.TrackBar.Thumb.Normal(base.Theme);
				barColor = MetroPaint.BackColor.TrackBar.Bar.Normal(base.Theme);
			}
			e.Graphics.Clear(color);
			this.DrawTrackBar(e.Graphics, thumbColor, barColor);
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0000B234 File Offset: 0x00009434
		private void DrawTrackBar(Graphics g, Color thumbColor, Color barColor)
		{
			int num = (this.trackerValue - this.barMinimum) * (base.Width - 6) / (this.barMaximum - this.barMinimum);
			using (SolidBrush solidBrush = new SolidBrush(thumbColor))
			{
				Rectangle rect = new Rectangle(0, base.Height / 2 - 2, num, 4);
				g.FillRectangle(solidBrush, rect);
				Rectangle rect2 = new Rectangle(num, base.Height / 2 - 8, 6, 16);
				g.FillRectangle(solidBrush, rect2);
			}
			using (SolidBrush solidBrush2 = new SolidBrush(barColor))
			{
				Rectangle rect3 = new Rectangle(num + 7, base.Height / 2 - 2, base.Width - num + 7, 4);
				g.FillRectangle(solidBrush2, rect3);
			}
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000B310 File Offset: 0x00009510
		protected override void OnGotFocus(EventArgs e)
		{
			this.isFocused = true;
			base.Invalidate();
			base.OnGotFocus(e);
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000B326 File Offset: 0x00009526
		protected override void OnLostFocus(EventArgs e)
		{
			this.isFocused = false;
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLostFocus(e);
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0000B34A File Offset: 0x0000954A
		protected override void OnEnter(EventArgs e)
		{
			this.isFocused = true;
			base.Invalidate();
			base.OnEnter(e);
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0000B360 File Offset: 0x00009560
		protected override void OnLeave(EventArgs e)
		{
			this.isFocused = false;
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnLeave(e);
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0000B384 File Offset: 0x00009584
		protected override void OnKeyDown(KeyEventArgs e)
		{
			this.isHovered = true;
			this.isPressed = true;
			base.Invalidate();
			base.OnKeyDown(e);
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0000B3A4 File Offset: 0x000095A4
		protected override void OnKeyUp(KeyEventArgs e)
		{
			this.isHovered = false;
			this.isPressed = false;
			base.Invalidate();
			base.OnKeyUp(e);
			switch (e.KeyCode)
			{
			case Keys.Prior:
				this.SetProperValue(this.Value + this.largeChange);
				this.OnScroll(ScrollEventType.LargeIncrement, this.Value);
				break;
			case Keys.Next:
				this.SetProperValue(this.Value - this.largeChange);
				this.OnScroll(ScrollEventType.LargeDecrement, this.Value);
				break;
			case Keys.End:
				this.Value = this.barMaximum;
				break;
			case Keys.Home:
				this.Value = this.barMinimum;
				break;
			case Keys.Left:
			case Keys.Down:
				this.SetProperValue(this.Value - this.smallChange);
				this.OnScroll(ScrollEventType.SmallDecrement, this.Value);
				break;
			case Keys.Up:
			case Keys.Right:
				this.SetProperValue(this.Value + this.smallChange);
				this.OnScroll(ScrollEventType.SmallIncrement, this.Value);
				break;
			}
			if (this.Value == this.barMinimum)
			{
				this.OnScroll(ScrollEventType.First, this.Value);
			}
			if (this.Value == this.barMaximum)
			{
				this.OnScroll(ScrollEventType.Last, this.Value);
			}
			Point point = base.PointToClient(Cursor.Position);
			this.OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, point.X, point.Y, 0));
		}

		// Token: 0x06000340 RID: 832 RVA: 0x0000B504 File Offset: 0x00009704
		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (keyData == Keys.Tab | Control.ModifierKeys == Keys.Shift)
			{
				return base.ProcessDialogKey(keyData);
			}
			this.OnKeyDown(new KeyEventArgs(keyData));
			return true;
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0000B52F File Offset: 0x0000972F
		protected override void OnMouseEnter(EventArgs e)
		{
			this.isHovered = true;
			base.Invalidate();
			base.OnMouseEnter(e);
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0000B548 File Offset: 0x00009748
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.isPressed = true;
				base.Invalidate();
			}
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left)
			{
				base.Capture = true;
				this.OnScroll(ScrollEventType.ThumbTrack, this.trackerValue);
				this.OnValueChanged();
				this.OnMouseMove(e);
			}
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0000B5A4 File Offset: 0x000097A4
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (base.Capture & e.Button == MouseButtons.Left)
			{
				ScrollEventType scrollType = ScrollEventType.ThumbPosition;
				int x = e.Location.X;
				float num = (float)(this.barMaximum - this.barMinimum) / (float)(base.ClientSize.Width - 3);
				this.trackerValue = (int)((float)x * num + (float)this.barMinimum);
				if (this.trackerValue <= this.barMinimum)
				{
					this.trackerValue = this.barMinimum;
					scrollType = ScrollEventType.First;
				}
				else if (this.trackerValue >= this.barMaximum)
				{
					this.trackerValue = this.barMaximum;
					scrollType = ScrollEventType.Last;
				}
				this.OnScroll(scrollType, this.trackerValue);
				this.OnValueChanged();
				base.Invalidate();
			}
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0000B66A File Offset: 0x0000986A
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.isPressed = false;
			base.Invalidate();
			base.OnMouseUp(e);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0000B680 File Offset: 0x00009880
		protected override void OnMouseLeave(EventArgs e)
		{
			this.isHovered = false;
			base.Invalidate();
			base.OnMouseLeave(e);
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0000B698 File Offset: 0x00009898
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			int num = e.Delta / 120 * (this.barMaximum - this.barMinimum) / this.mouseWheelBarPartitions;
			this.SetProperValue(this.Value + num);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0000B6D9 File Offset: 0x000098D9
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			base.Invalidate();
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0000B6E8 File Offset: 0x000098E8
		private void SetProperValue(int val)
		{
			if (val < this.barMinimum)
			{
				this.Value = this.barMinimum;
				return;
			}
			if (val > this.barMaximum)
			{
				this.Value = this.barMaximum;
				return;
			}
			this.Value = val;
		}

		// Token: 0x040000DB RID: 219
		private int trackerValue = 50;

		// Token: 0x040000DC RID: 220
		private int barMinimum;

		// Token: 0x040000DD RID: 221
		private int barMaximum = 100;

		// Token: 0x040000DE RID: 222
		private int smallChange = 1;

		// Token: 0x040000DF RID: 223
		private int largeChange = 5;

		// Token: 0x040000E0 RID: 224
		private int mouseWheelBarPartitions = 10;

		// Token: 0x040000E1 RID: 225
		private bool useCustomBackground;

		// Token: 0x040000E2 RID: 226
		private bool isHovered;

		// Token: 0x040000E3 RID: 227
		private bool isPressed;

		// Token: 0x040000E4 RID: 228
		private bool isFocused;
	}
}
