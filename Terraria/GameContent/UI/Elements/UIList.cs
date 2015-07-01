using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	internal class UIList : UIElement
	{
		protected List<UIElement> _items = new List<UIElement>();

		protected UIScrollbar _scrollbar;

		private UIElement _innerList = new UIList.UIInnerList();

		private float _innerListHeight;

		public float ListPadding = 5f;

		public int Count
		{
			get
			{
				return this._items.Count;
			}
		}

		public UIList()
		{
			this._innerList.OverflowHidden = false;
			this._innerList.Width.Set(0f, 1f);
			this._innerList.Height.Set(0f, 1f);
			this.OverflowHidden = true;
			base.Append(this._innerList);
		}

		public virtual void Add(UIElement item)
		{
			this._items.Add(item);
			this._innerList.Append(item);
			this.UpdateOrder();
			this._innerList.Recalculate();
		}

		public virtual void Clear()
		{
			this._innerList.RemoveAllChildren();
			this._items.Clear();
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			if (this._scrollbar != null)
			{
				this._innerList.Top.Set(-this._scrollbar.GetValue(), 0f);
			}
			this.Recalculate();
		}

		public void Goto(UIList.ElementSearchMethod searchMethod)
		{
			for (int i = 0; i < this._items.Count; i++)
			{
				if (searchMethod(this._items[i]))
				{
					this._scrollbar.ViewPosition = this._items[i].Top.Pixels;
					return;
				}
			}
		}

		public override void Recalculate()
		{
			base.Recalculate();
			this.UpdateScrollbar();
		}

		public override void RecalculateChildren()
		{
			base.RecalculateChildren();
			float height = 0f;
			for (int i = 0; i < this._items.Count; i++)
			{
				this._items[i].Top.Set(height, 0f);
				this._items[i].Recalculate();
				CalculatedStyle dimensions = this._items[i].GetDimensions();
				height = height + (dimensions.Height + this.ListPadding);
			}
			this._innerListHeight = height;
		}

		public virtual bool Remove(UIElement item)
		{
			this._innerList.RemoveChild(item);
			this.UpdateOrder();
			return this._items.Remove(item);
		}

		public override void ScrollWheel(UIScrollWheelEvent evt)
		{
			base.ScrollWheel(evt);
			if (this._scrollbar != null)
			{
				UIScrollbar viewPosition = this._scrollbar;
				viewPosition.ViewPosition = viewPosition.ViewPosition - (float)evt.ScrollWheelValue;
			}
		}

		public void SetScrollbar(UIScrollbar scrollbar)
		{
			this._scrollbar = scrollbar;
			this.UpdateScrollbar();
		}

		public int SortMethod(UIElement item1, UIElement item2)
		{
			return item1.CompareTo(item2);
		}

		public void UpdateOrder()
		{
			this._items.Sort(new Comparison<UIElement>(this.SortMethod));
			this.UpdateScrollbar();
		}

		private void UpdateScrollbar()
		{
			if (this._scrollbar == null)
			{
				return;
			}
			this._scrollbar.SetView(base.GetInnerDimensions().Height, this._innerListHeight);
		}

		public delegate bool ElementSearchMethod(UIElement element);

		private class UIInnerList : UIElement
		{
			public UIInnerList()
			{
			}

			public override bool ContainsPoint(Vector2 point)
			{
				return true;
			}

			protected override void DrawChildren(SpriteBatch spriteBatch)
			{
				Vector2 vector2 = this.Parent.GetDimensions().Position();
				Vector2 vector21 = new Vector2(this.Parent.GetDimensions().Width, this.Parent.GetDimensions().Height);
				foreach (UIElement element in this.Elements)
				{
					Vector2 vector22 = element.GetDimensions().Position();
					Vector2 vector23 = new Vector2(element.GetDimensions().Width, element.GetDimensions().Height);
					if (!Collision.CheckAABBvAABBCollision(vector2, vector21, vector22, vector23))
					{
						continue;
					}
					element.Draw(spriteBatch);
				}
			}
		}
	}
}