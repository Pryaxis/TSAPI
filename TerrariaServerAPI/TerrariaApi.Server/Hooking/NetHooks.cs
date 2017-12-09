using OTAPI;
using System;
using Terraria;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace TerrariaApi.Server.Hooking
{
	internal class NetHooks
	{
		private static HookManager _hookManager;

		public static readonly object syncRoot = new object();

		/// <summary>
		/// Attaches any of the OTAPI Net hooks to the existing <see cref="HookManager"/> implementation
		/// </summary>
		/// <param name="hookManager">HookManager instance which will receive the events</param>
		public static void AttachTo(HookManager hookManager)
		{
			_hookManager = hookManager;

			Hooks.Net.SendData = OnSendData;
			Hooks.Net.ReceiveData = OnReceiveData;
			Hooks.Player.PreGreet = OnPreGreet;
			Hooks.Net.SendBytes = OnSendBytes;
			Hooks.Net.Socket.Accepted = OnAccepted;
			Hooks.Net.BeforeBroadcastChatMessage = OnBroadcastChatMessage;
			Hooks.Player.NameCollision = OnNameCollision;
		}

		private static HookResult OnBroadcastChatMessage(NetworkText text, ref Color color, ref int ignorePlayer)
		{
			float r = color.R, g = color.G, b = color.B;

			var cancel = _hookManager.InvokeServerBroadcast(ref text, ref r, ref g, ref b);

			color.R = (byte)r;
			color.G = (byte)g;
			color.B = (byte)b;

			return cancel ? HookResult.Cancel : HookResult.Continue;
		}

		static HookResult OnSendData(
				ref int bufferId,
				ref int msgType,
				ref int remoteClient,
				ref int ignoreClient,
				ref Terraria.Localization.NetworkText text,
				ref int number,
				ref float number2,
				ref float number3,
				ref float number4,
				ref int number5,
				ref int number6,
				ref int number7
			)
		{
			if (_hookManager.InvokeNetSendData
			(
				ref msgType,
				ref remoteClient,
				ref ignoreClient,
				ref text,
				ref number,
				ref number2,
				ref number3,
				ref number4,
				ref number5,
				ref number6,
				ref number7
			))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}

		static HookResult OnReceiveData(
			MessageBuffer buffer,
			ref byte packetId,
			ref int readOffset,
			ref int start,
			ref int length
		)
		{
			if (!Enum.IsDefined(typeof(PacketTypes), (int)packetId))
			{
				return HookResult.Cancel;
			}
			if (_hookManager.InvokeNetGetData(ref packetId, buffer, ref readOffset, ref length))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}

		static HookResult OnPreGreet(ref int playerId)
		{
			if (_hookManager.InvokeNetGreetPlayer(playerId))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}

		static HookResult OnSendBytes(
			ref int remoteClient,
			ref byte[] data,
			ref int offset,
			ref int size,
			ref Terraria.Net.Sockets.SocketSendCallback callback,
			ref object state
		)
		{
			if (_hookManager.InvokeNetSendBytes(Netplay.Clients[remoteClient], data, offset, size))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}

		static HookResult OnNameCollision(Player player)
		{
			if (_hookManager.InvokeNetNameCollision(player.whoAmI, player.name))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}

		static HookResult OnAccepted(Terraria.Net.Sockets.ISocket client)
		{
			int slot = FindNextOpenClientSlot();
			if (slot != -1)
			{
				Netplay.Clients[slot].Reset();
				Netplay.Clients[slot].Socket = client;
			}
			if (FindNextOpenClientSlot() == -1)
			{
				Netplay.StopListening();
			}
			return HookResult.Cancel;
		}

		static int FindNextOpenClientSlot()
		{
			lock (syncRoot)
			{
				for (int i = 0; i < Main.maxNetPlayers; i++)
				{
					if (!Netplay.Clients[i].IsConnected())
					{
						return i;
					}
				}
			}
			return -1;
		}
	}
}
