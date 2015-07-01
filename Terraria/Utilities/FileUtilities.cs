using System;
using System.IO;
using System.Text.RegularExpressions;
using Terraria.Social;
using Terraria.Social.Base;

namespace Terraria.Utilities
{
	public static class FileUtilities
	{
		private static Regex FileNameRegex;

		static FileUtilities()
		{
			FileUtilities.FileNameRegex = new Regex("^.+[\\\\\\/](?<fileName>\\w+)(.(?<extension>\\w+))?$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
		}

		public static void Copy(string source, string destination, bool cloud, bool overwrite = true)
		{
			if (!cloud)
			{
				File.Copy(source, destination, overwrite);
				return;
			}
			if (SocialAPI.Cloud == null || !overwrite && SocialAPI.Cloud.HasFile(destination))
			{
				return;
			}
			SocialAPI.Cloud.Write(destination, SocialAPI.Cloud.Read(source));
		}

		public static void Delete(string path, bool cloud)
		{
			if (!cloud || SocialAPI.Cloud == null)
			{
				FileOperationAPIWrapper.MoveToRecycleBin(path);
				return;
			}
			SocialAPI.Cloud.Delete(path);
		}

		public static bool Exists(string path, bool cloud)
		{
			if (!cloud || SocialAPI.Cloud == null)
			{
				return File.Exists(path);
			}
			return SocialAPI.Cloud.HasFile(path);
		}

		public static string GetFileName(string path, bool includeExtension = true)
		{
			Match match = FileUtilities.FileNameRegex.Match(path);
			if (match == null || match.Groups["fileName"] == null)
			{
				return "";
			}
			includeExtension = includeExtension & match.Groups["extension"] != null;
			return string.Concat(match.Groups["fileName"].Value, (includeExtension ? string.Concat(".", match.Groups["extension"].Value) : ""));
		}

		public static string GetFullPath(string path, bool cloud)
		{
			if (cloud)
			{
				return path;
			}
			return Path.GetFullPath(path);
		}

		public static void Move(string source, string destination, bool cloud, bool overwrite = true)
		{
			FileUtilities.Copy(source, destination, cloud, overwrite);
			FileUtilities.Delete(source, cloud);
		}

		public static bool MoveToCloud(string localPath, string cloudPath)
		{
			if (SocialAPI.Cloud == null)
			{
				return false;
			}
			FileUtilities.WriteAllBytes(cloudPath, FileUtilities.ReadAllBytes(localPath, false), true);
			FileUtilities.Delete(localPath, false);
			return true;
		}

		public static bool MoveToLocal(string cloudPath, string localPath)
		{
			if (SocialAPI.Cloud == null)
			{
				return false;
			}
			FileUtilities.WriteAllBytes(localPath, FileUtilities.ReadAllBytes(cloudPath, true), false);
			FileUtilities.Delete(cloudPath, true);
			return true;
		}

		public static byte[] ReadAllBytes(string path, bool cloud)
		{
			if (!cloud || SocialAPI.Cloud == null)
			{
				return File.ReadAllBytes(path);
			}
			return SocialAPI.Cloud.Read(path);
		}

		public static void Write(string path, byte[] data, int length, bool cloud)
		{
			if (cloud && SocialAPI.Cloud != null)
			{
				SocialAPI.Cloud.Write(path, data, length);
				return;
			}
			using (FileStream fileStream = File.Open(path, FileMode.Create))
			{
				fileStream.Write(data, 0, length);
			}
		}

		public static void WriteAllBytes(string path, byte[] data, bool cloud)
		{
			FileUtilities.Write(path, data, (int)data.Length, cloud);
		}
	}
}