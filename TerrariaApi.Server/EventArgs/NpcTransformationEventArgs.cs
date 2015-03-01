using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TerrariaApi.Server
{
	public class NpcTransformationEventArgs : HandledEventArgs
	{
		public int NpcId
		{
			get;
			set;
		}
	}
}
