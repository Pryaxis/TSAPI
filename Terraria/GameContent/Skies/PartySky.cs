using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Graphics.Effects;

namespace Terraria.GameContent.Skies
{
	internal class PartySky : CustomSky
	{
		private struct Balloon
		{
			private const int MAX_FRAMES_X = 3;

			private const int MAX_FRAMES_Y = 3;

			private const int FRAME_RATE = 14;

			public int Variant;

			private Texture2D _texture;

			public Vector2 Position;

			public float Depth;

			public int FrameHeight;

			public int FrameWidth;

			public float Speed;

			public bool Active;

			private int _frameCounter;

			public Texture2D Texture
			{
				get
				{
					return this._texture;
				}
				set
				{
					this._texture = value;
					this.FrameWidth = value.Width / 3;
					this.FrameHeight = value.Height / 3;
				}
			}

			public int Frame
			{
				get
				{
					return this._frameCounter;
				}
				set
				{
					this._frameCounter = value % 42;
				}
			}

			public Rectangle GetSourceRectangle()
			{
				return new Rectangle(this.FrameWidth * this.Variant, this._frameCounter / 14 * this.FrameHeight, this.FrameWidth, this.FrameHeight);
			}
		}

		public static bool MultipleSkyWorkaroundFix;

		private bool _active;

		private bool _leaving;

		private float _opacity;

		private Texture2D[] _textures;

		private PartySky.Balloon[] _balloons;

		private Random _random = new Random();

		private int _balloonsDrawing;

		public override void OnLoad()
		{
			this._textures = new Texture2D[3];
			for (int i = 0; i < this._textures.Length; i++)
			{
				this._textures[i] = Main.extraTexture[69 + i];
			}
			this.GenerateBalloons(false);
		}

		private void GenerateBalloons(bool onlyMissing)
		{
			if (!onlyMissing)
			{
				this._balloons = new PartySky.Balloon[Main.maxTilesY / 4];
			}
			for (int i = 0; i < this._balloons.Length; i++)
			{
				if (!onlyMissing || !this._balloons[i].Active)
				{
					int num = (int)((double)Main.screenPosition.Y * 0.7 - (double)Main.screenHeight);
					int minValue = (int)((double)num - Main.worldSurface * 16.0);
					this._balloons[i].Position = new Vector2((float)(this._random.Next(0, Main.maxTilesX) * 16), (float)this._random.Next(minValue, num));
					this.ResetBalloon(i);
					this._balloons[i].Active = true;
				}
			}
			this._balloonsDrawing = this._balloons.Length;
		}

		public void ResetBalloon(int i)
		{
			this._balloons[i].Depth = (float)i / (float)this._balloons.Length * 1.75f + 1.6f;
			this._balloons[i].Speed = -1.5f - 2.5f * (float)this._random.NextDouble();
			this._balloons[i].Texture = this._textures[this._random.Next(2)];
			this._balloons[i].Variant = this._random.Next(3);
			if (this._random.Next(30) == 0)
			{
				this._balloons[i].Texture = this._textures[2];
			}
		}

		private bool IsNearParty()
		{
			return Main.player[Main.myPlayer].townNPCs > 0f || Main.partyMonoliths > 0;
		}

		public override void Update()
		{
			if (!PartySky.MultipleSkyWorkaroundFix)
			{
				return;
			}
			PartySky.MultipleSkyWorkaroundFix = false;
			if (Main.gamePaused || !Main.hasFocus)
			{
				return;
			}
			this._opacity = Utils.Clamp<float>(this._opacity + (float)this.IsNearParty().ToDirectionInt() * 0.01f, 0f, 1f);
			for (int i = 0; i < this._balloons.Length; i++)
			{
				if (this._balloons[i].Active)
				{
					PartySky.Balloon[] expr_74_cp_0 = this._balloons;
					int expr_74_cp_1 = i;
					expr_74_cp_0[expr_74_cp_1].Frame = expr_74_cp_0[expr_74_cp_1].Frame + 1;
					PartySky.Balloon[] expr_92_cp_0_cp_0 = this._balloons;
					int expr_92_cp_0_cp_1 = i;
					expr_92_cp_0_cp_0[expr_92_cp_0_cp_1].Position.Y = expr_92_cp_0_cp_0[expr_92_cp_0_cp_1].Position.Y + this._balloons[i].Speed;
					PartySky.Balloon[] expr_C0_cp_0_cp_0 = this._balloons;
					int expr_C0_cp_0_cp_1 = i;
					expr_C0_cp_0_cp_0[expr_C0_cp_0_cp_1].Position.X = expr_C0_cp_0_cp_0[expr_C0_cp_0_cp_1].Position.X + Main.windSpeed * (3f - this._balloons[i].Speed);
					if (this._balloons[i].Position.Y < 300f)
					{
						if (!this._leaving)
						{
							this.ResetBalloon(i);
							this._balloons[i].Position = new Vector2((float)(this._random.Next(0, Main.maxTilesX) * 16), (float)Main.worldSurface * 16f + 1600f);
							if (this._random.Next(30) == 0)
							{
								this._balloons[i].Texture = this._textures[2];
							}
						}
						else
						{
							this._balloons[i].Active = false;
							this._balloonsDrawing--;
						}
					}
				}
			}
			if (this._balloonsDrawing == 0)
			{
				this._active = false;
			}
			this._active = true;
		}

		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if ((double)Main.screenPosition.Y > Main.worldSurface * 16.0 || Main.gameMenu)
			{
				return;
			}
			if (this._opacity <= 0f)
			{
				return;
			}
			int num = -1;
			int num2 = 0;
			for (int i = 0; i < this._balloons.Length; i++)
			{
				float depth = this._balloons[i].Depth;
				if (num == -1 && depth < maxDepth)
				{
					num = i;
				}
				if (depth <= minDepth)
				{
					break;
				}
				num2 = i;
			}
			if (num == -1)
			{
				return;
			}
			Vector2 value = Main.screenPosition + new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
			Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
			for (int j = num; j < num2; j++)
			{
				if (this._balloons[j].Active)
				{
					Color value2 = new Color(Main.bgColor.ToVector4() * 0.9f + new Vector4(0.1f)) * 0.8f;
					float num3 = 1f;
					if (this._balloons[j].Depth > 3f)
					{
						num3 = 0.6f;
					}
					else if ((double)this._balloons[j].Depth > 2.5)
					{
						num3 = 0.7f;
					}
					else if (this._balloons[j].Depth > 2f)
					{
						num3 = 0.8f;
					}
					else if ((double)this._balloons[j].Depth > 1.5)
					{
						num3 = 0.9f;
					}
					num3 *= 0.9f;
					value2 = new Color((int)((float)value2.R * num3), (int)((float)value2.G * num3), (int)((float)value2.B * num3), (int)((float)value2.A * num3));
					Vector2 value3 = new Vector2(1f / this._balloons[j].Depth, 0.9f / this._balloons[j].Depth);
					Vector2 vector = this._balloons[j].Position;
					vector = (vector - value) * value3 + value - Main.screenPosition;
					vector.X = (vector.X + 500f) % 4000f;
					if (vector.X < 0f)
					{
						vector.X += 4000f;
					}
					vector.X -= 500f;
					if (rectangle.Contains((int)vector.X, (int)vector.Y))
					{
						spriteBatch.Draw(this._balloons[j].Texture, vector, new Rectangle?(this._balloons[j].GetSourceRectangle()), value2 * this._opacity, 0f, Vector2.Zero, value3.X * 2f, SpriteEffects.None, 0f);
					}
				}
			}
		}

		internal override void Activate(Vector2 position, params object[] args)
		{
			if (this._active)
			{
				this._leaving = false;
				this.GenerateBalloons(true);
				return;
			}
			this.GenerateBalloons(false);
			this._active = true;
			this._leaving = false;
		}

		internal override void Deactivate(params object[] args)
		{
			this._leaving = true;
		}

		public override bool IsActive()
		{
			return this._active;
		}

		public override void Reset()
		{
			this._active = false;
		}
	}
}
