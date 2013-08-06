using System;
using System.Diagnostics;
using System.IO;
using TerrariaApi.Server;

namespace Terraria
{
	public class ProgramServer
	{
		private static Main Game;

		private static void Main(string[] args)
		{
			try
			{
				// Must be done before creating Main because its constructor will invoke some of the hooks.
				ServerApi.InitializeHooks();
				Game = new Main();
				
				if (Environment.OSVersion.Platform == PlatformID.Unix)
					Terraria.Main.SavePath = "Terraria";
				else
					Terraria.Main.SavePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "My Games", "Terraria");

				Terraria.Main.WorldPath = Path.Combine(Terraria.Main.SavePath, "Worlds");
				Terraria.Main.PlayerPath = Path.Combine(Terraria.Main.SavePath, "Players");

				try
				{
					ServerApi.Initialize(args, Game);
				}
				catch (Exception ex)
				{
					ServerApi.LogWriter.ServerWriteLine(
						"Startup aborted due to an exception in the Server API initialization:\n" + ex, TraceLevel.Error);

					return;
				}
				
				Game.DedServ();
				ServerApi.DeInitialize();
			}
			catch (Exception ex)
			{
				ServerApi.LogWriter.ServerWriteLine("Server crashed due to an unhandled exception:\n" + ex, TraceLevel.Error);
			}
		}

		/*private static Assembly Compile(string name, string data, bool addfail = true)
		{
			var prov = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });
			var cp = new CompilerParameters();
			cp.GenerateInMemory = true;
			cp.GenerateExecutable = false;
			cp.CompilerOptions = "/d:TERRARIA_API /unsafe";

			foreach (var a in Assemblies)
			{
				if (!cp.ReferencedAssemblies.Contains(a.Location))
					cp.ReferencedAssemblies.Add(a.Location);
			}
			var r = prov.CompileAssemblyFromSource(cp, data);
			if (r.Errors.Count > 0)
			{
				for (int i = 0; i < r.Errors.Count; i++)
				{
					AppendLog("Error compiling: {0}\r\nLine number: {1}, Error number: {2}, Error text: {3}\r\n",
						name, r.Errors[i].Line, r.Errors[i].ErrorNumber, r.Errors[i].ErrorText);
				}
				return null;
			}
			return r.CompiledAssembly;
		}*/
	}
}
