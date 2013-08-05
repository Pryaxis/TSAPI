using System;

namespace ServerApi
{
	public static class PluginApi
	{
		public static HookManager Hooks
		{
			get; 
			private set;
		}
		public static LogWriterManager LogWriter
		{
			get;
			private set;
		}
		internal static IProfiler Profiler
		{
			get; 
			private set;
		}
		public static bool IsWorldRunning
		{
			get; 
			internal set;
		}

		static PluginApi()
		{
			LogWriter = new LogWriterManager();
			Hooks = new HookManager();
		}

		public static void AttachProfiler(IProfiler newProfiler)
		{
			if (newProfiler == null)
				throw new ArgumentNullException("newProfiler");

			if (Profiler != null)
				Profiler.Detach();

			Profiler = newProfiler;
		}
	}
}