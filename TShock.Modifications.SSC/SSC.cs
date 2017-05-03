using Mono.Cecil;
using Mono.Cecil.Cil;
using OTAPI.Patcher.Engine.Extensions;
using OTAPI.Patcher.Engine.Extensions.ILProcessor;
using OTAPI.Patcher.Engine.Modification;
using System.Linq;

namespace Mintaka.Modifications.SSC
{
	/// <summary>
	/// This modification is used to inject the server side characters flag into the send data
	/// method so the client is triggered into the mode, as vanilla does not do this
	/// </summary>
	public class SSC : ModificationBase
	{
		public override System.Collections.Generic.IEnumerable<string> AssemblyTargets => new[]
		{
			"OTAPI, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null"
		};
		public override string Description => "Adding server side character support...";
		public override void Run()
		{
			var sendData = this.Method(() => Terraria.NetMessage.SendDataDirect(0, 0, 0, Terraria.Localization.NetworkText.Empty, 0, 0, 0, 0, 0, 0, 0));

			//find the offset where we want to inject the Terraria.Main.ServerSideCharacter variable
			var downedClown = sendData.Body.Instructions.Single( //expect one for the signature this modification is based around.
				x => x.OpCode == OpCodes.Ldsfld
				&& (x.Operand as FieldReference).Name == "downedClown"
				&& x.Next.OpCode == OpCodes.Call
			).Next;

			//Insert our new instructions that will set the BitsByte at offset 6
			sendData.Body.GetILProcessor().InsertAfter(downedClown,
				new { OpCodes.Ldloca_S, Operand = (VariableDefinition)downedClown.Previous(x => x.OpCode == OpCodes.Ldloca_S).Operand },
				new { OpCodes.Ldc_I4_6 },
				new { OpCodes.Ldsfld, Operand = this.Field(() => Terraria.Main.ServerSideCharacter) },
				new { OpCodes.Call, Operand = (MethodReference)downedClown.Operand }
			);
		}
	}
}
