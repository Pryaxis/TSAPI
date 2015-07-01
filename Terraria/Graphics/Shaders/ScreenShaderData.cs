using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;

namespace Terraria.Graphics.Shaders
{
	public class ScreenShaderData : ShaderData
	{
		private Vector3 _uColor = Vector3.One;

		private Vector3 _uSecondaryColor = Vector3.One;

		private float _uOpacity = 1f;

		private float _globalOpacity = 1f;

		private float _uIntensity = 1f;

		private Vector2 _uTargetPosition = Vector2.One;

		private float _uProgress;

		public ScreenShaderData(string passName) : base(Main.screenShader, passName)
		{
		}

		public ScreenShaderData(Effect shader, string passName) : base(shader, passName)
		{
		}

		public override void Apply()
		{
			Vector2 vector2 = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			Vector2 vector21 = new Vector2((float)Main.screenWidth, (float)Main.screenHeight);
			this._shader.Parameters["uColor"].SetValue(this._uColor);
			this._shader.Parameters["uOpacity"].SetValue(this._uOpacity * this._globalOpacity);
			this._shader.Parameters["uSecondaryColor"].SetValue(this._uSecondaryColor);
			this._shader.Parameters["uTime"].SetValue(Main.GlobalTime);
			this._shader.Parameters["uScreenResolution"].SetValue(vector21);
			this._shader.Parameters["uScreenPosition"].SetValue(Main.screenPosition - vector2);
			this._shader.Parameters["uTargetPosition"].SetValue(this._uTargetPosition - vector2);
			this._shader.Parameters["uIntensity"].SetValue(this._uIntensity);
			this._shader.Parameters["uProgress"].SetValue(this._uProgress);
			base.Apply();
		}

		public virtual ScreenShaderData GetSecondaryShader(Player player)
		{
			return this;
		}

		public ScreenShaderData UseColor(float r, float g, float b)
		{
			return this.UseColor(new Vector3(r, g, b));
		}

		public ScreenShaderData UseColor(Color color)
		{
			return this.UseColor(color.ToVector3());
		}

		public ScreenShaderData UseColor(Vector3 color)
		{
			this._uColor = color;
			return this;
		}

		public ScreenShaderData UseGlobalOpacity(float opacity)
		{
			this._globalOpacity = opacity;
			return this;
		}

		public ScreenShaderData UseIntensity(float intensity)
		{
			this._uIntensity = intensity;
			return this;
		}

		public ScreenShaderData UseOpacity(float opacity)
		{
			this._uOpacity = opacity;
			return this;
		}

		public ScreenShaderData UseProgress(float progress)
		{
			this._uProgress = progress;
			return this;
		}

		public ScreenShaderData UseSecondaryColor(float r, float g, float b)
		{
			return this.UseSecondaryColor(new Vector3(r, g, b));
		}

		public ScreenShaderData UseSecondaryColor(Color color)
		{
			return this.UseSecondaryColor(color.ToVector3());
		}

		public ScreenShaderData UseSecondaryColor(Vector3 color)
		{
			this._uSecondaryColor = color;
			return this;
		}

		public ScreenShaderData UseTargetPosition(Vector2 position)
		{
			this._uTargetPosition = position;
			return this;
		}
	}
}