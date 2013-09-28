using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

using Terraria;

namespace TerrariaApi.Server
{
	public delegate void HookHandler<in ArgumentType>(ArgumentType args) where ArgumentType: EventArgs;

	public class HookManager
	{
		#region Client Hooks
		#region ClientChatReceived
		private readonly HandlerCollection<ChatReceivedEventArgs> clientChatReceived = 
			new HandlerCollection<ChatReceivedEventArgs>("ClientChatReceived");

		public HandlerCollection<ChatReceivedEventArgs> ClientChatReceived
		{
			get { return this.clientChatReceived; }
		}

		internal void InvokeClientChatReceived(byte playerID, Color color, string message)
		{
			ChatReceivedEventArgs args = new ChatReceivedEventArgs
			{
				PlayerID = playerID,
				Color = color,
				Message = message
			};

			this.ClientChatReceived.Invoke(args);
		}
		#endregion

		#region ClientChat
		private readonly HandlerCollection<ChatEventArgs> clientChat = 
			new HandlerCollection<ChatEventArgs>("ClientChat");

		public HandlerCollection<ChatEventArgs> ClientChat
		{
			get { return this.clientChat; }
		}

		internal bool InvokeClientChat(ref string message)
		{
			ChatEventArgs args = new ChatEventArgs
			{
				Message = message
			};

			this.ClientChat.Invoke(args);

			message = args.Message;
			return args.Handled;
		}
		#endregion
		#endregion

		#region Game Hooks
		#region GameUpdate
		private readonly HandlerCollection<EventArgs> gameUpdate = 
			new HandlerCollection<EventArgs>("GameUpdate");

		public HandlerCollection<EventArgs> GameUpdate
		{
			get { return this.gameUpdate; }
		}

		private bool currentGameMenuState;
		internal void InvokeGameUpdate()
		{
			if (this.currentGameMenuState != Main.gameMenu)
			{
				this.currentGameMenuState = Main.gameMenu;

				if (Main.gameMenu)
					this.InvokeGameWorldDisconnect();
				else
					this.InvokeGameWorldConnect();

				ServerApi.IsWorldRunning = !Main.gameMenu;
			}

			this.GameUpdate.Invoke(EventArgs.Empty);
		}
		#endregion

		#region GamePostUpdate
		private readonly HandlerCollection<EventArgs> gamePostUpdate = 
			new HandlerCollection<EventArgs>("GamePostUpdate");

		public HandlerCollection<EventArgs> GamePostUpdate
		{
			get { return this.gamePostUpdate; }
		}

		internal void InvokeGamePostUpdate()
		{
			this.GamePostUpdate.Invoke(EventArgs.Empty);
		}
		#endregion

		#region GameHardmodeTileUpdate
		private readonly HandlerCollection<HardmodeTileUpdateEventArgs> gameHardmodeTileUpdate = 
			new HandlerCollection<HardmodeTileUpdateEventArgs>("GameHardmodeTileUpdate");

		public HandlerCollection<HardmodeTileUpdateEventArgs> GameHardmodeTileUpdate
		{
			get { return this.gameHardmodeTileUpdate; }
		}

		internal bool InvokeGameHardmodeTileUpdate(int x, int y, int type)
		{
			HardmodeTileUpdateEventArgs args = new HardmodeTileUpdateEventArgs
			{
				X = x,
				Y = y,
				Type = type
			};

			this.GameHardmodeTileUpdate.Invoke(args);
			return args.Handled;
		}
		#endregion

		#region GameInitialize
		private readonly HandlerCollection<EventArgs> gameInitialize = 
			new HandlerCollection<EventArgs>("GameInitialize");

		public HandlerCollection<EventArgs> GameInitialize
		{
			get { return this.gameInitialize; }
		}

		internal void InvokeGameInitialize()
		{
			this.GameInitialize.Invoke(EventArgs.Empty);
		}
		#endregion

		#region GamePostInitialize
		private readonly HandlerCollection<EventArgs> gamePostInitialize = 
			new HandlerCollection<EventArgs>("GamePostInitialize");

		public HandlerCollection<EventArgs> GamePostInitialize
		{
			get { return this.gamePostInitialize; }
		}

		internal void InvokeGamePostInitialize()
		{
			this.GamePostInitialize.Invoke(EventArgs.Empty);
		}
		#endregion

		#region GameWorldConnect
		private readonly HandlerCollection<EventArgs> gameWorldConnect = 
			new HandlerCollection<EventArgs>("GameWorldConnect");

		public HandlerCollection<EventArgs> GameWorldConnect
		{
			get { return this.gameWorldConnect; }
		}

		internal void InvokeGameWorldConnect()
		{
			this.GameWorldConnect.Invoke(EventArgs.Empty);
		}
		#endregion

		#region GameWorldDisconnect
		private readonly HandlerCollection<EventArgs> gameWorldDisconnect = 
			new HandlerCollection<EventArgs>("GameWorldDisconnect");

		public HandlerCollection<EventArgs> GameWorldDisconnect
		{
			get { return this.gameWorldDisconnect; }
		}

		internal void InvokeGameWorldDisconnect()
		{
			this.GameWorldDisconnect.Invoke(EventArgs.Empty);
		}
		#endregion

		#region GameGetKeyState
		private readonly HandlerCollection<HandledEventArgs> gameGetKeyState = 
			new HandlerCollection<HandledEventArgs>("GameGetKeyState");

		public HandlerCollection<HandledEventArgs> GameGetKeyState
		{
			get { return this.gameGetKeyState; }
		}

		internal bool InvokeGameGetKeyState()
		{
			HandledEventArgs args = new HandledEventArgs();
			this.GameGetKeyState.Invoke(args);
			return args.Handled;
		}
		#endregion

		#region GameStatueSpawn
		private readonly HandlerCollection<StatueSpawnEventArgs> gameStatueSpawn = 
			new HandlerCollection<StatueSpawnEventArgs>("GameStatueSpawn");

		public HandlerCollection<StatueSpawnEventArgs> GameStatueSpawn
		{
			get { return this.gameStatueSpawn; }
		}

		internal bool InvokeGameStatueSpawn(int within200, int within600, int worldWide, int x, int y, int type, bool npc)
		{
			StatueSpawnEventArgs args = new StatueSpawnEventArgs
			{
				Within200 = within200,
				Within600 = within600,
				WorldWide = worldWide,
				X = x,
				Y = y,
				Type = type,
				Npc = npc
			};

			this.GameStatueSpawn.Invoke(args);
			return args.Handled;
		}
		#endregion
		#endregion

		#region Item Hooks
		#region ItemSetDefaultsInt
		private readonly HandlerCollection<SetDefaultsEventArgs<Item, int>> itemSetDefaultsInt = 
			new HandlerCollection<SetDefaultsEventArgs<Item, int>>("ItemSetDefaultsInt");

		public HandlerCollection<SetDefaultsEventArgs<Item, int>> ItemSetDefaultsInt
		{
			get { return this.itemSetDefaultsInt; }
		}

		internal bool InvokeItemSetDefaultsInt(ref int itemType, Item item)
		{
			SetDefaultsEventArgs<Item, int> args = new SetDefaultsEventArgs<Item, int>
			{
				Info = itemType,
				Object = item
			};

			this.ItemSetDefaultsInt.Invoke(args);

			itemType = args.Info;
			return args.Handled;
		}
		#endregion

		#region ItemSetDefaultsString
		private readonly HandlerCollection<SetDefaultsEventArgs<Item, string>> itemSetDefaultsString = 
			new HandlerCollection<SetDefaultsEventArgs<Item, string>>("ItemSetDefaultsString");

		public HandlerCollection<SetDefaultsEventArgs<Item, string>> ItemSetDefaultsString
		{
			get { return this.itemSetDefaultsString; }
		}

		internal bool InvokeItemSetDefaultsString(ref string itemName, Item item)
		{
			SetDefaultsEventArgs<Item, string> args = new SetDefaultsEventArgs<Item, string>
			{
				Info = itemName,
				Object = item
			};

			this.ItemSetDefaultsString.Invoke(args);

			itemName = args.Info;
			return args.Handled;
		}
		#endregion

		#region ItemNetDefaults
		private readonly HandlerCollection<SetDefaultsEventArgs<Item, int>> itemNetDefaults = 
			new HandlerCollection<SetDefaultsEventArgs<Item, int>>("ItemNetDefaults");

		public HandlerCollection<SetDefaultsEventArgs<Item, int>> ItemNetDefaults
		{
			get { return this.itemNetDefaults; }
		}

		internal bool InvokeItemNetDefaults(ref int netType, Item item)
		{
			SetDefaultsEventArgs<Item, int> args = new SetDefaultsEventArgs<Item, int>
			{
				Info = netType,
				Object = item
			};

			this.ItemNetDefaults.Invoke(args);

			netType = args.Info;
			return args.Handled;
		}
		#endregion
		#endregion

		#region Net Hooks
		#region NetSendData
		private readonly HandlerCollection<SendDataEventArgs> netSendData = 
			new HandlerCollection<SendDataEventArgs>("NetSendData");

		public HandlerCollection<SendDataEventArgs> NetSendData
		{
			get { return this.netSendData; }
		}

		internal bool InvokeNetSendData(
			ref int msgType, ref int remoteClient, ref int ignoreClient, ref string text, 
			ref int number, ref float number2, ref float number3, ref float number4, ref int number5)
		{
			if (Main.netMode != 2 && msgType == (int)PacketTypes.ChatText && this.InvokeClientChat(ref text))
				return true;

			SendDataEventArgs args = new SendDataEventArgs
			{
				MsgId = (PacketTypes)msgType, 
				remoteClient = remoteClient, 
				ignoreClient = ignoreClient, 
				text = text, 
				number = number, 
				number2 = number2, 
				number3 = number3, 
				number4 = number4,
				number5 = number5
			};

			this.NetSendData.Invoke(args);

			msgType = (int)args.MsgId;
			remoteClient = args.remoteClient;
			ignoreClient = args.ignoreClient;
			text = args.text;
			number = args.number;
			number2 = args.number2;
			number3 = args.number3;
			number4 = args.number4;
			return args.Handled;
		}
		#endregion

		#region NetGetData
		private readonly HandlerCollection<GetDataEventArgs> netGetData = 
			new HandlerCollection<GetDataEventArgs>("NetGetData");

		public HandlerCollection<GetDataEventArgs> NetGetData
		{
			get { return this.netGetData; }
		}

		internal bool InvokeNetGetData(ref byte msgId, messageBuffer buffer, ref int index, ref int length)
		{
			if (Main.netMode != 2 && msgId == (byte)PacketTypes.ChatText && length > 3)
			{
				byte playerID = buffer.readBuffer[index];
				Color color = new Color(buffer.readBuffer[index + 1] << 16, buffer.readBuffer[index + 2] << 8, buffer.readBuffer[index + 3]);
				string @string = Encoding.UTF8.GetString(buffer.readBuffer, index + 4, length - 5);
				this.InvokeClientChatReceived(playerID, color, @string);
			}

			if (Main.netMode == 2)
			{
				switch ((PacketTypes)msgId)
				{
					case PacketTypes.ConnectRequest:
						if (this.InvokeServerConnect(buffer.whoAmI))
						{
							Netplay.serverSock[buffer.whoAmI].kill = true;
							return true;
						}

						break;
					/*case PacketTypes.ContinueConnecting2:
						if (this.InvokeServerJoin(buffer.whoAmI))
						{
							Netplay.serverSock[buffer.whoAmI].kill = true;
							return true;
						}

						break;*/
					case PacketTypes.ChatText:
						string @string = Encoding.UTF8.GetString(buffer.readBuffer, index + 4, length - 5);
						if (this.InvokeServerChat(buffer, buffer.whoAmI, @string))
							return true;

						break;
				}
			}

			GetDataEventArgs args = new GetDataEventArgs
			{
				MsgID = (PacketTypes)msgId, 
				Msg = buffer, 
				Index = index, 
				Length = length
			};

			this.NetGetData.Invoke(args);

			msgId = (byte)args.MsgID;
			index = args.Index;
			length = args.Length;
			return args.Handled;
		}
		#endregion

		#region NetGreetPlayer
		private readonly HandlerCollection<GreetPlayerEventArgs> netGreetPlayer = 
			new HandlerCollection<GreetPlayerEventArgs>("NetGreetPlayer");

		public HandlerCollection<GreetPlayerEventArgs> NetGreetPlayer
		{
			get { return this.netGreetPlayer; }
		}

		internal bool InvokeNetGreetPlayer(int who)
		{
			GreetPlayerEventArgs args = new GreetPlayerEventArgs
			{
				Who = who
			};

			this.NetGreetPlayer.Invoke(args);
			
			return args.Handled;
		}
		#endregion

		#region NetSendBytes
		private readonly HandlerCollection<SendBytesEventArgs> netSendBytes = 
			new HandlerCollection<SendBytesEventArgs>("NetSendBytes");

		public HandlerCollection<SendBytesEventArgs> NetSendBytes
		{
			get { return this.netSendBytes; }
		}

		internal bool InvokeNetSendBytes(ServerSock socket, byte[] buffer, int offset, int count)
		{
			SendBytesEventArgs args = new SendBytesEventArgs
			{
				Socket = socket,
				Buffer = buffer,
				Offset = offset,
				Count = count
			};

			this.NetSendBytes.Invoke(args);
			return args.Handled;
		}
		#endregion

		#region NetNameCollision
		private readonly HandlerCollection<NameCollisionEventArgs> netNameCollision = 
			new HandlerCollection<NameCollisionEventArgs>("NetNameCollision");

		public HandlerCollection<NameCollisionEventArgs> NetNameCollision
		{
			get { return this.netNameCollision; }
		}

		internal bool InvokeNetNameCollision(int who, string name)
		{
			NameCollisionEventArgs args = new NameCollisionEventArgs
			{
				Who = who,
				Name = name
			};

			this.NetNameCollision.Invoke(args);
			return args.Handled;
		}
		#endregion
		#endregion

		#region Npc Hooks
		#region NpcSetDefaultsInt
		private readonly HandlerCollection<SetDefaultsEventArgs<NPC, int>> npcSetDefaultsInt = 
			new HandlerCollection<SetDefaultsEventArgs<NPC, int>>("NpcSetDefaultsInt");

		public HandlerCollection<SetDefaultsEventArgs<NPC, int>> NpcSetDefaultsInt
		{
			get { return this.npcSetDefaultsInt; }
		}

		internal bool InvokeNpcSetDefaultsInt(ref int npcType, NPC npc)
		{
			SetDefaultsEventArgs<NPC, int> args = new SetDefaultsEventArgs<NPC, int>
			{
				Object = npc, 
				Info = npcType
			};

			this.NpcSetDefaultsInt.Invoke(args);

			npcType = args.Info;
			return args.Handled;
		}
		#endregion

		#region NpcSetDefaultsString
		private readonly HandlerCollection<SetDefaultsEventArgs<NPC, string>> npcSetDefaultsString = 
			new HandlerCollection<SetDefaultsEventArgs<NPC, string>>("NpcSetDefaultsString");

		public HandlerCollection<SetDefaultsEventArgs<NPC, string>> NpcSetDefaultsString
		{
			get { return this.npcSetDefaultsString; }
		}

		internal bool InvokeNpcSetDefaultsString(ref string npcName, NPC npc)
		{
			SetDefaultsEventArgs<NPC, string> args = new SetDefaultsEventArgs<NPC, string>
			{
				Object = npc, 
				Info = npcName
			};

			this.NpcSetDefaultsString.Invoke(args);

			npcName = args.Info;
			return args.Handled;
		}
		#endregion

		#region NpcNetDefaults
		private readonly HandlerCollection<SetDefaultsEventArgs<NPC, int>> npcNetDefaults = 
			new HandlerCollection<SetDefaultsEventArgs<NPC, int>>("NpcNetDefaults");

		public HandlerCollection<SetDefaultsEventArgs<NPC, int>> NpcNetDefaults
		{
			get { return this.npcNetDefaults; }
		}

		internal bool InvokeNpcNetDefaults(ref int netType, NPC npc)
		{
			SetDefaultsEventArgs<NPC, int> args = new SetDefaultsEventArgs<NPC, int>
			{
				Object = npc,
				Info = netType
			};

			this.NpcNetDefaults.Invoke(args);

			netType = args.Info;
			return args.Handled;
		}
		#endregion

		#region NpcStrike
		private readonly HandlerCollection<NpcStrikeEventArgs> npcStrike = 
			new HandlerCollection<NpcStrikeEventArgs>("NpcStrike");

		public HandlerCollection<NpcStrikeEventArgs> NpcStrike
		{
			get { return this.npcStrike; }
		}

		internal bool InvokeNpcStrike(
			NPC npc, ref int damage, ref float knockback, ref int hitDirection, ref bool crit, ref bool noEffect, 
			ref double returnDamage)
		{
			NpcStrikeEventArgs args = new NpcStrikeEventArgs
			{
				Npc = npc, 
				Damage = damage, 
				KnockBack = knockback, 
				HitDirection = hitDirection, 
				Critical = crit,
				NoEffect = noEffect,
				ReturnDamage = returnDamage
			};

			this.NpcStrike.Invoke(args);

			damage = args.Damage;
			knockback = args.KnockBack;
			hitDirection = args.HitDirection;
			crit = args.Critical;
			noEffect = args.NoEffect;
			returnDamage = args.ReturnDamage;
			return args.Handled;
		}
		#endregion

		#region NpcSpawn
		private readonly HandlerCollection<NpcSpawnEventArgs> npcSpawn = 
			new HandlerCollection<NpcSpawnEventArgs>("NpcSpawn");

		public HandlerCollection<NpcSpawnEventArgs> NpcSpawn
		{
			get { return this.npcSpawn; }
		}

		internal bool InvokeNpcSpawn(NPC npc)
		{
			NpcSpawnEventArgs args = new NpcSpawnEventArgs
			{
				Npc = npc
			};

			this.NpcSpawn.Invoke(args);
			return args.Handled;
		}
		#endregion

		#region NpcLootDrop
		private readonly HandlerCollection<NpcLootDropEventArgs> npcLootDrop = 
			new HandlerCollection<NpcLootDropEventArgs>("NpcLootDrop");

		public HandlerCollection<NpcLootDropEventArgs> NpcLootDrop
		{
			get { return this.npcLootDrop; }
		}

		internal bool InvokeNpcLootDrop(
			ref int x, ref int y, ref int w, ref int h, ref int itemId, ref int stack, ref bool broadcast, ref int prefix, 
			int npcId, int npcArrayIndex, ref bool nodelay)
		{
			NpcLootDropEventArgs args = new NpcLootDropEventArgs
			{
				X = x,
				Y = y,
				Width = w,
				Height = h,
				ItemId = itemId,
				Stack = stack,
				Broadcast = broadcast,
				Prefix = prefix,
				NpcId = npcId,
				NpcArrayIndex = npcArrayIndex,
				NoGrabDelay = nodelay
			};

			this.NpcLootDrop.Invoke(args);

			x = args.X;
			y = args.Y;
			w = args.Width;
			h = args.Height;
			itemId = args.ItemId;
			stack = args.Stack;
			broadcast = args.Broadcast;
			prefix = args.Prefix;
			nodelay = args.NoGrabDelay;
			return args.Handled;
		}
		#endregion
		#endregion

		#region Player Hooks
		#region PlayerUpdatePhysics
		private readonly HandlerCollection<UpdatePhysicsEventArgs> playerUpdatePhysics = 
			new HandlerCollection<UpdatePhysicsEventArgs>("PlayerUpdatePhysics");

		public HandlerCollection<UpdatePhysicsEventArgs> PlayerUpdatePhysics
		{
			get { return this.playerUpdatePhysics; }
		}

		internal void InvokePlayerUpdatePhysics(Player player)
		{
			UpdatePhysicsEventArgs args = new UpdatePhysicsEventArgs
			{
				Player = player
			};

			this.PlayerUpdatePhysics.Invoke(args);
		}
		#endregion
		#endregion

		#region Projectile Hooks
		#region ProjectileSetDefaults
		private readonly HandlerCollection<SetDefaultsEventArgs<Projectile, int>> projectileSetDefaults = 
			new HandlerCollection<SetDefaultsEventArgs<Projectile, int>>("ProjectileSetDefaults");

		public HandlerCollection<SetDefaultsEventArgs<Projectile, int>> ProjectileSetDefaults
		{
			get { return this.projectileSetDefaults; }
		}

		internal bool InvokeProjectileSetDefaults(ref int type, Projectile projectile)
		{
			SetDefaultsEventArgs<Projectile, int> args = new SetDefaultsEventArgs<Projectile, int>
			{
				Object = projectile,
				Info = type
			};

			this.ProjectileSetDefaults.Invoke(args);

			type = args.Info;
			return args.Handled;
		}
		#endregion
		#endregion

		#region Server Hooks
		#region ServerCommand
		private readonly HandlerCollection<CommandEventArgs> serverCommand = 
			new HandlerCollection<CommandEventArgs>("ServerCommand");

		public HandlerCollection<CommandEventArgs> ServerCommand
		{
			get { return this.serverCommand; }
		}

		internal bool InvokeServerCommand(string command)
		{
			CommandEventArgs args = new CommandEventArgs
			{
				Command = command
			};

			this.ServerCommand.Invoke(args);
			return args.Handled;
		}
		#endregion

		#region ServerConnect
		private readonly HandlerCollection<ConnectEventArgs> serverConnect = 
			new HandlerCollection<ConnectEventArgs>("ServerConnect");

		public HandlerCollection<ConnectEventArgs> ServerConnect
		{
			get { return this.serverConnect; }
		}

		internal bool InvokeServerConnect(int who)
		{
			ConnectEventArgs args = new ConnectEventArgs
			{
				Who = who
			};

			this.ServerConnect.Invoke(args);
			return args.Handled;
		}
		#endregion

		#region ServerJoin
		private readonly HandlerCollection<JoinEventArgs> serverJoin = 
			new HandlerCollection<JoinEventArgs>("ServerJoin");

		public HandlerCollection<JoinEventArgs> ServerJoin
		{
			get { return this.serverJoin; }
		}

		internal bool InvokeServerJoin(int who)
		{
			JoinEventArgs args = new JoinEventArgs
			{
				Who = who
			};

			this.ServerJoin.Invoke(args);
			return args.Handled;
		}
		#endregion

		#region ServerLeave
		private readonly HandlerCollection<LeaveEventArgs> serverLeave = 
			new HandlerCollection<LeaveEventArgs>("ServerLeave");

		public HandlerCollection<LeaveEventArgs> ServerLeave
		{
			get { return this.serverLeave; }
		}

		internal void InvokeServerLeave(int who)
		{
			LeaveEventArgs args = new LeaveEventArgs
			{
				Who = who
			};

			this.ServerLeave.Invoke(args);
		}
		#endregion

		#region ServerChat
		private readonly HandlerCollection<ServerChatEventArgs> serverChat = 
			new HandlerCollection<ServerChatEventArgs>("ServerChat");

		public HandlerCollection<ServerChatEventArgs> ServerChat
		{
			get { return this.serverChat; }
		}

		internal bool InvokeServerChat(messageBuffer buffer, int who, string text)
		{
			ServerChatEventArgs args = new ServerChatEventArgs
			{
				Buffer = buffer,
				Who = who,
				Text = text
			};

			this.ServerChat.Invoke(args);
			return args.Handled;
		}
		#endregion

		#region ServerSocketReset
		private readonly HandlerCollection<SocketResetEventArgs> serverSocketReset = 
			new HandlerCollection<SocketResetEventArgs>("ServerSocketReset");

		public HandlerCollection<SocketResetEventArgs> ServerSocketReset
		{
			get { return this.serverSocketReset; }
		}

		internal void InvokeServerSocketReset(ServerSock socket)
		{
			SocketResetEventArgs args = new SocketResetEventArgs
			{
				Socket = socket
			};

			this.ServerSocketReset.Invoke(args);
		}
		#endregion
		#endregion

		#region World Hooks
		#region WorldSave
		private readonly HandlerCollection<WorldSaveEventArgs> worldSave = 
			new HandlerCollection<WorldSaveEventArgs>("WorldSave");

		public HandlerCollection<WorldSaveEventArgs> WorldSave
		{
			get { return this.worldSave; }
		}

		internal bool InvokeWorldSave(bool resetTime)
		{
			WorldSaveEventArgs args = new WorldSaveEventArgs
			{
				ResetTime = resetTime
			};

			this.WorldSave.Invoke(args);
			return args.Handled;
		}
		#endregion

		#region WorldStartHardMode
		private readonly HandlerCollection<HandledEventArgs> worldStartHardMode = 
			new HandlerCollection<HandledEventArgs>("WorldStartHardMode");

		public HandlerCollection<HandledEventArgs> WorldStartHardMode
		{
			get { return this.worldStartHardMode; }
		}

		internal bool InvokeWorldStartHardMode()
		{
			HandledEventArgs args = new HandledEventArgs();
			this.WorldStartHardMode.Invoke(args);
			return args.Handled;
		}
		#endregion

		#region WorldMeteorDrop
		private readonly HandlerCollection<MeteorDropEventArgs> worldMeteorDrop = 
			new HandlerCollection<MeteorDropEventArgs>("WorldMeteorDrop");

		public HandlerCollection<MeteorDropEventArgs> WorldMeteorDrop
		{
			get { return this.worldMeteorDrop; }
		}

		internal bool InvokeWorldMeteorDrop(int x, int y)
		{
			MeteorDropEventArgs args = new MeteorDropEventArgs
			{
				X = x,
				Y = y
			};

			this.WorldMeteorDrop.Invoke(args);
			return args.Handled;
		}
		#endregion

		#region WorldChristmasCheck
		private readonly HandlerCollection<ChristmasCheckEventArgs> worldChristmasCheck = 
			new HandlerCollection<ChristmasCheckEventArgs>("WorldChristmasCheck");

		public HandlerCollection<ChristmasCheckEventArgs> WorldChristmasCheck
		{
			get { return this.worldChristmasCheck; }
		}

		internal bool InvokeWorldChristmasCheck(ref bool xmasCheck)
		{
			ChristmasCheckEventArgs args = new ChristmasCheckEventArgs
			{
				Xmas = xmasCheck
			};

			this.WorldChristmasCheck.Invoke(args);

			xmasCheck = args.Xmas;
			return args.Handled;
		}
		#endregion
		#endregion
	}
}
