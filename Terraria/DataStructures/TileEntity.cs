using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Terraria.GameContent.Tile_Entities;

namespace Terraria.DataStructures
{
	public abstract class TileEntity
	{
		public const int MaxEntitiesPerChunk = 1000;

		public static Dictionary<int, TileEntity> ByID;

		public static Dictionary<Point16, TileEntity> ByPosition;

		public static int TileEntitiesNextID;

		public int ID;

		public Point16 Position;

		public byte type;

		static TileEntity()
		{
			TileEntity.ByID = new Dictionary<int, TileEntity>();
			TileEntity.ByPosition = new Dictionary<Point16, TileEntity>();
			TileEntity.TileEntitiesNextID = 0;
		}

		protected TileEntity()
		{
		}

		public static int AssignNewID()
		{
			int tileEntitiesNextID = TileEntity.TileEntitiesNextID;
			TileEntity.TileEntitiesNextID = tileEntitiesNextID + 1;
			return tileEntitiesNextID;
		}

		public static void InitializeAll()
		{
			TETrainingDummy.Initialize();
		}

		public static TileEntity Read(BinaryReader reader)
		{
			TileEntity tETrainingDummy = null;
			byte num = reader.ReadByte();
			switch (num)
			{
				case 0:
				{
					tETrainingDummy = new TETrainingDummy();
					break;
				}
				case 1:
				{
					tETrainingDummy = new TEItemFrame();
					break;
				}
			}
			tETrainingDummy.type = num;
			tETrainingDummy.ReadInner(reader);
			return tETrainingDummy;
		}

		public virtual void ReadExtraData(BinaryReader reader)
		{
		}

		private void ReadInner(BinaryReader reader)
		{
			this.ID = reader.ReadInt32();
			this.Position = new Point16(reader.ReadInt16(), reader.ReadInt16());
			this.ReadExtraData(reader);
		}

		public virtual void Update()
		{
		}

		public static void UpdateEnd()
		{
			if (TileEntity._UpdateEnd != null)
			{
				TileEntity._UpdateEnd();
			}
		}

		public static void UpdateStart()
		{
			if (TileEntity._UpdateStart != null)
			{
				TileEntity._UpdateStart();
			}
		}

		public static void Write(BinaryWriter writer, TileEntity ent)
		{
			writer.Write(ent.type);
			ent.WriteInner(writer);
		}

		public virtual void WriteExtraData(BinaryWriter writer)
		{
		}

		private void WriteInner(BinaryWriter writer)
		{
			writer.Write(this.ID);
			writer.Write(this.Position.X);
			writer.Write(this.Position.Y);
			this.WriteExtraData(writer);
		}

		public static event Action _UpdateEnd;

		public static event Action _UpdateStart;
	}
}