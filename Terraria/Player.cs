using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace Terraria
{
	public class Player
	{
		public const int maxBuffs = 10;
		public Vector2[] itemFlamePos = new Vector2[7];
		public int itemFlameCount;
		public bool outOfRange;
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
		public int wingTime;
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
		public int[] buffType = new int[10];
		public int[] buffTime = new int[10];
		public bool[] buffImmune = new bool[86];
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
		public bool lightOrb;
		public bool fairy;
		public bool bunny;
		public bool turtle;
		public bool eater;
		public bool penguin;
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
				for (int i = 0; i < 10; i++)
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
			for (int j = 0; j < 10; j++)
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
				for (int k = 0; k < 10; k++)
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
				for (int l = 0; l < 10; l++)
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
				for (int m = num2; m < 10; m++)
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
				for (int n = 0; n < 10; n++)
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
			for (int i = 0; i < 9; i++)
			{
				if (this.buffTime[i] == 0 || this.buffType[i] == 0)
				{
					for (int j = i + 1; j < 10; j++)
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
			for (int i = 0; i < 10; i++)
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
				if (this.countBuffs() == 10)
				{
					return;
				}
				if (this.inventory[i].stack > 0 && this.inventory[i].type > 0 && this.inventory[i].buffType > 0 && !this.inventory[i].summon)
				{
					bool flag = true;
					for (int j = 0; j < 10; j++)
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
						for (int k = 0; k < 10; k++)
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
			/*if (Main.hasFocus && !Main.chatMode && !Main.editSign)
			{
				Keys[] pressedKeys = Main.keyState.GetPressedKeys();
				for (int i = 0; i < pressedKeys.Length; i++)
				{
					string a = string.Concat(pressedKeys[i]);
					if (a == Main.cUp)
					{
						this.controlUp = true;
					}
					if (a == Main.cLeft)
					{
						this.controlLeft = true;
					}
					if (a == Main.cDown)
					{
						this.controlDown = true;
					}
					if (a == Main.cRight)
					{
						this.controlRight = true;
					}
					if (a == Main.cJump)
					{
						this.controlJump = true;
					}
				}
			}*/
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
			else if (Main.rand.Next(3) == 1)
			{
				int number2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1809, Main.rand.Next(10, 41), false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number2, 1f, 0f, 0f, 0);
					return;
				}
			}
			else if (Main.rand.Next(10) == 0)
			{
				int number3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Main.rand.Next(1846, 1851), 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number3, 1f, 0f, 0f, 0);
					return;
				}
			}
			else
			{
				int num = Main.rand.Next(19);
				if (num == 0)
				{
					int number4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1749, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number4, 1f, 0f, 0f, 0);
					}
					number4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1750, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number4, 1f, 0f, 0f, 0);
					}
					number4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1751, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number4, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 1)
				{
					int number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1746, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0);
					}
					number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1747, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0);
					}
					number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1748, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 2)
				{
					int number6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1752, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number6, 1f, 0f, 0f, 0);
					}
					number6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1753, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number6, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 3)
				{
					int number7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1767, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number7, 1f, 0f, 0f, 0);
					}
					number7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1768, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number7, 1f, 0f, 0f, 0);
					}
					number7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1769, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number7, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 4)
				{
					int number8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1770, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number8, 1f, 0f, 0f, 0);
					}
					number8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1771, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number8, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 5)
				{
					int number9 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1772, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number9, 1f, 0f, 0f, 0);
					}
					number9 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1773, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number9, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 6)
				{
					int number10 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1754, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number10, 1f, 0f, 0f, 0);
					}
					number10 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1755, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number10, 1f, 0f, 0f, 0);
					}
					number10 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1756, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number10, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 7)
				{
					int number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1757, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0);
					}
					number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1758, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0);
					}
					number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1759, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 8)
				{
					int number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1760, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0);
					}
					number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1761, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0);
					}
					number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1762, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 9)
				{
					int number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1763, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0);
					}
					number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1764, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0);
					}
					number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1765, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 10)
				{
					int number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1766, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0);
					}
					number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1775, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0);
					}
					number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1776, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 11)
				{
					int number15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1777, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number15, 1f, 0f, 0f, 0);
					}
					number15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1778, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number15, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 12)
				{
					int number16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1779, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number16, 1f, 0f, 0f, 0);
					}
					number16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1780, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number16, 1f, 0f, 0f, 0);
					}
					number16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1781, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number16, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 13)
				{
					int number17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1819, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number17, 1f, 0f, 0f, 0);
					}
					number17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1820, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number17, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 14)
				{
					int number18 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1821, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number18, 1f, 0f, 0f, 0);
					}
					number18 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1822, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number18, 1f, 0f, 0f, 0);
					}
					number18 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1823, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number18, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 15)
				{
					int number19 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1824, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number19, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 16)
				{
					int number20 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1838, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number20, 1f, 0f, 0f, 0);
					}
					number20 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1839, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number20, 1f, 0f, 0f, 0);
					}
					number20 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1840, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number20, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 17)
				{
					int number21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1841, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number21, 1f, 0f, 0f, 0);
					}
					number21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1842, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number21, 1f, 0f, 0f, 0);
					}
					number21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1843, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number21, 1f, 0f, 0f, 0);
						return;
					}
				}
				else if (num == 18)
				{
					int number22 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1851, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number22, 1f, 0f, 0f, 0);
					}
					number22 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1852, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number22, 1f, 0f, 0f, 0);
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
					Vector2[] expr_306_cp_0 = this.shadowPos;
					int expr_306_cp_1 = 0;
					expr_306_cp_0[expr_306_cp_1].Y = expr_306_cp_0[expr_306_cp_1].Y + this.gfxOffY;
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
					for (int j = 0; j < 10; j++)
					{
						this.buffTime[j] = 0;
						this.buffType[j] = 0;
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
					/*if (i == Main.myPlayer)
					{
						this.controlUp = false;
						this.controlLeft = false;
						this.controlDown = false;
						this.controlRight = false;
						this.controlJump = false;
						this.controlUseItem = false;
						this.controlUseTile = false;
						this.controlThrow = false;
						this.controlInv = false;
						this.controlHook = false;
						this.controlTorch = false;
						this.mapStyle = false;
						this.mapAlphaDown = false;
						this.mapAlphaUp = false;
						this.mapFullScreen = false;
						this.mapZoomIn = false;
						this.mapZoomOut = false;
						if (Main.hasFocus)
						{
							if (!Main.chatMode && !Main.editSign)
							{
								Keys[] pressedKeys = Main.keyState.GetPressedKeys();
								bool flag2 = false;
								bool flag3 = false;
								for (int k = 0; k < pressedKeys.Length; k++)
								{
									string a = string.Concat(pressedKeys[k]);
									if (a == Main.cUp)
									{
										this.controlUp = true;
									}
									if (a == Main.cLeft)
									{
										this.controlLeft = true;
									}
									if (a == Main.cDown)
									{
										this.controlDown = true;
									}
									if (a == Main.cRight)
									{
										this.controlRight = true;
									}
									if (a == Main.cJump)
									{
										this.controlJump = true;
									}
									if (a == Main.cThrowItem)
									{
										this.controlThrow = true;
									}
									if (a == Main.cInv)
									{
										this.controlInv = true;
									}
									if (a == Main.cBuff)
									{
										this.QuickBuff();
									}
									if (a == Main.cHeal)
									{
										flag3 = true;
									}
									if (a == Main.cMana)
									{
										flag2 = true;
									}
									if (a == Main.cHook)
									{
										this.controlHook = true;
									}
									if (a == Main.cTorch)
									{
										this.controlTorch = true;
									}
									if (Main.mapEnabled)
									{
										if (a == Main.cMapZoomIn)
										{
											this.mapZoomIn = true;
										}
										if (a == Main.cMapZoomOut)
										{
											this.mapZoomOut = true;
										}
										if (a == Main.cMapAlphaUp)
										{
											this.mapAlphaUp = true;
										}
										if (a == Main.cMapAlphaDown)
										{
											this.mapAlphaDown = true;
										}
										if (a == Main.cMapFull)
										{
											this.mapFullScreen = true;
										}
										if (a == Main.cMapStyle)
										{
											this.mapStyle = true;
										}
									}
								}
								if (Main.gamePad)
								{
									GamePadState state = GamePad.GetState(PlayerIndex.One);
									if (state.DPad.Up == ButtonState.Pressed)
									{
										this.controlUp = true;
									}
									if (state.DPad.Down == ButtonState.Pressed)
									{
										this.controlDown = true;
									}
									if (state.DPad.Left == ButtonState.Pressed)
									{
										this.controlLeft = true;
									}
									if (state.DPad.Right == ButtonState.Pressed)
									{
										this.controlRight = true;
									}
									if (state.Triggers.Left > 0f)
									{
										this.controlJump = true;
									}
									if (state.Triggers.Right > 0f)
									{
										this.controlUseItem = true;
									}
									Main.mouseX = (int)((float)(Main.screenWidth / 2) + state.ThumbSticks.Right.X * (float)Player.tileRangeX * 16f);
									Main.mouseY = (int)((float)(Main.screenHeight / 2) - state.ThumbSticks.Right.Y * (float)Player.tileRangeX * 16f);
									if (state.ThumbSticks.Right.X == 0f)
									{
										Main.mouseX = Main.screenWidth / 2 + this.direction * 2;
									}
								}
								if (Main.mapFullscreen)
								{
									if (this.controlUp)
									{
										Main.mapFullscreenPos.Y = Main.mapFullscreenPos.Y - 1f * (16f / Main.mapFullscreenScale);
									}
									if (this.controlDown)
									{
										Main.mapFullscreenPos.Y = Main.mapFullscreenPos.Y + 1f * (16f / Main.mapFullscreenScale);
									}
									if (this.controlLeft)
									{
										Main.mapFullscreenPos.X = Main.mapFullscreenPos.X - 1f * (16f / Main.mapFullscreenScale);
									}
									if (this.controlRight)
									{
										Main.mapFullscreenPos.X = Main.mapFullscreenPos.X + 1f * (16f / Main.mapFullscreenScale);
									}
									this.controlUp = false;
									this.controlLeft = false;
									this.controlDown = false;
									this.controlRight = false;
									this.controlJump = false;
									this.controlUseItem = false;
									this.controlUseTile = false;
									this.controlThrow = false;
									this.controlHook = false;
									this.controlTorch = false;
								}
								if (flag3)
								{
									if (this.releaseQuickHeal)
									{
										this.QuickHeal();
									}
									this.releaseQuickHeal = false;
								}
								else
								{
									this.releaseQuickHeal = true;
								}
								if (flag2)
								{
									if (this.releaseQuickMana)
									{
										this.QuickMana();
									}
									this.releaseQuickMana = false;
								}
								else
								{
									this.releaseQuickMana = true;
								}
								if (this.controlLeft && this.controlRight)
								{
									this.controlLeft = false;
									this.controlRight = false;
								}
								if (Main.mapFullscreen)
								{
									if (this.mapZoomIn)
									{
										Main.mapFullscreenScale *= 1.05f;
									}
									if (this.mapZoomOut)
									{
										Main.mapFullscreenScale *= 0.95f;
									}
								}
								else
								{
									if (Main.mapStyle == 1)
									{
										if (this.mapZoomIn)
										{
											Main.mapMinimapScale *= 1.025f;
										}
										if (this.mapZoomOut)
										{
											Main.mapMinimapScale *= 0.975f;
										}
										if (this.mapAlphaUp)
										{
											Main.mapMinimapAlpha += 0.015f;
										}
										if (this.mapAlphaDown)
										{
											Main.mapMinimapAlpha -= 0.015f;
										}
									}
									else if (Main.mapStyle == 2)
									{
										if (this.mapZoomIn)
										{
											Main.mapOverlayScale *= 1.05f;
										}
										if (this.mapZoomOut)
										{
											Main.mapOverlayScale *= 0.95f;
										}
										if (this.mapAlphaUp)
										{
											Main.mapOverlayAlpha += 0.015f;
										}
										if (this.mapAlphaDown)
										{
											Main.mapOverlayAlpha -= 0.015f;
										}
									}
									if (this.mapStyle)
									{
										if (this.releaseMapStyle)
										{
											Main.PlaySound(12, -1, -1, 1);
											Main.mapStyle++;
											if (Main.mapStyle > 2)
											{
												Main.mapStyle = 0;
											}
										}
										this.releaseMapStyle = false;
									}
									else
									{
										this.releaseMapStyle = true;
									}
								}
								if (this.mapFullScreen)
								{
									if (this.releaseMapFullscreen)
									{
										if (Main.mapFullscreen)
										{
											Main.PlaySound(11, -1, -1, 1);
											Main.mapFullscreen = false;
										}
										else
										{
											Main.playerInventory = false;
											this.talkNPC = -1;
											Main.PlaySound(10, -1, -1, 1);
											float mapFullscreenScale = 2.5f;
											Main.mapFullscreenScale = mapFullscreenScale;
											Main.mapFullscreen = true;
											Main.resetMapFull = true;
										}
									}
									this.releaseMapFullscreen = false;
								}
								else
								{
									this.releaseMapFullscreen = true;
								}
							}
							if (this.confused)
							{
								bool flag4 = this.controlLeft;
								bool flag5 = this.controlUp;
								this.controlLeft = this.controlRight;
								this.controlRight = flag4;
								this.controlUp = this.controlRight;
								this.controlDown = flag5;
							}
							if (Main.mouseLeft && !this.mouseInterface)
							{
								this.controlUseItem = true;
							}
							if (Main.mouseRight && !this.mouseInterface)
							{
								this.controlUseTile = true;
							}
							if (this.controlInv)
							{
								if (this.releaseInventory)
								{
									if (Main.mapFullscreen)
									{
										Main.mapFullscreen = false;
										this.releaseInventory = false;
										Main.PlaySound(11, -1, -1, 1);
									}
									else
									{
										this.toggleInv();
									}
								}
								this.releaseInventory = false;
							}
							else
							{
								this.releaseInventory = true;
							}
							if (this.delayUseItem)
							{
								if (!this.controlUseItem)
								{
									this.delayUseItem = false;
								}
								this.controlUseItem = false;
							}
							if (this.itemAnimation == 0 && this.itemTime == 0)
							{
								this.dropItemCheck();
								int num15 = this.selectedItem;
								if (!Main.chatMode && this.selectedItem != 58)
								{
									if (Main.keyState.IsKeyDown(Keys.D1))
									{
										this.selectedItem = 0;
									}
									if (Main.keyState.IsKeyDown(Keys.D2))
									{
										this.selectedItem = 1;
									}
									if (Main.keyState.IsKeyDown(Keys.D3))
									{
										this.selectedItem = 2;
									}
									if (Main.keyState.IsKeyDown(Keys.D4))
									{
										this.selectedItem = 3;
									}
									if (Main.keyState.IsKeyDown(Keys.D5))
									{
										this.selectedItem = 4;
									}
									if (Main.keyState.IsKeyDown(Keys.D6))
									{
										this.selectedItem = 5;
									}
									if (Main.keyState.IsKeyDown(Keys.D7))
									{
										this.selectedItem = 6;
									}
									if (Main.keyState.IsKeyDown(Keys.D8))
									{
										this.selectedItem = 7;
									}
									if (Main.keyState.IsKeyDown(Keys.D9))
									{
										this.selectedItem = 8;
									}
									if (Main.keyState.IsKeyDown(Keys.D0))
									{
										this.selectedItem = 9;
									}
								}
								if (num15 != this.selectedItem)
								{
									Main.PlaySound(12, -1, -1, 1);
								}
								if (Main.mapFullscreen)
								{
									int num16 = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
									Main.mapFullscreenScale *= 1f + (float)num16 * 0.3f;
								}
								else if (!Main.playerInventory)
								{
									int l;
									for (l = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120; l > 9; l -= 10)
									{
									}
									while (l < 0)
									{
										l += 10;
									}
									this.selectedItem -= l;
									if (l != 0)
									{
										Main.PlaySound(12, -1, -1, 1);
									}
									if (this.changeItem >= 0)
									{
										if (this.selectedItem != this.changeItem)
										{
											Main.PlaySound(12, -1, -1, 1);
										}
										this.selectedItem = this.changeItem;
										this.changeItem = -1;
									}
									while (this.selectedItem > 9)
									{
										this.selectedItem -= 10;
									}
									while (this.selectedItem < 0)
									{
										this.selectedItem += 10;
									}
								}
								else
								{
									int num17 = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
									Main.focusRecipe += num17;
									if (Main.focusRecipe > Main.numAvailableRecipes - 1)
									{
										Main.focusRecipe = Main.numAvailableRecipes - 1;
									}
									if (Main.focusRecipe < 0)
									{
										Main.focusRecipe = 0;
									}
								}
							}
						}
						if (this.selectedItem == 58)
						{
							this.nonTorch = -1;
						}
						else if (this.controlTorch && this.itemAnimation == 0)
						{
							int num18 = 0;
							int num19 = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
							int num20 = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
							if (this.gravDir == -1f)
							{
								num20 = (int)((Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16f);
							}
							if (this.position.X / 16f - (float)Player.tileRangeX <= (float)num19 && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX - 1f >= (float)num19 && this.position.Y / 16f - (float)Player.tileRangeY <= (float)num20 && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY - 2f >= (float)num20)
							{
								try
								{
									if (Main.tile[num19, num20].active())
									{
										int type = (int)Main.tile[num19, num20].type;
										if (type == 209)
										{
											num18 = 6;
										}
										else if (Main.tileHammer[type])
										{
											num18 = 1;
										}
										else if (Main.tileAxe[type])
										{
											num18 = 2;
										}
										else
										{
											num18 = 3;
										}
									}
									else if (Main.tile[num19, num20].liquid > 0 && this.wet)
									{
										num18 = 4;
									}
									goto IL_1561;
								}
								catch
								{
									goto IL_1561;
								}
							}
							if (this.wet)
							{
								num18 = 4;
							}
							IL_1561:
							if (num18 == 0)
							{
								float num21 = Math.Abs((float)Main.mouseX + Main.screenPosition.X - (this.position.X + (float)(this.width / 2)));
								float num22 = Math.Abs((float)Main.mouseY + Main.screenPosition.Y - (this.position.Y + (float)(this.height / 2))) * 1.3f;
								float num23 = (float)Math.Sqrt((double)(num21 * num21 + num22 * num22));
								if (num23 > 200f)
								{
									num18 = 5;
								}
							}
							for (int m = 0; m < 50; m++)
							{
								int type2 = this.inventory[m].type;
								if (num18 == 0)
								{
									if (type2 == 8 || type2 == 427 || type2 == 428 || type2 == 429 || type2 == 430 || type2 == 431 || type2 == 432 || type2 == 433 || type2 == 523 || type2 == 974 || type2 == 1245 || type2 == 1333)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										this.selectedItem = m;
										break;
									}
									if (type2 == 282 || type2 == 286)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										this.selectedItem = m;
									}
								}
								else if (num18 == 1)
								{
									if (this.inventory[m].hammer > 0)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										this.selectedItem = m;
										break;
									}
								}
								else if (num18 == 2)
								{
									if (this.inventory[m].axe > 0)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										this.selectedItem = m;
										break;
									}
								}
								else if (num18 == 3)
								{
									if (this.inventory[m].pick > 0)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										this.selectedItem = m;
										break;
									}
								}
								else if (num18 == 4)
								{
									if (type2 == 8 || type2 == 427 || type2 == 428 || type2 == 429 || type2 == 430 || type2 == 431 || type2 == 432 || type2 == 433 || type2 == 523 || type2 == 974 || type2 == 1245 || type2 == 1333)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										if (this.inventory[this.selectedItem].createTile != 4)
										{
											this.selectedItem = m;
										}
									}
									else if (type2 == 930)
									{
										bool flag6 = false;
										for (int n = 57; n >= 0; n--)
										{
											if (this.inventory[n].ammo == this.inventory[m].useAmmo)
											{
												flag6 = true;
												break;
											}
										}
										if (flag6)
										{
											if (this.nonTorch == -1)
											{
												this.nonTorch = this.selectedItem;
											}
											this.selectedItem = m;
											break;
										}
									}
									else if (type2 == 282 || type2 == 286 || type2 == 523 || type2 == 1333)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										this.selectedItem = m;
										break;
									}
								}
								else if (num18 == 5)
								{
									if (type2 == 8 || type2 == 427 || type2 == 428 || type2 == 429 || type2 == 430 || type2 == 431 || type2 == 432 || type2 == 433 || type2 == 523 || type2 == 974 || type2 == 1245 || type2 == 1333)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										if (this.inventory[this.selectedItem].createTile != 4)
										{
											this.selectedItem = m;
										}
									}
									else if (type2 == 930)
									{
										bool flag7 = false;
										for (int num24 = 57; num24 >= 0; num24--)
										{
											if (this.inventory[num24].ammo == this.inventory[m].useAmmo)
											{
												flag7 = true;
												break;
											}
										}
										if (flag7)
										{
											if (this.nonTorch == -1)
											{
												this.nonTorch = this.selectedItem;
											}
											this.selectedItem = m;
											break;
										}
									}
									else if (type2 == 282 || type2 == 286)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										this.selectedItem = m;
										break;
									}
								}
								else if (num18 == 6)
								{
									int num25 = 929;
									if (Main.tile[num19, num20].frameX >= 72)
									{
										num25 = 1338;
									}
									if (type2 == num25)
									{
										if (this.nonTorch == -1)
										{
											this.nonTorch = this.selectedItem;
										}
										this.selectedItem = m;
										break;
									}
								}
							}
						}
						else if (this.nonTorch > -1 && this.itemAnimation == 0)
						{
							this.selectedItem = this.nonTorch;
							this.nonTorch = -1;
						}
						if (this.frozen)
						{
							this.controlJump = false;
							this.controlDown = false;
							this.controlLeft = false;
							this.controlRight = false;
							this.controlUp = false;
							this.controlUseItem = false;
							this.controlUseTile = false;
							this.controlThrow = false;
						}
						if (!this.controlThrow)
						{
							this.releaseThrow = true;
						}
						else
						{
							this.releaseThrow = false;
						}
						if (Main.netMode == 1)
						{
							bool flag8 = false;
							if (this.statLife != Main.clientPlayer.statLife || this.statLifeMax != Main.clientPlayer.statLifeMax)
							{
								NetMessage.SendData(16, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
								flag8 = true;
							}
							if (this.statMana != Main.clientPlayer.statMana || this.statManaMax != Main.clientPlayer.statManaMax)
							{
								NetMessage.SendData(42, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
								flag8 = true;
							}
							if (this.controlUp != Main.clientPlayer.controlUp)
							{
								flag8 = true;
							}
							if (this.controlDown != Main.clientPlayer.controlDown)
							{
								flag8 = true;
							}
							if (this.controlLeft != Main.clientPlayer.controlLeft)
							{
								flag8 = true;
							}
							if (this.controlRight != Main.clientPlayer.controlRight)
							{
								flag8 = true;
							}
							if (this.controlJump != Main.clientPlayer.controlJump)
							{
								flag8 = true;
							}
							if (this.controlUseItem != Main.clientPlayer.controlUseItem)
							{
								flag8 = true;
							}
							if (this.selectedItem != Main.clientPlayer.selectedItem)
							{
								flag8 = true;
							}
							if (flag8)
							{
								NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
							}
						}
						if (Main.playerInventory)
						{
							this.AdjTiles();
						}
						if (this.chest != -1)
						{
							int num26 = (int)(((double)this.position.X + (double)this.width * 0.5) / 16.0);
							int num27 = (int)(((double)this.position.Y + (double)this.height * 0.5) / 16.0);
							if (num26 < this.chestX - 5 || num26 > this.chestX + 6 || num27 < this.chestY - 4 || num27 > this.chestY + 5)
							{
								if (this.chest != -1)
								{
									Main.PlaySound(11, -1, -1, 1);
								}
								this.chest = -1;
							}
							if (!Main.tile[this.chestX, this.chestY].active())
							{
								Main.PlaySound(11, -1, -1, 1);
								this.chest = -1;
							}
						}
						if (this.velocity.Y == 0f)
						{
							int num28 = (int)(this.position.Y / 16f) - this.fallStart;
							if (((this.gravDir == 1f && num28 > 25) || (this.gravDir == -1f && num28 < -25)) && !this.noFallDmg && this.wings == 0)
							{
								int damage = (int)((float)num28 * this.gravDir - 25f) * 10;
								this.immune = false;
								this.Hurt(damage, 0, false, false, Lang.deathMsg(-1, -1, -1, 0), false);
							}
							this.fallStart = (int)(this.position.Y / 16f);
						}
						if (this.jump > 0 || this.rocketDelay > 0 || this.wet || this.slowFall || (double)num10 < 0.8 || this.tongued)
						{
							this.fallStart = (int)(this.position.Y / 16f);
						}
					}
					if (this.mouseInterface)
					{
						this.delayUseItem = true;
					}*/
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
					this.onHitDodge = false;
					this.onHitRegen = false;
					this.onHitPetal = false;
					this.iceBarrier = false;
					this.maxMinions = 1;
					this.penguin = false;
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
					if (this.whoAmi == Main.myPlayer)
					{
						Main.musicBox2 = -1;
					}
					for (int num29 = 0; num29 < 86; num29++)
					{
						this.buffImmune[num29] = false;
					}
					for (int num30 = 0; num30 < 10; num30++)
					{
						if (this.buffType[num30] > 0 && this.buffTime[num30] > 0)
						{
							if (this.whoAmi == Main.myPlayer && this.buffType[num30] != 28)
							{
								this.buffTime[num30]--;
							}
							if (this.buffType[num30] == 1)
							{
								this.lavaImmune = true;
								this.fireWalk = true;
							}
							else if (this.buffType[num30] == 2)
							{
								this.lifeRegen += 2;
							}
							else if (this.buffType[num30] == 3)
							{
								this.moveSpeed += 0.25f;
							}
							else if (this.buffType[num30] == 4)
							{
								this.gills = true;
							}
							else if (this.buffType[num30] == 5)
							{
								this.statDefense += 8;
							}
							else if (this.buffType[num30] == 6)
							{
								this.manaRegenBuff = true;
							}
							else if (this.buffType[num30] == 7)
							{
								this.magicDamage += 0.2f;
							}
							else if (this.buffType[num30] == 8)
							{
								this.slowFall = true;
							}
							else if (this.buffType[num30] == 9)
							{
								this.findTreasure = true;
							}
							else if (this.buffType[num30] == 10)
							{
								this.invis = true;
							}
							else if (this.buffType[num30] == 11)
							{
								//Lighting.addLight((int)(this.position.X + (float)(this.width / 2)) / 16, (int)(this.position.Y + (float)(this.height / 2)) / 16, 0.8f, 0.95f, 1f);
							}
							else if (this.buffType[num30] == 12)
							{
								this.nightVision = true;
							}
							else if (this.buffType[num30] == 13)
							{
								this.enemySpawns = true;
							}
							else if (this.buffType[num30] == 14)
							{
								this.thorns = true;
							}
							else if (this.buffType[num30] == 15)
							{
								this.waterWalk = true;
							}
							else if (this.buffType[num30] == 16)
							{
								this.archery = true;
							}
							else if (this.buffType[num30] == 17)
							{
								this.detectCreature = true;
							}
							else if (this.buffType[num30] == 18)
							{
								this.gravControl = true;
							}
							else if (this.buffType[num30] == 30)
							{
								this.bleed = true;
							}
							else if (this.buffType[num30] == 31)
							{
								this.confused = true;
							}
							else if (this.buffType[num30] == 32)
							{
								this.slow = true;
							}
							else if (this.buffType[num30] == 35)
							{
								this.silence = true;
							}
							else if (this.buffType[num30] == 46)
							{
								this.chilled = true;
							}
							else if (this.buffType[num30] == 47)
							{
								this.frozen = true;
							}
							else if (this.buffType[num30] == 69)
							{
								this.ichor = true;
								this.statDefense -= 20;
							}
							else if (this.buffType[num30] == 36)
							{
								this.brokenArmor = true;
							}
							else if (this.buffType[num30] == 48)
							{
								this.honey = true;
							}
							else if (this.buffType[num30] == 59)
							{
								this.shadowDodge = true;
							}
							else if (this.buffType[num30] == 58)
							{
								this.palladiumRegen = true;
							}
							else if (this.buffType[num30] == 63)
							{
								this.moveSpeed += 1f;
							}
							else if (this.buffType[num30] == 62)
							{
								if ((double)this.statLife <= (double)this.statLifeMax * 0.25)
								{
									//Lighting.addLight((int)(this.Center().X / 16f), (int)(this.Center().Y / 16f), 0.1f, 0.2f, 0.45f);
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
									this.DelBuff(num30);
								}
							}
							else if (this.buffType[num30] == 49)
							{
								if (Main.myPlayer == i)
								{
									for (int num31 = 0; num31 < 1000; num31++)
									{
										if (Main.projectile[num31].active && Main.projectile[num31].owner == i && Main.projectile[num31].type >= 191 && Main.projectile[num31].type <= 194)
										{
											this.pygmy = true;
											break;
										}
									}
									if (!this.pygmy)
									{
										this.DelBuff(num30);
									}
									else
									{
										this.buffTime[num30] = 18000;
									}
								}
							}
							else if (this.buffType[num30] == 83)
							{
								if (Main.myPlayer == i)
								{
									for (int num32 = 0; num32 < 1000; num32++)
									{
										if (Main.projectile[num32].active && Main.projectile[num32].owner == i && Main.projectile[num32].type == 317)
										{
											this.raven = true;
											break;
										}
									}
									if (!this.raven)
									{
										this.DelBuff(num30);
									}
									else
									{
										this.buffTime[num30] = 18000;
									}
								}
							}
							else if (this.buffType[num30] == 64)
							{
								if (Main.myPlayer == i)
								{
									for (int num33 = 0; num33 < 1000; num33++)
									{
										if (Main.projectile[num33].active && Main.projectile[num33].owner == i && Main.projectile[num33].type == 266)
										{
											this.slime = true;
											break;
										}
									}
									if (!this.slime)
									{
										this.DelBuff(num30);
									}
									else
									{
										this.buffTime[num30] = 18000;
									}
								}
							}
							else if (this.buffType[num30] == 37)
							{
								if (Main.wof >= 0 && Main.npc[Main.wof].type == 113)
								{
									this.gross = true;
									this.buffTime[num30] = 10;
								}
								else
								{
									this.DelBuff(num30);
								}
							}
							else if (this.buffType[num30] == 38)
							{
								this.buffTime[num30] = 10;
								this.tongued = true;
							}
							else if (this.buffType[num30] == 19)
							{
								this.buffTime[num30] = 18000;
								this.lightOrb = true;
								bool flag9 = true;
								for (int num34 = 0; num34 < 1000; num34++)
								{
									if (Main.projectile[num34].active && Main.projectile[num34].owner == this.whoAmi && Main.projectile[num34].type == 18)
									{
										flag9 = false;
									}
								}
								if (flag9)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 18, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 27)
							{
								this.buffTime[num30] = 18000;
								this.fairy = true;
								bool flag10 = true;
								for (int num35 = 0; num35 < 1000; num35++)
								{
									if (Main.projectile[num35].active && Main.projectile[num35].owner == this.whoAmi && (Main.projectile[num35].type == 72 || Main.projectile[num35].type == 86 || Main.projectile[num35].type == 87))
									{
										flag10 = false;
										break;
									}
								}
								if (flag10)
								{
									int num36 = Main.rand.Next(3);
									if (num36 == 0)
									{
										num36 = 72;
									}
									else if (num36 == 1)
									{
										num36 = 86;
									}
									else if (num36 == 2)
									{
										num36 = 87;
									}
									if (this.head == 45 && this.body == 26 && this.legs == 25)
									{
										num36 = 72;
									}
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, num36, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 40)
							{
								this.buffTime[num30] = 18000;
								this.bunny = true;
								bool flag11 = true;
								for (int num37 = 0; num37 < 1000; num37++)
								{
									if (Main.projectile[num37].active && Main.projectile[num37].owner == this.whoAmi && Main.projectile[num37].type == 111)
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
							else if (this.buffType[num30] == 41)
							{
								this.buffTime[num30] = 18000;
								this.penguin = true;
								bool flag12 = true;
								for (int num38 = 0; num38 < 1000; num38++)
								{
									if (Main.projectile[num38].active && Main.projectile[num38].owner == this.whoAmi && Main.projectile[num38].type == 112)
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
							else if (this.buffType[num30] == 84)
							{
								this.buffTime[num30] = 18000;
								this.blackCat = true;
								bool flag13 = true;
								for (int num39 = 0; num39 < 1000; num39++)
								{
									if (Main.projectile[num39].active && Main.projectile[num39].owner == this.whoAmi && Main.projectile[num39].type == 319)
									{
										flag13 = false;
										break;
									}
								}
								if (flag13)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 319, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 61)
							{
								this.buffTime[num30] = 18000;
								this.dino = true;
								bool flag14 = true;
								for (int num40 = 0; num40 < 1000; num40++)
								{
									if (Main.projectile[num40].active && Main.projectile[num40].owner == this.whoAmi && Main.projectile[num40].type == 236)
									{
										flag14 = false;
										break;
									}
								}
								if (flag14)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 236, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 65)
							{
								this.buffTime[num30] = 18000;
								this.eyeSpring = true;
								bool flag15 = true;
								for (int num41 = 0; num41 < 1000; num41++)
								{
									if (Main.projectile[num41].active && Main.projectile[num41].owner == this.whoAmi && Main.projectile[num41].type == 268)
									{
										flag15 = false;
										break;
									}
								}
								if (flag15)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 268, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 66)
							{
								this.buffTime[num30] = 18000;
								this.snowman = true;
								bool flag16 = true;
								for (int num42 = 0; num42 < 1000; num42++)
								{
									if (Main.projectile[num42].active && Main.projectile[num42].owner == this.whoAmi && Main.projectile[num42].type == 269)
									{
										flag16 = false;
										break;
									}
								}
								if (flag16)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 269, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 42)
							{
								this.buffTime[num30] = 18000;
								this.turtle = true;
								bool flag17 = true;
								for (int num43 = 0; num43 < 1000; num43++)
								{
									if (Main.projectile[num43].active && Main.projectile[num43].owner == this.whoAmi && Main.projectile[num43].type == 127)
									{
										flag17 = false;
										break;
									}
								}
								if (flag17)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 127, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 45)
							{
								this.buffTime[num30] = 18000;
								this.eater = true;
								bool flag18 = true;
								for (int num44 = 0; num44 < 1000; num44++)
								{
									if (Main.projectile[num44].active && Main.projectile[num44].owner == this.whoAmi && Main.projectile[num44].type == 175)
									{
										flag18 = false;
										break;
									}
								}
								if (flag18)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 175, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 50)
							{
								this.buffTime[num30] = 18000;
								this.skeletron = true;
								bool flag19 = true;
								for (int num45 = 0; num45 < 1000; num45++)
								{
									if (Main.projectile[num45].active && Main.projectile[num45].owner == this.whoAmi && Main.projectile[num45].type == 197)
									{
										flag19 = false;
										break;
									}
								}
								if (flag19)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 197, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 51)
							{
								this.buffTime[num30] = 18000;
								this.hornet = true;
								bool flag20 = true;
								for (int num46 = 0; num46 < 1000; num46++)
								{
									if (Main.projectile[num46].active && Main.projectile[num46].owner == this.whoAmi && Main.projectile[num46].type == 198)
									{
										flag20 = false;
										break;
									}
								}
								if (flag20)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 198, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 52)
							{
								this.buffTime[num30] = 18000;
								this.tiki = true;
								bool flag21 = true;
								for (int num47 = 0; num47 < 1000; num47++)
								{
									if (Main.projectile[num47].active && Main.projectile[num47].owner == this.whoAmi && Main.projectile[num47].type == 199)
									{
										flag21 = false;
										break;
									}
								}
								if (flag21)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 199, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 53)
							{
								this.buffTime[num30] = 18000;
								this.lizard = true;
								bool flag22 = true;
								for (int num48 = 0; num48 < 1000; num48++)
								{
									if (Main.projectile[num48].active && Main.projectile[num48].owner == this.whoAmi && Main.projectile[num48].type == 200)
									{
										flag22 = false;
										break;
									}
								}
								if (flag22)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 200, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 54)
							{
								this.buffTime[num30] = 18000;
								this.parrot = true;
								bool flag23 = true;
								for (int num49 = 0; num49 < 1000; num49++)
								{
									if (Main.projectile[num49].active && Main.projectile[num49].owner == this.whoAmi && Main.projectile[num49].type == 208)
									{
										flag23 = false;
										break;
									}
								}
								if (flag23)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 208, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 55)
							{
								this.buffTime[num30] = 18000;
								this.truffle = true;
								bool flag24 = true;
								for (int num50 = 0; num50 < 1000; num50++)
								{
									if (Main.projectile[num50].active && Main.projectile[num50].owner == this.whoAmi && Main.projectile[num50].type == 209)
									{
										flag24 = false;
										break;
									}
								}
								if (flag24)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 209, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 56)
							{
								this.buffTime[num30] = 18000;
								this.sapling = true;
								bool flag25 = true;
								for (int num51 = 0; num51 < 1000; num51++)
								{
									if (Main.projectile[num51].active && Main.projectile[num51].owner == this.whoAmi && Main.projectile[num51].type == 210)
									{
										flag25 = false;
										break;
									}
								}
								if (flag25)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 210, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 85)
							{
								this.buffTime[num30] = 18000;
								this.cSapling = true;
								bool flag26 = true;
								for (int num52 = 0; num52 < 1000; num52++)
								{
									if (Main.projectile[num52].active && Main.projectile[num52].owner == this.whoAmi && Main.projectile[num52].type == 324)
									{
										flag26 = false;
										break;
									}
								}
								if (flag26)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 324, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 81)
							{
								this.buffTime[num30] = 18000;
								this.spider = true;
								bool flag27 = true;
								for (int num53 = 0; num53 < 1000; num53++)
								{
									if (Main.projectile[num53].active && Main.projectile[num53].owner == this.whoAmi && Main.projectile[num53].type == 313)
									{
										flag27 = false;
										break;
									}
								}
								if (flag27)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 313, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 82)
							{
								this.buffTime[num30] = 18000;
								this.squashling = true;
								bool flag28 = true;
								for (int num54 = 0; num54 < 1000; num54++)
								{
									if (Main.projectile[num54].active && Main.projectile[num54].owner == this.whoAmi && Main.projectile[num54].type == 314)
									{
										flag28 = false;
										break;
									}
								}
								if (flag28)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 314, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 57)
							{
								this.buffTime[num30] = 18000;
								this.wisp = true;
								bool flag29 = true;
								for (int num55 = 0; num55 < 1000; num55++)
								{
									if (Main.projectile[num55].active && Main.projectile[num55].owner == this.whoAmi && Main.projectile[num55].type == 211)
									{
										flag29 = false;
										break;
									}
								}
								if (flag29)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 211, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 60)
							{
								this.buffTime[num30] = 18000;
								this.crystalLeaf = true;
								bool flag30 = true;
								for (int num56 = 0; num56 < 1000; num56++)
								{
									if (Main.projectile[num56].active && Main.projectile[num56].owner == this.whoAmi && Main.projectile[num56].type == 226)
									{
										if (!flag30)
										{
											Main.projectile[num56].Kill();
										}
										flag30 = false;
									}
								}
								if (flag30)
								{
									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 226, 0, 0f, this.whoAmi, 0f, 0f);
								}
							}
							else if (this.buffType[num30] == 70)
							{
								this.venom = true;
							}
							else if (this.buffType[num30] == 20)
							{
								this.poisoned = true;
							}
							else if (this.buffType[num30] == 21)
							{
								this.potionDelay = this.buffTime[num30];
							}
							else if (this.buffType[num30] == 22)
							{
								this.blind = true;
							}
							else if (this.buffType[num30] == 80)
							{
								this.blackout = true;
							}
							else if (this.buffType[num30] == 23)
							{
								this.noItems = true;
							}
							else if (this.buffType[num30] == 24)
							{
								this.onFire = true;
							}
							else if (this.buffType[num30] == 67)
							{
								this.burned = true;
							}
							else if (this.buffType[num30] == 68)
							{
								this.suffocating = true;
							}
							else if (this.buffType[num30] == 39)
							{
								this.onFire2 = true;
							}
							else if (this.buffType[num30] == 44)
							{
								this.onFrostBurn = true;
							}
							else if (this.buffType[num30] == 43)
							{
								this.paladinBuff = true;
							}
							else if (this.buffType[num30] == 29)
							{
								this.magicCrit += 2;
								this.magicDamage += 0.05f;
								this.statManaMax2 += 20;
								this.manaCost -= 0.02f;
							}
							else if (this.buffType[num30] == 28)
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
									this.DelBuff(num30);
								}
							}
							else if (this.buffType[num30] == 33)
							{
								this.meleeDamage -= 0.051f;
								this.meleeSpeed -= 0.051f;
								this.statDefense -= 4;
								this.moveSpeed -= 0.1f;
							}
							else if (this.buffType[num30] == 25)
							{
								this.statDefense -= 4;
								this.meleeCrit += 2;
								this.meleeDamage += 0.1f;
								this.meleeSpeed += 0.1f;
							}
							else if (this.buffType[num30] == 26)
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
							else if (this.buffType[num30] == 71)
							{
								this.meleeEnchant = 1;
							}
							else if (this.buffType[num30] == 73)
							{
								this.meleeEnchant = 2;
							}
							else if (this.buffType[num30] == 74)
							{
								this.meleeEnchant = 3;
							}
							else if (this.buffType[num30] == 75)
							{
								this.meleeEnchant = 4;
							}
							else if (this.buffType[num30] == 76)
							{
								this.meleeEnchant = 5;
							}
							else if (this.buffType[num30] == 77)
							{
								this.meleeEnchant = 6;
							}
							else if (this.buffType[num30] == 78)
							{
								this.meleeEnchant = 7;
							}
							else if (this.buffType[num30] == 79)
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
						for (int num57 = 0; num57 < 10; num57++)
						{
							if (this.buffType[num57] > 0 && this.buffTime[num57] <= 0)
							{
								this.DelBuff(num57);
							}
						}
					}
					this.doubleJump = false;
					for (int num58 = 0; num58 < 8; num58++)
					{
						this.statDefense += this.armor[num58].defense;
						this.lifeRegen += this.armor[num58].lifeRegen;
						if (this.armor[num58].type == 268)
						{
							this.accDivingHelm = true;
						}
						if (this.armor[num58].type == 238)
						{
							this.magicDamage += 0.15f;
						}
						if (this.armor[num58].type == 123 || this.armor[num58].type == 124 || this.armor[num58].type == 125)
						{
							this.magicDamage += 0.07f;
						}
						if (this.armor[num58].type == 151 || this.armor[num58].type == 152 || this.armor[num58].type == 153 || this.armor[num58].type == 959)
						{
							this.rangedDamage += 0.05f;
						}
						if (this.armor[num58].type == 111 || this.armor[num58].type == 228 || this.armor[num58].type == 229 || this.armor[num58].type == 230 || this.armor[num58].type == 960 || this.armor[num58].type == 961 || this.armor[num58].type == 962)
						{
							this.statManaMax2 += 20;
						}
						if (this.armor[num58].type == 982)
						{
							this.statManaMax2 += 20;
							this.manaRegenDelayBonus++;
							this.manaRegenBonus += 25;
						}
						if (this.armor[num58].type == 1595)
						{
							this.statManaMax2 += 20;
							this.magicCuffs = true;
						}
						if (this.armor[num58].type == 228 || this.armor[num58].type == 229 || this.armor[num58].type == 230)
						{
							this.magicCrit += 3;
						}
						if (this.armor[num58].type == 100 || this.armor[num58].type == 101 || this.armor[num58].type == 102)
						{
							this.meleeSpeed += 0.07f;
						}
						if (this.armor[num58].type == 956 || this.armor[num58].type == 957 || this.armor[num58].type == 958)
						{
							this.meleeSpeed += 0.07f;
						}
						if (this.armor[num58].type == 791 || this.armor[num58].type == 792 || this.armor[num58].type == 793)
						{
							this.meleeDamage += 0.02f;
							this.rangedDamage += 0.02f;
							this.magicDamage += 0.02f;
						}
						if (this.armor[num58].type == 371)
						{
							this.magicCrit += 9;
							this.statManaMax2 += 40;
						}
						if (this.armor[num58].type == 372)
						{
							this.moveSpeed += 0.07f;
							this.meleeSpeed += 0.12f;
						}
						if (this.armor[num58].type == 373)
						{
							this.rangedDamage += 0.1f;
							this.rangedCrit += 6;
						}
						if (this.armor[num58].type == 374)
						{
							this.magicCrit += 3;
							this.meleeCrit += 3;
							this.rangedCrit += 3;
						}
						if (this.armor[num58].type == 375)
						{
							this.moveSpeed += 0.1f;
						}
						if (this.armor[num58].type == 376)
						{
							this.magicDamage += 0.15f;
							this.statManaMax2 += 60;
						}
						if (this.armor[num58].type == 377)
						{
							this.meleeCrit += 5;
							this.meleeDamage += 0.1f;
						}
						if (this.armor[num58].type == 378)
						{
							this.rangedDamage += 0.12f;
							this.rangedCrit += 7;
						}
						if (this.armor[num58].type == 379)
						{
							this.rangedDamage += 0.05f;
							this.meleeDamage += 0.05f;
							this.magicDamage += 0.05f;
						}
						if (this.armor[num58].type == 380)
						{
							this.magicCrit += 3;
							this.meleeCrit += 3;
							this.rangedCrit += 3;
						}
						if (this.armor[num58].type == 400)
						{
							this.magicDamage += 0.11f;
							this.magicCrit += 11;
							this.statManaMax2 += 80;
						}
						if (this.armor[num58].type == 401)
						{
							this.meleeCrit += 7;
							this.meleeDamage += 0.14f;
						}
						if (this.armor[num58].type == 402)
						{
							this.rangedDamage += 0.14f;
							this.rangedCrit += 8;
						}
						if (this.armor[num58].type == 403)
						{
							this.rangedDamage += 0.06f;
							this.meleeDamage += 0.06f;
							this.magicDamage += 0.06f;
						}
						if (this.armor[num58].type == 404)
						{
							this.magicCrit += 4;
							this.meleeCrit += 4;
							this.rangedCrit += 4;
							this.moveSpeed += 0.05f;
						}
						if (this.armor[num58].type == 1205)
						{
							this.meleeDamage += 0.08f;
							this.meleeSpeed += 0.12f;
						}
						if (this.armor[num58].type == 1206)
						{
							this.rangedDamage += 0.09f;
							this.rangedCrit += 9;
						}
						if (this.armor[num58].type == 1207)
						{
							this.magicDamage += 0.07f;
							this.magicCrit += 7;
							this.statManaMax2 += 60;
						}
						if (this.armor[num58].type == 1208)
						{
							this.meleeDamage += 0.03f;
							this.rangedDamage += 0.03f;
							this.magicDamage += 0.03f;
							this.magicCrit += 2;
							this.meleeCrit += 2;
							this.rangedCrit += 2;
						}
						if (this.armor[num58].type == 1209)
						{
							this.meleeDamage += 0.02f;
							this.rangedDamage += 0.02f;
							this.magicDamage += 0.02f;
							this.magicCrit++;
							this.meleeCrit++;
							this.rangedCrit++;
						}
						if (this.armor[num58].type == 1210)
						{
							this.meleeDamage += 0.07f;
							this.meleeSpeed += 0.07f;
							this.moveSpeed += 0.07f;
						}
						if (this.armor[num58].type == 1211)
						{
							this.rangedCrit += 15;
							this.moveSpeed += 0.08f;
						}
						if (this.armor[num58].type == 1212)
						{
							this.magicCrit += 18;
							this.statManaMax2 += 80;
						}
						if (this.armor[num58].type == 1213)
						{
							this.magicCrit += 6;
							this.meleeCrit += 6;
							this.rangedCrit += 6;
						}
						if (this.armor[num58].type == 1214)
						{
							this.moveSpeed += 0.11f;
						}
						if (this.armor[num58].type == 1215)
						{
							this.meleeDamage += 0.08f;
							this.meleeCrit += 8;
							this.meleeSpeed += 0.08f;
						}
						if (this.armor[num58].type == 1216)
						{
							this.rangedDamage += 0.16f;
							this.rangedCrit += 7;
						}
						if (this.armor[num58].type == 1217)
						{
							this.magicDamage += 0.16f;
							this.magicCrit += 7;
							this.statManaMax2 += 100;
						}
						if (this.armor[num58].type == 1218)
						{
							this.meleeDamage += 0.04f;
							this.rangedDamage += 0.04f;
							this.magicDamage += 0.04f;
							this.magicCrit += 3;
							this.meleeCrit += 3;
							this.rangedCrit += 3;
						}
						if (this.armor[num58].type == 1219)
						{
							this.meleeDamage += 0.03f;
							this.rangedDamage += 0.03f;
							this.magicDamage += 0.03f;
							this.magicCrit += 3;
							this.meleeCrit += 3;
							this.rangedCrit += 3;
							this.moveSpeed += 0.06f;
						}
						if (this.armor[num58].type == 558)
						{
							this.magicDamage += 0.12f;
							this.magicCrit += 12;
							this.statManaMax2 += 100;
						}
						if (this.armor[num58].type == 559)
						{
							this.meleeCrit += 10;
							this.meleeDamage += 0.1f;
							this.meleeSpeed += 0.1f;
						}
						if (this.armor[num58].type == 553)
						{
							this.rangedDamage += 0.15f;
							this.rangedCrit += 8;
						}
						if (this.armor[num58].type == 551)
						{
							this.magicCrit += 7;
							this.meleeCrit += 7;
							this.rangedCrit += 7;
						}
						if (this.armor[num58].type == 552)
						{
							this.rangedDamage += 0.07f;
							this.meleeDamage += 0.07f;
							this.magicDamage += 0.07f;
							this.moveSpeed += 0.08f;
						}
						if (this.armor[num58].type == 1001)
						{
							this.meleeDamage += 0.16f;
							this.meleeCrit += 6;
						}
						if (this.armor[num58].type == 1002)
						{
							this.rangedDamage += 0.16f;
							this.ammoCost80 = true;
						}
						if (this.armor[num58].type == 1003)
						{
							this.statManaMax2 += 80;
							this.manaCost -= 0.17f;
							this.magicDamage += 0.16f;
						}
						if (this.armor[num58].type == 1004)
						{
							this.meleeDamage += 0.05f;
							this.magicDamage += 0.05f;
							this.rangedDamage += 0.05f;
							this.magicCrit += 7;
							this.meleeCrit += 7;
							this.rangedCrit += 7;
						}
						if (this.armor[num58].type == 1005)
						{
							this.magicCrit += 8;
							this.meleeCrit += 8;
							this.rangedCrit += 8;
							this.moveSpeed += 0.05f;
						}
						if (this.armor[num58].type == 1503)
						{
							this.statManaMax2 += 80;
							this.manaCost -= 0.17f;
							this.magicDamage += 0.1f;
							this.magicCrit += 10;
						}
						if (this.armor[num58].type == 1504)
						{
							this.magicDamage += 0.07f;
							this.magicCrit += 7;
						}
						if (this.armor[num58].type == 1505)
						{
							this.magicDamage += 0.08f;
							this.moveSpeed += 0.08f;
						}
						if (this.armor[num58].type == 1546)
						{
							this.rangedCrit += 5;
							this.arrowDamage += 0.15f;
						}
						if (this.armor[num58].type == 1547)
						{
							this.rangedCrit += 5;
							this.bulletDamage += 0.15f;
						}
						if (this.armor[num58].type == 1548)
						{
							this.rangedCrit += 5;
							this.rocketDamage += 0.15f;
						}
						if (this.armor[num58].type == 1549)
						{
							this.rangedCrit += 13;
							this.rangedDamage += 0.13f;
							this.ammoCost80 = true;
						}
						if (this.armor[num58].type == 1550)
						{
							this.rangedCrit += 7;
							this.moveSpeed += 0.12f;
						}
						if (this.armor[num58].type == 1282)
						{
							this.statManaMax2 += 20;
							this.manaCost -= 0.05f;
						}
						if (this.armor[num58].type == 1283)
						{
							this.statManaMax2 += 40;
							this.manaCost -= 0.07f;
						}
						if (this.armor[num58].type == 1284)
						{
							this.statManaMax2 += 40;
							this.manaCost -= 0.09f;
						}
						if (this.armor[num58].type == 1285)
						{
							this.statManaMax2 += 60;
							this.manaCost -= 0.11f;
						}
						if (this.armor[num58].type == 1286)
						{
							this.statManaMax2 += 60;
							this.manaCost -= 0.13f;
						}
						if (this.armor[num58].type == 1287)
						{
							this.statManaMax2 += 80;
							this.manaCost -= 0.15f;
						}
						if (this.armor[num58].type == 1316 || this.armor[num58].type == 1317 || this.armor[num58].type == 1318)
						{
							this.aggro += 200;
						}
						if (this.armor[num58].type == 1316)
						{
							this.meleeDamage += 0.06f;
						}
						if (this.armor[num58].type == 1317)
						{
							this.meleeDamage += 0.08f;
							this.meleeCrit += 8;
						}
						if (this.armor[num58].type == 1318)
						{
							this.meleeCrit += 4;
						}
						if (this.armor[num58].type == 684)
						{
							this.rangedDamage += 0.16f;
							this.meleeDamage += 0.16f;
						}
						if (this.armor[num58].type == 685)
						{
							this.meleeCrit += 11;
							this.rangedCrit += 11;
						}
						if (this.armor[num58].type == 686)
						{
							this.moveSpeed += 0.08f;
							this.meleeSpeed += 0.07f;
						}
						if (this.armor[num58].type >= 1158 && this.armor[num58].type <= 1161)
						{
							this.maxMinions++;
						}
						if (this.armor[num58].type >= 1159 && this.armor[num58].type <= 1161)
						{
							this.minionDamage += 0.1f;
						}
						if (this.armor[num58].type >= 1832 && this.armor[num58].type <= 1834)
						{
							this.maxMinions++;
						}
						if (this.armor[num58].type >= 1832 && this.armor[num58].type <= 1834)
						{
							this.minionDamage += 0.11f;
						}
						if (this.armor[num58].prefix == 62)
						{
							this.statDefense++;
						}
						if (this.armor[num58].prefix == 63)
						{
							this.statDefense += 2;
						}
						if (this.armor[num58].prefix == 64)
						{
							this.statDefense += 3;
						}
						if (this.armor[num58].prefix == 65)
						{
							this.statDefense += 4;
						}
						if (this.armor[num58].prefix == 66)
						{
							this.statManaMax2 += 20;
						}
						if (this.armor[num58].prefix == 67)
						{
							this.meleeCrit++;
							this.rangedCrit++;
							this.magicCrit++;
						}
						if (this.armor[num58].prefix == 68)
						{
							this.meleeCrit += 2;
							this.rangedCrit += 2;
							this.magicCrit += 2;
						}
						if (this.armor[num58].prefix == 69)
						{
							this.meleeDamage += 0.01f;
							this.rangedDamage += 0.01f;
							this.magicDamage += 0.01f;
							this.minionDamage += 0.01f;
						}
						if (this.armor[num58].prefix == 70)
						{
							this.meleeDamage += 0.02f;
							this.rangedDamage += 0.02f;
							this.magicDamage += 0.02f;
							this.minionDamage += 0.02f;
						}
						if (this.armor[num58].prefix == 71)
						{
							this.meleeDamage += 0.03f;
							this.rangedDamage += 0.03f;
							this.magicDamage += 0.03f;
							this.minionDamage += 0.03f;
						}
						if (this.armor[num58].prefix == 72)
						{
							this.meleeDamage += 0.04f;
							this.rangedDamage += 0.04f;
							this.magicDamage += 0.04f;
							this.minionDamage += 0.04f;
						}
						if (this.armor[num58].prefix == 73)
						{
							this.moveSpeed += 0.01f;
						}
						if (this.armor[num58].prefix == 74)
						{
							this.moveSpeed += 0.02f;
						}
						if (this.armor[num58].prefix == 75)
						{
							this.moveSpeed += 0.03f;
						}
						if (this.armor[num58].prefix == 76)
						{
							this.moveSpeed += 0.04f;
						}
						if (this.armor[num58].prefix == 77)
						{
							this.meleeSpeed += 0.01f;
						}
						if (this.armor[num58].prefix == 78)
						{
							this.meleeSpeed += 0.02f;
						}
						if (this.armor[num58].prefix == 79)
						{
							this.meleeSpeed += 0.03f;
						}
						if (this.armor[num58].prefix == 80)
						{
							this.meleeSpeed += 0.04f;
						}
					}
					this.head = this.armor[0].headSlot;
					this.body = this.armor[1].bodySlot;
					this.legs = this.armor[2].legSlot;
					for (int num59 = 3; num59 < 8; num59++)
					{
						if (this.armor[num59].type == 15 && this.accWatch < 1)
						{
							this.accWatch = 1;
						}
						if (this.armor[num59].type == 16 && this.accWatch < 2)
						{
							this.accWatch = 2;
						}
						if (this.armor[num59].type == 17 && this.accWatch < 3)
						{
							this.accWatch = 3;
						}
						if (this.armor[num59].type == 707 && this.accWatch < 1)
						{
							this.accWatch = 1;
						}
						if (this.armor[num59].type == 708 && this.accWatch < 2)
						{
							this.accWatch = 2;
						}
						if (this.armor[num59].type == 709 && this.accWatch < 3)
						{
							this.accWatch = 3;
						}
						if (this.armor[num59].type == 18 && this.accDepthMeter < 1)
						{
							this.accDepthMeter = 1;
						}
						if (this.armor[num59].type == 857)
						{
							this.doubleJump2 = true;
						}
						if (this.armor[num59].type == 983)
						{
							this.doubleJump2 = true;
							this.jumpBoost = true;
						}
						if (this.armor[num59].type == 987)
						{
							this.doubleJump3 = true;
						}
						if (this.armor[num59].type == 1163)
						{
							this.doubleJump3 = true;
							this.jumpBoost = true;
						}
						if (this.armor[num59].type == 1724)
						{
							this.doubleJump4 = true;
						}
						if (this.armor[num59].type == 1164)
						{
							this.doubleJump = true;
							this.doubleJump2 = true;
							this.doubleJump3 = true;
							this.jumpBoost = true;
						}
						if (this.armor[num59].type == 1250)
						{
							this.jumpBoost = true;
							this.doubleJump = true;
							this.noFallDmg = true;
						}
						if (this.armor[num59].type == 1252)
						{
							this.doubleJump2 = true;
							this.jumpBoost = true;
							this.noFallDmg = true;
						}
						if (this.armor[num59].type == 1251)
						{
							this.doubleJump3 = true;
							this.jumpBoost = true;
							this.noFallDmg = true;
						}
						if (this.armor[num59].type == 1249)
						{
							this.jumpBoost = true;
							this.bee = true;
						}
						if (this.armor[num59].type == 1253 && (double)this.statLife <= (double)this.statLifeMax * 0.25)
						{
							this.AddBuff(62, 5, true);
						}
						if (this.armor[num59].type == 1290)
						{
							this.panic = true;
						}
						if (this.armor[num59].type == 1300 && this.inventory[this.selectedItem].useAmmo == 14)
						{
							this.scope = true;
						}
						if (this.armor[num59].type == 1303 && this.wet)
						{
							//Lighting.addLight((int)this.center().X / 16, (int)this.center().Y / 16, 0.9f, 0.2f, 0.6f);
						}
						if (this.armor[num59].type == 1301)
						{
							this.meleeCrit += 8;
							this.rangedCrit += 8;
							this.magicCrit += 8;
							this.meleeDamage += 0.1f;
							this.rangedDamage += 0.1f;
							this.magicDamage += 0.1f;
							this.minionDamage += 0.1f;
						}
						if (this.armor[num59].type == 1247)
						{
							this.starCloak = true;
							this.bee = true;
						}
						if (this.armor[num59].type == 1248)
						{
							this.meleeCrit += 10;
							this.rangedCrit += 10;
							this.magicCrit += 10;
						}
						if (this.armor[num59].type == 854)
						{
							this.discount = true;
						}
						if (this.armor[num59].type == 855)
						{
							this.coins = true;
						}
						if (this.armor[num59].type == 53)
						{
							this.doubleJump = true;
						}
						if (this.armor[num59].type == 54)
						{
							num6 = 6f;
						}
						if (this.armor[num59].type == 1579)
						{
							num6 = 6f;
							this.coldDash = true;
						}
						if (this.armor[num59].type == 128)
						{
							this.rocketBoots = 1;
						}
						if (this.armor[num59].type == 156)
						{
							this.noKnockback = true;
						}
						if (this.armor[num59].type == 158)
						{
							this.noFallDmg = true;
						}
						if (this.armor[num59].type == 934)
						{
							this.carpet = true;
						}
						if (this.armor[num59].type == 953)
						{
							this.spikedBoots++;
						}
						if (this.armor[num59].type == 975)
						{
							this.spikedBoots++;
						}
						if (this.armor[num59].type == 976)
						{
							this.spikedBoots += 2;
						}
						if (this.armor[num59].type == 977)
						{
							this.dash = 1;
						}
						if (this.armor[num59].type == 963)
						{
							this.blackBelt = true;
						}
						if (this.armor[num59].type == 984)
						{
							this.blackBelt = true;
							this.dash = 1;
							this.spikedBoots = 2;
						}
						if (this.armor[num59].type == 1131)
						{
							this.gravControl2 = true;
						}
						if (this.armor[num59].type == 1132)
						{
							this.bee = true;
						}
						if (this.armor[num59].type == 1578)
						{
							this.bee = true;
							this.panic = true;
						}
						if (this.armor[num59].type == 950)
						{
							this.iceSkate = true;
						}
						if (this.armor[num59].type == 159)
						{
							this.jumpBoost = true;
						}
						if (this.armor[num59].type == 187)
						{
							this.accFlipper = true;
						}
						if (this.armor[num59].type == 211)
						{
							this.meleeSpeed += 0.12f;
						}
						if (this.armor[num59].type == 223)
						{
							this.manaCost -= 0.06f;
						}
						if (this.armor[num59].type == 285)
						{
							this.moveSpeed += 0.05f;
						}
						if (this.armor[num59].type == 212)
						{
							this.moveSpeed += 0.1f;
						}
						if (this.armor[num59].type == 267)
						{
							this.killGuide = true;
						}
						if (this.armor[num59].type == 1307)
						{
							this.killClothier = true;
						}
						if (this.armor[num59].type == 193)
						{
							this.fireWalk = true;
						}
						if (this.armor[num59].type == 861)
						{
							this.accMerman = true;
							this.wolfAcc = true;
						}
						if (this.armor[num59].type == 862)
						{
							this.starCloak = true;
							this.longInvince = true;
						}
						if (this.armor[num59].type == 860)
						{
							this.pStone = true;
						}
						if (this.armor[num59].type == 863)
						{
							this.waterWalk2 = true;
						}
						if (this.armor[num59].type == 907)
						{
							this.waterWalk2 = true;
							this.fireWalk = true;
						}
						if (this.armor[num59].type == 908)
						{
							this.waterWalk = true;
							this.fireWalk = true;
							this.lavaMax += 420;
						}
						if (this.armor[num59].type == 906)
						{
							this.lavaMax += 420;
						}
						if (this.armor[num59].type == 485)
						{
							this.wolfAcc = true;
						}
						if (this.armor[num59].type == 486)
						{
							this.rulerAcc = true;
						}
						if (this.armor[num59].type == 393)
						{
							this.accCompass = 1;
						}
						if (this.armor[num59].type == 394)
						{
							this.accFlipper = true;
							this.accDivingHelm = true;
						}
						if (this.armor[num59].type == 395)
						{
							this.accWatch = 3;
							this.accDepthMeter = 1;
							this.accCompass = 1;
						}
						if (this.armor[num59].type == 396)
						{
							this.noFallDmg = true;
							this.fireWalk = true;
						}
						if (this.armor[num59].type == 397)
						{
							this.noKnockback = true;
							this.fireWalk = true;
						}
						if (this.armor[num59].type == 399)
						{
							this.jumpBoost = true;
							this.doubleJump = true;
						}
						if (this.armor[num59].type == 405)
						{
							num6 = 6f;
							this.rocketBoots = 2;
						}
						if (this.armor[num59].type == 897)
						{
							this.kbGlove = true;
							this.meleeSpeed += 0.12f;
						}
						if (this.armor[num59].type == 1343)
						{
							this.kbGlove = true;
							this.meleeSpeed += 0.09f;
							this.meleeDamage += 0.09f;
							this.magmaStone = true;
						}
						if (this.armor[num59].type == 1167)
						{
							this.minionKB += 2f;
							this.minionDamage += 0.15f;
						}
						if (this.armor[num59].type == 1845)
						{
							this.minionDamage += 0.1f;
							this.maxMinions++;
						}
						if (this.armor[num59].type == 1321)
						{
							this.magicQuiver = true;
							this.arrowDamage += 0.1f;
						}
						if (this.armor[num59].type == 1322)
						{
							this.magmaStone = true;
						}
						if (this.armor[num59].type == 1323)
						{
							this.lavaRose = true;
						}
						if (this.armor[num59].type == 938)
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
										float num60 = this.position.X - Main.player[myPlayer].position.X;
										float num61 = this.position.Y - Main.player[myPlayer].position.Y;
										float num62 = (float)Math.Sqrt((double)(num60 * num60 + num61 * num61));
										if (num62 < 800f)
										{
											Main.player[myPlayer].AddBuff(43, 10, true);
										}
									}
								}
							}
						}
						if (this.armor[num59].type == 936)
						{
							this.kbGlove = true;
							this.meleeSpeed += 0.12f;
							this.magicDamage += 0.12f;
							this.meleeDamage += 0.12f;
							this.rangedDamage += 0.12f;
						}
						if (this.armor[num59].type == 898)
						{
							num6 = 6.75f;
							this.rocketBoots = 2;
							this.moveSpeed += 0.08f;
						}
						if (this.armor[num59].type == 899 && Main.dayTime)
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
						if (this.armor[num59].type == 900 && !Main.dayTime)
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
						if (this.armor[num59].type == 407)
						{
							this.blockRange = 1;
						}
						if (this.armor[num59].type == 489)
						{
							this.magicDamage += 0.15f;
						}
						if (this.armor[num59].type == 490)
						{
							this.meleeDamage += 0.15f;
						}
						if (this.armor[num59].type == 491)
						{
							this.rangedDamage += 0.15f;
						}
						if (this.armor[num59].type == 935)
						{
							this.magicDamage += 0.12f;
							this.meleeDamage += 0.12f;
							this.rangedDamage += 0.12f;
							this.minionDamage += 0.12f;
						}
						if (this.armor[num59].type == 492)
						{
							this.wings = 1;
						}
						if (this.armor[num59].type == 493)
						{
							this.wings = 2;
						}
						if (this.armor[num59].type == 665)
						{
							this.wings = 3;
						}
						if (this.armor[num59].type == 748)
						{
							this.wings = 4;
						}
						if (this.armor[num59].type == 749)
						{
							this.wings = 5;
						}
						if (this.armor[num59].type == 761)
						{
							this.wings = 6;
						}
						if (this.armor[num59].type == 785)
						{
							this.wings = 7;
						}
						if (this.armor[num59].type == 786)
						{
							this.wings = 8;
						}
						if (this.armor[num59].type == 821)
						{
							this.wings = 9;
						}
						if (this.armor[num59].type == 822)
						{
							this.wings = 10;
						}
						if (this.armor[num59].type == 823)
						{
							this.wings = 11;
						}
						if (this.armor[num59].type == 948)
						{
							this.wings = 12;
						}
						if (this.armor[num59].type == 1162)
						{
							this.wings = 13;
						}
						if (this.armor[num59].type == 1165)
						{
							this.wings = 14;
						}
						if (this.armor[num59].type == 1515)
						{
							this.wings = 15;
						}
						if (this.armor[num59].type == 1583)
						{
							this.wings = 16;
						}
						if (this.armor[num59].type == 1584)
						{
							this.wings = 17;
						}
						if (this.armor[num59].type == 1585)
						{
							this.wings = 18;
						}
						if (this.armor[num59].type == 1586)
						{
							this.wings = 19;
						}
						if (this.armor[num59].type == 1797)
						{
							this.wings = 20;
						}
						if (this.armor[num59].type == 1830)
						{
							this.wings = 21;
						}
						if (this.armor[num59].type == 885)
						{
							this.buffImmune[30] = true;
						}
						if (this.armor[num59].type == 886)
						{
							this.buffImmune[36] = true;
						}
						if (this.armor[num59].type == 887)
						{
							this.buffImmune[20] = true;
						}
						if (this.armor[num59].type == 888)
						{
							this.buffImmune[22] = true;
						}
						if (this.armor[num59].type == 889)
						{
							this.buffImmune[32] = true;
						}
						if (this.armor[num59].type == 890)
						{
							this.buffImmune[35] = true;
						}
						if (this.armor[num59].type == 891)
						{
							this.buffImmune[23] = true;
						}
						if (this.armor[num59].type == 892)
						{
							this.buffImmune[33] = true;
						}
						if (this.armor[num59].type == 893)
						{
							this.buffImmune[31] = true;
						}
						if (this.armor[num59].type == 901)
						{
							this.buffImmune[33] = true;
							this.buffImmune[36] = true;
						}
						if (this.armor[num59].type == 902)
						{
							this.buffImmune[30] = true;
							this.buffImmune[20] = true;
						}
						if (this.armor[num59].type == 903)
						{
							this.buffImmune[32] = true;
							this.buffImmune[31] = true;
						}
						if (this.armor[num59].type == 904)
						{
							this.buffImmune[35] = true;
							this.buffImmune[23] = true;
						}
						if (this.armor[num59].type == 1612)
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
						if (this.armor[num59].type == 1613)
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
						if (this.armor[num59].type == 497)
						{
							this.accMerman = true;
						}
						if (this.armor[num59].type == 535)
						{
							this.pStone = true;
						}
						if (this.armor[num59].type == 536)
						{
							this.kbGlove = true;
						}
						if (this.armor[num59].type == 532)
						{
							this.starCloak = true;
						}
						if (this.armor[num59].type == 554)
						{
							this.longInvince = true;
						}
						if (this.armor[num59].type == 555)
						{
							this.manaFlower = true;
							this.manaCost -= 0.08f;
						}
						if (Main.myPlayer == this.whoAmi)
						{
							if (this.armor[num59].type == 576 && Main.rand.Next(18000) == 0 && Main.curMusic > 0)
							{
								int num63 = 0;
								if (Main.curMusic == 1)
								{
									num63 = 0;
								}
								if (Main.curMusic == 2)
								{
									num63 = 1;
								}
								if (Main.curMusic == 3)
								{
									num63 = 2;
								}
								if (Main.curMusic == 4)
								{
									num63 = 4;
								}
								if (Main.curMusic == 5)
								{
									num63 = 5;
								}
								if (Main.curMusic == 7)
								{
									num63 = 6;
								}
								if (Main.curMusic == 8)
								{
									num63 = 7;
								}
								if (Main.curMusic == 9)
								{
									num63 = 9;
								}
								if (Main.curMusic == 10)
								{
									num63 = 8;
								}
								if (Main.curMusic == 11)
								{
									num63 = 11;
								}
								if (Main.curMusic == 12)
								{
									num63 = 10;
								}
								if (Main.curMusic == 13)
								{
									num63 = 12;
								}
								if (Main.curMusic == 29)
								{
									this.armor[num59].SetDefaults(1610, false);
								}
								else if (Main.curMusic > 13)
								{
									this.armor[num59].SetDefaults(1596 + Main.curMusic - 14, false);
								}
								else
								{
									this.armor[num59].SetDefaults(num63 + 562, false);
								}
							}
							if (this.armor[num59].type >= 562 && this.armor[num59].type <= 574)
							{
								Main.musicBox2 = this.armor[num59].type - 562;
							}
							if (this.armor[num59].type >= 1596 && this.armor[num59].type <= 1609)
							{
								Main.musicBox2 = this.armor[num59].type - 1596 + 13;
							}
							if (this.armor[num59].type == 1610)
							{
								Main.musicBox2 = 27;
							}
						}
					}
					this.gemCount++;
					if (this.gemCount >= 10)
					{
						this.gem = -1;
						this.gemCount = 0;
						for (int num64 = 0; num64 <= 58; num64++)
						{
							if (this.inventory[num64].type == 0 || this.inventory[num64].stack == 0)
							{
								this.inventory[num64].type = 0;
								this.inventory[num64].stack = 0;
								this.inventory[num64].name = "";
								this.inventory[num64].netID = 0;
							}
							if (this.inventory[num64].type >= 1522 && this.inventory[num64].type <= 1527)
							{
								this.gem = this.inventory[num64].type - 1522;
							}
						}
					}
					if (this.head == 11)
					{
						int i2 = (int)(this.position.X + (float)(this.width / 2) + (float)(8 * this.direction)) / 16;
						int j2 = (int)(this.position.Y + 2f) / 16;
						//Lighting.addLight(i2, j2, 0.92f, 0.8f, 0.65f);
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
						for (int num65 = 0; num65 < 10; num65++)
						{
							if (this.buffType[num65] == 60)
							{
								this.DelBuff(num65);
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
							this.stealth += 0.0015f;
							if (this.stealth > 1f)
							{
								this.stealth = 1f;
							}
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
							float num66 = Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y);
							this.stealth += num66 * 0.0075f;
							if (this.stealth > 1f)
							{
								this.stealth = 1f;
							}
						}
						this.rangedDamage += (1f - this.stealth) * 0.5f;
						this.rangedCrit += (int)((1f - this.stealth) * 10f);
						this.aggro -= (int)((1f - this.stealth) * 600f);
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
					if (this.bleed)
					{
						this.lifeRegenTime = 0;
					}
					float num67 = 0f;
					if (this.lifeRegenTime >= 300)
					{
						num67 += 1f;
					}
					if (this.lifeRegenTime >= 600)
					{
						num67 += 1f;
					}
					if (this.lifeRegenTime >= 900)
					{
						num67 += 1f;
					}
					if (this.lifeRegenTime >= 1200)
					{
						num67 += 1f;
					}
					if (this.lifeRegenTime >= 1500)
					{
						num67 += 1f;
					}
					if (this.lifeRegenTime >= 1800)
					{
						num67 += 1f;
					}
					if (this.lifeRegenTime >= 2400)
					{
						num67 += 1f;
					}
					if (this.lifeRegenTime >= 3000)
					{
						num67 += 1f;
					}
					if (this.lifeRegenTime >= 3600)
					{
						num67 += 1f;
						this.lifeRegenTime = 3600;
					}
					if (this.velocity.X == 0f || this.grappling[0] > 0)
					{
						num67 *= 1.25f;
					}
					else
					{
						num67 *= 0.5f;
					}
					if (this.crimsonRegen)
					{
						num67 *= 1.5f;
					}
					if (this.whoAmi == Main.myPlayer && Main.campfire)
					{
						num67 *= 1.1f;
					}
					float num68 = (float)this.statLifeMax / 400f * 0.85f + 0.15f;
					num67 *= num68;
					this.lifeRegen += (int)Math.Round((double)num67);
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
								for (int num69 = 0; num69 < 10; num69++)
								{
									int num70 = Dust.NewDust(this.position, this.width, this.height, 5, 0f, 0f, 175, default(Color), 1.75f);
									Main.dust[num70].noGravity = true;
									Main.dust[num70].velocity *= 0.75f;
									int num71 = Main.rand.Next(-40, 41);
									int num72 = Main.rand.Next(-40, 41);
									Dust expr_83D3_cp_0 = Main.dust[num70];
									expr_83D3_cp_0.position.X = expr_83D3_cp_0.position.X + (float)num71;
									Dust expr_83EF_cp_0 = Main.dust[num70];
									expr_83EF_cp_0.position.Y = expr_83EF_cp_0.position.Y + (float)num72;
									Main.dust[num70].velocity.X = (float)(-(float)num71) * 0.075f;
									Main.dust[num70].velocity.Y = (float)(-(float)num72) * 0.075f;
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
							goto IL_87CF;
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
					IL_87CF:
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
						float num73 = (float)this.statMana / (float)this.statManaMax2 * 0.8f + 0.2f;
						if (this.manaRegenBuff)
						{
							num73 = 1f;
						}
						this.manaRegen = (int)((float)this.manaRegen * num73);
					}
					else
					{
						this.manaRegen = 0;
					}
					this.manaRegenCount += this.manaRegen;
					while (this.manaRegenCount >= 120)
					{
						bool flag31 = false;
						this.manaRegenCount -= 120;
						if (this.statMana < this.statManaMax2)
						{
							this.statMana++;
							flag31 = true;
						}
						if (this.statMana >= this.statManaMax2)
						{
							if (this.whoAmi == Main.myPlayer && flag31)
							{
								Main.PlaySound(25, -1, -1, 1);
								for (int num74 = 0; num74 < 5; num74++)
								{
									int num75 = Dust.NewDust(this.position, this.width, this.height, 45, 0f, 0f, 255, default(Color), (float)Main.rand.Next(20, 26) * 0.1f);
									Main.dust[num75].noLight = true;
									Main.dust[num75].noGravity = true;
									Main.dust[num75].velocity *= 0.5f;
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
					if (this.sticky)
					{
						Player.jumpHeight /= 10;
						Player.jumpSpeed /= 5f;
					}
					for (int num76 = 0; num76 < 10; num76++)
					{
						if (this.buffType[num76] > 0 && this.buffTime[num76] > 0 && this.buffImmune[this.buffType[num76]])
						{
							this.DelBuff(num76);
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
					if (!this.pulley && !this.frozen && !this.controlJump && this.gravDir == 1f && this.ropeCount == 0 && this.grappling[0] == -1 && !this.tongued && (this.controlUp || this.controlDown))
					{
						int num77 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num78 = (int)(this.position.Y - 8f) / 16;
						if (Main.tile[num77, num78].active() && Main.tileRope[(int)Main.tile[num77, num78].type])
						{
							float num79 = this.position.Y;
							if (Main.tile[num77, num78 - 1] == null)
							{
								Main.tile[num77, num78 - 1] = new Tile();
							}
							if (Main.tile[num77, num78 + 1] == null)
							{
								Main.tile[num77, num78 + 1] = new Tile();
							}
							if ((!Main.tile[num77, num78 - 1].active() || !Main.tileRope[(int)Main.tile[num77, num78 - 1].type]) && (!Main.tile[num77, num78 + 1].active() || !Main.tileRope[(int)Main.tile[num77, num78 + 1].type]))
							{
								num79 = (float)(num78 * 16 + 22);
							}
							float num80 = (float)(num77 * 16 + 8 - this.width / 2 + 6 * this.direction);
							int num81 = num77 * 16 + 8 - this.width / 2 + 6;
							int num82 = num77 * 16 + 8 - this.width / 2;
							int num83 = num77 * 16 + 8 - this.width / 2 + -6;
							int num84 = 1;
							float num85 = Math.Abs(this.position.X - (float)num81);
							if (Math.Abs(this.position.X - (float)num82) < num85)
							{
								num84 = 2;
								num85 = Math.Abs(this.position.X - (float)num82);
							}
							if (Math.Abs(this.position.X - (float)num83) < num85)
							{
								num84 = 3;
								num85 = Math.Abs(this.position.X - (float)num83);
							}
							if (num84 == 1)
							{
								num80 = (float)num81;
								this.pulleyDir = 2;
								this.direction = 1;
							}
							if (num84 == 2)
							{
								num80 = (float)num82;
								this.pulleyDir = 1;
							}
							if (num84 == 3)
							{
								num80 = (float)num83;
								this.pulleyDir = 2;
								this.direction = -1;
							}
							if (!Collision.SolidCollision(new Vector2(num80, this.position.Y), this.width, this.height))
							{
								if (i == Main.myPlayer)
								{
									Main.cameraX = Main.cameraX + this.position.X - num80;
								}
								this.pulley = true;
								this.position.X = num80;
								this.gfxOffY = this.position.Y - num79;
								this.stepSpeed = 2.5f;
								this.position.Y = num79;
								this.velocity.X = 0f;
							}
							else
							{
								num80 = (float)num81;
								this.pulleyDir = 2;
								this.direction = 1;
								if (!Collision.SolidCollision(new Vector2(num80, this.position.Y), this.width, this.height))
								{
									if (i == Main.myPlayer)
									{
										Main.cameraX = Main.cameraX + this.position.X - num80;
									}
									this.pulley = true;
									this.position.X = num80;
									this.gfxOffY = this.position.Y - num79;
									this.stepSpeed = 2.5f;
									this.position.Y = num79;
									this.velocity.X = 0f;
								}
								else
								{
									num80 = (float)num83;
									this.pulleyDir = 2;
									this.direction = -1;
									if (!Collision.SolidCollision(new Vector2(num80, this.position.Y), this.width, this.height))
									{
										if (i == Main.myPlayer)
										{
											Main.cameraX = Main.cameraX + this.position.X - num80;
										}
										this.pulley = true;
										this.position.X = num80;
										this.gfxOffY = this.position.Y - num79;
										this.stepSpeed = 2.5f;
										this.position.Y = num79;
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
						int num86 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num87 = (int)(this.position.Y - 8f) / 16;
						bool flag32 = false;
						if (this.pulleyDir == 0)
						{
							this.pulleyDir = 1;
						}
						if (this.pulleyDir == 1)
						{
							if (this.direction == -1 && this.controlLeft && (this.releaseLeft || this.leftTimer == 0))
							{
								this.pulleyDir = 2;
								flag32 = true;
							}
							else if ((this.direction == 1 && this.controlRight && this.releaseRight) || this.rightTimer == 0)
							{
								this.pulleyDir = 2;
								flag32 = true;
							}
							else
							{
								if (this.direction == 1 && this.controlLeft)
								{
									this.direction = -1;
									flag32 = true;
								}
								if (this.direction == -1 && this.controlRight)
								{
									this.direction = 1;
									flag32 = true;
								}
							}
						}
						else if (this.pulleyDir == 2)
						{
							if (this.direction == 1 && this.controlLeft)
							{
								flag32 = true;
								int num88 = num86 * 16 + 8 - this.width / 2;
								if (!Collision.SolidCollision(new Vector2((float)num88, this.position.Y), this.width, this.height))
								{
									this.pulleyDir = 1;
									this.direction = -1;
									flag32 = true;
								}
							}
							if (this.direction == -1 && this.controlRight)
							{
								flag32 = true;
								int num89 = num86 * 16 + 8 - this.width / 2;
								if (!Collision.SolidCollision(new Vector2((float)num89, this.position.Y), this.width, this.height))
								{
									this.pulleyDir = 1;
									this.direction = 1;
									flag32 = true;
								}
							}
						}
						bool flag33 = false;
						if (!flag32 && ((this.controlLeft && (this.releaseLeft || this.leftTimer == 0)) || (this.controlRight && (this.releaseRight || this.rightTimer == 0))))
						{
							int num90 = 1;
							if (this.controlLeft)
							{
								num90 = -1;
							}
							int num91 = num86 + num90;
							if (Main.tile[num91, num87].active() && Main.tileRope[(int)Main.tile[num91, num87].type])
							{
								this.pulleyDir = 1;
								this.direction = num90;
								int num92 = num91 * 16 + 8 - this.width / 2;
								float num93 = this.position.Y;
								num93 = (float)(num87 * 16 + 22);
								if ((!Main.tile[num91, num87 - 1].active() || !Main.tileRope[(int)Main.tile[num91, num87 - 1].type]) && (!Main.tile[num91, num87 + 1].active() || !Main.tileRope[(int)Main.tile[num91, num87 + 1].type]))
								{
									num93 = (float)(num87 * 16 + 22);
								}
								if (Collision.SolidCollision(new Vector2((float)num92, num93), this.width, this.height))
								{
									this.pulleyDir = 2;
									this.direction = -num90;
									if (this.direction == 1)
									{
										num92 = num91 * 16 + 8 - this.width / 2 + 6;
									}
									else
									{
										num92 = num91 * 16 + 8 - this.width / 2 + -6;
									}
								}
								if (i == Main.myPlayer)
								{
									Main.cameraX = Main.cameraX + this.position.X - (float)num92;
								}
								this.position.X = (float)num92;
								this.gfxOffY = this.position.Y - num93;
								this.position.Y = num93;
								flag33 = true;
							}
						}
						if (!flag33 && !flag32 && !this.controlUp && ((this.controlLeft && this.releaseLeft) || (this.controlRight && this.releaseRight)))
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
						if (Main.tile[num86, num87] == null)
						{
							Main.tile[num86, num87] = new Tile();
						}
						if (!Main.tile[num86, num87].active() || !Main.tileRope[(int)Main.tile[num86, num87].type])
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
						int num94 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num95 = (int)(this.position.Y - 16f) / 16;
						int num96 = (int)(this.position.Y - 8f) / 16;
						bool flag34 = true;
						bool flag35 = false;
						if ((Main.tile[num94, num96 - 1].active() && Main.tileRope[(int)Main.tile[num94, num96 - 1].type]) || (Main.tile[num94, num96 + 1].active() && Main.tileRope[(int)Main.tile[num94, num96 + 1].type]))
						{
							flag35 = true;
						}
						if (Main.tile[num94, num95] == null)
						{
							Main.tile[num94, num95] = new Tile();
						}
						if (!Main.tile[num94, num95].active() || !Main.tileRope[(int)Main.tile[num94, num95].type])
						{
							flag34 = false;
							if (this.velocity.Y < 0f)
							{
								this.velocity.Y = 0f;
							}
						}
						if (flag35)
						{
							if (this.controlUp && flag34)
							{
								float num97 = this.position.X;
								float y = this.position.Y - Math.Abs(this.velocity.Y) - 2f;
								if (Collision.SolidCollision(new Vector2(num97, y), this.width, this.height))
								{
									num97 = (float)(num94 * 16 + 8 - this.width / 2 + 6);
									if (!Collision.SolidCollision(new Vector2(num97, y), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
									{
										if (i == Main.myPlayer)
										{
											Main.cameraX = Main.cameraX + this.position.X - num97;
										}
										this.pulleyDir = 2;
										this.direction = 1;
										this.position.X = num97;
										this.velocity.X = 0f;
									}
									else
									{
										num97 = (float)(num94 * 16 + 8 - this.width / 2 + -6);
										if (!Collision.SolidCollision(new Vector2(num97, y), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
										{
											if (i == Main.myPlayer)
											{
												Main.cameraX = Main.cameraX + this.position.X - num97;
											}
											this.pulleyDir = 2;
											this.direction = -1;
											this.position.X = num97;
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
								float num98 = this.position.X;
								float y2 = this.position.Y;
								if (Collision.SolidCollision(new Vector2(num98, y2), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
								{
									num98 = (float)(num94 * 16 + 8 - this.width / 2 + 6);
									if (!Collision.SolidCollision(new Vector2(num98, y2), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
									{
										if (i == Main.myPlayer)
										{
											Main.cameraX = Main.cameraX + this.position.X - num98;
										}
										this.pulleyDir = 2;
										this.direction = 1;
										this.position.X = num98;
										this.velocity.X = 0f;
									}
									else
									{
										num98 = (float)(num94 * 16 + 8 - this.width / 2 + -6);
										if (!Collision.SolidCollision(new Vector2(num98, y2), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
										{
											if (i == Main.myPlayer)
											{
												Main.cameraX = Main.cameraX + this.position.X - num98;
											}
											this.pulleyDir = 2;
											this.direction = -1;
											this.position.X = num98;
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
							this.position.Y = (float)(num95 * 16 + 22);
						}
						float num99 = (float)(num94 * 16 + 8 - this.width / 2);
						if (this.pulleyDir == 1)
						{
							num99 = (float)(num94 * 16 + 8 - this.width / 2);
						}
						if (this.pulleyDir == 2)
						{
							num99 = (float)(num94 * 16 + 8 - this.width / 2 + 6 * this.direction);
						}
						if (i == Main.myPlayer)
						{
							Main.cameraX = Main.cameraX + this.position.X - num99;
						}
						this.position.X = num99;
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
						this.wingTime = this.GetWingTime();
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
							if (this.wings == 9 || this.wings == 10 || this.wings == 11 || this.wings == 20 || this.wings == 21)
							{
								num6 = 7.5f;
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
						else if (this.controlLeft && this.velocity.X > -num6 && this.dashDelay == 0)
						{
							if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
							{
								this.direction = -1;
							}
							if (this.velocity.Y == 0f || this.wings > 0)
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
							if (this.velocity.X < -(num6 + num3) / 2f && this.velocity.Y == 0f)
							{
								int num100 = 0;
								if (this.gravDir == -1f)
								{
									num100 -= this.height;
								}
								if (this.runSoundDelay == 0 && this.velocity.Y == 0f)
								{
									Main.PlaySound(17, (int)this.position.X, (int)this.position.Y, 1);
									this.runSoundDelay = 9;
								}
								if (this.wings == 3)
								{
									int num101 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num100), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num101].velocity *= 0.025f;
									num101 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num100), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num101].velocity *= 0.2f;
								}
								else if (this.coldDash)
								{
									for (int num102 = 0; num102 < 2; num102++)
									{
										int num103;
										if (num102 == 0)
										{
											num103 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
										}
										else
										{
											num103 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
										}
										Main.dust[num103].scale *= 1f + (float)Main.rand.Next(20, 40) * 0.01f;
										Main.dust[num103].noGravity = true;
										Main.dust[num103].noLight = true;
										Main.dust[num103].velocity *= 0.001f;
										Dust expr_A60B_cp_0 = Main.dust[num103];
										expr_A60B_cp_0.velocity.Y = expr_A60B_cp_0.velocity.Y - 0.003f;
									}
								}
								else
								{
									int num104 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num100), this.width + 8, 4, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num104].velocity.X = Main.dust[num104].velocity.X * 0.2f;
									Main.dust[num104].velocity.Y = Main.dust[num104].velocity.Y * 0.2f;
								}
							}
						}
						else if (this.controlRight && this.velocity.X < num6 && this.dashDelay == 0)
						{
							if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
							{
								this.direction = 1;
							}
							if (this.velocity.Y == 0f || this.wings > 0)
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
							if (this.velocity.X > (num6 + num3) / 2f && this.velocity.Y == 0f)
							{
								int num105 = 0;
								if (this.gravDir == -1f)
								{
									num105 -= this.height;
								}
								if (this.runSoundDelay == 0 && this.velocity.Y == 0f)
								{
									Main.PlaySound(17, (int)this.position.X, (int)this.position.Y, 1);
									this.runSoundDelay = 9;
								}
								if (this.wings == 3)
								{
									int num106 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num105), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num106].velocity *= 0.025f;
									num106 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num105), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num106].velocity *= 0.2f;
								}
								else if (this.coldDash)
								{
									for (int num107 = 0; num107 < 2; num107++)
									{
										int num108;
										if (num107 == 0)
										{
											num108 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
										}
										else
										{
											num108 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
										}
										Main.dust[num108].scale *= 1f + (float)Main.rand.Next(20, 40) * 0.01f;
										Main.dust[num108].noGravity = true;
										Main.dust[num108].noLight = true;
										Main.dust[num108].velocity *= 0.001f;
										Dust expr_AADB_cp_0 = Main.dust[num108];
										expr_AADB_cp_0.velocity.Y = expr_AADB_cp_0.velocity.Y - 0.003f;
									}
								}
								else
								{
									int num109 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num105), this.width + 8, 4, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
									Main.dust[num109].velocity.X = Main.dust[num109].velocity.X * 0.2f;
									Main.dust[num109].velocity.Y = Main.dust[num109].velocity.Y * 0.2f;
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
								bool flag36 = false;
								if (this.wet && this.accFlipper)
								{
									if (this.swimTime == 0)
									{
										this.swimTime = 30;
									}
									flag36 = true;
								}
								bool flag37 = false;
								bool flag38 = false;
								bool flag39 = false;
								if (this.jumpAgain2)
								{
									flag37 = true;
									this.jumpAgain2 = false;
								}
								else if (this.jumpAgain3)
								{
									flag38 = true;
									this.jumpAgain3 = false;
								}
								else if (this.jumpAgain4)
								{
									this.jumpAgain4 = false;
									flag39 = true;
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
								if (this.velocity.Y == 0f || flag36 || this.sliding)
								{
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									this.jump = Player.jumpHeight;
									if (this.sliding)
									{
										this.velocity.X = (float)(3 * -(float)this.slideDir);
									}
								}
								else if (flag37)
								{
									this.dJumpEffect2 = true;
									float arg_B11B_0 = this.gravDir;
									Main.PlaySound(16, (int)this.position.X, (int)this.position.Y, 1);
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									this.jump = Player.jumpHeight * 3;
								}
								else if (flag38)
								{
									this.dJumpEffect3 = true;
									float arg_B17D_0 = this.gravDir;
									Main.PlaySound(16, (int)this.position.X, (int)this.position.Y, 1);
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									this.jump = (int)((double)Player.jumpHeight * 1.5);
								}
								else if (flag39)
								{
									this.dJumpEffect4 = true;
									int num110 = this.height;
									if (this.gravDir == -1f)
									{
										num110 = 0;
									}
									Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 16);
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									this.jump = Player.jumpHeight * 2;
									for (int num111 = 0; num111 < 10; num111++)
									{
										int num112 = Dust.NewDust(new Vector2(this.position.X - 34f, this.position.Y + (float)num110 - 16f), 102, 32, 188, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
										Main.dust[num112].velocity.X = Main.dust[num112].velocity.X * 0.5f - this.velocity.X * 0.1f;
										Main.dust[num112].velocity.Y = Main.dust[num112].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
									}
									int num113 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 16f, this.position.Y + (float)num110 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(435, 438), 1f);
									Main.gore[num113].velocity.X = Main.gore[num113].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num113].velocity.Y = Main.gore[num113].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
									num113 = Gore.NewGore(new Vector2(this.position.X - 36f, this.position.Y + (float)num110 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(435, 438), 1f);
									Main.gore[num113].velocity.X = Main.gore[num113].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num113].velocity.Y = Main.gore[num113].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
									num113 = Gore.NewGore(new Vector2(this.position.X + (float)this.width + 4f, this.position.Y + (float)num110 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(435, 438), 1f);
									Main.gore[num113].velocity.X = Main.gore[num113].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num113].velocity.Y = Main.gore[num113].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
								}
								else
								{
									this.dJumpEffect = true;
									int num114 = this.height;
									if (this.gravDir == -1f)
									{
										num114 = 0;
									}
									Main.PlaySound(16, (int)this.position.X, (int)this.position.Y, 1);
									this.velocity.Y = -Player.jumpSpeed * this.gravDir;
									this.jump = (int)((double)Player.jumpHeight * 0.75);
									for (int num115 = 0; num115 < 10; num115++)
									{
										int num116 = Dust.NewDust(new Vector2(this.position.X - 34f, this.position.Y + (float)num114 - 16f), 102, 32, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
										Main.dust[num116].velocity.X = Main.dust[num116].velocity.X * 0.5f - this.velocity.X * 0.1f;
										Main.dust[num116].velocity.Y = Main.dust[num116].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
									}
									int num117 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 16f, this.position.Y + (float)num114 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
									Main.gore[num117].velocity.X = Main.gore[num117].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num117].velocity.Y = Main.gore[num117].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
									num117 = Gore.NewGore(new Vector2(this.position.X - 36f, this.position.Y + (float)num114 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
									Main.gore[num117].velocity.X = Main.gore[num117].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num117].velocity.Y = Main.gore[num117].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
									num117 = Gore.NewGore(new Vector2(this.position.X + (float)this.width + 4f, this.position.Y + (float)num114 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
									Main.gore[num117].velocity.X = Main.gore[num117].velocity.X * 0.1f - this.velocity.X * 0.1f;
									Main.gore[num117].velocity.Y = Main.gore[num117].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
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
							this.wingTime = 0;
						}
						if (this.wings == 3)
						{
							this.wingTime = 1000;
						}
						if (Main.myPlayer == this.whoAmi && (this.wings == 3 || this.wings == 16 || this.wings == 17 || this.wings == 18 || this.wings == 19))
						{
							this.wingTime = 0;
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
							for (int num118 = 0; num118 < 2; num118++)
							{
								int num119;
								if (this.velocity.Y == 0f)
								{
									num119 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 4f), this.width, 8, 31, 0f, 0f, 100, default(Color), 1.4f);
								}
								else
								{
									num119 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)(this.height / 2) - 8f), this.width, 16, 31, 0f, 0f, 100, default(Color), 1.4f);
								}
								Main.dust[num119].velocity *= 0.1f;
								Main.dust[num119].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
							}
							if (this.velocity.X > 13f || this.velocity.X < -13f)
							{
								this.velocity.X = this.velocity.X * 0.99f;
							}
							else if (this.velocity.X > num3 || this.velocity.X < -num3)
							{
								this.velocity.X = this.velocity.X * 0.8f;
							}
							else
							{
								this.dashDelay = 30;
							}
						}
						else if (this.dash > 0)
						{
							int num120 = 0;
							bool flag40 = false;
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
									num120 = 1;
									flag40 = true;
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
									num120 = -1;
									flag40 = true;
									this.dashTime = 0;
								}
								else
								{
									this.dashTime = -15;
								}
							}
							if (flag40)
							{
								this.velocity.X = 15.9f * (float)num120;
								this.dashDelay = -1;
								for (int num121 = 0; num121 < 20; num121++)
								{
									int num122 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 2f);
									Dust expr_BDC0_cp_0 = Main.dust[num122];
									expr_BDC0_cp_0.position.X = expr_BDC0_cp_0.position.X + (float)Main.rand.Next(-5, 6);
									Dust expr_BDE7_cp_0 = Main.dust[num122];
									expr_BDE7_cp_0.position.Y = expr_BDE7_cp_0.position.Y + (float)Main.rand.Next(-5, 6);
									Main.dust[num122].velocity *= 0.2f;
									Main.dust[num122].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
								}
								int num123 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 34f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num123].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
								Main.gore[num123].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
								Main.gore[num123].velocity *= 0.4f;
								num123 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 14f), default(Vector2), Main.rand.Next(61, 64), 1f);
								Main.gore[num123].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
								Main.gore[num123].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
								Main.gore[num123].velocity *= 0.4f;
							}
						}
						this.sliding = false;
						if (this.slideDir != 0 && this.spikedBoots > 0 && ((this.controlLeft && this.slideDir == -1) || (this.controlRight && this.slideDir == 1)))
						{
							bool flag41 = false;
							float num124 = this.position.X;
							if (this.slideDir == 1)
							{
								num124 += (float)this.width;
							}
							num124 += (float)this.slideDir;
							float num125 = this.position.Y + (float)this.height + 1f;
							if (this.gravDir < 0f)
							{
								num125 = this.position.Y - 1f;
							}
							num124 /= 16f;
							num125 /= 16f;
							if (WorldGen.SolidTile((int)num124, (int)num125) && WorldGen.SolidTile((int)num124, (int)num125 - 1))
							{
								flag41 = true;
							}
							if (this.spikedBoots >= 2)
							{
								if (flag41 && ((this.velocity.Y > 0f && this.gravDir == 1f) || (this.velocity.Y < num2 && this.gravDir == -1f)))
								{
									float num126 = num2;
									if (this.slowFall)
									{
										if (this.controlUp)
										{
											num126 = num2 / 10f * this.gravDir;
										}
										else
										{
											num126 = num2 / 3f * this.gravDir;
										}
									}
									this.fallStart = (int)(this.position.Y / 16f);
									if ((this.controlDown && this.gravDir == 1f) || (this.controlUp && this.gravDir == -1f))
									{
										this.velocity.Y = 4f * this.gravDir;
										int num127 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)((this.width / 2 - 4) * this.slideDir), this.position.Y + (float)(this.height / 2) + (float)(this.height / 2 - 4) * this.gravDir), 8, 8, 31, 0f, 0f, 0, default(Color), 1f);
										if (this.slideDir < 0)
										{
											Dust expr_C256_cp_0 = Main.dust[num127];
											expr_C256_cp_0.position.X = expr_C256_cp_0.position.X - 10f;
										}
										if (this.gravDir < 0f)
										{
											Dust expr_C281_cp_0 = Main.dust[num127];
											expr_C281_cp_0.position.Y = expr_C281_cp_0.position.Y - 12f;
										}
										Main.dust[num127].velocity *= 0.1f;
										Main.dust[num127].scale *= 1.2f;
										Main.dust[num127].noGravity = true;
									}
									else if (this.gravDir == -1f)
									{
										this.velocity.Y = (-num126 + 1E-05f) * this.gravDir;
									}
									else
									{
										this.velocity.Y = (-num126 + 1E-05f) * this.gravDir;
									}
									this.sliding = true;
								}
							}
							else if ((flag41 && (double)this.velocity.Y > 0.5 && this.gravDir == 1f) || ((double)this.velocity.Y < -0.5 && this.gravDir == -1f))
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
								int num128 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)((this.width / 2 - 4) * this.slideDir), this.position.Y + (float)(this.height / 2) + (float)(this.height / 2 - 4) * this.gravDir), 8, 8, 31, 0f, 0f, 0, default(Color), 1f);
								if (this.slideDir < 0)
								{
									Dust expr_C466_cp_0 = Main.dust[num128];
									expr_C466_cp_0.position.X = expr_C466_cp_0.position.X - 10f;
								}
								if (this.gravDir < 0f)
								{
									Dust expr_C491_cp_0 = Main.dust[num128];
									expr_C491_cp_0.position.Y = expr_C491_cp_0.position.Y - 12f;
								}
								Main.dust[num128].velocity *= 0.1f;
								Main.dust[num128].scale *= 1.2f;
								Main.dust[num128].noGravity = true;
							}
						}
						bool flag42 = false;
						if (this.grappling[0] == -1 && this.carpet && !this.jumpAgain && !this.jumpAgain2 && !this.jumpAgain3 && !this.jumpAgain4 && this.jump == 0 && this.velocity.Y != 0f && this.rocketTime == 0 && this.wingTime == 0)
						{
							if (this.controlJump && this.canCarpet)
							{
								this.canCarpet = false;
								this.carpetTime = 300;
							}
							if (this.carpetTime > 0 && this.controlJump)
							{
								this.fallStart = (int)(this.position.Y / 16f);
								flag42 = true;
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
						if (!flag42)
						{
							this.carpetFrame = -1;
						}
						if (this.dJumpEffect && this.doubleJump && !this.jumpAgain && (this.jumpAgain2 || !this.doubleJump2) && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
						{
							int num129 = this.height;
							if (this.gravDir == -1f)
							{
								num129 = -6;
							}
							int num130 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)num129), this.width + 8, 4, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
							Main.dust[num130].velocity.X = Main.dust[num130].velocity.X * 0.5f - this.velocity.X * 0.1f;
							Main.dust[num130].velocity.Y = Main.dust[num130].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
						}
						if (this.dJumpEffect2 && this.doubleJump2 && !this.jumpAgain2 && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
						{
							int num131 = this.height;
							if (this.gravDir == -1f)
							{
								num131 = -6;
							}
							float num132 = ((float)this.jump / 75f + 1f) / 2f;
							for (int num133 = 0; num133 < 3; num133++)
							{
								int num134 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)(num131 / 2)), this.width, 32, 124, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 150, default(Color), 1f * num132);
								Main.dust[num134].velocity *= 0.5f * num132;
								Main.dust[num134].fadeIn = 1.5f * num132;
							}
							this.sandStorm = true;
							if (this.miscCounter % 3 == 0)
							{
								int num135 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 18f, this.position.Y + (float)(num131 / 2)), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(220, 223), num132);
								Main.gore[num135].velocity = this.velocity * 0.3f * num132;
								Main.gore[num135].alpha = 100;
							}
						}
						if (this.dJumpEffect4 && this.doubleJump4 && !this.jumpAgain4 && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
						{
							int num136 = this.height;
							if (this.gravDir == -1f)
							{
								num136 = -6;
							}
							int num137 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)num136), this.width + 8, 4, 188, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
							Main.dust[num137].velocity.X = Main.dust[num137].velocity.X * 0.5f - this.velocity.X * 0.1f;
							Main.dust[num137].velocity.Y = Main.dust[num137].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
							Main.dust[num137].velocity *= 0.5f;
						}
						if (this.dJumpEffect3 && this.doubleJump3 && !this.jumpAgain3 && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
						{
							int num138 = this.height - 6;
							if (this.gravDir == -1f)
							{
								num138 = 6;
							}
							for (int num139 = 0; num139 < 2; num139++)
							{
								int num140 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)num138), this.width, 12, 76, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 0, default(Color), 1f);
								Main.dust[num140].velocity *= 0.1f;
								if (num139 == 0)
								{
									Main.dust[num140].velocity += this.velocity * 0.03f;
								}
								else
								{
									Main.dust[num140].velocity -= this.velocity * 0.03f;
								}
								Main.dust[num140].noLight = true;
							}
							for (int num141 = 0; num141 < 3; num141++)
							{
								int num142 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)num138), this.width, 12, 76, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 0, default(Color), 1f);
								Main.dust[num142].fadeIn = 1.5f;
								Main.dust[num142].velocity *= 0.6f;
								Main.dust[num142].velocity += this.velocity * 0.8f;
								Main.dust[num142].noGravity = true;
								Main.dust[num142].noLight = true;
							}
							for (int num143 = 0; num143 < 3; num143++)
							{
								int num144 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)num138), this.width, 12, 76, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 0, default(Color), 1f);
								Main.dust[num144].fadeIn = 1.5f;
								Main.dust[num144].velocity *= 0.6f;
								Main.dust[num144].velocity -= this.velocity * 0.8f;
								Main.dust[num144].noGravity = true;
								Main.dust[num144].noLight = true;
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
						bool flag43 = false;
						if (this.velocity.Y == 0f || this.sliding)
						{
							this.wingTime = this.GetWingTime();
						}
						if (this.wings > 0 && this.controlJump && this.wingTime > 0 && !this.jumpAgain && this.jump == 0 && this.velocity.Y != 0f)
						{
							flag43 = true;
						}
						if (this.frozen)
						{
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
							if (flag43)
							{
								if (this.wings == 10 && Main.rand.Next(2) == 0)
								{
									int num145 = 4;
									if (this.direction == 1)
									{
										num145 = -40;
									}
									int num146 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num145, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 76, 0f, 0f, 50, default(Color), 0.6f);
									Main.dust[num146].fadeIn = 1.1f;
									Main.dust[num146].noGravity = true;
									Main.dust[num146].noLight = true;
									Main.dust[num146].velocity *= 0.3f;
								}
								if (this.wings == 9 && Main.rand.Next(2) == 0)
								{
									int num147 = 4;
									if (this.direction == 1)
									{
										num147 = -40;
									}
									int num148 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num147, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 6, 0f, 0f, 200, default(Color), 2f);
									Main.dust[num148].noGravity = true;
									Main.dust[num148].velocity *= 0.3f;
								}
								if (this.wings == 6 && Main.rand.Next(4) == 0)
								{
									int num149 = 4;
									if (this.direction == 1)
									{
										num149 = -40;
									}
									int num150 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num149, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 55, 0f, 0f, 200, default(Color), 1f);
									Main.dust[num150].velocity *= 0.3f;
								}
								if (this.wings == 5 && Main.rand.Next(3) == 0)
								{
									int num151 = 6;
									if (this.direction == 1)
									{
										num151 = -30;
									}
									int num152 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num151, this.position.Y), 18, this.height, 58, 0f, 0f, 255, default(Color), 1.2f);
									Main.dust[num152].velocity *= 0.3f;
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
									this.wingTime -= 2;
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
									this.wingTime -= 2;
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
									this.wingTime--;
								}
							}
							if (this.wings == 4)
							{
								if (flag43 || this.jump > 0)
								{
									this.rocketDelay2--;
									if (this.rocketDelay2 <= 0)
									{
										Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 13);
										this.rocketDelay2 = 60;
									}
									int num153 = 2;
									if (this.controlUp)
									{
										num153 = 4;
									}
									for (int num154 = 0; num154 < num153; num154++)
									{
										int type3 = 6;
										if (this.head == 41)
										{
											int arg_D7D1_0 = this.body;
										}
										float scale = 1.75f;
										int alpha = 100;
										float x = this.position.X + (float)(this.width / 2) + 16f;
										if (this.direction > 0)
										{
											x = this.position.X + (float)(this.width / 2) - 26f;
										}
										float num155 = this.position.Y + (float)this.height - 18f;
										if (num154 == 1 || num154 == 3)
										{
											x = this.position.X + (float)(this.width / 2) + 8f;
											if (this.direction > 0)
											{
												x = this.position.X + (float)(this.width / 2) - 20f;
											}
											num155 += 6f;
										}
										if (num154 > 1)
										{
											num155 += this.velocity.Y;
										}
										int num156 = Dust.NewDust(new Vector2(x, num155), 8, 8, type3, 0f, 0f, alpha, default(Color), scale);
										Dust expr_D8E4_cp_0 = Main.dust[num156];
										expr_D8E4_cp_0.velocity.X = expr_D8E4_cp_0.velocity.X * 0.1f;
										Main.dust[num156].velocity.Y = Main.dust[num156].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
										Main.dust[num156].noGravity = true;
										if (num153 == 4)
										{
											Dust expr_D95E_cp_0 = Main.dust[num156];
											expr_D95E_cp_0.velocity.Y = expr_D95E_cp_0.velocity.Y + 6f;
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
							else if (this.wings == 12)
							{
								if (flag43 || this.jump > 0)
								{
									this.wingFrameCounter++;
									int num157 = 5;
									if (this.wingFrameCounter < num157)
									{
										this.wingFrame = 1;
									}
									else if (this.wingFrameCounter < num157 * 2)
									{
										this.wingFrame = 2;
									}
									else if (this.wingFrameCounter < num157 * 3)
									{
										this.wingFrame = 3;
									}
									else if (this.wingFrameCounter < num157 * 4 - 1)
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
							else if (flag43 || this.jump > 0)
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
								this.wingTime += this.rocketTime * 3;
								this.rocketTime = 0;
							}
							if (flag43 && this.wings != 4)
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
							if ((this.wingTime == 0 || this.wings == 0) && this.rocketBoots > 0 && this.controlJump && this.rocketDelay == 0 && this.canRocket && this.rocketRelease && !this.jumpAgain)
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
										else if (this.rocketBoots == 2)
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
								int num158 = this.height;
								if (this.gravDir == -1f)
								{
									num158 = 4;
								}
								this.rocketFrame = true;
								for (int num159 = 0; num159 < 2; num159++)
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
									else if (this.socialShadow)
									{
										type4 = 27;
										scale2 = 1.5f;
									}
									if (num159 == 0)
									{
										int num160 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)num158 - 10f), 8, 8, type4, 0f, 0f, alpha2, default(Color), scale2);
										if (this.rocketBoots == 1)
										{
											Main.dust[num160].noGravity = true;
										}
										Main.dust[num160].velocity.X = Main.dust[num160].velocity.X * 1f - 2f - this.velocity.X * 0.3f;
										Main.dust[num160].velocity.Y = Main.dust[num160].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
										if (this.rocketBoots == 2)
										{
											Main.dust[num160].velocity *= 0.1f;
										}
									}
									else
									{
										int num161 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 4f, this.position.Y + (float)num158 - 10f), 8, 8, type4, 0f, 0f, alpha2, default(Color), scale2);
										if (this.rocketBoots == 1)
										{
											Main.dust[num161].noGravity = true;
										}
										Main.dust[num161].velocity.X = Main.dust[num161].velocity.X * 1f + 2f - this.velocity.X * 0.3f;
										Main.dust[num161].velocity.Y = Main.dust[num161].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
										if (this.rocketBoots == 2)
										{
											Main.dust[num161].velocity *= 0.1f;
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
							else if (!flag43)
							{
								if (this.slowFall && ((!this.controlDown && this.gravDir == 1f) || (!this.controlUp && this.gravDir == -1f)))
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
											int num162 = 4;
											if (this.direction == 1)
											{
												num162 = -40;
											}
											int num163 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num162, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 76, 0f, 0f, 50, default(Color), 0.6f);
											Main.dust[num163].fadeIn = 1.1f;
											Main.dust[num163].noGravity = true;
											Main.dust[num163].noLight = true;
											Main.dust[num163].velocity *= 0.3f;
										}
										if (this.wings == 9 && Main.rand.Next(3) == 0)
										{
											int num164 = 8;
											if (this.direction == 1)
											{
												num164 = -40;
											}
											int num165 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num164, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 6, 0f, 0f, 200, default(Color), 2f);
											Main.dust[num165].noGravity = true;
											Main.dust[num165].velocity *= 0.3f;
										}
										if (this.wings == 6)
										{
											if (Main.rand.Next(10) == 0)
											{
												int num166 = 4;
												if (this.direction == 1)
												{
													num166 = -40;
												}
												int num167 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num166, this.position.Y + (float)(this.height / 2) - 12f), 30, 20, 55, 0f, 0f, 200, default(Color), 1f);
												Main.dust[num167].velocity *= 0.3f;
											}
										}
										else if (this.wings == 5 && Main.rand.Next(6) == 0)
										{
											int num168 = 6;
											if (this.direction == 1)
											{
												num168 = -30;
											}
											int num169 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num168, this.position.Y), 18, this.height, 58, 0f, 0f, 255, default(Color), 1.2f);
											Main.dust[num169].velocity *= 0.3f;
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
											float num170 = this.position.Y + (float)this.height - 18f;
											if (Main.rand.Next(2) == 1)
											{
												x2 = this.position.X + (float)(this.width / 2) + 8f;
												if (this.direction > 0)
												{
													x2 = this.position.X + (float)(this.width / 2) - 20f;
												}
												num170 += 6f;
											}
											int num171 = Dust.NewDust(new Vector2(x2, num170), 8, 8, type5, 0f, 0f, alpha3, default(Color), scale3);
											Dust expr_E655_cp_0 = Main.dust[num171];
											expr_E655_cp_0.velocity.X = expr_E655_cp_0.velocity.X * 0.3f;
											Dust expr_E673_cp_0 = Main.dust[num171];
											expr_E673_cp_0.velocity.Y = expr_E673_cp_0.velocity.Y + 10f;
											Main.dust[num171].noGravity = true;
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
										else if (this.wings == 12)
										{
											this.wingFrame = 3;
										}
										else
										{
											this.wingFrame = 2;
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
					for (int num172 = 0; num172 < 400; num172++)
					{
						if (Main.item[num172].active && Main.item[num172].noGrabDelay == 0 && Main.item[num172].owner == i)
						{
							if (new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height).Intersects(new Rectangle((int)Main.item[num172].position.X, (int)Main.item[num172].position.Y, Main.item[num172].width, Main.item[num172].height)))
							{
								if (i == Main.myPlayer && (this.inventory[this.selectedItem].type != 0 || this.itemAnimation <= 0))
								{
									if (Main.item[num172].type == 58 || Main.item[num172].type == 1734)
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
										Main.item[num172] = new Item();
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num172, 0f, 0f, 0f, 0);
										}
									}
									else if (Main.item[num172].type == 184 || Main.item[num172].type == 1735)
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
										Main.item[num172] = new Item();
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num172, 0f, 0f, 0f, 0);
										}
									}
									else
									{
										Main.item[num172] = this.GetItem(i, Main.item[num172]);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num172, 0f, 0f, 0f, 0);
										}
									}
								}
							}
							else if (new Rectangle((int)this.position.X - Player.itemGrabRange, (int)this.position.Y - Player.itemGrabRange, this.width + Player.itemGrabRange * 2, this.height + Player.itemGrabRange * 2).Intersects(new Rectangle((int)Main.item[num172].position.X, (int)Main.item[num172].position.Y, Main.item[num172].width, Main.item[num172].height)) && this.ItemSpace(Main.item[num172]))
							{
								Main.item[num172].beingGrabbed = true;
								if ((double)this.position.X + (double)this.width * 0.5 > (double)Main.item[num172].position.X + (double)Main.item[num172].width * 0.5)
								{
									if (Main.item[num172].velocity.X < Player.itemGrabSpeedMax + this.velocity.X)
									{
										Item expr_ED79_cp_0 = Main.item[num172];
										expr_ED79_cp_0.velocity.X = expr_ED79_cp_0.velocity.X + Player.itemGrabSpeed;
									}
									if (Main.item[num172].velocity.X < 0f)
									{
										Item expr_EDB3_cp_0 = Main.item[num172];
										expr_EDB3_cp_0.velocity.X = expr_EDB3_cp_0.velocity.X + Player.itemGrabSpeed * 0.75f;
									}
								}
								else
								{
									if (Main.item[num172].velocity.X > -Player.itemGrabSpeedMax + this.velocity.X)
									{
										Item expr_EE02_cp_0 = Main.item[num172];
										expr_EE02_cp_0.velocity.X = expr_EE02_cp_0.velocity.X - Player.itemGrabSpeed;
									}
									if (Main.item[num172].velocity.X > 0f)
									{
										Item expr_EE39_cp_0 = Main.item[num172];
										expr_EE39_cp_0.velocity.X = expr_EE39_cp_0.velocity.X - Player.itemGrabSpeed * 0.75f;
									}
								}
								if ((double)this.position.Y + (double)this.height * 0.5 > (double)Main.item[num172].position.Y + (double)Main.item[num172].height * 0.5)
								{
									if (Main.item[num172].velocity.Y < Player.itemGrabSpeedMax)
									{
										Item expr_EEC2_cp_0 = Main.item[num172];
										expr_EEC2_cp_0.velocity.Y = expr_EEC2_cp_0.velocity.Y + Player.itemGrabSpeed;
									}
									if (Main.item[num172].velocity.Y < 0f)
									{
										Item expr_EEFC_cp_0 = Main.item[num172];
										expr_EEFC_cp_0.velocity.Y = expr_EEFC_cp_0.velocity.Y + Player.itemGrabSpeed * 0.75f;
									}
								}
								else
								{
									if (Main.item[num172].velocity.Y > -Player.itemGrabSpeedMax)
									{
										Item expr_EF3C_cp_0 = Main.item[num172];
										expr_EF3C_cp_0.velocity.Y = expr_EF3C_cp_0.velocity.Y - Player.itemGrabSpeed;
									}
									if (Main.item[num172].velocity.Y > 0f)
									{
										Item expr_EF73_cp_0 = Main.item[num172];
										expr_EF73_cp_0.velocity.Y = expr_EF73_cp_0.velocity.Y - Player.itemGrabSpeed * 0.75f;
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
								int num173;
								for (num173 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18); num173 >= 4; num173 -= 4)
								{
								}
								if (num173 < 2)
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
								int num174 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
								int num175 = 0;
								while (num174 >= 40)
								{
									num174 -= 40;
									num175++;
								}
								this.showItemIcon2 = 970 + num175;
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
								int num176 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 22);
								if (num176 == 0)
								{
									this.showItemIcon2 = 8;
								}
								else if (num176 == 8)
								{
									this.showItemIcon2 = 523;
								}
								else if (num176 == 9)
								{
									this.showItemIcon2 = 974;
								}
								else if (num176 == 10)
								{
									this.showItemIcon2 = 1245;
								}
								else if (num176 == 11)
								{
									this.showItemIcon2 = 1333;
								}
								else
								{
									this.showItemIcon2 = 426 + num176;
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
								int num177 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 22);
								if (num177 == 1)
								{
									this.showItemIcon2 = 1405;
								}
								if (num177 == 2)
								{
									this.showItemIcon2 = 1406;
								}
								if (num177 == 3)
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
								int num178 = Player.tileTargetX;
								int num179 = Player.tileTargetY;
								int num180 = 0;
								for (int num181 = (int)(Main.tile[num178, num179].frameY / 18); num181 >= 2; num181 -= 2)
								{
									num180++;
								}
								this.showItemIcon = true;
								if (num180 >= 13)
								{
									this.showItemIcon2 = 1596 + num180 - 13;
								}
								else
								{
									this.showItemIcon2 = 562 + num180;
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 207)
							{
								this.noThrow = 2;
								int num182 = Player.tileTargetX;
								int num183 = Player.tileTargetY;
								int num184 = 0;
								for (int num185 = (int)(Main.tile[num182, num183].frameX / 18); num185 >= 2; num185 -= 2)
								{
									num184++;
								}
								this.showItemIcon = true;
								if (num184 == 0)
								{
									this.showItemIcon2 = 909;
								}
								else if (num184 == 1)
								{
									this.showItemIcon2 = 910;
								}
								else if (num184 == 2)
								{
									this.showItemIcon2 = 940;
								}
								else if (num184 == 3)
								{
									this.showItemIcon2 = 941;
								}
								else if (num184 == 4)
								{
									this.showItemIcon2 = 942;
								}
								else if (num184 == 5)
								{
									this.showItemIcon2 = 943;
								}
								else if (num184 == 6)
								{
									this.showItemIcon2 = 944;
								}
								else if (num184 == 7)
								{
									this.showItemIcon2 = 945;
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 55 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 85)
							{
								this.noThrow = 2;
								int num186 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18);
								int num187 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
								while (num186 > 1)
								{
									num186 -= 2;
								}
								int num188 = Player.tileTargetX - num186;
								int num189 = Player.tileTargetY - num187;
								Main.signBubble = true;
								Main.signX = num188 * 16 + 16;
								Main.signY = num189 * 16;
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
								int num190 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
								int num191 = 0;
								while (num190 >= 54)
								{
									num190 -= 54;
									num191++;
								}
								if (num191 == 0)
								{
									this.showItemIcon2 = 25;
								}
								else if (num191 == 9)
								{
									this.showItemIcon2 = 837;
								}
								else if (num191 == 10)
								{
									this.showItemIcon2 = 912;
								}
								else if (num191 == 11)
								{
									this.showItemIcon2 = 1141;
								}
								else if (num191 == 12)
								{
									this.showItemIcon2 = 1137;
								}
								else if (num191 == 13)
								{
									this.showItemIcon2 = 1138;
								}
								else if (num191 == 14)
								{
									this.showItemIcon2 = 1139;
								}
								else if (num191 == 15)
								{
									this.showItemIcon2 = 1140;
								}
								else if (num191 == 16)
								{
									this.showItemIcon2 = 1411;
								}
								else if (num191 == 17)
								{
									this.showItemIcon2 = 1412;
								}
								else if (num191 == 18)
								{
									this.showItemIcon2 = 1413;
								}
								else if (num191 == 19)
								{
									this.showItemIcon2 = 1458;
								}
								else if (num191 >= 20 && num191 <= 23)
								{
									this.showItemIcon2 = 1709 + num191 - 20;
								}
								else if (num191 == 24)
								{
									this.showItemIcon2 = 1793;
								}
								else if (num191 == 25)
								{
									this.showItemIcon2 = 1815;
								}
								else if (num191 >= 4 && num191 <= 8)
								{
									this.showItemIcon2 = 812 + num191;
								}
								else
								{
									this.showItemIcon2 = 649 + num191;
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
									int num192 = Player.tileTargetX;
									int num193 = Player.tileTargetY;
									bool flag44 = false;
									for (int num194 = 0; num194 < 58; num194++)
									{
										if (this.inventory[num194].type == 949 && this.inventory[num194].stack > 0)
										{
											this.inventory[num194].stack--;
											if (this.inventory[num194].stack <= 0)
											{
												this.inventory[num194].SetDefaults(0, false);
											}
											flag44 = true;
											break;
										}
									}
									if (flag44)
									{
										this.launcherWait = 10;
										Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 11);
										int num195 = (int)(Main.tile[num192, num193].frameX / 18);
										int num196 = 0;
										while (num195 >= 3)
										{
											num196++;
											num195 -= 3;
										}
										num195 = num192 - num195;
										int num197;
										for (num197 = (int)(Main.tile[num192, num193].frameY / 18); num197 >= 3; num197 -= 3)
										{
										}
										num197 = num193 - num197;
										float num198 = 12f + (float)Main.rand.Next(450) * 0.01f;
										float num199 = (float)Main.rand.Next(85, 105);
										float num200 = (float)Main.rand.Next(-35, 11);
										int type6 = 166;
										int damage2 = 17;
										float knockBack = 3.5f;
										Vector2 vector = new Vector2((float)((num195 + 2) * 16 - 8), (float)((num197 + 2) * 16 - 8));
										if (num196 == 0)
										{
											num199 *= -1f;
											vector.X -= 12f;
										}
										else
										{
											vector.X += 12f;
										}
										float num201 = num199;
										float num202 = num200;
										float num203 = (float)Math.Sqrt((double)(num201 * num201 + num202 * num202));
										num203 = num198 / num203;
										num201 *= num203;
										num202 *= num203;
										Projectile.NewProjectile(vector.X, vector.Y, num201, num202, type6, damage2, knockBack, Main.myPlayer, 0f, 0f);
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
										int num204 = Player.tileTargetX;
										int num205 = Player.tileTargetY;
										num204 += (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18 * -1);
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 72)
										{
											num204 += 4;
											num204++;
										}
										else
										{
											num204 += 2;
										}
										int num206 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
										int num207 = 0;
										while (num206 > 1)
										{
											num206 -= 2;
											num207++;
										}
										num205 -= num206;
										num205 += 2;
										if (Player.CheckSpawn(num204, num205))
										{
											this.ChangeSpawn(num204, num205);
											Main.NewText("Spawn point set!", 255, 240, 20, false);
										}
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 55 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 85)
									{
										bool flag45 = true;
										if (this.sign >= 0)
										{
											int num208 = Sign.ReadSign(Player.tileTargetX, Player.tileTargetY);
											if (num208 == this.sign)
											{
												this.sign = -1;
												Main.npcChatText = "";
												Main.editSign = false;
												Main.PlaySound(11, -1, -1, 1);
												flag45 = false;
											}
										}
										if (flag45)
										{
											if (Main.netMode == 0)
											{
												this.talkNPC = -1;
												Main.playerInventory = false;
												Main.editSign = false;
												Main.PlaySound(10, -1, -1, 1);
												int num209 = Sign.ReadSign(Player.tileTargetX, Player.tileTargetY);
												this.sign = num209;
												Main.npcChatText = Main.sign[num209].text;
											}
											else
											{
												int num210 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18);
												int num211 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
												while (num210 > 1)
												{
													num210 -= 2;
												}
												int num212 = Player.tileTargetX - num210;
												int num213 = Player.tileTargetY - num211;
												if (Main.tile[num212, num213].type == 55 || Main.tile[num212, num213].type == 85)
												{
													NetMessage.SendData(46, -1, -1, "", num212, (float)num213, 0f, 0f, 0);
												}
											}
										}
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 104)
									{
										string text = "AM";
										double num214 = Main.time;
										if (!Main.dayTime)
										{
											num214 += 54000.0;
										}
										num214 = num214 / 86400.0 * 24.0;
										double num215 = 7.5;
										num214 = num214 - num215 - 12.0;
										if (num214 < 0.0)
										{
											num214 += 24.0;
										}
										if (num214 >= 12.0)
										{
											text = "PM";
										}
										int num216 = (int)num214;
										double num217 = num214 - (double)num216;
										num217 = (double)((int)(num217 * 60.0));
										string text2 = string.Concat(num217);
										if (num217 < 10.0)
										{
											text2 = "0" + text2;
										}
										if (num216 > 12)
										{
											num216 -= 12;
										}
										if (num216 == 0)
										{
											num216 = 12;
										}
										string newText = string.Concat(new object[]
										{
											"Time: ",
											num216,
											":",
											text2,
											" ",
											text
										});
										Main.NewText(newText, 255, 240, 20, false);
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 237)
									{
										bool flag46 = false;
										if (!NPC.AnyNPCs(245))
										{
											for (int num218 = 0; num218 < 58; num218++)
											{
												if (this.inventory[num218].type == 1293)
												{
													this.inventory[num218].stack--;
													if (this.inventory[num218].stack <= 0)
													{
														this.inventory[num218].SetDefaults(0, false);
													}
													flag46 = true;
												}
											}
										}
										if (flag46)
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
										int num219 = Player.tileTargetX;
										int num220 = Player.tileTargetY;
										if (Main.tile[num219, num220].frameY >= 594 && Main.tile[num219, num220].frameY <= 646)
										{
											int num221 = 1141;
											for (int num222 = 0; num222 < 58; num222++)
											{
												if (this.inventory[num222].type == num221 && this.inventory[num222].stack > 0)
												{
													this.inventory[num222].stack--;
													if (this.inventory[num222].stack <= 0)
													{
														this.inventory[num222] = new Item();
													}
													WorldGen.UnlockDoor(num219, num220);
													if (Main.netMode == 1)
													{
														NetMessage.SendData(52, -1, -1, "", this.whoAmi, 2f, (float)num219, (float)num220, 0);
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
										int num223 = 0;
										int num224;
										for (num224 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18); num224 > 1; num224 -= 2)
										{
										}
										num224 = Player.tileTargetX - num224;
										int num225 = Player.tileTargetY - (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 29)
										{
											num223 = 1;
										}
										else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 97)
										{
											num223 = 2;
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
										if (Main.netMode == 1 && num223 == 0 && (Main.tile[num224, num225].frameX < 72 || Main.tile[num224, num225].frameX > 106) && (Main.tile[num224, num225].frameX < 144 || Main.tile[num224, num225].frameX > 178) && (Main.tile[num224, num225].frameX < 828 || Main.tile[num224, num225].frameX > 1006))
										{
											if (num224 == this.chestX && num225 == this.chestY && this.chest != -1)
											{
												this.chest = -1;
												Main.PlaySound(11, -1, -1, 1);
											}
											else
											{
												NetMessage.SendData(31, -1, -1, "", num224, (float)num225, 0f, 0f, 0);
											}
										}
										else
										{
											int num226 = -1;
											if (num223 == 1)
											{
												num226 = -2;
											}
											else if (num223 == 2)
											{
												num226 = -3;
											}
											else
											{
												bool flag47 = false;
												if ((Main.tile[num224, num225].frameX >= 72 && Main.tile[num224, num225].frameX <= 106) || (Main.tile[num224, num225].frameX >= 144 && Main.tile[num224, num225].frameX <= 178) || (Main.tile[num224, num225].frameX >= 828 && Main.tile[num224, num225].frameX <= 1006))
												{
													int num227 = 327;
													if (Main.tile[num224, num225].frameX >= 144 && Main.tile[num224, num225].frameX <= 178)
													{
														num227 = 329;
													}
													if (Main.tile[num224, num225].frameX >= 828 && Main.tile[num224, num225].frameX <= 1006)
													{
														int num228 = (int)(Main.tile[num224, num225].frameX / 18);
														int num229 = 0;
														while (num228 >= 2)
														{
															num228 -= 2;
															num229++;
														}
														num229 -= 23;
														num227 = 1533 + num229;
													}
													flag47 = true;
													for (int num230 = 0; num230 < 58; num230++)
													{
														if (this.inventory[num230].type == num227 && this.inventory[num230].stack > 0)
														{
															if (num227 != 329)
															{
																this.inventory[num230].stack--;
																if (this.inventory[num230].stack <= 0)
																{
																	this.inventory[num230] = new Item();
																}
															}
															Chest.Unlock(num224, num225);
															if (Main.netMode == 1)
															{
																NetMessage.SendData(52, -1, -1, "", this.whoAmi, 1f, (float)num224, (float)num225, 0);
															}
														}
													}
												}
												if (!flag47)
												{
													num226 = Chest.FindChest(num224, num225);
												}
											}
											if (num226 != -1)
											{
												if (num226 == this.chest)
												{
													this.chest = -1;
													Main.PlaySound(11, -1, -1, 1);
												}
												else if (num226 != this.chest && this.chest == -1)
												{
													this.chest = num226;
													Main.playerInventory = true;
													Main.PlaySound(10, -1, -1, 1);
													this.chestX = num224;
													this.chestY = num225;
												}
												else
												{
													this.chest = num226;
													Main.playerInventory = true;
													Main.PlaySound(12, -1, -1, 1);
													this.chestX = num224;
													this.chestY = num225;
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
						bool flag48 = false;
						if (Main.wof >= 0)
						{
							float num231 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2);
							num231 += (float)(Main.npc[Main.wof].direction * 200);
							float num232 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2);
							Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num233 = num231 - vector2.X;
							float num234 = num232 - vector2.Y;
							float num235 = (float)Math.Sqrt((double)(num233 * num233 + num234 * num234));
							float num236 = 11f;
							float num237;
							if (num235 > num236)
							{
								num237 = num236 / num235;
							}
							else
							{
								num237 = 1f;
								flag48 = true;
							}
							num233 *= num237;
							num234 *= num237;
							this.velocity.X = num233;
							this.velocity.Y = num234;
						}
						else
						{
							flag48 = true;
						}
						if (flag48 && Main.myPlayer == this.whoAmi)
						{
							for (int num238 = 0; num238 < 10; num238++)
							{
								if (this.buffType[num238] == 38)
								{
									this.DelBuff(num238);
								}
							}
						}
					}
					/*if (Main.myPlayer == this.whoAmi)
					{
						if (Main.wof >= 0 && Main.npc[Main.wof].active)
						{
							float num239 = Main.npc[Main.wof].position.X + 40f;
							if (Main.npc[Main.wof].direction > 0)
							{
								num239 -= 96f;
							}
							if (this.position.X + (float)this.width > num239 && this.position.X < num239 + 140f && this.gross)
							{
								this.noKnockback = false;
								this.Hurt(50, Main.npc[Main.wof].direction, false, false, " was slain...", false);
							}
							if (!this.gross && this.position.Y > (float)((Main.maxTilesY - 250) * 16) && this.position.X > num239 - 1920f && this.position.X < num239 + 1920f)
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
								for (int num240 = 0; num240 < 1000; num240++)
								{
									if (Main.projectile[num240].active && Main.projectile[num240].owner == Main.myPlayer && Main.projectile[num240].aiStyle == 7)
									{
										Main.projectile[num240].Kill();
									}
								}
								Vector2 vector3 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num241 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) - vector3.X;
								float num242 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2) - vector3.Y;
								float num243 = (float)Math.Sqrt((double)(num241 * num241 + num242 * num242));
								if (num243 > 3000f)
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
						if (Main.editSign)
						{
							if (this.sign == -1)
							{
								Main.editSign = false;
							}
							else
							{
								Main.npcChatText = Main.GetInputText(Main.npcChatText);
								if (Main.inputTextEnter)
								{
									byte[] bytes = new byte[]
									{
										10
									};
									Main.npcChatText += Encoding.ASCII.GetString(bytes);
								}
							}
						}
						if (!this.immune)
						{
							Rectangle rectangle3 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
							for (int num244 = 0; num244 < 200; num244++)
							{
								if (Main.npc[num244].active && !Main.npc[num244].friendly && Main.npc[num244].damage > 0 && rectangle3.Intersects(new Rectangle((int)Main.npc[num244].position.X, (int)Main.npc[num244].position.Y, Main.npc[num244].width, Main.npc[num244].height)))
								{
									int num245 = -1;
									if (Main.npc[num244].position.X + (float)(Main.npc[num244].width / 2) < this.position.X + (float)(this.width / 2))
									{
										num245 = 1;
									}
									int num246 = Main.DamageVar((float)Main.npc[num244].damage);
									if (this.whoAmi == Main.myPlayer && this.thorns && !this.immune && !Main.npc[num244].dontTakeDamage)
									{
										int num247 = num246 / 3;
										int num248 = 10;
										if (this.turtleThorns)
										{
											num247 = num246;
										}
										Main.npc[num244].StrikeNPC(num247, (float)num248, -num245, false, false);
										if (Main.netMode != 0)
										{
											NetMessage.SendData(28, -1, -1, "", num244, (float)num247, (float)num248, (float)(-(float)num245), 0);
										}
									}
									if (!this.immune)
									{
										if (Main.npc[num244].type >= 269 && Main.npc[num244].type <= 272)
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
										if (Main.npc[num244].type >= 273 && Main.npc[num244].type <= 276 && Main.rand.Next(2) == 0)
										{
											this.AddBuff(36, 600, true);
										}
										if (Main.npc[num244].type >= 277 && Main.npc[num244].type <= 280)
										{
											this.AddBuff(24, 600, true);
										}
										if (((Main.npc[num244].type == 1 && Main.npc[num244].name == "Black Slime") || Main.npc[num244].type == 81 || Main.npc[num244].type == 79) && Main.rand.Next(4) == 0)
										{
											this.AddBuff(22, 900, true);
										}
										if ((Main.npc[num244].type == 23 || Main.npc[num244].type == 25) && Main.rand.Next(3) == 0)
										{
											this.AddBuff(24, 420, true);
										}
										if ((Main.npc[num244].type == 34 || Main.npc[num244].type == 83 || Main.npc[num244].type == 84) && Main.rand.Next(3) == 0)
										{
											this.AddBuff(23, 240, true);
										}
										if ((Main.npc[num244].type == 104 || Main.npc[num244].type == 102) && Main.rand.Next(8) == 0)
										{
											this.AddBuff(30, 2700, true);
										}
										if (Main.npc[num244].type == 75 && Main.rand.Next(10) == 0)
										{
											this.AddBuff(35, 420, true);
										}
										if ((Main.npc[num244].type == 163 || Main.npc[num244].type == 238) && Main.rand.Next(10) == 0)
										{
											this.AddBuff(70, 480, true);
										}
										if ((Main.npc[num244].type == 79 || Main.npc[num244].type == 103) && Main.rand.Next(5) == 0)
										{
											this.AddBuff(35, 420, true);
										}
										if ((Main.npc[num244].type == 75 || Main.npc[num244].type == 78 || Main.npc[num244].type == 82) && Main.rand.Next(8) == 0)
										{
											this.AddBuff(32, 900, true);
										}
										if ((Main.npc[num244].type == 93 || Main.npc[num244].type == 109 || Main.npc[num244].type == 80) && Main.rand.Next(14) == 0)
										{
											this.AddBuff(31, 300, true);
										}
										if (Main.npc[num244].type >= 305 && Main.npc[num244].type <= 314 && Main.rand.Next(10) == 0)
										{
											this.AddBuff(33, 3600, true);
										}
										if (Main.npc[num244].type == 77 && Main.rand.Next(6) == 0)
										{
											this.AddBuff(36, 18000, true);
										}
										if (Main.npc[num244].type == 112 && Main.rand.Next(20) == 0)
										{
											this.AddBuff(33, 18000, true);
										}
										if (Main.npc[num244].type == 182 && Main.rand.Next(25) == 0)
										{
											this.AddBuff(33, 7200, true);
										}
										if (Main.npc[num244].type == 141 && Main.rand.Next(2) == 0)
										{
											this.AddBuff(20, 600, true);
										}
										if (Main.npc[num244].type == 147 && !Main.player[i].frozen && Main.rand.Next(12) == 0)
										{
											Main.player[i].AddBuff(46, 600, true);
										}
										if (Main.npc[num244].type == 150)
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
										if (Main.npc[num244].type == 184)
										{
											Main.player[i].AddBuff(46, 1200, true);
											if (!Main.player[i].frozen && Main.rand.Next(15) == 0)
											{
												Main.player[i].AddBuff(47, 60, true);
											}
										}
									}
									this.Hurt(num246, num245, false, false, Lang.deathMsg(-1, num244, -1, -1), false);
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
							int damage3 = Main.DamageVar(vector4.Y);
							this.Hurt(damage3, 0, false, false, Lang.deathMsg(-1, -1, -1, 3), false);
						}
					}*/
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
						this.wingTime = this.GetWingTime();
						this.rocketTime = this.rocketTimeMax;
						this.rocketDelay = 0;
						this.rocketFrame = false;
						this.canRocket = false;
						this.rocketRelease = false;
						this.fallStart = (int)(this.position.Y / 16f);
						float num249 = 0f;
						float num250 = 0f;
						for (int num251 = 0; num251 < this.grapCount; num251++)
						{
							num249 += Main.projectile[this.grappling[num251]].position.X + (float)(Main.projectile[this.grappling[num251]].width / 2);
							num250 += Main.projectile[this.grappling[num251]].position.Y + (float)(Main.projectile[this.grappling[num251]].height / 2);
						}
						num249 /= (float)this.grapCount;
						num250 /= (float)this.grapCount;
						Vector2 vector5 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num252 = num249 - vector5.X;
						float num253 = num250 - vector5.Y;
						float num254 = (float)Math.Sqrt((double)(num252 * num252 + num253 * num253));
						float num255 = 11f;
						if (Main.projectile[this.grappling[0]].type == 315)
						{
							num255 = 16f;
						}
						float num256;
						if (num254 > num255)
						{
							num256 = num255 / num254;
						}
						else
						{
							num256 = 1f;
						}
						num252 *= num256;
						num253 *= num256;
						this.velocity.X = num252;
						this.velocity.Y = num253;
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
								for (int num257 = 0; num257 < 1000; num257++)
								{
									if (Main.projectile[num257].active && Main.projectile[num257].owner == i && Main.projectile[num257].aiStyle == 7)
									{
										Main.projectile[num257].Kill();
									}
								}
							}
						}
						else
						{
							this.releaseJump = true;
						}
					}
					int num258 = this.width / 2;
					int num259 = this.height / 2;
					new Vector2(this.position.X + (float)(this.width / 2) - (float)(num258 / 2), this.position.Y + (float)(this.height / 2) - (float)(num259 / 2));
					Vector2 vector6 = Collision.StickyTiles(this.position, this.velocity, this.width, this.height);
					if (vector6.Y != -1f && vector6.X != -1f)
					{
						int num260 = (int)vector6.X;
						int num261 = (int)vector6.Y;
						int type7 = (int)Main.tile[num260, num261].type;
						if (this.whoAmi == Main.myPlayer && type7 == 51 && (this.velocity.X != 0f || this.velocity.Y != 0f))
						{
							this.stickyBreak++;
							if (this.stickyBreak > Main.rand.Next(20, 100))
							{
								this.stickyBreak = 0;
								WorldGen.KillTile(num260, num261, false, false, false);
								if (Main.netMode == 1 && !Main.tile[num260, num261].active() && Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 0, (float)num260, (float)num261, 0f, 0);
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
							if ((float)(num260 * 16) < this.position.X + (float)(this.width / 2))
							{
								int num262 = Dust.NewDust(new Vector2(this.position.X - 4f, (float)(num261 * 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
								Main.dust[num262].scale += (float)Main.rand.Next(0, 6) * 0.1f;
								Main.dust[num262].velocity *= 0.1f;
								Main.dust[num262].noGravity = true;
							}
							else
							{
								int num263 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 2f, (float)(num261 * 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
								Main.dust[num263].scale += (float)Main.rand.Next(0, 6) * 0.1f;
								Main.dust[num263].velocity *= 0.1f;
								Main.dust[num263].noGravity = true;
							}
							if (Main.tile[num260, num261 + 1] != null && Main.tile[num260, num261 + 1].type == 229 && this.position.Y + (float)this.height > (float)((num261 + 1) * 16))
							{
								if ((float)(num260 * 16) < this.position.X + (float)(this.width / 2))
								{
									int num264 = Dust.NewDust(new Vector2(this.position.X - 4f, (float)(num261 * 16 + 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num264].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num264].velocity *= 0.1f;
									Main.dust[num264].noGravity = true;
								}
								else
								{
									int num265 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 2f, (float)(num261 * 16 + 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num265].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num265].velocity *= 0.1f;
									Main.dust[num265].noGravity = true;
								}
							}
							if (Main.tile[num260, num261 + 2] != null && Main.tile[num260, num261 + 2].type == 229 && this.position.Y + (float)this.height > (float)((num261 + 2) * 16))
							{
								if ((float)(num260 * 16) < this.position.X + (float)(this.width / 2))
								{
									int num266 = Dust.NewDust(new Vector2(this.position.X - 4f, (float)(num261 * 16 + 32)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num266].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num266].velocity *= 0.1f;
									Main.dust[num266].noGravity = true;
								}
								else
								{
									int num267 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 2f, (float)(num261 * 16 + 32)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num267].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num267].velocity *= 0.1f;
									Main.dust[num267].noGravity = true;
								}
							}
						}
					}
					else
					{
						this.stickyBreak = 0;
					}
					bool flag49 = Collision.DrownCollision(this.position, this.width, this.height, this.gravDir);
					if (this.armor[0].type == 250)
					{
						flag49 = true;
					}
					if (this.inventory[this.selectedItem].type == 186)
					{
						try
						{
							int num268 = (int)((this.position.X + (float)(this.width / 2) + (float)(6 * this.direction)) / 16f);
							int num269 = 0;
							if (this.gravDir == -1f)
							{
								num269 = this.height;
							}
							int num270 = (int)((this.position.Y + (float)num269 - 44f * this.gravDir) / 16f);
							if (Main.tile[num268, num270].liquid < 128)
							{
								if (Main.tile[num268, num270] == null)
								{
									Main.tile[num268, num270] = new Tile();
								}
								if (!Main.tile[num268, num270].active() || !Main.tileSolid[(int)Main.tile[num268, num270].type] || Main.tileSolidTop[(int)Main.tile[num268, num270].type])
								{
									flag49 = false;
								}
							}
						}
						catch
						{
						}
					}
					if (this.gills)
					{
						flag49 = false;
					}
					if (Main.myPlayer == i)
					{
						if (this.merman)
						{
							flag49 = false;
						}
						if (flag49)
						{
							this.breathCD++;
							int num271 = 7;
							if (this.inventory[this.selectedItem].type == 186)
							{
								num271 *= 2;
							}
							if (this.accDivingHelm)
							{
								num271 *= 4;
							}
							if (this.breathCD >= num271)
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
					if (flag49 && Main.rand.Next(20) == 0 && !this.lavaWet && !this.honeyWet)
					{
						int num272 = 0;
						if (this.gravDir == -1f)
						{
							num272 += this.height - 12;
						}
						if (this.inventory[this.selectedItem].type == 186)
						{
							Dust.NewDust(new Vector2(this.position.X + (float)(10 * this.direction) + 4f, this.position.Y + (float)num272 - 54f * this.gravDir), this.width - 8, 8, 34, 0f, 0f, 0, default(Color), 1.2f);
						}
						else
						{
							Dust.NewDust(new Vector2(this.position.X + (float)(12 * this.direction), this.position.Y + (float)num272 + 4f * this.gravDir), this.width - 8, 8, 34, 0f, 0f, 0, default(Color), 1.2f);
						}
					}
					if (this.gravDir == -1f)
					{
						this.waterWalk = false;
						this.waterWalk2 = false;
					}
					int num273 = this.height;
					if (this.waterWalk)
					{
						num273 -= 6;
					}
					bool flag50 = Collision.LavaCollision(this.position, this.width, num273);
					if (flag50)
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
						num273 -= 6;
					}
					bool flag51 = Collision.WetCollision(this.position, this.width, this.height);
					if (Collision.honey)
					{
						this.AddBuff(48, 1800, true);
						this.honeyWet = true;
					}
					if (flag51)
					{
						if (this.onFire && !this.lavaWet)
						{
							for (int num274 = 0; num274 < 10; num274++)
							{
								if (this.buffType[num274] == 24)
								{
									this.DelBuff(num274);
								}
							}
						}
						if (!this.wet)
						{
							if (this.wetCount == 0)
							{
								this.wetCount = 10;
								if (!flag50)
								{
									if (this.honeyWet)
									{
										for (int num275 = 0; num275 < 20; num275++)
										{
											int num276 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 152, 0f, 0f, 0, default(Color), 1f);
											Dust expr_13A79_cp_0 = Main.dust[num276];
											expr_13A79_cp_0.velocity.Y = expr_13A79_cp_0.velocity.Y - 1f;
											Dust expr_13A99_cp_0 = Main.dust[num276];
											expr_13A99_cp_0.velocity.X = expr_13A99_cp_0.velocity.X * 2.5f;
											Main.dust[num276].scale = 1.3f;
											Main.dust[num276].alpha = 100;
											Main.dust[num276].noGravity = true;
										}
										Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
									}
									else
									{
										for (int num277 = 0; num277 < 50; num277++)
										{
											int num278 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, Dust.dustWater(), 0f, 0f, 0, default(Color), 1f);
											Dust expr_13B9A_cp_0 = Main.dust[num278];
											expr_13B9A_cp_0.velocity.Y = expr_13B9A_cp_0.velocity.Y - 3f;
											Dust expr_13BBA_cp_0 = Main.dust[num278];
											expr_13BBA_cp_0.velocity.X = expr_13BBA_cp_0.velocity.X * 2.5f;
											Main.dust[num278].scale = 0.8f;
											Main.dust[num278].alpha = 100;
											Main.dust[num278].noGravity = true;
										}
										Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
									}
								}
								else
								{
									for (int num279 = 0; num279 < 20; num279++)
									{
										int num280 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
										Dust expr_13CB8_cp_0 = Main.dust[num280];
										expr_13CB8_cp_0.velocity.Y = expr_13CB8_cp_0.velocity.Y - 1.5f;
										Dust expr_13CD8_cp_0 = Main.dust[num280];
										expr_13CD8_cp_0.velocity.X = expr_13CD8_cp_0.velocity.X * 2.5f;
										Main.dust[num280].scale = 1.3f;
										Main.dust[num280].alpha = 100;
										Main.dust[num280].noGravity = true;
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
									for (int num281 = 0; num281 < 20; num281++)
									{
										int num282 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 152, 0f, 0f, 0, default(Color), 1f);
										Dust expr_13E37_cp_0 = Main.dust[num282];
										expr_13E37_cp_0.velocity.Y = expr_13E37_cp_0.velocity.Y - 1f;
										Dust expr_13E57_cp_0 = Main.dust[num282];
										expr_13E57_cp_0.velocity.X = expr_13E57_cp_0.velocity.X * 2.5f;
										Main.dust[num282].scale = 1.3f;
										Main.dust[num282].alpha = 100;
										Main.dust[num282].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
								else
								{
									for (int num283 = 0; num283 < 50; num283++)
									{
										int num284 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2)), this.width + 12, 24, Dust.dustWater(), 0f, 0f, 0, default(Color), 1f);
										Dust expr_13F52_cp_0 = Main.dust[num284];
										expr_13F52_cp_0.velocity.Y = expr_13F52_cp_0.velocity.Y - 4f;
										Dust expr_13F72_cp_0 = Main.dust[num284];
										expr_13F72_cp_0.velocity.X = expr_13F72_cp_0.velocity.X * 2.5f;
										Main.dust[num284].scale = 0.8f;
										Main.dust[num284].alpha = 100;
										Main.dust[num284].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
								}
							}
							else
							{
								for (int num285 = 0; num285 < 20; num285++)
								{
									int num286 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
									Dust expr_14070_cp_0 = Main.dust[num286];
									expr_14070_cp_0.velocity.Y = expr_14070_cp_0.velocity.Y - 1.5f;
									Dust expr_14090_cp_0 = Main.dust[num286];
									expr_14090_cp_0.velocity.X = expr_14090_cp_0.velocity.X * 2.5f;
									Main.dust[num286].scale = 1.3f;
									Main.dust[num286].alpha = 100;
									Main.dust[num286].noGravity = true;
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
					float num287 = 1f + Math.Abs(this.velocity.X) / 3f;
					if (this.gfxOffY > 0f)
					{
						this.gfxOffY -= num287 * this.stepSpeed;
						if (this.gfxOffY < 0f)
						{
							this.gfxOffY = 0f;
						}
					}
					else if (this.gfxOffY < 0f)
					{
						this.gfxOffY += num287 * this.stepSpeed;
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
						int num288 = (int)(vector7.X / 16f);
						int num289 = (int)((vector7.X + (float)this.width) / 16f);
						int num290 = (int)((this.position.Y + (float)this.height + 1f) / 16f);
						for (int num291 = num288; num291 <= num289; num291++)
						{
							for (int num292 = num290; num292 <= num290 + 1; num292++)
							{
								if (Main.tile[num291, num292].nactive() && Main.tile[num291, num292].type == 162)
								{
									WorldGen.KillTile(num291, num292, false, false, false);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 0, (float)num291, (float)num292, 0f, 0);
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
						bool flag52 = false;
						int num293 = (int)(vector9.X / 16f);
						int num294 = (int)((vector9.X + (float)this.width) / 16f);
						int num295 = (int)((this.position.Y + (float)this.height + 4f) / 16f);
						float num296 = (float)((num295 + 3) * 16);
						for (int num297 = num293; num297 <= num294; num297++)
						{
							for (int num298 = num295; num298 <= num295 + 1; num298++)
							{
								if (Main.tile[num297, num298] == null)
								{
									Main.tile[num297, num298] = new Tile();
								}
								if (Main.tile[num297, num298].slope() != 0)
								{
									flag52 = true;
								}
								if (this.waterWalk2 || this.waterWalk)
								{
									if (Main.tile[num297, num298 - 1] == null)
									{
										Main.tile[num297, num298 - 1] = new Tile();
									}
									if (Main.tile[num297, num298].liquid > 0 && Main.tile[num297, num298 - 1].liquid == 0)
									{
										int num299 = (int)(Main.tile[num297, num298].liquid / 32 * 2 + 2);
										int num300 = num298 * 16 + 16 - num299;
										Rectangle rectangle4 = new Rectangle(num297 * 16, num298 * 16 - 17, 16, 16);
										if (rectangle4.Intersects(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height)) && (float)num300 < num296)
										{
											num296 = (float)num300;
										}
									}
								}
								if (Main.tile[num297, num298 - 1] == null)
								{
									Main.tile[num297, num298 - 1] = new Tile();
								}
								if (Main.tile[num297, num298].nactive() && (Main.tileSolid[(int)Main.tile[num297, num298].type] || Main.tileSolidTop[(int)Main.tile[num297, num298].type]))
								{
									int num301 = num298 * 16;
									if (Main.tile[num297, num298].halfBrick())
									{
										num301 += 8;
									}
									Rectangle rectangle5 = new Rectangle(num297 * 16, num298 * 16 - 17, 16, 16);
									if (rectangle5.Intersects(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height)) && (float)num301 < num296)
									{
										num296 = (float)num301;
									}
								}
							}
						}
						float num302 = num296 - (this.position.Y + (float)this.height);
						if (num302 > 7f && num302 < 17f && !flag52)
						{
							this.stepSpeed = 1.5f;
							if (num302 > 9f)
							{
								this.stepSpeed = 2.5f;
							}
							this.gfxOffY += this.position.Y + (float)this.height - num296;
							this.position.Y = num296 - (float)this.height;
						}
					}
					if (this.gravDir == -1f)
					{
						if ((this.carpetFrame != -1 || this.velocity.Y <= num2) && !this.controlUp)
						{
							int num303 = 0;
							if (this.velocity.X < 0f)
							{
								num303 = -1;
							}
							if (this.velocity.X > 0f)
							{
								num303 = 1;
							}
							Vector2 vector10 = this.position;
							vector10.X += this.velocity.X;
							int num304 = (int)((vector10.X + (float)(this.width / 2) + (float)((this.width / 2 + 1) * num303)) / 16f);
							int num305 = (int)(((double)vector10.Y + 0.1) / 16.0);
							if (Main.tile[num304, num305] == null)
							{
								Main.tile[num304, num305] = new Tile();
							}
							if (num305 - 1 > 0 && Main.tile[num304, num305 + 1] == null)
							{
								Main.tile[num304, num305 + 1] = new Tile();
							}
							if (num305 - 2 > 0 && Main.tile[num304, num305 + 2] == null)
							{
								Main.tile[num304, num305 + 2] = new Tile();
							}
							if (num305 - 3 > 0 && Main.tile[num304, num305 + 3] == null)
							{
								Main.tile[num304, num305 + 3] = new Tile();
							}
							if (num305 - 4 > 0 && Main.tile[num304, num305 + 4] == null)
							{
								Main.tile[num304, num305 + 4] = new Tile();
							}
							if (num305 - 3 > 0 && Main.tile[num304 - num303, num305 + 3] == null)
							{
								Main.tile[num304 - num303, num305 + 3] = new Tile();
							}
							if ((float)(num304 * 16) < vector10.X + (float)this.width && (float)(num304 * 16 + 16) > vector10.X && ((Main.tile[num304, num305].nactive() && ((Main.tileSolid[(int)Main.tile[num304, num305].type] && !Main.tileSolidTop[(int)Main.tile[num304, num305].type]) || (this.controlUp && Main.tileSolidTop[(int)Main.tile[num304, num305].type] && Main.tile[num304, num305].frameY == 0 && (!Main.tileSolid[(int)Main.tile[num304, num305 + 1].type] || !Main.tile[num304, num305 + 1].nactive())))) || (Main.tile[num304, num305 + 1].halfBrick() && Main.tile[num304, num305 + 1].nactive())) && (!Main.tile[num304, num305 + 1].nactive() || !Main.tileSolid[(int)Main.tile[num304, num305 + 1].type] || Main.tileSolidTop[(int)Main.tile[num304, num305 + 1].type] || Main.tile[num304, num305 + 1].slope() != 0 || (Main.tile[num304, num305 + 1].halfBrick() && (!Main.tile[num304, num305 + 4].nactive() || !Main.tileSolid[(int)Main.tile[num304, num305 + 4].type] || Main.tileSolidTop[(int)Main.tile[num304, num305 + 4].type]))) && (!Main.tile[num304, num305 + 2].nactive() || !Main.tileSolid[(int)Main.tile[num304, num305 + 2].type] || Main.tileSolidTop[(int)Main.tile[num304, num305 + 2].type]) && (!Main.tile[num304, num305 + 3].nactive() || !Main.tileSolid[(int)Main.tile[num304, num305 + 3].type] || Main.tileSolidTop[(int)Main.tile[num304, num305 + 3].type]) && (!Main.tile[num304 - num303, num305 + 3].nactive() || !Main.tileSolid[(int)Main.tile[num304 - num303, num305 + 3].type] || Main.tileSolidTop[(int)Main.tile[num304 - num303, num305 + 3].type]))
							{
								float num306 = (float)(num305 * 16 + 16);
								if (num306 > vector10.Y)
								{
									float num307 = num306 - vector10.Y;
									if ((double)num307 <= 16.1)
									{
										this.gfxOffY -= num306 - this.position.Y;
										this.position.Y = num306;
										this.velocity.Y = 0f;
										if (num307 < 9f)
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
						int num308 = 0;
						if (this.velocity.X < 0f)
						{
							num308 = -1;
						}
						if (this.velocity.X > 0f)
						{
							num308 = 1;
						}
						Vector2 vector11 = this.position;
						vector11.X += this.velocity.X;
						int num309 = (int)((vector11.X + (float)(this.width / 2) + (float)((this.width / 2 + 1) * num308)) / 16f);
						int num310 = (int)((vector11.Y + (float)this.height - 1f) / 16f);
						if (Main.tile[num309, num310] == null)
						{
							Main.tile[num309, num310] = new Tile();
						}
						if (num310 - 1 > 0 && Main.tile[num309, num310 - 1] == null)
						{
							Main.tile[num309, num310 - 1] = new Tile();
						}
						if (num310 - 2 > 0 && Main.tile[num309, num310 - 2] == null)
						{
							Main.tile[num309, num310 - 2] = new Tile();
						}
						if (num310 - 3 > 0 && Main.tile[num309, num310 - 3] == null)
						{
							Main.tile[num309, num310 - 3] = new Tile();
						}
						if (num310 - 4 > 0 && Main.tile[num309, num310 - 4] == null)
						{
							Main.tile[num309, num310 - 4] = new Tile();
						}
						if (num310 - 3 > 0 && Main.tile[num309 - num308, num310 - 3] == null)
						{
							Main.tile[num309 - num308, num310 - 3] = new Tile();
						}
						if ((float)(num309 * 16) < vector11.X + (float)this.width && (float)(num309 * 16 + 16) > vector11.X && ((Main.tile[num309, num310].nactive() && (Main.tile[num309, num310].slope() == 0 || (Main.tile[num309, num310].slope() == 1 && this.position.X + (float)(this.width / 2) < (float)(num309 * 16)) || (Main.tile[num309, num310].slope() == 2 && this.position.X + (float)(this.width / 2) > (float)(num309 * 16 + 16))) && (Main.tile[num309, num310 - 1].slope() == 0 || this.position.Y + (float)this.height > (float)(num310 * 16)) && ((Main.tileSolid[(int)Main.tile[num309, num310].type] && !Main.tileSolidTop[(int)Main.tile[num309, num310].type]) || (this.controlUp && Main.tileSolidTop[(int)Main.tile[num309, num310].type] && Main.tile[num309, num310].frameY == 0 && (!Main.tileSolid[(int)Main.tile[num309, num310 - 1].type] || !Main.tile[num309, num310 - 1].nactive())))) || (Main.tile[num309, num310 - 1].halfBrick() && Main.tile[num309, num310 - 1].nactive())) && (!Main.tile[num309, num310 - 1].nactive() || !Main.tileSolid[(int)Main.tile[num309, num310 - 1].type] || Main.tileSolidTop[(int)Main.tile[num309, num310 - 1].type] || (Main.tile[num309, num310 - 1].slope() == 1 && this.position.X + (float)(this.width / 2) > (float)(num309 * 16)) || (Main.tile[num309, num310 - 1].slope() == 2 && this.position.X + (float)(this.width / 2) < (float)(num309 * 16 + 16)) || (Main.tile[num309, num310 - 1].halfBrick() && (!Main.tile[num309, num310 - 4].nactive() || !Main.tileSolid[(int)Main.tile[num309, num310 - 4].type] || Main.tileSolidTop[(int)Main.tile[num309, num310 - 4].type]))) && (!Main.tile[num309, num310 - 2].nactive() || !Main.tileSolid[(int)Main.tile[num309, num310 - 2].type] || Main.tileSolidTop[(int)Main.tile[num309, num310 - 2].type]) && (!Main.tile[num309, num310 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num309, num310 - 3].type] || Main.tileSolidTop[(int)Main.tile[num309, num310 - 3].type]) && (!Main.tile[num309 - num308, num310 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num309 - num308, num310 - 3].type] || Main.tileSolidTop[(int)Main.tile[num309 - num308, num310 - 3].type]))
						{
							float num311 = (float)(num310 * 16);
							if (Main.tile[num309, num310].halfBrick())
							{
								num311 += 8f;
							}
							if (Main.tile[num309, num310 - 1].halfBrick())
							{
								num311 -= 8f;
							}
							if (num311 < vector11.Y + (float)this.height)
							{
								float num312 = vector11.Y + (float)this.height - num311;
								if ((double)num312 <= 16.1)
								{
									this.gfxOffY += this.position.Y + (float)this.height - num311;
									this.position.Y = num311 - (float)this.height;
									if (num312 < 9f)
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
					bool flag53 = false;
					if (this.velocity.Y > num2)
					{
						flag53 = true;
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
						int num313 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
						int num314 = (int)((this.position.Y + (float)this.height) / 16f);
						int num315 = -1;
						if (Main.tile[num313 - 1, num314] == null)
						{
							Main.tile[num313 - 1, num314] = new Tile();
						}
						if (Main.tile[num313 + 1, num314] == null)
						{
							Main.tile[num313 + 1, num314] = new Tile();
						}
						if (Main.tile[num313, num314] == null)
						{
							Main.tile[num313, num314] = new Tile();
						}
						if (Main.tile[num313, num314].nactive() && Main.tileSolid[(int)Main.tile[num313, num314].type])
						{
							num315 = (int)Main.tile[num313, num314].type;
						}
						else if (Main.tile[num313 - 1, num314].nactive() && Main.tileSolid[(int)Main.tile[num313 - 1, num314].type])
						{
							num315 = (int)Main.tile[num313 - 1, num314].type;
						}
						else if (Main.tile[num313 + 1, num314].nactive() && Main.tileSolid[(int)Main.tile[num313 + 1, num314].type])
						{
							num315 = (int)Main.tile[num313 + 1, num314].type;
						}
						if (num315 > -1)
						{
							if (num315 == 229)
							{
								this.sticky = true;
							}
							else
							{
								this.sticky = false;
							}
							if (num315 == 161 || num315 == 162 || num315 == 163 || num315 == 164 || num315 == 200)
							{
								this.slippy = true;
							}
							else
							{
								this.slippy = false;
							}
							if (num315 == 197)
							{
								this.slippy2 = true;
							}
							else
							{
								this.slippy2 = false;
							}
							if (num315 == 198)
							{
								this.powerrun = true;
							}
							else
							{
								this.powerrun = false;
							}
							if (Main.tile[num313 - 1, num314].slope() != 0 || Main.tile[num313, num314].slope() != 0 || Main.tile[num313 + 1, num314].slope() != 0)
							{
								num315 = -1;
							}
							if (!this.wet && (num315 == 147 || num315 == 25 || num315 == 53 || num315 == 189 || num315 == 0 || num315 == 123 || num315 == 57 || num315 == 112 || num315 == 116 || num315 == 196 || num315 == 193 || num315 == 195 || num315 == 197 || num315 == 199 || num315 == 229))
							{
								int num316 = 1;
								if (flag53)
								{
									num316 = 20;
								}
								for (int num317 = 0; num317 < num316; num317++)
								{
									bool flag54 = true;
									int num318 = 76;
									if (num315 == 53)
									{
										num318 = 32;
									}
									if (num315 == 189)
									{
										num318 = 16;
									}
									if (num315 == 0)
									{
										num318 = 0;
									}
									if (num315 == 123)
									{
										num318 = 53;
									}
									if (num315 == 57)
									{
										num318 = 36;
									}
									if (num315 == 112)
									{
										num318 = 14;
									}
									if (num315 == 116)
									{
										num318 = 51;
									}
									if (num315 == 196)
									{
										num318 = 108;
									}
									if (num315 == 193)
									{
										num318 = 4;
									}
									if (num315 == 195 || num315 == 199)
									{
										num318 = 5;
									}
									if (num315 == 197)
									{
										num318 = 4;
									}
									if (num315 == 229)
									{
										num318 = 153;
									}
									if (num315 == 25)
									{
										num318 = 37;
									}
									if (num318 == 32 && Main.rand.Next(2) == 0)
									{
										flag54 = false;
									}
									if (num318 == 14 && Main.rand.Next(2) == 0)
									{
										flag54 = false;
									}
									if (num318 == 51 && Main.rand.Next(2) == 0)
									{
										flag54 = false;
									}
									if (num318 == 36 && Main.rand.Next(2) == 0)
									{
										flag54 = false;
									}
									if (num318 == 0 && Main.rand.Next(3) != 0)
									{
										flag54 = false;
									}
									if (num318 == 53 && Main.rand.Next(3) != 0)
									{
										flag54 = false;
									}
									Color newColor = default(Color);
									if (num315 == 193)
									{
										newColor = new Color(30, 100, 255, 100);
									}
									if (num315 == 197)
									{
										newColor = new Color(97, 200, 255, 100);
									}
									if (!flag53)
									{
										float num319 = Math.Abs(this.velocity.X) / 3f;
										if ((float)Main.rand.Next(100) > num319 * 100f)
										{
											flag54 = false;
										}
									}
									if (flag54)
									{
										float num320 = this.velocity.X;
										if (num320 > 6f)
										{
											num320 = 6f;
										}
										if (num320 < -6f)
										{
											num320 = -6f;
										}
										if (this.velocity.X != 0f || flag53)
										{
											int num321 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), this.width, 6, num318, 0f, 0f, 50, newColor, 1f);
											if (num318 == 76)
											{
												Main.dust[num321].scale += (float)Main.rand.Next(3) * 0.1f;
												Main.dust[num321].noLight = true;
											}
											if (num318 == 16 || num318 == 108 || num318 == 153)
											{
												Main.dust[num321].scale += (float)Main.rand.Next(6) * 0.1f;
											}
											if (num318 == 37)
											{
												Main.dust[num321].scale += 0.25f;
												Main.dust[num321].alpha = 50;
											}
											if (num318 == 5)
											{
												Main.dust[num321].scale += (float)Main.rand.Next(2, 8) * 0.1f;
											}
											Main.dust[num321].noGravity = true;
											if (num316 > 1)
											{
												Dust expr_1623B_cp_0 = Main.dust[num321];
												expr_1623B_cp_0.velocity.X = expr_1623B_cp_0.velocity.X * 1.2f;
												Dust expr_1625B_cp_0 = Main.dust[num321];
												expr_1625B_cp_0.velocity.Y = expr_1625B_cp_0.velocity.Y * 0.8f;
												Dust expr_1627B_cp_0 = Main.dust[num321];
												expr_1627B_cp_0.velocity.Y = expr_1627B_cp_0.velocity.Y - 1f;
												Main.dust[num321].velocity *= 0.8f;
												Main.dust[num321].scale += (float)Main.rand.Next(3) * 0.1f;
												Main.dust[num321].velocity.X = (Main.dust[num321].position.X - (this.position.X + (float)(this.width / 2))) * 0.2f;
												if (Main.dust[num321].velocity.Y > 0f)
												{
													Dust expr_16341_cp_0 = Main.dust[num321];
													expr_16341_cp_0.velocity.Y = expr_16341_cp_0.velocity.Y * -1f;
												}
												Dust expr_16361_cp_0 = Main.dust[num321];
												expr_16361_cp_0.velocity.X = expr_16361_cp_0.velocity.X + num320 * 0.3f;
											}
											else
											{
												Main.dust[num321].velocity *= 0.2f;
											}
											Dust expr_163A7_cp_0 = Main.dust[num321];
											expr_163A7_cp_0.position.X = expr_163A7_cp_0.position.X - num320 * 1f;
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
							goto IL_1658B;
						}
						catch
						{
							goto IL_1658B;
						}
					}
					this.ItemCheck(i);
					IL_1658B:
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
					if (this.velocity.Y > 0f)
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
			if (this.swimTime > 0)
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
			this.grappling[0] = -1;
			Main.TeleportEffect(this.getRect(), Style);
			this.position = newPos;
			if (this.whoAmi == Main.myPlayer)
			{
				Main.BlackFadeIn = 255;
				//Lighting.BlackOut();
				Main.screenLastPosition = Main.screenPosition;
				Main.screenPosition.X = this.position.X + (float)(this.width / 2) - (float)(Main.screenWidth / 2);
				Main.screenPosition.Y = this.position.Y + (float)(this.height / 2) - (float)(Main.screenHeight / 2);
				/*if (Main.mapTime < 5)
				{
					Main.mapTime = 5;
				}*/
				Main.quickBG = 10;
				Main.maxQ = true;
				Main.renderNow = true;
			}
			this.fallStart = (int)(this.position.Y / 16f);
			Main.TeleportEffect(this.getRect(), Style);
			this.teleportTime = 1f;
			this.teleportStyle = Style;
		}
		public void Spawn()
		{
			if (this.whoAmi == Main.myPlayer)
			{
				/*if (Main.mapTime < 5)
				{
					Main.mapTime = 5;
				}*/
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
				/*if (Main.netMode == 1)
				{
					Netplay.newRecent();
				}*/
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
				for (int i = 0; i < 9; i++)
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
					//Main.mapFullscreen = false;
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
						//Main.mapFullscreen = false;
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
			if (this.whoAmi == Main.myPlayer)
			{
				try
				{
					//WorldGen.saveToonWhilePlaying();
				}
				catch
				{
				}
			}
		}
		public bool ItemSpace(Item newItem)
		{
			if (newItem.type == 58 || newItem.type == 184 || newItem.type == 1734 || newItem.type == 1735)
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
					int num25 = 1;
					int num26;
					if (Main.rand.Next(5000) == 0)
					{
						num26 = 1242;
					}
					else if (Main.rand.Next(25) == 0)
					{
						num26 = Main.rand.Next(6);
						if (num26 == 0)
						{
							num26 = 181;
						}
						else if (num26 == 1)
						{
							num26 = 180;
						}
						else if (num26 == 2)
						{
							num26 = 177;
						}
						else if (num26 == 3)
						{
							num26 = 179;
						}
						else if (num26 == 4)
						{
							num26 = 178;
						}
						else
						{
							num26 = 182;
						}
						if (Main.rand.Next(20) == 0)
						{
							num25 += Main.rand.Next(0, 2);
						}
						if (Main.rand.Next(30) == 0)
						{
							num25 += Main.rand.Next(0, 3);
						}
						if (Main.rand.Next(40) == 0)
						{
							num25 += Main.rand.Next(0, 4);
						}
						if (Main.rand.Next(50) == 0)
						{
							num25 += Main.rand.Next(0, 5);
						}
						if (Main.rand.Next(60) == 0)
						{
							num25 += Main.rand.Next(0, 6);
						}
					}
					else if (Main.rand.Next(50) == 0)
					{
						num26 = 999;
						if (Main.rand.Next(20) == 0)
						{
							num25 += Main.rand.Next(0, 2);
						}
						if (Main.rand.Next(30) == 0)
						{
							num25 += Main.rand.Next(0, 3);
						}
						if (Main.rand.Next(40) == 0)
						{
							num25 += Main.rand.Next(0, 4);
						}
						if (Main.rand.Next(50) == 0)
						{
							num25 += Main.rand.Next(0, 5);
						}
						if (Main.rand.Next(60) == 0)
						{
							num25 += Main.rand.Next(0, 6);
						}
					}
					else if (Main.rand.Next(3) == 0)
					{
						if (Main.rand.Next(5000) == 0)
						{
							num26 = 74;
							if (Main.rand.Next(10) == 0)
							{
								num25 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(10) == 0)
							{
								num25 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(10) == 0)
							{
								num25 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(10) == 0)
							{
								num25 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(10) == 0)
							{
								num25 += Main.rand.Next(0, 3);
							}
						}
						else if (Main.rand.Next(400) == 0)
						{
							num26 = 73;
							if (Main.rand.Next(5) == 0)
							{
								num25 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(5) == 0)
							{
								num25 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(5) == 0)
							{
								num25 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(5) == 0)
							{
								num25 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(5) == 0)
							{
								num25 += Main.rand.Next(1, 20);
							}
						}
						else if (Main.rand.Next(30) == 0)
						{
							num26 = 72;
							if (Main.rand.Next(3) == 0)
							{
								num25 += Main.rand.Next(5, 26);
							}
							if (Main.rand.Next(3) == 0)
							{
								num25 += Main.rand.Next(5, 26);
							}
							if (Main.rand.Next(3) == 0)
							{
								num25 += Main.rand.Next(5, 26);
							}
							if (Main.rand.Next(3) == 0)
							{
								num25 += Main.rand.Next(5, 25);
							}
						}
						else
						{
							num26 = 71;
							if (Main.rand.Next(2) == 0)
							{
								num25 += Main.rand.Next(10, 26);
							}
							if (Main.rand.Next(2) == 0)
							{
								num25 += Main.rand.Next(10, 26);
							}
							if (Main.rand.Next(2) == 0)
							{
								num25 += Main.rand.Next(10, 26);
							}
							if (Main.rand.Next(2) == 0)
							{
								num25 += Main.rand.Next(10, 25);
							}
						}
					}
					else
					{
						num26 = Main.rand.Next(8);
						if (num26 == 0)
						{
							num26 = 12;
						}
						else if (num26 == 1)
						{
							num26 = 11;
						}
						else if (num26 == 2)
						{
							num26 = 14;
						}
						else if (num26 == 3)
						{
							num26 = 13;
						}
						else if (num26 == 4)
						{
							num26 = 699;
						}
						else if (num26 == 5)
						{
							num26 = 700;
						}
						else if (num26 == 6)
						{
							num26 = 701;
						}
						else
						{
							num26 = 702;
						}
						if (Main.rand.Next(20) == 0)
						{
							num25 += Main.rand.Next(0, 2);
						}
						if (Main.rand.Next(30) == 0)
						{
							num25 += Main.rand.Next(0, 3);
						}
						if (Main.rand.Next(40) == 0)
						{
							num25 += Main.rand.Next(0, 4);
						}
						if (Main.rand.Next(50) == 0)
						{
							num25 += Main.rand.Next(0, 5);
						}
						if (Main.rand.Next(60) == 0)
						{
							num25 += Main.rand.Next(0, 6);
						}
					}
					if (num26 > 0)
					{
						int number = Item.NewItem((int)Main.screenPosition.X + Main.mouseX, (int)Main.screenPosition.Y + Main.mouseY, 1, 1, num26, num25, false, -1, false);
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
					int num27 = Player.tileTargetY;
					int num28 = Player.tileTargetX;
					int createTile = this.inventory[this.selectedItem].createTile;
					while (Main.tile[num28, num27].active() && (int)Main.tile[num28, num27].type == createTile && num27 < Main.maxTilesX - 5)
					{
						num27++;
						if (Main.tile[num28, num27] == null)
						{
							flag2 = false;
							num27 = Player.tileTargetY;
						}
					}
					if (!Main.tile[num28, num27].active())
					{
						Player.tileTargetY = num27;
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
							int num29 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type;
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].halfBrick())
							{
								num29 = -1;
							}
							int num30 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type;
							int num31 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type;
							int num32 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
							int num33 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].type;
							int num34 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
							int num35 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].type;
							if (!Main.tile[Player.tileTargetX, Player.tileTargetY + 1].nactive())
							{
								num29 = -1;
							}
							if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY].nactive())
							{
								num30 = -1;
							}
							if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY].nactive())
							{
								num31 = -1;
							}
							if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].nactive())
							{
								num32 = -1;
							}
							if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].nactive())
							{
								num33 = -1;
							}
							if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY + 1].nactive())
							{
								num34 = -1;
							}
							if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].nactive())
							{
								num35 = -1;
							}
							if (num29 >= 0 && Main.tileSolid[num29] && !Main.tileNoAttach[num29])
							{
								flag3 = true;
							}
							else if ((num30 >= 0 && Main.tileSolid[num30] && !Main.tileNoAttach[num30]) || (num30 == 5 && num32 == 5 && num34 == 5) || num30 == 124)
							{
								flag3 = true;
							}
							else if ((num31 >= 0 && Main.tileSolid[num31] && !Main.tileNoAttach[num31]) || (num31 == 5 && num33 == 5 && num35 == 5) || num31 == 124)
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
						int num36 = this.inventory[this.selectedItem].placeStyle;
						if (this.inventory[this.selectedItem].createTile == 212 && this.direction > 0)
						{
							num36 = 1;
						}
						if (this.inventory[this.selectedItem].createTile == 141)
						{
							num36 = Main.rand.Next(2);
						}
						if (this.inventory[this.selectedItem].createTile == 128)
						{
							if (this.direction < 0)
							{
								num36 = -1;
							}
							else
							{
								num36 = 1;
							}
						}
						if (this.inventory[this.selectedItem].createTile == 241 && this.inventory[this.selectedItem].placeStyle == 0)
						{
							num36 = Main.rand.Next(0, 9);
						}
						if (this.inventory[this.selectedItem].createTile == 35 && this.inventory[this.selectedItem].placeStyle == 0)
						{
							num36 = Main.rand.Next(9);
						}
						if (WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createTile, false, false, this.whoAmi, num36))
						{
							this.itemTime = this.inventory[this.selectedItem].useTime;
							if (Main.netMode == 1)
							{
								NetMessage.SendData(17, -1, -1, "", 1, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.inventory[this.selectedItem].createTile, num36);
							}
							if (this.inventory[this.selectedItem].createTile == 15)
							{
								if (this.direction == 1)
								{
									Tile expr_25BC = Main.tile[Player.tileTargetX, Player.tileTargetY];
									expr_25BC.frameX += 18;
									Tile expr_25E1 = Main.tile[Player.tileTargetX, Player.tileTargetY - 1];
									expr_25E1.frameX += 18;
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
									Tile expr_264B = Main.tile[Player.tileTargetX, Player.tileTargetY];
									expr_264B.frameX += 18;
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
								int num37 = Player.tileTargetX;
								int num38 = Player.tileTargetY + 1;
								if (Main.tile[num37, num38] != null && (Main.tile[num37, num38].slope() != 0 || Main.tile[num37, num38].halfBrick()))
								{
									WorldGen.SlopeTile(num37, num38, 0);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 14, (float)num37, (float)num38, 0f, 0);
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
								int num39 = Player.tileTargetX;
								int num40 = Player.tileTargetY;
								if (n == 0)
								{
									num39--;
								}
								if (n == 1)
								{
									num39++;
								}
								if (n == 2)
								{
									num40--;
								}
								if (n == 3)
								{
									num40++;
								}
								if (Main.tile[num39, num40].wall == 0)
								{
									int num41 = 0;
									for (int num42 = 0; num42 < 4; num42++)
									{
										int num43 = num39;
										int num44 = num40;
										if (num42 == 0)
										{
											num43--;
										}
										if (num42 == 1)
										{
											num43++;
										}
										if (num42 == 2)
										{
											num44--;
										}
										if (num42 == 3)
										{
											num44++;
										}
										if ((int)Main.tile[num43, num44].wall == createWall)
										{
											num41++;
										}
									}
									if (num41 == 4)
									{
										WorldGen.PlaceWall(num39, num40, createWall, false);
										if ((int)Main.tile[num39, num40].wall == createWall)
										{
											this.inventory[this.selectedItem].stack--;
											if (this.inventory[this.selectedItem].stack == 0)
											{
												this.inventory[this.selectedItem].SetDefaults(0, false);
											}
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 3, (float)num39, (float)num40, (float)createWall, 0);
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
				if (this.inventory[this.selectedItem].shoot == 6 || this.inventory[this.selectedItem].shoot == 19 || this.inventory[this.selectedItem].shoot == 33 || this.inventory[this.selectedItem].shoot == 52 || this.inventory[this.selectedItem].shoot == 113 || this.inventory[this.selectedItem].shoot == 182 || this.inventory[this.selectedItem].shoot == 320)
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
				if (this.inventory[this.selectedItem].shoot == 13 || this.inventory[this.selectedItem].shoot == 32 || (this.inventory[this.selectedItem].shoot >= 230 && this.inventory[this.selectedItem].shoot <= 235) || this.inventory[this.selectedItem].shoot == 315)
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
				bool arg_1954_0 = this.channel;
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
				if (Main.dedServ)
				{
					this.itemHeight = this.inventory[this.selectedItem].height;
					this.itemWidth = this.inventory[this.selectedItem].width;
				}
				else
				{
					//this.itemHeight = Main.itemTexture[this.inventory[this.selectedItem].type].Height;
					//this.itemWidth = Main.itemTexture[this.inventory[this.selectedItem].type].Width;
				}
				this.itemAnimation--;
				/*if (!Main.dedServ)
				{
					if (this.inventory[this.selectedItem].useStyle == 1)
					{
						if (this.inventory[this.selectedItem].type == 1827)
						{
							if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
							{
								float num19 = 10f;
								this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num19) * (float)this.direction;
								this.itemLocation.Y = this.position.Y + 26f;
							}
							else if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.666)
							{
								float num20 = 8f;
								this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num20) * (float)this.direction;
								num20 = 24f;
								this.itemLocation.Y = this.position.Y + num20;
							}
							else
							{
								float num21 = 6f;
								this.itemLocation.X = this.position.X + (float)this.width * 0.5f - ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num21) * (float)this.direction;
								num21 = 20f;
								this.itemLocation.Y = this.position.Y + num21;
							}
							this.itemRotation = ((float)this.itemAnimation / (float)this.itemAnimationMax - 0.5f) * (float)(-(float)this.direction) * 3.5f - (float)this.direction * 0.3f;
						}
						else
						{
							if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
							{
								float num22 = 10f;
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
								{
									num22 = 14f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 52)
								{
									num22 = 24f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 64)
								{
									num22 = 28f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 92)
								{
									num22 = 38f;
								}
								this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num22) * (float)this.direction;
								this.itemLocation.Y = this.position.Y + 24f;
							}
							else if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.666)
							{
								float num23 = 10f;
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
								{
									num23 = 18f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 52)
								{
									num23 = 24f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 64)
								{
									num23 = 28f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 92)
								{
									num23 = 38f;
								}
								this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num23) * (float)this.direction;
								num23 = 10f;
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 32)
								{
									num23 = 8f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Height >= 32)
								{
									num23 = 12f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 64)
								{
									num23 = 14f;
								}
								this.itemLocation.Y = this.position.Y + num23;
							}
							else
							{
								float num24 = 6f;
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
								{
									num24 = 14f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 52)
								{
									num24 = 24f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 64)
								{
									num24 = 28f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 92)
								{
									num24 = 38f;
								}
								this.itemLocation.X = this.position.X + (float)this.width * 0.5f - ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num24) * (float)this.direction;
								num24 = 10f;
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 32)
								{
									num24 = 10f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 52)
								{
									num24 = 12f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 64)
								{
									num24 = 14f;
								}
								this.itemLocation.Y = this.position.Y + num24;
							}
							this.itemRotation = ((float)this.itemAnimation / (float)this.itemAnimationMax - 0.5f) * (float)(-(float)this.direction) * 3.5f - (float)this.direction * 0.3f;
						}
						if (this.gravDir == -1f)
						{
							this.itemRotation = -this.itemRotation;
							this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
						}
					}
					else if (this.inventory[this.selectedItem].useStyle == 2)
					{
						this.itemRotation = (float)this.itemAnimation / (float)this.itemAnimationMax * (float)this.direction * 2f + -1.4f * (float)this.direction;
						if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.5)
						{
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - 9f - this.itemRotation * 12f * (float)this.direction) * (float)this.direction;
							this.itemLocation.Y = this.position.Y + 38f + this.itemRotation * (float)this.direction * 4f;
						}
						else
						{
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - 9f - this.itemRotation * 16f * (float)this.direction) * (float)this.direction;
							this.itemLocation.Y = this.position.Y + 38f + this.itemRotation * (float)this.direction;
						}
						if (this.gravDir == -1f)
						{
							this.itemRotation = -this.itemRotation;
							this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
						}
					}
					else if (this.inventory[this.selectedItem].useStyle == 3)
					{
						if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.666)
						{
							this.itemLocation.X = -1000f;
							this.itemLocation.Y = -1000f;
							this.itemRotation = -1.3f * (float)this.direction;
						}
						else
						{
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - 4f) * (float)this.direction;
							this.itemLocation.Y = this.position.Y + 24f;
							float num25 = (float)this.itemAnimation / (float)this.itemAnimationMax * (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * (float)this.direction * this.inventory[this.selectedItem].scale * 1.2f - (float)(10 * this.direction);
							if (num25 > -4f && this.direction == -1)
							{
								num25 = -8f;
							}
							if (num25 < 4f && this.direction == 1)
							{
								num25 = 8f;
							}
							this.itemLocation.X = this.itemLocation.X - num25;
							this.itemRotation = 0.8f * (float)this.direction;
						}
						if (this.gravDir == -1f)
						{
							this.itemRotation = -this.itemRotation;
							this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
						}
					}
					else if (this.inventory[this.selectedItem].useStyle == 4)
					{
						this.itemRotation = 0f;
						this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - 9f - this.itemRotation * 14f * (float)this.direction - 4f) * (float)this.direction;
						this.itemLocation.Y = this.position.Y + (float)Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5f + 4f;
						if (this.gravDir == -1f)
						{
							this.itemRotation = -this.itemRotation;
							this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
						}
					}
					else if (this.inventory[this.selectedItem].useStyle == 5)
					{
						this.itemLocation.X = this.position.X + (float)this.width * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - (float)(this.direction * 2);
						this.itemLocation.Y = this.position.Y + (float)this.height * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5f;
					}
				}*/
			}
			else if (this.inventory[this.selectedItem].holdStyle == 1 && !this.pulley)
			{
				if (Main.dedServ)
				{
					this.itemLocation.X = this.position.X + (float)this.width * 0.5f + 20f * (float)this.direction;
				}
				/*else if (this.inventory[this.selectedItem].type == 930)
				{
					this.itemLocation.X = this.position.X + (float)(this.width / 2) * 0.5f - 12f - (float)(2 * this.direction);
					float num26 = this.position.X + (float)(this.width / 2) + (float)(38 * this.direction);
					if (this.direction == 1)
					{
						num26 -= 10f;
					}
					float num27 = this.position.Y + (float)(this.height / 2) - 4f * this.gravDir;
					if (this.gravDir == -1f)
					{
						num27 -= 8f;
					}
					int num28 = 0;
					for (int num29 = 54; num29 < 58; num29++)
					{
						if (this.inventory[num29].stack > 0 && this.inventory[num29].ammo == 931)
						{
							num28 = this.inventory[num29].type;
							break;
						}
					}
					if (num28 == 0)
					{
						for (int num30 = 0; num30 < 54; num30++)
						{
							if (this.inventory[num30].stack > 0 && this.inventory[num30].ammo == 931)
							{
								num28 = this.inventory[num30].type;
								break;
							}
						}
					}
					if (num28 == 931)
					{
						num28 = 127;
					}
					else if (num28 == 1614)
					{
						num28 = 187;
					}
					if (num28 > 0)
					{
						int num31 = Dust.NewDust(new Vector2(num26, num27 + this.gfxOffY), 6, 6, num28, 0f, 0f, 100, default(Color), 1.6f);
						Main.dust[num31].noGravity = true;
						Dust expr_29BC_cp_0 = Main.dust[num31];
						expr_29BC_cp_0.velocity.Y = expr_29BC_cp_0.velocity.Y - 4f * this.gravDir;
					}
				}
				else if (this.inventory[this.selectedItem].type == 968)
				{
					this.itemLocation.X = this.position.X + (float)this.width * 0.5f + (float)(8 * this.direction);
					if (this.whoAmi == Main.myPlayer)
					{
						int num32 = (int)(this.itemLocation.X + (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.8f * (float)this.direction) / 16;
						int num33 = (int)(this.itemLocation.Y + (float)(Main.itemTexture[this.inventory[this.selectedItem].type].Height / 2)) / 16;
						if (Main.tile[num32, num33] == null)
						{
							Main.tile[num32, num33] = new Tile();
						}
						if (Main.tile[num32, num33].active() && Main.tile[num32, num33].type == 215)
						{
							this.miscTimer++;
							if (Main.rand.Next(5) == 0)
							{
								this.miscTimer++;
							}
							if (this.miscTimer > 900)
							{
								this.miscTimer = 0;
								this.inventory[this.selectedItem].SetDefaults(969, false);
								if (this.selectedItem == 58)
								{
									Main.mouseItem.SetDefaults(969, false);
								}
								for (int num34 = 0; num34 < 58; num34++)
								{
									if (this.inventory[num34].type == this.inventory[this.selectedItem].type && num34 != this.selectedItem && this.inventory[num34].stack < this.inventory[num34].maxStack)
									{
										Main.PlaySound(7, -1, -1, 1);
										this.inventory[num34].stack++;
										this.inventory[this.selectedItem].SetDefaults(0, false);
										if (this.selectedItem == 58)
										{
											Main.mouseItem.SetDefaults(0, false);
										}
									}
								}
							}
						}
						else
						{
							this.miscTimer = 0;
						}
					}
				}
				else if (this.inventory[this.selectedItem].type == 856)
				{
					this.itemLocation.X = this.position.X + (float)this.width * 0.5f + (float)(4 * this.direction);
				}
				else
				{
					this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f + 2f) * (float)this.direction;
					if (this.inventory[this.selectedItem].type == 282 || this.inventory[this.selectedItem].type == 286)
					{
						this.itemLocation.X = this.itemLocation.X - (float)(this.direction * 2);
						this.itemLocation.Y = this.itemLocation.Y + 4f;
					}
				}*/
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
			else if (this.inventory[this.selectedItem].holdStyle == 2 && !this.pulley)
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
			else if (this.inventory[this.selectedItem].holdStyle == 3 && !this.pulley && !Main.dedServ)
			{
				/*this.itemLocation.X = this.position.X + (float)this.width * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - (float)(this.direction * 2);
				this.itemLocation.Y = this.position.Y + (float)this.height * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5f;
				this.itemRotation = 0f;*/
			}
			if ((((this.inventory[this.selectedItem].type == 974 || this.inventory[this.selectedItem].type == 8 || this.inventory[this.selectedItem].type == 1245 || (this.inventory[this.selectedItem].type >= 427 && this.inventory[this.selectedItem].type <= 433)) && !this.wet) || this.inventory[this.selectedItem].type == 523 || this.inventory[this.selectedItem].type == 1333) && !this.pulley)
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
						Dust expr_353D_cp_0 = Main.dust[num37];
						expr_353D_cp_0.velocity.Y = expr_353D_cp_0.velocity.Y - 1.5f;
					}
					//Lighting.addLight((int)((this.itemLocation.X - 12f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f + this.velocity.Y) / 16f), r, g, b);
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
						Dust expr_3654_cp_0 = Main.dust[num38];
						expr_3654_cp_0.velocity.Y = expr_3654_cp_0.velocity.Y - 1.5f;
					}
					//Lighting.addLight((int)((this.itemLocation.X + 12f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f + this.velocity.Y) / 16f), r, g, b);
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
						Dust expr_37B0_cp_0 = Main.dust[num39];
						expr_37B0_cp_0.velocity.Y = expr_37B0_cp_0.velocity.Y - 1.5f;
					}
					//Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 1f, 0.95f, 0.8f);
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
						Dust expr_38C3_cp_0 = Main.dust[num40];
						expr_38C3_cp_0.velocity.Y = expr_38C3_cp_0.velocity.Y - 1.5f;
					}
					//Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 1f, 0.95f, 0.8f);
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
						Dust expr_3A1D_cp_0 = Main.dust[num41];
						expr_3A1D_cp_0.velocity.Y = expr_3A1D_cp_0.velocity.Y - 1.5f;
					}
					//Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0f, 0.5f, 1f);
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
						Dust expr_3B34_cp_0 = Main.dust[num42];
						expr_3B34_cp_0.velocity.Y = expr_3B34_cp_0.velocity.Y - 1.5f;
					}
					//Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0f, 0.5f, 1f);
				}
			}
			if (this.inventory[this.selectedItem].type == 282 && !this.pulley)
			{
				if (this.direction == -1)
				{
					//Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 1f, 0.8f);
				}
				else
				{
					//Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 1f, 0.8f);
				}
			}
			if (this.inventory[this.selectedItem].type == 286 && !this.pulley)
			{
				if (this.direction == -1)
				{
					//Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 0.8f, 1f);
				}
				else
				{
					//Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 0.8f, 1f);
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
					if (num45 == 13 || num45 == 32 || num45 == 315 || (num45 >= 230 && num45 <= 235))
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
							if (this.inventory[this.selectedItem].useAmmo == 771)
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
						else if (this.inventory[this.selectedItem].type == 1553)
						{
							float speedX2 = num53 + (float)Main.rand.Next(-40, 41) * 0.005f;
							float speedY2 = num54 + (float)Main.rand.Next(-40, 41) * 0.005f;
							Projectile.NewProjectile(vector.X, vector.Y, speedX2, speedY2, num45, num47, num48, i, 0f, 0f);
						}
						else if (this.inventory[this.selectedItem].type == 518)
						{
							float num61 = num53;
							float num62 = num54;
							num61 += (float)Main.rand.Next(-40, 41) * 0.04f;
							num62 += (float)Main.rand.Next(-40, 41) * 0.04f;
							Projectile.NewProjectile(vector.X, vector.Y, num61, num62, num45, num47, num48, i, 0f, 0f);
						}
						else if (this.inventory[this.selectedItem].type == 1265)
						{
							float num63 = num53;
							float num64 = num54;
							num63 += (float)Main.rand.Next(-30, 31) * 0.03f;
							num64 += (float)Main.rand.Next(-30, 31) * 0.03f;
							Projectile.NewProjectile(vector.X, vector.Y, num63, num64, num45, num47, num48, i, 0f, 0f);
						}
						else if (this.inventory[this.selectedItem].type == 534)
						{
							for (int num65 = 0; num65 < 4; num65++)
							{
								float num66 = num53;
								float num67 = num54;
								num66 += (float)Main.rand.Next(-40, 41) * 0.05f;
								num67 += (float)Main.rand.Next(-40, 41) * 0.05f;
								Projectile.NewProjectile(vector.X, vector.Y, num66, num67, num45, num47, num48, i, 0f, 0f);
							}
						}
						else if (this.inventory[this.selectedItem].type == 1308)
						{
							int num68 = 4;
							for (int num69 = 0; num69 < num68; num69++)
							{
								float num70 = num53;
								float num71 = num54;
								float num72 = 0.05f * (float)num69;
								num70 += (float)Main.rand.Next(-35, 36) * num72;
								num71 += (float)Main.rand.Next(-35, 36) * num72;
								num55 = (float)Math.Sqrt((double)(num70 * num70 + num71 * num71));
								num55 = num46 / num55;
								num70 *= num55;
								num71 *= num55;
								float x = vector.X;
								float y = vector.Y;
								Projectile.NewProjectile(x, y, num70, num71, num45, num47, num48, i, 0f, 0f);
							}
						}
						else if (this.inventory[this.selectedItem].type == 1258)
						{
							float num73 = num53;
							float num74 = num54;
							num73 += (float)Main.rand.Next(-40, 41) * 0.01f;
							num74 += (float)Main.rand.Next(-40, 41) * 0.01f;
							vector.X += (float)Main.rand.Next(-40, 41) * 0.05f;
							vector.Y += (float)Main.rand.Next(-45, 36) * 0.05f;
							Projectile.NewProjectile(vector.X, vector.Y, num73, num74, num45, num47, num48, i, 0f, 0f);
						}
						else if (this.inventory[this.selectedItem].type == 964)
						{
							for (int num75 = 0; num75 < 3; num75++)
							{
								float num76 = num53;
								float num77 = num54;
								num76 += (float)Main.rand.Next(-35, 36) * 0.04f;
								num77 += (float)Main.rand.Next(-35, 36) * 0.04f;
								Projectile.NewProjectile(vector.X, vector.Y, num76, num77, num45, num47, num48, i, 0f, 0f);
							}
						}
						else if (this.inventory[this.selectedItem].type == 1569)
						{
							int num78 = 4;
							if (Main.rand.Next(2) == 0)
							{
								num78++;
							}
							if (Main.rand.Next(4) == 0)
							{
								num78++;
							}
							if (Main.rand.Next(8) == 0)
							{
								num78++;
							}
							if (Main.rand.Next(16) == 0)
							{
								num78++;
							}
							for (int num79 = 0; num79 < num78; num79++)
							{
								float num80 = num53;
								float num81 = num54;
								float num82 = 0.05f * (float)num79;
								num80 += (float)Main.rand.Next(-35, 36) * num82;
								num81 += (float)Main.rand.Next(-35, 36) * num82;
								num55 = (float)Math.Sqrt((double)(num80 * num80 + num81 * num81));
								num55 = num46 / num55;
								num80 *= num55;
								num81 *= num55;
								float x2 = vector.X;
								float y2 = vector.Y;
								Projectile.NewProjectile(x2, y2, num80, num81, num45, num47, num48, i, 0f, 0f);
							}
						}
						else if (this.inventory[this.selectedItem].type == 1572)
						{
							for (int num83 = 0; num83 < 1000; num83++)
							{
								if (Main.projectile[num83].owner == this.whoAmi && Main.projectile[num83].type == 308)
								{
									Main.projectile[num83].Kill();
								}
							}
							int num84 = (int)((float)Main.mouseX + Main.screenPosition.X) / 16;
							int num85 = (int)((float)Main.mouseY + Main.screenPosition.Y) / 16;
							while (num85 < Main.maxTilesY - 10 && Main.tile[num84, num85] != null && !WorldGen.SolidTile(num84, num85) && Main.tile[num84 - 1, num85] != null && !WorldGen.SolidTile(num84 - 1, num85) && Main.tile[num84 + 1, num85] != null && !WorldGen.SolidTile(num84 + 1, num85))
							{
								num85++;
							}
							num85--;
							Projectile.NewProjectile((float)Main.mouseX + Main.screenPosition.X, (float)(num85 * 16 - 24), 0f, 15f, num45, num47, num48, i, 0f, 0f);
						}
						else if (this.inventory[this.selectedItem].type == 1244 || this.inventory[this.selectedItem].type == 1256)
						{
							int num86 = Projectile.NewProjectile(vector.X, vector.Y, num53, num54, num45, num47, num48, i, 0f, 0f);
							Main.projectile[num86].ai[0] = (float)Main.mouseX + Main.screenPosition.X;
							Main.projectile[num86].ai[1] = (float)Main.mouseY + Main.screenPosition.Y;
						}
						else if (this.inventory[this.selectedItem].type == 1229)
						{
							int num87 = Main.rand.Next(2, 4);
							if (Main.rand.Next(5) == 0)
							{
								num87++;
							}
							for (int num88 = 0; num88 < num87; num88++)
							{
								float num89 = num53;
								float num90 = num54;
								if (num88 > 0)
								{
									num89 += (float)Main.rand.Next(-35, 36) * 0.04f;
									num90 += (float)Main.rand.Next(-35, 36) * 0.04f;
								}
								if (num88 > 1)
								{
									num89 += (float)Main.rand.Next(-35, 36) * 0.04f;
									num90 += (float)Main.rand.Next(-35, 36) * 0.04f;
								}
								if (num88 > 2)
								{
									num89 += (float)Main.rand.Next(-35, 36) * 0.04f;
									num90 += (float)Main.rand.Next(-35, 36) * 0.04f;
								}
								int num91 = Projectile.NewProjectile(vector.X, vector.Y, num89, num90, num45, num47, num48, i, 0f, 0f);
								Main.projectile[num91].noDropItem = true;
							}
						}
						else if (this.inventory[this.selectedItem].type == 1121 || this.inventory[this.selectedItem].type == 1155)
						{
							int num92;
							if (this.inventory[this.selectedItem].type == 1121)
							{
								num92 = Main.rand.Next(1, 4);
								if (Main.rand.Next(6) == 0)
								{
									num92++;
								}
								if (Main.rand.Next(6) == 0)
								{
									num92++;
								}
							}
							else
							{
								num92 = Main.rand.Next(2, 5);
								if (Main.rand.Next(5) == 0)
								{
									num92++;
								}
								if (Main.rand.Next(5) == 0)
								{
									num92++;
								}
							}
							for (int num93 = 0; num93 < num92; num93++)
							{
								float num94 = num53;
								float num95 = num54;
								num94 += (float)Main.rand.Next(-35, 36) * 0.02f;
								num95 += (float)Main.rand.Next(-35, 36) * 0.02f;
								Projectile.NewProjectile(vector.X, vector.Y, num94, num95, num45, num47, num48, i, 0f, 0f);
							}
						}
						else if (this.inventory[this.selectedItem].type == 1801)
						{
							int num96 = Main.rand.Next(1, 4);
							for (int num97 = 0; num97 < num96; num97++)
							{
								float num98 = num53;
								float num99 = num54;
								num98 += (float)Main.rand.Next(-35, 36) * 0.05f;
								num99 += (float)Main.rand.Next(-35, 36) * 0.05f;
								Projectile.NewProjectile(vector.X, vector.Y, num98, num99, num45, num47, num48, i, 0f, 0f);
							}
						}
						else if (this.inventory[this.selectedItem].type == 679)
						{
							for (int num100 = 0; num100 < 6; num100++)
							{
								float num101 = num53;
								float num102 = num54;
								num101 += (float)Main.rand.Next(-40, 41) * 0.05f;
								num102 += (float)Main.rand.Next(-40, 41) * 0.05f;
								Projectile.NewProjectile(vector.X, vector.Y, num101, num102, num45, num47, num48, i, 0f, 0f);
							}
						}
						else if (this.inventory[this.selectedItem].type == 434)
						{
							float num103 = num53;
							float num104 = num54;
							if (this.itemAnimation < 5)
							{
								num103 += (float)Main.rand.Next(-40, 41) * 0.01f;
								num104 += (float)Main.rand.Next(-40, 41) * 0.01f;
								num103 *= 1.1f;
								num104 *= 1.1f;
							}
							else if (this.itemAnimation < 10)
							{
								num103 += (float)Main.rand.Next(-20, 21) * 0.01f;
								num104 += (float)Main.rand.Next(-20, 21) * 0.01f;
								num103 *= 1.05f;
								num104 *= 1.05f;
							}
							Projectile.NewProjectile(vector.X, vector.Y, num103, num104, num45, num47, num48, i, 0f, 0f);
						}
						else if (this.inventory[this.selectedItem].type == 1157)
						{
							num45 = Main.rand.Next(191, 195);
							num53 = 0f;
							num54 = 0f;
							vector.X = (float)Main.mouseX + Main.screenPosition.X;
							vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
							int num105 = Projectile.NewProjectile(vector.X, vector.Y, num53, num54, num45, num47, num48, i, 0f, 0f);
							Main.projectile[num105].localAI[0] = 30f;
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
							for (int num106 = 0; num106 < 1000; num106++)
							{
								if (Main.projectile[num106].active && Main.projectile[num106].owner == this.whoAmi)
								{
									if (this.inventory[this.selectedItem].shoot == 72)
									{
										if (Main.projectile[num106].type == 72 || Main.projectile[num106].type == 86 || Main.projectile[num106].type == 87)
										{
											Main.projectile[num106].Kill();
										}
									}
									else if (this.inventory[this.selectedItem].shoot == Main.projectile[num106].type)
									{
										Main.projectile[num106].Kill();
									}
								}
							}
							if (num45 == 72)
							{
								int num107 = Main.rand.Next(3);
								if (num107 == 0)
								{
									num45 = 72;
								}
								else if (num107 == 1)
								{
									num45 = 86;
								}
								else if (num107 == 2)
								{
									num45 = 87;
								}
							}
							Projectile.NewProjectile(vector.X, vector.Y, num53, num54, num45, num47, num48, i, 0f, 0f);
						}
						else
						{
							int num108 = Projectile.NewProjectile(vector.X, vector.Y, num53, num54, num45, num47, num48, i, 0f, 0f);
							if (num45 == 80)
							{
								Main.projectile[num108].ai[0] = (float)Player.tileTargetX;
								Main.projectile[num108].ai[1] = (float)Player.tileTargetY;
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
							int num109 = -1;
							for (int num110 = 0; num110 < 58; num110++)
							{
								if (this.inventory[num110].stack > 0 && this.inventory[num110].type == 530)
								{
									num109 = num110;
									break;
								}
							}
							if (num109 >= 0 && WorldGen.PlaceWire(i2, j2))
							{
								this.inventory[num109].stack--;
								if (this.inventory[num109].stack <= 0)
								{
									this.inventory[num109].SetDefaults(0, false);
								}
								this.itemTime = this.inventory[this.selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 5, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
							}
						}
						else if (this.inventory[this.selectedItem].type == 850)
						{
							int num111 = -1;
							for (int num112 = 0; num112 < 58; num112++)
							{
								if (this.inventory[num112].stack > 0 && this.inventory[num112].type == 530)
								{
									num111 = num112;
									break;
								}
							}
							if (num111 >= 0 && WorldGen.PlaceWire2(i2, j2))
							{
								this.inventory[num111].stack--;
								if (this.inventory[num111].stack <= 0)
								{
									this.inventory[num111].SetDefaults(0, false);
								}
								this.itemTime = this.inventory[this.selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 10, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
							}
						}
						if (this.inventory[this.selectedItem].type == 851)
						{
							int num113 = -1;
							for (int num114 = 0; num114 < 58; num114++)
							{
								if (this.inventory[num114].stack > 0 && this.inventory[num114].type == 530)
								{
									num113 = num114;
									break;
								}
							}
							if (num113 >= 0 && WorldGen.PlaceWire3(i2, j2))
							{
								this.inventory[num113].stack--;
								if (this.inventory[num113].stack <= 0)
								{
									this.inventory[num113].SetDefaults(0, false);
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
					float num115 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
					float num116 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
					float num117 = (float)Math.Sqrt((double)(num115 * num115 + num116 * num116));
					num117 /= (float)(Main.screenHeight / 2);
					if (num117 > 1f)
					{
						num117 = 1f;
					}
					num117 = num117 * 2f - 1f;
					if (num117 < -1f)
					{
						num117 = -1f;
					}
					if (num117 > 1f)
					{
						num117 = 1f;
					}
					Main.harpNote = num117;
					int style = 26;
					if (this.inventory[this.selectedItem].type == 507)
					{
						style = 35;
					}
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, style);
					NetMessage.SendData(58, -1, -1, "", this.whoAmi, num117, 0f, 0f, 0);
				}
				if (((this.inventory[this.selectedItem].type >= 205 && this.inventory[this.selectedItem].type <= 207) || this.inventory[this.selectedItem].type == 1128) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
				{
					this.showItemIcon = true;
					if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
					{
						if (this.inventory[this.selectedItem].type == 205)
						{
							int num118 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType();
							int num119 = 0;
							for (int num120 = Player.tileTargetX - 1; num120 <= Player.tileTargetX + 1; num120++)
							{
								for (int num121 = Player.tileTargetY - 1; num121 <= Player.tileTargetY + 1; num121++)
								{
									if ((int)Main.tile[num120, num121].liquidType() == num118)
									{
										num119 += (int)Main.tile[num120, num121].liquid;
									}
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0 && num119 > 100)
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
								int num122 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquid;
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
								for (int num123 = Player.tileTargetX - 1; num123 <= Player.tileTargetX + 1; num123++)
								{
									for (int num124 = Player.tileTargetY - 1; num124 <= Player.tileTargetY + 1; num124++)
									{
										if (num122 < 256 && (int)Main.tile[num123, num124].liquidType() == num118)
										{
											int num125 = (int)Main.tile[num123, num124].liquid;
											if (num125 + num122 > 255)
											{
												num125 = 255 - num122;
											}
											num122 += num125;
											Tile expr_681E = Main.tile[num123, num124];
											expr_681E.liquid -= (byte)num125;
											Main.tile[num123, num124].liquidType(liquidType);
											if (Main.tile[num123, num124].liquid == 0)
											{
												Main.tile[num123, num124].lava(false);
												Main.tile[num123, num124].honey(false);
											}
											WorldGen.SquareTileFrame(num123, num124, false);
											if (Main.netMode == 1)
											{
												NetMessage.sendWater(num123, num124);
											}
											else
											{
												Liquid.AddWater(num123, num124);
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
										int num126 = Player.tileTargetX;
										int num127 = Player.tileTargetY;
										if ((Main.tile[num126, num127].halfBrick() || Main.tile[num126, num127].slope() != 0) && !Main.tileSolidTop[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
										{
											int num128 = 1;
											int slope = 2;
											if (WorldGen.SolidTile(num126 + 1, num127) && !WorldGen.SolidTile(num126 - 1, num127))
											{
												num128 = 2;
												slope = 1;
											}
											if (Main.tile[num126, num127].slope() == 0)
											{
												WorldGen.SlopeTile(num126, num127, num128);
											}
											else if ((int)Main.tile[num126, num127].slope() == num128)
											{
												WorldGen.SlopeTile(num126, num127, slope);
											}
											else
											{
												WorldGen.SlopeTile(num126, num127, 0);
											}
											int num129 = (int)Main.tile[num126, num127].slope();
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 14, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)num129, 0);
											}
										}
										else
										{
											WorldGen.PoundTile(num126, num127);
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
					int num130 = Player.tileTargetX;
					int num131 = Player.tileTargetY;
					bool flag9 = true;
					if (Main.tile[num130, num131].wall > 0)
					{
						if (!Main.wallHouse[(int)Main.tile[num130, num131].wall])
						{
							for (int num132 = num130 - 1; num132 < num130 + 2; num132++)
							{
								for (int num133 = num131 - 1; num133 < num131 + 2; num133++)
								{
									if (Main.tile[num132, num133].wall != Main.tile[num130, num131].wall)
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
					if (flag9 && !Main.tile[num130, num131].active())
					{
						int num134 = -1;
						if ((double)(((float)Main.mouseX + Main.screenPosition.X) / 16f) < Math.Round((double)(((float)Main.mouseX + Main.screenPosition.X) / 16f)))
						{
							num134 = 0;
						}
						int num135 = -1;
						if ((double)(((float)Main.mouseY + Main.screenPosition.Y) / 16f) < Math.Round((double)(((float)Main.mouseY + Main.screenPosition.Y) / 16f)))
						{
							num135 = 0;
						}
						for (int num136 = Player.tileTargetX + num134; num136 <= Player.tileTargetX + num134 + 1; num136++)
						{
							for (int num137 = Player.tileTargetY + num135; num137 <= Player.tileTargetY + num135 + 1; num137++)
							{
								if (flag9)
								{
									num130 = num136;
									num131 = num137;
									if (Main.tile[num130, num131].wall > 0)
									{
										if (!Main.wallHouse[(int)Main.tile[num130, num131].wall])
										{
											for (int num138 = num130 - 1; num138 < num130 + 2; num138++)
											{
												for (int num139 = num131 - 1; num139 < num131 + 2; num139++)
												{
													if (Main.tile[num138, num139].wall != Main.tile[num130, num131].wall)
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
					if (flag8 && Main.tile[num130, num131].wall > 0 && (!Main.tile[num130, num131].active() || num130 != Player.tileTargetX || num131 != Player.tileTargetY || (!Main.tileHammer[(int)Main.tile[num130, num131].type] && !this.poundRelease)) && this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem && this.inventory[this.selectedItem].hammer > 0)
					{
						bool flag10 = true;
						if (!Main.wallHouse[(int)Main.tile[num130, num131].wall])
						{
							flag10 = false;
							for (int num140 = num130 - 1; num140 < num130 + 2; num140++)
							{
								for (int num141 = num131 - 1; num141 < num131 + 2; num141++)
								{
									if (Main.tile[num140, num141].wall == 0 || Main.wallHouse[(int)Main.tile[num140, num141].wall])
									{
										flag10 = true;
										break;
									}
								}
							}
						}
						if (flag10)
						{
							if (this.hitTileX != num130 || this.hitTileY != num131)
							{
								this.hitTile = 0;
								this.hitTileX = num130;
								this.hitTileY = num131;
							}
							this.hitTile += (int)((float)this.inventory[this.selectedItem].hammer * 1.5f);
							if (this.hitTile >= 100)
							{
								this.hitTile = 0;
								WorldGen.KillWall(num130, num131, false);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 2, (float)num130, (float)num131, 0f, 0);
								}
							}
							else
							{
								WorldGen.KillWall(num130, num131, true);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 2, (float)num130, (float)num131, 1f, 0);
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
					if (!Collision.SolidCollision(newPos, this.width, this.height))
					{
						this.Teleport(newPos, 1);
						NetMessage.SendData(65, -1, -1, "", 0, (float)this.whoAmi, newPos.X, newPos.Y, 1);
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
				if (!Main.dedServ)
				{
					//rectangle = new Rectangle((int)this.itemLocation.X, (int)this.itemLocation.Y, Main.itemTexture[this.inventory[this.selectedItem].type].Width, Main.itemTexture[this.inventory[this.selectedItem].type].Height);
				}
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
				float arg_8BF8_0 = this.gravDir;
				if (this.inventory[this.selectedItem].type == 1450 && Main.rand.Next(3) == 0)
				{
					int num142 = -1;
					float x3 = (float)(rectangle.X + Main.rand.Next(rectangle.Width));
					float y3 = (float)(rectangle.Y + Main.rand.Next(rectangle.Height));
					if (Main.rand.Next(500) == 0)
					{
						num142 = Gore.NewGore(new Vector2(x3, y3), default(Vector2), 415, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else if (Main.rand.Next(250) == 0)
					{
						num142 = Gore.NewGore(new Vector2(x3, y3), default(Vector2), 414, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else if (Main.rand.Next(80) == 0)
					{
						num142 = Gore.NewGore(new Vector2(x3, y3), default(Vector2), 413, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else if (Main.rand.Next(10) == 0)
					{
						num142 = Gore.NewGore(new Vector2(x3, y3), default(Vector2), 412, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else if (Main.rand.Next(3) == 0)
					{
						num142 = Gore.NewGore(new Vector2(x3, y3), default(Vector2), 411, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					if (num142 >= 0)
					{
						Gore expr_8DE6_cp_0 = Main.gore[num142];
						expr_8DE6_cp_0.velocity.X = expr_8DE6_cp_0.velocity.X + (float)(this.direction * 2);
						Gore expr_8E08_cp_0 = Main.gore[num142];
						expr_8E08_cp_0.velocity.Y = expr_8E08_cp_0.velocity.Y * 0.3f;
					}
				}
				if (!flag11)
				{
					if (this.inventory[this.selectedItem].type == 989 && Main.rand.Next(5) == 0)
					{
						int num143 = Main.rand.Next(3);
						if (num143 == 0)
						{
							num143 = 15;
						}
						else if (num143 == 1)
						{
							num143 = 57;
						}
						else
						{
							num143 = 58;
						}
						int num144 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, num143, (float)(this.direction * 2), 0f, 150, default(Color), 1.3f);
						Main.dust[num144].velocity *= 0.2f;
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
						int num145 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 27, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.2f);
						Main.dust[num145].noGravity = true;
						Dust expr_90C9_cp_0 = Main.dust[num145];
						expr_90C9_cp_0.velocity.X = expr_90C9_cp_0.velocity.X / 2f;
						Dust expr_90E7_cp_0 = Main.dust[num145];
						expr_90E7_cp_0.velocity.Y = expr_90E7_cp_0.velocity.Y / 2f;
					}
					if (this.inventory[this.selectedItem].type == 678)
					{
						int num146 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 71, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.2f);
						Main.dust[num146].velocity *= 1.5f;
						Main.dust[num146].noGravity = true;
					}
					if (this.inventory[this.selectedItem].type == 723 && Main.rand.Next(2) == 0)
					{
						int num147 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 64, 0f, 0f, 150, default(Color), 1.2f);
						Main.dust[num147].noGravity = true;
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
						int num148 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 40, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 0, default(Color), 1.2f);
						Main.dust[num148].noGravity = true;
					}
					if (this.inventory[this.selectedItem].type == 121)
					{
						for (int num149 = 0; num149 < 2; num149++)
						{
							int num150 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
							Main.dust[num150].noGravity = true;
							Dust expr_943F_cp_0 = Main.dust[num150];
							expr_943F_cp_0.velocity.X = expr_943F_cp_0.velocity.X * 2f;
							Dust expr_945D_cp_0 = Main.dust[num150];
							expr_945D_cp_0.velocity.Y = expr_945D_cp_0.velocity.Y * 2f;
						}
					}
					if (this.inventory[this.selectedItem].type == 122 || this.inventory[this.selectedItem].type == 217)
					{
						int num151 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.9f);
						Main.dust[num151].noGravity = true;
					}
					if (this.inventory[this.selectedItem].type == 155)
					{
						int num152 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 172, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 0.9f);
						Main.dust[num152].noGravity = true;
						Main.dust[num152].velocity *= 0.1f;
					}
					if ((this.inventory[this.selectedItem].type == 676 || this.inventory[this.selectedItem].type == 673) && Main.rand.Next(3) == 0)
					{
						int num153 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 67, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 90, default(Color), 1.5f);
						Main.dust[num153].noGravity = true;
						Main.dust[num153].velocity *= 0.2f;
					}
					if (this.inventory[this.selectedItem].type == 724 && Main.rand.Next(5) == 0)
					{
						int num154 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 67, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 90, default(Color), 1.5f);
						Main.dust[num154].noGravity = true;
						Main.dust[num154].velocity *= 0.2f;
					}
					if (this.inventory[this.selectedItem].type >= 795 && this.inventory[this.selectedItem].type <= 802 && Main.rand.Next(3) == 0)
					{
						int num155 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 115, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 140, default(Color), 1.5f);
						Main.dust[num155].noGravity = true;
						Main.dust[num155].velocity *= 0.25f;
					}
					if (this.inventory[this.selectedItem].type == 367 || this.inventory[this.selectedItem].type == 368 || this.inventory[this.selectedItem].type == 674)
					{
						if (Main.rand.Next(3) == 0)
						{
							int num156 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.1f);
							Main.dust[num156].noGravity = true;
							Dust expr_9949_cp_0 = Main.dust[num156];
							expr_9949_cp_0.velocity.X = expr_9949_cp_0.velocity.X / 2f;
							Dust expr_9967_cp_0 = Main.dust[num156];
							expr_9967_cp_0.velocity.Y = expr_9967_cp_0.velocity.Y / 2f;
							Dust expr_9985_cp_0 = Main.dust[num156];
							expr_9985_cp_0.velocity.X = expr_9985_cp_0.velocity.X + (float)(this.direction * 2);
						}
						if (Main.rand.Next(4) == 0)
						{
							int num156 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 43, 0f, 0f, 254, default(Color), 0.3f);
							Main.dust[num156].velocity *= 0f;
						}
					}
					if (this.inventory[this.selectedItem].type >= 198 && this.inventory[this.selectedItem].type <= 203)
					{
						float num157 = 0.5f;
						float num158 = 0.5f;
						float num159 = 0.5f;
						if (this.inventory[this.selectedItem].type == 198)
						{
							num157 *= 0.1f;
							num158 *= 0.5f;
							num159 *= 1.2f;
						}
						else if (this.inventory[this.selectedItem].type == 199)
						{
							num157 *= 1f;
							num158 *= 0.2f;
							num159 *= 0.1f;
						}
						else if (this.inventory[this.selectedItem].type == 200)
						{
							num157 *= 0.1f;
							num158 *= 1f;
							num159 *= 0.2f;
						}
						else if (this.inventory[this.selectedItem].type == 201)
						{
							num157 *= 0.8f;
							num158 *= 0.1f;
							num159 *= 1f;
						}
						else if (this.inventory[this.selectedItem].type == 202)
						{
							num157 *= 0.8f;
							num158 *= 0.9f;
							num159 *= 1f;
						}
						else if (this.inventory[this.selectedItem].type == 203)
						{
							num157 *= 0.9f;
							num158 *= 0.9f;
							num159 *= 0.1f;
						}
						//Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), num157, num158, num159);
					}
					if (this.frostBurn && this.inventory[this.selectedItem].melee && !this.inventory[this.selectedItem].noMelee && !this.inventory[this.selectedItem].noUseGraphic && Main.rand.Next(2) == 0)
					{
						int num160 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 135, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
						Main.dust[num160].noGravity = true;
						Main.dust[num160].velocity *= 0.7f;
						Dust expr_9D0B_cp_0 = Main.dust[num160];
						expr_9D0B_cp_0.velocity.Y = expr_9D0B_cp_0.velocity.Y - 0.5f;
					}
					if (this.inventory[this.selectedItem].melee && !this.inventory[this.selectedItem].noMelee && !this.inventory[this.selectedItem].noUseGraphic && this.meleeEnchant > 0)
					{
						if (this.meleeEnchant == 1)
						{
							if (Main.rand.Next(3) == 0)
							{
								int num161 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 171, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num161].noGravity = true;
								Main.dust[num161].fadeIn = 1.5f;
								Main.dust[num161].velocity *= 0.25f;
							}
						}
						else if (this.meleeEnchant == 2)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num162 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 75, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
								Main.dust[num162].noGravity = true;
								Main.dust[num162].velocity *= 0.7f;
								Dust expr_9EDA_cp_0 = Main.dust[num162];
								expr_9EDA_cp_0.velocity.Y = expr_9EDA_cp_0.velocity.Y - 0.5f;
							}
						}
						else if (this.meleeEnchant == 3)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num163 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
								Main.dust[num163].noGravity = true;
								Main.dust[num163].velocity *= 0.7f;
								Dust expr_9FB0_cp_0 = Main.dust[num163];
								expr_9FB0_cp_0.velocity.Y = expr_9FB0_cp_0.velocity.Y - 0.5f;
							}
						}
						else if (this.meleeEnchant == 4)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num164 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.1f);
								Main.dust[num164].noGravity = true;
								Dust expr_A06D_cp_0 = Main.dust[num164];
								expr_A06D_cp_0.velocity.X = expr_A06D_cp_0.velocity.X / 2f;
								Dust expr_A08B_cp_0 = Main.dust[num164];
								expr_A08B_cp_0.velocity.Y = expr_A08B_cp_0.velocity.Y / 2f;
							}
						}
						else if (this.meleeEnchant == 5)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num165 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 169, 0f, 0f, 100, default(Color), 1f);
								Dust expr_A118_cp_0 = Main.dust[num165];
								expr_A118_cp_0.velocity.X = expr_A118_cp_0.velocity.X + (float)this.direction;
								Dust expr_A138_cp_0 = Main.dust[num165];
								expr_A138_cp_0.velocity.Y = expr_A138_cp_0.velocity.Y + 0.2f;
								Main.dust[num165].noGravity = true;
							}
						}
						else if (this.meleeEnchant == 6)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num166 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 135, 0f, 0f, 100, default(Color), 1f);
								Dust expr_A1D3_cp_0 = Main.dust[num166];
								expr_A1D3_cp_0.velocity.X = expr_A1D3_cp_0.velocity.X + (float)this.direction;
								Dust expr_A1F3_cp_0 = Main.dust[num166];
								expr_A1F3_cp_0.velocity.Y = expr_A1F3_cp_0.velocity.Y + 0.2f;
								Main.dust[num166].noGravity = true;
							}
						}
						else if (this.meleeEnchant == 7)
						{
							if (Main.rand.Next(20) == 0)
							{
								int type3 = Main.rand.Next(139, 143);
								int num167 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, type3, this.velocity.X, this.velocity.Y, 0, default(Color), 1.2f);
								Dust expr_A2AD_cp_0 = Main.dust[num167];
								expr_A2AD_cp_0.velocity.X = expr_A2AD_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
								Dust expr_A2E1_cp_0 = Main.dust[num167];
								expr_A2E1_cp_0.velocity.Y = expr_A2E1_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
								Dust expr_A315_cp_0 = Main.dust[num167];
								expr_A315_cp_0.velocity.X = expr_A315_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
								Dust expr_A343_cp_0 = Main.dust[num167];
								expr_A343_cp_0.velocity.Y = expr_A343_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
								Main.dust[num167].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
							}
							if (Main.rand.Next(40) == 0)
							{
								int type4 = Main.rand.Next(276, 283);
								int num168 = Gore.NewGore(new Vector2((float)rectangle.X, (float)rectangle.Y), this.velocity, type4, 1f);
								Gore expr_A3F0_cp_0 = Main.gore[num168];
								expr_A3F0_cp_0.velocity.X = expr_A3F0_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
								Gore expr_A424_cp_0 = Main.gore[num168];
								expr_A424_cp_0.velocity.Y = expr_A424_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
								Main.gore[num168].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
								Gore expr_A487_cp_0 = Main.gore[num168];
								expr_A487_cp_0.velocity.X = expr_A487_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
								Gore expr_A4B5_cp_0 = Main.gore[num168];
								expr_A4B5_cp_0.velocity.Y = expr_A4B5_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
							}
						}
						else if (this.meleeEnchant == 8 && Main.rand.Next(4) == 0)
						{
							int num169 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 46, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num169].noGravity = true;
							Main.dust[num169].fadeIn = 1.5f;
							Main.dust[num169].velocity *= 0.25f;
						}
					}
					if (this.magmaStone && !this.inventory[this.selectedItem].magic && !this.inventory[this.selectedItem].ranged && Main.rand.Next(3) != 0)
					{
						int num170 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
						Main.dust[num170].noGravity = true;
						Dust expr_A64F_cp_0 = Main.dust[num170];
						expr_A64F_cp_0.velocity.X = expr_A64F_cp_0.velocity.X * 2f;
						Dust expr_A66D_cp_0 = Main.dust[num170];
						expr_A66D_cp_0.velocity.Y = expr_A66D_cp_0.velocity.Y * 2f;
					}
					if (Main.myPlayer == i && this.inventory[this.selectedItem].type != 1450)
					{
						int num171 = (int)((float)this.inventory[this.selectedItem].damage * this.meleeDamage);
						float num172 = this.inventory[this.selectedItem].knockBack;
						if (this.kbGlove)
						{
							num172 *= 2f;
						}
						int num173 = rectangle.X / 16;
						int num174 = (rectangle.X + rectangle.Width) / 16 + 1;
						int num175 = rectangle.Y / 16;
						int num176 = (rectangle.Y + rectangle.Height) / 16 + 1;
						for (int num177 = num173; num177 < num174; num177++)
						{
							for (int num178 = num175; num178 < num176; num178++)
							{
								if (Main.tile[num177, num178] != null && Main.tileCut[(int)Main.tile[num177, num178].type] && Main.tile[num177, num178 + 1] != null && Main.tile[num177, num178 + 1].type != 78)
								{
									if (this.inventory[this.selectedItem].type == 1786)
									{
										int type5 = (int)Main.tile[num177, num178].type;
										WorldGen.KillTile(num177, num178, false, false, false);
										if (!Main.tile[num177, num178].active())
										{
											int num179 = 0;
											if (type5 == 3 || type5 == 24 || type5 == 61 || type5 == 110 || type5 == 201)
											{
												num179 = Main.rand.Next(1, 3);
											}
											if (type5 == 73 || type5 == 74 || type5 == 113)
											{
												num179 = Main.rand.Next(2, 5);
											}
											if (num179 > 0)
											{
												int number = Item.NewItem(num177 * 16, num178 * 16, 16, 16, 1727, num179, false, 0, false);
												if (Main.netMode == 1)
												{
													NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0);
												}
											}
										}
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)num177, (float)num178, 0f, 0);
										}
									}
									else
									{
										WorldGen.KillTile(num177, num178, false, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)num177, (float)num178, 0f, 0);
										}
									}
								}
							}
						}
						for (int num180 = 0; num180 < 200; num180++)
						{
							if (Main.npc[num180].active && Main.npc[num180].immune[i] == 0 && this.attackCD == 0 && !Main.npc[num180].dontTakeDamage && (!Main.npc[num180].friendly || (Main.npc[num180].type == 22 && this.killGuide) || (Main.npc[num180].type == 54 && this.killClothier)))
							{
								Rectangle value = new Rectangle((int)Main.npc[num180].position.X, (int)Main.npc[num180].position.Y, Main.npc[num180].width, Main.npc[num180].height);
								if (rectangle.Intersects(value) && (Main.npc[num180].noTileCollide || Collision.CanHit(this.position, this.width, this.height, Main.npc[num180].position, Main.npc[num180].width, Main.npc[num180].height)))
								{
									bool flag12 = false;
									if (Main.rand.Next(1, 101) <= this.meleeCrit)
									{
										flag12 = true;
									}
									int num181 = Main.DamageVar((float)num171);
									this.StatusNPC(this.inventory[this.selectedItem].type, num180);
									this.onHit(Main.npc[num180].center().X, Main.npc[num180].center().Y);
									Main.npc[num180].StrikeNPC(num181, num172, this.direction, flag12, false);
									if (this.inventory[this.selectedItem].type == 1826)
									{
										this.pumpkinSword(num180, (int)((double)num171 * 1.5), num172);
									}
									if (this.meleeEnchant == 7)
									{
										Projectile.NewProjectile(Main.npc[num180].center().X, Main.npc[num180].center().Y, Main.npc[num180].velocity.X, Main.npc[num180].velocity.Y, 289, 0, 0f, this.whoAmi, 0f, 0f);
									}
									if (this.inventory[this.selectedItem].type == 1123)
									{
										int num182 = Main.rand.Next(1, 4);
										for (int num183 = 0; num183 < num182; num183++)
										{
											float num184 = (float)(this.direction * 2) + (float)Main.rand.Next(-35, 36) * 0.02f;
											float num185 = (float)Main.rand.Next(-35, 36) * 0.02f;
											num184 *= 0.2f;
											num185 *= 0.2f;
											Projectile.NewProjectile((float)(rectangle.X + rectangle.Width / 2), (float)(rectangle.Y + rectangle.Height / 2), num184, num185, 181, num181 / 3, 0f, i, 0f, 0f);
										}
									}
									if (Main.npc[num180].value > 0f && this.coins && Main.rand.Next(5) == 0)
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
										int num186 = Item.NewItem((int)Main.npc[num180].position.X, (int)Main.npc[num180].position.Y, Main.npc[num180].width, Main.npc[num180].height, type6, 1, false, 0, false);
										Main.item[num186].stack = Main.rand.Next(1, 11);
										Main.item[num186].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
										Main.item[num186].velocity.X = (float)Main.rand.Next(10, 31) * 0.2f * (float)this.direction;
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num186, 0f, 0f, 0f, 0);
										}
									}
									if (Main.netMode != 0)
									{
										if (flag12)
										{
											NetMessage.SendData(28, -1, -1, "", num180, (float)num181, num172, (float)this.direction, 1);
										}
										else
										{
											NetMessage.SendData(28, -1, -1, "", num180, (float)num181, num172, (float)this.direction, 0);
										}
									}
									Main.npc[num180].immune[i] = this.itemAnimation;
									this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
								}
							}
						}
						if (this.hostile)
						{
							for (int num187 = 0; num187 < 255; num187++)
							{
								if (num187 != i && Main.player[num187].active && Main.player[num187].hostile && !Main.player[num187].immune && !Main.player[num187].dead && (Main.player[i].team == 0 || Main.player[i].team != Main.player[num187].team))
								{
									Rectangle value2 = new Rectangle((int)Main.player[num187].position.X, (int)Main.player[num187].position.Y, Main.player[num187].width, Main.player[num187].height);
									if (rectangle.Intersects(value2) && Collision.CanHit(this.position, this.width, this.height, Main.player[num187].position, Main.player[num187].width, Main.player[num187].height))
									{
										bool flag13 = false;
										if (Main.rand.Next(1, 101) <= 10)
										{
											flag13 = true;
										}
										int num188 = Main.DamageVar((float)num171);
										this.StatusPvP(this.inventory[this.selectedItem].type, num187);
										this.onHit(Main.player[num187].center().X, Main.player[num187].center().Y);
										Main.player[num187].Hurt(num188, this.direction, true, false, "", flag13);
										if (this.meleeEnchant == 7)
										{
											Projectile.NewProjectile(Main.player[num187].center().X, Main.player[num187].center().Y, Main.player[num187].velocity.X, Main.player[num187].velocity.Y, 289, 0, 0f, this.whoAmi, 0f, 0f);
										}
										if (this.inventory[this.selectedItem].type == 1123)
										{
											int num189 = Main.rand.Next(1, 4);
											for (int num190 = 0; num190 < num189; num190++)
											{
												float num191 = (float)(this.direction * 2) + (float)Main.rand.Next(-35, 36) * 0.02f;
												float num192 = (float)Main.rand.Next(-35, 36) * 0.02f;
												num191 *= 0.2f;
												num192 *= 0.2f;
												Projectile.NewProjectile((float)(rectangle.X + rectangle.Width / 2), (float)(rectangle.Y + rectangle.Height / 2), num191, num192, 181, num188 / 3, 0f, i, 0f, 0f);
											}
										}
										if (Main.netMode != 0)
										{
											if (flag13)
											{
												NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.whoAmi, -1, -1, -1), num187, (float)this.direction, (float)num188, 1f, 1);
											}
											else
											{
												NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.whoAmi, -1, -1, -1), num187, (float)this.direction, (float)num188, 1f, 0);
											}
										}
										this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
									}
								}
							}
						}
						if (this.inventory[this.selectedItem].type == 787 && (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.5) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9)))
						{
							float num193 = 0f;
							float num194 = 0f;
							float num195 = 0f;
							float num196 = 0f;
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9))
							{
								num193 = -7f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
							{
								num193 = -6f;
								num194 = 2f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.5))
							{
								num193 = -4f;
								num194 = 4f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3))
							{
								num193 = -2f;
								num194 = 6f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1))
							{
								num194 = 7f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
							{
								num196 = 26f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3))
							{
								num196 -= 4f;
								num195 -= 20f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1))
							{
								num195 += 6f;
							}
							if (this.direction == -1)
							{
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9))
								{
									num196 -= 8f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
								{
									num196 -= 6f;
								}
							}
							num193 *= 1.5f;
							num194 *= 1.5f;
							num196 *= (float)this.direction;
							num195 *= this.gravDir;
							Projectile.NewProjectile((float)(rectangle.X + rectangle.Width / 2) + num196, (float)(rectangle.Y + rectangle.Height / 2) + num195, (float)this.direction * num194, num193 * this.gravDir, 131, num171 / 2, 0f, i, 0f, 0f);
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
					if (this.whoAmi == Main.myPlayer)
					{
						this.AddBuff(this.inventory[this.selectedItem].buffType, this.inventory[this.selectedItem].buffTime, true);
					}
					this.itemTime = this.inventory[this.selectedItem].useTime;
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
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 1844 && !Main.dayTime && !Main.pumpkinMoon)
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
				if (this.itemTime == 0 && this.itemAnimation > 0 && (this.inventory[this.selectedItem].type == 43 || this.inventory[this.selectedItem].type == 70 || this.inventory[this.selectedItem].type == 544 || this.inventory[this.selectedItem].type == 556 || this.inventory[this.selectedItem].type == 557 || this.inventory[this.selectedItem].type == 560 || this.inventory[this.selectedItem].type == 1133 || this.inventory[this.selectedItem].type == 1331))
				{
					bool flag14 = false;
					for (int num197 = 0; num197 < 200; num197++)
					{
						if (Main.npc[num197].active && ((this.inventory[this.selectedItem].type == 43 && Main.npc[num197].type == 4) || (this.inventory[this.selectedItem].type == 70 && Main.npc[num197].type == 13) || ((this.inventory[this.selectedItem].type == 560 & Main.npc[num197].type == 50) || (this.inventory[this.selectedItem].type == 544 && Main.npc[num197].type == 125)) || (this.inventory[this.selectedItem].type == 544 && Main.npc[num197].type == 126) || (this.inventory[this.selectedItem].type == 556 && Main.npc[num197].type == 134) || (this.inventory[this.selectedItem].type == 557 && Main.npc[num197].type == 128) || (this.inventory[this.selectedItem].type == 1133 && Main.npc[num197].type == 222) || (this.inventory[this.selectedItem].type == 1331 && Main.npc[num197].type == 266)))
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
					for (int num198 = 0; num198 < 70; num198++)
					{
						Dust.NewDust(this.position, this.width, this.height, 15, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, default(Color), 1.5f);
					}
					this.grappling[0] = -1;
					this.grapCount = 0;
					for (int num199 = 0; num199 < 1000; num199++)
					{
						if (Main.projectile[num199].active && Main.projectile[num199].owner == i && Main.projectile[num199].aiStyle == 7)
						{
							Main.projectile[num199].Kill();
						}
					}
					this.Spawn();
					for (int num200 = 0; num200 < 70; num200++)
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
					int num201 = 0;
					while (num201 < 58)
					{
						if (tileWand2 == this.inventory[num201].type && this.inventory[num201].stack > 0)
						{
							this.inventory[num201].stack--;
							if (this.inventory[num201].stack <= 0)
							{
								this.inventory[num201] = new Item();
								break;
							}
							break;
						}
						else
						{
							num201++;
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
			for (int j = 0; j < 10; j++)
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
		public static void SavePlayer(Player newPlayer, string playerPath)
		{
			try
			{
				/*if (Main.mapEnabled)
				{
					Map.saveMap();
				}*/
			}
			catch
			{
			}
			try
			{
				Directory.CreateDirectory(Main.PlayerPath);
			}
			catch
			{
			}
			if (Main.ServerSideCharacter)
			{
				return;
			}
			if (playerPath == null || playerPath == "")
			{
				return;
			}
			string destFileName = playerPath + ".bak";
			if (File.Exists(playerPath))
			{
				File.Copy(playerPath, destFileName, true);
			}
			string text = playerPath + ".dat";
			using (FileStream fileStream = new FileStream(text, FileMode.Create))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
				{
					binaryWriter.Write(Main.curRelease);
					binaryWriter.Write(newPlayer.name);
					binaryWriter.Write(newPlayer.difficulty);
					binaryWriter.Write(newPlayer.hair);
					binaryWriter.Write(newPlayer.male);
					binaryWriter.Write(newPlayer.statLife);
					binaryWriter.Write(newPlayer.statLifeMax);
					binaryWriter.Write(newPlayer.statMana);
					binaryWriter.Write(newPlayer.statManaMax);
					binaryWriter.Write(newPlayer.hairColor.R);
					binaryWriter.Write(newPlayer.hairColor.G);
					binaryWriter.Write(newPlayer.hairColor.B);
					binaryWriter.Write(newPlayer.skinColor.R);
					binaryWriter.Write(newPlayer.skinColor.G);
					binaryWriter.Write(newPlayer.skinColor.B);
					binaryWriter.Write(newPlayer.eyeColor.R);
					binaryWriter.Write(newPlayer.eyeColor.G);
					binaryWriter.Write(newPlayer.eyeColor.B);
					binaryWriter.Write(newPlayer.shirtColor.R);
					binaryWriter.Write(newPlayer.shirtColor.G);
					binaryWriter.Write(newPlayer.shirtColor.B);
					binaryWriter.Write(newPlayer.underShirtColor.R);
					binaryWriter.Write(newPlayer.underShirtColor.G);
					binaryWriter.Write(newPlayer.underShirtColor.B);
					binaryWriter.Write(newPlayer.pantsColor.R);
					binaryWriter.Write(newPlayer.pantsColor.G);
					binaryWriter.Write(newPlayer.pantsColor.B);
					binaryWriter.Write(newPlayer.shoeColor.R);
					binaryWriter.Write(newPlayer.shoeColor.G);
					binaryWriter.Write(newPlayer.shoeColor.B);
					for (int i = 0; i < 11; i++)
					{
						if (newPlayer.armor[i].name == null)
						{
							newPlayer.armor[i].name = "";
						}
						binaryWriter.Write(newPlayer.armor[i].netID);
						binaryWriter.Write(newPlayer.armor[i].prefix);
					}
					for (int j = 0; j < 3; j++)
					{
						binaryWriter.Write(newPlayer.dye[j].netID);
						binaryWriter.Write(newPlayer.dye[j].prefix);
					}
					for (int k = 0; k < 58; k++)
					{
						if (newPlayer.inventory[k].name == null)
						{
							newPlayer.inventory[k].name = "";
						}
						binaryWriter.Write(newPlayer.inventory[k].netID);
						binaryWriter.Write(newPlayer.inventory[k].stack);
						binaryWriter.Write(newPlayer.inventory[k].prefix);
					}
					for (int l = 0; l < Chest.maxItems; l++)
					{
						if (newPlayer.bank[l].name == null)
						{
							newPlayer.bank[l].name = "";
						}
						binaryWriter.Write(newPlayer.bank[l].netID);
						binaryWriter.Write(newPlayer.bank[l].stack);
						binaryWriter.Write(newPlayer.bank[l].prefix);
					}
					for (int m = 0; m < Chest.maxItems; m++)
					{
						if (newPlayer.bank2[m].name == null)
						{
							newPlayer.bank2[m].name = "";
						}
						binaryWriter.Write(newPlayer.bank2[m].netID);
						binaryWriter.Write(newPlayer.bank2[m].stack);
						binaryWriter.Write(newPlayer.bank2[m].prefix);
					}
					for (int n = 0; n < 10; n++)
					{
						binaryWriter.Write(newPlayer.buffType[n]);
						binaryWriter.Write(newPlayer.buffTime[n]);
					}
					for (int num = 0; num < 200; num++)
					{
						if (newPlayer.spN[num] == null)
						{
							binaryWriter.Write(-1);
							break;
						}
						binaryWriter.Write(newPlayer.spX[num]);
						binaryWriter.Write(newPlayer.spY[num]);
						binaryWriter.Write(newPlayer.spI[num]);
						binaryWriter.Write(newPlayer.spN[num]);
					}
					binaryWriter.Write(newPlayer.hbLocked);
					binaryWriter.Close();
				}
			}
			Player.EncryptFile(text, playerPath);
			File.Delete(text);
		}
		public static Player LoadPlayer(string playerPath)
		{
			bool flag = false;
			if (Main.rand == null)
			{
				Main.rand = new Random((int)DateTime.Now.Ticks);
			}
			Player player = new Player();
			try
			{
				string text = playerPath + ".dat";
				flag = Player.DecryptFile(playerPath, text);
				if (!flag)
				{
					using (FileStream fileStream = new FileStream(text, FileMode.Open))
					{
						using (BinaryReader binaryReader = new BinaryReader(fileStream))
						{
							int num = binaryReader.ReadInt32();
							player.name = binaryReader.ReadString();
							if (num >= 10)
							{
								if (num >= 17)
								{
									player.difficulty = binaryReader.ReadByte();
								}
								else
								{
									bool flag2 = binaryReader.ReadBoolean();
									if (flag2)
									{
										player.difficulty = 2;
									}
								}
							}
							player.hair = binaryReader.ReadInt32();
							if (num <= 17)
							{
								if (player.hair == 5 || player.hair == 6 || player.hair == 9 || player.hair == 11)
								{
									player.male = false;
								}
								else
								{
									player.male = true;
								}
							}
							else
							{
								player.male = binaryReader.ReadBoolean();
							}
							player.statLife = binaryReader.ReadInt32();
							player.statLifeMax = binaryReader.ReadInt32();
							if (player.statLifeMax > 500)
							{
								player.statLifeMax = 500;
							}
							if (player.statLife > player.statLifeMax)
							{
								player.statLife = player.statLifeMax;
							}
							player.statMana = binaryReader.ReadInt32();
							player.statManaMax = binaryReader.ReadInt32();
							if (player.statManaMax > 200)
							{
								player.statManaMax = 200;
							}
							if (player.statMana > 400)
							{
								player.statMana = 400;
							}
							player.hairColor.R = binaryReader.ReadByte();
							player.hairColor.G = binaryReader.ReadByte();
							player.hairColor.B = binaryReader.ReadByte();
							player.skinColor.R = binaryReader.ReadByte();
							player.skinColor.G = binaryReader.ReadByte();
							player.skinColor.B = binaryReader.ReadByte();
							player.eyeColor.R = binaryReader.ReadByte();
							player.eyeColor.G = binaryReader.ReadByte();
							player.eyeColor.B = binaryReader.ReadByte();
							player.shirtColor.R = binaryReader.ReadByte();
							player.shirtColor.G = binaryReader.ReadByte();
							player.shirtColor.B = binaryReader.ReadByte();
							player.underShirtColor.R = binaryReader.ReadByte();
							player.underShirtColor.G = binaryReader.ReadByte();
							player.underShirtColor.B = binaryReader.ReadByte();
							player.pantsColor.R = binaryReader.ReadByte();
							player.pantsColor.G = binaryReader.ReadByte();
							player.pantsColor.B = binaryReader.ReadByte();
							player.shoeColor.R = binaryReader.ReadByte();
							player.shoeColor.G = binaryReader.ReadByte();
							player.shoeColor.B = binaryReader.ReadByte();
							Main.player[Main.myPlayer].shirtColor = player.shirtColor;
							Main.player[Main.myPlayer].pantsColor = player.pantsColor;
							Main.player[Main.myPlayer].hairColor = player.hairColor;
							if (num >= 38)
							{
								for (int i = 0; i < 11; i++)
								{
									player.armor[i].netDefaults(binaryReader.ReadInt32());
									player.armor[i].Prefix((int)binaryReader.ReadByte());
								}
								if (num >= 47)
								{
									for (int j = 0; j < 3; j++)
									{
										player.dye[j].netDefaults(binaryReader.ReadInt32());
										player.dye[j].Prefix((int)binaryReader.ReadByte());
									}
								}
								if (num >= 58)
								{
									for (int k = 0; k < 58; k++)
									{
										int num2 = binaryReader.ReadInt32();
										if (num2 >= 1858)
										{
											player.inventory[k].netDefaults(0);
										}
										else
										{
											player.inventory[k].netDefaults(num2);
											player.inventory[k].stack = binaryReader.ReadInt32();
											player.inventory[k].Prefix((int)binaryReader.ReadByte());
										}
									}
								}
								else
								{
									for (int l = 0; l < 48; l++)
									{
										int num3 = binaryReader.ReadInt32();
										if (num3 >= 1858)
										{
											player.inventory[l].netDefaults(0);
										}
										else
										{
											player.inventory[l].netDefaults(num3);
											player.inventory[l].stack = binaryReader.ReadInt32();
											player.inventory[l].Prefix((int)binaryReader.ReadByte());
										}
									}
								}
								if (num >= 58)
								{
									for (int m = 0; m < 40; m++)
									{
										player.bank[m].netDefaults(binaryReader.ReadInt32());
										player.bank[m].stack = binaryReader.ReadInt32();
										player.bank[m].Prefix((int)binaryReader.ReadByte());
									}
									for (int n = 0; n < 40; n++)
									{
										player.bank2[n].netDefaults(binaryReader.ReadInt32());
										player.bank2[n].stack = binaryReader.ReadInt32();
										player.bank2[n].Prefix((int)binaryReader.ReadByte());
									}
								}
								else
								{
									for (int num4 = 0; num4 < 20; num4++)
									{
										player.bank[num4].netDefaults(binaryReader.ReadInt32());
										player.bank[num4].stack = binaryReader.ReadInt32();
										player.bank[num4].Prefix((int)binaryReader.ReadByte());
									}
									for (int num5 = 0; num5 < 20; num5++)
									{
										player.bank2[num5].netDefaults(binaryReader.ReadInt32());
										player.bank2[num5].stack = binaryReader.ReadInt32();
										player.bank2[num5].Prefix((int)binaryReader.ReadByte());
									}
								}
							}
							else
							{
								for (int num6 = 0; num6 < 8; num6++)
								{
									player.armor[num6].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
									if (num >= 36)
									{
										player.armor[num6].Prefix((int)binaryReader.ReadByte());
									}
								}
								if (num >= 6)
								{
									for (int num7 = 8; num7 < 11; num7++)
									{
										player.armor[num7].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
										if (num >= 36)
										{
											player.armor[num7].Prefix((int)binaryReader.ReadByte());
										}
									}
								}
								for (int num8 = 0; num8 < 44; num8++)
								{
									player.inventory[num8].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
									player.inventory[num8].stack = binaryReader.ReadInt32();
									if (num >= 36)
									{
										player.inventory[num8].Prefix((int)binaryReader.ReadByte());
									}
								}
								if (num >= 15)
								{
									for (int num9 = 44; num9 < 48; num9++)
									{
										player.inventory[num9].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
										player.inventory[num9].stack = binaryReader.ReadInt32();
										if (num >= 36)
										{
											player.inventory[num9].Prefix((int)binaryReader.ReadByte());
										}
									}
								}
								for (int num10 = 0; num10 < 20; num10++)
								{
									player.bank[num10].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
									player.bank[num10].stack = binaryReader.ReadInt32();
									if (num >= 36)
									{
										player.bank[num10].Prefix((int)binaryReader.ReadByte());
									}
								}
								if (num >= 20)
								{
									for (int num11 = 0; num11 < 20; num11++)
									{
										player.bank2[num11].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
										player.bank2[num11].stack = binaryReader.ReadInt32();
										if (num >= 36)
										{
											player.bank2[num11].Prefix((int)binaryReader.ReadByte());
										}
									}
								}
							}
							if (num < 58)
							{
								for (int num12 = 40; num12 < 48; num12++)
								{
									player.inventory[num12 + 10] = (Item)player.inventory[num12].Clone();
									player.inventory[num12].SetDefaults(0, false);
								}
							}
							if (num >= 11)
							{
								for (int num13 = 0; num13 < 10; num13++)
								{
									player.buffType[num13] = binaryReader.ReadInt32();
									player.buffTime[num13] = binaryReader.ReadInt32();
								}
							}
							for (int num14 = 0; num14 < 200; num14++)
							{
								int num15 = binaryReader.ReadInt32();
								if (num15 == -1)
								{
									break;
								}
								player.spX[num14] = num15;
								player.spY[num14] = binaryReader.ReadInt32();
								player.spI[num14] = binaryReader.ReadInt32();
								player.spN[num14] = binaryReader.ReadString();
							}
							if (num >= 16)
							{
								player.hbLocked = binaryReader.ReadBoolean();
							}
							binaryReader.Close();
						}
					}
					player.PlayerFrame();
					File.Delete(text);
					Player result = player;
					return result;
				}
			}
			catch
			{
				flag = true;
			}
			if (flag)
			{
				try
				{
					string text2 = playerPath + ".bak";
					Player result;
					if (File.Exists(text2))
					{
						File.Delete(playerPath);
						File.Move(text2, playerPath);
						result = Player.LoadPlayer(playerPath);
						return result;
					}
					result = new Player();
					return result;
				}
				catch
				{
					Player result = new Player();
					return result;
				}
			}
			return new Player();
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
			if (this.noItems)
			{
				return;
			}
			int num = -1;
			for (int i = 0; i < 58; i++)
			{
				if (this.inventory[i].shoot == 13 || this.inventory[i].shoot == 32 || this.inventory[i].shoot == 73 || this.inventory[i].shoot == 165 || (this.inventory[i].shoot >= 230 && this.inventory[i].shoot <= 235) || this.inventory[i].shoot == 256 || this.inventory[i].shoot == 315 || this.inventory[i].shoot == 322)
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
				if (num4 == 13 || num4 == 32 || num4 == 315 || (num4 >= 230 && num4 <= 235))
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
