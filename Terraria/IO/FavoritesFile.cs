using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Terraria.Utilities;

namespace Terraria.IO
{
	public class FavoritesFile
	{
		public readonly string Path;

		public readonly bool IsCloudSave;

		private Dictionary<string, Dictionary<string, bool>> _data = new Dictionary<string, Dictionary<string, bool>>();

		public FavoritesFile(string path, bool isCloud)
		{
			this.Path = path;
			this.IsCloudSave = isCloud;
		}

		public void ClearEntry(FileData fileData)
		{
			if (!this._data.ContainsKey(fileData.Type))
			{
				return;
			}
			this._data[fileData.Type].Remove(fileData.GetFileName(true));
			this.Save();
		}

		public bool IsFavorite(FileData fileData)
		{
			bool flag;
			if (!this._data.ContainsKey(fileData.Type))
			{
				return false;
			}
			string fileName = fileData.GetFileName(true);
			if (this._data[fileData.Type].TryGetValue(fileName, out flag))
			{
				return flag;
			}
			return false;
		}

		public void Load()
		{
			if (!FileUtilities.Exists(this.Path, this.IsCloudSave))
			{
				this._data.Clear();
				return;
			}
			string str = Encoding.ASCII.GetString(FileUtilities.ReadAllBytes(this.Path, this.IsCloudSave));
			this._data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, bool>>>(str);
			if (this._data == null)
			{
				this._data = new Dictionary<string, Dictionary<string, bool>>();
			}
		}

		public void Save()
		{
			FileUtilities.WriteAllBytes(this.Path, Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(this._data, Formatting.Indented)), this.IsCloudSave);
		}

		public void SaveFavorite(FileData fileData)
		{
			if (!this._data.ContainsKey(fileData.Type))
			{
				this._data.Add(fileData.Type, new Dictionary<string, bool>());
			}
			this._data[fileData.Type][fileData.GetFileName(true)] = fileData.IsFavorite;
			this.Save();
		}
	}
}