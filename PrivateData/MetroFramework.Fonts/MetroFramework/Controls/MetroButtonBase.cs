using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Interfaces;

namespace MetroFramework.Controls
{
	// Token: 0x02000019 RID: 25
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public abstract class MetroButtonBase : Button, IMetroControl, IMetroComponent, IDisposable, IMetroStyledComponent
	{
		// Token: 0x060000B4 RID: 180 RVA: 0x000041DC File Offset: 0x000023DC
		protected MetroButtonBase()
		{
			this._styleManager = new MetroStyleManager();
			this._styleManager.MetroStyleChanged += this.OnMetroStyleChanged;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00004206 File Offset: 0x00002406
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._styleManager.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x0000421D File Offset: 0x0000241D
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x00004225 File Offset: 0x00002425
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

		// Token: 0x060000B8 RID: 184 RVA: 0x00004233 File Offset: 0x00002433
		private void OnMetroStyleChanged(object sender, EventArgs e)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MethodInvoker(base.Invalidate));
				return;
			}
			base.Invalidate();
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00004257 File Offset: 0x00002457
		// (set) Token: 0x060000BA RID: 186 RVA: 0x00004260 File Offset: 0x00002460
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

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00004282 File Offset: 0x00002482
		// (set) Token: 0x060000BC RID: 188 RVA: 0x0000428F File Offset: 0x0000248F
		[DefaultValue(MetroThemeStyle.Default)]
		[AmbientValue(MetroThemeStyle.Default)]
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

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000BD RID: 189 RVA: 0x0000429D File Offset: 0x0000249D
		// (set) Token: 0x060000BE RID: 190 RVA: 0x000042AA File Offset: 0x000024AA
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

		// Token: 0x04000036 RID: 54
		private readonly MetroStyleManager _styleManager;
	}
}
