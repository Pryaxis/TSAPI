using System;
using System.ComponentModel;
using Terraria;
namespace Hooks
{
	public static class GameHooks
	{
		private static bool oldGameMenu;
		public static event Action Update;
        public delegate void HardUpdateD(HardUpdateEventArgs e);
        public delegate void StatueSpawnD(StatueSpawnEventArgs e);
		public static event Action PostUpdate;
		public static event Action Initialize;
		public static event Action PostInitialize;
		public static event Action WorldConnect;
		public static event Action WorldDisconnect;
		public static event Action<HandledEventArgs> GetKeyState;
        public static event HardUpdateD HardUpdate;
        public static event StatueSpawnD StatueSpawn;
		public static bool IsWorldRunning
		{
			get;
			private set;
		}
		static GameHooks()
		{
			GameHooks.oldGameMenu = true;
			GameHooks.Update += new Action(GameHooks.GameHooks_Update);
		}
		public static void OnUpdate(bool pre)
		{
			if (pre)
			{
				if (GameHooks.Update != null)
				{
					GameHooks.Update();
					return;
				}
			}
			else
			{
				if (GameHooks.PostUpdate != null)
				{
					GameHooks.PostUpdate();
				}
			}
		}
		public static void OnInitialize(bool pre)
		{
			if (pre)
			{
				if (GameHooks.Initialize != null)
				{
					GameHooks.Initialize();
					return;
				}
			}
			else
			{
				if (GameHooks.PostInitialize != null)
				{
					GameHooks.PostInitialize();
				}
			}
		}
		private static void GameHooks_Update()
		{
			if (GameHooks.oldGameMenu != Main.gameMenu)
			{
				GameHooks.oldGameMenu = Main.gameMenu;
				if (Main.gameMenu)
				{
					GameHooks.OnWorldDisconnect();
				}
				else
				{
					GameHooks.OnWorldConnect();
				}
				GameHooks.IsWorldRunning = !Main.gameMenu;
			}
		}
		public static void OnWorldConnect()
		{
			if (GameHooks.WorldConnect != null)
			{
				GameHooks.WorldConnect();
			}
		}
		public static void OnWorldDisconnect()
		{
			if (GameHooks.WorldDisconnect != null)
			{
				GameHooks.WorldDisconnect();
			}
		}
		public static bool OnGetKeyState()
		{
			if (GameHooks.GetKeyState == null)
			{
				return false;
			}
			HandledEventArgs handledEventArgs = new HandledEventArgs();
			GameHooks.GetKeyState(handledEventArgs);
			return handledEventArgs.Handled;
		}

        public static bool OnHardUpdate(int x, int y, int type)
        {
            if (HardUpdate == null)
            {
                return false;
            }
            HardUpdateEventArgs args = new HardUpdateEventArgs
            {
                X = x,
                Y = y,
                Type = type
            };
            GameHooks.HardUpdate(args);
            return args.Handled;
        }

        public static bool OnStatueSpawn(int n1, int n2, int n3, int x, int y, int type, bool npc)
        {
            if (StatueSpawn == null)
            {
                return false;
            }
            StatueSpawnEventArgs args = new StatueSpawnEventArgs
            {
                Within200 = n1,
                Within600 = n2,
                WorldWide = n3,
                X = x,
                Y = y,
                Type = type,
                NPC = npc
            };

            GameHooks.StatueSpawn(args);

            return args.Handled;
        }
    }
}
