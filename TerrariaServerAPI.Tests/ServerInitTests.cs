using NUnit.Framework;

namespace TerrariaServerAPI.Tests;

public class ServerInitTests : BaseTest
{
	[Test]
	public void EnsureBoots()
	{
		EnsureInitialised();
	}
}
