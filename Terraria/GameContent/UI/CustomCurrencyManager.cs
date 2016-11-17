using System;
using System.Collections.Generic;
using Terraria.ID;

namespace Terraria.GameContent.UI
{
	public class CustomCurrencyManager
	{
		private static Dictionary<int, CustomCurrencySystem> _currencies = new Dictionary<int, CustomCurrencySystem>();

		private static int _nextCurrencyIndex = 0;

		public static bool BuyItem(Player player, int price, int currencyIndex)
		{
			CustomCurrencySystem customCurrencySystem = CustomCurrencyManager._currencies[currencyIndex];
			bool flag;
			long num = customCurrencySystem.CountCurrency(out flag, player.inventory, new int[]
			{
				58,
				57,
				56,
				55,
				54
			});
			long num2 = customCurrencySystem.CountCurrency(out flag, player.bank.item, new int[0]);
			long num3 = customCurrencySystem.CountCurrency(out flag, player.bank2.item, new int[0]);
			long num4 = customCurrencySystem.CountCurrency(out flag, player.bank3.item, new int[0]);
			long num5 = customCurrencySystem.CombineStacks(out flag, new long[]
			{
				num,
				num2,
				num3,
				num4
			});
			if (num5 < (long)price)
			{
				return false;
			}
			List<Item[]> list = new List<Item[]>();
			Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
			List<Point> list2 = new List<Point>();
			List<Point> list3 = new List<Point>();
			List<Point> list4 = new List<Point>();
			List<Point> list5 = new List<Point>();
			List<Point> list6 = new List<Point>();
			list.Add(player.inventory);
			list.Add(player.bank.item);
			list.Add(player.bank2.item);
			list.Add(player.bank3.item);
			for (int i = 0; i < list.Count; i++)
			{
				dictionary[i] = new List<int>();
			}
			dictionary[0] = new List<int>
			{
				58,
				57,
				56,
				55,
				54
			};
			for (int j = 0; j < list.Count; j++)
			{
				for (int k = 0; k < list[j].Length; k++)
				{
					if (!dictionary[j].Contains(k) && customCurrencySystem.Accepts(list[j][k]))
					{
						list3.Add(new Point(j, k));
					}
				}
			}
			CustomCurrencyManager.FindEmptySlots(list, dictionary, list2, 0);
			CustomCurrencyManager.FindEmptySlots(list, dictionary, list4, 1);
			CustomCurrencyManager.FindEmptySlots(list, dictionary, list5, 2);
			CustomCurrencyManager.FindEmptySlots(list, dictionary, list6, 3);
			return customCurrencySystem.TryPurchasing(price, list, list3, list2, list4, list5, list6);
		}

		private static void FindEmptySlots(List<Item[]> inventories, Dictionary<int, List<int>> slotsToIgnore, List<Point> emptySlots, int currentInventoryIndex)
		{
			for (int i = inventories[currentInventoryIndex].Length - 1; i >= 0; i--)
			{
				if (!slotsToIgnore[currentInventoryIndex].Contains(i) && (inventories[currentInventoryIndex][i].type == 0 || inventories[currentInventoryIndex][i].stack == 0))
				{
					emptySlots.Add(new Point(currentInventoryIndex, i));
				}
			}
		}

		public static void GetPriceText(int currencyIndex, string[] lines, ref int currentLine, int price)
		{
			CustomCurrencySystem customCurrencySystem = CustomCurrencyManager._currencies[currencyIndex];
			customCurrencySystem.GetPriceText(lines, ref currentLine, price);
		}

		public static void Initialize()
		{
			CustomCurrencyManager._nextCurrencyIndex = 0;
			CustomCurrencyID.DefenderMedals = CustomCurrencyManager.RegisterCurrency(new CustomCurrencySingleCoin(3817, 999L));
		}

		public static int RegisterCurrency(CustomCurrencySystem collection)
		{
			int nextCurrencyIndex = CustomCurrencyManager._nextCurrencyIndex;
			CustomCurrencyManager._nextCurrencyIndex++;
			CustomCurrencyManager._currencies[nextCurrencyIndex] = collection;
			return nextCurrencyIndex;
		}
	}
}
