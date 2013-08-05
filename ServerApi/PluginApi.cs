using System;

namespace ServerApi
{
	public static class PluginApi
	{
		public static HookManager Hooks { get; private set; }
		internal static IProfiler Profiler { get; private set; }
		public static ILogWriter LogWriter { get; private set; }
		public static bool IsWorldRunning { get; internal set; }

		static PluginApi()
		{
			PluginApi.Hooks = new HookManager();
		}

		public static void AttachProfiler(IProfiler newProfiler)
		{
			if (newProfiler == null)
				throw new ArgumentNullException("newProfiler");

			if (PluginApi.Profiler != null)
				PluginApi.Profiler.Detach();

			PluginApi.Profiler = newProfiler;
		}

		public static void AttachLogWriter(ILogWriter newLogWriter)
		{
			if (newLogWriter == null)
				throw new ArgumentNullException("newLogWriter");

			if (PluginApi.LogWriter != null)
				PluginApi.LogWriter.Detach();

			PluginApi.LogWriter = newLogWriter;
		}
	}
}