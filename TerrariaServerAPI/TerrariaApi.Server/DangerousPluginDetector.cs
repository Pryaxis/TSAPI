using System;
using System.Collections.Generic;
using System.Reflection;

namespace TerrariaApi.Server
{
	/// <summary>
	/// Determines if a plugin is on a fixed list of malicious plugins based on the SHA512 of
	/// its Assembly's AssemblyName's Name and a given version.
	/// (The version check includes all assemblies at or below that version).
	/// (The version is the version reported by the AssemblyVersion information, not the plugin version)
	/// </summary>
	public class DangerousPluginDetector
	{
		/// <summary>
		/// Pairs of sha512(AssemblyName.Name, Version) where
		/// Version and all prior are dangerous. (The goal is to obfcuscate
		/// the Assembly's name in the codebase so that security advisories
		/// can be released without tipping off people which plugin it is
		/// until after the TSAPI binary is distributed.
		/// </summary>
		private readonly Dictionary<string, Version> dangerousPlugins = new Dictionary<string, Version>();

		/// <summary>
		/// Returns an initialized dangerous plugin detector with a readonly rule set.
		/// </summary>
		public DangerousPluginDetector()
		{
			// https://github.com/Pryaxis/Plugins/security/advisories/GHSA-w3h6-j2gm-qf7q
			dangerousPlugins.Add("1a55337d8d740e2609ed92b0922fd6bf04c31e15bf5aedcf160add043f8c53a2d58a245de30db3278e0fe4619193304f709c97467869339252ce6d32aabd7f83", new Version(1, 2, 0, 0));
			// https://github.com/Pryaxis/Plugins/security/advisories/GHSA-qj59-99v9-3gww
			dangerousPlugins.Add("e643d216d276bec8c51016aee217444501c03aec7e4bef1f1e5d1ae2d3f3239e3a27012ba64c685c0a24db1f62c2c20211cc8492b1f97a5114fd334ecba67dfb", new Version(1, 0, 1, 0));
		}

		/// <summary>
		/// Determines if the assembly has been previously identified to be malicious.
		/// It does this by reading the Assembly's name and the version, then checking the SHA512 hash
		/// of the assembly against a known malicious list. It's obfuscated to allow releasing without
		/// announcing which assembly is being marked as malicious, to give time for server operators
		/// to respond without simply disclosing that an assembly they run is malicious.
		/// (This is a thin layer of protection and not at all bulletproof).
		/// Will not flag assemblies that are "newer" than the given version in the list.
		/// </summary>
		/// <param name="assembly">The Assembly to check against the malicious list.</param>
		/// <returns>True if the assembly is known to be malicious.</returns>
		public bool MaliciousAssembly(Assembly assembly)
		{
			AssemblyName name = assembly.GetName();
			Version ver = name.Version;

			var hash = SHA512(name.Name).ToLower();

			foreach (KeyValuePair<string, Version> kvp in dangerousPlugins)
			{
				if ((kvp.Key.Trim() == hash))
				{
					if (kvp.Value >= ver)
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Returns the associated SHA512 hash of a given input.
		/// As described in Nazar's stackoverflow post, mostly because the underlying C# API is not intuitive.
		/// (A lot of boilerplate is required for something that is require 'digest'; Digest::SHA512.hexdigest(str) in ruby).
		/// https://stackoverflow.com/a/39131803
		/// </summary>
		/// <param name="input">The input string to hash</param>
		/// <returns>The SHA512 hash of the given string as a string</returns>
		private string SHA512(string input)
		{
			var bytes = System.Text.Encoding.UTF8.GetBytes(input);
			using (var hash = System.Security.Cryptography.SHA512.Create())
			{
				var hashedInputBytes = hash.ComputeHash(bytes);

				var hashedInputStringBuilder = new System.Text.StringBuilder(128);
				foreach (var b in hashedInputBytes)
					hashedInputStringBuilder.Append(b.ToString("X2"));
				return hashedInputStringBuilder.ToString();
			}
		}
	}
}
