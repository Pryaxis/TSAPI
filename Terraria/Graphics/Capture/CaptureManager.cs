using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Terraria.Graphics.Capture
{
	internal class CaptureManager
	{
		public static CaptureManager Instance;

		private CaptureInterface _interface;

		private CaptureCamera _camera;

		public bool Active
		{
			get
			{
				return this._interface.Active;
			}
			set
			{
				if (this._interface.Active != value)
				{
					this._interface.ToggleCamera(value);
				}
			}
		}

		public bool IsCapturing
		{
			get
			{
				return false;
			}
		}

		public bool UsingMap
		{
			get
			{
				if (!this.Active)
				{
					return false;
				}
				return this._interface.UsingMap();
			}
		}

		static CaptureManager()
		{
			CaptureManager.Instance = new CaptureManager();
		}

		public CaptureManager()
		{
			this._interface = new CaptureInterface();
		}

		public void Capture()
		{
			CaptureSettings captureSetting = new CaptureSettings()
			{
				Area = new Rectangle(2660, 100, 1000, 1000),
				UseScaling = false
			};
			this.Capture(captureSetting);
		}

		public void Capture(CaptureSettings settings)
		{
			this._camera.Capture(settings);
		}

		public void Draw(SpriteBatch sb)
		{
			this._interface.Draw(sb);
		}

		public void DrawTick()
		{
			this._camera.DrawTick();
		}

		public float GetProgress()
		{
			return this._camera.GetProgress();
		}

		public void Scrolling()
		{
			this._interface.Scrolling();
		}

		public void Update()
		{
			this._interface.Update();
		}
	}
}