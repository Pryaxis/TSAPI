using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TerrariaApi.Server;

namespace TerrariaApi.Server
{
	public static class TaskExt
	{
		public static Task LogExceptions(this Task task)
		{
			task.ContinueWith(t => { ServerApi.LogWriter.ServerWriteLine(t.Exception.ToString(), TraceLevel.Error); }, TaskContinuationOptions.OnlyOnFaulted);
			return task;
		}

		public static Task SuppressExceptions(this Task task)
		{
			task.ContinueWith(t => { var ex = t.Exception; }, TaskContinuationOptions.OnlyOnFaulted);
			return task;
		}

		public static Task InvokeOnException(this Task task, Action<AggregateException> action)
		{
			if (action != null) task.ContinueWith(t => { action(t.Exception); }, TaskContinuationOptions.OnlyOnFaulted);
			else return SuppressExceptions(task);
			return task;
		}
	}
}
