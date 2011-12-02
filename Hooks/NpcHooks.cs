using System;
using Terraria;
namespace Hooks
{
	public static class NpcHooks
	{
		public delegate void StrikeNpcD(NpcStrikeEventArgs e);
		public static event SetDefaultsD<NPC, int> SetDefaultsInt;
		public static event SetDefaultsD<NPC, string> SetDefaultsString;
		public static event NpcHooks.StrikeNpcD StrikeNpc;
		public static void OnSetDefaultsInt(ref int npctype, NPC npc)
		{
			if (NpcHooks.SetDefaultsInt == null)
			{
				return;
			}
			SetDefaultsEventArgs<NPC, int> setDefaultsEventArgs = new SetDefaultsEventArgs<NPC, int>
			{
				Object = npc, 
				Info = npctype
			};
			NpcHooks.SetDefaultsInt(setDefaultsEventArgs);
			npctype = setDefaultsEventArgs.Info;
		}
		public static void OnSetDefaultsString(ref string npcname, NPC npc)
		{
			if (NpcHooks.SetDefaultsString == null)
			{
				return;
			}
			SetDefaultsEventArgs<NPC, string> setDefaultsEventArgs = new SetDefaultsEventArgs<NPC, string>
			{
				Object = npc, 
				Info = npcname
			};
			NpcHooks.SetDefaultsString(setDefaultsEventArgs);
			npcname = setDefaultsEventArgs.Info;
		}
		public static bool OnStrikeNpc(NPC npc, ref int damage, ref float knockback, ref int hitdirection, ref double retdamage)
		{
			if (NpcHooks.StrikeNpc == null)
			{
				return false;
			}
			NpcStrikeEventArgs npcStrikeEventArgs = new NpcStrikeEventArgs
			{
				Npc = npc, 
				Damage = damage, 
				KnockBack = knockback, 
				HitDirection = hitdirection, 
				ReturnDamage = 0.0
			};
			NpcHooks.StrikeNpc(npcStrikeEventArgs);
			retdamage = npcStrikeEventArgs.ReturnDamage;
			damage = npcStrikeEventArgs.Damage;
			knockback = npcStrikeEventArgs.KnockBack;
			hitdirection = npcStrikeEventArgs.HitDirection;
			return npcStrikeEventArgs.Handled;
		}
	}
}
