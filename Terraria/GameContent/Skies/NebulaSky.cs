using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Effects;

namespace Terraria.GameContent.Skies
{
	internal class NebulaSky : CustomSky
	{
		private NebulaSky.LightPillar[] _pillars;

		private Random _random = new Random();

		private Texture2D _planetTexture;

		private Texture2D _bgTexture;

		private Texture2D _beamTexture;

		private Texture2D[] _rockTextures;

		private bool _isActive;

		private float _fadeOpacity;

		public NebulaSky()
		{
		}

		internal override void Activate(Vector2 position, params object[] args)
		{
			this._fadeOpacity = 0.002f;
			this._isActive = true;
			this._pillars = new NebulaSky.LightPillar[40];
			for (int i = 0; i < (int)this._pillars.Length; i++)
			{
				this._pillars[i].Position.X = (float)i / (float)((int)this._pillars.Length) * ((float)Main.maxTilesX * 16f + 20000f) + this._random.NextFloat() * 40f - 20f - 20000f;
				this._pillars[i].Position.Y = this._random.NextFloat() * 200f - 2000f;
				this._pillars[i].Depth = this._random.NextFloat() * 8f + 7f;
			}
			Array.Sort<NebulaSky.LightPillar>(this._pillars, new Comparison<NebulaSky.LightPillar>(this.SortMethod));
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
			for (int i = 0; i < (int)this._pillars.Length; i++)
			{
				float depth = this._pillars[i].Depth;
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
			Vector2 vector22 = Main.screenPosition + new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
			Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
			float single = Math.Min(1f, (Main.screenPosition.Y - 1000f) / 1000f);
			for (int j = num; j < num1; j++)
			{
				Vector2 vector23 = new Vector2(1f / this._pillars[j].Depth, 0.9f / this._pillars[j].Depth);
				Vector2 position = this._pillars[j].Position;
				position = (((position - vector22) * vector23) + vector22) - Main.screenPosition;
				if (rectangle.Contains((int)position.X, (int)position.Y))
				{
					float x = vector23.X * 450f;
					Rectangle? nullable1 = null;
					spriteBatch.Draw(this._beamTexture, position, nullable1, ((Color.White * 0.2f) * single) * this._fadeOpacity, 0f, Vector2.Zero, new Vector2(x / 70f, x / 45f), SpriteEffects.None, 0f);
					int length = 0;
					for (float k = 0f; k <= 1f; k = k + 0.03f)
					{
						float globalTime = 1f - (k + Main.GlobalTime * 0.02f + (float)Math.Sin((double)((float)j))) % 1f;
						Rectangle? nullable2 = null;
						spriteBatch.Draw(this._rockTextures[length], position + new Vector2((float)Math.Sin((double)(k * 1582f)) * (x * 0.5f) + x * 0.5f, globalTime * 2000f), nullable2, ((Color.White * globalTime) * single) * this._fadeOpacity, globalTime * 20f, new Vector2((float)(this._rockTextures[length].Width >> 1), (float)(this._rockTextures[length].Height >> 1)), 0.9f, SpriteEffects.None, 0f);
						length = (length + 1) % (int)this._rockTextures.Length;
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
			this._planetTexture = TextureManager.Load("Images/Misc/NebulaSky/Planet");
			this._bgTexture = TextureManager.Load("Images/Misc/NebulaSky/Background");
			this._beamTexture = TextureManager.Load("Images/Misc/NebulaSky/Beam");
			this._rockTextures = new Texture2D[3];
			for (int i = 0; i < (int)this._rockTextures.Length; i++)
			{
				this._rockTextures[i] = TextureManager.Load(string.Concat("Images/Misc/NebulaSky/Rock_", i));
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

		private int SortMethod(NebulaSky.LightPillar pillar1, NebulaSky.LightPillar pillar2)
		{
			return pillar2.Depth.CompareTo(pillar1.Depth);
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

		private struct LightPillar
		{
			public Vector2 Position;

			public float Depth;
		}
	}
}