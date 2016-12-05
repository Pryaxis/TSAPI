using NDesk.Options;
using OTAPI.Patcher.Engine;

using System;
using System.Linq;

namespace TShock.Modifications.Bootstrapper
{
	class Program
	{
		static Patcher patcher;
		static OptionSet options;
		
		static void Main(string[] args)
		{
			string sourceAsm = null;
			string modificationGlob = null;
			string outputPath = null;

			Console.WriteLine("Open Terraria API v2.0");

			if (args.Length == 0)
			{
				args = args.Concat(new[]
				{
					@"-in=OTAPI.dll",
					@"-mod=..\..\..\TShock.Modifications.**\bin\Debug\TShock.Modifications.*.dll",
					@"-o=Output\OTAPI.dll"
				}).ToArray();
			}

			options = new OptionSet();
			options.Add("in=|source=", "specifies the source assembly to patch",
				op => sourceAsm = op);
			options.Add("mod=|modifications=", "Glob specifying the path to modification assemblies that will run against the target assembly.",
				op => modificationGlob = op);
			options.Add("o=|output=", "Specifies the output assembly that has had all modifications applied.",
				op => outputPath = op);

			options.Parse(args);

			if (string.IsNullOrEmpty(sourceAsm) == true
				|| string.IsNullOrEmpty(modificationGlob) == true)
			{
				options.WriteOptionDescriptions(Console.Out);
				return;
			}

			System.IO.Directory.CreateDirectory("Output");

			patcher = new Patcher(sourceAsm, new[] {
				modificationGlob
			}, outputPath);
			patcher.Run();
		}
	}
}
