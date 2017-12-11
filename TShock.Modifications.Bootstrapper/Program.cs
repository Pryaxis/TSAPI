using System;
using System.IO;
using NDesk.Options;
using OTAPI.Patcher.Engine;

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
			string folder = null;

			Console.WriteLine("TShock Mintaka Bootstrapper, Open Terraria API v2.0");

			if (args.Length == 0)
			{
				if (File.Exists("env.config"))
				{
					using (StreamReader sr = File.OpenText("env.config"))
					{
						folder = sr.ReadLine();
						Console.WriteLine($"Folder set to: " + folder);
					}
				}
				else
				{
					Console.WriteLine("Something went wrong! (env.config not found)");
					Console.ReadLine();
					return;
				}
				args = new[]
				{
					"-in=OTAPI.dll",
					"-mod=" + Path.Combine("..", "..", "..", "TShock.Modifications.**", "bin", folder, "TShock.Modifications.*.dll"),
					"-o=" + Path.Combine("Output", "OTAPI.dll")
				};
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
			}, outputPath)
			{
				PackModifications = true
			};
			patcher.Run();
		}
	}
}
