using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace MetroFramework.Controls
{
	// Token: 0x02000033 RID: 51
	[Editor("MetroFramework.Design.MetroTabPageCollectionEditor, MetroFramework.Design, Version=1.2.0.3, Culture=neutral, PublicKeyToken=5f91a84759bf584a", typeof(UITypeEditor))]
	[ToolboxItem(false)]
	public class MetroTabPageCollection : TabControl.TabPageCollection
	{
		// Token: 0x0600025B RID: 603 RVA: 0x00008A7D File Offset: 0x00006C7D
		public MetroTabPageCollection(MetroTabControl owner) : base(owner)
		{
		}
	}
}
