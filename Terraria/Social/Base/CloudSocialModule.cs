using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.IO;
using Terraria.Social;

namespace Terraria.Social.Base
{
	public abstract class CloudSocialModule : ISocialModule
	{
		public bool EnabledByDefault;

		protected CloudSocialModule()
		{
		}

		public abstract bool Delete(string path);

		public abstract List<string> GetFiles(string matchPattern = ".+");

		public abstract int GetFileSize(string path);

		public abstract bool HasFile(string path);

		public virtual void Initialize()
		{
			Main.Configuration.OnLoad += new Action<Preferences>((Preferences preferences) => this.EnabledByDefault = preferences.Get<bool>("CloudSavingDefault", false));
			Main.Configuration.OnSave += new Action<Preferences>((Preferences preferences) => preferences.Put("CloudSavingDefault", this.EnabledByDefault));
		}

		public abstract void Read(string path, byte[] buffer, int length);

		public byte[] Read(string path)
		{
			byte[] numArray = new byte[this.GetFileSize(path)];
			this.Read(path, numArray, (int)numArray.Length);
			return numArray;
		}

		public void Read(string path, byte[] buffer)
		{
			this.Read(path, buffer, (int)buffer.Length);
		}

		public abstract void Shutdown();

		public abstract bool Write(string path, byte[] data, int length);

		public bool Write(string path, byte[] data)
		{
			return this.Write(path, data, (int)data.Length);
		}
	}
}