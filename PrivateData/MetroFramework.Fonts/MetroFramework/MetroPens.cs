using System;
using System.Collections.Generic;
using System.Drawing;

namespace MetroFramework
{
	// Token: 0x02000076 RID: 118
	internal static class MetroPens
	{
		// Token: 0x06000456 RID: 1110 RVA: 0x0000EFFC File Offset: 0x0000D1FC
		private static Pen GetSavePen(string key, Color color)
		{
			Pen result;
			lock (MetroPens.metroPens)
			{
				Pen pen;
				if (!MetroPens.metroPens.TryGetValue(key, out pen))
				{
					pen = new Pen(color, 1f);
					MetroPens.metroPens.Add(key, pen);
				}
				result = (Pen)pen.Clone();
			}
			return result;
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x0000F06C File Offset: 0x0000D26C
		public static Pen Black
		{
			get
			{
				return MetroPens.GetSavePen("Black", MetroColors.Black);
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000458 RID: 1112 RVA: 0x0000F07D File Offset: 0x0000D27D
		public static Pen White
		{
			get
			{
				return MetroPens.GetSavePen("White", MetroColors.White);
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x0000F08E File Offset: 0x0000D28E
		public static Pen Silver
		{
			get
			{
				return MetroPens.GetSavePen("Silver", MetroColors.Silver);
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600045A RID: 1114 RVA: 0x0000F09F File Offset: 0x0000D29F
		public static Pen Blue
		{
			get
			{
				return MetroPens.GetSavePen("Blue", MetroColors.Blue);
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x0600045B RID: 1115 RVA: 0x0000F0B0 File Offset: 0x0000D2B0
		public static Pen Green
		{
			get
			{
				return MetroPens.GetSavePen("Green", MetroColors.Green);
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x0600045C RID: 1116 RVA: 0x0000F0C1 File Offset: 0x0000D2C1
		public static Pen Lime
		{
			get
			{
				return MetroPens.GetSavePen("Lime", MetroColors.Lime);
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x0600045D RID: 1117 RVA: 0x0000F0D2 File Offset: 0x0000D2D2
		public static Pen Teal
		{
			get
			{
				return MetroPens.GetSavePen("Teal", MetroColors.Teal);
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x0600045E RID: 1118 RVA: 0x0000F0E3 File Offset: 0x0000D2E3
		public static Pen Orange
		{
			get
			{
				return MetroPens.GetSavePen("Orange", MetroColors.Orange);
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x0000F0F4 File Offset: 0x0000D2F4
		public static Pen Brown
		{
			get
			{
				return MetroPens.GetSavePen("Brown", MetroColors.Brown);
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000460 RID: 1120 RVA: 0x0000F105 File Offset: 0x0000D305
		public static Pen Pink
		{
			get
			{
				return MetroPens.GetSavePen("Pink", MetroColors.Pink);
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000461 RID: 1121 RVA: 0x0000F116 File Offset: 0x0000D316
		public static Pen Magenta
		{
			get
			{
				return MetroPens.GetSavePen("Magenta", MetroColors.Magenta);
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000462 RID: 1122 RVA: 0x0000F127 File Offset: 0x0000D327
		public static Pen Purple
		{
			get
			{
				return MetroPens.GetSavePen("Purple", MetroColors.Purple);
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000463 RID: 1123 RVA: 0x0000F138 File Offset: 0x0000D338
		public static Pen Red
		{
			get
			{
				return MetroPens.GetSavePen("Red", MetroColors.Red);
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000464 RID: 1124 RVA: 0x0000F149 File Offset: 0x0000D349
		public static Pen Yellow
		{
			get
			{
				return MetroPens.GetSavePen("Yellow", MetroColors.Yellow);
			}
		}

		// Token: 0x0400015D RID: 349
		private static readonly Dictionary<string, Pen> metroPens = new Dictionary<string, Pen>();
	}
}
