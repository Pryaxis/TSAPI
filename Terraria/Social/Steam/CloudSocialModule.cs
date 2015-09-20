using Steamworks;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Terraria.Social.Base;

namespace Terraria.Social.Steam
{
	public class CloudSocialModule : Terraria.Social.Base.CloudSocialModule
	{
		public CloudSocialModule()
		{
		}

		public override bool Delete(string path)
		{
			return SteamRemoteStorage.FileDelete(path);
		}

		public override List<string> GetFiles(string matchPattern)
		{
			int num;
			matchPattern = string.Concat("^", matchPattern, "$");
			List<string> strs = new List<string>();
			int fileCount = SteamRemoteStorage.GetFileCount();
			Regex regex = new Regex(matchPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
			for (int i = 0; i < fileCount; i++)
			{
				string fileNameAndSize = SteamRemoteStorage.GetFileNameAndSize(i, out num);
				if (regex.Match(fileNameAndSize).Length > 0)
				{
					strs.Add(fileNameAndSize);
				}
			}
			return strs;
		}

		public override int GetFileSize(string path)
		{
			return SteamRemoteStorage.GetFileSize(path);
		}

		public override bool HasFile(string path)
		{
			return SteamRemoteStorage.FileExists(path);
		}

		public override void Initialize()
		{
			base.Initialize();
		}

		public override void Read(string path, byte[] buffer, int size)
		{
			SteamRemoteStorage.FileRead(path, buffer, size);
		}

		public override void Shutdown()
		{
		}

		public override bool Write(string path, byte[] data, int length)
		{
			return SteamRemoteStorage.FileWrite(path, data, length);
		}
	}
}