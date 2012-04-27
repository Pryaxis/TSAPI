using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Hooks
{
	public class StatueSpawnEventArgs : HandledEventArgs
	{
        public int Within200 { get; set; }
        public int Within600 { get; set; }
        public int WorldWide { get; set; }
        public int Type { get; set; }
        public bool NPC { get; set; }
	}
}
