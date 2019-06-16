using System;
using System.Windows.Forms;
using MetroFramework.Components;

namespace MetroFramework.Interfaces
{
	// Token: 0x02000020 RID: 32
	public interface IMetroContainerControl : IContainerControl, IMetroStyledComponent, IMetroControl, IMetroComponent, IDisposable
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000125 RID: 293
		// (set) Token: 0x06000126 RID: 294
		MetroStyleManager StyleManager { get; set; }
	}
}
