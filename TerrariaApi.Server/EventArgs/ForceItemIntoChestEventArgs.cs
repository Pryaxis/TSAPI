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
		/// The chest's center position in world coordinates.
		/// This is a shortcut for Vector2(Chest.x*16 + 16, Chest.y*16 + 16)
		/// </summary>
		public Vector2 WorldPosition => new Vector2(Chest.x * 16 + 16, Chest.y * 16 + 16);
		/// <summary>
		/// The chest's position in tile coordinates.
		/// This is a shortcut for Vector2(Chest.x, Chest.y)
		/// </summary>
		public Vector2 TilePosition => new Vector2(Chest.x, Chest.y);
	}
}
