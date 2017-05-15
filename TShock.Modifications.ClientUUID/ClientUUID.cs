using OTAPI.Patcher.Engine.Extensions;
using OTAPI.Patcher.Engine.Modification;

namespace Mintaka.Modifications.ClientUUID
{
	public class ClientUUID : ModificationBase
	{
		public override System.Collections.Generic.IEnumerable<string> AssemblyTargets => new[]
		{
			"OTAPI, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null"
		};
		public override string Description => "Adding RemoteClient.ClientUUID...";
		public override void Run()
		{
			this.SourceDefinition.Type("Terraria.RemoteClient").Fields.Add(new Mono.Cecil.FieldDefinition(
				"ClientUUID",
				Mono.Cecil.FieldAttributes.Public,
				this.SourceDefinition.MainModule.TypeSystem.String
			));
		}
	}
}
