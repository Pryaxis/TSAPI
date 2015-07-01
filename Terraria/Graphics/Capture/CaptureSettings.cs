using Microsoft.Xna.Framework;
using System;

namespace Terraria.Graphics.Capture
{
	public class CaptureSettings
	{
		public Rectangle Area;

		public bool UseScaling = true;

		public string OutputName;

		public bool CaptureEntities = true;

		public CaptureBiome Biome = CaptureBiome.Biomes[0];

		public bool CaptureBackground;

		public CaptureSettings()
		{
			DateTime localTime = DateTime.Now.ToLocalTime();
			string[] str = new string[] { "Capture ", localTime.Year.ToString("D4"), "-", localTime.Month.ToString("D2"), "-", localTime.Day.ToString("D2"), " ", localTime.Hour.ToString("D2"), "_", localTime.Minute.ToString("D2"), "_", localTime.Second.ToString("D2") };
			this.OutputName = string.Concat(str);
		}
	}
}