using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics;

namespace Terraria.Graphics.Shaders
{
	public class HairShaderData : ShaderData
	{
		protected Vector3 _uColor = Vector3.One;

		protected Vector3 _uSecondaryColor = Vector3.One;

		protected float _uSaturation = 1f;

		protected float _uOpacity = 1f;

		protected Ref<Texture2D> _uImage;

		protected bool _shaderDisabled;

		public bool ShaderDisabled
		{
			get
			{
				return this._shaderDisabled;
			}
		}

		public HairShaderData(Effect shader, string passName) : base(shader, passName)
		{
		}

		public virtual void Apply(Player player, DrawData? drawData = null)
		{
			if (this._shaderDisabled)
			{
				return;
			}
			this._shader.Parameters["uColor"].SetValue(this._uColor);
			this._shader.Parameters["uSaturation"].SetValue(this._uSaturation);
			this._shader.Parameters["uSecondaryColor"].SetValue(this._uSecondaryColor);
			this._shader.Parameters["uTime"].SetValue(Main.GlobalTime);
			this._shader.Parameters["uOpacity"].SetValue(this._uOpacity);
			if (!drawData.HasValue)
			{
				this._shader.Parameters["uSourceRect"].SetValue(new Vector4(0f, 0f, 4f, 4f));
			}
			else
			{
				DrawData value = drawData.Value;
				Vector4 vector4 = new Vector4((float)value.sourceRect.Value.X, (float)value.sourceRect.Value.Y, (float)value.sourceRect.Value.Width, (float)value.sourceRect.Value.Height);
				this._shader.Parameters["uSourceRect"].SetValue(vector4);
				this._shader.Parameters["uWorldPosition"].SetValue(Main.screenPosition + value.position);
				this._shader.Parameters["uImageSize0"].SetValue(new Vector2((float)value.texture.Width, (float)value.texture.Height));
			}
			if (this._uImage != null)
			{
				Main.graphics.GraphicsDevice.Textures[1] = this._uImage.Value;
				this._shader.Parameters["uImageSize1"].SetValue(new Vector2((float)this._uImage.Value.Width, (float)this._uImage.Value.Height));
			}
			if (player != null)
			{
				this._shader.Parameters["uDirection"].SetValue((float)player.direction);
			}
			this.Apply();
		}

		public virtual Color GetColor(Player player, Color lightColor)
		{
			return new Color(lightColor.ToVector4() * player.hairColor.ToVector4());
		}

		public HairShaderData UseColor(float r, float g, float b)
		{
			return this.UseColor(new Vector3(r, g, b));
		}

		public HairShaderData UseColor(Color color)
		{
			return this.UseColor(color.ToVector3());
		}

		public HairShaderData UseColor(Vector3 color)
		{
			this._uColor = color;
			return this;
		}

		public HairShaderData UseImage(string path)
		{
			this._uImage = TextureManager.Retrieve(path);
			return this;
		}

		public HairShaderData UseOpacity(float alpha)
		{
			this._uOpacity = alpha;
			return this;
		}

		public HairShaderData UseSaturation(float saturation)
		{
			this._uSaturation = saturation;
			return this;
		}

		public HairShaderData UseSecondaryColor(float r, float g, float b)
		{
			return this.UseSecondaryColor(new Vector3(r, g, b));
		}

		public HairShaderData UseSecondaryColor(Color color)
		{
			return this.UseSecondaryColor(color.ToVector3());
		}

		public HairShaderData UseSecondaryColor(Vector3 color)
		{
			this._uSecondaryColor = color;
			return this;
		}
	}
}