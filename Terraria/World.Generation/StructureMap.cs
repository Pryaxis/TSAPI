
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace Terraria.World.Generation
{
	public class StructureMap
	{
		private List<Rectangle> _structures = new List<Rectangle>(2048);

		public StructureMap()
		{
		}

		public void AddStructure(Rectangle area, int padding = 0)
		{
			Rectangle rectangle = new Rectangle(area.X - padding, area.Y - padding, area.Width + padding * 2, area.Height + padding * 2);
			this._structures.Add(rectangle);
		}

		public bool CanPlace(Rectangle area, int padding = 0)
		{
			return this.CanPlace(area, TileID.Sets.GeneralPlacementTiles, padding);
		}

		public bool CanPlace(Rectangle area, bool[] validTiles, int padding = 0)
		{
			if (area.X < 0 || area.Y < 0 || area.X + area.Width > Main.maxTilesX - 1 || area.Y + area.Height > Main.maxTilesY - 1)
			{
				return false;
			}
			Rectangle rectangle = new Rectangle(area.X - padding, area.Y - padding, area.Width + padding * 2, area.Height + padding * 2);
			for (int i = 0; i < this._structures.Count; i++)
			{
				if (rectangle.Intersects(this._structures[i]))
				{
					return false;
				}
			}
			for (int j = rectangle.X; j < rectangle.X + rectangle.Width; j++)
			{
				for (int k = rectangle.Y; k < rectangle.Y + rectangle.Height; k++)
				{
					if (Main.tile[j, k].active() && !validTiles[Main.tile[j, k].type])
					{
						return false;
					}
				}
			}
			return true;
		}

		public void Reset()
		{
			this._structures.Clear();
		}
	}
}