using System;
using System.Collections.Generic;
using Terraria.ID;
namespace Terraria.GameContent.UI
{
	public class ItemRarity
	{
		private static Dictionary<int, Color> rarities = new Dictionary<int, Color>();
		public static void Initialize()
		{
			ItemRarity.rarities.Clear();
			ItemRarity.rarities.Add(-11, Colors.RarityAmber);
			ItemRarity.rarities.Add(-1, Colors.RarityTrash);
			ItemRarity.rarities.Add(1, Colors.RarityBlue);
			ItemRarity.rarities.Add(2, Colors.RarityGreen);
			ItemRarity.rarities.Add(3, Colors.RarityOrange);
			ItemRarity.rarities.Add(4, Colors.RarityRed);
			ItemRarity.rarities.Add(5, Colors.RarityPink);
			ItemRarity.rarities.Add(6, Colors.RarityPurple);
			ItemRarity.rarities.Add(7, Colors.RarityLime);
			ItemRarity.rarities.Add(8, Colors.RarityYellow);
			ItemRarity.rarities.Add(9, Colors.RarityCyan);
		}
		public static Color GetColor(int rarity)
		{
			Color result = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
			if (ItemRarity.rarities.ContainsKey(rarity))
			{
				return ItemRarity.rarities[rarity];
			}
			return result;
		}
	}
}
