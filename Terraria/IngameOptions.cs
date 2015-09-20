
using System;
using Terraria.GameContent;

namespace Terraria
{
	public static class IngameOptions
	{
		public const int width = 670;

		public const int height = 480;

		public static float[] leftScale;

		public static float[] rightScale;

		public static int leftHover;

		public static int rightHover;

		public static int oldLeftHover;

		public static int oldRightHover;

		public static int rightLock;

		public static bool inBar;

		public static bool notBar;

		public static bool noSound;

		private static Rectangle _GUIHover;

		public static int category;

		public static Vector2 valuePosition;

		static IngameOptions()
		{
			IngameOptions.leftScale = new float[] { 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f };
			IngameOptions.rightScale = new float[] { 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f };
			IngameOptions.leftHover = -1;
			IngameOptions.rightHover = -1;
			IngameOptions.oldLeftHover = -1;
			IngameOptions.oldRightHover = -1;
			IngameOptions.rightLock = -1;
			IngameOptions.inBar = false;
			IngameOptions.notBar = false;
			IngameOptions.noSound = false;
			IngameOptions._GUIHover = new Rectangle();
			IngameOptions.category = 0;
			IngameOptions.valuePosition = Vector2.Zero;
		}

		public static void Close()
		{
			if (Main.setKey != -1)
			{
				return;
			}
			Main.SaveSettings();
			Main.ingameOptionsWindow = false;
			Recipe.FindRecipes();
			Main.playerInventory = true;
		}

		public static void Draw(Main mainInstance)
		{
		}

		public static bool DrawLeftSide(string txt, int i, Vector2 anchor, Vector2 offset, float[] scales, float minscale = 0.7f, float maxscale = 0.8f, float scalespeed = 0.01f)
		{
			return false;
		}

		public static bool DrawRightSide(string txt, int i, Vector2 anchor, Vector2 offset, float scale, float colorScale, Color over = new Color())
		{
			return false;
		}

		public static bool DrawValue(string txt, int i, float scale, Color over = new Color())
		{
			return false;
		}

		public static float DrawValueBar(float scale, float perc)
		{
			return 1f;
		}

		public static void MouseOver()
		{
			if (!Main.ingameOptionsWindow)
			{
				return;
			}
			if (IngameOptions._GUIHover.Contains(Main.MouseScreen.ToPoint()))
			{
				Main.mouseText = true;
			}
		}

		public static void Open()
		{
			Main.playerInventory = false;
			Main.editChest = false;
			Main.npcChatText = "";
			Main.ingameOptionsWindow = true;
			IngameOptions.category = 0;
			for (int i = 0; i < (int)IngameOptions.leftScale.Length; i++)
			{
				IngameOptions.leftScale[i] = 0f;
			}
			for (int j = 0; j < (int)IngameOptions.rightScale.Length; j++)
			{
				IngameOptions.rightScale[j] = 0f;
			}
			IngameOptions.leftHover = -1;
			IngameOptions.rightHover = -1;
			IngameOptions.oldLeftHover = -1;
			IngameOptions.oldRightHover = -1;
			IngameOptions.rightLock = -1;
			IngameOptions.inBar = false;
			IngameOptions.notBar = false;
			IngameOptions.noSound = false;
		}
	}
}