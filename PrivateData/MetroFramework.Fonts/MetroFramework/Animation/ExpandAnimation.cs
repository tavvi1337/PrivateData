using System;
using System.Drawing;
using System.Windows.Forms;

namespace MetroFramework.Animation
{
	// Token: 0x0200000E RID: 14
	public sealed class ExpandAnimation : AnimationBase
	{
		// Token: 0x06000062 RID: 98 RVA: 0x00003440 File Offset: 0x00001640
		public void Start(Control control, Size targetSize, TransitionType transitionType, int duration)
		{
			base.Start(control, transitionType, duration, delegate()
			{
				int width = this.DoExpandAnimation(control.Width, targetSize.Width);
				int height = this.DoExpandAnimation(control.Height, targetSize.Height);
				control.Size = new Size(width, height);
			}, () => control.Size.Equals(targetSize));
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003490 File Offset: 0x00001690
		private int DoExpandAnimation(int startSize, int targetSize)
		{
			float t = (float)this.counter - (float)this.startTime;
			float b = (float)startSize;
			float c = (float)targetSize - (float)startSize;
			float d = (float)this.targetTime - (float)this.startTime;
			return base.MakeTransition(t, b, d, c);
		}
	}
}
