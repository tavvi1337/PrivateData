using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Interfaces;

namespace MetroFramework.Controls
{
	// Token: 0x02000024 RID: 36
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public abstract class MetroProgressBarBase : ProgressBar, IMetroControl, IMetroComponent, IDisposable, IMetroStyledComponent
	{
		// Token: 0x0600014A RID: 330 RVA: 0x000055B0 File Offset: 0x000037B0
		protected MetroProgressBarBase()
		{
			this._styleManager = new MetroStyleManager();
			this._styleManager.MetroStyleChanged += this.OnMetroStyleChanged;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x000055DA File Offset: 0x000037DA
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._styleManager.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600014C RID: 332 RVA: 0x000055F1 File Offset: 0x000037F1
		// (set) Token: 0x0600014D RID: 333 RVA: 0x000055F9 File Offset: 0x000037F9
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

		// Token: 0x0600014E RID: 334 RVA: 0x00005607 File Offset: 0x00003807
		private void OnMetroStyleChanged(object sender, EventArgs e)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MethodInvoker(base.Invalidate));
				return;
			}
			base.Invalidate();
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600014F RID: 335 RVA: 0x0000562B File Offset: 0x0000382B
		// (set) Token: 0x06000150 RID: 336 RVA: 0x00005634 File Offset: 0x00003834
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

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000151 RID: 337 RVA: 0x00005656 File Offset: 0x00003856
		// (set) Token: 0x06000152 RID: 338 RVA: 0x00005663 File Offset: 0x00003863
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

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000153 RID: 339 RVA: 0x00005671 File Offset: 0x00003871
		// (set) Token: 0x06000154 RID: 340 RVA: 0x0000567E File Offset: 0x0000387E
		[Category("Metro Appearance")]
		[DefaultValue(MetroColorStyle.Default)]
		[AmbientValue(MetroColorStyle.Default)]
		public new MetroColorStyle Style
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

		// Token: 0x0400004F RID: 79
		private readonly MetroStyleManager _styleManager;
	}
}
