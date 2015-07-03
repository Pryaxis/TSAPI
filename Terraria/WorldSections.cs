using XNA;
using System;
using System.Diagnostics;

namespace Terraria
{
	public class WorldSections
	{
		private int width;

		private int height;

		private BitsByte[] data;

		private int mapSectionsLeft;

		private int frameSectionsLeft;

		private WorldSections.IterationState prevFrame;

		private WorldSections.IterationState prevMap;

		public int FrameSectionsLeft
		{
			get
			{
				return this.frameSectionsLeft;
			}
		}

		public int MapSectionsLeft
		{
			get
			{
				return this.mapSectionsLeft;
			}
		}

		public WorldSections(int numSectionsX, int numSectionsY)
		{
			this.width = numSectionsX;
			this.height = numSectionsY;
			this.data = new BitsByte[this.width * this.height];
			this.mapSectionsLeft = this.width * this.height;
			this.prevFrame.Reset();
			this.prevMap.Reset();
		}

		public void ClearMapDraw()
		{
			for (int i = 0; i < (int)this.data.Length; i++)
			{
				this.data[i][2] = false;
			}
			this.prevMap.Reset();
			this.mapSectionsLeft = (int)this.data.Length;
		}

		public bool GetNextMapDraw(Vector2 playerPos, out int x, out int y)
		{
			int num;
			if (this.mapSectionsLeft <= 0)
			{
				x = -1;
				y = -1;
				return false;
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int num1 = 0;
			int num2 = 0;
			Vector2 vector2 = this.prevMap.centerPos;
			playerPos = playerPos * 0.0625f;
			int sectionX = Netplay.GetSectionX((int)playerPos.X);
			int sectionY = Netplay.GetSectionY((int)playerPos.Y);
			int sectionX1 = Netplay.GetSectionX((int)vector2.X);
			int sectionY1 = Netplay.GetSectionY((int)vector2.Y);
			if (sectionX1 != sectionX || sectionY1 != sectionY)
			{
				vector2 = playerPos;
				sectionX1 = sectionX;
				sectionY1 = sectionY;
				num = 4;
				x = sectionX;
				y = sectionY;
			}
			else
			{
				num = this.prevMap.leg;
				x = this.prevMap.X;
				y = this.prevMap.Y;
				num1 = this.prevMap.xDir;
				num2 = this.prevMap.yDir;
			}
			int num3 = (int)(playerPos.X - ((float)sectionX1 + 0.5f) * 200f);
			int num4 = (int)(playerPos.Y - ((float)sectionY1 + 0.5f) * 150f);
			if (num1 == 0)
			{
				num1 = (num3 <= 0 ? 1 : -1);
				num2 = (num4 <= 0 ? 1 : -1);
			}
			int num5 = 0;
			bool flag = false;
			bool flag1 = false;
			while (true)
			{
				if (num5 == 4)
				{
					if (flag1)
					{
						throw new Exception("Infinite loop in WorldSections.GetNextMapDraw");
					}
					flag1 = true;
					x = sectionX1;
					y = sectionY1;
					num3 = (int)(vector2.X - ((float)sectionX1 + 0.5f) * 200f);
					num4 = (int)(vector2.Y - ((float)sectionY1 + 0.5f) * 150f);
					num1 = (num3 <= 0 ? 1 : -1);
					num2 = (num4 <= 0 ? 1 : -1);
					num = 4;
					num5 = 0;
				}
				if (y >= 0 && y < this.height && x >= 0 && x < this.width)
				{
					flag = false;
					if (!this.data[y * this.width + x][2])
					{
						break;
					}
				}
				int num6 = x - sectionX1;
				int num7 = y - sectionY1;
				if (num6 == 0 || num7 == 0)
				{
					if (num != 4)
					{
						if (num6 != 0)
						{
							num1 = (num6 <= 0 ? 1 : -1);
						}
						else
						{
							num2 = (num7 <= 0 ? 1 : -1);
						}
						x = x + num1;
						y = y + num2;
						num++;
					}
					else
					{
						if (num6 != 0 || num7 != 0)
						{
							if (num6 != 0)
							{
								x = x + num6 / Math.Abs(num6);
							}
							if (num7 != 0)
							{
								y = y + num7 / Math.Abs(num7);
							}
						}
						else if (Math.Abs(num3) <= Math.Abs(num4))
						{
							x = x - num1;
						}
						else
						{
							y = y - num2;
						}
						num = 0;
						num5 = -2;
						flag = true;
					}
					if (!flag)
					{
						flag = true;
					}
					else
					{
						num5++;
					}
				}
				else
				{
					x = x + num1;
					y = y + num2;
				}
			}
			this.data[y * this.width + x][2] = true;
			WorldSections worldSection = this;
			worldSection.mapSectionsLeft = worldSection.mapSectionsLeft - 1;
			this.prevMap.centerPos = playerPos;
			this.prevMap.X = x;
			this.prevMap.Y = y;
			this.prevMap.leg = num;
			this.prevMap.xDir = num1;
			this.prevMap.yDir = num2;
			stopwatch.Stop();
			return true;
		}

		public bool GetNextTileFrame(Vector2 playerPos, out int x, out int y)
		{
			int num;
			if (this.frameSectionsLeft <= 0)
			{
				x = -1;
				y = -1;
				return false;
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int num1 = 0;
			int num2 = 0;
			Vector2 vector2 = this.prevFrame.centerPos;
			playerPos = playerPos * 0.0625f;
			int sectionX = Netplay.GetSectionX((int)playerPos.X);
			int sectionY = Netplay.GetSectionY((int)playerPos.Y);
			int sectionX1 = Netplay.GetSectionX((int)vector2.X);
			int sectionY1 = Netplay.GetSectionY((int)vector2.Y);
			if (sectionX1 != sectionX || sectionY1 != sectionY)
			{
				vector2 = playerPos;
				sectionX1 = sectionX;
				sectionY1 = sectionY;
				num = 4;
				x = sectionX;
				y = sectionY;
			}
			else
			{
				num = this.prevFrame.leg;
				x = this.prevFrame.X;
				y = this.prevFrame.Y;
				num1 = this.prevFrame.xDir;
				num2 = this.prevFrame.yDir;
			}
			int num3 = (int)(playerPos.X - ((float)sectionX1 + 0.5f) * 200f);
			int num4 = (int)(playerPos.Y - ((float)sectionY1 + 0.5f) * 150f);
			if (num1 == 0)
			{
				num1 = (num3 <= 0 ? 1 : -1);
				num2 = (num4 <= 0 ? 1 : -1);
			}
			int num5 = 0;
			bool flag = false;
			bool flag1 = false;
			while (true)
			{
				if (num5 == 4)
				{
					if (flag1)
					{
						throw new Exception("Infinite loop in WorldSections.GetNextTileFrame");
					}
					flag1 = true;
					x = sectionX1;
					y = sectionY1;
					num3 = (int)(vector2.X - ((float)sectionX1 + 0.5f) * 200f);
					num4 = (int)(vector2.Y - ((float)sectionY1 + 0.5f) * 150f);
					num1 = (num3 <= 0 ? 1 : -1);
					num2 = (num4 <= 0 ? 1 : -1);
					num = 4;
					num5 = 0;
				}
				if (y >= 0 && y < this.height && x >= 0 && x < this.width)
				{
					flag = false;
					if (this.data[y * this.width + x][0] && !this.data[y * this.width + x][1])
					{
						break;
					}
				}
				int num6 = x - sectionX1;
				int num7 = y - sectionY1;
				if (num6 == 0 || num7 == 0)
				{
					if (num != 4)
					{
						if (num6 != 0)
						{
							num1 = (num6 <= 0 ? 1 : -1);
						}
						else
						{
							num2 = (num7 <= 0 ? 1 : -1);
						}
						x = x + num1;
						y = y + num2;
						num++;
					}
					else
					{
						if (num6 != 0 || num7 != 0)
						{
							if (num6 != 0)
							{
								x = x + num6 / Math.Abs(num6);
							}
							if (num7 != 0)
							{
								y = y + num7 / Math.Abs(num7);
							}
						}
						else if (Math.Abs(num3) <= Math.Abs(num4))
						{
							x = x - num1;
						}
						else
						{
							y = y - num2;
						}
						num = 0;
						num5 = 0;
						flag = true;
					}
					if (!flag)
					{
						flag = true;
					}
					else
					{
						num5++;
					}
				}
				else
				{
					x = x + num1;
					y = y + num2;
				}
			}
			this.data[y * this.width + x][1] = true;
			WorldSections worldSection = this;
			worldSection.frameSectionsLeft = worldSection.frameSectionsLeft - 1;
			this.prevFrame.centerPos = playerPos;
			this.prevFrame.X = x;
			this.prevFrame.Y = y;
			this.prevFrame.leg = num;
			this.prevFrame.xDir = num1;
			this.prevFrame.yDir = num2;
			stopwatch.Stop();
			return true;
		}

		public bool MapSectionDrawn(int x, int y)
		{
			if (x < 0 || x >= this.width)
			{
				return false;
			}
			if (y < 0 || y >= this.height)
			{
				return false;
			}
			return this.data[y * this.width + x][2];
		}

		public void MapSectionDrawn(int x, int y, bool value)
		{
			if (x < 0 || x >= this.width)
			{
				return;
			}
			if (y < 0 || y >= this.height)
			{
				return;
			}
			if (this.data[y * this.width + x][1] != value)
			{
				if (!value)
				{
					WorldSections worldSection = this;
					worldSection.mapSectionsLeft = worldSection.mapSectionsLeft - 1;
				}
				else
				{
					WorldSections worldSection1 = this;
					worldSection1.mapSectionsLeft = worldSection1.mapSectionsLeft + 1;
				}
			}
			this.data[y * this.width + x][2] = value;
		}

		public bool SectionFramed(int x, int y)
		{
			if (x < 0 || x >= this.width)
			{
				return false;
			}
			if (y < 0 || y >= this.height)
			{
				return false;
			}
			return this.data[y * this.width + x][1];
		}

		public void SectionFramed(int x, int y, bool value)
		{
			if (x < 0 || x >= this.width)
			{
				return;
			}
			if (y < 0 || y >= this.height)
			{
				return;
			}
			if (this.data[y * this.width + x][1] != value)
			{
				if (!value)
				{
					WorldSections worldSection = this;
					worldSection.frameSectionsLeft = worldSection.frameSectionsLeft - 1;
				}
				else
				{
					WorldSections worldSection1 = this;
					worldSection1.frameSectionsLeft = worldSection1.frameSectionsLeft + 1;
				}
			}
			this.data[y * this.width + x][1] = value;
		}

		public bool SectionLoaded(int x, int y)
		{
			if (x < 0 || x >= this.width)
			{
				return false;
			}
			if (y < 0 || y >= this.height)
			{
				return false;
			}
			return this.data[y * this.width + x][0];
		}

		public void SectionLoaded(int x, int y, bool value)
		{
			if (x < 0 || x >= this.width)
			{
				return;
			}
			if (y < 0 || y >= this.height)
			{
				return;
			}
			this.data[y * this.width + x][0] = value;
		}

		public void SetAllFramesLoaded()
		{
			for (int i = 0; i < (int)this.data.Length; i++)
			{
				if (!this.data[i][0])
				{
					this.data[i][0] = true;
					WorldSections worldSection = this;
					worldSection.frameSectionsLeft = worldSection.frameSectionsLeft + 1;
				}
			}
		}

		public void SetSectionFramed(int x, int y)
		{
			if (x < 0 || x >= this.width)
			{
				return;
			}
			if (y < 0 || y >= this.height)
			{
				return;
			}
			if (!this.data[y * this.width + x][1])
			{
				this.data[y * this.width + x][1] = true;
				WorldSections worldSection = this;
				worldSection.frameSectionsLeft = worldSection.frameSectionsLeft - 1;
			}
		}

		public void SetSectionLoaded(int x, int y)
		{
			if (x < 0 || x >= this.width)
			{
				return;
			}
			if (y < 0 || y >= this.height)
			{
				return;
			}
			if (!this.data[y * this.width + x][0])
			{
				this.data[y * this.width + x][0] = true;
				WorldSections worldSection = this;
				worldSection.frameSectionsLeft = worldSection.frameSectionsLeft + 1;
			}
		}

		private struct IterationState
		{
			public Vector2 centerPos;

			public int X;

			public int Y;

			public int leg;

			public int xDir;

			public int yDir;

			public void Reset()
			{
				this.centerPos = new Vector2(-3200f, -2400f);
				this.X = 0;
				this.Y = 0;
				this.leg = 0;
				this.xDir = 0;
				this.yDir = 0;
			}
		}
	}
}