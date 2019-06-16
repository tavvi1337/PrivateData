using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Interfaces;

namespace MetroFramework.Controls
{
	// Token: 0x02000026 RID: 38
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public abstract class MetroTabControlBase : TabControl, IMetroControl, IMetroComponent, IDisposable, IMetroStyledComponent
	{
		// Token: 0x06000160 RID: 352 RVA: 0x00005768 File Offset: 0x00003968
		protected MetroTabControlBase()
		{
			this._styleManager = new MetroStyleManager();
			this._styleManager.MetroStyleChanged += this.OnMetroStyleChanged;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00005792 File Offset: 0x00003992
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._styleManager.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000162 RID: 354 RVA: 0x000057A9 File Offset: 0x000039A9
		// (set) Token: 0x06000163 RID: 355 RVA: 0x000057B1 File Offset: 0x000039B1
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

		// Token: 0x06000164 RID: 356 RVA: 0x000057BF File Offset: 0x000039BF
		private void OnMetroStyleChanged(object sender, EventArgs e)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MethodInvoker(base.Invalidate));
				return;
			}
			base.Invalidate();
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000165 RID: 357 RVA: 0x000057E3 File Offset: 0x000039E3
		// (set) Token: 0x06000166 RID: 358 RVA: 0x000057EC File Offset: 0x000039EC
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

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000167 RID: 359 RVA: 0x0000580E File Offset: 0x00003A0E
		// (set) Token: 0x06000168 RID: 360 RVA: 0x0000581B File Offset: 0x00003A1B
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

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000169 RID: 361 RVA: 0x00005829 File Offset: 0x00003A29
		// (set) Token: 0x0600016A RID: 362 RVA: 0x00005836 File Offset: 0x00003A36
		[DefaultValue(MetroColorStyle.Default)]
		[AmbientValue(MetroColorStyle.Default)]
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

		// Token: 0x04000051 RID: 81
		private readonly MetroStyleManager _styleManager;
	}
}
