using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Terraria;
using Terraria.Social;
using Terraria.Social.Base;
using Terraria.Utilities;

namespace Terraria.IO
{
	public class PlayerFileData : FileData
	{
		private Terraria.Player _player;

		private TimeSpan _playTime = TimeSpan.Zero;

		private Stopwatch _timer = new Stopwatch();

		private bool _isTimerActive;

		public Terraria.Player Player
		{
			get
			{
				return this._player;
			}
			set
			{
				this._player = value;
				if (value != null)
				{
					this.Name = this._player.name;
				}
			}
		}

		public PlayerFileData() : base("Player")
		{
		}

		public PlayerFileData(string path, bool cloudSave) : base("Player", path, cloudSave)
		{
		}

		public static PlayerFileData CreateAndSave(Terraria.Player player)
		{
			PlayerFileData playerFileDatum = new PlayerFileData()
			{
				Metadata = FileMetadata.FromCurrentSettings(FileType.Player),
				Player = player,
				_isCloudSave = (SocialAPI.Cloud == null ? false : SocialAPI.Cloud.EnabledByDefault),
			};
			playerFileDatum._path = Main.GetPlayerPathFromName(player.name, playerFileDatum.IsCloudSave);
			((playerFileDatum.IsCloudSave ? Main.CloudFavoritesData : Main.LocalFavoriteData)).ClearEntry(playerFileDatum);
			Terraria.Player.SavePlayer(playerFileDatum, true);
			return playerFileDatum;
		}

		public TimeSpan GetPlayTime()
		{
			if (!this._timer.IsRunning)
			{
				return this._playTime;
			}
			return this._playTime + this._timer.Elapsed;
		}

		public override void MoveToCloud()
		{
			if (base.IsCloudSave || SocialAPI.Cloud == null)
			{
				return;
			}
			string playerPathFromName = Main.GetPlayerPathFromName(this.Name, true);
			if (FileUtilities.MoveToCloud(base.Path, playerPathFromName))
			{
				string fileName = base.GetFileName(false);
				object[] playerPath = new object[] { Main.PlayerPath, System.IO.Path.DirectorySeparatorChar, fileName, System.IO.Path.DirectorySeparatorChar };
				string str = string.Concat(playerPath);
				if (Directory.Exists(str))
				{
					string[] files = Directory.GetFiles(str);
					for (int i = 0; i < (int)files.Length; i++)
					{
						string[] cloudPlayerPath = new string[] { Main.CloudPlayerPath, "/", fileName, "/", FileUtilities.GetFileName(files[i], true) };
						string str1 = string.Concat(cloudPlayerPath);
						FileUtilities.MoveToCloud(files[i], str1);
					}
				}
				Main.LocalFavoriteData.ClearEntry(this);
				this._isCloudSave = true;
				this._path = playerPathFromName;
				Main.CloudFavoritesData.SaveFavorite(this);
			}
		}

		public override void MoveToLocal()
		{
			if (!base.IsCloudSave || SocialAPI.Cloud == null)
			{
				return;
			}
			string playerPathFromName = Main.GetPlayerPathFromName(this.Name, false);
			if (FileUtilities.MoveToLocal(base.Path, playerPathFromName))
			{
				string fileName = base.GetFileName(false);
				char directorySeparatorChar = System.IO.Path.DirectorySeparatorChar;
				string str = string.Concat(Main.CloudPlayerPath, "/", fileName, "/.+\\.map");
				List<string> files = SocialAPI.Cloud.GetFiles(str);
				for (int i = 0; i < files.Count; i++)
				{
					object[] playerPath = new object[] { Main.PlayerPath, directorySeparatorChar, fileName, directorySeparatorChar, FileUtilities.GetFileName(files[i], true) };
					string str1 = string.Concat(playerPath);
					FileUtilities.MoveToLocal(files[i], str1);
				}
				Main.CloudFavoritesData.ClearEntry(this);
				this._isCloudSave = false;
				this._path = playerPathFromName;
				Main.LocalFavoriteData.SaveFavorite(this);
			}
		}

		public void PausePlayTimer()
		{
			if (this._timer.IsRunning)
			{
				this._timer.Stop();
			}
		}

		public override void SetAsActive()
		{
			Main.ActivePlayerFileData = this;
			Main.player[Main.myPlayer] = this.Player;
		}

		public void SetPlayTime(TimeSpan time)
		{
			this._playTime = time;
		}

		public void StartPlayTimer()
		{
			this._isTimerActive = true;
			if (!this._timer.IsRunning)
			{
				this._timer.Start();
			}
		}

		public void StopPlayTimer()
		{
			this._isTimerActive = false;
			if (this._timer.IsRunning)
			{
				PlayerFileData elapsed = this;
				elapsed._playTime = elapsed._playTime + this._timer.Elapsed;
				this._timer.Reset();
			}
		}

		public void UpdatePlayTimer()
		{
			if (Main.instance.IsActive && !Main.gamePaused && Main.hasFocus && this._isTimerActive)
			{
				this.StartPlayTimer();
				return;
			}
			this.PausePlayTimer();
		}
	}
}