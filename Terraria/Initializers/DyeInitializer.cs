using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.Graphics.Shaders;

namespace Terraria.Initializers
{
	internal static class DyeInitializer
	{
		private static void FixRecipes()
		{
			for (int i = 0; i < Recipe.maxRecipes; i++)
			{
				Main.recipe[i].createItem.dye = (byte)GameShaders.Armor.GetShaderIdFromItemId(Main.recipe[i].createItem.type);
				Main.recipe[i].createItem.hairDye = GameShaders.Hair.GetShaderIdFromItemId(Main.recipe[i].createItem.type);
			}
		}

		public static void Load()
		{
			DyeInitializer.LoadArmorDyes();
			DyeInitializer.LoadHairDyes();
			DyeInitializer.LoadMisc();
		}

		private static void LoadArmorDyes()
		{
			Effect effect = Main.pixelShader;
			DyeInitializer.LoadBasicColorDyes();
			GameShaders.Armor.BindShader<ArmorShaderData>(1050, new ArmorShaderData(effect, "ArmorBrightnessColored")).UseColor(0.6f, 0.6f, 0.6f);
			GameShaders.Armor.BindShader<ArmorShaderData>(1037, new ArmorShaderData(effect, "ArmorBrightnessColored")).UseColor(1f, 1f, 1f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3558, new ArmorShaderData(effect, "ArmorBrightnessColored")).UseColor(1.5f, 1.5f, 1.5f);
			GameShaders.Armor.BindShader<ArmorShaderData>(2871, new ArmorShaderData(effect, "ArmorBrightnessColored")).UseColor(0.05f, 0.05f, 0.05f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3559, new ArmorShaderData(effect, "ArmorColoredAndBlack")).UseColor(1f, 1f, 1f).UseSaturation(1.2f);
			GameShaders.Armor.BindShader<ArmorShaderData>(1031, new ArmorShaderData(effect, "ArmorColoredGradient")).UseColor(1f, 0f, 0f).UseSecondaryColor(1f, 1f, 0f).UseSaturation(1.2f);
			GameShaders.Armor.BindShader<ArmorShaderData>(1032, new ArmorShaderData(effect, "ArmorColoredAndBlackGradient")).UseColor(1f, 0f, 0f).UseSecondaryColor(1f, 1f, 0f).UseSaturation(1.5f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3550, new ArmorShaderData(effect, "ArmorColoredAndSilverTrimGradient")).UseColor(1f, 0f, 0f).UseSecondaryColor(1f, 1f, 0f).UseSaturation(1.5f);
			GameShaders.Armor.BindShader<ArmorShaderData>(1063, new ArmorShaderData(effect, "ArmorBrightnessGradient")).UseColor(1f, 0f, 0f).UseSecondaryColor(1f, 1f, 0f);
			GameShaders.Armor.BindShader<ArmorShaderData>(1035, new ArmorShaderData(effect, "ArmorColoredGradient")).UseColor(0f, 0f, 1f).UseSecondaryColor(0f, 1f, 1f).UseSaturation(1.2f);
			GameShaders.Armor.BindShader<ArmorShaderData>(1036, new ArmorShaderData(effect, "ArmorColoredAndBlackGradient")).UseColor(0f, 0f, 1f).UseSecondaryColor(0f, 1f, 1f).UseSaturation(1.5f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3552, new ArmorShaderData(effect, "ArmorColoredAndSilverTrimGradient")).UseColor(0f, 0f, 1f).UseSecondaryColor(0f, 1f, 1f).UseSaturation(1.5f);
			GameShaders.Armor.BindShader<ArmorShaderData>(1065, new ArmorShaderData(effect, "ArmorBrightnessGradient")).UseColor(0f, 0f, 1f).UseSecondaryColor(0f, 1f, 1f);
			GameShaders.Armor.BindShader<ArmorShaderData>(1033, new ArmorShaderData(effect, "ArmorColoredGradient")).UseColor(0f, 1f, 0f).UseSecondaryColor(1f, 1f, 0f).UseSaturation(1.2f);
			GameShaders.Armor.BindShader<ArmorShaderData>(1034, new ArmorShaderData(effect, "ArmorColoredAndBlackGradient")).UseColor(0f, 1f, 0f).UseSecondaryColor(1f, 1f, 0f).UseSaturation(1.5f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3551, new ArmorShaderData(effect, "ArmorColoredAndSilverTrimGradient")).UseColor(0f, 1f, 0f).UseSecondaryColor(1f, 1f, 0f).UseSaturation(1.5f);
			GameShaders.Armor.BindShader<ArmorShaderData>(1064, new ArmorShaderData(effect, "ArmorBrightnessGradient")).UseColor(0f, 1f, 0f).UseSecondaryColor(1f, 1f, 0f);
			GameShaders.Armor.BindShader<ArmorShaderData>(1068, new ArmorShaderData(effect, "ArmorColoredGradient")).UseColor(0.5f, 1f, 0f).UseSecondaryColor(1f, 0.5f, 0f).UseSaturation(1.5f);
			GameShaders.Armor.BindShader<ArmorShaderData>(1069, new ArmorShaderData(effect, "ArmorColoredGradient")).UseColor(0f, 1f, 0.5f).UseSecondaryColor(0f, 0.5f, 1f).UseSaturation(1.5f);
			GameShaders.Armor.BindShader<ArmorShaderData>(1070, new ArmorShaderData(effect, "ArmorColoredGradient")).UseColor(1f, 0f, 0.5f).UseSecondaryColor(0.5f, 0f, 1f).UseSaturation(1.5f);
			GameShaders.Armor.BindShader<ArmorShaderData>(1066, new ArmorShaderData(effect, "ArmorColoredRainbow"));
			GameShaders.Armor.BindShader<ArmorShaderData>(1067, new ArmorShaderData(effect, "ArmorBrightnessRainbow"));
			GameShaders.Armor.BindShader<ArmorShaderData>(3556, new ArmorShaderData(effect, "ArmorMidnightRainbow"));
			GameShaders.Armor.BindShader<ArmorShaderData>(2869, new ArmorShaderData(effect, "ArmorLivingFlame"));
			GameShaders.Armor.BindShader<ArmorShaderData>(2870, new ArmorShaderData(effect, "ArmorLivingRainbow"));
			GameShaders.Armor.BindShader<ArmorShaderData>(2873, new ArmorShaderData(effect, "ArmorLivingOcean"));
			GameShaders.Armor.BindShader<ReflectiveArmorShaderData>(3026, new ReflectiveArmorShaderData(effect, "ArmorReflectiveColor")).UseColor(1f, 1f, 1f);
			GameShaders.Armor.BindShader<ReflectiveArmorShaderData>(3027, new ReflectiveArmorShaderData(effect, "ArmorReflectiveColor")).UseColor(1.5f, 1.2f, 0.5f);
			GameShaders.Armor.BindShader<ReflectiveArmorShaderData>(3553, new ReflectiveArmorShaderData(effect, "ArmorReflectiveColor")).UseColor(1.35f, 0.7f, 0.4f);
			GameShaders.Armor.BindShader<ReflectiveArmorShaderData>(3554, new ReflectiveArmorShaderData(effect, "ArmorReflectiveColor")).UseColor(0.25f, 0f, 0.7f);
			GameShaders.Armor.BindShader<ReflectiveArmorShaderData>(3555, new ReflectiveArmorShaderData(effect, "ArmorReflectiveColor")).UseColor(0.4f, 0.4f, 0.4f);
			GameShaders.Armor.BindShader<ReflectiveArmorShaderData>(3190, new ReflectiveArmorShaderData(effect, "ArmorReflective"));
			GameShaders.Armor.BindShader<TeamArmorShaderData>(1969, new TeamArmorShaderData(effect, "ArmorColored"));
			GameShaders.Armor.BindShader<ArmorShaderData>(2864, new ArmorShaderData(effect, "ArmorMartian")).UseColor(0f, 2f, 3f);
			GameShaders.Armor.BindShader<ArmorShaderData>(2872, new ArmorShaderData(effect, "ArmorInvert"));
			GameShaders.Armor.BindShader<ArmorShaderData>(2878, new ArmorShaderData(effect, "ArmorWisp")).UseColor(0.7f, 1f, 0.9f).UseSecondaryColor(0.35f, 0.85f, 0.8f);
			GameShaders.Armor.BindShader<ArmorShaderData>(2879, new ArmorShaderData(effect, "ArmorWisp")).UseColor(1f, 1.2f, 0f).UseSecondaryColor(1f, 0.6f, 0.3f);
			GameShaders.Armor.BindShader<ArmorShaderData>(2885, new ArmorShaderData(effect, "ArmorWisp")).UseColor(1.2f, 0.8f, 0f).UseSecondaryColor(0.8f, 0.2f, 0f);
			GameShaders.Armor.BindShader<ArmorShaderData>(2884, new ArmorShaderData(effect, "ArmorWisp")).UseColor(1f, 0f, 1f).UseSecondaryColor(1f, 0.3f, 0.6f);
			GameShaders.Armor.BindShader<ArmorShaderData>(2883, new ArmorShaderData(effect, "ArmorHighContrastGlow")).UseColor(0f, 1f, 0f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3025, new ArmorShaderData(effect, "ArmorFlow")).UseColor(1f, 0.5f, 1f).UseSecondaryColor(0.6f, 0.1f, 1f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3039, new ArmorShaderData(effect, "ArmorTwilight")).UseImage("Images/Misc/noise").UseColor(0.5f, 0.1f, 1f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3040, new ArmorShaderData(effect, "ArmorAcid")).UseColor(0.5f, 1f, 0.3f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3041, new ArmorShaderData(effect, "ArmorMushroom")).UseColor(0.05f, 0.2f, 1f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3042, new ArmorShaderData(effect, "ArmorPhase")).UseImage("Images/Misc/noise").UseColor(0.4f, 0.2f, 1.5f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3560, new ArmorShaderData(effect, "ArmorAcid")).UseColor(0.9f, 0.2f, 0.2f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3561, new ArmorShaderData(effect, "ArmorGel")).UseImage("Images/Misc/noise").UseColor(0.4f, 0.7f, 1.4f).UseSecondaryColor(0f, 0f, 0.1f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3562, new ArmorShaderData(effect, "ArmorGel")).UseImage("Images/Misc/noise").UseColor(1.4f, 0.75f, 1f).UseSecondaryColor(0.45f, 0.1f, 0.3f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3024, new ArmorShaderData(effect, "ArmorGel")).UseImage("Images/Misc/noise").UseColor(-0.5f, -1f, 0f).UseSecondaryColor(1.5f, 1f, 2.2f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3534, new ArmorShaderData(effect, "ArmorMirage"));
			GameShaders.Armor.BindShader<ArmorShaderData>(3028, new ArmorShaderData(effect, "ArmorAcid")).UseColor(0.5f, 0.7f, 1.5f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3557, new ArmorShaderData(effect, "ArmorPolarized"));
			GameShaders.Armor.BindShader<ArmorShaderData>(3038, new ArmorShaderData(effect, "ArmorHades")).UseColor(0.5f, 0.7f, 1.3f).UseSecondaryColor(0.5f, 0.7f, 1.3f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3600, new ArmorShaderData(effect, "ArmorHades")).UseColor(0.7f, 0.4f, 1.5f).UseSecondaryColor(0.7f, 0.4f, 1.5f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3597, new ArmorShaderData(effect, "ArmorHades")).UseColor(1.5f, 0.6f, 0.4f).UseSecondaryColor(1.5f, 0.6f, 0.4f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3598, new ArmorShaderData(effect, "ArmorHades")).UseColor(0.1f, 0.1f, 0.1f).UseSecondaryColor(0.4f, 0.05f, 0.025f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3599, new ArmorShaderData(effect, "ArmorLoki")).UseColor(0.1f, 0.1f, 0.1f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3533, new ArmorShaderData(effect, "ArmorShiftingSands")).UseImage("Images/Misc/noise").UseColor(1.1f, 1f, 0.5f).UseSecondaryColor(0.7f, 0.5f, 0.3f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3535, new ArmorShaderData(effect, "ArmorShiftingPearlsands")).UseImage("Images/Misc/noise").UseColor(1.1f, 0.8f, 0.9f).UseSecondaryColor(0.35f, 0.25f, 0.44f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3526, new ArmorShaderData(effect, "ArmorSolar")).UseColor(1f, 0f, 0f).UseSecondaryColor(1f, 1f, 0f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3527, new ArmorShaderData(effect, "ArmorNebula")).UseImage("Images/Misc/noise").UseColor(1f, 0f, 1f).UseSecondaryColor(1f, 1f, 1f).UseSaturation(1f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3528, new ArmorShaderData(effect, "ArmorVortex")).UseImage("Images/Misc/noise").UseColor(0.1f, 0.5f, 0.35f).UseSecondaryColor(1f, 1f, 1f).UseSaturation(1f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3529, new ArmorShaderData(effect, "ArmorStardust")).UseImage("Images/Misc/noise").UseColor(0.4f, 0.6f, 1f).UseSecondaryColor(1f, 1f, 1f).UseSaturation(1f);
			GameShaders.Armor.BindShader<ArmorShaderData>(3530, new ArmorShaderData(effect, "ArmorVoid"));
			DyeInitializer.FixRecipes();
		}

		private static void LoadBasicColorDye(int baseDyeItem, int blackDyeItem, int brightDyeItem, int silverDyeItem, float r, float g, float b, float saturation = 1f, int oldShader = 1)
		{
			Effect effect = Main.pixelShader;
			GameShaders.Armor.BindShader<ArmorShaderData>(baseDyeItem, new ArmorShaderData(effect, "ArmorColored")).UseColor(r, g, b).UseSaturation(saturation);
			GameShaders.Armor.BindShader<ArmorShaderData>(blackDyeItem, new ArmorShaderData(effect, "ArmorColoredAndBlack")).UseColor(r, g, b).UseSaturation(saturation);
			GameShaders.Armor.BindShader<ArmorShaderData>(brightDyeItem, new ArmorShaderData(effect, "ArmorColored")).UseColor(r * 0.5f + 0.5f, g * 0.5f + 0.5f, b * 0.5f + 0.5f).UseSaturation(saturation);
			GameShaders.Armor.BindShader<ArmorShaderData>(silverDyeItem, new ArmorShaderData(effect, "ArmorColoredAndSilverTrim")).UseColor(r, g, b).UseSaturation(saturation);
		}

		private static void LoadBasicColorDye(int baseDyeItem, float r, float g, float b, float saturation = 1f, int oldShader = 1)
		{
			DyeInitializer.LoadBasicColorDye(baseDyeItem, baseDyeItem + 12, baseDyeItem + 31, baseDyeItem + 44, r, g, b, saturation, oldShader);
		}

		private static void LoadBasicColorDyes()
		{
			DyeInitializer.LoadBasicColorDye(1007, 1f, 0f, 0f, 1.2f, 1);
			DyeInitializer.LoadBasicColorDye(1008, 1f, 0.5f, 0f, 1.2f, 2);
			DyeInitializer.LoadBasicColorDye(1009, 1f, 1f, 0f, 1.2f, 3);
			DyeInitializer.LoadBasicColorDye(1010, 0.5f, 1f, 0f, 1.2f, 4);
			DyeInitializer.LoadBasicColorDye(1011, 0f, 1f, 0f, 1.2f, 5);
			DyeInitializer.LoadBasicColorDye(1012, 0f, 1f, 0.5f, 1.2f, 6);
			DyeInitializer.LoadBasicColorDye(1013, 0f, 1f, 1f, 1.2f, 7);
			DyeInitializer.LoadBasicColorDye(1014, 0.2f, 0.5f, 1f, 1.2f, 8);
			DyeInitializer.LoadBasicColorDye(1015, 0f, 0f, 1f, 1.2f, 9);
			DyeInitializer.LoadBasicColorDye(1016, 0.5f, 0f, 1f, 1.2f, 10);
			DyeInitializer.LoadBasicColorDye(1017, 1f, 0f, 1f, 1.2f, 11);
			DyeInitializer.LoadBasicColorDye(1018, 1f, 0.1f, 0.5f, 1.3f, 12);
			DyeInitializer.LoadBasicColorDye(2874, 2875, 2876, 2877, 0.4f, 0.2f, 0f, 1f, 1);
		}

		private static void LoadHairDyes()
		{
			Effect effect = Main.pixelShader;
			DyeInitializer.LoadLegacyHairdyes();
			GameShaders.Hair.BindShader<HairShaderData>(3259, new HairShaderData(effect, "ArmorTwilight")).UseImage("Images/Misc/noise").UseColor(0.5f, 0.1f, 1f);
		}

		private static void LoadLegacyHairdyes()
		{
			Effect effect = Main.pixelShader;
			GameShaders.Hair.BindShader<LegacyHairShaderData>(1977, (new LegacyHairShaderData()).UseLegacyMethod((Player player, Color newColor, ref bool lighting) => {
				newColor.R = (byte)((float)player.statLife / (float)player.statLifeMax2 * 235f + 20f);
				newColor.B = 20;
				newColor.G = 20;
				return newColor;
			}));
			GameShaders.Hair.BindShader<LegacyHairShaderData>(1978, (new LegacyHairShaderData()).UseLegacyMethod((Player player, Color newColor, ref bool lighting) => {
				newColor.R = (byte)((1f - (float)player.statMana / (float)player.statManaMax2) * 200f + 50f);
				newColor.B = 255;
				newColor.G = (byte)((1f - (float)player.statMana / (float)player.statManaMax2) * 180f + 75f);
				return newColor;
			}));
			GameShaders.Hair.BindShader<LegacyHairShaderData>(1979, (new LegacyHairShaderData()).UseLegacyMethod((Player player, Color newColor, ref bool lighting) => {
				float single = (float)(Main.worldSurface * 0.45) * 16f;
				float single1 = (float)(Main.worldSurface + Main.rockLayer) * 8f;
				float single2 = (float)(Main.rockLayer + (double)Main.maxTilesY) * 8f;
				float single3 = (float)(Main.maxTilesY - 150) * 16f;
				Vector2 center = player.Center;
				if (center.Y < single)
				{
					float y = (float)(center.Y / single);
					float single4 = 1f - y;
					newColor.R = (byte)(116f * single4 + 28f * y);
					newColor.G = (byte)(160f * single4 + 216f * y);
					newColor.B = (byte)(249f * single4 + 94f * y);
				}
				else if (center.Y < single1)
				{
					float single5 = single;
					float y1 = (float)((center.Y - single5) / (single1 - single5));
					float single6 = 1f - y1;
					newColor.R = (byte)(28f * single6 + 151f * y1);
					newColor.G = (byte)(216f * single6 + 107f * y1);
					newColor.B = (byte)(94f * single6 + 75f * y1);
				}
				else if (center.Y < single2)
				{
					float single7 = single1;
					float y2 = (float)((center.Y - single7) / (single2 - single7));
					float single8 = 1f - y2;
					newColor.R = (byte)(151f * single8 + 128f * y2);
					newColor.G = (byte)(107f * single8 + 128f * y2);
					newColor.B = (byte)(75f * single8 + 128f * y2);
				}
				else if (center.Y >= single3)
				{
					newColor.R = 255;
					newColor.G = 50;
					newColor.B = 10;
				}
				else
				{
					float single9 = single2;
					float y3 = (float)((center.Y - single9) / (single3 - single9));
					float single10 = 1f - y3;
					newColor.R = (byte)(128f * single10 + 255f * y3);
					newColor.G = (byte)(128f * single10 + 50f * y3);
					newColor.B = (byte)(128f * single10 + 15f * y3);
				}
				return newColor;
			}));
			GameShaders.Hair.BindShader<LegacyHairShaderData>(1980, (new LegacyHairShaderData()).UseLegacyMethod((Player player, Color newColor, ref bool lighting) => {
				int num = 0;
				for (int i = 0; i < 54; i++)
				{
					if (player.inventory[i].type == 71)
					{
						num = num + player.inventory[i].stack;
					}
					if (player.inventory[i].type == 72)
					{
						num = num + player.inventory[i].stack * 100;
					}
					if (player.inventory[i].type == 73)
					{
						num = num + player.inventory[i].stack * 10000;
					}
					if (player.inventory[i].type == 74)
					{
						num = num + player.inventory[i].stack * 1000000;
					}
				}
				float single = (float)Item.buyPrice(0, 5, 0, 0);
				float single1 = (float)Item.buyPrice(0, 50, 0, 0);
				float single2 = (float)Item.buyPrice(2, 0, 0, 0);
				Color color = new Color(226, 118, 76);
				Color color1 = new Color(174, 194, 196);
				Color color2 = new Color(204, 181, 72);
				Color color3 = new Color(161, 172, 173);
				if ((float)num < single)
				{
					float single3 = (float)((float)num / single);
					float single4 = 1f - single3;
					newColor.R = (byte)((float)color.R * single4 + (float)color1.R * single3);
					newColor.G = (byte)((float)color.G * single4 + (float)color1.G * single3);
					newColor.B = (byte)((float)color.B * single4 + (float)color1.B * single3);
				}
				else if ((float)num < single1)
				{
					float single5 = single;
					float single6 = (float)(((float)num - single5) / (single1 - single5));
					float single7 = 1f - single6;
					newColor.R = (byte)((float)color1.R * single7 + (float)color2.R * single6);
					newColor.G = (byte)((float)color1.G * single7 + (float)color2.G * single6);
					newColor.B = (byte)((float)color1.B * single7 + (float)color2.B * single6);
				}
				else if ((float)num >= single2)
				{
					newColor = color3;
				}
				else
				{
					float single8 = single1;
					float single9 = (float)(((float)num - single8) / (single2 - single8));
					float single10 = 1f - single9;
					newColor.R = (byte)((float)color2.R * single10 + (float)color3.R * single9);
					newColor.G = (byte)((float)color2.G * single10 + (float)color3.G * single9);
					newColor.B = (byte)((float)color2.B * single10 + (float)color3.B * single9);
				}
				return newColor;
			}));
			GameShaders.Hair.BindShader<LegacyHairShaderData>(1981, (new LegacyHairShaderData()).UseLegacyMethod((Player player, Color newColor, ref bool lighting) => {
				Color color = new Color(1, 142, 255);
				Color color1 = new Color(255, 255, 0);
				Color color2 = new Color(211, 45, 127);
				Color color3 = new Color(67, 44, 118);
				if (Main.dayTime)
				{
					if (Main.time >= 27000)
					{
						float single = 27000f;
						float single1 = (float)((Main.time - (double)single) / (54000 - (double)single));
						float single2 = 1f - single1;
						newColor.R = (byte)((float)color1.R * single2 + (float)color2.R * single1);
						newColor.G = (byte)((float)color1.G * single2 + (float)color2.G * single1);
						newColor.B = (byte)((float)color1.B * single2 + (float)color2.B * single1);
					}
					else
					{
						float single3 = (float)(Main.time / 27000);
						float single4 = 1f - single3;
						newColor.R = (byte)((float)color.R * single4 + (float)color1.R * single3);
						newColor.G = (byte)((float)color.G * single4 + (float)color1.G * single3);
						newColor.B = (byte)((float)color.B * single4 + (float)color1.B * single3);
					}
				}
				else if (Main.time >= 16200)
				{
					float single5 = 16200f;
					float single6 = (float)((Main.time - (double)single5) / (32400 - (double)single5));
					float single7 = 1f - single6;
					newColor.R = (byte)((float)color3.R * single7 + (float)color.R * single6);
					newColor.G = (byte)((float)color3.G * single7 + (float)color.G * single6);
					newColor.B = (byte)((float)color3.B * single7 + (float)color.B * single6);
				}
				else
				{
					float single8 = (float)(Main.time / 16200);
					float single9 = 1f - single8;
					newColor.R = (byte)((float)color2.R * single9 + (float)color3.R * single8);
					newColor.G = (byte)((float)color2.G * single9 + (float)color3.G * single8);
					newColor.B = (byte)((float)color2.B * single9 + (float)color3.B * single8);
				}
				return newColor;
			}));
			GameShaders.Hair.BindShader<LegacyHairShaderData>(1982, (new LegacyHairShaderData()).UseLegacyMethod((Player player, Color newColor, ref bool lighting) => {
				if (player.team >= 0 && player.team < (int)Main.teamColor.Length)
				{
					newColor = Main.teamColor[player.team];
				}
				return newColor;
			}));
			GameShaders.Hair.BindShader<LegacyHairShaderData>(1983, (new LegacyHairShaderData()).UseLegacyMethod((Player player, Color newColor, ref bool lighting) => {
				Color color = new Color();
				color = (Main.waterStyle != 2 ? (Main.waterStyle != 3 ? (Main.waterStyle != 4 ? (Main.waterStyle != 5 ? (Main.waterStyle != 6 ? (Main.waterStyle != 7 ? (Main.waterStyle != 8 ? (Main.waterStyle != 9 ? (Main.waterStyle != 10 ? new Color(28, 216, 94) : new Color(208, 80, 80)) : new Color(200, 0, 0)) : new Color(128, 128, 128)) : new Color(151, 107, 75)) : new Color(230, 219, 100)) : new Color(189, 231, 255)) : new Color(78, 193, 227)) : new Color(143, 215, 29)) : new Color(124, 118, 242));
				Color r = player.hairDyeColor;
				if (r.A == 0)
				{
					r = color;
				}
				if (r.R > color.R)
				{
					r.R = (byte)(r.R - 1);
				}
				if (r.R < color.R)
				{
					r.R = (byte)(r.R + 1);
				}
				if (r.G > color.G)
				{
					r.G = (byte)(r.G - 1);
				}
				if (r.G < color.G)
				{
					r.G = (byte)(r.G + 1);
				}
				if (r.B > color.B)
				{
					r.B = (byte)(r.B - 1);
				}
				if (r.B < color.B)
				{
					r.B = (byte)(r.B + 1);
				}
				newColor = r;
				return newColor;
			}));
			GameShaders.Hair.BindShader<LegacyHairShaderData>(1984, (new LegacyHairShaderData()).UseLegacyMethod((Player player, Color newColor, ref bool lighting) => {
				newColor = new Color(244, 22, 175);
				if (!Main.gameMenu && !Main.gamePaused)
				{
					if (Main.rand.Next(45) == 0)
					{
						int num = Main.rand.Next(139, 143);
						int num1 = Dust.NewDust(player.position, player.width, 8, num, 0f, 0f, 0, new Color(), 1.2f);
						Main.dust[num1].velocity.X = Main.dust[num1].velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Main.dust[num1].velocity.Y = Main.dust[num1].velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Main.dust[num1].velocity.X = Main.dust[num1].velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.dust[num1].velocity.Y = Main.dust[num1].velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.dust[num1].velocity.Y = Main.dust[num1].velocity.Y - 1f;
						Dust dust = Main.dust[num1];
						dust.scale = dust.scale * (0.7f + (float)Main.rand.Next(-30, 31) * 0.01f);
						Dust dust1 = Main.dust[num1];
						dust1.velocity = dust1.velocity + (player.velocity * 0.2f);
					}
					if (Main.rand.Next(225) == 0)
					{
						int num2 = Main.rand.Next(276, 283);
						int num3 = Gore.NewGore(new Vector2(player.position.X + (float)Main.rand.Next(player.width), player.position.Y + (float)Main.rand.Next(8)), player.velocity, num2, 1f);
						Main.gore[num3].velocity.X = Main.gore[num3].velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Main.gore[num3].velocity.Y = Main.gore[num3].velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Gore gore = Main.gore[num3];
						gore.scale = gore.scale * (1f + (float)Main.rand.Next(-20, 21) * 0.01f);
						Main.gore[num3].velocity.X = Main.gore[num3].velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.gore[num3].velocity.Y = Main.gore[num3].velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.gore[num3].velocity.Y = Main.gore[num3].velocity.Y - 1f;
						Gore gore1 = Main.gore[num3];
						gore1.velocity = gore1.velocity + (player.velocity * 0.2f);
					}
				}
				return newColor;
			}));
			GameShaders.Hair.BindShader<LegacyHairShaderData>(1985, (new LegacyHairShaderData()).UseLegacyMethod((Player player, Color newColor, ref bool lighting) => {
				newColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
				return newColor;
			}));
			GameShaders.Hair.BindShader<LegacyHairShaderData>(1986, (new LegacyHairShaderData()).UseLegacyMethod((Player player, Color newColor, ref bool lighting) => {
				float single = Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y);
				float single1 = 10f;
				if (single > single1)
				{
					single = single1;
				}
				float single2 = (float)(single / single1);
				float single3 = 1f - single2;
				newColor.R = (byte)(75f * single2 + (float)player.hairColor.R * single3);
				newColor.G = (byte)(255f * single2 + (float)player.hairColor.G * single3);
				newColor.B = (byte)(200f * single2 + (float)player.hairColor.B * single3);
				return newColor;
			}));
			GameShaders.Hair.BindShader<LegacyHairShaderData>(2863, (new LegacyHairShaderData()).UseLegacyMethod((Player player, Color newColor, ref bool lighting) => {
				lighting = false;
				Color color = Lighting.GetColor((int)((double)player.position.X + (double)player.width * 0.5) / 16, (int)(((double)player.position.Y + (double)player.height * 0.25) / 16));
				newColor.R = (byte)(color.R + newColor.R >> 1);
				newColor.G = (byte)(color.G + newColor.G >> 1);
				newColor.B = (byte)(color.B + newColor.B >> 1);
				return newColor;
			}));
		}

		private static void LoadMisc()
		{
			Effect effect = Main.pixelShader;
			GameShaders.Misc["ForceField"] = new MiscShaderData(effect, "ForceField");
		}
	}
}