using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading;
using Terraria;

namespace Terraria.Graphics
{
	internal static class TextureManager
	{
		private static ConcurrentDictionary<string, Texture2D> _textures;

		private static ConcurrentQueue<TextureManager.LoadPair> _loadQueue;

		private static Thread _loadThread;

		private readonly static object _loadThreadLock;

		public static Texture2D BlankTexture;

		static TextureManager()
		{
			TextureManager._textures = new ConcurrentDictionary<string, Texture2D>();
			TextureManager._loadQueue = new ConcurrentQueue<TextureManager.LoadPair>();
			TextureManager._loadThreadLock = new object();
		}

		public static void Initialize()
		{
			TextureManager.BlankTexture = new Texture2D(Main.graphics.GraphicsDevice, 4, 4);
			TextureManager._loadThread = new Thread(new ThreadStart(TextureManager.Run));
			TextureManager._loadThread.Start();
		}

		public static Texture2D Load(string name)
		{
			if (TextureManager._textures.ContainsKey(name))
			{
				return TextureManager._textures[name];
			}
			Texture2D blankTexture = TextureManager.BlankTexture;
			TextureManager._textures[name] = blankTexture;
			return blankTexture;
		}

		public static Ref<Texture2D> Retrieve(string name)
		{
			return new Ref<Texture2D>(TextureManager.Load(name));
		}

		public static void Run()
		{
			TextureManager.LoadPair loadPair;
			bool flag = true;
			Main.instance.Exiting += new EventHandler<EventArgs>((object obj, EventArgs args) => {
				flag = false;
				if (Monitor.TryEnter(TextureManager._loadThreadLock))
				{
					Monitor.Pulse(TextureManager._loadThreadLock);
					Monitor.Exit(TextureManager._loadThreadLock);
				}
			});
			Monitor.Enter(TextureManager._loadThreadLock);
			while (flag)
			{
				if (TextureManager._loadQueue.Count == 0)
				{
					Monitor.Wait(TextureManager._loadThreadLock);
				}
				else
				{
					if (!TextureManager._loadQueue.TryDequeue(out loadPair))
					{
						continue;
					}
					loadPair.TextureRef.Value = TextureManager.Load(loadPair.Path);
				}
			}
			Monitor.Exit(TextureManager._loadThreadLock);
		}

		private struct LoadPair
		{
			public string Path;

			public Ref<Texture2D> TextureRef;

			public LoadPair(string path, Ref<Texture2D> textureRef)
			{
				this.Path = path;
				this.TextureRef = textureRef;
			}
		}
	}
}