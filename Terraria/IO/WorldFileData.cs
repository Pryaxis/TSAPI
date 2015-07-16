using System;
using Terraria;
using Terraria.Utilities;

namespace Terraria.IO
{
	public class WorldFileData : FileData
	{
		public DateTime CreationTime;

		public int WorldSizeX;

		public int WorldSizeY;

		public string _worldSizeName;

		public bool IsExpertMode;

		public bool HasCorruption = true;

		public bool IsHardMode;

		public bool HasCrimson
		{
			get
			{
				return !this.HasCorruption;
			}
			set
			{
				this.HasCorruption = !value;
			}
		}

		public string WorldSizeName
		{
			get
			{
				return this._worldSizeName;
			}
		}

		public WorldFileData() : base("World")
		{
		}

		public WorldFileData(string path, bool cloudSave) : base("World", path, cloudSave)
		{
		}

		public override void SetAsActive()
		{
			Main.ActiveWorldFileData = this;
		}

		public void SetWorldSize(int x, int y)
		{
			this.WorldSizeX = x;
			this.WorldSizeY = y;
			int num = x;
			if (num == 4200)
			{
				this._worldSizeName = "Small";
				return;
			}
			if (num == 6400)
			{
				this._worldSizeName = "Medium";
				return;
			}
			if (num == 8400)
			{
				this._worldSizeName = "Large";
				return;
			}
			this._worldSizeName = "Unknown";
		}
	}
}