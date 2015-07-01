using Microsoft.Xna.Framework;
using System;

namespace Terraria.Graphics.Effects
{
	internal abstract class GameEffect
	{
		public float Opacity;

		protected bool _isLoaded;

		protected EffectPriority _priority;

		public bool IsLoaded
		{
			get
			{
				return this._isLoaded;
			}
		}

		public EffectPriority Priority
		{
			get
			{
				return this._priority;
			}
		}

		protected GameEffect()
		{
		}

		internal abstract void Activate(Vector2 position, params object[] args);

		internal abstract void Deactivate(params object[] args);

		public void Load()
		{
			if (this._isLoaded)
			{
				return;
			}
			this._isLoaded = true;
			this.OnLoad();
		}

		public virtual void OnLoad()
		{
		}
	}
}