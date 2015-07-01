using Microsoft.Xna.Framework;
using System;
using Terraria.ID;

namespace Terraria
{
	public static class DelegateMethods
	{
		public static Vector3 v3_1;

		public static float f_1;

		public static Color c_1;

		public static int i_1;

		static DelegateMethods()
		{
			DelegateMethods.v3_1 = Vector3.Zero;
			DelegateMethods.f_1 = 0f;
			DelegateMethods.c_1 = Color.Transparent;
			DelegateMethods.i_1 = 0;
		}

		public static bool CastLight(int x, int y)
		{
			if (x < 0 || x >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY)
			{
				return false;
			}
			if (Main.tile[x, y] == null)
			{
				return false;
			}
			Lighting.AddLight(x, y, DelegateMethods.v3_1.X, DelegateMethods.v3_1.Y, DelegateMethods.v3_1.Z);
			return true;
		}

		public static bool CastLightOpen(int x, int y)
		{
			if (x < 0 || x >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY)
			{
				return false;
			}
			if (Main.tile[x, y] == null)
			{
				return false;
			}
			if (!Main.tile[x, y].active() || Main.tile[x, y].inActive() || Main.tileSolidTop[Main.tile[x, y].type] || !Main.tileSolid[Main.tile[x, y].type])
			{
				Lighting.AddLight(x, y, DelegateMethods.v3_1.X, DelegateMethods.v3_1.Y, DelegateMethods.v3_1.Z);
			}
			return true;
		}

		public static int CompareYReverse(Point a, Point b)
		{
			return b.Y.CompareTo(a.Y);
		}

		public static bool CutTiles(int x, int y)
		{
			if (!WorldGen.InWorld(x, y, 1))
			{
				return false;
			}
			if (Main.tile[x, y] == null)
			{
				return false;
			}
			if (!Main.tileCut[Main.tile[x, y].type])
			{
				return true;
			}
			if (Main.tile[x, y + 1] != null && Main.tile[x, y + 1].type != 78 && Main.tile[x, y + 1].type != 380)
			{
				WorldGen.KillTile(x, y, false, false, false);
				if (Main.netMode != 0)
				{
					NetMessage.SendData(17, -1, -1, "", 0, (float)x, (float)y, 0f, 0, 0, 0);
				}
			}
			return true;
		}

		public static void LightningLaserDraw(int stage, Vector2 currentPosition, float distanceLeft, Rectangle lastFrame, out float distCovered, out Rectangle frame, out Vector2 origin, out Color color)
		{
			color = DelegateMethods.c_1 * DelegateMethods.f_1;
			if (stage == 0)
			{
				distCovered = 0f;
				frame = new Rectangle(0, 0, 21, 8);
				origin = frame.Size() / 2f;
				return;
			}
			if (stage == 1)
			{
				frame = new Rectangle(0, 8, 21, 6);
				distCovered = (float)frame.Height;
				origin = new Vector2((float)(frame.Width / 2), 0f);
				return;
			}
			if (stage != 2)
			{
				distCovered = 9999f;
				frame = Rectangle.Empty;
				origin = Vector2.Zero;
				color = Color.Transparent;
				return;
			}
			distCovered = 8f;
			frame = new Rectangle(0, 14, 21, 8);
			origin = new Vector2((float)(frame.Width / 2), 2f);
		}

		public static bool NotDoorStand(int x, int y)
		{
			if (Main.tile[x, y] == null || !Main.tile[x, y].active() || Main.tile[x, y].type != 11)
			{
				return true;
			}
			if (Main.tile[x, y].frameX < 18)
			{
				return false;
			}
			return Main.tile[x, y].frameX < 54;
		}

		public static void RainbowLaserDraw(int stage, Vector2 currentPosition, float distanceLeft, Rectangle lastFrame, out float distCovered, out Rectangle frame, out Vector2 origin, out Color color)
		{
			color = DelegateMethods.c_1;
			if (stage == 0)
			{
				distCovered = 33f;
				frame = new Rectangle(0, 0, 26, 22);
				origin = frame.Size() / 2f;
				return;
			}
			if (stage == 1)
			{
				frame = new Rectangle(0, 25, 26, 28);
				distCovered = (float)frame.Height;
				origin = new Vector2((float)(frame.Width / 2), 0f);
				return;
			}
			if (stage != 2)
			{
				distCovered = 9999f;
				frame = Rectangle.Empty;
				origin = Vector2.Zero;
				color = Color.Transparent;
				return;
			}
			distCovered = 22f;
			frame = new Rectangle(0, 56, 26, 22);
			origin = new Vector2((float)(frame.Width / 2), 1f);
		}

		public static bool SearchAvoidedByNPCs(int x, int y)
		{
			if (!WorldGen.InWorld(x, y, 1))
			{
				return false;
			}
			if (Main.tile[x, y] == null)
			{
				return false;
			}
			if (Main.tile[x, y].active() && TileID.Sets.AvoidedByNPCs[Main.tile[x, y].type])
			{
				return false;
			}
			return true;
		}

		public static bool TestDust(int x, int y)
		{
			if (x < 0 || x >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY)
			{
				return false;
			}
			Vector2 vector2 = (new Vector2((float)x, (float)y) * 16f) + new Vector2(8f);
			Color color = new Color();
			int num = Dust.NewDust(vector2, 0, 0, 6, 0f, 0f, 0, color, 1f);
			Main.dust[num].noGravity = true;
			Main.dust[num].noLight = true;
			return true;
		}

		public static void TurretLaserDraw(int stage, Vector2 currentPosition, float distanceLeft, Rectangle lastFrame, out float distCovered, out Rectangle frame, out Vector2 origin, out Color color)
		{
			color = DelegateMethods.c_1;
			if (stage == 0)
			{
				distCovered = 32f;
				frame = new Rectangle(0, 0, 22, 20);
				origin = frame.Size() / 2f;
				return;
			}
			if (stage == 1)
			{
				DelegateMethods.i_1 = DelegateMethods.i_1 + 1;
				int i1 = DelegateMethods.i_1 % 5;
				frame = new Rectangle(0, 22 * (i1 + 1), 22, 20);
				distCovered = (float)(frame.Height - 1);
				origin = new Vector2((float)(frame.Width / 2), 0f);
				return;
			}
			if (stage != 2)
			{
				distCovered = 9999f;
				frame = Rectangle.Empty;
				origin = Vector2.Zero;
				color = Color.Transparent;
				return;
			}
			frame = new Rectangle(0, 154, 22, 30);
			distCovered = (float)frame.Height;
			origin = new Vector2((float)(frame.Width / 2), 1f);
		}

		public static class Minecart
		{
			public static Vector2 rotationOrigin;

			public static float rotation;

			public static void Sparks(Vector2 dustPosition)
			{
				Vector2 vector2 = dustPosition;
				Vector2 vector21 = new Vector2((float)((Main.rand.Next(2) == 0 ? 13 : -13)), 0f);
				double num = (double)DelegateMethods.Minecart.rotation;
				Vector2 vector22 = new Vector2();
				dustPosition = vector2 + vector21.RotatedBy(num, vector22);
				float single = (float)Main.rand.Next(-2, 3);
				float single1 = (float)Main.rand.Next(-2, 3);
				Color color = new Color();
				int num1 = Dust.NewDust(dustPosition, 1, 1, 213, single, single1, 0, color, 1f);
				Main.dust[num1].noGravity = true;
				Main.dust[num1].fadeIn = Main.dust[num1].scale + 1f + 0.01f * (float)Main.rand.Next(0, 51);
				Main.dust[num1].noGravity = true;
				Dust dust = Main.dust[num1];
				dust.velocity = dust.velocity * ((float)Main.rand.Next(15, 51) * 0.01f);
				Main.dust[num1].velocity.X = Main.dust[num1].velocity.X * ((float)Main.rand.Next(25, 101) * 0.01f);
				Main.dust[num1].velocity.Y = Main.dust[num1].velocity.Y - (float)Main.rand.Next(15, 31) * 0.1f;
				Main.dust[num1].position.Y = Main.dust[num1].position.Y - 4f;
				if (Main.rand.Next(3) != 0)
				{
					Main.dust[num1].noGravity = false;
					return;
				}
				Dust dust1 = Main.dust[num1];
				dust1.scale = dust1.scale * 0.6f;
			}

			public static void SparksMech(Vector2 dustPosition)
			{
				Vector2 vector2 = dustPosition;
				Vector2 vector21 = new Vector2((float)((Main.rand.Next(2) == 0 ? 13 : -13)), 0f);
				double num = (double)DelegateMethods.Minecart.rotation;
				Vector2 vector22 = new Vector2();
				dustPosition = vector2 + vector21.RotatedBy(num, vector22);
				float single = (float)Main.rand.Next(-2, 3);
				float single1 = (float)Main.rand.Next(-2, 3);
				Color color = new Color();
				int num1 = Dust.NewDust(dustPosition, 1, 1, 260, single, single1, 0, color, 1f);
				Main.dust[num1].noGravity = true;
				Main.dust[num1].fadeIn = Main.dust[num1].scale + 0.5f + 0.01f * (float)Main.rand.Next(0, 51);
				Main.dust[num1].noGravity = true;
				Dust dust = Main.dust[num1];
				dust.velocity = dust.velocity * ((float)Main.rand.Next(15, 51) * 0.01f);
				Main.dust[num1].velocity.X = Main.dust[num1].velocity.X * ((float)Main.rand.Next(25, 101) * 0.01f);
				Main.dust[num1].velocity.Y = Main.dust[num1].velocity.Y - (float)Main.rand.Next(15, 31) * 0.1f;
				Main.dust[num1].position.Y = Main.dust[num1].position.Y - 4f;
				if (Main.rand.Next(3) != 0)
				{
					Main.dust[num1].noGravity = false;
					return;
				}
				Dust dust1 = Main.dust[num1];
				dust1.scale = dust1.scale * 0.6f;
			}
		}
	}
}