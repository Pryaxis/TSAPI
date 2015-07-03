using XNA;
using System;
using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Effects;

namespace Terraria.GameContent.Skies
{
	internal class SolarSky : CustomSky
	{
		private Random _random = new Random();

		private bool _isActive;

		private SolarSky.Meteor[] _meteors;

		private float _fadeOpacity;

		public SolarSky()
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

		private int SortMethod(SolarSky.Meteor meteor1, SolarSky.Meteor meteor2)
		{
			return meteor2.Depth.CompareTo(meteor1.Depth);
		}

		public override void Update()
		{
		}

		private struct Meteor
		{
			public Vector2 Position;

			public float Depth;

			public int FrameCounter;

			public float Scale;

			public float StartX;
		}
	}
}