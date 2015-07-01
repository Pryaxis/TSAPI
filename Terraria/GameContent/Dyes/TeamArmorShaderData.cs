using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Dyes
{
	internal class TeamArmorShaderData : ArmorShaderData
	{
		private static bool isInitialized;

		private static ArmorShaderData[] dustShaderData;

		static TeamArmorShaderData()
		{
			TeamArmorShaderData.isInitialized = false;
		}

		public TeamArmorShaderData(Effect shader, string passName) : base(shader, passName)
		{
			if (!TeamArmorShaderData.isInitialized)
			{
				TeamArmorShaderData.isInitialized = true;
				TeamArmorShaderData.dustShaderData = new ArmorShaderData[(int)Main.teamColor.Length];
				for (int i = 1; i < (int)Main.teamColor.Length; i++)
				{
					TeamArmorShaderData.dustShaderData[i] = (new ArmorShaderData(shader, passName)).UseColor(Main.teamColor[i]);
				}
				TeamArmorShaderData.dustShaderData[0] = new ArmorShaderData(shader, "Default");
			}
		}

		public override void Apply(Entity entity, DrawData? drawData)
		{
			Player player = entity as Player;
			if (player == null || player.team == 0)
			{
				TeamArmorShaderData.dustShaderData[0].Apply(player, drawData);
				return;
			}
			base.UseColor(Main.teamColor[player.team]);
			base.Apply(player, drawData);
		}

		public override ArmorShaderData GetSecondaryShader(Entity entity)
		{
			return TeamArmorShaderData.dustShaderData[(entity as Player).team];
		}
	}
}