using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Terraria.Graphics.Effects
{
	internal class FilterManager : EffectManager<Filter>
	{
		private const float OPACITY_RATE = 0.05f;

		private LinkedList<Filter> _activeFilters = new LinkedList<Filter>();

		public FilterManager()
		{
		}

		public void Apply()
		{
			LinkedListNode<Filter> first = this._activeFilters.First;
			int num = 0;
			int count = this._activeFilters.Count;
			while (first != null)
			{
				num++;
				Filter value = first.Value;
				LinkedListNode<Filter> next = first.Next;
				if (value.Opacity > 0f || num == count)
				{
					value.Apply();
					if (num != count || !value.Active)
					{
						value.Opacity = Math.Max(value.Opacity - 0.05f, 0f);
					}
					else
					{
						value.Opacity = Math.Min(value.Opacity + 0.05f, 1f);
					}
					next = null;
				}
				if (!value.Active && value.Opacity == 0f)
				{
					this._activeFilters.Remove(first);
				}
				first = next;
			}
		}

		public bool HasActiveFilter()
		{
			return this._activeFilters.Count != 0;
		}

		public override void OnActivate(Filter effect, Vector2 position)
		{
			if (!this._activeFilters.Contains(effect))
			{
				effect.Opacity = 0f;
			}
			else
			{
				if (effect.Active)
				{
					return;
				}
				this._activeFilters.Remove(effect);
			}
			if (this._activeFilters.Count == 0)
			{
				this._activeFilters.AddLast(effect);
				return;
			}
			for (LinkedListNode<Filter> i = this._activeFilters.First; i != null; i = i.Next)
			{
				Filter value = i.Value;
				if (effect.Priority < value.Priority)
				{
					this._activeFilters.AddBefore(i, effect);
					return;
				}
			}
			this._activeFilters.AddLast(effect);
		}
	}
}