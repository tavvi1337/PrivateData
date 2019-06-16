using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Animation;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;
using MetroFramework.Native;

namespace MetroFramework.Forms
{
	// Token: 0x02000061 RID: 97
	public sealed partial class MetroTaskWindow : MetroForm
	{
		// Token: 0x0600040D RID: 1037 RVA: 0x0000E094 File Offset: 0x0000C294
		public static void ShowTaskWindow(IWin32Window parent, string title, Control userControl, int secToClose)
		{
			if (MetroTaskWindow.singletonWindow != null)
			{
				MetroTaskWindow.singletonWindow.Close();
				MetroTaskWindow.singletonWindow.Dispose();
				MetroTaskWindow.singletonWindow = null;
			}
			MetroTaskWindow.singletonWindow = new MetroTaskWindow(secToClose, userControl);
			MetroTaskWindow.singletonWindow.Text = title;
			MetroTaskWindow.singletonWindow.Resizable = false;
			MetroTaskWindow.singletonWindow.StartPosition = FormStartPosition.Manual;
			IMetroForm metroForm = parent as IMetroForm;
			if (metroForm != null && metroForm.StyleManager != null)
			{
				((IMetroStyledComponent)MetroTaskWindow.singletonWindow.metroStyleManager).InternalStyleManager = metroForm.StyleManager;
			}
			MetroTaskWindow.singletonWindow.Show(parent);
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0000E121 File Offset: 0x0000C321
		public static bool IsVisible()
		{
			return MetroTaskWindow.singletonWindow != null && MetroTaskWindow.singletonWindow.Visible;
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0000E136 File Offset: 0x0000C336
		public static void ShowTaskWindow(IWin32Window parent, string text, Control userControl)
		{
			MetroTaskWindow.ShowTaskWindow(parent, text, userControl, 0);
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0000E141 File Offset: 0x0000C341
		public static void ShowTaskWindow(string text, Control userControl, int secToClose)
		{
			MetroTaskWindow.ShowTaskWindow(null, text, userControl, secToClose);
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x0000E14C File Offset: 0x0000C34C
		public static void ShowTaskWindow(string text, Control userControl)
		{
			MetroTaskWindow.ShowTaskWindow(null, text, userControl);
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0000E156 File Offset: 0x0000C356
		public static void CancelAutoClose()
		{
			if (MetroTaskWindow.singletonWindow != null)
			{
				MetroTaskWindow.singletonWindow.CancelTimer = true;
			}
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x0000E16A File Offset: 0x0000C36A
		public static void ForceClose()
		{
			if (MetroTaskWindow.singletonWindow != null)
			{
				MetroTaskWindow.CancelAutoClose();
				MetroTaskWindow.singletonWindow.Close();
				MetroTaskWindow.singletonWindow.Dispose();
				MetroTaskWindow.singletonWindow = null;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000414 RID: 1044 RVA: 0x0000E192 File Offset: 0x0000C392
		// (set) Token: 0x06000415 RID: 1045 RVA: 0x0000E19A File Offset: 0x0000C39A
		public bool CancelTimer
		{
			get
			{
				return this.cancelTimer;
			}
			set
			{
				this.cancelTimer = value;
			}
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x0000E1A3 File Offset: 0x0000C3A3
		public MetroTaskWindow()
		{
			this.controlContainer = new MetroPanel();
			base.Controls.Add(this.controlContainer);
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x0000E1C8 File Offset: 0x0000C3C8
		public MetroTaskWindow(int duration, Control userControl) : this()
		{
			this.controlContainer.Controls.Add(userControl);
			userControl.Dock = DockStyle.Fill;
			this.closeTime = duration * 500;
			if (this.closeTime > 0)
			{
				this.timer = DelayedCall.Start(new DelayedCall.Callback(this.UpdateProgress), 5);
			}
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x0000E224 File Offset: 0x0000C424
		protected override void OnActivated(EventArgs e)
		{
			if (!this.isInitialized)
			{
				base.MaximizeBox = false;
				base.MinimizeBox = false;
				base.Movable = false;
				base.TopMost = true;
				base.FormBorderStyle = FormBorderStyle.FixedDialog;
				base.Size = new Size(400, 200);
				Taskbar taskbar = new Taskbar();
				switch (taskbar.Position)
				{
				case TaskbarPosition.Left:
					base.Location = new Point(taskbar.Bounds.Width + 5, taskbar.Bounds.Height - base.Height - 5);
					goto IL_1A2;
				case TaskbarPosition.Top:
					base.Location = new Point(taskbar.Bounds.Width - base.Width - 5, taskbar.Bounds.Height + 5);
					goto IL_1A2;
				case TaskbarPosition.Right:
					base.Location = new Point(taskbar.Bounds.X - base.Width - 5, taskbar.Bounds.Height - base.Height - 5);
					goto IL_1A2;
				case TaskbarPosition.Bottom:
					base.Location = new Point(taskbar.Bounds.Width - base.Width - 5, taskbar.Bounds.Y - base.Height - 5);
					goto IL_1A2;
				}
				base.Location = new Point(Screen.PrimaryScreen.Bounds.Width - base.Width - 5, Screen.PrimaryScreen.Bounds.Height - base.Height - 5);
				IL_1A2:
				this.controlContainer.Location = new Point(0, 60);
				this.controlContainer.Size = new Size(base.Width - 40, base.Height - 80);
				this.controlContainer.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
				this.isInitialized = true;
				MoveAnimation moveAnimation = new MoveAnimation();
				moveAnimation.Start(this.controlContainer, new Point(20, 60), TransitionType.EaseInOutCubic, 15);
			}
			base.OnActivated(e);
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x0000E444 File Offset: 0x0000C644
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			using (SolidBrush solidBrush = new SolidBrush(MetroPaint.BackColor.Form(base.Theme)))
			{
				e.Graphics.FillRectangle(solidBrush, new Rectangle(base.Width - this.progressWidth, 0, this.progressWidth, 5));
			}
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0000E4AC File Offset: 0x0000C6AC
		private void UpdateProgress()
		{
			if (this.elapsedTime == this.closeTime)
			{
				this.timer.Dispose();
				this.timer = null;
				base.Close();
				return;
			}
			this.elapsedTime += 5;
			if (this.cancelTimer)
			{
				this.elapsedTime = 0;
			}
			double num = (double)this.elapsedTime / ((double)this.closeTime / 100.0);
			this.progressWidth = (int)((double)base.Width * (num / 100.0));
			base.Invalidate(new Rectangle(0, 0, base.Width, 5));
			if (!this.cancelTimer)
			{
				this.timer.Reset();
			}
		}

		// Token: 0x0400010E RID: 270
		private static MetroTaskWindow singletonWindow;

		// Token: 0x0400010F RID: 271
		private bool cancelTimer;

		// Token: 0x04000110 RID: 272
		private readonly int closeTime;

		// Token: 0x04000111 RID: 273
		private int elapsedTime;

		// Token: 0x04000112 RID: 274
		private int progressWidth;

		// Token: 0x04000113 RID: 275
		private DelayedCall timer;

		// Token: 0x04000114 RID: 276
		private readonly MetroPanel controlContainer;

		// Token: 0x04000115 RID: 277
		private bool isInitialized;
	}
}
