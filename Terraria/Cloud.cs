using XNA;
using System;

namespace Terraria
{
	public class Cloud
	{
		public Vector2 position;

		public float scale;

		public float rotation;

		public float rSpeed;

		public float sSpeed;

		public bool active;

		public int type;

		public int width;

		public int height;

		public float Alpha;

		public bool kill;

		private static Random rand;

		static Cloud()
		{
			Cloud.rand = new Random();
		}

		public Cloud()
		{
		}

		public static void addCloud()
		{
		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}

		public Color cloudColor(Color bgColor)
		{
			float alpha = this.scale * this.Alpha;
			if (alpha > 1f)
			{
				alpha = 1f;
			}
			float r = (float)((int)((float)bgColor.R * alpha));
			float g = (float)((int)((float)bgColor.G * alpha));
			float b = (float)((int)((float)bgColor.B * alpha));
			float a = (float)((int)((float)bgColor.A * alpha));
			return new Color((int)r, (int)g, (int)b, (int)a);
		}

		public static void resetClouds()
		{
			if (Main.dedServ)
			{
				return;
			}
			if (Main.cloudLimit < 10)
			{
				return;
			}
			Main.windSpeed = Main.windSpeedSet;
			for (int i = 0; i < 200; i++)
			{
				Main.cloud[i].active = false;
			}
			for (int j = 0; j < Main.numClouds; j++)
			{
				Cloud.addCloud();
				Main.cloud[j].Alpha = 1f;
			}
			for (int k = 0; k < 200; k++)
			{
				Main.cloud[k].Alpha = 1f;
			}
		}

		public void Update()
		{
		}

		public static void UpdateClouds()
		{
		}
	}
}