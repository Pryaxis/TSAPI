using System;
using System.ComponentModel;

namespace ServerApi
{
  public class HardUpdateEventArgs : HandledEventArgs
  {
    public int X
    {
      get;
      internal set;
    }

    public int Y
    {
      get;
      internal set;
    }

    public int Type
    {
      get;
      internal set;
    }
  }
}
