using System;
using System.Runtime.InteropServices;

namespace Terraria.Utilities
{
	public static class FileOperationAPIWrapper
	{
		private static bool DeleteCompletelySilent(string path)
		{
			return FileOperationAPIWrapper.DeleteFile(path, FileOperationAPIWrapper.FileOperationFlags.FOF_SILENT | FileOperationAPIWrapper.FileOperationFlags.FOF_NOCONFIRMATION | FileOperationAPIWrapper.FileOperationFlags.FOF_NOERRORUI);
		}

		private static bool DeleteFile(string path, FileOperationAPIWrapper.FileOperationFlags flags)
		{
			bool flag;
			try
			{
				FileOperationAPIWrapper.SHFILEOPSTRUCT sHFILEOPSTRUCT = new FileOperationAPIWrapper.SHFILEOPSTRUCT()
				{
					wFunc = FileOperationAPIWrapper.FileOperationType.FO_DELETE,
					pFrom = string.Concat(path, '\0', '\0'),
					fFlags = flags
				};
				FileOperationAPIWrapper.SHFILEOPSTRUCT sHFILEOPSTRUCT1 = sHFILEOPSTRUCT;
				//FileOperationAPIWrapper.SHFileOperation(ref sHFILEOPSTRUCT1);
				flag = true;
			}
			catch (Exception)
			{
#if DEBUG
				throw;
				System.Diagnostics.Debugger.Break();

#endif
				flag = false;
			}
			return flag;
		}

		public static bool MoveToRecycleBin(string path)
		{
			return FileOperationAPIWrapper.Send(path, FileOperationAPIWrapper.FileOperationFlags.FOF_SILENT | FileOperationAPIWrapper.FileOperationFlags.FOF_NOCONFIRMATION | FileOperationAPIWrapper.FileOperationFlags.FOF_NOERRORUI);
		}

		private static bool Send(string path, FileOperationAPIWrapper.FileOperationFlags flags)
		{
			bool flag;
			try
			{
				FileOperationAPIWrapper.SHFILEOPSTRUCT sHFILEOPSTRUCT = new FileOperationAPIWrapper.SHFILEOPSTRUCT()
				{
					wFunc = FileOperationAPIWrapper.FileOperationType.FO_DELETE,
					pFrom = string.Concat(path, '\0', '\0'),
					fFlags = (FileOperationAPIWrapper.FileOperationFlags)((ushort)(FileOperationAPIWrapper.FileOperationFlags.FOF_ALLOWUNDO | flags))
				};
				FileOperationAPIWrapper.SHFILEOPSTRUCT sHFILEOPSTRUCT1 = sHFILEOPSTRUCT;
				//FileOperationAPIWrapper.SHFileOperation(ref sHFILEOPSTRUCT1);
				flag = true;
			}
			catch (Exception)
			{
#if DEBUG
				throw;
				System.Diagnostics.Debugger.Break();

#endif
				flag = false;
			}
			return flag;
		}

		private static bool Send(string path)
		{
			return FileOperationAPIWrapper.Send(path, FileOperationAPIWrapper.FileOperationFlags.FOF_NOCONFIRMATION | FileOperationAPIWrapper.FileOperationFlags.FOF_WANTNUKEWARNING);
		}

		[Flags]
		private enum FileOperationFlags : ushort
		{
			FOF_SILENT = 4,
			FOF_NOCONFIRMATION = 16,
			FOF_ALLOWUNDO = 64,
			FOF_SIMPLEPROGRESS = 256,
			FOF_NOERRORUI = 1024,
			FOF_WANTNUKEWARNING = 16384
		}

		private enum FileOperationType : uint
		{
			FO_MOVE = 1,
			FO_COPY = 2,
			FO_DELETE = 3,
			FO_RENAME = 4
		}

		private struct SHFILEOPSTRUCT
		{
			public IntPtr hwnd;

			public FileOperationAPIWrapper.FileOperationType wFunc;

			public string pFrom;

			public string pTo;

			public FileOperationAPIWrapper.FileOperationFlags fFlags;

			public bool fAnyOperationsAborted;

			public IntPtr hNameMappings;

			public string lpszProgressTitle;
		}
	}
}