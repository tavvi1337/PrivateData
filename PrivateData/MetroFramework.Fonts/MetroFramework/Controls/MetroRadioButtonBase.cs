using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Interfaces;

namespace MetroFramework.Controls
{
	// Token: 0x02000025 RID: 37
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public abstract class MetroRadioButtonBase : RadioButton, IMetroControl, IMetroComponent, IDisposable, IMetroStyledComponent
	{
		// Token: 0x06000155 RID: 341 RVA: 0x0000568C File Offset: 0x0000388C
		protected MetroRadioButtonBase()
		{
			this._styleManager = new MetroStyleManager();
			this._styleManager.MetroStyleChanged += this.OnMetroStyleChanged;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000056B6 File Offset: 0x000038B6
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._styleManager.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000157 RID: 343 RVA: 0x000056CD File Offset: 0x000038CD
		// (set) Token: 0x06000158 RID: 344 RVA: 0x000056D5 File Offset: 0x000038D5
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

		// Token: 0x06000159 RID: 345 RVA: 0x000056E3 File Offset: 0x000038E3
		private void OnMetroStyleChanged(object sender, EventArgs e)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MethodInvoker(base.Invalidate));
				return;
			}
			base.Invalidate();
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600015A RID: 346 RVA: 0x00005707 File Offset: 0x00003907
		// (set) Token: 0x0600015B RID: 347 RVA: 0x00005710 File Offset: 0x00003910
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

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600015C RID: 348 RVA: 0x00005732 File Offset: 0x00003932
		// (set) Token: 0x0600015D RID: 349 RVA: 0x0000573F File Offset: 0x0000393F
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

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600015E RID: 350 RVA: 0x0000574D File Offset: 0x0000394D
		// (set) Token: 0x0600015F RID: 351 RVA: 0x0000575A File Offset: 0x0000395A
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

		// Token: 0x04000050 RID: 80
		private readonly MetroStyleManager _styleManager;
	}
}
