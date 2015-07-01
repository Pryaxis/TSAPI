using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Terraria.GameContent;
using Terraria.Social;
using Terraria.Social.Base;
using Terraria.UI;

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
			Main.PlaySound(11, -1, -1, 1);
			Recipe.FindRecipes();
			Main.playerInventory = true;
		}

		public static void Draw(Main mainInstance, SpriteBatch sb)
		{
			Color gold;
			string str;
			Color white;
			Color color;
			string str1;
			Color gold1;
			Color color1;
			string str2;
			Color white1;
			Color gold2;
			string str3;
			Color white2;
			Color color2;
			string str4;
			Color gold3;
			Color color3;
			string str5;
			Color white3;
			Color gold4;
			string str6;
			Color white4;
			Color color4;
			string str7;
			Color gold5;
			Color color5;
			string str8;
			Color white5;
			Color gold6;
			string str9;
			Color white6;
			Color color6;
			string str10;
			Color gold7;
			Color color7;
			string str11;
			Color white7;
			Color gold8;
			string str12;
			Color white8;
			Color color8;
			string str13;
			Color gold9;
			Color color9;
			string str14;
			Color white9;
			Color gold10;
			string str15;
			Color white10;
			Color color10;
			string str16;
			Color gold11;
			Color color11;
			string str17;
			Color white11;
			Color gold12;
			string str18;
			Color white12;
			Color color12;
			string str19;
			Color gold13;
			string str20;
			string str21;
			string str22;
			string str23;
			string str24;
			string str25;
			string str26;
			string str27;
			string str28;
			if (Main.player[Main.myPlayer].dead && !Main.player[Main.myPlayer].ghost)
			{
				Main.setKey = -1;
				IngameOptions.Close();
				Main.playerInventory = false;
				return;
			}
			Vector2 vector2 = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			bool flag = (!Main.mouseLeft ? false : Main.mouseLeftRelease);
			Vector2 vector21 = new Vector2((float)Main.screenWidth, (float)Main.screenHeight);
			Vector2 vector22 = new Vector2(670f, 480f);
			Vector2 vector23 = (vector21 / 2f) - (vector22 / 2f);
			int num = 20;
			IngameOptions._GUIHover = new Rectangle((int)(vector23.X - (float)num), (int)(vector23.Y - (float)num), (int)(vector22.X + (float)(num * 2)), (int)(vector22.Y + (float)(num * 2)));
			Utils.DrawInvBG(sb, vector23.X - (float)num, vector23.Y - (float)num, vector22.X + (float)(num * 2), vector22.Y + (float)(num * 2), new Color(33, 15, 91, 255) * 0.685f);
			if ((new Rectangle((int)vector23.X - num, (int)vector23.Y - num, (int)vector22.X + num * 2, (int)vector22.Y + num * 2)).Contains(new Point(Main.mouseX, Main.mouseY)))
			{
				Main.player[Main.myPlayer].mouseInterface = true;
			}
			float x = vector23.X + (float)(num / 2);
			float y = vector23.Y + (float)(num * 5 / 2);
			float single = vector22.X / 2f - (float)num;
			float y1 = vector22.Y - (float)(num * 3);
			Color color13 = new Color();
			Utils.DrawInvBG(sb, x, y, single, y1, color13);
			float x1 = vector23.X + vector22.X / 2f + (float)num;
			float single1 = vector23.Y + (float)(num * 5 / 2);
			float x2 = vector22.X / 2f - (float)(num * 3 / 2);
			float y2 = vector22.Y - (float)(num * 3);
			Color color14 = new Color();
			Utils.DrawInvBG(sb, x1, single1, x2, y2, color14);
			Utils.DrawBorderString(sb, "Settings Menu", vector23 + (vector22 * new Vector2(0.5f, 0f)), Color.White, 1f, 0.5f, 0f, -1);
			float single2 = 0.7f;
			float single3 = 0.8f;
			float single4 = 0.01f;
			if (IngameOptions.oldLeftHover != IngameOptions.leftHover && IngameOptions.leftHover != -1)
			{
				Main.PlaySound(12, -1, -1, 1);
			}
			if (IngameOptions.oldRightHover != IngameOptions.rightHover && IngameOptions.rightHover != -1)
			{
				Main.PlaySound(12, -1, -1, 1);
			}
			if (flag && IngameOptions.rightHover != -1 && !IngameOptions.noSound)
			{
				Main.PlaySound(12, -1, -1, 1);
			}
			IngameOptions.oldLeftHover = IngameOptions.leftHover;
			IngameOptions.oldRightHover = IngameOptions.rightHover;
			IngameOptions.noSound = false;
			bool flag1 = (SocialAPI.Network == null ? false : SocialAPI.Network.CanInvite());
			int num1 = (flag1 ? 1 : 0);
			int num2 = 6 + num1;
			Vector2 vector24 = new Vector2(vector23.X + vector22.X / 4f, vector23.Y + (float)(num * 5 / 2));
			Vector2 vector25 = new Vector2(0f, vector22.Y - (float)(num * 5)) / (float)(num2 + 1);
			for (int i = 0; i <= num2; i++)
			{
				if (IngameOptions.leftHover == i || i == IngameOptions.category)
				{
					IngameOptions.leftScale[i] = IngameOptions.leftScale[i] + single4;
				}
				else
				{
					IngameOptions.leftScale[i] = IngameOptions.leftScale[i] - single4;
				}
				if (IngameOptions.leftScale[i] < single2)
				{
					IngameOptions.leftScale[i] = single2;
				}
				if (IngameOptions.leftScale[i] > single3)
				{
					IngameOptions.leftScale[i] = single3;
				}
			}
			IngameOptions.leftHover = -1;
			int num3 = IngameOptions.category;
			if (IngameOptions.DrawLeftSide(sb, Lang.menu[114], 0, vector24, vector25, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
			{
				IngameOptions.leftHover = 0;
				if (flag)
				{
					IngameOptions.category = 0;
					Main.PlaySound(10, -1, -1, 1);
				}
			}
			if (IngameOptions.DrawLeftSide(sb, Lang.menu[63], 1, vector24, vector25, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
			{
				IngameOptions.leftHover = 1;
				if (flag)
				{
					IngameOptions.category = 1;
					Main.PlaySound(10, -1, -1, 1);
				}
			}
			if (IngameOptions.DrawLeftSide(sb, Lang.menu[66], 2, vector24, vector25, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
			{
				IngameOptions.leftHover = 2;
				if (flag)
				{
					IngameOptions.category = 2;
					Main.PlaySound(10, -1, -1, 1);
				}
			}
			if (IngameOptions.DrawLeftSide(sb, Lang.menu[115], 3, vector24, vector25, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
			{
				IngameOptions.leftHover = 3;
				if (flag)
				{
					IngameOptions.category = 3;
					Main.PlaySound(10, -1, -1, 1);
				}
			}
			if (flag1 && IngameOptions.DrawLeftSide(sb, Lang.menu[141], 4, vector24, vector25, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
			{
				IngameOptions.leftHover = 4;
				if (flag)
				{
					IngameOptions.Close();
					SocialAPI.Network.OpenInviteInterface();
				}
			}
			if (IngameOptions.DrawLeftSide(sb, Lang.menu[131], 4 + num1, vector24, vector25, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
			{
				IngameOptions.leftHover = 4 + num1;
				if (flag)
				{
					IngameOptions.Close();
					AchievementsUI.Open();
				}
			}
			if (IngameOptions.DrawLeftSide(sb, Lang.menu[118], 5 + num1, vector24, vector25, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
			{
				IngameOptions.leftHover = 5 + num1;
				if (flag)
				{
					IngameOptions.Close();
				}
			}
			if (IngameOptions.DrawLeftSide(sb, Lang.inter[35], 6 + num1, vector24, vector25, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
			{
				IngameOptions.leftHover = 6 + num1;
				if (flag)
				{
					IngameOptions.Close();
					Main.menuMode = 10;
					WorldGen.SaveAndQuit(null);
				}
			}
			if (num3 != IngameOptions.category)
			{
				for (int j = 0; j < (int)IngameOptions.rightScale.Length; j++)
				{
					IngameOptions.rightScale[j] = 0f;
				}
			}
			int num4 = 0;
			switch (IngameOptions.category)
			{
				case 0:
				{
					num4 = 10;
					single2 = 1f;
					single3 = 1.001f;
					single4 = 0.001f;
					break;
				}
				case 1:
				{
					num4 = 8;
					single2 = 1f;
					single3 = 1.001f;
					single4 = 0.001f;
					break;
				}
				case 2:
				{
					num4 = 14;
					single2 = 0.8f;
					single3 = 0.801f;
					single4 = 0.001f;
					break;
				}
				case 3:
				{
					num4 = 7;
					single2 = 0.8f;
					single3 = 0.801f;
					single4 = 0.001f;
					break;
				}
			}
			Vector2 x3 = new Vector2(vector23.X + vector22.X * 3f / 4f, vector23.Y + (float)(num * 5 / 2));
			Vector2 y3 = new Vector2(0f, vector22.Y - (float)(num * 3)) / (float)(num4 + 1);
			if (IngameOptions.category == 2)
			{
				y3.Y = y3.Y - 2f;
			}
			for (int k = 0; k < 15; k++)
			{
				if (IngameOptions.rightLock == k || IngameOptions.rightHover == k && IngameOptions.rightLock == -1)
				{
					IngameOptions.rightScale[k] = IngameOptions.rightScale[k] + single4;
				}
				else
				{
					IngameOptions.rightScale[k] = IngameOptions.rightScale[k] - single4;
				}
				if (IngameOptions.rightScale[k] < single2)
				{
					IngameOptions.rightScale[k] = single2;
				}
				if (IngameOptions.rightScale[k] > single3)
				{
					IngameOptions.rightScale[k] = single3;
				}
			}
			IngameOptions.inBar = false;
			IngameOptions.rightHover = -1;
			if (!Main.mouseLeft)
			{
				IngameOptions.rightLock = -1;
			}
			if (IngameOptions.rightLock == -1)
			{
				IngameOptions.notBar = false;
			}
			if (IngameOptions.category == 0)
			{
				int num5 = 0;
				x3.X = x3.X - 70f;
				object[] objArray = new object[] { Lang.menu[99], " ", Math.Round((double)(Main.musicVolume * 100f)), "%" };
				string str29 = string.Concat(objArray);
				float single5 = IngameOptions.rightScale[num5];
				float single6 = (IngameOptions.rightScale[num5] - single2) / (single3 - single2);
				Color color15 = new Color();
				if (IngameOptions.DrawRightSide(sb, str29, num5, x3, y3, single5, single6, color15))
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.noSound = true;
					IngameOptions.rightHover = num5;
				}
				IngameOptions.valuePosition.X = vector23.X + vector22.X - (float)(num / 2) - 20f;
				IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
				float single7 = IngameOptions.DrawValueBar(sb, 0.75f, Main.musicVolume);
				if ((IngameOptions.inBar || IngameOptions.rightLock == num5) && !IngameOptions.notBar)
				{
					IngameOptions.rightHover = num5;
					if (Main.mouseLeft && IngameOptions.rightLock == num5)
					{
						Main.musicVolume = single7;
					}
				}
				if ((float)Main.mouseX > vector23.X + vector22.X * 2f / 3f + (float)num && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num5;
				}
				num5++;
				object[] objArray1 = new object[] { Lang.menu[98], " ", Math.Round((double)(Main.soundVolume * 100f)), "%" };
				string str30 = string.Concat(objArray1);
				float single8 = IngameOptions.rightScale[num5];
				float single9 = (IngameOptions.rightScale[num5] - single2) / (single3 - single2);
				Color color16 = new Color();
				if (IngameOptions.DrawRightSide(sb, str30, num5, x3, y3, single8, single9, color16))
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num5;
				}
				IngameOptions.valuePosition.X = vector23.X + vector22.X - (float)(num / 2) - 20f;
				IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
				float single10 = IngameOptions.DrawValueBar(sb, 0.75f, Main.soundVolume);
				if ((IngameOptions.inBar || IngameOptions.rightLock == num5) && !IngameOptions.notBar)
				{
					IngameOptions.rightHover = num5;
					if (Main.mouseLeft && IngameOptions.rightLock == num5)
					{
						Main.soundVolume = single10;
						IngameOptions.noSound = true;
					}
				}
				if ((float)Main.mouseX > vector23.X + vector22.X * 2f / 3f + (float)num && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num5;
				}
				num5++;
				object[] objArray2 = new object[] { Lang.menu[119], " ", Math.Round((double)(Main.ambientVolume * 100f)), "%" };
				string str31 = string.Concat(objArray2);
				float single11 = IngameOptions.rightScale[num5];
				float single12 = (IngameOptions.rightScale[num5] - single2) / (single3 - single2);
				Color color17 = new Color();
				if (IngameOptions.DrawRightSide(sb, str31, num5, x3, y3, single11, single12, color17))
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num5;
				}
				IngameOptions.valuePosition.X = vector23.X + vector22.X - (float)(num / 2) - 20f;
				IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
				float single13 = IngameOptions.DrawValueBar(sb, 0.75f, Main.ambientVolume);
				if ((IngameOptions.inBar || IngameOptions.rightLock == num5) && !IngameOptions.notBar)
				{
					IngameOptions.rightHover = num5;
					if (Main.mouseLeft && IngameOptions.rightLock == num5)
					{
						Main.ambientVolume = single13;
						IngameOptions.noSound = true;
					}
				}
				if ((float)Main.mouseX > vector23.X + vector22.X * 2f / 3f + (float)num && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num5;
				}
				num5++;
				x3.X = x3.X + 70f;
				SpriteBatch spriteBatch = sb;
				str23 = (Main.autoSave ? Lang.menu[67] : Lang.menu[68]);
				float single14 = IngameOptions.rightScale[num5];
				float single15 = (IngameOptions.rightScale[num5] - single2) / (single3 - single2);
				Color color18 = new Color();
				if (IngameOptions.DrawRightSide(spriteBatch, str23, num5, x3, y3, single14, single15, color18))
				{
					IngameOptions.rightHover = num5;
					if (flag)
					{
						Main.autoSave = !Main.autoSave;
					}
				}
				num5++;
				SpriteBatch spriteBatch1 = sb;
				str24 = (Main.autoPause ? Lang.menu[69] : Lang.menu[70]);
				float single16 = IngameOptions.rightScale[num5];
				float single17 = (IngameOptions.rightScale[num5] - single2) / (single3 - single2);
				Color color19 = new Color();
				if (IngameOptions.DrawRightSide(spriteBatch1, str24, num5, x3, y3, single16, single17, color19))
				{
					IngameOptions.rightHover = num5;
					if (flag)
					{
						Main.autoPause = !Main.autoPause;
					}
				}
				num5++;
				SpriteBatch spriteBatch2 = sb;
				str25 = (Main.showItemText ? Lang.menu[71] : Lang.menu[72]);
				float single18 = IngameOptions.rightScale[num5];
				float single19 = (IngameOptions.rightScale[num5] - single2) / (single3 - single2);
				Color color20 = new Color();
				if (IngameOptions.DrawRightSide(spriteBatch2, str25, num5, x3, y3, single18, single19, color20))
				{
					IngameOptions.rightHover = num5;
					if (flag)
					{
						Main.showItemText = !Main.showItemText;
					}
				}
				num5++;
				SpriteBatch spriteBatch3 = sb;
				str26 = (Main.cSmartToggle ? Lang.menu[121] : Lang.menu[122]);
				float single20 = IngameOptions.rightScale[num5];
				float single21 = (IngameOptions.rightScale[num5] - single2) / (single3 - single2);
				Color color21 = new Color();
				if (IngameOptions.DrawRightSide(spriteBatch3, str26, num5, x3, y3, single20, single21, color21))
				{
					IngameOptions.rightHover = num5;
					if (flag)
					{
						Main.cSmartToggle = !Main.cSmartToggle;
					}
				}
				num5++;
				string str32 = string.Concat(Lang.menu[123], ": ", Lang.menu[124 + Main.invasionProgressMode]);
				float single22 = IngameOptions.rightScale[num5];
				float single23 = (IngameOptions.rightScale[num5] - single2) / (single3 - single2);
				Color color22 = new Color();
				if (IngameOptions.DrawRightSide(sb, str32, num5, x3, y3, single22, single23, color22))
				{
					IngameOptions.rightHover = num5;
					if (flag)
					{
						Main.invasionProgressMode = Main.invasionProgressMode + 1;
						if (Main.invasionProgressMode >= 3)
						{
							Main.invasionProgressMode = 0;
						}
					}
				}
				num5++;
				SpriteBatch spriteBatch4 = sb;
				str27 = (Main.placementPreview ? Lang.menu[128] : Lang.menu[129]);
				float single24 = IngameOptions.rightScale[num5];
				float single25 = (IngameOptions.rightScale[num5] - single2) / (single3 - single2);
				Color color23 = new Color();
				if (IngameOptions.DrawRightSide(spriteBatch4, str27, num5, x3, y3, single24, single25, color23))
				{
					IngameOptions.rightHover = num5;
					if (flag)
					{
						Main.placementPreview = !Main.placementPreview;
					}
				}
				num5++;
				SpriteBatch spriteBatch5 = sb;
				str28 = (ChildSafety.Disabled ? Lang.menu[132] : Lang.menu[133]);
				float single26 = IngameOptions.rightScale[num5];
				float single27 = (IngameOptions.rightScale[num5] - single2) / (single3 - single2);
				Color color24 = new Color();
				if (IngameOptions.DrawRightSide(spriteBatch5, str28, num5, x3, y3, single26, single27, color24))
				{
					IngameOptions.rightHover = num5;
					if (flag)
					{
						ChildSafety.Disabled = !ChildSafety.Disabled;
					}
				}
				num5++;
			}
			if (IngameOptions.category == 1)
			{
				int num6 = 0;
				SpriteBatch spriteBatch6 = sb;
				str20 = (Main.graphics.IsFullScreen ? Lang.menu[49] : Lang.menu[50]);
				float single28 = IngameOptions.rightScale[num6];
				float single29 = (IngameOptions.rightScale[num6] - single2) / (single3 - single2);
				Color color25 = new Color();
				if (IngameOptions.DrawRightSide(spriteBatch6, str20, num6, x3, y3, single28, single29, color25))
				{
					IngameOptions.rightHover = num6;
					if (flag)
					{
						Main.ToggleFullScreen();
					}
				}
				num6++;
				object[] pendingResolutionWidth = new object[] { Lang.menu[51], ": ", Main.PendingResolutionWidth, "x", Main.PendingResolutionHeight };
				string str33 = string.Concat(pendingResolutionWidth);
				float single30 = IngameOptions.rightScale[num6];
				float single31 = (IngameOptions.rightScale[num6] - single2) / (single3 - single2);
				Color color26 = new Color();
				if (IngameOptions.DrawRightSide(sb, str33, num6, x3, y3, single30, single31, color26))
				{
					IngameOptions.rightHover = num6;
					if (flag)
					{
						int num7 = 0;
						int num8 = 0;
						while (num8 < Main.numDisplayModes)
						{
							if (Main.displayWidth[num8] != Main.PendingResolutionWidth || Main.displayHeight[num8] != Main.PendingResolutionHeight)
							{
								num8++;
							}
							else
							{
								num7 = num8;
								break;
							}
						}
						num7++;
						if (num7 >= Main.numDisplayModes)
						{
							num7 = 0;
						}
						Main.PendingResolutionWidth = Main.displayWidth[num7];
						Main.PendingResolutionHeight = Main.displayHeight[num7];
					}
				}
				num6++;
				x3.X = x3.X - 70f;
				object[] objArray3 = new object[] { Lang.menu[52], ": ", Main.bgScroll, "%" };
				string str34 = string.Concat(objArray3);
				float single32 = IngameOptions.rightScale[num6];
				float single33 = (IngameOptions.rightScale[num6] - single2) / (single3 - single2);
				Color color27 = new Color();
				if (IngameOptions.DrawRightSide(sb, str34, num6, x3, y3, single32, single33, color27))
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.noSound = true;
					IngameOptions.rightHover = num6;
				}
				IngameOptions.valuePosition.X = vector23.X + vector22.X - (float)(num / 2) - 20f;
				IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
				float single34 = IngameOptions.DrawValueBar(sb, 0.75f, (float)Main.bgScroll / 100f);
				if ((IngameOptions.inBar || IngameOptions.rightLock == num6) && !IngameOptions.notBar)
				{
					IngameOptions.rightHover = num6;
					if (Main.mouseLeft && IngameOptions.rightLock == num6)
					{
						Main.bgScroll = (int)(single34 * 100f);
						Main.caveParallax = 1f - (float)Main.bgScroll / 500f;
					}
				}
				if ((float)Main.mouseX > vector23.X + vector22.X * 2f / 3f + (float)num && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num6;
				}
				num6++;
				x3.X = x3.X + 70f;
				SpriteBatch spriteBatch7 = sb;
				str21 = (Main.fixedTiming ? Lang.menu[53] : Lang.menu[54]);
				float single35 = IngameOptions.rightScale[num6];
				float single36 = (IngameOptions.rightScale[num6] - single2) / (single3 - single2);
				Color color28 = new Color();
				if (IngameOptions.DrawRightSide(spriteBatch7, str21, num6, x3, y3, single35, single36, color28))
				{
					IngameOptions.rightHover = num6;
					if (flag)
					{
						Main.fixedTiming = !Main.fixedTiming;
					}
				}
				num6++;
				string str35 = Lang.menu[55 + Lighting.lightMode];
				float single37 = IngameOptions.rightScale[num6];
				float single38 = (IngameOptions.rightScale[num6] - single2) / (single3 - single2);
				Color color29 = new Color();
				if (IngameOptions.DrawRightSide(sb, str35, num6, x3, y3, single37, single38, color29))
				{
					IngameOptions.rightHover = num6;
					if (flag)
					{
						Lighting.NextLightMode();
					}
				}
				num6++;
				SpriteBatch spriteBatch8 = sb;
				string str36 = string.Concat(Lang.menu[116], " ", (Lighting.LightingThreads > 0 ? string.Concat(Lighting.LightingThreads + 1) : Lang.menu[117]));
				float single39 = IngameOptions.rightScale[num6];
				float single40 = (IngameOptions.rightScale[num6] - single2) / (single3 - single2);
				Color color30 = new Color();
				if (IngameOptions.DrawRightSide(spriteBatch8, str36, num6, x3, y3, single39, single40, color30))
				{
					IngameOptions.rightHover = num6;
					if (flag)
					{
						Lighting.LightingThreads = Lighting.LightingThreads + 1;
						if (Lighting.LightingThreads > Environment.ProcessorCount - 1)
						{
							Lighting.LightingThreads = 0;
						}
					}
				}
				num6++;
				string str37 = Lang.menu[59 + Main.qaStyle];
				float single41 = IngameOptions.rightScale[num6];
				float single42 = (IngameOptions.rightScale[num6] - single2) / (single3 - single2);
				color13 = new Color();
				if (IngameOptions.DrawRightSide(sb, str37, num6, x3, y3, single41, single42, color13))
				{
					IngameOptions.rightHover = num6;
					if (flag)
					{
						Main.qaStyle = Main.qaStyle + 1;
						if (Main.qaStyle > 3)
						{
							Main.qaStyle = 0;
						}
					}
				}
				num6++;
				SpriteBatch spriteBatch9 = sb;
				str22 = (Main.owBack ? Lang.menu[100] : Lang.menu[101]);
				float single43 = IngameOptions.rightScale[num6];
				float single44 = (IngameOptions.rightScale[num6] - single2) / (single3 - single2);
				color13 = new Color();
				if (IngameOptions.DrawRightSide(spriteBatch9, str22, num6, x3, y3, single43, single44, color13))
				{
					IngameOptions.rightHover = num6;
					if (flag)
					{
						Main.owBack = !Main.owBack;
					}
				}
				num6++;
			}
			if (IngameOptions.category == 2)
			{
				int num9 = 0;
				int num10 = 0;
				x3.X = x3.X - 30f;
				num10 = 0;
				SpriteBatch spriteBatch10 = sb;
				string str38 = Lang.menu[74 + num10];
				int num11 = num9;
				Vector2 vector26 = x3;
				Vector2 vector27 = y3;
				float single45 = IngameOptions.rightScale[num9];
				float single46 = (IngameOptions.rightScale[num9] - single2) / (single3 - single2);
				if (Main.setKey == num10)
				{
					gold4 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					gold4 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch10, str38, num11, vector26, vector27, single45, single46, gold4))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch11 = sb;
				str6 = (Main.setKey == num10 ? "_" : Main.cUp);
				int num12 = num9;
				float single47 = single3;
				if (Main.setKey == num10)
				{
					white4 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num9)
				{
					white4 = Color.White;
				}
				else
				{
					color13 = new Color();
					white4 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch11, str6, num12, single47, white4))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				num9++;
				num10 = 1;
				SpriteBatch spriteBatch12 = sb;
				string str39 = Lang.menu[74 + num10];
				int num13 = num9;
				Vector2 vector28 = x3;
				Vector2 vector29 = y3;
				float single48 = IngameOptions.rightScale[num9];
				float single49 = (IngameOptions.rightScale[num9] - single2) / (single3 - single2);
				if (Main.setKey == num10)
				{
					color4 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					color4 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch12, str39, num13, vector28, vector29, single48, single49, color4))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch13 = sb;
				str7 = (Main.setKey == num10 ? "_" : Main.cDown);
				int num14 = num9;
				float single50 = single3;
				if (Main.setKey == num10)
				{
					gold5 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num9)
				{
					gold5 = Color.White;
				}
				else
				{
					color13 = new Color();
					gold5 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch13, str7, num14, single50, gold5))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				num9++;
				num10 = 2;
				SpriteBatch spriteBatch14 = sb;
				string str40 = Lang.menu[74 + num10];
				int num15 = num9;
				Vector2 vector210 = x3;
				Vector2 vector211 = y3;
				float single51 = IngameOptions.rightScale[num9];
				float single52 = (IngameOptions.rightScale[num9] - single2) / (single3 - single2);
				if (Main.setKey == num10)
				{
					color5 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					color5 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch14, str40, num15, vector210, vector211, single51, single52, color5))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch15 = sb;
				str8 = (Main.setKey == num10 ? "_" : Main.cLeft);
				int num16 = num9;
				float single53 = single3;
				if (Main.setKey == num10)
				{
					white5 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num9)
				{
					white5 = Color.White;
				}
				else
				{
					color13 = new Color();
					white5 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch15, str8, num16, single53, white5))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				num9++;
				num10 = 3;
				SpriteBatch spriteBatch16 = sb;
				string str41 = Lang.menu[74 + num10];
				int num17 = num9;
				Vector2 vector212 = x3;
				Vector2 vector213 = y3;
				float single54 = IngameOptions.rightScale[num9];
				float single55 = (IngameOptions.rightScale[num9] - single2) / (single3 - single2);
				if (Main.setKey == num10)
				{
					gold6 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					gold6 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch16, str41, num17, vector212, vector213, single54, single55, gold6))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch17 = sb;
				str9 = (Main.setKey == num10 ? "_" : Main.cRight);
				int num18 = num9;
				float single56 = single3;
				if (Main.setKey == num10)
				{
					white6 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num9)
				{
					white6 = Color.White;
				}
				else
				{
					color13 = new Color();
					white6 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch17, str9, num18, single56, white6))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				num9++;
				num10 = 4;
				SpriteBatch spriteBatch18 = sb;
				string str42 = Lang.menu[74 + num10];
				int num19 = num9;
				Vector2 vector214 = x3;
				Vector2 vector215 = y3;
				float single57 = IngameOptions.rightScale[num9];
				float single58 = (IngameOptions.rightScale[num9] - single2) / (single3 - single2);
				if (Main.setKey == num10)
				{
					color6 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					color6 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch18, str42, num19, vector214, vector215, single57, single58, color6))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch19 = sb;
				str10 = (Main.setKey == num10 ? "_" : Main.cJump);
				int num20 = num9;
				float single59 = single3;
				if (Main.setKey == num10)
				{
					gold7 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num9)
				{
					gold7 = Color.White;
				}
				else
				{
					color13 = new Color();
					gold7 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch19, str10, num20, single59, gold7))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				num9++;
				num10 = 5;
				SpriteBatch spriteBatch20 = sb;
				string str43 = Lang.menu[74 + num10];
				int num21 = num9;
				Vector2 vector216 = x3;
				Vector2 vector217 = y3;
				float single60 = IngameOptions.rightScale[num9];
				float single61 = (IngameOptions.rightScale[num9] - single2) / (single3 - single2);
				if (Main.setKey == num10)
				{
					color7 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					color7 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch20, str43, num21, vector216, vector217, single60, single61, color7))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch21 = sb;
				str11 = (Main.setKey == num10 ? "_" : Main.cThrowItem);
				int num22 = num9;
				float single62 = single3;
				if (Main.setKey == num10)
				{
					white7 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num9)
				{
					white7 = Color.White;
				}
				else
				{
					color13 = new Color();
					white7 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch21, str11, num22, single62, white7))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				num9++;
				num10 = 6;
				SpriteBatch spriteBatch22 = sb;
				string str44 = Lang.menu[74 + num10];
				int num23 = num9;
				Vector2 vector218 = x3;
				Vector2 vector219 = y3;
				float single63 = IngameOptions.rightScale[num9];
				float single64 = (IngameOptions.rightScale[num9] - single2) / (single3 - single2);
				if (Main.setKey == num10)
				{
					gold8 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					gold8 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch22, str44, num23, vector218, vector219, single63, single64, gold8))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch23 = sb;
				str12 = (Main.setKey == num10 ? "_" : Main.cInv);
				int num24 = num9;
				float single65 = single3;
				if (Main.setKey == num10)
				{
					white8 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num9)
				{
					white8 = Color.White;
				}
				else
				{
					color13 = new Color();
					white8 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch23, str12, num24, single65, white8))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				num9++;
				num10 = 7;
				SpriteBatch spriteBatch24 = sb;
				string str45 = Lang.menu[74 + num10];
				int num25 = num9;
				Vector2 vector220 = x3;
				Vector2 vector221 = y3;
				float single66 = IngameOptions.rightScale[num9];
				float single67 = (IngameOptions.rightScale[num9] - single2) / (single3 - single2);
				if (Main.setKey == num10)
				{
					color8 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					color8 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch24, str45, num25, vector220, vector221, single66, single67, color8))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch25 = sb;
				str13 = (Main.setKey == num10 ? "_" : Main.cHeal);
				int num26 = num9;
				float single68 = single3;
				if (Main.setKey == num10)
				{
					gold9 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num9)
				{
					gold9 = Color.White;
				}
				else
				{
					color13 = new Color();
					gold9 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch25, str13, num26, single68, gold9))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				num9++;
				num10 = 8;
				SpriteBatch spriteBatch26 = sb;
				string str46 = Lang.menu[74 + num10];
				int num27 = num9;
				Vector2 vector222 = x3;
				Vector2 vector223 = y3;
				float single69 = IngameOptions.rightScale[num9];
				float single70 = (IngameOptions.rightScale[num9] - single2) / (single3 - single2);
				if (Main.setKey == num10)
				{
					color9 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					color9 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch26, str46, num27, vector222, vector223, single69, single70, color9))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch27 = sb;
				str14 = (Main.setKey == num10 ? "_" : Main.cMana);
				int num28 = num9;
				float single71 = single3;
				if (Main.setKey == num10)
				{
					white9 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num9)
				{
					white9 = Color.White;
				}
				else
				{
					color13 = new Color();
					white9 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch27, str14, num28, single71, white9))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				num9++;
				num10 = 9;
				SpriteBatch spriteBatch28 = sb;
				string str47 = Lang.menu[74 + num10];
				int num29 = num9;
				Vector2 vector224 = x3;
				Vector2 vector225 = y3;
				float single72 = IngameOptions.rightScale[num9];
				float single73 = (IngameOptions.rightScale[num9] - single2) / (single3 - single2);
				if (Main.setKey == num10)
				{
					gold10 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					gold10 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch28, str47, num29, vector224, vector225, single72, single73, gold10))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch29 = sb;
				str15 = (Main.setKey == num10 ? "_" : Main.cBuff);
				int num30 = num9;
				float single74 = single3;
				if (Main.setKey == num10)
				{
					white10 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num9)
				{
					white10 = Color.White;
				}
				else
				{
					color13 = new Color();
					white10 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch29, str15, num30, single74, white10))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				num9++;
				num10 = 10;
				SpriteBatch spriteBatch30 = sb;
				string str48 = Lang.menu[74 + num10];
				int num31 = num9;
				Vector2 vector226 = x3;
				Vector2 vector227 = y3;
				float single75 = IngameOptions.rightScale[num9];
				float single76 = (IngameOptions.rightScale[num9] - single2) / (single3 - single2);
				if (Main.setKey == num10)
				{
					color10 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					color10 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch30, str48, num31, vector226, vector227, single75, single76, color10))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch31 = sb;
				str16 = (Main.setKey == num10 ? "_" : Main.cHook);
				int num32 = num9;
				float single77 = single3;
				if (Main.setKey == num10)
				{
					gold11 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num9)
				{
					gold11 = Color.White;
				}
				else
				{
					color13 = new Color();
					gold11 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch31, str16, num32, single77, gold11))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				num9++;
				num10 = 11;
				SpriteBatch spriteBatch32 = sb;
				string str49 = Lang.menu[74 + num10];
				int num33 = num9;
				Vector2 vector228 = x3;
				Vector2 vector229 = y3;
				float single78 = IngameOptions.rightScale[num9];
				float single79 = (IngameOptions.rightScale[num9] - single2) / (single3 - single2);
				if (Main.setKey == num10)
				{
					color11 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					color11 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch32, str49, num33, vector228, vector229, single78, single79, color11))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch33 = sb;
				str17 = (Main.setKey == num10 ? "_" : Main.cTorch);
				int num34 = num9;
				float single80 = single3;
				if (Main.setKey == num10)
				{
					white11 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num9)
				{
					white11 = Color.White;
				}
				else
				{
					color13 = new Color();
					white11 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch33, str17, num34, single80, white11))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				num9++;
				num10 = 12;
				SpriteBatch spriteBatch34 = sb;
				string str50 = Lang.menu[120];
				int num35 = num9;
				Vector2 vector230 = x3;
				Vector2 vector231 = y3;
				float single81 = IngameOptions.rightScale[num9];
				float single82 = (IngameOptions.rightScale[num9] - single2) / (single3 - single2);
				if (Main.setKey == num10)
				{
					gold12 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					gold12 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch34, str50, num35, vector230, vector231, single81, single82, gold12))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch35 = sb;
				str18 = (Main.setKey == num10 ? "_" : Main.cSmart);
				int num36 = num9;
				float single83 = single3;
				if (Main.setKey == num10)
				{
					white12 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num9)
				{
					white12 = Color.White;
				}
				else
				{
					color13 = new Color();
					white12 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch35, str18, num36, single83, white12))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				num9++;
				num10 = 13;
				SpriteBatch spriteBatch36 = sb;
				string str51 = Lang.menu[130];
				int num37 = num9;
				Vector2 vector232 = x3;
				Vector2 vector233 = y3;
				float single84 = IngameOptions.rightScale[num9];
				float single85 = (IngameOptions.rightScale[num9] - single2) / (single3 - single2);
				if (Main.setKey == num10)
				{
					color12 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					color12 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch36, str51, num37, vector232, vector233, single84, single85, color12))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch37 = sb;
				str19 = (Main.setKey == num10 ? "_" : Main.cMount);
				int num38 = num9;
				float single86 = single3;
				if (Main.setKey == num10)
				{
					gold13 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num9)
				{
					gold13 = Color.White;
				}
				else
				{
					color13 = new Color();
					gold13 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch37, str19, num38, single86, gold13))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.setKey = num10;
					}
				}
				num9++;
				x3.X = x3.X + 30f;
				string str52 = Lang.menu[86];
				float single87 = IngameOptions.rightScale[num9];
				float single88 = (IngameOptions.rightScale[num9] - single2) / (single3 - single2);
				color13 = new Color();
				if (IngameOptions.DrawRightSide(sb, str52, num9, x3, y3, single87, single88, color13))
				{
					IngameOptions.rightHover = num9;
					if (flag)
					{
						Main.ResetKeyBindings();
						Main.setKey = -1;
					}
				}
				num9++;
				if (Main.setKey >= 0)
				{
					Main.blockInput = true;
					Keys[] pressedKeys = Main.keyState.GetPressedKeys();
					if ((int)pressedKeys.Length > 0)
					{
						string str53 = string.Concat(pressedKeys[0]);
						if (str53 != "None")
						{
							if (Main.setKey == 0)
							{
								Main.cUp = str53;
							}
							if (Main.setKey == 1)
							{
								Main.cDown = str53;
							}
							if (Main.setKey == 2)
							{
								Main.cLeft = str53;
							}
							if (Main.setKey == 3)
							{
								Main.cRight = str53;
							}
							if (Main.setKey == 4)
							{
								Main.cJump = str53;
							}
							if (Main.setKey == 5)
							{
								Main.cThrowItem = str53;
							}
							if (Main.setKey == 6)
							{
								Main.cInv = str53;
							}
							if (Main.setKey == 7)
							{
								Main.cHeal = str53;
							}
							if (Main.setKey == 8)
							{
								Main.cMana = str53;
							}
							if (Main.setKey == 9)
							{
								Main.cBuff = str53;
							}
							if (Main.setKey == 10)
							{
								Main.cHook = str53;
							}
							if (Main.setKey == 11)
							{
								Main.cTorch = str53;
							}
							if (Main.setKey == 12)
							{
								Main.cSmart = str53;
							}
							if (Main.setKey == 13)
							{
								Main.cMount = str53;
							}
							Main.blockKey = pressedKeys[0];
							Main.blockInput = false;
							Main.setKey = -1;
						}
					}
				}
			}
			if (IngameOptions.category == 3)
			{
				int num39 = 0;
				int num40 = 0;
				x3.X = x3.X - 30f;
				num40 = 0;
				SpriteBatch spriteBatch38 = sb;
				string str54 = Lang.menu[106 + num40];
				int num41 = num39;
				Vector2 vector234 = x3;
				Vector2 vector235 = y3;
				float single89 = IngameOptions.rightScale[num39];
				float single90 = (IngameOptions.rightScale[num39] - single2) / (single3 - single2);
				if (Main.setKey == num40)
				{
					gold = Color.Gold;
				}
				else
				{
					color13 = new Color();
					gold = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch38, str54, num41, vector234, vector235, single89, single90, gold))
				{
					IngameOptions.rightHover = num39;
					if (flag)
					{
						Main.setKey = num40;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch39 = sb;
				str = (Main.setKey == num40 ? "_" : Main.cMapStyle);
				int num42 = num39;
				float single91 = single3;
				if (Main.setKey == num40)
				{
					white = Color.Gold;
				}
				else if (IngameOptions.rightHover == num39)
				{
					white = Color.White;
				}
				else
				{
					color13 = new Color();
					white = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch39, str, num42, single91, white))
				{
					IngameOptions.rightHover = num39;
					if (flag)
					{
						Main.setKey = num40;
					}
				}
				num39++;
				num40 = 1;
				SpriteBatch spriteBatch40 = sb;
				string str55 = Lang.menu[106 + num40];
				int num43 = num39;
				Vector2 vector236 = x3;
				Vector2 vector237 = y3;
				float single92 = IngameOptions.rightScale[num39];
				float single93 = (IngameOptions.rightScale[num39] - single2) / (single3 - single2);
				if (Main.setKey == num40)
				{
					color = Color.Gold;
				}
				else
				{
					color13 = new Color();
					color = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch40, str55, num43, vector236, vector237, single92, single93, color))
				{
					IngameOptions.rightHover = num39;
					if (flag)
					{
						Main.setKey = num40;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch41 = sb;
				str1 = (Main.setKey == num40 ? "_" : Main.cMapFull);
				int num44 = num39;
				float single94 = single3;
				if (Main.setKey == num40)
				{
					gold1 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num39)
				{
					gold1 = Color.White;
				}
				else
				{
					color13 = new Color();
					gold1 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch41, str1, num44, single94, gold1))
				{
					IngameOptions.rightHover = num39;
					if (flag)
					{
						Main.setKey = num40;
					}
				}
				num39++;
				num40 = 2;
				SpriteBatch spriteBatch42 = sb;
				string str56 = Lang.menu[106 + num40];
				int num45 = num39;
				Vector2 vector238 = x3;
				Vector2 vector239 = y3;
				float single95 = IngameOptions.rightScale[num39];
				float single96 = (IngameOptions.rightScale[num39] - single2) / (single3 - single2);
				if (Main.setKey == num40)
				{
					color1 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					color1 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch42, str56, num45, vector238, vector239, single95, single96, color1))
				{
					IngameOptions.rightHover = num39;
					if (flag)
					{
						Main.setKey = num40;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch43 = sb;
				str2 = (Main.setKey == num40 ? "_" : Main.cMapZoomIn);
				int num46 = num39;
				float single97 = single3;
				if (Main.setKey == num40)
				{
					white1 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num39)
				{
					white1 = Color.White;
				}
				else
				{
					color13 = new Color();
					white1 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch43, str2, num46, single97, white1))
				{
					IngameOptions.rightHover = num39;
					if (flag)
					{
						Main.setKey = num40;
					}
				}
				num39++;
				num40 = 3;
				SpriteBatch spriteBatch44 = sb;
				string str57 = Lang.menu[106 + num40];
				int num47 = num39;
				Vector2 vector240 = x3;
				Vector2 vector241 = y3;
				float single98 = IngameOptions.rightScale[num39];
				float single99 = (IngameOptions.rightScale[num39] - single2) / (single3 - single2);
				if (Main.setKey == num40)
				{
					gold2 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					gold2 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch44, str57, num47, vector240, vector241, single98, single99, gold2))
				{
					IngameOptions.rightHover = num39;
					if (flag)
					{
						Main.setKey = num40;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch45 = sb;
				str3 = (Main.setKey == num40 ? "_" : Main.cMapZoomOut);
				int num48 = num39;
				float single100 = single3;
				if (Main.setKey == num40)
				{
					white2 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num39)
				{
					white2 = Color.White;
				}
				else
				{
					color13 = new Color();
					white2 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch45, str3, num48, single100, white2))
				{
					IngameOptions.rightHover = num39;
					if (flag)
					{
						Main.setKey = num40;
					}
				}
				num39++;
				num40 = 4;
				SpriteBatch spriteBatch46 = sb;
				string str58 = Lang.menu[106 + num40];
				int num49 = num39;
				Vector2 vector242 = x3;
				Vector2 vector243 = y3;
				float single101 = IngameOptions.rightScale[num39];
				float single102 = (IngameOptions.rightScale[num39] - single2) / (single3 - single2);
				if (Main.setKey == num40)
				{
					color2 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					color2 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch46, str58, num49, vector242, vector243, single101, single102, color2))
				{
					IngameOptions.rightHover = num39;
					if (flag)
					{
						Main.setKey = num40;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch47 = sb;
				str4 = (Main.setKey == num40 ? "_" : Main.cMapAlphaUp);
				int num50 = num39;
				float single103 = single3;
				if (Main.setKey == num40)
				{
					gold3 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num39)
				{
					gold3 = Color.White;
				}
				else
				{
					color13 = new Color();
					gold3 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch47, str4, num50, single103, gold3))
				{
					IngameOptions.rightHover = num39;
					if (flag)
					{
						Main.setKey = num40;
					}
				}
				num39++;
				num40 = 5;
				SpriteBatch spriteBatch48 = sb;
				string str59 = Lang.menu[106 + num40];
				int num51 = num39;
				Vector2 vector244 = x3;
				Vector2 vector245 = y3;
				float single104 = IngameOptions.rightScale[num39];
				float single105 = (IngameOptions.rightScale[num39] - single2) / (single3 - single2);
				if (Main.setKey == num40)
				{
					color3 = Color.Gold;
				}
				else
				{
					color13 = new Color();
					color3 = color13;
				}
				if (IngameOptions.DrawRightSide(spriteBatch48, str59, num51, vector244, vector245, single104, single105, color3))
				{
					IngameOptions.rightHover = num39;
					if (flag)
					{
						Main.setKey = num40;
					}
				}
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + 10f;
				SpriteBatch spriteBatch49 = sb;
				str5 = (Main.setKey == num40 ? "_" : Main.cMapAlphaDown);
				int num52 = num39;
				float single106 = single3;
				if (Main.setKey == num40)
				{
					white3 = Color.Gold;
				}
				else if (IngameOptions.rightHover == num39)
				{
					white3 = Color.White;
				}
				else
				{
					color13 = new Color();
					white3 = color13;
				}
				if (IngameOptions.DrawValue(spriteBatch49, str5, num52, single106, white3))
				{
					IngameOptions.rightHover = num39;
					if (flag)
					{
						Main.setKey = num40;
					}
				}
				num39++;
				x3.X = x3.X + 30f;
				string str60 = Lang.menu[86];
				float single107 = IngameOptions.rightScale[num39];
				float single108 = (IngameOptions.rightScale[num39] - single2) / (single3 - single2);
				color13 = new Color();
				if (IngameOptions.DrawRightSide(sb, str60, num39, x3, y3, single107, single108, color13))
				{
					IngameOptions.rightHover = num39;
					if (flag)
					{
						Main.cMapStyle = "Tab";
						Main.cMapFull = "M";
						Main.cMapZoomIn = "Add";
						Main.cMapZoomOut = "Subtract";
						Main.cMapAlphaUp = "PageUp";
						Main.cMapAlphaDown = "PageDown";
						Main.setKey = -1;
					}
				}
				num39++;
				if (Main.setKey >= 0)
				{
					Main.blockInput = true;
					Keys[] keysArray = Main.keyState.GetPressedKeys();
					if ((int)keysArray.Length > 0)
					{
						string str61 = string.Concat(keysArray[0]);
						if (str61 != "None")
						{
							if (Main.setKey == 0)
							{
								Main.cMapStyle = str61;
							}
							if (Main.setKey == 1)
							{
								Main.cMapFull = str61;
							}
							if (Main.setKey == 2)
							{
								Main.cMapZoomIn = str61;
							}
							if (Main.setKey == 3)
							{
								Main.cMapZoomOut = str61;
							}
							if (Main.setKey == 4)
							{
								Main.cMapAlphaUp = str61;
							}
							if (Main.setKey == 5)
							{
								Main.cMapAlphaDown = str61;
							}
							Main.setKey = -1;
							Main.blockKey = keysArray[0];
							Main.blockInput = false;
						}
					}
				}
			}
			if (IngameOptions.rightHover != -1 && IngameOptions.rightLock == -1)
			{
				IngameOptions.rightLock = IngameOptions.rightHover;
			}
			Main.mouseText = false;
			Main.instance.GUIBarsDraw();
			Main.instance.DrawMouseOver();
			Texture2D texture2D = Main.cursorTextures[0];
			Vector2 vector246 = new Vector2((float)(Main.mouseX + 1), (float)(Main.mouseY + 1));
			Rectangle? nullable = null;
			Color color31 = new Color((int)((float)Main.cursorColor.R * 0.2f), (int)((float)Main.cursorColor.G * 0.2f), (int)((float)Main.cursorColor.B * 0.2f), (int)((float)Main.cursorColor.A * 0.5f));
			Vector2 vector247 = new Vector2();
			sb.Draw(texture2D, vector246, nullable, color31, 0f, vector247, Main.cursorScale * 1.1f, SpriteEffects.None, 0f);
			Texture2D texture2D1 = Main.cursorTextures[0];
			Vector2 vector248 = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			nullable = null;
			Color color32 = Main.cursorColor;
			vector247 = new Vector2();
			sb.Draw(texture2D1, vector248, nullable, color32, 0f, vector247, Main.cursorScale, SpriteEffects.None, 0f);
		}

		public static bool DrawLeftSide(SpriteBatch sb, string txt, int i, Vector2 anchor, Vector2 offset, float[] scales, float minscale = 0.7f, float maxscale = 0.8f, float scalespeed = 0.01f)
		{
			bool flag = i == IngameOptions.category;
			Color gold = Color.Lerp(Color.Gray, Color.White, (scales[i] - minscale) / (maxscale - minscale));
			if (flag)
			{
				gold = Color.Gold;
			}
			Vector2 vector2 = Utils.DrawBorderStringBig(sb, txt, anchor + (offset * (float)(1 + i)), gold, scales[i], 0.5f, 0.5f, -1);
			if ((new Rectangle((int)anchor.X - (int)vector2.X / 2, (int)anchor.Y + (int)(offset.Y * (float)(1 + i)) - (int)vector2.Y / 2, (int)vector2.X, (int)vector2.Y)).Contains(new Point(Main.mouseX, Main.mouseY)))
			{
				return true;
			}
			return false;
		}

		public static bool DrawRightSide(SpriteBatch sb, string txt, int i, Vector2 anchor, Vector2 offset, float scale, float colorScale, Color over = new Color())
		{
			Color color = Color.Lerp(Color.Gray, Color.White, colorScale);
			if (over != new Color())
			{
				color = over;
			}
			Vector2 vector2 = Utils.DrawBorderString(sb, txt, anchor + (offset * (float)(1 + i)), color, scale, 0.5f, 0.5f, -1);
			IngameOptions.valuePosition = (anchor + (offset * (float)(1 + i))) + (vector2 * new Vector2(0.5f, 0f));
			if ((new Rectangle((int)anchor.X - (int)vector2.X / 2, (int)anchor.Y + (int)(offset.Y * (float)(1 + i)) - (int)vector2.Y / 2, (int)vector2.X, (int)vector2.Y)).Contains(new Point(Main.mouseX, Main.mouseY)))
			{
				return true;
			}
			return false;
		}

		public static bool DrawValue(SpriteBatch sb, string txt, int i, float scale, Color over = new Color())
		{
			Color gray = Color.Gray;
			Vector2 vector2 = Main.fontMouseText.MeasureString(txt) * scale;
			Rectangle rectangle = new Rectangle((int)IngameOptions.valuePosition.X, (int)IngameOptions.valuePosition.Y - (int)vector2.Y / 2, (int)vector2.X, (int)vector2.Y);
			bool flag = rectangle.Contains(new Point(Main.mouseX, Main.mouseY));
			if (flag)
			{
				gray = Color.White;
			}
			if (over != new Color())
			{
				gray = over;
			}
			Utils.DrawBorderString(sb, txt, IngameOptions.valuePosition, gray, scale, 0f, 0.5f, -1);
			IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + vector2.X;
			if (flag)
			{
				return true;
			}
			return false;
		}

		public static float DrawValueBar(SpriteBatch sb, float scale, float perc)
		{
			Texture2D texture2D = Main.colorBarTexture;
			Vector2 vector2 = new Vector2((float)texture2D.Width, (float)texture2D.Height) * scale;
			IngameOptions.valuePosition.X = IngameOptions.valuePosition.X - (float)((int)vector2.X);
			Rectangle rectangle = new Rectangle((int)IngameOptions.valuePosition.X, (int)IngameOptions.valuePosition.Y - (int)vector2.Y / 2, (int)vector2.X, (int)vector2.Y);
			sb.Draw(texture2D, rectangle, Color.White);
			int num = 167;
			float x = (float)rectangle.X + 5f * scale;
			float y = (float)rectangle.Y + 4f * scale;
			for (float i = 0f; i < (float)num; i = i + 1f)
			{
				float single = (float)i / (float)num;
				Rectangle? nullable = null;
				sb.Draw(Main.colorBlipTexture, new Vector2(x + i * scale, y), nullable, Color.Lerp(Color.Black, Color.White, single), 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
			}
			Rectangle? nullable1 = null;
			sb.Draw(Main.colorSliderTexture, new Vector2(x + 167f * scale * perc, y + 4f * scale), nullable1, Color.White, 0f, new Vector2(0.5f * (float)Main.colorSliderTexture.Width, 0.5f * (float)Main.colorSliderTexture.Height), scale, SpriteEffects.None, 0f);
			rectangle.X = (int)x;
			rectangle.Y = (int)y;
			bool flag = rectangle.Contains(new Point(Main.mouseX, Main.mouseY));
			if (Main.mouseX >= rectangle.X && Main.mouseX <= rectangle.X + rectangle.Width)
			{
				IngameOptions.inBar = flag;
				return (float)(Main.mouseX - rectangle.X) / (float)rectangle.Width;
			}
			IngameOptions.inBar = false;
			if (rectangle.X >= Main.mouseX)
			{
				return 0f;
			}
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
			Main.PlaySound(10, -1, -1, 1);
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