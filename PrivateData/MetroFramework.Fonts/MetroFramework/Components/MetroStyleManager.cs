using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Interfaces;

namespace MetroFramework.Components
{
	// Token: 0x02000016 RID: 22
	[Designer("MetroFramework.Design.MetroStyleManagerDesigner, MetroFramework.Design, Version=1.2.0.3, Culture=neutral, PublicKeyToken=5f91a84759bf584a")]
	public sealed class MetroStyleManager : Component, ISupportInitialize, IMetroComponent, IDisposable, IMetroStyledComponent
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600008D RID: 141 RVA: 0x00003A1C File Offset: 0x00001C1C
		// (set) Token: 0x0600008E RID: 142 RVA: 0x00003A44 File Offset: 0x00001C44
		[Category("Metro Appearance")]
		[DefaultValue(MetroColorStyle.Default)]
		public MetroColorStyle Style
		{
			get
			{
				if (!base.DesignMode && this._metroStyle == MetroColorStyle.Default)
				{
					return this._styleManager.Style;
				}
				return this._metroStyle;
			}
			set
			{
				if (this._styleManager == null && value == MetroColorStyle.Default)
				{
					value = MetroColorStyle.Blue;
				}
				bool flag = this.Style != value;
				this._metroStyle = value;
				if (flag)
				{
					this.OnMetroStyleChanged(this, new EventArgs());
				}
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00003A83 File Offset: 0x00001C83
		// (set) Token: 0x06000090 RID: 144 RVA: 0x00003AA8 File Offset: 0x00001CA8
		[Category("Metro Appearance")]
		[DefaultValue(MetroThemeStyle.Default)]
		public MetroThemeStyle Theme
		{
			get
			{
				if (!base.DesignMode && this._metroTheme == MetroThemeStyle.Default)
				{
					return this._styleManager.Theme;
				}
				return this._metroTheme;
			}
			set
			{
				if (this._styleManager == null && value == MetroThemeStyle.Default)
				{
					value = MetroThemeStyle.Light;
				}
				bool flag = this.Theme != value;
				this._metroTheme = value;
				if (flag)
				{
					this.OnMetroStyleChanged(this, new EventArgs());
				}
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00003AE7 File Offset: 0x00001CE7
		// (set) Token: 0x06000092 RID: 146 RVA: 0x00003AF0 File Offset: 0x00001CF0
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
				if (value == null)
				{
					throw new ArgumentNullException();
				}
				if (value == this)
				{
					throw new ArgumentException();
				}
				bool flag = value.Theme != this.Theme || value.Style != this.Style;
				if (this._styleManager != null)
				{
					this._styleManager.MetroStyleChanged -= this.OnMetroStyleChanged;
				}
				this._styleManager = value;
				this._styleManager.MetroStyleChanged += this.OnMetroStyleChanged;
				if (flag)
				{
					this.OnMetroStyleChanged(this, new EventArgs());
				}
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000093 RID: 147 RVA: 0x00003B80 File Offset: 0x00001D80
		// (remove) Token: 0x06000094 RID: 148 RVA: 0x00003BB8 File Offset: 0x00001DB8
		public event EventHandler MetroStyleChanged;

		// Token: 0x06000095 RID: 149 RVA: 0x00003BF0 File Offset: 0x00001DF0
		private void OnMetroStyleChanged(object sender, EventArgs e)
		{
			if (!this.isInitializing)
			{
				this.Update();
				EventHandler metroStyleChanged = this.MetroStyleChanged;
				if (metroStyleChanged != null)
				{
					metroStyleChanged(this, e);
				}
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003C20 File Offset: 0x00001E20
		public MetroStyleManager()
		{
			this._styleManager = MetroStyleManager.Default;
			if (this._styleManager != null)
			{
				this._styleManager.MetroStyleChanged += this.OnMetroStyleChanged;
				return;
			}
			this._metroTheme = MetroThemeStyle.Light;
			this._metroStyle = MetroColorStyle.Blue;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003C7A File Offset: 0x00001E7A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this._styleManager != null)
			{
				this._styleManager.MetroStyleChanged -= this.OnMetroStyleChanged;
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00003CA5 File Offset: 0x00001EA5
		public MetroStyleManager(IContainer parentContainer) : this()
		{
			if (parentContainer != null)
			{
				this._parentContainer = parentContainer;
				this._parentContainer.Add(this);
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003CC3 File Offset: 0x00001EC3
		void ISupportInitialize.BeginInit()
		{
			this.isInitializing = true;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00003CCC File Offset: 0x00001ECC
		void ISupportInitialize.EndInit()
		{
			this.isInitializing = false;
			this.Update();
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00003CDB File Offset: 0x00001EDB
		// (set) Token: 0x0600009C RID: 156 RVA: 0x00003CE4 File Offset: 0x00001EE4
		[ImmutableObject(true)]
		public IMetroContainerControl Owner
		{
			get
			{
				return this._owner;
			}
			set
			{
				if (this._owner != null)
				{
					if (this._owner.StyleManager == this)
					{
						this._owner.StyleManager = null;
					}
					ContainerControl containerControl = this._owner as ContainerControl;
					if (containerControl != null)
					{
						containerControl.ControlAdded -= this.ControlAdded;
					}
				}
				this._owner = value;
				if (value != null)
				{
					value.StyleManager = this;
					ContainerControl containerControl2 = this._owner as ContainerControl;
					if (containerControl2 != null)
					{
						containerControl2.ControlAdded += this.ControlAdded;
					}
					if (!this.isInitializing)
					{
						this.UpdateControl((Control)value);
					}
				}
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00003D7A File Offset: 0x00001F7A
		private void ControlAdded(object sender, ControlEventArgs e)
		{
			if (!this.isInitializing)
			{
				this.UpdateControl(e.Control);
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003D90 File Offset: 0x00001F90
		public void Update()
		{
			if (this._owner != null)
			{
				this.UpdateControl((Control)this._owner);
			}
			if (this._parentContainer == null || this._parentContainer.Components == null)
			{
				return;
			}
			foreach (object obj in this._parentContainer.Components)
			{
				if (!object.ReferenceEquals(obj, this))
				{
					IMetroStyledComponent metroStyledComponent = obj as IMetroStyledComponent;
					if (metroStyledComponent != null)
					{
						metroStyledComponent.InternalStyleManager = this;
					}
				}
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003E2C File Offset: 0x0000202C
		private void UpdateControl(Control control)
		{
			if (control == null)
			{
				return;
			}
			IMetroContainerControl metroContainerControl = control as IMetroContainerControl;
			if (metroContainerControl != null && metroContainerControl.StyleManager != null && !object.ReferenceEquals(this, metroContainerControl.StyleManager))
			{
				((IMetroStyledComponent)metroContainerControl.StyleManager).InternalStyleManager = this;
				return;
			}
			IMetroStyledComponent metroStyledComponent = control as IMetroStyledComponent;
			if (metroStyledComponent != null)
			{
				metroStyledComponent.InternalStyleManager = this;
			}
			if (control.ContextMenuStrip != null)
			{
				this.UpdateControl(control.ContextMenuStrip);
			}
			TabControl tabControl = control as TabControl;
			if (tabControl != null)
			{
				foreach (object obj in tabControl.TabPages)
				{
					TabPage control2 = (TabPage)obj;
					this.UpdateControl(control2);
				}
			}
			if (control.Controls != null)
			{
				foreach (object obj2 in control.Controls)
				{
					Control control3 = (Control)obj2;
					this.UpdateControl(control3);
				}
			}
		}

		// Token: 0x0400002C RID: 44
		internal const string STYLE_PROPERTY_NAME = "Style";

		// Token: 0x0400002D RID: 45
		internal const string THEME_PROPERTY_NAME = "Theme";

		// Token: 0x0400002E RID: 46
		public static readonly MetroStyleManager Default = new MetroStyleManager();

		// Token: 0x0400002F RID: 47
		private MetroColorStyle _metroStyle = MetroColorStyle.Default;

		// Token: 0x04000030 RID: 48
		private MetroThemeStyle _metroTheme = MetroThemeStyle.Default;

		// Token: 0x04000031 RID: 49
		private MetroStyleManager _styleManager;

		// Token: 0x04000033 RID: 51
		private readonly IContainer _parentContainer;

		// Token: 0x04000034 RID: 52
		private bool isInitializing;

		// Token: 0x04000035 RID: 53
		private IMetroContainerControl _owner;
	}
}
