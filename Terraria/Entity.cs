using XNA;
using System;

namespace Terraria
{
	public abstract class Entity
	{
		public string name = "";

		public int whoAmI;

		public bool active;

		public Vector2 position;

		public Vector2 velocity;

		public Vector2 oldPosition;

		public Vector2 oldVelocity;

		public int oldDirection;

		public int direction = 1;

		public int width;

		public int height;

		public bool wet;

		public bool honeyWet;

		public byte wetCount;

		public bool lavaWet;

		public Vector2 Bottom
		{
			get
			{
				return new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)this.height);
			}
			set
			{
				this.position = new Vector2(value.X - (float)(this.width / 2), value.Y - (float)this.height);
			}
		}

		public Vector2 Center
		{
			get
			{
				return new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2));
			}
			set
			{
				this.position = new Vector2(value.X - (float)(this.width / 2), value.Y - (float)(this.height / 2));
			}
		}

		public Rectangle Hitbox
		{
			get
			{
				return new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
			}
			set
			{
				this.position = new Vector2((float)value.X, (float)value.Y);
				this.width = value.Width;
				this.height = value.Height;
			}
		}

		public Vector2 Left
		{
			get
			{
				return new Vector2(this.position.X, this.position.Y + (float)(this.height / 2));
			}
			set
			{
				this.position = new Vector2(value.X, value.Y - (float)(this.height / 2));
			}
		}

		public Vector2 Right
		{
			get
			{
				return new Vector2(this.position.X + (float)this.width, this.position.Y + (float)(this.height / 2));
			}
			set
			{
				this.position = new Vector2(value.X - (float)this.width, value.Y - (float)(this.height / 2));
			}
		}

		public Vector2 Size
		{
			get
			{
				return new Vector2((float)this.width, (float)this.height);
			}
			set
			{
				this.width = (int)value.X;
				this.height = (int)value.Y;
			}
		}

		public Vector2 Top
		{
			get
			{
				return new Vector2(this.position.X + (float)(this.width / 2), this.position.Y);
			}
			set
			{
				this.position = new Vector2(value.X - (float)(this.width / 2), value.Y);
			}
		}

		protected Entity()
		{
		}

		public float AngleFrom(Vector2 Source)
		{
			return (float)Math.Atan2((double)(this.Center.Y - Source.Y), (double)(this.Center.X - Source.X));
		}

		public float AngleTo(Vector2 Destination)
		{
			return (float)Math.Atan2((double)(Destination.Y - this.Center.Y), (double)(Destination.X - this.Center.X));
		}

		public Vector2 DirectionFrom(Vector2 Source)
		{
			return Vector2.Normalize(this.Center - Source);
		}

		public Vector2 DirectionTo(Vector2 Destination)
		{
			return Vector2.Normalize(Destination - this.Center);
		}

		public float Distance(Vector2 Other)
		{
			return Vector2.Distance(this.Center, Other);
		}

		public float DistanceSQ(Vector2 Other)
		{
			return Vector2.DistanceSquared(this.Center, Other);
		}

		public bool WithinRange(Vector2 Target, float MaxRange)
		{
			return Vector2.DistanceSquared(this.Center, Target) <= MaxRange * MaxRange;
		}
	}
}