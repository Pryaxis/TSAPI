using System;
using System.Runtime.CompilerServices;

namespace Extensions
{
	public static class EnumerationExtensions
	{
		public static bool Has<T>(this Enum value, T check)
		{
			Type type = value.GetType();
			EnumerationExtensions._Value __Value = new EnumerationExtensions._Value((object)check, type);
			if (__Value.Signed.HasValue)
			{
				return (Convert.ToInt64(value) & __Value.Signed.Value) == __Value.Signed.Value;
			}
			if (!__Value.Unsigned.HasValue)
			{
				return false;
			}
			return (Convert.ToUInt64(value) & __Value.Unsigned.Value) == __Value.Unsigned.Value;
		}

		public static T Include<T>(this Enum value, T append)
		{
			Type type = value.GetType();
			object num = value;
			EnumerationExtensions._Value __Value = new EnumerationExtensions._Value((object)append, type);
			if (__Value.Signed.HasValue)
			{
				num = Convert.ToInt64(value) | __Value.Signed.Value;
			}
			else if (__Value.Unsigned.HasValue)
			{
				num = Convert.ToUInt64(value) | __Value.Unsigned.Value;
			}
			return (T)Enum.Parse(type, num.ToString());
		}

		public static bool Missing<T>(this Enum obj, T value)
		{
			return !obj.Has<T>(value);
		}

		public static T Remove<T>(this Enum value, T remove)
		{
			Type type = value.GetType();
			object num = value;
			EnumerationExtensions._Value __Value = new EnumerationExtensions._Value((object)remove, type);
			if (__Value.Signed.HasValue)
			{
				num = Convert.ToInt64(value) & ~__Value.Signed.Value;
			}
			else if (__Value.Unsigned.HasValue)
			{
				num = Convert.ToUInt64(value) & ~__Value.Unsigned.Value;
			}
			return (T)Enum.Parse(type, num.ToString());
		}

		private class _Value
		{
			private static Type _UInt64;

			private static Type _UInt32;

			public long? Signed;

			public ulong? Unsigned;

			static _Value()
			{
				EnumerationExtensions._Value._UInt64 = typeof(ulong);
				EnumerationExtensions._Value._UInt32 = typeof(long);
			}

			public _Value(object value, Type type)
			{
				if (!type.IsEnum)
				{
					throw new ArgumentException("Value provided is not an enumerated type!");
				}
				Type underlyingType = Enum.GetUnderlyingType(type);
				if (!underlyingType.Equals(EnumerationExtensions._Value._UInt32) && !underlyingType.Equals(EnumerationExtensions._Value._UInt64))
				{
					this.Signed = new long?(Convert.ToInt64(value));
					return;
				}
				this.Unsigned = new ulong?(Convert.ToUInt64(value));
			}
		}
	}
}