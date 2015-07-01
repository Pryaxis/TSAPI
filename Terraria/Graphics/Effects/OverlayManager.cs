using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Terraria.Graphics.Effects
{
	internal class OverlayManager : EffectManager<Overlay>
	{
		private const float OPACITY_RATE = 0.05f;

		private LinkedList<Overlay>[] _activeOverlays = new LinkedList<Overlay>[(int)Enum.GetNames(typeof(EffectPriority)).Length];

		public OverlayManager()
		{
			for (int i = 0; i < (int)this._activeOverlays.Length; i++)
			{
				this._activeOverlays[i] = new LinkedList<Overlay>();
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			LinkedListNode<Overlay> next = null;
			Overlay overlay = null;
			for (int i = 0; i < (int)this._activeOverlays.Length; i++)
			{
				foreach (Overlay _activeOverlay in this._activeOverlays[i])
				{
					if (_activeOverlay.Mode != OverlayMode.Active)
					{
						continue;
					}
					overlay = _activeOverlay;
				}
			}
			for (int j = 0; j < (int)this._activeOverlays.Length; j++)
			{
				for (LinkedListNode<Overlay> k = this._activeOverlays[j].First; k != null; k = next)
				{
					Overlay value = k.Value;
					value.Draw(spriteBatch);
					next = k.Next;
					switch (value.Mode)
					{
						case OverlayMode.FadeIn:
						{
							Overlay opacity = value;
							opacity.Opacity = opacity.Opacity + 0.05f;
							if (value.Opacity < 1f)
							{
								break;
							}
							value.Opacity = 1f;
							value.Mode = OverlayMode.Active;
							break;
						}
						case OverlayMode.Active:
						{
							if (overlay == null || value == overlay)
							{
								value.Opacity = Math.Min(1f, value.Opacity + 0.05f);
								break;
							}
							else
							{
								value.Opacity = Math.Max(0f, value.Opacity - 0.05f);
								break;
							}
						}
						case OverlayMode.FadeOut:
						{
							Overlay opacity1 = value;
							opacity1.Opacity = opacity1.Opacity - 0.05f;
							if (value.Opacity > 0f)
							{
								break;
							}
							value.Opacity = 0f;
							value.Mode = OverlayMode.Inactive;
							this._activeOverlays[j].Remove(k);
							break;
						}
					}
				}
			}
		}

		public override void OnActivate(Overlay overlay, Vector2 position)
		{
			LinkedList<Overlay> overlays = this._activeOverlays[(int)overlay.Priority];
			if (overlay.Mode == OverlayMode.FadeIn || overlay.Mode == OverlayMode.Active)
			{
				return;
			}
			if (overlay.Mode != OverlayMode.FadeOut)
			{
				overlay.Opacity = 0f;
			}
			else
			{
				overlays.Remove(overlay);
			}
			if (overlays.Count != 0)
			{
				foreach (Overlay overlay1 in overlays)
				{
					overlay1.Mode = OverlayMode.FadeOut;
				}
			}
			overlays.AddLast(overlay);
		}
	}
}