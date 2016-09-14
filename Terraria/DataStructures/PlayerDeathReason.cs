using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria.DataStructures
{
	public class PlayerDeathReason
	{
		public static PlayerDeathReason ByNPC(int index)
		{
			return new PlayerDeathReason
			{
				SourceNPCIndex = index
			};
		}

		public static PlayerDeathReason ByOther(int type)
		{
			return new PlayerDeathReason
			{
				SourceOtherIndex = type
			};
		}

		public static PlayerDeathReason ByPlayer(int index)
		{
			return new PlayerDeathReason
			{
				SourcePlayerIndex = index,
				SourceItemType = Main.player[index].inventory[Main.player[index].selectedItem].type
			};
		}

		public static PlayerDeathReason ByProjectilePVP(int playerIndex, int projectileIndex)
		{
			return new PlayerDeathReason
			{
				SourcePlayerIndex = playerIndex,
				SourceProjectileIndex = projectileIndex,
				SourceProjectileType = Main.projectile[projectileIndex].type,
				SourceItemType = Main.player[playerIndex].inventory[Main.player[playerIndex].selectedItem].type
			};
		}

		public string GetDeathText()
		{
			return "";
		}

		private int SourceItemType;

		private int SourceNPCIndex = -1;

		private int SourceOtherIndex = -1;

		private int SourcePlayerIndex = -1;

		private int SourceProjectileIndex = -1;

		private int SourceProjectileType;
	}
}
