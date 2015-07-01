using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;

namespace Terraria.Graphics.Shaders
{
	public class HairShaderDataSet
	{
		protected List<HairShaderData> _shaderData = new List<HairShaderData>();

		protected Dictionary<int, short> _shaderLookupDictionary = new Dictionary<int, short>();

		protected byte _shaderDataCount;

		public HairShaderDataSet()
		{
		}

		public void Apply(short shaderId, Player player, DrawData? drawData = null)
		{
			if (shaderId == 0 || shaderId > this._shaderDataCount)
			{
				Main.pixelShader.CurrentTechnique.Passes[0].Apply();
				return;
			}
			this._shaderData[shaderId - 1].Apply(player, drawData);
		}

		public T BindShader<T>(int itemId, T shaderData)
		where T : HairShaderData
		{
			if (this._shaderDataCount == 255)
			{
				throw new Exception("Too many shaders bound.");
			}
			Dictionary<int, short> nums = this._shaderLookupDictionary;
			HairShaderDataSet hairShaderDataSet = this;
			byte num = (byte)(hairShaderDataSet._shaderDataCount + 1);
			byte num1 = num;
			hairShaderDataSet._shaderDataCount = num;
			nums[itemId] = num1;
			this._shaderData.Add(shaderData);
			return shaderData;
		}

		public Color GetColor(short shaderId, Player player, Color lightColor)
		{
			if (shaderId == 0 || shaderId > this._shaderDataCount)
			{
				return new Color(lightColor.ToVector4() * player.hairColor.ToVector4());
			}
			return this._shaderData[shaderId - 1].GetColor(player, lightColor);
		}

		public HairShaderData GetShaderFromItemId(int type)
		{
			if (!this._shaderLookupDictionary.ContainsKey(type))
			{
				return null;
			}
			return this._shaderData[this._shaderLookupDictionary[type] - 1];
		}

		public short GetShaderIdFromItemId(int type)
		{
			if (!this._shaderLookupDictionary.ContainsKey(type))
			{
				return -1;
			}
			return this._shaderLookupDictionary[type];
		}
	}
}