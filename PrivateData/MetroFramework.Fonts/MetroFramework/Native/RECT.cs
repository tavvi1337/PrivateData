using System;
using System.Diagnostics;
using System.Drawing;

namespace MetroFramework.Native
{
	// Token: 0x02000078 RID: 120
	[DebuggerDisplay("({Top},{Left}) ({Bottom},{Right})")]
	public struct RECT
	{
		// Token: 0x06000466 RID: 1126 RVA: 0x0000F166 File Offset: 0x0000D366
		public RECT(Rectangle rect)
		{
			this.Left = rect.Left;
			this.Top = rect.Top;
			this.Right = rect.Right;
			this.Bottom = rect.Bottom;
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x0000F19C File Offset: 0x0000D39C
		public RECT(int left, int top, int right, int bottom)
		{
			this.Left = left;
			this.Top = top;
			this.Right = right;
			this.Bottom = bottom;
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x0000F1BB File Offset: 0x0000D3BB
		public Rectangle ToRectangle()
		{
			return new Rectangle(this.Left, this.Top, this.Width, this.Height);
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x0000F1DA File Offset: 0x0000D3DA
		public int Height
		{
			get
			{
				return this.Bottom - this.Top;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600046A RID: 1130 RVA: 0x0000F1E9 File Offset: 0x0000D3E9
		public Size Size
		{
			get
			{
				return new Size(this.Width, this.Height);
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x0600046B RID: 1131 RVA: 0x0000F1FC File Offset: 0x0000D3FC
		public int Width
		{
			get
			{
				return this.Right - this.Left;
			}
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x0000F20B File Offset: 0x0000D40B
		public void Inflate(int px)
		{
			this.Left -= px;
			this.Top -= px;
			this.Right += px;
			this.Bottom += px;
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0000F245 File Offset: 0x0000D445
		public static implicit operator Rectangle(RECT other)
		{
			return other.ToRectangle();
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x0000F24E File Offset: 0x0000D44E
		public static implicit operator RECT(Rectangle other)
		{
			return new RECT(other);
		}

		// Token: 0x04000162 RID: 354
		public int Left;

		// Token: 0x04000163 RID: 355
		public int Top;

		// Token: 0x04000164 RID: 356
		public int Right;

		// Token: 0x04000165 RID: 357
		public int Bottom;

		// Token: 0x04000166 RID: 358
		public static RECT Empty;
	}
}
