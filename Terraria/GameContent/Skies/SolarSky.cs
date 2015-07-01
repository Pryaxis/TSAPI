using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Effects;

namespace Terraria.GameContent.Skies
{
	internal class SolarSky : CustomSky
	{
		private Random _random = new Random();

		private Texture2D _planetTexture;

		private Texture2D _bgTexture;

		private Texture2D _meteorTexture;

		private bool _isActive;

		private SolarSky.Meteor[] _meteors;

		private float _fadeOpacity;

		public SolarSky()
		{
		}

		internal override void Activate(Vector2 position, params object[] args)
		{
			this._fadeOpacity = 0.002f;
			this._isActive = true;
			this._meteors = new SolarSky.Meteor[150];
			for (int i = 0; i < (int)this._meteors.Length; i++)
			{
				float length = (float)i / (float)((int)this._meteors.Length);
				this._meteors[i].Position.X = length * ((float)Main.maxTilesX * 16f) + this._random.NextFloat() * 40f - 20f;
				this._meteors[i].Position.Y = this._random.NextFloat() * -((float)Main.worldSurface * 16f + 10000f) - 10000f;
				if (this._random.Next(3) == 0)
				{
					this._meteors[i].Depth = this._random.NextFloat() * 5f + 4.8f;
				}
				else
				{
					this._meteors[i].Depth = this._random.NextFloat() * 3f + 1.8f;
				}
				this._meteors[i].FrameCounter = this._random.Next(12);
				this._meteors[i].Scale = this._random.NextFloat() * 0.5f + 1f;
				this._meteors[i].StartX = this._meteors[i].Position.X;
			}
			Array.Sort<SolarSky.Meteor>(this._meteors, new Comparison<SolarSky.Meteor>(this.SortMethod));
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
			for (int i = 0; i < (int)this._meteors.Length; i++)
			{
				float depth = this._meteors[i].Depth;
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
				Vector2 vector23 = new Vector2(1f / this._meteors[j].Depth, 0.9f / this._meteors[j].Depth);
				Vector2 position = (((this._meteors[j].Position - vector22) * vector23) + vector22) - Main.screenPosition;
				int frameCounter = this._meteors[j].FrameCounter / 3;
				this._meteors[j].FrameCounter = (this._meteors[j].FrameCounter + 1) % 12;
				if (rectangle.Contains((int)position.X, (int)position.Y))
				{
					spriteBatch.Draw(this._meteorTexture, position, new Rectangle?(new Rectangle(0, frameCounter * (this._meteorTexture.Height / 4), this._meteorTexture.Width, this._meteorTexture.Height / 4)), (Color.White * single) * this._fadeOpacity, 0f, Vector2.Zero, vector23.X * 5f * this._meteors[j].Scale, SpriteEffects.None, 0f);
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
			this._planetTexture = TextureManager.Load("Images/Misc/SolarSky/Planet");
			this._bgTexture = TextureManager.Load("Images/Misc/SolarSky/Background");
			this._meteorTexture = TextureManager.Load("Images/Misc/SolarSky/Meteor");
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
			if (!this._isActive)
			{
				this._fadeOpacity = Math.Max(0f, this._fadeOpacity - 0.01f);
			}
			else
			{
				this._fadeOpacity = Math.Min(1f, 0.01f + this._fadeOpacity);
			}
			float single = 20f;
			for (int i = 0; i < (int)this._meteors.Length; i++)
			{
				this._meteors[i].Position.X = this._meteors[i].Position.X - single;
				this._meteors[i].Position.Y = this._meteors[i].Position.Y + single;
				if ((double)this._meteors[i].Position.Y > Main.worldSurface * 16)
				{
					this._meteors[i].Position.X = this._meteors[i].StartX;
					this._meteors[i].Position.Y = -10000f;
				}
			}
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