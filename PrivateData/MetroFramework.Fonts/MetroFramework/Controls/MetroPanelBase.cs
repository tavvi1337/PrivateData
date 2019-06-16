using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Interfaces;

namespace MetroFramework.Controls
{
	// Token: 0x02000023 RID: 35
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public abstract class MetroPanelBase : Panel, IMetroControl, IMetroComponent, IDisposable, IMetroStyledComponent
	{
		// Token: 0x0600013F RID: 319 RVA: 0x000054D4 File Offset: 0x000036D4
		protected MetroPanelBase()
		{
			this._styleManager = new MetroStyleManager();
			this._styleManager.MetroStyleChanged += this.OnMetroStyleChanged;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x000054FE File Offset: 0x000036FE
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._styleManager.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000141 RID: 321 RVA: 0x00005515 File Offset: 0x00003715
		// (set) Token: 0x06000142 RID: 322 RVA: 0x0000551D File Offset: 0x0000371D
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

		// Token: 0x06000143 RID: 323 RVA: 0x0000552B File Offset: 0x0000372B
		private void OnMetroStyleChanged(object sender, EventArgs e)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MethodInvoker(base.Invalidate));
				return;
			}
			base.Invalidate();
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000144 RID: 324 RVA: 0x0000554F File Offset: 0x0000374F
		// (set) Token: 0x06000145 RID: 325 RVA: 0x00005558 File Offset: 0x00003758
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

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000146 RID: 326 RVA: 0x0000557A File Offset: 0x0000377A
		// (set) Token: 0x06000147 RID: 327 RVA: 0x00005587 File Offset: 0x00003787
		[DefaultValue(MetroThemeStyle.Default)]
		[Category("Metro Appearance")]
		[AmbientValue(MetroThemeStyle.Default)]
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

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000148 RID: 328 RVA: 0x00005595 File Offset: 0x00003795
		// (set) Token: 0x06000149 RID: 329 RVA: 0x000055A2 File Offset: 0x000037A2
		[AmbientValue(MetroColorStyle.Default)]
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

		// Token: 0x0400004E RID: 78
		private readonly MetroStyleManager _styleManager;
	}
}
