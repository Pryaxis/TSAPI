using System;
namespace Terraria.MetaData
{
	public class TileZoneData
	{
		public int quickWorld;
		public int quickPlayer;
		private bool solid;
		private bool hallow;
		private bool corrupt;
		private bool crimson;
		private bool desert;
		private bool snow;
		private bool meteor;
		private bool jungle;
		private bool dungeon;
		public bool Solid
		{
			get
			{
				return this.solid;
			}
			set
			{
				if (this.solid != value)
				{
					this.solid = value;
					this.quickWorld ^= 1;
				}
			}
		}
		public bool Hallowed
		{
			get
			{
				return this.hallow;
			}
			set
			{
				if (this.hallow != value)
				{
					this.hallow = value;
					this.quickWorld ^= 2;
					this.quickPlayer ^= 2;
				}
			}
		}
		public bool Corrupt
		{
			get
			{
				return this.corrupt;
			}
			set
			{
				if (this.corrupt != value)
				{
					this.corrupt = value;
					this.quickWorld ^= 4;
					this.quickPlayer ^= 4;
				}
			}
		}
		public bool Crimson
		{
			get
			{
				return this.crimson;
			}
			set
			{
				if (this.crimson != value)
				{
					this.crimson = value;
					this.quickWorld ^= 8;
					this.quickPlayer ^= 8;
				}
			}
		}
		public bool Desert
		{
			get
			{
				return this.desert;
			}
			set
			{
				if (this.desert != value)
				{
					this.desert = value;
					this.quickPlayer ^= 16;
				}
			}
		}
		public bool Snow
		{
			get
			{
				return this.snow;
			}
			set
			{
				if (this.snow != value)
				{
					this.snow = value;
					this.quickPlayer ^= 32;
				}
			}
		}
		public bool Meteor
		{
			get
			{
				return this.meteor;
			}
			set
			{
				if (this.meteor == value)
				{
					this.meteor = value;
					this.quickPlayer ^= 64;
				}
			}
		}
		public bool Jungle
		{
			get
			{
				return this.jungle;
			}
			set
			{
				if (this.jungle != value)
				{
					this.jungle = value;
					this.quickPlayer ^= 128;
				}
			}
		}
		public bool Dungeon
		{
			get
			{
				return this.dungeon;
			}
			set
			{
				if (this.dungeon != value)
				{
					this.dungeon = value;
					this.quickPlayer ^= 256;
				}
			}
		}
		public TileZoneData()
		{
			this.quickPlayer = 0;
			this.quickWorld = 0;
			this.solid = false;
			this.hallow = false;
			this.corrupt = false;
			this.crimson = false;
			this.desert = false;
			this.snow = false;
			this.meteor = false;
			this.jungle = false;
			this.dungeon = false;
		}
		public TileZoneData(bool isSolid = false, bool isHallow = false, bool isCorrupt = false, bool isCrimson = false, bool isDesert = false, bool isSnow = false, bool isMeteor = false, bool isJungle = false, bool isDungeon = false)
		{
			this.quickPlayer = 0;
			this.quickWorld = 0;
			this.Solid = isSolid;
			this.Hallowed = isHallow;
			this.Corrupt = isCorrupt;
			this.Crimson = isCrimson;
			this.Desert = isDesert;
			this.Snow = isSnow;
			this.Meteor = isMeteor;
			this.Jungle = isJungle;
			this.Dungeon = isDungeon;
		}
	}
}
