using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Interfaces;

namespace MetroFramework.Components
{
	// Token: 0x02000014 RID: 20
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public abstract class MetroToolTipBase : ToolTip, IMetroComponent, IDisposable, IMetroStyledComponent
	{
		// Token: 0x06000075 RID: 117 RVA: 0x000036D8 File Offset: 0x000018D8
		protected MetroToolTipBase()
		{
			this._styleManager = new MetroStyleManager();
			this._styleManager.MetroStyleChanged += this.OnMetroStyleChanged;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003703 File Offset: 0x00001903
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._styleManager.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000077 RID: 119 RVA: 0x0000371A File Offset: 0x0000191A
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00003722 File Offset: 0x00001922
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		MetroStyleManager IMetroStyledComponent.InternalStyleManager
		{
			get
			{
				return this._styleManager;
			}
			set
			{
				((IMetroStyledComponent)this._styleManager).InternalStyleManager = value;
			}
		}

		// Token: 0x06000079 RID: 121
		protected abstract void OnMetroStyleChanged(object sender, EventArgs e);

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00003730 File Offset: 0x00001930
		// (set) Token: 0x0600007B RID: 123 RVA: 0x00003738 File Offset: 0x00001938
		public override ISite Site
		{
			get
			{
				return base.Site;
			}
			set
			{
				this._styleManager.Site = value;
				base.Site = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600007C RID: 124 RVA: 0x0000375A File Offset: 0x0000195A
		// (set) Token: 0x0600007D RID: 125 RVA: 0x00003767 File Offset: 0x00001967
		[DefaultValue(MetroThemeStyle.Default)]
		[Category("Metro Appearance")]
		public MetroThemeStyle Theme
		{
			get
			{
				return this._styleManager.Theme;
			}
			set
			{
				this._styleManager.Theme = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00003775 File Offset: 0x00001975
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00003782 File Offset: 0x00001982
		[Category("Metro Appearance")]
		[DefaultValue(MetroColorStyle.Default)]
		public MetroColorStyle Style
		{
			get
			{
				return this._styleManager.Style;
			}
			set
			{
				this._styleManager.Style = value;
			}
		}

		// Token: 0x04000029 RID: 41
		private readonly MetroStyleManager _styleManager;
	}
}
