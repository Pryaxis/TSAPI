using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil.Cil;
using OTAPI.Patcher.Engine.Modification;

namespace Mintaka.Modifications.UnicodeInput
{
	/// <summary>
	/// This modification works around the use of System.Text.Encoding.Unicode in the official server which breaks
	/// console I/O in macOS and Linux.  Setting the encoding to UTF8 should enable the full range of Terraria's
	/// localizations, and enable input cross-platform.
	/// </summary>
	public class UnicodeInputModification : ModificationBase
	{
		public override IEnumerable<string> AssemblyTargets => new[]
		{
			"OTAPI, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null"
		};

		public override string Description => "Changing Console's Input/Output encoding to UTF-8";

		public override void Run()
		{
			var consoleInitMethodDefinition = SourceDefinition.MainModule.Import(Method(() => Callbacks.InitializeConsoleOutputCallback.InitializeConsoleOutput()));
			var processor = Method(() => Terraria.Program.InitializeConsoleOutput()).Body.GetILProcessor();

			/*
			 * There is a .try block in the original code, which means the stack and exception handlers must be
             * cleared and reset to 1
             */
			processor.Body.Instructions.Clear();
			processor.Body.Variables.Clear();
			processor.Body.ExceptionHandlers.Clear();
			processor.Body.MaxStackSize = 1;

			processor.Append(Instruction.Create(OpCodes.Call, consoleInitMethodDefinition));
			processor.Append(Instruction.Create(OpCodes.Ret));
		}

	}
}
