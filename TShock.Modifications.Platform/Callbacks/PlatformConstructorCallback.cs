using System;
using System.Runtime.InteropServices;

namespace Mintaka.Modifications.Platform.Callbacks
{
	internal class PlatformConstructorCallback
	{
		internal static void ChangePlatform(ref ReLogic.OS.Platform platform)
		{
			Type type;

			switch (Environment.OSVersion.Platform)
			{
				case PlatformID.Unix:
					type = typeof(ReLogic.OS.Platform).Assembly.GetType(IsRunningOnMac() ? "ReLogic.OS.OsxPlatform" : "ReLogic.OS.LinuxPlatform");
					break;
				case PlatformID.Win32NT:
					type = typeof(ReLogic.OS.Platform).Assembly.GetType("ReLogic.OS.WindowsPlatform");
					break;
				default:
					throw new NotSupportedException();
			}

			platform = (ReLogic.OS.Platform) Activator.CreateInstance(type);
		}

		[DllImport("libc")]
		private static extern int uname(IntPtr buf);

		private static bool IsRunningOnMac()
		{
			var buf = IntPtr.Zero;
			try
			{
				buf = Marshal.AllocHGlobal(8192);
				// This is a hacktastic way of getting sysname from uname ()
				if (uname(buf) == 0)
				{
					string os = Marshal.PtrToStringAnsi(buf);
					if (os == "Darwin")
					{
						return true;
					}
				}
			}
			catch
			{
				// ignored
			}
			finally
			{
				if (buf != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(buf);
				}
			}
			return false;
		}
	}
}
