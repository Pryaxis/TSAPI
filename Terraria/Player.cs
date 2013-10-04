

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
		public bool[] buffImmune = new bool[81];
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
		public bool[] adjTile = new bool[251];
		public bool[] oldAdjTile = new bool[251];
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
				if (Main.player[j].active && !Main.player[j].dead && (num == -1f || Math.Abs(Main.player[j].position.X + (float)(Main.player[j].width / 2) - Position.X + (float)(Width / 2)) + Math.Abs(Main.player[j].position.Y + (float)(Main.player[j].height / 2) - Position.Y + (float)(Height / 2)) < num))
				{
					num = Math.Abs(Main.player[j].position.X + (float)(Main.player[j].width / 2) - Position.X + (float)(Width / 2)) + Math.Abs(Main.player[j].position.Y + (float)(Main.player[j].height / 2) - Position.Y + (float)(Height / 2));
					result = (byte)j;
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
				else
				{
					if (Main.rand.Next(3) == 0)
					{
						Main.npc[i].AddBuff(24, 120, false);
					}
					else
					{
						Main.npc[i].AddBuff(24, 60, false);
					}
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
			else
			{
				if (type == 122)
				{
					if (Main.rand.Next(10) == 0)
					{
						Main.npc[i].AddBuff(24, 180, false);
						return;
					}
				}
				else
				{
					if (type == 190)
					{
						if (Main.rand.Next(4) == 0)
						{
							Main.npc[i].AddBuff(20, 420, false);
							return;
						}
					}
					else
					{
						if (type == 217)
						{
							if (Main.rand.Next(5) == 0)
							{
								Main.npc[i].AddBuff(24, 180, false);
								return;
							}
						}
						else
						{
							if (type == 1123 && Main.rand.Next(10) != 0)
							{
								Main.npc[i].AddBuff(31, 120, false);
							}
						}
					}
				}
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
				else
				{
					if (Main.rand.Next(3) == 0)
					{
						Main.player[i].AddBuff(24, 120, true);
					}
					else
					{
						Main.player[i].AddBuff(24, 60, true);
					}
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
			else
			{
				if (type == 122)
				{
					if (Main.rand.Next(10) == 0)
					{
						Main.player[i].AddBuff(24, 180, false);
						return;
					}
				}
				else
				{
					if (type == 190)
					{
						if (Main.rand.Next(4) == 0)
						{
							Main.player[i].AddBuff(20, 420, false);
							return;
						}
					}
					else
					{
						if (type == 217)
						{
							if (Main.rand.Next(5) == 0)
							{
								Main.player[i].AddBuff(24, 180, false);
								return;
							}
						}
						else
						{
							if (type == 1123 && Main.rand.Next(9) != 0)
							{
								Main.player[i].AddBuff(31, 120, false);
							}
						}
					}
				}
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
			if (Main.hasFocus && !Main.chatMode && !Main.editSign)
			{
				/*Keys[] pressedKeys = Main.keyState.GetPressedKeys();
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
				}*/
			}
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
			else
			{
				if (this.controlDown)
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
				else
				{
					if ((double)this.velocity.Y < -0.1 || (double)this.velocity.Y > 0.1)
					{
						this.velocity.Y = this.velocity.Y * 0.9f;
					}
					else
					{
						this.velocity.Y = 0f;
					}
				}
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
			else
			{
				if (this.controlRight && !this.controlLeft)
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
				else
				{
					if ((double)this.velocity.X < -0.1 || (double)this.velocity.X > 0.1)
					{
						this.velocity.X = this.velocity.X * 0.9f;
					}
					else
					{
						this.velocity.X = 0f;
					}
				}
			}
			this.position += this.velocity;
			this.ghostFrameCounter++;
			if (this.velocity.X < 0f)
			{
				this.direction = -1;
			}
			else
			{
				if (this.velocity.X > 0f)
				{
					this.direction = 1;
				}
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
			if (this.wings == 12)
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
				if (x >= this.position.X + (float)(this.width / 2))
				{
					goto IL_9C;
				}
				IL_9C:
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
				else
				{
					if (this.merman)
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
					else
					{
						if (Main.tile[num7 - 3, num8] == null)
						{
							flag = true;
						}
						else
						{
							if (Main.tile[num7 + 3, num8] == null)
							{
								flag = true;
							}
							else
							{
								if (Main.tile[num7, num8 - 3] == null)
								{
									flag = true;
								}
								else
								{
									if (Main.tile[num7, num8 + 3] == null)
									{
										flag = true;
									}
								}
							}
						}
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
				else
				{
					if (this.shadowCount == 2)
					{
						this.shadowPos[1] = this.shadowPos[0];
					}
					else
					{
						if (this.shadowCount >= 3)
						{
							this.shadowCount = 0;
							this.shadowPos[0] = this.position;
							Vector2[] expr_306_cp_0 = this.shadowPos;
							int expr_306_cp_1 = 0;
							expr_306_cp_0[expr_306_cp_1].Y = expr_306_cp_0[expr_306_cp_1].Y + this.gfxOffY;
						}
					}
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
					else
					{
						if ((float)Main.rand.Next(100) <= 100f * this.teleportTime * 2f)
						{
							int num12 = Dust.NewDust(new Vector2((float)this.getRect().X, (float)this.getRect().Y), this.getRect().Width, this.getRect().Height, 159, 0f, 0f, 0, default(Color), 1f);
							Main.dust[num12].scale = this.teleportTime * 1.5f;
							Main.dust[num12].noGravity = true;
							Main.dust[num12].velocity *= 1.1f;
						}
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
					if (i == Main.myPlayer)
					{/*
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
									else
									{
										if (Main.mapStyle == 2)
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
								else
								{
									if (!Main.playerInventory)
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
						}
						if (this.selectedItem == 58)
						{
							this.nonTorch = -1;
						}
						else
						{
							if (this.controlTorch && this.itemAnimation == 0)
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
											else
											{
												if (Main.tileHammer[type])
												{
													num18 = 1;
												}
												else
												{
													if (Main.tileAxe[type])
													{
														num18 = 2;
													}
													else
													{
														num18 = 3;
													}
												}
											}
										}
										else
										{
											if (Main.tile[num19, num20].liquid > 0 && this.wet)
											{
												num18 = 4;
											}
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
									else
									{
										if (num18 == 1)
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
										else
										{
											if (num18 == 2)
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
											else
											{
												if (num18 == 3)
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
												else
												{
													if (num18 == 4)
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
														else
														{
															if (type2 == 930)
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
															else
															{
																if (type2 == 282 || type2 == 286 || type2 == 523 || type2 == 1333)
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
													else
													{
														if (num18 == 5)
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
															else
															{
																if (type2 == 930)
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
																else
																{
																	if (type2 == 282 || type2 == 286)
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
														else
														{
															if (num18 == 6)
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
												}
											}
										}
									}
								}
							}
							else
							{
								if (this.nonTorch > -1 && this.itemAnimation == 0)
								{
									this.selectedItem = this.nonTorch;
									this.nonTorch = -1;
								}
							}
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
					*/}
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
						else
						{
							if (this.immuneAlpha >= 205)
							{
								this.immuneAlphaDirection = -1;
							}
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
					this.truffle = false;
					this.shadowDodge = false;
					this.palladiumRegen = false;
					this.onHitDodge = false;
					this.onHitRegen = false;
					this.onHitPetal = false;
					this.iceBarrier = false;
					this.maxMinions = 1;
					this.penguin = false;
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
					this.paladinBuff = false;
					this.paladinGive = false;
					this.meleeCrit += this.inventory[this.selectedItem].crit;
					this.magicCrit += this.inventory[this.selectedItem].crit;
					this.rangedCrit += this.inventory[this.selectedItem].crit;
					if (this.whoAmi == Main.myPlayer)
					{
						Main.musicBox2 = -1;
					}
					for (int num29 = 0; num29 < 81; num29++)
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
							else
							{
								if (this.buffType[num30] == 2)
								{
									this.lifeRegen += 2;
								}
								else
								{
									if (this.buffType[num30] == 3)
									{
										this.moveSpeed += 0.25f;
									}
									else
									{
										if (this.buffType[num30] == 4)
										{
											this.gills = true;
										}
										else
										{
											if (this.buffType[num30] == 5)
											{
												this.statDefense += 8;
											}
											else
											{
												if (this.buffType[num30] == 6)
												{
													this.manaRegenBuff = true;
												}
												else
												{
													if (this.buffType[num30] == 7)
													{
														this.magicDamage += 0.2f;
													}
													else
													{
														if (this.buffType[num30] == 8)
														{
															this.slowFall = true;
														}
														else
														{
															if (this.buffType[num30] == 9)
															{
																this.findTreasure = true;
															}
															else
															{
																if (this.buffType[num30] == 10)
																{
																	this.invis = true;
																}
																else
																{
																	if (this.buffType[num30] == 11)
																	{
																		Lighting.addLight((int)(this.position.X + (float)(this.width / 2)) / 16, (int)(this.position.Y + (float)(this.height / 2)) / 16, 0.8f, 0.95f, 1f);
																	}
																	else
																	{
																		if (this.buffType[num30] == 12)
																		{
																			this.nightVision = true;
																		}
																		else
																		{
																			if (this.buffType[num30] == 13)
																			{
																				this.enemySpawns = true;
																			}
																			else
																			{
																				if (this.buffType[num30] == 14)
																				{
																					this.thorns = true;
																				}
																				else
																				{
																					if (this.buffType[num30] == 15)
																					{
																						this.waterWalk = true;
																					}
																					else
																					{
																						if (this.buffType[num30] == 16)
																						{
																							this.archery = true;
																						}
																						else
																						{
																							if (this.buffType[num30] == 17)
																							{
																								this.detectCreature = true;
																							}
																							else
																							{
																								if (this.buffType[num30] == 18)
																								{
																									this.gravControl = true;
																								}
																								else
																								{
																									if (this.buffType[num30] == 30)
																									{
																										this.bleed = true;
																									}
																									else
																									{
																										if (this.buffType[num30] == 31)
																										{
																											this.confused = true;
																										}
																										else
																										{
																											if (this.buffType[num30] == 32)
																											{
																												this.slow = true;
																											}
																											else
																											{
																												if (this.buffType[num30] == 35)
																												{
																													this.silence = true;
																												}
																												else
																												{
																													if (this.buffType[num30] == 46)
																													{
																														this.chilled = true;
																													}
																													else
																													{
																														if (this.buffType[num30] == 47)
																														{
																															this.frozen = true;
																														}
																														else
																														{
																															if (this.buffType[num30] == 69)
																															{
																																this.ichor = true;
																																this.statDefense -= 20;
																															}
																															else
																															{
																																if (this.buffType[num30] == 36)
																																{
																																	this.brokenArmor = true;
																																}
																																else
																																{
																																	if (this.buffType[num30] == 48)
																																	{
																																		this.honey = true;
																																	}
																																	else
																																	{
																																		if (this.buffType[num30] == 59)
																																		{
																																			this.shadowDodge = true;
																																		}
																																		else
																																		{
																																			if (this.buffType[num30] == 58)
																																			{
																																				this.palladiumRegen = true;
																																			}
																																			else
																																			{
																																				if (this.buffType[num30] == 63)
																																				{
																																					this.moveSpeed += 1f;
																																				}
																																				else
																																				{
																																					if (this.buffType[num30] == 62)
																																					{
																																						if ((double)this.statLife <= (double)this.statLifeMax * 0.25)
																																						{
																																							Lighting.addLight((int)(this.Center().X / 16f), (int)(this.Center().Y / 16f), 0.1f, 0.2f, 0.45f);
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
																																					else
																																					{
																																						if (this.buffType[num30] == 49)
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
																																						else
																																						{
																																							if (this.buffType[num30] == 64)
																																							{
																																								if (Main.myPlayer == i)
																																								{
																																									for (int num32 = 0; num32 < 1000; num32++)
																																									{
																																										if (Main.projectile[num32].active && Main.projectile[num32].owner == i && Main.projectile[num32].type == 266)
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
																																							else
																																							{
																																								if (this.buffType[num30] == 37)
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
																																								else
																																								{
																																									if (this.buffType[num30] == 38)
																																									{
																																										this.buffTime[num30] = 10;
																																										this.tongued = true;
																																									}
																																									else
																																									{
																																										if (this.buffType[num30] == 19)
																																										{
																																											this.buffTime[num30] = 18000;
																																											this.lightOrb = true;
																																											bool flag9 = true;
																																											for (int num33 = 0; num33 < 1000; num33++)
																																											{
																																												if (Main.projectile[num33].active && Main.projectile[num33].owner == this.whoAmi && Main.projectile[num33].type == 18)
																																												{
																																													flag9 = false;
																																												}
																																											}
																																											if (flag9)
																																											{
																																												Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 18, 0, 0f, this.whoAmi, 0f, 0f);
																																											}
																																										}
																																										else
																																										{
																																											if (this.buffType[num30] == 27)
																																											{
																																												this.buffTime[num30] = 18000;
																																												this.fairy = true;
																																												bool flag10 = true;
																																												for (int num34 = 0; num34 < 1000; num34++)
																																												{
																																													if (Main.projectile[num34].active && Main.projectile[num34].owner == this.whoAmi && (Main.projectile[num34].type == 72 || Main.projectile[num34].type == 86 || Main.projectile[num34].type == 87))
																																													{
																																														flag10 = false;
																																														break;
																																													}
																																												}
																																												if (flag10)
																																												{
																																													int num35 = Main.rand.Next(3);
																																													if (num35 == 0)
																																													{
																																														num35 = 72;
																																													}
																																													else
																																													{
																																														if (num35 == 1)
																																														{
																																															num35 = 86;
																																														}
																																														else
																																														{
																																															if (num35 == 2)
																																															{
																																																num35 = 87;
																																															}
																																														}
																																													}
																																													if (this.head == 45 && this.body == 26 && this.legs == 25)
																																													{
																																														num35 = 72;
																																													}
																																													Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, num35, 0, 0f, this.whoAmi, 0f, 0f);
																																												}
																																											}
																																											else
																																											{
																																												if (this.buffType[num30] == 40)
																																												{
																																													this.buffTime[num30] = 18000;
																																													this.bunny = true;
																																													bool flag11 = true;
																																													for (int num36 = 0; num36 < 1000; num36++)
																																													{
																																														if (Main.projectile[num36].active && Main.projectile[num36].owner == this.whoAmi && Main.projectile[num36].type == 111)
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
																																												else
																																												{
																																													if (this.buffType[num30] == 41)
																																													{
																																														this.buffTime[num30] = 18000;
																																														this.penguin = true;
																																														bool flag12 = true;
																																														for (int num37 = 0; num37 < 1000; num37++)
																																														{
																																															if (Main.projectile[num37].active && Main.projectile[num37].owner == this.whoAmi && Main.projectile[num37].type == 112)
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
																																													else
																																													{
																																														if (this.buffType[num30] == 61)
																																														{
																																															this.buffTime[num30] = 18000;
																																															this.dino = true;
																																															bool flag13 = true;
																																															for (int num38 = 0; num38 < 1000; num38++)
																																															{
																																																if (Main.projectile[num38].active && Main.projectile[num38].owner == this.whoAmi && Main.projectile[num38].type == 236)
																																																{
																																																	flag13 = false;
																																																	break;
																																																}
																																															}
																																															if (flag13)
																																															{
																																																Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 236, 0, 0f, this.whoAmi, 0f, 0f);
																																															}
																																														}
																																														else
																																														{
																																															if (this.buffType[num30] == 65)
																																															{
																																																this.buffTime[num30] = 18000;
																																																this.eyeSpring = true;
																																																bool flag14 = true;
																																																for (int num39 = 0; num39 < 1000; num39++)
																																																{
																																																	if (Main.projectile[num39].active && Main.projectile[num39].owner == this.whoAmi && Main.projectile[num39].type == 268)
																																																	{
																																																		flag14 = false;
																																																		break;
																																																	}
																																																}
																																																if (flag14)
																																																{
																																																	Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 268, 0, 0f, this.whoAmi, 0f, 0f);
																																																}
																																															}
																																															else
																																															{
																																																if (this.buffType[num30] == 66)
																																																{
																																																	this.buffTime[num30] = 18000;
																																																	this.snowman = true;
																																																	bool flag15 = true;
																																																	for (int num40 = 0; num40 < 1000; num40++)
																																																	{
																																																		if (Main.projectile[num40].active && Main.projectile[num40].owner == this.whoAmi && Main.projectile[num40].type == 269)
																																																		{
																																																			flag15 = false;
																																																			break;
																																																		}
																																																	}
																																																	if (flag15)
																																																	{
																																																		Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 269, 0, 0f, this.whoAmi, 0f, 0f);
																																																	}
																																																}
																																																else
																																																{
																																																	if (this.buffType[num30] == 42)
																																																	{
																																																		this.buffTime[num30] = 18000;
																																																		this.turtle = true;
																																																		bool flag16 = true;
																																																		for (int num41 = 0; num41 < 1000; num41++)
																																																		{
																																																			if (Main.projectile[num41].active && Main.projectile[num41].owner == this.whoAmi && Main.projectile[num41].type == 127)
																																																			{
																																																				flag16 = false;
																																																				break;
																																																			}
																																																		}
																																																		if (flag16)
																																																		{
																																																			Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 127, 0, 0f, this.whoAmi, 0f, 0f);
																																																		}
																																																	}
																																																	else
																																																	{
																																																		if (this.buffType[num30] == 45)
																																																		{
																																																			this.buffTime[num30] = 18000;
																																																			this.eater = true;
																																																			bool flag17 = true;
																																																			for (int num42 = 0; num42 < 1000; num42++)
																																																			{
																																																				if (Main.projectile[num42].active && Main.projectile[num42].owner == this.whoAmi && Main.projectile[num42].type == 175)
																																																				{
																																																					flag17 = false;
																																																					break;
																																																				}
																																																			}
																																																			if (flag17)
																																																			{
																																																				Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 175, 0, 0f, this.whoAmi, 0f, 0f);
																																																			}
																																																		}
																																																		else
																																																		{
																																																			if (this.buffType[num30] == 50)
																																																			{
																																																				this.buffTime[num30] = 18000;
																																																				this.skeletron = true;
																																																				bool flag18 = true;
																																																				for (int num43 = 0; num43 < 1000; num43++)
																																																				{
																																																					if (Main.projectile[num43].active && Main.projectile[num43].owner == this.whoAmi && Main.projectile[num43].type == 197)
																																																					{
																																																						flag18 = false;
																																																						break;
																																																					}
																																																				}
																																																				if (flag18)
																																																				{
																																																					Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 197, 0, 0f, this.whoAmi, 0f, 0f);
																																																				}
																																																			}
																																																			else
																																																			{
																																																				if (this.buffType[num30] == 51)
																																																				{
																																																					this.buffTime[num30] = 18000;
																																																					this.hornet = true;
																																																					bool flag19 = true;
																																																					for (int num44 = 0; num44 < 1000; num44++)
																																																					{
																																																						if (Main.projectile[num44].active && Main.projectile[num44].owner == this.whoAmi && Main.projectile[num44].type == 198)
																																																						{
																																																							flag19 = false;
																																																							break;
																																																						}
																																																					}
																																																					if (flag19)
																																																					{
																																																						Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 198, 0, 0f, this.whoAmi, 0f, 0f);
																																																					}
																																																				}
																																																				else
																																																				{
																																																					if (this.buffType[num30] == 52)
																																																					{
																																																						this.buffTime[num30] = 18000;
																																																						this.tiki = true;
																																																						bool flag20 = true;
																																																						for (int num45 = 0; num45 < 1000; num45++)
																																																						{
																																																							if (Main.projectile[num45].active && Main.projectile[num45].owner == this.whoAmi && Main.projectile[num45].type == 199)
																																																							{
																																																								flag20 = false;
																																																								break;
																																																							}
																																																						}
																																																						if (flag20)
																																																						{
																																																							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 199, 0, 0f, this.whoAmi, 0f, 0f);
																																																						}
																																																					}
																																																					else
																																																					{
																																																						if (this.buffType[num30] == 53)
																																																						{
																																																							this.buffTime[num30] = 18000;
																																																							this.lizard = true;
																																																							bool flag21 = true;
																																																							for (int num46 = 0; num46 < 1000; num46++)
																																																							{
																																																								if (Main.projectile[num46].active && Main.projectile[num46].owner == this.whoAmi && Main.projectile[num46].type == 200)
																																																								{
																																																									flag21 = false;
																																																									break;
																																																								}
																																																							}
																																																							if (flag21)
																																																							{
																																																								Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 200, 0, 0f, this.whoAmi, 0f, 0f);
																																																							}
																																																						}
																																																						else
																																																						{
																																																							if (this.buffType[num30] == 54)
																																																							{
																																																								this.buffTime[num30] = 18000;
																																																								this.parrot = true;
																																																								bool flag22 = true;
																																																								for (int num47 = 0; num47 < 1000; num47++)
																																																								{
																																																									if (Main.projectile[num47].active && Main.projectile[num47].owner == this.whoAmi && Main.projectile[num47].type == 208)
																																																									{
																																																										flag22 = false;
																																																										break;
																																																									}
																																																								}
																																																								if (flag22)
																																																								{
																																																									Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 208, 0, 0f, this.whoAmi, 0f, 0f);
																																																								}
																																																							}
																																																							else
																																																							{
																																																								if (this.buffType[num30] == 55)
																																																								{
																																																									this.buffTime[num30] = 18000;
																																																									this.truffle = true;
																																																									bool flag23 = true;
																																																									for (int num48 = 0; num48 < 1000; num48++)
																																																									{
																																																										if (Main.projectile[num48].active && Main.projectile[num48].owner == this.whoAmi && Main.projectile[num48].type == 209)
																																																										{
																																																											flag23 = false;
																																																											break;
																																																										}
																																																									}
																																																									if (flag23)
																																																									{
																																																										Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 209, 0, 0f, this.whoAmi, 0f, 0f);
																																																									}
																																																								}
																																																								else
																																																								{
																																																									if (this.buffType[num30] == 56)
																																																									{
																																																										this.buffTime[num30] = 18000;
																																																										this.sapling = true;
																																																										bool flag24 = true;
																																																										for (int num49 = 0; num49 < 1000; num49++)
																																																										{
																																																											if (Main.projectile[num49].active && Main.projectile[num49].owner == this.whoAmi && Main.projectile[num49].type == 210)
																																																											{
																																																												flag24 = false;
																																																												break;
																																																											}
																																																										}
																																																										if (flag24)
																																																										{
																																																											Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 210, 0, 0f, this.whoAmi, 0f, 0f);
																																																										}
																																																									}
																																																									else
																																																									{
																																																										if (this.buffType[num30] == 57)
																																																										{
																																																											this.buffTime[num30] = 18000;
																																																											this.wisp = true;
																																																											bool flag25 = true;
																																																											for (int num50 = 0; num50 < 1000; num50++)
																																																											{
																																																												if (Main.projectile[num50].active && Main.projectile[num50].owner == this.whoAmi && Main.projectile[num50].type == 211)
																																																												{
																																																													flag25 = false;
																																																													break;
																																																												}
																																																											}
																																																											if (flag25)
																																																											{
																																																												Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 211, 0, 0f, this.whoAmi, 0f, 0f);
																																																											}
																																																										}
																																																										else
																																																										{
																																																											if (this.buffType[num30] == 60)
																																																											{
																																																												this.buffTime[num30] = 18000;
																																																												this.crystalLeaf = true;
																																																												bool flag26 = true;
																																																												for (int num51 = 0; num51 < 1000; num51++)
																																																												{
																																																													if (Main.projectile[num51].active && Main.projectile[num51].owner == this.whoAmi && Main.projectile[num51].type == 226)
																																																													{
																																																														if (!flag26)
																																																														{
																																																															Main.projectile[num51].Kill();
																																																														}
																																																														flag26 = false;
																																																													}
																																																												}
																																																												if (flag26)
																																																												{
																																																													Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 226, 0, 0f, this.whoAmi, 0f, 0f);
																																																												}
																																																											}
																																																											else
																																																											{
																																																												if (this.buffType[num30] == 70)
																																																												{
																																																													this.venom = true;
																																																												}
																																																												else
																																																												{
																																																													if (this.buffType[num30] == 20)
																																																													{
																																																														this.poisoned = true;
																																																													}
																																																													else
																																																													{
																																																														if (this.buffType[num30] == 21)
																																																														{
																																																															this.potionDelay = this.buffTime[num30];
																																																														}
																																																														else
																																																														{
																																																															if (this.buffType[num30] == 22)
																																																															{
																																																																this.blind = true;
																																																															}
																																																															else
																																																															{
																																																																if (this.buffType[num30] == 80)
																																																																{
																																																																	this.blackout = true;
																																																																}
																																																																else
																																																																{
																																																																	if (this.buffType[num30] == 23)
																																																																	{
																																																																		this.noItems = true;
																																																																	}
																																																																	else
																																																																	{
																																																																		if (this.buffType[num30] == 24)
																																																																		{
																																																																			this.onFire = true;
																																																																		}
																																																																		else
																																																																		{
																																																																			if (this.buffType[num30] == 67)
																																																																			{
																																																																				this.burned = true;
																																																																			}
																																																																			else
																																																																			{
																																																																				if (this.buffType[num30] == 68)
																																																																				{
																																																																					this.suffocating = true;
																																																																				}
																																																																				else
																																																																				{
																																																																					if (this.buffType[num30] == 39)
																																																																					{
																																																																						this.onFire2 = true;
																																																																					}
																																																																					else
																																																																					{
																																																																						if (this.buffType[num30] == 44)
																																																																						{
																																																																							this.onFrostBurn = true;
																																																																						}
																																																																						else
																																																																						{
																																																																							if (this.buffType[num30] == 43)
																																																																							{
																																																																								this.paladinBuff = true;
																																																																							}
																																																																							else
																																																																							{
																																																																								if (this.buffType[num30] == 29)
																																																																								{
																																																																									this.magicCrit += 2;
																																																																									this.magicDamage += 0.05f;
																																																																									this.statManaMax2 += 20;
																																																																									this.manaCost -= 0.02f;
																																																																								}
																																																																								else
																																																																								{
																																																																									if (this.buffType[num30] == 28)
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
																																																																									else
																																																																									{
																																																																										if (this.buffType[num30] == 33)
																																																																										{
																																																																											this.meleeDamage -= 0.051f;
																																																																											this.meleeSpeed -= 0.051f;
																																																																											this.statDefense -= 4;
																																																																											this.moveSpeed -= 0.1f;
																																																																										}
																																																																										else
																																																																										{
																																																																											if (this.buffType[num30] == 25)
																																																																											{
																																																																												this.statDefense -= 4;
																																																																												this.meleeCrit += 2;
																																																																												this.meleeDamage += 0.1f;
																																																																												this.meleeSpeed += 0.1f;
																																																																											}
																																																																											else
																																																																											{
																																																																												if (this.buffType[num30] == 26)
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
																																																																												else
																																																																												{
																																																																													if (this.buffType[num30] == 71)
																																																																													{
																																																																														this.meleeEnchant = 1;
																																																																													}
																																																																													else
																																																																													{
																																																																														if (this.buffType[num30] == 73)
																																																																														{
																																																																															this.meleeEnchant = 2;
																																																																														}
																																																																														else
																																																																														{
																																																																															if (this.buffType[num30] == 74)
																																																																															{
																																																																																this.meleeEnchant = 3;
																																																																															}
																																																																															else
																																																																															{
																																																																																if (this.buffType[num30] == 75)
																																																																																{
																																																																																	this.meleeEnchant = 4;
																																																																																}
																																																																																else
																																																																																{
																																																																																	if (this.buffType[num30] == 76)
																																																																																	{
																																																																																		this.meleeEnchant = 5;
																																																																																	}
																																																																																	else
																																																																																	{
																																																																																		if (this.buffType[num30] == 77)
																																																																																		{
																																																																																			this.meleeEnchant = 6;
																																																																																		}
																																																																																		else
																																																																																		{
																																																																																			if (this.buffType[num30] == 78)
																																																																																			{
																																																																																				this.meleeEnchant = 7;
																																																																																			}
																																																																																			else
																																																																																			{
																																																																																				if (this.buffType[num30] == 79)
																																																																																				{
																																																																																					this.meleeEnchant = 8;
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
						for (int num52 = 0; num52 < 10; num52++)
						{
							if (this.buffType[num52] > 0 && this.buffTime[num52] <= 0)
							{
								this.DelBuff(num52);
							}
						}
					}
					this.doubleJump = false;
					for (int num53 = 0; num53 < 8; num53++)
					{
						this.statDefense += this.armor[num53].defense;
						this.lifeRegen += this.armor[num53].lifeRegen;
						if (this.armor[num53].type == 268)
						{
							this.accDivingHelm = true;
						}
						if (this.armor[num53].type == 238)
						{
							this.magicDamage += 0.15f;
						}
						if (this.armor[num53].type == 123 || this.armor[num53].type == 124 || this.armor[num53].type == 125)
						{
							this.magicDamage += 0.07f;
						}
						if (this.armor[num53].type == 151 || this.armor[num53].type == 152 || this.armor[num53].type == 153 || this.armor[num53].type == 959)
						{
							this.rangedDamage += 0.05f;
						}
						if (this.armor[num53].type == 111 || this.armor[num53].type == 228 || this.armor[num53].type == 229 || this.armor[num53].type == 230 || this.armor[num53].type == 960 || this.armor[num53].type == 961 || this.armor[num53].type == 962)
						{
							this.statManaMax2 += 20;
						}
						if (this.armor[num53].type == 982)
						{
							this.statManaMax2 += 20;
							this.manaRegenDelayBonus++;
							this.manaRegenBonus += 25;
						}
						if (this.armor[num53].type == 1595)
						{
							this.statManaMax2 += 20;
							this.magicCuffs = true;
						}
						if (this.armor[num53].type == 228 || this.armor[num53].type == 229 || this.armor[num53].type == 230)
						{
							this.magicCrit += 3;
						}
						if (this.armor[num53].type == 100 || this.armor[num53].type == 101 || this.armor[num53].type == 102)
						{
							this.meleeSpeed += 0.07f;
						}
						if (this.armor[num53].type == 956 || this.armor[num53].type == 957 || this.armor[num53].type == 958)
						{
							this.meleeSpeed += 0.07f;
						}
						if (this.armor[num53].type == 791 || this.armor[num53].type == 792 || this.armor[num53].type == 793)
						{
							this.meleeDamage += 0.02f;
							this.rangedDamage += 0.02f;
							this.magicDamage += 0.02f;
						}
						if (this.armor[num53].type == 371)
						{
							this.magicCrit += 9;
							this.statManaMax2 += 40;
						}
						if (this.armor[num53].type == 372)
						{
							this.moveSpeed += 0.07f;
							this.meleeSpeed += 0.12f;
						}
						if (this.armor[num53].type == 373)
						{
							this.rangedDamage += 0.1f;
							this.rangedCrit += 6;
						}
						if (this.armor[num53].type == 374)
						{
							this.magicCrit += 3;
							this.meleeCrit += 3;
							this.rangedCrit += 3;
						}
						if (this.armor[num53].type == 375)
						{
							this.moveSpeed += 0.1f;
						}
						if (this.armor[num53].type == 376)
						{
							this.magicDamage += 0.15f;
							this.statManaMax2 += 60;
						}
						if (this.armor[num53].type == 377)
						{
							this.meleeCrit += 5;
							this.meleeDamage += 0.1f;
						}
						if (this.armor[num53].type == 378)
						{
							this.rangedDamage += 0.12f;
							this.rangedCrit += 7;
						}
						if (this.armor[num53].type == 379)
						{
							this.rangedDamage += 0.05f;
							this.meleeDamage += 0.05f;
							this.magicDamage += 0.05f;
						}
						if (this.armor[num53].type == 380)
						{
							this.magicCrit += 3;
							this.meleeCrit += 3;
							this.rangedCrit += 3;
						}
						if (this.armor[num53].type == 400)
						{
							this.magicDamage += 0.11f;
							this.magicCrit += 11;
							this.statManaMax2 += 80;
						}
						if (this.armor[num53].type == 401)
						{
							this.meleeCrit += 7;
							this.meleeDamage += 0.14f;
						}
						if (this.armor[num53].type == 402)
						{
							this.rangedDamage += 0.14f;
							this.rangedCrit += 8;
						}
						if (this.armor[num53].type == 403)
						{
							this.rangedDamage += 0.06f;
							this.meleeDamage += 0.06f;
							this.magicDamage += 0.06f;
						}
						if (this.armor[num53].type == 404)
						{
							this.magicCrit += 4;
							this.meleeCrit += 4;
							this.rangedCrit += 4;
							this.moveSpeed += 0.05f;
						}
						if (this.armor[num53].type == 1205)
						{
							this.meleeDamage += 0.08f;
							this.meleeSpeed += 0.12f;
						}
						if (this.armor[num53].type == 1206)
						{
							this.rangedDamage += 0.09f;
							this.rangedCrit += 9;
						}
						if (this.armor[num53].type == 1207)
						{
							this.magicDamage += 0.07f;
							this.magicCrit += 7;
							this.statManaMax2 += 60;
						}
						if (this.armor[num53].type == 1208)
						{
							this.meleeDamage += 0.03f;
							this.rangedDamage += 0.03f;
							this.magicDamage += 0.03f;
							this.magicCrit += 2;
							this.meleeCrit += 2;
							this.rangedCrit += 2;
						}
						if (this.armor[num53].type == 1209)
						{
							this.meleeDamage += 0.02f;
							this.rangedDamage += 0.02f;
							this.magicDamage += 0.02f;
							this.magicCrit++;
							this.meleeCrit++;
							this.rangedCrit++;
						}
						if (this.armor[num53].type == 1210)
						{
							this.meleeDamage += 0.07f;
							this.meleeSpeed += 0.07f;
							this.moveSpeed += 0.07f;
						}
						if (this.armor[num53].type == 1211)
						{
							this.rangedCrit += 15;
							this.moveSpeed += 0.08f;
						}
						if (this.armor[num53].type == 1212)
						{
							this.magicCrit += 18;
							this.statManaMax2 += 80;
						}
						if (this.armor[num53].type == 1213)
						{
							this.magicCrit += 6;
							this.meleeCrit += 6;
							this.rangedCrit += 6;
						}
						if (this.armor[num53].type == 1214)
						{
							this.moveSpeed += 0.11f;
						}
						if (this.armor[num53].type == 1215)
						{
							this.meleeDamage += 0.08f;
							this.meleeCrit += 8;
							this.meleeSpeed += 0.08f;
						}
						if (this.armor[num53].type == 1216)
						{
							this.rangedDamage += 0.16f;
							this.rangedCrit += 7;
						}
						if (this.armor[num53].type == 1217)
						{
							this.magicDamage += 0.16f;
							this.magicCrit += 7;
							this.statManaMax2 += 100;
						}
						if (this.armor[num53].type == 1218)
						{
							this.meleeDamage += 0.04f;
							this.rangedDamage += 0.04f;
							this.magicDamage += 0.04f;
							this.magicCrit += 3;
							this.meleeCrit += 3;
							this.rangedCrit += 3;
						}
						if (this.armor[num53].type == 1219)
						{
							this.meleeDamage += 0.03f;
							this.rangedDamage += 0.03f;
							this.magicDamage += 0.03f;
							this.magicCrit += 3;
							this.meleeCrit += 3;
							this.rangedCrit += 3;
							this.moveSpeed += 0.06f;
						}
						if (this.armor[num53].type == 558)
						{
							this.magicDamage += 0.12f;
							this.magicCrit += 12;
							this.statManaMax2 += 100;
						}
						if (this.armor[num53].type == 559)
						{
							this.meleeCrit += 10;
							this.meleeDamage += 0.1f;
							this.meleeSpeed += 0.1f;
						}
						if (this.armor[num53].type == 553)
						{
							this.rangedDamage += 0.15f;
							this.rangedCrit += 8;
						}
						if (this.armor[num53].type == 551)
						{
							this.magicCrit += 7;
							this.meleeCrit += 7;
							this.rangedCrit += 7;
						}
						if (this.armor[num53].type == 552)
						{
							this.rangedDamage += 0.07f;
							this.meleeDamage += 0.07f;
							this.magicDamage += 0.07f;
							this.moveSpeed += 0.08f;
						}
						if (this.armor[num53].type == 1001)
						{
							this.meleeDamage += 0.16f;
							this.meleeCrit += 6;
						}
						if (this.armor[num53].type == 1002)
						{
							this.rangedDamage += 0.16f;
							this.ammoCost80 = true;
						}
						if (this.armor[num53].type == 1003)
						{
							this.statManaMax2 += 80;
							this.manaCost -= 0.17f;
							this.magicDamage += 0.16f;
						}
						if (this.armor[num53].type == 1004)
						{
							this.meleeDamage += 0.05f;
							this.magicDamage += 0.05f;
							this.rangedDamage += 0.05f;
							this.magicCrit += 7;
							this.meleeCrit += 7;
							this.rangedCrit += 7;
						}
						if (this.armor[num53].type == 1005)
						{
							this.magicCrit += 8;
							this.meleeCrit += 8;
							this.rangedCrit += 8;
							this.moveSpeed += 0.05f;
						}
						if (this.armor[num53].type == 1503)
						{
							this.statManaMax2 += 80;
							this.manaCost -= 0.17f;
							this.magicDamage += 0.1f;
							this.magicCrit += 10;
						}
						if (this.armor[num53].type == 1504)
						{
							this.magicDamage += 0.07f;
							this.magicCrit += 7;
						}
						if (this.armor[num53].type == 1505)
						{
							this.magicDamage += 0.08f;
							this.moveSpeed += 0.08f;
						}
						if (this.armor[num53].type == 1546)
						{
							this.rangedCrit += 5;
							this.arrowDamage += 0.15f;
						}
						if (this.armor[num53].type == 1547)
						{
							this.rangedCrit += 5;
							this.bulletDamage += 0.15f;
						}
						if (this.armor[num53].type == 1548)
						{
							this.rangedCrit += 5;
							this.rocketDamage += 0.15f;
						}
						if (this.armor[num53].type == 1549)
						{
							this.rangedCrit += 13;
							this.rangedDamage += 0.13f;
							this.ammoCost80 = true;
						}
						if (this.armor[num53].type == 1550)
						{
							this.rangedCrit += 7;
							this.moveSpeed += 0.12f;
						}
						if (this.armor[num53].type == 1282)
						{
							this.statManaMax2 += 20;
							this.manaCost -= 0.05f;
						}
						if (this.armor[num53].type == 1283)
						{
							this.statManaMax2 += 40;
							this.manaCost -= 0.07f;
						}
						if (this.armor[num53].type == 1284)
						{
							this.statManaMax2 += 40;
							this.manaCost -= 0.09f;
						}
						if (this.armor[num53].type == 1285)
						{
							this.statManaMax2 += 60;
							this.manaCost -= 0.11f;
						}
						if (this.armor[num53].type == 1286)
						{
							this.statManaMax2 += 60;
							this.manaCost -= 0.13f;
						}
						if (this.armor[num53].type == 1287)
						{
							this.statManaMax2 += 80;
							this.manaCost -= 0.15f;
						}
						if (this.armor[num53].type == 1316 || this.armor[num53].type == 1317 || this.armor[num53].type == 1318)
						{
							this.aggro += 200;
						}
						if (this.armor[num53].type == 1316)
						{
							this.meleeDamage += 0.06f;
						}
						if (this.armor[num53].type == 1317)
						{
							this.meleeDamage += 0.08f;
							this.meleeCrit += 8;
						}
						if (this.armor[num53].type == 1318)
						{
							this.meleeCrit += 4;
						}
						if (this.armor[num53].type == 684)
						{
							this.rangedDamage += 0.16f;
							this.meleeDamage += 0.16f;
						}
						if (this.armor[num53].type == 685)
						{
							this.magicCrit += 11;
							this.rangedCrit += 11;
						}
						if (this.armor[num53].type == 686)
						{
							this.moveSpeed += 0.08f;
							this.meleeSpeed += 0.07f;
						}
						if (this.armor[num53].type >= 1158 && this.armor[num53].type <= 1161)
						{
							this.maxMinions++;
						}
						if (this.armor[num53].type >= 1158 && this.armor[num53].type <= 1161)
						{
							this.minionDamage += 0.1f;
						}
						if (this.armor[num53].prefix == 62)
						{
							this.statDefense++;
						}
						if (this.armor[num53].prefix == 63)
						{
							this.statDefense += 2;
						}
						if (this.armor[num53].prefix == 64)
						{
							this.statDefense += 3;
						}
						if (this.armor[num53].prefix == 65)
						{
							this.statDefense += 4;
						}
						if (this.armor[num53].prefix == 66)
						{
							this.statManaMax2 += 20;
						}
						if (this.armor[num53].prefix == 67)
						{
							this.meleeCrit++;
							this.rangedCrit++;
							this.magicCrit++;
						}
						if (this.armor[num53].prefix == 68)
						{
							this.meleeCrit += 2;
							this.rangedCrit += 2;
							this.magicCrit += 2;
						}
						if (this.armor[num53].prefix == 69)
						{
							this.meleeDamage += 0.01f;
							this.rangedDamage += 0.01f;
							this.magicDamage += 0.01f;
							this.minionDamage += 0.01f;
						}
						if (this.armor[num53].prefix == 70)
						{
							this.meleeDamage += 0.02f;
							this.rangedDamage += 0.02f;
							this.magicDamage += 0.02f;
							this.minionDamage += 0.02f;
						}
						if (this.armor[num53].prefix == 71)
						{
							this.meleeDamage += 0.03f;
							this.rangedDamage += 0.03f;
							this.magicDamage += 0.03f;
							this.minionDamage += 0.03f;
						}
						if (this.armor[num53].prefix == 72)
						{
							this.meleeDamage += 0.04f;
							this.rangedDamage += 0.04f;
							this.magicDamage += 0.04f;
							this.minionDamage += 0.04f;
						}
						if (this.armor[num53].prefix == 73)
						{
							this.moveSpeed += 0.01f;
						}
						if (this.armor[num53].prefix == 74)
						{
							this.moveSpeed += 0.02f;
						}
						if (this.armor[num53].prefix == 75)
						{
							this.moveSpeed += 0.03f;
						}
						if (this.armor[num53].prefix == 76)
						{
							this.moveSpeed += 0.04f;
						}
						if (this.armor[num53].prefix == 77)
						{
							this.meleeSpeed += 0.01f;
						}
						if (this.armor[num53].prefix == 78)
						{
							this.meleeSpeed += 0.02f;
						}
						if (this.armor[num53].prefix == 79)
						{
							this.meleeSpeed += 0.03f;
						}
						if (this.armor[num53].prefix == 80)
						{
							this.meleeSpeed += 0.04f;
						}
					}
					this.head = this.armor[0].headSlot;
					this.body = this.armor[1].bodySlot;
					this.legs = this.armor[2].legSlot;
					for (int num54 = 3; num54 < 8; num54++)
					{
						if (this.armor[num54].type == 15 && this.accWatch < 1)
						{
							this.accWatch = 1;
						}
						if (this.armor[num54].type == 16 && this.accWatch < 2)
						{
							this.accWatch = 2;
						}
						if (this.armor[num54].type == 17 && this.accWatch < 3)
						{
							this.accWatch = 3;
						}
						if (this.armor[num54].type == 707 && this.accWatch < 1)
						{
							this.accWatch = 1;
						}
						if (this.armor[num54].type == 708 && this.accWatch < 2)
						{
							this.accWatch = 2;
						}
						if (this.armor[num54].type == 709 && this.accWatch < 3)
						{
							this.accWatch = 3;
						}
						if (this.armor[num54].type == 18 && this.accDepthMeter < 1)
						{
							this.accDepthMeter = 1;
						}
						if (this.armor[num54].type == 857)
						{
							this.doubleJump2 = true;
						}
						if (this.armor[num54].type == 983)
						{
							this.doubleJump2 = true;
							this.jumpBoost = true;
						}
						if (this.armor[num54].type == 987)
						{
							this.doubleJump3 = true;
						}
						if (this.armor[num54].type == 1163)
						{
							this.doubleJump3 = true;
							this.jumpBoost = true;
						}
						if (this.armor[num54].type == 1164)
						{
							this.doubleJump = true;
							this.doubleJump2 = true;
							this.doubleJump3 = true;
							this.jumpBoost = true;
						}
						if (this.armor[num54].type == 1250)
						{
							this.jumpBoost = true;
							this.doubleJump = true;
							this.noFallDmg = true;
						}
						if (this.armor[num54].type == 1252)
						{
							this.doubleJump2 = true;
							this.jumpBoost = true;
							this.noFallDmg = true;
						}
						if (this.armor[num54].type == 1251)
						{
							this.doubleJump3 = true;
							this.jumpBoost = true;
							this.noFallDmg = true;
						}
						if (this.armor[num54].type == 1249)
						{
							this.jumpBoost = true;
							this.bee = true;
						}
						if (this.armor[num54].type == 1253 && (double)this.statLife <= (double)this.statLifeMax * 0.25)
						{
							this.AddBuff(62, 5, true);
						}
						if (this.armor[num54].type == 1290)
						{
							this.panic = true;
						}
						if (this.armor[num54].type == 1300 && this.inventory[this.selectedItem].useAmmo == 14)
						{
							this.scope = true;
						}
						if (this.armor[num54].type == 1303 && this.wet)
						{
							Lighting.addLight((int)this.center().X / 16, (int)this.center().Y / 16, 0.9f, 0.2f, 0.6f);
						}
						if (this.armor[num54].type == 1301)
						{
							this.meleeCrit += 8;
							this.rangedCrit += 8;
							this.magicCrit += 8;
							this.meleeDamage += 0.1f;
							this.rangedDamage += 0.1f;
							this.magicDamage += 0.1f;
							this.minionDamage += 0.1f;
						}
						if (this.armor[num54].type == 1247)
						{
							this.starCloak = true;
							this.bee = true;
						}
						if (this.armor[num54].type == 1248)
						{
							this.meleeCrit += 10;
							this.rangedCrit += 10;
							this.magicCrit += 10;
						}
						if (this.armor[num54].type == 854)
						{
							this.discount = true;
						}
						if (this.armor[num54].type == 855)
						{
							this.coins = true;
						}
						if (this.armor[num54].type == 53)
						{
							this.doubleJump = true;
						}
						if (this.armor[num54].type == 54)
						{
							num6 = 6f;
						}
						if (this.armor[num54].type == 1579)
						{
							num6 = 6f;
							this.coldDash = true;
						}
						if (this.armor[num54].type == 128)
						{
							this.rocketBoots = 1;
						}
						if (this.armor[num54].type == 156)
						{
							this.noKnockback = true;
						}
						if (this.armor[num54].type == 158)
						{
							this.noFallDmg = true;
						}
						if (this.armor[num54].type == 934)
						{
							this.carpet = true;
						}
						if (this.armor[num54].type == 953)
						{
							this.spikedBoots++;
						}
						if (this.armor[num54].type == 975)
						{
							this.spikedBoots++;
						}
						if (this.armor[num54].type == 976)
						{
							this.spikedBoots += 2;
						}
						if (this.armor[num54].type == 977)
						{
							this.dash = 1;
						}
						if (this.armor[num54].type == 963)
						{
							this.blackBelt = true;
						}
						if (this.armor[num54].type == 984)
						{
							this.blackBelt = true;
							this.dash = 1;
							this.spikedBoots = 2;
						}
						if (this.armor[num54].type == 1131)
						{
							this.gravControl2 = true;
						}
						if (this.armor[num54].type == 1132)
						{
							this.bee = true;
						}
						if (this.armor[num54].type == 1578)
						{
							this.bee = true;
							this.panic = true;
						}
						if (this.armor[num54].type == 950)
						{
							this.iceSkate = true;
						}
						if (this.armor[num54].type == 159)
						{
							this.jumpBoost = true;
						}
						if (this.armor[num54].type == 187)
						{
							this.accFlipper = true;
						}
						if (this.armor[num54].type == 211)
						{
							this.meleeSpeed += 0.12f;
						}
						if (this.armor[num54].type == 223)
						{
							this.manaCost -= 0.06f;
						}
						if (this.armor[num54].type == 285)
						{
							this.moveSpeed += 0.05f;
						}
						if (this.armor[num54].type == 212)
						{
							this.moveSpeed += 0.1f;
						}
						if (this.armor[num54].type == 267)
						{
							this.killGuide = true;
						}
						if (this.armor[num54].type == 1307)
						{
							this.killClothier = true;
						}
						if (this.armor[num54].type == 193)
						{
							this.fireWalk = true;
						}
						if (this.armor[num54].type == 861)
						{
							this.accMerman = true;
							this.wolfAcc = true;
						}
						if (this.armor[num54].type == 862)
						{
							this.starCloak = true;
							this.longInvince = true;
						}
						if (this.armor[num54].type == 860)
						{
							this.pStone = true;
						}
						if (this.armor[num54].type == 863)
						{
							this.waterWalk2 = true;
						}
						if (this.armor[num54].type == 907)
						{
							this.waterWalk2 = true;
							this.fireWalk = true;
						}
						if (this.armor[num54].type == 908)
						{
							this.waterWalk = true;
							this.fireWalk = true;
							this.lavaMax += 420;
						}
						if (this.armor[num54].type == 906)
						{
							this.lavaMax += 420;
						}
						if (this.armor[num54].type == 485)
						{
							this.wolfAcc = true;
						}
						if (this.armor[num54].type == 486)
						{
							this.rulerAcc = true;
						}
						if (this.armor[num54].type == 393)
						{
							this.accCompass = 1;
						}
						if (this.armor[num54].type == 394)
						{
							this.accFlipper = true;
							this.accDivingHelm = true;
						}
						if (this.armor[num54].type == 395)
						{
							this.accWatch = 3;
							this.accDepthMeter = 1;
							this.accCompass = 1;
						}
						if (this.armor[num54].type == 396)
						{
							this.noFallDmg = true;
							this.fireWalk = true;
						}
						if (this.armor[num54].type == 397)
						{
							this.noKnockback = true;
							this.fireWalk = true;
						}
						if (this.armor[num54].type == 399)
						{
							this.jumpBoost = true;
							this.doubleJump = true;
						}
						if (this.armor[num54].type == 405)
						{
							num6 = 6f;
							this.rocketBoots = 2;
						}
						if (this.armor[num54].type == 897)
						{
							this.kbGlove = true;
							this.meleeSpeed += 0.12f;
						}
						if (this.armor[num54].type == 1343)
						{
							this.kbGlove = true;
							this.meleeSpeed += 0.09f;
							this.meleeDamage += 0.09f;
							this.magmaStone = true;
						}
						if (this.armor[num54].type == 1167)
						{
							this.minionKB += 2f;
							this.minionDamage += 0.15f;
						}
						if (this.armor[num54].type == 1321)
						{
							this.magicQuiver = true;
						}
						if (this.armor[num54].type == 1322)
						{
							this.magmaStone = true;
						}
						if (this.armor[num54].type == 1323)
						{
							this.lavaRose = true;
						}
						if (this.armor[num54].type == 938)
						{
							this.noKnockback = true;
							if ((double)this.statLife > (double)this.statLifeMax * 0.25)
							{
								if (i == Main.myPlayer)
								{
									this.paladinGive = true;
								}
								else
								{
									if (this.miscCounter % 5 == 0)
									{
										int myPlayer = Main.myPlayer;
										if (Main.player[myPlayer].team == this.team && this.team != 0)
										{
											float num55 = this.position.X - Main.player[myPlayer].position.X;
											float num56 = this.position.Y - Main.player[myPlayer].position.Y;
											float num57 = (float)Math.Sqrt((double)(num55 * num55 + num56 * num56));
											if (num57 < 800f)
											{
												Main.player[myPlayer].AddBuff(43, 10, true);
											}
										}
									}
								}
							}
						}
						if (this.armor[num54].type == 936)
						{
							this.kbGlove = true;
							this.meleeSpeed += 0.12f;
							this.magicDamage += 0.12f;
							this.meleeDamage += 0.12f;
							this.rangedDamage += 0.12f;
						}
						if (this.armor[num54].type == 898)
						{
							num6 = 6.75f;
							this.rocketBoots = 2;
							this.moveSpeed += 0.08f;
						}
						if (this.armor[num54].type == 899 && Main.dayTime)
						{
							this.lifeRegen += 2;
							this.statDefense += 4;
							this.meleeSpeed += 0.1f;
							this.meleeDamage += 0.1f;
							this.meleeCrit += 2;
							this.rangedDamage += 0.1f;
							this.rangedCrit += 2;
							this.magicDamage += 0.1f;
							this.magicCrit+= 2;
							this.pickSpeed -= 0.15f;
							this.minionDamage += 0.1f;
							this.minionKB += 0.5f;
						}
						if (this.armor[num54].type == 900 && !Main.dayTime)
						{
							this.lifeRegen += 2;
							this.statDefense += 4;
							this.meleeSpeed += 0.1f;
							this.meleeDamage += 0.1f;
							this.meleeCrit += 2;
							this.rangedDamage += 0.1f;
							this.rangedCrit += 2;
							this.magicDamage += 0.1f;
							this.magicCrit +=2;
							this.pickSpeed -= 0.15f;
							this.minionDamage += 0.1f;
							this.minionKB += 0.5f;
						}
						if (this.armor[num54].type == 407)
						{
							this.blockRange = 1;
						}
						if (this.armor[num54].type == 489)
						{
							this.magicDamage += 0.15f;
						}
						if (this.armor[num54].type == 490)
						{
							this.meleeDamage += 0.15f;
						}
						if (this.armor[num54].type == 491)
						{
							this.rangedDamage += 0.15f;
						}
						if (this.armor[num54].type == 935)
						{
							this.magicDamage += 0.12f;
							this.meleeDamage += 0.12f;
							this.rangedDamage += 0.12f;
							this.minionDamage += 0.12f;
						}
						if (this.armor[num54].type == 492)
						{
							this.wings = 1;
						}
						if (this.armor[num54].type == 493)
						{
							this.wings = 2;
						}
						if (this.armor[num54].type == 665)
						{
							this.wings = 3;
						}
						if (this.armor[num54].type == 748)
						{
							this.wings = 4;
						}
						if (this.armor[num54].type == 749)
						{
							this.wings = 5;
						}
						if (this.armor[num54].type == 761)
						{
							this.wings = 6;
						}
						if (this.armor[num54].type == 785)
						{
							this.wings = 7;
						}
						if (this.armor[num54].type == 786)
						{
							this.wings = 8;
						}
						if (this.armor[num54].type == 821)
						{
							this.wings = 9;
						}
						if (this.armor[num54].type == 822)
						{
							this.wings = 10;
						}
						if (this.armor[num54].type == 823)
						{
							this.wings = 11;
						}
						if (this.armor[num54].type == 948)
						{
							this.wings = 12;
						}
						if (this.armor[num54].type == 1162)
						{
							this.wings = 13;
						}
						if (this.armor[num54].type == 1165)
						{
							this.wings = 14;
						}
						if (this.armor[num54].type == 1515)
						{
							this.wings = 15;
						}
						if (this.armor[num54].type == 1583)
						{
							this.wings = 16;
						}
						if (this.armor[num54].type == 1584)
						{
							this.wings = 17;
						}
						if (this.armor[num54].type == 1585)
						{
							this.wings = 18;
						}
						if (this.armor[num54].type == 1586)
						{
							this.wings = 19;
						}
						if (this.armor[num54].type == 885)
						{
							this.buffImmune[30] = true;
						}
						if (this.armor[num54].type == 886)
						{
							this.buffImmune[36] = true;
						}
						if (this.armor[num54].type == 887)
						{
							this.buffImmune[20] = true;
						}
						if (this.armor[num54].type == 888)
						{
							this.buffImmune[22] = true;
						}
						if (this.armor[num54].type == 889)
						{
							this.buffImmune[32] = true;
						}
						if (this.armor[num54].type == 890)
						{
							this.buffImmune[35] = true;
						}
						if (this.armor[num54].type == 891)
						{
							this.buffImmune[23] = true;
						}
						if (this.armor[num54].type == 892)
						{
							this.buffImmune[33] = true;
						}
						if (this.armor[num54].type == 893)
						{
							this.buffImmune[31] = true;
						}
						if (this.armor[num54].type == 901)
						{
							this.buffImmune[33] = true;
							this.buffImmune[36] = true;
						}
						if (this.armor[num54].type == 902)
						{
							this.buffImmune[30] = true;
							this.buffImmune[20] = true;
						}
						if (this.armor[num54].type == 903)
						{
							this.buffImmune[32] = true;
							this.buffImmune[31] = true;
						}
						if (this.armor[num54].type == 904)
						{
							this.buffImmune[35] = true;
							this.buffImmune[23] = true;
						}
						if (this.armor[num54].type == 1612)
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
						if (this.armor[num54].type == 1613)
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
						if (this.armor[num54].type == 497)
						{
							this.accMerman = true;
						}
						if (this.armor[num54].type == 535)
						{
							this.pStone = true;
						}
						if (this.armor[num54].type == 536)
						{
							this.kbGlove = true;
						}
						if (this.armor[num54].type == 532)
						{
							this.starCloak = true;
						}
						if (this.armor[num54].type == 554)
						{
							this.longInvince = true;
						}
						if (this.armor[num54].type == 555)
						{
							this.manaFlower = true;
							this.manaCost -= 0.08f;
						}
						if (Main.myPlayer == this.whoAmi)
						{
							if (this.armor[num54].type == 576 && Main.rand.Next(18000) != 0 && Main.curMusic > 0)
							{
								int num58 = 0;
								if (Main.curMusic == 1)
								{
									num58 = 0;
								}
								if (Main.curMusic == 2)
								{
									num58 = 1;
								}
								if (Main.curMusic == 3)
								{
									num58 = 2;
								}
								if (Main.curMusic == 4)
								{
									num58 = 4;
								}
								if (Main.curMusic == 5)
								{
									num58 = 5;
								}
								if (Main.curMusic == 7)
								{
									num58 = 6;
								}
								if (Main.curMusic == 8)
								{
									num58 = 7;
								}
								if (Main.curMusic == 9)
								{
									num58 = 9;
								}
								if (Main.curMusic == 10)
								{
									num58 = 8;
								}
								if (Main.curMusic == 11)
								{
									num58 = 11;
								}
								if (Main.curMusic == 12)
								{
									num58 = 10;
								}
								if (Main.curMusic == 13)
								{
									num58 = 12;
								}
								if (Main.curMusic == 29)
								{
									this.armor[num54].SetDefaults(1610, false);
								}
								else
								{
									if (Main.curMusic > 13)
									{
										this.armor[num54].SetDefaults(1596 + Main.curMusic - 14, false);
									}
									else
									{
										this.armor[num54].SetDefaults(num58 + 562, false);
									}
								}
							}
							if (this.armor[num54].type >= 562 && this.armor[num54].type <= 574)
							{
								Main.musicBox2 = this.armor[num54].type - 562;
							}
							if (this.armor[num54].type >= 1596 && this.armor[num54].type <= 1609)
							{
								Main.musicBox2 = this.armor[num54].type - 1596 + 13;
							}
							if (this.armor[num54].type == 1610)
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
						for (int num59 = 0; num59 <= 58; num59++)
						{
							if (this.inventory[num59].type >= 1522 && this.inventory[num59].type <= 1527)
							{
								this.gem = this.inventory[num59].type - 1522;
							}
						}
					}
					if (this.head == 11)
					{
						int i2 = (int)(this.position.X + (float)(this.width / 2) + (float)(8 * this.direction)) / 16;
						int j2 = (int)(this.position.Y + 2f) / 16;
						Lighting.addLight(i2, j2, 0.92f, 0.8f, 0.65f);
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
						this.setBonus = Lang.setBonus(20, false);
						this.statDefense += 4;
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
					else
					{
						if (this.crystalLeaf)
						{
							for (int num60 = 0; num60 < 10; num60++)
							{
								if (this.buffType[num60] == 60)
								{
									this.DelBuff(num60);
								}
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
						else
						{
							if (this.head == 30)
							{
								this.setBonus = Lang.setBonus(9, false);
								this.meleeSpeed += 0.15f;
							}
							else
							{
								if (this.head == 31)
								{
									this.setBonus = Lang.setBonus(10, false);
									this.ammoCost80 = true;
								}
							}
						}
					}
					if (this.body == 18 && this.legs == 17)
					{
						if (this.head == 32)
						{
							this.setBonus = Lang.setBonus(11, false);
							this.manaCost -= 0.17f;
						}
						else
						{
							if (this.head == 33)
							{
								this.setBonus = Lang.setBonus(12, false);
								this.meleeCrit += 5;
							}
							else
							{
								if (this.head == 34)
								{
									this.setBonus = Lang.setBonus(13, false);
									this.ammoCost80 = true;
								}
							}
						}
					}
					if (this.body == 19 && this.legs == 18)
					{
						if (this.head == 35)
						{
							this.setBonus = Lang.setBonus(14, false);
							this.manaCost -= 0.19f;
						}
						else
						{
							if (this.head == 36)
							{
								this.setBonus = Lang.setBonus(15, false);
								this.meleeSpeed += 0.18f;
								this.moveSpeed += 0.18f;
							}
							else
							{
								if (this.head == 37)
								{
									this.setBonus = Lang.setBonus(16, false);
									this.ammoCost75 = true;
								}
							}
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
						else
						{
							if (this.head == 43)
							{
								this.setBonus = Lang.setBonus(18, false);
								this.meleeSpeed += 0.19f;
								this.moveSpeed += 0.19f;
							}
							else
							{
								if (this.head == 41)
								{
									this.setBonus = Lang.setBonus(19, false);
									this.ammoCost75 = true;
								}
							}
						}
					}
					if (this.head == 82 && this.body == 53 && this.legs == 48)
					{
						this.setBonus = Lang.setBonus(23, false);
						this.maxMinions++;
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
							float num61 = Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y);
							this.stealth += num61 * 0.0075f;
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
					else
					{
						if (this.venom)
						{
							if (this.lifeRegen > 0)
							{
								this.lifeRegen = 0;
							}
							this.lifeRegenTime = 0;
							this.lifeRegen -= 12;
						}
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
					if (this.bleed)
					{
						this.lifeRegenTime = 0;
					}
					float num62 = 0f;
					if (this.lifeRegenTime >= 300)
					{
						num62 += 1f;
					}
					if (this.lifeRegenTime >= 600)
					{
						num62 += 1f;
					}
					if (this.lifeRegenTime >= 900)
					{
						num62 += 1f;
					}
					if (this.lifeRegenTime >= 1200)
					{
						num62 += 1f;
					}
					if (this.lifeRegenTime >= 1500)
					{
						num62 += 1f;
					}
					if (this.lifeRegenTime >= 1800)
					{
						num62 += 1f;
					}
					if (this.lifeRegenTime >= 2400)
					{
						num62 += 1f;
					}
					if (this.lifeRegenTime >= 3000)
					{
						num62 += 1f;
					}
					if (this.lifeRegenTime >= 3600)
					{
						num62 += 1f;
						this.lifeRegenTime = 3600;
					}
					if (this.velocity.X == 0f || this.grappling[0] > 0)
					{
						num62 *= 1.25f;
					}
					else
					{
						num62 *= 0.5f;
					}
					if (this.crimsonRegen)
					{
						num62 *= 1.5f;
					}
					if (this.whoAmi == Main.myPlayer && Main.campfire)
					{
						num62 *= 1.1f;
					}
					float num63 = (float)this.statLifeMax / 400f * 0.85f + 0.15f;
					num62 *= num63;
					this.lifeRegen += (int)Math.Round((double)num62);
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
								for (int num64 = 0; num64 < 10; num64++)
								{
									int num65 = Dust.NewDust(this.position, this.width, this.height, 5, 0f, 0f, 175, default(Color), 1.75f);
									Main.dust[num65].noGravity = true;
									Main.dust[num65].velocity *= 0.75f;
									int num66 = Main.rand.Next(-40, 41);
									int num67 = Main.rand.Next(-40, 41);
									Dust expr_7DAE_cp_0 = Main.dust[num65];
									expr_7DAE_cp_0.position.X = expr_7DAE_cp_0.position.X + (float)num66;
									Dust expr_7DCA_cp_0 = Main.dust[num65];
									expr_7DCA_cp_0.position.Y = expr_7DCA_cp_0.position.Y + (float)num67;
									Main.dust[num65].velocity.X = (float)(-(float)num66) * 0.075f;
									Main.dust[num65].velocity.Y = (float)(-(float)num67) * 0.075f;
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
								else
								{
									if (this.lifeRegenCount <= -360)
									{
										this.lifeRegenCount += 360;
										this.statLife -= 3;
										CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(255, 60, 70, 255), string.Concat(3), false, true);
									}
									else
									{
										if (this.lifeRegenCount <= -240)
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
									}
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
							goto IL_81AA;
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
					IL_81AA:
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
						float num68 = (float)this.statMana / (float)this.statManaMax2 * 0.8f + 0.2f;
						if (this.manaRegenBuff)
						{
							num68 = 1f;
						}
						this.manaRegen = (int)((float)this.manaRegen * num68);
					}
					else
					{
						this.manaRegen = 0;
					}
					this.manaRegenCount += this.manaRegen;
					while (this.manaRegenCount >= 120)
					{
						bool flag27 = false;
						this.manaRegenCount -= 120;
						if (this.statMana < this.statManaMax2)
						{
							this.statMana++;
							flag27 = true;
						}
						if (this.statMana >= this.statManaMax2)
						{
							if (this.whoAmi == Main.myPlayer && flag27)
							{
								Main.PlaySound(25, -1, -1, 1);
								for (int num69 = 0; num69 < 5; num69++)
								{
									int num70 = Dust.NewDust(this.position, this.width, this.height, 45, 0f, 0f, 255, default(Color), (float)Main.rand.Next(20, 26) * 0.1f);
									Main.dust[num70].noLight = true;
									Main.dust[num70].noGravity = true;
									Main.dust[num70].velocity *= 0.5f;
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
					for (int num71 = 0; num71 < 10; num71++)
					{
						if (this.buffType[num71] > 0 && this.buffTime[num71] > 0 && this.buffImmune[this.buffType[num71]])
						{
							this.DelBuff(num71);
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
					else
					{
						if (this.velocity.Y == 0f || this.sliding)
						{
							this.jumpAgain = true;
						}
					}
					if (!this.doubleJump2)
					{
						this.jumpAgain2 = false;
					}
					else
					{
						if (this.velocity.Y == 0f || this.sliding)
						{
							this.jumpAgain2 = true;
						}
					}
					if (!this.doubleJump3)
					{
						this.jumpAgain3 = false;
					}
					else
					{
						if (this.velocity.Y == 0f || this.sliding)
						{
							this.jumpAgain3 = true;
						}
					}
					if (!this.carpet)
					{
						this.canCarpet = false;
						this.carpetFrame = -1;
					}
					else
					{
						if (this.velocity.Y == 0f || this.sliding)
						{
							this.canCarpet = true;
							this.carpetTime = 0;
							this.carpetFrame = -1;
							this.carpetFrameCounter = 0f;
						}
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
						int num72 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num73 = (int)(this.position.Y - 8f) / 16;
						if (Main.tile[num72, num73].active() && Main.tileRope[(int)Main.tile[num72, num73].type])
						{
							float num74 = this.position.Y;
							if (Main.tile[num72, num73 - 1] == null)
							{
								Main.tile[num72, num73 - 1] = new Tile();
							}
							if (Main.tile[num72, num73 + 1] == null)
							{
								Main.tile[num72, num73 + 1] = new Tile();
							}
							if ((!Main.tile[num72, num73 - 1].active() || !Main.tileRope[(int)Main.tile[num72, num73 - 1].type]) && (!Main.tile[num72, num73 + 1].active() || !Main.tileRope[(int)Main.tile[num72, num73 + 1].type]))
							{
								num74 = (float)(num73 * 16 + 22);
							}
							float num75 = (float)(num72 * 16 + 8 - this.width / 2 + 6 * this.direction);
							int num76 = num72 * 16 + 8 - this.width / 2 + 6;
							int num77 = num72 * 16 + 8 - this.width / 2;
							int num78 = num72 * 16 + 8 - this.width / 2 + -6;
							int num79 = 1;
							float num80 = Math.Abs(this.position.X - (float)num76);
							if (Math.Abs(this.position.X - (float)num77) < num80)
							{
								num79 = 2;
								num80 = Math.Abs(this.position.X - (float)num77);
							}
							if (Math.Abs(this.position.X - (float)num78) < num80)
							{
								num79 = 3;
								num80 = Math.Abs(this.position.X - (float)num78);
							}
							if (num79 == 1)
							{
								num75 = (float)num76;
								this.pulleyDir = 2;
								this.direction = 1;
							}
							if (num79 == 2)
							{
								num75 = (float)num77;
								this.pulleyDir = 1;
							}
							if (num79 == 3)
							{
								num75 = (float)num78;
								this.pulleyDir = 2;
								this.direction = -1;
							}
							if (!Collision.SolidCollision(new Vector2(num75, this.position.Y), this.width, this.height))
							{
								if (i == Main.myPlayer)
								{
									Main.cameraX = Main.cameraX + this.position.X - num75;
								}
								this.pulley = true;
								this.position.X = num75;
								this.gfxOffY = this.position.Y - num74;
								this.stepSpeed = 2.5f;
								this.position.Y = num74;
								this.velocity.X = 0f;
							}
							else
							{
								num75 = (float)num76;
								this.pulleyDir = 2;
								this.direction = 1;
								if (!Collision.SolidCollision(new Vector2(num75, this.position.Y), this.width, this.height))
								{
									if (i == Main.myPlayer)
									{
										Main.cameraX = Main.cameraX + this.position.X - num75;
									}
									this.pulley = true;
									this.position.X = num75;
									this.gfxOffY = this.position.Y - num74;
									this.stepSpeed = 2.5f;
									this.position.Y = num74;
									this.velocity.X = 0f;
								}
								else
								{
									num75 = (float)num78;
									this.pulleyDir = 2;
									this.direction = -1;
									if (!Collision.SolidCollision(new Vector2(num75, this.position.Y), this.width, this.height))
									{
										if (i == Main.myPlayer)
										{
											Main.cameraX = Main.cameraX + this.position.X - num75;
										}
										this.pulley = true;
										this.position.X = num75;
										this.gfxOffY = this.position.Y - num74;
										this.stepSpeed = 2.5f;
										this.position.Y = num74;
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
						int num81 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num82 = (int)(this.position.Y - 8f) / 16;
						bool flag28 = false;
						if (this.pulleyDir == 0)
						{
							this.pulleyDir = 1;
						}
						if (this.pulleyDir == 1)
						{
							if (this.direction == -1 && this.controlLeft && (this.releaseLeft || this.leftTimer == 0))
							{
								this.pulleyDir = 2;
								flag28 = true;
							}
							else
							{
								if ((this.direction == 1 && this.controlRight && this.releaseRight) || this.rightTimer == 0)
								{
									this.pulleyDir = 2;
									flag28 = true;
								}
								else
								{
									if (this.direction == 1 && this.controlLeft)
									{
										this.direction = -1;
										flag28 = true;
									}
									if (this.direction == -1 && this.controlRight)
									{
										this.direction = 1;
										flag28 = true;
									}
								}
							}
						}
						else
						{
							if (this.pulleyDir == 2)
							{
								if (this.direction == 1 && this.controlLeft)
								{
									flag28 = true;
									int num83 = num81 * 16 + 8 - this.width / 2;
									if (!Collision.SolidCollision(new Vector2((float)num83, this.position.Y), this.width, this.height))
									{
										this.pulleyDir = 1;
										this.direction = -1;
										flag28 = true;
									}
								}
								if (this.direction == -1 && this.controlRight)
								{
									flag28 = true;
									int num84 = num81 * 16 + 8 - this.width / 2;
									if (!Collision.SolidCollision(new Vector2((float)num84, this.position.Y), this.width, this.height))
									{
										this.pulleyDir = 1;
										this.direction = 1;
										flag28 = true;
									}
								}
							}
						}
						bool flag29 = false;
						if (!flag28 && ((this.controlLeft && (this.releaseLeft || this.leftTimer == 0)) || (this.controlRight && (this.releaseRight || this.rightTimer == 0))))
						{
							int num85 = 1;
							if (this.controlLeft)
							{
								num85 = -1;
							}
							int num86 = num81 + num85;
							if (Main.tile[num86, num82].active() && Main.tileRope[(int)Main.tile[num86, num82].type])
							{
								this.pulleyDir = 1;
								this.direction = num85;
								int num87 = num86 * 16 + 8 - this.width / 2;
								float num88 = this.position.Y;
								num88 = (float)(num82 * 16 + 22);
								if ((!Main.tile[num86, num82 - 1].active() || !Main.tileRope[(int)Main.tile[num86, num82 - 1].type]) && (!Main.tile[num86, num82 + 1].active() || !Main.tileRope[(int)Main.tile[num86, num82 + 1].type]))
								{
									num88 = (float)(num82 * 16 + 22);
								}
								if (Collision.SolidCollision(new Vector2((float)num87, num88), this.width, this.height))
								{
									this.pulleyDir = 2;
									this.direction = -num85;
									if (this.direction == 1)
									{
										num87 = num86 * 16 + 8 - this.width / 2 + 6;
									}
									else
									{
										num87 = num86 * 16 + 8 - this.width / 2 + -6;
									}
								}
								if (i == Main.myPlayer)
								{
									Main.cameraX = Main.cameraX + this.position.X - (float)num87;
								}
								this.position.X = (float)num87;
								this.gfxOffY = this.position.Y - num88;
								this.position.Y = num88;
								flag29 = true;
							}
						}
						if (!flag29 && !flag28 && !this.controlUp && ((this.controlLeft && this.releaseLeft) || (this.controlRight && this.releaseRight)))
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
						if (Main.tile[num81, num82] == null)
						{
							Main.tile[num81, num82] = new Tile();
						}
						if (!Main.tile[num81, num82].active() || !Main.tileRope[(int)Main.tile[num81, num82].type])
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
						int num89 = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int num90 = (int)(this.position.Y - 16f) / 16;
						int num91 = (int)(this.position.Y - 8f) / 16;
						bool flag30 = true;
						bool flag31 = false;
						if ((Main.tile[num89, num91 - 1].active() && Main.tileRope[(int)Main.tile[num89, num91 - 1].type]) || (Main.tile[num89, num91 + 1].active() && Main.tileRope[(int)Main.tile[num89, num91 + 1].type]))
						{
							flag31 = true;
						}
						if (Main.tile[num89, num90] == null)
						{
							Main.tile[num89, num90] = new Tile();
						}
						if (!Main.tile[num89, num90].active() || !Main.tileRope[(int)Main.tile[num89, num90].type])
						{
							flag30 = false;
							if (this.velocity.Y < 0f)
							{
								this.velocity.Y = 0f;
							}
						}
						if (flag31)
						{
							if (this.controlUp && flag30)
							{
								float num92 = this.position.X;
								float y = this.position.Y - Math.Abs(this.velocity.Y) - 2f;
								if (Collision.SolidCollision(new Vector2(num92, y), this.width, this.height))
								{
									num92 = (float)(num89 * 16 + 8 - this.width / 2 + 6);
									if (!Collision.SolidCollision(new Vector2(num92, y), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
									{
										if (i == Main.myPlayer)
										{
											Main.cameraX = Main.cameraX + this.position.X - num92;
										}
										this.pulleyDir = 2;
										this.direction = 1;
										this.position.X = num92;
										this.velocity.X = 0f;
									}
									else
									{
										num92 = (float)(num89 * 16 + 8 - this.width / 2 + -6);
										if (!Collision.SolidCollision(new Vector2(num92, y), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
										{
											if (i == Main.myPlayer)
											{
												Main.cameraX = Main.cameraX + this.position.X - num92;
											}
											this.pulleyDir = 2;
											this.direction = -1;
											this.position.X = num92;
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
							else
							{
								if (this.controlDown)
								{
									float num93 = this.position.X;
									float y2 = this.position.Y;
									if (Collision.SolidCollision(new Vector2(num93, y2), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
									{
										num93 = (float)(num89 * 16 + 8 - this.width / 2 + 6);
										if (!Collision.SolidCollision(new Vector2(num93, y2), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
										{
											if (i == Main.myPlayer)
											{
												Main.cameraX = Main.cameraX + this.position.X - num93;
											}
											this.pulleyDir = 2;
											this.direction = 1;
											this.position.X = num93;
											this.velocity.X = 0f;
										}
										else
										{
											num93 = (float)(num89 * 16 + 8 - this.width / 2 + -6);
											if (!Collision.SolidCollision(new Vector2(num93, y2), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
											{
												if (i == Main.myPlayer)
												{
													Main.cameraX = Main.cameraX + this.position.X - num93;
												}
												this.pulleyDir = 2;
												this.direction = -1;
												this.position.X = num93;
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
						}
						else
						{
							if (this.controlDown)
							{
								this.ropeCount = 10;
								this.pulley = false;
								this.velocity.Y = 1f;
							}
							else
							{
								this.velocity.Y = 0f;
								this.position.Y = (float)(num90 * 16 + 22);
							}
						}
						float num94 = (float)(num89 * 16 + 8 - this.width / 2);
						if (this.pulleyDir == 1)
						{
							num94 = (float)(num89 * 16 + 8 - this.width / 2);
						}
						if (this.pulleyDir == 2)
						{
							num94 = (float)(num89 * 16 + 8 - this.width / 2 + 6 * this.direction);
						}
						if (i == Main.myPlayer)
						{
							Main.cameraX = Main.cameraX + this.position.X - num94;
						}
						this.position.X = num94;
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
					else
					{
						if (this.grappling[0] == -1 && !this.tongued)
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
								if (this.wings == 9 || this.wings == 10 || this.wings == 11)
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
							else
							{
								if (this.powerrun)
								{
									num3 *= 3.5f;
									num4 *= 1f;
									num5 *= 2f;
								}
								else
								{
									if (this.slippy2)
									{
										num4 *= 0.6f;
										num5 = 0f;
										if (this.iceSkate)
										{
											num4 *= 3.5f;
											num3 *= 1.25f;
										}
									}
									else
									{
										if (this.slippy)
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
									}
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
							else
							{
								if (this.controlRight && this.velocity.X < num3)
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
								else
								{
									if (this.controlLeft && this.velocity.X > -num6 && this.dashDelay == 0)
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
											int num95 = 0;
											if (this.gravDir == -1f)
											{
												num95 -= this.height;
											}
											if (this.runSoundDelay == 0 && this.velocity.Y == 0f)
											{
												Main.PlaySound(17, (int)this.position.X, (int)this.position.Y, 1);
												this.runSoundDelay = 9;
											}
											if (this.wings == 3)
											{
												int num96 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num95), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
												Main.dust[num96].velocity *= 0.025f;
												num96 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num95), this.width + 8, 4, 186, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
												Main.dust[num96].velocity *= 0.2f;
											}
											else
											{
												if (this.coldDash)
												{
													for (int num97 = 0; num97 < 2; num97++)
													{
														int num98;
														if (num97 == 0)
														{
															num98 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
														}
														else
														{
															num98 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)this.height + this.gfxOffY), this.width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f);
														}
														Main.dust[num98].scale *= 1f + (float)Main.rand.Next(20, 40) * 0.01f;
														Main.dust[num98].noGravity = true;
														Main.dust[num98].noLight = true;
														Main.dust[num98].velocity *= 0.001f;
														Dust expr_9EEE_cp_0 = Main.dust[num98];
														expr_9EEE_cp_0.velocity.Y = expr_9EEE_cp_0.velocity.Y - 0.003f;
													}
												}
												else
												{
													int num99 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num95), this.width + 8, 4, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 50, default(Color), 1.5f);
													Main.dust[num99].velocity.X = Main.dust[num99].velocity.X * 0.2f;
													Main.dust[num99].velocity.Y = Main.dust[num99].velocity.Y * 0.2f;
												}
											}
										}
									}
									else
									{
										if (this.controlRight && this.velocity.X < num6 && this.dashDelay == 0)
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
												else
												{
													if (this.coldDash)
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
															Dust expr_A3BE_cp_0 = Main.dust[num103];
															expr_A3BE_cp_0.velocity.Y = expr_A3BE_cp_0.velocity.Y - 0.003f;
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
										}
										else
										{
											if (this.velocity.Y == 0f)
											{
												if (this.velocity.X > num5)
												{
													this.velocity.X = this.velocity.X - num5;
												}
												else
												{
													if (this.velocity.X < -num5)
													{
														this.velocity.X = this.velocity.X + num5;
													}
													else
													{
														this.velocity.X = 0f;
													}
												}
											}
											else
											{
												if ((double)this.velocity.X > (double)num5 * 0.5)
												{
													this.velocity.X = this.velocity.X - num5 * 0.5f;
												}
												else
												{
													if ((double)this.velocity.X < (double)(-(double)num5) * 0.5)
													{
														this.velocity.X = this.velocity.X + num5 * 0.5f;
													}
													else
													{
														this.velocity.X = 0f;
													}
												}
											}
										}
									}
								}
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
							else
							{
								if (this.gravControl2)
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
								else
								{
									if ((this.sliding || this.velocity.Y == 0f || this.jumpAgain || this.jumpAgain2 || this.jumpAgain3 || (this.wet && this.accFlipper)) && this.releaseJump)
									{
										bool flag32 = false;
										if (this.wet && this.accFlipper)
										{
											if (this.swimTime == 0)
											{
												this.swimTime = 30;
											}
											flag32 = true;
										}
										bool flag33 = false;
										bool flag34 = false;
										if (this.jumpAgain2)
										{
											flag33 = true;
											this.jumpAgain2 = false;
										}
										else
										{
											if (this.jumpAgain3)
											{
												flag34 = true;
												this.jumpAgain3 = false;
											}
											else
											{
												this.jumpAgain = false;
											}
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
										if (this.velocity.Y == 0f || flag32 || this.sliding)
										{
											this.velocity.Y = -Player.jumpSpeed * this.gravDir;
											this.jump = Player.jumpHeight;
											if (this.sliding)
											{
												this.velocity.X = (float)(3 * -(float)this.slideDir);
											}
										}
										else
										{
											if (flag33)
											{
												this.dJumpEffect2 = true;
												float arg_A9B6_0 = this.gravDir;
												Main.PlaySound(16, (int)this.position.X, (int)this.position.Y, 1);
												this.velocity.Y = -Player.jumpSpeed * this.gravDir;
												this.jump = Player.jumpHeight * 3;
											}
											else
											{
												if (flag34)
												{
													this.dJumpEffect3 = true;
													float arg_AA18_0 = this.gravDir;
													Main.PlaySound(16, (int)this.position.X, (int)this.position.Y, 1);
													this.velocity.Y = -Player.jumpSpeed * this.gravDir;
													this.jump = (int)((double)Player.jumpHeight * 1.5);
												}
												else
												{
													this.dJumpEffect = true;
													int num105 = this.height;
													if (this.gravDir == -1f)
													{
														num105 = 0;
													}
													Main.PlaySound(16, (int)this.position.X, (int)this.position.Y, 1);
													this.velocity.Y = -Player.jumpSpeed * this.gravDir;
													this.jump = (int)((double)Player.jumpHeight * 0.75);
													for (int num106 = 0; num106 < 10; num106++)
													{
														int num107 = Dust.NewDust(new Vector2(this.position.X - 34f, this.position.Y + (float)num105 - 16f), 102, 32, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
														Main.dust[num107].velocity.X = Main.dust[num107].velocity.X * 0.5f - this.velocity.X * 0.1f;
														Main.dust[num107].velocity.Y = Main.dust[num107].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
													}
													int num108 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 16f, this.position.Y + (float)num105 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
													Main.gore[num108].velocity.X = Main.gore[num108].velocity.X * 0.1f - this.velocity.X * 0.1f;
													Main.gore[num108].velocity.Y = Main.gore[num108].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
													num108 = Gore.NewGore(new Vector2(this.position.X - 36f, this.position.Y + (float)num105 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
													Main.gore[num108].velocity.X = Main.gore[num108].velocity.X * 0.1f - this.velocity.X * 0.1f;
													Main.gore[num108].velocity.Y = Main.gore[num108].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
													num108 = Gore.NewGore(new Vector2(this.position.X + (float)this.width + 4f, this.position.Y + (float)num105 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
													Main.gore[num108].velocity.X = Main.gore[num108].velocity.X * 0.1f - this.velocity.X * 0.1f;
													Main.gore[num108].velocity.Y = Main.gore[num108].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
												}
											}
										}
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
							}
							if (this.dashDelay > 0)
							{
								this.dashDelay--;
							}
							else
							{
								if (this.dashDelay < 0)
								{
									for (int num109 = 0; num109 < 2; num109++)
									{
										int num110;
										if (this.velocity.Y == 0f)
										{
											num110 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 4f), this.width, 8, 31, 0f, 0f, 100, default(Color), 1.4f);
										}
										else
										{
											num110 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)(this.height / 2) - 8f), this.width, 16, 31, 0f, 0f, 100, default(Color), 1.4f);
										}
										Main.dust[num110].velocity *= 0.1f;
										Main.dust[num110].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
									}
									if (this.velocity.X > 13f || this.velocity.X < -13f)
									{
										this.velocity.X = this.velocity.X * 0.99f;
									}
									else
									{
										if (this.velocity.X > num3 || this.velocity.X < -num3)
										{
											this.velocity.X = this.velocity.X * 0.8f;
										}
										else
										{
											this.dashDelay = 30;
										}
									}
								}
								else
								{
									if (this.dash > 0)
									{
										int num111 = 0;
										bool flag35 = false;
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
												num111 = 1;
												flag35 = true;
												this.dashTime = 0;
											}
											else
											{
												this.dashTime = 15;
											}
										}
										else
										{
											if (this.controlLeft && this.releaseLeft)
											{
												if (this.dashTime < 0)
												{
													num111 = -1;
													flag35 = true;
													this.dashTime = 0;
												}
												else
												{
													this.dashTime = -15;
												}
											}
										}
										if (flag35)
										{
											this.velocity.X = 15.9f * (float)num111;
											this.dashDelay = -1;
											for (int num112 = 0; num112 < 20; num112++)
											{
												int num113 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 31, 0f, 0f, 100, default(Color), 2f);
												Dust expr_B1E4_cp_0 = Main.dust[num113];
												expr_B1E4_cp_0.position.X = expr_B1E4_cp_0.position.X + (float)Main.rand.Next(-5, 6);
												Dust expr_B20B_cp_0 = Main.dust[num113];
												expr_B20B_cp_0.position.Y = expr_B20B_cp_0.position.Y + (float)Main.rand.Next(-5, 6);
												Main.dust[num113].velocity *= 0.2f;
												Main.dust[num113].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
											}
											int num114 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 34f), default(Vector2), Main.rand.Next(61, 64), 1f);
											Main.gore[num114].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
											Main.gore[num114].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
											Main.gore[num114].velocity *= 0.4f;
											num114 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 14f), default(Vector2), Main.rand.Next(61, 64), 1f);
											Main.gore[num114].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
											Main.gore[num114].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
											Main.gore[num114].velocity *= 0.4f;
										}
									}
								}
							}
							this.sliding = false;
							if (this.slideDir != 0 && this.spikedBoots > 0 && ((this.controlLeft && this.slideDir == -1) || (this.controlRight && this.slideDir == 1)))
							{
								bool flag36 = false;
								float num115 = this.position.X;
								if (this.slideDir == 1)
								{
									num115 += (float)this.width;
								}
								num115 += (float)this.slideDir;
								float num116 = this.position.Y + (float)this.height + 1f;
								if (this.gravDir < 0f)
								{
									num116 = this.position.Y - 1f;
								}
								num115 /= 16f;
								num116 /= 16f;
								if (WorldGen.SolidTile((int)num115, (int)num116) && WorldGen.SolidTile((int)num115, (int)num116 - 1))
								{
									flag36 = true;
								}
								if (this.spikedBoots >= 2)
								{
									if (flag36 && ((this.velocity.Y > 0f && this.gravDir == 1f) || (this.velocity.Y < num2 && this.gravDir == -1f)))
									{
										float num117 = num2;
										if (this.slowFall)
										{
											if (this.controlUp)
											{
												num117 = num2 / 10f * this.gravDir;
											}
											else
											{
												num117 = num2 / 3f * this.gravDir;
											}
										}
										this.fallStart = (int)(this.position.Y / 16f);
										if ((this.controlDown && this.gravDir == 1f) || (this.controlUp && this.gravDir == -1f))
										{
											this.velocity.Y = 4f * this.gravDir;
											int num118 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)((this.width / 2 - 4) * this.slideDir), this.position.Y + (float)(this.height / 2) + (float)(this.height / 2 - 4) * this.gravDir), 8, 8, 31, 0f, 0f, 0, default(Color), 1f);
											if (this.slideDir < 0)
											{
												Dust expr_B67A_cp_0 = Main.dust[num118];
												expr_B67A_cp_0.position.X = expr_B67A_cp_0.position.X - 10f;
											}
											if (this.gravDir < 0f)
											{
												Dust expr_B6A5_cp_0 = Main.dust[num118];
												expr_B6A5_cp_0.position.Y = expr_B6A5_cp_0.position.Y - 12f;
											}
											Main.dust[num118].velocity *= 0.1f;
											Main.dust[num118].scale *= 1.2f;
											Main.dust[num118].noGravity = true;
										}
										else
										{
											if (this.gravDir == -1f)
											{
												this.velocity.Y = (-num117 + 1E-05f) * this.gravDir;
											}
											else
											{
												this.velocity.Y = (-num117 + 1E-05f) * this.gravDir;
											}
										}
										this.sliding = true;
									}
								}
								else
								{
									if ((flag36 && (double)this.velocity.Y > 0.5 && this.gravDir == 1f) || ((double)this.velocity.Y < -0.5 && this.gravDir == -1f))
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
										int num119 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)((this.width / 2 - 4) * this.slideDir), this.position.Y + (float)(this.height / 2) + (float)(this.height / 2 - 4) * this.gravDir), 8, 8, 31, 0f, 0f, 0, default(Color), 1f);
										if (this.slideDir < 0)
										{
											Dust expr_B88A_cp_0 = Main.dust[num119];
											expr_B88A_cp_0.position.X = expr_B88A_cp_0.position.X - 10f;
										}
										if (this.gravDir < 0f)
										{
											Dust expr_B8B5_cp_0 = Main.dust[num119];
											expr_B8B5_cp_0.position.Y = expr_B8B5_cp_0.position.Y - 12f;
										}
										Main.dust[num119].velocity *= 0.1f;
										Main.dust[num119].scale *= 1.2f;
										Main.dust[num119].noGravity = true;
									}
								}
							}
							bool flag37 = false;
							if (this.grappling[0] == -1 && this.carpet && !this.jumpAgain && !this.jumpAgain2 && this.jump == 0 && this.velocity.Y != 0f && this.rocketTime == 0 && this.wingTime == 0)
							{
								if (this.controlJump && this.canCarpet)
								{
									this.canCarpet = false;
									this.carpetTime = 300;
								}
								if (this.carpetTime > 0 && this.controlJump)
								{
									this.fallStart = (int)(this.position.Y / 16f);
									flag37 = true;
									this.carpetTime--;
									if (this.gravDir == 1f && this.velocity.Y > -num2)
									{
										this.velocity.Y = -(num2 + 1E-06f);
									}
									else
									{
										if (this.gravDir == -1f && this.velocity.Y < num2)
										{
											this.velocity.Y = num2 + 1E-06f;
										}
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
							if (!flag37)
							{
								this.carpetFrame = -1;
							}
							if (this.dJumpEffect && this.doubleJump && !this.jumpAgain && (this.jumpAgain2 || !this.doubleJump2) && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
							{
								int num120 = this.height;
								if (this.gravDir == -1f)
								{
									num120 = -6;
								}
								int num121 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)num120), this.width + 8, 4, 16, -this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 100, default(Color), 1.5f);
								Main.dust[num121].velocity.X = Main.dust[num121].velocity.X * 0.5f - this.velocity.X * 0.1f;
								Main.dust[num121].velocity.Y = Main.dust[num121].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
							}
							if (this.dJumpEffect2 && this.doubleJump2 && !this.jumpAgain2 && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
							{
								int num122 = this.height;
								if (this.gravDir == -1f)
								{
									num122 = -6;
								}
								float num123 = ((float)this.jump / 75f + 1f) / 2f;
								for (int num124 = 0; num124 < 3; num124++)
								{
									int num125 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)(num122 / 2)), this.width, 32, 124, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 150, default(Color), 1f * num123);
									Main.dust[num125].velocity *= 0.5f * num123;
									Main.dust[num125].fadeIn = 1.5f * num123;
								}
								this.sandStorm = true;
								if (this.miscCounter % 3 == 0)
								{
									int num126 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 18f, this.position.Y + (float)(num122 / 2)), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(220, 223), num123);
									Main.gore[num126].velocity = this.velocity * 0.3f * num123;
									Main.gore[num126].alpha = 100;
								}
							}
							if (this.dJumpEffect3 && this.doubleJump3 && !this.jumpAgain3 && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
							{
								int num127 = this.height - 6;
								if (this.gravDir == -1f)
								{
									num127 = 6;
								}
								for (int num128 = 0; num128 < 2; num128++)
								{
									int num129 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)num127), this.width, 12, 76, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 0, default(Color), 1f);
									Main.dust[num129].velocity *= 0.1f;
									if (num128 == 0)
									{
										Main.dust[num129].velocity += this.velocity * 0.03f;
									}
									else
									{
										Main.dust[num129].velocity -= this.velocity * 0.03f;
									}
									Main.dust[num129].noLight = true;
								}
								for (int num130 = 0; num130 < 3; num130++)
								{
									int num131 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)num127), this.width, 12, 76, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 0, default(Color), 1f);
									Main.dust[num131].fadeIn = 1.5f;
									Main.dust[num131].velocity *= 0.6f;
									Main.dust[num131].velocity += this.velocity * 0.8f;
									Main.dust[num131].noGravity = true;
									Main.dust[num131].noLight = true;
								}
								for (int num132 = 0; num132 < 3; num132++)
								{
									int num133 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)num127), this.width, 12, 76, this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 0, default(Color), 1f);
									Main.dust[num133].fadeIn = 1.5f;
									Main.dust[num133].velocity *= 0.6f;
									Main.dust[num133].velocity -= this.velocity * 0.8f;
									Main.dust[num133].noGravity = true;
									Main.dust[num133].noLight = true;
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
							bool flag38 = false;
							if (this.velocity.Y == 0f || this.sliding)
							{
								this.wingTime = this.GetWingTime();
							}
							if (this.wings > 0 && this.controlJump && this.wingTime > 0 && !this.jumpAgain && this.jump == 0 && this.velocity.Y != 0f)
							{
								flag38 = true;
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
								if (flag38)
								{
									if (this.wings == 10 && Main.rand.Next(2) == 0)
									{
										int num134 = 4;
										if (this.direction == 1)
										{
											num134 = -40;
										}
										int num135 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num134, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 76, 0f, 0f, 50, default(Color), 0.6f);
										Main.dust[num135].fadeIn = 1.1f;
										Main.dust[num135].noGravity = true;
										Main.dust[num135].noLight = true;
										Main.dust[num135].velocity *= 0.3f;
									}
									if (this.wings == 9 && Main.rand.Next(2) == 0)
									{
										int num136 = 4;
										if (this.direction == 1)
										{
											num136 = -40;
										}
										int num137 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num136, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 6, 0f, 0f, 200, default(Color), 2f);
										Main.dust[num137].noGravity = true;
										Main.dust[num137].velocity *= 0.3f;
									}
									if (this.wings == 6 && Main.rand.Next(4) == 0)
									{
										int num138 = 4;
										if (this.direction == 1)
										{
											num138 = -40;
										}
										int num139 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num138, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 55, 0f, 0f, 200, default(Color), 1f);
										Main.dust[num139].velocity *= 0.3f;
									}
									if (this.wings == 5 && Main.rand.Next(3) == 0)
									{
										int num140 = 6;
										if (this.direction == 1)
										{
											num140 = -30;
										}
										int num141 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num140, this.position.Y), 18, this.height, 58, 0f, 0f, 255, default(Color), 1.2f);
										Main.dust[num141].velocity *= 0.3f;
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
											else
											{
												if (this.velocity.Y > -Player.jumpSpeed)
												{
													this.velocity.Y = this.velocity.Y - 0.2f;
												}
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
											else
											{
												if (this.velocity.Y < Player.jumpSpeed)
												{
													this.velocity.Y = this.velocity.Y + 0.2f;
												}
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
										if (this.wings == 3 && this.controlUp)
										{
											this.velocity.Y = this.velocity.Y - 0.3f * this.gravDir;
											if (this.gravDir == 1f)
											{
												if (this.velocity.Y > 0f)
												{
													this.velocity.Y = this.velocity.Y - 1f;
												}
												else
												{
													if (this.velocity.Y > -Player.jumpSpeed)
													{
														this.velocity.Y = this.velocity.Y - 0.2f;
													}
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
												else
												{
													if (this.velocity.Y < Player.jumpSpeed)
													{
														this.velocity.Y = this.velocity.Y + 0.2f;
													}
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
												else
												{
													if ((double)this.velocity.Y > (double)(-(double)Player.jumpSpeed) * 0.5)
													{
														this.velocity.Y = this.velocity.Y - 0.1f;
													}
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
												else
												{
													if ((double)this.velocity.Y < (double)Player.jumpSpeed * 0.5)
													{
														this.velocity.Y = this.velocity.Y + 0.1f;
													}
												}
												if (this.velocity.Y > Player.jumpSpeed * 1.5f)
												{
													this.velocity.Y = Player.jumpSpeed * 1.5f;
												}
											}
											this.wingTime--;
										}
									}
								}
								if (this.wings == 4)
								{
									if (flag38 || this.jump > 0)
									{
										this.rocketDelay2--;
										if (this.rocketDelay2 <= 0)
										{
											Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 13);
											this.rocketDelay2 = 60;
										}
										int num142 = 2;
										if (this.controlUp)
										{
											num142 = 4;
										}
										for (int num143 = 0; num143 < num142; num143++)
										{
											int type3 = 6;
											if (this.head == 41)
											{
												int arg_CA5A_0 = this.body;
											}
											float scale = 1.75f;
											int alpha = 100;
											float x = this.position.X + (float)(this.width / 2) + 16f;
											if (this.direction > 0)
											{
												x = this.position.X + (float)(this.width / 2) - 26f;
											}
											float num144 = this.position.Y + (float)this.height - 18f;
											if (num143 == 1 || num143 == 3)
											{
												x = this.position.X + (float)(this.width / 2) + 8f;
												if (this.direction > 0)
												{
													x = this.position.X + (float)(this.width / 2) - 20f;
												}
												num144 += 6f;
											}
											if (num143 > 1)
											{
												num144 += this.velocity.Y;
											}
											int num145 = Dust.NewDust(new Vector2(x, num144), 8, 8, type3, 0f, 0f, alpha, default(Color), scale);
											Dust expr_CB6D_cp_0 = Main.dust[num145];
											expr_CB6D_cp_0.velocity.X = expr_CB6D_cp_0.velocity.X * 0.1f;
											Main.dust[num145].velocity.Y = Main.dust[num145].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
											Main.dust[num145].noGravity = true;
											if (num142 == 4)
											{
												Dust expr_CBE7_cp_0 = Main.dust[num145];
												expr_CBE7_cp_0.velocity.Y = expr_CBE7_cp_0.velocity.Y + 6f;
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
									else
									{
										if (!this.controlJump || this.velocity.Y == 0f)
										{
											this.wingFrame = 3;
										}
									}
								}
								else
								{
									if (this.wings == 12)
									{
										if (flag38 || this.jump > 0)
										{
											this.wingFrameCounter++;
											int num146 = 5;
											if (this.wingFrameCounter < num146)
											{
												this.wingFrame = 1;
											}
											else
											{
												if (this.wingFrameCounter < num146 * 2)
												{
													this.wingFrame = 2;
												}
												else
												{
													if (this.wingFrameCounter < num146 * 3)
													{
														this.wingFrame = 3;
													}
													else
													{
														if (this.wingFrameCounter < num146 * 4 - 1)
														{
															this.wingFrame = 2;
														}
														else
														{
															this.wingFrame = 2;
															this.wingFrameCounter = 0;
														}
													}
												}
											}
										}
										else
										{
											if (this.velocity.Y != 0f)
											{
												this.wingFrame = 2;
											}
											else
											{
												this.wingFrame = 0;
											}
										}
									}
									else
									{
										if (flag38 || this.jump > 0)
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
										else
										{
											if (this.velocity.Y != 0f)
											{
												this.wingFrame = 1;
											}
											else
											{
												this.wingFrame = 0;
											}
										}
									}
								}
								if (this.wings > 0 && this.rocketBoots > 0)
								{
									this.wingTime += this.rocketTime * 3;
									this.rocketTime = 0;
								}
								if (flag38 && this.wings != 4)
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
											else
											{
												if (this.rocketBoots == 2)
												{
													Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 24);
													this.rocketDelay2 = 15;
												}
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
									int num147 = this.height;
									if (this.gravDir == -1f)
									{
										num147 = 4;
									}
									this.rocketFrame = true;
									for (int num148 = 0; num148 < 2; num148++)
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
										else
										{
											if (this.socialShadow)
											{
												type4 = 27;
												scale2 = 1.5f;
											}
										}
										if (num148 == 0)
										{
											int num149 = Dust.NewDust(new Vector2(this.position.X - 4f, this.position.Y + (float)num147 - 10f), 8, 8, type4, 0f, 0f, alpha2, default(Color), scale2);
											if (this.rocketBoots == 1)
											{
												Main.dust[num149].noGravity = true;
											}
											Main.dust[num149].velocity.X = Main.dust[num149].velocity.X * 1f - 2f - this.velocity.X * 0.3f;
											Main.dust[num149].velocity.Y = Main.dust[num149].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
											if (this.rocketBoots == 2)
											{
												Main.dust[num149].velocity *= 0.1f;
											}
										}
										else
										{
											int num150 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 4f, this.position.Y + (float)num147 - 10f), 8, 8, type4, 0f, 0f, alpha2, default(Color), scale2);
											if (this.rocketBoots == 1)
											{
												Main.dust[num150].noGravity = true;
											}
											Main.dust[num150].velocity.X = Main.dust[num150].velocity.X * 1f + 2f - this.velocity.X * 0.3f;
											Main.dust[num150].velocity.Y = Main.dust[num150].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
											if (this.rocketBoots == 2)
											{
												Main.dust[num150].velocity *= 0.1f;
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
										else
										{
											if ((double)this.velocity.Y > (double)(-(double)Player.jumpSpeed) * 0.5)
											{
												this.velocity.Y = this.velocity.Y - 0.1f;
											}
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
										else
										{
											if ((double)this.velocity.Y < (double)Player.jumpSpeed * 0.5)
											{
												this.velocity.Y = this.velocity.Y + 0.1f;
											}
										}
										if (this.velocity.Y > Player.jumpSpeed * 1.5f)
										{
											this.velocity.Y = Player.jumpSpeed * 1.5f;
										}
									}
								}
								else
								{
									if (!flag38)
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
										else
										{
											if (this.wings > 0 && this.controlJump && this.velocity.Y > 0f)
											{
												this.fallStart = (int)(this.position.Y / 16f);
												if (this.velocity.Y > 0f)
												{
													if (this.wings == 10 && Main.rand.Next(3) == 0)
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
													if (this.wings == 9 && Main.rand.Next(3) == 0)
													{
														int num153 = 8;
														if (this.direction == 1)
														{
															num153 = -40;
														}
														int num154 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num153, this.position.Y + (float)(this.height / 2) - 15f), 30, 30, 6, 0f, 0f, 200, default(Color), 2f);
														Main.dust[num154].noGravity = true;
														Main.dust[num154].velocity *= 0.3f;
													}
													if (this.wings == 6)
													{
														if (Main.rand.Next(10) == 0)
														{
															int num155 = 4;
															if (this.direction == 1)
															{
																num155 = -40;
															}
															int num156 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num155, this.position.Y + (float)(this.height / 2) - 12f), 30, 20, 55, 0f, 0f, 200, default(Color), 1f);
															Main.dust[num156].velocity *= 0.3f;
														}
													}
													else
													{
														if (this.wings == 5 && Main.rand.Next(6) == 0)
														{
															int num157 = 6;
															if (this.direction == 1)
															{
																num157 = -30;
															}
															int num158 = Dust.NewDust(new Vector2(this.position.X + (float)(this.width / 2) + (float)num157, this.position.Y), 18, this.height, 58, 0f, 0f, 255, default(Color), 1.2f);
															Main.dust[num158].velocity *= 0.3f;
														}
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
														float num159 = this.position.Y + (float)this.height - 18f;
														if (Main.rand.Next(2) == 1)
														{
															x2 = this.position.X + (float)(this.width / 2) + 8f;
															if (this.direction > 0)
															{
																x2 = this.position.X + (float)(this.width / 2) - 20f;
															}
															num159 += 6f;
														}
														int num160 = Dust.NewDust(new Vector2(x2, num159), 8, 8, type5, 0f, 0f, alpha3, default(Color), scale3);
														Dust expr_D8DE_cp_0 = Main.dust[num160];
														expr_D8DE_cp_0.velocity.X = expr_D8DE_cp_0.velocity.X * 0.3f;
														Dust expr_D8FC_cp_0 = Main.dust[num160];
														expr_D8FC_cp_0.velocity.Y = expr_D8FC_cp_0.velocity.Y + 10f;
														Main.dust[num160].noGravity = true;
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
													else
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
												else
												{
													if (this.velocity.Y < -num / 3f && !this.controlUp)
													{
														this.velocity.Y = -num / 3f;
													}
												}
											}
											else
											{
												this.velocity.Y = this.velocity.Y + num2 * this.gravDir;
											}
										}
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
					}
					if (this.wings == 3)
					{
						if (this.controlUp && this.controlDown)
						{
							this.velocity.Y = 0f;
						}
						else
						{
							if (this.controlDown && this.controlJump)
							{
								this.velocity.Y = this.velocity.Y * 0.9f;
								if (this.velocity.Y > -2f && this.velocity.Y < 1f)
								{
									this.velocity.Y = 1E-05f;
								}
							}
							else
							{
								if (this.controlDown && this.velocity.Y != 0f)
								{
									this.velocity.Y = this.velocity.Y + 0.2f;
								}
							}
						}
					}
					for (int num161 = 0; num161 < 400; num161++)
					{
						if (Main.item[num161].active && Main.item[num161].noGrabDelay == 0 && Main.item[num161].owner == i)
						{
							if (new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height).Intersects(new Rectangle((int)Main.item[num161].position.X, (int)Main.item[num161].position.Y, Main.item[num161].width, Main.item[num161].height)))
							{
								if (i == Main.myPlayer && (this.inventory[this.selectedItem].type != 0 || this.itemAnimation <= 0))
								{
									if (Main.item[num161].type == 58)
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
										Main.item[num161] = new Item();
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num161, 0f, 0f, 0f, 0);
										}
									}
									else
									{
										if (Main.item[num161].type == 184)
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
											Main.item[num161] = new Item();
											if (Main.netMode == 1)
											{
												NetMessage.SendData(21, -1, -1, "", num161, 0f, 0f, 0f, 0);
											}
										}
										else
										{
											Main.item[num161] = this.GetItem(i, Main.item[num161]);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(21, -1, -1, "", num161, 0f, 0f, 0f, 0);
											}
										}
									}
								}
							}
							else
							{
								if (new Rectangle((int)this.position.X - Player.itemGrabRange, (int)this.position.Y - Player.itemGrabRange, this.width + Player.itemGrabRange * 2, this.height + Player.itemGrabRange * 2).Intersects(new Rectangle((int)Main.item[num161].position.X, (int)Main.item[num161].position.Y, Main.item[num161].width, Main.item[num161].height)) && this.ItemSpace(Main.item[num161]))
								{
									Main.item[num161].beingGrabbed = true;
									if ((double)this.position.X + (double)this.width * 0.5 > (double)Main.item[num161].position.X + (double)Main.item[num161].width * 0.5)
									{
										if (Main.item[num161].velocity.X < Player.itemGrabSpeedMax + this.velocity.X)
										{
											Item expr_DFDA_cp_0 = Main.item[num161];
											expr_DFDA_cp_0.velocity.X = expr_DFDA_cp_0.velocity.X + Player.itemGrabSpeed;
										}
										if (Main.item[num161].velocity.X < 0f)
										{
											Item expr_E014_cp_0 = Main.item[num161];
											expr_E014_cp_0.velocity.X = expr_E014_cp_0.velocity.X + Player.itemGrabSpeed * 0.75f;
										}
									}
									else
									{
										if (Main.item[num161].velocity.X > -Player.itemGrabSpeedMax + this.velocity.X)
										{
											Item expr_E063_cp_0 = Main.item[num161];
											expr_E063_cp_0.velocity.X = expr_E063_cp_0.velocity.X - Player.itemGrabSpeed;
										}
										if (Main.item[num161].velocity.X > 0f)
										{
											Item expr_E09A_cp_0 = Main.item[num161];
											expr_E09A_cp_0.velocity.X = expr_E09A_cp_0.velocity.X - Player.itemGrabSpeed * 0.75f;
										}
									}
									if ((double)this.position.Y + (double)this.height * 0.5 > (double)Main.item[num161].position.Y + (double)Main.item[num161].height * 0.5)
									{
										if (Main.item[num161].velocity.Y < Player.itemGrabSpeedMax)
										{
											Item expr_E123_cp_0 = Main.item[num161];
											expr_E123_cp_0.velocity.Y = expr_E123_cp_0.velocity.Y + Player.itemGrabSpeed;
										}
										if (Main.item[num161].velocity.Y < 0f)
										{
											Item expr_E15D_cp_0 = Main.item[num161];
											expr_E15D_cp_0.velocity.Y = expr_E15D_cp_0.velocity.Y + Player.itemGrabSpeed * 0.75f;
										}
									}
									else
									{
										if (Main.item[num161].velocity.Y > -Player.itemGrabSpeedMax)
										{
											Item expr_E19D_cp_0 = Main.item[num161];
											expr_E19D_cp_0.velocity.Y = expr_E19D_cp_0.velocity.Y - Player.itemGrabSpeed;
										}
										if (Main.item[num161].velocity.Y > 0f)
										{
											Item expr_E1D4_cp_0 = Main.item[num161];
											expr_E1D4_cp_0.velocity.Y = expr_E1D4_cp_0.velocity.Y - Player.itemGrabSpeed * 0.75f;
										}
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
								else
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 72)
									{
										this.showItemIcon2 = 644;
									}
									else
									{
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 108)
										{
											this.showItemIcon2 = 645;
										}
										else
										{
											if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 144)
											{
												this.showItemIcon2 = 646;
											}
											else
											{
												if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 180)
												{
													this.showItemIcon2 = 920;
												}
												else
												{
													if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 216)
													{
														this.showItemIcon2 = 1470;
													}
													else
													{
														if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 252)
														{
															this.showItemIcon2 = 1471;
														}
														else
														{
															if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 288)
															{
																this.showItemIcon2 = 1472;
															}
															else
															{
																if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY < 324)
																{
																	this.showItemIcon2 = 1473;
																}
																else
																{
																	this.showItemIcon2 = 646;
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
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 209)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 72)
								{
									this.showItemIcon2 = 928;
								}
								else
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 144)
									{
										this.showItemIcon2 = 1337;
									}
								}
								int num162;
								for (num162 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18); num162 >= 4; num162 -= 4)
								{
								}
								if (num162 < 2)
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
								int num163 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
								int num164 = 0;
								while (num163 >= 40)
								{
									num163 -= 40;
									num164++;
								}
								this.showItemIcon2 = 970 + num164;
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
								else
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 936)
									{
										this.showItemIcon2 = 1536;
									}
									else
									{
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 900)
										{
											this.showItemIcon2 = 1535;
										}
										else
										{
											if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 864)
											{
												this.showItemIcon2 = 1534;
											}
											else
											{
												if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 828)
												{
													this.showItemIcon2 = 1533;
												}
												else
												{
													if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 792)
													{
														this.showItemIcon2 = 1532;
													}
													else
													{
														if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 756)
														{
															this.showItemIcon2 = 1531;
														}
														else
														{
															if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 720)
															{
																this.showItemIcon2 = 1530;
															}
															else
															{
																if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 684)
																{
																	this.showItemIcon2 = 1529;
																}
																else
																{
																	if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 648)
																	{
																		this.showItemIcon2 = 1528;
																	}
																	else
																	{
																		if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 612)
																		{
																			this.showItemIcon2 = 1298;
																		}
																		else
																		{
																			if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 576)
																			{
																				this.showItemIcon2 = 1142;
																			}
																			else
																			{
																				if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 540)
																				{
																					this.showItemIcon2 = 952;
																				}
																				else
																				{
																					if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 504)
																					{
																						this.showItemIcon2 = 914;
																					}
																					else
																					{
																						if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 468)
																						{
																							this.showItemIcon2 = 838;
																						}
																						else
																						{
																							if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 432)
																							{
																								this.showItemIcon2 = 831;
																							}
																							else
																							{
																								if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 396)
																								{
																									this.showItemIcon2 = 681;
																								}
																								else
																								{
																									if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 360)
																									{
																										this.showItemIcon2 = 680;
																									}
																									else
																									{
																										if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 324)
																										{
																											this.showItemIcon2 = 627;
																										}
																										else
																										{
																											if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 288)
																											{
																												this.showItemIcon2 = 626;
																											}
																											else
																											{
																												if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 252)
																												{
																													this.showItemIcon2 = 625;
																												}
																												else
																												{
																													if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 216)
																													{
																														this.showItemIcon2 = 348;
																													}
																													else
																													{
																														if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 180)
																														{
																															this.showItemIcon2 = 343;
																														}
																														else
																														{
																															if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 144)
																															{
																																this.showItemIcon2 = 329;
																															}
																															else
																															{
																																if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 108)
																																{
																																	this.showItemIcon2 = 328;
																																}
																																else
																																{
																																	if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 72)
																																	{
																																		this.showItemIcon2 = 327;
																																	}
																																	else
																																	{
																																		if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 36)
																																		{
																																			this.showItemIcon2 = 306;
																																		}
																																		else
																																		{
																																			this.showItemIcon2 = 48;
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
												}
											}
										}
									}
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 4)
							{
								this.noThrow = 2;
								this.showItemIcon = true;
								int num165 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 22);
								if (num165 == 0)
								{
									this.showItemIcon2 = 8;
								}
								else
								{
									if (num165 == 8)
									{
										this.showItemIcon2 = 523;
									}
									else
									{
										if (num165 == 9)
										{
											this.showItemIcon2 = 974;
										}
										else
										{
											if (num165 == 10)
											{
												this.showItemIcon2 = 1245;
											}
											else
											{
												if (num165 == 11)
												{
													this.showItemIcon2 = 1333;
												}
												else
												{
													this.showItemIcon2 = 426 + num165;
												}
											}
										}
									}
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
								else
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 54)
									{
										this.showItemIcon2 = 350;
									}
									else
									{
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 18)
										{
											this.showItemIcon2 = 28;
										}
										else
										{
											if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 36)
											{
												this.showItemIcon2 = 110;
											}
											else
											{
												this.showItemIcon2 = 31;
											}
										}
									}
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
								int num166 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 22);
								if (num166 == 1)
								{
									this.showItemIcon2 = 1405;
								}
								if (num166 == 2)
								{
									this.showItemIcon2 = 1406;
								}
								if (num166 == 3)
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
								int num167 = Player.tileTargetX;
								int num168 = Player.tileTargetY;
								int num169 = 0;
								for (int num170 = (int)(Main.tile[num167, num168].frameY / 18); num170 >= 2; num170 -= 2)
								{
									num169++;
								}
								this.showItemIcon = true;
								if (num169 >= 13)
								{
									this.showItemIcon2 = 1596 + num169 - 13;
								}
								else
								{
									this.showItemIcon2 = 562 + num169;
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 207)
							{
								this.noThrow = 2;
								int num171 = Player.tileTargetX;
								int num172 = Player.tileTargetY;
								int num173 = 0;
								for (int num174 = (int)(Main.tile[num171, num172].frameX / 18); num174 >= 2; num174 -= 2)
								{
									num173++;
								}
								this.showItemIcon = true;
								if (num173 == 0)
								{
									this.showItemIcon2 = 909;
								}
								else
								{
									if (num173 == 1)
									{
										this.showItemIcon2 = 910;
									}
									else
									{
										if (num173 == 2)
										{
											this.showItemIcon2 = 940;
										}
										else
										{
											if (num173 == 3)
											{
												this.showItemIcon2 = 941;
											}
											else
											{
												if (num173 == 4)
												{
													this.showItemIcon2 = 942;
												}
												else
												{
													if (num173 == 5)
													{
														this.showItemIcon2 = 943;
													}
													else
													{
														if (num173 == 6)
														{
															this.showItemIcon2 = 944;
														}
														else
														{
															if (num173 == 7)
															{
																this.showItemIcon2 = 945;
															}
														}
													}
												}
											}
										}
									}
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 55 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 85)
							{
								this.noThrow = 2;
								int num175 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18);
								int num176 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
								while (num175 > 1)
								{
									num175 -= 2;
								}
								int num177 = Player.tileTargetX - num175;
								int num178 = Player.tileTargetY - num176;
								Main.signBubble = true;
								Main.signX = num177 * 16 + 16;
								Main.signY = num178 * 16;
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
								int num179 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
								int num180 = 0;
								while (num179 >= 54)
								{
									num179 -= 54;
									num180++;
								}
								if (num180 == 0)
								{
									this.showItemIcon2 = 25;
								}
								else
								{
									if (num180 == 9)
									{
										this.showItemIcon2 = 837;
									}
									else
									{
										if (num180 == 10)
										{
											this.showItemIcon2 = 912;
										}
										else
										{
											if (num180 == 11)
											{
												this.showItemIcon2 = 1141;
											}
											else
											{
												if (num180 == 12)
												{
													this.showItemIcon2 = 1137;
												}
												else
												{
													if (num180 == 13)
													{
														this.showItemIcon2 = 1138;
													}
													else
													{
														if (num180 == 14)
														{
															this.showItemIcon2 = 1139;
														}
														else
														{
															if (num180 == 15)
															{
																this.showItemIcon2 = 1140;
															}
															else
															{
																if (num180 == 16)
																{
																	this.showItemIcon2 = 1411;
																}
																else
																{
																	if (num180 == 17)
																	{
																		this.showItemIcon2 = 1412;
																	}
																	else
																	{
																		if (num180 == 18)
																		{
																			this.showItemIcon2 = 1413;
																		}
																		else
																		{
																			if (num180 == 19)
																			{
																				this.showItemIcon2 = 1458;
																			}
																			else
																			{
																				if (num180 >= 4 && num180 <= 8)
																				{
																					this.showItemIcon2 = 812 + num180;
																				}
																				else
																				{
																					this.showItemIcon2 = 649 + num180;
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
									}
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
									int num181 = Player.tileTargetX;
									int num182 = Player.tileTargetY;
									bool flag39 = false;
									for (int num183 = 0; num183 < 58; num183++)
									{
										if (this.inventory[num183].type == 949 && this.inventory[num183].stack > 0)
										{
											this.inventory[num183].stack--;
											if (this.inventory[num183].stack <= 0)
											{
												this.inventory[num183].SetDefaults(0, false);
											}
											flag39 = true;
											break;
										}
									}
									if (flag39)
									{
										this.launcherWait = 10;
										Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 11);
										int num184 = (int)(Main.tile[num181, num182].frameX / 18);
										int num185 = 0;
										while (num184 >= 3)
										{
											num185++;
											num184 -= 3;
										}
										num184 = num181 - num184;
										int num186;
										for (num186 = (int)(Main.tile[num181, num182].frameY / 18); num186 >= 3; num186 -= 3)
										{
										}
										num186 = num182 - num186;
										float num187 = 12f + (float)Main.rand.Next(450) * 0.01f;
										float num188 = (float)Main.rand.Next(85, 105);
										float num189 = (float)Main.rand.Next(-35, 11);
										int type6 = 166;
										int damage2 = 17;
										float knockBack = 3.5f;
										Vector2 vector = new Vector2((float)((num184 + 2) * 16 - 8), (float)((num186 + 2) * 16 - 8));
										if (num185 == 0)
										{
											num188 *= -1f;
											vector.X -= 12f;
										}
										else
										{
											vector.X += 12f;
										}
										float num190 = num188;
										float num191 = num189;
										float num192 = (float)Math.Sqrt((double)(num190 * num190 + num191 * num191));
										num192 = num187 / num192;
										num190 *= num192;
										num191 *= num192;
										Projectile.NewProjectile(vector.X, vector.Y, num190, num191, type6, damage2, knockBack, Main.myPlayer, 0f, 0f);
									}
								}
								if (this.releaseUseTile)
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 132 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 136 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 144)
									{
										WorldGen.hitSwitch(Player.tileTargetX, Player.tileTargetY);
										NetMessage.SendData(59, -1, -1, "", Player.tileTargetX, (float)Player.tileTargetY, 0f, 0f, 0);
									}
									else
									{
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 139)
										{
											Main.PlaySound(28, Player.tileTargetX * 16, Player.tileTargetY * 16, 0);
											WorldGen.SwitchMB(Player.tileTargetX, Player.tileTargetY);
										}
										else
										{
											if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 207)
											{
												Main.PlaySound(28, Player.tileTargetX * 16, Player.tileTargetY * 16, 0);
												WorldGen.SwitchFountain(Player.tileTargetX, Player.tileTargetY);
											}
											else
											{
												if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 216)
												{
													WorldGen.LaunchRocket(Player.tileTargetX, Player.tileTargetY);
												}
												else
												{
													if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 4 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 13 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 33 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 49 || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 50 && Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 90))
													{
														WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
														if (Main.netMode == 1)
														{
															NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
														}
													}
													else
													{
														if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 125)
														{
															this.AddBuff(29, 36000, true);
															Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 4);
														}
														else
														{
															if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 79)
															{
																int num193 = Player.tileTargetX;
																int num194 = Player.tileTargetY;
																num193 += (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18 * -1);
																if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 72)
																{
																	num193 += 4;
																	num193++;
																}
																else
																{
																	num193 += 2;
																}
																int num195 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
																int num196 = 0;
																while (num195 > 1)
																{
																	num195 -= 2;
																	num196++;
																}
																num194 -= num195;
																num194 += 2;
																if (Player.CheckSpawn(num193, num194))
																{
																	this.ChangeSpawn(num193, num194);
																	Main.NewText("Spawn point set!", 255, 240, 20, false);
																}
															}
															else
															{
																if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 55 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 85)
																{
																	bool flag40 = true;
																	if (this.sign >= 0)
																	{
																		int num197 = Sign.ReadSign(Player.tileTargetX, Player.tileTargetY);
																		if (num197 == this.sign)
																		{
																			this.sign = -1;
																			Main.npcChatText = "";
																			Main.editSign = false;
																			Main.PlaySound(11, -1, -1, 1);
																			flag40 = false;
																		}
																	}
																	if (flag40)
																	{
																		if (Main.netMode == 0)
																		{
																			this.talkNPC = -1;
																			Main.playerInventory = false;
																			Main.editSign = false;
																			Main.PlaySound(10, -1, -1, 1);
																			int num198 = Sign.ReadSign(Player.tileTargetX, Player.tileTargetY);
																			this.sign = num198;
																			Main.npcChatText = Main.sign[num198].text;
																		}
																		else
																		{
																			int num199 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18);
																			int num200 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
																			while (num199 > 1)
																			{
																				num199 -= 2;
																			}
																			int num201 = Player.tileTargetX - num199;
																			int num202 = Player.tileTargetY - num200;
																			if (Main.tile[num201, num202].type == 55 || Main.tile[num201, num202].type == 85)
																			{
																				NetMessage.SendData(46, -1, -1, "", num201, (float)num202, 0f, 0f, 0);
																			}
																		}
																	}
																}
																else
																{
																	if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 104)
																	{
																		string text = "AM";
																		double num203 = Main.time;
																		if (!Main.dayTime)
																		{
																			num203 += 54000.0;
																		}
																		num203 = num203 / 86400.0 * 24.0;
																		double num204 = 7.5;
																		num203 = num203 - num204 - 12.0;
																		if (num203 < 0.0)
																		{
																			num203 += 24.0;
																		}
																		if (num203 >= 12.0)
																		{
																			text = "PM";
																		}
																		int num205 = (int)num203;
																		double num206 = num203 - (double)num205;
																		num206 = (double)((int)(num206 * 60.0));
																		string text2 = string.Concat(num206);
																		if (num206 < 10.0)
																		{
																			text2 = "0" + text2;
																		}
																		if (num205 > 12)
																		{
																			num205 -= 12;
																		}
																		if (num205 == 0)
																		{
																			num205 = 12;
																		}
																		string newText = string.Concat(new object[]
																		{
																			"Time: ",
																			num205,
																			":",
																			text2,
																			" ",
																			text
																		});
																		Main.NewText(newText, 255, 240, 20, false);
																	}
																	else
																	{
																		if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 237)
																		{
																			bool flag41 = false;
																			if (!NPC.AnyNPCs(245))
																			{
																				for (int num207 = 0; num207 < 58; num207++)
																				{
																					if (this.inventory[num207].type == 1293)
																					{
																						this.inventory[num207].stack--;
																						if (this.inventory[num207].stack <= 0)
																						{
																							this.inventory[num207].SetDefaults(0, false);
																						}
																						flag41 = true;
																					}
																				}
																			}
																			if (flag41)
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
																		else
																		{
																			if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 10)
																			{
																				int num208 = Player.tileTargetX;
																				int num209 = Player.tileTargetY;
																				if (Main.tile[num208, num209].frameY >= 594 && Main.tile[num208, num209].frameY <= 646)
																				{
																					int num210 = 1141;
																					for (int num211 = 0; num211 < 58; num211++)
																					{
																						if (this.inventory[num211].type == num210 && this.inventory[num211].stack > 0)
																						{
																							this.inventory[num211].stack--;
																							if (this.inventory[num211].stack <= 0)
																							{
																								this.inventory[num211] = new Item();
																							}
																							WorldGen.UnlockDoor(num208, num209);
																							if (Main.netMode == 1)
																							{
																								NetMessage.SendData(52, -1, -1, "", this.whoAmi, 2f, (float)num208, (float)num209, 0);
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
																			else
																			{
																				if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 11 && WorldGen.CloseDoor(Player.tileTargetX, Player.tileTargetY, false))
																				{
																					NetMessage.SendData(19, -1, -1, "", 1, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.direction, 0);
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
									}
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 209)
									{
										WorldGen.SwitchCannon(Player.tileTargetX, Player.tileTargetY);
									}
									else
									{
										if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 21 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 29 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 97) && this.talkNPC == -1)
										{
											int num212 = 0;
											int num213;
											for (num213 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18); num213 > 1; num213 -= 2)
											{
											}
											num213 = Player.tileTargetX - num213;
											int num214 = Player.tileTargetY - (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
											if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 29)
											{
												num212 = 1;
											}
											else
											{
												if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 97)
												{
													num212 = 2;
												}
												else
												{
													if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 252)
													{
														Main.chestText = "Chest";
													}
													else
													{
														if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 216)
														{
															Main.chestText = "Trash Can";
														}
														else
														{
															if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 180)
															{
																Main.chestText = "Barrel";
															}
															else
															{
																Main.chestText = "Chest";
															}
														}
													}
												}
											}
											if (Main.netMode == 1 && num212 == 0 && (Main.tile[num213, num214].frameX < 72 || Main.tile[num213, num214].frameX > 106) && (Main.tile[num213, num214].frameX < 144 || Main.tile[num213, num214].frameX > 178) && (Main.tile[num213, num214].frameX < 828 || Main.tile[num213, num214].frameX > 1006))
											{
												if (num213 == this.chestX && num214 == this.chestY && this.chest != -1)
												{
													this.chest = -1;
													Main.PlaySound(11, -1, -1, 1);
												}
												else
												{
													NetMessage.SendData(31, -1, -1, "", num213, (float)num214, 0f, 0f, 0);
												}
											}
											else
											{
												int num215 = -1;
												if (num212 == 1)
												{
													num215 = -2;
												}
												else
												{
													if (num212 == 2)
													{
														num215 = -3;
													}
													else
													{
														bool flag42 = false;
														if ((Main.tile[num213, num214].frameX >= 72 && Main.tile[num213, num214].frameX <= 106) || (Main.tile[num213, num214].frameX >= 144 && Main.tile[num213, num214].frameX <= 178) || (Main.tile[num213, num214].frameX >= 828 && Main.tile[num213, num214].frameX <= 1006))
														{
															int num216 = 327;
															if (Main.tile[num213, num214].frameX >= 144 && Main.tile[num213, num214].frameX <= 178)
															{
																num216 = 329;
															}
															if (Main.tile[num213, num214].frameX >= 828 && Main.tile[num213, num214].frameX <= 1006)
															{
																int num217 = (int)(Main.tile[num213, num214].frameX / 18);
																int num218 = 0;
																while (num217 >= 2)
																{
																	num217 -= 2;
																	num218++;
																}
																num218 -= 23;
																num216 = 1533 + num218;
															}
															flag42 = true;
															for (int num219 = 0; num219 < 58; num219++)
															{
																if (this.inventory[num219].type == num216 && this.inventory[num219].stack > 0)
																{
																	if (num216 != 329)
																	{
																		this.inventory[num219].stack--;
																		if (this.inventory[num219].stack <= 0)
																		{
																			this.inventory[num219] = new Item();
																		}
																	}
																	Chest.Unlock(num213, num214);
																	if (Main.netMode == 1)
																	{
																		NetMessage.SendData(52, -1, -1, "", this.whoAmi, 1f, (float)num213, (float)num214, 0);
																	}
																}
															}
														}
														if (!flag42)
														{
															num215 = Chest.FindChest(num213, num214);
														}
													}
												}
												if (num215 != -1)
												{
													if (num215 == this.chest)
													{
														this.chest = -1;
														Main.PlaySound(11, -1, -1, 1);
													}
													else
													{
														if (num215 != this.chest && this.chest == -1)
														{
															this.chest = num215;
															Main.playerInventory = true;
															Main.PlaySound(10, -1, -1, 1);
															this.chestX = num213;
															this.chestY = num214;
														}
														else
														{
															this.chest = num215;
															Main.playerInventory = true;
															Main.PlaySound(12, -1, -1, 1);
															this.chestX = num213;
															this.chestY = num214;
														}
													}
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
						bool flag43 = false;
						if (Main.wof >= 0)
						{
							float num220 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2);
							num220 += (float)(Main.npc[Main.wof].direction * 200);
							float num221 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2);
							Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
							float num222 = num220 - vector2.X;
							float num223 = num221 - vector2.Y;
							float num224 = (float)Math.Sqrt((double)(num222 * num222 + num223 * num223));
							float num225 = 11f;
							float num226;
							if (num224 > num225)
							{
								num226 = num225 / num224;
							}
							else
							{
								num226 = 1f;
								flag43 = true;
							}
							num222 *= num226;
							num223 *= num226;
							this.velocity.X = num222;
							this.velocity.Y = num223;
						}
						else
						{
							flag43 = true;
						}
						if (flag43 && Main.myPlayer == this.whoAmi)
						{
							for (int num227 = 0; num227 < 10; num227++)
							{
								if (this.buffType[num227] == 38)
								{
									this.DelBuff(num227);
								}
							}
						}
					}
					if (Main.myPlayer == this.whoAmi)
					{/*
						if (Main.wof >= 0 && Main.npc[Main.wof].active)
						{
							float num228 = Main.npc[Main.wof].position.X + 40f;
							if (Main.npc[Main.wof].direction > 0)
							{
								num228 -= 96f;
							}
							if (this.position.X + (float)this.width > num228 && this.position.X < num228 + 140f && this.gross)
							{
								this.noKnockback = false;
								this.Hurt(50, Main.npc[Main.wof].direction, false, false, " was slain...", false);
							}
							if (!this.gross && this.position.Y > (float)((Main.maxTilesY - 250) * 16) && this.position.X > num228 - 1920f && this.position.X < num228 + 1920f)
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
								else
								{
									if (this.position.X + (float)(this.width / 2) < Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) - 40f)
									{
										this.AddBuff(38, 10, true);
									}
								}
							}
							if (this.tongued)
							{
								this.controlHook = false;
								this.controlUseItem = false;
								for (int num229 = 0; num229 < 1000; num229++)
								{
									if (Main.projectile[num229].active && Main.projectile[num229].owner == Main.myPlayer && Main.projectile[num229].aiStyle == 7)
									{
										Main.projectile[num229].Kill();
									}
								}
								Vector2 vector3 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
								float num230 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) - vector3.X;
								float num231 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2) - vector3.Y;
								float num232 = (float)Math.Sqrt((double)(num230 * num230 + num231 * num231));
								if (num232 > 3000f)
								{
									this.KillMe(1000.0, 0, false, " tried to escape.");
								}
								else
								{
									if (Main.npc[Main.wof].position.X < 608f || Main.npc[Main.wof].position.X > (float)((Main.maxTilesX - 38) * 16))
									{
										this.KillMe(1000.0, 0, false, " was licked.");
									}
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
							for (int num233 = 0; num233 < 200; num233++)
							{
								if (Main.npc[num233].active && !Main.npc[num233].friendly && Main.npc[num233].damage > 0 && rectangle3.Intersects(new Rectangle((int)Main.npc[num233].position.X, (int)Main.npc[num233].position.Y, Main.npc[num233].width, Main.npc[num233].height)))
								{
									int num234 = -1;
									if (Main.npc[num233].position.X + (float)(Main.npc[num233].width / 2) < this.position.X + (float)(this.width / 2))
									{
										num234 = 1;
									}
									int num235 = Main.DamageVar((float)Main.npc[num233].damage);
									if (this.whoAmi == Main.myPlayer && this.thorns && !this.immune && !Main.npc[num233].dontTakeDamage)
									{
										int num236 = num235 / 3;
										int num237 = 10;
										if (this.turtleThorns)
										{
											num236 = num235;
										}
										Main.npc[num233].StrikeNPC(num236, (float)num237, -num234, false, false);
										if (Main.netMode != 0)
										{
											NetMessage.SendData(28, -1, -1, "", num233, (float)num236, (float)num237, (float)(-(float)num234), 0);
										}
									}
									if (!this.immune)
									{
										if (Main.npc[num233].type >= 269 && Main.npc[num233].type <= 272)
										{
											if (Main.rand.Next(3) == 0)
											{
												this.AddBuff(30, 600, true);
											}
											else
											{
												if (Main.rand.Next(3) == 0)
												{
													this.AddBuff(32, 300, true);
												}
											}
										}
										if (Main.npc[num233].type >= 273 && Main.npc[num233].type <= 276 && Main.rand.Next(2) == 0)
										{
											this.AddBuff(36, 600, true);
										}
										if (Main.npc[num233].type >= 277 && Main.npc[num233].type <= 280)
										{
											this.AddBuff(24, 600, true);
										}
										if (((Main.npc[num233].type == 1 && Main.npc[num233].name == "Black Slime") || Main.npc[num233].type == 81 || Main.npc[num233].type == 79) && Main.rand.Next(4) == 0)
										{
											this.AddBuff(22, 900, true);
										}
										if ((Main.npc[num233].type == 23 || Main.npc[num233].type == 25) && Main.rand.Next(3) == 0)
										{
											this.AddBuff(24, 420, true);
										}
										if ((Main.npc[num233].type == 34 || Main.npc[num233].type == 83 || Main.npc[num233].type == 84) && Main.rand.Next(3) == 0)
										{
											this.AddBuff(23, 240, true);
										}
										if ((Main.npc[num233].type == 104 || Main.npc[num233].type == 102) && Main.rand.Next(8) == 0)
										{
											this.AddBuff(30, 2700, true);
										}
										if (Main.npc[num233].type == 75 && Main.rand.Next(10) == 0)
										{
											this.AddBuff(35, 420, true);
										}
										if ((Main.npc[num233].type == 163 || Main.npc[num233].type == 238) && Main.rand.Next(10) == 0)
										{
											this.AddBuff(70, 480, true);
										}
										if ((Main.npc[num233].type == 79 || Main.npc[num233].type == 103) && Main.rand.Next(5) == 0)
										{
											this.AddBuff(35, 420, true);
										}
										if ((Main.npc[num233].type == 75 || Main.npc[num233].type == 78 || Main.npc[num233].type == 82) && Main.rand.Next(8) == 0)
										{
											this.AddBuff(32, 900, true);
										}
										if ((Main.npc[num233].type == 93 || Main.npc[num233].type == 109 || Main.npc[num233].type == 80) && Main.rand.Next(14) == 0)
										{
											this.AddBuff(31, 300, true);
										}
										if (Main.npc[num233].type == 77 && Main.rand.Next(6) == 0)
										{
											this.AddBuff(36, 18000, true);
										}
										if (Main.npc[num233].type == 112 && Main.rand.Next(20) == 0)
										{
											this.AddBuff(33, 18000, true);
										}
										if (Main.npc[num233].type == 141 && Main.rand.Next(2) == 0)
										{
											this.AddBuff(20, 600, true);
										}
										if (Main.npc[num233].type == 147 && !Main.player[i].frozen && Main.rand.Next(12) == 0)
										{
											Main.player[i].AddBuff(46, 600, true);
										}
										if (Main.npc[num233].type == 150)
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
										if (Main.npc[num233].type == 184)
										{
											Main.player[i].AddBuff(46, 1200, true);
											if (!Main.player[i].frozen && Main.rand.Next(15) == 0)
											{
												Main.player[i].AddBuff(47, 60, true);
											}
										}
									}
									this.Hurt(num235, num234, false, false, Lang.deathMsg(-1, num233, -1, -1), false);
								}
							}
						}
						Vector2 vector4 = Collision.HurtTiles(this.position, this.velocity, this.width, this.height, this.fireWalk);
						if (vector4.Y == 20f)
						{
							this.AddBuff(67, 20, true);
						}
						else
						{
							if (vector4.Y == 15f)
							{
								this.AddBuff(68, 1, true);
							}
							else
							{
								if (vector4.Y != 0f)
								{
									int damage3 = Main.DamageVar(vector4.Y);
									this.Hurt(damage3, 0, false, false, Lang.deathMsg(-1, -1, -1, 3), false);
								}
							}
						}*/
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
					else
					{
						if (this.controlRight)
						{
							this.rightTimer = 7;
						}
					}
					if (this.leftTimer > 0)
					{
						this.leftTimer--;
					}
					else
					{
						if (this.controlLeft)
						{
							this.leftTimer = 7;
						}
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
						float num238 = 0f;
						float num239 = 0f;
						for (int num240 = 0; num240 < this.grapCount; num240++)
						{
							num238 += Main.projectile[this.grappling[num240]].position.X + (float)(Main.projectile[this.grappling[num240]].width / 2);
							num239 += Main.projectile[this.grappling[num240]].position.Y + (float)(Main.projectile[this.grappling[num240]].height / 2);
						}
						num238 /= (float)this.grapCount;
						num239 /= (float)this.grapCount;
						Vector2 vector5 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num241 = num238 - vector5.X;
						float num242 = num239 - vector5.Y;
						float num243 = (float)Math.Sqrt((double)(num241 * num241 + num242 * num242));
						float num244 = 11f;
						float num245;
						if (num243 > num244)
						{
							num245 = num244 / num243;
						}
						else
						{
							num245 = 1f;
						}
						num241 *= num245;
						num242 *= num245;
						this.velocity.X = num241;
						this.velocity.Y = num242;
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
								this.grappling[0] = 0;
								this.grapCount = 0;
								for (int num246 = 0; num246 < 1000; num246++)
								{
									if (Main.projectile[num246].active && Main.projectile[num246].owner == i && Main.projectile[num246].aiStyle == 7)
									{
										Main.projectile[num246].Kill();
									}
								}
							}
						}
						else
						{
							this.releaseJump = true;
						}
					}
					int num247 = this.width / 2;
					int num248 = this.height / 2;
					new Vector2(this.position.X + (float)(this.width / 2) - (float)(num247 / 2), this.position.Y + (float)(this.height / 2) - (float)(num248 / 2));
					Vector2 vector6 = Collision.StickyTiles(this.position, this.velocity, this.width, this.height);
					if (vector6.Y != -1f && vector6.X != -1f)
					{
						int num249 = (int)vector6.X;
						int num250 = (int)vector6.Y;
						int type7 = (int)Main.tile[num249, num250].type;
						if (this.whoAmi == Main.myPlayer && type7 == 51 && (this.velocity.X != 0f || this.velocity.Y != 0f))
						{
							this.stickyBreak++;
							if (this.stickyBreak > Main.rand.Next(20, 100))
							{
								this.stickyBreak = 0;
								WorldGen.KillTile(num249, num250, false, false, false);
								if (Main.netMode == 1 && !Main.tile[num249, num250].active() && Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 0, (float)num249, (float)num250, 0f, 0);
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
							if ((float)(num249 * 16) < this.position.X + (float)(this.width / 2))
							{
								int num251 = Dust.NewDust(new Vector2(this.position.X - 4f, (float)(num250 * 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
								Main.dust[num251].scale += (float)Main.rand.Next(0, 6) * 0.1f;
								Main.dust[num251].velocity *= 0.1f;
								Main.dust[num251].noGravity = true;
							}
							else
							{
								int num252 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 2f, (float)(num250 * 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
								Main.dust[num252].scale += (float)Main.rand.Next(0, 6) * 0.1f;
								Main.dust[num252].velocity *= 0.1f;
								Main.dust[num252].noGravity = true;
							}
							if (Main.tile[num249, num250 + 1] != null && Main.tile[num249, num250 + 1].type == 229 && this.position.Y + (float)this.height > (float)((num250 + 1) * 16))
							{
								if ((float)(num249 * 16) < this.position.X + (float)(this.width / 2))
								{
									int num253 = Dust.NewDust(new Vector2(this.position.X - 4f, (float)(num250 * 16 + 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num253].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num253].velocity *= 0.1f;
									Main.dust[num253].noGravity = true;
								}
								else
								{
									int num254 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 2f, (float)(num250 * 16 + 16)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num254].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num254].velocity *= 0.1f;
									Main.dust[num254].noGravity = true;
								}
							}
							if (Main.tile[num249, num250 + 2] != null && Main.tile[num249, num250 + 2].type == 229 && this.position.Y + (float)this.height > (float)((num250 + 2) * 16))
							{
								if ((float)(num249 * 16) < this.position.X + (float)(this.width / 2))
								{
									int num255 = Dust.NewDust(new Vector2(this.position.X - 4f, (float)(num250 * 16 + 32)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num255].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num255].velocity *= 0.1f;
									Main.dust[num255].noGravity = true;
								}
								else
								{
									int num256 = Dust.NewDust(new Vector2(this.position.X + (float)this.width - 2f, (float)(num250 * 16 + 32)), 4, 16, 153, 0f, 0f, 50, default(Color), 1f);
									Main.dust[num256].scale += (float)Main.rand.Next(0, 6) * 0.1f;
									Main.dust[num256].velocity *= 0.1f;
									Main.dust[num256].noGravity = true;
								}
							}
						}
					}
					else
					{
						this.stickyBreak = 0;
					}
					bool flag44 = Collision.DrownCollision(this.position, this.width, this.height, this.gravDir);
					if (this.armor[0].type == 250)
					{
						flag44 = true;
					}
					if (this.inventory[this.selectedItem].type == 186)
					{
						try
						{
							int num257 = (int)((this.position.X + (float)(this.width / 2) + (float)(6 * this.direction)) / 16f);
							int num258 = 0;
							if (this.gravDir == -1f)
							{
								num258 = this.height;
							}
							int num259 = (int)((this.position.Y + (float)num258 - 44f * this.gravDir) / 16f);
							if (Main.tile[num257, num259].liquid < 128)
							{
								if (Main.tile[num257, num259] == null)
								{
									Main.tile[num257, num259] = new Tile();
								}
								if (!Main.tile[num257, num259].active() || !Main.tileSolid[(int)Main.tile[num257, num259].type] || Main.tileSolidTop[(int)Main.tile[num257, num259].type])
								{
									flag44 = false;
								}
							}
						}
						catch
						{
						}
					}
					if (this.gills)
					{
						flag44 = false;
					}
					if (Main.myPlayer == i)
					{
						if (this.merman)
						{
							flag44 = false;
						}
						if (flag44)
						{
							this.breathCD++;
							int num260 = 7;
							if (this.inventory[this.selectedItem].type == 186)
							{
								num260 *= 2;
							}
							if (this.accDivingHelm)
							{
								num260 *= 4;
							}
							if (this.breathCD >= num260)
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
					if (flag44 && Main.rand.Next(20) == 0 && !this.lavaWet && !this.honeyWet)
					{
						int num261 = 0;
						if (this.gravDir == -1f)
						{
							num261 += this.height - 12;
						}
						if (this.inventory[this.selectedItem].type == 186)
						{
							Dust.NewDust(new Vector2(this.position.X + (float)(10 * this.direction) + 4f, this.position.Y + (float)num261 - 54f * this.gravDir), this.width - 8, 8, 34, 0f, 0f, 0, default(Color), 1.2f);
						}
						else
						{
							Dust.NewDust(new Vector2(this.position.X + (float)(12 * this.direction), this.position.Y + (float)num261 + 4f * this.gravDir), this.width - 8, 8, 34, 0f, 0f, 0, default(Color), 1.2f);
						}
					}
					if (this.gravDir == -1f)
					{
						this.waterWalk = false;
						this.waterWalk2 = false;
					}
					int num262 = this.height;
					if (this.waterWalk)
					{
						num262 -= 6;
					}
					bool flag45 = Collision.LavaCollision(this.position, this.width, num262);
					if (flag45)
					{
						if (!this.lavaImmune && Main.myPlayer == i && !this.immune)
						{
							if (this.lavaTime > 0)
							{
								this.lavaTime--;
							}
							else
							{
								if (this.lavaRose)
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
						}
						this.lavaWet = true;
					}
					else
					{
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
						num262 -= 6;
					}
					bool flag46 = Collision.WetCollision(this.position, this.width, this.height);
					if (Collision.honey)
					{
						this.AddBuff(48, 1800, true);
						this.honeyWet = true;
					}
					if (flag46)
					{
						if (this.onFire && !this.lavaWet)
						{
							for (int num263 = 0; num263 < 10; num263++)
							{
								if (this.buffType[num263] == 24)
								{
									this.DelBuff(num263);
								}
							}
						}
						if (!this.wet)
						{
							if (this.wetCount == 0)
							{
								this.wetCount = 10;
								if (!flag45)
								{
									if (this.honeyWet)
									{
										for (int num264 = 0; num264 < 20; num264++)
										{
											int num265 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 152, 0f, 0f, 0, default(Color), 1f);
											Dust expr_12A6D_cp_0 = Main.dust[num265];
											expr_12A6D_cp_0.velocity.Y = expr_12A6D_cp_0.velocity.Y - 1f;
											Dust expr_12A8D_cp_0 = Main.dust[num265];
											expr_12A8D_cp_0.velocity.X = expr_12A8D_cp_0.velocity.X * 2.5f;
											Main.dust[num265].scale = 1.3f;
											Main.dust[num265].alpha = 100;
											Main.dust[num265].noGravity = true;
										}
										Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
									}
									else
									{
										for (int num266 = 0; num266 < 50; num266++)
										{
											int num267 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, Dust.dustWater(), 0f, 0f, 0, default(Color), 1f);
											Dust expr_12B8E_cp_0 = Main.dust[num267];
											expr_12B8E_cp_0.velocity.Y = expr_12B8E_cp_0.velocity.Y - 3f;
											Dust expr_12BAE_cp_0 = Main.dust[num267];
											expr_12BAE_cp_0.velocity.X = expr_12BAE_cp_0.velocity.X * 2.5f;
											Main.dust[num267].scale = 0.8f;
											Main.dust[num267].alpha = 100;
											Main.dust[num267].noGravity = true;
										}
										Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
									}
								}
								else
								{
									for (int num268 = 0; num268 < 20; num268++)
									{
										int num269 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
										Dust expr_12CAC_cp_0 = Main.dust[num269];
										expr_12CAC_cp_0.velocity.Y = expr_12CAC_cp_0.velocity.Y - 1.5f;
										Dust expr_12CCC_cp_0 = Main.dust[num269];
										expr_12CCC_cp_0.velocity.X = expr_12CCC_cp_0.velocity.X * 2.5f;
										Main.dust[num269].scale = 1.3f;
										Main.dust[num269].alpha = 100;
										Main.dust[num269].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
							}
							this.wet = true;
						}
					}
					else
					{
						if (this.wet)
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
										for (int num270 = 0; num270 < 20; num270++)
										{
											int num271 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 152, 0f, 0f, 0, default(Color), 1f);
											Dust expr_12E2B_cp_0 = Main.dust[num271];
											expr_12E2B_cp_0.velocity.Y = expr_12E2B_cp_0.velocity.Y - 1f;
											Dust expr_12E4B_cp_0 = Main.dust[num271];
											expr_12E4B_cp_0.velocity.X = expr_12E4B_cp_0.velocity.X * 2.5f;
											Main.dust[num271].scale = 1.3f;
											Main.dust[num271].alpha = 100;
											Main.dust[num271].noGravity = true;
										}
										Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
									}
									else
									{
										for (int num272 = 0; num272 < 50; num272++)
										{
											int num273 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2)), this.width + 12, 24, Dust.dustWater(), 0f, 0f, 0, default(Color), 1f);
											Dust expr_12F46_cp_0 = Main.dust[num273];
											expr_12F46_cp_0.velocity.Y = expr_12F46_cp_0.velocity.Y - 4f;
											Dust expr_12F66_cp_0 = Main.dust[num273];
											expr_12F66_cp_0.velocity.X = expr_12F66_cp_0.velocity.X * 2.5f;
											Main.dust[num273].scale = 0.8f;
											Main.dust[num273].alpha = 100;
											Main.dust[num273].noGravity = true;
										}
										Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
									}
								}
								else
								{
									for (int num274 = 0; num274 < 20; num274++)
									{
										int num275 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
										Dust expr_13064_cp_0 = Main.dust[num275];
										expr_13064_cp_0.velocity.Y = expr_13064_cp_0.velocity.Y - 1.5f;
										Dust expr_13084_cp_0 = Main.dust[num275];
										expr_13084_cp_0.velocity.X = expr_13084_cp_0.velocity.X * 2.5f;
										Main.dust[num275].scale = 1.3f;
										Main.dust[num275].alpha = 100;
										Main.dust[num275].noGravity = true;
									}
									Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
								}
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
					float num276 = 1f + Math.Abs(this.velocity.X) / 3f;
					if (this.gfxOffY > 0f)
					{
						this.gfxOffY -= num276 * this.stepSpeed;
						if (this.gfxOffY < 0f)
						{
							this.gfxOffY = 0f;
						}
					}
					else
					{
						if (this.gfxOffY < 0f)
						{
							this.gfxOffY += num276 * this.stepSpeed;
							if (this.gfxOffY > 0f)
							{
								this.gfxOffY = 0f;
							}
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
						int num277 = (int)(vector7.X / 16f);
						int num278 = (int)((vector7.X + (float)this.width) / 16f);
						int num279 = (int)((this.position.Y + (float)this.height + 1f) / 16f);
						for (int num280 = num277; num280 <= num278; num280++)
						{
							for (int num281 = num279; num281 <= num279 + 1; num281++)
							{
								if (Main.tile[num280, num281].nactive() && Main.tile[num280, num281].type == 162)
								{
									WorldGen.KillTile(num280, num281, false, false, false);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 0, (float)num280, (float)num281, 0f, 0);
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
						bool flag47 = false;
						int num282 = (int)(vector9.X / 16f);
						int num283 = (int)((vector9.X + (float)this.width) / 16f);
						int num284 = (int)((this.position.Y + (float)this.height + 4f) / 16f);
						float num285 = (float)((num284 + 3) * 16);
						for (int num286 = num282; num286 <= num283; num286++)
						{
							for (int num287 = num284; num287 <= num284 + 1; num287++)
							{
								if (Main.tile[num286, num287] == null)
								{
									Main.tile[num286, num287] = new Tile();
								}
								if (Main.tile[num286, num287].slope() != 0)
								{
									flag47 = true;
								}
								if (this.waterWalk2 || this.waterWalk)
								{
									if (Main.tile[num286, num287 - 1] == null)
									{
										Main.tile[num286, num287 - 1] = new Tile();
									}
									if (Main.tile[num286, num287].liquid > 0 && Main.tile[num286, num287 - 1].liquid == 0)
									{
										int num288 = (int)(Main.tile[num286, num287].liquid / 32 * 2 + 2);
										int num289 = num287 * 16 + 16 - num288;
										Rectangle rectangle4 = new Rectangle(num286 * 16, num287 * 16 - 17, 16, 16);
										if (rectangle4.Intersects(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height)) && (float)num289 < num285)
										{
											num285 = (float)num289;
										}
									}
								}
								if (Main.tile[num286, num287 - 1] == null)
								{
									Main.tile[num286, num287 - 1] = new Tile();
								}
								if (Main.tile[num286, num287].nactive() && (Main.tileSolid[(int)Main.tile[num286, num287].type] || Main.tileSolidTop[(int)Main.tile[num286, num287].type]))
								{
									int num290 = num287 * 16;
									if (Main.tile[num286, num287].halfBrick())
									{
										num290 += 8;
									}
									Rectangle rectangle5 = new Rectangle(num286 * 16, num287 * 16 - 17, 16, 16);
									if (rectangle5.Intersects(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height)) && (float)num290 < num285)
									{
										num285 = (float)num290;
									}
								}
							}
						}
						float num291 = num285 - (this.position.Y + (float)this.height);
						if (num291 > 7f && num291 < 17f && !flag47)
						{
							this.stepSpeed = 1.5f;
							if (num291 > 9f)
							{
								this.stepSpeed = 2.5f;
							}
							this.gfxOffY += this.position.Y + (float)this.height - num285;
							this.position.Y = num285 - (float)this.height;
						}
					}
					if (this.gravDir == -1f)
					{
						if ((this.carpetFrame != -1 || this.velocity.Y <= num2) && !this.controlUp)
						{
							int num292 = 0;
							if (this.velocity.X < 0f)
							{
								num292 = -1;
							}
							if (this.velocity.X > 0f)
							{
								num292 = 1;
							}
							Vector2 vector10 = this.position;
							vector10.X += this.velocity.X;
							int num293 = (int)((vector10.X + (float)(this.width / 2) + (float)((this.width / 2 + 1) * num292)) / 16f);
							int num294 = (int)(((double)vector10.Y + 0.1) / 16.0);
							if (Main.tile[num293, num294] == null)
							{
								Main.tile[num293, num294] = new Tile();
							}
							if (num294 - 1 > 0 && Main.tile[num293, num294 + 1] == null)
							{
								Main.tile[num293, num294 + 1] = new Tile();
							}
							if (num294 - 2 > 0 && Main.tile[num293, num294 + 2] == null)
							{
								Main.tile[num293, num294 + 2] = new Tile();
							}
							if (num294 - 3 > 0 && Main.tile[num293, num294 + 3] == null)
							{
								Main.tile[num293, num294 + 3] = new Tile();
							}
							if (num294 - 4 > 0 && Main.tile[num293, num294 + 4] == null)
							{
								Main.tile[num293, num294 + 4] = new Tile();
							}
							if (num294 - 3 > 0 && Main.tile[num293 - num292, num294 + 3] == null)
							{
								Main.tile[num293 - num292, num294 + 3] = new Tile();
							}
							if ((float)(num293 * 16) < vector10.X + (float)this.width && (float)(num293 * 16 + 16) > vector10.X && ((Main.tile[num293, num294].nactive() && ((Main.tileSolid[(int)Main.tile[num293, num294].type] && !Main.tileSolidTop[(int)Main.tile[num293, num294].type]) || (this.controlUp && Main.tileSolidTop[(int)Main.tile[num293, num294].type] && Main.tile[num293, num294].frameY == 0 && (!Main.tileSolid[(int)Main.tile[num293, num294 + 1].type] || !Main.tile[num293, num294 + 1].nactive())))) || (Main.tile[num293, num294 + 1].halfBrick() && Main.tile[num293, num294 + 1].nactive())) && (!Main.tile[num293, num294 + 1].nactive() || !Main.tileSolid[(int)Main.tile[num293, num294 + 1].type] || Main.tileSolidTop[(int)Main.tile[num293, num294 + 1].type] || Main.tile[num293, num294 + 1].slope() != 0 || (Main.tile[num293, num294 + 1].halfBrick() && (!Main.tile[num293, num294 + 4].nactive() || !Main.tileSolid[(int)Main.tile[num293, num294 + 4].type] || Main.tileSolidTop[(int)Main.tile[num293, num294 + 4].type]))) && (!Main.tile[num293, num294 + 2].nactive() || !Main.tileSolid[(int)Main.tile[num293, num294 + 2].type] || Main.tileSolidTop[(int)Main.tile[num293, num294 + 2].type]) && (!Main.tile[num293, num294 + 3].nactive() || !Main.tileSolid[(int)Main.tile[num293, num294 + 3].type] || Main.tileSolidTop[(int)Main.tile[num293, num294 + 3].type]) && (!Main.tile[num293 - num292, num294 + 3].nactive() || !Main.tileSolid[(int)Main.tile[num293 - num292, num294 + 3].type] || Main.tileSolidTop[(int)Main.tile[num293 - num292, num294 + 3].type]))
							{
								float num295 = (float)(num294 * 16 + 16);
								if (num295 > vector10.Y)
								{
									float num296 = num295 - vector10.Y;
									if ((double)num296 <= 16.1)
									{
										this.gfxOffY -= num295 - this.position.Y;
										this.position.Y = num295;
										this.velocity.Y = 0f;
										if (num296 < 9f)
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
					else
					{
						if ((this.carpetFrame != -1 || this.velocity.Y >= num2) && !this.controlDown)
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
							int num299 = (int)((vector11.Y + (float)this.height - 1f) / 16f);
							if (Main.tile[num298, num299] == null)
							{
								Main.tile[num298, num299] = new Tile();
							}
							if (num299 - 1 > 0 && Main.tile[num298, num299 - 1] == null)
							{
								Main.tile[num298, num299 - 1] = new Tile();
							}
							if (num299 - 2 > 0 && Main.tile[num298, num299 - 2] == null)
							{
								Main.tile[num298, num299 - 2] = new Tile();
							}
							if (num299 - 3 > 0 && Main.tile[num298, num299 - 3] == null)
							{
								Main.tile[num298, num299 - 3] = new Tile();
							}
							if (num299 - 4 > 0 && Main.tile[num298, num299 - 4] == null)
							{
								Main.tile[num298, num299 - 4] = new Tile();
							}
							if (num299 - 3 > 0 && Main.tile[num298 - num297, num299 - 3] == null)
							{
								Main.tile[num298 - num297, num299 - 3] = new Tile();
							}
							if ((float)(num298 * 16) < vector11.X + (float)this.width && (float)(num298 * 16 + 16) > vector11.X && ((Main.tile[num298, num299].nactive() && (Main.tile[num298, num299].slope() == 0 || (Main.tile[num298, num299].slope() == 1 && this.position.X + (float)(this.width / 2) < (float)(num298 * 16)) || (Main.tile[num298, num299].slope() == 2 && this.position.X + (float)(this.width / 2) > (float)(num298 * 16 + 16))) && (Main.tile[num298, num299 - 1].slope() == 0 || this.position.Y + (float)this.height > (float)(num299 * 16)) && ((Main.tileSolid[(int)Main.tile[num298, num299].type] && !Main.tileSolidTop[(int)Main.tile[num298, num299].type]) || (this.controlUp && Main.tileSolidTop[(int)Main.tile[num298, num299].type] && Main.tile[num298, num299].frameY == 0 && (!Main.tileSolid[(int)Main.tile[num298, num299 - 1].type] || !Main.tile[num298, num299 - 1].nactive())))) || (Main.tile[num298, num299 - 1].halfBrick() && Main.tile[num298, num299 - 1].nactive())) && (!Main.tile[num298, num299 - 1].nactive() || !Main.tileSolid[(int)Main.tile[num298, num299 - 1].type] || Main.tileSolidTop[(int)Main.tile[num298, num299 - 1].type] || (Main.tile[num298, num299 - 1].slope() == 1 && this.position.X + (float)(this.width / 2) > (float)(num298 * 16)) || (Main.tile[num298, num299 - 1].slope() == 2 && this.position.X + (float)(this.width / 2) < (float)(num298 * 16 + 16)) || (Main.tile[num298, num299 - 1].halfBrick() && (!Main.tile[num298, num299 - 4].nactive() || !Main.tileSolid[(int)Main.tile[num298, num299 - 4].type] || Main.tileSolidTop[(int)Main.tile[num298, num299 - 4].type]))) && (!Main.tile[num298, num299 - 2].nactive() || !Main.tileSolid[(int)Main.tile[num298, num299 - 2].type] || Main.tileSolidTop[(int)Main.tile[num298, num299 - 2].type]) && (!Main.tile[num298, num299 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num298, num299 - 3].type] || Main.tileSolidTop[(int)Main.tile[num298, num299 - 3].type]) && (!Main.tile[num298 - num297, num299 - 3].nactive() || !Main.tileSolid[(int)Main.tile[num298 - num297, num299 - 3].type] || Main.tileSolidTop[(int)Main.tile[num298 - num297, num299 - 3].type]))
							{
								float num300 = (float)(num299 * 16);
								if (Main.tile[num298, num299].halfBrick())
								{
									num300 += 8f;
								}
								if (Main.tile[num298, num299 - 1].halfBrick())
								{
									num300 -= 8f;
								}
								if (num300 < vector11.Y + (float)this.height)
								{
									float num301 = vector11.Y + (float)this.height - num300;
									if ((double)num301 <= 16.1)
									{
										this.gfxOffY += this.position.Y + (float)this.height - num300;
										this.position.Y = num300 - (float)this.height;
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
					this.oldPosition = this.position;
					bool flag48 = false;
					if (this.velocity.Y > num2)
					{
						flag48 = true;
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
					else
					{
						if (this.tongued)
						{
							this.position += this.velocity;
						}
						else
						{
							if (this.honeyWet)
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
							else
							{
								if (this.wet && !this.merman)
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
							}
						}
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
						else
						{
							if (vector12.X > 0f)
							{
								this.slideDir = 1;
							}
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
					else
					{
						if (this.gravDir == -1f && Collision.down)
						{
							this.velocity.Y = -0.01f;
							if (!this.merman)
							{
								this.jump = 0;
							}
						}
					}
					if (this.gravDir == -1f && this.velocity.Y > -1E-05f && this.velocity.Y < 1E-05f)
					{
						this.velocity.Y = 0f;
					}
					if (this.velocity.Y == 0f && this.grappling[0] == -1)
					{
						int num302 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
						int num303 = (int)((this.position.Y + (float)this.height) / 16f);
						int num304 = -1;
						if (Main.tile[num302 - 1, num303] == null)
						{
							Main.tile[num302 - 1, num303] = new Tile();
						}
						if (Main.tile[num302 + 1, num303] == null)
						{
							Main.tile[num302 + 1, num303] = new Tile();
						}
						if (Main.tile[num302, num303] == null)
						{
							Main.tile[num302, num303] = new Tile();
						}
						if (Main.tile[num302, num303].nactive() && Main.tileSolid[(int)Main.tile[num302, num303].type])
						{
							num304 = (int)Main.tile[num302, num303].type;
						}
						else
						{
							if (Main.tile[num302 - 1, num303].nactive() && Main.tileSolid[(int)Main.tile[num302 - 1, num303].type])
							{
								num304 = (int)Main.tile[num302 - 1, num303].type;
							}
							else
							{
								if (Main.tile[num302 + 1, num303].nactive() && Main.tileSolid[(int)Main.tile[num302 + 1, num303].type])
								{
									num304 = (int)Main.tile[num302 + 1, num303].type;
								}
							}
						}
						if (num304 > -1)
						{
							if (num304 == 229)
							{
								this.sticky = true;
							}
							else
							{
								this.sticky = false;
							}
							if (num304 == 161 || num304 == 162 || num304 == 163 || num304 == 164 || num304 == 200)
							{
								this.slippy = true;
							}
							else
							{
								this.slippy = false;
							}
							if (num304 == 197)
							{
								this.slippy2 = true;
							}
							else
							{
								this.slippy2 = false;
							}
							if (num304 == 198)
							{
								this.powerrun = true;
							}
							else
							{
								this.powerrun = false;
							}
							if (Main.tile[num302 - 1, num303].slope() != 0 || Main.tile[num302, num303].slope() != 0 || Main.tile[num302 + 1, num303].slope() != 0)
							{
								num304 = -1;
							}
							if (!this.wet && (num304 == 147 || num304 == 25 || num304 == 53 || num304 == 189 || num304 == 0 || num304 == 123 || num304 == 57 || num304 == 112 || num304 == 116 || num304 == 196 || num304 == 193 || num304 == 195 || num304 == 197 || num304 == 199 || num304 == 229))
							{
								int num305 = 1;
								if (flag48)
								{
									num305 = 20;
								}
								for (int num306 = 0; num306 < num305; num306++)
								{
									bool flag49 = true;
									int num307 = 76;
									if (num304 == 53)
									{
										num307 = 32;
									}
									if (num304 == 189)
									{
										num307 = 16;
									}
									if (num304 == 0)
									{
										num307 = 0;
									}
									if (num304 == 123)
									{
										num307 = 53;
									}
									if (num304 == 57)
									{
										num307 = 36;
									}
									if (num304 == 112)
									{
										num307 = 14;
									}
									if (num304 == 116)
									{
										num307 = 51;
									}
									if (num304 == 196)
									{
										num307 = 108;
									}
									if (num304 == 193)
									{
										num307 = 4;
									}
									if (num304 == 195 || num304 == 199)
									{
										num307 = 5;
									}
									if (num304 == 197)
									{
										num307 = 4;
									}
									if (num304 == 229)
									{
										num307 = 153;
									}
									if (num304 == 25)
									{
										num307 = 37;
									}
									if (num307 == 32 && Main.rand.Next(2) == 0)
									{
										flag49 = false;
									}
									if (num307 == 14 && Main.rand.Next(2) == 0)
									{
										flag49 = false;
									}
									if (num307 == 51 && Main.rand.Next(2) == 0)
									{
										flag49 = false;
									}
									if (num307 == 36 && Main.rand.Next(2) == 0)
									{
										flag49 = false;
									}
									if (num307 == 0 && Main.rand.Next(3) != 0)
									{
										flag49 = false;
									}
									if (num307 == 53 && Main.rand.Next(3) != 0)
									{
										flag49 = false;
									}
									Color newColor = default(Color);
									if (num304 == 193)
									{
										newColor = new Color(30, 100, 255, 100);
									}
									if (num304 == 197)
									{
										newColor = new Color(97, 200, 255, 100);
									}
									if (!flag48)
									{
										float num308 = Math.Abs(this.velocity.X) / 3f;
										if ((float)Main.rand.Next(100) > num308 * 100f)
										{
											flag49 = false;
										}
									}
									if (flag49)
									{
										float num309 = this.velocity.X;
										if (num309 > 6f)
										{
											num309 = 6f;
										}
										if (num309 < -6f)
										{
											num309 = -6f;
										}
										if (this.velocity.X != 0f || flag48)
										{
											int num310 = Dust.NewDust(new Vector2(this.position.X, this.position.Y + (float)this.height - 2f), this.width, 6, num307, 0f, 0f, 50, newColor, 1f);
											if (num307 == 76)
											{
												Main.dust[num310].scale += (float)Main.rand.Next(3) * 0.1f;
												Main.dust[num310].noLight = true;
											}
											if (num307 == 16 || num307 == 108 || num307 == 153)
											{
												Main.dust[num310].scale += (float)Main.rand.Next(6) * 0.1f;
											}
											if (num307 == 37)
											{
												Main.dust[num310].scale += 0.25f;
												Main.dust[num310].alpha = 50;
											}
											if (num307 == 5)
											{
												Main.dust[num310].scale += (float)Main.rand.Next(2, 8) * 0.1f;
											}
											Main.dust[num310].noGravity = true;
											if (num305 > 1)
											{
												Dust expr_151E2_cp_0 = Main.dust[num310];
												expr_151E2_cp_0.velocity.X = expr_151E2_cp_0.velocity.X * 1.2f;
												Dust expr_15202_cp_0 = Main.dust[num310];
												expr_15202_cp_0.velocity.Y = expr_15202_cp_0.velocity.Y * 0.8f;
												Dust expr_15222_cp_0 = Main.dust[num310];
												expr_15222_cp_0.velocity.Y = expr_15222_cp_0.velocity.Y - 1f;
												Main.dust[num310].velocity *= 0.8f;
												Main.dust[num310].scale += (float)Main.rand.Next(3) * 0.1f;
												Main.dust[num310].velocity.X = (Main.dust[num310].position.X - (this.position.X + (float)(this.width / 2))) * 0.2f;
												if (Main.dust[num310].velocity.Y > 0f)
												{
													Dust expr_152E8_cp_0 = Main.dust[num310];
													expr_152E8_cp_0.velocity.Y = expr_152E8_cp_0.velocity.Y * -1f;
												}
												Dust expr_15308_cp_0 = Main.dust[num310];
												expr_15308_cp_0.velocity.X = expr_15308_cp_0.velocity.X + num309 * 0.3f;
											}
											else
											{
												Main.dust[num310].velocity *= 0.2f;
											}
											Dust expr_1534E_cp_0 = Main.dust[num310];
											expr_1534E_cp_0.position.X = expr_1534E_cp_0.position.X - num309 * 1f;
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
							goto IL_15532;
						}
						catch
						{
							goto IL_15532;
						}
						goto IL_1552B;
					}
					goto IL_1552B;
					IL_15532:
					this.PlayerFrame();
					if (this.statLife > this.statLifeMax)
					{
						this.statLife = this.statLifeMax;
					}
					this.grappling[0] = -1;
					this.grapCount = 0;
					return;
					IL_1552B:
					this.ItemCheck(i);
					goto IL_15532;
			}
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
				for (int num310 = 0; num310 < 10; num310++)
				{
					this.buffTime[num310] = 0;
					this.buffType[num310] = 0;
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
						else
						{
							if (j >= 100)
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
							else
							{
								if (j >= 1)
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
			for (int i = 0; i < 251; i++)
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
				for (int l = 0; l < 251; l++)
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
					Dust expr_694_cp_0 = Main.dust[num3];
					expr_694_cp_0.velocity.X = expr_694_cp_0.velocity.X - this.velocity.X * 0.5f;
					Dust expr_6BE_cp_0 = Main.dust[num3];
					expr_6BE_cp_0.velocity.Y = expr_6BE_cp_0.velocity.Y - this.velocity.Y * 0.5f;
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
					Dust expr_92C_cp_0 = Main.dust[num5];
					expr_92C_cp_0.velocity.X = expr_92C_cp_0.velocity.X - this.velocity.X * 0.5f;
					Dust expr_956_cp_0 = Main.dust[num5];
					expr_956_cp_0.velocity.Y = expr_956_cp_0.velocity.Y - this.velocity.Y * 0.5f;
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
						Dust expr_E14_cp_0 = Main.dust[num9];
						expr_E14_cp_0.velocity.Y = expr_E14_cp_0.velocity.Y - 0.003f;
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
					else
					{
						if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.666)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 2;
						}
						else
						{
							this.bodyFrame.Y = this.bodyFrame.Height;
						}
					}
				}
				else
				{
					if (this.inventory[this.selectedItem].useStyle == 2)
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
					else
					{
						if (this.inventory[this.selectedItem].useStyle == 3)
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
						else
						{
							if (this.inventory[this.selectedItem].useStyle == 4)
							{
								this.bodyFrame.Y = this.bodyFrame.Height * 2;
							}
							else
							{
								if (this.inventory[this.selectedItem].useStyle == 5)
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
						}
					}
				}
			}
			else
			{
				if (this.pulley)
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
				else
				{
					if (this.inventory[this.selectedItem].holdStyle == 1 && (!this.wet || !this.inventory[this.selectedItem].noWet))
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
					}
					else
					{
						if (this.inventory[this.selectedItem].holdStyle == 2 && (!this.wet || !this.inventory[this.selectedItem].noWet))
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 2;
						}
						else
						{
							if (this.inventory[this.selectedItem].holdStyle == 3)
							{
								this.bodyFrame.Y = this.bodyFrame.Height * 3;
							}
							else
							{
								if (this.grappling[0] >= 0)
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
									else
									{
										if (num12 > 0f && Math.Abs(num12) > Math.Abs(num11))
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
								}
								else
								{
									if (this.swimTime > 0)
									{
										if (this.swimTime > 20)
										{
											this.bodyFrame.Y = 0;
										}
										else
										{
											if (this.swimTime > 10)
											{
												this.bodyFrame.Y = this.bodyFrame.Height * 5;
											}
											else
											{
												this.bodyFrame.Y = 0;
											}
										}
									}
									else
									{
										if (this.velocity.Y != 0f)
										{
											if (this.sliding)
											{
												this.bodyFrame.Y = this.bodyFrame.Height * 3;
											}
											else
											{
												if (this.sandStorm || this.carpetFrame >= 0)
												{
													this.bodyFrame.Y = this.bodyFrame.Height * 6;
												}
												else
												{
													if (this.wings > 0)
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
												}
											}
											this.bodyFrameCounter = 0.0;
										}
										else
										{
											if (this.velocity.X != 0f)
											{
												this.bodyFrameCounter += (double)Math.Abs(this.velocity.X) * 1.5;
												this.bodyFrame.Y = this.legFrame.Y;
											}
											else
											{
												this.bodyFrameCounter = 0.0;
												this.bodyFrame.Y = 0;
											}
										}
									}
								}
							}
						}
					}
				}
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
				else
				{
					if (this.legFrame.Y > this.legFrame.Height * 19)
					{
						this.legFrame.Y = this.legFrame.Height * 7;
					}
				}
			}
			else
			{
				if (this.velocity.Y != 0f || this.grappling[0] > -1)
				{
					this.legFrameCounter = 0.0;
					this.legFrame.Y = this.legFrame.Height * 5;
				}
				else
				{
					if (this.velocity.X != 0f)
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
							else
							{
								if (this.legFrame.Y > this.legFrame.Height * 19)
								{
									this.legFrame.Y = this.legFrame.Height * 7;
								}
							}
						}
					}
					else
					{
						this.legFrameCounter = 0.0;
						this.legFrame.Y = 0;
					}
				}
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
				Lighting.BlackOut();
				Main.screenLastPosition = Main.screenPosition;
				Main.screenPosition.X = this.position.X + (float)(this.width / 2) - (float)(Main.screenWidth / 2);
				Main.screenPosition.Y = this.position.Y + (float)(this.height / 2) - (float)(Main.screenHeight / 2);
				if (Main.mapTime < 5)
				{
					Main.mapTime = 5;
				}
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
				if (Main.netMode == 1)
				{
					Netplay.newRecent();
				}
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
				else
				{
					if (this.wereWolf)
					{
						Main.PlaySound(3, (int)this.position.X, (int)this.position.Y, 6);
					}
					else
					{
						if (this.boneArmor)
						{
							Main.PlaySound(3, (int)this.position.X, (int)this.position.Y, 2);
						}
						else
						{
							if (!this.male)
							{
								Main.PlaySound(20, (int)this.position.X, (int)this.position.Y, 1);
							}
							else
							{
								Main.PlaySound(1, (int)this.position.X, (int)this.position.Y, 1);
							}
						}
					}
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
						else
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
					else
					{
						if (this.difficulty == 2)
						{
							this.DropItems();
							this.KillMeForGood();
						}
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
			int num8 = 0;
			while ((double)num8 < 20.0 + dmg / (double)this.statLifeMax * 100.0)
			{
				if (this.boneArmor)
				{
					Dust.NewDust(this.position, this.width, this.height, 26, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
				}
				else
				{
					Dust.NewDust(this.position, this.width, this.height, 5, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
				}
				num8++;
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
			else
			{
				if (Main.netMode == 0)
				{
					Main.NewText(this.name + deathText, 225, 25, 25, false);
				}
			}
			if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
			{
				int num9 = 0;
				if (pvp)
				{
					num9 = 1;
				}
				NetMessage.SendData(44, -1, -1, deathText, this.whoAmi, (float)hitDirection, (float)((int)dmg), (float)num9, 0);
			}
			if (!pvp && this.whoAmi == Main.myPlayer && this.difficulty == 0)
			{
				this.DropCoins();
			}
			if (this.whoAmi == Main.myPlayer)
			{
				try
				{
					WorldGen.saveToonWhilePlaying();
				}
				catch
				{
				}
			}
		}
		public bool ItemSpace(Item newItem)
		{
			if (newItem.type == 58)
			{
				return true;
			}
			if (newItem.type == 184)
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
					if (this.inventory[j].IsTheSameAs(this.inventory[i]) && j != i && this.inventory[j].stack < this.inventory[j].maxStack)
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
						else
						{
							if (Main.tile[num11, num12].wallColor() > 0 && Main.tile[num11, num12].wall > 0 && WorldGen.paintWall(num11, num12, 0, true))
							{
								this.itemTime = this.inventory[this.selectedItem].useTime;
							}
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
					else
					{
						if (Main.tile[num13, num14].frameX < 144 && this.inventory[this.selectedItem].type == 1338)
						{
							num15 = 2;
						}
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
					else
					{
						if (Main.rand.Next(25) == 0)
						{
							num26 = Main.rand.Next(6);
							if (num26 == 0)
							{
								num26 = 181;
							}
							else
							{
								if (num26 == 1)
								{
									num26 = 180;
								}
								else
								{
									if (num26 == 2)
									{
										num26 = 177;
									}
									else
									{
										if (num26 == 3)
										{
											num26 = 179;
										}
										else
										{
											if (num26 == 4)
											{
												num26 = 178;
											}
											else
											{
												num26 = 182;
											}
										}
									}
								}
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
						else
						{
							if (Main.rand.Next(50) == 0)
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
							else
							{
								if (Main.rand.Next(3) == 0)
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
									else
									{
										if (Main.rand.Next(400) == 0)
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
										else
										{
											if (Main.rand.Next(30) == 0)
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
									}
								}
								else
								{
									num26 = Main.rand.Next(8);
									if (num26 == 0)
									{
										num26 = 12;
									}
									else
									{
										if (num26 == 1)
										{
											num26 = 11;
										}
										else
										{
											if (num26 == 2)
											{
												num26 = 14;
											}
											else
											{
												if (num26 == 3)
												{
													num26 = 13;
												}
												else
												{
													if (num26 == 4)
													{
														num26 = 699;
													}
													else
													{
														if (num26 == 5)
														{
															num26 = 700;
														}
														else
														{
															if (num26 == 6)
															{
																num26 = 701;
															}
															else
															{
																num26 = 702;
															}
														}
													}
												}
											}
										}
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
							}
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
			else
			{
				if (this.inventory[this.selectedItem].createTile >= 0 && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
				{
					this.showItemIcon = true;
					bool flag = false;
					if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0 && Main.tile[Player.tileTargetX, Player.tileTargetY].lava())
					{
						if (Main.tileSolid[this.inventory[this.selectedItem].createTile])
						{
							flag = true;
						}
						else
						{
							if (Main.tileLavaDeath[this.inventory[this.selectedItem].createTile])
							{
								flag = true;
							}
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
						else
						{
							if (this.inventory[this.selectedItem].createTile == 227)
							{
								flag3 = true;
							}
							else
							{
								if (this.inventory[this.selectedItem].createTile == 60 || this.inventory[this.selectedItem].createTile == 70)
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].nactive() && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 59)
									{
										flag3 = true;
									}
								}
								else
								{
									if (this.inventory[this.selectedItem].createTile == 4 || this.inventory[this.selectedItem].createTile == 136)
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
												else
												{
													if (!WorldGen.SolidTileNotDoor(Player.tileTargetX, Player.tileTargetY + 1) && !WorldGen.SolidTileNotDoor(Player.tileTargetX - 1, Player.tileTargetY) && (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].halfBrick() || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].slope() != 0))
													{
														WorldGen.SlopeTile(Player.tileTargetX - 1, Player.tileTargetY, 0);
														if (Main.netMode == 1)
														{
															NetMessage.SendData(17, -1, -1, "", 14, (float)(Player.tileTargetX - 1), (float)Player.tileTargetY, 0f, 0);
														}
													}
													else
													{
														if (!WorldGen.SolidTileNotDoor(Player.tileTargetX, Player.tileTargetY + 1) && !WorldGen.SolidTileNotDoor(Player.tileTargetX - 1, Player.tileTargetY) && !WorldGen.SolidTileNotDoor(Player.tileTargetX + 1, Player.tileTargetY) && (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].halfBrick() || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].slope() != 0))
														{
															WorldGen.SlopeTile(Player.tileTargetX + 1, Player.tileTargetY, 0);
															if (Main.netMode == 1)
															{
																NetMessage.SendData(17, -1, -1, "", 14, (float)(Player.tileTargetX + 1), (float)Player.tileTargetY, 0f, 0);
															}
														}
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
											else
											{
												if ((num30 >= 0 && Main.tileSolid[num30] && !Main.tileNoAttach[num30]) || (num30 == 5 && num32 == 5 && num34 == 5) || num30 == 124)
												{
													flag3 = true;
												}
												else
												{
													if ((num31 >= 0 && Main.tileSolid[num31] && !Main.tileNoAttach[num31]) || (num31 == 5 && num33 == 5 && num35 == 5) || num31 == 124)
													{
														flag3 = true;
													}
												}
											}
										}
									}
									else
									{
										if (this.inventory[this.selectedItem].createTile == 78 || this.inventory[this.selectedItem].createTile == 98 || this.inventory[this.selectedItem].createTile == 100 || this.inventory[this.selectedItem].createTile == 173 || this.inventory[this.selectedItem].createTile == 174)
										{
											if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].nactive() && (Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type] || Main.tileTable[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type]))
											{
												flag3 = true;
											}
										}
										else
										{
											if (this.inventory[this.selectedItem].createTile == 13 || this.inventory[this.selectedItem].createTile == 29 || this.inventory[this.selectedItem].createTile == 33 || this.inventory[this.selectedItem].createTile == 49 || this.inventory[this.selectedItem].createTile == 50 || this.inventory[this.selectedItem].createTile == 103)
											{
												if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].nactive() && Main.tileTable[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type])
												{
													flag3 = true;
												}
											}
											else
											{
												if (this.inventory[this.selectedItem].createTile == 51)
												{
													if (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active() || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active() || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active() || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active() || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0)
													{
														flag3 = true;
													}
												}
												else
												{
													if ((Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active() && (Main.tileSolid[(int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type] || Main.tileRope[(int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type])) || (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0 || (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active() && (Main.tileSolid[(int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type] || Main.tileRope[(int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type]))) || (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0 || (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active() && (Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type] || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type == 124 || Main.tileRope[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type]))) || (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0 || (Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active() && (Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type] || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type == 124 || Main.tileRope[(int)Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type]))) || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0)
													{
														flag3 = true;
													}
												}
											}
										}
									}
								}
							}
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
										Tile expr_2584 = Main.tile[Player.tileTargetX, Player.tileTargetY];
										expr_2584.frameX += 18;
										Tile expr_25A9 = Main.tile[Player.tileTargetX, Player.tileTargetY - 1];
										expr_25A9.frameX += 18;
									}
									if (Main.netMode == 1)
									{
										NetMessage.SendTileSquare(-1, Player.tileTargetX - 1, Player.tileTargetY - 1, 3);
									}
								}
								else
								{
									if (this.inventory[this.selectedItem].createTile == 137)
									{
										if (this.direction == 1)
										{
											Tile expr_2613 = Main.tile[Player.tileTargetX, Player.tileTargetY];
											expr_2613.frameX += 18;
										}
										if (Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 1);
										}
									}
									else
									{
										if ((this.inventory[this.selectedItem].createTile == 79 || this.inventory[this.selectedItem].createTile == 90) && Main.netMode == 1)
										{
											NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 5);
										}
									}
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
				else
				{
					if (this.inventory[this.selectedItem].ranged)
					{
						num = (int)((float)num * this.rangedDamage);
						if (this.inventory[this.selectedItem].useAmmo == 1)
						{
							num = (int)((float)num * this.arrowDamage);
						}
						if (this.inventory[this.selectedItem].useAmmo == 14)
						{
							num = (int)((float)num * this.bulletDamage);
						}
						if (this.inventory[this.selectedItem].useAmmo == 771 || this.inventory[this.selectedItem].useAmmo == 246)
						{
							num = (int)((float)num * this.rocketDamage);
						}
					}
					else
					{
						if (this.inventory[this.selectedItem].magic)
						{
							num = (int)((float)num * this.magicDamage);
						}
					}
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
						else
						{
							if (num4 == 1 && this.inventory[this.selectedItem].bodySlot >= 0)
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
							else
							{
								if (num4 == 2 && this.inventory[this.selectedItem].legSlot >= 0)
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
				if (this.inventory[this.selectedItem].shoot == 6 || this.inventory[this.selectedItem].shoot == 19 || this.inventory[this.selectedItem].shoot == 33 || this.inventory[this.selectedItem].shoot == 52 || this.inventory[this.selectedItem].shoot == 113 || this.inventory[this.selectedItem].shoot == 182)
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
				if (this.inventory[this.selectedItem].shoot == 13 || this.inventory[this.selectedItem].shoot == 32 || (this.inventory[this.selectedItem].shoot >= 230 && this.inventory[this.selectedItem].shoot <= 235))
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
						else
						{
							if (this.manaFlower)
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
				if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 1312)
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
						else
						{
							if (this.controlLeft)
							{
								this.direction = -1;
							}
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
					if ((this.inventory[this.selectedItem].shoot >= 191 && this.inventory[this.selectedItem].shoot <= 194) || this.inventory[this.selectedItem].shoot == 266)
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
				bool arg_176A_0 = this.channel;
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
					/*this.itemHeight = Main.itemTexture[this.inventory[this.selectedItem].type].Height;
					this.itemWidth = Main.itemTexture[this.inventory[this.selectedItem].type].Width;*/
				}
				this.itemAnimation--;
				if (!Main.dedServ)
				{/*
					if (this.inventory[this.selectedItem].useStyle == 1)
					{
						if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
						{
							float num19 = 10f;
							if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
							{
								num19 = 14f;
							}
							if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 52)
							{
								num19 = 24f;
							}
							if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 64)
							{
								num19 = 28f;
							}
							if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 92)
							{
								num19 = 38f;
							}
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num19) * (float)this.direction;
							this.itemLocation.Y = this.position.Y + 24f;
						}
						else
						{
							if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.666)
							{
								float num20 = 10f;
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
								{
									num20 = 18f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 52)
								{
									num20 = 24f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 64)
								{
									num20 = 28f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 92)
								{
									num20 = 38f;
								}
								this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num20) * (float)this.direction;
								num20 = 10f;
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 32)
								{
									num20 = 8f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Height >= 32)
								{
									num20 = 12f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 64)
								{
									num20 = 14f;
								}
								this.itemLocation.Y = this.position.Y + num20;
							}
							else
							{
								float num21 = 6f;
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
								{
									num21 = 14f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 52)
								{
									num21 = 24f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 64)
								{
									num21 = 28f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Width >= 92)
								{
									num21 = 38f;
								}
								this.itemLocation.X = this.position.X + (float)this.width * 0.5f - ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num21) * (float)this.direction;
								num21 = 10f;
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 32)
								{
									num21 = 10f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 52)
								{
									num21 = 12f;
								}
								if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 64)
								{
									num21 = 14f;
								}
								this.itemLocation.Y = this.position.Y + num21;
							}
						}
						this.itemRotation = ((float)this.itemAnimation / (float)this.itemAnimationMax - 0.5f) * (float)(-(float)this.direction) * 3.5f - (float)this.direction * 0.3f;
						if (this.gravDir == -1f)
						{
							this.itemRotation = -this.itemRotation;
							this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
						}
					}
					else
					{
						if (this.inventory[this.selectedItem].useStyle == 2)
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
						else
						{
							if (this.inventory[this.selectedItem].useStyle == 3)
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
									float num22 = (float)this.itemAnimation / (float)this.itemAnimationMax * (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * (float)this.direction * this.inventory[this.selectedItem].scale * 1.2f - (float)(10 * this.direction);
									if (num22 > -4f && this.direction == -1)
									{
										num22 = -8f;
									}
									if (num22 < 4f && this.direction == 1)
									{
										num22 = 8f;
									}
									this.itemLocation.X = this.itemLocation.X - num22;
									this.itemRotation = 0.8f * (float)this.direction;
								}
								if (this.gravDir == -1f)
								{
									this.itemRotation = -this.itemRotation;
									this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
								}
							}
							else
							{
								if (this.inventory[this.selectedItem].useStyle == 4)
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
								else
								{
									if (this.inventory[this.selectedItem].useStyle == 5)
									{
										this.itemLocation.X = this.position.X + (float)this.width * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - (float)(this.direction * 2);
										this.itemLocation.Y = this.position.Y + (float)this.height * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5f;
									}
								}
							}
						}
					}*/
				}
			}
			else
			{
				if (this.inventory[this.selectedItem].holdStyle == 1 && !this.pulley)
				{
					if (Main.dedServ)
					{
						this.itemLocation.X = this.position.X + (float)this.width * 0.5f + 20f * (float)this.direction;
					}
					else
					{/*
						if (this.inventory[this.selectedItem].type == 930)
						{
							this.itemLocation.X = this.position.X + (float)(this.width / 2) * 0.5f - 12f - (float)(2 * this.direction);
							float num23 = this.position.X + (float)(this.width / 2) + (float)(38 * this.direction);
							if (this.direction == 1)
							{
								num23 -= 10f;
							}
							float num24 = this.position.Y + (float)(this.height / 2) - 4f * this.gravDir;
							if (this.gravDir == -1f)
							{
								num24 -= 8f;
							}
							int num25 = Dust.NewDust(new Vector2(num23, num24 + this.gfxOffY), 6, 6, 127, 0f, 0f, 100, default(Color), 1.6f);
							Main.dust[num25].noGravity = true;
							Dust expr_250C_cp_0 = Main.dust[num25];
							expr_250C_cp_0.velocity.Y = expr_250C_cp_0.velocity.Y - 4f * this.gravDir;
						}
						else
						{
							if (this.inventory[this.selectedItem].type == 968)
							{
								this.itemLocation.X = this.position.X + (float)this.width * 0.5f + (float)(8 * this.direction);
								if (this.whoAmi == Main.myPlayer)
								{
									int num26 = (int)(this.itemLocation.X + (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.8f * (float)this.direction) / 16;
									int num27 = (int)(this.itemLocation.Y + (float)(Main.itemTexture[this.inventory[this.selectedItem].type].Height / 2)) / 16;
									if (Main.tile[num26, num27] == null)
									{
										Main.tile[num26, num27] = new Tile();
									}
									if (Main.tile[num26, num27].active() && Main.tile[num26, num27].type == 215)
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
											if (this.selectedItem == 48)
											{
												Main.mouseItem.SetDefaults(969, false);
											}
											for (int num28 = 0; num28 < 58; num28++)
											{
												if (this.inventory[num28].type == this.inventory[this.selectedItem].type && num28 != this.selectedItem && this.inventory[num28].stack < this.inventory[num28].maxStack)
												{
													Main.PlaySound(7, -1, -1, 1);
													this.inventory[num28].stack++;
													this.inventory[this.selectedItem].SetDefaults(0, false);
													if (this.selectedItem == 48)
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
							else
							{
								if (this.inventory[this.selectedItem].type == 856)
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
								}
							}
						}*/
					}
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
				else
				{
					if (this.inventory[this.selectedItem].holdStyle == 2 && !this.pulley)
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
							else
							{
								if (this.velocity.Y > 2f)
								{
									this.velocity.Y = 2f;
								}
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
					else
					{
						if (this.inventory[this.selectedItem].holdStyle == 3 && !this.pulley && !Main.dedServ)
						{/*
							this.itemLocation.X = this.position.X + (float)this.width * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - (float)(this.direction * 2);
							this.itemLocation.Y = this.position.Y + (float)this.height * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5f;
							this.itemRotation = 0f;*/
						}
					}
				}
			}
			if ((((this.inventory[this.selectedItem].type == 974 || this.inventory[this.selectedItem].type == 8 || this.inventory[this.selectedItem].type == 1245 || (this.inventory[this.selectedItem].type >= 427 && this.inventory[this.selectedItem].type <= 433)) && !this.wet) || this.inventory[this.selectedItem].type == 523 || this.inventory[this.selectedItem].type == 1333) && !this.pulley)
			{
				float r = 1f;
				float g = 0.95f;
				float b = 0.8f;
				int num29 = 0;
				if (this.inventory[this.selectedItem].type == 523)
				{
					num29 = 8;
				}
				else
				{
					if (this.inventory[this.selectedItem].type == 974)
					{
						num29 = 9;
					}
					else
					{
						if (this.inventory[this.selectedItem].type == 1245)
						{
							num29 = 10;
						}
						else
						{
							if (this.inventory[this.selectedItem].type == 1333)
							{
								num29 = 11;
							}
							else
							{
								if (this.inventory[this.selectedItem].type >= 427)
								{
									num29 = this.inventory[this.selectedItem].type - 426;
								}
							}
						}
					}
				}
				if (num29 == 1)
				{
					r = 0f;
					g = 0.1f;
					b = 1.3f;
				}
				else
				{
					if (num29 == 2)
					{
						r = 1f;
						g = 0.1f;
						b = 0.1f;
					}
					else
					{
						if (num29 == 3)
						{
							r = 0f;
							g = 1f;
							b = 0.1f;
						}
						else
						{
							if (num29 == 4)
							{
								r = 0.9f;
								g = 0f;
								b = 0.9f;
							}
							else
							{
								if (num29 == 5)
								{
									r = 1.3f;
									g = 1.3f;
									b = 1.3f;
								}
								else
								{
									if (num29 == 6)
									{
										r = 0.9f;
										g = 0.9f;
										b = 0f;
									}
									else
									{
										if (num29 == 7)
										{
											r = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
											g = 0.3f;
											b = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
										}
										else
										{
											if (num29 == 8)
											{
												b = 0.7f;
												r = 0.85f;
												g = 1f;
											}
											else
											{
												if (num29 == 9)
												{
													b = 1f;
													r = 0.7f;
													g = 0.85f;
												}
												else
												{
													if (num29 == 10)
													{
														b = 0f;
														r = 1f;
														g = 0.5f;
													}
													else
													{
														if (num29 == 11)
														{
															b = 0.8f;
															r = 1.25f;
															g = 1.25f;
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
				int num30 = num29;
				if (num30 == 0)
				{
					num30 = 6;
				}
				else
				{
					if (num30 == 8)
					{
						num30 = 75;
					}
					else
					{
						if (num30 == 9)
						{
							num30 = 135;
						}
						else
						{
							if (num30 == 10)
							{
								num30 = 158;
							}
							else
							{
								if (num30 == 11)
								{
									num30 = 169;
								}
								else
								{
									num30 = 58 + num30;
								}
							}
						}
					}
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
						int num31 = Dust.NewDust(new Vector2(this.itemLocation.X - 16f, this.itemLocation.Y - 14f * this.gravDir), 4, 4, num30, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num31].noGravity = true;
						}
						Main.dust[num31].velocity *= 0.3f;
						Dust expr_3089_cp_0 = Main.dust[num31];
						expr_3089_cp_0.velocity.Y = expr_3089_cp_0.velocity.Y - 1.5f;
					}
					Lighting.addLight((int)((this.itemLocation.X - 12f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f + this.velocity.Y) / 16f), r, g, b);
				}
				else
				{
					if (Main.rand.Next(maxValue) == 0)
					{
						int num32 = Dust.NewDust(new Vector2(this.itemLocation.X + 6f, this.itemLocation.Y - 14f * this.gravDir), 4, 4, num30, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num32].noGravity = true;
						}
						Main.dust[num32].velocity *= 0.3f;
						Dust expr_319C_cp_0 = Main.dust[num32];
						expr_319C_cp_0.velocity.Y = expr_319C_cp_0.velocity.Y - 1.5f;
					}
					Lighting.addLight((int)((this.itemLocation.X + 12f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f + this.velocity.Y) / 16f), r, g, b);
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
						int num33 = Dust.NewDust(new Vector2(this.itemLocation.X - 12f, this.itemLocation.Y - 20f * this.gravDir), 4, 4, 6, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num33].noGravity = true;
						}
						Main.dust[num33].velocity *= 0.3f;
						Dust expr_32F4_cp_0 = Main.dust[num33];
						expr_32F4_cp_0.velocity.Y = expr_32F4_cp_0.velocity.Y - 1.5f;
					}
					Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 1f, 0.95f, 0.8f);
				}
				else
				{
					if (Main.rand.Next(maxValue2) == 0)
					{
						int num34 = Dust.NewDust(new Vector2(this.itemLocation.X + 4f, this.itemLocation.Y - 20f * this.gravDir), 4, 4, 6, 0f, 0f, 100, default(Color), 1f);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num34].noGravity = true;
						}
						Main.dust[num34].velocity *= 0.3f;
						Dust expr_3403_cp_0 = Main.dust[num34];
						expr_3403_cp_0.velocity.Y = expr_3403_cp_0.velocity.Y - 1.5f;
					}
					Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 1f, 0.95f, 0.8f);
				}
			}
			else
			{
				if (this.inventory[this.selectedItem].type == 148 && !this.wet)
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
							int num35 = Dust.NewDust(new Vector2(this.itemLocation.X - 12f, this.itemLocation.Y - 20f * this.gravDir), 4, 4, 172, 0f, 0f, 100, default(Color), 1f);
							if (Main.rand.Next(3) != 0)
							{
								Main.dust[num35].noGravity = true;
							}
							Main.dust[num35].velocity *= 0.3f;
							Dust expr_3559_cp_0 = Main.dust[num35];
							expr_3559_cp_0.velocity.Y = expr_3559_cp_0.velocity.Y - 1.5f;
						}
						Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0f, 0.5f, 1f);
					}
					else
					{
						if (Main.rand.Next(maxValue3) == 0)
						{
							int num36 = Dust.NewDust(new Vector2(this.itemLocation.X + 4f, this.itemLocation.Y - 20f * this.gravDir), 4, 4, 172, 0f, 0f, 100, default(Color), 1f);
							if (Main.rand.Next(3) != 0)
							{
								Main.dust[num36].noGravity = true;
							}
							Main.dust[num36].velocity *= 0.3f;
							Dust expr_366C_cp_0 = Main.dust[num36];
							expr_366C_cp_0.velocity.Y = expr_366C_cp_0.velocity.Y - 1.5f;
						}
						Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0f, 0.5f, 1f);
					}
				}
			}
			if (this.inventory[this.selectedItem].type == 282 && !this.pulley)
			{
				if (this.direction == -1)
				{
					Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 1f, 0.8f);
				}
				else
				{
					Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 1f, 0.8f);
				}
			}
			if (this.inventory[this.selectedItem].type == 286 && !this.pulley)
			{
				if (this.direction == -1)
				{
					Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 0.8f, 1f);
				}
				else
				{
					Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 0.8f, 1f);
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
						for (int num37 = 0; num37 < 5; num37++)
						{
							int num38 = Dust.NewDust(this.position, this.width, this.height, 45, 0f, 0f, 255, default(Color), (float)Main.rand.Next(20, 26) * 0.1f);
							Main.dust[num38].noLight = true;
							Main.dust[num38].noGravity = true;
							Main.dust[num38].velocity *= 0.5f;
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
					int num39 = this.inventory[this.selectedItem].shoot;
					float num40 = this.inventory[this.selectedItem].shootSpeed;
					if (this.inventory[this.selectedItem].melee && num39 != 25 && num39 != 26 && num39 != 35)
					{
						num40 /= this.meleeSpeed;
					}
					bool flag5 = false;
					int num41 = num;
					float num42 = this.inventory[this.selectedItem].knockBack;
					if (num39 == 13 || num39 == 32 || (num39 >= 230 && num39 <= 235))
					{
						this.grappling[0] = -1;
						this.grapCount = 0;
						for (int num43 = 0; num43 < 1000; num43++)
						{
							if (Main.projectile[num43].active && Main.projectile[num43].owner == i)
							{
								if (Main.projectile[num43].type == 13)
								{
									Main.projectile[num43].Kill();
								}
								if (Main.projectile[num43].type >= 230 && Main.projectile[num43].type <= 235)
								{
									Main.projectile[num43].Kill();
								}
							}
						}
					}
					if (this.inventory[this.selectedItem].useAmmo > 0)
					{
						Item item = new Item();
						bool flag6 = false;
						for (int num44 = 54; num44 < 58; num44++)
						{
							if (this.inventory[num44].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[num44].stack > 0)
							{
								item = this.inventory[num44];
								flag5 = true;
								flag6 = true;
								break;
							}
						}
						if (!flag6)
						{
							for (int num45 = 0; num45 < 54; num45++)
							{
								if (this.inventory[num45].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[num45].stack > 0)
								{
									item = this.inventory[num45];
									flag5 = true;
									break;
								}
							}
						}
						if (flag5)
						{
							if (this.inventory[this.selectedItem].useAmmo == 771)
							{
								num39 += item.shoot;
							}
							else
							{
								if (this.inventory[this.selectedItem].useAmmo == 780)
								{
									num39 += item.shoot;
								}
								else
								{
									if (item.shoot > 0)
									{
										num39 = item.shoot;
									}
								}
							}
							if (num39 == 42)
							{
								if (item.type == 370)
								{
									num39 = 65;
									num41 += 5;
								}
								else
								{
									if (item.type == 408)
									{
										num39 = 68;
										num41 += 5;
									}
								}
							}
							if (this.magicQuiver && this.inventory[this.selectedItem].useAmmo == 1)
							{
								num42 = (float)((int)((double)num42 * 1.1));
								num40 *= 1.1f;
								num41 = (int)((double)num41 * 1.1);
							}
							num40 += item.shootSpeed;
							if (item.ranged)
							{
								if (item.damage > 0)
								{
									num41 += (int)((float)item.damage * this.rangedDamage);
								}
							}
							else
							{
								num41 += item.damage;
							}
							if (this.inventory[this.selectedItem].useAmmo == 1 && this.archery)
							{
								if (num40 < 20f)
								{
									num40 *= 1.2f;
									if (num40 > 20f)
									{
										num40 = 20f;
									}
								}
								num41 = (int)((double)((float)num41) * 1.2);
							}
							num42 += item.knockBack;
							bool flag7 = false;
							if (this.magicQuiver && this.inventory[this.selectedItem].useAmmo == 1 && Main.rand.Next(5) == 0)
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
							if (num39 == 85 && this.itemAnimation < this.itemAnimationMax - 6)
							{
								flag7 = true;
							}
							if ((num39 == 145 || num39 == 146 || num39 == 147 || num39 == 148 || num39 == 149) && this.itemAnimation < this.itemAnimationMax - 5)
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
					if (this.inventory[this.selectedItem].type == 1254 && num39 == 14)
					{
						num39 = 242;
					}
					if (this.inventory[this.selectedItem].type == 1255 && num39 == 14)
					{
						num39 = 242;
					}
					if (this.inventory[this.selectedItem].type == 1265 && num39 == 14)
					{
						num39 = 242;
					}
					if (num39 == 73)
					{
						for (int num46 = 0; num46 < 1000; num46++)
						{
							if (Main.projectile[num46].active && Main.projectile[num46].owner == i)
							{
								if (Main.projectile[num46].type == 73)
								{
									num39 = 74;
								}
								if (num39 == 74 && Main.projectile[num46].type == 74)
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
							num42 += this.minionKB;
							num41 = (int)((float)num41 * this.minionDamage);
						}
						if (num39 == 228)
						{
							num42 = 0f;
						}
						if (this.inventory[this.selectedItem].mech && this.kbGlove)
						{
							num42 *= 1.7f;
						}
						if (this.inventory[this.selectedItem].ranged && this.armorSteath)
						{
							num42 *= 1f + (1f - this.stealth) * 0.5f;
						}
						if (num39 == 1 && this.inventory[this.selectedItem].type == 120)
						{
							num39 = 2;
						}
						if (this.inventory[this.selectedItem].type == 682)
						{
							num39 = 117;
						}
						if (this.inventory[this.selectedItem].type == 725)
						{
							num39 = 120;
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
						if (num39 == 9)
						{
							vector = new Vector2(this.position.X + (float)this.width * 0.5f + (float)(Main.rand.Next(201) * -(float)this.direction) + ((float)Main.mouseX + Main.screenPosition.X - this.position.X), this.position.Y + (float)this.height * 0.5f - 600f);
							num42 = 0f;
							num41 = num41 * 2;
						}
						else
						{
							if (num39 == 51)
							{
								vector.Y -= 6f * this.gravDir;
							}
						}
						float num47 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
						float num48 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
						if (this.gravDir == -1f)
						{
							num48 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector.Y;
						}
						float num49 = (float)Math.Sqrt((double)(num47 * num47 + num48 * num48));
						float num50 = num49;
						num49 = num40 / num49;
						num47 *= num49;
						num48 *= num49;
						if (this.inventory[this.selectedItem].type == 757)
						{
							num41 = (int)((float)num41 * 1.25f);
						}
						if (num39 == 250)
						{
							for (int num51 = 0; num51 < 1000; num51++)
							{
								if (Main.projectile[num51].active && Main.projectile[num51].owner == this.whoAmi && (Main.projectile[num51].type == 250 || Main.projectile[num51].type == 251))
								{
									Main.projectile[num51].Kill();
								}
							}
						}
						if (num39 == 12)
						{
							vector.X += num47 * 3f;
							vector.Y += num48 * 3f;
						}
						if (this.inventory[this.selectedItem].useStyle == 5)
						{
							this.itemRotation = (float)Math.Atan2((double)(num48 * (float)this.direction), (double)(num47 * (float)this.direction));
							NetMessage.SendData(13, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
							NetMessage.SendData(41, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
						}
						if (num39 == 17)
						{
							vector.X = (float)Main.mouseX + Main.screenPosition.X;
							vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
						}
						if (num39 == 76)
						{
							num39 += Main.rand.Next(3);
							num50 /= (float)(Main.screenHeight / 2);
							if (num50 > 1f)
							{
								num50 = 1f;
							}
							float num52 = num47 + (float)Main.rand.Next(-40, 41) * 0.01f;
							float num53 = num48 + (float)Main.rand.Next(-40, 41) * 0.01f;
							num52 *= num50 + 0.25f;
							num53 *= num50 + 0.25f;
							int num54 = Projectile.NewProjectile(vector.X, vector.Y, num52, num53, num39, num41, num42, i, 0f, 0f);
							Main.projectile[num54].ai[1] = 1f;
							num50 = num50 * 2f - 1f;
							if (num50 < -1f)
							{
								num50 = -1f;
							}
							if (num50 > 1f)
							{
								num50 = 1f;
							}
							Main.projectile[num54].ai[0] = num50;
							NetMessage.SendData(27, -1, -1, "", num54, 0f, 0f, 0f, 0);
						}
						else
						{
							if (this.inventory[this.selectedItem].type == 98 || this.inventory[this.selectedItem].type == 533)
							{
								float speedX = num47 + (float)Main.rand.Next(-40, 41) * 0.01f;
								float speedY = num48 + (float)Main.rand.Next(-40, 41) * 0.01f;
								Projectile.NewProjectile(vector.X, vector.Y, speedX, speedY, num39, num41, num42, i, 0f, 0f);
							}
							else
							{
								if (this.inventory[this.selectedItem].type == 1553)
								{
									float speedX2 = num47 + (float)Main.rand.Next(-40, 41) * 0.005f;
									float speedY2 = num48 + (float)Main.rand.Next(-40, 41) * 0.005f;
									Projectile.NewProjectile(vector.X, vector.Y, speedX2, speedY2, num39, num41, num42, i, 0f, 0f);
								}
								else
								{
									if (this.inventory[this.selectedItem].type == 518)
									{
										float num55 = num47;
										float num56 = num48;
										num55 += (float)Main.rand.Next(-40, 41) * 0.04f;
										num56 += (float)Main.rand.Next(-40, 41) * 0.04f;
										Projectile.NewProjectile(vector.X, vector.Y, num55, num56, num39, num41, num42, i, 0f, 0f);
									}
									else
									{
										if (this.inventory[this.selectedItem].type == 1265)
										{
											float num57 = num47;
											float num58 = num48;
											num57 += (float)Main.rand.Next(-30, 31) * 0.03f;
											num58 += (float)Main.rand.Next(-30, 31) * 0.03f;
											Projectile.NewProjectile(vector.X, vector.Y, num57, num58, num39, num41, num42, i, 0f, 0f);
										}
										else
										{
											if (this.inventory[this.selectedItem].type == 534)
											{
												for (int num59 = 0; num59 < 4; num59++)
												{
													float num60 = num47;
													float num61 = num48;
													num60 += (float)Main.rand.Next(-40, 41) * 0.05f;
													num61 += (float)Main.rand.Next(-40, 41) * 0.05f;
													Projectile.NewProjectile(vector.X, vector.Y, num60, num61, num39, num41, num42, i, 0f, 0f);
												}
											}
											else
											{
												if (this.inventory[this.selectedItem].type == 1308)
												{
													int num62 = 4;
													for (int num63 = 0; num63 < num62; num63++)
													{
														float num64 = num47;
														float num65 = num48;
														float num66 = 0.05f * (float)num63;
														num64 += (float)Main.rand.Next(-35, 36) * num66;
														num65 += (float)Main.rand.Next(-35, 36) * num66;
														num49 = (float)Math.Sqrt((double)(num64 * num64 + num65 * num65));
														num49 = num40 / num49;
														num64 *= num49;
														num65 *= num49;
														float x = vector.X;
														float y = vector.Y;
														Projectile.NewProjectile(x, y, num64, num65, num39, num41, num42, i, 0f, 0f);
													}
												}
												else
												{
													if (this.inventory[this.selectedItem].type == 1258)
													{
														float num67 = num47;
														float num68 = num48;
														num67 += (float)Main.rand.Next(-40, 41) * 0.01f;
														num68 += (float)Main.rand.Next(-40, 41) * 0.01f;
														vector.X += (float)Main.rand.Next(-40, 41) * 0.05f;
														vector.Y += (float)Main.rand.Next(-45, 36) * 0.05f;
														Projectile.NewProjectile(vector.X, vector.Y, num67, num68, num39, num41, num42, i, 0f, 0f);
													}
													else
													{
														if (this.inventory[this.selectedItem].type == 964)
														{
															for (int num69 = 0; num69 < 3; num69++)
															{
																float num70 = num47;
																float num71 = num48;
																num70 += (float)Main.rand.Next(-35, 36) * 0.04f;
																num71 += (float)Main.rand.Next(-35, 36) * 0.04f;
																Projectile.NewProjectile(vector.X, vector.Y, num70, num71, num39, num41, num42, i, 0f, 0f);
															}
														}
														else
														{
															if (this.inventory[this.selectedItem].type == 1569)
															{
																int num72 = 4;
																if (Main.rand.Next(2) == 0)
																{
																	num72++;
																}
																if (Main.rand.Next(4) == 0)
																{
																	num72++;
																}
																if (Main.rand.Next(8) == 0)
																{
																	num72++;
																}
																if (Main.rand.Next(16) == 0)
																{
																	num72++;
																}
																for (int num73 = 0; num73 < num72; num73++)
																{
																	float num74 = num47;
																	float num75 = num48;
																	float num76 = 0.05f * (float)num73;
																	num74 += (float)Main.rand.Next(-35, 36) * num76;
																	num75 += (float)Main.rand.Next(-35, 36) * num76;
																	num49 = (float)Math.Sqrt((double)(num74 * num74 + num75 * num75));
																	num49 = num40 / num49;
																	num74 *= num49;
																	num75 *= num49;
																	float x2 = vector.X;
																	float y2 = vector.Y;
																	Projectile.NewProjectile(x2, y2, num74, num75, num39, num41, num42, i, 0f, 0f);
																}
															}
															else
															{
																if (this.inventory[this.selectedItem].type == 1572)
																{
																	for (int num77 = 0; num77 < 1000; num77++)
																	{
																		if (Main.projectile[num77].owner == this.whoAmi && Main.projectile[num77].type == 308)
																		{
																			Main.projectile[num77].Kill();
																		}
																	}
																	int num78 = (int)((float)Main.mouseX + Main.screenPosition.X) / 16;
																	int num79 = (int)((float)Main.mouseY + Main.screenPosition.Y) / 16;
																	while (num79 < Main.maxTilesY - 10 && Main.tile[num78, num79] != null && !WorldGen.SolidTile(num78, num79) && Main.tile[num78 - 1, num79] != null && !WorldGen.SolidTile(num78 - 1, num79) && Main.tile[num78 + 1, num79] != null && !WorldGen.SolidTile(num78 + 1, num79))
																	{
																		num79++;
																	}
																	num79--;
																	Projectile.NewProjectile((float)Main.mouseX + Main.screenPosition.X, (float)(num79 * 16 - 24), 0f, 15f, num39, num41, num42, i, 0f, 0f);
																}
																else
																{
																	if (this.inventory[this.selectedItem].type == 1244 || this.inventory[this.selectedItem].type == 1256)
																	{
																		int num80 = Projectile.NewProjectile(vector.X, vector.Y, num47, num48, num39, num41, num42, i, 0f, 0f);
																		Main.projectile[num80].ai[0] = (float)Main.mouseX + Main.screenPosition.X;
																		Main.projectile[num80].ai[1] = (float)Main.mouseY + Main.screenPosition.Y;
																	}
																	else
																	{
																		if (this.inventory[this.selectedItem].type == 1229)
																		{
																			int num81 = Main.rand.Next(2, 4);
																			if (Main.rand.Next(5) == 0)
																			{
																				num81++;
																			}
																			for (int num82 = 0; num82 < num81; num82++)
																			{
																				float num83 = num47;
																				float num84 = num48;
																				if (num82 > 0)
																				{
																					num83 += (float)Main.rand.Next(-35, 36) * 0.04f;
																					num84 += (float)Main.rand.Next(-35, 36) * 0.04f;
																				}
																				if (num82 > 1)
																				{
																					num83 += (float)Main.rand.Next(-35, 36) * 0.04f;
																					num84 += (float)Main.rand.Next(-35, 36) * 0.04f;
																				}
																				if (num82 > 2)
																				{
																					num83 += (float)Main.rand.Next(-35, 36) * 0.04f;
																					num84 += (float)Main.rand.Next(-35, 36) * 0.04f;
																				}
																				int num85 = Projectile.NewProjectile(vector.X, vector.Y, num83, num84, num39, num41, num42, i, 0f, 0f);
																				Main.projectile[num85].noDropItem = true;
																			}
																		}
																		else
																		{
																			if (this.inventory[this.selectedItem].type == 1121 || this.inventory[this.selectedItem].type == 1155)
																			{
																				int num86;
																				if (this.inventory[this.selectedItem].type == 1121)
																				{
																					num86 = Main.rand.Next(1, 4);
																					if (Main.rand.Next(6) == 0)
																					{
																						num86++;
																					}
																					if (Main.rand.Next(6) == 0)
																					{
																						num86++;
																					}
																				}
																				else
																				{
																					num86 = Main.rand.Next(2, 5);
																					if (Main.rand.Next(5) == 0)
																					{
																						num86++;
																					}
																					if (Main.rand.Next(5) == 0)
																					{
																						num86++;
																					}
																				}
																				for (int num87 = 0; num87 < num86; num87++)
																				{
																					float num88 = num47;
																					float num89 = num48;
																					num88 += (float)Main.rand.Next(-35, 36) * 0.02f;
																					num89 += (float)Main.rand.Next(-35, 36) * 0.02f;
																					Projectile.NewProjectile(vector.X, vector.Y, num88, num89, num39, num41, num42, i, 0f, 0f);
																				}
																			}
																			else
																			{
																				if (this.inventory[this.selectedItem].type == 679)
																				{
																					for (int num90 = 0; num90 < 6; num90++)
																					{
																						float num91 = num47;
																						float num92 = num48;
																						num91 += (float)Main.rand.Next(-40, 41) * 0.05f;
																						num92 += (float)Main.rand.Next(-40, 41) * 0.05f;
																						Projectile.NewProjectile(vector.X, vector.Y, num91, num92, num39, num41, num42, i, 0f, 0f);
																					}
																				}
																				else
																				{
																					if (this.inventory[this.selectedItem].type == 434)
																					{
																						float num93 = num47;
																						float num94 = num48;
																						if (this.itemAnimation < 5)
																						{
																							num93 += (float)Main.rand.Next(-40, 41) * 0.01f;
																							num94 += (float)Main.rand.Next(-40, 41) * 0.01f;
																							num93 *= 1.1f;
																							num94 *= 1.1f;
																						}
																						else
																						{
																							if (this.itemAnimation < 10)
																							{
																								num93 += (float)Main.rand.Next(-20, 21) * 0.01f;
																								num94 += (float)Main.rand.Next(-20, 21) * 0.01f;
																								num93 *= 1.05f;
																								num94 *= 1.05f;
																							}
																						}
																						Projectile.NewProjectile(vector.X, vector.Y, num93, num94, num39, num41, num42, i, 0f, 0f);
																					}
																					else
																					{
																						if (this.inventory[this.selectedItem].type == 1157)
																						{
																							num39 = Main.rand.Next(191, 195);
																							num47 = 0f;
																							num48 = 0f;
																							vector.X = (float)Main.mouseX + Main.screenPosition.X;
																							vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
																							int num95 = Projectile.NewProjectile(vector.X, vector.Y, num47, num48, num39, num41, num42, i, 0f, 0f);
																							Main.projectile[num95].localAI[0] = 30f;
																						}
																						else
																						{
																							if (this.inventory[this.selectedItem].type == 1309)
																							{
																								num47 = 0f;
																								num48 = 0f;
																								vector.X = (float)Main.mouseX + Main.screenPosition.X;
																								vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
																								Projectile.NewProjectile(vector.X, vector.Y, num47, num48, num39, num41, num42, i, 0f, 0f);
																							}
																							else
																							{
																								if (this.inventory[this.selectedItem].shoot > 0 && (Main.projPet[this.inventory[this.selectedItem].shoot] || this.inventory[this.selectedItem].shoot == 72 || this.inventory[this.selectedItem].shoot == 18) && !this.inventory[this.selectedItem].summon)
																								{
																									for (int num96 = 0; num96 < 1000; num96++)
																									{
																										if (Main.projectile[num96].active && Main.projectile[num96].owner == this.whoAmi)
																										{
																											if (this.inventory[this.selectedItem].shoot == 72)
																											{
																												if (Main.projectile[num96].type == 72 || Main.projectile[num96].type == 86 || Main.projectile[num96].type == 87)
																												{
																													Main.projectile[num96].Kill();
																												}
																											}
																											else
																											{
																												if (this.inventory[this.selectedItem].shoot == Main.projectile[num96].type)
																												{
																													Main.projectile[num96].Kill();
																												}
																											}
																										}
																									}
																									if (num39 == 72)
																									{
																										int num97 = Main.rand.Next(3);
																										if (num97 == 0)
																										{
																											num39 = 72;
																										}
																										else
																										{
																											if (num97 == 1)
																											{
																												num39 = 86;
																											}
																											else
																											{
																												if (num97 == 2)
																												{
																													num39 = 87;
																												}
																											}
																										}
																									}
																									Projectile.NewProjectile(vector.X, vector.Y, num47, num48, num39, num41, num42, i, 0f, 0f);
																								}
																								else
																								{
																									int num98 = Projectile.NewProjectile(vector.X, vector.Y, num47, num48, num39, num41, num42, i, 0f, 0f);
																									if (num39 == 80)
																									{
																										Main.projectile[num98].ai[0] = (float)Player.tileTargetX;
																										Main.projectile[num98].ai[1] = (float)Player.tileTargetY;
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
					else
					{
						if (this.inventory[this.selectedItem].useStyle == 5)
						{
							this.itemRotation = 0f;
							NetMessage.SendData(41, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
						}
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
							int num99 = -1;
							for (int num100 = 0; num100 < 58; num100++)
							{
								if (this.inventory[num100].stack > 0 && this.inventory[num100].type == 530)
								{
									num99 = num100;
									break;
								}
							}
							if (num99 >= 0 && WorldGen.PlaceWire(i2, j2))
							{
								this.inventory[num99].stack--;
								if (this.inventory[num99].stack <= 0)
								{
									this.inventory[num99].SetDefaults(0, false);
								}
								this.itemTime = this.inventory[this.selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 5, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
							}
						}
						else
						{
							if (this.inventory[this.selectedItem].type == 850)
							{
								int num101 = -1;
								for (int num102 = 0; num102 < 58; num102++)
								{
									if (this.inventory[num102].stack > 0 && this.inventory[num102].type == 530)
									{
										num101 = num102;
										break;
									}
								}
								if (num101 >= 0 && WorldGen.PlaceWire2(i2, j2))
								{
									this.inventory[num101].stack--;
									if (this.inventory[num101].stack <= 0)
									{
										this.inventory[num101].SetDefaults(0, false);
									}
									this.itemTime = this.inventory[this.selectedItem].useTime;
									NetMessage.SendData(17, -1, -1, "", 10, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
								}
							}
						}
						if (this.inventory[this.selectedItem].type == 851)
						{
							int num103 = -1;
							for (int num104 = 0; num104 < 58; num104++)
							{
								if (this.inventory[num104].stack > 0 && this.inventory[num104].type == 530)
								{
									num103 = num104;
									break;
								}
							}
							if (num103 >= 0 && WorldGen.PlaceWire3(i2, j2))
							{
								this.inventory[num103].stack--;
								if (this.inventory[num103].stack <= 0)
								{
									this.inventory[num103].SetDefaults(0, false);
								}
								this.itemTime = this.inventory[this.selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 12, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
							}
						}
						else
						{
							if (this.inventory[this.selectedItem].type == 510)
							{
								if (WorldGen.KillActuator(i2, j2))
								{
									this.itemTime = this.inventory[this.selectedItem].useTime;
									NetMessage.SendData(17, -1, -1, "", 9, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
								}
								else
								{
									if (WorldGen.KillWire3(i2, j2))
									{
										this.itemTime = this.inventory[this.selectedItem].useTime;
										NetMessage.SendData(17, -1, -1, "", 13, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
									}
									else
									{
										if (WorldGen.KillWire2(i2, j2))
										{
											this.itemTime = this.inventory[this.selectedItem].useTime;
											NetMessage.SendData(17, -1, -1, "", 11, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
										}
										else
										{
											if (WorldGen.KillWire(i2, j2))
											{
												this.itemTime = this.inventory[this.selectedItem].useTime;
												NetMessage.SendData(17, -1, -1, "", 6, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
											}
										}
									}
								}
							}
							else
							{
								if (this.inventory[this.selectedItem].type == 849 && this.inventory[this.selectedItem].stack > 0 && WorldGen.PlaceActuator(i2, j2))
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
					}
				}
				if (this.itemAnimation > 0 && this.itemTime == 0 && (this.inventory[this.selectedItem].type == 507 || this.inventory[this.selectedItem].type == 508))
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num105 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
					float num106 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
					float num107 = (float)Math.Sqrt((double)(num105 * num105 + num106 * num106));
					num107 /= (float)(Main.screenHeight / 2);
					if (num107 > 1f)
					{
						num107 = 1f;
					}
					num107 = num107 * 2f - 1f;
					if (num107 < -1f)
					{
						num107 = -1f;
					}
					if (num107 > 1f)
					{
						num107 = 1f;
					}
					Main.harpNote = num107;
					int style = 26;
					if (this.inventory[this.selectedItem].type == 507)
					{
						style = 35;
					}
					Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, style);
					NetMessage.SendData(58, -1, -1, "", this.whoAmi, num107, 0f, 0f, 0);
				}
				if (((this.inventory[this.selectedItem].type >= 205 && this.inventory[this.selectedItem].type <= 207) || this.inventory[this.selectedItem].type == 1128) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
				{
					this.showItemIcon = true;
					if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
					{
						if (this.inventory[this.selectedItem].type == 205)
						{
							int num108 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType();
							int num109 = 0;
							for (int num110 = Player.tileTargetX - 1; num110 <= Player.tileTargetX + 1; num110++)
							{
								for (int num111 = Player.tileTargetY - 1; num111 <= Player.tileTargetY + 1; num111++)
								{
									if ((int)Main.tile[num110, num111].liquidType() == num108)
									{
										num109 += (int)Main.tile[num110, num111].liquid;
									}
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0 && num109 > 100)
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
								int num112 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquid;
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
								for (int num113 = Player.tileTargetX - 1; num113 <= Player.tileTargetX + 1; num113++)
								{
									for (int num114 = Player.tileTargetY - 1; num114 <= Player.tileTargetY + 1; num114++)
									{
										if (num112 < 256 && (int)Main.tile[num113, num114].liquidType() == num108)
										{
											int num115 = (int)Main.tile[num113, num114].liquid;
											if (num115 + num112 > 255)
											{
												num115 = 255 - num112;
											}
											num112 += num115;
											Tile expr_61D0 = Main.tile[num113, num114];
											expr_61D0.liquid -= (byte)num115;
											Main.tile[num113, num114].liquidType(liquidType);
											if (Main.tile[num113, num114].liquid == 0)
											{
												Main.tile[num113, num114].lava(false);
												Main.tile[num113, num114].honey(false);
											}
											WorldGen.SquareTileFrame(num113, num114, false);
											if (Main.netMode == 1)
											{
												NetMessage.sendWater(num113, num114);
											}
											else
											{
												Liquid.AddWater(num113, num114);
											}
										}
									}
								}
							}
						}
						else
						{
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid < 200 && (!Main.tile[Player.tileTargetX, Player.tileTargetY].nactive() || !Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tileSolidTop[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
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
								else
								{
									if (this.inventory[this.selectedItem].type == 206)
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
									else
									{
										if (this.inventory[this.selectedItem].type == 1128 && (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 2))
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
							else
							{
								if (Main.tileAxe[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
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
								else
								{
									if (this.inventory[this.selectedItem].pick > 0)
									{
										if (Main.tileDungeon[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 25 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 58 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 117 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 203)
										{
											this.hitTile += this.inventory[this.selectedItem].pick / 2;
										}
										else
										{
											if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 48 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 232)
											{
												this.hitTile += this.inventory[this.selectedItem].pick / 4;
											}
											else
											{
												if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 226)
												{
													this.hitTile += this.inventory[this.selectedItem].pick / 4;
												}
												else
												{
													if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 107 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 221)
													{
														this.hitTile += this.inventory[this.selectedItem].pick / 2;
													}
													else
													{
														if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 108 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 222)
														{
															this.hitTile += this.inventory[this.selectedItem].pick / 3;
														}
														else
														{
															if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 111 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 223)
															{
																this.hitTile += this.inventory[this.selectedItem].pick / 4;
															}
															else
															{
																if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 211)
																{
																	this.hitTile += this.inventory[this.selectedItem].pick / 5;
																}
																else
																{
																	this.hitTile += this.inventory[this.selectedItem].pick;
																}
															}
														}
													}
												}
											}
										}
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 211 && this.inventory[this.selectedItem].pick < 200)
										{
											this.hitTile = 0;
										}
										if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 25 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 203) && this.inventory[this.selectedItem].pick < 65)
										{
											this.hitTile = 0;
										}
										else
										{
											if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 117 && this.inventory[this.selectedItem].pick < 65)
											{
												this.hitTile = 0;
											}
											else
											{
												if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 37 && this.inventory[this.selectedItem].pick < 50)
												{
													this.hitTile = 0;
												}
												else
												{
													if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 22 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 204) && (double)Player.tileTargetY > Main.worldSurface && this.inventory[this.selectedItem].pick < 55)
													{
														this.hitTile = 0;
													}
													else
													{
														if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 56 && this.inventory[this.selectedItem].pick < 65)
														{
															this.hitTile = 0;
														}
														else
														{
															if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 58 && this.inventory[this.selectedItem].pick < 65)
															{
																this.hitTile = 0;
															}
															else
															{
																if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 226 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 237) && this.inventory[this.selectedItem].pick < 210)
																{
																	this.hitTile = 0;
																}
																else
																{
																	if (Main.tileDungeon[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] && this.inventory[this.selectedItem].pick < 65)
																	{
																		if ((double)Player.tileTargetX < (double)Main.maxTilesX * 0.35 || (double)Player.tileTargetX > (double)Main.maxTilesX * 0.65)
																		{
																			this.hitTile = 0;
																		}
																	}
																	else
																	{
																		if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 107 && this.inventory[this.selectedItem].pick < 100)
																		{
																			this.hitTile = 0;
																		}
																		else
																		{
																			if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 108 && this.inventory[this.selectedItem].pick < 110)
																			{
																				this.hitTile = 0;
																			}
																			else
																			{
																				if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 111 && this.inventory[this.selectedItem].pick < 120)
																				{
																					this.hitTile = 0;
																				}
																				else
																				{
																					if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 221 && this.inventory[this.selectedItem].pick < 100)
																					{
																						this.hitTile = 0;
																					}
																					else
																					{
																						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 222 && this.inventory[this.selectedItem].pick < 110)
																						{
																							this.hitTile = 0;
																						}
																						else
																						{
																							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 223 && this.inventory[this.selectedItem].pick < 120)
																							{
																								this.hitTile = 0;
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
												}
											}
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
								}
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
										int num116 = Player.tileTargetX;
										int num117 = Player.tileTargetY;
										if ((Main.tile[num116, num117].halfBrick() || Main.tile[num116, num117].slope() != 0) && !Main.tileSolidTop[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
										{
											int num118 = 1;
											int slope = 2;
											if (WorldGen.SolidTile(num116 + 1, num117) && !WorldGen.SolidTile(num116 - 1, num117))
											{
												num118 = 2;
												slope = 1;
											}
											if (Main.tile[num116, num117].slope() == 0)
											{
												WorldGen.SlopeTile(num116, num117, num118);
											}
											else
											{
												if ((int)Main.tile[num116, num117].slope() == num118)
												{
													WorldGen.SlopeTile(num116, num117, slope);
												}
												else
												{
													WorldGen.SlopeTile(num116, num117, 0);
												}
											}
											int num119 = (int)Main.tile[num116, num117].slope();
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 14, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)num119, 0);
											}
										}
										else
										{
											WorldGen.PoundTile(num116, num117);
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
					int num120 = Player.tileTargetX;
					int num121 = Player.tileTargetY;
					bool flag9 = true;
					if (Main.tile[num120, num121].wall > 0)
					{
						if (!Main.wallHouse[(int)Main.tile[num120, num121].wall])
						{
							for (int num122 = num120 - 1; num122 < num120 + 2; num122++)
							{
								for (int num123 = num121 - 1; num123 < num121 + 2; num123++)
								{
									if (Main.tile[num122, num123].wall != Main.tile[num120, num121].wall)
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
					if (flag9 && !Main.tile[num120, num121].active())
					{
						int num124 = -1;
						if ((double)(((float)Main.mouseX + Main.screenPosition.X) / 16f) < Math.Round((double)(((float)Main.mouseX + Main.screenPosition.X) / 16f)))
						{
							num124 = 0;
						}
						int num125 = -1;
						if ((double)(((float)Main.mouseY + Main.screenPosition.Y) / 16f) < Math.Round((double)(((float)Main.mouseY + Main.screenPosition.Y) / 16f)))
						{
							num125 = 0;
						}
						for (int num126 = Player.tileTargetX + num124; num126 <= Player.tileTargetX + num124 + 1; num126++)
						{
							for (int num127 = Player.tileTargetY + num125; num127 <= Player.tileTargetY + num125 + 1; num127++)
							{
								if (flag9)
								{
									num120 = num126;
									num121 = num127;
									if (Main.tile[num120, num121].wall > 0)
									{
										if (!Main.wallHouse[(int)Main.tile[num120, num121].wall])
										{
											for (int num128 = num120 - 1; num128 < num120 + 2; num128++)
											{
												for (int num129 = num121 - 1; num129 < num121 + 2; num129++)
												{
													if (Main.tile[num128, num129].wall != Main.tile[num120, num121].wall)
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
					if (flag8 && Main.tile[num120, num121].wall > 0 && (!Main.tile[num120, num121].active() || num120 != Player.tileTargetX || num121 != Player.tileTargetY || (!Main.tileHammer[(int)Main.tile[num120, num121].type] && !this.poundRelease)) && this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem && this.inventory[this.selectedItem].hammer > 0)
					{
						bool flag10 = true;
						if (!Main.wallHouse[(int)Main.tile[num120, num121].wall])
						{
							flag10 = false;
							for (int num130 = num120 - 1; num130 < num120 + 2; num130++)
							{
								for (int num131 = num121 - 1; num131 < num121 + 2; num131++)
								{
									if (Main.tile[num130, num131].wall == 0 || Main.wallHouse[(int)Main.tile[num130, num131].wall])
									{
										flag10 = true;
										break;
									}
								}
							}
						}
						if (flag10)
						{
							if (this.hitTileX != num120 || this.hitTileY != num121)
							{
								this.hitTile = 0;
								this.hitTileX = num120;
								this.hitTileY = num121;
							}
							this.hitTile += (int)((float)this.inventory[this.selectedItem].hammer * 1.5f);
							if (this.hitTile >= 100)
							{
								this.hitTile = 0;
								WorldGen.KillWall(num120, num121, false);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 2, (float)num120, (float)num121, 0f, 0);
								}
							}
							else
							{
								WorldGen.KillWall(num120, num121, true);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 2, (float)num120, (float)num121, 1f, 0);
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
					else
					{
						if ((double)this.itemAnimation >= (double)this.itemAnimationMax * 0.666)
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
				}
				else
				{
					if (this.inventory[this.selectedItem].useStyle == 3)
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
				}
				float arg_85AA_0 = this.gravDir;
				if (this.inventory[this.selectedItem].type == 1450 && Main.rand.Next(3) == 0)
				{
					int num132 = -1;
					float x3 = (float)(rectangle.X + Main.rand.Next(rectangle.Width));
					float y3 = (float)(rectangle.Y + Main.rand.Next(rectangle.Height));
					if (Main.rand.Next(500) == 0)
					{
						num132 = Gore.NewGore(new Vector2(x3, y3), default(Vector2), 415, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else
					{
						if (Main.rand.Next(250) == 0)
						{
							num132 = Gore.NewGore(new Vector2(x3, y3), default(Vector2), 414, (float)Main.rand.Next(51, 101) * 0.01f);
						}
						else
						{
							if (Main.rand.Next(80) == 0)
							{
								num132 = Gore.NewGore(new Vector2(x3, y3), default(Vector2), 413, (float)Main.rand.Next(51, 101) * 0.01f);
							}
							else
							{
								if (Main.rand.Next(10) == 0)
								{
									num132 = Gore.NewGore(new Vector2(x3, y3), default(Vector2), 412, (float)Main.rand.Next(51, 101) * 0.01f);
								}
								else
								{
									if (Main.rand.Next(3) == 0)
									{
										num132 = Gore.NewGore(new Vector2(x3, y3), default(Vector2), 411, (float)Main.rand.Next(51, 101) * 0.01f);
									}
								}
							}
						}
					}
					if (num132 >= 0)
					{
						Gore expr_8784_cp_0 = Main.gore[num132];
						expr_8784_cp_0.velocity.X = expr_8784_cp_0.velocity.X + (float)(this.direction * 2);
						Gore expr_87A6_cp_0 = Main.gore[num132];
						expr_87A6_cp_0.velocity.Y = expr_87A6_cp_0.velocity.Y * 0.3f;
					}
				}
				if (!flag11)
				{
					if (this.inventory[this.selectedItem].type == 989 && Main.rand.Next(5) == 0)
					{
						int num133 = Main.rand.Next(3);
						if (num133 == 0)
						{
							num133 = 15;
						}
						else
						{
							if (num133 == 1)
							{
								num133 = 57;
							}
							else
							{
								num133 = 58;
							}
						}
						int num134 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, num133, (float)(this.direction * 2), 0f, 150, default(Color), 1.3f);
						Main.dust[num134].velocity *= 0.2f;
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
						int num135 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 27, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.2f);
						Main.dust[num135].noGravity = true;
						Dust expr_8A57_cp_0 = Main.dust[num135];
						expr_8A57_cp_0.velocity.X = expr_8A57_cp_0.velocity.X / 2f;
						Dust expr_8A75_cp_0 = Main.dust[num135];
						expr_8A75_cp_0.velocity.Y = expr_8A75_cp_0.velocity.Y / 2f;
					}
					if (this.inventory[this.selectedItem].type == 678)
					{
						int num136 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 71, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.2f);
						Main.dust[num136].velocity *= 1.5f;
						Main.dust[num136].noGravity = true;
					}
					if (this.inventory[this.selectedItem].type == 723 && Main.rand.Next(2) == 0)
					{
						int num137 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 64, 0f, 0f, 150, default(Color), 1.2f);
						Main.dust[num137].noGravity = true;
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
						int num138 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 40, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 0, default(Color), 1.2f);
						Main.dust[num138].noGravity = true;
					}
					if (this.inventory[this.selectedItem].type == 121)
					{
						for (int num139 = 0; num139 < 2; num139++)
						{
							int num140 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
							Main.dust[num140].noGravity = true;
							Dust expr_8DB5_cp_0 = Main.dust[num140];
							expr_8DB5_cp_0.velocity.X = expr_8DB5_cp_0.velocity.X * 2f;
							Dust expr_8DD3_cp_0 = Main.dust[num140];
							expr_8DD3_cp_0.velocity.Y = expr_8DD3_cp_0.velocity.Y * 2f;
						}
					}
					if (this.inventory[this.selectedItem].type == 122 || this.inventory[this.selectedItem].type == 217)
					{
						int num141 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.9f);
						Main.dust[num141].noGravity = true;
					}
					if (this.inventory[this.selectedItem].type == 155)
					{
						int num142 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 172, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 0.9f);
						Main.dust[num142].noGravity = true;
						Main.dust[num142].velocity *= 0.1f;
					}
					if ((this.inventory[this.selectedItem].type == 676 || this.inventory[this.selectedItem].type == 673) && Main.rand.Next(3) == 0)
					{
						int num143 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 67, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 90, default(Color), 1.5f);
						Main.dust[num143].noGravity = true;
						Main.dust[num143].velocity *= 0.2f;
					}
					if (this.inventory[this.selectedItem].type == 724 && Main.rand.Next(5) == 0)
					{
						int num144 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 67, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 90, default(Color), 1.5f);
						Main.dust[num144].noGravity = true;
						Main.dust[num144].velocity *= 0.2f;
					}
					if (this.inventory[this.selectedItem].type >= 795 && this.inventory[this.selectedItem].type <= 802 && Main.rand.Next(3) == 0)
					{
						int num145 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 115, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 140, default(Color), 1.5f);
						Main.dust[num145].noGravity = true;
						Main.dust[num145].velocity *= 0.25f;
					}
					if (this.inventory[this.selectedItem].type == 367 || this.inventory[this.selectedItem].type == 368 || this.inventory[this.selectedItem].type == 674)
					{
						if (Main.rand.Next(3) == 0)
						{
							int num146 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.1f);
							Main.dust[num146].noGravity = true;
							Dust expr_92A7_cp_0 = Main.dust[num146];
							expr_92A7_cp_0.velocity.X = expr_92A7_cp_0.velocity.X / 2f;
							Dust expr_92C5_cp_0 = Main.dust[num146];
							expr_92C5_cp_0.velocity.Y = expr_92C5_cp_0.velocity.Y / 2f;
							Dust expr_92E3_cp_0 = Main.dust[num146];
							expr_92E3_cp_0.velocity.X = expr_92E3_cp_0.velocity.X + (float)(this.direction * 2);
						}
						if (Main.rand.Next(4) == 0)
						{
							int num146 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 43, 0f, 0f, 254, default(Color), 0.3f);
							Main.dust[num146].velocity *= 0f;
						}
					}
					if (this.inventory[this.selectedItem].type >= 198 && this.inventory[this.selectedItem].type <= 203)
					{
						float num147 = 0.5f;
						float num148 = 0.5f;
						float num149 = 0.5f;
						if (this.inventory[this.selectedItem].type == 198)
						{
							num147 *= 0.1f;
							num148 *= 0.5f;
							num149 *= 1.2f;
						}
						else
						{
							if (this.inventory[this.selectedItem].type == 199)
							{
								num147 *= 1f;
								num148 *= 0.2f;
								num149 *= 0.1f;
							}
							else
							{
								if (this.inventory[this.selectedItem].type == 200)
								{
									num147 *= 0.1f;
									num148 *= 1f;
									num149 *= 0.2f;
								}
								else
								{
									if (this.inventory[this.selectedItem].type == 201)
									{
										num147 *= 0.8f;
										num148 *= 0.1f;
										num149 *= 1f;
									}
									else
									{
										if (this.inventory[this.selectedItem].type == 202)
										{
											num147 *= 0.8f;
											num148 *= 0.9f;
											num149 *= 1f;
										}
										else
										{
											if (this.inventory[this.selectedItem].type == 203)
											{
												num147 *= 0.9f;
												num148 *= 0.9f;
												num149 *= 0.1f;
											}
										}
									}
								}
							}
						}
						Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), num147, num148, num149);
					}
					if (this.frostBurn && this.inventory[this.selectedItem].melee && !this.inventory[this.selectedItem].noMelee && !this.inventory[this.selectedItem].noUseGraphic && Main.rand.Next(2) == 0)
					{
						int num150 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 135, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
						Main.dust[num150].noGravity = true;
						Main.dust[num150].velocity *= 0.7f;
						Dust expr_9661_cp_0 = Main.dust[num150];
						expr_9661_cp_0.velocity.Y = expr_9661_cp_0.velocity.Y - 0.5f;
					}
					if (this.inventory[this.selectedItem].melee && !this.inventory[this.selectedItem].noMelee && !this.inventory[this.selectedItem].noUseGraphic && this.meleeEnchant > 0)
					{
						if (this.meleeEnchant == 1)
						{
							if (Main.rand.Next(3) == 0)
							{
								int num151 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 171, 0f, 0f, 100, default(Color), 1f);
								Main.dust[num151].noGravity = true;
								Main.dust[num151].fadeIn = 1.5f;
								Main.dust[num151].velocity *= 0.25f;
							}
						}
						else
						{
							if (this.meleeEnchant == 2)
							{
								if (Main.rand.Next(2) == 0)
								{
									int num152 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 75, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
									Main.dust[num152].noGravity = true;
									Main.dust[num152].velocity *= 0.7f;
									Dust expr_9828_cp_0 = Main.dust[num152];
									expr_9828_cp_0.velocity.Y = expr_9828_cp_0.velocity.Y - 0.5f;
								}
							}
							else
							{
								if (this.meleeEnchant == 3)
								{
									if (Main.rand.Next(2) == 0)
									{
										int num153 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
										Main.dust[num153].noGravity = true;
										Main.dust[num153].velocity *= 0.7f;
										Dust expr_98FA_cp_0 = Main.dust[num153];
										expr_98FA_cp_0.velocity.Y = expr_98FA_cp_0.velocity.Y - 0.5f;
									}
								}
								else
								{
									if (this.meleeEnchant == 4)
									{
										if (Main.rand.Next(2) == 0)
										{
											int num154 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 57, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 1.1f);
											Main.dust[num154].noGravity = true;
											Dust expr_99B3_cp_0 = Main.dust[num154];
											expr_99B3_cp_0.velocity.X = expr_99B3_cp_0.velocity.X / 2f;
											Dust expr_99D1_cp_0 = Main.dust[num154];
											expr_99D1_cp_0.velocity.Y = expr_99D1_cp_0.velocity.Y / 2f;
										}
									}
									else
									{
										if (this.meleeEnchant == 5)
										{
											if (Main.rand.Next(2) == 0)
											{
												int num155 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 169, 0f, 0f, 100, default(Color), 1f);
												Dust expr_9A5A_cp_0 = Main.dust[num155];
												expr_9A5A_cp_0.velocity.X = expr_9A5A_cp_0.velocity.X + (float)this.direction;
												Dust expr_9A7A_cp_0 = Main.dust[num155];
												expr_9A7A_cp_0.velocity.Y = expr_9A7A_cp_0.velocity.Y + 0.2f;
												Main.dust[num155].noGravity = true;
											}
										}
										else
										{
											if (this.meleeEnchant == 6)
											{
												if (Main.rand.Next(2) == 0)
												{
													int num156 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 135, 0f, 0f, 100, default(Color), 1f);
													Dust expr_9B11_cp_0 = Main.dust[num156];
													expr_9B11_cp_0.velocity.X = expr_9B11_cp_0.velocity.X + (float)this.direction;
													Dust expr_9B31_cp_0 = Main.dust[num156];
													expr_9B31_cp_0.velocity.Y = expr_9B31_cp_0.velocity.Y + 0.2f;
													Main.dust[num156].noGravity = true;
												}
											}
											else
											{
												if (this.meleeEnchant == 7)
												{
													if (Main.rand.Next(20) == 0)
													{
														int type3 = Main.rand.Next(139, 143);
														int num157 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, type3, this.velocity.X, this.velocity.Y, 0, default(Color), 1.2f);
														Dust expr_9BE7_cp_0 = Main.dust[num157];
														expr_9BE7_cp_0.velocity.X = expr_9BE7_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
														Dust expr_9C1B_cp_0 = Main.dust[num157];
														expr_9C1B_cp_0.velocity.Y = expr_9C1B_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
														Dust expr_9C4F_cp_0 = Main.dust[num157];
														expr_9C4F_cp_0.velocity.X = expr_9C4F_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
														Dust expr_9C7D_cp_0 = Main.dust[num157];
														expr_9C7D_cp_0.velocity.Y = expr_9C7D_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
														Main.dust[num157].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
													}
													if (Main.rand.Next(40) == 0)
													{
														int type4 = Main.rand.Next(276, 283);
														int num158 = Gore.NewGore(new Vector2((float)rectangle.X, (float)rectangle.Y), this.velocity, type4, 1f);
														Gore expr_9D2A_cp_0 = Main.gore[num158];
														expr_9D2A_cp_0.velocity.X = expr_9D2A_cp_0.velocity.X * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
														Gore expr_9D5E_cp_0 = Main.gore[num158];
														expr_9D5E_cp_0.velocity.Y = expr_9D5E_cp_0.velocity.Y * (1f + (float)Main.rand.Next(-50, 51) * 0.01f);
														Main.gore[num158].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
														Gore expr_9DC1_cp_0 = Main.gore[num158];
														expr_9DC1_cp_0.velocity.X = expr_9DC1_cp_0.velocity.X + (float)Main.rand.Next(-50, 51) * 0.05f;
														Gore expr_9DEF_cp_0 = Main.gore[num158];
														expr_9DEF_cp_0.velocity.Y = expr_9DEF_cp_0.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.05f;
													}
												}
												else
												{
													if (this.meleeEnchant == 8 && Main.rand.Next(4) == 0)
													{
														int num159 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 46, 0f, 0f, 100, default(Color), 1f);
														Main.dust[num159].noGravity = true;
														Main.dust[num159].fadeIn = 1.5f;
														Main.dust[num159].velocity *= 0.25f;
													}
												}
											}
										}
									}
								}
							}
						}
					}
					if (this.magmaStone)
					{
						int num160 = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, 6, this.velocity.X * 0.2f + (float)(this.direction * 3), this.velocity.Y * 0.2f, 100, default(Color), 2.5f);
						Main.dust[num160].noGravity = true;
						Dust expr_9F43_cp_0 = Main.dust[num160];
						expr_9F43_cp_0.velocity.X = expr_9F43_cp_0.velocity.X * 2f;
						Dust expr_9F61_cp_0 = Main.dust[num160];
						expr_9F61_cp_0.velocity.Y = expr_9F61_cp_0.velocity.Y * 2f;
					}
					if (Main.myPlayer == i && this.inventory[this.selectedItem].type != 1450)
					{
						int num161 = (int)((float)this.inventory[this.selectedItem].damage * this.meleeDamage);
						float num162 = this.inventory[this.selectedItem].knockBack;
						if (this.kbGlove)
						{
							num162 *= 2f;
						}
						int num163 = rectangle.X / 16;
						int num164 = (rectangle.X + rectangle.Width) / 16 + 1;
						int num165 = rectangle.Y / 16;
						int num166 = (rectangle.Y + rectangle.Height) / 16 + 1;
						for (int num167 = num163; num167 < num164; num167++)
						{
							for (int num168 = num165; num168 < num166; num168++)
							{
								if (Main.tile[num167, num168] != null && Main.tileCut[(int)Main.tile[num167, num168].type] && Main.tile[num167, num168 + 1] != null && Main.tile[num167, num168 + 1].type != 78)
								{
									WorldGen.KillTile(num167, num168, false, false, false);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 0, (float)num167, (float)num168, 0f, 0);
									}
								}
							}
						}
						for (int num169 = 0; num169 < 200; num169++)
						{
							if (Main.npc[num169].active && Main.npc[num169].immune[i] == 0 && this.attackCD == 0 && !Main.npc[num169].dontTakeDamage && (!Main.npc[num169].friendly || (Main.npc[num169].type == 22 && this.killGuide)))
							{
								Rectangle value = new Rectangle((int)Main.npc[num169].position.X, (int)Main.npc[num169].position.Y, Main.npc[num169].width, Main.npc[num169].height);
								if (rectangle.Intersects(value) && (Main.npc[num169].noTileCollide || Collision.CanHit(this.position, this.width, this.height, Main.npc[num169].position, Main.npc[num169].width, Main.npc[num169].height)))
								{
									bool flag12 = false;
									if (Main.rand.Next(1, 101) <= this.meleeCrit)
									{
										flag12 = true;
									}
									int num170 = Main.DamageVar((float)num161);
									this.StatusNPC(this.inventory[this.selectedItem].type, num169);
									this.onHit(Main.npc[num169].center().X, Main.npc[num169].center().Y);
									Main.npc[num169].StrikeNPC(num170, num162, this.direction, flag12, false);
									if (this.meleeEnchant == 7)
									{
										Projectile.NewProjectile(Main.npc[num169].center().X, Main.npc[num169].center().Y, Main.npc[num169].velocity.X, Main.npc[num169].velocity.Y, 289, 0, 0f, this.whoAmi, 0f, 0f);
									}
									if (this.inventory[this.selectedItem].type == 1123)
									{
										int num171 = Main.rand.Next(1, 4);
										for (int num172 = 0; num172 < num171; num172++)
										{
											float num173 = (float)(this.direction * 2) + (float)Main.rand.Next(-35, 36) * 0.02f;
											float num174 = (float)Main.rand.Next(-35, 36) * 0.02f;
											num173 *= 0.2f;
											num174 *= 0.2f;
											Projectile.NewProjectile((float)(rectangle.X + rectangle.Width / 2), (float)(rectangle.Y + rectangle.Height / 2), num173, num174, 181, num170 / 3, 0f, i, 0f, 0f);
										}
									}
									if (this.coins && Main.rand.Next(5) == 0)
									{
										int type5 = 71;
										if (Main.rand.Next(10) == 0)
										{
											type5 = 72;
										}
										if (Main.rand.Next(100) == 0)
										{
											type5 = 73;
										}
										int num175 = Item.NewItem((int)Main.npc[num169].position.X, (int)Main.npc[num169].position.Y, Main.npc[num169].width, Main.npc[num169].height, type5, 1, false, 0, false);
										Main.item[num175].stack = Main.rand.Next(1, 11);
										Main.item[num175].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
										Main.item[num175].velocity.X = (float)Main.rand.Next(10, 31) * 0.2f * (float)this.direction;
										if (Main.netMode == 1)
										{
											NetMessage.SendData(21, -1, -1, "", num175, 0f, 0f, 0f, 0);
										}
									}
									if (Main.netMode != 0)
									{
										if (flag12)
										{
											NetMessage.SendData(28, -1, -1, "", num169, (float)num170, num162, (float)this.direction, 1);
										}
										else
										{
											NetMessage.SendData(28, -1, -1, "", num169, (float)num170, num162, (float)this.direction, 0);
										}
									}
									Main.npc[num169].immune[i] = this.itemAnimation;
									this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
								}
							}
						}
						if (this.hostile)
						{
							for (int num176 = 0; num176 < 255; num176++)
							{
								if (num176 != i && Main.player[num176].active && Main.player[num176].hostile && !Main.player[num176].immune && !Main.player[num176].dead && (Main.player[i].team == 0 || Main.player[i].team != Main.player[num176].team))
								{
									Rectangle value2 = new Rectangle((int)Main.player[num176].position.X, (int)Main.player[num176].position.Y, Main.player[num176].width, Main.player[num176].height);
									if (rectangle.Intersects(value2) && Collision.CanHit(this.position, this.width, this.height, Main.player[num176].position, Main.player[num176].width, Main.player[num176].height))
									{
										bool flag13 = false;
										if (Main.rand.Next(1, 101) <= 10)
										{
											flag13 = true;
										}
										int num177 = Main.DamageVar((float)num161);
										this.StatusPvP(this.inventory[this.selectedItem].type, num176);
										this.onHit(Main.player[num176].center().X, Main.player[num176].center().Y);
										Main.player[num176].Hurt(num177, this.direction, true, false, "", flag13);
										if (this.meleeEnchant == 7)
										{
											Projectile.NewProjectile(Main.player[num176].center().X, Main.player[num176].center().Y, Main.player[num176].velocity.X, Main.player[num176].velocity.Y, 289, 0, 0f, this.whoAmi, 0f, 0f);
										}
										if (this.inventory[this.selectedItem].type == 1123)
										{
											int num178 = Main.rand.Next(1, 4);
											for (int num179 = 0; num179 < num178; num179++)
											{
												float num180 = (float)(this.direction * 2) + (float)Main.rand.Next(-35, 36) * 0.02f;
												float num181 = (float)Main.rand.Next(-35, 36) * 0.02f;
												num180 *= 0.2f;
												num181 *= 0.2f;
												Projectile.NewProjectile((float)(rectangle.X + rectangle.Width / 2), (float)(rectangle.Y + rectangle.Height / 2), num180, num181, 181, num177 / 3, 0f, i, 0f, 0f);
											}
										}
										if (Main.netMode != 0)
										{
											if (flag13)
											{
												NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.whoAmi, -1, -1, -1), num176, (float)this.direction, (float)num177, 1f, 1);
											}
											else
											{
												NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.whoAmi, -1, -1, -1), num176, (float)this.direction, (float)num177, 1f, 0);
											}
										}
										this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
									}
								}
							}
						}
						if (this.inventory[this.selectedItem].type == 787 && (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.5) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9)))
						{
							float num182 = 0f;
							float num183 = 0f;
							float num184 = 0f;
							float num185 = 0f;
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9))
							{
								num182 = -7f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
							{
								num182 = -6f;
								num183 = 2f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.5))
							{
								num182 = -4f;
								num183 = 4f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3))
							{
								num182 = -2f;
								num183 = 6f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1))
							{
								num183 = 7f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
							{
								num185 = 26f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3))
							{
								num185 -= 4f;
								num184 -= 20f;
							}
							if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1))
							{
								num184 += 6f;
							}
							if (this.direction == -1)
							{
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9))
								{
									num185 -= 8f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
								{
									num185 -= 6f;
								}
							}
							num182 *= 1.5f;
							num183 *= 1.5f;
							num185 *= (float)this.direction;
							num184 *= this.gravDir;
							Projectile.NewProjectile((float)(rectangle.X + rectangle.Width / 2) + num185, (float)(rectangle.Y + rectangle.Height / 2) + num184, (float)this.direction * num183, num182 * this.gravDir, 131, num161 / 2, 0f, i, 0f, 0f);
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
				if (this.itemTime == 0 && this.itemAnimation > 0 && (this.inventory[this.selectedItem].type == 43 || this.inventory[this.selectedItem].type == 70 || this.inventory[this.selectedItem].type == 544 || this.inventory[this.selectedItem].type == 556 || this.inventory[this.selectedItem].type == 557 || this.inventory[this.selectedItem].type == 560 || this.inventory[this.selectedItem].type == 1133 || this.inventory[this.selectedItem].type == 1331))
				{
					bool flag14 = false;
					for (int num186 = 0; num186 < 200; num186++)
					{
						if (Main.npc[num186].active && ((this.inventory[this.selectedItem].type == 43 && Main.npc[num186].type == 4) || (this.inventory[this.selectedItem].type == 70 && Main.npc[num186].type == 13) || ((this.inventory[this.selectedItem].type == 560 & Main.npc[num186].type == 50) || (this.inventory[this.selectedItem].type == 544 && Main.npc[num186].type == 125)) || (this.inventory[this.selectedItem].type == 544 && Main.npc[num186].type == 126) || (this.inventory[this.selectedItem].type == 556 && Main.npc[num186].type == 134) || (this.inventory[this.selectedItem].type == 557 && Main.npc[num186].type == 128) || (this.inventory[this.selectedItem].type == 1133 && Main.npc[num186].type == 222) || (this.inventory[this.selectedItem].type == 1331 && Main.npc[num186].type == 266)))
						{
							flag14 = true;
							break;
						}
					}
					if (flag14)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
					}
					else
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
						else
						{
							if (this.inventory[this.selectedItem].type == 43)
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
							else
							{
								if (this.inventory[this.selectedItem].type == 70)
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
								else
								{
									if (this.inventory[this.selectedItem].type == 544)
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
									else
									{
										if (this.inventory[this.selectedItem].type == 556)
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
										else
										{
											if (this.inventory[this.selectedItem].type == 557)
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
											else
											{
												if (this.inventory[this.selectedItem].type == 1133)
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
												else
												{
													if (this.inventory[this.selectedItem].type == 1331 && this.zoneBlood)
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
										}
									}
								}
							}
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
				else
				{
					if (this.itemTime == this.inventory[this.selectedItem].useTime / 2)
					{
						for (int num187 = 0; num187 < 70; num187++)
						{
							Dust.NewDust(this.position, this.width, this.height, 15, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, default(Color), 1.5f);
						}
						this.grappling[0] = -1;
						this.grapCount = 0;
						for (int num188 = 0; num188 < 1000; num188++)
						{
							if (Main.projectile[num188].active && Main.projectile[num188].owner == i && Main.projectile[num188].aiStyle == 7)
							{
								Main.projectile[num188].Kill();
							}
						}
						this.Spawn();
						for (int num189 = 0; num189 < 70; num189++)
						{
							Dust.NewDust(this.position, this.width, this.height, 15, 0f, 0f, 150, default(Color), 1.5f);
						}
					}
				}
			}
			if (i == Main.myPlayer)
			{
				if (this.itemTime == this.inventory[this.selectedItem].useTime && this.inventory[this.selectedItem].tileWand > 0)
				{
					int tileWand2 = this.inventory[this.selectedItem].tileWand;
					int num190 = 0;
					while (num190 < 58)
					{
						if (tileWand2 == this.inventory[num190].type && this.inventory[num190].stack > 0)
						{
							this.inventory[num190].stack--;
							if (this.inventory[num190].stack <= 0)
							{
								this.inventory[num190] = new Item();
								break;
							}
							break;
						}
						else
						{
							num190++;
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
					if (i == 48)
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
				if (Main.mapEnabled)
				{
					Map.saveMap();
				}
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
										if (num2 >= 1615)
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
										if (num3 >= 1615)
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
				if (this.inventory[i].shoot == 13 || this.inventory[i].shoot == 32 || this.inventory[i].shoot == 73 || this.inventory[i].shoot == 165 || (this.inventory[i].shoot >= 230 && this.inventory[i].shoot <= 235) || this.inventory[i].shoot == 256)
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
			else
			{
				if (this.inventory[num].shoot == 165)
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
				else
				{
					if (num >= 0)
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
				if (num4 == 13 || num4 == 32 || (num4 >= 230 && num4 <= 235))
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
			for (int l = 0; l < 251; l++)
			{
				this.adjTile[l] = false;
				this.oldAdjTile[l] = false;
			}
		}
	}
}
