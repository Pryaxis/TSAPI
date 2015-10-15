using System;
using System.Threading;
using Terraria;
using Terraria.Achievements;
using Terraria.ID;

namespace Terraria.GameContent.Achievements
{
	public class AchievementsHelper
	{
		private static bool _isMining;

		private static bool mayhemOK;

		private static bool mayhem1down;

		private static bool mayhem2down;

		private static bool mayhem3down;

		public static bool CurrentlyMining
		{
			get
			{
				return AchievementsHelper._isMining;
			}
			set
			{
				AchievementsHelper._isMining = value;
			}
		}

		static AchievementsHelper()
		{
			AchievementsHelper._isMining = false;
		}

		public AchievementsHelper()
		{
		}

		public static void CheckMechaMayhem(int justKilled = -1)
		{
			if (AchievementsHelper.mayhemOK)
			{
				if (justKilled == 125 || justKilled == 126)
				{
					AchievementsHelper.mayhem1down = true;
				}
				else if (!NPC.AnyNPCs(NPCID.Retinazer) && !NPC.AnyNPCs(NPCID.Spazmatism) && !AchievementsHelper.mayhem1down)
				{
					AchievementsHelper.mayhemOK = false;
					return;
				}
				if (justKilled == 134)
				{
					AchievementsHelper.mayhem2down = true;
				}
				else if (!NPC.AnyNPCs(NPCID.TheDestroyer) && !AchievementsHelper.mayhem2down)
				{
					AchievementsHelper.mayhemOK = false;
					return;
				}
				if (justKilled == 127)
				{
					AchievementsHelper.mayhem3down = true;
				}
				else if (!NPC.AnyNPCs(NPCID.SkeletronPrime) && !AchievementsHelper.mayhem3down)
				{
					AchievementsHelper.mayhemOK = false;
					return;
				}
				if (AchievementsHelper.mayhem1down && AchievementsHelper.mayhem2down && AchievementsHelper.mayhem3down)
				{
					AchievementsHelper.NotifyProgressionEvent(21);
				}
			}
			else if (NPC.AnyNPCs(NPCID.SkeletronPrime) && NPC.AnyNPCs(NPCID.TheDestroyer) && NPC.AnyNPCs(NPCID.Spazmatism) && NPC.AnyNPCs(NPCID.Retinazer))
			{
				AchievementsHelper.mayhemOK = true;
				AchievementsHelper.mayhem1down = false;
				AchievementsHelper.mayhem2down = false;
				AchievementsHelper.mayhem3down = false;
				return;
			}
		}

		public static void HandleAnglerService()
		{
			Main.Achievements.GetCondition("SERVANT_IN_TRAINING", "Finish").Complete();
			CustomFloatCondition condition = (CustomFloatCondition)Main.Achievements.GetCondition("GOOD_LITTLE_SLAVE", "Finish");
			condition.Value = condition.Value + 1f;
			CustomFloatCondition value = (CustomFloatCondition)Main.Achievements.GetCondition("TROUT_MONKEY", "Finish");
			value.Value = value.Value + 1f;
			CustomFloatCondition customFloatCondition = (CustomFloatCondition)Main.Achievements.GetCondition("FAST_AND_FISHIOUS", "Finish");
			customFloatCondition.Value = customFloatCondition.Value + 1f;
			CustomFloatCondition condition1 = (CustomFloatCondition)Main.Achievements.GetCondition("SUPREME_HELPER_MINION", "Finish");
			condition1.Value = condition1.Value + 1f;
		}

		public static void HandleMining()
		{
			CustomIntCondition condition = (CustomIntCondition)Main.Achievements.GetCondition("BULLDOZER", "Pick");
			condition.Value = condition.Value + 1;
		}

		public static void HandleNurseService(int coinsSpent)
		{
			CustomFloatCondition condition = (CustomFloatCondition)Main.Achievements.GetCondition("FREQUENT_FLYER", "Pay");
			condition.Value = condition.Value + (float)coinsSpent;
		}

		public static void HandleOnEquip(Player player, Item item, int context)
		{
			if (context == 16)
			{
				Main.Achievements.GetCondition("HOLD_ON_TIGHT", "Equip").Complete();
			}
			if (context == 17)
			{
				Main.Achievements.GetCondition("THE_CAVALRY", "Equip").Complete();
			}
			if ((context == 10 || context == 11) && item.wingSlot > 0)
			{
				Main.Achievements.GetCondition("HEAD_IN_THE_CLOUDS", "Equip").Complete();
			}
			if (context == 8 && player.armor[0].stack > 0 && player.armor[1].stack > 0 && player.armor[2].stack > 0)
			{
				Main.Achievements.GetCondition("MATCHING_ATTIRE", "Equip").Complete();
			}
			if (context == 9 && player.armor[10].stack > 0 && player.armor[11].stack > 0 && player.armor[12].stack > 0)
			{
				Main.Achievements.GetCondition("FASHION_STATEMENT", "Equip").Complete();
			}
			if (context == 12)
			{
				for (int i = 0; i < player.extraAccessorySlots + 3 + 5; i++)
				{
					if (player.dye[i].type < 1 || player.dye[i].stack < 1)
					{
						return;
					}
				}
				Main.Achievements.GetCondition("DYE_HARD", "Equip").Complete();
			}
		}

		public static void HandleRunning(float pixelsMoved)
		{
			CustomFloatCondition condition = (CustomFloatCondition)Main.Achievements.GetCondition("MARATHON_MEDALIST", "Move");
			condition.Value = condition.Value + pixelsMoved;
		}

		public static void HandleSpecialEvent(Player player, int eventID)
		{
			if (player.whoAmI != Main.myPlayer)
			{
				return;
			}
			switch (eventID)
			{
				case 1:
				{
					Main.Achievements.GetCondition("STAR_POWER", "Use").Complete();
					if (player.statLifeMax != 500 || player.statManaMax != 200)
					{
						break;
					}
					Main.Achievements.GetCondition("TOPPED_OFF", "Use").Complete();
					return;
				}
				case 2:
				{
					Main.Achievements.GetCondition("A_LIFE", "Use").Complete();
					if (player.statLifeMax != 500 || player.statManaMax != 200)
					{
						break;
					}
					Main.Achievements.GetCondition("TOPPED_OFF", "Use").Complete();
					return;
				}
				case 3:
				{
					Main.Achievements.GetCondition("NOT_THE_BEES", "Use").Complete();
					return;
				}
				case 4:
				{
					Main.Achievements.GetCondition("WATCH_YOUR_STEP", "Hit").Complete();
					return;
				}
				case 5:
				{
					Main.Achievements.GetCondition("RAINBOWS_AND_UNICORNS", "Use").Complete();
					return;
				}
				case 6:
				{
					Main.Achievements.GetCondition("YOU_AND_WHAT_ARMY", "Spawn").Complete();
					return;
				}
				case 7:
				{
					Main.Achievements.GetCondition("THROWING_LINES", "Use").Complete();
					return;
				}
				case 8:
				{
					Main.Achievements.GetCondition("LUCKY_BREAK", "Hit").Complete();
					return;
				}
				case 9:
				{
					Main.Achievements.GetCondition("VEHICULAR_MANSLAUGHTER", "Hit").Complete();
					return;
				}
				case 10:
				{
					Main.Achievements.GetCondition("ROCK_BOTTOM", "Reach").Complete();
					return;
				}
				case 11:
				{
					Main.Achievements.GetCondition("INTO_ORBIT", "Reach").Complete();
					return;
				}
				case 12:
				{
					Main.Achievements.GetCondition("WHERES_MY_HONEY", "Reach").Complete();
					return;
				}
				case 13:
				{
					Main.Achievements.GetCondition("JEEPERS_CREEPERS", "Reach").Complete();
					return;
				}
				case 14:
				{
					Main.Achievements.GetCondition("ITS_GETTING_HOT_IN_HERE", "Reach").Complete();
					return;
				}
				case 15:
				{
					Main.Achievements.GetCondition("FUNKYTOWN", "Reach").Complete();
					return;
				}
				case 16:
				{
					Main.Achievements.GetCondition("I_AM_LOOT", "Peek").Complete();
					break;
				}
				default:
				{
					return;
				}
			}
		}

		public static void Initialize()
		{
			Player.OnEnterWorld += new Action<Player>(AchievementsHelper.OnPlayerEnteredWorld);
		}

		public static void NotifyItemCraft(Recipe recipe)
		{
			if (AchievementsHelper.OnItemCraft != null)
			{
				AchievementsHelper.OnItemCraft((short)recipe.createItem.netID, recipe.createItem.stack);
			}
		}

		public static void NotifyItemPickup(Player player, Item item)
		{
			if (AchievementsHelper.OnItemPickup != null)
			{
				AchievementsHelper.OnItemPickup(player, (short)item.netID, item.stack);
			}
		}

		public static void NotifyItemPickup(Player player, Item item, int customStack)
		{
			if (AchievementsHelper.OnItemPickup != null)
			{
				AchievementsHelper.OnItemPickup(player, (short)item.netID, customStack);
			}
		}

		public static void NotifyNPCKilled(NPC npc)
		{
			if (Main.netMode != 0)
			{
				for (int i = 0; i < 255; i++)
				{
					if (npc.playerInteraction[i])
					{
						NetMessage.SendData((int)PacketTypes.NotifyPlayerNpcKilled, i, -1, "", npc.netID, 0f, 0f, 0f, 0, 0, 0);
					}
				}
			}
			else if (npc.playerInteraction[Main.myPlayer])
			{
				AchievementsHelper.NotifyNPCKilledDirect(Main.player[Main.myPlayer], npc.netID);
				return;
			}
		}

		public static void NotifyNPCKilledDirect(Player player, int npcNetID)
		{
			if (AchievementsHelper.OnNPCKilled != null)
			{
				AchievementsHelper.OnNPCKilled(player, (short)npcNetID);
			}
		}

		public static void NotifyProgressionEvent(int eventID)
		{
			if (Main.netMode == 1)
			{
				return;
			}
			if (AchievementsHelper.OnProgressionEvent != null)
			{
				if (Main.netMode == 2)
				{
					NetMessage.SendData((int)PacketTypes.NotifyPlayerOfEvent, -1, -1, "", eventID, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				AchievementsHelper.OnProgressionEvent(eventID);
			}
		}

		public static void NotifyTileDestroyed(Player player, ushort tile)
		{
			if (Main.gameMenu || !AchievementsHelper._isMining)
			{
				return;
			}
			if (AchievementsHelper.OnTileDestroyed != null)
			{
				AchievementsHelper.OnTileDestroyed(player, tile);
			}
		}

		private static void OnPlayerEnteredWorld(Player player)
		{
			if (AchievementsHelper.OnItemPickup != null)
			{
				for (int i = 0; i < 58; i++)
				{
					AchievementsHelper.OnItemPickup(player, (short)player.inventory[i].type, player.inventory[i].stack);
				}
				for (int j = 0; j < (int)player.armor.Length; j++)
				{
					AchievementsHelper.OnItemPickup(player, (short)player.armor[j].type, player.armor[j].stack);
				}
				for (int k = 0; k < (int)player.dye.Length; k++)
				{
					AchievementsHelper.OnItemPickup(player, (short)player.dye[k].type, player.dye[k].stack);
				}
				for (int l = 0; l < (int)player.miscEquips.Length; l++)
				{
					AchievementsHelper.OnItemPickup(player, (short)player.miscEquips[l].type, player.miscEquips[l].stack);
				}
				for (int m = 0; m < (int)player.miscDyes.Length; m++)
				{
					AchievementsHelper.OnItemPickup(player, (short)player.miscDyes[m].type, player.miscDyes[m].stack);
				}
				for (int n = 0; n < (int)player.bank.item.Length; n++)
				{
					AchievementsHelper.OnItemPickup(player, (short)player.bank.item[n].type, player.bank.item[n].stack);
				}
				for (int o = 0; o < (int)player.bank2.item.Length; o++)
				{
					AchievementsHelper.OnItemPickup(player, (short)player.bank2.item[o].type, player.bank2.item[o].stack);
				}
			}
			if (player.statManaMax > 0)
			{
				Main.Achievements.GetCondition("STAR_POWER", "Use").Complete();
			}
			if (player.statLifeMax > 0)
			{
				Main.Achievements.GetCondition("A_LIFE", "Use").Complete();
			}
			if (player.statLifeMax == 500 && player.statManaMax == 200)
			{
				Main.Achievements.GetCondition("TOPPED_OFF", "Use").Complete();
			}
			if (player.miscEquips[4].type > 0)
			{
				Main.Achievements.GetCondition("HOLD_ON_TIGHT", "Equip").Complete();
			}
			if (player.miscEquips[3].type > 0)
			{
				Main.Achievements.GetCondition("THE_CAVALRY", "Equip").Complete();
			}
			int num = 0;
			while (num < (int)player.armor.Length)
			{
				if (player.armor[num].wingSlot <= 0)
				{
					num++;
				}
				else
				{
					Main.Achievements.GetCondition("HEAD_IN_THE_CLOUDS", "Equip").Complete();
					break;
				}
			}
			if (player.armor[0].stack > 0 && player.armor[1].stack > 0 && player.armor[2].stack > 0)
			{
				Main.Achievements.GetCondition("MATCHING_ATTIRE", "Equip").Complete();
			}
			if (player.armor[10].stack > 0 && player.armor[11].stack > 0 && player.armor[12].stack > 0)
			{
				Main.Achievements.GetCondition("FASHION_STATEMENT", "Equip").Complete();
			}
			bool flag = true;
			for (int p = 0; p < player.extraAccessorySlots + 3 + 5; p++)
			{
				if (player.dye[p].type < 1 || player.dye[p].stack < 1)
				{
					flag = false;
				}
			}
			if (flag)
			{
				Main.Achievements.GetCondition("DYE_HARD", "Equip").Complete();
			}
		}

		public static event AchievementsHelper.ItemCraftEvent OnItemCraft;

		public static event AchievementsHelper.ItemPickupEvent OnItemPickup;

		public static event AchievementsHelper.NPCKilledEvent OnNPCKilled;

		public static event AchievementsHelper.ProgressionEventEvent OnProgressionEvent;

		public static event AchievementsHelper.TileDestroyedEvent OnTileDestroyed;

		public delegate void ItemCraftEvent(short itemId, int count);

		public delegate void ItemPickupEvent(Player player, short itemId, int count);

		public delegate void NPCKilledEvent(Player player, short npcId);

		public delegate void ProgressionEventEvent(int eventID);

		public delegate void TileDestroyedEvent(Player player, ushort itemId);
	}
}
