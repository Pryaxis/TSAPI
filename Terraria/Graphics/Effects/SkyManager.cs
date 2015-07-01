using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Terraria.Graphics.Effects
{
	internal class SkyManager : EffectManager<CustomSky>
	{
		public static SkyManager Instance;

		private float _lastDepth;

		private LinkedList<CustomSky> _activeSkies = new LinkedList<CustomSky>();

		static SkyManager()
		{
			SkyManager.Instance = new SkyManager();
		}

		public SkyManager()
		{
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			this.DrawDepthRange(spriteBatch, float.MinValue, float.MaxValue);
		}

		public void DrawDepthRange(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			foreach (CustomSky _activeSky in this._activeSkies)
			{
				_activeSky.Draw(spriteBatch, minDepth, maxDepth);
			}
		}

		public void DrawRemainingDepth(SpriteBatch spriteBatch)
		{
			this.DrawDepthRange(spriteBatch, float.MinValue, this._lastDepth);
			this._lastDepth = float.MinValue;
		}

		public void DrawToDepth(SpriteBatch spriteBatch, float minDepth)
		{
			if (this._lastDepth <= minDepth)
			{
				return;
			}
			this.DrawDepthRange(spriteBatch, minDepth, this._lastDepth);
			this._lastDepth = minDepth;
		}

		public override void OnActivate(CustomSky effect, Vector2 position)
		{
			this._activeSkies.AddLast(effect);
		}

		public float ProcessCloudAlpha()
		{
			float cloudAlpha = 1f;
			foreach (CustomSky _activeSky in this._activeSkies)
			{
				cloudAlpha = cloudAlpha * _activeSky.GetCloudAlpha();
			}
			return MathHelper.Clamp(cloudAlpha, 0f, 1f);
		}

		public Color ProcessTileColor(Color color)
		{
			foreach (CustomSky _activeSky in this._activeSkies)
			{
				color = _activeSky.OnTileColor(color);
			}
			return color;
		}

		public void Reset()
		{
			foreach (CustomSky value in this._effects.Values)
			{
				value.Reset();
			}
			this._activeSkies.Clear();
		}

		public void ResetDepthTracker()
		{
			this._lastDepth = float.MaxValue;
		}

		public void SetStartingDepth(float depth)
		{
			this._lastDepth = depth;
		}

		public void Update()
		{
			LinkedListNode<CustomSky> next = null;
			for (LinkedListNode<CustomSky> i = this._activeSkies.First; i != null; i = next)
			{
				CustomSky value = i.Value;
				next = i.Next;
				value.Update();
				if (!value.IsActive())
				{
					this._activeSkies.Remove(i);
				}
			}
		}
	}
}