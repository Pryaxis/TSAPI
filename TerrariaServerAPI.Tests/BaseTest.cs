using NUnit.Framework;
using System.Runtime.InteropServices;

namespace TerrariaServerAPI.Tests;

public class BaseTest
{
	private static bool _initialized;

	[OneTimeSetUp]
	public void EnsureInitialised()
	{
		if (!_initialized)
		{
			TestContext.Out.WriteLine($"Test architecture {RuntimeInformation.ProcessArchitecture}");

			bool invoked = false;
			HookEvents.HookDelegate<Terraria.Main, HookEvents.Terraria.Main.DedServEventArgs> cb = (instance, args) =>
			{
				invoked = true;
				// DedServ typically requires input, so no need to continue execution
				args.ContinueExecution = false;
				// DedServ calls the following, which is needed for subsequent tests
				instance.Initialize();
			};
			HookEvents.Terraria.Main.DedServ += cb;

			TerrariaApi.Server.Program.Main([]);

			HookEvents.Terraria.Main.DedServ -= cb;

			Assert.That(invoked, Is.True);

			_initialized = true;
		}
	}
}
