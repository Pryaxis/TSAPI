using Microsoft.Xna.Framework;
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
			try
			{
				Console.WriteLine("TerrariaAPI Version: {0} (Protocol {1} ({2}), OTAPI {3})",
					ServerApi.ApiVersion,
					Main.versionNumber2,
					Main.curRelease,
					typeof(OTAPI.Hooks).Assembly.GetName().Version
				);
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

		public void AttachOTAPIHooks(string[] args)
		{
			if (args.Any(x => x == "-heaptile"))
			{
				ServerApi.LogWriter.ServerWriteLine($"Using {nameof(HeapTile)} for tile implementation", TraceLevel.Info);
				OTAPI.Hooks.Tile.CreateCollection = () =>
				{
					return new TileProvider();
				};
			}

			Hooking.GameHooks.AttachTo(this);
			Hooking.ItemHooks.AttachTo(this);
			Hooking.NetHooks.AttachTo(this);
			Hooking.NpcHooks.AttachTo(this);
			Hooking.ProjectileHooks.AttachTo(this);
			Hooking.ServerHooks.AttachTo(this);
			Hooking.WiringHooks.AttachTo(this);
			Hooking.WorldHooks.AttachTo(this);
		}

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
			ref int msgType, ref int remoteClient, ref int ignoreClient, ref Terraria.Localization.NetworkText text,
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
				// A critical server crash/slow-down bug was exploited in which a 0-length
				// packet is sent, causing all NetGetData handlers to throw exceptions.
				// Because a packet's header is 2 bytes of length + 1 byte of packet type,
				// all packets must contain at least 3 bytes.
				// Ideally this check should occur in an OTAPI modification.
				if (length < 1)
				{
					RemoteClient currentClient = Netplay.Clients[buffer.whoAmI];
					Netplay.Clients[buffer.whoAmI].PendingTermination = true;
					return true;
				}

				// A critical server crash/corruption bug was reported by @bartico6 on GitHub.
				// If a packet length comes in at extreme values, the server can enter infinite loops, deadlock, and corrupt the world.
				// As a result, we take the following action: disconnect the player and log the attempt as soon as we can.
				// The length 1000 was chosen as an arbitrarily large number for all packets. It may need to be tuned later.
				if (length > 1000)
				{
					RemoteClient currentClient = Netplay.Clients[buffer.whoAmI];
					Netplay.Clients[buffer.whoAmI].PendingTermination = true;
					return true;
				}
				
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
					case PacketTypes.LoadNetModule:
						using (var stream = new MemoryStream(buffer.readBuffer))
						{
							stream.Position = index;
							using (var reader = new BinaryReader(stream))
							{
								ushort moduleId = reader.ReadUInt16();
								//LoadNetModule is now used for sending chat text.
								//Read the module ID to determine if this is in fact the text module
								if (moduleId == Terraria.Net.NetManager.Instance.GetId<Terraria.GameContent.NetModules.NetTextModule>())
								{
									//Then deserialize the message from the reader
									Terraria.Chat.ChatMessage msg = Terraria.Chat.ChatMessage.Deserialize(reader);

									if (InvokeServerChat(buffer, buffer.whoAmI, @msg.Text, msg.CommandId))
									{
										return true;
									}
								}
							}
						}

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

		#region Killed
		private readonly HandlerCollection<NpcKilledEventArgs> npcKilledInt =
			new HandlerCollection<NpcKilledEventArgs>("NpcKilledInt");

		public HandlerCollection<NpcKilledEventArgs> NpcKilled => npcKilledInt;

		internal void InvokeNpcKilled(NPC npc)
		{
			this.npcKilledInt.Invoke(new NpcKilledEventArgs() { npc = npc });
		}
		#endregion

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

		internal bool InvokeServerChat(MessageBuffer buffer, int who, string text, Terraria.Chat.ChatCommandId commandId)
		{
			ServerChatEventArgs args = new ServerChatEventArgs
			{
				Buffer = buffer,
				Who = who,
				Text = text,
				CommandId = commandId
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

		internal bool InvokeServerBroadcast(ref Terraria.Localization.NetworkText message, ref float r, ref float g, ref float b)
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

		#region WorldGrassSpread
		private readonly HandlerCollection<GrassSpreadEventArgs> worldGrassSpread =
			new HandlerCollection<GrassSpreadEventArgs>("WorldGrassSpread");

		public HandlerCollection<GrassSpreadEventArgs> WorldGrassSpread
		{
			get { return this.worldGrassSpread; }
		}

		internal bool InvokeWorldGrassSpread(int tileX, int tileY, int dirt, int grass, bool repeat, byte color)
		{
			GrassSpreadEventArgs args = new GrassSpreadEventArgs
			{
				TileX = tileX,
				TileY = tileY,
				Dirt = dirt,
				Grass = grass,
				Repeat = repeat,
				Color = color
			};

			this.WorldGrassSpread.Invoke(args);
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
