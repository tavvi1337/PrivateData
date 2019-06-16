using System;
using System.Runtime.InteropServices;
using System.Security;

namespace MetroFramework.Native
{
	// Token: 0x0200008C RID: 140
	[SuppressUnmanagedCodeSecurity]
	internal sealed class WinCaret
	{
		// Token: 0x060004AC RID: 1196
		[DllImport("User32.dll")]
		private static extern bool CreateCaret(IntPtr hWnd, int hBitmap, int nWidth, int nHeight);

		// Token: 0x060004AD RID: 1197
		[DllImport("User32.dll")]
		private static extern bool SetCaretPos(int x, int y);

		// Token: 0x060004AE RID: 1198
		[DllImport("User32.dll")]
		private static extern bool DestroyCaret();

		// Token: 0x060004AF RID: 1199
		[DllImport("User32.dll")]
		private static extern bool ShowCaret(IntPtr hWnd);

		// Token: 0x060004B0 RID: 1200
		[DllImport("User32.dll")]
		public static extern bool HideCaret(IntPtr hWnd);

		// Token: 0x060004B1 RID: 1201 RVA: 0x0000F4EB File Offset: 0x0000D6EB
		public WinCaret(IntPtr ownerHandle)
		{
			this.controlHandle = ownerHandle;
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0000F4FA File Offset: 0x0000D6FA
		public bool Create(int width, int height)
		{
			return WinCaret.CreateCaret(this.controlHandle, 0, width, height);
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0000F50A File Offset: 0x0000D70A
		public void Hide()
		{
			WinCaret.HideCaret(this.controlHandle);
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x0000F518 File Offset: 0x0000D718
		public void Show()
		{
			WinCaret.ShowCaret(this.controlHandle);
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x0000F526 File Offset: 0x0000D726
		public bool SetPosition(int x, int y)
		{
			return WinCaret.SetCaretPos(x, y);
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x0000F52F File Offset: 0x0000D72F
		public void Destroy()
		{
			WinCaret.DestroyCaret();
		}

		// Token: 0x040002B9 RID: 697
		private IntPtr controlHandle;
	}
}
