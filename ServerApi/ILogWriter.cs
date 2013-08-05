using System;
using System.Diagnostics;
using System.Linq;

namespace ServerApi
{
  /// <summary>
  ///   Implements a server log writer. Methods of this implementation are generally expected to be thread safe.
  /// </summary>
  public interface ILogWriter
  {
    /// <summary>
    ///   Called before this log writer is detached, that is when the server is shutting down or the log writer is replaced by 
    ///   another log writer.
    /// </summary>
    void Detach();

    /// <summary>
    ///   Expects the log writer to write a line produced by the server itself. This method should never be called by a plugin.
    /// </summary>
    /// <param name="message">
    ///   The message to write.
    /// </param>
    /// <param name="kind">
    ///   The kind of message.
    /// </param>
    void ServerWriteLine(string message, TraceLevel kind);

    /// <summary>
    ///   Expects the log writer to write a line produced by a plugin.
    /// </summary>
    /// <param name="plugin">
    ///   The plugin writing the line.
    /// </param>
    /// <param name="message">
    ///   The message to write.
    /// </param>
    /// <param name="kind">
    ///   The kind of message.
    /// </param>
    void PluginWriteLine(TerrariaPlugin plugin, string message, TraceLevel kind);
  }
}