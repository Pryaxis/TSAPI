using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil.Cil;
using OTAPI.Patcher.Engine.Modification;

namespace Mintaka.Modifications.Platform
{
	/// <summary>
	/// This modification will make OTAPI initialized with right platform rather than Windows platform.
	/// This should fix different world path OTAPI used on macOS
	/// In addition, the console input will also be fixed.
	/// </summary>
	public class PlatformModification : ModificationBase
	{
		public override IEnumerable<string> AssemblyTargets => new[]
		{
			"OTAPI, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null"
		};

		public override string Description => "Enforcing OTAPI to load right platform...";

		public override void Run()
		{
			ReLogic.OS.Platform temp = null;
			var changePlatformMethodDefinition = SourceDefinition.MainModule.Import(Method(() => Callbacks.PlatformConstructorCallback.ChangePlatform(ref temp)));

			var field = Field(() => ReLogic.OS.Platform.Current);
			var cctor = Type<ReLogic.OS.Platform>().Methods.Single(m => m.Name == ".cctor");
			var instructions = cctor.Body.Instructions;

			if (instructions?.Count != 3 || instructions[1].OpCode != OpCodes.Stsfld || instructions[1].Operand != field)
			{
				throw new NotSupportedException("Could not patch Platform..cctor()");
			}

			var processor = cctor.Body.GetILProcessor();

			processor.Body.Instructions.Clear();

			processor.Append(Instruction.Create(OpCodes.Ldsflda, field));
			processor.Append(Instruction.Create(OpCodes.Call, changePlatformMethodDefinition));
			processor.Append(Instruction.Create(OpCodes.Ret));
		}

	}
}
