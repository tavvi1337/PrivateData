using System;

namespace MetroFramework.Animation
{
	// Token: 0x02000008 RID: 8
	internal class DelayedCall<T> : DelayedCall
	{
		// Token: 0x0600003E RID: 62 RVA: 0x00002EF8 File Offset: 0x000010F8
		public static DelayedCall<T> Create(DelayedCall<T>.Callback cb, T data, int milliseconds)
		{
			DelayedCall<T> delayedCall = new DelayedCall<T>();
			DelayedCall.PrepareDCObject(delayedCall, milliseconds, false);
			delayedCall.callback = cb;
			delayedCall.data = data;
			return delayedCall;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002F24 File Offset: 0x00001124
		public static DelayedCall<T> CreateAsync(DelayedCall<T>.Callback cb, T data, int milliseconds)
		{
			DelayedCall<T> delayedCall = new DelayedCall<T>();
			DelayedCall.PrepareDCObject(delayedCall, milliseconds, true);
			delayedCall.callback = cb;
			delayedCall.data = data;
			return delayedCall;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002F50 File Offset: 0x00001150
		public static DelayedCall<T> Start(DelayedCall<T>.Callback cb, T data, int milliseconds)
		{
			DelayedCall<T> delayedCall = DelayedCall<T>.Create(cb, data, milliseconds);
			delayedCall.Start();
			return delayedCall;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002F70 File Offset: 0x00001170
		public static DelayedCall<T> StartAsync(DelayedCall<T>.Callback cb, T data, int milliseconds)
		{
			DelayedCall<T> delayedCall = DelayedCall<T>.CreateAsync(cb, data, milliseconds);
			delayedCall.Start();
			return delayedCall;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002FF0 File Offset: 0x000011F0
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
					this.callback(this.data);
				}
			}, null);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000300C File Offset: 0x0000120C
		public void Reset(T data, int milliseconds)
		{
			lock (this.timerLock)
			{
				base.Cancel();
				this.data = data;
				base.Milliseconds = milliseconds;
				base.Start();
			}
		}

		// Token: 0x04000013 RID: 19
		private DelayedCall<T>.Callback callback;

		// Token: 0x04000014 RID: 20
		private T data;

		// Token: 0x02000009 RID: 9
		// (Invoke) Token: 0x06000047 RID: 71
		public new delegate void Callback(T data);
	}
}
