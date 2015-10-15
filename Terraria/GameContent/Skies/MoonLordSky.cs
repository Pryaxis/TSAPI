using XNA;
using System;
using Terraria;
using Terraria.Graphics.Effects;

namespace Terraria.GameContent.Skies
{
	internal class MoonLordSky : CustomSky
	{
		private Random _random = new Random();

		private bool _isActive;

		private int _moonLordIndex = -1;

		public MoonLordSky()
		{
		}

		internal override void Activate(Vector2 position, params object[] args)
		{
			this._isActive = true;
		}

		internal override void Deactivate(params object[] args)
		{
			this._isActive = false;
		}

		public override void Draw(float minDepth, float maxDepth)
		{
			if (maxDepth >= 0f && minDepth < 0f)
			{
				float intensity = this.GetIntensity();
			}
		}

		public override float GetCloudAlpha()
		{
			return 0f;
		}

		private float GetIntensity()
		{
			if (!this.UpdateMoonLordIndex())
			{
				return 0f;
			}
			float single = 0f;
			if (this._moonLordIndex != -1)
			{
				single = Vector2.Distance(Main.player[Main.myPlayer].Center, Main.npc[this._moonLordIndex].Center);
			}
			return 1f - Utils.SmoothStep(3000f, 6000f, single);
		}

		public override bool IsActive()
		{
			return this._isActive;
		}

		public override void OnLoad()
		{
		}

		public override Color OnTileColor(Color inColor)
		{
			float intensity = this.GetIntensity();
			return new Color(Vector4.Lerp(new Vector4(0.5f, 0.8f, 1f, 1f), inColor.ToVector4(), 1f - intensity));
		}

		public override void Reset()
		{
			this._isActive = false;
		}

		public override void Update()
		{
		}

		private bool UpdateMoonLordIndex()
		{
			if (this._moonLordIndex >= 0 && Main.npc[this._moonLordIndex].active && Main.npc[this._moonLordIndex].type == 398)
			{
				return true;
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
			return num != -1;
		}
	}
}
