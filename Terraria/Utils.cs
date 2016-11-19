using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Terraria.Utilities;
using Terraria.DataStructures;

namespace Terraria
{
	public static class Utils
	{
		public const long MaxCoins = 999999999L;

		private const ulong RANDOM_MULTIPLIER = 25214903917L;

		private const ulong RANDOM_ADD = 11L;

		private const ulong RANDOM_MASK = 281474976710655L;

		static Utils()
		{
		}

		public static float AngleLerp(this float curAngle, float targetAngle, float amount)
		{
			float single;
			float single1;
			if (targetAngle >= curAngle)
			{
				if (targetAngle <= curAngle)
				{
					return curAngle;
				}
				single = targetAngle - 6.28318548f;
				single1 = (targetAngle - curAngle > curAngle - single ? MathHelper.Lerp(curAngle, single, amount) : MathHelper.Lerp(curAngle, targetAngle, amount));
			}
			else
			{
				single = targetAngle + 6.28318548f;
				single1 = (single - curAngle > curAngle - targetAngle ? MathHelper.Lerp(curAngle, targetAngle, amount) : MathHelper.Lerp(curAngle, single, amount));
			}
			return MathHelper.WrapAngle(single1);
		}

		public static void WriteConsoleBar(int barWidth, int percent)
		{
			char barShade = '\u2592';
			char barFull = '\u2588';

			Console.Write($"{percent} % ");
			int pc = (int)(((decimal)percent / 100) * barWidth);
			for (int i = 0; i < barWidth; i++)
			{
				if (i < pc)
				{
					Console.Write(barFull);
				}
				else
				{
					Console.Write(barShade);
				}
			}
		}

		public static float AngleTowards(this float curAngle, float targetAngle, float maxChange)
		{
			curAngle = MathHelper.WrapAngle(curAngle);
			targetAngle = MathHelper.WrapAngle(targetAngle);
			if (curAngle < targetAngle)
			{
				if (targetAngle - curAngle > 3.14159274f)
				{
					curAngle = curAngle + 6.28318548f;
				}
			}
			else if (curAngle - targetAngle > 3.14159274f)
			{
				curAngle = curAngle - 6.28318548f;
			}
			curAngle = curAngle + MathHelper.Clamp(targetAngle - curAngle, -maxChange, maxChange);
			return MathHelper.WrapAngle(curAngle);
		}

		public static bool Between(this Vector2 vec, Vector2 minimum, Vector2 maximum)
		{
			if (vec.X < minimum.X || vec.X > maximum.X || vec.Y < minimum.Y)
			{
				return false;
			}
			return vec.Y <= maximum.Y;
		}

		public static Vector2 Bottom(this Rectangle r)
		{
			return new Vector2((float)(r.X + r.Width / 2), (float)(r.Y + r.Height));
		}

		public static Vector2 BottomLeft(this Rectangle r)
		{
			return new Vector2((float)r.X, (float)(r.Y + r.Height));
		}

		public static Vector2 BottomRight(this Rectangle r)
		{
			return new Vector2((float)(r.X + r.Width), (float)(r.Y + r.Height));
		}

		public static Vector2 Center(this Rectangle r)
		{
			return new Vector2((float)(r.X + r.Width / 2), (float)(r.Y + r.Height / 2));
		}

		public static Rectangle CenteredRectangle(Vector2 center, Vector2 size)
		{
			return new Rectangle((int)(center.X - size.X / 2f), (int)(center.Y - size.Y / 2f), (int)size.X, (int)size.Y);
		}

		public static T Clamp<T>(T value, T min, T max)
		where T : IComparable<T>
		{
			if (value.CompareTo(max) > 0)
			{
				return max;
			}
			if (value.CompareTo(min) < 0)
			{
				return min;
			}
			return value;
		}

		public static long CoinsCombineStacks(out bool overFlowing, params long[] coinCounts)
		{
			long num = (long)0;
			long[] numArray = coinCounts;
			for (int i = 0; i < (int)numArray.Length; i++)
			{
				num = num + numArray[i];
				if (num >= (long)999999999)
				{
					overFlowing = true;
					return (long)999999999;
				}
			}
			overFlowing = false;
			return num;
		}

		public static long CoinsCount(out bool overFlowing, Item[] inv, params int[] ignoreSlots)
		{
			List<int> nums = new List<int>(ignoreSlots);
			long num = (long)0;
			for (int i = 0; i < (int)inv.Length; i++)
			{
				if (!nums.Contains(i))
				{
					switch (inv[i].type)
					{
						case 71:
							{
								num = num + (long)inv[i].stack;
								break;
							}
						case 72:
							{
								num = num + (long)(inv[i].stack * 100);
								break;
							}
						case 73:
							{
								num = num + (long)(inv[i].stack * 10000);
								break;
							}
						case 74:
							{
								num = num + (long)(inv[i].stack * 1000000);
								break;
							}
					}
					if (num >= (long)999999999)
					{
						overFlowing = true;
						return (long)999999999;
					}
				}
			}
			overFlowing = false;
			return num;
		}

		public static int[] CoinsSplit(long count)
		{
			int[] numArray = new int[4];
			long num = (long)0;
			long num1 = (long)1000000;
			for (int i = 3; i >= 0; i--)
			{
				numArray[i] = (int)((count - num) / num1);
				num = num + (long)numArray[i] * num1;
				num1 = num1 / (long)100;
			}
			return numArray;
		}

		public static bool deepCompare(this int[] firstArray, int[] secondArray)
		{
			if (firstArray == null && secondArray == null)
			{
				return true;
			}
			if (firstArray == null || secondArray == null)
			{
				return false;
			}
			if ((int)firstArray.Length != (int)secondArray.Length)
			{
				return false;
			}
			for (int i = 0; i < (int)firstArray.Length; i++)
			{
				if (firstArray[i] != secondArray[i])
				{
					return false;
				}
			}
			return true;
		}

		public static float Distance(this Rectangle r, Vector2 point)
		{
			if (Utils.FloatIntersect((float)r.Left, (float)r.Top, (float)r.Width, (float)r.Height, point.X, point.Y, 0f, 0f))
			{
				return 0f;
			}
			if (point.X >= (float)r.Left && point.X <= (float)r.Right)
			{
				if (point.Y < (float)r.Top)
				{
					return (float)r.Top - point.Y;
				}
				return point.Y - (float)r.Bottom;
			}
			if (point.Y >= (float)r.Top && point.Y <= (float)r.Bottom)
			{
				if (point.X < (float)r.Left)
				{
					return (float)r.Left - point.X;
				}
				return point.X - (float)r.Right;
			}
			if (point.X < (float)r.Left)
			{
				if (point.Y < (float)r.Top)
				{
					return Vector2.Distance(point, r.TopLeft());
				}
				return Vector2.Distance(point, r.BottomLeft());
			}
			if (point.Y < (float)r.Top)
			{
				return Vector2.Distance(point, r.TopRight());
			}
			return Vector2.Distance(point, r.BottomRight());
		}

		public static Vector2 DrawBorderString(string text, Vector2 pos, Color color, float scale = 1f, float anchorx = 0f, float anchory = 0f, int stringLimit = -1)
		{
			return Vector2.Zero;
		}

		public static Vector2 DrawBorderStringBig(string text, Vector2 pos, Color color, float scale = 1f, float anchorx = 0f, float anchory = 0f, int stringLimit = -1)
		{
			return Vector2.Zero;
		}

		public static void DrawBorderStringFourWay(string text, float x, float y, Color textColor, Color borderColor, Vector2 origin, float scale = 1f)
		{
		}

		public static void DrawCursorSingle(Color color, float rot = float.NaN, float scale = 1f, Vector2 manualPosition = new Vector2(), int cursorSlot = 0, int specialMode = 0)
		{
		}

		public static void DrawInvBG(Rectangle R, Color c = new Color())
		{
		}

		public static void DrawInvBG(float x, float y, float w, float h, Color c = new Color())
		{
		}

		public static void DrawInvBG(int x, int y, int w, int h, Color c = new Color())
		{
		}

		public static void DrawLaser(Vector2 start, Vector2 end, Vector2 scale, Utils.LaserLineFraming framing)
		{
		}

		public static void DrawLine(Point start, Point end, Color color)
		{
		}

		public static void DrawLine(Vector2 start, Vector2 end, Color color)
		{
		}

		public static void DrawRect(Rectangle rect, Color color)
		{
		}

		public static void DrawRect(Point start, Point end, Color color)
		{
		}

		public static void DrawRect(Vector2 start, Vector2 end, Color color)
		{
		}

		public static void DrawRect(Vector2 topLeft, Vector2 topRight, Vector2 bottomRight, Vector2 bottomLeft, Color color)
		{
		}

		public static string[] FixArgs(string[] brokenArgs)
		{
			ArrayList arrayLists = new ArrayList();
			string str = "";
			for (int i = 0; i < (int)brokenArgs.Length; i++)
			{
				if (!brokenArgs[i].StartsWith("-"))
				{
					if (str != "")
					{
						str = string.Concat(str, " ");
					}
					str = string.Concat(str, brokenArgs[i]);
				}
				else
				{
					if (str == "")
					{
						arrayLists.Add("");
					}
					else
					{
						arrayLists.Add(str);
						str = "";
					}
					arrayLists.Add(brokenArgs[i]);
				}
			}
			arrayLists.Add(str);
			string[] strArrays = new string[arrayLists.Count];
			arrayLists.CopyTo(strArrays);
			return strArrays;
		}

		public static bool FloatIntersect(float r1StartX, float r1StartY, float r1Width, float r1Height, float r2StartX, float r2StartY, float r2Width, float r2Height)
		{
			if (r1StartX <= r2StartX + r2Width && r1StartY <= r2StartY + r2Height && r1StartX + r1Width >= r2StartX && r1StartY + r1Height >= r2StartY)
			{
				return true;
			}
			return false;
		}

		public static Vector2 Floor(this Vector2 vec)
		{
			vec.X = (float)((int)vec.X);
			vec.Y = (float)((int)vec.Y);
			return vec;
		}

		public static bool HasNaNs(this Vector2 vec)
		{
			if (float.IsNaN(vec.X))
			{
				return true;
			}
			return float.IsNaN(vec.Y);
		}

		public static string Hex3(this Color color)
		{
			string str = color.R.ToString("X2");
			string str1 = color.G.ToString("X2");
			byte b = color.B;
			return string.Concat(str, str1, b.ToString("X2")).ToLower();
		}

		public static string Hex4(this Color color)
		{
			string str = color.R.ToString("X2");
			string str1 = color.G.ToString("X2");
			string str2 = color.B.ToString("X2");
			byte a = color.A;
			return string.Concat(str, str1, str2, a.ToString("X2")).ToLower();
		}

		public static bool IndexInRange<T>(this T[] t, int index)
		{
			return index >= 0 && index < t.Length;
		}

		public static bool IndexInRange<T>(this List<T> t, int index)
		{
			return index >= 0 && index < t.Count;
		}

		public static float InverseLerp(float from, float to, float t, bool clamped = false)
		{
			if (clamped)
			{
				if (from < to)
				{
					if (t < from)
					{
						return 0f;
					}
					if (t > to)
					{
						return 1f;
					}
				}
				else
				{
					if (t < to)
					{
						return 1f;
					}
					if (t > from)
					{
						return 0f;
					}
				}
			}
			return (t - from) / (to - from);
		}

		public static bool IsPowerOfTwo(int x)
		{
			return x != 0 && (x & x - 1) == 0;
		}

		public static Vector2 Left(this Rectangle r)
		{
			return new Vector2((float)r.X, (float)(r.Y + r.Height / 2));
		}

		public static Color MultiplyRGB(this Color firstColor, Color secondColor)
		{
			return new Color((int)((float)(firstColor.R * secondColor.R) / 255f), (int)((float)(firstColor.G * secondColor.G) / 255f), (int)((float)(firstColor.B * secondColor.B) / 255f));
		}

		public static Color MultiplyRGBA(this Color firstColor, Color secondColor)
		{
			return new Color((int)((float)(firstColor.R * secondColor.R) / 255f), (int)((float)(firstColor.G * secondColor.G) / 255f), (int)((float)(firstColor.B * secondColor.B) / 255f), (int)((float)(firstColor.A * secondColor.A) / 255f));
		}

		public static float NextFloat(this UnifiedRandom r)
		{
			return (float)r.NextDouble();
		}

		public static float NextFloatDirection(this UnifiedRandom r)
		{
			return (float)r.NextDouble() * 2f - 1f;
		}

		public static Vector2 NextVector2Circular(this UnifiedRandom r, float circleHalfWidth, float circleHalfHeight)
		{
			return r.NextVector2Unit(0f, 6.28318548f) * new Vector2(circleHalfWidth, circleHalfHeight) * r.NextFloat();
		}

		public static Vector2 NextVector2CircularEdge(this UnifiedRandom r, float circleHalfWidth, float circleHalfHeight)
		{
			return r.NextVector2Unit(0f, 6.28318548f) * new Vector2(circleHalfWidth, circleHalfHeight);
		}

		public static Vector2 NextVector2Square(this UnifiedRandom r, float min, float max)
		{
			return new Vector2((max - min) * (float)r.NextDouble() + min, (max - min) * (float)r.NextDouble() + min);
		}

		public static Vector2 NextVector2Unit(this UnifiedRandom r, float startRotation = 0f, float rotationRange = 6.28318548f)
		{
			return (startRotation + rotationRange * r.NextFloat()).ToRotationVector2();
		}

		public static Vector2 OriginFlip(this Rectangle rect, Vector2 origin)
		{
			return origin;
		}

		public static Dictionary<string, string> ParseArguements(string[] args)
		{
			string str = null;
			string str1 = "";
			Dictionary<string, string> strs = new Dictionary<string, string>();
			for (int i = 0; i < (int)args.Length; i++)
			{
				if (args[i].Length != 0)
				{
					if (args[i][0] == '-' || args[i][0] == '+')
					{
						if (str != null)
						{
							strs.Add(str, str1);
							str1 = "";
						}
						str = args[i];
						str1 = "";
					}
					else
					{
						if (str1 != "")
						{
							str1 = string.Concat(str1, " ");
						}
						str1 = string.Concat(str1, args[i]);
					}
				}
			}
			if (str != null)
			{
				strs.Add(str, str1);
				str1 = "";
			}
			return strs;
		}

		public static bool PlotLine(Point16 p0, Point16 p1, Utils.PerLinePoint plot, bool jump = true)
		{
			return Utils.PlotLine(p0.X, p0.Y, p1.X, p1.Y, plot, jump);
		}

		public static bool PlotLine(Point p0, Point p1, Utils.PerLinePoint plot, bool jump = true)
		{
			return Utils.PlotLine(p0.X, p0.Y, p1.X, p1.Y, plot, jump);
		}

		private static bool PlotLine(int x0, int y0, int x1, int y1, Utils.PerLinePoint plot, bool jump = true)
		{
			if (x0 == x1 && y0 == y1)
			{
				return plot(x0, y0);
			}
			bool flag = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
			if (flag)
			{
				Utils.Swap<int>(ref x0, ref y0);
				Utils.Swap<int>(ref x1, ref y1);
			}
			int num = Math.Abs(x1 - x0);
			int num1 = Math.Abs(y1 - y0);
			int num2 = num / 2;
			int num3 = y0;
			int num4 = (x0 < x1 ? 1 : -1);
			int num5 = (y0 < y1 ? 1 : -1);
			for (int i = x0; i != x1; i = i + num4)
			{
				if (flag)
				{
					if (!plot(num3, i))
					{
						return false;
					}
				}
				else if (!plot(i, num3))
				{
					return false;
				}
				num2 = num2 - num1;
				if (num2 < 0)
				{
					num3 = num3 + num5;
					if (!jump)
					{
						if (flag)
						{
							if (!plot(num3, i))
							{
								return false;
							}
						}
						else if (!plot(i, num3))
						{
							return false;
						}
					}
					num2 = num2 + num;
				}
			}
			return true;
		}

		public static bool PlotTileLine(Vector2 start, Vector2 end, float width, Utils.PerLinePoint plot)
		{
			float single = width / 2f;
			Vector2 vector2 = end - start;
			Vector2 vector21 = vector2 / vector2.Length();
			Vector2 vector22 = new Vector2(-vector21.Y, vector21.X) * single;
			Point tileCoordinates = (start - vector22).ToTileCoordinates();
			Point point = (start + vector22).ToTileCoordinates();
			Point tileCoordinates1 = start.ToTileCoordinates();
			Point point1 = end.ToTileCoordinates();
			Point point2 = new Point(tileCoordinates.X - tileCoordinates1.X, tileCoordinates.Y - tileCoordinates1.Y);
			Point point3 = new Point(point.X - tileCoordinates1.X, point.Y - tileCoordinates1.Y);
			return Utils.PlotLine(tileCoordinates1.X, tileCoordinates1.Y, point1.X, point1.Y, (int x, int y) => Utils.PlotLine(x + point2.X, y + point2.Y, x + point3.X, y + point3.Y, plot, false), true);
		}

		public static bool PlotTileTale(Vector2 start, Vector2 end, float width, Utils.PerLinePoint plot)
		{
			float single1 = width / 2f;
			Vector2 vector2 = end - start;
			Vector2 vector21 = vector2 / vector2.Length();
			Vector2 vector22 = new Vector2(-vector21.Y, vector21.X);
			Point point3 = start.ToTileCoordinates();
			Point point4 = end.ToTileCoordinates();
			int num = 0;
			Utils.PlotLine(point3.X, point3.Y, point4.X, point4.Y, (int x, int y) =>
			{
				num++;
				return true;
			}, true);
			num--;
			int num1 = 0;
			return Utils.PlotLine(point3.X, point3.Y, point4.X, point4.Y, (int x, int y) =>
			{
				float single = 1f - (float)num1 / (float)num;
				num1++;
				Point tileCoordinates = (start - ((vector22 * single1) * single)).ToTileCoordinates();
				Point point = (start + ((vector22 * single1) * single)).ToTileCoordinates();
				Point point1 = new Point(tileCoordinates.X - point3.X, tileCoordinates.Y - point3.Y);
				Point point2 = new Point(point.X - point3.X, point.Y - point3.Y);
				return Utils.PlotLine(x + point1.X, y + point1.Y, x + point2.X, y + point2.Y, plot, false);
			}, true);
		}

		public static int RandomConsecutive(double random, int odds)
		{
			return (int)Math.Log(1 - random, 1 / (double)odds);
		}

		public static float RandomFloat(ref ulong seed)
		{
			return (float)Utils.RandomNext(ref seed, 24) / 16777216f;
		}

		public static int RandomInt(ref ulong seed, int max)
		{
			int num;
			int num1;
			if ((max & -max) == max)
			{
				return (int)((long)max * (long)Utils.RandomNext(ref seed, 31) >> 31);
			}
			do
			{
				num = Utils.RandomNext(ref seed, 31);
				num1 = num % max;
			}
			while (num - num1 + (max - 1) < 0);
			return num1;
		}

		public static int RandomInt(ref ulong seed, int min, int max)
		{
			return Utils.RandomInt(ref seed, max - min) + min;
		}

		public static int RandomNext(ref ulong seed, int bits)
		{
			seed = Utils.RandomNextSeed((ulong)seed);
			return (int)((long)seed >> (48 - bits & 63));
		}

		public static ulong RandomNextSeed(ulong seed)
		{
			return seed * 25214903917L + (long)11 & 281474976710655L;
		}

		public static Vector2 RandomVector2(UnifiedRandom random, float min, float max)
		{
			return new Vector2((max - min) * (float)random.NextDouble() + min, (max - min) * (float)random.NextDouble() + min);
		}

		public static Color ReadRGB(this BinaryReader bb)
		{
			return new Color((int)bb.ReadByte(), (int)bb.ReadByte(), (int)bb.ReadByte());
		}

		public static Vector2 ReadVector2(this BinaryReader bb)
		{
			return new Vector2(bb.ReadSingle(), bb.ReadSingle());
		}

		public static int ReadFloatAsInt(float value)
		{
			return new Utils.IntFloat(value).IntValue;
		}

		public static uint ReadFloatAsUInt(float value)
		{
			return new Utils.UIntFloat(value).UIntValue;
		}

		public static float ReadIntAsFloat(int value)
		{
			return new Utils.IntFloat(value).FloatValue;
		}

		public static float ReadUIntAsFloat(uint value)
		{
			return new Utils.UIntFloat(value).FloatValue;
		}

		public static Vector2 ReadPackedVector2(this BinaryReader bb)
		{
			HalfVector2 halfVector = new HalfVector2();
			halfVector.PackedValue = bb.ReadUInt32();
			return halfVector.ToVector2();
		}

		public static Vector2 Right(this Rectangle r)
		{
			return new Vector2((float)(r.X + r.Width), (float)(r.Y + r.Height / 2));
		}

		public static Vector2 RotatedBy(this Vector2 spinningpoint, double radians, Vector2 center = new Vector2())
		{
			float single = (float)Math.Cos(radians);
			float single1 = (float)Math.Sin(radians);
			Vector2 vector2 = spinningpoint - center;
			Vector2 x = center;
			x.X = x.X + (vector2.X * single - vector2.Y * single1);
			x.Y = x.Y + (vector2.X * single1 + vector2.Y * single);
			return x;
		}

		public static Vector2 RotatedByRandom(this Vector2 spinninpoint, double maxRadians)
		{
			Vector2 vector2 = new Vector2();
			return spinninpoint.RotatedBy(Main.rand.NextDouble() * maxRadians - Main.rand.NextDouble() * maxRadians, vector2);
		}

		public static Vector2 RotateRandom(this Vector2 spinninpoint, double maxRadians)
		{
			return spinninpoint.RotatedBy(Main.rand.NextDouble() * maxRadians - Main.rand.NextDouble() * maxRadians, default(Vector2));
		}

		public static T SelectRandom<T>(UnifiedRandom random, params T[] choices)
		{
			return choices[random.Next((int)choices.Length)];
		}

		public static Vector2 Size(this Rectangle r)
		{
			return new Vector2((float)r.Width, (float)r.Height);
		}

		public static float SmoothStep(float min, float max, float x)
		{
			return MathHelper.Clamp((x - min) / (max - min), 0f, 1f);
		}

		public static void Swap<T>(ref T t1, ref T t2)
		{
			T t = t1;
			t1 = t2;
			t2 = t;
		}

		public static byte[] ToByteArray(this string str)
		{
			byte[] numArray = new byte[str.Length * 2];
			Buffer.BlockCopy(str.ToCharArray(), 0, numArray, 0, (int)numArray.Length);
			return numArray;
		}

		public static int ToDirectionInt(this bool value)
		{
			if (!value)
			{
				return -1;
			}
			return 1;
		}

		public static int ToInt(this bool value)
		{
			if (!value)
			{
				return 0;
			}
			return 1;
		}

		public static Vector2 ToWorldCoordinates(this Point p, float autoAddX = 8f, float autoAddY = 8f)
		{
			return p.ToVector2() * 16f + new Vector2(autoAddX, autoAddY);
		}

		public static Vector2 Top(this Rectangle r)
		{
			return new Vector2((float)(r.X + r.Width / 2), (float)r.Y);
		}

		public static Vector2 TopLeft(this Rectangle r)
		{
			return new Vector2((float)r.X, (float)r.Y);
		}

		public static Point ToPoint(this Vector2 v)
		{
			return new Point((int)v.X, (int)v.Y);
		}

		public static Vector2 SafeNormalize(this Vector2 v, Vector2 defaultValue)
		{
			if (v == Vector2.Zero)
			{
				return defaultValue;
			}
			return Vector2.Normalize(v);
		}

		public static Vector2 TopRight(this Rectangle r)
		{
			return new Vector2((float)(r.X + r.Width), (float)r.Y);
		}

		public static float ToRotation(this Vector2 v)
		{
			return (float)Math.Atan2((double)v.Y, (double)v.X);
		}

		public static Vector2 ToRotationVector2(this float f)
		{
			return new Vector2((float)Math.Cos((double)f), (float)Math.Sin((double)f));
		}

		public static Point ToTileCoordinates(this Vector2 vec)
		{
			return new Point((int)vec.X >> 4, (int)vec.Y >> 4);
		}

		public static Point16 ToTileCoordinates16(this Vector2 vec)
		{
			return new Point16((int)vec.X >> 4, (int)vec.Y >> 4);
		}

		public static Vector2 ToVector2(this Point p)
		{
			return new Vector2((float)p.X, (float)p.Y);
		}

		public static Vector2 Vector2FromElipse(Vector2 angleVector, Vector2 elipseSizes)
		{
			if (elipseSizes == Vector2.Zero)
			{
				return Vector2.Zero;
			}
			if (angleVector == Vector2.Zero)
			{
				return Vector2.Zero;
			}
			angleVector.Normalize();
			Vector2 one = Vector2.Normalize(elipseSizes);
			one = Vector2.One / one;
			angleVector = angleVector * one;
			angleVector.Normalize();
			return (angleVector * elipseSizes) / 2f;
		}

		public static string[] WordwrapString(string text, int maxWidth, int maxLines, out int lineAmount)
		{
			string[] strArrays = new string[maxLines];
			lineAmount = 1;
			return strArrays;
		}

		public static void WriteRGB(this BinaryWriter bb, Color c)
		{
			bb.Write(c.R);
			bb.Write(c.G);
			bb.Write(c.B);
		}

		public static void WriteVector2(this BinaryWriter bb, Vector2 v)
		{
			bb.Write(v.X);
			bb.Write(v.Y);
		}

		public static void WritePackedVector2(this BinaryWriter bb, Vector2 v)
		{
			HalfVector2 halfVector = new HalfVector2(v.X, v.Y);
			bb.Write(halfVector.PackedValue);
		}

		public static Vector2 XY(this Vector4 vec)
		{
			return new Vector2(vec.X, vec.Y);
		}

		public static Vector3 XZW(this Vector4 vec)
		{
			return new Vector3(vec.X, vec.Z, vec.W);
		}

		public static Vector3 YZW(this Vector4 vec)
		{
			return new Vector3(vec.Y, vec.Z, vec.W);
		}

		public static Vector2 ZW(this Vector4 vec)
		{
			return new Vector2(vec.Z, vec.W);
		}

		public delegate void LaserLineFraming(int stage, Vector2 currentPosition, float distanceLeft, Rectangle lastFrame, out float distanceCovered, out Rectangle frame, out Vector2 origin, out Color color);

		public delegate bool PerLinePoint(int x, int y);

		#region 1.3.1
		public static bool RectangleLineCollision(Vector2 rectTopLeft, Vector2 rectBottomRight, Vector2 lineStart, Vector2 lineEnd)
		{
			if (lineStart.Between(rectTopLeft, rectBottomRight) || lineEnd.Between(rectTopLeft, rectBottomRight))
			{
				return true;
			}
			Vector2 p = new Vector2(rectBottomRight.X, rectTopLeft.Y);
			Vector2 vector = new Vector2(rectTopLeft.X, rectBottomRight.Y);
			Vector2[] array = new Vector2[]
			{
				rectTopLeft.ClosestPointOnLine(lineStart, lineEnd),
				p.ClosestPointOnLine(lineStart, lineEnd),
				vector.ClosestPointOnLine(lineStart, lineEnd),
				rectBottomRight.ClosestPointOnLine(lineStart, lineEnd)
			};
			for (int i = 0; i < array.Length; i++)
			{
				if (array[0].Between(rectTopLeft, vector))
				{
					return true;
				}
			}
			return false;
		}

		public static Vector2 ClosestPointOnLine(this Vector2 P, Vector2 A, Vector2 B)
		{
			Vector2 value = P - A;
			Vector2 vector = B - A;
			float num = vector.LengthSquared();
			float num2 = Vector2.Dot(value, vector);
			float num3 = num2 / num;
			if (num3 < 0f)
			{
				return A;
			}
			if (num3 > 1f)
			{
				return B;
			}
			return A + vector * num3;
		}
		#endregion

		private struct IntFloat
		{
			public IntFloat(int value)
			{
				this.FloatValue = 0f;
				this.IntValue = value;
			}

			public IntFloat(float value)
			{
				this.IntValue = 0;
				this.FloatValue = value;
			}

			public readonly int IntValue;

			public readonly float FloatValue;
		}

		private struct UIntFloat
		{
			public UIntFloat(uint value)
			{
				this.FloatValue = 0f;
				this.UIntValue = value;
			}

			public UIntFloat(float value)
			{
				this.UIntValue = 0u;
				this.FloatValue = value;
			}

			public readonly uint UIntValue;

			public readonly float FloatValue;
		}
	}
}
