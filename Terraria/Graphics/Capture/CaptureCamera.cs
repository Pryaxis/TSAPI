using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Terraria;

namespace Terraria.Graphics.Capture
{
	internal class CaptureCamera
	{
		public const int CHUNK_SIZE = 128;

		public const int FRAMEBUFFER_PIXEL_SIZE = 2048;

		public const int INNER_CHUNK_SIZE = 126;

		public const int MAX_IMAGE_SIZE = 4096;

		public const string CAPTURE_DIRECTORY = "Captures";

		private static bool CameraExists;

		private RenderTarget2D _frameBuffer;

		private RenderTarget2D _scaledFrameBuffer;

		private GraphicsDevice _graphics;

		private readonly object _captureLock = new object();

		private bool _isDisposed;

		private CaptureSettings _activeSettings;

		private Queue<CaptureCamera.CaptureChunk> _renderQueue = new Queue<CaptureCamera.CaptureChunk>();

		private SpriteBatch _spriteBatch;

		private byte[] _scaledFrameData;

		private byte[] _outputData;

		private Size _outputImageSize;

		private SamplerState _downscaleSampleState;

		private float _tilesProcessed;

		private float _totalTiles;

		public bool IsCapturing
		{
			get
			{
				Monitor.Enter(this._captureLock);
				bool flag = this._activeSettings != null;
				Monitor.Exit(this._captureLock);
				return flag;
			}
		}

		static CaptureCamera()
		{
		}

		public CaptureCamera(GraphicsDevice graphics)
		{
			CaptureCamera.CameraExists = true;
			this._graphics = graphics;
			this._spriteBatch = new SpriteBatch(graphics);
			this._frameBuffer = new RenderTarget2D(graphics, 2048, 2048, false, graphics.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
			this._downscaleSampleState = SamplerState.AnisotropicClamp;
		}

		public void Capture(CaptureSettings settings)
		{
			Main.GlobalTimerPaused = true;
			Monitor.Enter(this._captureLock);
			if (this._activeSettings != null)
			{
				throw new InvalidOperationException("Capture called while another capture was already active.");
			}
			this._activeSettings = settings;
			Microsoft.Xna.Framework.Rectangle area = settings.Area;
			float width = 1f;
			if (!settings.UseScaling)
			{
				this._outputData = new byte[16777216];
			}
			else
			{
				if (area.Width << 4 > 4096)
				{
					width = 4096f / (float)(area.Width << 4);
				}
				if (area.Height << 4 > 4096)
				{
					width = Math.Min(width, 4096f / (float)(area.Height << 4));
				}
				width = Math.Min(1f, width);
				this._outputImageSize = new Size((int)MathHelper.Clamp((float)((int)(width * (float)(area.Width << 4))), 1f, 4096f), (int)MathHelper.Clamp((float)((int)(width * (float)(area.Height << 4))), 1f, 4096f));
				this._outputData = new byte[4 * this._outputImageSize.Width * this._outputImageSize.Height];
				int num = (int)Math.Floor((double)(width * 2048f));
				this._scaledFrameData = new byte[4 * num * num];
				this._scaledFrameBuffer = new RenderTarget2D(this._graphics, num, num, false, this._graphics.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
			}
			this._tilesProcessed = 0f;
			this._totalTiles = (float)(area.Width * area.Height);
			for (int i = area.X; i < area.X + area.Width; i = i + 126)
			{
				for (int j = area.Y; j < area.Y + area.Height; j = j + 126)
				{
					int num1 = Math.Min(128, area.X + area.Width - i);
					int num2 = Math.Min(128, area.Y + area.Height - j);
					int num3 = (int)Math.Floor((double)(width * (float)(num1 << 4)));
					int num4 = (int)Math.Floor((double)(width * (float)(num2 << 4)));
					int num5 = (int)Math.Floor((double)(width * (float)(i - area.X << 4)));
					int num6 = (int)Math.Floor((double)(width * (float)(j - area.Y << 4)));
					this._renderQueue.Enqueue(new CaptureCamera.CaptureChunk(new Microsoft.Xna.Framework.Rectangle(i, j, num1, num2), new Microsoft.Xna.Framework.Rectangle(num5, num6, num3, num4)));
				}
			}
			Monitor.Exit(this._captureLock);
		}

		public void Dispose()
		{
		}

		private void DrawBytesToBuffer(byte[] sourceBuffer, byte[] destinationBuffer, int sourceBufferWidth, int destinationBufferWidth, Microsoft.Xna.Framework.Rectangle area)
		{
		}

		public void DrawTick()
		{
			Monitor.Enter(this._captureLock);
			if (this._activeSettings == null)
			{
				return;
			}
			CaptureCamera.CaptureChunk captureChunk = this._renderQueue.Dequeue();
			this._graphics.SetRenderTarget(this._frameBuffer);
			this._graphics.Clear(Microsoft.Xna.Framework.Color.Transparent);
			Main.instance.DrawCapture(captureChunk.Area, this._activeSettings);
			if (!this._activeSettings.UseScaling)
			{
				this._graphics.SetRenderTarget(null);
				RenderTarget2D renderTarget2D = this._frameBuffer;
				int width = captureChunk.ScaledArea.Width;
				int height = captureChunk.ScaledArea.Height;
				ImageFormat png = ImageFormat.Png;
				string outputName = this._activeSettings.OutputName;
				object[] x = new object[] { captureChunk.Area.X, "-", captureChunk.Area.Y, ".png" };
				this.SaveImage(renderTarget2D, width, height, png, outputName, string.Concat(x));
			}
			else
			{
				this._graphics.SetRenderTarget(this._scaledFrameBuffer);
				this._graphics.Clear(Microsoft.Xna.Framework.Color.Transparent);
				this._spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, this._downscaleSampleState, DepthStencilState.Default, RasterizerState.CullNone);
				this._spriteBatch.Draw(this._frameBuffer, new Microsoft.Xna.Framework.Rectangle(0, 0, this._scaledFrameBuffer.Width, this._scaledFrameBuffer.Height), Microsoft.Xna.Framework.Color.White);
				this._spriteBatch.End();
				this._graphics.SetRenderTarget(null);
				this._scaledFrameBuffer.GetData<byte>(this._scaledFrameData, 0, this._scaledFrameBuffer.Width * this._scaledFrameBuffer.Height * 4);
				this.DrawBytesToBuffer(this._scaledFrameData, this._outputData, this._scaledFrameBuffer.Width, this._outputImageSize.Width, captureChunk.ScaledArea);
			}
			CaptureCamera captureCamera = this;
			captureCamera._tilesProcessed = captureCamera._tilesProcessed + (float)(captureChunk.Area.Width * captureChunk.Area.Height);
			if (this._renderQueue.Count == 0)
			{
				this.FinishCapture();
			}
			Monitor.Exit(this._captureLock);
		}

		~CaptureCamera()
		{
			this.Dispose();
		}

		private void FinishCapture()
		{
			if (this._activeSettings.UseScaling)
			{
				int num = 0;
				do
				{
					int width = this._outputImageSize.Width;
					int height = this._outputImageSize.Height;
					ImageFormat png = ImageFormat.Png;
					object[] savePath = new object[] { Main.SavePath, Path.DirectorySeparatorChar, "Captures", Path.DirectorySeparatorChar, this._activeSettings.OutputName, ".png" };
					if (this.SaveImage(width, height, png, string.Concat(savePath)))
					{
						this._outputData = null;
						this._scaledFrameData = null;
						Main.GlobalTimerPaused = false;
						CaptureInterface.EndCamera();
						if (this._scaledFrameBuffer != null)
						{
							this._scaledFrameBuffer.Dispose();
							this._scaledFrameBuffer = null;
						}
						this._activeSettings = null;
						return;
					}
					GC.Collect();
					Thread.Sleep(5);
					num++;
					Console.WriteLine("An error occured while saving the capture. Attempting again...");
				}
				while (num <= 5);
				Console.WriteLine("Unable to capture.");
			}
			this._outputData = null;
			this._scaledFrameData = null;
			Main.GlobalTimerPaused = false;
			CaptureInterface.EndCamera();
			if (this._scaledFrameBuffer != null)
			{
				this._scaledFrameBuffer.Dispose();
				this._scaledFrameBuffer = null;
			}
			this._activeSettings = null;
		}

		public float GetProgress()
		{
			return this._tilesProcessed / this._totalTiles;
		}

		private bool SaveImage(int width, int height, ImageFormat imageFormat, string filename)
		{
			bool flag;
			try
			{
				object[] savePath = new object[] { Main.SavePath, Path.DirectorySeparatorChar, "Captures", Path.DirectorySeparatorChar };
				Directory.CreateDirectory(string.Concat(savePath));
				using (Bitmap bitmap = new Bitmap(width, height))
				{
					System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(0, 0, width, height);
					BitmapData bitmapDatum = bitmap.LockBits(rectangle, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
					IntPtr scan0 = bitmapDatum.Scan0;
					Marshal.Copy(this._outputData, 0, scan0, width * height * 4);
					bitmap.UnlockBits(bitmapDatum);
					bitmap.Save(filename, imageFormat);
					bitmap.Dispose();
				}
				flag = true;
			}
			catch (Exception)
			{
				flag = false;
			}
			return flag;
		}

		private void SaveImage(Texture2D texture, int width, int height, ImageFormat imageFormat, string foldername, string filename)
		{
			object[] savePath = new object[] { Main.SavePath, Path.DirectorySeparatorChar, "Captures", Path.DirectorySeparatorChar, foldername };
			Directory.CreateDirectory(string.Concat(savePath));
			using (Bitmap bitmap = new Bitmap(width, height))
			{
				System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(0, 0, width, height);
				int num = texture.Width * texture.Height * 4;
				texture.GetData<byte>(this._outputData, 0, num);
				int num1 = 0;
				int num2 = 0;
				for (int i = 0; i < height; i++)
				{
					for (int j = 0; j < width; j++)
					{
						byte num3 = this._outputData[num1 + 2];
						this._outputData[num2 + 2] = this._outputData[num1];
						this._outputData[num2] = num3;
						this._outputData[num2 + 1] = this._outputData[num1 + 1];
						this._outputData[num2 + 3] = this._outputData[num1 + 3];
						num1 = num1 + 4;
						num2 = num2 + 4;
					}
					num1 = num1 + (texture.Width - width << 2);
				}
				BitmapData bitmapDatum = bitmap.LockBits(rectangle, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
				IntPtr scan0 = bitmapDatum.Scan0;
				Marshal.Copy(this._outputData, 0, scan0, width * height * 4);
				bitmap.UnlockBits(bitmapDatum);
				object[] objArray = new object[] { Main.SavePath, Path.DirectorySeparatorChar, "Captures", Path.DirectorySeparatorChar, foldername, Path.DirectorySeparatorChar, filename };
				bitmap.Save(string.Concat(objArray), imageFormat);
			}
		}

		private class CaptureChunk
		{
			public readonly Microsoft.Xna.Framework.Rectangle Area;

			public readonly Microsoft.Xna.Framework.Rectangle ScaledArea;

			public CaptureChunk(Microsoft.Xna.Framework.Rectangle area, Microsoft.Xna.Framework.Rectangle scaledArea)
			{
				this.Area = area;
				this.ScaledArea = scaledArea;
			}
		}
	}
}