using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Graphics;

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
			MoonlordDeathDrama._explosions.Add(new MoonlordDeathDrama.MoonlordExplosion(TextureManager.Load("Images/Misc/MoonExplosion/Explosion"), spot, Main.rand.Next(2, 4)));
		}

		public static void DrawExplosions(SpriteBatch spriteBatch)
		{
			Rectangle rectangle = Utils.CenteredRectangle(Main.screenPosition + (new Vector2((float)Main.screenWidth, (float)Main.screenHeight) * 0.5f), new Vector2((float)(Main.screenWidth + 1000), (float)(Main.screenHeight + 1000)));
			for (int i = 0; i < MoonlordDeathDrama._explosions.Count; i++)
			{
				if (MoonlordDeathDrama._explosions[i].InDrawRange(rectangle))
				{
					MoonlordDeathDrama._explosions[i].Draw(spriteBatch);
				}
			}
		}

		public static void DrawPieces(SpriteBatch spriteBatch)
		{
			Rectangle rectangle = Utils.CenteredRectangle(Main.screenPosition + (new Vector2((float)Main.screenWidth, (float)Main.screenHeight) * 0.5f), new Vector2((float)(Main.screenWidth + 1000), (float)(Main.screenHeight + 1000)));
			for (int i = 0; i < MoonlordDeathDrama._pieces.Count; i++)
			{
				if (MoonlordDeathDrama._pieces[i].InDrawRange(rectangle))
				{
					MoonlordDeathDrama._pieces[i].Draw(spriteBatch);
				}
			}
		}

		public static void DrawWhite(SpriteBatch spriteBatch)
		{
			if (MoonlordDeathDrama.whitening == 0f)
			{
				return;
			}
			Color white = Color.White * MoonlordDeathDrama.whitening;
			spriteBatch.Draw(Main.magicPixel, new Rectangle(-2, -2, Main.screenWidth + 4, Main.screenHeight + 4), new Rectangle?(new Rectangle(0, 0, 1, 1)), white);
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
			Random random = new Random(DramaSeed);
			Vector2 vector2 = Vector2.UnitY.RotatedBy((double)(random.NextFloat() * 1.57079637f - 0.7853982f + 3.14159274f), new Vector2());
			MoonlordDeathDrama._pieces.Add(new MoonlordDeathDrama.MoonlordPiece(TextureManager.Load("Images/Misc/MoonExplosion/Spine"), new Vector2(64f, 150f), MoonlordCoreCenter + new Vector2(0f, 50f), vector2 * 6f, 0f, random.NextFloat() * 0.1f - 0.05f));
			vector2 = Vector2.UnitY.RotatedBy((double)(random.NextFloat() * 1.57079637f - 0.7853982f + 3.14159274f), new Vector2());
			MoonlordDeathDrama._pieces.Add(new MoonlordDeathDrama.MoonlordPiece(TextureManager.Load("Images/Misc/MoonExplosion/Shoulder"), new Vector2(40f, 120f), MoonlordCoreCenter + new Vector2(50f, -120f), vector2 * 10f, 0f, random.NextFloat() * 0.1f - 0.05f));
			vector2 = Vector2.UnitY.RotatedBy((double)(random.NextFloat() * 1.57079637f - 0.7853982f + 3.14159274f), new Vector2());
			MoonlordDeathDrama._pieces.Add(new MoonlordDeathDrama.MoonlordPiece(TextureManager.Load("Images/Misc/MoonExplosion/Torso"), new Vector2(192f, 252f), MoonlordCoreCenter, vector2 * 8f, 0f, random.NextFloat() * 0.1f - 0.05f));
			vector2 = Vector2.UnitY.RotatedBy((double)(random.NextFloat() * 1.57079637f - 0.7853982f + 3.14159274f), new Vector2());
			MoonlordDeathDrama._pieces.Add(new MoonlordDeathDrama.MoonlordPiece(TextureManager.Load("Images/Misc/MoonExplosion/Head"), new Vector2(138f, 185f), MoonlordCoreCenter - new Vector2(0f, 200f), vector2 * 12f, 0f, random.NextFloat() * 0.1f - 0.05f));
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
			private Texture2D _texture;

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

			public MoonlordExplosion(Texture2D pieceTexture, Vector2 centerPos, int frameSpeed)
			{
				this._texture = pieceTexture;
				this._position = centerPos;
				this._frameSpeed = frameSpeed;
				this._frameCounter = 0;
				this._frame = this._texture.Frame(1, 7, 0, 0);
				this._origin = this._frame.Size() / 2f;
			}

			public void Draw(SpriteBatch sp)
			{
				Color light = this.GetLight();
				sp.Draw(this._texture, this._position - Main.screenPosition, new Rectangle?(this._frame), light, 0f, this._origin, 1f, SpriteEffects.None, 0f);
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
				this._frame = this._texture.Frame(1, 7, 0, this._frameCounter / this._frameSpeed);
			}
		}

		public class MoonlordPiece
		{
			private Texture2D _texture;

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

			public MoonlordPiece(Texture2D pieceTexture, Vector2 textureOrigin, Vector2 centerPos, Vector2 velocity, float rot, float angularVelocity)
			{
				this._texture = pieceTexture;
				this._origin = textureOrigin;
				this._position = centerPos;
				this._velocity = velocity;
				this._rotation = rot;
				this._rotationVelocity = angularVelocity;
			}

			public void Draw(SpriteBatch sp)
			{
				Color light = this.GetLight();
				Rectangle? nullable = null;
				sp.Draw(this._texture, this._position - Main.screenPosition, nullable, light, this._rotation, this._origin, 1f, SpriteEffects.None, 0f);
			}

			public Color GetLight()
			{
				Vector3 zero = Vector3.Zero;
				float single = 0f;
				int num = 5;
				Point tileCoordinates = this._position.ToTileCoordinates();
				for (int i = tileCoordinates.X - num; i <= tileCoordinates.X + num; i++)
				{
					for (int j = tileCoordinates.Y - num; j <= tileCoordinates.Y + num; j++)
					{
						Color color = Lighting.GetColor(i, j);
						zero = zero + color.ToVector3();
						single = single + 1f;
					}
				}
				if (single == 0f)
				{
					return Color.White;
				}
				return new Color(zero / single);
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