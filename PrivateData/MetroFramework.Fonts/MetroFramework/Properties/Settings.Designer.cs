using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace MetroFramework.Properties
{
	// Token: 0x02000090 RID: 144
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060004BB RID: 1211 RVA: 0x0000F58E File Offset: 0x0000D78E
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x040002CC RID: 716
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
