using XNA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Terraria;

namespace Terraria.GameContent.Events
{
	internal class BlameNPCTest
	{
		public static Dictionary<int, int> npcTypes;

		public static List<KeyValuePair<int, int>> mostSeen;

		static BlameNPCTest()
		{
			BlameNPCTest.npcTypes = new Dictionary<int, int>();
			BlameNPCTest.mostSeen = new List<KeyValuePair<int, int>>();
		}

		public BlameNPCTest()
		{
		}

		public static void Draw()
		{
		}

		public static void Update(int newEntry)
		{
			if (!BlameNPCTest.npcTypes.ContainsKey(newEntry))
			{
				BlameNPCTest.npcTypes[newEntry] = 1;
			}
			else
			{
				Dictionary<int, int> item = BlameNPCTest.npcTypes;
				Dictionary<int, int> nums = item;
				int num = newEntry;
				item[num] = nums[num] + 1;
			}
			BlameNPCTest.mostSeen = BlameNPCTest.npcTypes.ToList<KeyValuePair<int, int>>();
			BlameNPCTest.mostSeen.Sort((KeyValuePair<int, int> x, KeyValuePair<int, int> y) => x.Value.CompareTo(y.Value));
		}
	}
}