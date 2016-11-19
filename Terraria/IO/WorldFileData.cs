using System;
using Terraria;
using Terraria.Localization;
using Terraria.Utilities;

namespace Terraria.IO
{
	public class WorldFileData : FileData
	{
		public DateTime CreationTime;

		public int WorldSizeX;

		public int WorldSizeY;

		public bool IsExpertMode;

		public bool HasCorruption = true;

		public bool IsHardMode;

		private const ulong GUID_IN_WORLD_FILE_VERSION = 777389080577uL;

		public Guid UniqueId;

		public ulong WorldGeneratorVersion;

		private int _seed;

		private string _seedText = "";

		public LocalizedText _worldSizeName;

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
				return this._worldSizeName.Value;
			}
		}

		public WorldFileData() : base("World")
		{
		}

		public WorldFileData(string path) : base("World", path)
		{
		}

		public override void SetAsActive()
		{
			Main.ActiveWorldFileData = this;
		}

		public void SetSeed(string seedText)
		{
			this._seedText = seedText;
			if (!int.TryParse(seedText, out this._seed))
			{
				this._seed = seedText.GetHashCode();
			}
			this._seed = Math.Abs(this._seed);
		}

		public void SetSeedToEmpty()
		{
			this.SetSeed("");
		}

		public void SetSeedToRandom()
		{
			this.SetSeed(new UnifiedRandom().Next().ToString());
		}

		public void SetWorldSize(int x, int y)
		{
			this.WorldSizeX = x;
			this.WorldSizeY = y;
			int num = x;
			if (num == 4200)
			{
				this._worldSizeName = Language.GetText("UI.WorldSizeSmall");
				return;
			}
			if (num == 6400)
			{
				this._worldSizeName = Language.GetText("UI.WorldSizeMedium");
				return;
			}
			if (num != 8400)
			{
				this._worldSizeName = Language.GetText("UI.WorldSizeUnknown");
				return;
			}
			this._worldSizeName = Language.GetText("UI.WorldSizeLarge");
		}

		public bool HasValidSeed
		{
			get
			{
				return this.WorldGeneratorVersion != 0uL;
			}
		}

		public int Seed
		{
			get
			{
				return this._seed;
			}
		}

		public string SeedText
		{
			get
			{
				return this._seedText;
			}
		}

		public bool UseGuidAsMapName
		{
			get
			{
				return this.WorldGeneratorVersion >= 777389080577uL;
			}
		}
	}
}