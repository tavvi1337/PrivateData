using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace MetroFramework.Animation
{
	// Token: 0x02000006 RID: 6
	internal class DelayedCall : IDisposable
	{
		// Token: 0x06000019 RID: 25 RVA: 0x000026C9 File Offset: 0x000008C9
		protected DelayedCall()
		{
			this.timerLock = new object();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000026DC File Offset: 0x000008DC
		[Obsolete("Use the static method DelayedCall.Create instead.")]
		public DelayedCall(DelayedCall.Callback cb) : this()
		{
			DelayedCall.PrepareDCObject(this, 0, false);
			this.callback = cb;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000026F3 File Offset: 0x000008F3
		[Obsolete("Use the static method DelayedCall.Create instead.")]
		public DelayedCall(DelayedCall<object>.Callback cb, object data) : this()
		{
			DelayedCall.PrepareDCObject(this, 0, false);
			this.oldCallback = cb;
			this.oldData = data;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002711 File Offset: 0x00000911
		[Obsolete("Use the static method DelayedCall.Start instead.")]
		public DelayedCall(DelayedCall.Callback cb, int milliseconds) : this()
		{
			DelayedCall.PrepareDCObject(this, milliseconds, false);
			this.callback = cb;
			if (milliseconds > 0)
			{
				this.Start();
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002732 File Offset: 0x00000932
		[Obsolete("Use the static method DelayedCall.Start instead.")]
		public DelayedCall(DelayedCall<object>.Callback cb, int milliseconds, object data) : this()
		{
			DelayedCall.PrepareDCObject(this, milliseconds, false);
			this.oldCallback = cb;
			this.oldData = data;
			if (milliseconds > 0)
			{
				this.Start();
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000275A File Offset: 0x0000095A
		[Obsolete("Use the method Restart of the generic class instead.")]
		public void Reset(object data)
		{
			this.Cancel();
			this.oldData = data;
			this.Start();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000276F File Offset: 0x0000096F
		[Obsolete("Use the method Restart of the generic class instead.")]
		public void Reset(int milliseconds, object data)
		{
			this.Cancel();
			this.oldData = data;
			this.Reset(milliseconds);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002785 File Offset: 0x00000985
		[Obsolete("Use the method Restart instead.")]
		public void SetTimeout(int milliseconds)
		{
			this.Reset(milliseconds);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002790 File Offset: 0x00000990
		public static DelayedCall Create(DelayedCall.Callback cb, int milliseconds)
		{
			DelayedCall delayedCall = new DelayedCall();
			DelayedCall.PrepareDCObject(delayedCall, milliseconds, false);
			delayedCall.callback = cb;
			return delayedCall;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000027B4 File Offset: 0x000009B4
		public static DelayedCall CreateAsync(DelayedCall.Callback cb, int milliseconds)
		{
			DelayedCall delayedCall = new DelayedCall();
			DelayedCall.PrepareDCObject(delayedCall, milliseconds, true);
			delayedCall.callback = cb;
			return delayedCall;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000027D8 File Offset: 0x000009D8
		public static DelayedCall Start(DelayedCall.Callback cb, int milliseconds)
		{
			DelayedCall delayedCall = DelayedCall.Create(cb, milliseconds);
			if (milliseconds > 0)
			{
				delayedCall.Start();
			}
			else if (milliseconds == 0)
			{
				delayedCall.FireNow();
			}
			return delayedCall;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002804 File Offset: 0x00000A04
		public static DelayedCall StartAsync(DelayedCall.Callback cb, int milliseconds)
		{
			DelayedCall delayedCall = DelayedCall.CreateAsync(cb, milliseconds);
			if (milliseconds > 0)
			{
				delayedCall.Start();
			}
			else if (milliseconds == 0)
			{
				delayedCall.FireNow();
			}
			return delayedCall;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002830 File Offset: 0x00000A30
		protected static void PrepareDCObject(DelayedCall dc, int milliseconds, bool async)
		{
			if (milliseconds < 0)
			{
				throw new ArgumentOutOfRangeException("milliseconds", "The new timeout must be 0 or greater.");
			}
			dc.context = null;
			if (!async)
			{
				dc.context = SynchronizationContext.Current;
				if (dc.context == null)
				{
					throw new InvalidOperationException("Cannot delay calls synchronously on a non-UI thread. Use the *Async methods instead.");
				}
			}
			if (dc.context == null)
			{
				dc.context = new SynchronizationContext();
			}
			dc.timer = new System.Timers.Timer();
			if (milliseconds > 0)
			{
				dc.timer.Interval = (double)milliseconds;
			}
			dc.timer.AutoReset = false;
			dc.timer.Elapsed += dc.Timer_Elapsed;
			DelayedCall.Register(dc);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000028D4 File Offset: 0x00000AD4
		protected static void Register(DelayedCall dc)
		{
			lock (DelayedCall.dcList)
			{
				if (!DelayedCall.dcList.Contains(dc))
				{
					DelayedCall.dcList.Add(dc);
				}
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002928 File Offset: 0x00000B28
		protected static void Unregister(DelayedCall dc)
		{
			lock (DelayedCall.dcList)
			{
				DelayedCall.dcList.Remove(dc);
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002970 File Offset: 0x00000B70
		public static int RegisteredCount
		{
			get
			{
				int count;
				lock (DelayedCall.dcList)
				{
					count = DelayedCall.dcList.Count;
				}
				return count;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000029B8 File Offset: 0x00000BB8
		public static bool IsAnyWaiting
		{
			get
			{
				lock (DelayedCall.dcList)
				{
					foreach (DelayedCall delayedCall in DelayedCall.dcList)
					{
						if (delayedCall.IsWaiting)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002A3C File Offset: 0x00000C3C
		public static void CancelAll()
		{
			lock (DelayedCall.dcList)
			{
				foreach (DelayedCall delayedCall in DelayedCall.dcList)
				{
					delayedCall.Cancel();
				}
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002AB8 File Offset: 0x00000CB8
		public static void FireAll()
		{
			lock (DelayedCall.dcList)
			{
				foreach (DelayedCall delayedCall in DelayedCall.dcList)
				{
					delayedCall.Fire();
				}
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002B34 File Offset: 0x00000D34
		public static void DisposeAll()
		{
			lock (DelayedCall.dcList)
			{
				while (DelayedCall.dcList.Count > 0)
				{
					DelayedCall.dcList[0].Dispose();
				}
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002B8C File Offset: 0x00000D8C
		protected virtual void Timer_Elapsed(object o, ElapsedEventArgs e)
		{
			this.FireNow();
			DelayedCall.Unregister(this);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002B9A File Offset: 0x00000D9A
		public void Dispose()
		{
			DelayedCall.Unregister(this);
			this.timer.Dispose();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002BB0 File Offset: 0x00000DB0
		public void Start()
		{
			lock (this.timerLock)
			{
				this.cancelled = false;
				this.timer.Start();
				DelayedCall.Register(this);
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002C04 File Offset: 0x00000E04
		public void Cancel()
		{
			lock (this.timerLock)
			{
				this.cancelled = true;
				DelayedCall.Unregister(this);
				this.timer.Stop();
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002C58 File Offset: 0x00000E58
		public bool IsWaiting
		{
			get
			{
				bool result;
				lock (this.timerLock)
				{
					result = (this.timer.Enabled && !this.cancelled);
				}
				return result;
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002CB0 File Offset: 0x00000EB0
		public void Fire()
		{
			lock (this.timerLock)
			{
				if (!this.IsWaiting)
				{
					return;
				}
				this.timer.Stop();
			}
			this.FireNow();
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002D08 File Offset: 0x00000F08
		public void FireNow()
		{
			this.OnFire();
			DelayedCall.Unregister(this);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002D88 File Offset: 0x00000F88
		protected virtual void OnFire()
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
					this.callback();
				}
				if (this.oldCallback != null)
				{
					this.oldCallback(this.oldData);
				}
			}, null);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002DA4 File Offset: 0x00000FA4
		public void Reset()
		{
			lock (this.timerLock)
			{
				this.Cancel();
				this.Start();
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002DEC File Offset: 0x00000FEC
		public void Reset(int milliseconds)
		{
			lock (this.timerLock)
			{
				this.Cancel();
				this.Milliseconds = milliseconds;
				this.Start();
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00002E3C File Offset: 0x0000103C
		// (set) Token: 0x06000038 RID: 56 RVA: 0x00002E84 File Offset: 0x00001084
		public int Milliseconds
		{
			get
			{
				int result;
				lock (this.timerLock)
				{
					result = (int)this.timer.Interval;
				}
				return result;
			}
			set
			{
				lock (this.timerLock)
				{
					if (value < 0)
					{
						throw new ArgumentOutOfRangeException("Milliseconds", "The new timeout must be 0 or greater.");
					}
					if (value == 0)
					{
						this.Cancel();
						this.FireNow();
						DelayedCall.Unregister(this);
					}
					else
					{
						this.timer.Interval = (double)value;
					}
				}
			}
		}

		// Token: 0x0400000B RID: 11
		protected static List<DelayedCall> dcList = new List<DelayedCall>();

		// Token: 0x0400000C RID: 12
		protected System.Timers.Timer timer;

		// Token: 0x0400000D RID: 13
		protected object timerLock;

		// Token: 0x0400000E RID: 14
		private DelayedCall.Callback callback;

		// Token: 0x0400000F RID: 15
		protected bool cancelled;

		// Token: 0x04000010 RID: 16
		protected SynchronizationContext context;

		// Token: 0x04000011 RID: 17
		private DelayedCall<object>.Callback oldCallback;

		// Token: 0x04000012 RID: 18
		private object oldData;

		// Token: 0x02000007 RID: 7
		// (Invoke) Token: 0x0600003B RID: 59
		public delegate void Callback();
	}
}
