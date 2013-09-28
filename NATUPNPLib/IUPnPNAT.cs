// Type: NATUPNPLib.IUPnPNAT
// Assembly: TerrariaServer, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: EB2F1A62-51C4-4A10-89A0-0EEF96EDFF7B
// Assembly location: C:\Users\Virus\Desktop\Terraria 1.2 vanilla server\TerrariaServer.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NATUPNPLib
{
  [Guid("B171C812-CC76-485A-94D8-B6B3A2794E99")]
  [TypeIdentifier]
  [CompilerGenerated]
  [ComImport]
  public interface IUPnPNAT
  {
    IStaticPortMappingCollection StaticPortMappingCollection { [DispId(1)] get; }
  }
}
