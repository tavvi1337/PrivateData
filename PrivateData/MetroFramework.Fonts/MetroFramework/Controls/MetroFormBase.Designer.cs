namespace MetroFramework.Controls
{
	// Token: 0x02000021 RID: 33
	//[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
	public abstract partial class MetroFormBase : System.Windows.Forms.Form, MetroFramework.Interfaces.IMetroContainerControl, System.Windows.Forms.IContainerControl, MetroFramework.Interfaces.IMetroControl, MetroFramework.Interfaces.IMetroComponent, System.IDisposable, MetroFramework.Interfaces.IMetroStyledComponent
	{
		// Token: 0x06000128 RID: 296 RVA: 0x00005336 File Offset: 0x00003536
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._styleManager.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0400004B RID: 75
		private readonly MetroFramework.Components.MetroStyleManager _styleManager;
	}
}
