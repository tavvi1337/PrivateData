using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MetroFramework.Drawing;

namespace MetroFramework.Controls
{
	// Token: 0x0200002F RID: 47
	[Designer("MetroFramework.Design.MetroProgressSpinnerDesigner, MetroFramework.Design, Version=1.2.0.3, Culture=neutral, PublicKeyToken=5f91a84759bf584a")]
	[ToolboxBitmap(typeof(ProgressBar))]
	public class MetroProgressSpinner : MetroControlBase
	{
		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x00006EC0 File Offset: 0x000050C0
		// (set) Token: 0x060001F2 RID: 498 RVA: 0x00006ECD File Offset: 0x000050CD
		[DefaultValue(true)]
		[Category("Metro Behavior")]
		public bool Spinning
		{
			get
			{
				return this.timer.Enabled;
			}
			set
			{
				this.timer.Enabled = value;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x00006EDB File Offset: 0x000050DB
		// (set) Token: 0x060001F4 RID: 500 RVA: 0x00006EE3 File Offset: 0x000050E3
		[DefaultValue(0)]
		[Category("Metro Appearance")]
		public int Value
		{
			get
			{
				return this.progress;
			}
			set
			{
				if (value != -1 && (value < this.minimum || value > this.maximum))
				{
					throw new ArgumentOutOfRangeException("Progress value must be -1 or between Minimum and Maximum.");
				}
				this.progress = value;
				this.Refresh();
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x00006F14 File Offset: 0x00005114
		// (set) Token: 0x060001F6 RID: 502 RVA: 0x00006F1C File Offset: 0x0000511C
		[Category("Metro Appearance")]
		[DefaultValue(0)]
		public int Minimum
		{
			get
			{
				return this.minimum;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Minimum value must be >= 0.");
				}
				if (value >= this.maximum)
				{
					throw new ArgumentOutOfRangeException("Minimum value must be < Maximum.");
				}
				this.minimum = value;
				if (this.progress != -1 && this.progress < this.minimum)
				{
					this.progress = this.minimum;
				}
				this.Refresh();
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00006F7E File Offset: 0x0000517E
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x00006F86 File Offset: 0x00005186
		[Category("Metro Appearance")]
		[DefaultValue(0)]
		public int Maximum
		{
			get
			{
				return this.maximum;
			}
			set
			{
				if (value <= this.minimum)
				{
					throw new ArgumentOutOfRangeException("Maximum value must be > Minimum.");
				}
				this.maximum = value;
				if (this.progress > this.maximum)
				{
					this.progress = this.maximum;
				}
				this.Refresh();
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x00006FC4 File Offset: 0x000051C4
		// (set) Token: 0x060001FA RID: 506 RVA: 0x00006FCC File Offset: 0x000051CC
		[DefaultValue(true)]
		[Category("Metro Appearance")]
		public bool EnsureVisible
		{
			get
			{
				return this.ensureVisible;
			}
			set
			{
				this.ensureVisible = value;
				this.Refresh();
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060001FB RID: 507 RVA: 0x00006FDB File Offset: 0x000051DB
		// (set) Token: 0x060001FC RID: 508 RVA: 0x00006FE3 File Offset: 0x000051E3
		[Category("Metro Behavior")]
		[DefaultValue(1f)]
		public float Speed
		{
			get
			{
				return this.speed;
			}
			set
			{
				if (value <= 0f || value > 10f)
				{
					throw new ArgumentOutOfRangeException("Speed value must be > 0 and <= 10.");
				}
				this.speed = value;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060001FD RID: 509 RVA: 0x00007008 File Offset: 0x00005208
		// (set) Token: 0x060001FE RID: 510 RVA: 0x00007010 File Offset: 0x00005210
		[DefaultValue(false)]
		[Category("Metro Behavior")]
		public bool Backwards
		{
			get
			{
				return this.backwards;
			}
			set
			{
				this.backwards = value;
				this.Refresh();
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060001FF RID: 511 RVA: 0x0000701F File Offset: 0x0000521F
		// (set) Token: 0x06000200 RID: 512 RVA: 0x00007027 File Offset: 0x00005227
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

		// Token: 0x06000201 RID: 513 RVA: 0x00007030 File Offset: 0x00005230
		public MetroProgressSpinner()
		{
			this.timer = new Timer();
			this.timer.Interval = 20;
			this.timer.Tick += this.timer_Tick;
			this.timer.Enabled = true;
			base.Width = 16;
			base.Height = 16;
			this.speed = 1f;
			this.DoubleBuffered = true;
		}

		// Token: 0x06000202 RID: 514 RVA: 0x000070BA File Offset: 0x000052BA
		public void Reset()
		{
			this.progress = this.minimum;
			this.angle = 270f;
			this.Refresh();
		}

		// Token: 0x06000203 RID: 515 RVA: 0x000070D9 File Offset: 0x000052D9
		private void timer_Tick(object sender, EventArgs e)
		{
			if (!base.DesignMode)
			{
				this.angle += 6f * this.speed * (float)(this.backwards ? -1 : 1);
				this.Refresh();
			}
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00007110 File Offset: 0x00005310
		protected override void OnPaint(PaintEventArgs e)
		{
			Color color;
			Color color2;
			if (this.useCustomBackground)
			{
				color = this.BackColor;
				color2 = MetroPaint.GetStyleColor(base.Style);
			}
			else if (base.Parent is MetroTile)
			{
				color = MetroPaint.GetStyleColor(base.Style);
				color2 = MetroPaint.ForeColor.Tile.Normal(base.Theme);
			}
			else
			{
				color = MetroPaint.BackColor.Form(base.Theme);
				color2 = MetroPaint.GetStyleColor(base.Style);
			}
			e.Graphics.Clear(color);
			using (Pen pen = new Pen(color2, (float)base.Width / 5f))
			{
				int num = (int)Math.Ceiling((double)((float)base.Width / 10f));
				e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				if (this.progress != -1)
				{
					float num2 = (float)(this.progress - this.minimum) / (float)(this.maximum - this.minimum);
					float num3;
					if (this.ensureVisible)
					{
						num3 = 30f + 300f * num2;
					}
					else
					{
						num3 = 360f * num2;
					}
					if (this.backwards)
					{
						num3 = -num3;
					}
					e.Graphics.DrawArc(pen, (float)num, (float)num, (float)(base.Width - 2 * num - 1), (float)(base.Height - 2 * num - 1), this.angle, num3);
				}
				else
				{
					for (int i = 0; i <= 180; i += 15)
					{
						int num4 = 290 - i * 290 / 180;
						if (num4 > 255)
						{
							num4 = 255;
						}
						if (num4 < 0)
						{
							num4 = 0;
						}
						Color color3 = Color.FromArgb(num4, pen.Color);
						using (Pen pen2 = new Pen(color3, pen.Width))
						{
							float startAngle = this.angle + (float)((i - (this.ensureVisible ? 30 : 0)) * (this.backwards ? 1 : -1));
							float sweepAngle = (float)(15 * (this.backwards ? 1 : -1));
							e.Graphics.DrawArc(pen2, (float)num, (float)num, (float)(base.Width - 2 * num - 1), (float)(base.Height - 2 * num - 1), startAngle, sweepAngle);
						}
					}
				}
			}
		}

		// Token: 0x04000076 RID: 118
		private Timer timer;

		// Token: 0x04000077 RID: 119
		private int progress;

		// Token: 0x04000078 RID: 120
		private float angle = 270f;

		// Token: 0x04000079 RID: 121
		private int minimum;

		// Token: 0x0400007A RID: 122
		private int maximum = 100;

		// Token: 0x0400007B RID: 123
		private bool ensureVisible = true;

		// Token: 0x0400007C RID: 124
		private float speed;

		// Token: 0x0400007D RID: 125
		private bool backwards;

		// Token: 0x0400007E RID: 126
		private bool useCustomBackground;
	}
}
