using Microsoft.Xna.Framework.Graphics;
using System;

namespace Terraria.Graphics.Shaders
{
	public class ShaderData
	{
		protected Effect _shader;

		protected string _passName;

		protected EffectPass _effectPass;

		public ShaderData(Effect shader, string passName)
		{
			this._passName = passName;
			this._shader = shader;
			if (shader != null && passName != null)
			{
				this._effectPass = shader.CurrentTechnique.Passes[passName];
			}
		}

		public virtual void Apply()
		{
			this._effectPass.Apply();
		}

		public void SwapProgram(string passName)
		{
			this._passName = passName;
			if (passName != null)
			{
				this._effectPass = this._shader.CurrentTechnique.Passes[passName];
			}
		}
	}
}