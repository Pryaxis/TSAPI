using System.ComponentModel;
using Terraria;

namespace TerrariaApi.Server
{
	public class ForceItemIntoChestEventArgs : HandledEventArgs
	{
		/// <summary>
		/// The player who caused this event
		/// </summary>
		public Player Player;
		/// <summary>
		/// The chest the item is being forced into
		/// </summary>
		public Chest Chest;
		/// <summary>
		/// The item being forced into the chest
		/// </summary>
		public Item Item;
		/// <summary>
		/// The chest's position
		/// </summary>
		public Vector2 Position;
	}
}
