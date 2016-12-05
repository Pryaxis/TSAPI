using System;
using System.Diagnostics;
using System.Linq;

namespace TerrariaApi.Server
{
	/// <summary>
	///   Implements a server profiler. Methods of this implementation are generally expected to be thread safe. Note that
	///   the plugin which has registered the profiler should never dispose it during deinitialization or disposing, let the
	///   Server API call the detach method instead.
	/// </summary>
	public interface IProfiler
	{
		/// <summary>
		///   Gets the name of the profiler implementation.
		/// </summary>
		string Name { get; }

		/// <summary>
		///   Called before this profiler is detached, that is when the server is shutting down or the profiler is replaced by 
		///   another profiler.
		/// </summary>
		void Detach();

		/// <summary>
		///   Provides the profiler with the processing time consumed by the whole server startup procedure (includes all plugin
		///   initializations).
		/// </summary>
		/// <param name="processingTime">
		///   The consumed processing time.
		/// </param>
		void InputServerInitTime(TimeSpan processingTime);

		/// <summary>
		///   Provides the profiler with the processing time consumed by the world load procedure.
		/// </summary>
		/// <param name="processingTime">
		///   The consumed processing time.
		/// </param>
		void InputServerWorldLoadTime(TimeSpan processingTime);

		/// <summary>
		///   Provides the profiler with the processing time consumed by the world save procedure.
		/// </summary>
		/// <param name="processingTime">
		///   The consumed processing time.
		/// </param>
		void InputServerWorldSaveTime(TimeSpan processingTime);

		/// <summary>
		///   Provides the profiler with the processing time consumed by the game update procedure.
		/// </summary>
		/// <param name="processingTime">
		///   The consumed processing time.
		/// </param>
		void InputServerGameUpdateTime(TimeSpan processingTime);

		/// <summary>
		///   Provides the profiler with the processing time consumed by the internal game update procedure (without the invokes
		///   of the GameUpdate, GamePostUpdate hooks).
		/// </summary>
		/// <param name="processingTime">
		///   The consumed processing time.
		/// </param>
		void InputServerGameUpdateTimeWithoutHooks(TimeSpan processingTime);

		/// <summary>
		///   Provides the profiler with the processing time consumed by a plugin's constructor and initialization.
		///   This method is called for each plugin after all plugins have been fully initialized to give the profiler a chance
		///   to gather all data no matter when it got attached.
		/// </summary>
		/// <param name="plugin">
		///   The initialized plugin.
		/// </param>
		/// <param name="processingTime">
		///   The consumed processing time.
		/// </param>
		void InputPluginInitTime(TerrariaPlugin plugin, TimeSpan processingTime);

		/// <summary>
		///   Provides the profiler with the processing time consumed by one of a plugin's registered handlers.
		/// </summary>
		/// <param name="plugin">
		///   The plugin which registered the handler.
		/// </param>
		/// <param name="hookName">
		///   The name of the hook the handler is registered for.
		/// </param>
		/// <param name="processingTime">
		///   The consumed processing time.
		/// </param>
		void InputPluginHandlerTime(TerrariaPlugin plugin, string hookName, TimeSpan processingTime);

		/// <summary>
		///   Provides the profiler with the processing time of a named custom operation performed by a plugin. This allows 
		///   plugins to pass performance measurements of any long time operations to the profiler.
		/// </summary>
		/// <param name="plugin">
		///   The plugin which performed the operation.
		/// </param>
		/// <param name="operation">
		///   The name of the operation. It's wise to use the same name for any recurring operation, allowing the profiler
		///   to produce better reports.
		/// </param>
		/// <param name="processingTime">
		///   The consumed processing time.
		/// </param>
		void InputPluginCustomProcessingTime(TerrariaPlugin plugin, string operation, TimeSpan processingTime);

		/// <summary>
		///   Provides the profiler with the exception thrown by one of a plugin's registered handlers. This allows to easily
		///   identify problematic plugins, which may not handle their exceptions properly and thus cause performance drawbacks
		///   or other problems, by profiling.
		/// </summary>
		/// <param name="plugin">
		///   The plugin which registered the handler.
		/// </param>
		/// <param name="hookName">
		///   The name of the hook the handler is registered for.
		/// </param>
		/// <param name="exception">
		///   The exception thrown by the plugin.
		/// </param>
		void InputPluginHandlerExceptionThrown(TerrariaPlugin plugin, string hookName, Exception exception);

		/// <summary>
		///   Provides the profiler with the processing time consumed by a plugin's DeInitialize and Dispose method.
		/// </summary>
		/// <param name="plugin">
		///   The plugin which registered the handler.
		/// </param>
		/// <param name="processingTime">
		///   The consumed processing time.
		/// </param>
		void InputPluginUnloadTime(TerrariaPlugin plugin, TimeSpan processingTime);
	}
}
