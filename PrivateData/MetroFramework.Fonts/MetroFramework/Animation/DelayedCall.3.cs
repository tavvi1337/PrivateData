using System;

namespace MetroFramework.Animation
{
	// Token: 0x0200000A RID: 10
	internal class DelayedCall<T1, T2> : DelayedCall
	{
		// Token: 0x0600004A RID: 74 RVA: 0x00003068 File Offset: 0x00001268
		public static DelayedCall<T1, T2> Create(DelayedCall<T1, T2>.Callback cb, T1 data1, T2 data2, int milliseconds)
		{
			DelayedCall<T1, T2> delayedCall = new DelayedCall<T1, T2>();
			DelayedCall.PrepareDCObject(delayedCall, milliseconds, false);
			delayedCall.callback = cb;
			delayedCall.data1 = data1;
			delayedCall.data2 = data2;
			return delayedCall;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000309C File Offset: 0x0000129C
		public static DelayedCall<T1, T2> CreateAsync(DelayedCall<T1, T2>.Callback cb, T1 data1, T2 data2, int milliseconds)
		{
			DelayedCall<T1, T2> delayedCall = new DelayedCall<T1, T2>();
			DelayedCall.PrepareDCObject(delayedCall, milliseconds, true);
			delayedCall.callback = cb;
			delayedCall.data1 = data1;
			delayedCall.data2 = data2;
			return delayedCall;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000030D0 File Offset: 0x000012D0
		public static DelayedCall<T1, T2> Start(DelayedCall<T1, T2>.Callback cb, T1 data1, T2 data2, int milliseconds)
		{
			DelayedCall<T1, T2> delayedCall = DelayedCall<T1, T2>.Create(cb, data1, data2, milliseconds);
			delayedCall.Start();
			return delayedCall;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000030F0 File Offset: 0x000012F0
		public static DelayedCall<T1, T2> StartAsync(DelayedCall<T1, T2>.Callback cb, T1 data1, T2 data2, int milliseconds)
		{
			DelayedCall<T1, T2> delayedCall = DelayedCall<T1, T2>.CreateAsync(cb, data1, data2, milliseconds);
			delayedCall.Start();
			return delayedCall;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003174 File Offset: 0x00001374
		protected override void OnFire()
		{
			this.context.Post(delegate(object param0)
			{
				lock (this.timerLock)
				{
					if (this.cancelled)
					{
						return;
					}
				}
				if (this.callback != null)
				{
					this.callback(this.data1, this.data2);
				}
			}, null);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00003190 File Offset: 0x00001390
		public void Reset(T1 data1, T2 data2, int milliseconds)
		{
			lock (this.timerLock)
			{
				base.Cancel();
				this.data1 = data1;
				this.data2 = data2;
				base.Milliseconds = milliseconds;
				base.Start();
			}
		}

		// Token: 0x04000015 RID: 21
		private DelayedCall<T1, T2>.Callback callback;

		// Token: 0x04000016 RID: 22
		private T1 data1;

		// Token: 0x04000017 RID: 23
		private T2 data2;

		// Token: 0x0200000B RID: 11
		// (Invoke) Token: 0x06000053 RID: 83
		public new delegate void Callback(T1 data1, T2 data2);
	}
}
