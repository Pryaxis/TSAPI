
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.ID;

namespace Terraria.GameContent
{
	public class PortalHelper
	{
		public const int PORTALS_PER_PERSON = 2;

		private static int[,] FoundPortals;

		private static int[] PortalCooldownForPlayers;

		private static int[] PortalCooldownForNPCs;

		private readonly static Vector2[] EDGES;

		private readonly static Vector2[] SLOPE_EDGES;

		private readonly static Point[] SLOPE_OFFSETS;

		static PortalHelper()
		{
			PortalHelper.FoundPortals = new int[255, 2];
			PortalHelper.PortalCooldownForPlayers = new int[255];
			PortalHelper.PortalCooldownForNPCs = new int[200];
			Vector2[] vector2 = new Vector2[] { new Vector2(0f, 1f), new Vector2(0f, -1f), new Vector2(1f, 0f), new Vector2(-1f, 0f) };
			PortalHelper.EDGES = vector2;
			Vector2[] vector2Array = new Vector2[] { new Vector2(1f, -1f), new Vector2(-1f, -1f), new Vector2(1f, 1f), new Vector2(-1f, 1f) };
			PortalHelper.SLOPE_EDGES = vector2Array;
			Point[] point = new Point[] { new Point(1, -1), new Point(-1, -1), new Point(1, 1), new Point(-1, 1) };
			PortalHelper.SLOPE_OFFSETS = point;
			for (int i = 0; i < (int)PortalHelper.SLOPE_EDGES.Length; i++)
			{
				PortalHelper.SLOPE_EDGES[i].Normalize();
			}
			for (int j = 0; j < PortalHelper.FoundPortals.GetLength(0); j++)
			{
				PortalHelper.FoundPortals[j, 0] = -1;
				PortalHelper.FoundPortals[j, 1] = -1;
			}
		}

		public PortalHelper()
		{
		}

		private static int AddPortal(Vector2 position, float angle, int form, int direction)
		{
			if (!PortalHelper.SupportedTilesAreFine(position, angle))
			{
				return -1;
			}
			PortalHelper.RemoveMyOldPortal(form);
			PortalHelper.RemoveIntersectingPortals(position, angle);
			int num = Projectile.NewProjectile(position.X, position.Y, 0f, 0f, 602, 0, 0f, Main.myPlayer, angle, (float)form);
			Main.projectile[num].direction = direction;
			Main.projectile[num].netUpdate = true;
			return num;
		}

		private static bool BlockPortals(Tile t)
		{
			if (t.active() && !Main.tileCut[t.type] && !TileID.Sets.BreakableWhenPlacing[t.type] && Main.tileSolid[t.type])
			{
				return true;
			}
			return false;
		}

		private static Vector2 FindCollision(Vector2 startPosition, Vector2 stopPosition)
		{
			int num = 0;
			int num1 = 0;
			Utils.PlotLine(startPosition.ToTileCoordinates(), stopPosition.ToTileCoordinates(), (int x, int y) => {
				num = x;
				num1 = y;
				return !WorldGen.SolidOrSlopedTile(x, y);
			}, false);
			return new Vector2((float)num * 16f, (float)num1 * 16f);
		}

		private static bool FindValidLine(Point position, int xOffset, int yOffset, out Point bestPosition)
		{
			bestPosition = position;
			if (PortalHelper.IsValidLine(position, xOffset, yOffset))
			{
				return true;
			}
			Point point = new Point(position.X - xOffset, position.Y - yOffset);
			if (PortalHelper.IsValidLine(point, xOffset, yOffset))
			{
				bestPosition = point;
				return true;
			}
			Point point1 = new Point(position.X + xOffset, position.Y + yOffset);
			if (!PortalHelper.IsValidLine(point1, xOffset, yOffset))
			{
				return false;
			}
			bestPosition = point1;
			return true;
		}

		public static Color GetPortalColor(int colorIndex)
		{
			return PortalHelper.GetPortalColor(colorIndex / 2, colorIndex % 2);
		}

		public static Color GetPortalColor(int player, int portal)
		{
			Color white = Color.White;
			if (Main.netMode != 0)
			{
				float single = 0.08f;
				float single1 = 0.5f;
				white = Main.HslToRgb((single1 + (float)player * (single * 2f) + (float)portal * single) % 1f, 1f, 0.5f);
			}
			else
			{
				white = (portal != 0 ? Main.HslToRgb(0.52f, 1f, 0.6f) : Main.HslToRgb(0.12f, 1f, 0.5f));
			}
			white.A = 66;
			return white;
		}

		private static void GetPortalEdges(Vector2 position, float angle, out Vector2 start, out Vector2 end)
		{
			Vector2 rotationVector2 = angle.ToRotationVector2();
			start = position + (rotationVector2 * -22f);
			end = position + (rotationVector2 * 22f);
		}

		private static Vector2 GetPortalOutingPoint(Vector2 objectSize, Vector2 portalPosition, float portalAngle, out int bonusX, out int bonusY)
		{
			int num = (int)Math.Round((double)(MathHelper.WrapAngle(portalAngle) / 0.7853982f));
			if (num == 2 || num == -2)
			{
				bonusX = (num == 2 ? -1 : 1);
				bonusY = 0;
				return portalPosition + new Vector2((num == 2 ? -objectSize.X : 0f), -objectSize.Y / 2f);
			}
			if (num == 0 || num == 4)
			{
				bonusX = 0;
				bonusY = (num == 0 ? 1 : -1);
				return portalPosition + new Vector2(-objectSize.X / 2f, (num == 0 ? 0f : -objectSize.Y));
			}
			if (num == -3 || num == 3)
			{
				bonusX = (num == -3 ? 1 : -1);
				bonusY = -1;
				return portalPosition + new Vector2((num == -3 ? 0f : -objectSize.X), -objectSize.Y);
			}
			if (num != 1 && num != -1)
			{
				Main.NewText(string.Concat("Broken portal! (over4s = ", num, ")"), 255, 255, 255, false);
				bonusX = 0;
				bonusY = 0;
				return portalPosition;
			}
			bonusX = (num == -1 ? 1 : -1);
			bonusY = 1;
			return portalPosition + new Vector2((num == -1 ? 0f : -objectSize.X), 0f);
		}

		private static bool IsValidLine(Point position, int xOffset, int yOffset)
		{
			Tile tile = Main.tile[position.X, position.Y];
			Tile tile1 = Main.tile[position.X - xOffset, position.Y - yOffset];
			Tile tile2 = Main.tile[position.X + xOffset, position.Y + yOffset];
			if (PortalHelper.BlockPortals(Main.tile[position.X + yOffset, position.Y - xOffset]) || PortalHelper.BlockPortals(Main.tile[position.X + yOffset - xOffset, position.Y - xOffset - yOffset]) || PortalHelper.BlockPortals(Main.tile[position.X + yOffset + xOffset, position.Y - xOffset + yOffset]))
			{
				return false;
			}
			if (WorldGen.SolidOrSlopedTile(tile) && WorldGen.SolidOrSlopedTile(tile1) && WorldGen.SolidOrSlopedTile(tile2) && tile1.HasSameSlope(tile) && tile2.HasSameSlope(tile))
			{
				return true;
			}
			return false;
		}

		private static void RemoveIntersectingPortals(Vector2 position, float angle)
		{
			Vector2 vector2;
			Vector2 vector21;
			Vector2 vector22;
			Vector2 vector23;
			PortalHelper.GetPortalEdges(position, angle, out vector2, out vector21);
			for (int i = 0; i < 1000; i++)
			{
				Projectile projectile = Main.projectile[i];
				if (projectile.active && projectile.type == ProjectileID.PortalGunGate)
				{
					PortalHelper.GetPortalEdges(projectile.Center, projectile.ai[0], out vector22, out vector23);
					if ((int)Collision.CheckLinevLine(vector2, vector21, vector22, vector23).Length > 0)
					{
						if (projectile.owner != Main.myPlayer)
						{
							NetMessage.SendData((int)PacketTypes.KillPortal, -1, -1, "", i, 0f, 0f, 0f, 0, 0, 0);
						}
						projectile.Kill();
					}
				}
			}
		}

		private static void RemoveMyOldPortal(int form)
		{
			for (int i = 0; i < 1000; i++)
			{
				Projectile projectile = Main.projectile[i];
				if (projectile.active && projectile.type == ProjectileID.PortalGunGate && projectile.owner == Main.myPlayer && projectile.ai[1] == (float)form)
				{
					projectile.Kill();
					return;
				}
			}
		}

		private static bool SupportedHalfbrick(int x, int y)
		{
			Tile tile = Main.tile[x, y];
			if (!tile.nactive() || Main.tileCut[tile.type] || TileID.Sets.BreakableWhenPlacing[tile.type] || !Main.tileSolid[tile.type])
			{
				return false;
			}
			return tile.halfBrick();
		}

		private static bool SupportedNormal(int x, int y)
		{
			Tile tile = Main.tile[x, y];
			if (!tile.nactive() || Main.tileCut[tile.type] || TileID.Sets.BreakableWhenPlacing[tile.type] || !Main.tileSolid[tile.type] || TileID.Sets.NotReallySolid[tile.type] || tile.halfBrick())
			{
				return false;
			}
			return tile.slope() == 0;
		}

		private static bool SupportedSlope(int x, int y, int slope)
		{
			Tile tile = Main.tile[x, y];
			if (!tile.nactive() || Main.tileCut[tile.type] || TileID.Sets.BreakableWhenPlacing[tile.type] || !Main.tileSolid[tile.type])
			{
				return false;
			}
			return tile.slope() == slope;
		}

		public static bool SupportedTilesAreFine(Vector2 portalCenter, float portalAngle)
		{
			int num;
			int num1;
			Point tileCoordinates = portalCenter.ToTileCoordinates();
			int num2 = (int)Math.Round((double)(MathHelper.WrapAngle(portalAngle) / 0.7853982f));
			if (num2 == 2 || num2 == -2)
			{
				num = (num2 == 2 ? -1 : 1);
				num1 = 0;
			}
			else if (num2 == 0 || num2 == 4)
			{
				num = 0;
				num1 = (num2 == 0 ? 1 : -1);
			}
			else if (num2 == -3 || num2 == 3)
			{
				num = (num2 == -3 ? 1 : -1);
				num1 = -1;
			}
			else
			{
				if (num2 != 1 && num2 != -1)
				{
					object[] objArray = new object[] { "Broken portal! (over4s = ", num2, " , ", portalAngle, ")" };
					Main.NewText(string.Concat(objArray), 255, 255, 255, false);
					return false;
				}
				num = (num2 == -1 ? 1 : -1);
				num1 = 1;
			}
			if (num != 0 && num1 != 0)
			{
				int num3 = 3;
				if (num == -1 && num1 == 1)
				{
					num3 = 5;
				}
				if (num == 1 && num1 == -1)
				{
					num3 = 2;
				}
				if (num == 1 && num1 == 1)
				{
					num3 = 4;
				}
				num3--;
				if (!PortalHelper.SupportedSlope(tileCoordinates.X, tileCoordinates.Y, num3) || !PortalHelper.SupportedSlope(tileCoordinates.X + num, tileCoordinates.Y - num1, num3))
				{
					return false;
				}
				return PortalHelper.SupportedSlope(tileCoordinates.X - num, tileCoordinates.Y + num1, num3);
			}
			if (num != 0)
			{
				if (num == 1)
				{
					tileCoordinates.X = tileCoordinates.X - 1;
				}
				if (!PortalHelper.SupportedNormal(tileCoordinates.X, tileCoordinates.Y) || !PortalHelper.SupportedNormal(tileCoordinates.X, tileCoordinates.Y - 1))
				{
					return false;
				}
				return PortalHelper.SupportedNormal(tileCoordinates.X, tileCoordinates.Y + 1);
			}
			if (num1 == 0)
			{
				return true;
			}
			if (num1 == 1)
			{
				tileCoordinates.Y = tileCoordinates.Y - 1;
			}
			if (PortalHelper.SupportedNormal(tileCoordinates.X, tileCoordinates.Y) && PortalHelper.SupportedNormal(tileCoordinates.X + 1, tileCoordinates.Y) && PortalHelper.SupportedNormal(tileCoordinates.X - 1, tileCoordinates.Y))
			{
				return true;
			}
			if (!PortalHelper.SupportedHalfbrick(tileCoordinates.X, tileCoordinates.Y) || !PortalHelper.SupportedHalfbrick(tileCoordinates.X + 1, tileCoordinates.Y))
			{
				return false;
			}
			return PortalHelper.SupportedHalfbrick(tileCoordinates.X - 1, tileCoordinates.Y);
		}

		public static void SyncPortalSections(Vector2 portalPosition, int fluff)
		{
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active)
				{
					RemoteClient.CheckSection(i, portalPosition, fluff);
				}
			}
		}

		public static void SyncPortalsOnPlayerJoin(int plr, int fluff, List<Point> dontInclude, out List<Point> portals, out List<Point> portalCenters)
		{
			portals = new List<Point>();
			portalCenters = new List<Point>();
			for (int i = 0; i < 1000; i++)
			{
				Projectile projectile = Main.projectile[i];
				if (projectile.active && (projectile.type == ProjectileID.PortalGunGate || projectile.type == ProjectileID.PortalGunBolt))
				{
					Vector2 center = projectile.Center;
					int sectionX = Netplay.GetSectionX((int)(center.X / 16f));
					int sectionY = Netplay.GetSectionY((int)(center.Y / 16f));
					for (int j = sectionX - fluff; j < sectionX + fluff + 1; j++)
					{
						for (int k = sectionY - fluff; k < sectionY + fluff + 1; k++)
						{
							if (j >= 0 && j < Main.maxSectionsX && k >= 0 && k < Main.maxSectionsY && !Netplay.Clients[plr].TileSections[j, k] && !dontInclude.Contains(new Point(j, k)))
							{
								portals.Add(new Point(j, k));
								if (!portalCenters.Contains(new Point(sectionX, sectionY)))
								{
									portalCenters.Add(new Point(sectionX, sectionY));
								}
							}
						}
					}
				}
			}
		}

		public static void TryGoingThroughPortals(Entity ent)
		{
			Vector2 vector2;
			Vector2 vector21;
			int num;
			int num1;
			float single = 0f;
			Vector2 vector22 = ent.velocity;
			int num2 = ent.width;
			int num3 = ent.height;
			int num4 = 1;
			if (ent is Player)
			{
				num4 = (int)((Player)ent).gravDir;
			}
			for (int i = 0; i < PortalHelper.FoundPortals.GetLength(0); i++)
			{
				if (PortalHelper.FoundPortals[i, 0] != -1 && PortalHelper.FoundPortals[i, 1] != -1 && (!(ent is Player) || PortalHelper.PortalCooldownForPlayers[i] <= 0) && (!(ent is NPC) || PortalHelper.PortalCooldownForNPCs[i] <= 0))
				{
					for (int j = 0; j < 2; j++)
					{
						Projectile projectile = Main.projectile[PortalHelper.FoundPortals[i, j]];
						PortalHelper.GetPortalEdges(projectile.Center, projectile.ai[0], out vector2, out vector21);
						if (Collision.CheckAABBvLineCollision(ent.position + ent.velocity, ent.Size, vector2, vector21, 2f, ref single))
						{
							Projectile projectile1 = Main.projectile[PortalHelper.FoundPortals[i, 1 - j]];
							float single1 = ent.Hitbox.Distance(projectile.Center);
							Vector2 portalOutingPoint = PortalHelper.GetPortalOutingPoint(ent.Size, projectile1.Center, projectile1.ai[0], out num, out num1) + (Vector2.Normalize(new Vector2((float)num, (float)num1)) * single1);
							Vector2 unitX = Vector2.UnitX * 16f;
							if (Collision.TileCollision(portalOutingPoint - unitX, unitX, num2, num3, false, false, num4) == unitX)
							{
								unitX = -Vector2.UnitX * 16f;
								if (Collision.TileCollision(portalOutingPoint - unitX, unitX, num2, num3, false, false, num4) == unitX)
								{
									unitX = Vector2.UnitY * 16f;
									if (Collision.TileCollision(portalOutingPoint - unitX, unitX, num2, num3, false, false, num4) == unitX)
									{
										unitX = -Vector2.UnitY * 16f;
										if (Collision.TileCollision(portalOutingPoint - unitX, unitX, num2, num3, false, false, num4) == unitX)
										{
											float single2 = 0.1f;
											if (num1 == -num4)
											{
												single2 = 0.1f;
											}
											if (ent.velocity == Vector2.Zero)
											{
												ent.velocity = (projectile.ai[0] - 1.57079637f).ToRotationVector2() * single2;
											}
											if (ent.velocity.Length() < single2)
											{
												ent.velocity.Normalize();
												Entity entity = ent;
												entity.velocity = entity.velocity * single2;
											}
											Vector2 unitX1 = Vector2.Normalize(new Vector2((float)num, (float)num1));
											if (unitX1.HasNaNs() || unitX1 == Vector2.Zero)
											{
												unitX1 = Vector2.UnitX * (float)ent.direction;
											}
											ent.velocity = unitX1 * ent.velocity.Length();
											if (num1 == -num4 && Math.Sign(ent.velocity.Y) != -num4 || Math.Abs(ent.velocity.Y) < 0.1f)
											{
												ent.velocity.Y = (float)(-num4) * 0.1f;
											}
											int num5 = (int)((float)(projectile1.owner * 2) + projectile1.ai[1]);
											int num6 = num5 + (num5 % 2 == 0 ? 1 : -1);
											if (ent is Player)
											{
												Player player = (Player)ent;
												player.lastPortalColorIndex = num6;
												player.Teleport(portalOutingPoint, 4, num5);
												if (Main.netMode == 1)
												{
													NetMessage.SendData((int)PacketTypes.PlayerTeleportPortal, -1, -1, "", player.whoAmI, portalOutingPoint.X, portalOutingPoint.Y, (float)num5, 0, 0, 0);
													NetMessage.SendData((int)PacketTypes.PlayerUpdate, -1, -1, "", player.whoAmI, 0f, 0f, 0f, 0, 0, 0);
												}
												PortalHelper.PortalCooldownForPlayers[i] = 10;
												return;
											}
											if (ent is NPC)
											{
												NPC nPC = (NPC)ent;
												nPC.lastPortalColorIndex = num6;
												nPC.Teleport(portalOutingPoint, 4, num5);
												if (Main.netMode == 1)
												{
													NetMessage.SendData((int)PacketTypes.NpcTeleportPortal, -1, -1, "", nPC.whoAmI, portalOutingPoint.X, portalOutingPoint.Y, (float)num5, 0, 0, 0);
													NetMessage.SendData((int)PacketTypes.NpcUpdate, -1, -1, "", nPC.whoAmI, 0f, 0f, 0f, 0, 0, 0);
												}
												PortalHelper.PortalCooldownForPlayers[i] = 10;
											}
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}

		public static int TryPlacingPortal(Projectile theBolt, Vector2 velocity, Vector2 theCrashVelocity)
		{
			Point point;
			Point point1;
			Vector2 vector2 = velocity / velocity.Length();
			Vector2 vector21 = PortalHelper.FindCollision(theBolt.position, (theBolt.position + velocity) + (vector2 * 32f));
			Point tileCoordinates = vector21.ToTileCoordinates();
			Tile tile = Main.tile[tileCoordinates.X, tileCoordinates.Y];
			Vector2 vector22 = new Vector2((float)(tileCoordinates.X * 16 + 8), (float)(tileCoordinates.Y * 16 + 8));
			if (!WorldGen.SolidOrSlopedTile(tile))
			{
				return -1;
			}
			int num = tile.slope();
			bool flag = tile.halfBrick();
			int num1 = 0;
			while (true)
			{
				if (num1 >= (flag ? 2 : (int)PortalHelper.EDGES.Length))
				{
					break;
				}
				if (Vector2.Dot(PortalHelper.EDGES[num1], vector2) > 0f && PortalHelper.FindValidLine(tileCoordinates, (int)PortalHelper.EDGES[num1].Y, (int)(-PortalHelper.EDGES[num1].X), out point))
				{
					vector22 = new Vector2((float)(point.X * 16 + 8), (float)(point.Y * 16 + 8));
					return PortalHelper.AddPortal(vector22 - (PortalHelper.EDGES[num1] * (flag ? 0f : 8f)), (float)Math.Atan2((double)PortalHelper.EDGES[num1].Y, (double)PortalHelper.EDGES[num1].X) + 1.57079637f, (int)theBolt.ai[0], theBolt.direction);
				}
				num1++;
			}
			if (num != 0)
			{
				Vector2 sLOPEEDGES = PortalHelper.SLOPE_EDGES[num - 1];
				if (Vector2.Dot(sLOPEEDGES, -vector2) > 0f && PortalHelper.FindValidLine(tileCoordinates, -PortalHelper.SLOPE_OFFSETS[num - 1].Y, PortalHelper.SLOPE_OFFSETS[num - 1].X, out point1))
				{
					vector22 = new Vector2((float)(point1.X * 16 + 8), (float)(point1.Y * 16 + 8));
					return PortalHelper.AddPortal(vector22, (float)Math.Atan2((double)sLOPEEDGES.Y, (double)sLOPEEDGES.X) - 1.57079637f, (int)theBolt.ai[0], theBolt.direction);
				}
			}
			return -1;
		}

		public static void UpdatePortalPoints()
		{
			for (int i = 0; i < PortalHelper.FoundPortals.GetLength(0); i++)
			{
				PortalHelper.FoundPortals[i, 0] = -1;
				PortalHelper.FoundPortals[i, 1] = -1;
			}
			for (int j = 0; j < PortalHelper.PortalCooldownForPlayers.Length; j++)
			{
				if (PortalHelper.PortalCooldownForPlayers[j] > 0)
				{
					PortalHelper.PortalCooldownForPlayers[j] -= 1;
				}
			}
			for (int k = 0; k < PortalHelper.PortalCooldownForNPCs.Length; k++)
			{
				if (PortalHelper.PortalCooldownForNPCs[k] > 0)
				{
					PortalHelper.PortalCooldownForNPCs[k] -= 1;
				}
			}
			for (int l = 0; l < 1000; l++)
			{
				Projectile projectile = Main.projectile[l];
				if (projectile.owner < 0 || projectile.owner >= PortalHelper.FoundPortals.GetLength(0))
					continue;
				if (projectile.active && projectile.type == ProjectileID.PortalGunGate && projectile.ai[1] >= 0f && projectile.ai[1] <= 1f)
				{
					PortalHelper.FoundPortals[projectile.owner, (int)projectile.ai[1]] = l;
				}
			}
		}
	}
}
