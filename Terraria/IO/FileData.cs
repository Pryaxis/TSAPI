using System;
using Terraria;
using Terraria.Utilities;

namespace Terraria.IO
{
	public abstract class FileData
	{
		protected string _path;

		public FileMetadata Metadata;

		public string Name;

		public readonly string Type;


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

		protected FileData(string type, string path)
		{
			this.Type = type;
			this._path = path;
		}

		public string GetFileName(bool includeExtension = true)
		{
			return FileUtilities.GetFileName(this.Path, includeExtension);
		}

		public abstract void SetAsActive();
	}
}