using System;
using System.Windows.Forms;

namespace MetroFramework.Animation
{
    // Token: 0x02000004 RID: 4
    public abstract class AnimationBase
    {
        // Token: 0x14000001 RID: 1
        // (add) Token: 0x06000009 RID: 9 RVA: 0x000020D0 File Offset: 0x000002D0
        // (remove) Token: 0x0600000A RID: 10 RVA: 0x00002108 File Offset: 0x00000308
        public event EventHandler AnimationCompleted;

        // Token: 0x0600000B RID: 11 RVA: 0x0000213D File Offset: 0x0000033D
        private void OnAnimationCompleted()
        {
            AnimationCompleted?.Invoke(this, EventArgs.Empty);
        }

        // Token: 0x17000001 RID: 1
        // (get) Token: 0x0600000C RID: 12 RVA: 0x00002158 File Offset: 0x00000358
        public bool IsCompleted => this.timer == null || !this.timer.IsWaiting;

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x0600000D RID: 13 RVA: 0x00002172 File Offset: 0x00000372
        public bool IsRunning => this.timer != null && this.timer.IsWaiting;

        // Token: 0x0600000E RID: 14 RVA: 0x00002189 File Offset: 0x00000389
        public void Cancel()
        {
            if (this.IsRunning)
            {
                this.timer.Cancel();
            }
        }

        // Token: 0x0600000F RID: 15 RVA: 0x0000219E File Offset: 0x0000039E
        protected void Start(Control control, TransitionType transitionType, int duration, AnimationAction actionHandler)
        {
            this.Start(control, transitionType, duration, actionHandler, null);
        }

        // Token: 0x06000010 RID: 16 RVA: 0x000021AC File Offset: 0x000003AC
        protected void Start(Control control, TransitionType transitionType, int duration, AnimationAction actionHandler, AnimationFinishedEvaluator evaluatorHandler)
        {
            this.targetControl = control;
            this.transitionType = transitionType;
            this.actionHandler = actionHandler;
            this.evaluatorHandler = evaluatorHandler;
            this.counter = 0;
            this.startTime = 0;
            this.targetTime = duration;
            this.timer = DelayedCall.Start(new DelayedCall.Callback(this.DoAnimation), duration);
        }

        // Token: 0x06000011 RID: 17 RVA: 0x00002204 File Offset: 0x00000404
        private void DoAnimation()
        {
            if (this.evaluatorHandler == null || this.evaluatorHandler())
            {
                this.OnAnimationCompleted();
                return;
            }
            this.actionHandler();
            this.counter++;
            this.timer.Start();
        }

        // Token: 0x06000012 RID: 18 RVA: 0x00002254 File Offset: 0x00000454
        protected int MakeTransition(float t, float b, float d, float c)
        {
            switch (this.transitionType)
            {
                case TransitionType.Linear:
                    return (int)(c * t / d + b);
                case TransitionType.EaseInQuad:
                    return (int)(c * (t /= d) * t + b);
                case TransitionType.EaseOutQuad:
                    return (int)(-c * (t /= d) * (t - 2f) + b);
                case TransitionType.EaseInOutQuad:
                    if ((t /= d / 2f) < 1f)
                    {
                        return (int)(c / 2f * t * t + b);
                    }
                    return (int)(-c / 2f * ((t -= 1f) * (t - 2f) - 1f) + b);
                case TransitionType.EaseInCubic:
                    return (int)(c * (t /= d) * t * t + b);
                case TransitionType.EaseOutCubic:
                    return (int)(c * ((t = t / d - 1f) * t * t + 1f) + b);
                case TransitionType.EaseInOutCubic:
                    if ((t /= d / 2f) < 1f)
                    {
                        return (int)(c / 2f * t * t * t + b);
                    }
                    return (int)(c / 2f * ((t -= 2f) * t * t + 2f) + b);
                case TransitionType.EaseInQuart:
                    return (int)(c * (t /= d) * t * t * t + b);
                case TransitionType.EaseInExpo:
                    if (t == 0f)
                    {
                        return (int)b;
                    }
                    return (int)((double)c * Math.Pow(2.0, (double)(10f * (t / d - 1f))) + (double)b);
                case TransitionType.EaseOutExpo:
                    if (t == d)
                    {
                        return (int)(b + c);
                    }
                    return (int)((double)c * (-Math.Pow(2.0, (double)(-10f * t / d)) + 1.0) + (double)b);
                default:
                    return 0;
            }
        }

        // Token: 0x04000002 RID: 2
        private DelayedCall timer;

        // Token: 0x04000003 RID: 3
        private Control targetControl;

        // Token: 0x04000004 RID: 4
        private AnimationAction actionHandler;

        // Token: 0x04000005 RID: 5
        private AnimationFinishedEvaluator evaluatorHandler;

        // Token: 0x04000006 RID: 6
        protected TransitionType transitionType;

        // Token: 0x04000007 RID: 7
        protected int counter;

        // Token: 0x04000008 RID: 8
        protected int startTime;

        // Token: 0x04000009 RID: 9
        protected int targetTime;
    }
}
