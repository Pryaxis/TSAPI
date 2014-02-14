using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Terraria
{
	public class Player
	{
		public const int maxBuffs = 22;
		public int beetleOrbs;
		public float beetleCounter;
		public int beetleCountdown;
		public bool beetleDefense;
		public bool beetleOffense;
		public bool beetleBuff;
		public bool manaMagnet;
		public int netManaTime;
		public int netLifeTime;
		public bool netMana;
		public bool netLife;
		public Vector2[] beetlePos = new Vector2[3];
		public Vector2[] beetleVel = new Vector2[3];
		public int beetleFrame;
		public int beetleFrameCounter;
		public static int manaSickTime = 300;
		public static int manaSickTimeMax = 600;
		public static float manaSickLessDmg = 0.25f;
		public float manaSickReduction;
		public bool manaSick;
		public bool stairFall;
		public int loadStatus;
		public Vector2[] itemFlamePos = new Vector2[7];
		public int itemFlameCount;
		public bool outOfRange;
		public float lifeSteal = 99999f;
		public float ghostDmg;
		public bool teleporting;
		public float teleportTime;
		public int teleportStyle;
		public bool sloping;
		public bool chilled;
		public bool frozen;
		public bool ichor;
		public int ropeCount;
		public int manaRegenBonus;
		public int manaRegenDelayBonus;
		public int dash;
		public int dashTime;
		public int dashDelay;
		public float accRunSpeed;
		public int gem = -1;
		public int gemCount;
		public byte meleeEnchant;
		public byte pulleyDir;
		public bool pulley;
		public int pulleyFrame;
		public float pulleyFrameCounter;
		public bool blackBelt;
		public bool sliding;
		public int slideDir;
		public int launcherWait;
		public bool iceSkate;
		public bool carpet;
		public int spikedBoots;
		public int carpetFrame = -1;
		public float carpetFrameCounter;
		public bool canCarpet;
		public int carpetTime;
		public int miscCounter;
		public bool sandStorm;
		public bool crimsonRegen;
		public bool ghostHeal;
		public bool ghostHurt;
		public bool sticky;
		public bool slippy;
		public bool slippy2;
		public bool powerrun;
		public bool flapSound;
		public bool iceBarrier;
		public bool panic;
		public byte iceBarrierFrame;
		public byte iceBarrierFrameCounter;
		public bool shadowDodge;
		public float shadowDodgeCount;
		public bool palladiumRegen;
		public bool onHitDodge;
		public bool onHitRegen;
		public bool onHitPetal;
		public int petalTimer;
		public int shadowDodgeTimer;
		public int maxMinions = 1;
		public int numMinions;
		public bool pygmy;
		public bool raven;
		public bool slime;
		public float wingTime;
		public int wings;
		public int wingsLogic;
		public int wingTimeMax;
		public int wingFrame;
		public int wingFrameCounter;
		public bool male = true;
		public bool ghost;
		public int ghostFrame;
		public int ghostFrameCounter;
		public int miscTimer;
		public bool pvpDeath;
		public bool zoneDungeon;
		public bool zoneEvil;
		public bool zoneHoly;
		public bool zoneMeteor;
		public bool zoneJungle;
		public bool zoneSnow;
		public bool zoneBlood;
		public bool zoneCandle;
		public bool boneArmor;
		public bool frostArmor;
		public bool honey;
		public bool crystalLeaf;
		public bool paladinBuff;
		public bool paladinGive;
		public float townNPCs;
		public Vector2 position;
		public Vector2 oldPosition;
		public Vector2 velocity;
		public Vector2 oldVelocity;
		public double headFrameCounter;
		public double bodyFrameCounter;
		public double legFrameCounter;
		public int netSkip;
		public int oldSelectItem;
		public bool immune;
		public int immuneTime;
		public int immuneAlphaDirection;
		public int immuneAlpha;
		public int team;
		public bool hbLocked;
		public static int nameLen = 20;
		private float maxRegenDelay;
		public string chatText = "";
		public int sign = -1;
		public bool editedChestName;
		public int chatShowTime;
		public int reuseDelay;
		public int aggro;
		public float activeNPCs;
		public bool mouseInterface;
		public bool lastMouseInterface;
		public int noThrow;
		public int changeItem = -1;
		public int selectedItem;
		public Item[] armor = new Item[16];
		public Item[] dye = new Item[8];
		public int itemAnimation;
		public int itemAnimationMax;
		public int itemTime;
		public int toolTime;
		public float itemRotation;
		public int itemWidth;
		public int itemHeight;
		public Vector2 itemLocation;
		public bool poundRelease;
		public float ghostFade;
		public float ghostDir = 1f;
		public int[] buffType = new int[22];
		public int[] buffTime = new int[22];
		public bool[] buffImmune = new bool[104];
		public int heldProj = -1;
		public int breathCD;
		public int breathMax = 200;
		public int breath = 200;
		public int lavaCD;
		public int lavaMax;
		public int lavaTime;
		public bool socialShadow;
		public bool socialGhost;
		public bool armorSteath;
		public int stealthTimer;
		public float stealth = 1f;
		public string setBonus = "";
		public Item[] inventory = new Item[59];
		public Chest bank = new Chest(true);
		public Chest bank2 = new Chest(true);
		public float headRotation;
		public float bodyRotation;
		public float legRotation;
		public Vector2 headPosition;
		public Vector2 bodyPosition;
		public Vector2 legPosition;
		public Vector2 headVelocity;
		public Vector2 bodyVelocity;
		public Vector2 legVelocity;
		public int nonTorch = -1;
		public float gfxOffY;
		public float stepSpeed = 1f;
		public static bool deadForGood = false;
		public bool dead;
		public int respawnTimer;
		public string name = "";
		public int attackCD;
		public int potionDelay;
		public byte difficulty;
		public bool wet;
		public byte wetCount;
		public bool lavaWet;
		public bool honeyWet;
		public int jump;
		public int head = -1;
		public int body = -1;
		public int legs = -1;
		public sbyte handon = -1;
		public sbyte handoff = -1;
		public sbyte back = -1;
		public sbyte front = -1;
		public sbyte shoe = -1;
		public sbyte waist = -1;
		public sbyte shield = -1;
		public sbyte neck = -1;
		public sbyte face = -1;
		public sbyte balloon = -1;
		public BitsByte hideVisual = 0;
		public Rectangle headFrame;
		public Rectangle bodyFrame;
		public Rectangle legFrame;
		public Rectangle hairFrame;
		public bool controlLeft;
		public bool controlRight;
		public bool controlUp;
		public bool controlDown;
		public bool controlJump;
		public bool controlUseItem;
		public bool controlUseTile;
		public bool controlThrow;
		public bool controlInv;
		public bool controlHook;
		public bool controlTorch;
		public bool controlMap;
		public bool releaseJump;
		public bool releaseUp;
		public bool releaseUseItem;
		public bool releaseUseTile;
		public bool releaseInventory;
		public bool releaseHook;
		public bool releaseThrow;
		public bool releaseQuickMana;
		public bool releaseQuickHeal;
		public bool releaseLeft;
		public bool releaseRight;
		public bool mapZoomIn;
		public bool mapZoomOut;
		public bool mapAlphaUp;
		public bool mapAlphaDown;
		public bool mapFullScreen;
		public bool mapStyle;
		public bool releaseMapFullscreen;
		public bool releaseMapStyle;
		public int leftTimer;
		public int rightTimer;
		public bool delayUseItem;
		public bool active;
		public int width = 20;
		public int height = 42;
		public int direction = 1;
		public bool showItemIcon;
		public bool showItemIconR;
		public int showItemIcon2;
		public string showItemIconText = "";
		public int whoAmi;
		public int runSoundDelay;
		public float shadow;
		public float manaCost = 1f;
		public bool fireWalk;
		public Vector2[] shadowPos = new Vector2[3];
		public int shadowCount;
		public bool channel;
		public int step = -1;
		public int statDefense;
		public int statAttack;
		public int statLifeMax = 100;
		public int statLife = 100;
		public int statMana;
		public int statManaMax;
		public int statManaMax2;
		public int lifeRegen;
		public int lifeRegenCount;
		public int lifeRegenTime;
		public int manaRegen;
		public int manaRegenCount;
		public int manaRegenDelay;
		public bool manaRegenBuff;
		public bool noKnockback;
		public bool spaceGun;
		public float gravDir = 1f;
		public bool ammoCost80;
		public bool ammoCost75;
		public int stickyBreak;
		public bool magicQuiver;
		public bool magmaStone;
		public bool lavaRose;
		public bool ammoBox;
		public bool chaosState;
		public bool lightOrb;
		public bool blueFairy;
		public bool redFairy;
		public bool greenFairy;
		public bool bunny;
		public bool turtle;
		public bool eater;
		public bool penguin;
		public bool puppy;
		public bool grinch;
		public bool wearsRobe;
		public int mount;
		public int mountFrame;
		public float mountFrameCounter;
		public int mountFlyTime;
		public bool blackCat;
		public bool spider;
		public bool squashling;
		public bool magicCuffs;
		public bool coldDash;
		public bool eyeSpring;
		public bool snowman;
		public bool scope;
		public bool dino;
		public bool skeletron;
		public bool hornet;
		public bool tiki;
		public bool parrot;
		public bool truffle;
		public bool sapling;
		public bool cSapling;
		public bool wisp;
		public bool lizard;
		public bool archery;
		public bool poisoned;
		public bool venom;
		public bool blind;
		public bool blackout;
		public bool frostBurn;
		public bool onFrostBurn;
		public bool burned;
		public bool suffocating;
		public byte suffocateDelay;
		public bool dripping;
		public bool onFire;
		public bool onFire2;
		public bool noItems;
		public bool wereWolf;
		public bool wolfAcc;
		public bool rulerAcc;
		public bool bleed;
		public bool confused;
		public bool accMerman;
		public bool merman;
		public bool brokenArmor;
		public bool silence;
		public bool slow;
		public bool gross;
		public bool tongued;
		public bool kbGlove;
		public bool starCloak;
		public bool longInvince;
		public bool pStone;
		public bool manaFlower;
		public int meleeCrit = 4;
		public int rangedCrit = 4;
		public int magicCrit = 4;
		public float meleeDamage = 1f;
		public float rangedDamage = 1f;
		public float bulletDamage = 1f;
		public float arrowDamage = 1f;
		public float rocketDamage = 1f;
		public float magicDamage = 1f;
		public float minionDamage = 1f;
		public float minionKB;
		public float meleeSpeed = 1f;
		public float moveSpeed = 1f;
		public float pickSpeed = 1f;
		public float wallSpeed = 1f;
		public float tileSpeed = 1f;
		public bool autoPaint;
		public int SpawnX = -1;
		public int SpawnY = -1;
		public int[] spX = new int[200];
		public int[] spY = new int[200];
		public string[] spN = new string[200];
		public int[] spI = new int[200];
		public static int tileRangeX = 5;
		public static int tileRangeY = 4;
		private static int tileTargetX;
		private static int tileTargetY;
		private static int jumpHeight = 15;
		private static float jumpSpeed = 5.01f;
		public bool adjWater;
		public bool adjHoney;
		public bool adjLava;
		public bool oldAdjWater;
		public bool oldAdjHoney;
		public bool oldAdjLava;
		public bool[] adjTile = new bool[314];
		public bool[] oldAdjTile = new bool[314];
		private static int defaultItemGrabRange = 38;
		private static float itemGrabSpeed = 0.45f;
		private static float itemGrabSpeedMax = 4f;
		public byte hairDye;
		public Color hairDyeColor = new Color(0, 0, 0, 0);
		public float hairDyeVar;
		public Color hairColor = new Color(215, 90, 55);
		public Color skinColor = new Color(255, 125, 90);
		public Color eyeColor = new Color(105, 90, 75);
		public Color shirtColor = new Color(175, 165, 140);
		public Color underShirtColor = new Color(160, 180, 215);
		public Color pantsColor = new Color(255, 230, 175);
		public Color shoeColor = new Color(160, 105, 60);
		public int hair;
		public bool hostile;
		public int accCompass;
		public int accWatch;
		public int accDepthMeter;
		public bool discount;
		public bool coins;
		public bool accDivingHelm;
		public bool accFlipper;
		public bool doubleJump;
		public bool jumpAgain;
		public bool dJumpEffect;
		public bool doubleJump2;
		public bool jumpAgain2;
		public bool dJumpEffect2;
		public bool doubleJump3;
		public bool jumpAgain3;
		public bool dJumpEffect3;
		public bool doubleJump4;
		public bool jumpAgain4;
		public bool dJumpEffect4;
		public bool spawnMax;
		public int blockRange;
		public int[] grappling = new int[20];
		public int grapCount;
		public int rocketTime;
		public int rocketTimeMax = 7;
		public int rocketDelay;
		public int rocketDelay2;
		public bool rocketRelease;
		public bool rocketFrame;
		public int rocketBoots;
		public bool canRocket;
		public bool jumpBoost;
		public bool noFallDmg;
		public int swimTime;
		public bool killGuide;
		public bool killClothier;
		public bool lavaImmune;
		public bool gills;
		public bool slowFall;
		public bool findTreasure;
		public bool invis;
		public bool detectCreature;
		public bool nightVision;
		public bool enemySpawns;
		public bool thorns;
		public bool turtleArmor;
		public bool turtleThorns;
		public bool waterWalk;
		public bool waterWalk2;
		public bool gravControl;
		public bool gravControl2;
		public bool bee;
		public int chest = -1;
		public int chestX;
		public int chestY;
		public int talkNPC = -1;
		public int fallStart;
		public int slowCount;
		public int potionDelayTime = Item.potionDelay;
		public static byte FindClosest(Vector2 Position, int Width, int Height)
		{
			byte result = 0;
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active)
				{
					result = (byte)i;
					break;
				}
			}
			float num = -1f;
			for (int j = 0; j < 255; j++)
			{
				if (Main.player[j].active && !Main.player[j].dead)
				{
					float num2 = Math.Abs(Main.player[j].position.X + (float)(Main.player[j].width / 2) - (Position.X + (float)(Width / 2))) + Math.Abs(Main.player[j].position.Y + (float)(Main.player[j].height / 2) - (Position.Y + (float)(Height / 2)));
					if (num == -1f || num2 < num)
					{
						num = num2;
						result = (byte)j;
					}
				}
			}
			return result;
		}
		public void checkArmor()
		{
		}
		public void dropItemCheck()
		{
			if (!Main.playerInventory)
			{
				this.noThrow = 0;
			}
			if (this.noThrow > 0)
			{
				this.noThrow--;
			}
			if (!Main.craftGuide && Main.guideItem.type > 0)
			{
				int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Main.guideItem.type, 1, false, 0, false);
				Main.guideItem.position = Main.item[num].position;
				Main.item[num] = Main.guideItem;
				Main.guideItem = new Item();
				if (Main.netMode == 0)
				{
					Main.item[num].noGrabDelay = 100;
				}
				Main.item[num].velocity.Y = -2f;
				Main.item[num].velocity.X = (float)(4 * this.direction) + this.velocity.X;
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0);
				}
			}
			if (!Main.reforge && Main.reforgeItem.type > 0)
			{
				int num2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Main.reforgeItem.type, 1, false, 0, false);
				Main.reforgeItem.position = Main.item[num2].position;
				Main.item[num2] = Main.reforgeItem;
				Main.reforgeItem = new Item();
				if (Main.netMode == 0)
				{
					Main.item[num2].noGrabDelay = 100;
				}
				Main.item[num2].velocity.Y = -2f;
				Main.item[num2].velocity.X = (float)(4 * this.direction) + this.velocity.X;
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", num2, 0f, 0f, 0f, 0);
				}
			}
			if (Main.myPlayer == this.whoAmi)
			{
				this.inventory[58] = Main.mouseItem.Clone();
			}
			bool flag = true;
			if (Main.mouseItem.type > 0 && Main.mouseItem.stack > 0 && !Main.gamePaused)
			{
				Player.tileTargetX = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
				Player.tileTargetY = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
				if (this.gravDir == -1f)
				{
					Player.tileTargetY = (int)((Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16f);
				}
				if (this.selectedItem != 58)
				{
					this.oldSelectItem = this.selectedItem;
				}
				this.selectedItem = 58;
				flag = false;
			}
			if (flag && this.selectedItem == 58)
			{
				this.selectedItem = this.oldSelectItem;
			}
			if (((this.controlThrow && this.releaseThrow && this.inventory[this.selectedItem].type > 0 && !Main.chatMode) || (((Main.mouseRight && !this.mouseInterface && Main.mouseRightRelease) || !Main.playerInventory) && Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)) && this.noThrow <= 0)
			{
				Item item = new Item();
				bool flag2 = false;
				if (((Main.mouseRight && !this.mouseInterface && Main.mouseRightRelease) || !Main.playerInventory) && Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)
				{
					item = this.inventory[this.selectedItem];
					this.inventory[this.selectedItem] = Main.mouseItem;
					this.delayUseItem = true;
					this.controlUseItem = false;
					flag2 = true;
				}
				int num3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[this.selectedItem].type, 1, false, 0, false);
				if (!flag2 && this.inventory[this.selectedItem].type == 8 && this.inventory[this.selectedItem].stack > 1)
				{
					this.inventory[this.selectedItem].stack--;
				}
				else
				{
					this.inventory[this.selectedItem].position = Main.item[num3].position;
					Main.item[num3] = this.inventory[this.selectedItem];
					this.inventory[this.selectedItem] = new Item();
				}
				if (Main.netMode == 0)
				{
					Main.item[num3].noGrabDelay = 100;
				}
				Main.item[num3].velocity.Y = -2f;
				Main.item[num3].velocity.X = (float)(4 * this.direction) + this.velocity.X;
				if (((Main.mouseRight && !this.mouseInterface) || !Main.playerInventory) && Main.mouseItem.type > 0)
				{
					this.inventory[this.selectedItem] = item;
					Main.mouseItem = new Item();
				}
				else
				{
					this.itemAnimation = 10;
					this.itemAnimationMax = 10;
				}
				Recipe.FindRecipes();
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", num3, 0f, 0f, 0f, 0);
				}
			}
		}
		public void AddBuff(int type, int time, bool quiet = true)
		{
			if (this.buffImmune[type])
			{
				return;
			}
			if (!quiet && Main.netMode == 1)
			{
				bool flag = true;
				for (int i = 0; i < 22; i++)
				{
					if (this.buffType[i] == type)
					{
						flag = false;
					}
				}
				if (flag)
				{
					NetMessage.SendData(55, -1, -1, "", this.whoAmi, (float)type, (float)time, 0f, 0);
				}
			}
			int num = -1;
			for (int j = 0; j < 22; j++)
			{
				if (this.buffType[j] == type)
				{
					if (type == 94)
					{
						this.buffTime[j] += time;
						if (this.buffTime[j] > Player.manaSickTimeMax)
						{
							this.buffTime[j] = Player.manaSickTimeMax;
							return;
						}
					}
					else if (this.buffTime[j] < time)
					{
						this.buffTime[j] = time;
					}
					return;
				}
			}
			if (Main.vanityPet[type] || Main.lightPet[type])
			{
				for (int k = 0; k < 22; k++)
				{
					if (Main.vanityPet[type] && Main.vanityPet[this.buffType[k]])
					{
						this.DelBuff(k);
					}
					if (Main.lightPet[type] && Main.lightPet[this.buffType[k]])
					{
						this.DelBuff(k);
					}
				}
			}
			while (num == -1)
			{
				int num2 = -1;
				for (int l = 0; l < 22; l++)
				{
					if (!Main.debuff[this.buffType[l]])
					{
						num2 = l;
						break;
					}
				}
				if (num2 == -1)
				{
					return;
				}
				for (int m = num2; m < 22; m++)
				{
					if (this.buffType[m] == 0)
					{
						num = m;
						break;
					}
				}
				if (num == -1)
				{
					this.DelBuff(num2);
				}
			}
			this.buffType[num] = type;
			this.buffTime[num] = time;
			if (Main.meleeBuff[type])
			{
				for (int n = 0; n < 22; n++)
				{
					if (n != num && Main.meleeBuff[this.buffType[n]])
					{
						this.DelBuff(n);
					}
				}
			}
		}
		public void DelBuff(int b)
		{
			this.buffTime[b] = 0;
			this.buffType[b] = 0;
			for (int i = 0; i < 21; i++)
			{
				if (this.buffTime[i] == 0 || this.buffType[i] == 0)
				{
					for (int j = i + 1; j < 22; j++)
					{
						this.buffTime[j - 1] = this.buffTime[j];
						this.buffType[j - 1] = this.buffType[j];
						this.buffTime[j] = 0;
						this.buffType[j] = 0;
					}
				}
			}
		}
		public void QuickHeal()
		{
			if (this.noItems)
			{
				return;
			}
			if (this.statLife == this.statLifeMax || this.potionDelay > 0)
			{
				return;
			}
			for (int i = 0; i < 58; i++)
			{
				if (this.inventory[i].stack > 0 && this.inventory[i].type > 0 && this.inventory[i].potion && this.inventory[i].healLife > 0)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, this.inventory[i].useSound);
					if (this.inventory[i].potion)
					{
						this.potionDelay = this.potionDelayTime;
						this.AddBuff(21, this.potionDelay, true);
					}
					this.statLife += this.inventory[i].healLife;
					this.statMana += this.inventory[i].healMana;
					if (this.statLife > this.statLifeMax)
					{
						this.statLife = this.statLifeMax;
					}
					if (this.statMana > this.statManaMax2)
					{
						this.statMana = this.statManaMax2;
					}
					this.inventory[i].stack--;
					if (this.inventory[i].stack <= 0)
					{
						this.inventory[i].type = 0;
						this.inventory[i].name = "";
					}
					Recipe.FindRecipes();
					return;
				}
			}
		}
		public void QuickMana()
		{
			if (this.noItems)
			{
				return;
			}
			if (this.statMana == this.statManaMax2)
			{
				return;
			}
			for (int i = 0; i < 58; i++)
			{
				if (this.inventory[i].stack > 0 && this.inventory[i].type > 0 && this.inventory[i].healMana > 0 && (this.potionDelay == 0 || !this.inventory[i].potion))
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, this.inventory[i].useSound);
					if (this.inventory[i].potion)
					{
						this.potionDelay = this.potionDelayTime;
						this.AddBuff(21, this.potionDelay, true);
					}
					this.statLife += this.inventory[i].healLife;
					this.statMana += this.inventory[i].healMana;
					if (this.statLife > this.statLifeMax)
					{
						this.statLife = this.statLifeMax;
					}
					if (this.statMana > this.statManaMax2)
					{
						this.statMana = this.statManaMax2;
					}
					if (this.inventory[i].healMana > 0)
					{
						this.AddBuff(94, Player.manaSickTime, true);
					}
					this.inventory[i].stack--;
					if (this.inventory[i].stack <= 0)
					{
						this.inventory[i].type = 0;
						this.inventory[i].name = "";
					}
					Recipe.FindRecipes();
					return;
				}
			}
		}
		public int countBuffs()
		{
			int num = 0;
			for (int i = 0; i < 22; i++)
			{
				if (this.buffType[num] > 0)
				{
					num++;
				}
			}
			return num;
		}
		public void QuickBuff()
		{
			if (this.noItems)
			{
				return;
			}
			int num = 0;
			for (int i = 0; i < 58; i++)
			{
				if (this.countBuffs() == 22)
				{
					return;
				}
				if (this.inventory[i].stack > 0 && this.inventory[i].type > 0 && this.inventory[i].buffType > 0 && !this.inventory[i].summon && this.inventory[i].buffType != 90)
				{
					int num2 = this.inventory[i].buffType;
					bool flag = true;
					for (int j = 0; j < 22; j++)
					{
						if ((num2 == 27 && this.buffType[j] == num2) || this.buffType[j] == 101 || this.buffType[j] == 102)
						{
							flag = false;
							break;
						}
						if (this.buffType[j] == num2)
						{
							flag = false;
							break;
						}
						if (Main.meleeBuff[num2] && Main.meleeBuff[this.buffType[j]])
						{
							flag = false;
							break;
						}
					}
					if (Main.lightPet[this.inventory[i].buffType] || Main.vanityPet[this.inventory[i].buffType])
					{
						for (int k = 0; k < 22; k++)
						{
							if (Main.lightPet[this.buffType[k]] && Main.lightPet[this.inventory[i].buffType])
							{
								flag = false;
							}
							if (Main.vanityPet[this.buffType[k]] && Main.vanityPet[this.inventory[i].buffType])
							{
								flag = false;
							}
						}
					}
					if (this.inventory[i].mana > 0 && flag)
					{
						if (this.statMana >= (int)((float)this.inventory[i].mana * this.manaCost))
						{
							this.manaRegenDelay = (int)this.maxRegenDelay;
							this.statMana -= (int)((float)this.inventory[i].mana * this.manaCost);
						}
						else
						{
							flag = false;
						}
					}
					if (this.whoAmi == Main.myPlayer && this.inventory[i].type == 603 && !Main.cEd)
					{
						flag = false;
					}
					if (num2 == 27)
					{
						num2 = Main.rand.Next(3);
						if (num2 == 0)
						{
							num2 = 27;
						}
						if (num2 == 1)
						{
							num2 = 101;
						}
						if (num2 == 2)
						{
							num2 = 102;
						}
					}
					if (flag)
					{
						num = this.inventory[i].useSound;
						int num3 = this.inventory[i].buffTime;
						if (num3 == 0)
						{
							num3 = 3600;
						}
						this.AddBuff(num2, num3, true);
						if (this.inventory[i].consumable)
						{
							this.inventory[i].stack--;
							if (this.inventory[i].stack <= 0)
							{
								this.inventory[i].type = 0;
								this.inventory[i].name = "";
							}
						}
					}
				}
			}
			if (num > 0)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, num);
				Recipe.FindRecipes();
			}
		}
		public void StatusNPC(int type, int i)
		{
			if (this.meleeEnchant > 0)
			{
				if (this.meleeEnchant == 1)
				{
					Main.npc[i].AddBuff(70, 60 * Main.rand.Next(5, 10), false);
				}
				if (this.meleeEnchant == 2)
				{
					Main.npc[i].AddBuff(39, 60 * Main.rand.Next(3, 7), false);
				}
				if (this.meleeEnchant == 3)
				{
					Main.npc[i].AddBuff(24, 60 * Main.rand.Next(3, 7), false);
				}
				if (this.meleeEnchant == 5)
				{
					Main.npc[i].AddBuff(69, 60 * Main.rand.Next(10, 20), false);
				}
				if (this.meleeEnchant == 6)
				{
					Main.npc[i].AddBuff(31, 60 * Main.rand.Next(1, 4), false);
				}
				if (this.meleeEnchant == 8)
				{
					Main.npc[i].AddBuff(20, 60 * Main.rand.Next(5, 10), false);
				}
				if (this.meleeEnchant == 4)
				{
					Main.npc[i].AddBuff(69, 120, false);
				}
			}
			if (this.frostBurn)
			{
				Main.npc[i].AddBuff(44, 60 * Main.rand.Next(5, 15), false);
			}
			if (this.magmaStone)
			{
				if (Main.rand.Next(7) == 0)
				{
					Main.npc[i].AddBuff(24, 360, false);
				}
				else if (Main.rand.Next(3) == 0)
				{
					Main.npc[i].AddBuff(24, 120, false);
				}
				else
				{
					Main.npc[i].AddBuff(24, 60, false);
				}
			}
			if (type == 121)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(24, 180, false);
					return;
				}
			}
			else if (type == 122)
			{
				if (Main.rand.Next(10) == 0)
				{
					Main.npc[i].AddBuff(24, 180, false);
					return;
				}
			}
			else if (type == 190)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.npc[i].AddBuff(20, 420, false);
					return;
				}
			}
			else if (type == 217)
			{
				if (Main.rand.Next(5) == 0)
				{
					Main.npc[i].AddBuff(24, 180, false);
					return;
				}
			}
			else if (type == 1123 && Main.rand.Next(10) != 0)
			{
				Main.npc[i].AddBuff(31, 120, false);
			}
		}
		public void StatusPvP(int type, int i)
		{
			if (this.meleeEnchant > 0)
			{
				if (this.meleeEnchant == 1)
				{
					Main.player[i].AddBuff(70, 60 * Main.rand.Next(5, 10), true);
				}
				if (this.meleeEnchant == 2)
				{
					Main.player[i].AddBuff(39, 60 * Main.rand.Next(3, 7), true);
				}
				if (this.meleeEnchant == 3)
				{
					Main.player[i].AddBuff(24, 60 * Main.rand.Next(3, 7), true);
				}
				if (this.meleeEnchant == 5)
				{
					Main.player[i].AddBuff(69, 60 * Main.rand.Next(10, 20), true);
				}
				if (this.meleeEnchant == 6)
				{
					Main.player[i].AddBuff(31, 60 * Main.rand.Next(1, 4), true);
				}
				if (this.meleeEnchant == 8)
				{
					Main.player[i].AddBuff(20, 60 * Main.rand.Next(5, 10), true);
				}
			}
			if (this.frostBurn)
			{
				Main.player[i].AddBuff(44, 60 * Main.rand.Next(1, 8), true);
			}
			if (this.magmaStone)
			{
				if (Main.rand.Next(7) == 0)
				{
					Main.player[i].AddBuff(24, 360, true);
				}
				else if (Main.rand.Next(3) == 0)
				{
					Main.player[i].AddBuff(24, 120, true);
				}
				else
				{
					Main.player[i].AddBuff(24, 60, true);
				}
			}
			if (type == 121)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(24, 180, false);
					return;
				}
			}
			else if (type == 122)
			{
				if (Main.rand.Next(10) == 0)
				{
					Main.player[i].AddBuff(24, 180, false);
					return;
				}
			}
			else if (type == 190)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.player[i].AddBuff(20, 420, false);
					return;
				}
			}
			else if (type == 217)
			{
				if (Main.rand.Next(5) == 0)
				{
					Main.player[i].AddBuff(24, 180, false);
					return;
				}
			}
			else if (type == 1123 && Main.rand.Next(9) != 0)
			{
				Main.player[i].AddBuff(31, 120, false);
			}
		}
		public void Ghost()
		{
			this.immune = false;
			this.immuneAlpha = 0;
			this.controlUp = false;
			this.controlLeft = false;
			this.controlDown = false;
			this.controlRight = false;
			this.controlJump = false;
			if (this.controlUp || this.controlJump)
			{
				if (this.velocity.Y > 0f)
				{
					this.velocity.Y = this.velocity.Y * 0.9f;
				}
				this.velocity.Y = this.velocity.Y - 0.1f;
				if (this.velocity.Y < -3f)
				{
					this.velocity.Y = -3f;
				}
			}
			else if (this.controlDown)
			{
				if (this.velocity.Y < 0f)
				{
					this.velocity.Y = this.velocity.Y * 0.9f;
				}
				this.velocity.Y = this.velocity.Y + 0.1f;
				if (this.velocity.Y > 3f)
				{
					this.velocity.Y = 3f;
				}
			}
			else if ((double)this.velocity.Y < -0.1 || (double)this.velocity.Y > 0.1)
			{
				this.velocity.Y = this.velocity.Y * 0.9f;
			}
			else
			{
				this.velocity.Y = 0f;
			}
			if (this.controlLeft && !this.controlRight)
			{
				if (this.velocity.X > 0f)
				{
					this.velocity.X = this.velocity.X * 0.9f;
				}
				this.velocity.X = this.velocity.X - 0.1f;
				if (this.velocity.X < -3f)
				{
					this.velocity.X = -3f;
				}
			}
			else if (this.controlRight && !this.controlLeft)
			{
				if (this.velocity.X < 0f)
				{
					this.velocity.X = this.velocity.X * 0.9f;
				}
				this.velocity.X = this.velocity.X + 0.1f;
				if (this.velocity.X > 3f)
				{
					this.velocity.X = 3f;
				}
			}
			else if ((double)this.velocity.X < -0.1 || (double)this.velocity.X > 0.1)
			{
				this.velocity.X = this.velocity.X * 0.9f;
			}
			else
			{
				this.velocity.X = 0f;
			}
			this.position += this.velocity;
			this.ghostFrameCounter++;
			if (this.velocity.X < 0f)
			{
				this.direction = -1;
			}
			else if (this.velocity.X > 0f)
			{
				this.direction = 1;
			}
			if (this.ghostFrameCounter >= 8)
			{
				this.ghostFrameCounter = 0;
				this.ghostFrame++;
				if (this.ghostFrame >= 4)
				{
					this.ghostFrame = 0;
				}
			}
			if (this.position.X < Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
			{
				this.position.X = Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
				this.velocity.X = 0f;
			}
			if (this.position.X + (float)this.width > Main.rightWorld - (float)(Lighting.offScreenTiles * 16) - 32f)
			{
				this.position.X = Main.rightWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.width;
				this.velocity.X = 0f;
			}
			if (this.position.Y < Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
			{
				this.position.Y = Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
				if ((double)this.velocity.Y < -0.1)
				{
					this.velocity.Y = -0.1f;
				}
			}
			if (this.position.Y > Main.bottomWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.height)
			{
				this.position.Y = Main.bottomWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.height;
				this.velocity.Y = 0f;
			}
		}
		public Vector2 Center()
		{
			return new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2));
		}
		public void onHit(float x, float y)
		{
			if (Main.myPlayer != this.whoAmi)
			{
				return;
			}
			if (this.onHitDodge && this.shadowDodgeTimer == 0 && Main.rand.Next(4) == 0)
			{
				if (!this.shadowDodge)
				{
					this.shadowDodgeTimer = 1200;
				}
				this.AddBuff(59, 1200, true);
			}
			if (this.onHitRegen)
			{
				this.AddBuff(58, 300, true);
			}
			if (this.onHitPetal && this.petalTimer == 0)
			{
				this.petalTimer = 20;
				if (x < this.position.X + (float)(this.width / 2))
				{
				}
				int num = this.direction;
				float num2 = Main.screenPosition.X;
				if (num < 0)
				{
					num2 += (float)Main.screenWidth;
				}
				float num3 = Main.screenPosition.Y;
				num3 += (float)Main.rand.Next(Main.screenHeight);
				Vector2 vector = new Vector2(num2, num3);
				float num4 = x - vector.X;
				float num5 = y - vector.Y;
				num4 += (float)Main.rand.Next(-50, 51) * 0.1f;
				num5 += (float)Main.rand.Next(-50, 51) * 0.1f;
				int num6 = 24;
				float num7 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
				num7 = (float)num6 / num7;
				num4 *= num7;
				num5 *= num7;
				Projectile.NewProjectile(num2, num3, num4, num5, 221, 36, 0f, this.whoAmi, 0f, 0f);
			}
			if (this.crystalLeaf && this.petalTimer == 0)
			{
				int arg_1AA_0 = this.inventory[this.selectedItem].type;
				for (int i = 0; i < 1000; i++)
				{
					if (Main.projectile[i].owner == this.whoAmi && Main.projectile[i].type == 226)
					{
						this.petalTimer = 50;
						float num8 = 12f;
						Vector2 vector2 = new Vector2(Main.projectile[i].position.X + (float)this.width * 0.5f, Main.projectile[i].position.Y + (float)this.height * 0.5f);
						float num9 = x - vector2.X;
						float num10 = y - vector2.Y;
						float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
						num11 = num8 / num11;
						num9 *= num11;
						num10 *= num11;
						Projectile.NewProjectile(Main.projectile[i].center().X - 4f, Main.projectile[i].center().Y, num9, num10, 227, 50, 5f, this.whoAmi, 0f, 0f);
						return;
					}
				}
			}
		}
		public void openPresent()
		{
			if (Main.rand.Next(15) == 0 && Main.hardMode)
			{
				int number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 602, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0);
					return;
				}
			}
			else if (Main.rand.Next(400) == 0)
			{
				int number2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1927, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number2, 1f, 0f, 0f, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int number3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1870, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number3, 1f, 0f, 0f, 0);
				}
				number3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 97, Main.rand.Next(30, 61), false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number3, 1f, 0f, 0f, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int number4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1909, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number4, 1f, 0f, 0f, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1917, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int number6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1918, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number6, 1f, 0f, 0f, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int number7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1921, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number7, 1f, 0f, 0f, 0);
					return;
				}
			}
			else if (Main.rand.Next(300) == 0)
			{
				int number8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1923, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number8, 1f, 0f, 0f, 0);
					return;
				}
			}
			else if (Main.rand.Next(40) == 0)
			{
				int number9 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1907, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number9, 1f, 0f, 0f, 0);
					return;
				}
			}
			else if (Main.rand.Next(10) == 0)
			{
				int number10 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1908, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number10, 1f, 0f, 0f, 0);
					return;
				}
			}
			else if (Main.rand.Next(15) == 0)
			{
				int num = Main.rand.Next(5);
				if (num == 0)
				{
					int number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1932, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0);
					}
					number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1933, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0);
					}
					number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1934, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 1)
				{
					int number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1935, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0);
					}
					number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1936, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0);
					}
					number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1937, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 2)
				{
					int number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1940, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0);
					}
					number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1941, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0);
					}
					number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1942, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 3)
				{
					int number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1938, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 4)
				{
					int number15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1939, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number15, 1f, 0f, 0f, 0);
						return;
					}
				}
			}
			else if (Main.rand.Next(7) == 0)
			{
				int num2 = Main.rand.Next(3);
				if (num2 == 0)
				{
					num2 = 1911;
				}
				if (num2 == 1)
				{
					num2 = 1919;
				}
				if (num2 == 2)
				{
					num2 = 1920;
				}
				int number16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num2, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number16, 1f, 0f, 0f, 0);
					return;
				}
			}
			else if (Main.rand.Next(8) == 0)
			{
				int number17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1912, Main.rand.Next(1, 4), false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number17, 1f, 0f, 0f, 0);
					return;
				}
			}
			else if (Main.rand.Next(9) == 0)
			{
				int number18 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1913, Main.rand.Next(20, 41), false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number18, 1f, 0f, 0f, 0);
					return;
				}
			}
			else
			{
				int num3 = Main.rand.Next(3);
				if (num3 == 0)
				{
					int number19 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1872, Main.rand.Next(20, 50), false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number19, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num3 == 1)
				{
					int number20 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 586, Main.rand.Next(20, 50), false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number20, 1f, 0f, 0f, 0);
						return;
					}
				}
				else
				{
					int number21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 591, Main.rand.Next(20, 50), false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number21, 1f, 0f, 0f, 0);
					}
				}
			}
		}
		public void openGoodieBag()
		{
			if (Main.rand.Next(150) == 0)
			{
				int number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1810, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int number2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1800, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number2, 1f, 0f, 0f, 0);
					return;
				}
			}
			else if (Main.rand.Next(3) == 1)
			{
				int number3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1809, Main.rand.Next(10, 41), false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number3, 1f, 0f, 0f, 0);
					return;
				}
			}
			else if (Main.rand.Next(10) == 0)
			{
				int number4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Main.rand.Next(1846, 1851), 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number4, 1f, 0f, 0f, 0);
					return;
				}
			}
			else
			{
				int num = Main.rand.Next(19);
				if (num == 0)
				{
					int number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1749, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0);
					}
					number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1750, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0);
					}
					number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1751, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 1)
				{
					int number6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1746, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number6, 1f, 0f, 0f, 0);
					}
					number6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1747, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number6, 1f, 0f, 0f, 0);
					}
					number6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1748, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number6, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 2)
				{
					int number7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1752, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number7, 1f, 0f, 0f, 0);
					}
					number7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1753, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number7, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 3)
				{
					int number8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1767, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number8, 1f, 0f, 0f, 0);
					}
					number8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1768, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number8, 1f, 0f, 0f, 0);
					}
					number8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1769, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number8, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 4)
				{
					int number9 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1770, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number9, 1f, 0f, 0f, 0);
					}
					number9 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1771, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number9, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 5)
				{
					int number10 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1772, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number10, 1f, 0f, 0f, 0);
					}
					number10 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1773, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number10, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 6)
				{
					int number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1754, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0);
					}
					number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1755, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0);
					}
					number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1756, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 7)
				{
					int number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1757, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0);
					}
					number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1758, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0);
					}
					number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1759, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 8)
				{
					int number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1760, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0);
					}
					number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1761, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0);
					}
					number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1762, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 9)
				{
					int number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1763, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0);
					}
					number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1764, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0);
					}
					number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1765, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 10)
				{
					int number15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1766, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number15, 1f, 0f, 0f, 0);
					}
					number15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1775, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number15, 1f, 0f, 0f, 0);
					}
					number15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1776, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number15, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 11)
				{
					int number16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1777, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number16, 1f, 0f, 0f, 0);
					}
					number16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1778, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number16, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 12)
				{
					int number17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1779, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number17, 1f, 0f, 0f, 0);
					}
					number17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1780, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number17, 1f, 0f, 0f, 0);
					}
					number17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1781, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number17, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 13)
				{
					int number18 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1819, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number18, 1f, 0f, 0f, 0);
					}
					number18 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1820, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number18, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 14)
				{
					int number19 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1821, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number19, 1f, 0f, 0f, 0);
					}
					number19 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1822, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number19, 1f, 0f, 0f, 0);
					}
					number19 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1823, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number19, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 15)
				{
					int number20 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1824, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number20, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 16)
				{
					int number21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1838, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number21, 1f, 0f, 0f, 0);
					}
					number21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1839, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number21, 1f, 0f, 0f, 0);
					}
					number21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1840, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number21, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 17)
				{
					int number22 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1841, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number22, 1f, 0f, 0f, 0);
					}
					number22 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1842, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number22, 1f, 0f, 0f, 0);
					}
					number22 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1843, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number22, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 18)
				{
					int number23 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1851, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number23, 1f, 0f, 0f, 0);
					}
					number23 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1852, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number23, 1f, 0f, 0f, 0);
					}
				}
			}
		}
		public void UpdatePlayerBuffs(int i)
		{
			for (int j = 0; j < 22; j++)
			{
				if (this.buffType[j] > 0 && this.buffTime[j] > 0)
				{
					if (this.whoAmi == Main.myPlayer && this.buffType[j] != 28)
					{
						this.buffTime[j]--;
					}
					if (this.buffType[j] == 1)
					{
						this.lavaImmune = true;
						this.fireWalk = true;
					}
					else if (this.buffType[j] == 2)
					{
						this.lifeRegen += 2;
					}
					else if (this.buffType[j] == 3)
					{
						this.moveSpeed += 0.25f;
					}
					else if (this.buffType[j] == 4)
					{
						this.gills = true;
					}
					else if (this.buffType[j] == 5)
					{
						this.statDefense += 8;
					}
					else if (this.buffType[j] == 6)
					{
						this.manaRegenBuff = true;
					}
					else if (this.buffType[j] == 7)
					{
						this.magicDamage += 0.2f;
					}
					else if (this.buffType[j] == 8)
					{
						this.slowFall = true;
					}
					else if (this.buffType[j] == 9)
					{
						this.findTreasure = true;
					}
					else if (this.buffType[j] == 10)
					{
						this.invis = true;
					}
					else if (this.buffType[j] == 12)
					{
						this.nightVision = true;
					}
					else if (this.buffType[j] == 13)
					{
						this.enemySpawns = true;
					}
					else if (this.buffType[j] == 14)
					{
						this.thorns = true;
					}
					else if (this.buffType[j] == 15)
					{
						this.waterWalk = true;
					}
					else if (this.buffType[j] == 16)
					{
						this.archery = true;
					}
					else if (this.buffType[j] == 17)
					{
						this.detectCreature = true;
					}
					else if (this.buffType[j] == 18)
					{
						this.gravControl = true;
					}
					else if (this.buffType[j] == 30)
					{
						this.bleed = true;
					}
					else if (this.buffType[j] == 31)
					{
						this.confused = true;
					}
					else if (this.buffType[j] == 32)
					{
						this.slow = true;
					}
					else if (this.buffType[j] == 35)
					{
						this.silence = true;
					}
					else if (this.buffType[j] == 46)
					{
						this.chilled = true;
					}
					else if (this.buffType[j] == 47)
					{
						this.frozen = true;
					}
					else if (this.buffType[j] == 69)
					{
						this.ichor = true;
						this.statDefense -= 20;
					}
					else if (this.buffType[j] == 36)
					{
						this.brokenArmor = true;
					}
					else if (this.buffType[j] == 48)
					{
						this.honey = true;
					}
					else if (this.buffType[j] == 59)
					{
						this.shadowDodge = true;
					}
					else if (this.buffType[j] == 93)
					{
						this.ammoBox = true;
					}
					else if (this.buffType[j] == 58)
					{
						this.palladiumRegen = true;
					}
					else if (this.buffType[j] == 88)
					{
						this.chaosState = true;
					}
					else if (this.buffType[j] == 63)
					{
						this.moveSpeed += 1f;
					}
					else if (this.buffType[j] == 94)
					{
						this.manaSick = true;
						this.manaSickReduction = Player.manaSickLessDmg * ((float)this.buffTime[j] / (float)Player.manaSickTime);
					}
					else if (this.buffType[j] >= 95 && this.buffType[j] <= 97)
					{
						this.buffTime[j] = 5;
						int num = (int)((byte)(1 + this.buffType[j] - 95));
						if (this.beetleOrbs > 0 && this.beetleOrbs != num)
						{
							if (this.beetleOrbs > num)
							{
								this.DelBuff(j);
							}
							else
							{
								for (int k = 0; k < 22; k++)
								{
									if (this.buffType[k] >= 95 && this.buffType[k] <= 95 + num - 1)
									{
										this.DelBuff(k);
									}
								}
							}
						}
						this.beetleOrbs = num;
						if (!this.beetleDefense)
						{
							this.beetleOrbs = 0;
							this.DelBuff(j);
						}
						else
						{
							this.beetleBuff = true;
						}
					}
					else if (this.buffType[j] >= 98 && this.buffType[j] <= 100)
					{
						int num2 = (int)((byte)(1 + this.buffType[j] - 98));
						if (this.beetleOrbs > 0 && this.beetleOrbs != num2)
						{
							if (this.beetleOrbs > num2)
							{
								this.DelBuff(j);
							}
							else
							{
								for (int l = 0; l < 22; l++)
								{
									if (this.buffType[l] >= 98 && this.buffType[l] <= 98 + num2 - 1)
									{
										this.DelBuff(l);
									}
								}
							}
						}
						this.beetleOrbs = num2;
						this.meleeDamage += 0.1f * (float)this.beetleOrbs;
						this.meleeSpeed += 0.1f * (float)this.beetleOrbs;
						if (!this.beetleOffense)
						{
							this.beetleOrbs = 0;
							this.DelBuff(j);
						}
						else
						{
							this.beetleBuff = true;
						}
					}
					else if (this.buffType[j] == 62)
					{
						if ((double)this.statLife <= (double)this.statLifeMax * 0.25)
						{
							this.iceBarrier = true;
							this.statDefense += 30;
							this.iceBarrierFrameCounter = (byte)(this.iceBarrierFrameCounter + 1);
							if (this.iceBarrierFrameCounter > 2)
							{
								this.iceBarrierFrameCounter = 0;
								this.iceBarrierFrame = (byte)(this.iceBarrierFrame + 1);
								if (this.iceBarrierFrame >= 12)
								{
									this.iceBarrierFrame = 0;
								}
							}
						}
						else
						{
							this.DelBuff(j);
						}
					}
					else if (this.buffType[j] == 49)
					{
						if (Main.myPlayer == i)
						{
							for (int m = 0; m < 1000; m++)
							{
								if (Main.projectile[m].active && Main.projectile[m].owner == i && Main.projectile[m].type >= 191 && Main.projectile[m].type <= 194)
								{
									this.pygmy = true;
									break;
								}
							}
							if (!this.pygmy)
							{
								this.DelBuff(j);
							}
							else
							{
								this.buffTime[j] = 18000;
							}
						}
					}
					else if (this.buffType[j] == 83)
					{
						if (Main.myPlayer == i)
						{
							for (int n = 0; n < 1000; n++)
							{
								if (Main.projectile[n].active && Main.projectile[n].owner == i && Main.projectile[n].type == 317)
								{
									this.raven = true;
									break;
								}
							}
							if (!this.raven)
							{
								this.DelBuff(j);
							}
							else
							{
								this.buffTime[j] = 18000;
							}
						}
					}
					else if (this.buffType[j] == 64)
					{
						if (Main.myPlayer == i)
						{
							for (int num3 = 0; num3 < 1000; num3++)
							{
								if (Main.projectile[num3].active && Main.projectile[num3].owner == i && Main.projectile[num3].type == 266)
								{
									this.slime = true;
									break;
								}
							}
							if (!this.slime)
							{
								this.DelBuff(j);
							}
							else
							{
								this.buffTime[j] = 18000;
							}
						}
					}
					else if (this.buffType[j] == 90)
					{
						this.mount = 1;
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == 37)
					{
						if (Main.wof >= 0 && Main.npc[Main.wof].type == 113)
						{
							this.gross = true;
							this.buffTime[j] = 10;
						}
						else
						{
							this.DelBuff(j);
						}
					}
					else if (this.buffType[j] == 38)
					{
						this.buffTime[j] = 10;
						this.tongued = true;
					}
					else if (this.buffType[j] == 19)
					{
						this.buffTime[j] = 18000;
						this.lightOrb = true;
						bool flag = true;
						for (int num4 = 0; num4 < 1000; num4++)
						{
							if (Main.projectile[num4].active && Main.projectile[num4].owner == this.whoAmi && Main.projectile[num4].type == 18)
							{
								flag = false;
							}
						}
						if (flag)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 18, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 27 || this.buffType[j] == 101 || this.buffType[j] == 102)
					{
						this.buffTime[j] = 18000;
						bool flag2 = true;
						int num5 = 72;
						if (this.buffType[j] == 27)
						{
							this.blueFairy = true;
						}
						if (this.buffType[j] == 101)
						{
							num5 = 86;
							this.redFairy = true;
						}
						if (this.buffType[j] == 102)
						{
							num5 = 87;
							this.greenFairy = true;
						}
						if (this.head == 45 && this.body == 26 && this.legs == 25)
						{
							num5 = 72;
						}
						for (int num6 = 0; num6 < 1000; num6++)
						{
							if (Main.projectile[num6].active && Main.projectile[num6].owner == this.whoAmi && Main.projectile[num6].type == num5)
							{
								flag2 = false;
								break;
							}
						}
						if (flag2)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, num5, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 40)
					{
						this.buffTime[j] = 18000;
						this.bunny = true;
						bool flag3 = true;
						for (int num7 = 0; num7 < 1000; num7++)
						{
							if (Main.projectile[num7].active && Main.projectile[num7].owner == this.whoAmi && Main.projectile[num7].type == 111)
							{
								flag3 = false;
								break;
							}
						}
						if (flag3)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 111, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 41)
					{
						this.buffTime[j] = 18000;
						this.penguin = true;
						bool flag4 = true;
						for (int num8 = 0; num8 < 1000; num8++)
						{
							if (Main.projectile[num8].active && Main.projectile[num8].owner == this.whoAmi && Main.projectile[num8].type == 112)
							{
								flag4 = false;
								break;
							}
						}
						if (flag4)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 112, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 91)
					{
						this.buffTime[j] = 18000;
						this.puppy = true;
						bool flag5 = true;
						for (int num9 = 0; num9 < 1000; num9++)
						{
							if (Main.projectile[num9].active && Main.projectile[num9].owner == this.whoAmi && Main.projectile[num9].type == 334)
							{
								flag5 = false;
								break;
							}
						}
						if (flag5)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 334, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 92)
					{
						this.buffTime[j] = 18000;
						this.grinch = true;
						bool flag6 = true;
						for (int num10 = 0; num10 < 1000; num10++)
						{
							if (Main.projectile[num10].active && Main.projectile[num10].owner == this.whoAmi && Main.projectile[num10].type == 353)
							{
								flag6 = false;
								break;
							}
						}
						if (flag6)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 353, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 84)
					{
						this.buffTime[j] = 18000;
						this.blackCat = true;
						bool flag7 = true;
						for (int num11 = 0; num11 < 1000; num11++)
						{
							if (Main.projectile[num11].active && Main.projectile[num11].owner == this.whoAmi && Main.projectile[num11].type == 319)
							{
								flag7 = false;
								break;
							}
						}
						if (flag7)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 319, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 61)
					{
						this.buffTime[j] = 18000;
						this.dino = true;
						bool flag8 = true;
						for (int num12 = 0; num12 < 1000; num12++)
						{
							if (Main.projectile[num12].active && Main.projectile[num12].owner == this.whoAmi && Main.projectile[num12].type == 236)
							{
								flag8 = false;
								break;
							}
						}
						if (flag8)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 236, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 65)
					{
						this.buffTime[j] = 18000;
						this.eyeSpring = true;
						bool flag9 = true;
						for (int num13 = 0; num13 < 1000; num13++)
						{
							if (Main.projectile[num13].active && Main.projectile[num13].owner == this.whoAmi && Main.projectile[num13].type == 268)
							{
								flag9 = false;
								break;
							}
						}
						if (flag9)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 268, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 66)
					{
						this.buffTime[j] = 18000;
						this.snowman = true;
						bool flag10 = true;
						for (int num14 = 0; num14 < 1000; num14++)
						{
							if (Main.projectile[num14].active && Main.projectile[num14].owner == this.whoAmi && Main.projectile[num14].type == 269)
							{
								flag10 = false;
								break;
							}
						}
						if (flag10)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 269, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 42)
					{
						this.buffTime[j] = 18000;
						this.turtle = true;
						bool flag11 = true;
						for (int num15 = 0; num15 < 1000; num15++)
						{
							if (Main.projectile[num15].active && Main.projectile[num15].owner == this.whoAmi && Main.projectile[num15].type == 127)
							{
								flag11 = false;
								break;
							}
						}
						if (flag11)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 127, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 45)
					{
						this.buffTime[j] = 18000;
						this.eater = true;
						bool flag12 = true;
						for (int num16 = 0; num16 < 1000; num16++)
						{
							if (Main.projectile[num16].active && Main.projectile[num16].owner == this.whoAmi && Main.projectile[num16].type == 175)
							{
								flag12 = false;
								break;
							}
						}
						if (flag12)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 175, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 50)
					{
						this.buffTime[j] = 18000;
						this.skeletron = true;
						bool flag13 = true;
						for (int num17 = 0; num17 < 1000; num17++)
						{
							if (Main.projectile[num17].active && Main.projectile[num17].owner == this.whoAmi && Main.projectile[num17].type == 197)
							{
								flag13 = false;
								break;
							}
						}
						if (flag13)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 197, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 51)
					{
						this.buffTime[j] = 18000;
						this.hornet = true;
						bool flag14 = true;
						for (int num18 = 0; num18 < 1000; num18++)
						{
							if (Main.projectile[num18].active && Main.projectile[num18].owner == this.whoAmi && Main.projectile[num18].type == 198)
							{
								flag14 = false;
								break;
							}
						}
						if (flag14)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 198, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 52)
					{
						this.buffTime[j] = 18000;
						this.tiki = true;
						bool flag15 = true;
						for (int num19 = 0; num19 < 1000; num19++)
						{
							if (Main.projectile[num19].active && Main.projectile[num19].owner == this.whoAmi && Main.projectile[num19].type == 199)
							{
								flag15 = false;
								break;
							}
						}
						if (flag15)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 199, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 53)
					{
						this.buffTime[j] = 18000;
						this.lizard = true;
						bool flag16 = true;
						for (int num20 = 0; num20 < 1000; num20++)
						{
							if (Main.projectile[num20].active && Main.projectile[num20].owner == this.whoAmi && Main.projectile[num20].type == 200)
							{
								flag16 = false;
								break;
							}
						}
						if (flag16)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 200, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 54)
					{
						this.buffTime[j] = 18000;
						this.parrot = true;
						bool flag17 = true;
						for (int num21 = 0; num21 < 1000; num21++)
						{
							if (Main.projectile[num21].active && Main.projectile[num21].owner == this.whoAmi && Main.projectile[num21].type == 208)
							{
								flag17 = false;
								break;
							}
						}
						if (flag17)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 208, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 55)
					{
						this.buffTime[j] = 18000;
						this.truffle = true;
						bool flag18 = true;
						for (int num22 = 0; num22 < 1000; num22++)
						{
							if (Main.projectile[num22].active && Main.projectile[num22].owner == this.whoAmi && Main.projectile[num22].type == 209)
							{
								flag18 = false;
								break;
							}
						}
						if (flag18)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 209, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 56)
					{
						this.buffTime[j] = 18000;
						this.sapling = true;
						bool flag19 = true;
						for (int num23 = 0; num23 < 1000; num23++)
						{
							if (Main.projectile[num23].active && Main.projectile[num23].owner == this.whoAmi && Main.projectile[num23].type == 210)
							{
								flag19 = false;
								break;
							}
						}
						if (flag19)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 210, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 85)
					{
						this.buffTime[j] = 18000;
						this.cSapling = true;
						bool flag20 = true;
						for (int num24 = 0; num24 < 1000; num24++)
						{
							if (Main.projectile[num24].active && Main.projectile[num24].owner == this.whoAmi && Main.projectile[num24].type == 324)
							{
								flag20 = false;
								break;
							}
						}
						if (flag20)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 324, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 81)
					{
						this.buffTime[j] = 18000;
						this.spider = true;
						bool flag21 = true;
						for (int num25 = 0; num25 < 1000; num25++)
						{
							if (Main.projectile[num25].active && Main.projectile[num25].owner == this.whoAmi && Main.projectile[num25].type == 313)
							{
								flag21 = false;
								break;
							}
						}
						if (flag21)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 313, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 82)
					{
						this.buffTime[j] = 18000;
						this.squashling = true;
						bool flag22 = true;
						for (int num26 = 0; num26 < 1000; num26++)
						{
							if (Main.projectile[num26].active && Main.projectile[num26].owner == this.whoAmi && Main.projectile[num26].type == 314)
							{
								flag22 = false;
								break;
							}
						}
						if (flag22)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 314, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 57)
					{
						this.buffTime[j] = 18000;
						this.wisp = true;
						bool flag23 = true;
						for (int num27 = 0; num27 < 1000; num27++)
						{
							if (Main.projectile[num27].active && Main.projectile[num27].owner == this.whoAmi && Main.projectile[num27].type == 211)
							{
								flag23 = false;
								break;
							}
						}
						if (flag23)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 211, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 60)
					{
						this.buffTime[j] = 18000;
						this.crystalLeaf = true;
						bool flag24 = true;
						for (int num28 = 0; num28 < 1000; num28++)
						{
							if (Main.projectile[num28].active && Main.projectile[num28].owner == this.whoAmi && Main.projectile[num28].type == 226)
							{
								if (!flag24)
								{
									Main.projectile[num28].Kill();
								}
								flag24 = false;
							}
						}
						if (flag24)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 226, 0, 0f, this.whoAmi, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 70)
					{
						this.venom = true;
					}
					else if (this.buffType[j] == 20)
					{
						this.poisoned = true;
					}
					else if (this.buffType[j] == 21)
					{
						this.potionDelay = this.buffTime[j];
					}
					else if (this.buffType[j] == 22)
					{
						this.blind = true;
					}
					else if (this.buffType[j] == 80)
					{
						this.blackout = true;
					}
					else if (this.buffType[j] == 23)
					{
						this.noItems = true;
					}
					else if (this.buffType[j] == 24)
					{
						this.onFire = true;
					}
					else if (this.buffType[j] == 103)
					{
						this.dripping = true;
					}
					else if (this.buffType[j] == 67)
					{
						this.burned = true;
					}
					else if (this.buffType[j] == 68)
					{
						this.suffocating = true;
					}
					else if (this.buffType[j] == 39)
					{
						this.onFire2 = true;
					}
					else if (this.buffType[j] == 44)
					{
						this.onFrostBurn = true;
					}
					else if (this.buffType[j] == 43)
					{
						this.paladinBuff = true;
					}
					else if (this.buffType[j] == 29)
					{
						this.magicCrit += 2;
						this.magicDamage += 0.05f;
						this.statManaMax2 += 20;
						this.manaCost -= 0.02f;
					}
					else if (this.buffType[j] == 28)
					{
						if (!Main.dayTime && this.wolfAcc && !this.merman)
						{
							this.lifeRegen++;
							this.wereWolf = true;
							this.meleeCrit += 2;
							this.meleeDamage += 0.051f;
							this.meleeSpeed += 0.051f;
							this.statDefense += 3;
							this.moveSpeed += 0.05f;
						}
						else
						{
							this.DelBuff(j);
						}
					}
					else if (this.buffType[j] == 33)
					{
						this.meleeDamage -= 0.051f;
						this.meleeSpeed -= 0.051f;
						this.statDefense -= 4;
						this.moveSpeed -= 0.1f;
					}
					else if (this.buffType[j] == 25)
					{
						this.statDefense -= 4;
						this.meleeCrit += 2;
						this.meleeDamage += 0.1f;
						this.meleeSpeed += 0.1f;
					}
					else if (this.buffType[j] == 26)
					{
						this.statDefense += 2;
						this.meleeCrit += 2;
						this.meleeDamage += 0.05f;
						this.meleeSpeed += 0.05f;
						this.magicCrit += 2;
						this.magicDamage += 0.05f;
						this.rangedCrit += 2;
						this.magicDamage += 0.05f;
						this.minionDamage += 0.05f;
						this.minionKB += 0.5f;
						this.moveSpeed += 0.2f;
					}
					else if (this.buffType[j] == 71)
					{
						this.meleeEnchant = 1;
					}
					else if (this.buffType[j] == 73)
					{
						this.meleeEnchant = 2;
					}
					else if (this.buffType[j] == 74)
					{
						this.meleeEnchant = 3;
					}
					else if (this.buffType[j] == 75)
					{
						this.meleeEnchant = 4;
					}
					else if (this.buffType[j] == 76)
					{
						this.meleeEnchant = 5;
					}
					else if (this.buffType[j] == 77)
					{
						this.meleeEnchant = 6;
					}
					else if (this.buffType[j] == 78)
					{
						this.meleeEnchant = 7;
					}
					else if (this.buffType[j] == 79)
					{
						this.meleeEnchant = 8;
					}
				}
			}
		}
		public void UpdatePlayerEquips(int i)
		{
			for (int j = 0; j < 8; j++)
			{
				this.statDefense += this.armor[j].defense;
				this.lifeRegen += this.armor[j].lifeRegen;
				if (this.armor[j].type == 268)
				{
					this.accDivingHelm = true;
				}
				if (this.armor[j].type == 238)
				{
					this.magicDamage += 0.15f;
				}
				if (this.armor[j].type == 2277)
				{
					this.magicDamage += 0.05f;
					this.meleeDamage += 0.05f;
					this.rangedDamage += 0.05f;
					this.magicCrit += 5;
					this.rangedCrit += 5;
					this.meleeCrit += 5;
					this.meleeSpeed += 0.1f;
					this.moveSpeed += 0.1f;
				}
				if (this.armor[j].type == 2279)
				{
					this.magicDamage += 0.06f;
					this.magicCrit += 6;
					this.manaCost -= 0.1f;
				}
				if (this.armor[j].type == 2275)
				{
					this.magicDamage += 0.07f;
					this.magicCrit += 7;
				}
				if (this.armor[j].type == 123 || this.armor[j].type == 124 || this.armor[j].type == 125)
				{
					this.magicDamage += 0.07f;
				}
				if (this.armor[j].type == 151 || this.armor[j].type == 152 || this.armor[j].type == 153 || this.armor[j].type == 959)
				{
					this.rangedDamage += 0.05f;
				}
				if (this.armor[j].type == 111 || this.armor[j].type == 228 || this.armor[j].type == 229 || this.armor[j].type == 230 || this.armor[j].type == 960 || this.armor[j].type == 961 || this.armor[j].type == 962)
				{
					this.statManaMax2 += 20;
				}
				if (this.armor[j].type == 228 || this.armor[j].type == 229 || this.armor[j].type == 230 || this.armor[j].type == 960 || this.armor[j].type == 961 || this.armor[j].type == 962)
				{
					this.magicCrit += 3;
				}
				if (this.armor[j].type == 100 || this.armor[j].type == 101 || this.armor[j].type == 102)
				{
					this.meleeSpeed += 0.07f;
				}
				if (this.armor[j].type == 956 || this.armor[j].type == 957 || this.armor[j].type == 958)
				{
					this.meleeSpeed += 0.07f;
				}
				if (this.armor[j].type == 791 || this.armor[j].type == 792 || this.armor[j].type == 793)
				{
					this.meleeDamage += 0.02f;
					this.rangedDamage += 0.02f;
					this.magicDamage += 0.02f;
				}
				if (this.armor[j].type == 371)
				{
					this.magicCrit += 9;
					this.statManaMax2 += 40;
				}
				if (this.armor[j].type == 372)
				{
					this.moveSpeed += 0.07f;
					this.meleeSpeed += 0.12f;
				}
				if (this.armor[j].type == 373)
				{
					this.rangedDamage += 0.1f;
					this.rangedCrit += 6;
				}
				if (this.armor[j].type == 374)
				{
					this.magicCrit += 3;
					this.meleeCrit += 3;
					this.rangedCrit += 3;
				}
				if (this.armor[j].type == 375)
				{
					this.moveSpeed += 0.1f;
				}
				if (this.armor[j].type == 376)
				{
					this.magicDamage += 0.15f;
					this.statManaMax2 += 60;
				}
				if (this.armor[j].type == 377)
				{
					this.meleeCrit += 5;
					this.meleeDamage += 0.1f;
				}
				if (this.armor[j].type == 378)
				{
					this.rangedDamage += 0.12f;
					this.rangedCrit += 7;
				}
				if (this.armor[j].type == 379)
				{
					this.rangedDamage += 0.05f;
					this.meleeDamage += 0.05f;
					this.magicDamage += 0.05f;
				}
				if (this.armor[j].type == 380)
				{
					this.magicCrit += 3;
					this.meleeCrit += 3;
					this.rangedCrit += 3;
				}
				if (this.armor[j].type == 400)
				{
					this.magicDamage += 0.11f;
					this.magicCrit += 11;
					this.statManaMax2 += 80;
				}
				if (this.armor[j].type == 401)
				{
					this.meleeCrit += 7;
					this.meleeDamage += 0.14f;
				}
				if (this.armor[j].type == 402)
				{
					this.rangedDamage += 0.14f;
					this.rangedCrit += 8;
				}
				if (this.armor[j].type == 403)
				{
					this.rangedDamage += 0.06f;
					this.meleeDamage += 0.06f;
					this.magicDamage += 0.06f;
				}
				if (this.armor[j].type == 404)
				{
					this.magicCrit += 4;
					this.meleeCrit += 4;
					this.rangedCrit += 4;
					this.moveSpeed += 0.05f;
				}
				if (this.armor[j].type == 1205)
				{
					this.meleeDamage += 0.08f;
					this.meleeSpeed += 0.12f;
				}
				if (this.armor[j].type == 1206)
				{
					this.rangedDamage += 0.09f;
					this.rangedCrit += 9;
				}
				if (this.armor[j].type == 1207)
				{
					this.magicDamage += 0.07f;
					this.magicCrit += 7;
					this.statManaMax2 += 60;
				}
				if (this.armor[j].type == 1208)
				{
					this.meleeDamage += 0.03f;
					this.rangedDamage += 0.03f;
					this.magicDamage += 0.03f;
					this.magicCrit += 2;
					this.meleeCrit += 2;
					this.rangedCrit += 2;
				}
				if (this.armor[j].type == 1209)
				{
					this.meleeDamage += 0.02f;
					this.rangedDamage += 0.02f;
					this.magicDamage += 0.02f;
					this.magicCrit++;
					this.meleeCrit++;
					this.rangedCrit++;
				}
				if (this.armor[j].type == 1210)
				{
					this.meleeDamage += 0.07f;
					this.meleeSpeed += 0.07f;
					this.moveSpeed += 0.07f;
				}
				if (this.armor[j].type == 1211)
				{
					this.rangedCrit += 15;
					this.moveSpeed += 0.08f;
				}
				if (this.armor[j].type == 1212)
				{
					this.magicCrit += 18;
					this.statManaMax2 += 80;
				}
				if (this.armor[j].type == 1213)
				{
					this.magicCrit += 6;
					this.meleeCrit += 6;
					this.rangedCrit += 6;
				}
				if (this.armor[j].type == 1214)
				{
					this.moveSpeed += 0.11f;
				}
				if (this.armor[j].type == 1215)
				{
					this.meleeDamage += 0.08f;
					this.meleeCrit += 8;
					this.meleeSpeed += 0.08f;
				}
				if (this.armor[j].type == 1216)
				{
					this.rangedDamage += 0.16f;
					this.rangedCrit += 7;
				}
				if (this.armor[j].type == 1217)
				{
					this.magicDamage += 0.16f;
					this.magicCrit += 7;
					this.statManaMax2 += 100;
				}
				if (this.armor[j].type == 1218)
				{
					this.meleeDamage += 0.04f;
					this.rangedDamage += 0.04f;
					this.magicDamage += 0.04f;
					this.magicCrit += 3;
					this.meleeCrit += 3;
					this.rangedCrit += 3;
				}
				if (this.armor[j].type == 1219)
				{
					this.meleeDamage += 0.03f;
					this.rangedDamage += 0.03f;
					this.magicDamage += 0.03f;
					this.magicCrit += 3;
					this.meleeCrit += 3;
					this.rangedCrit += 3;
					this.moveSpeed += 0.06f;
				}
				if (this.armor[j].type == 558)
				{
					this.magicDamage += 0.12f;
					this.magicCrit += 12;
					this.statManaMax2 += 100;
				}
				if (this.armor[j].type == 559)
				{
					this.meleeCrit += 10;
					this.meleeDamage += 0.1f;
					this.meleeSpeed += 0.1f;
				}
				if (this.armor[j].type == 553)
				{
					this.rangedDamage += 0.15f;
					this.rangedCrit += 8;
				}
				if (this.armor[j].type == 551)
				{
					this.magicCrit += 7;
					this.meleeCrit += 7;
					this.rangedCrit += 7;
				}
				if (this.armor[j].type == 552)
				{
					this.rangedDamage += 0.07f;
					this.meleeDamage += 0.07f;
					this.magicDamage += 0.07f;
					this.moveSpeed += 0.08f;
				}
				if (this.armor[j].type == 1001)
				{
					this.meleeDamage += 0.16f;
					this.meleeCrit += 6;
				}
				if (this.armor[j].type == 1002)
				{
					this.rangedDamage += 0.16f;
					this.ammoCost80 = true;
				}
				if (this.armor[j].type == 1003)
				{
					this.statManaMax2 += 80;
					this.manaCost -= 0.17f;
					this.magicDamage += 0.16f;
				}
				if (this.armor[j].type == 1004)
				{
					this.meleeDamage += 0.05f;
					this.magicDamage += 0.05f;
					this.rangedDamage += 0.05f;
					this.magicCrit += 7;
					this.meleeCrit += 7;
					this.rangedCrit += 7;
				}
				if (this.armor[j].type == 1005)
				{
					this.magicCrit += 8;
					this.meleeCrit += 8;
					this.rangedCrit += 8;
					this.moveSpeed += 0.05f;
				}
				if (this.armor[j].type == 2189)
				{
					this.statManaMax2 += 60;
					this.manaCost -= 0.13f;
					this.magicDamage += 0.05f;
					this.magicCrit += 5;
				}
				if (this.armor[j].type == 1503)
				{
					this.manaCost += 0.2f;
					this.magicDamage -= 0.4f;
				}
				if (this.armor[j].type == 1504)
				{
					this.magicDamage += 0.07f;
					this.magicCrit += 7;
				}
				if (this.armor[j].type == 1505)
				{
					this.magicDamage += 0.08f;
					this.moveSpeed += 0.08f;
				}
				if (this.armor[j].type == 1546)
				{
					this.rangedCrit += 5;
					this.arrowDamage += 0.15f;
				}
				if (this.armor[j].type == 1547)
				{
					this.rangedCrit += 5;
					this.bulletDamage += 0.15f;
				}
				if (this.armor[j].type == 1548)
				{
					this.rangedCrit += 5;
					this.rocketDamage += 0.15f;
				}
				if (this.armor[j].type == 1549)
				{
					this.rangedCrit += 13;
					this.rangedDamage += 0.13f;
					this.ammoCost80 = true;
				}
				if (this.armor[j].type == 1550)
				{
					this.rangedCrit += 7;
					this.moveSpeed += 0.12f;
				}
				if (this.armor[j].type == 1282)
				{
					this.statManaMax2 += 20;
					this.manaCost -= 0.05f;
				}
				if (this.armor[j].type == 1283)
				{
					this.statManaMax2 += 40;
					this.manaCost -= 0.07f;
				}
				if (this.armor[j].type == 1284)
				{
					this.statManaMax2 += 40;
					this.manaCost -= 0.09f;
				}
				if (this.armor[j].type == 1285)
				{
					this.statManaMax2 += 60;
					this.manaCost -= 0.11f;
				}
				if (this.armor[j].type == 1286)
				{
					this.statManaMax2 += 60;
					this.manaCost -= 0.13f;
				}
				if (this.armor[j].type == 1287)
				{
					this.statManaMax2 += 80;
					this.manaCost -= 0.15f;
				}
				if (this.armor[j].type == 1316 || this.armor[j].type == 1317 || this.armor[j].type == 1318)
				{
					this.aggro += 250;
				}
				if (this.armor[j].type == 1316)
				{
					this.meleeDamage += 0.06f;
				}
				if (this.armor[j].type == 1317)
				{
					this.meleeDamage += 0.08f;
					this.meleeCrit += 8;
				}
				if (this.armor[j].type == 1318)
				{
					this.meleeCrit += 4;
				}
				if (this.armor[j].type == 2199 || this.armor[j].type == 2202)
				{
					this.aggro += 250;
				}
				if (this.armor[j].type == 2201)
				{
					this.aggro += 400;
				}
				if (this.armor[j].type == 2199)
				{
					this.meleeDamage += 0.06f;
				}
				if (this.armor[j].type == 2200)
				{
					this.meleeDamage += 0.08f;
					this.meleeCrit += 8;
					this.meleeSpeed += 0.06f;
					this.moveSpeed += 0.06f;
				}
				if (this.armor[j].type == 2201)
				{
					this.meleeDamage += 0.05f;
					this.meleeCrit += 5;
				}
				if (this.armor[j].type == 2202)
				{
					this.meleeSpeed += 0.06f;
					this.moveSpeed += 0.06f;
				}
				if (this.armor[j].type == 684)
				{
					this.rangedDamage += 0.16f;
					this.meleeDamage += 0.16f;
				}
				if (this.armor[j].type == 685)
				{
					this.meleeCrit += 11;
					this.rangedCrit += 11;
				}
				if (this.armor[j].type == 686)
				{
					this.moveSpeed += 0.08f;
					this.meleeSpeed += 0.07f;
				}
				if (this.armor[j].type >= 1158 && this.armor[j].type <= 1161)
				{
					this.maxMinions++;
				}
				if (this.armor[j].type >= 1159 && this.armor[j].type <= 1161)
				{
					this.minionDamage += 0.1f;
				}
				if (this.armor[j].type >= 1832 && this.armor[j].type <= 1834)
				{
					this.maxMinions++;
				}
				if (this.armor[j].type >= 1832 && this.armor[j].type <= 1834)
				{
					this.minionDamage += 0.11f;
				}
				if (this.armor[j].prefix == 62)
				{
					this.statDefense++;
				}
				if (this.armor[j].prefix == 63)
				{
					this.statDefense += 2;
				}
				if (this.armor[j].prefix == 64)
				{
					this.statDefense += 3;
				}
				if (this.armor[j].prefix == 65)
				{
					this.statDefense += 4;
				}
				if (this.armor[j].prefix == 66)
				{
					this.statManaMax2 += 20;
				}
				if (this.armor[j].prefix == 67)
				{
					this.meleeCrit += 2;
					this.rangedCrit += 2;
					this.magicCrit += 2;
				}
				if (this.armor[j].prefix == 68)
				{
					this.meleeCrit += 4;
					this.rangedCrit += 4;
					this.magicCrit += 4;
				}
				if (this.armor[j].prefix == 69)
				{
					this.meleeDamage += 0.01f;
					this.rangedDamage += 0.01f;
					this.magicDamage += 0.01f;
					this.minionDamage += 0.01f;
				}
				if (this.armor[j].prefix == 70)
				{
					this.meleeDamage += 0.02f;
					this.rangedDamage += 0.02f;
					this.magicDamage += 0.02f;
					this.minionDamage += 0.02f;
				}
				if (this.armor[j].prefix == 71)
				{
					this.meleeDamage += 0.03f;
					this.rangedDamage += 0.03f;
					this.magicDamage += 0.03f;
					this.minionDamage += 0.03f;
				}
				if (this.armor[j].prefix == 72)
				{
					this.meleeDamage += 0.04f;
					this.rangedDamage += 0.04f;
					this.magicDamage += 0.04f;
					this.minionDamage += 0.04f;
				}
				if (this.armor[j].prefix == 73)
				{
					this.moveSpeed += 0.01f;
				}
				if (this.armor[j].prefix == 74)
				{
					this.moveSpeed += 0.02f;
				}
				if (this.armor[j].prefix == 75)
				{
					this.moveSpeed += 0.03f;
				}
				if (this.armor[j].prefix == 76)
				{
					this.moveSpeed += 0.04f;
				}
				if (this.armor[j].prefix == 77)
				{
					this.meleeSpeed += 0.01f;
				}
				if (this.armor[j].prefix == 78)
				{
					this.meleeSpeed += 0.02f;
				}
				if (this.armor[j].prefix == 79)
				{
					this.meleeSpeed += 0.03f;
				}
				if (this.armor[j].prefix == 80)
				{
					this.meleeSpeed += 0.04f;
				}
			}
			for (int k = 3; k < 8; k++)
			{
				if (this.armor[k].type == 15 && this.accWatch < 1)
				{
					this.accWatch = 1;
				}
				if (this.armor[k].type == 16 && this.accWatch < 2)
				{
					this.accWatch = 2;
				}
				if (this.armor[k].type == 17 && this.accWatch < 3)
				{
					this.accWatch = 3;
				}
				if (this.armor[k].type == 707 && this.accWatch < 1)
				{
					this.accWatch = 1;
				}
				if (this.armor[k].type == 708 && this.accWatch < 2)
				{
					this.accWatch = 2;
				}
				if (this.armor[k].type == 709 && this.accWatch < 3)
				{
					this.accWatch = 3;
				}
				if (this.armor[k].type == 18 && this.accDepthMeter < 1)
				{
					this.accDepthMeter = 1;
				}
				if (this.armor[k].type == 857)
				{
					this.doubleJump2 = true;
				}
				if (this.armor[k].type == 983)
				{
					this.doubleJump2 = true;
					this.jumpBoost = true;
				}
				if (this.armor[k].type == 987)
				{
					this.doubleJump3 = true;
				}
				if (this.armor[k].type == 1163)
				{
					this.doubleJump3 = true;
					this.jumpBoost = true;
				}
				if (this.armor[k].type == 1724)
				{
					this.doubleJump4 = true;
				}
				if (this.armor[k].type == 1863)
				{
					this.doubleJump4 = true;
					this.jumpBoost = true;
				}
				if (this.armor[k].type == 1164)
				{
					this.doubleJump = true;
					this.doubleJump2 = true;
					this.doubleJump3 = true;
					this.jumpBoost = true;
				}
				if (this.armor[k].type == 1250)
				{
					this.jumpBoost = true;
					this.doubleJump = true;
					this.noFallDmg = true;
				}
				if (this.armor[k].type == 1252)
				{
					this.doubleJump2 = true;
					this.jumpBoost = true;
					this.noFallDmg = true;
				}
				if (this.armor[k].type == 1251)
				{
					this.doubleJump3 = true;
					this.jumpBoost = true;
					this.noFallDmg = true;
				}
				if (this.armor[k].type == 1249)
				{
					this.jumpBoost = true;
					this.bee = true;
				}
				if (this.armor[k].type == 1253 && (double)this.statLife <= (double)this.statLifeMax * 0.25)
				{
					this.AddBuff(62, 5, true);
				}
				if (this.armor[k].type == 1290)
				{
					this.panic = true;
				}
				if ((this.armor[k].type == 1300 || this.armor[k].type == 1858) && (this.inventory[this.selectedItem].useAmmo == 14 || this.inventory[this.selectedItem].useAmmo == 311 || this.inventory[this.selectedItem].useAmmo == 323))
				{
					this.scope = true;
				}
				if (this.armor[k].type == 1858)
				{
					this.rangedCrit += 10;
					this.rangedDamage += 0.1f;
				}
				if (this.armor[k].type == 1301)
				{
					this.meleeCrit += 8;
					this.rangedCrit += 8;
					this.magicCrit += 8;
					this.meleeDamage += 0.1f;
					this.rangedDamage += 0.1f;
					this.magicDamage += 0.1f;
					this.minionDamage += 0.1f;
				}
				if (this.armor[k].type == 982)
				{
					this.statManaMax2 += 20;
					this.manaRegenDelayBonus++;
					this.manaRegenBonus += 25;
				}
				if (this.armor[k].type == 1595)
				{
					this.statManaMax2 += 20;
					this.magicCuffs = true;
				}
				if (this.armor[k].type == 2219)
				{
					this.manaMagnet = true;
				}
				if (this.armor[k].type == 2220)
				{
					this.manaMagnet = true;
					this.magicDamage += 0.15f;
				}
				if (this.armor[k].type == 2221)
				{
					this.manaMagnet = true;
					this.magicCuffs = true;
				}
				if (this.armor[k].type == 1923)
				{
					Player.tileRangeX++;
					Player.tileRangeY++;
				}
				if (this.armor[k].type == 1247)
				{
					this.starCloak = true;
					this.bee = true;
				}
				if (this.armor[k].type == 1248)
				{
					this.meleeCrit += 10;
					this.rangedCrit += 10;
					this.magicCrit += 10;
				}
				if (this.armor[k].type == 854)
				{
					this.discount = true;
				}
				if (this.armor[k].type == 855)
				{
					this.coins = true;
				}
				if (this.armor[k].type == 53)
				{
					this.doubleJump = true;
				}
				if (this.armor[k].type == 54)
				{
					this.accRunSpeed = 6f;
				}
				if (this.armor[k].type == 1579)
				{
					this.accRunSpeed = 6f;
					this.coldDash = true;
				}
				if (this.armor[k].type == 128)
				{
					this.rocketBoots = 1;
				}
				if (this.armor[k].type == 156)
				{
					this.noKnockback = true;
				}
				if (this.armor[k].type == 158)
				{
					this.noFallDmg = true;
				}
				if (this.armor[k].type == 934)
				{
					this.carpet = true;
				}
				if (this.armor[k].type == 953)
				{
					this.spikedBoots++;
				}
				if (this.armor[k].type == 975)
				{
					this.spikedBoots++;
				}
				if (this.armor[k].type == 976)
				{
					this.spikedBoots += 2;
				}
				if (this.armor[k].type == 977)
				{
					this.dash = 1;
				}
				if (this.armor[k].type == 963)
				{
					this.blackBelt = true;
				}
				if (this.armor[k].type == 984)
				{
					this.blackBelt = true;
					this.dash = 1;
					this.spikedBoots = 2;
				}
				if (this.armor[k].type == 1131)
				{
					this.gravControl2 = true;
				}
				if (this.armor[k].type == 1132)
				{
					this.bee = true;
				}
				if (this.armor[k].type == 1578)
				{
					this.bee = true;
					this.panic = true;
				}
				if (this.armor[k].type == 950)
				{
					this.iceSkate = true;
				}
				if (this.armor[k].type == 159)
				{
					this.jumpBoost = true;
				}
				if (this.armor[k].type == 187)
				{
					this.accFlipper = true;
				}
				if (this.armor[k].type == 211)
				{
					this.meleeSpeed += 0.12f;
				}
				if (this.armor[k].type == 223)
				{
					this.manaCost -= 0.06f;
				}
				if (this.armor[k].type == 285)
				{
					this.moveSpeed += 0.05f;
				}
				if (this.armor[k].type == 212)
				{
					this.moveSpeed += 0.1f;
				}
				if (this.armor[k].type == 267)
				{
					this.killGuide = true;
				}
				if (this.armor[k].type == 1307)
				{
					this.killClothier = true;
				}
				if (this.armor[k].type == 193)
				{
					this.fireWalk = true;
				}
				if (this.armor[k].type == 861)
				{
					this.accMerman = true;
					this.wolfAcc = true;
				}
				if (this.armor[k].type == 862)
				{
					this.starCloak = true;
					this.longInvince = true;
				}
				if (this.armor[k].type == 860)
				{
					this.pStone = true;
				}
				if (this.armor[k].type == 863)
				{
					this.waterWalk2 = true;
				}
				if (this.armor[k].type == 907)
				{
					this.waterWalk2 = true;
					this.fireWalk = true;
				}
				if (this.armor[k].type == 908)
				{
					this.waterWalk = true;
					this.fireWalk = true;
					this.lavaMax += 420;
				}
				if (this.armor[k].type == 906)
				{
					this.lavaMax += 420;
				}
				if (this.armor[k].type == 485)
				{
					this.wolfAcc = true;
				}
				if (this.armor[k].type == 486)
				{
					this.rulerAcc = true;
				}
				if (this.armor[k].type == 393)
				{
					this.accCompass = 1;
				}
				if (this.armor[k].type == 394)
				{
					this.accFlipper = true;
					this.accDivingHelm = true;
				}
				if (this.armor[k].type == 395)
				{
					this.accWatch = 3;
					this.accDepthMeter = 1;
					this.accCompass = 1;
				}
				if (this.armor[k].type == 396)
				{
					this.noFallDmg = true;
					this.fireWalk = true;
				}
				if (this.armor[k].type == 397)
				{
					this.noKnockback = true;
					this.fireWalk = true;
				}
				if (this.armor[k].type == 399)
				{
					this.jumpBoost = true;
					this.doubleJump = true;
				}
				if (this.armor[k].type == 405)
				{
					this.accRunSpeed = 6f;
					this.rocketBoots = 2;
				}
				if (this.armor[k].type == 1860)
				{
					this.accFlipper = true;
					this.accDivingHelm = true;
				}
				if (this.armor[k].type == 1861)
				{
					this.accFlipper = true;
					this.accDivingHelm = true;
					this.iceSkate = true;
				}
				if (this.armor[k].type == 2214)
				{
					this.tileSpeed += 0.5f;
				}
				if (this.armor[k].type == 2215)
				{
					Player.tileRangeX += 3;
					Player.tileRangeY += 2;
				}
				if (this.armor[k].type == 2216)
				{
					this.autoPaint = true;
				}
				if (this.armor[k].type == 2217)
				{
					this.wallSpeed += 0.5f;
				}
				if (this.armor[k].type == 897)
				{
					this.kbGlove = true;
					this.meleeSpeed += 0.12f;
				}
				if (this.armor[k].type == 1343)
				{
					this.kbGlove = true;
					this.meleeSpeed += 0.09f;
					this.meleeDamage += 0.09f;
					this.magmaStone = true;
				}
				if (this.armor[k].type == 1167)
				{
					this.minionKB += 2f;
					this.minionDamage += 0.15f;
				}
				if (this.armor[k].type == 1864)
				{
					this.minionKB += 2f;
					this.minionDamage += 0.15f;
					this.maxMinions++;
				}
				if (this.armor[k].type == 1845)
				{
					this.minionDamage += 0.1f;
					this.maxMinions++;
				}
				if (this.armor[k].type == 1321)
				{
					this.magicQuiver = true;
					this.arrowDamage += 0.1f;
				}
				if (this.armor[k].type == 1322)
				{
					this.magmaStone = true;
				}
				if (this.armor[k].type == 1323)
				{
					this.lavaRose = true;
				}
				if (this.armor[k].type == 938)
				{
					this.noKnockback = true;
					if ((double)this.statLife > (double)this.statLifeMax * 0.25)
					{
						if (i == Main.myPlayer)
						{
							this.paladinGive = true;
						}
						else if (this.miscCounter % 5 == 0)
						{
							int myPlayer = Main.myPlayer;
							if (Main.player[myPlayer].team == this.team && this.team != 0)
							{
								float num = this.position.X - Main.player[myPlayer].position.X;
								float num2 = this.position.Y - Main.player[myPlayer].position.Y;
								float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
								if (num3 < 800f)
								{
									Main.player[myPlayer].AddBuff(43, 10, true);
								}
							}
						}
					}
				}
				if (this.armor[k].type == 936)
				{
					this.kbGlove = true;
					this.meleeSpeed += 0.12f;
					this.meleeDamage += 0.12f;
				}
				if (this.armor[k].type == 898)
				{
					this.accRunSpeed = 6.75f;
					this.rocketBoots = 2;
					this.moveSpeed += 0.08f;
				}
				if (this.armor[k].type == 1862)
				{
					this.accRunSpeed = 6.75f;
					this.rocketBoots = 3;
					this.moveSpeed += 0.08f;
					this.iceSkate = true;
				}
				if (this.armor[k].type == 1865)
				{
					this.lifeRegen += 2;
					this.statDefense += 4;
					this.meleeSpeed += 0.1f;
					this.meleeDamage += 0.1f;
					this.meleeCrit += 2;
					this.rangedDamage += 0.1f;
					this.rangedCrit += 2;
					this.magicDamage += 0.1f;
					this.magicCrit += 2;
					this.pickSpeed -= 0.15f;
					this.minionDamage += 0.1f;
					this.minionKB += 0.5f;
				}
				if (this.armor[k].type == 899 && Main.dayTime)
				{
					this.lifeRegen += 2;
					this.statDefense += 4;
					this.meleeSpeed += 0.1f;
					this.meleeDamage += 0.1f;
					this.meleeCrit += 2;
					this.rangedDamage += 0.1f;
					this.rangedCrit += 2;
					this.magicDamage += 0.1f;
					this.magicCrit += 2;
					this.pickSpeed -= 0.15f;
					this.minionDamage += 0.1f;
					this.minionKB += 0.5f;
				}
				if (this.armor[k].type == 900 && !Main.dayTime)
				{
					this.lifeRegen += 2;
					this.statDefense += 4;
					this.meleeSpeed += 0.1f;
					this.meleeDamage += 0.1f;
					this.meleeCrit += 2;
					this.rangedDamage += 0.1f;
					this.rangedCrit += 2;
					this.magicDamage += 0.1f;
					this.magicCrit += 2;
					this.pickSpeed -= 0.15f;
					this.minionDamage += 0.1f;
					this.minionKB += 0.5f;
				}
				if (this.armor[k].type == 407)
				{
					this.blockRange = 1;
				}
				if (this.armor[k].type == 489)
				{
					this.magicDamage += 0.15f;
				}
				if (this.armor[k].type == 490)
				{
					this.meleeDamage += 0.15f;
				}
				if (this.armor[k].type == 491)
				{
					this.rangedDamage += 0.15f;
				}
				if (this.armor[k].type == 935)
				{
					this.magicDamage += 0.12f;
					this.meleeDamage += 0.12f;
					this.rangedDamage += 0.12f;
					this.minionDamage += 0.12f;
				}
				if (this.armor[k].type == 492)
				{
					this.wingTimeMax = 100;
				}
				if (this.armor[k].type == 493)
				{
					this.wingTimeMax = 100;
				}
				if (this.armor[k].type == 665)
				{
					this.wingTimeMax = 220;
				}
				if (this.armor[k].type == 748)
				{
					this.wingTimeMax = 115;
				}
				if (this.armor[k].type == 749)
				{
					this.wingTimeMax = 130;
				}
				if (this.armor[k].type == 761)
				{
					this.wingTimeMax = 130;
				}
				if (this.armor[k].type == 785)
				{
					this.wingTimeMax = 140;
				}
				if (this.armor[k].type == 786)
				{
					this.wingTimeMax = 140;
				}
				if (this.armor[k].type == 821)
				{
					this.wingTimeMax = 160;
				}
				if (this.armor[k].type == 822)
				{
					this.wingTimeMax = 160;
				}
				if (this.armor[k].type == 823)
				{
					this.wingTimeMax = 160;
				}
				if (this.armor[k].type == 2280)
				{
					this.wingTimeMax = 160;
				}
				if (this.armor[k].type == 948)
				{
					this.wingTimeMax = 180;
				}
				if (this.armor[k].type == 1162)
				{
					this.wingTimeMax = 160;
				}
				if (this.armor[k].type == 1165)
				{
					this.wingTimeMax = 140;
				}
				if (this.armor[k].type == 1515)
				{
					this.wingTimeMax = 130;
				}
				if (this.armor[k].type == 1583)
				{
					this.wingTimeMax = 190;
				}
				if (this.armor[k].type == 1584)
				{
					this.wingTimeMax = 190;
				}
				if (this.armor[k].type == 1585)
				{
					this.wingTimeMax = 190;
				}
				if (this.armor[k].type == 1586)
				{
					this.wingTimeMax = 190;
				}
				if (this.armor[k].type == 1797)
				{
					this.wingTimeMax = 180;
				}
				if (this.armor[k].type == 1830)
				{
					this.wingTimeMax = 180;
				}
				if (this.armor[k].type == 1866)
				{
					this.wingTimeMax = 170;
				}
				if (this.armor[k].type == 1871)
				{
					this.wingTimeMax = 170;
				}
				if (this.armor[k].type == 885)
				{
					this.buffImmune[30] = true;
				}
				if (this.armor[k].type == 886)
				{
					this.buffImmune[36] = true;
				}
				if (this.armor[k].type == 887)
				{
					this.buffImmune[20] = true;
				}
				if (this.armor[k].type == 888)
				{
					this.buffImmune[22] = true;
				}
				if (this.armor[k].type == 889)
				{
					this.buffImmune[32] = true;
				}
				if (this.armor[k].type == 890)
				{
					this.buffImmune[35] = true;
				}
				if (this.armor[k].type == 891)
				{
					this.buffImmune[23] = true;
				}
				if (this.armor[k].type == 892)
				{
					this.buffImmune[33] = true;
				}
				if (this.armor[k].type == 893)
				{
					this.buffImmune[31] = true;
				}
				if (this.armor[k].type == 901)
				{
					this.buffImmune[33] = true;
					this.buffImmune[36] = true;
				}
				if (this.armor[k].type == 902)
				{
					this.buffImmune[30] = true;
					this.buffImmune[20] = true;
				}
				if (this.armor[k].type == 903)
				{
					this.buffImmune[32] = true;
					this.buffImmune[31] = true;
				}
				if (this.armor[k].type == 904)
				{
					this.buffImmune[35] = true;
					this.buffImmune[23] = true;
				}
				if (this.armor[k].type == 1921)
				{
					this.buffImmune[46] = true;
					this.buffImmune[47] = true;
				}
				if (this.armor[k].type == 1612)
				{
					this.buffImmune[33] = true;
					this.buffImmune[36] = true;
					this.buffImmune[30] = true;
					this.buffImmune[20] = true;
					this.buffImmune[32] = true;
					this.buffImmune[31] = true;
					this.buffImmune[35] = true;
					this.buffImmune[23] = true;
					this.buffImmune[22] = true;
				}
				if (this.armor[k].type == 1613)
				{
					this.noKnockback = true;
					this.fireWalk = true;
					this.buffImmune[33] = true;
					this.buffImmune[36] = true;
					this.buffImmune[30] = true;
					this.buffImmune[20] = true;
					this.buffImmune[32] = true;
					this.buffImmune[31] = true;
					this.buffImmune[35] = true;
					this.buffImmune[23] = true;
					this.buffImmune[22] = true;
				}
				if (this.armor[k].type == 497)
				{
					this.accMerman = true;
				}
				if (this.armor[k].type == 535)
				{
					this.pStone = true;
				}
				if (this.armor[k].type == 536)
				{
					this.kbGlove = true;
				}
				if (this.armor[k].type == 532)
				{
					this.starCloak = true;
				}
				if (this.armor[k].type == 554)
				{
					this.longInvince = true;
				}
				if (this.armor[k].type == 555)
				{
					this.manaFlower = true;
					this.manaCost -= 0.08f;
				}
				if (Main.myPlayer == this.whoAmi)
				{
					if (this.armor[k].type == 576 && Main.rand.Next(18000) == 0 && Main.curMusic > 0 && Main.curMusic <= 32)
					{
						int num4 = 0;
						if (Main.curMusic == 1)
						{
							num4 = 0;
						}
						if (Main.curMusic == 2)
						{
							num4 = 1;
						}
						if (Main.curMusic == 3)
						{
							num4 = 2;
						}
						if (Main.curMusic == 4)
						{
							num4 = 4;
						}
						if (Main.curMusic == 5)
						{
							num4 = 5;
						}
						if (Main.curMusic == 6)
						{
							num4 = 3;
						}
						if (Main.curMusic == 7)
						{
							num4 = 6;
						}
						if (Main.curMusic == 8)
						{
							num4 = 7;
						}
						if (Main.curMusic == 9)
						{
							num4 = 9;
						}
						if (Main.curMusic == 10)
						{
							num4 = 8;
						}
						if (Main.curMusic == 11)
						{
							num4 = 11;
						}
						if (Main.curMusic == 12)
						{
							num4 = 10;
						}
						if (Main.curMusic == 13)
						{
							num4 = 12;
						}
						if (Main.curMusic == 29)
						{
							this.armor[k].SetDefaults(1610, false);
						}
						else if (Main.curMusic == 30)
						{
							this.armor[k].SetDefaults(1963, false);
						}
						else if (Main.curMusic == 31)
						{
							this.armor[k].SetDefaults(1964, false);
						}
						else if (Main.curMusic == 32)
						{
							this.armor[k].SetDefaults(1965, false);
						}
						else if (Main.curMusic > 13)
						{
							this.armor[k].SetDefaults(1596 + Main.curMusic - 14, false);
						}
						else
						{
							this.armor[k].SetDefaults(num4 + 562, false);
						}
					}
					if (this.armor[k].type >= 562 && this.armor[k].type <= 574)
					{
						Main.musicBox2 = this.armor[k].type - 562;
					}
					if (this.armor[k].type >= 1596 && this.armor[k].type <= 1609)
					{
						Main.musicBox2 = this.armor[k].type - 1596 + 13;
					}
					if (this.armor[k].type == 1610)
					{
						Main.musicBox2 = 27;
					}
					if (this.armor[k].type == 1963)
					{
						Main.musicBox2 = 28;
					}
					if (this.armor[k].type == 1964)
					{
						Main.musicBox2 = 29;
					}
					if (this.armor[k].type == 1965)
					{
						Main.musicBox2 = 30;
					}
				}
			}
			for (int l = 3; l < 8; l++)
			{
				if (this.armor[l].wingSlot > 0)
				{
					if (!this.hideVisual[l] || this.velocity.Y != 0f)
					{
						this.wings = (int)this.armor[l].wingSlot;
					}
					this.wingsLogic = (int)this.armor[l].wingSlot;
				}
			}
			for (int m = 11; m < 16; m++)
			{
				if (this.armor[m].wingSlot > 0)
				{
					this.wings = (int)this.armor[m].wingSlot;
				}
			}
		}
		public void UpdatePlayerArmorSets(int i)
		{
			this.setBonus = "";
			if (this.body == 67 && this.legs == 56 && this.head >= 103 && this.head <= 105)
			{
				this.setBonus = Lang.setBonus(31, false);
				this.armorSteath = true;
			}
			if ((this.head == 52 && this.body == 32 && this.legs == 31) || (this.head == 53 && this.body == 33 && this.legs == 32) || (this.head == 54 && this.body == 34 && this.legs == 33) || (this.head == 55 && this.body == 35 && this.legs == 34) || (this.head == 70 && this.body == 46 && this.legs == 42) || (this.head == 71 && this.body == 47 && this.legs == 43))
			{
				this.setBonus = Lang.setBonus(20, false);
				this.statDefense++;
			}
			if ((this.head == 1 && this.body == 1 && this.legs == 1) || ((this.head == 72 || this.head == 2) && this.body == 2 && this.legs == 2) || (this.head == 47 && this.body == 28 && this.legs == 27))
			{
				this.setBonus = Lang.setBonus(0, false);
				this.statDefense += 2;
			}
			if ((this.head == 3 && this.body == 3 && this.legs == 3) || ((this.head == 73 || this.head == 4) && this.body == 4 && this.legs == 4) || (this.head == 48 && this.body == 29 && this.legs == 28) || (this.head == 49 && this.body == 30 && this.legs == 29))
			{
				this.setBonus = Lang.setBonus(1, false);
				this.statDefense += 3;
			}
			if (this.head == 50 && this.body == 31 && this.legs == 30)
			{
				this.setBonus = Lang.setBonus(32, false);
				this.statDefense += 4;
			}
			if (this.head == 112 && this.body == 75 && this.legs == 64)
			{
				this.setBonus = Lang.setBonus(33, false);
				this.meleeDamage += 0.1f;
				this.magicDamage += 0.1f;
				this.rangedDamage += 0.1f;
			}
			if (this.head == 157 && this.body == 105 && this.legs == 98)
			{
				int num = 0;
				this.setBonus = Lang.setBonus(38, false);
				this.beetleOffense = true;
				this.beetleCounter -= 3f;
				this.beetleCounter -= (float)(this.beetleCountdown / 10);
				this.beetleCountdown++;
				if (this.beetleCounter < 0f)
				{
					this.beetleCounter = 0f;
				}
				int num2 = 400;
				int num3 = 1200;
				int num4 = 4600;
				if (this.beetleCounter > (float)(num2 + num3 + num4 + num3))
				{
					this.beetleCounter = (float)(num2 + num3 + num4 + num3);
				}
				if (this.beetleCounter > (float)(num2 + num3 + num4))
				{
					this.AddBuff(100, 5, false);
					num = 3;
				}
				else if (this.beetleCounter > (float)(num2 + num3))
				{
					this.AddBuff(99, 5, false);
					num = 2;
				}
				else if (this.beetleCounter > (float)num2)
				{
					this.AddBuff(98, 5, false);
					num = 1;
				}
				if (num < this.beetleOrbs)
				{
					this.beetleCountdown = 0;
				}
				else if (num > this.beetleOrbs)
				{
					this.beetleCounter += 200f;
				}
				if (num != this.beetleOrbs && this.beetleOrbs > 0)
				{
					for (int j = 0; j < 22; j++)
					{
						if (this.buffType[j] >= 98 && this.buffType[j] <= 100 && this.buffType[j] != 97 + num)
						{
							this.DelBuff(j);
						}
					}
				}
			}
			else if (this.head == 157 && this.body == 106 && this.legs == 98)
			{
				this.setBonus = Lang.setBonus(37, false);
				this.beetleDefense = true;
				this.beetleCounter += 1f;
				int num5 = 180;
				if (this.beetleCounter >= (float)num5)
				{
					if (this.beetleOrbs > 0 && this.beetleOrbs < 3)
					{
						for (int k = 0; k < 22; k++)
						{
							if (this.buffType[k] >= 95 && this.buffType[k] <= 96)
							{
								this.DelBuff(k);
							}
						}
					}
					if (this.beetleOrbs < 3)
					{
						this.AddBuff(95 + this.beetleOrbs, 5, false);
						this.beetleCounter = 0f;
					}
					else
					{
						this.beetleCounter = (float)num5;
					}
				}
			}
			if (!this.beetleDefense && !this.beetleOffense)
			{
				this.beetleCounter = 0f;
			}
			else
			{
				this.beetleFrameCounter++;
				if (this.beetleFrameCounter >= 1)
				{
					this.beetleFrameCounter = 0;
					this.beetleFrame++;
					if (this.beetleFrame > 2)
					{
						this.beetleFrame = 0;
					}
				}
				for (int l = this.beetleOrbs; l < 3; l++)
				{
					this.beetlePos[l].X = 0f;
					this.beetlePos[l].Y = 0f;
				}
				for (int m = 0; m < this.beetleOrbs; m++)
				{
					this.beetlePos[m] += this.beetleVel[m];
					Vector2[] expr_61A_cp_0 = this.beetleVel;
					int expr_61A_cp_1 = m;
					expr_61A_cp_0[expr_61A_cp_1].X = expr_61A_cp_0[expr_61A_cp_1].X + (float)Main.rand.Next(-100, 101) * 0.005f;
					Vector2[] expr_648_cp_0 = this.beetleVel;
					int expr_648_cp_1 = m;
					expr_648_cp_0[expr_648_cp_1].Y = expr_648_cp_0[expr_648_cp_1].Y + (float)Main.rand.Next(-100, 101) * 0.005f;
					float num6 = this.beetlePos[m].X;
					float num7 = this.beetlePos[m].Y;
					float num8 = (float)Math.Sqrt((double)(num6 * num6 + num7 * num7));
					if (num8 > 100f)
					{
						num8 = 20f / num8;
						num6 *= -num8;
						num7 *= -num8;
						int num9 = 10;
						this.beetleVel[m].X = (this.beetleVel[m].X * (float)(num9 - 1) + num6) / (float)num9;
						this.beetleVel[m].Y = (this.beetleVel[m].Y * (float)(num9 - 1) + num7) / (float)num9;
					}
					else if (num8 > 30f)
					{
						num8 = 10f / num8;
						num6 *= -num8;
						num7 *= -num8;
						int num10 = 20;
						this.beetleVel[m].X = (this.beetleVel[m].X * (float)(num10 - 1) + num6) / (float)num10;
						this.beetleVel[m].Y = (this.beetleVel[m].Y * (float)(num10 - 1) + num7) / (float)num10;
					}
					num6 = this.beetleVel[m].X;
					num7 = this.beetleVel[m].Y;
					num8 = (float)Math.Sqrt((double)(num6 * num6 + num7 * num7));
					if (num8 > 2f)
					{
						this.beetleVel[m] *= 0.9f;
					}
					this.beetlePos[m] -= this.velocity * 0.25f;
				}
			}
			if (this.head == 14 && ((this.body >= 58 && this.body <= 63) || this.body == 167))
			{
				this.setBonus = Lang.setBonus(28, false);
				this.magicCrit += 10;
			}
			if (this.head == 159 && ((this.body >= 58 && this.body <= 63) || this.body == 167))
			{
				this.setBonus = Lang.setBonus(36, false);
				this.statManaMax2 += 60;
			}
			if ((this.head == 5 || this.head == 74) && (this.body == 5 || this.body == 48) && (this.legs == 5 || this.legs == 44))
			{
				this.setBonus = Lang.setBonus(2, false);
				this.moveSpeed += 0.15f;
			}
			if (this.head == 57 && this.body == 37 && this.legs == 35)
			{
				this.setBonus = Lang.setBonus(21, false);
				this.crimsonRegen = true;
			}
			if (this.head == 101 && this.body == 66 && this.legs == 55)
			{
				this.setBonus = Lang.setBonus(30, false);
				this.ghostHeal = true;
			}
			if (this.head == 156 && this.body == 66 && this.legs == 55)
			{
				this.setBonus = Lang.setBonus(35, false);
				this.ghostHurt = true;
			}
			if (this.head == 6 && this.body == 6 && this.legs == 6)
			{
				this.setBonus = Lang.setBonus(3, false);
				this.spaceGun = true;
			}
			if (this.head == 46 && this.body == 27 && this.legs == 26)
			{
				this.setBonus = Lang.setBonus(22, false);
				this.frostBurn = true;
			}
			if ((this.head == 75 || this.head == 7) && this.body == 7 && this.legs == 7)
			{
				this.boneArmor = true;
				this.setBonus = Lang.setBonus(4, false);
				this.ammoCost80 = true;
			}
			if ((this.head == 76 || this.head == 8) && (this.body == 49 || this.body == 8) && (this.legs == 45 || this.legs == 8))
			{
				this.setBonus = Lang.setBonus(5, false);
				this.manaCost -= 0.16f;
			}
			if (this.head == 9 && this.body == 9 && this.legs == 9)
			{
				this.setBonus = Lang.setBonus(6, false);
				this.meleeDamage += 0.17f;
			}
			if (this.head == 11 && this.body == 20 && this.legs == 19)
			{
				this.setBonus = Lang.setBonus(7, false);
				this.pickSpeed -= 0.3f;
			}
			if ((this.head == 78 || this.head == 79 || this.head == 80) && this.body == 51 && this.legs == 47)
			{
				this.setBonus = Lang.setBonus(27, false);
				this.AddBuff(60, 18000, true);
			}
			else if (this.crystalLeaf)
			{
				for (int n = 0; n < 22; n++)
				{
					if (this.buffType[n] == 60)
					{
						this.DelBuff(n);
					}
				}
			}
			if (this.head == 99 && this.body == 65 && this.legs == 54)
			{
				this.setBonus = Lang.setBonus(29, false);
				this.thorns = true;
				this.turtleThorns = true;
			}
			if (this.body == 17 && this.legs == 16)
			{
				if (this.head == 29)
				{
					this.setBonus = Lang.setBonus(8, false);
					this.manaCost -= 0.14f;
				}
				else if (this.head == 30)
				{
					this.setBonus = Lang.setBonus(9, false);
					this.meleeSpeed += 0.15f;
				}
				else if (this.head == 31)
				{
					this.setBonus = Lang.setBonus(10, false);
					this.ammoCost80 = true;
				}
			}
			if (this.body == 18 && this.legs == 17)
			{
				if (this.head == 32)
				{
					this.setBonus = Lang.setBonus(11, false);
					this.manaCost -= 0.17f;
				}
				else if (this.head == 33)
				{
					this.setBonus = Lang.setBonus(12, false);
					this.meleeCrit += 5;
				}
				else if (this.head == 34)
				{
					this.setBonus = Lang.setBonus(13, false);
					this.ammoCost80 = true;
				}
			}
			if (this.body == 19 && this.legs == 18)
			{
				if (this.head == 35)
				{
					this.setBonus = Lang.setBonus(14, false);
					this.manaCost -= 0.19f;
				}
				else if (this.head == 36)
				{
					this.setBonus = Lang.setBonus(15, false);
					this.meleeSpeed += 0.18f;
					this.moveSpeed += 0.18f;
				}
				else if (this.head == 37)
				{
					this.setBonus = Lang.setBonus(16, false);
					this.ammoCost75 = true;
				}
			}
			if (this.body == 54 && this.legs == 49 && (this.head == 83 || this.head == 84 || this.head == 85))
			{
				this.setBonus = Lang.setBonus(24, false);
				this.onHitRegen = true;
			}
			if (this.body == 55 && this.legs == 50 && (this.head == 86 || this.head == 87 || this.head == 88))
			{
				this.setBonus = Lang.setBonus(25, false);
				this.onHitPetal = true;
			}
			if (this.body == 56 && this.legs == 51 && (this.head == 89 || this.head == 90 || this.head == 91))
			{
				this.setBonus = Lang.setBonus(26, false);
				this.onHitDodge = true;
			}
			if (this.body == 24 && this.legs == 23)
			{
				if (this.head == 42)
				{
					this.setBonus = Lang.setBonus(17, false);
					this.manaCost -= 0.2f;
				}
				else if (this.head == 43)
				{
					this.setBonus = Lang.setBonus(18, false);
					this.meleeSpeed += 0.19f;
					this.moveSpeed += 0.19f;
				}
				else if (this.head == 41)
				{
					this.setBonus = Lang.setBonus(19, false);
					this.ammoCost75 = true;
				}
			}
			if (this.head == 82 && this.body == 53 && this.legs == 48)
			{
				this.setBonus = Lang.setBonus(23, false);
				this.maxMinions++;
			}
			if (this.head == 134 && this.body == 95 && this.legs == 79)
			{
				this.setBonus = Lang.setBonus(34, false);
				this.minionDamage += 0.25f;
			}
		}
		public void UpdatePlayer(int i)
		{
			if (this.launcherWait > 0)
			{
				this.launcherWait--;
			}
			float num = 10f;
			float num2 = 0.4f;
			Player.jumpHeight = 15;
			Player.jumpSpeed = 5.01f;
			if (this.wet)
			{
				if (this.honeyWet)
				{
					num2 = 0.1f;
					num = 3f;
				}
				else if (this.merman)
				{
					num2 = 0.3f;
					num = 7f;
				}
				else
				{
					num2 = 0.2f;
					num = 5f;
					Player.jumpHeight = 30;
					Player.jumpSpeed = 6.01f;
				}
			}
			float num3 = 3f;
			float num4 = 0.08f;
			float num5 = 0.2f;
			this.accRunSpeed = num3;
			this.heldProj = -1;
			bool flag = false;
			if (this.active)
			{
				if (this.ghostDmg > 0f)
				{
					this.ghostDmg -= 1.66666663f;
				}
				if (this.ghostDmg < 0f)
				{
					this.ghostDmg = 0f;
				}
				if (this.lifeSteal < 80f)
				{
					this.lifeSteal += 0.6f;
				}
				if (this.lifeSteal > 80f)
				{
					this.lifeSteal = 80f;
				}
				if (this.mount == 1)
				{
					this.position.Y = this.position.Y + (float)this.height;
					this.height = 62;
					this.position.Y = this.position.Y - (float)this.height;
					int num6 = (int)(this.position.X + (float)(this.width / 2)) / 16;
					int j = (int)(this.position.Y + (float)(this.height / 2) - 14f) / 16;
				}
				else
				{
					this.position.Y = this.position.Y + (float)this.height;
					this.height = 42;
					this.position.Y = this.position.Y - (float)this.height;
				}
				Main.numPlayers++;
				this.outOfRange = false;
				if (this.whoAmi != Main.myPlayer)
				{
					int num7 = (int)(this.position.X + (float)(this.width / 2)) / 16;
					int num8 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
					if (Main.tile[num7, num8] == null)
					{
						flag = true;
					}
					else if (Main.tile[num7 - 3, num8] == null)
					{
						flag = true;
					}
					else if (Main.tile[num7 + 3, num8] == null)
					{
						flag = true;
					}
					else if (Main.tile[num7, num8 - 3] == null)
					{
						flag = true;
					}
					else if (Main.tile[num7, num8 + 3] == null)
					{
						flag = true;
					}
					if (flag)
					{
						this.outOfRange = true;
						this.numMinions = 0;
						this.itemAnimation = 0;
						this.PlayerFrame();
					}
				}
			}
			if (this.active && !flag)
			{
				this.miscCounter++;
				if (this.miscCounter >= 300)
				{
					this.miscCounter = 0;
				}
				float num9 = (float)(Main.maxTilesX / 4200);
				num9 *= num9;
				float num10 = (float)((double)(this.position.Y / 16f - (60f + 10f * num9)) / (Main.worldSurface / 6.0));
				if ((double)num10 < 0.25)
				{
					num10 = 0.25f;
				}
				if (num10 > 1f)
				{
					num10 = 1f;
				}
				num2 *= num10;
				this.maxRegenDelay = (1f - (float)this.statMana / (float)this.statManaMax2) * 60f * 4f + 45f;
				this.maxRegenDelay *= 0.7f;
				this.shadowCount++;
				if (this.shadowCount == 1)
				{
					this.shadowPos[2] = this.shadowPos[1];
				}
				else if (this.shadowCount == 2)
				{
					this.shadowPos[1] = this.shadowPos[0];
				}
				else if (this.shadowCount >= 3)
				{
					this.shadowCount = 0;
					this.shadowPos[0] = this.position;
					Vector2[] expr_4A0_cp_0 = this.shadowPos;
					int expr_4A0_cp_1 = 0;
					expr_4A0_cp_0[expr_4A0_cp_1].Y = expr_4A0_cp_0[expr_4A0_cp_1].Y + this.gfxOffY;
				}
				if (this.teleportTime > 0f)
				{
					if (this.teleportStyle == 1)
					{
						if ((float)Main.rand.Next(100) <= 100f * this.teleportTime)
						{
							int num11 = Dust.NewDust(new Vector2((float)this.getRect().X, (float)this.getRect().Y), this.getRect().Width, this.getRect().Height, 164, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num11].scale = this.teleportTime * 1.5f;
							Main.dust[num11].noGravity = true;
							Main.dust[num11].velocity *= 1.1f;
						}
					}
					else if ((float)Main.rand.Next(100) <= 100f * this.teleportTime * 2f)
					{
						int num12 = Dust.NewDust(new Vector2((float)this.getRect().X, (float)this.getRect().Y), this.getRect().Width, this.getRect().Height, 159, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num12].scale = this.teleportTime * 1.5f;
						Main.dust[num12].noGravity = true;
						Main.dust[num12].velocity *= 1.1f;
					}
					this.teleportTime -= 0.005f;
				}
				this.whoAmi = i;
				if (this.runSoundDelay > 0)
				{
					this.runSoundDelay--;
				}
				if (this.attackCD > 0)
				{
					this.attackCD--;
				}
				if (this.itemAnimation == 0)
				{
					this.attackCD = 0;
				}
				if (this.chatShowTime > 0)
				{
					this.chatShowTime--;
				}
				if (this.potionDelay > 0)
				{
					this.potionDelay--;
				}
				if (i == Main.myPlayer)
				{
					if (Main.trashItem.type >= 1522 && Main.trashItem.type <= 1527)
					{
						Main.trashItem.SetDefaults(0, false);
					}
					this.zoneEvil = false;
					if (Main.evilTiles >= 200)
					{
						this.zoneEvil = true;
					}
					this.zoneHoly = false;
					if (Main.holyTiles >= 100)
					{
						this.zoneHoly = true;
					}
					this.zoneMeteor = false;
					if (Main.meteorTiles >= 50)
					{
						this.zoneMeteor = true;
					}
					this.zoneDungeon = false;
					if (Main.dungeonTiles >= 250 && (double)this.position.Y > Main.worldSurface * 16.0)
					{
						int num13 = (int)this.position.X / 16;
						int num14 = (int)this.position.Y / 16;
						if (Main.wallDungeon[(int)Main.tile[num13, num14].wall])
						{
							this.zoneDungeon = true;
						}
					}
					this.zoneJungle = false;
					if (Main.jungleTiles >= 80)
					{
						this.zoneJungle = true;
					}
					this.zoneSnow = false;
					if (Main.snowTiles >= 300)
					{
						this.zoneSnow = true;
					}
					this.zoneBlood = false;
					if (Main.bloodTiles >= 200)
					{
						this.zoneBlood = true;
					}
					if (Main.waterCandles > 0)
					{
						this.zoneCandle = true;
					}
					else
					{
						this.zoneCandle = false;
					}
				}
				if (this.ghost)
				{
					this.Ghost();
					return;
				}
				if (this.dead)
				{
					this.gem = -1;
					this.slippy = false;
					this.slippy2 = false;
					this.powerrun = false;
					this.wings = 0;
					this.wingsLogic = 0;
					this.face = (this.neck = (this.back = (this.front = (this.handoff = (this.handon = (this.shoe = (this.waist = (this.balloon = (this.shield = 0)))))))));
					this.poisoned = false;
					this.venom = false;
					this.onFire = false;
					this.dripping = false;
					this.burned = false;
					this.suffocating = false;
					this.onFire2 = false;
					this.onFrostBurn = false;
					this.blind = false;
					this.blackout = false;
					this.gravDir = 1f;
					for (int k = 0; k < 22; k++)
					{
						this.buffTime[k] = 0;
						this.buffType[k] = 0;
					}
					if (i == Main.myPlayer)
					{
						Main.npcChatText = "";
						Main.editSign = false;
					}
					this.grappling[0] = -1;
					this.grappling[1] = -1;
					this.grappling[2] = -1;
					this.sign = -1;
					this.talkNPC = -1;
					this.statLife = 0;
					this.channel = false;
					this.potionDelay = 0;
					this.chest = -1;
					this.changeItem = -1;
					this.itemAnimation = 0;
					this.immuneAlpha += 2;
					if (this.immuneAlpha > 255)
					{
						this.immuneAlpha = 255;
					}
					this.headPosition += this.headVelocity;
					this.bodyPosition += this.bodyVelocity;
					this.legPosition += this.legVelocity;
					this.headRotation += this.headVelocity.X * 0.1f;
					this.bodyRotation += this.bodyVelocity.X * 0.1f;
					this.legRotation += this.legVelocity.X * 0.1f;
					this.headVelocity.Y = this.headVelocity.Y + 0.1f;
					this.bodyVelocity.Y = this.bodyVelocity.Y + 0.1f;
					this.legVelocity.Y = this.legVelocity.Y + 0.1f;
					this.headVelocity.X = this.headVelocity.X * 0.99f;
					this.bodyVelocity.X = this.bodyVelocity.X * 0.99f;
					this.legVelocity.X = this.legVelocity.X * 0.99f;
					if (this.difficulty == 2)
					{
						if (this.respawnTimer > 0)
						{
							this.respawnTimer--;
							return;
						}
						if (this.whoAmi == Main.myPlayer || Main.netMode == 2)
						{
							this.ghost = true;
							return;
						}
					}
					else
					{
						this.respawnTimer--;
						if (this.respawnTimer <= 0 && Main.myPlayer == this.whoAmi)
						{
							if (Main.mouseItem.type > 0)
							{
								Main.playerInventory = true;
							}
							this.Spawn();
							return;
						}
					}
				}
				else
				{
					if (this.mouseInterface)
					{
						this.delayUseItem = true;
					}
					Player.tileTargetX = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
					Player.tileTargetY = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
					if (Player.tileTargetX >= Main.maxTilesX)
					{
						Player.tileTargetX = Main.maxTilesX - 5;
					}
					if (Player.tileTargetY >= Main.maxTilesY)
					{
						Player.tileTargetY = Main.maxTilesY - 5;
					}
					if (this.gravDir == -1f)
					{
						Player.tileTargetY = (int)((Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16f);
					}
					if (this.immune)
					{
						this.immuneTime--;
						if (this.immuneTime <= 0)
						{
							this.immune = false;
						}
						this.immuneAlpha += this.immuneAlphaDirection * 50;
						if (this.immuneAlpha <= 50)
						{
							this.immuneAlphaDirection = 1;
						}
						else if (this.immuneAlpha >= 205)
						{
							this.immuneAlphaDirection = -1;
						}
					}
					else
					{
						this.immuneAlpha = 0;
					}
					if (this.petalTimer > 0)
					{
						this.petalTimer--;
					}
					if (this.shadowDodgeTimer > 0)
					{
						this.shadowDodgeTimer--;
					}
					if (this.jump > 0 || this.velocity.Y != 0f)
					{
						this.slippy = false;
						this.slippy2 = false;
						this.powerrun = false;
						this.sticky = false;
					}
					this.potionDelayTime = Item.potionDelay;
					if (this.pStone)
					{
						this.potionDelayTime -= 900;
					}
					this.armorSteath = false;
					this.statDefense = 0;
					this.accWatch = 0;
					this.accCompass = 0;
					this.accDepthMeter = 0;
					this.accDivingHelm = false;
					this.lifeRegen = 0;
					this.manaCost = 1f;
					this.meleeSpeed = 1f;
					this.meleeDamage = 1f;
					this.rangedDamage = 1f;
					this.magicDamage = 1f;
					this.minionDamage = 1f;
					this.minionKB = 0f;
					this.moveSpeed = 1f;
					this.boneArmor = false;
					this.honey = false;
					this.frostArmor = false;
					this.rocketBoots = 0;
					this.fireWalk = false;
					this.noKnockback = false;
					this.jumpBoost = false;
					this.noFallDmg = false;
					this.accFlipper = false;
					this.spawnMax = false;
					this.spaceGun = false;
					this.killGuide = false;
					this.killClothier = false;
					this.lavaImmune = false;
					this.gills = false;
					this.slowFall = false;
					this.findTreasure = false;
					this.invis = false;
					this.nightVision = false;
					this.enemySpawns = false;
					this.thorns = false;
					this.aggro = 0;
					this.waterWalk = false;
					this.waterWalk2 = false;
					this.detectCreature = false;
					this.gravControl = false;
					this.bee = false;
					this.gravControl2 = false;
					this.statManaMax2 = this.statManaMax;
					this.ammoCost80 = false;
					this.ammoCost75 = false;
					this.manaRegenBuff = false;
					this.meleeCrit = 4;
					this.rangedCrit = 4;
					this.magicCrit = 4;
					this.arrowDamage = 1f;
					this.bulletDamage = 1f;
					this.rocketDamage = 1f;
					this.lightOrb = false;
					this.blueFairy = false;
					this.redFairy = false;
					this.greenFairy = false;
					this.wisp = false;
					this.bunny = false;
					this.turtle = false;
					this.eater = false;
					this.skeletron = false;
					this.hornet = false;
					this.tiki = false;
					this.lizard = false;
					this.parrot = false;
					this.sapling = false;
					this.cSapling = false;
					this.truffle = false;
					this.shadowDodge = false;
					this.palladiumRegen = false;
					this.chaosState = false;
					this.onHitDodge = false;
					this.onHitRegen = false;
					this.onHitPetal = false;
					this.iceBarrier = false;
					this.maxMinions = 1;
					this.ammoBox = false;
					this.penguin = false;
					this.manaMagnet = false;
					this.beetleOrbs = 0;
					this.beetleBuff = false;
					this.wallSpeed = 1f;
					this.tileSpeed = 1f;
					this.autoPaint = false;
					this.manaSick = false;
					this.puppy = false;
					this.grinch = false;
					this.blackCat = false;
					this.spider = false;
					this.squashling = false;
					this.magicCuffs = false;
					this.coldDash = false;
					this.magicQuiver = false;
					this.magmaStone = false;
					this.lavaRose = false;
					this.eyeSpring = false;
					this.snowman = false;
					this.scope = false;
					this.panic = false;
					this.dino = false;
					this.crystalLeaf = false;
					this.pygmy = false;
					this.raven = false;
					this.slime = false;
					this.chilled = false;
					this.frozen = false;
					this.ichor = false;
					this.manaRegenBonus = 0;
					this.manaRegenDelayBonus = 0;
					this.carpet = false;
					this.iceSkate = false;
					this.dash = 0;
					this.spikedBoots = 0;
					this.blackBelt = false;
					this.lavaMax = 0;
					this.archery = false;
					this.poisoned = false;
					this.venom = false;
					this.blind = false;
					this.blackout = false;
					this.onFire = false;
					this.dripping = false;
					this.burned = false;
					this.suffocating = false;
					this.onFire2 = false;
					this.onFrostBurn = false;
					this.frostBurn = false;
					this.noItems = false;
					this.blockRange = 0;
					this.pickSpeed = 1f;
					this.wereWolf = false;
					this.rulerAcc = false;
					this.bleed = false;
					this.confused = false;
					this.wings = 0;
					this.wingsLogic = 0;
					this.wingTimeMax = 0;
					this.brokenArmor = false;
					this.silence = false;
					this.slow = false;
					this.gross = false;
					this.tongued = false;
					this.kbGlove = false;
					this.starCloak = false;
					this.longInvince = false;
					this.pStone = false;
					this.manaFlower = false;
					this.crimsonRegen = false;
					this.ghostHeal = false;
					this.ghostHurt = false;
					this.turtleArmor = false;
					this.turtleThorns = false;
					this.meleeEnchant = 0;
					this.discount = false;
					this.coins = false;
					this.doubleJump2 = false;
					this.doubleJump3 = false;
					this.doubleJump4 = false;
					this.paladinBuff = false;
					this.paladinGive = false;
					this.meleeCrit += this.inventory[this.selectedItem].crit;
					this.magicCrit += this.inventory[this.selectedItem].crit;
					this.rangedCrit += this.inventory[this.selectedItem].crit;
					Player.tileRangeX = 5;
					Player.tileRangeY = 4;
					this.mount = 0;
					if (this.whoAmi == Main.myPlayer)
					{
						Main.musicBox2 = -1;
						if (Main.waterCandles > 0)
						{
							this.AddBuff(86, 2, false);
						}
						if (Main.campfire)
						{
							this.AddBuff(87, 2, false);
						}
						if (Main.heartLantern)
						{
							this.AddBuff(89, 2, false);
						}
					}
					for (int num33 = 0; num33 < 104; num33++)
					{
						this.buffImmune[num33] = false;
					}
					this.UpdatePlayerBuffs(i);
					if (this.accMerman && this.wet && !this.lavaWet)
					{
						this.releaseJump = true;
						this.wings = 0;
						this.wingsLogic = 0;
						this.merman = true;
						this.accFlipper = true;
						this.AddBuff(34, 2, true);
					}
					else
					{
						this.merman = false;
					}
					this.accMerman = false;
					if (this.wolfAcc && !this.merman && !Main.dayTime && !this.wereWolf)
					{
						this.AddBuff(28, 60, true);
					}
					this.wolfAcc = false;
					if (this.whoAmi == Main.myPlayer)
					{
						for (int num34 = 0; num34 < 22; num34++)
						{
							if (this.buffType[num34] > 0 && this.buffTime[num34] <= 0)
							{
								this.DelBuff(num34);
							}
						}
					}
					this.beetleDefense = false;
					this.beetleOffense = false;
					this.doubleJump = false;
					this.head = this.armor[0].headSlot;
					this.body = this.armor[1].bodySlot;
					this.legs = this.armor[2].legSlot;
					this.handon = -1;
					this.handoff = -1;
					this.back = -1;
					this.front = -1;
					this.shoe = -1;
					this.waist = -1;
					this.shield = -1;
					this.neck = -1;
					this.face = -1;
					this.balloon = -1;
					this.UpdatePlayerEquips(i);
					this.gemCount++;
					if (this.gemCount >= 10)
					{
						this.gem = -1;
						this.gemCount = 0;
						for (int num35 = 0; num35 <= 58; num35++)
						{
							if (this.inventory[num35].type == 0 || this.inventory[num35].stack == 0)
							{
								this.inventory[num35].type = 0;
								this.inventory[num35].stack = 0;
								this.inventory[num35].name = "";
								this.inventory[num35].netID = 0;
							}
							if (this.inventory[num35].type >= 1522 && this.inventory[num35].type <= 1527)
							{
								this.gem = this.inventory[num35].type - 1522;
							}
						}
					}
					this.UpdatePlayerArmorSets(i);
					if (this.merman)
					{
						this.wings = 0;
						this.wingsLogic = 0;
					}
					if (this.armorSteath)
					{
						if (this.itemAnimation > 0)
						{
							this.stealthTimer = 5;
						}
						if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1 && (double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1)
						{
							if (this.stealthTimer == 0)
							{
								this.stealth -= 0.015f;
								if ((double)this.stealth < 0.0)
								{
									this.stealth = 0f;
								}
							}
						}
						else
						{
							float num36 = Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y);
							this.stealth += num36 * 0.0075f;
							if (this.stealth > 1f)
							{
								this.stealth = 1f;
							}
						}
						this.rangedDamage += (1f - this.stealth) * 0.6f;
						this.rangedCrit += (int)((1f - this.stealth) * 10f);
						this.aggro -= (int)((1f - this.stealth) * 750f);
						if (this.stealthTimer > 0)
						{
							this.stealthTimer--;
						}
					}
					else
					{
						this.stealth = 1f;
					}
					if (this.manaSick)
					{
						this.magicDamage *= 1f - this.manaSickReduction;
					}
					if (this.inventory[this.selectedItem].type == 1947)
					{
						this.meleeSpeed = (1f + this.meleeSpeed) / 2f;
					}
					if ((double)this.pickSpeed < 0.3)
					{
						this.pickSpeed = 0.3f;
					}
					if (this.meleeSpeed > 3f)
					{
						this.meleeSpeed = 3f;
					}
					if ((double)this.moveSpeed > 1.6)
					{
						this.moveSpeed = 1.6f;
					}
					if (this.tileSpeed > 3f)
					{
						this.tileSpeed = 3f;
					}
					this.tileSpeed = 1f / this.tileSpeed;
					if (this.wallSpeed > 3f)
					{
						this.wallSpeed = 3f;
					}
					this.wallSpeed = 1f / this.wallSpeed;
					if (this.slow)
					{
						this.moveSpeed *= 0.5f;
					}
					if (this.chilled)
					{
						this.moveSpeed *= 0.75f;
					}
					if (this.statManaMax2 > 400)
					{
						this.statManaMax2 = 400;
					}
					if (this.statDefense < 0)
					{
						this.statDefense = 0;
					}
					this.meleeSpeed = 1f / this.meleeSpeed;
					if (this.poisoned)
					{
						if (this.lifeRegen > 0)
						{
							this.lifeRegen = 0;
						}
						this.lifeRegenTime = 0;
						this.lifeRegen -= 4;
					}
					else if (this.venom)
					{
						if (this.lifeRegen > 0)
						{
							this.lifeRegen = 0;
						}
						this.lifeRegenTime = 0;
						this.lifeRegen -= 12;
					}
					if (this.onFire)
					{
						if (this.lifeRegen > 0)
						{
							this.lifeRegen = 0;
						}
						this.lifeRegenTime = 0;
						this.lifeRegen -= 8;
					}
					if (this.onFrostBurn)
					{
						if (this.lifeRegen > 0)
						{
							this.lifeRegen = 0;
						}
						this.lifeRegenTime = 0;
						this.lifeRegen -= 12;
					}
					if (this.onFire2)
					{
						if (this.lifeRegen > 0)
						{
							this.lifeRegen = 0;
						}
						this.lifeRegenTime = 0;
						this.lifeRegen -= 12;
					}
					if (this.burned)
					{
						if (this.lifeRegen > 0)
						{
							this.lifeRegen = 0;
						}
						this.lifeRegenTime = 0;
						this.lifeRegen -= 60;
						this.moveSpeed *= 0.5f;
					}
					if (this.suffocating)
					{
						if (this.lifeRegen > 0)
						{
							this.lifeRegen = 0;
						}
						this.lifeRegenTime = 0;
						this.lifeRegen -= 40;
					}
					this.lifeRegenTime++;
					if (this.crimsonRegen)
					{
						this.lifeRegenTime++;
					}
					if (this.honey)
					{
						this.lifeRegenTime += 2;
						this.lifeRegen += 2;
					}
					if (this.whoAmi == Main.myPlayer && Main.campfire)
					{
						this.lifeRegen++;
					}
					if (this.whoAmi == Main.myPlayer && Main.heartLantern)
					{
						this.lifeRegen += 2;
					}
					if (this.bleed)
					{
						this.lifeRegenTime = 0;
					}
					float num37 = 0f;
					if (this.lifeRegenTime >= 300)
					{
						num37 += 1f;
					}
					if (this.lifeRegenTime >= 600)
					{
						num37 += 1f;
					}
					if (this.lifeRegenTime >= 900)
					{
						num37 += 1f;
					}
					if (this.lifeRegenTime >= 1200)
					{
						num37 += 1f;
					}
					if (this.lifeRegenTime >= 1500)
					{
						num37 += 1f;
					}
					if (this.lifeRegenTime >= 1800)
					{
						num37 += 1f;
					}
					if (this.lifeRegenTime >= 2400)
					{
						num37 += 1f;
					}
					if (this.lifeRegenTime >= 3000)
					{
						num37 += 1f;
					}
					if (this.lifeRegenTime >= 3600)
					{
						num37 += 1f;
						this.lifeRegenTime = 3600;
					}
					if (this.velocity.X == 0f || this.grappling[0] > 0)
					{
						num37 *= 1.25f;
					}
					else
					{
						num37 *= 0.5f;
					}
					if (this.crimsonRegen)
					{
						num37 *= 1.5f;
					}
					if (this.whoAmi == Main.myPlayer && Main.campfire)
					{
						num37 *= 1.1f;
					}
					float num38 = (float)this.statLifeMax / 400f * 0.85f + 0.15f;
					num37 *= num38;
					this.lifeRegen += (int)Math.Round((double)num37);
					this.lifeRegenCount += this.lifeRegen;
					if (this.palladiumRegen)
					{
						this.lifeRegenCount += 6;
					}
					while (this.lifeRegenCount >= 120)
					{
						this.lifeRegenCount -= 120;
						if (this.statLife < this.statLifeMax)
						{
							this.statLife++;
							if (this.crimsonRegen)
							{
								for (int num39 = 0; num39 < 10; num39++)
								{
									int num40 = Dust.NewDust(this.position, this.width, this.height, 5, 0f, 0f, 175, default(Color), 1.75f);
									Main.dust[num40].noGravity = true;
									Main.dust[num40].velocity *= 0.75f;
									int num41 = Main.rand.Next(-40, 41);
									int num42 = Main.rand.Next(-40, 41);
									Dust expr_3227_cp_0 = Main.dust[num40];
									expr_3227_cp_0.position.X = expr_3227_cp_0.position.X + (float)num41;
									Dust expr_3243_cp_0 = Main.dust[num40];
									expr_3243_cp_0.position.Y = expr_3243_cp_0.position.Y + (float)num42;
									Main.dust[num40].velocity.X = (float)(-(float)num41) * 0.075f;
									Main.dust[num40].velocity.Y = (float)(-(float)num42) * 0.075f;
								}
							}
						}
						if (this.statLife > this.statLifeMax)
						{
							this.statLife = this.statLifeMax;
						}
					}
					if (!this.burned)
					{
						if (!this.suffocating)
						{
							while (this.lifeRegenCount <= -120)
							{
								if (this.lifeRegenCount <= -480)
								{
									this.lifeRegenCount += 480;
									this.statLife -= 4;
								}
								else if (this.lifeRegenCount <= -360)
								{
									this.lifeRegenCount += 360;
									this.statLife -= 3;
								}
								else if (this.lifeRegenCount <= -240)
								{
									this.lifeRegenCount += 240;
									this.statLife -= 2;
								}
								else
								{
									this.lifeRegenCount += 120;
									this.statLife--;
								}
								if (this.statLife <= 0 && this.whoAmi == Main.myPlayer)
								{
									if (this.poisoned || this.venom)
									{
										this.KillMe(10.0, 0, false, " " + Lang.dt[0]);
									}
									else
									{
										this.KillMe(10.0, 0, false, " " + Lang.dt[1]);
									}
								}
							}
							goto IL_3623;
						}
					}
					while (this.lifeRegenCount <= -600)
					{
						this.lifeRegenCount += 600;
						this.statLife -= 5;
						if (this.statLife <= 0 && this.whoAmi == Main.myPlayer)
						{
							if (this.suffocating)
							{
								this.KillMe(10.0, 0, false, " " + Lang.dt[2]);
							}
							else
							{
								this.KillMe(10.0, 0, false, " " + Lang.dt[1]);
							}
						}
					}
					IL_3623:
					if (this.manaRegenDelay > 0)
					{
						this.manaRegenDelay--;
						this.manaRegenDelay -= this.manaRegenDelayBonus;
						if ((this.velocity.X == 0f && this.velocity.Y == 0f) || this.grappling[0] >= 0 || this.manaRegenBuff)
						{
							this.manaRegenDelay--;
						}
					}
					if (this.manaRegenBuff && this.manaRegenDelay > 20)
					{
						this.manaRegenDelay = 20;
					}
					if (this.manaRegenDelay <= 0)
					{
						this.manaRegenDelay = 0;
						this.manaRegen = this.statManaMax2 / 7 + 1 + this.manaRegenBonus;
						if ((this.velocity.X == 0f && this.velocity.Y == 0f) || this.grappling[0] >= 0 || this.manaRegenBuff)
						{
							this.manaRegen += this.statManaMax2 / 2;
						}
						float num43 = (float)this.statMana / (float)this.statManaMax2 * 0.8f + 0.2f;
						if (this.manaRegenBuff)
						{
							num43 = 1f;
						}
						this.manaRegen = (int)((double)((float)this.manaRegen * num43) * 1.15);
					}
					else
					{
						this.manaRegen = 0;
					}
					this.manaRegenCount += this.manaRegen;
					while (this.manaRegenCount >= 120)
					{
						bool flag10 = false;
						this.manaRegenCount -= 120;
						if (this.statMana < this.statManaMax2)
						{
							this.statMana++;
							flag10 = true;
						}
						if (this.statMana >= this.statManaMax2)
						{
							if (this.whoAmi == Main.myPlayer && flag10)
							{
								Main.PlaySound(25, -1, -1, 1);
								for (int num44 = 0; num44 < 5; num44++)
								{
									int num45 = Dust.NewDust(this.position, this.width, this.height, 45, 0f, 0f, 255, default(Color), (float)Main.rand.Next(20, 26) * 0.1f);
									Main.dust[num45].noLight = true;
									Main.dust[num45].noGravity = true;
									Main.dust[num45].velocity *= 0.5f;
								}
							}
							this.statMana = this.statManaMax2;
						}
					}
					if (this.manaRegenCount < 0)
					{
						this.manaRegenCount = 0;
					}
					if (this.statMana > this.statManaMax2)
					{
						this.statMana = this.statManaMax2;
					}
					num4 *= this.moveSpeed;
					num3 *= this.moveSpeed;
					if (this.mount == 1)
					{
						Player.jumpHeight = 17 + (int)(Math.Abs(this.velocity.X) / 4f);
						Player.jumpSpeed = 5.31f + Math.Abs(this.velocity.X) / 3f;
					}
					else
					{
						if (this.jumpBoost)
						{
							Player.jumpHeight = 20;
							Player.jumpSpeed = 6.51f;
						}
						if (this.wereWolf)
						{
							Player.jumpHeight += 2;
							Player.jumpSpeed += 0.2f;
						}
					}
					if (this.sticky)
					{
						Player.jumpHeight /= 10;
						Player.jumpSpeed /= 5f;
					}
					for (int num46 = 0; num46 < 22; num46++)
					{
						if (this.buffType[num46] > 0 && this.buffTime[num46] > 0 && this.buffImmune[this.buffType[num46]])
						{
							this.DelBuff(num46);
						}
					}
					if (this.brokenArmor)
					{
						this.statDefense /= 2;
					}
					if (!this.doubleJump)
					{
						this.jumpAgain = false;
					}
					else if (this.velocity.Y == 0f || this.sliding)
					{
						this.jumpAgain = true;
					}
					if (!this.doubleJump2)
					{
						this.jumpAgain2 = false;
					}
					else if (this.velocity.Y == 0f || this.sliding)
					{
						this.jumpAgain2 = true;
					}
					if (!this.doubleJump3)
					{
						this.jumpAgain3 = false;
					}
					else if (this.velocity.Y == 0f || this.sliding)
					{
						this.jumpAgain3 = true;
					}
					if (!this.doubleJump4)
					{
						this.jumpAgain4 = false;
					}
					else if (this.velocity.Y == 0f || this.sliding)
					{
						this.jumpAgain4 = true;
					}
					if (!this.carpet)
					{
						this.canCarpet = false;
						this.carpetFrame = -1;
					}
					else if (this.velocity.Y == 0f || this.sliding)
					{
						this.canCarpet = true;
						this.carpetTime = 0;
						this.carpetFrame = -1;
						this.carpetFrameCounter = 0f;
					}
					if (this.gravDir == -1f)
					{
						this.canCarpet = false;
					}
					if (this.ropeCount > 0)
					{
						this.ropeCount--;
					}
					if (!this.pulley && !this.frozen && !this.controlJump && this.gravDir == 1f && this.ropeCount == 0 && this.grappling[0] == -1 && !this.tongued && this.mount == 0 && (this.controlUp || this.controlDown))
					{
						int num47 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num48 = (int)(this.position.Y - 8f) / 16;
						if (Main.tile[num47, num48].active() && Main.tileRope[(int)Main.tile[num47, num48].type])
						{
							float num49 = this.position.Y;
							if (Main.tile[num47, num48 - 1] == null)
							{
								Main.tile[num47, num48 - 1] = new Tile();
							}
							if (Main.tile[num47, num48 + 1] == null)
							{
								Main.tile[num47, num48 + 1] = new Tile();
							}
							if ((!Main.tile[num47, num48 - 1].active() || !Main.tileRope[(int)Main.tile[num47, num48 - 1].type]) && (!Main.tile[num47, num48 + 1].active() || !Main.tileRope[(int)Main.tile[num47, num48 + 1].type]))
							{
								num49 = (float)(num48 * 16 + 22);
							}
							float num50 = (float)(num47 * 16 + 8 - this.width / 2 + 6 * this.direction);
							int num51 = num47 * 16 + 8 - this.width / 2 + 6;
							int num52 = num47 * 16 + 8 - this.width / 2;
							int num53 = num47 * 16 + 8 - this.width / 2 + -6;
							int num54 = 1;
							float num55 = Math.Abs(this.position.X - (float)num51);
							if (Math.Abs(this.position.X - (float)num52) < num55)
							{
								num54 = 2;
								num55 = Math.Abs(this.position.X - (float)num52);
							}
							if (Math.Abs(this.position.X - (float)num53) < num55)
							{
								num54 = 3;
								num55 = Math.Abs(this.position.X - (float)num53);
							}
							if (num54 == 1)
							{
								num50 = (float)num51;
								this.pulleyDir = 2;
								this.direction = 1;
							}
							if (num54 == 2)
							{
								num50 = (float)num52;
								this.pulleyDir = 1;
							}
							if (num54 == 3)
							{
								num50 = (float)num53;
								this.pulleyDir = 2;
								this.direction = -1;
							}
							if (!Collision.SolidCollision(new Vector2(num50, this.position.Y), this.width, this.height))
							{
								if (i == Main.myPlayer)
								{
									Main.cameraX = Main.cameraX + this.position.X - num50;
								}
								this.pulley = true;
								this.position.X = num50;
								this.gfxOffY = this.position.Y - num49;
								this.stepSpeed = 2.5f;
								this.position.Y = num49;
								this.velocity.X = 0f;
							}
							else
							{
								num50 = (float)num51;
								this.pulleyDir = 2;
								this.direction = 1;
								if (!Collision.SolidCollision(new Vector2(num50, this.position.Y), this.width, this.height))
								{
									if (i == Main.myPlayer)
									{
										Main.cameraX = Main.cameraX + this.position.X - num50;
									}
									this.pulley = true;
									this.position.X = num50;
									this.gfxOffY = this.position.Y - num49;
									this.stepSpeed = 2.5f;
									this.position.Y = num49;
									this.velocity.X = 0f;
								}
								else
								{
									num50 = (float)num53;
									this.pulleyDir = 2;
									this.direction = -1;
									if (!Collision.SolidCollision(new Vector2(num50, this.position.Y), this.width, this.height))
									{
										if (i == Main.myPlayer)
										{
											Main.cameraX = Main.cameraX + this.position.X - num50;
										}
										this.pulley = true;
										this.position.X = num50;
										this.gfxOffY = this.position.Y - num49;
										this.stepSpeed = 2.5f;
										this.position.Y = num49;
										this.velocity.X = 0f;
									}
								}
							}
						}
					}
					if (this.pulley)
					{
						this.sandStorm = false;
						this.dJumpEffect = false;
						this.dJumpEffect2 = false;
						this.dJumpEffect3 = false;
						this.dJumpEffect4 = false;
						int num56 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num57 = (int)(this.position.Y - 8f) / 16;
						bool flag11 = false;
						if (this.pulleyDir == 0)
						{
							this.pulleyDir = 1;
						}
						if (this.pulleyDir == 1)
						{
							if (this.direction == -1 && this.controlLeft && (this.releaseLeft || this.leftTimer == 0))
							{
								this.pulleyDir = 2;
								flag11 = true;
							}
							else if ((this.direction == 1 && this.controlRight && this.releaseRight) || this.rightTimer == 0)
							{
								this.pulleyDir = 2;
								flag11 = true;
							}
							else
							{
								if (this.direction == 1 && this.controlLeft)
								{
									this.direction = -1;
									flag11 = true;
								}
								if (this.direction == -1 && this.controlRight)
								{
									this.direction = 1;
									flag11 = true;
								}
							}
						}
						else if (this.pulleyDir == 2)
						{
							if (this.direction == 1 && this.controlLeft)
							{
								flag11 = true;
								int num58 = num56 * 16 + 8 - this.width / 2;
								if (!Collision.SolidCollision(new Vector2((float)num58, this.position.Y), this.width, this.height))
								{
									this.pulleyDir = 1;
									this.direction = -1;
									flag11 = true;
								}
							}
							if (this.direction == -1 && this.controlRight)
							{
								flag11 = true;
								int num59 = num56 * 16 + 8 - this.width / 2;
								if (!Collision.SolidCollision(new Vector2((float)num59, this.position.Y), this.width, this.height))
								{
									this.pulleyDir = 1;
									this.direction = 1;
									flag11 = true;
								}
							}
						}
						bool flag12 = false;
						if (!flag11 && ((this.controlLeft && (this.releaseLeft || this.leftTimer == 0)) || (this.controlRight && (this.releaseRight || this.rightTimer == 0))))
						{
							int num60 = 1;
							if (this.controlLeft)
							{
								num60 = -1;
							}
							int num61 = num56 + num60;
							if (Main.tile[num61, num57].active() && Main.tileRope[(int)Main.tile[num61, num57].type])
							{
								this.pulleyDir = 1;
								this.direction = num60;
								int num62 = num61 * 16 + 8 - this.width / 2;
								float num63 = this.position.Y;
								num63 = (float)(num57 * 16 + 22);
								if ((!Main.tile[num61, num57 - 1].active() || !Main.tileRope[(int)Main.tile[num61, num57 - 1].type]) && (!Main.tile[num61, num57 + 1].active() || !Main.tileRope[(int)Main.tile[num61, num57 + 1].type]))
								{
									num63 = (float)(num57 * 16 + 22);
								}
								if (Collision.SolidCollision(new Vector2((float)num62, num63), this.width, this.height))
								{
									this.pulleyDir = 2;
									this.direction = -num60;
									if (this.direction == 1)
									{
										num62 = num61 * 16 + 8 - this.width / 2 + 6;
									}
									else
									{
										num62 = num61 * 16 + 8 - this.width / 2 + -6;
									}
								}
								if (i == Main.myPlayer)
								{
									Main.cameraX = Main.cameraX + this.position.X - (float)num62;
								}
								this.position.X = (float)num62;
								this.gfxOffY = this.position.Y - num63;
								this.position.Y = num63;
								flag12 = true;
							}
						}
						if (!flag12 && !flag11 && !this.controlUp && ((this.controlLeft && this.releaseLeft) || (this.controlRight && this.releaseRight)))
						{
							this.pulley = false;
							if (this.controlLeft && this.velocity.X == 0f)
							{
								this.velocity.X = -1f;
							}
							if (this.controlRight && this.velocity.X == 0f)
							{
								this.velocity.X = 1f;
							}
						}
						if (this.velocity.X != 0f)
						{
							this.pulley = false;
						}
						if (Main.tile[num56, num57] == null)
						{
							Main.tile[num56, num57] = new Tile();
						}
						if (!Main.tile[num56, num57].active() || !Main.tileRope[(int)Main.tile[num56, num57].type])
						{
							this.pulley = false;
						}
						if (this.gravDir != 1f)
						{
							this.pulley = false;
						}
						if (this.frozen)
						{
							this.pulley = false;
						}
						if (!this.pulley)
						{
							this.velocity.Y = this.velocity.Y - num2;
						}
						if (this.controlJump)
						{
							this.pulley = false;
							this.jump = Player.jumpHeight;
							this.velocity.Y = -Player.jumpSpeed;
						}
					}
					if (this.pulley)
					{
						this.fallStart = (int)this.position.Y / 16;
						this.wingFrame = 0;
						if (this.wings == 4)
						{
							this.wingFrame = 3;
						}
						int num64 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num65 = (int)(this.position.Y - 16f) / 16;
						int num66 = (int)(this.position.Y - 8f) / 16;
						bool flag13 = true;
						bool flag14 = false;
						if ((Main.tile[num64, num66 - 1].active() && Main.tileRope[(int)Main.tile[num64, num66 - 1].type]) || (Main.tile[num64, num66 + 1].active() && Main.tileRope[(int)Main.tile[num64, num66 + 1].type]))
						{
							flag14 = true;
						}
						if (Main.tile[num64, num65] == null)
						{
							Main.tile[num64, num65] = new Tile();
						}
						if (!Main.tile[num64, num65].active() || !Main.tileRope[(int)Main.tile[num64, num65].type])
						{
							flag13 = false;
							if (this.velocity.Y < 0f)
							{
								this.velocity.Y = 0f;
							}
						}
						if (flag14)
						{
							if (this.controlUp && flag13)
							{
								float num67 = this.position.X;
								float y = this.position.Y - Math.Abs(this.velocity.Y) - 2f;
								if (Collision.SolidCollision(new Vector2(num67, y), this.width, this.height))
								{
									num67 = (float)(num64 * 16 + 8 - this.width / 2 + 6);
									if (!Collision.SolidCollision(new Vector2(num67, y), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
									{
										if (i == Main.myPlayer)
										{
											Main.cameraX = Main.cameraX + this.position.X - num67;
										}
										this.pulleyDir = 2;
										this.direction = 1;
										this.position.X = num67;
										this.velocity.X = 0f;
									}
									else
									{
										num67 = (float)(num64 * 16 + 8 - this.width / 2 + -6);
										if (!Collision.SolidCollision(new Vector2(num67, y), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
										{
											if (i == Main.myPlayer)
											{
												Main.cameraX = Main.cameraX + this.position.X - num67;
											}
											this.pulleyDir = 2;
											this.direction = -1;
											this.position.X = num67;
											this.velocity.X = 0f;
										}
									}
								}
								if (this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.7f;
								}
								if (this.velocity.Y > -3f)
								{
									this.velocity.Y = this.velocity.Y - 0.2f;
								}
								else
								{
									this.velocity.Y = this.velocity.Y - 0.02f;
								}
								if (this.velocity.Y < -8f)
								{
									this.velocity.Y = -8f;
								}
							}
							else if (this.controlDown)
							{
								float num68 = this.position.X;
								float y2 = this.position.Y;
								if (Collision.SolidCollision(new Vector2(num68, y2), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
								{
									num68 = (float)(num64 * 16 + 8 - this.width / 2 + 6);
									if (!Collision.SolidCollision(new Vector2(num68, y2), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
									{
										if (i == Main.myPlayer)
										{
											Main.cameraX = Main.cameraX + this.position.X - num68;
										}
										this.pulleyDir = 2;
										this.direction = 1;
										this.position.X = num68;
										this.velocity.X = 0f;
									}
									else
									{
										num68 = (float)(num64 * 16 + 8 - this.width / 2 + -6);
										if (!Collision.SolidCollision(new Vector2(num68, y2), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
										{
											if (i == Main.myPlayer)
											{
												Main.cameraX = Main.cameraX + this.position.X - num68;
											}
											this.pulleyDir = 2;
											this.direction = -1;
											this.position.X = num68;
											this.velocity.X = 0f;
										}
									}
								}
								if (this.velocity.Y < 0f)
								{
									this.velocity.Y = this.velocity.Y * 0.7f;
								}
								if (this.velocity.Y < 3f)
								{
									this.velocity.Y = this.velocity.Y + 0.2f;
								}
								else
								{
									this.velocity.Y = this.velocity.Y + 0.1f;
								}
								if (this.velocity.Y > num)
								{
									this.velocity.Y = num;
								}
							}
							else
							{
								this.velocity.Y = this.velocity.Y * 0.7f;
								if ((double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1)
								{
									this.velocity.Y = 0f;
								}
							}
						}
						else if (this.controlDown)
						{
							this.ropeCount = 10;
							this.pulley = false;
							this.velocity.Y = 1f;
						}
						else
						{
							this.velocity.Y = 0f;
							this.position.Y = (float)(num65 * 16 + 22);
						}
						float num69 = (float)(num64 * 16 + 8 - this.width / 2);
						if (this.pulleyDir == 1)
						{
							num69 = (float)(num64 * 16 + 8 - this.width / 2);
						}
						if (this.pulleyDir == 2)
						{
							num69 = (float)(num64 * 16 + 8 - this.width / 2 + 6 * this.direction);
						}
						if (i == Main.myPlayer)
						{
							Main.cameraX = Main.cameraX + this.position.X - num69;
						}
						this.position.X = num69;
						this.pulleyFrameCounter += Math.Abs(this.velocity.Y * 0.75f);
						if (this.velocity.Y != 0f)
						{
							this.pulleyFrameCounter += 0.75f;
						}
						if (this.pulleyFrameCounter > 10f)
						{
							this.pulleyFrame++;
							this.pulleyFrameCounter = 0f;
						}
						if (this.pulleyFrame > 1)
						{
							this.pulleyFrame = 0;
						}
						this.canCarpet = true;
						this.carpetFrame = -1;
						this.wingTime = (float)this.wingTimeMax;
						this.rocketTime = this.rocketTimeMax;
						this.rocketDelay = 0;
						this.rocketFrame = false;
						this.canRocket = false;
						this.rocketRelease = false;
					}
					else if (this.grappling[0] == -1 && !this.tongued)
					{
						if (this.wingsLogic == 3 && this.velocity.Y == 0f)
						{
							this.accRunSpeed = 8.5f;
						}
						if (this.wingsLogic == 3 && Main.myPlayer == this.whoAmi)
						{
							this.accRunSpeed = 0f;
						}
						if (this.wingsLogic > 0 && this.velocity.Y != 0f)
						{
							if (this.wingsLogic == 1 || this.wingsLogic == 2)
							{
								this.accRunSpeed = 6.25f;
							}
							if (this.wingsLogic == 4)
							{
								this.accRunSpeed = 6.5f;
							}
							if (this.wingsLogic == 5 || this.wingsLogic == 6 || this.wingsLogic == 13 || this.wingsLogic == 15)
							{
								this.accRunSpeed = 6.75f;
							}
							if (this.wingsLogic == 7 || this.wingsLogic == 8)
							{
								this.accRunSpeed = 7f;
							}
							if (this.wingsLogic == 9 || this.wingsLogic == 10 || this.wingsLogic == 11 || this.wingsLogic == 20 || this.wingsLogic == 21 || this.wingsLogic == 23 || this.wingsLogic == 24)
							{
								this.accRunSpeed = 7.5f;
							}
							if (this.wingsLogic == 22)
							{
								if (this.controlDown && this.controlJump && this.wingTime > 0f)
								{
									this.accRunSpeed = 10f;
									num4 *= 10f;
								}
								else
								{
									this.accRunSpeed = 6.25f;
								}
							}
							if (this.wingsLogic == 12)
							{
								this.accRunSpeed = 7.75f;
							}
							if (this.wingsLogic == 16 || this.wingsLogic == 17 || this.wingsLogic == 18 || this.wingsLogic == 19)
							{
								this.accRunSpeed = 7.9f;
							}
							if (this.wingsLogic == 3)
							{
								this.accRunSpeed = 11f;
								num4 *= 3f;
							}
						}
						if (Main.myPlayer == this.whoAmi && (this.wings == 3 || this.wings == 16 || this.wings == 17 || this.wings == 18 || this.wings == 19))
						{
							this.accRunSpeed = 0f;
							num3 *= 0.2f;
							num4 *= 0.2f;
						}
						if (this.sticky)
						{
							num3 *= 0.25f;
							num4 *= 0.25f;
							num5 *= 2f;
							if (this.velocity.X > num3)
							{
								this.velocity.X = num3;
							}
							if (this.velocity.X < -num3)
							{
								this.velocity.X = -num3;
							}
						}
						else if (this.powerrun)
						{
							num3 *= 3.5f;
							num4 *= 1f;
							num5 *= 2f;
						}
						else if (this.slippy2)
						{
							num4 *= 0.6f;
							num5 = 0f;
							if (this.iceSkate)
							{
								num4 *= 3.5f;
								num3 *= 1.25f;
							}
						}
						else if (this.slippy)
						{
							num4 *= 0.7f;
							if (this.iceSkate)
							{
								num4 *= 3.5f;
								num3 *= 1.25f;
							}
							else
							{
								num5 *= 0.1f;
							}
						}
						if (this.sandStorm)
						{
							num4 *= 1.5f;
							num3 *= 2f;
						}
						if (this.dJumpEffect3 && this.doubleJump3)
						{
							num4 *= 3f;
							num3 *= 1.5f;
						}
						if (this.dJumpEffect4 && this.doubleJump4)
						{
							num4 *= 3f;
							num3 *= 1.75f;
						}
						if (this.carpetFrame != -1)
						{
							num4 *= 1.25f;
							num3 *= 1.5f;
						}
						if (this.mount > 0)
						{
							this.rocketBoots = 0;
							this.wings = 0;
							this.wingsLogic = 0;
							this.accRunSpeed = num3;
							if (this.mount == 1)
							{
								num3 = 5.5f;
								this.accRunSpeed = 12f;
								num4 = 0.09f;
							}
						}
						if (this.controlLeft && this.velocity.X > -num3)
						{
							if (this.velocity.X > num5)
							{
								this.velocity.X = this.velocity.X - num5;
							}
							this.velocity.X = this.velocity.X - num4;
							if (!this.sandStorm && (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn))
							{
								this.direction = -1;
							}
						}
						else if (this.controlRight && this.velocity.X < num3)
						{
							if (this.velocity.X < -num5)
							{
								this.velocity.X = this.velocity.X + num5;
							}
							this.velocity.X = this.velocity.X + num4;
							if (!this.sandStorm && (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn))
							{
								this.direction = 1;
							}
						}
						else if (this.controlLeft && this.velocity.X > -this.accRunSpeed && this.dashDelay >= 0)
						{
							if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
							{
								this.direction = -1;
							}
							if (this.velocity.Y == 0f || this.wingsLogic > 0 || this.mount == 1)
							{
								if (this.velocity.X > num5)
								{
									this.velocity.X = this.velocity.X - num5;
								}
								this.velocity.X = this.velocity.X - num4 * 0.2f;
								if (this.wingsLogic > 0)
								{
									this.velocity.X = this.velocity.X - num4 * 0.2f;
								}
							}
							if (this.velocity.X < -(this.accRunSpeed + num3) / 2f && this.velocity.Y == 0f && this.mount == 0)
							{
								int num70 = 0;
								if (this.gravDir == -1f)
								{
									num70 -= this.height;
								}
								if (this.runSoundDelay == 0 && this.velocity.Y == 0f)
								{
									Main.PlaySound(17, (int)this.position.X, (int)this.position.Y, 1);
									this.runSoundDelay = 9;
								}
								if (this.wings == 3)
								{
									int num71 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num70), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num71].velocity *= 0.025f;
									num71 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num70), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num71].velocity *= 0.2f;
								}
								else if (this.coldDash)
								{
									for (int num72 = 0; num72 < 2; num72++)
									{
										int num73;
										if (num72 == 0)
										{
											num73 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
										}
										else
										{
											num73 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
										}
										Main.dust[num73].scale *= 1f + (float)Main.rand.Next(20, 40) * 0.01f;
										Main.dust[num73].noGravity = true;
										Main.dust[num73].noLight = true;
										Main.dust[num73].velocity *= 0.001f;
										Dust expr_55AA_cp_0 = Main.dust[num73];
										expr_55AA_cp_0.velocity.Y = expr_55AA_cp_0.velocity.Y - 0.003f;
									}
								}
								else
								{
									int num74 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num70), this.width + 8, 4, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num74].velocity.X = Main.dust[num74].velocity.X * 0.2f;
									Main.dust[num74].velocity.Y = Main.dust[num74].velocity.Y * 0.2f;
								}
							}
						}
						else if (this.controlRight && this.velocity.X < this.accRunSpeed)
						{
							if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
							{
								this.direction = 1;
							}
							if (this.velocity.Y == 0f || this.wingsLogic > 0 || this.mount == 1)
							{
								if (this.velocity.X < -num5)
								{
									this.velocity.X = this.velocity.X + num5;
								}
								this.velocity.X = this.velocity.X + num4 * 0.2f;
								if (this.wingsLogic > 0)
								{
									this.velocity.X = this.velocity.X + num4 * 0.2f;
								}
							}
							if (this.velocity.X > (this.accRunSpeed + num3) / 2f && this.velocity.Y == 0f && this.mount == 0)
							{
								int num75 = 0;
								if (this.gravDir == -1f)
								{
									num75 -= this.height;
								}
								if (this.runSoundDelay == 0 && this.velocity.Y == 0f)
								{
									Main.PlaySound(17, (int)this.position.X, (int)this.position.Y, 1);
									this.runSoundDelay = 9;
								}
								if (this.wings == 3)
								{
									int num76 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num75), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num76].velocity *= 0.025f;
									num76 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num75), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num76].velocity *= 0.2f;
								}
								else if (this.coldDash)
								{
									for (int num77 = 0; num77 < 2; num77++)
									{
										int num78;
										if (num77 == 0)
										{
											num78 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
										}
										else
										{
											num78 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
										}
										Main.dust[num78].scale *= 1f + (float)Main.rand.Next(20, 40) * 0.01f;
										Main.dust[num78].noGravity = true;
										Main.dust[num78].noLight = true;
										Main.dust[num78].velocity *= 0.001f;
										Dust expr_5A8B_cp_0 = Main.dust[num78];
										expr_5A8B_cp_0.velocity.Y = expr_5A8B_cp_0.velocity.Y - 0.003f;
									}
								}
								else
								{
									int num79 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num75), this.width + 8, 4, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num79].velocity.X = Main.dust[num79].velocity.X * 0.2f;
									Main.dust[num79].velocity.Y = Main.dust[num79].velocity.Y * 0.2f;
								}
							}
						}
						else if (this.velocity.Y == 0f)
						{
							if (this.velocity.X > num5)
							{
								this.velocity.X = this.velocity.X - num5;
							}
							else if (this.velocity.X < -num5)
							{
								this.velocity.X = this.velocity.X + num5;
							}
							else
							{
								this.velocity.X = 0f;
							}
						}
						else if ((double)this.velocity.X > (double)num5 * 0.5)
						{
							this.velocity.X = this.velocity.X - num5 * 0.5f;
						}
						else if ((double)this.velocity.X < (double)(-(double)num5) * 0.5)
						{
							this.velocity.X = this.velocity.X + num5 * 0.5f;
						}
						else
						{
							this.velocity.X = 0f;
						}
						if (this.gravControl)
						{
							if (this.controlUp && this.releaseUp)
							{
								if (this.gravDir == 1f)
								{
									this.gravDir = -1f;
									this.fallStart = (int)(this.position.Y / 16f);
									this.jump = 0;
									Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
								}
								else
								{
									this.gravDir = 1f;
									this.fallStart = (int)(this.position.Y / 16f);
									this.jump = 0;
									Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
								}
							}
						}
						else if (this.gravControl2)
						{
							if (this.controlUp && this.releaseUp && this.velocity.Y == 0f)
							{
								if (this.gravDir == 1f)
								{
									this.gravDir = -1f;
									this.fallStart = (int)(this.position.Y / 16f);
									this.jump = 0;
									Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
								}
								else
								{
									this.gravDir = 1f;
									this.fallStart = (int)(this.position.Y / 16f);
									this.jump = 0;
									Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
								}
							}
						}
						else
						{
							this.gravDir = 1f;
						}
						if (this.controlUp)
						{
							this.releaseUp = false;
						}
						else
						{
							this.releaseUp = true;
						}
						this.sandStorm = false;
						if (this.controlJump)
						{
							if (this.jump > 0)
							{
								if (this.velocity.Y == 0f)
								{
									if (this.merman)
									{
										this.jump = 10;
									}
									this.jump = 0;
								}
								else
								{
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									if (this.merman)
									{
										if (this.swimTime <= 10)
										{
											this.swimTime = 30;
										}
									}
									else
									{
										this.jump--;
									}
								}
							}
							else if ((this.sliding || this.velocity.Y == 0f || this.jumpAgain || this.jumpAgain2 || this.jumpAgain3 || this.jumpAgain4 || (this.wet && this.accFlipper)) && this.releaseJump)
							{
								bool flag15 = false;
								if (this.wet && this.accFlipper)
								{
									if (this.swimTime == 0)
									{
										this.swimTime = 30;
									}
									flag15 = true;
								}
								bool flag16 = false;
								bool flag17 = false;
								bool flag18 = false;
								if (this.jumpAgain2)
								{
									flag16 = true;
									this.jumpAgain2 = false;
								}
								else if (this.jumpAgain3)
								{
									flag17 = true;
									this.jumpAgain3 = false;
								}
								else if (this.jumpAgain4)
								{
									this.jumpAgain4 = false;
									flag18 = true;
								}
								else
								{
									this.jumpAgain = false;
								}
								this.canRocket = false;
								this.rocketRelease = false;
								if ((this.velocity.Y == 0f || this.sliding) && this.doubleJump)
								{
									this.jumpAgain = true;
								}
								if ((this.velocity.Y == 0f || this.sliding) && this.doubleJump2)
								{
									this.jumpAgain2 = true;
								}
								if ((this.velocity.Y == 0f || this.sliding) && this.doubleJump3)
								{
									this.jumpAgain3 = true;
								}
								if ((this.velocity.Y == 0f || this.sliding) && this.doubleJump4)
								{
									this.jumpAgain4 = true;
								}
								if (this.velocity.Y == 0f || flag15 || this.sliding)
								{
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									this.jump = Player.jumpHeight;
									if (this.sliding)
									{
										this.velocity.X = (float)(3 * -(float)this.slideDir);
									}
								}
								else if (flag16)
								{
									this.dJumpEffect2 = true;
									float arg_60CB_0 = this.gravDir;
									Main.PlaySound(16, (int)this.position.X, (int)this.position.Y, 1);
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									this.jump = Player.jumpHeight * 3;
								}
								else if (flag17)
								{
									this.dJumpEffect3 = true;
									float arg_612D_0 = this.gravDir;
									Main.PlaySound(16, (int)this.position.X, (int)this.position.Y, 1);
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									this.jump = (int)((double)Player.jumpHeight * 1.5);
								}
								else if (flag18)
								{
									this.dJumpEffect4 = true;
									int num80 = this.height;
									if (this.gravDir == -1f)
									{
										num80 = 0;
									}
									Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 16);
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									this.jump = Player.jumpHeight * 2;
									for (int num81 = 0; num81 < 10; num81++)
									{
										int num82 = Dust.NewDust(new Vector2(this.position.X - 34f, this.position.Y + (float)num80 - 16f), 102, 32, 188, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
										Main.dust[num82].velocity.X = Main.dust[num82].velocity.X * 0.5f - this.velocity.X * 0.1f;
										Main.dust[num82].velocity.Y = Main.dust[num82].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
									}
									int num83 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 16f, this.position.Y + (float)num80 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(435, 438), 1f);
									Main.gore[num83].velocity.X = Main.gore[num83].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num83].velocity.Y = Main.gore[num83].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
									num83 = Gore.NewGore(new Vector2(this.position.X - 36f, this.position.Y + (float)num80 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(435, 438), 1f);
									Main.gore[num83].velocity.X = Main.gore[num83].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num83].velocity.Y = Main.gore[num83].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
									num83 = Gore.NewGore(new Vector2(this.position.X + (float)this.width + 4f, this.position.Y + (float)num80 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(435, 438), 1f);
									Main.gore[num83].velocity.X = Main.gore[num83].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num83].velocity.Y = Main.gore[num83].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
								}
								else
								{
									this.dJumpEffect = true;
									int num84 = this.height;
									if (this.gravDir == -1f)
									{
										num84 = 0;
									}
									Main.PlaySound(16, (int)this.position.X, (int)this.position.Y, 1);
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									this.jump = (int)((double)Player.jumpHeight * 0.75);
									for (int num85 = 0; num85 < 10; num85++)
									{
										int num86 = Dust.NewDust(new Vector2(this.position.X - 34f, this.position.Y + (float)num84 - 16f), 102, 32, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
										Main.dust[num86].velocity.X = Main.dust[num86].velocity.X * 0.5f - this.velocity.X * 0.1f;
										Main.dust[num86].velocity.Y = Main.dust[num86].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
									}
									int num87 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 16f, this.position.Y + (float)num84 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
									Main.gore[num87].velocity.X = Main.gore[num87].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num87].velocity.Y = Main.gore[num87].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
									num87 = Gore.NewGore(new Vector2(this.position.X - 36f, this.position.Y + (float)num84 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
									Main.gore[num87].velocity.X = Main.gore[num87].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num87].velocity.Y = Main.gore[num87].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
									num87 = Gore.NewGore(new Vector2(this.position.X + (float)this.width + 4f, this.position.Y + (float)num84 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
									Main.gore[num87].velocity.X = Main.gore[num87].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num87].velocity.Y = Main.gore[num87].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
								}
							}
							this.releaseJump = false;
						}
						else
						{
							this.jump = 0;
							this.releaseJump = true;
							this.rocketRelease = true;
						}
						if (this.wingsLogic == 0)
						{
							this.wingTime = 0f;
						}
						if (this.wingsLogic == 3)
						{
							this.wingTime = 1000f;
						}
						if (Main.myPlayer == this.whoAmi && (this.wings == 3 || this.wings == 16 || this.wings == 17 || this.wings == 18 || this.wings == 19))
						{
							this.wingTime = 0f;
							this.jump = 0;
						}
						if (this.rocketBoots == 0)
						{
							this.rocketTime = 0;
						}
						if (this.jump == 0)
						{
							this.dJumpEffect = false;
							this.dJumpEffect2 = false;
							this.dJumpEffect3 = false;
							this.dJumpEffect4 = false;
						}
						if (this.dashDelay > 0)
						{
							this.dashDelay--;
						}
						else if (this.dashDelay < 0)
						{
							for (int num88 = 0; num88 < 2; num88++)
							{
								int num89;
								if (this.velocity.Y == 0f)
								{
									num89 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 4f), this.width, 8, 31, 0f, 0f, 100, default(Color), 1.4f);
								}
								else
								{
									num89 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)(this.height / 2) - 8f), this.width, 16, 31, 0f, 0f, 100, default(Color), 1.4f);
								}
								Main.dust[num89].velocity *= 0.1f;
								Main.dust[num89].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
							}
							if (this.velocity.X > 13f || this.velocity.X < -13f)
							{
								this.velocity.X = this.velocity.X * 0.99f;
							}
							else if (this.velocity.X > this.accRunSpeed || this.velocity.X < -this.accRunSpeed)
							{
								this.velocity.X = this.velocity.X * 0.9f;
							}
							else
							{
								this.dashDelay = 20;
								if (this.velocity.X < 0f)
								{
									this.velocity.X = -this.accRunSpeed;
								}
								else if (this.velocity.X > 0f)
								{
									this.velocity.X = this.accRunSpeed;
								}
							}
						}
						else if (this.dash > 0 && this.mount == 0)
						{
							int num90 = 0;
							bool flag19 = false;
							if (this.dashTime > 0)
							{
								this.dashTime--;
							}
							if (this.dashTime < 0)
							{
								this.dashTime++;
							}
							if (this.controlRight && this.releaseRight)
							{
								if (this.dashTime > 0)
								{
									num90 = 1;
									flag19 = true;
									this.dashTime = 0;
								}
								else
								{
									this.dashTime = 15;
								}
							}
							else if (this.controlLeft && this.releaseLeft)
							{
								if (this.dashTime < 0)
								{
									num90 = -1;
									flag19 = true;
									this.dashTime = 0;
								}
								else
								{
									this.dashTime = -15;
								}
							}
							if (flag19)
							{
								this.velocity.X = 15.9f * (float)num90;
								this.dashDelay = -1;
								for (int num91 = 0; num91 < 20; num91++)
								{
									int num92 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 2f);
									Dust expr_6DDC_cp_0 = Main.dust[num92];
									expr_6DDC_cp_0.position.X = expr_6DDC_cp_0.position.X + (float)Main.rand.Next(-5, 6);
									Dust expr_6E03_cp_0 = Main.dust[num92];
									expr_6E03_cp_0.position.Y = expr_6E03_cp_0.position.Y + (float)Main.rand.Next(-5, 6);
									Main.dust[num92].velocity *= 0.2f;
									Main.dust[num92].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
								}
								int num93 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 34f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num93].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
								Main.gore[num93].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
								Main.gore[num93].velocity *= 0.4f;
								num93 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 14f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num93].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
								Main.gore[num93].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
								Main.gore[num93].velocity *= 0.4f;
							}
						}
						this.sliding = false;
						if (this.slideDir != 0 && this.spikedBoots > 0 && this.mount == 0 && ((this.controlLeft && this.slideDir == -1) || (this.controlRight && this.slideDir == 1)))
						{
							bool flag20 = false;
							float num94 = this.position.X;
							if (this.slideDir == 1)
							{
								num94 += (float)this.width;
							}
							num94 += (float)this.slideDir;
							float num95 = this.position.Y + (float)this.height + 1f;
							if (this.gravDir < 0f)
							{
								num95 = this.position.Y - 1f;
							}
							num94 /= 16f;
							num95 /= 16f;
							if (WorldGen.SolidTile((int)num94, (int)num95) && WorldGen.SolidTile((int)num94, (int)num95 - 1))
							{
								flag20 = true;
							}
							if (this.spikedBoots >= 2)
							{
								if (flag20 && ((this.velocity.Y > 0f && this.gravDir == 1f) || (this.velocity.Y < num2 && this.gravDir == -1f)))
								{
									float num96 = num2;
									if (this.slowFall)
									{
										if (this.controlUp)
										{
											num96 = num2 / 10f * this.gravDir;
										}
										else
										{
											num96 = num2 / 3f * this.gravDir;
										}
									}
									this.fallStart = (int)(this.position.Y / 16f);
									if ((this.controlDown && this.gravDir == 1f) || (this.controlUp && this.gravDir == -1f))
									{
										this.velocity.Y = 4f * this.gravDir;
										int num97 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)((this.width / 2 - 4) * this.slideDir), this.position.Y + (float)(this.height / 2) + (float)(this.height / 2 - 4) * this.gravDir), 8, 8, 31, 0f, 0f, 0, default(Color), 1f);
										if (this.slideDir < 0)
										{
											Dust expr_727D_cp_0 = Main.dust[num97];
											expr_727D_cp_0.position.X = expr_727D_cp_0.position.X - 10f;
										}
										if (this.gravDir < 0f)
										{
											Dust expr_72A8_cp_0 = Main.dust[num97];
											expr_72A8_cp_0.position.Y = expr_72A8_cp_0.position.Y - 12f;
										}
										Main.dust[num97].velocity *= 0.1f;
										Main.dust[num97].scale *= 1.2f;
										Main.dust[num97].noGravity = true;
									}
									else if (this.gravDir == -1f)
									{
										this.velocity.Y = (-num96 + 1E-05f) * this.gravDir;
									}
									else
									{
										this.velocity.Y = (-num96 + 1E-05f) * this.gravDir;
									}
									this.sliding = true;
								}
							}
							else if ((flag20 && (double)this.velocity.Y > 0.5 && this.gravDir == 1f) || ((double)this.velocity.Y < -0.5 && this.gravDir == -1f))
							{
								this.fallStart = (int)(this.position.Y / 16f);
								if (this.controlDown)
								{
									this.velocity.Y = 4f * this.gravDir;
								}
								else
								{
									this.velocity.Y = 0.5f * this.gravDir;
								}
								this.sliding = true;
								int num98 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)((this.width / 2 - 4) * this.slideDir), this.position.Y + (float)(this.height / 2) + (float)(this.height / 2 - 4) * this.gravDir), 8, 8, 31, 0f, 0f, 0, default(Color), 1f);
								if (this.slideDir < 0)
								{
									Dust expr_748D_cp_0 = Main.dust[num98];
									expr_748D_cp_0.position.X = expr_748D_cp_0.position.X - 10f;
								}
								if (this.gravDir < 0f)
								{
									Dust expr_74B8_cp_0 = Main.dust[num98];
									expr_74B8_cp_0.position.Y = expr_74B8_cp_0.position.Y - 12f;
								}
								Main.dust[num98].velocity *= 0.1f;
								Main.dust[num98].scale *= 1.2f;
								Main.dust[num98].noGravity = true;
							}
						}
						bool flag21 = false;
						if (this.grappling[0] == -1 && this.carpet && !this.jumpAgain && !this.jumpAgain2 && !this.jumpAgain3 && !this.jumpAgain4 && this.jump == 0 && this.velocity.Y != 0f && this.rocketTime == 0 && this.wingTime == 0f && this.mount == 0)
						{
							if (this.controlJump && this.canCarpet)
							{
								this.canCarpet = false;
								this.carpetTime = 300;
							}
							if (this.carpetTime > 0 && this.controlJump)
							{
								this.fallStart = (int)(this.position.Y / 16f);
								flag21 = true;
								this.carpetTime--;
								if (this.gravDir == 1f && this.velocity.Y > -num2)
								{
									this.velocity.Y = -(num2 + 1E-06f);
								}
								else if (this.gravDir == -1f && this.velocity.Y < num2)
								{
									this.velocity.Y = num2 + 1E-06f;
								}
								this.carpetFrameCounter += 1f + Math.Abs(this.velocity.X * 0.5f);
								if (this.carpetFrameCounter > 8f)
								{
									this.carpetFrameCounter = 0f;
									this.carpetFrame++;
								}
								if (this.carpetFrame < 0)
								{
									this.carpetFrame = 0;
								}
								if (this.carpetFrame > 5)
								{
									this.carpetFrame = 0;
								}
							}
						}
						if (!flag21)
						{
							this.carpetFrame = -1;
						}
						if (this.dJumpEffect && this.doubleJump && !this.jumpAgain && (this.jumpAgain2 || !this.doubleJump2) && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
						{
							int num99 = this.height;
							if (this.gravDir == -1f)
							{
								num99 = -6;
							}
							int num100 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)num99), this.width + 8, 4, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
							Main.dust[num100].velocity.X = Main.dust[num100].velocity.X * 0.5f - this.velocity.X * 0.1f;
							Main.dust[num100].velocity.Y = Main.dust[num100].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
						}
						if (this.dJumpEffect2 && this.doubleJump2 && !this.jumpAgain2 && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
						{
							int num101 = this.height;
							if (this.gravDir == -1f)
							{
								num101 = -6;
							}
							float num102 = ((float)this.jump / 75f + 1f) / 2f;
							for (int num103 = 0; num103 < 3; num103++)
							{
								int num104 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)(num101 / 2)), this.width, 32, 124, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 150, default(Color), 1f * num102);
								Main.dust[num104].velocity *= 0.5f * num102;
								Main.dust[num104].fadeIn = 1.5f * num102;
							}
							this.sandStorm = true;
							if (this.miscCounter % 3 == 0)
							{
								int num105 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 18f, this.position.Y + (float)(num101 / 2)), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(220, 223), num102);
								Main.gore[num105].velocity = this.velocity * 0.3f * num102;
								Main.gore[num105].alpha = 100;
							}
						}
						if (this.dJumpEffect4 && this.doubleJump4 && !this.jumpAgain4 && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
						{
							int num106 = this.height;
							if (this.gravDir == -1f)
							{
								num106 = -6;
							}
							int num107 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)num106), this.width + 8, 4, 188, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
							Main.dust[num107].velocity.X = Main.dust[num107].velocity.X * 0.5f - this.velocity.X * 0.1f;
							Main.dust[num107].velocity.Y = Main.dust[num107].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
							Main.dust[num107].velocity *= 0.5f;
						}
						if (this.dJumpEffect3 && this.doubleJump3 && !this.jumpAgain3 && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
						{
							int num108 = this.height - 6;
							if (this.gravDir == -1f)
							{
								num108 = 6;
							}
							for (int num109 = 0; num109 < 2; num109++)
							{
								int num110 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)num108), this.width, 12, 76, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 0, default(Color), 1f);
								Main.dust[num110].velocity *= 0.1f;
								if (num109 == 0)
								{
									Main.dust[num110].velocity += this.velocity * 0.03f;
								}
								else
								{
									Main.dust[num110].velocity -= this.velocity * 0.03f;
								}
								Main.dust[num110].noLight = true;
							}
							for (int num111 = 0; num111 < 3; num111++)
							{
								int num112 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)num108), this.width, 12, 76, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 0, default(Color), 1f);
								Main.dust[num112].fadeIn = 1.5f;
								Main.dust[num112].velocity *= 0.6f;
								Main.dust[num112].velocity += this.velocity * 0.8f;
								Main.dust[num112].noGravity = true;
								Main.dust[num112].noLight = true;
							}
							for (int num113 = 0; num113 < 3; num113++)
							{
								int num114 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)num108), this.width, 12, 76, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 0, default(Color), 1f);
								Main.dust[num114].fadeIn = 1.5f;
								Main.dust[num114].velocity *= 0.6f;
								Main.dust[num114].velocity -= this.velocity * 0.8f;
								Main.dust[num114].noGravity = true;
								Main.dust[num114].noLight = true;
							}
						}
						if (this.wings > 0)
						{
							this.sandStorm = false;
						}
						if (((this.gravDir == 1f && this.velocity.Y > -Player.jumpSpeed) || (this.gravDir == -1f && this.velocity.Y < Player.jumpSpeed)) && this.velocity.Y != 0f)
						{
							this.canRocket = true;
						}
						bool flag22 = false;
						if (this.velocity.Y == 0f || this.sliding)
						{
							if (this.mount == 1)
							{
								this.mountFlyTime = 160;
								this.mountFlyTime += (int)(Math.Abs(this.velocity.X) * 20f);
							}
							else
							{
								this.mountFlyTime = 0;
							}
							this.wingTime = (float)this.wingTimeMax;
						}
						if (this.wingsLogic > 0 && this.controlJump && this.wingTime > 0f && !this.jumpAgain && this.jump == 0 && this.velocity.Y != 0f)
						{
							flag22 = true;
						}
						if (this.frozen)
						{
							this.Dismount();
							this.velocity.Y = this.velocity.Y + num2;
							if (this.velocity.Y > num)
							{
								this.velocity.Y = num;
							}
							this.sandStorm = false;
							this.dJumpEffect = false;
							this.dJumpEffect2 = false;
							this.dJumpEffect3 = false;
						}
						else
						{
							if (flag22)
							{
								if (this.wings == 10 && Main.rand.Next(2) == 0)
								{
									int num115 = 4;
									if (this.direction == 1)
									{
										num115 = -40;
									}
									int num116 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num115, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 76, 0f, 0f, 50, default(Color), 0.6f);
									Main.dust[num116].fadeIn = 1.1f;
									Main.dust[num116].noGravity = true;
									Main.dust[num116].noLight = true;
									Main.dust[num116].velocity *= 0.3f;
								}
								if (this.wings == 9 && Main.rand.Next(2) == 0)
								{
									int num117 = 4;
									if (this.direction == 1)
									{
										num117 = -40;
									}
									int num118 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num117, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 6, 0f, 0f, 200, default(Color), 2f);
									Main.dust[num118].noGravity = true;
									Main.dust[num118].velocity *= 0.3f;
								}
								if (this.wings == 6 && Main.rand.Next(4) == 0)
								{
									int num119 = 4;
									if (this.direction == 1)
									{
										num119 = -40;
									}
									int num120 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num119, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 55, 0f, 0f, 200, default(Color), 1f);
									Main.dust[num120].velocity *= 0.3f;
								}
								if (this.wings == 5 && Main.rand.Next(3) == 0)
								{
									int num121 = 6;
									if (this.direction == 1)
									{
										num121 = -30;
									}
									int num122 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num121, this.position.Y), 18, this.height, 58, 0f, 0f, 255, default(Color), 1.2f);
									Main.dust[num122].velocity *= 0.3f;
								}
								if (this.wingsLogic == 4 && this.controlUp)
								{
									this.velocity.Y = this.velocity.Y - 0.2f * this.gravDir;
									if (this.gravDir == 1f)
									{
										if (this.velocity.Y > 0f)
										{
											this.velocity.Y = this.velocity.Y - 1f;
										}
										else if (this.velocity.Y > -Player.jumpSpeed)
										{
											this.velocity.Y = this.velocity.Y - 0.2f;
										}
										if (this.velocity.Y < -Player.jumpSpeed * 3f)
										{
											this.velocity.Y = -Player.jumpSpeed * 3f;
										}
									}
									else
									{
										if (this.velocity.Y < 0f)
										{
											this.velocity.Y = this.velocity.Y + 1f;
										}
										else if (this.velocity.Y < Player.jumpSpeed)
										{
											this.velocity.Y = this.velocity.Y + 0.2f;
										}
										if (this.velocity.Y > Player.jumpSpeed * 3f)
										{
											this.velocity.Y = Player.jumpSpeed * 3f;
										}
									}
									this.wingTime -= 2f;
								}
								else if (this.wingsLogic == 3 && this.controlUp)
								{
									this.velocity.Y = this.velocity.Y - 0.3f * this.gravDir;
									if (this.gravDir == 1f)
									{
										if (this.velocity.Y > 0f)
										{
											this.velocity.Y = this.velocity.Y - 1f;
										}
										else if (this.velocity.Y > -Player.jumpSpeed)
										{
											this.velocity.Y = this.velocity.Y - 0.2f;
										}
										if (this.velocity.Y < -Player.jumpSpeed * 3f)
										{
											this.velocity.Y = -Player.jumpSpeed * 3f;
										}
									}
									else
									{
										if (this.velocity.Y < 0f)
										{
											this.velocity.Y = this.velocity.Y + 1f;
										}
										else if (this.velocity.Y < Player.jumpSpeed)
										{
											this.velocity.Y = this.velocity.Y + 0.2f;
										}
										if (this.velocity.Y > Player.jumpSpeed * 3f)
										{
											this.velocity.Y = Player.jumpSpeed * 3f;
										}
									}
									this.wingTime -= 2f;
								}
								else
								{
									this.velocity.Y = this.velocity.Y - 0.1f * this.gravDir;
									if (this.gravDir == 1f)
									{
										if (this.velocity.Y > 0f)
										{
											this.velocity.Y = this.velocity.Y - 0.5f;
										}
										else if ((double)this.velocity.Y > (double)(-(double)Player.jumpSpeed) * 0.5)
										{
											this.velocity.Y = this.velocity.Y - 0.1f;
										}
										if (this.velocity.Y < -Player.jumpSpeed * 1.5f)
										{
											this.velocity.Y = -Player.jumpSpeed * 1.5f;
										}
									}
									else
									{
										if (this.velocity.Y < 0f)
										{
											this.velocity.Y = this.velocity.Y + 0.5f;
										}
										else if ((double)this.velocity.Y < (double)Player.jumpSpeed * 0.5)
										{
											this.velocity.Y = this.velocity.Y + 0.1f;
										}
										if (this.velocity.Y > Player.jumpSpeed * 1.5f)
										{
											this.velocity.Y = Player.jumpSpeed * 1.5f;
										}
									}
									if (this.wingsLogic == 22 && this.controlDown && !this.controlLeft && !this.controlRight)
									{
										this.wingTime -= 0.5f;
									}
									else
									{
										this.wingTime -= 1f;
									}
								}
							}
							if (this.wings == 4)
							{
								if (flag22 || this.jump > 0)
								{
									this.rocketDelay2--;
									if (this.rocketDelay2 <= 0)
									{
										Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 13);
										this.rocketDelay2 = 60;
									}
									int num123 = 2;
									if (this.controlUp)
									{
										num123 = 4;
									}
									for (int num124 = 0; num124 < num123; num124++)
									{
										int type3 = 6;
										if (this.head == 41)
										{
											int arg_8896_0 = this.body;
										}
										float scale = 1.75f;
										int alpha = 100;
										float x = this.position.X + (float)(this.width / 2) + 16f;
										if (this.direction > 0)
										{
											x = this.position.X + (float)(this.width / 2) - 26f;
										}
										float num125 = this.position.Y + (float)this.height - 18f;
										if (num124 == 1 || num124 == 3)
										{
											x = this.position.X + (float)(this.width / 2) + 8f;
											if (this.direction > 0)
											{
												x = this.position.X + (float)(this.width / 2) - 20f;
											}
											num125 += 6f;
										}
										if (num124 > 1)
										{
											num125 += this.velocity.Y;
										}
										int num126 = Dust.NewDust(new Vector2(x, num125), 8, 8, type3, 0f, 0f, alpha, default(Color), scale);
										Dust expr_89A9_cp_0 = Main.dust[num126];
										expr_89A9_cp_0.velocity.X = expr_89A9_cp_0.velocity.X * 0.1f;
										Main.dust[num126].velocity.Y = Main.dust[num126].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
										Main.dust[num126].noGravity = true;
										if (num123 == 4)
										{
											Dust expr_8A23_cp_0 = Main.dust[num126];
											expr_8A23_cp_0.velocity.Y = expr_8A23_cp_0.velocity.Y + 6f;
										}
									}
									this.wingFrameCounter++;
									if (this.wingFrameCounter > 4)
									{
										this.wingFrame++;
										this.wingFrameCounter = 0;
										if (this.wingFrame >= 3)
										{
											this.wingFrame = 0;
										}
									}
								}
								else if (!this.controlJump || this.velocity.Y == 0f)
								{
									this.wingFrame = 3;
								}
							}
							else if (this.wings == 22)
							{
								if (!this.controlJump)
								{
									this.wingFrame = 0;
									this.wingFrameCounter = 0;
								}
								else if (this.wingTime > 0f)
								{
									if (this.controlDown)
									{
										if (this.velocity.X != 0f)
										{
											this.wingFrameCounter++;
											int num127 = 2;
											if (this.wingFrameCounter < num127)
											{
												this.wingFrame = 1;
											}
											else if (this.wingFrameCounter < num127 * 2)
											{
												this.wingFrame = 2;
											}
											else if (this.wingFrameCounter < num127 * 3)
											{
												this.wingFrame = 3;
											}
											else if (this.wingFrameCounter < num127 * 4 - 1)
											{
												this.wingFrame = 2;
											}
											else
											{
												this.wingFrame = 2;
												this.wingFrameCounter = 0;
											}
										}
										else
										{
											this.wingFrameCounter++;
											int num128 = 6;
											if (this.wingFrameCounter < num128)
											{
												this.wingFrame = 4;
											}
											else if (this.wingFrameCounter < num128 * 2)
											{
												this.wingFrame = 5;
											}
											else if (this.wingFrameCounter < num128 * 3 - 1)
											{
												this.wingFrame = 4;
											}
											else
											{
												this.wingFrame = 4;
												this.wingFrameCounter = 0;
											}
										}
									}
									else
									{
										this.wingFrameCounter++;
										int num129 = 2;
										if (this.wingFrameCounter < num129)
										{
											this.wingFrame = 4;
										}
										else if (this.wingFrameCounter < num129 * 2)
										{
											this.wingFrame = 5;
										}
										else if (this.wingFrameCounter < num129 * 3)
										{
											this.wingFrame = 6;
										}
										else if (this.wingFrameCounter < num129 * 4 - 1)
										{
											this.wingFrame = 5;
										}
										else
										{
											this.wingFrame = 5;
											this.wingFrameCounter = 0;
										}
									}
								}
								else
								{
									this.wingFrameCounter++;
									int num130 = 6;
									if (this.wingFrameCounter < num130)
									{
										this.wingFrame = 4;
									}
									else if (this.wingFrameCounter < num130 * 2)
									{
										this.wingFrame = 5;
									}
									else if (this.wingFrameCounter < num130 * 3 - 1)
									{
										this.wingFrame = 4;
									}
									else
									{
										this.wingFrame = 4;
										this.wingFrameCounter = 0;
									}
								}
							}
							else if (this.wings == 12)
							{
								if (flag22 || this.jump > 0)
								{
									this.wingFrameCounter++;
									int num131 = 5;
									if (this.wingFrameCounter < num131)
									{
										this.wingFrame = 1;
									}
									else if (this.wingFrameCounter < num131 * 2)
									{
										this.wingFrame = 2;
									}
									else if (this.wingFrameCounter < num131 * 3)
									{
										this.wingFrame = 3;
									}
									else if (this.wingFrameCounter < num131 * 4 - 1)
									{
										this.wingFrame = 2;
									}
									else
									{
										this.wingFrame = 2;
										this.wingFrameCounter = 0;
									}
								}
								else if (this.velocity.Y != 0f)
								{
									this.wingFrame = 2;
								}
								else
								{
									this.wingFrame = 0;
								}
							}
							else if (this.wings == 24)
							{
								if (flag22 || this.jump > 0)
								{
									this.wingFrameCounter++;
									int num132 = 1;
									if (this.wingFrameCounter < num132)
									{
										this.wingFrame = 1;
									}
									else if (this.wingFrameCounter < num132 * 2)
									{
										this.wingFrame = 2;
									}
									else if (this.wingFrameCounter < num132 * 3)
									{
										this.wingFrame = 3;
									}
									else
									{
										this.wingFrame = 2;
										if (this.wingFrameCounter >= num132 * 4 - 1)
										{
											this.wingFrameCounter = 0;
										}
									}
								}
								else if (this.velocity.Y != 0f)
								{
									if (this.controlJump)
									{
										this.wingFrameCounter++;
										int num133 = 3;
										if (this.wingFrameCounter < num133)
										{
											this.wingFrame = 1;
										}
										else if (this.wingFrameCounter < num133 * 2)
										{
											this.wingFrame = 2;
										}
										else if (this.wingFrameCounter < num133 * 3)
										{
											this.wingFrame = 3;
										}
										else
										{
											this.wingFrame = 2;
											if (this.wingFrameCounter >= num133 * 4 - 1)
											{
												this.wingFrameCounter = 0;
											}
										}
									}
									else if (this.wingTime == 0f)
									{
										this.wingFrame = 0;
									}
									else
									{
										this.wingFrame = 1;
									}
								}
								else
								{
									this.wingFrame = 0;
								}
							}
							else if (flag22 || this.jump > 0)
							{
								this.wingFrameCounter++;
								if (this.wingFrameCounter > 4)
								{
									this.wingFrame++;
									this.wingFrameCounter = 0;
									if (this.wingFrame >= 4)
									{
										this.wingFrame = 0;
									}
								}
							}
							else if (this.velocity.Y != 0f)
							{
								this.wingFrame = 1;
							}
							else
							{
								this.wingFrame = 0;
							}
							if (this.wingsLogic > 0 && this.rocketBoots > 0)
							{
								this.wingTime += (float)(this.rocketTime * 3);
								this.rocketTime = 0;
							}
							if (flag22 && this.wings != 4 && this.wings != 22 && this.wings != 0 && this.wings != 24)
							{
								if (this.wingFrame == 3)
								{
									if (!this.flapSound)
									{
										Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 32);
									}
									this.flapSound = true;
								}
								else
								{
									this.flapSound = false;
								}
							}
							if (this.velocity.Y == 0f || this.sliding)
							{
								this.rocketTime = this.rocketTimeMax;
							}
							if ((this.wingTime == 0f || this.wingsLogic == 0) && this.rocketBoots > 0 && this.controlJump && this.rocketDelay == 0 && this.canRocket && this.rocketRelease && !this.jumpAgain)
							{
								if (this.rocketTime > 0)
								{
									this.rocketTime--;
									this.rocketDelay = 10;
									if (this.rocketDelay2 <= 0)
									{
										if (this.rocketBoots == 1)
										{
											Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 13);
											this.rocketDelay2 = 30;
										}
										else if (this.rocketBoots == 2 || this.rocketBoots == 3)
										{
											Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 24);
											this.rocketDelay2 = 15;
										}
									}
								}
								else
								{
									this.canRocket = false;
								}
							}
							if (this.rocketDelay2 > 0)
							{
								this.rocketDelay2--;
							}
							if (this.rocketDelay == 0)
							{
								this.rocketFrame = false;
							}
							if (this.rocketDelay > 0)
							{
								int num134 = this.height;
								if (this.gravDir == -1f)
								{
									num134 = 4;
								}
								this.rocketFrame = true;
								for (int num135 = 0; num135 < 2; num135++)
								{
									int type4 = 6;
									float scale2 = 2.5f;
									int alpha2 = 100;
									if (this.rocketBoots == 2)
									{
										type4 = 16;
										scale2 = 1.5f;
										alpha2 = 20;
									}
									else if (this.rocketBoots == 3)
									{
										type4 = 76;
										scale2 = 1f;
										alpha2 = 20;
									}
									else if (this.socialShadow)
									{
										type4 = 27;
										scale2 = 1.5f;
									}
									if (num135 == 0)
									{
										int num136 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)num134 - 10f), 8, 8, type4, 0f, 0f, alpha2, default(Color), scale2);
										if (this.rocketBoots == 1)
										{
											Main.dust[num136].noGravity = true;
										}
										Main.dust[num136].velocity.X = Main.dust[num136].velocity.X * 1f - 2f - this.velocity.X * 0.3f;
										Main.dust[num136].velocity.Y = Main.dust[num136].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
										if (this.rocketBoots == 2)
										{
											Main.dust[num136].velocity *= 0.1f;
										}
										if (this.rocketBoots == 3)
										{
											Main.dust[num136].velocity *= 0.05f;
											Dust expr_9338_cp_0 = Main.dust[num136];
											expr_9338_cp_0.velocity.Y = expr_9338_cp_0.velocity.Y + 0.15f;
											Main.dust[num136].noLight = true;
											if (Main.rand.Next(2) == 0)
											{
												Main.dust[num136].noGravity = true;
												Main.dust[num136].scale = 1.75f;
											}
										}
									}
									else
									{
										int num137 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 4f, this.position.Y + (float)num134 - 10f), 8, 8, type4, 0f, 0f, alpha2, default(Color), scale2);
										if (this.rocketBoots == 1)
										{
											Main.dust[num137].noGravity = true;
										}
										Main.dust[num137].velocity.X = Main.dust[num137].velocity.X * 1f + 2f - this.velocity.X * 0.3f;
										Main.dust[num137].velocity.Y = Main.dust[num137].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
										if (this.rocketBoots == 2)
										{
											Main.dust[num137].velocity *= 0.1f;
										}
										if (this.rocketBoots == 3)
										{
											Main.dust[num137].velocity *= 0.05f;
											Dust expr_94E1_cp_0 = Main.dust[num137];
											expr_94E1_cp_0.velocity.Y = expr_94E1_cp_0.velocity.Y + 0.15f;
											Main.dust[num137].noLight = true;
											if (Main.rand.Next(2) == 0)
											{
												Main.dust[num137].noGravity = true;
												Main.dust[num137].scale = 1.75f;
											}
										}
									}
								}
								if (this.rocketDelay == 0)
								{
									this.releaseJump = true;
								}
								this.rocketDelay--;
								this.velocity.Y = this.velocity.Y - 0.1f * this.gravDir;
								if (this.gravDir == 1f)
								{
									if (this.velocity.Y > 0f)
									{
										this.velocity.Y = this.velocity.Y - 0.5f;
									}
									else if ((double)this.velocity.Y > (double)(-(double)Player.jumpSpeed) * 0.5)
									{
										this.velocity.Y = this.velocity.Y - 0.1f;
									}
									if (this.velocity.Y < -Player.jumpSpeed * 1.5f)
									{
										this.velocity.Y = -Player.jumpSpeed * 1.5f;
									}
								}
								else
								{
									if (this.velocity.Y < 0f)
									{
										this.velocity.Y = this.velocity.Y + 0.5f;
									}
									else if ((double)this.velocity.Y < (double)Player.jumpSpeed * 0.5)
									{
										this.velocity.Y = this.velocity.Y + 0.1f;
									}
									if (this.velocity.Y > Player.jumpSpeed * 1.5f)
									{
										this.velocity.Y = Player.jumpSpeed * 1.5f;
									}
								}
							}
							else if (!flag22)
							{
								if (this.mount == 1 && this.controlJump && this.jump == 0)
								{
									if (this.mountFlyTime > 0)
									{
										this.mountFlyTime--;
										if (this.controlDown)
										{
											this.velocity.Y = this.velocity.Y * 0.9f;
											if (this.velocity.Y > -1f && (double)this.velocity.Y < 0.5)
											{
												this.velocity.Y = 1E-05f;
											}
										}
										else
										{
											if (this.velocity.Y > 0f)
											{
												this.velocity.Y = this.velocity.Y - 0.5f;
											}
											else if ((double)this.velocity.Y > (double)(-(double)Player.jumpSpeed) * 1.5)
											{
												this.velocity.Y = this.velocity.Y - 0.1f;
											}
											if (this.velocity.Y < -Player.jumpSpeed * 1.5f)
											{
												this.velocity.Y = -Player.jumpSpeed * 1.5f;
											}
										}
									}
									else
									{
										this.velocity.Y = this.velocity.Y + num2 / 3f * this.gravDir;
										if (this.gravDir == 1f)
										{
											if (this.velocity.Y > num / 3f && !this.controlDown)
											{
												this.velocity.Y = num / 3f;
											}
										}
										else if (this.velocity.Y < -num / 3f && !this.controlUp)
										{
											this.velocity.Y = -num / 3f;
										}
									}
								}
								else if (this.slowFall && ((!this.controlDown && this.gravDir == 1f) || (!this.controlDown && this.gravDir == -1f)))
								{
									if ((this.controlUp && this.gravDir == 1f) || (this.controlUp && this.gravDir == -1f))
									{
										num2 = num2 / 10f * this.gravDir;
									}
									else
									{
										num2 = num2 / 3f * this.gravDir;
									}
									this.velocity.Y = this.velocity.Y + num2;
								}
								else if (this.wingsLogic > 0 && this.controlJump && this.velocity.Y > 0f)
								{
									this.fallStart = (int)(this.position.Y / 16f);
									if (this.velocity.Y > 0f)
									{
										if (this.wings == 10 && Main.rand.Next(3) == 0)
										{
											int num138 = 4;
											if (this.direction == 1)
											{
												num138 = -40;
											}
											int num139 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num138, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 76, 0f, 0f, 50, default(Color), 0.6f);
											Main.dust[num139].fadeIn = 1.1f;
											Main.dust[num139].noGravity = true;
											Main.dust[num139].noLight = true;
											Main.dust[num139].velocity *= 0.3f;
										}
										if (this.wings == 9 && Main.rand.Next(3) == 0)
										{
											int num140 = 8;
											if (this.direction == 1)
											{
												num140 = -40;
											}
											int num141 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num140, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 6, 0f, 0f, 200, default(Color), 2f);
											Main.dust[num141].noGravity = true;
											Main.dust[num141].velocity *= 0.3f;
										}
										if (this.wings == 6)
										{
											if (Main.rand.Next(10) == 0)
											{
												int num142 = 4;
												if (this.direction == 1)
												{
													num142 = -40;
												}
												int num143 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num142, this.position.Y + (float)(this.height / 2) - 12f), 30, 20, 55, 0f, 0f, 200, default(Color), 1f);
												Main.dust[num143].velocity *= 0.3f;
											}
										}
										else if (this.wings == 5 && Main.rand.Next(6) == 0)
										{
											int num144 = 6;
											if (this.direction == 1)
											{
												num144 = -30;
											}
											int num145 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num144, this.position.Y), 18, this.height, 58, 0f, 0f, 255, default(Color), 1.2f);
											Main.dust[num145].velocity *= 0.3f;
										}
										if (this.wings == 4)
										{
											this.rocketDelay2--;
											if (this.rocketDelay2 <= 0)
											{
												Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 13);
												this.rocketDelay2 = 60;
											}
											int type5 = 6;
											float scale3 = 1.5f;
											int alpha3 = 100;
											float x2 = this.position.X + (float)(this.width / 2) + 16f;
											if (this.direction > 0)
											{
												x2 = this.position.X + (float)(this.width / 2) - 26f;
											}
											float num146 = this.position.Y + (float)this.height - 18f;
											if (Main.rand.Next(2) == 1)
											{
												x2 = this.position.X + (float)(this.width / 2) + 8f;
												if (this.direction > 0)
												{
													x2 = this.position.X + (float)(this.width / 2) - 20f;
												}
												num146 += 6f;
											}
											int num147 = Dust.NewDust(new Vector2(x2, num146), 8, 8, type5, 0f, 0f, alpha3, default(Color), scale3);
											Dust expr_9DCC_cp_0 = Main.dust[num147];
											expr_9DCC_cp_0.velocity.X = expr_9DCC_cp_0.velocity.X * 0.3f;
											Dust expr_9DEA_cp_0 = Main.dust[num147];
											expr_9DEA_cp_0.velocity.Y = expr_9DEA_cp_0.velocity.Y + 10f;
											Main.dust[num147].noGravity = true;
											this.wingFrameCounter++;
											if (this.wingFrameCounter > 4)
											{
												this.wingFrame++;
												this.wingFrameCounter = 0;
												if (this.wingFrame >= 3)
												{
													this.wingFrame = 0;
												}
											}
										}
										else if (this.wings != 22 && this.wings != 24)
										{
											if (this.wings == 12)
											{
												this.wingFrame = 3;
											}
											else
											{
												this.wingFrame = 2;
											}
										}
									}
									this.velocity.Y = this.velocity.Y + num2 / 3f * this.gravDir;
									if (this.gravDir == 1f)
									{
										if (this.velocity.Y > num / 3f && !this.controlDown)
										{
											this.velocity.Y = num / 3f;
										}
									}
									else if (this.velocity.Y < -num / 3f && !this.controlUp)
									{
										this.velocity.Y = -num / 3f;
									}
								}
								else
								{
									this.velocity.Y = this.velocity.Y + num2 * this.gravDir;
								}
							}
							if (this.gravDir == 1f)
							{
								if (this.velocity.Y > num)
								{
									this.velocity.Y = num;
								}
								if (this.slowFall && this.velocity.Y > num / 3f && !this.controlDown)
								{
									this.velocity.Y = num / 3f;
								}
								if (this.slowFall && this.velocity.Y > num / 5f && this.controlUp)
								{
									this.velocity.Y = num / 10f;
								}
							}
							else
							{
								if (this.velocity.Y < -num)
								{
									this.velocity.Y = -num;
								}
								if (this.slowFall && this.velocity.Y < -num / 3f && !this.controlDown)
								{
									this.velocity.Y = -num / 3f;
								}
								if (this.slowFall && this.velocity.Y < -num / 5f && this.controlUp)
								{
									this.velocity.Y = -num / 10f;
								}
							}
						}
					}
					if (this.wingsLogic == 3)
					{
						if (this.controlUp && this.controlDown)
						{
							this.velocity.Y = 0f;
						}
						else if (this.controlDown && this.controlJump)
						{
							this.velocity.Y = this.velocity.Y * 0.9f;
							if (this.velocity.Y > -2f && this.velocity.Y < 1f)
							{
								this.velocity.Y = 1E-05f;
							}
						}
						else if (this.controlDown && this.velocity.Y != 0f)
						{
							this.velocity.Y = this.velocity.Y + 0.2f;
						}
					}
					if (this.wingsLogic == 22 && this.controlDown && this.controlJump && this.wingTime > 0f)
					{
						this.velocity.Y = this.velocity.Y * 0.9f;
						if (this.velocity.Y > -2f && this.velocity.Y < 1f)
						{
							this.velocity.Y = 1E-05f;
						}
					}
					for (int num148 = 0; num148 < 400; num148++)
					{
						if (Main.item[num148].active && Main.item[num148].noGrabDelay == 0 && Main.item[num148].owner == i)
						{
							int num149 = Player.defaultItemGrabRange;
							if (this.manaMagnet && (Main.item[num148].type == 184 || Main.item[num148].type == 1735 || Main.item[num148].type == 1868))
							{
								num149 += Item.manaGrabRange;
							}
							if (new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height).Intersects(new Rectangle((int)Main.item[num148].position.X, (int)Main.item[num148].position.Y, Main.item[num148].width, Main.item[num148].height)))
							{
								if (i == Main.myPlayer && (this.inventory[this.selectedItem].type != 0 || this.itemAnimation <= 0))
								{
									if (Main.item[num148].type == 58 || Main.item[num148].type == 1734 || Main.item[num148].type == 1867)
									{
										Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
										this.statLife += 20;
										if (this.statLife > this.statLifeMax)
										{
											this.statLife = this.statLifeMax;
										}
										Main.item[num148] = new Item();
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num148, 0f, 0f, 0f, 0);
										}
									}
									else if (Main.item[num148].type == 184 || Main.item[num148].type == 1735 || Main.item[num148].type == 1868)
									{
										Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
										this.statMana += 100;
										if (this.statMana > this.statManaMax2)
										{
											this.statMana = this.statManaMax2;
										}
										Main.item[num148] = new Item();
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num148, 0f, 0f, 0f, 0);
										}
									}
									else
									{
										Main.item[num148] = this.GetItem(i, Main.item[num148]);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num148, 0f, 0f, 0f, 0);
										}
									}
								}
							}
							else if (new Rectangle((int)this.position.X - num149, (int)this.position.Y - num149, this.width + num149 * 2, this.height + num149 * 2).Intersects(new Rectangle((int)Main.item[num148].position.X, (int)Main.item[num148].position.Y, Main.item[num148].width, Main.item[num148].height)) && this.ItemSpace(Main.item[num148]))
							{
								Main.item[num148].beingGrabbed = true;
								if (this.manaMagnet && (Main.item[num148].type == 184 || Main.item[num148].type == 1735 || Main.item[num148].type == 1868))
								{
									float num150 = 12f;
									Vector2 vector = new Vector2(Main.item[num148].position.X + (float)(Main.item[num148].width / 2), Main.item[num148].position.Y + (float)(Main.item[num148].height / 2));
									float num151 = this.center().X - vector.X;
									float num152 = this.center().Y - vector.Y;
									float num153 = (float)Math.Sqrt((double)(num151 * num151 + num152 * num152));
									num153 = num150 / num153;
									num151 *= num153;
									num152 *= num153;
									int num154 = 5;
									Main.item[num148].velocity.X = (Main.item[num148].velocity.X * (float)(num154 - 1) + num151) / (float)num154;
									Main.item[num148].velocity.Y = (Main.item[num148].velocity.Y * (float)(num154 - 1) + num152) / (float)num154;
								}
								else
								{
									if ((double)this.position.X + (double)this.width * 0.5 > (double)Main.item[num148].position.X + (double)Main.item[num148].width * 0.5)
									{
										if (Main.item[num148].velocity.X < Player.itemGrabSpeedMax + this.velocity.X)
										{
											Item expr_A742_cp_0 = Main.item[num148];
											expr_A742_cp_0.velocity.X = expr_A742_cp_0.velocity.X + Player.itemGrabSpeed;
										}
										if (Main.item[num148].velocity.X < 0f)
										{
											Item expr_A77C_cp_0 = Main.item[num148];
											expr_A77C_cp_0.velocity.X = expr_A77C_cp_0.velocity.X + Player.itemGrabSpeed * 0.75f;
										}
									}
									else
									{
										if (Main.item[num148].velocity.X > -Player.itemGrabSpeedMax + this.velocity.X)
										{
											Item expr_A7CB_cp_0 = Main.item[num148];
											expr_A7CB_cp_0.velocity.X = expr_A7CB_cp_0.velocity.X - Player.itemGrabSpeed;
										}
										if (Main.item[num148].velocity.X > 0f)
										{
											Item expr_A802_cp_0 = Main.item[num148];
											expr_A802_cp_0.velocity.X = expr_A802_cp_0.velocity.X - Player.itemGrabSpeed * 0.75f;
										}
									}
									if ((double)this.position.Y + (double)this.height * 0.5 > (double)Main.item[num148].position.Y + (double)Main.item[num148].height * 0.5)
									{
										if (Main.item[num148].velocity.Y < Player.itemGrabSpeedMax)
										{
											Item expr_A88B_cp_0 = Main.item[num148];
											expr_A88B_cp_0.velocity.Y = expr_A88B_cp_0.velocity.Y + Player.itemGrabSpeed;
										}
										if (Main.item[num148].velocity.Y < 0f)
										{
											Item expr_A8C5_cp_0 = Main.item[num148];
											expr_A8C5_cp_0.velocity.Y = expr_A8C5_cp_0.velocity.Y + Player.itemGrabSpeed * 0.75f;
										}
									}
									else
									{
										if (Main.item[num148].velocity.Y > -Player.itemGrabSpeedMax)
										{
											Item expr_A905_cp_0 = Main.item[num148];
											expr_A905_cp_0.velocity.Y = expr_A905_cp_0.velocity.Y - Player.itemGrabSpeed;
										}
										if (Main.item[num148].velocity.Y > 0f)
										{
											Item expr_A93C_cp_0 = Main.item[num148];
											expr_A93C_cp_0.velocity.Y = expr_A93C_cp_0.velocity.Y - Player.itemGrabSpeed * 0.75f;
										}
									}
								}
							}
						}
					}
					if (this.tongued)
					{
						bool flag27 = false;
						if (Main.wof >= 0)
						{
							float num223 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2);
							num223 += (float)(Main.npc[Main.wof].direction * 200);
							float num224 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2);
							Vector2 vector3 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num225 = num223 - vector3.X;
							float num226 = num224 - vector3.Y;
							float num227 = (float)Math.Sqrt((double)(num225 * num225 + num226 * num226));
							float num228 = 11f;
							float num229;
							if (num227 > num228)
							{
								num229 = num228 / num227;
							}
							else
							{
								num229 = 1f;
								flag27 = true;
							}
							num225 *= num229;
							num226 *= num229;
							this.velocity.X = num225;
							this.velocity.Y = num226;
						}
						else
						{
							flag27 = true;
						}
						if (flag27 && Main.myPlayer == this.whoAmi)
						{
							for (int num230 = 0; num230 < 22; num230++)
							{
								if (this.buffType[num230] == 38)
								{
									this.DelBuff(num230);
								}
							}
						}
					}
					if (this.controlRight)
					{
						this.releaseRight = false;
					}
					else
					{
						this.releaseRight = true;
						this.rightTimer = 7;
					}
					if (this.controlLeft)
					{
						this.releaseLeft = false;
					}
					else
					{
						this.releaseLeft = true;
						this.leftTimer = 7;
					}
					if (this.rightTimer > 0)
					{
						this.rightTimer--;
					}
					else if (this.controlRight)
					{
						this.rightTimer = 7;
					}
					if (this.leftTimer > 0)
					{
						this.leftTimer--;
					}
					else if (this.controlLeft)
					{
						this.leftTimer = 7;
					}
					if (this.grappling[0] >= 0)
					{
						if (Main.myPlayer == this.whoAmi && this.mount > 0)
						{
							this.Dismount();
						}
						this.canCarpet = true;
						this.carpetFrame = -1;
						this.wingFrame = 1;
						if (this.velocity.Y == 0f || (this.wet && (double)this.velocity.Y > -0.02 && (double)this.velocity.Y < 0.02))
						{
							this.wingFrame = 0;
						}
						if (this.wings == 4)
						{
							this.wingFrame = 3;
						}
						this.wingTime = (float)this.wingTimeMax;
						this.rocketTime = this.rocketTimeMax;
						this.rocketDelay = 0;
						this.rocketFrame = false;
						this.canRocket = false;
						this.rocketRelease = false;
						this.fallStart = (int)(this.position.Y / 16f);
						float num242 = 0f;
						float num243 = 0f;
						for (int num244 = 0; num244 < this.grapCount; num244++)
						{
							num242 += Main.projectile[this.grappling[num244]].position.X + (float)(Main.projectile[this.grappling[num244]].width / 2);
							num243 += Main.projectile[this.grappling[num244]].position.Y + (float)(Main.projectile[this.grappling[num244]].height / 2);
						}
						num242 /= (float)this.grapCount;
						num243 /= (float)this.grapCount;
						Vector2 vector6 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num245 = num242 - vector6.X;
						float num246 = num243 - vector6.Y;
						float num247 = (float)Math.Sqrt((double)(num245 * num245 + num246 * num246));
						float num248 = 11f;
						if (Main.projectile[this.grappling[0]].type == 315)
						{
							num248 = 16f;
						}
						float num249;
						if (num247 > num248)
						{
							num249 = num248 / num247;
						}
						else
						{
							num249 = 1f;
						}
						num245 *= num249;
						num246 *= num249;
						this.velocity.X = num245;
						this.velocity.Y = num246;
						if (this.itemAnimation == 0)
						{
							if (this.velocity.X > 0f)
							{
								this.ChangeDir(1);
							}
							if (this.velocity.X < 0f)
							{
								this.ChangeDir(-1);
							}
						}
						if (this.controlJump)
						{
							if (this.releaseJump)
							{
								if ((this.velocity.Y == 0f || (this.wet && (double)this.velocity.Y > -0.02 && (double)this.velocity.Y < 0.02)) && !this.controlDown)
								{
									this.velocity.Y = -Player.jumpSpeed;
									this.jump = Player.jumpHeight / 2;
									this.releaseJump = false;
								}
								else
								{
									this.velocity.Y = this.velocity.Y + 0.01f;
									this.releaseJump = false;
								}
								if (this.doubleJump)
								{
									this.jumpAgain = true;
								}
								if (this.doubleJump2)
								{
									this.jumpAgain2 = true;
								}
								if (this.doubleJump3)
								{
									this.jumpAgain3 = true;
								}
								if (this.doubleJump4)
								{
									this.jumpAgain4 = true;
								}
								this.grappling[0] = 0;
								this.grapCount = 0;
								for (int num250 = 0; num250 < 1000; num250++)
								{
									if (Main.projectile[num250].active && Main.projectile[num250].owner == i && Main.projectile[num250].aiStyle == 7)
									{
										Main.projectile[num250].Kill();
									}
								}
							}
						}
						else
						{
							this.releaseJump = true;
						}
					}
					int num251 = this.width / 2;
					int num252 = this.height / 2;
					new Vector2(this.position.X + (float)(this.width / 2) - (float)(num251 / 2), this.position.Y + (float)(this.height / 2) - (float)(num252 / 2));
					Vector2 vector7 = Collision.StickyTiles(this.position, this.velocity, this.width, this.height);
					if (vector7.Y != -1f && vector7.X != -1f)
					{
						int num253 = (int)vector7.X;
						int num254 = (int)vector7.Y;
						int type7 = (int)Main.tile[num253, num254].type;
						if (this.whoAmi == Main.myPlayer && type7 == 51 && (this.velocity.X != 0f || this.velocity.Y != 0f))
						{
							this.stickyBreak++;
							if (this.stickyBreak > Main.rand.Next(20, 100))
							{
								this.stickyBreak = 0;
								WorldGen.KillTile(num253, num254, false, false, false);
								if (Main.netMode == 1 && !Main.tile[num253, num254].active() && Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 0, (float)num253, (float)num254, 0f, 0);
								}
							}
						}
						this.fallStart = (int)(this.position.Y / 16f);
						if (type7 != 229)
						{
							this.jump = 0;
						}
						if (this.velocity.X > 1f)
						{
							this.velocity.X = 1f;
						}
						if (this.velocity.X < -1f)
						{
							this.velocity.X = -1f;
						}
						if (this.velocity.Y > 1f)
						{
							this.velocity.Y = 1f;
						}
						if (this.velocity.Y < -5f)
						{
							this.velocity.Y = -5f;
						}
						if ((double)this.velocity.X > 0.75 || (double)this.velocity.X < -0.75)
						{
							this.velocity.X = this.velocity.X * 0.85f;
						}
						else
						{
							this.velocity.X = this.velocity.X * 0.6f;
						}
						if (this.velocity.Y < 0f)
						{
							this.velocity.Y = this.velocity.Y * 0.96f;
						}
						else
						{
							this.velocity.Y = this.velocity.Y * 0.3f;
						}
						if (type7 == 229 && Main.rand.Next(5) == 0 && ((double)this.velocity.Y > 0.15 || this.velocity.Y < 0f))
						{
							if ((float)(num253 * 16) < this.position.X + (float)(this.width / 2))
							{
								int num255 = Dust.NewDust(new Vector2(this.position.X - 4f, (float)(num254 * 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
								Main.dust[num255].scale += (float)Main.rand.Next(0, 6) * 0.1f;
								Main.dust[num255].velocity *= 0.1f;
								Main.dust[num255].noGravity = true;
							}
							else
							{
								int num256 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 2f, (float)(num254 * 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
								Main.dust[num256].scale += (float)Main.rand.Next(0, 6) * 0.1f;
								Main.dust[num256].velocity *= 0.1f;
								Main.dust[num256].noGravity = true;
							}
							if (Main.tile[num253, num254 + 1] != null && Main.tile[num253, num254 + 1].type == 229 && this.position.Y + (float)this.height > (float)((num254 + 1) * 16))
							{
								if ((float)(num253 * 16) < this.position.X + (float)(this.width / 2))
								{
									int num257 = Dust.NewDust(new Vector2(this.position.X - 4f, (float)(num254 * 16 + 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num257].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num257].velocity *= 0.1f;
									Main.dust[num257].noGravity = true;
								}
								else
								{
									int num258 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 2f, (float)(num254 * 16 + 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num258].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num258].velocity *= 0.1f;
									Main.dust[num258].noGravity = true;
								}
							}
							if (Main.tile[num253, num254 + 2] != null && Main.tile[num253, num254 + 2].type == 229 && this.position.Y + (float)this.height > (float)((num254 + 2) * 16))
							{
								if ((float)(num253 * 16) < this.position.X + (float)(this.width / 2))
								{
									int num259 = Dust.NewDust(new Vector2(this.position.X - 4f, (float)(num254 * 16 + 32)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num259].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num259].velocity *= 0.1f;
									Main.dust[num259].noGravity = true;
								}
								else
								{
									int num260 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 2f, (float)(num254 * 16 + 32)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num260].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num260].velocity *= 0.1f;
									Main.dust[num260].noGravity = true;
								}
							}
						}
					}
					else
					{
						this.stickyBreak = 0;
					}
					bool flag28 = Collision.DrownCollision(this.position, this.width, this.height, this.gravDir);
					if (this.armor[0].type == 250)
					{
						flag28 = true;
					}
					if (this.inventory[this.selectedItem].type == 186)
					{
						try
						{
							int num261 = (int)((this.position.X + (float)(this.width / 2) + (float)(6 * this.direction)) / 16f);
							int num262 = 0;
							if (this.gravDir == -1f)
							{
								num262 = this.height;
							}
							int num263 = (int)((this.position.Y + (float)num262 - 44f * this.gravDir) / 16f);
							if (Main.tile[num261, num263].liquid < 128)
							{
								if (Main.tile[num261, num263] == null)
								{
									Main.tile[num261, num263] = new Tile();
								}
								if (!Main.tile[num261, num263].active() || !Main.tileSolid[(int)Main.tile[num261, num263].type] || Main.tileSolidTop[(int)Main.tile[num261, num263].type])
								{
									flag28 = false;
								}
							}
						}
						catch
						{
						}
					}
					if (this.gills)
					{
						flag28 = false;
					}
					if (Main.myPlayer == i)
					{
						if (this.merman)
						{
							flag28 = false;
						}
						if (flag28)
						{
							this.breathCD++;
							int num264 = 7;
							if (this.inventory[this.selectedItem].type == 186)
							{
								num264 *= 2;
							}
							if (this.accDivingHelm)
							{
								num264 *= 4;
							}
							if (this.breathCD >= num264)
							{
								this.breathCD = 0;
								this.breath--;
								if (this.breath == 0)
								{
									Main.PlaySound(23, -1, -1, 1);
								}
								if (this.breath <= 0)
								{
									this.lifeRegenTime = 0;
									this.breath = 0;
									this.statLife -= 2;
									if (this.statLife <= 0)
									{
										this.statLife = 0;
										this.KillMe(10.0, 0, false, Lang.deathMsg(-1, -1, -1, 1));
									}
								}
							}
						}
						else
						{
							this.breath += 3;
							if (this.breath > this.breathMax)
							{
								this.breath = this.breathMax;
							}
							this.breathCD = 0;
						}
					}
					if (flag28 && Main.rand.Next(20) == 0 && !this.lavaWet && !this.honeyWet)
					{
						int num265 = 0;
						if (this.gravDir == -1f)
						{
							num265 += this.height - 12;
						}
						if (this.inventory[this.selectedItem].type == 186)
						{
							Dust.NewDust(new Vector2(this.position.X + (float)(10 * this.direction) + 4f, this.position.Y + (float)num265 - 54f * this.gravDir), this.width - 8, 8, 34, 0f, 0f, 0, default(Color), 1.2f);
						}
						else
						{
							Dust.NewDust(new Vector2(this.position.X + (float)(12 * this.direction), this.position.Y + (float)num265 + 4f * this.gravDir), this.width - 8, 8, 34, 0f, 0f, 0, default(Color), 1.2f);
						}
					}
					if (this.gravDir == -1f)
					{
						this.waterWalk = false;
						this.waterWalk2 = false;
					}
					int num266 = this.height;
					if (this.waterWalk)
					{
						num266 -= 6;
					}
					bool flag29 = Collision.LavaCollision(this.position, this.width, num266);
					if (flag29)
					{
						if (!this.lavaImmune && Main.myPlayer == i && !this.immune)
						{
							if (this.lavaTime > 0)
							{
								this.lavaTime--;
							}
							else if (this.lavaRose)
							{
								this.Hurt(50, 0, false, false, Lang.deathMsg(-1, -1, -1, 2), false);
								this.AddBuff(24, 210, true);
							}
							else
							{
								this.Hurt(80, 0, false, false, Lang.deathMsg(-1, -1, -1, 2), false);
								this.AddBuff(24, 420, true);
							}
						}
						this.lavaWet = true;
					}
					else
					{
						this.lavaWet = false;
						if (this.lavaTime < this.lavaMax)
						{
							this.lavaTime++;
						}
					}
					if (this.lavaTime > this.lavaMax)
					{
						this.lavaTime = this.lavaMax;
					}
					if (this.waterWalk2 && !this.waterWalk)
					{
						num266 -= 6;
					}
					bool flag30 = Collision.WetCollision(this.position, this.width, this.height);
					bool flag31 = Collision.honey;
					if (flag31)
					{
						this.AddBuff(48, 1800, true);
						this.honeyWet = true;
					}
					if (flag30)
					{
						if (this.onFire && !this.lavaWet)
						{
							for (int num267 = 0; num267 < 22; num267++)
							{
								if (this.buffType[num267] == 24)
								{
									this.DelBuff(num267);
								}
							}
						}
						if (!this.wet)
						{
							if (this.wetCount == 0)
							{
								this.wetCount = 10;
								if (!flag29)
								{
									if (this.honeyWet)
									{
										for (int num268 = 0; num268 < 20; num268++)
										{
											int num269 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 152, 0f, 0f, 0, default(Color), 1f);
											Dust expr_F3AF_cp_0 = Main.dust[num269];
											expr_F3AF_cp_0.velocity.Y = expr_F3AF_cp_0.velocity.Y - 1f;
											Dust expr_F3CF_cp_0 = Main.dust[num269];
											expr_F3CF_cp_0.velocity.X = expr_F3CF_cp_0.velocity.X * 2.5f;
											Main.dust[num269].scale = 1.3f;
											Main.dust[num269].alpha = 100;
											Main.dust[num269].noGravity = true;
										}
										Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
									}
									else
									{
										for (int num270 = 0; num270 < 50; num270++)
										{
											int num271 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, Dust.dustWater(), 0f, 0f, 0, default(Color), 1f);
											Dust expr_F4D0_cp_0 = Main.dust[num271];
											expr_F4D0_cp_0.velocity.Y = expr_F4D0_cp_0.velocity.Y - 3f;
											Dust expr_F4F0_cp_0 = Main.dust[num271];
											expr_F4F0_cp_0.velocity.X = expr_F4F0_cp_0.velocity.X * 2.5f;
											Main.dust[num271].scale = 0.8f;
											Main.dust[num271].alpha = 100;
											Main.dust[num271].noGravity = true;
										}
										Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
									}
								}
								else
								{
									for (int num272 = 0; num272 < 20; num272++)
									{
										int num273 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
										Dust expr_F5EE_cp_0 = Main.dust[num273];
										expr_F5EE_cp_0.velocity.Y = expr_F5EE_cp_0.velocity.Y - 1.5f;
										Dust expr_F60E_cp_0 = Main.dust[num273];
										expr_F60E_cp_0.velocity.X = expr_F60E_cp_0.velocity.X * 2.5f;
										Main.dust[num273].scale = 1.3f;
										Main.dust[num273].alpha = 100;
										Main.dust[num273].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
							}
							this.wet = true;
						}
					}
					else if (this.wet)
					{
						this.wet = false;
						if (this.jump > Player.jumpHeight / 5)
						{
							this.jump = Player.jumpHeight / 5;
						}
						if (this.wetCount == 0)
						{
							this.wetCount = 10;
							if (!this.lavaWet)
							{
								if (this.honeyWet)
								{
									for (int num274 = 0; num274 < 20; num274++)
									{
										int num275 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 152, 0f, 0f, 0, default(Color), 1f);
										Dust expr_F76D_cp_0 = Main.dust[num275];
										expr_F76D_cp_0.velocity.Y = expr_F76D_cp_0.velocity.Y - 1f;
										Dust expr_F78D_cp_0 = Main.dust[num275];
										expr_F78D_cp_0.velocity.X = expr_F78D_cp_0.velocity.X * 2.5f;
										Main.dust[num275].scale = 1.3f;
										Main.dust[num275].alpha = 100;
										Main.dust[num275].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
								else
								{
									for (int num276 = 0; num276 < 50; num276++)
									{
										int num277 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2)), this.width + 12, 24, Dust.dustWater(), 0f, 0f, 0, default(Color), 1f);
										Dust expr_F888_cp_0 = Main.dust[num277];
										expr_F888_cp_0.velocity.Y = expr_F888_cp_0.velocity.Y - 4f;
										Dust expr_F8A8_cp_0 = Main.dust[num277];
										expr_F8A8_cp_0.velocity.X = expr_F8A8_cp_0.velocity.X * 2.5f;
										Main.dust[num277].scale = 0.8f;
										Main.dust[num277].alpha = 100;
										Main.dust[num277].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
								}
							}
							else
							{
								for (int num278 = 0; num278 < 20; num278++)
								{
									int num279 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
									Dust expr_F9A6_cp_0 = Main.dust[num279];
									expr_F9A6_cp_0.velocity.Y = expr_F9A6_cp_0.velocity.Y - 1.5f;
									Dust expr_F9C6_cp_0 = Main.dust[num279];
									expr_F9C6_cp_0.velocity.X = expr_F9C6_cp_0.velocity.X * 2.5f;
									Main.dust[num279].scale = 1.3f;
									Main.dust[num279].alpha = 100;
									Main.dust[num279].noGravity = true;
								}
								Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
							}
						}
					}
					if (!flag31)
					{
						this.honeyWet = false;
					}
					if (!this.wet)
					{
						this.lavaWet = false;
						this.honeyWet = false;
					}
					if (this.wetCount > 0)
					{
						this.wetCount = (byte)(this.wetCount - 1);
					}
					float num280 = 1f + Math.Abs(this.velocity.X) / 3f;
					if (this.gfxOffY > 0f)
					{
						this.gfxOffY -= num280 * this.stepSpeed;
						if (this.gfxOffY < 0f)
						{
							this.gfxOffY = 0f;
						}
					}
					else if (this.gfxOffY < 0f)
					{
						this.gfxOffY += num280 * this.stepSpeed;
						if (this.gfxOffY > 0f)
						{
							this.gfxOffY = 0f;
						}
					}
					if (this.gfxOffY > 32f)
					{
						this.gfxOffY = 32f;
					}
					if (this.gfxOffY < -32f)
					{
						this.gfxOffY = -32f;
					}
					if (Main.myPlayer == i && !this.iceSkate && this.velocity.Y > 7f)
					{
						Vector2 vector8 = this.position + this.velocity;
						int num281 = (int)(vector8.X / 16f);
						int num282 = (int)((vector8.X + (float)this.width) / 16f);
						int num283 = (int)((this.position.Y + (float)this.height + 1f) / 16f);
						for (int num284 = num281; num284 <= num282; num284++)
						{
							for (int num285 = num283; num285 <= num283 + 1; num285++)
							{
								if (Main.tile[num284, num285].nactive() && Main.tile[num284, num285].type == 162)
								{
									WorldGen.KillTile(num284, num285, false, false, false);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 0, (float)num284, (float)num285, 0f, 0);
									}
								}
							}
						}
					}
					this.sloping = false;
					float y3 = this.velocity.Y;
					Vector4 vector9 = Collision.WalkDownSlope(this.position, this.velocity, this.width, this.height, num2 * this.gravDir);
					this.position.X = vector9.X;
					this.position.Y = vector9.Y;
					this.velocity.X = vector9.Z;
					this.velocity.Y = vector9.W;
					if (this.velocity.Y != y3)
					{
						this.sloping = true;
					}
					if (this.velocity.Y == num2)
					{
						Vector2 vector10 = this.position;
						vector10.X += this.velocity.X;
						bool flag32 = false;
						int num286 = (int)(vector10.X / 16f);
						int num287 = (int)((vector10.X + (float)this.width) / 16f);
						int num288 = (int)((this.position.Y + (float)this.height + 4f) / 16f);
						float num289 = (float)((num288 + 3) * 16);
						float num290 = Main.bottomWorld / 16f - 42f;
						for (int num291 = num286; num291 <= num287; num291++)
						{
							for (int num292 = num288; num292 <= num288 + 1; num292++)
							{
								if (Main.tile[num291, num292] == null)
								{
									Main.tile[num291, num292] = new Tile();
								}
								if (Main.tile[num291, num292 - 1] == null)
								{
									Main.tile[num291, num292 - 1] = new Tile();
								}
								if (Main.tile[num291, num292].topSlope())
								{
									flag32 = true;
								}
								if ((this.waterWalk2 || this.waterWalk) && Main.tile[num291, num292].liquid > 0 && Main.tile[num291, num292 - 1].liquid == 0)
								{
									int num293 = Main.tile[num291, num292].liquid / 32 * 2 + 2;
									int num294 = num292 * 16 + 16 - num293;
									Rectangle rectangle4 = new Rectangle(num291 * 16, num292 * 16 - 17, 16, 16);
									if (rectangle4.Intersects(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height)) && (float)num294 < num289)
									{
										num289 = (float)num294;
									}
								}
								if ((float)num292 >= num290 || (Main.tile[num291, num292].nactive() && (Main.tileSolid[(int)Main.tile[num291, num292].type] || Main.tileSolidTop[(int)Main.tile[num291, num292].type])))
								{
									int num295 = num292 * 16;
									if (Main.tile[num291, num292].halfBrick())
									{
										num295 += 8;
									}
									if (Utils.FloatIntersect((float)(num291 * 16), (float)(num292 * 16 - 17), 16f, 16f, this.position.X, this.position.Y, (float)this.width, (float)this.height) && (float)num295 < num289)
									{
										num289 = (float)num295;
									}
								}
							}
						}
						float num296 = num289 - (this.position.Y + (float)this.height);
						if (num296 > 7f && num296 < 17f && !flag32)
						{
							this.stepSpeed = 1.5f;
							if (num296 > 9f)
							{
								this.stepSpeed = 2.5f;
							}
							this.gfxOffY += this.position.Y + (float)this.height - num289;
							this.position.Y = num289 - (float)this.height;
						}
					}
					if (this.gravDir == -1f)
					{
						if ((this.carpetFrame != -1 || this.velocity.Y <= num2) && !this.controlUp)
						{
							int num297 = 0;
							if (this.velocity.X < 0f)
							{
								num297 = -1;
							}
							if (this.velocity.X > 0f)
							{
								num297 = 1;
							}
							Vector2 vector11 = this.position;
							vector11.X += this.velocity.X;
							int num298 = (int)((vector11.X + (float)(this.width / 2) + (float)((this.width / 2 + 1) * num297)) / 16f);
							int num299 = (int)(((double)vector11.Y + 0.1) / 16.0);
							if (Main.tile[num298, num299] == null)
							{
								Main.tile[num298, num299] = new Tile();
							}
							if (num299 - 1 > 0 && Main.tile[num298, num299 + 1] == null)
							{
								Main.tile[num298, num299 + 1] = new Tile();
							}
							if (num299 - 2 > 0 && Main.tile[num298, num299 + 2] == null)
							{
								Main.tile[num298, num299 + 2] = new Tile();
							}
							if (num299 - 3 > 0 && Main.tile[num298, num299 + 3] == null)
							{
								Main.tile[num298, num299 + 3] = new Tile();
							}
							if (num299 - 4 > 0 && Main.tile[num298, num299 + 4] == null)
							{
								Main.tile[num298, num299 + 4] = new Tile();
							}
							if (num299 - 3 > 0 && Main.tile[num298 - num297, num299 + 3] == null)
							{
								Main.tile[num298 - num297, num299 + 3] = new Tile();
							}
							if ((float)(num298 * 16) < vector11.X + (float)this.width && (float)(num298 * 16 + 16) > vector11.X && !Main.tile[num298, num299].bottomSlope() && ((Main.tile[num298, num299].nactive() && ((Main.tileSolid[(int)Main.tile[num298, num299].type] && !Main.tileSolidTop[(int)Main.tile[num298, num299].type]) || (this.controlUp && Main.tileSolidTop[(int)Main.tile[num298, num299].type] && Main.tile[num298, num299].frameY == 0 && (!Main.tileSolid[(int)Main.tile[num298, num299 + 1].type] || !Main.tile[num298, num299 + 1].nactive())))) || (Main.tile[num298, num299 + 1].halfBrick() && Main.tile[num298, num299 + 1].nactive())) && (!Main.tile[num298, num299 + 1].nactive() || !Main.tileSolid[(int)Main.tile[num298, num299 + 1].type] || Main.tileSolidTop[(int)Main.tile[num298, num299 + 1].type] || Main.tile[num298, num299 + 1].slope() != 0 || (Main.tile[num298, num299 + 1].halfBrick() && (!Main.tile[num298, num299 + 4].nactive() || !Main.tileSolid[(int)Main.tile[num298, num299 + 4].type] || Main.tileSolidTop[(int)Main.tile[num298, num299 + 4].type]))) && (!Main.tile[num298, num299 + 2].nactive() || !Main.tileSolid[(int)Main.tile[num298, num299 + 2].type] || Main.tileSolidTop[(int)Main.tile[num298, num299 + 2].type]) && (!Main.tile[num298, num299 + 3].nactive() || !Main.tileSolid[(int)Main.tile[num298, num299 + 3].type] || Main.tileSolidTop[(int)Main.tile[num298, num299 + 3].type]) && (!Main.tile[num298 - num297, num299 + 3].nactive() || !Main.tileSolid[(int)Main.tile[num298 - num297, num299 + 3].type] || Main.tileSolidTop[(int)Main.tile[num298 - num297, num299 + 3].type]))
							{
								float num300 = (float)(num299 * 16 + 16);
								if (num300 > vector11.Y)
								{
									float num301 = num300 - vector11.Y;
									if ((double)num301 <= 16.1)
									{
										this.gfxOffY -= num300 - this.position.Y;
										this.position.Y = num300;
										this.velocity.Y = 0f;
										if (num301 < 9f)
										{
											this.stepSpeed = 1f;
										}
										else
										{
											this.stepSpeed = 2f;
										}
									}
								}
							}
						}
					}
					else if ((this.carpetFrame != -1 || this.velocity.Y >= num2) && !this.controlDown)
					{
						int num302 = 0;
						if (this.velocity.X < 0f)
						{
							num302 = -1;
						}
						if (this.velocity.X > 0f)
						{
							num302 = 1;
						}
						Vector2 vector12 = this.position;
						vector12.X += this.velocity.X;
						int num303 = (int)((vector12.X + (float)(this.width / 2) + (float)((this.width / 2 + 1) * num302)) / 16f);
						int num304 = (int)((vector12.Y + (float)this.height - 1f) / 16f);
						if (Main.tile[num303, num304] == null)
						{
							Main.tile[num303, num304] = new Tile();
						}
						if (num304 - 1 > 0 && Main.tile[num303, num304 - 1] == null)
						{
							Main.tile[num303, num304 - 1] = new Tile();
						}
						if (num304 - 2 > 0 && Main.tile[num303, num304 - 2] == null)
						{
							Main.tile[num303, num304 - 2] = new Tile();
						}
						if (num304 - 3 > 0 && Main.tile[num303, num304 - 3] == null)
						{
							Main.tile[num303, num304 - 3] = new Tile();
						}
						if (num304 - 4 > 0 && Main.tile[num303, num304 - 4] == null)
						{
							Main.tile[num303, num304 - 4] = new Tile();
						}
						if (num304 - 3 > 0 && Main.tile[num303 - num302, num304 - 3] == null)
						{
							Main.tile[num303 - num302, num304 - 3] = new Tile();
						}
						if ((float)(num303 * 16) < vector12.X + (float)this.width && (float)(num303 * 16 + 16) > vector12.X && ((Main.tile[num303, num304].nactive() && (!Main.tile[num303, num304].topSlope() || (Main.tile[num303, num304].slope() == 1 && this.position.X + (float)(this.width / 2) < (float)(num303 * 16)) || (Main.tile[num303, num304].slope() == 2 && this.position.X + (float)(this.width / 2) > (float)(num303 * 16 + 16))) && (!Main.tile[num303, num304].topSlope() || this.position.Y + (float)this.height > (float)(num304 * 16)) && ((Main.tileSolid[(int)Main.tile[num303, num304].type] && !Main.tileSolidTop[(int)Main.tile[num303, num304].type]) || (this.controlUp && ((Main.tileSolidTop[(int)Main.tile[num303, num304].type] && Main.tile[num303, num304].frameY == 0) || Main.tile[num303, num304].type == 19) && (!Main.tileSolid[(int)Main.tile[num303, num304 - 1].type] || !Main.tile[num303, num304 - 1].nactive())))) || (Main.tile[num303, num304 - 1].halfBrick() && Main.tile[num303, num304 - 1].nactive())) && (!Main.tile[num303, num304 - 1].nactive() || !Main.tileSolid[(int)Main.tile[num303, num304 - 1].type] || Main.tileSolidTop[(int)Main.tile[num303, num304 - 1].type] || (Main.tile[num303, num304 - 1].slope() == 1 && this.position.X + (float)(this.width / 2) > (float)(num303 * 16)) || (Main.tile[num303, num304 - 1].slope() == 2 && this.position.X + (float)(this.width / 2) < (float)(num303 * 16 + 16)) || (Main.tile[num303, num304 - 1].halfBrick() && (!Main.tile[num303, num304 - 4].nactive() || !Main.tileSolid[(int)Main.tile[num303, num304 - 4].type] || Main.tileSolidTop[(int)Main.tile[num303, num304 - 4].type]))) && (!Main.tile[num303, num304 - 2].nactive() || !Main.tileSolid[(int)Main.tile[num303, num304 - 2].type] || Main.tileSolidTop[(int)Main.tile[num303, num304 - 2].type]) && (!Main.tile[num303, num304 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num303, num304 - 3].type] || Main.tileSolidTop[(int)Main.tile[num303, num304 - 3].type]) && (!Main.tile[num303 - num302, num304 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num303 - num302, num304 - 3].type] || Main.tileSolidTop[(int)Main.tile[num303 - num302, num304 - 3].type]))
						{
							float num305 = (float)(num304 * 16);
							if (Main.tile[num303, num304].halfBrick())
							{
								num305 += 8f;
							}
							if (Main.tile[num303, num304 - 1].halfBrick())
							{
								num305 -= 8f;
							}
							if (num305 < vector12.Y + (float)this.height)
							{
								float num306 = vector12.Y + (float)this.height - num305;
								if ((double)num306 <= 16.1)
								{
									this.gfxOffY += this.position.Y + (float)this.height - num305;
									this.position.Y = num305 - (float)this.height;
									if (num306 < 9f)
									{
										this.stepSpeed = 1f;
									}
									else
									{
										this.stepSpeed = 2f;
									}
								}
							}
						}
					}
					this.oldPosition = this.position;
					bool flag33 = false;
					if (this.velocity.Y > num2)
					{
						flag33 = true;
					}
					Vector2 vector13 = this.velocity;
					this.slideDir = 0;
					bool fall = false;
					bool fallThrough = this.controlDown;
					if (this.gravDir == -1f)
					{
						fall = true;
						fallThrough = true;
					}
					if (this.wingsLogic == 3 && this.controlUp && this.controlDown)
					{
						this.position += this.velocity;
					}
					else if (this.tongued)
					{
						this.position += this.velocity;
					}
					else if (this.honeyWet)
					{
						Vector2 vector14 = this.velocity;
						this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, fallThrough, fall, (int)this.gravDir);
						Vector2 value3 = this.velocity * 0.25f;
						if (this.velocity.X != vector14.X)
						{
							value3.X = this.velocity.X;
						}
						if (this.velocity.Y != vector14.Y)
						{
							value3.Y = this.velocity.Y;
						}
						this.position += value3;
					}
					else if (this.wet && !this.merman)
					{
						Vector2 vector15 = this.velocity;
						this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, fallThrough, fall, (int)this.gravDir);
						Vector2 value4 = this.velocity * 0.5f;
						if (this.velocity.X != vector15.X)
						{
							value4.X = this.velocity.X;
						}
						if (this.velocity.Y != vector15.Y)
						{
							value4.Y = this.velocity.Y;
						}
						this.position += value4;
					}
					else
					{
						this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, fallThrough, fall, (int)this.gravDir);
						if (Collision.up && this.gravDir == 1f)
						{
							this.jump = 0;
						}
						if (this.waterWalk || this.waterWalk2)
						{
							Vector2 value5 = this.velocity;
							this.velocity = Collision.WaterCollision(this.position, this.velocity, this.width, this.height, this.controlDown, false, this.waterWalk);
							if (value5 != this.velocity)
							{
								this.fallStart = (int)(this.position.Y / 16f);
							}
						}
						this.position += this.velocity;
					}
					if (this.wingsLogic != 3 || !this.controlUp || !this.controlDown)
					{
						if (this.controlDown || this.grappling[0] >= 0 || this.gravDir == -1f)
						{
							this.stairFall = true;
						}
						Vector4 vector16 = Collision.SlopeCollision(this.position, this.velocity, this.width, this.height, num2, this.stairFall);
						if (Collision.stairFall)
						{
							this.stairFall = true;
						}
						else if (!this.controlDown)
						{
							this.stairFall = false;
						}
						if (Collision.stair && Math.Abs(vector16.Y - this.position.Y) > 8f + Math.Abs(this.velocity.X))
						{
							this.gfxOffY -= vector16.Y - this.position.Y;
							this.stepSpeed = 4f;
						}
						this.position.X = vector16.X;
						this.position.Y = vector16.Y;
						this.velocity.X = vector16.Z;
						this.velocity.Y = vector16.W;
						if (this.gravDir == -1f && this.velocity.Y == 0.0101f)
						{
							this.velocity.Y = 0f;
						}
					}
					if (vector13.X != this.velocity.X)
					{
						if (vector13.X < 0f)
						{
							this.slideDir = -1;
						}
						else if (vector13.X > 0f)
						{
							this.slideDir = 1;
						}
					}
					if (this.gravDir == 1f && Collision.up)
					{
						this.velocity.Y = 0.01f;
						if (!this.merman)
						{
							this.jump = 0;
						}
					}
					else if (this.gravDir == -1f && Collision.down)
					{
						this.velocity.Y = -0.01f;
						if (!this.merman)
						{
							this.jump = 0;
						}
					}
					if (this.velocity.Y == 0f && this.grappling[0] == -1)
					{
						int num307 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
						int num308 = (int)((this.position.Y + (float)this.height) / 16f);
						int num309 = -1;
						if (Main.tile[num307 - 1, num308] == null)
						{
							Main.tile[num307 - 1, num308] = new Tile();
						}
						if (Main.tile[num307 + 1, num308] == null)
						{
							Main.tile[num307 + 1, num308] = new Tile();
						}
						if (Main.tile[num307, num308] == null)
						{
							Main.tile[num307, num308] = new Tile();
						}
						if (Main.tile[num307, num308].nactive() && Main.tileSolid[(int)Main.tile[num307, num308].type])
						{
							num309 = (int)Main.tile[num307, num308].type;
						}
						else if (Main.tile[num307 - 1, num308].nactive() && Main.tileSolid[(int)Main.tile[num307 - 1, num308].type])
						{
							num309 = (int)Main.tile[num307 - 1, num308].type;
						}
						else if (Main.tile[num307 + 1, num308].nactive() && Main.tileSolid[(int)Main.tile[num307 + 1, num308].type])
						{
							num309 = (int)Main.tile[num307 + 1, num308].type;
						}
						if (num309 > -1)
						{
							if (num309 == 229)
							{
								this.sticky = true;
							}
							else
							{
								this.sticky = false;
							}
							if (num309 == 161 || num309 == 162 || num309 == 163 || num309 == 164 || num309 == 200)
							{
								this.slippy = true;
							}
							else
							{
								this.slippy = false;
							}
							if (num309 == 197)
							{
								this.slippy2 = true;
							}
							else
							{
								this.slippy2 = false;
							}
							if (num309 == 198)
							{
								this.powerrun = true;
							}
							else
							{
								this.powerrun = false;
							}
							if (Main.tile[num307 - 1, num308].slope() != 0 || Main.tile[num307, num308].slope() != 0 || Main.tile[num307 + 1, num308].slope() != 0)
							{
								num309 = -1;
							}
							if (!this.wet && (num309 == 147 || num309 == 25 || num309 == 53 || num309 == 189 || num309 == 0 || num309 == 123 || num309 == 57 || num309 == 112 || num309 == 116 || num309 == 196 || num309 == 193 || num309 == 195 || num309 == 197 || num309 == 199 || num309 == 229))
							{
								int num310 = 1;
								if (flag33)
								{
									num310 = 20;
								}
								for (int num311 = 0; num311 < num310; num311++)
								{
									bool flag34 = true;
									int num312 = 76;
									if (num309 == 53)
									{
										num312 = 32;
									}
									if (num309 == 189)
									{
										num312 = 16;
									}
									if (num309 == 0)
									{
										num312 = 0;
									}
									if (num309 == 123)
									{
										num312 = 53;
									}
									if (num309 == 57)
									{
										num312 = 36;
									}
									if (num309 == 112)
									{
										num312 = 14;
									}
									if (num309 == 116)
									{
										num312 = 51;
									}
									if (num309 == 196)
									{
										num312 = 108;
									}
									if (num309 == 193)
									{
										num312 = 4;
									}
									if (num309 == 195 || num309 == 199)
									{
										num312 = 5;
									}
									if (num309 == 197)
									{
										num312 = 4;
									}
									if (num309 == 229)
									{
										num312 = 153;
									}
									if (num309 == 25)
									{
										num312 = 37;
									}
									if (num312 == 32 && Main.rand.Next(2) == 0)
									{
										flag34 = false;
									}
									if (num312 == 14 && Main.rand.Next(2) == 0)
									{
										flag34 = false;
									}
									if (num312 == 51 && Main.rand.Next(2) == 0)
									{
										flag34 = false;
									}
									if (num312 == 36 && Main.rand.Next(2) == 0)
									{
										flag34 = false;
									}
									if (num312 == 0 && Main.rand.Next(3) != 0)
									{
										flag34 = false;
									}
									if (num312 == 53 && Main.rand.Next(3) != 0)
									{
										flag34 = false;
									}
									Color newColor = default(Color);
									if (num309 == 193)
									{
										newColor = new Color(30, 100, 255, 100);
									}
									if (num309 == 197)
									{
										newColor = new Color(97, 200, 255, 100);
									}
									if (!flag33)
									{
										float num313 = Math.Abs(this.velocity.X) / 3f;
										if ((float)Main.rand.Next(100) > num313 * 100f)
										{
											flag34 = false;
										}
									}
									if (flag34)
									{
										float num314 = this.velocity.X;
										if (num314 > 6f)
										{
											num314 = 6f;
										}
										if (num314 < -6f)
										{
											num314 = -6f;
										}
										if (this.velocity.X != 0f || flag33)
										{
											int num315 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), this.width, 6, num312, 0f, 0f, 50, newColor, 1f);
											if (num312 == 76)
											{
												Main.dust[num315].scale += (float)Main.rand.Next(3) * 0.1f;
												Main.dust[num315].noLight = true;
											}
											if (num312 == 16 || num312 == 108 || num312 == 153)
											{
												Main.dust[num315].scale += (float)Main.rand.Next(6) * 0.1f;
											}
											if (num312 == 37)
											{
												Main.dust[num315].scale += 0.25f;
												Main.dust[num315].alpha = 50;
											}
											if (num312 == 5)
											{
												Main.dust[num315].scale += (float)Main.rand.Next(2, 8) * 0.1f;
											}
											Main.dust[num315].noGravity = true;
											if (num310 > 1)
											{
												Dust expr_11C16_cp_0 = Main.dust[num315];
												expr_11C16_cp_0.velocity.X = expr_11C16_cp_0.velocity.X * 1.2f;
												Dust expr_11C36_cp_0 = Main.dust[num315];
												expr_11C36_cp_0.velocity.Y = expr_11C36_cp_0.velocity.Y * 0.8f;
												Dust expr_11C56_cp_0 = Main.dust[num315];
												expr_11C56_cp_0.velocity.Y = expr_11C56_cp_0.velocity.Y - 1f;
												Main.dust[num315].velocity *= 0.8f;
												Main.dust[num315].scale += (float)Main.rand.Next(3) * 0.1f;
												Main.dust[num315].velocity.X = (Main.dust[num315].position.X - (this.position.X + (float)(this.width / 2))) * 0.2f;
												if (Main.dust[num315].velocity.Y > 0f)
												{
													Dust expr_11D1C_cp_0 = Main.dust[num315];
													expr_11D1C_cp_0.velocity.Y = expr_11D1C_cp_0.velocity.Y * -1f;
												}
												Dust expr_11D3C_cp_0 = Main.dust[num315];
												expr_11D3C_cp_0.velocity.X = expr_11D3C_cp_0.velocity.X + num314 * 0.3f;
											}
											else
											{
												Main.dust[num315].velocity *= 0.2f;
											}
											Dust expr_11D82_cp_0 = Main.dust[num315];
											expr_11D82_cp_0.position.X = expr_11D82_cp_0.position.X - num314 * 1f;
										}
									}
								}
							}
						}
					}
					if (this.position.X < Main.leftWorld + 640f + 16f)
					{
						this.position.X = Main.leftWorld + 640f + 16f;
						this.velocity.X = 0f;
					}
					if (this.position.X + (float)this.width > Main.rightWorld - 640f - 32f)
					{
						this.position.X = Main.rightWorld - 640f - 32f - (float)this.width;
						this.velocity.X = 0f;
					}
					if (this.position.Y < Main.topWorld + 640f + 16f)
					{
						this.position.Y = Main.topWorld + 640f + 16f;
						if ((double)this.velocity.Y < 0.11)
						{
							this.velocity.Y = 0.11f;
						}
						this.gravDir = 1f;
					}
					if (this.position.Y > Main.bottomWorld - 640f - 32f - (float)this.height)
					{
						this.position.Y = Main.bottomWorld - 640f - 32f - (float)this.height;
						this.velocity.Y = 0f;
					}
					this.numMinions = 0;
					if (Main.ignoreErrors)
					{
						try
						{
							this.ItemCheck(i);
							goto IL_11F66;
						}
						catch
						{
							goto IL_11F66;
						}
					}
					this.ItemCheck(i);
					IL_11F66:
					this.PlayerFrame();
					if (this.statLife > this.statLifeMax)
					{
						this.statLife = this.statLifeMax;
					}
					this.grappling[0] = -1;
					this.grapCount = 0;
				}
			}
		}
		public bool SellItem(int price, int stack)
		{
			if (price <= 0)
			{
				return false;
			}
			Item[] array = new Item[58];
			for (int i = 0; i < 58; i++)
			{
				array[i] = new Item();
				array[i] = this.inventory[i].Clone();
			}
			int j = price / 5;
			j *= stack;
			if (j < 1)
			{
				j = 1;
			}
			bool flag = false;
			while (j >= 1000000)
			{
				if (flag)
				{
					break;
				}
				int num = -1;
				for (int k = 53; k >= 0; k--)
				{
					if (num == -1 && (this.inventory[k].type == 0 || this.inventory[k].stack == 0))
					{
						num = k;
					}
					while (this.inventory[k].type == 74 && this.inventory[k].stack < this.inventory[k].maxStack && j >= 1000000)
					{
						this.inventory[k].stack++;
						j -= 1000000;
						this.DoCoins(k);
						if (this.inventory[k].stack == 0 && num == -1)
						{
							num = k;
						}
					}
				}
				if (j >= 1000000)
				{
					if (num == -1)
					{
						flag = true;
					}
					else
					{
						this.inventory[num].SetDefaults(74, false);
						j -= 1000000;
					}
				}
			}
			while (j >= 10000)
			{
				if (flag)
				{
					break;
				}
				int num2 = -1;
				for (int l = 53; l >= 0; l--)
				{
					if (num2 == -1 && (this.inventory[l].type == 0 || this.inventory[l].stack == 0))
					{
						num2 = l;
					}
					while (this.inventory[l].type == 73 && this.inventory[l].stack < this.inventory[l].maxStack && j >= 10000)
					{
						this.inventory[l].stack++;
						j -= 10000;
						this.DoCoins(l);
						if (this.inventory[l].stack == 0 && num2 == -1)
						{
							num2 = l;
						}
					}
				}
				if (j >= 10000)
				{
					if (num2 == -1)
					{
						flag = true;
					}
					else
					{
						this.inventory[num2].SetDefaults(73, false);
						j -= 10000;
					}
				}
			}
			while (j >= 100)
			{
				if (flag)
				{
					break;
				}
				int num3 = -1;
				for (int m = 53; m >= 0; m--)
				{
					if (num3 == -1 && (this.inventory[m].type == 0 || this.inventory[m].stack == 0))
					{
						num3 = m;
					}
					while (this.inventory[m].type == 72 && this.inventory[m].stack < this.inventory[m].maxStack && j >= 100)
					{
						this.inventory[m].stack++;
						j -= 100;
						this.DoCoins(m);
						if (this.inventory[m].stack == 0 && num3 == -1)
						{
							num3 = m;
						}
					}
				}
				if (j >= 100)
				{
					if (num3 == -1)
					{
						flag = true;
					}
					else
					{
						this.inventory[num3].SetDefaults(72, false);
						j -= 100;
					}
				}
			}
			while (j >= 1 && !flag)
			{
				int num4 = -1;
				for (int n = 53; n >= 0; n--)
				{
					if (num4 == -1 && (this.inventory[n].type == 0 || this.inventory[n].stack == 0))
					{
						num4 = n;
					}
					while (this.inventory[n].type == 71 && this.inventory[n].stack < this.inventory[n].maxStack && j >= 1)
					{
						this.inventory[n].stack++;
						j--;
						this.DoCoins(n);
						if (this.inventory[n].stack == 0 && num4 == -1)
						{
							num4 = n;
						}
					}
				}
				if (j >= 1)
				{
					if (num4 == -1)
					{
						flag = true;
					}
					else
					{
						this.inventory[num4].SetDefaults(71, false);
						j--;
					}
				}
			}
			if (flag)
			{
				for (int num5 = 0; num5 < 58; num5++)
				{
					this.inventory[num5] = array[num5].Clone();
				}
				return false;
			}
			return true;
		}
		public bool BuyItem(int price)
		{
			if (price == 0)
			{
				return true;
			}
			int num = 0;
			Item[] array = new Item[54];
			for (int i = 0; i < 54; i++)
			{
				array[i] = new Item();
				array[i] = this.inventory[i].Clone();
				if (this.inventory[i].type == 71)
				{
					num += this.inventory[i].stack;
				}
				if (this.inventory[i].type == 72)
				{
					num += this.inventory[i].stack * 100;
				}
				if (this.inventory[i].type == 73)
				{
					num += this.inventory[i].stack * 10000;
				}
				if (this.inventory[i].type == 74)
				{
					num += this.inventory[i].stack * 1000000;
				}
			}
			if (num >= price)
			{
				int j = price;
				while (j > 0)
				{
					if (j >= 1000000)
					{
						for (int k = 0; k < 54; k++)
						{
							if (this.inventory[k].type == 74)
							{
								while (this.inventory[k].stack > 0 && j >= 1000000)
								{
									j -= 1000000;
									this.inventory[k].stack--;
									if (this.inventory[k].stack == 0)
									{
										this.inventory[k].type = 0;
									}
								}
							}
						}
					}
					if (j >= 10000)
					{
						for (int l = 0; l < 54; l++)
						{
							if (this.inventory[l].type == 73)
							{
								while (this.inventory[l].stack > 0 && j >= 10000)
								{
									j -= 10000;
									this.inventory[l].stack--;
									if (this.inventory[l].stack == 0)
									{
										this.inventory[l].type = 0;
									}
								}
							}
						}
					}
					if (j >= 100)
					{
						for (int m = 0; m < 54; m++)
						{
							if (this.inventory[m].type == 72)
							{
								while (this.inventory[m].stack > 0 && j >= 100)
								{
									j -= 100;
									this.inventory[m].stack--;
									if (this.inventory[m].stack == 0)
									{
										this.inventory[m].type = 0;
									}
								}
							}
						}
					}
					if (j >= 1)
					{
						for (int n = 0; n < 54; n++)
						{
							if (this.inventory[n].type == 71)
							{
								while (this.inventory[n].stack > 0 && j >= 1)
								{
									j--;
									this.inventory[n].stack--;
									if (this.inventory[n].stack == 0)
									{
										this.inventory[n].type = 0;
									}
								}
							}
						}
					}
					if (j > 0)
					{
						int num2 = -1;
						for (int num3 = 53; num3 >= 0; num3--)
						{
							if (this.inventory[num3].type == 0 || this.inventory[num3].stack == 0)
							{
								num2 = num3;
								break;
							}
						}
						if (num2 < 0)
						{
							for (int num4 = 0; num4 < 54; num4++)
							{
								this.inventory[num4] = array[num4].Clone();
							}
							return false;
						}
						bool flag = true;
						if (j >= 10000)
						{
							for (int num5 = 0; num5 < 58; num5++)
							{
								if (this.inventory[num5].type == 74 && this.inventory[num5].stack >= 1)
								{
									this.inventory[num5].stack--;
									if (this.inventory[num5].stack == 0)
									{
										this.inventory[num5].type = 0;
									}
									this.inventory[num2].SetDefaults(73, false);
									this.inventory[num2].stack = 100;
									flag = false;
									break;
								}
							}
						}
						else if (j >= 100)
						{
							for (int num6 = 0; num6 < 54; num6++)
							{
								if (this.inventory[num6].type == 73 && this.inventory[num6].stack >= 1)
								{
									this.inventory[num6].stack--;
									if (this.inventory[num6].stack == 0)
									{
										this.inventory[num6].type = 0;
									}
									this.inventory[num2].SetDefaults(72, false);
									this.inventory[num2].stack = 100;
									flag = false;
									break;
								}
							}
						}
						else if (j >= 1)
						{
							for (int num7 = 0; num7 < 54; num7++)
							{
								if (this.inventory[num7].type == 72 && this.inventory[num7].stack >= 1)
								{
									this.inventory[num7].stack--;
									if (this.inventory[num7].stack == 0)
									{
										this.inventory[num7].type = 0;
									}
									this.inventory[num2].SetDefaults(71, false);
									this.inventory[num2].stack = 100;
									flag = false;
									break;
								}
							}
						}
						if (flag)
						{
							if (j < 10000)
							{
								for (int num8 = 0; num8 < 54; num8++)
								{
									if (this.inventory[num8].type == 73 && this.inventory[num8].stack >= 1)
									{
										this.inventory[num8].stack--;
										if (this.inventory[num8].stack == 0)
										{
											this.inventory[num8].type = 0;
										}
										this.inventory[num2].SetDefaults(72, false);
										this.inventory[num2].stack = 100;
										flag = false;
										break;
									}
								}
							}
							if (flag && j < 1000000)
							{
								for (int num9 = 0; num9 < 54; num9++)
								{
									if (this.inventory[num9].type == 74 && this.inventory[num9].stack >= 1)
									{
										this.inventory[num9].stack--;
										if (this.inventory[num9].stack == 0)
										{
											this.inventory[num9].type = 0;
										}
										this.inventory[num2].SetDefaults(73, false);
										this.inventory[num2].stack = 100;
										break;
									}
								}
							}
						}
					}
				}
				return true;
			}
			return false;
		}
		public void AdjTiles()
		{
			int num = 4;
			int num2 = 3;
			for (int i = 0; i < 314; i++)
			{
				this.oldAdjTile[i] = this.adjTile[i];
				this.adjTile[i] = false;
			}
			this.oldAdjWater = this.adjWater;
			this.adjWater = false;
			this.oldAdjHoney = this.adjHoney;
			this.adjHoney = false;
			this.oldAdjLava = this.adjLava;
			this.adjLava = false;
			int num3 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
			int num4 = (int)((this.position.Y + (float)this.height) / 16f);
			for (int j = num3 - num; j <= num3 + num; j++)
			{
				for (int k = num4 - num2; k < num4 + num2; k++)
				{
					if (Main.tile[j, k].active())
					{
						this.adjTile[(int)Main.tile[j, k].type] = true;
						if (Main.tile[j, k].type == 302)
						{
							this.adjTile[17] = true;
						}
						if (Main.tile[j, k].type == 77)
						{
							this.adjTile[17] = true;
						}
						if (Main.tile[j, k].type == 133)
						{
							this.adjTile[17] = true;
							this.adjTile[77] = true;
						}
						if (Main.tile[j, k].type == 134)
						{
							this.adjTile[16] = true;
						}
					}
					if (Main.tile[j, k].liquid > 200 && Main.tile[j, k].liquidType() == 0)
					{
						this.adjWater = true;
					}
					if (Main.tile[j, k].liquid > 200 && Main.tile[j, k].liquidType() == 2)
					{
						this.adjHoney = true;
					}
					if (Main.tile[j, k].liquid > 200 && Main.tile[j, k].liquidType() == 1)
					{
						this.adjLava = true;
					}
				}
			}
			if (Main.playerInventory)
			{
				bool flag = false;
				for (int l = 0; l < 314; l++)
				{
					if (this.oldAdjTile[l] != this.adjTile[l])
					{
						flag = true;
						break;
					}
				}
				if (this.adjWater != this.oldAdjWater)
				{
					flag = true;
				}
				if (this.adjHoney != this.oldAdjHoney)
				{
					flag = true;
				}
				if (this.adjLava != this.oldAdjLava)
				{
					flag = true;
				}
				if (flag)
				{
					Recipe.FindRecipes();
				}
			}
		}
		public void PlayerFrame()
		{
			if (this.swimTime > 0)
			{
				this.swimTime--;
				if (!this.wet)
				{
					this.swimTime = 0;
				}
			}
			this.head = this.armor[0].headSlot;
			this.body = this.armor[1].bodySlot;
			this.legs = this.armor[2].legSlot;
			int i = 3;
			while (i < 8)
			{
				if (this.armor[i].wingSlot <= 0)
				{
					goto IL_AC;
				}
				if (!this.hideVisual[i] || this.velocity.Y != 0f)
				{
					this.wings = (int)this.armor[i].wingSlot;
					goto IL_AC;
				}
				IL_222:
				i++;
				continue;
				IL_AC:
				if (this.hideVisual[i])
				{
					goto IL_222;
				}
				if (this.armor[i].handOnSlot > 0)
				{
					this.handon = this.armor[i].handOnSlot;
				}
				if (this.armor[i].handOffSlot > 0)
				{
					this.handoff = this.armor[i].handOffSlot;
				}
				if (this.armor[i].backSlot > 0)
				{
					this.back = this.armor[i].backSlot;
					this.front = -1;
				}
				if (this.armor[i].frontSlot > 0)
				{
					this.front = this.armor[i].frontSlot;
				}
				if (this.armor[i].shoeSlot > 0)
				{
					this.shoe = this.armor[i].shoeSlot;
				}
				if (this.armor[i].waistSlot > 0)
				{
					this.waist = this.armor[i].waistSlot;
				}
				if (this.armor[i].shieldSlot > 0)
				{
					this.shield = this.armor[i].shieldSlot;
				}
				if (this.armor[i].neckSlot > 0)
				{
					this.neck = this.armor[i].neckSlot;
				}
				if (this.armor[i].faceSlot > 0)
				{
					this.face = this.armor[i].faceSlot;
				}
				if (this.armor[i].balloonSlot > 0)
				{
					this.balloon = this.armor[i].balloonSlot;
					goto IL_222;
				}
				goto IL_222;
			}
			for (int j = 11; j < 16; j++)
			{
				if (this.armor[j].handOnSlot > 0)
				{
					this.handon = this.armor[j].handOnSlot;
				}
				if (this.armor[j].handOffSlot > 0)
				{
					this.handoff = this.armor[j].handOffSlot;
				}
				if (this.armor[j].backSlot > 0)
				{
					this.back = this.armor[j].backSlot;
					this.front = -1;
				}
				if (this.armor[j].frontSlot > 0)
				{
					this.front = this.armor[j].frontSlot;
				}
				if (this.armor[j].shoeSlot > 0)
				{
					this.shoe = this.armor[j].shoeSlot;
				}
				if (this.armor[j].waistSlot > 0)
				{
					this.waist = this.armor[j].waistSlot;
				}
				if (this.armor[j].shieldSlot > 0)
				{
					this.shield = this.armor[j].shieldSlot;
				}
				if (this.armor[j].neckSlot > 0)
				{
					this.neck = this.armor[j].neckSlot;
				}
				if (this.armor[j].faceSlot > 0)
				{
					this.face = this.armor[j].faceSlot;
				}
				if (this.armor[j].balloonSlot > 0)
				{
					this.balloon = this.armor[j].balloonSlot;
				}
				if (this.armor[j].wingSlot > 0)
				{
					this.wings = (int)this.armor[j].wingSlot;
				}
			}
			if (this.armor[8].headSlot >= 0)
			{
				this.head = this.armor[8].headSlot;
			}
			if (this.armor[9].bodySlot >= 0)
			{
				this.body = this.armor[9].bodySlot;
			}
			if (this.armor[10].legSlot >= 0)
			{
				this.legs = this.armor[10].legSlot;
			}
			this.wearsRobe = false;
			int num = this.body;
			if (num <= 36)
			{
				if (num != 15)
				{
					if (num == 36)
					{
						this.legs = 89;
						this.wearsRobe = true;
					}
				}
				else
				{
					this.legs = 88;
					this.wearsRobe = true;
				}
			}
			else
			{
				switch (num)
				{
				case 41:
					this.legs = 97;
					this.wearsRobe = true;
					break;
				case 42:
					this.legs = 90;
					this.wearsRobe = true;
					break;
				default:
					switch (num)
					{
					case 58:
						this.legs = 91;
						this.wearsRobe = true;
						break;
					case 59:
						this.legs = 92;
						this.wearsRobe = true;
						break;
					case 60:
						this.legs = 93;
						this.wearsRobe = true;
						break;
					case 61:
						this.legs = 94;
						this.wearsRobe = true;
						break;
					case 62:
						this.legs = 95;
						this.wearsRobe = true;
						break;
					case 63:
						this.legs = 96;
						this.wearsRobe = true;
						break;
					default:
						switch (num)
						{
						case 165:
							this.legs = 99;
							this.wearsRobe = true;
							break;
						case 166:
							this.legs = 100;
							this.wearsRobe = true;
							break;
						case 167:
							if (this.male)
							{
								this.legs = 101;
							}
							else
							{
								this.legs = 102;
							}
							this.wearsRobe = true;
							break;
						}
						break;
					}
					break;
				}
			}
			if (Main.myPlayer == this.whoAmi)
			{
				bool flag = false;
				if (this.wings == 3 || (this.wings >= 16 && this.wings <= 19))
				{
					flag = true;
				}
				if (this.wingsLogic == 3 || (this.wingsLogic >= 16 && this.wingsLogic <= 19))
				{
					flag = true;
				}
				else if (this.head == 45 || (this.head >= 106 && this.head <= 111))
				{
					flag = true;
				}
				else if (this.body == 26 || (this.body >= 68 && this.body <= 74))
				{
					flag = true;
				}
				else if (this.legs == 25 || (this.legs >= 57 && this.legs <= 63))
				{
					flag = true;
				}
				if (flag)
				{
					this.velocity.X = this.velocity.X * 0.9f;
					if (this.velocity.Y < 0f)
					{
						this.velocity.Y = this.velocity.Y + 0.2f;
					}
					this.jump = 0;
					this.statDefense = -1000;
					this.AddBuff(23, 2, false);
					this.AddBuff(80, 2, false);
					this.AddBuff(67, 2, false);
					this.AddBuff(32, 2, false);
					this.AddBuff(31, 2, false);
					this.AddBuff(33, 2, false);
				}
			}
			if (this.body == 93)
			{
				this.shield = 0;
				this.handoff = 0;
			}
			if (this.legs == 67)
			{
				this.shoe = 0;
			}
			if (this.wereWolf)
			{
				this.legs = 20;
				this.body = 21;
				this.head = 38;
			}
			if (this.merman)
			{
				this.head = 39;
				this.legs = 21;
				this.body = 22;
				this.wings = 0;
			}
			this.socialShadow = false;
			this.socialGhost = false;
			if (this.head == 101 && this.body == 66 && this.legs == 55)
			{
				this.socialGhost = true;
			}
			if (this.head == 156 && this.body == 66 && this.legs == 55)
			{
				this.socialGhost = true;
			}
			if (this.head == 99 && this.body == 65 && this.legs == 54)
			{
				this.turtleArmor = true;
			}
			if ((this.head == 75 || this.head == 7) && this.body == 7 && this.legs == 7)
			{
				this.boneArmor = true;
			}
			if (this.frozen)
			{
				return;
			}
			if (Main.gamePaused && !Main.gameMenu)
			{
				return;
			}
			if (((this.body == 68 && this.legs == 57 && this.head == 106) || (this.body == 74 && this.legs == 63 && this.head == 106)) && Main.rand.Next(10) == 0)
			{
				int num2 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 43, 0f, 0f, 100, new Color(255, 0, 255), 0.3f);
				Main.dust[num2].fadeIn = 0.8f;
				Main.dust[num2].noGravity = true;
				Main.dust[num2].velocity *= 2f;
			}
			if (this.head == 5 && this.body == 5 && this.legs == 5)
			{
				this.socialShadow = true;
			}
			if (this.head == 5 && this.body == 5 && this.legs == 5 && Main.rand.Next(10) == 0)
			{
				Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 200, default(Color), 1.2f);
			}
			if (this.head == 45 && this.body == 26 && this.legs == 25 && Main.rand.Next(12) == 0)
			{
				Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 186, 0f, 0f, 160, default(Color), 1.4f);
			}
			if (this.head == 76 && this.body == 49 && this.legs == 45)
			{
				this.socialShadow = true;
			}
			if (this.head == 74 && this.body == 48 && this.legs == 44)
			{
				this.socialShadow = true;
			}
			if (this.head == 74 && this.body == 48 && this.legs == 44 && Main.rand.Next(10) == 0)
			{
				Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 200, default(Color), 1.2f);
			}
			if (this.head == 57 && this.body == 37 && this.legs == 35)
			{
				int maxValue = 10;
				if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 1f)
				{
					maxValue = 2;
				}
				if (Main.rand.Next(maxValue) == 0)
				{
					int num3 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 115, 0f, 0f, 140, default(Color), 0.75f);
					Main.dust[num3].noGravity = true;
					Main.dust[num3].fadeIn = 1.5f;
					Main.dust[num3].velocity *= 0.3f;
					Main.dust[num3].velocity += this.velocity * 0.2f;
				}
			}
			if (this.head == 6 && this.body == 6 && this.legs == 6 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 1f && !this.rocketFrame)
			{
				for (int k = 0; k < 2; k++)
				{
					int num4 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num4].noGravity = true;
					Main.dust[num4].noLight = true;
					Dust expr_D25_cp_0 = Main.dust[num4];
					expr_D25_cp_0.velocity.X = expr_D25_cp_0.velocity.X - this.velocity.X * 0.5f;
					Dust expr_D4F_cp_0 = Main.dust[num4];
					expr_D4F_cp_0.velocity.Y = expr_D4F_cp_0.velocity.Y - this.velocity.Y * 0.5f;
				}
			}
			if (this.head == 8 && this.body == 8 && this.legs == 8 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 1f)
			{
				int num5 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 40, 0f, 0f, 50, default(Color), 1.4f);
				Main.dust[num5].noGravity = true;
				Main.dust[num5].velocity.X = this.velocity.X * 0.25f;
				Main.dust[num5].velocity.Y = this.velocity.Y * 0.25f;
			}
			if (this.head == 9 && this.body == 9 && this.legs == 9 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 1f && !this.rocketFrame)
			{
				for (int l = 0; l < 2; l++)
				{
					int num6 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num6].noGravity = true;
					Main.dust[num6].noLight = true;
					Dust expr_F94_cp_0 = Main.dust[num6];
					expr_F94_cp_0.velocity.X = expr_F94_cp_0.velocity.X - this.velocity.X * 0.5f;
					Dust expr_FBE_cp_0 = Main.dust[num6];
					expr_FBE_cp_0.velocity.Y = expr_FBE_cp_0.velocity.Y - this.velocity.Y * 0.5f;
				}
			}
			if (this.body == 18 && this.legs == 17 && (this.head == 32 || this.head == 33 || this.head == 34) && Main.rand.Next(10) == 0)
			{
				int num7 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 43, 0f, 0f, 100, default(Color), 0.3f);
				Main.dust[num7].fadeIn = 0.8f;
				Main.dust[num7].velocity *= 0f;
			}
			if (this.body == 24 && this.legs == 23 && (this.head == 42 || this.head == 43 || this.head == 41) && this.velocity.X != 0f && this.velocity.Y != 0f && Main.rand.Next(10) == 0)
			{
				int num8 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 43, 0f, 0f, 100, default(Color), 0.3f);
				Main.dust[num8].fadeIn = 0.8f;
				Main.dust[num8].velocity *= 0f;
			}
			if (this.body == 36 && this.head == 56 && this.velocity.X != 0f && this.velocity.Y == 0f)
			{
				for (int m = 0; m < 2; m++)
				{
					int num9 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)((this.gravDir == 1f) ? (this.height - 2) : -4)), this.width, 6, 106, 0f, 0f, 100, default(Color), 0.1f);
					Main.dust[num9].fadeIn = 1f;
					Main.dust[num9].noGravity = true;
					Main.dust[num9].velocity *= 0.2f;
				}
			}
			if (this.body == 27 && this.head == 46 && this.legs == 26)
			{
				this.frostArmor = true;
				if (this.velocity.X != 0f && this.velocity.Y == 0f && this.miscCounter % 2 == 0)
				{
					for (int n = 0; n < 2; n++)
					{
						int num10;
						if (n == 0)
						{
							num10 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
						}
						else
						{
							num10 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
						}
						Main.dust[num10].scale *= 1f + (float)Main.rand.Next(20, 40) * 0.01f;
						Main.dust[num10].noGravity = true;
						Main.dust[num10].noLight = true;
						Main.dust[num10].velocity *= 0.001f;
						Dust expr_1489_cp_0 = Main.dust[num10];
						expr_1489_cp_0.velocity.Y = expr_1489_cp_0.velocity.Y - 0.003f;
					}
				}
			}
			if (this.wings > 0)
			{
				this.back = -1;
				this.front = -1;
			}
			if (this.head > 0 && this.face != 7)
			{
				this.face = -1;
			}
			this.bodyFrame.Width = 40;
			this.bodyFrame.Height = 56;
			this.legFrame.Width = 40;
			this.legFrame.Height = 56;
			this.bodyFrame.X = 0;
			this.legFrame.X = 0;
			if (this.itemAnimation > 0 && this.inventory[this.selectedItem].useStyle != 10)
			{
				if (this.inventory[this.selectedItem].useStyle == 1 || this.inventory[this.selectedItem].type == 0)
				{
					if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
					}
					else if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.666)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 2;
					}
					else
					{
						this.bodyFrame.Y = this.bodyFrame.Height;
					}
				}
				else if (this.inventory[this.selectedItem].useStyle == 2)
				{
					if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.5)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
					}
					else
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 2;
					}
				}
				else if (this.inventory[this.selectedItem].useStyle == 3)
				{
					if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.666)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
					}
					else
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
					}
				}
				else if (this.inventory[this.selectedItem].useStyle == 4)
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 2;
				}
				else if (this.inventory[this.selectedItem].useStyle == 5)
				{
					if (this.inventory[this.selectedItem].type == 281 || this.inventory[this.selectedItem].type == 986)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 2;
					}
					else
					{
						float num11 = this.itemRotation * (float)this.direction;
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
						if ((double)num11 < -0.75)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 2;
							if (this.gravDir == -1f)
							{
								this.bodyFrame.Y = this.bodyFrame.Height * 4;
							}
						}
						if ((double)num11 > 0.6)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 4;
							if (this.gravDir == -1f)
							{
								this.bodyFrame.Y = this.bodyFrame.Height * 2;
							}
						}
					}
				}
			}
			else if (this.mount == 1)
			{
				this.bodyFrameCounter = 0.0;
				this.bodyFrame.Y = this.bodyFrame.Height * 3;
			}
			else if (this.pulley)
			{
				if (this.pulleyDir == 2)
				{
					this.bodyFrame.Y = this.bodyFrame.Height;
				}
				else
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 2;
				}
			}
			else if (this.inventory[this.selectedItem].holdStyle == 1 && (!this.wet || !this.inventory[this.selectedItem].noWet))
			{
				this.bodyFrame.Y = this.bodyFrame.Height * 3;
			}
			else if (this.inventory[this.selectedItem].holdStyle == 2 && (!this.wet || !this.inventory[this.selectedItem].noWet))
			{
				this.bodyFrame.Y = this.bodyFrame.Height * 2;
			}
			else if (this.inventory[this.selectedItem].holdStyle == 3)
			{
				this.bodyFrame.Y = this.bodyFrame.Height * 3;
			}
			else if (this.grappling[0] >= 0)
			{
				this.sandStorm = false;
				this.dJumpEffect = false;
				this.dJumpEffect2 = false;
				this.dJumpEffect3 = false;
				Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num12 = 0f;
				float num13 = 0f;
				for (int num14 = 0; num14 < this.grapCount; num14++)
				{
					num12 += Main.projectile[this.grappling[num14]].position.X + (float)(Main.projectile[this.grappling[num14]].width / 2);
					num13 += Main.projectile[this.grappling[num14]].position.Y + (float)(Main.projectile[this.grappling[num14]].height / 2);
				}
				num12 /= (float)this.grapCount;
				num13 /= (float)this.grapCount;
				num12 -= vector.X;
				num13 -= vector.Y;
				if (num13 < 0f && Math.Abs(num13) > Math.Abs(num12))
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 2;
					if (this.gravDir == -1f)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 4;
					}
				}
				else if (num13 > 0f && Math.Abs(num13) > Math.Abs(num12))
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 4;
					if (this.gravDir == -1f)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 2;
					}
				}
				else
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 3;
				}
			}
			else if (this.swimTime > 0)
			{
				if (this.swimTime > 20)
				{
					this.bodyFrame.Y = 0;
				}
				else if (this.swimTime > 10)
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 5;
				}
				else
				{
					this.bodyFrame.Y = 0;
				}
			}
			else if (this.velocity.Y != 0f)
			{
				if (this.sliding)
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 3;
				}
				else if (this.sandStorm || this.carpetFrame >= 0)
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 6;
				}
				else if (this.wings > 0)
				{
					if (this.wings == 22)
					{
						this.bodyFrame.Y = 0;
					}
					else if (this.velocity.Y > 0f)
					{
						if (this.controlJump)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 6;
						}
						else
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 5;
						}
					}
					else
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 6;
					}
				}
				else
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 5;
				}
				this.bodyFrameCounter = 0.0;
			}
			else if (this.velocity.X != 0f)
			{
				this.bodyFrameCounter += (double)Math.Abs(this.velocity.X) * 1.5;
				this.bodyFrame.Y = this.legFrame.Y;
			}
			else
			{
				this.bodyFrameCounter = 0.0;
				this.bodyFrame.Y = 0;
			}
			if (this.mount == 1)
			{
				this.legFrameCounter = 0.0;
				this.legFrame.Y = this.legFrame.Height * 6;
				if (this.velocity.Y != 0f)
				{
					if (this.mountFlyTime > 0 && this.jump == 0 && this.controlJump)
					{
						if (this.direction > 0)
						{
							if (Main.rand.Next(4) == 0)
							{
								int num15 = Dust.NewDust(new Vector2(this.Center().X - 22f, this.position.Y + (float)this.height - 6f), 20, 10, 64, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 255, default(Color), 1f);
								Main.dust[num15].velocity *= 0.1f;
								Main.dust[num15].noLight = true;
							}
							if (Main.rand.Next(4) == 0)
							{
								int num16 = Dust.NewDust(new Vector2(this.Center().X + 12f, this.position.Y + (float)this.height - 6f), 20, 10, 64, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 255, default(Color), 1f);
								Main.dust[num16].velocity *= 0.1f;
								Main.dust[num16].noLight = true;
							}
						}
						else
						{
							if (Main.rand.Next(4) == 0)
							{
								int num17 = Dust.NewDust(new Vector2(this.Center().X - 32f, this.position.Y + (float)this.height - 6f), 20, 10, 64, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 255, default(Color), 1f);
								Main.dust[num17].velocity *= 0.1f;
								Main.dust[num17].noLight = true;
							}
							if (Main.rand.Next(4) == 0)
							{
								int num18 = Dust.NewDust(new Vector2(this.Center().X + 2f, this.position.Y + (float)this.height - 6f), 20, 10, 64, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 255, default(Color), 1f);
								Main.dust[num18].velocity *= 0.1f;
								Main.dust[num18].noLight = true;
							}
						}
						this.mountFrameCounter += 1f;
						if (this.mountFrameCounter > 6f)
						{
							this.mountFrameCounter = 0f;
							this.mountFrame++;
						}
						if (this.mountFrame < 6)
						{
							this.mountFrame = 6;
						}
						if (this.mountFrame > 11)
						{
							this.mountFrame = 6;
						}
					}
					else
					{
						this.mountFrameCounter = 0f;
						this.mountFrame = 1;
					}
				}
				else if (this.velocity.X == 0f)
				{
					this.mountFrameCounter = 0f;
					this.mountFrame = 0;
				}
				else
				{
					this.mountFrameCounter += Math.Abs(this.velocity.X);
					if (this.mountFrameCounter > 12f)
					{
						this.mountFrameCounter = 0f;
						this.mountFrame++;
					}
					if (this.mountFrame < 6)
					{
						this.mountFrame = 6;
					}
					if (this.mountFrame > 11)
					{
						this.mountFrame = 6;
					}
				}
			}
			else if (this.swimTime > 0)
			{
				this.legFrameCounter += 2.0;
				while (this.legFrameCounter > 8.0)
				{
					this.legFrameCounter -= 8.0;
					this.legFrame.Y = this.legFrame.Y + this.legFrame.Height;
				}
				if (this.legFrame.Y < this.legFrame.Height * 7)
				{
					this.legFrame.Y = this.legFrame.Height * 19;
				}
				else if (this.legFrame.Y > this.legFrame.Height * 19)
				{
					this.legFrame.Y = this.legFrame.Height * 7;
				}
			}
			else if (this.velocity.Y != 0f || this.grappling[0] > -1)
			{
				this.legFrameCounter = 0.0;
				this.legFrame.Y = this.legFrame.Height * 5;
				if (this.wings == 22)
				{
					this.legFrame.Y = 0;
				}
			}
			else if (this.velocity.X != 0f)
			{
				if ((this.slippy || this.slippy2) && !this.controlLeft && !this.controlRight)
				{
					this.legFrameCounter = 0.0;
					this.legFrame.Y = 0;
				}
				else
				{
					this.legFrameCounter += (double)Math.Abs(this.velocity.X) * 1.3;
					while (this.legFrameCounter > 8.0)
					{
						this.legFrameCounter -= 8.0;
						this.legFrame.Y = this.legFrame.Y + this.legFrame.Height;
					}
					if (this.legFrame.Y < this.legFrame.Height * 7)
					{
						this.legFrame.Y = this.legFrame.Height * 19;
					}
					else if (this.legFrame.Y > this.legFrame.Height * 19)
					{
						this.legFrame.Y = this.legFrame.Height * 7;
					}
				}
			}
			else
			{
				this.legFrameCounter = 0.0;
				this.legFrame.Y = 0;
			}
			if (this.carpetFrame >= 0)
			{
				this.legFrameCounter = 0.0;
				this.legFrame.Y = 0;
			}
			if (this.sandStorm)
			{
				if (this.miscCounter % 4 == 0 && this.itemAnimation == 0)
				{
					this.ChangeDir(this.direction * -1);
					if (this.inventory[this.selectedItem].holdStyle == 2)
					{
						if (this.inventory[this.selectedItem].type == 946)
						{
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f - (float)(16 * this.direction);
						}
						if (this.inventory[this.selectedItem].type == 186)
						{
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f + (float)(6 * this.direction);
							this.itemRotation = 0.79f * (float)(-(float)this.direction);
						}
					}
				}
				this.legFrameCounter = 0.0;
				this.legFrame.Y = 0;
			}
		}
		public void Teleport(Vector2 newPos, int Style = 0)
		{
			try
			{
				this.grappling[0] = -1;
				this.grapCount = 0;
				for (int i = 0; i < 1000; i++)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == this.whoAmi && Main.projectile[i].aiStyle == 7)
					{
						Main.projectile[i].Kill();
					}
				}
				Main.TeleportEffect(this.getRect(), Style);
				this.position = newPos;
				this.fallStart = (int)(this.position.Y / 16f);
				Main.TeleportEffect(this.getRect(), Style);
				this.teleportTime = 1f;
				this.teleportStyle = Style;
			}
			catch
			{
			}
		}
		public void Spawn()
		{
			if (this.whoAmi == Main.myPlayer)
			{
				if (Main.mapTime < 5)
				{
					Main.mapTime = 5;
				}
				Main.quickBG = 10;
				this.FindSpawn();
				if (!Player.CheckSpawn(this.SpawnX, this.SpawnY))
				{
					this.SpawnX = -1;
					this.SpawnY = -1;
				}
				Main.maxQ = true;
			}
			if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(12, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				Main.gameMenu = false;
			}
			this.headPosition = default(Vector2);
			this.bodyPosition = default(Vector2);
			this.legPosition = default(Vector2);
			this.headRotation = 0f;
			this.bodyRotation = 0f;
			this.legRotation = 0f;
			this.lavaTime = this.lavaMax;
			if (this.statLife <= 0)
			{
				this.statLife = 100;
				this.breath = this.breathMax;
				if (this.spawnMax)
				{
					this.statLife = this.statLifeMax;
					this.statMana = this.statManaMax2;
				}
			}
			this.immune = true;
			this.dead = false;
			this.immuneTime = 0;
			this.active = true;
			if (this.SpawnX >= 0 && this.SpawnY >= 0)
			{
				this.position.X = (float)(this.SpawnX * 16 + 8 - this.width / 2);
				this.position.Y = (float)(this.SpawnY * 16 - this.height);
			}
			else
			{
				this.position.X = (float)(Main.spawnTileX * 16 + 8 - this.width / 2);
				this.position.Y = (float)(Main.spawnTileY * 16 - this.height);
				for (int i = Main.spawnTileX - 1; i < Main.spawnTileX + 2; i++)
				{
					for (int j = Main.spawnTileY - 3; j < Main.spawnTileY; j++)
					{
						if (Main.tileSolid[(int)Main.tile[i, j].type] && !Main.tileSolidTop[(int)Main.tile[i, j].type])
						{
							WorldGen.KillTile(i, j, false, false, false);
						}
						if (Main.tile[i, j].liquid > 0)
						{
							Main.tile[i, j].lava(false);
							Main.tile[i, j].liquid = 0;
							WorldGen.SquareTileFrame(i, j, true);
						}
					}
				}
			}
			this.wet = false;
			this.wetCount = 0;
			this.lavaWet = false;
			this.fallStart = (int)(this.position.Y / 16f);
			this.velocity.X = 0f;
			this.velocity.Y = 0f;
			this.talkNPC = -1;
			if (this.pvpDeath)
			{
				this.pvpDeath = false;
				this.immuneTime = 300;
				this.statLife = this.statLifeMax;
			}
			else
			{
				this.immuneTime = 60;
			}
			if (this.whoAmi == Main.myPlayer)
			{
				Main.BlackFadeIn = 255;
				Main.renderNow = true;
				Main.screenPosition.X = this.position.X + (float)(this.width / 2) - (float)(Main.screenWidth / 2);
				Main.screenPosition.Y = this.position.Y + (float)(this.height / 2) - (float)(Main.screenHeight / 2);
			}
		}
		public void ShadowDodge()
		{
			this.immune = true;
			this.immuneTime = 80;
			if (this.longInvince)
			{
				this.immuneTime += 40;
			}
			if (this.whoAmi == Main.myPlayer)
			{
				for (int i = 0; i < 22; i++)
				{
					if (this.buffTime[i] > 0 && this.buffType[i] == 59)
					{
						this.DelBuff(i);
					}
				}
				NetMessage.SendData(62, -1, -1, "", this.whoAmi, 2f, 0f, 0f, 0);
			}
		}
		public void NinjaDodge()
		{
			this.immune = true;
			this.immuneTime = 80;
			if (this.longInvince)
			{
				this.immuneTime += 40;
			}
			for (int i = 0; i < 100; i++)
			{
				int num = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 2f);
				Dust expr_82_cp_0 = Main.dust[num];
				expr_82_cp_0.position.X = expr_82_cp_0.position.X + (float)Main.rand.Next(-20, 21);
				Dust expr_A9_cp_0 = Main.dust[num];
				expr_A9_cp_0.position.Y = expr_A9_cp_0.position.Y + (float)Main.rand.Next(-20, 21);
				Main.dust[num].velocity *= 0.4f;
				Main.dust[num].scale *= 1f + (float)Main.rand.Next(40) * 0.01f;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num].scale *= 1f + (float)Main.rand.Next(40) * 0.01f;
					Main.dust[num].noGravity = true;
				}
			}
			int num2 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
			Main.gore[num2].scale = 1.5f;
			Main.gore[num2].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity *= 0.4f;
			num2 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
			Main.gore[num2].scale = 1.5f;
			Main.gore[num2].velocity.X = 1.5f + (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity.Y = 1.5f + (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity *= 0.4f;
			num2 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
			Main.gore[num2].scale = 1.5f;
			Main.gore[num2].velocity.X = -1.5f - (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity.Y = 1.5f + (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity *= 0.4f;
			num2 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
			Main.gore[num2].scale = 1.5f;
			Main.gore[num2].velocity.X = 1.5f + (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity.Y = -1.5f - (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity *= 0.4f;
			num2 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
			Main.gore[num2].scale = 1.5f;
			Main.gore[num2].velocity.X = -1.5f - (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity.Y = -1.5f - (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity *= 0.4f;
			if (this.whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(62, -1, -1, "", this.whoAmi, 1f, 0f, 0f, 0);
			}
		}
		public double Hurt(int Damage, int hitDirection, bool pvp = false, bool quiet = false, string deathText = " was slain...", bool Crit = false)
		{
			if (this.immune)
			{
				return 0.0;
			}
			if (this.whoAmi == Main.myPlayer && this.blackBelt && Main.rand.Next(10) == 0)
			{
				this.NinjaDodge();
				return 0.0;
			}
			if (this.whoAmi == Main.myPlayer && this.shadowDodge)
			{
				this.ShadowDodge();
				return 0.0;
			}
			if (this.whoAmi == Main.myPlayer && this.panic)
			{
				this.AddBuff(63, 300, true);
			}
			int num = Damage;
			double num2 = Main.CalculateDamage(num, this.statDefense);
			if (Crit)
			{
				num *= 2;
			}
			if (num2 >= 1.0)
			{
				if (this.beetleDefense && this.beetleOrbs > 0)
				{
					float num3 = 0.15f * (float)this.beetleOrbs;
					num2 = (double)((int)((double)(1f - num3) * num2));
					this.beetleOrbs--;
					for (int i = 0; i < 22; i++)
					{
						if (this.buffType[i] >= 95 && this.buffType[i] <= 97)
						{
							this.DelBuff(i);
						}
					}
					if (this.beetleOrbs > 0)
					{
						this.AddBuff(95 + this.beetleOrbs - 1, 5, false);
					}
					this.beetleCounter = 0f;
					if (num2 < 1.0)
					{
						num2 = 1.0;
					}
				}
				if (this.magicCuffs)
				{
					int num4 = num;
					this.statMana += num4;
					if (this.statMana > this.statManaMax2)
					{
						this.statMana = this.statManaMax2;
					}
				}
				if (this.paladinBuff)
				{
					int damage = (int)(num2 * 0.25);
					num2 = (double)((int)(num2 * 0.75));
					if (this.whoAmi != Main.myPlayer && Main.player[Main.myPlayer].paladinGive)
					{
						int myPlayer = Main.myPlayer;
						if (Main.player[myPlayer].team == this.team && this.team != 0)
						{
							float num5 = this.position.X - Main.player[myPlayer].position.X;
							float num6 = this.position.Y - Main.player[myPlayer].position.Y;
							float num7 = (float)Math.Sqrt((double)(num5 * num5 + num6 * num6));
							if (num7 < 800f)
							{
								Main.player[myPlayer].Hurt(damage, 0, false, false, "", false);
							}
						}
					}
				}
				if (Main.netMode == 1 && this.whoAmi == Main.myPlayer && !quiet)
				{
					int number = 0;
					if (Crit)
					{
						number = 1;
					}
					int num8 = 0;
					if (pvp)
					{
						num8 = 1;
					}
					NetMessage.SendData(13, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
					NetMessage.SendData(16, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
					NetMessage.SendData(26, -1, -1, "", this.whoAmi, (float)hitDirection, (float)Damage, (float)num8, number);
				}
				this.statLife -= (int)num2;
				this.immune = true;
				if (num2 == 1.0)
				{
					this.immuneTime = 20;
					if (this.longInvince)
					{
						this.immuneTime += 20;
					}
				}
				else
				{
					this.immuneTime = 40;
					if (this.longInvince)
					{
						this.immuneTime += 40;
					}
				}
				this.lifeRegenTime = 0;
				if (pvp)
				{
					this.immuneTime = 8;
				}
				if (this.whoAmi == Main.myPlayer)
				{
					if (this.starCloak)
					{
						for (int j = 0; j < 3; j++)
						{
							float x = this.position.X + (float)Main.rand.Next(-400, 400);
							float y = this.position.Y - (float)Main.rand.Next(500, 800);
							Vector2 vector = new Vector2(x, y);
							float num9 = this.position.X + (float)(this.width / 2) - vector.X;
							float num10 = this.position.Y + (float)(this.height / 2) - vector.Y;
							num9 += (float)Main.rand.Next(-100, 101);
							int num11 = 23;
							float num12 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
							num12 = (float)num11 / num12;
							num9 *= num12;
							num10 *= num12;
							int num13 = Projectile.NewProjectile(x, y, num9, num10, 92, 30, 5f, this.whoAmi, 0f, 0f);
							Main.projectile[num13].ai[1] = this.position.Y;
						}
					}
					if (this.bee)
					{
						int num14 = 1;
						if (Main.rand.Next(3) == 0)
						{
							num14++;
						}
						if (Main.rand.Next(3) == 0)
						{
							num14++;
						}
						for (int k = 0; k < num14; k++)
						{
							float speedX = (float)Main.rand.Next(-35, 36) * 0.02f;
							float speedY = (float)Main.rand.Next(-35, 36) * 0.02f;
							Projectile.NewProjectile(this.position.X, this.position.Y, speedX, speedY, 181, 7, 0f, Main.myPlayer, 0f, 0f);
						}
					}
				}
				if (!this.noKnockback && hitDirection != 0)
				{
					this.velocity.X = 4.5f * (float)hitDirection;
					this.velocity.Y = -3.5f;
				}
				if (this.frostArmor)
				{
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
				}
				else if (this.wereWolf)
				{
					Main.PlaySound(3, (int)this.position.X, (int)this.position.Y, 6);
				}
				else if (this.boneArmor)
				{
					Main.PlaySound(3, (int)this.position.X, (int)this.position.Y, 2);
				}
				else if (!this.male)
				{
					Main.PlaySound(20, (int)this.position.X, (int)this.position.Y, 1);
				}
				else
				{
					Main.PlaySound(1, (int)this.position.X, (int)this.position.Y, 1);
				}
				if (this.statLife > 0)
				{
					int num15 = 0;
					while ((double)num15 < num2 / (double)this.statLifeMax * 100.0)
					{
						if (this.body == 27 && this.head == 46 && this.legs == 26)
						{
							Dust.NewDust(this.position, this.width, this.height, 135, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
						}
						else if (this.boneArmor)
						{
							Dust.NewDust(this.position, this.width, this.height, 26, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
						}
						else
						{
							Dust.NewDust(this.position, this.width, this.height, 5, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
						}
						num15++;
					}
				}
				else
				{
					this.statLife = 0;
					if (this.whoAmi == Main.myPlayer)
					{
						this.KillMe(num2, hitDirection, pvp, deathText);
					}
				}
			}
			if (pvp)
			{
				num2 = Main.CalculateDamage(num, this.statDefense);
			}
			return num2;
		}
		public void KillMeForGood()
		{
			if (File.Exists(Main.playerPathName))
			{
				File.Delete(Main.playerPathName);
			}
			if (File.Exists(Main.playerPathName + ".bak"))
			{
				File.Delete(Main.playerPathName + ".bak");
			}
			if (File.Exists(Main.playerPathName + ".dat"))
			{
				File.Delete(Main.playerPathName + ".dat");
			}
			Main.playerPathName = "";
		}
		public void KillMe(double dmg, int hitDirection, bool pvp = false, string deathText = " was slain...")
		{
			if (this.dead)
			{
				return;
			}
			if (pvp)
			{
				this.pvpDeath = true;
			}
			if (this.difficulty == 0)
			{
				if (Main.netMode != 1)
				{
					float num = (float)Main.rand.Next(-35, 36) * 0.1f;
					while (num < 2f && num > -2f)
					{
						num += (float)Main.rand.Next(-30, 31) * 0.1f;
					}
					int num2 = Main.rand.Next(6);
					if (num2 == 0)
					{
						num2 = 43;
					}
					else
					{
						num2 = 200 + num2;
					}
					int num3 = Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.head / 2), (float)Main.rand.Next(10, 30) * 0.1f * (float)hitDirection + num, (float)Main.rand.Next(-40, -20) * 0.1f, num2, 0, 0f, Main.myPlayer, 0f, 0f);
					Main.projectile[num3].miscText = this.name + deathText;
				}
				if (Main.myPlayer == this.whoAmi)
				{
					for (int i = 0; i < 59; i++)
					{
						if (this.inventory[i].stack > 0 && this.inventory[i].type >= 1522 && this.inventory[i].type <= 1527)
						{
							int num4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[i].type, 1, false, 0, false);
							Main.item[num4].SetDefaults(this.inventory[i].name);
							Main.item[num4].Prefix((int)this.inventory[i].prefix);
							Main.item[num4].stack = this.inventory[i].stack;
							Main.item[num4].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
							Main.item[num4].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
							Main.item[num4].noGrabDelay = 100;
							if (Main.netMode == 1)
							{
								NetMessage.SendData(21, -1, -1, "", num4, 0f, 0f, 0f, 0);
							}
							this.inventory[i].SetDefaults(0, false);
						}
					}
					Main.mapFullscreen = false;
				}
			}
			else
			{
				if (Main.netMode != 1)
				{
					float num5 = (float)Main.rand.Next(-35, 36) * 0.1f;
					while (num5 < 2f && num5 > -2f)
					{
						num5 += (float)Main.rand.Next(-30, 31) * 0.1f;
					}
					int num6 = Main.rand.Next(6);
					if (num6 == 0)
					{
						num6 = 43;
					}
					else
					{
						num6 = 200 + num6;
					}
					int num7 = Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.head / 2), (float)Main.rand.Next(10, 30) * 0.1f * (float)hitDirection + num5, (float)Main.rand.Next(-40, -20) * 0.1f, num6, 0, 0f, Main.myPlayer, 0f, 0f);
					Main.projectile[num7].miscText = this.name + deathText;
				}
				if (Main.myPlayer == this.whoAmi)
				{
					if (Main.myPlayer == this.whoAmi)
					{
						Main.mapFullscreen = false;
					}
					Main.trashItem.SetDefaults(0, false);
					if (this.difficulty == 1)
					{
						this.DropItems();
					}
					else if (this.difficulty == 2)
					{
						this.DropItems();
						this.KillMeForGood();
					}
				}
			}
			Main.PlaySound(5, (int)this.position.X, (int)this.position.Y, 1);
			this.headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
			this.bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
			this.legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
			this.headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
			this.bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
			this.legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
			for (int j = 0; j < 100; j++)
			{
				if (this.boneArmor)
				{
					Dust.NewDust(this.position, this.width, this.height, 26, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
				}
				else
				{
					Dust.NewDust(this.position, this.width, this.height, 5, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
				}
			}
			this.mount = 0;
			this.dead = true;
			this.respawnTimer = 600;
			bool flag = false;
			if (Main.netMode != 0 && !pvp)
			{
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && (Main.npc[k].boss || Main.npc[k].type == 13 || Main.npc[k].type == 14 || Main.npc[k].type == 15) && Math.Abs(this.center().X - Main.npc[k].center().X) + Math.Abs(this.center().Y - Main.npc[k].center().Y) < 4000f)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				this.respawnTimer += 600;
			}
			this.immuneAlpha = 0;
			this.palladiumRegen = false;
			this.iceBarrier = false;
			this.crystalLeaf = false;
			if (Main.netMode == 2)
			{
				NetMessage.SendData(25, -1, -1, this.name + deathText, 255, 225f, 25f, 25f, 0);
			}
			else if (Main.netMode == 0)
			{
				Main.NewText(this.name + deathText, 225, 25, 25, false);
			}
			if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
			{
				int num8 = 0;
				if (pvp)
				{
					num8 = 1;
				}
				NetMessage.SendData(44, -1, -1, deathText, this.whoAmi, (float)hitDirection, (float)((int)dmg), (float)num8, 0);
			}
			if (!pvp && this.whoAmi == Main.myPlayer && this.difficulty == 0)
			{
				this.DropCoins();
			}
		}
		public bool ItemSpace(Item newItem)
		{
			if (newItem.type == 58 || newItem.type == 184 || newItem.type == 1734 || newItem.type == 1735 || newItem.type == 1867 || newItem.type == 1868)
			{
				return true;
			}
			int num = 50;
			if (newItem.type == 71 || newItem.type == 72 || newItem.type == 73 || newItem.type == 74)
			{
				num = 54;
			}
			for (int i = 0; i < num; i++)
			{
				if (this.inventory[i].type == 0)
				{
					return true;
				}
			}
			for (int j = 0; j < num; j++)
			{
				if (this.inventory[j].type > 0 && this.inventory[j].stack < this.inventory[j].maxStack && newItem.IsTheSameAs(this.inventory[j]))
				{
					return true;
				}
			}
			if (newItem.ammo > 0 && !newItem.notAmmo)
			{
				if (newItem.type != 75 && newItem.type != 169 && newItem.type != 23 && newItem.type != 408 && newItem.type != 370)
				{
					for (int k = 54; k < 58; k++)
					{
						if (this.inventory[k].type == 0)
						{
							return true;
						}
					}
				}
				for (int l = 54; l < 58; l++)
				{
					if (this.inventory[l].type > 0 && this.inventory[l].stack < this.inventory[l].maxStack && newItem.IsTheSameAs(this.inventory[l]))
					{
						return true;
					}
				}
			}
			return false;
		}
		public void DoCoins(int i)
		{
			if (this.inventory[i].stack == 100 && (this.inventory[i].type == 71 || this.inventory[i].type == 72 || this.inventory[i].type == 73))
			{
				this.inventory[i].SetDefaults(this.inventory[i].type + 1, false);
				for (int j = 0; j < 54; j++)
				{
					if (this.inventory[j].IsTheSameAs(this.inventory[i]) && j != i && this.inventory[j].type == this.inventory[i].type && this.inventory[j].stack < this.inventory[j].maxStack)
					{
						this.inventory[j].stack++;
						this.inventory[i].SetDefaults(0, false);
						this.inventory[i].active = false;
						this.inventory[i].name = "";
						this.inventory[i].type = 0;
						this.inventory[i].stack = 0;
						this.DoCoins(j);
					}
				}
			}
		}
		public Item FillAmmo(int plr, Item newItem)
		{
			for (int i = 54; i < 58; i++)
			{
				if (this.inventory[i].type > 0 && this.inventory[i].stack < this.inventory[i].maxStack && newItem.IsTheSameAs(this.inventory[i]))
				{
					Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
					if (newItem.stack + this.inventory[i].stack <= this.inventory[i].maxStack)
					{
						this.inventory[i].stack += newItem.stack;
						this.DoCoins(i);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						return new Item();
					}
					newItem.stack -= this.inventory[i].maxStack - this.inventory[i].stack;
					this.inventory[i].stack = this.inventory[i].maxStack;
					this.DoCoins(i);
					if (plr == Main.myPlayer)
					{
						Recipe.FindRecipes();
					}
				}
			}
			if (newItem.type != 169 && newItem.type != 75 && newItem.type != 23 && newItem.type != 408 && newItem.type != 370 && !newItem.notAmmo)
			{
				for (int j = 54; j < 58; j++)
				{
					if (this.inventory[j].type == 0)
					{
						this.inventory[j] = newItem;
						this.DoCoins(j);
						Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						return new Item();
					}
				}
			}
			return newItem;
		}
		public Item GetItem(int plr, Item newItem)
		{
			Item item = newItem;
			int num = 50;
			if (newItem.noGrabDelay > 0)
			{
				return item;
			}
			int num2 = 0;
			if (newItem.type == 71 || newItem.type == 72 || newItem.type == 73 || newItem.type == 74)
			{
				num2 = -4;
				num = 54;
			}
			if (item.ammo > 0 && !item.notAmmo)
			{
				item = this.FillAmmo(plr, item);
				if (item.type == 0 || item.stack == 0)
				{
					return new Item();
				}
			}
			for (int i = num2; i < 50; i++)
			{
				int num3 = i;
				if (num3 < 0)
				{
					num3 = 54 + i;
				}
				if (this.inventory[num3].type > 0 && this.inventory[num3].stack < this.inventory[num3].maxStack && item.IsTheSameAs(this.inventory[num3]))
				{
					Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
					if (item.stack + this.inventory[num3].stack <= this.inventory[num3].maxStack)
					{
						this.inventory[num3].stack += item.stack;
						this.DoCoins(num3);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						return new Item();
					}
					item.stack -= this.inventory[num3].maxStack - this.inventory[num3].stack;
					this.inventory[num3].stack = this.inventory[num3].maxStack;
					this.DoCoins(num3);
					if (plr == Main.myPlayer)
					{
						Recipe.FindRecipes();
					}
				}
			}
			if (newItem.type != 71 && newItem.type != 72 && newItem.type != 73 && newItem.type != 74 && newItem.useStyle > 0)
			{
				for (int j = 0; j < 10; j++)
				{
					if (this.inventory[j].type == 0)
					{
						this.inventory[j] = item;
						this.DoCoins(j);
						Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						return new Item();
					}
				}
			}
			for (int k = num - 1; k >= 0; k--)
			{
				if (this.inventory[k].type == 0)
				{
					this.inventory[k] = item;
					this.DoCoins(k);
					Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
					if (plr == Main.myPlayer)
					{
						Recipe.FindRecipes();
					}
					return new Item();
				}
			}
			return item;
		}
		public void PlaceThing()
		{
			if ((this.inventory[this.selectedItem].type == 1071 || this.inventory[this.selectedItem].type == 1543) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
			{
				int num = Player.tileTargetX;
				int num2 = Player.tileTargetY;
				if (Main.tile[num, num2] != null && Main.tile[num, num2].active())
				{
					this.showItemIcon = true;
					if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
					{
						int num3 = -1;
						int num4 = -1;
						for (int i = 0; i < 58; i++)
						{
							if (this.inventory[i].stack > 0 && this.inventory[i].paint > 0)
							{
								num3 = (int)this.inventory[i].paint;
								num4 = i;
								break;
							}
						}
						if (num3 > 0 && (int)Main.tile[num, num2].color() != num3 && WorldGen.paintTile(num, num2, (byte)num3, true))
						{
							int num5 = num4;
							this.inventory[num5].stack--;
							if (this.inventory[num5].stack <= 0)
							{
								this.inventory[num5].SetDefaults(0, false);
							}
							this.itemTime = this.inventory[this.selectedItem].useTime;
						}
					}
				}
			}
			if ((this.inventory[this.selectedItem].type == 1072 || this.inventory[this.selectedItem].type == 1544) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
			{
				int num6 = Player.tileTargetX;
				int num7 = Player.tileTargetY;
				if (Main.tile[num6, num7] != null && Main.tile[num6, num7].wall > 0)
				{
					this.showItemIcon = true;
					if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
					{
						int num8 = -1;
						int num9 = -1;
						for (int j = 0; j < 58; j++)
						{
							if (this.inventory[j].stack > 0 && this.inventory[j].paint > 0)
							{
								num8 = (int)this.inventory[j].paint;
								num9 = j;
								break;
							}
						}
						if (num8 > 0 && (int)Main.tile[num6, num7].wallColor() != num8 && WorldGen.paintWall(num6, num7, (byte)num8, true))
						{
							int num10 = num9;
							this.inventory[num10].stack--;
							if (this.inventory[num10].stack <= 0)
							{
								this.inventory[num10].SetDefaults(0, false);
							}
							this.itemTime = this.inventory[this.selectedItem].useTime;
						}
					}
				}
			}
			if ((this.inventory[this.selectedItem].type == 1100 || this.inventory[this.selectedItem].type == 1545) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
			{
				int num11 = Player.tileTargetX;
				int num12 = Player.tileTargetY;
				if (Main.tile[num11, num12] != null && ((Main.tile[num11, num12].wallColor() > 0 && Main.tile[num11, num12].wall > 0) || (Main.tile[num11, num12].color() > 0 && Main.tile[num11, num12].active())))
				{
					this.showItemIcon = true;
					if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
					{
						if (Main.tile[num11, num12].color() > 0 && Main.tile[num11, num12].active() && WorldGen.paintTile(num11, num12, 0, true))
						{
							this.itemTime = this.inventory[this.selectedItem].useTime;
						}
						else if (Main.tile[num11, num12].wallColor() > 0 && Main.tile[num11, num12].wall > 0 && WorldGen.paintWall(num11, num12, 0, true))
						{
							this.itemTime = this.inventory[this.selectedItem].useTime;
						}
					}
				}
			}
			if ((this.inventory[this.selectedItem].type == 929 || this.inventory[this.selectedItem].type == 1338) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
			{
				int num13 = Player.tileTargetX;
				int num14 = Player.tileTargetY;
				if (Main.tile[num13, num14].active() && Main.tile[num13, num14].type == 209)
				{
					int num15 = 0;
					if (Main.tile[num13, num14].frameX < 72)
					{
						if (this.inventory[this.selectedItem].type == 929)
						{
							num15 = 1;
						}
					}
					else if (Main.tile[num13, num14].frameX < 144 && this.inventory[this.selectedItem].type == 1338)
					{
						num15 = 2;
					}
					if (num15 > 0)
					{
						this.showItemIcon = true;
						if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
						{
							int k = Main.tile[num13, num14].frameX / 18;
							int num16 = 0;
							int num17 = 0;
							while (k >= 4)
							{
								num16++;
								k -= 4;
							}
							k = num13 - k;
							int l;
							for (l = Main.tile[num13, num14].frameY / 18; l >= 3; l -= 3)
							{
								num17++;
							}
							l = num14 - l;
							this.itemTime = this.inventory[this.selectedItem].useTime;
							float num18 = 14f;
							float num19 = 0f;
							float num20 = 0f;
							int type = 162;
							if (num15 == 2)
							{
								type = 281;
							}
							int damage = this.inventory[this.selectedItem].damage;
							int num21 = 8;
							if (num17 == 0)
							{
								num19 = 10f;
								num20 = 0f;
							}
							if (num17 == 1)
							{
								num19 = 7.5f;
								num20 = -2.5f;
							}
							if (num17 == 2)
							{
								num19 = 5f;
								num20 = -5f;
							}
							if (num17 == 3)
							{
								num19 = 2.75f;
								num20 = -6f;
							}
							if (num17 == 4)
							{
								num19 = 0f;
								num20 = -10f;
							}
							if (num17 == 5)
							{
								num19 = -2.75f;
								num20 = -6f;
							}
							if (num17 == 6)
							{
								num19 = -5f;
								num20 = -5f;
							}
							if (num17 == 7)
							{
								num19 = -7.5f;
								num20 = -2.5f;
							}
							if (num17 == 8)
							{
								num19 = -10f;
								num20 = 0f;
							}
							Vector2 vector = new Vector2((float)((k + 2) * 16), (float)((l + 2) * 16));
							float num22 = num19;
							float num23 = num20;
							float num24 = (float)Math.Sqrt((double)(num22 * num22 + num23 * num23));
							num24 = num18 / num24;
							num22 *= num24;
							num23 *= num24;
							Projectile.NewProjectile(vector.X, vector.Y, num22, num23, type, damage, (float)num21, Main.myPlayer, 0f, 0f);
						}
					}
				}
			}
			if (this.inventory[this.selectedItem].type >= 1874 && this.inventory[this.selectedItem].type <= 1905 && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 171 && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
			{
				int num25 = this.inventory[this.selectedItem].type;
				if (num25 >= 1874 && num25 <= 1877)
				{
					num25 -= 1873;
					if (WorldGen.checkXmasTreeDrop(Player.tileTargetX, Player.tileTargetY, 0) != num25)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						WorldGen.dropXmasTree(Player.tileTargetX, Player.tileTargetY, 0);
						WorldGen.setXmasTree(Player.tileTargetX, Player.tileTargetY, 0, num25);
						int num26 = Player.tileTargetX;
						int num27 = Player.tileTargetY;
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 10)
						{
							num26 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameX;
							num27 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
						}
						NetMessage.SendTileSquare(-1, num26, num27, 1);
					}
				}
				else if (num25 >= 1878 && num25 <= 1883)
				{
					num25 -= 1877;
					if (WorldGen.checkXmasTreeDrop(Player.tileTargetX, Player.tileTargetY, 1) != num25)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						WorldGen.dropXmasTree(Player.tileTargetX, Player.tileTargetY, 1);
						WorldGen.setXmasTree(Player.tileTargetX, Player.tileTargetY, 1, num25);
						int num28 = Player.tileTargetX;
						int num29 = Player.tileTargetY;
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 10)
						{
							num28 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameX;
							num29 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
						}
						NetMessage.SendTileSquare(-1, num28, num29, 1);
					}
				}
				else if (num25 >= 1884 && num25 <= 1894)
				{
					num25 -= 1883;
					if (WorldGen.checkXmasTreeDrop(Player.tileTargetX, Player.tileTargetY, 2) != num25)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						WorldGen.dropXmasTree(Player.tileTargetX, Player.tileTargetY, 2);
						WorldGen.setXmasTree(Player.tileTargetX, Player.tileTargetY, 2, num25);
						int num30 = Player.tileTargetX;
						int num31 = Player.tileTargetY;
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 10)
						{
							num30 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameX;
							num31 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
						}
						NetMessage.SendTileSquare(-1, num30, num31, 1);
					}
				}
				else if (num25 >= 1895 && num25 <= 1905)
				{
					num25 -= 1894;
					if (WorldGen.checkXmasTreeDrop(Player.tileTargetX, Player.tileTargetY, 3) != num25)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						WorldGen.dropXmasTree(Player.tileTargetX, Player.tileTargetY, 3);
						WorldGen.setXmasTree(Player.tileTargetX, Player.tileTargetY, 3, num25);
						int num32 = Player.tileTargetX;
						int num33 = Player.tileTargetY;
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 10)
						{
							num32 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameX;
							num33 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
						}
						NetMessage.SendTileSquare(-1, num32, num33, 1);
					}
				}
			}
			if ((this.inventory[this.selectedItem].type == 424 || this.inventory[this.selectedItem].type == 1103) && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 219)
			{
				if (this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					if (this.inventory[this.selectedItem].stack <= 0)
					{
						this.inventory[this.selectedItem].SetDefaults(0, false);
					}
					if (this.selectedItem == 48)
					{
						Main.mouseItem = this.inventory[this.selectedItem];
					}
					Main.PlaySound(7, -1, -1, 1);
					int num34 = 1;
					int num35;
					if (Main.rand.Next(2) == 0)
					{
						if (Main.rand.Next(10000) == 0)
						{
							num35 = 74;
							if (Main.rand.Next(12) == 0)
							{
								num34 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(12) == 0)
							{
								num34 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(12) == 0)
							{
								num34 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(12) == 0)
							{
								num34 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(12) == 0)
							{
								num34 += Main.rand.Next(0, 3);
							}
						}
						else if (Main.rand.Next(800) == 0)
						{
							num35 = 73;
							if (Main.rand.Next(6) == 0)
							{
								num34 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(6) == 0)
							{
								num34 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(6) == 0)
							{
								num34 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(6) == 0)
							{
								num34 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(6) == 0)
							{
								num34 += Main.rand.Next(1, 20);
							}
						}
						else if (Main.rand.Next(60) == 0)
						{
							num35 = 72;
							if (Main.rand.Next(4) == 0)
							{
								num34 += Main.rand.Next(5, 26);
							}
							if (Main.rand.Next(4) == 0)
							{
								num34 += Main.rand.Next(5, 26);
							}
							if (Main.rand.Next(4) == 0)
							{
								num34 += Main.rand.Next(5, 26);
							}
							if (Main.rand.Next(4) == 0)
							{
								num34 += Main.rand.Next(5, 25);
							}
						}
						else
						{
							num35 = 71;
							if (Main.rand.Next(3) == 0)
							{
								num34 += Main.rand.Next(10, 26);
							}
							if (Main.rand.Next(3) == 0)
							{
								num34 += Main.rand.Next(10, 26);
							}
							if (Main.rand.Next(3) == 0)
							{
								num34 += Main.rand.Next(10, 26);
							}
							if (Main.rand.Next(3) == 0)
							{
								num34 += Main.rand.Next(10, 25);
							}
						}
					}
					else if (Main.rand.Next(5000) == 0)
					{
						num35 = 1242;
					}
					else if (Main.rand.Next(25) == 0)
					{
						num35 = Main.rand.Next(6);
						if (num35 == 0)
						{
							num35 = 181;
						}
						else if (num35 == 1)
						{
							num35 = 180;
						}
						else if (num35 == 2)
						{
							num35 = 177;
						}
						else if (num35 == 3)
						{
							num35 = 179;
						}
						else if (num35 == 4)
						{
							num35 = 178;
						}
						else
						{
							num35 = 182;
						}
						if (Main.rand.Next(20) == 0)
						{
							num34 += Main.rand.Next(0, 2);
						}
						if (Main.rand.Next(30) == 0)
						{
							num34 += Main.rand.Next(0, 3);
						}
						if (Main.rand.Next(40) == 0)
						{
							num34 += Main.rand.Next(0, 4);
						}
						if (Main.rand.Next(50) == 0)
						{
							num34 += Main.rand.Next(0, 5);
						}
						if (Main.rand.Next(60) == 0)
						{
							num34 += Main.rand.Next(0, 6);
						}
					}
					else if (Main.rand.Next(50) == 0)
					{
						num35 = 999;
						if (Main.rand.Next(20) == 0)
						{
							num34 += Main.rand.Next(0, 2);
						}
						if (Main.rand.Next(30) == 0)
						{
							num34 += Main.rand.Next(0, 3);
						}
						if (Main.rand.Next(40) == 0)
						{
							num34 += Main.rand.Next(0, 4);
						}
						if (Main.rand.Next(50) == 0)
						{
							num34 += Main.rand.Next(0, 5);
						}
						if (Main.rand.Next(60) == 0)
						{
							num34 += Main.rand.Next(0, 6);
						}
					}
					else if (Main.rand.Next(3) == 0)
					{
						if (Main.rand.Next(5000) == 0)
						{
							num35 = 74;
							if (Main.rand.Next(10) == 0)
							{
								num34 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(10) == 0)
							{
								num34 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(10) == 0)
							{
								num34 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(10) == 0)
							{
								num34 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(10) == 0)
							{
								num34 += Main.rand.Next(0, 3);
							}
						}
						else if (Main.rand.Next(400) == 0)
						{
							num35 = 73;
							if (Main.rand.Next(5) == 0)
							{
								num34 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(5) == 0)
							{
								num34 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(5) == 0)
							{
								num34 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(5) == 0)
							{
								num34 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(5) == 0)
							{
								num34 += Main.rand.Next(1, 20);
							}
						}
						else if (Main.rand.Next(30) == 0)
						{
							num35 = 72;
							if (Main.rand.Next(3) == 0)
							{
								num34 += Main.rand.Next(5, 26);
							}
							if (Main.rand.Next(3) == 0)
							{
								num34 += Main.rand.Next(5, 26);
							}
							if (Main.rand.Next(3) == 0)
							{
								num34 += Main.rand.Next(5, 26);
							}
							if (Main.rand.Next(3) == 0)
							{
								num34 += Main.rand.Next(5, 25);
							}
						}
						else
						{
							num35 = 71;
							if (Main.rand.Next(2) == 0)
							{
								num34 += Main.rand.Next(10, 26);
							}
							if (Main.rand.Next(2) == 0)
							{
								num34 += Main.rand.Next(10, 26);
							}
							if (Main.rand.Next(2) == 0)
							{
								num34 += Main.rand.Next(10, 26);
							}
							if (Main.rand.Next(2) == 0)
							{
								num34 += Main.rand.Next(10, 25);
							}
						}
					}
					else
					{
						num35 = Main.rand.Next(8);
						if (num35 == 0)
						{
							num35 = 12;
						}
						else if (num35 == 1)
						{
							num35 = 11;
						}
						else if (num35 == 2)
						{
							num35 = 14;
						}
						else if (num35 == 3)
						{
							num35 = 13;
						}
						else if (num35 == 4)
						{
							num35 = 699;
						}
						else if (num35 == 5)
						{
							num35 = 700;
						}
						else if (num35 == 6)
						{
							num35 = 701;
						}
						else
						{
							num35 = 702;
						}
						if (Main.rand.Next(20) == 0)
						{
							num34 += Main.rand.Next(0, 2);
						}
						if (Main.rand.Next(30) == 0)
						{
							num34 += Main.rand.Next(0, 3);
						}
						if (Main.rand.Next(40) == 0)
						{
							num34 += Main.rand.Next(0, 4);
						}
						if (Main.rand.Next(50) == 0)
						{
							num34 += Main.rand.Next(0, 5);
						}
						if (Main.rand.Next(60) == 0)
						{
							num34 += Main.rand.Next(0, 6);
						}
					}
					if (num35 > 0)
					{
						int number = Item.NewItem((int)Main.screenPosition.X + Main.mouseX, (int)Main.screenPosition.Y + Main.mouseY, 1, 1, num35, num34, false, -1, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0);
						}
					}
				}
			}
			else if (this.inventory[this.selectedItem].createTile >= 0 && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
			{
				this.showItemIcon = true;
				bool flag = false;
				if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0 && Main.tile[Player.tileTargetX, Player.tileTargetY].lava())
				{
					if (Main.tileSolid[this.inventory[this.selectedItem].createTile])
					{
						flag = true;
					}
					else if (Main.tileLavaDeath[this.inventory[this.selectedItem].createTile])
					{
						flag = true;
					}
				}
				bool flag2 = true;
				if (this.inventory[this.selectedItem].tileWand > 0)
				{
					int tileWand = this.inventory[this.selectedItem].tileWand;
					flag2 = false;
					for (int m = 0; m < 58; m++)
					{
						if (tileWand == this.inventory[m].type && this.inventory[m].stack > 0)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (Main.tileRope[this.inventory[this.selectedItem].createTile] && flag2 && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tileRope[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
				{
					int num36 = Player.tileTargetY;
					int num37 = Player.tileTargetX;
					int createTile = this.inventory[this.selectedItem].createTile;
					while (Main.tile[num37, num36].active() && (int)Main.tile[num37, num36].type == createTile && num36 < Main.maxTilesX - 5)
					{
						num36++;
						if (Main.tile[num37, num36] == null)
						{
							flag2 = false;
							num36 = Player.tileTargetY;
						}
					}
					if (!Main.tile[num37, num36].active())
					{
						Player.tileTargetY = num36;
					}
				}
				if (flag2 && ((!Main.tile[Player.tileTargetX, Player.tileTargetY].active() && !flag) || Main.tileCut[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || this.inventory[this.selectedItem].createTile == 199 || this.inventory[this.selectedItem].createTile == 23 || this.inventory[this.selectedItem].createTile == 2 || this.inventory[this.selectedItem].createTile == 109 || this.inventory[this.selectedItem].createTile == 60 || this.inventory[this.selectedItem].createTile == 70) && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
				{
					bool flag3 = false;
					if (this.inventory[this.selectedItem].createTile == 23 || this.inventory[this.selectedItem].createTile == 2 || this.inventory[this.selectedItem].createTile == 109 || this.inventory[this.selectedItem].createTile == 199)
					{
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].nactive() && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0)
						{
							flag3 = true;
						}
					}
					else if (this.inventory[this.selectedItem].createTile == 227)
					{
						flag3 = true;
					}
					else if (this.inventory[this.selectedItem].createTile == 60 || this.inventory[this.selectedItem].createTile == 70)
					{
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].nactive() && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 59)
						{
							flag3 = true;
						}
					}
					else if (this.inventory[this.selectedItem].createTile == 4 || this.inventory[this.selectedItem].createTile == 136)
					{
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].wall > 0)
						{
							flag3 = true;
						}
						else
						{
							if (!WorldGen.SolidTileNoAttach(Player.tileTargetX, Player.tileTargetY + 1) && !WorldGen.SolidTileNoAttach(Player.tileTargetX - 1, Player.tileTargetY) && !WorldGen.SolidTileNoAttach(Player.tileTargetX + 1, Player.tileTargetY))
							{
								if (!WorldGen.SolidTileNoAttach(Player.tileTargetX, Player.tileTargetY + 1) && (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].halfBrick() || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].slope() != 0))
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type != 19)
									{
										WorldGen.SlopeTile(Player.tileTargetX, Player.tileTargetY + 1, 0);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 14, (float)Player.tileTargetX, (float)(Player.tileTargetY + 1), 0f, 0);
										}
									}
								}
								else if (!WorldGen.SolidTileNoAttach(Player.tileTargetX, Player.tileTargetY + 1) && !WorldGen.SolidTileNoAttach(Player.tileTargetX - 1, Player.tileTargetY) && (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].halfBrick() || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].slope() != 0))
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type != 19)
									{
										WorldGen.SlopeTile(Player.tileTargetX - 1, Player.tileTargetY, 0);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 14, (float)(Player.tileTargetX - 1), (float)Player.tileTargetY, 0f, 0);
										}
									}
								}
								else if (!WorldGen.SolidTileNoAttach(Player.tileTargetX, Player.tileTargetY + 1) && !WorldGen.SolidTileNoAttach(Player.tileTargetX - 1, Player.tileTargetY) && !WorldGen.SolidTileNoAttach(Player.tileTargetX + 1, Player.tileTargetY) && (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].halfBrick() || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].slope() != 0) && Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type != 19)
								{
									WorldGen.SlopeTile(Player.tileTargetX + 1, Player.tileTargetY, 0);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 14, (float)(Player.tileTargetX + 1), (float)Player.tileTargetY, 0f, 0);
									}
								}
							}
							int num38 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type;
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].halfBrick())
							{
								num38 = -1;
							}
							int num39 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type;
							int num40 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type;
							int num41 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
							int num42 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].type;
							int num43 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
							int num44 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].type;
							if (!Main.tile[Player.tileTargetX, Player.tileTargetY + 1].nactive())
							{
								num38 = -1;
							}
							if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY].nactive())
							{
								num39 = -1;
							}
							if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY].nactive())
							{
								num40 = -1;
							}
							if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].nactive())
							{
								num41 = -1;
							}
							if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].nactive())
							{
								num42 = -1;
							}
							if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY + 1].nactive())
							{
								num43 = -1;
							}
							if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].nactive())
							{
								num44 = -1;
							}
							if (num38 >= 0 && Main.tileSolid[num38] && !Main.tileNoAttach[num38])
							{
								flag3 = true;
							}
							else if ((num39 >= 0 && Main.tileSolid[num39] && !Main.tileNoAttach[num39]) || (num39 == 5 && num41 == 5 && num43 == 5) || num39 == 124)
							{
								flag3 = true;
							}
							else if ((num40 >= 0 && Main.tileSolid[num40] && !Main.tileNoAttach[num40]) || (num40 == 5 && num42 == 5 && num44 == 5) || num40 == 124)
							{
								flag3 = true;
							}
						}
					}
					else if (this.inventory[this.selectedItem].createTile == 78 || this.inventory[this.selectedItem].createTile == 98 || this.inventory[this.selectedItem].createTile == 100 || this.inventory[this.selectedItem].createTile == 173 || this.inventory[this.selectedItem].createTile == 174)
					{
						if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].nactive() && (Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type] || Main.tileTable[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type]))
						{
							flag3 = true;
						}
					}
					else if (this.inventory[this.selectedItem].createTile == 13 || this.inventory[this.selectedItem].createTile == 29 || this.inventory[this.selectedItem].createTile == 33 || this.inventory[this.selectedItem].createTile == 49 || this.inventory[this.selectedItem].createTile == 50 || this.inventory[this.selectedItem].createTile == 103)
					{
						if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].nactive() && Main.tileTable[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type])
						{
							flag3 = true;
						}
					}
					else if (this.inventory[this.selectedItem].createTile == 275 || this.inventory[this.selectedItem].createTile == 276 || this.inventory[this.selectedItem].createTile == 277)
					{
						flag3 = true;
					}
					else if (this.inventory[this.selectedItem].createTile == 51)
					{
						if (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active() || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active() || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active() || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active() || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0)
						{
							flag3 = true;
						}
					}
					else if ((Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active() && (Main.tileSolid[(int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type] || Main.tileRope[(int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type])) || (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0 || (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active() && (Main.tileSolid[(int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type] || Main.tileRope[(int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type]))) || (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0 || (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active() && (Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type] || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type == 124 || Main.tileRope[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type]))) || (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0 || (Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active() && (Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type] || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type == 124 || Main.tileRope[(int)Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type]))) || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0)
					{
						flag3 = true;
					}
					if (Main.tileAlch[this.inventory[this.selectedItem].createTile])
					{
						flag3 = true;
					}
					if (Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tileCut[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
					{
						if ((int)Main.tile[Player.tileTargetX, Player.tileTargetY].type != this.inventory[this.selectedItem].createTile)
						{
							if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type != 78)
							{
								WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
								if (!Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 4, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
								}
							}
							else
							{
								flag3 = false;
							}
						}
						else
						{
							flag3 = false;
						}
					}
					if (!flag3 && this.inventory[this.selectedItem].createTile == 19)
					{
						for (int n = Player.tileTargetX - 1; n <= Player.tileTargetX + 1; n++)
						{
							for (int num45 = Player.tileTargetY - 1; num45 <= Player.tileTargetY + 1; num45++)
							{
								if (Main.tile[n, num45].active())
								{
									flag3 = true;
									break;
								}
							}
						}
					}
					if (flag3)
					{
						int num46 = this.inventory[this.selectedItem].placeStyle;
						if (this.inventory[this.selectedItem].createTile == 36)
						{
							num46 = Main.rand.Next(7);
						}
						if (this.inventory[this.selectedItem].createTile == 212 && this.direction > 0)
						{
							num46 = 1;
						}
						if (this.inventory[this.selectedItem].createTile == 141)
						{
							num46 = Main.rand.Next(2);
						}
						if (this.inventory[this.selectedItem].createTile == 128 || this.inventory[this.selectedItem].createTile == 269)
						{
							if (this.direction < 0)
							{
								num46 = -1;
							}
							else
							{
								num46 = 1;
							}
						}
						if (this.inventory[this.selectedItem].createTile == 241 && this.inventory[this.selectedItem].placeStyle == 0)
						{
							num46 = Main.rand.Next(0, 9);
						}
						if (this.inventory[this.selectedItem].createTile == 35 && this.inventory[this.selectedItem].placeStyle == 0)
						{
							num46 = Main.rand.Next(9);
						}
						int[,] array = new int[11, 11];
						if (this.autoPaint)
						{
							for (int num47 = 0; num47 < 11; num47++)
							{
								for (int num48 = 0; num48 < 11; num48++)
								{
									int num49 = Player.tileTargetX - 5 + num47;
									int num50 = Player.tileTargetY - 5 + num48;
									if (Main.tile[num49, num50].active())
									{
										array[num47, num48] = (int)Main.tile[num49, num50].type;
									}
									else
									{
										array[num47, num48] = -1;
									}
								}
							}
						}
						if (WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createTile, false, false, this.whoAmi, num46))
						{
							this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.tileSpeed);
							if (Main.netMode == 1 && this.inventory[this.selectedItem].createTile != 21)
							{
								NetMessage.SendData(17, -1, -1, "", 1, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.inventory[this.selectedItem].createTile, num46);
							}
							if (this.inventory[this.selectedItem].createTile == 15)
							{
								if (this.direction == 1)
								{
									Tile expr_2FFA = Main.tile[Player.tileTargetX, Player.tileTargetY];
									expr_2FFA.frameX = (short)(expr_2FFA.frameX + 18);
									Tile expr_301F = Main.tile[Player.tileTargetX, Player.tileTargetY - 1];
									expr_301F.frameX = (short)(expr_301F.frameX + 18);
								}
								if (Main.netMode == 1)
								{
									NetMessage.SendTileSquare(-1, Player.tileTargetX - 1, Player.tileTargetY - 1, 3);
								}
							}
							else if (this.inventory[this.selectedItem].createTile == 137)
							{
								if (this.direction == 1)
								{
									Tile expr_3089 = Main.tile[Player.tileTargetX, Player.tileTargetY];
									expr_3089.frameX = (short)(expr_3089.frameX + 18);
								}
								if (Main.netMode == 1)
								{
									NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 1);
								}
							}
							else if ((this.inventory[this.selectedItem].createTile == 79 || this.inventory[this.selectedItem].createTile == 90) && Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 5);
							}
							if (Main.tileSolid[this.inventory[this.selectedItem].createTile] && this.inventory[this.selectedItem].createTile != 19)
							{
								int num51 = Player.tileTargetX;
								int num52 = Player.tileTargetY + 1;
								if (Main.tile[num51, num52] != null && Main.tile[num51, num52].type != 19 && (Main.tile[num51, num52].topSlope() || Main.tile[num51, num52].halfBrick()))
								{
									WorldGen.SlopeTile(num51, num52, 0);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 14, (float)num51, (float)num52, 0f, 0);
									}
								}
								num51 = Player.tileTargetX;
								num52 = Player.tileTargetY - 1;
								if (Main.tile[num51, num52] != null && Main.tile[num51, num52].type != 19 && Main.tile[num51, num52].bottomSlope())
								{
									WorldGen.SlopeTile(num51, num52, 0);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 14, (float)num51, (float)num52, 0f, 0);
									}
								}
							}
							if (this.autoPaint)
							{
								for (int num53 = 0; num53 < 11; num53++)
								{
									for (int num54 = 0; num54 < 11; num54++)
									{
										int num55 = Player.tileTargetX - 5 + num53;
										int num56 = Player.tileTargetY - 5 + num54;
										if ((Main.tile[num55, num56].active() || array[num53, num54] != -1) && (!Main.tile[num55, num56].active() || array[num53, num54] != (int)Main.tile[num55, num56].type))
										{
											int num57 = -1;
											int num58 = -1;
											for (int num59 = 0; num59 < 58; num59++)
											{
												if (this.inventory[num59].stack > 0 && this.inventory[num59].paint > 0)
												{
													num57 = (int)this.inventory[num59].paint;
													num58 = num59;
													break;
												}
											}
											if (num57 > 0 && (int)Main.tile[num55, num56].color() != num57 && WorldGen.paintTile(num55, num56, (byte)num57, true))
											{
												int num60 = num58;
												this.inventory[num60].stack--;
												if (this.inventory[num60].stack <= 0)
												{
													this.inventory[num60].SetDefaults(0, false);
												}
												this.itemTime = this.inventory[this.selectedItem].useTime;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			if (this.inventory[this.selectedItem].createWall >= 0 && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
			{
				this.showItemIcon = true;
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem && (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active() || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active() || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active() || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active() || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0) && (int)Main.tile[Player.tileTargetX, Player.tileTargetY].wall != this.inventory[this.selectedItem].createWall)
				{
					WorldGen.PlaceWall(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createWall, false);
					if ((int)Main.tile[Player.tileTargetX, Player.tileTargetY].wall == this.inventory[this.selectedItem].createWall)
					{
						this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.wallSpeed);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 3, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.inventory[this.selectedItem].createWall, 0);
						}
						if (this.inventory[this.selectedItem].stack > 1)
						{
							int createWall = this.inventory[this.selectedItem].createWall;
							for (int num61 = 0; num61 < 4; num61++)
							{
								int num62 = Player.tileTargetX;
								int num63 = Player.tileTargetY;
								if (num61 == 0)
								{
									num62--;
								}
								if (num61 == 1)
								{
									num62++;
								}
								if (num61 == 2)
								{
									num63--;
								}
								if (num61 == 3)
								{
									num63++;
								}
								if (Main.tile[num62, num63].wall == 0)
								{
									int num64 = 0;
									for (int num65 = 0; num65 < 4; num65++)
									{
										int num66 = num62;
										int num67 = num63;
										if (num65 == 0)
										{
											num66--;
										}
										if (num65 == 1)
										{
											num66++;
										}
										if (num65 == 2)
										{
											num67--;
										}
										if (num65 == 3)
										{
											num67++;
										}
										if ((int)Main.tile[num66, num67].wall == createWall)
										{
											num64++;
										}
									}
									if (num64 == 4)
									{
										WorldGen.PlaceWall(num62, num63, createWall, false);
										if ((int)Main.tile[num62, num63].wall == createWall)
										{
											this.inventory[this.selectedItem].stack--;
											if (this.inventory[this.selectedItem].stack == 0)
											{
												this.inventory[this.selectedItem].SetDefaults(0, false);
											}
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 3, (float)num62, (float)num63, (float)createWall, 0);
											}
											if (this.autoPaint)
											{
												int num68 = num62;
												int num69 = num63;
												int num70 = -1;
												int num71 = -1;
												for (int num72 = 0; num72 < 58; num72++)
												{
													if (this.inventory[num72].stack > 0 && this.inventory[num72].paint > 0)
													{
														num70 = (int)this.inventory[num72].paint;
														num71 = num72;
														break;
													}
												}
												if (num70 > 0 && (int)Main.tile[num68, num69].wallColor() != num70 && WorldGen.paintWall(num68, num69, (byte)num70, true))
												{
													int num73 = num71;
													this.inventory[num73].stack--;
													if (this.inventory[num73].stack <= 0)
													{
														this.inventory[num73].SetDefaults(0, false);
													}
													this.itemTime = this.inventory[this.selectedItem].useTime;
												}
											}
										}
									}
								}
							}
						}
						if (this.autoPaint)
						{
							int num74 = Player.tileTargetX;
							int num75 = Player.tileTargetY;
							int num76 = -1;
							int num77 = -1;
							for (int num78 = 0; num78 < 58; num78++)
							{
								if (this.inventory[num78].stack > 0 && this.inventory[num78].paint > 0)
								{
									num76 = (int)this.inventory[num78].paint;
									num77 = num78;
									break;
								}
							}
							if (num76 > 0 && (int)Main.tile[num74, num75].wallColor() != num76 && WorldGen.paintWall(num74, num75, (byte)num76, true))
							{
								int num79 = num77;
								this.inventory[num79].stack--;
								if (this.inventory[num79].stack <= 0)
								{
									this.inventory[num79].SetDefaults(0, false);
								}
								this.itemTime = this.inventory[this.selectedItem].useTime;
							}
						}
					}
				}
			}
		}
		public void ChangeDir(int dir)
		{
			if (!this.pulley || this.pulleyDir != 2)
			{
				this.direction = dir;
				return;
			}
			if (this.pulleyDir == 2 && dir == this.direction)
			{
				return;
			}
			int num = (int)(this.position.X + (float)(this.width / 2)) / 16;
			int num2 = num * 16 + 8 - this.width / 2;
			if (!Collision.SolidCollision(new Vector2((float)num2, this.position.Y), this.width, this.height))
			{
				if (this.whoAmi == Main.myPlayer)
				{
					Main.cameraX = Main.cameraX + this.position.X - (float)num2;
				}
				this.pulleyDir = 1;
				this.position.X = (float)num2;
				this.direction = dir;
			}
		}
		public Vector2 center()
		{
			return new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2));
		}
		public Rectangle getRect()
		{
			return new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
		}
		private void pumpkinSword(int i, int dmg, float kb)
		{
			int num = Main.rand.Next(100, 300);
			int num2 = Main.rand.Next(100, 300);
			if (Main.rand.Next(2) == 0)
			{
				num -= Main.maxScreenW / 2 + num;
			}
			else
			{
				num += Main.maxScreenW / 2 - num;
			}
			if (Main.rand.Next(2) == 0)
			{
				num2 -= Main.maxScreenH / 2 + num2;
			}
			else
			{
				num2 += Main.maxScreenH / 2 - num2;
			}
			num += (int)this.position.X;
			num2 += (int)this.position.Y;
			float num3 = 8f;
			Vector2 vector = new Vector2((float)num, (float)num2);
			float num4 = Main.npc[i].position.X - vector.X;
			float num5 = Main.npc[i].position.Y - vector.Y;
			float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
			num6 = num3 / num6;
			num4 *= num6;
			num5 *= num6;
			Projectile.NewProjectile((float)num, (float)num2, num4, num5, 321, dmg, kb, this.whoAmi, (float)i, 0f);
		}
		public void Dismount()
		{
			if (this.mount > 0)
			{
				for (int i = 0; i < 22; i++)
				{
					if (this.buffType[i] == 90)
					{
						this.DelBuff(i);
					}
				}
				if (this.mount == 1)
				{
					for (int j = 0; j < 100; j++)
					{
						int num = Dust.NewDust(new Vector2(this.position.X - 20f, this.position.Y), this.width + 40, this.height, 57, 0f, 0f, 255, default(Color), 1f);
						Main.dust[num].scale += (float)Main.rand.Next(-10, 21) * 0.01f;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num].scale *= 1.3f;
							Main.dust[num].noGravity = true;
						}
						else
						{
							Main.dust[num].velocity *= 0.5f;
						}
						Main.dust[num].velocity += this.velocity * 0.8f;
					}
				}
				this.mount = 0;
				this.position.Y = this.position.Y + (float)this.height;
				this.height = 42;
				this.position.Y = this.position.Y - (float)this.height;
				if (this.whoAmi == Main.myPlayer)
				{
					NetMessage.SendData(13, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
				}
			}
		}
		public void Mount(int m)
		{
			this.mountFlyTime = 0;
			if (this.mount == m)
			{
				return;
			}
			this.mount = m;
			if (this.mount == 1)
			{
				this.position.Y = this.position.Y + (float)this.height;
				this.height = 62;
				this.position.Y = this.position.Y - (float)this.height;
				for (int i = 0; i < 100; i++)
				{
					int num = Dust.NewDust(new Vector2(this.position.X - 20f, this.position.Y), this.width + 40, this.height, 57, 0f, 0f, 255, default(Color), 1f);
					Main.dust[num].scale += (float)Main.rand.Next(-10, 21) * 0.01f;
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num].scale *= 1.3f;
						Main.dust[num].noGravity = true;
					}
					else
					{
						Main.dust[num].velocity *= 0.5f;
					}
					Main.dust[num].velocity += this.velocity * 0.8f;
				}
				if (this.whoAmi == Main.myPlayer)
				{
					NetMessage.SendData(13, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
				}
			}
		}
		public void PutItemInInventory(int type, int selItem = -1)
		{
			if (selItem >= 0 && (this.inventory[selItem].type == 0 || this.inventory[selItem].stack <= 0))
			{
				this.inventory[selItem].SetDefaults(type, false);
				return;
			}
			Item item = new Item();
			item.SetDefaults(type, false);
			Item item2 = this.GetItem(this.whoAmi, item);
			if (item2.stack > 0)
			{
				int number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type, 1, false, 0, true);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0);
					return;
				}
			}
			else
			{
				item.position.X = this.center().X - (float)(item.width / 2);
				item.position.Y = this.center().Y - (float)(item.height / 2);
				item.active = true;
			}
		}
		public bool SummonItemCheck()
		{
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && ((this.inventory[this.selectedItem].type == 43 && Main.npc[i].type == 4) || (this.inventory[this.selectedItem].type == 70 && Main.npc[i].type == 13) || ((this.inventory[this.selectedItem].type == 560 & Main.npc[i].type == 50) || (this.inventory[this.selectedItem].type == 544 && Main.npc[i].type == 125)) || (this.inventory[this.selectedItem].type == 544 && Main.npc[i].type == 126) || (this.inventory[this.selectedItem].type == 556 && Main.npc[i].type == 134) || (this.inventory[this.selectedItem].type == 557 && Main.npc[i].type == 127) || (this.inventory[this.selectedItem].type == 1133 && Main.npc[i].type == 222) || (this.inventory[this.selectedItem].type == 1331 && Main.npc[i].type == 266)))
				{
					return false;
				}
			}
			return true;
		}
		public void ItemCheck(int i)
		{
			if (this.frozen)
			{
				return;
			}
			bool flag = false;
			float num = 5E-06f;
			int num2 = this.inventory[this.selectedItem].damage;
			if (num2 > 0)
			{
				if (this.inventory[this.selectedItem].melee)
				{
					num2 = (int)((float)num2 * this.meleeDamage + num);
				}
				else if (this.inventory[this.selectedItem].ranged)
				{
					num2 = (int)((float)num2 * this.rangedDamage + num);
					if (this.inventory[this.selectedItem].useAmmo == 1 || this.inventory[this.selectedItem].useAmmo == 323)
					{
						num2 = (int)((float)num2 * this.arrowDamage + num);
					}
					if (this.inventory[this.selectedItem].useAmmo == 14 || this.inventory[this.selectedItem].useAmmo == 311)
					{
						num2 = (int)((float)num2 * this.bulletDamage + num);
					}
					if (this.inventory[this.selectedItem].useAmmo == 771 || this.inventory[this.selectedItem].useAmmo == 246 || this.inventory[this.selectedItem].useAmmo == 312)
					{
						num2 = (int)((float)num2 * this.rocketDamage + num);
					}
				}
				else if (this.inventory[this.selectedItem].magic)
				{
					num2 = (int)((float)num2 * this.magicDamage + num);
				}
			}
			if (this.inventory[this.selectedItem].autoReuse && !this.noItems)
			{
				this.releaseUseItem = true;
				if (this.itemAnimation == 1 && this.inventory[this.selectedItem].stack > 0)
				{
					if (this.inventory[this.selectedItem].shoot > 0 && this.whoAmi != Main.myPlayer && this.controlUseItem)
					{
						this.itemAnimation = 2;
					}
					else
					{
						this.itemAnimation = 0;
					}
				}
			}
			if (this.whoAmi == Main.myPlayer && this.mount > 0)
			{
				if (this.inventory[this.selectedItem].buffType != 90 && this.itemAnimation > 0)
				{
					this.Dismount();
				}
				if (this.gravDir == -1f)
				{
					this.Dismount();
				}
			}
			if (this.itemAnimation == 0 && this.reuseDelay > 0)
			{
				this.itemAnimation = this.reuseDelay;
				this.itemTime = this.reuseDelay;
				this.reuseDelay = 0;
			}
			if (this.controlUseItem && this.releaseUseItem && (this.inventory[this.selectedItem].headSlot > 0 || this.inventory[this.selectedItem].bodySlot > 0 || this.inventory[this.selectedItem].legSlot > 0))
			{
				if (this.inventory[this.selectedItem].useStyle == 0)
				{
					this.releaseUseItem = false;
				}
				if (this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
				{
					int num3 = Player.tileTargetX;
					int num4 = Player.tileTargetY;
					if (Main.tile[num3, num4].active() && (Main.tile[num3, num4].type == 128 || Main.tile[num3, num4].type == 269))
					{
						int num5 = (int)Main.tile[num3, num4].frameY;
						int j = 0;
						if (this.inventory[this.selectedItem].bodySlot >= 0)
						{
							j = 1;
						}
						if (this.inventory[this.selectedItem].legSlot >= 0)
						{
							j = 2;
						}
						num5 /= 18;
						while (j > num5)
						{
							num4++;
							num5 = (int)Main.tile[num3, num4].frameY;
							num5 /= 18;
						}
						while (j < num5)
						{
							num4--;
							num5 = (int)Main.tile[num3, num4].frameY;
							num5 /= 18;
						}
						int k;
						for (k = (int)Main.tile[num3, num4].frameX; k >= 100; k -= 100)
						{
						}
						if (k >= 36)
						{
							k -= 36;
						}
						num3 -= k / 18;
						int l = (int)Main.tile[num3, num4].frameX;
						WorldGen.KillTile(num3, num4, true, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 0, (float)num3, (float)num4, 1f, 0);
						}
						while (l >= 100)
						{
							l -= 100;
						}
						if (num5 == 0 && this.inventory[this.selectedItem].headSlot >= 0)
						{
							Main.tile[num3, num4].frameX = (short)(l + this.inventory[this.selectedItem].headSlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num3, num4, 1);
							}
							this.inventory[this.selectedItem].SetDefaults(0, false);
							Main.mouseItem.SetDefaults(0, false);
							this.releaseUseItem = false;
							this.mouseInterface = true;
							this.itemAnimation = 30;
							this.itemAnimationMax = 30;
						}
						else if (num5 == 1 && this.inventory[this.selectedItem].bodySlot >= 0)
						{
							Main.tile[num3, num4].frameX = (short)(l + this.inventory[this.selectedItem].bodySlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num3, num4, 1);
							}
							this.inventory[this.selectedItem].SetDefaults(0, false);
							Main.mouseItem.SetDefaults(0, false);
							this.releaseUseItem = false;
							this.mouseInterface = true;
							this.itemAnimation = 30;
							this.itemAnimationMax = 30;
						}
						else if (num5 == 2 && this.inventory[this.selectedItem].legSlot >= 0)
						{
							Main.tile[num3, num4].frameX = (short)(l + this.inventory[this.selectedItem].legSlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num3, num4, 1);
							}
							this.inventory[this.selectedItem].SetDefaults(0, false);
							Main.mouseItem.SetDefaults(0, false);
							this.releaseUseItem = false;
							this.mouseInterface = true;
							this.itemAnimation = 30;
							this.itemAnimationMax = 30;
						}
					}
				}
			}
			if (this.controlUseItem && this.itemAnimation == 0 && this.releaseUseItem && this.inventory[this.selectedItem].useStyle > 0)
			{
				bool flag2 = true;
				if (this.inventory[this.selectedItem].shoot == 0)
				{
					this.itemRotation = 0f;
				}
				if (this.wet && (this.inventory[this.selectedItem].shoot == 85 || this.inventory[this.selectedItem].shoot == 15 || this.inventory[this.selectedItem].shoot == 34))
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].makeNPC > 0 && !NPC.CanReleaseNPCs(this.whoAmi))
				{
					flag2 = false;
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 603 && !Main.cEd)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].type == 1071 || this.inventory[this.selectedItem].type == 1072)
				{
					bool flag3 = false;
					for (int m = 0; m < 58; m++)
					{
						if (this.inventory[m].paint > 0)
						{
							flag3 = true;
							break;
						}
					}
					if (!flag3)
					{
						flag2 = false;
					}
				}
				if (this.noItems)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].tileWand > 0)
				{
					int tileWand = this.inventory[this.selectedItem].tileWand;
					flag2 = false;
					for (int n = 0; n < 58; n++)
					{
						if (tileWand == this.inventory[n].type && this.inventory[n].stack > 0)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (this.inventory[this.selectedItem].shoot == 6 || this.inventory[this.selectedItem].shoot == 19 || this.inventory[this.selectedItem].shoot == 33 || this.inventory[this.selectedItem].shoot == 52 || this.inventory[this.selectedItem].shoot == 113 || this.inventory[this.selectedItem].shoot == 182 || this.inventory[this.selectedItem].shoot == 320 || this.inventory[this.selectedItem].shoot == 333)
				{
					for (int num6 = 0; num6 < 1000; num6++)
					{
						if (Main.projectile[num6].active && Main.projectile[num6].owner == Main.myPlayer && Main.projectile[num6].type == this.inventory[this.selectedItem].shoot)
						{
							flag2 = false;
						}
					}
				}
				if (this.inventory[this.selectedItem].shoot == 106)
				{
					int num7 = 0;
					for (int num8 = 0; num8 < 1000; num8++)
					{
						if (Main.projectile[num8].active && Main.projectile[num8].owner == Main.myPlayer && Main.projectile[num8].type == this.inventory[this.selectedItem].shoot)
						{
							num7++;
						}
					}
					if (num7 >= this.inventory[this.selectedItem].stack)
					{
						flag2 = false;
					}
				}
				if (this.inventory[this.selectedItem].shoot == 272)
				{
					int num9 = 0;
					for (int num10 = 0; num10 < 1000; num10++)
					{
						if (Main.projectile[num10].active && Main.projectile[num10].owner == Main.myPlayer && Main.projectile[num10].type == this.inventory[this.selectedItem].shoot)
						{
							num9++;
						}
					}
					if (num9 >= this.inventory[this.selectedItem].stack)
					{
						flag2 = false;
					}
				}
				if (this.inventory[this.selectedItem].shoot == 13 || this.inventory[this.selectedItem].shoot == 32 || (this.inventory[this.selectedItem].shoot >= 230 && this.inventory[this.selectedItem].shoot <= 235) || this.inventory[this.selectedItem].shoot == 315 || this.inventory[this.selectedItem].shoot == 331)
				{
					for (int num11 = 0; num11 < 1000; num11++)
					{
						if (Main.projectile[num11].active && Main.projectile[num11].owner == Main.myPlayer && Main.projectile[num11].type == this.inventory[this.selectedItem].shoot && Main.projectile[num11].ai[0] != 2f)
						{
							flag2 = false;
						}
					}
				}
				if (this.inventory[this.selectedItem].shoot == 332)
				{
					int num12 = 0;
					for (int num13 = 0; num13 < 1000; num13++)
					{
						if (Main.projectile[num13].active && Main.projectile[num13].owner == Main.myPlayer && Main.projectile[num13].type == this.inventory[this.selectedItem].shoot && Main.projectile[num13].ai[0] != 2f)
						{
							num12++;
						}
					}
					if (num12 >= 3)
					{
						flag2 = false;
					}
				}
				if (this.inventory[this.selectedItem].potion && flag2)
				{
					if (this.potionDelay <= 0)
					{
						this.potionDelay = this.potionDelayTime;
						this.AddBuff(21, this.potionDelay, true);
					}
					else
					{
						flag2 = false;
					}
				}
				if (this.inventory[this.selectedItem].mana > 0 && this.silence)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].mana > 0 && flag2)
				{
					if (this.inventory[this.selectedItem].type != 127 || !this.spaceGun)
					{
						if (this.statMana >= (int)((float)this.inventory[this.selectedItem].mana * this.manaCost))
						{
							this.statMana -= (int)((float)this.inventory[this.selectedItem].mana * this.manaCost);
						}
						else if (this.manaFlower)
						{
							this.QuickMana();
							if (this.statMana >= (int)((float)this.inventory[this.selectedItem].mana * this.manaCost))
							{
								this.statMana -= (int)((float)this.inventory[this.selectedItem].mana * this.manaCost);
							}
							else
							{
								flag2 = false;
							}
						}
						else
						{
							flag2 = false;
						}
					}
					if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].buffType != 0 && flag2)
					{
						this.AddBuff(this.inventory[this.selectedItem].buffType, this.inventory[this.selectedItem].buffTime, true);
					}
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 603 && Main.cEd)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 669)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 115)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 425)
				{
					int num14 = Main.rand.Next(3);
					if (num14 == 0)
					{
						num14 = 27;
					}
					if (num14 == 1)
					{
						num14 = 101;
					}
					if (num14 == 2)
					{
						num14 = 102;
					}
					for (int num15 = 0; num15 < 22; num15++)
					{
						if (this.buffType[num15] == 27 || this.buffType[num15] == 101 || this.buffType[num15] == 102)
						{
							this.DelBuff(num15);
							num15--;
						}
					}
					this.AddBuff(num14, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 753)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 994)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1169)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1170)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1171)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1172)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1180)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1181)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1182)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1183)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1242)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1157)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1309)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1311)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1837)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1312)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1798)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1799)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1802)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1810)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1927)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1959)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
				}
				if (this.whoAmi == Main.myPlayer && this.gravDir == 1f && this.inventory[this.selectedItem].type == 1914)
				{
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
					this.Mount(1);
				}
				if (this.inventory[this.selectedItem].type == 43 && Main.dayTime)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].type == 544 && Main.dayTime)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].type == 556 && Main.dayTime)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].type == 557 && Main.dayTime)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].type == 70 && !this.zoneEvil)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].type == 1133 && !this.zoneJungle)
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].type == 1844 && (Main.dayTime || Main.pumpkinMoon || Main.snowMoon))
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].type == 1958 && (Main.dayTime || Main.pumpkinMoon || Main.snowMoon))
				{
					flag2 = false;
				}
				if (!this.SummonItemCheck())
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].shoot == 17 && flag2 && i == Main.myPlayer)
				{
					int num16 = (int)((float)Main.mouseX + Main.screenPosition.X) / 16;
					int num17 = (int)((float)Main.mouseY + Main.screenPosition.Y) / 16;
					Tile tile = Main.tile[num16, num17];
					if (tile.active() && (tile.type == 0 || tile.type == 2 || tile.type == 23 || tile.type == 109 || tile.type == 199))
					{
						WorldGen.KillTile(num16, num17, false, false, true);
						if (!Main.tile[num16, num17].active())
						{
							if (Main.netMode == 1)
							{
								NetMessage.SendData(17, -1, -1, "", 4, (float)num16, (float)num17, 0f, 0);
							}
						}
						else
						{
							flag2 = false;
						}
					}
					else
					{
						flag2 = false;
					}
				}
				if (flag2 && this.inventory[this.selectedItem].useAmmo > 0)
				{
					flag2 = false;
					for (int num18 = 0; num18 < 58; num18++)
					{
						if (this.inventory[num18].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[num18].stack > 0)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (flag2)
				{
					if (this.inventory[this.selectedItem].pick > 0 || this.inventory[this.selectedItem].axe > 0 || this.inventory[this.selectedItem].hammer > 0)
					{
						this.toolTime = 1;
					}
					if (this.grappling[0] > -1)
					{
						this.pulley = false;
						this.pulleyDir = 1;
						if (this.controlRight)
						{
							this.direction = 1;
						}
						else if (this.controlLeft)
						{
							this.direction = -1;
						}
					}
					this.channel = this.inventory[this.selectedItem].channel;
					this.attackCD = 0;
					if (this.inventory[this.selectedItem].melee)
					{
						this.itemAnimation = (int)((float)this.inventory[this.selectedItem].useAnimation * this.meleeSpeed);
						this.itemAnimationMax = (int)((float)this.inventory[this.selectedItem].useAnimation * this.meleeSpeed);
					}
					else if (this.inventory[this.selectedItem].createTile >= 0)
					{
						this.itemAnimation = (int)((float)this.inventory[this.selectedItem].useAnimation * this.tileSpeed);
						this.itemAnimationMax = (int)((float)this.inventory[this.selectedItem].useAnimation * this.tileSpeed);
					}
					else if (this.inventory[this.selectedItem].createWall >= 0)
					{
						this.itemAnimation = (int)((float)this.inventory[this.selectedItem].useAnimation * this.wallSpeed);
						this.itemAnimationMax = (int)((float)this.inventory[this.selectedItem].useAnimation * this.wallSpeed);
					}
					else
					{
						this.itemAnimation = this.inventory[this.selectedItem].useAnimation;
						this.itemAnimationMax = this.inventory[this.selectedItem].useAnimation;
						this.reuseDelay = this.inventory[this.selectedItem].reuseDelay;
					}
					if (this.inventory[this.selectedItem].useSound > 0)
					{
						Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, this.inventory[this.selectedItem].useSound);
					}
				}
				if (flag2 && (this.inventory[this.selectedItem].shoot == 18 || this.inventory[this.selectedItem].shoot == 72 || this.inventory[this.selectedItem].shoot == 86 || this.inventory[this.selectedItem].shoot == 86 || Main.projPet[this.inventory[this.selectedItem].shoot]))
				{
					if ((this.inventory[this.selectedItem].shoot >= 191 && this.inventory[this.selectedItem].shoot <= 194) || this.inventory[this.selectedItem].shoot == 266 || this.inventory[this.selectedItem].shoot == 317)
					{
						int num19 = 0;
						int num20 = -1;
						int num21 = -1;
						for (int num22 = 0; num22 < 1000; num22++)
						{
							if (Main.projectile[num22].active && Main.projectile[num22].owner == i && Main.projectile[num22].minion)
							{
								num19++;
								if (num20 == -1 || Main.projectile[num22].timeLeft < num20)
								{
									num21 = num22;
									num20 = Main.projectile[num22].timeLeft;
								}
							}
						}
						if (num19 >= this.maxMinions)
						{
							Main.projectile[num21].Kill();
						}
					}
					else
					{
						for (int num23 = 0; num23 < 1000; num23++)
						{
							if (Main.projectile[num23].active && Main.projectile[num23].owner == i && Main.projectile[num23].type == this.inventory[this.selectedItem].shoot)
							{
								Main.projectile[num23].Kill();
							}
							if (this.inventory[this.selectedItem].shoot == 72)
							{
								if (Main.projectile[num23].active && Main.projectile[num23].owner == i && Main.projectile[num23].type == 86)
								{
									Main.projectile[num23].Kill();
								}
								if (Main.projectile[num23].active && Main.projectile[num23].owner == i && Main.projectile[num23].type == 87)
								{
									Main.projectile[num23].Kill();
								}
							}
						}
					}
				}
			}
			if (!this.controlUseItem)
			{
				bool arg_1D6A_0 = this.channel;
				this.channel = false;
			}
			if (this.itemAnimation > 0)
			{
				if (this.inventory[this.selectedItem].melee)
				{
					this.itemAnimationMax = (int)((float)this.inventory[this.selectedItem].useAnimation * this.meleeSpeed);
				}
				else
				{
					this.itemAnimationMax = this.inventory[this.selectedItem].useAnimation;
				}
				if (this.inventory[this.selectedItem].mana > 0 && !flag && (this.inventory[this.selectedItem].type != 127 || !this.spaceGun))
				{
					this.manaRegenDelay = (int)this.maxRegenDelay;
				}
				this.itemHeight = this.inventory[this.selectedItem].height;
				this.itemWidth = this.inventory[this.selectedItem].width;
				this.itemAnimation--;
			}
			else if (this.inventory[this.selectedItem].holdStyle == 1 && !this.pulley && this.mount == 0)
			{
				this.itemLocation.X = this.position.X + (float)this.width * 0.5f + 20f * (float)this.direction;
				this.itemLocation.Y = this.position.Y + 24f;
				if (this.inventory[this.selectedItem].type == 856)
				{
					this.itemLocation.Y = this.position.Y + 34f;
				}
				if (this.inventory[this.selectedItem].type == 930)
				{
					this.itemLocation.Y = this.position.Y + 9f;
				}
				this.itemRotation = 0f;
				if (this.gravDir == -1f)
				{
					this.itemRotation = -this.itemRotation;
					this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
					if (this.inventory[this.selectedItem].type == 930)
					{
						this.itemLocation.Y = this.itemLocation.Y - 24f;
					}
				}
			}
			else if (this.inventory[this.selectedItem].holdStyle == 2 && !this.pulley && this.mount == 0)
			{
				if (this.inventory[this.selectedItem].type == 946)
				{
					this.itemRotation = 0f;
					this.itemLocation.X = this.position.X + (float)this.width * 0.5f - (float)(16 * this.direction);
					this.itemLocation.Y = this.position.Y + 22f;
					this.fallStart = (int)(this.position.Y / 16f);
					if (this.gravDir == -1f)
					{
						this.itemRotation = -this.itemRotation;
						this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
						if (this.velocity.Y < -2f)
						{
							this.velocity.Y = -2f;
						}
					}
					else if (this.velocity.Y > 2f)
					{
						this.velocity.Y = 2f;
					}
				}
				else
				{
					this.itemLocation.X = this.position.X + (float)this.width * 0.5f + (float)(6 * this.direction);
					this.itemLocation.Y = this.position.Y + 16f;
					this.itemRotation = 0.79f * (float)(-(float)this.direction);
					if (this.gravDir == -1f)
					{
						this.itemRotation = -this.itemRotation;
						this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
					}
				}
			}
			if ((((this.inventory[this.selectedItem].type == 974 || this.inventory[this.selectedItem].type == 8 || this.inventory[this.selectedItem].type == 1245 || (this.inventory[this.selectedItem].type >= 427 && this.inventory[this.selectedItem].type <= 433)) && !this.wet) || this.inventory[this.selectedItem].type == 523 || this.inventory[this.selectedItem].type == 1333 || this.inventory[this.selectedItem].type == 2274) && !this.pulley && this.mount == 0)
			{
				float num40 = 1f;
				float num41 = 0.95f;
				float num42 = 0.8f;
				int num43 = 0;
				if (this.inventory[this.selectedItem].type == 523)
				{
					num43 = 8;
				}
				else if (this.inventory[this.selectedItem].type == 974)
				{
					num43 = 9;
				}
				else if (this.inventory[this.selectedItem].type == 1245)
				{
					num43 = 10;
				}
				else if (this.inventory[this.selectedItem].type == 1333)
				{
					num43 = 11;
				}
				else if (this.inventory[this.selectedItem].type == 2274)
				{
					num43 = 12;
				}
				else if (this.inventory[this.selectedItem].type >= 427)
				{
					num43 = this.inventory[this.selectedItem].type - 426;
				}
				if (num43 == 1)
				{
					num40 = 0f;
					num41 = 0.1f;
					num42 = 1.3f;
				}
				else if (num43 == 2)
				{
					num40 = 1f;
					num41 = 0.1f;
					num42 = 0.1f;
				}
				else if (num43 == 3)
				{
					num40 = 0f;
					num41 = 1f;
					num42 = 0.1f;
				}
				else if (num43 == 4)
				{
					num40 = 0.9f;
					num41 = 0f;
					num42 = 0.9f;
				}
				else if (num43 == 5)
				{
					num40 = 1.3f;
					num41 = 1.3f;
					num42 = 1.3f;
				}
				else if (num43 == 6)
				{
					num40 = 0.9f;
					num41 = 0.9f;
					num42 = 0f;
				}
				else if (num43 == 7)
				{
					num40 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
					num41 = 0.3f;
					num42 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
				}
				else if (num43 == 8)
				{
					num42 = 0.7f;
					num40 = 0.85f;
					num41 = 1f;
				}
				else if (num43 == 9)
				{
					num42 = 1f;
					num40 = 0.7f;
					num41 = 0.85f;
				}
				else if (num43 == 10)
				{
					num42 = 0f;
					num40 = 1f;
					num41 = 0.5f;
				}
				else if (num43 == 11)
				{
					num42 = 0.8f;
					num40 = 1.25f;
					num41 = 1.25f;
				}
				else if (num43 == 12)
				{
					num40 *= 0.75f;
					num41 *= 1.3499999f;
					num42 *= 1.5f;
				}
				int num44 = num43;
				if (num44 == 0)
				{
					num44 = 6;
				}
				else if (num44 == 8)
				{
					num44 = 75;
				}
				else if (num44 == 9)
				{
					num44 = 135;
				}
				else if (num44 == 10)
				{
					num44 = 158;
				}
				else if (num44 == 11)
				{
					num44 = 169;
				}
				else if (num44 == 12)
				{
					num44 = 156;
				}
				else
				{
					num44 = 58 + num44;
				}
				int maxValue = 30;
				if (this.itemAnimation > 0)
				{
					maxValue = 7;
				}
			}
			if (this.controlUseItem)
			{
				this.releaseUseItem = false;
			}
			else
			{
				this.releaseUseItem = true;
			}
			if (this.itemTime > 0)
			{
				this.itemTime--;
				if (this.itemTime == 0 && this.whoAmi == Main.myPlayer)
				{
					int type = this.inventory[this.selectedItem].type;
					if (type == 65 || type == 676 || type == 723 || type == 724 || type == 989 || type == 1226 || type == 1227)
					{
						Main.PlaySound(25, -1, -1, 1);
						for (int num51 = 0; num51 < 5; num51++)
						{
							int num52 = Dust.NewDust(this.position, this.width, this.height, 45, 0f, 0f, 255, default(Color), (float)Main.rand.Next(20, 26) * 0.1f);
							Main.dust[num52].noLight = true;
							Main.dust[num52].noGravity = true;
							Main.dust[num52].velocity *= 0.5f;
						}
					}
				}
			}
			if (((this.inventory[this.selectedItem].damage >= 0 && this.inventory[this.selectedItem].type > 0 && !this.inventory[this.selectedItem].noMelee) || this.inventory[this.selectedItem].type == 1450 || this.inventory[this.selectedItem].type == 1991) && this.itemAnimation > 0)
			{
				bool flag11 = false;
				Rectangle rectangle = new Rectangle((int)this.itemLocation.X, (int)this.itemLocation.Y, 32, 32);
				rectangle.Width = (int)((float)rectangle.Width * this.inventory[this.selectedItem].scale);
				rectangle.Height = (int)((float)rectangle.Height * this.inventory[this.selectedItem].scale);
				if (this.direction == -1)
				{
					rectangle.X -= rectangle.Width;
				}
				if (this.gravDir == 1f)
				{
					rectangle.Y -= rectangle.Height;
				}
				if (this.inventory[this.selectedItem].useStyle == 1)
				{
					if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
					{
						if (this.direction == -1)
						{
							rectangle.X -= (int)((double)rectangle.Width * 1.4 - (double)rectangle.Width);
						}
						rectangle.Width = (int)((double)rectangle.Width * 1.4);
						rectangle.Y += (int)((double)rectangle.Height * 0.5 * (double)this.gravDir);
						rectangle.Height = (int)((double)rectangle.Height * 1.1);
					}
					else if ((double)this.itemAnimation >= (double)this.itemAnimationMax * 0.666)
					{
						if (this.direction == 1)
						{
							rectangle.X -= (int)((double)rectangle.Width * 1.2);
						}
						rectangle.Width *= 2;
						rectangle.Y -= (int)(((double)rectangle.Height * 1.4 - (double)rectangle.Height) * (double)this.gravDir);
						rectangle.Height = (int)((double)rectangle.Height * 1.4);
					}
				}
				else if (this.inventory[this.selectedItem].useStyle == 3)
				{
					if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.666)
					{
						flag11 = true;
					}
					else
					{
						if (this.direction == -1)
						{
							rectangle.X -= (int)((double)rectangle.Width * 1.4 - (double)rectangle.Width);
						}
						rectangle.Width = (int)((double)rectangle.Width * 1.4);
						rectangle.Y += (int)((double)rectangle.Height * 0.6);
						rectangle.Height = (int)((double)rectangle.Height * 0.6);
					}
				}
				float arg_9D16_0 = this.gravDir;
				if (this.inventory[this.selectedItem].type == 1450 && Main.rand.Next(3) == 0)
				{
					int num173 = -1;
					float x5 = (float)(rectangle.X + Main.rand.Next(rectangle.Width));
					float y5 = (float)(rectangle.Y + Main.rand.Next(rectangle.Height));
					if (Main.rand.Next(500) == 0)
					{
						num173 = Gore.NewGore(new Vector2(x5, y5), default(Vector2), 415, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else if (Main.rand.Next(250) == 0)
					{
						num173 = Gore.NewGore(new Vector2(x5, y5), default(Vector2), 414, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else if (Main.rand.Next(80) == 0)
					{
						num173 = Gore.NewGore(new Vector2(x5, y5), default(Vector2), 413, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else if (Main.rand.Next(10) == 0)
					{
						num173 = Gore.NewGore(new Vector2(x5, y5), default(Vector2), 412, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else if (Main.rand.Next(3) == 0)
					{
						num173 = Gore.NewGore(new Vector2(x5, y5), default(Vector2), 411, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					if (num173 >= 0)
					{
						Gore expr_9F04_cp_0 = Main.gore[num173];
						expr_9F04_cp_0.velocity.X = expr_9F04_cp_0.velocity.X + (float)(this.direction * 2);
						Gore expr_9F26_cp_0 = Main.gore[num173];
						expr_9F26_cp_0.velocity.Y = expr_9F26_cp_0.velocity.Y * 0.3f;
					}
				}
			}
			if (this.itemTime == 0 && this.itemAnimation > 0)
			{
				if (this.inventory[this.selectedItem].hairDye >= 0)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					if (this.whoAmi == Main.myPlayer)
					{
						this.hairDye = (byte)this.inventory[this.selectedItem].hairDye;
						NetMessage.SendData(4, -1, -1, Main.player[this.whoAmi].name, this.whoAmi, 0f, 0f, 0f, 0);
					}
				}
				if (this.inventory[this.selectedItem].healLife > 0)
				{
					this.statLife += this.inventory[this.selectedItem].healLife;
					this.itemTime = this.inventory[this.selectedItem].useTime;
				}
				if (this.inventory[this.selectedItem].healMana > 0)
				{
					this.statMana += this.inventory[this.selectedItem].healMana;
					this.itemTime = this.inventory[this.selectedItem].useTime;
					if (Main.myPlayer == this.whoAmi)
					{
						this.AddBuff(94, Player.manaSickTime, true);
					}
				}
				if (this.inventory[this.selectedItem].buffType > 0)
				{
					if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].buffType != 90)
					{
						this.AddBuff(this.inventory[this.selectedItem].buffType, this.inventory[this.selectedItem].buffTime, true);
					}
					this.itemTime = this.inventory[this.selectedItem].useTime;
				}
				if (this.inventory[this.selectedItem].type == 678)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					if (this.whoAmi == Main.myPlayer)
					{
						this.AddBuff(20, 216000, true);
						this.AddBuff(22, 216000, true);
						this.AddBuff(23, 216000, true);
						this.AddBuff(24, 216000, true);
						this.AddBuff(30, 216000, true);
						this.AddBuff(31, 216000, true);
						this.AddBuff(32, 216000, true);
						this.AddBuff(33, 216000, true);
						this.AddBuff(35, 216000, true);
						this.AddBuff(36, 216000, true);
						this.AddBuff(68, 216000, true);
					}
				}
			}
			if (this.whoAmi == Main.myPlayer)
			{
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 361)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
					if (Main.netMode != 1)
					{
						if (Main.invasionType == 0)
						{
							Main.invasionDelay = 0;
							Main.StartInvasion(1);
						}
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", this.whoAmi, -1f, 0f, 0f, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 602)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
					if (Main.netMode != 1)
					{
						if (Main.invasionType == 0)
						{
							Main.invasionDelay = 0;
							Main.StartInvasion(2);
						}
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", this.whoAmi, -2f, 0f, 0f, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 1315)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
					if (Main.netMode != 1)
					{
						if (Main.invasionType == 0)
						{
							Main.invasionDelay = 0;
							Main.StartInvasion(3);
						}
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", this.whoAmi, -3f, 0f, 0f, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 1844 && !Main.dayTime && !Main.pumpkinMoon && !Main.snowMoon)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
					if (Main.netMode != 1)
					{
						Main.NewText(Lang.misc[31], 50, 255, 130, false);
						Main.startPumpkinMoon();
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", this.whoAmi, -4f, 0f, 0f, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 1958 && !Main.dayTime && !Main.pumpkinMoon && !Main.snowMoon)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
					if (Main.netMode != 1)
					{
						Main.NewText(Lang.misc[34], 50, 255, 130, false);
						Main.startSnowMoon();
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", this.whoAmi, -5f, 0f, 0f, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].makeNPC > 0 && this.controlUseItem && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					int x6 = Main.mouseX + (int)Main.screenPosition.X;
					int y6 = Main.mouseY + (int)Main.screenPosition.Y;
					NPC.ReleaseNPC(x6, y6, (int)this.inventory[this.selectedItem].makeNPC, this.inventory[this.selectedItem].placeStyle, this.whoAmi);
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && (this.inventory[this.selectedItem].type == 43 || this.inventory[this.selectedItem].type == 70 || this.inventory[this.selectedItem].type == 544 || this.inventory[this.selectedItem].type == 556 || this.inventory[this.selectedItem].type == 557 || this.inventory[this.selectedItem].type == 560 || this.inventory[this.selectedItem].type == 1133 || this.inventory[this.selectedItem].type == 1331) && this.SummonItemCheck())
				{
					if (this.inventory[this.selectedItem].type == 560)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
						if (Main.netMode != 1)
						{
							NPC.SpawnOnPlayer(i, 50);
						}
						else
						{
							NetMessage.SendData(61, -1, -1, "", this.whoAmi, 50f, 0f, 0f, 0);
						}
					}
					else if (this.inventory[this.selectedItem].type == 43)
					{
						if (!Main.dayTime)
						{
							this.itemTime = this.inventory[this.selectedItem].useTime;
							Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
							if (Main.netMode != 1)
							{
								NPC.SpawnOnPlayer(i, 4);
							}
							else
							{
								NetMessage.SendData(61, -1, -1, "", this.whoAmi, 4f, 0f, 0f, 0);
							}
						}
					}
					else if (this.inventory[this.selectedItem].type == 70)
					{
						if (this.zoneEvil)
						{
							this.itemTime = this.inventory[this.selectedItem].useTime;
							Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
							if (Main.netMode != 1)
							{
								NPC.SpawnOnPlayer(i, 13);
							}
							else
							{
								NetMessage.SendData(61, -1, -1, "", this.whoAmi, 13f, 0f, 0f, 0);
							}
						}
					}
					else if (this.inventory[this.selectedItem].type == 544)
					{
						if (!Main.dayTime)
						{
							this.itemTime = this.inventory[this.selectedItem].useTime;
							Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
							if (Main.netMode != 1)
							{
								NPC.SpawnOnPlayer(i, 125);
								NPC.SpawnOnPlayer(i, 126);
							}
							else
							{
								NetMessage.SendData(61, -1, -1, "", this.whoAmi, 125f, 0f, 0f, 0);
								NetMessage.SendData(61, -1, -1, "", this.whoAmi, 126f, 0f, 0f, 0);
							}
						}
					}
					else if (this.inventory[this.selectedItem].type == 556)
					{
						if (!Main.dayTime)
						{
							this.itemTime = this.inventory[this.selectedItem].useTime;
							Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
							if (Main.netMode != 1)
							{
								NPC.SpawnOnPlayer(i, 134);
							}
							else
							{
								NetMessage.SendData(61, -1, -1, "", this.whoAmi, 134f, 0f, 0f, 0);
							}
						}
					}
					else if (this.inventory[this.selectedItem].type == 557)
					{
						if (!Main.dayTime)
						{
							this.itemTime = this.inventory[this.selectedItem].useTime;
							Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
							if (Main.netMode != 1)
							{
								NPC.SpawnOnPlayer(i, 127);
							}
							else
							{
								NetMessage.SendData(61, -1, -1, "", this.whoAmi, 127f, 0f, 0f, 0);
							}
						}
					}
					else if (this.inventory[this.selectedItem].type == 1133)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
						if (Main.netMode != 1)
						{
							NPC.SpawnOnPlayer(i, 222);
						}
						else
						{
							NetMessage.SendData(61, -1, -1, "", this.whoAmi, 222f, 0f, 0f, 0);
						}
					}
					else if (this.inventory[this.selectedItem].type == 1331 && this.zoneBlood)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
						if (Main.netMode != 1)
						{
							NPC.SpawnOnPlayer(i, 266);
						}
						else
						{
							NetMessage.SendData(61, -1, -1, "", this.whoAmi, 266f, 0f, 0f, 0);
						}
					}
				}
			}
			if (this.inventory[this.selectedItem].type == 50 && this.itemAnimation > 0)
			{
				if (Main.rand.Next(2) == 0)
				{
					Dust.NewDust(this.position, this.width, this.height, 15, 0f, 0f, 150, default(Color), 1.1f);
				}
				if (this.itemTime == 0)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
				}
				else if (this.itemTime == this.inventory[this.selectedItem].useTime / 2)
				{
					for (int num229 = 0; num229 < 70; num229++)
					{
						Dust.NewDust(this.position, this.width, this.height, 15, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, default(Color), 1.5f);
					}
					this.grappling[0] = -1;
					this.grapCount = 0;
					for (int num230 = 0; num230 < 1000; num230++)
					{
						if (Main.projectile[num230].active && Main.projectile[num230].owner == i && Main.projectile[num230].aiStyle == 7)
						{
							Main.projectile[num230].Kill();
						}
					}
					this.Spawn();
					for (int num231 = 0; num231 < 70; num231++)
					{
						Dust.NewDust(this.position, this.width, this.height, 15, 0f, 0f, 150, default(Color), 1.5f);
					}
				}
			}
			if (i == Main.myPlayer)
			{
				if (this.itemTime == this.inventory[this.selectedItem].useTime && this.inventory[this.selectedItem].tileWand > 0)
				{
					int tileWand2 = this.inventory[this.selectedItem].tileWand;
					int num232 = 0;
					while (num232 < 58)
					{
						if (tileWand2 == this.inventory[num232].type && this.inventory[num232].stack > 0)
						{
							this.inventory[num232].stack--;
							if (this.inventory[num232].stack <= 0)
							{
								this.inventory[num232] = new Item();
								break;
							}
							break;
						}
						else
						{
							num232++;
						}
					}
				}
				if (this.itemTime == this.inventory[this.selectedItem].useTime && this.inventory[this.selectedItem].consumable)
				{
					bool flag14 = true;
					if (this.inventory[this.selectedItem].ranged)
					{
						if (this.ammoCost80 && Main.rand.Next(5) == 0)
						{
							flag14 = false;
						}
						if (this.ammoCost75 && Main.rand.Next(4) == 0)
						{
							flag14 = false;
						}
					}
					if (flag14)
					{
						if (this.inventory[this.selectedItem].stack > 0)
						{
							this.inventory[this.selectedItem].stack--;
						}
						if (this.inventory[this.selectedItem].stack <= 0)
						{
							this.itemTime = this.itemAnimation;
						}
					}
				}
				if (this.inventory[this.selectedItem].stack <= 0 && this.itemAnimation == 0)
				{
					this.inventory[this.selectedItem] = new Item();
				}
				if (this.selectedItem == 58)
				{
					if (this.itemAnimation == 0)
					{
						return;
					}
					Main.mouseItem = this.inventory[this.selectedItem].Clone();
				}
			}
		}
		public Color GetImmuneAlpha(Color newColor)
		{
			float num = (float)(255 - this.immuneAlpha) / 255f;
			if (this.shadow > 0f)
			{
				num *= 1f - this.shadow;
			}
			if (this.immuneAlpha > 125)
			{
				return new Color(0, 0, 0, 0);
			}
			int r = (int)((float)newColor.R * num);
			int g = (int)((float)newColor.G * num);
			int b = (int)((float)newColor.B * num);
			int num2 = (int)((float)newColor.A * num);
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			return new Color(r, g, b, num2);
		}
		public Color GetImmuneAlpha2(Color newColor)
		{
			float num = (float)(255 - this.immuneAlpha) / 255f;
			if (this.shadow > 0f)
			{
				num *= 1f - this.shadow;
			}
			int r = (int)((float)newColor.R * num);
			int g = (int)((float)newColor.G * num);
			int b = (int)((float)newColor.B * num);
			int num2 = (int)((float)newColor.A * num);
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			return new Color(r, g, b, num2);
		}
		public Color GetDeathAlpha(Color newColor)
		{
			int r = (int)newColor.R + (int)((double)this.immuneAlpha * 0.9);
			int g = (int)newColor.G + (int)((double)this.immuneAlpha * 0.5);
			int b = (int)newColor.B + (int)((double)this.immuneAlpha * 0.5);
			int num = (int)newColor.A + (int)((double)this.immuneAlpha * 0.4);
			if (num < 0)
			{
				num = 0;
			}
			if (num > 255)
			{
				num = 255;
			}
			return new Color(r, g, b, num);
		}
		public void DropCoins()
		{
			for (int i = 0; i < 59; i++)
			{
				if (this.inventory[i].type >= 71 && this.inventory[i].type <= 74)
				{
					int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[i].type, 1, false, 0, false);
					int num2 = this.inventory[i].stack / 2;
					num2 = this.inventory[i].stack - num2;
					this.inventory[i].stack -= num2;
					if (this.inventory[i].stack <= 0)
					{
						this.inventory[i] = new Item();
					}
					Main.item[num].stack = num2;
					Main.item[num].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
					Main.item[num].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
					Main.item[num].noGrabDelay = 100;
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0);
					}
					if (i == 58)
					{
						Main.mouseItem = this.inventory[i].Clone();
					}
				}
			}
		}
		public void DropItems()
		{
			for (int i = 0; i < 59; i++)
			{
				if (this.inventory[i].stack > 0 && this.inventory[i].name != "Copper Pickaxe" && this.inventory[i].name != "Copper Axe" && this.inventory[i].name != "Copper Shortsword")
				{
					int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[i].type, 1, false, 0, false);
					Main.item[num].SetDefaults(this.inventory[i].name);
					Main.item[num].Prefix((int)this.inventory[i].prefix);
					Main.item[num].stack = this.inventory[i].stack;
					Main.item[num].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
					Main.item[num].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
					Main.item[num].noGrabDelay = 100;
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0);
					}
				}
				this.inventory[i] = new Item();
				if (i < 16)
				{
					if (this.armor[i].stack > 0)
					{
						int num2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.armor[i].type, 1, false, 0, false);
						Main.item[num2].SetDefaults(this.armor[i].name);
						Main.item[num2].Prefix((int)this.armor[i].prefix);
						Main.item[num2].stack = this.armor[i].stack;
						Main.item[num2].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
						Main.item[num2].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
						Main.item[num2].noGrabDelay = 100;
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", num2, 0f, 0f, 0f, 0);
						}
					}
					this.armor[i] = new Item();
				}
				if (i < 8)
				{
					if (this.dye[i].stack > 0)
					{
						int num3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.dye[i].type, 1, false, 0, false);
						Main.item[num3].SetDefaults(this.dye[i].name);
						Main.item[num3].Prefix((int)this.dye[i].prefix);
						Main.item[num3].stack = this.dye[i].stack;
						Main.item[num3].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
						Main.item[num3].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
						Main.item[num3].noGrabDelay = 100;
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", num3, 0f, 0f, 0f, 0);
						}
					}
					this.dye[i] = new Item();
				}
			}
			this.inventory[0].SetDefaults("Copper Shortsword");
			this.inventory[0].Prefix(-1);
			this.inventory[1].SetDefaults("Copper Pickaxe");
			this.inventory[1].Prefix(-1);
			this.inventory[2].SetDefaults("Copper Axe");
			this.inventory[2].Prefix(-1);
			Main.mouseItem = new Item();
		}
		public object Clone()
		{
			return base.MemberwiseClone();
		}
		public object clientClone()
		{
			Player player = new Player();
			player.zoneEvil = this.zoneEvil;
			player.zoneMeteor = this.zoneMeteor;
			player.zoneDungeon = this.zoneDungeon;
			player.zoneJungle = this.zoneJungle;
			player.zoneHoly = this.zoneHoly;
			player.zoneSnow = this.zoneSnow;
			player.zoneBlood = this.zoneBlood;
			player.zoneCandle = this.zoneCandle;
			player.direction = this.direction;
			player.selectedItem = this.selectedItem;
			player.controlUp = this.controlUp;
			player.controlDown = this.controlDown;
			player.controlLeft = this.controlLeft;
			player.controlRight = this.controlRight;
			player.controlJump = this.controlJump;
			player.controlUseItem = this.controlUseItem;
			player.statLife = this.statLife;
			player.statLifeMax = this.statLifeMax;
			player.statMana = this.statMana;
			player.statManaMax = this.statManaMax;
			player.position.X = this.position.X;
			player.chest = this.chest;
			player.talkNPC = this.talkNPC;
			player.hideVisual = this.hideVisual;
			for (int i = 0; i < 59; i++)
			{
				player.inventory[i] = this.inventory[i].Clone();
				if (i < 16)
				{
					player.armor[i] = this.armor[i].Clone();
				}
				if (i < 8)
				{
					player.dye[i] = this.dye[i].Clone();
				}
			}
			for (int j = 0; j < 22; j++)
			{
				player.buffType[j] = this.buffType[j];
				player.buffTime[j] = this.buffTime[j];
			}
			return player;
		}
		private static void EncryptFile(string inputFile, string outputFile)
		{
			string s = "h3y_gUyZ";
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			byte[] bytes = unicodeEncoding.GetBytes(s);
			FileStream fileStream = new FileStream(outputFile, FileMode.Create);
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
			FileStream fileStream2 = new FileStream(inputFile, FileMode.Open);
			int num;
			while ((num = fileStream2.ReadByte()) != -1)
			{
				cryptoStream.WriteByte((byte)num);
			}
			fileStream2.Close();
			cryptoStream.Close();
			fileStream.Close();
		}
		private static bool DecryptFile(string inputFile, string outputFile)
		{
			string s = "h3y_gUyZ";
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			byte[] bytes = unicodeEncoding.GetBytes(s);
			FileStream fileStream = new FileStream(inputFile, FileMode.Open);
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
			FileStream fileStream2 = new FileStream(outputFile, FileMode.Create);
			try
			{
				int num;
				while ((num = cryptoStream.ReadByte()) != -1)
				{
					fileStream2.WriteByte((byte)num);
				}
				fileStream2.Close();
				cryptoStream.Close();
				fileStream.Close();
			}
			catch
			{
				fileStream2.Close();
				fileStream.Close();
				File.Delete(outputFile);
				return true;
			}
			return false;
		}
		public static bool CheckSpawn(int x, int y)
		{
			if (x < 10 || x > Main.maxTilesX - 10 || y < 10 || y > Main.maxTilesX - 10)
			{
				return false;
			}
			if (Main.tile[x, y - 1] == null)
			{
				return false;
			}
			if (!Main.tile[x, y - 1].active() || Main.tile[x, y - 1].type != 79)
			{
				return false;
			}
			for (int i = x - 1; i <= x + 1; i++)
			{
				for (int j = y - 3; j < y; j++)
				{
					if (Main.tile[i, j] == null)
					{
						return false;
					}
					if (Main.tile[i, j].nactive() && Main.tileSolid[(int)Main.tile[i, j].type] && !Main.tileSolidTop[(int)Main.tile[i, j].type])
					{
						Main.NewText("There is not enough space", 255, 240, 20, false);
						return false;
					}
				}
			}
			return WorldGen.StartRoomCheck(x, y - 1);
		}
		public void FindSpawn()
		{
			for (int i = 0; i < 200; i++)
			{
				if (this.spN[i] == null)
				{
					this.SpawnX = -1;
					this.SpawnY = -1;
					return;
				}
				if (this.spN[i] == Main.worldName && this.spI[i] == Main.worldID)
				{
					this.SpawnX = this.spX[i];
					this.SpawnY = this.spY[i];
					return;
				}
			}
		}
		public void ChangeSpawn(int x, int y)
		{
			int num = 0;
			while (num < 200 && this.spN[num] != null)
			{
				if (this.spN[num] == Main.worldName && this.spI[num] == Main.worldID)
				{
					for (int i = num; i > 0; i--)
					{
						this.spN[i] = this.spN[i - 1];
						this.spI[i] = this.spI[i - 1];
						this.spX[i] = this.spX[i - 1];
						this.spY[i] = this.spY[i - 1];
					}
					this.spN[0] = Main.worldName;
					this.spI[0] = Main.worldID;
					this.spX[0] = x;
					this.spY[0] = y;
					return;
				}
				num++;
			}
			for (int j = 199; j > 0; j--)
			{
				if (this.spN[j - 1] != null)
				{
					this.spN[j] = this.spN[j - 1];
					this.spI[j] = this.spI[j - 1];
					this.spX[j] = this.spX[j - 1];
					this.spY[j] = this.spY[j - 1];
				}
			}
			this.spN[0] = Main.worldName;
			this.spI[0] = Main.worldID;
			this.spX[0] = x;
			this.spY[0] = y;
		}
		public Color GetHairColor(bool lighting = true)
		{
			Color color = this.hairColor;
			if (this.hairDye == 1)
			{
				color.R = (byte)((float)this.statLife / (float)this.statLifeMax * 235f + 20f);
				color.B = 20;
				color.G = 20;
			}
			else if (this.hairDye == 2)
			{
				color.R = (byte)((1f - (float)this.statMana / (float)this.statManaMax) * 200f + 50f);
				color.B = 255;
				color.G = (byte)((1f - (float)this.statMana / (float)this.statManaMax) * 180f + 75f);
			}
			else if (this.hairDye == 3)
			{
				float num = (float)(Main.worldSurface * 0.45) * 16f;
				float num2 = (float)(Main.worldSurface + Main.rockLayer) * 8f;
				float num3 = (float)(Main.rockLayer + (double)Main.maxTilesY) * 8f;
				float num4 = (float)(Main.maxTilesY - 150) * 16f;
				if (this.center().Y < num)
				{
					float num5 = this.center().Y / num;
					float num6 = 1f - num5;
					color.R = (byte)(116f * num6 + 28f * num5);
					color.G = (byte)(160f * num6 + 216f * num5);
					color.B = (byte)(249f * num6 + 94f * num5);
				}
				else if (this.center().Y < num2)
				{
					float num7 = num;
					float num8 = (this.center().Y - num7) / (num2 - num7);
					float num9 = 1f - num8;
					color.R = (byte)(28f * num9 + 151f * num8);
					color.G = (byte)(216f * num9 + 107f * num8);
					color.B = (byte)(94f * num9 + 75f * num8);
				}
				else if (this.center().Y < num3)
				{
					float num10 = num2;
					float num11 = (this.center().Y - num10) / (num3 - num10);
					float num12 = 1f - num11;
					color.R = (byte)(151f * num12 + 128f * num11);
					color.G = (byte)(107f * num12 + 128f * num11);
					color.B = (byte)(75f * num12 + 128f * num11);
				}
				else if (this.center().Y < num4)
				{
					float num13 = num3;
					float num14 = (this.center().Y - num13) / (num4 - num13);
					float num15 = 1f - num14;
					color.R = (byte)(128f * num15 + 255f * num14);
					color.G = (byte)(128f * num15 + 50f * num14);
					color.B = (byte)(128f * num15 + 15f * num14);
				}
				else
				{
					color.R = 255;
					color.G = 50;
					color.B = 10;
				}
			}
			else if (this.hairDye == 4)
			{
				int num16 = 0;
				for (int i = 0; i < 54; i++)
				{
					if (this.inventory[i].type == 71)
					{
						num16 += this.inventory[i].stack;
					}
					if (this.inventory[i].type == 72)
					{
						num16 += this.inventory[i].stack * 100;
					}
					if (this.inventory[i].type == 73)
					{
						num16 += this.inventory[i].stack * 10000;
					}
					if (this.inventory[i].type == 74)
					{
						num16 += this.inventory[i].stack * 1000000;
					}
				}
				float num17 = (float)Item.buyPrice(0, 5, 0, 0);
				float num18 = (float)Item.buyPrice(0, 50, 0, 0);
				float num19 = (float)Item.buyPrice(2, 0, 0, 0);
				Color color2 = new Color(226, 118, 76);
				Color color3 = new Color(174, 194, 196);
				Color color4 = new Color(204, 181, 72);
				Color color5 = new Color(161, 172, 173);
				if ((float)num16 < num17)
				{
					float num20 = (float)num16 / num17;
					float num21 = 1f - num20;
					color.R = (byte)((float)color2.R * num21 + (float)color3.R * num20);
					color.G = (byte)((float)color2.G * num21 + (float)color3.G * num20);
					color.B = (byte)((float)color2.B * num21 + (float)color3.B * num20);
				}
				else if ((float)num16 < num18)
				{
					float num22 = num17;
					float num23 = ((float)num16 - num22) / (num18 - num22);
					float num24 = 1f - num23;
					color.R = (byte)((float)color3.R * num24 + (float)color4.R * num23);
					color.G = (byte)((float)color3.G * num24 + (float)color4.G * num23);
					color.B = (byte)((float)color3.B * num24 + (float)color4.B * num23);
				}
				else if ((float)num16 < num19)
				{
					float num25 = num18;
					float num26 = ((float)num16 - num25) / (num19 - num25);
					float num27 = 1f - num26;
					color.R = (byte)((float)color4.R * num27 + (float)color5.R * num26);
					color.G = (byte)((float)color4.G * num27 + (float)color5.G * num26);
					color.B = (byte)((float)color4.B * num27 + (float)color5.B * num26);
				}
				else
				{
					color = color5;
				}
			}
			else if (this.hairDye == 5)
			{
				Color color6 = new Color(1, 142, 255);
				Color color7 = new Color(255, 255, 0);
				Color color8 = new Color(211, 45, 127);
				Color color9 = new Color(67, 44, 118);
				if (Main.dayTime)
				{
					if (Main.time < 27000.0)
					{
						float num28 = (float)(Main.time / 27000.0);
						float num29 = 1f - num28;
						color.R = (byte)((float)color6.R * num29 + (float)color7.R * num28);
						color.G = (byte)((float)color6.G * num29 + (float)color7.G * num28);
						color.B = (byte)((float)color6.B * num29 + (float)color7.B * num28);
					}
					else
					{
						float num30 = 27000f;
						float num31 = (float)((Main.time - (double)num30) / (54000.0 - (double)num30));
						float num32 = 1f - num31;
						color.R = (byte)((float)color7.R * num32 + (float)color8.R * num31);
						color.G = (byte)((float)color7.G * num32 + (float)color8.G * num31);
						color.B = (byte)((float)color7.B * num32 + (float)color8.B * num31);
					}
				}
				else if (Main.time < 16200.0)
				{
					float num33 = (float)(Main.time / 16200.0);
					float num34 = 1f - num33;
					color.R = (byte)((float)color8.R * num34 + (float)color9.R * num33);
					color.G = (byte)((float)color8.G * num34 + (float)color9.G * num33);
					color.B = (byte)((float)color8.B * num34 + (float)color9.B * num33);
				}
				else
				{
					float num35 = 16200f;
					float num36 = (float)((Main.time - (double)num35) / (32400.0 - (double)num35));
					float num37 = 1f - num36;
					color.R = (byte)((float)color9.R * num37 + (float)color6.R * num36);
					color.G = (byte)((float)color9.G * num37 + (float)color6.G * num36);
					color.B = (byte)((float)color9.B * num37 + (float)color6.B * num36);
				}
			}
			else if (this.hairDye == 6)
			{
				if (this.team == 1)
				{
					color = new Color(255, 0, 0);
				}
				else if (this.team == 2)
				{
					color = new Color(0, 255, 0);
				}
				else if (this.team == 3)
				{
					color = new Color(0, 0, 255);
				}
				else if (this.team == 4)
				{
					color = new Color(255, 255, 0);
				}
			}
			else if (this.hairDye == 7)
			{
				Color color10 = default(Color);
				if (Main.waterStyle == 2)
				{
					color10 = new Color(124, 118, 242);
				}
				else if (Main.waterStyle == 3)
				{
					color10 = new Color(143, 215, 29);
				}
				else if (Main.waterStyle == 4)
				{
					color10 = new Color(78, 193, 227);
				}
				else if (Main.waterStyle == 5)
				{
					color10 = new Color(189, 231, 255);
				}
				else if (Main.waterStyle == 6)
				{
					color10 = new Color(230, 219, 100);
				}
				else if (Main.waterStyle == 7)
				{
					color10 = new Color(151, 107, 75);
				}
				else if (Main.waterStyle == 8)
				{
					color10 = new Color(128, 128, 128);
				}
				else if (Main.waterStyle == 9)
				{
					color10 = new Color(200, 0, 0);
				}
				else if (Main.waterStyle == 10)
				{
					color10 = new Color(208, 80, 80);
				}
				else
				{
					color10 = new Color(28, 216, 94);
				}
				if (this.hairDyeColor.A == 0)
				{
					this.hairDyeColor = color10;
				}
				if (this.hairDyeColor.R > color10.R)
				{
					this.hairDyeColor.R = (byte)(this.hairDyeColor.R - 1);
				}
				if (this.hairDyeColor.R < color10.R)
				{
					this.hairDyeColor.R = (byte)(this.hairDyeColor.R + 1);
				}
				if (this.hairDyeColor.G > color10.G)
				{
					this.hairDyeColor.G = (byte)(this.hairDyeColor.G - 1);
				}
				if (this.hairDyeColor.G < color10.G)
				{
					this.hairDyeColor.G = (byte)(this.hairDyeColor.G + 1);
				}
				if (this.hairDyeColor.B > color10.B)
				{
					this.hairDyeColor.B = (byte)(this.hairDyeColor.B - 1);
				}
				if (this.hairDyeColor.B < color10.B)
				{
					this.hairDyeColor.B = (byte)(this.hairDyeColor.B + 1);
				}
				color = this.hairDyeColor;
			}
			else if (this.hairDye == 8)
			{
				color = new Color(244, 22, 175);
				if (!Main.gameMenu && !Main.gamePaused)
				{
					if (Main.rand.Next(45) == 0)
					{
						int type = Main.rand.Next(139, 143);
						int num38 = Dust.NewDust(this.position, this.width, 8, type, 0f, 0f, 0, default(Color), 1.2f);
						Dust expr_BE5_cp_0 = Main.dust[num38];
						expr_BE5_cp_0.velocity.X = expr_BE5_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Dust expr_C19_cp_0 = Main.dust[num38];
						expr_C19_cp_0.velocity.Y = expr_C19_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Dust expr_C4D_cp_0 = Main.dust[num38];
						expr_C4D_cp_0.velocity.X = expr_C4D_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
						Dust expr_C7B_cp_0 = Main.dust[num38];
						expr_C7B_cp_0.velocity.Y = expr_C7B_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
						Dust expr_CA9_cp_0 = Main.dust[num38];
						expr_CA9_cp_0.velocity.Y = expr_CA9_cp_0.velocity.Y - 1f;
						Main.dust[num38].scale *= 0.7f + (float)Main.rand.Next(-30, 31) * 0.01f;
						Main.dust[num38].velocity += this.velocity * 0.2f;
					}
					if (Main.rand.Next(225) == 0)
					{
						int type2 = Main.rand.Next(276, 283);
						int num39 = Gore.NewGore(new Vector2(this.position.X + (float)Main.rand.Next(this.width), this.position.Y + (float)Main.rand.Next(8)), this.velocity, type2, 1f);
						Gore expr_D96_cp_0 = Main.gore[num39];
						expr_D96_cp_0.velocity.X = expr_D96_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Gore expr_DCA_cp_0 = Main.gore[num39];
						expr_DCA_cp_0.velocity.Y = expr_DCA_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
						Main.gore[num39].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
						Gore expr_E2D_cp_0 = Main.gore[num39];
						expr_E2D_cp_0.velocity.X = expr_E2D_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
						Gore expr_E5B_cp_0 = Main.gore[num39];
						expr_E5B_cp_0.velocity.Y = expr_E5B_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
						Gore expr_E89_cp_0 = Main.gore[num39];
						expr_E89_cp_0.velocity.Y = expr_E89_cp_0.velocity.Y - 1f;
						Main.gore[num39].velocity += this.velocity * 0.2f;
					}
				}
			}
			else if (this.hairDye == 9)
			{
				color = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
			}
			else if (this.hairDye == 10)
			{
				float num40 = Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y);
				float num41 = 10f;
				if (num40 > num41)
				{
					num40 = num41;
				}
				float num42 = num40 / num41;
				float num43 = 1f - num42;
				color.R = (byte)(75f * num42 + (float)this.hairColor.R * num43);
				color.G = (byte)(255f * num42 + (float)this.hairColor.G * num43);
				color.B = (byte)(200f * num42 + (float)this.hairColor.B * num43);
			}
			return color;
		}
		public bool HasItem(int type)
		{
			for (int i = 0; i < 58; i++)
			{
				if (type == this.inventory[i].type && this.inventory[i].stack > 0)
				{
					return true;
				}
			}
			return false;
		}
		public void QuickGrapple()
		{
			this.Dismount();
			if (this.noItems)
			{
				return;
			}
			int num = -1;
			for (int i = 0; i < 58; i++)
			{
				if (this.inventory[i].shoot == 13 || this.inventory[i].shoot == 32 || this.inventory[i].shoot == 73 || this.inventory[i].shoot == 165 || (this.inventory[i].shoot >= 230 && this.inventory[i].shoot <= 235) || this.inventory[i].shoot == 256 || this.inventory[i].shoot == 315 || this.inventory[i].shoot == 322 || this.inventory[i].shoot == 331 || this.inventory[i].shoot == 332)
				{
					num = i;
					break;
				}
			}
			if (num < 0)
			{
				return;
			}
			if (this.inventory[num].shoot == 73)
			{
				int num2 = 0;
				if (num >= 0)
				{
					for (int j = 0; j < 1000; j++)
					{
						if (Main.projectile[j].active && Main.projectile[j].owner == Main.myPlayer && (Main.projectile[j].type == 73 || Main.projectile[j].type == 74))
						{
							num2++;
						}
					}
				}
				if (num2 > 1)
				{
					num = -1;
				}
			}
			else if (this.inventory[num].shoot == 165)
			{
				int num3 = 0;
				if (num >= 0)
				{
					for (int k = 0; k < 1000; k++)
					{
						if (Main.projectile[k].active && Main.projectile[k].owner == Main.myPlayer && Main.projectile[k].type == 165)
						{
							num3++;
						}
					}
				}
				if (num3 > 8)
				{
					num = -1;
				}
			}
			else if (num >= 0)
			{
				for (int l = 0; l < 1000; l++)
				{
					if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == this.inventory[num].shoot && Main.projectile[l].ai[0] != 2f)
					{
						num = -1;
						break;
					}
				}
			}
			if (num >= 0)
			{
				Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, this.inventory[num].useSound);
				if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
				{
					NetMessage.SendData(51, -1, -1, "", this.whoAmi, 2f, 0f, 0f, 0);
				}
				int num4 = this.inventory[num].shoot;
				float shootSpeed = this.inventory[num].shootSpeed;
				int damage = this.inventory[num].damage;
				float knockBack = this.inventory[num].knockBack;
				if (num4 == 13 || num4 == 32 || num4 == 315 || (num4 >= 230 && num4 <= 235) || num4 == 331)
				{
					this.grappling[0] = -1;
					this.grapCount = 0;
					for (int m = 0; m < 1000; m++)
					{
						if (Main.projectile[m].active && Main.projectile[m].owner == this.whoAmi)
						{
							if (Main.projectile[m].type == 13)
							{
								Main.projectile[m].Kill();
							}
							if (Main.projectile[m].type == 331)
							{
								Main.projectile[m].Kill();
							}
							if (Main.projectile[m].type == 315)
							{
								Main.projectile[m].Kill();
							}
							if (Main.projectile[m].type >= 230 && Main.projectile[m].type <= 235)
							{
								Main.projectile[m].Kill();
							}
						}
					}
				}
				if (num4 == 256)
				{
					int num5 = 0;
					int num6 = -1;
					int num7 = 100000;
					for (int n = 0; n < 1000; n++)
					{
						if (Main.projectile[n].active && Main.projectile[n].owner == this.whoAmi && Main.projectile[n].type == 256)
						{
							num5++;
							if (Main.projectile[n].timeLeft < num7)
							{
								num6 = n;
								num7 = Main.projectile[n].timeLeft;
							}
						}
					}
					if (num5 > 1)
					{
						Main.projectile[num6].Kill();
					}
				}
				if (num4 == 73)
				{
					for (int num8 = 0; num8 < 1000; num8++)
					{
						if (Main.projectile[num8].active && Main.projectile[num8].owner == this.whoAmi && Main.projectile[num8].type == 73)
						{
							num4 = 74;
						}
					}
				}
				Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num9 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
				float num10 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
				if (this.gravDir == -1f)
				{
					num10 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector.Y;
				}
				float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
				num11 = shootSpeed / num11;
				num9 *= num11;
				num10 *= num11;
				Projectile.NewProjectile(vector.X, vector.Y, num9, num10, num4, damage, knockBack, this.whoAmi, 0f, 0f);
			}
		}
		public Player()
		{
			this.name = string.Empty;
			for (int i = 0; i < 59; i++)
			{
				if (i < 16)
				{
					this.armor[i] = new Item();
					this.armor[i].name = "";
				}
				this.inventory[i] = new Item();
				this.inventory[i].name = "";
			}
			for (int j = 0; j < Chest.maxItems; j++)
			{
				this.bank.item[j] = new Item();
				this.bank.item[j].name = "";
				this.bank2.item[j] = new Item();
				this.bank2.item[j].name = "";
			}
			for (int k = 0; k < 8; k++)
			{
				this.dye[k] = new Item();
			}
			this.grappling[0] = -1;
			this.inventory[0].SetDefaults("Copper Shortsword");
			this.inventory[1].SetDefaults("Copper Pickaxe");
			this.inventory[2].SetDefaults("Copper Axe");
			this.statManaMax = 20;
			if (Main.cEd)
			{
				this.inventory[3].SetDefaults(603, false);
			}
			for (int l = 0; l < 314; l++)
			{
				this.adjTile[l] = false;
				this.oldAdjTile[l] = false;
			}
		}
	}
}
