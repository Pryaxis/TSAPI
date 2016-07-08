using System.ComponentModel;

namespace TerrariaApi.Server {
	public class TriggerAnnouncementBoxEventArgs : HandledEventArgs 
	{
		public int TileX 
		{
			get;
			set;
		}

		public int TileY 
		{
			get;
			set;
		}

		public int Who 
		{
			get;
			internal set;
		}

		public int Sign
		{
			get;
			internal set;
		}

		public string Text 
		{
			get;
			internal set;
		}
	}
}
