
using System;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ObjectData;

namespace Terraria
{
	public struct TileObject
	{
		public int xCoord;

		public int yCoord;

		public int type;

		public int style;

		public int alternate;

		public int random;

		public static TileObject Empty;

		public static TileObjectPreviewData objectPreview;

		static TileObject()
		{
			TileObject.Empty = new TileObject();
			TileObject.objectPreview = new TileObjectPreviewData();
		}

		public static bool CanPlace(int x, int y, int type, int style, int dir, out TileObject objectData, bool onlyCheck = false)
		{
			Tile tileSafely;
			TileObjectData tileData = TileObjectData.GetTileData(type, style, 0);
			objectData = TileObject.Empty;
			if (tileData == null)
			{
				return false;
			}
			int num = x - tileData.Origin.X;
			int num1 = y - tileData.Origin.Y;
			if (num < 0 || num + tileData.Width >= Main.maxTilesX || num1 < 0 || num1 + tileData.Height >= Main.maxTilesY)
			{
				return false;
			}
			bool randomStyleRange = tileData.RandomStyleRange > 0;
			if (TileObjectPreviewData.placementCache == null)
			{
				TileObjectPreviewData.placementCache = new TileObjectPreviewData();
			}
			TileObjectPreviewData.placementCache.Reset();
			int num2 = 0;
			int alternatesCount = 0;
			if (tileData.AlternatesCount != 0)
			{
				alternatesCount = tileData.AlternatesCount;
			}
			float single = -1f;
			float single1 = -1f;
			int num3 = 0;
			TileObjectData tileObjectDatum = null;
			int num4 = num2 - 1;
			while (num4 < alternatesCount)
			{
				num4++;
				TileObjectData tileData1 = TileObjectData.GetTileData(type, style, num4);
				if (tileData1.Direction != TileObjectDirection.None && (tileData1.Direction == TileObjectDirection.PlaceLeft && dir == 1 || tileData1.Direction == TileObjectDirection.PlaceRight && dir == -1))
				{
					continue;
				}
				int num5 = x - tileData1.Origin.X;
				int num6 = y - tileData1.Origin.Y;
				if (num5 < 5 || num5 + tileData1.Width > Main.maxTilesX - 5 || num6 < 5 || num6 + tileData1.Height > Main.maxTilesY - 5)
				{
					return false;
				}
				Rectangle rectangle = new Rectangle(0, 0, tileData1.Width, tileData1.Height);
				int num7 = 0;
				int num8 = 0;
				if (tileData1.AnchorTop.tileCount != 0)
				{
					if (rectangle.Y == 0)
					{
						rectangle.Y = -1;
						rectangle.Height = rectangle.Height + 1;
						num8++;
					}
					int anchorTop = tileData1.AnchorTop.checkStart;
					if (anchorTop < rectangle.X)
					{
						rectangle.Width = rectangle.Width + (rectangle.X - anchorTop);
						num7 = num7 + (rectangle.X - anchorTop);
						rectangle.X = anchorTop;
					}
					int anchorTop1 = anchorTop + tileData1.AnchorTop.tileCount - 1;
					int num9 = rectangle.X + rectangle.Width - 1;
					if (anchorTop1 > num9)
					{
						rectangle.Width = rectangle.Width + (anchorTop1 - num9);
					}
				}
				if (tileData1.AnchorBottom.tileCount != 0)
				{
					if (rectangle.Y + rectangle.Height == tileData1.Height)
					{
						rectangle.Height = rectangle.Height + 1;
					}
					int anchorBottom = tileData1.AnchorBottom.checkStart;
					if (anchorBottom < rectangle.X)
					{
						rectangle.Width = rectangle.Width + (rectangle.X - anchorBottom);
						num7 = num7 + (rectangle.X - anchorBottom);
						rectangle.X = anchorBottom;
					}
					int anchorBottom1 = anchorBottom + tileData1.AnchorBottom.tileCount - 1;
					int num10 = rectangle.X + rectangle.Width - 1;
					if (anchorBottom1 > num10)
					{
						rectangle.Width = rectangle.Width + (anchorBottom1 - num10);
					}
				}
				if (tileData1.AnchorLeft.tileCount != 0)
				{
					if (rectangle.X == 0)
					{
						rectangle.X = -1;
						rectangle.Width = rectangle.Width + 1;
						num7++;
					}
					int anchorLeft = tileData1.AnchorLeft.checkStart;
					if ((tileData1.AnchorLeft.type & AnchorType.Tree) == AnchorType.Tree)
					{
						anchorLeft--;
					}
					if (anchorLeft < rectangle.Y)
					{
						rectangle.Width = rectangle.Width + (rectangle.Y - anchorLeft);
						num8 = num8 + (rectangle.Y - anchorLeft);
						rectangle.Y = anchorLeft;
					}
					int anchorLeft1 = anchorLeft + tileData1.AnchorLeft.tileCount - 1;
					if ((tileData1.AnchorLeft.type & AnchorType.Tree) == AnchorType.Tree)
					{
						anchorLeft1 = anchorLeft1 + 2;
					}
					int num11 = rectangle.Y + rectangle.Height - 1;
					if (anchorLeft1 > num11)
					{
						rectangle.Height = rectangle.Height + (anchorLeft1 - num11);
					}
				}
				if (tileData1.AnchorRight.tileCount != 0)
				{
					if (rectangle.X + rectangle.Width == tileData1.Width)
					{
						rectangle.Width = rectangle.Width + 1;
					}
					int anchorLeft2 = tileData1.AnchorLeft.checkStart;
					if ((tileData1.AnchorRight.type & AnchorType.Tree) == AnchorType.Tree)
					{
						anchorLeft2--;
					}
					if (anchorLeft2 < rectangle.Y)
					{
						rectangle.Width = rectangle.Width + (rectangle.Y - anchorLeft2);
						num8 = num8 + (rectangle.Y - anchorLeft2);
						rectangle.Y = anchorLeft2;
					}
					int anchorRight = anchorLeft2 + tileData1.AnchorRight.tileCount - 1;
					if ((tileData1.AnchorRight.type & AnchorType.Tree) == AnchorType.Tree)
					{
						anchorRight = anchorRight + 2;
					}
					int num12 = rectangle.Y + rectangle.Height - 1;
					if (anchorRight > num12)
					{
						rectangle.Height = rectangle.Height + (anchorRight - num12);
					}
				}
				if (onlyCheck)
				{
					TileObject.objectPreview.Reset();
					TileObject.objectPreview.Active = true;
					TileObject.objectPreview.Type = (ushort)type;
					TileObject.objectPreview.Style = (short)style;
					TileObject.objectPreview.Alternate = num4;
					TileObject.objectPreview.Size = new Point16(rectangle.Width, rectangle.Height);
					TileObject.objectPreview.ObjectStart = new Point16(num7, num8);
					TileObject.objectPreview.Coordinates = new Point16(num5 - num7, num6 - num8);
				}
				float single2 = 0f;
				float width = (float)(tileData1.Width * tileData1.Height);
				float single3 = 0f;
				float single4 = 0f;
				for (int i = 0; i < tileData1.Width; i++)
				{
					for (int j = 0; j < tileData1.Height; j++)
					{
						tileSafely = Framing.GetTileSafely(num5 + i, num6 + j);
						bool flag = !tileData1.LiquidPlace(tileSafely);
						bool flag1 = false;
						if (tileData1.AnchorWall)
						{
							single4 = single4 + 1f;
							if (tileData1.isValidWallAnchor((int)tileSafely.wall))
							{
								single3 = single3 + 1f;
							}
							else
							{
								flag1 = true;
							}
						}
						bool flag2 = false;
						if (tileSafely.active() && !Main.tileCut[tileSafely.type])
						{
							flag2 = true;
						}
						if (!flag2 && !flag && !flag1)
						{
							if (onlyCheck)
							{
								TileObject.objectPreview[i + num7, j + num8] = 1;
							}
							single2 = single2 + 1f;
						}
						else if (onlyCheck)
						{
							TileObject.objectPreview[i + num7, j + num8] = 2;
						}
					}
				}
				AnchorData anchorDatum = tileData1.AnchorBottom;
				if (anchorDatum.tileCount != 0)
				{
					single4 = single4 + (float)anchorDatum.tileCount;
					int height = tileData1.Height;
					for (int k = 0; k < anchorDatum.tileCount; k++)
					{
						int num13 = anchorDatum.checkStart + k;
						tileSafely = Framing.GetTileSafely(num5 + num13, num6 + height);
						bool flag3 = false;
						if (tileSafely.nactive())
						{
							if ((anchorDatum.type & AnchorType.SolidTile) == AnchorType.SolidTile && Main.tileSolid[tileSafely.type] && !Main.tileSolidTop[tileSafely.type] && !Main.tileNoAttach[tileSafely.type] && (tileData1.FlattenAnchors || tileSafely.blockType() == 0))
							{
								flag3 = tileData1.isValidTileAnchor((int)tileSafely.type);
							}
							if (!flag3 && ((anchorDatum.type & AnchorType.SolidWithTop) == AnchorType.SolidWithTop || (anchorDatum.type & AnchorType.Table) == AnchorType.Table))
							{
								if (tileSafely.type == 19)
								{
									int num14 = tileSafely.frameX / TileObjectData.PlatformFrameWidth();
									if (!tileSafely.halfBrick() && num14 >= 0 && num14 <= 7 || num14 >= 12 && num14 <= 16 || num14 >= 25 && num14 <= 26)
									{
										flag3 = true;
									}
								}
								else if (Main.tileSolid[tileSafely.type] && Main.tileSolidTop[tileSafely.type])
								{
									flag3 = true;
								}
							}
							if (!flag3 && (anchorDatum.type & AnchorType.Table) == AnchorType.Table && tileSafely.type != 19 && Main.tileTable[tileSafely.type] && tileSafely.blockType() == 0)
							{
								flag3 = true;
							}
							if (!flag3 && (anchorDatum.type & AnchorType.SolidSide) == AnchorType.SolidSide && Main.tileSolid[tileSafely.type] && !Main.tileSolidTop[tileSafely.type])
							{
								switch (tileSafely.blockType())
								{
									case 4:
									case 5:
									{
										flag3 = tileData1.isValidTileAnchor((int)tileSafely.type);
										break;
									}
								}
							}
							if (!flag3 && (anchorDatum.type & AnchorType.AlternateTile) == AnchorType.AlternateTile && tileData1.isValidAlternateAnchor((int)tileSafely.type))
							{
								flag3 = true;
							}
						}
						else if (!flag3 && (anchorDatum.type & AnchorType.EmptyTile) == AnchorType.EmptyTile)
						{
							flag3 = true;
						}
						if (flag3)
						{
							if (onlyCheck)
							{
								TileObject.objectPreview[num13 + num7, height + num8] = 1;
							}
							single3 = single3 + 1f;
						}
						else if (onlyCheck)
						{
							TileObject.objectPreview[num13 + num7, height + num8] = 2;
						}
					}
				}
				anchorDatum = tileData1.AnchorTop;
				if (anchorDatum.tileCount != 0)
				{
					single4 = single4 + (float)anchorDatum.tileCount;
					int num15 = -1;
					for (int l = 0; l < anchorDatum.tileCount; l++)
					{
						int num16 = anchorDatum.checkStart + l;
						tileSafely = Framing.GetTileSafely(num5 + num16, num6 + num15);
						bool flag4 = false;
						if (tileSafely.nactive())
						{
							if (Main.tileSolid[tileSafely.type] && !Main.tileSolidTop[tileSafely.type] && !Main.tileNoAttach[tileSafely.type] && (tileData1.FlattenAnchors || tileSafely.blockType() == 0))
							{
								flag4 = tileData1.isValidTileAnchor((int)tileSafely.type);
							}
							if (!flag4 && (anchorDatum.type & AnchorType.SolidBottom) == AnchorType.SolidBottom && (Main.tileSolid[tileSafely.type] && (!Main.tileSolidTop[tileSafely.type] || tileSafely.type == 19 && (tileSafely.halfBrick() || tileSafely.topSlope())) || tileSafely.halfBrick() || tileSafely.topSlope()) && !tileSafely.bottomSlope())
							{
								flag4 = tileData1.isValidTileAnchor((int)tileSafely.type);
							}
							if (!flag4 && (anchorDatum.type & AnchorType.SolidSide) == AnchorType.SolidSide && Main.tileSolid[tileSafely.type] && !Main.tileSolidTop[tileSafely.type])
							{
								switch (tileSafely.blockType())
								{
									case 2:
									case 3:
									{
										flag4 = tileData1.isValidTileAnchor((int)tileSafely.type);
										break;
									}
								}
							}
							if (!flag4 && (anchorDatum.type & AnchorType.AlternateTile) == AnchorType.AlternateTile && tileData1.isValidAlternateAnchor((int)tileSafely.type))
							{
								flag4 = true;
							}
						}
						else if (!flag4 && (anchorDatum.type & AnchorType.EmptyTile) == AnchorType.EmptyTile)
						{
							flag4 = true;
						}
						if (flag4)
						{
							if (onlyCheck)
							{
								TileObject.objectPreview[num16 + num7, num15 + num8] = 1;
							}
							single3 = single3 + 1f;
						}
						else if (onlyCheck)
						{
							TileObject.objectPreview[num16 + num7, num15 + num8] = 2;
						}
					}
				}
				anchorDatum = tileData1.AnchorRight;
				if (anchorDatum.tileCount != 0)
				{
					single4 = single4 + (float)anchorDatum.tileCount;
					int width1 = tileData1.Width;
					for (int m = 0; m < anchorDatum.tileCount; m++)
					{
						int num17 = anchorDatum.checkStart + m;
						tileSafely = Framing.GetTileSafely(num5 + width1, num6 + num17);
						bool flag5 = false;
						if (tileSafely.nactive())
						{
							if (Main.tileSolid[tileSafely.type] && !Main.tileSolidTop[tileSafely.type] && !Main.tileNoAttach[tileSafely.type] && (tileData1.FlattenAnchors || tileSafely.blockType() == 0))
							{
								flag5 = tileData1.isValidTileAnchor((int)tileSafely.type);
							}
							if (!flag5 && (anchorDatum.type & AnchorType.SolidSide) == AnchorType.SolidSide && Main.tileSolid[tileSafely.type] && !Main.tileSolidTop[tileSafely.type])
							{
								switch (tileSafely.blockType())
								{
									case 2:
									case 4:
									{
										flag5 = tileData1.isValidTileAnchor((int)tileSafely.type);
										break;
									}
								}
							}
							if (!flag5 && (anchorDatum.type & AnchorType.Tree) == AnchorType.Tree && tileSafely.type == 5)
							{
								flag5 = true;
								if (m == 0)
								{
									single4 = single4 + 1f;
									Tile tile = Framing.GetTileSafely(num5 + width1, num6 + num17 - 1);
									if (tile.nactive() && tile.type == TileID.Trees)
									{
										single3 = single3 + 1f;
										if (onlyCheck)
										{
											TileObject.objectPreview[width1 + num7, num17 + num8 - 1] = 1;
										}
									}
									else if (onlyCheck)
									{
										TileObject.objectPreview[width1 + num7, num17 + num8 - 1] = 2;
									}
								}
								if (m == anchorDatum.tileCount - 1)
								{
									single4 = single4 + 1f;
									Tile tileSafely1 = Framing.GetTileSafely(num5 + width1, num6 + num17 + 1);
									if (tileSafely1.nactive() && tileSafely1.type == 5)
									{
										single3 = single3 + 1f;
										if (onlyCheck)
										{
											TileObject.objectPreview[width1 + num7, num17 + num8 + 1] = 1;
										}
									}
									else if (onlyCheck)
									{
										TileObject.objectPreview[width1 + num7, num17 + num8 + 1] = 2;
									}
								}
							}
							if (!flag5 && (anchorDatum.type & AnchorType.AlternateTile) == AnchorType.AlternateTile && tileData1.isValidAlternateAnchor((int)tileSafely.type))
							{
								flag5 = true;
							}
						}
						else if (!flag5 && (anchorDatum.type & AnchorType.EmptyTile) == AnchorType.EmptyTile)
						{
							flag5 = true;
						}
						if (flag5)
						{
							if (onlyCheck)
							{
								TileObject.objectPreview[width1 + num7, num17 + num8] = 1;
							}
							single3 = single3 + 1f;
						}
						else if (onlyCheck)
						{
							TileObject.objectPreview[width1 + num7, num17 + num8] = 2;
						}
					}
				}
				anchorDatum = tileData1.AnchorLeft;
				if (anchorDatum.tileCount != 0)
				{
					single4 = single4 + (float)anchorDatum.tileCount;
					int num18 = -1;
					for (int n = 0; n < anchorDatum.tileCount; n++)
					{
						int num19 = anchorDatum.checkStart + n;
						tileSafely = Framing.GetTileSafely(num5 + num18, num6 + num19);
						bool flag6 = false;
						if (tileSafely.nactive())
						{
							if (Main.tileSolid[tileSafely.type] && !Main.tileSolidTop[tileSafely.type] && !Main.tileNoAttach[tileSafely.type] && (tileData1.FlattenAnchors || tileSafely.blockType() == 0))
							{
								flag6 = tileData1.isValidTileAnchor((int)tileSafely.type);
							}
							if (!flag6 && (anchorDatum.type & AnchorType.SolidSide) == AnchorType.SolidSide && Main.tileSolid[tileSafely.type] && !Main.tileSolidTop[tileSafely.type])
							{
								switch (tileSafely.blockType())
								{
									case 3:
									case 5:
									{
										flag6 = tileData1.isValidTileAnchor((int)tileSafely.type);
										break;
									}
								}
							}
							if (!flag6 && (anchorDatum.type & AnchorType.Tree) == AnchorType.Tree && tileSafely.type == 5)
							{
								flag6 = true;
								if (n == 0)
								{
									single4 = single4 + 1f;
									Tile tile1 = Framing.GetTileSafely(num5 + num18, num6 + num19 - 1);
									if (tile1.nactive() && tile1.type == 5)
									{
										single3 = single3 + 1f;
										if (onlyCheck)
										{
											TileObject.objectPreview[num18 + num7, num19 + num8 - 1] = 1;
										}
									}
									else if (onlyCheck)
									{
										TileObject.objectPreview[num18 + num7, num19 + num8 - 1] = 2;
									}
								}
								if (n == anchorDatum.tileCount - 1)
								{
									single4 = single4 + 1f;
									Tile tileSafely2 = Framing.GetTileSafely(num5 + num18, num6 + num19 + 1);
									if (tileSafely2.nactive() && tileSafely2.type == 5)
									{
										single3 = single3 + 1f;
										if (onlyCheck)
										{
											TileObject.objectPreview[num18 + num7, num19 + num8 + 1] = 1;
										}
									}
									else if (onlyCheck)
									{
										TileObject.objectPreview[num18 + num7, num19 + num8 + 1] = 2;
									}
								}
							}
							if (!flag6 && (anchorDatum.type & AnchorType.AlternateTile) == AnchorType.AlternateTile && tileData1.isValidAlternateAnchor((int)tileSafely.type))
							{
								flag6 = true;
							}
						}
						else if (!flag6 && (anchorDatum.type & AnchorType.EmptyTile) == AnchorType.EmptyTile)
						{
							flag6 = true;
						}
						if (flag6)
						{
							if (onlyCheck)
							{
								TileObject.objectPreview[num18 + num7, num19 + num8] = 1;
							}
							single3 = single3 + 1f;
						}
						else if (onlyCheck)
						{
							TileObject.objectPreview[num18 + num7, num19 + num8] = 2;
						}
					}
				}
				if (tileData1.HookCheck.hook != null)
				{
					if (tileData1.HookCheck.processedCoordinates)
					{
						short num20 = tileData1.Origin.X;
						short num21 = tileData1.Origin.Y;
					}
					if (tileData1.HookCheck.hook(x, y, type, style, dir) == tileData1.HookCheck.badReturn && tileData1.HookCheck.badResponse == 0)
					{
						single3 = 0f;
						single2 = 0f;
						TileObject.objectPreview.AllInvalid();
					}
				}
				float single5 = single3 / single4;
				float single6 = single2 / width;
				if (single5 != 1f || single6 != 1f)
				{
					if (single5 <= single && (single5 != single || single6 <= single1))
					{
						continue;
					}
					TileObjectPreviewData.placementCache.CopyFrom(TileObject.objectPreview);
					single = single5;
					single1 = single6;
					tileObjectDatum = tileData1;
					num3 = num4;
				}
				else
				{
					single = 1f;
					single1 = 1f;
					num3 = num4;
					tileObjectDatum = tileData1;
					break;
				}
			}
			int num22 = -1;
			if (randomStyleRange)
			{
				if (TileObjectPreviewData.randomCache == null)
				{
					TileObjectPreviewData.randomCache = new TileObjectPreviewData();
				}
				bool flag7 = false;
				if (TileObjectPreviewData.randomCache.Type != type)
				{
					flag7 = true;
				}
				else
				{
					Point16 coordinates = TileObjectPreviewData.randomCache.Coordinates;
					Point16 objectStart = TileObjectPreviewData.randomCache.ObjectStart;
					int num23 = coordinates.X + objectStart.X;
					int num24 = coordinates.Y + objectStart.Y;
					int num25 = x - tileData.Origin.X;
					int num26 = y - tileData.Origin.Y;
					if (num23 != num25 || num24 != num26)
					{
						flag7 = true;
					}
				}
				num22 = (!flag7 ? TileObjectPreviewData.randomCache.Random : Main.rand.Next(tileData.RandomStyleRange));
			}
			if (onlyCheck)
			{
				if (single != 1f || single1 != 1f)
				{
					TileObject.objectPreview.CopyFrom(TileObjectPreviewData.placementCache);
					num4 = num3;
				}
				TileObject.objectPreview.Random = num22;
				if (tileData.RandomStyleRange > 0)
				{
					TileObjectPreviewData.randomCache.CopyFrom(TileObject.objectPreview);
				}
			}
			if (!onlyCheck)
			{
				objectData.xCoord = x - tileObjectDatum.Origin.X;
				objectData.yCoord = y - tileObjectDatum.Origin.Y;
				objectData.type = type;
				objectData.style = style;
				objectData.alternate = num4;
				objectData.random = num22;
			}
			if (single != 1f)
			{
				return false;
			}
			return single1 == 1f;
		}

		public static void DrawPreview(TileObjectPreviewData op, Vector2 position)
		{
		}

		public static bool Place(TileObject toBePlaced)
		{
			int num;
			int num1;
			TileObjectData tileData = TileObjectData.GetTileData(toBePlaced.type, toBePlaced.style, toBePlaced.alternate);
			if (tileData == null)
			{
				return false;
			}
			if (tileData.HookPlaceOverride.hook == null)
			{
				ushort num2 = (ushort)toBePlaced.type;
				int coordinateFullWidth = 0;
				int coordinateFullHeight = 0;
				int styleWrapLimit = tileData.CalculatePlacementStyle(toBePlaced.style, toBePlaced.alternate, toBePlaced.random);
				int styleWrapLimit1 = 0;
				if (tileData.StyleWrapLimit > 0)
				{
					styleWrapLimit1 = styleWrapLimit / tileData.StyleWrapLimit;
					styleWrapLimit = styleWrapLimit % tileData.StyleWrapLimit;
				}
				if (!tileData.StyleHorizontal)
				{
					coordinateFullWidth = tileData.CoordinateFullWidth * styleWrapLimit1;
					coordinateFullHeight = tileData.CoordinateFullHeight * styleWrapLimit;
				}
				else
				{
					coordinateFullWidth = tileData.CoordinateFullWidth * styleWrapLimit;
					coordinateFullHeight = tileData.CoordinateFullHeight * styleWrapLimit1;
				}
				int num3 = toBePlaced.xCoord;
				int num4 = toBePlaced.yCoord;
				for (int i = 0; i < tileData.Width; i++)
				{
					for (int j = 0; j < tileData.Height; j++)
					{
						Tile tileSafely = Framing.GetTileSafely(num3 + i, num4 + j);
						if (tileSafely.active() && Main.tileCut[tileSafely.type])
						{
							WorldGen.KillTile(num3 + i, num4 + j, false, false, false);
						}
					}
				}
				for (int k = 0; k < tileData.Width; k++)
				{
					int coordinateWidth = coordinateFullWidth + k * (tileData.CoordinateWidth + tileData.CoordinatePadding);
					int coordinateHeights = coordinateFullHeight;
					for (int l = 0; l < tileData.Height; l++)
					{
						Tile tile = Framing.GetTileSafely(num3 + k, num4 + l);
						if (!tile.active())
						{
							tile.active(true);
							tile.frameX = (short)coordinateWidth;
							tile.frameY = (short)coordinateHeights;
							tile.type = num2;
						}
						coordinateHeights = coordinateHeights + tileData.CoordinateHeights[l] + tileData.CoordinatePadding;
					}
				}
			}
			else
			{
				if (!tileData.HookPlaceOverride.processedCoordinates)
				{
					num = toBePlaced.xCoord + tileData.Origin.X;
					num1 = toBePlaced.yCoord + tileData.Origin.Y;
				}
				else
				{
					num = toBePlaced.xCoord;
					num1 = toBePlaced.yCoord;
				}
				if (tileData.HookPlaceOverride.hook(num, num1, toBePlaced.type, toBePlaced.style, 1) == tileData.HookPlaceOverride.badReturn)
				{
					return false;
				}
			}
			if (tileData.FlattenAnchors)
			{
				AnchorData anchorBottom = tileData.AnchorBottom;
				if (anchorBottom.tileCount != 0 && (anchorBottom.type & AnchorType.SolidTile) == AnchorType.SolidTile)
				{
					int num5 = toBePlaced.xCoord + anchorBottom.checkStart;
					int num6 = toBePlaced.yCoord + tileData.Height;
					for (int m = 0; m < anchorBottom.tileCount; m++)
					{
						Tile tileSafely1 = Framing.GetTileSafely(num5 + m, num6);
						if (Main.tileSolid[tileSafely1.type] && !Main.tileSolidTop[tileSafely1.type] && tileSafely1.blockType() != 0)
						{
							WorldGen.SlopeTile(num5 + m, num6, 0);
						}
					}
				}
				anchorBottom = tileData.AnchorTop;
				if (anchorBottom.tileCount != 0 && (anchorBottom.type & AnchorType.SolidTile) == AnchorType.SolidTile)
				{
					int num7 = toBePlaced.xCoord + anchorBottom.checkStart;
					int num8 = toBePlaced.yCoord - 1;
					for (int n = 0; n < anchorBottom.tileCount; n++)
					{
						Tile tile1 = Framing.GetTileSafely(num7 + n, num8);
						if (Main.tileSolid[tile1.type] && !Main.tileSolidTop[tile1.type] && tile1.blockType() != 0)
						{
							WorldGen.SlopeTile(num7 + n, num8, 0);
						}
					}
				}
				anchorBottom = tileData.AnchorRight;
				if (anchorBottom.tileCount != 0 && (anchorBottom.type & AnchorType.SolidTile) == AnchorType.SolidTile)
				{
					int num9 = toBePlaced.xCoord + tileData.Width;
					int num10 = toBePlaced.yCoord + anchorBottom.checkStart;
					for (int o = 0; o < anchorBottom.tileCount; o++)
					{
						Tile tileSafely2 = Framing.GetTileSafely(num9, num10 + o);
						if (Main.tileSolid[tileSafely2.type] && !Main.tileSolidTop[tileSafely2.type] && tileSafely2.blockType() != 0)
						{
							WorldGen.SlopeTile(num9, num10 + o, 0);
						}
					}
				}
				anchorBottom = tileData.AnchorLeft;
				if (anchorBottom.tileCount != 0 && (anchorBottom.type & AnchorType.SolidTile) == AnchorType.SolidTile)
				{
					int num11 = toBePlaced.xCoord - 1;
					int num12 = toBePlaced.yCoord + anchorBottom.checkStart;
					for (int p = 0; p < anchorBottom.tileCount; p++)
					{
						Tile tile2 = Framing.GetTileSafely(num11, num12 + p);
						if (Main.tileSolid[tile2.type] && !Main.tileSolidTop[tile2.type] && tile2.blockType() != 0)
						{
							WorldGen.SlopeTile(num11, num12 + p, 0);
						}
					}
				}
			}
			return true;
		}
	}
}
