using System;
using System.IO;
using System.Reflection;
using Terraria;
using Terraria.IO;
using Terraria.Social;
using Terraria.Utilities;

namespace Terraria.Map
{
	public class WorldMap
	{
		public readonly int MaxWidth;

		public readonly int MaxHeight;

		private MapTile[,] _tiles;

		public MapTile this[int x, int y]
		{
			get
			{
				return this._tiles[x, y];
			}
		}

		public WorldMap(int maxWidth, int maxHeight)
		{
			this.MaxWidth = maxWidth;
			this.MaxHeight = maxHeight;
			this._tiles = new MapTile[this.MaxWidth, this.MaxHeight];
		}

		public void Clear()
		{
			for (int i = 0; i < this.MaxWidth; i++)
			{
				for (int j = 0; j < this.MaxHeight; j++)
				{
					this._tiles[i, j].Clear();
				}
			}
		}

		public void ConsumeUpdate(int x, int y)
		{
			this._tiles[x, y].IsChanged = false;
		}

		public void Load()
		{
			if (!Main.mapEnabled)
			{
				return;
			}
			string str = Main.playerPathName.Substring(0, Main.playerPathName.Length - 4);
			object[] directorySeparatorChar = new object[] { str, Path.DirectorySeparatorChar, Main.worldID, ".map" };
			string str1 = string.Concat(directorySeparatorChar);
			if (!FileUtilities.Exists(str1))
			{
				Main.MapFileMetadata = FileMetadata.FromCurrentSettings(FileType.Map);
				return;
			}
			using (MemoryStream memoryStream = new MemoryStream(FileUtilities.ReadAllBytes(str1)))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					try
					{
						int num = binaryReader.ReadInt32();
						if (num <= Main.curRelease)
						{
							if (num > 91)
							{
								MapHelper.LoadMapVersion2(binaryReader, num);
							}
							else
							{
								MapHelper.LoadMapVersion1(binaryReader, num);
							}
							Main.clearMap = true;
							Main.loadMap = true;
							Main.loadMapLock = true;
							Main.refreshMap = false;
						}
						else
						{
							return;
						}
					}
					catch (Exception exception1)
					{
						Exception exception = exception1;
						using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", true))
						{
							streamWriter.WriteLine(DateTime.Now);
							streamWriter.WriteLine(exception);
							streamWriter.WriteLine("");
						}
						File.Copy(str1, string.Concat(str1, ".bad"), true);
						this.Clear();
					}
				}
			}
		}

		public void Save()
		{
			MapHelper.SaveMap();
		}

		public void SetTile(int x, int y, ref MapTile tile)
		{
			this._tiles[x, y] = tile;
		}

		public void UnlockMapSection(int sectionX, int sectionY)
		{
		}

		public void Update(int x, int y, byte light)
		{
			this._tiles[x, y] = MapHelper.CreateMapTile(x, y, light);
		}

		public bool UpdateLighting(int x, int y, byte light)
		{
			MapTile mapTile = this._tiles[x, y];
			MapTile mapTile1 = MapHelper.CreateMapTile(x, y, Math.Max(mapTile.Light, light));
			if (mapTile1.Equals(ref mapTile))
			{
				return false;
			}
			this._tiles[x, y] = mapTile1;
			return true;
		}

		public bool UpdateType(int x, int y)
		{
			MapTile mapTile = MapHelper.CreateMapTile(x, y, this._tiles[x, y].Light);
			if (mapTile.Equals(ref this._tiles[x, y]))
			{
				return false;
			}
			this._tiles[x, y] = mapTile;
			return true;
		}
	}
}