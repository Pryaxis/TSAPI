using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Effects;

namespace Terraria.GameContent.Skies
{
	internal class VortexSky : CustomSky
	{
		private Random _random = new Random();

		private Texture2D _planetTexture;

		private Texture2D _bgTexture;

		private Texture2D _boltTexture;

		private Texture2D _flashTexture;

		private bool _isActive;

		private int _ticksUntilNextBolt;

		private float _fadeOpacity;

		private VortexSky.Bolt[] _bolts;

		public VortexSky()
		{
		}

		internal override void Activate(Vector2 position, params object[] args)
		{
			this._fadeOpacity = 0.002f;
			this._isActive = true;
			this._bolts = new VortexSky.Bolt[500];
			for (int i = 0; i < (int)this._bolts.Length; i++)
			{
				this._bolts[i].IsAlive = false;
			}
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
				spriteBatch.Draw(this._bgTexture, new Rectangle(0, Math.Max(0, (int)((Main.worldSurface * 16 - (double)Main.screenPosition.Y - 2400) * 0.100000001490116)), Main.screenWidth, Main.screenHeight), (Color.White * Math.Min(1f, (Main.screenPosition.Y - 800f) / 1000f)) * this._fadeOpacity);
				Vector2 vector2 = new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
				Vector2 vector21 = 0.01f * (new Vector2((float)Main.maxTilesX * 8f, (float)Main.worldSurface / 2f) - Main.screenPosition);
				Rectangle? nullable = null;
				spriteBatch.Draw(this._planetTexture, (vector2 + new Vector2(-200f, -200f)) + vector21, nullable, (Color.White * 0.9f) * this._fadeOpacity, 0f, new Vector2((float)(this._planetTexture.Width >> 1), (float)(this._planetTexture.Height >> 1)), 1f, SpriteEffects.None, 1f);
			}
			float single = Math.Min(1f, (Main.screenPosition.Y - 1000f) / 1000f);
			Vector2 vector22 = Main.screenPosition + new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
			Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
			for (int i = 0; i < (int)this._bolts.Length; i++)
			{
				if (this._bolts[i].IsAlive && this._bolts[i].Depth > minDepth && this._bolts[i].Depth < maxDepth)
				{
					Vector2 vector23 = new Vector2(1f / this._bolts[i].Depth, 0.9f / this._bolts[i].Depth);
					Vector2 position = (((this._bolts[i].Position - vector22) * vector23) + vector22) - Main.screenPosition;
					if (rectangle.Contains((int)position.X, (int)position.Y))
					{
						Texture2D texture2D = this._boltTexture;
						int life = this._bolts[i].Life;
						if (life > 26 && life % 2 == 0)
						{
							texture2D = this._flashTexture;
						}
						float single1 = (float)life / 30f;
						Rectangle? nullable1 = null;
						spriteBatch.Draw(texture2D, position, nullable1, ((Color.White * single) * single1) * this._fadeOpacity, 0f, Vector2.Zero, vector23.X * 5f, SpriteEffects.None, 0f);
					}
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
			this._planetTexture = TextureManager.Load("Images/Misc/VortexSky/Planet");
			this._bgTexture = TextureManager.Load("Images/Misc/VortexSky/Background");
			this._boltTexture = TextureManager.Load("Images/Misc/VortexSky/Bolt");
			this._flashTexture = TextureManager.Load("Images/Misc/VortexSky/Flash");
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

		public override void Update()
		{
			if (!this._isActive)
			{
				this._fadeOpacity = Math.Max(0f, this._fadeOpacity - 0.01f);
			}
			else
			{
				this._fadeOpacity = Math.Min(1f, 0.01f + this._fadeOpacity);
			}
			if (this._ticksUntilNextBolt <= 0)
			{
				this._ticksUntilNextBolt = this._random.Next(1, 5);
				int num = 0;
				while (this._bolts[num].IsAlive && num != (int)this._bolts.Length - 1)
				{
					num++;
				}
				this._bolts[num].IsAlive = true;
				this._bolts[num].Position.X = this._random.NextFloat() * ((float)Main.maxTilesX * 16f + 4000f) - 2000f;
				this._bolts[num].Position.Y = this._random.NextFloat() * 500f;
				this._bolts[num].Depth = this._random.NextFloat() * 8f + 2f;
				this._bolts[num].Life = 30;
			}
			VortexSky vortexSky = this;
			vortexSky._ticksUntilNextBolt = vortexSky._ticksUntilNextBolt - 1;
			for (int i = 0; i < (int)this._bolts.Length; i++)
			{
				if (this._bolts[i].IsAlive)
				{
					this._bolts[i].Life = this._bolts[i].Life - 1;
					if (this._bolts[i].Life <= 0)
					{
						this._bolts[i].IsAlive = false;
					}
				}
			}
		}

		private struct Bolt
		{
			public Vector2 Position;

			public float Depth;

			public int Life;

			public bool IsAlive;
		}
	}
}