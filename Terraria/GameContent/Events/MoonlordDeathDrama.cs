using XNA;
using System;
using System.Collections.Generic;
using Terraria;

namespace Terraria.GameContent.Events
{
	public class MoonlordDeathDrama
	{
		private static List<MoonlordDeathDrama.MoonlordPiece> _pieces;

		private static List<MoonlordDeathDrama.MoonlordExplosion> _explosions;

		private static List<Vector2> _lightSources;

		private static float whitening;

		private static float requestedLight;

		static MoonlordDeathDrama()
		{
			MoonlordDeathDrama._pieces = new List<MoonlordDeathDrama.MoonlordPiece>();
			MoonlordDeathDrama._explosions = new List<MoonlordDeathDrama.MoonlordExplosion>();
			MoonlordDeathDrama._lightSources = new List<Vector2>();
			MoonlordDeathDrama.whitening = 0f;
			MoonlordDeathDrama.requestedLight = 0f;
		}

		public MoonlordDeathDrama()
		{
		}

		public static void AddExplosion(Vector2 spot)
		{
		}

		public static void DrawExplosions()
		{
		}

		public static void DrawPieces()
		{
		}

		public static void DrawWhite()
		{
		}

		public static void RequestLight(float light, Vector2 spot)
		{
			MoonlordDeathDrama._lightSources.Add(spot);
			if (light > 1f)
			{
				light = 1f;
			}
			if (MoonlordDeathDrama.requestedLight < light)
			{
				MoonlordDeathDrama.requestedLight = light;
			}
		}

		public static void ThrowPieces(Vector2 MoonlordCoreCenter, int DramaSeed)
		{
		}

		public static void Update()
		{
			for (int i = 0; i < MoonlordDeathDrama._pieces.Count; i++)
			{
				MoonlordDeathDrama.MoonlordPiece item = MoonlordDeathDrama._pieces[i];
				item.Update();
				if (item.Dead)
				{
					MoonlordDeathDrama._pieces.Remove(item);
					i--;
				}
			}
			for (int j = 0; j < MoonlordDeathDrama._explosions.Count; j++)
			{
				MoonlordDeathDrama.MoonlordExplosion moonlordExplosion = MoonlordDeathDrama._explosions[j];
				moonlordExplosion.Update();
				if (moonlordExplosion.Dead)
				{
					MoonlordDeathDrama._explosions.Remove(moonlordExplosion);
					j--;
				}
			}
			bool flag = false;
			int num = 0;
			while (num < MoonlordDeathDrama._lightSources.Count)
			{
				if (Main.player[Main.myPlayer].Distance(MoonlordDeathDrama._lightSources[num]) >= 2000f)
				{
					num++;
				}
				else
				{
					flag = true;
					break;
				}
			}
			MoonlordDeathDrama._lightSources.Clear();
			if (!flag)
			{
				MoonlordDeathDrama.requestedLight = 0f;
			}
			if (MoonlordDeathDrama.requestedLight != MoonlordDeathDrama.whitening)
			{
				if (Math.Abs(MoonlordDeathDrama.requestedLight - MoonlordDeathDrama.whitening) >= 0.02f)
				{
					MoonlordDeathDrama.whitening = MoonlordDeathDrama.whitening + (float)Math.Sign(MoonlordDeathDrama.requestedLight - MoonlordDeathDrama.whitening) * 0.02f;
				}
				else
				{
					MoonlordDeathDrama.whitening = MoonlordDeathDrama.requestedLight;
				}
			}
			MoonlordDeathDrama.requestedLight = 0f;
		}

		public class MoonlordExplosion
		{
			private Vector2 _position;

			private Vector2 _origin;

			private Rectangle _frame;

			private int _frameCounter;

			private int _frameSpeed;

			public bool Dead
			{
				get
				{
					if (this._position.Y > (float)(Main.maxTilesY * 16) - 480f || this._position.X < 480f || this._position.X >= (float)(Main.maxTilesX * 16) - 480f)
					{
						return true;
					}
					return this._frameCounter >= this._frameSpeed * 7;
				}
			}

			public MoonlordExplosion(Vector2 centerPos, int frameSpeed)
			{
				this._position = centerPos;
				this._frameSpeed = frameSpeed;
				this._frameCounter = 0;
			}

			public void Draw()
			{
				Color light = this.GetLight();
			}

			public Color GetLight()
			{
				return new Color(255, 255, 255, 127);
			}

			public bool InDrawRange(Rectangle playerScreen)
			{
				return playerScreen.Contains(this._position.ToPoint());
			}

			public void Update()
			{
				MoonlordDeathDrama.MoonlordExplosion moonlordExplosion = this;
				moonlordExplosion._frameCounter = moonlordExplosion._frameCounter + 1;
			}
		}

		public class MoonlordPiece
		{
			private Vector2 _position;

			private Vector2 _velocity;

			private Vector2 _origin;

			private float _rotation;

			private float _rotationVelocity;

			public bool Dead
			{
				get
				{
					if (this._position.Y > (float)(Main.maxTilesY * 16) - 480f || this._position.X < 480f)
					{
						return true;
					}
					return this._position.X >= (float)(Main.maxTilesX * 16) - 480f;
				}
			}

			public MoonlordPiece(Vector2 textureOrigin, Vector2 centerPos, Vector2 velocity, float rot, float angularVelocity)
			{
				this._origin = textureOrigin;
				this._position = centerPos;
				this._velocity = velocity;
				this._rotation = rot;
				this._rotationVelocity = angularVelocity;
			}

			public void Draw()
			{
				Color light = this.GetLight();
			}

			public Color GetLight()
			{
				return Color.Transparent;
			}

			public bool InDrawRange(Rectangle playerScreen)
			{
				return playerScreen.Contains(this._position.ToPoint());
			}

			public void Update()
			{
				this._velocity.Y = this._velocity.Y + 0.3f;
				MoonlordDeathDrama.MoonlordPiece moonlordPiece = this;
				moonlordPiece._rotation = moonlordPiece._rotation + this._rotationVelocity;
				MoonlordDeathDrama.MoonlordPiece moonlordPiece1 = this;
				moonlordPiece1._rotationVelocity = moonlordPiece1._rotationVelocity * 0.99f;
				MoonlordDeathDrama.MoonlordPiece moonlordPiece2 = this;
				moonlordPiece2._position = moonlordPiece2._position + this._velocity;
			}
		}
	}
}