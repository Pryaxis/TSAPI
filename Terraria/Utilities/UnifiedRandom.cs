using System;

namespace Terraria.Utilities
{
	[Serializable]
	public class UnifiedRandom
	{
		private int inext;

		private int inextp;

		private const int MBIG = 2147483647;

		private const int MSEED = 161803398;

		private const int MZ = 0;

		private int[] SeedArray = new int[56];

		public UnifiedRandom() : this(Environment.TickCount)
		{
		}

		public UnifiedRandom(int Seed)
		{
			int num = (Seed == -2147483648) ? MBIG : Math.Abs(Seed);
			int num2 = MSEED - num;
			this.SeedArray[55] = num2;
			int num3 = 1;
			for (int i = 1; i < 55; i++)
			{
				int num4 = 21 * i % 55;
				this.SeedArray[num4] = num3;
				num3 = num2 - num3;
				if (num3 < 0)
				{
					num3 += MBIG;
				}
				num2 = this.SeedArray[num4];
			}
			for (int j = 1; j < 5; j++)
			{
				for (int k = 1; k < 56; k++)
				{
					this.SeedArray[k] -= this.SeedArray[1 + (k + 30) % 55];
					if (this.SeedArray[k] < 0)
					{
						this.SeedArray[k] += MBIG;
					}
				}
			}
			this.inext = 0;
			this.inextp = 21;
			Seed = 1;
		}

		private double GetSampleForLargeRange()
		{
			int num = this.InternalSample();
			bool flag = this.InternalSample() % 2 == 0;
			if (flag)
			{
				num = -num;
			}
			double num2 = (double)num;
			num2 += 2147483646.0;
			return num2 / 4294967293.0;
		}

		private int InternalSample()
		{
			int num = this.inext;
			int num2 = this.inextp;
			if (++num >= 56)
			{
				num = 1;
			}
			if (++num2 >= 56)
			{
				num2 = 1;
			}
			int num3 = this.SeedArray[num] - this.SeedArray[num2];
			if (num3 == MBIG)
			{
				num3--;
			}
			if (num3 < 0)
			{
				num3 += MBIG;
			}
			this.SeedArray[num] = num3;
			this.inext = num;
			this.inextp = num2;
			return num3;
		}

		public virtual int Next()
		{
			return this.InternalSample();
		}

		public virtual int Next(int maxValue)
		{
			if (maxValue < 0)
			{
				throw new ArgumentOutOfRangeException("maxValue", "maxValue must be positive.");
			}
			return (int)(this.Sample() * (double)maxValue);
		}

		public virtual int Next(int minValue, int maxValue)
		{
			if (minValue > maxValue)
			{
				throw new ArgumentOutOfRangeException("minValue", "minValue must be less than maxValue");
			}
			long num = (long)maxValue - (long)minValue;
			if (num <= (long)MBIG)
			{
				return (int)(this.Sample() * (double)num) + minValue;
			}
			return (int)((long)(this.GetSampleForLargeRange() * (double)num) + (long)minValue);
		}

		public virtual void NextBytes(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = (byte)(this.InternalSample() % 256);
			}
		}

		public virtual double NextDouble()
		{
			return this.Sample();
		}

		protected virtual double Sample()
		{
			return (double)this.InternalSample() * 4.6566128752457969E-10;
		}
	}
}
