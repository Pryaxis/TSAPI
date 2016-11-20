using System;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Utilities;
using TerrariaApi.Server;

namespace Terraria
{
	public class Item : Entity
	{
		public bool accessory;

		public int alpha;

		public int ammo = AmmoID.None;

		public bool autoReuse;

		public int axe;

		public sbyte backSlot = -1;

		public int bait;

		public sbyte balloonSlot = -1;

		public bool beingGrabbed;

		public int bodySlot = -1;

		public static int[] bodyType = new int[208];

		public int buffTime;

		public int buffType;

		public bool buy;

		public bool buyOnce;

		public bool cartTrack;

		public bool channel;

		public static bool[] claw = new bool[3884];

		public static int coinGrabRange = 350;

		public Color color;

		public bool consumable;

		public const int copper = 1;

		public int createTile = -1;

		public int createWall = -1;

		public int crit;

		public int damage;

		public bool DD2Summon;

		public int defense;

		public byte dye;

		public bool expert;

		public bool expertOnly;

		public sbyte faceSlot = -1;

		public bool favorited;

		public int fishingPole = 1;

		public bool flame;

		public const int flaskTime = 72000;

		public sbyte frontSlot = -1;

		public short glowMask;

		public const int gold = 10000;

		public short hairDye = -1;

		public int hammer;

		public sbyte handOffSlot = -1;

		public sbyte handOnSlot = -1;

		public int headSlot = -1;

		public static int[] headType = new int[214];

		public int healLife;

		public int healMana;

		public int holdStyle;

		public bool instanced;

		public bool isBeingGrabbed;

		public static int[] itemCaches = ItemID.Sets.Factory.CreateIntSet(-1, new int[0]);

		public int keepTime;

		public float knockBack;

		public int legSlot = -1;

		public static int[] legType = new int[157];

		public static int lifeGrabRange = 250;

		public int lifeRegen;

		public bool magic;

		public short makeNPC;

		public int mana;

		public static int manaGrabRange = 300;

		public int manaIncrease;

		public bool material;

		public const int maxPrefixes = 84;

		public int maxStack;

		public bool mech;

		public bool melee;

		public int mountType = -1;

		public sbyte neckSlot = -1;

		public int netID;

		public bool newAndShiny;

		public int noGrabDelay;

		public bool noMelee;

		public bool notAmmo;

		public bool noUseGraphic;

		public bool noWet;

		public int owner = 255;

		public int ownIgnore = -1;

		public int ownTime;

		public byte paint;

		public int pick;

		public int placeStyle;

		public const int platinum = 1000000;

		public bool potion;

		public static int potionDelay = 3600;

		public byte prefix;

		public bool questItem;

		public bool ranged;

		public int rare;

		public int release;

		public static int restorationDelay = 3000;

		public int reuseDelay;

		public float scale = 1f;

		public bool sentry;

		public sbyte shieldSlot = -1;

		public sbyte shoeSlot = -1;

		public int shoot;

		public float shootSpeed;

		public int? shopCustomPrice = null;

		public int shopSpecialCurrency = -1;

		public const int silver = 100;

		public bool social;

		public int spawnTime;

		public int stack;

		public static bool[] staff = new bool[3884];

		public int stringColor;

		public bool summon;

		public bool thrown;

		public int tileBoost;

		public int tileWand = -1;

		public string toolTip;

		public string toolTip2;

		public int type;

		public bool uniqueStack;

		public int useAmmo = AmmoID.None;

		public int useAnimation;

		public int useStyle;

		public int useTime;

		public bool useTurn;

		public int value;

		public bool vanity;

		public sbyte waistSlot = -1;

		public sbyte wingSlot = -1;

		public bool wornArmor;

		public string AffixName()
		{
			if (Lang.lang <= 1)
			{
				if (Lang.prefix[(int)prefix] != "")
				{
					return Lang.prefix[(int)prefix] + " " + name;
				}
				return name;
			}
			else
			{
				if (Lang.prefix[(int)prefix] != "")
				{
					return name + " (" + Lang.prefix[(int)prefix] + ")";
				}
				return name;
			}
		}

		public static int BannerToItem(int banner)
		{
			int result;
			if (banner >= 257)
			{
				result = 3837 + banner - 257;
			}
			else if (banner >= 252)
			{
				result = 3789 + banner - 252;
			}
			else if (banner == 251)
			{
				result = 3780;
			}
			else if (banner >= 249)
			{
				result = 3593 + banner - 249;
			}
			else if (banner >= 186)
			{
				result = 3390 + banner - 186;
			}
			else if (banner >= 88)
			{
				result = 2897 + banner - 88;
			}
			else
			{
				result = 1615 + banner - 1;
			}
			return result;
		}

		public static int BannerToNPC(int i)
		{
			switch (i)
			{
				case 1:
					return 102;
				case 2:
					return 250;
				case 3:
					return 257;
				case 4:
					return 69;
				case 5:
					return 157;
				case 6:
					return 77;
				case 7:
					return 49;
				case 8:
					return 74;
				case 9:
					return 163;
				case 10:
					return 241;
				case 11:
					return 242;
				case 12:
					return 239;
				case 13:
					return 39;
				case 14:
					return 46;
				case 15:
					return 120;
				case 16:
					return 85;
				case 17:
					return 109;
				case 18:
					return 47;
				case 19:
					return 57;
				case 20:
					return 67;
				case 21:
					return 173;
				case 22:
					return 179;
				case 23:
					return 83;
				case 24:
					return 62;
				case 25:
					return 2;
				case 26:
					return 177;
				case 27:
					return 6;
				case 28:
					return 84;
				case 29:
					return 161;
				case 30:
					return 181;
				case 31:
					return 182;
				case 32:
					return 224;
				case 33:
					return 226;
				case 34:
					return 162;
				case 35:
					return 259;
				case 36:
					return 256;
				case 37:
					return 122;
				case 38:
					return 27;
				case 39:
					return 29;
				case 40:
					return 26;
				case 41:
					return 73;
				case 42:
					return 28;
				case 43:
					return 55;
				case 44:
					return 48;
				case 45:
					return 60;
				case 46:
					return 174;
				case 47:
					return 42;
				case 48:
					return 169;
				case 49:
					return 206;
				case 50:
					return 24;
				case 51:
					return 63;
				case 52:
					return 236;
				case 53:
					return 199;
				case 54:
					return 43;
				case 55:
					return 23;
				case 56:
					return 205;
				case 57:
					return 78;
				case 58:
					return 258;
				case 59:
					return 252;
				case 60:
					return 170;
				case 61:
					return 58;
				case 62:
					return 212;
				case 63:
					return 75;
				case 64:
					return 223;
				case 65:
					return 253;
				case 66:
					return 65;
				case 67:
					return 21;
				case 68:
					return 32;
				case 69:
					return 1;
				case 70:
					return 185;
				case 71:
					return 164;
				case 72:
					return 254;
				case 73:
					return 166;
				case 74:
					return 153;
				case 75:
					return 141;
				case 76:
					return 225;
				case 77:
					return 86;
				case 78:
					return 158;
				case 79:
					return 61;
				case 80:
					return 196;
				case 81:
					return 104;
				case 82:
					return 155;
				case 83:
					return 98;
				case 84:
					return 10;
				case 85:
					return 82;
				case 86:
					return 87;
				case 87:
					return 3;
				case 88:
					return 175;
				case 89:
					return 197;
				case 90:
					return -6;
				case 91:
					return 273;
				case 92:
					return 379;
				case 95:
					return 287;
				case 96:
					return 101;
				case 97:
					return 217;
				case 98:
					return 168;
				case 99:
					return 81;
				case 100:
					return 94;
				case 101:
					return 183;
				case 102:
					return 34;
				case 103:
					return 218;
				case 104:
					return 7;
				case 105:
					return 285;
				case 106:
					return 52;
				case 107:
					return 71;
				case 108:
					return 288;
				case 109:
					return 350;
				case 110:
					return 347;
				case 111:
					return 251;
				case 112:
					return 352;
				case 113:
					return 316;
				case 114:
					return 93;
				case 115:
					return 289;
				case 116:
					return 152;
				case 117:
					return 342;
				case 118:
					return 111;
				case 119:
					return -3;
				case 120:
					return 315;
				case 121:
					return 277;
				case 122:
					return 329;
				case 123:
					return 304;
				case 124:
					return 150;
				case 125:
					return 243;
				case 126:
					return 147;
				case 127:
					return 268;
				case 128:
					return 137;
				case 129:
					return 138;
				case 130:
					return 51;
				case 131:
					return -10;
				case 132:
					return 351;
				case 133:
					return 219;
				case 134:
					return 151;
				case 135:
					return 59;
				case 136:
					return 381;
				case 137:
					return 388;
				case 138:
					return 386;
				case 139:
					return 389;
				case 140:
					return 385;
				case 141:
					return 383;
				case 142:
					return 382;
				case 143:
					return 390;
				case 144:
					return 387;
				case 145:
					return 144;
				case 146:
					return 16;
				case 147:
					return 283;
				case 148:
					return 348;
				case 149:
					return 290;
				case 150:
					return 148;
				case 151:
					return -4;
				case 152:
					return 330;
				case 153:
					return 140;
				case 154:
					return 341;
				case 155:
					return -7;
				case 156:
					return 281;
				case 157:
					return 244;
				case 158:
					return 301;
				case 159:
					return -8;
				case 160:
					return 172;
				case 161:
					return 269;
				case 162:
					return 305;
				case 163:
					return 391;
				case 164:
					return 110;
				case 165:
					return 293;
				case 166:
					return 291;
				case 167:
					return 121;
				case 168:
					return 56;
				case 169:
					return 145;
				case 170:
					return 143;
				case 171:
					return 184;
				case 172:
					return 204;
				case 173:
					return 326;
				case 174:
					return 221;
				case 175:
					return 292;
				case 176:
					return 53;
				case 177:
					return 45;
				case 178:
					return 44;
				case 179:
					return 167;
				case 180:
					return 380;
				case 183:
					return -9;
				case 184:
					return 343;
				case 185:
					return 338;
				case 186:
					return 471;
				case 187:
					return 498;
				case 188:
					return 496;
				case 189:
					return 494;
				case 190:
					return 462;
				case 191:
					return 461;
				case 192:
					return 468;
				case 193:
					return 477;
				case 195:
					return 469;
				case 196:
					return 460;
				case 197:
					return 466;
				case 198:
					return 467;
				case 199:
					return 463;
				case 201:
					return 480;
				case 202:
					return 481;
				case 203:
					return 483;
				case 204:
					return 482;
				case 205:
					return 489;
				case 206:
					return 490;
				case 207:
					return 513;
				case 208:
					return 510;
				case 209:
					return 509;
				case 210:
					return 508;
				case 211:
					return 524;
				case 212:
					return 529;
				case 213:
					return 533;
				case 214:
					return 532;
				case 215:
					return 530;
				case 216:
					return 411;
				case 217:
					return 402;
				case 218:
					return 407;
				case 219:
					return 409;
				case 221:
					return 405;
				case 222:
					return 418;
				case 223:
					return 417;
				case 224:
					return 412;
				case 225:
					return 416;
				case 226:
					return 415;
				case 227:
					return 419;
				case 228:
					return 424;
				case 229:
					return 421;
				case 230:
					return 420;
				case 231:
					return 423;
				case 232:
					return 428;
				case 233:
					return 426;
				case 234:
					return 427;
				case 235:
					return 429;
				case 236:
					return 425;
				case 237:
					return 216;
				case 238:
					return 214;
				case 239:
					return 213;
				case 240:
					return 215;
				case 241:
					return 520;
				case 242:
					return 156;
				case 243:
					return 64;
				case 244:
					return 103;
				case 245:
					return 79;
				case 246:
					return 80;
				case 247:
					return 31;
				case 248:
					return 154;
				case 249:
					return 537;
				case 250:
					return 220;
				case 251:
					return 541;
				case 252:
					return 542;
				case 253:
					return 543;
				case 254:
					return 544;
				case 255:
					return 545;
				case 256:
					return 546;
				case 257:
					return 555;
				case 258:
					return 552;
				case 259:
					return 566;
				case 260:
					return 570;
				case 261:
					return 574;
				case 262:
					return 572;
				case 263:
					return 568;
				case 264:
					return 558;
				case 265:
					return 561;
				case 266:
					return 578;
			}
			return 0;
		}

		public static int buyPrice(int platinum = 0, int gold = 0, int silver = 0, int copper = 0)
		{
			int num = copper + silver * 100;
			num += gold * 100 * 100;
			return num + platinum * 100 * 100 * 100;
		}

		public bool checkMat()
		{
			if (type >= 71 && type <= 74)
			{
				material = false;
				return false;
			}
			for (int i = 0; i < Recipe.numRecipes; i++)
			{
				int num = 0;
				while (Main.recipe[i].requiredItem[num].type > 0)
				{
					if (netID == Main.recipe[i].requiredItem[num].netID)
					{
						material = true;
						return true;
					}
					num++;
				}
			}
			int num2 = type;
			if (num2 <= 543)
			{
				if (num2 != 529)
				{
					switch (num2)
					{
						case 541:
						case 542:
						case 543:
							break;
						default:
							goto IL_C5;
					}
				}
			}
			else
			{
				switch (num2)
				{
					case 852:
					case 853:
						break;
					default:
						if (num2 != 1151)
						{
							goto IL_C5;
						}
						break;
				}
			}
			material = true;
			return true;
			IL_C5:
			material = false;
			return false;
		}

		public void CheckTip()
		{
			toolTip = Lang.toolTip(netID, false);
			toolTip2 = Lang.toolTip2(netID, false);
		}

		public Item Clone()
		{
			return (Item)base.MemberwiseClone();
		}

		public Item DeepClone()
		{
			return (Item)base.MemberwiseClone();
		}

		public static void DropCache(Vector2 pos, Vector2 spread, int t, bool stopCaching = true)
		{
			if (Item.itemCaches[t] == -1)
			{
				return;
			}
			int i = Item.itemCaches[t];
			Item.itemCaches[t] = (stopCaching ? -1 : 0);
			Item item = new Item();
			item.SetDefaults(t, false);
			while (i > 0)
			{
				int num = item.maxStack;
				if (i < num)
				{
					num = i;
				}
				Item.NewItem((int)pos.X, (int)pos.Y, (int)spread.X, (int)spread.Y, t, num, false, 0, false, false);
				i -= num;
			}
		}

		public void FindOwner(int whoAmI)
		{
			if (keepTime > 0)
			{
				return;
			}
			int num = owner;
			owner = 255;
			float num2 = 999999f;
			for (int i = 0; i < 255; i++)
			{
				if (ownIgnore != i && Main.player[i].active && Main.player[i].ItemSpace(Main.item[whoAmI]))
				{
					float num3 = Math.Abs(Main.player[i].position.X + Main.player[i].width / 2 - position.X - width / 2) + Math.Abs(Main.player[i].position.Y + Main.player[i].height / 2 - position.Y - height);
					if (Main.player[i].manaMagnet && (type == 184 || type == 1735 || type == 1868))
					{
						num3 -= Item.manaGrabRange;
					}
					if (Main.player[i].lifeMagnet && (type == 58 || type == 1734 || type == 1867))
					{
						num3 -= Item.lifeGrabRange;
					}
					if (num3 < NPC.sWidth && num3 < num2)
					{
						num2 = num3;
						owner = i;
					}
				}
			}
			if (owner != num && ((num == Main.myPlayer && Main.netMode == 1) || (num == 255 && Main.netMode == 2) || (num != 255 && !Main.player[num].active)))
			{
				NetMessage.SendData(21, -1, -1, "", whoAmI, 0f, 0f, 0f, 0, 0, 0);
				if (active)
				{
					NetMessage.SendData(22, -1, -1, "", whoAmI, 0f, 0f, 0f, 0, 0, 0);
				}
			}
		}

		public Color GetAlpha(Color newColor)
		{
			int num = type;
			if (num > 1332)
			{
				if (num <= 2765)
				{
					if (num <= 1572)
					{
						if (num <= 1508)
						{
							if (num != 1446)
							{
								switch (num)
								{
									case 1506:
									case 1507:
										break;
									case 1508:
										return new Color(200, 200, 200, 0);
									default:
										goto IL_4EB;
								}
							}
						}
						else
						{
							switch (num)
							{
								case 1543:
								case 1544:
								case 1545:
									break;
								default:
									if (num != 1572)
									{
										goto IL_4EB;
									}
									return new Color(200, 200, 255, 125);
							}
						}
						return new Color(newColor.R, newColor.G, newColor.B, Main.gFade);
					}
					if (num <= 1826)
					{
						switch (num)
						{
							case 1734:
							case 1735:
								goto IL_39C;
							default:
								if (num != 1826)
								{
									goto IL_4EB;
								}
								return new Color(255, 255, 255, 200);
						}
					}
					else
					{
						switch (num)
						{
							case 1867:
							case 1868:
								goto IL_39C;
							default:
								switch (num)
								{
									case 2763:
									case 2764:
									case 2765:
										break;
									default:
										goto IL_4EB;
								}
								break;
						}
					}
				}
				else if (num <= 3459)
				{
					if (num <= 3065)
					{
						switch (num)
						{
							case 2782:
							case 2783:
							case 2784:
							case 2785:
							case 2786:
								break;
							default:
								if (num != 3065)
								{
									goto IL_4EB;
								}
								goto IL_317;
						}
					}
					else
					{
						if (num == 3191)
						{
							return new Color(250, 250, 250, 200);
						}
						switch (num)
						{
							case 3453:
							case 3454:
							case 3455:
								goto IL_385;
							case 3456:
							case 3457:
							case 3458:
							case 3459:
								goto IL_36B;
							default:
								goto IL_4EB;
						}
					}
				}
				else if (num <= 3580)
				{
					if (num != 3522)
					{
						if (num != 3580)
						{
							goto IL_4EB;
						}
						goto IL_385;
					}
				}
				else
				{
					if (num == 3822)
					{
						return Color.Lerp(Color.White, newColor, 0.5f) * ((255f - alpha) / 255f);
					}
					if (num == 3858)
					{
						goto IL_317;
					}
					goto IL_4EB;
				}
				return new Color(250, 250, 250, 255 - alpha);
			}
			if (num <= 502)
			{
				if (num <= 122)
				{
					if (num <= 58)
					{
						if (num == 51)
						{
							return new Color(255, 255, 255, 0);
						}
						if (num != 58)
						{
							goto IL_4EB;
						}
						goto IL_39C;
					}
					else
					{
						if (num == 75)
						{
							goto IL_317;
						}
						switch (num)
						{
							case 119:
							case 120:
							case 121:
							case 122:
								break;
							default:
								goto IL_4EB;
						}
					}
				}
				else if (num <= 203)
				{
					if (num == 184)
					{
						goto IL_39C;
					}
					switch (num)
					{
						case 198:
						case 199:
						case 200:
						case 201:
						case 202:
						case 203:
							return Color.White;
						default:
							goto IL_4EB;
					}
				}
				else
				{
					switch (num)
					{
						case 217:
						case 218:
						case 219:
						case 220:
							break;
						default:
							switch (num)
							{
								case 501:
									return new Color(200, 200, 200, 50);
								case 502:
									return new Color(255, 255, 255, 150);
								default:
									goto IL_4EB;
							}
					}
				}
				return new Color(255, 255, 255, 255);
			}
			if (num <= 757)
			{
				if (num <= 549)
				{
					switch (num)
					{
						case 520:
						case 521:
						case 522:
							goto IL_385;
						default:
							switch (num)
							{
								case 547:
								case 548:
								case 549:
									goto IL_385;
								default:
									goto IL_4EB;
							}
					}
				}
				else
				{
					if (num == 575)
					{
						goto IL_385;
					}
					if (num != 757)
					{
						goto IL_4EB;
					}
					goto IL_36B;
				}
			}
			else if (num <= 1260)
			{
				if (num == 787)
				{
					return new Color(255, 255, 255, 175);
				}
				if (num != 1260)
				{
					goto IL_4EB;
				}
				return new Color(255, 255, 255, 175);
			}
			else
			{
				if (num == 1306)
				{
					goto IL_36B;
				}
				if (num != 1332)
				{
					goto IL_4EB;
				}
				goto IL_385;
			}
			IL_317:
			return new Color(255, 255, 255, newColor.A - alpha);
			IL_36B:
			return new Color(255, 255, 255, 200);
			IL_385:
			return new Color(255, 255, 255, 50);
			IL_39C:
			return new Color(200, 200, 200, 200);
			IL_4EB:
			float num2 = (255 - alpha) / 255f;
			int r = (int)(newColor.R * num2);
			int g = (int)(newColor.G * num2);
			int b = (int)(newColor.B * num2);
			int num3 = newColor.A - alpha;
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num3 > 255)
			{
				num3 = 255;
			}
			return new Color(r, g, b, num3);
		}

		public Color GetColor(Color newColor)
		{
			int num = color.R - (255 - newColor.R);
			int num2 = color.G - (255 - newColor.G);
			int num3 = color.B - (255 - newColor.B);
			int num4 = color.A - (255 - newColor.A);
			if (num < 0)
			{
				num = 0;
			}
			if (num > 255)
			{
				num = 255;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num4 < 0)
			{
				num4 = 0;
			}
			if (num4 > 255)
			{
				num4 = 255;
			}
			return new Color(num, num2, num3, num4);
		}

		public Rectangle getRect()
		{
			return new Rectangle((int)position.X, (int)position.Y, width, height);
		}

		public int GetStoreValue()
		{
			if (shopCustomPrice.HasValue)
			{
				return shopCustomPrice.Value;
			}
			return value;
		}

		public bool IsAir
		{
			get
			{
				return this.type <= 0 || this.stack <= 0;
			}
		}

		public bool IsNotTheSameAs(Item compareItem)
		{
			return netID != compareItem.netID || stack != compareItem.stack || prefix != compareItem.prefix;
		}

		public bool IsTheSameAs(Item compareItem)
		{
			return netID == compareItem.netID && type == compareItem.type;
		}

		public static bool MechSpawn(float x, float y, int type)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < 200; i++)
			{
				if (Main.item[i].active && Main.item[i].type == type)
				{
					num++;
					Vector2 vector = new Vector2(x, y);
					float num4 = Main.item[i].position.X - vector.X;
					float num5 = Main.item[i].position.Y - vector.Y;
					float num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
					if (num6 < 300f)
					{
						num2++;
					}
					if (num6 < 800f)
					{
						num3++;
					}
				}
			}
			return ServerApi.Hooks.InvokeGameStatueSpawn(num2, num3, num, (int)(x / 16), (int)(y / 16), type, false);
		}

		public void netDefaults(int type)
		{
			if (ServerApi.Hooks.InvokeItemNetDefaults(ref type, this))
				return;

			if (type < 0)
			{
				if (type == -1)
				{
					SetDefaults("Gold Pickaxe");
					return;
				}
				if (type == -2)
				{
					SetDefaults("Gold Broadsword");
					return;
				}
				if (type == -3)
				{
					SetDefaults("Gold Shortsword");
					return;
				}
				if (type == -4)
				{
					SetDefaults("Gold Axe");
					return;
				}
				if (type == -5)
				{
					SetDefaults("Gold Hammer");
					return;
				}
				if (type == -6)
				{
					SetDefaults("Gold Bow");
					return;
				}
				if (type == -7)
				{
					SetDefaults("Silver Pickaxe");
					return;
				}
				if (type == -8)
				{
					SetDefaults("Silver Broadsword");
					return;
				}
				if (type == -9)
				{
					SetDefaults("Silver Shortsword");
					return;
				}
				if (type == -10)
				{
					SetDefaults("Silver Axe");
					return;
				}
				if (type == -11)
				{
					SetDefaults("Silver Hammer");
					return;
				}
				if (type == -12)
				{
					SetDefaults("Silver Bow");
					return;
				}
				if (type == -13)
				{
					SetDefaults("Copper Pickaxe");
					return;
				}
				if (type == -14)
				{
					SetDefaults("Copper Broadsword");
					return;
				}
				if (type == -15)
				{
					SetDefaults("Copper Shortsword");
					return;
				}
				if (type == -16)
				{
					SetDefaults("Copper Axe");
					return;
				}
				if (type == -17)
				{
					SetDefaults("Copper Hammer");
					return;
				}
				if (type == -18)
				{
					SetDefaults("Copper Bow");
					return;
				}
				if (type == -19)
				{
					SetDefaults("Blue Phasesaber");
					return;
				}
				if (type == -20)
				{
					SetDefaults("Red Phasesaber");
					return;
				}
				if (type == -21)
				{
					SetDefaults("Green Phasesaber");
					return;
				}
				if (type == -22)
				{
					SetDefaults("Purple Phasesaber");
					return;
				}
				if (type == -23)
				{
					SetDefaults("White Phasesaber");
					return;
				}
				if (type == -24)
				{
					SetDefaults("Yellow Phasesaber");
					return;
				}
				if (type == -25)
				{
					SetDefaults("Tin Pickaxe");
					return;
				}
				if (type == -26)
				{
					SetDefaults("Tin Broadsword");
					return;
				}
				if (type == -27)
				{
					SetDefaults("Tin Shortsword");
					return;
				}
				if (type == -28)
				{
					SetDefaults("Tin Axe");
					return;
				}
				if (type == -29)
				{
					SetDefaults("Tin Hammer");
					return;
				}
				if (type == -30)
				{
					SetDefaults("Tin Bow");
					return;
				}
				if (type == -31)
				{
					SetDefaults("Lead Pickaxe");
					return;
				}
				if (type == -32)
				{
					SetDefaults("Lead Broadsword");
					return;
				}
				if (type == -33)
				{
					SetDefaults("Lead Shortsword");
					return;
				}
				if (type == -34)
				{
					SetDefaults("Lead Axe");
					return;
				}
				if (type == -35)
				{
					SetDefaults("Lead Hammer");
					return;
				}
				if (type == -36)
				{
					SetDefaults("Lead Bow");
					return;
				}
				if (type == -37)
				{
					SetDefaults("Tungsten Pickaxe");
					return;
				}
				if (type == -38)
				{
					SetDefaults("Tungsten Broadsword");
					return;
				}
				if (type == -39)
				{
					SetDefaults("Tungsten Shortsword");
					return;
				}
				if (type == -40)
				{
					SetDefaults("Tungsten Axe");
					return;
				}
				if (type == -41)
				{
					SetDefaults("Tungsten Hammer");
					return;
				}
				if (type == -42)
				{
					SetDefaults("Tungsten Bow");
					return;
				}
				if (type == -43)
				{
					SetDefaults("Platinum Pickaxe");
					return;
				}
				if (type == -44)
				{
					SetDefaults("Platinum Broadsword");
					return;
				}
				if (type == -45)
				{
					SetDefaults("Platinum Shortsword");
					return;
				}
				if (type == -46)
				{
					SetDefaults("Platinum Axe");
					return;
				}
				if (type == -47)
				{
					SetDefaults("Platinum Hammer");
					return;
				}
				if (type == -48)
				{
					SetDefaults("Platinum Bow");
					return;
				}
			}
			else
			{
				SetDefaults(type, false);
			}
		}

		public static int NewItem(Vector2 pos, Vector2 randomBox, int Type, int Stack = 1, bool noBroadcast = false, int prefixGiven = 0, bool noGrabDelay = false, bool reverseLookup = false)
		{
			return Item.NewItem((int)pos.X, (int)pos.Y, (int)randomBox.X, (int)randomBox.Y, Type, Stack, noBroadcast, prefixGiven, noGrabDelay, reverseLookup);
		}

		public static int NewItem(Vector2 pos, int Width, int Height, int Type, int Stack = 1, bool noBroadcast = false, int prefixGiven = 0, bool noGrabDelay = false, bool reverseLookup = false)
		{
			return Item.NewItem((int)pos.X, (int)pos.Y, Width, Height, Type, Stack, noBroadcast, prefixGiven, noGrabDelay, reverseLookup);
		}

		public static int NewItem(int X, int Y, int Width, int Height, int Type, int Stack = 1, bool noBroadcast = false, int pfix = 0, bool noGrabDelay = false, bool reverseLookup = false)
		{
			if (WorldGen.gen)
			{
				return 0;
			}
			if (Main.rand == null)
			{
				Main.rand = new UnifiedRandom();
			}
			int num = 400;
			Main.item[400] = new Item();
			if (Main.halloween)
			{
				if (Type == 58)
				{
					Type = 1734;
				}
				if (Type == 184)
				{
					Type = 1735;
				}
			}
			if (Main.xMas)
			{
				if (Type == 58)
				{
					Type = 1867;
				}
				if (Type == 184)
				{
					Type = 1868;
				}
			}
			if (Item.itemCaches[Type] != -1)
			{
				Item.itemCaches[Type] += Stack;
				return 400;
			}
			if (Main.netMode != 1)
			{
				if (reverseLookup)
				{
					for (int i = 399; i >= 0; i--)
					{
						if (!Main.item[i].active && Main.itemLockoutTime[i] == 0)
						{
							num = i;
							break;
						}
					}
				}
				else
				{
					for (int j = 0; j < 400; j++)
					{
						if (!Main.item[j].active && Main.itemLockoutTime[j] == 0)
						{
							num = j;
							break;
						}
					}
				}
			}
			if (num == 400 && Main.netMode != 1)
			{
				int num2 = 0;
				for (int k = 0; k < 400; k++)
				{
					if (Main.item[k].spawnTime - Main.itemLockoutTime[k] > num2)
					{
						num2 = Main.item[k].spawnTime - Main.itemLockoutTime[k];
						num = k;
					}
				}
			}
			Main.itemLockoutTime[num] = 0;
			Main.item[num] = new Item();
			Main.item[num].SetDefaults(Type, false);
			Main.item[num].Prefix(pfix);
			Main.item[num].position.X = X + Width / 2 - Main.item[num].width / 2;
			Main.item[num].position.Y = Y + Height / 2 - Main.item[num].height / 2;
			Main.item[num].wet = Collision.WetCollision(Main.item[num].position, Main.item[num].width, Main.item[num].height);
			Main.item[num].velocity.X = Main.rand.Next(-30, 31) * 0.1f;
			Main.item[num].velocity.Y = Main.rand.Next(-40, -15) * 0.1f;
			if (Type == 859)
			{
				Main.item[num].velocity *= 0f;
			}
			if (Type == 520 || Type == 521 || (Main.item[num].type >= 0 && ItemID.Sets.NebulaPickup[Main.item[num].type]))
			{
				Main.item[num].velocity.X = Main.rand.Next(-30, 31) * 0.1f;
				Main.item[num].velocity.Y = Main.rand.Next(-30, 31) * 0.1f;
			}
			Main.item[num].active = true;
			Main.item[num].spawnTime = 0;
			Main.item[num].stack = Stack;
			if (Main.item[num].type >= 0 && !ItemID.Sets.NeverShiny[Main.item[num].type])
			{
				Main.item[num].newAndShiny = true;
			}
			if (Main.netMode == 2 && !noBroadcast)
			{
				int num3 = 0;
				if (noGrabDelay)
				{
					num3 = 1;
				}
				NetMessage.SendData(21, -1, -1, "", num, (float)num3, 0f, 0f, 0, 0, 0);
				Main.item[num].FindOwner(num);
			}
			return num;
		}

		public static int NPCtoBanner(int i)
		{
			switch (i)
			{
				case -10:
					return 131;
				case -9:
					return 183;
				case -8:
					return 159;
				case -7:
					return 155;
				case -6:
					return 90;
				case -4:
					return 151;
				case -3:
					return 119;
				case -2:
				case 121:
					return 167;
				case 1:
				case 302:
				case 333:
				case 334:
				case 335:
				case 336:
					return 69;
				case 2:
				case 133:
				case 190:
				case 191:
				case 192:
				case 193:
				case 194:
				case 317:
				case 318:
					return 25;
				case 3:
				case 132:
				case 186:
				case 187:
				case 188:
				case 189:
				case 200:
				case 319:
				case 320:
				case 321:
				case 331:
				case 332:
				case 430:
				case 432:
				case 433:
				case 434:
				case 435:
				case 436:
					return 87;
				case 6:
					return 27;
				case 7:
					return 104;
				case 10:
				case 11:
				case 12:
				case 95:
				case 96:
				case 97:
					return 84;
				case 16:
					return 146;
				case 21:
				case 201:
				case 202:
				case 203:
				case 449:
				case 450:
				case 451:
				case 452:
					return 67;
				case 23:
					return 55;
				case 24:
					return 50;
				case 26:
					return 40;
				case 27:
					return 38;
				case 28:
					return 42;
				case 29:
					return 39;
				case 31:
				case 294:
				case 295:
				case 296:
					return 247;
				case 32:
					return 68;
				case 34:
					return 102;
				case 39:
				case 40:
				case 41:
					return 13;
				case 42:
				case 176:
				case 231:
				case 232:
				case 233:
				case 234:
				case 235:
					return 47;
				case 43:
					return 54;
				case 44:
					return 178;
				case 45:
					return 177;
				case 46:
				case 303:
				case 337:
				case 540:
					return 14;
				case 47:
					return 18;
				case 48:
					return 44;
				case 49:
					return 7;
				case 51:
					return 130;
				case 52:
					return 106;
				case 53:
					return 176;
				case 55:
				case 230:
					return 43;
				case 56:
					return 168;
				case 57:
					return 19;
				case 58:
					return 61;
				case 59:
					return 135;
				case 60:
					return 45;
				case 61:
					return 79;
				case 62:
				case 66:
					return 24;
				case 63:
					return 51;
				case 64:
					return 243;
				case 65:
					return 66;
				case 67:
					return 20;
				case 69:
					return 4;
				case 71:
					return 107;
				case 73:
					return 41;
				case 74:
					return 8;
				case 75:
					return 63;
				case 77:
					return 6;
				case 78:
					return 57;
				case 79:
					return 245;
				case 80:
					return 246;
				case 81:
					return 99;
				case 82:
					return 85;
				case 83:
					return 23;
				case 84:
					return 28;
				case 85:
					return 16;
				case 86:
					return 77;
				case 87:
				case 88:
				case 89:
				case 90:
				case 91:
				case 92:
					return 86;
				case 93:
					return 114;
				case 94:
					return 100;
				case 98:
				case 99:
				case 100:
					return 83;
				case 101:
					return 96;
				case 102:
					return 1;
				case 103:
					return 244;
				case 104:
					return 81;
				case 109:
					return 17;
				case 110:
					return 164;
				case 111:
					return 118;
				case 120:
					return 15;
				case 122:
					return 37;
				case 137:
					return 128;
				case 138:
					return 129;
				case 140:
					return 153;
				case 141:
					return 75;
				case 143:
					return 170;
				case 144:
					return 145;
				case 145:
					return 169;
				case 147:
					return 126;
				case 148:
				case 149:
					return 150;
				case 150:
					return 124;
				case 151:
					return 134;
				case 152:
					return 116;
				case 153:
					return 74;
				case 154:
					return 248;
				case 155:
					return 82;
				case 156:
					return 242;
				case 157:
					return 5;
				case 158:
				case 159:
					return 78;
				case 161:
				case 431:
					return 29;
				case 162:
					return 34;
				case 163:
				case 238:
					return 9;
				case 164:
				case 165:
					return 71;
				case 166:
					return 73;
				case 167:
					return 179;
				case 168:
					return 98;
				case 169:
					return 48;
				case 170:
				case 171:
				case 180:
					return 60;
				case 172:
					return 160;
				case 173:
					return 21;
				case 174:
					return 46;
				case 175:
					return 88;
				case 177:
					return 26;
				case 179:
					return 22;
				case 181:
					return 30;
				case 182:
					return 31;
				case 183:
					return 101;
				case 184:
					return 171;
				case 185:
					return 70;
				case 195:
				case 196:
					return 80;
				case 197:
					return 89;
				case 198:
				case 199:
					return 53;
				case 204:
					return 172;
				case 205:
					return 56;
				case 206:
					return 49;
				case 212:
					return 62;
				case 213:
					return 239;
				case 214:
					return 238;
				case 215:
					return 240;
				case 216:
					return 237;
				case 217:
					return 97;
				case 218:
					return 103;
				case 219:
					return 133;
				case 220:
					return 250;
				case 221:
					return 174;
				case 223:
					return 64;
				case 224:
					return 32;
				case 225:
					return 76;
				case 226:
					return 33;
				case 236:
				case 237:
					return 52;
				case 239:
				case 240:
					return 12;
				case 241:
					return 10;
				case 242:
					return 11;
				case 243:
					return 125;
				case 244:
					return 157;
				case 250:
					return 2;
				case 251:
					return 111;
				case 252:
					return 59;
				case 253:
					return 65;
				case 254:
				case 255:
					return 72;
				case 256:
					return 36;
				case 257:
					return 3;
				case 258:
					return 58;
				case 259:
				case 260:
					return 35;
				case 268:
					return 127;
				case 269:
				case 270:
				case 271:
				case 272:
					return 161;
				case 273:
				case 274:
				case 275:
				case 276:
					return 91;
				case 277:
				case 278:
				case 279:
				case 280:
					return 121;
				case 281:
				case 282:
					return 156;
				case 283:
				case 284:
					return 147;
				case 285:
				case 286:
					return 105;
				case 287:
					return 95;
				case 288:
					return 108;
				case 289:
					return 115;
				case 290:
					return 149;
				case 291:
					return 166;
				case 292:
					return 175;
				case 293:
					return 165;
				case 301:
					return 158;
				case 304:
					return 123;
				case 305:
				case 306:
				case 307:
				case 308:
				case 309:
				case 310:
				case 311:
				case 312:
				case 313:
				case 314:
					return 162;
				case 315:
					return 120;
				case 316:
					return 113;
				case 326:
					return 173;
				case 329:
					return 122;
				case 330:
					return 152;
				case 338:
				case 339:
				case 340:
					return 185;
				case 341:
					return 154;
				case 342:
					return 117;
				case 343:
					return 184;
				case 347:
					return 110;
				case 348:
				case 349:
					return 148;
				case 350:
					return 109;
				case 351:
					return 132;
				case 352:
					return 112;
				case 379:
					return 92;
				case 380:
					return 180;
				case 381:
					return 136;
				case 382:
					return 142;
				case 383:
				case 384:
					return 141;
				case 385:
					return 140;
				case 386:
					return 138;
				case 387:
					return 144;
				case 388:
					return 137;
				case 389:
					return 139;
				case 390:
					return 143;
				case 391:
					return 163;
				case 402:
				case 403:
				case 404:
					return 217;
				case 405:
				case 406:
					return 221;
				case 407:
				case 408:
					return 218;
				case 409:
					return 219;
				case 411:
					return 216;
				case 412:
				case 413:
				case 414:
					return 224;
				case 415:
					return 226;
				case 416:
					return 225;
				case 417:
					return 223;
				case 418:
					return 222;
				case 419:
					return 227;
				case 420:
					return 230;
				case 421:
					return 229;
				case 423:
					return 231;
				case 424:
					return 228;
				case 425:
					return 236;
				case 426:
					return 233;
				case 427:
					return 234;
				case 428:
					return 232;
				case 429:
					return 235;
				case 460:
					return 196;
				case 461:
					return 191;
				case 462:
					return 190;
				case 463:
					return 199;
				case 466:
					return 197;
				case 467:
					return 198;
				case 468:
					return 192;
				case 469:
					return 195;
				case 471:
					return 186;
				case 477:
					return 193;
				case 480:
					return 201;
				case 481:
					return 202;
				case 482:
					return 204;
				case 483:
					return 203;
				case 489:
					return 205;
				case 490:
					return 206;
				case 494:
				case 495:
					return 189;
				case 496:
				case 497:
					return 188;
				case 498:
				case 499:
				case 500:
				case 501:
				case 502:
				case 503:
				case 504:
				case 505:
				case 506:
					return 187;
				case 508:
					return 210;
				case 509:
					return 209;
				case 510:
				case 511:
				case 512:
					return 208;
				case 513:
				case 514:
				case 515:
					return 207;
				case 520:
					return 241;
				case 524:
				case 525:
				case 526:
				case 527:
					return 211;
				case 528:
				case 529:
					return 212;
				case 530:
				case 531:
					return 215;
				case 532:
					return 214;
				case 533:
					return 213;
				case 537:
					return 249;
				case 541:
					return 251;
				case 542:
					return 252;
				case 543:
					return 253;
				case 544:
					return 254;
				case 545:
					return 255;
				case 546:
					return 256;
				case 552:
				case 553:
				case 554:
					return 258;
				case 555:
				case 556:
				case 557:
					return 257;
				case 558:
				case 559:
				case 560:
					return 264;
				case 561:
				case 562:
				case 563:
					return 265;
				case 566:
				case 567:
					return 259;
				case 568:
				case 569:
					return 263;
				case 570:
				case 571:
					return 260;
				case 572:
				case 573:
					return 262;
				case 574:
				case 575:
					return 261;
				case 578:
					return 266;
			}
			return 0;
		}

		public void OnPurchase(Item item)
		{
			if (item.shopCustomPrice.HasValue)
			{
				item.shopSpecialCurrency = -1;
				item.shopCustomPrice = null;
			}
		}

		public bool Prefix(int pre)
		{
			if (Main.rand == null)
			{
				Main.rand = new UnifiedRandom();
			}
			if (pre == 0 || type == 0)
			{
				return false;
			}
			UnifiedRandom unifiedRandom = WorldGen.gen ? WorldGen.genRand : Main.rand;
			int num = pre;
			float num2 = 1f;
			float num3 = 1f;
			float num4 = 1f;
			float num5 = 1f;
			float num6 = 1f;
			float num7 = 1f;
			int num8 = 0;
			bool flag = true;
			while (flag)
			{
				num2 = 1f;
				num3 = 1f;
				num4 = 1f;
				num5 = 1f;
				num6 = 1f;
				num7 = 1f;
				num8 = 0;
				flag = false;
				if (num == -1 && unifiedRandom.Next(4) == 0)
				{
					num = 0;
				}
				if (pre < -1)
				{
					num = -1;
				}
				if (num == -1 || num == -2 || num == -3)
				{
					if (type == 1 || type == 4 || type == 6 || type == 7 || type == 10 || type == 24 || type == 45 || type == 46 || type == 65 || type == 103 || type == 104 || type == 121 || type == 122 || type == 155 || type == 190 || type == 196 || type == 198 || type == 199 || type == 200 || type == 201 || type == 202 || type == 203 || type == 204 || type == 213 || type == 217 || type == 273 || type == 367 || type == 368 || type == 426 || type == 482 || type == 483 || type == 484 || type == 653 || type == 654 || type == 656 || type == 657 || type == 659 || type == 660 || type == 671 || type == 672 || type == 674 || type == 675 || type == 676 || type == 723 || type == 724 || type == 757 || type == 776 || type == 777 || type == 778 || type == 787 || type == 795 || type == 797 || type == 798 || type == 799 || type == 881 || type == 882 || type == 921 || type == 922 || type == 989 || type == 990 || type == 991 || type == 992 || type == 993 || type == 1123 || type == 1166 || type == 1185 || type == 1188 || type == 1192 || type == 1195 || type == 1199 || type == 1202 || type == 1222 || type == 1223 || type == 1224 || type == 1226 || type == 1227 || type == 1230 || type == 1233 || type == 1234 || type == 1294 || type == 1304 || type == 1305 || type == 1306 || type == 1320 || type == 1327 || type == 1506 || type == 1507 || type == 1786 || type == 1826 || type == 1827 || type == 1909 || type == 1917 || type == 1928 || type == 2176 || type == 2273 || type == 2608 || type == 2341 || type == 2330 || type == 2320 || type == 2516 || type == 2517 || type == 2746 || type == 2745 || type == 3063 || type == 3018 || type == 3211 || type == 3013 || type == 3258 || type == 3106 || type == 3065 || type == 2880 || type == 3481 || type == 3482 || type == 3483 || type == 3484 || type == 3485 || type == 3487 || type == 3488 || type == 3489 || type == 3490 || type == 3491 || type == 3493 || type == 3494 || type == 3495 || type == 3496 || type == 3497 || type == 3498 || type == 3500 || type == 3501 || type == 3502 || type == 3503 || type == 3504 || type == 3505 || type == 3506 || type == 3507 || type == 3508 || type == 3509 || type == 3511 || type == 3512 || type == 3513 || type == 3514 || type == 3515 || type == 3517 || type == 3518 || type == 3519 || type == 3520 || type == 3521 || type == 3522 || type == 3523 || type == 3524 || type == 3525 || (type >= 3462 && type <= 3466) || (type >= 2772 && type <= 2786) || (type == 3349 || type == 3352 || type == 3351 || (type >= 3764 && type <= 3769)) || type == 3772 || type == 3823 || type == 3827)
					{
						int num9 = unifiedRandom.Next(40);
						if (num9 == 0)
						{
							num = 1;
						}
						if (num9 == 1)
						{
							num = 2;
						}
						if (num9 == 2)
						{
							num = 3;
						}
						if (num9 == 3)
						{
							num = 4;
						}
						if (num9 == 4)
						{
							num = 5;
						}
						if (num9 == 5)
						{
							num = 6;
						}
						if (num9 == 6)
						{
							num = 7;
						}
						if (num9 == 7)
						{
							num = 8;
						}
						if (num9 == 8)
						{
							num = 9;
						}
						if (num9 == 9)
						{
							num = 10;
						}
						if (num9 == 10)
						{
							num = 11;
						}
						if (num9 == 11)
						{
							num = 12;
						}
						if (num9 == 12)
						{
							num = 13;
						}
						if (num9 == 13)
						{
							num = 14;
						}
						if (num9 == 14)
						{
							num = 15;
						}
						if (num9 == 15)
						{
							num = 36;
						}
						if (num9 == 16)
						{
							num = 37;
						}
						if (num9 == 17)
						{
							num = 38;
						}
						if (num9 == 18)
						{
							num = 53;
						}
						if (num9 == 19)
						{
							num = 54;
						}
						if (num9 == 20)
						{
							num = 55;
						}
						if (num9 == 21)
						{
							num = 39;
						}
						if (num9 == 22)
						{
							num = 40;
						}
						if (num9 == 23)
						{
							num = 56;
						}
						if (num9 == 24)
						{
							num = 41;
						}
						if (num9 == 25)
						{
							num = 57;
						}
						if (num9 == 26)
						{
							num = 42;
						}
						if (num9 == 27)
						{
							num = 43;
						}
						if (num9 == 28)
						{
							num = 44;
						}
						if (num9 == 29)
						{
							num = 45;
						}
						if (num9 == 30)
						{
							num = 46;
						}
						if (num9 == 31)
						{
							num = 47;
						}
						if (num9 == 32)
						{
							num = 48;
						}
						if (num9 == 33)
						{
							num = 49;
						}
						if (num9 == 34)
						{
							num = 50;
						}
						if (num9 == 35)
						{
							num = 51;
						}
						if (num9 == 36)
						{
							num = 59;
						}
						if (num9 == 37)
						{
							num = 60;
						}
						if (num9 == 38)
						{
							num = 61;
						}
						if (num9 == 39)
						{
							num = 81;
						}
					}
					else if (type == 162 || type == 160 || type == 163 || type == 220 || type == 274 || type == 277 || type == 280 || type == 383 || type == 384 || type == 385 || type == 386 || type == 387 || type == 388 || type == 389 || type == 390 || type == 406 || type == 537 || type == 550 || type == 579 || type == 756 || type == 759 || type == 801 || type == 802 || type == 1186 || type == 1189 || type == 1190 || type == 1193 || type == 1196 || type == 1197 || type == 1200 || type == 1203 || type == 1204 || type == 1228 || type == 1231 || type == 1232 || type == 1259 || type == 1262 || type == 1297 || type == 1314 || type == 1325 || type == 1947 || type == 2332 || type == 2331 || type == 2342 || type == 2424 || type == 2611 || type == 2798 || type == 3012 || type == 3473 || type == 3098 || type == 3368 || type == 3835 || type == 3836 || type == 3858)
					{
						int num10 = unifiedRandom.Next(14);
						if (num10 == 0)
						{
							num = 36;
						}
						if (num10 == 1)
						{
							num = 37;
						}
						if (num10 == 2)
						{
							num = 38;
						}
						if (num10 == 3)
						{
							num = 53;
						}
						if (num10 == 4)
						{
							num = 54;
						}
						if (num10 == 5)
						{
							num = 55;
						}
						if (num10 == 6)
						{
							num = 39;
						}
						if (num10 == 7)
						{
							num = 40;
						}
						if (num10 == 8)
						{
							num = 56;
						}
						if (num10 == 9)
						{
							num = 41;
						}
						if (num10 == 10)
						{
							num = 57;
						}
						if (num10 == 11)
						{
							num = 59;
						}
						if (num10 == 12)
						{
							num = 60;
						}
						if (num10 == 13)
						{
							num = 61;
						}
					}
					else if (type == 39 || type == 44 || type == 95 || type == 96 || type == 98 || type == 99 || type == 120 || type == 164 || type == 197 || type == 219 || type == 266 || type == 281 || type == 434 || type == 435 || type == 436 || type == 481 || type == 506 || type == 533 || type == 534 || type == 578 || type == 655 || type == 658 || type == 661 || type == 679 || type == 682 || type == 725 || type == 758 || type == 759 || type == 760 || type == 796 || type == 800 || type == 905 || type == 923 || type == 964 || type == 986 || type == 1156 || type == 1187 || type == 1194 || type == 1201 || type == 1229 || type == 1254 || type == 1255 || type == 1258 || type == 1265 || type == 1319 || type == 1553 || type == 1782 || type == 1784 || type == 1835 || type == 1870 || type == 1910 || type == 1929 || type == 1946 || type == 2223 || type == 2269 || type == 2270 || type == 2624 || type == 2515 || type == 2747 || type == 2796 || type == 2797 || type == 3052 || type == 2888 || type == 3019 || type == 3029 || type == 3007 || type == 3008 || type == 3210 || type == 3107 || type == 3245 || type == 3475 || type == 3540 || type == 3854 || type == 3859 || type == 3821 || type == 3480 || type == 3486 || type == 3492 || type == 3498 || type == 3504 || type == 3510 || type == 3516 || type == 3350 || type == 3546 || type == 3788)
					{
						int num11 = unifiedRandom.Next(36);
						if (num11 == 0)
						{
							num = 16;
						}
						if (num11 == 1)
						{
							num = 17;
						}
						if (num11 == 2)
						{
							num = 18;
						}
						if (num11 == 3)
						{
							num = 19;
						}
						if (num11 == 4)
						{
							num = 20;
						}
						if (num11 == 5)
						{
							num = 21;
						}
						if (num11 == 6)
						{
							num = 22;
						}
						if (num11 == 7)
						{
							num = 23;
						}
						if (num11 == 8)
						{
							num = 24;
						}
						if (num11 == 9)
						{
							num = 25;
						}
						if (num11 == 10)
						{
							num = 58;
						}
						if (num11 == 11)
						{
							num = 36;
						}
						if (num11 == 12)
						{
							num = 37;
						}
						if (num11 == 13)
						{
							num = 38;
						}
						if (num11 == 14)
						{
							num = 53;
						}
						if (num11 == 15)
						{
							num = 54;
						}
						if (num11 == 16)
						{
							num = 55;
						}
						if (num11 == 17)
						{
							num = 39;
						}
						if (num11 == 18)
						{
							num = 40;
						}
						if (num11 == 19)
						{
							num = 56;
						}
						if (num11 == 20)
						{
							num = 41;
						}
						if (num11 == 21)
						{
							num = 57;
						}
						if (num11 == 22)
						{
							num = 42;
						}
						if (num11 == 23)
						{
							num = 43;
						}
						if (num11 == 24)
						{
							num = 44;
						}
						if (num11 == 25)
						{
							num = 45;
						}
						if (num11 == 26)
						{
							num = 46;
						}
						if (num11 == 27)
						{
							num = 47;
						}
						if (num11 == 28)
						{
							num = 48;
						}
						if (num11 == 29)
						{
							num = 49;
						}
						if (num11 == 30)
						{
							num = 50;
						}
						if (num11 == 31)
						{
							num = 51;
						}
						if (num11 == 32)
						{
							num = 59;
						}
						if (num11 == 33)
						{
							num = 60;
						}
						if (num11 == 34)
						{
							num = 61;
						}
						if (num11 == 35)
						{
							num = 82;
						}
					}
					else if (type == 64 || type == 112 || type == 113 || type == 127 || type == 157 || type == 165 || type == 218 || type == 272 || type == 494 || type == 495 || type == 496 || type == 514 || type == 517 || type == 518 || type == 519 || type == 683 || type == 726 || type == 739 || type == 740 || type == 741 || type == 742 || type == 743 || type == 744 || type == 788 || type == 1121 || type == 1155 || type == 1157 || type == 1178 || type == 1244 || type == 1256 || type == 1260 || type == 1264 || type == 1266 || type == 1295 || type == 1296 || type == 1308 || type == 1309 || type == 1313 || type == 1336 || type == 1444 || type == 1445 || type == 1446 || type == 1572 || type == 1801 || type == 1802 || type == 1930 || type == 1931 || type == 2188 || type == 2622 || type == 2621 || type == 2584 || type == 2551 || type == 2366 || type == 2535 || type == 2365 || type == 2364 || type == 2623 || type == 2750 || type == 2795 || type == 3053 || type == 3051 || type == 3209 || type == 3014 || type == 3105 || type == 2882 || type == 3269 || type == 3006 || type == 3377 || type == 3069 || type == 2749 || type == 3249 || type == 3476 || type == 3474 || type == 3531 || type == 3541 || type == 3542 || type == 3569 || type == 3570 || type == 3571 || type == 3779 || type == 3787 || type == 3531 || type == 3852 || type == 3870 || this.type == 3824 || this.type == 3818 || this.type == 3829 || this.type == 3832 || this.type == 3825 || this.type == 3819 || this.type == 3830 || this.type == 3833 || this.type == 3826 || this.type == 3820 || this.type == 3831 || this.type == 3834)
					{
						int num12 = unifiedRandom.Next(36);
						if (num12 == 0)
						{
							num = 26;
						}
						if (num12 == 1)
						{
							num = 27;
						}
						if (num12 == 2)
						{
							num = 28;
						}
						if (num12 == 3)
						{
							num = 29;
						}
						if (num12 == 4)
						{
							num = 30;
						}
						if (num12 == 5)
						{
							num = 31;
						}
						if (num12 == 6)
						{
							num = 32;
						}
						if (num12 == 7)
						{
							num = 33;
						}
						if (num12 == 8)
						{
							num = 34;
						}
						if (num12 == 9)
						{
							num = 35;
						}
						if (num12 == 10)
						{
							num = 52;
						}
						if (num12 == 11)
						{
							num = 36;
						}
						if (num12 == 12)
						{
							num = 37;
						}
						if (num12 == 13)
						{
							num = 38;
						}
						if (num12 == 14)
						{
							num = 53;
						}
						if (num12 == 15)
						{
							num = 54;
						}
						if (num12 == 16)
						{
							num = 55;
						}
						if (num12 == 17)
						{
							num = 39;
						}
						if (num12 == 18)
						{
							num = 40;
						}
						if (num12 == 19)
						{
							num = 56;
						}
						if (num12 == 20)
						{
							num = 41;
						}
						if (num12 == 21)
						{
							num = 57;
						}
						if (num12 == 22)
						{
							num = 42;
						}
						if (num12 == 23)
						{
							num = 43;
						}
						if (num12 == 24)
						{
							num = 44;
						}
						if (num12 == 25)
						{
							num = 45;
						}
						if (num12 == 26)
						{
							num = 46;
						}
						if (num12 == 27)
						{
							num = 47;
						}
						if (num12 == 28)
						{
							num = 48;
						}
						if (num12 == 29)
						{
							num = 49;
						}
						if (num12 == 30)
						{
							num = 50;
						}
						if (num12 == 31)
						{
							num = 51;
						}
						if (num12 == 32)
						{
							num = 59;
						}
						if (num12 == 33)
						{
							num = 60;
						}
						if (num12 == 34)
						{
							num = 61;
						}
						if (num12 == 35)
						{
							num = 83;
						}
					}
					else if (type == 55 || type == 119 || type == 191 || type == 284 || type == 670 || type == 1122 || type == 1513 || type == 1569 || type == 1571 || type == 1825 || type == 1918 || type == 3054 || type == 3262 || (type >= 3278 && type <= 3292) || (type >= 3315 && type <= 3317) || type == 3389 || type == 3030 || type == 3543)
					{
						int num13 = unifiedRandom.Next(14);
						if (num13 == 0)
						{
							num = 36;
						}
						if (num13 == 1)
						{
							num = 37;
						}
						if (num13 == 2)
						{
							num = 38;
						}
						if (num13 == 3)
						{
							num = 53;
						}
						if (num13 == 4)
						{
							num = 54;
						}
						if (num13 == 5)
						{
							num = 55;
						}
						if (num13 == 6)
						{
							num = 39;
						}
						if (num13 == 7)
						{
							num = 40;
						}
						if (num13 == 8)
						{
							num = 56;
						}
						if (num13 == 9)
						{
							num = 41;
						}
						if (num13 == 10)
						{
							num = 57;
						}
						if (num13 == 11)
						{
							num = 59;
						}
						if (num13 == 12)
						{
							num = 60;
						}
						if (num13 == 13)
						{
							num = 61;
						}
					}
					else
					{
						if (!accessory || type == 267 || type == 562 || type == 563 || type == 564 || type == 565 || type == 566 || type == 567 || type == 568 || type == 569 || type == 570 || type == 571 || type == 572 || type == 573 || type == 574 || type == 576 || type == 1307 || (type >= 1596 && type < 1610) || vanity)
						{
							return false;
						}
						num = unifiedRandom.Next(62, 81);
					}
				}
				if (pre == -3)
				{
					return true;
				}
				if (pre == -1 && (num == 7 || num == 8 || num == 9 || num == 10 || num == 11 || num == 22 || num == 23 || num == 24 || num == 29 || num == 30 || num == 31 || num == 39 || num == 40 || num == 56 || num == 41 || num == 47 || num == 48 || num == 49) && unifiedRandom.Next(3) != 0)
				{
					num = 0;
				}
				if (num == 1)
				{
					num5 = 1.12f;
				}
				else if (num == 2)
				{
					num5 = 1.18f;
				}
				else if (num == 3)
				{
					num2 = 1.05f;
					num8 = 2;
					num5 = 1.05f;
				}
				else if (num == 4)
				{
					num2 = 1.1f;
					num5 = 1.1f;
					num3 = 1.1f;
				}
				else if (num == 5)
				{
					num2 = 1.15f;
				}
				else if (num == 6)
				{
					num2 = 1.1f;
				}
				else if (num == 81)
				{
					num3 = 1.15f;
					num2 = 1.15f;
					num8 = 5;
					num4 = 0.9f;
					num5 = 1.1f;
				}
				else if (num == 7)
				{
					num5 = 0.82f;
				}
				else if (num == 8)
				{
					num3 = 0.85f;
					num2 = 0.85f;
					num5 = 0.87f;
				}
				else if (num == 9)
				{
					num5 = 0.9f;
				}
				else if (num == 10)
				{
					num2 = 0.85f;
				}
				else if (num == 11)
				{
					num4 = 1.1f;
					num3 = 0.9f;
					num5 = 0.9f;
				}
				else if (num == 12)
				{
					num3 = 1.1f;
					num2 = 1.05f;
					num5 = 1.1f;
					num4 = 1.15f;
				}
				else if (num == 13)
				{
					num3 = 0.8f;
					num2 = 0.9f;
					num5 = 1.1f;
				}
				else if (num == 14)
				{
					num3 = 1.15f;
					num4 = 1.1f;
				}
				else if (num == 15)
				{
					num3 = 0.9f;
					num4 = 0.85f;
				}
				else if (num == 16)
				{
					num2 = 1.1f;
					num8 = 3;
				}
				else if (num == 17)
				{
					num4 = 0.85f;
					num6 = 1.1f;
				}
				else if (num == 18)
				{
					num4 = 0.9f;
					num6 = 1.15f;
				}
				else if (num == 19)
				{
					num3 = 1.15f;
					num6 = 1.05f;
				}
				else if (num == 20)
				{
					num3 = 1.05f;
					num6 = 1.05f;
					num2 = 1.1f;
					num4 = 0.95f;
					num8 = 2;
				}
				else if (num == 21)
				{
					num3 = 1.15f;
					num2 = 1.1f;
				}
				else if (num == 82)
				{
					num3 = 1.15f;
					num2 = 1.15f;
					num8 = 5;
					num4 = 0.9f;
					num6 = 1.1f;
				}
				else if (num == 22)
				{
					num3 = 0.9f;
					num6 = 0.9f;
					num2 = 0.85f;
				}
				else if (num == 23)
				{
					num4 = 1.15f;
					num6 = 0.9f;
				}
				else if (num == 24)
				{
					num4 = 1.1f;
					num3 = 0.8f;
				}
				else if (num == 25)
				{
					num4 = 1.1f;
					num2 = 1.15f;
					num8 = 1;
				}
				else if (num == 58)
				{
					num4 = 0.85f;
					num2 = 0.85f;
				}
				else if (num == 26)
				{
					num7 = 0.85f;
					num2 = 1.1f;
				}
				else if (num == 27)
				{
					num7 = 0.85f;
				}
				else if (num == 28)
				{
					num7 = 0.85f;
					num2 = 1.15f;
					num3 = 1.05f;
				}
				else if (num == 83)
				{
					num3 = 1.15f;
					num2 = 1.15f;
					num8 = 5;
					num4 = 0.9f;
					num7 = 0.9f;
				}
				else if (num == 29)
				{
					num7 = 1.1f;
				}
				else if (num == 30)
				{
					num7 = 1.2f;
					num2 = 0.9f;
				}
				else if (num == 31)
				{
					num3 = 0.9f;
					num2 = 0.9f;
				}
				else if (num == 32)
				{
					num7 = 1.15f;
					num2 = 1.1f;
				}
				else if (num == 33)
				{
					num7 = 1.1f;
					num3 = 1.1f;
					num4 = 0.9f;
				}
				else if (num == 34)
				{
					num7 = 0.9f;
					num3 = 1.1f;
					num4 = 1.1f;
					num2 = 1.1f;
				}
				else if (num == 35)
				{
					num7 = 1.2f;
					num2 = 1.15f;
					num3 = 1.15f;
				}
				else if (num == 52)
				{
					num7 = 0.9f;
					num2 = 0.9f;
					num4 = 0.9f;
				}
				else if (num == 36)
				{
					num8 = 3;
				}
				else if (num == 37)
				{
					num2 = 1.1f;
					num8 = 3;
					num3 = 1.1f;
				}
				else if (num == 38)
				{
					num3 = 1.15f;
				}
				else if (num == 53)
				{
					num2 = 1.1f;
				}
				else if (num == 54)
				{
					num3 = 1.15f;
				}
				else if (num == 55)
				{
					num3 = 1.15f;
					num2 = 1.05f;
				}
				else if (num == 59)
				{
					num3 = 1.15f;
					num2 = 1.15f;
					num8 = 5;
				}
				else if (num == 60)
				{
					num2 = 1.15f;
					num8 = 5;
				}
				else if (num == 61)
				{
					num8 = 5;
				}
				else if (num == 39)
				{
					num2 = 0.7f;
					num3 = 0.8f;
				}
				else if (num == 40)
				{
					num2 = 0.85f;
				}
				else if (num == 56)
				{
					num3 = 0.8f;
				}
				else if (num == 41)
				{
					num3 = 0.85f;
					num2 = 0.9f;
				}
				else if (num == 57)
				{
					num3 = 0.9f;
					num2 = 1.18f;
				}
				else if (num == 42)
				{
					num4 = 0.9f;
				}
				else if (num == 43)
				{
					num2 = 1.1f;
					num4 = 0.9f;
				}
				else if (num == 44)
				{
					num4 = 0.9f;
					num8 = 3;
				}
				else if (num == 45)
				{
					num4 = 0.95f;
				}
				else if (num == 46)
				{
					num8 = 3;
					num4 = 0.94f;
					num2 = 1.07f;
				}
				else if (num == 47)
				{
					num4 = 1.15f;
				}
				else if (num == 48)
				{
					num4 = 1.2f;
				}
				else if (num == 49)
				{
					num4 = 1.08f;
				}
				else if (num == 50)
				{
					num2 = 0.8f;
					num4 = 1.15f;
				}
				else if (num == 51)
				{
					num3 = 0.9f;
					num4 = 0.9f;
					num2 = 1.05f;
					num8 = 2;
				}
				if (num2 != 1f && Math.Round(damage * num2) == damage)
				{
					flag = true;
					num = -1;
				}
				if (num4 != 1f && Math.Round(useAnimation * num4) == useAnimation)
				{
					flag = true;
					num = -1;
				}
				if (num7 != 1f && Math.Round(mana * num7) == mana)
				{
					flag = true;
					num = -1;
				}
				if (num3 != 1f && knockBack == 0f)
				{
					flag = true;
					num = -1;
				}
				if (pre == -2 && num == 0)
				{
					num = -1;
					flag = true;
				}
			}
			damage = (int)Math.Round(damage * num2);
			useAnimation = (int)Math.Round(useAnimation * num4);
			useTime = (int)Math.Round(useTime * num4);
			reuseDelay = (int)Math.Round(reuseDelay * num4);
			mana = (int)Math.Round(mana * num7);
			knockBack *= num3;
			scale *= num5;
			shootSpeed *= num6;
			crit += num8;
			float num14 = 1f * num2 * (2f - num4) * (2f - num7) * num5 * num3 * num6 * (1f + crit * 0.02f);
			if (num == 62 || num == 69 || num == 73 || num == 77)
			{
				num14 *= 1.05f;
			}
			if (num == 63 || num == 70 || num == 74 || num == 78 || num == 67)
			{
				num14 *= 1.1f;
			}
			if (num == 64 || num == 71 || num == 75 || num == 79 || num == 66)
			{
				num14 *= 1.15f;
			}
			if (num == 65 || num == 72 || num == 76 || num == 80 || num == 68)
			{
				num14 *= 1.2f;
			}
			if (num14 >= 1.2)
			{
				rare += 2;
			}
			else if (num14 >= 1.05)
			{
				rare++;
			}
			else if (num14 <= 0.8)
			{
				rare -= 2;
			}
			else if (num14 <= 0.95)
			{
				rare--;
			}
			if (rare > -11)
			{
				if (rare < -1)
				{
					rare = -1;
				}
				if (rare > 11)
				{
					rare = 11;
				}
			}
			num14 *= num14;
			value = (int)(value * num14);
			prefix = (byte)num;
			return true;
		}

		public void ResetStats(int Type)
		{
			sentry = false;
			DD2Summon = false;
			shopSpecialCurrency = -1;
			shopCustomPrice = null;
			expert = false;
			expertOnly = false;
			instanced = false;
			thrown = false;
			questItem = false;
			fishingPole = 0;
			bait = 0;
			hairDye = -1;
			makeNPC = 0;
			dye = 0;
			paint = 0;
			tileWand = -1;
			notAmmo = false;
			netID = 0;
			prefix = 0;
			crit = 0;
			mech = false;
			flame = false;
			reuseDelay = 0;
			melee = false;
			magic = false;
			ranged = false;
			summon = false;
			placeStyle = 0;
			buffTime = 0;
			buffType = 0;
			mountType = -1;
			cartTrack = false;
			material = false;
			noWet = false;
			vanity = false;
			mana = 0;
			wet = false;
			wetCount = 0;
			lavaWet = false;
			channel = false;
			manaIncrease = 0;
			release = 0;
			noMelee = false;
			noUseGraphic = false;
			lifeRegen = 0;
			shootSpeed = 0f;
			active = true;
			alpha = 0;
			ammo = AmmoID.None;
			useAmmo = AmmoID.None;
			autoReuse = false;
			accessory = false;
			axe = 0;
			healMana = 0;
			bodySlot = -1;
			legSlot = -1;
			headSlot = -1;
			potion = false;
			color = default(Color);
			glowMask = -1;
			consumable = false;
			createTile = -1;
			createWall = -1;
			damage = -1;
			defense = 0;
			hammer = 0;
			healLife = 0;
			holdStyle = 0;
			knockBack = 0f;
			maxStack = 1;
			pick = 0;
			rare = 0;
			scale = 1f;
			shoot = 0;
			stack = 1;
			toolTip = null;
			toolTip2 = null;
			tileBoost = 0;
			useStyle = 0;
			useTime = 100;
			useAnimation = 100;
			value = 0;
			useTurn = false;
			buy = false;
			handOnSlot = -1;
			handOffSlot = -1;
			backSlot = -1;
			frontSlot = -1;
			shoeSlot = -1;
			waistSlot = -1;
			wingSlot = -1;
			shieldSlot = -1;
			neckSlot = -1;
			faceSlot = -1;
			balloonSlot = -1;
			uniqueStack = false;
			favorited = false;
			type = Type;
		}

		public static int sellPrice(int platinum = 0, int gold = 0, int silver = 0, int copper = 0)
		{
			int num = copper + silver * 100;
			num += gold * 100 * 100;
			num += platinum * 100 * 100 * 100;
			return num * 5;
		}

		public void SetDefaults(string ItemName)
		{
			if (ServerApi.Hooks.InvokeItemSetDefaultsString(ref ItemName, this))
				return;

			name = "";
			bool flag = false;
			if (ItemName != "")
			{
				for (int i = 0; i < Main.maxItemTypes; i++)
				{
					if (Main.itemName[i] == ItemName)
					{
						SetDefaults(i, false);
						checkMat();
						return;
					}
				}
				name = "";
				stack = 0;
				type = 0;
			}
			if (type != 0)
			{
				if (flag)
				{
					material = false;
				}
				else
				{
					checkMat();
				}
				name = ItemName;
				name = Lang.itemName(netID, false);
				CheckTip();
			}
		}

		public void SetDefaults(int Type = 0, bool noMatCheck = false)
		{
			if (ServerApi.Hooks.InvokeItemSetDefaultsInt(ref type, this))
				return;

			owner = 255;
			ResetStats(Type);
			if (type >= 3884)
			{
				type = 0;
			}
			if (type == 0)
			{
				netID = 0;
				name = "";
				stack = 0;
			}
			else if (type <= 1000)
			{
				SetDefaults1(type);
			}
			else if (type <= 2001)
			{
				SetDefaults2(type);
			}
			else if (type <= 3000)
			{
				SetDefaults3(type);
			}
			else
			{
				SetDefaults4(type);
			}
			if (type == 2015)
			{
				value = Item.sellPrice(0, 0, 5, 0);
			}
			if (type == 2016)
			{
				value = Item.sellPrice(0, 0, 7, 50);
			}
			if (type == 2017)
			{
				value = Item.sellPrice(0, 0, 7, 50);
			}
			if (type == 2019)
			{
				value = Item.sellPrice(0, 0, 5, 0);
			}
			if (type == 2018)
			{
				value = Item.sellPrice(0, 0, 5, 0);
			}
			if (type == 3563)
			{
				value = Item.sellPrice(0, 0, 5, 0);
			}
			if (type == 261)
			{
				value = Item.sellPrice(0, 0, 7, 50);
			}
			if (type == 2205)
			{
				value = Item.sellPrice(0, 0, 12, 50);
			}
			if (type == 2123)
			{
				value = Item.sellPrice(0, 0, 7, 50);
			}
			if (type == 2122)
			{
				value = Item.sellPrice(0, 0, 7, 50);
			}
			if (type == 2003)
			{
				value = Item.sellPrice(0, 0, 20, 0);
			}
			if (type == 2156)
			{
				value = Item.sellPrice(0, 0, 15, 0);
			}
			if (type == 2157)
			{
				value = Item.sellPrice(0, 0, 15, 0);
			}
			if (type == 2121)
			{
				value = Item.sellPrice(0, 0, 15, 0);
			}
			if (type == 1992)
			{
				value = Item.sellPrice(0, 0, 3, 0);
			}
			if (type == 2004)
			{
				value = Item.sellPrice(0, 0, 5, 0);
			}
			if (type == 2002)
			{
				value = Item.sellPrice(0, 0, 5, 0);
			}
			if (type == 2740)
			{
				value = Item.sellPrice(0, 0, 2, 50);
			}
			if (type == 2006)
			{
				value = Item.sellPrice(0, 0, 20, 0);
			}
			if (type == 3191)
			{
				value = Item.sellPrice(0, 0, 20, 0);
			}
			if (type == 3192)
			{
				value = Item.sellPrice(0, 0, 2, 50);
			}
			if (type == 3193)
			{
				value = Item.sellPrice(0, 0, 5, 0);
			}
			if (type == 3194)
			{
				value = Item.sellPrice(0, 0, 10, 0);
			}
			if (type == 2007)
			{
				value = Item.sellPrice(0, 0, 50, 0);
			}
			if (type == 2673)
			{
				value = Item.sellPrice(0, 10, 0, 0);
			}
			if (bait > 0)
			{
				if (bait >= 50)
				{
					rare = 3;
				}
				else if (bait >= 30)
				{
					rare = 2;
				}
				else if (bait >= 15)
				{
					rare = 1;
				}
			}
			if (type >= 1994 && type <= 2001)
			{
				int num = type - 1994;
				if (num == 0)
				{
					value = Item.sellPrice(0, 0, 5, 0);
				}
				if (num == 4)
				{
					value = Item.sellPrice(0, 0, 10, 0);
				}
				if (num == 6)
				{
					value = Item.sellPrice(0, 0, 15, 0);
				}
				if (num == 3)
				{
					value = Item.sellPrice(0, 0, 20, 0);
				}
				if (num == 7)
				{
					value = Item.sellPrice(0, 0, 30, 0);
				}
				if (num == 2)
				{
					value = Item.sellPrice(0, 0, 40, 0);
				}
				if (num == 1)
				{
					value = Item.sellPrice(0, 0, 75, 0);
				}
				if (num == 5)
				{
					value = Item.sellPrice(0, 1, 0, 0);
				}
			}
			if (type == 483 || type == 1192 || type == 482 || type == 1185 || type == 484 || type == 1199 || type == 368)
			{
				autoReuse = true;
				damage = (int)((double)damage * 1.15);
			}
			if (type == 2663 || type == 1720 || type == 2137 || type == 2155 || type == 2151 || type == 1704 || type == 2143 || type == 1710 || type == 2238 || type == 2133 || type == 2147 || type == 2405 || type == 1716 || type == 1705)
			{
				value = Item.sellPrice(0, 2, 0, 0);
			}
			if (Main.projHook[shoot])
			{
				useStyle = 0;
				useTime = 0;
				useAnimation = 0;
			}
			if (type >= 1803 && type <= 1807)
			{
				SetDefaults(1533 + type - 1803, false);
			}
			if (dye > 0)
			{
				maxStack = 99;
			}
			if (createTile == 19)
			{
				maxStack = 999;
			}
			netID = type;
			if (!noMatCheck)
			{
				checkMat();
			}
			name = Lang.itemName(netID, false);
			CheckTip();
			if (type > 0 && type < 3884 && ItemID.Sets.Deprecated[type])
			{
				netID = 0;
				type = 0;
				stack = 0;
				name = "";
			}
		}

		public void SetDefaults1(int type)
		{
			if (type == 1)
			{
				name = "Iron Pickaxe";
				useStyle = 1;
				useTurn = true;
				useAnimation = 20;
				useTime = 13;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 5;
				pick = 40;
				knockBack = 2f;
				value = 2000;
				melee = true;
			}
			else if (type == 2)
			{
				name = "Dirt Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 0;
				width = 12;
				height = 12;
			}
			else if (type == 3)
			{
				name = "Stone Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 1;
				width = 12;
				height = 12;
			}
			else if (type == 4)
			{
				name = "Iron Broadsword";
				useStyle = 1;
				useTurn = false;
				useAnimation = 21;
				useTime = 21;
				width = 24;
				height = 28;
				damage = 10;
				knockBack = 5f;
				scale = 1f;
				value = 1800;
				melee = true;
			}
			else if (type == 5)
			{
				name = "Mushroom";
				useStyle = 2;
				useTurn = false;
				useAnimation = 17;
				useTime = 17;
				width = 16;
				height = 18;
				healLife = 15;
				maxStack = 99;
				consumable = true;
				potion = true;
				value = Item.sellPrice(0, 0, 2, 50);
			}
			else if (type == 6)
			{
				name = "Iron Shortsword";
				useStyle = 3;
				useTurn = false;
				useAnimation = 12;
				useTime = 12;
				width = 24;
				height = 28;
				damage = 8;
				knockBack = 4f;
				scale = 0.9f;
				useTurn = true;
				value = 1400;
				melee = true;
			}
			else if (type == 7)
			{
				name = "Iron Hammer";
				autoReuse = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 30;
				useTime = 20;
				hammer = 40;
				width = 24;
				height = 28;
				damage = 7;
				knockBack = 5.5f;
				scale = 1.2f;
				value = 1600;
				melee = true;
			}
			else if (type == 8)
			{
				flame = true;
				noWet = true;
				name = "Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				width = 10;
				height = 12;
				toolTip = "Provides light";
				value = 50;
			}
			else if (type == 9)
			{
				name = "Wood";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 30;
				width = 8;
				height = 10;
			}
			else if (type == 10)
			{
				name = "Iron Axe";
				useStyle = 1;
				useTurn = true;
				useAnimation = 27;
				knockBack = 4.5f;
				useTime = 19;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 5;
				axe = 9;
				scale = 1.1f;
				value = 1600;
				melee = true;
			}
			else if (type == 11)
			{
				name = "Iron Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 6;
				width = 12;
				height = 12;
				value = 500;
			}
			else if (type == 12)
			{
				name = "Copper Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 7;
				width = 12;
				height = 12;
				value = 250;
			}
			else if (type == 13)
			{
				name = "Gold Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 8;
				width = 12;
				height = 12;
				value = 2000;
			}
			else if (type == 14)
			{
				name = "Silver Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 9;
				width = 12;
				height = 12;
				value = 1000;
			}
			else if (type == 15)
			{
				name = "Copper Watch";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Tells the time";
				value = 1000;
				waistSlot = 2;
			}
			else if (type == 16)
			{
				name = "Silver Watch";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Tells the time";
				value = 5000;
				waistSlot = 7;
			}
			else if (type == 17)
			{
				name = "Gold Watch";
				width = 24;
				height = 28;
				accessory = true;
				rare = 1;
				toolTip = "Tells the time";
				value = 10000;
				waistSlot = 3;
			}
			else if (type == 18)
			{
				name = "Depth Meter";
				width = 24;
				height = 18;
				accessory = true;
				rare = 1;
				toolTip = "Shows depth";
				value = Item.sellPrice(0, 0, 25, 0);
			}
			else if (type == 19)
			{
				name = "Gold Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 6000;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 6;
			}
			else if (type == 20)
			{
				name = "Copper Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 750;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 0;
			}
			else if (type == 21)
			{
				name = "Silver Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 3000;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 4;
			}
			else if (type == 22)
			{
				name = "Iron Bar";
				color = new Color(160, 145, 130, 110);
				width = 20;
				height = 20;
				maxStack = 99;
				value = 1500;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 2;
			}
			else if (type == 23)
			{
				name = "Gel";
				width = 10;
				height = 12;
				maxStack = 999;
				alpha = 175;
				ammo = AmmoID.Gel;
				color = new Color(0, 80, 255, 100);
				toolTip = "'Both tasty and flammable'";
				value = 5;
				consumable = true;
			}
			else if (type == 24)
			{
				name = "Wooden Sword";
				useStyle = 1;
				useTurn = false;
				useAnimation = 25;
				width = 24;
				height = 28;
				damage = 7;
				knockBack = 4f;
				scale = 0.95f;
				value = 100;
				melee = true;
			}
			else if (type == 25)
			{
				name = "Wooden Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				width = 14;
				height = 28;
				value = 200;
			}
			else if (type == 26)
			{
				name = "Stone Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 1;
				width = 12;
				height = 12;
			}
			else if (type == 27)
			{
				name = "Acorn";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 20;
				width = 18;
				height = 18;
				value = 10;
			}
			else if (type == 28)
			{
				name = "Lesser Healing Potion";
				healLife = 50;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				potion = true;
				value = 300;
			}
			else if (type == 29)
			{
				name = "Life Crystal";
				maxStack = 99;
				consumable = true;
				width = 18;
				height = 18;
				useStyle = 4;
				useTime = 30;
				useAnimation = 30;
				toolTip = "Permanently increases maximum life by 20";
				rare = 2;
				value = 75000;
			}
			else if (type == 30)
			{
				name = "Dirt Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 16;
				width = 12;
				height = 12;
			}
			else if (type == 31)
			{
				name = "Bottle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 13;
				width = 16;
				height = 24;
				value = 20;
			}
			else if (type == 32)
			{
				name = "Wooden Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				width = 26;
				height = 20;
				value = 300;
			}
			else if (type == 33)
			{
				name = "Furnace";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 17;
				width = 26;
				height = 24;
				value = 300;
				toolTip = "Used for smelting ore";
			}
			else if (type == 34)
			{
				name = "Wooden Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				width = 12;
				height = 30;
				value = 150;
			}
			else if (type == 35)
			{
				name = "Iron Anvil";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 16;
				width = 28;
				height = 14;
				value = 5000;
				toolTip = "Used to craft items from metal bars";
			}
			else if (type == 36)
			{
				name = "Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
			}
			else if (type == 37)
			{
				name = "Goggles";
				width = 28;
				height = 12;
				defense = 1;
				headSlot = 10;
				value = 1000;
			}
			else if (type == 38)
			{
				name = "Lens";
				width = 12;
				height = 20;
				maxStack = 99;
				value = 500;
			}
			else if (type == 39)
			{
				useStyle = 5;
				useAnimation = 30;
				useTime = 30;
				name = "Wooden Bow";
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = AmmoID.Arrow;
				damage = 4;
				shootSpeed = 6.1f;
				noMelee = true;
				value = 100;
				ranged = true;
			}
			else if (type == 40)
			{
				name = "Wooden Arrow";
				shootSpeed = 3f;
				shoot = 1;
				damage = 5;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Arrow;
				knockBack = 2f;
				value = 5;
				ranged = true;
			}
			else if (type == 41)
			{
				name = "Flaming Arrow";
				shootSpeed = 3.5f;
				shoot = 2;
				damage = 7;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Arrow;
				knockBack = 2f;
				value = 10;
				ranged = true;
			}
			else if (type == 42)
			{
				useStyle = 1;
				name = "Shuriken";
				shootSpeed = 9f;
				shoot = 3;
				damage = 10;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 15;
				thrown = true;
			}
			else if (type == 43)
			{
				useStyle = 4;
				name = "Suspicious Looking Eye";
				width = 22;
				height = 14;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				maxStack = 20;
				toolTip = "Summons the Eye of Cthulhu";
			}
			else if (type == 44)
			{
				useStyle = 5;
				useAnimation = 25;
				useTime = 25;
				name = "Demon Bow";
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = AmmoID.Arrow;
				damage = 14;
				shootSpeed = 6.7f;
				knockBack = 1f;
				alpha = 30;
				rare = 1;
				noMelee = true;
				value = 18000;
				ranged = true;
			}
			else if (type == 45)
			{
				name = "War Axe of the Night";
				autoReuse = true;
				useStyle = 1;
				useAnimation = 30;
				knockBack = 6f;
				useTime = 15;
				width = 24;
				height = 28;
				damage = 20;
				axe = 15;
				scale = 1.2f;
				rare = 1;
				value = 13500;
				melee = true;
			}
			else if (type == 46)
			{
				name = "Light's Bane";
				useStyle = 1;
				useAnimation = 20;
				knockBack = 5f;
				width = 24;
				height = 28;
				damage = 17;
				scale = 1.1f;
				rare = 1;
				value = 13500;
				melee = true;
			}
			else if (type == 47)
			{
				name = "Unholy Arrow";
				shootSpeed = 3.4f;
				shoot = 4;
				damage = 12;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Arrow;
				knockBack = 3f;
				alpha = 30;
				rare = 1;
				value = 40;
				ranged = true;
			}
			else if (type == 48)
			{
				name = "Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				width = 26;
				height = 22;
				value = 500;
			}
			else if (type == 49)
			{
				name = "Band of Regeneration";
				width = 22;
				height = 22;
				accessory = true;
				lifeRegen = 1;
				rare = 1;
				toolTip = "Slowly regenerates life";
				value = 50000;
				handOnSlot = 2;
			}
			else if (type == 50)
			{
				name = "Magic Mirror";
				useTurn = true;
				width = 20;
				height = 20;
				useStyle = 4;
				useTime = 90;
				useAnimation = 90;
				toolTip = "Gaze in the mirror to return home";
				rare = 1;
				value = 50000;
			}
			else if (type == 51)
			{
				name = "Jester's Arrow";
				shootSpeed = 0.5f;
				shoot = 5;
				damage = 10;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Arrow;
				knockBack = 4f;
				rare = 1;
				value = 100;
				ranged = true;
			}
			else if (type == 52)
			{
				type = 52;
				name = "Angel Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 1;
			}
			else if (type == 53)
			{
				name = "Cloud in a Bottle";
				width = 16;
				height = 24;
				accessory = true;
				rare = 1;
				toolTip = "Allows the holder to double jump";
				value = 50000;
				waistSlot = 1;
			}
			else if (type == 54)
			{
				name = "Hermes Boots";
				width = 28;
				height = 24;
				accessory = true;
				rare = 1;
				toolTip = "The wearer can run super fast";
				value = 50000;
				shoeSlot = 6;
			}
			else if (type == 55)
			{
				noMelee = true;
				useStyle = 1;
				name = "Enchanted Boomerang";
				shootSpeed = 10f;
				shoot = 6;
				damage = 13;
				knockBack = 8f;
				width = 14;
				height = 28;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				rare = 1;
				value = 50000;
				melee = true;
			}
			else if (type == 56)
			{
				name = "Demonite Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 22;
				width = 12;
				height = 12;
				rare = 1;
				toolTip = "'Pulsing with dark energy'";
				value = 4000;
			}
			else if (type == 57)
			{
				name = "Demonite Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				rare = 1;
				toolTip = "'Pulsing with dark energy'";
				value = 16000;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 8;
			}
			else if (type == 58)
			{
				name = "Heart";
				width = 12;
				height = 12;
			}
			else if (type == 59)
			{
				name = "Corrupt Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 23;
				width = 14;
				height = 14;
				value = 500;
				autoReuse = true;
			}
			else if (type == 60)
			{
				name = "Vile Mushroom";
				width = 16;
				height = 18;
				maxStack = 99;
				value = 50;
			}
			else if (type == 61)
			{
				name = "Ebonstone Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 25;
				width = 12;
				height = 12;
			}
			else if (type == 62)
			{
				name = "Grass Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 2;
				width = 14;
				height = 14;
				value = 20;
				autoReuse = true;
			}
			else if (type == 63)
			{
				name = "Sunflower";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 27;
				width = 26;
				height = 26;
				value = 200;
			}
			else if (type == 64)
			{
				mana = 10;
				damage = 10;
				useStyle = 1;
				name = "Vilethorn";
				shootSpeed = 32f;
				shoot = 7;
				width = 26;
				height = 28;
				useAnimation = 28;
				useTime = 28;
				rare = 1;
				noMelee = true;
				knockBack = 1f;
				toolTip = "Summons a vile thorn";
				value = 10000;
				magic = true;
			}
			else if (type == 65)
			{
				knockBack = 5f;
				alpha = 100;
				color = new Color(150, 150, 150, 0);
				damage = 22;
				useStyle = 1;
				scale = 1.25f;
				name = "Starfury";
				shootSpeed = 20f;
				shoot = 9;
				width = 14;
				height = 28;
				useAnimation = 20;
				useTime = 40;
				rare = 2;
				toolTip = "Causes stars to rain from the sky";
				toolTip2 = "'Forged with the fury of heaven'";
				value = 50000;
				melee = true;
			}
			else if (type == 66)
			{
				useStyle = 1;
				name = "Purification Powder";
				shootSpeed = 4f;
				shoot = 10;
				width = 16;
				height = 24;
				maxStack = 99;
				consumable = true;
				useAnimation = 15;
				useTime = 15;
				noMelee = true;
				toolTip = "Cleanses the corruption";
				value = 75;
			}
			else if (type == 67)
			{
				damage = 0;
				useStyle = 1;
				name = "Vile Powder";
				shootSpeed = 4f;
				shoot = 11;
				width = 16;
				height = 24;
				maxStack = 99;
				consumable = true;
				useAnimation = 15;
				useTime = 15;
				noMelee = true;
				value = 100;
				toolTip = "Removes the Hallow";
			}
			else if (type == 68)
			{
				name = "Rotten Chunk";
				width = 18;
				height = 20;
				maxStack = 99;
				toolTip = "'Looks tasty!'";
				value = 10;
			}
			else if (type == 69)
			{
				name = "Worm Tooth";
				width = 8;
				height = 20;
				maxStack = 99;
				value = 100;
			}
			else if (type == 70)
			{
				useStyle = 4;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				name = "Worm Food";
				width = 28;
				height = 28;
				maxStack = 20;
				toolTip = "Summons the Eater of Worlds";
			}
			else if (type == 71)
			{
				name = "Copper Coin";
				width = 10;
				height = 10;
				maxStack = 100;
				value = 5;
				ammo = AmmoID.Coin;
				shoot = 158;
				notAmmo = true;
				damage = 25;
				shootSpeed = 1f;
				ranged = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 330;
				noMelee = true;
			}
			else if (type == 72)
			{
				name = "Silver Coin";
				width = 10;
				height = 12;
				maxStack = 100;
				value = 500;
				ammo = AmmoID.Coin;
				notAmmo = true;
				damage = 50;
				shoot = 159;
				shootSpeed = 2f;
				ranged = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 331;
				noMelee = true;
			}
			else if (type == 73)
			{
				name = "Gold Coin";
				width = 10;
				height = 14;
				maxStack = 100;
				value = 50000;
				ammo = AmmoID.Coin;
				notAmmo = true;
				damage = 100;
				shoot = 160;
				shootSpeed = 3f;
				ranged = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 332;
				noMelee = true;
			}
			else if (type == 74)
			{
				name = "Platinum Coin";
				width = 12;
				height = 14;
				maxStack = 999;
				value = 5000000;
				ammo = AmmoID.Coin;
				notAmmo = true;
				damage = 200;
				shoot = 161;
				shootSpeed = 4f;
				ranged = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 333;
				noMelee = true;
			}
			else if (type == 75)
			{
				name = "Fallen Star";
				width = 18;
				height = 20;
				maxStack = 99;
				alpha = 75;
				ammo = AmmoID.FallenStar;
				toolTip = "Disappears after the sunrise";
				value = Item.sellPrice(0, 0, 5, 0);
				useStyle = 4;
				useTurn = false;
				useAnimation = 17;
				useTime = 17;
				consumable = true;
				rare = 1;
			}
			else if (type == 76)
			{
				name = "Copper Greaves";
				width = 18;
				height = 18;
				defense = 1;
				legSlot = 1;
				value = 750;
			}
			else if (type == 77)
			{
				name = "Iron Greaves";
				width = 18;
				height = 18;
				defense = 2;
				legSlot = 2;
				value = 3000;
			}
			else if (type == 78)
			{
				name = "Silver Greaves";
				width = 18;
				height = 18;
				defense = 3;
				legSlot = 3;
				value = 7500;
			}
			else if (type == 79)
			{
				name = "Gold Greaves";
				width = 18;
				height = 18;
				defense = 4;
				legSlot = 4;
				value = 15000;
			}
			else if (type == 80)
			{
				name = "Copper Chainmail";
				width = 18;
				height = 18;
				defense = 2;
				bodySlot = 1;
				value = 1000;
			}
			else if (type == 81)
			{
				name = "Iron Chainmail";
				width = 18;
				height = 18;
				defense = 3;
				bodySlot = 2;
				value = 4000;
			}
			else if (type == 82)
			{
				name = "Silver Chainmail";
				width = 18;
				height = 18;
				defense = 4;
				bodySlot = 3;
				value = 10000;
			}
			else if (type == 83)
			{
				name = "Gold Chainmail";
				width = 18;
				height = 18;
				defense = 5;
				bodySlot = 4;
				value = 20000;
			}
			else if (type == 84)
			{
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Grappling Hook";
				shootSpeed = 11.5f;
				shoot = 13;
				width = 18;
				height = 28;
				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				value = 20000;
				toolTip = "'Get over here!'";
			}
			else if (type == 85)
			{
				name = "Chain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 8;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 214;
				width = 12;
				height = 12;
				value = 200;
				tileBoost += 3;
				toolTip = "Can be climbed on";
			}
			else if (type == 86)
			{
				name = "Shadow Scale";
				width = 14;
				height = 18;
				maxStack = 99;
				rare = 1;
				value = 500;
			}
			else if (type == 87)
			{
				name = "Piggy Bank";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 29;
				width = 20;
				height = 12;
				value = 10000;
			}
			else if (type == 88)
			{
				name = "Mining Helmet";
				width = 22;
				height = 16;
				defense = 1;
				headSlot = 11;
				rare = 1;
				value = Item.buyPrice(0, 4, 0, 0);
				toolTip = "Provides light when worn";
			}
			else if (type == 89)
			{
				name = "Copper Helmet";
				width = 18;
				height = 18;
				defense = 1;
				headSlot = 1;
				value = 1250;
			}
			else if (type == 90)
			{
				name = "Iron Helmet";
				width = 18;
				height = 18;
				defense = 2;
				headSlot = 2;
				value = 5000;
			}
			else if (type == 91)
			{
				name = "Silver Helmet";
				width = 18;
				height = 18;
				defense = 3;
				headSlot = 3;
				value = 12500;
			}
			else if (type == 92)
			{
				name = "Gold Helmet";
				width = 18;
				height = 18;
				defense = 4;
				headSlot = 4;
				value = 25000;
			}
			else if (type == 93)
			{
				name = "Wood Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 4;
				width = 12;
				height = 12;
			}
			else if (type == 94)
			{
				name = "Wood Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 19;
				width = 8;
				height = 10;
			}
			else if (type == 95)
			{
				useStyle = 5;
				useAnimation = 16;
				useTime = 16;
				name = "Flintlock Pistol";
				width = 24;
				height = 28;
				shoot = 14;
				useAmmo = AmmoID.Bullet;
				damage = 10;
				shootSpeed = 5f;
				noMelee = true;
				value = 50000;
				scale = 0.9f;
				rare = 1;
				ranged = true;
			}
			else if (type == 96)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 36;
				useTime = 36;
				name = "Musket";
				width = 44;
				height = 14;
				shoot = 10;
				useAmmo = AmmoID.Bullet;
				damage = 31;
				shootSpeed = 9f;
				noMelee = true;
				value = 100000;
				knockBack = 5.25f;
				rare = 1;
				ranged = true;
				crit = 7;
			}
			else if (type == 97)
			{
				name = "Musket Ball";
				shootSpeed = 4f;
				shoot = 14;
				damage = 7;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Bullet;
				knockBack = 2f;
				value = 7;
				ranged = true;
			}
			else if (type == 98)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 8;
				useTime = 8;
				name = "Minishark";
				width = 50;
				height = 18;
				shoot = 10;
				useAmmo = AmmoID.Bullet;
				damage = 6;
				shootSpeed = 7f;
				noMelee = true;
				value = 350000;
				rare = 2;
				toolTip = "33% chance to not consume ammo";
				toolTip2 = "'Half shark, half gun, completely awesome.'";
				ranged = true;
			}
			else if (type == 99)
			{
				useStyle = 5;
				useAnimation = 28;
				useTime = 28;
				name = "Iron Bow";
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = AmmoID.Arrow;
				damage = 8;
				shootSpeed = 6.6f;
				noMelee = true;
				value = 1400;
				ranged = true;
			}
			else if (type == 100)
			{
				name = "Shadow Greaves";
				width = 18;
				height = 18;
				defense = 6;
				legSlot = 5;
				rare = 1;
				value = 22500;
				toolTip = "7% increased melee speed";
			}
			else if (type == 101)
			{
				name = "Shadow Scalemail";
				width = 18;
				height = 18;
				defense = 7;
				bodySlot = 5;
				rare = 1;
				value = 30000;
				toolTip = "7% increased melee speed";
			}
			else if (type == 102)
			{
				name = "Shadow Helmet";
				width = 18;
				height = 18;
				defense = 6;
				headSlot = 5;
				rare = 1;
				value = 37500;
				toolTip = "7% increased melee speed";
			}
			else if (type == 103)
			{
				name = "Nightmare Pickaxe";
				useStyle = 1;
				useTurn = true;
				useAnimation = 20;
				useTime = 15;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 9;
				pick = 65;
				knockBack = 3f;
				rare = 1;
				value = 18000;
				scale = 1.15f;
				toolTip = "Able to mine Hellstone";
				melee = true;
			}
			else if (type == 104)
			{
				name = "The Breaker";
				autoReuse = true;
				useStyle = 1;
				useAnimation = 45;
				useTime = 19;
				hammer = 55;
				width = 24;
				height = 28;
				damage = 24;
				knockBack = 6f;
				scale = 1.3f;
				rare = 1;
				value = 15000;
				melee = true;
			}
			else if (type == 105)
			{
				flame = true;
				noWet = true;
				name = "Candle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 33;
				width = 8;
				height = 18;
				holdStyle = 1;
			}
			else if (type == 106)
			{
				name = "Copper Chandelier";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 34;
				width = 26;
				height = 26;
				value = 3000;
			}
			else if (type == 107)
			{
				name = "Silver Chandelier";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 34;
				placeStyle = 1;
				width = 26;
				height = 26;
				value = 12000;
			}
			else if (type == 108)
			{
				name = "Gold Chandelier";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 34;
				placeStyle = 2;
				width = 26;
				height = 26;
				value = 24000;
			}
			else if (type == 109)
			{
				name = "Mana Crystal";
				maxStack = 99;
				consumable = true;
				width = 18;
				height = 18;
				useStyle = 4;
				useTime = 30;
				useAnimation = 30;
				toolTip = "Permanently increases maximum mana by 20";
				rare = 2;
			}
			else if (type == 110)
			{
				name = "Lesser Mana Potion";
				healMana = 50;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 50;
				consumable = true;
				width = 14;
				height = 24;
				value = Item.buyPrice(0, 0, 1, 0);
			}
			else if (type == 111)
			{
				name = "Band of Starpower";
				width = 22;
				height = 22;
				accessory = true;
				rare = 1;
				toolTip = "Increases maximum mana by 20";
				value = 50000;
				handOnSlot = 3;
			}
			else if (type == 112)
			{
				mana = 15;
				damage = 48;
				useStyle = 1;
				name = "Flower of Fire";
				shootSpeed = 6f;
				shoot = 15;
				width = 26;
				height = 28;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				knockBack = 5.5f;
				toolTip = "Throws balls of fire";
				value = 10000;
				magic = true;
			}
			else if (type == 113)
			{
				mana = 10;
				channel = true;
				damage = 27;
				useStyle = 1;
				name = "Magic Missile";
				shootSpeed = 6f;
				shoot = 16;
				width = 26;
				height = 28;
				useAnimation = 17;
				useTime = 17;
				rare = 2;
				noMelee = true;
				knockBack = 7.5f;
				toolTip = "Casts a controllable missile";
				value = 10000;
				magic = true;
			}
			else if (type == 114)
			{
				channel = true;
				knockBack = 5f;
				useStyle = 1;
				name = "Dirt Rod";
				shoot = 17;
				width = 26;
				height = 28;

				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				toolTip = "Magically moves dirt";
				value = Item.buyPrice(0, 5, 0, 0);
			}
			else if (type == 115)
			{
				channel = true;
				damage = 0;
				useStyle = 4;
				name = "Shadow Orb";
				shoot = 18;
				width = 24;
				height = 24;
				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				toolTip = "Creates a magical shadow orb";
				value = 10000;
				buffType = 19;
			}
			else if (type == 116)
			{
				name = "Meteorite";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 37;
				width = 12;
				height = 12;
				value = 1000;
			}
			else if (type == 117)
			{
				name = "Meteorite Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				rare = 1;
				toolTip = "'Warm to the touch'";
				value = 7000;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 9;
			}
			else if (type == 118)
			{
				name = "Hook";
				maxStack = 99;
				width = 18;
				height = 18;
				value = 1000;
				toolTip = "Sometimes dropped by Skeletons and Piranha";
			}
			else if (type == 119)
			{
				noMelee = true;
				useStyle = 1;
				name = "Flamarang";
				shootSpeed = 11f;
				shoot = 19;
				damage = 32;
				knockBack = 8f;
				width = 14;
				height = 28;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				rare = 3;
				value = 100000;
				melee = true;
			}
			else if (type == 120)
			{
				useStyle = 5;
				useAnimation = 22;
				useTime = 22;
				name = "Molten Fury";
				width = 14;
				height = 32;
				shoot = 1;
				useAmmo = AmmoID.Arrow;
				damage = 31;
				shootSpeed = 8f;
				knockBack = 2f;
				alpha = 30;
				rare = 3;
				noMelee = true;
				scale = 1.1f;
				value = 27000;
				toolTip = "Lights wooden arrows ablaze";
				ranged = true;
			}
			else if (type == 121)
			{
				name = "Fiery Greatsword";
				useStyle = 1;
				useAnimation = 34;
				knockBack = 6.5f;
				width = 24;
				height = 28;
				damage = 36;
				scale = 1.3f;
				rare = 3;
				value = 27000;
				toolTip = "'It's made out of fire!'";
				melee = true;
			}
			if (type == 122)
			{
				name = "Molten Pickaxe";
				useStyle = 1;
				useTurn = true;
				useAnimation = 23;
				useTime = 18;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 12;
				pick = 100;
				scale = 1.15f;
				knockBack = 2f;
				rare = 3;
				value = 27000;
				melee = true;
				return;
			}
			if (type == 123)
			{
				name = "Meteor Helmet";
				width = 18;
				height = 18;
				defense = 5;
				headSlot = 6;
				rare = 1;
				value = 45000;
				toolTip = "7% increased magic damage";
				return;
			}
			if (type == 124)
			{
				name = "Meteor Suit";
				width = 18;
				height = 18;
				defense = 6;
				bodySlot = 6;
				rare = 1;
				value = 30000;
				toolTip = "7% increased magic damage";
				return;
			}
			if (type == 125)
			{
				name = "Meteor Leggings";
				width = 18;
				height = 18;
				defense = 5;
				legSlot = 6;
				rare = 1;
				value = 30000;
				toolTip = "7% increased magic damage";
				return;
			}
			if (type == 126)
			{
				name = "Bottled Water";
				healLife = 20;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 999;
				consumable = true;
				width = 14;
				height = 24;
				potion = true;
				value = 20;
				return;
			}
			if (type == 127)
			{
				autoReuse = true;
				useStyle = 5;
				useAnimation = 17;
				useTime = 17;
				name = "Space Gun";
				width = 24;
				height = 28;
				shoot = 20;
				mana = 7;

				knockBack = 0.75f;
				damage = 19;
				shootSpeed = 10f;
				noMelee = true;
				scale = 0.8f;
				rare = 1;
				magic = true;
				value = 20000;
				return;
			}
			if (type == 128)
			{
				name = "Rocket Boots";
				width = 28;
				height = 24;
				accessory = true;
				rare = 3;
				toolTip = "Allows flight";
				value = 50000;
				shoeSlot = 12;
				return;
			}
			if (type == 129)
			{
				name = "Gray Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 38;
				width = 12;
				height = 12;
				return;
			}
			if (type == 130)
			{
				name = "Gray Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 5;
				width = 12;
				height = 12;
				return;
			}
			if (type == 131)
			{
				name = "Red Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 39;
				width = 12;
				height = 12;
				return;
			}
			if (type == 132)
			{
				name = "Red Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 6;
				width = 12;
				height = 12;
				return;
			}
			if (type == 133)
			{
				name = "Clay Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 40;
				width = 12;
				height = 12;
				return;
			}
			if (type == 134)
			{
				name = "Blue Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 41;
				width = 12;
				height = 12;
				return;
			}
			if (type == 135)
			{
				name = "Blue Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 17;
				width = 12;
				height = 12;
				return;
			}
			if (type == 136)
			{
				name = "Chain Lantern";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				return;
			}
			if (type == 137)
			{
				name = "Green Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 43;
				width = 12;
				height = 12;
				return;
			}
			if (type == 138)
			{
				name = "Green Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 18;
				width = 12;
				height = 12;
				return;
			}
			if (type == 139)
			{
				name = "Pink Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 44;
				width = 12;
				height = 12;
				return;
			}
			if (type == 140)
			{
				name = "Pink Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 19;
				width = 12;
				height = 12;
				return;
			}
			if (type == 141)
			{
				name = "Gold Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 45;
				width = 12;
				height = 12;
				return;
			}
			if (type == 142)
			{
				name = "Gold Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 10;
				width = 12;
				height = 12;
				return;
			}
			if (type == 143)
			{
				name = "Silver Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 46;
				width = 12;
				height = 12;
				return;
			}
			if (type == 144)
			{
				name = "Silver Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 11;
				width = 12;
				height = 12;
				return;
			}
			if (type == 145)
			{
				name = "Copper Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 47;
				width = 12;
				height = 12;
				return;
			}
			if (type == 146)
			{
				name = "Copper Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 12;
				width = 12;
				height = 12;
				return;
			}
			if (type == 147)
			{
				name = "Spike";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 48;
				width = 12;
				height = 12;
				return;
			}
			if (type == 148)
			{
				flame = true;
				noWet = true;
				name = "Water Candle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 49;
				width = 8;
				height = 18;
				holdStyle = 1;
				toolTip = "Holding this may attract unwanted attention";
				rare = 1;
				return;
			}
			if (type == 149)
			{
				name = "Book";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 50;
				width = 24;
				height = 28;
				toolTip = "'It contains strange symbols'";
				value = Item.sellPrice(0, 0, 0, 75);
				return;
			}
			if (type == 150)
			{
				name = "Cobweb";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 51;
				width = 20;
				height = 24;
				alpha = 100;
				return;
			}
			if (type == 151)
			{
				name = "Necro Helmet";
				width = 18;
				height = 18;
				defense = 5;
				headSlot = 7;
				rare = 2;
				value = 45000;
				toolTip = "4% increased ranged damage.";
				return;
			}
			if (type == 152)
			{
				name = "Necro Breastplate";
				width = 18;
				height = 18;
				defense = 6;
				bodySlot = 7;
				rare = 2;
				value = 30000;
				toolTip = "4% increased ranged damage.";
				return;
			}
			if (type == 153)
			{
				name = "Necro Greaves";
				width = 18;
				height = 18;
				defense = 5;
				legSlot = 7;
				rare = 2;
				value = 30000;
				toolTip = "4% increased ranged damage.";
				return;
			}
			if (type == 154)
			{
				name = "Bone";
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 14;
				value = 50;
				useAnimation = 12;
				useTime = 12;
				useStyle = 1;
				shootSpeed = 8f;
				noUseGraphic = true;
				noMelee = true;
				damage = 20;
				knockBack = 2.3f;
				shoot = 21;
				thrown = true;
				ammo = 154;
				notAmmo = false;
				return;
			}
			if (type == 155)
			{
				autoReuse = true;
				useTurn = true;
				name = "Muramasa";
				useStyle = 1;
				useAnimation = 18;
				width = 40;
				height = 40;
				damage = 19;
				scale = 1.1f;
				rare = 2;
				value = 27000;
				knockBack = 2.5f;
				melee = true;
				return;
			}
			if (type == 156)
			{
				name = "Cobalt Shield";
				width = 24;
				height = 28;
				rare = 2;
				value = 27000;
				accessory = true;
				defense = 1;
				toolTip = "Grants immunity to knockback";
				shieldSlot = 1;
				return;
			}
			if (type == 157)
			{
				mana = 6;
				autoReuse = true;
				name = "Aqua Scepter";
				useStyle = 5;
				useAnimation = 16;
				useTime = 8;
				knockBack = 5f;
				width = 38;
				height = 10;
				damage = 16;
				scale = 1f;
				shoot = 22;
				shootSpeed = 12.5f;
				noMelee = true;
				rare = 2;
				value = 27000;
				toolTip = "Sprays out a shower of water";
				magic = true;
				return;
			}
			if (type == 158)
			{
				name = "Lucky Horseshoe";
				width = 20;
				height = 22;
				rare = 1;
				value = 27000;
				accessory = true;
				toolTip = "Negates fall damage";
				return;
			}
			if (type == 159)
			{
				name = "Shiny Red Balloon";
				width = 14;
				height = 28;
				rare = 1;
				value = 27000;
				accessory = true;
				toolTip = "Increases jump height";
				balloonSlot = 8;
				return;
			}
			if (type == 160)
			{
				autoReuse = true;
				noMelee = true;
				name = "Harpoon";
				useStyle = 5;
				useAnimation = 30;
				useTime = 30;
				knockBack = 6f;
				width = 30;
				height = 10;
				damage = 25;
				scale = 1.1f;
				shoot = 23;
				shootSpeed = 11f;
				rare = 2;
				value = 27000;
				ranged = true;
				return;
			}
			if (type == 161)
			{
				useStyle = 1;
				name = "Spiky Ball";
				shootSpeed = 5f;
				shoot = 24;
				knockBack = 1f;
				damage = 15;
				width = 10;
				height = 10;
				maxStack = 999;
				consumable = true;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 80;
				thrown = true;
				return;
			}
			if (type == 162)
			{
				name = "Ball O' Hurt";
				useStyle = 5;
				useAnimation = 45;
				useTime = 45;
				knockBack = 6.5f;
				width = 30;
				height = 10;
				damage = 15;
				scale = 1.1f;
				noUseGraphic = true;
				shoot = 25;
				shootSpeed = 12f;
				rare = 1;
				value = 27000;
				melee = true;
				channel = true;
				noMelee = true;
				return;
			}
			if (type == 163)
			{
				name = "Blue Moon";
				noMelee = true;
				useStyle = 5;
				useAnimation = 45;
				useTime = 45;
				knockBack = 7f;
				width = 30;
				height = 10;
				damage = 23;
				scale = 1.1f;
				noUseGraphic = true;
				shoot = 26;
				shootSpeed = 12f;
				rare = 2;
				value = 27000;
				melee = true;
				channel = true;
				return;
			}
			if (type == 164)
			{
				autoReuse = false;
				useStyle = 5;
				useAnimation = 12;
				useTime = 12;
				name = "Handgun";
				width = 24;
				height = 24;
				shoot = 14;
				knockBack = 3f;
				useAmmo = AmmoID.Bullet;
				damage = 17;
				shootSpeed = 10f;
				noMelee = true;
				value = 50000;
				scale = 0.85f;
				rare = 2;
				ranged = true;
				return;
			}
			if (type == 165)
			{
				autoReuse = true;
				rare = 2;
				mana = 10;
				name = "Water Bolt";
				noMelee = true;
				useStyle = 5;
				damage = 19;
				useAnimation = 17;
				useTime = 17;
				width = 24;
				height = 28;
				shoot = 27;
				scale = 0.9f;
				shootSpeed = 4.5f;
				knockBack = 5f;
				toolTip = "Casts a slow moving bolt of water";
				magic = true;
				value = 50000;
				return;
			}
			if (type == 166)
			{
				useStyle = 1;
				name = "Bomb";
				shootSpeed = 5f;
				shoot = 28;
				width = 20;
				height = 20;
				maxStack = 99;
				consumable = true;
				useAnimation = 25;
				useTime = 25;
				noUseGraphic = true;
				noMelee = true;
				value = Item.buyPrice(0, 0, 3, 0);
				damage = 0;
				toolTip = "A small explosion that will destroy some tiles";
				return;
			}
			if (type == 167)
			{
				useStyle = 1;
				name = "Dynamite";
				shootSpeed = 4f;
				shoot = 29;
				width = 8;
				height = 28;
				maxStack = 30;
				consumable = true;
				useAnimation = 40;
				useTime = 40;
				noUseGraphic = true;
				noMelee = true;
				value = Item.buyPrice(0, 0, 20, 0);
				rare = 1;
				toolTip = "A large explosion that will destroy most tiles";
				return;
			}
			if (type == 168)
			{
				useStyle = 5;
				name = "Grenade";
				shootSpeed = 5.5f;
				shoot = 30;
				width = 20;
				height = 20;
				maxStack = 99;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				noUseGraphic = true;
				noMelee = true;
				value = 75;
				damage = 60;
				knockBack = 8f;
				toolTip = "A small explosion that will not destroy tiles";
				thrown = true;
				return;
			}
			if (type == 169)
			{
				name = "Sand Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 53;
				width = 12;
				height = 12;
				ammo = AmmoID.Sand;
				return;
			}
			if (type == 170)
			{
				name = "Glass";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 54;
				width = 12;
				height = 12;
				return;
			}
			if (type == 171)
			{
				name = "Sign";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 55;
				width = 28;
				height = 28;
				return;
			}
			if (type == 172)
			{
				name = "Ash Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 57;
				width = 12;
				height = 12;
				return;
			}
			if (type == 173)
			{
				name = "Obsidian";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 56;
				width = 12;
				height = 12;
				return;
			}
			if (type == 174)
			{
				name = "Hellstone";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 58;
				width = 12;
				height = 12;
				rare = 2;
				return;
			}
			if (type == 175)
			{
				name = "Hellstone Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				rare = 2;
				toolTip = "'Hot to the touch'";
				value = 20000;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 10;
				return;
			}
			if (type == 176)
			{
				name = "Mud Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 59;
				width = 12;
				height = 12;
				return;
			}
			if (type == 181)
			{
				name = "Amethyst";
				createTile = 178;
				placeStyle = 0;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				alpha = 50;
				width = 10;
				height = 14;
				value = 1875;
				return;
			}
			if (type == 180)
			{
				name = "Topaz";
				createTile = 178;
				placeStyle = 1;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				alpha = 50;
				width = 10;
				height = 14;
				value = 3750;
				return;
			}
			if (type == 177)
			{
				name = "Sapphire";
				createTile = 178;
				placeStyle = 2;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				alpha = 50;
				width = 10;
				height = 14;
				value = 5625;
				return;
			}
			if (type == 179)
			{
				name = "Emerald";
				createTile = 178;
				placeStyle = 3;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				alpha = 50;
				width = 10;
				height = 14;
				value = 7500;
				return;
			}
			if (type == 178)
			{
				name = "Ruby";
				createTile = 178;
				placeStyle = 4;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				alpha = 50;
				width = 10;
				height = 14;
				value = 11250;
				return;
			}
			if (type == 182)
			{
				name = "Diamond";
				createTile = 178;
				placeStyle = 5;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				alpha = 50;
				width = 10;
				height = 14;
				value = 15000;
				return;
			}
			if (type == 183)
			{
				name = "Glowing Mushroom";
				width = 16;
				height = 18;
				value = 50;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 190;
				return;
			}
			if (type == 184)
			{
				name = "Star";
				width = 12;
				height = 12;
				return;
			}
			if (type == 185)
			{
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Ivy Whip";
				shootSpeed = 13f;
				shoot = 32;
				width = 18;
				height = 28;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				value = 20000;
				return;
			}
			if (type == 186)
			{
				name = "Breathing Reed";
				width = 44;
				height = 44;
				rare = 1;
				value = 10000;
				holdStyle = 2;
				toolTip = "'Because not drowning is kinda nice'";
				return;
			}
			if (type == 187)
			{
				name = "Flipper";
				width = 28;
				height = 28;
				rare = 1;
				value = 10000;
				accessory = true;
				toolTip = "Grants the ability to swim";
				shoeSlot = 1;
				return;
			}
			if (type == 188)
			{
				name = "Healing Potion";
				healLife = 100;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				rare = 1;
				potion = true;
				value = 1000;
				return;
			}
			if (type == 189)
			{
				name = "Mana Potion";
				healMana = 100;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 75;
				consumable = true;
				width = 14;
				height = 24;
				rare = 1;
				value = Item.buyPrice(0, 0, 2, 50);
				return;
			}
			if (type == 190)
			{
				name = "Blade of Grass";
				useStyle = 1;
				useAnimation = 30;
				knockBack = 3f;
				width = 40;
				height = 40;
				damage = 28;
				scale = 1.4f;
				rare = 3;
				value = 27000;
				melee = true;
				return;
			}
			if (type == 191)
			{
				noMelee = true;
				useStyle = 1;
				name = "Thorn Chakram";
				shootSpeed = 11f;
				shoot = 33;
				damage = 25;
				knockBack = 8f;
				width = 14;
				height = 28;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				rare = 3;
				value = 50000;
				melee = true;
				return;
			}
			if (type == 192)
			{
				name = "Obsidian Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 75;
				width = 12;
				height = 12;
				return;
			}
			if (type == 193)
			{
				name = "Obsidian Skull";
				width = 20;
				height = 22;
				rare = 2;
				value = 27000;
				accessory = true;
				defense = 1;
				toolTip = "Grants immunity to fire blocks";
				return;
			}
			if (type == 194)
			{
				autoReuse = true;
				name = "Mushroom Grass Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 70;
				width = 14;
				height = 14;
				value = 150;
				return;
			}
			if (type == 195)
			{
				autoReuse = true;
				name = "Jungle Grass Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 60;
				width = 14;
				height = 14;
				value = 150;
				return;
			}
			if (type == 196)
			{
				name = "Wooden Hammer";
				autoReuse = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 37;
				useTime = 25;
				hammer = 25;
				width = 24;
				height = 28;
				damage = 2;
				knockBack = 5.5f;
				scale = 1.2f;
				tileBoost = -1;
				value = 50;
				melee = true;
				return;
			}
			if (type == 197)
			{
				autoReuse = true;
				useStyle = 5;
				useAnimation = 12;
				useTime = 12;
				name = "Star Cannon";
				width = 50;
				height = 18;
				shoot = 12;
				useAmmo = AmmoID.FallenStar;
				damage = 55;
				shootSpeed = 14f;
				noMelee = true;
				value = 500000;
				rare = 2;
				toolTip = "Shoots fallen stars";
				ranged = true;
				return;
			}
			if (type == 198)
			{
				name = "Blue Phaseblade";
				useStyle = 1;
				useAnimation = 25;
				knockBack = 3f;
				width = 40;
				height = 40;
				damage = 21;
				scale = 1f;
				rare = 1;
				value = 27000;
				melee = true;
				return;
			}
			if (type == 199)
			{
				name = "Red Phaseblade";
				useStyle = 1;
				useAnimation = 25;
				knockBack = 3f;
				width = 40;
				height = 40;
				damage = 21;
				scale = 1f;
				rare = 1;
				value = 27000;
				melee = true;
				return;
			}
			if (type == 200)
			{
				name = "Green Phaseblade";
				useStyle = 1;
				useAnimation = 25;
				knockBack = 3f;
				width = 40;
				height = 40;
				damage = 21;
				scale = 1f;
				rare = 1;
				value = 27000;
				melee = true;
				return;
			}
			if (type == 201)
			{
				name = "Purple Phaseblade";
				useStyle = 1;
				useAnimation = 25;
				knockBack = 3f;
				width = 40;
				height = 40;
				damage = 21;
				scale = 1f;
				rare = 1;
				value = 27000;
				melee = true;
				return;
			}
			if (type == 202)
			{
				name = "White Phaseblade";
				useStyle = 1;
				useAnimation = 25;
				knockBack = 3f;
				width = 40;
				height = 40;
				damage = 21;
				scale = 1f;
				rare = 1;
				value = 27000;
				melee = true;
				return;
			}
			if (type == 203)
			{
				name = "Yellow Phaseblade";
				useStyle = 1;
				useAnimation = 25;
				knockBack = 3f;
				width = 40;
				height = 40;
				damage = 21;
				scale = 1f;
				rare = 1;
				value = 27000;
				melee = true;
				return;
			}
			if (type == 204)
			{
				name = "Meteor Hamaxe";
				useTurn = true;
				autoReuse = true;
				useStyle = 1;
				useAnimation = 30;
				useTime = 16;
				hammer = 60;
				axe = 20;
				width = 24;
				height = 28;
				damage = 20;
				knockBack = 7f;
				scale = 1.2f;
				rare = 1;
				value = 15000;
				melee = true;
				return;
			}
			if (type == 205)
			{
				name = "Empty Bucket";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				width = 20;
				height = 20;
				headSlot = 13;
				defense = 1;
				maxStack = 99;
				autoReuse = true;
				return;
			}
			if (type == 206)
			{
				name = "Water Bucket";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				width = 20;
				height = 20;
				maxStack = 99;
				autoReuse = true;
				return;
			}
			if (type == 207)
			{
				name = "Lava Bucket";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				width = 20;
				height = 20;
				maxStack = 99;
				autoReuse = true;
				return;
			}
			if (type == 208)
			{
				name = "Jungle Rose";
				width = 20;
				height = 20;
				value = 100;
				headSlot = 23;
				toolTip = "'It's pretty, oh so pretty'";
				vanity = true;
				return;
			}
			if (type == 209)
			{
				name = "Stinger";
				width = 16;
				height = 18;
				maxStack = 99;
				value = 200;
				return;
			}
			if (type == 210)
			{
				name = "Vine";
				width = 14;
				height = 20;
				maxStack = 99;
				value = 1000;
				return;
			}
			if (type == 211)
			{
				name = "Feral Claws";
				width = 20;
				height = 20;
				accessory = true;
				rare = 3;
				toolTip = "12% increased melee speed";
				value = 50000;
				handOnSlot = 5;
				handOffSlot = 9;
				return;
			}
			if (type == 212)
			{
				name = "Anklet of the Wind";
				width = 20;
				height = 20;
				accessory = true;
				rare = 3;
				toolTip = "10% increased movement speed";
				value = 50000;
				return;
			}
			if (type == 213)
			{
				name = "Staff of Regrowth";
				useStyle = 1;
				useTurn = true;
				useAnimation = 25;
				useTime = 13;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 7;
				createTile = 2;

				knockBack = 3f;
				rare = 3;
				value = 2000;
				toolTip = "Creates grass on dirt";
				melee = true;
				return;
			}
			if (type == 214)
			{
				name = "Hellstone Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 76;
				width = 12;
				height = 12;
				return;
			}
			if (type == 215)
			{
				name = "Whoopie Cushion";
				width = 18;
				height = 18;
				useTurn = true;
				useTime = 30;
				useAnimation = 30;
				noUseGraphic = true;
				useStyle = 10;
				rare = 2;
				toolTip = "'May annoy others'";
				value = 100;
				return;
			}
			if (type == 216)
			{
				name = "Shackle";
				width = 20;
				height = 20;
				rare = 1;
				value = 1500;
				accessory = true;
				defense = 1;
				handOffSlot = 7;
				handOnSlot = 12;
				return;
			}
			if (type == 217)
			{
				name = "Molten Hamaxe";
				useTurn = true;
				autoReuse = true;
				useStyle = 1;
				useAnimation = 27;
				useTime = 14;
				hammer = 70;
				axe = 30;
				width = 24;
				height = 28;
				damage = 20;
				knockBack = 7f;
				scale = 1.4f;
				rare = 3;
				value = 15000;
				melee = true;
				return;
			}
			if (type == 218)
			{
				mana = 12;
				channel = true;
				damage = 40;
				useStyle = 1;
				name = "Flamelash";
				shootSpeed = 6f;
				shoot = 34;
				width = 26;
				height = 28;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				knockBack = 6.5f;
				toolTip = "Summons a controllable ball of fire";
				value = 10000;
				magic = true;
				return;
			}
			if (type == 219)
			{
				autoReuse = false;
				useStyle = 5;
				useAnimation = 11;
				useTime = 11;
				name = "Phoenix Blaster";
				width = 24;
				height = 22;
				shoot = 14;
				knockBack = 2f;
				useAmmo = AmmoID.Bullet;
				damage = 24;
				shootSpeed = 13f;
				noMelee = true;
				value = 50000;
				scale = 0.85f;
				rare = 3;
				ranged = true;
				return;
			}
			if (type == 220)
			{
				name = "Sunfury";
				noMelee = true;
				useStyle = 5;
				useAnimation = 45;
				useTime = 45;
				knockBack = 7.75f;
				width = 30;
				height = 10;
				damage = 35;
				crit = 7;
				scale = 1.1f;
				noUseGraphic = true;
				shoot = 35;
				shootSpeed = 12f;
				rare = 3;
				value = 27000;
				melee = true;
				channel = true;
				return;
			}
			if (type == 221)
			{
				name = "Hellforge";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 77;
				width = 26;
				height = 24;
				value = 3000;
				return;
			}
			if (type == 222)
			{
				name = "Clay Pot";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 78;
				width = 14;
				height = 14;
				value = 100;
				toolTip = "Grows plants";
				return;
			}
			if (type == 223)
			{
				name = "Nature's Gift";
				width = 20;
				height = 22;
				rare = 3;
				value = 27000;
				accessory = true;
				toolTip = "6% reduced mana usage";
				faceSlot = 1;
				return;
			}
			if (type == 224)
			{
				name = "Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				width = 28;
				height = 20;
				value = 2000;
				return;
			}
			if (type == 225)
			{
				name = "Silk";
				maxStack = 999;
				width = 22;
				height = 22;
				value = 1000;
				return;
			}
			if (type == 226 || type == 227)
			{
				type = 227;
				name = "Restoration Potion";
				healMana = 80;
				healLife = 80;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 20;
				consumable = true;
				width = 14;
				height = 24;
				potion = true;
				value = 1500;
				rare = 1;
				return;
			}
			if (type == 228)
			{
				name = "Jungle Hat";
				width = 18;
				height = 18;
				defense = 5;
				headSlot = 8;
				rare = 3;
				value = 45000;
				toolTip = "Increases maximum mana by 40";
				toolTip2 = "4% increased magic critical strike chance";
				return;
			}
			if (type == 229)
			{
				name = "Jungle Shirt";
				width = 18;
				height = 18;
				defense = 6;
				bodySlot = 8;
				rare = 3;
				value = 30000;
				toolTip = "Increases maximum mana by 20";
				toolTip2 = "4% increased magic critical strike chance";
				return;
			}
			if (type == 230)
			{
				name = "Jungle Pants";
				width = 18;
				height = 18;
				defense = 6;
				legSlot = 8;
				rare = 3;
				value = 30000;
				toolTip = "Increases maximum mana by 20";
				toolTip2 = "4% increased magic critical strike chance";
				return;
			}
			if (type == 231)
			{
				name = "Molten Helmet";
				width = 18;
				height = 18;
				defense = 8;
				headSlot = 9;
				rare = 3;
				value = 45000;
				return;
			}
			if (type == 232)
			{
				name = "Molten Breastplate";
				width = 18;
				height = 18;
				defense = 9;
				bodySlot = 9;
				rare = 3;
				value = 30000;
				return;
			}
			if (type == 233)
			{
				name = "Molten Greaves";
				width = 18;
				height = 18;
				defense = 8;
				legSlot = 9;
				rare = 3;
				value = 30000;
				return;
			}
			if (type == 234)
			{
				name = "Meteor Shot";
				shootSpeed = 3f;
				shoot = 36;
				damage = 9;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Bullet;
				knockBack = 1f;
				value = 8;
				rare = 1;
				ranged = true;
				return;
			}
			if (type == 235)
			{
				useStyle = 1;
				name = "Sticky Bomb";
				shootSpeed = 5f;
				shoot = 37;
				width = 20;
				height = 20;
				maxStack = 50;
				consumable = true;

				useAnimation = 25;
				useTime = 25;
				noUseGraphic = true;
				noMelee = true;
				value = 500;
				damage = 0;
				toolTip = "'Tossing may be difficult.'";
				return;
			}
			if (type == 236)
			{
				name = "Black Lens";
				width = 12;
				height = 20;
				maxStack = 99;
				value = 5000;
				return;
			}
			if (type == 237)
			{
				name = "Sunglasses";
				width = 28;
				height = 12;
				headSlot = 12;
				rare = 2;
				value = 10000;
				toolTip = "'Makes you look cool!'";
				vanity = true;
				return;
			}
			if (type == 238)
			{
				name = "Wizard Hat";
				width = 28;
				height = 20;
				headSlot = 14;
				rare = 2;
				value = 10000;
				defense = 2;
				toolTip = "15% increased magic damage";
				return;
			}
			if (type == 239)
			{
				name = "Top Hat";
				width = 18;
				height = 18;
				headSlot = 15;
				value = 10000;
				vanity = true;
				return;
			}
			if (type == 240)
			{
				name = "Tuxedo Shirt";
				width = 18;
				height = 18;
				bodySlot = 10;
				value = 5000;
				vanity = true;
				return;
			}
			if (type == 241)
			{
				name = "Tuxedo Pants";
				width = 18;
				height = 18;
				legSlot = 10;
				value = 5000;
				vanity = true;
				return;
			}
			if (type == 242)
			{
				name = "Summer Hat";
				width = 18;
				height = 18;
				headSlot = 16;
				value = 10000;
				vanity = true;
				return;
			}
			if (type == 243)
			{
				name = "Bunny Hood";
				width = 18;
				height = 18;
				headSlot = 17;
				value = 20000;
				vanity = true;
				return;
			}
			if (type == 244)
			{
				name = "Plumber's Hat";
				width = 18;
				height = 12;
				headSlot = 18;
				value = 10000;
				vanity = true;
				return;
			}
			if (type == 245)
			{
				name = "Plumber's Shirt";
				width = 18;
				height = 18;
				bodySlot = 11;
				value = 250000;
				vanity = true;
				return;
			}
			if (type == 246)
			{
				name = "Plumber's Pants";
				width = 18;
				height = 18;
				legSlot = 11;
				value = 250000;
				vanity = true;
				return;
			}
			if (type == 247)
			{
				name = "Hero's Hat";
				width = 18;
				height = 12;
				headSlot = 19;
				value = 10000;
				vanity = true;
				return;
			}
			if (type == 248)
			{
				name = "Hero's Shirt";
				width = 18;
				height = 18;
				bodySlot = 12;
				value = 5000;
				vanity = true;
				return;
			}
			if (type == 249)
			{
				name = "Hero's Pants";
				width = 18;
				height = 18;
				legSlot = 12;
				value = 5000;
				vanity = true;
				return;
			}
			if (type == 250)
			{
				name = "Fish Bowl";
				width = 18;
				height = 18;
				headSlot = 20;
				value = 10000;
				vanity = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 282;
				width = 12;
				height = 12;
				return;
			}
			if (type == 251)
			{
				name = "Archaeologist's Hat";
				width = 18;
				height = 12;
				headSlot = 21;
				value = 10000;
				vanity = true;
				return;
			}
			if (type == 252)
			{
				name = "Archaeologist's Jacket";
				width = 18;
				height = 18;
				bodySlot = 13;
				value = 5000;
				vanity = true;
				return;
			}
			if (type == 253)
			{
				name = "Archaeologist's Pants";
				width = 18;
				height = 18;
				legSlot = 13;
				value = 5000;
				vanity = true;
				return;
			}
			if (type == 254)
			{
				name = "Black Thread";
				maxStack = 99;
				width = 12;
				height = 20;
				value = 10000;
				return;
			}
			if (type == 255)
			{
				name = "Green Thread";
				maxStack = 99;
				width = 12;
				height = 20;
				value = 2000;
				return;
			}
			if (type == 256)
			{
				name = "Ninja Hood";
				width = 18;
				height = 12;
				headSlot = 22;
				value = 10000;
				defense = 2;
				rare = 1;
				toolTip = "20% increased throwing velocity";
				return;
			}
			if (type == 257)
			{
				name = "Ninja Shirt";
				width = 18;
				height = 18;
				bodySlot = 14;
				value = 5000;
				defense = 4;
				rare = 1;
				toolTip = "15% increased throwing damage";
				return;
			}
			if (type == 258)
			{
				name = "Ninja Pants";
				width = 18;
				height = 18;
				legSlot = 14;
				value = 5000;
				defense = 3;
				rare = 1;
				toolTip = "10% increased throwing critical strike chance";
				return;
			}
			if (type == 259)
			{
				name = "Leather";
				width = 18;
				height = 20;
				maxStack = 99;
				value = 50;
				return;
			}
			if (type == 260)
			{
				name = "Red Hat";
				width = 18;
				height = 14;
				headSlot = 24;
				value = 1000;
				vanity = true;
				return;
			}
			if (type == 261)
			{
				name = "Goldfish";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				noUseGraphic = true;
				makeNPC = 55;
				return;
			}
			if (type == 262)
			{
				name = "Robe";
				width = 18;
				height = 14;
				bodySlot = 15;
				value = 2000;
				vanity = true;
				return;
			}
			if (type == 263)
			{
				name = "Robot Hat";
				width = 18;
				height = 18;
				headSlot = 25;
				value = 10000;
				vanity = true;
				return;
			}
			if (type == 264)
			{
				name = "Gold Crown";
				width = 18;
				height = 18;
				headSlot = 26;
				value = 10000;
				vanity = true;
				return;
			}
			if (type == 265)
			{
				name = "Hellfire Arrow";
				shootSpeed = 6.5f;
				shoot = 41;
				damage = 13;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Arrow;
				knockBack = 8f;
				value = 100;
				rare = 2;
				ranged = true;
				return;
			}
			if (type == 266)
			{
				useStyle = 5;
				useAnimation = 16;
				useTime = 16;
				autoReuse = true;
				name = "Sandgun";
				width = 40;
				height = 20;
				shoot = 42;
				useAmmo = AmmoID.Sand;

				damage = 30;
				shootSpeed = 12f;
				noMelee = true;
				knockBack = 5f;
				value = 10000;
				rare = 2;
				toolTip = "'This is a good idea!'";
				ranged = true;
				return;
			}
			if (type == 267)
			{
				accessory = true;
				name = "Guide Voodoo Doll";
				width = 14;
				height = 26;
				value = 1000;
				toolTip = "'You are a terrible person.'";
				return;
			}
			if (type == 268)
			{
				headSlot = 27;
				defense = 2;
				name = "Diving Helmet";
				width = 20;
				height = 20;
				value = 1000;
				rare = 2;
				toolTip = "Greatly extends underwater breathing";
				return;
			}
			if (type == 269)
			{
				name = "Familiar Shirt";
				bodySlot = 0;
				width = 20;
				height = 20;
				value = 10000;
				color = Main.player[Main.myPlayer].shirtColor;
				vanity = true;
				return;
			}
			if (type == 270)
			{
				name = "Familiar Pants";
				legSlot = 0;
				width = 20;
				height = 20;
				value = 10000;
				color = Main.player[Main.myPlayer].pantsColor;
				vanity = true;
				return;
			}
			if (type == 271)
			{
				name = "Familiar Wig";
				headSlot = 0;
				width = 20;
				height = 20;
				value = 10000;
				color = Main.player[Main.myPlayer].hairColor;
				vanity = true;
				return;
			}
			if (type == 272)
			{
				mana = 14;
				damage = 35;
				useStyle = 5;
				name = "Demon Scythe";
				shootSpeed = 0.2f;
				shoot = 45;
				width = 26;
				height = 28;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				knockBack = 5f;
				scale = 0.9f;
				toolTip = "Casts a demon scythe";
				value = 10000;
				magic = true;
				return;
			}
			if (type == 273)
			{
				name = "Night's Edge";
				useStyle = 1;
				useAnimation = 27;
				useTime = 27;
				knockBack = 4.5f;
				width = 40;
				height = 40;
				damage = 42;
				scale = 1.15f;

				rare = 3;
				value = 54000;
				melee = true;
				return;
			}
			if (type == 274)
			{
				name = "Dark Lance";
				useStyle = 5;
				useAnimation = 22;
				useTime = 22;
				shootSpeed = 6f;
				knockBack = 5f;
				width = 40;
				height = 40;
				damage = 29;
				scale = 1.1f;

				shoot = 46;
				rare = 3;
				value = 27000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			}
			if (type == 275)
			{
				name = "Coral";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 81;
				width = 20;
				height = 22;
				value = 400;
				return;
			}
			if (type == 276)
			{
				name = "Cactus";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 188;
				width = 12;
				height = 12;
				value = 10;
				return;
			}
			if (type == 277)
			{
				name = "Trident";
				useStyle = 5;
				useAnimation = 31;
				useTime = 31;
				shootSpeed = 4f;
				knockBack = 5f;
				width = 40;
				height = 40;
				damage = 11;
				scale = 1.1f;

				shoot = 47;
				rare = 1;
				value = 10000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			}
			if (type == 278)
			{
				name = "Silver Bullet";
				shootSpeed = 4.5f;
				shoot = 14;
				damage = 9;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Bullet;
				knockBack = 3f;
				value = 15;
				ranged = true;
				return;
			}
			if (type == 279)
			{
				useStyle = 1;
				name = "Throwing Knife";
				shootSpeed = 10f;
				shoot = 48;
				damage = 12;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;

				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 50;
				knockBack = 2f;
				thrown = true;
				return;
			}
			if (type == 280)
			{
				name = "Spear";
				useStyle = 5;
				useAnimation = 31;
				useTime = 31;
				shootSpeed = 3.7f;
				knockBack = 6.5f;
				width = 32;
				height = 32;
				damage = 8;
				scale = 1f;

				shoot = 49;
				value = 1000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			}
			if (type == 281)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 45;
				useTime = 45;
				name = "Blowpipe";
				width = 38;
				height = 6;
				shoot = 10;
				useAmmo = AmmoID.Dart;

				damage = 9;
				shootSpeed = 11f;
				noMelee = true;
				value = 10000;
				knockBack = 3.5f;
				toolTip = "Allows the collection of seeds for ammo";
				ranged = true;
				return;
			}
			if (type == 282)
			{
				color = new Color(255, 255, 255, 0);
				useStyle = 1;
				name = "Glowstick";
				shootSpeed = 6f;
				shoot = 50;
				width = 12;
				height = 12;
				maxStack = 99;
				consumable = true;

				useAnimation = 15;
				useTime = 15;
				noMelee = true;
				value = 10;
				holdStyle = 1;
				toolTip = "Works when wet";
				return;
			}
			if (type == 283)
			{
				name = "Seed";
				shoot = 51;
				width = 8;
				height = 8;
				maxStack = 999;
				ammo = AmmoID.Dart;
				toolTip = "For use with Blowpipe";
				damage = 3;
				ranged = true;
				consumable = true;
				return;
			}
			if (type == 284)
			{
				noMelee = true;
				useStyle = 1;
				name = "Wooden Boomerang";
				shootSpeed = 6.5f;
				shoot = 52;
				damage = 8;
				knockBack = 5f;
				width = 14;
				height = 28;

				useAnimation = 16;
				useTime = 16;
				noUseGraphic = true;
				value = 5000;
				melee = true;
				return;
			}
			if (type == 285)
			{
				name = "Aglet";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "5% increased movement speed";
				value = 5000;
				return;
			}
			if (type == 286)
			{
				color = new Color(255, 255, 255, 0);
				useStyle = 1;
				name = "Sticky Glowstick";
				shootSpeed = 6f;
				shoot = 53;
				width = 12;
				height = 12;
				maxStack = 99;
				consumable = true;

				useAnimation = 15;
				useTime = 15;
				noMelee = true;
				value = 20;
				holdStyle = 1;
				return;
			}
			if (type == 287)
			{
				crit = 4;
				useStyle = 1;
				name = "Poisoned Knife";
				shootSpeed = 12f;
				shoot = 54;
				damage = 14;
				autoReuse = true;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;

				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 60;
				knockBack = 2.4f;
				thrown = true;
				return;
			}
			if (type == 288)
			{
				name = "Obsidian Skin Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 1;
				buffTime = 14400;
				toolTip = "Provides immunity to lava";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 289)
			{
				name = "Regeneration Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 2;
				buffTime = 18000;
				toolTip = "Provides life regeneration";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 290)
			{
				name = "Swiftness Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 3;
				buffTime = 14400;
				toolTip = "25% increased movement speed";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 291)
			{
				name = "Gills Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 4;
				buffTime = 7200;
				toolTip = "Breathe water instead of air";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 292)
			{
				name = "Ironskin Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 5;
				buffTime = 18000;
				toolTip = "Increase defense by 8";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 293)
			{
				name = "Mana Regeneration Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 6;
				buffTime = 25200;
				toolTip = "Increased mana regeneration";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 294)
			{
				name = "Magic Power Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 7;
				buffTime = 7200;
				toolTip = "20% increased magic damage";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 295)
			{
				name = "Featherfall Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 8;
				buffTime = 18000;
				toolTip = "Slows falling speed";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 296)
			{
				name = "Spelunker Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 9;
				buffTime = 18000;
				toolTip = "Shows the location of treasure and ore";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 297)
			{
				name = "Invisibility Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 10;
				buffTime = 7200;
				toolTip = "Grants invisibility";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 298)
			{
				name = "Shine Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 11;
				buffTime = 18000;
				toolTip = "Emits an aura of light";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 299)
			{
				name = "Night Owl Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 12;
				buffTime = 14400;
				toolTip = "Increases night vision";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 300)
			{
				name = "Battle Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 13;
				buffTime = 25200;
				toolTip = "Increases enemy spawn rate";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 301)
			{
				name = "Thorns Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 14;
				buffTime = 7200;
				toolTip = "Attackers also take damage";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 302)
			{
				name = "Water Walking Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 15;
				buffTime = 18000;
				toolTip = "Allows the ability to walk on water";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 303)
			{
				name = "Archery Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 16;
				buffTime = 14400;
				toolTip = "20% increased arrow speed and damage";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 304)
			{
				name = "Hunter Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 17;
				buffTime = 18000;
				toolTip = "Shows the location of enemies";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 305)
			{
				name = "Gravitation Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 18;
				buffTime = 10800;
				toolTip = "Allows the control of gravity";
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 306)
			{
				name = "Gold Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 1;
				width = 26;
				height = 22;
				value = 5000;
				return;
			}
			if (type == 307)
			{
				autoReuse = true;
				name = "Daybloom Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 82;
				placeStyle = 0;
				width = 12;
				height = 14;
				value = 80;
				return;
			}
			if (type == 308)
			{
				autoReuse = true;
				name = "Moonglow Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 82;
				placeStyle = 1;
				width = 12;
				height = 14;
				value = 80;
				return;
			}
			if (type == 309)
			{
				autoReuse = true;
				name = "Blinkroot Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 82;
				placeStyle = 2;
				width = 12;
				height = 14;
				value = 80;
				return;
			}
			if (type == 310)
			{
				autoReuse = true;
				name = "Deathweed Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 82;
				placeStyle = 3;
				width = 12;
				height = 14;
				value = 80;
				return;
			}
			if (type == 311)
			{
				autoReuse = true;
				name = "Waterleaf Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 82;
				placeStyle = 4;
				width = 12;
				height = 14;
				value = 80;
				return;
			}
			if (type == 312)
			{
				autoReuse = true;
				name = "Fireblossom Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 82;
				placeStyle = 5;
				width = 12;
				height = 14;
				value = 80;
				return;
			}
			if (type == 313)
			{
				name = "Daybloom";
				maxStack = 99;
				width = 12;
				height = 14;
				value = 100;
				return;
			}
			if (type == 314)
			{
				name = "Moonglow";
				maxStack = 99;
				width = 12;
				height = 14;
				value = 100;
				return;
			}
			if (type == 315)
			{
				name = "Blinkroot";
				maxStack = 99;
				width = 12;
				height = 14;
				value = 100;
				return;
			}
			if (type == 316)
			{
				name = "Deathweed";
				maxStack = 99;
				width = 12;
				height = 14;
				value = 100;
				return;
			}
			if (type == 317)
			{
				name = "Waterleaf";
				maxStack = 99;
				width = 12;
				height = 14;
				value = 100;
				return;
			}
			if (type == 318)
			{
				name = "Fireblossom";
				maxStack = 99;
				width = 12;
				height = 14;
				value = 100;
				return;
			}
			if (type == 319)
			{
				name = "Shark Fin";
				maxStack = 99;
				width = 16;
				height = 14;
				value = 200;
				color = new Color(123, 167, 163, 255);
				return;
			}
			if (type == 320)
			{
				name = "Feather";
				maxStack = 99;
				width = 16;
				height = 14;
				value = 50;
				return;
			}
			if (type == 321)
			{
				name = "Tombstone";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 85;
				width = 20;
				height = 20;
				return;
			}
			if (type == 322)
			{
				name = "Mime Mask";
				headSlot = 28;
				width = 20;
				height = 20;
				value = 20000;
				return;
			}
			if (type == 323)
			{
				name = "Antlion Mandible";
				width = 10;
				height = 20;
				maxStack = 99;
				value = 50;
				return;
			}
			if (type == 324)
			{
				name = "Illegal Gun Parts";
				width = 10;
				height = 20;
				maxStack = 99;
				value = 200000;
				toolTip = "'Banned in most places'";
				return;
			}
			if (type == 325)
			{
				name = "The Doctor's Shirt";
				width = 18;
				height = 18;
				bodySlot = 16;
				value = 200000;
				vanity = true;
				return;
			}
			if (type == 326)
			{
				name = "The Doctor's Pants";
				width = 18;
				height = 18;
				legSlot = 15;
				value = 200000;
				vanity = true;
				return;
			}
			if (type == 327)
			{
				name = "Golden Key";
				width = 14;
				height = 20;
				maxStack = 99;
				toolTip = "Opens one Gold Chest";
				return;
			}
			if (type == 328)
			{
				name = "Shadow Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 3;
				width = 26;
				height = 22;
				value = 5000;
				return;
			}
			if (type == 329)
			{
				name = "Shadow Key";
				width = 14;
				height = 20;
				maxStack = 1;
				toolTip = "Opens all Shadow Chests";
				value = 75000;
				return;
			}
			if (type == 330)
			{
				name = "Obsidian Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 20;
				width = 12;
				height = 12;
				return;
			}
			if (type == 331)
			{
				name = "Jungle Spores";
				width = 18;
				height = 16;
				maxStack = 99;
				value = 100;
				return;
			}
			if (type == 332)
			{
				name = "Loom";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 86;
				width = 20;
				height = 20;
				value = 300;
				toolTip = "Used for crafting cloth";
				return;
			}
			if (type == 333)
			{
				name = "Piano";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 87;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 334)
			{
				name = "Dresser";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 88;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 335)
			{
				name = "Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 89;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 336)
			{
				name = "Bathtub";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 90;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 337)
			{
				name = "Red Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 0;
				width = 10;
				height = 24;
				value = 500;
				return;
			}
			if (type == 338)
			{
				name = "Green Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 1;
				width = 10;
				height = 24;
				value = 500;
				return;
			}
			if (type == 339)
			{
				name = "Blue Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 2;
				width = 10;
				height = 24;
				value = 500;
				return;
			}
			if (type == 340)
			{
				name = "Yellow Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 3;
				width = 10;
				height = 24;
				value = 500;
				return;
			}
			if (type == 341)
			{
				name = "Lamp Post";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 92;
				width = 10;
				height = 24;
				value = 500;
				return;
			}
			if (type == 342)
			{
				name = "Tiki Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 93;
				width = 10;
				height = 24;
				value = 500;
				return;
			}
			if (type == 343)
			{
				name = "Barrel";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 5;
				width = 20;
				height = 20;
				value = 500;
				return;
			}
			if (type == 344)
			{
				name = "Chinese Lantern";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 95;
				width = 20;
				height = 20;
				value = 500;
				return;
			}
			if (type == 345)
			{
				name = "Cooking Pot";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 96;
				width = 20;
				height = 20;
				value = 500;
				return;
			}
			if (type == 346)
			{
				name = "Safe";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 97;
				width = 20;
				height = 20;
				value = 200000;
				return;
			}
			if (type == 347)
			{
				name = "Skull Lantern";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 98;
				width = 20;
				height = 20;
				value = 500;
				return;
			}
			if (type == 348)
			{
				name = "Trash Can";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 6;
				width = 20;
				height = 20;
				value = 1000;
				return;
			}
			if (type == 349)
			{
				name = "Candelabra";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 100;
				width = 20;
				height = 20;
				value = 1500;
				return;
			}
			if (type == 350)
			{
				name = "Pink Vase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 13;
				placeStyle = 3;
				width = 16;
				height = 24;
				value = 70;
				return;
			}
			if (type == 351)
			{
				name = "Mug";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 13;
				placeStyle = 4;
				width = 16;
				height = 24;
				value = 20;
				return;
			}
			if (type == 352)
			{
				name = "Keg";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 94;
				width = 24;
				height = 24;
				value = 600;
				toolTip = "Used for brewing ale";
				return;
			}
			if (type == 353)
			{
				name = "Ale";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 99;
				consumable = true;
				width = 10;
				height = 10;
				buffType = 25;
				buffTime = 7200;
				value = 100;
				holdStyle = 1;
				ammo = 353;
				notAmmo = true;
				return;
			}
			if (type == 354)
			{
				name = "Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 355)
			{
				name = "Throne";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 102;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 356)
			{
				name = "Bowl";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 103;
				width = 16;
				height = 24;
				value = 20;
				return;
			}
			if (type == 357)
			{
				name = "Bowl of Soup";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 10;
				height = 10;
				buffType = 26;
				buffTime = 108000;
				rare = 1;
				toolTip = "Minor improvements to all stats";
				value = 1000;
				return;
			}
			if (type == 358)
			{
				name = "Toilet";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 1;
				width = 12;
				height = 30;
				value = 150;
				return;
			}
			if (type == 359)
			{
				name = "Grandfather Clock";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 104;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 360)
			{
				name = "Armor Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 361)
			{
				useStyle = 4;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				name = "Goblin Battle Standard";
				width = 28;
				height = 28;
				toolTip = "Summons a Goblin Army";
				maxStack = 20;
				return;
			}
			if (type == 362)
			{
				name = "Tattered Cloth";
				maxStack = 99;
				width = 24;
				height = 24;
				value = 30;
				return;
			}
			if (type == 363)
			{
				name = "Sawmill";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 106;
				width = 20;
				height = 20;
				value = 300;
				toolTip = "Used for advanced wood crafting";
				return;
			}
			if (type == 364)
			{
				name = "Cobalt Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 107;
				width = 12;
				height = 12;
				value = 3500;
				rare = 3;
				return;
			}
			if (type == 365)
			{
				name = "Mythril Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 108;
				width = 12;
				height = 12;
				value = 5500;
				rare = 3;
				return;
			}
			if (type == 366)
			{
				name = "Adamantite Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 111;
				width = 12;
				height = 12;
				value = 7500;
				rare = 3;
				return;
			}
			if (type == 367)
			{
				name = "Pwnhammer";
				useTurn = true;
				autoReuse = true;
				useStyle = 1;
				useAnimation = 27;
				useTime = 14;
				hammer = 80;
				width = 24;
				height = 28;
				damage = 26;
				knockBack = 7.5f;
				scale = 1.2f;

				rare = 4;
				value = 39000;
				melee = true;
				toolTip = "Strong enough to destroy Demon Altars";
				return;
			}
			if (type == 368)
			{
				autoReuse = true;
				name = "Excalibur";
				useStyle = 1;
				useAnimation = 25;
				useTime = 25;
				knockBack = 4.5f;
				width = 40;
				height = 40;
				damage = 50;
				scale = 1.15f;

				rare = 5;
				value = 230000;
				melee = true;
				return;
			}
			if (type == 369)
			{
				autoReuse = true;
				name = "Hallowed Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 109;
				width = 14;
				height = 14;
				value = 2000;
				rare = 3;
				return;
			}
			if (type == 370)
			{
				name = "Ebonsand Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 112;
				width = 12;
				height = 12;
				ammo = AmmoID.Sand;
				return;
			}
			if (type == 371)
			{
				name = "Cobalt Hat";
				width = 18;
				height = 18;
				defense = 2;
				headSlot = 29;
				rare = 4;
				value = 75000;
				toolTip = "Increases maximum mana by 40";
				toolTip2 = "9% increased magic critical strike chance";
				return;
			}
			if (type == 372)
			{
				name = "Cobalt Helmet";
				width = 18;
				height = 18;
				defense = 11;
				headSlot = 30;
				rare = 4;
				value = 75000;
				toolTip = "7% increased movement speed";
				toolTip2 = "12% increased melee speed";
				return;
			}
			if (type == 373)
			{
				name = "Cobalt Mask";
				width = 18;
				height = 18;
				defense = 4;
				headSlot = 31;
				rare = 4;
				value = 75000;
				toolTip = "10% increased ranged damage";
				toolTip2 = "6% increased ranged critical strike chance";
				return;
			}
			if (type == 374)
			{
				name = "Cobalt Breastplate";
				width = 18;
				height = 18;
				defense = 8;
				bodySlot = 17;
				rare = 4;
				value = 60000;
				toolTip2 = "3% increased critical strike chance";
				return;
			}
			if (type == 375)
			{
				name = "Cobalt Leggings";
				width = 18;
				height = 18;
				defense = 7;
				legSlot = 16;
				rare = 4;
				value = 45000;
				toolTip2 = "10% increased movement speed";
				return;
			}
			if (type == 376)
			{
				name = "Mythril Hood";
				width = 18;
				height = 18;
				defense = 3;
				headSlot = 32;
				rare = 4;
				value = 112500;
				toolTip = "Increases maximum mana by 60";
				toolTip2 = "15% increased magic damage";
				return;
			}
			if (type == 377)
			{
				name = "Mythril Helmet";
				width = 18;
				height = 18;
				defense = 16;
				headSlot = 33;
				rare = 4;
				value = 112500;
				toolTip = "5% increased melee critical strike chance";
				toolTip2 = "10% increased melee damage";
				return;
			}
			if (type == 378)
			{
				name = "Mythril Hat";
				width = 18;
				height = 18;
				defense = 6;
				headSlot = 34;
				rare = 4;
				value = 112500;
				toolTip = "12% increased ranged damage";
				toolTip2 = "7% increased ranged critical strike chance";
				return;
			}
			if (type == 379)
			{
				name = "Mythril Chainmail";
				width = 18;
				height = 18;
				defense = 12;
				bodySlot = 18;
				rare = 4;
				value = 90000;
				toolTip2 = "5% increased damage";
				return;
			}
			if (type == 380)
			{
				name = "Mythril Greaves";
				width = 18;
				height = 18;
				defense = 9;
				legSlot = 17;
				rare = 4;
				value = 67500;
				toolTip2 = "3% increased critical strike chance";
				return;
			}
			if (type == 381)
			{
				name = "Cobalt Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10500;
				rare = 3;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 11;
				return;
			}
			if (type == 382)
			{
				name = "Mythril Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 22000;
				rare = 3;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 13;
				return;
			}
			if (type == 383)
			{
				name = "Cobalt Chainsaw";
				useStyle = 5;
				useAnimation = 25;
				useTime = 8;
				shootSpeed = 40f;
				knockBack = 2.75f;
				width = 20;
				height = 12;
				damage = 23;
				axe = 14;

				shoot = 57;
				rare = 4;
				value = 54000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				return;
			}
			if (type == 384)
			{
				name = "Mythril Chainsaw";
				useStyle = 5;
				useAnimation = 25;
				useTime = 8;
				shootSpeed = 40f;
				knockBack = 3f;
				width = 20;
				height = 12;
				damage = 29;
				axe = 17;

				shoot = 58;
				rare = 4;
				value = 81000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				return;
			}
			if (type == 385)
			{
				name = "Cobalt Drill";
				useStyle = 5;
				useAnimation = 25;
				useTime = 13;
				shootSpeed = 32f;
				knockBack = 0f;
				width = 20;
				height = 12;
				damage = 10;
				pick = 110;

				shoot = 59;
				rare = 4;
				value = 54000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				toolTip = "Can mine Mythril and Orichalcum";
				return;
			}
			if (type == 386)
			{
				name = "Mythril Drill";
				useStyle = 5;
				useAnimation = 25;
				useTime = 10;
				shootSpeed = 32f;
				knockBack = 0f;
				width = 20;
				height = 12;
				damage = 15;
				pick = 150;

				shoot = 60;
				rare = 4;
				value = 81000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				toolTip = "Can mine Adamantite and Titanium";
				return;
			}
			if (type == 387)
			{
				name = "Adamantite Chainsaw";
				useStyle = 5;
				useAnimation = 25;
				useTime = 6;
				shootSpeed = 40f;
				knockBack = 4.5f;
				width = 20;
				height = 12;
				damage = 33;
				axe = 20;

				shoot = 61;
				rare = 4;
				value = 108000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				return;
			}
			if (type == 388)
			{
				name = "Adamantite Drill";
				useStyle = 5;
				useAnimation = 25;
				useTime = 7;
				shootSpeed = 32f;
				knockBack = 0f;
				width = 20;
				height = 12;
				damage = 20;
				pick = 180;

				shoot = 62;
				rare = 4;
				value = 108000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				return;
			}
			if (type == 389)
			{
				name = "Dao of Pow";
				noMelee = true;
				useStyle = 5;
				useAnimation = 45;
				useTime = 45;
				knockBack = 7f;
				width = 30;
				height = 10;
				damage = 63;
				scale = 1.1f;
				noUseGraphic = true;
				shoot = 63;
				shootSpeed = 15f;

				rare = 5;
				value = 144000;
				melee = true;
				channel = true;
				toolTip = "Has a chance to confuse";
				toolTip2 = "'Find your inner pieces'";
				return;
			}
			if (type == 390)
			{
				name = "Mythril Halberd";
				useStyle = 5;
				useAnimation = 26;
				useTime = 26;
				shootSpeed = 4.5f;
				knockBack = 5f;
				width = 40;
				height = 40;
				damage = 35;
				scale = 1.1f;

				shoot = 64;
				rare = 4;
				value = 67500;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			}
			if (type == 391)
			{
				name = "Adamantite Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 37500;
				rare = 3;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 15;
				return;
			}
			if (type == 392)
			{
				name = "Glass Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 21;
				width = 12;
				height = 12;
				return;
			}
			if (type == 393)
			{
				name = "Compass";
				width = 24;
				height = 28;
				rare = 1;
				value = Item.sellPrice(0, 0, 25, 0);
				accessory = true;
				toolTip = "Shows horizontal position";
				return;
			}
			if (type == 394)
			{
				name = "Diving Gear";
				width = 24;
				height = 28;
				rare = 4;
				value = 100000;
				accessory = true;
				toolTip = "Grants the ability to swim";
				toolTip2 = "Greatly extends underwater breathing";
				faceSlot = 4;
				return;
			}
			if (type == 395)
			{
				name = "GPS";
				width = 24;
				height = 28;
				rare = 3;
				value = Item.sellPrice(0, 3, 0, 0);
				accessory = true;
				toolTip = "Shows position";
				toolTip2 = "Tells the time";
				return;
			}
			if (type == 396)
			{
				name = "Obsidian Horseshoe";
				width = 24;
				height = 28;
				rare = 4;
				value = 100000;
				accessory = true;
				toolTip = "Negates fall damage";
				toolTip2 = "Grants immunity to fire blocks";
				return;
			}
			if (type == 397)
			{
				name = "Obsidian Shield";
				width = 24;
				height = 28;
				rare = 4;
				value = 100000;
				accessory = true;
				defense = 2;
				toolTip = "Grants immunity to knockback";
				toolTip2 = "Grants immunity to fire blocks";
				shieldSlot = 3;
				return;
			}
			if (type == 398)
			{
				name = "Tinkerer's Workshop";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 114;
				width = 26;
				height = 20;
				value = 100000;
				toolTip = "Allows the combining of some accessories";
				return;
			}
			if (type == 399)
			{
				name = "Cloud in a Balloon";
				width = 14;
				height = 28;
				rare = 4;
				value = 150000;
				accessory = true;
				toolTip = "Allows the holder to double jump";
				toolTip2 = "Increases jump height";
				balloonSlot = 4;
				return;
			}
			if (type == 400)
			{
				name = "Adamantite Headgear";
				width = 18;
				height = 18;
				defense = 4;
				headSlot = 35;
				rare = 4;
				value = 150000;
				toolTip = "Increases maximum mana by 80";
				toolTip2 = "11% increased magic damage and critical strike chance";
				return;
			}
			if (type == 401)
			{
				name = "Adamantite Helmet";
				width = 18;
				height = 18;
				defense = 22;
				headSlot = 36;
				rare = 4;
				value = 150000;
				toolTip = "7% increased melee critical strike chance";
				toolTip2 = "14% increased melee damage";
				return;
			}
			if (type == 402)
			{
				name = "Adamantite Mask";
				width = 18;
				height = 18;
				defense = 8;
				headSlot = 37;
				rare = 4;
				value = 150000;
				toolTip = "14% increased ranged damage";
				toolTip2 = "8% increased ranged critical strike chance";
				return;
			}
			if (type == 403)
			{
				name = "Adamantite Breastplate";
				width = 18;
				height = 18;
				defense = 16;
				bodySlot = 19;
				rare = 4;
				value = 120000;
				toolTip = "6% increased damage";
				return;
			}
			if (type == 404)
			{
				name = "Adamantite Leggings";
				width = 18;
				height = 18;
				defense = 12;
				legSlot = 18;
				rare = 4;
				value = 90000;
				toolTip = "4% increased critical strike chance";
				toolTip2 = "5% increased movement speed";
				return;
			}
			if (type == 405)
			{
				name = "Spectre Boots";
				width = 28;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Allows flight";
				toolTip2 = "The wearer can run super fast";
				value = 100000;
				shoeSlot = 13;
				return;
			}
			if (type == 406)
			{
				name = "Adamantite Glaive";
				useStyle = 5;
				useAnimation = 25;
				useTime = 25;
				shootSpeed = 5f;
				knockBack = 6f;
				width = 40;
				height = 40;
				damage = 38;
				scale = 1.1f;

				shoot = 66;
				rare = 4;
				value = 90000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			}
			if (type == 407)
			{
				name = "Toolbelt";
				width = 28;
				height = 24;
				accessory = true;
				rare = 3;
				toolTip = "Increases block placement range";
				value = 100000;
				waistSlot = 5;
				return;
			}
			if (type == 408)
			{
				name = "Pearlsand Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 116;
				width = 12;
				height = 12;
				ammo = AmmoID.Sand;
				return;
			}
			if (type == 409)
			{
				name = "Pearlstone Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 117;
				width = 12;
				height = 12;
				return;
			}
			if (type == 410)
			{
				name = "Mining Shirt";
				width = 18;
				height = 18;
				defense = 1;
				bodySlot = 20;
				value = 5000;
				rare = 1;
				return;
			}
			if (type == 411)
			{
				name = "Mining Pants";
				width = 18;
				height = 18;
				defense = 1;
				legSlot = 19;
				value = 5000;
				rare = 1;
				return;
			}
			if (type == 412)
			{
				name = "Pearlstone Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 118;
				width = 12;
				height = 12;
				return;
			}
			if (type == 413)
			{
				name = "Iridescent Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 119;
				width = 12;
				height = 12;
				return;
			}
			if (type == 414)
			{
				name = "Mudstone Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 120;
				width = 12;
				height = 12;
				return;
			}
			if (type == 415)
			{
				name = "Cobalt Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 121;
				width = 12;
				height = 12;
				return;
			}
			if (type == 416)
			{
				name = "Mythril Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 122;
				width = 12;
				height = 12;
				return;
			}
			if (type == 417)
			{
				name = "Pearlstone Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 22;
				width = 12;
				height = 12;
				return;
			}
			if (type == 418)
			{
				name = "Iridescent Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 23;
				width = 12;
				height = 12;
				return;
			}
			if (type == 419)
			{
				name = "Mudstone Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 24;
				width = 12;
				height = 12;
				return;
			}
			if (type == 420)
			{
				name = "Cobalt Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 25;
				width = 12;
				height = 12;
				return;
			}
			if (type == 421)
			{
				name = "Mythril Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 26;
				width = 12;
				height = 12;
				return;
			}
			if (type == 422)
			{
				useStyle = 1;
				name = "Holy Water";
				shootSpeed = 9f;
				rare = 3;
				damage = 20;
				shoot = 69;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;
				knockBack = 3f;

				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 200;
				toolTip = "Spreads the Hallow to some blocks";
				return;
			}
			if (type == 423)
			{
				useStyle = 1;
				name = "Unholy Water";
				shootSpeed = 9f;
				rare = 3;
				damage = 20;
				shoot = 70;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;
				knockBack = 3f;

				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 200;
				toolTip = "Spreads the corruption to some blocks";
				return;
			}
			if (type == 424)
			{
				name = "Silt Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 123;
				width = 12;
				height = 12;
				return;
			}
			if (type == 425)
			{
				channel = true;
				damage = 0;
				useStyle = 1;
				name = "Fairy Bell";
				width = 24;
				height = 24;

				useAnimation = 20;
				useTime = 20;
				rare = 5;
				noMelee = true;
				toolTip = "Summons a magical fairy";
				value = (value = 250000);
				buffType = 27;
				return;
			}
			if (type == 426)
			{
				name = "Breaker Blade";
				useStyle = 1;
				useAnimation = 30;
				knockBack = 8f;
				width = 60;
				height = 70;
				damage = 39;
				scale = 1.05f;

				rare = 4;
				value = 150000;
				melee = true;
				return;
			}
			if (type == 427)
			{
				flame = true;
				noWet = true;
				name = "Blue Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 1;
				width = 10;
				height = 12;
				value = 200;
				return;
			}
			if (type == 428)
			{
				flame = true;
				noWet = true;
				name = "Red Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 2;
				width = 10;
				height = 12;
				value = 200;
				return;
			}
			if (type == 429)
			{
				flame = true;
				noWet = true;
				name = "Green Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 3;
				width = 10;
				height = 12;
				value = 200;
				return;
			}
			if (type == 430)
			{
				flame = true;
				noWet = true;
				name = "Purple Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 4;
				width = 10;
				height = 12;
				value = 200;
				return;
			}
			if (type == 431)
			{
				flame = true;
				noWet = true;
				name = "White Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 5;
				width = 10;
				height = 12;
				value = 500;
				return;
			}
			if (type == 432)
			{
				flame = true;
				noWet = true;
				name = "Yellow Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 6;
				width = 10;
				height = 12;
				value = 200;
				return;
			}
			if (type == 433)
			{
				flame = true;
				noWet = true;
				name = "Demon Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 7;
				width = 10;
				height = 12;
				value = 300;
				return;
			}
			if (type == 434)
			{
				autoReuse = true;
				useStyle = 5;
				useAnimation = 12;
				useTime = 4;
				reuseDelay = 14;
				name = "Clockwork Assault Rifle";
				width = 50;
				height = 18;
				shoot = 10;
				useAmmo = AmmoID.Bullet;

				damage = 19;
				shootSpeed = 7.75f;
				noMelee = true;
				value = 150000;
				rare = 4;
				ranged = true;
				toolTip = "Three round burst";
				toolTip2 = "Only the first shot consumes ammo";
				return;
			}
			if (type == 435)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 25;
				useTime = 25;
				name = "Cobalt Repeater";
				width = 50;
				height = 18;
				shoot = 1;
				useAmmo = AmmoID.Arrow;

				damage = 32;
				shootSpeed = 9f;
				noMelee = true;
				value = 60000;
				ranged = true;
				rare = 4;
				knockBack = 1.5f;
				return;
			}
			if (type == 436)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 23;
				useTime = 23;
				name = "Mythril Repeater";
				width = 50;
				height = 18;
				shoot = 1;
				useAmmo = AmmoID.Arrow;

				damage = 36;
				shootSpeed = 9.5f;
				noMelee = true;
				value = 90000;
				ranged = true;
				rare = 4;
				knockBack = 2f;
				return;
			}
			if (type == 437)
			{
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Dual Hook";
				shootSpeed = 14f;
				shoot = 73;
				width = 18;
				height = 28;

				useAnimation = 20;
				useTime = 20;
				rare = 4;
				noMelee = true;
				value = 200000;
				return;
			}
			if (type == 438)
			{
				name = "Star Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 2;
				return;
			}
			if (type == 439)
			{
				name = "Sword Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 3;
				return;
			}
			if (type == 440)
			{
				name = "Slime Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 4;
				return;
			}
			if (type == 441)
			{
				name = "Goblin Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 5;
				return;
			}
			if (type == 442)
			{
				name = "Shield Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 6;
				return;
			}
			if (type == 443)
			{
				name = "Bat Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 7;
				return;
			}
			if (type == 444)
			{
				name = "Fish Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 8;
				return;
			}
			if (type == 445)
			{
				name = "Bunny Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 9;
				return;
			}
			if (type == 446)
			{
				name = "Skeleton Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 10;
				return;
			}
			if (type == 447)
			{
				name = "Reaper Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 11;
				return;
			}
			if (type == 448)
			{
				name = "Woman Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 12;
				return;
			}
			if (type == 449)
			{
				name = "Imp Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 13;
				return;
			}
			if (type == 450)
			{
				name = "Gargoyle Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 14;
				return;
			}
			if (type == 451)
			{
				name = "Gloom Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 15;
				return;
			}
			if (type == 452)
			{
				name = "Hornet Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 16;
				return;
			}
			if (type == 453)
			{
				name = "Bomb Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 17;
				return;
			}
			if (type == 454)
			{
				name = "Crab Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 18;
				return;
			}
			if (type == 455)
			{
				name = "Hammer Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 19;
				return;
			}
			if (type == 456)
			{
				name = "Potion Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 20;
				return;
			}
			if (type == 457)
			{
				name = "Spear Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 21;
				return;
			}
			if (type == 458)
			{
				name = "Cross Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 22;
				return;
			}
			if (type == 459)
			{
				name = "Jellyfish Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 23;
				return;
			}
			if (type == 460)
			{
				name = "Bow Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 24;
				return;
			}
			if (type == 461)
			{
				name = "Boomerang Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 25;
				return;
			}
			if (type == 462)
			{
				name = "Boot Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 26;
				return;
			}
			if (type == 463)
			{
				name = "Chest Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 27;
				return;
			}
			if (type == 464)
			{
				name = "Bird Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 28;
				return;
			}
			if (type == 465)
			{
				name = "Axe Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 29;
				return;
			}
			if (type == 466)
			{
				name = "Corrupt Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 30;
				return;
			}
			if (type == 467)
			{
				name = "Tree Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 31;
				return;
			}
			if (type == 468)
			{
				name = "Anvil Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 32;
				return;
			}
			if (type == 469)
			{
				name = "Pickaxe Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 33;
				return;
			}
			if (type == 470)
			{
				name = "Mushroom Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 349;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 471)
			{
				name = "Eyeball Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 35;
				return;
			}
			if (type == 472)
			{
				name = "Pillar Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 36;
				return;
			}
			if (type == 473)
			{
				name = "Heart Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 37;
				return;
			}
			if (type == 474)
			{
				name = "Pot Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 38;
				return;
			}
			if (type == 475)
			{
				name = "Sunflower Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 39;
				return;
			}
			if (type == 476)
			{
				name = "King Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 40;
				return;
			}
			if (type == 477)
			{
				name = "Queen Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 41;
				return;
			}
			if (type == 478)
			{
				name = "Pirahna Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 42;
				return;
			}
			if (type == 479)
			{
				name = "Planked Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 27;
				width = 12;
				height = 12;
				return;
			}
			if (type == 480)
			{
				name = "Wooden Beam";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 124;
				width = 12;
				height = 12;
				return;
			}
			if (type == 481)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 20;
				useTime = 20;
				name = "Adamantite Repeater";
				width = 50;
				height = 18;
				shoot = 1;
				useAmmo = AmmoID.Arrow;

				damage = 40;
				shootSpeed = 10f;
				noMelee = true;
				value = 120000;
				ranged = true;
				rare = 4;
				knockBack = 2.5f;
				return;
			}
			if (type == 482)
			{
				name = "Adamantite Sword";
				useStyle = 1;
				useAnimation = 27;
				useTime = 27;
				knockBack = 6f;
				width = 40;
				height = 40;
				damage = 44;
				scale = 1.2f;

				rare = 4;
				value = 138000;
				melee = true;
				return;
			}
			if (type == 483)
			{
				useTurn = true;
				autoReuse = true;
				name = "Cobalt Sword";
				useStyle = 1;
				useAnimation = 23;
				useTime = 23;
				knockBack = 3.85f;
				width = 40;
				height = 40;
				damage = 34;
				scale = 1.1f;

				rare = 4;
				value = 69000;
				melee = true;
				return;
			}
			if (type == 484)
			{
				name = "Mythril Sword";
				useStyle = 1;
				useAnimation = 26;
				useTime = 26;
				knockBack = 6f;
				width = 40;
				height = 40;
				damage = 39;
				scale = 1.15f;

				rare = 4;
				value = 103500;
				melee = true;
				return;
			}
			if (type == 485)
			{
				rare = 4;
				name = "Moon Charm";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Turns the holder into a werewolf on full moons";
				value = 150000;
				return;
			}
			if (type == 486)
			{
				name = "Ruler";
				width = 10;
				height = 26;
				accessory = true;
				toolTip = "Creates a grid on screen for block placement";
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 487)
			{
				name = "Crystal Ball";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 125;
				width = 22;
				height = 22;
				value = 100000;
				rare = 3;
				return;
			}
			if (type == 488)
			{
				name = "Disco Ball";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 126;
				width = 22;
				height = 26;
				value = 10000;
				return;
			}
			if (type == 489)
			{
				name = "Sorcerer Emblem";
				width = 24;
				height = 24;
				accessory = true;
				toolTip = "15% increased magic damage";
				value = 100000;
				rare = 4;
				return;
			}
			if (type == 491)
			{
				name = "Ranger Emblem";
				width = 24;
				height = 24;
				accessory = true;
				toolTip = "15% increased ranged damage";
				value = 100000;
				rare = 4;
				return;
			}
			if (type == 490)
			{
				name = "Warrior Emblem";
				width = 24;
				height = 24;
				accessory = true;
				toolTip = "15% increased melee damage";
				value = 100000;
				rare = 4;
				return;
			}
			if (type == 492)
			{
				name = "Demon Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 1;
				return;
			}
			if (type == 493)
			{
				name = "Angel Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 2;
				return;
			}
			if (type == 494)
			{
				rare = 5;
				useStyle = 5;
				useAnimation = 12;
				useTime = 12;
				name = "Magical Harp";
				width = 12;
				height = 28;
				shoot = 76;
				holdStyle = 3;
				autoReuse = true;
				damage = 32;
				shootSpeed = 4.5f;
				noMelee = true;
				value = 200000;
				mana = 4;
				magic = true;
				return;
			}
			if (type == 495)
			{
				rare = 5;
				mana = 18;
				channel = true;
				damage = 74;
				useStyle = 1;
				name = "Rainbow Rod";
				shootSpeed = 6f;
				shoot = 79;
				width = 26;
				height = 28;

				useAnimation = 18;
				useTime = 18;
				noMelee = true;
				knockBack = 6f;
				toolTip = "Casts a controllable rainbow";
				value = 200000;
				magic = true;
				return;
			}
			if (type == 496)
			{
				rare = 4;
				mana = 6;
				damage = 28;
				useStyle = 1;
				name = "Ice Rod";
				shootSpeed = 12f;
				shoot = 80;
				width = 26;
				height = 28;

				useAnimation = 9;
				useTime = 9;
				rare = 4;
				autoReuse = true;
				noMelee = true;
				knockBack = 0f;
				toolTip = "Summons a block of ice";
				value = Item.buyPrice(0, 50, 0, 0);
				magic = true;
				knockBack = 2f;
				return;
			}
			if (type == 497)
			{
				name = "Neptune's Shell";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Transforms the holder into merfolk when entering water";
				value = 150000;
				rare = 5;
				return;
			}
			if (type == 498)
			{
				name = "Mannequin";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 128;
				width = 12;
				height = 12;
				return;
			}
			if (type == 499)
			{
				name = "Greater Healing Potion";

				healLife = 150;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				rare = 3;
				potion = true;
				value = 5000;
				return;
			}
			if (type == 500)
			{
				name = "Greater Mana Potion";

				healMana = 200;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 75;
				consumable = true;
				width = 14;
				height = 24;
				rare = 3;
				value = Item.buyPrice(0, 0, 5, 0);
				return;
			}
			if (type == 501)
			{
				name = "Pixie Dust";
				width = 16;
				height = 14;
				maxStack = 99;
				value = 500;
				rare = 1;
				return;
			}
			if (type == 502)
			{
				name = "Crystal Shard";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 129;
				width = 24;
				height = 24;
				value = 8000;
				rare = 1;
				return;
			}
			if (type == 503)
			{
				name = "Clown Hat";
				width = 18;
				height = 18;
				headSlot = 40;
				value = 20000;
				vanity = true;
				rare = 2;
				return;
			}
			if (type == 504)
			{
				name = "Clown Shirt";
				width = 18;
				height = 18;
				bodySlot = 23;
				value = 10000;
				vanity = true;
				rare = 2;
				return;
			}
			if (type == 505)
			{
				name = "Clown Pants";
				width = 18;
				height = 18;
				legSlot = 22;
				value = 10000;
				vanity = true;
				rare = 2;
				return;
			}
			if (type == 506)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 30;
				useTime = 6;
				name = "Flamethrower";
				width = 50;
				height = 18;
				shoot = 85;
				useAmmo = AmmoID.Gel;

				damage = 27;
				knockBack = 0.3f;
				shootSpeed = 7f;
				noMelee = true;
				value = 500000;
				rare = 5;
				ranged = true;
				toolTip = "Uses gel for ammo";
				return;
			}
			if (type == 507)
			{
				rare = 3;
				useStyle = 1;
				useAnimation = 12;
				useTime = 12;
				name = "Bell";
				width = 12;
				height = 28;
				autoReuse = true;
				noMelee = true;
				value = 10000;
				return;
			}
			if (type == 508)
			{
				rare = 3;
				useStyle = 5;
				useAnimation = 12;
				useTime = 12;
				name = "Harp";
				width = 12;
				height = 28;
				autoReuse = true;
				noMelee = true;
				value = 10000;
				return;
			}
			if (type == 509)
			{
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 5;
				autoReuse = true;
				name = "Wrench";
				width = 24;
				height = 28;
				rare = 1;
				toolTip = "Places red wire";
				value = 20000;
				mech = true;
				tileBoost = 20;
				return;
			}
			if (type == 510)
			{
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 5;
				autoReuse = true;
				name = "Wire Cutter";
				width = 24;
				height = 28;
				rare = 1;
				toolTip = "Removes wire";
				value = 20000;
				mech = true;
				tileBoost = 20;
				return;
			}
			if (type == 511)
			{
				name = "Active Stone Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 130;
				width = 12;
				height = 12;
				value = 1000;
				mech = true;
				return;
			}
			if (type == 512)
			{
				name = "Inactive Stone Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 131;
				width = 12;
				height = 12;
				value = 1000;
				mech = true;
				return;
			}
			if (type == 513)
			{
				name = "Lever";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 132;
				width = 24;
				height = 24;
				value = 3000;
				mech = true;
				return;
			}
			if (type == 514)
			{
				autoReuse = true;
				useStyle = 5;
				useAnimation = 12;
				useTime = 12;
				name = "Laser Rifle";
				width = 36;
				height = 22;
				shoot = 88;
				mana = 8;

				knockBack = 2.5f;
				damage = 29;
				shootSpeed = 17f;
				noMelee = true;
				rare = 4;
				magic = true;
				value = 150000;
				return;
			}
			if (type == 515)
			{
				name = "Crystal Bullet";
				shootSpeed = 5f;
				shoot = 89;
				damage = 9;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Bullet;
				knockBack = 1f;
				value = 30;
				ranged = true;
				rare = 3;
				toolTip = "Creates several crystal shards on impact";
				return;
			}
			if (type == 516)
			{
				name = "Holy Arrow";
				shootSpeed = 3.5f;
				shoot = 91;
				damage = 13;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Arrow;
				knockBack = 2f;
				value = 80;
				ranged = true;
				rare = 3;
				toolTip = "Summons falling stars on impact";
				return;
			}
			if (type == 517)
			{
				useStyle = 1;
				name = "Magic Dagger";
				shootSpeed = 12f;
				shoot = 93;
				damage = 40;
				width = 18;
				height = 20;
				mana = 6;
				useAnimation = 8;
				useTime = 8;
				noUseGraphic = true;
				noMelee = true;
				value = Item.sellPrice(0, 5, 0, 0);
				knockBack = 3.75f;
				magic = true;
				rare = 4;
				toolTip = "A magical returning dagger";
				return;
			}
			if (type == 518)
			{
				autoReuse = true;
				rare = 4;
				mana = 4;
				name = "Crystal Storm";
				noMelee = true;
				useStyle = 5;
				damage = 25;
				useAnimation = 7;
				useTime = 7;
				width = 24;
				height = 28;
				shoot = 94;
				scale = 0.9f;
				shootSpeed = 16f;
				knockBack = 5f;
				toolTip = "Summons rapid fire crystal shards";
				magic = true;
				value = 500000;
				return;
			}
			if (type == 519)
			{
				autoReuse = true;
				rare = 4;
				mana = 12;
				name = "Cursed Flames";
				noMelee = true;
				useStyle = 5;
				damage = 36;
				useAnimation = 20;
				useTime = 20;
				width = 24;
				height = 28;
				shoot = 95;
				scale = 0.9f;
				shootSpeed = 10f;
				knockBack = 6.5f;
				toolTip = "Summons unholy fire balls";
				magic = true;
				value = 500000;
				return;
			}
			if (type == 520)
			{
				name = "Soul of Light";
				width = 18;
				height = 18;
				maxStack = 999;
				value = 1000;
				rare = 3;
				toolTip = "'The essence of light creatures'";
				return;
			}
			if (type == 521)
			{
				name = "Soul of Night";
				width = 18;
				height = 18;
				maxStack = 999;
				value = 1000;
				rare = 3;
				toolTip = "'The essence of dark creatures'";
				return;
			}
			if (type == 522)
			{
				name = "Cursed Flame";
				width = 12;
				height = 14;
				maxStack = 99;
				value = 4000;
				rare = 3;
				toolTip = "'Not even water can put the flame out'";
				return;
			}
			if (type == 523)
			{
				flame = true;
				name = "Cursed Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 8;
				width = 10;
				height = 12;
				value = 300;
				rare = 1;
				toolTip = "Can be placed in water";
				return;
			}
			if (type == 524)
			{
				name = "Adamantite Forge";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 133;
				width = 44;
				height = 30;
				value = 50000;
				toolTip = "Used to smelt adamantite ore";
				rare = 3;
				return;
			}
			if (type == 525)
			{
				name = "Mythril Anvil";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 134;
				width = 28;
				height = 14;
				value = 25000;
				toolTip = "Used to craft items from mythril and adamantite bars";
				rare = 3;
				return;
			}
			if (type == 526)
			{
				name = "Unicorn Horn";
				width = 14;
				height = 14;
				maxStack = 99;
				value = 15000;
				rare = 1;
				toolTip = "'Sharp and magical!'";
				return;
			}
			if (type == 527)
			{
				name = "Dark Shard";
				width = 14;
				height = 14;
				maxStack = 99;
				value = 4500;
				rare = 2;
				toolTip = "'Sometimes carried by creatures in corrupt deserts'";
				return;
			}
			if (type == 528)
			{
				name = "Light Shard";
				width = 14;
				height = 14;
				maxStack = 99;
				value = 4500;
				rare = 2;
				toolTip = "'Sometimes carried by creatures in light deserts'";
				return;
			}
			if (type == 529)
			{
				name = "Red Pressure Plate";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 135;
				width = 12;
				height = 12;
				placeStyle = 0;
				mech = true;
				value = 5000;
				mech = true;
				toolTip = "Activates when stepped on";
				return;
			}
			if (type == 530)
			{
				name = "Wire";
				width = 12;
				height = 18;
				maxStack = 999;
				value = 500;
				mech = true;
				notAmmo = true;
				return;
			}
			if (type == 531)
			{
				name = "Spell Tome";
				width = 12;
				height = 18;
				maxStack = 99;
				value = 50000;
				rare = 1;
				toolTip = "Can be enchanted";
				return;
			}
			if (type == 532)
			{
				name = "Star Cloak";
				width = 20;
				height = 24;
				value = 100000;
				toolTip = "Causes stars to fall when injured";
				accessory = true;
				rare = 4;
				backSlot = 2;
				return;
			}
			if (type == 533)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 7;
				useTime = 7;
				name = "Megashark";
				width = 50;
				height = 18;
				shoot = 10;
				useAmmo = AmmoID.Bullet;

				damage = 25;
				shootSpeed = 10f;
				noMelee = true;
				value = 300000;
				rare = 5;
				toolTip = "50% chance to not consume ammo";
				toolTip2 = "'Minishark's older brother'";
				knockBack = 1f;
				ranged = true;
				return;
			}
			if (type == 534)
			{
				knockBack = 6.5f;
				useStyle = 5;
				useAnimation = 45;
				useTime = 45;
				name = "Shotgun";
				width = 50;
				height = 14;
				shoot = 10;
				useAmmo = AmmoID.Bullet;

				damage = 24;
				shootSpeed = 7f;
				noMelee = true;
				value = 250000;
				rare = 4;
				ranged = true;
				toolTip = "Fires a spread of bullets";
				return;
			}
			if (type == 535)
			{
				name = "Philosopher's Stone";
				width = 12;
				height = 18;
				value = 100000;
				toolTip = "Reduces the cooldown of healing potions";
				accessory = true;
				rare = 4;
				return;
			}
			if (type == 536)
			{
				name = "Titan Glove";
				width = 12;
				height = 18;
				value = 100000;
				toolTip = "Increases melee knockback";
				rare = 4;
				accessory = true;
				handOnSlot = 15;
				handOffSlot = 8;
				return;
			}
			if (type == 537)
			{
				name = "Cobalt Naginata";
				useStyle = 5;
				useAnimation = 28;
				useTime = 28;
				shootSpeed = 4.3f;
				knockBack = 4f;
				width = 40;
				height = 40;
				damage = 29;
				scale = 1.1f;

				shoot = 97;
				rare = 4;
				value = 45000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			}
			if (type == 538)
			{
				name = "Switch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 136;
				width = 12;
				height = 12;
				value = 2000;
				mech = true;
				return;
			}
			if (type == 539)
			{
				name = "Dart Trap";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 137;
				width = 12;
				height = 12;
				value = 10000;
				mech = true;
				return;
			}
			if (type == 540)
			{
				name = "Boulder";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 138;
				width = 12;
				height = 12;
				mech = true;
				return;
			}
			if (type == 541)
			{
				name = "Green Pressure Plate";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 135;
				width = 12;
				height = 12;
				placeStyle = 1;
				mech = true;
				value = 5000;
				toolTip = "Activates when stepped on";
				return;
			}
			if (type == 542)
			{
				name = "Gray Pressure Plate";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 135;
				width = 12;
				height = 12;
				placeStyle = 2;
				mech = true;
				value = 5000;
				toolTip = "Activates when a player steps on it on";
				return;
			}
			if (type == 543)
			{
				name = "Brown Pressure Plate";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 135;
				width = 12;
				height = 12;
				placeStyle = 3;
				mech = true;
				value = 5000;
				toolTip = "Activates when a player steps on it on";
				return;
			}
			if (type == 544)
			{
				useStyle = 4;
				name = "Mechanical Eye";
				width = 22;
				height = 14;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				maxStack = 20;
				toolTip = "Summons The Twins";
				rare = 3;
				return;
			}
			if (type == 545)
			{
				name = "Cursed Arrow";
				shootSpeed = 4f;
				shoot = 103;
				damage = 17;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Arrow;
				knockBack = 3f;
				value = 80;
				ranged = true;
				rare = 3;
				return;
			}
			if (type == 546)
			{
				name = "Cursed Bullet";
				shootSpeed = 5f;
				shoot = 104;
				damage = 12;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Bullet;
				knockBack = 4f;
				value = 30;
				rare = 1;
				ranged = true;
				rare = 3;
				return;
			}
			if (type == 547)
			{
				name = "Soul of Fright";
				width = 18;
				height = 18;
				maxStack = 999;
				value = 40000;
				rare = 5;
				toolTip = "'The essence of pure terror'";
				return;
			}
			if (type == 548)
			{
				name = "Soul of Might";
				width = 18;
				height = 18;
				maxStack = 999;
				value = 40000;
				rare = 5;
				toolTip = "'The essence of the destroyer'";
				return;
			}
			if (type == 549)
			{
				name = "Soul of Sight";
				width = 18;
				height = 18;
				maxStack = 999;
				value = 40000;
				rare = 5;
				toolTip = "'The essence of omniscient watchers'";
				return;
			}
			if (type == 550)
			{
				name = "Gungnir";
				useStyle = 5;
				useAnimation = 22;
				useTime = 22;
				shootSpeed = 5.6f;
				knockBack = 6.4f;
				width = 40;
				height = 40;
				damage = 42;
				scale = 1.1f;

				shoot = 105;
				rare = 5;
				value = 230000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			}
			if (type == 551)
			{
				name = "Hallowed Plate Mail";
				width = 18;
				height = 18;
				defense = 15;
				bodySlot = 24;
				rare = 5;
				value = 200000;
				toolTip = "7% increased critical strike chance";
				return;
			}
			if (type == 552)
			{
				name = "Hallowed Greaves";
				width = 18;
				height = 18;
				defense = 11;
				legSlot = 23;
				rare = 5;
				value = 150000;
				toolTip = "7% increased damage";
				toolTip2 = "8% increased movement speed";
				return;
			}
			if (type == 553)
			{
				name = "Hallowed Helmet";
				width = 18;
				height = 18;
				defense = 9;
				headSlot = 41;
				rare = 5;
				value = 250000;
				toolTip = "15% increased ranged damage";
				toolTip2 = "8% increased ranged critical strike chance";
				return;
			}
			if (type == 558)
			{
				name = "Hallowed Headgear";
				width = 18;
				height = 18;
				defense = 5;
				headSlot = 42;
				rare = 5;
				value = 250000;
				toolTip = "Increases maximum mana by 100";
				toolTip2 = "12% increased magic damage and critical strike chance";
				return;
			}
			if (type == 559)
			{
				name = "Hallowed Mask";
				width = 18;
				height = 18;
				defense = 24;
				headSlot = 43;
				rare = 5;
				value = 250000;
				toolTip = "10% increased melee damage and critical strike chance";
				toolTip2 = "10% increased melee haste";
				return;
			}
			if (type == 554)
			{
				name = "Cross Necklace";
				width = 20;
				height = 24;
				value = 1500;
				toolTip = "Increases length of invincibility after taking damage";
				accessory = true;
				rare = 4;
				neckSlot = 2;
				return;
			}
			if (type == 555)
			{
				name = "Mana Flower";
				width = 20;
				height = 24;
				value = 50000;
				toolTip = "8% reduced mana usage";
				toolTip2 = "Automatically use mana potions when needed";
				accessory = true;
				rare = 4;
				waistSlot = 6;
				return;
			}
			if (type == 556)
			{
				useStyle = 4;
				name = "Mechanical Worm";
				width = 22;
				height = 14;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				maxStack = 20;
				toolTip = "Summons Destroyer";
				rare = 3;
				return;
			}
			if (type == 557)
			{
				useStyle = 4;
				name = "Mechanical Skull";
				width = 22;
				height = 14;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				maxStack = 20;
				toolTip = "Summons Skeletron Prime";
				rare = 3;
				return;
			}
			if (type == 560)
			{
				useStyle = 4;
				name = "Slime Crown";
				width = 22;
				height = 14;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				maxStack = 20;
				toolTip = "Summons King Slime";
				rare = 1;
				return;
			}
			if (type == 561)
			{
				melee = true;
				autoReuse = true;
				noMelee = true;
				useStyle = 1;
				name = "Light Disc";
				shootSpeed = 13f;
				shoot = 106;
				damage = 57;
				knockBack = 8f;
				width = 24;
				height = 24;

				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				rare = 5;
				maxStack = 5;
				value = 500000;
				toolTip = "Stacks up to 5";
				return;
			}
			if (type == 562)
			{
				name = "Music Box (Overworld Day)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 0;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 563)
			{
				name = "Music Box (Eerie)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 1;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 564)
			{
				name = "Music Box (Night)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 2;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 565)
			{
				name = "Music Box (Title)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 3;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 566)
			{
				name = "Music Box (Underground)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 4;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 567)
			{
				name = "Music Box (Boss 1)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 5;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 568)
			{
				name = "Music Box (Jungle)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 6;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 569)
			{
				name = "Music Box (Corruption)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 7;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 570)
			{
				name = "Music Box (Underground Corruption)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 8;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 571)
			{
				name = "Music Box (The Hallow)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 9;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 572)
			{
				name = "Music Box (Boss 2)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 10;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 573)
			{
				name = "Music Box (Underground Hallow)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 11;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 574)
			{
				name = "Music Box (Boss 3)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 12;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 575)
			{
				name = "Soul of Flight";
				width = 18;
				height = 18;
				maxStack = 999;
				value = 1000;
				rare = 3;
				toolTip = "'The essence of powerful flying creatures'";
				return;
			}
			if (type == 576)
			{
				name = "Music Box";
				width = 24;
				height = 24;
				rare = 3;
				toolTip = "Has a chance to record songs";
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 577)
			{
				name = "Demonite Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 140;
				width = 12;
				height = 12;
				return;
			}
			if (type == 578)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 19;
				useTime = 19;
				name = "Hallowed Repeater";
				width = 50;
				height = 18;
				shoot = 1;
				useAmmo = AmmoID.Arrow;

				damage = 43;
				shootSpeed = 11f;
				noMelee = true;
				value = 200000;
				ranged = true;
				rare = 4;
				knockBack = 2.5f;
				return;
			}
			if (type == 579)
			{
				name = "Drax";
				useStyle = 5;
				useAnimation = 25;
				useTime = 7;
				shootSpeed = 36f;
				knockBack = 4.75f;
				width = 20;
				height = 12;
				damage = 35;
				pick = 200;
				axe = 22;

				shoot = 107;
				rare = 4;
				value = 220000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				toolTip = "'Not to be confused with a picksaw'";
				return;
			}
			if (type == 580)
			{
				mech = true;
				name = "Explosives";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 141;
				width = 12;
				height = 12;
				toolTip = "Explodes when activated";
				return;
			}
			if (type == 581)
			{
				mech = true;
				name = "Inlet Pump";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 142;
				width = 12;
				height = 12;
				toolTip = "Sends water to outlet pumps";
				return;
			}
			if (type == 582)
			{
				mech = true;
				name = "Outlet Pump";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 143;
				width = 12;
				height = 12;
				toolTip = "Receives water from inlet pumps";
				return;
			}
			if (type == 583)
			{
				mech = true;
				noWet = true;
				name = "1 Second Timer";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 144;
				placeStyle = 0;
				width = 10;
				height = 12;
				value = 50;
				toolTip = "Activates every second";
				return;
			}
			if (type == 584)
			{
				mech = true;
				noWet = true;
				name = "3 Second Timer";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 144;
				placeStyle = 1;
				width = 10;
				height = 12;
				value = 50;
				toolTip = "Activates every 3 seconds";
				return;
			}
			if (type == 585)
			{
				mech = true;
				noWet = true;
				name = "5 Second Timer";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 144;
				placeStyle = 2;
				width = 10;
				height = 12;
				value = 50;
				toolTip = "Activates every 5 seconds";
				return;
			}
			if (type == 586)
			{
				name = "Candy Cane Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 145;
				width = 12;
				height = 12;
				return;
			}
			if (type == 587)
			{
				name = "Candy Cane Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 29;
				width = 12;
				height = 12;
				return;
			}
			if (type == 588)
			{
				name = "Santa Hat";
				width = 18;
				height = 12;
				headSlot = 44;
				value = 150000;
				vanity = true;
				return;
			}
			if (type == 589)
			{
				name = "Santa Shirt";
				width = 18;
				height = 18;
				bodySlot = 25;
				value = 150000;
				vanity = true;
				return;
			}
			if (type == 590)
			{
				name = "Santa Pants";
				width = 18;
				height = 18;
				legSlot = 24;
				value = 150000;
				vanity = true;
				return;
			}
			if (type == 591)
			{
				name = "Green Candy Cane Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 146;
				width = 12;
				height = 12;
				return;
			}
			if (type == 592)
			{
				name = "Green Candy Cane Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 30;
				width = 12;
				height = 12;
				return;
			}
			if (type == 593)
			{
				name = "Snow Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 147;
				width = 12;
				height = 12;
				return;
			}
			if (type == 594)
			{
				name = "Snow Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 148;
				width = 12;
				height = 12;
				return;
			}
			if (type == 595)
			{
				name = "Snow Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 31;
				width = 12;
				height = 12;
				return;
			}
			if (type == 596)
			{
				name = "Blue Light";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 149;
				placeStyle = 0;
				width = 12;
				height = 12;
				value = 500;
				return;
			}
			if (type == 597)
			{
				name = "Red Light";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 149;
				placeStyle = 1;
				width = 12;
				height = 12;
				value = 500;
				return;
			}
			if (type == 598)
			{
				name = "Green Light";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 149;
				placeStyle = 2;
				width = 12;
				height = 12;
				value = 500;
				return;
			}
			if (type == 599)
			{
				name = "Blue Present";
				width = 12;
				height = 12;
				rare = 1;
				toolTip = "Right click to open";
				return;
			}
			if (type == 600)
			{
				name = "Green Present";
				width = 12;
				height = 12;
				rare = 1;
				toolTip = "Right click to open";
				return;
			}
			if (type == 601)
			{
				name = "Yellow Present";
				width = 12;
				height = 12;
				rare = 1;
				toolTip = "Right click to open";
				return;
			}
			if (type == 602)
			{
				name = "Snow Globe";
				useStyle = 4;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				width = 28;
				height = 28;
				toolTip = "Summons the Frost Legion";
				rare = 2;
				return;
			}
			if (type == 603)
			{
				damage = 0;
				useStyle = 1;
				name = "Carrot";
				shoot = 111;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a pet bunny";
				value = 0;
				buffType = 40;
				return;
			}
			if (type == 604)
			{
				name = "Adamantite Beam";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 150;
				width = 12;
				height = 12;
				return;
			}
			if (type == 605)
			{
				name = "Adamantite Beam Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 32;
				width = 12;
				height = 12;
				return;
			}
			if (type == 606)
			{
				name = "Demonite Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 33;
				width = 12;
				height = 12;
				return;
			}
			if (type == 607)
			{
				name = "Sandstone Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 151;
				width = 12;
				height = 12;
				return;
			}
			if (type == 608)
			{
				name = "Sandstone Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 34;
				width = 12;
				height = 12;
				return;
			}
			if (type == 609)
			{
				name = "Ebonstone Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 152;
				width = 12;
				height = 12;
				return;
			}
			if (type == 610)
			{
				name = "Ebonstone Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 35;
				width = 12;
				height = 12;
				return;
			}
			if (type == 611)
			{
				name = "Red Stucco";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 153;
				width = 12;
				height = 12;
				return;
			}
			if (type == 612)
			{
				name = "Yellow Stucco";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 154;
				width = 12;
				height = 12;
				return;
			}
			if (type == 613)
			{
				name = "Green Stucco";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 155;
				width = 12;
				height = 12;
				return;
			}
			if (type == 614)
			{
				name = "Gray Stucco";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 156;
				width = 12;
				height = 12;
				return;
			}
			if (type == 615)
			{
				name = "Red Stucco Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 36;
				width = 12;
				height = 12;
				return;
			}
			if (type == 616)
			{
				name = "Yellow Stucco Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 37;
				width = 12;
				height = 12;
				return;
			}
			if (type == 617)
			{
				name = "Green Stucco Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 38;
				width = 12;
				height = 12;
				return;
			}
			if (type == 618)
			{
				name = "Gray Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 39;
				width = 12;
				height = 12;
				return;
			}
			if (type == 619)
			{
				name = "Ebonwood";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 157;
				width = 8;
				height = 10;
				return;
			}
			if (type == 620)
			{
				name = "Rich Mahogany";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 158;
				width = 8;
				height = 10;
				return;
			}
			if (type == 621)
			{
				name = "Pearlwood";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 159;
				width = 8;
				height = 10;
				return;
			}
			if (type == 622)
			{
				name = "Ebonwood Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 41;
				width = 12;
				height = 12;
				return;
			}
			if (type == 623)
			{
				name = "Rich Mahogany Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 42;
				width = 12;
				height = 12;
				return;
			}
			if (type == 624)
			{
				name = "Pearlwood Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 43;
				width = 12;
				height = 12;
				return;
			}
			if (type == 625)
			{
				name = "Ebonwood Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 7;
				width = 26;
				height = 22;
				value = 500;
				return;
			}
			if (type == 626)
			{
				name = "Rich Mahogany Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 8;
				width = 26;
				height = 22;
				value = 500;
				return;
			}
			if (type == 627)
			{
				name = "Pearlwood Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 9;
				width = 26;
				height = 22;
				value = 500;
				return;
			}
			if (type == 628)
			{
				name = "Ebonwood Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 2;
				width = 12;
				height = 30;
				return;
			}
			if (type == 629)
			{
				name = "Rich Mahogany Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 3;
				width = 12;
				height = 30;
				return;
			}
			if (type == 630)
			{
				name = "Pearlwood Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 4;
				width = 12;
				height = 30;
				return;
			}
			if (type == 631)
			{
				name = "Ebonwood Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 19;
				placeStyle = 1;
				width = 8;
				height = 10;
				return;
			}
			if (type == 632)
			{
				name = "Rich Mahogany Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 19;
				placeStyle = 2;
				width = 8;
				height = 10;
				return;
			}
			if (type == 633)
			{
				name = "Pearlwood Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 19;
				placeStyle = 3;
				width = 8;
				height = 10;
				return;
			}
			if (type == 634)
			{
				name = "Bone Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 19;
				placeStyle = 4;
				width = 8;
				height = 10;
				return;
			}
			if (type == 635)
			{
				name = "Ebonwood Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 1;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				return;
			}
			if (type == 636)
			{
				name = "Rich Mahogany Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 2;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				return;
			}
			if (type == 637)
			{
				name = "Pearlwood Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 3;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				return;
			}
			if (type == 638)
			{
				name = "Ebonwood Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 1;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 639)
			{
				name = "Rich Mahogany Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 2;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 640)
			{
				name = "Pearlwood Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 3;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 641)
			{
				name = "Ebonwood Piano";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 87;
				placeStyle = 1;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 642)
			{
				name = "Rich Mahogany Piano";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 87;
				placeStyle = 2;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 643)
			{
				name = "Pearlwood Piano";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 87;
				placeStyle = 3;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 644)
			{
				name = "Ebonwood Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 1;
				width = 28;
				height = 20;
				value = 2000;
				return;
			}
			if (type == 645)
			{
				name = "Rich Mahogany Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 2;
				width = 28;
				height = 20;
				value = 2000;
				return;
			}
			if (type == 646)
			{
				name = "Pearlwood Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 3;
				width = 28;
				height = 20;
				value = 2000;
				return;
			}
			if (type == 647)
			{
				name = "Ebonwood Dresser";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 88;
				placeStyle = 1;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 648)
			{
				name = "Rich Mahogany Dresser";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 88;
				placeStyle = 2;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 649)
			{
				name = "Pearlwood Dresser";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 88;
				placeStyle = 3;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 650)
			{
				name = "Ebonwood Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 1;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 651)
			{
				name = "Rich Mahogany Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 2;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 652)
			{
				name = "Pearlwood Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 3;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 653)
			{
				name = "Ebonwood Sword";
				useStyle = 1;
				useTurn = false;
				useAnimation = 21;
				useTime = 21;
				width = 24;
				height = 28;
				damage = 10;
				knockBack = 5f;

				scale = 1f;
				value = 100;
				melee = true;
				return;
			}
			if (type == 654)
			{
				name = "Ebonwood Hammer";
				autoReuse = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 30;
				useTime = 20;
				hammer = 40;
				width = 24;
				height = 28;
				damage = 7;
				knockBack = 5.5f;
				scale = 1.2f;

				value = 50;
				melee = true;
				return;
			}
			if (type == 655)
			{
				name = "Ebonwood Bow";
				useStyle = 5;
				useAnimation = 28;
				useTime = 28;
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = AmmoID.Arrow;

				damage = 8;
				shootSpeed = 6.6f;
				noMelee = true;
				value = 100;
				ranged = true;
				return;
			}
			if (type == 656)
			{
				name = "Rich Mahogany Sword";
				useStyle = 1;
				useTurn = false;
				useAnimation = 23;
				useTime = 23;
				width = 24;
				height = 28;
				damage = 8;
				knockBack = 5f;

				scale = 1f;
				value = 100;
				melee = true;
				return;
			}
			if (type == 657)
			{
				name = "Rich Mahogany Hammer";
				autoReuse = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 33;
				useTime = 23;
				hammer = 35;
				width = 24;
				height = 28;
				damage = 4;
				knockBack = 5.5f;
				scale = 1.1f;

				value = 50;
				melee = true;
				return;
			}
			if (type == 658)
			{
				name = "Rich Mahogany Bow";
				useStyle = 5;
				useAnimation = 29;
				useTime = 29;
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = AmmoID.Arrow;

				damage = 6;
				shootSpeed = 6.6f;
				noMelee = true;
				value = 100;
				ranged = true;
				return;
			}
			if (type == 659)
			{
				name = "Pearlwood Sword";
				useStyle = 1;
				useTurn = false;
				useAnimation = 21;
				useTime = 21;
				width = 24;
				height = 28;
				damage = 11;
				knockBack = 5f;

				scale = 1f;
				value = 100;
				melee = true;
				return;
			}
			if (type == 660)
			{
				name = "Pearlwood Hammer";
				autoReuse = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 29;
				useTime = 19;
				hammer = 45;
				width = 24;
				height = 28;
				damage = 9;
				knockBack = 5.5f;
				scale = 1.25f;

				value = 50;
				melee = true;
				return;
			}
			if (type == 661)
			{
				name = "Pearlwood Bow";
				useStyle = 5;
				useAnimation = 27;
				useTime = 27;
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = AmmoID.Arrow;

				damage = 9;
				shootSpeed = 6.6f;
				noMelee = true;
				value = 100;
				ranged = true;
				return;
			}
			if (type == 662)
			{
				name = "Rainbow Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 160;
				width = 12;
				height = 12;
				return;
			}
			if (type == 663)
			{
				name = "Rainbow Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 44;
				width = 12;
				height = 12;
				return;
			}
			if (type == 664)
			{
				name = "Ice Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 161;
				width = 12;
				height = 12;
				return;
			}
			if (type == 665)
			{
				name = "Red's Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "You shouldn't have this";
				rare = 9;
				wingSlot = 3;
				value = 400000;
				return;
			}
			if (type == 666)
			{
				name = "Red's Helmet";
				width = 18;
				height = 18;
				headSlot = 45;
				rare = 9;
				toolTip = "You shouldn't have this";
				vanity = true;
				return;
			}
			if (type == 667)
			{
				name = "Red's Breastplate";
				width = 18;
				height = 18;
				bodySlot = 26;
				rare = 9;
				toolTip = "You shouldn't have this";
				vanity = true;
				return;
			}
			if (type == 668)
			{
				name = "Red's Leggings";
				width = 18;
				height = 18;
				legSlot = 25;
				rare = 9;
				toolTip = "You shouldn't have this";
				vanity = true;
				return;
			}
			if (type == 669)
			{
				damage = 0;
				useStyle = 1;
				name = "Fish";
				shoot = 112;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a baby penguin";
				buffType = 41;
				value = Item.sellPrice(0, 2, 0, 0);
				return;
			}
			if (type == 670)
			{
				crit = 2;
				noMelee = true;
				useStyle = 1;
				name = "Ice Boomerang";
				shootSpeed = 11.5f;
				shoot = 113;
				damage = 16;
				knockBack = 8.5f;
				width = 14;
				height = 28;

				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				rare = 1;
				value = 50000;
				melee = true;
				return;
			}
			if (type == 671)
			{
				crit = 13;
				autoReuse = true;
				name = "Keybrand";
				useStyle = 1;
				useAnimation = 20;
				useTime = 20;
				knockBack = 6.5f;
				width = 40;
				height = 40;
				damage = 70;
				scale = 1.2f;

				rare = 8;
				value = 138000;
				melee = true;
				return;
			}
			if (type == 672)
			{
				name = "Cutlass";
				useStyle = 1;
				useAnimation = 18;
				knockBack = 4f;
				width = 24;
				height = 28;
				damage = 49;
				scale = 1.1f;

				rare = 4;
				value = 180000;
				melee = true;
				autoReuse = true;
				useTurn = true;
				return;
			}
			if (type == 673)
			{
				name = "Boreal Wood Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 23;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				return;
			}
			if (type == 674)
			{
				name = "True Excalibur";
				useStyle = 1;
				useAnimation = 16;
				useTime = 16;
				shoot = 156;
				shootSpeed = 11f;
				knockBack = 4.5f;
				width = 40;
				height = 40;
				damage = 66;
				scale = 1.05f;

				rare = 8;
				value = Item.sellPrice(0, 10, 0, 0);
				melee = true;
				return;
			}
			if (type == 675)
			{
				name = "True Night's Edge";
				useStyle = 1;
				useAnimation = 26;
				useTime = 26;
				shoot = 157;
				shootSpeed = 10f;
				knockBack = 4.75f;
				width = 40;
				height = 40;
				damage = 90;
				scale = 1.15f;

				rare = 8;
				value = Item.sellPrice(0, 10, 0, 0);
				melee = true;
				return;
			}
			if (type == 676)
			{
				autoReuse = true;
				name = "Frostbrand";
				useStyle = 1;
				useAnimation = 23;
				useTime = 55;
				knockBack = 4.5f;
				width = 24;
				height = 28;
				damage = 49;
				scale = 1.15f;

				rare = 5;
				shoot = 119;
				shootSpeed = 12f;
				value = 250000;
				toolTip = "Shoots an icy bolt";
				melee = true;
				return;
			}
			if (type == 677)
			{
				name = "Boreal Wood Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 28;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 678)
			{
				name = "Red Potion";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				rare = 9;
				return;
			}
			if (type == 679)
			{
				autoReuse = true;
				knockBack = 7f;
				useStyle = 5;
				useAnimation = 34;
				useTime = 34;
				name = "Tactical Shotgun";
				width = 50;
				height = 14;
				shoot = 10;
				useAmmo = AmmoID.Bullet;

				damage = 29;
				shootSpeed = 6f;
				noMelee = true;
				value = 700000;
				rare = 8;
				ranged = true;
				toolTip = "Fires a spread of bullets";
				return;
			}
			if (type == 680)
			{
				name = "Bamboo Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 10;
				width = 26;
				height = 22;
				value = 5000;
				return;
			}
			if (type == 681)
			{
				name = "Ice Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 11;
				width = 26;
				height = 22;
				value = 5000;
				return;
			}
			if (type == 682)
			{
				useStyle = 5;
				useAnimation = 19;
				useTime = 19;
				name = "Marrow";
				width = 14;
				height = 32;
				shoot = 1;
				useAmmo = AmmoID.Arrow;
				damage = 40;
				shootSpeed = 11f;
				knockBack = 4.7f;
				rare = 5;
				crit = 5;
				noMelee = true;
				scale = 1.1f;
				value = 27000;
				ranged = true;
				return;
			}
			if (type == 683)
			{
				autoReuse = true;
				rare = 6;
				mana = 25;
				name = "Unholy Trident";
				noMelee = true;
				useStyle = 5;
				damage = 73;
				useAnimation = 22;
				useTime = 22;
				width = 30;
				height = 30;
				shoot = 114;
				shootSpeed = 13f;
				knockBack = 6.5f;
				toolTip = "Summons the Devil's trident";
				magic = true;
				value = 500000;
				return;
			}
			if (type == 684)
			{
				name = "Frost Helmet";
				width = 18;
				height = 18;
				defense = 10;
				headSlot = 46;
				rare = 5;
				value = 250000;
				toolTip = "16% increased melee and ranged damage";
				return;
			}
			if (type == 685)
			{
				name = "Frost Breastplate";
				width = 18;
				height = 18;
				defense = 20;
				bodySlot = 27;
				rare = 5;
				value = 200000;
				toolTip = "11% increased melee and ranged critical strike chance";
				return;
			}
			if (type == 686)
			{
				name = "Frost Leggings";
				width = 18;
				height = 18;
				defense = 13;
				legSlot = 26;
				rare = 5;
				value = 150000;
				toolTip = "8% increased movement speed";
				toolTip = "7% increased melee attack speed";
				return;
			}
			if (type == 687)
			{
				name = "Tin Helmet";
				width = 18;
				height = 18;
				defense = 2;
				headSlot = 47;
				value = 1875;
				return;
			}
			if (type == 688)
			{
				name = "Tin Chainmail";
				width = 18;
				height = 18;
				defense = 2;
				bodySlot = 28;
				value = Item.sellPrice(0, 0, 0, 50);
				return;
			}
			if (type == 689)
			{
				name = "Tin Greaves";
				width = 18;
				height = 18;
				defense = 1;
				legSlot = 27;
				value = 1125;
				return;
			}
			if (type == 690)
			{
				name = "Lead Helmet";
				width = 18;
				height = 18;
				defense = 3;
				headSlot = 48;
				value = 7500;
				return;
			}
			if (type == 691)
			{
				name = "Lead Chainmail";
				width = 18;
				height = 18;
				defense = 3;
				bodySlot = 29;
				value = 6000;
				return;
			}
			if (type == 692)
			{
				name = "Lead Greaves";
				width = 18;
				height = 18;
				defense = 2;
				legSlot = 28;
				value = 4500;
				return;
			}
			if (type == 693)
			{
				name = "Tungsten Helmet";
				width = 18;
				height = 18;
				defense = 4;
				headSlot = 49;
				value = 7500;
				return;
			}
			if (type == 694)
			{
				name = "Tungsten Chainmail";
				width = 18;
				height = 18;
				defense = 5;
				bodySlot = 30;
				value = 6000;
				return;
			}
			if (type == 695)
			{
				name = "Tungsten Greaves";
				width = 18;
				height = 18;
				defense = 3;
				legSlot = 29;
				value = 4500;
				return;
			}
			if (type == 696)
			{
				name = "Platinum Helmet";
				width = 18;
				height = 18;
				defense = 5;
				headSlot = 50;
				value = 7500;
				return;
			}
			if (type == 697)
			{
				name = "Platinum Chainmail";
				width = 18;
				height = 18;
				defense = 6;
				bodySlot = 31;
				value = 6000;
				return;
			}
			if (type == 698)
			{
				name = "Platinum Greaves";
				width = 18;
				height = 18;
				defense = 5;
				legSlot = 30;
				value = 4500;
				return;
			}
			if (type == 699)
			{
				name = "Tin Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 166;
				width = 12;
				height = 12;
				value = 375;
				return;
			}
			if (type == 700)
			{
				name = "Lead Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 167;
				width = 12;
				height = 12;
				value = 750;
				return;
			}
			if (type == 701)
			{
				name = "Tungsten Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 168;
				width = 12;
				height = 12;
				value = 1500;
				return;
			}
			if (type == 702)
			{
				name = "Platinum Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 169;
				width = 12;
				height = 12;
				value = 3000;
				return;
			}
			if (type == 703)
			{
				name = "Tin Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 1125;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 1;
				return;
			}
			if (type == 704)
			{
				name = "Lead Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 2250;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 3;
				return;
			}
			if (type == 705)
			{
				name = "Tungsten Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 4500;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 5;
				return;
			}
			if (type == 706)
			{
				name = "Platinum Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 9000;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 7;
				return;
			}
			if (type == 707)
			{
				name = "Tin Watch";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Tells the time";
				value = 1500;
				waistSlot = 8;
				return;
			}
			if (type == 708)
			{
				name = "Tungsten Watch";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Tells the time";
				value = 7500;
				waistSlot = 9;
				return;
			}
			if (type == 709)
			{
				name = "Platinum Watch";
				width = 24;
				height = 28;
				accessory = true;
				rare = 1;
				toolTip = "Tells the time";
				value = 15000;
				waistSlot = 4;
				return;
			}
			if (type == 710)
			{
				name = "Tin Chandelier";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 34;
				placeStyle = 3;
				width = 26;
				height = 26;
				value = 4500;
				return;
			}
			if (type == 711)
			{
				name = "Tungsten Chandelier";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 34;
				placeStyle = 4;
				width = 26;
				height = 26;
				value = 18000;
				return;
			}
			if (type == 712)
			{
				name = "Platinum Chandelier";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 34;
				placeStyle = 5;
				width = 26;
				height = 26;
				value = 36000;
				return;
			}
			if (type == 713)
			{
				flame = true;
				name = "Platinum Candle";
				noWet = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 174;
				width = 8;
				height = 18;
				holdStyle = 1;
				return;
			}
			if (type == 714)
			{
				name = "Platinum Candelabra";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 173;
				width = 20;
				height = 20;
				return;
			}
			if (type == 715)
			{
				name = "Platinum Crown";
				width = 18;
				height = 18;
				headSlot = 51;
				value = 15000;
				vanity = true;
				return;
			}
			if (type == 716)
			{
				name = "Lead Anvil";
				placeStyle = 1;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 16;
				width = 28;
				height = 14;
				value = 7500;
				toolTip = "Used to craft items from metal bars";
				return;
			}
			if (type == 717)
			{
				name = "Tin Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 175;
				width = 12;
				height = 12;
				return;
			}
			if (type == 718)
			{
				name = "Tungsten Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 176;
				width = 12;
				height = 12;
				return;
			}
			if (type == 719)
			{
				name = "Platinum Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 177;
				width = 12;
				height = 12;
				return;
			}
			if (type == 720)
			{
				name = "Tin Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 45;
				width = 12;
				height = 12;
				return;
			}
			if (type == 721)
			{
				name = "Tungsten Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 46;
				width = 12;
				height = 12;
				return;
			}
			if (type == 722)
			{
				name = "Platinum Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 47;
				width = 12;
				height = 12;
				return;
			}
			if (type == 723)
			{
				rare = 4;

				name = "Beam Sword";
				useStyle = 1;
				damage = 52;
				useAnimation = 15;
				useTime = 60;
				width = 30;
				height = 30;
				shoot = 116;
				shootSpeed = 11f;
				knockBack = 6.5f;
				toolTip = "Shoots a beam of light";
				melee = true;
				value = 500000;
				return;
			}
			if (type == 724)
			{
				autoReuse = true;
				crit = 2;
				rare = 1;

				name = "Ice Blade";
				useStyle = 1;
				damage = 17;
				useAnimation = 20;
				useTime = 55;
				width = 30;
				height = 30;
				shoot = 118;
				shootSpeed = 9.5f;
				knockBack = 4.75f;
				toolTip = "Shoots an icy bolt";
				melee = true;
				value = 20000;
				return;
			}
			if (type == 725)
			{
				useStyle = 5;
				useAnimation = 21;
				useTime = 21;
				name = "Ice Bow";
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = AmmoID.Arrow;

				damage = 46;
				shootSpeed = 10f;
				knockBack = 4.5f;
				alpha = 30;
				rare = 5;
				noMelee = true;
				value = Item.sellPrice(0, 3, 50, 0);
				toolTip = "Shoots frost arrows";
				ranged = true;
				return;
			}
			if (type == 726)
			{
				autoReuse = true;
				rare = 5;
				mana = 14;

				name = "Frost Staff";
				useStyle = 5;
				damage = 46;
				useAnimation = 20;
				useTime = 20;
				width = 30;
				height = 30;
				shoot = 359;
				shootSpeed = 16f;
				knockBack = 5f;
				toolTip = "Shoots a stream of frost";
				magic = true;
				value = 500000;
				noMelee = true;
				return;
			}
			if (type == 727)
			{
				name = "Wood Helmet";
				width = 18;
				height = 18;
				defense = 1;
				headSlot = 52;
				return;
			}
			if (type == 728)
			{
				name = "Wood Breastplate";
				width = 18;
				height = 18;
				defense = 1;
				bodySlot = 32;
				return;
			}
			if (type == 729)
			{
				name = "Wood Greaves";
				width = 18;
				height = 18;
				defense = 0;
				legSlot = 31;
				return;
			}
			if (type == 730)
			{
				name = "Ebonwood Helmet";
				width = 18;
				height = 18;
				defense = 1;
				headSlot = 53;
				return;
			}
			if (type == 731)
			{
				name = "Ebonwood Breastplate";
				width = 18;
				height = 18;
				defense = 2;
				bodySlot = 33;
				return;
			}
			if (type == 732)
			{
				name = "Ebonwood Greaves";
				width = 18;
				height = 18;
				defense = 1;
				legSlot = 32;
				return;
			}
			if (type == 733)
			{
				name = "Rich Mahogany Helmet";
				width = 18;
				height = 18;
				defense = 1;
				headSlot = 54;
				return;
			}
			if (type == 734)
			{
				name = "Rich Mahogany Breastplate";
				width = 18;
				height = 18;
				defense = 1;
				bodySlot = 34;
				return;
			}
			if (type == 735)
			{
				name = "Rich Mahogany Greaves";
				width = 18;
				height = 18;
				defense = 1;
				legSlot = 33;
				return;
			}
			if (type == 736)
			{
				name = "Pearlwood Helmet";
				width = 18;
				height = 18;
				defense = 2;
				headSlot = 55;
				return;
			}
			if (type == 737)
			{
				name = "Pearlwood Breastplate";
				width = 18;
				height = 18;
				defense = 3;
				bodySlot = 35;
				return;
			}
			if (type == 738)
			{
				name = "Pearlwood Greaves";
				width = 18;
				height = 18;
				defense = 2;
				legSlot = 34;
				return;
			}
			if (type == 739)
			{
				name = "Amethyst Staff";
				mana = 3;

				useStyle = 5;
				damage = 14;
				useAnimation = 40;
				useTime = 40;
				width = 40;
				height = 40;
				shoot = 121;
				shootSpeed = 6f;
				knockBack = 3.25f;
				value = 2000;
				magic = true;
				noMelee = true;
				return;
			}
			if (type == 740)
			{
				name = "Topaz Staff";
				mana = 4;

				useStyle = 5;
				damage = 15;
				useAnimation = 38;
				useTime = 38;
				width = 40;
				height = 40;
				shoot = 122;
				shootSpeed = 6.5f;
				knockBack = 3.5f;
				value = 3000;
				magic = true;
				noMelee = true;
				return;
			}
			if (type == 741)
			{
				name = "Sapphire Staff";
				mana = 5;

				useStyle = 5;
				damage = 17;
				useAnimation = 34;
				useTime = 34;
				width = 40;
				height = 40;
				shoot = 123;
				shootSpeed = 7.5f;
				knockBack = 4f;
				value = 10000;
				magic = true;
				rare = 1;
				noMelee = true;
				return;
			}
			if (type == 742)
			{
				name = "Emerald Staff";
				mana = 6;

				useStyle = 5;
				damage = 19;
				useAnimation = 32;
				useTime = 32;
				width = 40;
				height = 40;
				shoot = 124;
				shootSpeed = 8f;
				knockBack = 4.25f;
				magic = true;
				autoReuse = true;
				value = 15000;
				rare = 1;
				noMelee = true;
				return;
			}
			if (type == 743)
			{
				name = "Ruby Staff";
				mana = 7;

				useStyle = 5;
				damage = 21;
				useAnimation = 28;
				useTime = 28;
				width = 40;
				height = 40;
				shoot = 125;
				shootSpeed = 9f;
				knockBack = 4.75f;
				magic = true;
				autoReuse = true;
				value = 20000;
				rare = 1;
				noMelee = true;
				return;
			}
			if (type == 744)
			{
				name = "Diamond Staff";
				mana = 8;

				useStyle = 5;
				damage = 23;
				useAnimation = 26;
				useTime = 26;
				width = 40;
				height = 40;
				shoot = 126;
				shootSpeed = 9.5f;
				knockBack = 5.5f;
				magic = true;
				autoReuse = true;
				value = 30000;
				rare = 2;
				noMelee = true;
				return;
			}
			if (type == 745)
			{
				name = "Grass Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 66;
				width = 12;
				height = 12;
				value = 10;
				return;
			}
			if (type == 746)
			{
				name = "Jungle Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 67;
				width = 12;
				height = 12;
				value = 10;
				return;
			}
			if (type == 747)
			{
				name = "Flower Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 68;
				width = 12;
				height = 12;
				value = 10;
				return;
			}
			if (type == 748)
			{
				name = "Jetpack";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				toolTip2 = "Hold up to rocket faster";
				value = 400000;
				rare = 5;
				wingSlot = 4;
				return;
			}
			if (type == 749)
			{
				name = "Butterfly Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 5;
				return;
			}
			if (type == 750)
			{
				name = "Cactus Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 72;
				width = 12;
				height = 12;
				return;
			}
			if (type == 751)
			{
				name = "Cloud";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 189;
				width = 12;
				height = 12;
				return;
			}
			if (type == 752)
			{
				name = "Cloud Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 73;
				width = 12;
				height = 12;
				return;
			}
			if (type == 753)
			{
				damage = 0;
				useStyle = 1;
				name = "Seaweed";
				shoot = 127;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a turtle";
				value = Item.sellPrice(0, 2, 0, 0);
				buffType = 42;
				return;
			}
			if (type == 754)
			{
				name = "Rune Hat";
				width = 28;
				height = 20;
				headSlot = 56;
				rare = 5;
				value = 50000;
				vanity = true;
				return;
			}
			if (type == 755)
			{
				name = "Rune Robe";
				width = 18;
				height = 14;
				bodySlot = 36;
				value = 50000;
				vanity = true;
				rare = 5;
				return;
			}
			if (type == 756)
			{
				rare = 7;
				name = "Mushroom Spear";
				useStyle = 5;
				useAnimation = 40;
				useTime = 40;
				shootSpeed = 5.5f;
				knockBack = 6.2f;
				width = 32;
				height = 32;
				damage = 60;
				scale = 1f;

				shoot = 130;
				value = Item.buyPrice(0, 70, 0, 0);
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			}
			if (type == 757)
			{
				rare = 8;

				name = "Terra Blade";
				useStyle = 1;
				damage = 95;
				useAnimation = 16;
				useTime = 16;
				width = 30;
				height = 30;
				shoot = 132;
				scale = 1.1f;
				shootSpeed = 12f;
				knockBack = 6.5f;
				melee = true;
				value = Item.sellPrice(0, 20, 0, 0);
				autoReuse = true;
				return;
			}
			if (type == 758)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 30;
				useTime = 30;
				name = "Grenade Launcher";
				useAmmo = AmmoID.Rocket;
				width = 50;
				height = 20;
				shoot = 133;

				damage = 60;
				shootSpeed = 10f;
				noMelee = true;
				value = 100000;
				knockBack = 4f;
				rare = 8;
				ranged = true;
				return;
			}
			if (type == 759)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 30;
				useTime = 30;
				name = "Rocket Launcher";
				useAmmo = AmmoID.Rocket;
				width = 50;
				height = 20;
				shoot = 134;

				damage = 50;
				shootSpeed = 5f;
				noMelee = true;
				value = 100000;
				knockBack = 4f;
				rare = 8;
				ranged = true;
				return;
			}
			if (type == 760)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 40;
				useTime = 40;
				name = "Proximity Mine Launcher";
				useAmmo = AmmoID.Rocket;
				width = 50;
				height = 20;
				shoot = 135;

				damage = 80;
				shootSpeed = 12f;
				noMelee = true;
				value = Item.buyPrice(0, 35, 0, 0);
				knockBack = 4f;
				rare = 8;
				ranged = true;
				return;
			}
			if (type == 761)
			{
				name = "Fairy Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 6;
				return;
			}
			if (type == 762)
			{
				name = "Slime Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 193;
				width = 12;
				height = 12;
				return;
			}
			if (type == 763)
			{
				name = "Flesh Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 195;
				width = 12;
				height = 12;
				return;
			}
			if (type == 764)
			{
				name = "Mushroom Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 74;
				width = 12;
				height = 12;
				return;
			}
			if (type == 765)
			{
				name = "Rain Cloud";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 196;
				width = 12;
				height = 12;
				return;
			}
			if (type == 766)
			{
				name = "Bone Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 194;
				width = 12;
				height = 12;
				return;
			}
			if (type == 767)
			{
				name = "Frozen Slime Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 197;
				width = 12;
				height = 12;
				return;
			}
			if (type == 768)
			{
				name = "Bone Block Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 75;
				width = 12;
				height = 12;
				return;
			}
			if (type == 769)
			{
				name = "Slime Block Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 76;
				width = 12;
				height = 12;
				return;
			}
			if (type == 770)
			{
				name = "Flesh Block Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 77;
				width = 12;
				height = 12;
				return;
			}
			if (type == 771)
			{
				name = "Rocket I";
				shoot = 0;
				damage = 40;
				width = 20;
				height = 14;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Rocket;
				knockBack = 4f;
				value = Item.buyPrice(0, 0, 0, 50);
				ranged = true;
				toolTip = "Small blast radius. Will not destroy tiles";
				return;
			}
			if (type == 772)
			{
				name = "Rocket II";
				shoot = 3;
				damage = 40;
				width = 20;
				height = 14;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Rocket;
				knockBack = 4f;
				value = Item.buyPrice(0, 0, 2, 50);
				ranged = true;
				toolTip = "Small blast radius. Will destroy tiles";
				rare = 1;
				return;
			}
			if (type == 773)
			{
				name = "Rocket III";
				shoot = 6;
				damage = 65;
				width = 20;
				height = 14;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Rocket;
				knockBack = 6f;
				value = Item.buyPrice(0, 0, 1, 0);
				ranged = true;
				toolTip = "Large blast radius. Will not destroy tiles";
				rare = 1;
				return;
			}
			if (type == 774)
			{
				name = "Rocket IV";
				shoot = 9;
				damage = 65;
				width = 20;
				height = 14;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Rocket;
				knockBack = 6f;
				value = (value = Item.buyPrice(0, 0, 5, 0));
				ranged = true;
				toolTip = "Large blast radius. Will destroy tiles";
				rare = 2;
				return;
			}
			if (type == 775)
			{
				name = "Asphalt Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 198;
				width = 12;
				height = 12;
				toolTip = "Increases running speed";
				return;
			}
			if (type == 776)
			{
				name = "Cobalt Pickaxe";
				useStyle = 1;
				useTurn = true;
				autoReuse = true;
				useAnimation = 25;
				useTime = 13;
				knockBack = 5f;
				width = 20;
				height = 12;
				damage = 10;
				pick = 110;

				rare = 4;
				value = 54000;
				melee = true;
				toolTip = "Can mine Mythril and Orichalcum";
				scale = 1.15f;
				return;
			}
			if (type == 777)
			{
				name = "Mythril Pickaxe";
				useStyle = 1;
				useAnimation = 25;
				useTime = 10;
				knockBack = 5f;
				useTurn = true;
				autoReuse = true;
				width = 20;
				height = 12;
				damage = 15;
				pick = 150;

				rare = 4;
				value = 81000;
				melee = true;
				toolTip = "Can mine Adamantite and Titanium";
				scale = 1.15f;
				return;
			}
			if (type == 778)
			{
				name = "Adamantite Pickaxe";
				useStyle = 1;
				useAnimation = 25;
				useTime = 7;
				knockBack = 5f;
				useTurn = true;
				autoReuse = true;
				width = 20;
				height = 12;
				damage = 20;
				pick = 180;

				rare = 4;
				value = 108000;
				melee = true;
				scale = 1.15f;
				return;
			}
			if (type == 779)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 30;
				useTime = 5;
				name = "Clentaminator";
				width = 50;
				height = 18;
				shoot = 145;
				useAmmo = AmmoID.Solution;

				knockBack = 0.3f;
				shootSpeed = 7f;
				noMelee = true;
				value = Item.buyPrice(2, 0, 0, 0);
				rare = 5;
				toolTip = "Creates and destroys biomes when sprayed";
				toolTip2 = "Uses colored solution";
				return;
			}
			if (type == 780)
			{
				name = "Green Solution";
				shoot = 0;
				ammo = AmmoID.Solution;
				width = 10;
				height = 12;
				value = Item.buyPrice(0, 0, 25, 0);
				rare = 3;
				maxStack = 999;
				toolTip = "Used by the Clentaminator";
				toolTip2 = "Spreads the purity";
				consumable = true;
				return;
			}
			if (type == 781)
			{
				name = "Blue Solution";
				shoot = 1;
				ammo = AmmoID.Solution;
				width = 10;
				height = 12;
				value = Item.buyPrice(0, 0, 25, 0);
				rare = 3;
				maxStack = 999;
				toolTip = "Used by the Clentaminator";
				toolTip2 = "Spreads the hallow";
				consumable = true;
				return;
			}
			if (type == 782)
			{
				name = "Purple Solution";
				shoot = 2;
				ammo = AmmoID.Solution;
				width = 10;
				height = 12;
				value = Item.buyPrice(0, 0, 25, 0);
				rare = 3;
				maxStack = 999;
				toolTip = "Used by the Clentaminator";
				toolTip2 = "Spreads the corruption";
				consumable = true;
				return;
			}
			if (type == 783)
			{
				name = "Dark Blue Solution";
				shoot = 3;
				ammo = AmmoID.Solution;
				width = 10;
				height = 12;
				value = Item.buyPrice(0, 0, 25, 0);
				rare = 3;
				maxStack = 999;
				toolTip = "Used by the Clentaminator";
				toolTip2 = "Spreads glowing mushrooms";
				consumable = true;
				return;
			}
			if (type == 784)
			{
				name = "Red Solution";
				shoot = 4;
				ammo = AmmoID.Solution;
				width = 10;
				height = 12;
				value = Item.buyPrice(0, 0, 25, 0);
				rare = 3;
				maxStack = 999;
				toolTip = "Used by the Clentaminator";
				toolTip2 = "Spreads the crimson";
				consumable = true;
				return;
			}
			if (type == 785)
			{
				name = "Harpy Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 7;
				return;
			}
			if (type == 786)
			{
				name = "Bone Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 8;
				return;
			}
			if (type == 787)
			{
				name = "Hammush";
				useTurn = true;
				autoReuse = true;
				useStyle = 1;
				useAnimation = 27;
				useTime = 14;
				hammer = 85;
				width = 24;
				height = 28;
				damage = 26;
				knockBack = 7.5f;
				scale = 1.1f;

				rare = 7;
				value = Item.buyPrice(0, 40, 0, 0);
				melee = true;
				toolTip = "Strong enough to destroy Demon Altars";
				return;
			}
			if (type == 788)
			{
				mana = 10;
				damage = 28;
				useStyle = 5;
				name = "Nettle Burst";
				shootSpeed = 32f;
				shoot = 150;
				width = 26;
				height = 28;

				useAnimation = 25;
				useTime = 25;
				autoReuse = true;
				rare = 7;
				noMelee = true;
				knockBack = 1f;
				toolTip = "Summons a thorn spear";
				value = 200000;
				magic = true;
				return;
			}
			if (type == 789)
			{
				name = "Ankh Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 4;
				width = 10;
				height = 24;
				value = 5000;
				return;
			}
			if (type == 790)
			{
				name = "Snake Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 5;
				width = 10;
				height = 24;
				value = 5000;
				return;
			}
			if (type == 791)
			{
				name = "Omega Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 6;
				width = 10;
				height = 24;
				value = 5000;
				return;
			}
			if (type == 792)
			{
				name = "Crimson Helmet";
				width = 18;
				height = 18;
				defense = 6;
				headSlot = 57;
				value = 50000;
				toolTip = "2% increased damage";
				rare = 1;
				return;
			}
			if (type == 793)
			{
				name = "Crimson Scalemail";
				width = 18;
				height = 18;
				defense = 7;
				bodySlot = 37;
				value = 40000;
				toolTip = "2% increased damage";
				rare = 1;
				return;
			}
			if (type == 794)
			{
				name = "Crimson Greaves";
				width = 18;
				height = 18;
				defense = 6;
				legSlot = 35;
				value = 30000;
				toolTip = "2% increased damage";
				rare = 1;
				return;
			}
			if (type == 795)
			{
				name = "Blood Butcherer";
				useStyle = 1;
				useAnimation = 25;
				knockBack = 5f;
				width = 24;
				height = 28;
				damage = 22;
				scale = 1.1f;

				rare = 1;
				value = 13500;
				melee = true;
				return;
			}
			if (type == 796)
			{
				useStyle = 5;
				useAnimation = 30;
				useTime = 30;
				name = "Tendon Bow";
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = AmmoID.Arrow;

				damage = 19;
				shootSpeed = 6.7f;
				knockBack = 1f;
				alpha = 30;
				rare = 1;
				noMelee = true;
				value = 18000;
				ranged = true;
				return;
			}
			if (type == 797)
			{
				name = "Flesh Grinder";
				autoReuse = true;
				useStyle = 1;
				useAnimation = 40;
				useTime = 19;
				hammer = 55;
				width = 24;
				height = 28;
				damage = 23;
				knockBack = 6f;
				scale = 1.2f;

				rare = 1;
				value = 15000;
				melee = true;
				return;
			}
			if (type == 798)
			{
				name = "Deathbringer Pickaxe";
				useStyle = 1;
				useTurn = true;
				useAnimation = 22;
				useTime = 14;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 12;
				pick = 70;

				knockBack = 3.5f;
				rare = 1;
				value = 18000;
				scale = 1.15f;
				toolTip = "Able to mine Hellstone";
				melee = true;
				return;
			}
			if (type == 799)
			{
				name = "Blood Lust Cluster";
				autoReuse = true;
				useStyle = 1;
				useAnimation = 32;
				knockBack = 6f;
				useTime = 15;
				width = 24;
				height = 28;
				damage = 22;
				axe = 15;
				scale = 1.2f;

				rare = 1;
				value = 13500;
				melee = true;
				return;
			}
			if (type == 800)
			{
				useStyle = 5;
				useAnimation = 23;
				useTime = 23;
				name = "The Undertaker";
				width = 24;
				height = 28;
				shoot = 14;
				useAmmo = AmmoID.Bullet;

				damage = 15;
				shootSpeed = 6f;
				noMelee = true;
				knockBack = 1f;
				value = 50000;
				scale = 0.9f;
				rare = 1;
				ranged = true;
				return;
			}
			if (type == 801)
			{
				name = "The Meatball";
				useStyle = 5;
				useAnimation = 45;
				useTime = 45;
				knockBack = 6.5f;
				width = 30;
				height = 10;
				damage = 16;
				scale = 1.1f;
				noUseGraphic = true;
				shoot = 154;
				shootSpeed = 12f;

				rare = 1;
				value = 27000;
				melee = true;
				channel = true;
				noMelee = true;
				return;
			}
			if (type == 802)
			{
				name = "The Rotted Fork";
				useStyle = 5;
				useAnimation = 31;
				useTime = 31;
				shootSpeed = 4f;
				knockBack = 5f;
				width = 40;
				height = 40;
				damage = 14;
				scale = 1.1f;

				shoot = 153;
				rare = 1;
				value = 10000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			}
			if (type == 803)
			{
				name = "Eskimo Hood";
				width = 18;
				height = 18;
				headSlot = 58;
				value = 50000;
				defense = 1;
				return;
			}
			if (type == 804)
			{
				name = "Eskimo Coat";
				width = 18;
				height = 18;
				bodySlot = 38;
				value = 40000;
				defense = 2;
				return;
			}
			if (type == 805)
			{
				name = "Eskimo Pants";
				width = 18;
				height = 18;
				legSlot = 36;
				value = 30000;
				defense = 1;
				return;
			}
			if (type == 806)
			{
				name = "Living Wood Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 5;
				width = 12;
				height = 30;
				return;
			}
			if (type == 807)
			{
				name = "Cactus Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 6;
				width = 12;
				height = 30;
				return;
			}
			if (type == 808)
			{
				name = "Bone Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 7;
				width = 12;
				height = 30;
				return;
			}
			if (type == 809)
			{
				name = "Flesh Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 8;
				width = 12;
				height = 30;
				return;
			}
			if (type == 810)
			{
				name = "Mushroom Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 9;
				width = 12;
				height = 30;
				return;
			}
			if (type == 811)
			{
				name = "Bone Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 4;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				return;
			}
			if (type == 812)
			{
				name = "Cactus Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 5;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				return;
			}
			if (type == 813)
			{
				name = "Flesh Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 6;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				return;
			}
			if (type == 814)
			{
				name = "Mushroom Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 7;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				return;
			}
			if (type == 815)
			{
				name = "Slime Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 8;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				return;
			}
			if (type == 816)
			{
				name = "Cactus Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 4;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 817)
			{
				name = "Flesh Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 5;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 818)
			{
				name = "Mushroom Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 6;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 819)
			{
				name = "Living Wood Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 7;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 820)
			{
				name = "Bone Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 8;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 821)
			{
				name = "Flame Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 9;
				return;
			}
			if (type == 822)
			{
				name = "Frozen Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 10;
				return;
			}
			if (type == 823)
			{
				name = "Ghost Wings";
				color = new Color(255, 255, 255, 0);
				alpha = 255;
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 8;
				wingSlot = 11;
				return;
			}
			if (type == 824)
			{
				name = "Sunplate Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 202;
				width = 12;
				height = 12;
				return;
			}
			if (type == 825)
			{
				name = "Disc Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 82;
				width = 12;
				height = 12;
				return;
			}
			if (type == 826)
			{
				name = "Skyware Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 10;
				width = 12;
				height = 30;
				return;
			}
			if (type == 827)
			{
				name = "Bone Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 4;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 828)
			{
				name = "Flesh Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 5;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 829)
			{
				name = "Living Wood Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 6;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 830)
			{
				name = "Skyware Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 7;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 831)
			{
				name = "Living Wood Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 12;
				width = 26;
				height = 22;
				value = 5000;
				return;
			}
			if (type == 832)
			{
				name = "Living Wood Wand";
				tileWand = 9;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				createTile = 191;
				width = 8;
				height = 10;
				rare = 1;
				toolTip = "Places living wood";
				return;
			}
			if (type == 833)
			{
				name = "Purple Ice Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 163;
				width = 12;
				height = 12;
				return;
			}
			if (type == 834)
			{
				name = "Pink Ice Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 164;
				width = 12;
				height = 12;
				return;
			}
			if (type == 835)
			{
				name = "Red Ice Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 200;
				width = 12;
				height = 12;
				return;
			}
			if (type == 836)
			{
				name = "Crimstone";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 203;
				width = 12;
				height = 12;
				return;
			}
			if (type == 837)
			{
				name = "Skyware Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 9;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 838)
			{
				name = "Skyware Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 13;
				width = 26;
				height = 22;
				value = 5000;
				return;
			}
			if (type == 839)
			{
				name = "Steampunk Hat";
				width = 28;
				height = 20;
				headSlot = 59;
				rare = 2;
				vanity = true;
				value = Item.buyPrice(0, 1, 50, 0);
				return;
			}
			if (type == 840)
			{
				name = "Steampunk Shirt";
				width = 18;
				height = 14;
				bodySlot = 39;
				rare = 2;
				vanity = true;
				value = Item.buyPrice(0, 1, 50, 0);
				return;
			}
			if (type == 841)
			{
				name = "Steampunk Pants";
				width = 18;
				height = 14;
				legSlot = 37;
				rare = 2;
				vanity = true;
				value = Item.buyPrice(0, 1, 50, 0);
				return;
			}
			if (type == 842)
			{
				name = "Bee Hat";
				width = 28;
				height = 20;
				headSlot = 60;
				rare = 1;
				vanity = true;
				return;
			}
			if (type == 843)
			{
				name = "Bee Shirt";
				width = 18;
				height = 14;
				bodySlot = 40;
				rare = 1;
				vanity = true;
				return;
			}
			if (type == 844)
			{
				name = "Bee Pants";
				width = 18;
				height = 14;
				legSlot = 38;
				rare = 1;
				vanity = true;
				return;
			}
			if (type == 845)
			{
				name = "World Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 7;
				width = 10;
				height = 24;
				value = 5000;
				return;
			}
			if (type == 846)
			{
				name = "Sun Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 8;
				width = 10;
				height = 24;
				value = 5000;
				return;
			}
			if (type == 847)
			{
				name = "Gravity Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 9;
				width = 10;
				height = 24;
				value = 5000;
				return;
			}
			if (type == 848)
			{
				name = "Pharaoh's Mask";
				width = 28;
				height = 20;
				headSlot = 61;
				rare = 1;
				vanity = true;
				return;
			}
			if (type == 849)
			{
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				name = "Actuator";
				width = 24;
				height = 28;
				toolTip = "Enables solid blocks to be toggled on and off";
				maxStack = 999;
				mech = true;
				value = Item.buyPrice(0, 0, 10, 0);
				return;
			}
			if (type == 850)
			{
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 5;
				autoReuse = true;
				name = "Blue Wrench";
				width = 24;
				height = 28;
				rare = 1;
				toolTip = "Places blue wire";
				value = 20000;
				mech = true;
				tileBoost = 20;
				return;
			}
			if (type == 851)
			{
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 5;
				autoReuse = true;
				name = "Green Wrench";
				width = 24;
				height = 28;
				rare = 1;
				toolTip = "Places green wire";
				value = 20000;
				mech = true;
				tileBoost = 20;
				return;
			}
			if (type == 852)
			{
				name = "Blue Pressure Plate";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 135;
				width = 12;
				height = 12;
				placeStyle = 4;
				mech = true;
				value = 5000;
				toolTip = "Activates when a player steps on it on";
				return;
			}
			if (type == 853)
			{
				name = "Yellow Pressure Plate";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 135;
				width = 12;
				height = 12;
				placeStyle = 5;
				mech = true;
				value = 5000;
				toolTip = "Activates when anything but a player steps on it on";
				return;
			}
			if (type == 854)
			{
				name = "Discount Card";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Shops have lower prices";
				value = 50000;
				return;
			}
			if (type == 855)
			{
				name = "Lucky Coin";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Hitting enemies will sometimes drop extra coins";
				value = 50000;
				return;
			}
			if (type == 856)
			{
				noWet = true;
				name = "Stick Unicorn";
				holdStyle = 1;
				width = 30;
				height = 30;
				toolTip = "'Having a wonderful time!'";
				value = 500;
				rare = 2;
				vanity = true;
				return;
			}
			if (type == 857)
			{
				name = "Sandstorm in a Bottle";
				width = 16;
				height = 24;
				accessory = true;
				rare = 2;
				toolTip = "Allows the holder to double jump";
				value = 50000;
				return;
			}
			if (type == 858)
			{
				name = "Boreal Wood Sofa";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 89;
				placeStyle = 24;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 859)
			{
				useStyle = 1;
				name = "Beach Ball";
				shootSpeed = 6f;
				shoot = 155;
				width = 44;
				height = 44;
				consumable = true;

				useAnimation = 20;
				useTime = 20;
				noUseGraphic = true;
				noMelee = true;
				value = 20;
				return;
			}
			if (type == 860)
			{
				name = "Charm of Myths";
				width = 16;
				height = 24;
				accessory = true;
				rare = 6;
				lifeRegen = 1;
				toolTip = "Provides life regeneration and reduces the cooldown of healing potions";
				value = 500000;
				handOnSlot = 4;
				return;
			}
			if (type == 861)
			{
				name = "Moon Shell";
				width = 16;
				height = 24;
				accessory = true;
				rare = 6;
				toolTip = "Turns the holder into a werewolf on full moons and a merfolk when entering water";
				value = 500000;
				return;
			}
			if (type == 862)
			{
				name = "Star Veil";
				width = 16;
				height = 24;
				accessory = true;
				rare = 6;
				toolTip = "Causes stars to fall and increases length of invincibility after taking damage";
				value = 500000;
				neckSlot = 5;
				return;
			}
			if (type == 863)
			{
				name = "Water Walking Boots";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Provides the ability to walk on water";
				value = 200000;
				shoeSlot = 2;
				return;
			}
			if (type == 864)
			{
				name = "Tiara";
				width = 28;
				height = 20;
				headSlot = 62;
				rare = 1;
				vanity = true;
				value = Item.buyPrice(0, 25, 0, 0);
				return;
			}
			if (type == 865)
			{
				name = "Princess Dress";
				width = 18;
				height = 14;
				bodySlot = 41;
				rare = 1;
				vanity = true;
				value = Item.buyPrice(0, 10, 0, 0);
				return;
			}
			if (type == 866)
			{
				name = "Pharaoh's Robe";
				width = 18;
				height = 14;
				bodySlot = 42;
				rare = 1;
				vanity = true;
				return;
			}
			if (type == 867)
			{
				name = "Green Cap";
				width = 28;
				height = 20;
				headSlot = 63;
				rare = 1;
				vanity = true;
				return;
			}
			if (type == 868)
			{
				name = "Mushroom Cap";
				width = 28;
				height = 20;
				headSlot = 64;
				rare = 1;
				vanity = true;
				value = Item.buyPrice(0, 2, 0, 0);
				return;
			}
			if (type == 869)
			{
				name = "Tam O' Shanter";
				width = 28;
				height = 20;
				headSlot = 65;
				rare = 1;
				vanity = true;
				value = Item.buyPrice(0, 2, 50, 0);
				return;
			}
			if (type == 870)
			{
				name = "Mummy Mask";
				width = 28;
				height = 20;
				headSlot = 66;
				rare = 1;
				vanity = true;
				return;
			}
			if (type == 871)
			{
				name = "Mummy Shirt";
				width = 28;
				height = 20;
				bodySlot = 43;
				rare = 1;
				vanity = true;
				return;
			}
			if (type == 872)
			{
				name = "Mummy Pants";
				width = 28;
				height = 20;
				legSlot = 39;
				rare = 1;
				vanity = true;
				return;
			}
			if (type == 873)
			{
				name = "Cowboy Hat";
				width = 28;
				height = 20;
				headSlot = 67;
				rare = 1;
				vanity = true;
				value = Item.buyPrice(0, 5, 0, 0);
				return;
			}
			if (type == 874)
			{
				name = "Cowboy Jacket";
				width = 28;
				height = 20;
				bodySlot = 44;
				rare = 1;
				vanity = true;
				value = Item.buyPrice(0, 5, 0, 0);
				return;
			}
			if (type == 875)
			{
				name = "Cowboy Pants";
				width = 28;
				height = 20;
				legSlot = 40;
				rare = 1;
				vanity = true;
				value = Item.buyPrice(0, 5, 0, 0);
				return;
			}
			if (type == 876)
			{
				name = "Pirate Hat";
				width = 28;
				height = 20;
				headSlot = 68;
				rare = 1;
				vanity = true;
				value = Item.buyPrice(0, 5, 0, 0);
				return;
			}
			if (type == 877)
			{
				name = "Pirate Shirt";
				width = 28;
				height = 20;
				bodySlot = 45;
				rare = 1;
				vanity = true;
				value = Item.buyPrice(0, 5, 0, 0);
				return;
			}
			if (type == 878)
			{
				name = "Pirate Pants";
				width = 28;
				height = 20;
				legSlot = 41;
				rare = 1;
				vanity = true;
				value = Item.buyPrice(0, 5, 0, 0);
				return;
			}
			if (type == 879)
			{
				name = "Viking Helmet";
				width = 28;
				height = 20;
				headSlot = 69;
				rare = 1;
				defense = 4;
				value = Item.sellPrice(0, 0, 50, 0);
				return;
			}
			if (type == 880)
			{
				name = "Crimtane";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 204;
				width = 12;
				height = 12;
				rare = 1;
				value = 4500;
				return;
			}
			if (type == 881)
			{
				name = "Cactus Sword";
				useStyle = 1;
				useTurn = false;
				useAnimation = 25;
				useTime = 25;
				width = 24;
				height = 28;
				damage = 9;
				knockBack = 5f;

				scale = 1f;
				value = 1800;
				melee = true;
				return;
			}
			if (type == 882)
			{
				name = "Cactus Pickaxe";
				useStyle = 1;
				useTurn = true;
				useAnimation = 23;
				useTime = 15;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 5;
				pick = 35;

				knockBack = 2f;
				value = 2000;
				melee = true;
				return;
			}
			if (type == 883)
			{
				name = "Ice Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 206;
				width = 12;
				height = 12;
				return;
			}
			if (type == 884)
			{
				name = "Ice Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 84;
				width = 12;
				height = 12;
				return;
			}
			if (type == 885)
			{
				name = "Adhesive Bandage";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Immunity to Bleeding";
				value = 100000;
				return;
			}
			if (type == 886)
			{
				name = "Armor Polish";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Immunity to Broken Armor";
				value = 100000;
				return;
			}
			if (type == 887)
			{
				name = "Bezoar";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Immunity to Poison";
				value = 100000;
				return;
			}
			if (type == 888)
			{
				name = "Blindfold";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Immunity to Darkness";
				value = 100000;
				faceSlot = 5;
				return;
			}
			if (type == 889)
			{
				name = "Fast Clock";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Immunity to Slow";
				value = 100000;
				return;
			}
			if (type == 890)
			{
				name = "Megaphone";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Immunity to Silence";
				value = 100000;
				return;
			}
			if (type == 891)
			{
				name = "Nazar";
				width = 16;
				height = 24;
				accessory = true;
				rare = 2;
				toolTip = "Immunity to Curse";
				value = 100000;
				return;
			}
			if (type == 892)
			{
				name = "Vitamins";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Immunity to Weakness";
				value = 100000;
				return;
			}
			if (type == 893)
			{
				name = "Trifold Map";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Immunity to Confusion";
				value = 100000;
				return;
			}
			if (type == 894)
			{
				name = "Cactus Helmet";
				width = 18;
				height = 18;
				defense = 1;
				headSlot = 70;
				return;
			}
			if (type == 895)
			{
				name = "Cactus Breastplate";
				width = 18;
				height = 18;
				defense = 2;
				bodySlot = 46;
				return;
			}
			if (type == 896)
			{
				name = "Cactus Leggings";
				width = 18;
				height = 18;
				defense = 1;
				legSlot = 42;
				return;
			}
			if (type == 897)
			{
				name = "Power Glove";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Increases melee knockback";
				toolTip = "12% increased melee speed";
				value = 300000;
				handOffSlot = 5;
				handOnSlot = 10;
				return;
			}
			if (type == 898)
			{
				name = "Lightning Boots";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Allows flight and super fast running";
				toolTip = "7% increased movement speed";
				value = 300000;
				shoeSlot = 10;
				return;
			}
			if (type == 899)
			{
				name = "Sun Stone";
				width = 16;
				height = 24;
				accessory = true;
				rare = 7;
				toolTip = "Increases all stats if worn during the day";
				value = 300000;
				handOnSlot = 13;
				return;
			}
			if (type == 900)
			{
				name = "Moon Stone";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Increases all stats if worn during the night";
				value = 300000;
				handOnSlot = 14;
				return;
			}
			if (type == 901)
			{
				name = "Armor Bracing";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Immunity to Weakness and Broken Armor";
				value = 100000;
				return;
			}
			if (type == 902)
			{
				name = "Medicated Bandage";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Immunity to Poison and Bleeding";
				value = 100000;
				return;
			}
			if (type == 903)
			{
				name = "The Plan";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Immunity to Slow and Confusion";
				value = 100000;
				return;
			}
			if (type == 904)
			{
				name = "Countercurse Mantra";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Immunity to Silence and Curse";
				value = 100000;
				return;
			}
			if (type == 905)
			{
				name = "Coin Gun";
				useStyle = 5;
				autoReuse = true;
				useAnimation = 8;
				useTime = 8;
				width = 50;
				height = 18;
				shoot = 158;
				useAmmo = AmmoID.Coin;

				damage = 0;
				shootSpeed = 10f;
				noMelee = true;
				value = 300000;
				rare = 6;
				toolTip = "Uses coins for ammo";
				toolTip2 = "Higher valued coins do more damage";
				knockBack = 2f;
				ranged = true;
				return;
			}
			if (type == 906)
			{
				name = "Lava Charm";
				width = 16;
				height = 24;
				accessory = true;
				rare = 3;
				toolTip = "Provides 7 seconds of immunity to lava";
				value = 300000;
				return;
			}
			if (type == 907)
			{
				name = "Obsidian Water Walking Boots";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Provides the ability to walk on water";
				toolTip = "Grants immunity to fire blocks";
				value = 500000;
				shoeSlot = 11;
				return;
			}
			if (type == 908)
			{
				name = "Lava Waders";
				width = 16;
				height = 24;
				accessory = true;
				rare = 7;
				toolTip = "Provides the ability to walk on water and lava";
				toolTip = "Grants immunity to fire blocks and 7 seconds of immunity to lava";
				value = 500000;
				shoeSlot = 8;
				return;
			}
			if (type == 909)
			{
				name = "Pure Water Fountain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 207;
				placeStyle = 0;
				width = 26;
				height = 36;
				value = Item.buyPrice(0, 4, 0, 0);
				return;
			}
			if (type == 910)
			{
				name = "Desert Water Fountain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 207;
				placeStyle = 1;
				width = 26;
				height = 36;
				value = Item.buyPrice(0, 4, 0, 0);
				return;
			}
			if (type == 911)
			{
				name = "Shadewood";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 208;
				width = 8;
				height = 10;
				return;
			}
			if (type == 912)
			{
				name = "Shadewood Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 10;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 913)
			{
				name = "Shadewood Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 19;
				placeStyle = 5;
				width = 8;
				height = 10;
				return;
			}
			if (type == 914)
			{
				name = "Shadewood Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 14;
				width = 26;
				height = 22;
				value = 500;
				return;
			}
			if (type == 915)
			{
				name = "Shadewood Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 11;
				width = 12;
				height = 30;
				return;
			}
			if (type == 916)
			{
				name = "Shadewood Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 9;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				return;
			}
			if (type == 917)
			{
				name = "Shadewood Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 8;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 918)
			{
				name = "Shadewood Dresser";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 88;
				placeStyle = 4;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 919)
			{
				name = "Shadewood Piano";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 87;
				placeStyle = 4;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 920)
			{
				name = "Shadewood Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 4;
				width = 28;
				height = 20;
				value = 2000;
				return;
			}
			if (type == 921)
			{
				name = "Shadewood Sword";
				useStyle = 1;
				useTurn = false;
				useAnimation = 21;
				useTime = 21;
				width = 24;
				height = 28;
				damage = 10;
				knockBack = 5f;

				scale = 1f;
				value = 100;
				melee = true;
				return;
			}
			if (type == 922)
			{
				name = "Shadewood Hammer";
				autoReuse = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 30;
				useTime = 20;
				hammer = 40;
				width = 24;
				height = 28;
				damage = 7;
				knockBack = 5.5f;
				scale = 1.2f;

				value = 50;
				melee = true;
				return;
			}
			if (type == 923)
			{
				name = "Shadewood Bow";
				useStyle = 5;
				useAnimation = 28;
				useTime = 28;
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = AmmoID.Arrow;

				damage = 8;
				shootSpeed = 6.6f;
				noMelee = true;
				value = 100;
				ranged = true;
				return;
			}
			if (type == 924)
			{
				name = "Shadewood Helmet";
				width = 18;
				height = 18;
				defense = 1;
				headSlot = 71;
				return;
			}
			if (type == 925)
			{
				name = "Shadewood Breastplate";
				width = 18;
				height = 18;
				defense = 2;
				bodySlot = 47;
				return;
			}
			if (type == 926)
			{
				name = "Shadewood Greaves";
				width = 18;
				height = 18;
				defense = 1;
				legSlot = 43;
				return;
			}
			if (type == 927)
			{
				name = "Shadewood Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 85;
				width = 12;
				height = 12;
				return;
			}
			if (type == 928)
			{
				name = "Cannon";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 209;
				width = 12;
				height = 12;
				rare = 3;
				value = Item.buyPrice(0, 25, 0, 0);
				return;
			}
			if (type == 929)
			{
				name = "Cannonball";
				useStyle = 1;
				useTurn = true;
				useAnimation = 20;
				useTime = 20;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				damage = 300;
				noMelee = true;
				value = Item.buyPrice(0, 0, 15, 0);
				return;
			}
			if (type == 930)
			{
				useStyle = 5;
				useAnimation = 18;
				useTime = 18;
				name = "Flare Gun";
				width = 24;
				height = 28;
				shoot = 163;
				useAmmo = AmmoID.Flare;

				damage = 2;
				shootSpeed = 6f;
				noMelee = true;
				value = 50000;
				scale = 0.9f;
				rare = 1;
				holdStyle = 1;
				return;
			}
			if (type == 931)
			{
				name = "Flare";
				shootSpeed = 6f;
				shoot = 163;
				damage = 1;
				width = 12;
				height = 12;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Flare;
				knockBack = 1.5f;
				value = 7;
				ranged = true;
				return;
			}
			if (type == 932)
			{
				name = "Bone Wand";
				tileWand = 154;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				createTile = 194;
				width = 8;
				height = 10;
				rare = 1;
				toolTip = "Places bone";
				return;
			}
			if (type == 933)
			{
				name = "Leaf Wand";
				tileWand = 9;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				createTile = 192;
				width = 8;
				height = 10;
				rare = 1;
				toolTip = "Places leaves";
				return;
			}
			if (type == 934)
			{
				name = "Flying Carpet";
				width = 34;
				height = 12;
				accessory = true;
				rare = 2;
				toolTip = "Allows the owner to float for a few seconds";
				value = 50000;
				return;
			}
			if (type == 935)
			{
				name = "Avenger Emblem";
				width = 24;
				height = 24;
				accessory = true;
				toolTip = "12% increased damage";
				value = 300000;
				rare = 5;
				return;
			}
			if (type == 936)
			{
				name = "Mechanical Glove";
				width = 24;
				height = 24;
				accessory = true;
				rare = 6;
				toolTip = "Increases melee knockback";
				toolTip = "12% increased melee damage and melee speed";
				value = 300000;
				handOffSlot = 4;
				handOnSlot = 9;
				return;
			}
			if (type == 937)
			{
				name = "Land Mine";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 210;
				width = 12;
				height = 12;
				placeStyle = 0;
				mech = true;
				value = 50000;
				mech = true;
				toolTip = "Explodes when stepped on";
				return;
			}
			if (type == 938)
			{
				name = "Paladin's Shield";
				width = 24;
				height = 24;
				accessory = true;
				rare = 8;
				defense = 6;
				toolTip = "Absorbs 25% of damage done to players on your team when above 25% life";
				toolTip = "Grants immunity to knockback";
				value = 300000;
				shieldSlot = 2;
				return;
			}
			if (type == 939)
			{
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Web Slinger";
				shootSpeed = 10f;
				shoot = 165;
				width = 18;
				height = 28;

				useAnimation = 20;
				useTime = 20;
				rare = 2;
				noMelee = true;
				value = 20000;
				return;
			}
			if (type == 940)
			{
				name = "Jungle Water Fountain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 207;
				placeStyle = 2;
				width = 26;
				height = 36;
				value = Item.buyPrice(0, 4, 0, 0);
				return;
			}
			if (type == 941)
			{
				name = "Icy Water Fountain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 207;
				placeStyle = 3;
				width = 26;
				height = 36;
				value = Item.buyPrice(0, 4, 0, 0);
				return;
			}
			if (type == 942)
			{
				name = "Corrupt Water Fountain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 207;
				placeStyle = 4;
				width = 26;
				height = 36;
				value = Item.buyPrice(0, 4, 0, 0);
				return;
			}
			if (type == 943)
			{
				name = "Crimson Water Fountain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 207;
				placeStyle = 5;
				width = 26;
				height = 36;
				value = Item.buyPrice(0, 4, 0, 0);
				return;
			}
			if (type == 944)
			{
				name = "Hallowed Water Fountain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 207;
				placeStyle = 6;
				width = 26;
				height = 36;
				value = Item.buyPrice(0, 4, 0, 0);
				return;
			}
			if (type == 945)
			{
				name = "Blood Water Fountain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 207;
				placeStyle = 7;
				width = 26;
				height = 36;
				value = Item.buyPrice(0, 4, 0, 0);
				return;
			}
			if (type == 946)
			{
				name = "Umbrella";
				width = 44;
				height = 44;
				rare = 1;
				value = 10000;
				holdStyle = 2;
				toolTip = "You will fall slower while holding this";
				return;
			}
			if (type == 947)
			{
				name = "Chlorophyte Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 211;
				width = 12;
				height = 12;
				rare = 7;
				value = 3000;
				toolTip = "Reacts to the light";
				return;
			}
			if (type == 948)
			{
				name = "Steampunk Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 8;
				wingSlot = 12;
				value = Item.buyPrice(1, 0, 0, 0);
				return;
			}
			if (type == 949)
			{
				useStyle = 1;
				name = "Snowball";
				shootSpeed = 7f;
				shoot = 166;
				ammo = AmmoID.Snowball;
				damage = 8;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;

				useAnimation = 19;
				useTime = 19;
				noUseGraphic = true;
				noMelee = true;
				thrown = true;
				knockBack = 5.75f;
				return;
			}
			if (type == 950)
			{
				name = "Ice Skates";
				width = 16;
				height = 24;
				accessory = true;
				rare = 1;
				toolTip = "Provides extra mobility on ice";
				value = 50000;
				shoeSlot = 7;
				return;
			}
			if (type == 951)
			{
				name = "Snowball Launcher";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 212;
				width = 20;
				height = 20;
				value = 50000;
				rare = 2;
				toolTip = "Rapidly launches snowballs";
				return;
			}
			if (type == 952)
			{
				name = "Web Covered Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 15;
				width = 26;
				height = 22;
				value = 500;
				return;
			}
			if (type == 953)
			{
				name = "Climbing Claws";
				width = 16;
				height = 24;
				accessory = true;
				rare = 1;
				toolTip = "Allows the ability to slide down walls";
				toolTip = "Improved ability if combined with Shoe Spikes";
				value = 50000;
				handOnSlot = 11;
				handOffSlot = 6;
				return;
			}
			if (type == 954)
			{
				name = "Ancient Iron Helmet";
				width = 18;
				height = 18;
				defense = 2;
				headSlot = 72;
				value = 5000;
				return;
			}
			if (type == 955)
			{
				name = "Ancient Gold Helmet";
				width = 18;
				height = 18;
				defense = 4;
				headSlot = 73;
				value = 25000;
				return;
			}
			if (type == 956)
			{
				name = "Ancient Shadow Helmet";
				width = 18;
				height = 18;
				defense = 6;
				headSlot = 74;
				rare = 1;
				value = 37500;
				toolTip = "7% increased melee speed";
				return;
			}
			if (type == 957)
			{
				name = "Ancient Shadow Scalemail";
				width = 18;
				height = 18;
				defense = 7;
				bodySlot = 48;
				rare = 1;
				value = 30000;
				toolTip = "7% increased melee speed";
				return;
			}
			if (type == 958)
			{
				name = "Ancient Shadow Greaves";
				width = 18;
				height = 18;
				defense = 6;
				legSlot = 44;
				rare = 1;
				value = 22500;
				toolTip = "7% increased melee speed";
				return;
			}
			if (type == 959)
			{
				name = "Ancient Necro Helmet";
				width = 18;
				height = 18;
				defense = 5;
				headSlot = 75;
				rare = 2;
				value = 45000;
				toolTip = "4% increased ranged damage.";
				return;
			}
			if (type == 960)
			{
				name = "Ancient Cobalt Helmet";
				width = 18;
				height = 18;
				defense = 5;
				headSlot = 76;
				rare = 3;
				value = 45000;
				toolTip = "Increases maximum mana by 40";
				toolTip2 = "3% increased magic critical strike chance";
				return;
			}
			if (type == 961)
			{
				name = "Ancient Cobalt Breastplate";
				width = 18;
				height = 18;
				defense = 6;
				bodySlot = 49;
				rare = 3;
				value = 30000;
				toolTip = "Increases maximum mana by 20";
				toolTip2 = "3% increased magic critical strike chance";
				return;
			}
			if (type == 962)
			{
				name = "Ancient Cobalt Leggings";
				width = 18;
				height = 18;
				defense = 6;
				legSlot = 45;
				rare = 3;
				value = 30000;
				toolTip = "Increases maximum mana by 20";
				toolTip2 = "3% increased magic critical strike chance";
				return;
			}
			if (type == 963)
			{
				name = "Black Belt";
				width = 16;
				height = 24;
				accessory = true;
				rare = 7;
				toolTip = "Gives a chance to dodge attacks";
				value = 50000;
				waistSlot = 10;
				return;
			}
			if (type == 964)
			{
				knockBack = 5.75f;
				useStyle = 5;
				useAnimation = 40;
				useTime = 40;
				name = "Boomstick";
				width = 50;
				height = 14;
				shoot = 10;
				useAmmo = AmmoID.Bullet;

				damage = 14;
				shootSpeed = 5.35f;
				noMelee = true;
				value = Item.sellPrice(0, 2, 0, 0);
				rare = 2;
				ranged = true;
				toolTip = "Fires a spread of bullets";
				return;
			}
			if (type == 965)
			{
				name = "Rope";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 8;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 213;
				width = 12;
				height = 12;
				value = 10;
				tileBoost += 3;
				toolTip = "Can be climbed on";
				return;
			}
			if (type == 966)
			{
				name = "Campfire";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 215;
				width = 12;
				height = 12;
				toolTip = "Life regen is increased when near a campfire";
				return;
			}
			if (type == 967)
			{
				name = "Marshmellow";
				width = 12;
				height = 12;
				maxStack = 99;
				value = 100;
				return;
			}
			if (type == 968)
			{
				name = "Marshmellow on a Stick";
				holdStyle = 1;
				width = 12;
				height = 12;
				value = 200;
				return;
			}
			if (type == 969)
			{
				name = "Cooked Marshmellow";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 12;
				height = 12;
				buffType = 26;
				buffTime = 36000;
				rare = 1;
				toolTip = "Minor improvements to all stats";
				value = 1000;
				value = 1000;
				return;
			}
			if (type == 970)
			{
				name = "Red Rocket";
				createTile = 216;
				placeStyle = 0;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				width = 12;
				height = 30;
				value = 1500;
				mech = true;
				return;
			}
			if (type == 971)
			{
				name = "Green Rocket";
				createTile = 216;
				placeStyle = 1;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				width = 12;
				height = 30;
				value = 1500;
				mech = true;
				return;
			}
			if (type == 972)
			{
				name = "Blue Rocket";
				createTile = 216;
				placeStyle = 2;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				width = 12;
				height = 30;
				value = 1500;
				mech = true;
				return;
			}
			if (type == 973)
			{
				name = "Yellow Rocket";
				createTile = 216;
				placeStyle = 3;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				width = 12;
				height = 30;
				value = 1500;
				mech = true;
				return;
			}
			if (type == 974)
			{
				flame = true;
				name = "Ice Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 9;
				width = 10;
				height = 12;
				value = 60;
				noWet = true;
				return;
			}
			if (type == 975)
			{
				name = "Shoe Spikes";
				width = 16;
				height = 24;
				accessory = true;
				rare = 1;
				toolTip = "Allows the ability to slide down walls";
				toolTip = "Improved ability if combined with Climbing Claws";
				value = 50000;
				shoeSlot = 4;
				return;
			}
			if (type == 976)
			{
				name = "Tiger Climbing Gear";
				width = 16;
				height = 24;
				accessory = true;
				rare = 2;
				toolTip = "Allows the ability to climb walls";
				value = 50000;
				shoeSlot = 4;
				handOnSlot = 11;
				handOffSlot = 6;
				return;
			}
			if (type == 977)
			{
				name = "Tabi";
				width = 16;
				height = 24;
				accessory = true;
				rare = 7;
				toolTip = "Allows the ability to dash";
				toolTip = "Double tap a direction";
				value = 50000;
				shoeSlot = 3;
				return;
			}
			if (type == 978)
			{
				name = "Pink Eskimo Hood";
				width = 18;
				height = 18;
				headSlot = 77;
				value = 50000;
				defense = 1;
				return;
			}
			if (type == 979)
			{
				name = "Pink Eskimo Coat";
				width = 18;
				height = 18;
				bodySlot = 50;
				value = 40000;
				defense = 2;
				return;
			}
			if (type == 980)
			{
				name = "Pink Eskimo Pants";
				width = 18;
				height = 18;
				legSlot = 46;
				value = 30000;
				defense = 1;
				return;
			}
			if (type == 981)
			{
				name = "Pink Thread";
				maxStack = 99;
				width = 12;
				height = 20;
				value = 10000;
				return;
			}
			if (type == 982)
			{
				name = "Mana Regeneration Band";
				width = 22;
				height = 22;
				accessory = true;
				rare = 1;
				toolTip = "Increases maximum mana by 20";
				toolTip2 = "Increases mana regeneration rate";
				value = 50000;
				handOnSlot = 1;
				return;
			}
			if (type == 983)
			{
				name = "Sandstorm in a Balloon";
				width = 14;
				height = 28;
				rare = 4;
				value = 150000;
				accessory = true;
				toolTip = "Allows the holder to double jump";
				toolTip2 = "Increases jump height";
				balloonSlot = 6;
				return;
			}
			if (type == 984)
			{
				name = "Master Ninja Gear";
				width = 16;
				height = 24;
				accessory = true;
				rare = 8;
				toolTip = "Allows the ability to climb walls and dash";
				toolTip2 = "Gives a chance to dodge attacks";
				value = 500000;
				handOnSlot = 11;
				handOffSlot = 6;
				shoeSlot = 14;
				waistSlot = 10;
				return;
			}
			if (type == 985)
			{
				useStyle = 1;
				name = "Rope Coil";
				shootSpeed = 10f;
				shoot = 171;
				damage = 0;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;

				useAnimation = 20;
				useTime = 20;
				noUseGraphic = true;
				noMelee = true;
				value = 100;
				toolTip = "Throw to create a climbable line of rope";
				return;
			}
			if (type == 986)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 35;
				useTime = 35;
				name = "Blowgun";
				width = 38;
				height = 6;
				shoot = 10;
				useAmmo = AmmoID.Dart;

				damage = 27;
				shootSpeed = 13f;
				noMelee = true;
				value = Item.buyPrice(0, 5, 0, 0);
				knockBack = 4f;
				useAmmo = AmmoID.Dart;
				toolTip = "Allows the collection of seeds for ammo";
				ranged = true;
				rare = 3;
				return;
			}
			if (type == 987)
			{
				name = "Blizzard in a Bottle";
				width = 16;
				height = 24;
				accessory = true;
				rare = 1;
				toolTip = "Allows the holder to double jump";
				value = 50000;
				return;
			}
			if (type == 988)
			{
				name = "Frostburn Arrow";
				shootSpeed = 3.75f;
				shoot = 172;
				damage = 9;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Arrow;
				knockBack = 2.2f;
				value = 15;
				ranged = true;
				return;
			}
			if (type == 989)
			{
				autoReuse = true;
				rare = 2;

				name = "Enchanted Sword";
				useStyle = 1;
				damage = 24;
				useAnimation = 18;
				useTime = 45;
				scale = 1.1f;
				width = 30;
				height = 30;
				shoot = 173;
				shootSpeed = 9.5f;
				knockBack = 5.25f;
				toolTip = "Shoots an echanted beam";
				melee = true;
				value = 20000;
				return;
			}
			if (type == 990)
			{
				useTurn = true;
				autoReuse = true;
				name = "Pickaxe Axe";
				useStyle = 1;
				useAnimation = 25;
				useTime = 7;
				knockBack = 4.75f;
				width = 20;
				height = 12;
				damage = 35;
				pick = 200;
				axe = 22;

				rare = 4;
				value = 220000;
				melee = true;
				scale = 1.1f;
				toolTip = "'Not to be confused with a hamdrill'";
				return;
			}
			if (type == 991)
			{
				useTurn = true;
				autoReuse = true;
				name = "Cobalt Waraxe";
				useStyle = 1;
				useAnimation = 35;
				useTime = 8;
				knockBack = 5f;
				width = 20;
				height = 12;
				damage = 33;
				axe = 14;

				rare = 4;
				value = 54000;
				melee = true;
				scale = 1.1f;
				return;
			}
			if (type == 992)
			{
				useTurn = true;
				autoReuse = true;
				name = "Mythril Waraxe";
				useStyle = 1;
				useAnimation = 35;
				useTime = 8;
				knockBack = 6f;
				width = 20;
				height = 12;
				damage = 39;
				axe = 17;

				rare = 4;
				value = 81000;
				melee = true;
				scale = 1.1f;
				return;
			}
			if (type == 993)
			{
				useTurn = true;
				autoReuse = true;
				name = "Adamantite Waraxe";
				useStyle = 1;
				useAnimation = 35;
				useTime = 6;
				knockBack = 7f;
				width = 20;
				height = 12;
				damage = 43;
				axe = 20;

				rare = 4;
				value = 108000;
				melee = true;
				scale = 1.1f;
				return;
			}
			if (type == 994)
			{
				damage = 0;
				useStyle = 1;
				name = "Eater's Bone";
				shoot = 175;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Baby Eater of Souls";
				value = 0;
				buffType = 45;
				return;
			}
			if (type == 995)
			{
				name = "Blend-O-Matic";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 217;
				width = 26;
				height = 20;
				value = 100000;
				toolTip = "Used to craft objects";
				return;
			}
			if (type == 996)
			{
				name = "Meat Grinder";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 218;
				width = 26;
				height = 20;
				value = 100000;
				toolTip = "Used to craft objects";
				return;
			}
			if (type == 997)
			{
				name = "Silt Extractinator";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 219;
				width = 26;
				height = 20;
				value = 100000;
				toolTip = "Turns silt into something more useful";
				toolTip2 = "'To use: Place silt in the extractinator'";
				return;
			}
			if (type == 998)
			{
				name = "Solidifier";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 220;
				width = 26;
				height = 20;
				value = 100000;
				toolTip = "Used to craft objects";
				return;
			}
			if (type == 999)
			{
				name = "Amber";
				createTile = 178;
				placeStyle = 6;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				alpha = 50;
				width = 10;
				height = 14;
				value = 15000;
				return;
			}
			if (type == 1000)
			{
				useStyle = 5;
				name = "Confetti Gun";
				shootSpeed = 10f;
				shoot = 178;
				damage = 0;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;

				useAnimation = 15;
				useTime = 15;
				noMelee = true;
				value = 100;
				ranged = true;
			}
		}

		public void SetDefaults2(int type)
		{
			if (type == 1001)
			{
				name = "Chlorophyte Mask";
				width = 18;
				height = 18;
				defense = 25;
				headSlot = 78;
				rare = 7;
				value = 300000;
				toolTip = "16% increased melee damage";
				toolTip2 = "6% increased melee critical strike chance";
				return;
			}
			if (type == 1002)
			{
				name = "Chlorophyte Helmet";
				width = 18;
				height = 18;
				defense = 13;
				headSlot = 79;
				rare = 7;
				value = 300000;
				toolTip = "16% increased ranged damage";
				toolTip2 = "20% chance to not consume ammo";
				return;
			}
			if (type == 1003)
			{
				name = "Chlorophyte Headgear";
				width = 18;
				height = 18;
				defense = 7;
				headSlot = 80;
				rare = 7;
				value = 300000;
				toolTip = "Increases maximum mana by 80 and reduces mana usage by 17%";
				toolTip2 = "16% increased magic damage";
				return;
			}
			if (type == 1004)
			{
				name = "Chlorophyte Plate Mail";
				width = 18;
				height = 18;
				defense = 18;
				bodySlot = 51;
				rare = 7;
				value = 240000;
				toolTip = "5% increased damage";
				toolTip = "7% increased critical strike chance";
				return;
			}
			if (type == 1005)
			{
				name = "Chlorophyte Greaves";
				width = 18;
				height = 18;
				defense = 13;
				legSlot = 47;
				rare = 7;
				value = 180000;
				toolTip = "8% increased critical strike chance";
				toolTip = "5% increased movement speed";
				return;
			}
			if (type == 1006)
			{
				name = "Chlorophyte Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = Item.sellPrice(0, 0, 90, 0);
				rare = 7;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 17;
				return;
			}
			if (type == 1007)
			{
				name = "Red Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1008)
			{
				name = "Orange Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1009)
			{
				name = "Yellow Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1010)
			{
				name = "Lime Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1011)
			{
				name = "Green Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1012)
			{
				name = "Teal Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1013)
			{
				name = "Cyan Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1014)
			{
				name = "Sky Blue Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1015)
			{
				name = "Blue Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1016)
			{
				name = "Purple Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1017)
			{
				name = "Violet Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1018)
			{
				name = "Pink Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1019)
			{
				name = "Red and Black Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1020)
			{
				name = "Orange and Black Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1021)
			{
				name = "Yellow and Black Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1022)
			{
				name = "Lime and Black Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1023)
			{
				name = "Green and Black Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1024)
			{
				name = "Teal and Black Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1025)
			{
				name = "Cyan and Black Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1026)
			{
				name = "Sky Blue and Black Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1027)
			{
				name = "Blue and Black Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1028)
			{
				name = "Purple and Black Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1029)
			{
				name = "Violet and Black Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1030)
			{
				name = "Pink and Black Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1031)
			{
				name = "Flame Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1032)
			{
				name = "Flame and Black Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1033)
			{
				name = "Green Flame Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1034)
			{
				name = "Green Flame and Black Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1035)
			{
				name = "Blue Flame Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1036)
			{
				name = "Blue Flame and Black Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1037)
			{
				name = "Silver Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1038)
			{
				name = "Bright Red Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1039)
			{
				name = "Bright Orange Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1040)
			{
				name = "Bright Yellow Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1041)
			{
				name = "Bright Lime Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1042)
			{
				name = "Bright Green Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1043)
			{
				name = "Bright Teal Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1044)
			{
				name = "Bright Cyan Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1045)
			{
				name = "Bright Sky Blue Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1046)
			{
				name = "Bright Blue Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1047)
			{
				name = "Bright Purple Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1048)
			{
				name = "Bright Violet Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1049)
			{
				name = "Bright Pink Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1050)
			{
				name = "Black Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1051)
			{
				name = "Red and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1052)
			{
				name = "Orange and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1053)
			{
				name = "Yellow and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1054)
			{
				name = "Lime and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1055)
			{
				name = "Green and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1056)
			{
				name = "Teal and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1057)
			{
				name = "Cyan and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1058)
			{
				name = "Sky Blue and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1059)
			{
				name = "Blue and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1060)
			{
				name = "Purple and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1061)
			{
				name = "Violet and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1062)
			{
				name = "Pink and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1063)
			{
				name = "Intense Flame Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1064)
			{
				name = "Intense Green Flame Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1065)
			{
				name = "Intense Blue Flame Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1066)
			{
				name = "Rainbow Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1067)
			{
				name = "Intense Rainbow Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1068)
			{
				name = "Yellow Gradient Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1069)
			{
				name = "Cyan Gradient Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1070)
			{
				name = "Violet Gradient Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type == 1071)
			{
				name = "Paintbrush";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				width = 24;
				height = 24;
				toolTip = "Used with paint to color blocks";
				value = 10000;
				return;
			}
			if (type == 1072)
			{
				name = "Paint Roller";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				width = 24;
				height = 24;
				toolTip = "Used with paint to color walls";
				value = 10000;
				return;
			}
			if (type == 1073)
			{
				name = "Red Paint";
				paint = 1;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1074)
			{
				name = "Orange Paint";
				paint = 2;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1075)
			{
				name = "Yellow Paint";
				paint = 3;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1076)
			{
				name = "Lime Paint";
				paint = 4;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1077)
			{
				name = "Green Paint";
				paint = 5;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1078)
			{
				name = "Teal Paint";
				paint = 6;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1079)
			{
				name = "Cyan Paint";
				paint = 7;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1080)
			{
				name = "Sky Blue Paint";
				paint = 8;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1081)
			{
				name = "Blue Paint";
				paint = 9;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1082)
			{
				name = "Purple Paint";
				paint = 10;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1083)
			{
				name = "Violet Paint";
				paint = 11;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1084)
			{
				name = "Pink Paint";
				paint = 12;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1085)
			{
				name = "Deep Red Paint";
				paint = 13;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1086)
			{
				name = "Deep Orange Paint";
				paint = 14;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1087)
			{
				name = "Deep Yellow Paint";
				paint = 15;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1088)
			{
				name = "Deep Lime Paint";
				paint = 16;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1089)
			{
				name = "Deep Green Paint";
				paint = 17;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1090)
			{
				name = "Deep Teal Paint";
				paint = 18;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1091)
			{
				name = "Deep Cyan Paint";
				paint = 19;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1092)
			{
				name = "Deep Sky Blue Paint";
				paint = 20;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1093)
			{
				name = "Deep Blue Paint";
				paint = 21;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1094)
			{
				name = "Deep Purple Paint";
				paint = 22;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1095)
			{
				name = "Deep Violet Paint";
				paint = 23;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1096)
			{
				name = "Deep Pink Paint";
				paint = 24;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1097)
			{
				name = "Black Paint";
				paint = 25;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1098)
			{
				name = "White Paint";
				paint = 26;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1099)
			{
				name = "Gray Paint";
				paint = 27;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1100)
			{
				name = "Paint Scraper";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				width = 24;
				height = 24;
				toolTip = "Used to remove paint";
				value = 10000;
				return;
			}
			if (type == 1101)
			{
				name = "Lihzahrd Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 226;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1102)
			{
				name = "Lihzahrd Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 112;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1103)
			{
				name = "Slush Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 224;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1104)
			{
				name = "Palladium Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 221;
				width = 12;
				height = 12;
				value = 4500;
				rare = 3;
				return;
			}
			if (type == 1105)
			{
				name = "Orichalcum Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 222;
				width = 12;
				height = 12;
				value = 6500;
				rare = 3;
				return;
			}
			if (type == 1106)
			{
				name = "Titanium Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 223;
				width = 12;
				height = 12;
				value = 8500;
				rare = 3;
				return;
			}
			if (type == 1107)
			{
				name = "Teal Mushroom";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Teal Dye";
				placeStyle = 0;
				createTile = 227;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				return;
			}
			if (type == 1108)
			{
				name = "Green Mushroom";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Green Dye";
				placeStyle = 1;
				createTile = 227;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				return;
			}
			if (type == 1109)
			{
				name = "Sky Blue Flower";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Sky Blue Dye";
				placeStyle = 2;
				createTile = 227;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				return;
			}
			if (type == 1110)
			{
				name = "Yellow Marigold";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Yellow Dye";
				placeStyle = 3;
				createTile = 227;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				return;
			}
			if (type == 1111)
			{
				name = "Blue Berries";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Blue Dye";
				placeStyle = 4;
				createTile = 227;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				return;
			}
			if (type == 1112)
			{
				name = "Lime Kelp";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Lime Dye";
				placeStyle = 5;
				createTile = 227;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				return;
			}
			if (type == 1113)
			{
				name = "Pink Prickly Pear";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Pink Dye";
				return;
			}
			if (type == 1114)
			{
				name = "Orange Bloodroot";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Orange Dye";
				placeStyle = 7;
				createTile = 227;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				return;
			}
			if (type == 1115)
			{
				name = "Red Husk";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Red Dye";
				return;
			}
			if (type == 1116)
			{
				name = "Cyan Husk";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Cyan Dye";
				return;
			}
			if (type == 1117)
			{
				name = "Violet Husk";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Violet Dye";
				return;
			}
			if (type == 1118)
			{
				name = "Purple Mucus";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Purple Dye";
				return;
			}
			if (type == 1119)
			{
				name = "Black Ink";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Black Dye";
				return;
			}
			if (type == 1120)
			{
				name = "Dye Vat";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 228;
				width = 26;
				height = 20;
				value = Item.buyPrice(0, 5, 0, 0);
				toolTip = "Used to craft dyes";
				return;
			}
			if (type == 1121)
			{
				name = "Beegun";
				useStyle = 5;
				autoReuse = true;
				useAnimation = 12;
				useTime = 12;
				mana = 5;
				width = 50;
				height = 18;
				shoot = 181;

				damage = 9;
				shootSpeed = 8f;
				noMelee = true;
				value = Item.sellPrice(0, 3, 0, 0);
				rare = 2;
				magic = true;
				scale = 0.8f;
				return;
			}
			if (type == 1122)
			{
				autoReuse = true;
				useStyle = 1;
				name = "Possessed Hatchet";
				shootSpeed = 12f;
				shoot = 182;
				damage = 80;
				width = 18;
				height = 20;

				useAnimation = 14;
				useTime = 14;
				noUseGraphic = true;
				noMelee = true;
				value = 500000;
				knockBack = 5f;
				melee = true;
				rare = 7;
				toolTip = "A magical returning hatchet";
				return;
			}
			if (type == 1123)
			{
				name = "Bee Keeper";
				useStyle = 1;
				useAnimation = 20;
				knockBack = 5.3f;
				autoReuse = true;
				width = 40;
				height = 40;
				damage = 26;
				scale = 1.1f;

				rare = 3;
				value = 27000;
				melee = true;
				toolTip = "Summons killer bees after striking your foe";
				toolTip2 = "Small chance to cause confusion";
				return;
			}
			if (type == 1124)
			{
				name = "Hive";
				width = 12;
				height = 12;
				maxStack = 999;
				return;
			}
			if (type == 1125)
			{
				name = "Honey Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 229;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1126)
			{
				name = "Hive Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 108;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1127)
			{
				name = "Crispy Honey Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 230;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1128)
			{
				name = "Honey Bucket";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				width = 20;
				height = 20;
				maxStack = 99;
				autoReuse = true;
				return;
			}
			if (type == 1129)
			{
				name = "Hive Wand";
				tileWand = 1124;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				createTile = 225;
				width = 8;
				height = 10;
				rare = 1;
				toolTip = "Places hives";
				return;
			}
			if (type == 1130)
			{
				useStyle = 1;
				name = "Beenade";
				shootSpeed = 6f;
				shoot = 183;
				knockBack = 1f;
				damage = 14;
				width = 10;
				height = 10;
				maxStack = 999;
				consumable = true;

				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 200;
				thrown = true;
				return;
			}
			if (type == 1131)
			{
				name = "Gravity Globe";
				width = 22;
				height = 22;
				accessory = true;
				rare = 8;
				toolTip = "Allows the holder to reverse gravity";
				toolTip2 = "Press UP to change gravity";
				value = 50000;
				expert = true;
				return;
			}
			if (type == 1132)
			{
				name = "Honey Comb";
				width = 22;
				height = 22;
				accessory = true;
				rare = 2;
				toolTip = "Releases bees when damaged";
				value = 100000;
				return;
			}
			if (type == 1133)
			{
				useStyle = 4;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				name = "Abeemination";
				width = 28;
				height = 28;
				maxStack = 20;
				toolTip = "Summons the Queen Bee";
				return;
			}
			if (type == 1134)
			{
				name = "Bottled Honey";

				healLife = 80;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				potion = true;
				value = 40;
				return;
			}
			if (type == 1135)
			{
				name = "Rain Hat";
				width = 18;
				height = 18;
				headSlot = 81;
				value = 1000;
				defense = 1;
				return;
			}
			if (type == 1136)
			{
				name = "Rain Coat";
				width = 18;
				height = 18;
				bodySlot = 52;
				value = 1000;
				defense = 2;
				return;
			}
			if (type == 1137)
			{
				name = "Lihzahrd Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 12;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 1138)
			{
				name = "Dungeon Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 13;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 1139)
			{
				name = "Lead Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 14;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 1140)
			{
				name = "Iron Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 15;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 1141)
			{
				name = "Temple Key";
				width = 14;
				height = 20;
				maxStack = 99;
				toolTip = "Opens the jungle temple door";
				rare = 7;
				return;
			}
			if (type == 1142)
			{
				name = "Lihzahrd Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 16;
				width = 26;
				height = 22;
				value = 500;
				return;
			}
			if (type == 1143)
			{
				name = "Lihzahrd Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 12;
				width = 12;
				height = 30;
				return;
			}
			if (type == 1144)
			{
				name = "Lihzahrd Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 9;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 1145)
			{
				name = "Lihzahrd Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 10;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				return;
			}
			if (type == 1146)
			{
				name = "Super Dart Trap";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 137;
				placeStyle = 1;
				width = 12;
				height = 12;
				value = 10000;
				mech = true;
				return;
			}
			if (type == 1147)
			{
				name = "Flame Trap";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 137;
				placeStyle = 2;
				width = 12;
				height = 12;
				value = 10000;
				mech = true;
				return;
			}
			if (type == 1148)
			{
				name = "Spiky Ball Trap";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 137;
				placeStyle = 3;
				width = 12;
				height = 12;
				value = 10000;
				mech = true;
				return;
			}
			if (type == 1149)
			{
				name = "Spear Trap";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 137;
				placeStyle = 4;
				width = 12;
				height = 12;
				value = 10000;
				mech = true;
				return;
			}
			if (type == 1150)
			{
				name = "Wooden Spike";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 232;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1151)
			{
				name = "Lihzahrd Pressure Plate";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 135;
				width = 12;
				height = 12;
				placeStyle = 6;
				mech = true;
				value = 5000;
				toolTip = "Activates when a player steps on it on";
				return;
			}
			if (type == 1152)
			{
				name = "Lihzahrd Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 43;
				return;
			}
			if (type == 1153)
			{
				name = "Lihzahrd Watcher Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 44;
				return;
			}
			if (type == 1154)
			{
				name = "Lihzahrd Guardian Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 45;
				return;
			}
			if (type == 1155)
			{
				name = "Wasp Gun";
				useStyle = 5;
				autoReuse = true;
				useAnimation = 11;
				useTime = 11;
				mana = 6;
				width = 50;
				height = 18;
				shoot = 189;

				damage = 21;
				shootSpeed = 9f;
				noMelee = true;
				value = 500000;
				rare = 8;
				magic = true;
				return;
			}
			if (type == 1156)
			{
				channel = true;
				name = "Piranha Gun";
				useStyle = 5;
				useAnimation = 30;
				useTime = 30;
				knockBack = 1f;
				width = 30;
				height = 10;
				damage = 38;
				scale = 1.1f;
				shoot = 190;
				shootSpeed = 14f;

				rare = 8;
				value = Item.sellPrice(0, 5, 50, 0);
				ranged = true;
				noMelee = true;
				return;
			}
			if (type == 1157)
			{
				mana = 10;
				damage = 34;
				useStyle = 1;
				name = "Pygmy Staff";
				shootSpeed = 10f;
				shoot = 191;
				width = 26;
				height = 28;

				useAnimation = 28;
				useTime = 28;
				rare = 7;
				noMelee = true;
				knockBack = 3f;
				toolTip = "Summons a pygmy to fight for you";
				buffType = 49;
				value = 100000;
				summon = true;
				return;
			}
			if (type == 1158)
			{
				name = "Pygmy Necklace";
				rare = 7;
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Increases your max number of minions";
				value = Item.buyPrice(0, 40, 0, 0);
				neckSlot = 4;
				return;
			}
			if (type == 1159)
			{
				name = "Tiki Mask";
				width = 18;
				height = 18;
				defense = 6;
				headSlot = 82;
				rare = 7;
				value = Item.buyPrice(0, 50, 0, 0);
				toolTip = "Increases your max number of minions";
				toolTip2 = "Increases minion damage by 10%";
				return;
			}
			if (type == 1160)
			{
				name = "Tiki Shirt";
				width = 18;
				height = 18;
				defense = 17;
				bodySlot = 53;
				rare = 7;
				value = Item.buyPrice(0, 50, 0, 0);
				toolTip = "Increases your max number of minions";
				toolTip2 = "Increases minion damage by 10%";
				return;
			}
			if (type == 1161)
			{
				name = "Tiki Pants";
				width = 18;
				height = 18;
				defense = 12;
				legSlot = 48;
				rare = 7;
				value = Item.buyPrice(0, 50, 0, 0);
				toolTip = "Increases your max number of minions";
				toolTip2 = "Increases minion damage by 10%";
				return;
			}
			if (type == 1162)
			{
				name = "Leaf Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = Item.buyPrice(1, 0, 0, 0);
				wingSlot = 13;
				rare = 5;
				return;
			}
			if (type == 1163)
			{
				name = "Blizzard in a Balloon";
				width = 14;
				height = 28;
				rare = 4;
				value = 150000;
				accessory = true;
				toolTip = "Allows the holder to double jump";
				toolTip2 = "Increases jump height";
				balloonSlot = 1;
				return;
			}
			if (type == 1164)
			{
				name = "Bundle of Balloons";
				width = 14;
				height = 28;
				rare = 8;
				value = 150000;
				accessory = true;
				toolTip = "Allows the holder to quadruple jump";
				toolTip2 = "Increases jump height";
				balloonSlot = 3;
				return;
			}
			if (type == 1165)
			{
				name = "Bat Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 14;
				return;
			}
			if (type == 1166)
			{
				name = "Bone Sword";
				useStyle = 1;
				useAnimation = 22;
				knockBack = 4.5f;
				width = 24;
				height = 28;
				damage = 16;
				scale = 1.05f;

				rare = 3;
				value = 9000;
				melee = true;
				return;
			}
			if (type == 1167)
			{
				name = "Hercules Beetle";
				rare = 7;
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Increases the damage and knockback of your minions";
				value = Item.buyPrice(0, 40, 0, 0);
				return;
			}
			if (type == 1168)
			{
				useStyle = 1;
				name = "Smoke Bomb";
				shootSpeed = 6f;
				shoot = 196;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;

				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 20;
				return;
			}
			if (type == 1169)
			{
				damage = 0;
				useStyle = 1;
				name = "Bone Key";
				shoot = 197;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Baby Skeletron Head";
				value = Item.sellPrice(0, 5, 0, 0);
				buffType = 50;
				return;
			}
			if (type == 1170)
			{
				damage = 0;
				useStyle = 1;
				name = "Nectar";
				shoot = 198;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Baby Hornet";
				value = Item.sellPrice(0, 3, 0, 0);
				buffType = 51;
				return;
			}
			if (type == 1171)
			{
				damage = 0;
				useStyle = 1;
				name = "Tiki Totem";
				shoot = 199;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Tiki Spirit";
				buffType = 52;
				value = Item.buyPrice(2, 0, 0, 0);
				return;
			}
			if (type == 1172)
			{
				damage = 0;
				useStyle = 1;
				name = "Lizard Egg";
				shoot = 200;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Pet Lizard";
				value = Item.sellPrice(0, 2, 0, 0);
				buffType = 53;
				return;
			}
			if (type == 1173)
			{
				name = "Grave Marker";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 85;
				placeStyle = 1;
				width = 20;
				height = 20;
				return;
			}
			if (type == 1174)
			{
				name = "Cross Grave Marker";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 85;
				placeStyle = 2;
				width = 20;
				height = 20;
				return;
			}
			if (type == 1175)
			{
				name = "Headstone";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 85;
				placeStyle = 3;
				width = 20;
				height = 20;
				return;
			}
			if (type == 1176)
			{
				name = "Gravestone";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 85;
				placeStyle = 4;
				width = 20;
				height = 20;
				return;
			}
			if (type == 1177)
			{
				name = "Obelisk";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 85;
				placeStyle = 5;
				width = 20;
				height = 20;
				return;
			}
			if (type == 1178)
			{
				useStyle = 5;
				mana = 4;
				autoReuse = true;
				useAnimation = 7;
				useTime = 7;
				name = "Leaf Blower";
				width = 24;
				height = 18;
				shoot = 206;

				damage = 48;
				shootSpeed = 11f;
				noMelee = true;
				value = 300000;
				knockBack = 4f;
				rare = 7;
				toolTip = "Rapidly shoots razor sharp leaves";
				magic = true;
				return;
			}
			if (type == 1179)
			{
				name = "Chlorophyte Bullet";
				shootSpeed = 5f;
				shoot = 207;
				damage = 10;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Bullet;
				knockBack = 4.5f;
				value = 50;
				ranged = true;
				rare = 7;
				return;
			}
			if (type == 1180)
			{
				damage = 0;
				useStyle = 1;
				name = "Parrot Cracker";
				shoot = 208;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Pet Parrot";
				buffType = 54;
				value = Item.sellPrice(0, 75, 0, 0);
				return;
			}
			if (type == 1181)
			{
				damage = 0;
				useStyle = 1;
				name = "Strange Glowing Mushroom";
				shoot = 209;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Baby Truffle";
				value = Item.buyPrice(0, 45, 0, 0);
				buffType = 55;
				return;
			}
			if (type == 1182)
			{
				damage = 0;
				useStyle = 1;
				name = "Seedling";
				shoot = 210;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Pet Sapling";
				value = Item.sellPrice(0, 2, 0, 0);
				buffType = 56;
				return;
			}
			if (type == 1183)
			{
				damage = 0;
				useStyle = 1;
				name = "Wisp in a Bottle";
				shoot = 211;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 8;
				noMelee = true;
				toolTip = "Summons a Wisp to provide light";
				value = Item.sellPrice(0, 5, 50, 0);
				buffType = 57;
				return;
			}
			if (type == 1184)
			{
				name = "Palladium Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 13500;
				rare = 3;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 12;
				return;
			}
			if (type == 1185)
			{
				useTurn = true;
				autoReuse = true;
				name = "Palladium Sword";
				useStyle = 1;
				useAnimation = 25;
				useTime = 25;
				knockBack = 4.75f;
				width = 40;
				height = 40;
				damage = 36;
				scale = 1.125f;

				rare = 4;
				value = 92000;
				melee = true;
				return;
			}
			if (type == 1186)
			{
				name = "Palladium Pike";
				useStyle = 5;
				useAnimation = 27;
				useTime = 27;
				shootSpeed = 4.4f;
				knockBack = 4.5f;
				width = 40;
				height = 40;
				damage = 32;
				scale = 1.1f;

				shoot = 212;
				rare = 4;
				value = 60000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			}
			if (type == 1187)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 24;
				useTime = 24;
				name = "Palladium Repeater";
				width = 50;
				height = 18;
				shoot = 1;
				useAmmo = AmmoID.Arrow;

				damage = 34;
				shootSpeed = 9.25f;
				noMelee = true;
				value = 80000;
				ranged = true;
				rare = 4;
				knockBack = 1.75f;
				return;
			}
			if (type == 1188)
			{
				name = "Palladium Pickaxe";
				useStyle = 1;
				useTurn = true;
				autoReuse = true;
				useAnimation = 25;
				useTime = 11;
				knockBack = 5f;
				width = 20;
				height = 12;
				damage = 12;
				pick = 130;

				rare = 4;
				value = 72000;
				melee = true;
				toolTip = "Can mine Mythril and Orichalcum";
				scale = 1.15f;
				return;
			}
			if (type == 1189)
			{
				name = "Palladium Drill";
				useStyle = 5;
				useAnimation = 25;
				useTime = 11;
				shootSpeed = 32f;
				knockBack = 0f;
				width = 20;
				height = 12;
				damage = 12;
				pick = 130;

				shoot = 213;
				rare = 4;
				value = 72000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				toolTip = "Can mine Mythril and Orichalcum";
				return;
			}
			if (type == 1190)
			{
				name = "Palladium Chainsaw";
				useStyle = 5;
				useAnimation = 25;
				useTime = 8;
				shootSpeed = 40f;
				knockBack = 2.9f;
				width = 20;
				height = 12;
				damage = 26;
				axe = 15;

				shoot = 214;
				rare = 4;
				value = 72000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				return;
			}
			if (type == 1191)
			{
				name = "Orichalcum Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 22000;
				rare = 3;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 14;
				return;
			}
			if (type == 1192)
			{
				name = "Orichalcum Sword";
				useStyle = 1;
				useAnimation = 26;
				useTime = 26;
				knockBack = 6f;
				width = 40;
				height = 40;
				damage = 41;
				scale = 1.17f;

				rare = 4;
				value = 126500;
				melee = true;
				return;
			}
			if (type == 1193)
			{
				name = "Orichalcum Halberd";
				useStyle = 5;
				useAnimation = 25;
				useTime = 25;
				shootSpeed = 4.5f;
				knockBack = 5.5f;
				width = 40;
				height = 40;
				damage = 36;
				scale = 1.1f;

				shoot = 215;
				rare = 4;
				value = 82500;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			}
			if (type == 1194)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 22;
				useTime = 22;
				name = "Orichalcum Repeater";
				width = 50;
				height = 18;
				shoot = 1;
				useAmmo = AmmoID.Arrow;

				damage = 38;
				shootSpeed = 9.75f;
				noMelee = true;
				value = 110000;
				ranged = true;
				rare = 4;
				knockBack = 2f;
				return;
			}
			if (type == 1195)
			{
				name = "Orichalcum Pickaxe";
				useStyle = 1;
				useAnimation = 25;
				useTime = 8;
				knockBack = 5f;
				useTurn = true;
				autoReuse = true;
				width = 20;
				height = 12;
				damage = 17;
				pick = 165;

				rare = 4;
				value = 99000;
				melee = true;
				toolTip = "Can mine Adamantite and Titanium";
				scale = 1.15f;
				return;
			}
			if (type == 1196)
			{
				name = "Orichalcum Drill";
				useStyle = 5;
				useAnimation = 25;
				useTime = 10;
				shootSpeed = 32f;
				knockBack = 0f;
				width = 20;
				height = 12;
				damage = 17;
				pick = 165;

				shoot = 216;
				rare = 4;
				value = 99000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				toolTip = "Can mine Adamantite and Titanium";
				return;
			}
			if (type == 1197)
			{
				name = "Orichalcum Chainsaw";
				useStyle = 5;
				useAnimation = 25;
				useTime = 7;
				shootSpeed = 40f;
				knockBack = 3.75f;
				width = 20;
				height = 12;
				damage = 31;
				axe = 18;

				shoot = 217;
				rare = 4;
				value = 99000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				return;
			}
			if (type == 1198)
			{
				name = "Titanium Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 37500;
				rare = 3;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 16;
				return;
			}
			if (type == 1199)
			{
				name = "Titanium Sword";
				useStyle = 1;
				useAnimation = 26;
				useTime = 26;
				knockBack = 6f;
				width = 40;
				height = 40;
				damage = 46;
				scale = 1.2f;

				rare = 4;
				value = 161000;
				melee = true;
				return;
			}
			if (type == 1200)
			{
				name = "Titanium Trident";
				useStyle = 5;
				useAnimation = 23;
				useTime = 23;
				shootSpeed = 5f;
				knockBack = 6.2f;
				width = 40;
				height = 40;
				damage = 40;
				scale = 1.1f;

				shoot = 218;
				rare = 4;
				value = 105000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			}
			if (type == 1201)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 19;
				useTime = 19;
				name = "Titanium Repeater";
				width = 50;
				height = 18;
				shoot = 1;
				useAmmo = AmmoID.Arrow;

				damage = 41;
				shootSpeed = 10.5f;
				noMelee = true;
				value = 140000;
				ranged = true;
				rare = 4;
				knockBack = 2.5f;
				return;
			}
			if (type == 1202)
			{
				name = "Titanium Pickaxe";
				useStyle = 1;
				useAnimation = 25;
				useTime = 7;
				knockBack = 5f;
				useTurn = true;
				autoReuse = true;
				width = 20;
				height = 12;
				damage = 27;
				pick = 190;

				rare = 4;
				value = 126000;
				melee = true;
				scale = 1.15f;
				return;
			}
			if (type == 1203)
			{
				name = "Titanium Drill";
				useStyle = 5;
				useAnimation = 25;
				useTime = 7;
				shootSpeed = 32f;
				knockBack = 0f;
				width = 20;
				height = 12;
				damage = 27;
				pick = 190;

				shoot = 219;
				rare = 4;
				value = 126000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				return;
			}
			if (type == 1204)
			{
				name = "Titanium Chainsaw";
				useStyle = 5;
				useAnimation = 25;
				useTime = 6;
				shootSpeed = 40f;
				knockBack = 4.6f;
				width = 20;
				height = 12;
				damage = 34;
				axe = 21;

				shoot = 220;
				rare = 4;
				value = 126000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				return;
			}
			if (type == 1205)
			{
				name = "Palladium Mask";
				width = 18;
				height = 18;
				defense = 14;
				headSlot = 83;
				rare = 4;
				value = 75000;
				toolTip = "7% increased movement speed";
				toolTip2 = "12% increased melee speed";
				return;
			}
			if (type == 1206)
			{
				name = "Palladium Helmet";
				width = 18;
				height = 18;
				defense = 5;
				headSlot = 84;
				rare = 4;
				value = 75000;
				toolTip = "10% increased ranged damage";
				toolTip2 = "6% increased ranged critical strike chance";
				return;
			}
			if (type == 1207)
			{
				name = "Palladium Headgear";
				width = 18;
				height = 18;
				defense = 3;
				headSlot = 85;
				rare = 4;
				value = 75000;
				toolTip = "Increases maximum mana by 40";
				toolTip2 = "9% increased magic critical strike chance";
				return;
			}
			if (type == 1208)
			{
				name = "Palladium Breastplate";
				width = 18;
				height = 18;
				defense = 10;
				bodySlot = 54;
				rare = 4;
				value = 60000;
				toolTip2 = "3% increased critical strike chance";
				return;
			}
			if (type == 1209)
			{
				name = "Palladium Leggings";
				width = 18;
				height = 18;
				defense = 8;
				legSlot = 49;
				rare = 4;
				value = 45000;
				toolTip2 = "10% increased movement speed";
				return;
			}
			if (type == 1210)
			{
				name = "Orichalcum Mask";
				width = 18;
				height = 18;
				defense = 19;
				headSlot = 86;
				rare = 4;
				value = 112500;
				toolTip = "5% increased melee critical strike chance";
				toolTip2 = "10% increased melee damage";
				return;
			}
			if (type == 1211)
			{
				name = "Orichalcum Helmet";
				width = 18;
				height = 18;
				defense = 7;
				headSlot = 87;
				rare = 4;
				value = 112500;
				toolTip = "12% increased ranged damage";
				toolTip2 = "7% increased ranged critical strike chance";
				return;
			}
			if (type == 1212)
			{
				name = "Orichalcum Headgear";
				width = 18;
				height = 18;
				defense = 4;
				headSlot = 88;
				rare = 4;
				value = 112500;
				toolTip = "Increases maximum mana by 60";
				toolTip2 = "15% increased magic damage";
				return;
			}
			if (type == 1213)
			{
				name = "Orichalcum Breastplate";
				width = 18;
				height = 18;
				defense = 13;
				bodySlot = 55;
				rare = 4;
				value = 90000;
				toolTip2 = "5% increased damage";
				return;
			}
			if (type == 1214)
			{
				name = "Orichalcum Leggings";
				width = 18;
				height = 18;
				defense = 10;
				legSlot = 50;
				rare = 4;
				value = 67500;
				toolTip2 = "3% increased critical strike chance";
				return;
			}
			if (type == 1215)
			{
				name = "Titanium Mask";
				width = 18;
				height = 18;
				defense = 23;
				headSlot = 89;
				rare = 4;
				value = 150000;
				toolTip = "7% increased melee critical strike chance";
				toolTip2 = "14% increased melee damage";
				return;
			}
			if (type == 1216)
			{
				name = "Titanium Helmet";
				width = 18;
				height = 18;
				defense = 8;
				headSlot = 90;
				rare = 4;
				value = 150000;
				toolTip = "14% increased ranged damage";
				toolTip2 = "8% increased ranged critical strike chance";
				return;
			}
			if (type == 1217)
			{
				name = "Titanium Headgear";
				width = 18;
				height = 18;
				defense = 4;
				headSlot = 91;
				rare = 4;
				value = 150000;
				toolTip = "Increases maximum mana by 80";
				toolTip2 = "11% increased magic damage and critical strike chance";
				return;
			}
			if (type == 1218)
			{
				name = "Titanium Breastplate";
				width = 18;
				height = 18;
				defense = 15;
				bodySlot = 56;
				rare = 4;
				value = 120000;
				toolTip = "6% increased damage";
				return;
			}
			if (type == 1219)
			{
				name = "Titanium Leggings";
				width = 18;
				height = 18;
				defense = 11;
				legSlot = 51;
				rare = 4;
				value = 90000;
				toolTip = "4% increased critical strike chance";
				toolTip2 = "5% increased movement speed";
				return;
			}
			if (type == 1220)
			{
				name = "Mythril Anvil";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 134;
				placeStyle = 1;
				width = 28;
				height = 14;
				value = 25000;
				toolTip = "Used to craft items from mythril, orichalcum, adamantite, and titanium bars";
				rare = 3;
				return;
			}
			if (type == 1221)
			{
				name = "Orichalcum Forge";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 133;
				placeStyle = 1;
				width = 44;
				height = 30;
				value = 50000;
				toolTip = "Used to smelt adamantite and titanium ore";
				rare = 3;
				return;
			}
			if (type == 1222)
			{
				useTurn = true;
				autoReuse = true;
				name = "Palladium Waraxe";
				useStyle = 1;
				useAnimation = 35;
				useTime = 8;
				knockBack = 5.5f;
				width = 20;
				height = 12;
				damage = 36;
				axe = 15;

				rare = 4;
				value = 72000;
				melee = true;
				scale = 1.1f;
				return;
			}
			if (type == 1223)
			{
				useTurn = true;
				autoReuse = true;
				name = "Orichalcum Waraxe";
				useStyle = 1;
				useAnimation = 35;
				useTime = 7;
				knockBack = 6.5f;
				width = 20;
				height = 12;
				damage = 41;
				axe = 18;

				rare = 4;
				value = 99000;
				melee = true;
				scale = 1.1f;
				return;
			}
			if (type == 1224)
			{
				useTurn = true;
				autoReuse = true;
				name = "Titanium Waraxe";
				useStyle = 1;
				useAnimation = 35;
				useTime = 6;
				knockBack = 7.5f;
				width = 20;
				height = 12;
				damage = 44;
				axe = 21;

				rare = 4;
				value = 108000;
				melee = true;
				scale = 1.1f;
				return;
			}
			if (type == 1225)
			{
				name = "Hallowed Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = Item.sellPrice(0, 0, 40, 0);
				rare = 4;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 18;
				return;
			}
			if (type == 1226)
			{
				name = "Chlorophyte Claymore";
				useStyle = 1;
				useAnimation = 26;
				useTime = 60;
				shoot = 229;
				shootSpeed = 8f;
				knockBack = 6f;
				width = 40;
				height = 40;
				damage = 75;

				rare = 7;
				value = 276000;
				scale = 1.25f;
				melee = true;
				return;
			}
			if (type == 1227)
			{
				name = "Chlorophyte Saber";
				autoReuse = true;
				useTurn = true;
				useStyle = 1;
				useAnimation = 16;
				useTime = 42;
				shoot = 228;
				shootSpeed = 8f;
				knockBack = 4f;
				width = 40;
				height = 40;
				damage = 48;

				rare = 7;
				value = 276000;
				melee = true;
				return;
			}
			if (type == 1228)
			{
				name = "Chlorophyte Partisan";
				useStyle = 5;
				useAnimation = 23;
				useTime = 23;
				shootSpeed = 5f;
				knockBack = 6.2f;
				width = 40;
				height = 40;
				damage = 49;
				scale = 1.1f;

				shoot = 222;
				rare = 7;
				value = 180000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			}
			if (type == 1229)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 19;
				useTime = 19;
				name = "Chlorophyte Shotbow";
				width = 50;
				height = 18;
				shoot = 1;
				useAmmo = AmmoID.Arrow;

				damage = 34;
				shootSpeed = 11.5f;
				noMelee = true;
				value = 240000;
				ranged = true;
				rare = 7;
				knockBack = 2.75f;
				return;
			}
			if (type == 1230)
			{
				name = "Chlorophyte Pickaxe";
				useStyle = 1;
				useAnimation = 25;
				useTime = 7;
				knockBack = 5f;
				useTurn = true;
				autoReuse = true;
				width = 20;
				height = 12;
				damage = 40;
				pick = 200;

				rare = 7;
				value = 216000;
				melee = true;
				scale = 1.15f;
				tileBoost++;
				return;
			}
			if (type == 1231)
			{
				name = "Chlorophyte Drill";
				useStyle = 5;
				useAnimation = 25;
				useTime = 7;
				shootSpeed = 40f;
				knockBack = 1f;
				width = 20;
				height = 12;
				damage = 35;
				pick = 200;

				shoot = 223;
				rare = 7;
				value = 216000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				tileBoost++;
				return;
			}
			if (type == 1232)
			{
				name = "Chlorophyte Chainsaw";
				useStyle = 5;
				useAnimation = 25;
				useTime = 7;
				shootSpeed = 46f;
				knockBack = 4.6f;
				width = 20;
				height = 12;
				damage = 50;
				axe = 23;

				shoot = 224;
				rare = 7;
				value = 216000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				tileBoost++;
				return;
			}
			if (type == 1233)
			{
				useTurn = true;
				autoReuse = true;
				name = "Chlorophyte Greataxe";
				useStyle = 1;
				useAnimation = 30;
				useTime = 6;
				knockBack = 7f;
				width = 20;
				height = 12;
				damage = 70;
				axe = 23;

				rare = 7;
				value = 216000;
				melee = true;
				scale = 1.15f;
				tileBoost++;
				return;
			}
			if (type == 1234)
			{
				name = "Chlorophyte Warhammer";
				useTurn = true;
				autoReuse = true;
				useStyle = 1;
				useAnimation = 35;
				useTime = 14;
				hammer = 90;
				width = 24;
				height = 28;
				damage = 80;
				knockBack = 8f;
				scale = 1.25f;

				rare = 7;
				value = 216000;
				melee = true;
				tileBoost++;
				return;
			}
			if (type == 1235)
			{
				name = "Chlorophyte Arrow";
				shootSpeed = 4.5f;
				shoot = 225;
				damage = 16;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Arrow;
				knockBack = 3.5f;
				value = 100;
				ranged = true;
				rare = 7;
				return;
			}
			if (type == 1236)
			{
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Amethyst Hook";
				shootSpeed = 10f;
				shoot = 230;
				width = 18;
				height = 28;

				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				value = 20000;
				return;
			}
			if (type == 1237)
			{
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Topaz Hook";
				shootSpeed = 10.5f;
				shoot = 231;
				width = 18;
				height = 28;

				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				value = 20000;
				return;
			}
			if (type == 1238)
			{
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Sapphire Hook";
				shootSpeed = 11f;
				shoot = 232;
				width = 18;
				height = 28;

				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				value = 20000;
				return;
			}
			if (type == 1239)
			{
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Emerald Hook";
				shootSpeed = 11.5f;
				shoot = 233;
				width = 18;
				height = 28;

				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				value = 20000;
				return;
			}
			if (type == 1240)
			{
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Ruby Hook";
				shootSpeed = 12f;
				shoot = 234;
				width = 18;
				height = 28;

				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				value = 20000;
				return;
			}
			if (type == 1241)
			{
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Diamond Hook";
				shootSpeed = 12.5f;
				shoot = 235;
				width = 18;
				height = 28;

				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				value = 20000;
				return;
			}
			if (type == 1242)
			{
				damage = 0;
				useStyle = 1;
				name = "Amber Mosquito";
				shoot = 236;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Baby Dinosaur";
				value = Item.sellPrice(0, 7, 50, 0);
				buffType = 61;
				return;
			}
			if (type == 1243)
			{
				name = "Umbrella Hat";
				width = 28;
				height = 20;
				headSlot = 92;
				rare = 1;
				vanity = true;
				return;
			}
			if (type == 1244)
			{
				mana = 10;
				damage = 36;
				useStyle = 1;
				name = "Nimbus Rod";
				shootSpeed = 16f;
				shoot = 237;
				width = 26;
				height = 28;

				useAnimation = 22;
				useTime = 22;
				rare = 6;
				noMelee = true;
				knockBack = 0f;
				toolTip = "Summons a cloud to rain down on your foes";
				value = Item.sellPrice(0, 3, 50, 0);
				magic = true;
				return;
			}
			if (type == 1245)
			{
				name = "Orange Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 10;
				width = 10;
				height = 12;
				value = 60;
				noWet = true;
				return;
			}
			if (type == 1246)
			{
				name = "Crimsand Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 234;
				width = 12;
				height = 12;
				ammo = AmmoID.Sand;
				return;
			}
			if (type == 1247)
			{
				name = "Bee Cloak";
				width = 20;
				height = 24;
				value = 150000;
				toolTip = "Causes stars to fall and releases bees when injured";
				accessory = true;
				rare = 4;
				backSlot = 1;
				return;
			}
			if (type == 1248)
			{
				name = "Eye of the Golem";
				width = 24;
				height = 24;
				accessory = true;
				toolTip = "10% increased critical strike chance";
				value = 100000;
				rare = 7;
				return;
			}
			if (type == 1249)
			{
				name = "Honey Balloon";
				width = 14;
				height = 28;
				rare = 2;
				value = 54000;
				accessory = true;
				toolTip = "Increases jump height";
				toolTip2 = "Releases bees when damaged";
				balloonSlot = 7;
				return;
			}
			if (type == 1250)
			{
				name = "Blue Horseshoe Balloon";
				width = 20;
				height = 22;
				rare = 4;
				value = 45000;
				accessory = true;
				toolTip = "Allows the holder to double jump";
				toolTip = "Increases jump height and negates fall damage";
				balloonSlot = 2;
				return;
			}
			if (type == 1251)
			{
				name = "White Horseshoe Balloon";
				width = 20;
				height = 22;
				rare = 4;
				value = 45000;
				accessory = true;
				toolTip = "Allows the holder to double jump";
				toolTip = "Increases jump height and negates fall damage";
				balloonSlot = 9;
				return;
			}
			if (type == 1252)
			{
				name = "Yellow Horseshoe Balloon";
				width = 20;
				height = 22;
				rare = 4;
				value = 45000;
				accessory = true;
				toolTip = "Allows the holder to double jump";
				toolTip = "Increases jump height and negates fall damage";
				balloonSlot = 10;
				return;
			}
			if (type == 1253)
			{
				name = "Frozen Turtle Scale";
				width = 20;
				height = 24;
				value = 225000;
				toolTip = "Puts a shell around the owner when below 20% life";
				accessory = true;
				rare = 5;
				return;
			}
			if (type == 1254)
			{
				useStyle = 5;
				useAnimation = 36;
				useTime = 36;
				name = "Sniper Rifle";
				crit += 25;
				width = 44;
				height = 14;
				shoot = 10;
				useAmmo = AmmoID.Bullet;
				damage = 185;
				shootSpeed = 16f;
				noMelee = true;
				value = 100000;
				knockBack = 8f;
				rare = 8;
				ranged = true;
				return;
			}
			if (type == 1255)
			{
				autoReuse = false;
				useStyle = 5;
				useAnimation = 8;
				useTime = 8;
				name = "Venus Magnum";
				width = 24;
				height = 22;
				shoot = 14;
				knockBack = 5.5f;
				useAmmo = AmmoID.Bullet;
				damage = 38;
				shootSpeed = 13.5f;
				noMelee = true;
				value = Item.sellPrice(0, 5, 0, 0);
				scale = 0.85f;
				rare = 7;
				ranged = true;
				return;
			}
			if (type == 1256)
			{
				mana = 10;
				damage = 12;
				useStyle = 1;
				name = "Crimson Rod";
				shootSpeed = 12f;
				shoot = 243;
				width = 26;
				height = 28;
				useAnimation = 24;
				useTime = 24;
				rare = 1;
				noMelee = true;
				knockBack = 0f;
				toolTip = "Summons a cloud to rain blood on your foes";
				value = 10000;
				magic = true;
				return;
			}
			if (type == 1257)
			{
				name = "Crimtane Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				rare = 1;
				value = 20000;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 19;
				return;
			}
			if (type == 1258)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 22;
				useTime = 22;
				name = "Stynger";
				width = 50;
				height = 18;
				shoot = 246;
				useAmmo = AmmoID.StyngerBolt;
				damage = 45;
				knockBack = 5f;
				shootSpeed = 9f;
				noMelee = true;
				value = 350000;
				rare = 7;
				ranged = true;
				toolTip = "Shoots a bolt that explodes into deadly shrapnel";
				return;
			}
			if (type == 1259)
			{
				name = "Flower Pow";
				noMelee = true;
				useStyle = 5;
				useAnimation = 40;
				useTime = 40;
				knockBack = 7.5f;
				width = 30;
				height = 10;
				damage = 65;
				scale = 1.1f;
				noUseGraphic = true;
				shoot = 247;
				shootSpeed = 15.9f;

				rare = 7;
				value = Item.sellPrice(0, 6, 0, 0);
				melee = true;
				channel = true;
				return;
			}
			if (type == 1260)
			{
				useStyle = 5;
				useAnimation = 40;
				useTime = 40;
				name = "Rainbow Gun";
				width = 50;
				height = 18;
				shoot = 250;
				damage = 45;
				knockBack = 2.5f;
				shootSpeed = 16f;
				noMelee = true;
				value = 350000;
				rare = 8;
				magic = true;
				mana = 20;
				return;
			}
			if (type == 1261)
			{
				name = "Stynger Bolt";
				shootSpeed = 2f;
				shoot = 246;
				damage = 17;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.StyngerBolt;
				knockBack = 1f;
				value = 75;
				rare = 5;
				ranged = true;
				return;
			}
			if (type == 1262)
			{
				name = "Chlorophyte Jackhammer";
				useStyle = 5;
				useAnimation = 25;
				useTime = 7;
				shootSpeed = 46f;
				knockBack = 5.2f;
				width = 20;
				height = 12;
				damage = 45;
				hammer = 90;
				shoot = 252;
				rare = 7;
				value = 216000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				tileBoost++;
				return;
			}
			if (type == 1263)
			{
				name = "Teleporter";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 235;
				width = 12;
				height = 12;
				value = Item.buyPrice(0, 2, 50, 0);
				mech = true;
				return;
			}
			if (type == 1264)
			{
				mana = 17;
				damage = 55;
				useStyle = 1;
				name = "Flower of Frost";
				shootSpeed = 7f;
				shoot = 253;
				width = 26;
				height = 28;
				useAnimation = 20;
				useTime = 20;
				rare = 6;
				noMelee = true;
				knockBack = 6.5f;
				toolTip = "Throws balls of frost";
				value = 10000;
				magic = true;
				return;
			}
			if (type == 1265)
			{
				autoReuse = true;
				useStyle = 5;
				useAnimation = 9;
				useTime = 9;
				name = "Uzi";
				width = 24;
				height = 22;
				shoot = 14;
				knockBack = 3.5f;
				useAmmo = AmmoID.Bullet;
				damage = 30;
				shootSpeed = 13f;
				noMelee = true;
				value = 50000;
				scale = 0.75f;
				rare = 7;
				ranged = true;
				return;
			}
			if (type == 1266)
			{
				rare = 8;
				mana = 14;
				name = "Magnet Sphere";
				noMelee = true;
				useStyle = 5;
				damage = 48;
				knockBack = 6f;
				useAnimation = 20;
				useTime = 20;
				width = 24;
				height = 28;
				shoot = 254;
				shootSpeed = 1.2f;
				toolTip = "Summons something to do stuff and things";
				magic = true;
				value = 500000;
				return;
			}
			if (type == 1267)
			{
				name = "Purple Stained Glass";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 88;
				width = 12;
				height = 12;
				value = Item.sellPrice(0, 0, 5, 0);
				return;
			}
			if (type == 1268)
			{
				name = "Yellow Stained Glass";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 89;
				width = 12;
				height = 12;
				value = Item.sellPrice(0, 0, 5, 0);
				return;
			}
			if (type == 1269)
			{
				name = "Blue Stained Glass";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 90;
				width = 12;
				height = 12;
				value = Item.sellPrice(0, 0, 5, 0);
				return;
			}
			if (type == 1270)
			{
				name = "Green Stained Glass";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 91;
				width = 12;
				height = 12;
				value = Item.sellPrice(0, 0, 5, 0);
				return;
			}
			if (type == 1271)
			{
				name = "Red Stained Glass";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 92;
				width = 12;
				height = 12;
				value = Item.sellPrice(0, 0, 5, 0);
				return;
			}
			if (type == 1272)
			{
				name = "Multicolored Stained Glass";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 93;
				width = 12;
				height = 12;
				value = Item.sellPrice(0, 0, 5, 0);
				return;
			}
			if (type == 1273)
			{
				name = "Skeletron Hand";
				useStyle = 5;
				useAnimation = 25;
				useTime = 25;
				width = 30;
				height = 10;
				noUseGraphic = true;
				shoot = 256;
				shootSpeed = 15f;

				rare = 2;
				value = 45000;
				return;
			}
			if (type == 1274)
			{
				name = "Skull";
				width = 28;
				height = 20;
				headSlot = 93;
				rare = 1;
				vanity = true;
				return;
			}
			if (type == 1275)
			{
				name = "Balla Hat";
				width = 28;
				height = 20;
				headSlot = 94;
				rare = 1;
				vanity = true;
				value = Item.buyPrice(0, 1, 0, 0);
				return;
			}
			if (type == 1276)
			{
				name = "Gangsta Hat";
				width = 28;
				height = 20;
				headSlot = 95;
				rare = 1;
				vanity = true;
				value = Item.buyPrice(0, 1, 0, 0);
				return;
			}
			if (type == 1277)
			{
				name = "Sailor Hat";
				width = 28;
				height = 20;
				headSlot = 96;
				rare = 1;
				vanity = true;
				return;
			}
			if (type == 1278)
			{
				name = "Eye Patch";
				width = 28;
				height = 20;
				headSlot = 97;
				rare = 1;
				vanity = true;
				return;
			}
			if (type == 1279)
			{
				name = "Sailor Shirt";
				width = 28;
				height = 20;
				bodySlot = 57;
				rare = 1;
				vanity = true;
				return;
			}
			if (type == 1280)
			{
				name = "Sailor Pants";
				width = 28;
				height = 20;
				legSlot = 52;
				rare = 1;
				vanity = true;
				return;
			}
			if (type == 1281)
			{
				name = "Skeletron Mask";
				width = 28;
				height = 20;
				headSlot = 98;
				rare = 1;
				vanity = true;
				return;
			}
			if (type == 1282)
			{
				name = "Amethyst Robe";
				width = 18;
				height = 14;
				bodySlot = 58;
				value = Item.sellPrice(0, 0, 50, 0);
				toolTip = "Increases maximum mana by 20";
				toolTip = "Reduces mana usage by 5%";
				return;
			}
			if (type == 1283)
			{
				name = "Topaz Robe";
				width = 18;
				height = 14;
				bodySlot = 59;
				defense = 1;
				value = Item.sellPrice(0, 0, 50, 0) * 2;
				toolTip = "Increases maximum mana by 40";
				toolTip2 = "Reduces mana usage by 7%";
				return;
			}
			if (type == 1284)
			{
				name = "Sapphire Robe";
				width = 18;
				height = 14;
				bodySlot = 60;
				defense = 1;
				value = Item.sellPrice(0, 0, 50, 0) * 3;
				toolTip = "Increases maximum mana by 40";
				toolTip2 = "Reduces mana usage by 9%";
				rare = 1;
				return;
			}
			if (type == 1285)
			{
				name = "Emerald Robe";
				width = 18;
				height = 14;
				bodySlot = 61;
				defense = 2;
				value = Item.sellPrice(0, 0, 50, 0) * 4;
				toolTip = "Increases maximum mana by 60";
				toolTip2 = "Reduces mana usage by 11%";
				rare = 1;
				return;
			}
			if (type == 1286)
			{
				name = "Ruby Robe";
				width = 18;
				height = 14;
				bodySlot = 62;
				defense = 2;
				value = Item.sellPrice(0, 0, 50, 0) * 5;
				toolTip = "Increases maximum mana by 60";
				toolTip2 = "Reduces mana usage by 13%";
				rare = 1;
				return;
			}
			if (type == 1287)
			{
				name = "Diamond Robe";
				defense = 3;
				width = 18;
				height = 14;
				bodySlot = 63;
				value = Item.sellPrice(0, 0, 50, 0) * 6;
				toolTip = "Increases maximum mana by 80";
				toolTip2 = "Reduces mana usage by 15%";
				rare = 2;
				return;
			}
			if (type == 1288)
			{
				name = "White Tuxedo Shirt";
				width = 28;
				height = 20;
				bodySlot = 64;
				rare = 1;
				vanity = true;
				value = Item.buyPrice(0, 25, 0, 0);
				return;
			}
			if (type == 1289)
			{
				name = "White Tuxedo Pants";
				width = 28;
				height = 20;
				legSlot = 53;
				rare = 1;
				vanity = true;
				value = Item.buyPrice(0, 25, 0, 0);
				return;
			}
			if (type == 1290)
			{
				name = "Panic Necklace";
				width = 22;
				height = 22;
				accessory = true;
				rare = 1;
				toolTip = "Increases movement speed after being struck";
				value = 50000;
				neckSlot = 3;
				return;
			}
			if (type == 1291)
			{
				name = "Heart Fruit";
				maxStack = 99;
				consumable = true;
				width = 18;
				height = 18;
				useStyle = 4;
				useTime = 30;

				useAnimation = 30;
				toolTip = "Permanently increases maximum life by 5";
				rare = 7;
				value = Item.sellPrice(0, 2, 0, 0);
				return;
			}
			if (type == 1292)
			{
				name = "Lihzahrd Altar";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 237;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 1293)
			{
				name = "Lihzahrd Power Cell";
				maxStack = 99;
				consumable = true;
				width = 22;
				height = 10;
				value = Item.sellPrice(0, 1, 0, 0);
				return;
			}
			if (type == 1294)
			{
				name = "Picksaw";
				useStyle = 1;
				useAnimation = 16;
				useTime = 6;
				knockBack = 5.5f;
				useTurn = true;
				autoReuse = true;
				width = 20;
				height = 12;
				damage = 34;
				pick = 210;
				axe = 25;

				rare = 7;
				value = 216000;
				melee = true;
				scale = 1.15f;
				tileBoost++;
				toolTip = "Capable of mining Lihzahrd Bricks";
				return;
			}
			if (type == 1295)
			{
				mana = 8;
				useStyle = 5;
				autoReuse = true;
				useAnimation = 16;
				useTime = 16;
				name = "Heat Ray";
				width = 24;
				height = 18;
				shoot = 260;

				damage = 55;
				shootSpeed = 15f;
				noMelee = true;
				value = 350000;
				knockBack = 3f;
				rare = 7;
				magic = true;
				toolTip = "Shoots a piercing beam of heat";
				return;
			}
			if (type == 1296)
			{
				mana = 15;
				damage = 73;
				useStyle = 1;
				name = "Staff of Earth";
				shootSpeed = 11f;
				shoot = 261;
				width = 26;
				height = 28;

				useAnimation = 40;
				useTime = 40;
				rare = 7;
				noMelee = true;
				knockBack = 7.5f;
				value = Item.sellPrice(0, 10, 0, 0);
				magic = true;
				toolTip = "Summons a powerful boulder";
				return;
			}
			if (type == 1297)
			{
				autoReuse = true;
				name = "Golem Fist";
				useStyle = 5;
				useAnimation = 24;
				useTime = 24;
				knockBack = 12f;
				width = 30;
				height = 10;
				damage = 76;
				scale = 0.9f;
				shoot = 262;
				shootSpeed = 14f;

				rare = 7;
				value = Item.sellPrice(0, 5, 0, 0);
				melee = true;
				noMelee = true;
				toolTip = "Punches with the force of a golem";
				return;
			}
			if (type == 1298)
			{
				name = "Water Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 17;
				width = 26;
				height = 22;
				value = 500;
				return;
			}
			if (type == 1299)
			{
				name = "Binoculars";
				width = 14;
				height = 28;
				rare = 4;
				value = 150000;
				toolTip = "Increases view range when held";
				return;
			}
			if (type == 1300)
			{
				name = "Rifle Scope";
				width = 14;
				height = 28;
				rare = 4;
				value = 150000;
				accessory = true;
				toolTip = "Increases view range for guns";
				toolTip2 = "Right click to zoom out";
				return;
			}
			if (type == 1301)
			{
				name = "Destroyer Emblem";
				width = 24;
				height = 24;
				accessory = true;
				toolTip = "10% increased damage";
				toolTip2 = "8% increased critical strike chance";
				value = 300000;
				rare = 7;
				return;
			}
			if (type == 1302)
			{
				name = "High Velocity Bullet";
				shootSpeed = 4f;
				shoot = 242;
				damage = 10;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Bullet;
				knockBack = 4f;
				value = 40;
				ranged = true;
				rare = 3;
				return;
			}
			if (type == 1303)
			{
				name = "Jellyfish Necklace";
				width = 24;
				height = 24;
				accessory = true;
				toolTip = "Provides light under water";
				value = Item.sellPrice(0, 1, 0, 0);
				rare = 2;
				neckSlot = 1;
				return;
			}
			if (type == 1304)
			{
				name = "Zombie Arm";
				useStyle = 1;
				useTurn = false;
				useAnimation = 23;
				useTime = 23;
				width = 24;
				height = 28;
				damage = 12;
				knockBack = 4.25f;

				scale = 1f;
				value = 2000;
				melee = true;
				return;
			}
			if (type == 1305)
			{
				name = "The Axe";
				autoReuse = true;
				useStyle = 1;
				useAnimation = 23;
				knockBack = 7.25f;
				useTime = 7;
				width = 24;
				height = 28;
				damage = 72;
				axe = 35;
				hammer = 100;
				tileBoost = 1;
				scale = 1.15f;

				rare = 8;
				value = Item.sellPrice(0, 10, 0, 0);
				melee = true;
				return;
			}
			if (type == 1306)
			{
				name = "Ice Sickle";
				useStyle = 1;
				useAnimation = 25;
				useTime = 25;
				knockBack = 5.5f;
				width = 24;
				height = 28;
				damage = 42;
				scale = 1.15f;
				rare = 5;
				shoot = 263;
				shootSpeed = 8f;
				value = 250000;
				toolTip = "Shoots an icy sickle";
				melee = true;
				return;
			}
			if (type == 1307)
			{
				accessory = true;
				name = "Clothier Voodoo Doll";
				width = 14;
				height = 26;
				value = 1000;
				toolTip = "'You are a terrible person.'";
				rare = 1;
				return;
			}
			if (type == 1308)
			{
				name = "Poison Staff";
				mana = 22;
				useStyle = 5;
				damage = 48;
				useAnimation = 36;
				useTime = 36;
				width = 40;
				height = 40;
				shoot = 265;
				shootSpeed = 13.5f;
				knockBack = 5.6f;
				magic = true;
				autoReuse = true;
				rare = 6;
				noMelee = true;
				value = Item.sellPrice(0, 4, 0, 0);
				return;
			}
			if (type == 1309)
			{
				mana = 10;
				damage = 8;
				useStyle = 1;
				name = "Slime Staff";
				shootSpeed = 10f;
				shoot = 266;
				width = 26;
				height = 28;
				useAnimation = 28;
				useTime = 28;
				rare = 4;
				noMelee = true;
				knockBack = 2f;
				toolTip = "Summons a baby slime to fight for you";
				buffType = 64;
				value = 100000;
				summon = true;
				return;
			}
			if (type == 1310)
			{
				name = "Poison Dart";
				shoot = 267;
				width = 8;
				height = 8;
				maxStack = 999;
				ammo = AmmoID.Dart;
				toolTip = "Inflicts poison on enemies";
				toolTip2 = "For use with Blowpipe and Blowgun";
				damage = 10;
				knockBack = 2f;
				shootSpeed = 2f;
				ranged = true;
				rare = 2;
				consumable = true;
				return;
			}
			if (type == 1311)
			{
				damage = 0;
				useStyle = 1;
				name = "Eyespring";
				shoot = 268;
				width = 16;
				height = 30;
				useAnimation = 20;
				useTime = 20;
				rare = 6;
				noMelee = true;
				toolTip = "Summons an eye spring";
				value = Item.sellPrice(0, 3, 0, 0);
				buffType = 65;
				return;
			}
			if (type == 1312)
			{
				damage = 0;
				useStyle = 1;
				name = "Toy Sled";
				shoot = 269;
				width = 16;
				height = 30;
				useAnimation = 20;
				useTime = 20;
				rare = 6;
				noMelee = true;
				toolTip = "Summons a baby snowman";
				value = Item.sellPrice(0, 2, 50, 0);
				buffType = 66;
				return;
			}
			if (type == 1313)
			{
				autoReuse = true;
				rare = 2;
				mana = 18;
				name = "Book of Skulls";
				noMelee = true;
				useStyle = 5;
				damage = 29;
				useAnimation = 26;
				useTime = 26;
				width = 24;
				height = 28;
				shoot = 270;
				scale = 0.9f;
				shootSpeed = 3.5f;
				knockBack = 3.5f;
				toolTip = "Shoots a skull";
				magic = true;
				value = 50000;
				return;
			}
			if (type == 1314)
			{
				autoReuse = true;
				name = "KO Cannon";
				useStyle = 5;
				useAnimation = 28;
				useTime = 28;
				knockBack = 6.5f;
				width = 30;
				height = 10;
				damage = 40;
				scale = 0.9f;
				shoot = 271;
				shootSpeed = 15f;

				rare = 4;
				value = 27000;
				melee = true;
				noMelee = true;
				toolTip = "Shoots a boxing glove";
				return;
			}
			if (type == 1315)
			{
				useStyle = 4;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				name = "Pirate Map";
				width = 28;
				height = 28;
				toolTip = "Summons a Pirate Invasion";
				return;
			}
			if (type == 1316)
			{
				name = "Turtle Helmet";
				width = 18;
				height = 18;
				defense = 21;
				headSlot = 99;
				rare = 8;
				value = 300000;
				toolTip = "5% increased melee damage";
				toolTip2 = "Enemies are more likely to target you";
				return;
			}
			if (type == 1317)
			{
				name = "Turtle Scale Mail";
				width = 18;
				height = 18;
				defense = 27;
				bodySlot = 65;
				rare = 8;
				value = 240000;
				toolTip = "7% increased melee damage and critical strike chance";
				toolTip2 = "Enemies are more likely to target you";
				return;
			}
			if (type == 1318)
			{
				name = "Turtle Leggings";
				width = 18;
				height = 18;
				defense = 17;
				legSlot = 54;
				rare = 8;
				value = 180000;
				toolTip = "3% increased melee critical strike chance";
				toolTip2 = "Enemies are more likely to target you";
				return;
			}
			if (type == 1319)
			{
				name = "Snowball Cannon";
				autoReuse = true;
				useStyle = 5;
				useAnimation = 19;
				useTime = 19;
				width = 44;
				height = 14;
				shoot = 166;
				useAmmo = AmmoID.Bullet;

				damage = 10;
				shootSpeed = 11f;
				noMelee = true;
				value = 100000;
				knockBack = 1f;
				rare = 1;
				ranged = true;
				useAmmo = AmmoID.Snowball;
				shoot = 166;
				return;
			}
			if (type == 1320)
			{
				name = "Bone Pickaxe";
				useStyle = 1;
				useTurn = true;
				useAnimation = 19;
				useTime = 11;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 8;
				pick = 50;

				knockBack = 3f;
				rare = 1;
				value = Item.buyPrice(0, 1, 50, 0);
				scale = 1.15f;
				melee = true;
				return;
			}
			if (type == 1321)
			{
				name = "Magic Quiver";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Increase arrow speed and damage by 10%";
				toolTip2 = "20% chance to not consume arrow";
				value = Item.sellPrice(0, 5, 0, 0);
				rare = 4;
				backSlot = 7;
				return;
			}
			if (type == 1322)
			{
				name = "Magma Stone";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Chance to inflict fire damage on attack";
				value = Item.sellPrice(0, 2, 0, 0);
				rare = 3;
				return;
			}
			if (type == 1323)
			{
				name = "Lava Rose";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Reduced damage from touching lava";
				value = Item.sellPrice(0, 2, 0, 0);
				rare = 3;
				faceSlot = 6;
				return;
			}
			if (type == 1324)
			{
				autoReuse = true;
				noMelee = true;
				useStyle = 1;
				name = "Bananarang";
				shootSpeed = 14f;
				shoot = 272;
				damage = 55;
				knockBack = 6.5f;
				width = 14;
				height = 28;

				useAnimation = 14;
				useTime = 14;
				noUseGraphic = true;
				rare = 5;
				value = 75000;
				melee = true;
				maxStack = 10;
				return;
			}
			if (type == 1325)
			{
				autoReuse = false;
				name = "Chain Knife";
				useStyle = 5;
				useAnimation = 20;
				useTime = 20;
				knockBack = 3.5f;
				width = 30;
				height = 10;
				damage = 11;
				shoot = 273;
				shootSpeed = 12f;

				rare = 2;
				value = 1000;
				melee = true;
				noUseGraphic = true;
				return;
			}
			if (type == 1326)
			{
				autoReuse = false;
				name = "Rod of Discord";
				useStyle = 1;
				useAnimation = 20;
				useTime = 20;
				width = 20;
				height = 20;

				rare = 7;
				value = Item.sellPrice(0, 10, 0, 0);
				toolTip = "Teleports to a new location";
				return;
			}
			if (type == 1327)
			{
				autoReuse = true;
				name = "Death Sickle";
				useStyle = 1;
				useAnimation = 25;
				useTime = 25;
				knockBack = 7f;
				width = 24;
				height = 28;
				damage = 57;
				scale = 1.15f;

				rare = 6;
				shoot = 274;
				shootSpeed = 9f;
				value = 250000;
				toolTip = "Shoots a deathly sickle";
				melee = true;
				return;
			}
			if (type == 1328)
			{
				name = "Turtle Scale";
				width = 14;
				height = 18;
				maxStack = 99;
				rare = 7;
				value = 5000;
				return;
			}
			if (type == 1329)
			{
				name = "Tissue Sample";
				width = 14;
				height = 18;
				maxStack = 99;
				rare = 1;
				value = 750;
				return;
			}
			if (type == 1330)
			{
				name = "Vertebrae";
				width = 18;
				height = 20;
				maxStack = 99;
				value = 12;
				return;
			}
			if (type == 1331)
			{
				useStyle = 4;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				name = "Bloody Spine";
				width = 28;
				height = 28;
				maxStack = 20;
				toolTip = "Summons the Brain of Cthulhu";
				return;
			}
			if (type == 1332)
			{
				name = "Ichor";
				width = 12;
				height = 14;
				maxStack = 99;
				value = 4500;
				rare = 3;
				toolTip = "'The blood of gods'";
				return;
			}
			if (type == 1333)
			{
				flame = true;
				name = "Ichor Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 11;
				width = 10;
				height = 12;
				value = 330;
				rare = 1;
				toolTip = "Can be placed in water";
				return;
			}
			if (type == 1334)
			{
				name = "Ichor Arrow";
				shootSpeed = 4.25f;
				shoot = 278;
				damage = 16;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Arrow;
				knockBack = 3f;
				value = 80;
				ranged = true;
				rare = 3;
				toolTip = "Decreases target's defense";
				return;
			}
			if (type == 1335)
			{
				name = "Ichor Bullet";
				shootSpeed = 5.25f;
				shoot = 279;
				damage = 13;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Bullet;
				knockBack = 4f;
				value = 30;
				ranged = true;
				rare = 3;
				toolTip = "Decreases target's defense";
				return;
			}
			if (type == 1336)
			{
				mana = 7;
				autoReuse = true;
				name = "Golden Shower";
				useStyle = 5;
				useAnimation = 18;
				useTime = 6;
				knockBack = 4f;
				width = 38;
				height = 10;
				damage = 21;
				shoot = 280;
				shootSpeed = 10f;

				rare = 4;
				value = 500000;
				toolTip = "Sprays out a shower of ichor";
				magic = true;
				noMelee = true;
				return;
			}
			if (type == 1337)
			{
				name = "Bunny Cannon";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 209;
				placeStyle = 1;
				width = 12;
				height = 12;
				value = Item.buyPrice(0, 50, 0, 0);
				return;
			}
			if (type == 1338)
			{
				name = "Explosive Bunny";
				useStyle = 1;
				useTurn = true;
				useAnimation = 20;
				useTime = 20;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				damage = 350;
				noMelee = true;
				value = Item.buyPrice(0, 0, 35, 0);
				return;
			}
			if (type == 1339)
			{
				name = "Vial of Venom";
				width = 12;
				height = 20;
				maxStack = 99;
				value = Item.buyPrice(0, 0, 10, 0);
				return;
			}
			if (type == 1340)
			{
				name = "Flask of Venom";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 71;
				buffTime = 72000;
				toolTip = "Melee attacks inflict venom on enemies";
				value = Item.sellPrice(0, 0, 5, 0);
				rare = 4;
				return;
			}
			if (type == 1341)
			{
				name = "Venom Arrow";
				shootSpeed = 4.3f;
				shoot = 282;
				damage = 17;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Arrow;
				knockBack = 4.2f;
				value = 90;
				ranged = true;
				rare = 3;
				toolTip = "Inflicts target with venom";
				return;
			}
			if (type == 1342)
			{
				name = "Venom Bullet";
				shootSpeed = 5.3f;
				shoot = 283;
				damage = 14;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Bullet;
				knockBack = 4.1f;
				value = 40;
				ranged = true;
				rare = 3;
				toolTip = "Inflicts target with venom";
				return;
			}
			if (type == 1343)
			{
				name = "Fire Gauntlet";
				width = 16;
				height = 24;
				accessory = true;
				rare = 7;
				toolTip = "Increases melee knockback and inflicts fire damage on attack";
				toolTip = "9% increased melee damage and speed";
				value = 300000;
				handOffSlot = 1;
				handOnSlot = 6;
				return;
			}
			if (type == 1344)
			{
				name = "Cog";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 272;
				width = 12;
				height = 12;
				value = Item.buyPrice(0, 0, 7, 0);
				return;
			}
			if (type == 1345)
			{
				name = "Confetti";
				width = 12;
				height = 20;
				maxStack = 99;
				value = Item.buyPrice(0, 0, 1, 0);
				noMelee = true;
				useStyle = 1;
				useAnimation = (useTime = 20);
				autoReuse = true;
				consumable = true;
				return;
			}
			if (type == 1346)
			{
				name = "Nanites";
				width = 12;
				height = 20;
				maxStack = 99;
				value = Item.buyPrice(0, 0, 10, 0);
				return;
			}
			if (type == 1347)
			{
				name = "Explosive Powder";
				width = 12;
				height = 20;
				maxStack = 99;
				value = Item.buyPrice(0, 0, 12, 0);
				return;
			}
			if (type == 1348)
			{
				name = "Gold Dust";
				width = 12;
				height = 20;
				maxStack = 99;
				value = Item.buyPrice(0, 0, 17, 0);
				return;
			}
			if (type == 1349)
			{
				name = "Party Bullet";
				shootSpeed = 5.1f;
				shoot = 284;
				damage = 10;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Bullet;
				knockBack = 5f;
				value = 40;
				ranged = true;
				rare = 3;
				toolTip = "Explodes into confetti on impact";
				return;
			}
			if (type == 1350)
			{
				name = "Nano Bullet";
				shootSpeed = 4.6f;
				shoot = 285;
				damage = 10;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Bullet;
				knockBack = 3.6f;
				value = 40;
				ranged = true;
				rare = 3;
				toolTip = "Causes confusion";
				return;
			}
			if (type == 1351)
			{
				name = "Exploding Bullet";
				shootSpeed = 4.7f;
				shoot = 286;
				damage = 10;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Bullet;
				knockBack = 6.6f;
				value = 40;
				ranged = true;
				rare = 3;
				toolTip = "Explodes on impact";
				return;
			}
			if (type == 1352)
			{
				name = "Golden Bullet";
				shootSpeed = 4.6f;
				shoot = 287;
				damage = 10;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Bullet;
				knockBack = 3.6f;
				value = 40;
				ranged = true;
				rare = 3;
				toolTip = "Enemies killed will drop more money";
				return;
			}
			if (type == 1353)
			{
				name = "Flask of Cursed Flames";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 73;
				buffTime = 72000;
				value = Item.sellPrice(0, 0, 5, 0);
				rare = 4;
				return;
			}
			if (type == 1354)
			{
				name = "Flask of Fire";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 74;
				buffTime = 72000;
				value = Item.sellPrice(0, 0, 5, 0);
				rare = 4;
				return;
			}
			if (type == 1355)
			{
				name = "Flask of Gold";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 75;
				buffTime = 72000;
				value = Item.sellPrice(0, 0, 5, 0);
				rare = 4;
				return;
			}
			if (type == 1356)
			{
				name = "Flask of Ichor";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 76;
				buffTime = 72000;
				value = Item.sellPrice(0, 0, 5, 0);
				rare = 4;
				return;
			}
			if (type == 1357)
			{
				name = "Flask of Nanites";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 77;
				buffTime = 72000;
				value = Item.sellPrice(0, 0, 5, 0);
				rare = 4;
				return;
			}
			if (type == 1358)
			{
				name = "Flask of Party";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 78;
				buffTime = 72000;
				value = Item.sellPrice(0, 0, 5, 0);
				rare = 4;
				return;
			}
			if (type == 1359)
			{
				name = "Flask of Poison";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 79;
				buffTime = 72000;
				value = Item.sellPrice(0, 0, 5, 0);
				rare = 4;
				return;
			}
			if (type == 1360)
			{
				name = "Eye of Cthulhu Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 1, 0, 0);
				placeStyle = 0;
				rare = 1;
				return;
			}
			if (type == 1361)
			{
				name = "Eater of Worlds Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 1, 0, 0);
				placeStyle = 1;
				rare = 1;
				return;
			}
			if (type == 1362)
			{
				name = "Brain of Cthulhu Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 1, 0, 0);
				placeStyle = 2;
				rare = 1;
				return;
			}
			if (type == 1363)
			{
				name = "Skeletron Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 1, 0, 0);
				placeStyle = 3;
				rare = 1;
				return;
			}
			if (type == 1364)
			{
				name = "Queen Bee Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 1, 0, 0);
				placeStyle = 4;
				rare = 1;
				return;
			}
			if (type == 1365)
			{
				name = "Wall of Flesh Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 1, 0, 0);
				placeStyle = 5;
				rare = 1;
				return;
			}
			if (type == 1366)
			{
				name = "Destroyer Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 1, 0, 0);
				placeStyle = 6;
				rare = 1;
				return;
			}
			if (type == 1367)
			{
				name = "Skeletron Prime Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 1, 0, 0);
				placeStyle = 7;
				rare = 1;
				return;
			}
			if (type == 1368)
			{
				name = "Retinazer Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 1, 0, 0);
				placeStyle = 8;
				rare = 1;
				return;
			}
			if (type == 1369)
			{
				name = "Spazmatism Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 1, 0, 0);
				placeStyle = 9;
				rare = 1;
				return;
			}
			if (type == 1370)
			{
				name = "Plantera Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 1, 0, 0);
				placeStyle = 10;
				rare = 1;
				return;
			}
			if (type == 1371)
			{
				name = "Golem Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 1, 0, 0);
				placeStyle = 11;
				rare = 1;
				return;
			}
			if (type == 1372)
			{
				name = "Blood Moon Rising";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 12;
				return;
			}
			if (type == 1373)
			{
				name = "The Hanged Man";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 13;
				return;
			}
			if (type == 1374)
			{
				name = "Glory of the Fire";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 14;
				return;
			}
			if (type == 1375)
			{
				name = "Bone Warp";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 15;
				return;
			}
			if (type == 1376)
			{
				name = "Wall Skeleton";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				placeStyle = 16;
				return;
			}
			if (type == 1377)
			{
				name = "Hanging Skeleton";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				placeStyle = 17;
				return;
			}
			if (type == 1378)
			{
				name = "Blue Slab Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 100;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1379)
			{
				name = "Blue Tiled Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 101;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1380)
			{
				name = "Pink Slab Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 102;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1381)
			{
				name = "Pink Tiled Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 103;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1382)
			{
				name = "Green Slab Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 104;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1383)
			{
				name = "Green Tiled Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 105;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1384)
			{
				name = "Blue Brick Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 19;
				placeStyle = 6;
				width = 8;
				height = 10;
				return;
			}
			if (type == 1385)
			{
				name = "Pink Brick Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 19;
				placeStyle = 7;
				width = 8;
				height = 10;
				return;
			}
			if (type == 1386)
			{
				name = "Green Brick Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 19;
				placeStyle = 8;
				width = 8;
				height = 10;
				return;
			}
			if (type == 1387)
			{
				name = "Dungeon Shelf 1";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 19;
				placeStyle = 9;
				width = 8;
				height = 10;
				return;
			}
			if (type == 1388)
			{
				name = "Dungeon Shelf 2";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 19;
				placeStyle = 10;
				width = 8;
				height = 10;
				return;
			}
			if (type == 1389)
			{
				name = "Dungeon Shelf 3";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 19;
				placeStyle = 11;
				width = 8;
				height = 10;
				return;
			}
			if (type == 1390)
			{
				name = "Lantern 1";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 1;
				return;
			}
			if (type == 1391)
			{
				name = "Lantern 2";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 2;
				return;
			}
			if (type == 1392)
			{
				name = "Lantern 3";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 3;
				return;
			}
			if (type == 1393)
			{
				name = "Lantern 4";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 4;
				return;
			}
			if (type == 1394)
			{
				name = "Lantern 5";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 5;
				return;
			}
			if (type == 1395)
			{
				name = "Lantern 6";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 6;
				return;
			}
			if (type == 1396)
			{
				name = "Blue Dungeon Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 13;
				width = 12;
				height = 30;
				return;
			}
			if (type == 1397)
			{
				name = "Blue Dungeon Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 10;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 1398)
			{
				name = "Blue Dungeon Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 11;
				width = 28;
				height = 14;
				value = 150;
				return;
			}
			if (type == 1399)
			{
				name = "Green Dungeon Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 14;
				width = 12;
				height = 30;
				return;
			}
			if (type == 1400)
			{
				name = "Green Dungeon Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 11;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 1401)
			{
				name = "Green Dungeon Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 12;
				width = 28;
				height = 14;
				value = 150;
				return;
			}
			if (type == 1402)
			{
				name = "Pink Dungeon Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 15;
				width = 12;
				height = 30;
				return;
			}
			if (type == 1403)
			{
				name = "Pink Dungeon Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 12;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 1404)
			{
				name = "Pink Dungeon Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 13;
				width = 28;
				height = 14;
				value = 150;
				return;
			}
			if (type == 1405)
			{
				noWet = true;
				name = "Blue Dungeon Candle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 33;
				width = 8;
				height = 18;
				placeStyle = 1;
				return;
			}
			if (type == 1406)
			{
				noWet = true;
				name = "Green Dungeon Candle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 33;
				width = 8;
				height = 18;
				placeStyle = 2;
				return;
			}
			if (type == 1407)
			{
				noWet = true;
				name = "Pink Dungeon Candle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 33;
				width = 8;
				height = 18;
				placeStyle = 3;
				return;
			}
			if (type == 1408)
			{
				name = "Blue Dungeon Vase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 46;
				return;
			}
			if (type == 1409)
			{
				name = "Green Dungeon Vase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 47;
				return;
			}
			if (type == 1410)
			{
				name = "Pink Dungeon Vase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 48;
				return;
			}
			if (type == 1411)
			{
				name = "Blue Dungeon Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 16;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 1412)
			{
				name = "Green Dungeon Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 17;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 1413)
			{
				name = "Pink Dungeon Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 18;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 1414)
			{
				name = "Blue Dungeon Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 1;
				return;
			}
			if (type == 1415)
			{
				name = "Green Dungeon Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 2;
				return;
			}
			if (type == 1416)
			{
				name = "Pink Dungeon Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 3;
				return;
			}
			if (type == 1417)
			{
				name = "Catacomb";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 241;
				placeStyle = 0;
				width = 30;
				height = 30;
				return;
			}
			if (type == 1418)
			{
				name = "Dungeon Shelf 4";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				placeStyle = 12;
				width = 8;
				height = 10;
				return;
			}
			if (type == 1419)
			{
				name = "Skellington J Skellingsworth";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 18;
				return;
			}
			if (type == 1420)
			{
				name = "The Cursed Man";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 19;
				return;
			}
			if (type == 1421)
			{
				name = "The Eye Sees the End";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 0;
				return;
			}
			if (type == 1422)
			{
				name = "Something Evil is Watching You";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 1;
				return;
			}
			if (type == 1423)
			{
				name = "The Twins Have Awoken";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 2;
				return;
			}
			if (type == 1424)
			{
				name = "The Screamer";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 3;
				return;
			}
			if (type == 1425)
			{
				name = "Goblins Playing Poker";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 4;
				return;
			}
			if (type == 1426)
			{
				name = "Dryadisque";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 5;
				return;
			}
			if (type == 1427)
			{
				name = "Sunflowers";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 20;
				return;
			}
			if (type == 1428)
			{
				name = "Terrarian Gothic";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 21;
				return;
			}
			if (type == 1429)
			{
				name = "Beanie";
				width = 18;
				height = 18;
				headSlot = 100;
				vanity = true;
				value = Item.buyPrice(0, 1, 0, 0);
				return;
			}
			if (type == 1430)
			{
				name = "Imbuing Station";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 243;
				width = 26;
				height = 20;
				value = Item.buyPrice(0, 7, 0, 0);
				rare = 2;
				return;
			}
			if (type == 1431)
			{
				name = "Star in a Bottle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 7;
				return;
			}
			if (type == 1432)
			{
				name = "Empty Bullet";
				width = 12;
				height = 20;
				maxStack = 999;
				value = Item.buyPrice(0, 0, 0, 3);
				return;
			}
			if (type == 1433)
			{
				name = "Impact";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 6;
				return;
			}
			if (type == 1434)
			{
				name = "Powered by Birds";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 7;
				return;
			}
			if (type == 1435)
			{
				name = "The Destroyer";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 8;
				return;
			}
			if (type == 1436)
			{
				name = "The Persistency of Eyes";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 9;
				return;
			}
			if (type == 1437)
			{
				name = "Unicorn Crossing the Hallows";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 10;
				return;
			}
			if (type == 1438)
			{
				name = "Great Wave";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 11;
				return;
			}
			if (type == 1439)
			{
				name = "Starry Night";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 12;
				return;
			}
			if (type == 1440)
			{
				name = "Guide Picasso";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 22;
				return;
			}
			if (type == 1441)
			{
				name = "The Guardian's Gaze";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 23;
				return;
			}
			if (type == 1442)
			{
				name = "Father of Someone";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 24;
				return;
			}
			if (type == 1443)
			{
				name = "Nurse Lisa";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 25;
				return;
			}
			if (type == 1444)
			{
				name = "Shadowbeam Staff";
				mana = 7;

				useStyle = 5;
				damage = 53;
				useAnimation = 16;
				useTime = 16;
				autoReuse = true;
				width = 40;
				height = 40;
				shoot = 294;
				shootSpeed = 6f;
				knockBack = 3.25f;
				value = Item.sellPrice(0, 6, 0, 0);
				magic = true;
				rare = 8;
				noMelee = true;
				return;
			}
			if (type == 1445)
			{
				name = "Inferno Fork";
				mana = 18;

				useStyle = 5;
				damage = 65;
				useAnimation = 30;
				useTime = 30;
				width = 40;
				height = 40;
				shoot = 295;
				shootSpeed = 8f;
				knockBack = 8f;
				value = Item.sellPrice(0, 6, 0, 0);
				magic = true;
				noMelee = true;
				rare = 8;
				return;
			}
			if (type == 1446)
			{
				name = "Spectre Staff";
				mana = 11;

				useStyle = 5;
				damage = 72;
				autoReuse = true;
				useAnimation = 24;
				useTime = 24;
				width = 40;
				height = 40;
				shoot = 297;
				shootSpeed = 6f;
				knockBack = 6f;
				value = Item.sellPrice(0, 6, 0, 0);
				magic = true;
				noMelee = true;
				rare = 8;
				return;
			}
			if (type == 1447)
			{
				name = "Wooden Fence";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 106;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1448)
			{
				name = "Lead Fence";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 107;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1449)
			{
				name = "Bubble Machine";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 244;
				width = 26;
				height = 20;
				value = Item.buyPrice(0, 4, 0, 0);
				rare = 1;
				return;
			}
			if (type == 1450)
			{
				name = "Bubble Wand";
				useStyle = 1;
				autoReuse = true;
				useTurn = false;
				useAnimation = 25;
				useTime = 25;
				width = 24;
				height = 28;
				scale = 1f;
				value = Item.buyPrice(0, 5, 0, 0);
				noMelee = true;
				rare = 1;
				return;
			}
			if (type == 1451)
			{
				name = "Marching Bones Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 10;
				width = 10;
				height = 24;
				value = 1000;
				return;
			}
			if (type == 1452)
			{
				name = "Necromantic Sign";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 11;
				width = 10;
				height = 24;
				value = 1000;
				return;
			}
			if (type == 1453)
			{
				name = "Rusted Company Standard";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 12;
				width = 10;
				height = 24;
				value = 1000;
				return;
			}
			if (type == 1454)
			{
				name = "Ragged Brotherhood Sigil";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 13;
				width = 10;
				height = 24;
				value = 1000;
				return;
			}
			if (type == 1455)
			{
				name = "Molten Legion Flag";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 14;
				width = 10;
				height = 24;
				value = 1000;
				return;
			}
			if (type == 1456)
			{
				name = "Diabolic Sigil";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 15;
				width = 10;
				height = 24;
				value = 1000;
				return;
			}
			if (type == 1457)
			{
				name = "Obsidian Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 19;
				placeStyle = 13;
				width = 8;
				height = 10;
				return;
			}
			if (type == 1458)
			{
				name = "Obsidian Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 19;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 1459)
			{
				name = "Obsidian Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 16;
				width = 12;
				height = 30;
				return;
			}
			if (type == 1460)
			{
				name = "Obsidian Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 13;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 1461)
			{
				name = "Obsidian Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 14;
				width = 28;
				height = 14;
				value = 150;
				return;
			}
			if (type == 1462)
			{
				name = "Obsidian Vase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 49;
				return;
			}
			if (type == 1463)
			{
				name = "Obsidian Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 4;
				return;
			}
			if (type == 1464)
			{
				name = "Hellbound Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 16;
				width = 10;
				height = 24;
				value = 1000;
				return;
			}
			if (type == 1465)
			{
				name = "Hell Hammer Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 17;
				width = 10;
				height = 24;
				value = 1000;
				return;
			}
			if (type == 1466)
			{
				name = "Helltower Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 18;
				width = 10;
				height = 24;
				value = 1000;
				return;
			}
			if (type == 1467)
			{
				name = "Lost Hopes of Man Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 19;
				width = 10;
				height = 24;
				value = 1000;
				return;
			}
			if (type == 1468)
			{
				name = "Obsidian Watcher Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 20;
				width = 10;
				height = 24;
				value = 1000;
				return;
			}
			if (type == 1469)
			{
				name = "Lava Erupts Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 21;
				width = 10;
				height = 24;
				value = 1000;
				return;
			}
			if (type == 1470)
			{
				name = "Blue Dungeon Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 5;
				width = 28;
				height = 20;
				value = 2000;
				return;
			}
			if (type == 1471)
			{
				name = "Green Dungeon Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 6;
				width = 28;
				height = 20;
				value = 2000;
				return;
			}
			if (type == 1472)
			{
				name = "Red Dungeon Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 7;
				width = 28;
				height = 20;
				value = 2000;
				return;
			}
			if (type == 1473)
			{
				name = "Obsidian Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 8;
				width = 28;
				height = 20;
				value = 2000;
				return;
			}
			if (type >= 1474 && type <= 1478)
			{
				name = "Picture";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 245;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = type - 1474;
				return;
			}
			if (type >= 1479 && type <= 1494)
			{
				name = "Picture";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 246;
				width = 30;
				height = 30;
				if (type >= 1481 && type <= 1494)
				{
					value = Item.buyPrice(0, 1, 0, 0);
				}
				else
				{
					value = Item.sellPrice(0, 0, 10, 0);
				}
				placeStyle = type - 1479;
				return;
			}
			if (type == 1495)
			{
				name = "American Explosive";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 245;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 5;
				return;
			}
			if (type >= 1496 && type <= 1499)
			{
				name = "Picture";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 26 + type - 1496;
				return;
			}
			if (type >= 1500 && type <= 1502)
			{
				name = "Picture";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 13 + type - 1500;
				return;
			}
			if (type == 1503)
			{
				name = "Spectre Hood";
				width = 18;
				height = 18;
				defense = 6;
				headSlot = 101;
				rare = 8;
				value = 375000;
				toolTip = "40% decreased magic damage";
				return;
			}
			if (type == 1504)
			{
				name = "Spectre Robe";
				width = 18;
				height = 18;
				defense = 14;
				bodySlot = 66;
				rare = 8;
				value = 300000;
				toolTip = "7% increased magic damage and critical strike chance";
				return;
			}
			if (type == 1505)
			{
				name = "Spectre Pants";
				width = 18;
				height = 18;
				defense = 10;
				legSlot = 55;
				rare = 8;
				value = 225000;
				toolTip = "8% increased magic damage";
				toolTip2 = "8% increased movement speed";
				return;
			}
			if (type == 1506)
			{
				name = "Spirit Pickaxe";
				useStyle = 1;
				useAnimation = 24;
				useTime = 10;
				knockBack = 5.25f;
				useTurn = true;
				autoReuse = true;
				width = 20;
				height = 12;
				damage = 32;
				pick = 200;

				rare = 8;
				value = 216000;
				melee = true;
				scale = 1.15f;
				tileBoost += 3;
				return;
			}
			if (type == 1507)
			{
				name = "Spirit Hamaxe";
				useTurn = true;
				autoReuse = true;
				useStyle = 1;
				useAnimation = 28;
				useTime = 8;
				knockBack = 7f;
				width = 20;
				height = 12;
				damage = 60;
				axe = 30;
				hammer = 90;

				rare = 8;
				value = 216000;
				melee = true;
				scale = 1.05f;
				tileBoost += 3;
				return;
			}
			if (type == 1508)
			{
				name = "Ectoplasm";
				maxStack = 99;
				width = 16;
				height = 14;
				value = Item.sellPrice(0, 0, 50, 0);
				rare = 8;
				return;
			}
			if (type == 1509)
			{
				name = "Gothic Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 17;
				width = 12;
				height = 30;
				return;
			}
			if (type == 1510)
			{
				name = "Gothic Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 14;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 1511)
			{
				name = "Gothic Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 15;
				width = 28;
				height = 14;
				value = 150;
				return;
			}
			if (type == 1512)
			{
				name = "Gothic Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 5;
				return;
			}
			if (type == 1513)
			{
				noMelee = true;
				useStyle = 1;
				name = "Paladin's Hammer";
				shootSpeed = 14f;
				shoot = 301;
				damage = 90;
				knockBack = 9f;
				width = 14;
				height = 28;

				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				rare = 8;
				value = Item.sellPrice(0, 10, 0, 0);
				melee = true;
				return;
			}
			if (type == 1514)
			{
				name = "SWAT Helmet";
				width = 18;
				height = 18;
				headSlot = 102;
				rare = 1;
				value = Item.sellPrice(0, 1, 0, 0);
				vanity = true;
				return;
			}
			if (type == 1515)
			{
				name = "Bee Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 15;
				return;
			}
			if (type >= 1516 && type <= 1521)
			{
				name = "Feather";
				maxStack = 99;
				width = 16;
				height = 14;
				value = Item.sellPrice(0, 2, 50, 0);
				rare = 5;
				return;
			}
			if (type >= 1522 && type <= 1527)
			{
				name = "Large Gem";
				width = 20;
				height = 20;
				rare = 1;
				return;
			}
			if (type >= 1528 && type <= 1532)
			{
				name = "Dungeon Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 18 + type - 1528;
				width = 26;
				height = 22;
				value = 2500;
				return;
			}
			if (type >= 1533 && type <= 1537)
			{
				name = "Dungeon Key";
				width = 14;
				height = 20;
				maxStack = 99;
				rare = 8;
				return;
			}
			if (type >= 1538 && type <= 1540)
			{
				name = "Picture";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 30 + type - 1538;
				return;
			}
			if (type >= 1541 && type <= 1542)
			{
				name = "Picture";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 246;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 16 + type - 1541;
				return;
			}
			if (type >= 1543 && type <= 1545)
			{
				name = "Spectre Paintbrush";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				width = 24;
				height = 24;
				value = 10000;
				tileBoost += 3;
				return;
			}
			if (type == 1546)
			{
				name = "Shroomite Headgear";
				width = 18;
				height = 18;
				defense = 11;
				headSlot = 103;
				rare = 8;
				value = 375000;
				toolTip = "15% increased arrow damage";
				toolTip2 = "5% ranged critical strike chance";
				return;
			}
			if (type == 1547)
			{
				name = "Shroomite Mask";
				width = 18;
				height = 18;
				defense = 11;
				headSlot = 104;
				rare = 8;
				value = 375000;
				toolTip = "15% increased bullet damage";
				toolTip2 = "5% ranged critical strike chance";
				return;
			}
			if (type == 1548)
			{
				name = "Shroomite Helmet";
				width = 18;
				height = 18;
				defense = 11;
				headSlot = 105;
				rare = 8;
				value = 375000;
				toolTip = "15% increased rocket damage";
				toolTip2 = "5% ranged critical strike chance";
				return;
			}
			if (type == 1549)
			{
				name = "Shroomite Breastplate";
				width = 18;
				height = 18;
				defense = 24;
				bodySlot = 67;
				rare = 8;
				value = 300000;
				toolTip = "13% increased ranged critical strike chance";
				toolTip2 = "20% chance to not consume ammo";
				return;
			}
			if (type == 1550)
			{
				name = "Shroomite Leggings";
				width = 18;
				height = 18;
				defense = 16;
				legSlot = 56;
				rare = 8;
				value = 225000;
				toolTip = "7% increased ranged critical strike chance";
				toolTip2 = "12% increased movement speed";
				return;
			}
			if (type == 1551)
			{
				name = "Autohammer";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 247;
				width = 26;
				height = 24;
				value = Item.buyPrice(1, 0, 0, 0);
				toolTip = "Converts Chlorophyte Bars into Shroomite Bars";
				return;
			}
			if (type == 1552)
			{
				name = "Shroomite Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				rare = 7;
				value = Item.sellPrice(0, 1, 0, 0);
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 20;
				return;
			}
			if (type == 1553)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 5;
				useTime = 5;
				name = "S.D.M.G.";
				crit += 10;
				width = 60;
				height = 26;
				shoot = 10;
				useAmmo = AmmoID.Bullet;

				damage = 77;
				shootSpeed = 12f;
				noMelee = true;
				value = 750000;
				rare = 10;
				toolTip = "50% chance to not consume ammo";
				toolTip2 = "'Space Dolphin Machine Gun'";
				knockBack = 2.5f;
				ranged = true;
				return;
			}
			if (type == 1554)
			{
				name = "Cenx's Tiara";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				headSlot = 106;
				return;
			}
			if (type == 1555)
			{
				name = "Cenx's Breastplate";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				bodySlot = 68;
				return;
			}
			if (type == 1556)
			{
				name = "Cenx's Leggings";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				legSlot = 57;
				return;
			}
			if (type == 1557)
			{
				name = "Crowno's Mask";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				headSlot = 107;
				return;
			}
			if (type == 1558)
			{
				name = "Crowno's Breastplate";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				bodySlot = 69;
				return;
			}
			if (type == 1559)
			{
				name = "Crowno's Leggings";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				legSlot = 58;
				return;
			}
			if (type == 1560)
			{
				name = "Will's Helmet";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				headSlot = 108;
				return;
			}
			if (type == 1561)
			{
				name = "Will's Breastplate";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				bodySlot = 70;
				return;
			}
			if (type == 1562)
			{
				name = "Will's Leggings";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				legSlot = 59;
				return;
			}
			if (type == 1563)
			{
				name = "Jim's Helmet";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				headSlot = 109;
				return;
			}
			if (type == 1564)
			{
				name = "Jim's Breastplate";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				bodySlot = 71;
				return;
			}
			if (type == 1565)
			{
				name = "Jim's Leggings";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				legSlot = 60;
				return;
			}
			if (type == 1566)
			{
				name = "Aaron's Helmet";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				headSlot = 110;
				return;
			}
			if (type == 1567)
			{
				name = "Aaron's Breastplate";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				bodySlot = 72;
				return;
			}
			if (type == 1568)
			{
				name = "Aaron's Leggings";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				legSlot = 61;
				return;
			}
			if (type == 1569)
			{
				autoReuse = true;
				useStyle = 1;
				name = "Vampire Knives";
				shootSpeed = 15f;
				shoot = 304;
				damage = 29;
				width = 18;
				height = 20;

				useAnimation = 16;
				useTime = 16;
				noUseGraphic = true;
				noMelee = true;
				value = Item.sellPrice(0, 20, 0, 0);
				knockBack = 2.75f;
				melee = true;
				rare = 8;
				toolTip = "Rapidly shoot life stealing daggers";
				return;
			}
			if (type == 1570)
			{
				name = "Broken Hero Sword";
				width = 14;
				height = 18;
				maxStack = 99;
				rare = 8;
				value = Item.sellPrice(0, 2, 0, 0);
				return;
			}
			if (type == 1571)
			{
				autoReuse = true;
				useStyle = 5;
				name = "Eater's Bite";
				shootSpeed = 14f;
				shoot = 306;
				damage = 64;
				width = 18;
				height = 20;

				useAnimation = 20;
				useTime = 20;
				noUseGraphic = true;
				noMelee = true;
				value = Item.sellPrice(0, 20, 0, 0);
				knockBack = 5f;
				melee = true;
				rare = 8;
				return;
			}
			if (type == 1572)
			{
				name = "Hydra Staff";
				useStyle = 1;
				shootSpeed = 14f;
				shoot = 308;
				damage = 100;
				width = 18;
				height = 20;

				useAnimation = 30;
				useTime = 30;
				noMelee = true;
				value = Item.sellPrice(0, 20, 0, 0);
				knockBack = 7.5f;
				rare = 8;
				summon = true;
				mana = 20;
				sentry = true;
				return;
			}
			if (type == 1573)
			{
				name = "The Creation of the Guide";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 16;
				return;
			}
			if (type >= 1574 && type <= 1576)
			{
				name = "Picture";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 33 + type - 1574;
				return;
			}
			if (type == 1577)
			{
				name = "Glorious Night";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 245;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 6;
				return;
			}
			if (type == 1578)
			{
				name = "Sweetheart Necklace";
				width = 22;
				height = 22;
				accessory = true;
				rare = 3;
				toolTip = "Releases bees and increases movement speed when damaged";
				value = 100000;
				neckSlot = 6;
				return;
			}
			if (type == 1579)
			{
				name = "Flurry Boots";
				width = 28;
				height = 24;
				accessory = true;
				rare = 1;
				toolTip = "The wearer can run super fast";
				value = 50000;
				shoeSlot = 5;
				return;
			}
			if (type == 1580)
			{
				name = "D-Town's Helmet";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				headSlot = 111;
				return;
			}
			if (type == 1581)
			{
				name = "D-Town's Breastplate";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				bodySlot = 73;
				return;
			}
			if (type == 1582)
			{
				name = "D-Town's Leggings";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				legSlot = 62;
				return;
			}
			if (type == 1583)
			{
				name = "D-Town's Wings";
				width = 24;
				height = 8;
				accessory = true;
				rare = 9;
				wingSlot = 16;
				value = 400000;
				return;
			}
			if (type == 1584)
			{
				name = "Will's Wings";
				width = 24;
				height = 8;
				accessory = true;
				rare = 9;
				wingSlot = 17;
				value = 400000;
				return;
			}
			if (type == 1585)
			{
				name = "Crowno's Wings";
				width = 24;
				height = 8;
				accessory = true;
				rare = 9;
				wingSlot = 18;
				value = 400000;
				return;
			}
			if (type == 1586)
			{
				name = "Cenx's Wings";
				width = 24;
				height = 8;
				accessory = true;
				rare = 9;
				wingSlot = 19;
				value = 400000;
				return;
			}
			if (type == 1587)
			{
				name = "Cenx's Dress";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				bodySlot = 74;
				return;
			}
			if (type == 1588)
			{
				name = "Cenx's Dress Pants";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				legSlot = 63;
				return;
			}
			if (type == 1589)
			{
				name = "Palladium Column";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 248;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1590)
			{
				name = "Palladium Column Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 109;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1591)
			{
				name = "Bubblegum Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 249;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1592)
			{
				name = "Bubblegum Block Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 110;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1593)
			{
				name = "Titanstone Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 250;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1594)
			{
				name = "Titanstone Block Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 111;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1595)
			{
				name = "Magic Cuffs";
				width = 22;
				height = 22;
				accessory = true;
				rare = 2;
				toolTip = "Increases maximum mana by 20";
				toolTip2 = "Restores mana when damaged";
				value = 100000;
				handOffSlot = 3;
				handOnSlot = 8;
				return;
			}
			if (type >= 1596 && type <= 1610)
			{
				name = "Music Box";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = type - 1596 + 13;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 1611)
			{
				name = "Butterfly Dust";
				maxStack = 99;
				width = 16;
				height = 14;
				value = Item.sellPrice(0, 2, 50, 0);
				rare = 5;
				return;
			}
			if (type == 1612)
			{
				name = "Ankh Charm";
				width = 16;
				height = 24;
				accessory = true;
				rare = 6;
				toolTip = "Grants immunity to most debuffs";
				value = Item.sellPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1613)
			{
				name = "Ankh Shield";
				width = 24;
				height = 28;
				rare = 7;
				value = Item.sellPrice(0, 5, 0, 0);
				accessory = true;
				defense = 4;
				toolTip = "Grants immunity to knockback and fire blocks";
				toolTip2 = "Grants immunity to most debuffs";
				shieldSlot = 4;
				return;
			}
			if (type == 1614)
			{
				name = "Blue Flare";
				shootSpeed = 6f;
				shoot = 310;
				damage = 1;
				width = 12;
				height = 12;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Flare;
				knockBack = 1.5f;
				value = 7;
				ranged = true;
				return;
			}
			if (type >= 1615 && type <= 1701)
			{
				name = "Monster Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 22 + type - 1615;
				width = 10;
				height = 24;
				value = 1000;
				rare = 1;
				return;
			}
			if (type == 1702)
			{
				name = "Glass Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 19;
				placeStyle = 14;
				width = 8;
				height = 10;
				return;
			}
			if (type >= 1703 && type <= 1708)
			{
				name = "Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 18 + type - 1703;
				width = 12;
				height = 30;
				return;
			}
			if (type >= 1709 && type <= 1712)
			{
				name = "Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 20 + type - 1709;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type >= 1713 && type <= 1718)
			{
				name = "Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 15 + type - 1713;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type >= 1719 && type <= 1722)
			{
				name = "Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 9 + type - 1719;
				width = 28;
				height = 20;
				value = 2000;
				return;
			}
			if (type == 1723)
			{
				name = "Living Wood Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 78;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1724)
			{
				name = "Fart in a Jar";
				width = 16;
				height = 24;
				accessory = true;
				rare = 2;
				toolTip = "Allows the holder to double jump";
				value = 75000;
				return;
			}
			if (type == 1725)
			{
				name = "Pumpkin";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 251;
				width = 8;
				height = 10;
				value = Item.sellPrice(0, 0, 0, 25);
				return;
			}
			if (type == 1726)
			{
				name = "Pumpkin Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 113;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1727)
			{
				name = "Hay";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 252;
				width = 8;
				height = 10;
				return;
			}
			if (type == 1728)
			{
				name = "Hay Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 114;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1729)
			{
				name = "Spooky Wood";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 253;
				width = 8;
				height = 10;
				return;
			}
			if (type == 1730)
			{
				name = "Spooky Wood Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 115;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1731)
			{
				name = "Pumpkin Helmet";
				width = 18;
				height = 18;
				defense = 2;
				headSlot = 112;
				return;
			}
			if (type == 1732)
			{
				name = "Pumpkin Breastplate";
				width = 18;
				height = 18;
				defense = 3;
				bodySlot = 75;
				return;
			}
			if (type == 1733)
			{
				name = "Pumpkin Leggings";
				width = 18;
				height = 18;
				defense = 2;
				legSlot = 64;
				return;
			}
			if (type == 1734)
			{
				name = "Candy Apple";
				width = 12;
				height = 12;
				return;
			}
			if (type == 1735)
			{
				name = "Soul Cake";
				width = 12;
				height = 12;
				return;
			}
			if (type == 1736)
			{
				name = "Nurse Hat";
				width = 18;
				height = 18;
				headSlot = 113;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1737)
			{
				name = "Nurse Shirt";
				width = 18;
				height = 18;
				bodySlot = 76;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1738)
			{
				name = "Nurse Pants";
				width = 18;
				height = 18;
				legSlot = 65;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1739)
			{
				name = "Wizard's Hat";
				width = 18;
				height = 18;
				headSlot = 114;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1740)
			{
				name = "Guy Fawkes Mask";
				width = 18;
				height = 18;
				headSlot = 115;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1741)
			{
				name = "Dye Trader Robe";
				width = 18;
				height = 18;
				bodySlot = 77;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1742)
			{
				name = "Steampunk Goggles";
				width = 18;
				height = 18;
				headSlot = 116;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1743)
			{
				name = "Cyborg Helmet";
				width = 18;
				height = 18;
				headSlot = 117;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1744)
			{
				name = "Cyborg Shirt";
				width = 18;
				height = 18;
				bodySlot = 78;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1745)
			{
				name = "Cyborg Pants";
				width = 18;
				height = 18;
				legSlot = 66;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1746)
			{
				name = "Creeper Mask";
				width = 18;
				height = 18;
				headSlot = 118;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1747)
			{
				name = "Creeper Shirt";
				width = 18;
				height = 18;
				bodySlot = 79;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1748)
			{
				name = "Creeper Pants";
				width = 18;
				height = 18;
				legSlot = 67;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1749)
			{
				name = "Cat Mask";
				width = 18;
				height = 18;
				headSlot = 119;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1750)
			{
				name = "Cat Shirt";
				width = 18;
				height = 18;
				bodySlot = 80;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1751)
			{
				name = "Cat Pants";
				width = 18;
				height = 18;
				legSlot = 68;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1752)
			{
				name = "Ghost Mask";
				width = 18;
				height = 18;
				headSlot = 120;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1753)
			{
				name = "Ghost Shirt";
				width = 18;
				height = 18;
				bodySlot = 81;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1754)
			{
				name = "Pumpkin Mask";
				width = 18;
				height = 18;
				headSlot = 121;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1755)
			{
				name = "Pumpkin Shirt";
				width = 18;
				height = 18;
				bodySlot = 82;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1756)
			{
				name = "Pumpkin Pants";
				width = 18;
				height = 18;
				legSlot = 69;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1757)
			{
				name = "Robot Mask";
				width = 18;
				height = 18;
				headSlot = 122;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1758)
			{
				name = "Robot Shirt";
				width = 18;
				height = 18;
				bodySlot = 83;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1759)
			{
				name = "Robot Pants";
				width = 18;
				height = 18;
				legSlot = 70;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1760)
			{
				name = "Unicorn Mask";
				width = 18;
				height = 18;
				headSlot = 123;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1761)
			{
				name = "Unicorn Shirt";
				width = 18;
				height = 18;
				bodySlot = 84;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1762)
			{
				name = "Unicorn Pants";
				width = 18;
				height = 18;
				legSlot = 71;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1763)
			{
				name = "Vampire Mask";
				width = 18;
				height = 18;
				headSlot = 124;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1764)
			{
				name = "Vampire Shirt";
				width = 18;
				height = 18;
				bodySlot = 85;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1765)
			{
				name = "Vampire Pants";
				width = 18;
				height = 18;
				legSlot = 72;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1766)
			{
				name = "Witch Hat";
				width = 18;
				height = 18;
				headSlot = 125;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1767)
			{
				name = "Leprechaun Hat";
				width = 18;
				height = 18;
				headSlot = 126;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1768)
			{
				name = "Leprechaun Shirt";
				width = 18;
				height = 18;
				bodySlot = 86;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1769)
			{
				name = "Leprechaun Pants";
				width = 18;
				height = 18;
				legSlot = 73;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1770)
			{
				name = "Pixie Shirt";
				width = 18;
				height = 18;
				bodySlot = 87;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1771)
			{
				name = "Pixie Pants";
				width = 18;
				height = 18;
				legSlot = 74;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1772)
			{
				name = "Princess Hat";
				width = 18;
				height = 18;
				headSlot = 127;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1773)
			{
				name = "Princess Dress";
				width = 18;
				height = 18;
				bodySlot = 88;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1774)
			{
				name = "Goodie Bag";
				width = 12;
				height = 12;
				rare = 3;
				toolTip = "Right click to open";
				maxStack = 99;
				value = Item.sellPrice(0, 1, 0, 0);
				return;
			}
			if (type == 1775)
			{
				name = "Witch Dress";
				width = 18;
				height = 18;
				bodySlot = 89;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1776)
			{
				name = "Witch Boots";
				width = 18;
				height = 18;
				legSlot = 75;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1777)
			{
				name = "Bride of Frankenstein Mask";
				width = 18;
				height = 18;
				headSlot = 128;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1778)
			{
				name = "Bride of Frankenstein Dress";
				width = 18;
				height = 18;
				bodySlot = 90;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1779)
			{
				name = "Karate Tortoise Mask";
				width = 18;
				height = 18;
				headSlot = 129;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1780)
			{
				name = "Karate Tortoise Shirt";
				width = 18;
				height = 18;
				bodySlot = 91;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1781)
			{
				name = "Karate Tortoise Pants";
				width = 18;
				height = 18;
				legSlot = 76;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1782)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 9;
				useTime = 9;
				name = "Candy Corn Rifle";
				crit += 6;
				width = 60;
				height = 26;
				shoot = 311;
				useAmmo = AmmoID.CandyCorn;

				damage = 44;
				shootSpeed = 10f;
				noMelee = true;
				value = 750000;
				rare = 8;
				knockBack = 2f;
				ranged = true;
				return;
			}
			if (type == 1783)
			{
				name = "Candy Corn";
				shootSpeed = 4f;
				shoot = 311;
				damage = 9;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.CandyCorn;
				knockBack = 1.5f;
				value = 5;
				ranged = true;
				return;
			}
			if (type == 1784)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 30;
				useTime = 30;
				name = "Jack 'O Lantern Launcher";
				crit += 6;
				width = 60;
				height = 26;
				shoot = 312;
				useAmmo = AmmoID.JackOLantern;

				damage = 65;
				shootSpeed = 7f;
				noMelee = true;
				value = 750000;
				rare = 8;
				knockBack = 5f;
				ranged = true;
				return;
			}
			if (type == 1785)
			{
				name = "Explosive Jack 'O Lantern";
				shootSpeed = 4f;
				shoot = 312;
				damage = 30;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.JackOLantern;
				knockBack = 3f;
				value = 15;
				ranged = true;
				return;
			}
			if (type == 1786)
			{
				name = "Sickle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 24;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 9;

				knockBack = 2.25f;
				value = Item.buyPrice(0, 0, 60, 0);
				melee = true;
				return;
			}
			if (type == 1787)
			{
				name = "Pumpkin Pie";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 10;
				height = 10;
				buffType = 26;
				buffTime = 162000;
				rare = 1;
				toolTip = "Minor improvements to all stats";
				value = 1000;
				return;
			}
			if (type == 1788)
			{
				name = "Scarecrow Hat";
				width = 18;
				height = 18;
				headSlot = 130;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1789)
			{
				name = "Scarecrow Shirt";
				width = 18;
				height = 18;
				bodySlot = 92;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1790)
			{
				name = "Scarecrow Pants";
				width = 18;
				height = 18;
				legSlot = 77;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1791)
			{
				name = "Cauldron";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 96;
				placeStyle = 1;
				width = 20;
				height = 20;
				value = Item.buyPrice(0, 1, 50, 0);
				return;
			}
			if (type == 1792)
			{
				name = "Pumpkin Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 24;
				width = 12;
				height = 30;
				return;
			}
			if (type == 1793)
			{
				name = "Pumpkin Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 24;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 1794)
			{
				name = "Pumpkin Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 21;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 1795)
			{
				name = "Pumpkin Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 16;
				width = 28;
				height = 14;
				value = 150;
				return;
			}
			if (type == 1796)
			{
				name = "Pumpkin Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 19;
				placeStyle = 15;
				width = 8;
				height = 10;
				return;
			}
			if (type == 1797)
			{
				name = "Tattered Fairy Wings";
				width = 24;
				height = 8;
				accessory = true;
				rare = 7;
				value = 400000;
				wingSlot = 20;
				return;
			}
			if (type == 1798)
			{
				damage = 0;
				useStyle = 1;
				name = "Spider Egg";
				shoot = 313;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a pet spider";
				buffType = 81;
				value = Item.sellPrice(0, 2, 0, 0);
				return;
			}
			if (type == 1799)
			{
				damage = 0;
				useStyle = 1;
				name = "Magical Pumpkin Seed";
				shoot = 314;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a squashling";
				buffType = 82;
				value = Item.sellPrice(0, 2, 0, 0);
				return;
			}
			if (type == 1800)
			{
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Bat Hook";
				shootSpeed = 15.5f;
				shoot = 315;
				width = 18;
				height = 28;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				value = Item.sellPrice(0, 2, 0, 0);
				return;
			}
			if (type == 1801)
			{
				name = "Bat Scepter";
				useStyle = 5;
				autoReuse = true;
				useAnimation = 12;
				useTime = 12;
				mana = 3;
				width = 50;
				height = 18;
				shoot = 316;

				damage = 45;
				shootSpeed = 10f;
				noMelee = true;
				value = 500000;
				rare = 8;
				magic = true;
				knockBack = 3f;
				return;
			}
			if (type == 1802)
			{
				mana = 10;
				damage = 37;
				useStyle = 1;
				name = "Raven Staff";
				shootSpeed = 10f;
				shoot = 317;
				width = 26;
				height = 28;

				useAnimation = 28;
				useTime = 28;
				rare = 8;
				noMelee = true;
				knockBack = 3f;
				toolTip = "Summons a raven to fight for you";
				buffType = 83;
				value = 100000;
				summon = true;
				return;
			}
			if (type >= 1803 && type <= 1807)
			{
				return;
			}
			if (type == 1808)
			{
				name = "Hanging Jack 'O Lantern";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 8;
				return;
			}
			if (type == 1809)
			{
				useStyle = 1;
				name = "Rotten Egg";
				shootSpeed = 9f;
				shoot = 318;
				damage = 13;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;

				useAnimation = 19;
				useTime = 19;
				noUseGraphic = true;
				noMelee = true;
				thrown = true;
				knockBack = 6.5f;
				return;
			}
			if (type == 1810)
			{
				damage = 0;
				useStyle = 1;
				name = "Unlucky Yarn";
				shoot = 319;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				buffType = 84;
				value = Item.sellPrice(0, 2, 0, 0);
				return;
			}
			if (type == 1811)
			{
				name = "Black Fairy Dust";
				maxStack = 99;
				width = 16;
				height = 14;
				value = Item.sellPrice(0, 2, 50, 0);
				rare = 5;
				return;
			}
			if (type == 1812)
			{
				name = "Jackelier";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 34;
				placeStyle = 6;
				width = 26;
				height = 26;
				return;
			}
			if (type == 1813)
			{
				name = "Jack 'O Lantern";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 35;
				width = 26;
				height = 26;
				return;
			}
			if (type == 1814)
			{
				name = "Spooky Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 25;
				width = 12;
				height = 30;
				return;
			}
			if (type == 1815)
			{
				name = "Spooky Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 25;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 1816)
			{
				name = "Spooky Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 22;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 1817)
			{
				name = "Spooky Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 17;
				width = 28;
				height = 14;
				value = 150;
				return;
			}
			if (type == 1818)
			{
				name = "Spooky Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 19;
				placeStyle = 16;
				width = 8;
				height = 10;
				return;
			}
			if (type == 1819)
			{
				name = "Reaper Mask";
				width = 18;
				height = 18;
				headSlot = 131;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1820)
			{
				name = "Reaper Robe";
				width = 18;
				height = 18;
				bodySlot = 93;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1821)
			{
				name = "Fox Mask";
				width = 18;
				height = 18;
				headSlot = 132;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1822)
			{
				name = "Fox Shirt";
				width = 18;
				height = 18;
				bodySlot = 94;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1823)
			{
				name = "Fox Pants";
				width = 18;
				height = 18;
				legSlot = 78;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1824)
			{
				name = "Cat Ears";
				width = 18;
				height = 18;
				headSlot = 133;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1825)
			{
				noMelee = true;
				useStyle = 1;
				name = "Bloody Machete";
				shootSpeed = 15f;
				shoot = 320;
				damage = 15;
				knockBack = 5f;
				width = 34;
				height = 34;

				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				rare = 2;
				value = 50000;
				melee = true;
				return;
			}
			if (type == 1826)
			{
				autoReuse = true;
				name = "Horseman's Blade";
				useStyle = 1;
				useAnimation = 26;
				knockBack = 7.5f;
				width = 40;
				height = 40;
				damage = 75;
				scale = 1.15f;

				rare = 8;
				value = Item.sellPrice(0, 10, 0, 0);
				melee = true;
				return;
			}
			if (type == 1827)
			{
				name = "Bladed Glove";
				useStyle = 1;
				useTurn = true;
				autoReuse = true;
				useAnimation = 8;
				useTime = 8;
				width = 24;
				height = 28;
				damage = 12;
				knockBack = 4f;

				scale = 1.35f;
				melee = true;
				rare = 2;
				value = 50000;
				melee = true;
				return;
			}
			if (type == 1828)
			{
				autoReuse = true;
				name = "Pumpkin Seed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 254;
				width = 8;
				height = 10;
				value = Item.buyPrice(0, 0, 2, 50);
				return;
			}
			if (type == 1829)
			{
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Spooky Hook";
				shootSpeed = 15.5f;
				shoot = 322;
				width = 18;
				height = 28;

				useAnimation = 20;
				useTime = 20;
				rare = 7;
				noMelee = true;
				value = Item.sellPrice(0, 4, 0, 0);
				return;
			}
			if (type == 1830)
			{
				name = "Spooky Wings";
				width = 24;
				height = 8;
				accessory = true;
				rare = 7;
				value = 400000;
				wingSlot = 21;
				return;
			}
			if (type == 1831)
			{
				name = "Spooky Twig";
				maxStack = 99;
				width = 16;
				height = 14;
				value = Item.sellPrice(0, 2, 50, 0);
				rare = 5;
				return;
			}
			if (type == 1832)
			{
				name = "Spooky Helmet";
				width = 18;
				height = 18;
				headSlot = 134;
				value = Item.sellPrice(0, 1, 0, 0);
				defense = 8;
				rare = 8;
				toolTip = "Increases your max number of minions";
				toolTip2 = "Increases minion damage by 11%";
				return;
			}
			if (type == 1833)
			{
				name = "Spooky Breastplate";
				width = 18;
				height = 18;
				bodySlot = 95;
				value = Item.sellPrice(0, 1, 0, 0);
				defense = 10;
				rare = 8;
				toolTip = "Increases your max number of minions";
				toolTip2 = "Increases minion damage by 11%";
				return;
			}
			if (type == 1834)
			{
				name = "Spooky Leggings";
				width = 18;
				height = 18;
				legSlot = 79;
				value = Item.sellPrice(0, 1, 0, 0);
				defense = 9;
				rare = 8;
				toolTip = "Increases your max number of minions";
				toolTip2 = "Increases minion damage by 11%";
				return;
			}
			if (type == 1835)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 26;
				useTime = 26;
				name = "Stake Launcher";
				crit += 10;
				width = 40;
				height = 26;
				shoot = 323;
				useAmmo = AmmoID.Stake;

				damage = 75;
				shootSpeed = 9f;
				noMelee = true;
				value = 750000;
				rare = 8;
				knockBack = 6.5f;
				ranged = true;
				return;
			}
			if (type == 1836)
			{
				name = "Stake";
				shootSpeed = 3f;
				shoot = 323;
				damage = 25;
				width = 20;
				height = 14;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Stake;
				knockBack = 4.5f;
				value = 15;
				ranged = true;
				return;
			}
			if (type == 1837)
			{
				useStyle = 1;
				name = "Cursed Sapling";
				shoot = 324;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				buffType = 85;
				value = Item.sellPrice(0, 2, 0, 0);
				return;
			}
			if (type == 1838)
			{
				name = "Space Creature Mask";
				width = 18;
				height = 18;
				headSlot = 135;
				value = Item.buyPrice(0, 3, 0, 0);
				vanity = true;
				return;
			}
			if (type == 1839)
			{
				name = "Space Creature Shirt";
				width = 18;
				height = 18;
				bodySlot = 96;
				value = Item.buyPrice(0, 3, 0, 0);
				vanity = true;
				return;
			}
			if (type == 1840)
			{
				name = "Space Creature Pants";
				width = 18;
				height = 18;
				legSlot = 80;
				value = Item.buyPrice(0, 3, 0, 0);
				vanity = true;
				return;
			}
			if (type == 1841)
			{
				name = "Wolf Mask";
				width = 18;
				height = 18;
				headSlot = 136;
				value = Item.buyPrice(0, 3, 0, 0);
				vanity = true;
				return;
			}
			if (type == 1842)
			{
				name = "Wolf Shirt";
				width = 18;
				height = 18;
				bodySlot = 97;
				value = Item.buyPrice(0, 3, 0, 0);
				vanity = true;
				return;
			}
			if (type == 1843)
			{
				name = "Wolf Pants";
				width = 18;
				height = 18;
				legSlot = 81;
				value = Item.buyPrice(0, 3, 0, 0);
				vanity = true;
				return;
			}
			if (type == 1844)
			{
				useStyle = 4;
				name = "Pumpkin Moon Medallion";
				width = 22;
				height = 14;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				maxStack = 20;
				toolTip = "Summons the Pumpkin Moon";
				rare = 8;
				return;
			}
			if (type == 1845)
			{
				name = "Necromantic Scroll";
				rare = 8;
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Increases your max number of minions";
				toolTip2 = "Increases minion damage by 10%";
				value = Item.buyPrice(0, 20, 0, 0);
				return;
			}
			if (type >= 1846 && type <= 1850)
			{
				name = "Large Painting";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 17 + type - 1846;
				return;
			}
			if (type == 1851)
			{
				name = "Treasure Hunter Shirt";
				width = 18;
				height = 18;
				bodySlot = 98;
				value = Item.buyPrice(0, 3, 0, 0);
				vanity = true;
				return;
			}
			if (type == 1852)
			{
				name = "Treasure Hunter Pants";
				width = 18;
				height = 18;
				legSlot = 82;
				value = Item.buyPrice(0, 3, 0, 0);
				vanity = true;
				return;
			}
			if (type == 1853)
			{
				name = "Dryad Coverings";
				width = 18;
				height = 18;
				bodySlot = 99;
				value = Item.buyPrice(0, 3, 0, 0);
				vanity = true;
				return;
			}
			if (type == 1854)
			{
				name = "Dryad Loincloth";
				width = 18;
				height = 18;
				legSlot = 83;
				value = Item.buyPrice(0, 3, 0, 0);
				vanity = true;
				return;
			}
			if (type == 1855 || type == 1856)
			{
				name = "Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 1, 0, 0);
				rare = 1;
				placeStyle = 36 + type - 1855;
				return;
			}
			if (type == 1857)
			{
				name = "Jack 'O Lantern Mask";
				width = 18;
				height = 18;
				headSlot = 137;
				value = Item.sellPrice(0, 5, 0, 0);
				vanity = true;
				rare = 3;
				return;
			}
			if (type == 1858)
			{
				name = "Sniper Scope";
				width = 14;
				height = 28;
				rare = 7;
				value = 300000;
				accessory = true;
				toolTip = "Increases view range for guns (Right click to zoom out)";
				toolTip2 = "10% increased ranged damage and critical strike chance";
				return;
			}
			if (type == 1859)
			{
				name = "Heart Lantern";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 9;
				return;
			}
			if (type == 1860)
			{
				name = "Jellyfish Diving Gear";
				width = 24;
				height = 28;
				rare = 5;
				value = 150000;
				accessory = true;
				toolTip = "Grants the ability to swim and greatly extends underwater breathing";
				toolTip2 = "Provides light under water";
				faceSlot = 3;
				return;
			}
			if (type == 1861)
			{
				name = "Arctic Diving Gear";
				width = 24;
				height = 28;
				rare = 6;
				value = 250000;
				accessory = true;
				toolTip = "Grants the ability to swim and greatly extends underwater breathing";
				toolTip2 = "Provides light under water and extra mobility on ice";
				faceSlot = 2;
				return;
			}
			if (type == 1862)
			{
				name = "Sparkfrost Boots";
				width = 16;
				height = 24;
				accessory = true;
				rare = 7;
				toolTip = "Allows flight, super fast running, and extra mobility on ice";
				toolTip = "7% increased movement speed";
				value = 350000;
				shoeSlot = 9;
				return;
			}
			if (type == 1863)
			{
				name = "Fart in a Balloon";
				width = 14;
				height = 28;
				rare = 4;
				value = 150000;
				accessory = true;
				toolTip = "Allows the holder to double jump";
				toolTip2 = "Increases jump height";
				balloonSlot = 5;
				return;
			}
			if (type == 1864)
			{
				name = "Papyrus Scarab";
				rare = 8;
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Increases your max number of minions";
				toolTip2 = "Increases the damage and knockback of your minions";
				value = Item.buyPrice(0, 25, 0, 0);
				return;
			}
			if (type == 1865)
			{
				name = "Celestial Stone";
				width = 16;
				height = 24;
				accessory = true;
				rare = 7;
				toolTip = "Minor increase to damage, attack speed, critical strike chance,";
				toolTip2 = "life regeneration, defense, pick speed, and minion knockback";
				value = 400000;
				return;
			}
			if (type == 1866)
			{
				name = "Hoverboard";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 22;
				return;
			}
			if (type == 1867)
			{
				name = "Candy Cane";
				width = 12;
				height = 12;
				return;
			}
			if (type == 1868)
			{
				name = "Sugar Plum";
				width = 12;
				height = 12;
				return;
			}
			if (type == 1869)
			{
				name = "Present";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 36;
				width = 12;
				height = 28;
				rare = 1;
				toolTip = "Right click to open";
				return;
			}
			if (type == 1870)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 38;
				useTime = 38;
				name = "Red Ryder";
				width = 44;
				height = 14;
				shoot = 10;
				useAmmo = AmmoID.Bullet;

				damage = 20;
				shootSpeed = 8f;
				noMelee = true;
				value = 100000;
				knockBack = 3.75f;
				rare = 1;
				ranged = true;
				return;
			}
			if (type == 1871)
			{
				name = "Festive Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 23;
				return;
			}
			if (type == 1872)
			{
				name = "Tree Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 170;
				width = 12;
				height = 12;
				return;
			}
			if (type == 1873)
			{
				name = "Christmas Tree";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 171;
				width = 12;
				height = 12;
				value = Item.buyPrice(0, 0, 25, 0);
				return;
			}
			if (type >= 1874 && type <= 1905)
			{
				name = "Xmas decorations";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				noMelee = true;
				value = Item.buyPrice(0, 0, 5, 0);
				return;
			}
			if (type == 1906)
			{
				name = "Giant Bow";
				width = 18;
				height = 18;
				headSlot = 138;
				vanity = true;
				value = Item.buyPrice(0, 1, 0, 0);
				return;
			}
			if (type == 1907)
			{
				name = "Reindeer Antlers";
				width = 18;
				height = 18;
				headSlot = 139;
				vanity = true;
				value = Item.buyPrice(0, 1, 0, 0);
				return;
			}
			if (type == 1908)
			{
				name = "Holly";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 246;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 18;
				return;
			}
			if (type == 1909)
			{
				name = "Candy Cane Sword";
				useStyle = 1;
				useAnimation = 27;
				knockBack = 5.3f;
				width = 24;
				height = 28;
				damage = 16;
				scale = 1.1f;

				rare = 1;
				value = 13500;
				melee = true;
				return;
			}
			if (type == 1910)
			{
				name = "Elf Melter";
				useStyle = 5;
				autoReuse = true;
				useAnimation = 30;
				useTime = 5;
				width = 50;
				height = 18;
				shoot = 85;
				useAmmo = AmmoID.Gel;

				damage = 40;
				knockBack = 0.425f;
				shootSpeed = 8.5f;
				noMelee = true;
				value = 500000;
				rare = 8;
				ranged = true;
				toolTip = "Uses gel for ammo";
				return;
			}
			if (type == 1911)
			{
				name = "Christmas Pudding";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 10;
				height = 10;
				buffType = 26;
				buffTime = 126000;
				rare = 1;
				toolTip = "Minor improvements to all stats";
				value = 1000;
				return;
			}
			if (type == 1912)
			{
				name = "Eggnog";

				healLife = 80;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				potion = true;
				value = 40;
				rare = 1;
				return;
			}
			if (type == 1913)
			{
				useStyle = 1;
				name = "Star Anise";
				shootSpeed = 12f;
				shoot = 330;
				damage = 14;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;

				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 25;
				thrown = true;
				return;
			}
			if (type == 1914)
			{
				useStyle = 1;
				name = "Reindeer Bells";
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 8;
				noMelee = true;
				mountType = 0;
				value = Item.sellPrice(0, 5, 0, 0);
				return;
			}
			if (type == 1915)
			{
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Candy Cane Hook";
				shootSpeed = 11.5f;
				shoot = 331;
				width = 18;
				height = 28;

				useAnimation = 20;
				useTime = 20;
				rare = 7;
				noMelee = true;
				value = Item.sellPrice(0, 4, 0, 0);
				return;
			}
			if (type == 1916)
			{
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Christmas Hook";
				shootSpeed = 15.5f;
				shoot = 332;
				width = 18;
				height = 28;

				useAnimation = 20;
				useTime = 20;
				rare = 7;
				noMelee = true;
				value = Item.sellPrice(0, 4, 0, 0);
				return;
			}
			if (type == 1917)
			{
				name = "Candy Cane Pickaxe";
				useStyle = 1;
				useTurn = true;
				useAnimation = 20;
				useTime = 16;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 7;
				pick = 55;

				knockBack = 2.5f;
				value = 10000;
				melee = true;
				toolTip = "Can mine Meteorite";
				return;
			}
			if (type == 1918)
			{
				noMelee = true;
				useStyle = 1;
				name = "Fruitcake Chakrum";
				shootSpeed = 11f;
				shoot = 333;
				damage = 14;
				knockBack = 8f;
				width = 14;
				height = 28;

				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				rare = 1;
				value = 50000;
				melee = true;
				return;
			}
			if (type == 1919)
			{
				name = "Sugar Cookie";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 10;
				height = 10;
				buffType = 26;
				buffTime = 108000;
				rare = 1;
				toolTip = "Minor improvements to all stats";
				value = 1000;
				return;
			}
			if (type == 1920)
			{
				name = "Gingerbread Man";

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 10;
				height = 10;
				buffType = 26;
				buffTime = 108000;
				rare = 1;
				toolTip = "Minor improvements to all stats";
				value = 1000;
				return;
			}
			if (type == 1921)
			{
				name = "Hand Warmer";
				width = 16;
				height = 24;
				accessory = true;
				rare = 2;
				value = 50000;
				handOffSlot = 2;
				handOnSlot = 7;
				return;
			}
			if (type == 1922)
			{
				name = "Coal";
				width = 16;
				height = 24;
				return;
			}
			if (type == 1923)
			{
				name = "Toolbox";
				width = 16;
				height = 24;
				accessory = true;
				rare = 2;
				value = 50000;
				return;
			}
			if (type == 1924)
			{
				name = "Pine Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 26;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type == 1925)
			{
				name = "Pine Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 26;
				width = 12;
				height = 30;
				return;
			}
			if (type == 1926)
			{
				name = "Pine Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 23;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type == 1927)
			{
				useStyle = 1;
				name = "Dog Whistle";
				shoot = 334;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Puppy";
				value = 0;
				buffType = 91;
				return;
			}
			if (type == 1928)
			{
				name = "Christmas Sword";
				useStyle = 1;
				useAnimation = 23;
				useTime = 23;
				knockBack = 7f;
				width = 40;
				height = 40;
				damage = 86;
				scale = 1.1f;
				shoot = 335;
				shootSpeed = 14f;

				rare = 8;
				value = Item.sellPrice(0, 10, 0, 0);
				melee = true;
				return;
			}
			if (type == 1929)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 4;
				useTime = 4;
				name = "Chaingun";
				width = 50;
				height = 18;
				shoot = 10;
				useAmmo = AmmoID.Bullet;

				damage = 31;
				shootSpeed = 14f;
				noMelee = true;
				value = Item.sellPrice(0, 5, 0, 0);
				rare = 8;
				toolTip = "50% chance to not consume ammo";
				knockBack = 1.75f;
				ranged = true;
				return;
			}
			if (type == 1930)
			{
				autoReuse = true;
				name = "Razorpine";
				mana = 5;

				useStyle = 5;
				damage = 48;
				useAnimation = 8;
				useTime = 8;
				width = 40;
				height = 40;
				shoot = 336;
				shootSpeed = 12f;
				knockBack = 3.25f;
				value = Item.sellPrice(0, 5, 0, 0);
				toolTip = "Shoots razor sharp pine needles";
				magic = true;
				rare = 8;
				noMelee = true;
				return;
			}
			if (type == 1931)
			{
				autoReuse = true;
				name = "Blizzard Staff";
				mana = 9;
				useStyle = 5;
				damage = 58;
				useAnimation = 10;
				useTime = 5;
				width = 40;
				height = 40;
				shoot = 337;
				shootSpeed = 10f;
				knockBack = 4.5f;
				value = Item.sellPrice(0, 5, 0, 0);
				magic = true;
				rare = 8;
				noMelee = true;
				return;
			}
			if (type == 1932)
			{
				name = "Mrs. Clause Hat";
				width = 18;
				height = 18;
				headSlot = 140;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1933)
			{
				name = "Mrs. Clause Shirt";
				width = 18;
				height = 18;
				bodySlot = 100;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1934)
			{
				name = "Mrs. Clause Heals";
				width = 18;
				height = 18;
				legSlot = 84;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1935)
			{
				name = "Parka Hood";
				width = 18;
				height = 18;
				headSlot = 142;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1936)
			{
				name = "Parka Coat";
				width = 18;
				height = 18;
				bodySlot = 102;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1937)
			{
				name = "Parka Pants";
				width = 18;
				height = 18;
				legSlot = 86;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1940)
			{
				name = "Tree Mask";
				width = 18;
				height = 18;
				headSlot = 141;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1941)
			{
				name = "Tree Shirt";
				width = 18;
				height = 18;
				bodySlot = 101;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1942)
			{
				name = "Tree Trunks";
				width = 18;
				height = 18;
				legSlot = 85;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1938)
			{
				name = "Snow Hat";
				width = 18;
				height = 18;
				headSlot = 143;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1939)
			{
				name = "Christmas Sweater";
				width = 18;
				height = 18;
				bodySlot = 103;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1943)
			{
				name = "Elf Mask";
				width = 18;
				height = 18;
				headSlot = 144;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1944)
			{
				name = "Elf Shirt";
				width = 18;
				height = 18;
				bodySlot = 104;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1945)
			{
				name = "Elf Pants";
				width = 18;
				height = 18;
				legSlot = 87;
				vanity = true;
				value = Item.buyPrice(0, 3, 0, 0);
				return;
			}
			if (type == 1946)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 15;
				useTime = 15;
				name = "Snowman Cannon";
				useAmmo = AmmoID.Rocket;
				width = 50;
				height = 20;
				shoot = 338;

				damage = 67;
				shootSpeed = 15f;
				noMelee = true;
				value = Item.sellPrice(0, 20, 0, 0);
				knockBack = 4f;
				rare = 8;
				ranged = true;
				return;
			}
			if (type == 1947)
			{
				name = "North Pole";
				useStyle = 5;
				useAnimation = 25;
				useTime = 25;
				shootSpeed = 4.75f;
				knockBack = 6.7f;
				width = 40;
				height = 40;
				damage = 73;
				scale = 1.1f;

				shoot = 342;
				rare = 7;
				value = 180000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			}
			if (type >= 1948 && type <= 1957)
			{
				name = "Christmas Wallpaper";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 116 + type - 1948;
				width = 12;
				height = 12;
				value = Item.buyPrice(0, 0, 1, 0);
				return;
			}
			if (type == 1958)
			{
				useStyle = 4;
				name = "Naughty Present";
				width = 22;
				height = 14;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				maxStack = 20;
				toolTip = "Summons the Frost Moon";
				rare = 8;
				return;
			}
			if (type == 1959)
			{
				useStyle = 1;
				name = "Baby Grinch Mischief's Whistle";
				shoot = 353;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Baby Grinch";
				value = 0;
				buffType = 92;
				return;
			}
			if (type == 1960 || type == 1961 || type == 1962)
			{
				name = "Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 1, 0, 0);
				rare = 1;
				placeStyle = 38 + type - 1960;
				return;
			}
			if (type == 1963)
			{
				name = "Music Box (Pumpkin Moon)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 28;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 1964)
			{
				name = "Music Box (Alt Underground)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 29;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 1965)
			{
				name = "Music Box (Frost Moon)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 30;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 1966)
			{
				name = "Brown Paint";
				paint = 28;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			}
			if (type == 1967)
			{
				name = "Shadow Paint";
				paint = 29;
				width = 24;
				height = 24;
				value = 50;
				maxStack = 999;
				return;
			}
			if (type == 1968)
			{
				name = "Negative Paint";
				paint = 30;
				width = 24;
				height = 24;
				value = 75;
				maxStack = 999;
				return;
			}
			if (type == 1969)
			{
				name = "Team Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				return;
			}
			if (type >= 1970 && type <= 1976)
			{
				name = "Gemspark Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 262 + type - 1970;
				width = 12;
				height = 12;
				return;
			}
			if (type >= 1977 && type <= 1986)
			{
				name = "Hair Dye";
				width = 20;
				height = 26;
				maxStack = 99;
				value = Item.buyPrice(0, 5, 0, 0);
				rare = 2;
				if (type == 1980)
				{
					value = Item.buyPrice(0, 10, 0, 0);
				}
				if (type == 1984)
				{
					value = Item.buyPrice(0, 7, 50, 0);
				}
				if (type == 1985)
				{
					value = Item.buyPrice(0, 15, 0, 0);
				}

				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				consumable = true;
				return;
			}
			if (type == 1987)
			{
				name = "Angel Halo";
				width = 18;
				height = 12;
				maxStack = 1;
				value = Item.buyPrice(0, 40, 0, 0);
				rare = 5;
				accessory = true;
				faceSlot = 7;
				vanity = true;
				return;
			}
			if (type == 1988)
			{
				name = "Fez";
				width = 20;
				height = 14;
				maxStack = 1;
				value = Item.buyPrice(0, 3, 50, 0);
				vanity = true;
				headSlot = 145;
				return;
			}
			if (type == 1989)
			{
				name = "Womannequin";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 269;
				width = 22;
				height = 32;
				return;
			}
			if (type == 1990)
			{
				name = "Hair Dye Remover";
				width = 20;
				height = 26;
				maxStack = 99;
				value = Item.buyPrice(0, 2, 0, 0);
				rare = 2;

				useStyle = 2;
				useTurn = true;
				hairDye = 0;
				useAnimation = 17;
				useTime = 17;
				consumable = true;
				return;
			}
			if (type == 1991)
			{
				name = "Bug Net";
				useTurn = true;
				useStyle = 1;
				useAnimation = 25;
				width = 24;
				height = 28;

				value = Item.buyPrice(0, 0, 25, 0);
				autoReuse = true;
				return;
			}
			if (type == 1992)
			{
				name = "Firefly";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 355;
				noUseGraphic = true;
				bait = 20;
				return;
			}
			if (type == 1993)
			{
				name = "Firefly in a Bottle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 270;
				width = 12;
				height = 28;
				return;
			}
			if (type >= 1994 && type <= 2001)
			{
				name = "Butterfly";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 356;
				placeStyle = 1 + type - 1994;
				noUseGraphic = true;
				int num = type - 1994;
				if (num == 0)
				{
					bait = 5;
				}
				if (num == 4)
				{
					bait = 10;
				}
				if (num == 6)
				{
					bait = 15;
				}
				if (num == 3)
				{
					bait = 20;
				}
				if (num == 7)
				{
					bait = 25;
				}
				if (num == 2)
				{
					bait = 30;
				}
				if (num == 1)
				{
					bait = 35;
				}
				if (num == 5)
				{
					bait = 50;
				}
			}
		}

		public void SetDefaults3(int type)
		{
			if (type == 2002)
			{
				name = "Worm";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 357;
				noUseGraphic = true;
				bait = 25;
				return;
			}
			if (type == 2003)
			{
				name = "Mouse";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 300;
				noUseGraphic = true;
				return;
			}
			if (type == 2004)
			{
				name = "Lightning Bug";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 358;
				noUseGraphic = true;
				bait = 35;
				return;
			}
			if (type == 2005)
			{
				name = "Lightning Bug in a Bottle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 271;
				width = 12;
				height = 28;
				return;
			}
			if (type == 2006)
			{
				name = "Snail";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 359;
				noUseGraphic = true;
				bait = 10;
				return;
			}
			if (type == 2007)
			{
				name = "Glowing Snail";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 360;
				noUseGraphic = true;
				bait = 15;
				return;
			}
			if (type >= 2008 && type <= 2014)
			{
				name = "Wallpaper";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 126 + type - 2008;
				width = 12;
				height = 12;
				value = Item.buyPrice(0, 0, 1, 0);
				return;
			}
			if (type >= 2015 && type <= 2019)
			{
				name = "Glowing Snail";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				noUseGraphic = true;
				if (type == 2015)
				{
					makeNPC = 74;
				}
				if (type == 2016)
				{
					makeNPC = 297;
				}
				if (type == 2017)
				{
					makeNPC = 298;
				}
				if (type == 2018)
				{
					makeNPC = 299;
				}
				if (type == 2019)
				{
					makeNPC = 46;
					return;
				}
			}
			else
			{
				if (type == 2020)
				{
					name = "Cactus Bookcase";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 101;
					width = 20;
					height = 20;
					value = 300;
					placeStyle = 6;
					return;
				}
				if (type == 2021)
				{
					name = "Ebonwood Bookcase";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 101;
					width = 20;
					height = 20;
					value = 300;
					placeStyle = 7;
					return;
				}
				if (type == 2022)
				{
					name = "Flesh Bookcase";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 101;
					width = 20;
					height = 20;
					value = 300;
					placeStyle = 8;
					return;
				}
				if (type == 2023)
				{
					name = "Hive Bookcase";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 101;
					width = 20;
					height = 20;
					value = 300;
					placeStyle = 9;
					return;
				}
				if (type == 2024)
				{
					name = "Steampunk Bookcase";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 101;
					width = 20;
					height = 20;
					value = 300;
					placeStyle = 10;
					return;
				}
				if (type == 2025)
				{
					name = "Glass Bookcase";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 101;
					width = 20;
					height = 20;
					value = 300;
					placeStyle = 11;
					return;
				}
				if (type == 2026)
				{
					name = "Rich Mahogany Bookcase";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 101;
					width = 20;
					height = 20;
					value = 300;
					placeStyle = 12;
					return;
				}
				if (type == 2027)
				{
					name = "Pearlwood Bookcase";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 101;
					width = 20;
					height = 20;
					value = 300;
					placeStyle = 13;
					return;
				}
				if (type == 2028)
				{
					name = "Spooky Bookcase";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 101;
					width = 20;
					height = 20;
					value = 300;
					placeStyle = 14;
					return;
				}
				if (type == 2029)
				{
					name = "Sunplate Bookcase";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 101;
					width = 20;
					height = 20;
					value = 300;
					placeStyle = 15;
					return;
				}
				if (type == 2030)
				{
					name = "Temple Bookcase";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 101;
					width = 20;
					height = 20;
					value = 300;
					placeStyle = 16;
					return;
				}
				if (type == 2031)
				{
					name = "Frozen Bookcase";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 101;
					width = 20;
					height = 20;
					value = 300;
					placeStyle = 17;
					return;
				}
				if (type == 2032)
				{
					name = "Lantern 10";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 42;
					width = 12;
					height = 28;
					placeStyle = 10;
					return;
				}
				if (type == 2033)
				{
					name = "Lantern 11";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 42;
					width = 12;
					height = 28;
					placeStyle = 11;
					return;
				}
				if (type == 2034)
				{
					name = "Lantern 12";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 42;
					width = 12;
					height = 28;
					placeStyle = 12;
					return;
				}
				if (type == 2035)
				{
					name = "Lantern 13";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 42;
					width = 12;
					height = 28;
					placeStyle = 13;
					return;
				}
				if (type == 2036)
				{
					name = "Lantern 14";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 42;
					width = 12;
					height = 28;
					placeStyle = 14;
					return;
				}
				if (type == 2037)
				{
					name = "Lantern 15";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 42;
					width = 12;
					height = 28;
					placeStyle = 15;
					return;
				}
				if (type == 2038)
				{
					name = "Lantern 16";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 42;
					width = 12;
					height = 28;
					placeStyle = 16;
					return;
				}
				if (type == 2039)
				{
					name = "Lantern 17";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 42;
					width = 12;
					height = 28;
					placeStyle = 17;
					return;
				}
				if (type == 2040)
				{
					name = "Lantern 18";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 42;
					width = 12;
					height = 28;
					placeStyle = 18;
					return;
				}
				if (type == 2041)
				{
					name = "Lantern 19";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 42;
					width = 12;
					height = 28;
					placeStyle = 19;
					return;
				}
				if (type == 2042)
				{
					name = "Lantern 20";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 42;
					width = 12;
					height = 28;
					placeStyle = 20;
					return;
				}
				if (type == 2043)
				{
					name = "Lantern 21";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 42;
					width = 12;
					height = 28;
					placeStyle = 21;
					return;
				}
				if (type == 2044)
				{
					name = "Frozen Door";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					maxStack = 99;
					consumable = true;
					createTile = 10;
					placeStyle = 27;
					width = 14;
					height = 28;
					value = 200;
					return;
				}
				if (type >= 2045 && type <= 2054)
				{
					noWet = true;
					name = "more candles";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 33;
					width = 8;
					height = 18;
					placeStyle = 4 + type - 2045;
					return;
				}
				if (type >= 2055 && type <= 2065)
				{
					name = "more chandeliers";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 34;
					placeStyle = 7 + type - 2055;
					width = 26;
					height = 26;
					value = 3000;
					return;
				}
				if (type >= 2066 && type <= 2071)
				{
					name = "more beds";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					maxStack = 99;
					consumable = true;
					autoReuse = true;
					createTile = 79;
					placeStyle = 13 + type - 2066;
					width = 28;
					height = 20;
					value = 2000;
					return;
				}
				if (type >= 2072 && type <= 2081)
				{
					name = "more bathtubs";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 90;
					placeStyle = type + 1 - 2072;
					width = 20;
					height = 20;
					value = 300;
					return;
				}
				if (type >= 2082 && type <= 2091)
				{
					name = "Lamps";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 93;
					placeStyle = type + 1 - 2082;
					width = 10;
					height = 24;
					value = 500;
					return;
				}
				if (type >= 2092 && type <= 2103)
				{
					name = "more candelabras";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 100;
					placeStyle = type + 1 - 2092;
					width = 20;
					height = 20;
					value = 1500;
					return;
				}
				if (type >= 2104 && type <= 2113)
				{
					name = "Skeletron Mask";
					width = 28;
					height = 20;
					headSlot = type + 146 - 2104;
					rare = 1;
					vanity = true;
					return;
				}
				if (type >= 2114 && type <= 2118)
				{
					name = "Rack";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 240;
					width = 30;
					height = 30;
					value = Item.sellPrice(0, 0, 5, 0);
					placeStyle = 41 + type - 2114;
					maxStack = 99;
					return;
				}
				if (type == 2119)
				{
					name = "Stone Slab";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 273;
					width = 12;
					height = 12;
					return;
				}
				if (type == 2120)
				{
					name = "Sandstone Slab";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 274;
					width = 12;
					height = 12;
					return;
				}
				if (type == 2121)
				{
					name = "Frog";
					useStyle = 1;
					autoReuse = true;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					maxStack = 999;
					consumable = true;
					width = 12;
					height = 12;
					makeNPC = 361;
					noUseGraphic = true;
					return;
				}
				if (type == 2122)
				{
					name = "Duck";
					useStyle = 1;
					autoReuse = true;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					maxStack = 999;
					consumable = true;
					width = 12;
					height = 12;
					makeNPC = 362;
					noUseGraphic = true;
					return;
				}
				if (type == 2123)
				{
					name = "Duck";
					useStyle = 1;
					autoReuse = true;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					maxStack = 999;
					consumable = true;
					width = 12;
					height = 12;
					makeNPC = 364;
					noUseGraphic = true;
					return;
				}
				if (type >= 2124 && type <= 2128)
				{
					name = "more bathtubs";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 90;
					placeStyle = type + 11 - 2124;
					width = 20;
					height = 20;
					value = 300;
					return;
				}
				if (type >= 2129 && type <= 2134)
				{
					name = "Lamps";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 93;
					placeStyle = type + 11 - 2129;
					width = 10;
					height = 24;
					value = 500;
					return;
				}
				if (type >= 2135 && type <= 2138)
				{
					name = "Bookcase";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 101;
					width = 20;
					height = 20;
					value = 300;
					placeStyle = 18 + type - 2135;
					return;
				}
				if (type == 2139)
				{
					name = "more beds";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					maxStack = 99;
					consumable = true;
					autoReuse = true;
					createTile = 79;
					placeStyle = 19;
					width = 28;
					height = 20;
					value = 2000;
					return;
				}
				if (type == 2140)
				{
					name = "more beds";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					maxStack = 99;
					consumable = true;
					autoReuse = true;
					createTile = 79;
					placeStyle = 20;
					width = 28;
					height = 20;
					value = 2000;
					return;
				}
				if (type >= 2141 && type <= 2144)
				{
					name = "more chandeliers";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 34;
					placeStyle = 18 + type - 2141;
					width = 26;
					height = 26;
					value = 3000;
					return;
				}
				if (type >= 2145 && type <= 2148)
				{
					name = "Lantern 22";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 42;
					width = 12;
					height = 28;
					placeStyle = 22 + type - 2145;
					return;
				}
				if (type >= 2149 && type <= 2152)
				{
					name = "more candelabras";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 100;
					placeStyle = type + 13 - 2149;
					width = 20;
					height = 20;
					value = 1500;
					return;
				}
				if (type >= 2153 && type <= 2155)
				{
					noWet = true;
					name = "more candles";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 33;
					width = 8;
					height = 18;
					placeStyle = 14 + type - 2153;
					return;
				}
				if (type == 2156)
				{
					name = "Black Scorpion";
					useStyle = 1;
					autoReuse = true;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					maxStack = 999;
					consumable = true;
					width = 12;
					height = 12;
					makeNPC = 366;
					noUseGraphic = true;
					bait = 15;
					return;
				}
				if (type == 2157)
				{
					name = "Scorpion";
					useStyle = 1;
					autoReuse = true;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					maxStack = 999;
					consumable = true;
					width = 12;
					height = 12;
					makeNPC = 367;
					noUseGraphic = true;
					bait = 10;
					return;
				}
				if (type >= 2158 && type <= 2160)
				{
					name = "Wallpaper";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 7;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createWall = 133 + type - 2158;
					width = 12;
					height = 12;
					value = Item.buyPrice(0, 0, 1, 0);
					return;
				}
				if (type == 2161)
				{
					name = "Frost Core";
					width = 18;
					height = 18;
					maxStack = 999;
					value = 50000;
					rare = 5;
					return;
				}
				if (type >= 2162 && type <= 2168)
				{
					name = "Critter Cage";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 275 + type - 2162;
					width = 12;
					height = 12;
					return;
				}
				if (type == 2169)
				{
					name = "Waterfall Wall";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 7;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createWall = 136;
					width = 12;
					height = 12;
					return;
				}
				if (type == 2170)
				{
					name = "Lavafall Wall";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 7;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createWall = 137;
					width = 12;
					height = 12;
					return;
				}
				if (type == 2171)
				{
					autoReuse = true;
					name = "Crimson Seeds";
					useTurn = true;
					useStyle = 1;
					useAnimation = 15;
					useTime = 10;
					maxStack = 99;
					consumable = true;
					createTile = 199;
					width = 14;
					height = 14;
					value = 500;
					return;
				}
				if (type == 2172)
				{
					name = "Heavy Work Bench";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 283;
					width = 28;
					height = 14;
					value = 500;
					toolTip = "Used for advanced crafting";
					return;
				}
				if (type == 2173)
				{
					name = "Copper Plating";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 284;
					width = 12;
					height = 12;
					return;
				}
				if (type >= 2174 && type <= 2175)
				{
					name = "Critter Cage";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 285 + type - 2174;
					width = 12;
					height = 12;
					return;
				}
				if (type == 2176)
				{
					name = "Shroomite Digging Claw";
					useStyle = 1;
					useAnimation = 12;
					useTime = 4;
					knockBack = 6f;
					useTurn = true;
					autoReuse = true;
					width = 20;
					height = 12;
					damage = 45;
					pick = 200;
					axe = 25;

					rare = 8;
					value = Item.sellPrice(0, 1, 0, 0);
					melee = true;
					tileBoost--;
					return;
				}
				if (type == 2177)
				{
					name = "Ammo Box";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 287;
					width = 22;
					height = 22;
					value = Item.buyPrice(0, 15, 0, 0);
					rare = 6;
					return;
				}
				if (type >= 2178 && type <= 2187)
				{
					name = "Butterfly Jar";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 288 + type - 2178;
					width = 12;
					height = 12;
					return;
				}
				if (type == 2189)
				{
					name = "Spectre Mask";
					width = 18;
					height = 18;
					defense = 18;
					headSlot = 156;
					rare = 8;
					value = 375000;
					toolTip = "Increases maximum mana by 60 and reduces mana usage by 13%";
					toolTip2 = "5% increased magic damage and critical strike chance";
					return;
				}
				if (type == 2188)
				{
					name = "Venom Staff";
					mana = 25;

					useStyle = 5;
					damage = 63;
					useAnimation = 30;
					useTime = 30;
					width = 40;
					height = 40;
					shoot = 355;
					shootSpeed = 14f;
					knockBack = 7f;
					magic = true;
					autoReuse = true;
					rare = 7;
					noMelee = true;
					value = Item.sellPrice(0, 7, 0, 0);
					return;
				}
				if (type >= 2190 && type <= 2191)
				{
					name = "Critter Cage";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 298 + type - 2190;
					width = 12;
					height = 12;
					return;
				}
				if ((type >= 2192 && type <= 2198) || type == 2203 || type == 2204)
				{
					name = "Crafting Tables";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					if (type == 2203)
					{
						createTile = 307;
					}
					else if (type == 2204)
					{
						createTile = 308;
					}
					else
					{
						createTile = 300 + type - 2192;
					}
					width = 12;
					height = 12;
					value = Item.buyPrice(0, 10, 0, 0);
					return;
				}
				if (type == 2199)
				{
					name = "Beetle Helmet";
					width = 18;
					height = 18;
					defense = 23;
					headSlot = 157;
					rare = 8;
					value = 300000;
					toolTip = "6% increased melee damage";
					toolTip2 = "Enemies are more likely to target you";
					return;
				}
				if (type == 2200)
				{
					name = "Beetle Scale Mail";
					width = 18;
					height = 18;
					defense = 20;
					bodySlot = 105;
					rare = 8;
					value = 240000;
					toolTip = "8% increased melee damage and critical strike chance";
					toolTip = "6% increased movement and melee speed";
					return;
				}
				if (type == 2201)
				{
					name = "Beetle Shell";
					width = 18;
					height = 18;
					defense = 32;
					bodySlot = 106;
					rare = 8;
					value = 240000;
					toolTip = "5% increased melee damage and critical strike chance";
					toolTip2 = "Enemies are more likely to target you";
					return;
				}
				if (type == 2202)
				{
					name = "Beetle Leggings";
					width = 18;
					height = 18;
					defense = 18;
					legSlot = 98;
					rare = 8;
					value = 180000;
					toolTip = "6% increased movement and melee speed";
					toolTip2 = "Enemies are more likely to target you";
					return;
				}
				if (type == 2205)
				{
					name = "Penguin";
					useStyle = 1;
					autoReuse = true;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					maxStack = 999;
					consumable = true;
					width = 12;
					height = 12;
					makeNPC = 148;
					noUseGraphic = true;
					return;
				}
				if (type == 2206 || type == 2207)
				{
					name = "Critter Cage";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 309 + type - 2206;
					width = 12;
					height = 12;
					return;
				}
				if (type == 2208)
				{
					name = "Terrarium";
					width = 18;
					height = 20;
					maxStack = 99;
					return;
				}
				if (type == 2209)
				{
					name = "Super Mana Potion";

					healMana = 300;
					useStyle = 2;
					useTurn = true;
					useAnimation = 17;
					useTime = 17;
					maxStack = 99;
					consumable = true;
					width = 14;
					height = 24;
					rare = 4;
					value = 1500;
					return;
				}
				if (type >= 2210 && type <= 2213)
				{
					name = "Wooden Fences";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 7;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createWall = 138 + type - 2210;
					width = 12;
					height = 12;
					return;
				}
				if (type >= 2214 && type <= 2217)
				{
					name = "Builder's Accessories";
					width = 30;
					height = 30;
					accessory = true;
					rare = 3;
					value = Item.buyPrice(0, 10, 0, 0);
					return;
				}
				if (type == 2218)
				{
					name = "Beetle Husk";
					width = 14;
					height = 18;
					maxStack = 99;
					rare = 8;
					value = Item.sellPrice(0, 0, 50, 0);
					return;
				}
				if (type == 2219)
				{
					name = "Celestial Magnet";
					width = 24;
					height = 24;
					accessory = true;
					toolTip = "Increases pickup range for stars";
					value = Item.buyPrice(0, 15, 0, 0);
					rare = 4;
					return;
				}
				if (type == 2220)
				{
					name = "Celestial Emblem";
					width = 24;
					height = 24;
					accessory = true;
					toolTip = "15% increased magic damage";
					toolTip2 = "Increases pickup range for stars";
					value = Item.buyPrice(0, 16, 0, 0);
					rare = 5;
					return;
				}
				if (type == 2221)
				{
					name = "Celestial Cuffs";
					width = 24;
					height = 24;
					accessory = true;
					rare = 5;
					toolTip = "Restores mana when damaged";
					toolTip2 = "Increases pickup range for stars";
					value = Item.buyPrice(0, 16, 0, 0);
					handOffSlot = 10;
					handOnSlot = 17;
					return;
				}
				if (type == 2222)
				{
					name = "Peddler's Hat";
					width = 18;
					height = 18;
					headSlot = 158;
					vanity = true;
					value = Item.sellPrice(0, 0, 25, 0);
					return;
				}
				if (type == 2223)
				{
					autoReuse = true;
					useStyle = 5;
					useAnimation = 22;
					useTime = 22;
					name = "Pulse Bow";
					width = 50;
					height = 18;
					shoot = 10;
					useAmmo = AmmoID.Arrow;

					crit = 7;
					damage = 65;
					knockBack = 3f;
					shootSpeed = 7.75f;
					noMelee = true;
					value = Item.buyPrice(0, 45, 0, 0);
					rare = 8;
					ranged = true;
					toolTip = "Shoots a charged arrow";
					return;
				}
				if (type == 2224)
				{
					name = "more chandeliers";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 34;
					placeStyle = 22;
					width = 26;
					height = 26;
					value = 3000;
					return;
				}
				if (type == 2225)
				{
					name = "Lamps";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 93;
					placeStyle = 17;
					width = 10;
					height = 24;
					value = 500;
					return;
				}
				if (type == 2226)
				{
					name = "Lantern";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 42;
					width = 12;
					height = 28;
					placeStyle = 26;
					return;
				}
				if (type == 2227)
				{
					name = "more candelabras";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 100;
					placeStyle = 17;
					width = 20;
					height = 20;
					value = 1500;
					return;
				}
				if (type == 2228)
				{
					name = "Dynasty Chair";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 15;
					placeStyle = 27;
					width = 12;
					height = 30;
					return;
				}
				if (type == 2229)
				{
					name = "Dynasty Work Bench";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 18;
					placeStyle = 18;
					width = 28;
					height = 14;
					value = 150;
					return;
				}
				if (type == 2230)
				{
					name = "Dynasty Chest";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 21;
					placeStyle = 28;
					width = 26;
					height = 22;
					value = 2500;
					return;
				}
				if (type == 2231)
				{
					name = "Dynasty Bed";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					maxStack = 99;
					consumable = true;
					autoReuse = true;
					createTile = 79;
					placeStyle = 21;
					width = 28;
					height = 20;
					value = 2000;
					return;
				}
				if (type == 2232)
				{
					name = "more bathtubs";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 90;
					placeStyle = 16;
					width = 20;
					height = 20;
					value = 300;
					return;
				}
				if (type == 2233)
				{
					name = "Bookcase";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 101;
					width = 20;
					height = 20;
					value = 300;
					placeStyle = 22;
					return;
				}
				if (type == 2234)
				{
					name = "Dynasty Cup";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 13;
					placeStyle = 5;
					width = 16;
					height = 24;
					value = 20;
					return;
				}
				if (type == 2235)
				{
					name = "Bowl";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 103;
					placeStyle = 1;
					width = 16;
					height = 24;
					value = 20;
					return;
				}
				if (type == 2236)
				{
					noWet = true;
					name = "more candles";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 33;
					width = 8;
					height = 18;
					placeStyle = 17;
					return;
				}
				if (type >= 2237 && type <= 2241)
				{
					name = "Grandfather Clock";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 104;
					placeStyle = 1 + type - 2237;
					width = 20;
					height = 20;
					value = 300;
					return;
				}
				if (type == 2242 || type == 2243)
				{
					name = "Bowl";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 103;
					placeStyle = 2 + type - 2242;
					width = 16;
					height = 24;
					value = 20;
					if (type == 2242)
					{
						value = Item.buyPrice(0, 0, 20, 0);
						return;
					}
				}
				else
				{
					if (type == 2244)
					{
						name = "Wine Glass";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 13;
						placeStyle = 6;
						width = 16;
						height = 24;
						value = 20;
						return;
					}
					if (type >= 2245 && type <= 2247)
					{
						name = "Piano";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 87;
						placeStyle = 5 + type - 2245;
						width = 20;
						height = 20;
						value = 300;
						return;
					}
					if (type == 2248)
					{
						name = "Frozen Table";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 14;
						placeStyle = 24;
						width = 26;
						height = 20;
						value = 300;
						return;
					}
					if (type == 2249 || type == 2250)
					{
						name = "Dynasty Chest";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 21;
						placeStyle = 29 + type - 2249;
						width = 26;
						height = 22;
						value = 2500;
						return;
					}
					if (type >= 2251 && type <= 2253)
					{
						name = "Honey Work Bench";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 18;
						placeStyle = 19 + type - 2251;
						width = 28;
						height = 14;
						value = 150;
						return;
					}
					if (type >= 2254 && type <= 2256)
					{
						name = "Piano";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 87;
						placeStyle = 8 + type - 2254;
						width = 20;
						height = 20;
						value = 300;
						return;
					}
					if (type == 2257 || type == 2258)
					{
						name = "more cups";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 13;
						placeStyle = 7 + type - 2257;
						width = 16;
						height = 24;
						value = 20;
						if (type == 2258)
						{
							value = Item.buyPrice(0, 0, 50, 0);
							return;
						}
					}
					else
					{
						if (type == 2259)
						{
							name = "Dynasty Table";
							useStyle = 1;
							useTurn = true;
							useAnimation = 15;
							useTime = 10;
							autoReuse = true;
							maxStack = 99;
							consumable = true;
							createTile = 14;
							placeStyle = 25;
							width = 26;
							height = 20;
							value = 300;
							return;
						}
						if (type >= 2260 && type <= 2262)
						{
							name = "Dynasty Blocks";
							useStyle = 1;
							useTurn = true;
							useAnimation = 15;
							useTime = 10;
							autoReuse = true;
							maxStack = 999;
							consumable = true;
							createTile = 311 + type - 2260;
							width = 12;
							height = 12;
							value = Item.buyPrice(0, 0, 0, 50);
							return;
						}
						if (type >= 2263 && type <= 2264)
						{
							name = "Dynasty Walls";
							useStyle = 1;
							useTurn = true;
							useAnimation = 15;
							useTime = 10;
							autoReuse = true;
							maxStack = 999;
							consumable = true;
							createWall = 142 + type - 2263;
							width = 12;
							height = 12;
							return;
						}
						if (type == 2265)
						{
							name = "Dynasty Door";
							useStyle = 1;
							useTurn = true;
							useAnimation = 15;
							useTime = 10;
							maxStack = 99;
							consumable = true;
							createTile = 10;
							placeStyle = 28;
							width = 14;
							height = 28;
							value = 200;
							return;
						}
						if (type == 2266)
						{
							name = "Sake";

							useStyle = 2;
							useTurn = true;
							useAnimation = 17;
							useTime = 17;
							maxStack = 30;
							consumable = true;
							width = 10;
							height = 10;
							buffType = 25;
							buffTime = 14400;
							rare = 1;
							value = Item.buyPrice(0, 0, 5, 0);
							return;
						}
						if (type == 2267)
						{
							name = "Pad Thai";

							useStyle = 2;
							useTurn = true;
							useAnimation = 17;
							useTime = 17;
							maxStack = 30;
							consumable = true;
							width = 10;
							height = 10;
							buffType = 26;
							buffTime = 36000;
							rare = 1;
							toolTip = "Minor improvements to all stats";
							value = Item.buyPrice(0, 0, 20, 0);
							return;
						}
						if (type == 2268)
						{
							name = "Pho";

							useStyle = 2;
							useTurn = true;
							useAnimation = 17;
							useTime = 17;
							maxStack = 30;
							consumable = true;
							width = 10;
							height = 10;
							buffType = 26;
							buffTime = 54000;
							rare = 1;
							toolTip = "Minor improvements to all stats";
							value = Item.buyPrice(0, 0, 30, 0);
							return;
						}
						if (type == 2269)
						{
							name = "Revolver";
							autoReuse = false;
							useStyle = 5;
							useAnimation = 22;
							useTime = 22;
							width = 24;
							height = 24;
							shoot = 14;
							knockBack = 4f;
							useAmmo = AmmoID.Bullet;

							damage = 20;
							shootSpeed = 16f;
							noMelee = true;
							value = Item.buyPrice(0, 10, 0, 0);
							scale = 0.85f;
							rare = 2;
							ranged = true;
							crit = 5;
							return;
						}
						if (type == 2270)
						{
							useStyle = 5;
							autoReuse = true;
							useAnimation = 7;
							useTime = 7;
							name = "Gatligator";
							width = 50;
							height = 18;
							shoot = 10;
							useAmmo = AmmoID.Bullet;

							damage = 21;
							shootSpeed = 8f;
							noMelee = true;
							value = Item.buyPrice(0, 35, 0, 0);
							knockBack = 1.5f;
							rare = 4;
							toolTip = "33% chance to not consume ammo";
							ranged = true;
							return;
						}
						if (type == 2271)
						{
							name = "Arcane Runes";
							useStyle = 1;
							useTurn = true;
							useAnimation = 15;
							useTime = 10;
							autoReuse = true;
							maxStack = 999;
							consumable = true;
							createWall = 144;
							width = 12;
							height = 12;
							value = Item.buyPrice(0, 0, 2, 50);
							return;
						}
						if (type == 2272)
						{
							name = "Water Gun";
							useStyle = 5;
							useAnimation = 20;
							useTime = 20;
							width = 38;
							height = 10;
							damage = 0;
							scale = 0.9f;
							shoot = 358;
							shootSpeed = 11f;
							value = Item.buyPrice(0, 1, 50, 0);
							return;
						}
						if (type == 2273)
						{
							autoReuse = true;
							useTurn = true;
							name = "Katana";
							useStyle = 1;
							useAnimation = 22;
							knockBack = 3.5f;
							width = 34;
							height = 34;
							damage = 16;
							crit = 15;
							scale = 1f;

							rare = 1;
							value = Item.buyPrice(0, 4, 0, 0);
							melee = true;
							return;
						}
						if (type == 2274)
						{
							flame = true;
							noWet = true;
							name = "Ultrabright Torch";
							useStyle = 1;
							useTurn = true;
							useAnimation = 15;
							useTime = 10;
							holdStyle = 1;
							autoReuse = true;
							maxStack = 99;
							consumable = true;
							createTile = 4;
							placeStyle = 12;
							width = 10;
							height = 12;
							value = Item.buyPrice(0, 0, 3, 0);
							return;
						}
						if (type == 2275)
						{
							name = "Magic Hat";
							width = 18;
							height = 18;
							headSlot = 159;
							value = Item.buyPrice(0, 3, 0, 0);
							toolTip = "7% increased magic damage and critical strike chance";
							defense = 2;
							rare = 2;
							return;
						}
						if (type == 2276)
						{
							name = "Diamond Ring";
							width = 24;
							height = 24;
							accessory = true;
							vanity = true;
							rare = 8;
							value = Item.buyPrice(2, 0, 0, 0);
							handOnSlot = 16;
							return;
						}
						if (type == 2277)
						{
							name = "Gi";
							width = 18;
							height = 14;
							bodySlot = 165;
							value = Item.buyPrice(0, 2, 0, 0);
							defense = 4;
							toolTip = "5% increased damage and critical strike chance";
							toolTip = "10% increased melee and movement speed";
							rare = 1;
							return;
						}
						if (type == 2278)
						{
							name = "Kimono";
							width = 18;
							height = 14;
							bodySlot = 166;
							vanity = true;
							value = Item.buyPrice(0, 1, 0, 0);
							return;
						}
						if (type == 2279)
						{
							name = "Gypsy Robe";
							width = 18;
							height = 14;
							bodySlot = 167;
							value = Item.buyPrice(0, 3, 50, 0);
							defense = 2;
							toolTip = "6% increased magic damage and critical strike chance";
							toolTip2 = "Reduces mana usage by 10%";
							rare = 1;
							return;
						}
						if (type == 2280)
						{
							name = "Beetle Wings";
							width = 22;
							height = 20;
							accessory = true;
							toolTip = "Allows flight and slow fall";
							value = 400000;
							rare = 7;
							wingSlot = 24;
							return;
						}
						if (type >= 2281 && type <= 2283)
						{
							name = "Animal Skins";
							useStyle = 1;
							useTurn = true;
							useAnimation = 15;
							useTime = 10;
							autoReuse = true;
							maxStack = 99;
							consumable = true;
							createTile = 242;
							width = 30;
							height = 30;
							value = Item.buyPrice(0, 1, 0, 0);
							placeStyle = 22 + type - 2281;
							return;
						}
						if (type >= 2284 && type <= 2287)
						{
							name = "Capes";
							width = 26;
							height = 30;
							maxStack = 1;
							value = Item.buyPrice(0, 5, 0, 0);
							rare = 5;
							accessory = true;
							backSlot = (sbyte)(3 + type - 2284);
							frontSlot = (sbyte)(1 + type - 2284);
							vanity = true;
							return;
						}
						if (type == 2288)
						{
							name = "Frozen Chair";
							useStyle = 1;
							useTurn = true;
							useAnimation = 15;
							useTime = 10;
							autoReuse = true;
							maxStack = 99;
							consumable = true;
							createTile = 15;
							placeStyle = 28;
							width = 12;
							height = 30;
							return;
						}
						if (type == 2289 || (type >= 2291 && type <= 2296))
						{
							name = "Fishing Poles";
							useStyle = 1;
							useAnimation = 8;
							useTime = 8;
							width = 24;
							height = 28;

							shoot = 361 + type - 2291;
							if (type == 2289)
							{
								fishingPole = 5;
								shootSpeed = 9f;
								shoot = 360;
								return;
							}
							if (type == 2291)
							{
								fishingPole = 15;
								shootSpeed = 11f;
								return;
							}
							if (type == 2293)
							{
								fishingPole = 20;
								shootSpeed = 13f;
								rare = 1;
								return;
							}
							if (type == 2292)
							{
								fishingPole = 27;
								shootSpeed = 14f;
								rare = 2;
								value = Item.sellPrice(0, 1, 0, 0);
								return;
							}
							if (type == 2295)
							{
								fishingPole = 30;
								shootSpeed = 15f;
								rare = 2;
								value = Item.buyPrice(0, 20, 0, 0);
								return;
							}
							if (type == 2296)
							{
								fishingPole = 40;
								shootSpeed = 16f;
								rare = 2;
								value = Item.buyPrice(0, 35, 0, 0);
								return;
							}
							if (type == 2294)
							{
								fishingPole = 50;
								shootSpeed = 17f;
								rare = 3;
								value = Item.sellPrice(0, 20, 0, 0);
								return;
							}
						}
						else if (type >= 2421 && type <= 2422)
						{
							name = "Fishing Poles";
							useStyle = 1;
							useAnimation = 8;
							useTime = 8;
							width = 24;
							height = 28;

							shoot = 381 + type - 2421;
							if (type == 2421)
							{
								fishingPole = 22;
								shootSpeed = 13.5f;
								rare = 1;
								return;
							}
							fishingPole = 45;
							shootSpeed = 16.5f;
							rare = 3;
							value = Item.sellPrice(0, 10, 0, 0);
							return;
						}
						else
						{
							if (type == 2320)
							{
								name = "Rockfish";
								autoReuse = true;
								width = 26;
								height = 26;
								value = Item.sellPrice(0, 1, 50, 0);
								useStyle = 1;
								useAnimation = 24;
								useTime = 14;
								hammer = 70;
								knockBack = 6f;
								damage = 24;
								scale = 1.05f;

								rare = 3;
								melee = true;
								return;
							}
							if (type == 2314)
							{
								name = "Honeyfin";
								maxStack = 30;
								width = 26;
								height = 26;
								value = Item.sellPrice(0, 0, 15, 0);
								rare = 1;

								healLife = 120;
								useStyle = 2;
								useTurn = true;
								useAnimation = 17;
								useTime = 17;
								consumable = true;
								potion = true;
								return;
							}
							if (type >= 2290 && type <= 2321)
							{
								name = "Fish";
								maxStack = 999;
								width = 26;
								height = 26;
								value = Item.sellPrice(0, 0, 5, 0);
								if (type == 2308)
								{
									value = Item.sellPrice(0, 10, 0, 0);
									rare = 4;
								}
								if (type == 2312)
								{
									value = Item.sellPrice(0, 0, 50, 0);
									rare = 2;
								}
								if (type == 2317)
								{
									value = Item.sellPrice(0, 3, 0, 0);
									rare = 4;
								}
								if (type == 2310)
								{
									value = Item.sellPrice(0, 1, 0, 0);
									rare = 3;
								}
								if (type == 2321)
								{
									value = Item.sellPrice(0, 0, 25, 0);
									rare = 1;
								}
								if (type == 2315)
								{
									value = Item.sellPrice(0, 0, 15, 0);
									rare = 2;
								}
								if (type == 2303)
								{
									value = Item.sellPrice(0, 0, 15, 0);
									rare = 1;
								}
								if (type == 2304)
								{
									value = Item.sellPrice(0, 0, 30, 0);
									rare = 1;
								}
								if (type == 2316)
								{
									value = Item.sellPrice(0, 0, 15, 0);
								}
								if (type == 2311)
								{
									value = Item.sellPrice(0, 0, 15, 0);
									rare = 1;
								}
								if (type == 2313)
								{
									value = Item.sellPrice(0, 0, 15, 0);
									rare = 1;
								}
								if (type == 2306)
								{
									value = Item.sellPrice(0, 0, 15, 0);
									rare = 1;
								}
								if (type == 2307)
								{
									value = Item.sellPrice(0, 0, 25, 0);
									rare = 2;
								}
								if (type == 2319)
								{
									value = Item.sellPrice(0, 0, 15, 0);
									rare = 1;
								}
								if (type == 2318)
								{
									value = Item.sellPrice(0, 0, 15, 0);
									rare = 1;
								}
								if (type == 2298)
								{
									value = Item.sellPrice(0, 0, 7, 50);
								}
								if (type == 2309)
								{
									value = Item.sellPrice(0, 0, 7, 50);
									rare = 1;
								}
								if (type == 2300)
								{
									value = Item.sellPrice(0, 0, 7, 50);
								}
								if (type == 2301)
								{
									value = Item.sellPrice(0, 0, 7, 50);
								}
								if (type == 2302)
								{
									value = Item.sellPrice(0, 0, 15, 0);
								}
								if (type == 2299)
								{
									value = Item.sellPrice(0, 0, 7, 50);
								}
								if (type == 2305)
								{
									value = Item.sellPrice(0, 0, 7, 50);
									rare = 1;
									return;
								}
							}
							else
							{
								if (type == 2322)
								{
									name = "Mining Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 104;
									buffTime = 28800;
									toolTip = "Increases mining speed";
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2323)
								{
									name = "Heartreach Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 105;
									buffTime = 28800;
									toolTip = "Increases pickup range for life hearts";
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2324)
								{
									name = "Calming Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 106;
									buffTime = 18000;
									toolTip = "Reduces enemy aggression and spawn rate";
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2325)
								{
									name = "Builder Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 107;
									buffTime = 54000;
									toolTip = "Increases placement speed and range";
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2326)
								{
									name = "Titan Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 108;
									buffTime = 14400;
									toolTip = "Increases knockback";
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2327)
								{
									name = "Flipper Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 109;
									buffTime = 28800;
									toolTip = "Lets you to move swiftly in liquids";
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2328)
								{
									name = "Summoning Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 110;
									buffTime = 21600;
									toolTip = "Increases your max number of minions";
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2329)
								{
									name = "Trapsight Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 111;
									buffTime = 36000;
									toolTip = "Allows you to see nearby traps";
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2330)
								{
									name = "Purple Clubberfish";
									autoReuse = true;
									useStyle = 1;
									useAnimation = 35;
									width = 24;
									height = 28;
									damage = 24;
									knockBack = 7f;
									scale = 1.15f;

									rare = 1;
									value = Item.sellPrice(0, 1, 0, 0);
									melee = true;
									return;
								}
								if (type == 2331)
								{
									name = "Obsidian Swordfish";
									useStyle = 5;
									useAnimation = 20;
									useTime = 20;
									shootSpeed = 4f;
									knockBack = 6.5f;
									width = 40;
									height = 40;
									damage = 70;
									crit = 20;

									shoot = 367;
									rare = 7;
									value = Item.sellPrice(0, 1, 0, 0);
									noMelee = true;
									noUseGraphic = true;
									melee = true;
									return;
								}
								if (type == 2332)
								{
									name = "Swordfish";
									useStyle = 5;
									useAnimation = 20;
									useTime = 20;
									shootSpeed = 4f;
									knockBack = 4.25f;
									width = 40;
									height = 40;
									damage = 19;

									shoot = 368;
									rare = 2;
									value = Item.sellPrice(0, 0, 50, 0);
									noMelee = true;
									noUseGraphic = true;
									melee = true;
									return;
								}
								if (type == 2333)
								{
									name = "Iron Fence";
									useStyle = 1;
									useTurn = true;
									useAnimation = 15;
									useTime = 7;
									autoReuse = true;
									maxStack = 999;
									consumable = true;
									createWall = 145;
									width = 12;
									height = 12;
									return;
								}
								if (type == 2334)
								{
									name = "Wooden Crate";
									width = 12;
									height = 12;
									rare = 1;
									toolTip = "Right click to open";
									maxStack = 99;
									value = Item.sellPrice(0, 0, 10, 0);
									createTile = 376;
									placeStyle = 0;
									useAnimation = 15;
									useTime = 15;
									autoReuse = true;
									useStyle = 1;
									consumable = true;
									return;
								}
								if (type == 2335)
								{
									name = "Iron Crate";
									width = 12;
									height = 12;
									rare = 2;
									toolTip = "Right click to open";
									maxStack = 99;
									value = Item.sellPrice(0, 0, 50, 0);
									createTile = 376;
									placeStyle = 1;
									useAnimation = 15;
									useTime = 15;
									autoReuse = true;
									useStyle = 1;
									consumable = true;
									return;
								}
								if (type == 2336)
								{
									name = "Golden Crate";
									width = 12;
									height = 12;
									rare = 3;
									toolTip = "Right click to open";
									maxStack = 99;
									value = Item.sellPrice(0, 2, 0, 0);
									createTile = 376;
									placeStyle = 2;
									useAnimation = 15;
									useTime = 15;
									autoReuse = true;
									useStyle = 1;
									consumable = true;
									return;
								}
								if (type >= 2337 && type <= 2339)
								{
									name = "Junk";
									width = 12;
									height = 12;
									rare = -1;
									maxStack = 99;
									return;
								}
								if (type == 2340)
								{
									name = "Tracks";
									useStyle = 1;
									useAnimation = 15;
									useTime = 7;
									useTurn = true;
									autoReuse = true;
									width = 16;
									height = 16;
									maxStack = 999;
									createTile = 314;
									placeStyle = 0;
									consumable = true;
									cartTrack = true;
									tileBoost = 5;
									return;
								}
								if (type == 2341)
								{
									name = "Reaver Shark";
									useStyle = 1;
									useTurn = true;
									useAnimation = 22;
									useTime = 18;
									autoReuse = true;
									width = 24;
									height = 28;
									damage = 16;
									pick = 100;
									scale = 1.15f;

									knockBack = 3f;
									rare = 3;
									value = Item.sellPrice(0, 1, 50, 0);
									melee = true;
									return;
								}
								if (type == 2342)
								{
									name = "Sawtooth Shark";
									useStyle = 5;
									useAnimation = 25;
									useTime = 8;
									shootSpeed = 48f;
									knockBack = 2.25f;
									width = 20;
									height = 12;
									damage = 13;
									axe = 14;

									shoot = 369;
									rare = 3;
									value = Item.sellPrice(0, 1, 50, 0);
									noMelee = true;
									noUseGraphic = true;
									melee = true;
									channel = true;
									return;
								}
								if (type == 2343)
								{
									name = "Minecart";
									width = 48;
									height = 28;
									mountType = 6;
									rare = 1;
									value = Item.sellPrice(0, 0, 2, 0);
									return;
								}
								if (type == 2344)
								{
									name = "Ammo Reservation Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 112;
									buffTime = 25200;
									toolTip = "Gives 15% chance to not consume ammo";
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2345)
								{
									name = "Lifeforce Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 113;
									buffTime = 18000;
									toolTip = "Increases max life by 20%";
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2346)
								{
									name = "Endurance Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 114;
									buffTime = 14400;
									toolTip = "Reduces damage taken by 10%";
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2347)
								{
									name = "Rage Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 115;
									buffTime = 14400;
									toolTip = "Increases critical strike chance by 10%";
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2348)
								{
									name = "Inferno Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 116;
									buffTime = 14400;
									toolTip = "Ignites nearby enemies";
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2349)
								{
									name = "Wrath Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 117;
									buffTime = 14400;
									toolTip = "Increases damage by 10%";
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2350)
								{
									name = "Recall Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									toolTip = "Teleports you home";
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2351)
								{
									name = "Teleportation Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									toolTip = "Teleports you to a random location";
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2352)
								{
									useStyle = 1;
									name = "Love Potion";
									shootSpeed = 9f;
									shoot = 370;
									width = 18;
									height = 20;
									maxStack = 99;
									consumable = true;

									useAnimation = 15;
									useTime = 15;
									noUseGraphic = true;
									noMelee = true;
									value = 200;
									toolTip = "Throw at someone to make them fall in love";
									return;
								}
								if (type == 2353)
								{
									useStyle = 1;
									name = "Stink Potion";
									shootSpeed = 9f;
									shoot = 371;
									width = 18;
									height = 20;
									maxStack = 99;
									consumable = true;

									useAnimation = 15;
									useTime = 15;
									noUseGraphic = true;
									noMelee = true;
									value = 200;
									toolTip = "Throw at someone to make them smell terrible";
									return;
								}
								if (type == 2354)
								{
									name = "Fishing Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 121;
									buffTime = 28800;
									toolTip = "Increases fishing skill";
									rare = 1;
									value = 1000;
									return;
								}
								if (type == 2355)
								{
									name = "Sonar Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 122;
									buffTime = 14400;
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2356)
								{
									name = "Crate Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 123;
									buffTime = 10800;
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2357)
								{
									autoReuse = true;
									name = "Shiverthorn Seeds";
									useTurn = true;
									useStyle = 1;
									useAnimation = 15;
									useTime = 10;
									maxStack = 99;
									consumable = true;
									createTile = 82;
									placeStyle = 6;
									width = 12;
									height = 14;
									value = 80;
									return;
								}
								if (type == 2358)
								{
									name = "Shiverthorn";
									maxStack = 99;
									width = 12;
									height = 14;
									value = 100;
									return;
								}
								if (type == 2359)
								{
									name = "Warmth Potion";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 14;
									height = 24;
									buffType = 124;
									buffTime = 54000;
									toolTip = "Reduces damage from cold sources";
									value = 1000;
									rare = 1;
									return;
								}
								if (type == 2360)
								{
									noUseGraphic = true;
									damage = 0;
									useStyle = 5;
									name = "Fish Hook";
									shootSpeed = 13f;
									shoot = 372;
									width = 18;
									height = 28;

									useAnimation = 20;
									useTime = 20;
									rare = 3;
									noMelee = true;
									value = 20000;
									return;
								}
								if (type == 2361)
								{
									name = "Bee Headgear";
									width = 18;
									height = 18;
									defense = 4;
									headSlot = 160;
									rare = 3;
									value = 45000;
									toolTip = "Increases minion damage by 4%";
									return;
								}
								if (type == 2362)
								{
									name = "Bee Breastplate";
									width = 18;
									height = 18;
									defense = 5;
									bodySlot = 168;
									rare = 3;
									value = 30000;
									toolTip = "Increases minion damage by 6%";
									return;
								}
								if (type == 2363)
								{
									name = "Bee Greaves";
									width = 18;
									height = 18;
									defense = 4;
									legSlot = 103;
									rare = 3;
									value = 30000;
									toolTip = "Increases minion damage by 5%";
									return;
								}
								if (type == 2364)
								{
									mana = 10;
									damage = 9;
									useStyle = 1;
									name = "Hornet Staff";
									shootSpeed = 10f;
									shoot = 373;
									width = 26;
									height = 28;

									useAnimation = 22;
									useTime = 22;
									rare = 3;
									noMelee = true;
									knockBack = 2f;
									toolTip = "Summons a hornet to fight for you";
									buffType = 125;
									value = 10000;
									summon = true;
									return;
								}
								if (type == 2365)
								{
									mana = 10;
									damage = 21;
									useStyle = 1;
									name = "Imp Staff";
									shootSpeed = 10f;
									shoot = 375;
									width = 26;
									height = 28;

									useAnimation = 36;
									useTime = 36;
									rare = 3;
									noMelee = true;
									knockBack = 2f;
									toolTip = "Summons an imp to fight for you";
									buffType = 126;
									value = 10000;
									summon = true;
									return;
								}
								if (type == 2366)
								{
									mana = 10;
									damage = 26;
									name = "Spider Queen Staff";
									useStyle = 1;
									shootSpeed = 14f;
									shoot = 377;
									width = 18;
									height = 20;

									useAnimation = 30;
									useTime = 30;
									noMelee = true;
									value = Item.sellPrice(0, 5, 0, 0);
									knockBack = 7.5f;
									rare = 4;
									summon = true;
									sentry = true;
									return;
								}
								if (type == 2367)
								{
									name = "Angler Hat";
									width = 18;
									height = 18;
									defense = 1;
									headSlot = 161;
									rare = 1;
									value = Item.sellPrice(0, 1, 0, 0);
									return;
								}
								if (type == 2368)
								{
									name = "Angler Vest";
									width = 18;
									height = 18;
									bodySlot = 169;
									defense = 2;
									rare = 1;
									value = Item.sellPrice(0, 1, 0, 0);
									return;
								}
								if (type == 2369)
								{
									name = "Angler Pants";
									width = 18;
									height = 18;
									legSlot = 104;
									defense = 1;
									rare = 1;
									value = Item.sellPrice(0, 1, 0, 0);
									return;
								}
								if (type == 2370)
								{
									name = "Spider Mask";
									width = 18;
									height = 18;
									headSlot = 162;
									rare = 4;
									value = Item.sellPrice(0, 0, 75, 0);
									toolTip = "Increases your max number of minions";
									toolTip2 = "Increases minion damage by 5%";
									defense = 5;
									return;
								}
								if (type == 2371)
								{
									name = "Spider Breastplate";
									width = 18;
									height = 18;
									bodySlot = 170;
									rare = 4;
									value = Item.sellPrice(0, 0, 75, 0);
									toolTip = "Increases your max number of minions";
									toolTip2 = "Increases minion damage by 6%";
									defense = 8;
									return;
								}
								if (type == 2372)
								{
									name = "Spider Greaves";
									width = 18;
									height = 18;
									legSlot = 105;
									rare = 4;
									value = Item.sellPrice(0, 0, 75, 0);
									toolTip = "Increases your max number of minions";
									toolTip2 = "Increases minion damage by 6%";
									defense = 7;
									return;
								}
								if (type >= 2373 && type <= 2375)
								{
									name = "Fishing Accessories";
									width = 26;
									height = 30;
									maxStack = 1;
									value = Item.sellPrice(0, 1, 0, 0);
									rare = 1;
									accessory = true;
									return;
								}
								if (type >= 2376 && type <= 2385)
								{
									name = "More Pianos";
									useStyle = 1;
									useTurn = true;
									useAnimation = 15;
									useTime = 10;
									autoReuse = true;
									maxStack = 99;
									consumable = true;
									createTile = 87;
									placeStyle = 11 + type - 2376;
									width = 20;
									height = 20;
									value = 300;
									return;
								}
								if (type >= 2386 && type <= 2396)
								{
									name = "More Dressers";
									useStyle = 1;
									useTurn = true;
									useAnimation = 15;
									useTime = 10;
									autoReuse = true;
									maxStack = 99;
									consumable = true;
									createTile = 88;
									placeStyle = 5 + type - 2386;
									width = 20;
									height = 20;
									value = 300;
									return;
								}
								if (type >= 2397 && type <= 2416)
								{
									name = "Sofas";
									useStyle = 1;
									useTurn = true;
									useAnimation = 15;
									useTime = 10;
									autoReuse = true;
									maxStack = 99;
									consumable = true;
									createTile = 89;
									placeStyle = 1 + type - 2397;
									width = 20;
									height = 20;
									value = 300;
									return;
								}
								if (type == 2417)
								{
									name = "Seashell Hairpin";
									width = 18;
									height = 18;
									headSlot = 163;
									vanity = true;
									value = Item.sellPrice(0, 1, 0, 0);
									return;
								}
								if (type == 2418)
								{
									name = "Mermaid Adornment";
									width = 18;
									height = 18;
									bodySlot = 171;
									vanity = true;
									value = Item.sellPrice(0, 1, 0, 0);
									return;
								}
								if (type == 2419)
								{
									name = "Mermaid Tail";
									width = 18;
									height = 18;
									legSlot = 106;
									vanity = true;
									value = Item.sellPrice(0, 1, 0, 0);
									return;
								}
								if (type == 2420)
								{
									damage = 0;
									useStyle = 1;
									name = "Zephyr Fish";
									shoot = 380;
									width = 16;
									height = 30;

									useAnimation = 20;
									useTime = 20;
									rare = 3;
									noMelee = true;
									toolTip = "Summons a Zephyr Fish";
									value = Item.sellPrice(0, 3, 0, 0);
									buffType = 127;
									return;
								}
								if (type == 2423)
								{
									name = "Frog Leg";
									width = 16;
									height = 24;
									accessory = true;
									rare = 1;
									toolTip = "Increases Jump Speed";
									toolTip2 = "Allows constant jumping";
									value = 50000;
									shoeSlot = 15;
									return;
								}
								if (type == 2424)
								{
									noMelee = true;
									useStyle = 1;
									name = "Anchor";
									shootSpeed = 20f;
									shoot = 383;
									damage = 30;
									knockBack = 5f;
									width = 34;
									height = 34;

									useAnimation = 30;
									useTime = 30;
									noUseGraphic = true;
									rare = 3;
									value = 50000;
									melee = true;
									return;
								}
								if (type >= 2425 && type <= 2427)
								{
									name = "Fishing Food";

									useStyle = 2;
									useTurn = true;
									useAnimation = 17;
									useTime = 17;
									maxStack = 30;
									consumable = true;
									width = 10;
									height = 10;
									buffType = 26;
									buffTime = 72000;
									rare = 1;
									toolTip = "Minor improvements to all stats";
									value = Item.sellPrice(0, 0, 5, 0);
									return;
								}
								if (type == 2428)
								{
									useStyle = 1;
									name = "Fuzzy Carrot";
									width = 16;
									height = 30;

									useAnimation = 20;
									useTime = 20;
									rare = 8;
									noMelee = true;
									mountType = 1;
									value = Item.sellPrice(0, 5, 0, 0);
									return;
								}
								if (type == 2429)
								{
									useStyle = 1;
									name = "Scaly Truffle";
									width = 16;
									height = 30;

									useAnimation = 20;
									useTime = 20;
									rare = 8;
									noMelee = true;
									mountType = 2;
									value = Item.sellPrice(0, 5, 0, 0);
									return;
								}
								if (type == 2430)
								{
									useStyle = 1;
									name = "Slimy Saddle";
									width = 16;
									height = 30;

									useAnimation = 20;
									useTime = 20;
									rare = 8;
									noMelee = true;
									mountType = 3;
									value = Item.sellPrice(0, 5, 0, 0);
									return;
								}
								if (type == 2431)
								{
									name = "Bee Wax";
									width = 18;
									height = 16;
									maxStack = 99;
									value = 100;
									return;
								}
								if (type >= 2432 && type <= 2434)
								{
									name = "Some walls";
									useStyle = 1;
									useTurn = true;
									useAnimation = 15;
									useTime = 7;
									autoReuse = true;
									maxStack = 999;
									consumable = true;
									createWall = 146 + type - 2432;
									width = 12;
									height = 12;
									if (type == 2434)
									{
										value = Item.buyPrice(0, 0, 0, 50);
										return;
									}
								}
								else
								{
									if (type == 2435)
									{
										name = "Coralstone Block";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 315;
										width = 12;
										height = 12;
										value = Item.buyPrice(0, 0, 0, 50);
										return;
									}
									if (type >= 2436 && type <= 2438)
									{
										name = "Jellyfish(es)";
										useStyle = 1;
										autoReuse = true;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										maxStack = 999;
										consumable = true;
										width = 12;
										height = 12;
										noUseGraphic = true;
										bait = 20;
										value = Item.sellPrice(0, 3, 50, 0);
										return;
									}
									if (type >= 2439 && type <= 2441)
									{
										name = "Jellyfish Jar";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 316 + type - 2439;
										width = 12;
										height = 12;
										return;
									}
									if (type >= 2442 && type <= 2449)
									{
										name = "Fishing Wall Hangings";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 240;
										width = 30;
										height = 30;
										value = Item.sellPrice(0, 0, 50, 0);
										placeStyle = 46 + type - 2442;
										return;
									}
									if (type >= 2450 && type <= 2488)
									{
										name = "Quest Fish";
										questItem = true;
										maxStack = 1;
										width = 26;
										height = 26;
										uniqueStack = true;
										rare = -11;
										return;
									}
									if (type == 2489)
									{
										name = "King Slime Trophy";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 240;
										width = 30;
										height = 30;
										value = Item.sellPrice(0, 1, 0, 0);
										placeStyle = 54;
										rare = 1;
										return;
									}
									if (type == 2490)
									{
										name = "Ship in a Bottle";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 319;
										width = 12;
										height = 12;
										value = Item.sellPrice(0, 3, 0, 0);
										return;
									}
									if (type == 2491)
									{
										useStyle = 1;
										name = "Hardy Saddle";
										width = 16;
										height = 30;

										useAnimation = 20;
										useTime = 20;
										rare = 8;
										noMelee = true;
										mountType = 4;
										value = Item.sellPrice(0, 5, 0, 0);
										return;
									}
									if (type == 2492)
									{
										name = "Pressure Track";
										useStyle = 1;
										useAnimation = 15;
										useTime = 7;
										useTurn = true;
										autoReuse = true;
										width = 16;
										height = 16;
										maxStack = 99;
										createTile = 314;
										placeStyle = 1;
										consumable = true;
										cartTrack = true;
										mech = true;
										tileBoost = 2;
										value = Item.sellPrice(0, 0, 10, 0);
										return;
									}
									if (type == 2493)
									{
										name = "King Slime Mask";
										width = 28;
										height = 20;
										headSlot = 164;
										rare = 1;
										vanity = true;
										return;
									}
									if (type == 2494)
									{
										name = "Fin Wings";
										width = 22;
										height = 20;
										accessory = true;
										toolTip = "Allows flight and slow fall";
										value = Item.sellPrice(0, 10, 0, 0);
										rare = 4;
										wingSlot = 25;
										return;
									}
									if (type == 2495)
									{
										name = "Treasure Map";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 242;
										width = 30;
										height = 30;
										value = Item.sellPrice(0, 1, 0, 0);
										placeStyle = 25;
										return;
									}
									if (type == 2496)
									{
										name = "Seaweed Planter";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 320;
										placeStyle = 0;
										width = 22;
										height = 30;
										value = Item.sellPrice(0, 1, 0, 0);
										return;
									}
									if (type == 2497)
									{
										name = "Pillagin Me Pixels";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 242;
										width = 30;
										height = 30;
										value = Item.sellPrice(0, 0, 50, 0);
										placeStyle = 26;
										return;
									}
									if (type == 2498)
									{
										name = "Fish Costume Mask";
										width = 18;
										height = 18;
										headSlot = 165;
										vanity = true;
										value = Item.sellPrice(0, 1, 0, 0);
										return;
									}
									if (type == 2499)
									{
										name = "Fish Costume Shirt";
										width = 18;
										height = 18;
										bodySlot = 172;
										vanity = true;
										value = Item.sellPrice(0, 1, 0, 0);
										return;
									}
									if (type == 2500)
									{
										name = "Fish Costume Finskirt";
										width = 18;
										height = 18;
										legSlot = 107;
										vanity = true;
										value = Item.sellPrice(0, 1, 0, 0);
										return;
									}
									if (type == 2501)
									{
										name = "Ginger Beard";
										width = 18;
										height = 12;
										maxStack = 1;
										value = Item.buyPrice(0, 40, 0, 0);
										rare = 5;
										accessory = true;
										faceSlot = 8;
										vanity = true;
										return;
									}
									if (type == 2502)
									{
										useStyle = 1;
										name = "Honeyed Goggles";
										width = 16;
										height = 30;

										useAnimation = 20;
										useTime = 20;
										rare = 8;
										noMelee = true;
										mountType = 5;
										value = Item.sellPrice(0, 5, 0, 0);
										return;
									}
									if (type == 2503)
									{
										name = "Boreal Wood";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 321;
										width = 8;
										height = 10;
										return;
									}
									if (type == 2504)
									{
										name = "Palm Wood";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 322;
										width = 8;
										height = 10;
										return;
									}
									if (type == 2505)
									{
										name = "Boreal Wood Wall";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 7;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createWall = 149;
										width = 12;
										height = 12;
										return;
									}
									if (type == 2506)
									{
										name = "Palm Wood Wall";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 7;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createWall = 151;
										width = 12;
										height = 12;
										return;
									}
									if (type == 2507)
									{
										name = "Boreal Wood Fence";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 7;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createWall = 150;
										width = 12;
										height = 12;
										return;
									}
									if (type == 2508)
									{
										name = "Palm Wood Fence";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 7;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createWall = 152;
										width = 12;
										height = 12;
										return;
									}
									if (type == 2509)
									{
										name = "Boreal Wood Helmet";
										width = 18;
										height = 18;
										defense = 1;
										headSlot = 166;
										return;
									}
									if (type == 2510)
									{
										name = "Boreal Wood Breastplate";
										width = 18;
										height = 18;
										defense = 1;
										bodySlot = 173;
										return;
									}
									if (type == 2511)
									{
										name = "Boreal Wood Greaves";
										width = 18;
										height = 18;
										defense = 1;
										legSlot = 108;
										return;
									}
									if (type == 2512)
									{
										name = "Palm Wood Helmet";
										width = 18;
										height = 18;
										defense = 1;
										headSlot = 167;
										return;
									}
									if (type == 2513)
									{
										name = "Palm Wood Breastplate";
										width = 18;
										height = 18;
										defense = 1;
										bodySlot = 174;
										return;
									}
									if (type == 2514)
									{
										name = "Palm Wood Greaves";
										width = 18;
										height = 18;
										defense = 1;
										legSlot = 109;
										return;
									}
									if (type == 2517)
									{
										name = "Palm Wood Sword";
										useStyle = 1;
										useTurn = false;
										useAnimation = 23;
										useTime = 23;
										width = 24;
										height = 28;
										damage = 8;
										knockBack = 5f;

										scale = 1f;
										value = 100;
										melee = true;
										return;
									}
									if (type == 2516)
									{
										name = "Palm Wood Hammer";
										autoReuse = true;
										useStyle = 1;
										useTurn = true;
										useAnimation = 33;
										useTime = 23;
										hammer = 35;
										width = 24;
										height = 28;
										damage = 4;
										knockBack = 5.5f;
										scale = 1.1f;

										value = 50;
										melee = true;
										return;
									}
									if (type == 2515)
									{
										name = "Palm Wood Bow";
										useStyle = 5;
										useAnimation = 29;
										useTime = 29;
										width = 12;
										height = 28;
										shoot = 1;
										useAmmo = AmmoID.Arrow;

										damage = 6;
										shootSpeed = 6.6f;
										noMelee = true;
										value = 100;
										ranged = true;
										return;
									}
									if (type == 2518)
									{
										name = "Palm Wood Platform";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 19;
										placeStyle = 17;
										width = 8;
										height = 10;
										return;
									}
									if (type == 2519)
									{
										name = "Palm Wood Bathtub";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 90;
										placeStyle = 17;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2520)
									{
										name = "Palm Wood Bed";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										maxStack = 99;
										consumable = true;
										autoReuse = true;
										createTile = 79;
										placeStyle = 22;
										width = 28;
										height = 20;
										value = 2000;
										return;
									}
									if (type == 2521)
									{
										name = "Palm Wood Bench";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 89;
										placeStyle = 21;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2527)
									{
										name = "Palm Wood Sofa";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 89;
										placeStyle = 22;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2522)
									{
										name = "Palm Wood Candelabra";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 100;
										placeStyle = 18;
										width = 20;
										height = 20;
										value = 1500;
										return;
									}
									if (type == 2523)
									{
										noWet = true;
										name = "Palm Wood Candle";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 33;
										placeStyle = 18;
										width = 8;
										height = 18;
										return;
									}
									if (type == 2524)
									{
										name = "Palm Wood Chair";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 15;
										placeStyle = 29;
										width = 12;
										height = 30;
										return;
									}
									if (type == 2525)
									{
										name = "Palm Wood Chandelier";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 34;
										placeStyle = 23;
										width = 26;
										height = 26;
										value = 3000;
										return;
									}
									if (type == 2526)
									{
										name = "Palm Wood Chest";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 21;
										placeStyle = 31;
										width = 26;
										height = 22;
										value = 500;
										return;
									}
									if (type == 2528)
									{
										name = "Palm Wood Door";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										maxStack = 99;
										consumable = true;
										createTile = 10;
										placeStyle = 29;
										width = 14;
										height = 28;
										value = 200;
										return;
									}
									if (type == 2529)
									{
										name = "Palm Wood Dresser";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 88;
										placeStyle = 16;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2530)
									{
										name = "Palm Wood Lantern";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 42;
										width = 12;
										height = 28;
										placeStyle = 27;
										return;
									}
									if (type == 2531)
									{
										name = "Palm Wood Piano";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 87;
										placeStyle = 21;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2535)
									{
										mana = 10;
										damage = 30;
										useStyle = 1;
										name = "Optic Staff";
										shootSpeed = 10f;
										shoot = 387;
										width = 26;
										height = 28;

										useAnimation = 36;
										useTime = 36;
										rare = 5;
										noMelee = true;
										knockBack = 2f;
										toolTip = "Summons twins to fight for you";
										buffType = 134;
										value = Item.buyPrice(0, 10, 0, 0);
										summon = true;
										return;
									}
									if (type == 2532)
									{
										name = "Palm Wood Table";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 14;
										placeStyle = 26;
										width = 26;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2533)
									{
										name = "Palm Wood Lamp";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 93;
										placeStyle = 18;
										width = 10;
										height = 24;
										value = 500;
										return;
									}
									if (type == 2534)
									{
										name = "Palm Wood Work Bench";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 18;
										placeStyle = 22;
										width = 28;
										height = 14;
										value = 150;
										toolTip = "Used for basic crafting";
										return;
									}
									if (type == 2536)
									{
										name = "Palm Wood Bookcase";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 101;
										width = 20;
										height = 20;
										value = 300;
										placeStyle = 23;
										return;
									}
									if (type == 2549)
									{
										name = "Mushroom Platform";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 19;
										placeStyle = 18;
										width = 8;
										height = 10;
										return;
									}
									if (type == 2537)
									{
										name = "Mushroom Bathtub";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 90;
										placeStyle = 18;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2538)
									{
										name = "Mushroom Bed";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										maxStack = 99;
										consumable = true;
										autoReuse = true;
										createTile = 79;
										placeStyle = 23;
										width = 28;
										height = 20;
										value = 2000;
										return;
									}
									if (type == 2539)
									{
										name = "Mushroom Bench";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 89;
										placeStyle = 23;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2540)
									{
										name = "Mushroom Bookcase";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 101;
										width = 20;
										height = 20;
										value = 300;
										placeStyle = 24;
										return;
									}
									if (type == 2541)
									{
										name = "Mushroom Candelabra";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 100;
										placeStyle = 19;
										width = 20;
										height = 20;
										value = 1500;
										return;
									}
									if (type == 2542)
									{
										noWet = true;
										name = "Mushroom Candle";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 33;
										placeStyle = 19;
										width = 8;
										height = 18;
										return;
									}
									if (type == 2543)
									{
										name = "Mushroom Chandelier";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 34;
										placeStyle = 24;
										width = 26;
										height = 26;
										value = 3000;
										return;
									}
									if (type == 2544)
									{
										name = "Mushroom Chest";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 21;
										placeStyle = 32;
										width = 26;
										height = 22;
										value = 500;
										return;
									}
									if (type == 2545)
									{
										name = "Mushroom Dresser";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 88;
										placeStyle = 17;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2547)
									{
										name = "Mushroom Lamp";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 93;
										placeStyle = 19;
										width = 10;
										height = 24;
										value = 500;
										return;
									}
									if (type == 2546)
									{
										name = "Mushroom Lantern";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 42;
										width = 12;
										height = 28;
										placeStyle = 28;
										return;
									}
									if (type == 2548)
									{
										name = "Mushroom Piano";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 87;
										placeStyle = 22;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2413)
									{
										name = "Mushroom Sofa";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 89;
										placeStyle = 23;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2550)
									{
										name = "Mushroom Table";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 14;
										placeStyle = 27;
										width = 26;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2551)
									{
										mana = 10;
										damage = 26;
										useStyle = 1;
										name = "Spider Staff";
										shootSpeed = 10f;
										shoot = 390;
										width = 26;
										height = 28;

										useAnimation = 36;
										useTime = 36;
										rare = 4;
										noMelee = true;
										knockBack = 3f;
										toolTip = "Summons spiders to fight for you";
										buffType = 133;
										value = Item.buyPrice(0, 5, 0, 0);
										summon = true;
										return;
									}
									if (type == 2552)
									{
										name = "Boreal Wood Bathtub";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 90;
										placeStyle = 19;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2553)
									{
										name = "Boreal Wood Bed";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										maxStack = 99;
										consumable = true;
										autoReuse = true;
										createTile = 79;
										placeStyle = 24;
										width = 28;
										height = 20;
										value = 2000;
										return;
									}
									if (type == 2554)
									{
										name = "Boreal Wood Bookcase";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 101;
										width = 20;
										height = 20;
										value = 300;
										placeStyle = 25;
										return;
									}
									if (type == 2555)
									{
										name = "Boreal Wood Candelabra";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 100;
										placeStyle = 20;
										width = 20;
										height = 20;
										value = 1500;
										return;
									}
									if (type == 2556)
									{
										noWet = true;
										name = "Boreal Wood Candle";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 33;
										placeStyle = 20;
										width = 8;
										height = 18;
										return;
									}
									if (type == 2557)
									{
										name = "Boreal Wood Chair";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 15;
										placeStyle = 30;
										width = 12;
										height = 30;
										return;
									}
									if (type == 2558)
									{
										name = "Boreal Wood Chandelier";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 34;
										placeStyle = 25;
										width = 26;
										height = 26;
										value = 3000;
										return;
									}
									if (type == 2559)
									{
										name = "Boreal Wood Chest";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 21;
										placeStyle = 33;
										width = 26;
										height = 22;
										value = 500;
										return;
									}
									if (type == 2560)
									{
										name = "Boreal Wood Clock";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 104;
										placeStyle = 6;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2561)
									{
										name = "Boreal Wood Door";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										maxStack = 99;
										consumable = true;
										createTile = 10;
										placeStyle = 30;
										width = 14;
										height = 28;
										value = 200;
										return;
									}
									if (type == 2562)
									{
										name = "Boreal Wood Dresser";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 88;
										placeStyle = 18;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2563)
									{
										name = "Boreal Wood Lamp";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 93;
										placeStyle = 20;
										width = 10;
										height = 24;
										value = 500;
										return;
									}
									if (type == 2564)
									{
										name = "Boreal Wood Lantern";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 42;
										placeStyle = 29;
										width = 12;
										height = 28;
										return;
									}
									if (type == 2565)
									{
										name = "Boreal Wood Piano";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 87;
										placeStyle = 23;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2566)
									{
										name = "Boreal Wood Platform";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 19;
										placeStyle = 19;
										width = 8;
										height = 10;
										return;
									}
									if (type == 2567)
									{
										name = "Slime Bathtub";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 90;
										placeStyle = 20;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2568)
									{
										name = "Slime Bed";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										maxStack = 99;
										consumable = true;
										autoReuse = true;
										createTile = 79;
										placeStyle = 25;
										width = 28;
										height = 20;
										value = 2000;
										return;
									}
									if (type == 2569)
									{
										name = "Slime Bookcase";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 101;
										placeStyle = 26;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2570)
									{
										name = "Slime Candelabra";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 100;
										placeStyle = 21;
										width = 20;
										height = 20;
										value = 1500;
										return;
									}
									if (type == 2571)
									{
										noWet = true;
										name = "Slime Candle";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 33;
										placeStyle = 21;
										width = 8;
										height = 18;
										return;
									}
									if (type == 2572)
									{
										name = "Slime Chair";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 15;
										placeStyle = 31;
										width = 12;
										height = 30;
										return;
									}
									if (type == 2573)
									{
										name = "Slime Chandelier";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 34;
										placeStyle = 26;
										width = 26;
										height = 26;
										value = 3000;
										return;
									}
									if (type == 2574)
									{
										name = "Slime Chest";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 21;
										placeStyle = 34;
										width = 26;
										height = 22;
										value = 500;
										return;
									}
									if (type == 2575)
									{
										name = "Slime Clock";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 104;
										placeStyle = 7;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2576)
									{
										name = "Slime Door";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										maxStack = 99;
										consumable = true;
										createTile = 10;
										placeStyle = 31;
										width = 14;
										height = 28;
										value = 200;
										return;
									}
									if (type == 2577)
									{
										name = "Slime Dresser";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 88;
										placeStyle = 19;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2578)
									{
										name = "Slime Lamp";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 93;
										placeStyle = 21;
										width = 10;
										height = 24;
										value = 500;
										return;
									}
									if (type == 2579)
									{
										name = "Slime Lantern";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 42;
										placeStyle = 30;
										width = 12;
										height = 28;
										return;
									}
									if (type == 2580)
									{
										name = "Slime Piano";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 87;
										placeStyle = 24;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2581)
									{
										name = "Slime Platform";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 19;
										placeStyle = 20;
										width = 8;
										height = 10;
										return;
									}
									if (type == 2582)
									{
										name = "Slime Sofa";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 89;
										placeStyle = 25;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2583)
									{
										name = "Slime Table";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 14;
										placeStyle = 29;
										width = 26;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2584)
									{
										mana = 10;
										damage = 40;
										useStyle = 1;
										name = "Pirate Staff";
										shootSpeed = 10f;
										shoot = 393;
										width = 26;
										height = 28;

										useAnimation = 36;
										useTime = 36;
										rare = 5;
										noMelee = true;
										knockBack = 6f;
										toolTip = "Summons pirates to fight for you";
										buffType = 135;
										value = Item.buyPrice(0, 5, 0, 0);
										summon = true;
										return;
									}
									if (type == 2585)
									{
										noUseGraphic = true;
										damage = 0;
										useStyle = 5;
										name = "Slime Hook";
										shootSpeed = 13f;
										shoot = 396;
										width = 18;
										height = 28;

										useAnimation = 20;
										useTime = 20;
										rare = 3;
										noMelee = true;
										value = 20000;
										return;
									}
									if (type == 2586)
									{
										useStyle = 5;
										name = "Sticky Grenade";
										shootSpeed = 5.5f;
										shoot = 397;
										width = 20;
										height = 20;
										maxStack = 99;
										consumable = true;

										useAnimation = 45;
										useTime = 45;
										noUseGraphic = true;
										noMelee = true;
										value = 75;
										damage = 60;
										knockBack = 8f;
										toolTip = "A small explosion that will not destroy tiles";
										toolTip2 = "Tossing may be difficult";
										thrown = true;
										return;
									}
									if (type == 2587)
									{
										damage = 0;
										useStyle = 1;
										name = "Tartar Sauce";
										shoot = 398;
										width = 16;
										height = 30;

										useAnimation = 20;
										useTime = 20;
										rare = 3;
										noMelee = true;
										toolTip = "Summons a mini minotaur";
										buffType = 136;
										value = Item.sellPrice(0, 2, 0, 0);
										return;
									}
									if (type == 2588)
									{
										name = "Duke Fishron Mask";
										width = 28;
										height = 20;
										headSlot = 168;
										rare = 1;
										vanity = true;
										return;
									}
									if (type == 2589)
									{
										name = "Duke Fishron Trophy";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 240;
										width = 30;
										height = 30;
										value = Item.sellPrice(0, 1, 0, 0);
										placeStyle = 55;
										rare = 1;
										return;
									}
									if (type == 2590)
									{
										useStyle = 5;
										name = "Molotov Cocktail";
										shootSpeed = 6.5f;
										shoot = 399;
										width = 20;
										height = 20;
										maxStack = 99;
										consumable = true;

										useAnimation = 40;
										useTime = 40;
										noUseGraphic = true;
										noMelee = true;
										value = Item.sellPrice(0, 0, 1, 0);
										damage = 23;
										knockBack = 7f;
										toolTip = "A small explosion that puts enemies on fire";
										toolTip2 = "Lights nearby area on fire for a while";
										thrown = true;
										rare = 1;
										return;
									}
									if (type >= 2591 && type <= 2606)
									{
										name = "Grandfather Clock";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 104;
										placeStyle = 8 + type - 2591;
										width = 20;
										height = 20;
										value = 300;
										return;
									}
									if (type == 2607)
									{
										name = "Spider Fang";
										maxStack = 99;
										width = 12;
										height = 12;
										rare = 4;
										value = Item.sellPrice(0, 0, 5, 0);
										return;
									}
									if (type == 2608)
									{
										autoReuse = true;
										scale = 1.05f;
										name = "Falcon Blade";
										useStyle = 1;
										useAnimation = 15;
										knockBack = 6f;
										width = 24;
										height = 28;
										damage = 30;
										scale = 1.05f;

										rare = 4;
										value = 10000;
										melee = true;
										return;
									}
									if (type == 2609)
									{
										name = "Fishron Wings";
										width = 22;
										height = 20;
										accessory = true;
										toolTip = "Allows flight and slow fall";
										value = Item.buyPrice(0, 10, 0, 0);
										rare = 8;
										wingSlot = 26;
										return;
									}
									if (type == 2610)
									{
										name = "Slime Gun";
										useStyle = 5;
										useAnimation = 12;
										useTime = 12;
										width = 38;
										height = 10;
										damage = 0;
										scale = 0.9f;
										shoot = 406;
										shootSpeed = 8f;
										autoReuse = true;
										value = Item.buyPrice(0, 1, 50, 0);
										return;
									}
									if (type == 2611)
									{
										autoReuse = false;
										name = "Flairon";
										useStyle = 5;
										useAnimation = 20;
										useTime = 20;
										autoReuse = true;
										knockBack = 4.5f;
										width = 30;
										height = 10;
										damage = 66;
										shoot = 404;
										shootSpeed = 14f;

										rare = 8;
										value = Item.sellPrice(0, 5, 0, 0);
										melee = true;
										noUseGraphic = true;
										return;
									}
									if (type >= 2612 && type <= 2620)
									{
										name = "Many Chests";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 21;
										if (type <= 2614)
										{
											placeStyle = 35 + (type - 2612) * 2;
										}
										else
										{
											placeStyle = 41 + type - 2615;
										}
										width = 26;
										height = 22;
										value = 500;
										return;
									}
									if (type == 2621)
									{
										mana = 10;
										damage = 50;
										useStyle = 1;
										name = "Tempest Staff";
										shootSpeed = 10f;
										shoot = 407;
										width = 26;
										height = 28;

										useAnimation = 36;
										useTime = 36;
										rare = 8;
										noMelee = true;
										knockBack = 2f;
										toolTip = "Summons sharknados to fight for you";
										buffType = 139;
										value = Item.sellPrice(0, 5, 0, 0);
										summon = true;
										return;
									}
									if (type == 2624)
									{
										useStyle = 5;
										autoReuse = true;
										useAnimation = 24;
										useTime = 24;
										name = "Tsunami";
										width = 50;
										height = 18;
										shoot = 1;
										useAmmo = AmmoID.Arrow;

										damage = 60;
										shootSpeed = 10f;
										noMelee = true;
										value = Item.sellPrice(0, 5, 0, 0);
										ranged = true;
										rare = 8;
										knockBack = 2f;
										return;
									}
									if (type == 2622)
									{
										mana = 16;
										damage = 60;
										useStyle = 5;
										name = "Razorblade Typhoon";
										shootSpeed = 6f;
										shoot = 409;
										width = 26;
										height = 28;

										useAnimation = 40;
										useTime = 20;
										autoReuse = true;
										rare = 8;
										noMelee = true;
										knockBack = 5f;
										scale = 0.9f;
										toolTip = "Casts a typhoon";
										value = Item.sellPrice(0, 5, 0, 0);
										magic = true;
										return;
									}
									if (type == 2625 || type == 2626)
									{
										name = "Beach Stuff";
										useStyle = 1;
										autoReuse = true;
										useAnimation = 15;
										useTime = 10;
										maxStack = 99;
										consumable = true;
										createTile = 324;
										if (type == 2626)
										{
											placeStyle = 1;
											width = 26;
											height = 24;
											return;
										}
										width = 22;
										height = 22;
										return;
									}
									else
									{
										if (type >= 2627 && type <= 2630)
										{
											name = "More Platforms";
											useStyle = 1;
											useTurn = true;
											useAnimation = 15;
											useTime = 10;
											autoReuse = true;
											maxStack = 999;
											consumable = true;
											createTile = 19;
											placeStyle = 21 + type - 2627;
											width = 8;
											height = 10;
											return;
										}
										if (type >= 2631 && type <= 2633)
										{
											name = "More Work Benches";
											useStyle = 1;
											useTurn = true;
											useAnimation = 15;
											useTime = 10;
											autoReuse = true;
											maxStack = 99;
											consumable = true;
											createTile = 18;
											placeStyle = 24 + type - 2631;
											width = 28;
											height = 14;
											value = 150;
											toolTip = "Used for basic crafting";
											return;
										}
										if (type >= 2634 && type <= 2636)
										{
											name = "Sofas";
											useStyle = 1;
											useTurn = true;
											useAnimation = 15;
											useTime = 10;
											autoReuse = true;
											maxStack = 99;
											consumable = true;
											createTile = 89;
											placeStyle = 26 + type - 2634;
											width = 20;
											height = 20;
											value = 300;
											return;
										}
										if (type == 2623)
										{
											autoReuse = true;
											name = "Bubble Gun";
											mana = 4;

											useStyle = 5;
											damage = 70;
											useAnimation = 9;
											useTime = 9;
											width = 40;
											height = 40;
											shoot = 410;
											shootSpeed = 11f;
											knockBack = 3f;
											value = Item.sellPrice(0, 5, 0, 0);
											magic = true;
											rare = 8;
											noMelee = true;
											return;
										}
										if (type >= 2637 && type <= 2640)
										{
											name = "Dressers";
											useStyle = 1;
											useTurn = true;
											useAnimation = 15;
											useTime = 10;
											autoReuse = true;
											maxStack = 99;
											consumable = true;
											createTile = 88;
											placeStyle = 20 + type - 2637;
											width = 20;
											height = 20;
											value = 300;
											return;
										}
										if (type == 2641 || type == 2642)
										{
											name = "Lantern 1";
											useStyle = 1;
											useTurn = true;
											useAnimation = 15;
											useTime = 10;
											autoReuse = true;
											maxStack = 999;
											consumable = true;
											createTile = 42;
											if (type == 2641)
											{
												placeStyle = 31;
											}
											else
											{
												placeStyle = 32;
											}
											width = 12;
											height = 28;
											return;
										}
										if (type >= 2643 && type <= 2647)
										{
											name = "More Lamps";
											useStyle = 1;
											useTurn = true;
											useAnimation = 15;
											useTime = 10;
											autoReuse = true;
											maxStack = 99;
											consumable = true;
											createTile = 93;
											placeStyle = 22 + type - 2643;
											width = 10;
											height = 24;
											value = 500;
											return;
										}
										if (type >= 2648 && type <= 2651)
										{
											noWet = true;
											name = "even more candles";
											useStyle = 1;
											useTurn = true;
											useAnimation = 15;
											useTime = 10;
											autoReuse = true;
											maxStack = 99;
											consumable = true;
											createTile = 33;
											width = 8;
											height = 18;
											placeStyle = 22 + type - 2648;
											return;
										}
										if (type >= 2652 && type <= 2657)
										{
											name = "More Chandeliers";
											useStyle = 1;
											useTurn = true;
											useAnimation = 15;
											useTime = 10;
											autoReuse = true;
											maxStack = 99;
											consumable = true;
											createTile = 34;
											placeStyle = 27 + type - 2652;
											width = 26;
											height = 26;
											value = 3000;
											return;
										}
										if (type >= 2658 && type <= 2663)
										{
											name = "more bathtubs";
											useStyle = 1;
											useTurn = true;
											useAnimation = 15;
											useTime = 10;
											autoReuse = true;
											maxStack = 99;
											consumable = true;
											createTile = 90;
											placeStyle = 21 + type - 2658;
											width = 20;
											height = 20;
											value = 300;
											return;
										}
										if (type >= 2664 && type <= 2668)
										{
											name = "even more candelabras";
											useStyle = 1;
											useTurn = true;
											useAnimation = 15;
											useTime = 10;
											autoReuse = true;
											maxStack = 99;
											consumable = true;
											createTile = 100;
											placeStyle = 22 + type - 2664;
											width = 20;
											height = 20;
											value = 1500;
											return;
										}
										if (type == 2669)
										{
											name = "Pumpkin Bed";
											useStyle = 1;
											useTurn = true;
											useAnimation = 15;
											useTime = 10;
											maxStack = 99;
											consumable = true;
											autoReuse = true;
											createTile = 79;
											placeStyle = 26;
											width = 28;
											height = 20;
											value = 2000;
											return;
										}
										if (type == 2670)
										{
											name = "Pumpkin Bookcase";
											useStyle = 1;
											useTurn = true;
											useAnimation = 15;
											useTime = 10;
											autoReuse = true;
											maxStack = 99;
											consumable = true;
											createTile = 101;
											width = 20;
											height = 20;
											value = 300;
											placeStyle = 27;
											return;
										}
										if (type == 2671)
										{
											name = "Pumpkin Piano";
											useStyle = 1;
											useTurn = true;
											useAnimation = 15;
											useTime = 10;
											autoReuse = true;
											maxStack = 99;
											consumable = true;
											createTile = 87;
											placeStyle = 25;
											width = 20;
											height = 20;
											value = 300;
											return;
										}
										if (type == 2672)
										{
											name = "Shark Statue";
											useStyle = 1;
											useTurn = true;
											useAnimation = 15;
											useTime = 10;
											autoReuse = true;
											maxStack = 99;
											consumable = true;
											createTile = 105;
											width = 20;
											height = 20;
											value = 300;
											placeStyle = 50;
											return;
										}
										if (type == 2673)
										{
											name = "Truffle Worm";
											useStyle = 1;
											autoReuse = true;
											useTurn = true;
											useAnimation = 15;
											useTime = 10;
											maxStack = 999;
											consumable = true;
											width = 12;
											height = 12;
											makeNPC = 374;
											noUseGraphic = true;
											bait = 666;
											return;
										}
										if (type >= 2674 && type <= 2676)
										{
											name = "baits";
											maxStack = 999;
											consumable = true;
											width = 12;
											height = 12;
											if (type == 2675)
											{
												bait = 30;
												value = Item.sellPrice(0, 0, 3, 0);
												return;
											}
											if (type == 2676)
											{
												bait = 50;
												value = Item.sellPrice(0, 0, 10, 0);
												return;
											}
											bait = 15;
											value = Item.sellPrice(0, 0, 1, 0);
											return;
										}
										else
										{
											if (type >= 2677 && type <= 2690)
											{
												name = "gemspark walls";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												switch (type)
												{
													case 2677:
														createWall = 153;
														break;
													case 2678:
														createWall = 157;
														break;
													case 2679:
														createWall = 154;
														break;
													case 2680:
														createWall = 158;
														break;
													case 2681:
														createWall = 155;
														break;
													case 2682:
														createWall = 159;
														break;
													case 2683:
														createWall = 156;
														break;
													case 2684:
														createWall = 160;
														break;
													case 2685:
														createWall = 164;
														break;
													case 2686:
														createWall = 161;
														break;
													case 2687:
														createWall = 165;
														break;
													case 2688:
														createWall = 162;
														break;
													case 2689:
														createWall = 166;
														break;
													case 2690:
														createWall = 163;
														break;
												}
												width = 12;
												height = 12;
												return;
											}
											if (type == 2691)
											{
												name = "Tin Plating Wall";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 7;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createWall = 167;
												width = 12;
												height = 12;
												return;
											}
											if (type == 2692)
											{
												name = "Tin Plating";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createTile = 325;
												width = 12;
												height = 12;
												return;
											}
											if (type == 2693)
											{
												name = "Waterfall Block";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createTile = 326;
												width = 12;
												height = 12;
												return;
											}
											if (type == 2694)
											{
												name = "Lavafall Block";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createTile = 327;
												width = 12;
												height = 12;
												return;
											}
											if (type == 2695)
											{
												name = "Confetti Block";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createTile = 328;
												width = 12;
												height = 12;
												return;
											}
											if (type == 2696)
											{
												name = "Confetti Wall";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 7;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createWall = 168;
												width = 12;
												height = 12;
												return;
											}
											if (type == 2697)
											{
												name = "Confetti Block";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createTile = 329;
												width = 12;
												height = 12;
												return;
											}
											if (type == 2698)
											{
												name = "Confetti Wall";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 7;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createWall = 169;
												width = 12;
												height = 12;
												return;
											}
											if (type == 2699)
											{
												name = "Weapon Rack";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 334;
												width = 30;
												height = 30;
												value = Item.sellPrice(0, 0, 0, 50);
												return;
											}
											if (type == 2700)
											{
												name = "Fireworks Box";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 335;
												width = 26;
												height = 22;
												value = Item.buyPrice(0, 5, 0, 0);
												mech = true;
												return;
											}
											if (type == 2701)
											{
												name = "Living Fire Block";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createTile = 336;
												width = 12;
												height = 12;
												return;
											}
											if (type >= 2702 && type <= 2737)
											{
												name = "statues";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 337;
												width = 20;
												height = 20;
												value = 300;
												placeStyle = type - 2702;
												return;
											}
											if (type == 2738)
											{
												name = "Firework Fountain";
												createTile = 338;
												placeStyle = 0;
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												width = 12;
												height = 30;
												value = Item.buyPrice(0, 3, 0, 0);
												mech = true;
												return;
											}
											if (type == 2739)
											{
												name = "Booster Track";
												useStyle = 1;
												useAnimation = 15;
												useTime = 7;
												useTurn = true;
												autoReuse = true;
												width = 16;
												height = 16;
												maxStack = 99;
												createTile = 314;
												placeStyle = 2;
												consumable = true;
												cartTrack = true;
												mech = true;
												tileBoost = 2;
												value = Item.buyPrice(0, 0, 50, 0);
												return;
											}
											if (type == 2740)
											{
												name = "Grasshopper";
												useStyle = 1;
												autoReuse = true;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												maxStack = 999;
												consumable = true;
												width = 12;
												height = 12;
												makeNPC = 377;
												noUseGraphic = true;
												bait = 10;
												return;
											}
											if (type == 2741)
											{
												name = "Critter Cage";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 339;
												width = 12;
												height = 12;
												return;
											}
											if (type == 2742)
											{
												name = "Music Box (Underground Crimson)";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												consumable = true;
												createTile = 139;
												placeStyle = 31;
												width = 24;
												height = 24;
												rare = 4;
												value = 100000;
												accessory = true;
												return;
											}
											if (type == 2743)
											{
												name = "Cactus Table";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 14;
												placeStyle = 30;
												width = 26;
												height = 20;
												value = 300;
												return;
											}
											if (type == 2744)
											{
												name = "Cactus Platform";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createTile = 19;
												placeStyle = 25;
												width = 8;
												height = 10;
												return;
											}
											if (type == 2745)
											{
												name = "Boreal Wood Sword";
												useStyle = 1;
												useTurn = false;
												useAnimation = 23;
												useTime = 23;
												width = 24;
												height = 28;
												damage = 8;
												knockBack = 5f;

												scale = 1f;
												value = 100;
												melee = true;
												return;
											}
											if (type == 2746)
											{
												name = "Boreal Wood Hammer";
												autoReuse = true;
												useStyle = 1;
												useTurn = true;
												useAnimation = 33;
												useTime = 23;
												hammer = 35;
												width = 24;
												height = 28;
												damage = 4;
												knockBack = 5.5f;
												scale = 1.1f;

												value = 50;
												melee = true;
												return;
											}
											if (type == 2747)
											{
												name = "Boreal Wood Bow";
												useStyle = 5;
												useAnimation = 29;
												useTime = 29;
												width = 12;
												height = 28;
												shoot = 1;
												useAmmo = AmmoID.Arrow;

												damage = 6;
												shootSpeed = 6.6f;
												noMelee = true;
												value = 100;
												ranged = true;
												return;
											}
											if (type == 2748)
											{
												name = "Glass Chest";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 21;
												placeStyle = 47;
												width = 26;
												height = 22;
												value = 500;
												return;
											}
											if (type == 2749)
											{
												mana = 10;
												damage = 36;
												useStyle = 1;
												name = "Xeno Staff";
												shootSpeed = 10f;
												shoot = 423;
												width = 26;
												height = 28;

												useAnimation = 36;
												useTime = 36;
												rare = 8;
												noMelee = true;
												knockBack = 2f;
												toolTip = "Summons a UFO to fight for you";
												buffType = 140;
												value = 10000;
												summon = true;
												return;
											}
											if (type == 2750)
											{
												autoReuse = true;
												name = "Meteor Staff";
												mana = 13;
												useStyle = 5;
												damage = 50;
												useAnimation = 10;
												useTime = 10;
												width = 40;
												height = 40;
												shoot = 424;
												shootSpeed = 10f;
												knockBack = 4.5f;
												value = Item.sellPrice(0, 2, 0, 0);
												magic = true;
												rare = 5;
												noMelee = true;

												return;
											}
											if (type >= 2751 && type <= 2755)
											{
												name = "Living Fire Block";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createTile = 340 + type - 2751;
												width = 12;
												height = 12;
												return;
											}
											if (type == 2756)
											{
												name = "Gender Change Potion";

												useStyle = 2;
												useTurn = true;
												useAnimation = 17;
												useTime = 17;
												maxStack = 30;
												consumable = true;
												width = 14;
												height = 24;
												value = 1000;
												rare = 1;
												return;
											}
											if (type == 2757)
											{
												name = "Vortex Helmet";
												width = 18;
												height = 18;
												defense = 14;
												headSlot = 169;
												glowMask = 26;
												rare = 10;
												return;
											}
											if (type == 2758)
											{
												name = "Vortex Breastplate";
												width = 18;
												height = 18;
												defense = 28;
												bodySlot = 175;
												glowMask = 27;
												rare = 10;
												return;
											}
											if (type == 2759)
											{
												name = "Vortex Leggings";
												width = 18;
												height = 18;
												defense = 20;
												legSlot = 110;
												rare = 10;
												return;
											}
											if (type == 2760)
											{
												name = "Nebula Helmet";
												width = 18;
												height = 18;
												defense = 14;
												headSlot = 170;
												glowMask = 28;
												rare = 10;
												return;
											}
											if (type == 2761)
											{
												name = "Nebula Breastplate";
												width = 18;
												height = 18;
												defense = 18;
												bodySlot = 176;
												glowMask = 29;
												rare = 10;
												return;
											}
											if (type == 2762)
											{
												name = "Nebula Leggings";
												width = 18;
												height = 18;
												defense = 14;
												legSlot = 111;
												glowMask = 30;
												rare = 10;
												return;
											}
											if (type == 2763)
											{
												name = "Solar Flare Helmet";
												width = 18;
												height = 18;
												defense = 24;
												headSlot = 171;
												rare = 10;
												return;
											}
											if (type == 2764)
											{
												name = "Solar Flare Breastplate";
												width = 18;
												height = 18;
												defense = 34;
												bodySlot = 177;
												rare = 10;
												return;
											}
											if (type == 2765)
											{
												name = "Solar Flare Leggings";
												width = 18;
												height = 18;
												defense = 20;
												legSlot = 112;
												rare = 10;
												return;
											}
											if (type == 2767)
											{
												useStyle = 4;
												name = "Lunar Tablet";
												width = 22;
												height = 14;
												consumable = true;
												useAnimation = 45;
												useTime = 45;
												maxStack = 20;
												toolTip = "Summons the Eclipse";
												rare = 8;
												return;
											}
											if (type == 2766)
											{
												name = "Lunar Tablet Fragment";
												width = 22;
												height = 14;
												maxStack = 99;
												toolTip = "Power pulses weakly in the fragment";
												rare = 8;
												return;
											}
											if (type == 2770)
											{
												name = "Mothron Wings";
												width = 22;
												height = 20;
												accessory = true;
												toolTip = "Allows flight and slow fall";
												value = 400000;
												rare = 8;
												wingSlot = 27;
												return;
											}
											if (type == 2769)
											{
												useStyle = 1;
												name = "Cosmic Car Key";
												width = 32;
												height = 30;

												useAnimation = 20;
												useTime = 20;
												rare = 8;
												noMelee = true;
												mountType = 7;
												value = Item.sellPrice(0, 5, 0, 0);
												return;
											}
											if (type == 2768)
											{
												useStyle = 1;
												name = "Drill Containment Unit";
												width = 32;
												height = 30;

												useAnimation = 20;
												useTime = 20;
												rare = 8;
												noMelee = true;
												mountType = 8;
												value = Item.sellPrice(0, 5, 0, 0);
												return;
											}
											if (type == 2771)
											{
												useStyle = 1;
												name = "Brain Scrambler";
												channel = true;
												width = 34;
												height = 34;

												useAnimation = 20;
												useTime = 20;
												rare = 8;
												noMelee = true;
												mountType = 9;
												value = Item.sellPrice(0, 5, 0, 0);
												return;
											}
											if (type == 2772)
											{
												name = "Vortex Axe";
												autoReuse = true;
												useStyle = 1;
												useAnimation = 25;
												knockBack = 6f;
												useTime = 7;
												width = 54;
												height = 54;
												damage = 100;
												axe = 27;

												rare = 10;
												scale = 1.05f;
												value = Item.sellPrice(0, 5, 0, 0);
												melee = true;
												glowMask = 1;
												tileBoost += 4;
												return;
											}
											if (type == 2773)
											{
												name = "Vortex Chainsaw";
												useStyle = 5;
												useAnimation = 25;
												useTime = 7;
												shootSpeed = 28f;
												knockBack = 4f;
												width = 56;
												height = 22;
												damage = 80;
												axe = 27;

												shoot = 427;
												rare = 10;
												value = Item.sellPrice(0, 5, 0, 0);
												noMelee = true;
												noUseGraphic = true;
												melee = true;
												channel = true;
												glowMask = 20;
												tileBoost += 4;
												return;
											}
											if (type == 2774)
											{
												name = "Vortex Drill";
												useStyle = 5;
												useAnimation = 25;
												useTime = 9;
												shootSpeed = 32f;
												knockBack = 0f;
												width = 54;
												height = 26;
												damage = 50;
												pick = 225;

												shoot = 428;
												rare = 10;
												value = Item.sellPrice(0, 5, 0, 0);
												noMelee = true;
												noUseGraphic = true;
												melee = true;
												channel = true;
												glowMask = 21;
												tileBoost += 4;
												return;
											}
											if (type == 2776)
											{
												name = "Vortex Pickaxe";
												useStyle = 1;
												useAnimation = 12;
												useTime = 6;
												knockBack = 5.5f;
												useTurn = true;
												autoReuse = true;
												width = 36;
												height = 36;
												damage = 80;
												pick = 225;

												rare = 10;
												value = Item.sellPrice(0, 5, 0, 0);
												melee = true;
												glowMask = 5;
												tileBoost += 4;
												return;
											}
											if (type == 2775)
											{
												name = "Vortex Hammer";
												useTurn = true;
												autoReuse = true;
												useStyle = 1;
												useAnimation = 30;
												useTime = 7;
												knockBack = 7f;
												width = 44;
												height = 42;
												damage = 110;
												hammer = 100;

												rare = 10;
												value = Item.sellPrice(0, 5, 0, 0);
												melee = true;
												scale = 1.1f;
												glowMask = 4;
												tileBoost += 4;
												return;
											}
											if (type == 2777)
											{
												SetDefaults3(2772);
												type = 2777;
												name = "Nebula Axe";
												glowMask = 6;
												return;
											}
											if (type == 2778)
											{
												SetDefaults3(2773);
												type = 2778;
												name = "Nebula Chainsaw";
												shoot = 429;
												glowMask = 22;
												return;
											}
											if (type == 2779)
											{
												SetDefaults3(2774);
												type = 2779;
												name = "Nebula Drill";
												shoot = 430;
												glowMask = 23;
												return;
											}
											if (type == 2780)
											{
												SetDefaults3(2775);
												type = 2780;
												name = "Nebula Hammer";
												glowMask = 9;
												return;
											}
											if (type == 2781)
											{
												SetDefaults3(2776);
												type = 2781;
												name = "Nebula Pickaxe";
												glowMask = 10;
												return;
											}
											if (type == 2782)
											{
												SetDefaults3(2772);
												type = 2782;
												name = "Solar Flare Axe";
												glowMask = -1;
												return;
											}
											if (type == 2783)
											{
												SetDefaults3(2773);
												type = 2783;
												name = "Solar Flare Chainsaw";
												shoot = 431;
												glowMask = -1;
												return;
											}
											if (type == 2784)
											{
												SetDefaults3(2774);
												type = 2784;
												name = "Solar Flare Drill";
												shoot = 432;
												glowMask = -1;
												return;
											}
											if (type == 2785)
											{
												SetDefaults3(2775);
												type = 2785;
												name = "Solar Flare Hammer";
												glowMask = -1;
												return;
											}
											if (type == 2786)
											{
												SetDefaults3(2776);
												type = 2786;
												name = "Solar Flare Pickaxe";
												glowMask = -1;
												return;
											}
											if (type == 2787)
											{
												name = "Honeyfall Block";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createTile = 345;
												width = 12;
												height = 12;
												return;
											}
											if (type == 2788)
											{
												name = "Honeyfall Wall";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 7;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createWall = 172;
												width = 12;
												height = 12;
												return;
											}
											if (type >= 2789 && type <= 2791)
											{
												name = "Walls";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 7;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createWall = 173 + type - 2789;
												width = 12;
												height = 12;
												return;
											}
											if (type >= 2792 && type <= 2794)
											{
												name = "bricks";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createTile = 346 + type - 2792;
												width = 12;
												height = 12;
												return;
											}
											if (type == 2795)
											{
												name = "Laser Machinegun";
												useStyle = 5;
												useAnimation = 20;
												useTime = 20;
												shootSpeed = 20f;
												knockBack = 2f;
												width = 20;
												height = 12;
												damage = 60;
												shoot = 439;
												mana = 6;
												rare = 8;
												value = Item.sellPrice(0, 10, 0, 0);
												noMelee = true;
												noUseGraphic = true;
												magic = true;
												channel = true;
												glowMask = 47;
												return;
											}
											if (type == 2796)
											{
												useStyle = 5;
												useAnimation = 12;
												useTime = 12;
												name = "Electrosphere Launcher";
												width = 50;
												height = 18;
												shoot = 442;
												useAmmo = 771;
												glowMask = 36;

												damage = 40;
												shootSpeed = 12f;
												noMelee = true;
												value = Item.sellPrice(0, 10, 0, 0);
												ranged = true;
												rare = 8;
												knockBack = 2f;
												return;
											}
											if (type == 2797)
											{
												useStyle = 5;
												useAnimation = 21;
												useTime = 21;
												autoReuse = true;
												name = "Xenopopper";
												width = 50;
												height = 18;
												shoot = 444;
												useAmmo = 14;
												glowMask = 38;

												damage = 45;
												shootSpeed = 12f;
												noMelee = true;
												value = Item.sellPrice(0, 10, 0, 0);
												ranged = true;
												rare = 8;
												knockBack = 3f;
												return;
											}
											if (type == 2798)
											{
												name = "Laser Drill";
												useStyle = 5;
												useAnimation = 25;
												useTime = 7;
												shootSpeed = 36f;
												knockBack = 4.75f;
												width = 20;
												height = 12;
												damage = 35;
												pick = 230;
												axe = 30;

												shoot = 445;
												rare = 8;
												value = Item.sellPrice(0, 10, 0, 0);
												tileBoost = 10;
												noMelee = true;
												noUseGraphic = true;
												melee = true;
												channel = true;
												glowMask = 39;
												return;
											}
											if (type == 2799)
											{
												name = "Laser Ruler";
												width = 10;
												height = 26;
												accessory = true;
												toolTip = "Creates measurement lines on screen for block placement";
												value = Item.buyPrice(0, 1, 0, 0);
												rare = 1;
												return;
											}
											if (type == 2800)
											{
												noUseGraphic = true;
												damage = 0;
												knockBack = 7f;
												useStyle = 5;
												name = "Anti-Gravity Hook";
												shootSpeed = 14f;
												shoot = 446;
												width = 18;
												height = 28;

												useAnimation = 20;
												useTime = 20;
												rare = 7;
												noMelee = true;
												value = Item.sellPrice(0, 1, 0, 0);
												return;
											}
											if (type == 2801)
											{
												name = "Moon Mask";
												width = 28;
												height = 20;
												headSlot = 172;
												rare = 1;
												vanity = true;
												return;
											}
											if (type == 2802)
											{
												name = "Sun Mask";
												width = 28;
												height = 20;
												headSlot = 173;
												rare = 1;
												vanity = true;
												return;
											}
											if (type == 2803)
											{
												name = "Martian Costume Mask";
												width = 18;
												height = 18;
												headSlot = 174;
												vanity = true;
												value = Item.sellPrice(0, 1, 0, 0);
												return;
											}
											if (type == 2804)
											{
												name = "Martian Costume Shirt";
												width = 18;
												height = 18;
												bodySlot = 178;
												vanity = true;
												value = Item.sellPrice(0, 1, 0, 0);
												return;
											}
											if (type == 2805)
											{
												name = "Martian Costume Pants";
												width = 18;
												height = 18;
												legSlot = 113;
												vanity = true;
												value = Item.sellPrice(0, 1, 0, 0);
												return;
											}
											if (type == 2806)
											{
												name = "Martian Uniform Helmet";
												width = 18;
												height = 18;
												headSlot = 175;
												vanity = true;
												value = Item.sellPrice(0, 1, 0, 0);
												glowMask = 46;
												return;
											}
											if (type == 2807)
											{
												name = "Martian Uniform Torso";
												width = 18;
												height = 18;
												bodySlot = 179;
												vanity = true;
												value = Item.sellPrice(0, 1, 0, 0);
												glowMask = 45;
												return;
											}
											if (type == 2808)
											{
												name = "Martian Uniform Pants";
												width = 18;
												height = 18;
												legSlot = 114;
												vanity = true;
												value = Item.sellPrice(0, 1, 0, 0);
												return;
											}
											if (type == 2822)
											{
												name = "Martian Platform";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createTile = 19;
												placeStyle = 26;
												width = 8;
												height = 10;
												return;
											}
											if (type == 2810)
											{
												name = "Martian Bathtub";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 90;
												placeStyle = 27;
												width = 20;
												height = 20;
												value = 300;
												return;
											}
											if (type == 2811)
											{
												name = "Martian Bed";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												maxStack = 99;
												consumable = true;
												autoReuse = true;
												createTile = 79;
												placeStyle = 27;
												width = 28;
												height = 20;
												value = 2000;
												return;
											}
											if (type == 2823)
											{
												name = "Martian Sofa";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 89;
												placeStyle = 29;
												width = 20;
												height = 20;
												value = 300;
												return;
											}
											if (type == 2825)
											{
												name = "Martian Table Lamp";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 100;
												placeStyle = 27;
												width = 20;
												height = 20;
												value = 1500;
												return;
											}
											if (type == 2818)
											{
												noWet = true;
												name = "Martian Hover Candle";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 33;
												placeStyle = 26;
												width = 8;
												height = 18;
												return;
											}
											if (type == 2812)
											{
												name = "Martian Chair";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 15;
												placeStyle = 32;
												width = 12;
												height = 30;
												return;
											}
											if (type == 2813)
											{
												name = "Martian Chandelier";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 34;
												placeStyle = 33;
												width = 26;
												height = 26;
												value = 3000;
												return;
											}
											if (type == 2814)
											{
												name = "Martian Chest";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 21;
												placeStyle = 48;
												width = 26;
												height = 22;
												value = 500;
												return;
											}
											if (type == 2815)
											{
												name = "Martian Door";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												maxStack = 99;
												consumable = true;
												createTile = 10;
												placeStyle = 32;
												width = 14;
												height = 28;
												value = 200;
												return;
											}
											if (type == 2816)
											{
												name = "Martian Dresser";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 88;
												placeStyle = 24;
												width = 20;
												height = 20;
												value = 300;
												return;
											}
											if (type == 2820)
											{
												name = "Martian Lantern";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createTile = 42;
												width = 12;
												height = 28;
												placeStyle = 33;
												return;
											}
											if (type == 2821)
											{
												name = "Martian Piano";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 87;
												placeStyle = 26;
												width = 20;
												height = 20;
												value = 300;
												return;
											}
											if (type == 2824)
											{
												name = "Martian Table";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 14;
												placeStyle = 31;
												width = 26;
												height = 20;
												value = 300;
												return;
											}
											if (type == 2819)
											{
												name = "Martian Lamppost";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 93;
												placeStyle = 27;
												width = 10;
												height = 24;
												value = 500;
												return;
											}
											if (type == 2826)
											{
												name = "Martian Work Bench";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 18;
												placeStyle = 27;
												width = 28;
												height = 14;
												value = 150;
												toolTip = "Used for basic crafting";
												return;
											}
											if (type == 2817)
											{
												name = "Martian Holobookcase";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 101;
												width = 20;
												height = 20;
												value = 300;
												placeStyle = 28;
												return;
											}
											if (type == 2809)
											{
												name = "Martian Astro Clock";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 104;
												width = 20;
												height = 20;
												value = 300;
												placeStyle = 24;
												return;
											}
											if (type >= 2827 && type <= 2855)
											{
												name = "Sink";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 172;
												placeStyle = type - 2827;
												width = 20;
												height = 20;
												value = 300;
												return;
											}
											if (type == 2856)
											{
												name = "White Lunatic Hood";
												width = 28;
												height = 20;
												headSlot = 176;
												rare = 1;
												vanity = true;
												value = Item.buyPrice(0, 10, 0, 0);
												return;
											}
											if (type == 2857)
											{
												name = "Blue Lunatic Hood";
												width = 28;
												height = 20;
												headSlot = 177;
												rare = 1;
												vanity = true;
												value = Item.buyPrice(0, 10, 0, 0);
												return;
											}
											if (type == 2858)
											{
												name = "White Lunatic Robe";
												width = 18;
												height = 14;
												bodySlot = 180;
												rare = 1;
												vanity = true;
												value = Item.buyPrice(0, 10, 0, 0);
												return;
											}
											if (type == 2859)
											{
												name = "Blue Lunatic Robe";
												width = 18;
												height = 14;
												bodySlot = 181;
												rare = 1;
												vanity = true;
												value = Item.buyPrice(0, 10, 0, 0);
												return;
											}
											if (type == 2860)
											{
												name = "Martian Conduit Plating";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												glowMask = 93;
												createTile = 350;
												width = 12;
												height = 12;
												return;
											}
											if (type == 2861)
											{
												name = "Martian Conduit Wall";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 7;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												glowMask = 95;
												createWall = 176;
												width = 12;
												height = 12;
												return;
											}
											if (type == 2862)
											{
												name = "HiTek Sunglasses";
												width = 28;
												height = 12;
												headSlot = 178;
												rare = 3;
												value = Item.sellPrice(0, 1, 0, 0);
												vanity = true;
												glowMask = 97;
												return;
											}
											if (type == 2863)
											{
												name = "Martian Hair Dye";
												width = 20;
												height = 26;
												maxStack = 99;
												rare = 3;
												glowMask = 98;
												value = Item.buyPrice(0, 30, 0, 0);

												useStyle = 2;
												useTurn = true;
												useAnimation = 17;
												useTime = 17;
												consumable = true;
												return;
											}
											if (type == 2864)
											{
												name = "Martian Dye";
												glowMask = 99;
												width = 20;
												height = 20;
												maxStack = 99;
												value = Item.sellPrice(0, 1, 50, 0);
												rare = 3;
												return;
											}
											if (type == 2865)
											{
												name = "Castle Marsberg";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 242;
												width = 30;
												height = 30;
												value = Item.buyPrice(0, 2, 0, 0);
												placeStyle = 27;
												return;
											}
											if (type == 2866)
											{
												name = "Martia Lisa";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 242;
												width = 30;
												height = 30;
												value = Item.buyPrice(0, 2, 0, 0);
												placeStyle = 28;
												return;
											}
											if (type == 2867)
											{
												name = "The Truth Is Up There";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 99;
												consumable = true;
												createTile = 242;
												width = 30;
												height = 30;
												value = Item.buyPrice(0, 2, 0, 0);
												placeStyle = 29;
												return;
											}
											if (type == 2868)
											{
												name = "Smoke Block";
												useStyle = 1;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												autoReuse = true;
												maxStack = 999;
												consumable = true;
												createTile = 351;
												width = 12;
												height = 12;
												value = Item.buyPrice(0, 0, 1, 0);
												return;
											}
											if (type == 2869)
											{
												name = "Living Flame Dye";
												width = 20;
												height = 20;
												maxStack = 99;
												value = Item.sellPrice(0, 1, 50, 0);
												rare = 3;
												return;
											}
											if (type == 2870)
											{
												name = "Living Rainbow Dye";
												width = 20;
												height = 20;
												maxStack = 99;
												value = Item.sellPrice(0, 1, 50, 0);
												rare = 3;
												return;
											}
											if (type == 2871)
											{
												name = "Shadow Dye";
												width = 20;
												height = 20;
												maxStack = 99;
												value = Item.sellPrice(0, 0, 75, 0);
												rare = 2;
												return;
											}
											if (type == 2872)
											{
												name = "Negative Dye";
												width = 20;
												height = 20;
												maxStack = 99;
												value = Item.sellPrice(0, 0, 75, 0);
												rare = 2;
												return;
											}
											if (type == 2873)
											{
												name = "Living Ocean Dye";
												width = 20;
												height = 20;
												maxStack = 99;
												value = Item.sellPrice(0, 1, 50, 0);
												rare = 3;
												return;
											}
											if (type == 2874)
											{
												name = "Brown Dye";
												width = 20;
												height = 20;
												maxStack = 99;
												value = 10000;
												rare = 1;
												return;
											}
											if (type == 2875)
											{
												name = "Brown and Black Dye";
												width = 20;
												height = 20;
												maxStack = 99;
												value = 10000;
												rare = 1;
												return;
											}
											if (type == 2876)
											{
												name = "Bright Brown Dye";
												width = 20;
												height = 20;
												maxStack = 99;
												value = 10000;
												rare = 1;
												return;
											}
											if (type == 2877)
											{
												name = "Brown and Silver Dye";
												width = 20;
												height = 20;
												maxStack = 99;
												value = 10000;
												rare = 1;
												return;
											}
											if (type == 2878)
											{
												name = "Wisp Dye";
												width = 20;
												height = 20;
												maxStack = 99;
												value = Item.sellPrice(0, 1, 50, 0);
												rare = 3;
												glowMask = 105;
												return;
											}
											if (type == 2879)
											{
												name = "Pixie Dye";
												width = 20;
												height = 20;
												maxStack = 99;
												value = Item.sellPrice(0, 1, 50, 0);
												rare = 3;
												glowMask = 104;
												return;
											}
											if (type == 2880)
											{
												name = "Spellbound Edge";
												useStyle = 1;
												useAnimation = 20;
												useTime = 20;
												autoReuse = true;
												shoot = 451;
												shootSpeed = 11f;
												knockBack = 4.5f;
												width = 40;
												height = 40;
												damage = 110;
												scale = 1.05f;

												rare = 8;
												value = Item.sellPrice(0, 10, 0, 0);
												melee = true;
												return;
											}
											if (type == 2882)
											{
												name = "Charged Blaster Cannon";
												useStyle = 5;
												useAnimation = 20;
												useTime = 20;
												shootSpeed = 14f;
												knockBack = 2f;
												width = 16;
												height = 16;
												damage = 50;

												shoot = 460;
												mana = 14;
												rare = 8;
												value = Item.sellPrice(0, 10, 0, 0);
												noMelee = true;
												noUseGraphic = true;
												magic = true;
												channel = true;
												glowMask = 102;
												return;
											}
											if (type == 2883)
											{
												name = "Chlorophyte Dye";
												width = 20;
												height = 20;
												maxStack = 99;
												value = Item.sellPrice(0, 1, 50, 0);
												rare = 3;
												glowMask = 103;
												return;
											}
											if (type == 2885)
											{
												name = "Infernal Wisp Dye";
												width = 20;
												height = 20;
												maxStack = 99;
												value = Item.sellPrice(0, 1, 50, 0);
												rare = 3;
												glowMask = 106;
												return;
											}
											if (type == 2884)
											{
												name = "Unicorn Wisp Dye";
												width = 20;
												height = 20;
												maxStack = 99;
												value = Item.sellPrice(0, 1, 50, 0);
												rare = 3;
												glowMask = 107;
												return;
											}
											if (type == 2887)
											{
												name = "Vicious Mushroom";
												width = 16;
												height = 18;
												maxStack = 99;
												value = 50;
												return;
											}
											if (type == 2886)
											{
												damage = 0;
												useStyle = 1;
												name = "Vicious Powder";
												shootSpeed = 4f;
												shoot = 463;
												width = 16;
												height = 24;
												maxStack = 99;
												consumable = true;

												useAnimation = 15;
												useTime = 15;
												noMelee = true;
												value = 100;
												toolTip = "Removes the Hallow";
												return;
											}
											if (type == 2888)
											{
												useStyle = 5;
												useAnimation = 23;
												useTime = 23;
												name = "The Bee's Knees";
												width = 12;
												height = 28;
												shoot = 469;
												useAmmo = AmmoID.Arrow;

												damage = 26;
												shootSpeed = 8f;
												knockBack = 3f;
												rare = 3;
												noMelee = true;
												value = 27000;
												ranged = true;
												return;
											}
											if (type >= 2889 && type <= 2895)
											{
												name = "Gold Critter";
												useStyle = 1;
												autoReuse = true;
												useTurn = true;
												useAnimation = 15;
												useTime = 10;
												maxStack = 999;
												consumable = true;
												width = 12;
												height = 12;
												makeNPC = (short)(442 + type - 2889);
												noUseGraphic = true;
												value = Item.sellPrice(0, 10, 0, 0);
												rare = 2;
												if (type == 2895 || type == 2893 || type == 2891)
												{
													bait = 50;
													return;
												}
											}
											else
											{
												if (type == 2896)
												{
													useStyle = 1;
													name = "Sticky Dynamite";
													shootSpeed = 4f;
													shoot = 470;
													width = 8;
													height = 28;
													maxStack = 30;
													consumable = true;

													useAnimation = 40;
													useTime = 40;
													noUseGraphic = true;
													noMelee = true;
													value = Item.buyPrice(0, 0, 20, 0);
													rare = 1;
													return;
												}
												if (type >= 2897 && type <= 2994)
												{
													name = "Monster Banner";
													useStyle = 1;
													useTurn = true;
													useAnimation = 15;
													useTime = 10;
													autoReuse = true;
													maxStack = 99;
													consumable = true;
													createTile = 91;
													placeStyle = 109 + type - 2897;
													width = 10;
													height = 24;
													value = 1000;
													rare = 1;
													return;
												}
												if (type == 2995)
												{
													name = "Sparky Painting";
													useStyle = 1;
													useTurn = true;
													useAnimation = 15;
													useTime = 10;
													autoReuse = true;
													maxStack = 99;
													consumable = true;
													createTile = 242;
													width = 30;
													height = 30;
													value = Item.sellPrice(0, 0, 10, 0);
													placeStyle = 30;
													return;
												}
												if (type == 2996)
												{
													name = "Vine Rope";
													useStyle = 1;
													useTurn = true;
													useAnimation = 15;
													useTime = 8;
													autoReuse = true;
													maxStack = 999;
													consumable = true;
													createTile = 353;
													width = 12;
													height = 12;
													tileBoost += 3;
													toolTip = "Can be climbed on";
													return;
												}
												if (type == 2997)
												{
													name = "Unity Potion";
													maxStack = 30;
													consumable = true;
													width = 14;
													height = 24;
													toolTip = "Teleports you to a party member";
													toolTip2 = "Right click their head on the fullscreen map";
													value = 1000;
													rare = 1;
													return;
												}
												if (type == 2998)
												{
													name = "Summoner Emblem";
													width = 24;
													height = 24;
													accessory = true;
													toolTip = "15% increased summon damage";
													value = 100000;
													rare = 4;
													return;
												}
												if (type == 2999)
												{
													rare = 1;
													name = "Bewitching Table";
													useStyle = 1;
													useTurn = true;
													useAnimation = 15;
													useTime = 10;
													autoReuse = true;
													maxStack = 999;
													consumable = true;
													createTile = 354;
													width = 12;
													height = 12;
													value = 100000;
													return;
												}
												if (type == 3000)
												{
													rare = 1;
													name = "Alchemy Table";
													useStyle = 1;
													useTurn = true;
													useAnimation = 15;
													useTime = 10;
													autoReuse = true;
													maxStack = 999;
													consumable = true;
													createTile = 355;
													width = 12;
													height = 12;
													value = 100000;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		public void SetDefaults4(int type)
		{
			if (type == 3001)
			{
				rare = 1;
				name = "StrangeBrew";

				healLife = 80;
				healMana = 400;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				potion = true;
				value = Item.buyPrice(0, 0, 5, 0);
				return;
			}
			if (type == 3061)
			{
				name = "Architect Gizmo Pack";
				width = 30;
				height = 30;
				accessory = true;
				rare = 5;
				value = Item.buyPrice(0, 20, 0, 0);
				backSlot = 8;
				return;
			}
			if (type == 3002)
			{
				alpha = 0;
				color = new Color(255, 255, 255, 0);
				rare = 1;
				useStyle = 1;
				name = "Spelunker Glowstick";
				shootSpeed = 6f;
				shoot = 473;
				width = 12;
				height = 12;
				maxStack = 99;
				consumable = true;

				useAnimation = 15;
				useTime = 15;
				noMelee = true;
				value = Item.buyPrice(0, 0, 1, 50);
				holdStyle = 1;
				return;
			}
			if (type == 3003)
			{
				name = "Bone Arrow";
				shootSpeed = 3.5f;
				shoot = 474;
				damage = 6;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.Arrow;
				knockBack = 2.5f;
				value = Item.buyPrice(0, 0, 0, 15);
				ranged = true;
				return;
			}
			if (type == 3004)
			{
				flame = true;
				noWet = true;
				name = "Bone Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 13;
				width = 10;
				height = 12;
				value = Item.buyPrice(0, 0, 1, 0);
				return;
			}
			if (type == 3005)
			{
				useStyle = 1;
				name = "Vine Rope Coil";
				shootSpeed = 10f;
				shoot = 475;
				damage = 0;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;

				useAnimation = 20;
				useTime = 20;
				noUseGraphic = true;
				noMelee = true;
				toolTip = "Throw to create a climbable line of vine rope";
				return;
			}
			if (type == 3006)
			{
				mana = 10;
				autoReuse = true;
				damage = 30;
				useStyle = 5;
				name = "Soul Drain";
				shootSpeed = 10f;
				shoot = 476;
				width = 26;
				height = 28;
				useAnimation = 12;
				useTime = 12;
				rare = 5;
				noMelee = true;
				knockBack = 2.5f;
				toolTip = "Drains power from enemies";
				value = Item.sellPrice(0, 8, 0, 0);
				magic = true;
				return;
			}
			if (type == 3007)
			{
				autoReuse = true;
				name = "Dart Pistol";
				useStyle = 5;
				useAnimation = 22;
				useTime = 22;
				width = 38;
				height = 6;
				shoot = 10;
				useAmmo = AmmoID.Dart;

				damage = 28;
				shootSpeed = 13f;
				noMelee = true;
				value = Item.sellPrice(0, 5, 0, 0);
				knockBack = 3.5f;
				useAmmo = AmmoID.Dart;
				ranged = true;
				rare = 5;
				scale = 0.9f;
				return;
			}
			if (type == 3008)
			{
				autoReuse = true;
				name = "Dart Rifle";
				useStyle = 5;
				useAnimation = 38;
				useTime = 38;
				width = 38;
				height = 6;
				shoot = 10;
				useAmmo = AmmoID.Dart;

				damage = 52;
				shootSpeed = 14.5f;
				noMelee = true;
				value = Item.sellPrice(0, 5, 0, 0);
				knockBack = 5.5f;
				useAmmo = AmmoID.Dart;
				ranged = true;
				rare = 5;
				scale = 1f;
				return;
			}
			if (type == 3009)
			{
				name = "Crystal Dart";
				shoot = 477;
				width = 8;
				height = 8;
				maxStack = 999;
				ammo = AmmoID.Dart;
				damage = 15;
				knockBack = 3.5f;
				shootSpeed = 1f;
				ranged = true;
				rare = 3;
				consumable = true;
				return;
			}
			if (type == 3010)
			{
				name = "Cursed Dart";
				shoot = 478;
				width = 8;
				height = 8;
				maxStack = 999;
				ammo = AmmoID.Dart;
				damage = 9;
				knockBack = 2.2f;
				shootSpeed = 3f;
				ranged = true;
				rare = 3;
				consumable = true;
				return;
			}
			if (type == 3011)
			{
				name = "Ichor Dart";
				shoot = 479;
				width = 8;
				height = 8;
				maxStack = 999;
				ammo = AmmoID.Dart;
				damage = 10;
				knockBack = 2.5f;
				shootSpeed = 3f;
				ranged = true;
				rare = 3;
				consumable = true;
				return;
			}
			if (type == 3012)
			{
				autoReuse = true;
				name = "Chain Guillotines";
				useStyle = 1;
				useTurn = true;
				useAnimation = 14;
				useTime = 14;
				knockBack = 3.25f;
				width = 30;
				height = 10;
				damage = 43;
				shoot = 481;
				shootSpeed = 14f;

				rare = 5;
				value = 1000;
				melee = true;
				noUseGraphic = true;
				return;
			}
			if (type == 3013)
			{
				name = "Fetid Baghnakhs";
				useStyle = 1;
				useTurn = true;
				autoReuse = true;
				useAnimation = 7;
				useTime = 7;
				width = 24;
				height = 28;
				damage = 70;
				knockBack = 6f;

				scale = 1.35f;
				melee = true;
				rare = 5;
				value = Item.sellPrice(0, 8, 0, 0);
				melee = true;
				return;
			}
			if (type == 3014)
			{
				mana = 40;
				autoReuse = true;
				damage = 43;
				useStyle = 1;
				name = "Clinger Staff";
				shootSpeed = 15f;
				shoot = 482;
				width = 26;
				height = 28;

				useAnimation = 24;
				useTime = 24;
				rare = 5;
				noMelee = true;
				knockBack = 8f;
				toolTip = "Summons a wall of cursed flames";
				value = Item.sellPrice(0, 8, 0, 0);
				magic = true;
				return;
			}
			if (type == 3024)
			{
				name = "Skiphs's Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				rare = 9;
				value = Item.sellPrice(0, 3, 0, 0);
				return;
			}
			if (type == 3599)
			{
				name = "Loki's Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				rare = 9;
				value = Item.sellPrice(0, 3, 0, 0);
				return;
			}
			if (type == 3015)
			{
				name = "Putrid Scent";
				width = 24;
				height = 24;
				accessory = true;
				toolTip = "Enemies are less likely to target you";
				toolTip2 = "3% increased damage and critical strike chance";
				value = Item.sellPrice(0, 8, 0, 0);
				rare = 6;
				return;
			}
			if (type == 3016)
			{
				name = "Flesh Knuckles";
				width = 24;
				height = 24;
				accessory = true;
				toolTip = "Enemies are more likely to target you";
				defense = 7;
				value = Item.sellPrice(0, 8, 0, 0);
				rare = 5;
				return;
			}
			if (type == 3017)
			{
				name = "Flower Boots";
				width = 16;
				height = 24;
				accessory = true;
				rare = 7;
				toolTip = "Flowers grow on the grass beneath you";
				value = Item.sellPrice(0, 8, 0, 0);
				shoeSlot = 16;
				return;
			}
			if (type == 3018)
			{
				name = "Seedler";
				useStyle = 1;
				autoReuse = true;
				useAnimation = 23;
				useTime = 23;
				width = 50;
				height = 20;
				shoot = 483;

				damage = 50;
				shootSpeed = 12f;
				value = Item.sellPrice(0, 10, 0, 0);
				knockBack = 6f;
				rare = 5;
				melee = true;
				return;
			}
			if (type == 3019)
			{
				autoReuse = true;
				useStyle = 5;
				useAnimation = 14;
				useTime = 14;
				name = "Hellwing Bow";
				width = 18;
				height = 46;
				shoot = 485;
				useAmmo = AmmoID.Arrow;

				damage = 20;
				knockBack = 5f;
				shootSpeed = 6f;
				noMelee = true;
				value = Item.sellPrice(0, 4, 0, 0);
				rare = 3;
				ranged = true;
				toolTip = "Shoots a charged arrow";
				return;
			}
			if (type >= 3020 && type <= 3023)
			{
				name = "Hook";
				noUseGraphic = true;
				damage = 0;
				useStyle = 5;
				shootSpeed = 15f;
				shoot = 486 + type - 3020;
				width = 18;
				height = 28;

				useAnimation = 20;
				useTime = 20;
				rare = 6;
				noMelee = true;
				value = Item.sellPrice(0, 8, 0, 0);
				return;
			}
			if (type == 3025)
			{
				name = "Plaid Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = Item.sellPrice(0, 0, 75, 0);
				rare = 2;
				return;
			}
			if (type == 3026)
			{
				name = "Reflective Silver Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = Item.sellPrice(0, 0, 75, 0);
				rare = 2;
				return;
			}
			if (type == 3027)
			{
				name = "Reflective Gold Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = Item.sellPrice(0, 0, 75, 0);
				rare = 2;
				return;
			}
			if (type == 3190)
			{
				name = "Reflective Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = Item.sellPrice(0, 0, 75, 0);
				rare = 2;
				return;
			}
			if (type == 3038)
			{
				name = "Hades Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = Item.sellPrice(0, 1, 50, 0);
				rare = 3;
				return;
			}
			if (type == 3597)
			{
				name = "Burning Hades Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = Item.sellPrice(0, 1, 50, 0);
				rare = 3;
				return;
			}
			if (type == 3600)
			{
				name = "Shadowflame Hades Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = Item.sellPrice(0, 1, 50, 0);
				rare = 3;
				return;
			}
			if (type == 3598)
			{
				name = "Grim Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = Item.sellPrice(0, 1, 50, 0);
				rare = 3;
				return;
			}
			if (type == 3029)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 19;
				useTime = 19;
				name = "Daedalus Stormbow";
				width = 28;
				height = 60;
				shoot = 1;
				useAmmo = AmmoID.Arrow;

				damage = 43;
				shootSpeed = 12.5f;
				noMelee = true;
				value = Item.sellPrice(0, 8, 0, 0);
				ranged = true;
				rare = 6;
				knockBack = 2.25f;
				return;
			}
			if (type == 3030)
			{
				channel = true;
				damage = 40;
				useStyle = 1;
				name = "Flying Knife";
				shootSpeed = 17f;
				shoot = 491;
				width = 26;
				height = 28;

				useAnimation = 15;
				useTime = 15;
				rare = 6;
				noMelee = true;
				knockBack = 4.5f;
				value = Item.sellPrice(0, 8, 0, 0);
				melee = true;
				noUseGraphic = true;
				return;
			}
			if (type == 3031 || type == 3032)
			{
				useStyle = 1;
				useTurn = true;
				useAnimation = 12;
				useTime = 5;
				width = 20;
				height = 20;
				autoReuse = true;
				rare = 7;
				value = Item.sellPrice(0, 10, 0, 0);
				tileBoost += 2;
				return;
			}
			if (type == 3036)
			{
				name = "Fish Finder";
				width = 24;
				height = 28;
				rare = 3;
				value = Item.sellPrice(0, 3, 0, 0);
				accessory = true;
				return;
			}
			if (type == 3037)
			{
				name = "Weather Radio";
				width = 24;
				height = 28;
				rare = 1;
				value = Item.sellPrice(0, 1, 0, 0);
				accessory = true;
				return;
			}
			if (type == 3033)
			{
				name = "Gold Ring";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				value = 50000;
				return;
			}
			if (type == 3034)
			{
				name = "Coin Ring";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				value = 100000;
				return;
			}
			if (type == 3035)
			{
				name = "Greedy Ring";
				width = 16;
				height = 24;
				accessory = true;
				rare = 6;
				value = 150000;
				return;
			}
			if (type == 3039)
			{
				name = "Twilight Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = Item.sellPrice(0, 1, 50, 0);
				rare = 3;
				return;
			}
			if (type == 3040)
			{
				name = "Acid Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = Item.sellPrice(0, 0, 75, 0);
				rare = 2;
				return;
			}
			if (type == 3028)
			{
				name = "Blue Acid Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = Item.sellPrice(0, 0, 75, 0);
				rare = 2;
				return;
			}
			if (type == 3041)
			{
				name = "Glowing Mushroom Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = Item.sellPrice(0, 0, 75, 0);
				rare = 2;
				return;
			}
			if (type == 3042)
			{
				name = "Phase Dye";
				width = 20;
				height = 20;
				maxStack = 99;
				value = Item.sellPrice(0, 1, 50, 0);
				rare = 3;
				return;
			}
			if (type == 3043)
			{
				damage = 0;
				useStyle = 1;
				name = "Magic Lantern";
				shoot = 492;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				value = Item.buyPrice(0, 10, 0, 0);
				buffType = 152;
				return;
			}
			if (type == 3044)
			{
				name = "Music Box (Lunar Boss?)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 32;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			if (type == 3045)
			{
				flame = true;
				noWet = true;
				name = "Rainbow Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 14;
				width = 10;
				height = 12;
				value = 500;
				rare = 1;
				return;
			}
			if (type >= 3046 && type <= 3050)
			{
				name = "Campfire";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 215;
				placeStyle = 1 + type - 3046;
				width = 12;
				height = 12;
				toolTip = "Life regen is increased when near a campfire";
				return;
			}
			if (type == 3051)
			{
				mana = 13;
				damage = 19;
				useStyle = 5;
				name = "Crystal Vile Shard";
				shootSpeed = 32f;
				shoot = 494;
				width = 26;
				height = 28;

				useAnimation = 33;
				useTime = 33;
				rare = 5;
				noMelee = true;
				knockBack = 3f;
				value = Item.sellPrice(0, 8, 0, 0);
				magic = true;
				autoReuse = true;
				return;
			}
			if (type == 3052)
			{
				autoReuse = true;
				useStyle = 5;
				useAnimation = 20;
				useTime = 20;
				width = 14;
				height = 32;
				shoot = 495;
				useAmmo = AmmoID.Arrow;

				damage = 47;
				shootSpeed = 11f;
				knockBack = 4.5f;
				rare = 5;
				crit = 3;
				noMelee = true;
				value = Item.sellPrice(0, 2, 0, 0);
				ranged = true;
				return;
			}
			if (type == 3053)
			{
				autoReuse = true;
				rare = 5;
				mana = 6;

				useStyle = 5;
				damage = 40;
				useAnimation = 21;
				useTime = 7;
				width = 24;
				height = 28;
				shoot = 496;
				shootSpeed = 9f;
				knockBack = 3.75f;
				magic = true;
				value = Item.sellPrice(0, 2, 0, 0);
				noMelee = true;
				noUseGraphic = true;
				crit = 3;
				return;
			}
			if (type == 3054)
			{
				crit = 3;
				autoReuse = true;
				useStyle = 1;
				shootSpeed = 13f;
				shoot = 497;
				damage = 38;
				width = 18;
				height = 20;

				useAnimation = 12;
				useTime = 12;
				noUseGraphic = true;
				noMelee = true;
				value = Item.sellPrice(0, 2, 0, 0);
				knockBack = 5.75f;
				melee = true;
				rare = 5;
				return;
			}
			if (type >= 3055 && type <= 3059)
			{
				name = "Painting";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = Item.sellPrice(0, 0, 10, 0);
				placeStyle = 31 + type - 3055;
				return;
			}
			if (type == 3060)
			{
				damage = 0;
				useStyle = 1;
				name = "Bone Rattle";
				shoot = 499;
				width = 16;
				height = 30;

				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				value = Item.sellPrice(0, 7, 50, 0);
				buffType = 154;
				return;
			}
			if (type == 3062)
			{
				channel = true;
				damage = 0;
				useStyle = 4;
				name = "Crimson Heart";
				shoot = 500;
				width = 24;
				height = 24;

				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				toolTip = "Creates a magical crimson heart";
				value = 10000;
				buffType = 155;
				return;
			}
			if (type == 3063)
			{
				rare = 10;

				name = "Meowmere";
				useStyle = 1;
				damage = 200;
				useAnimation = 16;
				useTime = 16;
				width = 30;
				height = 30;
				shoot = 502;
				scale = 1.1f;
				shootSpeed = 12f;
				knockBack = 6.5f;
				melee = true;
				value = Item.sellPrice(0, 20, 0, 0);
				autoReuse = true;
				return;
			}
			if (type == 3064)
			{
				name = "Sundial";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 356;
				width = 18;
				height = 34;
				value = Item.sellPrice(0, 3, 0, 0);
				rare = 7;
				return;
			}
			if (type == 3065)
			{
				rare = 9;

				name = "Star Wrath";
				useStyle = 1;
				damage = 110;
				useAnimation = 16;
				useTime = 16;
				width = 30;
				height = 30;
				shoot = 503;
				scale = 1.1f;
				shootSpeed = 8f;
				knockBack = 6.5f;
				melee = true;
				value = Item.sellPrice(0, 20, 0, 0);
				autoReuse = true;
				return;
			}
			if (type == 3066)
			{
				name = "Marble Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 357;
				width = 12;
				height = 12;
				return;
			}
			if (type == 3067)
			{
				name = "Hellstone Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 177;
				width = 12;
				height = 12;
				return;
			}
			if (type == 3068)
			{
				name = "Guide to Making Cordage";
				width = 16;
				height = 24;
				accessory = true;
				rare = 1;
				value = 50000;
				return;
			}
			if (type == 3069)
			{
				mana = 2;
				damage = 8;
				useStyle = 1;
				name = "Wand of Sparking";
				shootSpeed = 7f;
				shoot = 504;
				width = 26;
				height = 28;

				useAnimation = 28;
				useTime = 28;
				rare = 1;
				noMelee = true;
				value = 5000;
				magic = true;
				return;
			}
			if (type >= 3070 && type <= 3076)
			{
				name = "Gold Critter Cage";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 358 + type - 3070;
				width = 12;
				height = 12;
				value = Item.sellPrice(0, 10, 0, 0);
				rare = 2;
				return;
			}
			if (type == 3077)
			{
				name = "Silk Rope";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 8;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 365;
				width = 12;
				height = 12;
				value = 10;
				tileBoost += 3;
				toolTip = "Can be climbed on";
				return;
			}
			if (type == 3078)
			{
				name = "Web Rope";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 8;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 366;
				width = 12;
				height = 12;
				value = 10;
				tileBoost += 3;
				toolTip = "Can be climbed on";
				return;
			}
			if (type == 3081)
			{
				name = "Marble";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 367;
				width = 12;
				height = 12;
				return;
			}
			if (type == 3082)
			{
				name = "Marble Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 183;
				width = 12;
				height = 12;
				return;
			}
			if (type == 3083)
			{
				name = "Marble Block Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 179;
				width = 12;
				height = 12;
				return;
			}
			if (type == 3084)
			{
				name = "Radar";
				width = 24;
				height = 18;
				accessory = true;
				rare = 1;
				value = Item.sellPrice(0, 1, 0, 0);
				return;
			}
			if (type == 3085)
			{
				name = "Gold Lock Box";
				width = 12;
				height = 12;
				rare = 2;
				toolTip = "Right click to open";
				toolTip2 = "Requires a Golden Key";
				maxStack = 99;
				value = Item.buyPrice(0, 2, 0, 0);
				return;
			}
			if (type == 3086)
			{
				name = "Granite";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 368;
				width = 12;
				height = 12;
				return;
			}
			if (type == 3080)
			{
				useStyle = 1;
				name = "Web Rope Coil";
				shootSpeed = 10f;
				shoot = 506;
				damage = 0;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;

				useAnimation = 20;
				useTime = 20;
				noUseGraphic = true;
				noMelee = true;
				value = 100;
				toolTip = "Throw to create a climbable line of rope";
				return;
			}
			if (type == 3079)
			{
				useStyle = 1;
				name = "Silk Rope Coil";
				shootSpeed = 10f;
				shoot = 505;
				damage = 0;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;

				useAnimation = 20;
				useTime = 20;
				noUseGraphic = true;
				noMelee = true;
				value = 100;
				toolTip = "Throw to create a climbable line of rope";
				return;
			}
			if (type == 3087)
			{
				name = "Granite Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 369;
				width = 12;
				height = 12;
				return;
			}
			if (type == 3088)
			{
				name = "Granite Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 184;
				width = 12;
				height = 12;
				return;
			}
			if (type == 3089)
			{
				name = "Granite Block Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 181;
				width = 12;
				height = 12;
				return;
			}
			if (type == 3090)
			{
				name = "Royal Gel";
				width = 16;
				height = 24;
				accessory = true;
				rare = 2;
				toolTip = "Slimes become friendly";
				value = 100000;
				expert = true;
				return;
			}
			if (type == 3091 || type == 3092)
			{
				name = "Mimic Key";
				width = 14;
				height = 20;
				maxStack = 99;
				toolTip = "Spawns a mimic";
				useAnimation = 20;
				useTime = 20;
				return;
			}
			if (type == 3093)
			{
				name = "Herb Bag";
				width = 12;
				height = 12;
				rare = 1;
				toolTip = "Right click to open";
				maxStack = 99;
				value = Item.sellPrice(0, 0, 10, 0);
				return;
			}
			if (type == 3094)
			{
				useStyle = 1;
				name = "Javelin";
				shootSpeed = 11.5f;
				shoot = 507;
				damage = 17;
				width = 30;
				height = 30;
				maxStack = 999;
				consumable = true;

				useAnimation = 24;
				useTime = 24;
				noUseGraphic = true;
				noMelee = true;
				knockBack = 4.75f;
				thrown = true;
				return;
			}
			if (type == 3095)
			{
				name = "Tally Counter";
				width = 24;
				height = 18;
				accessory = true;
				rare = 1;
				value = Item.sellPrice(0, 1, 0, 0);
				return;
			}
			if (type == 3097)
			{
				melee = true;
				damage = 30;
				name = "Shield of Cthulhu";
				width = 24;
				height = 28;
				rare = 1;
				value = Item.sellPrice(0, 0, 30, 0);
				accessory = true;
				defense = 2;
				shieldSlot = 5;
				knockBack = 9f;
				expert = true;
				return;
			}
			if (type == 3098)
			{
				name = "Butcher's Chainsaw";
				useStyle = 5;
				useAnimation = 25;
				useTime = 8;
				shootSpeed = 48f;
				knockBack = 8f;
				width = 54;
				height = 20;
				damage = 120;
				axe = 30;

				shoot = 509;
				rare = 8;
				value = Item.sellPrice(0, 4, 0, 0);
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				return;
			}
			if (type == 3099)
			{
				name = "Stopwatch";
				width = 24;
				height = 18;
				accessory = true;
				rare = 1;
				value = Item.sellPrice(0, 1, 0, 0);
				return;
			}
			if (type == 3100)
			{
				name = "Meteorite Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 370;
				width = 12;
				height = 12;
				return;
			}
			if (type == 3101)
			{
				name = "Meteorite Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 182;
				width = 12;
				height = 12;
				return;
			}
			if (type == 3102)
			{
				name = "Metal Detector";
				width = 24;
				height = 18;
				accessory = true;
				rare = 1;
				value = Item.sellPrice(0, 1, 0, 0);
				return;
			}
			if (type == 3103)
			{
				name = "Endless Quiver";
				shootSpeed = 3f;
				shoot = 1;
				damage = 5;
				width = 26;
				height = 26;
				ammo = AmmoID.Arrow;
				knockBack = 2f;
				value = Item.sellPrice(0, 2, 0, 0);
				ranged = true;
				rare = 2;
				return;
			}
			if (type == 3104)
			{
				name = "Endless Musket Pouch";
				shootSpeed = 4f;
				shoot = 14;
				damage = 7;
				width = 26;
				height = 26;
				ammo = AmmoID.Bullet;
				knockBack = 2f;
				value = Item.sellPrice(0, 2, 0, 0);
				ranged = true;
				rare = 2;
				return;
			}
			if (type == 3105)
			{
				magic = true;
				mana = 30;
				useStyle = 1;
				name = "Toxic Flask";
				shootSpeed = 9f;
				rare = 8;
				damage = 46;
				shoot = 510;
				width = 18;
				height = 20;
				knockBack = 4f;

				useAnimation = 28;
				useTime = 28;
				noUseGraphic = true;
				noMelee = true;
				value = Item.sellPrice(0, 2, 0, 0);
				return;
			}
			if (type == 3106)
			{
				autoReuse = true;
				name = "Psycho Knife";
				useStyle = 1;
				useAnimation = 20;
				useTime = 20;
				knockBack = 3.5f;
				width = 30;
				height = 30;
				damage = 70;
				scale = 1.1f;
				rare = 8;
				value = Item.sellPrice(0, 5, 0, 0);
				melee = true;
				return;
			}
			if (type == 3107)
			{
				useStyle = 5;
				autoReuse = true;
				useAnimation = 15;
				useTime = 15;
				name = "Nailgun";
				width = 50;
				height = 18;
				shoot = 514;
				useAmmo = AmmoID.NailFriendly;
				damage = 85;
				shootSpeed = 10f;
				noMelee = true;
				value = Item.sellPrice(0, 10, 0, 0);
				rare = 8;
				ranged = true;
				return;
			}
			if (type == 3108)
			{
				name = "Nail";
				shootSpeed = 6f;
				shoot = 514;
				damage = 30;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = AmmoID.NailFriendly;
				knockBack = 3f;
				value = Item.buyPrice(0, 0, 1, 0);
				ranged = true;
				rare = 8;
				return;
			}
			if (type == 3109)
			{
				name = "Night Vision Helmet";
				width = 22;
				height = 22;
				defense = 2;
				headSlot = 179;
				rare = 3;
				value = Item.sellPrice(0, 2, 0, 0);
				toolTip = "Improves vision";
				return;
			}
			if (type == 3110)
			{
				name = "Celestial Shell";
				width = 16;
				height = 24;
				accessory = true;
				rare = 8;
				toolTip = "Turns the holder into a werewolf at night and a merfolk when entering water";
				toolTip2 = "Minor increases to all stats";
				value = 700000;
				return;
			}
			if (type == 3111)
			{
				name = "Pink Gel";
				width = 10;
				height = 12;
				maxStack = 999;
				alpha = 100;
				toolTip = "'Bouncy and sweet!'";
				value = 15;
				return;
			}
			if (type == 3112)
			{
				color = new Color(255, 255, 255, 0);
				useStyle = 1;
				name = "Bouncy Glowstick";
				shootSpeed = 6f;
				shoot = 515;
				width = 12;
				height = 12;
				maxStack = 99;
				consumable = true;

				useAnimation = 15;
				useTime = 15;
				noMelee = true;
				value = 10;
				holdStyle = 1;
				toolTip = "Works when wet";
				toolTip2 = "Very bouncy";
				return;
			}
			if (type == 3113)
			{
				name = "Pink Slime Block";
				createTile = 371;
				width = 12;
				height = 12;
				toolTip = "Very bouncy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				return;
			}
			if (type == 3114)
			{
				flame = true;
				noWet = true;
				name = "Pink Torch";
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 15;
				width = 10;
				height = 12;
				value = 80;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				return;
			}
			if (type == 3115)
			{
				useStyle = 1;
				name = "Bouncy Bomb";
				shootSpeed = 5f;
				shoot = 516;
				width = 20;
				height = 20;
				maxStack = 99;
				consumable = true;

				useAnimation = 25;
				useTime = 25;
				noUseGraphic = true;
				noMelee = true;
				value = Item.buyPrice(0, 0, 4, 0);
				damage = 0;
				toolTip = "A small explosion that will destroy some tiles";
				toolTip2 = "Very bouncy";
				return;
			}
			if (type == 3116)
			{
				useStyle = 5;
				name = "Bouncy Grenade";
				shootSpeed = 6.5f;
				shoot = 517;
				width = 20;
				height = 20;
				maxStack = 99;
				consumable = true;

				useAnimation = 40;
				useTime = 40;
				noUseGraphic = true;
				noMelee = true;
				value = 100;
				damage = 65;
				knockBack = 8f;
				toolTip = "A small explosion that will not destroy tiles";
				toolTip2 = "Very bouncy";
				thrown = true;
				return;
			}
			if (type == 3117)
			{
				flame = true;
				noWet = true;
				name = "Peace Candle";
				createTile = 372;
				width = 8;
				height = 18;
				holdStyle = 1;
				toolTip = "Makes surrounding creatures less hostile";
				rare = 1;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				return;
			}
			if (type >= 3203 && type <= 3208)
			{
				name = "Biome Crate";
				width = 12;
				height = 12;
				rare = 2;
				toolTip = "Right click to open";
				maxStack = 99;
				createTile = 376;
				placeStyle = 3 + type - 3203;
				useAnimation = 15;
				useTime = 15;
				autoReuse = true;
				useStyle = 1;
				consumable = true;
				value = Item.sellPrice(0, 1, 0, 0);
				return;
			}
			if (type == 3209)
			{
				name = "Crystal Serpent";
				mana = 9;

				useStyle = 5;
				damage = 40;
				useAnimation = 29;
				useTime = 29;
				width = 36;
				height = 40;
				shoot = 521;
				shootSpeed = 13f;
				knockBack = 4.4f;
				magic = true;
				autoReuse = true;
				value = Item.sellPrice(0, 4, 0, 0);
				rare = 5;
				noMelee = true;
				return;
			}
			if (type == 3210)
			{
				name = "Toxikcarp";

				useStyle = 5;
				damage = 43;
				useAnimation = 14;
				useTime = 14;
				width = 30;
				height = 28;
				shoot = 523;
				shootSpeed = 8.5f;
				knockBack = 3f;
				ranged = true;
				autoReuse = true;
				value = Item.sellPrice(0, 4, 0, 0);
				rare = 5;
				noMelee = true;
				return;
			}
			if (type == 3211)
			{
				name = "Bladetongue";
				useStyle = 1;
				useAnimation = 28;
				useTime = 28;
				knockBack = 5.75f;
				width = 40;
				height = 40;
				damage = 55;
				scale = 1.125f;

				rare = 5;
				autoReuse = true;
				value = Item.sellPrice(0, 4, 0, 0);
				melee = true;
				return;
			}
			if (type == 3212)
			{
				name = "Shark Tooth Necklace";
				width = 22;
				height = 22;
				accessory = true;
				rare = 1;
				toolTip = "Increases armor penetration";
				value = Item.sellPrice(0, 1, 0, 0);
				neckSlot = 7;
				return;
			}
			if (type == 3213)
			{
				name = "Money Trough";
				useStyle = 1;
				shootSpeed = 4f;
				shoot = 525;
				width = 26;
				height = 24;

				useAnimation = 28;
				useTime = 28;
				rare = 3;
				value = Item.sellPrice(0, 2, 0, 0);
				return;
			}
			if (type == 3119)
			{
				name = "DPS Meter";
				width = 24;
				height = 18;
				accessory = true;
				rare = 1;
				value = Item.sellPrice(0, 1, 0, 0);
				return;
			}
			if (type == 3118)
			{
				name = "Lifeform Analyzer";
				width = 24;
				height = 18;
				accessory = true;
				rare = 1;
				value = Item.sellPrice(0, 1, 0, 0);
				return;
			}
			if (type == 3096)
			{
				name = "Sextant";
				width = 24;
				height = 18;
				accessory = true;
				rare = 1;
				value = Item.sellPrice(0, 1, 0, 0);
				return;
			}
			if (type == 3120)
			{
				name = "Fisherman's Guide";
				width = 24;
				height = 28;
				rare = 1;
				value = Item.sellPrice(0, 1, 0, 0);
				accessory = true;
				return;
			}
			if (type == 3121)
			{
				name = "Goblin Tech";
				width = 24;
				height = 28;
				rare = 3;
				value = Item.sellPrice(0, 3, 0, 0);
				accessory = true;
				return;
			}
			if (type == 3122)
			{
				name = "REK";
				width = 24;
				height = 28;
				rare = 3;
				value = Item.sellPrice(0, 3, 0, 0);
				accessory = true;
				return;
			}
			if (type == 3123)
			{
				name = "PDA";
				width = 24;
				height = 28;
				rare = 5;
				value = Item.sellPrice(0, 5, 0, 0);
				accessory = true;
				return;
			}
			if (type == 3124)
			{
				name = "Cell Phone";
				width = 24;
				height = 28;
				rare = 7;
				value = Item.sellPrice(0, 8, 0, 0);
				useTurn = true;
				useStyle = 4;
				useTime = 90;

				useAnimation = 90;
				return;
			}
			if (type == 3159 || type == 3160 || type == 3161)
			{
				name = "Bathtubs";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 90;
				if (type == 3159)
				{
					placeStyle = 28;
				}
				else if (type == 3160)
				{
					placeStyle = 30;
				}
				else if (type == 3161)
				{
					placeStyle = 29;
				}
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type == 3162 || type == 3163 || type == 3164)
			{
				name = "Beds";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				autoReuse = true;
				createTile = 79;
				width = 28;
				height = 20;
				value = 2000;
				if (type == 3162)
				{
					placeStyle = 28;
					return;
				}
				if (type == 3163)
				{
					placeStyle = 30;
					return;
				}
				if (type == 3164)
				{
					placeStyle = 29;
					return;
				}
			}
			else if (type == 3165 || type == 3166 || type == 3167)
			{
				name = "Bookcases";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				if (type == 3165)
				{
					placeStyle = 29;
					return;
				}
				if (type == 3166)
				{
					placeStyle = 31;
					return;
				}
				if (type == 3167)
				{
					placeStyle = 30;
					return;
				}
			}
			else if (type == 3168 || type == 3169 || type == 3170)
			{
				name = "Candelabras";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 100;
				width = 20;
				height = 20;
				value = 1500;
				if (type == 3168)
				{
					placeStyle = 28;
					return;
				}
				if (type == 3169)
				{
					placeStyle = 30;
					return;
				}
				if (type == 3170)
				{
					placeStyle = 29;
					return;
				}
			}
			else if (type == 3171 || type == 3172 || type == 3173)
			{
				name = "Candles";
				noWet = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 33;
				width = 8;
				height = 18;
				if (type == 3171)
				{
					placeStyle = 27;
					return;
				}
				if (type == 3172)
				{
					placeStyle = 29;
					return;
				}
				if (type == 3173)
				{
					placeStyle = 28;
					return;
				}
			}
			else if (type == 3174 || type == 3175 || type == 3176)
			{
				name = "Chairs";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				width = 12;
				height = 30;
				if (type == 3174)
				{
					placeStyle = 33;
					return;
				}
				if (type == 3175)
				{
					placeStyle = 35;
					return;
				}
				if (type == 3176)
				{
					placeStyle = 34;
					return;
				}
			}
			else if (type == 3177 || type == 3178 || type == 3179)
			{
				name = "Chandeliers";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 34;
				width = 26;
				height = 26;
				value = 3000;
				if (type == 3177)
				{
					placeStyle = 34;
					return;
				}
				if (type == 3178)
				{
					placeStyle = 36;
					return;
				}
				if (type == 3179)
				{
					placeStyle = 35;
					return;
				}
			}
			else if (type == 3180 || type == 3181 || type == 3125)
			{
				name = "Chests";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				width = 26;
				height = 22;
				value = 500;
				if (type == 3180)
				{
					placeStyle = 49;
					return;
				}
				if (type == 3181)
				{
					placeStyle = 51;
					return;
				}
				if (type == 3125)
				{
					placeStyle = 50;
					return;
				}
			}
			else if (type == 3126 || type == 3127 || type == 3128)
			{
				name = "Clocks";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 104;
				width = 20;
				height = 20;
				value = 300;
				if (type == 3126)
				{
					placeStyle = 25;
					return;
				}
				if (type == 3127)
				{
					placeStyle = 27;
					return;
				}
				if (type == 3128)
				{
					placeStyle = 26;
					return;
				}
			}
			else if (type == 3129 || type == 3130 || type == 3131)
			{
				name = "Doors";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				width = 14;
				height = 28;
				value = 200;
				if (type == 3129)
				{
					placeStyle = 33;
					return;
				}
				if (type == 3130)
				{
					placeStyle = 35;
					return;
				}
				if (type == 3131)
				{
					placeStyle = 34;
					return;
				}
			}
			else if (type == 3132 || type == 3133 || type == 3134)
			{
				name = "Dressers";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 88;
				width = 20;
				height = 20;
				value = 300;
				if (type == 3132)
				{
					placeStyle = 25;
					return;
				}
				if (type == 3133)
				{
					placeStyle = 27;
					return;
				}
				if (type == 3134)
				{
					placeStyle = 26;
					return;
				}
			}
			else if (type == 3135 || type == 3136 || type == 3137)
			{
				name = "Lamps";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 93;
				width = 10;
				height = 24;
				value = 500;
				if (type == 3135)
				{
					placeStyle = 28;
					return;
				}
				if (type == 3136)
				{
					placeStyle = 30;
					return;
				}
				if (type == 3137)
				{
					placeStyle = 29;
					return;
				}
			}
			else if (type == 3138 || type == 3139 || type == 3140)
			{
				name = "Lanterns";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				if (type == 3138)
				{
					placeStyle = 34;
					return;
				}
				if (type == 3139)
				{
					placeStyle = 36;
					return;
				}
				if (type == 3140)
				{
					placeStyle = 35;
					return;
				}
			}
			else if (type == 3141 || type == 3142 || type == 3143)
			{
				name = "Pianos";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 87;
				width = 20;
				height = 20;
				value = 300;
				if (type == 3141)
				{
					placeStyle = 27;
					return;
				}
				if (type == 3142)
				{
					placeStyle = 29;
					return;
				}
				if (type == 3143)
				{
					placeStyle = 28;
					return;
				}
			}
			else if (type == 3144 || type == 3145 || type == 3146)
			{
				name = "Platforms";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 19;
				width = 8;
				height = 10;
				if (type == 3144)
				{
					placeStyle = 27;
					return;
				}
				if (type == 3145)
				{
					placeStyle = 29;
					return;
				}
				if (type == 3146)
				{
					placeStyle = 28;
					return;
				}
			}
			else if (type == 3147 || type == 3148 || type == 3149)
			{
				name = "Sinks";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 172;
				width = 20;
				height = 20;
				value = 300;
				if (type == 3147)
				{
					placeStyle = 29;
					return;
				}
				if (type == 3148)
				{
					placeStyle = 31;
					return;
				}
				if (type == 3149)
				{
					placeStyle = 30;
					return;
				}
			}
			else if (type == 3150 || type == 3151 || type == 3152)
			{
				name = "Sofas";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 89;
				width = 20;
				height = 20;
				value = 300;
				if (type == 3150)
				{
					placeStyle = 30;
					return;
				}
				if (type == 3151)
				{
					placeStyle = 32;
					return;
				}
				if (type == 3152)
				{
					placeStyle = 31;
					return;
				}
			}
			else if (type == 3153 || type == 3154 || type == 3155)
			{
				name = "Tables";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				width = 26;
				height = 20;
				value = 300;
				if (type == 3153)
				{
					placeStyle = 32;
					return;
				}
				if (type == 3154)
				{
					placeStyle = 34;
					return;
				}
				if (type == 3155)
				{
					placeStyle = 33;
					return;
				}
			}
			else if (type == 3156 || type == 3157 || type == 3158)
			{
				name = "Workbenchs";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				width = 28;
				height = 14;
				value = 150;
				if (type == 3156)
				{
					placeStyle = 28;
					return;
				}
				if (type == 3157)
				{
					placeStyle = 30;
					return;
				}
				if (type == 3158)
				{
					placeStyle = 29;
					return;
				}
			}
			else
			{
				if (type == 3182)
				{
					name = "Magic Water Dropper";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 373;
					width = 24;
					height = 24;
					value = Item.sellPrice(0, 0, 1, 0);
					return;
				}
				if (type == 3183)
				{
					name = "Golden Bug Net";
					useTurn = true;
					useStyle = 1;
					useAnimation = 18;
					width = 24;
					height = 28;

					value = Item.sellPrice(0, 5, 0, 0);
					autoReuse = true;
					rare = 4;
					scale = 1.15f;
					return;
				}
				if (type == 3184)
				{
					name = "Magic Lava Dropper";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 374;
					width = 24;
					height = 24;
					value = Item.sellPrice(0, 0, 1, 0);
					return;
				}
				if (type == 3185)
				{
					name = "Magic Honey Dropper";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createTile = 375;
					width = 24;
					height = 24;
					value = Item.sellPrice(0, 0, 1, 0);
					return;
				}
				if (type == 3186)
				{
					name = "Empty Dropper";
					maxStack = 999;
					width = 24;
					height = 24;
					value = Item.buyPrice(0, 0, 1, 0);
					return;
				}
				if (type == 3187)
				{
					name = "Gladiator Helmet";
					width = 18;
					height = 18;
					defense = 2;
					headSlot = 180;
					value = 20000;
					return;
				}
				if (type == 3188)
				{
					name = "Gladiator Breastplate";
					width = 18;
					height = 18;
					defense = 3;
					bodySlot = 182;
					value = 16000;
					return;
				}
				if (type == 3189)
				{
					name = "Gladiator Leggings";
					width = 18;
					height = 18;
					defense = 2;
					legSlot = 122;
					value = 12000;
					return;
				}
				if (type >= 3191 && type <= 3194)
				{
					name = "Grub";
					useStyle = 1;
					autoReuse = true;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					maxStack = 999;
					consumable = true;
					width = 12;
					height = 12;
					makeNPC = (short)(484 + type - 3191);
					noUseGraphic = true;
					if (type == 3192)
					{
						bait = 15;
						return;
					}
					if (type == 3193)
					{
						bait = 25;
						return;
					}
					if (type == 3194)
					{
						bait = 40;
						return;
					}
					bait = 35;
					return;
				}
				else
				{
					if (type == 3195)
					{
						name = "Grub Soup";

						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 10;
						height = 10;
						buffType = 26;
						buffTime = 108000;
						rare = 1;
						toolTip = "Minor improvements to all stats";
						value = 1000;
						return;
					}
					if (type == 3196)
					{
						useStyle = 1;
						name = "Bomb Fish";
						shootSpeed = 6f;
						shoot = 519;
						width = 26;
						height = 26;
						maxStack = 99;
						consumable = true;

						useAnimation = 25;
						useTime = 25;
						noUseGraphic = true;
						noMelee = true;
						value = Item.sellPrice(0, 0, 2, 0);
						damage = 0;
						toolTip = "A small explosion that will destroy some tiles";
						rare = 1;
						return;
					}
					if (type == 3197)
					{
						rare = 1;
						useStyle = 1;
						name = "Frost Daggerfish";
						shootSpeed = 12.5f;
						shoot = 520;
						damage = 17;
						width = 28;
						height = 28;
						maxStack = 999;
						consumable = true;

						useAnimation = 13;
						useTime = 13;
						noUseGraphic = true;
						noMelee = true;
						value = 80;
						knockBack = 3.5f;
						thrown = true;
						return;
					}
					if (type == 3198)
					{
						rare = 1;
						name = "Sharpening Station";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 377;
						width = 28;
						height = 22;
						value = 100000;
						return;
					}
					if (type == 3199)
					{
						name = "Ice Mirror";
						useTurn = true;
						width = 20;
						height = 20;
						useStyle = 4;
						useTime = 90;

						useAnimation = 90;
						toolTip = "Gaze in the mirror to return home";
						rare = 1;
						value = 50000;
						return;
					}
					if (type == 3200)
					{
						name = "Sailfish Boots";
						width = 28;
						height = 24;
						accessory = true;
						rare = 1;
						toolTip = "The wearer can run super fast";
						value = 50000;
						shoeSlot = 17;
						return;
					}
					if (type == 3201)
					{
						name = "Tsunami in a Bottle";
						width = 16;
						height = 24;
						accessory = true;
						rare = 1;
						toolTip = "Allows the holder to double jump";
						value = 50000;
						waistSlot = 11;
						return;
					}
					if (type == 3202)
					{
						rare = 1;
						name = "Target Dummy";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 378;
						width = 20;
						height = 30;
						value = Item.sellPrice(0, 0, 1, 0);
						return;
					}
					if (type == 3214)
					{
						name = "Bubble";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 379;
						width = 12;
						height = 12;
						value = Item.buyPrice(0, 0, 2, 0);
						return;
					}
					if (type >= 3215 && type <= 3222)
					{
						name = "Planter Box";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 380;
						placeStyle = type - 3215;
						width = 24;
						height = 20;
						value = Item.buyPrice(0, 0, 1, 0);
						return;
					}
					if (type == 3223)
					{
						name = "Brain of Confusion";
						width = 22;
						height = 22;
						accessory = true;
						rare = 1;
						toolTip = "May confuse nearby enemies after being struck";
						value = 50000;
						expert = true;
						return;
					}
					if (type == 3224)
					{
						name = "Worm Scarf";
						width = 22;
						height = 22;
						accessory = true;
						rare = 1;
						toolTip = "Reduces damage taken by 10%";
						value = 50000;
						neckSlot = 8;
						expert = true;
						return;
					}
					if (type == 3225)
					{
						name = "Balloon Pufferfish";
						width = 14;
						height = 28;
						rare = 1;
						value = 27000;
						accessory = true;
						toolTip = "Increases jump height";
						balloonSlot = 11;
						return;
					}
					if (type == 3226)
					{
						name = "Lazure's Helmet";
						width = 28;
						height = 20;
						headSlot = 181;
						rare = 9;
						vanity = true;
						return;
					}
					if (type == 3227)
					{
						name = "Lazure's Armor";
						width = 18;
						height = 14;
						bodySlot = 183;
						rare = 9;
						vanity = true;
						return;
					}
					if (type == 3228)
					{
						name = "Lazure's Wings";
						width = 24;
						height = 8;
						accessory = true;
						rare = 9;
						wingSlot = 28;
						value = 400000;
						return;
					}
					if (type >= 3229 && type <= 3233)
					{
						name = "Grave Marker";
						useTurn = true;
						useStyle = 1;
						useAnimation = 15;
						useTime = 10;
						maxStack = 99;
						consumable = true;
						createTile = 85;
						placeStyle = 6 + type - 3229;
						width = 20;
						height = 20;
						return;
					}
					if (type == 3234)
					{
						name = "Crystal Block";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 385;
						width = 12;
						height = 12;
						return;
					}
					if (type >= 3235 && type <= 3237)
					{
						name = "Music Boxes";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						consumable = true;
						createTile = 139;
						placeStyle = 33 + type - 3235;
						width = 24;
						height = 24;
						rare = 4;
						value = 100000;
						accessory = true;
						return;
					}
					if (type == 3238)
					{
						name = "Crystal Wall";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 7;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createWall = 186;
						width = 12;
						height = 12;
						return;
					}
					if (type == 3239)
					{
						name = "Trap Door";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 387;
						width = 20;
						height = 12;
						return;
					}
					if (type == 3240)
					{
						name = "Tall Gate";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 388;
						width = 18;
						height = 26;
						return;
					}
					if (type == 3241)
					{
						name = "Balloon Sharkron";
						width = 14;
						height = 28;
						rare = 1;
						value = 27000;
						accessory = true;
						toolTip = "Increases jump height";
						balloonSlot = 12;
						return;
					}
					if (type == 3242)
					{
						name = "Tax Collector's Hat";
						width = 18;
						height = 18;
						value = Item.buyPrice(0, 3, 0, 0);
						vanity = true;
						headSlot = 182;
						return;
					}
					if (type == 3243)
					{
						name = "Tax Collector's Suit";
						width = 18;
						height = 18;
						value = Item.buyPrice(0, 3, 0, 0);
						vanity = true;
						bodySlot = 184;
						return;
					}
					if (type == 3244)
					{
						name = "Tax Collector's Pants";
						width = 18;
						height = 18;
						value = Item.buyPrice(0, 3, 0, 0);
						vanity = true;
						legSlot = 124;
						return;
					}
					if (type == 3245)
					{
						name = "Bone Glove";
						width = 16;
						height = 16;
						value = Item.sellPrice(0, 1, 0, 0);
						useAnimation = 17;
						useTime = 17;
						useStyle = 1;
						noMelee = true;
						shootSpeed = 1f;
						damage = 11;
						knockBack = 1.8f;
						shoot = 21;
						thrown = true;
						rare = 2;
						useAmmo = 154;
						noUseGraphic = true;
						expert = true;
						return;
					}
					if (type == 3246)
					{
						name = "Clothier's Jacket";
						width = 18;
						height = 18;
						value = Item.buyPrice(0, 3, 0, 0);
						vanity = true;
						bodySlot = 185;
						return;
					}
					if (type == 3247)
					{
						name = "Clothier's Pants";
						width = 18;
						height = 18;
						value = Item.buyPrice(0, 3, 0, 0);
						vanity = true;
						legSlot = 125;
						return;
					}
					if (type == 3248)
					{
						name = "Dye Trader's Turban";
						width = 18;
						height = 18;
						value = Item.buyPrice(0, 3, 0, 0);
						vanity = true;
						headSlot = 183;
						return;
					}
					if (type == 3249)
					{
						mana = 10;
						damage = 50;
						useStyle = 1;
						name = "Deadly Sphere Staff";
						shootSpeed = 10f;
						shoot = 533;
						buffType = 161;
						width = 26;
						height = 28;

						useAnimation = 36;
						useTime = 36;
						rare = 8;
						noMelee = true;
						knockBack = 2f;
						toolTip = "Summons deadly spheres to fight for you";
						value = Item.sellPrice(0, 5, 0, 0);
						summon = true;
						return;
					}
					if (type == 3250 || type == 3251 || type == 3252)
					{
						name = "Horseshoe Balloons";
						width = 20;
						height = 22;
						rare = 4;
						value = 45000;
						accessory = true;
						balloonSlot = (sbyte)(13 + type - 3250);
						return;
					}
					if (type == 3253)
					{
						name = "Lava Lamp";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 390;
						width = 12;
						height = 30;
						value = Item.buyPrice(0, 2, 0, 0);
						rare = 1;
						glowMask = 129;
						return;
					}
					if (type >= 3254 && type <= 3257)
					{
						name = "Critter Cage";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 391 + type - 3254;
						width = 12;
						height = 12;
						return;
					}
					if (type == 3258)
					{
						name = "Slap Hand";
						useStyle = 1;
						useAnimation = 21;
						useTime = 21;
						autoReuse = true;
						knockBack = 20f;
						width = 36;
						height = 36;
						damage = 35;
						scale = 1.1f;

						rare = 4;
						value = Item.buyPrice(0, 25, 0, 0);
						melee = true;
						crit = 15;
						return;
					}
					if (type == 3260)
					{
						useStyle = 4;
						name = "Blessed Apple";
						channel = true;
						width = 34;
						height = 34;

						useAnimation = 20;
						useTime = 20;
						rare = 8;
						noMelee = true;
						mountType = 10;
						value = Item.sellPrice(0, 5, 0, 0);
						return;
					}
					if (type == 3259)
					{
						name = "Twilight Hair Dye";
						width = 20;
						height = 26;
						maxStack = 99;
						rare = 3;
						value = Item.buyPrice(0, 30, 0, 0);

						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						consumable = true;
						return;
					}
					if (type == 3261)
					{
						name = "Spectre Bar";
						width = 20;
						height = 20;
						maxStack = 99;
						rare = 7;
						value = Item.sellPrice(0, 1, 0, 0);
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						consumable = true;
						createTile = 239;
						placeStyle = 21;
						return;
					}
					if (type == 3262 || (type >= 3278 && type <= 3292) || (type >= 3315 && type <= 3317))
					{
						name = "Yoyo";
						useStyle = 5;
						width = 24;
						height = 24;
						noUseGraphic = true;

						melee = true;
						channel = true;
						noMelee = true;
						shoot = 541 + type - 3278;
						useAnimation = 25;
						useTime = 25;
						shootSpeed = 16f;
						if (type == 3278)
						{
							knockBack = 2.5f;
							damage = 9;
							value = Item.sellPrice(0, 0, 1, 0);
							rare = 0;
							return;
						}
						if (type == 3285)
						{
							knockBack = 3.5f;
							damage = 14;
							value = Item.sellPrice(0, 0, 50, 0);
							rare = 1;
							return;
						}
						if (type == 3279)
						{
							knockBack = 4.5f;
							damage = 16;
							value = Item.sellPrice(0, 1, 0, 0);
							rare = 1;
							return;
						}
						if (type == 3280)
						{
							knockBack = 4f;
							damage = 17;
							value = Item.sellPrice(0, 1, 0, 0);
							rare = 1;
							return;
						}
						if (type == 3281)
						{
							knockBack = 3.75f;
							damage = 20;
							value = Item.sellPrice(0, 1, 30, 0);
							rare = 3;
							return;
						}
						if (type == 3317)
						{
							knockBack = 3.85f;
							damage = 22;
							value = Item.sellPrice(0, 1, 50, 0);
							rare = 3;
							shoot = 564;
							return;
						}
						if (type == 3282)
						{
							knockBack = 4.3f;
							damage = 27;
							value = Item.sellPrice(0, 1, 80, 0);
							rare = 3;
							return;
						}
						if (type == 3262)
						{
							knockBack = 3.25f;
							damage = 21;
							value = Item.buyPrice(0, 5, 0, 0);
							rare = 2;
							shoot = 534;
							return;
						}
						if (type == 3315)
						{
							knockBack = 3.25f;
							damage = 29;
							value = Item.sellPrice(0, 4, 0, 0);
							rare = 3;
							shoot = 562;
							return;
						}
						if (type == 3316)
						{
							knockBack = 3.8f;
							damage = 34;
							value = Item.sellPrice(0, 4, 0, 0);
							rare = 3;
							shoot = 563;
							return;
						}
						if (type == 3283)
						{
							knockBack = 3.15f;
							damage = 39;
							value = Item.sellPrice(0, 4, 0, 0);
							rare = 4;
							return;
						}
						if (type == 3289)
						{
							knockBack = 2.8f;
							damage = 43;
							value = Item.sellPrice(0, 4, 0, 0);
							rare = 4;
							return;
						}
						if (type == 3290)
						{
							knockBack = 4.5f;
							damage = 41;
							value = Item.sellPrice(0, 4, 0, 0);
							rare = 4;
							return;
						}
						if (type == 3284)
						{
							knockBack = 3.8f;
							damage = 47;
							value = Item.buyPrice(0, 25, 0, 0);
							rare = 5;
							return;
						}
						if (type == 3286)
						{
							knockBack = 3.1f;
							damage = 60;
							value = Item.sellPrice(0, 5, 0, 0);
							rare = 7;
							return;
						}
						if (type == 3291)
						{
							knockBack = 4.3f;
							damage = 90;
							value = Item.sellPrice(0, 11, 0, 0);
							rare = 8;
							return;
						}
						if (type == 3288 || type == 3287)
						{
							knockBack = 4.5f;
							damage = 70;
							rare = 9;
							value = Item.sellPrice(0, 4, 0, 0);
							return;
						}
						if (type == 3292)
						{
							knockBack = 3.5f;
							damage = 115;
							value = Item.sellPrice(0, 11, 0, 0);
							rare = 8;
							return;
						}
						knockBack = 4f;
						damage = 15;
						rare = 2;
						value = Item.sellPrice(0, 1, 0, 0);
						return;
					}
					else
					{
						if (type == 3389)
						{
							name = "Yoyo";
							useStyle = 5;
							width = 24;
							height = 24;
							noUseGraphic = true;

							melee = true;
							channel = true;
							noMelee = true;
							shoot = 603;
							useAnimation = 25;
							useTime = 25;
							shootSpeed = 16f;
							damage = 190;
							knockBack = 6.5f;
							value = Item.sellPrice(0, 10, 0, 0);
							crit = 10;
							rare = 10;
							return;
						}
						if (type >= 3293 && type <= 3308)
						{
							name = "String";
							width = 24;
							height = 24;
							rare = 1;
							value = Item.sellPrice(0, 0, 3, 0);
							accessory = true;
							if (type == 3307)
							{
								stringColor = 27;
								return;
							}
							if (type == 3306)
							{
								stringColor = 14;
								return;
							}
							if (type == 3308)
							{
								stringColor = 13;
								return;
							}
							if (type == 3305)
							{
								stringColor = 28;
								return;
							}
							stringColor = 1 + type - 3293;
							return;
						}
						else
						{
							if (type >= 3309 && type <= 3314)
							{
								name = "Counterweight";
								width = 24;
								height = 24;
								rare = 2;
								value = Item.buyPrice(0, 5, 0, 0);
								accessory = true;
								return;
							}
							if (type == 3263)
							{
								name = "Hat";
								width = 18;
								height = 18;
								value = Item.buyPrice(0, 3, 0, 0);
								vanity = true;
								headSlot = 184;
								return;
							}
							if (type == 3264)
							{
								name = "Torso";
								width = 18;
								height = 18;
								value = Item.buyPrice(0, 3, 0, 0);
								vanity = true;
								bodySlot = 186;
								return;
							}
							if (type == 3265)
							{
								name = "Pants";
								width = 18;
								height = 18;
								value = Item.buyPrice(0, 3, 0, 0);
								vanity = true;
								legSlot = 126;
								return;
							}
							if (type == 3266)
							{
								name = "Hat";
								width = 18;
								height = 18;
								value = 4500;
								headSlot = 185;
								defense = 4;
								return;
							}
							if (type == 3267)
							{
								name = "Torso";
								width = 18;
								height = 18;
								value = 4500;
								bodySlot = 187;
								defense = 5;
								return;
							}
							if (type == 3268)
							{
								name = "Pants";
								width = 18;
								height = 18;
								value = 4500;
								legSlot = 127;
								defense = 4;
								return;
							}
							if (type == 3269)
							{
								name = "Medusa Head";
								useStyle = 4;
								useAnimation = 20;
								useTime = 20;
								autoReuse = true;
								reuseDelay = 10;
								shootSpeed = 1f;
								knockBack = 2f;
								width = 16;
								height = 16;
								damage = 45;
								shoot = 535;
								mana = 10;
								rare = 4;
								value = Item.sellPrice(0, 1, 0, 0);
								noMelee = true;
								noUseGraphic = true;
								magic = true;
								channel = true;
								return;
							}
							if (type == 3270)
							{
								name = "Item Frame";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								maxStack = 99;
								consumable = true;
								createTile = 395;
								width = 28;
								height = 28;
								rare = 1;
								return;
							}
							if (type == 3272)
							{
								name = "Hardened Sand";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createTile = 397;
								width = 12;
								height = 12;
								return;
							}
							if (type == 3271)
							{
								name = "Sandstone";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createTile = 396;
								width = 12;
								height = 12;
								return;
							}
							if (type == 3273)
							{
								name = "Sandstone Wall";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 7;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createWall = 187;
								width = 12;
								height = 12;
								return;
							}
							if (type == 3344)
							{
								name = "Corrupt Sandstone Wall";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 7;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createWall = 220;
								width = 12;
								height = 12;
								return;
							}
							if (type == 3345)
							{
								name = "Crimson Sandstone Wall";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 7;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createWall = 221;
								width = 12;
								height = 12;
								return;
							}
							if (type == 3346)
							{
								name = "Hallow Sandstone Wall";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 7;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createWall = 222;
								width = 12;
								height = 12;
								return;
							}
							if (type == 3340)
							{
								name = "Hardened Sand Wall";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 7;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createWall = 216;
								width = 12;
								height = 12;
								return;
							}
							if (type == 3341)
							{
								name = "Corrupt Hardened Sand Wall";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 7;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createWall = 217;
								width = 12;
								height = 12;
								return;
							}
							if (type == 3342)
							{
								name = "Crimson Hardened Sand Wall";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 7;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createWall = 218;
								width = 12;
								height = 12;
								return;
							}
							if (type == 3343)
							{
								name = "Hallow Hardened Sand Wall";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 7;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createWall = 219;
								width = 12;
								height = 12;
								return;
							}
							if (type == 3277)
							{
								name = "Crimson Sandstone";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createTile = 401;
								width = 12;
								height = 12;
								return;
							}
							if (type == 3276)
							{
								name = "Corrupt Sandstone";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createTile = 400;
								width = 12;
								height = 12;
								return;
							}
							if (type == 3275)
							{
								name = "Crimson Hardened Sand";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createTile = 399;
								width = 12;
								height = 12;
								return;
							}
							if (type == 3274)
							{
								name = "Corrupt Hardened Sand";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createTile = 398;
								width = 12;
								height = 12;
								return;
							}
							if (type == 3339)
							{
								name = "Hallow Sandstone";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createTile = 403;
								width = 12;
								height = 12;
								return;
							}
							if (type == 3338)
							{
								name = "Hallow Hardened Sand";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createTile = 402;
								width = 12;
								height = 12;
								return;
							}
							if (type == 3347)
							{
								name = "Desert Fossil Block";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createTile = 404;
								width = 12;
								height = 12;
								return;
							}
							if (type == 3348)
							{
								name = "Desert Fossil Wall";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 7;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createWall = 223;
								width = 12;
								height = 12;
								return;
							}
							if (type >= 3318 && type <= 3332)
							{
								name = "Treasure Bag";
								maxStack = 999;
								consumable = true;
								width = 24;
								height = 24;
								rare = 1;
								if (type == 3320)
								{
									rare = 2;
								}
								if (type == 3321)
								{
									rare = 2;
								}
								if (type == 3322)
								{
									rare = 3;
								}
								if (type == 3323)
								{
									rare = 3;
								}
								if (type == 3324)
								{
									rare = 4;
								}
								if (type == 3325)
								{
									rare = 5;
								}
								if (type == 3326)
								{
									rare = 5;
								}
								if (type == 3327)
								{
									rare = 5;
								}
								if (type == 3328)
								{
									rare = 6;
								}
								if (type == 3329)
								{
									rare = 7;
								}
								if (type == 3330)
								{
									rare = 7;
								}
								if (type == 3331)
								{
									rare = 8;
								}
								if (type == 3332)
								{
									rare = 8;
								}
								expert = true;
								return;
							}
							if (type == 3333)
							{
								name = "Hive Backpack";
								width = 22;
								height = 22;
								accessory = true;
								rare = 3;
								value = Item.sellPrice(0, 2, 0, 0);
								backSlot = 9;
								expert = true;
								return;
							}
							if (type == 3334)
							{
								name = "Yoyo Golve";
								width = 22;
								height = 22;
								accessory = true;
								rare = 4;
								value = Item.buyPrice(0, 50, 0, 0);
								handOffSlot = 11;
								handOnSlot = 18;
								return;
							}
							if (type == 3335)
							{
								name = "Demon Heart";
								maxStack = 99;
								consumable = true;
								width = 18;
								height = 18;
								useStyle = 4;
								useTime = 30;

								useAnimation = 30;
								rare = 4;
								value = Item.sellPrice(0, 2, 0, 0);
								expert = true;
								return;
							}
							if (type == 3336)
							{
								name = "Spore Sac";
								width = 22;
								height = 22;
								accessory = true;
								rare = 8;
								value = Item.sellPrice(0, 4, 0, 0);
								expert = true;
								return;
							}
							if (type == 3337)
							{
								name = "Shiny Stone";
								width = 22;
								height = 22;
								accessory = true;
								rare = 8;
								value = Item.sellPrice(0, 5, 0, 0);
								expert = true;
								return;
							}
							if (type == 3353)
							{
								name = "Minecart Mech";
								width = 36;
								height = 26;
								mountType = 11;
								rare = 6;
								value = Item.sellPrice(0, 3, 0, 0);
								expert = true;
								return;
							}
							if (type == 3355 || type == 3354 || type == 3356)
							{
								name = "Mechanical Piece";
								width = 20;
								height = 20;
								maxStack = 99;
								rare = 5;
								value = Item.sellPrice(0, 0, 50, 0);
								expert = true;
								return;
							}
							if (type == 3357 || type == 3358 || type == 3359)
							{
								name = "Trophy";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								maxStack = 99;
								consumable = true;
								createTile = 240;
								width = 30;
								height = 30;
								value = Item.sellPrice(0, 1, 0, 0);
								placeStyle = 56 + type - 3357;
								rare = 1;
								return;
							}
							if (type == 3360)
							{
								name = "Wand";
								tileWand = 620;
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								createTile = 383;
								width = 8;
								height = 10;
								rare = 1;
								return;
							}
							if (type == 3361)
							{
								name = "Wand";
								tileWand = 620;
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								createTile = 384;
								width = 8;
								height = 10;
								rare = 1;
								return;
							}
							if (type == 3362)
							{
								name = "Fallen Tuxedo Shirt";
								width = 28;
								height = 20;
								bodySlot = 188;
								rare = 1;
								vanity = true;
								value = Item.buyPrice(0, 25, 0, 0);
								return;
							}
							if (type == 3363)
							{
								name = "Fallen Tuxedo Pants";
								width = 28;
								height = 20;
								legSlot = 128;
								rare = 1;
								vanity = true;
								value = Item.buyPrice(0, 25, 0, 0);
								return;
							}
							if (type == 3364)
							{
								name = "Fireplace";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								maxStack = 99;
								consumable = true;
								createTile = 405;
								width = 28;
								height = 28;
								rare = 1;
								return;
							}
							if (type == 3365)
							{
								name = "Fireplace";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								maxStack = 99;
								consumable = true;
								createTile = 406;
								width = 28;
								height = 28;
								rare = 1;
								return;
							}
							if (type == 3366)
							{
								name = "Yoyo Bag";
								width = 24;
								height = 24;
								rare = 4;
								value = Item.sellPrice(0, 3, 0, 0);
								accessory = true;
								return;
							}
							if (type == 3367)
							{
								useStyle = 4;
								name = "Shrimpy Truffle";
								channel = true;
								width = 34;
								height = 34;

								useAnimation = 20;
								useTime = 20;
								rare = 8;
								noMelee = true;
								mountType = 12;
								value = Item.sellPrice(0, 5, 0, 0);
								expert = true;
								return;
							}
							if (type == 3368)
							{
								name = "Arkhalis";
								width = 14;
								height = 38;
								useAnimation = 25;
								useTime = 15;
								useStyle = 5;
								rare = 2;
								noUseGraphic = true;
								channel = true;
								noMelee = true;
								damage = 20;
								knockBack = 4f;
								autoReuse = false;
								noMelee = true;
								melee = true;
								shoot = 595;
								shootSpeed = 15f;
								value = 40000;
								return;
							}
							if (type == 3369)
							{
								name = "Confetti Cannon";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createTile = 209;
								placeStyle = 2;
								width = 12;
								height = 12;
								rare = 3;
								value = Item.buyPrice(0, 25, 0, 0);
								return;
							}
							if (type == 3370)
							{
								name = "Music Box (Towers)";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								consumable = true;
								createTile = 139;
								placeStyle = 36;
								width = 24;
								height = 24;
								rare = 4;
								value = 100000;
								accessory = true;
								return;
							}
							if (type == 3371)
							{
								name = "Music Box (Goblins)";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								consumable = true;
								createTile = 139;
								placeStyle = 37;
								width = 24;
								height = 24;
								rare = 4;
								value = 100000;
								accessory = true;
								return;
							}
							if (type >= 3372 && type <= 3373)
							{
								name = "Skeletron Mask";
								width = 28;
								height = 20;
								headSlot = type + 186 - 3372;
								rare = 1;
								vanity = true;
								return;
							}
							if (type == 3374)
							{
								name = "Fossil Helmet";
								width = 18;
								height = 18;
								defense = 3;
								headSlot = 188;
								rare = 1;
								value = Item.sellPrice(0, 0, 30, 0);
								return;
							}
							if (type == 3375)
							{
								name = "Fossil Plate";
								width = 18;
								height = 18;
								defense = 6;
								bodySlot = 189;
								rare = 1;
								value = Item.sellPrice(0, 0, 50, 0);
								return;
							}
							if (type == 3376)
							{
								name = "Fossil Greaves";
								width = 18;
								height = 18;
								defense = 4;
								legSlot = 129;
								rare = 1;
								value = Item.sellPrice(0, 0, 40, 0);
								return;
							}
							if (type == 3377)
							{
								name = "Amber Staff";
								mana = 7;

								useStyle = 5;
								damage = 20;
								useAnimation = 28;
								useTime = 28;
								width = 40;
								height = 40;
								shoot = 597;
								shootSpeed = 9f;
								knockBack = 4.75f;
								magic = true;
								autoReuse = true;
								value = 20000;
								rare = 1;
								noMelee = true;
								return;
							}
							if (type == 3378)
							{
								name = "Bone Javelin";
								shoot = 598;
								shootSpeed = 10f;
								damage = 29;
								knockBack = 5f;
								thrown = true;
								useStyle = 1;

								useAnimation = 25;
								useTime = 25;
								width = 30;
								height = 30;
								maxStack = 999;
								consumable = true;
								noUseGraphic = true;
								noMelee = true;
								autoReuse = true;
								value = 50;
								rare = 1;
								return;
							}
							if (type == 3379)
							{
								autoReuse = true;
								useStyle = 1;
								name = "Bone Knife";
								shootSpeed = 10f;
								shoot = 599;
								damage = 14;
								width = 18;
								height = 20;
								maxStack = 999;
								consumable = true;

								useAnimation = 14;
								useTime = 14;
								noUseGraphic = true;
								noMelee = true;
								value = 50;
								knockBack = 1.5f;
								thrown = true;
								rare = 1;
								return;
							}
							if (type == 3380)
							{
								name = "Fossil Ore";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								maxStack = 999;
								consumable = true;
								createTile = 407;
								width = 12;
								height = 12;
								rare = 1;
								return;
							}
							if (type == 3381)
							{
								name = "Stardust Helmet";
								width = 18;
								height = 18;
								defense = 10;
								headSlot = 189;
								rare = 10;
								return;
							}
							if (type == 3382)
							{
								name = "Stardust Breastplate";
								width = 18;
								height = 18;
								defense = 16;
								bodySlot = 190;
								rare = 10;
								return;
							}
							if (type == 3383)
							{
								name = "Stardust Leggings";
								width = 18;
								height = 18;
								defense = 12;
								legSlot = 130;
								rare = 10;
								return;
							}
							if (type == 3384)
							{
								name = "Portal Gun";
								useStyle = 5;
								useAnimation = 20;
								useTime = 20;
								shootSpeed = 24f;
								knockBack = 2f;
								width = 16;
								height = 16;
								shoot = 600;
								rare = 8;
								value = Item.sellPrice(0, 10, 0, 0);
								noMelee = true;
								noUseGraphic = true;
								channel = true;
								autoReuse = true;
								return;
							}
							if (type >= 3385 && type <= 3388)
							{
								name = "Strange Plant";
								width = 20;
								height = 20;
								maxStack = 99;
								value = 10000;
								rare = -11;
								placeStyle = type - 3385 + 8;
								createTile = 227;
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								consumable = true;
								return;
							}
							if (type >= 3390 && type <= 3452)
							{
								name = "Monster Banner";
								useStyle = 1;
								useTurn = true;
								useAnimation = 15;
								useTime = 10;
								autoReuse = true;
								maxStack = 99;
								consumable = true;
								createTile = 91;
								placeStyle = 207 + type - 3390;
								width = 10;
								height = 24;
								value = 1000;
								rare = 1;
								return;
							}
							if (type >= 3453 && type <= 3455)
							{
								name = "Nebulae";
								width = 12;
								height = 12;
								switch (type)
								{
									case 3453:
										buffType = 179;
										return;
									case 3454:
										buffType = 173;
										return;
									case 3455:
										buffType = 176;
										return;
									default:
										return;
								}
							}
							else
							{
								if (type >= 3456 && type <= 3459)
								{
									name = "Fragment";
									width = 18;
									height = 18;
									maxStack = 999;
									value = Item.sellPrice(0, 0, 20, 0);
									rare = 9;
									return;
								}
								if (type == 3460)
								{
									name = "Lunar Ore";
									useStyle = 1;
									useTurn = true;
									useAnimation = 15;
									useTime = 10;
									autoReuse = true;
									maxStack = 999;
									consumable = true;
									createTile = 408;
									width = 12;
									height = 12;
									rare = 10;
									value = Item.sellPrice(0, 1, 20, 0) / 4;
									return;
								}
								if (type == 3461)
								{
									name = "Lunar Brick";
									useStyle = 1;
									useTurn = true;
									useAnimation = 15;
									useTime = 10;
									autoReuse = true;
									maxStack = 999;
									consumable = true;
									createTile = 409;
									width = 12;
									height = 12;
									return;
								}
								if (type == 3462)
								{
									SetDefaults3(2772);
									type = 3462;
									name = "Stardust Axe";
									glowMask = 174;
									return;
								}
								if (type == 3463)
								{
									SetDefaults3(2773);
									type = 3463;
									name = "Stardust Chainsaw";
									shoot = 610;
									glowMask = 175;
									return;
								}
								if (type == 3464)
								{
									SetDefaults3(2774);
									type = 3464;
									name = "Stardust Drill";
									shoot = 609;
									glowMask = 176;
									return;
								}
								if (type == 3465)
								{
									SetDefaults3(2775);
									type = 3465;
									name = "Stardust Hammer";
									glowMask = 177;
									return;
								}
								if (type == 3466)
								{
									SetDefaults3(2776);
									type = 3466;
									name = "Stardust Pickaxe";
									glowMask = 178;
									return;
								}
								if (type == 3467)
								{
									name = "Luminite";
									width = 20;
									height = 20;
									maxStack = 999;
									rare = 10;
									value = Item.sellPrice(0, 1, 20, 0);
									useStyle = 1;
									useTurn = true;
									useAnimation = 15;
									useTime = 10;
									autoReuse = true;
									consumable = true;
									createTile = 239;
									placeStyle = 22;
									return;
								}
								if (type >= 3468 && type <= 3471)
								{
									name = "Wings";
									width = 22;
									height = 20;
									accessory = true;
									toolTip = "Allows flight and slow fall";
									value = Item.buyPrice(0, 10, 0, 0);
									rare = 10;
									wingSlot = (sbyte)(29 + type - 3468);
									return;
								}
								if (type == 3472)
								{
									name = "Lunar Brick Wall";
									useStyle = 1;
									useTurn = true;
									useAnimation = 15;
									useTime = 7;
									autoReuse = true;
									maxStack = 999;
									consumable = true;
									createWall = 224;
									width = 12;
									height = 12;
									return;
								}
								if (type == 3473)
								{
									name = "Solar Eruption";
									useStyle = 5;
									useAnimation = 20;
									useTime = 20;
									shootSpeed = 24f;
									knockBack = 2f;
									width = 16;
									height = 16;

									shoot = 611;
									rare = 10;
									value = Item.sellPrice(0, 10, 0, 0);
									noMelee = true;
									noUseGraphic = true;
									channel = true;
									autoReuse = true;
									melee = true;
									damage = 105;
									return;
								}
								if (type == 3474)
								{
									mana = 10;
									damage = 60;
									useStyle = 1;
									name = "Stardust Cell Staff";
									shootSpeed = 10f;
									shoot = 613;
									width = 26;
									height = 28;

									useAnimation = 36;
									useTime = 36;
									rare = 10;
									noMelee = true;
									knockBack = 2f;
									buffType = 182;
									value = Item.sellPrice(0, 10, 0, 0);
									summon = true;
									return;
								}
								if (type == 3475)
								{
									name = "Vortex Beater";
									useStyle = 5;
									useAnimation = 20;
									useTime = 20;
									shootSpeed = 20f;
									knockBack = 2f;
									width = 20;
									height = 12;
									damage = 50;

									shoot = 615;
									rare = 10;
									value = Item.sellPrice(0, 10, 0, 0);
									noMelee = true;
									noUseGraphic = true;
									ranged = true;
									channel = true;
									glowMask = 191;
									useAmmo = AmmoID.Bullet;
									autoReuse = true;
									return;
								}
								if (type == 3476)
								{
									mana = 30;
									damage = 70;
									useStyle = 5;
									name = "Nebula Arcanum";
									shootSpeed = 7f;
									shoot = 617;
									width = 26;
									height = 28;

									useAnimation = 30;
									useTime = 30;
									autoReuse = true;
									noMelee = true;
									knockBack = 5f;
									rare = 10;
									value = Item.sellPrice(0, 10, 0, 0);
									magic = true;
									glowMask = 194;
									holdStyle = 1;
									return;
								}
								if (type == 3477)
								{
									useStyle = 1;
									name = "Blood Water";
									shootSpeed = 9f;
									rare = 3;
									damage = 20;
									shoot = 621;
									width = 18;
									height = 20;
									maxStack = 999;
									consumable = true;
									knockBack = 3f;

									useAnimation = 15;
									useTime = 15;
									noUseGraphic = true;
									noMelee = true;
									value = 200;
									toolTip = "Spreads the Crimson to some blocks";
									return;
								}
								if (type == 3478)
								{
									name = "Wedding Veil";
									width = 18;
									height = 18;
									headSlot = 190;
									value = 5000;
									vanity = true;
									return;
								}
								if (type == 3479)
								{
									name = "Wedding Dress";
									width = 18;
									height = 18;
									bodySlot = 191;
									value = 5000;
									vanity = true;
									return;
								}
								if (type >= 3522 && type <= 3525)
								{
									name = "Lunar Hamaxe";
									useTurn = true;
									autoReuse = true;
									useStyle = 1;
									useAnimation = 28;
									useTime = 7;
									knockBack = 7f;
									width = 42;
									height = 42;
									damage = 60;
									axe = 30;
									hammer = 100;

									rare = 10;
									value = Item.sellPrice(0, 5, 0, 0);
									melee = true;
									tileBoost += 4;
									switch (type)
									{
										case 3522:
											break;
										case 3523:
											glowMask = 196;
											return;
										case 3524:
											glowMask = 197;
											return;
										case 3525:
											glowMask = 198;
											return;
										default:
											return;
									}
								}
								else
								{
									if (type == 3521)
									{
										SetDefaults1(1);
										type = type;
										useTime = 17;
										pick = 55;
										useAnimation = 20;
										scale = 1.05f;
										damage = 6;
										value = 10000;
										return;
									}
									if (type == 3520)
									{
										SetDefaults1(4);
										type = type;
										useAnimation = 20;
										damage = 13;
										scale = 1.05f;
										value = 9000;
										return;
									}
									if (type == 3519)
									{
										SetDefaults1(6);
										type = type;
										damage = 11;
										useAnimation = 11;
										scale = 0.95f;
										value = 7000;
										return;
									}
									if (type == 3517)
									{
										SetDefaults1(7);
										type = type;
										useAnimation = 28;
										useTime = 23;
										scale = 1.25f;
										damage = 9;
										hammer = 55;
										value = 8000;
										return;
									}
									if (type == 3518)
									{
										SetDefaults1(10);
										type = type;
										useTime = 18;
										axe = 11;
										useAnimation = 26;
										scale = 1.15f;
										damage = 7;
										value = 8000;
										return;
									}
									if (type == 3516)
									{
										SetDefaults1(99);
										type = type;
										useAnimation = 26;
										useTime = 26;
										damage = 11;
										value = 7000;
										return;
									}
									if (type == 3515)
									{
										SetDefaults1(1);
										type = type;
										useTime = 11;
										pick = 45;
										useAnimation = 19;
										scale = 1.05f;
										damage = 6;
										value = 5000;
										return;
									}
									if (type == 3514)
									{
										SetDefaults1(4);
										type = type;
										useAnimation = 21;
										damage = 11;
										value = 4500;
										return;
									}
									if (type == 3513)
									{
										SetDefaults1(6);
										type = type;
										damage = 9;
										useAnimation = 12;
										scale = 0.95f;
										value = 3500;
										return;
									}
									if (type == 3511)
									{
										SetDefaults1(7);
										type = type;
										useAnimation = 29;
										useTime = 19;
										scale = 1.25f;
										damage = 9;
										hammer = 45;
										value = 4000;
										return;
									}
									if (type == 3512)
									{
										SetDefaults1(10);
										type = type;
										useTime = 18;
										axe = 10;
										useAnimation = 26;
										scale = 1.15f;
										damage = 6;
										value = 4000;
										return;
									}
									if (type == 3510)
									{
										SetDefaults1(99);
										type = type;
										useAnimation = 27;
										useTime = 27;
										damage = 9;
										value = 3500;
										return;
									}
									if (type == 3509)
									{
										SetDefaults1(1);
										type = type;
										useTime = 15;
										pick = 35;
										useAnimation = 23;
										damage = 4;
										scale = 0.9f;
										tileBoost = -1;
										value = 500;
										return;
									}
									if (type == 3508)
									{
										SetDefaults1(4);
										type = type;
										useAnimation = 23;
										damage = 8;
										value = 450;
										return;
									}
									if (type == 3507)
									{
										SetDefaults1(6);
										type = type;
										damage = 5;
										useAnimation = 13;
										scale = 0.8f;
										value = 350;
										return;
									}
									if (type == 3505)
									{
										SetDefaults1(7);
										type = type;
										useAnimation = 33;
										useTime = 23;
										scale = 1.1f;
										damage = 4;
										hammer = 35;
										tileBoost = -1;
										value = 400;
										return;
									}
									if (type == 3506)
									{
										SetDefaults1(10);
										type = type;
										useTime = 21;
										axe = 7;
										useAnimation = 30;
										scale = 1f;
										damage = 3;
										tileBoost = -1;
										value = 400;
										return;
									}
									if (type == 3504)
									{
										SetDefaults1(99);
										type = type;
										useAnimation = 29;
										useTime = 29;
										damage = 6;
										value = 350;
										return;
									}
									if (type == 3503)
									{
										SetDefaults1(1);
										type = type;
										useTime = 14;
										pick = 35;
										useAnimation = 21;
										damage = 5;
										scale = 0.95f;
										value = 750;
										return;
									}
									if (type == 3502)
									{
										SetDefaults1(4);
										type = type;
										useAnimation = 22;
										damage = 9;
										value = 675;
										return;
									}
									if (type == 3501)
									{
										SetDefaults1(6);
										type = type;
										damage = 7;
										useAnimation = 12;
										scale = 0.85f;
										value = 525;
										return;
									}
									if (type == 3499)
									{
										SetDefaults1(7);
										type = type;
										useAnimation = 31;
										useTime = 21;
										scale = 1.15f;
										damage = 6;
										hammer = 38;
										value = 600;
										return;
									}
									if (type == 3500)
									{
										SetDefaults1(10);
										type = type;
										useTime = 20;
										axe = 8;
										useAnimation = 28;
										scale = 1.05f;
										damage = 4;
										value = 600;
										return;
									}
									if (type == 3498)
									{
										SetDefaults1(99);
										type = type;
										useAnimation = 28;
										useTime = 28;
										damage = 7;
										value = 525;
										return;
									}
									if (type == 3497)
									{
										SetDefaults1(1);
										type = type;
										useTime = 12;
										pick = 43;
										useAnimation = 19;
										damage = 6;
										scale = 1.025f;
										value = 3000;
										return;
									}
									if (type == 3496)
									{
										SetDefaults1(4);
										type = type;
										useAnimation = 21;
										damage = 11;
										value = 2700;
										return;
									}
									if (type == 3495)
									{
										SetDefaults1(6);
										type = type;
										damage = 9;
										useAnimation = 12;
										scale = 0.925f;
										value = 2100;
										return;
									}
									if (type == 3493)
									{
										SetDefaults1(7);
										type = type;
										useAnimation = 29;
										useTime = 19;
										scale = 1.225f;
										damage = 8;
										hammer = 43;
										value = 2400;
										return;
									}
									if (type == 3494)
									{
										SetDefaults1(10);
										type = type;
										useTime = 19;
										axe = 10;
										useAnimation = 28;
										scale = 1.125f;
										damage = 6;
										value = 2400;
										return;
									}
									if (type == 3492)
									{
										SetDefaults1(99);
										type = type;
										useAnimation = 27;
										useTime = 27;
										damage = 9;
										value = 2100;
										return;
									}
									if (type == 3491)
									{
										SetDefaults1(1);
										type = type;
										useTime = 19;
										pick = 50;
										useAnimation = 21;
										scale = 1.05f;
										damage = 6;
										value = 7500;
										return;
									}
									if (type == 3490)
									{
										SetDefaults1(4);
										type = type;
										useAnimation = 20;
										damage = 12;
										scale *= 1.025f;
										value = 6750;
										return;
									}
									if (type == 3489)
									{
										SetDefaults1(6);
										type = type;
										damage = 10;
										useAnimation = 11;
										scale = 0.95f;
										value = 5250;
										return;
									}
									if (type == 3487)
									{
										SetDefaults1(7);
										type = type;
										useAnimation = 28;
										useTime = 25;
										scale = 1.25f;
										damage = 9;
										hammer = 50;
										value = 6000;
										return;
									}
									if (type == 3488)
									{
										SetDefaults1(10);
										type = type;
										useTime = 18;
										axe = 11;
										useAnimation = 26;
										scale = 1.15f;
										damage = 7;
										value = 4000;
										return;
									}
									if (type == 3486)
									{
										SetDefaults1(99);
										type = type;
										useAnimation = 26;
										useTime = 26;
										damage = 10;
										value = 5250;
										return;
									}
									if (type == 3485)
									{
										SetDefaults1(1);
										type = type;
										useTime = 15;
										pick = 59;
										useAnimation = 19;
										scale = 1.05f;
										damage = 7;
										value = 15000;
										return;
									}
									if (type == 3484)
									{
										SetDefaults1(4);
										type = type;
										useAnimation = 19;
										damage = 15;
										scale = 1.075f;
										value = 13500;
										return;
									}
									if (type == 3483)
									{
										SetDefaults1(6);
										type = type;
										damage = 13;
										useAnimation = 10;
										scale = 0.975f;
										value = 10500;
										return;
									}
									if (type == 3481)
									{
										SetDefaults1(7);
										type = type;
										useAnimation = 27;
										useTime = 21;
										scale = 1.275f;
										damage = 10;
										hammer = 59;
										value = 12000;
										return;
									}
									if (type == 3482)
									{
										SetDefaults1(10);
										type = type;
										useTime = 17;
										axe = 12;
										useAnimation = 25;
										scale = 1.175f;
										damage = 8;
										value = 12000;
										return;
									}
									if (type == 3480)
									{
										SetDefaults1(99);
										type = type;
										useAnimation = 25;
										useTime = 25;
										damage = 13;
										value = 10500;
										return;
									}
									if (type == 3526)
									{
										name = "Solar Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = Item.sellPrice(0, 2, 50, 0);
										rare = 4;
										return;
									}
									if (type == 3527)
									{
										name = "Nebula Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = Item.sellPrice(0, 2, 50, 0);
										rare = 4;
										return;
									}
									if (type == 3528)
									{
										name = "Vortex Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = Item.sellPrice(0, 2, 50, 0);
										rare = 4;
										return;
									}
									if (type == 3529)
									{
										name = "Stardust Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = Item.sellPrice(0, 2, 50, 0);
										rare = 4;
										return;
									}
									if (type == 3530)
									{
										name = "Void Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = Item.sellPrice(0, 2, 50, 0);
										rare = 4;
										return;
									}
									if (type == 3531)
									{
										mana = 10;
										damage = 40;
										useStyle = 1;
										name = "Stardust Dragon Staff";
										shootSpeed = 10f;
										shoot = 625;
										width = 26;
										height = 28;

										useAnimation = 36;
										useTime = 36;
										rare = 10;
										noMelee = true;
										knockBack = 2f;
										buffType = 188;
										value = Item.sellPrice(0, 10, 0, 0);
										summon = true;
										return;
									}
									if (type == 3540)
									{
										name = "Phantasm";
										useStyle = 5;
										useAnimation = 12;
										useTime = 12;
										shootSpeed = 20f;
										knockBack = 2f;
										width = 20;
										height = 12;
										damage = 50;

										shoot = 630;
										rare = 10;
										value = Item.sellPrice(0, 10, 0, 0);
										noMelee = true;
										noUseGraphic = true;
										ranged = true;
										channel = true;
										glowMask = 200;
										useAmmo = AmmoID.Arrow;
										autoReuse = true;
										return;
									}
									if (type == 3532)
									{
										name = "Bacon";

										useStyle = 2;
										useTurn = true;
										useAnimation = 17;
										useTime = 17;
										maxStack = 30;
										consumable = true;
										width = 10;
										height = 10;
										buffType = 26;
										buffTime = 108000;
										rare = 1;
										toolTip = "Minor improvements to all stats";
										value = 1000;
										return;
									}
									if (type == 3541)
									{
										name = "Last Prism";
										useStyle = 5;
										useAnimation = 10;
										useTime = 10;
										reuseDelay = 5;
										shootSpeed = 30f;
										knockBack = 0f;
										width = 16;
										height = 16;
										damage = 100;

										shoot = 633;
										mana = 12;
										rare = 10;
										value = Item.sellPrice(0, 10, 0, 0);
										noMelee = true;
										noUseGraphic = true;
										magic = true;
										channel = true;
										return;
									}
									if (type == 3533)
									{
										name = "Shifting Sands Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = Item.sellPrice(0, 1, 50, 0);
										rare = 3;
										return;
									}
									if (type == 3534)
									{
										name = "Mirage Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = Item.sellPrice(0, 0, 75, 0);
										rare = 2;
										return;
									}
									if (type == 3535)
									{
										name = "Shifting Pearlsands Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = Item.sellPrice(0, 1, 50, 0);
										rare = 3;
										return;
									}
									if (type == 3536)
									{
										name = "Vortex Monolith";
										width = 22;
										height = 32;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 410;
										placeStyle = 0;
										rare = 9;
										value = Item.buyPrice(0, 5, 0, 0);
										return;
									}
									if (type == 3537)
									{
										name = "Nebula Monolith";
										width = 22;
										height = 32;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 410;
										placeStyle = 1;
										rare = 9;
										value = Item.buyPrice(1, 0, 0, 0);
										return;
									}
									if (type == 3538)
									{
										name = "Stardust Monolith";
										width = 22;
										height = 32;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 410;
										placeStyle = 2;
										rare = 9;
										value = Item.buyPrice(1, 0, 0, 0);
										return;
									}
									if (type == 3539)
									{
										name = "Solar Monolith";
										width = 22;
										height = 32;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 410;
										placeStyle = 3;
										rare = 9;
										value = Item.buyPrice(1, 0, 0, 0);
										return;
									}
									if (type == 3542)
									{
										name = "Nebula Blaze";
										useStyle = 5;
										useAnimation = 15;
										useTime = 15;
										shootSpeed = 6f;
										knockBack = 0f;
										width = 16;
										height = 16;
										damage = 130;

										shoot = 634;
										mana = 18;
										rare = 10;
										value = Item.sellPrice(0, 10, 0, 0);
										noMelee = true;
										magic = true;
										autoReuse = true;
										noUseGraphic = true;
										glowMask = 207;
										return;
									}
									if (type == 3543)
									{
										name = "Daybreak";
										shoot = 636;
										shootSpeed = 10f;
										damage = 150;
										knockBack = 5f;
										melee = true;
										useStyle = 1;

										useAnimation = 16;
										useTime = 16;
										width = 30;
										height = 30;
										noUseGraphic = true;
										noMelee = true;
										autoReuse = true;
										value = Item.sellPrice(0, 10, 0, 0);
										rare = 10;
										return;
									}
									if (type == 3544)
									{
										name = "Super Healing Potion";

										healLife = 200;
										useStyle = 2;
										useTurn = true;
										useAnimation = 17;
										useTime = 17;
										maxStack = 30;
										consumable = true;
										potion = true;
										width = 14;
										height = 24;
										rare = 7;
										value = 1500;
										return;
									}
									if (type == 3545)
									{
										name = "Detonator";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 411;
										width = 28;
										height = 28;
										rare = 1;
										mech = true;
										return;
									}
									if (type == 3547)
									{
										useStyle = 1;
										name = "Bouncy Dynamite";
										shootSpeed = 4f;
										shoot = 637;
										width = 8;
										height = 28;
										maxStack = 30;
										consumable = true;

										useAnimation = 40;
										useTime = 40;
										noUseGraphic = true;
										noMelee = true;
										value = Item.buyPrice(0, 0, 20, 0);
										rare = 1;
										return;
									}
									if (type == 3546)
									{
										crit = 10;
										useStyle = 5;
										autoReuse = true;
										useAnimation = 30;
										useTime = 30;
										name = "Fireworks Launcher";
										useAmmo = AmmoID.Rocket;
										width = 50;
										height = 20;
										shoot = 134;

										damage = 65;
										shootSpeed = 15f;
										noMelee = true;
										value = Item.sellPrice(0, 10, 0, 0);
										knockBack = 4f;
										rare = 10;
										ranged = true;
										return;
									}
									if (type == 3350)
									{
										useStyle = 5;
										useAnimation = 24;
										useTime = 9;
										name = "Paintball Gun";
										width = 24;
										height = 14;
										shoot = 587;
										damage = 12;
										shootSpeed = 10f;
										noMelee = true;
										value = Item.sellPrice(0, 0, 50, 0);
										knockBack = 1.25f;
										scale = 0.85f;
										rare = 2;
										ranged = true;
										crit = 7;
										return;
									}
									if (type == 3352)
									{
										SetDefaults1(4);
										type = type;
										useAnimation = 12;
										useTime = 12;
										damage = 14;
										width = (height = 32);
										knockBack = 5f;
										rare = 2;
										value = Item.sellPrice(0, 0, 50, 0);
										return;
									}
									if (type == 3351)
									{
										SetDefaults1(4);
										type = type;
										useAnimation = 15;
										useTime = 15;
										damage = 16;
										width = (height = 28);
										knockBack = 3.5f;
										rare = 2;
										value = Item.sellPrice(0, 0, 50, 0);
										return;
									}
									if (type == 3349)
									{
										SetDefaults1(4);
										type = type;
										useAnimation = 18;
										useTime = 18;
										damage = 20;
										width = (height = 32);
										knockBack = 4.25f;
										rare = 2;
										value = Item.sellPrice(0, 0, 50, 0);
										return;
									}
									if (type == 3548)
									{
										useStyle = 5;
										name = "Party Grenade";
										shootSpeed = 6f;
										shoot = 588;
										width = 20;
										height = 20;
										maxStack = 99;
										consumable = true;

										useAnimation = 20;
										useTime = 20;
										noUseGraphic = true;
										noMelee = true;
										value = Item.sellPrice(0, 0, 0, 50);
										damage = 30;
										knockBack = 6f;
										rare = 2;
										thrown = true;
										return;
									}
									if (type == 3549)
									{
										name = "Lunar Crafting Station";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 412;
										width = 28;
										height = 28;
										rare = 10;
										return;
									}
									if (type == 3563)
									{
										name = "Squirrel";
										useStyle = 1;
										autoReuse = true;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										maxStack = 999;
										consumable = true;
										width = 12;
										height = 12;
										noUseGraphic = true;
										makeNPC = 538;
										return;
									}
									if (type == 3564)
									{
										name = "Gold Critter";
										useStyle = 1;
										autoReuse = true;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										maxStack = 999;
										consumable = true;
										width = 12;
										height = 12;
										makeNPC = 539;
										noUseGraphic = true;
										value = Item.sellPrice(0, 10, 0, 0);
										rare = 2;
										return;
									}
									if (type == 3565)
									{
										name = "Critter Cage";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 413;
										width = 12;
										height = 12;
										return;
									}
									if (type == 3566)
									{
										name = "Gold Critter Cage";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 414;
										width = 12;
										height = 12;
										value = Item.sellPrice(0, 10, 0, 0);
										rare = 2;
										return;
									}
									if (type == 3550)
									{
										name = "Flame And Silver Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = 10000;
										rare = 1;
										return;
									}
									if (type == 3551)
									{
										name = "Green Flame And Silver Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = 10000;
										rare = 1;
										return;
									}
									if (type == 3552)
									{
										name = "Blue Flame And Silver Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = 10000;
										rare = 1;
										return;
									}
									if (type == 3553)
									{
										name = "Reflective Copper Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = Item.sellPrice(0, 0, 75, 0);
										rare = 2;
										return;
									}
									if (type == 3554)
									{
										name = "Reflective Obsidian Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = Item.sellPrice(0, 0, 75, 0);
										rare = 2;
										return;
									}
									if (type == 3555)
									{
										name = "Reflective Metal Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = Item.sellPrice(0, 0, 75, 0);
										rare = 2;
										return;
									}
									if (type == 3556)
									{
										name = "Midnight Rainbow Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = Item.sellPrice(0, 1, 50, 0);
										rare = 3;
										return;
									}
									if (type == 3557)
									{
										name = "Black And White Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = 10000;
										rare = 1;
										return;
									}
									if (type == 3558)
									{
										name = "Bright Silver Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = 10000;
										rare = 1;
										return;
									}
									if (type == 3559)
									{
										name = "Silver And Black Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = 10000;
										rare = 1;
										return;
									}
									if (type == 3560)
									{
										name = "Red Acid Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = 10000;
										rare = 1;
										return;
									}
									if (type == 3561)
									{
										name = "Gel Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = Item.sellPrice(0, 1, 50, 0);
										rare = 3;
										return;
									}
									if (type == 3562)
									{
										name = "Pink Gel Dye";
										width = 20;
										height = 20;
										maxStack = 99;
										value = Item.sellPrice(0, 1, 50, 0);
										rare = 3;
										return;
									}
									if (type == 3567)
									{
										name = "Phaser Bullet";
										shootSpeed = 2f;
										shoot = 638;
										damage = 20;
										width = 8;
										height = 8;
										maxStack = 999;
										consumable = true;
										ammo = AmmoID.Bullet;
										knockBack = 3f;
										value = 7;
										ranged = true;
										rare = 9;
										value = Item.sellPrice(0, 0, 0, 2);
										return;
									}
									if (type == 3568)
									{
										name = "Luminite Arrow";
										shootSpeed = 3f;
										shoot = 639;
										damage = 15;
										width = 10;
										height = 28;
										maxStack = 999;
										consumable = true;
										ammo = AmmoID.Arrow;
										knockBack = 3.5f;
										value = 5;
										ranged = true;
										rare = 9;
										value = Item.sellPrice(0, 0, 0, 2);
										return;
									}
									if (type == 3569)
									{
										mana = 10;
										damage = 50;
										name = "Lunar Portal Staff";
										useStyle = 1;
										shootSpeed = 14f;
										shoot = 641;
										width = 18;
										height = 20;

										useAnimation = 30;
										useTime = 30;
										noMelee = true;
										value = Item.sellPrice(0, 10, 0, 0);
										knockBack = 7.5f;
										rare = 10;
										summon = true;
										sentry = true;
										return;
									}
									if (type == 3571)
									{
										mana = 10;
										damage = 150;
										name = "Rainbow Crystal Staff";
										useStyle = 1;
										shootSpeed = 14f;
										shoot = 643;
										width = 18;
										height = 20;

										useAnimation = 30;
										useTime = 30;
										noMelee = true;
										value = Item.sellPrice(0, 10, 0, 0);
										knockBack = 7.5f;
										rare = 10;
										summon = true;
										sentry = true;
										return;
									}
									if (type == 3570)
									{
										autoReuse = true;
										name = "Flare Staff";
										mana = 13;
										useStyle = 5;
										damage = 100;
										useAnimation = 10;
										useTime = 10;
										width = 40;
										height = 40;
										shoot = 645;
										shootSpeed = 10f;
										knockBack = 4.5f;
										value = Item.sellPrice(0, 10, 0, 0);
										magic = true;
										rare = 10;
										noMelee = true;

										return;
									}
									if (type == 3572)
									{
										noUseGraphic = true;
										damage = 0;
										useStyle = 5;
										name = "Lunar Hook";
										shootSpeed = 16f;
										shoot = 646;
										width = 18;
										height = 28;

										useAnimation = 20;
										useTime = 20;
										rare = 10;
										noMelee = true;
										value = Item.sellPrice(0, 10, 0, 0);
										return;
									}
									if (type >= 3573 && type <= 3576)
									{
										name = "Lunar Block";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 415 + type - 3573;
										width = 12;
										height = 12;
										return;
									}
									if (type == 3577)
									{
										channel = true;
										damage = 0;
										useStyle = 4;
										name = "Suspicious Looking Tentacle";
										shoot = 650;
										width = 24;
										height = 24;

										useAnimation = 20;
										useTime = 20;
										rare = 10;
										noMelee = true;
										toolTip = "Summons a suspicious tentacle";
										value = Item.sellPrice(0, 10, 0, 0);
										buffType = 190;
										return;
									}
									if (type == 3578)
									{
										name = "If you're reading this, hi";
										width = 28;
										height = 20;
										bodySlot = 192;
										rare = 9;
										vanity = true;
										return;
									}
									if (type == 3579)
									{
										name = "Yes, this is my dev armor, deal with it";
										width = 18;
										height = 14;
										legSlot = 132;
										rare = 9;
										vanity = true;
										return;
									}
									if (type == 3580)
									{
										name = "Isn't this glorious?";
										width = 18;
										height = 14;
										wingSlot = 33;
										rare = 9;
										accessory = true;
										value = 400000;
										return;
									}
									if (type == 3581)
									{
										name = "Dark...";
										width = 18;
										height = 14;
										rare = 9;
										vanity = true;
										accessory = true;
										return;
									}
									if (type == 3582)
									{
										name = "Jimm's Wings";
										width = 24;
										height = 8;
										accessory = true;
										rare = 9;
										wingSlot = 34;
										value = 400000;
										return;
									}
									if (type == 3583)
									{
										name = "Testokun";
										width = 28;
										height = 20;
										headSlot = 191;
										rare = 9;
										vanity = true;
										return;
									}
									if (type == 3584)
									{
										name = "Living Leaf Wall";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 7;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createWall = 60;
										width = 12;
										height = 12;
										return;
									}
									if (type == 3585)
									{
										name = "Skiphs's Helm";
										width = 28;
										height = 20;
										headSlot = 192;
										rare = 9;
										vanity = true;
										return;
									}
									if (type == 3586)
									{
										name = "Skiphs's Shirt";
										width = 28;
										height = 20;
										bodySlot = 193;
										rare = 9;
										vanity = true;
										return;
									}
									if (type == 3587)
									{
										name = "Skiphs's Pants";
										width = 18;
										height = 14;
										legSlot = 133;
										rare = 9;
										vanity = true;
										return;
									}
									if (type == 3588)
									{
										name = "Skiphs's Wings";
										width = 24;
										height = 8;
										accessory = true;
										rare = 9;
										wingSlot = 35;
										value = 400000;
										return;
									}
									if (type == 3589)
									{
										name = "Loki's Helm";
										width = 28;
										height = 20;
										headSlot = 193;
										rare = 9;
										vanity = true;
										return;
									}
									if (type == 3590)
									{
										name = "Loki's Shirt";
										width = 28;
										height = 20;
										bodySlot = 194;
										rare = 9;
										vanity = true;
										return;
									}
									if (type == 3591)
									{
										name = "Loki's Pants";
										width = 18;
										height = 14;
										legSlot = 134;
										rare = 9;
										vanity = true;
										return;
									}
									if (type == 3592)
									{
										name = "Loki's Wings";
										width = 24;
										height = 8;
										accessory = true;
										rare = 9;
										wingSlot = 36;
										value = 400000;
										return;
									}
									if (type >= 3593 && type <= 3594)
									{
										name = "Monster Banner";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 91;
										placeStyle = 270 + type - 3593;
										width = 10;
										height = 24;
										value = 1000;
										rare = 1;
										return;
									}
									if (type == 3595)
									{
										name = "Trophy";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 240;
										width = 30;
										height = 30;
										value = Item.sellPrice(0, 1, 0, 0);
										placeStyle = 59;
										rare = 1;
										return;
									}
									if (type == 3596)
									{
										name = "moonlord painting";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 242;
										width = 30;
										height = 30;
										value = Item.buyPrice(0, 3, 0, 0);
										placeStyle = 36;
										return;
									}
									if (type == 3601)
									{
										useStyle = 4;
										name = "Celestial Sigil";
										width = 22;
										height = 14;
										consumable = true;
										useAnimation = 45;
										useTime = 45;
										maxStack = 20;
										toolTip = "Summons the impending doom";
										rare = 10;
										return;
									}
									if (type == 3602)
									{
										name = "logic";
										createTile = 419;
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										mech = true;
										value = Item.buyPrice(0, 0, 10, 0);
										return;
									}
									if (type >= 3603 && type <= 3608)
									{
										name = "logic";
										createTile = 420;
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										placeStyle = type - 3603;
										mech = true;
										value = Item.buyPrice(0, 2, 0, 0);
										return;
									}
									if (type == 3609)
									{
										name = "logic";
										createTile = 421;
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										value = Item.buyPrice(0, 0, 5, 0);
										return;
									}
									if (type == 3610)
									{
										name = "logic";
										createTile = 422;
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										value = Item.buyPrice(0, 0, 5, 0);
										return;
									}
									if (type == 3611)
									{
										name = "kite";
										useStyle = 5;
										useAnimation = 10;
										useTime = 10;
										width = 20;
										height = 20;
										shoot = 651;
										channel = true;
										shootSpeed = 10f;
										value = Item.buyPrice(0, 15, 0, 0);
										rare = 2;

										mech = true;
										return;
									}
									if (type == 3612)
									{
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 5;
										autoReuse = true;
										name = "Wrench";
										width = 24;
										height = 28;
										rare = 1;
										value = 20000;
										tileBoost = 20;
										mech = true;
										return;
									}
									if (type >= 3613 && type <= 3615)
									{
										name = "logic";
										createTile = 423;
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										placeStyle = type - 3613;
										mech = true;
										return;
									}
									if (type == 3616)
									{
										name = "logic";
										createTile = 424;
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										mech = true;
										value = Item.buyPrice(0, 0, 2, 0);
										return;
									}
									if (type == 3617)
									{
										name = "Sign";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 425;
										width = 28;
										height = 28;
										mech = true;
										return;
									}
									if (type == 3618)
									{
										name = "logic";
										createTile = 419;
										placeStyle = 1;
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										mech = true;
										value = Item.buyPrice(0, 0, 10, 0);
										return;
									}
									if (type == 3619)
									{
										name = "info acc";
										width = 24;
										height = 28;
										rare = 3;
										value = Item.buyPrice(0, 1, 0, 0);
										accessory = true;
										return;
									}
									if (type == 3620)
									{
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 5;
										autoReuse = true;
										name = "rod";
										width = 24;
										height = 28;
										rare = 1;
										value = 20000;
										tileBoost = 20;
										mech = true;
										return;
									}
									if (type == 3621)
									{
										name = "logic";
										createTile = 426;
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										value = Item.buyPrice(0, 0, 1, 0);
										return;
									}
									if (type == 3622)
									{
										name = "logic";
										createTile = 427;
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										value = Item.buyPrice(0, 0, 1, 0);
										return;
									}
									if (type == 3623)
									{
										noUseGraphic = true;
										damage = 0;
										useStyle = 5;
										name = "Static Hook";
										shootSpeed = 16f;
										shoot = 652;
										width = 18;
										height = 28;
										useAnimation = 20;
										useTime = 20;
										rare = 10;
										noMelee = true;
										value = Item.sellPrice(0, 10, 0, 0);
										return;
									}
									if (type == 3624)
									{
										name = "Builder's Accessories";
										width = 30;
										height = 30;
										accessory = true;
										rare = 3;
										value = Item.buyPrice(0, 10, 0, 0);
										return;
									}
									if (type == 3625)
									{
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 5;
										autoReuse = true;
										name = "Wrench";
										width = 24;
										height = 28;
										rare = 1;
										value = 100000;
										tileBoost = 20;
										mech = true;
										return;
									}
									if (type == 3626)
									{
										name = "logic";
										createTile = 428;
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										placeStyle = 3;
										mech = true;
										return;
									}
									if (type == 3627)
									{
										name = "Engineering Helmet";
										width = 18;
										height = 18;
										headSlot = 194;
										value = Item.buyPrice(0, 1, 0, 0);
										vanity = true;
										return;
									}
									if (type == 3628)
									{
										channel = true;
										damage = 0;
										useStyle = 4;
										name = "Companion Cube";
										shoot = 653;
										width = 24;
										height = 24;

										useAnimation = 20;
										useTime = 20;
										rare = 1;
										noMelee = true;
										value = Item.buyPrice(5, 0, 0, 0);
										buffType = 191;
										return;
									}
									if (type == 3629)
									{
										name = "logic";
										createTile = 429;
										width = 16;
										height = 16;
										rare = 2;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										mech = true;
										value = Item.buyPrice(0, 5, 0, 0);
										return;
									}
									if (type == 3630)
									{
										name = "logic";
										createTile = 428;
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										placeStyle = 0;
										mech = true;
										return;
									}
									if (type == 3631)
									{
										name = "logic";
										createTile = 428;
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										placeStyle = 2;
										mech = true;
										return;
									}
									if (type == 3632)
									{
										name = "logic";
										createTile = 428;
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										placeStyle = 1;
										mech = true;
										return;
									}
									if (type >= 3633 && type <= 3637)
									{
										name = "logic";
										createTile = 430 + (type - 3633);
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										value = Item.buyPrice(0, 0, 1, 0);
										return;
									}
									if (type >= 3638 && type <= 3642)
									{
										name = "logic";
										createTile = 435 + (type - 3638);
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										value = Item.buyPrice(0, 0, 1, 0);
										return;
									}
									if (type == 3643)
									{
										name = "Large Gem";
										width = 20;
										height = 20;
										rare = 1;
										return;
									}
									if (type >= 3644 && type <= 3650)
									{
										name = "Gem Lock";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 440;
										placeStyle = type - 3644;
										width = 22;
										height = 22;
										value = Item.sellPrice(0, 0, 1, 0);
										return;
									}
									if (type >= 3651 && type <= 3662)
									{
										name = "Statue";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 105;
										width = 20;
										height = 20;
										value = 300;
										placeStyle = 51 + type - 3651;
										return;
									}
									if (type == 3663)
									{
										name = "logic";
										createTile = 419;
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										mech = true;
										placeStyle = 2;
										value = Item.buyPrice(0, 2, 0, 0);
										return;
									}
									if (type == 3664)
									{
										name = "Portal Gun Station";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 209;
										placeStyle = 3;
										width = 12;
										height = 12;
										rare = 3;
										value = Item.buyPrice(0, 10, 0, 0);
										return;
									}
									if (type >= 3665 && type <= 3706)
									{
										name = "Chest";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 441;
										placeStyle = type - 3665 + (type > 3666).ToInt() + (type > 3667).ToInt() * 3 + (type > 3683).ToInt() * 5 + (type > 3691).ToInt() + (type > 3692).ToInt() + (type > 3693).ToInt();
										width = 26;
										height = 22;
										value = 500;
										return;
									}
									if (type == 3707)
									{
										name = "logic";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 442;
										width = 12;
										height = 12;
										placeStyle = 0;
										mech = true;
										value = Item.buyPrice(0, 2, 0, 0);
										mech = true;
										return;
									}
									if (type >= 3708 && type <= 3720)
									{
										name = "Statue";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 105;
										width = 20;
										height = 20;
										value = 300;
										placeStyle = 63 + type - 3708;
										return;
									}
									if (type == 3721)
									{
										name = "Fishing Accessories";
										width = 26;
										height = 30;
										maxStack = 1;
										value = Item.sellPrice(0, 3, 0, 0);
										rare = 3;
										accessory = true;
										backSlot = 10;
										return;
									}
									if (type == 3722)
									{
										name = "logic";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 443;
										width = 20;
										height = 12;
										value = 10000;
										mech = true;
										return;
									}
									if (type >= 3723 && type <= 3724)
									{
										name = "Campfire";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 215;
										placeStyle = 6 + type - 3723;
										width = 12;
										height = 12;
										toolTip = "Life regen is increased when near a campfire";
										return;
									}
									if (type == 3725)
									{
										name = "logic";
										createTile = 445;
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										mech = true;
										value = Item.buyPrice(0, 0, 2, 0);
										return;
									}
									if (type >= 3726 && type <= 3729)
									{
										name = "logic";
										createTile = 423;
										width = 16;
										height = 16;
										rare = 1;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										placeStyle = type - 3726 + 3;
										mech = true;
										return;
									}
									if (type == 3730 || type == 3731)
									{
										name = "balloon";
										width = 20;
										height = 22;
										rare = 1;
										value = Item.buyPrice(0, 2, 0, 0);
										accessory = true;
										vanity = true;
										balloonSlot = (sbyte)(16 + type - 3730);
										return;
									}
									if (type == 3732)
									{
										name = "hat";
										width = 18;
										height = 18;
										headSlot = 195;
										value = Item.buyPrice(0, 1, 0, 0);
										vanity = true;
										return;
									}
									if (type == 3733)
									{
										name = "hat";
										width = 18;
										height = 18;
										headSlot = 196;
										value = Item.buyPrice(0, 3, 0, 0);
										vanity = true;
										return;
									}
									if (type == 3734)
									{
										name = "shirt";
										width = 28;
										height = 20;
										bodySlot = 195;
										value = Item.buyPrice(0, 3, 0, 0);
										vanity = true;
										return;
									}
									if (type == 3735)
									{
										name = "pants";
										width = 18;
										height = 14;
										legSlot = 138;
										value = Item.buyPrice(0, 3, 0, 0);
										vanity = true;
										return;
									}
									if (type >= 3736 && type <= 3738)
									{
										name = "block";
										createTile = 446 + (type - 3736);
										width = 16;
										height = 16;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										value = Item.buyPrice(0, 0, 1, 0);
										return;
									}
									if (type >= 3739 && type <= 3741)
									{
										name = "block";
										createTile = 449 + (type - 3739);
										width = 16;
										height = 16;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										value = Item.buyPrice(0, 0, 0, 50);
										tileBoost += 3;
										return;
									}
									if (type == 3742)
									{
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 452;
										width = 26;
										height = 20;
										value = Item.buyPrice(0, 5, 0, 0);
										rare = 1;
										return;
									}
									if (type >= 3743 && type <= 3745)
									{
										name = "obj 1x3";
										createTile = 453;
										placeStyle = type - 3743;
										if (3744 == type)
										{
											placeStyle = 0;
										}
										if (3745 == type)
										{
											placeStyle = 2;
										}
										if (3743 == type)
										{
											placeStyle = 4;
										}
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										width = 12;
										height = 30;
										value = Item.buyPrice(0, 0, 10, 0);
										return;
									}
									if (type == 3746)
									{
										name = "obj 3x3";
										createTile = 454;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										width = 12;
										height = 30;
										value = Item.buyPrice(0, 1, 0, 0);
										return;
									}
									if (type == 3747)
									{
										name = "obj 3x3";
										createTile = 455;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										width = 12;
										height = 30;
										value = Item.buyPrice(0, 20, 0, 0);
										rare = 9;
										return;
									}
									if (type == 3748)
									{
										name = "obj 2x3";
										createTile = 456;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										width = 12;
										height = 30;
										value = Item.buyPrice(0, 0, 20, 0);
										return;
									}
									if (type == 3749)
									{
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 457;
										width = 26;
										height = 20;
										value = Item.buyPrice(0, 0, 20, 0);
										rare = 1;
										return;
									}
									if (type == 3750)
									{
										name = "buff pot";

										useStyle = 2;
										useTurn = true;
										useAnimation = 17;
										useTime = 17;
										maxStack = 30;
										consumable = true;
										width = 14;
										height = 24;
										value = 1000;
										rare = 1;
										return;
									}
									if (type == 3751)
									{
										name = "wall";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 7;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createWall = 225;
										width = 12;
										height = 12;
										return;
									}
									if (type == 3752)
									{
										name = "wall";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 7;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createWall = 226;
										width = 12;
										height = 12;
										return;
									}
									if (type == 3753)
									{
										name = "wall";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 7;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createWall = 227;
										width = 12;
										height = 12;
										return;
									}
									if (type == 3754)
									{
										name = "block";
										createTile = 458;
										width = 16;
										height = 16;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										value = Item.buyPrice(0, 0, 0, 5);
										return;
									}
									if (type == 3755)
									{
										name = "block";
										createTile = 459;
										width = 16;
										height = 16;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										return;
									}
									if (type == 3756)
									{
										name = "block";
										createTile = 460;
										width = 16;
										height = 16;
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										return;
									}
									if (type == 3757)
									{
										name = "hat";
										width = 18;
										height = 18;
										headSlot = 197;
										value = Item.sellPrice(0, 0, 30, 0);
										vanity = true;
										rare = 9;
										return;
									}
									if (type == 3758)
									{
										name = "shirt";
										width = 28;
										height = 20;
										bodySlot = 196;
										value = Item.sellPrice(0, 0, 30, 0);
										vanity = true;
										rare = 9;
										return;
									}
									if (type == 3759)
									{
										name = "pants";
										width = 18;
										height = 14;
										legSlot = 139;
										value = Item.sellPrice(0, 0, 30, 0);
										vanity = true;
										rare = 9;
										return;
									}
									if (type >= 3760 && type <= 3762)
									{
										name = "wall";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 7;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createWall = 228 + (type - 3760);
										width = 12;
										height = 12;
										return;
									}
									if (type == 3763)
									{
										name = "hat";
										width = 18;
										height = 18;
										headSlot = 198;
										value = Item.sellPrice(0, 1, 0, 0);
										vanity = true;
										rare = 9;
										return;
									}
									if (type >= 3764 && type <= 3769)
									{
										SetDefaults(198, false);
										type = type;
										damage = 41;
										scale = 1.15f;
										autoReuse = true;
										useTurn = true;
										rare = 4;
										return;
									}
									if (type == 3770)
									{
										name = "pants";
										width = 18;
										height = 14;
										legSlot = 140;
										value = Item.sellPrice(0, 1, 0, 0);
										vanity = true;
										rare = 4;
										return;
									}
									if (type == 3771)
									{
										useStyle = 4;
										name = "Mount Item";
										channel = true;
										width = 34;
										height = 34;

										useAnimation = 20;
										useTime = 20;
										rare = 8;
										noMelee = true;
										mountType = 14;
										value = Item.sellPrice(0, 5, 0, 0);
										return;
									}
									if (type == 3772)
									{
										name = "melee claw";
										useStyle = 1;
										useTurn = true;
										autoReuse = true;
										useAnimation = 18;
										useTime = 18;
										width = 28;
										height = 28;
										damage = 14;
										knockBack = 4.5f;

										scale = 1f;
										melee = true;
										value = Item.sellPrice(0, 0, 10, 0);
										rare = 2;
										return;
									}
									if (type == 3773)
									{
										name = "hat";
										width = 18;
										height = 18;
										headSlot = 199;
										rare = 3;
										vanity = true;
										value = Item.sellPrice(0, 0, 50, 0);
										return;
									}
									if (type == 3774)
									{
										name = "shirt";
										width = 18;
										height = 18;
										bodySlot = 197;
										rare = 3;
										vanity = true;
										value = Item.sellPrice(0, 0, 50, 0);
										return;
									}
									if (type == 3775)
									{
										name = "pants";
										width = 18;
										height = 18;
										legSlot = 141;
										rare = 3;
										vanity = true;
										value = Item.sellPrice(0, 0, 50, 0);
										return;
									}
									if (type == 3776)
									{
										name = "hat";
										width = 18;
										height = 18;
										defense = 6;
										headSlot = 200;
										rare = 5;
										value = 250000;
										return;
									}
									if (type == 3777)
									{
										name = "shirt";
										width = 18;
										height = 18;
										defense = 12;
										bodySlot = 198;
										rare = 5;
										value = 200000;
										return;
									}
									if (type == 3778)
									{
										name = "pants";
										width = 18;
										height = 18;
										defense = 8;
										legSlot = 142;
										rare = 5;
										value = 150000;
										return;
									}
									if (type == 3779)
									{
										mana = 18;
										damage = 85;
										useStyle = 5;
										name = "spell";
										shootSpeed = 3f;
										shoot = 659;
										width = 26;
										height = 28;

										useAnimation = 30;
										useTime = 30;
										autoReuse = true;
										noMelee = true;
										knockBack = 5f;
										rare = 4;
										value = Item.sellPrice(0, 1, 0, 0);
										magic = true;
										glowMask = 218;
										return;
									}
									if (type == 3780)
									{
										name = "Monster Banner";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 91;
										placeStyle = 272;
										width = 10;
										height = 24;
										value = 1000;
										rare = 1;
										return;
									}
									if (type == 3781)
									{
										name = "accessory";
										width = 24;
										height = 28;
										rare = 3;
										value = 100000;
										accessory = true;
										return;
									}
									if (type == 3784)
									{
										name = "pants";
										width = 18;
										height = 18;
										legSlot = 143;
										rare = 3;
										vanity = true;
										value = Item.sellPrice(0, 0, 50, 0);
										return;
									}
									if (type == 3785)
									{
										name = "shirt";
										width = 18;
										height = 18;
										bodySlot = 199;
										rare = 3;
										vanity = true;
										value = Item.sellPrice(0, 0, 50, 0);
										return;
									}
									if (type == 3786)
									{
										name = "hat";
										width = 18;
										height = 18;
										headSlot = 201;
										rare = 3;
										vanity = true;
										value = Item.sellPrice(0, 0, 50, 0);
										return;
									}
									if (type == 3782)
									{
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 461;
										width = 24;
										height = 24;
										value = Item.sellPrice(0, 0, 1, 0);
										return;
									}
									if (type == 3787)
									{
										name = "magic glove";
										useStyle = 5;
										useAnimation = 12;
										useTime = 4;
										reuseDelay = useAnimation + 6;
										shootSpeed = 14f;
										knockBack = 6f;
										width = 16;
										height = 16;
										damage = 38;

										crit = 20;
										shoot = 660;
										mana = 14;
										rare = 4;
										value = 300000;
										noMelee = true;
										magic = true;
										autoReuse = true;
										return;
									}
									if (type == 3788)
									{
										name = "shotgun";
										knockBack = 6.5f;
										useStyle = 5;
										useAnimation = 45;
										useTime = 45;
										width = 50;
										height = 14;
										shoot = 10;
										useAmmo = AmmoID.Bullet;

										damage = 28;
										shootSpeed = 7f;
										noMelee = true;
										value = 250000;
										rare = 4;
										ranged = true;
										return;
									}
									if (type == 3783)
									{
										name = "material";
										width = 18;
										height = 18;
										maxStack = 999;
										value = 50000;
										rare = 5;
										return;
									}
									if (type >= 3789 && type <= 3793)
									{
										name = "Monster Banner";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 91;
										placeStyle = 273 + type - 3789;
										width = 10;
										height = 24;
										value = 1000;
										rare = 1;
										return;
									}
									if (type == 3794)
									{
										name = "material";
										width = 18;
										height = 18;
										maxStack = 999;
										value = Item.sellPrice(0, 0, 1, 0);
										rare = 1;
										return;
									}
									if (type == 3795)
									{
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 462;
										width = 26;
										height = 18;
										value = Item.sellPrice(0, 0, 50, 0);
										rare = 3;
										return;
									}
									if (type == 3796)
									{
										name = "Music Boxes";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										consumable = true;
										createTile = 139;
										placeStyle = 38;
										width = 24;
										height = 24;
										rare = 4;
										value = 100000;
										accessory = true;
										return;
									}
									if (type == 3797)
									{
										name = "Apprentice's Hat";
										width = 18;
										height = 18;
										headSlot = 203;
										rare = 8;
										defense = 7;
										value = Item.sellPrice(0, 3, 0, 0);
										return;
									}
									if (type == 3798)
									{
										name = "Apprentice's Robe";
										width = 18;
										height = 18;
										bodySlot = 200;
										rare = 8;
										defense = 15;
										value = Item.sellPrice(0, 3, 0, 0);
										return;
									}
									if (type == 3799)
									{
										name = "Apprentice's Trousers";
										width = 18;
										height = 18;
										legSlot = 144;
										rare = 8;
										defense = 10;
										value = Item.sellPrice(0, 3, 0, 0);
										return;
									}
									if (type == 3800)
									{
										name = "Squire's Great Helm";
										width = 18;
										height = 18;
										headSlot = 204;
										rare = 8;
										defense = 12;
										value = Item.sellPrice(0, 3, 0, 0);
										return;
									}
									if (type == 3801)
									{
										name = "Squire's Plating";
										width = 18;
										height = 18;
										bodySlot = 201;
										rare = 8;
										defense = 27;
										value = Item.sellPrice(0, 3, 0, 0);
										return;
									}
									if (type == 3802)
									{
										name = "Squire's Greaves";
										width = 18;
										height = 18;
										legSlot = 145;
										rare = 8;
										defense = 17;
										value = Item.sellPrice(0, 3, 0, 0);
										return;
									}
									if (type == 3803)
									{
										name = "Huntress's Wig";
										width = 18;
										height = 18;
										headSlot = 205;
										rare = 8;
										defense = 7;
										value = Item.sellPrice(0, 3, 0, 0);
										return;
									}
									if (type == 3804)
									{
										name = "Huntress's Jerkin";
										width = 18;
										height = 18;
										bodySlot = 202;
										rare = 8;
										defense = 17;
										value = Item.sellPrice(0, 3, 0, 0);
										return;
									}
									if (type == 3805)
									{
										name = "Huntress's Pants";
										width = 18;
										height = 18;
										legSlot = 146;
										rare = 8;
										defense = 12;
										value = Item.sellPrice(0, 3, 0, 0);
										return;
									}
									if (type == 3806)
									{
										name = "Monk's Brows";
										width = 18;
										height = 18;
										headSlot = 206;
										rare = 8;
										defense = 8;
										value = Item.sellPrice(0, 3, 0, 0);
										return;
									}
									if (type == 3807)
									{
										name = "Monk's Shirt";
										width = 18;
										height = 18;
										bodySlot = 203;
										rare = 8;
										defense = 22;
										value = Item.sellPrice(0, 3, 0, 0);
										return;
									}
									if (type == 3808)
									{
										name = "Monk's Pants";
										width = 18;
										height = 18;
										legSlot = 148;
										rare = 8;
										defense = 16;
										value = Item.sellPrice(0, 3, 0, 0);
										return;
									}
									if (type == 3809)
									{
										name = "Apprentice's Scarf";
										width = 22;
										height = 22;
										accessory = true;
										rare = 5;
										value = Item.sellPrice(0, 3, 0, 0);
										neckSlot = 9;
										return;
									}
									if (type == 3810)
									{
										name = "Squire's Shield";
										width = 22;
										height = 22;
										accessory = true;
										rare = 5;
										value = Item.sellPrice(0, 3, 0, 0);
										shieldSlot = 6;
										return;
									}
									if (type == 3811)
									{
										name = "Huntress's Buckler";
										width = 22;
										height = 22;
										accessory = true;
										rare = 5;
										value = Item.sellPrice(0, 3, 0, 0);
										handOnSlot = 19;
										return;
									}
									if (type == 3812)
									{
										name = "Monk's Belt";
										width = 22;
										height = 22;
										accessory = true;
										rare = 5;
										value = Item.sellPrice(0, 3, 0, 0);
										waistSlot = 12;
										return;
									}
									if (type == 3813)
									{
										rare = 3;
										name = "Defender's Forge";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 99;
										consumable = true;
										createTile = 463;
										width = 12;
										height = 12;
										value = 100000;
										glowMask = 244;
										return;
									}
									if (type == 3814)
									{
										rare = 1;
										name = "War Table";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 464;
										width = 12;
										height = 12;
										value = 100000;
										return;
									}
									if (type == 3815)
									{
										rare = 1;
										name = "War Table Banner";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 465;
										width = 12;
										height = 12;
										value = 100000;
										return;
									}
									if (type == 3816)
									{
										rare = 3;
										name = "tile";
										useStyle = 1;
										useTurn = true;
										useAnimation = 15;
										useTime = 10;
										autoReuse = true;
										maxStack = 999;
										consumable = true;
										createTile = 466;
										width = 12;
										height = 12;
										value = Item.buyPrice(0, 1, 0, 0);
										return;
									}
									if (type == 3817)
									{
										name = "our first non coin currency!";
										width = 12;
										height = 12;
										maxStack = 999;
										value = 0;
										rare = 3;
										return;
									}
									if (type == 3818 || type == 3819 || type == 3820 || type == 3824 || type == 3825 || type == 3826 || type == 3829 || type == 3830 || type == 3831 || type == 3832 || type == 3833 || type == 3834)
									{
										name = "tower popper";
										width = 18;
										height = 20;
										useStyle = 1;
										useAnimation = 30;
										useTime = 30;
										shootSpeed = 1f;
										noMelee = true;
										value = Item.sellPrice(0, 1, 0, 0);
										rare = 3;
										shoot = 663;
										summon = true;
										damage = 17;
										knockBack = 3f;
										mana = 5;
										DD2Summon = true;
										sentry = true;
										switch (type)
										{
											case 3819:
												shoot = 665;
												damage = 42;
												rare = 5;
												mana = 10;
												value = Item.sellPrice(0, 5, 0, 0);
												return;
											case 3820:
												shoot = 667;
												damage = 88;
												rare = 8;
												mana = 15;
												value = Item.sellPrice(0, 15, 0, 0);
												return;
											case 3821:
											case 3822:
											case 3823:
											case 3827:
											case 3828:
												break;
											case 3824:
												shoot = 677;
												damage = 27;
												knockBack = 4.5f;
												return;
											case 3825:
												shoot = 678;
												damage = 67;
												rare = 5;
												mana = 10;
												knockBack = 4.5f;
												value = Item.sellPrice(0, 5, 0, 0);
												return;
											case 3826:
												shoot = 679;
												damage = 140;
												rare = 8;
												mana = 15;
												knockBack = 4.5f;
												value = Item.sellPrice(0, 15, 0, 0);
												return;
											case 3829:
												shoot = 688;
												damage = 4;
												knockBack = 0f;
												return;
											case 3830:
												shoot = 689;
												damage = 11;
												rare = 5;
												mana = 10;
												knockBack = 0f;
												value = Item.sellPrice(0, 5, 0, 0);
												return;
											case 3831:
												shoot = 690;
												damage = 34;
												rare = 8;
												mana = 15;
												knockBack = 0f;
												value = Item.sellPrice(0, 15, 0, 0);
												return;
											case 3832:
												shoot = 691;
												damage = 24;
												knockBack = 0f;
												return;
											case 3833:
												shoot = 692;
												damage = 59;
												rare = 5;
												mana = 10;
												knockBack = 0f;
												value = Item.sellPrice(0, 5, 0, 0);
												return;
											case 3834:
												shoot = 693;
												damage = 126;
												rare = 8;
												mana = 15;
												knockBack = 0f;
												value = Item.sellPrice(0, 15, 0, 0);
												return;
											default:
												return;
										}
									}
									else
									{
										if (type == 3821)
										{
											name = "throwing glove";
											shootSpeed = 6.5f;
											shoot = 669;
											width = 20;
											height = 20;
											maxStack = 1;

											useStyle = 5;
											useAnimation = 40;
											useTime = 40;
											noUseGraphic = true;
											noMelee = true;
											value = Item.sellPrice(0, 0, 1, 0);
											damage = 20;
											knockBack = 7f;
											thrown = true;
											rare = 1;
											useAmmo = 353;
											return;
										}
										if (type == 3822)
										{
											name = "its an ammo technically!";
											width = 12;
											height = 12;
											maxStack = 999;
											value = 0;
											return;
										}
										if (type == 3823)
										{

											name = "Brand of the inferno";
											useStyle = 1;
											damage = 44;
											useAnimation = 25;
											useTime = 25;
											width = 34;
											height = 34;
											scale = 1.15f;
											knockBack = 6.5f;
											melee = true;
											rare = 5;
											value = Item.sellPrice(0, 1, 0, 0);
											autoReuse = true;
											flame = true;
											useTurn = true;
											return;
										}
										if (type == 3828)
										{
											rare = 3;
											name = "Eternia Crystal";
											maxStack = 99;
											consumable = true;
											width = 22;
											height = 18;
											value = Item.buyPrice(0, 0, 25, 0);
											return;
										}
										if (type == 3835)
										{
											name = "Sleepy Octopod";
											useStyle = 5;
											useAnimation = 30;
											useTime = 30;
											shootSpeed = 24f;
											knockBack = 7f;
											width = 16;
											height = 16;
											shoot = 697;
											rare = 5;
											value = Item.sellPrice(0, 1, 0, 0);
											noMelee = true;
											noUseGraphic = true;
											channel = true;
											autoReuse = true;
											melee = true;
											damage = 40;
											return;
										}
										if (type == 3836)
										{
											name = "Ghastly Glaive";
											useStyle = 5;
											useAnimation = 27;
											useTime = 27;
											shootSpeed = 42f;
											knockBack = 7f;
											width = 16;
											height = 16;
											shoot = 699;
											rare = 5;
											value = Item.sellPrice(0, 1, 0, 0);
											noMelee = true;
											noUseGraphic = true;
											channel = true;
											melee = true;
											damage = 45;
											return;
										}
										if (type >= 3837 && type <= 3846)
										{
											name = "Monster Banner";
											useStyle = 1;
											useTurn = true;
											useAnimation = 15;
											useTime = 10;
											autoReuse = true;
											maxStack = 99;
											consumable = true;
											createTile = 91;
											placeStyle = 278 + type - 3837;
											width = 10;
											height = 24;
											value = 1000;
											rare = 1;
											return;
										}
										if (type == 3855 || type == 3856 || type == 3857)
										{
											name = "pet item";
											damage = 0;
											useStyle = 1;
											width = 16;
											height = 30;

											useAnimation = 20;
											useTime = 20;
											rare = 3;
											noMelee = true;
											value = Item.sellPrice(0, 2, 0, 0);
											buffType = 200;
											shoot = 703;
											switch (type)
											{
												case 3856:
													buffType = 201;
													shoot = 702;
													return;
												case 3857:
													buffType = 202;
													shoot = 701;
													return;
												default:
													return;
											}
										}
										else
										{
											if (type == 3854)
											{
												name = "bow";
												useStyle = 5;
												useAnimation = 20;
												useTime = 20;
												shootSpeed = 20f;
												knockBack = 2f;
												width = 20;
												height = 12;
												damage = 24;

												shoot = 705;
												rare = 5;
												value = Item.sellPrice(0, 1, 0, 0);
												noMelee = true;
												noUseGraphic = true;
												ranged = true;
												channel = true;
												useAmmo = AmmoID.Arrow;
												autoReuse = true;
												return;
											}
											if (type == 3827)
											{
												rare = 8;
												name = "Flying Dragon";
												useStyle = 1;
												damage = 90;
												useAnimation = 25;
												useTime = 25;
												width = 30;
												height = 30;
												knockBack = 5.5f;
												melee = true;
												value = Item.sellPrice(0, 5, 0, 0);
												autoReuse = true;
												useTurn = false;
												glowMask = 227;
												shoot = 684;
												shootSpeed = 17f;
												return;
											}
											if (type == 3852)
											{
												name = "staff";
												useStyle = 5;
												useAnimation = 30;
												useTime = 3;
												shootSpeed = 11f;
												knockBack = 9f;
												width = 16;
												height = 16;
												damage = 24;
												shoot = 712;
												mana = 20;
												rare = 5;
												value = Item.sellPrice(0, 1, 0, 0);
												noMelee = true;
												magic = true;
												autoReuse = true;
												return;
											}
											if (type == 3858)
											{
												name = "Sky Dragon's Fury";
												useStyle = 5;
												useAnimation = 30;
												useTime = 30;
												shootSpeed = 24f;
												knockBack = 5f;
												width = 16;
												height = 16;
												shoot = 707;
												rare = 8;
												value = Item.sellPrice(0, 5, 0, 0);
												noMelee = true;
												noUseGraphic = true;
												channel = true;
												autoReuse = true;
												melee = true;
												damage = 70;
												return;
											}
											if (type == 3859)
											{
												autoReuse = true;
												useStyle = 5;
												useAnimation = 30;
												useTime = 30;
												width = 14;
												height = 32;
												shoot = 495;
												useAmmo = AmmoID.Arrow;

												damage = 55;
												shootSpeed = 11f;
												knockBack = 4.5f;
												rare = 8;
												crit = 3;
												noMelee = true;
												value = Item.sellPrice(0, 5, 0, 0);
												ranged = true;
												glowMask = 234;
												return;
											}
											if (type == 3860 || type == 3862 || type == 3861)
											{
												name = "Treasure Bag";
												maxStack = 999;
												consumable = true;
												width = 24;
												height = 24;
												rare = 1;
												if (type == 3860)
												{
													rare = 8;
												}
												if (type == 3862)
												{
													rare = 3;
												}
												if (type == 3861)
												{
													rare = 5;
												}
												expert = true;
												return;
											}
											if (type >= 3863 && type <= 3865)
											{
												name = "Mask";
												width = 28;
												height = 20;
												rare = 1;
												vanity = true;
												switch (type)
												{
													case 3863:
														headSlot = 207;
														return;
													case 3864:
														headSlot = 208;
														return;
													case 3865:
														headSlot = 209;
														return;
													default:
														return;
												}
											}
											else
											{
												if (type == 3866 || type == 3867 || type == 3868)
												{
													name = "Trophy";
													useStyle = 1;
													useTurn = true;
													useAnimation = 15;
													useTime = 10;
													autoReuse = true;
													maxStack = 99;
													consumable = true;
													createTile = 240;
													width = 30;
													height = 30;
													value = Item.sellPrice(0, 1, 0, 0);
													placeStyle = 60;
													if (type == 3866)
													{
														placeStyle = 61;
													}
													if (type == 3868)
													{
														placeStyle = 62;
													}
													rare = 1;
													return;
												}
												if (type == 3869)
												{
													name = "Music Boxes";
													useStyle = 1;
													useTurn = true;
													useAnimation = 15;
													useTime = 10;
													autoReuse = true;
													consumable = true;
													createTile = 139;
													placeStyle = 39;
													width = 24;
													height = 24;
													rare = 4;
													value = 100000;
													accessory = true;
													return;
												}
												if (type == 3870)
												{
													name = "staff";
													useStyle = 5;
													useAnimation = 20;
													useTime = 20;
													reuseDelay = 10;
													shootSpeed = 14f;
													knockBack = 7f;
													width = 16;
													height = 16;
													damage = 65;
													shoot = 711;
													mana = 14;
													rare = 8;
													value = Item.sellPrice(0, 5, 0, 0);
													noMelee = true;
													magic = true;
													autoReuse = true;
													glowMask = 238;
													return;
												}
												if (type == 3871)
												{
													name = "head";
													width = 18;
													height = 18;
													rare = 8;
													defense = 14;
													value = Item.sellPrice(0, 3, 0, 0);
													headSlot = 210;
													return;
												}
												if (type == 3872)
												{
													name = "shirt";
													width = 18;
													height = 18;
													rare = 8;
													defense = 30;
													value = Item.sellPrice(0, 3, 0, 0);
													bodySlot = 204;
													return;
												}
												if (type == 3873)
												{
													name = "pants";
													width = 18;
													height = 18;
													rare = 8;
													defense = 20;
													value = Item.sellPrice(0, 3, 0, 0);
													legSlot = 152;
													return;
												}
												if (type == 3874)
												{
													name = "head";
													width = 18;
													height = 18;
													rare = 8;
													defense = 7;
													value = Item.sellPrice(0, 3, 0, 0);
													headSlot = 211;
													return;
												}
												if (type == 3875)
												{
													name = "shirt";
													width = 18;
													height = 18;
													rare = 8;
													defense = 21;
													value = Item.sellPrice(0, 3, 0, 0);
													bodySlot = 205;
													backSlot = 11;
													return;
												}
												if (type == 3876)
												{
													name = "pants";
													width = 18;
													height = 18;
													rare = 8;
													defense = 14;
													value = Item.sellPrice(0, 3, 0, 0);
													legSlot = 153;
													return;
												}
												if (type == 3877)
												{
													name = "head";
													width = 18;
													height = 18;
													rare = 8;
													defense = 8;
													value = Item.sellPrice(0, 3, 0, 0);
													headSlot = 212;
													return;
												}
												if (type == 3878)
												{
													name = "shirt";
													width = 18;
													height = 18;
													rare = 8;
													defense = 24;
													value = Item.sellPrice(0, 3, 0, 0);
													bodySlot = 206;
													backSlot = 12;
													return;
												}
												if (type == 3879)
												{
													name = "pants";
													width = 18;
													height = 18;
													rare = 8;
													defense = 16;
													value = Item.sellPrice(0, 3, 0, 0);
													legSlot = 154;
													return;
												}
												if (type == 3880)
												{
													name = "head";
													width = 18;
													height = 18;
													rare = 8;
													defense = 10;
													value = Item.sellPrice(0, 3, 0, 0);
													headSlot = 213;
													return;
												}
												if (type == 3881)
												{
													name = "shirt";
													width = 18;
													height = 18;
													rare = 8;
													defense = 26;
													value = Item.sellPrice(0, 3, 0, 0);
													bodySlot = 207;
													backSlot = 13;
													return;
												}
												if (type == 3882)
												{
													name = "pants";
													width = 18;
													height = 18;
													rare = 8;
													defense = 18;
													value = Item.sellPrice(0, 3, 0, 0);
													legSlot = 156;
													return;
												}
												if (type == 3883)
												{
													name = "Wings";
													width = 22;
													height = 20;
													accessory = true;
													value = Item.sellPrice(0, 5, 0, 0);
													rare = 8;
													wingSlot = 37;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		public static void StartCachingType(int t)
		{
			if (Item.itemCaches[t] == -1)
			{
				Item.itemCaches[t] = 0;
			}
		}

		public override string ToString()
		{
			return string.Format("{{Name: \"{0}\" NetID: {1} Stack: {2}", name, netID, stack);
		}

		public void TurnToAir()
		{
			this.type = 0;
			this.stack = 0;
			this.netID = 0;
			this.name = "";
		}

		public void UpdateItem(int i)
		{
			if (Main.itemLockoutTime[i] > 0)
			{
				Main.itemLockoutTime[i]--;
				return;
			}
			if (active)
			{
				if (instanced)
				{
					if (Main.netMode == 2)
					{
						active = false;
						return;
					}
					keepTime = 600;
				}
				float num = 0.1f;
				float num2 = 7f;
				if (honeyWet)
				{
					num = 0.05f;
					num2 = 3f;
				}
				else if (wet)
				{
					num2 = 5f;
					num = 0.08f;
				}
				if (ownTime > 0)
				{
					ownTime--;
				}
				else
				{
					ownIgnore = -1;
				}
				if (keepTime > 0)
				{
					keepTime--;
				}
				if (beingGrabbed)
				{
					isBeingGrabbed = true;
				}
				else
				{
					isBeingGrabbed = false;
				}
				Vector2 value = velocity * 0.5f;
				if (!beingGrabbed)
				{
					bool flag = true;
					switch (type)
					{
						case 71:
						case 72:
						case 73:
						case 74:
							flag = false;
							break;
					}
					if (ItemID.Sets.NebulaPickup[type])
					{
						flag = false;
					}
					if (owner == Main.myPlayer && flag && (createTile >= 0 || createWall > 0 || (ammo > 0 && !notAmmo) || (consumable || (type >= 205 && type <= 207)) || type == 1128 || type == 530 || dye > 0 || paint > 0 || material) && stack < maxStack)
					{
						for (int j = i + 1; j < 400; j++)
						{
							if (Main.item[j].active && Main.item[j].type == type && Main.item[j].stack > 0 && Main.item[j].owner == owner)
							{
								float num5 = Math.Abs(position.X + width / 2 - (Main.item[j].position.X + Main.item[j].width / 2)) + Math.Abs(position.Y + height / 2 - (Main.item[j].position.Y + Main.item[j].height / 2));
								if (num5 < 30f)
								{
									position = (position + Main.item[j].position) / 2f;
									velocity = (velocity + Main.item[j].velocity) / 2f;
									int num6 = Main.item[j].stack;
									if (num6 > maxStack - stack)
									{
										num6 = maxStack - stack;
									}
									Main.item[j].stack -= num6;
									stack += num6;
									if (Main.item[j].stack <= 0)
									{
										Main.item[j].SetDefaults(0, false);
										Main.item[j].active = false;
									}
									if (Main.netMode != 0 && owner == Main.myPlayer)
									{
										NetMessage.SendData(21, -1, -1, "", i, 0f, 0f, 0f, 0, 0, 0);
										NetMessage.SendData(21, -1, -1, "", j, 0f, 0f, 0f, 0, 0, 0);
									}
								}
							}
						}
					}
					if (ItemID.Sets.ItemNoGravity[type])
					{
						velocity.X = velocity.X * 0.95f;
						if (velocity.X < 0.1 && velocity.X > -0.1)
						{
							velocity.X = 0f;
						}
						velocity.Y = velocity.Y * 0.95f;
						if (velocity.Y < 0.1 && velocity.Y > -0.1)
						{
							velocity.Y = 0f;
						}
					}
					else
					{
						velocity.Y = velocity.Y + num;
						if (velocity.Y > num2)
						{
							velocity.Y = num2;
						}
						velocity.X = velocity.X * 0.95f;
						if (velocity.X < 0.1 && velocity.X > -0.1)
						{
							velocity.X = 0f;
						}
					}
					bool flag2 = Collision.LavaCollision(position, width, height);
					if (flag2)
					{
						lavaWet = true;
					}
					bool flag3 = Collision.WetCollision(position, width, height);
					if (Collision.honey)
					{
						honeyWet = true;
					}
					if (flag3)
					{
						if (!wet)
						{
							wet = true;
						}
					}
					else if (wet)
					{
						wet = false;
						byte arg_CCD_0 = wetCount;
					}
					if (!wet)
					{
						lavaWet = false;
						honeyWet = false;
					}
					if (wetCount > 0)
					{
						wetCount -= 1;
					}
					if (wet)
					{
						Vector2 velocity = this.velocity;
						this.velocity = Collision.TileCollision(position, velocity, width, height, false, false, 1);
						if (velocity.X != this.velocity.X)
						{
							value.X = this.velocity.X;
						}
						if (velocity.Y != this.velocity.Y)
						{
							value.Y = this.velocity.Y;
						}
					}
					else
					{
						velocity = Collision.TileCollision(position, velocity, width, height, false, false, 1);
					}
					Vector4 vector = Collision.SlopeCollision(position, velocity, width, height, num, false);
					position.X = vector.X;
					position.Y = vector.Y;
					velocity.X = vector.Z;
					velocity.Y = vector.W;
					Collision.StepConveyorBelt(this, 1f);
					if (lavaWet)
					{
						if (type == 267)
						{
							if (Main.netMode != 1)
							{
								active = false;
								type = 0;
								name = "";
								stack = 0;
								for (int num17 = 0; num17 < 200; num17++)
								{
									if (Main.npc[num17].active && Main.npc[num17].type == 22)
									{
										if (Main.netMode == 2)
										{
											NetMessage.SendData(28, -1, -1, "", num17, 9999f, 10f, -Main.npc[num17].direction, 0, 0, 0);
										}
										Main.npc[num17].StrikeNPCNoInteraction(9999, 10f, -Main.npc[num17].direction, false, false, false);
										NPC.SpawnWOF(position);
									}
								}
								NetMessage.SendData(21, -1, -1, "", i, 0f, 0f, 0f, 0, 0, 0);
							}
						}
						else if (owner == Main.myPlayer && type != 312 && type != 318 && type != 173 && type != 174 && type != 175 && type != 2701 && rare == 0)
						{
							active = false;
							type = 0;
							name = "";
							stack = 0;
							if (Main.netMode != 0)
							{
								NetMessage.SendData(21, -1, -1, "", i, 0f, 0f, 0f, 0, 0, 0);
							}
						}
					}
					if (type == 75 && Main.dayTime)
					{
						active = false;
						type = 0;
						stack = 0;
						if (Main.netMode == 2)
						{
							NetMessage.SendData(21, -1, -1, "", i, 0f, 0f, 0f, 0, 0, 0);
						}
					}
					if (type == 3822 && !DD2Event.Ongoing)
					{
						int num31 = Main.rand.Next(18, 24);
						active = false;
						type = 0;
						stack = 0;
						if (Main.netMode == 2)
						{
							NetMessage.SendData(21, -1, -1, "", i, 0f, 0f, 0f, 0, 0, 0);
						}
					}
				}
				else
				{
					beingGrabbed = false;
				}
				if (spawnTime < 2147483646)
				{
					if (type == 58 || type == 184 || type == 1867 || type == 1868 || type == 1734 || type == 1735)
					{
						spawnTime += 4;
					}
					spawnTime++;
				}
				if (Main.netMode == 2 && owner != Main.myPlayer)
				{
					release++;
					if (release >= 300)
					{
						release = 0;
						NetMessage.SendData(39, owner, -1, "", i, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				if (wet)
				{
					position += value;
				}
				else
				{
					position += velocity;
				}
				if (noGrabDelay > 0)
				{
					noGrabDelay--;
				}
			}
		}

		public static string VersionName(string oldName, int release)
		{
			string result = oldName;
			if (release <= 4)
			{
				if (oldName == "Cobalt Helmet")
				{
					result = "Jungle Hat";
				}
				else if (oldName == "Cobalt Breastplate")
				{
					result = "Jungle Shirt";
				}
				else if (oldName == "Cobalt Greaves")
				{
					result = "Jungle Pants";
				}
			}
			if (release <= 13 && oldName == "Jungle Rose")
			{
				result = "Jungle Spores";
			}
			if (release <= 20)
			{
				if (oldName == "Gills potion")
				{
					result = "Gills Potion";
				}
				else if (oldName == "Thorn Chakrum")
				{
					result = "Thorn Chakram";
				}
				else if (oldName == "Ball 'O Hurt")
				{
					result = "Ball O' Hurt";
				}
			}
			if (release <= 41 && oldName == "Iron Chain")
			{
				result = "Chain";
			}
			if (release <= 44 && oldName == "Orb of Light")
			{
				result = "Shadow Orb";
			}
			if (release <= 46)
			{
				if (oldName == "Black Dye")
				{
					result = "Black Thread";
				}
				if (oldName == "Green Dye")
				{
					result = "Green Thread";
				}
			}
			return result;
		}
	}
}