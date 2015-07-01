using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Terraria.Graphics.Effects
{
	internal abstract class CustomSky : GameEffect
	{
		protected CustomSky()
		{
		}

		public abstract void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth);

		public virtual float GetCloudAlpha()
		{
			return 1f;
		}

		public abstract bool IsActive();

		public virtual Color OnTileColor(Color inColor)
		{
			return inColor;
		}

		public abstract void Reset();

		public abstract void Update();
	}
}