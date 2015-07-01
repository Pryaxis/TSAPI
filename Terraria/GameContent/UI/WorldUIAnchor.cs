using Microsoft.Xna.Framework;
using System;
using Terraria;

namespace Terraria.GameContent.UI
{
	public class WorldUIAnchor
	{
		public WorldUIAnchor.AnchorType type;

		public Entity entity;

		public Vector2 pos = Vector2.Zero;

		public Vector2 size = Vector2.Zero;

		public WorldUIAnchor()
		{
			this.type = WorldUIAnchor.AnchorType.None;
		}

		public WorldUIAnchor(Entity anchor)
		{
			this.type = WorldUIAnchor.AnchorType.Entity;
			this.entity = anchor;
		}

		public WorldUIAnchor(Vector2 anchor)
		{
			this.type = WorldUIAnchor.AnchorType.Pos;
			this.pos = anchor;
		}

		public WorldUIAnchor(int topLeftX, int topLeftY, int width, int height)
		{
			this.type = WorldUIAnchor.AnchorType.Tile;
			this.pos = new Vector2((float)topLeftX + (float)width / 2f, (float)topLeftY + (float)height / 2f) * 16f;
			this.size = new Vector2((float)width, (float)height) * 16f;
		}

		public bool InRange(Vector2 target, float tileRangeX, float tileRangeY)
		{
			switch (this.type)
			{
				case WorldUIAnchor.AnchorType.Entity:
				{
					if (Math.Abs(target.X - this.entity.Center.X) > tileRangeX * 16f + (float)this.entity.width / 2f)
					{
						return false;
					}
					return Math.Abs(target.Y - this.entity.Center.Y) <= tileRangeY * 16f + (float)this.entity.height / 2f;
				}
				case WorldUIAnchor.AnchorType.Tile:
				{
					if (Math.Abs(target.X - this.pos.X) > tileRangeX * 16f + this.size.X / 2f)
					{
						return false;
					}
					return Math.Abs(target.Y - this.pos.Y) <= tileRangeY * 16f + this.size.Y / 2f;
				}
				case WorldUIAnchor.AnchorType.Pos:
				{
					if (Math.Abs(target.X - this.pos.X) > tileRangeX * 16f)
					{
						return false;
					}
					return Math.Abs(target.Y - this.pos.Y) <= tileRangeY * 16f;
				}
			}
			return true;
		}

		public enum AnchorType
		{
			Entity,
			Tile,
			Pos,
			None
		}
	}
}