using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Utilities;

namespace Terraria.GameContent.Events
{
	public class Sandstorm
	{
		private static void ChangeSeverityIntentions()
		{
			if (Sandstorm.Happening)
			{
				Sandstorm.IntendedSeverity = 0.4f + Main.rand.NextFloat();
			}
			else if (Main.rand.Next(3) == 0)
			{
				Sandstorm.IntendedSeverity = 0f;
			}
			else
			{
				Sandstorm.IntendedSeverity = Main.rand.NextFloat() * 0.3f;
			}
			NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
		}

		public static void DrawGrains()
		{
		}

		public static void EmitDust()
		{

		}

		public static void HandleEffectAndSky(bool toState)
		{

		}

		public static void StartSandstorm()
		{
			Sandstorm.Happening = true;
			Sandstorm.TimeLeft = (int)(3600f * (8f + Main.rand.NextFloat() * 16f));
			Sandstorm.ChangeSeverityIntentions();
		}

		public static void StopSandstorm()
		{
			Sandstorm.Happening = false;
			Sandstorm.TimeLeft = 0;
			Sandstorm.ChangeSeverityIntentions();
		}

		private static void UpdateSeverity()
		{
			int num = Math.Sign(Sandstorm.IntendedSeverity - Sandstorm.Severity);
			Sandstorm.Severity = MathHelper.Clamp(Sandstorm.Severity + 0.003f * (float)num, 0f, 1f);
			int num2 = Math.Sign(Sandstorm.IntendedSeverity - Sandstorm.Severity);
			if (num != num2)
			{
				Sandstorm.Severity = Sandstorm.IntendedSeverity;
			}
		}

		public static void UpdateTime()
		{
			if (Main.netMode != 1)
			{
				if (Sandstorm.Happening)
				{
					if (Sandstorm.TimeLeft > 86400)
					{
						Sandstorm.TimeLeft = 0;
					}
					Sandstorm.TimeLeft -= Main.dayRate;
					if (Sandstorm.TimeLeft <= 0)
					{
						Sandstorm.StopSandstorm();
					}
				}
				else
				{
					int value = (int)(Main.windSpeed * 100f);
					for (int i = 0; i < Main.dayRate; i++)
					{
						if (Main.rand.Next(518400) == 0)
						{
							Sandstorm.StartSandstorm();
						}
						else if ((Main.numClouds < 40 || Math.Abs(value) > 50) && Main.rand.Next(345600) == 0)
						{
							Sandstorm.StartSandstorm();
						}
					}
				}
				if (Main.rand.Next(18000) == 0)
				{
					Sandstorm.ChangeSeverityIntentions();
				}
			}
			Sandstorm.UpdateSeverity();
		}

		public static void WorldClear()
		{
			Sandstorm.Happening = false;
		}

		public static bool Happening;

		public static float IntendedSeverity;

		public static float Severity;

		public static int TimeLeft;

		private static bool _effectsUp = false;
	}
}
