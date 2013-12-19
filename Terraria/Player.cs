using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace Terraria
{
	public class Player
	{
		public const int maxBuffs = 22;
		public Vector2[] itemFlamePos = new Vector2[7];
		public int itemFlameCount;
		public bool outOfRange;
		public float lifeSteal = 99999f;
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
		public int chatShowTime;
		public int reuseDelay;
		public int aggro;
		public float activeNPCs;
		public bool mouseInterface;
		public bool lastMouseInterface;
		public int noThrow;
		public int changeItem = -1;
		public int selectedItem;
		public Item[] armor = new Item[11];
		public Item[] dye = new Item[3];
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
		public bool[] buffImmune = new bool[93];
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
		public Item[] bank = new Item[Chest.maxItems];
		public Item[] bank2 = new Item[Chest.maxItems];
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
		public int hitTile;
		public int hitTileX;
		public int hitTileY;
		public int jump;
		public int head = -1;
		public int body = -1;
		public int legs = -1;
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
		public bool chaosState;
		public bool lightOrb;
		public bool fairy;
		public bool bunny;
		public bool turtle;
		public bool eater;
		public bool penguin;
		public bool puppy;
		public bool grinch;
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
		public bool oldAdjWater;
		public bool oldAdjHoney;
		public bool[] adjTile = new bool[255];
		public bool[] oldAdjTile = new bool[255];
		private static int itemGrabRange = 38;
		private static float itemGrabSpeed = 0.45f;
		private static float itemGrabSpeedMax = 4f;
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
		public void HealEffect(int healAmount, bool broadcast = true)
		{
			CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(100, 255, 100, 255), string.Concat(healAmount), false, false);
			if (broadcast && Main.netMode == 1 && this.whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(35, -1, -1, "", this.whoAmi, (float)healAmount, 0f, 0f, 0);
			}
		}
		public void ManaEffect(int manaAmount)
		{
			CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(100, 100, 255, 255), string.Concat(manaAmount), false, false);
			if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(43, -1, -1, "", this.whoAmi, (float)manaAmount, 0f, 0f, 0);
			}
		}
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
		public void toggleInv()
		{
			if (this.talkNPC >= 0)
			{
				this.talkNPC = -1;
				Main.npcChatText = "";
				Main.PlaySound(11, -1, -1, 1);
				return;
			}
			if (this.sign >= 0)
			{
				this.sign = -1;
				Main.editSign = false;
				Main.npcChatText = "";
				Main.PlaySound(11, -1, -1, 1);
				return;
			}
			if (!Main.playerInventory)
			{
				Recipe.FindRecipes();
				Main.playerInventory = true;
				Main.PlaySound(10, -1, -1, 1);
				return;
			}
			Main.playerInventory = false;
			Main.PlaySound(11, -1, -1, 1);
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
				this.inventory[58] = (Item)Main.mouseItem.Clone();
			}
			bool flag = true;
			if (Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)
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
					if (this.buffTime[j] < time)
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
					if (this.inventory[i].healLife > 0 && Main.myPlayer == this.whoAmi)
					{
						this.HealEffect(this.inventory[i].healLife, true);
					}
					if (this.inventory[i].healMana > 0 && Main.myPlayer == this.whoAmi)
					{
						this.ManaEffect(this.inventory[i].healMana);
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
					if (this.inventory[i].healLife > 0 && Main.myPlayer == this.whoAmi)
					{
						this.HealEffect(this.inventory[i].healLife, true);
					}
					if (this.inventory[i].healMana > 0 && Main.myPlayer == this.whoAmi)
					{
						this.ManaEffect(this.inventory[i].healMana);
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
					bool flag = true;
					for (int j = 0; j < 22; j++)
					{
						if (this.buffType[j] == this.inventory[i].buffType)
						{
							flag = false;
							break;
						}
						if (Main.meleeBuff[this.inventory[i].buffType] && Main.meleeBuff[this.buffType[j]])
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
					if (flag)
					{
						num = this.inventory[i].useSound;
						int num2 = this.inventory[i].buffTime;
						if (num2 == 0)
						{
							num2 = 3600;
						}
						this.AddBuff(this.inventory[i].buffType, num2, true);
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
		public int GetWingTime()
		{
			if (this.wings == 1 || this.wings == 2)
			{
				return 100;
			}
			if (this.wings == 4)
			{
				return 115;
			}
			if (this.wings == 5 || this.wings == 6 || this.wings == 15)
			{
				return 130;
			}
			if (this.wings == 7 || this.wings == 8 || this.wings == 14)
			{
				return 140;
			}
			if (this.wings == 9 || this.wings == 10 || this.wings == 11 || this.wings == 13)
			{
				return 160;
			}
			if (this.wings == 12 || this.wings == 20 || this.wings == 21)
			{
				return 180;
			}
			if (this.wings == 22 || this.wings == 23)
			{
				return 170;
			}
			if (this.wings == 16 || this.wings == 17 || this.wings == 18 || this.wings == 19)
			{
				return 190;
			}
			if (this.wings == 3)
			{
				return 220;
			}
			return 90;
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
						this.petalTimer = 60;
						float num8 = 12f;
						Vector2 vector2 = new Vector2(Main.projectile[i].position.X + (float)this.width * 0.5f, Main.projectile[i].position.Y + (float)this.height * 0.5f);
						float num9 = x - vector2.X;
						float num10 = y - vector2.Y;
						float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
						num11 = num8 / num11;
						num9 *= num11;
						num10 *= num11;
						Projectile.NewProjectile(Main.projectile[i].center().X - 4f, Main.projectile[i].center().Y, num9, num10, 227, 40, 5f, this.whoAmi, 0f, 0f);
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
			float num6 = num3;
			this.heldProj = -1;
			bool flag = false;
			if (this.active)
			{
				if (this.lifeSteal < 120f)
				{
					this.lifeSteal += 0.7f;
				}
				if (this.lifeSteal > 120f)
				{
					this.lifeSteal = 120f;
				}
				if (this.mount == 1)
				{
					this.position.Y = this.position.Y + (float)this.height;
					this.height = 62;
					this.position.Y = this.position.Y - (float)this.height;
					int num7 = (int)(this.position.X + (float)(this.width / 2)) / 16;
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
					int num8 = (int)(this.position.X + (float)(this.width / 2)) / 16;
					int num9 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
					if (Main.tile[num8, num9] == null)
					{
						flag = true;
					}
					else if (Main.tile[num8 - 3, num9] == null)
					{
						flag = true;
					}
					else if (Main.tile[num8 + 3, num9] == null)
					{
						flag = true;
					}
					else if (Main.tile[num8, num9 - 3] == null)
					{
						flag = true;
					}
					else if (Main.tile[num8, num9 + 3] == null)
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
				float num10 = (float)(Main.maxTilesX / 4200);
				num10 *= num10;
				float num11 = (float)((double)(this.position.Y / 16f - (60f + 10f * num10)) / (Main.worldSurface / 6.0));
				if ((double)num11 < 0.25)
				{
					num11 = 0.25f;
				}
				if (num11 > 1f)
				{
					num11 = 1f;
				}
				num2 *= num11;
				this.maxRegenDelay = (1f - (float)this.statMana / (float)this.statManaMax2) * 60f * 4f + 45f;
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
					Vector2[] expr_453_cp_0 = this.shadowPos;
					int expr_453_cp_1 = 0;
					expr_453_cp_0[expr_453_cp_1].Y = expr_453_cp_0[expr_453_cp_1].Y + this.gfxOffY;
				}
				if (this.teleportTime > 0f)
				{
					if (this.teleportStyle == 1)
					{
						if ((float)Main.rand.Next(100) <= 100f * this.teleportTime)
						{
							int num12 = Dust.NewDust(new Vector2((float)this.getRect().X, (float)this.getRect().Y), this.getRect().Width, this.getRect().Height, 164, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num12].scale = this.teleportTime * 1.5f;
							Main.dust[num12].noGravity = true;
							Main.dust[num12].velocity *= 1.1f;
						}
					}
					else if ((float)Main.rand.Next(100) <= 100f * this.teleportTime * 2f)
					{
						int num13 = Dust.NewDust(new Vector2((float)this.getRect().X, (float)this.getRect().Y), this.getRect().Width, this.getRect().Height, 159, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num13].scale = this.teleportTime * 1.5f;
						Main.dust[num13].noGravity = true;
						Main.dust[num13].velocity *= 1.1f;
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
						int num14 = (int)this.position.X / 16;
						int num15 = (int)this.position.Y / 16;
						if (Main.wallDungeon[(int)Main.tile[num14, num15].wall])
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
					this.poisoned = false;
					this.venom = false;
					this.onFire = false;
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
					this.fairy = false;
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
					this.penguin = false;
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
					for (int num33 = 0; num33 < 93; num33++)
					{
						this.buffImmune[num33] = false;
					}
					for (int num34 = 0; num34 < 22; num34++)
					{
						if (this.buffType[num34] > 0 && this.buffTime[num34] > 0)
						{
							if (this.whoAmi == Main.myPlayer && this.buffType[num34] != 28)
							{
								this.buffTime[num34]--;
							}
							if (this.buffType[num34] == 1)
							{
								this.lavaImmune = true;
								this.fireWalk = true;
							}
							else if (this.buffType[num34] == 2)
							{
								this.lifeRegen += 2;
							}
							else if (this.buffType[num34] == 3)
							{
								this.moveSpeed += 0.25f;
							}
							else if (this.buffType[num34] == 4)
							{
								this.gills = true;
							}
							else if (this.buffType[num34] == 5)
							{
								this.statDefense += 8;
							}
							else if (this.buffType[num34] == 6)
							{
								this.manaRegenBuff = true;
							}
							else if (this.buffType[num34] == 7)
							{
								this.magicDamage += 0.2f;
							}
							else if (this.buffType[num34] == 8)
							{
								this.slowFall = true;
							}
							else if (this.buffType[num34] == 9)
							{
								this.findTreasure = true;
							}
							else if (this.buffType[num34] == 10)
							{
								this.invis = true;
							}
							else if (this.buffType[num34] == 12)
							{
								this.nightVision = true;
							}
							else if (this.buffType[num34] == 13)
							{
								this.enemySpawns = true;
							}
							else if (this.buffType[num34] == 14)
							{
								this.thorns = true;
							}
							else if (this.buffType[num34] == 15)
							{
								this.waterWalk = true;
							}
							else if (this.buffType[num34] == 16)
							{
								this.archery = true;
							}
							else if (this.buffType[num34] == 17)
							{
								this.detectCreature = true;
							}
							else if (this.buffType[num34] == 18)
							{
								this.gravControl = true;
							}
							else if (this.buffType[num34] == 30)
							{
								this.bleed = true;
							}
							else if (this.buffType[num34] == 31)
							{
								this.confused = true;
							}
							else if (this.buffType[num34] == 32)
							{
								this.slow = true;
							}
							else if (this.buffType[num34] == 35)
							{
								this.silence = true;
							}
							else if (this.buffType[num34] == 46)
							{
								this.chilled = true;
							}
							else if (this.buffType[num34] == 47)
							{
								this.frozen = true;
							}
							else if (this.buffType[num34] == 69)
							{
								this.ichor = true;
								this.statDefense -= 20;
							}
							else if (this.buffType[num34] == 36)
							{
								this.brokenArmor = true;
							}
							else if (this.buffType[num34] == 48)
							{
								this.honey = true;
							}
							else if (this.buffType[num34] == 59)
							{
								this.shadowDodge = true;
							}
							else if (this.buffType[num34] == 58)
							{
								this.palladiumRegen = true;
							}
							else if (this.buffType[num34] == 88)
							{
								this.chaosState = true;
							}
							else if (this.buffType[num34] == 63)
							{
								this.moveSpeed += 1f;
							}
							else if (this.buffType[num34] == 62)
							{
								if ((double)this.statLife <= (double)this.statLifeMax * 0.25)
								{
									this.iceBarrier = true;
									this.statDefense += 30;
									this.iceBarrierFrameCounter += 1;
									if (this.iceBarrierFrameCounter > 2)
									{
										this.iceBarrierFrameCounter = 0;
										this.iceBarrierFrame += 1;
										if (this.iceBarrierFrame >= 12)
										{
											this.iceBarrierFrame = 0;
										}
									}
								}
								else
								{
									this.DelBuff(num34);
								}
							}
							else if (this.buffType[num34] == 49)
							{
								if (Main.myPlayer == i)
								{
									for (int num35 = 0; num35 < 1000; num35++)
									{
										if (Main.projectile[num35].active && Main.projectile[num35].owner == i && Main.projectile[num35].type >= 191 && Main.projectile[num35].type <= 194)
										{
											this.pygmy = true;
											break;
										}
									}
									if (!this.pygmy)
									{
										this.DelBuff(num34);
									}
									else
									{
										this.buffTime[num34] = 18000;
									}
								}
							}
							else if (this.buffType[num34] == 83)
							{
								if (Main.myPlayer == i)
								{
									for (int num36 = 0; num36 < 1000; num36++)
									{
										if (Main.projectile[num36].active && Main.projectile[num36].owner == i && Main.projectile[num36].type == 317)
										{
											this.raven = true;
											break;
										}
									}
									if (!this.raven)
									{
										this.DelBuff(num34);
									}
									else
									{
										this.buffTime[num34] = 18000;
									}
								}
							}
							else if (this.buffType[num34] == 64)
							{
								if (Main.myPlayer == i)
								{
									for (int num37 = 0; num37 < 1000; num37++)
									{
										if (Main.projectile[num37].active && Main.projectile[num37].owner == i && Main.projectile[num37].type == 266)
										{
											this.slime = true;
											break;
										}
									}
									if (!this.slime)
									{
										this.DelBuff(num34);
									}
									else
									{
										this.buffTime[num34] = 18000;
									}
								}
							}
							else if (this.buffType[num34] == 90)
							{
								this.mount = 1;
								this.buffTime[num34] = 10;
							}
							else if (this.buffType[num34] == 37)
							{
								if (Main.wof >= 0 && Main.npc[Main.wof].type == 113)
								{
									this.gross = true;
									this.buffTime[num34] = 10;
								}
								else
								{
									this.DelBuff(num34);
								}
							}
							else if (this.buffType[num34] == 38)
							{
								this.buffTime[num34] = 10;
								this.tongued = true;
							}
							else if (this.buffType[num34] == 19)
							{
								this.buffTime[num34] = 18000;
								this.lightOrb = true;
								bool flag9 = true;
								for (int num38 = 0; num38 < 1000; num38++)
								{
									if (Main.projectile[num38].active && Main.projectile[num38].owner == this.whoAmi && Main.projectile[num38].type == 18)
									{
										flag9 = false;
									}
								}
								if (flag9)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 18, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 27)
							{
								this.buffTime[num34] = 18000;
								this.fairy = true;
								bool flag10 = true;
								for (int num39 = 0; num39 < 1000; num39++)
								{
									if (Main.projectile[num39].active && Main.projectile[num39].owner == this.whoAmi && (Main.projectile[num39].type == 72 || Main.projectile[num39].type == 86 || Main.projectile[num39].type == 87))
									{
										flag10 = false;
										break;
									}
								}
								if (flag10)
								{
									int num40 = Main.rand.Next(3);
									if (num40 == 0)
									{
										num40 = 72;
									}
									else if (num40 == 1)
									{
										num40 = 86;
									}
									else if (num40 == 2)
									{
										num40 = 87;
									}
									if (this.head == 45 && this.body == 26 && this.legs == 25)
									{
										num40 = 72;
									}
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, num40, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 40)
							{
								this.buffTime[num34] = 18000;
								this.bunny = true;
								bool flag11 = true;
								for (int num41 = 0; num41 < 1000; num41++)
								{
									if (Main.projectile[num41].active && Main.projectile[num41].owner == this.whoAmi && Main.projectile[num41].type == 111)
									{
										flag11 = false;
										break;
									}
								}
								if (flag11)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 111, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 41)
							{
								this.buffTime[num34] = 18000;
								this.penguin = true;
								bool flag12 = true;
								for (int num42 = 0; num42 < 1000; num42++)
								{
									if (Main.projectile[num42].active && Main.projectile[num42].owner == this.whoAmi && Main.projectile[num42].type == 112)
									{
										flag12 = false;
										break;
									}
								}
								if (flag12)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 112, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 91)
							{
								this.buffTime[num34] = 18000;
								this.puppy = true;
								bool flag13 = true;
								for (int num43 = 0; num43 < 1000; num43++)
								{
									if (Main.projectile[num43].active && Main.projectile[num43].owner == this.whoAmi && Main.projectile[num43].type == 334)
									{
										flag13 = false;
										break;
									}
								}
								if (flag13)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 334, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 92)
							{
								this.buffTime[num34] = 18000;
								this.grinch = true;
								bool flag14 = true;
								for (int num44 = 0; num44 < 1000; num44++)
								{
									if (Main.projectile[num44].active && Main.projectile[num44].owner == this.whoAmi && Main.projectile[num44].type == 353)
									{
										flag14 = false;
										break;
									}
								}
								if (flag14)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 353, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 84)
							{
								this.buffTime[num34] = 18000;
								this.blackCat = true;
								bool flag15 = true;
								for (int num45 = 0; num45 < 1000; num45++)
								{
									if (Main.projectile[num45].active && Main.projectile[num45].owner == this.whoAmi && Main.projectile[num45].type == 319)
									{
										flag15 = false;
										break;
									}
								}
								if (flag15)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 319, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 61)
							{
								this.buffTime[num34] = 18000;
								this.dino = true;
								bool flag16 = true;
								for (int num46 = 0; num46 < 1000; num46++)
								{
									if (Main.projectile[num46].active && Main.projectile[num46].owner == this.whoAmi && Main.projectile[num46].type == 236)
									{
										flag16 = false;
										break;
									}
								}
								if (flag16)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 236, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 65)
							{
								this.buffTime[num34] = 18000;
								this.eyeSpring = true;
								bool flag17 = true;
								for (int num47 = 0; num47 < 1000; num47++)
								{
									if (Main.projectile[num47].active && Main.projectile[num47].owner == this.whoAmi && Main.projectile[num47].type == 268)
									{
										flag17 = false;
										break;
									}
								}
								if (flag17)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 268, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 66)
							{
								this.buffTime[num34] = 18000;
								this.snowman = true;
								bool flag18 = true;
								for (int num48 = 0; num48 < 1000; num48++)
								{
									if (Main.projectile[num48].active && Main.projectile[num48].owner == this.whoAmi && Main.projectile[num48].type == 269)
									{
										flag18 = false;
										break;
									}
								}
								if (flag18)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 269, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 42)
							{
								this.buffTime[num34] = 18000;
								this.turtle = true;
								bool flag19 = true;
								for (int num49 = 0; num49 < 1000; num49++)
								{
									if (Main.projectile[num49].active && Main.projectile[num49].owner == this.whoAmi && Main.projectile[num49].type == 127)
									{
										flag19 = false;
										break;
									}
								}
								if (flag19)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 127, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 45)
							{
								this.buffTime[num34] = 18000;
								this.eater = true;
								bool flag20 = true;
								for (int num50 = 0; num50 < 1000; num50++)
								{
									if (Main.projectile[num50].active && Main.projectile[num50].owner == this.whoAmi && Main.projectile[num50].type == 175)
									{
										flag20 = false;
										break;
									}
								}
								if (flag20)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 175, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 50)
							{
								this.buffTime[num34] = 18000;
								this.skeletron = true;
								bool flag21 = true;
								for (int num51 = 0; num51 < 1000; num51++)
								{
									if (Main.projectile[num51].active && Main.projectile[num51].owner == this.whoAmi && Main.projectile[num51].type == 197)
									{
										flag21 = false;
										break;
									}
								}
								if (flag21)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 197, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 51)
							{
								this.buffTime[num34] = 18000;
								this.hornet = true;
								bool flag22 = true;
								for (int num52 = 0; num52 < 1000; num52++)
								{
									if (Main.projectile[num52].active && Main.projectile[num52].owner == this.whoAmi && Main.projectile[num52].type == 198)
									{
										flag22 = false;
										break;
									}
								}
								if (flag22)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 198, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 52)
							{
								this.buffTime[num34] = 18000;
								this.tiki = true;
								bool flag23 = true;
								for (int num53 = 0; num53 < 1000; num53++)
								{
									if (Main.projectile[num53].active && Main.projectile[num53].owner == this.whoAmi && Main.projectile[num53].type == 199)
									{
										flag23 = false;
										break;
									}
								}
								if (flag23)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 199, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 53)
							{
								this.buffTime[num34] = 18000;
								this.lizard = true;
								bool flag24 = true;
								for (int num54 = 0; num54 < 1000; num54++)
								{
									if (Main.projectile[num54].active && Main.projectile[num54].owner == this.whoAmi && Main.projectile[num54].type == 200)
									{
										flag24 = false;
										break;
									}
								}
								if (flag24)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 200, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 54)
							{
								this.buffTime[num34] = 18000;
								this.parrot = true;
								bool flag25 = true;
								for (int num55 = 0; num55 < 1000; num55++)
								{
									if (Main.projectile[num55].active && Main.projectile[num55].owner == this.whoAmi && Main.projectile[num55].type == 208)
									{
										flag25 = false;
										break;
									}
								}
								if (flag25)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 208, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 55)
							{
								this.buffTime[num34] = 18000;
								this.truffle = true;
								bool flag26 = true;
								for (int num56 = 0; num56 < 1000; num56++)
								{
									if (Main.projectile[num56].active && Main.projectile[num56].owner == this.whoAmi && Main.projectile[num56].type == 209)
									{
										flag26 = false;
										break;
									}
								}
								if (flag26)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 209, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 56)
							{
								this.buffTime[num34] = 18000;
								this.sapling = true;
								bool flag27 = true;
								for (int num57 = 0; num57 < 1000; num57++)
								{
									if (Main.projectile[num57].active && Main.projectile[num57].owner == this.whoAmi && Main.projectile[num57].type == 210)
									{
										flag27 = false;
										break;
									}
								}
								if (flag27)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 210, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 85)
							{
								this.buffTime[num34] = 18000;
								this.cSapling = true;
								bool flag28 = true;
								for (int num58 = 0; num58 < 1000; num58++)
								{
									if (Main.projectile[num58].active && Main.projectile[num58].owner == this.whoAmi && Main.projectile[num58].type == 324)
									{
										flag28 = false;
										break;
									}
								}
								if (flag28)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 324, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 81)
							{
								this.buffTime[num34] = 18000;
								this.spider = true;
								bool flag29 = true;
								for (int num59 = 0; num59 < 1000; num59++)
								{
									if (Main.projectile[num59].active && Main.projectile[num59].owner == this.whoAmi && Main.projectile[num59].type == 313)
									{
										flag29 = false;
										break;
									}
								}
								if (flag29)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 313, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 82)
							{
								this.buffTime[num34] = 18000;
								this.squashling = true;
								bool flag30 = true;
								for (int num60 = 0; num60 < 1000; num60++)
								{
									if (Main.projectile[num60].active && Main.projectile[num60].owner == this.whoAmi && Main.projectile[num60].type == 314)
									{
										flag30 = false;
										break;
									}
								}
								if (flag30)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 314, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 57)
							{
								this.buffTime[num34] = 18000;
								this.wisp = true;
								bool flag31 = true;
								for (int num61 = 0; num61 < 1000; num61++)
								{
									if (Main.projectile[num61].active && Main.projectile[num61].owner == this.whoAmi && Main.projectile[num61].type == 211)
									{
										flag31 = false;
										break;
									}
								}
								if (flag31)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 211, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 60)
							{
								this.buffTime[num34] = 18000;
								this.crystalLeaf = true;
								bool flag32 = true;
								for (int num62 = 0; num62 < 1000; num62++)
								{
									if (Main.projectile[num62].active && Main.projectile[num62].owner == this.whoAmi && Main.projectile[num62].type == 226)
									{
										if (!flag32)
										{
											Main.projectile[num62].Kill();
										}
										flag32 = false;
									}
								}
								if (flag32)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 226, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num34] == 70)
							{
								this.venom = true;
							}
							else if (this.buffType[num34] == 20)
							{
								this.poisoned = true;
							}
							else if (this.buffType[num34] == 21)
							{
								this.potionDelay = this.buffTime[num34];
							}
							else if (this.buffType[num34] == 22)
							{
								this.blind = true;
							}
							else if (this.buffType[num34] == 80)
							{
								this.blackout = true;
							}
							else if (this.buffType[num34] == 23)
							{
								this.noItems = true;
							}
							else if (this.buffType[num34] == 24)
							{
								this.onFire = true;
							}
							else if (this.buffType[num34] == 67)
							{
								this.burned = true;
							}
							else if (this.buffType[num34] == 68)
							{
								this.suffocating = true;
							}
							else if (this.buffType[num34] == 39)
							{
								this.onFire2 = true;
							}
							else if (this.buffType[num34] == 44)
							{
								this.onFrostBurn = true;
							}
							else if (this.buffType[num34] == 43)
							{
								this.paladinBuff = true;
							}
							else if (this.buffType[num34] == 29)
							{
								this.magicCrit += 2;
								this.magicDamage += 0.05f;
								this.statManaMax2 += 20;
								this.manaCost -= 0.02f;
							}
							else if (this.buffType[num34] == 28)
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
									this.DelBuff(num34);
								}
							}
							else if (this.buffType[num34] == 33)
							{
								this.meleeDamage -= 0.051f;
								this.meleeSpeed -= 0.051f;
								this.statDefense -= 4;
								this.moveSpeed -= 0.1f;
							}
							else if (this.buffType[num34] == 25)
							{
								this.statDefense -= 4;
								this.meleeCrit += 2;
								this.meleeDamage += 0.1f;
								this.meleeSpeed += 0.1f;
							}
							else if (this.buffType[num34] == 26)
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
							else if (this.buffType[num34] == 71)
							{
								this.meleeEnchant = 1;
							}
							else if (this.buffType[num34] == 73)
							{
								this.meleeEnchant = 2;
							}
							else if (this.buffType[num34] == 74)
							{
								this.meleeEnchant = 3;
							}
							else if (this.buffType[num34] == 75)
							{
								this.meleeEnchant = 4;
							}
							else if (this.buffType[num34] == 76)
							{
								this.meleeEnchant = 5;
							}
							else if (this.buffType[num34] == 77)
							{
								this.meleeEnchant = 6;
							}
							else if (this.buffType[num34] == 78)
							{
								this.meleeEnchant = 7;
							}
							else if (this.buffType[num34] == 79)
							{
								this.meleeEnchant = 8;
							}
						}
					}
					if (this.accMerman && this.wet && !this.lavaWet)
					{
						this.releaseJump = true;
						this.wings = 0;
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
						for (int num63 = 0; num63 < 22; num63++)
						{
							if (this.buffType[num63] > 0 && this.buffTime[num63] <= 0)
							{
								this.DelBuff(num63);
							}
						}
					}
					this.doubleJump = false;
					for (int num64 = 0; num64 < 8; num64++)
					{
						this.statDefense += this.armor[num64].defense;
						this.lifeRegen += this.armor[num64].lifeRegen;
						if (this.armor[num64].type == 268)
						{
							this.accDivingHelm = true;
						}
						if (this.armor[num64].type == 238)
						{
							this.magicDamage += 0.15f;
						}
						if (this.armor[num64].type == 123 || this.armor[num64].type == 124 || this.armor[num64].type == 125)
						{
							this.magicDamage += 0.07f;
						}
						if (this.armor[num64].type == 151 || this.armor[num64].type == 152 || this.armor[num64].type == 153 || this.armor[num64].type == 959)
						{
							this.rangedDamage += 0.05f;
						}
						if (this.armor[num64].type == 111 || this.armor[num64].type == 228 || this.armor[num64].type == 229 || this.armor[num64].type == 230 || this.armor[num64].type == 960 || this.armor[num64].type == 961 || this.armor[num64].type == 962)
						{
							this.statManaMax2 += 20;
						}
						if (this.armor[num64].type == 982)
						{
							this.statManaMax2 += 20;
							this.manaRegenDelayBonus++;
							this.manaRegenBonus += 25;
						}
						if (this.armor[num64].type == 1595)
						{
							this.statManaMax2 += 20;
							this.magicCuffs = true;
						}
						if (this.armor[num64].type == 228 || this.armor[num64].type == 229 || this.armor[num64].type == 230)
						{
							this.magicCrit += 3;
						}
						if (this.armor[num64].type == 100 || this.armor[num64].type == 101 || this.armor[num64].type == 102)
						{
							this.meleeSpeed += 0.07f;
						}
						if (this.armor[num64].type == 956 || this.armor[num64].type == 957 || this.armor[num64].type == 958)
						{
							this.meleeSpeed += 0.07f;
						}
						if (this.armor[num64].type == 791 || this.armor[num64].type == 792 || this.armor[num64].type == 793)
						{
							this.meleeDamage += 0.02f;
							this.rangedDamage += 0.02f;
							this.magicDamage += 0.02f;
						}
						if (this.armor[num64].type == 371)
						{
							this.magicCrit += 9;
							this.statManaMax2 += 40;
						}
						if (this.armor[num64].type == 372)
						{
							this.moveSpeed += 0.07f;
							this.meleeSpeed += 0.12f;
						}
						if (this.armor[num64].type == 373)
						{
							this.rangedDamage += 0.1f;
							this.rangedCrit += 6;
						}
						if (this.armor[num64].type == 374)
						{
							this.magicCrit += 3;
							this.meleeCrit += 3;
							this.rangedCrit += 3;
						}
						if (this.armor[num64].type == 375)
						{
							this.moveSpeed += 0.1f;
						}
						if (this.armor[num64].type == 376)
						{
							this.magicDamage += 0.15f;
							this.statManaMax2 += 60;
						}
						if (this.armor[num64].type == 377)
						{
							this.meleeCrit += 5;
							this.meleeDamage += 0.1f;
						}
						if (this.armor[num64].type == 378)
						{
							this.rangedDamage += 0.12f;
							this.rangedCrit += 7;
						}
						if (this.armor[num64].type == 379)
						{
							this.rangedDamage += 0.05f;
							this.meleeDamage += 0.05f;
							this.magicDamage += 0.05f;
						}
						if (this.armor[num64].type == 380)
						{
							this.magicCrit += 3;
							this.meleeCrit += 3;
							this.rangedCrit += 3;
						}
						if (this.armor[num64].type == 400)
						{
							this.magicDamage += 0.11f;
							this.magicCrit += 11;
							this.statManaMax2 += 80;
						}
						if (this.armor[num64].type == 401)
						{
							this.meleeCrit += 7;
							this.meleeDamage += 0.14f;
						}
						if (this.armor[num64].type == 402)
						{
							this.rangedDamage += 0.14f;
							this.rangedCrit += 8;
						}
						if (this.armor[num64].type == 403)
						{
							this.rangedDamage += 0.06f;
							this.meleeDamage += 0.06f;
							this.magicDamage += 0.06f;
						}
						if (this.armor[num64].type == 404)
						{
							this.magicCrit += 4;
							this.meleeCrit += 4;
							this.rangedCrit += 4;
							this.moveSpeed += 0.05f;
						}
						if (this.armor[num64].type == 1205)
						{
							this.meleeDamage += 0.08f;
							this.meleeSpeed += 0.12f;
						}
						if (this.armor[num64].type == 1206)
						{
							this.rangedDamage += 0.09f;
							this.rangedCrit += 9;
						}
						if (this.armor[num64].type == 1207)
						{
							this.magicDamage += 0.07f;
							this.magicCrit += 7;
							this.statManaMax2 += 60;
						}
						if (this.armor[num64].type == 1208)
						{
							this.meleeDamage += 0.03f;
							this.rangedDamage += 0.03f;
							this.magicDamage += 0.03f;
							this.magicCrit += 2;
							this.meleeCrit += 2;
							this.rangedCrit += 2;
						}
						if (this.armor[num64].type == 1209)
						{
							this.meleeDamage += 0.02f;
							this.rangedDamage += 0.02f;
							this.magicDamage += 0.02f;
							this.magicCrit++;
							this.meleeCrit++;
							this.rangedCrit++;
						}
						if (this.armor[num64].type == 1210)
						{
							this.meleeDamage += 0.07f;
							this.meleeSpeed += 0.07f;
							this.moveSpeed += 0.07f;
						}
						if (this.armor[num64].type == 1211)
						{
							this.rangedCrit += 15;
							this.moveSpeed += 0.08f;
						}
						if (this.armor[num64].type == 1212)
						{
							this.magicCrit += 18;
							this.statManaMax2 += 80;
						}
						if (this.armor[num64].type == 1213)
						{
							this.magicCrit += 6;
							this.meleeCrit += 6;
							this.rangedCrit += 6;
						}
						if (this.armor[num64].type == 1214)
						{
							this.moveSpeed += 0.11f;
						}
						if (this.armor[num64].type == 1215)
						{
							this.meleeDamage += 0.08f;
							this.meleeCrit += 8;
							this.meleeSpeed += 0.08f;
						}
						if (this.armor[num64].type == 1216)
						{
							this.rangedDamage += 0.16f;
							this.rangedCrit += 7;
						}
						if (this.armor[num64].type == 1217)
						{
							this.magicDamage += 0.16f;
							this.magicCrit += 7;
							this.statManaMax2 += 100;
						}
						if (this.armor[num64].type == 1218)
						{
							this.meleeDamage += 0.04f;
							this.rangedDamage += 0.04f;
							this.magicDamage += 0.04f;
							this.magicCrit += 3;
							this.meleeCrit += 3;
							this.rangedCrit += 3;
						}
						if (this.armor[num64].type == 1219)
						{
							this.meleeDamage += 0.03f;
							this.rangedDamage += 0.03f;
							this.magicDamage += 0.03f;
							this.magicCrit += 3;
							this.meleeCrit += 3;
							this.rangedCrit += 3;
							this.moveSpeed += 0.06f;
						}
						if (this.armor[num64].type == 558)
						{
							this.magicDamage += 0.12f;
							this.magicCrit += 12;
							this.statManaMax2 += 100;
						}
						if (this.armor[num64].type == 559)
						{
							this.meleeCrit += 10;
							this.meleeDamage += 0.1f;
							this.meleeSpeed += 0.1f;
						}
						if (this.armor[num64].type == 553)
						{
							this.rangedDamage += 0.15f;
							this.rangedCrit += 8;
						}
						if (this.armor[num64].type == 551)
						{
							this.magicCrit += 7;
							this.meleeCrit += 7;
							this.rangedCrit += 7;
						}
						if (this.armor[num64].type == 552)
						{
							this.rangedDamage += 0.07f;
							this.meleeDamage += 0.07f;
							this.magicDamage += 0.07f;
							this.moveSpeed += 0.08f;
						}
						if (this.armor[num64].type == 1001)
						{
							this.meleeDamage += 0.16f;
							this.meleeCrit += 6;
						}
						if (this.armor[num64].type == 1002)
						{
							this.rangedDamage += 0.16f;
							this.ammoCost80 = true;
						}
						if (this.armor[num64].type == 1003)
						{
							this.statManaMax2 += 80;
							this.manaCost -= 0.17f;
							this.magicDamage += 0.16f;
						}
						if (this.armor[num64].type == 1004)
						{
							this.meleeDamage += 0.05f;
							this.magicDamage += 0.05f;
							this.rangedDamage += 0.05f;
							this.magicCrit += 7;
							this.meleeCrit += 7;
							this.rangedCrit += 7;
						}
						if (this.armor[num64].type == 1005)
						{
							this.magicCrit += 8;
							this.meleeCrit += 8;
							this.rangedCrit += 8;
							this.moveSpeed += 0.05f;
						}
						if (this.armor[num64].type == 1503)
						{
							this.statManaMax2 += 80;
							this.manaCost -= 0.17f;
							this.magicDamage += 0.1f;
							this.magicCrit += 10;
						}
						if (this.armor[num64].type == 1504)
						{
							this.magicDamage += 0.07f;
							this.magicCrit += 7;
						}
						if (this.armor[num64].type == 1505)
						{
							this.magicDamage += 0.08f;
							this.moveSpeed += 0.08f;
						}
						if (this.armor[num64].type == 1546)
						{
							this.rangedCrit += 5;
							this.arrowDamage += 0.15f;
						}
						if (this.armor[num64].type == 1547)
						{
							this.rangedCrit += 5;
							this.bulletDamage += 0.15f;
						}
						if (this.armor[num64].type == 1548)
						{
							this.rangedCrit += 5;
							this.rocketDamage += 0.15f;
						}
						if (this.armor[num64].type == 1549)
						{
							this.rangedCrit += 13;
							this.rangedDamage += 0.13f;
							this.ammoCost80 = true;
						}
						if (this.armor[num64].type == 1550)
						{
							this.rangedCrit += 7;
							this.moveSpeed += 0.12f;
						}
						if (this.armor[num64].type == 1282)
						{
							this.statManaMax2 += 20;
							this.manaCost -= 0.05f;
						}
						if (this.armor[num64].type == 1283)
						{
							this.statManaMax2 += 40;
							this.manaCost -= 0.07f;
						}
						if (this.armor[num64].type == 1284)
						{
							this.statManaMax2 += 40;
							this.manaCost -= 0.09f;
						}
						if (this.armor[num64].type == 1285)
						{
							this.statManaMax2 += 60;
							this.manaCost -= 0.11f;
						}
						if (this.armor[num64].type == 1286)
						{
							this.statManaMax2 += 60;
							this.manaCost -= 0.13f;
						}
						if (this.armor[num64].type == 1287)
						{
							this.statManaMax2 += 80;
							this.manaCost -= 0.15f;
						}
						if (this.armor[num64].type == 1316 || this.armor[num64].type == 1317 || this.armor[num64].type == 1318)
						{
							this.aggro += 250;
						}
						if (this.armor[num64].type == 1316)
						{
							this.meleeDamage += 0.06f;
						}
						if (this.armor[num64].type == 1317)
						{
							this.meleeDamage += 0.08f;
							this.meleeCrit += 8;
						}
						if (this.armor[num64].type == 1318)
						{
							this.meleeCrit += 4;
						}
						if (this.armor[num64].type == 684)
						{
							this.rangedDamage += 0.16f;
							this.meleeDamage += 0.16f;
						}
						if (this.armor[num64].type == 685)
						{
							this.meleeCrit += 11;
							this.rangedCrit += 11;
						}
						if (this.armor[num64].type == 686)
						{
							this.moveSpeed += 0.08f;
							this.meleeSpeed += 0.07f;
						}
						if (this.armor[num64].type >= 1158 && this.armor[num64].type <= 1161)
						{
							this.maxMinions++;
						}
						if (this.armor[num64].type >= 1159 && this.armor[num64].type <= 1161)
						{
							this.minionDamage += 0.1f;
						}
						if (this.armor[num64].type >= 1832 && this.armor[num64].type <= 1834)
						{
							this.maxMinions++;
						}
						if (this.armor[num64].type >= 1832 && this.armor[num64].type <= 1834)
						{
							this.minionDamage += 0.11f;
						}
						if (this.armor[num64].prefix == 62)
						{
							this.statDefense++;
						}
						if (this.armor[num64].prefix == 63)
						{
							this.statDefense += 2;
						}
						if (this.armor[num64].prefix == 64)
						{
							this.statDefense += 3;
						}
						if (this.armor[num64].prefix == 65)
						{
							this.statDefense += 4;
						}
						if (this.armor[num64].prefix == 66)
						{
							this.statManaMax2 += 20;
						}
						if (this.armor[num64].prefix == 67)
						{
							this.meleeCrit += 2;
							this.rangedCrit += 2;
							this.magicCrit += 2;
						}
						if (this.armor[num64].prefix == 68)
						{
							this.meleeCrit += 4;
							this.rangedCrit += 4;
							this.magicCrit += 4;
						}
						if (this.armor[num64].prefix == 69)
						{
							this.meleeDamage += 0.01f;
							this.rangedDamage += 0.01f;
							this.magicDamage += 0.01f;
							this.minionDamage += 0.01f;
						}
						if (this.armor[num64].prefix == 70)
						{
							this.meleeDamage += 0.02f;
							this.rangedDamage += 0.02f;
							this.magicDamage += 0.02f;
							this.minionDamage += 0.02f;
						}
						if (this.armor[num64].prefix == 71)
						{
							this.meleeDamage += 0.03f;
							this.rangedDamage += 0.03f;
							this.magicDamage += 0.03f;
							this.minionDamage += 0.03f;
						}
						if (this.armor[num64].prefix == 72)
						{
							this.meleeDamage += 0.04f;
							this.rangedDamage += 0.04f;
							this.magicDamage += 0.04f;
							this.minionDamage += 0.04f;
						}
						if (this.armor[num64].prefix == 73)
						{
							this.moveSpeed += 0.01f;
						}
						if (this.armor[num64].prefix == 74)
						{
							this.moveSpeed += 0.02f;
						}
						if (this.armor[num64].prefix == 75)
						{
							this.moveSpeed += 0.03f;
						}
						if (this.armor[num64].prefix == 76)
						{
							this.moveSpeed += 0.04f;
						}
						if (this.armor[num64].prefix == 77)
						{
							this.meleeSpeed += 0.01f;
						}
						if (this.armor[num64].prefix == 78)
						{
							this.meleeSpeed += 0.02f;
						}
						if (this.armor[num64].prefix == 79)
						{
							this.meleeSpeed += 0.03f;
						}
						if (this.armor[num64].prefix == 80)
						{
							this.meleeSpeed += 0.04f;
						}
					}
					this.head = this.armor[0].headSlot;
					this.body = this.armor[1].bodySlot;
					this.legs = this.armor[2].legSlot;
					for (int num65 = 3; num65 < 8; num65++)
					{
						if (this.armor[num65].type == 15 && this.accWatch < 1)
						{
							this.accWatch = 1;
						}
						if (this.armor[num65].type == 16 && this.accWatch < 2)
						{
							this.accWatch = 2;
						}
						if (this.armor[num65].type == 17 && this.accWatch < 3)
						{
							this.accWatch = 3;
						}
						if (this.armor[num65].type == 707 && this.accWatch < 1)
						{
							this.accWatch = 1;
						}
						if (this.armor[num65].type == 708 && this.accWatch < 2)
						{
							this.accWatch = 2;
						}
						if (this.armor[num65].type == 709 && this.accWatch < 3)
						{
							this.accWatch = 3;
						}
						if (this.armor[num65].type == 18 && this.accDepthMeter < 1)
						{
							this.accDepthMeter = 1;
						}
						if (this.armor[num65].type == 857)
						{
							this.doubleJump2 = true;
						}
						if (this.armor[num65].type == 983)
						{
							this.doubleJump2 = true;
							this.jumpBoost = true;
						}
						if (this.armor[num65].type == 987)
						{
							this.doubleJump3 = true;
						}
						if (this.armor[num65].type == 1163)
						{
							this.doubleJump3 = true;
							this.jumpBoost = true;
						}
						if (this.armor[num65].type == 1724)
						{
							this.doubleJump4 = true;
						}
						if (this.armor[num65].type == 1863)
						{
							this.doubleJump4 = true;
							this.jumpBoost = true;
						}
						if (this.armor[num65].type == 1164)
						{
							this.doubleJump = true;
							this.doubleJump2 = true;
							this.doubleJump3 = true;
							this.jumpBoost = true;
						}
						if (this.armor[num65].type == 1250)
						{
							this.jumpBoost = true;
							this.doubleJump = true;
							this.noFallDmg = true;
						}
						if (this.armor[num65].type == 1252)
						{
							this.doubleJump2 = true;
							this.jumpBoost = true;
							this.noFallDmg = true;
						}
						if (this.armor[num65].type == 1251)
						{
							this.doubleJump3 = true;
							this.jumpBoost = true;
							this.noFallDmg = true;
						}
						if (this.armor[num65].type == 1249)
						{
							this.jumpBoost = true;
							this.bee = true;
						}
						if (this.armor[num65].type == 1253 && (double)this.statLife <= (double)this.statLifeMax * 0.25)
						{
							this.AddBuff(62, 5, true);
						}
						if (this.armor[num65].type == 1290)
						{
							this.panic = true;
						}
						if ((this.armor[num65].type == 1300 || this.armor[num65].type == 1858) && (this.inventory[this.selectedItem].useAmmo == 14 || this.inventory[this.selectedItem].useAmmo == 311 || this.inventory[this.selectedItem].useAmmo == 323))
						{
							this.scope = true;
						}
						if (this.armor[num65].type == 1858)
						{
							this.rangedCrit += 10;
							this.rangedDamage += 0.1f;
						}
						if (this.armor[num65].type == 1301)
						{
							this.meleeCrit += 8;
							this.rangedCrit += 8;
							this.magicCrit += 8;
							this.meleeDamage += 0.1f;
							this.rangedDamage += 0.1f;
							this.magicDamage += 0.1f;
							this.minionDamage += 0.1f;
						}
						if (this.armor[num65].type == 1923)
						{
							Player.tileRangeX++;
							Player.tileRangeY++;
						}
						if (this.armor[num65].type == 1247)
						{
							this.starCloak = true;
							this.bee = true;
						}
						if (this.armor[num65].type == 1248)
						{
							this.meleeCrit += 10;
							this.rangedCrit += 10;
							this.magicCrit += 10;
						}
						if (this.armor[num65].type == 854)
						{
							this.discount = true;
						}
						if (this.armor[num65].type == 855)
						{
							this.coins = true;
						}
						if (this.armor[num65].type == 53)
						{
							this.doubleJump = true;
						}
						if (this.armor[num65].type == 54)
						{
							num6 = 6f;
						}
						if (this.armor[num65].type == 1579)
						{
							num6 = 6f;
							this.coldDash = true;
						}
						if (this.armor[num65].type == 128)
						{
							this.rocketBoots = 1;
						}
						if (this.armor[num65].type == 156)
						{
							this.noKnockback = true;
						}
						if (this.armor[num65].type == 158)
						{
							this.noFallDmg = true;
						}
						if (this.armor[num65].type == 934)
						{
							this.carpet = true;
						}
						if (this.armor[num65].type == 953)
						{
							this.spikedBoots++;
						}
						if (this.armor[num65].type == 975)
						{
							this.spikedBoots++;
						}
						if (this.armor[num65].type == 976)
						{
							this.spikedBoots += 2;
						}
						if (this.armor[num65].type == 977)
						{
							this.dash = 1;
						}
						if (this.armor[num65].type == 963)
						{
							this.blackBelt = true;
						}
						if (this.armor[num65].type == 984)
						{
							this.blackBelt = true;
							this.dash = 1;
							this.spikedBoots = 2;
						}
						if (this.armor[num65].type == 1131)
						{
							this.gravControl2 = true;
						}
						if (this.armor[num65].type == 1132)
						{
							this.bee = true;
						}
						if (this.armor[num65].type == 1578)
						{
							this.bee = true;
							this.panic = true;
						}
						if (this.armor[num65].type == 950)
						{
							this.iceSkate = true;
						}
						if (this.armor[num65].type == 159)
						{
							this.jumpBoost = true;
						}
						if (this.armor[num65].type == 187)
						{
							this.accFlipper = true;
						}
						if (this.armor[num65].type == 211)
						{
							this.meleeSpeed += 0.12f;
						}
						if (this.armor[num65].type == 223)
						{
							this.manaCost -= 0.06f;
						}
						if (this.armor[num65].type == 285)
						{
							this.moveSpeed += 0.05f;
						}
						if (this.armor[num65].type == 212)
						{
							this.moveSpeed += 0.1f;
						}
						if (this.armor[num65].type == 267)
						{
							this.killGuide = true;
						}
						if (this.armor[num65].type == 1307)
						{
							this.killClothier = true;
						}
						if (this.armor[num65].type == 193)
						{
							this.fireWalk = true;
						}
						if (this.armor[num65].type == 861)
						{
							this.accMerman = true;
							this.wolfAcc = true;
						}
						if (this.armor[num65].type == 862)
						{
							this.starCloak = true;
							this.longInvince = true;
						}
						if (this.armor[num65].type == 860)
						{
							this.pStone = true;
						}
						if (this.armor[num65].type == 863)
						{
							this.waterWalk2 = true;
						}
						if (this.armor[num65].type == 907)
						{
							this.waterWalk2 = true;
							this.fireWalk = true;
						}
						if (this.armor[num65].type == 908)
						{
							this.waterWalk = true;
							this.fireWalk = true;
							this.lavaMax += 420;
						}
						if (this.armor[num65].type == 906)
						{
							this.lavaMax += 420;
						}
						if (this.armor[num65].type == 485)
						{
							this.wolfAcc = true;
						}
						if (this.armor[num65].type == 486)
						{
							this.rulerAcc = true;
						}
						if (this.armor[num65].type == 393)
						{
							this.accCompass = 1;
						}
						if (this.armor[num65].type == 394)
						{
							this.accFlipper = true;
							this.accDivingHelm = true;
						}
						if (this.armor[num65].type == 395)
						{
							this.accWatch = 3;
							this.accDepthMeter = 1;
							this.accCompass = 1;
						}
						if (this.armor[num65].type == 396)
						{
							this.noFallDmg = true;
							this.fireWalk = true;
						}
						if (this.armor[num65].type == 397)
						{
							this.noKnockback = true;
							this.fireWalk = true;
						}
						if (this.armor[num65].type == 399)
						{
							this.jumpBoost = true;
							this.doubleJump = true;
						}
						if (this.armor[num65].type == 405)
						{
							num6 = 6f;
							this.rocketBoots = 2;
						}
						if (this.armor[num65].type == 1860)
						{
							this.accFlipper = true;
							this.accDivingHelm = true;
						}
						if (this.armor[num65].type == 1861)
						{
							this.accFlipper = true;
							this.accDivingHelm = true;
							this.iceSkate = true;
						}
						if (this.armor[num65].type == 897)
						{
							this.kbGlove = true;
							this.meleeSpeed += 0.12f;
						}
						if (this.armor[num65].type == 1343)
						{
							this.kbGlove = true;
							this.meleeSpeed += 0.09f;
							this.meleeDamage += 0.09f;
							this.magmaStone = true;
						}
						if (this.armor[num65].type == 1167)
						{
							this.minionKB += 2f;
							this.minionDamage += 0.15f;
						}
						if (this.armor[num65].type == 1864)
						{
							this.minionKB += 2f;
							this.minionDamage += 0.15f;
							this.maxMinions++;
						}
						if (this.armor[num65].type == 1845)
						{
							this.minionDamage += 0.1f;
							this.maxMinions++;
						}
						if (this.armor[num65].type == 1321)
						{
							this.magicQuiver = true;
							this.arrowDamage += 0.1f;
						}
						if (this.armor[num65].type == 1322)
						{
							this.magmaStone = true;
						}
						if (this.armor[num65].type == 1323)
						{
							this.lavaRose = true;
						}
						if (this.armor[num65].type == 938)
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
										float num66 = this.position.X - Main.player[myPlayer].position.X;
										float num67 = this.position.Y - Main.player[myPlayer].position.Y;
										float num68 = (float)Math.Sqrt((double)(num66 * num66 + num67 * num67));
										if (num68 < 800f)
										{
											Main.player[myPlayer].AddBuff(43, 10, true);
										}
									}
								}
							}
						}
						if (this.armor[num65].type == 936)
						{
							this.kbGlove = true;
							this.meleeSpeed += 0.12f;
							this.magicDamage += 0.12f;
							this.meleeDamage += 0.12f;
							this.rangedDamage += 0.12f;
						}
						if (this.armor[num65].type == 898)
						{
							num6 = 6.75f;
							this.rocketBoots = 2;
							this.moveSpeed += 0.08f;
						}
						if (this.armor[num65].type == 1862)
						{
							num6 = 6.75f;
							this.rocketBoots = 3;
							this.moveSpeed += 0.08f;
							this.iceSkate = true;
						}
						if (this.armor[num65].type == 1865)
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
						if (this.armor[num65].type == 899 && Main.dayTime)
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
						if (this.armor[num65].type == 900 && !Main.dayTime)
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
						if (this.armor[num65].type == 407)
						{
							this.blockRange = 1;
						}
						if (this.armor[num65].type == 489)
						{
							this.magicDamage += 0.15f;
						}
						if (this.armor[num65].type == 490)
						{
							this.meleeDamage += 0.15f;
						}
						if (this.armor[num65].type == 491)
						{
							this.rangedDamage += 0.15f;
						}
						if (this.armor[num65].type == 935)
						{
							this.magicDamage += 0.12f;
							this.meleeDamage += 0.12f;
							this.rangedDamage += 0.12f;
							this.minionDamage += 0.12f;
						}
						if (this.armor[num65].type == 492)
						{
							this.wings = 1;
						}
						if (this.armor[num65].type == 493)
						{
							this.wings = 2;
						}
						if (this.armor[num65].type == 665)
						{
							this.wings = 3;
						}
						if (this.armor[num65].type == 748)
						{
							this.wings = 4;
						}
						if (this.armor[num65].type == 749)
						{
							this.wings = 5;
						}
						if (this.armor[num65].type == 761)
						{
							this.wings = 6;
						}
						if (this.armor[num65].type == 785)
						{
							this.wings = 7;
						}
						if (this.armor[num65].type == 786)
						{
							this.wings = 8;
						}
						if (this.armor[num65].type == 821)
						{
							this.wings = 9;
						}
						if (this.armor[num65].type == 822)
						{
							this.wings = 10;
						}
						if (this.armor[num65].type == 823)
						{
							this.wings = 11;
						}
						if (this.armor[num65].type == 948)
						{
							this.wings = 12;
						}
						if (this.armor[num65].type == 1162)
						{
							this.wings = 13;
						}
						if (this.armor[num65].type == 1165)
						{
							this.wings = 14;
						}
						if (this.armor[num65].type == 1515)
						{
							this.wings = 15;
						}
						if (this.armor[num65].type == 1583)
						{
							this.wings = 16;
						}
						if (this.armor[num65].type == 1584)
						{
							this.wings = 17;
						}
						if (this.armor[num65].type == 1585)
						{
							this.wings = 18;
						}
						if (this.armor[num65].type == 1586)
						{
							this.wings = 19;
						}
						if (this.armor[num65].type == 1797)
						{
							this.wings = 20;
						}
						if (this.armor[num65].type == 1830)
						{
							this.wings = 21;
						}
						if (this.armor[num65].type == 1866)
						{
							this.wings = 22;
						}
						if (this.armor[num65].type == 1871)
						{
							this.wings = 23;
						}
						if (this.armor[num65].type == 885)
						{
							this.buffImmune[30] = true;
						}
						if (this.armor[num65].type == 886)
						{
							this.buffImmune[36] = true;
						}
						if (this.armor[num65].type == 887)
						{
							this.buffImmune[20] = true;
						}
						if (this.armor[num65].type == 888)
						{
							this.buffImmune[22] = true;
						}
						if (this.armor[num65].type == 889)
						{
							this.buffImmune[32] = true;
						}
						if (this.armor[num65].type == 890)
						{
							this.buffImmune[35] = true;
						}
						if (this.armor[num65].type == 891)
						{
							this.buffImmune[23] = true;
						}
						if (this.armor[num65].type == 892)
						{
							this.buffImmune[33] = true;
						}
						if (this.armor[num65].type == 893)
						{
							this.buffImmune[31] = true;
						}
						if (this.armor[num65].type == 901)
						{
							this.buffImmune[33] = true;
							this.buffImmune[36] = true;
						}
						if (this.armor[num65].type == 902)
						{
							this.buffImmune[30] = true;
							this.buffImmune[20] = true;
						}
						if (this.armor[num65].type == 903)
						{
							this.buffImmune[32] = true;
							this.buffImmune[31] = true;
						}
						if (this.armor[num65].type == 904)
						{
							this.buffImmune[35] = true;
							this.buffImmune[23] = true;
						}
						if (this.armor[num65].type == 1921)
						{
							this.buffImmune[46] = true;
							this.buffImmune[47] = true;
						}
						if (this.armor[num65].type == 1612)
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
						if (this.armor[num65].type == 1613)
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
						if (this.armor[num65].type == 497)
						{
							this.accMerman = true;
						}
						if (this.armor[num65].type == 535)
						{
							this.pStone = true;
						}
						if (this.armor[num65].type == 536)
						{
							this.kbGlove = true;
						}
						if (this.armor[num65].type == 532)
						{
							this.starCloak = true;
						}
						if (this.armor[num65].type == 554)
						{
							this.longInvince = true;
						}
						if (this.armor[num65].type == 555)
						{
							this.manaFlower = true;
							this.manaCost -= 0.08f;
						}
						if (Main.myPlayer == this.whoAmi)
						{
							if (this.armor[num65].type == 576)
							{
								Main.rand.Next(18000);
								if (Main.curMusic > 0 && Main.curMusic <= 32)
								{
									int num69 = 0;
									if (Main.curMusic == 1)
									{
										num69 = 0;
									}
									if (Main.curMusic == 2)
									{
										num69 = 1;
									}
									if (Main.curMusic == 3)
									{
										num69 = 2;
									}
									if (Main.curMusic == 4)
									{
										num69 = 4;
									}
									if (Main.curMusic == 5)
									{
										num69 = 5;
									}
									if (Main.curMusic == 7)
									{
										num69 = 6;
									}
									if (Main.curMusic == 8)
									{
										num69 = 7;
									}
									if (Main.curMusic == 9)
									{
										num69 = 9;
									}
									if (Main.curMusic == 10)
									{
										num69 = 8;
									}
									if (Main.curMusic == 11)
									{
										num69 = 11;
									}
									if (Main.curMusic == 12)
									{
										num69 = 10;
									}
									if (Main.curMusic == 13)
									{
										num69 = 12;
									}
									if (Main.curMusic == 29)
									{
										this.armor[num65].SetDefaults(1610, false);
									}
									else if (Main.curMusic == 30)
									{
										this.armor[num65].SetDefaults(1963, false);
									}
									else if (Main.curMusic == 31)
									{
										this.armor[num65].SetDefaults(1964, false);
									}
									else if (Main.curMusic == 32)
									{
										this.armor[num65].SetDefaults(1965, false);
									}
									else if (Main.curMusic > 13)
									{
										this.armor[num65].SetDefaults(1596 + Main.curMusic - 14, false);
									}
									else
									{
										this.armor[num65].SetDefaults(num69 + 562, false);
									}
								}
							}
							if (this.armor[num65].type >= 562 && this.armor[num65].type <= 574)
							{
								Main.musicBox2 = this.armor[num65].type - 562;
							}
							if (this.armor[num65].type >= 1596 && this.armor[num65].type <= 1609)
							{
								Main.musicBox2 = this.armor[num65].type - 1596 + 13;
							}
							if (this.armor[num65].type == 1610)
							{
								Main.musicBox2 = 27;
							}
							if (this.armor[num65].type == 1963)
							{
								Main.musicBox2 = 28;
							}
							if (this.armor[num65].type == 1964)
							{
								Main.musicBox2 = 29;
							}
							if (this.armor[num65].type == 1965)
							{
								Main.musicBox2 = 30;
							}
						}
					}
					this.gemCount++;
					if (this.gemCount >= 10)
					{
						this.gem = -1;
						this.gemCount = 0;
						for (int num70 = 0; num70 <= 58; num70++)
						{
							if (this.inventory[num70].type == 0 || this.inventory[num70].stack == 0)
							{
								this.inventory[num70].type = 0;
								this.inventory[num70].stack = 0;
								this.inventory[num70].name = "";
								this.inventory[num70].netID = 0;
							}
							if (this.inventory[num70].type >= 1522 && this.inventory[num70].type <= 1527)
							{
								this.gem = this.inventory[num70].type - 1522;
							}
						}
					}
					if (this.head == 11)
					{
						int i2 = (int)(this.position.X + (float)(this.width / 2) + (float)(8 * this.direction)) / 16;
						int j2 = (int)(this.position.Y + 2f) / 16;
					}
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
					if (this.head == 14 && this.body >= 58 && this.body <= 63)
					{
						this.setBonus = Lang.setBonus(28, false);
						this.magicCrit += 10;
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
					if (this.head == 8 && this.body == 8 && this.legs == 8)
					{
						this.setBonus = Lang.setBonus(5, false);
						this.manaCost -= 0.16f;
					}
					if (this.head == 76 && this.body == 49 && this.legs == 45)
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
						for (int num71 = 0; num71 < 22; num71++)
						{
							if (this.buffType[num71] == 60)
							{
								this.DelBuff(num71);
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
					if (this.merman)
					{
						this.wings = 0;
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
							float num72 = Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y);
							this.stealth += num72 * 0.0075f;
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
					if ((double)this.pickSpeed < 0.3)
					{
						this.pickSpeed = 0.3f;
					}
					if (this.meleeSpeed > 4f)
					{
						this.meleeSpeed = 4f;
					}
					if ((double)this.moveSpeed > 1.6)
					{
						this.moveSpeed = 1.6f;
					}
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
						this.lifeRegen += 2;
					}
					if (this.whoAmi == Main.myPlayer && Main.heartLantern)
					{
						this.lifeRegen += 4;
					}
					if (this.bleed)
					{
						this.lifeRegenTime = 0;
					}
					float num73 = 0f;
					if (this.lifeRegenTime >= 300)
					{
						num73 += 1f;
					}
					if (this.lifeRegenTime >= 600)
					{
						num73 += 1f;
					}
					if (this.lifeRegenTime >= 900)
					{
						num73 += 1f;
					}
					if (this.lifeRegenTime >= 1200)
					{
						num73 += 1f;
					}
					if (this.lifeRegenTime >= 1500)
					{
						num73 += 1f;
					}
					if (this.lifeRegenTime >= 1800)
					{
						num73 += 1f;
					}
					if (this.lifeRegenTime >= 2400)
					{
						num73 += 1f;
					}
					if (this.lifeRegenTime >= 3000)
					{
						num73 += 1f;
					}
					if (this.lifeRegenTime >= 3600)
					{
						num73 += 1f;
						this.lifeRegenTime = 3600;
					}
					if (this.velocity.X == 0f || this.grappling[0] > 0)
					{
						num73 *= 1.25f;
					}
					else
					{
						num73 *= 0.5f;
					}
					if (this.crimsonRegen)
					{
						num73 *= 1.5f;
					}
					if (this.whoAmi == Main.myPlayer && Main.campfire)
					{
						num73 *= 1.1f;
					}
					float num74 = (float)this.statLifeMax / 400f * 0.85f + 0.15f;
					num73 *= num74;
					this.lifeRegen += (int)Math.Round((double)num73);
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
								for (int num75 = 0; num75 < 10; num75++)
								{
									int num76 = Dust.NewDust(this.position, this.width, this.height, 5, 0f, 0f, 175, default(Color), 1.75f);
									Main.dust[num76].noGravity = true;
									Main.dust[num76].velocity *= 0.75f;
									int num77 = Main.rand.Next(-40, 41);
									int num78 = Main.rand.Next(-40, 41);
									Dust expr_8BA6_cp_0 = Main.dust[num76];
									expr_8BA6_cp_0.position.X = expr_8BA6_cp_0.position.X + (float)num77;
									Dust expr_8BC2_cp_0 = Main.dust[num76];
									expr_8BC2_cp_0.position.Y = expr_8BC2_cp_0.position.Y + (float)num78;
									Main.dust[num76].velocity.X = (float)(-(float)num77) * 0.075f;
									Main.dust[num76].velocity.Y = (float)(-(float)num78) * 0.075f;
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
									CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(255, 60, 70, 255), string.Concat(4), false, true);
								}
								else if (this.lifeRegenCount <= -360)
								{
									this.lifeRegenCount += 360;
									this.statLife -= 3;
									CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(255, 60, 70, 255), string.Concat(3), false, true);
								}
								else if (this.lifeRegenCount <= -240)
								{
									this.lifeRegenCount += 240;
									this.statLife -= 2;
									CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(255, 60, 70, 255), string.Concat(2), false, true);
								}
								else
								{
									this.lifeRegenCount += 120;
									this.statLife--;
									CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(255, 60, 70, 255), string.Concat(1), false, true);
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
							goto IL_8FA2;
						}
					}
					while (this.lifeRegenCount <= -600)
					{
						this.lifeRegenCount += 600;
						this.statLife -= 5;
						CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(255, 60, 70, 255), string.Concat(5), false, true);
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
					IL_8FA2:
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
						float num79 = (float)this.statMana / (float)this.statManaMax2 * 0.8f + 0.2f;
						if (this.manaRegenBuff)
						{
							num79 = 1f;
						}
						this.manaRegen = (int)((float)this.manaRegen * num79);
					}
					else
					{
						this.manaRegen = 0;
					}
					this.manaRegenCount += this.manaRegen;
					while (this.manaRegenCount >= 120)
					{
						bool flag33 = false;
						this.manaRegenCount -= 120;
						if (this.statMana < this.statManaMax2)
						{
							this.statMana++;
							flag33 = true;
						}
						if (this.statMana >= this.statManaMax2)
						{
							if (this.whoAmi == Main.myPlayer && flag33)
							{
								Main.PlaySound(25, -1, -1, 1);
								for (int num80 = 0; num80 < 5; num80++)
								{
									int num81 = Dust.NewDust(this.position, this.width, this.height, 45, 0f, 0f, 255, default(Color), (float)Main.rand.Next(20, 26) * 0.1f);
									Main.dust[num81].noLight = true;
									Main.dust[num81].noGravity = true;
									Main.dust[num81].velocity *= 0.5f;
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
					for (int num82 = 0; num82 < 22; num82++)
					{
						if (this.buffType[num82] > 0 && this.buffTime[num82] > 0 && this.buffImmune[this.buffType[num82]])
						{
							this.DelBuff(num82);
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
						int num83 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num84 = (int)(this.position.Y - 8f) / 16;
						if (Main.tile[num83, num84].active() && Main.tileRope[(int)Main.tile[num83, num84].type])
						{
							float num85 = this.position.Y;
							if (Main.tile[num83, num84 - 1] == null)
							{
								Main.tile[num83, num84 - 1] = new Tile();
							}
							if (Main.tile[num83, num84 + 1] == null)
							{
								Main.tile[num83, num84 + 1] = new Tile();
							}
							if ((!Main.tile[num83, num84 - 1].active() || !Main.tileRope[(int)Main.tile[num83, num84 - 1].type]) && (!Main.tile[num83, num84 + 1].active() || !Main.tileRope[(int)Main.tile[num83, num84 + 1].type]))
							{
								num85 = (float)(num84 * 16 + 22);
							}
							float num86 = (float)(num83 * 16 + 8 - this.width / 2 + 6 * this.direction);
							int num87 = num83 * 16 + 8 - this.width / 2 + 6;
							int num88 = num83 * 16 + 8 - this.width / 2;
							int num89 = num83 * 16 + 8 - this.width / 2 + -6;
							int num90 = 1;
							float num91 = Math.Abs(this.position.X - (float)num87);
							if (Math.Abs(this.position.X - (float)num88) < num91)
							{
								num90 = 2;
								num91 = Math.Abs(this.position.X - (float)num88);
							}
							if (Math.Abs(this.position.X - (float)num89) < num91)
							{
								num90 = 3;
								num91 = Math.Abs(this.position.X - (float)num89);
							}
							if (num90 == 1)
							{
								num86 = (float)num87;
								this.pulleyDir = 2;
								this.direction = 1;
							}
							if (num90 == 2)
							{
								num86 = (float)num88;
								this.pulleyDir = 1;
							}
							if (num90 == 3)
							{
								num86 = (float)num89;
								this.pulleyDir = 2;
								this.direction = -1;
							}
							if (!Collision.SolidCollision(new Vector2(num86, this.position.Y), this.width, this.height))
							{
								if (i == Main.myPlayer)
								{
									Main.cameraX = Main.cameraX + this.position.X - num86;
								}
								this.pulley = true;
								this.position.X = num86;
								this.gfxOffY = this.position.Y - num85;
								this.stepSpeed = 2.5f;
								this.position.Y = num85;
								this.velocity.X = 0f;
							}
							else
							{
								num86 = (float)num87;
								this.pulleyDir = 2;
								this.direction = 1;
								if (!Collision.SolidCollision(new Vector2(num86, this.position.Y), this.width, this.height))
								{
									if (i == Main.myPlayer)
									{
										Main.cameraX = Main.cameraX + this.position.X - num86;
									}
									this.pulley = true;
									this.position.X = num86;
									this.gfxOffY = this.position.Y - num85;
									this.stepSpeed = 2.5f;
									this.position.Y = num85;
									this.velocity.X = 0f;
								}
								else
								{
									num86 = (float)num89;
									this.pulleyDir = 2;
									this.direction = -1;
									if (!Collision.SolidCollision(new Vector2(num86, this.position.Y), this.width, this.height))
									{
										if (i == Main.myPlayer)
										{
											Main.cameraX = Main.cameraX + this.position.X - num86;
										}
										this.pulley = true;
										this.position.X = num86;
										this.gfxOffY = this.position.Y - num85;
										this.stepSpeed = 2.5f;
										this.position.Y = num85;
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
						int num92 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num93 = (int)(this.position.Y - 8f) / 16;
						bool flag34 = false;
						if (this.pulleyDir == 0)
						{
							this.pulleyDir = 1;
						}
						if (this.pulleyDir == 1)
						{
							if (this.direction == -1 && this.controlLeft && (this.releaseLeft || this.leftTimer == 0))
							{
								this.pulleyDir = 2;
								flag34 = true;
							}
							else if ((this.direction == 1 && this.controlRight && this.releaseRight) || this.rightTimer == 0)
							{
								this.pulleyDir = 2;
								flag34 = true;
							}
							else
							{
								if (this.direction == 1 && this.controlLeft)
								{
									this.direction = -1;
									flag34 = true;
								}
								if (this.direction == -1 && this.controlRight)
								{
									this.direction = 1;
									flag34 = true;
								}
							}
						}
						else if (this.pulleyDir == 2)
						{
							if (this.direction == 1 && this.controlLeft)
							{
								flag34 = true;
								int num94 = num92 * 16 + 8 - this.width / 2;
								if (!Collision.SolidCollision(new Vector2((float)num94, this.position.Y), this.width, this.height))
								{
									this.pulleyDir = 1;
									this.direction = -1;
									flag34 = true;
								}
							}
							if (this.direction == -1 && this.controlRight)
							{
								flag34 = true;
								int num95 = num92 * 16 + 8 - this.width / 2;
								if (!Collision.SolidCollision(new Vector2((float)num95, this.position.Y), this.width, this.height))
								{
									this.pulleyDir = 1;
									this.direction = 1;
									flag34 = true;
								}
							}
						}
						bool flag35 = false;
						if (!flag34 && ((this.controlLeft && (this.releaseLeft || this.leftTimer == 0)) || (this.controlRight && (this.releaseRight || this.rightTimer == 0))))
						{
							int num96 = 1;
							if (this.controlLeft)
							{
								num96 = -1;
							}
							int num97 = num92 + num96;
							if (Main.tile[num97, num93].active() && Main.tileRope[(int)Main.tile[num97, num93].type])
							{
								this.pulleyDir = 1;
								this.direction = num96;
								int num98 = num97 * 16 + 8 - this.width / 2;
								float num99 = this.position.Y;
								num99 = (float)(num93 * 16 + 22);
								if ((!Main.tile[num97, num93 - 1].active() || !Main.tileRope[(int)Main.tile[num97, num93 - 1].type]) && (!Main.tile[num97, num93 + 1].active() || !Main.tileRope[(int)Main.tile[num97, num93 + 1].type]))
								{
									num99 = (float)(num93 * 16 + 22);
								}
								if (Collision.SolidCollision(new Vector2((float)num98, num99), this.width, this.height))
								{
									this.pulleyDir = 2;
									this.direction = -num96;
									if (this.direction == 1)
									{
										num98 = num97 * 16 + 8 - this.width / 2 + 6;
									}
									else
									{
										num98 = num97 * 16 + 8 - this.width / 2 + -6;
									}
								}
								if (i == Main.myPlayer)
								{
									Main.cameraX = Main.cameraX + this.position.X - (float)num98;
								}
								this.position.X = (float)num98;
								this.gfxOffY = this.position.Y - num99;
								this.position.Y = num99;
								flag35 = true;
							}
						}
						if (!flag35 && !flag34 && !this.controlUp && ((this.controlLeft && this.releaseLeft) || (this.controlRight && this.releaseRight)))
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
						if (Main.tile[num92, num93] == null)
						{
							Main.tile[num92, num93] = new Tile();
						}
						if (!Main.tile[num92, num93].active() || !Main.tileRope[(int)Main.tile[num92, num93].type])
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
						int num100 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num101 = (int)(this.position.Y - 16f) / 16;
						int num102 = (int)(this.position.Y - 8f) / 16;
						bool flag36 = true;
						bool flag37 = false;
						if ((Main.tile[num100, num102 - 1].active() && Main.tileRope[(int)Main.tile[num100, num102 - 1].type]) || (Main.tile[num100, num102 + 1].active() && Main.tileRope[(int)Main.tile[num100, num102 + 1].type]))
						{
							flag37 = true;
						}
						if (Main.tile[num100, num101] == null)
						{
							Main.tile[num100, num101] = new Tile();
						}
						if (!Main.tile[num100, num101].active() || !Main.tileRope[(int)Main.tile[num100, num101].type])
						{
							flag36 = false;
							if (this.velocity.Y < 0f)
							{
								this.velocity.Y = 0f;
							}
						}
						if (flag37)
						{
							if (this.controlUp && flag36)
							{
								float num103 = this.position.X;
								float y = this.position.Y - Math.Abs(this.velocity.Y) - 2f;
								if (Collision.SolidCollision(new Vector2(num103, y), this.width, this.height))
								{
									num103 = (float)(num100 * 16 + 8 - this.width / 2 + 6);
									if (!Collision.SolidCollision(new Vector2(num103, y), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
									{
										if (i == Main.myPlayer)
										{
											Main.cameraX = Main.cameraX + this.position.X - num103;
										}
										this.pulleyDir = 2;
										this.direction = 1;
										this.position.X = num103;
										this.velocity.X = 0f;
									}
									else
									{
										num103 = (float)(num100 * 16 + 8 - this.width / 2 + -6);
										if (!Collision.SolidCollision(new Vector2(num103, y), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
										{
											if (i == Main.myPlayer)
											{
												Main.cameraX = Main.cameraX + this.position.X - num103;
											}
											this.pulleyDir = 2;
											this.direction = -1;
											this.position.X = num103;
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
								float num104 = this.position.X;
								float y2 = this.position.Y;
								if (Collision.SolidCollision(new Vector2(num104, y2), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
								{
									num104 = (float)(num100 * 16 + 8 - this.width / 2 + 6);
									if (!Collision.SolidCollision(new Vector2(num104, y2), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
									{
										if (i == Main.myPlayer)
										{
											Main.cameraX = Main.cameraX + this.position.X - num104;
										}
										this.pulleyDir = 2;
										this.direction = 1;
										this.position.X = num104;
										this.velocity.X = 0f;
									}
									else
									{
										num104 = (float)(num100 * 16 + 8 - this.width / 2 + -6);
										if (!Collision.SolidCollision(new Vector2(num104, y2), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
										{
											if (i == Main.myPlayer)
											{
												Main.cameraX = Main.cameraX + this.position.X - num104;
											}
											this.pulleyDir = 2;
											this.direction = -1;
											this.position.X = num104;
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
							this.position.Y = (float)(num101 * 16 + 22);
						}
						float num105 = (float)(num100 * 16 + 8 - this.width / 2);
						if (this.pulleyDir == 1)
						{
							num105 = (float)(num100 * 16 + 8 - this.width / 2);
						}
						if (this.pulleyDir == 2)
						{
							num105 = (float)(num100 * 16 + 8 - this.width / 2 + 6 * this.direction);
						}
						if (i == Main.myPlayer)
						{
							Main.cameraX = Main.cameraX + this.position.X - num105;
						}
						this.position.X = num105;
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
						this.wingTime = (float)this.GetWingTime();
						this.rocketTime = this.rocketTimeMax;
						this.rocketDelay = 0;
						this.rocketFrame = false;
						this.canRocket = false;
						this.rocketRelease = false;
					}
					else if (this.grappling[0] == -1 && !this.tongued)
					{
						if (this.wings == 3 && this.velocity.Y == 0f)
						{
							num6 = 8.5f;
						}
						if (this.wings == 3 && Main.myPlayer == this.whoAmi)
						{
							num6 = 0f;
						}
						if (this.wings > 0 && this.velocity.Y != 0f)
						{
							if (this.wings == 1 || this.wings == 2)
							{
								num6 = 6.25f;
							}
							if (this.wings == 4)
							{
								num6 = 6.5f;
							}
							if (this.wings == 5 || this.wings == 6 || this.wings == 13 || this.wings == 15)
							{
								num6 = 6.75f;
							}
							if (this.wings == 7 || this.wings == 8)
							{
								num6 = 7f;
							}
							if (this.wings == 9 || this.wings == 10 || this.wings == 11 || this.wings == 20 || this.wings == 21 || this.wings == 23)
							{
								num6 = 7.5f;
							}
							if (this.wings == 22)
							{
								if (this.controlDown && this.controlJump && this.wingTime > 0f)
								{
									num6 = 10f;
									num4 *= 10f;
								}
								else
								{
									num6 = 6.25f;
								}
							}
							if (this.wings == 12)
							{
								num6 = 7.75f;
							}
							if (this.wings == 16 || this.wings == 17 || this.wings == 18 || this.wings == 19)
							{
								num6 = 7.9f;
							}
							if (this.wings == 3)
							{
								num6 = 11f;
								num4 *= 3f;
							}
						}
						if (Main.myPlayer == this.whoAmi && (this.wings == 3 || this.wings == 16 || this.wings == 17 || this.wings == 18 || this.wings == 19))
						{
							num6 = 0f;
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
							num6 = num3;
							if (this.mount == 1)
							{
								num3 = 5.5f;
								num6 = 12f;
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
						else if (this.controlLeft && this.velocity.X > -num6 && this.dashDelay >= 0)
						{
							if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
							{
								this.direction = -1;
							}
							if (this.velocity.Y == 0f || this.wings > 0 || this.mount == 1)
							{
								if (this.velocity.X > num5)
								{
									this.velocity.X = this.velocity.X - num5;
								}
								this.velocity.X = this.velocity.X - num4 * 0.2f;
								if (this.wings > 0)
								{
									this.velocity.X = this.velocity.X - num4 * 0.2f;
								}
							}
							if (this.velocity.X < -(num6 + num3) / 2f && this.velocity.Y == 0f && this.mount == 0)
							{
								int num106 = 0;
								if (this.gravDir == -1f)
								{
									num106 -= this.height;
								}
								if (this.runSoundDelay == 0 && this.velocity.Y == 0f)
								{
									Main.PlaySound(17, (int)this.position.X, (int)this.position.Y, 1);
									this.runSoundDelay = 9;
								}
								if (this.wings == 3)
								{
									int num107 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num106), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num107].velocity *= 0.025f;
									num107 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num106), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num107].velocity *= 0.2f;
								}
								else if (this.coldDash)
								{
									for (int num108 = 0; num108 < 2; num108++)
									{
										int num109;
										if (num108 == 0)
										{
											num109 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
										}
										else
										{
											num109 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
										}
										Main.dust[num109].scale *= 1f + (float)Main.rand.Next(20, 40) * 0.01f;
										Main.dust[num109].noGravity = true;
										Main.dust[num109].noLight = true;
										Main.dust[num109].velocity *= 0.001f;
										Dust expr_AEC9_cp_0 = Main.dust[num109];
										expr_AEC9_cp_0.velocity.Y = expr_AEC9_cp_0.velocity.Y - 0.003f;
									}
								}
								else
								{
									int num110 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num106), this.width + 8, 4, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num110].velocity.X = Main.dust[num110].velocity.X * 0.2f;
									Main.dust[num110].velocity.Y = Main.dust[num110].velocity.Y * 0.2f;
								}
							}
						}
						else if (this.controlRight && this.velocity.X < num6)
						{
							if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
							{
								this.direction = 1;
							}
							if (this.velocity.Y == 0f || this.wings > 0 || this.mount == 1)
							{
								if (this.velocity.X < -num5)
								{
									this.velocity.X = this.velocity.X + num5;
								}
								this.velocity.X = this.velocity.X + num4 * 0.2f;
								if (this.wings > 0)
								{
									this.velocity.X = this.velocity.X + num4 * 0.2f;
								}
							}
							if (this.velocity.X > (num6 + num3) / 2f && this.velocity.Y == 0f && this.mount == 0)
							{
								int num111 = 0;
								if (this.gravDir == -1f)
								{
									num111 -= this.height;
								}
								if (this.runSoundDelay == 0 && this.velocity.Y == 0f)
								{
									Main.PlaySound(17, (int)this.position.X, (int)this.position.Y, 1);
									this.runSoundDelay = 9;
								}
								if (this.wings == 3)
								{
									int num112 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num111), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num112].velocity *= 0.025f;
									num112 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num111), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num112].velocity *= 0.2f;
								}
								else if (this.coldDash)
								{
									for (int num113 = 0; num113 < 2; num113++)
									{
										int num114;
										if (num113 == 0)
										{
											num114 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
										}
										else
										{
											num114 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
										}
										Main.dust[num114].scale *= 1f + (float)Main.rand.Next(20, 40) * 0.01f;
										Main.dust[num114].noGravity = true;
										Main.dust[num114].noLight = true;
										Main.dust[num114].velocity *= 0.001f;
										Dust expr_B3A2_cp_0 = Main.dust[num114];
										expr_B3A2_cp_0.velocity.Y = expr_B3A2_cp_0.velocity.Y - 0.003f;
									}
								}
								else
								{
									int num115 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num111), this.width + 8, 4, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num115].velocity.X = Main.dust[num115].velocity.X * 0.2f;
									Main.dust[num115].velocity.Y = Main.dust[num115].velocity.Y * 0.2f;
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
								bool flag38 = false;
								if (this.wet && this.accFlipper)
								{
									if (this.swimTime == 0)
									{
										this.swimTime = 30;
									}
									flag38 = true;
								}
								bool flag39 = false;
								bool flag40 = false;
								bool flag41 = false;
								if (this.jumpAgain2)
								{
									flag39 = true;
									this.jumpAgain2 = false;
								}
								else if (this.jumpAgain3)
								{
									flag40 = true;
									this.jumpAgain3 = false;
								}
								else if (this.jumpAgain4)
								{
									this.jumpAgain4 = false;
									flag41 = true;
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
								if (this.velocity.Y == 0f || flag38 || this.sliding)
								{
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									this.jump = Player.jumpHeight;
									if (this.sliding)
									{
										this.velocity.X = (float)(3 * -(float)this.slideDir);
									}
								}
								else if (flag39)
								{
									this.dJumpEffect2 = true;
									float arg_B9E2_0 = this.gravDir;
									Main.PlaySound(16, (int)this.position.X, (int)this.position.Y, 1);
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									this.jump = Player.jumpHeight * 3;
								}
								else if (flag40)
								{
									this.dJumpEffect3 = true;
									float arg_BA44_0 = this.gravDir;
									Main.PlaySound(16, (int)this.position.X, (int)this.position.Y, 1);
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									this.jump = (int)((double)Player.jumpHeight * 1.5);
								}
								else if (flag41)
								{
									this.dJumpEffect4 = true;
									int num116 = this.height;
									if (this.gravDir == -1f)
									{
										num116 = 0;
									}
									Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 16);
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									this.jump = Player.jumpHeight * 2;
									for (int num117 = 0; num117 < 10; num117++)
									{
										int num118 = Dust.NewDust(new Vector2(this.position.X - 34f, this.position.Y + (float)num116 - 16f), 102, 32, 188, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
										Main.dust[num118].velocity.X = Main.dust[num118].velocity.X * 0.5f - this.velocity.X * 0.1f;
										Main.dust[num118].velocity.Y = Main.dust[num118].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
									}
									int num119 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 16f, this.position.Y + (float)num116 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(435, 438), 1f);
									Main.gore[num119].velocity.X = Main.gore[num119].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num119].velocity.Y = Main.gore[num119].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
									num119 = Gore.NewGore(new Vector2(this.position.X - 36f, this.position.Y + (float)num116 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(435, 438), 1f);
									Main.gore[num119].velocity.X = Main.gore[num119].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num119].velocity.Y = Main.gore[num119].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
									num119 = Gore.NewGore(new Vector2(this.position.X + (float)this.width + 4f, this.position.Y + (float)num116 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(435, 438), 1f);
									Main.gore[num119].velocity.X = Main.gore[num119].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num119].velocity.Y = Main.gore[num119].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
								}
								else
								{
									this.dJumpEffect = true;
									int num120 = this.height;
									if (this.gravDir == -1f)
									{
										num120 = 0;
									}
									Main.PlaySound(16, (int)this.position.X, (int)this.position.Y, 1);
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									this.jump = (int)((double)Player.jumpHeight * 0.75);
									for (int num121 = 0; num121 < 10; num121++)
									{
										int num122 = Dust.NewDust(new Vector2(this.position.X - 34f, this.position.Y + (float)num120 - 16f), 102, 32, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
										Main.dust[num122].velocity.X = Main.dust[num122].velocity.X * 0.5f - this.velocity.X * 0.1f;
										Main.dust[num122].velocity.Y = Main.dust[num122].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
									}
									int num123 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 16f, this.position.Y + (float)num120 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
									Main.gore[num123].velocity.X = Main.gore[num123].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num123].velocity.Y = Main.gore[num123].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
									num123 = Gore.NewGore(new Vector2(this.position.X - 36f, this.position.Y + (float)num120 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
									Main.gore[num123].velocity.X = Main.gore[num123].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num123].velocity.Y = Main.gore[num123].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
									num123 = Gore.NewGore(new Vector2(this.position.X + (float)this.width + 4f, this.position.Y + (float)num120 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
									Main.gore[num123].velocity.X = Main.gore[num123].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num123].velocity.Y = Main.gore[num123].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
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
						if (this.wings == 0)
						{
							this.wingTime = 0f;
						}
						if (this.wings == 3)
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
							for (int num124 = 0; num124 < 2; num124++)
							{
								int num125;
								if (this.velocity.Y == 0f)
								{
									num125 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 4f), this.width, 8, 31, 0f, 0f, 100, default(Color), 1.4f);
								}
								else
								{
									num125 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)(this.height / 2) - 8f), this.width, 16, 31, 0f, 0f, 100, default(Color), 1.4f);
								}
								Main.dust[num125].velocity *= 0.1f;
								Main.dust[num125].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
							}
							if (this.velocity.X > 13f || this.velocity.X < -13f)
							{
								this.velocity.X = this.velocity.X * 0.99f;
							}
							else if (this.velocity.X > num6 || this.velocity.X < -num6)
							{
								this.velocity.X = this.velocity.X * 0.9f;
							}
							else
							{
								this.dashDelay = 20;
								if (this.velocity.X < 0f)
								{
									this.velocity.X = -num6;
								}
								else if (this.velocity.X > 0f)
								{
									this.velocity.X = num6;
								}
							}
						}
						else if (this.dash > 0 && this.mount == 0)
						{
							int num126 = 0;
							bool flag42 = false;
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
									num126 = 1;
									flag42 = true;
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
									num126 = -1;
									flag42 = true;
									this.dashTime = 0;
								}
								else
								{
									this.dashTime = -15;
								}
							}
							if (flag42)
							{
								this.velocity.X = 15.9f * (float)num126;
								this.dashDelay = -1;
								for (int num127 = 0; num127 < 20; num127++)
								{
									int num128 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 2f);
									Dust expr_C6E3_cp_0 = Main.dust[num128];
									expr_C6E3_cp_0.position.X = expr_C6E3_cp_0.position.X + (float)Main.rand.Next(-5, 6);
									Dust expr_C70A_cp_0 = Main.dust[num128];
									expr_C70A_cp_0.position.Y = expr_C70A_cp_0.position.Y + (float)Main.rand.Next(-5, 6);
									Main.dust[num128].velocity *= 0.2f;
									Main.dust[num128].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
								}
								int num129 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 34f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num129].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
								Main.gore[num129].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
								Main.gore[num129].velocity *= 0.4f;
								num129 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 14f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num129].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
								Main.gore[num129].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
								Main.gore[num129].velocity *= 0.4f;
							}
						}
						this.sliding = false;
						if (this.slideDir != 0 && this.spikedBoots > 0 && this.mount == 0 && ((this.controlLeft && this.slideDir == -1) || (this.controlRight && this.slideDir == 1)))
						{
							bool flag43 = false;
							float num130 = this.position.X;
							if (this.slideDir == 1)
							{
								num130 += (float)this.width;
							}
							num130 += (float)this.slideDir;
							float num131 = this.position.Y + (float)this.height + 1f;
							if (this.gravDir < 0f)
							{
								num131 = this.position.Y - 1f;
							}
							num130 /= 16f;
							num131 /= 16f;
							if (WorldGen.SolidTile((int)num130, (int)num131) && WorldGen.SolidTile((int)num130, (int)num131 - 1))
							{
								flag43 = true;
							}
							if (this.spikedBoots >= 2)
							{
								if (flag43 && ((this.velocity.Y > 0f && this.gravDir == 1f) || (this.velocity.Y < num2 && this.gravDir == -1f)))
								{
									float num132 = num2;
									if (this.slowFall)
									{
										if (this.controlUp)
										{
											num132 = num2 / 10f * this.gravDir;
										}
										else
										{
											num132 = num2 / 3f * this.gravDir;
										}
									}
									this.fallStart = (int)(this.position.Y / 16f);
									if ((this.controlDown && this.gravDir == 1f) || (this.controlUp && this.gravDir == -1f))
									{
										this.velocity.Y = 4f * this.gravDir;
										int num133 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)((this.width / 2 - 4) * this.slideDir), this.position.Y + (float)(this.height / 2) + (float)(this.height / 2 - 4) * this.gravDir), 8, 8, 31, 0f, 0f, 0, default(Color), 1f);
										if (this.slideDir < 0)
										{
											Dust expr_CB84_cp_0 = Main.dust[num133];
											expr_CB84_cp_0.position.X = expr_CB84_cp_0.position.X - 10f;
										}
										if (this.gravDir < 0f)
										{
											Dust expr_CBAF_cp_0 = Main.dust[num133];
											expr_CBAF_cp_0.position.Y = expr_CBAF_cp_0.position.Y - 12f;
										}
										Main.dust[num133].velocity *= 0.1f;
										Main.dust[num133].scale *= 1.2f;
										Main.dust[num133].noGravity = true;
									}
									else if (this.gravDir == -1f)
									{
										this.velocity.Y = (-num132 + 1E-05f) * this.gravDir;
									}
									else
									{
										this.velocity.Y = (-num132 + 1E-05f) * this.gravDir;
									}
									this.sliding = true;
								}
							}
							else if ((flag43 && (double)this.velocity.Y > 0.5 && this.gravDir == 1f) || ((double)this.velocity.Y < -0.5 && this.gravDir == -1f))
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
								int num134 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)((this.width / 2 - 4) * this.slideDir), this.position.Y + (float)(this.height / 2) + (float)(this.height / 2 - 4) * this.gravDir), 8, 8, 31, 0f, 0f, 0, default(Color), 1f);
								if (this.slideDir < 0)
								{
									Dust expr_CD94_cp_0 = Main.dust[num134];
									expr_CD94_cp_0.position.X = expr_CD94_cp_0.position.X - 10f;
								}
								if (this.gravDir < 0f)
								{
									Dust expr_CDBF_cp_0 = Main.dust[num134];
									expr_CDBF_cp_0.position.Y = expr_CDBF_cp_0.position.Y - 12f;
								}
								Main.dust[num134].velocity *= 0.1f;
								Main.dust[num134].scale *= 1.2f;
								Main.dust[num134].noGravity = true;
							}
						}
						bool flag44 = false;
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
								flag44 = true;
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
						if (!flag44)
						{
							this.carpetFrame = -1;
						}
						if (this.dJumpEffect && this.doubleJump && !this.jumpAgain && (this.jumpAgain2 || !this.doubleJump2) && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
						{
							int num135 = this.height;
							if (this.gravDir == -1f)
							{
								num135 = -6;
							}
							int num136 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)num135), this.width + 8, 4, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
							Main.dust[num136].velocity.X = Main.dust[num136].velocity.X * 0.5f - this.velocity.X * 0.1f;
							Main.dust[num136].velocity.Y = Main.dust[num136].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
						}
						if (this.dJumpEffect2 && this.doubleJump2 && !this.jumpAgain2 && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
						{
							int num137 = this.height;
							if (this.gravDir == -1f)
							{
								num137 = -6;
							}
							float num138 = ((float)this.jump / 75f + 1f) / 2f;
							for (int num139 = 0; num139 < 3; num139++)
							{
								int num140 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)(num137 / 2)), this.width, 32, 124, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 150, default(Color), 1f * num138);
								Main.dust[num140].velocity *= 0.5f * num138;
								Main.dust[num140].fadeIn = 1.5f * num138;
							}
							this.sandStorm = true;
							if (this.miscCounter % 3 == 0)
							{
								int num141 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 18f, this.position.Y + (float)(num137 / 2)), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(220, 223), num138);
								Main.gore[num141].velocity = this.velocity * 0.3f * num138;
								Main.gore[num141].alpha = 100;
							}
						}
						if (this.dJumpEffect4 && this.doubleJump4 && !this.jumpAgain4 && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
						{
							int num142 = this.height;
							if (this.gravDir == -1f)
							{
								num142 = -6;
							}
							int num143 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)num142), this.width + 8, 4, 188, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
							Main.dust[num143].velocity.X = Main.dust[num143].velocity.X * 0.5f - this.velocity.X * 0.1f;
							Main.dust[num143].velocity.Y = Main.dust[num143].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
							Main.dust[num143].velocity *= 0.5f;
						}
						if (this.dJumpEffect3 && this.doubleJump3 && !this.jumpAgain3 && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
						{
							int num144 = this.height - 6;
							if (this.gravDir == -1f)
							{
								num144 = 6;
							}
							for (int num145 = 0; num145 < 2; num145++)
							{
								int num146 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)num144), this.width, 12, 76, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 0, default(Color), 1f);
								Main.dust[num146].velocity *= 0.1f;
								if (num145 == 0)
								{
									Main.dust[num146].velocity += this.velocity * 0.03f;
								}
								else
								{
									Main.dust[num146].velocity -= this.velocity * 0.03f;
								}
								Main.dust[num146].noLight = true;
							}
							for (int num147 = 0; num147 < 3; num147++)
							{
								int num148 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)num144), this.width, 12, 76, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 0, default(Color), 1f);
								Main.dust[num148].fadeIn = 1.5f;
								Main.dust[num148].velocity *= 0.6f;
								Main.dust[num148].velocity += this.velocity * 0.8f;
								Main.dust[num148].noGravity = true;
								Main.dust[num148].noLight = true;
							}
							for (int num149 = 0; num149 < 3; num149++)
							{
								int num150 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)num144), this.width, 12, 76, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 0, default(Color), 1f);
								Main.dust[num150].fadeIn = 1.5f;
								Main.dust[num150].velocity *= 0.6f;
								Main.dust[num150].velocity -= this.velocity * 0.8f;
								Main.dust[num150].noGravity = true;
								Main.dust[num150].noLight = true;
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
						bool flag45 = false;
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
							this.wingTime = (float)this.GetWingTime();
						}
						if (this.wings > 0 && this.controlJump && this.wingTime > 0f && !this.jumpAgain && this.jump == 0 && this.velocity.Y != 0f)
						{
							flag45 = true;
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
							if (flag45)
							{
								if (this.wings == 10 && Main.rand.Next(2) == 0)
								{
									int num151 = 4;
									if (this.direction == 1)
									{
										num151 = -40;
									}
									int num152 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num151, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 76, 0f, 0f, 50, default(Color), 0.6f);
									Main.dust[num152].fadeIn = 1.1f;
									Main.dust[num152].noGravity = true;
									Main.dust[num152].noLight = true;
									Main.dust[num152].velocity *= 0.3f;
								}
								if (this.wings == 9 && Main.rand.Next(2) == 0)
								{
									int num153 = 4;
									if (this.direction == 1)
									{
										num153 = -40;
									}
									int num154 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num153, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 6, 0f, 0f, 200, default(Color), 2f);
									Main.dust[num154].noGravity = true;
									Main.dust[num154].velocity *= 0.3f;
								}
								if (this.wings == 6 && Main.rand.Next(4) == 0)
								{
									int num155 = 4;
									if (this.direction == 1)
									{
										num155 = -40;
									}
									int num156 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num155, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 55, 0f, 0f, 200, default(Color), 1f);
									Main.dust[num156].velocity *= 0.3f;
								}
								if (this.wings == 5 && Main.rand.Next(3) == 0)
								{
									int num157 = 6;
									if (this.direction == 1)
									{
										num157 = -30;
									}
									int num158 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num157, this.position.Y), 18, this.height, 58, 0f, 0f, 255, default(Color), 1.2f);
									Main.dust[num158].velocity *= 0.3f;
								}
								if (this.wings == 4 && this.controlUp)
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
								else if (this.wings == 3 && this.controlUp)
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
									if (this.wings == 22 && this.controlDown && !this.controlLeft && !this.controlRight)
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
								if (flag45 || this.jump > 0)
								{
									this.rocketDelay2--;
									if (this.rocketDelay2 <= 0)
									{
										Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 13);
										this.rocketDelay2 = 60;
									}
									int num159 = 2;
									if (this.controlUp)
									{
										num159 = 4;
									}
									for (int num160 = 0; num160 < num159; num160++)
									{
										int type3 = 6;
										if (this.head == 41)
										{
											int arg_E19D_0 = this.body;
										}
										float scale = 1.75f;
										int alpha = 100;
										float x = this.position.X + (float)(this.width / 2) + 16f;
										if (this.direction > 0)
										{
											x = this.position.X + (float)(this.width / 2) - 26f;
										}
										float num161 = this.position.Y + (float)this.height - 18f;
										if (num160 == 1 || num160 == 3)
										{
											x = this.position.X + (float)(this.width / 2) + 8f;
											if (this.direction > 0)
											{
												x = this.position.X + (float)(this.width / 2) - 20f;
											}
											num161 += 6f;
										}
										if (num160 > 1)
										{
											num161 += this.velocity.Y;
										}
										int num162 = Dust.NewDust(new Vector2(x, num161), 8, 8, type3, 0f, 0f, alpha, default(Color), scale);
										Dust expr_E2B0_cp_0 = Main.dust[num162];
										expr_E2B0_cp_0.velocity.X = expr_E2B0_cp_0.velocity.X * 0.1f;
										Main.dust[num162].velocity.Y = Main.dust[num162].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
										Main.dust[num162].noGravity = true;
										if (num159 == 4)
										{
											Dust expr_E32A_cp_0 = Main.dust[num162];
											expr_E32A_cp_0.velocity.Y = expr_E32A_cp_0.velocity.Y + 6f;
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
											int num163 = 2;
											if (this.wingFrameCounter < num163)
											{
												this.wingFrame = 1;
											}
											else if (this.wingFrameCounter < num163 * 2)
											{
												this.wingFrame = 2;
											}
											else if (this.wingFrameCounter < num163 * 3)
											{
												this.wingFrame = 3;
											}
											else if (this.wingFrameCounter < num163 * 4 - 1)
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
											int num164 = 6;
											if (this.wingFrameCounter < num164)
											{
												this.wingFrame = 4;
											}
											else if (this.wingFrameCounter < num164 * 2)
											{
												this.wingFrame = 5;
											}
											else if (this.wingFrameCounter < num164 * 3 - 1)
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
										int num165 = 2;
										if (this.wingFrameCounter < num165)
										{
											this.wingFrame = 4;
										}
										else if (this.wingFrameCounter < num165 * 2)
										{
											this.wingFrame = 5;
										}
										else if (this.wingFrameCounter < num165 * 3)
										{
											this.wingFrame = 6;
										}
										else if (this.wingFrameCounter < num165 * 4 - 1)
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
									int num166 = 6;
									if (this.wingFrameCounter < num166)
									{
										this.wingFrame = 4;
									}
									else if (this.wingFrameCounter < num166 * 2)
									{
										this.wingFrame = 5;
									}
									else if (this.wingFrameCounter < num166 * 3 - 1)
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
								if (flag45 || this.jump > 0)
								{
									this.wingFrameCounter++;
									int num167 = 5;
									if (this.wingFrameCounter < num167)
									{
										this.wingFrame = 1;
									}
									else if (this.wingFrameCounter < num167 * 2)
									{
										this.wingFrame = 2;
									}
									else if (this.wingFrameCounter < num167 * 3)
									{
										this.wingFrame = 3;
									}
									else if (this.wingFrameCounter < num167 * 4 - 1)
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
							else if (flag45 || this.jump > 0)
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
							if (this.wings > 0 && this.rocketBoots > 0)
							{
								this.wingTime += (float)(this.rocketTime * 3);
								this.rocketTime = 0;
							}
							if (flag45 && this.wings != 4 && this.wings != 22)
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
							if ((this.wingTime == 0f || this.wings == 0) && this.rocketBoots > 0 && this.controlJump && this.rocketDelay == 0 && this.canRocket && this.rocketRelease && !this.jumpAgain)
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
								int num168 = this.height;
								if (this.gravDir == -1f)
								{
									num168 = 4;
								}
								this.rocketFrame = true;
								for (int num169 = 0; num169 < 2; num169++)
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
									if (num169 == 0)
									{
										int num170 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)num168 - 10f), 8, 8, type4, 0f, 0f, alpha2, default(Color), scale2);
										if (this.rocketBoots == 1)
										{
											Main.dust[num170].noGravity = true;
										}
										Main.dust[num170].velocity.X = Main.dust[num170].velocity.X * 1f - 2f - this.velocity.X * 0.3f;
										Main.dust[num170].velocity.Y = Main.dust[num170].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
										if (this.rocketBoots == 2)
										{
											Main.dust[num170].velocity *= 0.1f;
										}
										if (this.rocketBoots == 3)
										{
											Main.dust[num170].velocity *= 0.05f;
											Dust expr_EAD2_cp_0 = Main.dust[num170];
											expr_EAD2_cp_0.velocity.Y = expr_EAD2_cp_0.velocity.Y + 0.15f;
											Main.dust[num170].noLight = true;
											if (Main.rand.Next(2) == 0)
											{
												Main.dust[num170].noGravity = true;
												Main.dust[num170].scale = 1.75f;
											}
										}
									}
									else
									{
										int num171 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 4f, this.position.Y + (float)num168 - 10f), 8, 8, type4, 0f, 0f, alpha2, default(Color), scale2);
										if (this.rocketBoots == 1)
										{
											Main.dust[num171].noGravity = true;
										}
										Main.dust[num171].velocity.X = Main.dust[num171].velocity.X * 1f + 2f - this.velocity.X * 0.3f;
										Main.dust[num171].velocity.Y = Main.dust[num171].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
										if (this.rocketBoots == 2)
										{
											Main.dust[num171].velocity *= 0.1f;
										}
										if (this.rocketBoots == 3)
										{
											Main.dust[num171].velocity *= 0.05f;
											Dust expr_EC7B_cp_0 = Main.dust[num171];
											expr_EC7B_cp_0.velocity.Y = expr_EC7B_cp_0.velocity.Y + 0.15f;
											Main.dust[num171].noLight = true;
											if (Main.rand.Next(2) == 0)
											{
												Main.dust[num171].noGravity = true;
												Main.dust[num171].scale = 1.75f;
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
							else if (!flag45)
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
								else if (this.slowFall && ((!this.controlDown && this.gravDir == 1f) || (!this.controlUp && this.gravDir == -1f)))
								{
									if ((this.controlUp && this.gravDir == 1f) || (this.controlDown && this.gravDir == -1f))
									{
										num2 = num2 / 10f * this.gravDir;
									}
									else
									{
										num2 = num2 / 3f * this.gravDir;
									}
									this.velocity.Y = this.velocity.Y + num2;
								}
								else if (this.wings > 0 && this.controlJump && this.velocity.Y > 0f)
								{
									this.fallStart = (int)(this.position.Y / 16f);
									if (this.velocity.Y > 0f)
									{
										if (this.wings == 10 && Main.rand.Next(3) == 0)
										{
											int num172 = 4;
											if (this.direction == 1)
											{
												num172 = -40;
											}
											int num173 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num172, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 76, 0f, 0f, 50, default(Color), 0.6f);
											Main.dust[num173].fadeIn = 1.1f;
											Main.dust[num173].noGravity = true;
											Main.dust[num173].noLight = true;
											Main.dust[num173].velocity *= 0.3f;
										}
										if (this.wings == 9 && Main.rand.Next(3) == 0)
										{
											int num174 = 8;
											if (this.direction == 1)
											{
												num174 = -40;
											}
											int num175 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num174, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 6, 0f, 0f, 200, default(Color), 2f);
											Main.dust[num175].noGravity = true;
											Main.dust[num175].velocity *= 0.3f;
										}
										if (this.wings == 6)
										{
											if (Main.rand.Next(10) == 0)
											{
												int num176 = 4;
												if (this.direction == 1)
												{
													num176 = -40;
												}
												int num177 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num176, this.position.Y + (float)(this.height / 2) - 12f), 30, 20, 55, 0f, 0f, 200, default(Color), 1f);
												Main.dust[num177].velocity *= 0.3f;
											}
										}
										else if (this.wings == 5 && Main.rand.Next(6) == 0)
										{
											int num178 = 6;
											if (this.direction == 1)
											{
												num178 = -30;
											}
											int num179 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num178, this.position.Y), 18, this.height, 58, 0f, 0f, 255, default(Color), 1.2f);
											Main.dust[num179].velocity *= 0.3f;
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
											float num180 = this.position.Y + (float)this.height - 18f;
											if (Main.rand.Next(2) == 1)
											{
												x2 = this.position.X + (float)(this.width / 2) + 8f;
												if (this.direction > 0)
												{
													x2 = this.position.X + (float)(this.width / 2) - 20f;
												}
												num180 += 6f;
											}
											int num181 = Dust.NewDust(new Vector2(x2, num180), 8, 8, type5, 0f, 0f, alpha3, default(Color), scale3);
											Dust expr_F566_cp_0 = Main.dust[num181];
											expr_F566_cp_0.velocity.X = expr_F566_cp_0.velocity.X * 0.3f;
											Dust expr_F584_cp_0 = Main.dust[num181];
											expr_F584_cp_0.velocity.Y = expr_F584_cp_0.velocity.Y + 10f;
											Main.dust[num181].noGravity = true;
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
										else if (this.wings != 22)
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
								if (this.slowFall && this.velocity.Y < -num / 3f && !this.controlUp)
								{
									this.velocity.Y = -num / 3f;
								}
								if (this.slowFall && this.velocity.Y < -num / 5f && this.controlDown)
								{
									this.velocity.Y = -num / 10f;
								}
							}
						}
					}
					if (this.wings == 3)
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
					if (this.wings == 22 && this.controlDown && this.controlJump && this.wingTime > 0f)
					{
						this.velocity.Y = this.velocity.Y * 0.9f;
						if (this.velocity.Y > -2f && this.velocity.Y < 1f)
						{
							this.velocity.Y = 1E-05f;
						}
					}
					for (int num182 = 0; num182 < 400; num182++)
					{
						if (Main.item[num182].active && Main.item[num182].noGrabDelay == 0 && Main.item[num182].owner == i)
						{
							if (new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height).Intersects(new Rectangle((int)Main.item[num182].position.X, (int)Main.item[num182].position.Y, Main.item[num182].width, Main.item[num182].height)))
							{
								if (i == Main.myPlayer && (this.inventory[this.selectedItem].type != 0 || this.itemAnimation <= 0))
								{
									if (Main.item[num182].type == 58 || Main.item[num182].type == 1734 || Main.item[num182].type == 1867)
									{
										Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
										this.statLife += 20;
										if (Main.myPlayer == this.whoAmi)
										{
											this.HealEffect(20, true);
										}
										if (this.statLife > this.statLifeMax)
										{
											this.statLife = this.statLifeMax;
										}
										Main.item[num182] = new Item();
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num182, 0f, 0f, 0f, 0);
										}
									}
									else if (Main.item[num182].type == 184 || Main.item[num182].type == 1735 || Main.item[num182].type == 1868)
									{
										Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
										this.statMana += 100;
										if (Main.myPlayer == this.whoAmi)
										{
											this.ManaEffect(100);
										}
										if (this.statMana > this.statManaMax2)
										{
											this.statMana = this.statManaMax2;
										}
										Main.item[num182] = new Item();
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num182, 0f, 0f, 0f, 0);
										}
									}
									else
									{
										Main.item[num182] = this.GetItem(i, Main.item[num182]);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num182, 0f, 0f, 0f, 0);
										}
									}
								}
							}
							else if (new Rectangle((int)this.position.X - Player.itemGrabRange, (int)this.position.Y - Player.itemGrabRange, this.width + Player.itemGrabRange * 2, this.height + Player.itemGrabRange * 2).Intersects(new Rectangle((int)Main.item[num182].position.X, (int)Main.item[num182].position.Y, Main.item[num182].width, Main.item[num182].height)) && this.ItemSpace(Main.item[num182]))
							{
								Main.item[num182].beingGrabbed = true;
								if ((double)this.position.X + (double)this.width * 0.5 > (double)Main.item[num182].position.X + (double)Main.item[num182].width * 0.5)
								{
									if (Main.item[num182].velocity.X < Player.itemGrabSpeedMax + this.velocity.X)
									{
										Item expr_FD2E_cp_0 = Main.item[num182];
										expr_FD2E_cp_0.velocity.X = expr_FD2E_cp_0.velocity.X + Player.itemGrabSpeed;
									}
									if (Main.item[num182].velocity.X < 0f)
									{
										Item expr_FD68_cp_0 = Main.item[num182];
										expr_FD68_cp_0.velocity.X = expr_FD68_cp_0.velocity.X + Player.itemGrabSpeed * 0.75f;
									}
								}
								else
								{
									if (Main.item[num182].velocity.X > -Player.itemGrabSpeedMax + this.velocity.X)
									{
										Item expr_FDB7_cp_0 = Main.item[num182];
										expr_FDB7_cp_0.velocity.X = expr_FDB7_cp_0.velocity.X - Player.itemGrabSpeed;
									}
									if (Main.item[num182].velocity.X > 0f)
									{
										Item expr_FDEE_cp_0 = Main.item[num182];
										expr_FDEE_cp_0.velocity.X = expr_FDEE_cp_0.velocity.X - Player.itemGrabSpeed * 0.75f;
									}
								}
								if ((double)this.position.Y + (double)this.height * 0.5 > (double)Main.item[num182].position.Y + (double)Main.item[num182].height * 0.5)
								{
									if (Main.item[num182].velocity.Y < Player.itemGrabSpeedMax)
									{
										Item expr_FE77_cp_0 = Main.item[num182];
										expr_FE77_cp_0.velocity.Y = expr_FE77_cp_0.velocity.Y + Player.itemGrabSpeed;
									}
									if (Main.item[num182].velocity.Y < 0f)
									{
										Item expr_FEB1_cp_0 = Main.item[num182];
										expr_FEB1_cp_0.velocity.Y = expr_FEB1_cp_0.velocity.Y + Player.itemGrabSpeed * 0.75f;
									}
								}
								else
								{
									if (Main.item[num182].velocity.Y > -Player.itemGrabSpeedMax)
									{
										Item expr_FEF1_cp_0 = Main.item[num182];
										expr_FEF1_cp_0.velocity.Y = expr_FEF1_cp_0.velocity.Y - Player.itemGrabSpeed;
									}
									if (Main.item[num182].velocity.Y > 0f)
									{
										Item expr_FF28_cp_0 = Main.item[num182];
										expr_FF28_cp_0.velocity.Y = expr_FF28_cp_0.velocity.Y - Player.itemGrabSpeed * 0.75f;
									}
								}
							}
						}
					}
					if (this.position.X / 16f - (float)Player.tileRangeX <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY - 2f >= (float)Player.tileTargetY)
					{
						if (Main.tile[Player.tileTargetX, Player.tileTargetY] == null)
						{
							Main.tile[Player.tileTargetX, Player.tileTargetY] = new Tile();
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].active())
						{
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 104)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 359;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 79)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 36)
								{
									this.showItemIcon2 = 224;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 72)
								{
									this.showItemIcon2 = 644;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 108)
								{
									this.showItemIcon2 = 645;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 144)
								{
									this.showItemIcon2 = 646;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 180)
								{
									this.showItemIcon2 = 920;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 216)
								{
									this.showItemIcon2 = 1470;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 252)
								{
									this.showItemIcon2 = 1471;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 288)
								{
									this.showItemIcon2 = 1472;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 324)
								{
									this.showItemIcon2 = 1473;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 358)
								{
									this.showItemIcon2 = 1719;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 396)
								{
									this.showItemIcon2 = 1720;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 432)
								{
									this.showItemIcon2 = 1721;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 468)
								{
									this.showItemIcon2 = 1722;
								}
								else
								{
									this.showItemIcon2 = 646;
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 209)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 72)
								{
									this.showItemIcon2 = 928;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 144)
								{
									this.showItemIcon2 = 1337;
								}
								int num183;
								for (num183 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18); num183 >= 4; num183 -= 4)
								{
								}
								if (num183 < 2)
								{
									this.showItemIconR = true;
								}
								else
								{
									this.showItemIconR = false;
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 216)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								int num184 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
								int num185 = 0;
								while (num184 >= 40)
								{
									num184 -= 40;
									num185++;
								}
								this.showItemIcon2 = 970 + num185;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 212)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 949;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 21)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 972)
								{
									this.showItemIcon2 = 1537;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 936)
								{
									this.showItemIcon2 = 1536;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 900)
								{
									this.showItemIcon2 = 1535;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 864)
								{
									this.showItemIcon2 = 1534;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 828)
								{
									this.showItemIcon2 = 1533;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 792)
								{
									this.showItemIcon2 = 1532;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 756)
								{
									this.showItemIcon2 = 1531;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 720)
								{
									this.showItemIcon2 = 1530;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 684)
								{
									this.showItemIcon2 = 1529;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 648)
								{
									this.showItemIcon2 = 1528;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 612)
								{
									this.showItemIcon2 = 1298;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 576)
								{
									this.showItemIcon2 = 1142;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 540)
								{
									this.showItemIcon2 = 952;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 504)
								{
									this.showItemIcon2 = 914;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 468)
								{
									this.showItemIcon2 = 838;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 432)
								{
									this.showItemIcon2 = 831;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 396)
								{
									this.showItemIcon2 = 681;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 360)
								{
									this.showItemIcon2 = 680;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 324)
								{
									this.showItemIcon2 = 627;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 288)
								{
									this.showItemIcon2 = 626;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 252)
								{
									this.showItemIcon2 = 625;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 216)
								{
									this.showItemIcon2 = 348;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 180)
								{
									this.showItemIcon2 = 343;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 144)
								{
									this.showItemIcon2 = 329;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 108)
								{
									this.showItemIcon2 = 328;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 72)
								{
									this.showItemIcon2 = 327;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 36)
								{
									this.showItemIcon2 = 306;
								}
								else
								{
									this.showItemIcon2 = 48;
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 4)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								int num186 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 22);
								if (num186 == 0)
								{
									this.showItemIcon2 = 8;
								}
								else if (num186 == 8)
								{
									this.showItemIcon2 = 523;
								}
								else if (num186 == 9)
								{
									this.showItemIcon2 = 974;
								}
								else if (num186 == 10)
								{
									this.showItemIcon2 = 1245;
								}
								else if (num186 == 11)
								{
									this.showItemIcon2 = 1333;
								}
								else
								{
									this.showItemIcon2 = 426 + num186;
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 13)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 72)
								{
									this.showItemIcon2 = 351;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 54)
								{
									this.showItemIcon2 = 350;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 18)
								{
									this.showItemIcon2 = 28;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 36)
								{
									this.showItemIcon2 = 110;
								}
								else
								{
									this.showItemIcon2 = 31;
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 29)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 87;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 97)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 346;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 33)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 105;
								int num187 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 22);
								if (num187 == 1)
								{
									this.showItemIcon2 = 1405;
								}
								if (num187 == 2)
								{
									this.showItemIcon2 = 1406;
								}
								if (num187 == 3)
								{
									this.showItemIcon2 = 1407;
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 49)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 148;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 50)
							{
								this.noThrow = 2;
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 90)
								{
									this.showItemIcon = true;
									this.showItemIcon2 = 165;
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 139)
							{
								this.noThrow = 2;
								int num188 = Player.tileTargetX;
								int num189 = Player.tileTargetY;
								int num190 = 0;
								for (int num191 = (int)(Main.tile[num188, num189].frameY / 18); num191 >= 2; num191 -= 2)
								{
									num190++;
								}
								this.showItemIcon = true;
								if (num190 == 28)
								{
									this.showItemIcon2 = 1963;
								}
								else if (num190 == 29)
								{
									this.showItemIcon2 = 1964;
								}
								else if (num190 == 30)
								{
									this.showItemIcon2 = 1965;
								}
								else if (num190 >= 13)
								{
									this.showItemIcon2 = 1596 + num190 - 13;
								}
								else
								{
									this.showItemIcon2 = 562 + num190;
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 207)
							{
								this.noThrow = 2;
								int num192 = Player.tileTargetX;
								int num193 = Player.tileTargetY;
								int num194 = 0;
								for (int num195 = (int)(Main.tile[num192, num193].frameX / 18); num195 >= 2; num195 -= 2)
								{
									num194++;
								}
								this.showItemIcon = true;
								if (num194 == 0)
								{
									this.showItemIcon2 = 909;
								}
								else if (num194 == 1)
								{
									this.showItemIcon2 = 910;
								}
								else if (num194 == 2)
								{
									this.showItemIcon2 = 940;
								}
								else if (num194 == 3)
								{
									this.showItemIcon2 = 941;
								}
								else if (num194 == 4)
								{
									this.showItemIcon2 = 942;
								}
								else if (num194 == 5)
								{
									this.showItemIcon2 = 943;
								}
								else if (num194 == 6)
								{
									this.showItemIcon2 = 944;
								}
								else if (num194 == 7)
								{
									this.showItemIcon2 = 945;
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 55 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 85)
							{
								this.noThrow = 2;
								int num196 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18);
								int num197 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
								while (num196 > 1)
								{
									num196 -= 2;
								}
								int num198 = Player.tileTargetX - num196;
								int num199 = Player.tileTargetY - num197;
								Main.signBubble = true;
								Main.signX = num198 * 16 + 16;
								Main.signY = num199 * 16;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 237)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 1293;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 10 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 11)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								int num200 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
								int num201 = 0;
								while (num200 >= 54)
								{
									num200 -= 54;
									num201++;
								}
								if (num201 == 0)
								{
									this.showItemIcon2 = 25;
								}
								else if (num201 == 9)
								{
									this.showItemIcon2 = 837;
								}
								else if (num201 == 10)
								{
									this.showItemIcon2 = 912;
								}
								else if (num201 == 11)
								{
									this.showItemIcon2 = 1141;
								}
								else if (num201 == 12)
								{
									this.showItemIcon2 = 1137;
								}
								else if (num201 == 13)
								{
									this.showItemIcon2 = 1138;
								}
								else if (num201 == 14)
								{
									this.showItemIcon2 = 1139;
								}
								else if (num201 == 15)
								{
									this.showItemIcon2 = 1140;
								}
								else if (num201 == 16)
								{
									this.showItemIcon2 = 1411;
								}
								else if (num201 == 17)
								{
									this.showItemIcon2 = 1412;
								}
								else if (num201 == 18)
								{
									this.showItemIcon2 = 1413;
								}
								else if (num201 == 19)
								{
									this.showItemIcon2 = 1458;
								}
								else if (num201 >= 20 && num201 <= 23)
								{
									this.showItemIcon2 = 1709 + num201 - 20;
								}
								else if (num201 == 24)
								{
									this.showItemIcon2 = 1793;
								}
								else if (num201 == 25)
								{
									this.showItemIcon2 = 1815;
								}
								else if (num201 == 26)
								{
									this.showItemIcon2 = 1924;
								}
								else if (num201 >= 4 && num201 <= 8)
								{
									this.showItemIcon2 = 812 + num201;
								}
								else
								{
									this.showItemIcon2 = 649 + num201;
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 125)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 487;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 132)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 513;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 136)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = 538;
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 144)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								this.showItemIcon2 = (int)(583 + Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18);
							}
							if (this.controlUseTile)
							{
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 212 && this.launcherWait <= 0)
								{
									int num202 = Player.tileTargetX;
									int num203 = Player.tileTargetY;
									bool flag46 = false;
									for (int num204 = 0; num204 < 58; num204++)
									{
										if (this.inventory[num204].type == 949 && this.inventory[num204].stack > 0)
										{
											this.inventory[num204].stack--;
											if (this.inventory[num204].stack <= 0)
											{
												this.inventory[num204].SetDefaults(0, false);
											}
											flag46 = true;
											break;
										}
									}
									if (flag46)
									{
										this.launcherWait = 10;
										Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 11);
										int num205 = (int)(Main.tile[num202, num203].frameX / 18);
										int num206 = 0;
										while (num205 >= 3)
										{
											num206++;
											num205 -= 3;
										}
										num205 = num202 - num205;
										int num207;
										for (num207 = (int)(Main.tile[num202, num203].frameY / 18); num207 >= 3; num207 -= 3)
										{
										}
										num207 = num203 - num207;
										float num208 = 12f + (float)Main.rand.Next(450) * 0.01f;
										float num209 = (float)Main.rand.Next(85, 105);
										float num210 = (float)Main.rand.Next(-35, 11);
										int type6 = 166;
										int damage = 17;
										float knockBack = 3.5f;
										Vector2 vector = new Vector2((float)((num205 + 2) * 16 - 8), (float)((num207 + 2) * 16 - 8));
										if (num206 == 0)
										{
											num209 *= -1f;
											vector.X -= 12f;
										}
										else
										{
											vector.X += 12f;
										}
										float num211 = num209;
										float num212 = num210;
										float num213 = (float)Math.Sqrt((double)(num211 * num211 + num212 * num212));
										num213 = num208 / num213;
										num211 *= num213;
										num212 *= num213;
										Projectile.NewProjectile(vector.X, vector.Y, num211, num212, type6, damage, knockBack, Main.myPlayer, 0f, 0f);
									}
								}
								if (this.releaseUseTile)
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 132 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 136 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 144)
									{
										WorldGen.hitSwitch(Player.tileTargetX, Player.tileTargetY);
										NetMessage.SendData(59, -1, -1, "", Player.tileTargetX, (float)Player.tileTargetY, 0f, 0f, 0);
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 139)
									{
										Main.PlaySound(28, Player.tileTargetX * 16, Player.tileTargetY * 16, 0);
										WorldGen.SwitchMB(Player.tileTargetX, Player.tileTargetY);
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 207)
									{
										Main.PlaySound(28, Player.tileTargetX * 16, Player.tileTargetY * 16, 0);
										WorldGen.SwitchFountain(Player.tileTargetX, Player.tileTargetY);
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 216)
									{
										WorldGen.LaunchRocket(Player.tileTargetX, Player.tileTargetY);
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 4 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 13 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 33 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 49 || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 50 && Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 90))
									{
										WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
										}
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 125)
									{
										this.AddBuff(29, 36000, true);
										Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 4);
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 79)
									{
										int num214 = Player.tileTargetX;
										int num215 = Player.tileTargetY;
										num214 += (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18 * -1);
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 72)
										{
											num214 += 4;
											num214++;
										}
										else
										{
											num214 += 2;
										}
										int num216 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
										int num217 = 0;
										while (num216 > 1)
										{
											num216 -= 2;
											num217++;
										}
										num215 -= num216;
										num215 += 2;
										if (Player.CheckSpawn(num214, num215))
										{
											this.ChangeSpawn(num214, num215);
											Main.NewText("Spawn point set!", 255, 240, 20, false);
										}
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 55 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 85)
									{
										bool flag47 = true;
										if (this.sign >= 0)
										{
											int num218 = Sign.ReadSign(Player.tileTargetX, Player.tileTargetY);
											if (num218 == this.sign)
											{
												this.sign = -1;
												Main.npcChatText = "";
												Main.editSign = false;
												Main.PlaySound(11, -1, -1, 1);
												flag47 = false;
											}
										}
										if (flag47)
										{
											if (Main.netMode == 0)
											{
												this.talkNPC = -1;
												Main.playerInventory = false;
												Main.editSign = false;
												Main.PlaySound(10, -1, -1, 1);
												int num219 = Sign.ReadSign(Player.tileTargetX, Player.tileTargetY);
												this.sign = num219;
												Main.npcChatText = Main.sign[num219].text;
											}
											else
											{
												int num220 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18);
												int num221 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
												while (num220 > 1)
												{
													num220 -= 2;
												}
												int num222 = Player.tileTargetX - num220;
												int num223 = Player.tileTargetY - num221;
												if (Main.tile[num222, num223].type == 55 || Main.tile[num222, num223].type == 85)
												{
													NetMessage.SendData(46, -1, -1, "", num222, (float)num223, 0f, 0f, 0);
												}
											}
										}
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 104)
									{
										string text = "AM";
										double num224 = Main.time;
										if (!Main.dayTime)
										{
											num224 += 54000.0;
										}
										num224 = num224 / 86400.0 * 24.0;
										double num225 = 7.5;
										num224 = num224 - num225 - 12.0;
										if (num224 < 0.0)
										{
											num224 += 24.0;
										}
										if (num224 >= 12.0)
										{
											text = "PM";
										}
										int num226 = (int)num224;
										double num227 = num224 - (double)num226;
										num227 = (double)((int)(num227 * 60.0));
										string text2 = string.Concat(num227);
										if (num227 < 10.0)
										{
											text2 = "0" + text2;
										}
										if (num226 > 12)
										{
											num226 -= 12;
										}
										if (num226 == 0)
										{
											num226 = 12;
										}
										string newText = string.Concat(new object[]
										{
											"Time: ",
											num226,
											":",
											text2,
											" ",
											text
										});
										Main.NewText(newText, 255, 240, 20, false);
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 237)
									{
										bool flag48 = false;
										if (!NPC.AnyNPCs(245))
										{
											for (int num228 = 0; num228 < 58; num228++)
											{
												if (this.inventory[num228].type == 1293)
												{
													this.inventory[num228].stack--;
													if (this.inventory[num228].stack <= 0)
													{
														this.inventory[num228].SetDefaults(0, false);
													}
													flag48 = true;
												}
											}
										}
										if (flag48)
										{
											Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
											if (Main.netMode != 1)
											{
												NPC.SpawnOnPlayer(i, 245);
											}
											else
											{
												NetMessage.SendData(61, -1, -1, "", this.whoAmi, 245f, 0f, 0f, 0);
											}
										}
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 10)
									{
										int num229 = Player.tileTargetX;
										int num230 = Player.tileTargetY;
										if (Main.tile[num229, num230].frameY >= 594 && Main.tile[num229, num230].frameY <= 646)
										{
											int num231 = 1141;
											for (int num232 = 0; num232 < 58; num232++)
											{
												if (this.inventory[num232].type == num231 && this.inventory[num232].stack > 0)
												{
													this.inventory[num232].stack--;
													if (this.inventory[num232].stack <= 0)
													{
														this.inventory[num232] = new Item();
													}
													WorldGen.UnlockDoor(num229, num230);
													if (Main.netMode == 1)
													{
														NetMessage.SendData(52, -1, -1, "", this.whoAmi, 2f, (float)num229, (float)num230, 0);
													}
												}
											}
										}
										else
										{
											WorldGen.OpenDoor(Player.tileTargetX, Player.tileTargetY, this.direction);
											NetMessage.SendData(19, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.direction, 0);
										}
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 11 && WorldGen.CloseDoor(Player.tileTargetX, Player.tileTargetY, false))
									{
										NetMessage.SendData(19, -1, -1, "", 1, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.direction, 0);
									}
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 209)
									{
										WorldGen.SwitchCannon(Player.tileTargetX, Player.tileTargetY);
									}
									else if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 21 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 29 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 97) && this.talkNPC == -1)
									{
										Main.mouseRightRelease = false;
										int num233 = 0;
										int num234;
										for (num234 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18); num234 > 1; num234 -= 2)
										{
										}
										num234 = Player.tileTargetX - num234;
										int num235 = Player.tileTargetY - (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 29)
										{
											num233 = 1;
										}
										else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 97)
										{
											num233 = 2;
										}
										else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 252)
										{
											Main.chestText = "Chest";
										}
										else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 216)
										{
											Main.chestText = "Trash Can";
										}
										else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 180)
										{
											Main.chestText = "Barrel";
										}
										else
										{
											Main.chestText = "Chest";
										}
										if (Main.netMode == 1 && num233 == 0 && (Main.tile[num234, num235].frameX < 72 || Main.tile[num234, num235].frameX > 106) && (Main.tile[num234, num235].frameX < 144 || Main.tile[num234, num235].frameX > 178) && (Main.tile[num234, num235].frameX < 828 || Main.tile[num234, num235].frameX > 1006))
										{
											if (num234 == this.chestX && num235 == this.chestY && this.chest != -1)
											{
												this.chest = -1;
												Main.PlaySound(11, -1, -1, 1);
											}
											else
											{
												NetMessage.SendData(31, -1, -1, "", num234, (float)num235, 0f, 0f, 0);
											}
										}
										else
										{
											int num236 = -1;
											if (num233 == 1)
											{
												num236 = -2;
											}
											else if (num233 == 2)
											{
												num236 = -3;
											}
											else
											{
												bool flag49 = false;
												if ((Main.tile[num234, num235].frameX >= 72 && Main.tile[num234, num235].frameX <= 106) || (Main.tile[num234, num235].frameX >= 144 && Main.tile[num234, num235].frameX <= 178) || (Main.tile[num234, num235].frameX >= 828 && Main.tile[num234, num235].frameX <= 1006))
												{
													int num237 = 327;
													if (Main.tile[num234, num235].frameX >= 144 && Main.tile[num234, num235].frameX <= 178)
													{
														num237 = 329;
													}
													if (Main.tile[num234, num235].frameX >= 828 && Main.tile[num234, num235].frameX <= 1006)
													{
														int num238 = (int)(Main.tile[num234, num235].frameX / 18);
														int num239 = 0;
														while (num238 >= 2)
														{
															num238 -= 2;
															num239++;
														}
														num239 -= 23;
														num237 = 1533 + num239;
													}
													flag49 = true;
													for (int num240 = 0; num240 < 58; num240++)
													{
														if (this.inventory[num240].type == num237 && this.inventory[num240].stack > 0)
														{
															if (num237 != 329)
															{
																this.inventory[num240].stack--;
																if (this.inventory[num240].stack <= 0)
																{
																	this.inventory[num240] = new Item();
																}
															}
															Chest.Unlock(num234, num235);
															if (Main.netMode == 1)
															{
																NetMessage.SendData(52, -1, -1, "", this.whoAmi, 1f, (float)num234, (float)num235, 0);
															}
														}
													}
												}
												if (!flag49)
												{
													num236 = Chest.FindChest(num234, num235);
													Main.stackSplit = 600;
												}
											}
											if (num236 != -1)
											{
												if (num236 == this.chest)
												{
													this.chest = -1;
													Main.PlaySound(11, -1, -1, 1);
												}
												else if (num236 != this.chest && this.chest == -1)
												{
													this.chest = num236;
													Main.playerInventory = true;
													Main.PlaySound(10, -1, -1, 1);
													this.chestX = num234;
													this.chestY = num235;
												}
												else
												{
													this.chest = num236;
													Main.playerInventory = true;
													Main.PlaySound(12, -1, -1, 1);
													this.chestX = num234;
													this.chestY = num235;
												}
											}
										}
									}
								}
								this.releaseUseTile = false;
							}
							else
							{
								this.releaseUseTile = true;
							}
						}
					}
					if (this.tongued)
					{
						bool flag50 = false;
						if (Main.wof >= 0)
						{
							float num241 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2);
							num241 += (float)(Main.npc[Main.wof].direction * 200);
							float num242 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2);
							Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num243 = num241 - vector2.X;
							float num244 = num242 - vector2.Y;
							float num245 = (float)Math.Sqrt((double)(num243 * num243 + num244 * num244));
							float num246 = 11f;
							float num247;
							if (num245 > num246)
							{
								num247 = num246 / num245;
							}
							else
							{
								num247 = 1f;
								flag50 = true;
							}
							num243 *= num247;
							num244 *= num247;
							this.velocity.X = num243;
							this.velocity.Y = num244;
						}
						else
						{
							flag50 = true;
						}
						if (flag50 && Main.myPlayer == this.whoAmi)
						{
							for (int num248 = 0; num248 < 22; num248++)
							{
								if (this.buffType[num248] == 38)
								{
									this.DelBuff(num248);
								}
							}
						}
					}
					if (Main.myPlayer == this.whoAmi)
					{
						if (Main.wof >= 0 && Main.npc[Main.wof].active)
						{
							float num249 = Main.npc[Main.wof].position.X + 40f;
							if (Main.npc[Main.wof].direction > 0)
							{
								num249 -= 96f;
							}
							if (this.position.X + (float)this.width > num249 && this.position.X < num249 + 140f && this.gross)
							{
								this.noKnockback = false;
								this.Hurt(50, Main.npc[Main.wof].direction, false, false, " was slain...", false);
							}
							if (!this.gross && this.position.Y > (float)((Main.maxTilesY - 250) * 16) && this.position.X > num249 - 1920f && this.position.X < num249 + 1920f)
							{
								this.AddBuff(37, 10, true);
								Main.PlaySound(4, (int)Main.npc[Main.wof].position.X, (int)Main.npc[Main.wof].position.Y, 10);
							}
							if (this.gross)
							{
								if (this.position.Y < (float)((Main.maxTilesY - 200) * 16))
								{
									this.AddBuff(38, 10, true);
								}
								if (Main.npc[Main.wof].direction < 0)
								{
									if (this.position.X + (float)(this.width / 2) > Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) + 40f)
									{
										this.AddBuff(38, 10, true);
									}
								}
								else if (this.position.X + (float)(this.width / 2) < Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) - 40f)
								{
									this.AddBuff(38, 10, true);
								}
							}
							if (this.tongued)
							{
								this.controlHook = false;
								this.controlUseItem = false;
								for (int num250 = 0; num250 < 1000; num250++)
								{
									if (Main.projectile[num250].active && Main.projectile[num250].owner == Main.myPlayer && Main.projectile[num250].aiStyle == 7)
									{
										Main.projectile[num250].Kill();
									}
								}
								Vector2 vector3 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num251 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) - vector3.X;
								float num252 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2) - vector3.Y;
								float num253 = (float)Math.Sqrt((double)(num251 * num251 + num252 * num252));
								if (num253 > 3000f)
								{
									this.KillMe(1000.0, 0, false, " tried to escape.");
								}
								else if (Main.npc[Main.wof].position.X < 608f || Main.npc[Main.wof].position.X > (float)((Main.maxTilesX - 38) * 16))
								{
									this.KillMe(1000.0, 0, false, " was licked.");
								}
							}
						}
						if (this.controlHook)
						{
							if (this.releaseHook)
							{
								this.QuickGrapple();
							}
							this.releaseHook = false;
						}
						else
						{
							this.releaseHook = true;
						}
						if (this.talkNPC >= 0)
						{
							Rectangle rectangle = new Rectangle((int)(this.position.X + (float)(this.width / 2) - (float)(Player.tileRangeX * 16)), (int)(this.position.Y + (float)(this.height / 2) - (float)(Player.tileRangeY * 16)), Player.tileRangeX * 16 * 2, Player.tileRangeY * 16 * 2);
							Rectangle value = new Rectangle((int)Main.npc[this.talkNPC].position.X, (int)Main.npc[this.talkNPC].position.Y, Main.npc[this.talkNPC].width, Main.npc[this.talkNPC].height);
							if (!rectangle.Intersects(value) || this.chest != -1 || !Main.npc[this.talkNPC].active)
							{
								if (this.chest == -1)
								{
									Main.PlaySound(11, -1, -1, 1);
								}
								this.talkNPC = -1;
								Main.npcChatText = "";
							}
						}
						if (this.sign >= 0)
						{
							Rectangle rectangle2 = new Rectangle((int)(this.position.X + (float)(this.width / 2) - (float)(Player.tileRangeX * 16)), (int)(this.position.Y + (float)(this.height / 2) - (float)(Player.tileRangeY * 16)), Player.tileRangeX * 16 * 2, Player.tileRangeY * 16 * 2);
							try
							{
								Rectangle value2 = new Rectangle(Main.sign[this.sign].x * 16, Main.sign[this.sign].y * 16, 32, 32);
								if (!rectangle2.Intersects(value2))
								{
									Main.PlaySound(11, -1, -1, 1);
									this.sign = -1;
									Main.editSign = false;
									Main.npcChatText = "";
								}
							}
							catch
							{
								Main.PlaySound(11, -1, -1, 1);
								this.sign = -1;
								Main.editSign = false;
								Main.npcChatText = "";
							}
						}
						if (!this.immune)
						{
							Rectangle rectangle3 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
							for (int num254 = 0; num254 < 200; num254++)
							{
								if (Main.npc[num254].active && !Main.npc[num254].friendly && Main.npc[num254].damage > 0 && rectangle3.Intersects(new Rectangle((int)Main.npc[num254].position.X, (int)Main.npc[num254].position.Y, Main.npc[num254].width, Main.npc[num254].height)))
								{
									int num255 = -1;
									if (Main.npc[num254].position.X + (float)(Main.npc[num254].width / 2) < this.position.X + (float)(this.width / 2))
									{
										num255 = 1;
									}
									int num256 = Main.DamageVar((float)Main.npc[num254].damage);
									if (this.whoAmi == Main.myPlayer && this.thorns && !this.immune && !Main.npc[num254].dontTakeDamage)
									{
										int num257 = num256 / 3;
										int num258 = 10;
										if (this.turtleThorns)
										{
											num257 = num256;
										}
										Main.npc[num254].StrikeNPC(num257, (float)num258, -num255, false, false);
										if (Main.netMode != 0)
										{
											NetMessage.SendData(28, -1, -1, "", num254, (float)num257, (float)num258, (float)(-(float)num255), 0);
										}
									}
									if (!this.immune)
									{
										if (Main.npc[num254].type >= 269 && Main.npc[num254].type <= 272)
										{
											if (Main.rand.Next(3) == 0)
											{
												this.AddBuff(30, 600, true);
											}
											else if (Main.rand.Next(3) == 0)
											{
												this.AddBuff(32, 300, true);
											}
										}
										if (Main.npc[num254].type >= 273 && Main.npc[num254].type <= 276 && Main.rand.Next(2) == 0)
										{
											this.AddBuff(36, 600, true);
										}
										if (Main.npc[num254].type >= 277 && Main.npc[num254].type <= 280)
										{
											this.AddBuff(24, 600, true);
										}
										if (((Main.npc[num254].type == 1 && Main.npc[num254].name == "Black Slime") || Main.npc[num254].type == 81 || Main.npc[num254].type == 79) && Main.rand.Next(4) == 0)
										{
											this.AddBuff(22, 900, true);
										}
										if ((Main.npc[num254].type == 23 || Main.npc[num254].type == 25) && Main.rand.Next(3) == 0)
										{
											this.AddBuff(24, 420, true);
										}
										if ((Main.npc[num254].type == 34 || Main.npc[num254].type == 83 || Main.npc[num254].type == 84) && Main.rand.Next(3) == 0)
										{
											this.AddBuff(23, 240, true);
										}
										if ((Main.npc[num254].type == 104 || Main.npc[num254].type == 102) && Main.rand.Next(8) == 0)
										{
											this.AddBuff(30, 2700, true);
										}
										if (Main.npc[num254].type == 75 && Main.rand.Next(10) == 0)
										{
											this.AddBuff(35, 420, true);
										}
										if ((Main.npc[num254].type == 163 || Main.npc[num254].type == 238) && Main.rand.Next(10) == 0)
										{
											this.AddBuff(70, 480, true);
										}
										if ((Main.npc[num254].type == 79 || Main.npc[num254].type == 103) && Main.rand.Next(5) == 0)
										{
											this.AddBuff(35, 420, true);
										}
										if ((Main.npc[num254].type == 75 || Main.npc[num254].type == 78 || Main.npc[num254].type == 82) && Main.rand.Next(8) == 0)
										{
											this.AddBuff(32, 900, true);
										}
										if ((Main.npc[num254].type == 93 || Main.npc[num254].type == 109 || Main.npc[num254].type == 80) && Main.rand.Next(14) == 0)
										{
											this.AddBuff(31, 300, true);
										}
										if (Main.npc[num254].type >= 305 && Main.npc[num254].type <= 314 && Main.rand.Next(10) == 0)
										{
											this.AddBuff(33, 3600, true);
										}
										if (Main.npc[num254].type == 77 && Main.rand.Next(6) == 0)
										{
											this.AddBuff(36, 18000, true);
										}
										if (Main.npc[num254].type == 112 && Main.rand.Next(20) == 0)
										{
											this.AddBuff(33, 18000, true);
										}
										if (Main.npc[num254].type == 182 && Main.rand.Next(25) == 0)
										{
											this.AddBuff(33, 7200, true);
										}
										if (Main.npc[num254].type == 141 && Main.rand.Next(2) == 0)
										{
											this.AddBuff(20, 600, true);
										}
										if (Main.npc[num254].type == 147 && !Main.player[i].frozen && Main.rand.Next(12) == 0)
										{
											Main.player[i].AddBuff(46, 600, true);
										}
										if (Main.npc[num254].type == 150)
										{
											if (Main.rand.Next(2) == 0)
											{
												Main.player[i].AddBuff(46, 900, true);
											}
											if (!Main.player[i].frozen && Main.rand.Next(35) == 0)
											{
												Main.player[i].AddBuff(47, 60, true);
											}
										}
										if (Main.npc[num254].type == 184)
										{
											Main.player[i].AddBuff(46, 1200, true);
											if (!Main.player[i].frozen && Main.rand.Next(15) == 0)
											{
												Main.player[i].AddBuff(47, 60, true);
											}
										}
									}
									this.Hurt(num256, num255, false, false, Lang.deathMsg(-1, num254, -1, -1), false);
								}
							}
						}
						Vector2 vector4 = Collision.HurtTiles(this.position, this.velocity, this.width, this.height, this.fireWalk);
						if (vector4.Y == 20f)
						{
							this.AddBuff(67, 20, true);
						}
						else if (vector4.Y == 15f)
						{
							this.AddBuff(68, 1, true);
						}
						else if (vector4.Y != 0f)
						{
							int damage2 = Main.DamageVar(vector4.Y);
							this.Hurt(damage2, 0, false, false, Lang.deathMsg(-1, -1, -1, 3), false);
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
						this.wingTime = (float)this.GetWingTime();
						this.rocketTime = this.rocketTimeMax;
						this.rocketDelay = 0;
						this.rocketFrame = false;
						this.canRocket = false;
						this.rocketRelease = false;
						this.fallStart = (int)(this.position.Y / 16f);
						float num259 = 0f;
						float num260 = 0f;
						for (int num261 = 0; num261 < this.grapCount; num261++)
						{
							num259 += Main.projectile[this.grappling[num261]].position.X + (float)(Main.projectile[this.grappling[num261]].width / 2);
							num260 += Main.projectile[this.grappling[num261]].position.Y + (float)(Main.projectile[this.grappling[num261]].height / 2);
						}
						num259 /= (float)this.grapCount;
						num260 /= (float)this.grapCount;
						Vector2 vector5 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num262 = num259 - vector5.X;
						float num263 = num260 - vector5.Y;
						float num264 = (float)Math.Sqrt((double)(num262 * num262 + num263 * num263));
						float num265 = 11f;
						if (Main.projectile[this.grappling[0]].type == 315)
						{
							num265 = 16f;
						}
						float num266;
						if (num264 > num265)
						{
							num266 = num265 / num264;
						}
						else
						{
							num266 = 1f;
						}
						num262 *= num266;
						num263 *= num266;
						this.velocity.X = num262;
						this.velocity.Y = num263;
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
								for (int num267 = 0; num267 < 1000; num267++)
								{
									if (Main.projectile[num267].active && Main.projectile[num267].owner == i && Main.projectile[num267].aiStyle == 7)
									{
										Main.projectile[num267].Kill();
									}
								}
							}
						}
						else
						{
							this.releaseJump = true;
						}
					}
					int num268 = this.width / 2;
					int num269 = this.height / 2;
					new Vector2(this.position.X + (float)(this.width / 2) - (float)(num268 / 2), this.position.Y + (float)(this.height / 2) - (float)(num269 / 2));
					Vector2 vector6 = Collision.StickyTiles(this.position, this.velocity, this.width, this.height);
					if (vector6.Y != -1f && vector6.X != -1f)
					{
						int num270 = (int)vector6.X;
						int num271 = (int)vector6.Y;
						int type7 = (int)Main.tile[num270, num271].type;
						if (this.whoAmi == Main.myPlayer && type7 == 51 && (this.velocity.X != 0f || this.velocity.Y != 0f))
						{
							this.stickyBreak++;
							if (this.stickyBreak > Main.rand.Next(20, 100))
							{
								this.stickyBreak = 0;
								WorldGen.KillTile(num270, num271, false, false, false);
								if (Main.netMode == 1 && !Main.tile[num270, num271].active() && Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 0, (float)num270, (float)num271, 0f, 0);
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
							if ((float)(num270 * 16) < this.position.X + (float)(this.width / 2))
							{
								int num272 = Dust.NewDust(new Vector2(this.position.X - 4f, (float)(num271 * 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
								Main.dust[num272].scale += (float)Main.rand.Next(0, 6) * 0.1f;
								Main.dust[num272].velocity *= 0.1f;
								Main.dust[num272].noGravity = true;
							}
							else
							{
								int num273 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 2f, (float)(num271 * 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
								Main.dust[num273].scale += (float)Main.rand.Next(0, 6) * 0.1f;
								Main.dust[num273].velocity *= 0.1f;
								Main.dust[num273].noGravity = true;
							}
							if (Main.tile[num270, num271 + 1] != null && Main.tile[num270, num271 + 1].type == 229 && this.position.Y + (float)this.height > (float)((num271 + 1) * 16))
							{
								if ((float)(num270 * 16) < this.position.X + (float)(this.width / 2))
								{
									int num274 = Dust.NewDust(new Vector2(this.position.X - 4f, (float)(num271 * 16 + 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num274].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num274].velocity *= 0.1f;
									Main.dust[num274].noGravity = true;
								}
								else
								{
									int num275 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 2f, (float)(num271 * 16 + 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num275].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num275].velocity *= 0.1f;
									Main.dust[num275].noGravity = true;
								}
							}
							if (Main.tile[num270, num271 + 2] != null && Main.tile[num270, num271 + 2].type == 229 && this.position.Y + (float)this.height > (float)((num271 + 2) * 16))
							{
								if ((float)(num270 * 16) < this.position.X + (float)(this.width / 2))
								{
									int num276 = Dust.NewDust(new Vector2(this.position.X - 4f, (float)(num271 * 16 + 32)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num276].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num276].velocity *= 0.1f;
									Main.dust[num276].noGravity = true;
								}
								else
								{
									int num277 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 2f, (float)(num271 * 16 + 32)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num277].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num277].velocity *= 0.1f;
									Main.dust[num277].noGravity = true;
								}
							}
						}
					}
					else
					{
						this.stickyBreak = 0;
					}
					bool flag51 = Collision.DrownCollision(this.position, this.width, this.height, this.gravDir);
					if (this.armor[0].type == 250)
					{
						flag51 = true;
					}
					if (this.inventory[this.selectedItem].type == 186)
					{
						try
						{
							int num278 = (int)((this.position.X + (float)(this.width / 2) + (float)(6 * this.direction)) / 16f);
							int num279 = 0;
							if (this.gravDir == -1f)
							{
								num279 = this.height;
							}
							int num280 = (int)((this.position.Y + (float)num279 - 44f * this.gravDir) / 16f);
							if (Main.tile[num278, num280].liquid < 128)
							{
								if (Main.tile[num278, num280] == null)
								{
									Main.tile[num278, num280] = new Tile();
								}
								if (!Main.tile[num278, num280].active() || !Main.tileSolid[(int)Main.tile[num278, num280].type] || Main.tileSolidTop[(int)Main.tile[num278, num280].type])
								{
									flag51 = false;
								}
							}
						}
						catch
						{
						}
					}
					if (this.gills)
					{
						flag51 = false;
					}
					if (Main.myPlayer == i)
					{
						if (this.merman)
						{
							flag51 = false;
						}
						if (flag51)
						{
							this.breathCD++;
							int num281 = 7;
							if (this.inventory[this.selectedItem].type == 186)
							{
								num281 *= 2;
							}
							if (this.accDivingHelm)
							{
								num281 *= 4;
							}
							if (this.breathCD >= num281)
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
					if (flag51 && Main.rand.Next(20) == 0 && !this.lavaWet && !this.honeyWet)
					{
						int num282 = 0;
						if (this.gravDir == -1f)
						{
							num282 += this.height - 12;
						}
						if (this.inventory[this.selectedItem].type == 186)
						{
							Dust.NewDust(new Vector2(this.position.X + (float)(10 * this.direction) + 4f, this.position.Y + (float)num282 - 54f * this.gravDir), this.width - 8, 8, 34, 0f, 0f, 0, default(Color), 1.2f);
						}
						else
						{
							Dust.NewDust(new Vector2(this.position.X + (float)(12 * this.direction), this.position.Y + (float)num282 + 4f * this.gravDir), this.width - 8, 8, 34, 0f, 0f, 0, default(Color), 1.2f);
						}
					}
					if (this.gravDir == -1f)
					{
						this.waterWalk = false;
						this.waterWalk2 = false;
					}
					int num283 = this.height;
					if (this.waterWalk)
					{
						num283 -= 6;
					}
					bool flag52 = Collision.LavaCollision(this.position, this.width, num283);
					if (flag52)
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
					else if (this.lavaTime < this.lavaMax)
					{
						this.lavaTime++;
					}
					if (this.lavaTime > this.lavaMax)
					{
						this.lavaTime = this.lavaMax;
					}
					if (this.waterWalk2 && !this.waterWalk)
					{
						num283 -= 6;
					}
					bool flag53 = Collision.WetCollision(this.position, this.width, this.height);
					if (Collision.honey)
					{
						this.AddBuff(48, 1800, true);
						this.honeyWet = true;
					}
					if (flag53)
					{
						if (this.onFire && !this.lavaWet)
						{
							for (int num284 = 0; num284 < 22; num284++)
							{
								if (this.buffType[num284] == 24)
								{
									this.DelBuff(num284);
								}
							}
						}
						if (!this.wet)
						{
							if (this.wetCount == 0)
							{
								this.wetCount = 10;
								if (!flag52)
								{
									if (this.honeyWet)
									{
										for (int num285 = 0; num285 < 20; num285++)
										{
											int num286 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 152, 0f, 0f, 0, default(Color), 1f);
											Dust expr_14B12_cp_0 = Main.dust[num286];
											expr_14B12_cp_0.velocity.Y = expr_14B12_cp_0.velocity.Y - 1f;
											Dust expr_14B32_cp_0 = Main.dust[num286];
											expr_14B32_cp_0.velocity.X = expr_14B32_cp_0.velocity.X * 2.5f;
											Main.dust[num286].scale = 1.3f;
											Main.dust[num286].alpha = 100;
											Main.dust[num286].noGravity = true;
										}
										Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
									}
									else
									{
										for (int num287 = 0; num287 < 50; num287++)
										{
											int num288 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, Dust.dustWater(), 0f, 0f, 0, default(Color), 1f);
											Dust expr_14C33_cp_0 = Main.dust[num288];
											expr_14C33_cp_0.velocity.Y = expr_14C33_cp_0.velocity.Y - 3f;
											Dust expr_14C53_cp_0 = Main.dust[num288];
											expr_14C53_cp_0.velocity.X = expr_14C53_cp_0.velocity.X * 2.5f;
											Main.dust[num288].scale = 0.8f;
											Main.dust[num288].alpha = 100;
											Main.dust[num288].noGravity = true;
										}
										Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
									}
								}
								else
								{
									for (int num289 = 0; num289 < 20; num289++)
									{
										int num290 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
										Dust expr_14D51_cp_0 = Main.dust[num290];
										expr_14D51_cp_0.velocity.Y = expr_14D51_cp_0.velocity.Y - 1.5f;
										Dust expr_14D71_cp_0 = Main.dust[num290];
										expr_14D71_cp_0.velocity.X = expr_14D71_cp_0.velocity.X * 2.5f;
										Main.dust[num290].scale = 1.3f;
										Main.dust[num290].alpha = 100;
										Main.dust[num290].noGravity = true;
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
									for (int num291 = 0; num291 < 20; num291++)
									{
										int num292 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 152, 0f, 0f, 0, default(Color), 1f);
										Dust expr_14ED0_cp_0 = Main.dust[num292];
										expr_14ED0_cp_0.velocity.Y = expr_14ED0_cp_0.velocity.Y - 1f;
										Dust expr_14EF0_cp_0 = Main.dust[num292];
										expr_14EF0_cp_0.velocity.X = expr_14EF0_cp_0.velocity.X * 2.5f;
										Main.dust[num292].scale = 1.3f;
										Main.dust[num292].alpha = 100;
										Main.dust[num292].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
								else
								{
									for (int num293 = 0; num293 < 50; num293++)
									{
										int num294 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2)), this.width + 12, 24, Dust.dustWater(), 0f, 0f, 0, default(Color), 1f);
										Dust expr_14FEB_cp_0 = Main.dust[num294];
										expr_14FEB_cp_0.velocity.Y = expr_14FEB_cp_0.velocity.Y - 4f;
										Dust expr_1500B_cp_0 = Main.dust[num294];
										expr_1500B_cp_0.velocity.X = expr_1500B_cp_0.velocity.X * 2.5f;
										Main.dust[num294].scale = 0.8f;
										Main.dust[num294].alpha = 100;
										Main.dust[num294].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
								}
							}
							else
							{
								for (int num295 = 0; num295 < 20; num295++)
								{
									int num296 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
									Dust expr_15109_cp_0 = Main.dust[num296];
									expr_15109_cp_0.velocity.Y = expr_15109_cp_0.velocity.Y - 1.5f;
									Dust expr_15129_cp_0 = Main.dust[num296];
									expr_15129_cp_0.velocity.X = expr_15129_cp_0.velocity.X * 2.5f;
									Main.dust[num296].scale = 1.3f;
									Main.dust[num296].alpha = 100;
									Main.dust[num296].noGravity = true;
								}
								Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
							}
						}
					}
					if (!this.wet)
					{
						this.lavaWet = false;
						this.honeyWet = false;
					}
					if (this.wetCount > 0)
					{
						this.wetCount -= 1;
					}
					float num297 = 1f + Math.Abs(this.velocity.X) / 3f;
					if (this.gfxOffY > 0f)
					{
						this.gfxOffY -= num297 * this.stepSpeed;
						if (this.gfxOffY < 0f)
						{
							this.gfxOffY = 0f;
						}
					}
					else if (this.gfxOffY < 0f)
					{
						this.gfxOffY += num297 * this.stepSpeed;
						if (this.gfxOffY > 0f)
						{
							this.gfxOffY = 0f;
						}
					}
					if (this.gfxOffY > 16f)
					{
						this.gfxOffY = 16f;
					}
					if (this.gfxOffY < -16f)
					{
						this.gfxOffY = -16f;
					}
					if (Main.myPlayer == i && !this.iceSkate && this.velocity.Y > 7f)
					{
						Vector2 vector7 = this.position + this.velocity;
						int num298 = (int)(vector7.X / 16f);
						int num299 = (int)((vector7.X + (float)this.width) / 16f);
						int num300 = (int)((this.position.Y + (float)this.height + 1f) / 16f);
						for (int num301 = num298; num301 <= num299; num301++)
						{
							for (int num302 = num300; num302 <= num300 + 1; num302++)
							{
								if (Main.tile[num301, num302].nactive() && Main.tile[num301, num302].type == 162)
								{
									WorldGen.KillTile(num301, num302, false, false, false);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 0, (float)num301, (float)num302, 0f, 0);
									}
								}
							}
						}
					}
					this.sloping = false;
					float y3 = this.velocity.Y;
					Vector4 vector8 = Collision.WalkDownSlope(this.position, this.velocity, this.width, this.height, num2);
					this.position.X = vector8.X;
					this.position.Y = vector8.Y;
					this.velocity.X = vector8.Z;
					this.velocity.Y = vector8.W;
					if (this.velocity.Y != y3)
					{
						this.sloping = true;
					}
					if (this.velocity.Y == num2)
					{
						Vector2 vector9 = this.position;
						vector9.X += this.velocity.X;
						bool flag54 = false;
						int num303 = (int)(vector9.X / 16f);
						int num304 = (int)((vector9.X + (float)this.width) / 16f);
						int num305 = (int)((this.position.Y + (float)this.height + 4f) / 16f);
						float num306 = (float)((num305 + 3) * 16);
						for (int num307 = num303; num307 <= num304; num307++)
						{
							for (int num308 = num305; num308 <= num305 + 1; num308++)
							{
								if (Main.tile[num307, num308] == null)
								{
									Main.tile[num307, num308] = new Tile();
								}
								if (Main.tile[num307, num308].slope() != 0)
								{
									flag54 = true;
								}
								if (this.waterWalk2 || this.waterWalk)
								{
									if (Main.tile[num307, num308 - 1] == null)
									{
										Main.tile[num307, num308 - 1] = new Tile();
									}
									if (Main.tile[num307, num308].liquid > 0 && Main.tile[num307, num308 - 1].liquid == 0)
									{
										int num309 = (int)(Main.tile[num307, num308].liquid / 32 * 2 + 2);
										int num310 = num308 * 16 + 16 - num309;
										Rectangle rectangle4 = new Rectangle(num307 * 16, num308 * 16 - 17, 16, 16);
										if (rectangle4.Intersects(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height)) && (float)num310 < num306)
										{
											num306 = (float)num310;
										}
									}
								}
								if (Main.tile[num307, num308 - 1] == null)
								{
									Main.tile[num307, num308 - 1] = new Tile();
								}
								if (Main.tile[num307, num308].nactive() && (Main.tileSolid[(int)Main.tile[num307, num308].type] || Main.tileSolidTop[(int)Main.tile[num307, num308].type]))
								{
									int num311 = num308 * 16;
									if (Main.tile[num307, num308].halfBrick())
									{
										num311 += 8;
									}
									Rectangle rectangle5 = new Rectangle(num307 * 16, num308 * 16 - 17, 16, 16);
									if (rectangle5.Intersects(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height)) && (float)num311 < num306)
									{
										num306 = (float)num311;
									}
								}
							}
						}
						float num312 = num306 - (this.position.Y + (float)this.height);
						if (num312 > 7f && num312 < 17f && !flag54)
						{
							this.stepSpeed = 1.5f;
							if (num312 > 9f)
							{
								this.stepSpeed = 2.5f;
							}
							this.gfxOffY += this.position.Y + (float)this.height - num306;
							this.position.Y = num306 - (float)this.height;
						}
					}
					if (this.gravDir == -1f)
					{
						if ((this.carpetFrame != -1 || this.velocity.Y <= num2) && !this.controlUp)
						{
							int num313 = 0;
							if (this.velocity.X < 0f)
							{
								num313 = -1;
							}
							if (this.velocity.X > 0f)
							{
								num313 = 1;
							}
							Vector2 vector10 = this.position;
							vector10.X += this.velocity.X;
							int num314 = (int)((vector10.X + (float)(this.width / 2) + (float)((this.width / 2 + 1) * num313)) / 16f);
							int num315 = (int)(((double)vector10.Y + 0.1) / 16.0);
							if (Main.tile[num314, num315] == null)
							{
								Main.tile[num314, num315] = new Tile();
							}
							if (num315 - 1 > 0 && Main.tile[num314, num315 + 1] == null)
							{
								Main.tile[num314, num315 + 1] = new Tile();
							}
							if (num315 - 2 > 0 && Main.tile[num314, num315 + 2] == null)
							{
								Main.tile[num314, num315 + 2] = new Tile();
							}
							if (num315 - 3 > 0 && Main.tile[num314, num315 + 3] == null)
							{
								Main.tile[num314, num315 + 3] = new Tile();
							}
							if (num315 - 4 > 0 && Main.tile[num314, num315 + 4] == null)
							{
								Main.tile[num314, num315 + 4] = new Tile();
							}
							if (num315 - 3 > 0 && Main.tile[num314 - num313, num315 + 3] == null)
							{
								Main.tile[num314 - num313, num315 + 3] = new Tile();
							}
							if ((float)(num314 * 16) < vector10.X + (float)this.width && (float)(num314 * 16 + 16) > vector10.X && ((Main.tile[num314, num315].nactive() && ((Main.tileSolid[(int)Main.tile[num314, num315].type] && !Main.tileSolidTop[(int)Main.tile[num314, num315].type]) || (this.controlUp && Main.tileSolidTop[(int)Main.tile[num314, num315].type] && Main.tile[num314, num315].frameY == 0 && (!Main.tileSolid[(int)Main.tile[num314, num315 + 1].type] || !Main.tile[num314, num315 + 1].nactive())))) || (Main.tile[num314, num315 + 1].halfBrick() && Main.tile[num314, num315 + 1].nactive())) && (!Main.tile[num314, num315 + 1].nactive() || !Main.tileSolid[(int)Main.tile[num314, num315 + 1].type] || Main.tileSolidTop[(int)Main.tile[num314, num315 + 1].type] || Main.tile[num314, num315 + 1].slope() != 0 || (Main.tile[num314, num315 + 1].halfBrick() && (!Main.tile[num314, num315 + 4].nactive() || !Main.tileSolid[(int)Main.tile[num314, num315 + 4].type] || Main.tileSolidTop[(int)Main.tile[num314, num315 + 4].type]))) && (!Main.tile[num314, num315 + 2].nactive() || !Main.tileSolid[(int)Main.tile[num314, num315 + 2].type] || Main.tileSolidTop[(int)Main.tile[num314, num315 + 2].type]) && (!Main.tile[num314, num315 + 3].nactive() || !Main.tileSolid[(int)Main.tile[num314, num315 + 3].type] || Main.tileSolidTop[(int)Main.tile[num314, num315 + 3].type]) && (!Main.tile[num314 - num313, num315 + 3].nactive() || !Main.tileSolid[(int)Main.tile[num314 - num313, num315 + 3].type] || Main.tileSolidTop[(int)Main.tile[num314 - num313, num315 + 3].type]))
							{
								float num316 = (float)(num315 * 16 + 16);
								if (num316 > vector10.Y)
								{
									float num317 = num316 - vector10.Y;
									if ((double)num317 <= 16.1)
									{
										this.gfxOffY -= num316 - this.position.Y;
										this.position.Y = num316;
										this.velocity.Y = 0f;
										if (num317 < 9f)
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
						int num318 = 0;
						if (this.velocity.X < 0f)
						{
							num318 = -1;
						}
						if (this.velocity.X > 0f)
						{
							num318 = 1;
						}
						Vector2 vector11 = this.position;
						vector11.X += this.velocity.X;
						int num319 = (int)((vector11.X + (float)(this.width / 2) + (float)((this.width / 2 + 1) * num318)) / 16f);
						int num320 = (int)((vector11.Y + (float)this.height - 1f) / 16f);
						if (Main.tile[num319, num320] == null)
						{
							Main.tile[num319, num320] = new Tile();
						}
						if (num320 - 1 > 0 && Main.tile[num319, num320 - 1] == null)
						{
							Main.tile[num319, num320 - 1] = new Tile();
						}
						if (num320 - 2 > 0 && Main.tile[num319, num320 - 2] == null)
						{
							Main.tile[num319, num320 - 2] = new Tile();
						}
						if (num320 - 3 > 0 && Main.tile[num319, num320 - 3] == null)
						{
							Main.tile[num319, num320 - 3] = new Tile();
						}
						if (num320 - 4 > 0 && Main.tile[num319, num320 - 4] == null)
						{
							Main.tile[num319, num320 - 4] = new Tile();
						}
						if (num320 - 3 > 0 && Main.tile[num319 - num318, num320 - 3] == null)
						{
							Main.tile[num319 - num318, num320 - 3] = new Tile();
						}
						if ((float)(num319 * 16) < vector11.X + (float)this.width && (float)(num319 * 16 + 16) > vector11.X && ((Main.tile[num319, num320].nactive() && (Main.tile[num319, num320].slope() == 0 || (Main.tile[num319, num320].slope() == 1 && this.position.X + (float)(this.width / 2) < (float)(num319 * 16)) || (Main.tile[num319, num320].slope() == 2 && this.position.X + (float)(this.width / 2) > (float)(num319 * 16 + 16))) && (Main.tile[num319, num320 - 1].slope() == 0 || this.position.Y + (float)this.height > (float)(num320 * 16)) && ((Main.tileSolid[(int)Main.tile[num319, num320].type] && !Main.tileSolidTop[(int)Main.tile[num319, num320].type]) || (this.controlUp && ((Main.tileSolidTop[(int)Main.tile[num319, num320].type] && Main.tile[num319, num320].frameY == 0) || Main.tile[num319, num320].type == 19) && (!Main.tileSolid[(int)Main.tile[num319, num320 - 1].type] || !Main.tile[num319, num320 - 1].nactive())))) || (Main.tile[num319, num320 - 1].halfBrick() && Main.tile[num319, num320 - 1].nactive())) && (!Main.tile[num319, num320 - 1].nactive() || !Main.tileSolid[(int)Main.tile[num319, num320 - 1].type] || Main.tileSolidTop[(int)Main.tile[num319, num320 - 1].type] || (Main.tile[num319, num320 - 1].slope() == 1 && this.position.X + (float)(this.width / 2) > (float)(num319 * 16)) || (Main.tile[num319, num320 - 1].slope() == 2 && this.position.X + (float)(this.width / 2) < (float)(num319 * 16 + 16)) || (Main.tile[num319, num320 - 1].halfBrick() && (!Main.tile[num319, num320 - 4].nactive() || !Main.tileSolid[(int)Main.tile[num319, num320 - 4].type] || Main.tileSolidTop[(int)Main.tile[num319, num320 - 4].type]))) && (!Main.tile[num319, num320 - 2].nactive() || !Main.tileSolid[(int)Main.tile[num319, num320 - 2].type] || Main.tileSolidTop[(int)Main.tile[num319, num320 - 2].type]) && (!Main.tile[num319, num320 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num319, num320 - 3].type] || Main.tileSolidTop[(int)Main.tile[num319, num320 - 3].type]) && (!Main.tile[num319 - num318, num320 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num319 - num318, num320 - 3].type] || Main.tileSolidTop[(int)Main.tile[num319 - num318, num320 - 3].type]))
						{
							float num321 = (float)(num320 * 16);
							if (Main.tile[num319, num320].halfBrick())
							{
								num321 += 8f;
							}
							if (Main.tile[num319, num320 - 1].halfBrick())
							{
								num321 -= 8f;
							}
							if (num321 < vector11.Y + (float)this.height)
							{
								float num322 = vector11.Y + (float)this.height - num321;
								if ((double)num322 <= 16.1)
								{
									this.gfxOffY += this.position.Y + (float)this.height - num321;
									this.position.Y = num321 - (float)this.height;
									if (num322 < 9f)
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
					bool flag55 = false;
					if (this.velocity.Y > num2)
					{
						flag55 = true;
					}
					Vector2 vector12 = this.velocity;
					this.slideDir = 0;
					bool fall = false;
					bool fallThrough = this.controlDown;
					if (this.gravDir == -1f)
					{
						fall = true;
						fallThrough = true;
					}
					if (this.wings == 3 && this.controlUp && this.controlDown)
					{
						this.position += this.velocity;
					}
					else if (this.tongued)
					{
						this.position += this.velocity;
					}
					else if (this.honeyWet)
					{
						Vector2 vector13 = this.velocity;
						this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, fallThrough, fall);
						Vector2 value3 = this.velocity * 0.25f;
						if (this.velocity.X != vector13.X)
						{
							value3.X = this.velocity.X;
						}
						if (this.velocity.Y != vector13.Y)
						{
							value3.Y = this.velocity.Y;
						}
						this.position += value3;
					}
					else if (this.wet && !this.merman)
					{
						Vector2 vector14 = this.velocity;
						this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, fallThrough, fall);
						Vector2 value4 = this.velocity * 0.5f;
						if (this.velocity.X != vector14.X)
						{
							value4.X = this.velocity.X;
						}
						if (this.velocity.Y != vector14.Y)
						{
							value4.Y = this.velocity.Y;
						}
						this.position += value4;
					}
					else
					{
						this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, fallThrough, fall);
						if (Collision.up && this.gravDir == 1f)
						{
							this.jump = 0;
						}
						if (this.gravDir == -1f && this.velocity.Y >= 0f && (double)this.velocity.Y < 0.01)
						{
							this.velocity.Y = 0f;
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
					if (this.wings != 3 || !this.controlUp || !this.controlDown)
					{
						Vector4 vector15 = Collision.SlopeCollision(this.position, this.velocity, this.width, this.height, num2);
						this.position.X = vector15.X;
						this.position.Y = vector15.Y;
						this.velocity.X = vector15.Z;
						this.velocity.Y = vector15.W;
					}
					if (vector12.X != this.velocity.X)
					{
						if (vector12.X < 0f)
						{
							this.slideDir = -1;
						}
						else if (vector12.X > 0f)
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
					if (this.gravDir == -1f && this.velocity.Y > -1E-05f && this.velocity.Y < 1E-05f)
					{
						this.velocity.Y = 0f;
					}
					if (this.velocity.Y == 0f && this.grappling[0] == -1)
					{
						int num323 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
						int num324 = (int)((this.position.Y + (float)this.height) / 16f);
						int num325 = -1;
						if (Main.tile[num323 - 1, num324] == null)
						{
							Main.tile[num323 - 1, num324] = new Tile();
						}
						if (Main.tile[num323 + 1, num324] == null)
						{
							Main.tile[num323 + 1, num324] = new Tile();
						}
						if (Main.tile[num323, num324] == null)
						{
							Main.tile[num323, num324] = new Tile();
						}
						if (Main.tile[num323, num324].nactive() && Main.tileSolid[(int)Main.tile[num323, num324].type])
						{
							num325 = (int)Main.tile[num323, num324].type;
						}
						else if (Main.tile[num323 - 1, num324].nactive() && Main.tileSolid[(int)Main.tile[num323 - 1, num324].type])
						{
							num325 = (int)Main.tile[num323 - 1, num324].type;
						}
						else if (Main.tile[num323 + 1, num324].nactive() && Main.tileSolid[(int)Main.tile[num323 + 1, num324].type])
						{
							num325 = (int)Main.tile[num323 + 1, num324].type;
						}
						if (num325 > -1)
						{
							if (num325 == 229)
							{
								this.sticky = true;
							}
							else
							{
								this.sticky = false;
							}
							if (num325 == 161 || num325 == 162 || num325 == 163 || num325 == 164 || num325 == 200)
							{
								this.slippy = true;
							}
							else
							{
								this.slippy = false;
							}
							if (num325 == 197)
							{
								this.slippy2 = true;
							}
							else
							{
								this.slippy2 = false;
							}
							if (num325 == 198)
							{
								this.powerrun = true;
							}
							else
							{
								this.powerrun = false;
							}
							if (Main.tile[num323 - 1, num324].slope() != 0 || Main.tile[num323, num324].slope() != 0 || Main.tile[num323 + 1, num324].slope() != 0)
							{
								num325 = -1;
							}
							if (!this.wet && (num325 == 147 || num325 == 25 || num325 == 53 || num325 == 189 || num325 == 0 || num325 == 123 || num325 == 57 || num325 == 112 || num325 == 116 || num325 == 196 || num325 == 193 || num325 == 195 || num325 == 197 || num325 == 199 || num325 == 229))
							{
								int num326 = 1;
								if (flag55)
								{
									num326 = 20;
								}
								for (int num327 = 0; num327 < num326; num327++)
								{
									bool flag56 = true;
									int num328 = 76;
									if (num325 == 53)
									{
										num328 = 32;
									}
									if (num325 == 189)
									{
										num328 = 16;
									}
									if (num325 == 0)
									{
										num328 = 0;
									}
									if (num325 == 123)
									{
										num328 = 53;
									}
									if (num325 == 57)
									{
										num328 = 36;
									}
									if (num325 == 112)
									{
										num328 = 14;
									}
									if (num325 == 116)
									{
										num328 = 51;
									}
									if (num325 == 196)
									{
										num328 = 108;
									}
									if (num325 == 193)
									{
										num328 = 4;
									}
									if (num325 == 195 || num325 == 199)
									{
										num328 = 5;
									}
									if (num325 == 197)
									{
										num328 = 4;
									}
									if (num325 == 229)
									{
										num328 = 153;
									}
									if (num325 == 25)
									{
										num328 = 37;
									}
									if (num328 == 32 && Main.rand.Next(2) == 0)
									{
										flag56 = false;
									}
									if (num328 == 14 && Main.rand.Next(2) == 0)
									{
										flag56 = false;
									}
									if (num328 == 51 && Main.rand.Next(2) == 0)
									{
										flag56 = false;
									}
									if (num328 == 36 && Main.rand.Next(2) == 0)
									{
										flag56 = false;
									}
									if (num328 == 0 && Main.rand.Next(3) != 0)
									{
										flag56 = false;
									}
									if (num328 == 53 && Main.rand.Next(3) != 0)
									{
										flag56 = false;
									}
									Color newColor = default(Color);
									if (num325 == 193)
									{
										newColor = new Color(30, 100, 255, 100);
									}
									if (num325 == 197)
									{
										newColor = new Color(97, 200, 255, 100);
									}
									if (!flag55)
									{
										float num329 = Math.Abs(this.velocity.X) / 3f;
										if ((float)Main.rand.Next(100) > num329 * 100f)
										{
											flag56 = false;
										}
									}
									if (flag56)
									{
										float num330 = this.velocity.X;
										if (num330 > 6f)
										{
											num330 = 6f;
										}
										if (num330 < -6f)
										{
											num330 = -6f;
										}
										if (this.velocity.X != 0f || flag55)
										{
											int num331 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), this.width, 6, num328, 0f, 0f, 50, newColor, 1f);
											if (num328 == 76)
											{
												Main.dust[num331].scale += (float)Main.rand.Next(3) * 0.1f;
												Main.dust[num331].noLight = true;
											}
											if (num328 == 16 || num328 == 108 || num328 == 153)
											{
												Main.dust[num331].scale += (float)Main.rand.Next(6) * 0.1f;
											}
											if (num328 == 37)
											{
												Main.dust[num331].scale += 0.25f;
												Main.dust[num331].alpha = 50;
											}
											if (num328 == 5)
											{
												Main.dust[num331].scale += (float)Main.rand.Next(2, 8) * 0.1f;
											}
											Main.dust[num331].noGravity = true;
											if (num326 > 1)
											{
												Dust expr_172F2_cp_0 = Main.dust[num331];
												expr_172F2_cp_0.velocity.X = expr_172F2_cp_0.velocity.X * 1.2f;
												Dust expr_17312_cp_0 = Main.dust[num331];
												expr_17312_cp_0.velocity.Y = expr_17312_cp_0.velocity.Y * 0.8f;
												Dust expr_17332_cp_0 = Main.dust[num331];
												expr_17332_cp_0.velocity.Y = expr_17332_cp_0.velocity.Y - 1f;
												Main.dust[num331].velocity *= 0.8f;
												Main.dust[num331].scale += (float)Main.rand.Next(3) * 0.1f;
												Main.dust[num331].velocity.X = (Main.dust[num331].position.X - (this.position.X + (float)(this.width / 2))) * 0.2f;
												if (Main.dust[num331].velocity.Y > 0f)
												{
													Dust expr_173F8_cp_0 = Main.dust[num331];
													expr_173F8_cp_0.velocity.Y = expr_173F8_cp_0.velocity.Y * -1f;
												}
												Dust expr_17418_cp_0 = Main.dust[num331];
												expr_17418_cp_0.velocity.X = expr_17418_cp_0.velocity.X + num330 * 0.3f;
											}
											else
											{
												Main.dust[num331].velocity *= 0.2f;
											}
											Dust expr_1745E_cp_0 = Main.dust[num331];
											expr_1745E_cp_0.position.X = expr_1745E_cp_0.position.X - num330 * 1f;
										}
									}
								}
							}
						}
					}
					if (this.whoAmi == Main.myPlayer)
					{
						Collision.SwitchTiles(this.position, this.width, this.height, this.oldPosition, 1);
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
							goto IL_17642;
						}
						catch
						{
							goto IL_17642;
						}
					}
					this.ItemCheck(i);
					IL_17642:
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
				array[i] = (Item)this.inventory[i].Clone();
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
					this.inventory[num5] = (Item)array[num5].Clone();
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
				array[i] = (Item)this.inventory[i].Clone();
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
								this.inventory[num4] = (Item)array[num4].Clone();
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
			for (int i = 0; i < 255; i++)
			{
				this.oldAdjTile[i] = this.adjTile[i];
				this.adjTile[i] = false;
			}
			this.oldAdjWater = this.adjWater;
			this.adjWater = false;
			this.oldAdjHoney = this.adjHoney;
			this.adjHoney = false;
			int num3 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
			int num4 = (int)((this.position.Y + (float)this.height) / 16f);
			for (int j = num3 - num; j <= num3 + num; j++)
			{
				for (int k = num4 - num2; k < num4 + num2; k++)
				{
					if (Main.tile[j, k].active())
					{
						this.adjTile[(int)Main.tile[j, k].type] = true;
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
				}
			}
			if (Main.playerInventory)
			{
				bool flag = false;
				for (int l = 0; l < 255; l++)
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
				if (flag)
				{
					Recipe.FindRecipes();
				}
			}
		}
		public void PlayerFrame()
		{
			if (this.frozen)
			{
				return;
			}
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
			if (Main.myPlayer == this.whoAmi)
			{
				bool flag = false;
				if (this.wings == 3 || (this.wings >= 16 && this.wings <= 19))
				{
					flag = true;
				}
				else if (this.head == 45 || (this.head >= 106 && this.head <= 110))
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
			}
			this.socialShadow = false;
			this.socialGhost = false;
			if (this.head == 101 && this.body == 66 && this.legs == 55)
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
			if (((this.body == 68 && this.legs == 57 && this.head == 106) || (this.body == 74 && this.legs == 63 && this.head == 106)) && Main.rand.Next(10) == 0)
			{
				int num = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 43, 0f, 0f, 100, new Color(255, 0, 255), 0.3f);
				Main.dust[num].fadeIn = 0.8f;
				Main.dust[num].noGravity = true;
				Main.dust[num].velocity *= 2f;
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
					int num2 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 115, 0f, 0f, 140, default(Color), 0.75f);
					Main.dust[num2].noGravity = true;
					Main.dust[num2].fadeIn = 1.5f;
					Main.dust[num2].velocity *= 0.3f;
					Main.dust[num2].velocity += this.velocity * 0.2f;
				}
			}
			if (this.head == 6 && this.body == 6 && this.legs == 6 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 1f && !this.rocketFrame)
			{
				for (int i = 0; i < 2; i++)
				{
					int num3 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num3].noGravity = true;
					Main.dust[num3].noLight = true;
					Dust expr_7B6_cp_0 = Main.dust[num3];
					expr_7B6_cp_0.velocity.X = expr_7B6_cp_0.velocity.X - this.velocity.X * 0.5f;
					Dust expr_7E0_cp_0 = Main.dust[num3];
					expr_7E0_cp_0.velocity.Y = expr_7E0_cp_0.velocity.Y - this.velocity.Y * 0.5f;
				}
			}
			if (this.head == 8 && this.body == 8 && this.legs == 8 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 1f)
			{
				int num4 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 40, 0f, 0f, 50, default(Color), 1.4f);
				Main.dust[num4].noGravity = true;
				Main.dust[num4].velocity.X = this.velocity.X * 0.25f;
				Main.dust[num4].velocity.Y = this.velocity.Y * 0.25f;
			}
			if (this.head == 9 && this.body == 9 && this.legs == 9 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 1f && !this.rocketFrame)
			{
				for (int j = 0; j < 2; j++)
				{
					int num5 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num5].noGravity = true;
					Main.dust[num5].noLight = true;
					Dust expr_A25_cp_0 = Main.dust[num5];
					expr_A25_cp_0.velocity.X = expr_A25_cp_0.velocity.X - this.velocity.X * 0.5f;
					Dust expr_A4F_cp_0 = Main.dust[num5];
					expr_A4F_cp_0.velocity.Y = expr_A4F_cp_0.velocity.Y - this.velocity.Y * 0.5f;
				}
			}
			if (this.body == 18 && this.legs == 17 && (this.head == 32 || this.head == 33 || this.head == 34) && Main.rand.Next(10) == 0)
			{
				int num6 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 43, 0f, 0f, 100, default(Color), 0.3f);
				Main.dust[num6].fadeIn = 0.8f;
				Main.dust[num6].velocity *= 0f;
			}
			if (this.body == 24 && this.legs == 23 && (this.head == 42 || this.head == 43 || this.head == 41) && this.velocity.X != 0f && this.velocity.Y != 0f && Main.rand.Next(10) == 0)
			{
				int num7 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 43, 0f, 0f, 100, default(Color), 0.3f);
				Main.dust[num7].fadeIn = 0.8f;
				Main.dust[num7].velocity *= 0f;
			}
			if (this.body == 36 && this.head == 56 && this.velocity.X != 0f && this.velocity.Y == 0f)
			{
				for (int k = 0; k < 2; k++)
				{
					int num8 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), this.width, 6, 106, 0f, 0f, 100, default(Color), 0.1f);
					Main.dust[num8].fadeIn = 1f;
					Main.dust[num8].noGravity = true;
					Main.dust[num8].velocity *= 0.2f;
				}
			}
			if (this.body == 27 && this.head == 46 && this.legs == 26)
			{
				this.frostArmor = true;
				if (this.velocity.X != 0f && this.velocity.Y == 0f && this.miscCounter % 2 == 0)
				{
					for (int l = 0; l < 2; l++)
					{
						int num9;
						if (l == 0)
						{
							num9 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
						}
						else
						{
							num9 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
						}
						Main.dust[num9].scale *= 1f + (float)Main.rand.Next(20, 40) * 0.01f;
						Main.dust[num9].noGravity = true;
						Main.dust[num9].noLight = true;
						Main.dust[num9].velocity *= 0.001f;
						Dust expr_F0D_cp_0 = Main.dust[num9];
						expr_F0D_cp_0.velocity.Y = expr_F0D_cp_0.velocity.Y - 0.003f;
					}
				}
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
						float num10 = this.itemRotation * (float)this.direction;
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
						if ((double)num10 < -0.75)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 2;
							if (this.gravDir == -1f)
							{
								this.bodyFrame.Y = this.bodyFrame.Height * 4;
							}
						}
						if ((double)num10 > 0.6)
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
				float num11 = 0f;
				float num12 = 0f;
				for (int m = 0; m < this.grapCount; m++)
				{
					num11 += Main.projectile[this.grappling[m]].position.X + (float)(Main.projectile[this.grappling[m]].width / 2);
					num12 += Main.projectile[this.grappling[m]].position.Y + (float)(Main.projectile[this.grappling[m]].height / 2);
				}
				num11 /= (float)this.grapCount;
				num12 /= (float)this.grapCount;
				num11 -= vector.X;
				num12 -= vector.Y;
				if (num12 < 0f && Math.Abs(num12) > Math.Abs(num11))
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 2;
					if (this.gravDir == -1f)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 4;
					}
				}
				else if (num12 > 0f && Math.Abs(num12) > Math.Abs(num11))
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
								int num13 = Dust.NewDust(new Vector2(this.Center().X - 22f, this.position.Y + (float)this.height - 6f), 20, 10, 64, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 255, default(Color), 1f);
								Main.dust[num13].velocity *= 0.1f;
								Main.dust[num13].noLight = true;
							}
							if (Main.rand.Next(4) == 0)
							{
								int num14 = Dust.NewDust(new Vector2(this.Center().X + 12f, this.position.Y + (float)this.height - 6f), 20, 10, 64, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 255, default(Color), 1f);
								Main.dust[num14].velocity *= 0.1f;
								Main.dust[num14].noLight = true;
							}
						}
						else
						{
							if (Main.rand.Next(4) == 0)
							{
								int num15 = Dust.NewDust(new Vector2(this.Center().X - 32f, this.position.Y + (float)this.height - 6f), 20, 10, 64, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 255, default(Color), 1f);
								Main.dust[num15].velocity *= 0.1f;
								Main.dust[num15].noLight = true;
							}
							if (Main.rand.Next(4) == 0)
							{
								int num16 = Dust.NewDust(new Vector2(this.Center().X + 2f, this.position.Y + (float)this.height - 6f), 20, 10, 64, this.velocity.X * 0.25f, this.velocity.Y * 0.25f, 255, default(Color), 1f);
								Main.dust[num16].velocity *= 0.1f;
								Main.dust[num16].noLight = true;
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
					this.direction *= -1;
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
				for (int i = 0; i < 21; i++)
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
				if (this.magicCuffs)
				{
					int num3 = num;
					this.statMana += num3;
					if (this.statMana > this.statManaMax2)
					{
						this.statMana = this.statManaMax2;
					}
					this.ManaEffect(num3);
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
							float num4 = this.position.X - Main.player[myPlayer].position.X;
							float num5 = this.position.Y - Main.player[myPlayer].position.Y;
							float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
							if (num6 < 800f)
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
					int num7 = 0;
					if (pvp)
					{
						num7 = 1;
					}
					NetMessage.SendData(13, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
					NetMessage.SendData(16, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
					NetMessage.SendData(26, -1, -1, "", this.whoAmi, (float)hitDirection, (float)Damage, (float)num7, number);
				}
				CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(255, 80, 90, 255), string.Concat((int)num2), Crit, false);
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
						for (int i = 0; i < 3; i++)
						{
							float x = this.position.X + (float)Main.rand.Next(-400, 400);
							float y = this.position.Y - (float)Main.rand.Next(500, 800);
							Vector2 vector = new Vector2(x, y);
							float num8 = this.position.X + (float)(this.width / 2) - vector.X;
							float num9 = this.position.Y + (float)(this.height / 2) - vector.Y;
							num8 += (float)Main.rand.Next(-100, 101);
							int num10 = 23;
							float num11 = (float)Math.Sqrt((double)(num8 * num8 + num9 * num9));
							num11 = (float)num10 / num11;
							num8 *= num11;
							num9 *= num11;
							int num12 = Projectile.NewProjectile(x, y, num8, num9, 92, 30, 5f, this.whoAmi, 0f, 0f);
							Main.projectile[num12].ai[1] = this.position.Y;
						}
					}
					if (this.bee)
					{
						int num13 = 1;
						if (Main.rand.Next(3) == 0)
						{
							num13++;
						}
						if (Main.rand.Next(3) == 0)
						{
							num13++;
						}
						for (int j = 0; j < num13; j++)
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
					int num14 = 0;
					while ((double)num14 < num2 / (double)this.statLifeMax * 100.0)
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
						num14++;
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
						ItemText.NewText(newItem, newItem.stack);
						this.DoCoins(i);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						return new Item();
					}
					newItem.stack -= this.inventory[i].maxStack - this.inventory[i].stack;
					ItemText.NewText(newItem, this.inventory[i].maxStack - this.inventory[i].stack);
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
						ItemText.NewText(newItem, newItem.stack);
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
						ItemText.NewText(newItem, item.stack);
						this.DoCoins(num3);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						return new Item();
					}
					item.stack -= this.inventory[num3].maxStack - this.inventory[num3].stack;
					ItemText.NewText(newItem, this.inventory[num3].maxStack - this.inventory[num3].stack);
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
						ItemText.NewText(newItem, newItem.stack);
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
					ItemText.NewText(newItem, newItem.stack);
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
							int k = (int)(Main.tile[num13, num14].frameX / 18);
							int num16 = 0;
							int num17 = 0;
							while (k >= 4)
							{
								num16++;
								k -= 4;
							}
							k = num13 - k;
							int l;
							for (l = (int)(Main.tile[num13, num14].frameY / 18); l >= 3; l -= 3)
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
					this.inventory[this.selectedItem].stack--;
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
					if (Main.rand.Next(5000) == 0)
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
				if (flag2 && ((!Main.tile[Player.tileTargetX, Player.tileTargetY].active() && !flag) || Main.tileCut[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || this.inventory[this.selectedItem].createTile == 23 || this.inventory[this.selectedItem].createTile == 2 || this.inventory[this.selectedItem].createTile == 109 || this.inventory[this.selectedItem].createTile == 60 || this.inventory[this.selectedItem].createTile == 70) && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
				{
					bool flag3 = false;
					if (this.inventory[this.selectedItem].createTile == 23 || this.inventory[this.selectedItem].createTile == 2 || this.inventory[this.selectedItem].createTile == 109)
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
							if (!WorldGen.SolidTileNotDoor(Player.tileTargetX, Player.tileTargetY + 1) && !WorldGen.SolidTileNotDoor(Player.tileTargetX - 1, Player.tileTargetY) && !WorldGen.SolidTileNotDoor(Player.tileTargetX + 1, Player.tileTargetY))
							{
								if (!WorldGen.SolidTileNotDoor(Player.tileTargetX, Player.tileTargetY + 1) && (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].halfBrick() || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].slope() != 0))
								{
									WorldGen.SlopeTile(Player.tileTargetX, Player.tileTargetY + 1, 0);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 14, (float)Player.tileTargetX, (float)(Player.tileTargetY + 1), 0f, 0);
									}
								}
								else if (!WorldGen.SolidTileNotDoor(Player.tileTargetX, Player.tileTargetY + 1) && !WorldGen.SolidTileNotDoor(Player.tileTargetX - 1, Player.tileTargetY) && (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].halfBrick() || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].slope() != 0))
								{
									WorldGen.SlopeTile(Player.tileTargetX - 1, Player.tileTargetY, 0);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 14, (float)(Player.tileTargetX - 1), (float)Player.tileTargetY, 0f, 0);
									}
								}
								else if (!WorldGen.SolidTileNotDoor(Player.tileTargetX, Player.tileTargetY + 1) && !WorldGen.SolidTileNotDoor(Player.tileTargetX - 1, Player.tileTargetY) && !WorldGen.SolidTileNotDoor(Player.tileTargetX + 1, Player.tileTargetY) && (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].halfBrick() || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].slope() != 0))
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
					if (flag3)
					{
						int num45 = this.inventory[this.selectedItem].placeStyle;
						if (this.inventory[this.selectedItem].createTile == 36)
						{
							num45 = Main.rand.Next(7);
						}
						if (this.inventory[this.selectedItem].createTile == 212 && this.direction > 0)
						{
							num45 = 1;
						}
						if (this.inventory[this.selectedItem].createTile == 141)
						{
							num45 = Main.rand.Next(2);
						}
						if (this.inventory[this.selectedItem].createTile == 128)
						{
							if (this.direction < 0)
							{
								num45 = -1;
							}
							else
							{
								num45 = 1;
							}
						}
						if (this.inventory[this.selectedItem].createTile == 241 && this.inventory[this.selectedItem].placeStyle == 0)
						{
							num45 = Main.rand.Next(0, 9);
						}
						if (this.inventory[this.selectedItem].createTile == 35 && this.inventory[this.selectedItem].placeStyle == 0)
						{
							num45 = Main.rand.Next(9);
						}
						if (WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createTile, false, false, this.whoAmi, num45))
						{
							this.itemTime = this.inventory[this.selectedItem].useTime;
							if (Main.netMode == 1)
							{
								NetMessage.SendData(17, -1, -1, "", 1, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.inventory[this.selectedItem].createTile, num45);
							}
							if (this.inventory[this.selectedItem].createTile == 15)
							{
								if (this.direction == 1)
								{
									Tile expr_2B49 = Main.tile[Player.tileTargetX, Player.tileTargetY];
									expr_2B49.frameX += 18;
									Tile expr_2B6E = Main.tile[Player.tileTargetX, Player.tileTargetY - 1];
									expr_2B6E.frameX += 18;
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
									Tile expr_2BD8 = Main.tile[Player.tileTargetX, Player.tileTargetY];
									expr_2BD8.frameX += 18;
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
							if (Main.tileSolid[this.inventory[this.selectedItem].createTile])
							{
								int num46 = Player.tileTargetX;
								int num47 = Player.tileTargetY + 1;
								if (Main.tile[num46, num47] != null && (Main.tile[num46, num47].slope() != 0 || Main.tile[num46, num47].halfBrick()))
								{
									WorldGen.SlopeTile(num46, num47, 0);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 14, (float)num46, (float)num47, 0f, 0);
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
						this.itemTime = this.inventory[this.selectedItem].useTime;
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 3, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.inventory[this.selectedItem].createWall, 0);
						}
						if (this.inventory[this.selectedItem].stack > 1)
						{
							int createWall = this.inventory[this.selectedItem].createWall;
							for (int n = 0; n < 4; n++)
							{
								int num48 = Player.tileTargetX;
								int num49 = Player.tileTargetY;
								if (n == 0)
								{
									num48--;
								}
								if (n == 1)
								{
									num48++;
								}
								if (n == 2)
								{
									num49--;
								}
								if (n == 3)
								{
									num49++;
								}
								if (Main.tile[num48, num49].wall == 0)
								{
									int num50 = 0;
									for (int num51 = 0; num51 < 4; num51++)
									{
										int num52 = num48;
										int num53 = num49;
										if (num51 == 0)
										{
											num52--;
										}
										if (num51 == 1)
										{
											num52++;
										}
										if (num51 == 2)
										{
											num53--;
										}
										if (num51 == 3)
										{
											num53++;
										}
										if ((int)Main.tile[num52, num53].wall == createWall)
										{
											num50++;
										}
									}
									if (num50 == 4)
									{
										WorldGen.PlaceWall(num48, num49, createWall, false);
										if ((int)Main.tile[num48, num49].wall == createWall)
										{
											this.inventory[this.selectedItem].stack--;
											if (this.inventory[this.selectedItem].stack == 0)
											{
												this.inventory[this.selectedItem].SetDefaults(0, false);
											}
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 3, (float)num48, (float)num49, (float)createWall, 0);
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
		public void ItemCheck(int i)
		{
			if (this.frozen)
			{
				return;
			}
			bool flag = false;
			int num = this.inventory[this.selectedItem].damage;
			if (num > 0)
			{
				if (this.inventory[this.selectedItem].melee)
				{
					num = (int)((float)num * this.meleeDamage);
				}
				else if (this.inventory[this.selectedItem].ranged)
				{
					num = (int)((float)num * this.rangedDamage);
					if (this.inventory[this.selectedItem].useAmmo == 1 || this.inventory[this.selectedItem].useAmmo == 323)
					{
						num = (int)((float)num * this.arrowDamage);
					}
					if (this.inventory[this.selectedItem].useAmmo == 14 || this.inventory[this.selectedItem].useAmmo == 311)
					{
						num = (int)((float)num * this.bulletDamage);
					}
					if (this.inventory[this.selectedItem].useAmmo == 771 || this.inventory[this.selectedItem].useAmmo == 246 || this.inventory[this.selectedItem].useAmmo == 312)
					{
						num = (int)((float)num * this.rocketDamage);
					}
				}
				else if (this.inventory[this.selectedItem].magic)
				{
					num = (int)((float)num * this.magicDamage);
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
					int num2 = Player.tileTargetX;
					int num3 = Player.tileTargetY;
					if (Main.tile[num2, num3].active() && Main.tile[num2, num3].type == 128)
					{
						int num4 = (int)Main.tile[num2, num3].frameY;
						int j = 0;
						if (this.inventory[this.selectedItem].bodySlot >= 0)
						{
							j = 1;
						}
						if (this.inventory[this.selectedItem].legSlot >= 0)
						{
							j = 2;
						}
						num4 /= 18;
						while (j > num4)
						{
							num3++;
							num4 = (int)Main.tile[num2, num3].frameY;
							num4 /= 18;
						}
						while (j < num4)
						{
							num3--;
							num4 = (int)Main.tile[num2, num3].frameY;
							num4 /= 18;
						}
						int k;
						for (k = (int)Main.tile[num2, num3].frameX; k >= 100; k -= 100)
						{
						}
						if (k >= 36)
						{
							k -= 36;
						}
						num2 -= k / 18;
						int l = (int)Main.tile[num2, num3].frameX;
						WorldGen.KillTile(num2, num3, true, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 0, (float)num2, (float)num3, 1f, 0);
						}
						while (l >= 100)
						{
							l -= 100;
						}
						if (num4 == 0 && this.inventory[this.selectedItem].headSlot >= 0)
						{
							Main.tile[num2, num3].frameX = (short)(l + this.inventory[this.selectedItem].headSlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num2, num3, 1);
							}
							this.inventory[this.selectedItem].SetDefaults(0, false);
							Main.mouseItem.SetDefaults(0, false);
							this.releaseUseItem = false;
							this.mouseInterface = true;
						}
						else if (num4 == 1 && this.inventory[this.selectedItem].bodySlot >= 0)
						{
							Main.tile[num2, num3].frameX = (short)(l + this.inventory[this.selectedItem].bodySlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num2, num3, 1);
							}
							this.inventory[this.selectedItem].SetDefaults(0, false);
							Main.mouseItem.SetDefaults(0, false);
							this.releaseUseItem = false;
							this.mouseInterface = true;
						}
						else if (num4 == 2 && this.inventory[this.selectedItem].legSlot >= 0)
						{
							Main.tile[num2, num3].frameX = (short)(l + this.inventory[this.selectedItem].legSlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num2, num3, 1);
							}
							this.inventory[this.selectedItem].SetDefaults(0, false);
							Main.mouseItem.SetDefaults(0, false);
							this.releaseUseItem = false;
							this.mouseInterface = true;
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
					for (int num5 = 0; num5 < 1000; num5++)
					{
						if (Main.projectile[num5].active && Main.projectile[num5].owner == Main.myPlayer && Main.projectile[num5].type == this.inventory[this.selectedItem].shoot)
						{
							flag2 = false;
						}
					}
				}
				if (this.inventory[this.selectedItem].shoot == 106)
				{
					int num6 = 0;
					for (int num7 = 0; num7 < 1000; num7++)
					{
						if (Main.projectile[num7].active && Main.projectile[num7].owner == Main.myPlayer && Main.projectile[num7].type == this.inventory[this.selectedItem].shoot)
						{
							num6++;
						}
					}
					if (num6 >= this.inventory[this.selectedItem].stack)
					{
						flag2 = false;
					}
				}
				if (this.inventory[this.selectedItem].shoot == 272)
				{
					int num8 = 0;
					for (int num9 = 0; num9 < 1000; num9++)
					{
						if (Main.projectile[num9].active && Main.projectile[num9].owner == Main.myPlayer && Main.projectile[num9].type == this.inventory[this.selectedItem].shoot)
						{
							num8++;
						}
					}
					if (num8 >= this.inventory[this.selectedItem].stack)
					{
						flag2 = false;
					}
				}
				if (this.inventory[this.selectedItem].shoot == 13 || this.inventory[this.selectedItem].shoot == 32 || (this.inventory[this.selectedItem].shoot >= 230 && this.inventory[this.selectedItem].shoot <= 235) || this.inventory[this.selectedItem].shoot == 315 || this.inventory[this.selectedItem].shoot == 331)
				{
					for (int num10 = 0; num10 < 1000; num10++)
					{
						if (Main.projectile[num10].active && Main.projectile[num10].owner == Main.myPlayer && Main.projectile[num10].type == this.inventory[this.selectedItem].shoot && Main.projectile[num10].ai[0] != 2f)
						{
							flag2 = false;
						}
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
					this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
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
				if (this.inventory[this.selectedItem].type == 1844 && (Main.dayTime || Main.pumpkinMoon || this.snowman))
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].type == 1958 && (Main.dayTime || Main.pumpkinMoon || this.snowman))
				{
					flag2 = false;
				}
				if (this.inventory[this.selectedItem].shoot == 17 && flag2 && i == Main.myPlayer)
				{
					int num11 = (int)((float)Main.mouseX + Main.screenPosition.X) / 16;
					int num12 = (int)((float)Main.mouseY + Main.screenPosition.Y) / 16;
					if (Main.tile[num11, num12].active() && (Main.tile[num11, num12].type == 0 || Main.tile[num11, num12].type == 2 || Main.tile[num11, num12].type == 23))
					{
						WorldGen.KillTile(num11, num12, false, false, true);
						if (!Main.tile[num11, num12].active())
						{
							if (Main.netMode == 1)
							{
								NetMessage.SendData(17, -1, -1, "", 4, (float)num11, (float)num12, 0f, 0);
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
					for (int num13 = 0; num13 < 58; num13++)
					{
						if (this.inventory[num13].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[num13].stack > 0)
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
						int num14 = 0;
						int num15 = -1;
						int num16 = -1;
						for (int num17 = 0; num17 < 1000; num17++)
						{
							if (Main.projectile[num17].active && Main.projectile[num17].owner == i && Main.projectile[num17].minion)
							{
								num14++;
								if (num15 == -1 || Main.projectile[num17].timeLeft < num15)
								{
									num16 = num17;
									num15 = Main.projectile[num17].timeLeft;
								}
							}
						}
						if (num14 >= this.maxMinions)
						{
							Main.projectile[num16].Kill();
						}
					}
					else
					{
						for (int num18 = 0; num18 < 1000; num18++)
						{
							if (Main.projectile[num18].active && Main.projectile[num18].owner == i && Main.projectile[num18].type == this.inventory[this.selectedItem].shoot)
							{
								Main.projectile[num18].Kill();
							}
							if (this.inventory[this.selectedItem].shoot == 72)
							{
								if (Main.projectile[num18].active && Main.projectile[num18].owner == i && Main.projectile[num18].type == 86)
								{
									Main.projectile[num18].Kill();
								}
								if (Main.projectile[num18].active && Main.projectile[num18].owner == i && Main.projectile[num18].type == 87)
								{
									Main.projectile[num18].Kill();
								}
							}
						}
					}
				}
			}
			if (!this.controlUseItem)
			{
				bool arg_1B1B_0 = this.channel;
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
			if ((((this.inventory[this.selectedItem].type == 974 || this.inventory[this.selectedItem].type == 8 || this.inventory[this.selectedItem].type == 1245 || (this.inventory[this.selectedItem].type >= 427 && this.inventory[this.selectedItem].type <= 433)) && !this.wet) || this.inventory[this.selectedItem].type == 523 || this.inventory[this.selectedItem].type == 1333) && !this.pulley && this.mount == 0)
			{
				float r = 1f;
				float g = 0.95f;
				float b = 0.8f;
				int num35 = 0;
				if (this.inventory[this.selectedItem].type == 523)
				{
					num35 = 8;
				}
				else if (this.inventory[this.selectedItem].type == 974)
				{
					num35 = 9;
				}
				else if (this.inventory[this.selectedItem].type == 1245)
				{
					num35 = 10;
				}
				else if (this.inventory[this.selectedItem].type == 1333)
				{
					num35 = 11;
				}
				else if (this.inventory[this.selectedItem].type >= 427)
				{
					num35 = this.inventory[this.selectedItem].type - 426;
				}
				if (num35 == 1)
				{
					r = 0f;
					g = 0.1f;
					b = 1.3f;
				}
				else if (num35 == 2)
				{
					r = 1f;
					g = 0.1f;
					b = 0.1f;
				}
				else if (num35 == 3)
				{
					r = 0f;
					g = 1f;
					b = 0.1f;
				}
				else if (num35 == 4)
				{
					r = 0.9f;
					g = 0f;
					b = 0.9f;
				}
				else if (num35 == 5)
				{
					r = 1.3f;
					g = 1.3f;
					b = 1.3f;
				}
				else if (num35 == 6)
				{
					r = 0.9f;
					g = 0.9f;
					b = 0f;
				}
				else if (num35 == 7)
				{
					r = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
					g = 0.3f;
					b = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
				}
				else if (num35 == 8)
				{
					b = 0.7f;
					r = 0.85f;
					g = 1f;
				}
				else if (num35 == 9)
				{
					b = 1f;
					r = 0.7f;
					g = 0.85f;
				}
				else if (num35 == 10)
				{
					b = 0f;
					r = 1f;
					g = 0.5f;
				}
				else if (num35 == 11)
				{
					b = 0.8f;
					r = 1.25f;
					g = 1.25f;
				}
				int num36 = num35;
				if (num36 == 0)
				{
					num36 = 6;
				}
				else if (num36 == 8)
				{
					num36 = 75;
				}
				else if (num36 == 9)
				{
					num36 = 135;
				}
				else if (num36 == 10)
				{
					num36 = 158;
				}
				else if (num36 == 11)
				{
					num36 = 169;
				}
				else
				{
					num36 = 58 + num36;
				}
				int maxValue = 30;
				if (this.itemAnimation > 0)
				{
					maxValue = 7;
				}
				if (this.direction == -1)
				{
					if (Main.rand.Next(maxValue) == 0)
					{
						int num37 = Dust.NewDust(new Vector2(this.itemLocation.X - 16f, this.itemLocation.Y - 14f * this.gravDir), 4, 4, num36, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num37].noGravity = true;
						}
						Main.dust[num37].velocity *= 0.3f;
						Dust expr_3730_cp_0 = Main.dust[num37];
						expr_3730_cp_0.velocity.Y = expr_3730_cp_0.velocity.Y - 1.5f;
					}
				}
				else
				{
					if (Main.rand.Next(maxValue) == 0)
					{
						int num38 = Dust.NewDust(new Vector2(this.itemLocation.X + 6f, this.itemLocation.Y - 14f * this.gravDir), 4, 4, num36, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num38].noGravity = true;
						}
						Main.dust[num38].velocity *= 0.3f;
						Dust expr_3847_cp_0 = Main.dust[num38];
						expr_3847_cp_0.velocity.Y = expr_3847_cp_0.velocity.Y - 1.5f;
					}
				}
			}
			if (this.inventory[this.selectedItem].type == 105 && !this.wet && !this.pulley)
			{
				int maxValue2 = 20;
				if (this.itemAnimation > 0)
				{
					maxValue2 = 7;
				}
				if (this.direction == -1)
				{
					if (Main.rand.Next(maxValue2) == 0)
					{
						int num39 = Dust.NewDust(new Vector2(this.itemLocation.X - 12f, this.itemLocation.Y - 20f * this.gravDir), 4, 4, 6, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num39].noGravity = true;
						}
						Main.dust[num39].velocity *= 0.3f;
						Dust expr_39A3_cp_0 = Main.dust[num39];
						expr_39A3_cp_0.velocity.Y = expr_39A3_cp_0.velocity.Y - 1.5f;
					}
				}
				else
				{
					if (Main.rand.Next(maxValue2) == 0)
					{
						int num40 = Dust.NewDust(new Vector2(this.itemLocation.X + 4f, this.itemLocation.Y - 20f * this.gravDir), 4, 4, 6, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num40].noGravity = true;
						}
						Main.dust[num40].velocity *= 0.3f;
						Dust expr_3AB6_cp_0 = Main.dust[num40];
						expr_3AB6_cp_0.velocity.Y = expr_3AB6_cp_0.velocity.Y - 1.5f;
					}
				}
			}
			else if (this.inventory[this.selectedItem].type == 148 && !this.wet)
			{
				int maxValue3 = 10;
				if (this.itemAnimation > 0)
				{
					maxValue3 = 7;
				}
				if (this.direction == -1)
				{
					if (Main.rand.Next(maxValue3) == 0)
					{
						int num41 = Dust.NewDust(new Vector2(this.itemLocation.X - 12f, this.itemLocation.Y - 20f * this.gravDir), 4, 4, 172, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num41].noGravity = true;
						}
						Main.dust[num41].velocity *= 0.3f;
						Dust expr_3C10_cp_0 = Main.dust[num41];
						expr_3C10_cp_0.velocity.Y = expr_3C10_cp_0.velocity.Y - 1.5f;
					}
				}
				else
				{
					if (Main.rand.Next(maxValue3) == 0)
					{
						int num42 = Dust.NewDust(new Vector2(this.itemLocation.X + 4f, this.itemLocation.Y - 20f * this.gravDir), 4, 4, 172, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num42].noGravity = true;
						}
						Main.dust[num42].velocity *= 0.3f;
						Dust expr_3D27_cp_0 = Main.dust[num42];
						expr_3D27_cp_0.velocity.Y = expr_3D27_cp_0.velocity.Y - 1.5f;
					}
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
					if (type == 65 || type == 676 || type == 723 || type == 724 || type == 757 || type == 674 || type == 675 || type == 989 || type == 1226 || type == 1227)
					{
						Main.PlaySound(25, -1, -1, 1);
						for (int num43 = 0; num43 < 5; num43++)
						{
							int num44 = Dust.NewDust(this.position, this.width, this.height, 45, 0f, 0f, 255, default(Color), (float)Main.rand.Next(20, 26) * 0.1f);
							Main.dust[num44].noLight = true;
							Main.dust[num44].noGravity = true;
							Main.dust[num44].velocity *= 0.5f;
						}
					}
				}
			}
			if (i == Main.myPlayer)
			{
				bool flag4 = true;
				int type2 = this.inventory[this.selectedItem].type;
				if ((type2 == 65 || type2 == 676 || type2 == 723 || type2 == 724 || type2 == 757 || type2 == 674 || type2 == 675 || type2 == 989 || type2 == 1226 || type2 == 1227) && this.itemAnimation != this.itemAnimationMax - 1)
				{
					flag4 = false;
				}
				if (this.inventory[this.selectedItem].shoot > 0 && this.itemAnimation > 0 && this.itemTime == 0 && flag4)
				{
					int num45 = this.inventory[this.selectedItem].shoot;
					float num46 = this.inventory[this.selectedItem].shootSpeed;
					if (this.inventory[this.selectedItem].melee && num45 != 25 && num45 != 26 && num45 != 35)
					{
						num46 /= this.meleeSpeed;
					}
					bool flag5 = false;
					int num47 = num;
					float num48 = this.inventory[this.selectedItem].knockBack;
					if (num45 == 13 || num45 == 32 || num45 == 315 || (num45 >= 230 && num45 <= 235) || num45 == 331)
					{
						this.grappling[0] = -1;
						this.grapCount = 0;
						for (int num49 = 0; num49 < 1000; num49++)
						{
							if (Main.projectile[num49].active && Main.projectile[num49].owner == i)
							{
								if (Main.projectile[num49].type == 13)
								{
									Main.projectile[num49].Kill();
								}
								if (Main.projectile[num49].type == 331)
								{
									Main.projectile[num49].Kill();
								}
								if (Main.projectile[num49].type == 315)
								{
									Main.projectile[num49].Kill();
								}
								if (Main.projectile[num49].type >= 230 && Main.projectile[num49].type <= 235)
								{
									Main.projectile[num49].Kill();
								}
							}
						}
					}
					if (this.inventory[this.selectedItem].useAmmo > 0)
					{
						Item item = new Item();
						bool flag6 = false;
						for (int num50 = 54; num50 < 58; num50++)
						{
							if (this.inventory[num50].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[num50].stack > 0)
							{
								item = this.inventory[num50];
								flag5 = true;
								flag6 = true;
								break;
							}
						}
						if (!flag6)
						{
							for (int num51 = 0; num51 < 54; num51++)
							{
								if (this.inventory[num51].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[num51].stack > 0)
								{
									item = this.inventory[num51];
									flag5 = true;
									break;
								}
							}
						}
						if (flag5)
						{
							if (this.inventory[this.selectedItem].type == 1946)
							{
								num45 = 338 + item.type - 771;
							}
							else if (this.inventory[this.selectedItem].useAmmo == 771)
							{
								num45 += item.shoot;
							}
							else if (this.inventory[this.selectedItem].useAmmo == 780)
							{
								num45 += item.shoot;
							}
							else if (item.shoot > 0)
							{
								num45 = item.shoot;
							}
							if (num45 == 42)
							{
								if (item.type == 370)
								{
									num45 = 65;
									num47 += 5;
								}
								else if (item.type == 408)
								{
									num45 = 68;
									num47 += 5;
								}
							}
							if (this.magicQuiver && (this.inventory[this.selectedItem].useAmmo == 1 || this.inventory[this.selectedItem].useAmmo == 323))
							{
								num48 = (float)((int)((double)num48 * 1.1));
								num46 *= 1.1f;
							}
							num46 += item.shootSpeed;
							if (item.ranged)
							{
								if (item.damage > 0)
								{
									num47 += (int)((float)item.damage * this.rangedDamage);
								}
							}
							else
							{
								num47 += item.damage;
							}
							if (this.inventory[this.selectedItem].useAmmo == 1 && this.archery)
							{
								if (num46 < 20f)
								{
									num46 *= 1.2f;
									if (num46 > 20f)
									{
										num46 = 20f;
									}
								}
								num47 = (int)((double)((float)num47) * 1.2);
							}
							num48 += item.knockBack;
							bool flag7 = false;
							if (this.magicQuiver && this.inventory[this.selectedItem].useAmmo == 1 && Main.rand.Next(5) == 0)
							{
								flag7 = true;
							}
							if (this.inventory[this.selectedItem].type == 1782 && Main.rand.Next(3) == 0)
							{
								flag7 = true;
							}
							if (this.inventory[this.selectedItem].type == 98 && Main.rand.Next(3) == 0)
							{
								flag7 = true;
							}
							if (this.inventory[this.selectedItem].type == 533 && Main.rand.Next(2) == 0)
							{
								flag7 = true;
							}
							if (this.inventory[this.selectedItem].type == 1929 && Main.rand.Next(2) == 0)
							{
								flag7 = true;
							}
							if (this.inventory[this.selectedItem].type == 1553 && Main.rand.Next(2) == 0)
							{
								flag7 = true;
							}
							if (this.inventory[this.selectedItem].type == 434 && this.itemAnimation < this.inventory[this.selectedItem].useAnimation - 2)
							{
								flag7 = true;
							}
							if (this.ammoCost80 && Main.rand.Next(5) == 0)
							{
								flag7 = true;
							}
							if (this.ammoCost75 && Main.rand.Next(4) == 0)
							{
								flag7 = true;
							}
							if (num45 == 85 && this.itemAnimation < this.itemAnimationMax - 6)
							{
								flag7 = true;
							}
							if ((num45 == 145 || num45 == 146 || num45 == 147 || num45 == 148 || num45 == 149) && this.itemAnimation < this.itemAnimationMax - 5)
							{
								flag7 = true;
							}
							if (!flag7)
							{
								item.stack--;
								if (item.stack <= 0)
								{
									item.active = false;
									item.name = "";
									item.type = 0;
								}
							}
						}
					}
					else
					{
						flag5 = true;
					}
					if (this.inventory[this.selectedItem].type == 1254 && num45 == 14)
					{
						num45 = 242;
					}
					if (this.inventory[this.selectedItem].type == 1255 && num45 == 14)
					{
						num45 = 242;
					}
					if (this.inventory[this.selectedItem].type == 1265 && num45 == 14)
					{
						num45 = 242;
					}
					if (num45 == 73)
					{
						for (int num52 = 0; num52 < 1000; num52++)
						{
							if (Main.projectile[num52].active && Main.projectile[num52].owner == i)
							{
								if (Main.projectile[num52].type == 73)
								{
									num45 = 74;
								}
								if (num45 == 74 && Main.projectile[num52].type == 74)
								{
									flag5 = false;
								}
							}
						}
					}
					if (flag5)
					{
						if (this.inventory[this.selectedItem].summon)
						{
							num48 += this.minionKB;
							num47 = (int)((float)num47 * this.minionDamage);
						}
						if (num45 == 228)
						{
							num48 = 0f;
						}
						if (this.inventory[this.selectedItem].mech && this.kbGlove)
						{
							num48 *= 1.7f;
						}
						if (this.inventory[this.selectedItem].ranged && this.armorSteath)
						{
							num48 *= 1f + (1f - this.stealth) * 0.5f;
						}
						if (num45 == 1 && this.inventory[this.selectedItem].type == 120)
						{
							num45 = 2;
						}
						if (this.inventory[this.selectedItem].type == 682)
						{
							num45 = 117;
						}
						if (this.inventory[this.selectedItem].type == 725)
						{
							num45 = 120;
						}
						this.itemTime = this.inventory[this.selectedItem].useTime;
						if ((float)Main.mouseX + Main.screenPosition.X > this.position.X + (float)this.width * 0.5f)
						{
							this.ChangeDir(1);
						}
						else
						{
							this.ChangeDir(-1);
						}
						Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						if (num45 == 9)
						{
							vector = new Vector2(this.position.X + (float)this.width * 0.5f + (float)(Main.rand.Next(201) * -(float)this.direction) + ((float)Main.mouseX + Main.screenPosition.X - this.position.X), this.position.Y + (float)this.height * 0.5f - 600f);
							num48 = 0f;
							num47 *= 2;
						}
						else if (num45 == 51)
						{
							vector.Y -= 6f * this.gravDir;
						}
						float num53 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
						float num54 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
						if (this.gravDir == -1f)
						{
							num54 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector.Y;
						}
						float num55 = (float)Math.Sqrt((double)(num53 * num53 + num54 * num54));
						float num56 = num55;
						num55 = num46 / num55;
						if (this.inventory[this.selectedItem].type == 1929)
						{
							num53 += (float)Main.rand.Next(-50, 51) * 0.03f / num55;
							num54 += (float)Main.rand.Next(-50, 51) * 0.03f / num55;
						}
						num53 *= num55;
						num54 *= num55;
						if (this.inventory[this.selectedItem].type == 757)
						{
							num47 = (int)((float)num47 * 1.25f);
						}
						if (num45 == 250)
						{
							for (int num57 = 0; num57 < 1000; num57++)
							{
								if (Main.projectile[num57].active && Main.projectile[num57].owner == this.whoAmi && (Main.projectile[num57].type == 250 || Main.projectile[num57].type == 251))
								{
									Main.projectile[num57].Kill();
								}
							}
						}
						if (num45 == 12)
						{
							vector.X += num53 * 3f;
							vector.Y += num54 * 3f;
						}
						if (this.inventory[this.selectedItem].useStyle == 5)
						{
							this.itemRotation = (float)Math.Atan2((double)(num54 * (float)this.direction), (double)(num53 * (float)this.direction));
							NetMessage.SendData(13, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
							NetMessage.SendData(41, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
						}
						if (num45 == 17)
						{
							vector.X = (float)Main.mouseX + Main.screenPosition.X;
							vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
						}
						if (num45 == 76)
						{
							num45 += Main.rand.Next(3);
							num56 /= (float)(Main.screenHeight / 2);
							if (num56 > 1f)
							{
								num56 = 1f;
							}
							float num58 = num53 + (float)Main.rand.Next(-40, 41) * 0.01f;
							float num59 = num54 + (float)Main.rand.Next(-40, 41) * 0.01f;
							num58 *= num56 + 0.25f;
							num59 *= num56 + 0.25f;
							int num60 = Projectile.NewProjectile(vector.X, vector.Y, num58, num59, num45, num47, num48, i, 0f, 0f);
							Main.projectile[num60].ai[1] = 1f;
							num56 = num56 * 2f - 1f;
							if (num56 < -1f)
							{
								num56 = -1f;
							}
							if (num56 > 1f)
							{
								num56 = 1f;
							}
							Main.projectile[num60].ai[0] = num56;
							NetMessage.SendData(27, -1, -1, "", num60, 0f, 0f, 0f, 0);
						}
						else if (this.inventory[this.selectedItem].type == 98 || this.inventory[this.selectedItem].type == 533)
						{
							float speedX = num53 + (float)Main.rand.Next(-40, 41) * 0.01f;
							float speedY = num54 + (float)Main.rand.Next(-40, 41) * 0.01f;
							Projectile.NewProjectile(vector.X, vector.Y, speedX, speedY, num45, num47, num48, i, 0f, 0f);
						}
						else if (this.inventory[this.selectedItem].type == 1930)
						{
							int num61 = 2 + Main.rand.Next(3);
							for (int num62 = 0; num62 < num61; num62++)
							{
								float num63 = num53;
								float num64 = num54;
								float num65 = 0.025f * (float)num62;
								num63 += (float)Main.rand.Next(-35, 36) * num65;
								num64 += (float)Main.rand.Next(-35, 36) * num65;
								num55 = (float)Math.Sqrt((double)(num63 * num63 + num64 * num64));
								num55 = num46 / num55;
								num63 *= num55;
								num64 *= num55;
								float x = vector.X + num53 * (float)(num61 - num62) * 1.75f;
								float y = vector.Y + num54 * (float)(num61 - num62) * 1.75f;
								Projectile.NewProjectile(x, y, num63, num64, num45, num47, num48, i, (float)Main.rand.Next(0, 10 * (num62 + 1)), 0f);
							}
						}
						else if (this.inventory[this.selectedItem].type == 1931)
						{
							int num66 = 2;
							for (int num67 = 0; num67 < num66; num67++)
							{
								vector = new Vector2(this.position.X + (float)this.width * 0.5f + (float)(Main.rand.Next(201) * -(float)this.direction) + ((float)Main.mouseX + Main.screenPosition.X - this.position.X), this.position.Y + (float)this.height * 0.5f - 600f);
								vector.X = (vector.X + this.center().X) / 2f + (float)Main.rand.Next(-200, 201);
								vector.Y -= (float)(100 * num67);
								num53 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
								num54 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
								num55 = (float)Math.Sqrt((double)(num53 * num53 + num54 * num54));
								num55 = num46 / num55;
								num53 *= num55;
								num54 *= num55;
								float speedX2 = num53 + (float)Main.rand.Next(-40, 41) * 0.02f;
								float speedY2 = num54 + (float)Main.rand.Next(-40, 41) * 0.02f;
								Projectile.NewProjectile(vector.X, vector.Y, speedX2, speedY2, num45, num47, num48, i, 0f, (float)Main.rand.Next(5));
							}
						}
						else if (this.inventory[this.selectedItem].type == 1929)
						{
							float speedX3 = num53 + (float)Main.rand.Next(-40, 41) * 0.03f;
							float speedY3 = num54 + (float)Main.rand.Next(-40, 41) * 0.03f;
							Projectile.NewProjectile(vector.X, vector.Y, speedX3, speedY3, num45, num47, num48, i, 0f, 0f);
						}
						else if (this.inventory[this.selectedItem].type == 1553)
						{
							float speedX4 = num53 + (float)Main.rand.Next(-40, 41) * 0.005f;
							float speedY4 = num54 + (float)Main.rand.Next(-40, 41) * 0.005f;
							Projectile.NewProjectile(vector.X, vector.Y, speedX4, speedY4, num45, num47, num48, i, 0f, 0f);
						}
						else if (this.inventory[this.selectedItem].type == 518)
						{
							float num68 = num53;
							float num69 = num54;
							num68 += (float)Main.rand.Next(-40, 41) * 0.04f;
							num69 += (float)Main.rand.Next(-40, 41) * 0.04f;
							Projectile.NewProjectile(vector.X, vector.Y, num68, num69, num45, num47, num48, i, 0f, 0f);
						}
						else if (this.inventory[this.selectedItem].type == 1265)
						{
							float num70 = num53;
							float num71 = num54;
							num70 += (float)Main.rand.Next(-30, 31) * 0.03f;
							num71 += (float)Main.rand.Next(-30, 31) * 0.03f;
							Projectile.NewProjectile(vector.X, vector.Y, num70, num71, num45, num47, num48, i, 0f, 0f);
						}
						else if (this.inventory[this.selectedItem].type == 534)
						{
							for (int num72 = 0; num72 < 4; num72++)
							{
								float num73 = num53;
								float num74 = num54;
								num73 += (float)Main.rand.Next(-40, 41) * 0.05f;
								num74 += (float)Main.rand.Next(-40, 41) * 0.05f;
								Projectile.NewProjectile(vector.X, vector.Y, num73, num74, num45, num47, num48, i, 0f, 0f);
							}
						}
						else if (this.inventory[this.selectedItem].type == 1308)
						{
							int num75 = 4;
							for (int num76 = 0; num76 < num75; num76++)
							{
								float num77 = num53;
								float num78 = num54;
								float num79 = 0.05f * (float)num76;
								num77 += (float)Main.rand.Next(-35, 36) * num79;
								num78 += (float)Main.rand.Next(-35, 36) * num79;
								num55 = (float)Math.Sqrt((double)(num77 * num77 + num78 * num78));
								num55 = num46 / num55;
								num77 *= num55;
								num78 *= num55;
								float x2 = vector.X;
								float y2 = vector.Y;
								Projectile.NewProjectile(x2, y2, num77, num78, num45, num47, num48, i, 0f, 0f);
							}
						}
						else if (this.inventory[this.selectedItem].type == 1258)
						{
							float num80 = num53;
							float num81 = num54;
							num80 += (float)Main.rand.Next(-40, 41) * 0.01f;
							num81 += (float)Main.rand.Next(-40, 41) * 0.01f;
							vector.X += (float)Main.rand.Next(-40, 41) * 0.05f;
							vector.Y += (float)Main.rand.Next(-45, 36) * 0.05f;
							Projectile.NewProjectile(vector.X, vector.Y, num80, num81, num45, num47, num48, i, 0f, 0f);
						}
						else if (this.inventory[this.selectedItem].type == 964)
						{
							for (int num82 = 0; num82 < 3; num82++)
							{
								float num83 = num53;
								float num84 = num54;
								num83 += (float)Main.rand.Next(-35, 36) * 0.04f;
								num84 += (float)Main.rand.Next(-35, 36) * 0.04f;
								Projectile.NewProjectile(vector.X, vector.Y, num83, num84, num45, num47, num48, i, 0f, 0f);
							}
						}
						else if (this.inventory[this.selectedItem].type == 1569)
						{
							int num85 = 4;
							if (Main.rand.Next(2) == 0)
							{
								num85++;
							}
							if (Main.rand.Next(4) == 0)
							{
								num85++;
							}
							if (Main.rand.Next(8) == 0)
							{
								num85++;
							}
							if (Main.rand.Next(16) == 0)
							{
								num85++;
							}
							for (int num86 = 0; num86 < num85; num86++)
							{
								float num87 = num53;
								float num88 = num54;
								float num89 = 0.05f * (float)num86;
								num87 += (float)Main.rand.Next(-35, 36) * num89;
								num88 += (float)Main.rand.Next(-35, 36) * num89;
								num55 = (float)Math.Sqrt((double)(num87 * num87 + num88 * num88));
								num55 = num46 / num55;
								num87 *= num55;
								num88 *= num55;
								float x3 = vector.X;
								float y3 = vector.Y;
								Projectile.NewProjectile(x3, y3, num87, num88, num45, num47, num48, i, 0f, 0f);
							}
						}
						else if (this.inventory[this.selectedItem].type == 1572)
						{
							for (int num90 = 0; num90 < 1000; num90++)
							{
								if (Main.projectile[num90].owner == this.whoAmi && Main.projectile[num90].type == 308)
								{
									Main.projectile[num90].Kill();
								}
							}
							int num91 = (int)((float)Main.mouseX + Main.screenPosition.X) / 16;
							int num92 = (int)((float)Main.mouseY + Main.screenPosition.Y) / 16;
							while (num92 < Main.maxTilesY - 10 && Main.tile[num91, num92] != null && !WorldGen.SolidTile(num91, num92) && Main.tile[num91 - 1, num92] != null && !WorldGen.SolidTile(num91 - 1, num92) && Main.tile[num91 + 1, num92] != null && !WorldGen.SolidTile(num91 + 1, num92))
							{
								num92++;
							}
							num92--;
							Projectile.NewProjectile((float)Main.mouseX + Main.screenPosition.X, (float)(num92 * 16 - 24), 0f, 15f, num45, num47, num48, i, 0f, 0f);
						}
						else if (this.inventory[this.selectedItem].type == 1244 || this.inventory[this.selectedItem].type == 1256)
						{
							int num93 = Projectile.NewProjectile(vector.X, vector.Y, num53, num54, num45, num47, num48, i, 0f, 0f);
							Main.projectile[num93].ai[0] = (float)Main.mouseX + Main.screenPosition.X;
							Main.projectile[num93].ai[1] = (float)Main.mouseY + Main.screenPosition.Y;
						}
						else if (this.inventory[this.selectedItem].type == 1229)
						{
							int num94 = Main.rand.Next(2, 4);
							if (Main.rand.Next(5) == 0)
							{
								num94++;
							}
							for (int num95 = 0; num95 < num94; num95++)
							{
								float num96 = num53;
								float num97 = num54;
								if (num95 > 0)
								{
									num96 += (float)Main.rand.Next(-35, 36) * 0.04f;
									num97 += (float)Main.rand.Next(-35, 36) * 0.04f;
								}
								if (num95 > 1)
								{
									num96 += (float)Main.rand.Next(-35, 36) * 0.04f;
									num97 += (float)Main.rand.Next(-35, 36) * 0.04f;
								}
								if (num95 > 2)
								{
									num96 += (float)Main.rand.Next(-35, 36) * 0.04f;
									num97 += (float)Main.rand.Next(-35, 36) * 0.04f;
								}
								int num98 = Projectile.NewProjectile(vector.X, vector.Y, num96, num97, num45, num47, num48, i, 0f, 0f);
								Main.projectile[num98].noDropItem = true;
							}
						}
						else if (this.inventory[this.selectedItem].type == 1121 || this.inventory[this.selectedItem].type == 1155)
						{
							int num99;
							if (this.inventory[this.selectedItem].type == 1121)
							{
								num99 = Main.rand.Next(1, 4);
								if (Main.rand.Next(6) == 0)
								{
									num99++;
								}
								if (Main.rand.Next(6) == 0)
								{
									num99++;
								}
							}
							else
							{
								num99 = Main.rand.Next(2, 5);
								if (Main.rand.Next(5) == 0)
								{
									num99++;
								}
								if (Main.rand.Next(5) == 0)
								{
									num99++;
								}
							}
							for (int num100 = 0; num100 < num99; num100++)
							{
								float num101 = num53;
								float num102 = num54;
								num101 += (float)Main.rand.Next(-35, 36) * 0.02f;
								num102 += (float)Main.rand.Next(-35, 36) * 0.02f;
								Projectile.NewProjectile(vector.X, vector.Y, num101, num102, num45, num47, num48, i, 0f, 0f);
							}
						}
						else if (this.inventory[this.selectedItem].type == 1801)
						{
							int num103 = Main.rand.Next(1, 4);
							for (int num104 = 0; num104 < num103; num104++)
							{
								float num105 = num53;
								float num106 = num54;
								num105 += (float)Main.rand.Next(-35, 36) * 0.05f;
								num106 += (float)Main.rand.Next(-35, 36) * 0.05f;
								Projectile.NewProjectile(vector.X, vector.Y, num105, num106, num45, num47, num48, i, 0f, 0f);
							}
						}
						else if (this.inventory[this.selectedItem].type == 679)
						{
							for (int num107 = 0; num107 < 6; num107++)
							{
								float num108 = num53;
								float num109 = num54;
								num108 += (float)Main.rand.Next(-40, 41) * 0.05f;
								num109 += (float)Main.rand.Next(-40, 41) * 0.05f;
								Projectile.NewProjectile(vector.X, vector.Y, num108, num109, num45, num47, num48, i, 0f, 0f);
							}
						}
						else if (this.inventory[this.selectedItem].type == 434)
						{
							float num110 = num53;
							float num111 = num54;
							if (this.itemAnimation < 5)
							{
								num110 += (float)Main.rand.Next(-40, 41) * 0.01f;
								num111 += (float)Main.rand.Next(-40, 41) * 0.01f;
								num110 *= 1.1f;
								num111 *= 1.1f;
							}
							else if (this.itemAnimation < 10)
							{
								num110 += (float)Main.rand.Next(-20, 21) * 0.01f;
								num111 += (float)Main.rand.Next(-20, 21) * 0.01f;
								num110 *= 1.05f;
								num111 *= 1.05f;
							}
							Projectile.NewProjectile(vector.X, vector.Y, num110, num111, num45, num47, num48, i, 0f, 0f);
						}
						else if (this.inventory[this.selectedItem].type == 1157)
						{
							num45 = Main.rand.Next(191, 195);
							num53 = 0f;
							num54 = 0f;
							vector.X = (float)Main.mouseX + Main.screenPosition.X;
							vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
							int num112 = Projectile.NewProjectile(vector.X, vector.Y, num53, num54, num45, num47, num48, i, 0f, 0f);
							Main.projectile[num112].localAI[0] = 30f;
						}
						else if (this.inventory[this.selectedItem].type == 1802)
						{
							num53 = 0f;
							num54 = 0f;
							vector.X = (float)Main.mouseX + Main.screenPosition.X;
							vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(vector.X, vector.Y, num53, num54, num45, num47, num48, i, 0f, 0f);
						}
						else if (this.inventory[this.selectedItem].type == 1309)
						{
							num53 = 0f;
							num54 = 0f;
							vector.X = (float)Main.mouseX + Main.screenPosition.X;
							vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(vector.X, vector.Y, num53, num54, num45, num47, num48, i, 0f, 0f);
						}
						else if (this.inventory[this.selectedItem].shoot > 0 && (Main.projPet[this.inventory[this.selectedItem].shoot] || this.inventory[this.selectedItem].shoot == 72 || this.inventory[this.selectedItem].shoot == 18) && !this.inventory[this.selectedItem].summon)
						{
							for (int num113 = 0; num113 < 1000; num113++)
							{
								if (Main.projectile[num113].active && Main.projectile[num113].owner == this.whoAmi)
								{
									if (this.inventory[this.selectedItem].shoot == 72)
									{
										if (Main.projectile[num113].type == 72 || Main.projectile[num113].type == 86 || Main.projectile[num113].type == 87)
										{
											Main.projectile[num113].Kill();
										}
									}
									else if (this.inventory[this.selectedItem].shoot == Main.projectile[num113].type)
									{
										Main.projectile[num113].Kill();
									}
								}
							}
							if (num45 == 72)
							{
								int num114 = Main.rand.Next(3);
								if (num114 == 0)
								{
									num45 = 72;
								}
								else if (num114 == 1)
								{
									num45 = 86;
								}
								else if (num114 == 2)
								{
									num45 = 87;
								}
							}
							Projectile.NewProjectile(vector.X, vector.Y, num53, num54, num45, num47, num48, i, 0f, 0f);
						}
						else
						{
							int num115 = Projectile.NewProjectile(vector.X, vector.Y, num53, num54, num45, num47, num48, i, 0f, 0f);
							if (this.inventory[this.selectedItem].type == 726)
							{
								Main.projectile[num115].magic = true;
							}
							if (this.inventory[this.selectedItem].type == 724 || this.inventory[this.selectedItem].type == 676)
							{
								Main.projectile[num115].melee = true;
							}
							if (num45 == 80)
							{
								Main.projectile[num115].ai[0] = (float)Player.tileTargetX;
								Main.projectile[num115].ai[1] = (float)Player.tileTargetY;
							}
						}
					}
					else if (this.inventory[this.selectedItem].useStyle == 5)
					{
						this.itemRotation = 0f;
						NetMessage.SendData(41, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
					}
				}
				if (this.whoAmi == Main.myPlayer && (this.inventory[this.selectedItem].type == 509 || this.inventory[this.selectedItem].type == 510 || this.inventory[this.selectedItem].type == 849 || this.inventory[this.selectedItem].type == 850 || this.inventory[this.selectedItem].type == 851) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
				{
					this.showItemIcon = true;
					if (this.itemAnimation > 0 && this.itemTime == 0 && this.controlUseItem)
					{
						int i2 = Player.tileTargetX;
						int j2 = Player.tileTargetY;
						if (this.inventory[this.selectedItem].type == 509)
						{
							int num116 = -1;
							for (int num117 = 0; num117 < 58; num117++)
							{
								if (this.inventory[num117].stack > 0 && this.inventory[num117].type == 530)
								{
									num116 = num117;
									break;
								}
							}
							if (num116 >= 0 && WorldGen.PlaceWire(i2, j2))
							{
								this.inventory[num116].stack--;
								if (this.inventory[num116].stack <= 0)
								{
									this.inventory[num116].SetDefaults(0, false);
								}
								this.itemTime = this.inventory[this.selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 5, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
							}
						}
						else if (this.inventory[this.selectedItem].type == 850)
						{
							int num118 = -1;
							for (int num119 = 0; num119 < 58; num119++)
							{
								if (this.inventory[num119].stack > 0 && this.inventory[num119].type == 530)
								{
									num118 = num119;
									break;
								}
							}
							if (num118 >= 0 && WorldGen.PlaceWire2(i2, j2))
							{
								this.inventory[num118].stack--;
								if (this.inventory[num118].stack <= 0)
								{
									this.inventory[num118].SetDefaults(0, false);
								}
								this.itemTime = this.inventory[this.selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 10, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
							}
						}
						if (this.inventory[this.selectedItem].type == 851)
						{
							int num120 = -1;
							for (int num121 = 0; num121 < 58; num121++)
							{
								if (this.inventory[num121].stack > 0 && this.inventory[num121].type == 530)
								{
									num120 = num121;
									break;
								}
							}
							if (num120 >= 0 && WorldGen.PlaceWire3(i2, j2))
							{
								this.inventory[num120].stack--;
								if (this.inventory[num120].stack <= 0)
								{
									this.inventory[num120].SetDefaults(0, false);
								}
								this.itemTime = this.inventory[this.selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 12, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
							}
						}
						else if (this.inventory[this.selectedItem].type == 510)
						{
							if (WorldGen.KillActuator(i2, j2))
							{
								this.itemTime = this.inventory[this.selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 9, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
							}
							else if (WorldGen.KillWire3(i2, j2))
							{
								this.itemTime = this.inventory[this.selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 13, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
							}
							else if (WorldGen.KillWire2(i2, j2))
							{
								this.itemTime = this.inventory[this.selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 11, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
							}
							else if (WorldGen.KillWire(i2, j2))
							{
								this.itemTime = this.inventory[this.selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 6, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
							}
						}
						else if (this.inventory[this.selectedItem].type == 849 && this.inventory[this.selectedItem].stack > 0 && WorldGen.PlaceActuator(i2, j2))
						{
							this.itemTime = this.inventory[this.selectedItem].useTime;
							NetMessage.SendData(17, -1, -1, "", 8, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
							this.inventory[this.selectedItem].stack--;
							if (this.inventory[this.selectedItem].stack <= 0)
							{
								this.inventory[this.selectedItem].SetDefaults(0, false);
							}
						}
					}
				}
				if (this.itemAnimation > 0 && this.itemTime == 0 && (this.inventory[this.selectedItem].type == 507 || this.inventory[this.selectedItem].type == 508))
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num122 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
					float num123 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
					float num124 = (float)Math.Sqrt((double)(num122 * num122 + num123 * num123));
					num124 /= (float)(Main.screenHeight / 2);
					if (num124 > 1f)
					{
						num124 = 1f;
					}
					num124 = num124 * 2f - 1f;
					if (num124 < -1f)
					{
						num124 = -1f;
					}
					if (num124 > 1f)
					{
						num124 = 1f;
					}
					Main.harpNote = num124;
					int style = 26;
					if (this.inventory[this.selectedItem].type == 507)
					{
						style = 35;
					}
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, style);
					NetMessage.SendData(58, -1, -1, "", this.whoAmi, num124, 0f, 0f, 0);
				}
				if (((this.inventory[this.selectedItem].type >= 205 && this.inventory[this.selectedItem].type <= 207) || this.inventory[this.selectedItem].type == 1128) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
				{
					this.showItemIcon = true;
					if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
					{
						if (this.inventory[this.selectedItem].type == 205)
						{
							int num125 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType();
							int num126 = 0;
							for (int num127 = Player.tileTargetX - 1; num127 <= Player.tileTargetX + 1; num127++)
							{
								for (int num128 = Player.tileTargetY - 1; num128 <= Player.tileTargetY + 1; num128++)
								{
									if ((int)Main.tile[num127, num128].liquidType() == num125)
									{
										num126 += (int)Main.tile[num127, num128].liquid;
									}
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0 && num126 > 100)
							{
								int liquidType = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType();
								if (!Main.tile[Player.tileTargetX, Player.tileTargetY].lava())
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].honey())
									{
										this.inventory[this.selectedItem].SetDefaults(1128, false);
									}
									else
									{
										this.inventory[this.selectedItem].SetDefaults(206, false);
									}
								}
								else
								{
									this.inventory[this.selectedItem].SetDefaults(207, false);
								}
								Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								this.itemTime = this.inventory[this.selectedItem].useTime;
								int num129 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquid;
								Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 0;
								Main.tile[Player.tileTargetX, Player.tileTargetY].lava(false);
								Main.tile[Player.tileTargetX, Player.tileTargetY].honey(false);
								WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, false);
								if (Main.netMode == 1)
								{
									NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
								}
								else
								{
									Liquid.AddWater(Player.tileTargetX, Player.tileTargetY);
								}
								for (int num130 = Player.tileTargetX - 1; num130 <= Player.tileTargetX + 1; num130++)
								{
									for (int num131 = Player.tileTargetY - 1; num131 <= Player.tileTargetY + 1; num131++)
									{
										if (num129 < 256 && (int)Main.tile[num130, num131].liquidType() == num125)
										{
											int num132 = (int)Main.tile[num130, num131].liquid;
											if (num132 + num129 > 255)
											{
												num132 = 255 - num129;
											}
											num129 += num132;
											Tile expr_6E97 = Main.tile[num130, num131];
											expr_6E97.liquid -= (byte)num132;
											Main.tile[num130, num131].liquidType(liquidType);
											if (Main.tile[num130, num131].liquid == 0)
											{
												Main.tile[num130, num131].lava(false);
												Main.tile[num130, num131].honey(false);
											}
											WorldGen.SquareTileFrame(num130, num131, false);
											if (Main.netMode == 1)
											{
												NetMessage.sendWater(num130, num131);
											}
											else
											{
												Liquid.AddWater(num130, num131);
											}
										}
									}
								}
							}
						}
						else if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid < 200 && (!Main.tile[Player.tileTargetX, Player.tileTargetY].nactive() || !Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tileSolidTop[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
						{
							if (this.inventory[this.selectedItem].type == 207)
							{
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 1)
								{
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
									Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType(1);
									Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 255;
									WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
									this.inventory[this.selectedItem].SetDefaults(205, false);
									this.itemTime = this.inventory[this.selectedItem].useTime;
									if (Main.netMode == 1)
									{
										NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
									}
								}
							}
							else if (this.inventory[this.selectedItem].type == 206)
							{
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 0)
								{
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
									Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType(0);
									Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 255;
									WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
									this.inventory[this.selectedItem].SetDefaults(205, false);
									this.itemTime = this.inventory[this.selectedItem].useTime;
									if (Main.netMode == 1)
									{
										NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
									}
								}
							}
							else if (this.inventory[this.selectedItem].type == 1128 && (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 2))
							{
								Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType(2);
								Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 255;
								WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
								this.inventory[this.selectedItem].SetDefaults(205, false);
								this.itemTime = this.inventory[this.selectedItem].useTime;
								if (Main.netMode == 1)
								{
									NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
								}
							}
						}
					}
				}
				if (!this.channel)
				{
					this.toolTime = this.itemTime;
				}
				else
				{
					this.toolTime--;
					if (this.toolTime < 0)
					{
						if (this.inventory[this.selectedItem].pick > 0)
						{
							this.toolTime = this.inventory[this.selectedItem].useTime;
						}
						else
						{
							this.toolTime = (int)((float)this.inventory[this.selectedItem].useTime * this.pickSpeed);
						}
					}
				}
				if ((this.inventory[this.selectedItem].pick > 0 || this.inventory[this.selectedItem].axe > 0 || this.inventory[this.selectedItem].hammer > 0) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
				{
					bool flag8 = true;
					this.showItemIcon = true;
					if (this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem && (!Main.tile[Player.tileTargetX, Player.tileTargetY].active() || (!Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] && !Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])))
					{
						this.poundRelease = false;
					}
					if (Main.tile[Player.tileTargetX, Player.tileTargetY].active())
					{
						if ((this.inventory[this.selectedItem].pick > 0 && !Main.tileAxe[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] && !Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]) || (this.inventory[this.selectedItem].axe > 0 && Main.tileAxe[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]) || (this.inventory[this.selectedItem].hammer > 0 && Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
						{
							flag8 = false;
						}
						if (this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
						{
							if (this.hitTileX != Player.tileTargetX || this.hitTileY != Player.tileTargetY)
							{
								this.hitTile = 0;
								this.hitTileX = Player.tileTargetX;
								this.hitTileY = Player.tileTargetY;
							}
							if (Main.tileNoFail[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
							{
								this.hitTile = 100;
							}
							if (Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
							{
								flag8 = false;
								if (this.inventory[this.selectedItem].hammer > 0)
								{
									this.hitTile += this.inventory[this.selectedItem].hammer;
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 26 && (this.inventory[this.selectedItem].hammer < 80 || !Main.hardMode))
									{
										this.hitTile = 0;
										this.Hurt(this.statLife / 2, -this.direction, false, false, Lang.deathMsg(-1, -1, -1, 4), false);
									}
									if (this.hitTile >= 100)
									{
										this.hitTile = 0;
										WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
										}
									}
									else
									{
										WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
										}
									}
									this.itemTime = this.inventory[this.selectedItem].useTime;
								}
							}
							else if (Main.tileAxe[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
							{
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 80)
								{
									this.hitTile += this.inventory[this.selectedItem].axe * 3;
								}
								else
								{
									this.hitTile += this.inventory[this.selectedItem].axe;
								}
								if (this.inventory[this.selectedItem].axe > 0)
								{
									if (this.hitTile >= 100)
									{
										this.hitTile = 0;
										WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
										}
									}
									else
									{
										WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
										}
									}
									this.itemTime = this.inventory[this.selectedItem].useTime;
								}
							}
							else if (this.inventory[this.selectedItem].pick > 0)
							{
								if (Main.tileDungeon[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 25 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 58 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 117 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 203)
								{
									this.hitTile += this.inventory[this.selectedItem].pick / 2;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 48 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 232)
								{
									this.hitTile += this.inventory[this.selectedItem].pick / 4;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 226)
								{
									this.hitTile += this.inventory[this.selectedItem].pick / 4;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 107 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 221)
								{
									this.hitTile += this.inventory[this.selectedItem].pick / 2;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 108 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 222)
								{
									this.hitTile += this.inventory[this.selectedItem].pick / 3;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 111 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 223)
								{
									this.hitTile += this.inventory[this.selectedItem].pick / 4;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 211)
								{
									this.hitTile += this.inventory[this.selectedItem].pick / 5;
								}
								else
								{
									this.hitTile += this.inventory[this.selectedItem].pick;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 211 && this.inventory[this.selectedItem].pick < 200)
								{
									this.hitTile = 0;
								}
								if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 25 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 203) && this.inventory[this.selectedItem].pick < 65)
								{
									this.hitTile = 0;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 117 && this.inventory[this.selectedItem].pick < 65)
								{
									this.hitTile = 0;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 37 && this.inventory[this.selectedItem].pick < 50)
								{
									this.hitTile = 0;
								}
								else if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 22 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 204) && (double)Player.tileTargetY > Main.worldSurface && this.inventory[this.selectedItem].pick < 55)
								{
									this.hitTile = 0;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 56 && this.inventory[this.selectedItem].pick < 65)
								{
									this.hitTile = 0;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 58 && this.inventory[this.selectedItem].pick < 65)
								{
									this.hitTile = 0;
								}
								else if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 226 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 237) && this.inventory[this.selectedItem].pick < 210)
								{
									this.hitTile = 0;
								}
								else if (Main.tileDungeon[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] && this.inventory[this.selectedItem].pick < 65)
								{
									if ((double)Player.tileTargetX < (double)Main.maxTilesX * 0.35 || (double)Player.tileTargetX > (double)Main.maxTilesX * 0.65)
									{
										this.hitTile = 0;
									}
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 107 && this.inventory[this.selectedItem].pick < 100)
								{
									this.hitTile = 0;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 108 && this.inventory[this.selectedItem].pick < 110)
								{
									this.hitTile = 0;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 111 && this.inventory[this.selectedItem].pick < 120)
								{
									this.hitTile = 0;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 221 && this.inventory[this.selectedItem].pick < 100)
								{
									this.hitTile = 0;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 222 && this.inventory[this.selectedItem].pick < 110)
								{
									this.hitTile = 0;
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 223 && this.inventory[this.selectedItem].pick < 120)
								{
									this.hitTile = 0;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 147 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 40 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 53 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 57 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 59 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 123 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 224)
								{
									this.hitTile += this.inventory[this.selectedItem].pick;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 165 || Main.tileRope[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 199 || Main.tileMoss[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
								{
									this.hitTile = 100;
								}
								if (this.hitTile >= 100 && (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 2 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 23 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 60 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 70 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 109 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 71 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 199 || Main.tileMoss[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
								{
									this.hitTile = 0;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 128)
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 18 || Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 54)
									{
										Player.tileTargetX--;
									}
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 100)
									{
										this.hitTile = 0;
									}
								}
								if (this.hitTile >= 100)
								{
									this.hitTile = 0;
									if (Main.netMode == 1 && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 21)
									{
										WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
										NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
										NetMessage.SendData(34, -1, -1, "", Player.tileTargetX, (float)Player.tileTargetY, 0f, 0f, 0);
									}
									else
									{
										WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
										}
									}
								}
								else
								{
									WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
									}
								}
								this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.pickSpeed);
							}
							if (this.inventory[this.selectedItem].hammer > 0 && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] && Main.tile[Player.tileTargetX, Player.tileTargetY].type != 10 && this.poundRelease)
							{
								flag8 = false;
								this.itemTime = this.inventory[this.selectedItem].useTime;
								this.hitTile += (int)((double)this.inventory[this.selectedItem].hammer * 1.25);
								this.hitTile = 100;
								if (Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active() && Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type == 10)
								{
									this.hitTile = 0;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active() && Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type == 10)
								{
									this.hitTile = 0;
								}
								if (this.hitTile >= 100)
								{
									this.hitTile = 0;
									if (this.poundRelease)
									{
										int num133 = Player.tileTargetX;
										int num134 = Player.tileTargetY;
										if ((Main.tile[num133, num134].halfBrick() || Main.tile[num133, num134].slope() != 0) && !Main.tileSolidTop[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
										{
											int num135 = 1;
											int slope = 2;
											if (WorldGen.SolidTile(num133 + 1, num134) && !WorldGen.SolidTile(num133 - 1, num134))
											{
												num135 = 2;
												slope = 1;
											}
											if (Main.tile[num133, num134].slope() == 0)
											{
												WorldGen.SlopeTile(num133, num134, num135);
											}
											else if ((int)Main.tile[num133, num134].slope() == num135)
											{
												WorldGen.SlopeTile(num133, num134, slope);
											}
											else
											{
												WorldGen.SlopeTile(num133, num134, 0);
											}
											int num136 = (int)Main.tile[num133, num134].slope();
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 14, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)num136, 0);
											}
										}
										else
										{
											WorldGen.PoundTile(num133, num134);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 7, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
											}
										}
										this.poundRelease = false;
									}
								}
								else
								{
									WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, true, false);
									Main.PlaySound(0, Player.tileTargetX * 16, Player.tileTargetY * 16, 1);
								}
							}
							else
							{
								this.poundRelease = false;
							}
						}
					}
					if (this.releaseUseItem)
					{
						this.poundRelease = true;
					}
					int num137 = Player.tileTargetX;
					int num138 = Player.tileTargetY;
					bool flag9 = true;
					if (Main.tile[num137, num138].wall > 0)
					{
						if (!Main.wallHouse[(int)Main.tile[num137, num138].wall])
						{
							for (int num139 = num137 - 1; num139 < num137 + 2; num139++)
							{
								for (int num140 = num138 - 1; num140 < num138 + 2; num140++)
								{
									if (Main.tile[num139, num140].wall != Main.tile[num137, num138].wall)
									{
										flag9 = false;
										break;
									}
								}
							}
						}
						else
						{
							flag9 = false;
						}
					}
					if (flag9 && !Main.tile[num137, num138].active())
					{
						int num141 = -1;
						if ((double)(((float)Main.mouseX + Main.screenPosition.X) / 16f) < Math.Round((double)(((float)Main.mouseX + Main.screenPosition.X) / 16f)))
						{
							num141 = 0;
						}
						int num142 = -1;
						if ((double)(((float)Main.mouseY + Main.screenPosition.Y) / 16f) < Math.Round((double)(((float)Main.mouseY + Main.screenPosition.Y) / 16f)))
						{
							num142 = 0;
						}
						for (int num143 = Player.tileTargetX + num141; num143 <= Player.tileTargetX + num141 + 1; num143++)
						{
							for (int num144 = Player.tileTargetY + num142; num144 <= Player.tileTargetY + num142 + 1; num144++)
							{
								if (flag9)
								{
									num137 = num143;
									num138 = num144;
									if (Main.tile[num137, num138].wall > 0)
									{
										if (!Main.wallHouse[(int)Main.tile[num137, num138].wall])
										{
											for (int num145 = num137 - 1; num145 < num137 + 2; num145++)
											{
												for (int num146 = num138 - 1; num146 < num138 + 2; num146++)
												{
													if (Main.tile[num145, num146].wall != Main.tile[num137, num138].wall)
													{
														flag9 = false;
														break;
													}
												}
											}
										}
										else
										{
											flag9 = false;
										}
									}
								}
							}
						}
					}
					if (flag8 && Main.tile[num137, num138].wall > 0 && (!Main.tile[num137, num138].active() || num137 != Player.tileTargetX || num138 != Player.tileTargetY || (!Main.tileHammer[(int)Main.tile[num137, num138].type] && !this.poundRelease)) && this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem && this.inventory[this.selectedItem].hammer > 0)
					{
						bool flag10 = true;
						if (!Main.wallHouse[(int)Main.tile[num137, num138].wall])
						{
							flag10 = false;
							for (int num147 = num137 - 1; num147 < num137 + 2; num147++)
							{
								for (int num148 = num138 - 1; num148 < num138 + 2; num148++)
								{
									if (Main.tile[num147, num148].wall == 0 || Main.wallHouse[(int)Main.tile[num147, num148].wall])
									{
										flag10 = true;
										break;
									}
								}
							}
						}
						if (flag10)
						{
							if (this.hitTileX != num137 || this.hitTileY != num138)
							{
								this.hitTile = 0;
								this.hitTileX = num137;
								this.hitTileY = num138;
							}
							this.hitTile += (int)((float)this.inventory[this.selectedItem].hammer * 1.5f);
							if (this.hitTile >= 100)
							{
								this.hitTile = 0;
								WorldGen.KillWall(num137, num138, false);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 2, (float)num137, (float)num138, 0f, 0);
								}
							}
							else
							{
								WorldGen.KillWall(num137, num138, true);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 2, (float)num137, (float)num138, 1f, 0);
								}
							}
							this.itemTime = this.inventory[this.selectedItem].useTime / 2;
						}
					}
				}
				if (Main.myPlayer == this.whoAmi && this.inventory[this.selectedItem].type == 1326 && this.itemAnimation > 0 && this.itemTime == 0)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Vector2 newPos;
					newPos.X = (float)Main.mouseX + Main.screenPosition.X;
					newPos.Y = (float)Main.mouseY + Main.screenPosition.Y;
					newPos.X -= (float)(this.width / 2);
					newPos.Y -= (float)this.height;
					if (newPos.X > 50f && newPos.X < (float)(Main.maxTilesX * 16 - 50) && newPos.Y > 50f && newPos.Y < (float)(Main.maxTilesY * 16 - 50))
					{
						int num149 = (int)(newPos.X / 16f);
						int num150 = (int)(newPos.Y / 16f);
						if ((Main.tile[num149, num150].wall != 87 || (double)num150 <= Main.worldSurface || NPC.downedPlantBoss) && !Collision.SolidCollision(newPos, this.width, this.height))
						{
							this.Teleport(newPos, 1);
							NetMessage.SendData(65, -1, -1, "", 0, (float)this.whoAmi, newPos.X, newPos.Y, 1);
							if (this.chaosState)
							{
								this.statLife -= this.statLifeMax / 5;
								if (Lang.lang <= 1)
								{
									string deathText = " didn't materialize";
									if (Main.rand.Next(2) == 0)
									{
										if (this.male)
										{
											deathText = "'s legs appeared where his head should be";
										}
										else
										{
											deathText = "'s legs appeared where her head should be";
										}
									}
									if (this.statLife <= 0)
									{
										this.KillMe(1.0, 0, false, deathText);
									}
								}
								else if (this.statLife <= 0)
								{
									this.KillMe(1.0, 0, false, "");
								}
								this.lifeRegenCount = 0;
								this.lifeRegenTime = 0;
							}
							this.AddBuff(88, 600, true);
						}
					}
				}
				if (this.inventory[this.selectedItem].type == 29 && this.itemAnimation > 0 && this.statLifeMax < 400 && this.itemTime == 0)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					this.statLifeMax += 20;
					this.statLife += 20;
					if (Main.myPlayer == this.whoAmi)
					{
						this.HealEffect(20, true);
					}
				}
				if (this.inventory[this.selectedItem].type == 1291 && this.itemAnimation > 0 && this.statLifeMax >= 400 && this.statLifeMax < 500 && this.itemTime == 0)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					this.statLifeMax += 5;
					this.statLife += 5;
					if (Main.myPlayer == this.whoAmi)
					{
						this.HealEffect(5, true);
					}
				}
				if (this.inventory[this.selectedItem].type == 109 && this.itemAnimation > 0 && this.statManaMax < 200 && this.itemTime == 0)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					this.statManaMax += 20;
					this.statMana += 20;
					if (Main.myPlayer == this.whoAmi)
					{
						this.ManaEffect(20);
					}
				}
				this.PlaceThing();
			}
			if (((this.inventory[this.selectedItem].damage >= 0 && this.inventory[this.selectedItem].type > 0 && !this.inventory[this.selectedItem].noMelee) || this.inventory[this.selectedItem].type == 1450) && this.itemAnimation > 0)
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
				float arg_93BE_0 = this.gravDir;
				if (this.inventory[this.selectedItem].type == 1450 && Main.rand.Next(3) == 0)
				{
					int num151 = -1;
					float x4 = (float)(rectangle.X + Main.rand.Next(rectangle.Width));
					float y4 = (float)(rectangle.Y + Main.rand.Next(rectangle.Height));
					if (Main.rand.Next(500) == 0)
					{
						num151 = Gore.NewGore(new Vector2(x4, y4), default(Vector2), 415, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else if (Main.rand.Next(250) == 0)
					{
						num151 = Gore.NewGore(new Vector2(x4, y4), default(Vector2), 414, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else if (Main.rand.Next(80) == 0)
					{
						num151 = Gore.NewGore(new Vector2(x4, y4), default(Vector2), 413, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else if (Main.rand.Next(10) == 0)
					{
						num151 = Gore.NewGore(new Vector2(x4, y4), default(Vector2), 412, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else if (Main.rand.Next(3) == 0)
					{
						num151 = Gore.NewGore(new Vector2(x4, y4), default(Vector2), 411, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					if (num151 >= 0)
					{
						Gore expr_95AC_cp_0 = Main.gore[num151];
						expr_95AC_cp_0.velocity.X = expr_95AC_cp_0.velocity.X + (float)(this.direction * 2);
						Gore expr_95CE_cp_0 = Main.gore[num151];
						expr_95CE_cp_0.velocity.Y = expr_95CE_cp_0.velocity.Y * 0.3f;
					}
				}
				if (!flag11)
				{
					if (this.inventory[this.selectedItem].type == 989 && Main.rand.Next(5) == 0)
					{
						int num152 = Main.rand.Next(3);
						if (num152 == 0)
						{
							num152 = 15;
						}
						else if (num152 == 1)
						{
							num152 = 57;
						}
						else
						{
							num152 = 58;
						}
						int num153 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, num152, (float)(this.direction * 2), 0f, 150, default(Color), 1.3f);
						Main.dust[num153].velocity *= 0.2f;
					}
					if ((this.inventory[this.selectedItem].type == 44 || this.inventory[this.selectedItem].type == 45 || this.inventory[this.selectedItem].type == 46 || this.inventory[this.selectedItem].type == 103 || this.inventory[this.selectedItem].type == 104) && Main.rand.Next(15) == 0)
					{
						Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 14, (float)(this.direction * 2), 0f, 150, default(Color), 1.3f);
					}
					if (this.inventory[this.selectedItem].type == 273 || this.inventory[this.selectedItem].type == 675)
					{
						if (Main.rand.Next(5) == 0)
						{
							Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 14, (float)(this.direction * 2), 0f, 150, default(Color), 1.4f);
						}
						int num154 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 27, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.2f);
						Main.dust[num154].noGravity = true;
						Dust expr_988F_cp_0 = Main.dust[num154];
						expr_988F_cp_0.velocity.X = expr_988F_cp_0.velocity.X / 2f;
						Dust expr_98AD_cp_0 = Main.dust[num154];
						expr_98AD_cp_0.velocity.Y = expr_98AD_cp_0.velocity.Y / 2f;
					}
					if (this.inventory[this.selectedItem].type == 723 && Main.rand.Next(2) == 0)
					{
						int num155 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 64, 0f, 0f, 150, default(Color), 1.2f);
						Main.dust[num155].noGravity = true;
					}
					if (this.inventory[this.selectedItem].type == 65)
					{
						if (Main.rand.Next(5) == 0)
						{
							Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 58, 0f, 0f, 150, default(Color), 1.2f);
						}
						if (Main.rand.Next(10) == 0)
						{
							Gore.NewGore(new Vector2((float)rectangle.X, (float)rectangle.Y), default(Vector2), Main.rand.Next(16, 18), 1f);
						}
					}
					if (this.inventory[this.selectedItem].type == 190 || this.inventory[this.selectedItem].type == 213)
					{
						int num156 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 40, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 0, default(Color), 1.2f);
						Main.dust[num156].noGravity = true;
					}
					if (this.inventory[this.selectedItem].type == 121)
					{
						for (int num157 = 0; num157 < 2; num157++)
						{
							int num158 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
							Main.dust[num158].noGravity = true;
							Dust expr_9B51_cp_0 = Main.dust[num158];
							expr_9B51_cp_0.velocity.X = expr_9B51_cp_0.velocity.X * 2f;
							Dust expr_9B6F_cp_0 = Main.dust[num158];
							expr_9B6F_cp_0.velocity.Y = expr_9B6F_cp_0.velocity.Y * 2f;
						}
					}
					if (this.inventory[this.selectedItem].type == 122 || this.inventory[this.selectedItem].type == 217)
					{
						int num159 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.9f);
						Main.dust[num159].noGravity = true;
					}
					if (this.inventory[this.selectedItem].type == 155)
					{
						int num160 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 172, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 0.9f);
						Main.dust[num160].noGravity = true;
						Main.dust[num160].velocity *= 0.1f;
					}
					if ((this.inventory[this.selectedItem].type == 676 || this.inventory[this.selectedItem].type == 673) && Main.rand.Next(3) == 0)
					{
						int num161 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 67, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 90, default(Color), 1.5f);
						Main.dust[num161].noGravity = true;
						Main.dust[num161].velocity *= 0.2f;
					}
					if (this.inventory[this.selectedItem].type == 724 && Main.rand.Next(5) == 0)
					{
						int num162 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 67, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 90, default(Color), 1.5f);
						Main.dust[num162].noGravity = true;
						Main.dust[num162].velocity *= 0.2f;
					}
					if (this.inventory[this.selectedItem].type >= 795 && this.inventory[this.selectedItem].type <= 802 && Main.rand.Next(3) == 0)
					{
						int num163 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 115, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 140, default(Color), 1.5f);
						Main.dust[num163].noGravity = true;
						Main.dust[num163].velocity *= 0.25f;
					}
					if (this.inventory[this.selectedItem].type == 367 || this.inventory[this.selectedItem].type == 368 || this.inventory[this.selectedItem].type == 674)
					{
						if (Main.rand.Next(3) == 0)
						{
							int num164 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.1f);
							Main.dust[num164].noGravity = true;
							Dust expr_A05B_cp_0 = Main.dust[num164];
							expr_A05B_cp_0.velocity.X = expr_A05B_cp_0.velocity.X / 2f;
							Dust expr_A079_cp_0 = Main.dust[num164];
							expr_A079_cp_0.velocity.Y = expr_A079_cp_0.velocity.Y / 2f;
							Dust expr_A097_cp_0 = Main.dust[num164];
							expr_A097_cp_0.velocity.X = expr_A097_cp_0.velocity.X + (float)(this.direction * 2);
						}
						if (Main.rand.Next(4) == 0)
						{
							int num164 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 43, 0f, 0f, 254, default(Color), 0.3f);
							Main.dust[num164].velocity *= 0f;
						}
					}
					if (this.inventory[this.selectedItem].type >= 198 && this.inventory[this.selectedItem].type <= 203)
					{
						float num165 = 0.5f;
						float num166 = 0.5f;
						float num167 = 0.5f;
						if (this.inventory[this.selectedItem].type == 198)
						{
							num165 *= 0.1f;
							num166 *= 0.5f;
							num167 *= 1.2f;
						}
						else if (this.inventory[this.selectedItem].type == 199)
						{
							num165 *= 1f;
							num166 *= 0.2f;
							num167 *= 0.1f;
						}
						else if (this.inventory[this.selectedItem].type == 200)
						{
							num165 *= 0.1f;
							num166 *= 1f;
							num167 *= 0.2f;
						}
						else if (this.inventory[this.selectedItem].type == 201)
						{
							num165 *= 0.8f;
							num166 *= 0.1f;
							num167 *= 1f;
						}
						else if (this.inventory[this.selectedItem].type == 202)
						{
							num165 *= 0.8f;
							num166 *= 0.9f;
							num167 *= 1f;
						}
						else if (this.inventory[this.selectedItem].type == 203)
						{
							num165 *= 0.9f;
							num166 *= 0.9f;
							num167 *= 0.1f;
						}
					}
					if (this.frostBurn && this.inventory[this.selectedItem].melee && !this.inventory[this.selectedItem].noMelee && !this.inventory[this.selectedItem].noUseGraphic && Main.rand.Next(2) == 0)
					{
						int num168 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 135, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
						Main.dust[num168].noGravity = true;
						Main.dust[num168].velocity *= 0.7f;
						Dust expr_A41D_cp_0 = Main.dust[num168];
						expr_A41D_cp_0.velocity.Y = expr_A41D_cp_0.velocity.Y - 0.5f;
					}
					if (this.inventory[this.selectedItem].melee && !this.inventory[this.selectedItem].noMelee && !this.inventory[this.selectedItem].noUseGraphic && this.meleeEnchant > 0)
					{
						if (this.meleeEnchant == 1)
						{
							if (Main.rand.Next(3) == 0)
							{
								int num169 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 171, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num169].noGravity = true;
								Main.dust[num169].fadeIn = 1.5f;
								Main.dust[num169].velocity *= 0.25f;
							}
						}
						else if (this.meleeEnchant == 2)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num170 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 75, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
								Main.dust[num170].noGravity = true;
								Main.dust[num170].velocity *= 0.7f;
								Dust expr_A5EC_cp_0 = Main.dust[num170];
								expr_A5EC_cp_0.velocity.Y = expr_A5EC_cp_0.velocity.Y - 0.5f;
							}
						}
						else if (this.meleeEnchant == 3)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num171 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
								Main.dust[num171].noGravity = true;
								Main.dust[num171].velocity *= 0.7f;
								Dust expr_A6C2_cp_0 = Main.dust[num171];
								expr_A6C2_cp_0.velocity.Y = expr_A6C2_cp_0.velocity.Y - 0.5f;
							}
						}
						else if (this.meleeEnchant == 4)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num172 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.1f);
								Main.dust[num172].noGravity = true;
								Dust expr_A77F_cp_0 = Main.dust[num172];
								expr_A77F_cp_0.velocity.X = expr_A77F_cp_0.velocity.X / 2f;
								Dust expr_A79D_cp_0 = Main.dust[num172];
								expr_A79D_cp_0.velocity.Y = expr_A79D_cp_0.velocity.Y / 2f;
							}
						}
						else if (this.meleeEnchant == 5)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num173 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 169, 0f, 0f, 100, default(Color), 1f);
								Dust expr_A82A_cp_0 = Main.dust[num173];
								expr_A82A_cp_0.velocity.X = expr_A82A_cp_0.velocity.X + (float)this.direction;
								Dust expr_A84A_cp_0 = Main.dust[num173];
								expr_A84A_cp_0.velocity.Y = expr_A84A_cp_0.velocity.Y + 0.2f;
								Main.dust[num173].noGravity = true;
							}
						}
						else if (this.meleeEnchant == 6)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num174 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 135, 0f, 0f, 100, default(Color), 1f);
								Dust expr_A8E5_cp_0 = Main.dust[num174];
								expr_A8E5_cp_0.velocity.X = expr_A8E5_cp_0.velocity.X + (float)this.direction;
								Dust expr_A905_cp_0 = Main.dust[num174];
								expr_A905_cp_0.velocity.Y = expr_A905_cp_0.velocity.Y + 0.2f;
								Main.dust[num174].noGravity = true;
							}
						}
						else if (this.meleeEnchant == 7)
						{
							if (Main.rand.Next(20) == 0)
							{
								int type3 = Main.rand.Next(139, 143);
								int num175 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, type3, this.velocity.X, this.velocity.Y, 0, default(Color), 1.2f);
								Dust expr_A9BF_cp_0 = Main.dust[num175];
								expr_A9BF_cp_0.velocity.X = expr_A9BF_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
								Dust expr_A9F3_cp_0 = Main.dust[num175];
								expr_A9F3_cp_0.velocity.Y = expr_A9F3_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
								Dust expr_AA27_cp_0 = Main.dust[num175];
								expr_AA27_cp_0.velocity.X = expr_AA27_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
								Dust expr_AA55_cp_0 = Main.dust[num175];
								expr_AA55_cp_0.velocity.Y = expr_AA55_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
								Main.dust[num175].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
							}
							if (Main.rand.Next(40) == 0)
							{
								int type4 = Main.rand.Next(276, 283);
								int num176 = Gore.NewGore(new Vector2((float)rectangle.X, (float)rectangle.Y), this.velocity, type4, 1f);
								Gore expr_AB02_cp_0 = Main.gore[num176];
								expr_AB02_cp_0.velocity.X = expr_AB02_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
								Gore expr_AB36_cp_0 = Main.gore[num176];
								expr_AB36_cp_0.velocity.Y = expr_AB36_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
								Main.gore[num176].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
								Gore expr_AB99_cp_0 = Main.gore[num176];
								expr_AB99_cp_0.velocity.X = expr_AB99_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
								Gore expr_ABC7_cp_0 = Main.gore[num176];
								expr_ABC7_cp_0.velocity.Y = expr_ABC7_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
							}
						}
						else if (this.meleeEnchant == 8 && Main.rand.Next(4) == 0)
						{
							int num177 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 46, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num177].noGravity = true;
							Main.dust[num177].fadeIn = 1.5f;
							Main.dust[num177].velocity *= 0.25f;
						}
					}
					if (this.magmaStone && !this.inventory[this.selectedItem].magic && !this.inventory[this.selectedItem].ranged && Main.rand.Next(3) != 0)
					{
						int num178 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
						Main.dust[num178].noGravity = true;
						Dust expr_AD61_cp_0 = Main.dust[num178];
						expr_AD61_cp_0.velocity.X = expr_AD61_cp_0.velocity.X * 2f;
						Dust expr_AD7F_cp_0 = Main.dust[num178];
						expr_AD7F_cp_0.velocity.Y = expr_AD7F_cp_0.velocity.Y * 2f;
					}
					if (Main.myPlayer == i && this.inventory[this.selectedItem].type != 1450)
					{
						int num179 = (int)((float)this.inventory[this.selectedItem].damage * this.meleeDamage);
						float num180 = this.inventory[this.selectedItem].knockBack;
						if (this.kbGlove)
						{
							num180 *= 2f;
						}
						int num181 = rectangle.X / 16;
						int num182 = (rectangle.X + rectangle.Width) / 16 + 1;
						int num183 = rectangle.Y / 16;
						int num184 = (rectangle.Y + rectangle.Height) / 16 + 1;
						for (int num185 = num181; num185 < num182; num185++)
						{
							for (int num186 = num183; num186 < num184; num186++)
							{
								if (Main.tile[num185, num186] != null && Main.tileCut[(int)Main.tile[num185, num186].type] && Main.tile[num185, num186 + 1] != null && Main.tile[num185, num186 + 1].type != 78)
								{
									if (this.inventory[this.selectedItem].type == 1786)
									{
										int type5 = (int)Main.tile[num185, num186].type;
										WorldGen.KillTile(num185, num186, false, false, false);
										if (!Main.tile[num185, num186].active())
										{
											int num187 = 0;
											if (type5 == 3 || type5 == 24 || type5 == 61 || type5 == 110 || type5 == 201)
											{
												num187 = Main.rand.Next(1, 3);
											}
											if (type5 == 73 || type5 == 74 || type5 == 113)
											{
												num187 = Main.rand.Next(2, 5);
											}
											if (num187 > 0)
											{
												int number = Item.NewItem(num185 * 16, num186 * 16, 16, 16, 1727, num187, false, 0, false);
												if (Main.netMode == 1)
												{
													NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0);
												}
											}
										}
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)num185, (float)num186, 0f, 0);
										}
									}
									else
									{
										WorldGen.KillTile(num185, num186, false, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)num185, (float)num186, 0f, 0);
										}
									}
								}
							}
						}
						for (int num188 = 0; num188 < 200; num188++)
						{
							if (Main.npc[num188].active && Main.npc[num188].immune[i] == 0 && this.attackCD == 0 && !Main.npc[num188].dontTakeDamage && (!Main.npc[num188].friendly || (Main.npc[num188].type == 22 && this.killGuide) || (Main.npc[num188].type == 54 && this.killClothier)))
							{
								Rectangle value = new Rectangle((int)Main.npc[num188].position.X, (int)Main.npc[num188].position.Y, Main.npc[num188].width, Main.npc[num188].height);
								if (rectangle.Intersects(value) && (Main.npc[num188].noTileCollide || Collision.CanHit(this.position, this.width, this.height, Main.npc[num188].position, Main.npc[num188].width, Main.npc[num188].height)))
								{
									bool flag12 = false;
									if (Main.rand.Next(1, 101) <= this.meleeCrit)
									{
										flag12 = true;
									}
									int num189 = Main.DamageVar((float)num179);
									this.StatusNPC(this.inventory[this.selectedItem].type, num188);
									this.onHit(Main.npc[num188].center().X, Main.npc[num188].center().Y);
									Main.npc[num188].StrikeNPC(num189, num180, this.direction, flag12, false);
									if (this.inventory[this.selectedItem].type == 1826)
									{
										this.pumpkinSword(num188, (int)((double)num179 * 1.5), num180);
									}
									if (this.meleeEnchant == 7)
									{
										Projectile.NewProjectile(Main.npc[num188].center().X, Main.npc[num188].center().Y, Main.npc[num188].velocity.X, Main.npc[num188].velocity.Y, 289, 0, 0f, this.whoAmi, 0f, 0f);
									}
									if (this.inventory[this.selectedItem].type == 1123)
									{
										int num190 = Main.rand.Next(1, 4);
										for (int num191 = 0; num191 < num190; num191++)
										{
											float num192 = (float)(this.direction * 2) + (float)Main.rand.Next(-35, 36) * 0.02f;
											float num193 = (float)Main.rand.Next(-35, 36) * 0.02f;
											num192 *= 0.2f;
											num193 *= 0.2f;
											Projectile.NewProjectile((float)(rectangle.X + rectangle.Width / 2), (float)(rectangle.Y + rectangle.Height / 2), num192, num193, 181, num189 / 3, 0f, i, 0f, 0f);
										}
									}
									if (Main.npc[num188].value > 0f && this.coins && Main.rand.Next(5) == 0)
									{
										int type6 = 71;
										if (Main.rand.Next(10) == 0)
										{
											type6 = 72;
										}
										if (Main.rand.Next(100) == 0)
										{
											type6 = 73;
										}
										int num194 = Item.NewItem((int)Main.npc[num188].position.X, (int)Main.npc[num188].position.Y, Main.npc[num188].width, Main.npc[num188].height, type6, 1, false, 0, false);
										Main.item[num194].stack = Main.rand.Next(1, 11);
										Main.item[num194].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
										Main.item[num194].velocity.X = (float)Main.rand.Next(10, 31) * 0.2f * (float)this.direction;
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num194, 0f, 0f, 0f, 0);
										}
									}
									if (Main.netMode != 0)
									{
										if (flag12)
										{
											NetMessage.SendData(28, -1, -1, "", num188, (float)num189, num180, (float)this.direction, 1);
										}
										else
										{
											NetMessage.SendData(28, -1, -1, "", num188, (float)num189, num180, (float)this.direction, 0);
										}
									}
									Main.npc[num188].immune[i] = this.itemAnimation;
									this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
								}
							}
						}
						if (this.hostile)
						{
							for (int num195 = 0; num195 < 255; num195++)
							{
								if (num195 != i && Main.player[num195].active && Main.player[num195].hostile && !Main.player[num195].immune && !Main.player[num195].dead && (Main.player[i].team == 0 || Main.player[i].team != Main.player[num195].team))
								{
									Rectangle value2 = new Rectangle((int)Main.player[num195].position.X, (int)Main.player[num195].position.Y, Main.player[num195].width, Main.player[num195].height);
									if (rectangle.Intersects(value2) && Collision.CanHit(this.position, this.width, this.height, Main.player[num195].position, Main.player[num195].width, Main.player[num195].height))
									{
										bool flag13 = false;
										if (Main.rand.Next(1, 101) <= 10)
										{
											flag13 = true;
										}
										int num196 = Main.DamageVar((float)num179);
										this.StatusPvP(this.inventory[this.selectedItem].type, num195);
										this.onHit(Main.player[num195].center().X, Main.player[num195].center().Y);
										Main.player[num195].Hurt(num196, this.direction, true, false, "", flag13);
										if (this.meleeEnchant == 7)
										{
											Projectile.NewProjectile(Main.player[num195].center().X, Main.player[num195].center().Y, Main.player[num195].velocity.X, Main.player[num195].velocity.Y, 289, 0, 0f, this.whoAmi, 0f, 0f);
										}
										if (this.inventory[this.selectedItem].type == 1123)
										{
											int num197 = Main.rand.Next(1, 4);
											for (int num198 = 0; num198 < num197; num198++)
											{
												float num199 = (float)(this.direction * 2) + (float)Main.rand.Next(-35, 36) * 0.02f;
												float num200 = (float)Main.rand.Next(-35, 36) * 0.02f;
												num199 *= 0.2f;
												num200 *= 0.2f;
												Projectile.NewProjectile((float)(rectangle.X + rectangle.Width / 2), (float)(rectangle.Y + rectangle.Height / 2), num199, num200, 181, num196 / 3, 0f, i, 0f, 0f);
											}
										}
										if (Main.netMode != 0)
										{
											if (flag13)
											{
												NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.whoAmi, -1, -1, -1), num195, (float)this.direction, (float)num196, 1f, 1);
											}
											else
											{
												NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.whoAmi, -1, -1, -1), num195, (float)this.direction, (float)num196, 1f, 0);
											}
										}
										this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
									}
								}
							}
						}
						if (this.inventory[this.selectedItem].type == 787 && (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.5) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9)))
						{
							float num201 = 0f;
							float num202 = 0f;
							float num203 = 0f;
							float num204 = 0f;
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9))
							{
								num201 = -7f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
							{
								num201 = -6f;
								num202 = 2f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.5))
							{
								num201 = -4f;
								num202 = 4f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3))
							{
								num201 = -2f;
								num202 = 6f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1))
							{
								num202 = 7f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
							{
								num204 = 26f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3))
							{
								num204 -= 4f;
								num203 -= 20f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1))
							{
								num203 += 6f;
							}
							if (this.direction == -1)
							{
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9))
								{
									num204 -= 8f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
								{
									num204 -= 6f;
								}
							}
							num201 *= 1.5f;
							num202 *= 1.5f;
							num204 *= (float)this.direction;
							num203 *= this.gravDir;
							Projectile.NewProjectile((float)(rectangle.X + rectangle.Width / 2) + num204, (float)(rectangle.Y + rectangle.Height / 2) + num203, (float)this.direction * num202, num201 * this.gravDir, 131, num179 / 2, 0f, i, 0f, 0f);
						}
					}
				}
			}
			if (this.itemTime == 0 && this.itemAnimation > 0)
			{
				if (this.inventory[this.selectedItem].healLife > 0)
				{
					this.statLife += this.inventory[this.selectedItem].healLife;
					this.itemTime = this.inventory[this.selectedItem].useTime;
					if (Main.myPlayer == this.whoAmi)
					{
						this.HealEffect(this.inventory[this.selectedItem].healLife, true);
					}
				}
				if (this.inventory[this.selectedItem].healMana > 0)
				{
					this.statMana += this.inventory[this.selectedItem].healMana;
					this.itemTime = this.inventory[this.selectedItem].useTime;
					if (Main.myPlayer == this.whoAmi)
					{
						this.ManaEffect(this.inventory[this.selectedItem].healMana);
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
				if (this.itemTime == 0 && this.itemAnimation > 0 && (this.inventory[this.selectedItem].type == 43 || this.inventory[this.selectedItem].type == 70 || this.inventory[this.selectedItem].type == 544 || this.inventory[this.selectedItem].type == 556 || this.inventory[this.selectedItem].type == 557 || this.inventory[this.selectedItem].type == 560 || this.inventory[this.selectedItem].type == 1133 || this.inventory[this.selectedItem].type == 1331))
				{
					bool flag14 = false;
					for (int num205 = 0; num205 < 200; num205++)
					{
						if (Main.npc[num205].active && ((this.inventory[this.selectedItem].type == 43 && Main.npc[num205].type == 4) || (this.inventory[this.selectedItem].type == 70 && Main.npc[num205].type == 13) || ((this.inventory[this.selectedItem].type == 560 & Main.npc[num205].type == 50) || (this.inventory[this.selectedItem].type == 544 && Main.npc[num205].type == 125)) || (this.inventory[this.selectedItem].type == 544 && Main.npc[num205].type == 126) || (this.inventory[this.selectedItem].type == 556 && Main.npc[num205].type == 134) || (this.inventory[this.selectedItem].type == 557 && Main.npc[num205].type == 128) || (this.inventory[this.selectedItem].type == 1133 && Main.npc[num205].type == 222) || (this.inventory[this.selectedItem].type == 1331 && Main.npc[num205].type == 266)))
						{
							flag14 = true;
							break;
						}
					}
					if (flag14)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
					}
					else if (this.inventory[this.selectedItem].type == 560)
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
					for (int num206 = 0; num206 < 70; num206++)
					{
						Dust.NewDust(this.position, this.width, this.height, 15, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, default(Color), 1.5f);
					}
					this.grappling[0] = -1;
					this.grapCount = 0;
					for (int num207 = 0; num207 < 1000; num207++)
					{
						if (Main.projectile[num207].active && Main.projectile[num207].owner == i && Main.projectile[num207].aiStyle == 7)
						{
							Main.projectile[num207].Kill();
						}
					}
					this.Spawn();
					for (int num208 = 0; num208 < 70; num208++)
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
					int num209 = 0;
					while (num209 < 58)
					{
						if (tileWand2 == this.inventory[num209].type && this.inventory[num209].stack > 0)
						{
							this.inventory[num209].stack--;
							if (this.inventory[num209].stack <= 0)
							{
								this.inventory[num209] = new Item();
								break;
							}
							break;
						}
						else
						{
							num209++;
						}
					}
				}
				if (this.itemTime == this.inventory[this.selectedItem].useTime && this.inventory[this.selectedItem].consumable)
				{
					bool flag15 = true;
					if (this.inventory[this.selectedItem].ranged)
					{
						if (this.ammoCost80 && Main.rand.Next(5) == 0)
						{
							flag15 = false;
						}
						if (this.ammoCost75 && Main.rand.Next(4) == 0)
						{
							flag15 = false;
						}
					}
					if (flag15)
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
					Main.mouseItem = (Item)this.inventory[this.selectedItem].Clone();
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
						Main.mouseItem = (Item)this.inventory[i].Clone();
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
				if (i < 11)
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
			for (int i = 0; i < 59; i++)
			{
				player.inventory[i] = (Item)this.inventory[i].Clone();
				if (i < 11)
				{
					player.armor[i] = (Item)this.armor[i].Clone();
				}
				if (i < 3)
				{
					player.dye[i] = (Item)this.dye[i].Clone();
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
			for (int i = 0; i < 59; i++)
			{
				if (i < 11)
				{
					this.armor[i] = new Item();
					this.armor[i].name = "";
				}
				this.inventory[i] = new Item();
				this.inventory[i].name = "";
			}
			for (int j = 0; j < Chest.maxItems; j++)
			{
				this.bank[j] = new Item();
				this.bank[j].name = "";
				this.bank2[j] = new Item();
				this.bank2[j].name = "";
			}
			for (int k = 0; k < 3; k++)
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
			for (int l = 0; l < 255; l++)
			{
				this.adjTile[l] = false;
				this.oldAdjTile[l] = false;
			}
		}
	}
}
