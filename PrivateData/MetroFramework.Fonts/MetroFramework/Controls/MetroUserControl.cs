using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Drawing;

namespace MetroFramework.Controls
{
	// Token: 0x0200003B RID: 59
	public class MetroUserControl : MetroUserControlBase
	{
		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000349 RID: 841 RVA: 0x0000B71D File Offset: 0x0000991D
		// (set) Token: 0x0600034A RID: 842 RVA: 0x0000B725 File Offset: 0x00009925
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

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600034B RID: 843 RVA: 0x0000B72E File Offset: 0x0000992E
		// (set) Token: 0x0600034C RID: 844 RVA: 0x0000B736 File Offset: 0x00009936
		[Browsable(true)]
		[DefaultValue(MetroBorderStyle.None)]
		[Category("Metro Appearance")]
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

		// Token: 0x0600034D RID: 845 RVA: 0x0000B73F File Offset: 0x0000993F
		public MetroUserControl()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
			base.BorderStyle = System.Windows.Forms.BorderStyle.None;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0000B75C File Offset: 0x0000995C
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
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000B860 File Offset: 0x00009A60
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			base.Invalidate();
		}

		// Token: 0x040000E5 RID: 229
		private bool useCustomBackground;

		// Token: 0x040000E6 RID: 230
		private MetroBorderStyle _borderStyle;
	}
}
