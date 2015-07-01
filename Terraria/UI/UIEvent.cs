using System;

namespace Terraria.UI
{
	public class UIEvent
	{
		public readonly UIElement Target;

		public UIEvent(UIElement target)
		{
			this.Target = target;
		}
	}
}