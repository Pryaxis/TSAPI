using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Shaders
{
	internal class BloodMoonScreenShaderData : ScreenShaderData
	{
		public BloodMoonScreenShaderData(string passName) : base(passName)
		{
		}

		public override void Apply()
		{
			float single = 1f - Utils.SmoothStep((float)Main.worldSurface + 50f, (float)Main.rockLayer + 100f, (Main.screenPosition.Y + (float)(Main.screenHeight / 2)) / 16f);
			base.UseOpacity(single * 0.75f);
			base.Apply();
		}
	}
}