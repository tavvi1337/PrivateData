using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Interfaces;

namespace MetroFramework.Controls
{
	// Token: 0x02000021 RID: 33
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public abstract partial class MetroFormBase : Form, IMetroContainerControl, IContainerControl, IMetroControl, IMetroComponent, IDisposable, IMetroStyledComponent
	{
		// Token: 0x06000127 RID: 295 RVA: 0x0000530C File Offset: 0x0000350C
		protected MetroFormBase()
		{
			this._styleManager = new MetroStyleManager();
			this._styleManager.MetroStyleChanged += this.OnMetroStyleChanged;
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000129 RID: 297 RVA: 0x0000534D File Offset: 0x0000354D
		// (set) Token: 0x0600012A RID: 298 RVA: 0x00005355 File Offset: 0x00003555
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

		// Token: 0x0600012B RID: 299 RVA: 0x00005363 File Offset: 0x00003563
		private void OnMetroStyleChanged(object sender, EventArgs e)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MethodInvoker(base.Invalidate));
				return;
			}
			base.Invalidate();
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600012C RID: 300 RVA: 0x00005387 File Offset: 0x00003587
		// (set) Token: 0x0600012D RID: 301 RVA: 0x00005390 File Offset: 0x00003590
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

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600012E RID: 302 RVA: 0x000053B2 File Offset: 0x000035B2
		// (set) Token: 0x0600012F RID: 303 RVA: 0x000053BF File Offset: 0x000035BF
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

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000130 RID: 304 RVA: 0x000053CD File Offset: 0x000035CD
		// (set) Token: 0x06000131 RID: 305 RVA: 0x000053DA File Offset: 0x000035DA
		[DefaultValue(MetroColorStyle.Default)]
		[Category("Metro Appearance")]
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

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000132 RID: 306 RVA: 0x000053E8 File Offset: 0x000035E8
		// (set) Token: 0x06000133 RID: 307 RVA: 0x000053F0 File Offset: 0x000035F0
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public MetroStyleManager StyleManager { get; set; }
	}
}
