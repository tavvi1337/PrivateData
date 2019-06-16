using System;

namespace MetroFramework.Animation
{
	// Token: 0x0200000C RID: 12
	internal class DelayedCall<T1, T2, T3> : DelayedCall
	{
		// Token: 0x06000056 RID: 86 RVA: 0x000031F4 File Offset: 0x000013F4
		public static DelayedCall<T1, T2, T3> Create(DelayedCall<T1, T2, T3>.Callback cb, T1 data1, T2 data2, T3 data3, int milliseconds)
		{
			DelayedCall<T1, T2, T3> delayedCall = new DelayedCall<T1, T2, T3>();
			DelayedCall.PrepareDCObject(delayedCall, milliseconds, false);
			delayedCall.callback = cb;
			delayedCall.data1 = data1;
			delayedCall.data2 = data2;
			delayedCall.data3 = data3;
			return delayedCall;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003230 File Offset: 0x00001430
		public static DelayedCall<T1, T2, T3> CreateAsync(DelayedCall<T1, T2, T3>.Callback cb, T1 data1, T2 data2, T3 data3, int milliseconds)
		{
			DelayedCall<T1, T2, T3> delayedCall = new DelayedCall<T1, T2, T3>();
			DelayedCall.PrepareDCObject(delayedCall, milliseconds, true);
			delayedCall.callback = cb;
			delayedCall.data1 = data1;
			delayedCall.data2 = data2;
			delayedCall.data3 = data3;
			return delayedCall;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000326C File Offset: 0x0000146C
		public static DelayedCall<T1, T2, T3> Start(DelayedCall<T1, T2, T3>.Callback cb, T1 data1, T2 data2, T3 data3, int milliseconds)
		{
			DelayedCall<T1, T2, T3> delayedCall = DelayedCall<T1, T2, T3>.Create(cb, data1, data2, data3, milliseconds);
			delayedCall.Start();
			return delayedCall;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000328C File Offset: 0x0000148C
		public static DelayedCall<T1, T2, T3> StartAsync(DelayedCall<T1, T2, T3>.Callback cb, T1 data1, T2 data2, T3 data3, int milliseconds)
		{
			DelayedCall<T1, T2, T3> delayedCall = DelayedCall<T1, T2, T3>.CreateAsync(cb, data1, data2, data3, milliseconds);
			delayedCall.Start();
			return delayedCall;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003318 File Offset: 0x00001518
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
					this.callback(this.data1, this.data2, this.data3);
				}
			}, null);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003334 File Offset: 0x00001534
		public void Reset(T1 data1, T2 data2, T3 data3, int milliseconds)
		{
			lock (this.timerLock)
			{
				base.Cancel();
				this.data1 = data1;
				this.data2 = data2;
				this.data3 = data3;
				base.Milliseconds = milliseconds;
				base.Start();
			}
		}

		// Token: 0x04000018 RID: 24
		private DelayedCall<T1, T2, T3>.Callback callback;

		// Token: 0x04000019 RID: 25
		private T1 data1;

		// Token: 0x0400001A RID: 26
		private T2 data2;

		// Token: 0x0400001B RID: 27
		private T3 data3;

		// Token: 0x0200000D RID: 13
		// (Invoke) Token: 0x0600005F RID: 95
		public new delegate void Callback(T1 data1, T2 data2, T3 data3);
	}
}
