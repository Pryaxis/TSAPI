using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Hooks
{
	public class NpcLootDropEventArgs : HandledEventArgs
	{
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Stack { get; set; }
        public int ItemID { get; set; }
        public bool Broadcast { get; set; }
        public int Prefix { get; set; }
        public int NPCID { get; set; }
        public int NPCArrayIndex { get; set; }
	}
}
