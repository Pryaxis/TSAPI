using System;
using System.Globalization;

[Serializable]
public struct Vector3 : IEquatable<Vector3>
{
	public float X;
	public float Y;
	public float Z;
	private static Vector3 _zero;
	private static Vector3 _one;
	private static Vector3 _unitX;
	private static Vector3 _unitY;
	private static Vector3 _unitZ;
	public static Vector3 Zero
	{
		get
		{
			return Vector3._zero;
		}
	}
	public static Vector3 One
	{
		get
		{
			return Vector3._one;
		}
	}
	public static Vector3 UnitX
	{
		get
		{
			return Vector3._unitX;
		}
	}
	public static Vector3 UnitY
	{
		get
		{
			return Vector3._unitY;
		}
	}
	public static Vector3 UnitZ
	{
		get
		{
			return Vector3._unitZ;
		}
	}

	public Vector3(float x, float y, float z)
	{
		this.X = x;
		this.Y = y;
		this.Z = z;
	}
	public Vector3(Vector2 value, float z)
	{
		this.X = value.X;
		this.Y = value.Y;
		this.Z = z;
	}
	public Vector3(float value)
	{
		this.Z = value;
		this.Y = value;
		this.X = value;
	}
	public override string ToString()
	{
		CultureInfo currentCulture = CultureInfo.CurrentCulture;
		return string.Format(currentCulture, "{{X:{0} Y:{1} Z:{2}}}", new object[]
		{
			this.X.ToString(currentCulture), 
			this.Y.ToString(currentCulture), 
			this.Z.ToString(currentCulture), 
		});
	}
	public bool Equals(Vector3 other)
	{
		return this.X == other.X && this.Y == other.Y && this.Z == other.Z;
	}
	public override bool Equals(object obj)
	{
		bool result = false;
		if (obj is Vector3)
		{
			result = this.Equals((Vector3)obj);
		}
		return result;
	}
	public override int GetHashCode()
	{
		return this.X.GetHashCode() + this.Y.GetHashCode() + this.Z.GetHashCode();
	}
	public float Length()
	{
		float num = this.X * this.X + this.Y * this.Y + this.Z * this.Z;
		return (float)Math.Sqrt((double)num);
	}
	public float LengthSquared()
	{
		return this.X * this.X + this.Y * this.Y + this.Z * this.Z;
	}
	public static float Distance(Vector3 value1, Vector3 value2)
	{
		float num = value1.X - value2.X;
		float num2 = value1.Y - value2.Y;
		float num3 = value1.Z - value2.Z;
		float num5 = num * num + num2 * num2 + num3 * num3;
		return (float)Math.Sqrt((double)num5);
	}
	public static void Distance(ref Vector3 value1, ref Vector3 value2, out float result)
	{
		float num = value1.X - value2.X;
		float num2 = value1.Y - value2.Y;
		float num3 = value1.Z - value2.Z;
		float num5 = num * num + num2 * num2 + num3 * num3;
		result = (float)Math.Sqrt((double)num5);
	}
	public static float DistanceSquared(Vector3 value1, Vector3 value2)
	{
		float num = value1.X - value2.X;
		float num2 = value1.Y - value2.Y;
		float num3 = value1.Z - value2.Z;
		return num * num + num2 * num2 + num3 * num3;
	}
	public static void DistanceSquared(ref Vector3 value1, ref Vector3 value2, out float result)
	{
		float num = value1.X - value2.X;
		float num2 = value1.Y - value2.Y;
		float num3 = value1.Z - value2.Z;
		result = num * num + num2 * num2 + num3 * num3;
	}
	public static float Dot(Vector3 vector1, Vector3 vector2)
	{
		return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
	}
	public static void Dot(ref Vector3 vector1, ref Vector3 vector2, out float result)
	{
		result = vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
	}
	public void Normalize()
	{
		float num = this.X * this.X + this.Y * this.Y + this.Z * this.Z;
		float num2 = 1f / (float)Math.Sqrt((double)num);
		this.X *= num2;
		this.Y *= num2;
		this.Z *= num2;
	}
	public static Vector3 Normalize(Vector3 vector)
	{
		float num = vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z;
		float num2 = 1f / (float)Math.Sqrt((double)num);
		Vector3 result;
		result.X = vector.X * num2;
		result.Y = vector.Y * num2;
		result.Z = vector.Z * num2;
		return result;
	}
	public static void Normalize(ref Vector3 vector, out Vector3 result)
	{
		float num = vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z;
		float num2 = 1f / (float)Math.Sqrt((double)num);
		result.X = vector.X * num2;
		result.Y = vector.Y * num2;
		result.Z = vector.Z * num2;
	}
	public static Vector3 Min(Vector3 value1, Vector3 value2)
	{
		Vector3 result;
		result.X = ((value1.X < value2.X) ? value1.X : value2.X);
		result.Y = ((value1.Y < value2.Y) ? value1.Y : value2.Y);
		result.Z = ((value1.Z < value2.Z) ? value1.Z : value2.Z);
		return result;
	}
	public static void Min(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
	{
		result.X = ((value1.X < value2.X) ? value1.X : value2.X);
		result.Y = ((value1.Y < value2.Y) ? value1.Y : value2.Y);
		result.Z = ((value1.Z < value2.Z) ? value1.Z : value2.Z);
	}
	public static Vector3 Max(Vector3 value1, Vector3 value2)
	{
		Vector3 result;
		result.X = ((value1.X > value2.X) ? value1.X : value2.X);
		result.Y = ((value1.Y > value2.Y) ? value1.Y : value2.Y);
		result.Z = ((value1.Z > value2.Z) ? value1.Z : value2.Z);
		return result;
	}
	public static void Max(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
	{
		result.X = ((value1.X > value2.X) ? value1.X : value2.X);
		result.Y = ((value1.Y > value2.Y) ? value1.Y : value2.Y);
		result.Z = ((value1.Z > value2.Z) ? value1.Z : value2.Z);
	}
	public static Vector3 Clamp(Vector3 value1, Vector3 min, Vector3 max)
	{
		float num = value1.X;
		num = ((num > max.X) ? max.X : num);
		num = ((num < min.X) ? min.X : num);
		float num2 = value1.Y;
		num2 = ((num2 > max.Y) ? max.Y : num2);
		num2 = ((num2 < min.Y) ? min.Y : num2);
		float num3 = value1.Z;
		num3 = ((num3 > max.Z) ? max.Z : num3);
		num3 = ((num3 < min.Z) ? min.Z : num3);
		Vector3 result;
		result.X = num;
		result.Y = num2;
		result.Z = num3;
		return result;
	}
	public static void Clamp(ref Vector3 value1, ref Vector3 min, ref Vector3 max, out Vector3 result)
	{
		float num = value1.X;
		num = ((num > max.X) ? max.X : num);
		num = ((num < min.X) ? min.X : num);
		float num2 = value1.Y;
		num2 = ((num2 > max.Y) ? max.Y : num2);
		num2 = ((num2 < min.Y) ? min.Y : num2);
		float num3 = value1.Z;
		num3 = ((num3 > max.Z) ? max.Z : num3);
		num3 = ((num3 < min.Z) ? min.Z : num3);
		result.X = num;
		result.Y = num2;
		result.Z = num3;
	}
	public static Vector3 Lerp(Vector3 value1, Vector3 value2, float amount)
	{
		Vector3 result;
		result.X = value1.X + (value2.X - value1.X) * amount;
		result.Y = value1.Y + (value2.Y - value1.Y) * amount;
		result.Z = value1.Z + (value2.Z - value1.Z) * amount;
		return result;
	}
	public static void Lerp(ref Vector3 value1, ref Vector3 value2, float amount, out Vector3 result)
	{
		result.X = value1.X + (value2.X - value1.X) * amount;
		result.Y = value1.Y + (value2.Y - value1.Y) * amount;
		result.Z = value1.Z + (value2.Z - value1.Z) * amount;
	}
	public static Vector3 Barycentric(Vector3 value1, Vector3 value2, Vector3 value3, float amount1, float amount2)
	{
		Vector3 result;
		result.X = value1.X + amount1 * (value2.X - value1.X) + amount2 * (value3.X - value1.X);
		result.Y = value1.Y + amount1 * (value2.Y - value1.Y) + amount2 * (value3.Y - value1.Y);
		result.Z = value1.Z + amount1 * (value2.Z - value1.Z) + amount2 * (value3.Z - value1.Z);
		return result;
	}
	public static void Barycentric(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, float amount1, float amount2, out Vector3 result)
	{
		result.X = value1.X + amount1 * (value2.X - value1.X) + amount2 * (value3.X - value1.X);
		result.Y = value1.Y + amount1 * (value2.Y - value1.Y) + amount2 * (value3.Y - value1.Y);
		result.Z = value1.Z + amount1 * (value2.Z - value1.Z) + amount2 * (value3.Z - value1.Z);
	}
	public static Vector3 SmoothStep(Vector3 value1, Vector3 value2, float amount)
	{
		amount = ((amount > 1f) ? 1f : ((amount < 0f) ? 0f : amount));
		amount = amount * amount * (3f - 2f * amount);
		Vector3 result;
		result.X = value1.X + (value2.X - value1.X) * amount;
		result.Y = value1.Y + (value2.Y - value1.Y) * amount;
		result.Z = value1.Z + (value2.Z - value1.Z) * amount;
		return result;
	}
	public static void SmoothStep(ref Vector3 value1, ref Vector3 value2, float amount, out Vector3 result)
	{
		amount = ((amount > 1f) ? 1f : ((amount < 0f) ? 0f : amount));
		amount = amount * amount * (3f - 2f * amount);
		result.X = value1.X + (value2.X - value1.X) * amount;
		result.Y = value1.Y + (value2.Y - value1.Y) * amount;
		result.Z = value1.Z + (value2.Z - value1.Z) * amount;
	}
	public static Vector3 CatmullRom(Vector3 value1, Vector3 value2, Vector3 value3, Vector3 value4, float amount)
	{
		float num = amount * amount;
		float num2 = amount * num;
		Vector3 result;
		result.X = 0.5f * (2f * value2.X + (-value1.X + value3.X) * amount + (2f * value1.X - 5f * value2.X + 4f * value3.X - value4.X) * num + (-value1.X + 3f * value2.X - 3f * value3.X + value4.X) * num2);
		result.Y = 0.5f * (2f * value2.Y + (-value1.Y + value3.Y) * amount + (2f * value1.Y - 5f * value2.Y + 4f * value3.Y - value4.Y) * num + (-value1.Y + 3f * value2.Y - 3f * value3.Y + value4.Y) * num2);
		result.Z = 0.5f * (2f * value2.Z + (-value1.Z + value3.Z) * amount + (2f * value1.Z - 5f * value2.Z + 4f * value3.Z - value4.Z) * num + (-value1.Z + 3f * value2.Z - 3f * value3.Z + value4.Z) * num2);
		return result;
	}
	public static void CatmullRom(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, ref Vector3 value4, float amount, out Vector3 result)
	{
		float num = amount * amount;
		float num2 = amount * num;
		result.X = 0.5f * (2f * value2.X + (-value1.X + value3.X) * amount + (2f * value1.X - 5f * value2.X + 4f * value3.X - value4.X) * num + (-value1.X + 3f * value2.X - 3f * value3.X + value4.X) * num2);
		result.Y = 0.5f * (2f * value2.Y + (-value1.Y + value3.Y) * amount + (2f * value1.Y - 5f * value2.Y + 4f * value3.Y - value4.Y) * num + (-value1.Y + 3f * value2.Y - 3f * value3.Y + value4.Y) * num2);
		result.Z = 0.5f * (2f * value2.Z + (-value1.Z + value3.Z) * amount + (2f * value1.Z - 5f * value2.Z + 4f * value3.Z - value4.Z) * num + (-value1.Z + 3f * value2.Z - 3f * value3.Z + value4.Z) * num2);
	}
	public static Vector3 Hermite(Vector3 value1, Vector3 tangent1, Vector3 value2, Vector3 tangent2, float amount)
	{
		float num = amount * amount;
		float num2 = amount * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + amount;
		float num6 = num2 - num;
		Vector3 result;
		result.X = value1.X * num3 + value2.X * num4 + tangent1.X * num5 + tangent2.X * num6;
		result.Y = value1.Y * num3 + value2.Y * num4 + tangent1.Y * num5 + tangent2.Y * num6;
		result.Z = value1.Z * num3 + value2.Z * num4 + tangent1.Z * num5 + tangent2.Z * num6;
		return result;
	}
	public static void Hermite(ref Vector3 value1, ref Vector3 tangent1, ref Vector3 value2, ref Vector3 tangent2, float amount, out Vector3 result)
	{
		float num = amount * amount;
		float num2 = amount * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + amount;
		float num6 = num2 - num;
		result.X = value1.X * num3 + value2.X * num4 + tangent1.X * num5 + tangent2.X * num6;
		result.Y = value1.Y * num3 + value2.Y * num4 + tangent1.Y * num5 + tangent2.Y * num6;
		result.Z = value1.Z * num3 + value2.Z * num4 + tangent1.Z * num5 + tangent2.Z * num6;
	}
	public static Vector3 Negate(Vector3 value)
	{
		Vector3 result;
		result.X = -value.X;
		result.Y = -value.Y;
		result.Z = -value.Z;
		return result;
	}
	public static void Negate(ref Vector3 value, out Vector3 result)
	{
		result.X = -value.X;
		result.Y = -value.Y;
		result.Z = -value.Z;
	}
	public static Vector3 Add(Vector3 value1, Vector3 value2)
	{
		Vector3 result;
		result.X = value1.X + value2.X;
		result.Y = value1.Y + value2.Y;
		result.Z = value1.Z + value2.Z;
		return result;
	}
	public static void Add(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
	{
		result.X = value1.X + value2.X;
		result.Y = value1.Y + value2.Y;
		result.Z = value1.Z + value2.Z;
	}
	public static Vector3 Subtract(Vector3 value1, Vector3 value2)
	{
		Vector3 result;
		result.X = value1.X - value2.X;
		result.Y = value1.Y - value2.Y;
		result.Z = value1.Z - value2.Z;
		return result;
	}
	public static void Subtract(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
	{
		result.X = value1.X - value2.X;
		result.Y = value1.Y - value2.Y;
		result.Z = value1.Z - value2.Z;
	}
	public static Vector3 Multiply(Vector3 value1, Vector3 value2)
	{
		Vector3 result;
		result.X = value1.X * value2.X;
		result.Y = value1.Y * value2.Y;
		result.Z = value1.Z * value2.Z;
		return result;
	}
	public static void Multiply(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
	{
		result.X = value1.X * value2.X;
		result.Y = value1.Y * value2.Y;
		result.Z = value1.Z * value2.Z;
	}
	public static Vector3 Multiply(Vector3 value1, float scaleFactor)
	{
		Vector3 result;
		result.X = value1.X * scaleFactor;
		result.Y = value1.Y * scaleFactor;
		result.Z = value1.Z * scaleFactor;
		return result;
	}
	public static void Multiply(ref Vector3 value1, float scaleFactor, out Vector3 result)
	{
		result.X = value1.X * scaleFactor;
		result.Y = value1.Y * scaleFactor;
		result.Z = value1.Z * scaleFactor;
	}
	public static Vector3 Divide(Vector3 value1, Vector3 value2)
	{
		Vector3 result;
		result.X = value1.X / value2.X;
		result.Y = value1.Y / value2.Y;
		result.Z = value1.Z / value2.Z;
		return result;
	}
	public static void Divide(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
	{
		result.X = value1.X / value2.X;
		result.Y = value1.Y / value2.Y;
		result.Z = value1.Z / value2.Z;
	}
	public static Vector3 Divide(Vector3 value1, float divider)
	{
		float num = 1f / divider;
		Vector3 result;
		result.X = value1.X * num;
		result.Y = value1.Y * num;
		result.Z = value1.Z * num;
		return result;
	}
	public static void Divide(ref Vector3 value1, float divider, out Vector3 result)
	{
		float num = 1f / divider;
		result.X = value1.X * num;
		result.Y = value1.Y * num;
		result.Z = value1.Z * num;
	}
	public static Vector3 operator -(Vector3 value)
	{
		Vector3 result;
		result.X = -value.X;
		result.Y = -value.Y;
		result.Z = -value.Z;
		return result;
	}
	public static bool operator ==(Vector3 value1, Vector3 value2)
	{
		return value1.X == value2.X && value1.Y == value2.Y && value1.Z == value2.Z;
	}
	public static bool operator !=(Vector3 value1, Vector3 value2)
	{
		return value1.X != value2.X || value1.Y != value2.Y || value1.Z != value2.Z;
	}
	public static Vector3 operator +(Vector3 value1, Vector3 value2)
	{
		Vector3 result;
		result.X = value1.X + value2.X;
		result.Y = value1.Y + value2.Y;
		result.Z = value1.Z + value2.Z;
		return result;
	}
	public static Vector3 operator -(Vector3 value1, Vector3 value2)
	{
		Vector3 result;
		result.X = value1.X - value2.X;
		result.Y = value1.Y - value2.Y;
		result.Z = value1.Z - value2.Z;
		return result;
	}
	public static Vector3 operator *(Vector3 value1, Vector3 value2)
	{
		Vector3 result;
		result.X = value1.X * value2.X;
		result.Y = value1.Y * value2.Y;
		result.Z = value1.Z * value2.Z;
		return result;
	}
	public static Vector3 operator *(Vector3 value1, float scaleFactor)
	{
		Vector3 result;
		result.X = value1.X * scaleFactor;
		result.Y = value1.Y * scaleFactor;
		result.Z = value1.Z * scaleFactor;
		return result;
	}
	public static Vector3 operator *(float scaleFactor, Vector3 value1)
	{
		Vector3 result;
		result.X = value1.X * scaleFactor;
		result.Y = value1.Y * scaleFactor;
		result.Z = value1.Z * scaleFactor;
		return result;
	}
	public static Vector3 operator /(Vector3 value1, Vector3 value2)
	{
		Vector3 result;
		result.X = value1.X / value2.X;
		result.Y = value1.Y / value2.Y;
		result.Z = value1.Z / value2.Z;
		return result;
	}
	public static Vector3 operator /(Vector3 value1, float divider)
	{
		float num = 1f / divider;
		Vector3 result;
		result.X = value1.X * num;
		result.Y = value1.Y * num;
		result.Z = value1.Z * num;
		return result;
	}
	static Vector3()
	{
		Vector3._zero = default(Vector3);
		Vector3._one = new Vector3(1f, 1f, 1f);
		Vector3._unitX = new Vector3(1f, 0f, 0f);
		Vector3._unitY = new Vector3(0f, 1f, 0f);
		Vector3._unitZ = new Vector3(0f, 0f, 1f);
	}
}
