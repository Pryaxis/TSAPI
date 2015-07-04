using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Terraria;

namespace Terraria.Utilities
{
	public class CrashDump
	{
		public CrashDump()
		{
		}

		public static void Create()
		{
			DateTime localTime = DateTime.Now.ToLocalTime();
			string[] str = new string[] { "TerrariaServer", Main.versionNumber, " ", localTime.Year.ToString("D4"), "-", localTime.Month.ToString("D2"), "-", localTime.Day.ToString("D2"), " ", localTime.Hour.ToString("D2"), "_", localTime.Minute.ToString("D2"), "_", localTime.Second.ToString("D2"), ".dmp" };
			CrashDump.Create(string.Concat(str));
		}

		public static void Create(string path)
		{
			bool flag = Program.LaunchParameters.ContainsKey("-fulldump");
			using (FileStream fileStream = File.Create(path))
			{
				Process currentProcess = Process.GetCurrentProcess();
				//CrashDump.MiniDumpWriteDump(currentProcess.Handle, currentProcess.Id, fileStream.SafeFileHandle.DangerousGetHandle(), (flag ? CrashDump.MINIDUMP_TYPE.MiniDumpWithFullMemory : CrashDump.MINIDUMP_TYPE.MiniDumpWithIndirectlyReferencedMemory), IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
			}
		}

		public static void CreateFull()
		{
			DateTime localTime = DateTime.Now.ToLocalTime();
			string[] str = new string[] { "DMP-FULL TerrariaServer", Main.versionNumber, " ", localTime.Year.ToString("D4"), "-", localTime.Month.ToString("D2"), "-", localTime.Day.ToString("D2"), " ", localTime.Hour.ToString("D2"), "_", localTime.Minute.ToString("D2"), "_", localTime.Second.ToString("D2"), ".dmp" };
			using (FileStream fileStream = File.Create(string.Concat(str)))
			{
				Process currentProcess = Process.GetCurrentProcess();
				//CrashDump.MiniDumpWriteDump(currentProcess.Handle, currentProcess.Id, fileStream.SafeFileHandle.DangerousGetHandle(), CrashDump.MINIDUMP_TYPE.MiniDumpWithFullMemory, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
			}
		}

		internal enum MINIDUMP_TYPE
		{
			MiniDumpNormal = 0,
			MiniDumpWithDataSegs = 1,
			MiniDumpWithFullMemory = 2,
			MiniDumpWithHandleData = 4,
			MiniDumpFilterMemory = 8,
			MiniDumpScanMemory = 16,
			MiniDumpWithUnloadedModules = 32,
			MiniDumpWithIndirectlyReferencedMemory = 64,
			MiniDumpFilterModulePaths = 128,
			MiniDumpWithProcessThreadData = 256,
			MiniDumpWithPrivateReadWriteMemory = 512,
			MiniDumpWithoutOptionalData = 1024,
			MiniDumpWithFullMemoryInfo = 2048,
			MiniDumpWithThreadInfo = 4096,
			MiniDumpWithCodeSegs = 8192
		}
	}
}