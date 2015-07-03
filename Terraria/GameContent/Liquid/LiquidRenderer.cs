using XNA;
using System;
using Terraria;

namespace Terraria.GameContent.Liquid
{
	internal class LiquidRenderer
	{
		private const int ANIMATION_FRAME_COUNT = 16;

		private const int CACHE_PADDING = 2;

		private const int CACHE_PADDING_2 = 4;

		public const float MIN_LIQUID_SIZE = 0.25f;

		private static int[] WATERFALL_LENGTH;

		private readonly static float[] DEFAULT_OPACITY;

		private readonly static Tile EMPTY_TILE;

		public static LiquidRenderer Instance;

		private Tile[,] _tiles = Main.tile;

		private Texture2D[] _liquidTextures = new Texture2D[12];

		private LiquidRenderer.LiquidCache[] _cache = new LiquidRenderer.LiquidCache[41616];

		private LiquidRenderer.LiquidDrawCache[] _drawCache = new LiquidRenderer.LiquidDrawCache[40000];

		private int _animationFrame;

		private Rectangle _drawArea;

		private Random _random = new Random();

		static LiquidRenderer()
		{
			LiquidRenderer.WATERFALL_LENGTH = new int[] { 10, 3, 2 };
			LiquidRenderer.DEFAULT_OPACITY = new float[] { 0.6f, 0.95f, 0.95f };
			LiquidRenderer.EMPTY_TILE = new Tile();
			LiquidRenderer.Instance = new LiquidRenderer();
		}

		public LiquidRenderer()
		{
			for (int i = 0; i < (int)this._liquidTextures.Length; i++)
			{
				this._liquidTextures[i] = TextureManager.Load(string.Concat("Images/Misc/water_", i));
			}
		}

		public void Draw(SpriteBatch spriteBatch, Vector2 drawOffset, int waterStyle, float alpha, bool isBackgroundDraw)
		{
			this.InternalDraw(spriteBatch, drawOffset, waterStyle, alpha, isBackgroundDraw);
		}

		public bool HasFullWater(int x, int y)
		{
			x = x - this._drawArea.X;
			y = y - this._drawArea.Y;
			int num = x * this._drawArea.Height + y;
			if (num < 0 || num >= (int)this._drawCache.Length)
			{
				return true;
			}
			if (!this._drawCache[num].IsVisible)
			{
				return false;
			}
			return !this._drawCache[num].IsSurfaceLiquid;
		}

		public void InternalDraw(SpriteBatch spriteBatch, Vector2 drawOffset, int waterStyle, float globalAlpha, bool isBackgroundDraw)
		{
		}

		private void InternalUpdate(Rectangle drawArea)
		{
		}

		public void Update(Rectangle drawArea)
		{
			this.InternalUpdate(drawArea);
			this._animationFrame = (this._animationFrame + 1) % 16;
		}

		private struct LiquidCache
		{
			public float LiquidLevel;

			public float VisibleLiquidLevel;

			public float Opacity;

			public bool IsSolid;

			public bool IsHalfBrick;

			public bool HasLiquid;

			public bool HasVisibleLiquid;

			public bool HasWall;

			public Point FrameOffset;

			public bool HasLeftEdge;

			public bool HasRightEdge;

			public bool HasTopEdge;

			public bool HasBottomEdge;

			public float LeftWall;

			public float RightWall;

			public float BottomWall;

			public float TopWall;

			public float VisibleLeftWall;

			public float VisibleRightWall;

			public float VisibleBottomWall;

			public float VisibleTopWall;

			public byte Type;

			public byte VisibleType;
		}

		private struct LiquidDrawCache
		{
			public Rectangle SourceRectangle;

			public Vector2 LiquidOffset;

			public bool IsVisible;

			public float Opacity;

			public byte Type;

			public bool IsSurfaceLiquid;

			public bool HasWall;
		}
	}
}