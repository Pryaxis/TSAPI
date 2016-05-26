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

		public static TileEntity Read(BinaryReader reader, bool networkSend = false)
		{
			TileEntity tileEntity = null;
			byte b = reader.ReadByte();
			switch (b)
			{
			case 0:
				tileEntity = new TETrainingDummy();
				break;
			case 1:
				tileEntity = new TEItemFrame();
				break;
			case 2:
				tileEntity = new TELogicSensor();
				break;
			}
			tileEntity.type = b;
			tileEntity.ReadInner(reader, networkSend);
			return tileEntity;
		}

        public virtual void ReadExtraData(BinaryReader reader, bool networkSend)
        {
        }

		private void ReadInner(BinaryReader reader, bool networkSend)
		{
			if (!networkSend)
			{
				this.ID = reader.ReadInt32();
			}
			this.Position = new Point16(reader.ReadInt16(), reader.ReadInt16());
			this.ReadExtraData(reader, networkSend);
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

        public static void Write(BinaryWriter writer, TileEntity ent, bool networkSend = false)
        {
            writer.Write(ent.type);
            ent.WriteInner(writer, networkSend);
        }


        public virtual void WriteExtraData(BinaryWriter writer, bool networkSend)
        {
        }


        private void WriteInner(BinaryWriter writer, bool networkSend)
        {
            if (!networkSend)
            {
                writer.Write(this.ID);
            }
            writer.Write(this.Position.X);
            writer.Write(this.Position.Y);
            this.WriteExtraData(writer, networkSend);
        }

        public static event Action _UpdateEnd;

        public static event Action _UpdateStart;

        #region 1.3.1

        public static event Action<int, int, int> _NetPlaceEntity;

        public static void Clear()
        {
            TileEntity.ByID.Clear();
            TileEntity.ByPosition.Clear();
            TileEntity.TileEntitiesNextID = 0;
        }

        #endregion
    }
}