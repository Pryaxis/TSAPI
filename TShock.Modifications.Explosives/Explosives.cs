using OTAPI.Patcher.Engine.Extensions;
using OTAPI.Patcher.Engine.Modification;
using System.Linq;

namespace Mintaka.Modifications.Explosives
{
	public class Explosives : ModificationBase
	{
		public override System.Collections.Generic.IEnumerable<string> AssemblyTargets => new[]
		{
			"OTAPI, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null"
		};
		public override string Description => "Adding ItemID.Sets.Explosives...";
		public override void Run()
		{
			var sets = this.SourceDefinition.Type("Terraria.ID.ItemID").NestedType("Sets");

			sets.Fields.Add(new Mono.Cecil.FieldDefinition("Explosives",
				Mono.Cecil.FieldAttributes.Public | Mono.Cecil.FieldAttributes.Static,
				this.SourceDefinition.MainModule.Import(typeof(bool[]))
			));
		}
	}
}
