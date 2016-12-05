using System;

[Serializable]
public struct HalfVector2 : IPackedVector<uint>, IPackedVector, IEquatable<HalfVector2>
{
	public HalfVector2(Vector2 vector)
	{
		this.packedValue = HalfVector2.PackHelper(vector.X, vector.Y);
	}

	public HalfVector2(float x, float y)
	{
		this.packedValue = HalfVector2.PackHelper(x, y);
	}

	public override bool Equals(object obj)
	{
		return obj is HalfVector2 && this.Equals((HalfVector2)obj);
	}

	public bool Equals(HalfVector2 other)
	{
		return this.packedValue.Equals(other.packedValue);
	}

	public override int GetHashCode()
	{
		return this.packedValue.GetHashCode();
	}

	void IPackedVector.PackFromVector4(Vector4 vector)
	{
		this.packedValue = HalfVector2.PackHelper(vector.X, vector.Y);
	}

	Vector4 IPackedVector.ToVector4()
	{
		Vector2 vector = this.ToVector2();
		return new Vector4(vector.X, vector.Y, 0f, 1f);
	}

	public static bool operator ==(HalfVector2 a, HalfVector2 b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(HalfVector2 a, HalfVector2 b)
	{
		return !a.Equals(b);
	}

	private static uint PackHelper(float vectorX, float vectorY)
	{
		uint num = (uint)HalfUtils.Pack(vectorX);
		uint num2 = (uint)((uint)HalfUtils.Pack(vectorY) << 16);
		return num | num2;
	}

	public override string ToString()
	{
		return this.ToVector2().ToString();
	}

	public Vector2 ToVector2()
	{
		Vector2 result;
		result.X = HalfUtils.Unpack((ushort)this.packedValue);
		result.Y = HalfUtils.Unpack((ushort)(this.packedValue >> 16));
		return result;
	}

	public uint PackedValue
	{
		get { return this.packedValue; }
		set { this.packedValue = value; }
	}

	private uint packedValue;
}