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
		internal static ProfilerManager Profiler
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
			Profiler = new ProfilerManager();
			Hooks = new HookManager();
		}
	}
}