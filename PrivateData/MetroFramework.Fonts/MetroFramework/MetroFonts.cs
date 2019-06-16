using System;
using System.Drawing;

namespace MetroFramework
{
	// Token: 0x02000073 RID: 115
	public static class MetroFonts
	{
		// Token: 0x06000445 RID: 1093 RVA: 0x0000EB30 File Offset: 0x0000CD30
		static MetroFonts()
		{
			try
			{
				Type type = Type.GetType("MetroFramework.Fonts.FontResolver, MetroFramework.Fonts, Version=1.2.0.3, Culture=neutral, PublicKeyToken=5f91a84759bf584a");
				if (type != null)
				{
					MetroFonts.FontResolver = (MetroFonts.IMetroFontResolver)Activator.CreateInstance(type);
					if (MetroFonts.FontResolver != null)
					{
						return;
					}
				}
			}
			catch (Exception)
			{
			}
			MetroFonts.FontResolver = new MetroFonts.DefaultFontResolver();
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x0000EB8C File Offset: 0x0000CD8C
		public static Font DefaultLight(float size)
		{
			return MetroFonts.FontResolver.ResolveFont("Segoe UI Light", size, FontStyle.Regular, GraphicsUnit.Pixel);
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0000EBA0 File Offset: 0x0000CDA0
		public static Font Default(float size)
		{
			return MetroFonts.FontResolver.ResolveFont("Segoe UI", size, FontStyle.Regular, GraphicsUnit.Pixel);
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0000EBB4 File Offset: 0x0000CDB4
		public static Font DefaultBold(float size)
		{
			return MetroFonts.FontResolver.ResolveFont("Segoe UI", size, FontStyle.Bold, GraphicsUnit.Pixel);
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x0000EBC8 File Offset: 0x0000CDC8
		public static Font Title
		{
			get
			{
				return MetroFonts.DefaultLight(24f);
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600044A RID: 1098 RVA: 0x0000EBD4 File Offset: 0x0000CDD4
		public static Font Subtitle
		{
			get
			{
				return MetroFonts.Default(14f);
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x0000EBE0 File Offset: 0x0000CDE0
		public static Font Button
		{
			get
			{
				return MetroFonts.DefaultBold(11f);
			}
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x0000EBEC File Offset: 0x0000CDEC
		public static Font Tile(MetroTileTextSize labelSize, MetroTileTextWeight labelWeight)
		{
			if (labelSize == MetroTileTextSize.Small)
			{
				if (labelWeight == MetroTileTextWeight.Light)
				{
					return MetroFonts.DefaultLight(12f);
				}
				if (labelWeight == MetroTileTextWeight.Regular)
				{
					return MetroFonts.Default(12f);
				}
				if (labelWeight == MetroTileTextWeight.Bold)
				{
					return MetroFonts.DefaultBold(12f);
				}
			}
			else if (labelSize == MetroTileTextSize.Medium)
			{
				if (labelWeight == MetroTileTextWeight.Light)
				{
					return MetroFonts.DefaultLight(14f);
				}
				if (labelWeight == MetroTileTextWeight.Regular)
				{
					return MetroFonts.Default(14f);
				}
				if (labelWeight == MetroTileTextWeight.Bold)
				{
					return MetroFonts.DefaultBold(14f);
				}
			}
			else if (labelSize == MetroTileTextSize.Tall)
			{
				if (labelWeight == MetroTileTextWeight.Light)
				{
					return MetroFonts.DefaultLight(18f);
				}
				if (labelWeight == MetroTileTextWeight.Regular)
				{
					return MetroFonts.Default(18f);
				}
				if (labelWeight == MetroTileTextWeight.Bold)
				{
					return MetroFonts.DefaultBold(18f);
				}
			}
			return MetroFonts.DefaultLight(14f);
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x0000EC92 File Offset: 0x0000CE92
		public static Font TileCount
		{
			get
			{
				return MetroFonts.Default(44f);
			}
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x0000ECA0 File Offset: 0x0000CEA0
		public static Font Link(MetroLinkSize linkSize, MetroLinkWeight linkWeight)
		{
			if (linkSize == MetroLinkSize.Small)
			{
				if (linkWeight == MetroLinkWeight.Light)
				{
					return MetroFonts.DefaultLight(12f);
				}
				if (linkWeight == MetroLinkWeight.Regular)
				{
					return MetroFonts.Default(12f);
				}
				if (linkWeight == MetroLinkWeight.Bold)
				{
					return MetroFonts.DefaultBold(12f);
				}
			}
			else if (linkSize == MetroLinkSize.Medium)
			{
				if (linkWeight == MetroLinkWeight.Light)
				{
					return MetroFonts.DefaultLight(14f);
				}
				if (linkWeight == MetroLinkWeight.Regular)
				{
					return MetroFonts.Default(14f);
				}
				if (linkWeight == MetroLinkWeight.Bold)
				{
					return MetroFonts.DefaultBold(14f);
				}
			}
			else if (linkSize == MetroLinkSize.Tall)
			{
				if (linkWeight == MetroLinkWeight.Light)
				{
					return MetroFonts.DefaultLight(18f);
				}
				if (linkWeight == MetroLinkWeight.Regular)
				{
					return MetroFonts.Default(18f);
				}
				if (linkWeight == MetroLinkWeight.Bold)
				{
					return MetroFonts.DefaultBold(18f);
				}
			}
			return MetroFonts.Default(12f);
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0000ED48 File Offset: 0x0000CF48
		public static Font Label(MetroLabelSize labelSize, MetroLabelWeight labelWeight)
		{
			if (labelSize == MetroLabelSize.Small)
			{
				if (labelWeight == MetroLabelWeight.Light)
				{
					return MetroFonts.DefaultLight(12f);
				}
				if (labelWeight == MetroLabelWeight.Regular)
				{
					return MetroFonts.Default(12f);
				}
				if (labelWeight == MetroLabelWeight.Bold)
				{
					return MetroFonts.DefaultBold(12f);
				}
			}
			else if (labelSize == MetroLabelSize.Medium)
			{
				if (labelWeight == MetroLabelWeight.Light)
				{
					return MetroFonts.DefaultLight(14f);
				}
				if (labelWeight == MetroLabelWeight.Regular)
				{
					return MetroFonts.Default(14f);
				}
				if (labelWeight == MetroLabelWeight.Bold)
				{
					return MetroFonts.DefaultBold(14f);
				}
			}
			else if (labelSize == MetroLabelSize.Tall)
			{
				if (labelWeight == MetroLabelWeight.Light)
				{
					return MetroFonts.DefaultLight(18f);
				}
				if (labelWeight == MetroLabelWeight.Regular)
				{
					return MetroFonts.Default(18f);
				}
				if (labelWeight == MetroLabelWeight.Bold)
				{
					return MetroFonts.DefaultBold(18f);
				}
			}
			return MetroFonts.DefaultLight(14f);
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x0000EDF0 File Offset: 0x0000CFF0
		public static Font TextBox(MetroTextBoxSize linkSize, MetroTextBoxWeight linkWeight)
		{
			if (linkSize == MetroTextBoxSize.Small)
			{
				if (linkWeight == MetroTextBoxWeight.Light)
				{
					return MetroFonts.DefaultLight(12f);
				}
				if (linkWeight == MetroTextBoxWeight.Regular)
				{
					return MetroFonts.Default(12f);
				}
				if (linkWeight == MetroTextBoxWeight.Bold)
				{
					return MetroFonts.DefaultBold(12f);
				}
			}
			else if (linkSize == MetroTextBoxSize.Medium)
			{
				if (linkWeight == MetroTextBoxWeight.Light)
				{
					return MetroFonts.DefaultLight(14f);
				}
				if (linkWeight == MetroTextBoxWeight.Regular)
				{
					return MetroFonts.Default(14f);
				}
				if (linkWeight == MetroTextBoxWeight.Bold)
				{
					return MetroFonts.DefaultBold(14f);
				}
			}
			else if (linkSize == MetroTextBoxSize.Tall)
			{
				if (linkWeight == MetroTextBoxWeight.Light)
				{
					return MetroFonts.DefaultLight(18f);
				}
				if (linkWeight == MetroTextBoxWeight.Regular)
				{
					return MetroFonts.Default(18f);
				}
				if (linkWeight == MetroTextBoxWeight.Bold)
				{
					return MetroFonts.DefaultBold(18f);
				}
			}
			return MetroFonts.Default(12f);
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0000EE98 File Offset: 0x0000D098
		public static Font ProgressBar(MetroProgressBarSize labelSize, MetroProgressBarWeight labelWeight)
		{
			if (labelSize == MetroProgressBarSize.Small)
			{
				if (labelWeight == MetroProgressBarWeight.Light)
				{
					return MetroFonts.DefaultLight(12f);
				}
				if (labelWeight == MetroProgressBarWeight.Regular)
				{
					return MetroFonts.Default(12f);
				}
				if (labelWeight == MetroProgressBarWeight.Bold)
				{
					return MetroFonts.DefaultBold(12f);
				}
			}
			else if (labelSize == MetroProgressBarSize.Medium)
			{
				if (labelWeight == MetroProgressBarWeight.Light)
				{
					return MetroFonts.DefaultLight(14f);
				}
				if (labelWeight == MetroProgressBarWeight.Regular)
				{
					return MetroFonts.Default(14f);
				}
				if (labelWeight == MetroProgressBarWeight.Bold)
				{
					return MetroFonts.DefaultBold(14f);
				}
			}
			else if (labelSize == MetroProgressBarSize.Tall)
			{
				if (labelWeight == MetroProgressBarWeight.Light)
				{
					return MetroFonts.DefaultLight(18f);
				}
				if (labelWeight == MetroProgressBarWeight.Regular)
				{
					return MetroFonts.Default(18f);
				}
				if (labelWeight == MetroProgressBarWeight.Bold)
				{
					return MetroFonts.DefaultBold(18f);
				}
			}
			return MetroFonts.DefaultLight(14f);
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x0000EF40 File Offset: 0x0000D140
		public static Font TabControl(MetroTabControlSize labelSize, MetroTabControlWeight labelWeight)
		{
			if (labelSize == MetroTabControlSize.Small)
			{
				if (labelWeight == MetroTabControlWeight.Light)
				{
					return MetroFonts.DefaultLight(12f);
				}
				if (labelWeight == MetroTabControlWeight.Regular)
				{
					return MetroFonts.Default(12f);
				}
				if (labelWeight == MetroTabControlWeight.Bold)
				{
					return MetroFonts.DefaultBold(12f);
				}
			}
			else if (labelSize == MetroTabControlSize.Medium)
			{
				if (labelWeight == MetroTabControlWeight.Light)
				{
					return MetroFonts.DefaultLight(14f);
				}
				if (labelWeight == MetroTabControlWeight.Regular)
				{
					return MetroFonts.Default(14f);
				}
				if (labelWeight == MetroTabControlWeight.Bold)
				{
					return MetroFonts.DefaultBold(14f);
				}
			}
			else if (labelSize == MetroTabControlSize.Tall)
			{
				if (labelWeight == MetroTabControlWeight.Light)
				{
					return MetroFonts.DefaultLight(18f);
				}
				if (labelWeight == MetroTabControlWeight.Regular)
				{
					return MetroFonts.Default(18f);
				}
				if (labelWeight == MetroTabControlWeight.Bold)
				{
					return MetroFonts.DefaultBold(18f);
				}
			}
			return MetroFonts.DefaultLight(14f);
		}

		// Token: 0x0400015C RID: 348
		private static MetroFonts.IMetroFontResolver FontResolver;

		// Token: 0x02000074 RID: 116
		internal interface IMetroFontResolver
		{
			// Token: 0x06000453 RID: 1107
			Font ResolveFont(string familyName, float emSize, FontStyle fontStyle, GraphicsUnit unit);
		}

		// Token: 0x02000075 RID: 117
		private class DefaultFontResolver : MetroFonts.IMetroFontResolver
		{
			// Token: 0x06000454 RID: 1108 RVA: 0x0000EFE6 File Offset: 0x0000D1E6
			public Font ResolveFont(string familyName, float emSize, FontStyle fontStyle, GraphicsUnit unit)
			{
				return new Font(familyName, emSize, fontStyle, unit);
			}
		}
	}
}
