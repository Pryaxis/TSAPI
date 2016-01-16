
using System;
using System.Collections.Generic;
using Terraria.Net.Sockets;
using TerrariaApi.Server;

namespace Terraria
{
	public class RemoteClient
	{
		public ISocket Socket = new TcpSocket();

		public int Id;

		public string Name = "Anonymous";

		public string ClientUUID = "";

		public bool IsActive;

		public bool PendingTermination;

		public bool IsAnnouncementCompleted;

		public bool IsReading;

		public int State;

		public int TimeOutTimer;

		public string StatusText = "";

		public string StatusText2;

		public int StatusCount;

		public int StatusMax;

		public bool[,] TileSections = new bool[Main.maxTilesX / 200 + 1, Main.maxTilesY / 150 + 1];

		public byte[] ReadBuffer;

		public float SpamProjectile;

		public float SpamAddBlock;

		public float SpamDeleteBlock;

		public float SpamWater;

		public float SpamProjectileMax = 100f;

		public float SpamAddBlockMax = 100f;

		public float SpamDeleteBlockMax = 500f;

		public float SpamWaterMax = 50f;

		public RemoteClient()
		{
		}

		public static void CheckSection(int playerIndex, Vector2 position, int fluff = 1)
		{
			int num = playerIndex;
			int sectionX = Netplay.GetSectionX((int)(position.X / 16f));
			int sectionY = Netplay.GetSectionY((int)(position.Y / 16f));
			int num1 = 0;
			for (int i = sectionX - fluff; i < sectionX + fluff + 1; i++)
			{
				for (int j = sectionY - fluff; j < sectionY + fluff + 1; j++)
				{
					if (i >= 0 && i < Main.maxSectionsX && j >= 0 && j < Main.maxSectionsY && !Netplay.Clients[num].TileSections[i, j])
					{
						num1++;
					}
				}
			}
			if (num1 > 0)
			{
				int num2 = num1;
				Netplay.Clients[num].StatusText2 = "is receiving tile data";
				RemoteClient clients = Netplay.Clients[num];
				clients.StatusMax = clients.StatusMax + num2;

				NetMessage.SendData(9, num, -1, Lang.inter[44], num2, 0f, 0f, 0f, 0, 0, 0);

				for (int k = sectionX - fluff; k < sectionX + fluff + 1; k++)
				{
					for (int l = sectionY - fluff; l < sectionY + fluff + 1; l++)
					{
						if (k >= 0 && k < Main.maxSectionsX && l >= 0 && l < Main.maxSectionsY && !Netplay.Clients[num].TileSections[k, l])
						{
							NetMessage.SendSection(num, k, l, false);
							NetMessage.SendData(11, num, -1, "", k, (float)l, (float)k, (float)l, 0, 0, 0);
						}
					}
				}
			}
		}

		public void Reset()
		{
			ServerApi.Hooks.InvokeServerSocketReset(this);
			this.ResetSections();
			if (this.Id < 255)
			{
				Main.player[this.Id] = new Player();
			}
			this.TimeOutTimer = 0;
			this.StatusCount = 0;
			this.StatusMax = 0;
			this.StatusText2 = "";
			this.StatusText = "";
			this.ClientUUID = "";
			this.State = 0;
			this.IsReading = false;
			this.PendingTermination = false;
			this.SpamClear();
			this.IsActive = false;
			NetMessage.buffer[this.Id].Reset();
			this.Socket.Close();
		}

		public void ResetSections()
		{
			for (int i = 0; i < Main.maxSectionsX; i++)
			{
				for (int j = 0; j < Main.maxSectionsY; j++)
				{
					this.TileSections[i, j] = false;
				}
			}
		}

		public bool SectionRange(int size, int firstX, int firstY)
		{
			for (int i = 0; i < 4; i++)
			{
				int num = firstX;
				int num1 = firstY;
				if (i == 1)
				{
					num = num + size;
				}
				if (i == 2)
				{
					num1 = num1 + size;
				}
				if (i == 3)
				{
					num = num + size;
					num1 = num1 + size;
				}
				int sectionX = Netplay.GetSectionX(num);
				int sectionY = Netplay.GetSectionY(num1);
				if (this.TileSections[sectionX, sectionY])
				{
					return true;
				}
			}
			return false;
		}

		public void ServerReadCallBack(object state, int length)
		{
			if (!Netplay.disconnect)
			{
				int num = length;
				if (num == 0)
				{
					this.PendingTermination = true;
				}
				else if (!Main.ignoreErrors)
				{
					NetMessage.RecieveBytes(this.ReadBuffer, num, this.Id);
				}
				else
				{
					try
					{
						NetMessage.RecieveBytes(this.ReadBuffer, num, this.Id);
					}
					catch (Exception ex)
					{
#if DEBUG
						Console.WriteLine(ex);
						System.Diagnostics.Debugger.Break();

#endif
					}
				}
			}
			this.IsReading = false;
		}

		public void ServerWriteCallBack(object state)
		{
			MessageBuffer messageBuffer = NetMessage.buffer[this.Id];
			messageBuffer.spamCount = messageBuffer.spamCount - 1;
			if (this.StatusMax > 0)
			{
				RemoteClient statusCount = this;
				statusCount.StatusCount = statusCount.StatusCount + 1;
			}
		}

		public void SpamClear()
		{
			this.SpamProjectile = 0f;
			this.SpamAddBlock = 0f;
			this.SpamDeleteBlock = 0f;
			this.SpamWater = 0f;
		}

		public void SpamUpdate()
		{
			if (!Netplay.spamCheck)
			{
				this.SpamProjectile = 0f;
				this.SpamDeleteBlock = 0f;
				this.SpamAddBlock = 0f;
				this.SpamWater = 0f;
				return;
			}
			if (this.SpamProjectile > this.SpamProjectileMax)
			{
				NetMessage.BootPlayer(this.Id, "Cheating attempt detected: Projectile spam");
			}
			if (this.SpamAddBlock > this.SpamAddBlockMax)
			{
				NetMessage.BootPlayer(this.Id, "Cheating attempt detected: Add tile spam");
			}
			if (this.SpamDeleteBlock > this.SpamDeleteBlockMax)
			{
				NetMessage.BootPlayer(this.Id, "Cheating attempt detected: Remove tile spam");
			}
			if (this.SpamWater > this.SpamWaterMax)
			{
				NetMessage.BootPlayer(this.Id, "Cheating attempt detected: Liquid spam");
			}
			SpamProjectile -= 0.4f;
			if (this.SpamProjectile < 0f)
			{
				this.SpamProjectile = 0f;
			}
			SpamAddBlock -= 0.3f;
			if (this.SpamAddBlock < 0f)
			{
				this.SpamAddBlock = 0f;
			}
			SpamDeleteBlock -= 5f;
			if (this.SpamDeleteBlock < 0f)
			{
				this.SpamDeleteBlock = 0f;
			}
			SpamWater -= 0.2f;
			if (this.SpamWater < 0f)
			{
				this.SpamWater = 0f;
			}
		}
	}
}