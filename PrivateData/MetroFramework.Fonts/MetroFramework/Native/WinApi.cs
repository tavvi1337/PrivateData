using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;

namespace MetroFramework.Native
{
	// Token: 0x0200007D RID: 125
	[SuppressUnmanagedCodeSecurity]
	internal static class WinApi
	{
		// Token: 0x0600048A RID: 1162
		[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern WinApi.Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, int crKey, ref WinApi.BLENDFUNCTION pblend, int dwFlags);

		// Token: 0x0600048B RID: 1163
		[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x0600048C RID: 1164
		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

		// Token: 0x0600048D RID: 1165
		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern WinApi.Bool DeleteDC(IntPtr hdc);

		// Token: 0x0600048E RID: 1166
		[DllImport("gdi32.dll", ExactSpelling = true)]
		public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

		// Token: 0x0600048F RID: 1167
		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern WinApi.Bool DeleteObject(IntPtr hObject);

		// Token: 0x06000490 RID: 1168
		[DllImport("user32.dll", SetLastError = true)]
		public static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

		// Token: 0x06000491 RID: 1169
		[DllImport("user32.dll")]
		public static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

		// Token: 0x06000492 RID: 1170
		[DllImport("user32.dll")]
		public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

		// Token: 0x06000493 RID: 1171
		[DllImport("user32.dll")]
		public static extern int GetMenuItemCount(IntPtr hMenu);

		// Token: 0x06000494 RID: 1172
		[DllImport("user32.dll")]
		public static extern bool DrawMenuBar(IntPtr hWnd);

		// Token: 0x06000495 RID: 1173
		[DllImport("user32.dll")]
		public static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);

		// Token: 0x06000496 RID: 1174
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x06000497 RID: 1175
		[DllImport("user32.dll")]
		public static extern IntPtr SetCapture(IntPtr hWnd);

		// Token: 0x06000498 RID: 1176
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x06000499 RID: 1177
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr wnd, int msg, bool param, int lparam);

		// Token: 0x0600049A RID: 1178
		[DllImport("shell32.dll", SetLastError = true)]
		public static extern IntPtr SHAppBarMessage(WinApi.ABM dwMessage, [In] ref WinApi.APPBARDATA pData);

		// Token: 0x0600049B RID: 1179
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		// Token: 0x0600049C RID: 1180
		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		// Token: 0x0600049D RID: 1181
		[DllImport("user32.dll")]
		public static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);

		// Token: 0x0600049E RID: 1182
		[DllImport("user32.dll")]
		public static extern bool ShowScrollBar(IntPtr hWnd, int bar, int cmd);

		// Token: 0x0600049F RID: 1183
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetWindowDC(IntPtr handle);

		// Token: 0x060004A0 RID: 1184
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr ReleaseDC(IntPtr handle, IntPtr hDC);

		// Token: 0x060004A1 RID: 1185
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int GetClassName(IntPtr hwnd, char[] className, int maxCount);

		// Token: 0x060004A2 RID: 1186
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetWindow(IntPtr hwnd, int uCmd);

		// Token: 0x060004A3 RID: 1187
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool IsWindowVisible(IntPtr hwnd);

		// Token: 0x060004A4 RID: 1188
		[DllImport("user32", CharSet = CharSet.Auto)]
		public static extern int GetClientRect(IntPtr hwnd, ref RECT rect);

		// Token: 0x060004A5 RID: 1189
		[DllImport("user32", CharSet = CharSet.Auto)]
		public static extern bool MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

		// Token: 0x060004A6 RID: 1190
		[DllImport("user32", CharSet = CharSet.Auto)]
		public static extern bool UpdateWindow(IntPtr hwnd);

		// Token: 0x060004A7 RID: 1191
		[DllImport("user32", CharSet = CharSet.Auto)]
		public static extern bool InvalidateRect(IntPtr hwnd, ref RECT rect, bool bErase);

		// Token: 0x060004A8 RID: 1192
		[DllImport("user32", CharSet = CharSet.Auto)]
		public static extern bool ValidateRect(IntPtr hwnd, ref RECT rect);

		// Token: 0x060004A9 RID: 1193
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern bool GetWindowRect(IntPtr hWnd, [In] [Out] ref RECT rect);

		// Token: 0x060004AA RID: 1194 RVA: 0x0000F4D6 File Offset: 0x0000D6D6
		public static int LoWord(int dwValue)
		{
			return dwValue & 65535;
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x0000F4DF File Offset: 0x0000D6DF
		public static int HiWord(int dwValue)
		{
			return dwValue >> 16 & 65535;
		}

		// Token: 0x04000174 RID: 372
		public const int Autohide = 1;

		// Token: 0x04000175 RID: 373
		public const int AlwaysOnTop = 2;

		// Token: 0x04000176 RID: 374
		public const int MfByposition = 1024;

		// Token: 0x04000177 RID: 375
		public const int MfRemove = 4096;

		// Token: 0x04000178 RID: 376
		public const int TCM_HITTEST = 4883;

		// Token: 0x04000179 RID: 377
		public const int ULW_COLORKEY = 1;

		// Token: 0x0400017A RID: 378
		public const int ULW_ALPHA = 2;

		// Token: 0x0400017B RID: 379
		public const int ULW_OPAQUE = 4;

		// Token: 0x0400017C RID: 380
		public const byte AC_SRC_OVER = 0;

		// Token: 0x0400017D RID: 381
		public const byte AC_SRC_ALPHA = 1;

		// Token: 0x0400017E RID: 382
		public const int GW_HWNDFIRST = 0;

		// Token: 0x0400017F RID: 383
		public const int GW_HWNDLAST = 1;

		// Token: 0x04000180 RID: 384
		public const int GW_HWNDNEXT = 2;

		// Token: 0x04000181 RID: 385
		public const int GW_HWNDPREV = 3;

		// Token: 0x04000182 RID: 386
		public const int GW_OWNER = 4;

		// Token: 0x04000183 RID: 387
		public const int GW_CHILD = 5;

		// Token: 0x04000184 RID: 388
		public const int HC_ACTION = 0;

		// Token: 0x04000185 RID: 389
		public const int WH_CALLWNDPROC = 4;

		// Token: 0x04000186 RID: 390
		public const int GWL_WNDPROC = -4;

		// Token: 0x0200007E RID: 126
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct ARGB
		{
			// Token: 0x04000187 RID: 391
			public byte Blue;

			// Token: 0x04000188 RID: 392
			public byte Green;

			// Token: 0x04000189 RID: 393
			public byte Red;

			// Token: 0x0400018A RID: 394
			public byte Alpha;
		}

		// Token: 0x0200007F RID: 127
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct BLENDFUNCTION
		{
			// Token: 0x0400018B RID: 395
			public byte BlendOp;

			// Token: 0x0400018C RID: 396
			public byte BlendFlags;

			// Token: 0x0400018D RID: 397
			public byte SourceConstantAlpha;

			// Token: 0x0400018E RID: 398
			public byte AlphaFormat;
		}

		// Token: 0x02000080 RID: 128
		public struct TCHITTESTINFO
		{
			// Token: 0x0400018F RID: 399
			public Point pt;

			// Token: 0x04000190 RID: 400
			public uint flags;
		}

		// Token: 0x02000081 RID: 129
		public struct NCCALCSIZE_PARAMS
		{
			// Token: 0x04000191 RID: 401
			public RECT rect0;

			// Token: 0x04000192 RID: 402
			public RECT rect1;

			// Token: 0x04000193 RID: 403
			public RECT rect2;

			// Token: 0x04000194 RID: 404
			public IntPtr lpPos;
		}

		// Token: 0x02000082 RID: 130
		public struct MINMAXINFO
		{
			// Token: 0x04000195 RID: 405
			public Point ptReserved;

			// Token: 0x04000196 RID: 406
			public Point ptMaxSize;

			// Token: 0x04000197 RID: 407
			public Point ptMaxPosition;

			// Token: 0x04000198 RID: 408
			public Point ptMinTrackSize;

			// Token: 0x04000199 RID: 409
			public Point ptMaxTrackSize;
		}

		// Token: 0x02000083 RID: 131
		public struct APPBARDATA
		{
			// Token: 0x0400019A RID: 410
			public uint cbSize;

			// Token: 0x0400019B RID: 411
			public IntPtr hWnd;

			// Token: 0x0400019C RID: 412
			public uint uCallbackMessage;

			// Token: 0x0400019D RID: 413
			public WinApi.ABE uEdge;

			// Token: 0x0400019E RID: 414
			public RECT rc;

			// Token: 0x0400019F RID: 415
			public int lParam;
		}

		// Token: 0x02000084 RID: 132
		public struct WINDOWPOS
		{
			// Token: 0x040001A0 RID: 416
			public int hwnd;

			// Token: 0x040001A1 RID: 417
			public int hWndInsertAfter;

			// Token: 0x040001A2 RID: 418
			public int x;

			// Token: 0x040001A3 RID: 419
			public int y;

			// Token: 0x040001A4 RID: 420
			public int cx;

			// Token: 0x040001A5 RID: 421
			public int cy;

			// Token: 0x040001A6 RID: 422
			public int flags;
		}

		// Token: 0x02000085 RID: 133
		public enum ABM : uint
		{
			// Token: 0x040001A8 RID: 424
			New,
			// Token: 0x040001A9 RID: 425
			Remove,
			// Token: 0x040001AA RID: 426
			QueryPos,
			// Token: 0x040001AB RID: 427
			SetPos,
			// Token: 0x040001AC RID: 428
			GetState,
			// Token: 0x040001AD RID: 429
			GetTaskbarPos,
			// Token: 0x040001AE RID: 430
			Activate,
			// Token: 0x040001AF RID: 431
			GetAutoHideBar,
			// Token: 0x040001B0 RID: 432
			SetAutoHideBar,
			// Token: 0x040001B1 RID: 433
			WindowPosChanged,
			// Token: 0x040001B2 RID: 434
			SetState
		}

		// Token: 0x02000086 RID: 134
		public enum ABE : uint
		{
			// Token: 0x040001B4 RID: 436
			Left,
			// Token: 0x040001B5 RID: 437
			Top,
			// Token: 0x040001B6 RID: 438
			Right,
			// Token: 0x040001B7 RID: 439
			Bottom
		}

		// Token: 0x02000087 RID: 135
		public enum ScrollBar
		{
			// Token: 0x040001B9 RID: 441
			SB_HORZ,
			// Token: 0x040001BA RID: 442
			SB_VERT,
			// Token: 0x040001BB RID: 443
			SB_CTL,
			// Token: 0x040001BC RID: 444
			SB_BOTH
		}

		// Token: 0x02000088 RID: 136
		public enum HitTest
		{
			// Token: 0x040001BE RID: 446
			HTNOWHERE,
			// Token: 0x040001BF RID: 447
			HTCLIENT,
			// Token: 0x040001C0 RID: 448
			HTCAPTION,
			// Token: 0x040001C1 RID: 449
			HTGROWBOX = 4,
			// Token: 0x040001C2 RID: 450
			HTSIZE = 4,
			// Token: 0x040001C3 RID: 451
			HTMINBUTTON = 8,
			// Token: 0x040001C4 RID: 452
			HTMAXBUTTON,
			// Token: 0x040001C5 RID: 453
			HTLEFT,
			// Token: 0x040001C6 RID: 454
			HTRIGHT,
			// Token: 0x040001C7 RID: 455
			HTTOP,
			// Token: 0x040001C8 RID: 456
			HTTOPLEFT,
			// Token: 0x040001C9 RID: 457
			HTTOPRIGHT,
			// Token: 0x040001CA RID: 458
			HTBOTTOM,
			// Token: 0x040001CB RID: 459
			HTBOTTOMLEFT,
			// Token: 0x040001CC RID: 460
			HTBOTTOMRIGHT,
			// Token: 0x040001CD RID: 461
			HTREDUCE = 8,
			// Token: 0x040001CE RID: 462
			HTZOOM,
			// Token: 0x040001CF RID: 463
			HTSIZEFIRST,
			// Token: 0x040001D0 RID: 464
			HTSIZELAST = 17,
			// Token: 0x040001D1 RID: 465
			HTTRANSPARENT = -1
		}

		// Token: 0x02000089 RID: 137
		public enum TabControlHitTest
		{
			// Token: 0x040001D3 RID: 467
			TCHT_NOWHERE = 1
		}

		// Token: 0x0200008A RID: 138
		internal static class Messages
		{
			// Token: 0x040001D4 RID: 468
			public const int WM_NULL = 0;

			// Token: 0x040001D5 RID: 469
			public const int WM_CREATE = 1;

			// Token: 0x040001D6 RID: 470
			public const int WM_DESTROY = 2;

			// Token: 0x040001D7 RID: 471
			public const int WM_MOVE = 3;

			// Token: 0x040001D8 RID: 472
			public const int WM_SIZE = 5;

			// Token: 0x040001D9 RID: 473
			public const int WM_ACTIVATE = 6;

			// Token: 0x040001DA RID: 474
			public const int WM_SETFOCUS = 7;

			// Token: 0x040001DB RID: 475
			public const int WM_KILLFOCUS = 8;

			// Token: 0x040001DC RID: 476
			public const int WM_ENABLE = 10;

			// Token: 0x040001DD RID: 477
			public const int WM_SETREDRAW = 11;

			// Token: 0x040001DE RID: 478
			public const int WM_SETTEXT = 12;

			// Token: 0x040001DF RID: 479
			public const int WM_GETTEXT = 13;

			// Token: 0x040001E0 RID: 480
			public const int WM_GETTEXTLENGTH = 14;

			// Token: 0x040001E1 RID: 481
			public const int WM_PAINT = 15;

			// Token: 0x040001E2 RID: 482
			public const int WM_CLOSE = 16;

			// Token: 0x040001E3 RID: 483
			public const int WM_QUERYENDSESSION = 17;

			// Token: 0x040001E4 RID: 484
			public const int WM_QUERYOPEN = 19;

			// Token: 0x040001E5 RID: 485
			public const int WM_ENDSESSION = 22;

			// Token: 0x040001E6 RID: 486
			public const int WM_QUIT = 18;

			// Token: 0x040001E7 RID: 487
			public const int WM_ERASEBKGND = 20;

			// Token: 0x040001E8 RID: 488
			public const int WM_SYSCOLORCHANGE = 21;

			// Token: 0x040001E9 RID: 489
			public const int WM_SHOWWINDOW = 24;

			// Token: 0x040001EA RID: 490
			public const int WM_WININICHANGE = 26;

			// Token: 0x040001EB RID: 491
			public const int WM_SETTINGCHANGE = 26;

			// Token: 0x040001EC RID: 492
			public const int WM_DEVMODECHANGE = 27;

			// Token: 0x040001ED RID: 493
			public const int WM_ACTIVATEAPP = 28;

			// Token: 0x040001EE RID: 494
			public const int WM_FONTCHANGE = 29;

			// Token: 0x040001EF RID: 495
			public const int WM_TIMECHANGE = 30;

			// Token: 0x040001F0 RID: 496
			public const int WM_CANCELMODE = 31;

			// Token: 0x040001F1 RID: 497
			public const int WM_SETCURSOR = 32;

			// Token: 0x040001F2 RID: 498
			public const int WM_MOUSEACTIVATE = 33;

			// Token: 0x040001F3 RID: 499
			public const int WM_CHILDACTIVATE = 34;

			// Token: 0x040001F4 RID: 500
			public const int WM_QUEUESYNC = 35;

			// Token: 0x040001F5 RID: 501
			public const int WM_GETMINMAXINFO = 36;

			// Token: 0x040001F6 RID: 502
			public const int WM_PAINTICON = 38;

			// Token: 0x040001F7 RID: 503
			public const int WM_ICONERASEBKGND = 39;

			// Token: 0x040001F8 RID: 504
			public const int WM_NEXTDLGCTL = 40;

			// Token: 0x040001F9 RID: 505
			public const int WM_SPOOLERSTATUS = 42;

			// Token: 0x040001FA RID: 506
			public const int WM_DRAWITEM = 43;

			// Token: 0x040001FB RID: 507
			public const int WM_MEASUREITEM = 44;

			// Token: 0x040001FC RID: 508
			public const int WM_DELETEITEM = 45;

			// Token: 0x040001FD RID: 509
			public const int WM_VKEYTOITEM = 46;

			// Token: 0x040001FE RID: 510
			public const int WM_CHARTOITEM = 47;

			// Token: 0x040001FF RID: 511
			public const int WM_SETFONT = 48;

			// Token: 0x04000200 RID: 512
			public const int WM_GETFONT = 49;

			// Token: 0x04000201 RID: 513
			public const int WM_SETHOTKEY = 50;

			// Token: 0x04000202 RID: 514
			public const int WM_GETHOTKEY = 51;

			// Token: 0x04000203 RID: 515
			public const int WM_QUERYDRAGICON = 55;

			// Token: 0x04000204 RID: 516
			public const int WM_COMPAREITEM = 57;

			// Token: 0x04000205 RID: 517
			public const int WM_GETOBJECT = 61;

			// Token: 0x04000206 RID: 518
			public const int WM_COMPACTING = 65;

			// Token: 0x04000207 RID: 519
			public const int WM_COMMNOTIFY = 68;

			// Token: 0x04000208 RID: 520
			public const int WM_WINDOWPOSCHANGING = 70;

			// Token: 0x04000209 RID: 521
			public const int WM_WINDOWPOSCHANGED = 71;

			// Token: 0x0400020A RID: 522
			public const int WM_POWER = 72;

			// Token: 0x0400020B RID: 523
			public const int WM_COPYDATA = 74;

			// Token: 0x0400020C RID: 524
			public const int WM_CANCELJOURNAL = 75;

			// Token: 0x0400020D RID: 525
			public const int WM_NOTIFY = 78;

			// Token: 0x0400020E RID: 526
			public const int WM_INPUTLANGCHANGEREQUEST = 80;

			// Token: 0x0400020F RID: 527
			public const int WM_INPUTLANGCHANGE = 81;

			// Token: 0x04000210 RID: 528
			public const int WM_TCARD = 82;

			// Token: 0x04000211 RID: 529
			public const int WM_HELP = 83;

			// Token: 0x04000212 RID: 530
			public const int WM_USERCHANGED = 84;

			// Token: 0x04000213 RID: 531
			public const int WM_NOTIFYFORMAT = 85;

			// Token: 0x04000214 RID: 532
			public const int WM_CONTEXTMENU = 123;

			// Token: 0x04000215 RID: 533
			public const int WM_STYLECHANGING = 124;

			// Token: 0x04000216 RID: 534
			public const int WM_STYLECHANGED = 125;

			// Token: 0x04000217 RID: 535
			public const int WM_DISPLAYCHANGE = 126;

			// Token: 0x04000218 RID: 536
			public const int WM_GETICON = 127;

			// Token: 0x04000219 RID: 537
			public const int WM_SETICON = 128;

			// Token: 0x0400021A RID: 538
			public const int WM_NCCREATE = 129;

			// Token: 0x0400021B RID: 539
			public const int WM_NCDESTROY = 130;

			// Token: 0x0400021C RID: 540
			public const int WM_NCCALCSIZE = 131;

			// Token: 0x0400021D RID: 541
			public const int WM_NCHITTEST = 132;

			// Token: 0x0400021E RID: 542
			public const int WM_NCPAINT = 133;

			// Token: 0x0400021F RID: 543
			public const int WM_NCACTIVATE = 134;

			// Token: 0x04000220 RID: 544
			public const int WM_GETDLGCODE = 135;

			// Token: 0x04000221 RID: 545
			public const int WM_SYNCPAINT = 136;

			// Token: 0x04000222 RID: 546
			public const int WM_NCMOUSEMOVE = 160;

			// Token: 0x04000223 RID: 547
			public const int WM_NCLBUTTONDOWN = 161;

			// Token: 0x04000224 RID: 548
			public const int WM_NCLBUTTONUP = 162;

			// Token: 0x04000225 RID: 549
			public const int WM_NCLBUTTONDBLCLK = 163;

			// Token: 0x04000226 RID: 550
			public const int WM_NCRBUTTONDOWN = 164;

			// Token: 0x04000227 RID: 551
			public const int WM_NCRBUTTONUP = 165;

			// Token: 0x04000228 RID: 552
			public const int WM_NCRBUTTONDBLCLK = 166;

			// Token: 0x04000229 RID: 553
			public const int WM_NCMBUTTONDOWN = 167;

			// Token: 0x0400022A RID: 554
			public const int WM_NCMBUTTONUP = 168;

			// Token: 0x0400022B RID: 555
			public const int WM_NCMBUTTONDBLCLK = 169;

			// Token: 0x0400022C RID: 556
			public const int WM_NCXBUTTONDOWN = 171;

			// Token: 0x0400022D RID: 557
			public const int WM_NCXBUTTONUP = 172;

			// Token: 0x0400022E RID: 558
			public const int WM_NCXBUTTONDBLCLK = 173;

			// Token: 0x0400022F RID: 559
			public const int WM_INPUT = 255;

			// Token: 0x04000230 RID: 560
			public const int WM_KEYFIRST = 256;

			// Token: 0x04000231 RID: 561
			public const int WM_KEYDOWN = 256;

			// Token: 0x04000232 RID: 562
			public const int WM_KEYUP = 257;

			// Token: 0x04000233 RID: 563
			public const int WM_CHAR = 258;

			// Token: 0x04000234 RID: 564
			public const int WM_DEADCHAR = 259;

			// Token: 0x04000235 RID: 565
			public const int WM_SYSKEYDOWN = 260;

			// Token: 0x04000236 RID: 566
			public const int WM_SYSKEYUP = 261;

			// Token: 0x04000237 RID: 567
			public const int WM_SYSCHAR = 262;

			// Token: 0x04000238 RID: 568
			public const int WM_SYSDEADCHAR = 263;

			// Token: 0x04000239 RID: 569
			public const int WM_UNICHAR = 265;

			// Token: 0x0400023A RID: 570
			public const int WM_KEYLAST = 264;

			// Token: 0x0400023B RID: 571
			public const int WM_IME_STARTCOMPOSITION = 269;

			// Token: 0x0400023C RID: 572
			public const int WM_IME_ENDCOMPOSITION = 270;

			// Token: 0x0400023D RID: 573
			public const int WM_IME_COMPOSITION = 271;

			// Token: 0x0400023E RID: 574
			public const int WM_IME_KEYLAST = 271;

			// Token: 0x0400023F RID: 575
			public const int WM_INITDIALOG = 272;

			// Token: 0x04000240 RID: 576
			public const int WM_COMMAND = 273;

			// Token: 0x04000241 RID: 577
			public const int WM_SYSCOMMAND = 274;

			// Token: 0x04000242 RID: 578
			public const int WM_TIMER = 275;

			// Token: 0x04000243 RID: 579
			public const int WM_HSCROLL = 276;

			// Token: 0x04000244 RID: 580
			public const int WM_VSCROLL = 277;

			// Token: 0x04000245 RID: 581
			public const int WM_INITMENU = 278;

			// Token: 0x04000246 RID: 582
			public const int WM_INITMENUPOPUP = 279;

			// Token: 0x04000247 RID: 583
			public const int WM_MENUSELECT = 287;

			// Token: 0x04000248 RID: 584
			public const int WM_MENUCHAR = 288;

			// Token: 0x04000249 RID: 585
			public const int WM_ENTERIDLE = 289;

			// Token: 0x0400024A RID: 586
			public const int WM_MENURBUTTONUP = 290;

			// Token: 0x0400024B RID: 587
			public const int WM_MENUDRAG = 291;

			// Token: 0x0400024C RID: 588
			public const int WM_MENUGETOBJECT = 292;

			// Token: 0x0400024D RID: 589
			public const int WM_UNINITMENUPOPUP = 293;

			// Token: 0x0400024E RID: 590
			public const int WM_MENUCOMMAND = 294;

			// Token: 0x0400024F RID: 591
			public const int WM_CHANGEUISTATE = 295;

			// Token: 0x04000250 RID: 592
			public const int WM_UPDATEUISTATE = 296;

			// Token: 0x04000251 RID: 593
			public const int WM_QUERYUISTATE = 297;

			// Token: 0x04000252 RID: 594
			public const int WM_CTLCOLOR = 25;

			// Token: 0x04000253 RID: 595
			public const int WM_CTLCOLORMSGBOX = 306;

			// Token: 0x04000254 RID: 596
			public const int WM_CTLCOLOREDIT = 307;

			// Token: 0x04000255 RID: 597
			public const int WM_CTLCOLORLISTBOX = 308;

			// Token: 0x04000256 RID: 598
			public const int WM_CTLCOLORBTN = 309;

			// Token: 0x04000257 RID: 599
			public const int WM_CTLCOLORDLG = 310;

			// Token: 0x04000258 RID: 600
			public const int WM_CTLCOLORSCROLLBAR = 311;

			// Token: 0x04000259 RID: 601
			public const int WM_CTLCOLORSTATIC = 312;

			// Token: 0x0400025A RID: 602
			public const int WM_MOUSEFIRST = 512;

			// Token: 0x0400025B RID: 603
			public const int WM_MOUSEMOVE = 512;

			// Token: 0x0400025C RID: 604
			public const int WM_LBUTTONDOWN = 513;

			// Token: 0x0400025D RID: 605
			public const int WM_LBUTTONUP = 514;

			// Token: 0x0400025E RID: 606
			public const int WM_LBUTTONDBLCLK = 515;

			// Token: 0x0400025F RID: 607
			public const int WM_RBUTTONDOWN = 516;

			// Token: 0x04000260 RID: 608
			public const int WM_RBUTTONUP = 517;

			// Token: 0x04000261 RID: 609
			public const int WM_RBUTTONDBLCLK = 518;

			// Token: 0x04000262 RID: 610
			public const int WM_MBUTTONDOWN = 519;

			// Token: 0x04000263 RID: 611
			public const int WM_MBUTTONUP = 520;

			// Token: 0x04000264 RID: 612
			public const int WM_MBUTTONDBLCLK = 521;

			// Token: 0x04000265 RID: 613
			public const int WM_MOUSEWHEEL = 522;

			// Token: 0x04000266 RID: 614
			public const int WM_XBUTTONDOWN = 523;

			// Token: 0x04000267 RID: 615
			public const int WM_XBUTTONUP = 524;

			// Token: 0x04000268 RID: 616
			public const int WM_XBUTTONDBLCLK = 525;

			// Token: 0x04000269 RID: 617
			public const int WM_MOUSELAST = 525;

			// Token: 0x0400026A RID: 618
			public const int WM_PARENTNOTIFY = 528;

			// Token: 0x0400026B RID: 619
			public const int WM_ENTERMENULOOP = 529;

			// Token: 0x0400026C RID: 620
			public const int WM_EXITMENULOOP = 530;

			// Token: 0x0400026D RID: 621
			public const int WM_NEXTMENU = 531;

			// Token: 0x0400026E RID: 622
			public const int WM_SIZING = 532;

			// Token: 0x0400026F RID: 623
			public const int WM_CAPTURECHANGED = 533;

			// Token: 0x04000270 RID: 624
			public const int WM_MOVING = 534;

			// Token: 0x04000271 RID: 625
			public const int WM_POWERBROADCAST = 536;

			// Token: 0x04000272 RID: 626
			public const int WM_DEVICECHANGE = 537;

			// Token: 0x04000273 RID: 627
			public const int WM_MDICREATE = 544;

			// Token: 0x04000274 RID: 628
			public const int WM_MDIDESTROY = 545;

			// Token: 0x04000275 RID: 629
			public const int WM_MDIACTIVATE = 546;

			// Token: 0x04000276 RID: 630
			public const int WM_MDIRESTORE = 547;

			// Token: 0x04000277 RID: 631
			public const int WM_MDINEXT = 548;

			// Token: 0x04000278 RID: 632
			public const int WM_MDIMAXIMIZE = 549;

			// Token: 0x04000279 RID: 633
			public const int WM_MDITILE = 550;

			// Token: 0x0400027A RID: 634
			public const int WM_MDICASCADE = 551;

			// Token: 0x0400027B RID: 635
			public const int WM_MDIICONARRANGE = 552;

			// Token: 0x0400027C RID: 636
			public const int WM_MDIGETACTIVE = 553;

			// Token: 0x0400027D RID: 637
			public const int WM_MDISETMENU = 560;

			// Token: 0x0400027E RID: 638
			public const int WM_ENTERSIZEMOVE = 561;

			// Token: 0x0400027F RID: 639
			public const int WM_EXITSIZEMOVE = 562;

			// Token: 0x04000280 RID: 640
			public const int WM_DROPFILES = 563;

			// Token: 0x04000281 RID: 641
			public const int WM_MDIREFRESHMENU = 564;

			// Token: 0x04000282 RID: 642
			public const int WM_IME_SETCONTEXT = 641;

			// Token: 0x04000283 RID: 643
			public const int WM_IME_NOTIFY = 642;

			// Token: 0x04000284 RID: 644
			public const int WM_IME_CONTROL = 643;

			// Token: 0x04000285 RID: 645
			public const int WM_IME_COMPOSITIONFULL = 644;

			// Token: 0x04000286 RID: 646
			public const int WM_IME_SELECT = 645;

			// Token: 0x04000287 RID: 647
			public const int WM_IME_CHAR = 646;

			// Token: 0x04000288 RID: 648
			public const int WM_IME_REQUEST = 648;

			// Token: 0x04000289 RID: 649
			public const int WM_IME_KEYDOWN = 656;

			// Token: 0x0400028A RID: 650
			public const int WM_IME_KEYUP = 657;

			// Token: 0x0400028B RID: 651
			public const int WM_MOUSEHOVER = 673;

			// Token: 0x0400028C RID: 652
			public const int WM_MOUSELEAVE = 675;

			// Token: 0x0400028D RID: 653
			public const int WM_NCMOUSELEAVE = 674;

			// Token: 0x0400028E RID: 654
			public const int WM_WTSSESSION_CHANGE = 689;

			// Token: 0x0400028F RID: 655
			public const int WM_TABLET_FIRST = 704;

			// Token: 0x04000290 RID: 656
			public const int WM_TABLET_LAST = 735;

			// Token: 0x04000291 RID: 657
			public const int WM_CUT = 768;

			// Token: 0x04000292 RID: 658
			public const int WM_COPY = 769;

			// Token: 0x04000293 RID: 659
			public const int WM_PASTE = 770;

			// Token: 0x04000294 RID: 660
			public const int WM_CLEAR = 771;

			// Token: 0x04000295 RID: 661
			public const int WM_UNDO = 772;

			// Token: 0x04000296 RID: 662
			public const int WM_RENDERFORMAT = 773;

			// Token: 0x04000297 RID: 663
			public const int WM_RENDERALLFORMATS = 774;

			// Token: 0x04000298 RID: 664
			public const int WM_DESTROYCLIPBOARD = 775;

			// Token: 0x04000299 RID: 665
			public const int WM_DRAWCLIPBOARD = 776;

			// Token: 0x0400029A RID: 666
			public const int WM_PAINTCLIPBOARD = 777;

			// Token: 0x0400029B RID: 667
			public const int WM_VSCROLLCLIPBOARD = 778;

			// Token: 0x0400029C RID: 668
			public const int WM_SIZECLIPBOARD = 779;

			// Token: 0x0400029D RID: 669
			public const int WM_ASKCBFORMATNAME = 780;

			// Token: 0x0400029E RID: 670
			public const int WM_CHANGECBCHAIN = 781;

			// Token: 0x0400029F RID: 671
			public const int WM_HSCROLLCLIPBOARD = 782;

			// Token: 0x040002A0 RID: 672
			public const int WM_QUERYNEWPALETTE = 783;

			// Token: 0x040002A1 RID: 673
			public const int WM_PALETTEISCHANGING = 784;

			// Token: 0x040002A2 RID: 674
			public const int WM_PALETTECHANGED = 785;

			// Token: 0x040002A3 RID: 675
			public const int WM_HOTKEY = 786;

			// Token: 0x040002A4 RID: 676
			public const int WM_PRINT = 791;

			// Token: 0x040002A5 RID: 677
			public const int WM_PRINTCLIENT = 792;

			// Token: 0x040002A6 RID: 678
			public const int WM_APPCOMMAND = 793;

			// Token: 0x040002A7 RID: 679
			public const int WM_THEMECHANGED = 794;

			// Token: 0x040002A8 RID: 680
			public const int WM_HANDHELDFIRST = 856;

			// Token: 0x040002A9 RID: 681
			public const int WM_HANDHELDLAST = 863;

			// Token: 0x040002AA RID: 682
			public const int WM_AFXFIRST = 864;

			// Token: 0x040002AB RID: 683
			public const int WM_AFXLAST = 895;

			// Token: 0x040002AC RID: 684
			public const int WM_PENWINFIRST = 896;

			// Token: 0x040002AD RID: 685
			public const int WM_PENWINLAST = 911;

			// Token: 0x040002AE RID: 686
			public const int WM_USER = 1024;

			// Token: 0x040002AF RID: 687
			public const int WM_REFLECT = 8192;

			// Token: 0x040002B0 RID: 688
			public const int WM_APP = 32768;

			// Token: 0x040002B1 RID: 689
			public const int WM_DWMCOMPOSITIONCHANGED = 798;

			// Token: 0x040002B2 RID: 690
			public const int SC_MOVE = 61456;

			// Token: 0x040002B3 RID: 691
			public const int SC_MINIMIZE = 61472;

			// Token: 0x040002B4 RID: 692
			public const int SC_MAXIMIZE = 61488;

			// Token: 0x040002B5 RID: 693
			public const int SC_RESTORE = 61728;
		}

		// Token: 0x0200008B RID: 139
		public enum Bool
		{
			// Token: 0x040002B7 RID: 695
			False,
			// Token: 0x040002B8 RID: 696
			True
		}
	}
}
