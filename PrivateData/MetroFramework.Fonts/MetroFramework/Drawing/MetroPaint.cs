using System;
using System.Drawing;
using System.Windows.Forms;

namespace MetroFramework.Drawing
{
	// Token: 0x0200003D RID: 61
	public sealed class MetroPaint
	{
		// Token: 0x06000350 RID: 848 RVA: 0x0000B870 File Offset: 0x00009A70
		public static Color GetStyleColor(MetroColorStyle style)
		{
			switch (style)
			{
			case MetroColorStyle.Black:
				return MetroColors.Black;
			case MetroColorStyle.White:
				return MetroColors.White;
			case MetroColorStyle.Silver:
				return MetroColors.Silver;
			case MetroColorStyle.Blue:
				return MetroColors.Blue;
			case MetroColorStyle.Green:
				return MetroColors.Green;
			case MetroColorStyle.Lime:
				return MetroColors.Lime;
			case MetroColorStyle.Teal:
				return MetroColors.Teal;
			case MetroColorStyle.Orange:
				return MetroColors.Orange;
			case MetroColorStyle.Brown:
				return MetroColors.Brown;
			case MetroColorStyle.Pink:
				return MetroColors.Pink;
			case MetroColorStyle.Magenta:
				return MetroColors.Magenta;
			case MetroColorStyle.Purple:
				return MetroColors.Purple;
			case MetroColorStyle.Red:
				return MetroColors.Red;
			case MetroColorStyle.Yellow:
				return MetroColors.Yellow;
			default:
				return MetroColors.Blue;
			}
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000B918 File Offset: 0x00009B18
		public static SolidBrush GetStyleBrush(MetroColorStyle style)
		{
			switch (style)
			{
			case MetroColorStyle.Black:
				return MetroBrushes.Black;
			case MetroColorStyle.White:
				return MetroBrushes.White;
			case MetroColorStyle.Silver:
				return MetroBrushes.Silver;
			case MetroColorStyle.Blue:
				return MetroBrushes.Blue;
			case MetroColorStyle.Green:
				return MetroBrushes.Green;
			case MetroColorStyle.Lime:
				return MetroBrushes.Lime;
			case MetroColorStyle.Teal:
				return MetroBrushes.Teal;
			case MetroColorStyle.Orange:
				return MetroBrushes.Orange;
			case MetroColorStyle.Brown:
				return MetroBrushes.Brown;
			case MetroColorStyle.Pink:
				return MetroBrushes.Pink;
			case MetroColorStyle.Magenta:
				return MetroBrushes.Magenta;
			case MetroColorStyle.Purple:
				return MetroBrushes.Purple;
			case MetroColorStyle.Red:
				return MetroBrushes.Red;
			case MetroColorStyle.Yellow:
				return MetroBrushes.Yellow;
			default:
				return MetroBrushes.Blue;
			}
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000B9C0 File Offset: 0x00009BC0
		public static Pen GetStylePen(MetroColorStyle style)
		{
			switch (style)
			{
			case MetroColorStyle.Black:
				return MetroPens.Black;
			case MetroColorStyle.White:
				return MetroPens.White;
			case MetroColorStyle.Silver:
				return MetroPens.Silver;
			case MetroColorStyle.Blue:
				return MetroPens.Blue;
			case MetroColorStyle.Green:
				return MetroPens.Green;
			case MetroColorStyle.Lime:
				return MetroPens.Lime;
			case MetroColorStyle.Teal:
				return MetroPens.Teal;
			case MetroColorStyle.Orange:
				return MetroPens.Orange;
			case MetroColorStyle.Brown:
				return MetroPens.Brown;
			case MetroColorStyle.Pink:
				return MetroPens.Pink;
			case MetroColorStyle.Magenta:
				return MetroPens.Magenta;
			case MetroColorStyle.Purple:
				return MetroPens.Purple;
			case MetroColorStyle.Red:
				return MetroPens.Red;
			case MetroColorStyle.Yellow:
				return MetroPens.Yellow;
			default:
				return MetroPens.Blue;
			}
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0000BA68 File Offset: 0x00009C68
		public static TextFormatFlags GetTextFormatFlags(ContentAlignment textAlign)
		{
			TextFormatFlags textFormatFlags = TextFormatFlags.EndEllipsis;
			if (textAlign <= ContentAlignment.MiddleCenter)
			{
				switch (textAlign)
				{
				case ContentAlignment.TopLeft:
					break;
				case ContentAlignment.TopCenter:
					textFormatFlags |= TextFormatFlags.HorizontalCenter;
					break;
				case (ContentAlignment)3:
					break;
				case ContentAlignment.TopRight:
					textFormatFlags |= TextFormatFlags.Right;
					break;
				default:
					if (textAlign != ContentAlignment.MiddleLeft)
					{
						if (textAlign == ContentAlignment.MiddleCenter)
						{
							textFormatFlags |= (TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
						}
					}
					else
					{
						textFormatFlags |= TextFormatFlags.VerticalCenter;
					}
					break;
				}
			}
			else if (textAlign <= ContentAlignment.BottomLeft)
			{
				if (textAlign != ContentAlignment.MiddleRight)
				{
					if (textAlign == ContentAlignment.BottomLeft)
					{
						textFormatFlags |= TextFormatFlags.Bottom;
					}
				}
				else
				{
					textFormatFlags |= (TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
				}
			}
			else if (textAlign != ContentAlignment.BottomCenter)
			{
				if (textAlign == ContentAlignment.BottomRight)
				{
					textFormatFlags |= (TextFormatFlags.Bottom | TextFormatFlags.Right);
				}
			}
			else
			{
				textFormatFlags |= (TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter);
			}
			return textFormatFlags;
		}

		// Token: 0x0200003E RID: 62
		public sealed class BorderColor
		{
			// Token: 0x06000355 RID: 853 RVA: 0x0000BB0C File Offset: 0x00009D0C
			public static Color Form(MetroThemeStyle theme)
			{
				if (theme == MetroThemeStyle.Dark)
				{
					return Color.FromArgb(153, 153, 153);
				}
				return Color.FromArgb(153, 153, 153);
			}

			// Token: 0x0200003F RID: 63
			public static class Button
			{
				// Token: 0x06000357 RID: 855 RVA: 0x0000BB43 File Offset: 0x00009D43
				public static Color Normal(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(68, 68, 68);
					}
					return Color.FromArgb(204, 204, 204);
				}

				// Token: 0x06000358 RID: 856 RVA: 0x0000BB69 File Offset: 0x00009D69
				public static Color Hover(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(170, 170, 170);
					}
					return Color.FromArgb(102, 102, 102);
				}

				// Token: 0x06000359 RID: 857 RVA: 0x0000BB8F File Offset: 0x00009D8F
				public static Color Press(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(238, 238, 238);
					}
					return Color.FromArgb(51, 51, 51);
				}

				// Token: 0x0600035A RID: 858 RVA: 0x0000BBB5 File Offset: 0x00009DB5
				public static Color Disabled(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(109, 109, 109);
					}
					return Color.FromArgb(155, 155, 155);
				}
			}

			// Token: 0x02000040 RID: 64
			public static class CheckBox
			{
				// Token: 0x0600035B RID: 859 RVA: 0x0000BBDB File Offset: 0x00009DDB
				public static Color Normal(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(153, 153, 153);
					}
					return Color.FromArgb(153, 153, 153);
				}

				// Token: 0x0600035C RID: 860 RVA: 0x0000BC0A File Offset: 0x00009E0A
				public static Color Hover(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(204, 204, 204);
					}
					return Color.FromArgb(51, 51, 51);
				}

				// Token: 0x0600035D RID: 861 RVA: 0x0000BC30 File Offset: 0x00009E30
				public static Color Press(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(153, 153, 153);
					}
					return Color.FromArgb(153, 153, 153);
				}

				// Token: 0x0600035E RID: 862 RVA: 0x0000BC5F File Offset: 0x00009E5F
				public static Color Disabled(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(85, 85, 85);
					}
					return Color.FromArgb(204, 204, 204);
				}
			}

			// Token: 0x02000041 RID: 65
			public static class ComboBox
			{
				// Token: 0x0600035F RID: 863 RVA: 0x0000BC85 File Offset: 0x00009E85
				public static Color Normal(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(153, 153, 153);
					}
					return Color.FromArgb(153, 153, 153);
				}

				// Token: 0x06000360 RID: 864 RVA: 0x0000BCB4 File Offset: 0x00009EB4
				public static Color Hover(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(204, 204, 204);
					}
					return Color.FromArgb(51, 51, 51);
				}

				// Token: 0x06000361 RID: 865 RVA: 0x0000BCDA File Offset: 0x00009EDA
				public static Color Press(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(153, 153, 153);
					}
					return Color.FromArgb(153, 153, 153);
				}

				// Token: 0x06000362 RID: 866 RVA: 0x0000BD09 File Offset: 0x00009F09
				public static Color Disabled(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(85, 85, 85);
					}
					return Color.FromArgb(204, 204, 204);
				}
			}

			// Token: 0x02000042 RID: 66
			public static class ProgressBar
			{
				// Token: 0x06000363 RID: 867 RVA: 0x0000BD2F File Offset: 0x00009F2F
				public static Color Normal(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(68, 68, 68);
					}
					return Color.FromArgb(204, 204, 204);
				}

				// Token: 0x06000364 RID: 868 RVA: 0x0000BD55 File Offset: 0x00009F55
				public static Color Hover(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(68, 68, 68);
					}
					return Color.FromArgb(204, 204, 204);
				}

				// Token: 0x06000365 RID: 869 RVA: 0x0000BD7B File Offset: 0x00009F7B
				public static Color Press(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(68, 68, 68);
					}
					return Color.FromArgb(204, 204, 204);
				}

				// Token: 0x06000366 RID: 870 RVA: 0x0000BDA1 File Offset: 0x00009FA1
				public static Color Disabled(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(109, 109, 109);
					}
					return Color.FromArgb(155, 155, 155);
				}
			}

			// Token: 0x02000043 RID: 67
			public static class TabControl
			{
				// Token: 0x06000367 RID: 871 RVA: 0x0000BDC7 File Offset: 0x00009FC7
				public static Color Normal(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(68, 68, 68);
					}
					return Color.FromArgb(204, 204, 204);
				}

				// Token: 0x06000368 RID: 872 RVA: 0x0000BDED File Offset: 0x00009FED
				public static Color Hover(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(68, 68, 68);
					}
					return Color.FromArgb(204, 204, 204);
				}

				// Token: 0x06000369 RID: 873 RVA: 0x0000BE13 File Offset: 0x0000A013
				public static Color Press(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(68, 68, 68);
					}
					return Color.FromArgb(204, 204, 204);
				}

				// Token: 0x0600036A RID: 874 RVA: 0x0000BE39 File Offset: 0x0000A039
				public static Color Disabled(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(109, 109, 109);
					}
					return Color.FromArgb(155, 155, 155);
				}
			}
		}

		// Token: 0x02000044 RID: 68
		public sealed class BackColor
		{
			// Token: 0x0600036B RID: 875 RVA: 0x0000BE5F File Offset: 0x0000A05F
			public static Color Form(MetroThemeStyle theme)
			{
				if (theme == MetroThemeStyle.Dark)
				{
					return Color.FromArgb(17, 17, 17);
				}
				return Color.FromArgb(255, 255, 255);
			}

			// Token: 0x02000045 RID: 69
			public sealed class Button
			{
				// Token: 0x0600036D RID: 877 RVA: 0x0000BE8D File Offset: 0x0000A08D
				public static Color Normal(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(34, 34, 34);
					}
					return Color.FromArgb(238, 238, 238);
				}

				// Token: 0x0600036E RID: 878 RVA: 0x0000BEB3 File Offset: 0x0000A0B3
				public static Color Hover(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(170, 170, 170);
					}
					return Color.FromArgb(102, 102, 102);
				}

				// Token: 0x0600036F RID: 879 RVA: 0x0000BED9 File Offset: 0x0000A0D9
				public static Color Press(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(238, 238, 238);
					}
					return Color.FromArgb(51, 51, 51);
				}

				// Token: 0x06000370 RID: 880 RVA: 0x0000BEFF File Offset: 0x0000A0FF
				public static Color Disabled(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(80, 80, 80);
					}
					return Color.FromArgb(204, 204, 204);
				}
			}

			// Token: 0x02000046 RID: 70
			public sealed class TrackBar
			{
				// Token: 0x02000047 RID: 71
				public sealed class Thumb
				{
					// Token: 0x06000373 RID: 883 RVA: 0x0000BF35 File Offset: 0x0000A135
					public static Color Normal(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(153, 153, 153);
						}
						return Color.FromArgb(102, 102, 102);
					}

					// Token: 0x06000374 RID: 884 RVA: 0x0000BF5B File Offset: 0x0000A15B
					public static Color Hover(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(204, 204, 204);
						}
						return Color.FromArgb(17, 17, 17);
					}

					// Token: 0x06000375 RID: 885 RVA: 0x0000BF81 File Offset: 0x0000A181
					public static Color Press(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(204, 204, 204);
						}
						return Color.FromArgb(17, 17, 17);
					}

					// Token: 0x06000376 RID: 886 RVA: 0x0000BFA7 File Offset: 0x0000A1A7
					public static Color Disabled(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(85, 85, 85);
						}
						return Color.FromArgb(179, 179, 179);
					}
				}

				// Token: 0x02000048 RID: 72
				public sealed class Bar
				{
					// Token: 0x06000378 RID: 888 RVA: 0x0000BFD5 File Offset: 0x0000A1D5
					public static Color Normal(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(51, 51, 51);
						}
						return Color.FromArgb(204, 204, 204);
					}

					// Token: 0x06000379 RID: 889 RVA: 0x0000BFFB File Offset: 0x0000A1FB
					public static Color Hover(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(51, 51, 51);
						}
						return Color.FromArgb(204, 204, 204);
					}

					// Token: 0x0600037A RID: 890 RVA: 0x0000C021 File Offset: 0x0000A221
					public static Color Press(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(51, 51, 51);
						}
						return Color.FromArgb(204, 204, 204);
					}

					// Token: 0x0600037B RID: 891 RVA: 0x0000C047 File Offset: 0x0000A247
					public static Color Disabled(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(34, 34, 34);
						}
						return Color.FromArgb(230, 230, 230);
					}
				}
			}

			// Token: 0x02000049 RID: 73
			public sealed class ScrollBar
			{
				// Token: 0x0200004A RID: 74
				public sealed class Thumb
				{
					// Token: 0x0600037E RID: 894 RVA: 0x0000C07D File Offset: 0x0000A27D
					public static Color Normal(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(51, 51, 51);
						}
						return Color.FromArgb(221, 221, 221);
					}

					// Token: 0x0600037F RID: 895 RVA: 0x0000C0A3 File Offset: 0x0000A2A3
					public static Color Hover(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(204, 204, 204);
						}
						return Color.FromArgb(17, 17, 17);
					}

					// Token: 0x06000380 RID: 896 RVA: 0x0000C0C9 File Offset: 0x0000A2C9
					public static Color Press(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(204, 204, 204);
						}
						return Color.FromArgb(17, 17, 17);
					}

					// Token: 0x06000381 RID: 897 RVA: 0x0000C0EF File Offset: 0x0000A2EF
					public static Color Disabled(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(51, 51, 51);
						}
						return Color.FromArgb(221, 221, 221);
					}
				}

				// Token: 0x0200004B RID: 75
				public sealed class Bar
				{
					// Token: 0x06000383 RID: 899 RVA: 0x0000C11D File Offset: 0x0000A31D
					public static Color Normal(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(38, 38, 38);
						}
						return Color.FromArgb(234, 234, 234);
					}

					// Token: 0x06000384 RID: 900 RVA: 0x0000C143 File Offset: 0x0000A343
					public static Color Hover(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(38, 38, 38);
						}
						return Color.FromArgb(234, 234, 234);
					}

					// Token: 0x06000385 RID: 901 RVA: 0x0000C169 File Offset: 0x0000A369
					public static Color Press(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(38, 38, 38);
						}
						return Color.FromArgb(234, 234, 234);
					}

					// Token: 0x06000386 RID: 902 RVA: 0x0000C18F File Offset: 0x0000A38F
					public static Color Disabled(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(38, 38, 38);
						}
						return Color.FromArgb(234, 234, 234);
					}
				}
			}

			// Token: 0x0200004C RID: 76
			public sealed class ProgressBar
			{
				// Token: 0x0200004D RID: 77
				public sealed class Bar
				{
					// Token: 0x06000389 RID: 905 RVA: 0x0000C1C5 File Offset: 0x0000A3C5
					public static Color Normal(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(38, 38, 38);
						}
						return Color.FromArgb(234, 234, 234);
					}

					// Token: 0x0600038A RID: 906 RVA: 0x0000C1EB File Offset: 0x0000A3EB
					public static Color Hover(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(38, 38, 38);
						}
						return Color.FromArgb(234, 234, 234);
					}

					// Token: 0x0600038B RID: 907 RVA: 0x0000C211 File Offset: 0x0000A411
					public static Color Press(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(38, 38, 38);
						}
						return Color.FromArgb(234, 234, 234);
					}

					// Token: 0x0600038C RID: 908 RVA: 0x0000C237 File Offset: 0x0000A437
					public static Color Disabled(MetroThemeStyle theme)
					{
						if (theme == MetroThemeStyle.Dark)
						{
							return Color.FromArgb(51, 51, 51);
						}
						return Color.FromArgb(221, 221, 221);
					}
				}
			}
		}

		// Token: 0x0200004E RID: 78
		public sealed class ForeColor
		{
			// Token: 0x0600038E RID: 910 RVA: 0x0000C265 File Offset: 0x0000A465
			public static Color Form(MetroThemeStyle theme)
			{
				if (theme == MetroThemeStyle.Dark)
				{
					return Color.FromArgb(255, 255, 255);
				}
				return Color.FromArgb(0, 0, 0);
			}

			// Token: 0x0200004F RID: 79
			public sealed class Button
			{
				// Token: 0x06000390 RID: 912 RVA: 0x0000C290 File Offset: 0x0000A490
				public static Color Normal(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(204, 204, 204);
					}
					return Color.FromArgb(0, 0, 0);
				}

				// Token: 0x06000391 RID: 913 RVA: 0x0000C2B3 File Offset: 0x0000A4B3
				public static Color Hover(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(17, 17, 17);
					}
					return Color.FromArgb(255, 255, 255);
				}

				// Token: 0x06000392 RID: 914 RVA: 0x0000C2D9 File Offset: 0x0000A4D9
				public static Color Press(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(17, 17, 17);
					}
					return Color.FromArgb(255, 255, 255);
				}

				// Token: 0x06000393 RID: 915 RVA: 0x0000C2FF File Offset: 0x0000A4FF
				public static Color Disabled(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(109, 109, 109);
					}
					return Color.FromArgb(136, 136, 136);
				}
			}

			// Token: 0x02000050 RID: 80
			public sealed class Tile
			{
				// Token: 0x06000395 RID: 917 RVA: 0x0000C32D File Offset: 0x0000A52D
				public static Color Normal(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(255, 255, 255);
					}
					return Color.FromArgb(255, 255, 255);
				}

				// Token: 0x06000396 RID: 918 RVA: 0x0000C35C File Offset: 0x0000A55C
				public static Color Hover(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(255, 255, 255);
					}
					return Color.FromArgb(255, 255, 255);
				}

				// Token: 0x06000397 RID: 919 RVA: 0x0000C38B File Offset: 0x0000A58B
				public static Color Press(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(255, 255, 255);
					}
					return Color.FromArgb(255, 255, 255);
				}

				// Token: 0x06000398 RID: 920 RVA: 0x0000C3BA File Offset: 0x0000A5BA
				public static Color Disabled(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(209, 209, 209);
					}
					return Color.FromArgb(209, 209, 209);
				}
			}

			// Token: 0x02000051 RID: 81
			public sealed class Link
			{
				// Token: 0x0600039A RID: 922 RVA: 0x0000C3F1 File Offset: 0x0000A5F1
				public static Color Normal(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(170, 170, 170);
					}
					return Color.FromArgb(0, 0, 0);
				}

				// Token: 0x0600039B RID: 923 RVA: 0x0000C414 File Offset: 0x0000A614
				public static Color Hover(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(93, 93, 93);
					}
					return Color.FromArgb(128, 128, 128);
				}

				// Token: 0x0600039C RID: 924 RVA: 0x0000C43A File Offset: 0x0000A63A
				public static Color Press(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(93, 93, 93);
					}
					return Color.FromArgb(128, 128, 128);
				}

				// Token: 0x0600039D RID: 925 RVA: 0x0000C460 File Offset: 0x0000A660
				public static Color Disabled(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(51, 51, 51);
					}
					return Color.FromArgb(209, 209, 209);
				}
			}

			// Token: 0x02000052 RID: 82
			public sealed class Label
			{
				// Token: 0x0600039F RID: 927 RVA: 0x0000C48E File Offset: 0x0000A68E
				public static Color Normal(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(170, 170, 170);
					}
					return Color.FromArgb(0, 0, 0);
				}

				// Token: 0x060003A0 RID: 928 RVA: 0x0000C4B1 File Offset: 0x0000A6B1
				public static Color Disabled(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(51, 51, 51);
					}
					return Color.FromArgb(209, 209, 209);
				}
			}

			// Token: 0x02000053 RID: 83
			public sealed class CheckBox
			{
				// Token: 0x060003A2 RID: 930 RVA: 0x0000C4DF File Offset: 0x0000A6DF
				public static Color Normal(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(170, 170, 170);
					}
					return Color.FromArgb(17, 17, 17);
				}

				// Token: 0x060003A3 RID: 931 RVA: 0x0000C505 File Offset: 0x0000A705
				public static Color Hover(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(153, 153, 153);
					}
					return Color.FromArgb(153, 153, 153);
				}

				// Token: 0x060003A4 RID: 932 RVA: 0x0000C534 File Offset: 0x0000A734
				public static Color Press(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(153, 153, 153);
					}
					return Color.FromArgb(153, 153, 153);
				}

				// Token: 0x060003A5 RID: 933 RVA: 0x0000C563 File Offset: 0x0000A763
				public static Color Disabled(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(93, 93, 93);
					}
					return Color.FromArgb(136, 136, 136);
				}
			}

			// Token: 0x02000054 RID: 84
			public sealed class ComboBox
			{
				// Token: 0x060003A7 RID: 935 RVA: 0x0000C591 File Offset: 0x0000A791
				public static Color Normal(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(153, 153, 153);
					}
					return Color.FromArgb(153, 153, 153);
				}

				// Token: 0x060003A8 RID: 936 RVA: 0x0000C5C0 File Offset: 0x0000A7C0
				public static Color Hover(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(170, 170, 170);
					}
					return Color.FromArgb(17, 17, 17);
				}

				// Token: 0x060003A9 RID: 937 RVA: 0x0000C5E6 File Offset: 0x0000A7E6
				public static Color Press(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(153, 153, 153);
					}
					return Color.FromArgb(153, 153, 153);
				}

				// Token: 0x060003AA RID: 938 RVA: 0x0000C615 File Offset: 0x0000A815
				public static Color Disabled(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(93, 93, 93);
					}
					return Color.FromArgb(136, 136, 136);
				}
			}

			// Token: 0x02000055 RID: 85
			public sealed class ProgressBar
			{
				// Token: 0x060003AC RID: 940 RVA: 0x0000C643 File Offset: 0x0000A843
				public static Color Normal(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(170, 170, 170);
					}
					return Color.FromArgb(0, 0, 0);
				}

				// Token: 0x060003AD RID: 941 RVA: 0x0000C666 File Offset: 0x0000A866
				public static Color Disabled(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(51, 51, 51);
					}
					return Color.FromArgb(209, 209, 209);
				}
			}

			// Token: 0x02000056 RID: 86
			public sealed class TabControl
			{
				// Token: 0x060003AF RID: 943 RVA: 0x0000C694 File Offset: 0x0000A894
				public static Color Normal(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(170, 170, 170);
					}
					return Color.FromArgb(0, 0, 0);
				}

				// Token: 0x060003B0 RID: 944 RVA: 0x0000C6B7 File Offset: 0x0000A8B7
				public static Color Disabled(MetroThemeStyle theme)
				{
					if (theme == MetroThemeStyle.Dark)
					{
						return Color.FromArgb(51, 51, 51);
					}
					return Color.FromArgb(209, 209, 209);
				}
			}
		}
	}
}
