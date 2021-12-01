using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace TerrariaServerAPI.Tests
{
	[TestClass]
    public class ServerInitTests
    {
        [TestMethod]
        public void EnsureBoots()
		{
			bool hit = false;
			On.Terraria.Main.DedServ += (orig, instance) =>
			{
				hit = true;
				Debug.WriteLine("Server init process successful");
			};

			TerrariaApi.Server.Program.Main(new string[] { });

			Assert.AreEqual(true, hit);
		}
	}
}
