using XNA;
using System;
using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Effects;

namespace Terraria.GameContent.Skies
{
	internal class SlimeSky : CustomSky
	{
		private SlimeSky.Slime[] _slimes;

		private Random _random = new Random();

		private int _slimesRemaining;

		private bool _isActive;

		private bool _isLeaving;

		public SlimeSky()
		{
		}

		internal override void Activate(Vector2 position, params object[] args)
		{
			this.GenerateSlimes();
			this._isActive = true;
			this._isLeaving = false;
		}

		internal override void Deactivate(params object[] args)
		{
			this._isLeaving = true;
		}

		public override void Draw(float minDepth, float maxDepth)
		{
		}

		private void GenerateSlimes()
		{
		}

		public override bool IsActive()
		{
			return this._isActive;
		}

		public override void OnLoad()
		{
		}

		public override void Reset()
		{
			this._isActive = false;
		}

		public override void Update()
		{
		}

		private struct Slime
		{
			private const int MAX_FRAMES = 4;

			private const int FRAME_RATE = 6;

			public Vector2 Position;

			public float Depth;

			public int FrameHeight;

			public int FrameWidth;

			public float Speed;

			public bool Active;

			private int _frame;

			public int Frame
			{
				get
				{
					return this._frame;
				}
				set
				{
					this._frame = value % 24;
				}
			}

			public Rectangle GetSourceRectangle()
			{
				return new Rectangle(0, this._frame / 6 * this.FrameHeight, this.FrameWidth, this.FrameHeight);
			}
		}
	}
}