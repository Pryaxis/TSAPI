using System;
using System.Collections.Generic;

namespace Terraria.Graphics.Shaders
{
	internal class GameShaders
	{
		public static ArmorShaderDataSet Armor;

		public static HairShaderDataSet Hair;

		public static Dictionary<string, MiscShaderData> Misc;

		static GameShaders()
		{
			GameShaders.Armor = new ArmorShaderDataSet();
			GameShaders.Hair = new HairShaderDataSet();
			GameShaders.Misc = new Dictionary<string, MiscShaderData>();
		}

		public GameShaders()
		{
		}
	}
}