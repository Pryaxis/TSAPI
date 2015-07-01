using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Terraria;

namespace Terraria.UI
{
	public class UserInterface
	{
		private const double DOUBLE_CLICK_TIME = 500;

		private const double STATE_CHANGE_CLICK_DISABLE_TIME = 200;

		private const int MAX_HISTORY_SIZE = 32;

		private const int HISTORY_PRUNE_SIZE = 4;

		public static UserInterface ActiveInstance;

		private List<UIState> _history = new List<UIState>();

		public Vector2 MousePosition;

		private bool _wasMouseDown;

		private UIElement _lastElementHover;

		private UIElement _lastElementDown;

		private UIElement _lastElementClicked;

		private double _lastMouseDownTime;

		private int _scrollWheelState;

		private double _clickDisabledTimeRemaining;

		public bool IsVisible;

		private UIState _currentState;

		public UIState CurrentState
		{
			get
			{
				return this._currentState;
			}
		}

		static UserInterface()
		{
			UserInterface.ActiveInstance = new UserInterface();
		}

		public UserInterface()
		{
			UserInterface.ActiveInstance = this;
		}

		private void AddToHistory(UIState state)
		{
			this._history.Add(state);
			if (this._history.Count > 32)
			{
				this._history.RemoveRange(0, 4);
			}
		}

		public void Draw(SpriteBatch spriteBatch, GameTime time)
		{
			UIElement elementAt;
			this.Use();
			if (this._currentState != null)
			{
				MouseState state = Mouse.GetState();
				this.MousePosition = new Vector2((float)state.X, (float)state.Y);
				bool flag = (state.LeftButton != ButtonState.Pressed ? false : Main.hasFocus);
				if (Main.hasFocus)
				{
					elementAt = this._currentState.GetElementAt(this.MousePosition);
				}
				else
				{
					elementAt = null;
				}
				UIElement uIElement = elementAt;
				double num = this._clickDisabledTimeRemaining;
				TimeSpan elapsedGameTime = time.ElapsedGameTime;
				this._clickDisabledTimeRemaining = Math.Max(0, num - elapsedGameTime.TotalMilliseconds);
				bool flag1 = this._clickDisabledTimeRemaining > 0;
				if (uIElement != this._lastElementHover)
				{
					if (this._lastElementHover != null)
					{
						this._lastElementHover.MouseOut(new UIMouseEvent(this._lastElementHover, this.MousePosition));
					}
					if (uIElement != null)
					{
						uIElement.MouseOver(new UIMouseEvent(uIElement, this.MousePosition));
					}
					this._lastElementHover = uIElement;
				}
				if (flag && !this._wasMouseDown && uIElement != null && !flag1)
				{
					this._lastElementDown = uIElement;
					uIElement.MouseDown(new UIMouseEvent(uIElement, this.MousePosition));
					if (this._lastElementClicked == uIElement && time.TotalGameTime.TotalMilliseconds - this._lastMouseDownTime < 500)
					{
						uIElement.DoubleClick(new UIMouseEvent(uIElement, this.MousePosition));
						this._lastElementClicked = null;
					}
					this._lastMouseDownTime = time.TotalGameTime.TotalMilliseconds;
				}
				else if (!flag && this._wasMouseDown && this._lastElementDown != null && !flag1)
				{
					UIElement uIElement1 = this._lastElementDown;
					if (uIElement1.ContainsPoint(this.MousePosition))
					{
						uIElement1.Click(new UIMouseEvent(uIElement1, this.MousePosition));
						this._lastElementClicked = this._lastElementDown;
					}
					uIElement1.MouseUp(new UIMouseEvent(uIElement1, this.MousePosition));
					this._lastElementDown = null;
				}
				if (state.ScrollWheelValue != this._scrollWheelState)
				{
					if (uIElement != null)
					{
						uIElement.ScrollWheel(new UIScrollWheelEvent(uIElement, this.MousePosition, state.ScrollWheelValue - this._scrollWheelState));
					}
					this._scrollWheelState = state.ScrollWheelValue;
				}
				this._wasMouseDown = flag;
				if (this._currentState != null)
				{
					this._currentState.Draw(spriteBatch);
				}
			}
		}

		public CalculatedStyle GetDimensions()
		{
			return new CalculatedStyle(0f, 0f, (float)Main.screenWidth, (float)Main.screenHeight);
		}

		public void GoBack()
		{
			if (this._history.Count < 2)
			{
				return;
			}
			UIState item = this._history[this._history.Count - 2];
			this._history.RemoveRange(this._history.Count - 2, 2);
			this.SetState(item);
		}

		public bool IsElementUnderMouse()
		{
			if (!this.IsVisible || this._lastElementHover == null)
			{
				return false;
			}
			return !(this._lastElementHover is UIState);
		}

		public void Recalculate()
		{
			this._scrollWheelState = Mouse.GetState().ScrollWheelValue;
			if (this._currentState != null)
			{
				this._currentState.Recalculate();
			}
		}

		internal void RefreshState()
		{
			if (this._currentState != null)
			{
				this._currentState.Deactivate();
			}
			this.ResetState();
			this._currentState.Activate();
			this._currentState.Recalculate();
		}

		private void ResetState()
		{
			MouseState state = Mouse.GetState();
			this._scrollWheelState = state.ScrollWheelValue;
			this.MousePosition = new Vector2((float)state.X, (float)state.Y);
			this._wasMouseDown = state.LeftButton == ButtonState.Pressed;
			if (this._lastElementHover != null)
			{
				this._lastElementHover.MouseOut(new UIMouseEvent(this._lastElementHover, this.MousePosition));
			}
			this._lastElementHover = null;
			this._lastElementDown = null;
			this._lastElementClicked = null;
			this._lastMouseDownTime = 0;
			this._clickDisabledTimeRemaining = Math.Max(this._clickDisabledTimeRemaining, 200);
		}

		public void SetState(UIState state)
		{
			this.AddToHistory(state);
			if (this._currentState != null)
			{
				this._currentState.Deactivate();
			}
			this._currentState = state;
			this.ResetState();
			if (state != null)
			{
				state.Activate();
				state.Recalculate();
			}
		}

		public void Use()
		{
			if (UserInterface.ActiveInstance == this)
			{
				UserInterface.ActiveInstance = this;
				return;
			}
			UserInterface.ActiveInstance = this;
			this.Recalculate();
		}
	}
}