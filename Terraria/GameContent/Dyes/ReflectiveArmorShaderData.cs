using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Dyes
{
	public class ReflectiveArmorShaderData : ArmorShaderData
	{
		public ReflectiveArmorShaderData(Effect shader, string passName) : base(shader, passName)
		{
		}

		public override void Apply(Entity entity, DrawData? drawData)
		{
			if (entity != null)
			{
				float value = 0f;
				if (drawData.HasValue)
				{
					value = drawData.Value.rotation;
				}
				Vector2 vector2 = entity.position;
				float single = (float)entity.width;
				float single1 = (float)entity.height;
				vector2 = vector2 + (new Vector2(single, single1) * 0.1f);
				single = single * 0.8f;
				single1 = single1 * 0.8f;
				Vector3 subLight = Lighting.GetSubLight(vector2 + new Vector2(single * 0.5f, 0f));
				Vector3 vector3 = Lighting.GetSubLight(vector2 + new Vector2(0f, single1 * 0.5f));
				Vector3 subLight1 = Lighting.GetSubLight(vector2 + new Vector2(single, single1 * 0.5f));
				Vector3 vector31 = Lighting.GetSubLight(vector2 + new Vector2(single * 0.5f, single1));
				float x = subLight.X + subLight.Y + subLight.Z;
				float x1 = vector3.X + vector3.Y + vector3.Z;
				float x2 = subLight1.X + subLight1.Y + subLight1.Z;
				float single2 = vector31.X + vector31.Y + vector31.Z;
				Vector2 vector21 = new Vector2(x2 - x1, single2 - x);
				if (vector21.Length() > 1f)
				{
					vector21 = vector21 / 1f;
				}
				if (entity.direction == -1)
				{
					vector21.X = vector21.X * -1f;
				}
				vector21 = vector21.RotatedBy((double)(-value), new Vector2());
				Vector3 y = new Vector3(vector21, 1f - (vector21.X * vector21.X + vector21.Y * vector21.Y));
				y.X *= 2f;
				y.Y = 0.15f;
				y.Y = y.Y * 2f;
				y.Normalize();
				y.Z = y.Z * 0.6f;
				this._shader.Parameters["uLightSource"].SetValue(y);
			}
			else
			{
				this._shader.Parameters["uLightSource"].SetValue(Vector3.Zero);
			}
			base.Apply(entity, drawData);
		}
	}
}