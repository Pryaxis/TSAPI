using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace TerrariaApi.Server
{
    /// <summary>
    /// Provides an abstraction layer between Terraria's tile mechanism and the various mechanisms that
    /// provide the data to TSAPI.
    /// </summary>
    public class TileProvider : OTAPI.Tile.ITileCollection
    {
        /// <summary>
        /// Holds the tile heap.
        /// </summary>
        /// <remarks>
        /// The tile heap is a flat list of tiles, 13-bytes each full of tile header data.
        /// </remarks>
        protected byte[] tileHeap;

        protected HeapTile lastTile;

        protected readonly object syncRoot = new object();

        public int Width { get; private set; }

        public int Height { get; private set; }

        /// <summary>
        /// Retrieves the Terraria.Tile instance at X and Y position.  Used for ABI compatibility with all of
        /// TSAPI's tile accessor mechansims.
        /// </summary>
        /// <param name="x">X coordinate of the tile to retrieve</param>
        /// <param name="y">Y coordinate of the tile to retrieve</param>
        /// <returns>
        /// A Terraria.Tile instance of the tile at the X and Y coordinate
        /// </returns>
        public OTAPI.Tile.ITile this[int x, int y]
        {
            get
            {
				if (tileHeap == null)
                {
                    this.Width = Terraria.Main.maxTilesX;
                    this.Height = Terraria.Main.maxTilesY;
                    /*
                     * The checker must be null here, because Main.maxTilesX is always
                     * initialized to the large world size, wasting RAM for smaller
                     * and medium maps.
                     */
                    tileHeap = new byte[HeapTile.kHeapTileSize * ((Terraria.Main.maxTilesX + 1) * (Terraria.Main.maxTilesY + 1))];
                }

                return GetTile(x, y);
            }
            set
            {
                SetTile(value, x, y);
            }
        }

        /// <summary>
        /// Retrieves a tile at position X and Y.
        /// </summary>
        /// <param name="x">The X coordinate of the tile to retrieve</param>
        /// <param name="y">The Y coordinate of the tile to retrieve</param>
        /// <returns>
        /// A Terraria.Tile instance of the tile at position X and Y.
        /// </returns>
        /// <remarks>
        /// Virtual function that derivatives must override if they want to implement getting of a tile from
        /// its backing store.        /// </remarks>
        protected virtual OTAPI.Tile.ITile GetTile(int x, int y)
        {
            HeapTile tile;

            lock (syncRoot)
            {
                if (lastTile != null && x == lastTile.x && y == lastTile.y)
                {
                    return lastTile;
                }
                tile = lastTile = new HeapTile(tileHeap, x, y);
            }

            return tile;
        }

        /// <summary>
        /// Sets a tile at position X and Y to the tile instance specified.
        /// </summary>
        /// <param name="tile">
        /// A tile instance in which to store
        /// </param>
        /// <param name="x">X coordinate of the tile to store</param>
        /// <param name="y">Y coordinate of the tile to store</param>
        /// <remarks>
        /// Virtual function that derivatives must override if they want to implement getting of a tile from
        /// its backing store.
        /// </remarks>
        protected virtual void SetTile(OTAPI.Tile.ITile tile, int x, int y)
        {
            HeapTile heapTile = new HeapTile(tileHeap, x, y);
            heapTile.CopyFrom(tile);
        }
    }
}
