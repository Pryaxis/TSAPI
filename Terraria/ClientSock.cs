using System;
using System.Net.Sockets;

namespace Terraria
{
    public class ClientSock
    {
        public bool active;
        public bool locked;
        public NetworkStream networkStream;
        public byte[] readBuffer;
        public int state;
        public int statusCount;
        public int statusMax;
        public string statusText;
        public TcpClient tcpClient = new TcpClient();
        public int timeOut;
        public byte[] writeBuffer;

        public void ClientWriteCallBack(IAsyncResult ar)
        {
            NetMessage.buffer[256].spamCount--;
        }

        public void ClientReadCallBack(IAsyncResult ar)
        {
            if (!Netplay.disconnect)
            {
                int num = networkStream.EndRead(ar);
                if (num == 0)
                {
                    Netplay.disconnect = true;
                    Main.statusText = "Lost connection";
                }
                else
                {
                    if (Main.ignoreErrors)
                    {
                        try
                        {
                            NetMessage.RecieveBytes(readBuffer, num, 256);
                            goto IL_59;
                        }
                        catch
                        {
                            goto IL_59;
                        }
                    }
                    NetMessage.RecieveBytes(readBuffer, num, 256);
                }
            }
            IL_59:
            locked = false;
        }
    }
}