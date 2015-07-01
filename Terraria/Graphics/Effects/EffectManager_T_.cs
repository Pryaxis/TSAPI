using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Terraria.Graphics.Effects
{
	internal abstract class EffectManager<T>
	where T : GameEffect
	{
		protected bool _isLoaded;

		protected Dictionary<string, T> _effects;

		public bool IsLoaded
		{
			get
			{
				return this._isLoaded;
			}
		}

		public T this[string key]
		{
			get
			{
				T t;
				if (this._effects.TryGetValue(key, out t))
				{
					return t;
				}
				return default(T);
			}
			set
			{
				this.Bind(key, value);
			}
		}

		protected EffectManager()
		{
		}

		public T Activate(string name, Vector2 position = new Vector2(), params object[] args)
		{
			if (!this._effects.ContainsKey(name))
			{
				object[] objArray = new object[] { "Unable to find effect named: ", name, ". Type: ", typeof(T), "." };
				throw new MissingEffectException(string.Concat(objArray));
			}
			T item = this._effects[name];
			this.OnActivate(item, position);
			item.Activate(position, args);
			return item;
		}

		public void Bind(string name, T effect)
		{
			this._effects[name] = effect;
			if (this._isLoaded)
			{
				effect.Load();
			}
		}

		public void Deactivate(string name, params object[] args)
		{
			if (!this._effects.ContainsKey(name))
			{
				object[] objArray = new object[] { "Unable to find effect named: ", name, ". Type: ", typeof(T), "." };
				throw new MissingEffectException(string.Concat(objArray));
			}
			T item = this._effects[name];
			this.OnDeactivate(item);
			item.Deactivate(args);
		}

		public void Load()
		{
			if (this._isLoaded)
			{
				return;
			}
			this._isLoaded = true;
			foreach (T value in this._effects.Values)
			{
				value.Load();
			}
		}

		public virtual void OnActivate(T effect, Vector2 position)
		{
		}

		public virtual void OnDeactivate(T effect)
		{
		}
	}
}