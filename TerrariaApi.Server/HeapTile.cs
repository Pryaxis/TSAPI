using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaApi.Server
{
    public class HeapTile : Terraria.Tile
    {
        protected int offset;
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

        protected int x;
        protected int y;

        public HeapTile(byte[] array, int x, int y)
        {
            heap = array;
            this.offset = (Terraria.Main.maxTilesY * x + y) * kHeapTileSize;
            this.x = x;
            this.y = y;
        }

        public override ushort type
        {
            get
            {
                return ToUInt16_fast(heap, offset + kHeapTileTypeOffset);
            }

            set
            {
                ToBytes_fast(value, heap, offset + kHeapTileTypeOffset);
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
                return ToInt16_fast(heap, offset + kHeapTileSTileHeaderOffset);
            }

            set
            {
                ToBytes_fast(value, heap, offset + kHeapTileSTileHeaderOffset);
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
                return ToInt16_fast(heap, offset + kHeapTileFrameXOffset);
            }

            set
            {
                ToBytes_fast(value, heap, offset + kHeapTileFrameXOffset);
            }
        }

        public override short frameY
        {
            get
            {
                return ToInt16_fast(heap, offset + kHeapTileFrameYOffset);
            }

            set
            {
                ToBytes_fast(value, heap, offset + kHeapTileFrameYOffset);
            }
        }

        #region Unsafe heap accessor methods

        protected unsafe ushort ToUInt16_fast(byte[] array, int offset)
        {
            fixed (byte *arrayPtr = &array[offset])
            {
                return *(ushort*)arrayPtr;
            }
        }

        protected unsafe void ToBytes_fast(ushort value, byte[] array, int offset)
        {
            fixed (byte* ptr = &array[offset])
            {
                *(ushort*)ptr = value;
            }
        }

        protected unsafe short ToInt16_fast(byte[] array, int offset)
        {
            fixed (byte *arrayPtr = &array[offset])
            {
                return *(short*)arrayPtr;
            }
        }

        protected unsafe void ToBytes_fast(short value, byte[] array, int offset)
        {
            fixed (byte* ptr = &array[offset])
            {
                *(short*)ptr = value;
            }
        }

        #endregion

        public override string ToString()
        {
            return $"[HeapTile type={type} wall={wall} liquid={liquid} sTileHeader={sTileHeader} bHeaders={bTileHeader},{bTileHeader2},{bTileHeader3}]";
        }
    }
}
