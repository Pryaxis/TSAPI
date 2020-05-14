using System;
using System.Diagnostics;

namespace TerrariaApi.Server
{
	public sealed class LogWriterManager
	{
		internal ServerLogWriter DefaultLogWriter
		{
			get; 
			private set;
		}
		internal ILogWriter WrappedLogWriter
		{
			get; 
			private set;
		}
		public string LogWriterName
		{
			get { return this.WrappedLogWriter.Name; }
		}

		internal LogWriterManager()
		{
			this.DefaultLogWriter = new ServerLogWriter();
			this.WrappedLogWriter = this.DefaultLogWriter;
		}

		public void Attach(ILogWriter newLogWriter)
		{
			if (newLogWriter == null)
				throw new ArgumentNullException("newLogWriter");
			if (newLogWriter == this.WrappedLogWriter)
				return;

			ILogWriter prevLogWriter = this.WrappedLogWriter;
			Exception detachException = null;
			if (this.WrappedLogWriter != null)
			{
				try
				{
					prevLogWriter.Detach();
				}
				catch (Exception ex)
				{
					detachException = ex;
				}

				this.WrappedLogWriter.ServerWriteLine(
					string.Format("Log writer \"{0}\" is being detached.", this.LogWriterName), TraceLevel.Verbose);
			}

			this.WrappedLogWriter = newLogWriter;

			this.WrappedLogWriter.ServerWriteLine(
				string.Format("Log writer \"{0}\" has been attached.", this.LogWriterName), TraceLevel.Verbose);

			if (detachException != null)
				this.ServerWriteLine(
					string.Format("Log writer \"{0}\" had thrown an unexpected exception:\n{1}", prevLogWriter.Name, detachException), 
					TraceLevel.Error);
		}

		internal void Deatch()
		{
			if (this.WrappedLogWriter == null)
				return;

			try
			{
				this.WrappedLogWriter.Detach();
			}
			catch (Exception ex)
			{
				DefaultLogWriter.ServerWriteLine(
					string.Format("Log writer \"{0}\" has thrown an unexpected exception:\n{1}", this.LogWriterName, ex), TraceLevel.Error);
			}

			this.WrappedLogWriter = null;
		}

		internal void ServerWriteLine(string message, TraceLevel kind)
		{
			try
			{
				this.WrappedLogWriter.ServerWriteLine(message, kind);
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
				this.WrappedLogWriter.PluginWriteLine(plugin, message, kind);
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
