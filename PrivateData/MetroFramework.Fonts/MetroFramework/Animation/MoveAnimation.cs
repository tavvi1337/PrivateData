using System;
using System.Drawing;
using System.Windows.Forms;

namespace MetroFramework.Animation
{
	// Token: 0x0200000F RID: 15
	public sealed class MoveAnimation : AnimationBase
	{
		// Token: 0x06000065 RID: 101 RVA: 0x00003588 File Offset: 0x00001788
		public void Start(Control control, Point targetPoint, TransitionType transitionType, int duration)
		{
			base.Start(control, transitionType, duration, delegate()
			{
				int x = this.DoMoveAnimation(control.Location.X, targetPoint.X);
				int y = this.DoMoveAnimation(control.Location.Y, targetPoint.Y);
				control.Location = new Point(x, y);
			}, () => control.Location.Equals(targetPoint));
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000035D8 File Offset: 0x000017D8
		private int DoMoveAnimation(int startPos, int targetPos)
		{
			float t = (float)this.counter - (float)this.startTime;
			float b = (float)startPos;
			float c = (float)targetPos - (float)startPos;
			float d = (float)this.targetTime - (float)this.startTime;
			return base.MakeTransition(t, b, d, c);
		}
	}
}
