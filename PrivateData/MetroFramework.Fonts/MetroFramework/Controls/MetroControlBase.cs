using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Interfaces;

namespace MetroFramework.Controls
{
	// Token: 0x0200001F RID: 31
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public abstract class MetroControlBase : Control, IMetroControl, IMetroComponent, IDisposable, IMetroStyledComponent
	{
		// Token: 0x0600011A RID: 282 RVA: 0x00005230 File Offset: 0x00003430
		protected MetroControlBase()
		{
			this._styleManager = new MetroStyleManager();
			this._styleManager.MetroStyleChanged += this.OnMetroStyleChanged;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000525A File Offset: 0x0000345A
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._styleManager.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600011C RID: 284 RVA: 0x00005271 File Offset: 0x00003471
		// (set) Token: 0x0600011D RID: 285 RVA: 0x00005279 File Offset: 0x00003479
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

		// Token: 0x0600011E RID: 286 RVA: 0x00005287 File Offset: 0x00003487
		private void OnMetroStyleChanged(object sender, EventArgs e)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MethodInvoker(base.Invalidate));
				return;
			}
			base.Invalidate();
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600011F RID: 287 RVA: 0x000052AB File Offset: 0x000034AB
		// (set) Token: 0x06000120 RID: 288 RVA: 0x000052B4 File Offset: 0x000034B4
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

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000121 RID: 289 RVA: 0x000052D6 File Offset: 0x000034D6
		// (set) Token: 0x06000122 RID: 290 RVA: 0x000052E3 File Offset: 0x000034E3
		[Category("Metro Appearance")]
		[DefaultValue(MetroThemeStyle.Default)]
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

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000123 RID: 291 RVA: 0x000052F1 File Offset: 0x000034F1
		// (set) Token: 0x06000124 RID: 292 RVA: 0x000052FE File Offset: 0x000034FE
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

		// Token: 0x0400004A RID: 74
		private readonly MetroStyleManager _styleManager;
	}
}
