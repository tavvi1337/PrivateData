using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace MetroFramework.Properties
{
	// Token: 0x0200008F RID: 143
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x060004B7 RID: 1207 RVA: 0x0000F537 File Offset: 0x0000D737
		internal Resources()
		{
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x0000F540 File Offset: 0x0000D740
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("MetroFramework.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060004B9 RID: 1209 RVA: 0x0000F57F File Offset: 0x0000D77F
		// (set) Token: 0x060004BA RID: 1210 RVA: 0x0000F586 File Offset: 0x0000D786
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x040002CA RID: 714
		private static ResourceManager resourceMan;

		// Token: 0x040002CB RID: 715
		private static CultureInfo resourceCulture;
	}
}
