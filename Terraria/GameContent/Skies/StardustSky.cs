using XNA;
using System;
using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Effects;

namespace Terraria.GameContent.Skies
{
	internal class StardustSky : CustomSky
	{
		private Random _random = new Random();

		private bool _isActive;

		private StardustSky.Star[] _stars;

		private float _fadeOpacity;

		public StardustSky()
		{
		}

		internal override void Activate(Vector2 position, params object[] args)
		{
		}

		internal override void Deactivate(params object[] args)
		{
			this._isActive = false;
		}

		public override void Draw(float minDepth, float maxDepth)
		{
		}

		public override float GetCloudAlpha()
		{
			return (1f - this._fadeOpacity) * 0.3f + 0.7f;
		}

		public override bool IsActive()
		{
			if (this._isActive)
			{
				return true;
			}
			return this._fadeOpacity > 0.001f;
		}

		public override void OnLoad()
		{
		}

		public override Color OnTileColor(Color inColor)
		{
			Vector4 vector4 = inColor.ToVector4();
			return new Color(Vector4.Lerp(vector4, Vector4.One, this._fadeOpacity * 0.5f));
		}

		public override void Reset()
		{
			this._isActive = false;
		}

		private int SortMethod(StardustSky.Star meteor1, StardustSky.Star meteor2)
		{
			return meteor2.Depth.CompareTo(meteor1.Depth);
		}

		public override void Update()
		{
			if (this._isActive)
			{
				this._fadeOpacity = Math.Min(1f, 0.01f + this._fadeOpacity);
				return;
			}
			this._fadeOpacity = Math.Max(0f, this._fadeOpacity - 0.01f);
		}

		private struct Star
		{
			public Vector2 Position;

			public float Depth;

			public int TextureIndex;

			public float SinOffset;

			public float AlphaFrequency;

			public float AlphaAmplitude;
		}
	}
}