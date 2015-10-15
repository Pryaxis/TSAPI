
using System;
using System.Runtime.CompilerServices;
using Terraria.ID;

namespace Terraria
{
	public static class Minecart
	{
		private const int TotalFrames = 36;

		public const int LeftDownDecoration = 36;

		public const int RightDownDecoration = 37;

		public const int BouncyBumperDecoration = 38;

		public const int RegularBumperDecoration = 39;

		public const int Flag_OnTrack = 0;

		public const int Flag_BouncyBumper = 1;

		public const int Flag_UsedRamp = 2;

		public const int Flag_HitSwitch = 3;

		public const int Flag_BoostLeft = 4;

		public const int Flag_BoostRight = 5;

		private const int NoConnection = -1;

		private const int TopConnection = 0;

		private const int MiddleConnection = 1;

		private const int BottomConnection = 2;

		private const int BumperEnd = -1;

		private const int BouncyEnd = -2;

		private const int RampEnd = -3;

		private const int OpenEnd = -4;

		public const float BoosterSpeed = 4f;

		private const int Type_Normal = 0;

		private const int Type_Pressure = 1;

		private const int Type_Booster = 2;

		private const float MinecartTextureWidth = 50f;

		private static Vector2 _trackMagnetOffset;

		private static int[] _leftSideConnection;

		private static int[] _rightSideConnection;

		private static int[] _trackType;

		private static bool[] _boostLeft;

		private static Vector2[] _texturePosition;

		private static short _firstPressureFrame;

		private static short _firstLeftBoostFrame;

		private static short _firstRightBoostFrame;

		private static int[][] _trackSwitchOptions;

		private static int[][] _tileHeight;

		static Minecart()
		{
			Minecart._trackMagnetOffset = new Vector2(25f, 26f);
		}

		private static short BackTrack(this Tile tileTrack)
		{
			return tileTrack.frameY;
		}

		private static void BackTrack(this Tile tileTrack, short trackID)
		{
			tileTrack.frameY = trackID;
		}

		public static bool DrawBouncyBumper(int frameID)
		{
			if (frameID < 0 || frameID >= 36)
			{
				return false;
			}
			if (Minecart._tileHeight[frameID][0] == -2)
			{
				return true;
			}
			return Minecart._tileHeight[frameID][7] == -2;
		}

		public static bool DrawBumper(int frameID)
		{
			if (frameID < 0 || frameID >= 36)
			{
				return false;
			}
			if (Minecart._tileHeight[frameID][0] == -1)
			{
				return true;
			}
			return Minecart._tileHeight[frameID][7] == -1;
		}

		public static bool DrawLeftDecoration(int frameID)
		{
			if (frameID < 0 || frameID >= 36)
			{
				return false;
			}
			return Minecart._leftSideConnection[frameID] == 2;
		}

		public static bool DrawRightDecoration(int frameID)
		{
			if (frameID < 0 || frameID >= 36)
			{
				return false;
			}
			return Minecart._rightSideConnection[frameID] == 2;
		}

		public static void FlipSwitchTrack(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			short num = tile.FrontTrack();
			if (num == -1)
			{
				return;
			}
			switch (Minecart._trackType[num])
			{
				case 0:
				{
					if (tile.BackTrack() == -1)
					{
						return;
					}
					tile.FrontTrack(tile.BackTrack());
					tile.BackTrack(num);
					NetMessage.SendTileSquare(-1, i, j, 1);
					return;
				}
				case 1:
				{
					return;
				}
				case 2:
				{
					Minecart.FrameTrack(i, j, true, true);
					NetMessage.SendTileSquare(-1, i, j, 1);
					return;
				}
				default:
				{
					return;
				}
			}
		}

		public static bool FrameTrack(int i, int j, bool pound, bool mute = false)
		{
			int num;
			bool flag;
			int num1 = 0;
			Tile tile = Main.tile[i, j];
			if (tile == null)
			{
				tile = new Tile();
				Main.tile[i, j] = tile;
			}
			if (mute && tile.type != TileID.MinecartTrack)
			{
				return false;
			}
			if (Main.tile[i - 1, j - 1] != null && Main.tile[i - 1, j - 1].type == 314)
			{
				num1++;
			}
			if (Main.tile[i - 1, j] != null && Main.tile[i - 1, j].type == 314)
			{
				num1 = num1 + 2;
			}
			if (Main.tile[i - 1, j + 1] != null && Main.tile[i - 1, j + 1].type == 314)
			{
				num1 = num1 + 4;
			}
			if (Main.tile[i + 1, j - 1] != null && Main.tile[i + 1, j - 1].type == 314)
			{
				num1 = num1 + 8;
			}
			if (Main.tile[i + 1, j] != null && Main.tile[i + 1, j].type == 314)
			{
				num1 = num1 + 16;
			}
			if (Main.tile[i + 1, j + 1] != null && Main.tile[i + 1, j + 1].type == 314)
			{
				num1 = num1 + 32;
			}
			int num2 = tile.FrontTrack();
			int num3 = tile.BackTrack();
			if (Minecart._trackType == null)
			{
				return false;
			}
			num = (num2 < 0 || num2 >= (int)Minecart._trackType.Length ? 0 : Minecart._trackType[num2]);
			int num4 = -1;
			int num5 = -1;
			int[] numArray = Minecart._trackSwitchOptions[num1];
			if (numArray == null)
			{
				if (pound)
				{
					return false;
				}
				tile.FrontTrack(0);
				tile.BackTrack(-1);
				return false;
			}
			if (pound)
			{
				for (int i1 = 0; i1 < (int)numArray.Length; i1++)
				{
					if (num2 == numArray[i1])
					{
						num4 = i1;
					}
					if (num3 == numArray[i1])
					{
						num5 = i1;
					}
				}
				int num6 = 0;
				int num7 = 0;
				for (int j1 = 0; j1 < (int)numArray.Length; j1++)
				{
					if (Minecart._trackType[numArray[j1]] == num)
					{
						if (Minecart._leftSideConnection[numArray[j1]] == -1 || Minecart._rightSideConnection[numArray[j1]] == -1)
						{
							num7++;
						}
						else
						{
							num6++;
						}
					}
				}
				if (num6 < 2 && num7 < 2)
				{
					return false;
				}
				bool flag1 = num6 == 0;
				bool flag2 = false;
				if (!flag1)
				{
					while (!flag2)
					{
						num5++;
						if (num5 < (int)numArray.Length)
						{
							if (Minecart._leftSideConnection[numArray[num5]] == Minecart._leftSideConnection[numArray[num4]] && Minecart._rightSideConnection[numArray[num5]] == Minecart._rightSideConnection[numArray[num4]] || Minecart._trackType[numArray[num5]] != num || Minecart._leftSideConnection[numArray[num5]] == -1 || Minecart._rightSideConnection[numArray[num5]] == -1)
							{
								continue;
							}
							flag2 = true;
						}
						else
						{
							num5 = -1;
							break;
						}
					}
				}
				if (!flag2)
				{
					do
					{
					Label0:
						num4++;
						if (num4 >= (int)numArray.Length)
						{
							num4 = -1;
							while (true)
							{
								num4++;
								if (Minecart._trackType[numArray[num4]] == num)
								{
									if ((Minecart._leftSideConnection[numArray[num4]] == -1 ? true : Minecart._rightSideConnection[numArray[num4]] == -1) == flag1)
									{
										goto Label1;
									}
								}
							}
						}
						else if (Minecart._trackType[numArray[num4]] == num)
						{
							flag = (Minecart._leftSideConnection[numArray[num4]] == -1 ? true : Minecart._rightSideConnection[numArray[num4]] == -1);
						}
						else
						{
							goto Label0;
						}
					}
					while (flag != flag1);
				}
			}
			else
			{
				int num8 = -1;
				int num9 = -1;
				bool flag3 = false;
				for (int k = 0; k < (int)numArray.Length; k++)
				{
					int num10 = numArray[k];
					if (num3 == numArray[k])
					{
						num5 = k;
					}
					if (Minecart._trackType[num10] == num)
					{
						if (Minecart._leftSideConnection[num10] == -1 || Minecart._rightSideConnection[num10] == -1)
						{
							if (num2 == numArray[k])
							{
								num4 = k;
								flag3 = true;
							}
							if (num8 == -1)
							{
								num8 = k;
							}
						}
						else
						{
							if (num2 == numArray[k])
							{
								num4 = k;
								flag3 = false;
							}
							if (num9 == -1)
							{
								num9 = k;
							}
						}
					}
				}
				if (num9 == -1)
				{
					if (num4 == -1)
					{
						if (num == 2)
						{
							return false;
						}
						if (num == 1)
						{
							return false;
						}
						num4 = num8;
					}
					num5 = -1;
				}
				else if (num4 == -1 || flag3)
				{
					num4 = num9;
				}
			}
		Label1:
			bool flag4 = false;
			if (num4 == -2)
			{
				if (tile.FrontTrack() != Minecart._firstPressureFrame)
				{
					flag4 = true;
				}
			}
			else if (num4 == -1)
			{
				if (tile.FrontTrack() != 0)
				{
					flag4 = true;
				}
			}
			else if (tile.FrontTrack() != numArray[num4])
			{
				flag4 = true;
			}
			if (num5 == -1)
			{
				if (tile.BackTrack() != -1)
				{
					flag4 = true;
				}
			}
			else if (tile.BackTrack() != numArray[num5])
			{
				flag4 = true;
			}
			if (num4 == -2)
			{
				tile.FrontTrack(Minecart._firstPressureFrame);
			}
			else if (num4 != -1)
			{
				tile.FrontTrack((short)numArray[num4]);
			}
			else
			{
				tile.FrontTrack(0);
			}
			if (num5 != -1)
			{
				tile.BackTrack((short)numArray[num5]);
			}
			else
			{
				tile.BackTrack(-1);
			}
			if (pound && flag4 && !mute)
			{
				WorldGen.KillTile(i, j, true, false, false);
			}
			return true;
		}

		private static short FrontTrack(this Tile tileTrack)
		{
			return tileTrack.frameX;
		}

		private static void FrontTrack(this Tile tileTrack, short trackID)
		{
			tileTrack.frameX = trackID;
		}

		public static bool GetOnTrack(int tileX, int tileY, ref Vector2 Position, int Width, int Height)
		{
			Tile tile = Main.tile[tileX, tileY];
			if (tile.type != TileID.MinecartTrack)
			{
				return false;
			}
			Vector2 vector2 = new Vector2((float)(Width / 2) - 25f, (float)(Height / 2));
			Vector2 position = (Position + vector2) + Minecart._trackMagnetOffset;
			int x = (int)position.X % 16 / 2;
			int num = -1;
			int num1 = 0;
			int num2 = x;
			while (num2 < 8)
			{
				num1 = Minecart._tileHeight[tile.frameX][num2];
				if (num1 < 0)
				{
					num2++;
				}
				else
				{
					num = num2;
					break;
				}
			}
			if (num == -1)
			{
				int num3 = x - 1;
				while (num3 >= 0)
				{
					num1 = Minecart._tileHeight[tile.frameX][num3];
					if (num1 < 0)
					{
						num3--;
					}
					else
					{
						num = num3;
						break;
					}
				}
			}
			if (num == -1)
			{
				return false;
			}
			position.X = (float)(tileX * 16 + num * 2);
			position.Y = (float)(tileY * 16 + num1);
			position = position - Minecart._trackMagnetOffset;
			position = position - vector2;
			Position = position;
			return true;
		}

		public static Rectangle GetSourceRect(int frameID, int animationFrame = 0)
		{
			if (frameID < 0 || frameID >= 40)
			{
				return new Rectangle(0, 0, 0, 0);
			}
			Vector2 vector2 = Minecart._texturePosition[frameID];
			Rectangle rectangle = new Rectangle((int)vector2.X, (int)vector2.Y, 16, 16);
			if (frameID < 36 && Minecart._trackType[frameID] == 2)
			{
				rectangle.Y = rectangle.Y + 18 * animationFrame;
			}
			return rectangle;
		}

		public static int GetTrackItem(Tile trackCache)
		{
			switch (Minecart._trackType[trackCache.frameX])
			{
				case 0:
				{
					return 2340;
				}
				case 1:
				{
					return 2492;
				}
				case 2:
				{
					return 2739;
				}
			}
			return 0;
		}

		public static void HitTrackSwitch(Vector2 Position, int Width, int Height)
		{
			Vector2 vector2 = new Vector2((float)(Width / 2) - 25f, (float)(Height / 2));
			Vector2 position = Position + new Vector2((float)(Width / 2) - 25f, (float)(Height / 2));
			Vector2 vector21 = position + Minecart._trackMagnetOffset;
			int x = (int)(vector21.X / 16f);
			int y = (int)(vector21.Y / 16f);
			Wiring.HitSwitch(x, y);
			NetMessage.SendData((int)PacketTypes.HitSwitch, -1, -1, "", x, (float)y, 0f, 0f, 0, 0, 0);
		}

		public static void Initialize()
		{
			Minecart._rightSideConnection = new int[36];
			Minecart._leftSideConnection = new int[36];
			Minecart._trackType = new int[36];
			Minecart._boostLeft = new bool[36];
			Minecart._texturePosition = new Vector2[40];
			Minecart._tileHeight = new int[36][];
			for (int i = 0; i < 36; i++)
			{
				int[] numArray = new int[8];
				for (int j = 0; j < (int)numArray.Length; j++)
				{
					numArray[j] = 5;
				}
				Minecart._tileHeight[i] = numArray;
			}
			int num = 0;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = -1;
			Minecart._tileHeight[num][0] = -4;
			Minecart._tileHeight[num][7] = -4;
			Minecart._texturePosition[num] = new Vector2(0f, 0f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = 1;
			Minecart._texturePosition[num] = new Vector2(1f, 0f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 1;
			for (int k = 0; k < 4; k++)
			{
				Minecart._tileHeight[num][k] = -1;
			}
			Minecart._texturePosition[num] = new Vector2(2f, 1f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = -1;
			for (int l = 4; l < 8; l++)
			{
				Minecart._tileHeight[num][l] = -1;
			}
			Minecart._texturePosition[num] = new Vector2(3f, 1f);
			num++;
			Minecart._leftSideConnection[num] = 2;
			Minecart._rightSideConnection[num] = 1;
			Minecart._tileHeight[num][0] = 1;
			Minecart._tileHeight[num][1] = 2;
			Minecart._tileHeight[num][2] = 3;
			Minecart._tileHeight[num][3] = 3;
			Minecart._tileHeight[num][4] = 4;
			Minecart._tileHeight[num][5] = 4;
			Minecart._texturePosition[num] = new Vector2(0f, 2f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = 2;
			Minecart._tileHeight[num][2] = 4;
			Minecart._tileHeight[num][3] = 4;
			Minecart._tileHeight[num][4] = 3;
			Minecart._tileHeight[num][5] = 3;
			Minecart._tileHeight[num][6] = 2;
			Minecart._tileHeight[num][7] = 1;
			Minecart._texturePosition[num] = new Vector2(1f, 2f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = 0;
			Minecart._tileHeight[num][4] = 6;
			Minecart._tileHeight[num][5] = 6;
			Minecart._tileHeight[num][6] = 7;
			Minecart._tileHeight[num][7] = 8;
			Minecart._texturePosition[num] = new Vector2(0f, 1f);
			num++;
			Minecart._leftSideConnection[num] = 0;
			Minecart._rightSideConnection[num] = 1;
			Minecart._tileHeight[num][0] = 8;
			Minecart._tileHeight[num][1] = 7;
			Minecart._tileHeight[num][2] = 6;
			Minecart._tileHeight[num][3] = 6;
			Minecart._texturePosition[num] = new Vector2(1f, 1f);
			num++;
			Minecart._leftSideConnection[num] = 0;
			Minecart._rightSideConnection[num] = 2;
			for (int m = 0; m < 8; m++)
			{
				Minecart._tileHeight[num][m] = 8 - m;
			}
			Minecart._texturePosition[num] = new Vector2(0f, 3f);
			num++;
			Minecart._leftSideConnection[num] = 2;
			Minecart._rightSideConnection[num] = 0;
			for (int n = 0; n < 8; n++)
			{
				Minecart._tileHeight[num][n] = n + 1;
			}
			Minecart._texturePosition[num] = new Vector2(1f, 3f);
			num++;
			Minecart._leftSideConnection[num] = 2;
			Minecart._rightSideConnection[num] = -1;
			Minecart._tileHeight[num][0] = 1;
			Minecart._tileHeight[num][1] = 2;
			for (int o = 2; o < 8; o++)
			{
				Minecart._tileHeight[num][o] = -1;
			}
			Minecart._texturePosition[num] = new Vector2(4f, 1f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 2;
			Minecart._tileHeight[num][6] = 2;
			Minecart._tileHeight[num][7] = 1;
			for (int p = 0; p < 6; p++)
			{
				Minecart._tileHeight[num][p] = -1;
			}
			Minecart._texturePosition[num] = new Vector2(5f, 1f);
			num++;
			Minecart._leftSideConnection[num] = 0;
			Minecart._rightSideConnection[num] = -1;
			Minecart._tileHeight[num][0] = 8;
			Minecart._tileHeight[num][1] = 7;
			Minecart._tileHeight[num][2] = 6;
			for (int q = 3; q < 8; q++)
			{
				Minecart._tileHeight[num][q] = -1;
			}
			Minecart._texturePosition[num] = new Vector2(6f, 1f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 0;
			Minecart._tileHeight[num][5] = 6;
			Minecart._tileHeight[num][6] = 7;
			Minecart._tileHeight[num][7] = 8;
			for (int r = 0; r < 5; r++)
			{
				Minecart._tileHeight[num][r] = -1;
			}
			Minecart._texturePosition[num] = new Vector2(7f, 1f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 1;
			Minecart._tileHeight[num][0] = -4;
			Minecart._texturePosition[num] = new Vector2(2f, 0f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = -1;
			Minecart._tileHeight[num][7] = -4;
			Minecart._texturePosition[num] = new Vector2(3f, 0f);
			num++;
			Minecart._leftSideConnection[num] = 2;
			Minecart._rightSideConnection[num] = -1;
			for (int s = 0; s < 6; s++)
			{
				Minecart._tileHeight[num][s] = s + 1;
			}
			Minecart._tileHeight[num][6] = -3;
			Minecart._tileHeight[num][7] = -3;
			Minecart._texturePosition[num] = new Vector2(4f, 0f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 2;
			Minecart._tileHeight[num][0] = -3;
			Minecart._tileHeight[num][1] = -3;
			for (int t = 2; t < 8; t++)
			{
				Minecart._tileHeight[num][t] = 8 - t;
			}
			Minecart._texturePosition[num] = new Vector2(5f, 0f);
			num++;
			Minecart._leftSideConnection[num] = 0;
			Minecart._rightSideConnection[num] = -1;
			for (int u = 0; u < 6; u++)
			{
				Minecart._tileHeight[num][u] = 8 - u;
			}
			Minecart._tileHeight[num][6] = -3;
			Minecart._tileHeight[num][7] = -3;
			Minecart._texturePosition[num] = new Vector2(6f, 0f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 0;
			Minecart._tileHeight[num][0] = -3;
			Minecart._tileHeight[num][1] = -3;
			for (int v = 2; v < 8; v++)
			{
				Minecart._tileHeight[num][v] = v + 1;
			}
			Minecart._texturePosition[num] = new Vector2(7f, 0f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = -1;
			Minecart._tileHeight[num][0] = -4;
			Minecart._tileHeight[num][7] = -4;
			Minecart._trackType[num] = 1;
			Minecart._texturePosition[num] = new Vector2(0f, 4f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = 1;
			Minecart._trackType[num] = 1;
			Minecart._texturePosition[num] = new Vector2(1f, 4f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 1;
			Minecart._tileHeight[num][0] = -4;
			Minecart._trackType[num] = 1;
			Minecart._texturePosition[num] = new Vector2(0f, 5f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = -1;
			Minecart._tileHeight[num][7] = -4;
			Minecart._trackType[num] = 1;
			Minecart._texturePosition[num] = new Vector2(1f, 5f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 1;
			for (int w = 0; w < 6; w++)
			{
				Minecart._tileHeight[num][w] = -2;
			}
			Minecart._texturePosition[num] = new Vector2(2f, 2f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = -1;
			for (int x = 2; x < 8; x++)
			{
				Minecart._tileHeight[num][x] = -2;
			}
			Minecart._texturePosition[num] = new Vector2(3f, 2f);
			num++;
			Minecart._leftSideConnection[num] = 2;
			Minecart._rightSideConnection[num] = -1;
			Minecart._tileHeight[num][0] = 1;
			Minecart._tileHeight[num][1] = 2;
			for (int y = 2; y < 8; y++)
			{
				Minecart._tileHeight[num][y] = -2;
			}
			Minecart._texturePosition[num] = new Vector2(4f, 2f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 2;
			Minecart._tileHeight[num][6] = 2;
			Minecart._tileHeight[num][7] = 1;
			for (int a = 0; a < 6; a++)
			{
				Minecart._tileHeight[num][a] = -2;
			}
			Minecart._texturePosition[num] = new Vector2(5f, 2f);
			num++;
			Minecart._leftSideConnection[num] = 0;
			Minecart._rightSideConnection[num] = -1;
			Minecart._tileHeight[num][0] = 8;
			Minecart._tileHeight[num][1] = 7;
			Minecart._tileHeight[num][2] = 6;
			for (int b = 3; b < 8; b++)
			{
				Minecart._tileHeight[num][b] = -2;
			}
			Minecart._texturePosition[num] = new Vector2(6f, 2f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 0;
			Minecart._tileHeight[num][5] = 6;
			Minecart._tileHeight[num][6] = 7;
			Minecart._tileHeight[num][7] = 8;
			for (int c = 0; c < 5; c++)
			{
				Minecart._tileHeight[num][c] = -2;
			}
			Minecart._texturePosition[num] = new Vector2(7f, 2f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = 1;
			Minecart._trackType[num] = 2;
			Minecart._boostLeft[num] = false;
			Minecart._texturePosition[num] = new Vector2(2f, 3f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = 1;
			Minecart._trackType[num] = 2;
			Minecart._boostLeft[num] = true;
			Minecart._texturePosition[num] = new Vector2(3f, 3f);
			num++;
			Minecart._leftSideConnection[num] = 0;
			Minecart._rightSideConnection[num] = 2;
			for (int d = 0; d < 8; d++)
			{
				Minecart._tileHeight[num][d] = 8 - d;
			}
			Minecart._trackType[num] = 2;
			Minecart._boostLeft[num] = false;
			Minecart._texturePosition[num] = new Vector2(4f, 3f);
			num++;
			Minecart._leftSideConnection[num] = 2;
			Minecart._rightSideConnection[num] = 0;
			for (int e = 0; e < 8; e++)
			{
				Minecart._tileHeight[num][e] = e + 1;
			}
			Minecart._trackType[num] = 2;
			Minecart._boostLeft[num] = true;
			Minecart._texturePosition[num] = new Vector2(5f, 3f);
			num++;
			Minecart._leftSideConnection[num] = 0;
			Minecart._rightSideConnection[num] = 2;
			for (int f = 0; f < 8; f++)
			{
				Minecart._tileHeight[num][f] = 8 - f;
			}
			Minecart._trackType[num] = 2;
			Minecart._boostLeft[num] = true;
			Minecart._texturePosition[num] = new Vector2(6f, 3f);
			num++;
			Minecart._leftSideConnection[num] = 2;
			Minecart._rightSideConnection[num] = 0;
			for (int g = 0; g < 8; g++)
			{
				Minecart._tileHeight[num][g] = g + 1;
			}
			Minecart._trackType[num] = 2;
			Minecart._boostLeft[num] = false;
			Minecart._texturePosition[num] = new Vector2(7f, 3f);
			num++;
			Minecart._texturePosition[36] = new Vector2(0f, 6f);
			Minecart._texturePosition[37] = new Vector2(1f, 6f);
			Minecart._texturePosition[39] = new Vector2(0f, 7f);
			Minecart._texturePosition[38] = new Vector2(1f, 7f);
			for (int h = 0; h < (int)Minecart._texturePosition.Length; h++)
			{
				Minecart._texturePosition[h] = Minecart._texturePosition[h] * 18f;
			}
			for (int i1 = 0; i1 < (int)Minecart._tileHeight.Length; i1++)
			{
				int[] numArray1 = Minecart._tileHeight[i1];
				for (int j1 = 0; j1 < (int)numArray1.Length; j1++)
				{
					if (numArray1[j1] >= 0)
					{
						numArray1[j1] = (8 - numArray1[j1]) * 2;
					}
				}
			}
			int[] numArray2 = new int[36];
			Minecart._trackSwitchOptions = new int[64][];
			for (int k1 = 0; k1 < 64; k1++)
			{
				int num1 = 0;
				for (int l1 = 1; l1 < 256; l1 = l1 << 1)
				{
					if ((k1 & l1) == l1)
					{
						num1++;
					}
				}
				int num2 = 0;
				int num3 = 0;
				while (num3 < 36)
				{
					numArray2[num3] = -1;
					int num4 = 0;
					switch (Minecart._leftSideConnection[num3])
					{
						case -1:
						{
							switch (Minecart._rightSideConnection[num3])
							{
								case -1:
								{
									if (num1 < 2)
									{
										if (k1 == num4)
										{
											goto Label1;
										}
										goto Label0;
									}
									else if (num4 == 0 || (k1 & num4) != num4)
									{
										goto Label0;
									}
								Label1:
									numArray2[num3] = num3;
									num2++;
								Label0:
									num3++;
									continue;
								}
								case 0:
								{
									num4 = num4 | 8;
									goto case -1;
								}
								case 1:
								{
									num4 = num4 | 16;
									goto case -1;
								}
								case 2:
								{
									num4 = num4 | 32;
									goto case -1;
								}
								default:
								{
									goto case -1;
								}
							}
						}
						case 0:
						{
							num4 = num4 | 1;
							goto case -1;
						}
						case 1:
						{
							num4 = num4 | 2;
							goto case -1;
						}
						case 2:
						{
							num4 = num4 | 4;
							goto case -1;
						}
						default:
						{
							goto case -1;
						}
					}
				}
				if (num2 != 0)
				{
					int[] numArray3 = new int[num2];
					int num5 = 0;
					for (int m1 = 0; m1 < 36; m1++)
					{
						if (numArray2[m1] != -1)
						{
							numArray3[num5] = numArray2[m1];
							num5++;
						}
					}
					Minecart._trackSwitchOptions[k1] = numArray3;
				}
			}
			Minecart._firstPressureFrame = -1;
			Minecart._firstLeftBoostFrame = -1;
			Minecart._firstRightBoostFrame = -1;
			for (int n1 = 0; n1 < (int)Minecart._trackType.Length; n1++)
			{
				switch (Minecart._trackType[n1])
				{
					case 1:
					{
						if (Minecart._firstPressureFrame != -1)
						{
							break;
						}
						Minecart._firstPressureFrame = (short)n1;
						break;
					}
					case 2:
					{
						if (!Minecart._boostLeft[n1])
						{
							if (Minecart._firstRightBoostFrame != -1)
							{
								break;
							}
							Minecart._firstRightBoostFrame = (short)n1;
							break;
						}
						else
						{
							if (Minecart._firstLeftBoostFrame != -1)
							{
								break;
							}
							Minecart._firstLeftBoostFrame = (short)n1;
							break;
						}
					}
				}
			}
		}

		public static bool OnTrack(Vector2 Position, int Width, int Height)
		{
			Vector2 position = Position + new Vector2((float)(Width / 2) - 25f, (float)(Height / 2));
			Vector2 vector2 = position + Minecart._trackMagnetOffset;
			int x = (int)(vector2.X / 16f);
			int y = (int)(vector2.Y / 16f);
			return Main.tile[x, y].type == TileID.MinecartTrack;
		}

		public static void PlaceTrack(Tile trackCache, int style)
		{
			trackCache.active(true);
			trackCache.type = 314;
			trackCache.frameY = -1;
			switch (style)
			{
				case 0:
				{
					trackCache.frameX = -1;
					return;
				}
				case 1:
				{
					trackCache.frameX = Minecart._firstPressureFrame;
					return;
				}
				case 2:
				{
					trackCache.frameX = Minecart._firstLeftBoostFrame;
					return;
				}
				case 3:
				{
					trackCache.frameX = Minecart._firstRightBoostFrame;
					return;
				}
				default:
				{
					return;
				}
			}
		}

		public static BitsByte TrackCollision(ref Vector2 Position, ref Vector2 Velocity, ref Vector2 lastBoost, int Width, int Height, bool followDown, bool followUp, int fallStart, bool trackOnly)
		{
			int num;
			int num1;
			Matrix matrix;
			Minecart.TrackState trackState;
			if (followDown && followUp)
			{
				followDown = false;
				followUp = false;
			}
			Vector2 vector2 = new Vector2((float)(Width / 2) - 25f, (float)(Height / 2));
			Vector2 position = Position + new Vector2((float)(Width / 2) - 25f, (float)(Height / 2));
			Vector2 vector21 = position + Minecart._trackMagnetOffset;
			Vector2 velocity = Velocity;
			float x = velocity.Length();
			velocity.Normalize();
			Vector2 y = vector21;
			Tile tile = null;
			bool flag = false;
			bool flag1 = true;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			Minecart.TrackState trackState1 = Minecart.TrackState.NoTrack;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			Vector2 zero = Vector2.Zero;
			Vector2 zero1 = Vector2.Zero;
			BitsByte bitsByte = new BitsByte();
			while (true)
			{
				int x1 = (int)(y.X / 16f);
				int y1 = (int)(y.Y / 16f);
				int x2 = (int)y.X % 16 / 2;
				if (flag1)
				{
					num4 = x2;
				}
				bool flag6 = x2 != num4;
				if ((trackState1 == Minecart.TrackState.OnBack || trackState1 == Minecart.TrackState.OnTrack || trackState1 == Minecart.TrackState.OnFront) && x1 != num2)
				{
					num = (trackState1 != Minecart.TrackState.OnBack ? tile.FrontTrack() : tile.BackTrack());
					num1 = (velocity.X >= 0f ? Minecart._rightSideConnection[num] : Minecart._leftSideConnection[num]);
					switch (num1)
					{
						case 0:
						{
							y1--;
							y.Y = y.Y - 2f;
							break;
						}
						case 2:
						{
							y1++;
							y.Y = y.Y + 2f;
							break;
						}
					}
				}
				Minecart.TrackState trackState2 = Minecart.TrackState.NoTrack;
				bool flag7 = false;
				if (x1 != num2 || y1 != num3)
				{
					if (!flag1)
					{
						flag7 = true;
					}
					else
					{
						flag1 = false;
					}
					tile = Main.tile[x1, y1];
					if (tile == null)
					{
						tile = new Tile();
						Main.tile[x1, y1] = tile;
					}
					flag = (!tile.nactive() || tile.type != TileID.MinecartTrack ? false : true);
				}
				if (flag)
				{
					Minecart.TrackState trackState3 = Minecart.TrackState.NoTrack;
					int num5 = tile.FrontTrack();
					int num6 = tile.BackTrack();
					int num7 = Minecart._tileHeight[num5][x2];
					switch (num7)
					{
						case -4:
						{
							if (trackState1 != Minecart.TrackState.OnFront)
							{
								break;
							}
							if (!trackOnly)
							{
								trackState2 = Minecart.TrackState.NoTrack;
								flag4 = true;
								break;
							}
							else
							{
								y = y - zero1;
								x = 0f;
								trackState2 = Minecart.TrackState.OnFront;
								flag5 = true;
								break;
							}
						}
						case -3:
						{
							if (trackState1 != Minecart.TrackState.OnFront)
							{
								break;
							}
							trackState1 = Minecart.TrackState.NoTrack;
							if (Velocity.X <= 0f)
							{
								matrix = (Minecart._rightSideConnection[num5] != 2 ? Matrix.CreateRotationZ(-0.7853982f) : Matrix.CreateRotationZ(0.7853982f));
							}
							else
							{
								matrix = (Minecart._leftSideConnection[num5] != 2 ? Matrix.CreateRotationZ(0.7853982f) : Matrix.CreateRotationZ(-0.7853982f));
							}
							zero = Vector2.Transform(new Vector2(Velocity.X, 0f), matrix);
							zero.X = Velocity.X;
							flag3 = true;
							x = 0f;
							break;
						}
						case -2:
						{
							if (trackState1 != Minecart.TrackState.OnFront)
							{
								break;
							}
							if (!trackOnly)
							{
								if (velocity.X < 0f)
								{
									float single = (float)(x1 * 16 + (x2 + 1) * 2) - y.X;
									y.X = y.X + single;
									x = x + single / velocity.X;
								}
								velocity.X = -velocity.X;
								bitsByte[1] = true;
								trackState2 = Minecart.TrackState.OnFront;
								break;
							}
							else
							{
								y = y - zero1;
								x = 0f;
								trackState2 = Minecart.TrackState.OnFront;
								flag5 = true;
								break;
							}
						}
						case -1:
						{
							if (trackState1 != Minecart.TrackState.OnFront)
							{
								break;
							}
							y = y - zero1;
							x = 0f;
							trackState2 = Minecart.TrackState.OnFront;
							flag5 = true;
							break;
						}
						default:
						{
							float single1 = (float)(y1 * 16 + num7);
							if (x1 != num2 && trackState1 == Minecart.TrackState.NoTrack && y.Y > single1 && y.Y - single1 < 2f)
							{
								flag7 = false;
								trackState1 = Minecart.TrackState.AboveFront;
							}
							if (y.Y >= single1)
							{
								trackState = (y.Y <= single1 ? Minecart.TrackState.OnTrack : Minecart.TrackState.BelowTrack);
							}
							else
							{
								trackState = Minecart.TrackState.AboveTrack;
							}
							if (num6 != -1)
							{
								float single2 = (float)(y1 * 16 + Minecart._tileHeight[num6][x2]);
								if (y.Y >= single2)
								{
									trackState3 = (y.Y <= single2 ? Minecart.TrackState.OnTrack : Minecart.TrackState.BelowTrack);
								}
								else
								{
									trackState3 = Minecart.TrackState.AboveTrack;
								}
							}
							switch (trackState)
							{
								case Minecart.TrackState.AboveTrack:
								{
									switch (trackState3)
									{
										case Minecart.TrackState.AboveTrack:
										{
											trackState2 = Minecart.TrackState.AboveTrack;
											break;
										}
										case Minecart.TrackState.OnTrack:
										{
											trackState2 = Minecart.TrackState.OnBack;
											break;
										}
										case Minecart.TrackState.BelowTrack:
										{
											trackState2 = Minecart.TrackState.AboveFront;
											break;
										}
										default:
										{
											trackState2 = Minecart.TrackState.AboveFront;
											break;
										}
									}
									break;
								}
								case Minecart.TrackState.OnTrack:
								{
									trackState2 = (trackState3 != Minecart.TrackState.OnTrack ? Minecart.TrackState.OnFront : Minecart.TrackState.OnTrack);
									break;
								}
								case Minecart.TrackState.BelowTrack:
								{
									switch (trackState3)
									{
										case Minecart.TrackState.AboveTrack:
										{
											trackState2 = Minecart.TrackState.AboveBack;
											break;
										}
										case Minecart.TrackState.OnTrack:
										{
											trackState2 = Minecart.TrackState.OnBack;
											break;
										}
										case Minecart.TrackState.BelowTrack:
										{
											trackState2 = Minecart.TrackState.BelowTrack;
											break;
										}
										default:
										{
											trackState2 = Minecart.TrackState.BelowTrack;
											break;
										}
									}
									break;
								}
							}
							break;
						}
					}
				}
				if (!flag7)
				{
					if (trackState1 != trackState2)
					{
						if (flag6 || velocity.Y > 0f)
						{
							switch (trackState1)
							{
								case Minecart.TrackState.AboveTrack:
								{
									switch (trackState2)
									{
										case Minecart.TrackState.AboveTrack:
										{
											trackState2 = Minecart.TrackState.OnTrack;
											break;
										}
										case Minecart.TrackState.AboveFront:
										{
											trackState2 = Minecart.TrackState.OnBack;
											break;
										}
										case Minecart.TrackState.AboveBack:
										{
											trackState2 = Minecart.TrackState.OnFront;
											break;
										}
										default:
										{
											break;
										}
									}
									goto case Minecart.TrackState.BelowTrack;
								}
								case Minecart.TrackState.OnTrack:
								{
									int num8 = Minecart._tileHeight[tile.FrontTrack()][x2];
									int num9 = Minecart._tileHeight[tile.BackTrack()][x2];
									if (followDown)
									{
										trackState2 = (num8 >= num9 ? Minecart.TrackState.OnFront : Minecart.TrackState.OnBack);
									}
									else if (!followUp)
									{
										trackState2 = Minecart.TrackState.OnFront;
									}
									else
									{
										trackState2 = (num8 >= num9 ? Minecart.TrackState.OnBack : Minecart.TrackState.OnFront);
									}
									goto case Minecart.TrackState.BelowTrack;
								}
								case Minecart.TrackState.BelowTrack:
								{
									int num10 = -1;
									Minecart.TrackState trackState4 = trackState2;
									if (trackState4 != Minecart.TrackState.OnTrack)
									{
										switch (trackState4)
										{
											case Minecart.TrackState.OnFront:
											{
												break;
											}
											case Minecart.TrackState.OnBack:
											{
												num10 = tile.BackTrack();
												goto Label1;
											}
											default:
											{
												goto Label1;
											}
										}
									}
									num10 = tile.FrontTrack();
								Label1:
									if (num10 == -1)
									{
										break;
									}
									if (trackState1 == Minecart.TrackState.AboveFront && Minecart._trackType[num10] == 1)
									{
										flag2 = true;
									}
									velocity.Y = 0f;
									y.Y = (float)(y1 * 16 + Minecart._tileHeight[num10][x2]);
									break;
								}
								case Minecart.TrackState.AboveFront:
								{
									if (trackState2 != Minecart.TrackState.BelowTrack)
									{
										goto case Minecart.TrackState.BelowTrack;
									}
									trackState2 = Minecart.TrackState.OnFront;
									goto case Minecart.TrackState.BelowTrack;
								}
								case Minecart.TrackState.AboveBack:
								{
									if (trackState2 != Minecart.TrackState.BelowTrack)
									{
										goto case Minecart.TrackState.BelowTrack;
									}
									trackState2 = Minecart.TrackState.OnBack;
									goto case Minecart.TrackState.BelowTrack;
								}
								case Minecart.TrackState.OnFront:
								{
									trackState2 = Minecart.TrackState.OnFront;
									goto case Minecart.TrackState.BelowTrack;
								}
								case Minecart.TrackState.OnBack:
								{
									trackState2 = Minecart.TrackState.OnBack;
									goto case Minecart.TrackState.BelowTrack;
								}
								default:
								{
									goto case Minecart.TrackState.BelowTrack;
								}
							}
						}
					}
				}
				else if (trackState2 == Minecart.TrackState.OnFront || trackState2 == Minecart.TrackState.OnBack || trackState2 == Minecart.TrackState.OnTrack)
				{
					if (flag && Minecart._trackType[tile.FrontTrack()] == 1)
					{
						flag2 = true;
					}
					velocity.Y = 0f;
				}
				if (trackState2 == Minecart.TrackState.OnFront)
				{
					int num11 = tile.FrontTrack();
					if (Minecart._trackType[num11] == 2 && lastBoost.X == 0f && lastBoost.Y == 0f)
					{
						lastBoost = new Vector2((float)x1, (float)y1);
						if (!Minecart._boostLeft[num11])
						{
							bitsByte[5] = true;
						}
						else
						{
							bitsByte[4] = true;
						}
					}
				}
				num4 = x2;
				trackState1 = trackState2;
				num2 = x1;
				num3 = y1;
				if (x <= 0f)
				{
					if (lastBoost.X == (float)num2 && lastBoost.Y == (float)num3)
					{
						break;
					}
					lastBoost = Vector2.Zero;
					break;
				}
				else
				{
					float x3 = y.X % 2f;
					float y2 = y.Y % 2f;
					float single3 = 3f;
					float single4 = 3f;
					if (velocity.X < 0f)
					{
						single3 = x3 + 0.125f;
					}
					else if (velocity.X > 0f)
					{
						single3 = 2f - x3;
					}
					if (velocity.Y < 0f)
					{
						single4 = y2 + 0.125f;
					}
					else if (velocity.Y > 0f)
					{
						single4 = 2f - y2;
					}
					if (single3 == 3f && single4 == 3f)
					{
						break;
					}
					float single5 = Math.Abs(single3 / velocity.X);
					float single6 = Math.Abs(single4 / velocity.Y);
					float single7 = (single5 < single6 ? single5 : single6);
					if (single7 <= x)
					{
						zero1 = velocity * single7;
						x = x - single7;
					}
					else
					{
						zero1 = velocity * x;
						x = 0f;
					}
					y = y + zero1;
				}
			}
			if (flag2)
			{
				bitsByte[3] = true;
			}
			if (flag4)
			{
				Velocity.X = y.X - vector21.X;
				Velocity.Y = Player.defaultGravity;
			}
			else if (flag3)
			{
				bitsByte[2] = true;
				Velocity = zero;
			}
			else if (!bitsByte[1])
			{
				if (flag5)
				{
					Velocity.X = y.X - vector21.X;
				}
				if (velocity.Y == 0f)
				{
					Velocity.Y = 0f;
				}
			}
			else
			{
				Velocity.X = -Velocity.X;
				Position.X = y.X - Minecart._trackMagnetOffset.X - vector2.X - Velocity.X;
				if (velocity.Y == 0f)
				{
					Velocity.Y = 0f;
				}
			}
			Position.Y = Position.Y + (y.Y - vector21.Y - Velocity.Y);
			Position.Y = (float)Math.Round((double)Position.Y, 2);
			Minecart.TrackState trackState5 = trackState1;
			if (trackState5 != Minecart.TrackState.OnTrack)
			{
				switch (trackState5)
				{
					case Minecart.TrackState.OnFront:
					case Minecart.TrackState.OnBack:
					{
						break;
					}
					default:
					{
						return bitsByte;
					}
				}
			}
			bitsByte[0] = true;
			return bitsByte;
		}

		public static void TrackColors(int i, int j, Tile trackTile, out int frontColor, out int backColor)
		{
			int num;
			int num1;
			Tile tile;
			int num2;
			if (trackTile.type != 314)
			{
				frontColor = 0;
				backColor = 0;
			}
			else
			{
				frontColor = trackTile.color();
				backColor = frontColor;
				if (trackTile.frameY == -1)
				{
					return;
				}
				int num3 = Minecart._leftSideConnection[trackTile.frameX];
				int num4 = Minecart._rightSideConnection[trackTile.frameX];
				int num5 = Minecart._leftSideConnection[trackTile.frameY];
				int num6 = Minecart._rightSideConnection[trackTile.frameY];
				int num7 = 0;
				int num8 = 0;
				int num9 = 0;
				int num10 = 0;
				for (int i1 = 0; i1 < 4; i1++)
				{
					switch (i1)
					{
						case 1:
						{
							num = num4;
							break;
						}
						case 2:
						{
							num = num5;
							break;
						}
						case 3:
						{
							num = num6;
							break;
						}
						default:
						{
							num = num3;
							break;
						}
					}
					switch (num)
					{
						case 0:
						{
							num1 = -1;
							break;
						}
						case 1:
						{
							num1 = 0;
							break;
						}
						case 2:
						{
							num1 = 1;
							break;
						}
						default:
						{
							num1 = 0;
							break;
						}
					}
					tile = (i1 % 2 != 0 ? Main.tile[i + 1, j + num1] : Main.tile[i - 1, j + num1]);
					if (tile == null || !tile.active() || tile.type != TileID.MinecartTrack)
					{
						num2 = 0;
					}
					else
					{
						num2 = tile.color();
					}
					switch (i1)
					{
						case 1:
						{
							num8 = num2;
							break;
						}
						case 2:
						{
							num9 = num2;
							break;
						}
						case 3:
						{
							num10 = num2;
							break;
						}
						default:
						{
							num7 = num2;
							break;
						}
					}
				}
				if (num3 == num5)
				{
					if (num8 != 0)
					{
						frontColor = num8;
					}
					else if (num7 != 0)
					{
						frontColor = num7;
					}
					if (num10 != 0)
					{
						backColor = num10;
						return;
					}
					if (num9 != 0)
					{
						backColor = num9;
						return;
					}
				}
				else if (num4 != num6)
				{
					if (num8 == 0)
					{
						if (num7 != 0)
						{
							frontColor = num7;
						}
					}
					else if (num7 != 0)
					{
						frontColor = (num4 <= num3 ? num8 : num7);
					}
					if (num10 == 0)
					{
						if (num9 != 0)
						{
							backColor = num9;
							return;
						}
					}
					else if (num9 != 0)
					{
						backColor = (num6 <= num5 ? num10 : num9);
						return;
					}
				}
				else
				{
					if (num7 != 0)
					{
						frontColor = num7;
					}
					else if (num8 != 0)
					{
						frontColor = num8;
					}
					if (num9 != 0)
					{
						backColor = num9;
						return;
					}
					if (num10 != 0)
					{
						backColor = num10;
						return;
					}
				}
			}
		}

		public static float TrackRotation(ref float rotation, Vector2 Position, int Width, int Height, bool followDown, bool followUp)
		{
			Vector2 position = Position;
			Vector2 vector2 = Position;
			Vector2 zero = Vector2.Zero;
			Vector2 vector21 = new Vector2(-12f, 0f);
			Minecart.TrackCollision(ref position, ref vector21, ref zero, Width, Height, followDown, followUp, 0, true);
			position = position + vector21;
			vector21 = new Vector2(12f, 0f);
			Minecart.TrackCollision(ref vector2, ref vector21, ref zero, Width, Height, followDown, followUp, 0, true);
			vector2 = vector2 + vector21;
			float y = vector2.Y - position.Y;
			float x = vector2.X - position.X;
			float single = y / x;
			float y1 = position.Y + (Position.X - position.X) * single;
			float x1 = (Position.X - (float)((int)Position.X)) * single;
			rotation = (float)Math.Atan2((double)y, (double)x);
			return y1 - Position.Y + x1;
		}

		private enum TrackState
		{
			NoTrack = -1,
			AboveTrack = 0,
			OnTrack = 1,
			BelowTrack = 2,
			AboveFront = 3,
			AboveBack = 4,
			OnFront = 5,
			OnBack = 6
		}
	}
}
