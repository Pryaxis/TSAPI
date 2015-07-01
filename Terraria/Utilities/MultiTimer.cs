using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Terraria.Utilities
{
	public class MultiTimer
	{
		private int ticksBetweenPrint = 100;

		private int ticksElapsedForPrint;

		private Stopwatch timer = new Stopwatch();

		private Dictionary<string, double> timerDataMap = new Dictionary<string, double>();

		public MultiTimer()
		{
		}

		public MultiTimer(int ticksBetweenPrint)
		{
			this.ticksBetweenPrint = ticksBetweenPrint;
		}

		public void Record(string key)
		{
			double totalMilliseconds = this.timer.Elapsed.TotalMilliseconds;
			if (this.timerDataMap.ContainsKey(key))
			{
				Dictionary<string, double> item = this.timerDataMap;
				Dictionary<string, double> strs = item;
				string str = key;
				item[str] = strs[str] + totalMilliseconds;
			}
			else
			{
				this.timerDataMap.Add(key, totalMilliseconds);
			}
			this.timer.Restart();
		}

		public void Start()
		{
			this.timer.Reset();
			this.timer.Start();
		}

		public bool StopAndPrint()
		{
			MultiTimer multiTimer = this;
			multiTimer.ticksElapsedForPrint = multiTimer.ticksElapsedForPrint + 1;
			if (this.ticksElapsedForPrint != this.ticksBetweenPrint)
			{
				return false;
			}
			this.ticksElapsedForPrint = 0;
			Console.WriteLine("Average elapsed time: ");
			double value = 0;
			foreach (KeyValuePair<string, double> keyValuePair in this.timerDataMap)
			{
				object[] key = new object[] { keyValuePair.Key, " : ", (float)keyValuePair.Value / (float)this.ticksBetweenPrint, "ms" };
				Console.WriteLine(string.Concat(key));
				value = value + keyValuePair.Value;
			}
			List<string> strs = new List<string>(this.timerDataMap.Keys);
			for (int i = 0; i < strs.Count; i++)
			{
				this.timerDataMap[strs[i]] = 0;
			}
			Console.WriteLine(string.Concat("Total : ", (float)value / (float)this.ticksBetweenPrint, "ms"));
			return true;
		}
	}
}