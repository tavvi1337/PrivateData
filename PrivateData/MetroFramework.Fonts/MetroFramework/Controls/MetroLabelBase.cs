using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Interfaces;

namespace MetroFramework.Controls
{
	// Token: 0x02000022 RID: 34
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public abstract class MetroLabelBase : Label, IMetroControl, IMetroComponent, IDisposable, IMetroStyledComponent
	{
		// Token: 0x06000134 RID: 308 RVA: 0x000053F9 File Offset: 0x000035F9
		protected MetroLabelBase()
		{
			this._styleManager = new MetroStyleManager();
			this._styleManager.MetroStyleChanged += this.OnMetroStyleChanged;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00005423 File Offset: 0x00003623
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._styleManager.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000136 RID: 310 RVA: 0x0000543A File Offset: 0x0000363A
		// (set) Token: 0x06000137 RID: 311 RVA: 0x00005442 File Offset: 0x00003642
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

		// Token: 0x06000138 RID: 312 RVA: 0x00005450 File Offset: 0x00003650
		private void OnMetroStyleChanged(object sender, EventArgs e)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MethodInvoker(base.Invalidate));
				return;
			}
			base.Invalidate();
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00005474 File Offset: 0x00003674
		// (set) Token: 0x0600013A RID: 314 RVA: 0x0000547C File Offset: 0x0000367C
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

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600013B RID: 315 RVA: 0x0000549E File Offset: 0x0000369E
		// (set) Token: 0x0600013C RID: 316 RVA: 0x000054AB File Offset: 0x000036AB
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

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600013D RID: 317 RVA: 0x000054B9 File Offset: 0x000036B9
		// (set) Token: 0x0600013E RID: 318 RVA: 0x000054C6 File Offset: 0x000036C6
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

		// Token: 0x0400004D RID: 77
		private readonly MetroStyleManager _styleManager;
	}
}
