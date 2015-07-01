using System;

namespace Terraria.UI
{
	public class UIState : UIElement
	{
		public UIState()
		{
			this.Width.Precent = 1f;
			this.Height.Precent = 1f;
			this.Recalculate();
		}
	}
}