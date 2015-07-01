using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Effects;

namespace Terraria.GameContent.Skies
{
	internal class SlimeSky : CustomSky
	{
		private Texture2D[] _textures;

		private SlimeSky.Slime[] _slimes;

		private Random _random = new Random();

		private int _slimesRemaining;

		private bool _isActive;

		private bool _isLeaving;

		public SlimeSky()
		{
		}

		internal override void Activate(Vector2 position, params object[] args)
		{
			this.GenerateSlimes();
			this._isActive = true;
			this._isLeaving = false;
		}

		internal override void Deactivate(params object[] args)
		{
			this._isLeaving = true;
		}

		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (Main.screenPosition.Y > 10000f || Main.gameMenu)
			{
				return;
			}
			int num = -1;
			int num1 = 0;
			for (int i = 0; i < (int)this._slimes.Length; i++)
			{
				float depth = this._slimes[i].Depth;
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
			Vector2 vector2 = Main.screenPosition + new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
			Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
			for (int j = num; j < num1; j++)
			{
				if (this._slimes[j].Active)
				{
					Color color = new Color((Main.bgColor.ToVector4() * 0.9f) + new Vector4(0.1f)) * 0.8f;
					float single = 1f;
					if (this._slimes[j].Depth > 3f)
					{
						single = 0.6f;
					}
					else if ((double)this._slimes[j].Depth > 2.5)
					{
						single = 0.7f;
					}
					else if (this._slimes[j].Depth > 2f)
					{
						single = 0.8f;
					}
					else if ((double)this._slimes[j].Depth > 1.5)
					{
						single = 0.9f;
					}
					single = single * 0.8f;
					color = new Color((int)((float)color.R * single), (int)((float)color.G * single), (int)((float)color.B * single), (int)((float)color.A * single));
					Vector2 vector21 = new Vector2(1f / this._slimes[j].Depth, 0.9f / this._slimes[j].Depth);
					Vector2 position = this._slimes[j].Position;
					position = (((position - vector2) * vector21) + vector2) - Main.screenPosition;
					position.X = (position.X + 500f) % 4000f;
					if (position.X < 0f)
					{
						position.X = position.X + 4000f;
					}
					position.X = position.X - 500f;
					if (rectangle.Contains((int)position.X, (int)position.Y))
					{
						spriteBatch.Draw(this._slimes[j].Texture, position, new Rectangle?(this._slimes[j].GetSourceRectangle()), color, 0f, Vector2.Zero, vector21.X * 2f, SpriteEffects.None, 0f);
					}
				}
			}
		}

		private void GenerateSlimes()
		{
			this._slimes = new SlimeSky.Slime[Main.maxTilesY / 6];
			for (int i = 0; i < (int)this._slimes.Length; i++)
			{
				int y = (int)((double)Main.screenPosition.Y * 0.7 - (double)Main.screenHeight);
				int num = (int)((double)y - Main.worldSurface * 16);
				this._slimes[i].Position = new Vector2((float)(this._random.Next(0, Main.maxTilesX) * 16), (float)this._random.Next(num, y));
				this._slimes[i].Speed = 5f + 3f * (float)this._random.NextDouble();
				this._slimes[i].Depth = (float)i / (float)((int)this._slimes.Length) * 1.75f + 1.6f;
				this._slimes[i].Texture = this._textures[this._random.Next(2)];
				if (this._random.Next(60) == 0)
				{
					this._slimes[i].Texture = this._textures[3];
					this._slimes[i].Speed = 6f + 3f * (float)this._random.NextDouble();
					this._slimes[i].Depth = this._slimes[i].Depth + 0.5f;
				}
				else if (this._random.Next(30) == 0)
				{
					this._slimes[i].Texture = this._textures[2];
					this._slimes[i].Speed = 6f + 2f * (float)this._random.NextDouble();
				}
				this._slimes[i].Active = true;
			}
			this._slimesRemaining = (int)this._slimes.Length;
		}

		public override bool IsActive()
		{
			return this._isActive;
		}

		public override void OnLoad()
		{
			this._textures = new Texture2D[4];
			for (int i = 0; i < 4; i++)
			{
				this._textures[i] = TextureManager.Load(string.Concat("Images/Misc/Sky_Slime_", i + 1));
			}
			this.GenerateSlimes();
		}

		public override void Reset()
		{
			this._isActive = false;
		}

		public override void Update()
		{
			if (Main.gamePaused || !Main.hasFocus)
			{
				return;
			}
			for (int i = 0; i < (int)this._slimes.Length; i++)
			{
				if (this._slimes[i].Active)
				{
					this._slimes[i].Frame = this._slimes[i].Frame + 1;
					this._slimes[i].Position.Y = this._slimes[i].Position.Y + this._slimes[i].Speed;
					if ((double)this._slimes[i].Position.Y > Main.worldSurface * 16)
					{
						if (this._isLeaving)
						{
							this._slimes[i].Active = false;
							SlimeSky slimeSky = this;
							slimeSky._slimesRemaining = slimeSky._slimesRemaining - 1;
						}
						else
						{
							this._slimes[i].Depth = (float)i / (float)((int)this._slimes.Length) * 1.75f + 1.6f;
							this._slimes[i].Position = new Vector2((float)(this._random.Next(0, Main.maxTilesX) * 16), -100f);
							this._slimes[i].Texture = this._textures[this._random.Next(2)];
							this._slimes[i].Speed = 5f + 3f * (float)this._random.NextDouble();
							if (this._random.Next(60) == 0)
							{
								this._slimes[i].Texture = this._textures[3];
								this._slimes[i].Speed = 6f + 3f * (float)this._random.NextDouble();
								this._slimes[i].Depth = this._slimes[i].Depth + 0.5f;
							}
							else if (this._random.Next(30) == 0)
							{
								this._slimes[i].Texture = this._textures[2];
								this._slimes[i].Speed = 6f + 2f * (float)this._random.NextDouble();
							}
						}
					}
				}
			}
			if (this._slimesRemaining == 0)
			{
				this._isActive = false;
			}
		}

		private struct Slime
		{
			private const int MAX_FRAMES = 4;

			private const int FRAME_RATE = 6;

			private Texture2D _texture;

			public Vector2 Position;

			public float Depth;

			public int FrameHeight;

			public int FrameWidth;

			public float Speed;

			public bool Active;

			private int _frame;

			public int Frame
			{
				get
				{
					return this._frame;
				}
				set
				{
					this._frame = value % 24;
				}
			}

			public Texture2D Texture
			{
				get
				{
					return this._texture;
				}
				set
				{
					this._texture = value;
					this.FrameWidth = value.Width;
					this.FrameHeight = value.Height / 4;
				}
			}

			public Rectangle GetSourceRectangle()
			{
				return new Rectangle(0, this._frame / 6 * this.FrameHeight, this.FrameWidth, this.FrameHeight);
			}
		}
	}
}