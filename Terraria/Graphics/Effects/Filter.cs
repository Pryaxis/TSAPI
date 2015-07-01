using Microsoft.Xna.Framework;
using System;
using Terraria.Graphics.Shaders;

namespace Terraria.Graphics.Effects
{
	internal class Filter : GameEffect
	{
		public bool Active;

		private ScreenShaderData _shader;

		public Vector2 TargetPosition = Vector2.Zero;

		public Filter(ScreenShaderData shader, EffectPriority priority = 0)
		{
			this._shader = shader;
			this._priority = priority;
		}

		internal override void Activate(Vector2 position, params object[] args)
		{
			this.TargetPosition = position;
			this.Active = true;
		}

		public void Apply()
		{
			this._shader.UseGlobalOpacity(this.Opacity);
			this._shader.UseTargetPosition(this.TargetPosition);
			this._shader.Apply();
		}

		internal override void Deactivate(params object[] args)
		{
			this.Active = false;
		}

		public ScreenShaderData GetShader()
		{
			return this._shader;
		}

		public bool IsActive()
		{
			return this.Active;
		}
	}
}