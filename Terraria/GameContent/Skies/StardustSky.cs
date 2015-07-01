using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Effects;

namespace Terraria.GameContent.Skies
{
	internal class StardustSky : CustomSky
	{
		private Random _random = new Random();

		private Texture2D _planetTexture;

		private Texture2D _bgTexture;

		private Texture2D[] _starTextures;

		private bool _isActive;

		private StardustSky.Star[] _stars;

		private float _fadeOpacity;

		public StardustSky()
		{
		}

		internal override void Activate(Vector2 position, params object[] args)
		{
			this._fadeOpacity = 0.002f;
			this._isActive = true;
			int num = 200;
			int num1 = 10;
			this._stars = new StardustSky.Star[num * num1];
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				float single = (float)i / (float)num;
				for (int j = 0; j < num1; j++)
				{
					float single1 = (float)j / (float)num1;
					this._stars[num2].Position.X = single * (float)Main.maxTilesX * 16f;
					this._stars[num2].Position.Y = single1 * ((float)Main.worldSurface * 16f + 2000f) - 1000f;
					this._stars[num2].Depth = this._random.NextFloat() * 8f + 1.5f;
					this._stars[num2].TextureIndex = this._random.Next((int)this._starTextures.Length);
					this._stars[num2].SinOffset = this._random.NextFloat() * 6.28f;
					this._stars[num2].AlphaAmplitude = this._random.NextFloat() * 5f;
					this._stars[num2].AlphaFrequency = this._random.NextFloat() + 1f;
					num2++;
				}
			}
			Array.Sort<StardustSky.Star>(this._stars, new Comparison<StardustSky.Star>(this.SortMethod));
		}

		internal override void Deactivate(params object[] args)
		{
			this._isActive = false;
		}

		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (maxDepth >= float.MaxValue && minDepth < float.MaxValue)
			{
				spriteBatch.Draw(Main.blackTileTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Black * this._fadeOpacity);
				spriteBatch.Draw(this._bgTexture, new Rectangle(0, Math.Max(0, (int)((Main.worldSurface * 16 - (double)Main.screenPosition.Y - 2400) * 0.100000001490116)), Main.screenWidth, Main.screenHeight), Color.White * Math.Min(1f, (Main.screenPosition.Y - 800f) / 1000f * this._fadeOpacity));
				Vector2 vector2 = new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
				Vector2 vector21 = 0.01f * (new Vector2((float)Main.maxTilesX * 8f, (float)Main.worldSurface / 2f) - Main.screenPosition);
				Rectangle? nullable = null;
				spriteBatch.Draw(this._planetTexture, (vector2 + new Vector2(-200f, -200f)) + vector21, nullable, (Color.White * 0.9f) * this._fadeOpacity, 0f, new Vector2((float)(this._planetTexture.Width >> 1), (float)(this._planetTexture.Height >> 1)), 1f, SpriteEffects.None, 1f);
			}
			int num = -1;
			int num1 = 0;
			for (int i = 0; i < (int)this._stars.Length; i++)
			{
				float depth = this._stars[i].Depth;
				if (num == -1 && depth < maxDepth)
				{
					num = i;
				}
				if (depth <= minDepth)
				{
					break;
				}
				num1 = i;
			}
			if (num == -1)
			{
				return;
			}
			float single = Math.Min(1f, (Main.screenPosition.Y - 1000f) / 1000f);
			Vector2 vector22 = Main.screenPosition + new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
			Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
			for (int j = num; j < num1; j++)
			{
				Vector2 vector23 = new Vector2(1f / this._stars[j].Depth, 1.1f / this._stars[j].Depth);
				Vector2 position = (((this._stars[j].Position - vector22) * vector23) + vector22) - Main.screenPosition;
				if (rectangle.Contains((int)position.X, (int)position.Y))
				{
					float single1 = (float)Math.Sin((double)(this._stars[j].AlphaFrequency * Main.GlobalTime + this._stars[j].SinOffset)) * this._stars[j].AlphaAmplitude + this._stars[j].AlphaAmplitude;
					float single2 = (float)Math.Sin((double)(this._stars[j].AlphaFrequency * Main.GlobalTime * 5f + this._stars[j].SinOffset)) * 0.1f - 0.1f;
					single1 = MathHelper.Clamp(single1, 0f, 1f);
					Texture2D texture2D = this._starTextures[this._stars[j].TextureIndex];
					Rectangle? nullable1 = null;
					spriteBatch.Draw(texture2D, position, nullable1, ((((Color.White * single) * single1) * 0.8f) * (1f - single2)) * this._fadeOpacity, 0f, new Vector2((float)(texture2D.Width >> 1), (float)(texture2D.Height >> 1)), (vector23.X * 0.5f + 0.5f) * (single1 * 0.3f + 0.7f), SpriteEffects.None, 0f);
				}
			}
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
			this._planetTexture = TextureManager.Load("Images/Misc/StarDustSky/Planet");
			this._bgTexture = TextureManager.Load("Images/Misc/StarDustSky/Background");
			this._starTextures = new Texture2D[2];
			for (int i = 0; i < (int)this._starTextures.Length; i++)
			{
				this._starTextures[i] = TextureManager.Load(string.Concat("Images/Misc/StarDustSky/Star ", i));
			}
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