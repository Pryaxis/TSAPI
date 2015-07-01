using System;
using Terraria.Enums;

namespace Terraria.DataStructures
{
	public struct AnchorData
	{
		public AnchorType type;

		public int tileCount;

		public int checkStart;

		public static AnchorData Empty;

		static AnchorData()
		{
			AnchorData.Empty = new AnchorData();
		}

		public AnchorData(AnchorType type, int count, int start)
		{
			this.type = type;
			this.tileCount = count;
			this.checkStart = start;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is AnchorData))
			{
				return false;
			}
			if (this.type != ((AnchorData)obj).type || this.tileCount != ((AnchorData)obj).tileCount)
			{
				return false;
			}
			return this.checkStart == ((AnchorData)obj).checkStart;
		}

		public override int GetHashCode()
		{
			byte num = (byte)this.checkStart;
			byte num1 = (byte)this.tileCount;
			ushort num2 = (ushort)this.type;
			return num2 << 16 | num1 << 8 | num;
		}

		public static bool operator ==(AnchorData data1, AnchorData data2)
		{
			if (data1.type != data2.type || data1.tileCount != data2.tileCount)
			{
				return false;
			}
			return data1.checkStart == data2.checkStart;
		}

		public static bool operator !=(AnchorData data1, AnchorData data2)
		{
			if (data1.type != data2.type || data1.tileCount != data2.tileCount)
			{
				return true;
			}
			return data1.checkStart != data2.checkStart;
		}
	}
}