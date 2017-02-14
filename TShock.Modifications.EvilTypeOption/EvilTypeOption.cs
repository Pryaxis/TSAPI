using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using OTAPI.Patcher.Engine.Modification;

namespace TShock.Modifications.EvilTypeOption
{
	public class EvilTypeOption : ModificationBase
	{
		public override System.Collections.Generic.IEnumerable<string> AssemblyTargets => new[]
		{
			"OTAPI, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null"
		};
		public override string Description => "Adding evil type options...";
		public override void Run()
		{
			var dedServ = Method(() => new Terraria.Main().DedServ());

			var worldEvil = dedServ.Body.Instructions.Single(
				x => x.OpCode == OpCodes.Ldsfld
				&& (x.Operand as FieldReference)?.Name == "SettingsUnlock_WorldEvil"
				&& x.Next.OpCode == OpCodes.Brfalse
			);

			var processor = dedServ.Body.GetILProcessor();

			processor.Remove(worldEvil.Next);
			processor.Remove(worldEvil);
		}
	}
}
