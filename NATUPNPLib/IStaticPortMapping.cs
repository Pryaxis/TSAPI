// Type: NATUPNPLib.IStaticPortMapping
// Assembly: TerrariaServer, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: EB2F1A62-51C4-4A10-89A0-0EEF96EDFF7B
// Assembly location: C:\Users\Virus\Desktop\Terraria 1.2 vanilla server\TerrariaServer.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NATUPNPLib
{
  [CompilerGenerated]
  [Guid("6F10711F-729B-41E5-93B8-F21D0F818DF1")]
  [TypeIdentifier]
  [ComImport]
  public interface IStaticPortMapping
  {
    int InternalPort { [DispId(3)] get; }

    string Protocol { [DispId(4)] get; }

    string InternalClient { [DispId(5)] get; }

    [SpecialName]
    void _VtblGap1_2();
  }
}
