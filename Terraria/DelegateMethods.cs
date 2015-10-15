
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
					NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)x, (float)y, 0f, 0, 0, 0);
				}
			}
			return true;
		}

		public static void LightningLaserDraw(int stage, Vector2 currentPosition, float distanceLeft, Rectangle lastFrame, out float distCovered, out Rectangle frame, out Vector2 origin, out Color color)
		{
			distCovered = 0;
			frame = Rectangle.Empty;
			origin = Vector2.Zero;
			color = Color.White;
		}

		public static bool NotDoorStand(int x, int y)
		{
			if (Main.tile[x, y] == null || !Main.tile[x, y].active() || Main.tile[x, y].type != TileID.OpenDoor)
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
			distCovered = 0;
			frame = Rectangle.Empty;
			origin = Vector2.Zero;
			color = Color.White;
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
			return true;
		}

		public static void TurretLaserDraw(int stage, Vector2 currentPosition, float distanceLeft, Rectangle lastFrame, out float distCovered, out Rectangle frame, out Vector2 origin, out Color color)
		{
			distCovered = 0;
			frame = Rectangle.Empty;
			origin = Vector2.Zero;
			color = Color.White;
		}

		public static class Minecart
		{
			public static Vector2 rotationOrigin;

			public static float rotation;

			public static void Sparks(Vector2 dustPosition)
			{
			}

			public static void SparksMech(Vector2 dustPosition)
			{
			}
		}
	}
}
