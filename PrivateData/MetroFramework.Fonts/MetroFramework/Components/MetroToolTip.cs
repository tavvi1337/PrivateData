using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;

namespace MetroFramework.Components
{
	// Token: 0x02000017 RID: 23
	[ToolboxItemFilter("System.Windows.Forms")]
	[ToolboxBitmap(typeof(ToolTip))]
	public class MetroToolTip : MetroToolTipBase
	{
		// Token: 0x060000A1 RID: 161 RVA: 0x00003F54 File Offset: 0x00002154
		protected override void OnMetroStyleChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x00003F56 File Offset: 0x00002156
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x00003F5E File Offset: 0x0000215E
		[Browsable(false)]
		[DefaultValue(true)]
		public new bool ShowAlways
		{
			get
			{
				return base.ShowAlways;
			}
			set
			{
				base.ShowAlways = true;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00003F67 File Offset: 0x00002167
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x00003F6F File Offset: 0x0000216F
		[Browsable(false)]
		[DefaultValue(true)]
		public new bool OwnerDraw
		{
			get
			{
				return base.OwnerDraw;
			}
			set
			{
				base.OwnerDraw = true;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x00003F78 File Offset: 0x00002178
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x00003F80 File Offset: 0x00002180
		[Browsable(false)]
		public new bool IsBalloon
		{
			get
			{
				return base.IsBalloon;
			}
			set
			{
				base.IsBalloon = false;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x00003F89 File Offset: 0x00002189
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x00003F91 File Offset: 0x00002191
		[Browsable(false)]
		public new Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00003F9A File Offset: 0x0000219A
		// (set) Token: 0x060000AB RID: 171 RVA: 0x00003FA2 File Offset: 0x000021A2
		[Browsable(false)]
		public new Color ForeColor
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

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00003FAB File Offset: 0x000021AB
		// (set) Token: 0x060000AD RID: 173 RVA: 0x00003FB3 File Offset: 0x000021B3
		[Browsable(false)]
		public new string ToolTipTitle
		{
			get
			{
				return base.ToolTipTitle;
			}
			set
			{
				base.ToolTipTitle = "";
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00003FC0 File Offset: 0x000021C0
		// (set) Token: 0x060000AF RID: 175 RVA: 0x00003FC8 File Offset: 0x000021C8
		[Browsable(false)]
		public new ToolTipIcon ToolTipIcon
		{
			get
			{
				return base.ToolTipIcon;
			}
			set
			{
				base.ToolTipIcon = ToolTipIcon.None;
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00003FD1 File Offset: 0x000021D1
		public MetroToolTip()
		{
			this.OwnerDraw = true;
			this.ShowAlways = true;
			base.Draw += this.MetroToolTip_Draw;
			base.Popup += this.MetroToolTip_Popup;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000400C File Offset: 0x0000220C
		public new void SetToolTip(Control control, string caption)
		{
			base.SetToolTip(control, caption);
			if (control is IMetroControl)
			{
				foreach (object obj in control.Controls)
				{
					Control control2 = (Control)obj;
					this.SetToolTip(control2, caption);
				}
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00004078 File Offset: 0x00002278
		private void MetroToolTip_Popup(object sender, PopupEventArgs e)
		{
			IMetroContainerControl metroContainerControl = e.AssociatedWindow as IMetroContainerControl;
			if (metroContainerControl != null && metroContainerControl.StyleManager == null)
			{
				((IMetroStyledComponent)this).InternalStyleManager = metroContainerControl.InternalStyleManager;
			}
			e.ToolTipSize = new Size(e.ToolTipSize.Width + 24, e.ToolTipSize.Height + 9);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000040D8 File Offset: 0x000022D8
		private void MetroToolTip_Draw(object sender, DrawToolTipEventArgs e)
		{
			MetroThemeStyle theme = (base.Theme == MetroThemeStyle.Light) ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
			Color color = MetroPaint.BackColor.Form(theme);
			Color color2 = MetroPaint.BorderColor.Button.Normal(theme);
			Color foreColor = MetroPaint.ForeColor.Label.Normal(theme);
			using (SolidBrush solidBrush = new SolidBrush(color))
			{
				e.Graphics.FillRectangle(solidBrush, e.Bounds);
			}
			using (Pen pen = new Pen(color2))
			{
				e.Graphics.DrawRectangle(pen, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
			}
			Font font = MetroFonts.Default(13f);
			TextRenderer.DrawText(e.Graphics, e.ToolTipText, font, e.Bounds, foreColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
		}
	}
}
