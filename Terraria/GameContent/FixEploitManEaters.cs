using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria.GameContent
{
	public static class FixExploitManEaters
	{
		public static void ProtectSpot(int x, int y)
		{
			int item = (x & 65535) << 16 | (y & 65535);
			if (!FixExploitManEaters._indexesProtected.Contains(item))
			{
				FixExploitManEaters._indexesProtected.Add(item);
			}
		}

		public static bool SpotProtected(int x, int y)
		{
			int item = (x & 65535) << 16 | (y & 65535);
			return FixExploitManEaters._indexesProtected.Contains(item);
		}

		public static void Update()
		{
			FixExploitManEaters._indexesProtected.Clear();
		}

		private static List<int> _indexesProtected = new List<int>();
	}
}
