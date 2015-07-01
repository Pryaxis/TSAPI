using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.Graphics.Effects;

namespace Terraria.GameContent.Skies
{
	internal class MartianSky : CustomSky
	{
		private MartianSky.Ufo[] _ufos;

		private Random _random = new Random();

		private int _maxUfos;

		private bool _active;

		private bool _leaving;

		private int _activeUfos;

		public MartianSky()
		{
		}

		internal override void Activate(Vector2 position, params object[] args)
		{
			this._activeUfos = 0;
			this.GenerateUfos();
			Array.Sort<MartianSky.Ufo>(this._ufos, (MartianSky.Ufo ufo1, MartianSky.Ufo ufo2) => ufo2.Depth.CompareTo(ufo1.Depth));
			this._active = true;
			this._leaving = false;
		}

		internal override void Deactivate(params object[] args)
		{
			this._leaving = true;
		}

		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (Main.screenPosition.Y > 10000f)
			{
				return;
			}
			int num = -1;
			int num1 = 0;
			for (int i = 0; i < (int)this._ufos.Length; i++)
			{
				float depth = this._ufos[i].Depth;
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
			Color color = new Color((Main.bgColor.ToVector4() * 0.9f) + new Vector4(0.1f));
			Vector2 vector2 = Main.screenPosition + new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
			Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
			for (int j = num; j < num1; j++)
			{
				Vector2 vector21 = new Vector2(1f / this._ufos[j].Depth, 0.9f / this._ufos[j].Depth);
				Vector2 position = this._ufos[j].Position;
				position = (((position - vector2) * vector21) + vector2) - Main.screenPosition;
				if (this._ufos[j].IsActive && rectangle.Contains((int)position.X, (int)position.Y))
				{
					spriteBatch.Draw(this._ufos[j].Texture, position, new Rectangle?(this._ufos[j].GetSourceRectangle()), color * this._ufos[j].Opacity, this._ufos[j].Rotation, Vector2.Zero, vector21.X * 5f * this._ufos[j].Scale, SpriteEffects.None, 0f);
					if (this._ufos[j].GlowTexture != null)
					{
						spriteBatch.Draw(this._ufos[j].GlowTexture, position, new Rectangle?(this._ufos[j].GetSourceRectangle()), Color.White * this._ufos[j].Opacity, this._ufos[j].Rotation, Vector2.Zero, vector21.X * 5f * this._ufos[j].Scale, SpriteEffects.None, 0f);
					}
				}
			}
		}

		private void GenerateUfos()
		{
			float single = (float)Main.maxTilesX / 4200f;
			this._maxUfos = (int)(256f * single);
			this._ufos = new MartianSky.Ufo[this._maxUfos];
			int num = this._maxUfos >> 4;
			for (int i = 0; i < num; i++)
			{
				float single1 = (float)i / (float)num;
				this._ufos[i] = new MartianSky.Ufo(Main.extraTexture[5], (float)Main.rand.NextDouble() * 4f + 6.6f);
				this._ufos[i].GlowTexture = Main.glowMaskTexture[90];
			}
			for (int j = num; j < (int)this._ufos.Length; j++)
			{
				float length = (float)(j - num) / (float)((int)this._ufos.Length - num);
				this._ufos[j] = new MartianSky.Ufo(Main.extraTexture[6], (float)Main.rand.NextDouble() * 5f + 1.6f);
				this._ufos[j].Scale = 0.5f;
				this._ufos[j].GlowTexture = Main.glowMaskTexture[91];
			}
		}

		public override bool IsActive()
		{
			return this._active;
		}

		public override void Reset()
		{
			this._active = false;
		}

		public override void Update()
		{
			if (Main.gamePaused || !Main.hasFocus)
			{
				return;
			}
			int num = this._activeUfos;
			for (int i = 0; i < (int)this._ufos.Length; i++)
			{
				MartianSky.Ufo frame = this._ufos[i];
				if (frame.IsActive)
				{
					frame.Frame = frame.Frame + 1;
					if (!frame.Update())
					{
						if (this._leaving)
						{
							frame.IsActive = false;
							num--;
						}
						else
						{
							frame.AssignNewBehavior();
						}
					}
				}
				this._ufos[i] = frame;
			}
			if (!this._leaving && num != this._maxUfos)
			{
				this._ufos[num].IsActive = true;
				int num1 = num;
				num = num1 + 1;
				this._ufos[num1].AssignNewBehavior();
			}
			this._active = (!this._leaving ? true : num != 0);
			this._activeUfos = num;
		}

		private class HoverBehavior : MartianSky.IUfoController
		{
			private int _ticks;

			private int _maxTicks;

			public HoverBehavior()
			{
			}

			public override void InitializeUfo(ref MartianSky.Ufo ufo)
			{
				ufo.Position.X = (float)(MartianSky.Ufo.Random.NextDouble() * (double)(Main.maxTilesX << 4));
				ufo.Position.Y = (float)(MartianSky.Ufo.Random.NextDouble() * 5000);
				ufo.Opacity = 0f;
				ufo.Rotation = 0f;
				this._ticks = 0;
				this._maxTicks = MartianSky.Ufo.Random.Next(120, 240);
			}

			public override bool Update(ref MartianSky.Ufo ufo)
			{
				if (this._ticks < 10)
				{
					ufo.Opacity = ufo.Opacity + 0.1f;
				}
				else if (this._ticks > this._maxTicks - 10)
				{
					ufo.Opacity = ufo.Opacity - 0.1f;
				}
				if (this._ticks == this._maxTicks)
				{
					return false;
				}
				MartianSky.HoverBehavior hoverBehavior = this;
				hoverBehavior._ticks = hoverBehavior._ticks + 1;
				return true;
			}
		}

		private abstract class IUfoController
		{
			protected IUfoController()
			{
			}

			public abstract void InitializeUfo(ref MartianSky.Ufo ufo);

			public abstract bool Update(ref MartianSky.Ufo ufo);
		}

		private struct Ufo
		{
			private const int MAX_FRAMES = 3;

			private const int FRAME_RATE = 4;

			public static Random Random;

			private int _frame;

			private Texture2D _texture;

			private MartianSky.IUfoController _controller;

			public Texture2D GlowTexture;

			public Vector2 Position;

			public int FrameHeight;

			public int FrameWidth;

			public float Depth;

			public float Scale;

			public float Opacity;

			public bool IsActive;

			public float Rotation;

			public MartianSky.IUfoController Controller
			{
				get
				{
					return this._controller;
				}
				set
				{
					this._controller = value;
					value.InitializeUfo(ref this);
				}
			}

			public int Frame
			{
				get
				{
					return this._frame;
				}
				set
				{
					this._frame = value % 12;
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
					this.FrameHeight = value.Height / 3;
				}
			}

			static Ufo()
			{
				MartianSky.Ufo.Random = new Random();
			}

			public Ufo(Texture2D texture, float depth = 1f)
			{
				this._frame = 0;
				this.Position = Vector2.Zero;
				this._texture = texture;
				this.Depth = depth;
				this.Scale = 1f;
				this.FrameWidth = texture.Width;
				this.FrameHeight = texture.Height / 3;
				this.GlowTexture = null;
				this.Opacity = 0f;
				this.Rotation = 0f;
				this.IsActive = false;
				this._controller = null;
			}

			public void AssignNewBehavior()
			{
				switch (MartianSky.Ufo.Random.Next(2))
				{
					case 0:
					{
						this.Controller = new MartianSky.ZipBehavior();
						return;
					}
					case 1:
					{
						this.Controller = new MartianSky.HoverBehavior();
						return;
					}
					default:
					{
						return;
					}
				}
			}

			public Rectangle GetSourceRectangle()
			{
				return new Rectangle(0, this._frame / 4 * this.FrameHeight, this.FrameWidth, this.FrameHeight);
			}

			public bool Update()
			{
				return this.Controller.Update(ref this);
			}
		}

		private class ZipBehavior : MartianSky.IUfoController
		{
			private Vector2 _speed;

			private int _ticks;

			private int _maxTicks;

			public ZipBehavior()
			{
			}

			public override void InitializeUfo(ref MartianSky.Ufo ufo)
			{
				ufo.Position.X = (float)(MartianSky.Ufo.Random.NextDouble() * (double)(Main.maxTilesX << 4));
				ufo.Position.Y = (float)(MartianSky.Ufo.Random.NextDouble() * 5000);
				ufo.Opacity = 0f;
				float single = (float)MartianSky.Ufo.Random.NextDouble() * 5f + 10f;
				double num = MartianSky.Ufo.Random.NextDouble() * 0.600000023841858 - 0.300000011920929;
				ufo.Rotation = (float)num;
				if (MartianSky.Ufo.Random.Next(2) == 0)
				{
					num = num + 3.14159274101257;
				}
				this._speed = new Vector2((float)Math.Cos(num) * single, (float)Math.Sin(num) * single);
				this._ticks = 0;
				this._maxTicks = MartianSky.Ufo.Random.Next(400, 500);
			}

			public override bool Update(ref MartianSky.Ufo ufo)
			{
				if (this._ticks < 10)
				{
					ufo.Opacity = ufo.Opacity + 0.1f;
				}
				else if (this._ticks > this._maxTicks - 10)
				{
					ufo.Opacity = ufo.Opacity - 0.1f;
				}
				ufo.Position = ufo.Position + this._speed;
				if (this._ticks == this._maxTicks)
				{
					return false;
				}
				MartianSky.ZipBehavior zipBehavior = this;
				zipBehavior._ticks = zipBehavior._ticks + 1;
				return true;
			}
		}
	}
}