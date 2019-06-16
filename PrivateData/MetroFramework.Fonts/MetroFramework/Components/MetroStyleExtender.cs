using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;

namespace MetroFramework.Components
{
	// Token: 0x02000015 RID: 21
	[ProvideProperty("ApplyMetroTheme", typeof(Control))]
	public sealed class MetroStyleExtender : Component, IExtenderProvider, IMetroComponent, IDisposable, IMetroStyledComponent
	{
		// Token: 0x06000080 RID: 128 RVA: 0x00003790 File Offset: 0x00001990
		public MetroStyleExtender()
		{
			this._styleManager = new MetroStyleManager();
			this._styleManager.MetroStyleChanged += this.OnMetroStyleChanged;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000037C5 File Offset: 0x000019C5
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._styleManager.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000082 RID: 130 RVA: 0x000037DC File Offset: 0x000019DC
		// (set) Token: 0x06000083 RID: 131 RVA: 0x000037E4 File Offset: 0x000019E4
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

		// Token: 0x06000084 RID: 132 RVA: 0x000037F2 File Offset: 0x000019F2
		private void OnMetroStyleChanged(object sender, EventArgs e)
		{
			this.UpdateTheme();
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000085 RID: 133 RVA: 0x000037FA File Offset: 0x000019FA
		// (set) Token: 0x06000086 RID: 134 RVA: 0x00003804 File Offset: 0x00001A04
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

		// Token: 0x06000087 RID: 135 RVA: 0x00003826 File Offset: 0x00001A26
		public MetroStyleExtender(IContainer parent) : this()
		{
			if (parent != null)
			{
				parent.Add(this);
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00003838 File Offset: 0x00001A38
		private void UpdateTheme()
		{
			if (this._extendedControls.Count == 0)
			{
				return;
			}
			Control control = this._extendedControls[0];
			if (control.InvokeRequired)
			{
				control.Invoke(new MethodInvoker(this.UpdateTheme));
				return;
			}
			Color color = MetroPaint.BackColor.Form(this._styleManager.Theme);
			Color color2 = MetroPaint.ForeColor.Label.Normal(this._styleManager.Theme);
			foreach (Control control2 in this._extendedControls)
			{
				try
				{
					if (control2.BackColor != color)
					{
						control2.BackColor = color;
					}
				}
				catch
				{
				}
				try
				{
					if (control2.ForeColor != color2)
					{
						control2.ForeColor = color2;
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000392C File Offset: 0x00001B2C
		private void UpdateTheme(Control ctrl)
		{
			Color color = MetroPaint.BackColor.Form(this._styleManager.Theme);
			Color color2 = MetroPaint.ForeColor.Label.Normal(this._styleManager.Theme);
			try
			{
				if (ctrl.BackColor != color)
				{
					ctrl.BackColor = color;
				}
			}
			catch
			{
			}
			try
			{
				if (ctrl.ForeColor != color2)
				{
					ctrl.ForeColor = color2;
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000039AC File Offset: 0x00001BAC
		bool IExtenderProvider.CanExtend(object target)
		{
			return target is Control && !(target is IMetroControl) && !(target is IMetroForm);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000039CE File Offset: 0x00001BCE
		[DefaultValue(false)]
		[Category("Metro Appearance")]
		[Description("Apply Metro Theme BackColor and ForeColor.")]
		public bool GetApplyMetroTheme(Control control)
		{
			return control != null && this._extendedControls.Contains(control);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000039E1 File Offset: 0x00001BE1
		public void SetApplyMetroTheme(Control control, bool value)
		{
			if (control == null)
			{
				return;
			}
			if (this._extendedControls.Contains(control))
			{
				if (!value)
				{
					this._extendedControls.Remove(control);
					return;
				}
			}
			else if (value)
			{
				this._extendedControls.Add(control);
				this.UpdateTheme(control);
			}
		}

		// Token: 0x0400002A RID: 42
		private MetroStyleManager _styleManager;

		// Token: 0x0400002B RID: 43
		private readonly List<Control> _extendedControls = new List<Control>();
	}
}
