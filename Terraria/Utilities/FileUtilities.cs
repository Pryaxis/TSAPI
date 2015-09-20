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

		public static void Delete(string path)
		{
			FileOperationAPIWrapper.MoveToRecycleBin(path);
		}

		public static bool Exists(string path)
		{
			return File.Exists(path);
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

		public static string GetFullPath(string path)
		{
			return Path.GetFullPath(path);
		}

		public static void Move(string source, string destination, bool overwrite = true)
		{
			FileUtilities.Copy(source, destination, overwrite);
			FileUtilities.Delete(source);
		}

		public static byte[] ReadAllBytes(string path)
		{
			return File.ReadAllBytes(path);
		}

		public static void Write(string path, byte[] data, int length)
		{
			using (FileStream fileStream = File.Open(path, FileMode.Create))
			{
				fileStream.Write(data, 0, length);
			}
		}

		public static void WriteAllBytes(string path, byte[] data)
		{
			FileUtilities.Write(path, data, (int)data.Length);
		}
	}
}