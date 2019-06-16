using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Drawing;

namespace MetroFramework.Controls
{
	// Token: 0x0200002E RID: 46
	[ToolboxBitmap(typeof(ProgressBar))]
	[Designer("MetroFramework.Design.MetroProgressBarDesigner, MetroFramework.Design, Version=1.2.0.3, Culture=neutral, PublicKeyToken=5f91a84759bf584a")]
	public class MetroProgressBar : MetroProgressBarBase
	{
		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x000069E6 File Offset: 0x00004BE6
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x000069EE File Offset: 0x00004BEE
		[Category("Metro Appearance")]
		[DefaultValue(MetroProgressBarSize.Medium)]
		public MetroProgressBarSize FontSize
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

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x000069F7 File Offset: 0x00004BF7
		// (set) Token: 0x060001DA RID: 474 RVA: 0x000069FF File Offset: 0x00004BFF
		[Category("Metro Appearance")]
		[DefaultValue(MetroProgressBarWeight.Light)]
		public MetroProgressBarWeight FontWeight
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

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00006A08 File Offset: 0x00004C08
		// (set) Token: 0x060001DC RID: 476 RVA: 0x00006A10 File Offset: 0x00004C10
		[DefaultValue(ContentAlignment.MiddleRight)]
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

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00006A19 File Offset: 0x00004C19
		// (set) Token: 0x060001DE RID: 478 RVA: 0x00006A21 File Offset: 0x00004C21
		[DefaultValue(true)]
		[Category("Metro Appearance")]
		public bool HideProgressText
		{
			get
			{
				return this.hideProgressText;
			}
			set
			{
				this.hideProgressText = value;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00006A2A File Offset: 0x00004C2A
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x00006A32 File Offset: 0x00004C32
		[DefaultValue(ProgressBarStyle.Continuous)]
		[Category("Metro Appearance")]
		public ProgressBarStyle ProgressBarStyle
		{
			get
			{
				return this.progressBarStyle;
			}
			set
			{
				this.progressBarStyle = value;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x00006A3B File Offset: 0x00004C3B
		// (set) Token: 0x060001E2 RID: 482 RVA: 0x00006A43 File Offset: 0x00004C43
		public new int Value
		{
			get
			{
				return base.Value;
			}
			set
			{
				if (value > base.Maximum)
				{
					return;
				}
				base.Value = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00006A5C File Offset: 0x00004C5C
		[Browsable(false)]
		public double ProgressTotalPercent
		{
			get
			{
				return (1.0 - (double)(base.Maximum - this.Value) / (double)base.Maximum) * 100.0;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x00006A88 File Offset: 0x00004C88
		[Browsable(false)]
		public double ProgressTotalValue
		{
			get
			{
				return 1.0 - (double)(base.Maximum - this.Value) / (double)base.Maximum;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x00006AAA File Offset: 0x00004CAA
		[Browsable(false)]
		public string ProgressPercentText
		{
			get
			{
				return string.Format("{0}%", Math.Round(this.ProgressTotalPercent));
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x00006AC8 File Offset: 0x00004CC8
		private double ProgressBarWidth
		{
			get
			{
				return (double)this.Value / (double)base.Maximum * (double)base.ClientRectangle.Width;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x00006AF4 File Offset: 0x00004CF4
		private int ProgressBarMarqueeWidth
		{
			get
			{
				return base.ClientRectangle.Width / 3;
			}
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00006B11 File Offset: 0x00004D11
		public MetroProgressBar()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00006B44 File Offset: 0x00004D44
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Color color = base.Enabled ? MetroPaint.BackColor.ProgressBar.Bar.Normal(base.Theme) : MetroPaint.BackColor.ProgressBar.Bar.Disabled(base.Theme);
			e.Graphics.Clear(color);
			if (this.progressBarStyle == ProgressBarStyle.Continuous)
			{
				if (!base.DesignMode)
				{
					this.StopTimer();
				}
				this.DrawProgressContinuous(e.Graphics);
			}
			else if (this.progressBarStyle == ProgressBarStyle.Blocks)
			{
				if (!base.DesignMode)
				{
					this.StopTimer();
				}
				this.DrawProgressContinuous(e.Graphics);
			}
			else if (this.progressBarStyle == ProgressBarStyle.Marquee)
			{
				if (!base.DesignMode && base.Enabled)
				{
					this.StartTimer();
				}
				if (!base.Enabled)
				{
					this.StopTimer();
				}
				if (this.Value == base.Maximum)
				{
					this.StopTimer();
					this.DrawProgressContinuous(e.Graphics);
				}
				else
				{
					this.DrawProgressMarquee(e.Graphics);
				}
			}
			this.DrawProgressText(e.Graphics);
			using (Pen pen = new Pen(MetroPaint.BorderColor.ProgressBar.Normal(base.Theme)))
			{
				Rectangle rect = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
				e.Graphics.DrawRectangle(pen, rect);
			}
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00006C88 File Offset: 0x00004E88
		private void DrawProgressContinuous(Graphics graphics)
		{
			graphics.FillRectangle(MetroPaint.GetStyleBrush(base.Style), 0, 0, (int)this.ProgressBarWidth, base.ClientRectangle.Height);
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00006CC0 File Offset: 0x00004EC0
		private void DrawProgressMarquee(Graphics graphics)
		{
			graphics.FillRectangle(MetroPaint.GetStyleBrush(base.Style), this.marqueeX, 0, this.ProgressBarMarqueeWidth, base.ClientRectangle.Height);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00006CFC File Offset: 0x00004EFC
		private void DrawProgressText(Graphics graphics)
		{
			if (this.HideProgressText)
			{
				return;
			}
			Color transparent = Color.Transparent;
			Color foreColor = (!base.Enabled) ? MetroPaint.ForeColor.ProgressBar.Disabled(base.Theme) : MetroPaint.ForeColor.ProgressBar.Normal(base.Theme);
			TextRenderer.DrawText(graphics, this.ProgressPercentText, MetroFonts.ProgressBar(this.metroLabelSize, this.metroLabelWeight), base.ClientRectangle, foreColor, transparent, MetroPaint.GetTextFormatFlags(this.TextAlign));
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00006D6C File Offset: 0x00004F6C
		public override Size GetPreferredSize(Size proposedSize)
		{
			base.GetPreferredSize(proposedSize);
			Size result;
			using (Graphics graphics = base.CreateGraphics())
			{
				proposedSize = new Size(int.MaxValue, int.MaxValue);
				result = TextRenderer.MeasureText(graphics, this.ProgressPercentText, MetroFonts.ProgressBar(this.metroLabelSize, this.metroLabelWeight), proposedSize, MetroPaint.GetTextFormatFlags(this.TextAlign));
			}
			return result;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00006DE0 File Offset: 0x00004FE0
		private void StartTimer()
		{
			if (this.marqueeTimerEnabled)
			{
				return;
			}
			if (this.marqueeTimer == null)
			{
				this.marqueeTimer = new Timer();
				this.marqueeTimer.Interval = 10;
				this.marqueeTimer.Tick += this.marqueeTimer_Tick;
			}
			this.marqueeX = -this.ProgressBarMarqueeWidth;
			this.marqueeTimer.Stop();
			this.marqueeTimer.Start();
			this.marqueeTimerEnabled = true;
			base.Invalidate();
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00006E5D File Offset: 0x0000505D
		private void StopTimer()
		{
			if (this.marqueeTimer == null)
			{
				return;
			}
			this.marqueeTimer.Stop();
			base.Invalidate();
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00006E7C File Offset: 0x0000507C
		private void marqueeTimer_Tick(object sender, EventArgs e)
		{
			this.marqueeX++;
			if (this.marqueeX > base.ClientRectangle.Width)
			{
				this.marqueeX = -this.ProgressBarMarqueeWidth;
			}
			base.Invalidate();
		}

		// Token: 0x0400006E RID: 110
		private MetroProgressBarSize metroLabelSize = MetroProgressBarSize.Medium;

		// Token: 0x0400006F RID: 111
		private MetroProgressBarWeight metroLabelWeight;

		// Token: 0x04000070 RID: 112
		private ContentAlignment textAlign = ContentAlignment.MiddleRight;

		// Token: 0x04000071 RID: 113
		private bool hideProgressText = true;

		// Token: 0x04000072 RID: 114
		private ProgressBarStyle progressBarStyle = ProgressBarStyle.Continuous;

		// Token: 0x04000073 RID: 115
		private int marqueeX;

		// Token: 0x04000074 RID: 116
		private Timer marqueeTimer;

		// Token: 0x04000075 RID: 117
		private bool marqueeTimerEnabled;
	}
}
