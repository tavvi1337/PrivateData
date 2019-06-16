using System;
using System.Security;
using System.Windows.Forms;

namespace MetroFramework.Native
{
	// Token: 0x02000079 RID: 121
	[SuppressUnmanagedCodeSecurity]
	internal class SubClass : NativeWindow
	{
		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600046F RID: 1135 RVA: 0x0000F258 File Offset: 0x0000D458
		// (remove) Token: 0x06000470 RID: 1136 RVA: 0x0000F290 File Offset: 0x0000D490
		public event SubClass.SubClassWndProcEventHandler SubClassedWndProc;

		// Token: 0x06000471 RID: 1137 RVA: 0x0000F2C5 File Offset: 0x0000D4C5
		public SubClass(IntPtr Handle, bool _SubClass)
		{
			base.AssignHandle(Handle);
			this.IsSubClassed = _SubClass;
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x0000F2DB File Offset: 0x0000D4DB
		// (set) Token: 0x06000473 RID: 1139 RVA: 0x0000F2E3 File Offset: 0x0000D4E3
		public bool SubClassed
		{
			get
			{
				return this.IsSubClassed;
			}
			set
			{
				this.IsSubClassed = value;
			}
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0000F2EC File Offset: 0x0000D4EC
		protected override void WndProc(ref Message m)
		{
			if (this.IsSubClassed && this.OnSubClassedWndProc(ref m) != 0)
			{
				return;
			}
			base.WndProc(ref m);
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x0000F307 File Offset: 0x0000D507
		public void CallDefaultWndProc(ref Message m)
		{
			base.WndProc(ref m);
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0000F310 File Offset: 0x0000D510
		public int HiWord(int Number)
		{
			return Number >> 16 & 65535;
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0000F31C File Offset: 0x0000D51C
		public int LoWord(int Number)
		{
			return Number & 65535;
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0000F325 File Offset: 0x0000D525
		public int MakeLong(int LoWord, int HiWord)
		{
			return HiWord << 16 | (LoWord & 65535);
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0000F333 File Offset: 0x0000D533
		public IntPtr MakeLParam(int LoWord, int HiWord)
		{
			return (IntPtr)(HiWord << 16 | (LoWord & 65535));
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0000F346 File Offset: 0x0000D546
		private int OnSubClassedWndProc(ref Message m)
		{
			if (this.SubClassedWndProc != null)
			{
				return this.SubClassedWndProc(ref m);
			}
			return 0;
		}

		// Token: 0x04000168 RID: 360
		private bool IsSubClassed;

		// Token: 0x0200007A RID: 122
		// (Invoke) Token: 0x0600047C RID: 1148
		public delegate int SubClassWndProcEventHandler(ref Message m);
	}
}
