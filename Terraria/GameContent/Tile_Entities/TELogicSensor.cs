using System;
using System.Collections.Generic;
using System.IO;
using Terraria.DataStructures;
using Terraria.ID;

namespace Terraria.GameContent.Tile_Entities
{
	public class TELogicSensor : TileEntity
	{
		public TELogicSensor()
		{
			this.logicCheck = TELogicSensor.LogicCheckType.None;
			this.On = false;
		}

		public void ChangeState(bool onState, bool TripWire)
		{
			if (onState != this.On && !TELogicSensor.SanityCheck((int)this.Position.X, (int)this.Position.Y))
			{
				return;
			}
			Main.tile[(int)this.Position.X, (int)this.Position.Y].frameX = (short)(onState ? 18 : 0);
			this.On = onState;
			if (Main.netMode == 2)
			{
				NetMessage.SendTileSquare(-1, (int)this.Position.X, (int)this.Position.Y, 1, TileChangeType.None);
			}
			if (TripWire && Main.netMode != 1)
			{
				TELogicSensor.tripPoints.Add(Tuple.Create<Point16, bool>(this.Position, this.logicCheck == TELogicSensor.LogicCheckType.PlayerAbove));
			}
		}

		public void FigureCheckState()
		{
			this.logicCheck = TELogicSensor.FigureCheckType((int)this.Position.X, (int)this.Position.Y, out this.On);
			TELogicSensor.GetFrame((int)this.Position.X, (int)this.Position.Y, this.logicCheck, this.On);
		}

		public static TELogicSensor.LogicCheckType FigureCheckType(int x, int y, out bool on)
		{
			on = false;
			if (!WorldGen.InWorld(x, y, 0))
			{
				return TELogicSensor.LogicCheckType.None;
			}
			Tile tile = Main.tile[x, y];
			if (tile == null)
			{
				return TELogicSensor.LogicCheckType.None;
			}
			TELogicSensor.LogicCheckType logicCheckType = TELogicSensor.LogicCheckType.None;
			switch (tile.frameY / 18)
			{
			case 0:
				logicCheckType = TELogicSensor.LogicCheckType.Day;
				break;
			case 1:
				logicCheckType = TELogicSensor.LogicCheckType.Night;
				break;
			case 2:
				logicCheckType = TELogicSensor.LogicCheckType.PlayerAbove;
				break;
			case 3:
				logicCheckType = TELogicSensor.LogicCheckType.Water;
				break;
			case 4:
				logicCheckType = TELogicSensor.LogicCheckType.Lava;
				break;
			case 5:
				logicCheckType = TELogicSensor.LogicCheckType.Honey;
				break;
			case 6:
				logicCheckType = TELogicSensor.LogicCheckType.Liquid;
				break;
			}
			on = TELogicSensor.GetState(x, y, logicCheckType, null);
			return logicCheckType;
		}

		private static void FillPlayerHitboxes()
		{
			if (!TELogicSensor.playerBoxFilled)
			{
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active)
					{
						TELogicSensor.playerBox[i] = Main.player[i].getRect();
					}
				}
				TELogicSensor.playerBoxFilled = true;
			}
		}

		public static int Find(int x, int y)
		{
			TileEntity tileEntity;
			if (TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) && tileEntity.type == 2)
			{
				return tileEntity.ID;
			}
			return -1;
		}

		public static void GetFrame(int x, int y, TELogicSensor.LogicCheckType type, bool on)
		{
			Main.tile[x, y].frameX = (short)(on ? 18 : 0);
			switch (type)
			{
			case TELogicSensor.LogicCheckType.Day:
				Main.tile[x, y].frameY = 0;
				return;
			case TELogicSensor.LogicCheckType.Night:
				Main.tile[x, y].frameY = 18;
				return;
			case TELogicSensor.LogicCheckType.PlayerAbove:
				Main.tile[x, y].frameY = 36;
				return;
			case TELogicSensor.LogicCheckType.Water:
				Main.tile[x, y].frameY = 54;
				return;
			case TELogicSensor.LogicCheckType.Lava:
				Main.tile[x, y].frameY = 72;
				return;
			case TELogicSensor.LogicCheckType.Honey:
				Main.tile[x, y].frameY = 90;
				return;
			case TELogicSensor.LogicCheckType.Liquid:
				Main.tile[x, y].frameY = 108;
				return;
			default:
				Main.tile[x, y].frameY = 0;
				return;
			}
		}

		public static bool GetState(int x, int y, TELogicSensor.LogicCheckType type, TELogicSensor instance = null)
		{
			switch (type)
			{
			case TELogicSensor.LogicCheckType.Day:
				return Main.dayTime;
			case TELogicSensor.LogicCheckType.Night:
				return !Main.dayTime;
			case TELogicSensor.LogicCheckType.PlayerAbove:
			{
				bool result = false;
				Rectangle value = new Rectangle(x * 16 - 32 - 1, y * 16 - 160 - 1, 82, 162);
				foreach (KeyValuePair<int, Rectangle> current in TELogicSensor.playerBox)
				{
					if (current.Value.Intersects(value))
					{
						result = true;
						break;
					}
				}
				return result;
			}
			case TELogicSensor.LogicCheckType.Water:
			case TELogicSensor.LogicCheckType.Lava:
			case TELogicSensor.LogicCheckType.Honey:
			case TELogicSensor.LogicCheckType.Liquid:
			{
				if (instance == null)
				{
					return false;
				}
				Tile tile = Main.tile[x, y];
				bool flag = true;
				if (tile == null || tile.liquid == 0)
				{
					flag = false;
				}
				if (!tile.lava() && type == TELogicSensor.LogicCheckType.Lava)
				{
					flag = false;
				}
				if (!tile.honey() && type == TELogicSensor.LogicCheckType.Honey)
				{
					flag = false;
				}
				if ((tile.honey() || tile.lava()) && type == TELogicSensor.LogicCheckType.Water)
				{
					flag = false;
				}
				if (!flag && instance.On)
				{
					if (instance.CountedData == 0)
					{
						instance.CountedData = 15;
					}
					else if (instance.CountedData > 0)
					{
						instance.CountedData--;
					}
					flag = (instance.CountedData > 0);
				}
				return flag;
			}
			default:
				return false;
			}
		}

		public static int Hook_AfterPlacement(int x, int y, int type = 423, int style = 0, int direction = 1)
		{
			bool on;
			TELogicSensor.LogicCheckType type2 = TELogicSensor.FigureCheckType(x, y, out on);
			TELogicSensor.GetFrame(x, y, type2, on);
			if (Main.netMode == 1)
			{
				NetMessage.SendTileSquare(Main.myPlayer, x, y, 1, TileChangeType.None);
				NetMessage.SendData(87, -1, -1, "", x, (float)y, 2f, 0f, 0, 0, 0);
				return -1;
			}
			int num = TELogicSensor.Place(x, y);
			((TELogicSensor)TileEntity.ByID[num]).FigureCheckState();
			return num;
		}

		public static void Initialize()
		{
			TileEntity._UpdateStart += new Action(TELogicSensor.UpdateStartInternal);
			TileEntity._UpdateEnd += new Action(TELogicSensor.UpdateEndInternal);
			TileEntity._NetPlaceEntity += new Action<int, int, int>(TELogicSensor.NetPlaceEntity);
		}

		public static void Kill(int x, int y)
		{
			TileEntity tileEntity;
			if (TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) && tileEntity.type == 2)
			{
				Wiring.blockPlayerTeleportationForOneIteration = (((TELogicSensor)tileEntity).logicCheck == TELogicSensor.LogicCheckType.PlayerAbove);
				if (((TELogicSensor)tileEntity).logicCheck == TELogicSensor.LogicCheckType.PlayerAbove && ((TELogicSensor)tileEntity).On)
				{
					Wiring.HitSwitch((int)tileEntity.Position.X, (int)tileEntity.Position.Y);
				}
				if (((TELogicSensor)tileEntity).logicCheck == TELogicSensor.LogicCheckType.Water && ((TELogicSensor)tileEntity).On)
				{
					Wiring.HitSwitch((int)tileEntity.Position.X, (int)tileEntity.Position.Y);
				}
				if (((TELogicSensor)tileEntity).logicCheck == TELogicSensor.LogicCheckType.Lava && ((TELogicSensor)tileEntity).On)
				{
					Wiring.HitSwitch((int)tileEntity.Position.X, (int)tileEntity.Position.Y);
				}
				if (((TELogicSensor)tileEntity).logicCheck == TELogicSensor.LogicCheckType.Honey && ((TELogicSensor)tileEntity).On)
				{
					Wiring.HitSwitch((int)tileEntity.Position.X, (int)tileEntity.Position.Y);
				}
				if (((TELogicSensor)tileEntity).logicCheck == TELogicSensor.LogicCheckType.Liquid && ((TELogicSensor)tileEntity).On)
				{
					Wiring.HitSwitch((int)tileEntity.Position.X, (int)tileEntity.Position.Y);
				}
				Wiring.blockPlayerTeleportationForOneIteration = false;
				if (TELogicSensor.inUpdateLoop)
				{
					TELogicSensor.markedIDsForRemoval.Add(tileEntity.ID);
					return;
				}
				TileEntity.ByPosition.Remove(new Point16(x, y));
				TileEntity.ByID.Remove(tileEntity.ID);
			}
		}

		public static void NetPlaceEntity(int x, int y, int type)
		{
			if (type != 2)
			{
				return;
			}
			if (!TELogicSensor.ValidTile(x, y))
			{
				return;
			}
			int num = TELogicSensor.Place(x, y);
			((TELogicSensor)TileEntity.ByID[num]).FigureCheckState();
			NetMessage.SendData(86, -1, -1, "", num, (float)x, (float)y, 0f, 0, 0, 0);
		}

		public static int Place(int x, int y)
		{
			TELogicSensor tELogicSensor = new TELogicSensor();
			tELogicSensor.Position = new Point16(x, y);
			tELogicSensor.ID = TileEntity.AssignNewID();
			tELogicSensor.type = 2;
			TileEntity.ByID[tELogicSensor.ID] = tELogicSensor;
			TileEntity.ByPosition[tELogicSensor.Position] = tELogicSensor;
			return tELogicSensor.ID;
		}

		public override void ReadExtraData(BinaryReader reader, bool networkSend)
		{
			if (!networkSend)
			{
				this.logicCheck = (TELogicSensor.LogicCheckType)reader.ReadByte();
				this.On = reader.ReadBoolean();
			}
		}

		public static bool SanityCheck(int x, int y)
		{
			if (!Main.tile[x, y].active() || Main.tile[x, y].type != 423)
			{
				TELogicSensor.Kill(x, y);
				return false;
			}
			return true;
		}

		public override string ToString()
		{
			return string.Concat(new object[]
			{
				this.Position.X,
				"x  ",
				this.Position.Y,
				"y ",
				this.logicCheck
			});
		}

		public override void Update()
		{
			bool state = TELogicSensor.GetState((int)this.Position.X, (int)this.Position.Y, this.logicCheck, this);
			switch (this.logicCheck)
			{
			case TELogicSensor.LogicCheckType.Day:
			case TELogicSensor.LogicCheckType.Night:
				if (!this.On && state)
				{
					this.ChangeState(true, true);
				}
				if (this.On && !state)
				{
					this.ChangeState(false, false);
					return;
				}
				break;
			case TELogicSensor.LogicCheckType.PlayerAbove:
			case TELogicSensor.LogicCheckType.Water:
			case TELogicSensor.LogicCheckType.Lava:
			case TELogicSensor.LogicCheckType.Honey:
			case TELogicSensor.LogicCheckType.Liquid:
				if (this.On != state)
				{
					this.ChangeState(state, true);
				}
				break;
			default:
				return;
			}
		}

		private static void UpdateEndInternal()
		{
			TELogicSensor.inUpdateLoop = false;
			foreach (Tuple<Point16, bool> current in TELogicSensor.tripPoints)
			{
				Wiring.blockPlayerTeleportationForOneIteration = current.Item2;
				Wiring.HitSwitch((int)current.Item1.X, (int)current.Item1.Y);
			}
			Wiring.blockPlayerTeleportationForOneIteration = false;
			TELogicSensor.tripPoints.Clear();
			foreach (int current2 in TELogicSensor.markedIDsForRemoval)
			{
				TileEntity tileEntity;
				if (TileEntity.ByID.TryGetValue(current2, out tileEntity) && tileEntity.type == 2)
				{
					TileEntity.ByID.Remove(current2);
				}
				TileEntity.ByPosition.Remove(tileEntity.Position);
			}
			TELogicSensor.markedIDsForRemoval.Clear();
		}

		private static void UpdateStartInternal()
		{
			TELogicSensor.inUpdateLoop = true;
			TELogicSensor.markedIDsForRemoval.Clear();
			TELogicSensor.playerBox.Clear();
			TELogicSensor.playerBoxFilled = false;
			TELogicSensor.FillPlayerHitboxes();
		}

		public static bool ValidTile(int x, int y)
		{
			return Main.tile[x, y].active() && Main.tile[x, y].type == 423 && Main.tile[x, y].frameY % 18 == 0 && Main.tile[x, y].frameX % 18 == 0;
		}

		public override void WriteExtraData(BinaryWriter writer, bool networkSend)
		{
			if (!networkSend)
			{
				writer.Write((byte)this.logicCheck);
				writer.Write(this.On);
			}
		}

		public int CountedData;
		private static bool inUpdateLoop = false;
		public TELogicSensor.LogicCheckType logicCheck;
		private static List<int> markedIDsForRemoval = new List<int>();
		public bool On;
		private static Dictionary<int, Rectangle> playerBox = new Dictionary<int, Rectangle>();
		private static bool playerBoxFilled = false;
		private static List<Tuple<Point16, bool>> tripPoints = new List<Tuple<Point16, bool>>();
		
		public enum LogicCheckType
		{
			None,
			Day,
			Night,
			PlayerAbove,
			Water,
			Lava,
			Honey,
			Liquid
		}
	}
}
