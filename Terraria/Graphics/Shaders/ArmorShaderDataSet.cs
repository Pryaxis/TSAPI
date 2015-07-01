using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;

namespace Terraria.Graphics.Shaders
{
	public class ArmorShaderDataSet
	{
		protected List<ArmorShaderData> _shaderData = new List<ArmorShaderData>();

		protected Dictionary<int, int> _shaderLookupDictionary = new Dictionary<int, int>();

		protected int _shaderDataCount;

		public ArmorShaderDataSet()
		{
		}

		public void Apply(int shaderId, Entity entity, DrawData? drawData = null)
		{
			if (shaderId == 0 || shaderId > this._shaderDataCount)
			{
				Main.pixelShader.CurrentTechnique.Passes[0].Apply();
				return;
			}
			this._shaderData[shaderId - 1].Apply(entity, drawData);
		}

		public void ApplySecondary(int shaderId, Entity entity, DrawData? drawData = null)
		{
			if (shaderId == 0 || shaderId > this._shaderDataCount)
			{
				Main.pixelShader.CurrentTechnique.Passes[0].Apply();
				return;
			}
			this._shaderData[shaderId - 1].GetSecondaryShader(entity).Apply(entity, drawData);
		}

		public T BindShader<T>(int itemId, T shaderData)
		where T : ArmorShaderData
		{
			ArmorShaderDataSet armorShaderDataSet = this;
			int num = armorShaderDataSet._shaderDataCount + 1;
			int num1 = num;
			armorShaderDataSet._shaderDataCount = num;
			this._shaderLookupDictionary[itemId] = num1;
			this._shaderData.Add(shaderData);
			return shaderData;
		}

		public ArmorShaderData GetSecondaryShader(int id, Player player)
		{
			if (id == 0 || id > this._shaderDataCount || this._shaderData[id - 1] == null)
			{
				return null;
			}
			return this._shaderData[id - 1].GetSecondaryShader(player);
		}

		public ArmorShaderData GetShaderFromItemId(int type)
		{
			if (!this._shaderLookupDictionary.ContainsKey(type))
			{
				return null;
			}
			return this._shaderData[this._shaderLookupDictionary[type] - 1];
		}

		public int GetShaderIdFromItemId(int type)
		{
			if (!this._shaderLookupDictionary.ContainsKey(type))
			{
				return 0;
			}
			return this._shaderLookupDictionary[type];
		}
	}
}