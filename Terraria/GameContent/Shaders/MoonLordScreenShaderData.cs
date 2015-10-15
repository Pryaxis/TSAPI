using System;
using Terraria;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Shaders
{
	internal class MoonLordScreenShaderData : ScreenShaderData
	{
		private int _moonLordIndex = -1;

		public MoonLordScreenShaderData(string passName) : base(passName)
		{
		}

		public override void Apply()
		{
			this.UpdateMoonLordIndex();
			if (this._moonLordIndex != -1)
			{
				base.UseTargetPosition(Main.npc[this._moonLordIndex].Center);
			}
			base.Apply();
		}

		private void UpdateMoonLordIndex()
		{
			if (this._moonLordIndex >= 0 && Main.npc[this._moonLordIndex].active && Main.npc[this._moonLordIndex].type == 398)
			{
				return;
			}
			int num = -1;
			int num1 = 0;
			while (num1 < (int)Main.npc.Length)
			{
				if (!Main.npc[num1].active || Main.npc[num1].type != NPCID.MoonLordCore)
				{
					num1++;
				}
				else
				{
					num = num1;
					break;
				}
			}
			this._moonLordIndex = num;
		}
	}
}
