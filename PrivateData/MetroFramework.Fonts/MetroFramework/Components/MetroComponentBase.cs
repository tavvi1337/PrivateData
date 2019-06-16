using System;
using System.ComponentModel;
using MetroFramework.Interfaces;

namespace MetroFramework.Components
{
	// Token: 0x02000013 RID: 19
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public abstract class MetroComponentBase : Component, IMetroComponent, IDisposable, IMetroStyledComponent
	{
		// Token: 0x0600006A RID: 106 RVA: 0x00003620 File Offset: 0x00001820
		protected MetroComponentBase()
		{
			this._styleManager = new MetroStyleManager();
			this._styleManager.MetroStyleChanged += this.OnMetroStyleChanged;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000364B File Offset: 0x0000184B
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._styleManager.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00003662 File Offset: 0x00001862
		// (set) Token: 0x0600006D RID: 109 RVA: 0x0000366A File Offset: 0x0000186A
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

		// Token: 0x0600006E RID: 110
		protected abstract void OnMetroStyleChanged(object sender, EventArgs e);

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00003678 File Offset: 0x00001878
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00003680 File Offset: 0x00001880
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

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000071 RID: 113 RVA: 0x000036A2 File Offset: 0x000018A2
		// (set) Token: 0x06000072 RID: 114 RVA: 0x000036AF File Offset: 0x000018AF
		[Category("Metro Appearance")]
		[DefaultValue(MetroThemeStyle.Default)]
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

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000073 RID: 115 RVA: 0x000036BD File Offset: 0x000018BD
		// (set) Token: 0x06000074 RID: 116 RVA: 0x000036CA File Offset: 0x000018CA
		[DefaultValue(MetroColorStyle.Default)]
		[Category("Metro Appearance")]
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

		// Token: 0x04000028 RID: 40
		private readonly MetroStyleManager _styleManager;
	}
}
