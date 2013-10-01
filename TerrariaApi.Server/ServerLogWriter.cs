using System;
using System.Diagnostics;
using System.IO;

namespace TerrariaApi.Server
{
	public class ServerLogWriter : ILogWriter, IDisposable
	{
		protected StreamWriter LogFileWriter { get; private set; }

		public string Name
		{
			get { return "Server Log Writer"; }
		}

		public ServerLogWriter(string logFilePath = "ServerLog.txt") {
			try
			{
				this.LogFileWriter = new StreamWriter(logFilePath, true);
			}
			catch (Exception ex)
			{
				try {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Fatal startup exception. Could not write to \"{0}\". Exception details:\n{1}", logFilePath, ex);
				} finally {
					Console.ForegroundColor = ConsoleColor.Gray;
				}

				throw;
			}
			this.LogFileWriter.AutoFlush = true;
		}

		public void Detach()
		{
		}

		public void ServerWriteLine(string message, TraceLevel kind)
		{
			this.WriteLine("Server API", message, kind);
		}

		public void PluginWriteLine(TerrariaPlugin plugin, string message, TraceLevel kind)
		{
			this.WriteLine(plugin.Name, message, kind);
		}

		protected virtual void WriteLine(string context, string message, TraceLevel kind)
		{
			if (kind == TraceLevel.Off)
				return;

			if (kind != TraceLevel.Verbose)
			{
				try {
					switch (kind)
					{
						case TraceLevel.Error:
							Console.ForegroundColor = ConsoleColor.Red;
							break;
						case TraceLevel.Warning:
							Console.ForegroundColor = ConsoleColor.Yellow;
							break;
						case TraceLevel.Info:
							Console.ForegroundColor = ConsoleColor.Gray;
							break;
					}

					Console.WriteLine("[{0}] {1} {2}", context, kind, message);
				} finally {
					Console.ForegroundColor = ConsoleColor.Gray;
				}
			}

			this.LogFileWriter.WriteLine("[{0:MM/dd/yy HH:mm:ss}] [{1}] {2}: {3}", DateTime.Now, context, kind, message);
		}

		~ServerLogWriter()
		{
			this.Dispose(false);
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.LogFileWriter != null)
					this.LogFileWriter.Dispose();
			}
		}
	}
}
