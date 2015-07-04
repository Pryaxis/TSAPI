
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Terraria.DataStructures;
using Terraria.Map;

namespace Terraria
{
	public class Lighting
	{
		public static int maxRenderCount;

		public static float brightness;

		public static float defBrightness;

		public static int lightMode;

		public static bool RGB;

		private static float oldSkyColor;

		private static float skyColor;

		private static int lightCounter;

		public static int offScreenTiles;

		public static int offScreenTiles2;

		private static int firstTileX;

		private static int lastTileX;

		private static int firstTileY;

		private static int lastTileY;

		public static int LightingThreads;

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

		private static int maxTempLights;

		private static Dictionary<Point16, Lighting.ColorTriplet> tempLights;

		private static int firstToLightX;

		private static int firstToLightY;

		private static int lastToLightX;

		private static int lastToLightY;

		private static float negLight;

		private static float negLight2;

		private static float wetLightR;

		private static float wetLightG;

		private static float wetLightB;

		private static float honeyLightR;

		private static float honeyLightG;

		private static float honeyLightB;

		private static float blueWave;

		private static int blueDir;

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

		static Lighting()
		{
			Lighting.maxRenderCount = 4;
			Lighting.brightness = 1f;
			Lighting.defBrightness = 1f;
			Lighting.lightMode = 0;
			Lighting.RGB = true;
			Lighting.oldSkyColor = 0f;
			Lighting.skyColor = 0f;
			Lighting.lightCounter = 0;
			Lighting.offScreenTiles = 45;
			Lighting.offScreenTiles2 = 35;
			Lighting.LightingThreads = 0;
			Lighting.maxTempLights = 2000;
			Lighting.negLight = 0.04f;
			Lighting.negLight2 = 0.16f;
			Lighting.wetLightR = 0.16f;
			Lighting.wetLightG = 0.16f;
			Lighting.wetLightB = 0.16f;
			Lighting.honeyLightR = 0.16f;
			Lighting.honeyLightG = 0.16f;
			Lighting.honeyLightB = 0.16f;
			Lighting.blueWave = 1f;
			Lighting.blueDir = 1;
		}

		public Lighting()
		{
		}

		public static void AddLight(Vector2 position, Vector3 rgb)
		{
		}

		public static void AddLight(Vector2 position, float R, float G, float B)
		{
		}

		public static void AddLight(int i, int j, float R, float G, float B)
		{
		}

		public static void BlackOut()
		{
		}

		public static float Brightness(int x, int y)
		{
			return 0.0f;
		}

		public static float BrightnessAverage(int x, int y, int width, int height)
		{
			return 0.0f;
		}

		private static void callback_LightingSwipe(object obj)
		{
		}

		public static void doColors()
		{
		}

		private static void doColors_Mode0_Swipe(Lighting.LightingSwipeData swipeData)
		{
		}

		private static void doColors_Mode1_Swipe(Lighting.LightingSwipeData swipeData)
		{
		}

		private static void doColors_Mode2_Swipe(Lighting.LightingSwipeData swipeData)
		{
		}

		private static void doColors_Mode3_Swipe(Lighting.LightingSwipeData swipeData)
		{
		}

		public static Color GetBlackness(int x, int y)
		{
			return Color.White;
		}

		public static Color GetColor(int x, int y, Color oldColor)
		{
			return oldColor;
		}

		public static Color GetColor(int x, int y)
		{
			return Color.White;
		}

		public static void GetColor4Slice(int centerX, int centerY, ref Color[] slices)
		{
		}

		public static void GetColor9Slice(int centerX, int centerY, ref Color[] slices)
		{
		}

		public static Vector3 GetSubLight(Vector2 position)
		{
			return Vector3.Zero;
		}

		public static void Initialize(bool resize = false)
		{
		}

		public static void LightTiles(int firstX, int lastX, int firstY, int lastY)
		{
		}

		public static void NextLightMode()
		{
		}

		public static void PreRenderPhase() 
		{
		}
		
		struct ColorTriplet
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
				float single = averageColor;
				float single1 = single;
				this.b = single;
				float single2 = single1;
				float single3 = single2;
				this.g = single2;
				this.r = single3;
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

			public LightingState()
			{
			}

			public Vector3 ToVector3()
			{
				return new Vector3(this.r, this.g, this.b);
			}
		}

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
	}
}