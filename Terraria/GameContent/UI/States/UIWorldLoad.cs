using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.World.Generation;

namespace Terraria.GameContent.UI.States
{
	internal class UIWorldLoad : UIState
	{
		private UIGenProgressBar _progressBar = new UIGenProgressBar();

		private UIHeader _progressMessage = new UIHeader();

		private GenerationProgress _progress;

		public UIWorldLoad(GenerationProgress progress)
		{
			this._progressBar.Top.Pixels = 370f;
			this._progressBar.HAlign = 0.5f;
			this._progressBar.VAlign = 0f;
			this._progressBar.Recalculate();
			this._progressMessage.CopyStyle(this._progressBar);
			this._progressMessage.Top.Pixels = this._progressMessage.Top.Pixels - 70f;
			this._progressMessage.Recalculate();
			this._progress = progress;
			base.Append(this._progressBar);
			base.Append(this._progressMessage);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			this._progressBar.SetProgress(this._progress.TotalProgress, this._progress.Value);
			this._progressMessage.Text = this._progress.Message;
		}

		public string GetStatusText()
		{
			return string.Format(string.Concat("{0:0.0%} - ", this._progress.Message, " - {1:0.0%}"), this._progress.TotalProgress, this._progress.Value);
		}
	}
}