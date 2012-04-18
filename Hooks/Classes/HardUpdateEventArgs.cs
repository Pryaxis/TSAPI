using System;
using System.ComponentModel;
using Terraria;
namespace Hooks
{
    public class HardUpdateEventArgs : HandledEventArgs
    {
        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public int Type
        {
            get;
            set;
        }
    }
}
