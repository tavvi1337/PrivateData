using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Security;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MetroFramework.Controls;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;
using MetroFramework.Native;

namespace MetroFramework.Forms
{
	// Token: 0x02000058 RID: 88
	public partial class MetroForm : MetroFormBase, IMetroForm, IMetroContainerControl, IContainerControl, IMetroControl, IMetroComponent, IDisposable, IMetroStyledComponent
	{
		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060003B2 RID: 946 RVA: 0x0000C6E5 File Offset: 0x0000A8E5
		// (set) Token: 0x060003B3 RID: 947 RVA: 0x0000C6ED File Offset: 0x0000A8ED
		[Browsable(true)]
		[Category("Metro Appearance")]
		public HorizontalAlign TextAlign
		{
			get
			{
				return this.textAlign;
			}
			set
			{
				this.textAlign = value;
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x0000C6F6 File Offset: 0x0000A8F6
		[Browsable(false)]
		public override Color BackColor
		{
			get
			{
				return MetroPaint.BackColor.Form(base.Theme);
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x0000C703 File Offset: 0x0000A903
		// (set) Token: 0x060003B6 RID: 950 RVA: 0x0000C70B File Offset: 0x0000A90B
		[DefaultValue(MetroBorderStyle.None)]
		[Browsable(true)]
		[Category("Metro Appearance")]
		public MetroBorderStyle BorderStyle
		{
			get
			{
				return this._borderStyle;
			}
			set
			{
				this._borderStyle = value;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060003B7 RID: 951 RVA: 0x0000C714 File Offset: 0x0000A914
		// (set) Token: 0x060003B8 RID: 952 RVA: 0x0000C71C File Offset: 0x0000A91C
		[Category("Metro Appearance")]
		public bool Movable
		{
			get
			{
				return this.isMovable;
			}
			set
			{
				this.isMovable = value;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060003B9 RID: 953 RVA: 0x0000C725 File Offset: 0x0000A925
		// (set) Token: 0x060003BA RID: 954 RVA: 0x0000C72D File Offset: 0x0000A92D
		public new Padding Padding
		{
			get
			{
				return base.Padding;
			}
			set
			{
				value.Top = Math.Max(value.Top, this.DisplayHeader ? 60 : 30);
				base.Padding = value;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060003BB RID: 955 RVA: 0x0000C757 File Offset: 0x0000A957
		protected override Padding DefaultPadding
		{
			get
			{
				return new Padding(20, this.DisplayHeader ? 60 : 20, 20, 20);
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060003BC RID: 956 RVA: 0x0000C772 File Offset: 0x0000A972
		// (set) Token: 0x060003BD RID: 957 RVA: 0x0000C77C File Offset: 0x0000A97C
		[Category("Metro Appearance")]
		[DefaultValue(true)]
		public bool DisplayHeader
		{
			get
			{
				return this.displayHeader;
			}
			set
			{
				if (value != this.displayHeader)
				{
					Padding padding = base.Padding;
					padding.Top += (value ? 30 : -30);
					base.Padding = padding;
				}
				this.displayHeader = value;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060003BE RID: 958 RVA: 0x0000C7BE File Offset: 0x0000A9BE
		// (set) Token: 0x060003BF RID: 959 RVA: 0x0000C7C6 File Offset: 0x0000A9C6
		[Category("Metro Appearance")]
		public bool Resizable
		{
			get
			{
				return this.isResizable;
			}
			set
			{
				this.isResizable = value;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x0000C7CF File Offset: 0x0000A9CF
		// (set) Token: 0x060003C1 RID: 961 RVA: 0x0000C7D7 File Offset: 0x0000A9D7
		[Category("Metro Appearance")]
		[DefaultValue(MetroForm.MetroFormShadowType.AeroShadow)]
		public MetroForm.MetroFormShadowType ShadowType
		{
			get
			{
				return this.shadowType;
			}
			set
			{
				this.shadowType = value;
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x0000C7E0 File Offset: 0x0000A9E0
		// (set) Token: 0x060003C3 RID: 963 RVA: 0x0000C7E8 File Offset: 0x0000A9E8
		public new Form MdiParent
		{
			get
			{
				return base.MdiParent;
			}
			set
			{
				if (value != null)
				{
					this.RemoveShadow();
					this.shadowType = MetroForm.MetroFormShadowType.None;
				}
				base.MdiParent = value;
			}
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0000C804 File Offset: 0x0000AA04
		public MetroForm()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "MetroForm";
			base.StartPosition = FormStartPosition.CenterScreen;
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0000C86C File Offset: 0x0000AA6C
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			Color color = MetroPaint.BackColor.Form(base.Theme);
			Color foreColor = MetroPaint.ForeColor.Form(base.Theme);
			e.Graphics.Clear(color);
			using (SolidBrush styleBrush = MetroPaint.GetStyleBrush(base.Style))
			{
				Rectangle rect = new Rectangle(0, 0, base.Width, 5);
				e.Graphics.FillRectangle(styleBrush, rect);
			}
			if (this.BorderStyle != MetroBorderStyle.None)
			{
				Color color2 = MetroPaint.BorderColor.Form(base.Theme);
				using (Pen pen = new Pen(color2))
				{
					e.Graphics.DrawLines(pen, new Point[]
					{
						new Point(0, 5),
						new Point(0, base.Height - 1),
						new Point(base.Width - 1, base.Height - 1),
						new Point(base.Width - 1, 5)
					});
				}
			}
			if (this.displayHeader)
			{
				TextRenderingHint textRenderingHint = e.Graphics.TextRenderingHint;
				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
				e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				Rectangle bounds = new Rectangle(20, 20, base.ClientRectangle.Width - 40, 40);
				TextFormatFlags flags = TextFormatFlags.EndEllipsis | this.GetTextFormatFlags();
				TextRenderer.DrawText(e.Graphics, this.Text, MetroFonts.Title, bounds, foreColor, flags);
				e.Graphics.TextRenderingHint = textRenderingHint;
				e.Graphics.SmoothingMode = smoothingMode;
			}
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0000CA48 File Offset: 0x0000AC48
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (this.Resizable && (base.SizeGripStyle == SizeGripStyle.Auto || base.SizeGripStyle == SizeGripStyle.Show))
			{
				using (SolidBrush solidBrush = new SolidBrush(MetroPaint.ForeColor.Button.Disabled(base.Theme)))
				{
					Size size = new Size(2, 2);
					e.Graphics.FillRectangles(solidBrush, new Rectangle[]
					{
						new Rectangle(new Point(base.ClientRectangle.Width - 6, base.ClientRectangle.Height - 6), size),
						new Rectangle(new Point(base.ClientRectangle.Width - 10, base.ClientRectangle.Height - 10), size),
						new Rectangle(new Point(base.ClientRectangle.Width - 10, base.ClientRectangle.Height - 6), size),
						new Rectangle(new Point(base.ClientRectangle.Width - 6, base.ClientRectangle.Height - 10), size),
						new Rectangle(new Point(base.ClientRectangle.Width - 14, base.ClientRectangle.Height - 6), size),
						new Rectangle(new Point(base.ClientRectangle.Width - 6, base.ClientRectangle.Height - 14), size)
					});
				}
			}
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0000CC2C File Offset: 0x0000AE2C
		private TextFormatFlags GetTextFormatFlags()
		{
			switch (this.TextAlign)
			{
			case HorizontalAlign.Left:
				return TextFormatFlags.Default;
			case HorizontalAlign.Center:
				return TextFormatFlags.HorizontalCenter;
			case HorizontalAlign.Right:
				return TextFormatFlags.Right;
			default:
				throw new InvalidOperationException();
			}
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0000CC5F File Offset: 0x0000AE5F
		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			if (!e.Cancel && !(this is MetroTaskWindow))
			{
				MetroTaskWindow.ForceClose();
			}
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0000CC7D File Offset: 0x0000AE7D
		protected override void OnClosed(EventArgs e)
		{
			this.RemoveShadow();
			base.OnClosed(e);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0000CC8C File Offset: 0x0000AE8C
		[SecuritySafeCritical]
		public bool FocusMe()
		{
			return WinApi.SetForegroundWindow(base.Handle);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x0000CC99 File Offset: 0x0000AE99
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			if (base.DesignMode)
			{
				return;
			}
			this.CreateShadow();
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0000CCB4 File Offset: 0x0000AEB4
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			if (base.DesignMode)
			{
				return;
			}
			FormStartPosition startPosition = base.StartPosition;
			if (startPosition != FormStartPosition.CenterScreen)
			{
				if (startPosition == FormStartPosition.CenterParent)
				{
					base.CenterToParent();
				}
			}
			else if (base.IsMdiChild)
			{
				base.CenterToParent();
			}
			else
			{
				base.CenterToScreen();
			}
			this.RemoveCloseButton();
			if (base.ControlBox)
			{
				this.AddWindowButton(MetroForm.WindowButtons.Close);
				if (base.MaximizeBox)
				{
					this.AddWindowButton(MetroForm.WindowButtons.Maximize);
				}
				if (base.MinimizeBox)
				{
					this.AddWindowButton(MetroForm.WindowButtons.Minimize);
				}
				this.UpdateWindowButtonPosition();
			}
		}

		// Token: 0x060003CE RID: 974 RVA: 0x0000CD37 File Offset: 0x0000AF37
		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
			bool designMode = base.DesignMode;
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0000CD47 File Offset: 0x0000AF47
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			base.Invalidate();
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0000CD56 File Offset: 0x0000AF56
		protected override void OnResizeEnd(EventArgs e)
		{
			base.OnResizeEnd(e);
			this.UpdateWindowButtonPosition();
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0000CD68 File Offset: 0x0000AF68
		protected override void WndProc(ref Message m)
		{
			if (base.DesignMode)
			{
				base.WndProc(ref m);
				return;
			}
			int msg = m.Msg;
			if (msg <= 163)
			{
				if (msg != 132)
				{
					if (msg != 163)
					{
						goto IL_B8;
					}
				}
				else
				{
					WinApi.HitTest hitTest = this.HitTestNCA(m.HWnd, m.WParam, m.LParam);
					if (hitTest != WinApi.HitTest.HTCLIENT)
					{
						m.Result = (IntPtr)((long)hitTest);
						return;
					}
					goto IL_B8;
				}
			}
			else if (msg != 274)
			{
				if (msg != 515)
				{
					goto IL_B8;
				}
			}
			else
			{
				int num = m.WParam.ToInt32() & 65520;
				int num2 = num;
				if (num2 != 61456)
				{
					if (num2 != 61488 && num2 != 61728)
					{
						goto IL_B8;
					}
					goto IL_B8;
				}
				else
				{
					if (!this.Movable)
					{
						return;
					}
					goto IL_B8;
				}
			}
			if (!base.MaximizeBox)
			{
				return;
			}
			IL_B8:
			base.WndProc(ref m);
			int msg2 = m.Msg;
			if (msg2 != 36)
			{
				return;
			}
			this.OnGetMinMaxInfo(m.HWnd, m.LParam);
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0000CE58 File Offset: 0x0000B058
		[SecuritySafeCritical]
		private unsafe void OnGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
		{
			WinApi.MINMAXINFO* ptr = (WinApi.MINMAXINFO*)((void*)lParam);
			Screen screen = Screen.FromHandle(hwnd);
			ptr->ptMaxSize.X = screen.WorkingArea.Width;
			ptr->ptMaxSize.Y = screen.WorkingArea.Height;
			ptr->ptMaxPosition.X = Math.Abs(screen.WorkingArea.Left - screen.Bounds.Left);
			ptr->ptMaxPosition.Y = Math.Abs(screen.WorkingArea.Top - screen.Bounds.Top);
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0000CF04 File Offset: 0x0000B104
		private WinApi.HitTest HitTestNCA(IntPtr hwnd, IntPtr wparam, IntPtr lparam)
		{
			Point pt = new Point((int)((short)((int)lparam)), (int)((short)((int)lparam >> 16)));
			int num = Math.Max(this.Padding.Right, this.Padding.Bottom);
			if (this.Resizable && base.RectangleToScreen(new Rectangle(base.ClientRectangle.Width - num, base.ClientRectangle.Height - num, num, num)).Contains(pt))
			{
				return WinApi.HitTest.HTBOTTOMRIGHT;
			}
			if (base.RectangleToScreen(new Rectangle(5, 5, base.ClientRectangle.Width - 10, 50)).Contains(pt))
			{
				return WinApi.HitTest.HTCAPTION;
			}
			return WinApi.HitTest.HTCLIENT;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0000CFC4 File Offset: 0x0000B1C4
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left && this.Movable)
			{
				if (base.WindowState == FormWindowState.Maximized)
				{
					return;
				}
				if (base.Width - 5 > e.Location.X && e.Location.X > 5 && e.Location.Y > 5)
				{
					this.MoveControl();
				}
			}
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0000D037 File Offset: 0x0000B237
		[SecuritySafeCritical]
		private void MoveControl()
		{
			WinApi.ReleaseCapture();
			WinApi.SendMessage(base.Handle, 161, 2, 0);
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0000D054 File Offset: 0x0000B254
		private void AddWindowButton(MetroForm.WindowButtons button)
		{
			if (this.windowButtonList == null)
			{
				this.windowButtonList = new Dictionary<MetroForm.WindowButtons, MetroForm.MetroFormButton>();
			}
			if (this.windowButtonList.ContainsKey(button))
			{
				return;
			}
			MetroForm.MetroFormButton metroFormButton = new MetroForm.MetroFormButton();
			if (button == MetroForm.WindowButtons.Close)
			{
				metroFormButton.Text = "r";
			}
			else if (button == MetroForm.WindowButtons.Minimize)
			{
				metroFormButton.Text = "0";
			}
			else if (button == MetroForm.WindowButtons.Maximize)
			{
				if (base.WindowState == FormWindowState.Normal)
				{
					metroFormButton.Text = "1";
				}
				else
				{
					metroFormButton.Text = "2";
				}
			}
			metroFormButton.Tag = button;
			metroFormButton.Size = new Size(25, 20);
			metroFormButton.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			metroFormButton.Click += this.WindowButton_Click;
			base.Controls.Add(metroFormButton);
			this.windowButtonList.Add(button, metroFormButton);
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0000D11C File Offset: 0x0000B31C
		private void WindowButton_Click(object sender, EventArgs e)
		{
			MetroForm.MetroFormButton metroFormButton = sender as MetroForm.MetroFormButton;
			if (metroFormButton != null)
			{
				MetroForm.WindowButtons windowButtons = (MetroForm.WindowButtons)metroFormButton.Tag;
				if (windowButtons == MetroForm.WindowButtons.Close)
				{
					base.Close();
					return;
				}
				if (windowButtons == MetroForm.WindowButtons.Minimize)
				{
					base.WindowState = FormWindowState.Minimized;
					return;
				}
				if (windowButtons == MetroForm.WindowButtons.Maximize)
				{
					if (base.WindowState == FormWindowState.Normal)
					{
						base.WindowState = FormWindowState.Maximized;
						metroFormButton.Text = "2";
						return;
					}
					base.WindowState = FormWindowState.Normal;
					metroFormButton.Text = "1";
				}
			}
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0000D188 File Offset: 0x0000B388
		private void UpdateWindowButtonPosition()
		{
			if (!base.ControlBox)
			{
				return;
			}
			Dictionary<int, MetroForm.WindowButtons> dictionary = new Dictionary<int, MetroForm.WindowButtons>(3)
			{
				{
					0,
					MetroForm.WindowButtons.Close
				},
				{
					1,
					MetroForm.WindowButtons.Maximize
				},
				{
					2,
					MetroForm.WindowButtons.Minimize
				}
			};
			Point location = new Point(base.ClientRectangle.Width - 5 - 25, 5);
			int num = location.X - 25;
			MetroForm.MetroFormButton metroFormButton = null;
			if (this.windowButtonList.Count == 1)
			{
				using (Dictionary<MetroForm.WindowButtons, MetroForm.MetroFormButton>.Enumerator enumerator = this.windowButtonList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<MetroForm.WindowButtons, MetroForm.MetroFormButton> keyValuePair = enumerator.Current;
						keyValuePair.Value.Location = location;
					}
					goto IL_134;
				}
			}
			foreach (KeyValuePair<int, MetroForm.WindowButtons> keyValuePair2 in dictionary)
			{
				bool flag = this.windowButtonList.ContainsKey(keyValuePair2.Value);
				if (metroFormButton == null && flag)
				{
					metroFormButton = this.windowButtonList[keyValuePair2.Value];
					metroFormButton.Location = location;
				}
				else if (metroFormButton != null && flag)
				{
					this.windowButtonList[keyValuePair2.Value].Location = new Point(num, 5);
					num -= 25;
				}
			}
			IL_134:
			this.Refresh();
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x0000D2EC File Offset: 0x0000B4EC
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				if (this.ShadowType == MetroForm.MetroFormShadowType.SystemShadow)
				{
					createParams.ClassStyle |= 131072;
				}
				return createParams;
			}
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0000D31C File Offset: 0x0000B51C
		private void CreateShadow()
		{
			switch (this.ShadowType)
			{
			case MetroForm.MetroFormShadowType.Flat:
				this.shadowForm = new MetroForm.MetroFlatDropShadow(this);
				return;
			case MetroForm.MetroFormShadowType.DropShadow:
				this.shadowForm = new MetroForm.MetroRealisticDropShadow(this);
				return;
			case MetroForm.MetroFormShadowType.SystemShadow:
				break;
			case MetroForm.MetroFormShadowType.AeroShadow:
				this.shadowForm = new MetroForm.MetroAeroDropShadow(this);
				break;
			default:
				return;
			}
		}

		// Token: 0x060003DB RID: 987 RVA: 0x0000D370 File Offset: 0x0000B570
		private void RemoveShadow()
		{
			if (this.shadowForm == null || this.shadowForm.IsDisposed)
			{
				return;
			}
			this.shadowForm.Visible = false;
			base.Owner = this.shadowForm.Owner;
			this.shadowForm.Owner = null;
			this.shadowForm.Dispose();
			this.shadowForm = null;
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0000D3D0 File Offset: 0x0000B5D0
		protected override void SetVisibleCore(bool value)
		{
			if (this._barrierProxyShadowForm)
			{
				return;
			}
			if (this.shadowForm != null)
			{
				this._barrierProxyShadowForm = true;
				try
				{
					this.shadowForm.Visible = value;
				}
				finally
				{
					this._barrierProxyShadowForm = false;
				}
			}
			base.SetVisibleCore(value);
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0000D424 File Offset: 0x0000B624
		[SecuritySafeCritical]
		public void RemoveCloseButton()
		{
			IntPtr systemMenu = WinApi.GetSystemMenu(base.Handle, false);
			if (systemMenu == IntPtr.Zero)
			{
				return;
			}
			int menuItemCount = WinApi.GetMenuItemCount(systemMenu);
			if (menuItemCount <= 0)
			{
				return;
			}
			WinApi.RemoveMenu(systemMenu, (uint)(menuItemCount - 1), 5120u);
			WinApi.RemoveMenu(systemMenu, (uint)(menuItemCount - 2), 5120u);
			WinApi.DrawMenuBar(base.Handle);
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0000D484 File Offset: 0x0000B684
		private Rectangle MeasureText(Graphics g, Rectangle clientRectangle, Font font, string text, TextFormatFlags flags)
		{
			Size proposedSize = new Size(int.MaxValue, int.MinValue);
			Size size = TextRenderer.MeasureText(g, text, font, proposedSize, flags);
			return new Rectangle(clientRectangle.X, clientRectangle.Y, size.Width, size.Height);
		}

		// Token: 0x040000EA RID: 234
		private const int borderWidth = 5;

		// Token: 0x040000EB RID: 235
		private const int CS_DROPSHADOW = 131072;

		// Token: 0x040000EC RID: 236
		private HorizontalAlign textAlign;

		// Token: 0x040000ED RID: 237
		private MetroBorderStyle _borderStyle;

		// Token: 0x040000EE RID: 238
		private bool isMovable = true;

		// Token: 0x040000EF RID: 239
		private bool displayHeader = true;

		// Token: 0x040000F0 RID: 240
		private bool isResizable = true;

		// Token: 0x040000F1 RID: 241
		private MetroForm.MetroFormShadowType shadowType = MetroForm.MetroFormShadowType.AeroShadow;

		// Token: 0x040000F2 RID: 242
		private Dictionary<MetroForm.WindowButtons, MetroForm.MetroFormButton> windowButtonList;

		// Token: 0x040000F3 RID: 243
		private Form shadowForm;

		// Token: 0x040000F4 RID: 244
		private bool _barrierProxyShadowForm;

		// Token: 0x02000059 RID: 89
		private enum WindowButtons
		{
			// Token: 0x040000F6 RID: 246
			Minimize,
			// Token: 0x040000F7 RID: 247
			Maximize,
			// Token: 0x040000F8 RID: 248
			Close
		}

		// Token: 0x0200005A RID: 90
		private class MetroFormButton : MetroButtonBase
		{
			// Token: 0x060003DF RID: 991 RVA: 0x0000D4D0 File Offset: 0x0000B6D0
			public MetroFormButton()
			{
				base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			}

			// Token: 0x060003E0 RID: 992 RVA: 0x0000D4E4 File Offset: 0x0000B6E4
			protected override void OnPaint(PaintEventArgs e)
			{
				Color color;
				if (base.Parent != null)
				{
					if (base.Parent is IMetroForm)
					{
						color = MetroPaint.BackColor.Form(base.Theme);
					}
					else if (base.Parent is IMetroControl)
					{
						color = MetroPaint.GetStyleColor(base.Style);
					}
					else
					{
						color = base.Parent.BackColor;
					}
				}
				else
				{
					color = MetroPaint.BackColor.Form(base.Theme);
				}
				Color foreColor;
				if (this.isHovered && !this.isPressed && base.Enabled)
				{
					foreColor = MetroPaint.ForeColor.Button.Normal(base.Theme);
					color = MetroPaint.BackColor.Button.Normal(base.Theme);
				}
				else if (this.isHovered && this.isPressed && base.Enabled)
				{
					foreColor = MetroPaint.ForeColor.Button.Press(base.Theme);
					color = MetroPaint.GetStyleColor(base.Style);
				}
				else if (!base.Enabled)
				{
					foreColor = MetroPaint.ForeColor.Button.Disabled(base.Theme);
					color = MetroPaint.BackColor.Button.Disabled(base.Theme);
				}
				else
				{
					foreColor = MetroPaint.ForeColor.Button.Normal(base.Theme);
				}
				e.Graphics.Clear(color);
				Font font = new Font("Webdings", 9.25f);
				TextRenderer.DrawText(e.Graphics, this.Text, font, base.ClientRectangle, foreColor, color, TextFormatFlags.EndEllipsis | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
			}

			// Token: 0x060003E1 RID: 993 RVA: 0x0000D616 File Offset: 0x0000B816
			protected override void OnMouseEnter(EventArgs e)
			{
				this.isHovered = true;
				base.Invalidate();
				base.OnMouseEnter(e);
			}

			// Token: 0x060003E2 RID: 994 RVA: 0x0000D62C File Offset: 0x0000B82C
			protected override void OnMouseDown(MouseEventArgs e)
			{
				if (e.Button == MouseButtons.Left)
				{
					this.isPressed = true;
					base.Invalidate();
				}
				base.OnMouseDown(e);
			}

			// Token: 0x060003E3 RID: 995 RVA: 0x0000D64F File Offset: 0x0000B84F
			protected override void OnMouseUp(MouseEventArgs e)
			{
				this.isPressed = false;
				base.Invalidate();
				base.OnMouseUp(e);
			}

			// Token: 0x060003E4 RID: 996 RVA: 0x0000D665 File Offset: 0x0000B865
			protected override void OnMouseLeave(EventArgs e)
			{
				this.isHovered = false;
				base.Invalidate();
				base.OnMouseLeave(e);
			}

			// Token: 0x040000F9 RID: 249
			private bool isHovered;

			// Token: 0x040000FA RID: 250
			private bool isPressed;
		}

		// Token: 0x0200005B RID: 91
		public enum MetroFormShadowType
		{
			// Token: 0x040000FC RID: 252
			None,
			// Token: 0x040000FD RID: 253
			Flat,
			// Token: 0x040000FE RID: 254
			DropShadow,
			// Token: 0x040000FF RID: 255
			SystemShadow,
			// Token: 0x04000100 RID: 256
			AeroShadow
		}

		// Token: 0x0200005C RID: 92
		protected abstract class MetroShadowBase : Form
		{
			// Token: 0x170000E4 RID: 228
			// (get) Token: 0x060003E5 RID: 997 RVA: 0x0000D67B File Offset: 0x0000B87B
			// (set) Token: 0x060003E6 RID: 998 RVA: 0x0000D683 File Offset: 0x0000B883
			private protected Form TargetForm { get; set; }

			// Token: 0x060003E7 RID: 999 RVA: 0x0000D68C File Offset: 0x0000B88C
			protected MetroShadowBase(Form targetForm, int shadowSize, int wsExStyle)
			{
				this.TargetForm = targetForm;
				this._shadowSize = shadowSize;
				this._wsExStyle = wsExStyle;
				this.TargetForm.Activated += this.OnTargetFormActivated;
				this.TargetForm.ResizeBegin += this.OnTargetFormResizeBegin;
				this.TargetForm.ResizeEnd += this.OnTargetFormResizeEnd;
				this.TargetForm.VisibleChanged += this.OnTargetFormVisibleChanged;
				this.TargetForm.SizeChanged += this.OnTargetFormSizeChanged;
				this.TargetForm.Move += this.OnTargetFormMove;
				this.TargetForm.Resize += this.OnTargetFormResize;
				if (this.TargetForm.Owner != null)
				{
					base.Owner = this.TargetForm.Owner;
				}
				this.TargetForm.Owner = this;
				base.MaximizeBox = false;
				base.MinimizeBox = false;
				base.ShowInTaskbar = false;
				base.ShowIcon = false;
				base.FormBorderStyle = FormBorderStyle.None;
				base.Bounds = this.GetShadowBounds();
			}

			// Token: 0x170000E5 RID: 229
			// (get) Token: 0x060003E8 RID: 1000 RVA: 0x0000D7B0 File Offset: 0x0000B9B0
			protected override CreateParams CreateParams
			{
				get
				{
					CreateParams createParams = base.CreateParams;
					createParams.ExStyle |= this._wsExStyle;
					return createParams;
				}
			}

			// Token: 0x060003E9 RID: 1001 RVA: 0x0000D7D8 File Offset: 0x0000B9D8
			private Rectangle GetShadowBounds()
			{
				Rectangle bounds = this.TargetForm.Bounds;
				bounds.Inflate(this._shadowSize, this._shadowSize);
				return bounds;
			}

			// Token: 0x060003EA RID: 1002
			protected abstract void PaintShadow();

			// Token: 0x060003EB RID: 1003
			protected abstract void ClearShadow();

			// Token: 0x060003EC RID: 1004 RVA: 0x0000D808 File Offset: 0x0000BA08
			[SecuritySafeCritical]
			protected void SetBitmap(Bitmap bitmap, byte opacity)
			{
				if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
				{
					throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");
				}
				IntPtr dc = WinApi.GetDC(IntPtr.Zero);
				IntPtr intPtr = WinApi.CreateCompatibleDC(dc);
				IntPtr intPtr2 = IntPtr.Zero;
				IntPtr hObject = IntPtr.Zero;
				try
				{
					intPtr2 = bitmap.GetHbitmap(Color.FromArgb(0));
					hObject = WinApi.SelectObject(intPtr, intPtr2);
					Size size = new Size(bitmap.Width, bitmap.Height);
					Point point = new Point(0, 0);
					Point point2 = new Point(base.Left, base.Top);
					WinApi.BLENDFUNCTION blendfunction = new WinApi.BLENDFUNCTION
					{
						BlendOp = 0,
						BlendFlags = 0,
						SourceConstantAlpha = opacity,
						AlphaFormat = 1
					};
					WinApi.UpdateLayeredWindow(base.Handle, dc, ref point2, ref size, intPtr, ref point, 0, ref blendfunction, 2);
				}
				finally
				{
					WinApi.ReleaseDC(IntPtr.Zero, dc);
					if (intPtr2 != IntPtr.Zero)
					{
						WinApi.SelectObject(intPtr, hObject);
						WinApi.DeleteObject(intPtr2);
					}
					WinApi.DeleteDC(intPtr);
				}
			}

			// Token: 0x060003ED RID: 1005 RVA: 0x0000D924 File Offset: 0x0000BB24
			protected override void OnDeactivate(EventArgs e)
			{
				base.OnDeactivate(e);
				this._isBringingToFront = true;
			}

			// Token: 0x060003EE RID: 1006 RVA: 0x0000D934 File Offset: 0x0000BB34
			private void OnTargetFormActivated(object sender, EventArgs e)
			{
				if (base.Visible)
				{
					base.Update();
				}
				if (this._isBringingToFront)
				{
					this._isBringingToFront = false;
					return;
				}
				base.BringToFront();
			}

			// Token: 0x060003EF RID: 1007 RVA: 0x0000D95A File Offset: 0x0000BB5A
			private void OnTargetFormVisibleChanged(object sender, EventArgs e)
			{
				base.Visible = (this.TargetForm.Visible && this.TargetForm.WindowState == FormWindowState.Normal);
				base.Update();
			}

			// Token: 0x170000E6 RID: 230
			// (get) Token: 0x060003F0 RID: 1008 RVA: 0x0000D986 File Offset: 0x0000BB86
			private bool IsResizing
			{
				get
				{
					return this._lastResizedOn > 0L;
				}
			}

			// Token: 0x060003F1 RID: 1009 RVA: 0x0000D994 File Offset: 0x0000BB94
			private void OnTargetFormResizeBegin(object sender, EventArgs e)
			{
				this._lastResizedOn = DateTime.Now.Ticks;
			}

			// Token: 0x060003F2 RID: 1010 RVA: 0x0000D9B4 File Offset: 0x0000BBB4
			private void OnTargetFormMove(object sender, EventArgs e)
			{
				if (!this.TargetForm.Visible || this.TargetForm.WindowState != FormWindowState.Normal)
				{
					base.Visible = false;
					return;
				}
				base.Bounds = this.GetShadowBounds();
			}

			// Token: 0x060003F3 RID: 1011 RVA: 0x0000D9E4 File Offset: 0x0000BBE4
			private void OnTargetFormResize(object sender, EventArgs e)
			{
				this.ClearShadow();
			}

			// Token: 0x060003F4 RID: 1012 RVA: 0x0000D9EC File Offset: 0x0000BBEC
			private void OnTargetFormSizeChanged(object sender, EventArgs e)
			{
				base.Bounds = this.GetShadowBounds();
				if (this.IsResizing)
				{
					if (DateTime.Now.Ticks - this._lastResizedOn <= 100000L)
					{
						return;
					}
					this._lastResizedOn = DateTime.Now.Ticks;
				}
				this.PaintShadowIfVisible();
			}

			// Token: 0x060003F5 RID: 1013 RVA: 0x0000DA43 File Offset: 0x0000BC43
			private void OnTargetFormResizeEnd(object sender, EventArgs e)
			{
				this._lastResizedOn = 0L;
				this.PaintShadowIfVisible();
			}

			// Token: 0x060003F6 RID: 1014 RVA: 0x0000DA53 File Offset: 0x0000BC53
			private void PaintShadowIfVisible()
			{
				if (this.TargetForm.Visible && this.TargetForm.WindowState == FormWindowState.Normal)
				{
					this.PaintShadow();
				}
			}

			// Token: 0x04000101 RID: 257
			private const int TICKS_PER_MS = 10000;

			// Token: 0x04000102 RID: 258
			private const long RESIZE_REDRAW_INTERVAL = 100000L;

			// Token: 0x04000103 RID: 259
			protected const int WS_EX_TRANSPARENT = 32;

			// Token: 0x04000104 RID: 260
			protected const int WS_EX_LAYERED = 524288;

			// Token: 0x04000105 RID: 261
			protected const int WS_EX_NOACTIVATE = 134217728;

			// Token: 0x04000106 RID: 262
			private readonly int _shadowSize;

			// Token: 0x04000107 RID: 263
			private readonly int _wsExStyle;

			// Token: 0x04000108 RID: 264
			private bool _isBringingToFront;

			// Token: 0x04000109 RID: 265
			private long _lastResizedOn;
		}

		// Token: 0x0200005D RID: 93
		protected class MetroAeroDropShadow : MetroForm.MetroShadowBase
		{
			// Token: 0x060003F7 RID: 1015 RVA: 0x0000DA75 File Offset: 0x0000BC75
			public MetroAeroDropShadow(Form targetForm) : base(targetForm, 0, 134217760)
			{
				base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
				base.TransparencyKey = Color.Black;
			}

			// Token: 0x060003F8 RID: 1016 RVA: 0x0000DA96 File Offset: 0x0000BC96
			protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
			{
				if (specified == BoundsSpecified.Size)
				{
					return;
				}
				base.SetBoundsCore(x, y, width, height, specified);
			}

			// Token: 0x060003F9 RID: 1017 RVA: 0x0000DAAC File Offset: 0x0000BCAC
			protected override void PaintShadow()
			{
				base.Visible = true;
			}

			// Token: 0x060003FA RID: 1018 RVA: 0x0000DAB5 File Offset: 0x0000BCB5
			protected override void ClearShadow()
			{
			}

			// Token: 0x060003FB RID: 1019 RVA: 0x0000DAB7 File Offset: 0x0000BCB7
			protected override void OnPaint(PaintEventArgs e)
			{
				e.Graphics.Clear(Color.Black);
			}
		}

		// Token: 0x0200005E RID: 94
		protected class MetroFlatDropShadow : MetroForm.MetroShadowBase
		{
			// Token: 0x060003FC RID: 1020 RVA: 0x0000DAC9 File Offset: 0x0000BCC9
			public MetroFlatDropShadow(Form targetForm) : base(targetForm, 6, 134742048)
			{
			}

			// Token: 0x060003FD RID: 1021 RVA: 0x0000DAE7 File Offset: 0x0000BCE7
			protected override void OnLoad(EventArgs e)
			{
				base.OnLoad(e);
				this.PaintShadow();
			}

			// Token: 0x060003FE RID: 1022 RVA: 0x0000DAF6 File Offset: 0x0000BCF6
			protected override void OnPaint(PaintEventArgs e)
			{
				base.Visible = true;
				this.PaintShadow();
			}

			// Token: 0x060003FF RID: 1023 RVA: 0x0000DB08 File Offset: 0x0000BD08
			protected override void PaintShadow()
			{
				using (Bitmap bitmap = this.DrawBlurBorder())
				{
					base.SetBitmap(bitmap, byte.MaxValue);
				}
			}

			// Token: 0x06000400 RID: 1024 RVA: 0x0000DB44 File Offset: 0x0000BD44
			protected override void ClearShadow()
			{
			}

			// Token: 0x06000401 RID: 1025 RVA: 0x0000DB48 File Offset: 0x0000BD48
			private Bitmap DrawBlurBorder()
			{
				return (Bitmap)this.DrawOutsetShadow(Color.Black, new Rectangle(0, 0, base.ClientRectangle.Width, base.ClientRectangle.Height));
			}

			// Token: 0x06000402 RID: 1026 RVA: 0x0000DB88 File Offset: 0x0000BD88
			private Image DrawOutsetShadow(Color color, Rectangle shadowCanvasArea)
			{
				Rectangle rect = shadowCanvasArea;
				Rectangle rect2 = new Rectangle(shadowCanvasArea.X + (-this.Offset.X - 1), shadowCanvasArea.Y + (-this.Offset.Y - 1), shadowCanvasArea.Width - (-this.Offset.X * 2 - 1), shadowCanvasArea.Height - (-this.Offset.Y * 2 - 1));
				Bitmap bitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				using (Brush brush = new SolidBrush(Color.FromArgb(30, Color.Black)))
				{
					graphics.FillRectangle(brush, rect);
				}
				using (Brush brush2 = new SolidBrush(Color.FromArgb(60, Color.Black)))
				{
					graphics.FillRectangle(brush2, rect2);
				}
				graphics.Flush();
				graphics.Dispose();
				return bitmap;
			}

			// Token: 0x0400010B RID: 267
			private Point Offset = new Point(-6, -6);
		}

		// Token: 0x0200005F RID: 95
		protected class MetroRealisticDropShadow : MetroForm.MetroShadowBase
		{
			// Token: 0x06000403 RID: 1027 RVA: 0x0000DCA8 File Offset: 0x0000BEA8
			public MetroRealisticDropShadow(Form targetForm) : base(targetForm, 15, 134742048)
			{
			}

			// Token: 0x06000404 RID: 1028 RVA: 0x0000DCB8 File Offset: 0x0000BEB8
			protected override void OnLoad(EventArgs e)
			{
				base.OnLoad(e);
				this.PaintShadow();
			}

			// Token: 0x06000405 RID: 1029 RVA: 0x0000DCC7 File Offset: 0x0000BEC7
			protected override void OnPaint(PaintEventArgs e)
			{
				base.Visible = true;
				this.PaintShadow();
			}

			// Token: 0x06000406 RID: 1030 RVA: 0x0000DCD8 File Offset: 0x0000BED8
			protected override void PaintShadow()
			{
				using (Bitmap bitmap = this.DrawBlurBorder())
				{
					base.SetBitmap(bitmap, byte.MaxValue);
				}
			}

			// Token: 0x06000407 RID: 1031 RVA: 0x0000DD14 File Offset: 0x0000BF14
			protected override void ClearShadow()
			{
				Bitmap bitmap = new Bitmap(base.Width, base.Height, PixelFormat.Format32bppArgb);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.Clear(Color.Transparent);
				graphics.Flush();
				graphics.Dispose();
				base.SetBitmap(bitmap, byte.MaxValue);
				bitmap.Dispose();
			}

			// Token: 0x06000408 RID: 1032 RVA: 0x0000DD68 File Offset: 0x0000BF68
			private Bitmap DrawBlurBorder()
			{
				return (Bitmap)this.DrawOutsetShadow(0, 0, 40, 1, Color.Black, new Rectangle(1, 1, base.ClientRectangle.Width, base.ClientRectangle.Height));
			}

			// Token: 0x06000409 RID: 1033 RVA: 0x0000DDB0 File Offset: 0x0000BFB0
			private Image DrawOutsetShadow(int hShadow, int vShadow, int blur, int spread, Color color, Rectangle shadowCanvasArea)
			{
				Rectangle rectangle = shadowCanvasArea;
				Rectangle rectangle2 = shadowCanvasArea;
				rectangle2.Offset(hShadow, vShadow);
				rectangle2.Inflate(-blur, -blur);
				rectangle.Inflate(spread, spread);
				rectangle.Offset(hShadow, vShadow);
				Rectangle rectangle3 = rectangle;
				Bitmap bitmap = new Bitmap(rectangle3.Width, rectangle3.Height, PixelFormat.Format32bppArgb);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				int cornerRadius = 0;
				do
				{
					double num = (double)(rectangle.Height - rectangle2.Height) / (double)(blur * 2 + spread * 2);
					Color fillColor = Color.FromArgb((int)(200.0 * (num * num)), color);
					Rectangle bounds = rectangle2;
					bounds.Offset(-rectangle3.Left, -rectangle3.Top);
					this.DrawRoundedRectangle(graphics, bounds, cornerRadius, Pens.Transparent, fillColor);
					rectangle2.Inflate(1, 1);
					cornerRadius = (int)((double)blur * (1.0 - num * num));
				}
				while (rectangle.Contains(rectangle2));
				graphics.Flush();
				graphics.Dispose();
				return bitmap;
			}

			// Token: 0x0600040A RID: 1034 RVA: 0x0000DEC0 File Offset: 0x0000C0C0
			private void DrawRoundedRectangle(Graphics g, Rectangle bounds, int cornerRadius, Pen drawPen, Color fillColor)
			{
				int num = Convert.ToInt32(Math.Ceiling((double)drawPen.Width));
				bounds = Rectangle.Inflate(bounds, -num, -num);
				GraphicsPath graphicsPath = new GraphicsPath();
				if (cornerRadius > 0)
				{
					graphicsPath.AddArc(bounds.X, bounds.Y, cornerRadius, cornerRadius, 180f, 90f);
					graphicsPath.AddArc(bounds.X + bounds.Width - cornerRadius, bounds.Y, cornerRadius, cornerRadius, 270f, 90f);
					graphicsPath.AddArc(bounds.X + bounds.Width - cornerRadius, bounds.Y + bounds.Height - cornerRadius, cornerRadius, cornerRadius, 0f, 90f);
					graphicsPath.AddArc(bounds.X, bounds.Y + bounds.Height - cornerRadius, cornerRadius, cornerRadius, 90f, 90f);
				}
				else
				{
					graphicsPath.AddRectangle(bounds);
				}
				graphicsPath.CloseAllFigures();
				if (cornerRadius > 5)
				{
					using (SolidBrush solidBrush = new SolidBrush(fillColor))
					{
						g.FillPath(solidBrush, graphicsPath);
					}
				}
				if (drawPen != Pens.Transparent)
				{
					using (Pen pen = new Pen(drawPen.Color))
					{
						pen.EndCap = (pen.StartCap = LineCap.Round);
						g.DrawPath(pen, graphicsPath);
					}
				}
			}
		}
	}
}
