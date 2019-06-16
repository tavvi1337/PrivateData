using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Interfaces;

namespace MetroFramework.Controls
{
	// Token: 0x02000027 RID: 39
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public abstract class MetroTabPageBase : TabPage, IMetroControl, IMetroComponent, IDisposable, IMetroStyledComponent
	{
		// Token: 0x0600016B RID: 363 RVA: 0x00005844 File Offset: 0x00003A44
		protected MetroTabPageBase()
		{
			this._styleManager = new MetroStyleManager();
			this._styleManager.MetroStyleChanged += this.OnMetroStyleChanged;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000586E File Offset: 0x00003A6E
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._styleManager.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600016D RID: 365 RVA: 0x00005885 File Offset: 0x00003A85
		// (set) Token: 0x0600016E RID: 366 RVA: 0x0000588D File Offset: 0x00003A8D
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

		// Token: 0x0600016F RID: 367 RVA: 0x0000589B File Offset: 0x00003A9B
		private void OnMetroStyleChanged(object sender, EventArgs e)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MethodInvoker(base.Invalidate));
				return;
			}
			base.Invalidate();
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000170 RID: 368 RVA: 0x000058BF File Offset: 0x00003ABF
		// (set) Token: 0x06000171 RID: 369 RVA: 0x000058C8 File Offset: 0x00003AC8
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

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000172 RID: 370 RVA: 0x000058EA File Offset: 0x00003AEA
		// (set) Token: 0x06000173 RID: 371 RVA: 0x000058F7 File Offset: 0x00003AF7
		[AmbientValue(MetroThemeStyle.Default)]
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

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000174 RID: 372 RVA: 0x00005905 File Offset: 0x00003B05
		// (set) Token: 0x06000175 RID: 373 RVA: 0x00005912 File Offset: 0x00003B12
		[Category("Metro Appearance")]
		[AmbientValue(MetroColorStyle.Default)]
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

		// Token: 0x04000052 RID: 82
		private readonly MetroStyleManager _styleManager;
	}
}
