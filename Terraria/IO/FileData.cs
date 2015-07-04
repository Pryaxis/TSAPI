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

		protected bool _isFavorite;

		public bool IsCloudSave
		{
			get
			{
				return this._isCloudSave;
			}
		}

		public bool IsFavorite
		{
			get
			{
				return this._isFavorite;
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
			this._isFavorite = ((isCloud ? Main.CloudFavoritesData : Main.LocalFavoriteData)).IsFavorite(this);
		}

		public string GetFileName(bool includeExtension = true)
		{
			return FileUtilities.GetFileName(this.Path, includeExtension);
		}

		public abstract void MoveToCloud();

		public abstract void MoveToLocal();

		public abstract void SetAsActive();

		public void SetFavorite(bool favorite, bool saveChanges = true)
		{
			this._isFavorite = favorite;
			if (saveChanges)
			{
				((this.IsCloudSave ? Main.CloudFavoritesData : Main.LocalFavoriteData)).SaveFavorite(this);
			}
		}

		public void ToggleFavorite()
		{
			this.SetFavorite(!this.IsFavorite, true);
		}
	}
}