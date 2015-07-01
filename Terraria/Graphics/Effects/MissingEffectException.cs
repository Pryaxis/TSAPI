using System;

namespace Terraria.Graphics.Effects
{
	internal class MissingEffectException : Exception
	{
		public MissingEffectException(string text) : base(text)
		{
		}
	}
}