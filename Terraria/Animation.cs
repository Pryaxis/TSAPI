using System;
using System.Collections.Generic;
using Terraria.DataStructures;

namespace Terraria
{
	public class Animation
	{
		private static List<Animation> _animations;

		private static Dictionary<Point16, Animation> _temporaryAnimations;

		private static List<Point16> _awaitingRemoval;

		private static List<Animation> _awaitingAddition;

		private bool _temporary;

		private Point16 _coordinates;

		private ushort _tileType;

		private int _frame;

		private int _frameMax;

		private int _frameCounter;

		private int _frameCounterMax;

		private int[] _frameData;

		public Animation()
		{
		}

		public static bool GetTemporaryFrame(int x, int y, out int frameData)
		{
			Animation animation;
			Point16 point16 = new Point16(x, y);
			if (!Animation._temporaryAnimations.TryGetValue(point16, out animation))
			{
				frameData = 0;
				return false;
			}
			frameData = animation._frameData[animation._frame];
			return true;
		}

		public static void Initialize()
		{
			Animation._animations = new List<Animation>();
			Animation._temporaryAnimations = new Dictionary<Point16, Animation>();
			Animation._awaitingRemoval = new List<Point16>();
			Animation._awaitingAddition = new List<Animation>();
		}

		public static void NewTemporaryAnimation(int type, ushort tileType, int x, int y)
		{
			Point16 point16 = new Point16(x, y);
			if (x < 0 || x >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY)
			{
				return;
			}
			Animation animation = new Animation();
			animation.SetDefaults(type);
			animation._tileType = tileType;
			animation._coordinates = point16;
			animation._temporary = true;
			Animation._awaitingAddition.Add(animation);
			if (Main.netMode == 2)
			{
				NetMessage.SendTemporaryAnimation(-1, type, (int)tileType, x, y);
			}
		}

		private static void RemoveTemporaryAnimation(short x, short y)
		{
			Point16 point16 = new Point16(x, y);
			if (Animation._temporaryAnimations.ContainsKey(point16))
			{
				Animation._awaitingRemoval.Add(point16);
			}
		}

		private void SetDefaults(int type)
		{
			this._tileType = 0;
			this._frame = 0;
			this._frameMax = 0;
			this._frameCounter = 0;
			this._frameCounterMax = 0;
			this._temporary = false;
			switch (type)
			{
				case 0:
				{
					this._frameMax = 5;
					this._frameCounterMax = 12;
					this._frameData = new int[this._frameMax];
					for (int i = 0; i < this._frameMax; i++)
					{
						this._frameData[i] = i + 1;
					}
					return;
				}
				case 1:
				{
					this._frameMax = 5;
					this._frameCounterMax = 12;
					this._frameData = new int[this._frameMax];
					for (int j = 0; j < this._frameMax; j++)
					{
						this._frameData[j] = 5 - j;
					}
					return;
				}
				default:
				{
					return;
				}
			}
		}

		public void Update()
		{
			if (this._temporary)
			{
				Tile tile = Main.tile[this._coordinates.X, this._coordinates.Y];
				if (tile != null && tile.type != this._tileType)
				{
					Animation.RemoveTemporaryAnimation(this._coordinates.X, this._coordinates.Y);
					return;
				}
			}
			Animation animation = this;
			animation._frameCounter = animation._frameCounter + 1;
			if (this._frameCounter >= this._frameCounterMax)
			{
				this._frameCounter = 0;
				Animation animation1 = this;
				animation1._frame = animation1._frame + 1;
				if (this._frame >= this._frameMax)
				{
					this._frame = 0;
					if (this._temporary)
					{
						Animation.RemoveTemporaryAnimation(this._coordinates.X, this._coordinates.Y);
					}
				}
			}
		}

		public static void UpdateAll()
		{
			for (int i = 0; i < Animation._animations.Count; i++)
			{
				Animation._animations[i].Update();
			}
			if (Animation._awaitingAddition.Count > 0)
			{
				for (int j = 0; j < Animation._awaitingAddition.Count; j++)
				{
					Animation item = Animation._awaitingAddition[j];
					Animation._temporaryAnimations[item._coordinates] = item;
				}
				Animation._awaitingAddition.Clear();
			}
			foreach (KeyValuePair<Point16, Animation> _temporaryAnimation in Animation._temporaryAnimations)
			{
				_temporaryAnimation.Value.Update();
			}
			if (Animation._awaitingRemoval.Count > 0)
			{
				for (int k = 0; k < Animation._awaitingRemoval.Count; k++)
				{
					Animation._temporaryAnimations.Remove(Animation._awaitingRemoval[k]);
				}
				Animation._awaitingRemoval.Clear();
			}
		}
	}
}