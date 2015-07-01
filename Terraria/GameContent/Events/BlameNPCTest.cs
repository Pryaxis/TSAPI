using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.UI.Chat;

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

		public static void Draw(SpriteBatch sb)
		{
			if (Main.netDiag || Main.showFrameRate)
			{
				return;
			}
			for (int i = 0; i < BlameNPCTest.mostSeen.Count; i++)
			{
				int num = 200 + i % 13 * 100;
				int num1 = 200 + i / 13 * 30;
				SpriteFont spriteFont = Main.fontItemStack;
				object[] key = new object[4];
				KeyValuePair<int, int> item = BlameNPCTest.mostSeen[i];
				key[0] = item.Key;
				key[1] = " (";
				KeyValuePair<int, int> keyValuePair = BlameNPCTest.mostSeen[i];
				key[2] = keyValuePair.Value;
				key[3] = ")";
				ChatManager.DrawColorCodedString(sb, spriteFont, string.Concat(key), new Vector2((float)num, (float)num1), Color.White, 0f, Vector2.Zero, Vector2.One, -1f, false);
			}
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