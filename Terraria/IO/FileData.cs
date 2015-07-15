using System;
using Terraria;
using Terraria.Utilities;

namespace Terraria.IO
{
	public abstract class FileData
	{
		protected string _path;

		protected bool _isCloudSave;

		public FileMetadata Metadata;

		public string Name;

		public readonly string Type;

		public bool IsCloudSave
		{
			get
			{
				return this._isCloudSave;
			}
		}

		public string Path
		{
			get
			{
				return this._path;
			}
			set
			{
				this._path = value;
			}
		}

		protected FileData(string type)
		{
			this.Type = type;
		}

		protected FileData(string type, string path, bool isCloud)
		{
			this.Type = type;
			this._path = path;
			this._isCloudSave = isCloud;
		}

		public string GetFileName(bool includeExtension = true)
		{
			return FileUtilities.GetFileName(this.Path, includeExtension);
		}

		public abstract void MoveToCloud();

		public abstract void MoveToLocal();

		public abstract void SetAsActive();
	}
}