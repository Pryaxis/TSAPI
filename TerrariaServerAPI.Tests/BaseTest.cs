using NUnit.Framework;
using System;
using System.Threading;

namespace TerrariaServerAPI.Tests;

public class BaseTest
{
	private static bool _initialized;

	[OneTimeSetUp]
	public void EnsureInitialised()
	{
		if (!_initialized)
		{
			var are = new AutoResetEvent(false);
			Exception? error = null;
			On.Terraria.Main.hook_DedServ cb = (On.Terraria.Main.orig_DedServ orig, Terraria.Main instance) =>
			{
				instance.Initialize();
				are.Set();
				_initialized = true;
			};
			On.Terraria.Main.DedServ += cb;

			global::TerrariaApi.Server.Program.Main(new string[] { });

			_initialized = are.WaitOne(TimeSpan.FromSeconds(30));

			On.Terraria.Main.DedServ -= cb;

			Assert.That(_initialized, Is.True);
			Assert.That(error, Is.Null);
		}
	}
}
