using System;
using System.Collections.Generic;

namespace Terraria
{
	public class RecipeGroup
	{
		public Func<string> GetText;

		public List<int> ValidItems;

		public int IconicItemIndex;

		public static Dictionary<int, RecipeGroup> recipeGroups = new Dictionary<int, RecipeGroup>();

		public static Dictionary<string, int> recipeGroupIDs = new Dictionary<string, int>();

		public static int nextRecipeGroupIndex = 0;

		public RecipeGroup(Func<string> getName, params int[] validItems)
		{
			this.GetText = getName;
			this.ValidItems = new List<int>(validItems);
		}

		public static int RegisterGroup(string name, RecipeGroup rec)
		{
			int num = RecipeGroup.nextRecipeGroupIndex++;
			RecipeGroup.recipeGroups.Add(num, rec);
			RecipeGroup.recipeGroupIDs.Add(name, num);
			return num;
		}
	}
}
