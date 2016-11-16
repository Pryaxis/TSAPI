using System;

namespace Terraria.Utilities
{
	public struct SlotId
	{
		public SlotId(uint value)
		{
			this.Value = value;
		}

		public override bool Equals(object obj)
		{
			return obj is SlotId && ((SlotId)obj).Value == this.Value;
		}

		public static SlotId FromFloat(float value)
		{
			return new SlotId(Utils.ReadFloatAsUInt(value));
		}

		public static bool operator ==(SlotId lhs, SlotId rhs)
		{
			return lhs.Value == rhs.Value;
		}

		public static bool operator !=(SlotId lhs, SlotId rhs)
		{
			return lhs.Value != rhs.Value;
		}

		internal SlotId ToActive(uint index)
		{
			uint num = 2147418112u & this.Key + 65536u;
			return new SlotId(2147483648u | num | index);
		}

		public float ToFloat()
		{
			return Utils.ReadUIntAsFloat(this.Value);
		}

		internal SlotId ToInactive(uint freeHead)
		{
			return new SlotId(this.Key | freeHead);
		}

		internal uint Index
		{
			get
			{
				return this.Value & 65535u;
			}
		}

		internal bool IsActive
		{
			get
			{
				return (this.Value & 2147483648u) != 0u && this.IsValid;
			}
		}

		public bool IsValid
		{
			get
			{
				return (this.Value & 65535u) != 65535u;
			}
		}

		internal uint Key
		{
			get
			{
				return this.Value & 2147418112u;
			}
		}

		private const uint KEY_INC = 65536u;

		private const uint INDEX_MASK = 65535u;

		private const uint ACTIVE_MASK = 2147483648u;

		private const uint KEY_MASK = 2147418112u;

		public static readonly SlotId Invalid = new SlotId(65535u);

		public readonly uint Value;
	}
}
