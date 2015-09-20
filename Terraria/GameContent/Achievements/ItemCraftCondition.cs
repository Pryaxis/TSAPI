using System;
using System.Collections.Generic;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
	public class ItemCraftCondition : AchievementCondition
	{
		private const string Identifier = "ITEM_PICKUP";

		private static Dictionary<short, List<ItemCraftCondition>> _listeners;

		private static bool _isListenerHooked;

		private short[] _itemIds;

		static ItemCraftCondition()
		{
			ItemCraftCondition._listeners = new Dictionary<short, List<ItemCraftCondition>>();
			ItemCraftCondition._isListenerHooked = false;
		}

		private ItemCraftCondition(short itemId) : base(string.Concat("ITEM_PICKUP_", itemId))
		{
			this._itemIds = new short[] { itemId };
			ItemCraftCondition.ListenForCraft(this);
		}

		private ItemCraftCondition(short[] itemIds) : base(string.Concat("ITEM_PICKUP_", itemIds[0]))
		{
			this._itemIds = itemIds;
			ItemCraftCondition.ListenForCraft(this);
		}

		public static AchievementCondition Create(params short[] items)
		{
			return new ItemCraftCondition(items);
		}

		public static AchievementCondition Create(short item)
		{
			return new ItemCraftCondition(item);
		}

		public static AchievementCondition[] CreateMany(params short[] items)
		{
			AchievementCondition[] itemCraftCondition = new AchievementCondition[(int)items.Length];
			for (int i = 0; i < (int)items.Length; i++)
			{
				itemCraftCondition[i] = new ItemCraftCondition(items[i]);
			}
			return itemCraftCondition;
		}

		private static void ItemCraftListener(short itemId, int count)
		{
			if (ItemCraftCondition._listeners.ContainsKey(itemId))
			{
				foreach (ItemCraftCondition item in ItemCraftCondition._listeners[itemId])
				{
					item.Complete();
				}
			}
		}

		private static void ListenForCraft(ItemCraftCondition condition)
		{
			if (!ItemCraftCondition._isListenerHooked)
			{
				AchievementsHelper.OnItemCraft += new AchievementsHelper.ItemCraftEvent(ItemCraftCondition.ItemCraftListener);
				ItemCraftCondition._isListenerHooked = true;
			}
			for (int i = 0; i < (int)condition._itemIds.Length; i++)
			{
				if (!ItemCraftCondition._listeners.ContainsKey(condition._itemIds[i]))
				{
					ItemCraftCondition._listeners[condition._itemIds[i]] = new List<ItemCraftCondition>();
				}
				ItemCraftCondition._listeners[condition._itemIds[i]].Add(condition);
			}
		}
	}
}