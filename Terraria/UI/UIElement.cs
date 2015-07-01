using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Threading;
using Terraria;

namespace Terraria.UI
{
	public class UIElement : IComparable
	{
		public string Id = "";

		public UIElement Parent;

		protected List<UIElement> Elements = new List<UIElement>();

		public StyleDimension Top;

		public StyleDimension Left;

		public StyleDimension Width;

		public StyleDimension Height;

		public StyleDimension MaxWidth = StyleDimension.Fill;

		public StyleDimension MaxHeight = StyleDimension.Fill;

		public StyleDimension MinWidth = StyleDimension.Empty;

		public StyleDimension MinHeight = StyleDimension.Empty;

		private bool _isInitialized;

		public bool OverflowHidden;

		public float PaddingTop;

		public float PaddingLeft;

		public float PaddingRight;

		public float PaddingBottom;

		public float HAlign;

		public float VAlign;

		private CalculatedStyle _innerDimensions;

		private CalculatedStyle _dimensions;

		private static RasterizerState _overflowHiddenRasterizerState;

		protected bool _useImmediateMode;

		private bool _isMouseHovering;

		public bool IsMouseHovering
		{
			get
			{
				return this._isMouseHovering;
			}
		}

		public UIElement()
		{
			if (UIElement._overflowHiddenRasterizerState == null)
			{
				RasterizerState rasterizerState = new RasterizerState()
				{
					CullMode = CullMode.None,
					ScissorTestEnable = true
				};
				UIElement._overflowHiddenRasterizerState = rasterizerState;
			}
		}

		public void Activate()
		{
			if (!this._isInitialized)
			{
				this.Initialize();
			}
			this.OnActivate();
			foreach (UIElement element in this.Elements)
			{
				element.Activate();
			}
		}

		public void Append(UIElement element)
		{
			element.Remove();
			element.Parent = this;
			this.Elements.Add(element);
			element.Recalculate();
		}

		public virtual void Click(UIMouseEvent evt)
		{
			if (this.OnClick != null)
			{
				this.OnClick(evt, this);
			}
			if (this.Parent != null)
			{
				this.Parent.Click(evt);
			}
		}

		public virtual int CompareTo(object obj)
		{
			return 0;
		}

		public virtual bool ContainsPoint(Vector2 point)
		{
			if (point.X <= this._dimensions.X || point.Y <= this._dimensions.Y || point.X >= this._dimensions.X + this._dimensions.Width)
			{
				return false;
			}
			return point.Y < this._dimensions.Y + this._dimensions.Height;
		}

		public void CopyStyle(UIElement element)
		{
			this.Top = element.Top;
			this.Left = element.Left;
			this.Width = element.Width;
			this.Height = element.Height;
			this.PaddingBottom = element.PaddingBottom;
			this.PaddingLeft = element.PaddingLeft;
			this.PaddingRight = element.PaddingRight;
			this.PaddingTop = element.PaddingTop;
			this.HAlign = element.HAlign;
			this.VAlign = element.VAlign;
			this.MinWidth = element.MinWidth;
			this.MaxWidth = element.MaxWidth;
			this.MinHeight = element.MinHeight;
			this.MaxHeight = element.MaxHeight;
			this.Recalculate();
		}

		public void Deactivate()
		{
			this.OnDeactivate();
			foreach (UIElement element in this.Elements)
			{
				element.Deactivate();
			}
		}

		public virtual void DoubleClick(UIMouseEvent evt)
		{
			if (this.OnDoubleClick != null)
			{
				this.OnDoubleClick(evt, this);
			}
			if (this.Parent != null)
			{
				this.Parent.DoubleClick(evt);
			}
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			bool overflowHidden = this.OverflowHidden;
			bool flag = this._useImmediateMode;
			RasterizerState rasterizerState = spriteBatch.GraphicsDevice.RasterizerState;
			Rectangle scissorRectangle = spriteBatch.GraphicsDevice.ScissorRectangle;
			if (!flag)
			{
				this.DrawSelf(spriteBatch);
			}
			else
			{
				spriteBatch.End();
				spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.AnisotropicClamp, DepthStencilState.None, UIElement._overflowHiddenRasterizerState);
				this.DrawSelf(spriteBatch);
				spriteBatch.End();
				spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.AnisotropicClamp, DepthStencilState.None, UIElement._overflowHiddenRasterizerState);
			}
			if (overflowHidden)
			{
				spriteBatch.End();
				Rectangle rectangle = new Rectangle((int)this._innerDimensions.X, (int)this._innerDimensions.Y, (int)this._innerDimensions.Width, (int)this._innerDimensions.Height);
				int width = spriteBatch.GraphicsDevice.Viewport.Width;
				int height = spriteBatch.GraphicsDevice.Viewport.Height;
				rectangle.X = Utils.Clamp<int>(rectangle.X, 0, width);
				rectangle.Y = Utils.Clamp<int>(rectangle.Y, 0, height);
				rectangle.Width = Utils.Clamp<int>(rectangle.Width, 0, width - rectangle.X);
				rectangle.Height = Utils.Clamp<int>(rectangle.Height, 0, height - rectangle.Y);
				spriteBatch.GraphicsDevice.ScissorRectangle = rectangle;
				spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.AnisotropicClamp, DepthStencilState.None, UIElement._overflowHiddenRasterizerState);
			}
			this.DrawChildren(spriteBatch);
			if (overflowHidden)
			{
				spriteBatch.End();
				spriteBatch.GraphicsDevice.ScissorRectangle = scissorRectangle;
				spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.AnisotropicClamp, DepthStencilState.None, rasterizerState);
			}
		}

		protected virtual void DrawChildren(SpriteBatch spriteBatch)
		{
			foreach (UIElement element in this.Elements)
			{
				element.Draw(spriteBatch);
			}
		}

		protected virtual void DrawSelf(SpriteBatch spriteBatch)
		{
		}

		public CalculatedStyle GetDimensions()
		{
			return this._dimensions;
		}

		public UIElement GetElementAt(Vector2 point)
		{
			UIElement uIElement = null;
			foreach (UIElement element in this.Elements)
			{
				if (!element.ContainsPoint(point))
				{
					continue;
				}
				uIElement = element;
				break;
			}
			if (uIElement != null)
			{
				return uIElement.GetElementAt(point);
			}
			if (this.ContainsPoint(point))
			{
				return this;
			}
			return null;
		}

		public CalculatedStyle GetInnerDimensions()
		{
			return this._innerDimensions;
		}

		public void Initialize()
		{
			this.OnInitialize();
			this._isInitialized = true;
		}

		public virtual void MouseDown(UIMouseEvent evt)
		{
			if (this.OnMouseDown != null)
			{
				this.OnMouseDown(evt, this);
			}
			if (this.Parent != null)
			{
				this.Parent.MouseDown(evt);
			}
		}

		public virtual void MouseOut(UIMouseEvent evt)
		{
			this._isMouseHovering = false;
			if (this.OnMouseOut != null)
			{
				this.OnMouseOut(evt, this);
			}
			if (this.Parent != null)
			{
				this.Parent.MouseOut(evt);
			}
		}

		public virtual void MouseOver(UIMouseEvent evt)
		{
			this._isMouseHovering = true;
			if (this.OnMouseOver != null)
			{
				this.OnMouseOver(evt, this);
			}
			if (this.Parent != null)
			{
				this.Parent.MouseOver(evt);
			}
		}

		public virtual void MouseUp(UIMouseEvent evt)
		{
			if (this.OnMouseUp != null)
			{
				this.OnMouseUp(evt, this);
			}
			if (this.Parent != null)
			{
				this.Parent.MouseUp(evt);
			}
		}

		public virtual void OnActivate()
		{
		}

		public virtual void OnDeactivate()
		{
		}

		public virtual void OnInitialize()
		{
		}

		public virtual void Recalculate()
		{
			CalculatedStyle calculatedStyle;
			CalculatedStyle value = new CalculatedStyle();
			calculatedStyle = (this.Parent == null ? UserInterface.ActiveInstance.GetDimensions() : this.Parent.GetInnerDimensions());
			value.X = this.Left.GetValue(calculatedStyle.Width) + calculatedStyle.X;
			value.Y = this.Top.GetValue(calculatedStyle.Height) + calculatedStyle.Y;
			float single = this.MinWidth.GetValue(calculatedStyle.Width);
			float value1 = this.MaxWidth.GetValue(calculatedStyle.Width);
			float single1 = this.MinHeight.GetValue(calculatedStyle.Height);
			float value2 = this.MaxHeight.GetValue(calculatedStyle.Height);
			value.Width = MathHelper.Clamp(this.Width.GetValue(calculatedStyle.Width), single, value1);
			value.Height = MathHelper.Clamp(this.Height.GetValue(calculatedStyle.Height), single1, value2);
			value.X = value.X + (calculatedStyle.Width * (float)this.HAlign - value.Width * (float)this.HAlign);
			value.Y = value.Y + (calculatedStyle.Height * (float)this.VAlign - value.Height * (float)this.VAlign);
			this._dimensions = value;
			value.X = value.X + this.PaddingLeft;
			value.Y = value.Y + this.PaddingTop;
			value.Width = value.Width - (this.PaddingLeft + this.PaddingRight);
			value.Height = value.Height - (this.PaddingTop + this.PaddingBottom);
			this._innerDimensions = value;
			this.RecalculateChildren();
		}

		public virtual void RecalculateChildren()
		{
			foreach (UIElement element in this.Elements)
			{
				element.Recalculate();
			}
		}

		public void Remove()
		{
			if (this.Parent != null)
			{
				this.Parent.RemoveChild(this);
			}
		}

		public void RemoveAllChildren()
		{
			foreach (UIElement element in this.Elements)
			{
				element.Parent = null;
			}
			this.Elements.Clear();
		}

		public void RemoveChild(UIElement child)
		{
			this.Elements.Remove(child);
			child.Parent = null;
		}

		public virtual void ScrollWheel(UIScrollWheelEvent evt)
		{
			if (this.OnScrollWheel != null)
			{
				this.OnScrollWheel(evt, this);
			}
			if (this.Parent != null)
			{
				this.Parent.ScrollWheel(evt);
			}
		}

		public void SetPadding(float pixels)
		{
			this.PaddingBottom = pixels;
			this.PaddingLeft = pixels;
			this.PaddingRight = pixels;
			this.PaddingTop = pixels;
		}

		public event UIElement.MouseEvent OnClick;

		public event UIElement.MouseEvent OnDoubleClick;

		public event UIElement.MouseEvent OnMouseDown;

		public event UIElement.MouseEvent OnMouseOut;

		public event UIElement.MouseEvent OnMouseOver;

		public event UIElement.MouseEvent OnMouseUp;

		public event UIElement.ScrollWheelEvent OnScrollWheel;

		public delegate void MouseEvent(UIMouseEvent evt, UIElement listeningElement);

		public delegate void ScrollWheelEvent(UIScrollWheelEvent evt, UIElement listeningElement);
	}
}