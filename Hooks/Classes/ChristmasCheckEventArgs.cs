using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Hooks
{
	public class ChristmasCheckEventArgs : HandledEventArgs
	{
        public bool Xmas { get; set; }
        public ChristmasCheckEventArgs(bool x)
        {
            Xmas = x;
        }
	}
}
