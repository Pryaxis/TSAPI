using Microsoft.Xna.Framework;
using OTAPI;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Terraria;

namespace TerrariaApi.Server
{
	public delegate void HookHandler<in ArgumentType>(ArgumentType args) where ArgumentType : EventArgs;

	public class HookManager
	{
		public static void InitialiseAPI()
		{
			//AppDomain.CurrentDomain.AssemblyResolve += delegate (object sender, ResolveEventArgs sargs)
			//{
			//	if (sargs.Name.StartsWith("TerrariaServer"))
			//	{
			//		return typeof(OTAPI.Shims.TShock.Program).Assembly;
			//	}
			//	return null;
			//};

			//Terraria.Program.LaunchParameters = Utils.ParseArguements(args);

			//Game = new Main();

			try
			{
				Console.WriteLine("TerrariaAPI Version: " + ServerApi.ApiVersion + " (Protocol {0} ({1}), OTAPI {2})",
					Terraria.Main.versionNumber2, Terraria.Main.curRelease,
					typeof(OTAPI.Hooks).Assembly.GetName().Version);
				ServerApi.Initialize(Environment.GetCommandLineArgs(), Main.instance);
			}
			catch (Exception ex)
			{
				ServerApi.LogWriter.ServerWriteLine(
					"Startup aborted due to an exception in the Server API initialization:\n" + ex, TraceLevel.Error);

				Console.ReadLine();
				return;
			}
		}

		#region
		public void AttachHooks()
		{
			Hooks.Tile.CreateCollection = () =>
			{
				return new TileProvider();
			};
			#region Game Hooks
			OTAPI.Hooks.Game.PreUpdate = (ref GameTime gameTime) =>
			{
				InvokeGameUpdate();
			};
			OTAPI.Hooks.Game.PostUpdate = (ref GameTime gameTime) =>
			{
				InvokeGamePostUpdate();
			};
			OTAPI.Hooks.World.HardmodeTileUpdate = (int x, int y, ref ushort type) =>
			{
				if (InvokeGameHardmodeTileUpdate(x, y, type))
				{
					return OTAPI.HardmodeTileUpdateResult.Cancel;
				}
				return OTAPI.HardmodeTileUpdateResult.Continue;
			};
			OTAPI.Hooks.Game.PreInitialize = () =>
			{
				HookManager.InitialiseAPI();
				//InitialiseAPI();
				InvokeGameInitialize();
			};
			//OTAPI.Hooks.Game.PostInitialize = () =>
			//{
			//	InvokeGamePostInitialize();
			//};
			OTAPI.Hooks.Game.Started = () =>
			{
				InvokeGamePostInitialize();
			};
			OTAPI.Hooks.World.Statue = (StatueType caller, float x, float y, int type, ref int num, ref int num2, ref int num3) =>
			{
				if (InvokeGameStatueSpawn(num2, num3, num, (int)x, (int)y, type, caller == StatueType.Item))
				{
					return HookResult.Cancel;
				}
				return OTAPI.HookResult.Continue;
			};
			#endregion
			#region Item Hooks
			OTAPI.Hooks.Item.PreSetDefaultsById = (Item item, ref int type, ref bool noMatCheck) =>
			{
				if (InvokeItemSetDefaultsInt(ref type, item))
				{
					return HookResult.Cancel;
				}
				return HookResult.Continue;
			};
			Hooks.Item.PreSetDefaultsByName = (Item item, ref string name) =>
			{
				if (InvokeItemSetDefaultsString(ref name, item))
				{
					return HookResult.Cancel;
				}
				return HookResult.Continue;
			};
			Hooks.Item.PreNetDefaults = (Item item, ref int type) =>
			 {
				 if (InvokeItemNetDefaults(ref type, item))
				 {
					 return HookResult.Cancel;
				 }
				 return HookResult.Continue;
			 };
			Hooks.Chest.QuickStack = (int playerId, Item item, int chestIndex) =>
			{
				if (InvokeItemForceIntoChest(Main.chest[chestIndex], item, Main.player[playerId]))
				{
					return HookResult.Cancel;
				}
				return HookResult.Continue;
			};
			#endregion
			#region Net Hooks
			Hooks.Net.SendData = (ref int bufferId, ref int msgType, ref int remoteClient, ref int ignoreClient, ref string text,
				  ref int number, ref float number2, ref float number3, ref float number4, ref int number5, ref int number6,
				  ref int number7) =>
			  {
				  if (InvokeNetSendData(ref msgType, ref remoteClient, ref ignoreClient, ref text, ref number,
					  ref number2, ref number3, ref number4, ref number5, ref number6, ref number7))
				  {
					  return HookResult.Cancel;
				  }

				  if (msgType == 25)
				  {
					  if (InvokeServerBroadcast(ref text, ref number2, ref number3, ref number4))
					  {
						  return HookResult.Cancel;
					  }
				  }

				  return HookResult.Continue;
			  };
			Hooks.Net.ReceiveData = (MessageBuffer buffer, ref byte packetId, ref int readOffset, ref int start, ref int length,
				  ref int messageType) =>
			{
				try
				{
					if (!Enum.IsDefined(typeof(PacketTypes), (int)packetId))
					{
						return HookResult.Cancel;
					}
					if (InvokeNetGetData(ref packetId, buffer, ref readOffset, ref length))
					{
						return HookResult.Cancel;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("TSAPI.HookManager.ReceiveData: " + ex);
				}
				return HookResult.Continue;
			};
			Hooks.Player.PreGreet = (ref int playerId) =>
			{
				if (InvokeNetGreetPlayer(playerId))
				{
					return HookResult.Cancel;
				}
				return HookResult.Continue;
			};
			Hooks.Net.SendBytes = (ref int remoteClient, ref byte[] data, ref int offset, ref int size,
				  ref Terraria.Net.Sockets.SocketSendCallback callback, ref object state) =>
			  {
				  if (InvokeNetSendBytes(Netplay.Clients[remoteClient], data, offset, size))
				  {
					  return HookResult.Cancel;
				  }
				  return HookResult.Continue;
			  };
			Hooks.Player.NameCollision = (Player player) =>
			 {
				 if (InvokeNetNameCollision(player.whoAmI, player.name))
				 {
					 return HookResult.Cancel;
				 }
				 return HookResult.Continue;
			 };
			#endregion
			#region Npc Hooks
			Hooks.Npc.PreSetDefaultsById = (NPC npc, ref int type, ref float scaleOverride) =>
			 {
				 if (InvokeNpcSetDefaultsInt(ref type, npc))
				 {
					 return HookResult.Cancel;
				 }
				 return HookResult.Continue;
			 };
			Hooks.Npc.PreSetDefaultsByName = (NPC npc, ref string name) =>
			 {
				 if (InvokeNpcSetDefaultsString(ref name, npc))
				 {
					 return HookResult.Cancel;
				 }
				 return HookResult.Continue;
			 };
			Hooks.Npc.PreNetDefaults = (NPC npc, ref int type) =>
			 {
				 if (InvokeNpcNetDefaults(ref type, npc))
				 {
					 return HookResult.Cancel;
				 }
				 return HookResult.Continue;
			 };
			Hooks.Npc.Strike = (NPC npc, ref int cancelResult, ref int damage, ref float knockBack,
			   ref int hitDirection, ref bool critical, ref bool noEffect, ref bool fromNet, Entity entity) =>
		   {
			   var player = entity as Player;
			   if (player != null)
			   {
				   if (InvokeNpcStrike(npc, ref damage, ref knockBack, ref hitDirection,
					   ref critical, ref noEffect, ref fromNet, player))
				   {
					   return HookResult.Cancel;
				   }
			   }
			   return HookResult.Continue;
		   };
			Hooks.Npc.PreTransform = (NPC npc, ref int newType) =>
			  {
				  if (InvokeNpcTransformation(npc.whoAmI))
				  {
					  return HookResult.Cancel;
				  }
				  return HookResult.Continue;
			  };
			Hooks.Npc.Spawn = (ref int index) =>
			{
				if (InvokeNpcSpawn(ref index))
				{
					return HookResult.Cancel;
				}
				return HookResult.Continue;
			};
			Hooks.Npc.PreDropLoot = (
				 global::Terraria.NPC npc,
				 ref int itemId,
				 ref int x,
				 ref int y,
				 ref int width,
				 ref int height,
				 ref int type,
				 ref int stack,
				 ref bool noBroadcast,
				 ref int prefix,
				 ref bool noGrabDelay,
				 ref bool reverseLookup) =>
			{
				var position = new Vector2(x, y);
				if (InvokeNpcLootDrop(ref position, ref width, ref height, ref itemId,
					ref stack, ref noBroadcast, ref prefix, npc.type, npc.whoAmI, ref noGrabDelay, ref reverseLookup))
				{
					x = (int)position.X;
					y = (int)position.Y;
					return HookResult.Cancel;
				}
				x = (int)position.X;
				y = (int)position.Y;
				return HookResult.Continue;
			};

			Hooks.Npc.BossBagItem = (
				global::Terraria.NPC npc,
			ref int X,
			ref int Y,
			ref int Width,
			 ref int Height,
			 ref int Type,
			 ref int Stack,
			 ref bool noBroadcast,
			 ref int pfix,
			ref bool noGrabDelay,
			 ref bool reverseLookup) =>
			 {
				 var positon = new Vector2(X, Y);
				 if (InvokeDropBossBag(ref positon, ref Width, ref Height, ref Type, ref Stack, ref noBroadcast, ref pfix,
					npc.type, npc.whoAmI, ref noGrabDelay, ref reverseLookup))
				 {
					 return HookResult.Cancel;
				 }
				 return HookResult.Continue;
			 };
			Hooks.Npc.PreAI = (NPC npc) =>
			 {
				 if (InvokeNpcAIUpdate(npc))
				 {
					 return HookResult.Cancel;
				 }
				 return HookResult.Continue;
			 };
			#endregion
			Hooks.Collision.PressurePlate = (ref int x, ref int y, ref Entity entity) =>
			{
				var npc = entity as NPC;
				if (npc != null)
				{
					if (InvokeNpcTriggerPressurePlate(npc, x, y))
					{
						return HookResult.Cancel;
					}
				}
				else
				{
					var player = entity as Player;
					if (player != null)
					{
						if (InvokePlayerTriggerPressurePlate(player, x, y))
						{
							return HookResult.Cancel;
						}
					}
					else
					{
						var projectile = entity as Projectile;
						if (projectile != null)
						{
							if (InvokeProjectileTriggerPressurePlate(projectile, x, y))
							{
								return HookResult.Cancel;
							}
						}
					}
				}

				return HookResult.Continue;
			};
			#region Projectile Hooks
			Hooks.Projectile.PreSetDefaultsById = (Projectile projectile, ref int type) =>
			  {
				  if (InvokeProjectileSetDefaults(ref type, projectile))
				  {
					  return HookResult.Cancel;
				  }
				  return HookResult.Continue;
			  };
			Hooks.Projectile.PreAI = (Projectile projectile) =>
			 {
				 if (InvokeProjectileAIUpdate(projectile))
				 {
					 return HookResult.Cancel;
				 }
				 return HookResult.Continue;
			 };
			#endregion
			#region Server Hooks
			Hooks.Command.Process = (string lowered, string raw) =>
			  {
				  if (InvokeServerCommand(raw))
				  {
					  return HookResult.Cancel;
				  }
				  return HookResult.Continue;
			  };
			Hooks.Net.RemoteClient.PreReset = (RemoteClient remoteClient) =>
			  {
				  InvokeServerLeave(remoteClient.Id);
				  InvokeServerSocketReset(remoteClient);
				  return HookResult.Continue;
			  };
			#endregion
			#region World Hooks
			Hooks.World.IO.PreSaveWorld = (ref bool useCloudSaving, ref bool resetTime) =>
			  {
				  if (InvokeWorldSave(resetTime))
				  {
					  return HookResult.Cancel;
				  }
				  return HookResult.Continue;
			  };
			Hooks.World.PreHardmode = () =>
			{
				if (InvokeWorldStartHardMode())
				{
					return HookResult.Cancel;
				}
				return HookResult.Continue;
			};
			Hooks.World.DropMeteor = (ref int x, ref int y) =>
			 {
				 if (InvokeWorldMeteorDrop(x, y))
				 {
					 return HookResult.Cancel;
				 }
				 return HookResult.Continue;
			 };
			Hooks.Game.Christmas = () =>
			{
				if (InvokeWorldChristmasCheck(ref Terraria.Main.xMas))
				{
					return HookResult.Cancel;
				}
				return HookResult.Continue;
			};
			Hooks.Game.Halloween = () =>
			{
				if (InvokeWorldHalloweenCheck(ref Main.halloween))
				{
					return HookResult.Cancel;
				}
				return HookResult.Continue;
			};
			#endregion
			#region Wiring Hooks
			Hooks.Wiring.AnnouncementBox = (int x, int y, int signId) =>
			 {
				 if (InvokeWireTriggerAnnouncementBox(Wiring.CurrentUser, x, y, signId, Main.sign[signId].text))
				 {
					 return HookResult.Cancel;
				 }
				 return HookResult.Continue;
			 };
			#endregion
		}
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

		#region ForceItemIntoChest
		private readonly HandlerCollection<ForceItemIntoChestEventArgs> itemForceIntoChest =
			new HandlerCollection<ForceItemIntoChestEventArgs>("ItemForceIntoChest");

		public HandlerCollection<ForceItemIntoChestEventArgs> ItemForceIntoChest
		{
			get { return this.itemForceIntoChest; }
		}

		internal bool InvokeItemForceIntoChest(Chest chest, Item item, Player player)
		{
			ForceItemIntoChestEventArgs args = new ForceItemIntoChestEventArgs()
			{
				Chest = chest,
				Item = item,
				Player = player
			};

			this.ItemForceIntoChest.Invoke(args);

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
			ref int number, ref float number2, ref float number3, ref float number4, ref int number5,
			ref int number6, ref int number7)
		{

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
				number5 = number5,
				number6 = number6,
				number7 = number7
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
			number5 = args.number5;
			number6 = args.number6;
			number7 = args.number7;
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

		internal bool InvokeNetGetData(ref byte msgId, MessageBuffer buffer, ref int index, ref int length)
		{
			if (Main.netMode == 2)
			{
				switch ((PacketTypes)msgId)
				{
					case PacketTypes.ConnectRequest:
						if (this.InvokeServerConnect(buffer.whoAmI))
						{
							Netplay.Clients[buffer.whoAmI].PendingTermination = true;
							return true;
						}

						break;
					case PacketTypes.ContinueConnecting2:
						if (this.InvokeServerJoin(buffer.whoAmI))
						{
							Netplay.Clients[buffer.whoAmI].PendingTermination = true;
							return true;
						}

						break;
					case PacketTypes.ChatText:
						var text = "";
						using (var stream = new MemoryStream(buffer.readBuffer))
						{
							stream.Position = index;
							using (var reader = new BinaryReader(stream))
							{
								reader.ReadByte();
								reader.ReadRGB();
								text = reader.ReadString();
							}
						}

						if (this.InvokeServerChat(buffer, buffer.whoAmI, @text))
							return true;

						break;

					//Making sure packet length is 38, otherwise it's not a valid UUID packet length.
					//We copy the bytes of the UUID then convert it to string. Then validating the GUID so its the correct format.
					//Then the bytes get hashed, and set as ClientUUID (and gets written in DB for auto-login)
					//length minus 2 = 36, the length of a UUID.
					case PacketTypes.ClientUUID:
						if (length == 38)
						{
							byte[] uuid = new byte[length - 2];
							Buffer.BlockCopy(buffer.readBuffer, index + 1, uuid, 0, length - 2);
							Guid guid = new Guid();
							if (Guid.TryParse(Encoding.Default.GetString(uuid, 0, uuid.Length), out guid))
							{
								SHA512 shaM = new SHA512Managed();
								var result = shaM.ComputeHash(uuid);
								Netplay.Clients[buffer.whoAmI].ClientUUID = result.Aggregate("", (s, b) => s + b.ToString("X2"));
								return true;
							}
						}
						Netplay.Clients[buffer.whoAmI].ClientUUID = "";
						return true;
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

		internal bool InvokeNetSendBytes(RemoteClient socket, byte[] buffer, int offset, int count)
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
			ref bool fromNet, Player player)
		{
			NpcStrikeEventArgs args = new NpcStrikeEventArgs
			{
				Npc = npc,
				Damage = damage,
				KnockBack = knockback,
				HitDirection = hitDirection,
				Critical = crit,
				NoEffect = noEffect,
				FromNet = fromNet,
				Player = player
			};

			this.NpcStrike.Invoke(args);

			damage = args.Damage;
			knockback = args.KnockBack;
			hitDirection = args.HitDirection;
			crit = args.Critical;
			noEffect = args.NoEffect;
			fromNet = args.FromNet;
			player = args.Player;
			return args.Handled;
		}
		#endregion

		#region NpcTransformation
		private readonly HandlerCollection<NpcTransformationEventArgs> npcTransform =
			new HandlerCollection<NpcTransformationEventArgs>("NpcTransform");

		public HandlerCollection<NpcTransformationEventArgs> NpcTransform
		{
			get { return this.npcTransform; }
		}

		internal bool InvokeNpcTransformation(int npcId)
		{
			NpcTransformationEventArgs args = new NpcTransformationEventArgs
			{
				NpcId = npcId
			};

			this.NpcTransform.Invoke(args);
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

		internal bool InvokeNpcSpawn(ref int npcId)
		{
			NpcSpawnEventArgs args = new NpcSpawnEventArgs
			{
				NpcId = npcId
			};

			this.NpcSpawn.Invoke(args);
			npcId = args.NpcId;
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
			ref Vector2 position, ref int w, ref int h, ref int itemId, ref int stack, ref bool broadcast, ref int prefix,
			int npcId, int npcArrayIndex, ref bool nodelay, ref bool reverseLookup)
		{
			NpcLootDropEventArgs args = new NpcLootDropEventArgs
			{
				Position = position,
				Width = w,
				Height = h,
				ItemId = itemId,
				Stack = stack,
				Broadcast = broadcast,
				Prefix = prefix,
				NpcId = npcId,
				NpcArrayIndex = npcArrayIndex,
				NoGrabDelay = nodelay,
				ReverseLookup = reverseLookup
			};

			this.NpcLootDrop.Invoke(args);

			position = args.Position;
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

		#region NpcTriggerPressurePlate
		private readonly HandlerCollection<TriggerPressurePlateEventArgs<NPC>> npcTriggerPressurePlate =
			new HandlerCollection<TriggerPressurePlateEventArgs<NPC>>("NpcTriggerPressurePlate");

		public HandlerCollection<TriggerPressurePlateEventArgs<NPC>> NpcTriggerPressurePlate
		{
			get { return this.npcTriggerPressurePlate; }
		}

		internal bool InvokeNpcTriggerPressurePlate(NPC npc, int tileX, int tileY)
		{
			TriggerPressurePlateEventArgs<NPC> args = new TriggerPressurePlateEventArgs<NPC>
			{
				Object = npc,
				TileX = tileX,
				TileY = tileY
			};

			this.NpcTriggerPressurePlate.Invoke(args);

			return args.Handled;
		}
		#endregion

		#region DropBossBag
		private readonly HandlerCollection<DropBossBagEventArgs> dropBossBag =
			new HandlerCollection<DropBossBagEventArgs>("DropBossBag");

		public HandlerCollection<DropBossBagEventArgs> DropBossBag
		{
			get { return this.dropBossBag; }
		}

		internal bool InvokeDropBossBag(ref Vector2 position, ref int w, ref int h, ref int itemId, ref int stack, ref bool broadcast, ref int prefix,
			int npcId, int npcArrayIndex, ref bool nodelay, ref bool reverseLookup)
		{
			DropBossBagEventArgs args = new DropBossBagEventArgs
			{
				Position = position,
				Width = w,
				Height = h,
				ItemId = itemId,
				Stack = stack,
				Broadcast = broadcast,
				Prefix = prefix,
				NpcId = npcId,
				NpcArrayIndex = npcArrayIndex,
				NoGrabDelay = nodelay,
				ReverseLookup = reverseLookup
			};

			this.DropBossBag.Invoke(args);

			position = args.Position;
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

		#region NpcAIUpdate
		private readonly HandlerCollection<NpcAiUpdateEventArgs> npcAiUpdate =
			new HandlerCollection<NpcAiUpdateEventArgs>("NpcAIUpdate");

		public HandlerCollection<NpcAiUpdateEventArgs> NpcAIUpdate
		{
			get { return this.npcAiUpdate; }
		}

		internal bool InvokeNpcAIUpdate(NPC npc)
		{
			NpcAiUpdateEventArgs args = new NpcAiUpdateEventArgs
			{
				Npc = npc
			};

			this.NpcAIUpdate.Invoke(args);

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
		#region PlayerTriggerPressurePlate
		private readonly HandlerCollection<TriggerPressurePlateEventArgs<Player>> playerTriggerPressurePlate =
			new HandlerCollection<TriggerPressurePlateEventArgs<Player>>("PlayerTriggerPressurePlate");

		public HandlerCollection<TriggerPressurePlateEventArgs<Player>> PlayerTriggerPressurePlate
		{
			get { return this.playerTriggerPressurePlate; }
		}

		internal bool InvokePlayerTriggerPressurePlate(Player player, int tileX, int tileY)
		{
			TriggerPressurePlateEventArgs<Player> args = new TriggerPressurePlateEventArgs<Player>
			{
				Object = player,
				TileX = tileX,
				TileY = tileY
			};

			this.PlayerTriggerPressurePlate.Invoke(args);

			return args.Handled;
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

		#region ProjectileTriggerPressurePlate
		private readonly HandlerCollection<TriggerPressurePlateEventArgs<Projectile>> projectileTriggerPressurePlate =
			new HandlerCollection<TriggerPressurePlateEventArgs<Projectile>>("ProjectileTriggerPressurePlate");

		public HandlerCollection<TriggerPressurePlateEventArgs<Projectile>> ProjectileTriggerPressurePlate
		{
			get { return this.projectileTriggerPressurePlate; }
		}

		internal bool InvokeProjectileTriggerPressurePlate(Projectile projectile, int tileX, int tileY)
		{
			TriggerPressurePlateEventArgs<Projectile> args = new TriggerPressurePlateEventArgs<Projectile>
			{
				Object = projectile,
				TileX = tileX,
				TileY = tileY
			};

			this.ProjectileTriggerPressurePlate.Invoke(args);

			return args.Handled;
		}
		#endregion

		#region ProjectileAIUpdate
		private readonly HandlerCollection<ProjectileAiUpdateEventArgs> projectileAiUpdate =
			new HandlerCollection<ProjectileAiUpdateEventArgs>("ProjectileAIUpdate");

		public HandlerCollection<ProjectileAiUpdateEventArgs> ProjectileAIUpdate
		{
			get { return this.projectileAiUpdate; }
		}

		internal bool InvokeProjectileAIUpdate(Projectile projectile)
		{
			ProjectileAiUpdateEventArgs args = new ProjectileAiUpdateEventArgs
			{
				Projectile = projectile
			};

			this.ProjectileAIUpdate.Invoke(args);

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
			if (Netplay.Clients[who].State != 0)
			{
				return false;
			}

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

		internal bool InvokeServerChat(MessageBuffer buffer, int who, string text)
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

		#region ServerBroadcast
		private readonly HandlerCollection<ServerBroadcastEventArgs> serverBroadcast =
			new HandlerCollection<ServerBroadcastEventArgs>("ServerBroadcast");

		public HandlerCollection<ServerBroadcastEventArgs> ServerBroadcast
		{
			get { return serverBroadcast; }
		}

		internal bool InvokeServerBroadcast(ref string message, ref float r, ref float g, ref float b)
		{
			ServerBroadcastEventArgs args = new ServerBroadcastEventArgs
			{
				Message = message,
				Color = new Color((int)r, (int)g, (int)b)
			};

			ServerBroadcast.Invoke(args);

			message = args.Message;
			r = args.Color.R;
			g = args.Color.G;
			b = args.Color.B;

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

		internal void InvokeServerSocketReset(RemoteClient socket)
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
		#region WorldHalloweenCheck
		private readonly HandlerCollection<HalloweenCheckEventArgs> worldHalloweenCheck =
			new HandlerCollection<HalloweenCheckEventArgs>("WorldHalloweenCheck");

		public HandlerCollection<HalloweenCheckEventArgs> WorldHalloweenCheck
		{
			get { return this.worldHalloweenCheck; }
		}

		internal bool InvokeWorldHalloweenCheck(ref bool halloweenCheck)
		{
			HalloweenCheckEventArgs args = new HalloweenCheckEventArgs
			{
				Halloween = halloweenCheck
			};

			this.worldHalloweenCheck.Invoke(args);

			halloweenCheck = args.Halloween;
			return args.Handled;
		}
		#endregion
		#endregion

		#region Wire Hooks
		#region WireTriggerAnnouncementBox
		private readonly HandlerCollection<TriggerAnnouncementBoxEventArgs> wireTriggerAnnouncementBox =
			new HandlerCollection<TriggerAnnouncementBoxEventArgs>("WireTriggerAnnouncementBox");

		public HandlerCollection<TriggerAnnouncementBoxEventArgs> WireTriggerAnnouncementBox
		{
			get { return this.wireTriggerAnnouncementBox; }
		}

		internal bool InvokeWireTriggerAnnouncementBox(int player, int tileX, int tileY, int signIndex, string text)
		{
			TriggerAnnouncementBoxEventArgs args = new TriggerAnnouncementBoxEventArgs
			{
				Who = player,
				TileX = tileX,
				TileY = tileY,
				Sign = signIndex,
				Text = text
			};

			this.WireTriggerAnnouncementBox.Invoke(args);

			return args.Handled;
		}
		#endregion
		#endregion
	}
}
