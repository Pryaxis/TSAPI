using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Runtime.CompilerServices;

namespace Terraria.Graphics
{
	public class TileBatch
	{
		private static float[] xCornerOffsets;

		private static float[] yCornerOffsets;

		private GraphicsDevice graphicsDevice;

		private TileBatch.SpriteData[] spriteDataQueue = new TileBatch.SpriteData[2048];

		private Texture2D[] spriteTextures;

		private int queuedSpriteCount;

		private SpriteBatch _spriteBatch;

		private static Vector2 vector2Zero;

		private static Rectangle? nullRectangle;

		private DynamicVertexBuffer vertexBuffer;

		private DynamicIndexBuffer indexBuffer;

		private short[] fallbackIndexData;

		private VertexPositionColorTexture[] vertices = new VertexPositionColorTexture[8192];

		private int vertexBufferPosition;

		static TileBatch()
		{
			float[] singleArray = new float[] { default(float), 1f, 1f, default(float) };
			TileBatch.xCornerOffsets = singleArray;
			float[] singleArray1 = new float[] { default(float), default(float), 1f, 1f };
			TileBatch.yCornerOffsets = singleArray1;
		}

		public TileBatch(GraphicsDevice graphicsDevice)
		{
			this.graphicsDevice = graphicsDevice;
			this._spriteBatch = new SpriteBatch(graphicsDevice);
			this.Allocate();
		}

		private void Allocate()
		{
			if (this.vertexBuffer == null || this.vertexBuffer.IsDisposed)
			{
				this.vertexBuffer = new DynamicVertexBuffer(this.graphicsDevice, typeof(VertexPositionColorTexture), 8192, BufferUsage.WriteOnly);
				this.vertexBufferPosition = 0;
				this.vertexBuffer.ContentLost += new EventHandler<EventArgs>((object sender, EventArgs e) => this.vertexBufferPosition = 0);
			}
			if (this.indexBuffer == null || this.indexBuffer.IsDisposed)
			{
				if (this.fallbackIndexData == null)
				{
					this.fallbackIndexData = new short[12288];
					for (int i = 0; i < 2048; i++)
					{
						this.fallbackIndexData[i * 6] = (short)(i * 4);
						this.fallbackIndexData[i * 6 + 1] = (short)(i * 4 + 1);
						this.fallbackIndexData[i * 6 + 2] = (short)(i * 4 + 2);
						this.fallbackIndexData[i * 6 + 3] = (short)(i * 4);
						this.fallbackIndexData[i * 6 + 4] = (short)(i * 4 + 2);
						this.fallbackIndexData[i * 6 + 5] = (short)(i * 4 + 3);
					}
				}
				this.indexBuffer = new DynamicIndexBuffer(this.graphicsDevice, typeof(short), 12288, BufferUsage.WriteOnly);
				this.indexBuffer.SetData<short>(this.fallbackIndexData);
				this.indexBuffer.ContentLost += new EventHandler<EventArgs>((object sender, EventArgs e) => this.indexBuffer.SetData<short>(this.fallbackIndexData));
			}
		}

		public void Begin()
		{
			this._spriteBatch.Begin();
			this._spriteBatch.End();
		}

		private static short[] CreateIndexData()
		{
			short[] numArray = new short[12288];
			for (int i = 0; i < 2048; i++)
			{
				numArray[i * 6] = (short)(i * 4);
				numArray[i * 6 + 1] = (short)(i * 4 + 1);
				numArray[i * 6 + 2] = (short)(i * 4 + 2);
				numArray[i * 6 + 3] = (short)(i * 4);
				numArray[i * 6 + 4] = (short)(i * 4 + 2);
				numArray[i * 6 + 5] = (short)(i * 4 + 3);
			}
			return numArray;
		}

		public void Dispose()
		{
			if (this.vertexBuffer != null)
			{
				this.vertexBuffer.Dispose();
			}
			if (this.indexBuffer != null)
			{
				this.indexBuffer.Dispose();
			}
		}

		public void Draw(Texture2D texture, Vector2 position, vertexColors colors)
		{
			Vector4 vector4 = new Vector4()
			{
				X = position.X,
				Y = position.Y,
				Z = 1f,
				W = 1f
			};
			this.InternalDraw(texture, ref vector4, true, ref TileBatch.nullRectangle, ref colors, ref TileBatch.vector2Zero, SpriteEffects.None);
		}

		public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, vertexColors colors, Vector2 origin, float scale, SpriteEffects effects)
		{
			Vector4 vector4 = new Vector4()
			{
				X = position.X,
				Y = position.Y,
				Z = scale,
				W = scale
			};
			this.InternalDraw(texture, ref vector4, true, ref sourceRectangle, ref colors, ref origin, effects);
		}

		public void Draw(Texture2D texture, Vector4 destination, vertexColors colors)
		{
			this.InternalDraw(texture, ref destination, false, ref TileBatch.nullRectangle, ref colors, ref TileBatch.vector2Zero, SpriteEffects.None);
		}

		public void Draw(Texture2D texture, Vector2 position, vertexColors colors, Vector2 scale)
		{
			Vector4 vector4 = new Vector4()
			{
				X = position.X,
				Y = position.Y,
				Z = scale.X,
				W = scale.Y
			};
			this.InternalDraw(texture, ref vector4, true, ref TileBatch.nullRectangle, ref colors, ref TileBatch.vector2Zero, SpriteEffects.None);
		}

		public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, vertexColors colors)
		{
			Vector4 vector4 = new Vector4()
			{
				X = (float)destinationRectangle.X,
				Y = (float)destinationRectangle.Y,
				Z = (float)destinationRectangle.Width,
				W = (float)destinationRectangle.Height
			};
			this.InternalDraw(texture, ref vector4, false, ref sourceRectangle, ref colors, ref TileBatch.vector2Zero, SpriteEffects.None);
		}

		public void End()
		{
			if (this.queuedSpriteCount == 0)
			{
				return;
			}
			this.FlushRenderState();
			this.Flush();
		}

		private void Flush()
		{
			Texture2D texture2D = null;
			int num = 0;
			for (int i = 0; i < this.queuedSpriteCount; i++)
			{
				if (this.spriteTextures[i] != texture2D)
				{
					if (i > num)
					{
						this.RenderBatch(texture2D, this.spriteDataQueue, num, i - num);
					}
					num = i;
					texture2D = this.spriteTextures[i];
				}
			}
			this.RenderBatch(texture2D, this.spriteDataQueue, num, this.queuedSpriteCount - num);
			Array.Clear(this.spriteTextures, 0, this.queuedSpriteCount);
			this.queuedSpriteCount = 0;
		}

		private void FlushRenderState()
		{
			this.Allocate();
			this.graphicsDevice.SetVertexBuffer(this.vertexBuffer);
			this.graphicsDevice.Indices = this.indexBuffer;
			this.graphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
		}

		private void InternalDraw(Texture2D texture, ref Vector4 destination, bool scaleDestination, ref Rectangle? sourceRectangle, ref vertexColors colors, ref Vector2 origin, SpriteEffects effects)
		{
		}

		private void RenderBatch(Texture2D texture, TileBatch.SpriteData[] sprites, int offset, int count)
		{
		}

		private struct SpriteData
		{
			public Vector4 Source;

			public Vector4 Destination;

			public Vector2 Origin;

			public SpriteEffects Effects;

			public vertexColors Colors;
		}
	}
}