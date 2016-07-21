using System;
using System.Collections.Generic;
using System.Linq;

namespace Terraria.GameContent.Events
{
	internal class BirthdayParty
	{
		public static bool ManualParty = false;

		public static bool GenuineParty = false;

		public static int PartyDaysOnCooldown = 0;

		public static List<int> CelebratingNPCs = new List<int>();

		private static bool _wasCelebrating = false;

		public static bool PartyIsUp
		{
			get
			{
				return BirthdayParty.GenuineParty || BirthdayParty.ManualParty;
			}
		}

		public static void CheckMorning()
		{
			BirthdayParty.NaturalAttempt();
		}

		public static void CheckNight()
		{
			bool flag = false;
			if (BirthdayParty.GenuineParty)
			{
				flag = true;
				BirthdayParty.GenuineParty = false;
				BirthdayParty.CelebratingNPCs.Clear();
			}
			if (BirthdayParty.ManualParty)
			{
				flag = true;
				BirthdayParty.ManualParty = false;
			}
			if (flag)
			{
				Color color = new Color(255, 0, 160);
				WorldGen.BroadcastText(Lang.misc[99], color);
			}
		}

		private static void NaturalAttempt()
		{
			if (BirthdayParty.PartyDaysOnCooldown > 0)
			{
				BirthdayParty.PartyDaysOnCooldown--;
				return;
			}
			if (Main.rand.Next(10) != 0)
			{
				return;
			}
			List<NPC> list = new List<NPC>();
			for (int l = 0; l < 200; l++)
			{
				NPC nPC = Main.npc[l];
				if (nPC.active && nPC.townNPC && nPC.type != 37 && nPC.type != 453 && nPC.aiStyle != 0)
				{
					list.Add(nPC);
				}
			}
			if (list.Count < 5)
			{
				return;
			}
			BirthdayParty.GenuineParty = true;
			BirthdayParty.PartyDaysOnCooldown = Main.rand.Next(5, 11);
			BirthdayParty.CelebratingNPCs.Clear();
			List<int> list2 = new List<int>();
			int num = 1;
			if (Main.rand.Next(5) == 0 && list.Count > 12)
			{
				num = 3;
			}
			else if (Main.rand.Next(3) == 0)
			{
				num = 2;
			}
			list = (from i in list
			orderby Main.rand.Next()
			select i).ToList<NPC>();
			for (int j = 0; j < num; j++)
			{
				list2.Add(j);
			}
			for (int k = 0; k < list2.Count; k++)
			{
				BirthdayParty.CelebratingNPCs.Add(list[list2[k]].whoAmI);
			}
			Color color = new Color(255, 0, 160);
			if (BirthdayParty.CelebratingNPCs.Count == 3)
			{
				WorldGen.BroadcastText(string.Concat(new string[]
				{
					Lang.misc[96],
					Main.npc[BirthdayParty.CelebratingNPCs[0]].displayName,
					", ",
					Main.npc[BirthdayParty.CelebratingNPCs[1]].displayName,
					" & ",
					Main.npc[BirthdayParty.CelebratingNPCs[2]].displayName,
					Lang.misc[98]
				}), color);
				return;
			}
			if (BirthdayParty.CelebratingNPCs.Count == 2)
			{
				WorldGen.BroadcastText(string.Concat(new string[]
				{
					Lang.misc[96],
					Main.npc[BirthdayParty.CelebratingNPCs[0]].displayName,
					" & ",
					Main.npc[BirthdayParty.CelebratingNPCs[1]].displayName,
					Lang.misc[98]
				}), color);
				return;
			}
			WorldGen.BroadcastText(Lang.misc[96] + Main.npc[BirthdayParty.CelebratingNPCs[0]].displayName + Lang.misc[97], color);
		}

		public static void ToggleManualParty()
		{
			bool partyIsUp = BirthdayParty.PartyIsUp;
			if (Main.netMode != 1)
			{
				BirthdayParty.ManualParty = !BirthdayParty.ManualParty;
			}
			else
			{
				NetMessage.SendData(111, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
			}
			if (partyIsUp != BirthdayParty.PartyIsUp && Main.netMode == 2)
			{
				NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
			}
		}

		public static void WorldClear()
		{
			BirthdayParty.ManualParty = false;
			BirthdayParty.GenuineParty = false;
			BirthdayParty.PartyDaysOnCooldown = 0;
			BirthdayParty.CelebratingNPCs.Clear();
			BirthdayParty._wasCelebrating = false;
		}

		public static void UpdateTime()
		{
			if (BirthdayParty._wasCelebrating != BirthdayParty.PartyIsUp)
			{
				if (Main.netMode != 1 && BirthdayParty.CelebratingNPCs.Count > 0)
				{
					for (int i = 0; i < BirthdayParty.CelebratingNPCs.Count; i++)
					{
						NPC nPC = Main.npc[BirthdayParty.CelebratingNPCs[i]];
						if (!nPC.active || !nPC.townNPC || nPC.type == 37 || nPC.type == 453 || nPC.aiStyle == 0)
						{
							BirthdayParty.CelebratingNPCs.RemoveAt(i);
						}
					}
					if (BirthdayParty.CelebratingNPCs.Count == 0)
					{
						BirthdayParty.GenuineParty = false;
						if (!BirthdayParty.ManualParty)
						{
							Color color = new Color(255, 0, 160);
							WorldGen.BroadcastText(Lang.misc[99], color);
							NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						}
					}
				}
			}
			BirthdayParty._wasCelebrating = BirthdayParty.PartyIsUp;
		}
	}
}
