using System;
using System.Text;

namespace Mintaka.Modifications.UnicodeInput.Callbacks
{
	internal class InitializeConsoleOutputCallback
	{
		internal static void InitializeConsoleOutput()
		{
			if (!Console.IsInputRedirected)
			{
				Console.InputEncoding = Encoding.UTF8;
			}

			if (!Console.IsOutputRedirected)
			{
				Console.OutputEncoding = Encoding.UTF8;
			}
		}
	}
}
