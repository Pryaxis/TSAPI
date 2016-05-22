using System;
using System.Collections.Generic;
using System.IO;
using Terraria.DataStructures;

namespace Terraria.GameContent.Tile_Entities
{
	// Token: 0x0200021C RID: 540
	internal class TELogicSensor : TileEntity
	{
		// Token: 0x0600127C RID: 4732 RVA: 0x00422A73 File Offset: 0x00420C73
		public TELogicSensor()
		{
			this.logicCheck = TELogicSensor.LogicCheckType.None;
			this.On = false;
		}

		// Token: 0x0600127A RID: 4730 RVA: 0x00422960 File Offset: 0x00420B60
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
				NetMessage.SendTileSquare(-1, (int)this.Position.X, (int)this.Position.Y, 1);
			}
			if (TripWire && Main.netMode != 1)
			{
				TELogicSensor.tripPoints.Add(this.Position);
			}
		}

		// Token: 0x0600127F RID: 4735 RVA: 0x00422C74 File Offset: 0x00420E74
		public void FigureCheckState()
		{
			this.logicCheck = TELogicSensor.FigureCheckType((int)this.Position.X, (int)this.Position.Y, out this.On);
			TELogicSensor.GetFrame((int)this.Position.X, (int)this.Position.Y, this.logicCheck, this.On);
		}

		// Token: 0x0600127D RID: 4733 RVA: 0x00422A8C File Offset: 0x00420C8C
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

		// Token: 0x06001277 RID: 4727 RVA: 0x00422788 File Offset: 0x00420988
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

		// Token: 0x06001285 RID: 4741 RVA: 0x00423050 File Offset: 0x00421250
		public static int Find(int x, int y)
		{
			TileEntity tileEntity;
			if (TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) && tileEntity.type == 2)
			{
				return tileEntity.ID;
			}
			return -1;
		}

		// Token: 0x06001280 RID: 4736 RVA: 0x00422CD0 File Offset: 0x00420ED0
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

		// Token: 0x0600127E RID: 4734 RVA: 0x00422B10 File Offset: 0x00420D10
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

		// Token: 0x06001283 RID: 4739 RVA: 0x00422E54 File Offset: 0x00421054
		public static int Hook_AfterPlacement(int x, int y, int type = 423, int style = 0, int direction = 1)
		{
			bool on;
			TELogicSensor.LogicCheckType type2 = TELogicSensor.FigureCheckType(x, y, out on);
			TELogicSensor.GetFrame(x, y, type2, on);
			if (Main.netMode == 1)
			{
				NetMessage.SendTileSquare(Main.myPlayer, x, y, 1);
				NetMessage.SendData(87, -1, -1, "", x, (float)y, 2f, 0f, 0, 0, 0);
				return -1;
			}
			int num = TELogicSensor.Place(x, y);
			((TELogicSensor)TileEntity.ByID[num]).FigureCheckState();
			return num;
		}

		// Token: 0x06001274 RID: 4724 RVA: 0x004226D7 File Offset: 0x004208D7
		public static void Initialize()
		{
			TileEntity._UpdateStart += new Action(TELogicSensor.UpdateStartInternal);
			TileEntity._UpdateEnd += new Action(TELogicSensor.UpdateEndInternal);
			TileEntity._NetPlaceEntity += new Action<int, int, int>(TELogicSensor.NetPlaceEntity);
		}

		// Token: 0x06001284 RID: 4740 RVA: 0x00422EC8 File Offset: 0x004210C8
		public static void Kill(int x, int y)
		{
			TileEntity tileEntity;
			if (TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) && tileEntity.type == 2)
			{
				Wiring.blockPlayerTeleportationForOneIteration = true;
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

		// Token: 0x06001275 RID: 4725 RVA: 0x0042270C File Offset: 0x0042090C
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

		// Token: 0x06001282 RID: 4738 RVA: 0x00422DF8 File Offset: 0x00420FF8
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

		// Token: 0x06001287 RID: 4743 RVA: 0x004230A1 File Offset: 0x004212A1
		public override void ReadExtraData(BinaryReader reader, bool networkSend)
		{
			if (!networkSend)
			{
				this.logicCheck = (TELogicSensor.LogicCheckType)reader.ReadByte();
				this.On = reader.ReadBoolean();
			}
		}

		// Token: 0x06001281 RID: 4737 RVA: 0x00422DBF File Offset: 0x00420FBF
		public static bool SanityCheck(int x, int y)
		{
			if (!Main.tile[x, y].active() || Main.tile[x, y].type != 423)
			{
				TELogicSensor.Kill(x, y);
				return false;
			}
			return true;
		}

		// Token: 0x06001288 RID: 4744 RVA: 0x004230C0 File Offset: 0x004212C0
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

		// Token: 0x06001279 RID: 4729 RVA: 0x004228CC File Offset: 0x00420ACC
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

		// Token: 0x06001278 RID: 4728 RVA: 0x004227D8 File Offset: 0x004209D8
		private static void UpdateEndInternal()
		{
			TELogicSensor.inUpdateLoop = false;
			foreach (Point16 current in TELogicSensor.tripPoints)
			{
				Wiring.blockPlayerTeleportationForOneIteration = true;
				Wiring.HitSwitch((int)current.X, (int)current.Y);
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

		// Token: 0x06001276 RID: 4726 RVA: 0x00422760 File Offset: 0x00420960
		private static void UpdateStartInternal()
		{
			TELogicSensor.inUpdateLoop = true;
			TELogicSensor.markedIDsForRemoval.Clear();
			TELogicSensor.playerBox.Clear();
			TELogicSensor.playerBoxFilled = false;
			TELogicSensor.FillPlayerHitboxes();
		}

		// Token: 0x0600127B RID: 4731 RVA: 0x00422A0C File Offset: 0x00420C0C
		public static bool ValidTile(int x, int y)
		{
			return Main.tile[x, y].active() && Main.tile[x, y].type == 423 && Main.tile[x, y].frameY % 18 == 0 && Main.tile[x, y].frameX % 18 == 0;
		}

		// Token: 0x06001286 RID: 4742 RVA: 0x00423083 File Offset: 0x00421283
		public override void WriteExtraData(BinaryWriter writer, bool networkSend)
		{
			if (!networkSend)
			{
				writer.Write((byte)this.logicCheck);
				writer.Write(this.On);
			}
		}

		// Token: 0x0400325E RID: 12894
		public int CountedData;

		// Token: 0x0400325A RID: 12890
		private static bool inUpdateLoop = false;

		// Token: 0x0400325C RID: 12892
		public TELogicSensor.LogicCheckType logicCheck;

		// Token: 0x04003259 RID: 12889
		private static List<int> markedIDsForRemoval = new List<int>();

		// Token: 0x0400325D RID: 12893
		public bool On;

		// Token: 0x04003257 RID: 12887
		private static Dictionary<int, Rectangle> playerBox = new Dictionary<int, Rectangle>();

		// Token: 0x0400325B RID: 12891
		private static bool playerBoxFilled = false;

		// Token: 0x04003258 RID: 12888
		private static List<Point16> tripPoints = new List<Point16>();

		// Token: 0x0200021D RID: 541
		public enum LogicCheckType
		{
			// Token: 0x04003260 RID: 12896
			None,
			// Token: 0x04003261 RID: 12897
			Day,
			// Token: 0x04003262 RID: 12898
			Night,
			// Token: 0x04003263 RID: 12899
			PlayerAbove,
			// Token: 0x04003264 RID: 12900
			Water,
			// Token: 0x04003265 RID: 12901
			Lava,
			// Token: 0x04003266 RID: 12902
			Honey,
			// Token: 0x04003267 RID: 12903
			Liquid
		}
	}
}
