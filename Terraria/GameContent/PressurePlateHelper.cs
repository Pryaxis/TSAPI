using System;
using System.Collections.Generic;

namespace Terraria.GameContent
{
	public class PressurePlateHelper
	{
		public static Dictionary<Point, bool[]> PressurePlatesPressed = new Dictionary<Point, bool[]>();

		public static bool NeedsFirstUpdate = false;

		private static Vector2[] PlayerLastPosition = new Vector2[255];

		private static Rectangle pressurePlateBounds = new Rectangle(0, 0, 16, 10);

		public static void Update()
		{
			if (!PressurePlateHelper.NeedsFirstUpdate)
			{
				return;
			}
			foreach (Point current in PressurePlateHelper.PressurePlatesPressed.Keys)
			{
				PressurePlateHelper.PokeLocation(current);
			}
			PressurePlateHelper.PressurePlatesPressed.Clear();
		}

		public static void Reset()
		{
			PressurePlateHelper.PressurePlatesPressed.Clear();
			for (int i = 0; i < PressurePlateHelper.PlayerLastPosition.Length; i++)
			{
				PressurePlateHelper.PlayerLastPosition[i] = Vector2.Zero;
			}
		}

		public static void ResetPlayer(int player)
		{
			foreach (bool[] current in PressurePlateHelper.PressurePlatesPressed.Values)
			{
				current[player] = false;
			}
		}

		public static void UpdatePlayerPosition(Player player)
		{
			Point p = new Point(1, 1);
			Vector2 vector = p.ToVector2();
			List<Point> tilesIn = Collision.GetTilesIn(PressurePlateHelper.PlayerLastPosition[player.whoAmI] + vector, PressurePlateHelper.PlayerLastPosition[player.whoAmI] + player.Size - vector * 2f);
			List<Point> tilesIn2 = Collision.GetTilesIn(player.TopLeft + vector, player.BottomRight - vector * 2f);
			Rectangle hitbox = player.Hitbox;
			Rectangle hitbox2 = player.Hitbox;
			hitbox.Inflate(-p.X, -p.Y);
			hitbox2.Inflate(-p.X, -p.Y);
			hitbox2.X = (int)PressurePlateHelper.PlayerLastPosition[player.whoAmI].X;
			hitbox2.Y = (int)PressurePlateHelper.PlayerLastPosition[player.whoAmI].Y;
			for (int i = 0; i < tilesIn.Count; i++)
			{
				Point point = tilesIn[i];
				Tile tile = Main.tile[point.X, point.Y];
				if (tile.active() && tile.type == 428)
				{
					PressurePlateHelper.pressurePlateBounds.X = point.X * 16;
					PressurePlateHelper.pressurePlateBounds.Y = point.Y * 16 + 16 - PressurePlateHelper.pressurePlateBounds.Height;
					if (!hitbox.Intersects(PressurePlateHelper.pressurePlateBounds) && !tilesIn2.Contains(point))
					{
						PressurePlateHelper.MoveAwayFrom(point, player.whoAmI);
					}
				}
			}
			for (int j = 0; j < tilesIn2.Count; j++)
			{
				Point point2 = tilesIn2[j];
				Tile tile2 = Main.tile[point2.X, point2.Y];
				if (tile2.active() && tile2.type == 428)
				{
					PressurePlateHelper.pressurePlateBounds.X = point2.X * 16;
					PressurePlateHelper.pressurePlateBounds.Y = point2.Y * 16 + 16 - PressurePlateHelper.pressurePlateBounds.Height;
					if (hitbox.Intersects(PressurePlateHelper.pressurePlateBounds) && (!tilesIn.Contains(point2) || !hitbox2.Intersects(PressurePlateHelper.pressurePlateBounds)))
					{
						PressurePlateHelper.MoveInto(point2, player.whoAmI);
					}
				}
			}
			PressurePlateHelper.PlayerLastPosition[player.whoAmI] = player.position;
		}

		public static void DestroyPlate(Point location)
		{
			bool[] array;
			if (PressurePlateHelper.PressurePlatesPressed.TryGetValue(location, out array))
			{
				PressurePlateHelper.PressurePlatesPressed.Remove(location);
				PressurePlateHelper.PokeLocation(location);
			}
		}

		private static void UpdatePlatePosition(Point location, int player, bool onIt)
		{
			if (onIt)
			{
				PressurePlateHelper.MoveInto(location, player);
				return;
			}
			PressurePlateHelper.MoveAwayFrom(location, player);
		}

		private static void MoveInto(Point location, int player)
		{
			bool[] array;
			if (PressurePlateHelper.PressurePlatesPressed.TryGetValue(location, out array))
			{
				array[player] = true;
				return;
			}
			PressurePlateHelper.PressurePlatesPressed[location] = new bool[255];
			PressurePlateHelper.PressurePlatesPressed[location][player] = true;
			PressurePlateHelper.PokeLocation(location);
		}

		private static void MoveAwayFrom(Point location, int player)
		{
			bool[] array;
			if (PressurePlateHelper.PressurePlatesPressed.TryGetValue(location, out array))
			{
				array[player] = false;
				bool flag = false;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i])
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					PressurePlateHelper.PressurePlatesPressed.Remove(location);
					PressurePlateHelper.PokeLocation(location);
				}
			}
		}

		private static void PokeLocation(Point location)
		{
			if (Main.netMode != 1)
			{
				Wiring.blockPlayerTeleportationForOneIteration = true;
				Wiring.HitSwitch(location.X, location.Y);
				NetMessage.SendData(59, -1, -1, "", location.X, (float)location.Y, 0f, 0f, 0, 0, 0);
			}
		}
	}
}
