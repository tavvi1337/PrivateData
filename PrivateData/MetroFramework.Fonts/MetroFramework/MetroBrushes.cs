using System;
using System.Collections.Generic;
using System.Drawing;

namespace MetroFramework
{
	// Token: 0x02000063 RID: 99
	internal static class MetroBrushes
	{
		// Token: 0x06000427 RID: 1063 RVA: 0x0000E8E4 File Offset: 0x0000CAE4
		private static SolidBrush GetSaveBrush(string key, Color color)
		{
			SolidBrush result;
			lock (MetroBrushes.metroBrushes)
			{
				SolidBrush solidBrush;
				if (!MetroBrushes.metroBrushes.TryGetValue(key, out solidBrush))
				{
					solidBrush = new SolidBrush(color);
					MetroBrushes.metroBrushes.Add(key, solidBrush);
				}
				result = (SolidBrush)solidBrush.Clone();
			}
			return result;
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000428 RID: 1064 RVA: 0x0000E94C File Offset: 0x0000CB4C
		public static SolidBrush Black
		{
			get
			{
				return MetroBrushes.GetSaveBrush("Black", MetroColors.Black);
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x0000E95D File Offset: 0x0000CB5D
		public static SolidBrush White
		{
			get
			{
				return MetroBrushes.GetSaveBrush("White", MetroColors.White);
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x0000E96E File Offset: 0x0000CB6E
		public static SolidBrush Silver
		{
			get
			{
				return MetroBrushes.GetSaveBrush("Silver", MetroColors.Silver);
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x0000E97F File Offset: 0x0000CB7F
		public static SolidBrush Blue
		{
			get
			{
				return MetroBrushes.GetSaveBrush("Blue", MetroColors.Blue);
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x0000E990 File Offset: 0x0000CB90
		public static SolidBrush Green
		{
			get
			{
				return MetroBrushes.GetSaveBrush("Green", MetroColors.Green);
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x0000E9A1 File Offset: 0x0000CBA1
		public static SolidBrush Lime
		{
			get
			{
				return MetroBrushes.GetSaveBrush("Lime", MetroColors.Lime);
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x0600042E RID: 1070 RVA: 0x0000E9B2 File Offset: 0x0000CBB2
		public static SolidBrush Teal
		{
			get
			{
				return MetroBrushes.GetSaveBrush("Teal", MetroColors.Teal);
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x0000E9C3 File Offset: 0x0000CBC3
		public static SolidBrush Orange
		{
			get
			{
				return MetroBrushes.GetSaveBrush("Orange", MetroColors.Orange);
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x0000E9D4 File Offset: 0x0000CBD4
		public static SolidBrush Brown
		{
			get
			{
				return MetroBrushes.GetSaveBrush("Brown", MetroColors.Brown);
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x0000E9E5 File Offset: 0x0000CBE5
		public static SolidBrush Pink
		{
			get
			{
				return MetroBrushes.GetSaveBrush("Pink", MetroColors.Pink);
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x0000E9F6 File Offset: 0x0000CBF6
		public static SolidBrush Magenta
		{
			get
			{
				return MetroBrushes.GetSaveBrush("Magenta", MetroColors.Magenta);
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x0000EA07 File Offset: 0x0000CC07
		public static SolidBrush Purple
		{
			get
			{
				return MetroBrushes.GetSaveBrush("Purple", MetroColors.Purple);
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000434 RID: 1076 RVA: 0x0000EA18 File Offset: 0x0000CC18
		public static SolidBrush Red
		{
			get
			{
				return MetroBrushes.GetSaveBrush("Red", MetroColors.Red);
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x0000EA29 File Offset: 0x0000CC29
		public static SolidBrush Yellow
		{
			get
			{
				return MetroBrushes.GetSaveBrush("Yellow", MetroColors.Yellow);
			}
		}

		// Token: 0x04000117 RID: 279
		private static readonly Dictionary<string, SolidBrush> metroBrushes = new Dictionary<string, SolidBrush>();
	}
}
