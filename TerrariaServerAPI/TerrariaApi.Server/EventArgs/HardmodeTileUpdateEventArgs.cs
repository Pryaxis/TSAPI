using System;
using System.ComponentModel;

namespace TerrariaApi.Server
{
  public class HardmodeTileUpdateEventArgs : HandledEventArgs
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
