using System;

namespace Terraria.Social
{
	public interface ISocialModule
	{
		void Initialize();

		void Shutdown();
	}
}