using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TerrariaApi.Server;

namespace Reporting
{
	internal class CrashReporter : IDisposable
	{
		internal CrashReporter()
		{
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		}

		internal void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			ServerApi.LogWriter.ServerWriteLine("An unhandled exception has occured in TSAPI, and a crash report will be generated.", TraceLevel.Error);
			ServerApi.LogWriter.ServerWriteLine("Generating a crash report, please wait...", TraceLevel.Error);

			string path = CollectCrashReport(e.ExceptionObject as Exception);

			ServerApi.LogWriter.ServerWriteLine("Crash report saved at " + path, TraceLevel.Error);

			if (e.IsTerminating)
			{
				ServerApi.LogWriter.ServerWriteLine("The process will terminate.", TraceLevel.Error);
			}
		}

		internal string CollectCrashReport(Exception ex)
		{
			Process process = Process.GetCurrentProcess();
			dynamic systemInfo = GenerateSystemProfile(ex);
			string zipTempName = Path.GetTempFileName();
			string dumpTempName = Path.GetTempFileName();
			string reportFileName = string.Format("crash_{0}.zip", DateTime.Now.ToFileTimeUtc());
			string reportPath = Path.Combine("crashes", reportFileName);

			using (FileStream fs = new FileStream(dumpTempName, FileMode.OpenOrCreate))
			{
				if (Native.MiniDumpWriteDump(process.Handle, (uint)process.Id, fs.SafeFileHandle, Native.MINIDUMP_TYPE.WithFullMemory,
					IntPtr.Zero, IntPtr.Zero, IntPtr.Zero) == false)
				{
					throw new Win32Exception(Marshal.GetLastWin32Error());
				}
			}

			using (FileStream zipFs = new FileStream(zipTempName, FileMode.OpenOrCreate))
			using (ZipArchive zipArchive = new ZipArchive(zipFs, ZipArchiveMode.Create))
			{
				using (StreamWriter sw = new StreamWriter(zipArchive.CreateEntry("crash.json", CompressionLevel.Optimal).Open()))
				{
					sw.Write(JObject.FromObject(systemInfo).ToString());
				}

				try
				{
					using (FileStream fs = new FileStream(dumpTempName, FileMode.Open))
					{
						fs.CopyTo(zipArchive.CreateEntry("heap.dump", CompressionLevel.Optimal).Open());
					}
				}
				finally
				{
					/*
					 * The memory dmp files are large, and should be axed regardless of if the 
					 * process could copy it to the zip file or not.
					 */
					File.Delete(dumpTempName);
				}

			}

			if (Directory.Exists("crashes") == false)
			{
				Directory.CreateDirectory("crashes");
			}

			File.Move(zipTempName, reportPath);
			
			return reportFileName;
		}

		~CrashReporter()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		internal virtual void Dispose(bool disposing)
		{

			if (disposing)
			{
				AppDomain.CurrentDomain.UnhandledException -= CurrentDomain_UnhandledException;
			}
		}

		internal dynamic GetMemoryInfoMono()
		{
			return new
			{

			};
		}

		internal dynamic GetProcessMemoryInfo(string processName)
		{
			var memory = new PerformanceCounterCategory(".NET CLR Memory", ".").GetCounters(processName);

			return new
			{
				TotalMiB = memory.FirstOrDefault(i => i.CounterName == "# Bytes in all Heaps").NextValue() / 1024 / 1024,
				LOHSizeMiB = memory.FirstOrDefault(i => i.CounterName == "Large Object Heap size").NextValue() / 1024 / 1024,
			};
		}

		internal dynamic GetMemoryInfo()
		{
			//if (Type.GetType("Mono.Runtime") != null)
			//{
			//	return GetMemoryInfoMono();
			//}


			return from i in new PerformanceCounterCategory(".NET CLR Memory").GetInstanceNames().Where(i => i.Contains("TerrariaServer"))
				   select new
				   {
					   Process = i,
					   Info = GetProcessMemoryInfo(i)
				   };
		}

		internal dynamic GenerateExceptionData(Exception ex)
		{
			if (ex == null)
			{
				return null;
			}

			return new
			{
				message = ex.Message,
				type = ex.GetType().Name,
				trace = ex.StackTrace,
				inner = GenerateExceptionData(ex.InnerException)
			};
		}

		internal dynamic GenerateSystemProfile(Exception ex)
		{
			dynamic systemProfile = new
			{
				os = new
				{
					x64 = Environment.Is64BitOperatingSystem ? "yes" : "no",
					x64Process = Environment.Is64BitProcess ? "yes" : "no",
					Platform = Environment.OSVersion.Platform.ToString(),
					Version = Environment.OSVersion.VersionString,
				},

				hardware = new
				{
					CPUs = Environment.ProcessorCount,
					CPUID = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER"),
				},

				server = new
				{
					Players = Main.player.Count(i => i != null && i.active == true),
					MaxPlayers = Main.maxPlayers,
					WorldName = Main.worldName,
					WorldFile = Main.worldPathName,
					Time = Main.time,
				},

				process = new
				{
					curRelease = Main.curRelease,
					TSAPIVersion = Assembly.GetCallingAssembly().GetName().Version.ToString(),
					Uptime = DateTime.Now.Subtract(Process.GetCurrentProcess().StartTime).ToString(),
					Process.GetCurrentProcess().StartInfo.WorkingDirectory,
					Process.GetCurrentProcess().StartInfo.Arguments
				},

				memory = GetMemoryInfo(),

				/*
				frame = from i in new System.Diagnostics.StackTrace(ex, fNeedFileInfo: true).GetFrames()
						select new
						{
							Method = i.GetMethod().Name,
							File = i.GetFileName(),
							Offset = i.GetFileLineNumber()
						},*/

				plugins = from i in TerrariaApi.Server.ServerApi.Plugins
						  orderby i.Plugin.Order
						  select new
						  {
							  Name = i.Plugin.Name,
							  Author = i.Plugin.Author,
							  Version = i.Plugin.Version.ToString(),
						  },

				exception = GenerateExceptionData(ex)
			};

			return systemProfile;
		}

	}
}
