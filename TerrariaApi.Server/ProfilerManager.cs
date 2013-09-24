using System;
using System.Diagnostics;

namespace TerrariaApi.Server {
	public class ProfilerManager
	{
		private Stopwatch serverInitTimeWatch = new Stopwatch();

		internal IProfiler WrappedProfiler
		{
			get;
			private set;
		}
		public string ProfilerName
		{
			get
			{
				if (this.WrappedProfiler == null)
					return null;

				return this.WrappedProfiler.Name;
			}
		}

		public void Attach(IProfiler newProfiler)
		{
			if (newProfiler == null)
				throw new ArgumentNullException("newProfiler");
			if (newProfiler == this.WrappedProfiler)
				return;

			if (this.WrappedProfiler != null)
			{
				try
				{
					this.WrappedProfiler.Detach();
				}
				catch (Exception ex)
				{
					ServerApi.LogWriter.ServerWriteLine(
						string.Format("Profiler \"{0}\" had thrown an unexpected exception:\n{1}", this.ProfilerName, ex), TraceLevel.Error);
				}

				ServerApi.LogWriter.ServerWriteLine(
					string.Format("Profiler \"{0}\" was detached.", this.ProfilerName), TraceLevel.Verbose);
			}

			this.WrappedProfiler = newProfiler;

			ServerApi.LogWriter.ServerWriteLine(
				string.Format("Profiler \"{0}\" was attached.", this.ProfilerName), TraceLevel.Verbose);
		}

		internal void Deatch()
		{
			if (this.WrappedProfiler == null)
				return;

			try
			{
				this.WrappedProfiler.Detach();
			}
			catch (Exception ex)
			{
				ServerApi.LogWriter.ServerWriteLine(
					string.Format("Profiler \"{0}\" has thrown an unexpected exception:\n{1}", this.ProfilerName, ex), TraceLevel.Error);
			}

			this.WrappedProfiler = null;
		}

		internal void BeginMeasureServerInitTime()
		{
			if (this.serverInitTimeWatch == null)
				this.serverInitTimeWatch = new Stopwatch();

			this.serverInitTimeWatch.Start();
		}

		internal void EndMeasureServerInitTime()
		{
			if (this.serverInitTimeWatch == null)
				return;

			this.serverInitTimeWatch.Stop();
			this.InputServerInitTime(this.serverInitTimeWatch.Elapsed);

			this.serverInitTimeWatch = null;
		}

		internal void InputServerInitTime(TimeSpan processingTime)
		{
			if (this.WrappedProfiler == null)
				return;

			try
			{
				this.WrappedProfiler.InputServerInitTime(processingTime);
			}
			catch (Exception ex)
			{
				ServerApi.LogWriter.ServerWriteLine(
					string.Format("Profiler \"{0}\" has thrown an unexpected exception:\n{1}", this.ProfilerName, ex), TraceLevel.Error);
			}
		}

		internal void InputServerWorldLoadTime(TimeSpan processingTime)
		{
			if (this.WrappedProfiler == null)
				return;

			try
			{
				this.WrappedProfiler.InputServerWorldLoadTime(processingTime);
			}
			catch (Exception ex)
			{
				ServerApi.LogWriter.ServerWriteLine(
					string.Format("Profiler \"{0}\" has thrown an unexpected exception:\n{1}", this.ProfilerName, ex), TraceLevel.Error);
			}
		}

		internal void InputServerWorldSaveTime(TimeSpan processingTime)
		{
			if (this.WrappedProfiler == null)
				return;

			try
			{
				this.WrappedProfiler.InputServerWorldSaveTime(processingTime);
			}
			catch (Exception ex)
			{
				ServerApi.LogWriter.ServerWriteLine(
					string.Format("Profiler \"{0}\" has thrown an unexpected exception:\n{1}", this.ProfilerName, ex), TraceLevel.Error);
			}
		}

		internal void InputServerGameUpdateTime(TimeSpan processingTime)
		{
			if (this.WrappedProfiler == null)
				return;

			try
			{
				this.WrappedProfiler.InputServerGameUpdateTime(processingTime);
			}
			catch (Exception ex)
			{
				ServerApi.LogWriter.ServerWriteLine(
					string.Format("Profiler \"{0}\" has thrown an unexpected exception:\n{1}", this.ProfilerName, ex), TraceLevel.Error);
			}
		}

		internal void InputServerGameUpdateTimeWithoutHooks(TimeSpan processingTime)
		{
			if (this.WrappedProfiler == null)
				return;

			try
			{
				this.WrappedProfiler.InputServerGameUpdateTimeWithoutHooks(processingTime);
			}
			catch (Exception ex)
			{
				ServerApi.LogWriter.ServerWriteLine(
					string.Format("Profiler \"{0}\" has thrown an unexpected exception:\n{1}", this.ProfilerName, ex), TraceLevel.Error);
			}
		}

		internal void InputPluginInitTime(TerrariaPlugin plugin, TimeSpan processingTime)
		{
			if (plugin == null)
				throw new ArgumentNullException("plugin");
			if (this.WrappedProfiler == null)
				return;

			try
			{
				this.WrappedProfiler.InputPluginInitTime(plugin, processingTime);
			}
			catch (Exception ex)
			{
				ServerApi.LogWriter.ServerWriteLine(
					string.Format("Profiler \"{0}\" has thrown an unexpected exception:\n{1}", this.ProfilerName, ex), TraceLevel.Error);
			}
		}

		internal void InputPluginHandlerTime(TerrariaPlugin plugin, string hookName, TimeSpan processingTime)
		{
			if (plugin == null)
				throw new ArgumentNullException("plugin");
			if (string.IsNullOrWhiteSpace(hookName))
				throw new ArgumentException("hookName");
			if (this.WrappedProfiler == null)
				return;

			try
			{
				this.WrappedProfiler.InputPluginHandlerTime(plugin, hookName, processingTime);
			}
			catch (Exception ex)
			{
				ServerApi.LogWriter.ServerWriteLine(
					string.Format("Profiler \"{0}\" has thrown an unexpected exception:\n{1}", this.ProfilerName, ex), TraceLevel.Error);
			}
		}

		public void InputPluginCustomProcessingTime(TerrariaPlugin plugin, string operation, TimeSpan processingTime)
		{
			if (plugin == null)
				throw new ArgumentNullException("plugin");
			if (string.IsNullOrWhiteSpace(operation))
				throw new ArgumentException("operation");
			if (this.WrappedProfiler == null)
				return;

			try
			{
				this.WrappedProfiler.InputPluginCustomProcessingTime(plugin, operation, processingTime);
			}
			catch (Exception ex)
			{
				ServerApi.LogWriter.ServerWriteLine(
					string.Format("Profiler \"{0}\" has thrown an unexpected exception:\n{1}", this.ProfilerName, ex), TraceLevel.Error);
			}
		}

		internal void InputPluginHandlerExceptionThrown(TerrariaPlugin plugin, string hookName, Exception exception)
		{
			if (plugin == null)
				throw new ArgumentNullException("plugin");
			if (string.IsNullOrWhiteSpace(hookName))
				throw new ArgumentException("hookName");
			if (exception == null)
				throw new ArgumentNullException("exception");
			if (this.WrappedProfiler == null)
				return;

			try
			{
				this.WrappedProfiler.InputPluginHandlerExceptionThrown(plugin, hookName, exception);
			}
			catch (Exception ex)
			{
				ServerApi.LogWriter.ServerWriteLine(
					string.Format("Profiler \"{0}\" has thrown an unexpected exception:\n{1}", this.ProfilerName, ex), TraceLevel.Error);
			}
		}

		internal void InputPluginUnloadTime(TerrariaPlugin plugin, TimeSpan processingTime)
		{
			if (plugin == null)
				throw new ArgumentNullException("plugin");
			if (this.WrappedProfiler == null)
				return;

			try
			{
				this.WrappedProfiler.InputPluginUnloadTime(plugin, processingTime);
			}
			catch (Exception ex)
			{
				ServerApi.LogWriter.ServerWriteLine(
					string.Format("Profiler \"{0}\" has thrown an unexpected exception:\n{1}", this.ProfilerName, ex), TraceLevel.Error);
			}
		}
	}
}
