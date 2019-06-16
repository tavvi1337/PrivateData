using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Interfaces;

namespace MetroFramework.Controls
{
	// Token: 0x0200001B RID: 27
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public abstract class MetroCheckBoxBase : CheckBox, IMetroControl, IMetroComponent, IDisposable, IMetroStyledComponent
	{
		// Token: 0x060000CE RID: 206 RVA: 0x00004604 File Offset: 0x00002804
		protected MetroCheckBoxBase()
		{
			this._styleManager = new MetroStyleManager();
			this._styleManager.MetroStyleChanged += this.OnMetroStyleChanged;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000462E File Offset: 0x0000282E
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._styleManager.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x00004645 File Offset: 0x00002845
		// (set) Token: 0x060000D1 RID: 209 RVA: 0x0000464D File Offset: 0x0000284D
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

		// Token: 0x060000D2 RID: 210 RVA: 0x0000465B File Offset: 0x0000285B
		private void OnMetroStyleChanged(object sender, EventArgs e)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MethodInvoker(base.Invalidate));
				return;
			}
			base.Invalidate();
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x0000467F File Offset: 0x0000287F
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x00004688 File Offset: 0x00002888
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

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x000046AA File Offset: 0x000028AA
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x000046B7 File Offset: 0x000028B7
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

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x000046C5 File Offset: 0x000028C5
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x000046D2 File Offset: 0x000028D2
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

		// Token: 0x0400003B RID: 59
		private readonly MetroStyleManager _styleManager;
	}
}
