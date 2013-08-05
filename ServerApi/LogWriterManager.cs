using System;
using System.Diagnostics;

namespace ServerApi
{
	public sealed class LogWriterManager
	{
		internal ServerLogWriter DefaultLogWriter
		{
			get; 
			private set;
		}
		internal ILogWriter LogWriter
		{
			get; 
			private set;
		}
		public string LogWriterName
		{
			get { return this.LogWriter.Name; }
		}

		internal LogWriterManager()
		{
			this.DefaultLogWriter = new ServerLogWriter();
			this.Attach(this.DefaultLogWriter);
		}

		public void Attach(ILogWriter newLogWriter)
		{
			if (newLogWriter == null)
				throw new ArgumentNullException("newLogWriter");
			if (newLogWriter == this.LogWriter)
				return;

			ILogWriter prevLogWriter = this.LogWriter;
			Exception detachException = null;
			if (this.LogWriter != null)
			{
				try
				{
					prevLogWriter.Detach();
				}
				catch (Exception ex)
				{
					detachException = ex;
				}

				PluginApi.LogWriter.ServerWriteLine(
					string.Format("Log writer \"{0}\" is being detached.", this.LogWriterName), TraceLevel.Verbose);
			}

			this.LogWriter = newLogWriter;

			PluginApi.LogWriter.ServerWriteLine(
				string.Format("Log writer \"{0}\" has been attached.", this.LogWriterName), TraceLevel.Verbose);

			if (detachException != null)
				this.ServerWriteLine(
					string.Format("Log writer \"{0}\" had thrown an unhandled exception:\n{1}", prevLogWriter.Name, detachException), 
					TraceLevel.Error);
		}

		internal void ServerWriteLine(string message, TraceLevel kind)
		{
			try
			{
				this.LogWriter.ServerWriteLine(message, kind);
			}
			catch (Exception ex)
			{
				this.DefaultLogWriter.ServerWriteLine(string.Format(
					"The attached log writer \"{0}\" has thrown an unexpected exception:\n{1}", this.LogWriterName, ex),
					TraceLevel.Error);
			}
		}

		public void PluginWriteLine(TerrariaPlugin plugin, string message, TraceLevel kind)
		{
			try
			{
				LogWriter.PluginWriteLine(plugin, message, kind);
			}
			catch (Exception ex)
			{
				DefaultLogWriter.ServerWriteLine(string.Format(
					"The attached log writer \"{0}\" has thrown an unexpected exception:\n{1}", this.LogWriterName, ex),
					TraceLevel.Error);
			}
		}
	}
}
