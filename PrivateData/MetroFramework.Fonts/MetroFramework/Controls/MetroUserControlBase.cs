using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Interfaces;

namespace MetroFramework.Controls
{
	// Token: 0x02000028 RID: 40
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public abstract class MetroUserControlBase : UserControl, IMetroContainerControl, IContainerControl, IMetroControl, IMetroComponent, IDisposable, IMetroStyledComponent
	{
		// Token: 0x06000176 RID: 374 RVA: 0x00005920 File Offset: 0x00003B20
		protected MetroUserControlBase()
		{
			this._styleManager = new MetroStyleManager();
			this._styleManager.MetroStyleChanged += this.OnMetroStyleChanged;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000594A File Offset: 0x00003B4A
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._styleManager.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000178 RID: 376 RVA: 0x00005961 File Offset: 0x00003B61
		// (set) Token: 0x06000179 RID: 377 RVA: 0x00005969 File Offset: 0x00003B69
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

		// Token: 0x0600017A RID: 378 RVA: 0x00005977 File Offset: 0x00003B77
		private void OnMetroStyleChanged(object sender, EventArgs e)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MethodInvoker(base.Invalidate));
				return;
			}
			base.Invalidate();
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600017B RID: 379 RVA: 0x0000599B File Offset: 0x00003B9B
		// (set) Token: 0x0600017C RID: 380 RVA: 0x000059A4 File Offset: 0x00003BA4
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

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600017D RID: 381 RVA: 0x000059C6 File Offset: 0x00003BC6
		// (set) Token: 0x0600017E RID: 382 RVA: 0x000059D3 File Offset: 0x00003BD3
		[Category("Metro Appearance")]
		[AmbientValue(MetroThemeStyle.Default)]
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

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600017F RID: 383 RVA: 0x000059E1 File Offset: 0x00003BE1
		// (set) Token: 0x06000180 RID: 384 RVA: 0x000059EE File Offset: 0x00003BEE
		[Category("Metro Appearance")]
		[DefaultValue(MetroColorStyle.Default)]
		[AmbientValue(MetroColorStyle.Default)]
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

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000181 RID: 385 RVA: 0x000059FC File Offset: 0x00003BFC
		// (set) Token: 0x06000182 RID: 386 RVA: 0x00005A04 File Offset: 0x00003C04
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public MetroStyleManager StyleManager { get; set; }

		// Token: 0x04000053 RID: 83
		private readonly MetroStyleManager _styleManager;
	}
}
