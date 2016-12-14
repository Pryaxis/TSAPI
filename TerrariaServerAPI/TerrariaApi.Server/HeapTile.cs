namespace TerrariaApi.Server
{
	public class HeapTile : Terraria.Tile
    {
        protected readonly int offset;
        protected byte[] heap;

        public const int kHeapTileSize = 13;

        public const int kHeapTileTypeOffset = 0;
        public const int kHeapTileWallOffset = 2;
        public const int kHeapTileLiquidOffset = 3;
        public const int kHeapTileSTileHeaderOffset = 4;
        public const int kHeapTileBTypeHeaderOffset = 6;
        public const int kHeapTileBTypeHeader2Offset = 7;
        public const int kHeapTileBTypeHeader3Offset = 8;
        public const int kHeapTileFrameXOffset = 9;
        public const int kHeapTileFrameYOffset = 11;

        internal int x;
        internal int y;

        public HeapTile(byte[] array, int x, int y)
        {
            heap = array;
            this.offset = (Terraria.Main.maxTilesY * x + y) * kHeapTileSize;
            this.x = x;
            this.y = y;
        }

		public override void Initialise()
		{
			// here we prevent reinitialisation of the tile which would reset the tile in the heap

			//base.Initialise();
		}

		public override ushort type
        {
            get
            {
                return (ushort)((heap[offset + kHeapTileTypeOffset + 1] << 8) | heap[offset + kHeapTileTypeOffset]);
            }

            set
            {
                heap[offset + kHeapTileTypeOffset + 1] = (byte)(value >> 8);
                heap[offset + kHeapTileTypeOffset] = (byte)(value & 0xFF);
            }
        }

        public override byte wall
        {
            get
            {
                return heap[offset + kHeapTileWallOffset];
            }

            set
            {
                heap[offset + kHeapTileWallOffset] = value;
            }
        }

        public override byte liquid
        {
            get
            {
                return heap[offset + kHeapTileLiquidOffset];
            }

            set
            {
                heap[offset + kHeapTileLiquidOffset] = value;
            }
        }

        public override short sTileHeader
        {
            get
            {
                return (short)((heap[offset + kHeapTileSTileHeaderOffset + 1] << 8) | heap[offset + kHeapTileSTileHeaderOffset]);
            }

            set
            {
                heap[offset + kHeapTileSTileHeaderOffset + 1] = (byte)(value >> 8);
                heap[offset + kHeapTileSTileHeaderOffset] = (byte)(value & 0xFF);
            }
        }

        public override byte bTileHeader
        {
            get
            {
                return heap[offset + kHeapTileBTypeHeaderOffset];
            }

            set
            {
                heap[offset + kHeapTileBTypeHeaderOffset] = value;
            }
        }

        public override byte bTileHeader2
        {
            get
            {
                return heap[offset + kHeapTileBTypeHeader2Offset];
            }

            set
            {
                heap[offset + kHeapTileBTypeHeader2Offset] = value;
            }
        }

        public override byte bTileHeader3
        {
            get
            {
                return heap[offset + kHeapTileBTypeHeader3Offset];
            }

            set
            {
                heap[offset + kHeapTileBTypeHeader3Offset] = value;
            }
        }

        public override short frameX
        {
            get
            {
                return (short)((heap[offset + kHeapTileFrameXOffset + 1] << 8) | heap[offset + kHeapTileFrameXOffset]);
            }

            set
            {
                heap[offset + kHeapTileFrameXOffset + 1] = (byte)(value >> 8);
                heap[offset + kHeapTileFrameXOffset] = (byte)(value & 0xFF);
            }
        }

        public override short frameY
        {
            get
            {
                return (short)((heap[offset + kHeapTileFrameYOffset + 1] << 8) | heap[offset + kHeapTileFrameYOffset]);
            }

            set
            {
                heap[offset + kHeapTileFrameYOffset + 1] = (byte)(value >> 8);
                heap[offset + kHeapTileFrameYOffset] = (byte)(value & 0xFF);
            }
        }
    }
}
