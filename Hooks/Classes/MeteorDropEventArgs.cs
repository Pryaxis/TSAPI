using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Hooks
{
	public class MeteorDropEventArgs : HandledEventArgs
	{
        public int X { get; set; }
        public int Y { get; set; }
	}
}
