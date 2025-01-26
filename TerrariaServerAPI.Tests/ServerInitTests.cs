using NUnit.Framework;
using System.Runtime.InteropServices;

namespace TerrariaServerAPI.Tests;

public class ServerInitTests : BaseTest
{
	[Test]
	public void EnsureBoots()
	{
		EnsureInitialised();
	}

	[Test]
	public void EnsureRuntimeDetours()
	{
		// Platform exclude doesnt support arm64, so manual check it is...
		if (RuntimeInformation.ProcessArchitecture == Architecture.Arm64)
			Assert.Ignore("Test is not supported on ARM64 architecture.");

		TestContext.Out.WriteLine($"Test architecture {RuntimeInformation.ProcessArchitecture}");

		bool invoked = false;

		On.Terraria.Program.hook_RunGame callback = (orig) => invoked = true;
		On.Terraria.Program.RunGame += callback;

		Terraria.Program.RunGame();

		On.Terraria.Program.RunGame -= callback;

		Assert.That(invoked, Is.True);
	}
}
