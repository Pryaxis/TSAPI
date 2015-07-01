using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Dyes
{
	internal class LegacyHairShaderData : HairShaderData
	{
		private LegacyHairShaderData.ColorProcessingMethod _colorProcessor;

		public LegacyHairShaderData() : base(null, null)
		{
			this._shaderDisabled = true;
		}

		public override Color GetColor(Player player, Color lightColor)
		{
			bool flag = true;
			Color color = this._colorProcessor(player, player.hairColor, ref flag);
			if (!flag)
			{
				return color;
			}
			return new Color(color.ToVector4() * lightColor.ToVector4());
		}

		public LegacyHairShaderData UseLegacyMethod(LegacyHairShaderData.ColorProcessingMethod colorProcessor)
		{
			this._colorProcessor = colorProcessor;
			return this;
		}

		public delegate Color ColorProcessingMethod(Player player, Color color, ref bool lighting);
	}
}