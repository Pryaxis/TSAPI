using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Terraria;

namespace TerrariaApi.Server
{
	public class ProjectileAiUpdateEventArgs : HandledEventArgs
	{
		public Projectile Projectile { get; set; }
	}
}
