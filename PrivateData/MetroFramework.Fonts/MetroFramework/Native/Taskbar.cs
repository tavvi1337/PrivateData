using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;

namespace MetroFramework.Native
{
	// Token: 0x0200007C RID: 124
	internal class Taskbar
	{
		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600047F RID: 1151 RVA: 0x0000F35E File Offset: 0x0000D55E
		// (set) Token: 0x06000480 RID: 1152 RVA: 0x0000F366 File Offset: 0x0000D566
		public Rectangle Bounds
		{
			get
			{
				return this.bounds;
			}
			private set
			{
				this.bounds = value;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x0000F36F File Offset: 0x0000D56F
		// (set) Token: 0x06000482 RID: 1154 RVA: 0x0000F377 File Offset: 0x0000D577
		public TaskbarPosition Position
		{
			get
			{
				return this.position;
			}
			private set
			{
				this.position = value;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x0000F380 File Offset: 0x0000D580
		public Point Location
		{
			get
			{
				return this.Bounds.Location;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x0000F39C File Offset: 0x0000D59C
		public Size Size
		{
			get
			{
				return this.Bounds.Size;
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x0000F3B7 File Offset: 0x0000D5B7
		// (set) Token: 0x06000486 RID: 1158 RVA: 0x0000F3BF File Offset: 0x0000D5BF
		public bool AlwaysOnTop
		{
			get
			{
				return this.alwaysOnTop;
			}
			private set
			{
				this.alwaysOnTop = value;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000487 RID: 1159 RVA: 0x0000F3C8 File Offset: 0x0000D5C8
		// (set) Token: 0x06000488 RID: 1160 RVA: 0x0000F3D0 File Offset: 0x0000D5D0
		public bool AutoHide
		{
			get
			{
				return this.autoHide;
			}
			private set
			{
				this.autoHide = value;
			}
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x0000F3DC File Offset: 0x0000D5DC
		[SecuritySafeCritical]
		public Taskbar()
		{
			IntPtr hWnd = WinApi.FindWindow("Shell_TrayWnd", null);
			WinApi.APPBARDATA appbardata = default(WinApi.APPBARDATA);
			appbardata.cbSize = (uint)Marshal.SizeOf(typeof(WinApi.APPBARDATA));
			appbardata.hWnd = hWnd;
			IntPtr value = WinApi.SHAppBarMessage(WinApi.ABM.GetTaskbarPos, ref appbardata);
			if (value == IntPtr.Zero)
			{
				throw new InvalidOperationException();
			}
			this.Position = (TaskbarPosition)appbardata.uEdge;
			this.Bounds = Rectangle.FromLTRB(appbardata.rc.Left, appbardata.rc.Top, appbardata.rc.Right, appbardata.rc.Bottom);
			appbardata.cbSize = (uint)Marshal.SizeOf(typeof(WinApi.APPBARDATA));
			int num = WinApi.SHAppBarMessage(WinApi.ABM.GetState, ref appbardata).ToInt32();
			this.AlwaysOnTop = ((num & 2) == 2);
			this.AutoHide = ((num & 1) == 1);
		}

		// Token: 0x0400016F RID: 367
		private const string ClassName = "Shell_TrayWnd";

		// Token: 0x04000170 RID: 368
		private Rectangle bounds = Rectangle.Empty;

		// Token: 0x04000171 RID: 369
		private TaskbarPosition position = TaskbarPosition.Unknown;

		// Token: 0x04000172 RID: 370
		private bool alwaysOnTop;

		// Token: 0x04000173 RID: 371
		private bool autoHide;
	}
}
