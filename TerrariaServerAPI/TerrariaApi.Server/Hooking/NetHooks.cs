using OTAPI;
using System;
using Terraria;
using Terraria.Net;

namespace TerrariaApi.Server.Hooking;

internal class NetHooks
{
	private static HookManager _hookManager;

	public static readonly object syncRoot = new();

	/// <summary>
	/// Attaches any of the OTAPI Net hooks to the existing <see cref="HookManager"/> implementation
	/// </summary>
	/// <param name="hookManager">HookManager instance which will receive the events</param>
	public static void AttachTo(HookManager hookManager)
	{
		_hookManager = hookManager;

		HookEvents.Terraria.NetMessage.greetPlayer += OnGreetPlayer;
		HookEvents.Terraria.Netplay.OnConnectionAccepted += OnConnectionAccepted;
		HookEvents.Terraria.Chat.ChatHelper.BroadcastChatMessage += OnBroadcastChatMessage;
		HookEvents.Terraria.Net.NetManager.SendData += OnSendNetData;
		HookEvents.Terraria.Netplay.UpdateConnectedClients += OnUpdateConnectedClients;

		Hooks.NetMessage.SendData += OnSendData;
		Hooks.NetMessage.SendBytes += OnSendBytes;
		Hooks.MessageBuffer.GetData += OnReceiveData;
		Hooks.MessageBuffer.NameCollision += OnNameCollision;
	}

	static void OnUpdateConnectedClients(object? sender, HookEvents.Terraria.Netplay.UpdateConnectedClientsEventArgs args)
	{
		if (!args.ContinueExecution) return;
		args.ContinueExecution = false;
		args.OriginalMethod();
		if (ServerApi.ForceUpdate)
		{
			Terraria.Netplay.HasClients = true;
		}
	}

	static void OnBroadcastChatMessage(object? sender, HookEvents.Terraria.Chat.ChatHelper.BroadcastChatMessageEventArgs args)
	{
		if (!args.ContinueExecution) return;
		float r = args.color.R, g = args.color.G, b = args.color.B;

		var cancel = _hookManager.InvokeServerBroadcast(ref args.text, ref r, ref g, ref b);

		if (!cancel)
		{
			args.color = new Microsoft.Xna.Framework.Color(r, g, b);
		}

		args.ContinueExecution = !cancel;
	}

	static void OnSendData(object sender, Hooks.NetMessage.SendDataEventArgs e)
	{
		if (e.Result == HookResult.Cancel)
		{
			return;
		}
		if (e.Event == HookEvent.Before)
		{
			var msgType = e.MsgType;
			var remoteClient = e.RemoteClient;
			var ignoreClient = e.IgnoreClient;
			var text = e.Text;
			var number = e.Number;
			var number2 = e.Number2;
			var number3 = e.Number3;
			var number4 = e.Number4;
			var number5 = e.Number5;
			var number6 = e.Number6;
			var number7 = e.Number7;
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
				e.Result = HookResult.Cancel;
			}

			e.MsgType = msgType;
			e.RemoteClient = remoteClient;
			e.IgnoreClient = ignoreClient;
			e.Text = text;
			e.Number = number;
			e.Number2 = number2;
			e.Number3 = number3;
			e.Number4 = number4;
			e.Number5 = number5;
			e.Number6 = number6;
			e.Number7 = number7;
		}
	}

	static void OnSendNetData(NetManager netmanager, HookEvents.Terraria.Net.NetManager.SendDataEventArgs args)
	{
		if (!args.ContinueExecution) return;
		if (_hookManager.InvokeNetSendNetData
		(
			ref netmanager,
			ref args.socket,
			ref args.packet
		))
		{
			args.ContinueExecution = false;
		}
	}

	static void OnReceiveData(object sender, Hooks.MessageBuffer.GetDataEventArgs e)
	{
		if (e.Result == HookResult.Cancel)
		{
			return;
		}
		if (!Enum.IsDefined(typeof(PacketTypes), (int)e.PacketId))
		{
			e.Result = HookResult.Cancel;
		}
		else
		{
			var msgId = e.PacketId;
			var readOffset = e.ReadOffset;
			var length = e.Length;

			if (_hookManager.InvokeNetGetData(ref msgId, e.Instance, ref readOffset, ref length))
			{
				e.Result = HookResult.Cancel;
			}

			e.PacketId = msgId;
			e.ReadOffset = readOffset;
			e.Length = length;
		}
	}

	static void OnGreetPlayer(object? sender, HookEvents.Terraria.NetMessage.greetPlayerEventArgs args)
	{
		if (!args.ContinueExecution) return;
		if (_hookManager.InvokeNetGreetPlayer(args.plr))
			args.ContinueExecution = false;
	}

	static void OnSendBytes(object sender, Hooks.NetMessage.SendBytesEventArgs e)
	{
		if (e.Result == HookResult.Cancel)
		{
			return;
		}
		if (_hookManager.InvokeNetSendBytes(Netplay.Clients[e.RemoteClient], e.Data, e.Offset, e.Size))
		{
			e.Result = HookResult.Cancel;
		}
	}

	static void OnNameCollision(object sender, Hooks.MessageBuffer.NameCollisionEventArgs e)
	{
		if (e.Result == HookResult.Cancel)
		{
			return;
		}
		if (_hookManager.InvokeNetNameCollision(e.Player.whoAmI, e.Player.name))
		{
			e.Result = HookResult.Cancel;
		}
	}

	static void OnConnectionAccepted(object? sender, HookEvents.Terraria.Netplay.OnConnectionAcceptedEventArgs args)
	{
		if (!args.ContinueExecution) return;
		args.ContinueExecution = false;
		int slot = FindNextOpenClientSlot();
		if (slot != -1)
		{
			Netplay.Clients[slot].Reset();
			Netplay.Clients[slot].Socket = args.client;
		}
		if (FindNextOpenClientSlot() == -1)
		{
			Netplay.StopListening();
		}
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
