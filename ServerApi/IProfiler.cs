using System;
using System.Diagnostics;
using System.Linq;

namespace ServerApi
{
  /// <summary>
  ///   Implements a server profiler. Methods of this implementation are generally expected to be thread safe.
  /// </summary>
  public interface IProfiler
  {
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
    ///   Provides the profiler with the processing time consumed by a plugin's initialization.
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
    ///   Provides the profiler with the processing time consumed by a plugin's dispose method.
    /// </summary>
    /// <param name="plugin">
    ///   The plugin which registered the handler.
    /// </param>
    /// <param name="processingTime">
    ///   The consumed processing time.
    /// </param>
    void InputPluginDisposeTime(TerrariaPlugin plugin, TimeSpan processingTime);
  }
}