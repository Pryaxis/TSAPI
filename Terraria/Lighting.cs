using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Terraria.DataStructures;
namespace Terraria
{
	public class Lighting
	{
		private class LightingSwipeData
		{
			public int outerLoopStart;
			public int outerLoopEnd;
			public int innerLoop1Start;
			public int innerLoop1End;
			public int innerLoop2Start;
			public int innerLoop2End;
			public Random rand;
			public Action<Lighting.LightingSwipeData> function;
			public Lighting.LightingState[][] jaggedArray;
			public LightingSwipeData()
			{
				this.innerLoop1Start = 0;
				this.outerLoopStart = 0;
				this.innerLoop1End = 0;
				this.outerLoopEnd = 0;
				this.innerLoop2Start = 0;
				this.innerLoop2End = 0;
				this.function = null;
				this.rand = new Random();
			}
			public void CopyFrom(Lighting.LightingSwipeData from)
			{
				this.innerLoop1Start = from.innerLoop1Start;
				this.outerLoopStart = from.outerLoopStart;
				this.innerLoop1End = from.innerLoop1End;
				this.outerLoopEnd = from.outerLoopEnd;
				this.innerLoop2Start = from.innerLoop2Start;
				this.innerLoop2End = from.innerLoop2End;
				this.function = from.function;
				this.jaggedArray = from.jaggedArray;
			}
		}
		private class LightingState
		{
			public float r;
			public float r2;
			public float g;
			public float g2;
			public float b;
			public float b2;
			public bool stopLight;
			public bool wetLight;
			public bool honeyLight;
		}
		private struct ColorTriplet
		{
			public float r;
			public float g;
			public float b;
			public ColorTriplet(float R, float G, float B)
			{
				this.r = R;
				this.g = G;
				this.b = B;
			}
			public ColorTriplet(float averageColor)
			{
				this.b = averageColor;
				this.g = averageColor;
				this.r = averageColor;
			}
		}
		public static int maxRenderCount = 4;
		public static float brightness = 1f;
		public static float defBrightness = 1f;
		public static int lightMode = 0;
		public static bool RGB = true;
		private static float oldSkyColor = 0f;
		private static float skyColor = 0f;
		private static int lightCounter = 0;
		public static int offScreenTiles = 45;
		public static int offScreenTiles2 = 35;
		private static int firstTileX;
		private static int lastTileX;
		private static int firstTileY;
		private static int lastTileY;
		public static int LightingThreads = 0;
		private static Lighting.LightingState[][] states;
		private static Lighting.LightingState[][] axisFlipStates;
		private static Lighting.LightingSwipeData swipe;
		private static Lighting.LightingSwipeData[] threadSwipes;
		private static CountdownEvent countdown;
		public static int scrX;
		public static int scrY;
		public static int minX;
		public static int maxX;
		public static int minY;
		public static int maxY;
		private static int maxTempLights = 2000;
		private static Dictionary<Point16, Lighting.ColorTriplet> tempLights;
		private static int firstToLightX;
		private static int firstToLightY;
		private static int lastToLightX;
		private static int lastToLightY;
		private static float negLight = 0.04f;
		private static float negLight2 = 0.16f;
		private static float wetLightR = 0.16f;
		private static float wetLightG = 0.16f;
		private static float wetLightB = 0.16f;
		private static float honeyLightR = 0.16f;
		private static float honeyLightG = 0.16f;
		private static float honeyLightB = 0.16f;
		private static float blueWave = 1f;
		private static int blueDir = 1;
		private static int minX7;
		private static int maxX7;
		private static int minY7;
		private static int maxY7;
		private static int firstTileX7;
		private static int lastTileX7;
		private static int lastTileY7;
		private static int firstTileY7;
		private static int firstToLightX7;
		private static int lastToLightX7;
		private static int firstToLightY7;
		private static int lastToLightY7;
		private static int firstToLightX27;
		private static int lastToLightX27;
		private static int firstToLightY27;
		private static int lastToLightY27;
		public static void Initialize(bool resize = false)
		{
			if (!resize)
			{
				Lighting.tempLights = new Dictionary<Point16, Lighting.ColorTriplet>();
				Lighting.swipe = new Lighting.LightingSwipeData();
				Lighting.countdown = new CountdownEvent(0);
				Lighting.threadSwipes = new Lighting.LightingSwipeData[Environment.ProcessorCount];
				for (int i = 0; i < Lighting.threadSwipes.Length; i++)
				{
					Lighting.threadSwipes[i] = new Lighting.LightingSwipeData();
				}
			}
			int num = Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10;
			int num2 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10;
			if (Lighting.states == null || Lighting.states.Length < num || Lighting.states[0].Length < num2)
			{
				Lighting.states = new Lighting.LightingState[num][];
				Lighting.axisFlipStates = new Lighting.LightingState[num2][];
				for (int j = 0; j < num2; j++)
				{
					Lighting.axisFlipStates[j] = new Lighting.LightingState[num];
				}
				for (int k = 0; k < num; k++)
				{
					Lighting.LightingState[] array = new Lighting.LightingState[num2];
					for (int l = 0; l < num2; l++)
					{
						Lighting.LightingState lightingState = new Lighting.LightingState();
						array[l] = lightingState;
						Lighting.axisFlipStates[l][k] = lightingState;
					}
					Lighting.states[k] = array;
				}
			}
		}
		

		private static void callback_LightingSwipe(object obj)
		{
			Lighting.LightingSwipeData lightingSwipeData = obj as Lighting.LightingSwipeData;
			try
			{
				lightingSwipeData.function(lightingSwipeData);
			}
			catch
			{
			}
			Lighting.countdown.Signal();
		}
		private static void doColors_Mode0_Swipe(Lighting.LightingSwipeData swipeData)
		{
			try
			{
				bool flag = true;
				while (true)
				{
					int num;
					int num2;
					int num3;
					if (flag)
					{
						num = 1;
						num2 = swipeData.innerLoop1Start;
						num3 = swipeData.innerLoop1End;
					}
					else
					{
						num = -1;
						num2 = swipeData.innerLoop2Start;
						num3 = swipeData.innerLoop2End;
					}
					int outerLoopStart = swipeData.outerLoopStart;
					int outerLoopEnd = swipeData.outerLoopEnd;
					for (int i = outerLoopStart; i < outerLoopEnd; i++)
					{
						Lighting.LightingState[] array = swipeData.jaggedArray[i];
						float num4 = 0f;
						float num5 = 0f;
						float num6 = 0f;
						int num7 = num2;
						while (num7 != num3)
						{
							Lighting.LightingState lightingState = array[num7];
							Lighting.LightingState lightingState2 = array[num7 + num];
							bool flag3;
							bool flag2 = flag3 = false;
							if (lightingState.r2 > num4)
							{
								num4 = lightingState.r2;
							}
							else if ((double)num4 <= 0.0185)
							{
								flag3 = true;
							}
							else if (lightingState.r2 < num4)
							{
								lightingState.r2 = num4;
							}
							if (!flag3 && lightingState2.r2 <= num4)
							{
								if (lightingState.stopLight)
								{
									num4 *= Lighting.negLight2;
								}
								else if (lightingState.wetLight)
								{
									if (lightingState.honeyLight)
									{
										num4 *= Lighting.honeyLightR * (float)swipeData.rand.Next(98, 100) * 0.01f;
									}
									else
									{
										num4 *= Lighting.wetLightR * (float)swipeData.rand.Next(98, 100) * 0.01f;
									}
								}
								else
								{
									num4 *= Lighting.negLight;
								}
							}
							if (lightingState.g2 > num5)
							{
								num5 = lightingState.g2;
							}
							else if ((double)num5 <= 0.0185)
							{
								flag2 = true;
							}
							else
							{
								lightingState.g2 = num5;
							}
							if (!flag2 && lightingState2.g2 <= num5)
							{
								if (lightingState.stopLight)
								{
									num5 *= Lighting.negLight2;
								}
								else if (lightingState.wetLight)
								{
									if (lightingState.honeyLight)
									{
										num5 *= Lighting.honeyLightG * (float)swipeData.rand.Next(97, 100) * 0.01f;
									}
									else
									{
										num5 *= Lighting.wetLightG * (float)swipeData.rand.Next(97, 100) * 0.01f;
									}
								}
								else
								{
									num5 *= Lighting.negLight;
								}
							}
							if (lightingState.b2 > num6)
							{
								num6 = lightingState.b2;
								goto IL_22F;
							}
							if ((double)num6 > 0.0185)
							{
								lightingState.b2 = num6;
								goto IL_22F;
							}
							IL_2B1:
							num7 += num;
							continue;
							IL_22F:
							if (lightingState2.b2 >= num6)
							{
								goto IL_2B1;
							}
							if (lightingState.stopLight)
							{
								num6 *= Lighting.negLight2;
								goto IL_2B1;
							}
							if (!lightingState.wetLight)
							{
								num6 *= Lighting.negLight;
								goto IL_2B1;
							}
							if (lightingState.honeyLight)
							{
								num6 *= Lighting.honeyLightB * (float)swipeData.rand.Next(97, 100) * 0.01f;
								goto IL_2B1;
							}
							num6 *= Lighting.wetLightB * (float)swipeData.rand.Next(97, 100) * 0.01f;
							goto IL_2B1;
						}
					}
					if (!flag)
					{
						break;
					}
					flag = false;
				}
			}
			catch
			{
			}
		}
		private static void doColors_Mode1_Swipe(Lighting.LightingSwipeData swipeData)
		{
			try
			{
				bool flag = true;
				while (true)
				{
					int num;
					int num2;
					int num3;
					if (flag)
					{
						num = 1;
						num2 = swipeData.innerLoop1Start;
						num3 = swipeData.innerLoop1End;
					}
					else
					{
						num = -1;
						num2 = swipeData.innerLoop2Start;
						num3 = swipeData.innerLoop2End;
					}
					int outerLoopStart = swipeData.outerLoopStart;
					int outerLoopEnd = swipeData.outerLoopEnd;
					for (int i = outerLoopStart; i < outerLoopEnd; i++)
					{
						Lighting.LightingState[] array = swipeData.jaggedArray[i];
						float num4 = 0f;
						int num5 = num2;
						while (num5 != num3)
						{
							Lighting.LightingState lightingState = array[num5];
							if (lightingState.r2 > num4)
							{
								num4 = lightingState.r2;
								goto IL_9C;
							}
							if ((double)num4 > 0.0185)
							{
								if (lightingState.r2 < num4)
								{
									lightingState.r2 = num4;
									goto IL_9C;
								}
								goto IL_9C;
							}
							IL_123:
							num5 += num;
							continue;
							IL_9C:
							if (array[num5 + num].r2 > num4)
							{
								goto IL_123;
							}
							if (lightingState.stopLight)
							{
								num4 *= Lighting.negLight2;
								goto IL_123;
							}
							if (!lightingState.wetLight)
							{
								num4 *= Lighting.negLight;
								goto IL_123;
							}
							if (lightingState.honeyLight)
							{
								num4 *= Lighting.honeyLightR * (float)swipeData.rand.Next(98, 100) * 0.01f;
								goto IL_123;
							}
							num4 *= Lighting.wetLightR * (float)swipeData.rand.Next(98, 100) * 0.01f;
							goto IL_123;
						}
					}
					if (!flag)
					{
						break;
					}
					flag = false;
				}
			}
			catch
			{
			}
		}
		private static void doColors_Mode2_Swipe(Lighting.LightingSwipeData swipeData)
		{
			try
			{
				bool flag = true;
				while (true)
				{
					int num;
					int num2;
					int num3;
					if (flag)
					{
						num = 1;
						num2 = swipeData.innerLoop1Start;
						num3 = swipeData.innerLoop1End;
					}
					else
					{
						num = -1;
						num2 = swipeData.innerLoop2Start;
						num3 = swipeData.innerLoop2End;
					}
					int outerLoopStart = swipeData.outerLoopStart;
					int outerLoopEnd = swipeData.outerLoopEnd;
					for (int i = outerLoopStart; i < outerLoopEnd; i++)
					{
						Lighting.LightingState[] array = swipeData.jaggedArray[i];
						float num4 = 0f;
						int num5 = num2;
						while (num5 != num3)
						{
							Lighting.LightingState lightingState = array[num5];
							if (lightingState.r2 > num4)
							{
								num4 = lightingState.r2;
								goto IL_86;
							}
							if (num4 > 0f)
							{
								lightingState.r2 = num4;
								goto IL_86;
							}
							IL_BA:
							num5 += num;
							continue;
							IL_86:
							if (lightingState.stopLight)
							{
								num4 -= Lighting.negLight2;
								goto IL_BA;
							}
							if (lightingState.wetLight)
							{
								num4 -= Lighting.wetLightR;
								goto IL_BA;
							}
							num4 -= Lighting.negLight;
							goto IL_BA;
						}
					}
					if (!flag)
					{
						break;
					}
					flag = false;
				}
			}
			catch
			{
			}
		}
		private static void doColors_Mode3_Swipe(Lighting.LightingSwipeData swipeData)
		{
			try
			{
				bool flag = true;
				while (true)
				{
					int num;
					int num2;
					int num3;
					if (flag)
					{
						num = 1;
						num2 = swipeData.innerLoop1Start;
						num3 = swipeData.innerLoop1End;
					}
					else
					{
						num = -1;
						num2 = swipeData.innerLoop2Start;
						num3 = swipeData.innerLoop2End;
					}
					int outerLoopStart = swipeData.outerLoopStart;
					int outerLoopEnd = swipeData.outerLoopEnd;
					for (int i = outerLoopStart; i < outerLoopEnd; i++)
					{
						Lighting.LightingState[] array = swipeData.jaggedArray[i];
						float num4 = 0f;
						float num5 = 0f;
						float num6 = 0f;
						int num7 = num2;
						while (num7 != num3)
						{
							Lighting.LightingState lightingState = array[num7];
							bool flag3;
							bool flag2 = flag3 = false;
							if (lightingState.r2 > num4)
							{
								num4 = lightingState.r2;
							}
							else if (num4 <= 0f)
							{
								flag3 = true;
							}
							else
							{
								lightingState.r2 = num4;
							}
							if (!flag3)
							{
								if (lightingState.stopLight)
								{
									num4 -= Lighting.negLight2;
								}
								else if (lightingState.wetLight)
								{
									num4 -= Lighting.wetLightR;
								}
								else
								{
									num4 -= Lighting.negLight;
								}
							}
							if (lightingState.g2 > num5)
							{
								num5 = lightingState.g2;
							}
							else if (num5 <= 0f)
							{
								flag2 = true;
							}
							else
							{
								lightingState.g2 = num5;
							}
							if (!flag2)
							{
								if (lightingState.stopLight)
								{
									num5 -= Lighting.negLight2;
								}
								else if (lightingState.wetLight)
								{
									num5 -= Lighting.wetLightG;
								}
								else
								{
									num5 -= Lighting.negLight;
								}
							}
							if (lightingState.b2 > num6)
							{
								num6 = lightingState.b2;
								goto IL_167;
							}
							if (num6 > 0f)
							{
								lightingState.b2 = num6;
								goto IL_167;
							}
							IL_186:
							num7 += num;
							continue;
							IL_167:
							if (lightingState.stopLight)
							{
								num6 -= Lighting.negLight2;
								goto IL_186;
							}
							num6 -= Lighting.negLight;
							goto IL_186;
						}
					}
					if (!flag)
					{
						break;
					}
					flag = false;
				}
			}
			catch
			{
			}
		}
		public static void addLight(int i, int j, float R, float G, float B)
		{
			if (Main.netMode == 2)
			{
				return;
			}
			if (i - Lighting.firstTileX + Lighting.offScreenTiles >= 0 && i - Lighting.firstTileX + Lighting.offScreenTiles < Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 && j - Lighting.firstTileY + Lighting.offScreenTiles >= 0 && j - Lighting.firstTileY + Lighting.offScreenTiles < Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
			{
				if (Lighting.tempLights.Count == Lighting.maxTempLights)
				{
					return;
				}
				Point16 key = new Point16(i, j);
				Lighting.ColorTriplet value;
				if (Lighting.tempLights.TryGetValue(key, out value))
				{
					if (Lighting.RGB)
					{
						if (value.r < R)
						{
							value.r = R;
						}
						if (value.g < G)
						{
							value.g = G;
						}
						if (value.b < B)
						{
							value.b = B;
						}
						Lighting.tempLights[key] = value;
						return;
					}
					float num = (R + G + B) / 3f;
					if (value.r < num)
					{
						Lighting.tempLights[key] = new Lighting.ColorTriplet(num);
						return;
					}
				}
				else
				{
					if (Lighting.RGB)
					{
						value = new Lighting.ColorTriplet(R, G, B);
					}
					else
					{
						value = new Lighting.ColorTriplet((R + G + B) / 3f);
					}
					Lighting.tempLights.Add(key, value);
				}
			}
		}
		public static void NextLightMode()
		{
			Lighting.lightCounter += 100;
			Lighting.lightMode++;
			if (Lighting.lightMode >= 4)
			{
				Lighting.lightMode = 0;
			}
			if (Lighting.lightMode == 2 || Lighting.lightMode == 0)
			{
				Main.renderCount = 0;
				Main.renderNow = true;
				Lighting.BlackOut();
			}
		}
		public static void BlackOut()
		{
			int num = Main.screenWidth / 16 + Lighting.offScreenTiles * 2;
			int num2 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2;
			for (int i = 0; i < num; i++)
			{
				Lighting.LightingState[] array = Lighting.states[i];
				for (int j = 0; j < num2; j++)
				{
					Lighting.LightingState lightingState = array[j];
					lightingState.r = 0f;
					lightingState.g = 0f;
					lightingState.b = 0f;
				}
			}
		}
		public static Color GetColor(int x, int y, Color oldColor)
		{
			int num = x - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
			if (Main.gameMenu)
			{
				return oldColor;
			}
			if (num < 0 || num2 < 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
			{
				return Color.Black;
			}
			Color white = Color.White;
			Lighting.LightingState lightingState = Lighting.states[num][num2];
			int num3 = (int)((float)oldColor.R * lightingState.r * Lighting.brightness);
			int num4 = (int)((float)oldColor.G * lightingState.g * Lighting.brightness);
			int num5 = (int)((float)oldColor.B * lightingState.b * Lighting.brightness);
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num4 > 255)
			{
				num4 = 255;
			}
			if (num5 > 255)
			{
				num5 = 255;
			}
			white.R = (byte)num3;
			white.G = (byte)num4;
			white.B = (byte)num5;
			return white;
		}
		public static Color GetColor(int x, int y)
		{
			int num = x - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
			if (num < 0 || num2 < 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2)
			{
				return Color.Black;
			}
			Lighting.LightingState lightingState = Lighting.states[num][num2];
			int num3 = (int)(255f * lightingState.r * Lighting.brightness);
			int num4 = (int)(255f * lightingState.g * Lighting.brightness);
			int num5 = (int)(255f * lightingState.b * Lighting.brightness);
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num4 > 255)
			{
				num4 = 255;
			}
			if (num5 > 255)
			{
				num5 = 255;
			}
			Color result = new Color((int)((byte)num3), (int)((byte)num4), (int)((byte)num5), 255);
			return result;
		}
		public static void GetColor9Slice(int centerX, int centerY, ref Color[] slices)
		{
			int num = centerX - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = centerY - Lighting.firstTileY + Lighting.offScreenTiles;
			if (num <= 0 || num2 <= 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 - 1 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 - 1)
			{
				for (int i = 0; i < 9; i++)
				{
					slices[i] = Color.Black;
				}
				return;
			}
			int num3 = 0;
			for (int j = num - 1; j <= num + 1; j++)
			{
				Lighting.LightingState[] array = Lighting.states[j];
				for (int k = num2 - 1; k <= num2 + 1; k++)
				{
					Lighting.LightingState lightingState = array[k];
					int num4 = (int)(255f * lightingState.r * Lighting.brightness);
					int num5 = (int)(255f * lightingState.g * Lighting.brightness);
					int num6 = (int)(255f * lightingState.b * Lighting.brightness);
					if (num4 > 255)
					{
						num4 = 255;
					}
					if (num5 > 255)
					{
						num5 = 255;
					}
					if (num6 > 255)
					{
						num6 = 255;
					}
					slices[num3] = new Color((int)((byte)num4), (int)((byte)num5), (int)((byte)num6), 255);
					num3 += 3;
				}
				num3 -= 8;
			}
		}
		public static void GetColor4Slice(int centerX, int centerY, ref Color[] slices)
		{
			int i = centerX - Lighting.firstTileX + Lighting.offScreenTiles;
			int num = centerY - Lighting.firstTileY + Lighting.offScreenTiles;
			if (i <= 0 || num <= 0 || i >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 - 1 || num >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 - 1)
			{
				for (i = 0; i < 4; i++)
				{
					slices[i] = Color.Black;
				}
				return;
			}
			Lighting.LightingState lightingState = Lighting.states[i][num - 1];
			Lighting.LightingState lightingState2 = Lighting.states[i][num + 1];
			Lighting.LightingState lightingState3 = Lighting.states[i - 1][num];
			Lighting.LightingState lightingState4 = Lighting.states[i + 1][num];
			float num2 = lightingState.r + lightingState.g + lightingState.b;
			float num3 = lightingState2.r + lightingState2.g + lightingState2.b;
			float num4 = lightingState4.r + lightingState4.g + lightingState4.b;
			float num5 = lightingState3.r + lightingState3.g + lightingState3.b;
			if (num2 >= num5)
			{
				int num6 = (int)(255f * lightingState3.r * Lighting.brightness);
				int num7 = (int)(255f * lightingState3.g * Lighting.brightness);
				int num8 = (int)(255f * lightingState3.b * Lighting.brightness);
				if (num6 > 255)
				{
					num6 = 255;
				}
				if (num7 > 255)
				{
					num7 = 255;
				}
				if (num8 > 255)
				{
					num8 = 255;
				}
				slices[0] = new Color((int)((byte)num6), (int)((byte)num7), (int)((byte)num8), 255);
			}
			else
			{
				int num9 = (int)(255f * lightingState.r * Lighting.brightness);
				int num10 = (int)(255f * lightingState.g * Lighting.brightness);
				int num11 = (int)(255f * lightingState.b * Lighting.brightness);
				if (num9 > 255)
				{
					num9 = 255;
				}
				if (num10 > 255)
				{
					num10 = 255;
				}
				if (num11 > 255)
				{
					num11 = 255;
				}
				slices[0] = new Color((int)((byte)num9), (int)((byte)num10), (int)((byte)num11), 255);
			}
			if (num2 >= num4)
			{
				int num12 = (int)(255f * lightingState4.r * Lighting.brightness);
				int num13 = (int)(255f * lightingState4.g * Lighting.brightness);
				int num14 = (int)(255f * lightingState4.b * Lighting.brightness);
				if (num12 > 255)
				{
					num12 = 255;
				}
				if (num13 > 255)
				{
					num13 = 255;
				}
				if (num14 > 255)
				{
					num14 = 255;
				}
				slices[1] = new Color((int)((byte)num12), (int)((byte)num13), (int)((byte)num14), 255);
			}
			else
			{
				int num15 = (int)(255f * lightingState.r * Lighting.brightness);
				int num16 = (int)(255f * lightingState.g * Lighting.brightness);
				int num17 = (int)(255f * lightingState.b * Lighting.brightness);
				if (num15 > 255)
				{
					num15 = 255;
				}
				if (num16 > 255)
				{
					num16 = 255;
				}
				if (num17 > 255)
				{
					num17 = 255;
				}
				slices[1] = new Color((int)((byte)num15), (int)((byte)num16), (int)((byte)num17), 255);
			}
			if (num3 >= num5)
			{
				int num18 = (int)(255f * lightingState3.r * Lighting.brightness);
				int num19 = (int)(255f * lightingState3.g * Lighting.brightness);
				int num20 = (int)(255f * lightingState3.b * Lighting.brightness);
				if (num18 > 255)
				{
					num18 = 255;
				}
				if (num19 > 255)
				{
					num19 = 255;
				}
				if (num20 > 255)
				{
					num20 = 255;
				}
				slices[2] = new Color((int)((byte)num18), (int)((byte)num19), (int)((byte)num20), 255);
			}
			else
			{
				int num21 = (int)(255f * lightingState2.r * Lighting.brightness);
				int num22 = (int)(255f * lightingState2.g * Lighting.brightness);
				int num23 = (int)(255f * lightingState2.b * Lighting.brightness);
				if (num21 > 255)
				{
					num21 = 255;
				}
				if (num22 > 255)
				{
					num22 = 255;
				}
				if (num23 > 255)
				{
					num23 = 255;
				}
				slices[2] = new Color((int)((byte)num21), (int)((byte)num22), (int)((byte)num23), 255);
			}
			if (num3 >= num4)
			{
				int num24 = (int)(255f * lightingState4.r * Lighting.brightness);
				int num25 = (int)(255f * lightingState4.g * Lighting.brightness);
				int num26 = (int)(255f * lightingState4.b * Lighting.brightness);
				if (num24 > 255)
				{
					num24 = 255;
				}
				if (num25 > 255)
				{
					num25 = 255;
				}
				if (num26 > 255)
				{
					num26 = 255;
				}
				slices[3] = new Color((int)((byte)num24), (int)((byte)num25), (int)((byte)num26), 255);
				return;
			}
			int num27 = (int)(255f * lightingState2.r * Lighting.brightness);
			int num28 = (int)(255f * lightingState2.g * Lighting.brightness);
			int num29 = (int)(255f * lightingState2.b * Lighting.brightness);
			if (num27 > 255)
			{
				num27 = 255;
			}
			if (num28 > 255)
			{
				num28 = 255;
			}
			if (num29 > 255)
			{
				num29 = 255;
			}
			slices[3] = new Color((int)((byte)num27), (int)((byte)num28), (int)((byte)num29), 255);
		}
		public static Color GetBlackness(int x, int y)
		{
			int num = x - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
			if (num < 0 || num2 < 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
			{
				return Color.Black;
			}
			Color result = new Color(0, 0, 0, (int)((byte)(255f - 255f * Lighting.states[num][num2].r)));
			return result;
		}
		public static float Brightness(int x, int y)
		{
			int num = x - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
			if (num < 0 || num2 < 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
			{
				return 0f;
			}
			Lighting.LightingState lightingState = Lighting.states[num][num2];
			return (lightingState.r + lightingState.g + lightingState.b) / 3f;
		}
	}
}
