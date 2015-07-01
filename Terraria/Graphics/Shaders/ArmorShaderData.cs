using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics;

namespace Terraria.Graphics.Shaders
{
	public class ArmorShaderData : ShaderData
	{
		private Vector3 _uColor = Vector3.One;

		private Vector3 _uSecondaryColor = Vector3.One;

		private float _uSaturation = 1f;

		private float _uOpacity = 1f;

		private Ref<Texture2D> _uImage;

		public ArmorShaderData(Effect shader, string passName) : base(shader, passName)
		{
		}

		public virtual void Apply(Entity entity, DrawData? drawData = null)
		{
			Vector4 vector4;
			this._shader.Parameters["uColor"].SetValue(this._uColor);
			this._shader.Parameters["uSaturation"].SetValue(this._uSaturation);
			this._shader.Parameters["uSecondaryColor"].SetValue(this._uSecondaryColor);
			this._shader.Parameters["uTime"].SetValue(Main.GlobalTime);
			this._shader.Parameters["uOpacity"].SetValue(this._uOpacity);
			if (!drawData.HasValue)
			{
				this._shader.Parameters["uSourceRect"].SetValue(new Vector4(0f, 0f, 4f, 4f));
				this._shader.Parameters["uRotation"].SetValue(0f);
			}
			else
			{
				DrawData value = drawData.Value;
				vector4 = (!value.sourceRect.HasValue ? new Vector4(0f, 0f, (float)value.texture.Width, (float)value.texture.Height) : new Vector4((float)value.sourceRect.Value.X, (float)value.sourceRect.Value.Y, (float)value.sourceRect.Value.Width, (float)value.sourceRect.Value.Height));
				this._shader.Parameters["uSourceRect"].SetValue(vector4);
				this._shader.Parameters["uWorldPosition"].SetValue(Main.screenPosition + value.position);
				this._shader.Parameters["uImageSize0"].SetValue(new Vector2((float)value.texture.Width, (float)value.texture.Height));
				this._shader.Parameters["uRotation"].SetValue(value.rotation * (value.effect.HasFlag(SpriteEffects.FlipHorizontally) ? -1f : 1f));
				this._shader.Parameters["uDirection"].SetValue((value.effect.HasFlag(SpriteEffects.FlipHorizontally) ? -1 : 1));
			}
			if (this._uImage != null)
			{
				Main.graphics.GraphicsDevice.Textures[1] = this._uImage.Value;
				this._shader.Parameters["uImageSize1"].SetValue(new Vector2((float)this._uImage.Value.Width, (float)this._uImage.Value.Height));
			}
			if (entity != null)
			{
				this._shader.Parameters["uDirection"].SetValue((float)entity.direction);
			}
			this.Apply();
		}

		public virtual ArmorShaderData GetSecondaryShader(Entity entity)
		{
			return this;
		}

		public ArmorShaderData UseColor(float r, float g, float b)
		{
			return this.UseColor(new Vector3(r, g, b));
		}

		public ArmorShaderData UseColor(Color color)
		{
			return this.UseColor(color.ToVector3());
		}

		public ArmorShaderData UseColor(Vector3 color)
		{
			this._uColor = color;
			return this;
		}

		public ArmorShaderData UseImage(string path)
		{
			this._uImage = TextureManager.Retrieve(path);
			return this;
		}

		public ArmorShaderData UseOpacity(float alpha)
		{
			this._uOpacity = alpha;
			return this;
		}

		public ArmorShaderData UseSaturation(float saturation)
		{
			this._uSaturation = saturation;
			return this;
		}

		public ArmorShaderData UseSecondaryColor(float r, float g, float b)
		{
			return this.UseSecondaryColor(new Vector3(r, g, b));
		}

		public ArmorShaderData UseSecondaryColor(Color color)
		{
			return this.UseSecondaryColor(color.ToVector3());
		}

		public ArmorShaderData UseSecondaryColor(Vector3 color)
		{
			this._uSecondaryColor = color;
			return this;
		}
	}
}