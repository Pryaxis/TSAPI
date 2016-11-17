using System;
using System.Collections.Generic;

namespace Terraria.GameContent.UI
{
	public class CustomCurrencySystem
	{
		private long _currencyCap = 999999999L;

		protected Dictionary<int, int> _valuePerUnit = new Dictionary<int, int>();

		public virtual bool Accepts(Item item)
		{
			return this._valuePerUnit.ContainsKey(item.type);
		}

		public virtual long CombineStacks(out bool overFlowing, params long[] coinCounts)
		{
			long num = 0L;
			for (int i = 0; i < coinCounts.Length; i++)
			{
				long num2 = coinCounts[i];
				num += num2;
				if (num >= this.CurrencyCap)
				{
					overFlowing = true;
					return this.CurrencyCap;
				}
			}
			overFlowing = false;
			return num;
		}

		public virtual long CountCurrency(out bool overFlowing, Item[] inv, params int[] ignoreSlots)
		{
			List<int> list = new List<int>(ignoreSlots);
			long num = 0L;
			for (int i = 0; i < inv.Length; i++)
			{
				if (!list.Contains(i))
				{
					int num2;
					if (this._valuePerUnit.TryGetValue(inv[i].type, out num2))
					{
						num += (long)(num2 * inv[i].stack);
					}
					if (num >= this.CurrencyCap)
					{
						overFlowing = true;
						return this.CurrencyCap;
					}
				}
			}
			overFlowing = false;
			return num;
		}

		public virtual void GetPriceText(string[] lines, ref int currentLine, int price)
		{
		}

		public void Include(int coin, int howMuchIsItWorth)
		{
			this._valuePerUnit[coin] = howMuchIsItWorth;
		}

		protected List<Tuple<Point, Item>> ItemCacheCreate(List<Item[]> inventories)
		{
			List<Tuple<Point, Item>> list = new List<Tuple<Point, Item>>();
			for (int i = 0; i < inventories.Count; i++)
			{
				for (int j = 0; j < inventories[i].Length; j++)
				{
					Item item = inventories[i][j];
					list.Add(new Tuple<Point, Item>(new Point(i, j), item.DeepClone()));
				}
			}
			return list;
		}

		protected void ItemCacheRestore(List<Tuple<Point, Item>> cache, List<Item[]> inventories)
		{
			foreach (Tuple<Point, Item> current in cache)
			{
				inventories[current.Item1.X][current.Item1.Y] = current.Item2;
			}
		}

		public void SetCurrencyCap(long cap)
		{
			this._currencyCap = cap;
		}

		protected int SortByHighest(Tuple<int, int> valueA, Tuple<int, int> valueB)
		{
			if (valueA.Item2 > valueB.Item2)
			{
				return -1;
			}
			if (valueA.Item2 == valueB.Item2)
			{
				return 0;
			}
			return -1;
		}

		public virtual bool TryPurchasing(int price, List<Item[]> inv, List<Point> slotCoins, List<Point> slotsEmpty, List<Point> slotEmptyBank, List<Point> slotEmptyBank2, List<Point> slotEmptyBank3)
		{
			long num = (long)price;
			Dictionary<Point, Item> dictionary = new Dictionary<Point, Item>();
			bool result = true;
			while (num > 0L)
			{
				long num2 = 1000000L;
				for (int i = 0; i < 4; i++)
				{
					if (num >= num2)
					{
						foreach (Point current in slotCoins)
						{
							if (inv[current.X][current.Y].type == 74 - i)
							{
								long num3 = num / num2;
								dictionary[current] = inv[current.X][current.Y].Clone();
								if (num3 < (long)inv[current.X][current.Y].stack)
								{
									inv[current.X][current.Y].stack -= (int)num3;
								}
								else
								{
									inv[current.X][current.Y].SetDefaults(0, false);
									slotsEmpty.Add(current);
								}
								num -= num2 * (long)(dictionary[current].stack - inv[current.X][current.Y].stack);
							}
						}
					}
					num2 /= 100L;
				}
				if (num > 0L)
				{
					if (slotsEmpty.Count <= 0)
					{
						foreach (KeyValuePair<Point, Item> current2 in dictionary)
						{
							inv[current2.Key.X][current2.Key.Y] = current2.Value.Clone();
						}
						result = false;
						break;
					}
					slotsEmpty.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
					Point item = new Point(-1, -1);
					for (int j = 0; j < inv.Count; j++)
					{
						num2 = 10000L;
						for (int k = 0; k < 3; k++)
						{
							if (num >= num2)
							{
								foreach (Point current3 in slotCoins)
								{
									if (current3.X == j && inv[current3.X][current3.Y].type == 74 - k && inv[current3.X][current3.Y].stack >= 1)
									{
										List<Point> list = slotsEmpty;
										if (j == 1 && slotEmptyBank.Count > 0)
										{
											list = slotEmptyBank;
										}
										if (j == 2 && slotEmptyBank2.Count > 0)
										{
											list = slotEmptyBank2;
										}
										if (j == 3 && slotEmptyBank3.Count > 0)
										{
											list = slotEmptyBank3;
										}
										if (--inv[current3.X][current3.Y].stack <= 0)
										{
											inv[current3.X][current3.Y].SetDefaults(0, false);
											list.Add(current3);
										}
										dictionary[list[0]] = inv[list[0].X][list[0].Y].Clone();
										inv[list[0].X][list[0].Y].SetDefaults(73 - k, false);
										inv[list[0].X][list[0].Y].stack = 100;
										item = list[0];
										list.RemoveAt(0);
										break;
									}
								}
							}
							if (item.X != -1 || item.Y != -1)
							{
								break;
							}
							num2 /= 100L;
						}
						for (int l = 0; l < 2; l++)
						{
							if (item.X == -1 && item.Y == -1)
							{
								foreach (Point current4 in slotCoins)
								{
									if (current4.X == j && inv[current4.X][current4.Y].type == 73 + l && inv[current4.X][current4.Y].stack >= 1)
									{
										List<Point> list2 = slotsEmpty;
										if (j == 1 && slotEmptyBank.Count > 0)
										{
											list2 = slotEmptyBank;
										}
										if (j == 2 && slotEmptyBank2.Count > 0)
										{
											list2 = slotEmptyBank2;
										}
										if (j == 3 && slotEmptyBank3.Count > 0)
										{
											list2 = slotEmptyBank3;
										}
										if (--inv[current4.X][current4.Y].stack <= 0)
										{
											inv[current4.X][current4.Y].SetDefaults(0, false);
											list2.Add(current4);
										}
										dictionary[list2[0]] = inv[list2[0].X][list2[0].Y].Clone();
										inv[list2[0].X][list2[0].Y].SetDefaults(72 + l, false);
										inv[list2[0].X][list2[0].Y].stack = 100;
										item = list2[0];
										list2.RemoveAt(0);
										break;
									}
								}
							}
						}
						if (item.X != -1 && item.Y != -1)
						{
							slotCoins.Add(item);
							break;
						}
					}
					slotsEmpty.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
					slotEmptyBank.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
					slotEmptyBank2.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
					slotEmptyBank3.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
				}
			}
			return result;
		}

		public long CurrencyCap
		{
			get
			{
				return this._currencyCap;
			}
		}
	}
}
