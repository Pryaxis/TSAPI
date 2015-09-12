using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaApi.Server
{
    /// <summary>
    /// Provides an abstraction layer between Terraria's tile mechanism and the various mechanisms that
    /// provide the data to TSAPI.
    /// </summary>
    public class TileProvider
    {
        protected byte[] tileHeap;
        //protected bool[] nullTiles;

        //public static Terraria.Tile[,] tiles = new Terraria.Tile[Terraria.Main.maxTilesX, Terraria.Main.maxTilesY];
        /// <summary>
        /// Retrieves the Terraria.Tile instance at X and Y position.  Used for ABI compatibility with all of
        /// TSAPI's tile accessor mechansims.
        /// </summary>
        /// <param name="x">X coordinate of the tile to retrieve</param>
        /// <param name="y">Y coordinate of the tile to retrieve</param>
        /// <returns>
        /// A Terraria.Tile instance of the tile at the X and Y coordinate
        /// </returns>
        public Terraria.Tile this[int x, int y]
        {
            get
            {
                if (tileHeap == null)
                {
                    /*
                     * The checker must be null here, because Main.maxTilesX is always
                     * initialized to the large world size, wasting RAM for smaller
                     * and medium maps.
                     */
                    tileHeap = new byte[HeapTile.kHeapTileSize * (Terraria.Main.maxTilesX * Terraria.Main.maxTilesY + 1)];
                    //nullTiles = new bool[Terraria.Main.maxTilesX * Terraria.Main.maxTilesY];
                    //for (int i = 0; i < nullTiles.Length; i++)
                    //{
                    //    nullTiles[i] = true;
                    //}
                }

                //if (nullTiles[Terraria.Main.maxTilesY * x + y] == true)
                //{
                //    return null;
                //}

                // return tiles[x, y];
                return GetTile(x, y);
            }
            set
            {
                //nullTiles[Terraria.Main.maxTilesY * x + y] = value == null;

                //if (value != null)
                //{
                    SetTile(value, x, y);
                //}
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
        protected virtual Terraria.Tile GetTile(int x, int y)
        {
            return new HeapTile(tileHeap, x, y);
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
        protected virtual void SetTile(Terraria.Tile tile, int x, int y)
        {
            HeapTile heapTile = new HeapTile(tileHeap, x, y);
            heapTile.CopyFrom(tile);
        }


    }
}