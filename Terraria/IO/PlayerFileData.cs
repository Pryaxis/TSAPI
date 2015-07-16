
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
			};
			playerFileDatum._path = Main.GetPlayerPathFromName(player.name, false);
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

		public void PausePlayTimer()
		{
		}

		public override void SetAsActive()
		{
		}

		public void SetPlayTime(TimeSpan time)
		{
		}

		public void StartPlayTimer()
		{
		}

		public void StopPlayTimer()
		{
		}

		public void UpdatePlayTimer()
		{
		}
	}
}