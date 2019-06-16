using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Interfaces;

namespace MetroFramework.Controls
{
	// Token: 0x0200001D RID: 29
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public abstract class MetroComboBoxBase : ComboBox, IMetroControl, IMetroComponent, IDisposable, IMetroStyledComponent
	{
		// Token: 0x060000F4 RID: 244 RVA: 0x00004B98 File Offset: 0x00002D98
		protected MetroComboBoxBase()
		{
			this._styleManager = new MetroStyleManager();
			this._styleManager.MetroStyleChanged += this.OnMetroStyleChanged;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00004BC2 File Offset: 0x00002DC2
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._styleManager.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x00004BD9 File Offset: 0x00002DD9
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x00004BE1 File Offset: 0x00002DE1
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

		// Token: 0x060000F8 RID: 248 RVA: 0x00004BEF File Offset: 0x00002DEF
		private void OnMetroStyleChanged(object sender, EventArgs e)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MethodInvoker(base.Invalidate));
				return;
			}
			base.Invalidate();
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x00004C13 File Offset: 0x00002E13
		// (set) Token: 0x060000FA RID: 250 RVA: 0x00004C1C File Offset: 0x00002E1C
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

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000FB RID: 251 RVA: 0x00004C3E File Offset: 0x00002E3E
		// (set) Token: 0x060000FC RID: 252 RVA: 0x00004C4B File Offset: 0x00002E4B
		[AmbientValue(MetroThemeStyle.Default)]
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

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000FD RID: 253 RVA: 0x00004C59 File Offset: 0x00002E59
		// (set) Token: 0x060000FE RID: 254 RVA: 0x00004C66 File Offset: 0x00002E66
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

		// Token: 0x04000044 RID: 68
		private readonly MetroStyleManager _styleManager;
	}
}
