namespace MetroFramework.Forms
{
	// Token: 0x02000058 RID: 88
	public partial class MetroForm : global::MetroFramework.Controls.MetroFormBase, global::MetroFramework.Interfaces.IMetroForm, global::MetroFramework.Interfaces.IMetroContainerControl, global::System.Windows.Forms.IContainerControl, global::MetroFramework.Interfaces.IMetroControl, global::MetroFramework.Interfaces.IMetroComponent, global::System.IDisposable, global::MetroFramework.Interfaces.IMetroStyledComponent
	{
		// Token: 0x060003C5 RID: 965 RVA: 0x0000C858 File Offset: 0x0000AA58
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.RemoveShadow();
			}
			base.Dispose(disposing);
		}
	}
}
