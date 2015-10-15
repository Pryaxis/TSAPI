
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Terraria.Achievements;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Tile_Entities;
using Terraria.ID;
using Terraria.IO;
//using Terraria.Map;
using Terraria.ObjectData;
using Terraria.Utilities;
using Terraria.World.Generation;

namespace Terraria
{
	public class Player : Entity
	{
		public const int maxSolarShields = 3;

		public const int nebulaMaxLevel = 3;

		public const int SupportedSlotsArmor = 3;

		public const int SupportedSlotsAccs = 7;

		public const int SupportedSlotSets = 10;

		public const int InitialAccSlotCount = 5;

		public const int miscSlotPet = 0;

		public const int miscSlotLight = 1;

		public const int miscSlotCart = 2;

		public const int miscSlotMount = 3;

		public const int miscSlotHook = 4;

		public const int maxBuffs = 22;

		public const int defaultWidth = 20;

		public const int defaultHeight = 42;

		private const int shadowMax = 3;

		private static byte[] ENCRYPTION_KEY;

		public Player.OverheadMessage chatOverhead = new Player.OverheadMessage();

		public bool alchemyTable;

		private bool GoingDownWithGrapple;

		private byte spelunkerTimer;

		public bool[] hideInfo = new bool[13];

		public int lostCoins;

		public string lostCoinString = "";

		public int soulDrain;

		public float drainBoost;

		public int taxMoney;

		public int taxTimer;

		public static int taxRate;

		public static int crystalLeafDamage;

		public static int crystalLeafKB;

		public bool[] NPCBannerBuff = new bool[251];

		public bool hasBanner;

		public Vector2 lastDeathPostion;

		public DateTime lastDeathTime;

		public bool showLastDeath;

		public int extraAccessorySlots = 2;

		public bool extraAccessory;

		public int tankPet = -1;

		public bool tankPetReset;

		public int stringColor;

		public int counterWeight;

		public bool yoyoString;

		public bool yoyoGlove;

		public int beetleOrbs;

		public float beetleCounter;

		public int beetleCountdown;

		public bool beetleDefense;

		public bool beetleOffense;

		public bool beetleBuff;

		public int solarShields;

		public int solarCounter;

		public Vector2[] solarShieldPos = new Vector2[3];

		public Vector2[] solarShieldVel = new Vector2[3];

		public bool solarDashing;

		public bool solarDashConsumedFlare;

		public int nebulaLevelLife;

		public int nebulaLevelMana;

		public int nebulaManaCounter;

		public int nebulaLevelDamage;

		public bool manaMagnet;

		public bool lifeMagnet;

		public bool lifeForce;

		public bool calmed;

		public bool inferno;

		public float flameRingRot;

		public float flameRingScale = 1f;

		public byte flameRingFrame;

		public byte flameRingAlpha;

		public int netManaTime;

		public int netLifeTime;

		public bool netMana;

		public bool netLife;

		public Vector2[] beetlePos = new Vector2[3];

		public Vector2[] beetleVel = new Vector2[3];

		public int beetleFrame;

		public int beetleFrameCounter;

		public static int manaSickTime;

		public static int manaSickTimeMax;

		public static float manaSickLessDmg;

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

		public bool dazed;

		public bool frozen;

		public bool stoned;

		public bool lastStoned;

		public bool ichor;

		public bool webbed;

		public int ropeCount;

		public int manaRegenBonus;

		public int manaRegenDelayBonus;

		public int dash;

		public int dashTime;

		public int dashDelay;

		public int eocDash;

		public int eocHit;

		public float accRunSpeed;

		public bool cordage;

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

		public int infernoCounter;

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

		public bool dangerSense;

		public float endurance;

		public bool loveStruck;

		public bool stinky;

		public bool resistCold;

		public bool electrified;

		public bool dryadWard;

		public bool panic;

		public bool brainOfConfusion;

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

		public int fishingSkill;

		public bool cratePotion;

		public bool sonarPotion;

		public bool accFishingLine;

		public bool accTackleBox;

		public int maxMinions = 1;

		public int numMinions;

		public float slotsMinions;

		public bool pygmy;

		public bool raven;

		public bool slime;

		public bool hornetMinion;

		public bool impMinion;

		public bool twinsMinion;

		public bool spiderMinion;

		public bool pirateMinion;

		public bool sharknadoMinion;

		public bool UFOMinion;

		public bool DeadlySphereMinion;

		public bool stardustMinion;

		public bool stardustGuardian;

		public bool stardustDragon;

		public float wingTime;

		public int wings;

		public int wingsLogic;

		public int wingTimeMax;

		public int wingFrame;

		public int wingFrameCounter;

		public int skinVariant;

		public bool ghost;

		public int ghostFrame;

		public int ghostFrameCounter;

		public int miscTimer;

		public bool pvpDeath;

		public BitsByte zone1 = 0;

		public BitsByte zone2 = 0;

		public bool boneArmor;

		public bool frostArmor;

		public bool honey;

		public bool crystalLeaf;

		public int[] doubleTapCardinalTimer = new int[4];

		public int[] holdDownCardinalTimer = new int[4];

		public bool paladinBuff;

		public bool paladinGive;

		public float[] speedSlice = new float[60];

		public float townNPCs;

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

		public static int nameLen;

		private float maxRegenDelay;

		public int sign = -1;

		public bool editedChestName;

		public int reuseDelay;

		public int aggro;

		public float activeNPCs;

		public bool mouseInterface;

		public bool lastMouseInterface;

		public int noThrow;

		public int changeItem = -1;

		public int selectedItem;

		public Item[] armor = new Item[20];

		public Item[] dye = new Item[10];

		public Item[] miscEquips = new Item[5];

		public Item[] miscDyes = new Item[5];

		public Item trashItem = new Item();

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

		public bool[] buffImmune = new bool[BuffID.Count];

		public int heldProj = -1;

		public int breathCD;

		public int breathMax = 200;

		public int breath = 200;

		public int lavaCD;

		public int lavaMax;

		public int lavaTime;

		public bool ignoreWater;

		public bool socialShadow;

		public bool socialGhost;

		public bool shroomiteStealth;

		public int stealthTimer;

		public float stealth = 1f;

		public string setBonus = "";

		public Item[] inventory = new Item[59];

		public bool[] inventoryChestStack = new bool[59];

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

		public float fullRotation;

		public Vector2 fullRotationOrigin = Vector2.Zero;

		public int nonTorch = -1;

		public float gfxOffY;

		public float stepSpeed = 1f;

		public static bool deadForGood;

		public bool dead;

		public int respawnTimer;

		public int attackCD;

		public int potionDelay;

		public byte difficulty;

		public byte wetSlime;

		public HitTile hitTile;

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

		public bool[] hideVisual = new bool[10];

		public BitsByte hideMisc = 0;

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

		public bool controlSmart;

		public bool controlMount;

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

		public bool releaseSmart;

		public bool releaseMount;

		public bool releaseDown;

		public int altFunctionUse;

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

		public bool showItemIcon;

		public bool showItemIconR;

		public int showItemIcon2;

		public string showItemIconText = "";

		public int runSoundDelay;

		public float shadow;

		public Vector2[] shadowPos = new Vector2[3];

		public float[] shadowRotation = new float[3];

		public Vector2[] shadowOrigin = new Vector2[3];

		public int[] shadowDirection = new int[3];

		public int shadowCount;

		public float manaCost = 1f;

		public bool fireWalk;

		public bool channel;

		public int step = -1;

		public int anglerQuestsFinished;

		public int armorPenetration;

		public int statDefense;

		public int statLifeMax = 100;

		public int statLifeMax2 = 100;

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

		public int phantasmTime;

		public bool ammoBox;

		public bool ammoPotion;

		public bool chaosState;

		public bool strongBees;

		public bool sporeSac;

		public bool shinyStone;

		public int yoraiz0rEye;

		public bool yoraiz0rDarkness;

		public bool suspiciouslookingTentacle;

		public bool crimsonHeart;

		public bool lightOrb;

		public bool blueFairy;

		public bool redFairy;

		public bool greenFairy;

		public bool bunny;

		public bool turtle;

		public bool eater;

		public bool penguin;

		public bool magicLantern;

		public bool rabid;

		public bool sunflower;

		public bool wellFed;

		public bool puppy;

		public bool grinch;

		public bool miniMinotaur;

		public bool arcticDivingGear;

		public bool wearsRobe;

		public bool minecartLeft;

		public bool onWrongGround;

		public bool onTrack;

		public int cartRampTime;

		public bool cartFlip;

		public float trackBoost;

		public Vector2 lastBoost = Vector2.Zero;

		public Mount mount;

		public bool blackCat;

		public bool spider;

		public bool squashling;

		public bool babyFaceMonster;

		public bool magicCuffs;

		public bool coldDash;

		public bool sailDash;

		public bool eyeSpring;

		public bool snowman;

		public bool scope;

		public bool dino;

		public bool skeletron;

		public bool hornet;

		public bool zephyrfish;

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

		public bool headcovered;

		public bool frostBurn;

		public bool onFrostBurn;

		public bool burned;

		public bool suffocating;

		public byte suffocateDelay;

		public bool dripping;

		public bool drippingSlime;

		public bool onFire;

		public bool onFire2;

		public bool noItems;

		public bool wereWolf;

		public bool wolfAcc;

		public bool hideMerman;

		public bool hideWolf;

		public bool forceMerman;

		public bool forceWerewolf;

		public bool rulerGrid;

		public bool rulerLine;

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

		public bool kbBuff;

		public bool starCloak;

		public bool longInvince;

		public bool pStone;

		public bool manaFlower;

		public bool moonLeech;

		public bool vortexDebuff;

		public bool trapDebuffSource;

		public int meleeCrit = 4;

		public int rangedCrit = 4;

		public int magicCrit = 4;

		public int thrownCrit = 4;

		public float meleeDamage = 1f;

		public float rangedDamage = 1f;

		public float thrownDamage = 1f;

		public float bulletDamage = 1f;

		public float arrowDamage = 1f;

		public float rocketDamage = 1f;

		public float magicDamage = 1f;

		public float minionDamage = 1f;

		public float minionKB;

		public float meleeSpeed = 1f;

		public float thrownVelocity = 1f;

		public bool thrownCost50;

		public bool thrownCost33;

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

		public static int tileRangeX;

		public static int tileRangeY;

		public int lastTileRangeX;

		public int lastTileRangeY;

		public static int tileTargetX;

		public static int tileTargetY;

		public static float defaultGravity;

		private static int jumpHeight;

		private static float jumpSpeed;

		public float gravity = Player.defaultGravity;

		public float maxFallSpeed = 10f;

		public float maxRunSpeed = 3f;

		public float runAcceleration = 0.08f;

		public float runSlowdown = 0.2f;

		public bool adjWater;

		public bool adjHoney;

		public bool adjLava;

		public bool oldAdjWater;

		public bool oldAdjHoney;

		public bool oldAdjLava;

		public bool[] adjTile = new bool[419];

		public bool[] oldAdjTile = new bool[419];

		private static int defaultItemGrabRange;

		private static float itemGrabSpeed;

		private static float itemGrabSpeedMax;

		public byte hairDye;

		public Color hairDyeColor = Color.Transparent;

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

		public bool accFishFinder;

		public bool accWeatherRadio;

		public bool accJarOfSouls;

		public bool accCalendar;

		public int lastCreatureHit = -1;

		public bool accThirdEye;

		public byte accThirdEyeCounter;

		public byte accThirdEyeNumber;

		public bool accStopwatch;

		public bool accOreFinder;

		public int bestOre = -1;

		public bool accCritterGuide;

		public byte accCritterGuideCounter;

		public byte accCritterGuideNumber;

		public bool accDreamCatcher;

		public DateTime dpsStart;

		public DateTime dpsEnd;

		public DateTime dpsLastHit;

		public int dpsDamage;

		public bool dpsStarted;

		public string displayedFishingInfo = "";

		public bool discount;

		public bool coins;

		public bool goldRing;

		public bool accDivingHelm;

		public bool accFlipper;

		public bool doubleJumpCloud;

		public bool jumpAgainCloud;

		public bool dJumpEffectCloud;

		public bool doubleJumpSandstorm;

		public bool jumpAgainSandstorm;

		public bool dJumpEffectSandstorm;

		public bool doubleJumpBlizzard;

		public bool jumpAgainBlizzard;

		public bool dJumpEffectBlizzard;

		public bool doubleJumpFart;

		public bool jumpAgainFart;

		public bool dJumpEffectFart;

		public bool doubleJumpSail;

		public bool jumpAgainSail;

		public bool dJumpEffectSail;

		public bool doubleJumpUnicorn;

		public bool jumpAgainUnicorn;

		public bool dJumpEffectUnicorn;

		public bool autoJump;

		public bool justJumped;

		public float jumpSpeedBoost;

		public int extraFall;

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

		public float thorns;

		public bool turtleArmor;

		public bool turtleThorns;

		public bool spiderArmor;

		public bool setSolar;

		public bool setVortex;

		public bool setNebula;

		public int nebulaCD;

		public bool setStardust;

		public bool vortexStealthActive;

		public bool waterWalk;

		public bool waterWalk2;

		public bool gravControl;

		public bool gravControl2;

		public bool bee;

		public int lastChest;

		public int flyingPigChest = -1;

		public int chest = -1;

		public int chestX;

		public int chestY;

		public int talkNPC = -1;

		public int fallStart;

		public int fallStart2;

		public int potionDelayTime = Item.potionDelay;

		public int restorationDelayTime = Item.restorationDelay;

		private int cHead;

		private int cBody;

		private int cLegs;

		private int cHandOn;

		private int cHandOff;

		private int cBack;

		private int cFront;

		private int cShoe;

		private int cWaist;

		private int cShield;

		private int cNeck;

		private int cFace;

		private int cBalloon;

		private int cWings;

		private int cCarpet;

		public int cGrapple;

		public int cMount;

		public int cMinecart;

		public int cPet;

		public int cLight;

		public int cYorai;

		public int[] ownedProjectileCounts = new int[651];

		public bool[] npcTypeNoAggro = new bool[540];

		public int lastPortalColorIndex;

		public int _portalPhysicsTime;

		public bool justGotOutOfPortal;

		public float MountFishronSpecialCounter;

		public Vector2 MinionTargetPoint = Vector2.Zero;

		public List<Point> TouchedTiles = new List<Point>();

		private bool makeStrongBee;

		public int _funkytownCheckCD;

		public int[] hurtCooldowns;

		public static bool lastPound;

		public bool CCed
		{
			get
			{
				return this.frozen || this.webbed || this.stoned;
			}
		}
		public Vector2 Directions
		{
			get
			{
				return new Vector2((float)this.direction, this.gravDir);
			}
		}

		public bool HasMinionTarget
		{
			get
			{
				return this.MinionTargetPoint != Vector2.Zero;
			}
		}

		public bool Male
		{
			get
			{
				return this.skinVariant < 4;
			}
			set
			{
				if (value)
				{
					if (this.skinVariant >= 4)
					{
						
						this.skinVariant -= 4;
						return;
					}
				}
				else if (this.skinVariant < 4)
				{
					this.skinVariant += 4;
				}
			}
		}

		public Vector2 MountedCenter
		{
			get
			{
				return new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + 21f + (float)this.mount.PlayerOffsetHitbox);
			}
			set
			{
				this.position = new Vector2(value.X - (float)(this.width / 2), value.Y - 21f - (float)this.mount.PlayerOffsetHitbox);
			}
		}

		public bool MountFishronSpecial
		{
			get
			{
				if (this.statLife < this.statLifeMax2 / 2 || this.wet && !this.lavaWet && !this.honeyWet || this.dripping)
				{
					return true;
				}
				return this.MountFishronSpecialCounter > 0f;
			}
		}

		public bool PortalPhysicsEnabled
		{
			get
			{
				if (this._portalPhysicsTime <= 0)
				{
					return false;
				}
				return !this.mount.Active;
			}
		}

		public bool SlimeDontHyperJump
		{
			get
			{
				if (!this.mount.Active || this.mount.Type != 3 || this.wetSlime <= 0)
				{
					return false;
				}
				return !this.controlJump;
			}
		}

		public bool ZoneCorrupt
		{
			get
			{
				return this.zone1[1];
			}
			set
			{
				this.zone1[1] = value;
			}
		}

		public bool ZoneCrimson
		{
			get
			{
				return this.zone1[6];
			}
			set
			{
				this.zone1[6] = value;
			}
		}

		public bool ZoneDesert
		{
			get
			{
				return this.zone2[5];
			}
			set
			{
				this.zone2[5] = value;
			}
		}

		public bool ZoneDungeon
		{
			get
			{
				return this.zone1[0];
			}
			set
			{
				this.zone1[0] = value;
			}
		}

		public bool ZoneGlowshroom
		{
			get
			{
				return this.zone2[6];
			}
			set
			{
				this.zone2[6] = value;
			}
		}

		public bool ZoneHoly
		{
			get
			{
				return this.zone1[2];
			}
			set
			{
				this.zone1[2] = value;
			}
		}

		public bool ZoneJungle
		{
			get
			{
				return this.zone1[4];
			}
			set
			{
				this.zone1[4] = value;
			}
		}

		public bool ZoneMeteor
		{
			get
			{
				return this.zone1[3];
			}
			set
			{
				this.zone1[3] = value;
			}
		}

		public bool ZonePeaceCandle
		{
			get
			{
				return this.zone2[0];
			}
			set
			{
				this.zone2[0] = value;
			}
		}

		public bool ZoneSnow
		{
			get
			{
				return this.zone1[5];
			}
			set
			{
				this.zone1[5] = value;
			}
		}

		public bool ZoneTowerNebula
		{
			get
			{
				return this.zone2[3];
			}
			set
			{
				this.zone2[3] = value;
			}
		}

		public bool ZoneTowerSolar
		{
			get
			{
				return this.zone2[1];
			}
			set
			{
				this.zone2[1] = value;
			}
		}

		public bool ZoneTowerStardust
		{
			get
			{
				return this.zone2[4];
			}
			set
			{
				this.zone2[4] = value;
			}
		}

		public bool ZoneTowerVortex
		{
			get
			{
				return this.zone2[2];
			}
			set
			{
				this.zone2[2] = value;
			}
		}

		public bool ZoneUndergroundDesert
		{
			get
			{
				return this.zone2[7];
			}
			set
			{
				this.zone2[7] = value;
			}
		}

		public bool ZoneWaterCandle
		{
			get
			{
				return this.zone1[7];
			}
			set
			{
				this.zone1[7] = value;
			}
		}

		static Player()
		{
			Player.ENCRYPTION_KEY = (new UnicodeEncoding()).GetBytes("h3y_gUyZ");
			Player.taxRate = 3600;
			Player.crystalLeafDamage = 100;
			Player.crystalLeafKB = 10;
			Player.manaSickTime = 300;
			Player.manaSickTimeMax = 600;
			Player.manaSickLessDmg = 0.25f;
			Player.nameLen = 20;
			Player.deadForGood = false;
			Player.tileRangeX = 5;
			Player.tileRangeY = 4;
			Player.defaultGravity = 0.4f;
			Player.jumpHeight = 15;
			Player.jumpSpeed = 5.01f;
			Player.defaultItemGrabRange = 38;
			Player.itemGrabSpeed = 0.45f;
			Player.itemGrabSpeedMax = 4f;
			Player.lastPound = true;
		}

		public Player()
		{
			int[] array = new int[2];
			this.hurtCooldowns = array;
			this.width = 20;
			this.height = 42;
			this.name = string.Empty;
			for (int i = 0; i < 59; i++)
			{
				if (i < (int)this.armor.Length)
				{
					this.armor[i] = new Item();
					this.armor[i].name = "";
				}
				this.inventory[i] = new Item();
				this.inventory[i].name = "";
			}
			for (int j = 0; j < 40; j++)
			{
				this.bank.item[j] = new Item();
				this.bank.item[j].name = "";
				this.bank2.item[j] = new Item();
				this.bank2.item[j].name = "";
			}
			for (int k = 0; k < (int)this.dye.Length; k++)
			{
				this.dye[k] = new Item();
			}
			for (int l = 0; l < (int)this.miscEquips.Length; l++)
			{
				this.miscEquips[l] = new Item();
			}
			for (int m = 0; m < (int)this.miscDyes.Length; m++)
			{
				this.miscDyes[m] = new Item();
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
			for (int n = 0; n < 419; n++)
			{
				this.adjTile[n] = false;
				this.oldAdjTile[n] = false;
			}
			this.hitTile = new HitTile();
			this.mount = new Mount();
		}

		public void AddBuff(int type, int time1, bool quiet = true)
		{
		}

		public void addDPS(int dmg)
		{
		}

		public void AdjTiles()
		{
			int num = 4;
			int num1 = 3;
			for (int i = 0; i < 419; i++)
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
			this.alchemyTable = false;
			int x = (int)((this.position.X + (float)(this.width / 2)) / 16f);
			int y = (int)((this.position.Y + (float)this.height) / 16f);
			for (int j = x - num; j <= x + num; j++)
			{
				for (int k = y - num1; k < y + num1; k++)
				{
					if (Main.tile[j, k].active())
					{
						this.adjTile[Main.tile[j, k].type] = true;
						if (Main.tile[j, k].type == TileID.GlassKiln)
						{
							this.adjTile[17] = true;
						}
						if (Main.tile[j, k].type == TileID.Hellforge)
						{
							this.adjTile[17] = true;
						}
						if (Main.tile[j, k].type == TileID.AdamantiteForge)
						{
							this.adjTile[17] = true;
							this.adjTile[77] = true;
						}
						if (Main.tile[j, k].type == TileID.MythrilAnvil)
						{
							this.adjTile[16] = true;
						}
						if (Main.tile[j, k].type == TileID.BewitchingTable)
						{
							this.adjTile[14] = true;
						}
						if (Main.tile[j, k].type == TileID.AlchemyTable)
						{
							this.adjTile[13] = true;
							this.adjTile[14] = true;
							this.alchemyTable = true;
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
				int num2 = 0;
				while (num2 < 419)
				{
					if (this.oldAdjTile[num2] == this.adjTile[num2])
					{
						num2++;
					}
					else
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

		private void ApplyAnimation(Item sItem)
		{
			if (sItem.melee)
			{
				this.itemAnimation = (int)((float)sItem.useAnimation * this.meleeSpeed);
				this.itemAnimationMax = (int)((float)sItem.useAnimation * this.meleeSpeed);
				return;
			}
			if (sItem.createTile >= 0)
			{
				this.itemAnimation = (int)((float)sItem.useAnimation * this.tileSpeed);
				this.itemAnimationMax = (int)((float)sItem.useAnimation * this.tileSpeed);
				return;
			}
			if (sItem.createWall < 0)
			{
				this.itemAnimation = sItem.useAnimation;
				this.itemAnimationMax = sItem.useAnimation;
				this.reuseDelay = sItem.reuseDelay;
				return;
			}
			this.itemAnimation = (int)((float)sItem.useAnimation * this.wallSpeed);
			this.itemAnimationMax = (int)((float)sItem.useAnimation * this.wallSpeed);
		}

		public int ArmorSetDye()
		{
			switch (Main.rand.Next(3))
			{
				case 0:
				{
					return this.cHead;
				}
				case 1:
				{
					return this.cBody;
				}
				case 2:
				{
					return this.cLegs;
				}
			}
			return this.cBody;
		}

		public int beeDamage(int dmg)
		{
			if (!this.makeStrongBee)
			{
				return dmg + Main.rand.Next(2);
			}
			return dmg + Main.rand.Next(1, 4);
		}

		public float beeKB(float KB)
		{
			if (!this.makeStrongBee)
			{
				return KB;
			}
			return 0.5f + KB * 1.1f;
		}

		public int beeType()
		{
			if (this.strongBees && Main.rand.Next(2) == 0)
			{
				this.makeStrongBee = true;
				return 566;
			}
			this.makeStrongBee = false;
			return 181;
		}

		public void BordersMovement()
		{
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
				AchievementsHelper.HandleSpecialEvent(this, 11);
			}
			if (this.position.Y > Main.bottomWorld - 640f - 32f - (float)this.height)
			{
				this.position.Y = Main.bottomWorld - 640f - 32f - (float)this.height;
				this.velocity.Y = 0f;
				AchievementsHelper.HandleSpecialEvent(this, 10);
			}
		}

		public bool BuyItem(int price)
		{
			bool flag;
			Item[] itemArray = this.inventory;
			int[] numArray = new int[] { 58, 57, 56, 55, 54 };
			long num = Terraria.Utils.CoinsCount(out flag, itemArray, numArray);
			long num1 = Terraria.Utils.CoinsCount(out flag, this.bank.item, new int[0]);
			long num2 = Terraria.Utils.CoinsCount(out flag, this.bank2.item, new int[0]);
			long[] numArray1 = new long[] { num, num1, num2 };
			if (Terraria.Utils.CoinsCombineStacks(out flag, numArray1) < (long)price)
			{
				return false;
			}
			List<Item[]> itemArrays = new List<Item[]>();
			Dictionary<int, List<int>> nums = new Dictionary<int, List<int>>();
			List<Point> points = new List<Point>();
			List<Point> points1 = new List<Point>();
			List<Point> points2 = new List<Point>();
			List<Point> points3 = new List<Point>();
			itemArrays.Add(this.inventory);
			itemArrays.Add(this.bank.item);
			itemArrays.Add(this.bank2.item);
			for (int i = 0; i < itemArrays.Count; i++)
			{
				nums[i] = new List<int>();
			}
			List<int> nums1 = new List<int>()
			{
				58,
				57,
				56,
				55,
				54
			};
			nums[0] = nums1;
			for (int j = 0; j < itemArrays.Count; j++)
			{
				for (int k = 0; k < (int)itemArrays[j].Length; k++)
				{
					if (!nums[j].Contains(k) && itemArrays[j][k].type >= 71 && itemArrays[j][k].type <= 74)
					{
						points1.Add(new Point(j, k));
					}
				}
			}
			int num3 = 0;
			for (int l = (int)itemArrays[num3].Length - 1; l >= 0; l--)
			{
				if (!nums[num3].Contains(l) && (itemArrays[num3][l].type == 0 || itemArrays[num3][l].stack == 0))
				{
					points.Add(new Point(num3, l));
				}
			}
			num3 = 1;
			for (int m = (int)itemArrays[num3].Length - 1; m >= 0; m--)
			{
				if (!nums[num3].Contains(m) && (itemArrays[num3][m].type == 0 || itemArrays[num3][m].stack == 0))
				{
					points2.Add(new Point(num3, m));
				}
			}
			num3 = 2;
			for (int n = (int)itemArrays[num3].Length - 1; n >= 0; n--)
			{
				if (!nums[num3].Contains(n) && (itemArrays[num3][n].type == 0 || itemArrays[num3][n].stack == 0))
				{
					points3.Add(new Point(num3, n));
				}
			}
			long item = (long)price;
			Dictionary<Point, Item> points4 = new Dictionary<Point, Item>();
			while (item > (long)0)
			{
				long num4 = (long)1000000;
				for (int o = 0; o < 4; o++)
				{
					if (item >= num4)
					{
						foreach (Point point in points1)
						{
							if (itemArrays[point.X][point.Y].type != 74 - o)
							{
								continue;
							}
							long num5 = item / num4;
							points4[point] = itemArrays[point.X][point.Y].Clone();
							if (num5 >= (long)itemArrays[point.X][point.Y].stack)
							{
								itemArrays[point.X][point.Y].SetDefaults(0, false);
								points.Add(point);
							}
							else
							{
								Item item1 = itemArrays[point.X][point.Y];
								item1.stack = item1.stack - (int)num5;
							}
							item = item - num4 * (long)(points4[point].stack - itemArrays[point.X][point.Y].stack);
						}
					}
					num4 = num4 / (long)100;
				}
				if (item <= (long)0)
				{
					continue;
				}
				if (points.Count <= 0)
				{
					foreach (KeyValuePair<Point, Item> keyValuePair in points4)
					{
						itemArrays[keyValuePair.Key.X][keyValuePair.Key.Y] = keyValuePair.Value.Clone();
					}
					return false;
				}
				points.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
				Point point1 = new Point(-1, -1);
				int num6 = 0;
				while (num6 < itemArrays.Count)
				{
					num4 = (long)10000;
					for (int p = 0; p < 3; p++)
					{
						if (item >= num4)
						{
							foreach (Point point2 in points1)
							{
								if (point2.X != num6 || itemArrays[point2.X][point2.Y].type != 74 - p || itemArrays[point2.X][point2.Y].stack < 1)
								{
									continue;
								}
								List<Point> points5 = points;
								if (num6 == 1 && points2.Count > 0)
								{
									points5 = points2;
								}
								if (num6 == 2 && points3.Count > 0)
								{
									points5 = points3;
								}
								Item item2 = itemArrays[point2.X][point2.Y];
								int num7 = item2.stack - 1;
								int num8 = num7;
								item2.stack = num7;
								if (num8 <= 0)
								{
									itemArrays[point2.X][point2.Y].SetDefaults(0, false);
									points5.Add(point2);
								}
								points4[points5[0]] = itemArrays[points5[0].X][points5[0].Y].Clone();
								itemArrays[points5[0].X][points5[0].Y].SetDefaults(73 - p, false);
								itemArrays[points5[0].X][points5[0].Y].stack = 100;
								point1 = points5[0];
								points5.RemoveAt(0);
								break;
							}
						}
						if (point1.X != -1 || point1.Y != -1)
						{
							break;
						}
						num4 = num4 / (long)100;
					}
					for (int q = 0; q < 2; q++)
					{
						if (point1.X == -1 && point1.Y == -1)
						{
							foreach (Point point3 in points1)
							{
								if (point3.X != num6 || itemArrays[point3.X][point3.Y].type != 73 + q || itemArrays[point3.X][point3.Y].stack < 1)
								{
									continue;
								}
								List<Point> points6 = points;
								if (num6 == 1 && points2.Count > 0)
								{
									points6 = points2;
								}
								if (num6 == 2 && points3.Count > 0)
								{
									points6 = points3;
								}
								Item item3 = itemArrays[point3.X][point3.Y];
								int num9 = item3.stack - 1;
								int num10 = num9;
								item3.stack = num9;
								if (num10 <= 0)
								{
									itemArrays[point3.X][point3.Y].SetDefaults(0, false);
									points6.Add(point3);
								}
								points4[points6[0]] = itemArrays[points6[0].X][points6[0].Y].Clone();
								itemArrays[points6[0].X][points6[0].Y].SetDefaults(72 + q, false);
								itemArrays[points6[0].X][points6[0].Y].stack = 100;
								point1 = points6[0];
								points6.RemoveAt(0);
								break;
							}
						}
					}
					if (point1.X == -1 || point1.Y == -1)
					{
						num6++;
					}
					else
					{
						points1.Add(point1);
						break;
					}
				}
				points.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
				points2.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
				points3.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
			}
			return true;
		}

		public bool BuyItemOld(int price)
		{
			if (price == 0)
			{
				return true;
			}
			long num = (long)0;
			int num1 = price;
			Item[] item = new Item[54];
			for (int i = 0; i < 54; i++)
			{
				item[i] = new Item();
				item[i] = this.inventory[i].Clone();
				if (this.inventory[i].type == 71)
				{
					num = num + (long)this.inventory[i].stack;
				}
				if (this.inventory[i].type == 72)
				{
					num = num + (long)(this.inventory[i].stack * 100);
				}
				if (this.inventory[i].type == 73)
				{
					num = num + (long)(this.inventory[i].stack * 10000);
				}
				if (this.inventory[i].type == 74)
				{
					num = num + (long)(this.inventory[i].stack * 1000000);
				}
			}
			if (num < (long)price)
			{
				return false;
			}
			num1 = price;
		Label0:
			while (num1 > 0)
			{
				if (num1 >= 1000000)
				{
					for (int j = 0; j < 54; j++)
					{
						if (this.inventory[j].type == 74)
						{
							while (this.inventory[j].stack > 0 && num1 >= 1000000)
							{
								num1 = num1 - 1000000;
								Item item1 = this.inventory[j];
								item1.stack = item1.stack - 1;
								if (this.inventory[j].stack != 0)
								{
									continue;
								}
								this.inventory[j].type = 0;
							}
						}
					}
				}
				if (num1 >= 10000)
				{
					for (int k = 0; k < 54; k++)
					{
						if (this.inventory[k].type == 73)
						{
							while (this.inventory[k].stack > 0 && num1 >= 10000)
							{
								num1 = num1 - 10000;
								Item item2 = this.inventory[k];
								item2.stack = item2.stack - 1;
								if (this.inventory[k].stack != 0)
								{
									continue;
								}
								this.inventory[k].type = 0;
							}
						}
					}
				}
				if (num1 >= 100)
				{
					for (int l = 0; l < 54; l++)
					{
						if (this.inventory[l].type == 72)
						{
							while (this.inventory[l].stack > 0 && num1 >= 100)
							{
								num1 = num1 - 100;
								Item item3 = this.inventory[l];
								item3.stack = item3.stack - 1;
								if (this.inventory[l].stack != 0)
								{
									continue;
								}
								this.inventory[l].type = 0;
							}
						}
					}
				}
				if (num1 >= 1)
				{
					for (int m = 0; m < 54; m++)
					{
						if (this.inventory[m].type == 71)
						{
							while (this.inventory[m].stack > 0 && num1 >= 1)
							{
								num1--;
								Item item4 = this.inventory[m];
								item4.stack = item4.stack - 1;
								if (this.inventory[m].stack != 0)
								{
									continue;
								}
								this.inventory[m].type = 0;
							}
						}
					}
				}
				if (num1 <= 0)
				{
					continue;
				}
				int num2 = -1;
				int num3 = 53;
				while (num3 >= 0)
				{
					if (this.inventory[num3].type == 0 || this.inventory[num3].stack == 0)
					{
						num2 = num3;
						break;
					}
					else
					{
						num3--;
					}
				}
				if (num2 < 0)
				{
					for (int n = 0; n < 54; n++)
					{
						this.inventory[n] = item[n].Clone();
					}
					return false;
				}
				bool flag = true;
				if (num1 >= 10000)
				{
					int num4 = 0;
					while (num4 < 58)
					{
						if (this.inventory[num4].type != 74 || this.inventory[num4].stack < 1)
						{
							num4++;
						}
						else
						{
							Item item5 = this.inventory[num4];
							item5.stack = item5.stack - 1;
							if (this.inventory[num4].stack == 0)
							{
								this.inventory[num4].type = 0;
							}
							this.inventory[num2].SetDefaults(73, false);
							this.inventory[num2].stack = 100;
							flag = false;
							goto Label1;
						}
					}
				}
				else if (num1 >= 100)
				{
					int num5 = 0;
					while (num5 < 54)
					{
						if (this.inventory[num5].type != 73 || this.inventory[num5].stack < 1)
						{
							num5++;
						}
						else
						{
							Item item6 = this.inventory[num5];
							item6.stack = item6.stack - 1;
							if (this.inventory[num5].stack == 0)
							{
								this.inventory[num5].type = 0;
							}
							this.inventory[num2].SetDefaults(72, false);
							this.inventory[num2].stack = 100;
							flag = false;
							goto Label1;
						}
					}
				}
				else if (num1 >= 1)
				{
					int num6 = 0;
					while (num6 < 54)
					{
						if (this.inventory[num6].type != 72 || this.inventory[num6].stack < 1)
						{
							num6++;
						}
						else
						{
							Item item7 = this.inventory[num6];
							item7.stack = item7.stack - 1;
							if (this.inventory[num6].stack == 0)
							{
								this.inventory[num6].type = 0;
							}
							this.inventory[num2].SetDefaults(71, false);
							this.inventory[num2].stack = 100;
							flag = false;
							break;
						}
					}
				}
			Label1:
				if (!flag)
				{
					continue;
				}
				if (num1 < 10000)
				{
					int num7 = 0;
					while (num7 < 54)
					{
						if (this.inventory[num7].type != 73 || this.inventory[num7].stack < 1)
						{
							num7++;
						}
						else
						{
							Item item8 = this.inventory[num7];
							item8.stack = item8.stack - 1;
							if (this.inventory[num7].stack == 0)
							{
								this.inventory[num7].type = 0;
							}
							this.inventory[num2].SetDefaults(72, false);
							this.inventory[num2].stack = 100;
							flag = false;
							break;
						}
					}
				}
				if (!flag || num1 >= 1000000)
				{
					continue;
				}
				int num8 = 0;
				while (num8 < 54)
				{
					if (this.inventory[num8].type != 74 || this.inventory[num8].stack < 1)
					{
						num8++;
					}
					else
					{
						Item item9 = this.inventory[num8];
						item9.stack = item9.stack - 1;
						if (this.inventory[num8].stack == 0)
						{
							this.inventory[num8].type = 0;
						}
						this.inventory[num2].SetDefaults(73, false);
						this.inventory[num2].stack = 100;
						flag = false;
						goto Label0;
					}
				}
			}
			return true;
		}

		public void CarpetMovement()
		{
			bool flag = false;
			if (this.grappling[0] == -1 && this.carpet && !this.jumpAgainCloud && !this.jumpAgainSandstorm && !this.jumpAgainBlizzard && !this.jumpAgainFart && !this.jumpAgainSail && !this.jumpAgainUnicorn && this.jump == 0 && this.velocity.Y != 0f && this.rocketTime == 0 && this.wingTime == 0f && !this.mount.Active)
			{
				if (this.controlJump && this.canCarpet)
				{
					this.canCarpet = false;
					this.carpetTime = 300;
				}
				if (this.carpetTime > 0 && this.controlJump)
				{
					this.fallStart = (int)(this.position.Y / 16f);
					flag = true;
					Player player = this;
					player.carpetTime = player.carpetTime - 1;
					float single = this.gravity;
					if (this.gravDir == 1f && this.velocity.Y > -single)
					{
						this.velocity.Y = -(single + 1E-06f);
					}
					else if (this.gravDir == -1f && this.velocity.Y < single)
					{
						this.velocity.Y = single + 1E-06f;
					}
					Player player1 = this;
					player1.carpetFrameCounter = player1.carpetFrameCounter + (1f + Math.Abs(this.velocity.X * 0.5f));
					if (this.carpetFrameCounter > 8f)
					{
						this.carpetFrameCounter = 0f;
						Player player2 = this;
						player2.carpetFrame = player2.carpetFrame + 1;
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
			if (!flag)
			{
				this.carpetFrame = -1;
				return;
			}
			this.slowFall = false;
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
			int x = (int)(this.position.X + (float)(this.width / 2)) / 16;
			int num = x * 16 + 8 - this.width / 2;
			if (!Collision.SolidCollision(new Vector2((float)num, this.position.Y), this.width, this.height))
			{
				if (this.whoAmI == Main.myPlayer)
				{
					Main.cameraX = Main.cameraX + this.position.X - (float)num;
				}
				this.pulleyDir = 1;
				this.position.X = (float)num;
				this.direction = dir;
			}
		}

		public void ChangeSpawn(int x, int y)
		{
			for (int i = 0; i < 200 && this.spN[i] != null; i++)
			{
				if (this.spN[i] == Main.worldName && this.spI[i] == Main.worldID)
				{
					for (int j = i; j > 0; j--)
					{
						this.spN[j] = this.spN[j - 1];
						this.spI[j] = this.spI[j - 1];
						this.spX[j] = this.spX[j - 1];
						this.spY[j] = this.spY[j - 1];
					}
					this.spN[0] = Main.worldName;
					this.spI[0] = Main.worldID;
					this.spX[0] = x;
					this.spY[0] = y;
					return;
				}
			}
			for (int k = 199; k > 0; k--)
			{
				if (this.spN[k - 1] != null)
				{
					this.spN[k] = this.spN[k - 1];
					this.spI[k] = this.spI[k - 1];
					this.spX[k] = this.spX[k - 1];
					this.spY[k] = this.spY[k - 1];
				}
			}
			this.spN[0] = Main.worldName;
			this.spI[0] = Main.worldID;
			this.spX[0] = x;
			this.spY[0] = y;
		}

		public void checkArmor()
		{
		}

		public void checkDPSTime()
		{
			int num = 3;
			if (!this.dpsStarted)
			{
				return;
			}
			if ((DateTime.Now - this.dpsLastHit).Seconds >= num)
			{
				this.dpsStarted = false;
			}
		}

		public void CheckDrowning()
		{
			bool flag = Collision.DrownCollision(this.position, this.width, this.height, this.gravDir);
			if (this.armor[0].type == 250)
			{
				flag = true;
			}
			if (this.inventory[this.selectedItem].type == 186)
			{
				try
				{
					int x = (int)((this.position.X + (float)(this.width / 2) + (float)(6 * this.direction)) / 16f);
					int num = 0;
					if (this.gravDir == -1f)
					{
						num = this.height;
					}
					int y = (int)((this.position.Y + (float)num - 44f * this.gravDir) / 16f);
					if (Main.tile[x, y].liquid < 128)
					{
						if (Main.tile[x, y] == null)
						{
							Main.tile[x, y] = new Tile();
						}
						if (!Main.tile[x, y].active() || !Main.tileSolid[Main.tile[x, y].type] || Main.tileSolidTop[Main.tile[x, y].type])
						{
							flag = false;
						}
					}
				}
				catch (Exception ex)
				{
#if DEBUG
					Console.WriteLine(ex);
					System.Diagnostics.Debugger.Break();

#endif
				}
			}
			if (this.gills)
			{
				flag = false;
			}
			if (Main.myPlayer == this.whoAmI)
			{
				if (this.merman)
				{
					flag = false;
				}
				if (!flag)
				{
					Player player = this;
					player.breath = player.breath + 3;
					if (this.breath > this.breathMax)
					{
						this.breath = this.breathMax;
					}
					this.breathCD = 0;
				}
				else
				{
					Player player1 = this;
					player1.breathCD = player1.breathCD + 1;
					int num1 = 7;
					if (this.inventory[this.selectedItem].type == 186)
					{
						num1 = num1 * 2;
					}
					if (this.accDivingHelm)
					{
						num1 = num1 * 4;
					}
					if (this.breathCD >= num1)
					{
						this.breathCD = 0;
						Player player2 = this;
						player2.breath = player2.breath - 1;
						if (this.breath <= 0)
						{
							this.lifeRegenTime = 0;
							this.breath = 0;
							Player player3 = this;
							player3.statLife = player3.statLife - 2;
							if (this.statLife <= 0)
							{
								this.statLife = 0;
								this.KillMe(10, 0, false, Lang.deathMsg(-1, -1, -1, 1));
							}
						}
					}
				}
			}
			if (flag && Main.rand.Next(20) == 0 && !this.lavaWet && !this.honeyWet)
			{
				if (this.inventory[this.selectedItem].type == 186)
				{
					return;
				}
			}
		}

		public void CheckIceBreak()
		{
			if (this.velocity.Y > 7f)
			{
				Vector2 vector2 = this.position + this.velocity;
				int x = (int)(vector2.X / 16f);
				int num = (int)((vector2.X + (float)this.width) / 16f);
				int y = (int)((this.position.Y + (float)this.height + 1f) / 16f);
				for (int i = x; i <= num; i++)
				{
					for (int j = y; j <= y + 1; j++)
					{
						if (Main.tile[i, j].nactive() && Main.tile[i, j].type == TileID.BreakableIce && !WorldGen.SolidTile(i, j - 1))
						{
							WorldGen.KillTile(i, j, false, false, false);
							if (Main.netMode == 1)
							{
								NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)i, (float)j, 0f, 0, 0, 0);
							}
						}
					}
				}
			}
		}

		public bool CheckMana(int amount, bool pay = false, bool blockQuickMana = false)
		{
			int num = (int)((float)amount * this.manaCost);
			if (this.statMana >= num)
			{
				if (pay)
				{
					Player player = this;
					player.statMana = player.statMana - num;
				}
				return true;
			}
			if (!this.manaFlower || blockQuickMana)
			{
				return false;
			}
			this.QuickMana();
			if (this.statMana < num)
			{
				return false;
			}
			if (pay)
			{
				Player player1 = this;
				player1.statMana = player1.statMana - num;
			}
			return true;
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
					if (Main.tile[i, j].nactive() && Main.tileSolid[Main.tile[i, j].type] && !Main.tileSolidTop[Main.tile[i, j].type])
					{
						Main.NewText("Your bed is obstructed.", 255, 240, 20, false);
						return false;
					}
				}
			}
			if (!WorldGen.StartRoomCheck(x, y - 1))
			{
				return false;
			}
			return true;
		}

		public void ClearBuff(int type)
		{
			for (int i = 0; i < 22; i++)
			{
				if (this.buffType[i] == type)
				{
					this.DelBuff(i);
				}
			}
		}

		public object clientClone()
		{
			Player player = new Player()
			{
				zone1 = this.zone1,
				zone2 = this.zone2,
				MinionTargetPoint = this.MinionTargetPoint,
				direction = this.direction,
				selectedItem = this.selectedItem,
				controlUp = this.controlUp,
				controlDown = this.controlDown,
				controlLeft = this.controlLeft,
				controlRight = this.controlRight,
				controlJump = this.controlJump,
				controlUseItem = this.controlUseItem,
				statLife = this.statLife,
				statLifeMax = this.statLifeMax,
				statMana = this.statMana,
				statManaMax = this.statManaMax
			};
			player.position.X = this.position.X;
			player.chest = this.chest;
			player.talkNPC = this.talkNPC;
			player.hideVisual = this.hideVisual;
			player.hideMisc = this.hideMisc;
			for (int i = 0; i < 59; i++)
			{
				player.inventory[i] = this.inventory[i].Clone();
				if (i < (int)this.armor.Length)
				{
					player.armor[i] = this.armor[i].Clone();
				}
				if (i < (int)this.dye.Length)
				{
					player.dye[i] = this.dye[i].Clone();
				}
				if (i < (int)this.miscEquips.Length)
				{
					player.miscEquips[i] = this.miscEquips[i].Clone();
				}
				if (i < (int)this.miscDyes.Length)
				{
					player.miscDyes[i] = this.miscDyes[i].Clone();
				}
				if (i < (int)this.bank.item.Length)
				{
					player.bank.item[i] = this.bank.item[i].Clone();
				}
				if (i < (int)this.bank2.item.Length)
				{
					player.bank2.item[i] = this.bank2.item[i].Clone();
				}
			}
			player.trashItem = this.trashItem.Clone();
			for (int j = 0; j < 22; j++)
			{
				player.buffType[j] = this.buffType[j];
				player.buffTime[j] = this.buffTime[j];
			}
			return player;
		}

		public object Clone()
		{
			return base.MemberwiseClone();
		}

		public void CollectTaxes()
		{
			int num = Item.buyPrice(0, 0, 0, 50);
			int num1 = Item.buyPrice(0, 10, 0, 0);
			if (!NPC.taxCollector)
			{
				return;
			}
			if (this.taxMoney >= num1)
			{
				return;
			}
			int num2 = 0;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && !Main.npc[i].homeless && NPC.TypeToNum(Main.npc[i].type) > 0)
				{
					num2++;
				}
			}
			Player player = this;
			player.taxMoney = player.taxMoney + num * num2;
			if (this.taxMoney > num1)
			{
				this.taxMoney = num1;
			}
		}

		public bool consumeItem(int type)
		{
			for (int i = 0; i < 58; i++)
			{
				if (this.inventory[i].stack > 0 && this.inventory[i].type == type)
				{
					Item item = this.inventory[i];
					item.stack = item.stack - 1;
					if (this.inventory[i].stack <= 0)
					{
						this.inventory[i].SetDefaults(0, false);
					}
					return true;
				}
			}
			return false;
		}

		public bool ConsumeSolarFlare()
		{
			if (!this.setSolar || this.solarShields <= 0)
			{
				return false;
			}
			if (Main.netMode == 1 && this.whoAmI != Main.myPlayer)
			{
				return true;
			}
			Player player = this;
			player.solarShields = player.solarShields - 1;
			for (int i = 0; i < 22; i++)
			{
				if (this.buffType[i] >= BuffID.SolarShield1 && this.buffType[i] <= BuffID.SolarShield3)
				{
					this.DelBuff(i);
				}
			}
			if (this.solarShields > 0)
			{
				this.AddBuff(BuffID.SolarShield1 + this.solarShields - 1, 5, false);
			}
			this.solarCounter = 0;
			return true;
		}

		public int CountBuffs()
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

		public void Counterweight(Vector2 hitPos, int dmg, float kb)
		{
			if (!this.yoyoGlove && this.counterWeight <= 0)
			{
				return;
			}
			int num = -1;
			int num1 = 0;
			int num2 = 0;
			for (int i = 0; i < 1000; i++)
			{
				if (Main.projectile[i].active && Main.projectile[i].owner == this.whoAmI)
				{
					if (Main.projectile[i].counterweight)
					{
						num2++;
					}
					else if (Main.projectile[i].aiStyle == 99)
					{
						num1++;
						num = i;
					}
				}
			}
			if (this.yoyoGlove && num1 < 2)
			{
				if (num >= 0)
				{
					Vector2 vector2 = hitPos - base.Center;
					vector2.Normalize();
					vector2 = vector2 * 16f;
					Projectile.NewProjectile(base.Center.X, base.Center.Y, vector2.X, vector2.Y, Main.projectile[num].type, Main.projectile[num].damage, Main.projectile[num].knockBack, this.whoAmI, 1f, 0f);
					return;
				}
			}
			else if (num2 < num1)
			{
				Vector2 vector21 = hitPos - base.Center;
				vector21.Normalize();
				vector21 = vector21 * 16f;
				float single = (kb + 6f) / 2f;
				if (num2 > 0)
				{
					Projectile.NewProjectile(base.Center.X, base.Center.Y, vector21.X, vector21.Y, this.counterWeight, (int)((double)dmg * 0.8), single, this.whoAmI, 1f, 0f);
					return;
				}
				Projectile.NewProjectile(base.Center.X, base.Center.Y, vector21.X, vector21.Y, this.counterWeight, (int)((double)dmg * 0.8), single, this.whoAmI, 0f, 0f);
			}
		}

		public void DashMovement()
		{
			if (this.dash == 2 && this.eocDash > 0)
			{
				if (this.eocHit < 0)
				{
					Rectangle rectangle = new Rectangle((int)((double)this.position.X + (double)this.velocity.X * 0.5 - 4), (int)((double)this.position.Y + (double)this.velocity.Y * 0.5 - 4), this.width + 8, this.height + 8);
					for (int i = 0; i < 200; i++)
					{
						if (Main.npc[i].active && !Main.npc[i].dontTakeDamage && !Main.npc[i].friendly)
						{
							NPC nPC = Main.npc[i];
							if (rectangle.Intersects(nPC.getRect()) && (nPC.noTileCollide || Collision.CanHit(this.position, this.width, this.height, nPC.position, nPC.width, nPC.height)))
							{
								float single = 30f * this.meleeDamage;
								float single1 = 9f;
								bool flag = false;
								if (this.kbGlove)
								{
									single1 = single1 * 2f;
								}
								if (this.kbBuff)
								{
									single1 = single1 * 1.5f;
								}
								if (Main.rand.Next(100) < this.meleeCrit)
								{
									flag = true;
								}
								int num2 = this.direction;
								if (this.velocity.X < 0f)
								{
									num2 = -1;
								}
								if (this.velocity.X > 0f)
								{
									num2 = 1;
								}
								nPC.StrikeNPC((int)single, single1, num2, flag, false, false, this);
								this.eocDash = 10;
								this.dashDelay = 30;
								this.velocity.X = (float)(-num2 * 9);
								this.velocity.Y = -4f;
								this.immune = true;
								this.immuneTime = 4;
								this.eocHit = i;
							}
						}
					}
				}
				else if ((!this.controlLeft || this.velocity.X >= 0f) && (!this.controlRight || this.velocity.X <= 0f))
				{
					this.velocity.X = this.velocity.X * 0.95f;
				}
			}
			if (this.dash == 3 && this.dashDelay < 0 && this.whoAmI == Main.myPlayer)
			{
				Rectangle rectangle1 = new Rectangle((int)((double)this.position.X + (double)this.velocity.X * 0.5 - 4), (int)((double)this.position.Y + (double)this.velocity.Y * 0.5 - 4), this.width + 8, this.height + 8);
				for (int j = 0; j < 200; j++)
				{
					if (Main.npc[j].active && !Main.npc[j].dontTakeDamage && !Main.npc[j].friendly && Main.npc[j].immune[this.whoAmI] <= 0)
					{
						NPC nPC1 = Main.npc[j];
						if (rectangle1.Intersects(nPC1.getRect()) && (nPC1.noTileCollide || Collision.CanHit(this.position, this.width, this.height, nPC1.position, nPC1.width, nPC1.height)))
						{
							if (!this.solarDashConsumedFlare)
							{
								this.solarDashConsumedFlare = true;
								this.ConsumeSolarFlare();
							}
							float single2 = 150f * this.meleeDamage;
							float single3 = 9f;
							bool flag1 = false;
							if (this.kbGlove)
							{
								single3 = single3 * 2f;
							}
							if (this.kbBuff)
							{
								single3 = single3 * 1.5f;
							}
							if (Main.rand.Next(100) < this.meleeCrit)
							{
								flag1 = true;
							}
							int num3 = this.direction;
							if (this.velocity.X < 0f)
							{
								num3 = -1;
							}
							if (this.velocity.X > 0f)
							{
								num3 = 1;
							}
							if (this.whoAmI == Main.myPlayer)
							{
								nPC1.StrikeNPC((int)single2, single3, num3, flag1, false, false, this);
								if (Main.netMode != 0)
								{
									NetMessage.SendData((int)PacketTypes.NpcStrike, -1, -1, "", j, single2, single3, (float)num3, 0, 0, 0);
								}
								int num7 = Projectile.NewProjectile(base.Center.X, base.Center.Y, 0f, 0f, 608, 150, 15f, Main.myPlayer, 0f, 0f);
								Main.projectile[num7].Kill();
							}
							nPC1.immune[this.whoAmI] = 6;
							this.immune = true;
							this.immuneTime = 4;
						}
					}
				}
			}
			if (this.dashDelay > 0)
			{
				if (this.eocDash > 0)
				{
					Player player = this;
					player.eocDash = player.eocDash - 1;
				}
				if (this.eocDash == 0)
				{
					this.eocHit = -1;
				}
				Player player1 = this;
				player1.dashDelay = player1.dashDelay - 1;
				return;
			}
			if (this.dashDelay < 0)
			{
				float single4 = 12f;
				float single5 = 0.992f;
				float single6 = Math.Max(this.accRunSpeed, this.maxRunSpeed);
				float single7 = 0.96f;
				int num4 = 20;
				if (this.dash == 1)
				{
				}
				else if (this.dash == 2)
				{
					single5 = 0.985f;
					single7 = 0.94f;
					num4 = 30;
				}
				else if (this.dash == 3)
				{
					single4 = 14f;
					single5 = 0.985f;
					single7 = 0.94f;
					num4 = 20;
				}
				else if (this.dash == 4)
				{
					single5 = 0.985f;
					single7 = 0.94f;
					num4 = 20;
				}
				if (this.dash > 0)
				{
					this.vortexStealthActive = false;
					if (this.velocity.X > single4 || this.velocity.X < -single4)
					{
						this.velocity.X = this.velocity.X * single5;
						return;
					}
					if (this.velocity.X > single6 || this.velocity.X < -single6)
					{
						this.velocity.X = this.velocity.X * single7;
						return;
					}
					this.dashDelay = num4;
					if (this.velocity.X < 0f)
					{
						this.velocity.X = -single6;
						return;
					}
					if (this.velocity.X > 0f)
					{
						this.velocity.X = single6;
						return;
					}
				}
			}
			else if (this.dash > 0 && !this.mount.Active)
			{
				if (this.dash == 1)
				{
					int num13 = 0;
					bool flag2 = false;
					if (this.dashTime > 0)
					{
						Player player2 = this;
						player2.dashTime = player2.dashTime - 1;
					}
					if (this.dashTime < 0)
					{
						Player player3 = this;
						player3.dashTime = player3.dashTime + 1;
					}
					if (this.controlRight && this.releaseRight)
					{
						if (this.dashTime <= 0)
						{
							this.dashTime = 15;
						}
						else
						{
							num13 = 1;
							flag2 = true;
							this.dashTime = 0;
						}
					}
					else if (this.controlLeft && this.releaseLeft)
					{
						if (this.dashTime >= 0)
						{
							this.dashTime = -15;
						}
						else
						{
							num13 = -1;
							flag2 = true;
							this.dashTime = 0;
						}
					}
					if (flag2)
					{
						this.velocity.X = 16.9f * (float)num13;
						Point tileCoordinates = (base.Center + new Vector2((float)(num13 * this.width / 2 + 2), this.gravDir * (float)(-this.height) / 2f + this.gravDir * 2f)).ToTileCoordinates();
						Point point = (base.Center + new Vector2((float)(num13 * this.width / 2 + 2), 0f)).ToTileCoordinates();
						if (WorldGen.SolidOrSlopedTile(tileCoordinates.X, tileCoordinates.Y) || WorldGen.SolidOrSlopedTile(point.X, point.Y))
						{
							this.velocity.X = this.velocity.X / 2f;
						}
						this.dashDelay = -1;
						return;
					}
				}
				else if (this.dash == 2)
				{
					int num18 = 0;
					bool flag3 = false;
					if (this.dashTime > 0)
					{
						Player player4 = this;
						player4.dashTime = player4.dashTime - 1;
					}
					if (this.dashTime < 0)
					{
						Player player5 = this;
						player5.dashTime = player5.dashTime + 1;
					}
					if (this.controlRight && this.releaseRight)
					{
						if (this.dashTime <= 0)
						{
							this.dashTime = 15;
						}
						else
						{
							num18 = 1;
							flag3 = true;
							this.dashTime = 0;
						}
					}
					else if (this.controlLeft && this.releaseLeft)
					{
						if (this.dashTime >= 0)
						{
							this.dashTime = -15;
						}
						else
						{
							num18 = -1;
							flag3 = true;
							this.dashTime = 0;
						}
					}
					if (flag3)
					{
						this.velocity.X = 14.5f * (float)num18;
						Point tileCoordinates1 = (base.Center + new Vector2((float)(num18 * this.width / 2 + 2), this.gravDir * (float)(-this.height) / 2f + this.gravDir * 2f)).ToTileCoordinates();
						Point point1 = (base.Center + new Vector2((float)(num18 * this.width / 2 + 2), 0f)).ToTileCoordinates();
						if (WorldGen.SolidTile(tileCoordinates1.X, tileCoordinates1.Y) || WorldGen.SolidTile(point1.X, point1.Y))
						{
							this.velocity.X = this.velocity.X / 2f;
						}
						this.dashDelay = -1;
						this.eocDash = 15;
						return;
					}
				}
				else if (this.dash == 3)
				{
					int num22 = 0;
					bool flag4 = false;
					if (this.dashTime > 0)
					{
						Player player6 = this;
						player6.dashTime = player6.dashTime - 1;
					}
					if (this.dashTime < 0)
					{
						Player player7 = this;
						player7.dashTime = player7.dashTime + 1;
					}
					if (this.controlRight && this.releaseRight)
					{
						if (this.dashTime <= 0)
						{
							this.dashTime = 15;
						}
						else
						{
							num22 = 1;
							flag4 = true;
							this.dashTime = 0;
							this.solarDashing = true;
							this.solarDashConsumedFlare = false;
						}
					}
					else if (this.controlLeft && this.releaseLeft)
					{
						if (this.dashTime >= 0)
						{
							this.dashTime = -15;
						}
						else
						{
							num22 = -1;
							flag4 = true;
							this.dashTime = 0;
							this.solarDashing = true;
							this.solarDashConsumedFlare = false;
						}
					}
					if (flag4)
					{
						this.velocity.X = 21.9f * (float)num22;
						Point tileCoordinates2 = (base.Center + new Vector2((float)(num22 * this.width / 2 + 2), this.gravDir * (float)(-this.height) / 2f + this.gravDir * 2f)).ToTileCoordinates();
						Point point2 = (base.Center + new Vector2((float)(num22 * this.width / 2 + 2), 0f)).ToTileCoordinates();
						if (WorldGen.SolidTile(tileCoordinates2.X, tileCoordinates2.Y) || WorldGen.SolidTile(point2.X, point2.Y))
						{
							this.velocity.X = this.velocity.X / 2f;
						}
						this.dashDelay = -1;
						return;
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

		public void DoCoins(int i)
		{
			if (this.inventory[i].stack == 100 && (this.inventory[i].type == 71 || this.inventory[i].type == 72 || this.inventory[i].type == 73))
			{
				this.inventory[i].SetDefaults(this.inventory[i].type + 1, false);
				for (int num = 0; num < 54; num++)
				{
					if (this.inventory[num].IsTheSameAs(this.inventory[i]) && num != i && this.inventory[num].type == this.inventory[i].type && this.inventory[num].stack < this.inventory[num].maxStack)
					{
						Item item = this.inventory[num];
						item.stack = item.stack + 1;
						this.inventory[i].SetDefaults(0, false);
						this.inventory[i].active = false;
						this.inventory[i].name = "";
						this.inventory[i].type = 0;
						this.inventory[i].stack = 0;
						this.DoCoins(num);
					}
				}
			}
		}



		public int DropCoins()
		{
			int num = 0;
			for (int i = 0; i < 59; i++)
			{
				if (this.inventory[i].type >= 71 && this.inventory[i].type <= 74)
				{
					int num1 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[i].type, 1, false, 0, false);
					int num2 = this.inventory[i].stack / 2;
					if (Main.expertMode)
					{
						num2 = (int)((double)this.inventory[i].stack * 0.25);
					}
					num2 = this.inventory[i].stack - num2;
					Item item = this.inventory[i];
					item.stack = item.stack - num2;
					if (this.inventory[i].type == 71)
					{
						num = num + num2;
					}
					if (this.inventory[i].type == 72)
					{
						num = num + num2 * 100;
					}
					if (this.inventory[i].type == 73)
					{
						num = num + num2 * 10000;
					}
					if (this.inventory[i].type == 74)
					{
						num = num + num2 * 1000000;
					}
					if (this.inventory[i].stack <= 0)
					{
						this.inventory[i] = new Item();
					}
					Main.item[num1].stack = num2;
					Main.item[num1].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
					Main.item[num1].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
					Main.item[num1].noGrabDelay = 100;
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num1, 0f, 0f, 0f, 0, 0, 0);
					}
					if (i == 58)
					{
						Main.mouseItem = this.inventory[i].Clone();
					}
				}
			}
			this.lostCoins = num;
			this.lostCoinString = Main.ValueToCoins(this.lostCoins);
			return num;
		}

		public void dropItemCheck()
		{
			if (!Main.playerInventory)
			{
				this.noThrow = 0;
			}
			if (this.noThrow > 0)
			{
				Player player = this;
				player.noThrow = player.noThrow - 1;
			}
			if (!Main.craftGuide && Main.guideItem.type > 0)
			{
				Main.guideItem.position = base.Center;
				Item item = this.GetItem(this.whoAmI, Main.guideItem, false, true);
				if (item.stack > 0)
				{
					int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item.type, item.stack, false, (int)Main.guideItem.prefix, true);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				Main.guideItem = new Item();
			}
			if (!Main.reforge && Main.reforgeItem.type > 0)
			{
				Main.reforgeItem.position = base.Center;
				Item item1 = this.GetItem(this.whoAmI, Main.reforgeItem, false, true);
				if (item1.stack > 0)
				{
					int num1 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item1.type, item1.stack, false, (int)Main.reforgeItem.prefix, true);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num1, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				Main.reforgeItem = new Item();
			}
			if (Main.myPlayer == this.whoAmI)
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
			if (WorldGen.InWorld(Player.tileTargetX, Player.tileTargetY, 0) && Main.tile[Player.tileTargetX, Player.tileTargetY] != null && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 334 && this.ItemFitsWeaponRack(this.inventory[this.selectedItem]))
			{
				this.noThrow = 2;
			}
			if (WorldGen.InWorld(Player.tileTargetX, Player.tileTargetY, 0) && Main.tile[Player.tileTargetX, Player.tileTargetY] != null && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 395 && this.ItemFitsItemFrame(this.inventory[this.selectedItem]))
			{
				this.noThrow = 2;
			}
			if (Main.mouseItem.type > 0 && !Main.playerInventory)
			{
				Main.mouseItem.position = base.Center;
				Item item2 = this.GetItem(this.whoAmI, Main.mouseItem, false, true);
				if (item2.stack > 0)
				{
					int num2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item2.type, item2.stack, false, 0, true);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num2, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				Main.mouseItem = new Item();
				Recipe.FindRecipes();
			}
			if ((this.controlThrow && this.releaseThrow && !this.inventory[this.selectedItem].favorited && this.inventory[this.selectedItem].type > 0 && !Main.chatMode || (Main.mouseRight && !this.mouseInterface && Main.mouseRightRelease || !Main.playerInventory) && Main.mouseItem.type > 0 && Main.mouseItem.stack > 0) && this.noThrow <= 0)
			{
				if (this.inventory[this.selectedItem].favorited)
				{
					this.inventory[this.selectedItem] = this.GetItem(this.whoAmI, this.inventory[this.selectedItem], false, true);
					if (this.selectedItem == 58)
					{
						Main.mouseItem = this.inventory[this.selectedItem];
					}
					Recipe.FindRecipes();
					if (this.inventory[this.selectedItem].type == 0)
					{
						return;
					}
				}
				Item item3 = new Item();
				bool flag1 = false;
				if ((Main.mouseRight && !this.mouseInterface && Main.mouseRightRelease || !Main.playerInventory) && Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)
				{
					item3 = this.inventory[this.selectedItem];
					this.inventory[this.selectedItem] = Main.mouseItem;
					this.delayUseItem = true;
					this.controlUseItem = false;
					flag1 = true;
				}
				int num3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[this.selectedItem].type, 1, false, 0, false);
				if (flag1 || this.inventory[this.selectedItem].type != 8 || this.inventory[this.selectedItem].stack <= 1)
				{
					this.inventory[this.selectedItem].position = Main.item[num3].position;
					Main.item[num3] = this.inventory[this.selectedItem];
					this.inventory[this.selectedItem] = new Item();
				}
				else
				{
					Item item4 = this.inventory[this.selectedItem];
					item4.stack = item4.stack - 1;
				}
				if (Main.netMode == 0)
				{
					Main.item[num3].noGrabDelay = 100;
				}
				Main.item[num3].velocity.Y = -2f;
				Main.item[num3].velocity.X = (float)(4 * this.direction) + this.velocity.X;
				Main.item[num3].favorited = false;
				if ((!Main.mouseRight || this.mouseInterface) && Main.playerInventory || Main.mouseItem.type <= 0)
				{
					this.itemAnimation = 10;
					this.itemAnimationMax = 10;
				}
				else
				{
					this.inventory[this.selectedItem] = item3;
					Main.mouseItem = new Item();
				}
				Recipe.FindRecipes();
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num3, 0f, 0f, 0f, 0, 0, 0);
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
					Main.item[num].netDefaults(this.inventory[i].netID);
					Main.item[num].Prefix((int)this.inventory[i].prefix);
					Main.item[num].stack = this.inventory[i].stack;
					Main.item[num].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
					Main.item[num].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
					Main.item[num].noGrabDelay = 100;
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				this.inventory[i] = new Item();
				if (i < (int)this.armor.Length)
				{
					if (this.armor[i].stack > 0)
					{
						int num1 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.armor[i].type, 1, false, 0, false);
						Main.item[num1].netDefaults(this.armor[i].netID);
						Main.item[num1].Prefix((int)this.armor[i].prefix);
						Main.item[num1].stack = this.armor[i].stack;
						Main.item[num1].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
						Main.item[num1].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
						Main.item[num1].noGrabDelay = 100;
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num1, 0f, 0f, 0f, 0, 0, 0);
						}
					}
					this.armor[i] = new Item();
				}
				if (i < (int)this.dye.Length)
				{
					if (this.dye[i].stack > 0)
					{
						int num2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.dye[i].type, 1, false, 0, false);
						Main.item[num2].netDefaults(this.dye[i].netID);
						Main.item[num2].Prefix((int)this.dye[i].prefix);
						Main.item[num2].stack = this.dye[i].stack;
						Main.item[num2].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
						Main.item[num2].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
						Main.item[num2].noGrabDelay = 100;
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num2, 0f, 0f, 0f, 0, 0, 0);
						}
					}
					this.dye[i] = new Item();
				}
				if (i < (int)this.miscEquips.Length)
				{
					if (this.miscEquips[i].stack > 0)
					{
						int num3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.miscEquips[i].type, 1, false, 0, false);
						Main.item[num3].netDefaults(this.miscEquips[i].netID);
						Main.item[num3].Prefix((int)this.miscEquips[i].prefix);
						Main.item[num3].stack = this.miscEquips[i].stack;
						Main.item[num3].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
						Main.item[num3].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
						Main.item[num3].noGrabDelay = 100;
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num3, 0f, 0f, 0f, 0, 0, 0);
						}
					}
					this.miscEquips[i] = new Item();
				}
				if (i < (int)this.miscDyes.Length)
				{
					if (this.miscDyes[i].stack > 0)
					{
						int num4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.miscDyes[i].type, 1, false, 0, false);
						Main.item[num4].netDefaults(this.miscDyes[i].netID);
						Main.item[num4].Prefix((int)this.miscDyes[i].prefix);
						Main.item[num4].stack = this.miscDyes[i].stack;
						Main.item[num4].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
						Main.item[num4].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
						Main.item[num4].noGrabDelay = 100;
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num4, 0f, 0f, 0f, 0, 0, 0);
						}
					}
					this.miscDyes[i] = new Item();
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

		public void DropTombstone(int coinsOwned, string deathText, int hitDirection)
		{
			if (Main.netMode != 1)
			{
				float single = (float)Main.rand.Next(-35, 36) * 0.1f;
				while (single < 2f && single > -2f)
				{
					single = single + (float)Main.rand.Next(-30, 31) * 0.1f;
				}
				int num = Main.rand.Next(6);
				if (coinsOwned <= 100000)
				{
					num = (num != 0 ? 200 + num : 43);
				}
				else
				{
					num = Main.rand.Next(5);
					num = num + 527;
				}
				int num1 = Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), (float)Main.rand.Next(10, 30) * 0.1f * (float)hitDirection + single, (float)Main.rand.Next(-40, -20) * 0.1f, num, 0, 0f, Main.myPlayer, 0f, 0f);
				Main.projectile[num1].miscText = string.Concat(this.name, deathText);
			}
		}

		public void DryCollision(bool fallThrough, bool ignorePlats)
		{
			int num;
			num = (!this.onTrack ? this.height : this.height - 10);
			this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, num, fallThrough, ignorePlats, (int)this.gravDir);
			if (Collision.up && this.gravDir == 1f)
			{
				this.jump = 0;
			}
			if (this.waterWalk || this.waterWalk2)
			{
				Vector2 vector2 = this.velocity;
				this.velocity = Collision.WaterCollision(this.position, this.velocity, this.width, this.height, fallThrough, false, this.waterWalk);
				if (vector2 != this.velocity)
				{
					this.fallStart = (int)(this.position.Y / 16f);
				}
			}
			Player player = this;
			player.position = player.position + this.velocity;
		}

		public static void EnterWorld(Player player)
		{
			if (Player.OnEnterWorld != null)
			{
				Player.OnEnterWorld(player);
			}
		}

		private static void ExtractinatorUse(int extractType)
		{
			int num = 5000;
			int num1 = 25;
			int num2 = 50;
			int num3 = -1;
			if (extractType == 1)
			{
				num = num / 3;
				num1 = num1 * 2;
				num2 = num2 / 2;
				num3 = 10;
			}
			int num4 = -1;
			int num5 = 1;
			if (num3 != -1 && Main.rand.Next(num3) == 0)
			{
				num4 = 3380;
				if (Main.rand.Next(5) == 0)
				{
					num5 = num5 + Main.rand.Next(2);
				}
				if (Main.rand.Next(10) == 0)
				{
					num5 = num5 + Main.rand.Next(3);
				}
				if (Main.rand.Next(15) == 0)
				{
					num5 = num5 + Main.rand.Next(4);
				}
			}
			else if (Main.rand.Next(2) == 0)
			{
				if (Main.rand.Next(12000) == 0)
				{
					num4 = 74;
					if (Main.rand.Next(14) == 0)
					{
						num5 = num5 + Main.rand.Next(0, 2);
					}
					if (Main.rand.Next(14) == 0)
					{
						num5 = num5 + Main.rand.Next(0, 2);
					}
					if (Main.rand.Next(14) == 0)
					{
						num5 = num5 + Main.rand.Next(0, 2);
					}
				}
				else if (Main.rand.Next(800) == 0)
				{
					num4 = 73;
					if (Main.rand.Next(6) == 0)
					{
						num5 = num5 + Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(6) == 0)
					{
						num5 = num5 + Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(6) == 0)
					{
						num5 = num5 + Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(6) == 0)
					{
						num5 = num5 + Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(6) == 0)
					{
						num5 = num5 + Main.rand.Next(1, 20);
					}
				}
				else if (Main.rand.Next(60) != 0)
				{
					num4 = 71;
					if (Main.rand.Next(3) == 0)
					{
						num5 = num5 + Main.rand.Next(10, 26);
					}
					if (Main.rand.Next(3) == 0)
					{
						num5 = num5 + Main.rand.Next(10, 26);
					}
					if (Main.rand.Next(3) == 0)
					{
						num5 = num5 + Main.rand.Next(10, 26);
					}
					if (Main.rand.Next(3) == 0)
					{
						num5 = num5 + Main.rand.Next(10, 25);
					}
				}
				else
				{
					num4 = 72;
					if (Main.rand.Next(4) == 0)
					{
						num5 = num5 + Main.rand.Next(5, 26);
					}
					if (Main.rand.Next(4) == 0)
					{
						num5 = num5 + Main.rand.Next(5, 26);
					}
					if (Main.rand.Next(4) == 0)
					{
						num5 = num5 + Main.rand.Next(5, 26);
					}
					if (Main.rand.Next(4) == 0)
					{
						num5 = num5 + Main.rand.Next(5, 25);
					}
				}
			}
			else if (num != -1 && Main.rand.Next(num) == 0)
			{
				num4 = 1242;
			}
			else if (num1 != -1 && Main.rand.Next(num1) == 0)
			{
				num4 = Main.rand.Next(6);
				if (num4 == 0)
				{
					num4 = 181;
				}
				else if (num4 == 1)
				{
					num4 = 180;
				}
				else if (num4 == 2)
				{
					num4 = 177;
				}
				else if (num4 != 3)
				{
					num4 = (num4 != 4 ? 182 : 178);
				}
				else
				{
					num4 = 179;
				}
				if (Main.rand.Next(20) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 2);
				}
				if (Main.rand.Next(30) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 3);
				}
				if (Main.rand.Next(40) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 4);
				}
				if (Main.rand.Next(50) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 5);
				}
				if (Main.rand.Next(60) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 6);
				}
			}
			else if (num2 != -1 && Main.rand.Next(num2) == 0)
			{
				num4 = 999;
				if (Main.rand.Next(20) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 2);
				}
				if (Main.rand.Next(30) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 3);
				}
				if (Main.rand.Next(40) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 4);
				}
				if (Main.rand.Next(50) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 5);
				}
				if (Main.rand.Next(60) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 6);
				}
			}
			else if (Main.rand.Next(3) != 0)
			{
				num4 = Main.rand.Next(8);
				if (num4 == 0)
				{
					num4 = 12;
				}
				else if (num4 == 1)
				{
					num4 = 11;
				}
				else if (num4 == 2)
				{
					num4 = 14;
				}
				else if (num4 == 3)
				{
					num4 = 13;
				}
				else if (num4 == 4)
				{
					num4 = 699;
				}
				else if (num4 != 5)
				{
					num4 = (num4 != 6 ? 702 : 701);
				}
				else
				{
					num4 = 700;
				}
				if (Main.rand.Next(20) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 2);
				}
				if (Main.rand.Next(30) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 3);
				}
				if (Main.rand.Next(40) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 4);
				}
				if (Main.rand.Next(50) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 5);
				}
				if (Main.rand.Next(60) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 6);
				}
			}
			else if (Main.rand.Next(5000) == 0)
			{
				num4 = 74;
				if (Main.rand.Next(10) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 3);
				}
				if (Main.rand.Next(10) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 3);
				}
				if (Main.rand.Next(10) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 3);
				}
				if (Main.rand.Next(10) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 3);
				}
				if (Main.rand.Next(10) == 0)
				{
					num5 = num5 + Main.rand.Next(0, 3);
				}
			}
			else if (Main.rand.Next(400) == 0)
			{
				num4 = 73;
				if (Main.rand.Next(5) == 0)
				{
					num5 = num5 + Main.rand.Next(1, 21);
				}
				if (Main.rand.Next(5) == 0)
				{
					num5 = num5 + Main.rand.Next(1, 21);
				}
				if (Main.rand.Next(5) == 0)
				{
					num5 = num5 + Main.rand.Next(1, 21);
				}
				if (Main.rand.Next(5) == 0)
				{
					num5 = num5 + Main.rand.Next(1, 21);
				}
				if (Main.rand.Next(5) == 0)
				{
					num5 = num5 + Main.rand.Next(1, 20);
				}
			}
			else if (Main.rand.Next(30) != 0)
			{
				num4 = 71;
				if (Main.rand.Next(2) == 0)
				{
					num5 = num5 + Main.rand.Next(10, 26);
				}
				if (Main.rand.Next(2) == 0)
				{
					num5 = num5 + Main.rand.Next(10, 26);
				}
				if (Main.rand.Next(2) == 0)
				{
					num5 = num5 + Main.rand.Next(10, 26);
				}
				if (Main.rand.Next(2) == 0)
				{
					num5 = num5 + Main.rand.Next(10, 25);
				}
			}
			else
			{
				num4 = 72;
				if (Main.rand.Next(3) == 0)
				{
					num5 = num5 + Main.rand.Next(5, 26);
				}
				if (Main.rand.Next(3) == 0)
				{
					num5 = num5 + Main.rand.Next(5, 26);
				}
				if (Main.rand.Next(3) == 0)
				{
					num5 = num5 + Main.rand.Next(5, 26);
				}
				if (Main.rand.Next(3) == 0)
				{
					num5 = num5 + Main.rand.Next(5, 25);
				}
			}
			if (num4 > 0)
			{
				int num6 = Item.NewItem((int)Main.screenPosition.X + Main.mouseX, (int)Main.screenPosition.Y + Main.mouseY, 1, 1, num4, num5, false, -1, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num6, 1f, 0f, 0f, 0, 0, 0);
				}
			}
		}

		public Item FillAmmo(int plr, Item newItem, bool noText = false)
		{
			Item item = newItem;
			for (int i = 54; i < 58; i++)
			{
				if (this.inventory[i].type > 0 && this.inventory[i].stack < this.inventory[i].maxStack && item.IsTheSameAs(this.inventory[i]))
				{
					if (item.stack + this.inventory[i].stack <= this.inventory[i].maxStack)
					{
						Item item1 = this.inventory[i];
						item1.stack = item1.stack + item.stack;
						if (!noText)
						{
							ItemText.NewText(newItem, item.stack, false, false);
						}
						this.DoCoins(i);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						return new Item();
					}
					Item item2 = item;
					item2.stack = item2.stack - (this.inventory[i].maxStack - this.inventory[i].stack);
					if (!noText)
					{
						ItemText.NewText(newItem, this.inventory[i].maxStack - this.inventory[i].stack, false, false);
					}
					this.inventory[i].stack = this.inventory[i].maxStack;
					this.DoCoins(i);
					if (plr == Main.myPlayer)
					{
						Recipe.FindRecipes();
					}
				}
			}
			if (item.type != ItemID.SandBlock && item.type != ItemID.FallenStar && item.type != ItemID.Gel && item.type != ItemID.PearlsandBlock && item.type != ItemID.EbonsandBlock && item.type != ItemID.CrimsandBlock && item.type != ItemID.Bone && !item.notAmmo)
			{
				for (int j = 54; j < 58; j++)
				{
					if (this.inventory[j].type == 0)
					{
						this.inventory[j] = item;
						if (!noText)
						{
							ItemText.NewText(newItem, newItem.stack, false, false);
						}
						this.DoCoins(j);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						return new Item();
					}
				}
			}
			return item;
		}

		public static byte FindClosest(Vector2 Position, int Width, int Height)
		{
			byte num = 0;
			int num1 = 0;
			while (num1 < 255)
			{
				if (!Main.player[num1].active)
				{
					num1++;
				}
				else
				{
					num = (byte)num1;
					break;
				}
			}
			float single = -1f;
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active && !Main.player[i].dead)
				{
					float single1 = Math.Abs(Main.player[i].position.X + (float)(Main.player[i].width / 2) - (Position.X + (float)(Width / 2))) + Math.Abs(Main.player[i].position.Y + (float)(Main.player[i].height / 2) - (Position.Y + (float)(Height / 2)));
					if (single == -1f || single1 < single)
					{
						single = single1;
						num = (byte)i;
					}
				}
			}
			return num;
		}

		public int FindItem(int netid)
		{
			for (int i = 0; i < 58; i++)
			{
				if (netid == this.inventory[i].netID && this.inventory[i].stack > 0)
				{
					return i;
				}
			}
			return -1;
		}

		public int FindItem(List<int> netids)
		{
			for (int i = 0; i < 58; i++)
			{
				if (this.inventory[i].stack > 0 && netids.Contains(this.inventory[i].netID))
				{
					return i;
				}
			}
			return -1;
		}

		public int FindItem(bool[] validtypes)
		{
			for (int i = 0; i < 58; i++)
			{
				if (this.inventory[i].stack > 0 && validtypes[this.inventory[i].type])
				{
					return i;
				}
			}
			return -1;
		}

		public void FindPulley()
		{
			if (this.controlUp || this.controlDown)
			{
				int x = (int)(this.position.X + (float)(this.width / 2)) / 16;
				int y = (int)(this.position.Y - 8f) / 16;
				if (Main.tile[x, y] != null && Main.tile[x, y].active() && Main.tileRope[Main.tile[x, y].type])
				{
					float single = this.position.Y;
					if (Main.tile[x, y - 1] == null)
					{
						Main.tile[x, y - 1] = new Tile();
					}
					if (Main.tile[x, y + 1] == null)
					{
						Main.tile[x, y + 1] = new Tile();
					}
					if ((!Main.tile[x, y - 1].active() || !Main.tileRope[Main.tile[x, y - 1].type]) && (!Main.tile[x, y + 1].active() || !Main.tileRope[Main.tile[x, y + 1].type]))
					{
						single = (float)(y * 16 + 22);
					}
					float single1 = (float)(x * 16 + 8 - this.width / 2 + 6 * this.direction);
					int num = x * 16 + 8 - this.width / 2 + 6;
					int num1 = x * 16 + 8 - this.width / 2;
					int num2 = x * 16 + 8 - this.width / 2 + -6;
					int num3 = 1;
					float single2 = Math.Abs(this.position.X - (float)num);
					if (Math.Abs(this.position.X - (float)num1) < single2)
					{
						num3 = 2;
						single2 = Math.Abs(this.position.X - (float)num1);
					}
					if (Math.Abs(this.position.X - (float)num2) < single2)
					{
						num3 = 3;
						single2 = Math.Abs(this.position.X - (float)num2);
					}
					if (num3 == 1)
					{
						single1 = (float)num;
						this.pulleyDir = 2;
						this.direction = 1;
					}
					if (num3 == 2)
					{
						single1 = (float)num1;
						this.pulleyDir = 1;
					}
					if (num3 == 3)
					{
						single1 = (float)num2;
						this.pulleyDir = 2;
						this.direction = -1;
					}
					if (!Collision.SolidCollision(new Vector2(single1, this.position.Y), this.width, this.height))
					{
						if (this.whoAmI == Main.myPlayer)
						{
							Main.cameraX = Main.cameraX + this.position.X - single1;
						}
						this.pulley = true;
						this.position.X = single1;
						this.gfxOffY = this.position.Y - single;
						this.stepSpeed = 2.5f;
						this.position.Y = single;
						this.velocity.X = 0f;
						return;
					}
					single1 = (float)num;
					this.pulleyDir = 2;
					this.direction = 1;
					if (!Collision.SolidCollision(new Vector2(single1, this.position.Y), this.width, this.height))
					{
						if (this.whoAmI == Main.myPlayer)
						{
							Main.cameraX = Main.cameraX + this.position.X - single1;
						}
						this.pulley = true;
						this.position.X = single1;
						this.gfxOffY = this.position.Y - single;
						this.stepSpeed = 2.5f;
						this.position.Y = single;
						this.velocity.X = 0f;
						return;
					}
					single1 = (float)num2;
					this.pulleyDir = 2;
					this.direction = -1;
					if (!Collision.SolidCollision(new Vector2(single1, this.position.Y), this.width, this.height))
					{
						if (this.whoAmI == Main.myPlayer)
						{
							Main.cameraX = Main.cameraX + this.position.X - single1;
						}
						this.pulley = true;
						this.position.X = single1;
						this.gfxOffY = this.position.Y - single;
						this.stepSpeed = 2.5f;
						this.position.Y = single;
						this.velocity.X = 0f;
					}
				}
			}
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

		public int FishingLevel()
		{
			int num = 0;
			int num1 = this.inventory[this.selectedItem].fishingPole;
			if (num1 == 0)
			{
				for (int i = 0; i < 58; i++)
				{
					if (this.inventory[i].fishingPole > num1)
					{
						num1 = this.inventory[i].fishingPole;
					}
				}
			}
			int num2 = 0;
			while (num2 < 58)
			{
				if (this.inventory[num2].stack <= 0 || this.inventory[num2].bait <= 0)
				{
					num2++;
				}
				else
				{
					if (this.inventory[num2].type == 2673)
					{
						return -1;
					}
					num = this.inventory[num2].bait;
					break;
				}
			}
			if (num == 0 || num1 == 0)
			{
				return 0;
			}
			int num3 = num + num1 + this.fishingSkill;
			if (Main.raining)
			{
				num3 = (int)((float)num3 * 1.2f);
			}
			if (Main.cloudBGAlpha > 0f)
			{
				num3 = (int)((float)num3 * 1.1f);
			}
			if (Main.dayTime && (Main.time < 5400 || Main.time > 48600))
			{
				num3 = (int)((float)num3 * 1.3f);
			}
			if (Main.dayTime && Main.time > 16200 && Main.time < 37800)
			{
				num3 = (int)((float)num3 * 0.8f);
			}
			if (!Main.dayTime && Main.time > 6480 && Main.time < 25920)
			{
				num3 = (int)((float)num3 * 0.8f);
			}
			if (Main.moonPhase == 0)
			{
				num3 = (int)((float)num3 * 1.1f);
			}
			if (Main.moonPhase == 1 || Main.moonPhase == 7)
			{
				num3 = (int)((float)num3 * 1.05f);
			}
			if (Main.moonPhase == 3 || Main.moonPhase == 5)
			{
				num3 = (int)((float)num3 * 0.95f);
			}
			if (Main.moonPhase == 4)
			{
				num3 = (int)((float)num3 * 0.9f);
			}
			return num3;
		}

		public void FloorVisuals(bool Falling)
		{
			int x = (int)((this.position.X + (float)(this.width / 2)) / 16f);
			int y = (int)((this.position.Y + (float)this.height) / 16f);
			if (this.gravDir == -1f)
			{
				y = (int)(this.position.Y - 0.1f) / 16;
			}
			int num = -1;
			if (Main.tile[x - 1, y] == null)
			{
				Main.tile[x - 1, y] = new Tile();
			}
			if (Main.tile[x + 1, y] == null)
			{
				Main.tile[x + 1, y] = new Tile();
			}
			if (Main.tile[x, y] == null)
			{
				Main.tile[x, y] = new Tile();
			}
			if (Main.tile[x, y].nactive() && Main.tileSolid[Main.tile[x, y].type])
			{
				num = Main.tile[x, y].type;
			}
			else if (Main.tile[x - 1, y].nactive() && Main.tileSolid[Main.tile[x - 1, y].type])
			{
				num = Main.tile[x - 1, y].type;
			}
			else if (Main.tile[x + 1, y].nactive() && Main.tileSolid[Main.tile[x + 1, y].type])
			{
				num = Main.tile[x + 1, y].type;
			}
			if (num <= -1)
			{
				this.slippy = false;
				this.slippy2 = false;
				this.sticky = false;
				this.powerrun = false;
				return;
			}
			this.sticky = num == 229;
			this.slippy = (num == 161 || num == 162 || num == 163 || num == 164 || num == 200 ? true : num == 127);
			this.slippy2 = num == 197;
			this.powerrun = num == 198;
			if (Main.tile[x - 1, y].slope() != 0 || Main.tile[x, y].slope() != 0 || Main.tile[x + 1, y].slope() != 0)
			{
				num = -1;
			}
		}

		public void GetAnglerReward()
		{
			Item item = new Item()
			{
				type = 0
			};
			float single = 1f;
			if (this.anglerQuestsFinished <= 50)
			{
				single = single - (float)this.anglerQuestsFinished * 0.01f;
			}
			else if (this.anglerQuestsFinished <= 100)
			{
				single = 0.5f - (float)(this.anglerQuestsFinished - 50) * 0.005f;
			}
			else if (this.anglerQuestsFinished <= 150)
			{
				single = 0.25f - (float)(this.anglerQuestsFinished - 100) * 0.002f;
			}
			if (this.anglerQuestsFinished == 5)
			{
				item.SetDefaults(2428, false);
			}
			else if (this.anglerQuestsFinished == 10)
			{
				item.SetDefaults(2367, false);
			}
			else if (this.anglerQuestsFinished == 15)
			{
				item.SetDefaults(2368, false);
			}
			else if (this.anglerQuestsFinished == 20)
			{
				item.SetDefaults(2369, false);
			}
			else if (this.anglerQuestsFinished == 30)
			{
				item.SetDefaults(2294, false);
			}
			else if (this.anglerQuestsFinished > 75 && Main.rand.Next((int)(250f * single)) == 0)
			{
				item.SetDefaults(2294, false);
			}
			else if (Main.hardMode && this.anglerQuestsFinished > 25 && Main.rand.Next((int)(100f * single)) == 0)
			{
				item.SetDefaults(2422, false);
			}
			else if (Main.hardMode && this.anglerQuestsFinished > 10 && Main.rand.Next((int)(70f * single)) == 0)
			{
				item.SetDefaults(2494, false);
			}
			else if (Main.hardMode && this.anglerQuestsFinished > 10 && Main.rand.Next((int)(70f * single)) == 0)
			{
				item.SetDefaults(3031, false);
			}
			else if (Main.hardMode && this.anglerQuestsFinished > 10 && Main.rand.Next((int)(70f * single)) == 0)
			{
				item.SetDefaults(3032, false);
			}
			else if (Main.rand.Next((int)(80f * single)) == 0)
			{
				item.SetDefaults(3183, false);
			}
			else if (Main.rand.Next((int)(60f * single)) == 0)
			{
				item.SetDefaults(2360, false);
			}
			else if (Main.rand.Next((int)(40f * single)) == 0)
			{
				item.SetDefaults(2373, false);
			}
			else if (Main.rand.Next((int)(40f * single)) == 0)
			{
				item.SetDefaults(2374, false);
			}
			else if (Main.rand.Next((int)(40f * single)) == 0)
			{
				item.SetDefaults(2375, false);
			}
			else if (Main.rand.Next((int)(40f * single)) == 0)
			{
				item.SetDefaults(3120, false);
			}
			else if (Main.rand.Next((int)(40f * single)) == 0)
			{
				item.SetDefaults(3037, false);
			}
			else if (Main.rand.Next((int)(40f * single)) == 0)
			{
				item.SetDefaults(3096, false);
			}
			else if (Main.rand.Next((int)(40f * single)) == 0)
			{
				item.SetDefaults(2417, false);
			}
			else if (Main.rand.Next((int)(40f * single)) != 0)
			{
				int num = Main.rand.Next(70);
				if (num == 0)
				{
					item.SetDefaults(2442, false);
				}
				else if (num == 1)
				{
					item.SetDefaults(2443, false);
				}
				else if (num == 2)
				{
					item.SetDefaults(2444, false);
				}
				else if (num == 3)
				{
					item.SetDefaults(2445, false);
				}
				else if (num == 4)
				{
					item.SetDefaults(2497, false);
				}
				else if (num == 5)
				{
					item.SetDefaults(2495, false);
				}
				else if (num == 6)
				{
					item.SetDefaults(2446, false);
				}
				else if (num == 7)
				{
					item.SetDefaults(2447, false);
				}
				else if (num == 8)
				{
					item.SetDefaults(2448, false);
				}
				else if (num == 9)
				{
					item.SetDefaults(2449, false);
				}
				else if (num == 10)
				{
					item.SetDefaults(2490, false);
				}
				else if (num == 11)
				{
					item.SetDefaults(2435, false);
					item.stack = Main.rand.Next(50, 151);
				}
				else if (num != 12)
				{
					int num1 = Main.rand.Next(3);
					if (num1 == 0)
					{
						item.SetDefaults(2354, false);
						item.stack = Main.rand.Next(2, 6);
					}
					else if (num1 != 1)
					{
						item.SetDefaults(2356, false);
						item.stack = Main.rand.Next(2, 6);
					}
					else
					{
						item.SetDefaults(2355, false);
						item.stack = Main.rand.Next(2, 6);
					}
				}
				else
				{
					item.SetDefaults(2496, false);
				}
			}
			else
			{
				item.SetDefaults(2498, false);
			}
			item.position = base.Center;
			Item item1 = this.GetItem(this.whoAmI, item, true, false);
			if (item1.stack > 0)
			{
				int num2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item1.type, item1.stack, false, 0, true);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num2, 1f, 0f, 0f, 0, 0, 0);
				}
			}
			if (item.type == ItemID.SeashellHairpin)
			{
				Item center = new Item();
				Item center1 = new Item();
				center.SetDefaults(2418, false);
				center.position = base.Center;
				item1 = this.GetItem(this.whoAmI, center, true, false);
				if (item1.stack > 0)
				{
					int num3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item1.type, item1.stack, false, 0, true);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num3, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				center1.SetDefaults(2419, false);
				center1.position = base.Center;
				item1 = this.GetItem(this.whoAmI, center1, true, false);
				if (item1.stack > 0)
				{
					int num4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item1.type, item1.stack, false, 0, true);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num4, 1f, 0f, 0f, 0, 0, 0);
					}
				}
			}
			else if (item.type == ItemID.FishCostumeMask)
			{
				Item item2 = new Item();
				Item center2 = new Item();
				item2.SetDefaults(2499, false);
				item2.position = base.Center;
				item1 = this.GetItem(this.whoAmI, item2, true, false);
				if (item1.stack > 0)
				{
					int num5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item1.type, item1.stack, false, 0, true);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num5, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				center2.SetDefaults(2500, false);
				center2.position = base.Center;
				item1 = this.GetItem(this.whoAmI, center2, true, false);
				if (item1.stack > 0)
				{
					int num6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item1.type, item1.stack, false, 0, true);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num6, 1f, 0f, 0f, 0, 0, 0);
					}
				}
			}
			Item item3 = new Item();
			int num7 = (this.anglerQuestsFinished + 50) / 2;
			num7 = (int)((float)(num7 * Main.rand.Next(50, 201)) * 0.015f);
			num7 = (int)((double)num7 * 1.5);
			if (Main.expertMode)
			{
				num7 = num7 * 2;
			}
			if (num7 <= 100)
			{
				if (num7 > 99)
				{
					num7 = 99;
				}
				if (num7 < 1)
				{
					num7 = 1;
				}
				item3.SetDefaults(72, false);
				item3.stack = num7;
			}
			else
			{
				num7 = num7 / 100;
				if (num7 > 10)
				{
					num7 = 10;
				}
				if (num7 < 1)
				{
					num7 = 1;
				}
				item3.SetDefaults(73, false);
				item3.stack = num7;
			}
			item3.position = base.Center;
			item1 = this.GetItem(this.whoAmI, item3, true, false);
			if (item1.stack > 0)
			{
				int num8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item1.type, item1.stack, false, 0, true);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num8, 1f, 0f, 0f, 0, 0, 0);
				}
			}
			if (Main.rand.Next((int)(100f * single)) <= 50)
			{
				Item center3 = new Item();
				if (Main.rand.Next((int)(15f * single)) == 0)
				{
					center3.SetDefaults(2676, false);
				}
				else if (Main.rand.Next((int)(5f * single)) != 0)
				{
					center3.SetDefaults(2674, false);
				}
				else
				{
					center3.SetDefaults(2675, false);
				}
				if (Main.rand.Next(25) <= this.anglerQuestsFinished)
				{
					Item item4 = center3;
					item4.stack = item4.stack + 1;
				}
				if (Main.rand.Next(50) <= this.anglerQuestsFinished)
				{
					Item item5 = center3;
					item5.stack = item5.stack + 1;
				}
				if (Main.rand.Next(100) <= this.anglerQuestsFinished)
				{
					Item item6 = center3;
					item6.stack = item6.stack + 1;
				}
				if (Main.rand.Next(150) <= this.anglerQuestsFinished)
				{
					Item item7 = center3;
					item7.stack = item7.stack + 1;
				}
				if (Main.rand.Next(200) <= this.anglerQuestsFinished)
				{
					Item item8 = center3;
					item8.stack = item8.stack + 1;
				}
				if (Main.rand.Next(250) <= this.anglerQuestsFinished)
				{
					Item item9 = center3;
					item9.stack = item9.stack + 1;
				}
				center3.position = base.Center;
				item1 = this.GetItem(this.whoAmI, center3, true, false);
				if (item1.stack > 0)
				{
					int num9 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item1.type, item1.stack, false, 0, true);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num9, 1f, 0f, 0f, 0, 0, 0);
					}
				}
			}
		}

		public Color GetDeathAlpha(Color newColor)
		{
			int r = newColor.R + (int)((double)this.immuneAlpha * 0.9);
			int g = newColor.G + (int)((double)this.immuneAlpha * 0.5);
			int b = newColor.B + (int)((double)this.immuneAlpha * 0.5);
			int a = newColor.A + (int)((double)this.immuneAlpha * 0.4);
			if (a < 0)
			{
				a = 0;
			}
			if (a > 255)
			{
				a = 255;
			}
			return new Color(r, g, b, a);
		}

		public int getDPS()
		{
			TimeSpan timeSpan = this.dpsEnd - this.dpsStart;
			float milliseconds = (float)timeSpan.Milliseconds / 1000f;
			milliseconds = milliseconds + (float)timeSpan.Seconds;
			milliseconds = milliseconds + (float)timeSpan.Minutes / 60f;
			if (milliseconds >= 3f)
			{
				this.dpsStart = DateTime.Now;
				this.dpsStart = this.dpsStart.AddSeconds(-1);
				this.dpsDamage = (int)((float)this.dpsDamage / milliseconds);
				timeSpan = this.dpsEnd - this.dpsStart;
				milliseconds = (float)timeSpan.Milliseconds / 1000f;
				milliseconds = milliseconds + (float)timeSpan.Seconds;
				milliseconds = milliseconds + (float)timeSpan.Minutes / 60f;
			}
			if (milliseconds < 1f)
			{
				milliseconds = 1f;
			}
			return (int)((float)this.dpsDamage / milliseconds);
		}

		public void GetDyeTraderReward()
		{
			int item = -1;
			List<int> nums = new List<int>()
			{
				3560,
				3028,
				3041,
				3040,
				3025,
				3190,
				3027,
				3026,
				3554,
				3553,
				3555,
				2872,
				3534,
				2871
			};
			List<int> nums1 = nums;
			if (Main.hardMode)
			{
				nums1.Add(3039);
				nums1.Add(3038);
				nums1.Add(3598);
				nums1.Add(3597);
				nums1.Add(3600);
				nums1.Add(3042);
				nums1.Add(3533);
				nums1.Add(3561);
				if (NPC.downedMechBossAny)
				{
					nums1.Add(2883);
					nums1.Add(2869);
					nums1.Add(2873);
					nums1.Add(2870);
				}
				if (NPC.downedPlantBoss)
				{
					nums1.Add(2878);
					nums1.Add(2879);
					nums1.Add(2884);
					nums1.Add(2885);
				}
				if (NPC.downedMartians)
				{
					nums1.Add(2864);
					nums1.Add(3556);
				}
				if (NPC.downedMoonlord)
				{
					nums1.Add(3024);
				}
			}
			item = nums1[Main.rand.Next(nums1.Count)];
			Item center = new Item();
			center.SetDefaults(item, false);
			center.stack = 3;
			center.position = base.Center;
			Item item1 = this.GetItem(this.whoAmI, center, true, false);
			if (item1.stack > 0)
			{
				int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item1.type, item1.stack, false, 0, true);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num, 1f, 0f, 0f, 0, 0, 0);
				}
			}
		}

		public static PlayerFileData GetFileData(string file)
		{
			if (file == null || !File.Exists(file))
			{
				return null;
			}
			PlayerFileData playerFileDatum = Player.LoadPlayer(file);
			if (playerFileDatum.Player == null)
			{
				return null;
			}
			if (playerFileDatum.Player.loadStatus != 0 && playerFileDatum.Player.loadStatus != 1)
			{
				if (FileUtilities.Exists(string.Concat(file, ".bak")))
				{
					FileUtilities.Move(string.Concat(file, ".bak"), file, true);
				}
				playerFileDatum = Player.LoadPlayer(file);
				if (playerFileDatum.Player == null)
				{
					return null;
				}
			}
			return playerFileDatum;
		}


		public Color GetImmuneAlpha(Color newColor, float alphaReduction)
		{
			float single = (float)(255 - this.immuneAlpha) / 255f;
			if (alphaReduction > 0f)
			{
				single = single * (1f - alphaReduction);
			}
			if (this.immuneAlpha > 125)
			{
				return Color.Transparent;
			}
			return Color.Multiply(newColor, single);
		}

		public Color GetImmuneAlphaPure(Color newColor, float alphaReduction)
		{
			float single = (float)(255 - this.immuneAlpha) / 255f;
			if (alphaReduction > 0f)
			{
				single = single * (1f - alphaReduction);
			}
			return Color.Multiply(newColor, single);
		}

		public Item GetItem(int plr, Item newItem, bool longText = false, bool noText = false)
		{
			bool flag = (newItem.type < 71 ? false : newItem.type <= ItemID.PlatinumCoin);
			Item item = newItem;
			int num = 50;
			if (newItem.noGrabDelay > 0)
			{
				return item;
			}
			int num1 = 0;
			if (newItem.uniqueStack && this.HasItem(newItem.type))
			{
				return item;
			}
			if (newItem.type == ItemID.CopperCoin || newItem.type == ItemID.SilverCoin || newItem.type == ItemID.GoldCoin || newItem.type == ItemID.PlatinumCoin)
			{
				num1 = -4;
				num = 54;
			}
			if (item.ammo > 0 && !item.notAmmo)
			{
				item = this.FillAmmo(plr, item, noText);
				if (item.type == ItemID.None || item.stack == 0)
				{
					return new Item();
				}
			}
			for (int i = num1; i < 50; i++)
			{
				int num2 = i;
				if (num2 < 0)
				{
					num2 = 54 + i;
				}
				if (this.inventory[num2].type > 0 && this.inventory[num2].stack < this.inventory[num2].maxStack && item.IsTheSameAs(this.inventory[num2]))
				{
					if (item.stack + this.inventory[num2].stack <= this.inventory[num2].maxStack)
					{
						Item item1 = this.inventory[num2];
						item1.stack = item1.stack + item.stack;
						if (!noText)
						{
							ItemText.NewText(newItem, item.stack, false, longText);
						}
						this.DoCoins(num2);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						AchievementsHelper.NotifyItemPickup(this, item);
						return new Item();
					}
					AchievementsHelper.NotifyItemPickup(this, item, this.inventory[num2].maxStack - this.inventory[num2].stack);
					Item item2 = item;
					item2.stack = item2.stack - (this.inventory[num2].maxStack - this.inventory[num2].stack);
					if (!noText)
					{
						ItemText.NewText(newItem, this.inventory[num2].maxStack - this.inventory[num2].stack, false, longText);
					}
					this.inventory[num2].stack = this.inventory[num2].maxStack;
					this.DoCoins(num2);
					if (plr == Main.myPlayer)
					{
						Recipe.FindRecipes();
					}
				}
			}
			if (newItem.type != ItemID.CopperCoin && newItem.type != ItemID.SilverCoin && newItem.type != ItemID.GoldCoin && newItem.type != ItemID.PlatinumCoin && newItem.useStyle > 0)
			{
				for (int j = 0; j < 10; j++)
				{
					if (this.inventory[j].type == 0)
					{
						this.inventory[j] = item;
						if (!noText)
						{
							ItemText.NewText(newItem, newItem.stack, false, longText);
						}
						this.DoCoins(j);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						AchievementsHelper.NotifyItemPickup(this, item);
						return new Item();
					}
				}
			}
			if (!newItem.favorited)
			{
				for (int k = num - 1; k >= 0; k--)
				{
					if (this.inventory[k].type == 0)
					{
						this.inventory[k] = item;
						if (!noText)
						{
							ItemText.NewText(newItem, newItem.stack, false, longText);
						}
						this.DoCoins(k);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						AchievementsHelper.NotifyItemPickup(this, item);
						return new Item();
					}
				}
			}
			else
			{
				for (int l = 0; l < num; l++)
				{
					if (this.inventory[l].type == 0)
					{
						this.inventory[l] = item;
						if (!noText)
						{
							ItemText.NewText(newItem, newItem.stack, false, longText);
						}
						this.DoCoins(l);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						AchievementsHelper.NotifyItemPickup(this, item);
						return new Item();
					}
				}
			}
			return item;
		}

		public Rectangle getRect()
		{
			return new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
		}

		public float GetWeaponKnockback(Item sItem, float KnockBack)
		{
			if (sItem.summon)
			{
				KnockBack += this.minionKB;
			}
			if (sItem.melee && this.kbGlove)
			{
				KnockBack *= 2f;
			}
			if (this.kbBuff)
			{
				KnockBack *= 1.5f;
			}
			if (sItem.ranged && this.shroomiteStealth)
			{
				KnockBack *= 1f + (1f - this.stealth) * 0.5f;
			}
			if (sItem.ranged && this.setVortex)
			{
				KnockBack *= 1f + (1f - this.stealth) * 0.5f;
			}
			return KnockBack;
		}
		public int GetWeaponDamage(Item sItem)
		{
			int num = sItem.damage;
			if (num > 0)
			{
				if (sItem.melee)
				{
					num = (int)((float)num * this.meleeDamage + 5E-06f);
				}
				else if (sItem.ranged)
				{
					num = (int)((float)num * this.rangedDamage + 5E-06f);
					if (sItem.useAmmo == 1 || sItem.useAmmo == 323)
					{
						num = (int)((float)num * this.arrowDamage + 5E-06f);
					}
					if (sItem.useAmmo == 14 || sItem.useAmmo == 311)
					{
						num = (int)((float)num * this.bulletDamage + 5E-06f);
					}
					if (sItem.useAmmo == 771 || sItem.useAmmo == 246 || sItem.useAmmo == 312 || sItem.useAmmo == 514)
					{
						num = (int)((float)num * this.rocketDamage + 5E-06f);
					}
				}
				else if (sItem.thrown)
				{
					num = (int)((float)num * this.thrownDamage + 5E-06f);
				}
				else if (sItem.magic)
				{
					num = (int)((float)num * this.magicDamage + 5E-06f);
				}
				else if (sItem.summon)
				{
					num = (int)((float)num * this.minionDamage);
				}
			}
			return num;
		}

		public void Ghost()
		{
		}

		private void GrabItems(int i)
		{
			for (int num = 0; num < 400; num++)
			{
				if (Main.item[num].active && Main.item[num].noGrabDelay == 0 && Main.item[num].owner == i)
				{
					int num1 = Player.defaultItemGrabRange;
					if (this.goldRing && Main.item[num].type >= 71 && Main.item[num].type <= 74)
					{
						num1 = num1 + Item.coinGrabRange;
					}
					if (this.manaMagnet && (Main.item[num].type == 184 || Main.item[num].type == 1735 || Main.item[num].type == 1868))
					{
						num1 = num1 + Item.manaGrabRange;
					}
					if (this.lifeMagnet && (Main.item[num].type == 58 || Main.item[num].type == 1734 || Main.item[num].type == 1867))
					{
						num1 = num1 + Item.lifeGrabRange;
					}
					if (ItemID.Sets.NebulaPickup[Main.item[num].type])
					{
						num1 = num1 + 100;
					}
					if ((new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height)).Intersects(new Rectangle((int)Main.item[num].position.X, (int)Main.item[num].position.Y, Main.item[num].width, Main.item[num].height)))
					{
						if (i == Main.myPlayer && (this.inventory[this.selectedItem].type != 0 || this.itemAnimation <= 0))
						{
							if (ItemID.Sets.NebulaPickup[Main.item[num].type])
							{
								int num2 = Main.item[num].buffType;
								Main.item[num] = new Item();
								if (Main.netMode != 1)
								{
									this.NebulaLevelup(num2);
								}
								else
								{
									NetMessage.SendData((int)PacketTypes.NebulaLevelUp, -1, -1, "", i, (float)num2, base.Center.X, base.Center.Y, 0, 0, 0);
									NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num, 0f, 0f, 0f, 0, 0, 0);
								}
							}
							if (Main.item[num].type == 58 || Main.item[num].type == 1734 || Main.item[num].type == 1867)
							{
								Player player = this;
								player.statLife = player.statLife + 20;
								if (Main.myPlayer == this.whoAmI)
								{
									this.HealEffect(20, true);
								}
								if (this.statLife > this.statLifeMax2)
								{
									this.statLife = this.statLifeMax2;
								}
								Main.item[num] = new Item();
								if (Main.netMode == 1)
								{
									NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num, 0f, 0f, 0f, 0, 0, 0);
								}
							}
							else if (Main.item[num].type == 184 || Main.item[num].type == 1735 || Main.item[num].type == 1868)
							{
								Player player1 = this;
								player1.statMana = player1.statMana + 100;
								if (Main.myPlayer == this.whoAmI)
								{
									this.ManaEffect(100);
								}
								if (this.statMana > this.statManaMax2)
								{
									this.statMana = this.statManaMax2;
								}
								Main.item[num] = new Item();
								if (Main.netMode == 1)
								{
									NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num, 0f, 0f, 0f, 0, 0, 0);
								}
							}
							else
							{
								Main.item[num] = this.GetItem(i, Main.item[num], false, false);
								if (Main.netMode == 1)
								{
									NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num, 0f, 0f, 0f, 0, 0, 0);
								}
							}
						}
					}
					else if ((new Rectangle((int)this.position.X - num1, (int)this.position.Y - num1, this.width + num1 * 2, this.height + num1 * 2)).Intersects(new Rectangle((int)Main.item[num].position.X, (int)Main.item[num].position.Y, Main.item[num].width, Main.item[num].height)) && this.ItemSpace(Main.item[num]))
					{
						Main.item[num].beingGrabbed = true;
						if (this.manaMagnet && (Main.item[num].type == 184 || Main.item[num].type == 1735 || Main.item[num].type == 1868))
						{
							float single = 12f;
							Vector2 vector2 = new Vector2(Main.item[num].position.X + (float)(Main.item[num].width / 2), Main.item[num].position.Y + (float)(Main.item[num].height / 2));
							float x = base.Center.X - vector2.X;
							float y = base.Center.Y - vector2.Y;
							float single1 = (float)Math.Sqrt((double)(x * x + y * y));
							single1 = single / single1;
							x = x * single1;
							y = y * single1;
							int num3 = 5;
							Main.item[num].velocity.X = (Main.item[num].velocity.X * (float)(num3 - 1) + x) / (float)num3;
							Main.item[num].velocity.Y = (Main.item[num].velocity.Y * (float)(num3 - 1) + y) / (float)num3;
						}
						else if (this.lifeMagnet && (Main.item[num].type == 58 || Main.item[num].type == 1734 || Main.item[num].type == 1867))
						{
							float single2 = 15f;
							Vector2 vector21 = new Vector2(Main.item[num].position.X + (float)(Main.item[num].width / 2), Main.item[num].position.Y + (float)(Main.item[num].height / 2));
							float x1 = base.Center.X - vector21.X;
							float y1 = base.Center.Y - vector21.Y;
							float single3 = (float)Math.Sqrt((double)(x1 * x1 + y1 * y1));
							single3 = single2 / single3;
							x1 = x1 * single3;
							y1 = y1 * single3;
							int num4 = 5;
							Main.item[num].velocity.X = (Main.item[num].velocity.X * (float)(num4 - 1) + x1) / (float)num4;
							Main.item[num].velocity.Y = (Main.item[num].velocity.Y * (float)(num4 - 1) + y1) / (float)num4;
						}
						else if (this.goldRing && Main.item[num].type >= 71 && Main.item[num].type <= 74)
						{
							float single4 = 12f;
							Vector2 vector22 = new Vector2(Main.item[num].position.X + (float)(Main.item[num].width / 2), Main.item[num].position.Y + (float)(Main.item[num].height / 2));
							float x2 = base.Center.X - vector22.X;
							float y2 = base.Center.Y - vector22.Y;
							float single5 = (float)Math.Sqrt((double)(x2 * x2 + y2 * y2));
							single5 = single4 / single5;
							x2 = x2 * single5;
							y2 = y2 * single5;
							int num5 = 5;
							Main.item[num].velocity.X = (Main.item[num].velocity.X * (float)(num5 - 1) + x2) / (float)num5;
							Main.item[num].velocity.Y = (Main.item[num].velocity.Y * (float)(num5 - 1) + y2) / (float)num5;
						}
						else if (!ItemID.Sets.NebulaPickup[Main.item[num].type])
						{
							if ((double)this.position.X + (double)this.width * 0.5 <= (double)Main.item[num].position.X + (double)Main.item[num].width * 0.5)
							{
								if (Main.item[num].velocity.X > -Player.itemGrabSpeedMax + this.velocity.X)
								{
									Main.item[num].velocity.X = Main.item[num].velocity.X - Player.itemGrabSpeed;
								}
								if (Main.item[num].velocity.X > 0f)
								{
									Main.item[num].velocity.X = Main.item[num].velocity.X - Player.itemGrabSpeed * 0.75f;
								}
							}
							else
							{
								if (Main.item[num].velocity.X < Player.itemGrabSpeedMax + this.velocity.X)
								{
									Main.item[num].velocity.X = Main.item[num].velocity.X + Player.itemGrabSpeed;
								}
								if (Main.item[num].velocity.X < 0f)
								{
									Main.item[num].velocity.X = Main.item[num].velocity.X + Player.itemGrabSpeed * 0.75f;
								}
							}
							if ((double)this.position.Y + (double)this.height * 0.5 <= (double)Main.item[num].position.Y + (double)Main.item[num].height * 0.5)
							{
								if (Main.item[num].velocity.Y > -Player.itemGrabSpeedMax)
								{
									Main.item[num].velocity.Y = Main.item[num].velocity.Y - Player.itemGrabSpeed;
								}
								if (Main.item[num].velocity.Y > 0f)
								{
									Main.item[num].velocity.Y = Main.item[num].velocity.Y - Player.itemGrabSpeed * 0.75f;
								}
							}
							else
							{
								if (Main.item[num].velocity.Y < Player.itemGrabSpeedMax)
								{
									Main.item[num].velocity.Y = Main.item[num].velocity.Y + Player.itemGrabSpeed;
								}
								if (Main.item[num].velocity.Y < 0f)
								{
									Main.item[num].velocity.Y = Main.item[num].velocity.Y + Player.itemGrabSpeed * 0.75f;
								}
							}
						}
						else
						{
							float single6 = 12f;
							Vector2 vector23 = new Vector2(Main.item[num].position.X + (float)(Main.item[num].width / 2), Main.item[num].position.Y + (float)(Main.item[num].height / 2));
							float x3 = base.Center.X - vector23.X;
							float y3 = base.Center.Y - vector23.Y;
							float single7 = (float)Math.Sqrt((double)(x3 * x3 + y3 * y3));
							single7 = single6 / single7;
							x3 = x3 * single7;
							y3 = y3 * single7;
							int num6 = 5;
							Main.item[num].velocity.X = (Main.item[num].velocity.X * (float)(num6 - 1) + x3) / (float)num6;
							Main.item[num].velocity.Y = (Main.item[num].velocity.Y * (float)(num6 - 1) + y3) / (float)num6;
						}
					}
				}
			}
		}

		public void GrappleMovement()
		{
			Vector2 vector2 = new Vector2();
			if (this.grappling[0] >= 0)
			{
				if (Main.myPlayer == this.whoAmI && this.mount.Active)
				{
					this.mount.Dismount(this);
				}
				this.canCarpet = true;
				this.carpetFrame = -1;
				this.wingFrame = 1;
				if (this.velocity.Y == 0f || this.wet && (double)this.velocity.Y > -0.02 && (double)this.velocity.Y < 0.02)
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
				int num = -1;
				float x = 0f;
				float y = 0f;
				for (int i = 0; i < this.grapCount; i++)
				{
					Projectile projectile = Main.projectile[this.grappling[i]];
					x = x + (projectile.position.X + (float)(projectile.width / 2));
					y = y + (projectile.position.Y + (float)(projectile.height / 2));
					if (projectile.type == TileID.HallowSandstone)
					{
						num = i;
					}
					else if (projectile.type == ProjectileID.AntiGravityHook)
					{
						Vector2 vector21 = new Vector2((float)(this.controlRight.ToInt() - this.controlLeft.ToInt()), (float)(this.controlDown.ToInt() - this.controlUp.ToInt()));
						if (vector21 != Vector2.Zero)
						{
							vector21.Normalize();
						}
						vector21 = vector21 * 100f;
						Vector2 unitY = Vector2.Normalize((base.Center - projectile.Center) + vector21);
						if (float.IsNaN(unitY.X) || float.IsNaN(unitY.Y))
						{
							unitY = -Vector2.UnitY;
						}
						float single = 200f;
						x = x + unitY.X * single;
						y = y + unitY.Y * single;
					}
				}
				x = x / (float)this.grapCount;
				y = y / (float)this.grapCount;
				Vector2 vector22 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float x1 = x - vector22.X;
				float y1 = y - vector22.Y;
				float single1 = (float)Math.Sqrt((double)(x1 * x1 + y1 * y1));
				float single2 = 11f;
				if (Main.projectile[this.grappling[0]].type == 315)
				{
					single2 = 16f;
				}
				if (Main.projectile[this.grappling[0]].type >= 646 && Main.projectile[this.grappling[0]].type <= 649)
				{
					single2 = 13f;
				}
				float single3 = single1;
				single3 = (single1 <= single2 ? 1f : single2 / single1);
				x1 = x1 * single3;
				y1 = y1 * single3;
				if (y1 > 0f)
				{
					this.GoingDownWithGrapple = true;
				}
				this.velocity.X = x1;
				this.velocity.Y = y1;
				if (num != -1)
				{
					Projectile projectile1 = Main.projectile[this.grappling[num]];
					if (projectile1.position.X < this.position.X + (float)this.width && projectile1.position.X + (float)projectile1.width >= this.position.X && projectile1.position.Y < this.position.Y + (float)this.height && projectile1.position.Y + (float)projectile1.height >= this.position.Y)
					{
						int num1 = (int)(projectile1.position.X + (float)(projectile1.width / 2)) / 16;
						int y2 = (int)(projectile1.position.Y + (float)(projectile1.height / 2)) / 16;
						this.velocity = Vector2.Zero;
						if (Main.tile[num1, y2].type == TileID.MinecartTrack)
						{
							vector2.X = projectile1.position.X + (float)(projectile1.width / 2) - (float)(this.width / 2);
							vector2.Y = projectile1.position.Y + (float)(projectile1.height / 2) - (float)(this.height / 2);
							this.trashItem = new Item();
							this.grappling[0] = -1;
							this.grapCount = 0;
							for (int j = 0; j < 1000; j++)
							{
								if (Main.projectile[j].active && Main.projectile[j].owner == this.whoAmI && Main.projectile[j].aiStyle == 7)
								{
									Main.projectile[j].Kill();
								}
							}
							int num2 = 13;
							if (this.miscEquips[2].stack > 0 && this.miscEquips[2].mountType >= 0 && MountID.Sets.Cart[this.miscEquips[2].mountType] && (!this.miscEquips[2].expertOnly || Main.expertMode))
							{
								num2 = this.miscEquips[2].mountType;
							}
							int heightBoost = this.height + Mount.GetHeightBoost(num2);
							if (Minecart.GetOnTrack(num1, y2, ref vector2, this.width, heightBoost) && !Collision.SolidCollision(vector2, this.width, heightBoost - 20))
							{
								this.position = vector2;
								DelegateMethods.Minecart.rotation = this.fullRotation;
								DelegateMethods.Minecart.rotationOrigin = this.fullRotationOrigin;
								this.mount.SetMount(num2, this, this.minecartLeft);
							}
						}
					}
				}
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
				if (!this.controlJump)
				{
					this.releaseJump = true;
				}
				else if (this.releaseJump)
				{
					if ((this.velocity.Y == 0f || this.wet && (double)this.velocity.Y > -0.02 && (double)this.velocity.Y < 0.02) && !this.controlDown)
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
					if (this.doubleJumpCloud)
					{
						this.jumpAgainCloud = true;
					}
					if (this.doubleJumpSandstorm)
					{
						this.jumpAgainSandstorm = true;
					}
					if (this.doubleJumpBlizzard)
					{
						this.jumpAgainBlizzard = true;
					}
					if (this.doubleJumpFart)
					{
						this.jumpAgainFart = true;
					}
					if (this.doubleJumpSail)
					{
						this.jumpAgainSail = true;
					}
					if (this.doubleJumpUnicorn)
					{
						this.jumpAgainUnicorn = true;
					}
					this.grappling[0] = 0;
					this.grapCount = 0;
					for (int k = 0; k < 1000; k++)
					{
						if (Main.projectile[k].active && Main.projectile[k].owner == this.whoAmI && Main.projectile[k].aiStyle == 7)
						{
							Main.projectile[k].Kill();
						}
					}
					return;
				}
			}
		}

		public bool HasAmmo(Item sItem, bool canUse)
		{
			if (sItem.useAmmo > 0)
			{
				canUse = false;
				int num = 0;
				while (num < 58)
				{
					if (this.inventory[num].ammo != sItem.useAmmo || this.inventory[num].stack <= 0)
					{
						num++;
					}
					else
					{
						canUse = true;
						break;
					}
				}
			}
			return canUse;
		}

		public int HasBuff(int type)
		{
			if (this.buffImmune[type])
			{
				return -1;
			}
			for (int i = 0; i < 22; i++)
			{
				if (this.buffTime[i] >= 1 && this.buffType[i] == type)
				{
					return i;
				}
			}
			return -1;
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

		public bool HasUnityPotion()
		{
			for (int i = 0; i < 58; i++)
			{
				if (this.inventory[i].type == 2997 && this.inventory[i].stack > 0)
				{
					return true;
				}
			}
			return false;
		}

		public void HealEffect(int healAmount, bool broadcast = true)
		{
			CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), CombatText.HealLife, string.Concat(healAmount), false, false);
			if (broadcast && Main.netMode == 1 && this.whoAmI == Main.myPlayer)
			{
				NetMessage.SendData((int)PacketTypes.EffectHeal, -1, -1, "", this.whoAmI, (float)healAmount, 0f, 0f, 0, 0, 0);
			}
		}

		public void HoneyCollision(bool fallThrough, bool ignorePlats)
		{
			int num;
			num = (!this.onTrack ? this.height : this.height - 20);
			Vector2 vector2 = this.velocity;
			this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, num, fallThrough, ignorePlats, (int)this.gravDir);
			Vector2 x = this.velocity * 0.25f;
			if (this.velocity.X != vector2.X)
			{
				x.X = this.velocity.X;
			}
			if (this.velocity.Y != vector2.Y)
			{
				x.Y = this.velocity.Y;
			}
			Player player = this;
			player.position = player.position + x;
		}

		public void HorizontalMovement()
		{
			if (this.chilled)
			{
				this.accRunSpeed = this.maxRunSpeed;
			}
			bool flag = (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn ? this.mount.AllowDirectionChange : false);
			if (this.trackBoost != 0f)
			{
				this.velocity.X = this.velocity.X + this.trackBoost;
				this.trackBoost = 0f;
				if (this.velocity.X < 0f)
				{
					if (this.velocity.X < -this.maxRunSpeed)
					{
						this.velocity.X = -this.maxRunSpeed;
					}
				}
				else if (this.velocity.X > this.maxRunSpeed)
				{
					this.velocity.X = this.maxRunSpeed;
				}
			}
			if (this.controlLeft && this.velocity.X > -this.maxRunSpeed)
			{
				if (!this.mount.Active || !this.mount.Cart || this.velocity.Y == 0f)
				{
					if (this.velocity.X > this.runSlowdown)
					{
						this.velocity.X = this.velocity.X - this.runSlowdown;
					}
					this.velocity.X = this.velocity.X - this.runAcceleration;
				}
				if (this.onWrongGround)
				{
					if (this.velocity.X >= -this.runSlowdown)
					{
						this.velocity.X = 0f;
					}
					else
					{
						this.velocity.X = this.velocity.X + this.runSlowdown;
					}
				}
				if (!this.mount.Active || !this.mount.Cart || this.onWrongGround)
				{
					if (!this.sandStorm && (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn) && this.mount.AllowDirectionChange)
					{
						this.direction = -1;
					}
				}
				else if (this.velocity.X < 0f && flag)
				{
					this.direction = -1;
				}
			}
			else if (this.controlRight && this.velocity.X < this.maxRunSpeed)
			{
				if (!this.mount.Active || !this.mount.Cart || this.velocity.Y == 0f)
				{
					if (this.velocity.X < -this.runSlowdown)
					{
						this.velocity.X = this.velocity.X + this.runSlowdown;
					}
					this.velocity.X = this.velocity.X + this.runAcceleration;
				}
				if (this.onWrongGround)
				{
					if (this.velocity.X <= this.runSlowdown)
					{
						this.velocity.X = 0f;
					}
					else
					{
						this.velocity.X = this.velocity.X - this.runSlowdown;
					}
				}
				if (!this.mount.Active || !this.mount.Cart || this.onWrongGround)
				{
					if (!this.sandStorm && (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn) && this.mount.AllowDirectionChange)
					{
						this.direction = 1;
					}
				}
				else if (this.velocity.X > 0f && flag)
				{
					this.direction = 1;
				}
			}
			else if (this.controlLeft && this.velocity.X > -this.accRunSpeed && this.dashDelay >= 0)
			{
				if (this.mount.Active && this.mount.Cart)
				{
					if (this.velocity.X < 0f)
					{
						this.direction = -1;
					}
				}
				else if ((this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn) && this.mount.AllowDirectionChange)
				{
					this.direction = -1;
				}
				if (this.velocity.Y == 0f || this.wingsLogic > 0 || this.mount.CanFly)
				{
					if (this.velocity.X > this.runSlowdown)
					{
						this.velocity.X = this.velocity.X - this.runSlowdown;
					}
					this.velocity.X = this.velocity.X - this.runAcceleration * 0.2f;
					if (this.wingsLogic > 0)
					{
						this.velocity.X = this.velocity.X - this.runAcceleration * 0.2f;
					}
				}
				if (this.onWrongGround)
				{
					if (this.velocity.X >= this.runSlowdown)
					{
						this.velocity.X = 0f;
					}
					else
					{
						this.velocity.X = this.velocity.X + this.runSlowdown;
					}
				}
			}
			else if (this.controlRight && this.velocity.X < this.accRunSpeed && this.dashDelay >= 0)
			{
				if (this.mount.Active && this.mount.Cart)
				{
					if (this.velocity.X > 0f)
					{
						this.direction = -1;
					}
				}
				else if ((this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn) && this.mount.AllowDirectionChange)
				{
					this.direction = 1;
				}
				if (this.velocity.Y == 0f || this.wingsLogic > 0 || this.mount.CanFly)
				{
					if (this.velocity.X < -this.runSlowdown)
					{
						this.velocity.X = this.velocity.X + this.runSlowdown;
					}
					this.velocity.X = this.velocity.X + this.runAcceleration * 0.2f;
					if (this.wingsLogic > 0)
					{
						this.velocity.X = this.velocity.X + this.runAcceleration * 0.2f;
					}
				}
				if (this.onWrongGround)
				{
					if (this.velocity.X <= this.runSlowdown)
					{
						this.velocity.X = 0f;
					}
					else
					{
						this.velocity.X = this.velocity.X - this.runSlowdown;
					}
				}
			}
			else if (this.mount.Active && this.mount.Cart && Math.Abs(this.velocity.X) >= 1f)
			{
				if (this.onWrongGround)
				{
					if (this.velocity.X > 0f)
					{
						if (this.velocity.X <= this.runSlowdown)
						{
							this.velocity.X = 0f;
						}
						else
						{
							this.velocity.X = this.velocity.X - this.runSlowdown;
						}
					}
					else if (this.velocity.X < 0f)
					{
						if (this.velocity.X >= -this.runSlowdown)
						{
							this.velocity.X = 0f;
						}
						else
						{
							this.velocity.X = this.velocity.X + this.runSlowdown;
						}
					}
				}
				if (this.velocity.X > this.maxRunSpeed)
				{
					this.velocity.X = this.maxRunSpeed;
				}
				if (this.velocity.X < -this.maxRunSpeed)
				{
					this.velocity.X = -this.maxRunSpeed;
				}
			}
			else if (this.velocity.Y != 0f)
			{
				if (!this.PortalPhysicsEnabled)
				{
					if ((double)this.velocity.X > (double)this.runSlowdown * 0.5)
					{
						this.velocity.X = this.velocity.X - this.runSlowdown * 0.5f;
					}
					else if ((double)this.velocity.X >= (double)(-this.runSlowdown) * 0.5)
					{
						this.velocity.X = 0f;
					}
					else
					{
						this.velocity.X = this.velocity.X + this.runSlowdown * 0.5f;
					}
				}
			}
			else if (this.velocity.X > this.runSlowdown)
			{
				this.velocity.X = this.velocity.X - this.runSlowdown;
			}
			else if (this.velocity.X >= -this.runSlowdown)
			{
				this.velocity.X = 0f;
			}
			else
			{
				this.velocity.X = this.velocity.X + this.runSlowdown;
			}
			if (this.mount.Active && this.mount.Type == 10 && Math.Abs(this.velocity.X) > this.mount.DashSpeed - this.mount.RunSpeed / 2f)
			{
				Rectangle rect = this.getRect();
				if (this.direction == 1)
				{
					rect.Offset(this.width - 1, 0);
				}
				rect.Width = 2;
				rect.Inflate(6, 12);
				for (int m = 0; m < 200; m++)
				{
					NPC nPC = Main.npc[m];
					if (nPC.active && !nPC.dontTakeDamage && !nPC.friendly && nPC.immune[this.whoAmI] == 0 && rect.Intersects(nPC.getRect()) && (nPC.noTileCollide || Collision.CanHit(this.position, this.width, this.height, nPC.position, nPC.width, nPC.height)))
					{
						float single = 80f * this.minionDamage;
						float single1 = 10f;
						int num16 = this.direction;
						if (this.velocity.X < 0f)
						{
							num16 = -1;
						}
						if (this.velocity.X > 0f)
						{
							num16 = 1;
						}
						nPC.StrikeNPC((int)single, single1, num16, false, false, false, this);
						nPC.immune[this.whoAmI] = 30;
						this.immune = true;
						this.immuneTime = 6;
						return;
					}
				}
			}
		}

		public double Hurt(int Damage, int hitDirection, bool pvp = false, bool quiet = false, string deathText = " was slain...", bool Crit = false, int cooldownCounter = -1)
		{
			bool flag = !this.immune;
			if (cooldownCounter == 0)
			{
				flag = (this.hurtCooldowns[0] <= 0);
			}
			if (!flag)
			{
				return 0;
			}
			if (this.whoAmI == Main.myPlayer && this.blackBelt && Main.rand.Next(10) == 0)
			{
				this.NinjaDodge();
				return 0;
			}
			if (this.whoAmI == Main.myPlayer && this.shadowDodge)
			{
				this.ShadowDodge();
				return 0;
			}
			if (this.whoAmI == Main.myPlayer && this.panic)
			{
				this.AddBuff(BuffID.Panic, 300, true);
			}
			this.stealth = 1f;
			if (Main.netMode == 1)
			{
				NetMessage.SendData((int)PacketTypes.PlayerStealth, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
			}
			int damage = Damage;
			double num = Main.CalculatePlayerDamage(damage, this.statDefense);
			if (Crit)
			{
				damage = damage * 2;
			}
			if (num >= 1)
			{
				if (this.invis)
				{
					for (int i = 0; i < 22; i++)
					{
						if (this.buffType[i] == BuffID.Invisibility)
						{
							this.DelBuff(i);
						}
					}
				}
				num = (double)((int)((double)(1f - this.endurance) * num));
				if (num < 1)
				{
					num = 1;
				}
				if (this.ConsumeSolarFlare())
				{
					num = (double)((int)((double)(1f - 0.3f) * num));
					if (num < 1)
					{
						num = 1;
					}
					if (this.whoAmI == Main.myPlayer)
					{
						int num1 = Projectile.NewProjectile(base.Center.X, base.Center.Y, 0f, 0f, 608, 150, 15f, Main.myPlayer, 0f, 0f);
						Main.projectile[num1].Kill();
					}
				}
				if (this.beetleDefense && this.beetleOrbs > 0)
				{
					float single = 0.15f * (float)this.beetleOrbs;
					num = (double)((int)((double)(1f - single) * num));
					Player player = this;
					player.beetleOrbs = player.beetleOrbs - 1;
					for (int j = 0; j < 22; j++)
					{
						if (this.buffType[j] >= BuffID.BeetleEndurance1 && this.buffType[j] <= BuffID.BeetleEndurance3)
						{
							this.DelBuff(j);
						}
					}
					if (this.beetleOrbs > 0)
					{
						this.AddBuff(BuffID.BeetleEndurance1 + this.beetleOrbs - 1, 5, false);
					}
					this.beetleCounter = 0f;
					if (num < 1)
					{
						num = 1;
					}
				}
				if (this.magicCuffs)
				{
					int num2 = damage;
					Player player1 = this;
					player1.statMana = player1.statMana + num2;
					if (this.statMana > this.statManaMax2)
					{
						this.statMana = this.statManaMax2;
					}
					this.ManaEffect(num2);
				}
				if (this.paladinBuff && this.whoAmI != Main.myPlayer)
				{
					int num3 = (int)(num * 0.25);
					num = (double)((int)(num * 0.75));
					if (Main.player[Main.myPlayer].paladinGive)
					{
						int num4 = Main.myPlayer;
						if (Main.player[num4].team == this.team && this.team != 0)
						{
							float x = this.position.X - Main.player[num4].position.X;
							float y = this.position.Y - Main.player[num4].position.Y;
							if ((float)Math.Sqrt((double)(x * x + y * y)) < 800f)
							{
								Main.player[num4].Hurt(num3, 0, false, false, "", false);
							}
						}
					}
				}
				if (this.brainOfConfusion && Main.myPlayer == this.whoAmI)
				{
					for (int k = 0; k < 200; k++)
					{
						if (Main.npc[k].active && !Main.npc[k].friendly && Main.rand.Next(500) < 300 + (int)num * 2)
						{
							Vector2 center = Main.npc[k].Center - base.Center;
							float single1 = center.Length();
							float single2 = (float)Main.rand.Next(200 + (int)num / 2, 301 + (int)num * 2);
							if (single2 > 500f)
							{
								single2 = 500f + (single2 - 500f) * 0.75f;
							}
							if (single2 > 700f)
							{
								single2 = 700f + (single2 - 700f) * 0.5f;
							}
							if (single2 > 900f)
							{
								single2 = 900f + (single2 - 900f) * 0.25f;
							}
							if (single1 < single2)
							{
								float single3 = (float)Main.rand.Next(90 + (int)num / 3, 300 + (int)num / 2);
								Main.npc[k].AddBuff(BuffID.Confused, (int)single3, false);
							}
						}
					}
					Projectile.NewProjectile(base.Center.X + (float)Main.rand.Next(-40, 40), base.Center.Y - (float)Main.rand.Next(20, 60), this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 565, 0, 0f, this.whoAmI, 0f, 0f);
				}
				if (Main.netMode == 1 && this.whoAmI == Main.myPlayer && !quiet)
				{
					int num5 = 0;
					if (Crit)
					{
						num5 = 1;
					}
					int num6 = 0;
					if (pvp)
					{
						num6 = 1;
					}
					NetMessage.SendData((int)PacketTypes.PlayerUpdate, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
					NetMessage.SendData((int)PacketTypes.PlayerHp, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
					NetMessage.SendData((int)PacketTypes.PlayerDamage, -1, -1, "", this.whoAmI, (float)hitDirection, (float)Damage, (float)num6, num5, cooldownCounter, 0);
				}
				Color color = (Crit ? CombatText.DamagedFriendlyCrit : CombatText.DamagedFriendly);
				CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), color, string.Concat((int)num), Crit, false);
				Player player2 = this;
				this.statLife -= (int)num;
				if (cooldownCounter == -1)
				{
					this.immune = true;
					if (num == 1.0)
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
					if (pvp)
					{
						this.immuneTime = 8;
					}
				}
				else if (cooldownCounter == 0)
				{
					if (num == 1.0)
					{
						this.hurtCooldowns[cooldownCounter] = (this.longInvince ? 40 : 20);
					}
					else
					{
						this.hurtCooldowns[cooldownCounter] = (this.longInvince ? 80 : 40);
					}
				}
				else if (cooldownCounter == 1)
				{
					if (num == 1.0)
					{
						this.hurtCooldowns[cooldownCounter] = (this.longInvince ? 40 : 20);
					}
					else
					{
						this.hurtCooldowns[cooldownCounter] = (this.longInvince ? 80 : 40);
					}
				}
				this.lifeRegenTime = 0;
				if (this.whoAmI == Main.myPlayer)
				{
					if (this.starCloak)
					{
						for (int l = 0; l < 3; l++)
						{
							float x1 = this.position.X + (float)Main.rand.Next(-400, 400);
							float y1 = this.position.Y - (float)Main.rand.Next(500, 800);
							Vector2 vector2 = new Vector2(x1, y1);
							float x2 = this.position.X + (float)(this.width / 2) - vector2.X;
							float y2 = this.position.Y + (float)(this.height / 2) - vector2.Y;
							x2 = x2 + (float)Main.rand.Next(-100, 101);
							int num7 = 23;
							float single4 = (float)Math.Sqrt((double)(x2 * x2 + y2 * y2));
							single4 = (float)num7 / single4;
							x2 = x2 * single4;
							y2 = y2 * single4;
							int num8 = Projectile.NewProjectile(x1, y1, x2, y2, ProjectileID.HallowStar, 30, 5f, this.whoAmI, 0f, 0f);
							Main.projectile[num8].ai[1] = this.position.Y;
						}
					}
					if (this.bee)
					{
						int num9 = 1;
						if (Main.rand.Next(3) == 0)
						{
							num9++;
						}
						if (Main.rand.Next(3) == 0)
						{
							num9++;
						}
						if (this.strongBees && Main.rand.Next(3) == 0)
						{
							num9++;
						}
						for (int m = 0; m < num9; m++)
						{
							float single5 = (float)Main.rand.Next(-35, 36) * 0.02f;
							float single6 = (float)Main.rand.Next(-35, 36) * 0.02f;
							Projectile.NewProjectile(this.position.X, this.position.Y, single5, single6, this.beeType(), this.beeDamage(7), this.beeKB(0f), Main.myPlayer, 0f, 0f);
						}
					}
				}
				if (!this.noKnockback && hitDirection != 0 && (!this.mount.Active || !this.mount.Cart))
				{
					this.velocity.X = 4.5f * (float)hitDirection;
					this.velocity.Y = -3.5f;
				}
				if (this.statLife <= 0)
				{
					this.statLife = 0;
					if (this.whoAmI == Main.myPlayer)
					{
						this.KillMe(num, hitDirection, pvp, deathText);
					}
				}
			}
			if (pvp)
			{
				num = Main.CalculateDamage(damage, this.statDefense);
			}
			return num;
		}

		public bool IsStackingItems()
		{
			for (int i = 0; i < (int)this.inventoryChestStack.Length; i++)
			{
				if (this.inventoryChestStack[i])
				{
					if (this.inventory[i].type != 0 && this.inventory[i].stack != 0)
					{
						return true;
					}
					this.inventoryChestStack[i] = false;
				}
			}
			return false;
		}

		public void ItemCheck(int i)
		{
			TileObject tileObject;
			Vector2 vector2 = new Vector2();
			Vector2 x = new Vector2();
			Vector2 y = new Vector2();
			int num;
			Vector2 vector21;
			if (this.webbed || this.frozen || this.stoned)
			{
				return;
			}
			bool flag = false;
			float playerOffsetHitbox = (float)this.mount.PlayerOffsetHitbox;
			Item item = this.inventory[this.selectedItem];
			if (this.mount.Active)
			{
				if (this.mount.Type == 8)
				{
					this.noItems = true;
					if (this.controlUseItem)
					{
						this.channel = true;
						if (this.releaseUseItem)
						{
							this.mount.UseAbility(this, Vector2.Zero, true);
						}
						this.releaseUseItem = false;
					}
				}
				if (this.whoAmI == Main.myPlayer && this.gravDir == -1f)
				{
					this.mount.Dismount(this);
				}
			}
			int weaponDamage = this.GetWeaponDamage(item);
			if (item.autoReuse && !this.noItems)
			{
				this.releaseUseItem = true;
				if (this.itemAnimation == 1 && item.stack > 0)
				{
					if (item.shoot <= 0 || this.whoAmI == Main.myPlayer || !this.controlUseItem || item.useStyle != 5)
					{
						this.itemAnimation = 0;
					}
					else
					{
						this.ApplyAnimation(item);
					}
				}
			}
			if (item.fishingPole > 0)
			{
				item.holdStyle = 0;
				if (this.itemTime == 0 && this.itemAnimation == 0)
				{
					for (int i1 = 0; i1 < 1000; i1++)
					{
						if (Main.projectile[i1].active && Main.projectile[i1].owner == this.whoAmI && Main.projectile[i1].bobber)
						{
							item.holdStyle = 1;
						}
					}
				}
			}
			if (this.itemAnimation == 0 && this.altFunctionUse == 2)
			{
				this.altFunctionUse = 0;
			}
			if (this.itemAnimation == 0 && this.reuseDelay > 0)
			{
				this.itemAnimation = this.reuseDelay;
				this.itemTime = this.reuseDelay;
				this.reuseDelay = 0;
			}
			if (this.controlUseItem && this.releaseUseItem && (item.headSlot > 0 || item.bodySlot > 0 || item.legSlot > 0))
			{
				if (item.useStyle == 0)
				{
					this.releaseUseItem = false;
				}
				if (this.position.X / 16f - (float)Player.tileRangeX - (float)item.tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)item.tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)item.tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)item.tileBoost - 2f >= (float)Player.tileTargetY)
				{
					int num2 = Player.tileTargetX;
					int num3 = Player.tileTargetY;
					if (Main.tile[num2, num3].active() && (Main.tile[num2, num3].type == TileID.Mannequin || Main.tile[num2, num3].type == TileID.Womannequin))
					{
						int j = Main.tile[num2, num3].frameY;
						int num4 = 0;
						if (item.bodySlot >= 0)
						{
							num4 = 1;
						}
						if (item.legSlot >= 0)
						{
							num4 = 2;
						}
						for (j = j / 18; num4 > j; j = j / 18)
						{
							num3++;
							j = Main.tile[num2, num3].frameY;
						}
						while (num4 < j)
						{
							num3--;
							j = Main.tile[num2, num3].frameY;
							j = j / 18;
						}
						int num5 = Main.tile[num2, num3].frameX;
						while (num5 >= 100)
						{
							num5 = num5 - 100;
						}
						if (num5 >= 36)
						{
							num5 = num5 - 36;
						}
						num2 = num2 - num5 / 18;
						int num6 = Main.tile[num2, num3].frameX;
						WorldGen.KillTile(num2, num3, true, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)num2, (float)num3, 1f, 0, 0, 0);
						}
						while (num6 >= 100)
						{
							num6 = num6 - 100;
						}
						if (j == 0 && item.headSlot >= 0)
						{
							Main.blockMouse = true;
							Main.tile[num2, num3].frameX = (short)(num6 + item.headSlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num2, num3, 1);
							}
							Item item1 = item;
							item1.stack = item1.stack - 1;
							if (item.stack <= 0)
							{
								item.SetDefaults(0, false);
								Main.mouseItem.SetDefaults(0, false);
							}
							if (this.selectedItem == 58)
							{
								Main.mouseItem = item.Clone();
							}
							this.releaseUseItem = false;
							this.mouseInterface = true;
						}
						else if (j == 1 && item.bodySlot >= 0)
						{
							Main.blockMouse = true;
							Main.tile[num2, num3].frameX = (short)(num6 + item.bodySlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num2, num3, 1);
							}
							Item item2 = item;
							item2.stack = item2.stack - 1;
							if (item.stack <= 0)
							{
								item.SetDefaults(0, false);
								Main.mouseItem.SetDefaults(0, false);
							}
							if (this.selectedItem == 58)
							{
								Main.mouseItem = item.Clone();
							}
							this.releaseUseItem = false;
							this.mouseInterface = true;
						}
						else if (j == 2 && item.legSlot >= 0)
						{
							Main.blockMouse = true;
							Main.tile[num2, num3].frameX = (short)(num6 + item.legSlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num2, num3, 1);
							}
							Item item3 = item;
							item3.stack = item3.stack - 1;
							if (item.stack <= 0)
							{
								item.SetDefaults(0, false);
								Main.mouseItem.SetDefaults(0, false);
							}
							if (this.selectedItem == 58)
							{
								Main.mouseItem = item.Clone();
							}
							this.releaseUseItem = false;
							this.mouseInterface = true;
						}
					}
				}
			}
			if (Main.myPlayer == i && this.itemAnimation == 0 && TileObjectData.CustomPlace(item.createTile, item.placeStyle))
			{
				TileObject.CanPlace(Player.tileTargetX, Player.tileTargetY, item.createTile, item.placeStyle, this.direction, out tileObject, true);
			}
			if (this.controlUseItem && this.itemAnimation == 0 && this.releaseUseItem && item.useStyle > 0)
			{
				if (this.altFunctionUse == 1)
				{
					this.altFunctionUse = 2;
				}
				bool flag1 = true;
				if (item.shoot == 0)
				{
					this.itemRotation = 0f;
				}
				if (item.type == ItemID.DemonHeart && (this.extraAccessory || !Main.expertMode))
				{
					flag1 = false;
				}
				if (this.pulley && item.fishingPole > 0)
				{
					flag1 = false;
				}
				if (this.wet && (item.shoot == 85 || item.shoot == 15 || item.shoot == 34))
				{
					flag1 = false;
				}
				if (item.makeNPC > 0 && !NPC.CanReleaseNPCs(this.whoAmI))
				{
					flag1 = false;
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.Carrot && !Main.cEd)
				{
					flag1 = false;
				}
				if (item.type == ItemID.Paintbrush || item.type == ItemID.PaintRoller)
				{
					bool flag2 = false;
					int num7 = 0;
					while (num7 < 58)
					{
						if (this.inventory[num7].paint <= 0)
						{
							num7++;
						}
						else
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						flag1 = false;
					}
				}
				if (this.noItems)
				{
					flag1 = false;
				}
				if (item.tileWand > 0)
				{
					int num8 = item.tileWand;
					flag1 = false;
					int num9 = 0;
					while (num9 < 58)
					{
						if (num8 != this.inventory[num9].type || this.inventory[num9].stack <= 0)
						{
							num9++;
						}
						else
						{
							flag1 = true;
							break;
						}
					}
				}
				if (item.fishingPole > 0)
				{
					for (int k = 0; k < 1000; k++)
					{
						if (Main.projectile[k].active && Main.projectile[k].owner == this.whoAmI && Main.projectile[k].bobber)
						{
							flag1 = false;
							if (this.whoAmI == Main.myPlayer && Main.projectile[k].ai[0] == 0f)
							{
								Main.projectile[k].ai[0] = 1f;
								float single1 = -10f;
								if (Main.projectile[k].wet && Main.projectile[k].velocity.Y > single1)
								{
									Main.projectile[k].velocity.Y = single1;
								}
								Main.projectile[k].netUpdate2 = true;
								if (Main.projectile[k].ai[1] < 0f && Main.projectile[k].localAI[1] != 0f)
								{
									bool flag3 = false;
									int num10 = 0;
									int num11 = 0;
									while (num11 < 58)
									{
										if (this.inventory[num11].stack <= 0 || this.inventory[num11].bait <= 0)
										{
											num11++;
										}
										else
										{
											bool flag4 = false;
											int num12 = 1 + this.inventory[num11].bait / 5;
											if (num12 < 1)
											{
												num12 = 1;
											}
											if (this.accTackleBox)
											{
												num12++;
											}
											if (Main.rand.Next(num12) == 0)
											{
												flag4 = true;
											}
											if (Main.projectile[k].localAI[1] < 0f)
											{
												flag4 = true;
											}
											if (Main.projectile[k].localAI[1] > 0f)
											{
												Item item4 = new Item();
												item4.SetDefaults((int)Main.projectile[k].localAI[1], false);
												if (item4.rare < 0)
												{
													flag4 = false;
												}
											}
											if (flag4)
											{
												num10 = this.inventory[num11].type;
												Item item5 = this.inventory[num11];
												item5.stack = item5.stack - 1;
												if (this.inventory[num11].stack <= 0)
												{
													this.inventory[num11].SetDefaults(0, false);
												}
											}
											flag3 = true;
											break;
										}
									}
									if (flag3)
									{
										if (num10 == 2673)
										{
											if (Main.netMode == 1)
											{
												NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, 370f, 0f, 0f, 0, 0, 0);
											}
											else
											{
												NPC.SpawnOnPlayer(this.whoAmI, 370);
											}
											Main.projectile[k].ai[0] = 2f;
										}
										else if (Main.rand.Next(7) != 0 || this.accFishingLine)
										{
											Main.projectile[k].ai[1] = Main.projectile[k].localAI[1];
										}
										else
										{
											Main.projectile[k].ai[0] = 2f;
										}
										Main.projectile[k].netUpdate = true;
									}
								}
							}
						}
					}
				}
				if (item.shoot == 6 || item.shoot == 19 || item.shoot == 33 || item.shoot == 52 || item.shoot == 113 || item.shoot == 320 || item.shoot == 333 || item.shoot == 383 || item.shoot == 491)
				{
					for (int l = 0; l < 1000; l++)
					{
						if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == item.shoot)
						{
							flag1 = false;
						}
					}
				}
				if (item.shoot == 106)
				{
					int num13 = 0;
					for (int m = 0; m < 1000; m++)
					{
						if (Main.projectile[m].active && Main.projectile[m].owner == Main.myPlayer && Main.projectile[m].type == item.shoot)
						{
							num13++;
						}
					}
					if (num13 >= item.stack)
					{
						flag1 = false;
					}
				}
				if (item.shoot == 272)
				{
					int num14 = 0;
					for (int n = 0; n < 1000; n++)
					{
						if (Main.projectile[n].active && Main.projectile[n].owner == Main.myPlayer && Main.projectile[n].type == item.shoot)
						{
							num14++;
						}
					}
					if (num14 >= item.stack)
					{
						flag1 = false;
					}
				}
				if (item.shoot == 13 || item.shoot == 32 || item.shoot >= 230 && item.shoot <= 235 || item.shoot == 315 || item.shoot == 331 || item.shoot == 372)
				{
					for (int o = 0; o < 1000; o++)
					{
						if (Main.projectile[o].active && Main.projectile[o].owner == Main.myPlayer && Main.projectile[o].type == item.shoot && Main.projectile[o].ai[0] != 2f)
						{
							flag1 = false;
						}
					}
				}
				if (item.shoot == 332)
				{
					int num15 = 0;
					for (int p = 0; p < 1000; p++)
					{
						if (Main.projectile[p].active && Main.projectile[p].owner == Main.myPlayer && Main.projectile[p].type == item.shoot && Main.projectile[p].ai[0] != 2f)
						{
							num15++;
						}
					}
					if (num15 >= 3)
					{
						flag1 = false;
					}
				}
				if (item.potion && flag1)
				{
					if (this.potionDelay > 0)
					{
						flag1 = false;
					}
					else if (item.type != ItemID.RestorationPotion)
					{
						this.potionDelay = this.potionDelayTime;
						this.AddBuff(BuffID.PotionSickness, this.potionDelay, true);
					}
					else
					{
						this.potionDelay = this.restorationDelayTime;
						this.AddBuff(BuffID.PotionSickness, this.potionDelay, true);
					}
				}
				if (item.mana > 0 && this.silence)
				{
					flag1 = false;
				}
				if (item.mana > 0 && flag1)
				{
					bool flag5 = false;
					if (item.type == ItemID.LaserMachinegun)
					{
						flag5 = true;
					}
					if (item.type != ItemID.SpaceGun || !this.spaceGun)
					{
						if (this.statMana >= (int)((float)item.mana * this.manaCost))
						{
							if (!flag5)
							{
								Player player = this;
								player.statMana = player.statMana - (int)((float)item.mana * this.manaCost);
							}
						}
						else if (!this.manaFlower)
						{
							flag1 = false;
						}
						else
						{
							this.QuickMana();
							if (this.statMana < (int)((float)item.mana * this.manaCost))
							{
								flag1 = false;
							}
							else if (!flag5)
							{
								Player player1 = this;
								player1.statMana = player1.statMana - (int)((float)item.mana * this.manaCost);
							}
						}
					}
					if (this.whoAmI == Main.myPlayer && item.buffType != 0 && flag1)
					{
						this.AddBuff(item.buffType, item.buffTime, true);
					}
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.Carrot && Main.cEd)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.Fish)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.ShadowOrb)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.BoneRattle)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.CrimsonHeart)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.SuspiciousLookingTentacle)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.FairyBell)
				{
					int num16 = Main.rand.Next(3);
					if (num16 == 0)
					{
						num16 = 27;
					}
					if (num16 == 1)
					{
						num16 = 101;
					}
					if (num16 == 2)
					{
						num16 = 102;
					}
					for (int q = 0; q < 22; q++)
					{
						if (this.buffType[q] == BuffID.FairyBlue || this.buffType[q] == BuffID.FairyRed || this.buffType[q] == BuffID.FairyGreen)
						{
							this.DelBuff(q);
							q--;
						}
					}
					this.AddBuff(num16, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.Seaweed)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.EatersBone)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.BoneKey)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.Nectar)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.TikiTotem)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.LizardEgg)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.ParrotCracker)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.StrangeGlowingMushroom)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.Seedling)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.WispinaBottle)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.AmberMosquito)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.PygmyStaff)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.SlimeStaff)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.EyeSpring)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.CursedSapling)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.ToySled)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.SpiderEgg)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.MagicalPumpkinSeed)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.RavenStaff)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.UnluckyYarn)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.DogWhistle)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.BabyGrinchMischiefWhistle)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.HornetStaff)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.ImpStaff)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.MagicLantern)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.ZephyrFish)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.OpticStaff)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.SpiderStaff)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.PirateStaff)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.TartarSauce)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.TempestStaff)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.XenoStaff)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.DeadlySphereStaff)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.StardustCellStaff)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == ItemID.StardustDragonStaff)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && this.gravDir == 1f && item.mountType != -1 && this.mount.CanMount(item.mountType, this))
				{
					this.mount.SetMount(item.mountType, this, false);
				}
				if (item.type == ItemID.SuspiciousLookingEye && Main.dayTime)
				{
					flag1 = false;
				}
				if (item.type == ItemID.MechanicalEye && Main.dayTime)
				{
					flag1 = false;
				}
				if (item.type == ItemID.MechanicalWorm && Main.dayTime)
				{
					flag1 = false;
				}
				if (item.type == ItemID.MechanicalSkull && Main.dayTime)
				{
					flag1 = false;
				}
				if (item.type == ItemID.WormFood && !this.ZoneCorrupt)
				{
					flag1 = false;
				}
				if (item.type == ItemID.Abeemination && !this.ZoneJungle)
				{
					flag1 = false;
				}
				if (item.type == ItemID.PumpkinMoonMedallion && (Main.dayTime || Main.pumpkinMoon || Main.snowMoon))
				{
					flag1 = false;
				}
				if (item.type == ItemID.NaughtyPresent && (Main.dayTime || Main.pumpkinMoon || Main.snowMoon))
				{
					flag1 = false;
				}
				if (item.type == ItemID.LunarTablet && (!Main.dayTime || Main.eclipse || !Main.hardMode))
				{
					flag1 = false;
				}
				if (item.type == ItemID.CelestialSigil && (!NPC.downedGolemBoss || !Main.hardMode || NPC.AnyDanger() || NPC.AnyoneNearCultists()))
				{
					flag1 = false;
				}
				if (!this.SummonItemCheck())
				{
					flag1 = false;
				}
				if (item.shoot == 17 && flag1 && i == Main.myPlayer)
				{
					int x1 = (int)((float)Main.mouseX + Main.screenPosition.X) / 16;
					int y1 = (int)((float)Main.mouseY + Main.screenPosition.Y) / 16;
					if (this.gravDir == -1f)
					{
						y1 = (int)(Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16;
					}
					Tile tile = Main.tile[x1, y1];
					if (!tile.active() || tile.type != TileID.Dirt && tile.type != TileID.Grass && tile.type != TileID.CorruptGrass && tile.type != TileID.HallowedGrass && tile.type != TileID.FleshGrass)
					{
						flag1 = false;
					}
					else
					{
						WorldGen.KillTile(x1, y1, false, false, true);
						if (Main.tile[x1, y1].active())
						{
							flag1 = false;
						}
						else if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 4, (float)x1, (float)y1, 0f, 0, 0, 0);
						}
					}
				}
				if (flag1)
				{
					flag1 = this.HasAmmo(item, flag1);
				}
				if (flag1)
				{
					if (item.pick > 0 || item.axe > 0 || item.hammer > 0)
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
					this.channel = item.channel;
					this.attackCD = 0;
					this.ApplyAnimation(item);
				}
				if (flag1 && this.whoAmI == Main.myPlayer && item.shoot >= 0 && item.shoot < 651 && (ProjectileID.Sets.LightPet[item.shoot] || Main.projPet[item.shoot]))
				{
					if (!ProjectileID.Sets.MinionSacrificable[item.shoot])
					{
						for (int r = 0; r < 1000; r++)
						{
							if (Main.projectile[r].active && Main.projectile[r].owner == i && Main.projectile[r].type == item.shoot)
							{
								Main.projectile[r].Kill();
							}
							if (item.shoot == 72)
							{
								if (Main.projectile[r].active && Main.projectile[r].owner == i && Main.projectile[r].type == ProjectileID.PinkFairy)
								{
									Main.projectile[r].Kill();
								}
								if (Main.projectile[r].active && Main.projectile[r].owner == i && Main.projectile[r].type == ProjectileID.GreenFairy)
								{
									Main.projectile[r].Kill();
								}
							}
						}
					}
					else
					{
						List<int> nums = new List<int>();
						float single2 = 0f;
						for (int s = 0; s < 1000; s++)
						{
							if (Main.projectile[s].active && Main.projectile[s].owner == i && Main.projectile[s].minion)
							{
								int num17 = 0;
								while (num17 < nums.Count)
								{
									if (Main.projectile[nums[num17]].minionSlots <= Main.projectile[s].minionSlots)
									{
										num17++;
									}
									else
									{
										nums.Insert(num17, s);
										break;
									}
								}
								if (num17 == nums.Count)
								{
									nums.Add(s);
								}
								single2 = single2 + Main.projectile[s].minionSlots;
							}
						}
						float staffMinionSlotsRequired = (float)ItemID.Sets.StaffMinionSlotsRequired[item.type];
						float single3 = 0f;
						int num18 = 388;
						int item6 = -1;
						for (int t = 0; t < nums.Count; t++)
						{
							int num19 = Main.projectile[nums[t]].type;
							if (num19 == 626)
							{
								nums.RemoveAt(t);
								t--;
							}
							if (num19 == 627)
							{
								if (Main.projectile[(int)Main.projectile[nums[t]].localAI[1]].type == 628)
								{
									item6 = nums[t];
								}
								nums.RemoveAt(t);
								t--;
							}
						}
						if (item6 != -1)
						{
							nums.Add(item6);
							nums.Add((int)Main.projectile[item6].ai[0]);
						}
						for (int u = 0; u < nums.Count && single2 - single3 > (float)this.maxMinions - staffMinionSlotsRequired; u++)
						{
							int num20 = Main.projectile[nums[u]].type;
							if (num20 != num18 && num20 != 625 && num20 != 628)
							{
								if (num20 == 388 && num18 == 387)
								{
									num18 = 388;
								}
								if (num20 == 387 && num18 == 388)
								{
									num18 = 387;
								}
								single3 = single3 + Main.projectile[nums[u]].minionSlots;
								if (num20 == 626 || num20 == 627)
								{
									int byUUID = Projectile.GetByUUID(Main.projectile[nums[u]].owner, Main.projectile[nums[u]].ai[0]);
									if (byUUID >= 0)
									{
										Projectile projectile = Main.projectile[byUUID];
										if (projectile.type != ProjectileID.StardustDragon1)
										{
											projectile.localAI[1] = Main.projectile[nums[u]].localAI[1];
										}
										projectile = Main.projectile[(int)Main.projectile[nums[u]].localAI[1]];
										projectile.ai[0] = Main.projectile[nums[u]].ai[0];
										projectile.ai[1] = 1f;
										projectile.netUpdate = true;
									}
								}
								Main.projectile[nums[u]].Kill();
							}
						}
						nums.Clear();
						if (single2 + staffMinionSlotsRequired >= 9f)
						{
							AchievementsHelper.HandleSpecialEvent(this, 6);
						}
					}
				}
			}
			if (!this.controlUseItem)
			{
				bool flag6 = this.channel;
				this.channel = false;
			}
			if (this.itemAnimation > 0)
			{
				if (!item.melee)
				{
					this.itemAnimationMax = item.useAnimation;
				}
				else
				{
					this.itemAnimationMax = (int)((float)item.useAnimation * this.meleeSpeed);
				}
				if (item.mana > 0 && !flag && (item.type != ItemID.SpaceGun || !this.spaceGun))
				{
					this.manaRegenDelay = (int)this.maxRegenDelay;
				}
					this.itemHeight = item.height;
					this.itemWidth = item.width;
				Player player2 = this;
				player2.itemAnimation = player2.itemAnimation - 1;
			}
			else if (item.holdStyle == 1 && !this.pulley)
			{
				if (Main.dedServ)
				{
					this.itemLocation.X = this.position.X + (float)this.width * 0.5f + 20f * (float)this.direction;
				}
				this.itemLocation.Y = this.position.Y + 24f + playerOffsetHitbox;
				if (item.type == ItemID.UnicornonaStick)
				{
					this.itemLocation.Y = this.position.Y + 34f + playerOffsetHitbox;
				}
				if (item.type == ItemID.FlareGun)
				{
					this.itemLocation.Y = this.position.Y + 9f + playerOffsetHitbox;
				}
				if (item.fishingPole > 0)
				{
					this.itemLocation.Y = this.itemLocation.Y + 4f;
				}
				else if (item.type == ItemID.NebulaArcanum)
				{
					this.itemLocation.X = base.Center.X + (float)(14 * this.direction);
					this.itemLocation.Y = this.MountedCenter.Y;
				}
				this.itemRotation = 0f;
				if (this.gravDir == -1f)
				{
					this.itemRotation = -this.itemRotation;
					this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y) + playerOffsetHitbox;
					if (item.type == ItemID.FlareGun)
					{
						this.itemLocation.Y = this.itemLocation.Y - 24f;
					}
				}
			}
			else if (item.holdStyle == 2 && !this.pulley)
			{
				if (item.type != ItemID.Umbrella)
				{
					this.itemLocation.X = this.position.X + (float)this.width * 0.5f + (float)(6 * this.direction);
					this.itemLocation.Y = this.position.Y + 16f + playerOffsetHitbox;
					this.itemRotation = 0.79f * (float)(-this.direction);
					if (this.gravDir == -1f)
					{
						this.itemRotation = -this.itemRotation;
						this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
					}
				}
				else
				{
					this.itemRotation = 0f;
					this.itemLocation.X = this.position.X + (float)this.width * 0.5f - (float)(16 * this.direction);
					this.itemLocation.Y = this.position.Y + 22f + playerOffsetHitbox;
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
			}
			if (((item.type == ItemID.IceTorch || item.type == ItemID.Torch || item.type == ItemID.OrangeTorch || item.type == ItemID.UltrabrightTorch || item.type == ItemID.BoneTorch || item.type == ItemID.RainbowTorch || item.type == ItemID.PinkTorch || item.type >= ItemID.BlueTorch && item.type <= ItemID.DemonTorch) && !this.wet || item.type == ItemID.CursedTorch || item.type == ItemID.IchorTorch) && !this.pulley)
			{
				float discoR = 1f;
				float discoG = 0.95f;
				float discoB = 0.8f;
				int num25 = 0;
				if (item.type == ItemID.CursedTorch)
				{
					num25 = 8;
				}
				else if (item.type == ItemID.IceTorch)
				{
					num25 = 9;
				}
				else if (item.type == ItemID.OrangeTorch)
				{
					num25 = 10;
				}
				else if (item.type == ItemID.IchorTorch)
				{
					num25 = 11;
				}
				else if (item.type == ItemID.UltrabrightTorch)
				{
					num25 = 12;
				}
				else if (item.type == ItemID.BoneTorch)
				{
					num25 = 13;
				}
				else if (item.type == ItemID.RainbowTorch)
				{
					num25 = 14;
				}
				else if (item.type == ItemID.PinkTorch)
				{
					num25 = 15;
				}
				else if (item.type >= ItemID.BlueTorch)
				{
					num25 = item.type - 426;
				}
				if (num25 == 1)
				{
					discoR = 0f;
					discoG = 0.1f;
					discoB = 1.3f;
				}
				else if (num25 == 2)
				{
					discoR = 1f;
					discoG = 0.1f;
					discoB = 0.1f;
				}
				else if (num25 == 3)
				{
					discoR = 0f;
					discoG = 1f;
					discoB = 0.1f;
				}
				else if (num25 == 4)
				{
					discoR = 0.9f;
					discoG = 0f;
					discoB = 0.9f;
				}
				else if (num25 == 5)
				{
					discoR = 1.3f;
					discoG = 1.3f;
					discoB = 1.3f;
				}
				else if (num25 == 6)
				{
					discoR = 0.9f;
					discoG = 0.9f;
					discoB = 0f;
				}
				else if (num25 == 7)
				{
					discoR = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
					discoG = 0.3f;
					discoB = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
				}
				else if (num25 == 8)
				{
					discoB = 0.7f;
					discoR = 0.85f;
					discoG = 1f;
				}
				else if (num25 == 9)
				{
					discoB = 1f;
					discoR = 0.7f;
					discoG = 0.85f;
				}
				else if (num25 == 10)
				{
					discoB = 0f;
					discoR = 1f;
					discoG = 0.5f;
				}
				else if (num25 == 11)
				{
					discoB = 0.8f;
					discoR = 1.25f;
					discoG = 1.25f;
				}
				else if (num25 == 12)
				{
					discoR = discoR * 0.75f;
					discoG = discoG * 1.3499999f;
					discoB = discoB * 1.5f;
				}
				else if (num25 == 13)
				{
					discoR = 0.95f;
					discoG = 0.65f;
					discoB = 1.3f;
				}
				else if (num25 == 14)
				{
					discoR = (float)Main.DiscoR / 255f;
					discoG = (float)Main.DiscoG / 255f;
					discoB = (float)Main.DiscoB / 255f;
				}
				else if (num25 == 15)
				{
					discoR = 1f;
					discoG = 0f;
					discoB = 1f;
				}
				int num26 = num25;
				if (num26 == 0)
				{
					num26 = 6;
				}
				else if (num26 == 8)
				{
					num26 = 75;
				}
				else if (num26 == 9)
				{
					num26 = 135;
				}
				else if (num26 == 10)
				{
					num26 = 158;
				}
				else if (num26 == 11)
				{
					num26 = 169;
				}
				else if (num26 == 12)
				{
					num26 = 156;
				}
				else if (num26 == 13)
				{
					num26 = 234;
				}
				else if (num26 != 14)
				{
					num26 = (num26 != 15 ? 58 + num26 : 242);
				}
				else
				{
					num26 = 66;
				}
			}
			else if (item.type == ItemID.PeaceCandle && !this.wet)
			{
				this.itemLocation.X = this.itemLocation.X - (float)(this.direction * 4);
			}
			if (item.type == ItemID.SpelunkerGlowstick && !this.pulley)
			{
				Player player5 = this;
				player5.spelunkerTimer = (byte)(player5.spelunkerTimer + 1);
				if (this.spelunkerTimer >= 10)
				{
					this.spelunkerTimer = 0;
				}
			}
			if (!this.controlUseItem)
			{
				this.releaseUseItem = true;
			}
			else
			{
				this.releaseUseItem = false;
			}
			if (this.itemTime > 0)
			{
				Player player6 = this;
				player6.itemTime = player6.itemTime - 1;
			}
			if (i == Main.myPlayer)
			{
				bool flag8 = true;
				int num45 = item.type;
				if ((num45 == 65 || num45 == 676 || num45 == 723 || num45 == 724 || num45 == 757 || num45 == 674 || num45 == 675 || num45 == 989 || num45 == 1226 || num45 == 1227) && this.itemAnimation != this.itemAnimationMax - 1)
				{
					flag8 = false;
				}
				if (item.shoot > 0 && this.itemAnimation > 0 && this.itemTime == 0 && flag8)
				{
					int num46 = item.shoot;
					float single14 = item.shootSpeed;
					if (this.inventory[this.selectedItem].thrown && single14 < 16f)
					{
						single14 = single14 * this.thrownVelocity;
						if (single14 > 16f)
						{
							single14 = 16f;
						}
					}
					if (item.melee && num46 != 25 && num46 != 26 && num46 != 35)
					{
						single14 = single14 / this.meleeSpeed;
					}
					bool flag9 = false;
					int num47 = weaponDamage;
					float single15 = item.knockBack;
					if (num46 == 13 || num46 == 32 || num46 == 315 || num46 >= 230 && num46 <= 235 || num46 == 331)
					{
						this.grappling[0] = -1;
						this.grapCount = 0;
						for (int a = 0; a < 1000; a++)
						{
							if (Main.projectile[a].active && Main.projectile[a].owner == i)
							{
								if (Main.projectile[a].type == ProjectileID.Hook)
								{
									Main.projectile[a].Kill();
								}
								if (Main.projectile[a].type == ProjectileID.CandyCaneHook)
								{
									Main.projectile[a].Kill();
								}
								if (Main.projectile[a].type == ProjectileID.BatHook)
								{
									Main.projectile[a].Kill();
								}
								if (Main.projectile[a].type >= ProjectileID.GemHookAmethyst && Main.projectile[a].type <= ProjectileID.GemHookDiamond)
								{
									Main.projectile[a].Kill();
								}
							}
						}
					}
					if (item.useAmmo <= 0)
					{
						flag9 = true;
					}
					else
					{
						this.PickAmmo(item, ref num46, ref single14, ref flag9, ref num47, ref single15, ItemID.Sets.gunProj[item.type]);
					}
					if (item.type == ItemID.VortexBeater || item.type == ItemID.Phantasm)
					{
						single15 = item.knockBack;
						num47 = weaponDamage;
						single14 = item.shootSpeed;
					}
					if (item.type == ItemID.CopperCoin)
					{
						flag9 = false;
					}
					if (item.type == ItemID.SilverCoin)
					{
						flag9 = false;
					}
					if (item.type == ItemID.GoldCoin)
					{
						flag9 = false;
					}
					if (item.type == ItemID.PlatinumCoin)
					{
						flag9 = false;
					}
					if (item.type == ItemID.SniperRifle && num46 == 14)
					{
						num46 = 242;
					}
					if (item.type == ItemID.VenusMagnum && num46 == 14)
					{
						num46 = 242;
					}
					if (item.type == ItemID.Uzi && num46 == 14)
					{
						num46 = 242;
					}
					if (item.type == ItemID.NebulaBlaze)
					{
						if (Main.rand.Next(100) >= 20)
						{
							single14 = single14 - 1f;
						}
						else
						{
							num46++;
							num47 = num47 * 3;
						}
					}
					if (num46 == 73)
					{
						for (int b = 0; b < 1000; b++)
						{
							if (Main.projectile[b].active && Main.projectile[b].owner == i)
							{
								if (Main.projectile[b].type == ProjectileID.DualHookBlue)
								{
									num46 = 74;
								}
								if (num46 == 74 && Main.projectile[b].type == ProjectileID.DualHookRed)
								{
									flag9 = false;
								}
							}
						}
					}
					if (flag9)
					{
						single15 = this.GetWeaponKnockback(item, single15);
						if (num46 == 228)
						{
							single15 = 0f;
						}
						if (num46 == 1 && item.type == ItemID.MoltenFury)
						{
							num46 = 2;
						}
						if (item.type == ItemID.Marrow)
						{
							num46 = 117;
						}
						if (item.type == ItemID.IceBow)
						{
							num46 = 120;
						}
						if (item.type == ItemID.ElectrosphereLauncher)
						{
							num46 = 442;
						}
						if (item.type == ItemID.PulseBow)
						{
							num46 = 357;
						}
						this.itemTime = item.useTime;
						Vector2 center = this.RotatedRelativePoint(this.MountedCenter, true);
						Vector2 unitX = Vector2.UnitX;
						double num48 = (double)this.fullRotation;
						vector21 = new Vector2();
						Vector2 vector230 = unitX.RotatedBy(num48, vector21);
						Vector2 mouseWorld = Main.MouseWorld - center;
						if (mouseWorld != Vector2.Zero)
						{
							mouseWorld.Normalize();
						}
						if (Vector2.Dot(vector230, mouseWorld) <= 0f)
						{
							this.ChangeDir(-1);
						}
						else
						{
							this.ChangeDir(1);
						}
						if (item.type == ItemID.Javelin || item.type == ItemID.BoneJavelin || item.type == ItemID.DayBreak)
						{
							center.Y = this.position.Y + (float)(this.height / 3);
						}
						if (num46 == 9)
						{
							center = new Vector2(this.position.X + (float)this.width * 0.5f + (float)(Main.rand.Next(201) * -this.direction) + ((float)Main.mouseX + Main.screenPosition.X - this.position.X), this.MountedCenter.Y - 600f);
							single15 = 0f;
							num47 = num47 * 2;
						}
						if (item.type == ItemID.Blowgun || item.type == ItemID.Blowpipe)
						{
							center.X = center.X + (float)(6 * this.direction);
							center.Y = center.Y - 6f * this.gravDir;
						}
						if (item.type == ItemID.DartPistol)
						{
							center.X = center.X - (float)(4 * this.direction);
							center.Y = center.Y - 1f * this.gravDir;
						}
						float x6 = (float)Main.mouseX + Main.screenPosition.X - center.X;
						float y6 = (float)Main.mouseY + Main.screenPosition.Y - center.Y;
						if (this.gravDir == -1f)
						{
							y6 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - center.Y;
						}
						float single16 = (float)Math.Sqrt((double)(x6 * x6 + y6 * y6));
						float single17 = single16;
						if ((!float.IsNaN(x6) || !float.IsNaN(y6)) && (x6 != 0f || y6 != 0f))
						{
							single16 = single14 / single16;
						}
						else
						{
							x6 = (float)this.direction;
							y6 = 0f;
							single16 = single14;
						}
						if (item.type == ItemID.ChainGun || item.type == ItemID.Gatligator)
						{
							x6 = x6 + (float)Main.rand.Next(-50, 51) * 0.03f / single16;
							y6 = y6 + (float)Main.rand.Next(-50, 51) * 0.03f / single16;
						}
						x6 = x6 * single16;
						y6 = y6 * single16;
						if (item.type == ItemID.TerraBlade)
						{
							num47 = (int)((float)num47 * 1.25f);
						}
						if (num46 == 250)
						{
							for (int c = 0; c < 1000; c++)
							{
								if (Main.projectile[c].active && Main.projectile[c].owner == this.whoAmI && (Main.projectile[c].type == ProjectileID.RainbowFront || Main.projectile[c].type == ProjectileID.RainbowBack))
								{
									Main.projectile[c].Kill();
								}
							}
						}
						if (num46 == 12)
						{
							center.X = center.X + x6 * 3f;
							center.Y = center.Y + y6 * 3f;
						}
						if (item.useStyle == 5)
						{
							if (item.type != ItemID.DaedalusStormbow)
							{
								this.itemRotation = (float)Math.Atan2((double)(y6 * (float)this.direction), (double)(x6 * (float)this.direction)) - this.fullRotation;
								NetMessage.SendData((int)PacketTypes.PlayerUpdate, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
								NetMessage.SendData((int)PacketTypes.PlayerAnimation, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
							}
							else
							{
								Vector2 vector231 = new Vector2(x6, y6)
								{
									X = (float)Main.mouseX + Main.screenPosition.X - center.X,
									Y = (float)Main.mouseY + Main.screenPosition.Y - center.Y - 1000f
								};
								this.itemRotation = (float)Math.Atan2((double)(vector231.Y * (float)this.direction), (double)(vector231.X * (float)this.direction));
								NetMessage.SendData((int)PacketTypes.PlayerUpdate, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
								NetMessage.SendData((int)PacketTypes.PlayerAnimation, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
							}
						}
						if (num46 == 17)
						{
							center.X = (float)Main.mouseX + Main.screenPosition.X;
							center.Y = (float)Main.mouseY + Main.screenPosition.Y;
							if (this.gravDir == -1f)
							{
								center.Y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY;
							}
						}
						if (num46 == 76)
						{
							num46 = num46 + Main.rand.Next(3);
							single17 = single17 / (float)(Main.screenHeight / 2);
							if (single17 > 1f)
							{
								single17 = 1f;
							}
							float single18 = x6 + (float)Main.rand.Next(-40, 41) * 0.01f;
							float single19 = y6 + (float)Main.rand.Next(-40, 41) * 0.01f;
							single18 = single18 * (single17 + 0.25f);
							single19 = single19 * (single17 + 0.25f);
							int num49 = Projectile.NewProjectile(center.X, center.Y, single18, single19, num46, num47, single15, i, 0f, 0f);
							Main.projectile[num49].ai[1] = 1f;
							single17 = single17 * 2f - 1f;
							if (single17 < -1f)
							{
								single17 = -1f;
							}
							if (single17 > 1f)
							{
								single17 = 1f;
							}
							Main.projectile[num49].ai[0] = single17;
							NetMessage.SendData((int)PacketTypes.ProjectileNew, -1, -1, "", num49, 0f, 0f, 0f, 0, 0, 0);
						}
						else if (item.type == ItemID.DaedalusStormbow)
						{
							int num50 = 3;
							if (Main.rand.Next(3) == 0)
							{
								num50++;
							}
							for (int d = 0; d < num50; d++)
							{
								center = new Vector2(this.position.X + (float)this.width * 0.5f + (float)(Main.rand.Next(201) * -this.direction) + ((float)Main.mouseX + Main.screenPosition.X - this.position.X), this.MountedCenter.Y - 600f)
								{
									X = (center.X * 10f + base.Center.X) / 11f + (float)Main.rand.Next(-100, 101),
									Y = center.Y - (float)(150 * d)
								};
								x6 = (float)Main.mouseX + Main.screenPosition.X - center.X;
								y6 = (float)Main.mouseY + Main.screenPosition.Y - center.Y;
								if (y6 < 0f)
								{
									y6 = y6 * -1f;
								}
								if (y6 < 20f)
								{
									y6 = 20f;
								}
								single16 = (float)Math.Sqrt((double)(x6 * x6 + y6 * y6));
								single16 = single14 / single16;
								x6 = x6 * single16;
								y6 = y6 * single16;
								float single20 = x6 + (float)Main.rand.Next(-40, 41) * 0.03f;
								float single21 = y6 + (float)Main.rand.Next(-40, 41) * 0.03f;
								single20 = single20 * ((float)Main.rand.Next(75, 150) * 0.01f);
								center.X = center.X + (float)Main.rand.Next(-50, 51);
								int num51 = Projectile.NewProjectile(center.X, center.Y, single20, single21, num46, num47, single15, i, 0f, 0f);
								Main.projectile[num51].noDropItem = true;
							}
						}
						else if (item.type == ItemID.Minishark || item.type == ItemID.Megashark)
						{
							float single22 = x6 + (float)Main.rand.Next(-40, 41) * 0.01f;
							float single23 = y6 + (float)Main.rand.Next(-40, 41) * 0.01f;
							Projectile.NewProjectile(center.X, center.Y, single22, single23, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.SnowballCannon)
						{
							float single24 = x6 + (float)Main.rand.Next(-40, 41) * 0.02f;
							float single25 = y6 + (float)Main.rand.Next(-40, 41) * 0.02f;
							int num52 = Projectile.NewProjectile(center.X, center.Y, single24, single25, num46, num47, single15, i, 0f, 0f);
							Main.projectile[num52].ranged = true;
							Main.projectile[num52].thrown = false;
						}
						else if (item.type == ItemID.NailGun)
						{
							float single26 = x6 + (float)Main.rand.Next(-40, 41) * 0.02f;
							float single27 = y6 + (float)Main.rand.Next(-40, 41) * 0.02f;
							Projectile.NewProjectile(center.X, center.Y, single26, single27, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.ShadowFlameHexDoll)
						{
							Vector2 vector232 = new Vector2(x6, y6);
							vector232.Normalize();
							Vector2 vector233 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
							vector233.Normalize();
							vector232 = (vector232 * 4f) + vector233;
							vector232.Normalize();
							vector232 = vector232 * item.shootSpeed;
							float single28 = (float)Main.rand.Next(10, 80) * 0.001f;
							if (Main.rand.Next(2) == 0)
							{
								single28 = single28 * -1f;
							}
							float single29 = (float)Main.rand.Next(10, 80) * 0.001f;
							if (Main.rand.Next(2) == 0)
							{
								single29 = single29 * -1f;
							}
							Projectile.NewProjectile(center.X, center.Y, vector232.X, vector232.Y, num46, num47, single15, i, single29, single28);
						}
						else if (item.type == ItemID.HellwingBow)
						{
							Vector2 x7 = new Vector2(x6, y6);
							float single30 = x7.Length();
							x7.X = x7.X + (float)Main.rand.Next(-100, 101) * 0.01f * single30 * 0.15f;
							x7.Y = x7.Y + (float)Main.rand.Next(-100, 101) * 0.01f * single30 * 0.15f;
							float x8 = x6 + (float)Main.rand.Next(-40, 41) * 0.03f;
							float y7 = y6 + (float)Main.rand.Next(-40, 41) * 0.03f;
							x7.Normalize();
							x7 = x7 * single30;
							x8 = x8 * ((float)Main.rand.Next(50, 150) * 0.01f);
							y7 = y7 * ((float)Main.rand.Next(50, 150) * 0.01f);
							Vector2 vector234 = new Vector2(x8, y7);
							vector234.Normalize();
							vector234 = vector234 * single30;
							x8 = vector234.X;
							y7 = vector234.Y;
							Projectile.NewProjectile(center.X, center.Y, x8, y7, num46, num47, single15, i, x7.X, x7.Y);
						}
						else if (item.type == ItemID.Xenopopper)
						{
							Vector2 vector235 = (Vector2.Normalize(new Vector2(x6, y6)) * 40f) * item.scale;
							if (Collision.CanHit(center, 0, 0, center + vector235, 0, 0))
							{
								center = center + vector235;
							}
							float rotation = (new Vector2(x6, y6)).ToRotation();
							float single31 = 2.09439516f;
							int num53 = Main.rand.Next(4, 5);
							if (Main.rand.Next(4) == 0)
							{
								num53++;
							}
							for (int e = 0; e < num53; e++)
							{
								float single32 = (float)Main.rand.NextDouble() * 0.2f + 0.05f;
								Vector2 vector236 = new Vector2(x6, y6);
								double num54 = (double)(single31 * (float)Main.rand.NextDouble() - single31 / 2f);
								vector21 = new Vector2();
								Vector2 vector237 = vector236.RotatedBy(num54, vector21) * single32;
								int num55 = Projectile.NewProjectile(center.X, center.Y, vector237.X, vector237.Y, 444, num47, single15, i, rotation, 0f);
								Main.projectile[num55].localAI[0] = (float)num46;
								Main.projectile[num55].localAI[1] = single14;
							}
						}
						else if (item.type == ItemID.Gatligator)
						{
							float single33 = x6 + (float)Main.rand.Next(-40, 41) * 0.05f;
							float single34 = y6 + (float)Main.rand.Next(-40, 41) * 0.05f;
							if (Main.rand.Next(3) == 0)
							{
								single33 = single33 * (1f + (float)Main.rand.Next(-30, 31) * 0.02f);
								single34 = single34 * (1f + (float)Main.rand.Next(-30, 31) * 0.02f);
							}
							Projectile.NewProjectile(center.X, center.Y, single33, single34, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.Razorpine)
						{
							int num56 = 2 + Main.rand.Next(3);
							for (int f = 0; f < num56; f++)
							{
								float single35 = x6;
								float single36 = y6;
								float single37 = 0.025f * (float)f;
								single35 = single35 + (float)Main.rand.Next(-35, 36) * single37;
								single36 = single36 + (float)Main.rand.Next(-35, 36) * single37;
								single16 = (float)Math.Sqrt((double)(single35 * single35 + single36 * single36));
								single16 = single14 / single16;
								single35 = single35 * single16;
								single36 = single36 * single16;
								float x9 = center.X + x6 * (float)(num56 - f) * 1.75f;
								float y8 = center.Y + y6 * (float)(num56 - f) * 1.75f;
								Projectile.NewProjectile(x9, y8, single35, single36, num46, num47, single15, i, (float)Main.rand.Next(0, 10 * (f + 1)), 0f);
							}
						}
						else if (item.type == ItemID.BlizzardStaff)
						{
							int num57 = 2;
							for (int g = 0; g < num57; g++)
							{
								center = new Vector2(this.position.X + (float)this.width * 0.5f + (float)(Main.rand.Next(201) * -this.direction) + ((float)Main.mouseX + Main.screenPosition.X - this.position.X), this.MountedCenter.Y - 600f)
								{
									X = (center.X + base.Center.X) / 2f + (float)Main.rand.Next(-200, 201),
									Y = center.Y - (float)(100 * g)
								};
								x6 = (float)Main.mouseX + Main.screenPosition.X - center.X;
								y6 = (float)Main.mouseY + Main.screenPosition.Y - center.Y;
								if (y6 < 0f)
								{
									y6 = y6 * -1f;
								}
								if (y6 < 20f)
								{
									y6 = 20f;
								}
								single16 = (float)Math.Sqrt((double)(x6 * x6 + y6 * y6));
								single16 = single14 / single16;
								x6 = x6 * single16;
								y6 = y6 * single16;
								float single38 = x6 + (float)Main.rand.Next(-40, 41) * 0.02f;
								float single39 = y6 + (float)Main.rand.Next(-40, 41) * 0.02f;
								Projectile.NewProjectile(center.X, center.Y, single38, single39, num46, num47, single15, i, 0f, (float)Main.rand.Next(5));
							}
						}
						else if (item.type == ItemID.MeteorStaff)
						{
							int num58 = 1;
							for (int h = 0; h < num58; h++)
							{
								center = new Vector2(this.position.X + (float)this.width * 0.5f + (float)(Main.rand.Next(201) * -this.direction) + ((float)Main.mouseX + Main.screenPosition.X - this.position.X), this.MountedCenter.Y - 600f)
								{
									X = (center.X + base.Center.X) / 2f + (float)Main.rand.Next(-200, 201),
									Y = center.Y - (float)(100 * h)
								};
								x6 = (float)Main.mouseX + Main.screenPosition.X - center.X + (float)Main.rand.Next(-40, 41) * 0.03f;
								y6 = (float)Main.mouseY + Main.screenPosition.Y - center.Y;
								if (y6 < 0f)
								{
									y6 = y6 * -1f;
								}
								if (y6 < 20f)
								{
									y6 = 20f;
								}
								single16 = (float)Math.Sqrt((double)(x6 * x6 + y6 * y6));
								single16 = single14 / single16;
								x6 = x6 * single16;
								y6 = y6 * single16;
								float single40 = x6;
								float single41 = y6 + (float)Main.rand.Next(-40, 41) * 0.02f;
								Projectile.NewProjectile(center.X, center.Y, single40 * 0.75f, single41 * 0.75f, num46 + Main.rand.Next(3), num47, single15, i, 0f, 0.5f + (float)Main.rand.NextDouble() * 0.3f);
							}
						}
						else if (item.type == ItemID.LunarFlareBook)
						{
							int num59 = 3;
							for (int i11 = 0; i11 < num59; i11++)
							{
								center = new Vector2(this.position.X + (float)this.width * 0.5f + (float)(Main.rand.Next(201) * -this.direction) + ((float)Main.mouseX + Main.screenPosition.X - this.position.X), this.MountedCenter.Y - 600f)
								{
									X = (center.X + base.Center.X) / 2f + (float)Main.rand.Next(-200, 201),
									Y = center.Y - (float)(100 * i11)
								};
								x6 = (float)Main.mouseX + Main.screenPosition.X - center.X;
								y6 = (float)Main.mouseY + Main.screenPosition.Y - center.Y;
								float y9 = y6 + center.Y;
								if (y6 < 0f)
								{
									y6 = y6 * -1f;
								}
								if (y6 < 20f)
								{
									y6 = 20f;
								}
								single16 = (float)Math.Sqrt((double)(x6 * x6 + y6 * y6));
								single16 = single14 / single16;
								x6 = x6 * single16;
								y6 = y6 * single16;
								Vector2 vector238 = new Vector2(x6, y6) / 2f;
								Projectile.NewProjectile(center.X, center.Y, vector238.X, vector238.Y, num46, num47, single15, i, 0f, y9);
							}
						}
						else if (item.type == ItemID.StarWrath)
						{
							Vector2 vector239 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
							float y10 = vector239.Y;
							if (y10 > base.Center.Y - 200f)
							{
								y10 = base.Center.Y - 200f;
							}
							for (int j1 = 0; j1 < 3; j1++)
							{
								center = base.Center + new Vector2((float)(-Main.rand.Next(0, 401) * this.direction), -600f);
								center.Y = center.Y - (float)(100 * j1);
								Vector2 y11 = vector239 - center;
								if (y11.Y < 0f)
								{
									y11.Y = y11.Y * -1f;
								}
								if (y11.Y < 20f)
								{
									y11.Y = 20f;
								}
								y11.Normalize();
								y11 = y11 * single14;
								x6 = y11.X;
								y6 = y11.Y;
								float single42 = x6;
								float single43 = y6 + (float)Main.rand.Next(-40, 41) * 0.02f;
								Projectile.NewProjectile(center.X, center.Y, single42, single43, num46, num47 * 2, single15, i, 0f, y10);
							}
						}
						else if (item.type == ItemID.Tsunami)
						{
							float single44 = 0.314159274f;
							int num60 = 5;
							Vector2 vector240 = new Vector2(x6, y6);
							vector240.Normalize();
							vector240 = vector240 * 40f;
							bool flag10 = Collision.CanHit(center, 0, 0, center + vector240, 0, 0);
							for (int k1 = 0; k1 < num60; k1++)
							{
								float single45 = (float)k1 - ((float)num60 - 1f) / 2f;
								double num61 = (double)(single44 * single45);
								vector21 = new Vector2();
								Vector2 vector241 = vector240.RotatedBy(num61, vector21);
								if (!flag10)
								{
									vector241 = vector241 - vector240;
								}
								int num62 = Projectile.NewProjectile(center.X + vector241.X, center.Y + vector241.Y, x6, y6, num46, num47, single15, i, 0f, 0f);
								Main.projectile[num62].noDropItem = true;
							}
						}
						else if (item.type == ItemID.ChainGun)
						{
							float single46 = x6 + (float)Main.rand.Next(-40, 41) * 0.03f;
							float single47 = y6 + (float)Main.rand.Next(-40, 41) * 0.03f;
							Projectile.NewProjectile(center.X, center.Y, single46, single47, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.SDMG)
						{
							float single48 = x6 + (float)Main.rand.Next(-40, 41) * 0.005f;
							float single49 = y6 + (float)Main.rand.Next(-40, 41) * 0.005f;
							Projectile.NewProjectile(center.X, center.Y, single48, single49, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.CrystalStorm)
						{
							float single50 = x6;
							float single51 = y6;
							single50 = single50 + (float)Main.rand.Next(-40, 41) * 0.04f;
							single51 = single51 + (float)Main.rand.Next(-40, 41) * 0.04f;
							Projectile.NewProjectile(center.X, center.Y, single50, single51, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.Uzi)
						{
							float single52 = x6;
							float single53 = y6;
							single52 = single52 + (float)Main.rand.Next(-30, 31) * 0.03f;
							single53 = single53 + (float)Main.rand.Next(-30, 31) * 0.03f;
							Projectile.NewProjectile(center.X, center.Y, single52, single53, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.Shotgun)
						{
							int num63 = Main.rand.Next(4, 6);
							for (int l1 = 0; l1 < num63; l1++)
							{
								float single54 = x6;
								float single55 = y6;
								single54 = single54 + (float)Main.rand.Next(-40, 41) * 0.05f;
								single55 = single55 + (float)Main.rand.Next(-40, 41) * 0.05f;
								Projectile.NewProjectile(center.X, center.Y, single54, single55, num46, num47, single15, i, 0f, 0f);
							}
						}
						else if (item.type == ItemID.VenomStaff)
						{
							int num64 = 4;
							if (Main.rand.Next(3) == 0)
							{
								num64++;
							}
							if (Main.rand.Next(4) == 0)
							{
								num64++;
							}
							if (Main.rand.Next(5) == 0)
							{
								num64++;
							}
							for (int m1 = 0; m1 < num64; m1++)
							{
								float single56 = x6;
								float single57 = y6;
								float single58 = 0.05f * (float)m1;
								single56 = single56 + (float)Main.rand.Next(-35, 36) * single58;
								single57 = single57 + (float)Main.rand.Next(-35, 36) * single58;
								single16 = (float)Math.Sqrt((double)(single56 * single56 + single57 * single57));
								single16 = single14 / single16;
								single56 = single56 * single16;
								single57 = single57 * single16;
								float x10 = center.X;
								float y12 = center.Y;
								Projectile.NewProjectile(x10, y12, single56, single57, num46, num47, single15, i, 0f, 0f);
							}
						}
						else if (item.type == ItemID.PoisonStaff)
						{
							int num65 = 3;
							if (Main.rand.Next(3) == 0)
							{
								num65++;
							}
							for (int n1 = 0; n1 < num65; n1++)
							{
								float single59 = x6;
								float single60 = y6;
								float single61 = 0.05f * (float)n1;
								single59 = single59 + (float)Main.rand.Next(-35, 36) * single61;
								single60 = single60 + (float)Main.rand.Next(-35, 36) * single61;
								single16 = (float)Math.Sqrt((double)(single59 * single59 + single60 * single60));
								single16 = single14 / single16;
								single59 = single59 * single16;
								single60 = single60 * single16;
								float x11 = center.X;
								float y13 = center.Y;
								Projectile.NewProjectile(x11, y13, single59, single60, num46, num47, single15, i, 0f, 0f);
							}
						}
						else if (item.type == ItemID.Stynger)
						{
							float single62 = x6;
							float single63 = y6;
							single62 = single62 + (float)Main.rand.Next(-40, 41) * 0.01f;
							single63 = single63 + (float)Main.rand.Next(-40, 41) * 0.01f;
							center.X = center.X + (float)Main.rand.Next(-40, 41) * 0.05f;
							center.Y = center.Y + (float)Main.rand.Next(-45, 36) * 0.05f;
							Projectile.NewProjectile(center.X, center.Y, single62, single63, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.Boomstick)
						{
							int num66 = Main.rand.Next(3, 5);
							for (int o1 = 0; o1 < num66; o1++)
							{
								float single64 = x6;
								float single65 = y6;
								single64 = single64 + (float)Main.rand.Next(-35, 36) * 0.04f;
								single65 = single65 + (float)Main.rand.Next(-35, 36) * 0.04f;
								Projectile.NewProjectile(center.X, center.Y, single64, single65, num46, num47, single15, i, 0f, 0f);
							}
						}
						else if (item.type == ItemID.VampireKnives)
						{
							int num67 = 4;
							if (Main.rand.Next(2) == 0)
							{
								num67++;
							}
							if (Main.rand.Next(4) == 0)
							{
								num67++;
							}
							if (Main.rand.Next(8) == 0)
							{
								num67++;
							}
							if (Main.rand.Next(16) == 0)
							{
								num67++;
							}
							for (int p1 = 0; p1 < num67; p1++)
							{
								float single66 = x6;
								float single67 = y6;
								float single68 = 0.05f * (float)p1;
								single66 = single66 + (float)Main.rand.Next(-35, 36) * single68;
								single67 = single67 + (float)Main.rand.Next(-35, 36) * single68;
								single16 = (float)Math.Sqrt((double)(single66 * single66 + single67 * single67));
								single16 = single14 / single16;
								single66 = single66 * single16;
								single67 = single67 * single16;
								float x12 = center.X;
								float y14 = center.Y;
								Projectile.NewProjectile(x12, y14, single66, single67, num46, num47, single15, i, 0f, 0f);
							}
						}
						else if (item.type == ItemID.StaffoftheFrostHydra || item.type == ItemID.QueenSpiderStaff || item.type == ItemID.RainbowCrystalStaff || item.type == ItemID.MoonlordTurretStaff)
						{
							int num68 = item.shoot;
							for (int q1 = 0; q1 < 1000; q1++)
							{
								if (Main.projectile[q1].owner == this.whoAmI && Main.projectile[q1].type == num68)
								{
									Main.projectile[q1].Kill();
								}
							}
							bool flag11 = (item.type == ItemID.RainbowCrystalStaff ? true : item.type == ItemID.MoonlordTurretStaff);
							int x13 = (int)((float)Main.mouseX + Main.screenPosition.X) / 16;
							int y15 = (int)((float)Main.mouseY + Main.screenPosition.Y) / 16;
							if (this.gravDir == -1f)
							{
								y15 = (int)(Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16;
							}
							if (!flag11)
							{
								while (y15 < Main.maxTilesY - 10 && Main.tile[x13, y15] != null && !WorldGen.SolidTile2(x13, y15) && Main.tile[x13 - 1, y15] != null && !WorldGen.SolidTile2(x13 - 1, y15) && Main.tile[x13 + 1, y15] != null && !WorldGen.SolidTile2(x13 + 1, y15))
								{
									y15++;
								}
								y15--;
							}
							Projectile.NewProjectile((float)Main.mouseX + Main.screenPosition.X, (float)(y15 * 16 - 24), 0f, 15f, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.NimbusRod || item.type == ItemID.CrimsonRod)
						{
							int num69 = Projectile.NewProjectile(center.X, center.Y, x6, y6, num46, num47, single15, i, 0f, 0f);
							Main.projectile[num69].ai[0] = (float)Main.mouseX + Main.screenPosition.X;
							Main.projectile[num69].ai[1] = (float)Main.mouseY + Main.screenPosition.Y;
						}
						else if (item.type == ItemID.ChlorophyteShotbow)
						{
							int num70 = Main.rand.Next(2, 4);
							if (Main.rand.Next(5) == 0)
							{
								num70++;
							}
							for (int r1 = 0; r1 < num70; r1++)
							{
								float single69 = x6;
								float single70 = y6;
								if (r1 > 0)
								{
									single69 = single69 + (float)Main.rand.Next(-35, 36) * 0.04f;
									single70 = single70 + (float)Main.rand.Next(-35, 36) * 0.04f;
								}
								if (r1 > 1)
								{
									single69 = single69 + (float)Main.rand.Next(-35, 36) * 0.04f;
									single70 = single70 + (float)Main.rand.Next(-35, 36) * 0.04f;
								}
								if (r1 > 2)
								{
									single69 = single69 + (float)Main.rand.Next(-35, 36) * 0.04f;
									single70 = single70 + (float)Main.rand.Next(-35, 36) * 0.04f;
								}
								int num71 = Projectile.NewProjectile(center.X, center.Y, single69, single70, num46, num47, single15, i, 0f, 0f);
								Main.projectile[num71].noDropItem = true;
							}
						}
						else if (item.type == ItemID.BeeGun)
						{
							int num72 = Main.rand.Next(1, 4);
							if (Main.rand.Next(6) == 0)
							{
								num72++;
							}
							if (Main.rand.Next(6) == 0)
							{
								num72++;
							}
							if (this.strongBees && Main.rand.Next(3) == 0)
							{
								num72++;
							}
							for (int s1 = 0; s1 < num72; s1++)
							{
								float single71 = x6;
								float single72 = y6;
								single71 = single71 + (float)Main.rand.Next(-35, 36) * 0.02f;
								single72 = single72 + (float)Main.rand.Next(-35, 36) * 0.02f;
								Projectile.NewProjectile(center.X, center.Y, single71, single72, this.beeType(), this.beeDamage(num47), this.beeKB(single15), i, 0f, 0f);
							}
						}
						else if (item.type == ItemID.WaspGun)
						{
							int num73 = Main.rand.Next(2, 5);
							if (Main.rand.Next(5) == 0)
							{
								num73++;
							}
							if (Main.rand.Next(5) == 0)
							{
								num73++;
							}
							for (int t1 = 0; t1 < num73; t1++)
							{
								float single73 = x6;
								float single74 = y6;
								single73 = single73 + (float)Main.rand.Next(-35, 36) * 0.02f;
								single74 = single74 + (float)Main.rand.Next(-35, 36) * 0.02f;
								Projectile.NewProjectile(center.X, center.Y, single73, single74, num46, num47, single15, i, 0f, 0f);
							}
						}
						else if (item.type == ItemID.BatScepter)
						{
							int num74 = Main.rand.Next(1, 4);
							for (int u1 = 0; u1 < num74; u1++)
							{
								float single75 = x6;
								float single76 = y6;
								single75 = single75 + (float)Main.rand.Next(-35, 36) * 0.05f;
								single76 = single76 + (float)Main.rand.Next(-35, 36) * 0.05f;
								Projectile.NewProjectile(center.X, center.Y, single75, single76, num46, num47, single15, i, 0f, 0f);
							}
						}
						else if (item.type == ItemID.TacticalShotgun)
						{
							for (int v1 = 0; v1 < 6; v1++)
							{
								float single77 = x6;
								float single78 = y6;
								single77 = single77 + (float)Main.rand.Next(-40, 41) * 0.05f;
								single78 = single78 + (float)Main.rand.Next(-40, 41) * 0.05f;
								Projectile.NewProjectile(center.X, center.Y, single77, single78, num46, num47, single15, i, 0f, 0f);
							}
						}
						else if (item.type == ItemID.BubbleGun)
						{
							for (int w1 = 0; w1 < 3; w1++)
							{
								float single79 = x6;
								float single80 = y6;
								single79 = single79 + (float)Main.rand.Next(-40, 41) * 0.1f;
								single80 = single80 + (float)Main.rand.Next(-40, 41) * 0.1f;
								Projectile.NewProjectile(center.X, center.Y, single79, single80, num46, num47, single15, i, 0f, 0f);
							}
						}
						else if (item.type == ItemID.Toxikarp)
						{
							Vector2 x14 = new Vector2(x6, y6);
							x14.Normalize();
							x14 = x14 * ((float)Main.rand.Next(70, 91) * 0.1f);
							x14.X = x14.X + (float)Main.rand.Next(-30, 31) * 0.04f;
							x14.Y = x14.Y + (float)Main.rand.Next(-30, 31) * 0.03f;
							Projectile.NewProjectile(center.X, center.Y, x14.X, x14.Y, num46, num47, single15, i, (float)Main.rand.Next(20), 0f);
						}
						else if (item.type == ItemID.ClockworkAssaultRifle)
						{
							float single81 = x6;
							float single82 = y6;
							if (this.itemAnimation < 5)
							{
								single81 = single81 + (float)Main.rand.Next(-40, 41) * 0.01f;
								single82 = single82 + (float)Main.rand.Next(-40, 41) * 0.01f;
								single81 = single81 * 1.1f;
								single82 = single82 * 1.1f;
							}
							else if (this.itemAnimation < 10)
							{
								single81 = single81 + (float)Main.rand.Next(-20, 21) * 0.01f;
								single82 = single82 + (float)Main.rand.Next(-20, 21) * 0.01f;
								single81 = single81 * 1.05f;
								single82 = single82 * 1.05f;
							}
							Projectile.NewProjectile(center.X, center.Y, single81, single82, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.PygmyStaff)
						{
							num46 = Main.rand.Next(191, 195);
							x6 = 0f;
							y6 = 0f;
							center.X = (float)Main.mouseX + Main.screenPosition.X;
							center.Y = (float)Main.mouseY + Main.screenPosition.Y;
							int num75 = Projectile.NewProjectile(center.X, center.Y, x6, y6, num46, num47, single15, i, 0f, 0f);
							Main.projectile[num75].localAI[0] = 30f;
						}
						else if (item.type == ItemID.RavenStaff)
						{
							x6 = 0f;
							y6 = 0f;
							center.X = (float)Main.mouseX + Main.screenPosition.X;
							center.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(center.X, center.Y, x6, y6, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.HornetStaff || item.type == ItemID.ImpStaff)
						{
							x6 = 0f;
							y6 = 0f;
							center.X = (float)Main.mouseX + Main.screenPosition.X;
							center.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(center.X, center.Y, x6, y6, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.OpticStaff)
						{
							x6 = 0f;
							y6 = 0f;
							center.X = (float)Main.mouseX + Main.screenPosition.X;
							center.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Vector2 vector242 = new Vector2(x6, y6);
							vector21 = new Vector2();
							vector242 = vector242.RotatedBy(1.57079637050629, vector21);
							Projectile.NewProjectile(center.X + vector242.X, center.Y + vector242.Y, vector242.X, vector242.Y, num46, num47, single15, i, 0f, 0f);
							vector21 = new Vector2();
							vector242 = vector242.RotatedBy(-3.14159274101257, vector21);
							Projectile.NewProjectile(center.X + vector242.X, center.Y + vector242.Y, vector242.X, vector242.Y, num46 + 1, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.SpiderStaff)
						{
							x6 = 0f;
							y6 = 0f;
							center.X = (float)Main.mouseX + Main.screenPosition.X;
							center.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(center.X, center.Y, x6, y6, num46 + Main.rand.Next(3), num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.PirateStaff)
						{
							x6 = 0f;
							y6 = 0f;
							center.X = (float)Main.mouseX + Main.screenPosition.X;
							center.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(center.X, center.Y, x6, y6, num46 + Main.rand.Next(3), num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.TempestStaff)
						{
							x6 = 0f;
							y6 = 0f;
							center.X = (float)Main.mouseX + Main.screenPosition.X;
							center.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(center.X, center.Y, x6, y6, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.XenoStaff || item.type == ItemID.DeadlySphereStaff || item.type == ItemID.StardustCellStaff)
						{
							x6 = 0f;
							y6 = 0f;
							center.X = (float)Main.mouseX + Main.screenPosition.X;
							center.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(center.X, center.Y, x6, y6, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.StardustDragonStaff)
						{
							int num76 = -1;
							int num77 = -1;
							for (int x15 = 0; x15 < 1000; x15++)
							{
								if (Main.projectile[x15].active && Main.projectile[x15].owner == Main.myPlayer)
								{
									if (num76 == -1 && Main.projectile[x15].type == ProjectileID.StardustDragon1)
									{
										num76 = x15;
									}
									if (num77 == -1 && Main.projectile[x15].type == ProjectileID.StardustDragon4)
									{
										num77 = x15;
									}
									if (num76 != -1 && num77 != -1)
									{
										break;
									}
								}
							}
							if (num76 == -1 && num77 == -1)
							{
								x6 = 0f;
								y6 = 0f;
								center.X = (float)Main.mouseX + Main.screenPosition.X;
								center.Y = (float)Main.mouseY + Main.screenPosition.Y;
								int num78 = Projectile.NewProjectile(center.X, center.Y, x6, y6, num46, num47, single15, i, 0f, 0f);
								num78 = Projectile.NewProjectile(center.X, center.Y, x6, y6, num46 + 1, num47, single15, i, (float)num78, 0f);
								int num79 = num78;
								num78 = Projectile.NewProjectile(center.X, center.Y, x6, y6, num46 + 2, num47, single15, i, (float)num78, 0f);
								Main.projectile[num79].localAI[1] = (float)num78;
								num79 = num78;
								num78 = Projectile.NewProjectile(center.X, center.Y, x6, y6, num46 + 3, num47, single15, i, (float)num78, 0f);
								Main.projectile[num79].localAI[1] = (float)num78;
							}
							else if (num76 != -1 && num77 != -1)
							{
								int num80 = Projectile.NewProjectile(center.X, center.Y, x6, y6, num46 + 1, num47, single15, i, Main.projectile[num77].ai[0], 0f);
								int num81 = num80;
								num80 = Projectile.NewProjectile(center.X, center.Y, x6, y6, num46 + 2, num47, single15, i, (float)num80, 0f);
								Main.projectile[num81].localAI[1] = (float)num80;
								Main.projectile[num81].netUpdate = true;
								Main.projectile[num81].ai[1] = 1f;
								Main.projectile[num80].localAI[1] = (float)num77;
								Main.projectile[num80].netUpdate = true;
								Main.projectile[num80].ai[1] = 1f;
								Main.projectile[num77].ai[0] = (float)Main.projectile[num80].projUUID;
								Main.projectile[num77].netUpdate = true;
								Main.projectile[num77].ai[1] = 1f;
							}
						}
						else if (item.type == ItemID.SlimeStaff)
						{
							x6 = 0f;
							y6 = 0f;
							center.X = (float)Main.mouseX + Main.screenPosition.X;
							center.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(center.X, center.Y, x6, y6, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.shoot > 0 && (Main.projPet[item.shoot] || item.shoot == 72 || item.shoot == 18 || item.shoot == 500 || item.shoot == 650) && !item.summon)
						{
							for (int y16 = 0; y16 < 1000; y16++)
							{
								if (Main.projectile[y16].active && Main.projectile[y16].owner == this.whoAmI)
								{
									if (item.shoot == 72)
									{
										if (Main.projectile[y16].type == ProjectileID.BlueFairy || Main.projectile[y16].type == ProjectileID.PinkFairy || Main.projectile[y16].type == ProjectileID.GreenFairy)
										{
											Main.projectile[y16].Kill();
										}
									}
									else if (item.shoot == Main.projectile[y16].type)
									{
										Main.projectile[y16].Kill();
									}
								}
							}
							Projectile.NewProjectile(center.X, center.Y, x6, y6, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.SoulDrain)
						{
							vector2.X = (float)Main.mouseX + Main.screenPosition.X;
							vector2.Y = (float)Main.mouseY + Main.screenPosition.Y;
							while (Collision.CanHitLine(this.position, this.width, this.height, center, 1, 1))
							{
								center.X = center.X + x6;
								center.Y = center.Y + y6;
								if ((center - vector2).Length() >= 20f + Math.Abs(x6) + Math.Abs(y6))
								{
									continue;
								}
								center = vector2;
								break;
							}
							Projectile.NewProjectile(center.X, center.Y, 0f, 0f, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.ClingerStaff)
						{
							x.X = (float)Main.mouseX + Main.screenPosition.X;
							x.Y = (float)Main.mouseY + Main.screenPosition.Y;
							while (Collision.CanHitLine(this.position, this.width, this.height, center, 1, 1))
							{
								center.X = center.X + x6;
								center.Y = center.Y + y6;
								if ((center - x).Length() >= 20f + Math.Abs(x6) + Math.Abs(y6))
								{
									continue;
								}
								center = x;
								break;
							}
							bool flag12 = false;
							int y17 = (int)center.Y / 16;
							int x16 = (int)center.X / 16;
							int num82 = y17;
							while (y17 < Main.maxTilesY - 10 && y17 - num82 < 30 && !WorldGen.SolidTile(x16, y17))
							{
								y17++;
							}
							if (!WorldGen.SolidTile(x16, y17))
							{
								flag12 = true;
							}
							float single83 = (float)(y17 * 16);
							y17 = num82;
							while (y17 > 10 && num82 - y17 < 30 && !WorldGen.SolidTile(x16, y17))
							{
								y17--;
							}
							float single84 = (float)(y17 * 16 + 16);
							float single85 = single83 - single84;
							int num83 = 10;
							if (single85 > (float)(16 * num83))
							{
								single85 = (float)(16 * num83);
							}
							single84 = single83 - single85;
							center.X = (float)((int)(center.X / 16f) * 16);
							if (!flag12)
							{
								Projectile.NewProjectile(center.X, center.Y, 0f, 0f, num46, num47, single15, i, single84, single85);
							}
						}
						else if (item.type == ItemID.PortalGun)
						{
							int num84 = (this.altFunctionUse == 2 ? 1 : 0);
							Projectile.NewProjectile(center.X, center.Y, x6, y6, num46, num47, single15, i, 0f, (float)num84);
						}
						else if (item.type == ItemID.SolarEruption)
						{
							float single86 = (Main.rand.NextFloat() - 0.5f) * 0.7853982f;
							Vector2 vector243 = new Vector2(x6, y6);
							Projectile.NewProjectile(center.X, center.Y, vector243.X, vector243.Y, num46, num47, single15, i, 0f, single86);
						}
						else if (item.type == ItemID.NebulaBlaze)
						{
							float single87 = (Main.rand.NextFloat() - 0.5f) * 0.7853982f;
							for (int a1 = 0; a1 < 10; a1++)
							{
								Vector2 vector244 = new Vector2(x6, y6);
								double num85 = (double)single87;
								vector21 = new Vector2();
								if (Collision.CanHit(center, 0, 0, center + (vector244.RotatedBy(num85, vector21) * 100f), 0, 0))
								{
									break;
								}
								single87 = (Main.rand.NextFloat() - 0.5f) * 0.7853982f;
							}
							Vector2 vector245 = new Vector2(x6, y6);
							double num86 = (double)single87;
							vector21 = new Vector2();
							Vector2 vector246 = vector245.RotatedBy(num86, vector21) * (0.85f + Main.rand.NextFloat() * 0.3f);
							Projectile.NewProjectile(center.X, center.Y, vector246.X, vector246.Y, num46, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.VortexBeater)
						{
							Projectile.NewProjectile(center.X, center.Y, x6, y6, 615, num47, single15, i, (float)(5 * Main.rand.Next(0, 20)), 0f);
						}
						else if (item.type == ItemID.Phantasm)
						{
							Projectile.NewProjectile(center.X, center.Y, x6, y6, 630, num47, single15, i, 0f, 0f);
						}
						else if (item.type == ItemID.FireworksLauncher)
						{
							for (int b1 = 0; b1 < 2; b1++)
							{
								float single88 = x6;
								float single89 = y6;
								single88 = single88 + (float)Main.rand.Next(-40, 41) * 0.05f;
								single89 = single89 + (float)Main.rand.Next(-40, 41) * 0.05f;
								Vector2 vector247 = new Vector2(single88, single89);
								double num87 = (double)(-1.57079637f * (float)this.direction);
								vector21 = new Vector2();
								Vector2 vector248 = center + (Vector2.Normalize(vector247.RotatedBy(num87, vector21)) * 6f);
								Projectile.NewProjectile(vector248.X, vector248.Y, single88, single89, 167 + Main.rand.Next(4), num47, single15, i, 0f, 1f);
							}
						}
						else if (item.type != ItemID.PainterPaintballGun)
						{
							int num88 = Projectile.NewProjectile(center.X, center.Y, x6, y6, num46, num47, single15, i, 0f, 0f);
							if (item.type == ItemID.FrostStaff)
							{
								Main.projectile[num88].magic = true;
							}
							if (item.type == ItemID.IceBlade || item.type == ItemID.Frostbrand)
							{
								Main.projectile[num88].melee = true;
							}
							if (num46 == 80)
							{
								Main.projectile[num88].ai[0] = (float)Player.tileTargetX;
								Main.projectile[num88].ai[1] = (float)Player.tileTargetY;
							}
							if (num46 == 442)
							{
								Main.projectile[num88].ai[0] = (float)Player.tileTargetX;
								Main.projectile[num88].ai[1] = (float)Player.tileTargetY;
							}
							if ((this.thrownCost50 || this.thrownCost33) && this.inventory[this.selectedItem].thrown)
							{
								Main.projectile[num88].noDropItem = true;
							}
							if (Main.projectile[num88].aiStyle == 99)
							{
								AchievementsHelper.HandleSpecialEvent(this, 7);
							}
						}
						else
						{
							float single90 = x6;
							float single91 = y6;
							single90 = single90 + (float)Main.rand.Next(-1, 2) * 0.5f;
							single91 = single91 + (float)Main.rand.Next(-1, 2) * 0.5f;
							if (Collision.CanHitLine(base.Center, 0, 0, center + (new Vector2(single90, single91) * 2f), 0, 0))
							{
								center = center + new Vector2(single90, single91);
							}
							Projectile.NewProjectile(center.X, center.Y - this.gravDir * 4f, single90, single91, num46, num47, single15, i, 0f, (float)Main.rand.Next(12) / 6f);
						}
					}
					else if (item.useStyle == 5)
					{
						this.itemRotation = 0f;
						NetMessage.SendData((int)PacketTypes.PlayerAnimation, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				if (this.whoAmI == Main.myPlayer && (item.type == ItemID.Wrench || item.type == ItemID.WireCutter || item.type == ItemID.Actuator || item.type == ItemID.BlueWrench || item.type == ItemID.GreenWrench) && this.position.X / 16f - (float)Player.tileRangeX - (float)item.tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)item.tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)item.tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)item.tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
				{
					this.showItemIcon = true;
					if (this.itemAnimation > 0 && this.itemTime == 0 && this.controlUseItem)
					{
						int num89 = Player.tileTargetX;
						int num90 = Player.tileTargetY;
						if (item.type == ItemID.Wrench)
						{
							int num91 = -1;
							int num92 = 0;
							while (num92 < 58)
							{
								if (this.inventory[num92].stack <= 0 || this.inventory[num92].type != 530)
								{
									num92++;
								}
								else
								{
									num91 = num92;
									break;
								}
							}
							if (num91 >= 0 && WorldGen.PlaceWire(num89, num90))
							{
								Item item8 = this.inventory[num91];
								item8.stack = item8.stack - 1;
								if (this.inventory[num91].stack <= 0)
								{
									this.inventory[num91].SetDefaults(0, false);
								}
								this.itemTime = item.useTime;
								NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 5, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
							}
						}
						else if (item.type == ItemID.BlueWrench)
						{
							int num93 = -1;
							int num94 = 0;
							while (num94 < 58)
							{
								if (this.inventory[num94].stack <= 0 || this.inventory[num94].type != 530)
								{
									num94++;
								}
								else
								{
									num93 = num94;
									break;
								}
							}
							if (num93 >= 0 && WorldGen.PlaceWire2(num89, num90))
							{
								Item item9 = this.inventory[num93];
								item9.stack = item9.stack - 1;
								if (this.inventory[num93].stack <= 0)
								{
									this.inventory[num93].SetDefaults(0, false);
								}
								this.itemTime = item.useTime;
								NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 10, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
							}
						}
						if (item.type == ItemID.GreenWrench)
						{
							int num95 = -1;
							int num96 = 0;
							while (num96 < 58)
							{
								if (this.inventory[num96].stack <= 0 || this.inventory[num96].type != 530)
								{
									num96++;
								}
								else
								{
									num95 = num96;
									break;
								}
							}
							if (num95 >= 0 && WorldGen.PlaceWire3(num89, num90))
							{
								Item item10 = this.inventory[num95];
								item10.stack = item10.stack - 1;
								if (this.inventory[num95].stack <= 0)
								{
									this.inventory[num95].SetDefaults(0, false);
								}
								this.itemTime = item.useTime;
								NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 12, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
							}
						}
						else if (item.type != ItemID.WireCutter)
						{
							if (item.type == ItemID.Actuator && item.stack > 0 && WorldGen.PlaceActuator(num89, num90))
							{
								this.itemTime = item.useTime;
								NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 8, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
								Item item11 = item;
								item11.stack = item11.stack - 1;
								if (item.stack <= 0)
								{
									item.SetDefaults(0, false);
								}
							}
						}
						else if (WorldGen.KillActuator(num89, num90))
						{
							this.itemTime = item.useTime;
							NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 9, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
						}
						else if (WorldGen.KillWire3(num89, num90))
						{
							this.itemTime = item.useTime;
							NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 13, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
						}
						else if (WorldGen.KillWire2(num89, num90))
						{
							this.itemTime = item.useTime;
							NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 11, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
						}
						else if (WorldGen.KillWire(num89, num90))
						{
							this.itemTime = item.useTime;
							NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 6, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
						}
					}
				}
				if (this.itemAnimation > 0 && this.itemTime == 0 && (item.type == ItemID.Bell || item.type == ItemID.Harp))
				{
					this.itemTime = item.useTime;
					Vector2 vector249 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float x17 = (float)Main.mouseX + Main.screenPosition.X - vector249.X;
					float y18 = (float)Main.mouseY + Main.screenPosition.Y - vector249.Y;
					float single92 = (float)Math.Sqrt((double)(x17 * x17 + y18 * y18));
					single92 = single92 / (float)(Main.screenHeight / 2);
					if (single92 > 1f)
					{
						single92 = 1f;
					}
					single92 = single92 * 2f - 1f;
					if (single92 < -1f)
					{
						single92 = -1f;
					}
					if (single92 > 1f)
					{
						single92 = 1f;
					}
					Main.harpNote = single92;
					NetMessage.SendData((int)PacketTypes.PlayHarp, -1, -1, "", this.whoAmI, single92, 0f, 0f, 0, 0, 0);
				}
				if ((item.type >= ItemID.EmptyBucket && item.type <= ItemID.LavaBucket || item.type == ItemID.HoneyBucket || item.type == ItemID.BottomlessBucket || item.type == ItemID.SuperAbsorbantSponge) && this.position.X / 16f - (float)Player.tileRangeX - (float)item.tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)item.tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)item.tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)item.tileBoost - 2f >= (float)Player.tileTargetY)
				{
					this.showItemIcon = true;
					if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
					{
						if (item.type == ItemID.EmptyBucket || item.type == ItemID.SuperAbsorbantSponge && Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 0)
						{
							int num98 = Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType();
							int num99 = 0;
							for (int c1 = Player.tileTargetX - 1; c1 <= Player.tileTargetX + 1; c1++)
							{
								for (int d1 = Player.tileTargetY - 1; d1 <= Player.tileTargetY + 1; d1++)
								{
									if (Main.tile[c1, d1].liquidType() == num98)
									{
										num99 = num99 + Main.tile[c1, d1].liquid;
									}
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0 && (num99 > 100 || item.type == ItemID.SuperAbsorbantSponge))
							{
								int num100 = Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType();
								if (item.type != ItemID.SuperAbsorbantSponge)
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].lava())
									{
										Item item12 = item;
										item12.stack = item12.stack - 1;
										this.PutItemInInventory(207, this.selectedItem);
									}
									else if (!Main.tile[Player.tileTargetX, Player.tileTargetY].honey())
									{
										Item item13 = item;
										item13.stack = item13.stack - 1;
										this.PutItemInInventory(206, this.selectedItem);
									}
									else
									{
										Item item14 = item;
										item14.stack = item14.stack - 1;
										this.PutItemInInventory(1128, this.selectedItem);
									}
								}
								this.itemTime = item.useTime;
								int num101 = Main.tile[Player.tileTargetX, Player.tileTargetY].liquid;
								Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 0;
								Main.tile[Player.tileTargetX, Player.tileTargetY].lava(false);
								Main.tile[Player.tileTargetX, Player.tileTargetY].honey(false);
								WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, false);
								if (Main.netMode != 1)
								{
									Liquid.AddWater(Player.tileTargetX, Player.tileTargetY);
								}
								else
								{
									NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
								}
								for (int e1 = Player.tileTargetX - 1; e1 <= Player.tileTargetX + 1; e1++)
								{
									for (int f1 = Player.tileTargetY - 1; f1 <= Player.tileTargetY + 1; f1++)
									{
										if (num101 < 256 && Main.tile[e1, f1].liquidType() == num98)
										{
											int num102 = Main.tile[e1, f1].liquid;
											if (num102 + num101 > 255)
											{
												num102 = 255 - num101;
											}
											num101 = num101 + num102;
											Tile tile1 = Main.tile[e1, f1];
											tile1.liquid = (byte)(tile1.liquid - (byte)num102);
											Main.tile[e1, f1].liquidType(num100);
											if (Main.tile[e1, f1].liquid == 0)
											{
												Main.tile[e1, f1].lava(false);
												Main.tile[e1, f1].honey(false);
											}
											WorldGen.SquareTileFrame(e1, f1, false);
											if (Main.netMode != 1)
											{
												Liquid.AddWater(e1, f1);
											}
											else
											{
												NetMessage.sendWater(e1, f1);
											}
										}
									}
								}
							}
						}
						else if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid < 200 && (!Main.tile[Player.tileTargetX, Player.tileTargetY].nactive() || !Main.tileSolid[Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tileSolidTop[Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
						{
							if (item.type == ItemID.LavaBucket)
							{
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 1)
								{
									Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType(1);
									Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 255;
									WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
									Item item15 = item;
									item15.stack = item15.stack - 1;
									this.PutItemInInventory(205, this.selectedItem);
									this.itemTime = item.useTime;
									if (Main.netMode == 1)
									{
										NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
									}
								}
							}
							else if (item.type != ItemID.WaterBucket && item.type != ItemID.BottomlessBucket)
							{
								if (item.type == ItemID.HoneyBucket && (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 2))
								{
									Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType(2);
									Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 255;
									WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
									Item item16 = item;
									item16.stack = item16.stack - 1;
									this.PutItemInInventory(205, this.selectedItem);
									this.itemTime = item.useTime;
									if (Main.netMode == 1)
									{
										NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
									}
								}
							}
							else if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 0)
							{
								Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType(0);
								Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 255;
								WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
								if (item.type != ItemID.BottomlessBucket)
								{
									Item item17 = item;
									item17.stack = item17.stack - 1;
									this.PutItemInInventory(205, this.selectedItem);
								}
								this.itemTime = item.useTime;
								if (Main.netMode == 1)
								{
									NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
								}
							}
						}
					}
				}
				if (this.channel)
				{
					Player player7 = this;
					player7.toolTime = player7.toolTime - 1;
					if (this.toolTime < 0)
					{
						if (item.pick <= 0)
						{
							this.toolTime = (int)((float)item.useTime * this.pickSpeed);
						}
						else
						{
							this.toolTime = item.useTime;
						}
					}
				}
				else
				{
					this.toolTime = this.itemTime;
				}
				if ((item.pick > 0 || item.axe > 0 || item.hammer > 0) && this.position.X / 16f - (float)Player.tileRangeX - (float)item.tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)item.tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)item.tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)item.tileBoost - 2f >= (float)Player.tileTargetY)
				{
					int num103 = -1;
					int num104 = 0;
					bool flag13 = true;
					this.showItemIcon = true;
					if (this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem && (!Main.tile[Player.tileTargetX, Player.tileTargetY].active() || !Main.tileHammer[Main.tile[Player.tileTargetX, Player.tileTargetY].type] && !Main.tileSolid[Main.tile[Player.tileTargetX, Player.tileTargetY].type] && Main.tile[Player.tileTargetX, Player.tileTargetY].type != 314 && Main.tile[Player.tileTargetX, Player.tileTargetY].type != 351))
					{
						this.poundRelease = false;
					}
					if (Main.tile[Player.tileTargetX, Player.tileTargetY].active())
					{
						if (item.pick > 0 && !Main.tileAxe[Main.tile[Player.tileTargetX, Player.tileTargetY].type] && !Main.tileHammer[Main.tile[Player.tileTargetX, Player.tileTargetY].type] || item.axe > 0 && Main.tileAxe[Main.tile[Player.tileTargetX, Player.tileTargetY].type] || item.hammer > 0 && Main.tileHammer[Main.tile[Player.tileTargetX, Player.tileTargetY].type])
						{
							flag13 = false;
						}
						if (this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
						{
							num103 = this.hitTile.HitObject(Player.tileTargetX, Player.tileTargetY, 1);
							if (Main.tileNoFail[Main.tile[Player.tileTargetX, Player.tileTargetY].type])
							{
								num104 = 100;
							}
							if (Main.tileHammer[Main.tile[Player.tileTargetX, Player.tileTargetY].type])
							{
								flag13 = false;
								if (item.hammer > 0)
								{
									num104 = num104 + item.hammer;
									if (!WorldGen.CanKillTile(Player.tileTargetX, Player.tileTargetY))
									{
										num104 = 0;
									}
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 26 && (item.hammer < 80 || !Main.hardMode))
									{
										num104 = 0;
										this.Hurt(this.statLife / 2, -this.direction, false, false, Lang.deathMsg(-1, -1, -1, 4), false);
									}
									AchievementsHelper.CurrentlyMining = true;
									if (this.hitTile.AddDamage(num103, num104, true) < 100)
									{
										WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0, 0, 0);
										}
									}
									else
									{
										this.hitTile.Clear(num103);
										WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
										}
									}
									if (num104 != 0)
									{
										this.hitTile.Prune();
									}
									this.itemTime = item.useTime;
									AchievementsHelper.CurrentlyMining = false;
								}
							}
							else if (Main.tileAxe[Main.tile[Player.tileTargetX, Player.tileTargetY].type])
							{
								num104 = (Main.tile[Player.tileTargetX, Player.tileTargetY].type != 80 ? num104 + item.axe : num104 + item.axe * 3);
								if (item.axe > 0)
								{
									AchievementsHelper.CurrentlyMining = true;
									if (!WorldGen.CanKillTile(Player.tileTargetX, Player.tileTargetY))
									{
										num104 = 0;
									}
									if (this.hitTile.AddDamage(num103, num104, true) < 100)
									{
										WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0, 0, 0);
										}
									}
									else
									{
										this.hitTile.Clear(num103);
										WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
										}
									}
									if (num104 != 0)
									{
										this.hitTile.Prune();
									}
									this.itemTime = item.useTime;
									AchievementsHelper.CurrentlyMining = false;
								}
							}
							else if (item.pick > 0)
							{
								this.PickTile(Player.tileTargetX, Player.tileTargetY, item.pick);
								this.itemTime = (int)((float)item.useTime * this.pickSpeed);
							}
							if (item.pick > 0)
							{
								this.itemTime = (int)((float)item.useTime * this.pickSpeed);
							}
							if (item.hammer <= 0 || !Main.tile[Player.tileTargetX, Player.tileTargetY].active() || (!Main.tileSolid[Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 10) && Main.tile[Player.tileTargetX, Player.tileTargetY].type != 314 && Main.tile[Player.tileTargetX, Player.tileTargetY].type != 351 || !this.poundRelease)
							{
								this.poundRelease = false;
							}
							else
							{
								flag13 = false;
								this.itemTime = item.useTime;
								num104 = num104 + (int)((double)item.hammer * 1.25);
								num104 = 100;
								if (Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active() && Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type == 10)
								{
									num104 = 0;
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active() && Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type == 10)
								{
									num104 = 0;
								}
								if (this.hitTile.AddDamage(num103, num104, true) < 100)
								{
									WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, true, false);
								}
								else
								{
									this.hitTile.Clear(num103);
									if (this.poundRelease)
									{
										int num105 = Player.tileTargetX;
										int num106 = Player.tileTargetY;
										if (Main.tile[num105, num106].type == TileID.Platforms)
										{
											if (!Main.tile[num105, num106].halfBrick())
											{
												int num107 = 1;
												int num108 = 2;
												if (Main.tile[num105 + 1, num106 - 1].type == 19 || Main.tile[num105 - 1, num106 + 1].type == 19 || WorldGen.SolidTile(num105 + 1, num106) && !WorldGen.SolidTile(num105 - 1, num106))
												{
													num107 = 2;
													num108 = 1;
												}
												if (Main.tile[num105, num106].slope() == 0)
												{
													WorldGen.SlopeTile(num105, num106, num107);
													int num109 = Main.tile[num105, num106].slope();
													if (Main.netMode == 1)
													{
														NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 14, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)num109, 0, 0, 0);
													}
												}
												else if (Main.tile[num105, num106].slope() != num107)
												{
													WorldGen.SlopeTile(num105, num106, 0);
													int num110 = Main.tile[num105, num106].slope();
													if (Main.netMode == 1)
													{
														NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 14, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)num110, 0, 0, 0);
													}
													WorldGen.PoundTile(num105, num106);
													if (Main.netMode == 1)
													{
														NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 7, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0, 0, 0);
													}
												}
												else
												{
													WorldGen.SlopeTile(num105, num106, num108);
													int num111 = Main.tile[num105, num106].slope();
													if (Main.netMode == 1)
													{
														NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 14, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)num111, 0, 0, 0);
													}
												}
											}
											else
											{
												WorldGen.PoundTile(num105, num106);
												if (Main.netMode == 1)
												{
													NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 7, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0, 0, 0);
												}
											}
										}
										else if (Main.tile[num105, num106].type == TileID.MinecartTrack)
										{
											if (Minecart.FrameTrack(num105, num106, true, false) && Main.netMode == 1)
											{
												NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 15, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0, 0, 0);
											}
										}
										else if (Main.tile[num105, num106].type == TileID.Traps)
										{
											if (Main.tile[num105, num106].frameX != 18)
											{
												Main.tile[num105, num106].frameX = 18;
											}
											else
											{
												Main.tile[num105, num106].frameX = 0;
											}
											if (Main.netMode == 1)
											{
												NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 1);
											}
										}
										else if ((Main.tile[num105, num106].halfBrick() || Main.tile[num105, num106].slope() != 0) && !Main.tileSolidTop[Main.tile[Player.tileTargetX, Player.tileTargetY].type])
										{
											int num112 = 1;
											int num113 = 1;
											int num114 = 2;
											if ((WorldGen.SolidTile(num105 + 1, num106) || Main.tile[num105 + 1, num106].slope() == 1 || Main.tile[num105 + 1, num106].slope() == 3) && !WorldGen.SolidTile(num105 - 1, num106))
											{
												num113 = 2;
												num114 = 1;
											}
											if (WorldGen.SolidTile(num105, num106 - 1) && !WorldGen.SolidTile(num105, num106 + 1))
											{
												num112 = -1;
											}
											if (num112 == 1)
											{
												if (Main.tile[num105, num106].slope() == 0)
												{
													WorldGen.SlopeTile(num105, num106, num113);
												}
												else if (Main.tile[num105, num106].slope() == num113)
												{
													WorldGen.SlopeTile(num105, num106, num114);
												}
												else if (Main.tile[num105, num106].slope() == num114)
												{
													WorldGen.SlopeTile(num105, num106, num113 + 2);
												}
												else if (Main.tile[num105, num106].slope() != num113 + 2)
												{
													WorldGen.SlopeTile(num105, num106, 0);
												}
												else
												{
													WorldGen.SlopeTile(num105, num106, num114 + 2);
												}
											}
											else if (Main.tile[num105, num106].slope() == 0)
											{
												WorldGen.SlopeTile(num105, num106, num113 + 2);
											}
											else if (Main.tile[num105, num106].slope() == num113 + 2)
											{
												WorldGen.SlopeTile(num105, num106, num114 + 2);
											}
											else if (Main.tile[num105, num106].slope() == num114 + 2)
											{
												WorldGen.SlopeTile(num105, num106, num113);
											}
											else if (Main.tile[num105, num106].slope() != num113)
											{
												WorldGen.SlopeTile(num105, num106, 0);
											}
											else
											{
												WorldGen.SlopeTile(num105, num106, num114);
											}
											int num115 = Main.tile[num105, num106].slope();
											if (Main.netMode == 1)
											{
												NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 14, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)num115, 0, 0, 0);
											}
										}
										else
										{
											WorldGen.PoundTile(num105, num106);
											if (Main.netMode == 1)
											{
												NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 7, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0, 0, 0);
											}
										}
										this.poundRelease = false;
									}
								}
							}
						}
					}
					if (this.releaseUseItem)
					{
						this.poundRelease = true;
					}
					int num116 = Player.tileTargetX;
					int num117 = Player.tileTargetY;
					bool flag14 = true;
					if (Main.tile[num116, num117].wall > 0)
					{
						if (Main.wallHouse[Main.tile[num116, num117].wall])
						{
							flag14 = false;
						}
						else
						{
							for (int g1 = num116 - 1; g1 < num116 + 2; g1++)
							{
								int num118 = num117 - 1;
								while (num118 < num117 + 2)
								{
									if (Main.tile[g1, num118].wall == Main.tile[num116, num117].wall)
									{
										num118++;
									}
									else
									{
										flag14 = false;
										break;
									}
								}
							}
						}
					}
					if (flag14 && !Main.tile[num116, num117].active())
					{
						int num119 = -1;
						if ((double)(((float)Main.mouseX + Main.screenPosition.X) / 16f) < Math.Round((double)(((float)Main.mouseX + Main.screenPosition.X) / 16f)))
						{
							num119 = 0;
						}
						int num120 = -1;
						if ((double)(((float)Main.mouseY + Main.screenPosition.Y) / 16f) < Math.Round((double)(((float)Main.mouseY + Main.screenPosition.Y) / 16f)))
						{
							num120 = 0;
						}
						for (int h1 = Player.tileTargetX + num119; h1 <= Player.tileTargetX + num119 + 1; h1++)
						{
							for (int i2 = Player.tileTargetY + num120; i2 <= Player.tileTargetY + num120 + 1; i2++)
							{
								if (flag14)
								{
									num116 = h1;
									num117 = i2;
									if (Main.tile[num116, num117].wall > 0)
									{
										if (Main.wallHouse[Main.tile[num116, num117].wall])
										{
											flag14 = false;
										}
										else
										{
											for (int j2 = num116 - 1; j2 < num116 + 2; j2++)
											{
												int num121 = num117 - 1;
												while (num121 < num117 + 2)
												{
													if (Main.tile[j2, num121].wall == Main.tile[num116, num117].wall)
													{
														num121++;
													}
													else
													{
														flag14 = false;
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
					if (flag13 && Main.tile[num116, num117].wall > 0 && (!Main.tile[num116, num117].active() || num116 != Player.tileTargetX || num117 != Player.tileTargetY || !Main.tileHammer[Main.tile[num116, num117].type] && !this.poundRelease) && this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem && item.hammer > 0)
					{
						bool flag15 = true;
						if (!Main.wallHouse[Main.tile[num116, num117].wall])
						{
							flag15 = false;
							for (int k2 = num116 - 1; k2 < num116 + 2; k2++)
							{
								int num122 = num117 - 1;
								while (num122 < num117 + 2)
								{
									if (Main.tile[k2, num122].wall == WallID.None || Main.wallHouse[Main.tile[k2, num122].wall])
									{
										flag15 = true;
										break;
									}
									else
									{
										num122++;
									}
								}
							}
						}
						if (flag15)
						{
							num103 = this.hitTile.HitObject(num116, num117, 2);
							num104 = num104 + (int)((float)item.hammer * 1.5f);
							if (this.hitTile.AddDamage(num103, num104, true) < 100)
							{
								WorldGen.KillWall(num116, num117, true);
								if (Main.netMode == 1)
								{
									NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 2, (float)num116, (float)num117, 1f, 0, 0, 0);
								}
							}
							else
							{
								this.hitTile.Clear(num103);
								WorldGen.KillWall(num116, num117, false);
								if (Main.netMode == 1)
								{
									NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 2, (float)num116, (float)num117, 0f, 0, 0, 0);
								}
							}
							if (num104 != 0)
							{
								this.hitTile.Prune();
							}
							this.itemTime = item.useTime / 2;
						}
					}
				}
				if (Main.myPlayer == this.whoAmI && item.type == ItemID.RodofDiscord && this.itemAnimation > 0 && this.itemTime == 0)
				{
					this.itemTime = item.useTime;
					y.X = (float)Main.mouseX + Main.screenPosition.X;
					if (this.gravDir != 1f)
					{
						y.Y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY;
					}
					else
					{
						y.Y = (float)Main.mouseY + Main.screenPosition.Y - (float)this.height;
					}
					y.X = y.X - (float)(this.width / 2);
					if (y.X > 50f && y.X < (float)(Main.maxTilesX * 16 - 50) && y.Y > 50f && y.Y < (float)(Main.maxTilesY * 16 - 50))
					{
						int x18 = (int)(y.X / 16f);
						int y19 = (int)(y.Y / 16f);
						if ((Main.tile[x18, y19].wall != WallID.LihzahrdBrickUnsafe || (double)y19 <= Main.worldSurface || NPC.downedPlantBoss) && !Collision.SolidCollision(y, this.width, this.height))
						{
							this.Teleport(y, 1, 0);
							NetMessage.SendData((int)PacketTypes.Teleport, -1, -1, "", 0, (float)this.whoAmI, y.X, y.Y, 1, 0, 0);
							if (this.chaosState)
							{
								Player player8 = this;
								player8.statLife = player8.statLife - this.statLifeMax2 / 7;
								if (Lang.lang <= 1)
								{
									string str = " didn't materialize";
									if (Main.rand.Next(2) == 0)
									{
										str = (!this.Male ? "'s legs appeared where her head should be" : "'s legs appeared where his head should be");
									}
									if (this.statLife <= 0)
									{
										this.KillMe(1, 0, false, str);
									}
								}
								else if (this.statLife <= 0)
								{
									this.KillMe(1, 0, false, "");
								}
								this.lifeRegenCount = 0;
								this.lifeRegenTime = 0;
							}
							this.AddBuff(BuffID.ChaosState, 360, true);
						}
					}
				}
				if (item.type == ItemID.LifeCrystal && this.itemAnimation > 0 && this.statLifeMax < 400 && this.itemTime == 0)
				{
					this.itemTime = item.useTime;
					Player player9 = this;
					player9.statLifeMax = player9.statLifeMax + 20;
					Player player10 = this;
					player10.statLifeMax2 = player10.statLifeMax2 + 20;
					Player player11 = this;
					player11.statLife = player11.statLife + 20;
					if (Main.myPlayer == this.whoAmI)
					{
						this.HealEffect(20, true);
					}
					AchievementsHelper.HandleSpecialEvent(this, 0);
				}
				if (item.type == ItemID.LifeFruit && this.itemAnimation > 0 && this.statLifeMax >= 400 && this.statLifeMax < 500 && this.itemTime == 0)
				{
					this.itemTime = item.useTime;
					Player player12 = this;
					player12.statLifeMax = player12.statLifeMax + 5;
					Player player13 = this;
					player13.statLifeMax2 = player13.statLifeMax2 + 5;
					Player player14 = this;
					player14.statLife = player14.statLife + 5;
					if (Main.myPlayer == this.whoAmI)
					{
						this.HealEffect(5, true);
					}
					AchievementsHelper.HandleSpecialEvent(this, 2);
				}
				if (item.type == ItemID.ManaCrystal && this.itemAnimation > 0 && this.statManaMax < 200 && this.itemTime == 0)
				{
					this.itemTime = item.useTime;
					Player player15 = this;
					player15.statManaMax = player15.statManaMax + 20;
					Player player16 = this;
					player16.statManaMax2 = player16.statManaMax2 + 20;
					Player player17 = this;
					player17.statMana = player17.statMana + 20;
					if (Main.myPlayer == this.whoAmI)
					{
						this.ManaEffect(20);
					}
					AchievementsHelper.HandleSpecialEvent(this, 1);
				}
				if (item.type == ItemID.DemonHeart && this.itemAnimation > 0 && !this.extraAccessory && Main.expertMode && this.itemTime == 0)
				{
					this.itemTime = item.useTime;
					this.extraAccessory = true;
					NetMessage.SendData((int)PacketTypes.PlayerInfo, -1, -1, Main.player[this.whoAmI].name, this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
				}
				this.PlaceThing();
			}
			if (item.type == ItemID.NebulaBlaze)
			{
				Vector2 offsetsPlayerOnhand = Main.OffsetsPlayerOnhand[this.bodyFrame.Y / 56] * 2f;
				if (this.direction != 1)
				{
					offsetsPlayerOnhand.X = (float)this.bodyFrame.Width - offsetsPlayerOnhand.X;
				}
				if (this.gravDir != 1f)
				{
					offsetsPlayerOnhand.Y = (float)this.bodyFrame.Height - offsetsPlayerOnhand.Y;
				}
				offsetsPlayerOnhand = offsetsPlayerOnhand - (new Vector2((float)(this.bodyFrame.Width - this.width), (float)(this.bodyFrame.Height - 42)) / 2f);
			}
			if ((item.damage >= 0 && item.type > 0 && !item.noMelee || item.type == ItemID.BubbleWand || item.type == ItemID.BugNet || item.type == ItemID.GoldenBugNet || item.type == ItemID.NebulaBlaze) && this.itemAnimation > 0)
			{
				bool flag16 = false;
				Rectangle rectangle = new Rectangle((int)this.itemLocation.X, (int)this.itemLocation.Y, 32, 32);
				rectangle.Width = (int)((float)rectangle.Width * item.scale);
				rectangle.Height = (int)((float)rectangle.Height * item.scale);
				if (this.direction == -1)
				{
					rectangle.X = rectangle.X - rectangle.Width;
				}
				if (this.gravDir == 1f)
				{
					rectangle.Y = rectangle.Y - rectangle.Height;
				}
				if (item.useStyle != 1)
				{
					if (item.useStyle == 3)
					{
						if ((double)this.itemAnimation <= (double)this.itemAnimationMax * 0.666)
						{
							if (this.direction == -1)
							{
								rectangle.X = rectangle.X - (int)((double)rectangle.Width * 1.4 - (double)rectangle.Width);
							}
							rectangle.Width = (int)((double)rectangle.Width * 1.4);
							rectangle.Y = rectangle.Y + (int)((double)rectangle.Height * 0.6);
							rectangle.Height = (int)((double)rectangle.Height * 0.6);
						}
						else
						{
							flag16 = true;
						}
					}
				}
				else if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
				{
					if (this.direction == -1)
					{
						rectangle.X = rectangle.X - (int)((double)rectangle.Width * 1.4 - (double)rectangle.Width);
					}
					rectangle.Width = (int)((double)rectangle.Width * 1.4);
					rectangle.Y = rectangle.Y + (int)((double)rectangle.Height * 0.5 * (double)this.gravDir);
					rectangle.Height = (int)((double)rectangle.Height * 1.1);
				}
				else if ((double)this.itemAnimation >= (double)this.itemAnimationMax * 0.666)
				{
					if (this.direction == 1)
					{
						rectangle.X = rectangle.X - (int)((double)rectangle.Width * 1.2);
					}
					rectangle.Width = rectangle.Width * 2;
					rectangle.Y = rectangle.Y - (int)(((double)rectangle.Height * 1.4 - (double)rectangle.Height) * (double)this.gravDir);
					rectangle.Height = (int)((double)rectangle.Height * 1.4);
				}
				float single94 = this.gravDir;
				if (item.type == ItemID.NebulaBlaze)
				{
					flag16 = true;
				}
				if (!flag16)
				{
					if (Main.myPlayer == i && (item.type == ItemID.BugNet || item.type == ItemID.GoldenBugNet))
					{
						for (int n2 = 0; n2 < 200; n2++)
						{
							if (Main.npc[n2].active && Main.npc[n2].catchItem > 0)
							{
								Rectangle rectangle1 = new Rectangle((int)Main.npc[n2].position.X, (int)Main.npc[n2].position.Y, Main.npc[n2].width, Main.npc[n2].height);
								if (rectangle.Intersects(rectangle1) && (item.type == ItemID.GoldenBugNet || Main.npc[n2].noTileCollide || Collision.CanHit(this.position, this.width, this.height, Main.npc[n2].position, Main.npc[n2].width, Main.npc[n2].height)))
								{
									NPC.CatchNPC(n2, i);
								}
							}
						}
					}
					if (Main.myPlayer == i && (item.damage > 0 || item.type == ItemID.GoldenBugNet))
					{
						int num155 = (int)((float)item.damage * this.meleeDamage);
						float single102 = item.knockBack;
						float single103 = 1f;
						if (this.kbGlove)
						{
							single103 = single103 + 1f;
						}
						if (this.kbBuff)
						{
							single103 = single103 + 0.5f;
						}
						single102 = single102 * single103;
						if (this.inventory[this.selectedItem].type == 3106)
						{
							single102 = single102 + single102 * (1f - this.stealth);
						}
						List<ushort> nums1 = null;
						if (item.type == ItemID.StaffofRegrowth)
						{
							nums1 = new List<ushort>(new ushort[] { 3, 24, 52, 61, 62, 71, 73, 74, 82, 83, 84, 110, 113, 115, 184, 205, 201 });
						}
						int x36 = rectangle.X / 16;
						int x37 = (rectangle.X + rectangle.Width) / 16 + 1;
						int y22 = rectangle.Y / 16;
						int y23 = (rectangle.Y + rectangle.Height) / 16 + 1;
						for (int o2 = x36; o2 < x37; o2++)
						{
							for (int p2 = y22; p2 < y23; p2++)
							{
								if (Main.tile[o2, p2] != null && Main.tileCut[Main.tile[o2, p2].type] && (nums1 == null || !nums1.Contains(Main.tile[o2, p2].type)) && Main.tile[o2, p2 + 1] != null && Main.tile[o2, p2 + 1].type != 78 && Main.tile[o2, p2 + 1].type != 380)
								{
									if (item.type != ItemID.Sickle)
									{
										WorldGen.KillTile(o2, p2, false, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)o2, (float)p2, 0f, 0, 0, 0);
										}
									}
									else
									{
										int num156 = Main.tile[o2, p2].type;
										WorldGen.KillTile(o2, p2, false, false, false);
										if (!Main.tile[o2, p2].active())
										{
											int num157 = 0;
											if (num156 == 3 || num156 == 24 || num156 == 61 || num156 == 110 || num156 == 201)
											{
												num157 = Main.rand.Next(1, 3);
											}
											if (num156 == 73 || num156 == 74 || num156 == 113)
											{
												num157 = Main.rand.Next(2, 5);
											}
											if (num157 > 0)
											{
												int num158 = Item.NewItem(o2 * 16, p2 * 16, 16, 16, 1727, num157, false, 0, false);
												if (Main.netMode == 1)
												{
													NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num158, 1f, 0f, 0f, 0, 0, 0);
												}
											}
										}
										if (Main.netMode == 1)
										{
											NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)o2, (float)p2, 0f, 0, 0, 0);
										}
									}
								}
							}
						}
						if (item.type != ItemID.GoldenBugNet)
						{
							for (int q2 = 0; q2 < 200; q2++)
							{
								if (Main.npc[q2].active && Main.npc[q2].immune[i] == 0 && this.attackCD == 0)
								{
									if (!Main.npc[q2].dontTakeDamage)
									{
										if (!Main.npc[q2].friendly || Main.npc[q2].type == NPCID.Guide && this.killGuide || Main.npc[q2].type == NPCID.Clothier && this.killClothier)
										{
											Rectangle rectangle2 = new Rectangle((int)Main.npc[q2].position.X, (int)Main.npc[q2].position.Y, Main.npc[q2].width, Main.npc[q2].height);
											if (rectangle.Intersects(rectangle2) && (Main.npc[q2].noTileCollide || Collision.CanHit(this.position, this.width, this.height, Main.npc[q2].position, Main.npc[q2].width, Main.npc[q2].height)))
											{
												bool flag17 = false;
												if (Main.rand.Next(1, 101) <= this.meleeCrit)
												{
													flag17 = true;
												}
												int num159 = Main.DamageVar((float)num155);
												int num160 = Item.NPCtoBanner(Main.npc[q2].BannerID());
												if (num160 > 0 && this.NPCBannerBuff[num160])
												{
													num155 = (!Main.expertMode ? (int)((double)num155 * 1.5) : num155 * 2);
												}
												this.StatusNPC(item.type, q2);
												this.OnHit(Main.npc[q2].Center.X, Main.npc[q2].Center.Y, Main.npc[q2]);
												if (this.armorPenetration > 0)
												{
													num159 = num159 + Main.npc[q2].checkArmorPenetration(this.armorPenetration);
												}
												int num161 = (int)Main.npc[q2].StrikeNPC(num159, single102, this.direction, flag17, false, false, this);
												if (this.inventory[this.selectedItem].type == 3211)
												{
													Vector2 vector286 = new Vector2((float)(this.direction * 100 + Main.rand.Next(-25, 26)), (float)Main.rand.Next(-75, 76));
													vector286.Normalize();
													vector286 = vector286 * ((float)Main.rand.Next(30, 41) * 0.1f);
													Vector2 center2 = new Vector2((float)(rectangle.X + Main.rand.Next(rectangle.Width)), (float)(rectangle.Y + Main.rand.Next(rectangle.Height)));
													center2 = (center2 + (Main.npc[q2].Center * 2f)) / 3f;
													Projectile.NewProjectile(center2.X, center2.Y, vector286.X, vector286.Y, 524, (int)((double)num155 * 0.7), single102 * 0.7f, this.whoAmI, 0f, 0f);
												}
												if (this.beetleOffense)
												{
													Player player18 = this;
													player18.beetleCounter = player18.beetleCounter + (float)num161;
													this.beetleCountdown = 0;
												}
												if (item.type == ItemID.TheHorsemansBlade && Main.npc[q2].@value > 0f)
												{
													this.pumpkinSword(q2, (int)((double)num155 * 1.5), single102);
												}
												if (this.meleeEnchant == 7)
												{
													Projectile.NewProjectile(Main.npc[q2].Center.X, Main.npc[q2].Center.Y, Main.npc[q2].velocity.X, Main.npc[q2].velocity.Y, 289, 0, 0f, this.whoAmI, 0f, 0f);
												}
												if (this.inventory[this.selectedItem].type == 3106)
												{
													this.stealth = 1f;
													if (Main.netMode == 1)
													{
														NetMessage.SendData((int)PacketTypes.PlayerStealth, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
													}
												}
												if (item.type == ItemID.BeeKeeper)
												{
													int num162 = Main.rand.Next(1, 4);
													if (this.strongBees && Main.rand.Next(3) == 0)
													{
														num162++;
													}
													for (int r2 = 0; r2 < num162; r2++)
													{
														float single104 = (float)(this.direction * 2) + (float)Main.rand.Next(-35, 36) * 0.02f;
														float single105 = (float)Main.rand.Next(-35, 36) * 0.02f;
														single104 = single104 * 0.2f;
														single105 = single105 * 0.2f;
														Projectile.NewProjectile((float)(rectangle.X + rectangle.Width / 2), (float)(rectangle.Y + rectangle.Height / 2), single104, single105, this.beeType(), this.beeDamage(num159 / 3), this.beeKB(0f), i, 0f, 0f);
													}
												}
												if (Main.npc[q2].@value > 0f && this.coins && Main.rand.Next(5) == 0)
												{
													int num163 = 71;
													if (Main.rand.Next(10) == 0)
													{
														num163 = 72;
													}
													if (Main.rand.Next(100) == 0)
													{
														num163 = 73;
													}
													int num164 = Item.NewItem((int)Main.npc[q2].position.X, (int)Main.npc[q2].position.Y, Main.npc[q2].width, Main.npc[q2].height, num163, 1, false, 0, false);
													Main.item[num164].stack = Main.rand.Next(1, 11);
													Main.item[num164].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
													Main.item[num164].velocity.X = (float)Main.rand.Next(10, 31) * 0.2f * (float)this.direction;
													if (Main.netMode == 1)
													{
														NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num164, 0f, 0f, 0f, 0, 0, 0);
													}
												}
												int num165 = Item.NPCtoBanner(Main.npc[q2].BannerID());
												if (num165 >= 0)
												{
													this.lastCreatureHit = num165;
												}
												if (Main.netMode != 0)
												{
													if (!flag17)
													{
														NetMessage.SendData((int)PacketTypes.NpcStrike, -1, -1, "", q2, (float)num159, single102, (float)this.direction, 0, 0, 0);
													}
													else
													{
														NetMessage.SendData((int)PacketTypes.NpcStrike, -1, -1, "", q2, (float)num159, single102, (float)this.direction, 1, 0, 0);
													}
												}
												if (this.accDreamCatcher)
												{
													this.addDPS(num159);
												}
												Main.npc[q2].immune[i] = this.itemAnimation;
												this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
											}
										}
									}
									else if (Main.npc[q2].type == NPCID.BlueJellyfish || Main.npc[q2].type == NPCID.PinkJellyfish || Main.npc[q2].type == NPCID.GreenJellyfish || Main.npc[q2].type == NPCID.BloodJelly)
									{
										Rectangle rectangle3 = new Rectangle((int)Main.npc[q2].position.X, (int)Main.npc[q2].position.Y, Main.npc[q2].width, Main.npc[q2].height);
										if (rectangle.Intersects(rectangle3))
										{
											this.Hurt((int)((double)Main.npc[q2].damage * 1.3), -this.direction, false, false, " was slain...", false);
											Main.npc[q2].immune[i] = this.itemAnimation;
											this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
										}
									}
								}
							}
							if (this.hostile)
							{
								for (int s2 = 0; s2 < 255; s2++)
								{
									if (s2 != i && Main.player[s2].active && Main.player[s2].hostile && !Main.player[s2].immune && !Main.player[s2].dead && (Main.player[i].team == 0 || Main.player[i].team != Main.player[s2].team))
									{
										Rectangle rectangle4 = new Rectangle((int)Main.player[s2].position.X, (int)Main.player[s2].position.Y, Main.player[s2].width, Main.player[s2].height);
										if (rectangle.Intersects(rectangle4) && Collision.CanHit(this.position, this.width, this.height, Main.player[s2].position, Main.player[s2].width, Main.player[s2].height))
										{
											bool flag18 = false;
											if (Main.rand.Next(1, 101) <= 10)
											{
												flag18 = true;
											}
											int num166 = Main.DamageVar((float)num155);
											this.StatusPvP(item.type, s2);
											this.OnHit(Main.player[s2].Center.X, Main.player[s2].Center.Y, Main.player[s2]);
											int num167 = (int)Main.player[s2].Hurt(num166, this.direction, true, false, "", flag18);
											if (this.inventory[this.selectedItem].type == 3211)
											{
												Vector2 vector287 = new Vector2((float)(this.direction * 100 + Main.rand.Next(-25, 26)), (float)Main.rand.Next(-75, 76));
												vector287.Normalize();
												vector287 = vector287 * ((float)Main.rand.Next(30, 41) * 0.1f);
												Vector2 center3 = new Vector2((float)(rectangle.X + Main.rand.Next(rectangle.Width)), (float)(rectangle.Y + Main.rand.Next(rectangle.Height)));
												center3 = (center3 + (Main.player[s2].Center * 2f)) / 3f;
												Projectile.NewProjectile(center3.X, center3.Y, vector287.X, vector287.Y, 524, (int)((double)num155 * 0.7), single102 * 0.7f, this.whoAmI, 0f, 0f);
											}
											if (this.beetleOffense)
											{
												Player player19 = this;
												player19.beetleCounter = player19.beetleCounter + (float)num167;
												this.beetleCountdown = 0;
											}
											if (this.meleeEnchant == 7)
											{
												Projectile.NewProjectile(Main.player[s2].Center.X, Main.player[s2].Center.Y, Main.player[s2].velocity.X, Main.player[s2].velocity.Y, 289, 0, 0f, this.whoAmI, 0f, 0f);
											}
											if (item.type == ItemID.BeeKeeper)
											{
												int num168 = Main.rand.Next(1, 4);
												if (this.strongBees && Main.rand.Next(3) == 0)
												{
													num168++;
												}
												for (int t2 = 0; t2 < num168; t2++)
												{
													float single106 = (float)(this.direction * 2) + (float)Main.rand.Next(-35, 36) * 0.02f;
													float single107 = (float)Main.rand.Next(-35, 36) * 0.02f;
													single106 = single106 * 0.2f;
													single107 = single107 * 0.2f;
													Projectile.NewProjectile((float)(rectangle.X + rectangle.Width / 2), (float)(rectangle.Y + rectangle.Height / 2), single106, single107, this.beeType(), this.beeDamage(num166 / 3), this.beeKB(0f), i, 0f, 0f);
												}
											}
											if (this.inventory[this.selectedItem].type == 3106)
											{
												this.stealth = 1f;
												if (Main.netMode == 1)
												{
													NetMessage.SendData((int)PacketTypes.PlayerStealth, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
												}
											}
											if (item.type == ItemID.TheHorsemansBlade && Main.npc[s2].@value > 0f)
											{
												this.pumpkinSword(s2, (int)((double)num155 * 1.5), single102);
											}
											if (Main.netMode != 0)
											{
												if (!flag18)
												{
													NetMessage.SendData((int)PacketTypes.PlayerDamage, -1, -1, Lang.deathMsg(this.whoAmI, -1, -1, -1), s2, (float)this.direction, (float)num166, 1f, 0, 0, 0);
												}
												else
												{
													NetMessage.SendData((int)PacketTypes.PlayerDamage, -1, -1, Lang.deathMsg(this.whoAmI, -1, -1, -1), s2, (float)this.direction, (float)num166, 1f, 1, 0, 0);
												}
											}
											this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
										}
									}
								}
							}
							if (item.type == ItemID.Hammush && (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.5) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9)))
							{
								float single108 = 0f;
								float single109 = 0f;
								float single110 = 0f;
								float single111 = 0f;
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9))
								{
									single108 = -7f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
								{
									single108 = -6f;
									single109 = 2f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.5))
								{
									single108 = -4f;
									single109 = 4f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3))
								{
									single108 = -2f;
									single109 = 6f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1))
								{
									single109 = 7f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
								{
									single111 = 26f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3))
								{
									single111 = single111 - 4f;
									single110 = single110 - 20f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1))
								{
									single110 = single110 + 6f;
								}
								if (this.direction == -1)
								{
									if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9))
									{
										single111 = single111 - 8f;
									}
									if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
									{
										single111 = single111 - 6f;
									}
								}
								single108 = single108 * 1.5f;
								single109 = single109 * 1.5f;
								single111 = single111 * (float)this.direction;
								single110 = single110 * this.gravDir;
								Projectile.NewProjectile((float)(rectangle.X + rectangle.Width / 2) + single111, (float)(rectangle.Y + rectangle.Height / 2) + single110, (float)this.direction * single109, single108 * this.gravDir, 131, num155 / 2, 0f, i, 0f, 0f);
							}
						}
					}
				}
			}
			if (this.itemTime == 0 && this.itemAnimation > 0)
			{
				if (item.hairDye >= 0)
				{
					this.itemTime = item.useTime;
					if (this.whoAmI == Main.myPlayer)
					{
						this.hairDye = (byte)item.hairDye;
						NetMessage.SendData((int)PacketTypes.PlayerInfo, -1, -1, Main.player[this.whoAmI].name, this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				if (item.healLife > 0)
				{
					Player player20 = this;
					player20.statLife = player20.statLife + item.healLife;
					this.itemTime = item.useTime;
					if (Main.myPlayer == this.whoAmI)
					{
						this.HealEffect(item.healLife, true);
					}
				}
				if (item.healMana > 0)
				{
					Player player21 = this;
					player21.statMana = player21.statMana + item.healMana;
					this.itemTime = item.useTime;
					if (Main.myPlayer == this.whoAmI)
					{
						this.AddBuff(BuffID.ManaSickness, Player.manaSickTime, true);
						this.ManaEffect(item.healMana);
					}
				}
				if (item.buffType > 0)
				{
					if (this.whoAmI == Main.myPlayer && item.buffType != 90 && item.buffType != 27)
					{
						this.AddBuff(item.buffType, item.buffTime, true);
					}
					this.itemTime = item.useTime;
				}
				if (item.type == ItemID.RedPotion)
				{
					this.itemTime = item.useTime;
					if (this.whoAmI == Main.myPlayer)
					{
						this.AddBuff(BuffID.Poisoned, 216000, true);
						this.AddBuff(BuffID.Darkness, 216000, true);
						this.AddBuff(BuffID.Cursed, 216000, true);
						this.AddBuff(BuffID.OnFire, 216000, true);
						this.AddBuff(BuffID.Bleeding, 216000, true);
						this.AddBuff(BuffID.Confused, 216000, true);
						this.AddBuff(BuffID.Slow, 216000, true);
						this.AddBuff(BuffID.Weak, 216000, true);
						this.AddBuff(BuffID.Silenced, 216000, true);
						this.AddBuff(BuffID.BrokenArmor, 216000, true);
						this.AddBuff(BuffID.Suffocation, 216000, true);
					}
				}
			}
			if (this.whoAmI == Main.myPlayer)
			{
				if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == ItemID.GoblinBattleStandard && Main.CanStartInvasion(1, true))
				{
					this.itemTime = item.useTime;
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, -1f, 0f, 0f, 0, 0, 0);
					}
					else if (Main.invasionType == 0)
					{
						Main.invasionDelay = 0;
						Main.StartInvasion(1);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == ItemID.SnowGlobe && Main.CanStartInvasion(2, true))
				{
					this.itemTime = item.useTime;
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, -2f, 0f, 0f, 0, 0, 0);
					}
					else if (Main.invasionType == 0)
					{
						Main.invasionDelay = 0;
						Main.StartInvasion(2);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == ItemID.PirateMap && Main.CanStartInvasion(3, true))
				{
					this.itemTime = item.useTime;
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, -3f, 0f, 0f, 0, 0, 0);
					}
					else if (Main.invasionType == 0)
					{
						Main.invasionDelay = 0;
						Main.StartInvasion(3);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == ItemID.PumpkinMoonMedallion && !Main.dayTime && !Main.pumpkinMoon && !Main.snowMoon)
				{
					this.itemTime = item.useTime;
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, -4f, 0f, 0f, 0, 0, 0);
					}
					else
					{
						Main.NewText(Lang.misc[31], 50, 255, 130, false);
						Main.startPumpkinMoon();
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == ItemID.LunarTablet && Main.dayTime && !Main.eclipse)
				{
					if (Main.netMode != 0)
					{
						NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, -6f, 0f, 0f, 0, 0, 0);
					}
					else
					{
						this.itemTime = item.useTime;
						Main.eclipse = true;
						Main.NewText(Lang.misc[20], 50, 255, 130, false);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == ItemID.CelestialSigil && NPC.downedGolemBoss && Main.hardMode && !NPC.AnyDanger() && !NPC.AnyoneNearCultists())
				{
					this.itemTime = item.useTime;
					if (Main.netMode == 0)
					{
						WorldGen.StartImpendingDoom();
					}
					else
					{
						NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, -8f, 0f, 0f, 0, 0, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == ItemID.NaughtyPresent && !Main.dayTime && !Main.pumpkinMoon && !Main.snowMoon)
				{
					this.itemTime = item.useTime;
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, -5f, 0f, 0f, 0, 0, 0);
					}
					else
					{
						Main.NewText(Lang.misc[34], 50, 255, 130, false);
						Main.startSnowMoon();
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && item.makeNPC > 0 && this.controlUseItem && this.position.X / 16f - (float)Player.tileRangeX - (float)item.tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)item.tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)item.tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)item.tileBoost - 2f >= (float)Player.tileTargetY)
				{
					int x38 = Main.mouseX + (int)Main.screenPosition.X;
					int y24 = Main.mouseY + (int)Main.screenPosition.Y;
					this.itemTime = item.useTime;
					if (!WorldGen.SolidTile(x38 / 16, y24 / 16))
					{
						NPC.ReleaseNPC(x38, y24, item.makeNPC, item.placeStyle, this.whoAmI);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && (item.type == ItemID.SuspiciousLookingEye || item.type == ItemID.WormFood || item.type == ItemID.MechanicalEye || item.type == ItemID.MechanicalWorm || item.type == ItemID.MechanicalSkull || item.type == ItemID.SlimeCrown || item.type == ItemID.Abeemination || item.type == ItemID.BloodySpine) && this.SummonItemCheck())
				{
					if (item.type == ItemID.SlimeCrown)
					{
						this.itemTime = item.useTime;
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, 50f, 0f, 0f, 0, 0, 0);
						}
						else
						{
							NPC.SpawnOnPlayer(i, 50);
						}
					}
					else if (item.type == ItemID.SuspiciousLookingEye)
					{
						if (!Main.dayTime)
						{
							this.itemTime = item.useTime;
							if (Main.netMode == 1)
							{
								NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, 4f, 0f, 0f, 0, 0, 0);
							}
							else
							{
								NPC.SpawnOnPlayer(i, 4);
							}
						}
					}
					else if (item.type == ItemID.WormFood)
					{
						if (this.ZoneCorrupt)
						{
							this.itemTime = item.useTime;
							if (Main.netMode == 1)
							{
								NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, 13f, 0f, 0f, 0, 0, 0);
							}
							else
							{
								NPC.SpawnOnPlayer(i, 13);
							}
						}
					}
					else if (item.type == ItemID.MechanicalEye)
					{
						if (!Main.dayTime)
						{
							this.itemTime = item.useTime;
							if (Main.netMode == 1)
							{
								NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, 125f, 0f, 0f, 0, 0, 0);
								NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, 126f, 0f, 0f, 0, 0, 0);
							}
							else
							{
								NPC.SpawnOnPlayer(i, 125);
								NPC.SpawnOnPlayer(i, 126);
							}
						}
					}
					else if (item.type == ItemID.MechanicalWorm)
					{
						if (!Main.dayTime)
						{
							this.itemTime = item.useTime;
							if (Main.netMode == 1)
							{
								NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, 134f, 0f, 0f, 0, 0, 0);
							}
							else
							{
								NPC.SpawnOnPlayer(i, 134);
							}
						}
					}
					else if (item.type == ItemID.MechanicalSkull)
					{
						if (!Main.dayTime)
						{
							this.itemTime = item.useTime;
							if (Main.netMode == 1)
							{
								NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, 127f, 0f, 0f, 0, 0, 0);
							}
							else
							{
								NPC.SpawnOnPlayer(i, 127);
							}
						}
					}
					else if (item.type == ItemID.Abeemination)
					{
						this.itemTime = item.useTime;
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, 222f, 0f, 0f, 0, 0, 0);
						}
						else
						{
							NPC.SpawnOnPlayer(i, 222);
						}
					}
					else if (item.type == ItemID.BloodySpine && this.ZoneCrimson)
					{
						this.itemTime = item.useTime;
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, 266f, 0f, 0f, 0, 0, 0);
						}
						else
						{
							NPC.SpawnOnPlayer(i, 266);
						}
					}
				}
			}
			if ((item.type == ItemID.MagicMirror || item.type == ItemID.CellPhone || item.type == ItemID.IceMirror) && this.itemAnimation > 0)
			{
				if (this.itemTime == 0)
				{
					this.itemTime = item.useTime;
				}
				else if (this.itemTime == item.useTime / 2)
				{
					this.grappling[0] = -1;
					this.grapCount = 0;
					for (int v2 = 0; v2 < 1000; v2++)
					{
						if (Main.projectile[v2].active && Main.projectile[v2].owner == i && Main.projectile[v2].aiStyle == 7)
						{
							Main.projectile[v2].Kill();
						}
					}
					this.Spawn();
				}
			}
			if (item.type == ItemID.RecallPotion && this.itemAnimation > 0)
			{
				if (this.itemTime == 0)
				{
					this.itemTime = item.useTime;
				}
				else if (this.itemTime == 2)
				{
					this.grappling[0] = -1;
					this.grapCount = 0;
					for (int y25 = 0; y25 < 1000; y25++)
					{
						if (Main.projectile[y25].active && Main.projectile[y25].owner == i && Main.projectile[y25].aiStyle == 7)
						{
							Main.projectile[y25].Kill();
						}
					}
					bool flag19 = this.immune;
					int num175 = this.immuneTime;
					this.Spawn();
					this.immune = flag19;
					this.immuneTime = num175;
					if (item.stack > 0)
					{
						Item item18 = item;
						item18.stack = item18.stack - 1;
					}
				}
			}
			if (item.type == ItemID.TeleportationPotion && this.itemAnimation > 0)
			{
				if (this.itemTime == 0)
				{
					this.itemTime = item.useTime;
				}
				else if (this.itemTime == 2)
				{
					if (Main.netMode == 0)
					{
						this.TeleportationPotion();
					}
					else if (Main.netMode == 1 && this.whoAmI == Main.myPlayer)
					{
						NetMessage.SendData((int)PacketTypes.TeleportationPotion, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
					}
					if (item.stack > 0)
					{
						Item item19 = item;
						item19.stack = item19.stack - 1;
					}
				}
			}
			if (item.type == ItemID.GenderChangePotion && this.itemAnimation > 0)
			{
				if (this.itemTime == 0)
				{
					this.itemTime = item.useTime;
				}
				else if (this.itemTime != 2)
				{
				}
				else
				{
					if (this.whoAmI == Main.myPlayer)
					{
						this.Male = !this.Male;
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.PlayerInfo, -1, -1, this.name, this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
						}
					}
					if (item.stack > 0)
					{
						Item item20 = item;
						item20.stack = item20.stack - 1;
					}
				}
			}
			if (i == Main.myPlayer)
			{
				if (this.itemTime == (int)((float)item.useTime * this.tileSpeed) && item.tileWand > 0)
				{
					int num179 = item.tileWand;
					int num180 = 0;
					while (num180 < 58)
					{
						if (num179 != this.inventory[num180].type || this.inventory[num180].stack <= 0)
						{
							num180++;
						}
						else
						{
							Item item21 = this.inventory[num180];
							item21.stack = item21.stack - 1;
							if (this.inventory[num180].stack > 0)
							{
								break;
							}
							this.inventory[num180] = new Item();
							break;
						}
					}
				}
				if (item.createTile < 0)
				{
					num = (item.createWall <= 0 ? item.useTime : (int)((float)item.useTime * this.wallSpeed));
				}
				else
				{
					num = (int)((float)item.useTime * this.tileSpeed);
				}
				if (this.itemTime == num && item.consumable)
				{
					bool flag20 = true;
					if (item.type == ItemID.RecallPotion || item.type == ItemID.TeleportationPotion)
					{
						flag20 = false;
					}
					if (item.type == ItemID.GenderChangePotion)
					{
						flag20 = false;
					}
					if (item.ranged)
					{
						if (this.ammoCost80 && Main.rand.Next(5) == 0)
						{
							flag20 = false;
						}
						if (this.ammoCost75 && Main.rand.Next(4) == 0)
						{
							flag20 = false;
						}
					}
					if (item.thrown)
					{
						if (this.thrownCost50 && Main.rand.Next(100) < 50)
						{
							flag20 = false;
						}
						if (this.thrownCost33 && Main.rand.Next(100) < 33)
						{
							flag20 = false;
						}
					}
					if (item.type >= ItemID.CopperCoin && item.type <= ItemID.PlatinumCoin)
					{
						flag20 = true;
					}
					if (flag20)
					{
						if (item.stack > 0)
						{
							Item item22 = item;
							item22.stack = item22.stack - 1;
						}
						if (item.stack <= 0)
						{
							this.itemTime = this.itemAnimation;
							Main.blockMouse = true;
						}
					}
				}
				if (item.stack <= 0 && this.itemAnimation == 0)
				{
					this.inventory[this.selectedItem] = new Item();
				}
				if (this.selectedItem == 58)
				{
					if (this.itemAnimation == 0)
					{
						return;
					}
					Main.mouseItem = item.Clone();
				}
			}
		}

		public bool ItemFitsItemFrame(Item i)
		{
			return i.stack > 0;
		}

		public bool ItemFitsWeaponRack(Item i)
		{
			bool flag = false;
			if (i.fishingPole > 0)
			{
				flag = true;
			}
			int num = i.netID;
			if (num == 905 || num == 1326)
			{
				flag = true;
			}
			if (i.damage <= 0 && !flag || i.useStyle <= 0)
			{
				return false;
			}
			return i.stack > 0;
		}

		public bool ItemSpace(Item newItem)
		{
			if (newItem.uniqueStack && this.HasItem(newItem.type))
			{
				return false;
			}
			if (newItem.type == ItemID.Heart || newItem.type == ItemID.Star || newItem.type == ItemID.CandyApple || newItem.type == ItemID.SoulCake || newItem.type == ItemID.CandyCane || newItem.type == ItemID.SugarPlum)
			{
				return true;
			}
			if (ItemID.Sets.NebulaPickup[newItem.type])
			{
				return true;
			}
			int num = 50;
			if (newItem.type == ItemID.CopperCoin || newItem.type == ItemID.SilverCoin || newItem.type == ItemID.GoldCoin || newItem.type == ItemID.PlatinumCoin)
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
				if (newItem.type != ItemID.FallenStar && newItem.type != ItemID.SandBlock && newItem.type != ItemID.Gel && newItem.type != ItemID.PearlsandBlock && newItem.type != ItemID.EbonsandBlock && newItem.type != ItemID.CrimsandBlock)
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

		public void JumpMovement()
		{
			if (this.mount.Active && this.mount.Type == 3 && this.wetSlime == 0 && this.velocity.Y > 0f)
			{
				Rectangle rect = this.getRect();
				rect.Offset(0, this.height - 1);
				rect.Height = 2;
				rect.Inflate(12, 6);
				int num = 0;
				while (num < 200)
				{
					NPC nPC = Main.npc[num];
					if (!nPC.active || nPC.dontTakeDamage || nPC.friendly || !rect.Intersects(nPC.getRect()) || !nPC.noTileCollide && !Collision.CanHit(this.position, this.width, this.height, nPC.position, nPC.width, nPC.height))
					{
						num++;
					}
					else
					{
						float single = 40f * this.minionDamage;
						float single1 = 5f;
						int num1 = this.direction;
						if (this.velocity.X < 0f)
						{
							num1 = -1;
						}
						if (this.velocity.X > 0f)
						{
							num1 = 1;
						}
						nPC.StrikeNPC((int)single, single1, num1, false, false, false, this);
						nPC.immune[this.whoAmI] = 30;
						this.velocity.Y = -10f;
						this.immune = true;
						this.immuneTime = 6;
						break;
					}
				}
			}
			if (!this.controlJump)
			{
				this.jump = 0;
				this.releaseJump = true;
				this.rocketRelease = true;
				return;
			}
			bool flag = false;
			if (this.mount.Active && this.mount.Type == 3 && this.wetSlime > 0)
			{
				flag = true;
			}
			if (this.jump > 0)
			{
				if (this.velocity.Y != 0f)
				{
					this.velocity.Y = -Player.jumpSpeed * this.gravDir;
					if (!this.merman || this.mount.Active && this.mount.Cart)
					{
						Player player = this;
						player.jump = player.jump - 1;
					}
					else if (this.swimTime <= 10)
					{
						this.swimTime = 30;
					}
				}
				else
				{
					this.jump = 0;
				}
			}
			else if ((this.sliding || this.velocity.Y == 0f || flag || this.jumpAgainCloud || this.jumpAgainSandstorm || this.jumpAgainBlizzard || this.jumpAgainFart || this.jumpAgainSail || this.jumpAgainUnicorn || this.wet && this.accFlipper && (!this.mount.Active || !this.mount.Cart)) && (this.releaseJump || this.autoJump && (this.velocity.Y == 0f || this.sliding)))
			{
				if (this.sliding || this.velocity.Y == 0f)
				{
					this.justJumped = true;
				}
				bool flag1 = false;
				if (this.wet && this.accFlipper)
				{
					if (this.swimTime == 0)
					{
						this.swimTime = 30;
					}
					flag1 = true;
				}
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				if (!flag)
				{
					if (this.jumpAgainUnicorn)
					{
						flag6 = true;
						this.jumpAgainUnicorn = false;
					}
					else if (this.jumpAgainSandstorm)
					{
						flag2 = true;
						this.jumpAgainSandstorm = false;
					}
					else if (this.jumpAgainBlizzard)
					{
						flag3 = true;
						this.jumpAgainBlizzard = false;
					}
					else if (this.jumpAgainFart)
					{
						this.jumpAgainFart = false;
						flag4 = true;
					}
					else if (!this.jumpAgainSail)
					{
						this.jumpAgainCloud = false;
					}
					else
					{
						this.jumpAgainSail = false;
						flag5 = true;
					}
				}
				this.canRocket = false;
				this.rocketRelease = false;
				if ((this.velocity.Y == 0f || this.sliding || this.autoJump && this.justJumped) && this.doubleJumpCloud)
				{
					this.jumpAgainCloud = true;
				}
				if ((this.velocity.Y == 0f || this.sliding || this.autoJump && this.justJumped) && this.doubleJumpSandstorm)
				{
					this.jumpAgainSandstorm = true;
				}
				if ((this.velocity.Y == 0f || this.sliding || this.autoJump && this.justJumped) && this.doubleJumpBlizzard)
				{
					this.jumpAgainBlizzard = true;
				}
				if ((this.velocity.Y == 0f || this.sliding || this.autoJump && this.justJumped) && this.doubleJumpFart)
				{
					this.jumpAgainFart = true;
				}
				if ((this.velocity.Y == 0f || this.sliding || this.autoJump && this.justJumped) && this.doubleJumpSail)
				{
					this.jumpAgainSail = true;
				}
				if ((this.velocity.Y == 0f || this.sliding || this.autoJump && this.justJumped) && this.doubleJumpUnicorn)
				{
					this.jumpAgainUnicorn = true;
				}
				if (this.velocity.Y == 0f || flag1 || this.sliding || flag)
				{
					this.velocity.Y = -Player.jumpSpeed * this.gravDir;
					this.jump = Player.jumpHeight;
					if (this.sliding)
					{
						this.velocity.X = (float)(3 * -this.slideDir);
					}
				}
				else if (flag2)
				{
					this.dJumpEffectSandstorm = true;
					int num2 = this.height;
					float single2 = this.gravDir;
					this.velocity.Y = -Player.jumpSpeed * this.gravDir;
					this.jump = Player.jumpHeight * 3;
				}
				else if (flag3)
				{
					this.dJumpEffectBlizzard = true;
					int num3 = this.height;
					float single3 = this.gravDir;
					this.velocity.Y = -Player.jumpSpeed * this.gravDir;
					this.jump = (int)((double)Player.jumpHeight * 1.5);
				}
				else if (flag5)
				{
					this.dJumpEffectSail = true;
					int num4 = this.height;
					if (this.gravDir == -1f)
					{
						num4 = 0;
					}
					this.velocity.Y = -Player.jumpSpeed * this.gravDir;
					this.jump = (int)((double)Player.jumpHeight * 1.25);
				}
				else if (flag4)
				{
					this.dJumpEffectFart = true;
					int num7 = this.height;
					if (this.gravDir == -1f)
					{
						num7 = 0;
					}
					this.velocity.Y = -Player.jumpSpeed * this.gravDir;
					this.jump = Player.jumpHeight * 2;
				}
				else if (!flag6)
				{
					this.dJumpEffectCloud = true;
					int num10 = this.height;
					if (this.gravDir == -1f)
					{
						num10 = 0;
					}
					this.velocity.Y = -Player.jumpSpeed * this.gravDir;
					this.jump = (int)((double)Player.jumpHeight * 0.75);
				}
				else
				{
					this.dJumpEffectUnicorn = true;
					int num13 = this.height;
					float single4 = this.gravDir;
					this.velocity.Y = -Player.jumpSpeed * this.gravDir;
					this.jump = Player.jumpHeight * 2;
					Vector2 center = base.Center;
					Vector2 vector24 = new Vector2(50f, 20f);
					float single5 = 6.28318548f * Main.rand.NextFloat();
				}
			}
			this.releaseJump = false;
		}

		public void KeyDoubleTap(int keyDir)
		{
			if (keyDir == 0)
			{
				if (this.setVortex && !this.mount.Active)
				{
					this.vortexStealthActive = !this.vortexStealthActive;
				}
				if (this.setStardust)
				{
					this.MinionTargetAim();
				}
			}
		}

		public void KeyHoldDown(int keyDir, int holdTime)
		{
			if (keyDir == 0 && this.setStardust && holdTime >= 60)
			{
				this.MinionTargetPoint = Vector2.Zero;
			}
		}

		public void KillMe(double dmg, int hitDirection, bool pvp = false, string deathText = " was slain...")
		{
			bool flag;
			if (this.dead)
			{
				return;
			}
			if (pvp)
			{
				this.pvpDeath = true;
			}
			if (this.trapDebuffSource)
			{
				AchievementsHelper.HandleSpecialEvent(this, 4);
			}
			this.lastDeathPostion = base.Center;
			this.lastDeathTime = DateTime.Now;
			this.showLastDeath = true;
			int num = (int)Terraria.Utils.CoinsCount(out flag, this.inventory, new int[0]);
			if (Main.myPlayer == this.whoAmI)
			{
				this.lostCoins = num;
				this.lostCoinString = Main.ValueToCoins(this.lostCoins);
			}
			if (Main.myPlayer == this.whoAmI)
			{
				Main.mapFullscreen = false;
			}
			if (Main.myPlayer == this.whoAmI)
			{
				if (this.difficulty != 0)
				{
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
				else
				{
					for (int i = 0; i < 59; i++)
					{
						if (this.inventory[i].stack > 0 && this.inventory[i].type >= 1522 && this.inventory[i].type <= 1527)
						{
							int num1 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[i].type, 1, false, 0, false);
							Main.item[num1].netDefaults(this.inventory[i].netID);
							Main.item[num1].Prefix((int)this.inventory[i].prefix);
							Main.item[num1].stack = this.inventory[i].stack;
							Main.item[num1].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
							Main.item[num1].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
							Main.item[num1].noGrabDelay = 100;
							Main.item[num1].favorited = false;
							if (Main.netMode == 1)
							{
								NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num1, 0f, 0f, 0f, 0, 0, 0);
							}
							this.inventory[i].SetDefaults(0, false);
						}
					}
				}
			}
			this.headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
			this.bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
			this.legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
			this.headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
			this.bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
			this.legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
			if (this.stoned)
			{
				this.headPosition = Vector2.Zero;
				this.bodyPosition = Vector2.Zero;
				this.legPosition = Vector2.Zero;
			}
			this.mount.Dismount(this);
			this.dead = true;
			this.respawnTimer = 600;
			bool flag1 = false;
			if (Main.netMode != 0 && !pvp)
			{
				int num12 = 0;
				while (num12 < 200)
				{
					if (!Main.npc[num12].active || !Main.npc[num12].boss && Main.npc[num12].type != NPCID.EaterofWorldsHead && Main.npc[num12].type != NPCID.EaterofWorldsBody && Main.npc[num12].type != NPCID.EaterofWorldsTail || Math.Abs(base.Center.X - Main.npc[num12].Center.X) + Math.Abs(base.Center.Y - Main.npc[num12].Center.Y) >= 4000f)
					{
						num12++;
					}
					else
					{
						flag1 = true;
						break;
					}
				}
			}
			if (flag1)
			{
				Player player = this;
				player.respawnTimer = player.respawnTimer + 600;
			}
			if (Main.expertMode)
			{
				this.respawnTimer = (int)((double)this.respawnTimer * 1.5);
			}
			this.immuneAlpha = 0;
			this.palladiumRegen = false;
			this.iceBarrier = false;
			this.crystalLeaf = false;
			if (Main.netMode == 2)
			{
				NetMessage.SendData((int)PacketTypes.ChatText, -1, -1, string.Concat(this.name, deathText), 255, 225f, 25f, 25f, 0, 0, 0);
			}
			else if (Main.netMode == 0)
			{
				Main.NewText(string.Concat(this.name, deathText), 225, 25, 25, false);
			}
			if (Main.netMode == 1 && this.whoAmI == Main.myPlayer)
			{
				int num13 = 0;
				if (pvp)
				{
					num13 = 1;
				}
				NetMessage.SendData((int)PacketTypes.PlayerKillMe, -1, -1, deathText, this.whoAmI, (float)hitDirection, (float)((int)dmg), (float)num13, 0, 0, 0);
			}
			if (this.whoAmI == Main.myPlayer && this.difficulty == 0)
			{
				if (pvp)
				{
					this.lostCoins = 0;
					this.lostCoinString = Main.ValueToCoins(this.lostCoins);
				}
				else
				{
					this.DropCoins();
				}
			}
			this.DropTombstone(num, deathText, hitDirection);
			if (this.whoAmI == Main.myPlayer)
			{
				try
				{
					WorldGen.saveToonWhilePlaying();
				}
				catch (Exception ex)
				{
#if DEBUG
					Console.WriteLine(ex);
					System.Diagnostics.Debugger.Break();

#endif
				}
			}
		}

		public void KillMeForGood()
		{
			if (FileUtilities.Exists(Main.playerPathName))
			{
				FileUtilities.Delete(Main.playerPathName);
			}
			if (FileUtilities.Exists(string.Concat(Main.playerPathName, ".bak")))
			{
				FileUtilities.Delete(string.Concat(Main.playerPathName, ".bak"));
			}
			Main.ActivePlayerFileData = new PlayerFileData();
		}

		public static PlayerFileData LoadPlayer(string playerPath)
		{
			PlayerFileData playerFileDatum;
			PlayerFileData playerFileDatum1 = new PlayerFileData(playerPath);
			if (Main.rand == null)
			{
				Main.rand = new Random((int)DateTime.Now.Ticks);
			}
			Player player = new Player();
			try
			{
				RijndaelManaged rijndaelManaged = new RijndaelManaged()
				{
					Padding = PaddingMode.None
				};
				using (MemoryStream memoryStream = new MemoryStream(FileUtilities.ReadAllBytes(playerPath)))
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateDecryptor(Player.ENCRYPTION_KEY, Player.ENCRYPTION_KEY), CryptoStreamMode.Read))
					{
						using (BinaryReader binaryReader = new BinaryReader(cryptoStream))
						{
							int num = binaryReader.ReadInt32();
							if (num < 135)
							{
								playerFileDatum1.Metadata = FileMetadata.FromCurrentSettings(FileType.Player);
							}
							else
							{
								playerFileDatum1.Metadata = FileMetadata.Read(binaryReader, FileType.Player);
							}
							if (num <= Main.curRelease)
							{
								player.name = binaryReader.ReadString();
								if (num >= 10)
								{
									if (num >= 17)
									{
										player.difficulty = binaryReader.ReadByte();
									}
									else if (binaryReader.ReadBoolean())
									{
										player.difficulty = 2;
									}
								}
								if (num < 138)
								{
									playerFileDatum1.SetPlayTime(TimeSpan.Zero);
								}
								else
								{
									playerFileDatum1.SetPlayTime(new TimeSpan(binaryReader.ReadInt64()));
								}
								player.hair = binaryReader.ReadInt32();
								if (num >= 82)
								{
									player.hairDye = binaryReader.ReadByte();
								}
								if (num >= 124)
								{
									BitsByte bitsByte = binaryReader.ReadByte();
									for (int i = 0; i < 8; i++)
									{
										player.hideVisual[i] = bitsByte[i];
									}
									bitsByte = binaryReader.ReadByte();
									for (int j = 0; j < 2; j++)
									{
										player.hideVisual[j + 8] = bitsByte[j];
									}
								}
								else if (num >= 83)
								{
									BitsByte bitsByte1 = binaryReader.ReadByte();
									for (int k = 0; k < 8; k++)
									{
										player.hideVisual[k] = bitsByte1[k];
									}
								}
								if (num >= 119)
								{
									player.hideMisc = binaryReader.ReadByte();
								}
								if (num <= 17)
								{
									if (player.hair == 5 || player.hair == 6 || player.hair == 9 || player.hair == 11)
									{
										player.Male = false;
									}
									else
									{
										player.Male = true;
									}
								}
								else if (num >= 107)
								{
									player.skinVariant = binaryReader.ReadByte();
								}
								else
								{
									player.Male = binaryReader.ReadBoolean();
								}
								player.statLife = binaryReader.ReadInt32();
								player.statLifeMax = binaryReader.ReadInt32();
								if (player.statLifeMax > 500)
								{
									player.statLifeMax = 500;
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
								if (num >= 125)
								{
									player.extraAccessory = binaryReader.ReadBoolean();
								}
								if (num >= 128)
								{
									player.taxMoney = binaryReader.ReadInt32();
								}
								player.hairColor = binaryReader.ReadRGB();
								player.skinColor = binaryReader.ReadRGB();
								player.eyeColor = binaryReader.ReadRGB();
								player.shirtColor = binaryReader.ReadRGB();
								player.underShirtColor = binaryReader.ReadRGB();
								player.pantsColor = binaryReader.ReadRGB();
								player.shoeColor = binaryReader.ReadRGB();
								Main.player[Main.myPlayer].shirtColor = player.shirtColor;
								Main.player[Main.myPlayer].pantsColor = player.pantsColor;
								Main.player[Main.myPlayer].hairColor = player.hairColor;
								if (num < 38)
								{
									for (int l = 0; l < 8; l++)
									{
										player.armor[l].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
										if (num >= 36)
										{
											player.armor[l].Prefix((int)binaryReader.ReadByte());
										}
									}
									if (num >= 6)
									{
										for (int m = 8; m < 11; m++)
										{
											player.armor[m].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
											if (num >= 36)
											{
												player.armor[m].Prefix((int)binaryReader.ReadByte());
											}
										}
									}
									for (int n = 0; n < 44; n++)
									{
										player.inventory[n].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
										player.inventory[n].stack = binaryReader.ReadInt32();
										if (num >= 36)
										{
											player.inventory[n].Prefix((int)binaryReader.ReadByte());
										}
									}
									if (num >= 15)
									{
										for (int o = 44; o < 48; o++)
										{
											player.inventory[o].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
											player.inventory[o].stack = binaryReader.ReadInt32();
											if (num >= 36)
											{
												player.inventory[o].Prefix((int)binaryReader.ReadByte());
											}
										}
									}
									for (int p = 0; p < 20; p++)
									{
										player.bank.item[p].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
										player.bank.item[p].stack = binaryReader.ReadInt32();
										if (num >= 36)
										{
											player.bank.item[p].Prefix((int)binaryReader.ReadByte());
										}
									}
									if (num >= 20)
									{
										for (int q = 0; q < 20; q++)
										{
											player.bank2.item[q].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
											player.bank2.item[q].stack = binaryReader.ReadInt32();
											if (num >= 36)
											{
												player.bank2.item[q].Prefix((int)binaryReader.ReadByte());
											}
										}
									}
								}
								else
								{
									if (num >= 124)
									{
										int num1 = 20;
										for (int r = 0; r < num1; r++)
										{
											player.armor[r].netDefaults(binaryReader.ReadInt32());
											player.armor[r].Prefix((int)binaryReader.ReadByte());
										}
									}
									else
									{
										int num2 = 11;
										if (num >= 81)
										{
											num2 = 16;
										}
										for (int s = 0; s < num2; s++)
										{
											int num3 = s;
											if (num3 >= 8)
											{
												num3 = num3 + 2;
											}
											player.armor[num3].netDefaults(binaryReader.ReadInt32());
											player.armor[num3].Prefix((int)binaryReader.ReadByte());
										}
									}
									if (num >= 47)
									{
										int num4 = 3;
										if (num >= 81)
										{
											num4 = 8;
										}
										if (num >= 124)
										{
											num4 = 10;
										}
										for (int t = 0; t < num4; t++)
										{
											int num5 = t;
											player.dye[num5].netDefaults(binaryReader.ReadInt32());
											player.dye[num5].Prefix((int)binaryReader.ReadByte());
										}
									}
									if (num < 58)
									{
										for (int u = 0; u < 48; u++)
										{
											int num6 = binaryReader.ReadInt32();
											if (num6 < Main.maxItemTypes)
											{
												player.inventory[u].netDefaults(num6);
												player.inventory[u].stack = binaryReader.ReadInt32();
												player.inventory[u].Prefix((int)binaryReader.ReadByte());
											}
											else
											{
												player.inventory[u].netDefaults(0);
											}
										}
									}
									else
									{
										for (int v = 0; v < 58; v++)
										{
											int num7 = binaryReader.ReadInt32();
											if (num7 < Main.maxItemTypes)
											{
												player.inventory[v].netDefaults(num7);
												player.inventory[v].stack = binaryReader.ReadInt32();
												player.inventory[v].Prefix((int)binaryReader.ReadByte());
												if (num >= 114)
												{
													player.inventory[v].favorited = binaryReader.ReadBoolean();
												}
											}
											else
											{
												player.inventory[v].netDefaults(0);
											}
										}
									}
									if (num >= 117)
									{
										if (num >= 136)
										{
											for (int w = 0; w < 5; w++)
											{
												int num8 = binaryReader.ReadInt32();
												if (num8 < Main.maxItemTypes)
												{
													player.miscEquips[w].netDefaults(num8);
													player.miscEquips[w].Prefix((int)binaryReader.ReadByte());
												}
												else
												{
													player.miscEquips[w].netDefaults(0);
												}
												num8 = binaryReader.ReadInt32();
												if (num8 < Main.maxItemTypes)
												{
													player.miscDyes[w].netDefaults(num8);
													player.miscDyes[w].Prefix((int)binaryReader.ReadByte());
												}
												else
												{
													player.miscDyes[w].netDefaults(0);
												}
											}
										}
										else
										{
											for (int x = 0; x < 5; x++)
											{
												if (x != 1)
												{
													int num9 = binaryReader.ReadInt32();
													if (num9 < Main.maxItemTypes)
													{
														player.miscEquips[x].netDefaults(num9);
														player.miscEquips[x].Prefix((int)binaryReader.ReadByte());
													}
													else
													{
														player.miscEquips[x].netDefaults(0);
													}
													num9 = binaryReader.ReadInt32();
													if (num9 < Main.maxItemTypes)
													{
														player.miscDyes[x].netDefaults(num9);
														player.miscDyes[x].Prefix((int)binaryReader.ReadByte());
													}
													else
													{
														player.miscDyes[x].netDefaults(0);
													}
												}
											}
										}
									}
									if (num < 58)
									{
										for (int y = 0; y < 20; y++)
										{
											player.bank.item[y].netDefaults(binaryReader.ReadInt32());
											player.bank.item[y].stack = binaryReader.ReadInt32();
											player.bank.item[y].Prefix((int)binaryReader.ReadByte());
										}
										for (int a = 0; a < 20; a++)
										{
											player.bank2.item[a].netDefaults(binaryReader.ReadInt32());
											player.bank2.item[a].stack = binaryReader.ReadInt32();
											player.bank2.item[a].Prefix((int)binaryReader.ReadByte());
										}
									}
									else
									{
										for (int b = 0; b < 40; b++)
										{
											player.bank.item[b].netDefaults(binaryReader.ReadInt32());
											player.bank.item[b].stack = binaryReader.ReadInt32();
											player.bank.item[b].Prefix((int)binaryReader.ReadByte());
										}
										for (int c = 0; c < 40; c++)
										{
											player.bank2.item[c].netDefaults(binaryReader.ReadInt32());
											player.bank2.item[c].stack = binaryReader.ReadInt32();
											player.bank2.item[c].Prefix((int)binaryReader.ReadByte());
										}
									}
								}
								if (num < 58)
								{
									for (int d = 40; d < 48; d++)
									{
										player.inventory[d + 10] = player.inventory[d].Clone();
										player.inventory[d].SetDefaults(0, false);
									}
								}
								if (num >= 11)
								{
									int num10 = 22;
									if (num < 74)
									{
										num10 = 10;
									}
									for (int e = 0; e < num10; e++)
									{
										player.buffType[e] = binaryReader.ReadInt32();
										player.buffTime[e] = binaryReader.ReadInt32();
										if (player.buffType[e] == 0)
										{
											e--;
											num10--;
										}
									}
								}
								for (int f = 0; f < 200; f++)
								{
									int num11 = binaryReader.ReadInt32();
									if (num11 == -1)
									{
										break;
									}
									player.spX[f] = num11;
									player.spY[f] = binaryReader.ReadInt32();
									player.spI[f] = binaryReader.ReadInt32();
									player.spN[f] = binaryReader.ReadString();
								}
								if (num >= 16)
								{
									player.hbLocked = binaryReader.ReadBoolean();
								}
								if (num >= 115)
								{
									int num12 = 13;
									for (int g = 0; g < num12; g++)
									{
										player.hideInfo[g] = binaryReader.ReadBoolean();
									}
								}
								if (num >= 98)
								{
									player.anglerQuestsFinished = binaryReader.ReadInt32();
								}
								player.skinVariant = (int)MathHelper.Clamp((float)player.skinVariant, 0f, 7f);
								for (int h = 3; h < 8 + player.extraAccessorySlots; h++)
								{
									int num13 = player.armor[h].type;
									if (num13 == 908)
									{
										Player player1 = player;
										player1.lavaMax = player1.lavaMax + 420;
									}
									if (num13 == 906)
									{
										Player player2 = player;
										player2.lavaMax = player2.lavaMax + 420;
									}
									if (player.wingsLogic == 0 && player.armor[h].wingSlot >= 0)
									{
										player.wingsLogic = player.armor[h].wingSlot;
									}
									if (num13 == 158 || num13 == 396 || num13 == 1250 || num13 == 1251 || num13 == 1252)
									{
										player.noFallDmg = true;
									}
									player.lavaTime = player.lavaMax;
								}
							}
							else
							{
								player.loadStatus = 1;
								player.name = binaryReader.ReadString();
								playerFileDatum1.Player = player;
								playerFileDatum = playerFileDatum1;
								return playerFileDatum;
							}
						}
					}
				}
				player.PlayerFrame();
				player.loadStatus = 0;
				playerFileDatum1.Player = player;
				playerFileDatum = playerFileDatum1;
			}
			catch
			{
				Player player3 = new Player()
				{
					loadStatus = 2
				};
				if (player.name == "")
				{
					char[] directorySeparatorChar = new char[] { Path.DirectorySeparatorChar };
					string[] strArrays = playerPath.Split(directorySeparatorChar);
					string str = strArrays[(int)strArrays.Length - 1];
					char[] chrArray = new char[] { '.' };
					player.name = str.Split(chrArray)[0];
				}
				else
				{
					player3.name = player.name;
				}
				playerFileDatum1.Player = player3;
				return playerFileDatum1;
			}
			return playerFileDatum;
		}

		public void ManaEffect(int manaAmount)
		{
			CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), CombatText.HealMana, string.Concat(manaAmount), false, false);
			if (Main.netMode == 1 && this.whoAmI == Main.myPlayer)
			{
				NetMessage.SendData((int)PacketTypes.EffectMana, -1, -1, "", this.whoAmI, (float)manaAmount, 0f, 0f, 0, 0, 0);
			}
		}

		public void ManageSpecialBiomeVisuals(string biomeName, bool inZone, Vector2 activationSource = new Vector2())
		{
		}

		public void MinionTargetAim()
		{
			Vector2 mouseWorld = Main.MouseWorld;
			float y = mouseWorld.Y;
			int x = (int)mouseWorld.X / 16;
			int num = (int)y / 16;
			int num1 = 0;
			if ((!Main.tile[x, num].nactive() || !Main.tileSolid[Main.tile[x, num].type] ? false : !Main.tileSolidTop[Main.tile[x, num].type]))
			{
				int num2 = 0;
				int num3 = 0;
				while (num3 > -20 && num + num3 > 1)
				{
					int num4 = num + num3;
					if ((!Main.tile[x, num4].nactive() || !Main.tileSolid[Main.tile[x, num4].type] ? true : Main.tileSolidTop[Main.tile[x, num4].type]))
					{
						num2 = num3;
						break;
					}
					else
					{
						num2 = num3;
						num3--;
					}
				}
				int num5 = 0;
				int num6 = 0;
				while (num6 < 20 && num + num6 < Main.maxTilesY)
				{
					int num7 = num + num6;
					if ((!Main.tile[x, num7].nactive() || !Main.tileSolid[Main.tile[x, num7].type] ? true : Main.tileSolidTop[Main.tile[x, num7].type]))
					{
						num5 = num6;
						break;
					}
					else
					{
						num5 = num6;
						num6++;
					}
				}
				num1 = (num5 <= -num2 ? num5 + 3 : num2 - 2);
			}
			int num8 = num + num1;
			bool flag = false;
			for (int i = num8; i < num8 + 5; i++)
			{
				if (WorldGen.SolidTileAllowBottomSlope(x, i))
				{
					flag = true;
				}
			}
			while (!flag)
			{
				num8++;
				for (int j = num8; j < num8 + 5; j++)
				{
					if (WorldGen.SolidTileAllowBottomSlope(x, j))
					{
						flag = true;
					}
				}
			}
		}

		public void MoonLeechRope()
		{
			int num = -1;
			int num1 = 0;
			while (num1 < 1000)
			{
				if (!Main.projectile[num1].active || Main.projectile[num1].type != ProjectileID.MoonLeech || Main.projectile[num1].ai[1] != (float)this.whoAmI)
				{
					num1++;
				}
				else
				{
					num = num1;
					break;
				}
			}
			if (num == -1)
			{
				return;
			}
			if (Main.projectile[num].ai[0] < 0f)
			{
				return;
			}
			Projectile projectile = Main.projectile[num];
			Vector2 vector2 = new Vector2(0f, 216f);
			Vector2 center = (Main.npc[(int)Math.Abs(projectile.ai[0]) - 1].Center - base.Center) + vector2;
			if (center.Length() > 200f)
			{
				Vector2 vector21 = Vector2.Normalize(center);
				Player player = this;
				player.position = player.position + (vector21 * (center.Length() - 200f));
			}
		}

		public void NebulaLevelup(int type)
		{
			if (this.whoAmI == Main.myPlayer)
			{
				int num = 480;
				for (int i = 0; i < 22; i++)
				{
					if (this.buffType[i] >= type && this.buffType[i] < type + 3)
					{
						this.DelBuff(i);
					}
				}
				int num1 = type;
				if (num1 == 173)
				{
					this.nebulaLevelLife = (int)MathHelper.Clamp((float)(this.nebulaLevelLife + 1), 0f, 3f);
					this.AddBuff(type + this.nebulaLevelLife - 1, num, true);
					return;
				}
				if (num1 == 176)
				{
					this.nebulaLevelMana = (int)MathHelper.Clamp((float)(this.nebulaLevelMana + 1), 0f, 3f);
					this.AddBuff(type + this.nebulaLevelMana - 1, num, true);
					return;
				}
				if (num1 != 179)
				{
					return;
				}
				this.nebulaLevelDamage = (int)MathHelper.Clamp((float)(this.nebulaLevelDamage + 1), 0f, 3f);
				this.AddBuff(type + this.nebulaLevelDamage - 1, num, true);
			}
		}

		public void NinjaDodge()
		{
			this.immune = true;
			this.immuneTime = 80;
			if (this.longInvince)
			{
				Player player = this;
				player.immuneTime = player.immuneTime + 40;
			}
			if (this.whoAmI == Main.myPlayer)
			{
				NetMessage.SendData((int)PacketTypes.PlayerDodge, -1, -1, "", this.whoAmI, 1f, 0f, 0f, 0, 0, 0);
			}
		}

		public void OnHit(float x, float y, Entity victim)
		{
			if (Main.myPlayer != this.whoAmI)
			{
				return;
			}
			if (this.onHitDodge && this.shadowDodgeTimer == 0 && Main.rand.Next(4) == 0)
			{
				if (!this.shadowDodge)
				{
					this.shadowDodgeTimer = 1800;
				}
				this.AddBuff(BuffID.ShadowDodge, 1800, true);
			}
			if (this.onHitRegen)
			{
				this.AddBuff(BuffID.RapidHealing, 300, true);
			}
			if (this.stardustMinion && victim is NPC)
			{
				for (int i = 0; i < 1000; i++)
				{
					Projectile projectile = Main.projectile[i];
					if (projectile.active && projectile.owner == this.whoAmI && projectile.type == ProjectileID.StardustCellMinion && projectile.localAI[1] <= 0f && Main.rand.Next(2) == 0)
					{
						Vector2 vector2 = new Vector2(x, y) - projectile.Center;
						if (vector2.Length() > 0f)
						{
							vector2.Normalize();
						}
						vector2 = vector2 * 20f;
						Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector2.X, vector2.Y, 614, projectile.damage / 3, 0f, projectile.owner, 0f, (float)victim.whoAmI);
						projectile.localAI[1] = (float)(30 + Main.rand.Next(4) * 10);
					}
				}
			}
			if (this.onHitPetal && this.petalTimer == 0)
			{
				this.petalTimer = 20;
				int num = 1;
				if (x < this.position.X + (float)(this.width / 2))
				{
					num = -1;
				}
				num = this.direction;
				float single = Main.screenPosition.X;
				if (num < 0)
				{
					single = single + (float)Main.screenWidth;
				}
				float single1 = Main.screenPosition.Y;
				single1 = single1 + (float)Main.rand.Next(Main.screenHeight);
				Vector2 vector21 = new Vector2(single, single1);
				float single2 = x - vector21.X;
				float single3 = y - vector21.Y;
				single2 = single2 + (float)Main.rand.Next(-50, 51) * 0.1f;
				single3 = single3 + (float)Main.rand.Next(-50, 51) * 0.1f;
				int num1 = 24;
				float single4 = (float)Math.Sqrt((double)(single2 * single2 + single3 * single3));
				single4 = (float)num1 / single4;
				single2 = single2 * single4;
				single3 = single3 * single4;
				Projectile.NewProjectile(single, single1, single2, single3, ProjectileID.FlowerPetal, 36, 0f, this.whoAmI, 0f, 0f);
			}
			if (this.crystalLeaf && this.petalTimer == 0)
			{
				int num2 = this.inventory[this.selectedItem].type;
				for (int j = 0; j < 1000; j++)
				{
					if (Main.projectile[j].owner == this.whoAmI && Main.projectile[j].type == ProjectileID.CrystalLeaf)
					{
						this.petalTimer = 50;
						float single5 = 12f;
						Vector2 vector22 = new Vector2(Main.projectile[j].position.X + (float)this.width * 0.5f, Main.projectile[j].position.Y + (float)this.height * 0.5f);
						float single6 = x - vector22.X;
						float single7 = y - vector22.Y;
						float single8 = (float)Math.Sqrt((double)(single6 * single6 + single7 * single7));
						single8 = single5 / single8;
						single6 = single6 * single8;
						single7 = single7 * single8;
						Projectile.NewProjectile(Main.projectile[j].Center.X - 4f, Main.projectile[j].Center.Y, single6, single7, 227, Player.crystalLeafDamage, (float)Player.crystalLeafKB, this.whoAmI, 0f, 0f);
						return;
					}
				}
			}
		}

		public void OpenBossBag(int type)
		{
			if (type == 3318)
			{
				if (Main.rand.Next(2) == 0)
				{
					this.QuickSpawnItem(2430, 1);
				}
				if (Main.rand.Next(7) == 0)
				{
					this.QuickSpawnItem(2493, 1);
				}
				int num = Main.rand.Next(256, 259);
				int num1 = Main.rand.Next(256, 259);
				while (num1 == num)
				{
					num1 = Main.rand.Next(256, 259);
				}
				this.QuickSpawnItem(num, 1);
				this.QuickSpawnItem(num1, 1);
				if (Main.rand.Next(2) != 0)
				{
					this.QuickSpawnItem(2585, 1);
				}
				else
				{
					this.QuickSpawnItem(2610, 1);
				}
				this.QuickSpawnItem(998, 1);
				this.QuickSpawnItem(3090, 1);
			}
			else if (type == 3319)
			{
				if (Main.rand.Next(7) == 0)
				{
					this.QuickSpawnItem(2112, 1);
				}
				if (Main.rand.Next(30) == 0)
				{
					this.QuickSpawnItem(1299, 1);
				}
				if (!WorldGen.crimson)
				{
					int num2 = Main.rand.Next(20) + 10;
					num2 = num2 + Main.rand.Next(20) + 10;
					num2 = num2 + Main.rand.Next(20) + 10;
					this.QuickSpawnItem(56, num2);
					num2 = Main.rand.Next(3) + 1;
					this.QuickSpawnItem(59, num2);
					num2 = Main.rand.Next(30) + 20;
					this.QuickSpawnItem(47, num2);
				}
				else
				{
					int num3 = Main.rand.Next(20) + 10;
					num3 = num3 + Main.rand.Next(20) + 10;
					num3 = num3 + Main.rand.Next(20) + 10;
					this.QuickSpawnItem(880, num3);
					num3 = Main.rand.Next(3) + 1;
					this.QuickSpawnItem(2171, num3);
				}
				this.QuickSpawnItem(3097, 1);
			}
			else if (type == 3320)
			{
				int num4 = Main.rand.Next(15, 30);
				num4 = num4 + Main.rand.Next(15, 31);
				this.QuickSpawnItem(56, num4);
				this.QuickSpawnItem(86, Main.rand.Next(10, 20));
				if (Main.rand.Next(20) == 0)
				{
					this.QuickSpawnItem(994, 1);
				}
				if (Main.rand.Next(7) == 0)
				{
					this.QuickSpawnItem(2111, 1);
				}
				this.QuickSpawnItem(3224, 1);
			}
			else if (type == 3321)
			{
				int num5 = Main.rand.Next(20, 46);
				num5 = num5 + Main.rand.Next(20, 46);
				this.QuickSpawnItem(880, num5);
				this.QuickSpawnItem(1329, Main.rand.Next(10, 20));
				if (Main.rand.Next(7) == 0)
				{
					this.QuickSpawnItem(2104, 1);
				}
				if (Main.rand.Next(20) == 0)
				{
					this.QuickSpawnItem(3060, 1);
				}
				this.QuickSpawnItem(3223, 1);
			}
			else if (type == 3322)
			{
				if (Main.rand.Next(7) == 0)
				{
					this.QuickSpawnItem(2108, 1);
				}
				int num6 = Main.rand.Next(3);
				if (num6 == 0)
				{
					num6 = 1121;
				}
				else if (num6 == 1)
				{
					num6 = 1123;
				}
				else if (num6 == 2)
				{
					num6 = 2888;
				}
				this.QuickSpawnItem(num6, 1);
				this.QuickSpawnItem(3333, 1);
				if (Main.rand.Next(3) == 0)
				{
					this.QuickSpawnItem(1132, 1);
				}
				if (Main.rand.Next(9) == 0)
				{
					this.QuickSpawnItem(1170, 1);
				}
				if (Main.rand.Next(9) == 0)
				{
					this.QuickSpawnItem(2502, 1);
				}
				this.QuickSpawnItem(1129, 1);
				this.QuickSpawnItem(Main.rand.Next(842, 845), 1);
				this.QuickSpawnItem(1130, Main.rand.Next(10, 30));
				this.QuickSpawnItem(2431, Main.rand.Next(17, 30));
			}
			else if (type == 3323)
			{
				this.QuickSpawnItem(3245, 1);
				int num7 = Main.rand.Next(3);
				if (num7 == 0)
				{
					this.QuickSpawnItem(1281, 1);
				}
				else if (num7 != 1)
				{
					this.QuickSpawnItem(1313, 1);
				}
				else
				{
					this.QuickSpawnItem(1273, 1);
				}
			}
			else if (type == 3324)
			{
				if (Main.rand.Next(7) == 0)
				{
					this.QuickSpawnItem(2105, 1);
				}
				this.QuickSpawnItem(367, 1);
				if (!this.extraAccessory)
				{
					this.QuickSpawnItem(3335, 1);
				}
				int num8 = Main.rand.Next(4);
				num8 = (num8 != 3 ? 489 + num8 : 2998);
				this.QuickSpawnItem(num8, 1);
				int num9 = Main.rand.Next(3);
				if (num9 == 0)
				{
					this.QuickSpawnItem(514, 1);
				}
				else if (num9 == 1)
				{
					this.QuickSpawnItem(426, 1);
				}
				else if (num9 == 2)
				{
					this.QuickSpawnItem(434, 1);
				}
			}
			else if (type == 3325)
			{
				this.TryGettingDevArmor();
				if (Main.rand.Next(7) == 0)
				{
					this.QuickSpawnItem(2113, 1);
				}
				this.QuickSpawnItem(548, Main.rand.Next(25, 41));
				this.QuickSpawnItem(1225, Main.rand.Next(20, 36));
				this.QuickSpawnItem(3355, 1);
			}
			else if (type == 3326)
			{
				this.TryGettingDevArmor();
				if (Main.rand.Next(7) == 0)
				{
					this.QuickSpawnItem(2106, 1);
				}
				this.QuickSpawnItem(549, Main.rand.Next(25, 41));
				this.QuickSpawnItem(1225, Main.rand.Next(20, 36));
				this.QuickSpawnItem(3354, 1);
			}
			else if (type == 3327)
			{
				this.TryGettingDevArmor();
				if (Main.rand.Next(7) == 0)
				{
					this.QuickSpawnItem(2107, 1);
				}
				this.QuickSpawnItem(547, Main.rand.Next(25, 41));
				this.QuickSpawnItem(1225, Main.rand.Next(20, 36));
				this.QuickSpawnItem(3356, 1);
			}
			else if (type == 3328)
			{
				this.TryGettingDevArmor();
				if (Main.rand.Next(7) == 0)
				{
					this.QuickSpawnItem(2109, 1);
				}
				this.QuickSpawnItem(1141, 1);
				this.QuickSpawnItem(3336, 1);
				if (Main.rand.Next(15) == 0)
				{
					this.QuickSpawnItem(1182, 1);
				}
				if (Main.rand.Next(20) == 0)
				{
					this.QuickSpawnItem(1305, 1);
				}
				if (Main.rand.Next(2) == 0)
				{
					this.QuickSpawnItem(1157, 1);
				}
				if (Main.rand.Next(10) == 0)
				{
					this.QuickSpawnItem(3021, 1);
				}
				int num10 = Main.rand.Next(6);
				if (num10 == 0)
				{
					this.QuickSpawnItem(758, 1);
					this.QuickSpawnItem(771, Main.rand.Next(50, 150));
				}
				else if (num10 == 1)
				{
					this.QuickSpawnItem(1255, 1);
				}
				else if (num10 == 2)
				{
					this.QuickSpawnItem(788, 1);
				}
				else if (num10 == 3)
				{
					this.QuickSpawnItem(1178, 1);
				}
				else if (num10 == 4)
				{
					this.QuickSpawnItem(1259, 1);
				}
				else if (num10 == 5)
				{
					this.QuickSpawnItem(1155, 1);
				}
			}
			else if (type == 3329)
			{
				this.TryGettingDevArmor();
				this.QuickSpawnItem(3337, 1);
				if (Main.rand.Next(7) == 0)
				{
					this.QuickSpawnItem(2110, 1);
				}
				int num11 = Main.rand.Next(8);
				if (num11 == 0)
				{
					this.QuickSpawnItem(1258, 1);
					this.QuickSpawnItem(1261, Main.rand.Next(60, 100));
				}
				else if (num11 == 1)
				{
					this.QuickSpawnItem(1122, 1);
				}
				else if (num11 == 2)
				{
					this.QuickSpawnItem(899, 1);
				}
				else if (num11 == 3)
				{
					this.QuickSpawnItem(1248, 1);
				}
				else if (num11 == 4)
				{
					this.QuickSpawnItem(1294, 1);
				}
				else if (num11 == 5)
				{
					this.QuickSpawnItem(1295, 1);
				}
				else if (num11 == 6)
				{
					this.QuickSpawnItem(1296, 1);
				}
				else if (num11 == 7)
				{
					this.QuickSpawnItem(1297, 1);
				}
				this.QuickSpawnItem(2218, Main.rand.Next(18, 24));
			}
			else if (type == 3330)
			{
				this.TryGettingDevArmor();
				this.QuickSpawnItem(3367, 1);
				if (Main.rand.Next(7) == 0)
				{
					this.QuickSpawnItem(2588, 1);
				}
				if (Main.rand.Next(10) == 0)
				{
					this.QuickSpawnItem(2609, 1);
				}
				int num12 = Main.rand.Next(5);
				if (num12 == 0)
				{
					this.QuickSpawnItem(2611, 1);
				}
				else if (num12 == 1)
				{
					this.QuickSpawnItem(2624, 1);
				}
				else if (num12 == 2)
				{
					this.QuickSpawnItem(2622, 1);
				}
				else if (num12 == 3)
				{
					this.QuickSpawnItem(2621, 1);
				}
				else if (num12 == 4)
				{
					this.QuickSpawnItem(2623, 1);
				}
			}
			else if (type == 3331)
			{
				this.TryGettingDevArmor();
				if (Main.rand.Next(7) == 0)
				{
					this.QuickSpawnItem(3372, 1);
				}
			}
			else if (type == 3332)
			{
				this.TryGettingDevArmor();
				if (Main.rand.Next(7) == 0)
				{
					this.QuickSpawnItem(3373, 1);
				}
				if (!this.HasItem(3384))
				{
					this.QuickSpawnItem(3384, 1);
				}
				this.QuickSpawnItem(3460, Main.rand.Next(90, 111));
				this.QuickSpawnItem(1131, 1);
				this.QuickSpawnItem(3577, 1);
				Random random = Main.rand;
				int[] numArray = new int[] { 3063, 3389, 3065, 1553, 3546, 3541, 3570, 3571, 3569 };
				this.QuickSpawnItem(Terraria.Utils.SelectRandom<int>(random, numArray), 1);
			}
			int num13 = -1;
			if (type == 3318)
			{
				num13 = 50;
			}
			if (type == 3319)
			{
				num13 = 4;
			}
			if (type == 3320)
			{
				num13 = 13;
			}
			if (type == 3321)
			{
				num13 = 266;
			}
			if (type == 3322)
			{
				num13 = 222;
			}
			if (type == 3323)
			{
				num13 = 35;
			}
			if (type == 3324)
			{
				num13 = 113;
			}
			if (type == 3325)
			{
				num13 = 134;
			}
			if (type == 3326)
			{
				num13 = 125;
			}
			if (type == 3327)
			{
				num13 = 127;
			}
			if (type == 3328)
			{
				num13 = 262;
			}
			if (type == 3329)
			{
				num13 = 245;
			}
			if (type == 3330)
			{
				num13 = 370;
			}
			if (type == 3331)
			{
				num13 = 439;
			}
			if (type == 3332)
			{
				num13 = 398;
			}
			if (num13 > 0)
			{
				NPC nPC = new NPC();
				nPC.SetDefaults(num13, -1f);
				float single = nPC.@value;
				single = single * (1f + (float)Main.rand.Next(-20, 21) * 0.01f);
				if (Main.rand.Next(5) == 0)
				{
					single = single * (1f + (float)Main.rand.Next(5, 11) * 0.01f);
				}
				if (Main.rand.Next(10) == 0)
				{
					single = single * (1f + (float)Main.rand.Next(10, 21) * 0.01f);
				}
				if (Main.rand.Next(15) == 0)
				{
					single = single * (1f + (float)Main.rand.Next(15, 31) * 0.01f);
				}
				if (Main.rand.Next(20) == 0)
				{
					single = single * (1f + (float)Main.rand.Next(20, 41) * 0.01f);
				}
				while ((int)single > 0)
				{
					if (single > 1000000f)
					{
						int num14 = (int)(single / 1000000f);
						single = single - (float)(1000000 * num14);
						this.QuickSpawnItem(74, num14);
					}
					else if (single > 10000f)
					{
						int num15 = (int)(single / 10000f);
						single = single - (float)(10000 * num15);
						this.QuickSpawnItem(73, num15);
					}
					else if (single <= 100f)
					{
						int num16 = (int)single;
						if (num16 < 1)
						{
							num16 = 1;
						}
						single = single - (float)num16;
						this.QuickSpawnItem(71, num16);
					}
					else
					{
						int num17 = (int)(single / 100f);
						single = single - (float)(100 * num17);
						this.QuickSpawnItem(72, num17);
					}
				}
			}
		}

		public void openCrate(int type)
		{
			int num;
			int num1 = type - 2334;
			if (type >= 3203)
			{
				num1 = type - 3203 + 3;
			}
			if (num1 == 0)
			{
				bool flag = true;
				while (flag)
				{
					if (Main.hardMode && flag && Main.rand.Next(200) == 0)
					{
						int num2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 3064, 1, false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num2, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (flag && Main.rand.Next(40) == 0)
					{
						int num3 = 3200;
						int num4 = 1;
						int num5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num3, num4, false, -1, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num5, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (flag && Main.rand.Next(40) == 0)
					{
						int num6 = 3201;
						int num7 = 1;
						int num8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num6, num7, false, -1, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num8, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (Main.hardMode && flag && Main.rand.Next(25) == 0)
					{
						int num9 = 2424;
						int num10 = 1;
						int num11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num9, num10, false, -1, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num11, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (Main.rand.Next(45) == 0)
					{
						int num12 = Main.rand.Next(5);
						if (num12 == 0)
						{
							num12 = 285;
						}
						else if (num12 == 1)
						{
							num12 = 953;
						}
						else if (num12 == 2)
						{
							num12 = 946;
						}
						else if (num12 == 3)
						{
							num12 = 3068;
						}
						else if (num12 == 4)
						{
							num12 = 3084;
						}
						int num13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num12, 1, false, -1, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num13, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (!Main.hardMode && flag && Main.rand.Next(50) == 0)
					{
						int num14 = 997;
						int num15 = 1;
						int num16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num14, num15, false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num16, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (Main.rand.Next(7) == 0)
					{
						int num17 = Main.rand.Next(3);
						if (num17 != 0)
						{
							num17 = 72;
							num = Main.rand.Next(20, 91);
						}
						else
						{
							num17 = 73;
							num = Main.rand.Next(1, 6);
						}
						int num18 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num17, num, false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num18, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (Main.rand.Next(7) == 0)
					{
						int num19 = Main.rand.Next(8);
						if (num19 == 0)
						{
							num19 = 12;
						}
						else if (num19 == 1)
						{
							num19 = 11;
						}
						else if (num19 == 2)
						{
							num19 = 14;
						}
						else if (num19 == 3)
						{
							num19 = 13;
						}
						else if (num19 == 4)
						{
							num19 = 699;
						}
						else if (num19 == 5)
						{
							num19 = 700;
						}
						else if (num19 == 6)
						{
							num19 = 701;
						}
						else if (num19 == 7)
						{
							num19 = 702;
						}
						if (Main.hardMode && Main.rand.Next(2) == 0)
						{
							num19 = Main.rand.Next(6);
							if (num19 == 0)
							{
								num19 = 364;
							}
							else if (num19 == 1)
							{
								num19 = 365;
							}
							else if (num19 == 2)
							{
								num19 = 366;
							}
							else if (num19 == 3)
							{
								num19 = 1104;
							}
							else if (num19 == 4)
							{
								num19 = 1105;
							}
							else if (num19 == 5)
							{
								num19 = 1106;
							}
						}
						int num20 = Main.rand.Next(8, 21);
						int num21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num19, num20, false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num21, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (Main.rand.Next(8) == 0)
					{
						int num22 = Main.rand.Next(8);
						if (num22 == 0)
						{
							num22 = 20;
						}
						else if (num22 == 1)
						{
							num22 = 22;
						}
						else if (num22 == 2)
						{
							num22 = 21;
						}
						else if (num22 == 3)
						{
							num22 = 19;
						}
						else if (num22 == 4)
						{
							num22 = 703;
						}
						else if (num22 == 5)
						{
							num22 = 704;
						}
						else if (num22 == 6)
						{
							num22 = 705;
						}
						else if (num22 == 7)
						{
							num22 = 706;
						}
						int num23 = Main.rand.Next(2, 8);
						if (Main.hardMode && Main.rand.Next(2) == 0)
						{
							num22 = Main.rand.Next(6);
							if (num22 == 0)
							{
								num22 = 381;
							}
							else if (num22 == 1)
							{
								num22 = 382;
							}
							else if (num22 == 2)
							{
								num22 = 391;
							}
							else if (num22 == 3)
							{
								num22 = 1184;
							}
							else if (num22 == 4)
							{
								num22 = 1191;
							}
							else if (num22 == 5)
							{
								num22 = 1198;
							}
							num23 = num23 - Main.rand.Next(2);
						}
						int num24 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num22, num23, false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num24, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (Main.rand.Next(7) != 0)
					{
						continue;
					}
					int num25 = Main.rand.Next(10);
					if (num25 == 0)
					{
						num25 = 288;
					}
					else if (num25 == 1)
					{
						num25 = 290;
					}
					else if (num25 == 2)
					{
						num25 = 292;
					}
					else if (num25 == 3)
					{
						num25 = 299;
					}
					else if (num25 == 4)
					{
						num25 = 298;
					}
					else if (num25 == 5)
					{
						num25 = 304;
					}
					else if (num25 == 6)
					{
						num25 = 291;
					}
					else if (num25 == 7)
					{
						num25 = 2322;
					}
					else if (num25 == 8)
					{
						num25 = 2323;
					}
					else if (num25 == 9)
					{
						num25 = 2329;
					}
					int num26 = Main.rand.Next(1, 4);
					int num27 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num25, num26, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num27, 1f, 0f, 0f, 0, 0, 0);
					}
					flag = false;
				}
				if (Main.rand.Next(3) == 0)
				{
					int num28 = Main.rand.Next(2);
					if (num28 == 0)
					{
						num28 = 28;
					}
					else if (num28 == 1)
					{
						num28 = 110;
					}
					int num29 = Main.rand.Next(5, 16);
					int num30 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num28, num29, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num30, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.rand.Next(3) == 0)
				{
					int num31 = Main.rand.Next(3);
					num31 = (num31 != 0 ? 2674 : 2675);
					int num32 = Main.rand.Next(1, 5);
					int num33 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num31, num32, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num33, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
			}
			else if (num1 == 1)
			{
				bool flag1 = true;
				while (flag1)
				{
					if (Main.hardMode && flag1 && Main.rand.Next(60) == 0)
					{
						int num34 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 3064, 1, false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num34, 1f, 0f, 0f, 0, 0, 0);
						}
						flag1 = false;
					}
					if (flag1 && Main.rand.Next(25) == 0)
					{
						int num35 = 2501;
						int num36 = 1;
						int num37 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num35, num36, false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num37, 1f, 0f, 0f, 0, 0, 0);
						}
						flag1 = false;
					}
					if (flag1 && Main.rand.Next(20) == 0)
					{
						int num38 = 2587;
						int num39 = 1;
						int num40 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num38, num39, false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num40, 1f, 0f, 0f, 0, 0, 0);
						}
						flag1 = false;
					}
					if (flag1 && Main.rand.Next(15) == 0)
					{
						int num41 = 2608;
						int num42 = 1;
						int num43 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num41, num42, false, -1, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num43, 1f, 0f, 0f, 0, 0, 0);
						}
						flag1 = false;
					}
					if (flag1 && Main.rand.Next(20) == 0)
					{
						int num44 = 3200;
						int num45 = 1;
						int num46 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num44, num45, false, -1, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num46, 1f, 0f, 0f, 0, 0, 0);
						}
						flag1 = false;
					}
					if (flag1 && Main.rand.Next(20) == 0)
					{
						int num47 = 3201;
						int num48 = 1;
						int num49 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num47, num48, false, -1, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num49, 1f, 0f, 0f, 0, 0, 0);
						}
						flag1 = false;
					}
					if (Main.rand.Next(4) == 0)
					{
						int num50 = 73;
						int num51 = Main.rand.Next(5, 11);
						int num52 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num50, num51, false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num52, 1f, 0f, 0f, 0, 0, 0);
						}
						flag1 = false;
					}
					if (Main.rand.Next(4) == 0)
					{
						int num53 = Main.rand.Next(8);
						if (num53 == 0)
						{
							num53 = 20;
						}
						else if (num53 == 1)
						{
							num53 = 22;
						}
						else if (num53 == 2)
						{
							num53 = 21;
						}
						else if (num53 == 3)
						{
							num53 = 19;
						}
						else if (num53 == 4)
						{
							num53 = 703;
						}
						else if (num53 == 5)
						{
							num53 = 704;
						}
						else if (num53 == 6)
						{
							num53 = 705;
						}
						else if (num53 == 7)
						{
							num53 = 706;
						}
						int num54 = Main.rand.Next(6, 15);
						if (Main.hardMode && Main.rand.Next(3) != 0)
						{
							num53 = Main.rand.Next(6);
							if (num53 == 0)
							{
								num53 = 381;
							}
							else if (num53 == 1)
							{
								num53 = 382;
							}
							else if (num53 == 2)
							{
								num53 = 391;
							}
							else if (num53 == 3)
							{
								num53 = 1184;
							}
							else if (num53 == 4)
							{
								num53 = 1191;
							}
							else if (num53 == 5)
							{
								num53 = 1198;
							}
							num54 = num54 - Main.rand.Next(2);
						}
						int num55 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num53, num54, false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num55, 1f, 0f, 0f, 0, 0, 0);
						}
						flag1 = false;
					}
					if (Main.rand.Next(4) != 0)
					{
						continue;
					}
					int num56 = Main.rand.Next(8);
					if (num56 == 0)
					{
						num56 = 288;
					}
					else if (num56 == 1)
					{
						num56 = 296;
					}
					else if (num56 == 2)
					{
						num56 = 304;
					}
					else if (num56 == 3)
					{
						num56 = 305;
					}
					else if (num56 == 4)
					{
						num56 = 2322;
					}
					else if (num56 == 5)
					{
						num56 = 2323;
					}
					else if (num56 == 6)
					{
						num56 = 2324;
					}
					else if (num56 == 7)
					{
						num56 = 2327;
					}
					int num57 = Main.rand.Next(2, 5);
					int num58 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num56, num57, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num58, 1f, 0f, 0f, 0, 0, 0);
					}
					flag1 = false;
				}
				if (Main.rand.Next(2) == 0)
				{
					int num59 = Main.rand.Next(188, 190);
					int num60 = Main.rand.Next(5, 16);
					int num61 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num59, num60, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num61, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					int num62 = Main.rand.Next(3);
					num62 = (num62 != 0 ? 2675 : 2676);
					int num63 = Main.rand.Next(2, 5);
					int num64 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num62, num63, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num64, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
			}
			else if (num1 != 2)
			{
				int num65 = 6;
				bool flag2 = true;
				while (flag2)
				{
					if (num1 == 3 && flag2 && Main.rand.Next(num65) == 0)
					{
						int num66 = Main.rand.Next(5);
						if (num66 == 0)
						{
							num66 = 162;
						}
						else if (num66 == 1)
						{
							num66 = 111;
						}
						else if (num66 != 2)
						{
							num66 = (num66 != 3 ? 64 : 115);
						}
						else
						{
							num66 = 96;
						}
						int num67 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num66, 1, false, -1, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num67, 1f, 0f, 0f, 0, 0, 0);
						}
						flag2 = false;
					}
					if (num1 == 4 && flag2 && Main.rand.Next(num65) == 0)
					{
						int num68 = Main.rand.Next(5);
						if (num68 == 0)
						{
							num68 = 800;
						}
						else if (num68 == 1)
						{
							num68 = 802;
						}
						else if (num68 != 2)
						{
							num68 = (num68 != 3 ? 3062 : 1290);
						}
						else
						{
							num68 = 1256;
						}
						int num69 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num68, 1, false, -1, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num69, 1f, 0f, 0f, 0, 0, 0);
						}
						flag2 = false;
					}
					if (num1 == 5 && flag2 && Main.rand.Next(num65) == 0)
					{
						int num70 = 3085;
						int num71 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num70, 1, false, -1, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num71, 1f, 0f, 0f, 0, 0, 0);
						}
						flag2 = false;
					}
					if (num1 == 6 && flag2 && Main.rand.Next(num65) == 0)
					{
						int num72 = Main.rand.Next(3);
						if (num72 != 0)
						{
							num72 = (num72 != 1 ? 159 : 65);
						}
						else
						{
							num72 = 158;
						}
						int num73 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num72, 1, false, -1, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num73, 1f, 0f, 0f, 0, 0, 0);
						}
						flag2 = false;
					}
					if (num1 == 8 && flag2 && Main.rand.Next(num65) == 0)
					{
						int num74 = Main.rand.Next(5);
						if (num74 == 0)
						{
							num74 = 212;
						}
						else if (num74 == 1)
						{
							num74 = 964;
						}
						else if (num74 != 2)
						{
							num74 = (num74 != 3 ? 2292 : 213);
						}
						else
						{
							num74 = 211;
						}
						int num75 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num74, 1, false, -1, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num75, 1f, 0f, 0f, 0, 0, 0);
						}
						flag2 = false;
					}
					if (Main.rand.Next(4) == 0)
					{
						int num76 = 73;
						int num77 = Main.rand.Next(5, 13);
						int num78 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num76, num77, false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num78, 1f, 0f, 0f, 0, 0, 0);
						}
						flag2 = false;
					}
					if (Main.rand.Next(4) != 0)
					{
						continue;
					}
					int num79 = Main.rand.Next(6);
					if (num79 == 0)
					{
						num79 = 22;
					}
					else if (num79 == 1)
					{
						num79 = 21;
					}
					else if (num79 == 2)
					{
						num79 = 19;
					}
					else if (num79 == 3)
					{
						num79 = 704;
					}
					else if (num79 == 4)
					{
						num79 = 705;
					}
					else if (num79 == 5)
					{
						num79 = 706;
					}
					int num80 = Main.rand.Next(10, 21);
					if (Main.hardMode && Main.rand.Next(3) != 0)
					{
						num79 = Main.rand.Next(6);
						if (num79 == 0)
						{
							num79 = 381;
						}
						else if (num79 == 1)
						{
							num79 = 382;
						}
						else if (num79 == 2)
						{
							num79 = 391;
						}
						else if (num79 == 3)
						{
							num79 = 1184;
						}
						else if (num79 == 4)
						{
							num79 = 1191;
						}
						else if (num79 == 5)
						{
							num79 = 1198;
						}
						num80 = num80 - Main.rand.Next(3);
					}
					int num81 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num79, num80, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num81, 1f, 0f, 0f, 0, 0, 0);
					}
					flag2 = false;
				}
				if (Main.rand.Next(4) == 0)
				{
					int num82 = Main.rand.Next(6);
					if (num82 == 0)
					{
						num82 = 288;
					}
					else if (num82 == 1)
					{
						num82 = 296;
					}
					else if (num82 == 2)
					{
						num82 = 304;
					}
					else if (num82 == 3)
					{
						num82 = 305;
					}
					else if (num82 == 4)
					{
						num82 = 2322;
					}
					else if (num82 == 5)
					{
						num82 = 2323;
					}
					int num83 = Main.rand.Next(2, 5);
					int num84 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num82, num83, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num84, 1f, 0f, 0f, 0, 0, 0);
					}
					flag2 = false;
				}
				if (Main.rand.Next(2) == 0)
				{
					int num85 = Main.rand.Next(188, 190);
					int num86 = Main.rand.Next(5, 18);
					int num87 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num85, num86, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num87, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					int num88 = Main.rand.Next(2);
					num88 = (num88 != 0 ? 2675 : 2676);
					int num89 = Main.rand.Next(2, 7);
					int num90 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num88, num89, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num90, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (num1 == 3 || num1 == 4 || num1 == 7)
				{
					if (Main.hardMode && Main.rand.Next(2) == 0)
					{
						int num91 = 521;
						if (num1 == 7)
						{
							num91 = 520;
						}
						int num92 = Main.rand.Next(2, 6);
						int num93 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num91, num92, false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num93, 1f, 0f, 0f, 0, 0, 0);
						}
					}
					if (Main.hardMode && Main.rand.Next(2) == 0)
					{
						int num94 = 522;
						int num95 = Main.rand.Next(2, 6);
						if (num1 == 4)
						{
							num94 = 1332;
						}
						else if (num1 == 7)
						{
							num94 = 502;
							num95 = Main.rand.Next(4, 11);
						}
						int num96 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num94, num95, false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num96, 1f, 0f, 0f, 0, 0, 0);
						}
					}
				}
			}
			else
			{
				bool flag3 = true;
				while (flag3)
				{
					if (Main.hardMode && flag3 && Main.rand.Next(20) == 0)
					{
						int num97 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 3064, 1, false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num97, 1f, 0f, 0f, 0, 0, 0);
						}
						flag3 = false;
					}
					if (flag3 && Main.rand.Next(10) == 0)
					{
						int num98 = 2491;
						int num99 = 1;
						int num100 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num98, num99, false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num100, 1f, 0f, 0f, 0, 0, 0);
						}
						flag3 = false;
					}
					if (Main.rand.Next(3) == 0)
					{
						int num101 = 73;
						int num102 = Main.rand.Next(8, 21);
						int num103 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num101, num102, false, 0, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num103, 1f, 0f, 0f, 0, 0, 0);
						}
						flag3 = false;
					}
					if (Main.rand.Next(3) != 0)
					{
						continue;
					}
					int num104 = Main.rand.Next(4);
					if (num104 == 0)
					{
						num104 = 21;
					}
					else if (num104 == 1)
					{
						num104 = 19;
					}
					else if (num104 == 2)
					{
						num104 = 705;
					}
					else if (num104 == 3)
					{
						num104 = 706;
					}
					if (Main.hardMode && Main.rand.Next(3) != 0)
					{
						num104 = Main.rand.Next(4);
						if (num104 == 0)
						{
							num104 = 382;
						}
						else if (num104 == 1)
						{
							num104 = 391;
						}
						else if (num104 == 2)
						{
							num104 = 1191;
						}
						else if (num104 == 3)
						{
							num104 = 1198;
						}
					}
					int num105 = Main.rand.Next(15, 31);
					int num106 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num104, num105, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num106, 1f, 0f, 0f, 0, 0, 0);
					}
					flag3 = false;
				}
				if (Main.rand.Next(3) == 0)
				{
					int num107 = Main.rand.Next(5);
					if (num107 == 0)
					{
						num107 = 288;
					}
					else if (num107 == 1)
					{
						num107 = 296;
					}
					else if (num107 == 2)
					{
						num107 = 305;
					}
					else if (num107 == 3)
					{
						num107 = 2322;
					}
					else if (num107 == 4)
					{
						num107 = 2323;
					}
					int num108 = Main.rand.Next(2, 6);
					int num109 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num107, num108, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num109, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					int num110 = Main.rand.Next(499, 501);
					int num111 = Main.rand.Next(5, 21);
					int num112 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num110, num111, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num112, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.rand.Next(3) != 0)
				{
					int num113 = 2676;
					int num114 = Main.rand.Next(3, 8);
					int num115 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num113, num114, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num115, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
			}
		}

		public void openGoodieBag()
		{
			if (Main.rand.Next(150) == 0)
			{
				int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1810, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int num1 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1800, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num1, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(4) == 0)
			{
				int num2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1809, Main.rand.Next(10, 41), false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num2, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(10) != 0)
			{
				int num3 = Main.rand.Next(19);
				if (num3 == 0)
				{
					int num4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1749, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num4, 1f, 0f, 0f, 0, 0, 0);
					}
					num4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1750, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num4, 1f, 0f, 0f, 0, 0, 0);
					}
					num4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1751, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num4, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 1)
				{
					int num5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1746, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num5, 1f, 0f, 0f, 0, 0, 0);
					}
					num5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1747, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num5, 1f, 0f, 0f, 0, 0, 0);
					}
					num5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1748, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num5, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 2)
				{
					int num6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1752, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num6, 1f, 0f, 0f, 0, 0, 0);
					}
					num6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1753, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num6, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 3)
				{
					int num7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1767, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num7, 1f, 0f, 0f, 0, 0, 0);
					}
					num7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1768, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num7, 1f, 0f, 0f, 0, 0, 0);
					}
					num7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1769, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num7, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 4)
				{
					int num8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1770, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num8, 1f, 0f, 0f, 0, 0, 0);
					}
					num8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1771, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num8, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 5)
				{
					int num9 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1772, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num9, 1f, 0f, 0f, 0, 0, 0);
					}
					num9 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1773, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num9, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 6)
				{
					int num10 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1754, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num10, 1f, 0f, 0f, 0, 0, 0);
					}
					num10 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1755, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num10, 1f, 0f, 0f, 0, 0, 0);
					}
					num10 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1756, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num10, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 7)
				{
					int num11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1757, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num11, 1f, 0f, 0f, 0, 0, 0);
					}
					num11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1758, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num11, 1f, 0f, 0f, 0, 0, 0);
					}
					num11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1759, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num11, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 8)
				{
					int num12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1760, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num12, 1f, 0f, 0f, 0, 0, 0);
					}
					num12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1761, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num12, 1f, 0f, 0f, 0, 0, 0);
					}
					num12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1762, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num12, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 9)
				{
					int num13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1763, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num13, 1f, 0f, 0f, 0, 0, 0);
					}
					num13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1764, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num13, 1f, 0f, 0f, 0, 0, 0);
					}
					num13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1765, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num13, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 10)
				{
					int num14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1766, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num14, 1f, 0f, 0f, 0, 0, 0);
					}
					num14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1775, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num14, 1f, 0f, 0f, 0, 0, 0);
					}
					num14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1776, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num14, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 11)
				{
					int num15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1777, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num15, 1f, 0f, 0f, 0, 0, 0);
					}
					num15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1778, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num15, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 12)
				{
					int num16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1779, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num16, 1f, 0f, 0f, 0, 0, 0);
					}
					num16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1780, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num16, 1f, 0f, 0f, 0, 0, 0);
					}
					num16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1781, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num16, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 13)
				{
					int num17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1819, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num17, 1f, 0f, 0f, 0, 0, 0);
					}
					num17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1820, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num17, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 14)
				{
					int num18 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1821, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num18, 1f, 0f, 0f, 0, 0, 0);
					}
					num18 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1822, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num18, 1f, 0f, 0f, 0, 0, 0);
					}
					num18 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1823, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num18, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 15)
				{
					int num19 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1824, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num19, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 16)
				{
					int num20 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1838, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num20, 1f, 0f, 0f, 0, 0, 0);
					}
					num20 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1839, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num20, 1f, 0f, 0f, 0, 0, 0);
					}
					num20 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1840, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num20, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 17)
				{
					int num21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1841, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num21, 1f, 0f, 0f, 0, 0, 0);
					}
					num21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1842, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num21, 1f, 0f, 0f, 0, 0, 0);
					}
					num21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1843, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num21, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 18)
				{
					int num22 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1851, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num22, 1f, 0f, 0f, 0, 0, 0);
					}
					num22 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1852, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num22, 1f, 0f, 0f, 0, 0, 0);
					}
				}
			}
			else
			{
				int num23 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Main.rand.Next(1846, 1851), 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num23, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
		}

		public void openHerbBag()
		{
			int num = Main.rand.Next(2, 5);
			if (Main.rand.Next(3) == 0)
			{
				num++;
			}
			for (int i = 0; i < num; i++)
			{
				int num1 = Main.rand.Next(14);
				if (num1 == 0)
				{
					num1 = 313;
				}
				if (num1 == 1)
				{
					num1 = 314;
				}
				if (num1 == 2)
				{
					num1 = 315;
				}
				if (num1 == 3)
				{
					num1 = 317;
				}
				if (num1 == 4)
				{
					num1 = 316;
				}
				if (num1 == 5)
				{
					num1 = 318;
				}
				if (num1 == 6)
				{
					num1 = 2358;
				}
				if (num1 == 7)
				{
					num1 = 307;
				}
				if (num1 == 8)
				{
					num1 = 308;
				}
				if (num1 == 9)
				{
					num1 = 309;
				}
				if (num1 == 10)
				{
					num1 = 311;
				}
				if (num1 == 11)
				{
					num1 = 310;
				}
				if (num1 == 12)
				{
					num1 = 312;
				}
				if (num1 == 13)
				{
					num1 = 2357;
				}
				int num2 = Main.rand.Next(2, 5);
				if (Main.rand.Next(3) == 0)
				{
					num2 = num2 + Main.rand.Next(1, 5);
				}
				int num3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num1, num2, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num3, 1f, 0f, 0f, 0, 0, 0);
				}
			}
		}

		public void openLockBox()
		{
			bool flag = true;
			while (flag)
			{
				flag = false;
				int num = 0;
				int num1 = Main.rand.Next(7);
				if (num1 == 1)
				{
					num = 329;
				}
				else if (num1 == 2)
				{
					num = 155;
				}
				else if (num1 == 3)
				{
					num = 156;
				}
				else if (num1 == 4)
				{
					num = 157;
				}
				else if (num1 != 5)
				{
					num = (num1 != 6 ? 164 : 113);
				}
				else
				{
					num = 163;
				}
				int num2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num, 1, false, -1, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num2, 1f, 0f, 0f, 0, 0, 0);
				}
				if (Main.rand.Next(3) == 0)
				{
					flag = false;
					int num3 = Main.rand.Next(1, 4);
					if (Main.rand.Next(2) == 0)
					{
						num3 = num3 + Main.rand.Next(2);
					}
					if (Main.rand.Next(3) == 0)
					{
						num3 = num3 + Main.rand.Next(3);
					}
					if (Main.rand.Next(4) == 0)
					{
						num3 = num3 + Main.rand.Next(3);
					}
					if (Main.rand.Next(5) == 0)
					{
						num3 = num3 + Main.rand.Next(1, 3);
					}
					int num4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 73, num3, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num4, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					flag = false;
					int num5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 72, Main.rand.Next(10, 100), false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num5, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.rand.Next(3) == 0)
				{
					flag = false;
					int num6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 188, Main.rand.Next(2, 6), false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num6, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.rand.Next(3) != 0)
				{
					continue;
				}
				flag = false;
				int num7 = Main.rand.Next(9);
				if (num7 == 0)
				{
					num7 = 296;
				}
				else if (num7 == 1)
				{
					num7 = 2346;
				}
				else if (num7 == 2)
				{
					num7 = 305;
				}
				else if (num7 == 3)
				{
					num7 = 2323;
				}
				else if (num7 == 4)
				{
					num7 = 292;
				}
				else if (num7 == 5)
				{
					num7 = 294;
				}
				else if (num7 != 6)
				{
					num7 = (Main.netMode != 1 ? 2350 : 2997);
				}
				else
				{
					num7 = 288;
				}
				int num8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num7, Main.rand.Next(1, 4), false, 0, false);
				if (Main.netMode != 1)
				{
					continue;
				}
				NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num8, 1f, 0f, 0f, 0, 0, 0);
			}
		}

		public void openPresent()
		{
			if (Main.rand.Next(15) == 0 && Main.hardMode)
			{
				int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 602, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(30) == 0)
			{
				int num1 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1922, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num1, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(400) == 0)
			{
				int num2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1927, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num2, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int num3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1870, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num3, 1f, 0f, 0f, 0, 0, 0);
				}
				num3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 97, Main.rand.Next(30, 61), false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num3, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int num4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1909, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num4, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int num5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1917, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num5, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int num6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1915, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num6, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int num7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1918, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num7, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int num8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1921, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num8, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(300) == 0)
			{
				int num9 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1923, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num9, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(40) == 0)
			{
				int num10 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1907, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num10, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(10) == 0)
			{
				int num11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1908, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num11, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(15) == 0)
			{
				int num12 = Main.rand.Next(5);
				if (num12 == 0)
				{
					int num13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1932, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num13, 1f, 0f, 0f, 0, 0, 0);
					}
					num13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1933, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num13, 1f, 0f, 0f, 0, 0, 0);
					}
					num13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1934, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num13, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num12 == 1)
				{
					int num14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1935, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num14, 1f, 0f, 0f, 0, 0, 0);
					}
					num14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1936, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num14, 1f, 0f, 0f, 0, 0, 0);
					}
					num14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1937, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num14, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num12 == 2)
				{
					int num15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1940, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num15, 1f, 0f, 0f, 0, 0, 0);
					}
					num15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1941, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num15, 1f, 0f, 0f, 0, 0, 0);
					}
					num15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1942, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num15, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num12 == 3)
				{
					int num16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1938, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num16, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num12 == 4)
				{
					int num17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1939, 1, false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num17, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
			}
			else if (Main.rand.Next(7) == 0)
			{
				int num18 = Main.rand.Next(3);
				if (num18 == 0)
				{
					num18 = 1911;
				}
				if (num18 == 1)
				{
					num18 = 1919;
				}
				if (num18 == 2)
				{
					num18 = 1920;
				}
				int num19 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num18, 1, false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num19, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(8) == 0)
			{
				int num20 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1912, Main.rand.Next(1, 4), false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num20, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(9) != 0)
			{
				int num21 = Main.rand.Next(3);
				if (num21 == 0)
				{
					int num22 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1872, Main.rand.Next(20, 50), false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num22, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num21 != 1)
				{
					int num23 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 591, Main.rand.Next(20, 50), false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num23, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				else
				{
					int num24 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 586, Main.rand.Next(20, 50), false, 0, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num24, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
			}
			else
			{
				int num25 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1913, Main.rand.Next(20, 41), false, 0, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num25, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
		}

		public void PickAmmo(Item sItem, ref int shoot, ref float speed, ref bool canShoot, ref int Damage, ref float KnockBack, bool dontConsume = false)
		{
			Item item = new Item();
			bool flag = false;
			int num = 54;
			while (num < 58)
			{
				if (this.inventory[num].ammo != sItem.useAmmo || this.inventory[num].stack <= 0)
				{
					num++;
				}
				else
				{
					item = this.inventory[num];
					canShoot = true;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				int num1 = 0;
				while (num1 < 54)
				{
					if (this.inventory[num1].ammo != sItem.useAmmo || this.inventory[num1].stack <= 0)
					{
						num1++;
					}
					else
					{
						item = this.inventory[num1];
						canShoot = true;
						break;
					}
				}
			}
			if (canShoot)
			{
				if (sItem.type == ItemID.SnowmanCannon)
				{
					shoot = 338 + item.type - 771;
				}
				else if (sItem.useAmmo == 771)
				{
					shoot = shoot + item.shoot;
				}
				else if (sItem.useAmmo == 780)
				{
					shoot = shoot + item.shoot;
				}
				else if (item.shoot > 0)
				{
					shoot = item.shoot;
				}
				if (sItem.type == ItemID.HellwingBow && shoot == 1)
				{
					shoot = 485;
				}
				if (sItem.type == ItemID.ShadowFlameBow)
				{
					shoot = 495;
				}
				if (sItem.type == ItemID.BoneGlove && shoot == 21)
				{
					shoot = 532;
				}
				if (shoot == 42)
				{
					if (item.type == ItemID.EbonsandBlock)
					{
						shoot = 65;
						Damage = Damage + 5;
					}
					else if (item.type == ItemID.PearlsandBlock)
					{
						shoot = 68;
						Damage = Damage + 5;
					}
					else if (item.type == ItemID.CrimsandBlock)
					{
						shoot = 354;
						Damage = Damage + 5;
					}
				}
				if (this.inventory[this.selectedItem].type == 2888 && shoot == 1)
				{
					shoot = 469;
				}
				if (this.magicQuiver && (sItem.useAmmo == 1 || sItem.useAmmo == 323))
				{
					KnockBack = (float)((int)((double)KnockBack * 1.1));
					speed = speed * 1.1f;
				}
				speed = speed + item.shootSpeed;
				if (!item.ranged)
				{
					Damage = Damage + item.damage;
				}
				else if (item.damage > 0)
				{
					Damage = Damage + (int)((float)item.damage * this.rangedDamage);
				}
				if (sItem.useAmmo == 1 && this.archery)
				{
					if (speed < 20f)
					{
						speed = speed * 1.2f;
						if (speed > 20f)
						{
							speed = 20f;
						}
					}
					Damage = (int)((double)((float)Damage) * 1.2);
				}
				KnockBack = KnockBack + item.knockBack;
				bool flag1 = dontConsume;
				if (sItem.type == ItemID.BoneGlove)
				{
					if (Main.rand.Next(3) == 0)
					{
						flag1 = true;
					}
					else if (this.thrownCost33 && Main.rand.Next(100) < 33)
					{
						flag1 = true;
					}
					else if (this.thrownCost50 && Main.rand.Next(100) < 50)
					{
						flag1 = true;
					}
				}
				if (sItem.type == ItemID.VortexBeater && Main.rand.Next(3) != 0)
				{
					flag1 = true;
				}
				if (sItem.type == ItemID.Phantasm && Main.rand.Next(3) != 0)
				{
					flag1 = true;
				}
				if (this.magicQuiver && sItem.useAmmo == 1 && Main.rand.Next(5) == 0)
				{
					flag1 = true;
				}
				if (this.ammoBox && Main.rand.Next(5) == 0)
				{
					flag1 = true;
				}
				if (this.ammoPotion && Main.rand.Next(5) == 0)
				{
					flag1 = true;
				}
				if (sItem.type == ItemID.CandyCornRifle && Main.rand.Next(3) == 0)
				{
					flag1 = true;
				}
				if (sItem.type == ItemID.Minishark && Main.rand.Next(3) == 0)
				{
					flag1 = true;
				}
				if (sItem.type == ItemID.Gatligator && Main.rand.Next(2) == 0)
				{
					flag1 = true;
				}
				if (sItem.type == ItemID.Megashark && Main.rand.Next(2) == 0)
				{
					flag1 = true;
				}
				if (sItem.type == ItemID.ChainGun && Main.rand.Next(2) == 0)
				{
					flag1 = true;
				}
				if (sItem.type == ItemID.SDMG && Main.rand.Next(2) == 0)
				{
					flag1 = true;
				}
				if (sItem.type == ItemID.ClockworkAssaultRifle && this.itemAnimation < sItem.useAnimation - 2)
				{
					flag1 = true;
				}
				if (this.ammoCost80 && Main.rand.Next(5) == 0)
				{
					flag1 = true;
				}
				if (this.ammoCost75 && Main.rand.Next(4) == 0)
				{
					flag1 = true;
				}
				if (shoot == 85 && this.itemAnimation < this.itemAnimationMax - 6)
				{
					flag1 = true;
				}
				if ((shoot == 145 || shoot == 146 || shoot == 147 || shoot == 148 || shoot == 149) && this.itemAnimation < this.itemAnimationMax - 5)
				{
					flag1 = true;
				}
				if (!flag1 && item.consumable)
				{
					Item item1 = item;
					item1.stack = item1.stack - 1;
					if (item.stack <= 0)
					{
						item.active = false;
						item.name = "";
						item.type = 0;
					}
				}
			}
		}

		public void PickTile(int x, int y, int pickPower)
		{
			int num = 0;
			int num1 = this.hitTile.HitObject(x, y, 1);
			Tile tile = Main.tile[x, y];
			if (Main.tileNoFail[tile.type])
			{
				num = 100;
			}
			if (Main.tileDungeon[tile.type] || tile.type == TileID.Ebonstone || tile.type == TileID.Hellstone || tile.type == TileID.Pearlstone || tile.type == TileID.Crimstone)
			{
				num = num + pickPower / 2;
			}
			else if (tile.type == TileID.Spikes || tile.type == TileID.WoodenSpikes)
			{
				num = num + pickPower / 4;
			}
			else if (tile.type == TileID.LihzahrdBrick)
			{
				num = num + pickPower / 4;
			}
			else if (tile.type == TileID.Cobalt || tile.type == TileID.Palladium)
			{
				num = num + pickPower / 2;
			}
			else if (tile.type == TileID.Mythril || tile.type == TileID.Orichalcum)
			{
				num = num + pickPower / 3;
			}
			else if (tile.type == TileID.Adamantite || tile.type == TileID.Titanium)
			{
				num = num + pickPower / 4;
			}
			else
			{
				num = (tile.type != TileID.Chlorophyte ? num + pickPower : num + pickPower / 5);
			}
			if (tile.type == TileID.Chlorophyte && pickPower < 200)
			{
				num = 0;
			}
			if ((tile.type == TileID.Ebonstone || tile.type == TileID.Crimstone) && pickPower < 65)
			{
				num = 0;
			}
			else if (tile.type == TileID.Pearlstone && pickPower < 65)
			{
				num = 0;
			}
			else if (tile.type == TileID.Meteorite && pickPower < 50)
			{
				num = 0;
			}
			else if (tile.type == TileID.DesertFossil && pickPower < 65)
			{
				num = 0;
			}
			else if ((tile.type == TileID.Demonite || tile.type == TileID.Crimtane) && (double)y > Main.worldSurface && pickPower < 55)
			{
				num = 0;
			}
			else if (tile.type == TileID.Obsidian && pickPower < 65)
			{
				num = 0;
			}
			else if (tile.type == TileID.Hellstone && pickPower < 65)
			{
				num = 0;
			}
			else if ((tile.type == TileID.LihzahrdBrick || tile.type == TileID.LihzahrdAltar) && pickPower < 210)
			{
				num = 0;
			}
			else if (Main.tileDungeon[tile.type] && pickPower < 65)
			{
				if ((double)x < (double)Main.maxTilesX * 0.35 || (double)x > (double)Main.maxTilesX * 0.65)
				{
					num = 0;
				}
			}
			else if (tile.type == TileID.Cobalt && pickPower < 100)
			{
				num = 0;
			}
			else if (tile.type == TileID.Mythril && pickPower < 110)
			{
				num = 0;
			}
			else if (tile.type == TileID.Adamantite && pickPower < 150)
			{
				num = 0;
			}
			else if (tile.type == TileID.Palladium && pickPower < 100)
			{
				num = 0;
			}
			else if (tile.type == TileID.Orichalcum && pickPower < 110)
			{
				num = 0;
			}
			else if (tile.type == TileID.Titanium && pickPower < 150)
			{
				num = 0;
			}
			if (tile.type == TileID.SnowBlock || tile.type == TileID.Dirt || tile.type == TileID.ClayBlock || tile.type == TileID.Sand || tile.type == TileID.Ash || tile.type == TileID.Mud || tile.type == TileID.Silt || tile.type == TileID.Slush || tile.type == TileID.HardenedSand)
			{
				num = num + pickPower;
			}
			if (tile.type == TileID.Stalactite || Main.tileRope[tile.type] || tile.type == TileID.FleshGrass || Main.tileMoss[tile.type])
			{
				num = 100;
			}
			if (this.hitTile.AddDamage(num1, num, false) >= 100 && (tile.type == TileID.Grass || tile.type == TileID.CorruptGrass || tile.type == TileID.JungleGrass || tile.type == TileID.MushroomGrass || tile.type == TileID.HallowedGrass || tile.type == TileID.FleshGrass || Main.tileMoss[tile.type]))
			{
				num = 0;
			}
			if (tile.type == TileID.Mannequin || tile.type == TileID.Womannequin)
			{
				if (tile.frameX == 18 || tile.frameX == 54)
				{
					x--;
					tile = Main.tile[x, y];
					this.hitTile.UpdatePosition(num1, x, y);
				}
				if (tile.frameX >= 100)
				{
					num = 0;
					Main.blockMouse = true;
				}
			}
			if (tile.type == TileID.WeaponsRack)
			{
				if (tile.frameY == 0)
				{
					y++;
					tile = Main.tile[x, y];
					this.hitTile.UpdatePosition(num1, x, y);
				}
				if (tile.frameY == 36)
				{
					y--;
					tile = Main.tile[x, y];
					this.hitTile.UpdatePosition(num1, x, y);
				}
				int num2 = tile.frameX;
				bool flag = num2 >= 5000;
				bool flag1 = false;
				if (!flag)
				{
					x = x - num2 / 18 % 3;
					tile = Main.tile[x, y];
					if (tile.frameX >= 5000)
					{
						flag = true;
					}
				}
				if (flag)
				{
					num2 = tile.frameX;
					int num3 = 0;
					while (num2 >= 5000)
					{
						num2 = num2 - 5000;
						num3++;
					}
					if (num3 != 0)
					{
						flag1 = true;
					}
				}
				if (flag1)
				{
					num = 0;
					Main.blockMouse = true;
				}
			}
			if (!WorldGen.CanKillTile(x, y))
			{
				num = 0;
			}
			if (this.hitTile.AddDamage(num1, num, true) < 100)
			{
				WorldGen.KillTile(x, y, true, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)x, (float)y, 1f, 0, 0, 0);
				}
			}
			else
			{
				AchievementsHelper.CurrentlyMining = true;
				this.hitTile.Clear(num1);
				if (Main.netMode != 1 || !Main.tileContainer[Main.tile[x, y].type])
				{
					int num4 = y;
					Main.tile[x, num4].active();
					WorldGen.KillTile(x, num4, false, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)x, (float)num4, 0f, 0, 0, 0);
					}
				}
				else
				{
					WorldGen.KillTile(x, y, true, false, false);
					NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)x, (float)y, 1f, 0, 0, 0);
					if (Main.tile[x, y].type == TileID.Containers)
					{
						NetMessage.SendData((int)PacketTypes.TileKill, -1, -1, "", 1, (float)x, (float)y, 0f, 0, 0, 0);
					}
					if (Main.tile[x, y].type == TileID.Dressers)
					{
						NetMessage.SendData((int)PacketTypes.TileKill, -1, -1, "", 3, (float)x, (float)y, 0f, 0, 0, 0);
					}
				}
				AchievementsHelper.CurrentlyMining = false;
			}
			if (num != 0)
			{
				this.hitTile.Prune();
			}
		}

		public void PlaceItemInFrame(int x, int y)
		{
			if (Main.tile[x, y].frameX % 36 != 0)
			{
				x--;
			}
			if (Main.tile[x, y].frameY % 36 != 0)
			{
				y--;
			}
			int num = TEItemFrame.Find(x, y);
			if (num == -1)
			{
				return;
			}
			if (((TEItemFrame)TileEntity.ByID[num]).item.stack > 0)
			{
				WorldGen.KillTile(x, y, true, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)Player.tileTargetX, (float)y, 1f, 0, 0, 0);
				}
			}
			if (Main.netMode != 1)
			{
				TEItemFrame.TryPlacing(x, y, this.inventory[this.selectedItem].netID, (int)this.inventory[this.selectedItem].prefix, this.inventory[this.selectedItem].stack);
			}
			else
			{
				NetMessage.SendData((int)PacketTypes.PlaceItemFrame, -1, -1, "", x, (float)y, (float)this.selectedItem, (float)this.whoAmI, 0, 0, 0);
			}
			Item item = this.inventory[this.selectedItem];
			item.stack = item.stack - 1;
			if (this.inventory[this.selectedItem].stack <= 0)
			{
				this.inventory[this.selectedItem].SetDefaults(0, false);
				Main.mouseItem.SetDefaults(0, false);
			}
			if (this.selectedItem == 58)
			{
				Main.mouseItem = this.inventory[this.selectedItem].Clone();
			}
			this.releaseUseItem = false;
			this.mouseInterface = true;
		}

		public void PlaceThing()
		{
			int i;
			bool flag;
			if ((this.inventory[this.selectedItem].type == 1071 || this.inventory[this.selectedItem].type == 1543) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
			{
				int num = Player.tileTargetX;
				int num1 = Player.tileTargetY;
				if (Main.tile[num, num1] != null && Main.tile[num, num1].active())
				{
					this.showItemIcon = true;
					if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
					{
						int num2 = -1;
						int num3 = -1;
						int num4 = 0;
						while (num4 < 58)
						{
							if (this.inventory[num4].stack <= 0 || this.inventory[num4].paint <= 0)
							{
								num4++;
							}
							else
							{
								num2 = this.inventory[num4].paint;
								num3 = num4;
								break;
							}
						}
						if (num2 > 0 && Main.tile[num, num1].color() != num2 && WorldGen.paintTile(num, num1, (byte)num2, true))
						{
							int num5 = num3;
							Item item = this.inventory[num5];
							item.stack = item.stack - 1;
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
						int num10 = 0;
						while (num10 < 58)
						{
							if (this.inventory[num10].stack <= 0 || this.inventory[num10].paint <= 0)
							{
								num10++;
							}
							else
							{
								num8 = this.inventory[num10].paint;
								num9 = num10;
								break;
							}
						}
						if (num8 > 0 && Main.tile[num6, num7].wallColor() != num8 && WorldGen.paintWall(num6, num7, (byte)num8, true))
						{
							int num11 = num9;
							Item item1 = this.inventory[num11];
							item1.stack = item1.stack - 1;
							if (this.inventory[num11].stack <= 0)
							{
								this.inventory[num11].SetDefaults(0, false);
							}
							this.itemTime = this.inventory[this.selectedItem].useTime;
						}
					}
				}
			}
			if ((this.inventory[this.selectedItem].type == 1100 || this.inventory[this.selectedItem].type == 1545) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
			{
				int num12 = Player.tileTargetX;
				int num13 = Player.tileTargetY;
				if (Main.tile[num12, num13] != null && (Main.tile[num12, num13].wallColor() > 0 && Main.tile[num12, num13].wall > 0 || Main.tile[num12, num13].color() > 0 && Main.tile[num12, num13].active()))
				{
					this.showItemIcon = true;
					if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
					{
						if (Main.tile[num12, num13].color() > 0 && Main.tile[num12, num13].active() && WorldGen.paintTile(num12, num13, 0, true))
						{
							this.itemTime = this.inventory[this.selectedItem].useTime;
						}
						else if (Main.tile[num12, num13].wallColor() > 0 && Main.tile[num12, num13].wall > 0 && WorldGen.paintWall(num12, num13, 0, true))
						{
							this.itemTime = this.inventory[this.selectedItem].useTime;
						}
					}
				}
			}
			if ((this.inventory[this.selectedItem].type == 929 || this.inventory[this.selectedItem].type == 1338 || this.inventory[this.selectedItem].type == 1345) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
			{
				int num14 = Player.tileTargetX;
				int num15 = Player.tileTargetY;
				if (Main.tile[num14, num15].active() && Main.tile[num14, num15].type == TileID.Cannon)
				{
					int num16 = 0;
					if (Main.tile[num14, num15].frameX < 72)
					{
						if (this.inventory[this.selectedItem].type == 929)
						{
							num16 = 1;
						}
					}
					else if (Main.tile[num14, num15].frameX < 144)
					{
						if (this.inventory[this.selectedItem].type == 1338)
						{
							num16 = 2;
						}
					}
					else if (Main.tile[num14, num15].frameX < 288 && this.inventory[this.selectedItem].type == 1345)
					{
						num16 = 3;
					}
					if (num16 > 0)
					{
						this.showItemIcon = true;
						if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
						{
							int num17 = Main.tile[num14, num15].frameX / 18;
							int num18 = 0;
							int num19 = 0;
							while (num17 >= 4)
							{
								num18++;
								num17 = num17 - 4;
							}
							num17 = num14 - num17;
							for (i = Main.tile[num14, num15].frameY / 18; i >= 3; i = i - 3)
							{
								num19++;
							}
							i = num15 - i;
							this.itemTime = this.inventory[this.selectedItem].useTime;
							float single = 14f;
							float single1 = 0f;
							float single2 = 0f;
							int num20 = 162;
							if (num16 == 2)
							{
								num20 = 281;
							}
							if (num16 == 3)
							{
								num20 = 178;
							}
							int num21 = this.inventory[this.selectedItem].damage;
							int num22 = 8;
							if (num19 == 0)
							{
								single1 = 10f;
								single2 = 0f;
							}
							if (num19 == 1)
							{
								single1 = 7.5f;
								single2 = -2.5f;
							}
							if (num19 == 2)
							{
								single1 = 5f;
								single2 = -5f;
							}
							if (num19 == 3)
							{
								single1 = 2.75f;
								single2 = -6f;
							}
							if (num19 == 4)
							{
								single1 = 0f;
								single2 = -10f;
							}
							if (num19 == 5)
							{
								single1 = -2.75f;
								single2 = -6f;
							}
							if (num19 == 6)
							{
								single1 = -5f;
								single2 = -5f;
							}
							if (num19 == 7)
							{
								single1 = -7.5f;
								single2 = -2.5f;
							}
							if (num19 == 8)
							{
								single1 = -10f;
								single2 = 0f;
							}
							Vector2 vector2 = new Vector2((float)((num17 + 2) * 16), (float)((i + 2) * 16));
							float single3 = single1;
							float single4 = single2;
							float single5 = (float)Math.Sqrt((double)(single3 * single3 + single4 * single4));
							single5 = single / single5;
							single3 = single3 * single5;
							single4 = single4 * single5;
							Projectile.NewProjectile(vector2.X, vector2.Y, single3, single4, num20, num21, (float)num22, Main.myPlayer, 0f, 0f);
						}
					}
				}
			}
			if (this.inventory[this.selectedItem].type >= 1874 && this.inventory[this.selectedItem].type <= 1905 && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 171 && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
			{
				int num23 = this.inventory[this.selectedItem].type;
				if (num23 >= 1874 && num23 <= 1877)
				{
					num23 = num23 - 1873;
					if (WorldGen.checkXmasTreeDrop(Player.tileTargetX, Player.tileTargetY, 0) != num23)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						WorldGen.dropXmasTree(Player.tileTargetX, Player.tileTargetY, 0);
						WorldGen.setXmasTree(Player.tileTargetX, Player.tileTargetY, 0, num23);
						int num24 = Player.tileTargetX;
						int num25 = Player.tileTargetY;
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 10)
						{
							num24 = num24 - Main.tile[Player.tileTargetX, Player.tileTargetY].frameX;
							num25 = num25 - Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
						}
						NetMessage.SendTileSquare(-1, num24, num25, 1);
					}
				}
				else if (num23 >= 1878 && num23 <= 1883)
				{
					num23 = num23 - 1877;
					if (WorldGen.checkXmasTreeDrop(Player.tileTargetX, Player.tileTargetY, 1) != num23)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						WorldGen.dropXmasTree(Player.tileTargetX, Player.tileTargetY, 1);
						WorldGen.setXmasTree(Player.tileTargetX, Player.tileTargetY, 1, num23);
						int num26 = Player.tileTargetX;
						int num27 = Player.tileTargetY;
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 10)
						{
							num26 = num26 - Main.tile[Player.tileTargetX, Player.tileTargetY].frameX;
							num27 = num27 - Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
						}
						NetMessage.SendTileSquare(-1, num26, num27, 1);
					}
				}
				else if (num23 >= 1884 && num23 <= 1894)
				{
					num23 = num23 - 1883;
					if (WorldGen.checkXmasTreeDrop(Player.tileTargetX, Player.tileTargetY, 2) != num23)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						WorldGen.dropXmasTree(Player.tileTargetX, Player.tileTargetY, 2);
						WorldGen.setXmasTree(Player.tileTargetX, Player.tileTargetY, 2, num23);
						int num28 = Player.tileTargetX;
						int num29 = Player.tileTargetY;
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 10)
						{
							num28 = num28 - Main.tile[Player.tileTargetX, Player.tileTargetY].frameX;
							num29 = num29 - Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
						}
						NetMessage.SendTileSquare(-1, num28, num29, 1);
					}
				}
				else if (num23 >= 1895 && num23 <= 1905)
				{
					num23 = num23 - 1894;
					if (WorldGen.checkXmasTreeDrop(Player.tileTargetX, Player.tileTargetY, 3) != num23)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						WorldGen.dropXmasTree(Player.tileTargetX, Player.tileTargetY, 3);
						WorldGen.setXmasTree(Player.tileTargetX, Player.tileTargetY, 3, num23);
						int num30 = Player.tileTargetX;
						int num31 = Player.tileTargetY;
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 10)
						{
							num30 = num30 - Main.tile[Player.tileTargetX, Player.tileTargetY].frameX;
							num31 = num31 - Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
						}
						NetMessage.SendTileSquare(-1, num30, num31, 1);
					}
				}
			}
			if (ItemID.Sets.ExtractinatorMode[this.inventory[this.selectedItem].type] >= 0 && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 219)
			{
				if (this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					int extractinatorMode = ItemID.Sets.ExtractinatorMode[this.inventory[this.selectedItem].type];
					Player.ExtractinatorUse(extractinatorMode);
				}
			}
			else if (this.inventory[this.selectedItem].createTile >= 0 && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
			{
				this.showItemIcon = true;
				bool flag1 = false;
				if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0 && Main.tile[Player.tileTargetX, Player.tileTargetY].lava())
				{
					if (Main.tileSolid[this.inventory[this.selectedItem].createTile])
					{
						flag1 = true;
					}
					else if (!TileObjectData.CheckLiquidPlacement(this.inventory[this.selectedItem].createTile, this.inventory[this.selectedItem].placeStyle, Main.tile[Player.tileTargetX, Player.tileTargetY]))
					{
						flag1 = true;
					}
				}
				bool flag2 = true;
				if (this.inventory[this.selectedItem].tileWand > 0)
				{
					int num32 = this.inventory[this.selectedItem].tileWand;
					flag2 = false;
					int num33 = 0;
					while (num33 < 58)
					{
						if (num32 != this.inventory[num33].type || this.inventory[num33].stack <= 0)
						{
							num33++;
						}
						else
						{
							flag2 = true;
							break;
						}
					}
				}
				if (Main.tileRope[this.inventory[this.selectedItem].createTile] && flag2 && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tileRope[Main.tile[Player.tileTargetX, Player.tileTargetY].type])
				{
					int num34 = Player.tileTargetY;
					int num35 = Player.tileTargetX;
					int num36 = this.inventory[this.selectedItem].createTile;
					while (Main.tile[num35, num34].active() && Main.tileRope[Main.tile[num35, num34].type] && num34 < Main.maxTilesX - 5 && Main.tile[num35, num34 + 2] != null && !Main.tile[num35, num34 + 1].lava())
					{
						num34++;
						if (Main.tile[num35, num34] != null)
						{
							continue;
						}
						flag2 = false;
						num34 = Player.tileTargetY;
					}
					if (!Main.tile[num35, num34].active())
					{
						Player.tileTargetY = num34;
					}
				}
				if (flag2 && (!Main.tile[Player.tileTargetX, Player.tileTargetY].active() && !flag1 || Main.tileCut[Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tile[Player.tileTargetX, Player.tileTargetY].type >= 373 && Main.tile[Player.tileTargetX, Player.tileTargetY].type <= 375 || this.inventory[this.selectedItem].createTile == 199 || this.inventory[this.selectedItem].createTile == 23 || this.inventory[this.selectedItem].createTile == 2 || this.inventory[this.selectedItem].createTile == 109 || this.inventory[this.selectedItem].createTile == 60 || this.inventory[this.selectedItem].createTile == 70 || TileID.Sets.BreakableWhenPlacing[Main.tile[Player.tileTargetX, Player.tileTargetY].type]) && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
				{
					bool flag3 = false;
					bool flag4 = false;
					TileObject tileObject = new TileObject();
					if (!TileObjectData.CustomPlace(this.inventory[this.selectedItem].createTile, this.inventory[this.selectedItem].placeStyle) || this.inventory[this.selectedItem].createTile == 82)
					{
						if (this.inventory[this.selectedItem].type == 213)
						{
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 1)
							{
								flag3 = true;
							}
						}
						else if (this.inventory[this.selectedItem].createTile == 23 || this.inventory[this.selectedItem].createTile == 2 || this.inventory[this.selectedItem].createTile == 109 || this.inventory[this.selectedItem].createTile == 199)
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
						else if (this.inventory[this.selectedItem].createTile >= 373 && this.inventory[this.selectedItem].createTile <= 375)
						{
							int num37 = Player.tileTargetX;
							int num38 = Player.tileTargetY - 1;
							if (Main.tile[num37, num38].nactive() && Main.tileSolid[Main.tile[num37, num38].type] && !Main.tileSolidTop[Main.tile[num37, num38].type])
							{
								flag3 = true;
							}
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
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].wall <= 0)
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
												NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 14, (float)Player.tileTargetX, (float)(Player.tileTargetY + 1), 0f, 0, 0, 0);
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
												NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 14, (float)(Player.tileTargetX - 1), (float)Player.tileTargetY, 0f, 0, 0, 0);
											}
										}
									}
									else if (!WorldGen.SolidTileNoAttach(Player.tileTargetX, Player.tileTargetY + 1) && !WorldGen.SolidTileNoAttach(Player.tileTargetX - 1, Player.tileTargetY) && !WorldGen.SolidTileNoAttach(Player.tileTargetX + 1, Player.tileTargetY) && (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].halfBrick() || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].slope() != 0) && Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type != 19)
									{
										WorldGen.SlopeTile(Player.tileTargetX + 1, Player.tileTargetY, 0);
										if (Main.netMode == 1)
										{
											NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 14, (float)(Player.tileTargetX + 1), (float)Player.tileTargetY, 0f, 0, 0, 0);
										}
									}
								}
								int num39 = Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type;
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].halfBrick())
								{
									num39 = -1;
								}
								int num40 = Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type;
								int num41 = Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type;
								int num42 = Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
								int num43 = Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].type;
								int num44 = Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
								int num45 = Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].type;
								if (!Main.tile[Player.tileTargetX, Player.tileTargetY + 1].nactive())
								{
									num39 = -1;
								}
								if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY].nactive())
								{
									num40 = -1;
								}
								if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY].nactive())
								{
									num41 = -1;
								}
								if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].nactive())
								{
									num42 = -1;
								}
								if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].nactive())
								{
									num43 = -1;
								}
								if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY + 1].nactive())
								{
									num44 = -1;
								}
								if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].nactive())
								{
									num45 = -1;
								}
								if (num39 >= 0 && Main.tileSolid[num39] && (!Main.tileNoAttach[num39] || num39 == 19))
								{
									flag3 = true;
								}
								else if (num40 >= 0 && Main.tileSolid[num40] && !Main.tileNoAttach[num40] || num40 == 5 && num42 == 5 && num44 == 5 || num40 == 124)
								{
									flag3 = true;
								}
								else if (num41 >= 0 && Main.tileSolid[num41] && !Main.tileNoAttach[num41] || num41 == 5 && num43 == 5 && num45 == 5 || num41 == 124)
								{
									flag3 = true;
								}
							}
							else
							{
								flag3 = true;
							}
						}
						else if (this.inventory[this.selectedItem].createTile == 78 || this.inventory[this.selectedItem].createTile == 98 || this.inventory[this.selectedItem].createTile == 100 || this.inventory[this.selectedItem].createTile == 173 || this.inventory[this.selectedItem].createTile == 174 || this.inventory[this.selectedItem].createTile == 324)
						{
							if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].nactive() && (Main.tileSolid[Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type] || Main.tileTable[Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type]))
							{
								flag3 = true;
							}
						}
						else if (this.inventory[this.selectedItem].createTile == 13 || this.inventory[this.selectedItem].createTile == 29 || this.inventory[this.selectedItem].createTile == 33 || this.inventory[this.selectedItem].createTile == 49 || this.inventory[this.selectedItem].createTile == 50 || this.inventory[this.selectedItem].createTile == 103)
						{
							if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].nactive() && Main.tileTable[Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type])
							{
								flag3 = true;
							}
						}
						else if (this.inventory[this.selectedItem].createTile == 275 || this.inventory[this.selectedItem].createTile == 276 || this.inventory[this.selectedItem].createTile == 277)
						{
							flag3 = true;
						}
						else if (this.inventory[this.selectedItem].createTile != 51 && this.inventory[this.selectedItem].createTile != 330 && this.inventory[this.selectedItem].createTile != 331 && this.inventory[this.selectedItem].createTile != 332 && this.inventory[this.selectedItem].createTile != 333 && this.inventory[this.selectedItem].createTile != 336 && this.inventory[this.selectedItem].createTile != 340 && this.inventory[this.selectedItem].createTile != 342 && this.inventory[this.selectedItem].createTile != 341 && this.inventory[this.selectedItem].createTile != 343 && this.inventory[this.selectedItem].createTile != 344 && this.inventory[this.selectedItem].createTile != 379 && this.inventory[this.selectedItem].createTile != 351)
						{
							if (this.inventory[this.selectedItem].createTile != 314)
							{
								Tile tile = Main.tile[Player.tileTargetX - 1, Player.tileTargetY];
								Tile tile1 = Main.tile[Player.tileTargetX + 1, Player.tileTargetY];
								Tile tile2 = Main.tile[Player.tileTargetX, Player.tileTargetY - 1];
								Tile tile3 = Main.tile[Player.tileTargetX, Player.tileTargetY + 1];
								if (tile1.active() && (Main.tileSolid[tile1.type] || Main.tileRope[tile1.type] || tile1.type == 314) || tile1.wall > 0 || tile.active() && (Main.tileSolid[tile.type] || Main.tileRope[tile.type] || tile.type == TileID.MinecartTrack) || tile.wall > 0 || tile3.active() && (Main.tileSolid[tile3.type] || tile3.type == 124 || Main.tileRope[tile3.type] || tile3.type == 314) || tile3.wall > 0 || tile2.active() && (Main.tileSolid[tile2.type] || tile2.type == 124 || Main.tileRope[tile2.type] || tile2.type == 314) || tile2.wall > 0)
								{
									flag3 = true;
								}
							}
							else
							{
								for (int j = Player.tileTargetX - 1; j <= Player.tileTargetX + 1; j++)
								{
									int num46 = Player.tileTargetY - 1;
									while (num46 <= Player.tileTargetY + 1)
									{
										Tile tile4 = Main.tile[j, num46];
										if (tile4.active() || tile4.wall > 0)
										{
											flag3 = true;
											break;
										}
										else
										{
											num46++;
										}
									}
								}
							}
						}
						else if (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active() || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active() || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active() || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active() || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0)
						{
							flag3 = true;
						}
						if (this.inventory[this.selectedItem].type == 213 && Main.tile[Player.tileTargetX, Player.tileTargetY].active())
						{
							int num47 = Player.tileTargetX;
							int num48 = Player.tileTargetY;
							if (Main.tile[num47, num48].type == TileID.Plants || Main.tile[num47, num48].type == TileID.Plants2 || Main.tile[num47, num48].type == TileID.BloomingHerbs)
							{
								WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
								if (!Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.netMode == 1)
								{
									NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
								}
							}
							else if (Main.tile[num47, num48].type == TileID.MatureHerbs)
							{
								bool flag5 = false;
								int num49 = Main.tile[num47, num48].frameX / 18;
								if (num49 == 0 && Main.dayTime)
								{
									flag5 = true;
								}
								if (num49 == 1 && !Main.dayTime)
								{
									flag5 = true;
								}
								if (num49 == 3 && !Main.dayTime && (Main.bloodMoon || Main.moonPhase == 0))
								{
									flag5 = true;
								}
								if (num49 == 4 && (Main.raining || Main.cloudAlpha > 0f))
								{
									flag5 = true;
								}
								if (num49 == 5 && !Main.raining && Main.dayTime && Main.time > 40500)
								{
									flag5 = true;
								}
								if (flag5)
								{
									WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
									NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
								}
							}
						}
						if (Main.tileAlch[this.inventory[this.selectedItem].createTile])
						{
							flag3 = true;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].active() && (Main.tileCut[Main.tile[Player.tileTargetX, Player.tileTargetY].type] || TileID.Sets.BreakableWhenPlacing[Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tile[Player.tileTargetX, Player.tileTargetY].type >= 373 && Main.tile[Player.tileTargetX, Player.tileTargetY].type <= 375))
						{
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == this.inventory[this.selectedItem].createTile)
							{
								flag3 = false;
							}
							else if ((Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type == 78 || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type == 380) && (Main.tile[Player.tileTargetX, Player.tileTargetY].type != 3 && Main.tile[Player.tileTargetX, Player.tileTargetY].type != 73 || !Main.tileAlch[this.inventory[this.selectedItem].createTile]))
							{
								flag3 = false;
							}
							else
							{
								WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
								if (!Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.netMode == 1)
								{
									NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 4, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
								}
							}
						}
						if (!flag3 && this.inventory[this.selectedItem].createTile == 19)
						{
							for (int k = Player.tileTargetX - 1; k <= Player.tileTargetX + 1; k++)
							{
								int num50 = Player.tileTargetY - 1;
								while (num50 <= Player.tileTargetY + 1)
								{
									if (!Main.tile[k, num50].active())
									{
										num50++;
									}
									else
									{
										flag3 = true;
										break;
									}
								}
							}
						}
					}
					else
					{
						flag4 = true;
						flag3 = TileObject.CanPlace(Player.tileTargetX, Player.tileTargetY, (int)this.inventory[this.selectedItem].createTile, this.inventory[this.selectedItem].placeStyle, this.direction, out tileObject, false);
					}
					if (flag3)
					{
						int num51 = this.inventory[this.selectedItem].placeStyle;
						if (!flag4)
						{
							if (this.inventory[this.selectedItem].createTile == 36)
							{
								num51 = Main.rand.Next(7);
							}
							if (this.inventory[this.selectedItem].createTile == 212 && this.direction > 0)
							{
								num51 = 1;
							}
							if (this.inventory[this.selectedItem].createTile == 141)
							{
								num51 = Main.rand.Next(2);
							}
							if (this.inventory[this.selectedItem].createTile == 128 || this.inventory[this.selectedItem].createTile == 269 || this.inventory[this.selectedItem].createTile == 334)
							{
								num51 = (this.direction >= 0 ? 1 : -1);
							}
							if (this.inventory[this.selectedItem].createTile == 241 && this.inventory[this.selectedItem].placeStyle == 0)
							{
								num51 = Main.rand.Next(0, 9);
							}
							if (this.inventory[this.selectedItem].createTile == 35 && this.inventory[this.selectedItem].placeStyle == 0)
							{
								num51 = Main.rand.Next(9);
							}
						}
						if (this.inventory[this.selectedItem].createTile == 314 && num51 == 2 && this.direction == 1)
						{
							num51++;
						}
						int[,] numArray = new int[11, 11];
						if (this.autoPaint)
						{
							for (int l = 0; l < 11; l++)
							{
								for (int m = 0; m < 11; m++)
								{
									int num52 = Player.tileTargetX - 5 + l;
									int num53 = Player.tileTargetY - 5 + m;
									if (!Main.tile[num52, num53].active())
									{
										numArray[l, m] = -1;
									}
									else
									{
										numArray[l, m] = Main.tile[num52, num53].type;
									}
								}
							}
						}
						bool flag6 = false;
						if (!flag4)
						{
							flag = WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createTile, false, flag6, this.whoAmI, num51);
						}
						else
						{
							flag = TileObject.Place(tileObject);
							WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
						}
						if (this.inventory[this.selectedItem].type == 213 && !flag && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 1 && Main.tile[Player.tileTargetX, Player.tileTargetY].active())
						{
							int key = 0;
							int value = 0;
							Point tileCoordinates = base.Center.ToTileCoordinates();
							Dictionary<ushort, int> nums = new Dictionary<ushort, int>();
							Point point = new Point(tileCoordinates.X - 25, tileCoordinates.Y - 25);
							Shapes.Rectangle rectangle = new Shapes.Rectangle(50, 50);
							ushort[] numArray1 = new ushort[] { 182, 180, 179, 183, 181, 381 };
							WorldUtils.Gen(point, rectangle, (new Actions.TileScanner(numArray1)).Output(nums));
							foreach (KeyValuePair<ushort, int> keyValuePair in nums)
							{
								if (keyValuePair.Value <= value)
								{
									continue;
								}
								value = keyValuePair.Value;
								key = keyValuePair.Key;
							}
							if (value == 0)
							{
								Random random = Main.rand;
								int[] numArray2 = new int[] { 182, 180, 179, 183, 181 };
								key = Terraria.Utils.SelectRandom<int>(random, numArray2);
							}
							if (key != 0)
							{
								Main.tile[Player.tileTargetX, Player.tileTargetY].type = (ushort)key;
								WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
								flag = true;
							}
						}
						if (flag)
						{
							this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.tileSpeed);
							if (!flag4)
							{
								NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 1, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.inventory[this.selectedItem].createTile, num51, 0, 0);
								if (this.inventory[this.selectedItem].createTile == 15)
								{
									if (this.direction == 1)
									{
										Tile tile5 = Main.tile[Player.tileTargetX, Player.tileTargetY];
										tile5.frameX = (short)(tile5.frameX + 18);
										Tile tile6 = Main.tile[Player.tileTargetX, Player.tileTargetY - 1];
										tile6.frameX = (short)(tile6.frameX + 18);
									}
									if (Main.netMode == 1)
									{
										NetMessage.SendTileSquare(-1, Player.tileTargetX - 1, Player.tileTargetY - 1, 3);
									}
								}
								else if ((this.inventory[this.selectedItem].createTile == 79 || this.inventory[this.selectedItem].createTile == 90) && Main.netMode == 1)
								{
									NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 5);
								}
							}
							else
							{
								TileObjectData.CallPostPlacementPlayerHook(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createTile, num51, this.direction, tileObject);
								if (Main.netMode == 1 && !Main.tileContainer[this.inventory[this.selectedItem].createTile])
								{
									NetMessage.SendObjectPlacment(-1, Player.tileTargetX, Player.tileTargetY, tileObject.type, tileObject.style, tileObject.alternate, tileObject.random, this.direction);
								}
							}
							if (this.inventory[this.selectedItem].createTile == 137)
							{
								if (this.direction == 1)
								{
									Tile tile7 = Main.tile[Player.tileTargetX, Player.tileTargetY];
									tile7.frameX = (short)(tile7.frameX + 18);
								}
								if (Main.netMode == 1)
								{
									NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 1);
								}
							}
							if (this.inventory[this.selectedItem].createTile == 19 && Main.smartDigEnabled)
							{
								int num54 = Player.tileTargetX;
								int num55 = Player.tileTargetY;
								int num56 = -1;
								int num57 = 0;
								int num58 = 0;
								bool flag7 = true;
								for (int n = -1; n < 2; n++)
								{
									for (int o = -1; o < 2; o++)
									{
										if ((n != 0 || o != 0) && Main.tile[num54 + n, num55 + o].type == 19)
										{
											flag7 = false;
										}
									}
								}
								if (!flag7)
								{
									Tile tile8 = Main.tile[num54 - 1, num55 - 1];
									if (tile8.active() && tile8.type == 19 && tile8.slope() != 2)
									{
										num57++;
									}
									tile8 = Main.tile[num54 - 1, num55 + 1];
									if (tile8.active() && tile8.type == 19 && tile8.slope() != 1)
									{
										num58++;
									}
									tile8 = Main.tile[num54 + 1, num55 - 1];
									if (tile8.active() && tile8.type == 19 && tile8.slope() != 1)
									{
										num58++;
									}
									tile8 = Main.tile[num54 + 1, num55 + 1];
									if (tile8.active() && tile8.type == 19 && tile8.slope() != 2)
									{
										num57++;
									}
									tile8 = Main.tile[num54 - 1, num55];
									if (WorldGen.SolidTile(tile8))
									{
										num57++;
										if (tile8.type == 19 && tile8.slope() == 0)
										{
											num57++;
										}
									}
									tile8 = Main.tile[num54 + 1, num55];
									if (WorldGen.SolidTile(tile8))
									{
										num58++;
										if (tile8.type == 19 && tile8.slope() == 0)
										{
											num58++;
										}
									}
									if (num57 > num58)
									{
										num56 = 1;
									}
									else if (num58 > num57)
									{
										num56 = 2;
									}
									tile8 = Main.tile[num54 - 1, num55];
									if (tile8.active() && tile8.type == 19)
									{
										num56 = 0;
									}
									tile8 = Main.tile[num54 + 1, num55];
									if (tile8.active() && tile8.type == 19)
									{
										num56 = 0;
									}
									int num59 = 0;
									int num60 = 0;
									if (num56 == -1)
									{
										num56 = 0;
										int num61 = 0;
										num59 = -1;
										tile8 = Main.tile[num54 + num59, num55];
										if (tile8.active() && tile8.type == 19 && tile8.slope() != 0)
										{
											int directionInt = (tile8.slope() == 1).ToDirectionInt() * num59;
											num56 = (directionInt == -1 ? 0 : (int)tile8.slope());
											bool flag8 = true;
											if (Main.tile[num54 + num59 * 2, num55 + directionInt].active() && Main.tile[num54 + num59 * 2, num55].type == 19 && num56 == Main.tile[num54 + num59 * 2, num55 + directionInt].slope())
											{
												flag8 = false;
											}
											if (Main.tile[num54, num55 - directionInt].active() && Main.tile[num54, num55 - directionInt].type == 19 && tile8.slope() == Main.tile[num54, num55 - directionInt].slope())
											{
												flag8 = false;
											}
											if (flag8)
											{
												WorldGen.SlopeTile(num54 + num59, num55, num56);
												num61 = tile8.slope();
												if (Main.netMode == 1)
												{
													NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 14, (float)(num54 + num59), (float)num55, (float)num61, 0, 0, 0);
												}
											}
										}
										num59 = 1;
										num60 = 0;
										tile8 = Main.tile[num54 + num59, num55 + num60];
										if (tile8.active() && tile8.type == 19 && tile8.slope() != 0)
										{
											int directionInt1 = (tile8.slope() == 1).ToDirectionInt() * num59;
											num56 = (directionInt1 == -1 ? 0 : (int)tile8.slope());
											bool flag9 = true;
											if (Main.tile[num54 + num59 * 2, num55 + directionInt1].active() && Main.tile[num54 + num59 * 2, num55].type == 19 && num56 == Main.tile[num54 + num59 * 2, num55 + directionInt1].slope())
											{
												flag9 = false;
											}
											if (Main.tile[num54, num55 - directionInt1].active() && Main.tile[num54, num55 - directionInt1].type == 19 && tile8.slope() == Main.tile[num54, num55 - directionInt1].slope())
											{
												flag9 = false;
											}
											if (flag9)
											{
												WorldGen.SlopeTile(num54 + num59, num55, num56);
												num61 = tile8.slope();
												if (Main.netMode == 1)
												{
													NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 14, (float)(num54 + num59), (float)num55, (float)num61, 0, 0, 0);
												}
											}
										}
										if (num57 == num58 && WorldGen.PlatformProperSides(num54, num55, false) == 0)
										{
											tile8 = Main.tile[num54, num55 + 1];
											if (tile8.active() && !tile8.halfBrick() && tile8.slope() == 0 && Main.tileSolid[tile8.type])
											{
												num56 = (this.direction == 1 ? 2 : 1);
												WorldGen.SlopeTile(num54, num55, num56);
												num61 = Main.tile[num54, num55].slope();
												if (Main.netMode == 1)
												{
													NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 14, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)num61, 0, 0, 0);
												}
											}
										}
									}
									else
									{
										WorldGen.SlopeTile(num54, num55, num56);
										int num62 = Main.tile[num54, num55].slope();
										if (Main.netMode == 1)
										{
											NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 14, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)num62, 0, 0, 0);
										}
										if (num56 != 1)
										{
											num59 = 1;
											num60 = -1;
										}
										else
										{
											num59 = -1;
											num60 = -1;
										}
										tile8 = Main.tile[num54 + num59, num55 + num60];
										if (tile8.active() && tile8.type == 19 && tile8.slope() == 0 && (!Main.tile[num54 + num59 + num59, num55 + num60].active() || Main.tile[num54 + num59 + num59, num55 + num60].type != 19 || !Main.tile[num54 + num59 + num59, num55 + num60].halfBrick()))
										{
											WorldGen.SlopeTile(num54 + num59, num55 + num60, num56);
											num62 = tile8.slope();
											if (Main.netMode == 1)
											{
												NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 14, (float)(num54 + num59), (float)(num55 + num60), (float)num62, 0, 0, 0);
											}
										}
										if (num56 != 1)
										{
											num59 = -1;
											num60 = 1;
										}
										else
										{
											num59 = 1;
											num60 = 1;
										}
										tile8 = Main.tile[num54 + num59, num55 + num60];
										if (tile8.active() && tile8.type == 19 && tile8.slope() == 0 && WorldGen.PlatformProperSides(num54 + num59, num55 + num60, true) <= 0)
										{
											WorldGen.SlopeTile(num54 + num59, num55 + num60, num56);
											num62 = tile8.slope();
											if (Main.netMode == 1)
											{
												NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 14, (float)(num54 + num59), (float)(num55 + num60), (float)num62, 0, 0, 0);
											}
										}
									}
								}
							}
							if (Main.tileSolid[this.inventory[this.selectedItem].createTile] && this.inventory[this.selectedItem].createTile != 19)
							{
								int num63 = Player.tileTargetX;
								int num64 = Player.tileTargetY + 1;
								if (Main.tile[num63, num64] != null && Main.tile[num63, num64].type != TileID.Platforms && (Main.tile[num63, num64].topSlope() || Main.tile[num63, num64].halfBrick()))
								{
									WorldGen.SlopeTile(num63, num64, 0);
									if (Main.netMode == 1)
									{
										NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 14, (float)num63, (float)num64, 0f, 0, 0, 0);
									}
								}
								num63 = Player.tileTargetX;
								num64 = Player.tileTargetY - 1;
								if (Main.tile[num63, num64] != null && Main.tile[num63, num64].type != TileID.Platforms && Main.tile[num63, num64].bottomSlope())
								{
									WorldGen.SlopeTile(num63, num64, 0);
									if (Main.netMode == 1)
									{
										NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 14, (float)num63, (float)num64, 0f, 0, 0, 0);
									}
								}
							}
							if (Main.tileSolid[this.inventory[this.selectedItem].createTile])
							{
								for (int p = Player.tileTargetX - 1; p <= Player.tileTargetX + 1; p++)
								{
									for (int q = Player.tileTargetY - 1; q <= Player.tileTargetY + 1; q++)
									{
										if (Main.tile[p, q].active() && this.inventory[this.selectedItem].createTile != Main.tile[p, q].type && (Main.tile[p, q].type == TileID.Grass || Main.tile[p, q].type == TileID.CorruptGrass || Main.tile[p, q].type == TileID.JungleGrass || Main.tile[p, q].type == TileID.MushroomGrass || Main.tile[p, q].type == TileID.HallowedGrass || Main.tile[p, q].type == TileID.FleshGrass))
										{
											bool flag10 = true;
											for (int r = p - 1; r <= p + 1; r++)
											{
												for (int s = q - 1; s <= q + 1; s++)
												{
													if (!WorldGen.SolidTile(r, s))
													{
														flag10 = false;
													}
												}
											}
											if (flag10)
											{
												WorldGen.KillTile(p, q, true, false, false);
												if (Main.netMode == 1)
												{
													NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)p, (float)q, 1f, 0, 0, 0);
												}
											}
										}
									}
								}
							}
							if (this.autoPaint)
							{
								for (int t = 0; t < 11; t++)
								{
									for (int u = 0; u < 11; u++)
									{
										int num65 = Player.tileTargetX - 5 + t;
										int num66 = Player.tileTargetY - 5 + u;
										if ((Main.tile[num65, num66].active() || numArray[t, u] != -1) && (!Main.tile[num65, num66].active() || numArray[t, u] != Main.tile[num65, num66].type))
										{
											int num67 = -1;
											int num68 = -1;
											int num69 = 0;
											while (num69 < 58)
											{
												if (this.inventory[num69].stack <= 0 || this.inventory[num69].paint <= 0)
												{
													num69++;
												}
												else
												{
													num67 = this.inventory[num69].paint;
													num68 = num69;
													break;
												}
											}
											if (num67 > 0 && Main.tile[num65, num66].color() != num67 && WorldGen.paintTile(num65, num66, (byte)num67, true))
											{
												int num70 = num68;
												Item item2 = this.inventory[num70];
												item2.stack = item2.stack - 1;
												if (this.inventory[num70].stack <= 0)
												{
													this.inventory[num70].SetDefaults(0, false);
												}
												this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.tileSpeed);
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
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem && (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active() || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active() || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active() || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active() || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0) && Main.tile[Player.tileTargetX, Player.tileTargetY].wall != this.inventory[this.selectedItem].createWall)
				{
					if (Main.tile[Player.tileTargetX, Player.tileTargetY].wall != 0 && WorldGen.NearFriendlyWall(Player.tileTargetX, Player.tileTargetY))
					{
						WorldGen.KillWall(Player.tileTargetX, Player.tileTargetY, false);
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].wall == 0 && Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 2, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
						}
						if (this.inventory[this.selectedItem].consumable)
						{
							Item item3 = this.inventory[this.selectedItem];
							item3.stack = item3.stack + 1;
						}
						this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.wallSpeed);
						return;
					}
					WorldGen.PlaceWall(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createWall, false);
					if (Main.tile[Player.tileTargetX, Player.tileTargetY].wall == this.inventory[this.selectedItem].createWall)
					{
						this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.wallSpeed);
						if (Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 3, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.inventory[this.selectedItem].createWall, 0, 0, 0);
						}
						if (this.inventory[this.selectedItem].stack > 1)
						{
							int num71 = this.inventory[this.selectedItem].createWall;
							for (int v = 0; v < 4; v++)
							{
								int num72 = Player.tileTargetX;
								int num73 = Player.tileTargetY;
								if (v == 0)
								{
									num72--;
								}
								if (v == 1)
								{
									num72++;
								}
								if (v == 2)
								{
									num73--;
								}
								if (v == 3)
								{
									num73++;
								}
								if (Main.tile[num72, num73].wall == WallID.None)
								{
									int num74 = 0;
									for (int w = 0; w < 4; w++)
									{
										int num75 = num72;
										int num76 = num73;
										if (w == 0)
										{
											num75--;
										}
										if (w == 1)
										{
											num75++;
										}
										if (w == 2)
										{
											num76--;
										}
										if (w == 3)
										{
											num76++;
										}
										if (Main.tile[num75, num76].wall == num71)
										{
											num74++;
										}
									}
									if (num74 == 4)
									{
										WorldGen.PlaceWall(num72, num73, num71, false);
										if (Main.tile[num72, num73].wall == num71)
										{
											Item item4 = this.inventory[this.selectedItem];
											item4.stack = item4.stack - 1;
											if (this.inventory[this.selectedItem].stack == 0)
											{
												this.inventory[this.selectedItem].SetDefaults(0, false);
											}
											if (Main.netMode == 1)
											{
												NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 3, (float)num72, (float)num73, (float)num71, 0, 0, 0);
											}
											if (this.autoPaint)
											{
												int num77 = num72;
												int num78 = num73;
												int num79 = -1;
												int num80 = -1;
												int num81 = 0;
												while (num81 < 58)
												{
													if (this.inventory[num81].stack <= 0 || this.inventory[num81].paint <= 0)
													{
														num81++;
													}
													else
													{
														num79 = this.inventory[num81].paint;
														num80 = num81;
														break;
													}
												}
												if (num79 > 0 && Main.tile[num77, num78].wallColor() != num79 && WorldGen.paintWall(num77, num78, (byte)num79, true))
												{
													int num82 = num80;
													Item item5 = this.inventory[num82];
													item5.stack = item5.stack - 1;
													if (this.inventory[num82].stack <= 0)
													{
														this.inventory[num82].SetDefaults(0, false);
													}
													this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.wallSpeed);
												}
											}
										}
									}
								}
							}
						}
						if (this.autoPaint)
						{
							int num83 = Player.tileTargetX;
							int num84 = Player.tileTargetY;
							int num85 = -1;
							int num86 = -1;
							int num87 = 0;
							while (num87 < 58)
							{
								if (this.inventory[num87].stack <= 0 || this.inventory[num87].paint <= 0)
								{
									num87++;
								}
								else
								{
									num85 = this.inventory[num87].paint;
									num86 = num87;
									break;
								}
							}
							if (num85 > 0 && Main.tile[num83, num84].wallColor() != num85 && WorldGen.paintWall(num83, num84, (byte)num85, true))
							{
								int num88 = num86;
								Item item6 = this.inventory[num88];
								item6.stack = item6.stack - 1;
								if (this.inventory[num88].stack <= 0)
								{
									this.inventory[num88].SetDefaults(0, false);
								}
								this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.wallSpeed);
							}
						}
					}
				}
			}
		}

		public void PlaceWeapon(int x, int y)
		{
			if (!Main.tile[x, y].active() || Main.tile[x, y].type != TileID.WeaponsRack)
			{
				return;
			}
			int i = Main.tile[x, y].frameY;
			int num = 1;
			for (i = i / 18; num > i; i = i / 18)
			{
				y++;
				i = Main.tile[x, y].frameY;
			}
			while (num < i)
			{
				y--;
				i = Main.tile[x, y].frameY;
				i = i / 18;
			}
			int num1 = Main.tile[x, y].frameX;
			int num2 = 0;
			while (num1 >= 5000)
			{
				num1 = num1 - 5000;
				num2++;
			}
			if (num2 != 0)
			{
				num1 = (num2 - 1) * 18;
			}
			bool flag = false;
			if (num1 >= 54)
			{
				num1 = num1 - 54;
				flag = true;
			}
			x = x - num1 / 18;
			int num3 = Main.tile[x, y].frameX;
			WorldGen.KillTile(x, y, true, false, false);
			if (Main.netMode == 1)
			{
				NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)x, (float)y, 1f, 0, 0, 0);
			}
			if (Main.netMode == 1)
			{
				NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)(x + 1), (float)y, 1f, 0, 0, 0);
			}
			while (num3 >= 5000)
			{
				num3 = num3 - 5000;
			}
			Main.blockMouse = true;
			int num4 = 5000;
			int num5 = 10000;
			if (flag)
			{
				num4 = 20000;
				num5 = 25000;
			}
			Main.tile[x, y].frameX = (short)(this.inventory[this.selectedItem].netID + num4 + 100);
			Main.tile[x + 1, y].frameX = (short)(this.inventory[this.selectedItem].prefix + num5);
			if (Main.netMode == 1)
			{
				NetMessage.SendTileSquare(-1, x, y, 1);
			}
			if (Main.netMode == 1)
			{
				NetMessage.SendTileSquare(-1, x + 1, y, 1);
			}
			Item item = this.inventory[this.selectedItem];
			item.stack = item.stack - 1;
			if (this.inventory[this.selectedItem].stack <= 0)
			{
				this.inventory[this.selectedItem].SetDefaults(0, false);
				Main.mouseItem.SetDefaults(0, false);
			}
			if (this.selectedItem == 58)
			{
				Main.mouseItem = this.inventory[this.selectedItem].Clone();
			}
			this.releaseUseItem = false;
			this.mouseInterface = true;
		}

		public void PlayerFrame()
		{
			if (this.swimTime > 0)
			{
				Player player = this;
				player.swimTime = player.swimTime - 1;
				if (!this.wet)
				{
					this.swimTime = 0;
				}
			}
			this.head = this.armor[0].headSlot;
			this.body = this.armor[1].bodySlot;
			this.legs = this.armor[2].legSlot;
			for (int i = 3; i < 8 + this.extraAccessorySlots; i++)
			{
				if (this.armor[i].shieldSlot == 5 && this.eocDash > 0)
				{
					this.shield = this.armor[i].shieldSlot;
				}
				if ((this.shield <= 0 || this.armor[i].frontSlot < 1 || this.armor[i].frontSlot > 4) && (this.front < 1 || this.front > 4 || this.armor[i].shieldSlot <= 0))
				{
					if (this.armor[i].wingSlot > 0)
					{
						if (this.hideVisual[i] && (this.velocity.Y == 0f || this.mount.Active))
						{
							continue;
						}
						this.wings = this.armor[i].wingSlot;
					}
					if (!this.hideVisual[i])
					{
						if (this.armor[i].stringColor > 0)
						{
							this.stringColor = this.armor[i].stringColor;
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
						}
						if (this.armor[i].type == 3580)
						{
							this.yoraiz0rEye = i - 2;
						}
						if (this.armor[i].type == 3581)
						{
							this.yoraiz0rDarkness = true;
						}
					}
				}
			}
			for (int j = 13; j < 18 + this.extraAccessorySlots; j++)
			{
				if (this.armor[j].stringColor > 0)
				{
					this.stringColor = this.armor[j].stringColor;
				}
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
					this.wings = this.armor[j].wingSlot;
				}
				if (this.armor[j].type == 3580)
				{
					this.yoraiz0rEye = j - 2;
				}
				if (this.armor[j].type == 3581)
				{
					this.yoraiz0rDarkness = true;
				}
			}
			if (this.armor[10].headSlot >= 0)
			{
				this.head = this.armor[10].headSlot;
			}
			if (this.armor[11].bodySlot >= 0)
			{
				this.body = this.armor[11].bodySlot;
			}
			if (this.armor[12].legSlot >= 0)
			{
				this.legs = this.armor[12].legSlot;
			}
			this.wearsRobe = false;
			int num1 = Player.SetMatch(1, this.body, this.Male, ref this.wearsRobe);
			if (num1 != -1)
			{
				this.legs = num1;
			}
			bool flag = false;
			num1 = Player.SetMatch(2, this.legs, this.Male, ref flag);
			if (num1 != -1)
			{
				this.legs = num1;
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
			if ((this.wereWolf || this.forceWerewolf) && !this.hideWolf)
			{
				this.legs = 20;
				this.body = 21;
				this.head = 38;
			}
			bool flag2 = this.wet && !this.lavaWet && (!this.mount.Active || this.mount.Type != 3);
			if (this.merman || this.forceMerman)
			{
				if (!this.hideMerman)
				{
					this.head = 39;
					this.legs = 21;
					this.body = 22;
				}
				if (flag2)
				{
					this.wings = 0;
				}
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
			if (this.head == 162 && this.body == 170 && this.legs == 105)
			{
				this.spiderArmor = true;
			}
			if ((this.head == 75 || this.head == 7) && this.body == 7 && this.legs == 7)
			{
				this.boneArmor = true;
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
			if (this.webbed || this.frozen || this.stoned)
			{
				return;
			}
			if (Main.gamePaused && !Main.gameMenu)
			{
				return;
			}
			if (this.head == 5 && this.body == 5 && this.legs == 5)
			{
				this.socialShadow = true;
			}
			if (this.head == 76 && this.body == 49 && this.legs == 45)
			{
				this.socialShadow = true;
			}
			if (this.head == 74 && this.body == 48 && this.legs == 44)
			{
				this.socialShadow = true;
			}
			if (this.body == 27 && this.head == 46 && this.legs == 26)
			{
				this.frostArmor = true;
			}
			this.bodyFrame.Width = 40;
			this.bodyFrame.Height = 56;
			this.legFrame.Width = 40;
			this.legFrame.Height = 56;
			this.bodyFrame.X = 0;
			this.legFrame.X = 0;
			if (this.mount.Active)
			{
				this.legFrameCounter = 0;
				this.legFrame.Y = this.legFrame.Height * 6;
				if (this.velocity.Y == 0f)
				{
					if (this.velocity.X != 0f)
					{
						this.mount.UpdateFrame(this, 1, this.velocity);
					}
					else
					{
						this.mount.UpdateFrame(this, 0, this.velocity);
					}
				}
				else if (this.mount.FlyTime > 0 && this.jump == 0 && this.controlJump && !this.mount.CanHover)
				{
					this.mount.UpdateFrame(this, 3, this.velocity);
				}
				else if (!this.wet)
				{
					this.mount.UpdateFrame(this, 2, this.velocity);
				}
				else
				{
					this.mount.UpdateFrame(this, 4, this.velocity);
				}
			}
			else if (this.swimTime > 0)
			{
				Player player1 = this;
				player1.legFrameCounter = player1.legFrameCounter + 2;
				while (this.legFrameCounter > 8)
				{
					Player player2 = this;
					player2.legFrameCounter = player2.legFrameCounter - 8;
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
				this.legFrameCounter = 0;
				this.legFrame.Y = this.legFrame.Height * 5;
				if (this.wings == 22 || this.wings == 28)
				{
					this.legFrame.Y = 0;
				}
			}
			else if (this.velocity.X == 0f)
			{
				this.legFrameCounter = 0;
				this.legFrame.Y = 0;
			}
			else if ((this.slippy || this.slippy2) && !this.controlLeft && !this.controlRight)
			{
				this.legFrameCounter = 0;
				this.legFrame.Y = 0;
			}
			else
			{
				Player player3 = this;
				player3.legFrameCounter = player3.legFrameCounter + (double)Math.Abs(this.velocity.X) * 1.3;
				while (this.legFrameCounter > 8)
				{
					Player player4 = this;
					player4.legFrameCounter = player4.legFrameCounter - 8;
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
			if (this.carpetFrame >= 0)
			{
				this.legFrameCounter = 0;
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
							this.itemRotation = 0.79f * (float)(-this.direction);
						}
					}
				}
				this.legFrameCounter = 0;
				this.legFrame.Y = 0;
			}
			if (this.itemAnimation <= 0 || this.inventory[this.selectedItem].useStyle == 10)
			{
				if (this.mount.Active)
				{
					this.bodyFrameCounter = 0;
					this.bodyFrame.Y = this.bodyFrame.Height * this.mount.BodyFrame;
					return;
				}
				if (this.pulley)
				{
					if (this.pulleyDir == 2)
					{
						this.bodyFrame.Y = this.bodyFrame.Height;
						return;
					}
					this.bodyFrame.Y = this.bodyFrame.Height * 2;
					return;
				}
				if (this.inventory[this.selectedItem].holdStyle == 1 && (!this.wet || !this.inventory[this.selectedItem].noWet))
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 3;
					return;
				}
				if (this.inventory[this.selectedItem].holdStyle == 2 && (!this.wet || !this.inventory[this.selectedItem].noWet))
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 2;
					return;
				}
				if (this.inventory[this.selectedItem].holdStyle == 3)
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 3;
					return;
				}
				if (this.grappling[0] < 0)
				{
					if (this.swimTime > 0)
					{
						if (this.swimTime > 20)
						{
							this.bodyFrame.Y = 0;
							return;
						}
						if (this.swimTime <= 10)
						{
							this.bodyFrame.Y = 0;
							return;
						}
						this.bodyFrame.Y = this.bodyFrame.Height * 5;
						return;
					}
					if (this.velocity.Y != 0f)
					{
						if (this.sliding)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 3;
						}
						else if (this.sandStorm || this.carpetFrame >= 0)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 6;
						}
						else if (this.eocDash > 0)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 6;
						}
						else if (this.wings <= 0)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 5;
						}
						else if (this.wings == 22 || this.wings == 28)
						{
							this.bodyFrame.Y = 0;
						}
						else if (this.velocity.Y <= 0f)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 6;
						}
						else if (!this.controlJump)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 5;
						}
						else
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 6;
						}
						this.bodyFrameCounter = 0;
						return;
					}
					if (this.velocity.X != 0f)
					{
						Player player5 = this;
						player5.bodyFrameCounter = player5.bodyFrameCounter + (double)Math.Abs(this.velocity.X) * 1.5;
						this.bodyFrame.Y = this.legFrame.Y;
						return;
					}
					this.bodyFrameCounter = 0;
					this.bodyFrame.Y = 0;
				}
				else
				{
					this.sandStorm = false;
					this.dJumpEffectCloud = false;
					this.dJumpEffectSandstorm = false;
					this.dJumpEffectBlizzard = false;
					this.dJumpEffectFart = false;
					this.dJumpEffectSail = false;
					this.dJumpEffectUnicorn = false;
					Vector2 vector215 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float x = 0f;
					float y = 0f;
					for (int o = 0; o < this.grapCount; o++)
					{
						x = x + (Main.projectile[this.grappling[o]].position.X + (float)(Main.projectile[this.grappling[o]].width / 2));
						y = y + (Main.projectile[this.grappling[o]].position.Y + (float)(Main.projectile[this.grappling[o]].height / 2));
					}
					x = x / (float)this.grapCount;
					y = y / (float)this.grapCount;
					x = x - vector215.X;
					y = y - vector215.Y;
					if (y >= 0f || Math.Abs(y) <= Math.Abs(x))
					{
						if (y <= 0f || Math.Abs(y) <= Math.Abs(x))
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 3;
							return;
						}
						this.bodyFrame.Y = this.bodyFrame.Height * 4;
						if (this.gravDir == -1f)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 2;
							return;
						}
					}
					else
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 2;
						if (this.gravDir == -1f)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 4;
							return;
						}
					}
				}
			}
			else
			{
				if (this.inventory[this.selectedItem].useStyle == 1 || this.inventory[this.selectedItem].type == 0)
				{
					if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
						return;
					}
					if ((double)this.itemAnimation >= (double)this.itemAnimationMax * 0.666)
					{
						this.bodyFrame.Y = this.bodyFrame.Height;
						return;
					}
					this.bodyFrame.Y = this.bodyFrame.Height * 2;
					return;
				}
				if (this.inventory[this.selectedItem].useStyle == 2)
				{
					if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.5)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
						return;
					}
					this.bodyFrame.Y = this.bodyFrame.Height * 2;
					return;
				}
				if (this.inventory[this.selectedItem].useStyle == 3)
				{
					if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.666)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
						return;
					}
					this.bodyFrame.Y = this.bodyFrame.Height * 3;
					return;
				}
				if (this.inventory[this.selectedItem].useStyle == 4)
				{
					this.bodyFrame.Y = this.bodyFrame.Height * 2;
					return;
				}
				if (this.inventory[this.selectedItem].useStyle == 5)
				{
					if (this.inventory[this.selectedItem].type == 281 || this.inventory[this.selectedItem].type == 986)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 2;
						return;
					}
					float single1 = this.itemRotation * (float)this.direction;
					this.bodyFrame.Y = this.bodyFrame.Height * 3;
					if ((double)single1 < -0.75)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 2;
						if (this.gravDir == -1f)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 4;
						}
					}
					if ((double)single1 > 0.6)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 4;
						if (this.gravDir == -1f)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 2;
							return;
						}
					}
				}
			}
		}

		private void pumpkinSword(int i, int dmg, float kb)
		{
			int x = Main.rand.Next(100, 300);
			int y = Main.rand.Next(100, 300);
			x = (Main.rand.Next(2) != 0 ? x + (Main.maxScreenW / 2 - x) : x - (Main.maxScreenW / 2 + x));
			y = (Main.rand.Next(2) != 0 ? y + (Main.maxScreenH / 2 - y) : y - (Main.maxScreenH / 2 + y));
			x = x + (int)this.position.X;
			y = y + (int)this.position.Y;
			float single = 8f;
			Vector2 vector2 = new Vector2((float)x, (float)y);
			float x1 = Main.npc[i].position.X - vector2.X;
			float y1 = Main.npc[i].position.Y - vector2.Y;
			float single1 = (float)Math.Sqrt((double)(x1 * x1 + y1 * y1));
			single1 = single / single1;
			x1 = x1 * single1;
			y1 = y1 * single1;
			Projectile.NewProjectile((float)x, (float)y, x1, y1, 321, dmg, kb, this.whoAmI, (float)i, 0f);
		}

		public void PutItemInInventory(int type, int selItem = -1)
		{
			for (int i = 0; i < 58; i++)
			{
				Item item = this.inventory[i];
				if (item.stack > 0 && item.type == type && item.stack < item.maxStack)
				{
					Item item1 = item;
					item1.stack = item1.stack + 1;
					return;
				}
			}
			if (selItem >= 0 && (this.inventory[selItem].type == 0 || this.inventory[selItem].stack <= 0))
			{
				this.inventory[selItem].SetDefaults(type, false);
				return;
			}
			Item x = new Item();
			x.SetDefaults(type, false);
			if (this.GetItem(this.whoAmI, x, false, false).stack <= 0)
			{
				x.position.X = base.Center.X - (float)(x.width / 2);
				x.position.Y = base.Center.Y - (float)(x.height / 2);
				x.active = true;
				ItemText.NewText(x, 0, false, false);
			}
			else
			{
				int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type, 1, false, 0, true);
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
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
				if (this.CountBuffs() == 22)
				{
					return;
				}
				if (this.inventory[i].stack > 0 && this.inventory[i].type > 0 && this.inventory[i].buffType > 0 && !this.inventory[i].summon && this.inventory[i].buffType != 90)
				{
					int num1 = this.inventory[i].buffType;
					bool flag = true;
					int num2 = 0;
					while (num2 < 22)
					{
						if (num1 == 27 && (this.buffType[num2] == num1 || this.buffType[num2] == BuffID.FairyRed || this.buffType[num2] == BuffID.FairyGreen))
						{
							flag = false;
							break;
						}
						else if (this.buffType[num2] == num1)
						{
							flag = false;
							break;
						}
						else if (!Main.meleeBuff[num1] || !Main.meleeBuff[this.buffType[num2]])
						{
							num2++;
						}
						else
						{
							flag = false;
							break;
						}
					}
					if (Main.lightPet[this.inventory[i].buffType] || Main.vanityPet[this.inventory[i].buffType])
					{
						for (int j = 0; j < 22; j++)
						{
							if (Main.lightPet[this.buffType[j]] && Main.lightPet[this.inventory[i].buffType])
							{
								flag = false;
							}
							if (Main.vanityPet[this.buffType[j]] && Main.vanityPet[this.inventory[i].buffType])
							{
								flag = false;
							}
						}
					}
					if (this.inventory[i].mana > 0 && flag)
					{
						if (this.statMana < (int)((float)this.inventory[i].mana * this.manaCost))
						{
							flag = false;
						}
						else
						{
							this.manaRegenDelay = (int)this.maxRegenDelay;
							Player player = this;
							player.statMana = player.statMana - (int)((float)this.inventory[i].mana * this.manaCost);
						}
					}
					if (this.whoAmI == Main.myPlayer && this.inventory[i].type == 603 && !Main.cEd)
					{
						flag = false;
					}
					if (num1 == 27)
					{
						num1 = Main.rand.Next(3);
						if (num1 == 0)
						{
							num1 = 27;
						}
						if (num1 == 1)
						{
							num1 = 101;
						}
						if (num1 == 2)
						{
							num1 = 102;
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
						this.AddBuff(num1, num3, true);
						if (this.inventory[i].consumable)
						{
							Item item = this.inventory[i];
							item.stack = item.stack - 1;
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
				Recipe.FindRecipes();
			}
		}

		public void QuickGrapple()
		{
			if (this.frozen || this.tongued || this.webbed || this.stoned)
			{
				return;
			}
			if (this.mount.Active)
			{
				this.mount.Dismount(this);
			}
			if (this.noItems)
			{
				return;
			}
			Item item = null;
			if (item == null && Main.projHook[this.miscEquips[4].shoot])
			{
				item = this.miscEquips[4];
			}
			if (item == null)
			{
				int num = 0;
				while (num < 58)
				{
					if (!Main.projHook[this.inventory[num].shoot])
					{
						num++;
					}
					else
					{
						item = this.inventory[num];
						break;
					}
				}
			}
			if (item == null)
			{
				return;
			}
			if (item.shoot == 73)
			{
				int num1 = 0;
				for (int i = 0; i < 1000; i++)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && (Main.projectile[i].type == ProjectileID.DualHookBlue || Main.projectile[i].type == ProjectileID.DualHookRed))
					{
						num1++;
					}
				}
				if (num1 > 1)
				{
					item = null;
				}
			}
			else if (item.shoot == 165)
			{
				int num2 = 0;
				for (int j = 0; j < 1000; j++)
				{
					if (Main.projectile[j].active && Main.projectile[j].owner == Main.myPlayer && Main.projectile[j].type == ProjectileID.Web)
					{
						num2++;
					}
				}
				if (num2 > 8)
				{
					item = null;
				}
			}
			else if (item.shoot == 372)
			{
				int num3 = 0;
				for (int k = 0; k < 1000; k++)
				{
					if (Main.projectile[k].active && Main.projectile[k].owner == Main.myPlayer && Main.projectile[k].type == ProjectileID.FishHook)
					{
						num3++;
					}
				}
				if (num3 > 2)
				{
					item = null;
				}
			}
			else if (item.shoot != 165)
			{
				int num4 = 0;
				while (num4 < 1000)
				{
					if (!Main.projectile[num4].active || Main.projectile[num4].owner != Main.myPlayer || Main.projectile[num4].type != item.shoot || Main.projectile[num4].ai[0] == 2f)
					{
						num4++;
					}
					else
					{
						item = null;
						break;
					}
				}
			}
			else
			{
				int num5 = 0;
				for (int l = 0; l < 1000; l++)
				{
					if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type >= ProjectileID.LunarHookSolar && Main.projectile[l].type <= ProjectileID.LunarHookStardust)
					{
						num5++;
					}
				}
				if (num5 > 4)
				{
					item = null;
				}
			}
			if (item != null)
			{
				if (Main.netMode == 1 && this.whoAmI == Main.myPlayer)
				{
					NetMessage.SendData((int)PacketTypes.NpcSpecial, -1, -1, "", this.whoAmI, 2f, 0f, 0f, 0, 0, 0);
				}
				int num6 = item.shoot;
				float single = item.shootSpeed;
				int num7 = item.damage;
				float single1 = item.knockBack;
				if (num6 == 13 || num6 == 32 || num6 == 315 || num6 >= 230 && num6 <= 235 || num6 == 331)
				{
					this.grappling[0] = -1;
					this.grapCount = 0;
					for (int m = 0; m < 1000; m++)
					{
						if (Main.projectile[m].active && Main.projectile[m].owner == this.whoAmI)
						{
							if (Main.projectile[m].type == ProjectileID.Hook)
							{
								Main.projectile[m].Kill();
							}
							if (Main.projectile[m].type == ProjectileID.CandyCaneHook)
							{
								Main.projectile[m].Kill();
							}
							if (Main.projectile[m].type == ProjectileID.BatHook)
							{
								Main.projectile[m].Kill();
							}
							if (Main.projectile[m].type >= ProjectileID.GemHookAmethyst && Main.projectile[m].type <= ProjectileID.GemHookDiamond)
							{
								Main.projectile[m].Kill();
							}
						}
					}
				}
				if (num6 == 256)
				{
					int num8 = 0;
					int num9 = -1;
					int num10 = 100000;
					for (int n = 0; n < 1000; n++)
					{
						if (Main.projectile[n].active && Main.projectile[n].owner == this.whoAmI && Main.projectile[n].type == ProjectileID.SkeletronHand)
						{
							num8++;
							if (Main.projectile[n].timeLeft < num10)
							{
								num9 = n;
								num10 = Main.projectile[n].timeLeft;
							}
						}
					}
					if (num8 > 1)
					{
						Main.projectile[num9].Kill();
					}
				}
				if (num6 == 73)
				{
					for (int o = 0; o < 1000; o++)
					{
						if (Main.projectile[o].active && Main.projectile[o].owner == this.whoAmI && Main.projectile[o].type == ProjectileID.DualHookBlue)
						{
							num6 = 74;
						}
					}
				}
				if (item.type == ItemID.LunarHook)
				{
					int num11 = -1;
					int num12 = -1;
					for (int p = 0; p < 1000; p++)
					{
						Projectile projectile = Main.projectile[p];
						if (projectile.active && projectile.owner == this.whoAmI && projectile.type >= ProjectileID.LunarHookSolar && projectile.type <= ProjectileID.LunarHookStardust && (num12 == -1 || num12 < projectile.timeLeft))
						{
							num11 = projectile.type;
							num12 = projectile.timeLeft;
						}
					}
					int num13 = num11;
					if (num13 != -1)
					{
						switch (num13)
						{
							case 646:
							{
								num6 = 647;
								goto Label0;
							}
							case 647:
							{
								num6 = 648;
								goto Label0;
							}
							case 648:
							{
								num6 = 649;
								goto Label0;
							}
							case 649:
							{
								break;
							}
							default:
							{
								goto Label0;
							}
						}
					}
					num6 = 646;
				}
			Label0:
				Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float x = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
				float y = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
				if (this.gravDir == -1f)
				{
					y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector2.Y;
				}
				float single2 = (float)Math.Sqrt((double)(x * x + y * y));
				if ((!float.IsNaN(x) || !float.IsNaN(y)) && (x != 0f || y != 0f))
				{
					single2 = single / single2;
				}
				else
				{
					x = (float)this.direction;
					y = 0f;
					single2 = single;
				}
				x = x * single2;
				y = y * single2;
				Projectile.NewProjectile(vector2.X, vector2.Y, x, y, num6, num7, single1, this.whoAmI, 0f, 0f);
			}
		}

		public void QuickHeal()
		{
			if (this.noItems)
			{
				return;
			}
			if (this.statLife == this.statLifeMax2 || this.potionDelay > 0)
			{
				return;
			}
			int num = this.statLifeMax2 - this.statLife;
			Item item = null;
			int num1 = -this.statLifeMax2;
			for (int i = 0; i < 58; i++)
			{
				Item item1 = this.inventory[i];
				if (item1.stack > 0 && item1.type > 0 && item1.potion && item1.healLife > 0)
				{
					int num2 = item1.healLife - num;
					if (num1 < 0)
					{
						if (num2 > num1)
						{
							item = item1;
							num1 = num2;
						}
					}
					else if (num2 < num1 && num2 >= 0)
					{
						item = item1;
						num1 = num2;
					}
				}
			}
			if (item == null)
			{
				return;
			}
			if (item.potion)
			{
				if (item.type != ItemID.RestorationPotion)
				{
					this.potionDelay = this.potionDelayTime;
					this.AddBuff(BuffID.PotionSickness, this.potionDelay, true);
				}
				else
				{
					this.potionDelay = this.restorationDelayTime;
					this.AddBuff(BuffID.PotionSickness, this.potionDelay, true);
				}
			}
			Player player = this;
			player.statLife = player.statLife + item.healLife;
			Player player1 = this;
			player1.statMana = player1.statMana + item.healMana;
			if (this.statLife > this.statLifeMax2)
			{
				this.statLife = this.statLifeMax2;
			}
			if (this.statMana > this.statManaMax2)
			{
				this.statMana = this.statManaMax2;
			}
			if (item.healLife > 0 && Main.myPlayer == this.whoAmI)
			{
				this.HealEffect(item.healLife, true);
			}
			if (item.healMana > 0 && Main.myPlayer == this.whoAmI)
			{
				this.ManaEffect(item.healMana);
			}
			Item item2 = item;
			item2.stack = item2.stack - 1;
			if (item.stack <= 0)
			{
				item.type = 0;
				item.name = "";
			}
			Recipe.FindRecipes();
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
					if (this.inventory[i].potion)
					{
						if (this.inventory[i].type != 227)
						{
							this.potionDelay = this.potionDelayTime;
							this.AddBuff(BuffID.PotionSickness, this.potionDelay, true);
						}
						else
						{
							this.potionDelay = this.restorationDelayTime;
							this.AddBuff(BuffID.PotionSickness, this.potionDelay, true);
						}
					}
					Player player = this;
					player.statLife = player.statLife + this.inventory[i].healLife;
					Player player1 = this;
					player1.statMana = player1.statMana + this.inventory[i].healMana;
					if (this.statLife > this.statLifeMax2)
					{
						this.statLife = this.statLifeMax2;
					}
					if (this.statMana > this.statManaMax2)
					{
						this.statMana = this.statManaMax2;
					}
					if (this.inventory[i].healLife > 0 && Main.myPlayer == this.whoAmI)
					{
						this.HealEffect(this.inventory[i].healLife, true);
					}
					if (this.inventory[i].healMana > 0)
					{
						this.AddBuff(BuffID.ManaSickness, Player.manaSickTime, true);
						if (Main.myPlayer == this.whoAmI)
						{
							this.ManaEffect(this.inventory[i].healMana);
						}
					}
					Item item = this.inventory[i];
					item.stack = item.stack - 1;
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

		public void QuickMount()
		{
			if (this.mount.Active)
			{
				this.mount.Dismount(this);
				return;
			}
			if (this.frozen || this.tongued || this.webbed || this.stoned || this.gravDir == -1f)
			{
				return;
			}
			if (this.noItems)
			{
				return;
			}
			Item item = null;
			if (item == null && this.miscEquips[3].mountType != -1 && !MountID.Sets.Cart[this.miscEquips[3].mountType])
			{
				item = this.miscEquips[3];
			}
			if (item == null)
			{
				int num = 0;
				while (num < 58)
				{
					if (this.inventory[num].mountType == -1 || MountID.Sets.Cart[this.inventory[num].mountType])
					{
						num++;
					}
					else
					{
						item = this.inventory[num];
						break;
					}
				}
			}
			if (item != null && item.mountType != -1 && this.mount.CanMount(item.mountType, this))
			{
				this.mount.SetMount(item.mountType, this, false);
			}
		}

		public void QuickSpawnItem(int item, int stack = 1)
		{
			int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item, stack, false, -1, false);
			if (Main.netMode == 1)
			{
				NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num, 1f, 0f, 0f, 0, 0, 0);
			}
		}

		public void QuickStackAllChests()
		{
			if (this.IsStackingItems())
			{
				return;
			}
			if (Main.netMode == 1)
			{
				for (int i = 10; i < 50; i++)
				{
					if (this.inventory[i].type > 0 && this.inventory[i].stack > 0 && !this.inventory[i].favorited)
					{
						NetMessage.SendData((int)PacketTypes.PlayerSlot, -1, -1, "", this.whoAmI, (float)i, (float)this.inventory[i].prefix, 0f, 0, 0, 0);
						NetMessage.SendData((int)PacketTypes.ForceItemIntoNearestChest, -1, -1, "", i, 0f, 0f, 0f, 0, 0, 0);
						this.inventoryChestStack[i] = true;
					}
				}
				return;
			}
			for (int j = 10; j < 50; j++)
			{
				if (this.inventory[j].type > 0 && this.inventory[j].stack > 0 && !this.inventory[j].favorited)
				{
					this.inventory[j] = Chest.PutItemInNearbyChest(this.inventory[j], base.Center);
				}
			}
		}

		public void RemoveSpawn()
		{
			this.SpawnX = -1;
			this.SpawnY = -1;
			for (int i = 0; i < 200; i++)
			{
				if (this.spN[i] == null)
				{
					return;
				}
				if (this.spN[i] == Main.worldName && this.spI[i] == Main.worldID)
				{
					for (int j = i; j < 199; j++)
					{
						this.spN[j] = this.spN[j + 1];
						this.spI[j] = this.spI[j + 1];
						this.spX[j] = this.spX[j + 1];
						this.spY[j] = this.spY[j + 1];
					}
					this.spN[199] = null;
					this.spI[199] = 0;
					this.spX[199] = 0;
					this.spY[199] = 0;
					return;
				}
			}
		}

		public void ResetEffects()
		{
			if (!this.extraAccessory || !Main.expertMode && !Main.gameMenu)
			{
				this.extraAccessorySlots = 0;
			}
			else
			{
				this.extraAccessorySlots = 1;
			}
			this.arcticDivingGear = false;
			this.strongBees = false;
			this.armorPenetration = 0;
			this.shroomiteStealth = false;
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
			this.thrownDamage = 1f;
			this.magicDamage = 1f;
			this.minionDamage = 1f;
			this.meleeCrit = 4;
			this.rangedCrit = 4;
			this.magicCrit = 4;
			this.thrownCrit = 4;
			this.thrownVelocity = 1f;
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
			this.thorns = 0f;
			this.aggro = 0;
			this.waterWalk = false;
			this.waterWalk2 = false;
			this.detectCreature = false;
			this.gravControl = false;
			this.bee = false;
			this.gravControl2 = false;
			this.statLifeMax2 = this.statLifeMax;
			this.statManaMax2 = this.statManaMax;
			this.ammoCost80 = false;
			this.ammoCost75 = false;
			this.thrownCost50 = false;
			this.thrownCost33 = false;
			this.manaRegenBuff = false;
			this.arrowDamage = 1f;
			this.bulletDamage = 1f;
			this.rocketDamage = 1f;
			this.yoraiz0rEye = 0;
			this.yoraiz0rDarkness = false;
			this.suspiciouslookingTentacle = false;
			this.crimsonHeart = false;
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
			this.zephyrfish = false;
			this.tiki = false;
			this.lizard = false;
			this.parrot = false;
			this.sapling = false;
			this.cSapling = false;
			this.truffle = false;
			this.yoyoGlove = false;
			this.counterWeight = 0;
			this.stringColor = 0;
			this.yoyoString = false;
			this.shadowDodge = false;
			this.palladiumRegen = false;
			this.chaosState = false;
			this.onHitDodge = false;
			this.onHitRegen = false;
			this.onHitPetal = false;
			this.iceBarrier = false;
			this.maxMinions = 1;
			this.ammoBox = false;
			this.ammoPotion = false;
			this.penguin = false;
			this.sporeSac = false;
			this.shinyStone = false;
			this.magicLantern = false;
			this.rabid = false;
			this.sunflower = false;
			this.wellFed = false;
			this.inferno = false;
			this.manaMagnet = false;
			this.lifeMagnet = false;
			this.lifeForce = false;
			this.dangerSense = false;
			this.endurance = 0f;
			this.calmed = false;
			this.beetleOrbs = 0;
			this.beetleBuff = false;
			this.miniMinotaur = false;
			this.goldRing = false;
			this.solarShields = 0;
			this.GoingDownWithGrapple = false;
			this.fishingSkill = 0;
			this.cratePotion = false;
			this.sonarPotion = false;
			this.accTackleBox = false;
			this.accFishingLine = false;
			this.accFishFinder = false;
			this.accWeatherRadio = false;
			this.accThirdEye = false;
			this.accJarOfSouls = false;
			this.accCalendar = false;
			this.accStopwatch = false;
			this.accOreFinder = false;
			this.accCritterGuide = false;
			this.accDreamCatcher = false;
			this.wallSpeed = 1f;
			this.tileSpeed = 1f;
			this.autoPaint = false;
			this.babyFaceMonster = false;
			this.manaSick = false;
			this.puppy = false;
			this.grinch = false;
			this.blackCat = false;
			this.spider = false;
			this.squashling = false;
			this.magicCuffs = false;
			this.coldDash = false;
			this.sailDash = false;
			this.cordage = false;
			this.magicQuiver = false;
			this.magmaStone = false;
			this.lavaRose = false;
			this.eyeSpring = false;
			this.snowman = false;
			this.scope = false;
			this.panic = false;
			this.brainOfConfusion = false;
			this.dino = false;
			this.crystalLeaf = false;
			this.pygmy = false;
			this.raven = false;
			this.slime = false;
			this.hornetMinion = false;
			this.impMinion = false;
			this.twinsMinion = false;
			this.spiderMinion = false;
			this.pirateMinion = false;
			this.sharknadoMinion = false;
			this.stardustMinion = false;
			this.stardustGuardian = false;
			this.stardustDragon = false;
			this.UFOMinion = false;
			this.DeadlySphereMinion = false;
			this.chilled = false;
			this.dazed = false;
			this.frozen = false;
			this.stoned = false;
			this.webbed = false;
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
			this.drippingSlime = false;
			this.burned = false;
			this.suffocating = false;
			this.onFire2 = false;
			this.onFrostBurn = false;
			this.frostBurn = false;
			this.noItems = false;
			this.blockRange = 0;
			this.pickSpeed = 1f;
			this.wereWolf = false;
			this.rulerGrid = false;
			this.rulerLine = false;
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
			this.kbBuff = false;
			this.starCloak = false;
			this.longInvince = false;
			this.pStone = false;
			this.manaFlower = false;
			this.crimsonRegen = false;
			this.ghostHeal = false;
			this.ghostHurt = false;
			this.turtleArmor = false;
			this.turtleThorns = false;
			this.spiderArmor = false;
			this.loveStruck = false;
			this.stinky = false;
			this.dryadWard = false;
			this.resistCold = false;
			this.electrified = false;
			this.moonLeech = false;
			this.headcovered = false;
			this.vortexDebuff = false;
			bool flag = false;
			this.setStardust = false;
			bool flag1 = flag;
			bool flag2 = flag1;
			this.setNebula = flag1;
			this.setVortex = flag2;
			int num1 = 0;
			int num2 = num1;
			this.nebulaLevelMana = num1;
			int num3 = num2;
			int num4 = num3;
			this.nebulaLevelLife = num3;
			this.nebulaLevelDamage = num4;
			this.ignoreWater = false;
			this.meleeEnchant = 0;
			this.discount = false;
			this.coins = false;
			this.doubleJumpSail = false;
			this.doubleJumpSandstorm = false;
			this.doubleJumpBlizzard = false;
			this.doubleJumpFart = false;
			this.doubleJumpUnicorn = false;
			this.paladinBuff = false;
			this.paladinGive = false;
			this.autoJump = false;
			this.justJumped = false;
			this.jumpSpeedBoost = 0f;
			this.extraFall = 0;
			if (this.phantasmTime > 0)
			{
				Player player = this;
				player.phantasmTime = player.phantasmTime - 1;
			}
			for (int i = 0; i < (int)this.npcTypeNoAggro.Length; i++)
			{
				this.npcTypeNoAggro[i] = false;
			}
			for (int j = 0; j < (int)this.ownedProjectileCounts.Length; j++)
			{
				this.ownedProjectileCounts[j] = 0;
			}
			if (this.whoAmI == Main.myPlayer)
			{
				Player.tileRangeX = 5;
				Player.tileRangeY = 4;
			}
			this.mount.CheckMountBuff(this);
		}

		public Vector2 RotatedRelativePoint(Vector2 pos, bool rotateForward = true)
		{
			Vector2 vector2 = this.position + this.fullRotationOrigin;
			Matrix matrix = Matrix.CreateRotationZ(this.fullRotation * (float)rotateForward.ToInt());
			pos = pos - (this.position + this.fullRotationOrigin);
			pos = Vector2.Transform(pos, matrix);
			return pos + vector2;
		}

		public void RotateRelativePoint(ref float x, ref float y)
		{
			Vector2 vector2 = this.RotatedRelativePoint(new Vector2(x, y), true);
			x = vector2.X;
			y = vector2.Y;
		}

		public static void SavePlayer(PlayerFileData playerFile, bool skipMapSave = false)
		{
			Stream memoryStream;
			Main.Achievements.Save();
			string path = playerFile.Path;
			Player player = playerFile.Player;
			if (!skipMapSave)
			{
				try
				{
					Directory.CreateDirectory(Main.PlayerPath);
				}
				catch (Exception ex)
				{
#if DEBUG
					Console.WriteLine(ex);
					System.Diagnostics.Debugger.Break();

#endif
				}
			}
			if (Main.ServerSideCharacter)
			{
				return;
			}
			if (path == null || path == "")
			{
				return;
			}
			if (FileUtilities.Exists(path))
			{
				FileUtilities.Copy(path, string.Concat(path, ".bak"), false, true);
			}
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			memoryStream = new FileStream(path, FileMode.Create);
			using (Stream stream = memoryStream)
			{
				using (CryptoStream cryptoStream = new CryptoStream(stream, rijndaelManaged.CreateEncryptor(Player.ENCRYPTION_KEY, Player.ENCRYPTION_KEY), CryptoStreamMode.Write))
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(cryptoStream))
					{
						binaryWriter.Write(Main.curRelease);
						playerFile.Metadata.Write(binaryWriter);
						binaryWriter.Write(player.name);
						binaryWriter.Write(player.difficulty);
						binaryWriter.Write(playerFile.GetPlayTime().Ticks);
						binaryWriter.Write(player.hair);
						binaryWriter.Write(player.hairDye);
						BitsByte bitsByte = 0;
						for (int i = 0; i < 8; i++)
						{
							bitsByte[i] = player.hideVisual[i];
						}
						binaryWriter.Write(bitsByte);
						bitsByte = 0;
						for (int j = 0; j < 2; j++)
						{
							bitsByte[j] = player.hideVisual[j + 8];
						}
						binaryWriter.Write(bitsByte);
						binaryWriter.Write(player.hideMisc);
						binaryWriter.Write((byte)player.skinVariant);
						binaryWriter.Write(player.statLife);
						binaryWriter.Write(player.statLifeMax);
						binaryWriter.Write(player.statMana);
						binaryWriter.Write(player.statManaMax);
						binaryWriter.Write(player.extraAccessory);
						binaryWriter.Write(player.taxMoney);
						binaryWriter.Write(player.hairColor.R);
						binaryWriter.Write(player.hairColor.G);
						binaryWriter.Write(player.hairColor.B);
						binaryWriter.Write(player.skinColor.R);
						binaryWriter.Write(player.skinColor.G);
						binaryWriter.Write(player.skinColor.B);
						binaryWriter.Write(player.eyeColor.R);
						binaryWriter.Write(player.eyeColor.G);
						binaryWriter.Write(player.eyeColor.B);
						binaryWriter.Write(player.shirtColor.R);
						binaryWriter.Write(player.shirtColor.G);
						binaryWriter.Write(player.shirtColor.B);
						binaryWriter.Write(player.underShirtColor.R);
						binaryWriter.Write(player.underShirtColor.G);
						binaryWriter.Write(player.underShirtColor.B);
						binaryWriter.Write(player.pantsColor.R);
						binaryWriter.Write(player.pantsColor.G);
						binaryWriter.Write(player.pantsColor.B);
						binaryWriter.Write(player.shoeColor.R);
						binaryWriter.Write(player.shoeColor.G);
						binaryWriter.Write(player.shoeColor.B);
						for (int k = 0; k < (int)player.armor.Length; k++)
						{
							if (player.armor[k].name == null)
							{
								player.armor[k].name = "";
							}
							binaryWriter.Write(player.armor[k].netID);
							binaryWriter.Write(player.armor[k].prefix);
						}
						for (int l = 0; l < (int)player.dye.Length; l++)
						{
							binaryWriter.Write(player.dye[l].netID);
							binaryWriter.Write(player.dye[l].prefix);
						}
						for (int m = 0; m < 58; m++)
						{
							if (player.inventory[m].name == null)
							{
								player.inventory[m].name = "";
							}
							binaryWriter.Write(player.inventory[m].netID);
							binaryWriter.Write(player.inventory[m].stack);
							binaryWriter.Write(player.inventory[m].prefix);
							binaryWriter.Write(player.inventory[m].favorited);
						}
						for (int n = 0; n < (int)player.miscEquips.Length; n++)
						{
							binaryWriter.Write(player.miscEquips[n].netID);
							binaryWriter.Write(player.miscEquips[n].prefix);
							binaryWriter.Write(player.miscDyes[n].netID);
							binaryWriter.Write(player.miscDyes[n].prefix);
						}
						for (int o = 0; o < 40; o++)
						{
							if (player.bank.item[o].name == null)
							{
								player.bank.item[o].name = "";
							}
							binaryWriter.Write(player.bank.item[o].netID);
							binaryWriter.Write(player.bank.item[o].stack);
							binaryWriter.Write(player.bank.item[o].prefix);
						}
						for (int p = 0; p < 40; p++)
						{
							if (player.bank2.item[p].name == null)
							{
								player.bank2.item[p].name = "";
							}
							binaryWriter.Write(player.bank2.item[p].netID);
							binaryWriter.Write(player.bank2.item[p].stack);
							binaryWriter.Write(player.bank2.item[p].prefix);
						}
						for (int q = 0; q < 22; q++)
						{
							if (!Main.buffNoSave[player.buffType[q]])
							{
								binaryWriter.Write(player.buffType[q]);
								binaryWriter.Write(player.buffTime[q]);
							}
							else
							{
								binaryWriter.Write(0);
								binaryWriter.Write(0);
							}
						}
						int num = 0;
						while (num < 200)
						{
							if (player.spN[num] != null)
							{
								binaryWriter.Write(player.spX[num]);
								binaryWriter.Write(player.spY[num]);
								binaryWriter.Write(player.spI[num]);
								binaryWriter.Write(player.spN[num]);
								num++;
							}
							else
							{
								binaryWriter.Write(-1);
								break;
							}
						}
						binaryWriter.Write(player.hbLocked);
						for (int r = 0; r < (int)player.hideInfo.Length; r++)
						{
							binaryWriter.Write(player.hideInfo[r]);
						}
						binaryWriter.Write(player.anglerQuestsFinished);
						binaryWriter.Flush();
						cryptoStream.FlushFinalBlock();
						stream.Flush();
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
			Item[] item = new Item[58];
			for (int i = 0; i < 58; i++)
			{
				item[i] = new Item();
				item[i] = this.inventory[i].Clone();
			}
			int num = price / 5;
			num = num * stack;
			if (num < 1)
			{
				num = 1;
			}
			bool flag = false;
			while (num >= 1000000)
			{
				if (!flag)
				{
					int num1 = -1;
					for (int j = 53; j >= 0; j--)
					{
						if (num1 == -1 && (this.inventory[j].type == 0 || this.inventory[j].stack == 0))
						{
							num1 = j;
						}
						while (this.inventory[j].type == 74 && this.inventory[j].stack < this.inventory[j].maxStack && num >= 1000000)
						{
							Item item1 = this.inventory[j];
							item1.stack = item1.stack + 1;
							num = num - 1000000;
							this.DoCoins(j);
							if (this.inventory[j].stack != 0 || num1 != -1)
							{
								continue;
							}
							num1 = j;
						}
					}
					if (num < 1000000)
					{
						continue;
					}
					if (num1 != -1)
					{
						this.inventory[num1].SetDefaults(74, false);
						num = num - 1000000;
					}
					else
					{
						flag = true;
					}
				}
				else
				{
					break;
				}
			}
			while (num >= 10000)
			{
				if (!flag)
				{
					int num2 = -1;
					for (int k = 53; k >= 0; k--)
					{
						if (num2 == -1 && (this.inventory[k].type == 0 || this.inventory[k].stack == 0))
						{
							num2 = k;
						}
						while (this.inventory[k].type == 73 && this.inventory[k].stack < this.inventory[k].maxStack && num >= 10000)
						{
							Item item2 = this.inventory[k];
							item2.stack = item2.stack + 1;
							num = num - 10000;
							this.DoCoins(k);
							if (this.inventory[k].stack != 0 || num2 != -1)
							{
								continue;
							}
							num2 = k;
						}
					}
					if (num < 10000)
					{
						continue;
					}
					if (num2 != -1)
					{
						this.inventory[num2].SetDefaults(73, false);
						num = num - 10000;
					}
					else
					{
						flag = true;
					}
				}
				else
				{
					break;
				}
			}
			while (num >= 100)
			{
				if (!flag)
				{
					int num3 = -1;
					for (int l = 53; l >= 0; l--)
					{
						if (num3 == -1 && (this.inventory[l].type == 0 || this.inventory[l].stack == 0))
						{
							num3 = l;
						}
						while (this.inventory[l].type == 72 && this.inventory[l].stack < this.inventory[l].maxStack && num >= 100)
						{
							Item item3 = this.inventory[l];
							item3.stack = item3.stack + 1;
							num = num - 100;
							this.DoCoins(l);
							if (this.inventory[l].stack != 0 || num3 != -1)
							{
								continue;
							}
							num3 = l;
						}
					}
					if (num < 100)
					{
						continue;
					}
					if (num3 != -1)
					{
						this.inventory[num3].SetDefaults(72, false);
						num = num - 100;
					}
					else
					{
						flag = true;
					}
				}
				else
				{
					break;
				}
			}
			while (num >= 1 && !flag)
			{
				int num4 = -1;
				for (int m = 53; m >= 0; m--)
				{
					if (num4 == -1 && (this.inventory[m].type == 0 || this.inventory[m].stack == 0))
					{
						num4 = m;
					}
					while (this.inventory[m].type == 71 && this.inventory[m].stack < this.inventory[m].maxStack && num >= 1)
					{
						Item item4 = this.inventory[m];
						item4.stack = item4.stack + 1;
						num--;
						this.DoCoins(m);
						if (this.inventory[m].stack != 0 || num4 != -1)
						{
							continue;
						}
						num4 = m;
					}
				}
				if (num < 1)
				{
					continue;
				}
				if (num4 != -1)
				{
					this.inventory[num4].SetDefaults(71, false);
					num--;
				}
				else
				{
					flag = true;
				}
			}
			if (!flag)
			{
				return true;
			}
			for (int n = 0; n < 58; n++)
			{
				this.inventory[n] = item[n].Clone();
			}
			return false;
		}

		public static int SetMatch(int armorslot, int type, bool male, ref bool somethingSpecial)
		{
			int num = -1;
			if (armorslot == 1)
			{
				int num1 = type;
				if (num1 > 63)
				{
					if (num1 > 167)
					{
						switch (num1)
						{
							case 180:
							{
								num = 115;
								break;
							}
							case 181:
							{
								num = 116;
								break;
							}
							case 182:
							{
								break;
							}
							case 183:
							{
								num = 123;
								break;
							}
							default:
							{
								if (num1 == 191)
								{
									num = 131;
									break;
								}
								else
								{
									break;
								}
							}
						}
					}
					else if (num1 == 77)
					{
						num = 121;
					}
					else
					{
						switch (num1)
						{
							case 165:
							{
								if (male)
								{
									num = 99;
									break;
								}
								else
								{
									num = 118;
									break;
								}
							}
							case 166:
							{
								if (male)
								{
									num = 100;
									break;
								}
								else
								{
									num = 119;
									break;
								}
							}
							case 167:
							{
								if (male)
								{
									num = 102;
									break;
								}
								else
								{
									num = 101;
									break;
								}
							}
						}
					}
				}
				else if (num1 > 36)
				{
					switch (num1)
					{
						case 41:
						{
							num = 97;
							break;
						}
						case 42:
						{
							num = 90;
							break;
						}
						default:
						{
							switch (num1)
							{
								case 58:
								{
									num = 91;
									break;
								}
								case 59:
								{
									num = 92;
									break;
								}
								case 60:
								{
									num = 93;
									break;
								}
								case 61:
								{
									num = 94;
									break;
								}
								case 62:
								{
									num = 95;
									break;
								}
								case 63:
								{
									num = 96;
									break;
								}
							}
							break;
						}
					}
				}
				else if (num1 == 15)
				{
					num = 88;
				}
				else if (num1 == 36)
				{
					num = 89;
				}
				if (num != -1)
				{
					somethingSpecial = true;
				}
			}
			if (armorslot == 2)
			{
				switch (type)
				{
					case 83:
					{
						if (!male)
						{
							break;
						}
						num = 117;
						break;
					}
					case 84:
					{
						if (!male)
						{
							break;
						}
						num = 120;
						break;
					}
				}
			}
			return num;
		}

		public void ShadowDodge()
		{
			this.immune = true;
			this.immuneTime = 80;
			if (this.longInvince)
			{
				Player player = this;
				player.immuneTime = player.immuneTime + 40;
			}
			if (this.whoAmI == Main.myPlayer)
			{
				for (int i = 0; i < 22; i++)
				{
					if (this.buffTime[i] > 0 && this.buffType[i] == BuffID.ShadowDodge)
					{
						this.DelBuff(i);
					}
				}
				NetMessage.SendData((int)PacketTypes.PlayerDodge, -1, -1, "", this.whoAmI, 2f, 0f, 0f, 0, 0, 0);
			}
		}

		public void SlopeDownMovement()
		{
			this.sloping = false;
			float y = this.velocity.Y;
			Vector4 vector4 = Collision.WalkDownSlope(this.position, this.velocity, this.width, this.height, this.gravity * this.gravDir);
			this.position.X = vector4.X;
			this.position.Y = vector4.Y;
			this.velocity.X = vector4.Z;
			this.velocity.Y = vector4.W;
			if (this.velocity.Y != y)
			{
				this.sloping = true;
			}
		}

		public void SlopingCollision(bool fallThrough)
		{
			if (this.controlDown || this.grappling[0] >= 0 || this.gravDir == -1f)
			{
				this.stairFall = true;
			}
			Vector4 vector4 = Collision.SlopeCollision(this.position, this.velocity, this.width, this.height, this.gravity, this.stairFall);
			if (Collision.stairFall)
			{
				this.stairFall = true;
			}
			else if (!fallThrough)
			{
				this.stairFall = false;
			}
			if (Collision.stair && Math.Abs(vector4.Y - this.position.Y) > 8f + Math.Abs(this.velocity.X))
			{
				Player y = this;
				y.gfxOffY = y.gfxOffY - (vector4.Y - this.position.Y);
				this.stepSpeed = 4f;
			}
			float single = this.velocity.Y;
			this.position.X = vector4.X;
			this.position.Y = vector4.Y;
			this.velocity.X = vector4.Z;
			this.velocity.Y = vector4.W;
			if (this.gravDir == -1f && this.velocity.Y == 0.0101f)
			{
				this.velocity.Y = 0f;
			}
		}

		public void SmartCursorLookup()
		{
			Tuple<int, int> tuple;
			ushort num;
			if (this.whoAmI != Main.myPlayer)
			{
				return;
			}
			Main.smartDigShowing = false;
			if (!Main.smartDigEnabled)
			{
				return;
			}
			Item item = this.inventory[this.selectedItem];
			Vector2 vector2 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (this.gravDir == -1f)
			{
				vector2.Y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY;
			}
			int num1 = Player.tileTargetX;
			int num2 = Player.tileTargetY;
			if (num1 < 10)
			{
				num1 = 10;
			}
			if (num1 > Main.maxTilesX - 10)
			{
				num1 = Main.maxTilesX - 10;
			}
			if (num2 < 10)
			{
				num2 = 10;
			}
			if (num2 > Main.maxTilesY - 10)
			{
				num2 = Main.maxTilesY - 10;
			}
			bool flag = false;
			if (Main.tile[num1, num2] == null)
			{
				return;
			}
			if (Main.tile[num1, num2].active())
			{
				num = Main.tile[num1, num2].type;
				if (num <= 132)
				{
					if (num <= 55)
					{
						if (num <= 21)
						{
							if (num != 4)
							{
								switch (num)
								{
									case 10:
									case 11:
									case 13:
									{
										break;
									}
									case 12:
									{
										goto Label0;
									}
									default:
									{
										if (num == 21)
										{
											break;
										}
										goto Label0;
									}
								}
							}
						}
						else if (num > 33)
						{
							switch (num)
							{
								case 49:
								case 50:
								{
									break;
								}
								default:
								{
									if (num == 55)
									{
										break;
									}
									goto Label0;
								}
							}
						}
						else
						{
							if (num == 29 || num == 33)
							{
								goto Label1;
							}
							goto Label0;
						}
					}
					else if (num <= 88)
					{
						if (num == 79 || num == 85 || num == 88)
						{
							goto Label1;
						}
						goto Label0;
					}
					else if (num > 104)
					{
						if (num == 125 || num == 132)
						{
							goto Label1;
						}
						goto Label0;
					}
					else
					{
						if (num == 97 || num == 104)
						{
							goto Label1;
						}
						goto Label0;
					}
				}
				else if (num > 216)
				{
					if (num <= 314)
					{
						if (num > 237)
						{
							if (num == 287)
							{
								goto Label1;
							}
							if (num != 314)
							{
								goto Label0;
							}
							else if (this.gravDir == 1f)
							{
								flag = true;
								goto Label0;
							}
							else
							{
								goto Label0;
							}
						}
						else
						{
							if (num == 219 || num == 237)
							{
								goto Label1;
							}
							goto Label0;
						}
					}
					else if (num > 354)
					{
						switch (num)
						{
							case 386:
							case 387:
							{
								break;
							}
							default:
							{
								if (num != 411)
								{
									goto Label0;
								}
								else
								{
									break;
								}
							}
						}
					}
					else
					{
						switch (num)
						{
							case 334:
							case 335:
							case 338:
							{
								break;
							}
							case 336:
							case 337:
							{
								goto Label0;
							}
							default:
							{
								if (num == 354)
								{
									break;
								}
								goto Label0;
							}
						}
					}
				}
				else if (num <= 144)
				{
					if (num == 136 || num == 139 || num == 144)
					{
						goto Label1;
					}
					goto Label0;
				}
				else if (num > 209)
				{
					if (num == 212 || num == 216)
					{
						goto Label1;
					}
					goto Label0;
				}
				else if (num != 174)
				{
					switch (num)
					{
						case 207:
						case 209:
						{
							break;
						}
						default:
						{
							goto Label0;
						}
					}
				}
			Label1:
				flag = true;
			}
		Label0:
			int num3 = item.tileBoost;
			int num4 = 0;
			if (item.type == ItemID.Paintbrush || item.type == ItemID.SpectrePaintbrush || item.type == ItemID.PaintRoller || item.type == ItemID.SpectrePaintRoller)
			{
				int num5 = 0;
				while (num5 < 58)
				{
					if (this.inventory[num5].stack <= 0 || this.inventory[num5].paint <= 0)
					{
						num5++;
					}
					else
					{
						num4 = this.inventory[num5].paint;
						break;
					}
				}
			}
			int x = (int)(this.position.X / 16f) - Player.tileRangeX - num3 + 1;
			int x1 = (int)((this.position.X + (float)this.width) / 16f) + Player.tileRangeX + num3 - 1;
			int y = (int)(this.position.Y / 16f) - Player.tileRangeY - num3 + 1;
			int y1 = (int)((this.position.Y + (float)this.height) / 16f) + Player.tileRangeY + num3 - 2;
			if (x < 10)
			{
				x = 10;
			}
			if (x1 > Main.maxTilesX - 10)
			{
				x1 = Main.maxTilesX - 10;
			}
			if (y < 10)
			{
				y = 10;
			}
			if (y1 > Main.maxTilesY - 10)
			{
				y1 = Main.maxTilesY - 10;
			}
			if (flag && num1 >= x && num1 <= x1 && num2 >= y && num2 <= y1)
			{
				return;
			}
			List<Tuple<int, int>> tuples = new List<Tuple<int, int>>();
			for (int i = 0; i < this.grapCount; i++)
			{
				Projectile projectile = Main.projectile[this.grappling[i]];
				int x2 = (int)projectile.Center.X / 16;
				int y2 = (int)projectile.Center.Y / 16;
				tuples.Add(new Tuple<int, int>(x2, y2));
			}
			int item1 = -1;
			int item2 = -1;
			if (item.axe > 0 && item1 == -1 && item2 == -1)
			{
				float single = -1f;
				for (int j = x; j <= x1; j++)
				{
					for (int k = y; k <= y1; k++)
					{
						if (Main.tile[j, k].active())
						{
							Tile tile = Main.tile[j, k];
							if (Main.tileAxe[tile.type])
							{
								int num6 = j;
								int num7 = k;
								if (tile.type == TileID.Trees)
								{
									if (Collision.InTileBounds(num6 + 1, num7, x, y, x1, y1))
									{
										if (Main.tile[num6, num7].frameY >= 198 && Main.tile[num6, num7].frameX == 44)
										{
											num6++;
										}
										if (Main.tile[num6, num7].frameX == 66 && Main.tile[num6, num7].frameY <= 44)
										{
											num6++;
										}
										if (Main.tile[num6, num7].frameX == 44 && Main.tile[num6, num7].frameY >= 132 && Main.tile[num6, num7].frameY <= 176)
										{
											num6++;
										}
									}
									if (Collision.InTileBounds(num6 - 1, num7, x, y, x1, y1))
									{
										if (Main.tile[num6, num7].frameY >= 198 && Main.tile[num6, num7].frameX == 66)
										{
											num6--;
										}
										if (Main.tile[num6, num7].frameX == 88 && Main.tile[num6, num7].frameY >= 66 && Main.tile[num6, num7].frameY <= 110)
										{
											num6--;
										}
										if (Main.tile[num6, num7].frameX == 22 && Main.tile[num6, num7].frameY >= 132 && Main.tile[num6, num7].frameY <= 176)
										{
											num6--;
										}
									}
									while (Main.tile[num6, num7].active() && Main.tile[num6, num7].type == TileID.Trees && Main.tile[num6, num7 + 1].type == 5 && Collision.InTileBounds(num6, num7 + 1, x, y, x1, y1))
									{
										num7++;
									}
								}
								if (tile.type == TileID.Cactus)
								{
									if (Collision.InTileBounds(num6 + 1, num7, x, y, x1, y1))
									{
										if (Main.tile[num6, num7].frameX == 54)
										{
											num6++;
										}
										if (Main.tile[num6, num7].frameX == 108 && Main.tile[num6, num7].frameY == 36)
										{
											num6++;
										}
									}
									if (Collision.InTileBounds(num6 - 1, num7, x, y, x1, y1))
									{
										if (Main.tile[num6, num7].frameX == 36)
										{
											num6--;
										}
										if (Main.tile[num6, num7].frameX == 108 && Main.tile[num6, num7].frameY == 18)
										{
											num6--;
										}
									}
									while (Main.tile[num6, num7].active() && Main.tile[num6, num7].type == TileID.Cactus && Main.tile[num6, num7 + 1].type == 80 && Collision.InTileBounds(num6, num7 + 1, x, y, x1, y1))
									{
										num7++;
									}
								}
								if (tile.type != TileID.PalmTree)
								{
									if (tile.type != TileID.MushroomTrees)
									{
										goto Label2;
									}
								}
								while (Main.tile[num6, num7].active() && (Main.tile[num6, num7].type == TileID.PalmTree && Main.tile[num6, num7 + 1].type == 323 || Main.tile[num6, num7].type == TileID.MushroomTrees && Main.tile[num6, num7 + 1].type == 72) && Collision.InTileBounds(num6, num7 + 1, x, y, x1, y1))
								{
									num7++;
								}
							Label2:
								float single1 = Vector2.Distance((new Vector2((float)num6, (float)num7) * 16f) + (Vector2.One * 8f), vector2);
								if (single == -1f || single1 < single)
								{
									single = single1;
									item1 = num6;
									item2 = num7;
								}
							}
						}
					}
				}
			}
			if (item.pick > 0 && item1 == -1 && item2 == -1)
			{
				Vector2 center = vector2 - base.Center;
				int num8 = Math.Sign(center.X);
				int num9 = Math.Sign(center.Y);
				if (Math.Abs(center.X) > Math.Abs(center.Y) * 3f)
				{
					num9 = 0;
					vector2.Y = base.Center.Y;
				}
				if (Math.Abs(center.Y) > Math.Abs(center.X) * 3f)
				{
					num8 = 0;
					vector2.X = base.Center.X;
				}
				int x3 = (int)base.Center.X / 16;
				int y3 = (int)base.Center.Y / 16;
				List<Tuple<int, int>> tuples1 = new List<Tuple<int, int>>();
				List<Tuple<int, int>> tuples2 = new List<Tuple<int, int>>();
				int num10 = 1;
				if (num9 == -1 && num8 != 0)
				{
					num10 = -1;
				}
				int x4 = (int)((this.position.X + (float)(this.width / 2) + (float)((this.width / 2 - 1) * num8)) / 16f);
				int y4 = (int)(((double)this.position.Y + 0.1) / 16);
				if (num10 == -1)
				{
					y4 = (int)((this.position.Y + (float)this.height - 1f) / 16f);
				}
				int num11 = this.width / 16 + (this.width % 16 == 0 ? 0 : 1);
				int num12 = this.height / 16 + (this.height % 16 == 0 ? 0 : 1);
				if (num8 != 0)
				{
					for (int l = 0; l < num12; l++)
					{
						if (Main.tile[x4, y4 + l * num10] == null)
						{
							return;
						}
						tuples1.Add(new Tuple<int, int>(x4, y4 + l * num10));
					}
				}
				if (num9 != 0)
				{
					for (int m = 0; m < num11; m++)
					{
						if (Main.tile[(int)(this.position.X / 16f) + m, y4] == null)
						{
							return;
						}
						tuples1.Add(new Tuple<int, int>((int)(this.position.X / 16f) + m, y4));
					}
				}
				int x5 = (int)((vector2.X + (float)((this.width / 2 - 1) * num8)) / 16f);
				int y5 = (int)(((double)vector2.Y + 0.1 - (double)(this.height / 2 + 1)) / 16);
				if (num10 == -1)
				{
					y5 = (int)((vector2.Y + (float)(this.height / 2) - 1f) / 16f);
				}
				if (this.gravDir == -1f && num9 == 0)
				{
					y5++;
				}
				if (y5 < 10)
				{
					y5 = 10;
				}
				if (y5 > Main.maxTilesY - 10)
				{
					y5 = Main.maxTilesY - 10;
				}
				int num13 = this.width / 16 + (this.width % 16 == 0 ? 0 : 1);
				int num14 = this.height / 16 + (this.height % 16 == 0 ? 0 : 1);
				if (num8 != 0)
				{
					for (int n = 0; n < num14; n++)
					{
						if (Main.tile[x5, y5 + n * num10] == null)
						{
							return;
						}
						tuples2.Add(new Tuple<int, int>(x5, y5 + n * num10));
					}
				}
				if (num9 != 0)
				{
					for (int o = 0; o < num13; o++)
					{
						if (Main.tile[(int)((vector2.X - (float)(this.width / 2)) / 16f) + o, y5] == null)
						{
							return;
						}
						tuples2.Add(new Tuple<int, int>((int)((vector2.X - (float)(this.width / 2)) / 16f) + o, y5));
					}
				}
				List<Tuple<int, int>> tuples3 = new List<Tuple<int, int>>();
				while (tuples1.Count > 0)
				{
					Tuple<int, int> tuple1 = tuples1[0];
					Tuple<int, int> tuple2 = tuples2[0];
					if (Collision.TupleHitLine(tuple1.Item1, tuple1.Item2, tuple2.Item1, tuple2.Item2, num8 * (int)this.gravDir, -num9 * (int)this.gravDir, tuples, out tuple))
					{
						if (tuple.Item1 != tuple2.Item1 || tuple.Item2 != tuple2.Item2)
						{
							tuples3.Add(tuple);
						}
						Tile tile1 = Main.tile[tuple.Item1, tuple.Item2];
						if (!tile1.inActive() && tile1.active() && Main.tileSolid[tile1.type] && !Main.tileSolidTop[tile1.type] && !tuples.Contains(tuple))
						{
							tuples3.Add(tuple);
						}
						tuples1.Remove(tuple1);
						tuples2.Remove(tuple2);
					}
					else
					{
						tuples1.Remove(tuple1);
						tuples2.Remove(tuple2);
					}
				}
				List<Tuple<int, int>> tuples4 = new List<Tuple<int, int>>();
				for (int p = 0; p < tuples3.Count; p++)
				{
					if (!WorldGen.CanKillTile(tuples3[p].Item1, tuples3[p].Item2))
					{
						tuples4.Add(tuples3[p]);
					}
				}
				for (int q = 0; q < tuples4.Count; q++)
				{
					tuples3.Remove(tuples4[q]);
				}
				tuples4.Clear();
				if (tuples3.Count > 0)
				{
					float single2 = -1f;
					Tuple<int, int> item3 = tuples3[0];
					for (int r = 0; r < tuples3.Count; r++)
					{
						float single3 = Vector2.Distance((new Vector2((float)tuples3[r].Item1, (float)tuples3[r].Item2) * 16f) + (Vector2.One * 8f), base.Center);
						if (single2 == -1f || single3 < single2)
						{
							single2 = single3;
							item3 = tuples3[r];
						}
					}
					if (Collision.InTileBounds(item3.Item1, item3.Item2, x, y, x1, y1))
					{
						item1 = item3.Item1;
						item2 = item3.Item2;
					}
				}
				tuples1.Clear();
				tuples2.Clear();
				tuples3.Clear();
			}
			if ((item.type == ItemID.Wrench || item.type == ItemID.BlueWrench || item.type == ItemID.GreenWrench) && item1 == -1 && item2 == -1)
			{
				List<Tuple<int, int>> tuples5 = new List<Tuple<int, int>>();
				int num15 = 0;
				if (item.type == ItemID.Wrench)
				{
					num15 = 1;
				}
				if (item.type == ItemID.BlueWrench)
				{
					num15 = 2;
				}
				if (item.type == ItemID.GreenWrench)
				{
					num15 = 3;
				}
				bool flag1 = false;
				if (Main.tile[num1, num2].wire() && num15 == 1)
				{
					flag1 = true;
				}
				if (Main.tile[num1, num2].wire2() && num15 == 2)
				{
					flag1 = true;
				}
				if (Main.tile[num1, num2].wire3() && num15 == 3)
				{
					flag1 = true;
				}
				if (!flag1)
				{
					for (int s = x; s <= x1; s++)
					{
						for (int t = y; t <= y1; t++)
						{
							Tile tile2 = Main.tile[s, t];
							if (tile2.wire() && num15 == 1 || tile2.wire2() && num15 == 2 || tile2.wire3() && num15 == 3)
							{
								if (num15 == 1)
								{
									if (!Main.tile[s - 1, t].wire())
									{
										tuples5.Add(new Tuple<int, int>(s - 1, t));
									}
									if (!Main.tile[s + 1, t].wire())
									{
										tuples5.Add(new Tuple<int, int>(s + 1, t));
									}
									if (!Main.tile[s, t - 1].wire())
									{
										tuples5.Add(new Tuple<int, int>(s, t - 1));
									}
									if (!Main.tile[s, t + 1].wire())
									{
										tuples5.Add(new Tuple<int, int>(s, t + 1));
									}
								}
								if (num15 == 2)
								{
									if (!Main.tile[s - 1, t].wire2())
									{
										tuples5.Add(new Tuple<int, int>(s - 1, t));
									}
									if (!Main.tile[s + 1, t].wire2())
									{
										tuples5.Add(new Tuple<int, int>(s + 1, t));
									}
									if (!Main.tile[s, t - 1].wire2())
									{
										tuples5.Add(new Tuple<int, int>(s, t - 1));
									}
									if (!Main.tile[s, t + 1].wire2())
									{
										tuples5.Add(new Tuple<int, int>(s, t + 1));
									}
								}
								if (num15 == 3)
								{
									if (!Main.tile[s - 1, t].wire3())
									{
										tuples5.Add(new Tuple<int, int>(s - 1, t));
									}
									if (!Main.tile[s + 1, t].wire3())
									{
										tuples5.Add(new Tuple<int, int>(s + 1, t));
									}
									if (!Main.tile[s, t - 1].wire3())
									{
										tuples5.Add(new Tuple<int, int>(s, t - 1));
									}
									if (!Main.tile[s, t + 1].wire3())
									{
										tuples5.Add(new Tuple<int, int>(s, t + 1));
									}
								}
							}
						}
					}
				}
				if (tuples5.Count > 0)
				{
					float single4 = -1f;
					Tuple<int, int> tuple3 = tuples5[0];
					for (int u = 0; u < tuples5.Count; u++)
					{
						float single5 = Vector2.Distance((new Vector2((float)tuples5[u].Item1, (float)tuples5[u].Item2) * 16f) + (Vector2.One * 8f), vector2);
						if (single4 == -1f || single5 < single4)
						{
							single4 = single5;
							tuple3 = tuples5[u];
						}
					}
					if (Collision.InTileBounds(tuple3.Item1, tuple3.Item2, x, y, x1, y1))
					{
						item1 = tuple3.Item1;
						item2 = tuple3.Item2;
					}
				}
				tuples5.Clear();
			}
			if (item.hammer > 0 && item1 == -1 && item2 == -1)
			{
				Vector2 center1 = vector2 - base.Center;
				int num16 = Math.Sign(center1.X);
				int num17 = Math.Sign(center1.Y);
				if (Math.Abs(center1.X) > Math.Abs(center1.Y) * 3f)
				{
					num17 = 0;
					vector2.Y = base.Center.Y;
				}
				if (Math.Abs(center1.Y) > Math.Abs(center1.X) * 3f)
				{
					num16 = 0;
					vector2.X = base.Center.X;
				}
				int x6 = (int)base.Center.X / 16;
				int y6 = (int)base.Center.Y / 16;
				List<Tuple<int, int>> tuples6 = new List<Tuple<int, int>>();
				List<Tuple<int, int>> tuples7 = new List<Tuple<int, int>>();
				int num18 = 1;
				if (num17 == -1 && num16 != 0)
				{
					num18 = -1;
				}
				int x7 = (int)((this.position.X + (float)(this.width / 2) + (float)((this.width / 2 - 1) * num16)) / 16f);
				int y7 = (int)(((double)this.position.Y + 0.1) / 16);
				if (num18 == -1)
				{
					y7 = (int)((this.position.Y + (float)this.height - 1f) / 16f);
				}
				int num19 = this.width / 16 + (this.width % 16 == 0 ? 0 : 1);
				int num20 = this.height / 16 + (this.height % 16 == 0 ? 0 : 1);
				if (num16 != 0)
				{
					for (int v = 0; v < num20; v++)
					{
						if (Main.tile[x7, y7 + v * num18] == null)
						{
							return;
						}
						tuples6.Add(new Tuple<int, int>(x7, y7 + v * num18));
					}
				}
				if (num17 != 0)
				{
					for (int w = 0; w < num19; w++)
					{
						if (Main.tile[(int)(this.position.X / 16f) + w, y7] == null)
						{
							return;
						}
						tuples6.Add(new Tuple<int, int>((int)(this.position.X / 16f) + w, y7));
					}
				}
				int x8 = (int)((vector2.X + (float)((this.width / 2 - 1) * num16)) / 16f);
				int y8 = (int)(((double)vector2.Y + 0.1 - (double)(this.height / 2 + 1)) / 16);
				if (num18 == -1)
				{
					y8 = (int)((vector2.Y + (float)(this.height / 2) - 1f) / 16f);
				}
				if (this.gravDir == -1f && num17 == 0)
				{
					y8++;
				}
				if (y8 < 10)
				{
					y8 = 10;
				}
				if (y8 > Main.maxTilesY - 10)
				{
					y8 = Main.maxTilesY - 10;
				}
				int num21 = this.width / 16 + (this.width % 16 == 0 ? 0 : 1);
				int num22 = this.height / 16 + (this.height % 16 == 0 ? 0 : 1);
				if (num16 != 0)
				{
					for (int x9 = 0; x9 < num22; x9++)
					{
						if (Main.tile[x8, y8 + x9 * num18] == null)
						{
							return;
						}
						tuples7.Add(new Tuple<int, int>(x8, y8 + x9 * num18));
					}
				}
				if (num17 != 0)
				{
					for (int y9 = 0; y9 < num21; y9++)
					{
						if (Main.tile[(int)((vector2.X - (float)(this.width / 2)) / 16f) + y9, y8] == null)
						{
							return;
						}
						tuples7.Add(new Tuple<int, int>((int)((vector2.X - (float)(this.width / 2)) / 16f) + y9, y8));
					}
				}
				List<Tuple<int, int>> tuples8 = new List<Tuple<int, int>>();
				while (tuples6.Count > 0)
				{
					Tuple<int, int> item4 = tuples6[0];
					Tuple<int, int> tuple4 = tuples7[0];
					Tuple<int, int> tuple5 = Collision.TupleHitLineWall(item4.Item1, item4.Item2, tuple4.Item1, tuple4.Item2);
					if (tuple5.Item1 == -1 || tuple5.Item2 == -1)
					{
						tuples6.Remove(item4);
						tuples7.Remove(tuple4);
					}
					else
					{
						if (tuple5.Item1 != tuple4.Item1 || tuple5.Item2 != tuple4.Item2)
						{
							tuples8.Add(tuple5);
						}
						Tile tile3 = Main.tile[tuple5.Item1, tuple5.Item2];
						if (Collision.HitWallSubstep(tuple5.Item1, tuple5.Item2))
						{
							tuples8.Add(tuple5);
						}
						tuples6.Remove(item4);
						tuples7.Remove(tuple4);
					}
				}
				if (tuples8.Count > 0)
				{
					float single6 = -1f;
					Tuple<int, int> item5 = tuples8[0];
					for (int a = 0; a < tuples8.Count; a++)
					{
						float single7 = Vector2.Distance((new Vector2((float)tuples8[a].Item1, (float)tuples8[a].Item2) * 16f) + (Vector2.One * 8f), base.Center);
						if (single6 == -1f || single7 < single6)
						{
							single6 = single7;
							item5 = tuples8[a];
						}
					}
					if (Collision.InTileBounds(item5.Item1, item5.Item2, x, y, x1, y1))
					{
						this.poundRelease = false;
						item1 = item5.Item1;
						item2 = item5.Item2;
					}
				}
				tuples8.Clear();
				tuples6.Clear();
				tuples7.Clear();
			}
			if (item.hammer > 0 && item1 == -1 && item2 == -1)
			{
				List<Tuple<int, int>> tuples9 = new List<Tuple<int, int>>();
				for (int b = x; b <= x1; b++)
				{
					for (int c = y; c <= y1; c++)
					{
						if (Main.tile[b, c].wall > 0 && Collision.HitWallSubstep(b, c))
						{
							tuples9.Add(new Tuple<int, int>(b, c));
						}
					}
				}
				if (tuples9.Count > 0)
				{
					float single8 = -1f;
					Tuple<int, int> item6 = tuples9[0];
					for (int d = 0; d < tuples9.Count; d++)
					{
						float single9 = Vector2.Distance((new Vector2((float)tuples9[d].Item1, (float)tuples9[d].Item2) * 16f) + (Vector2.One * 8f), vector2);
						if (single8 == -1f || single9 < single8)
						{
							single8 = single9;
							item6 = tuples9[d];
						}
					}
					if (Collision.InTileBounds(item6.Item1, item6.Item2, x, y, x1, y1))
					{
						this.poundRelease = false;
						item1 = item6.Item1;
						item2 = item6.Item2;
					}
				}
				tuples9.Clear();
			}
			if (item.type == ItemID.WireCutter && item1 == -1 && item2 == -1)
			{
				List<Tuple<int, int>> tuples10 = new List<Tuple<int, int>>();
				for (int e = x; e <= x1; e++)
				{
					for (int f = y; f <= y1; f++)
					{
						Tile tile4 = Main.tile[e, f];
						if (tile4.wire() || tile4.wire2() || tile4.wire3())
						{
							tuples10.Add(new Tuple<int, int>(e, f));
						}
					}
				}
				if (tuples10.Count > 0)
				{
					float single10 = -1f;
					Tuple<int, int> tuple6 = tuples10[0];
					for (int g = 0; g < tuples10.Count; g++)
					{
						float single11 = Vector2.Distance((new Vector2((float)tuples10[g].Item1, (float)tuples10[g].Item2) * 16f) + (Vector2.One * 8f), vector2);
						if (single10 == -1f || single11 < single10)
						{
							single10 = single11;
							tuple6 = tuples10[g];
						}
					}
					if (Collision.InTileBounds(tuple6.Item1, tuple6.Item2, x, y, x1, y1))
					{
						item1 = tuple6.Item1;
						item2 = tuple6.Item2;
					}
				}
				tuples10.Clear();
			}
			if (item.createTile == 19 && item1 == -1 && item2 == -1)
			{
				List<Tuple<int, int>> tuples11 = new List<Tuple<int, int>>();
				bool flag2 = false;
				if (Main.tile[num1, num2].active() && Main.tile[num1, num2].type == TileID.Platforms)
				{
					flag2 = true;
				}
				if (!flag2)
				{
					for (int h = x; h <= x1; h++)
					{
						for (int i1 = y; i1 <= y1; i1++)
						{
							Tile tile5 = Main.tile[h, i1];
							if (tile5.active() && tile5.type == 19)
							{
								int num23 = tile5.slope();
								if (num23 != 2 && !Main.tile[h - 1, i1 - 1].active())
								{
									tuples11.Add(new Tuple<int, int>(h - 1, i1 - 1));
								}
								if (!Main.tile[h - 1, i1].active())
								{
									tuples11.Add(new Tuple<int, int>(h - 1, i1));
								}
								if (num23 != 1 && !Main.tile[h - 1, i1 + 1].active())
								{
									tuples11.Add(new Tuple<int, int>(h - 1, i1 + 1));
								}
								if (num23 != 1 && !Main.tile[h + 1, i1 - 1].active())
								{
									tuples11.Add(new Tuple<int, int>(h + 1, i1 - 1));
								}
								if (!Main.tile[h + 1, i1].active())
								{
									tuples11.Add(new Tuple<int, int>(h + 1, i1));
								}
								if (num23 != 2 && !Main.tile[h + 1, i1 + 1].active())
								{
									tuples11.Add(new Tuple<int, int>(h + 1, i1 + 1));
								}
							}
							if (!tile5.active())
							{
								int num24 = 0;
								int num25 = 0;
								num24 = 0;
								num25 = 1;
								Tile tile6 = Main.tile[h + num24, i1 + num25];
								if (tile6.active() && Main.tileSolid[tile6.type] && !Main.tileSolidTop[tile6.type])
								{
									tuples11.Add(new Tuple<int, int>(h, i1));
								}
								num24 = -1;
								num25 = 0;
								tile6 = Main.tile[h + num24, i1 + num25];
								if (tile6.active() && Main.tileSolid[tile6.type] && !Main.tileSolidTop[tile6.type])
								{
									tuples11.Add(new Tuple<int, int>(h, i1));
								}
								num24 = 1;
								num25 = 0;
								tile6 = Main.tile[h + num24, i1 + num25];
								if (tile6.active() && Main.tileSolid[tile6.type] && !Main.tileSolidTop[tile6.type])
								{
									tuples11.Add(new Tuple<int, int>(h, i1));
								}
							}
						}
					}
				}
				if (tuples11.Count > 0)
				{
					float single12 = -1f;
					Tuple<int, int> item7 = tuples11[0];
					for (int j1 = 0; j1 < tuples11.Count; j1++)
					{
						float single13 = Vector2.Distance((new Vector2((float)tuples11[j1].Item1, (float)tuples11[j1].Item2) * 16f) + (Vector2.One * 8f), vector2);
						if (single12 == -1f || single13 < single12)
						{
							single12 = single13;
							item7 = tuples11[j1];
						}
					}
					if (Collision.InTileBounds(item7.Item1, item7.Item2, x, y, x1, y1))
					{
						item1 = item7.Item1;
						item2 = item7.Item2;
					}
				}
				tuples11.Clear();
			}
			if ((item.type == ItemID.MinecartTrack || item.type == ItemID.BoosterTrack) && item1 == -1 && item2 == -1)
			{
				List<Tuple<int, int>> tuples12 = new List<Tuple<int, int>>();
				bool flag3 = false;
				if (Main.tile[num1, num2].active() && Main.tile[num1, num2].type == TileID.MinecartTrack)
				{
					flag3 = true;
				}
				if (!flag3)
				{
					for (int k1 = x; k1 <= x1; k1++)
					{
						for (int l1 = y; l1 <= y1; l1++)
						{
							Tile tile7 = Main.tile[k1, l1];
							if (tile7.active() && tile7.type == 314)
							{
								bool flag4 = (!Main.tile[k1 + 1, l1 + 1].active() ? false : Main.tile[k1 + 1, l1 + 1].type == 314);
								bool flag5 = (!Main.tile[k1 + 1, l1 - 1].active() ? false : Main.tile[k1 + 1, l1 - 1].type == 314);
								bool flag6 = (!Main.tile[k1 - 1, l1 + 1].active() ? false : Main.tile[k1 - 1, l1 + 1].type == 314);
								bool flag7 = (!Main.tile[k1 - 1, l1 - 1].active() ? false : Main.tile[k1 - 1, l1 - 1].type == 314);
								if ((!Main.tile[k1 - 1, l1 - 1].active() || Main.tileCut[Main.tile[k1 - 1, l1 - 1].type] || TileID.Sets.BreakableWhenPlacing[Main.tile[k1 - 1, l1 - 1].type]) && (flag4 || !flag5))
								{
									tuples12.Add(new Tuple<int, int>(k1 - 1, l1 - 1));
								}
								if (!Main.tile[k1 - 1, l1].active() || Main.tileCut[Main.tile[k1 - 1, l1].type] || TileID.Sets.BreakableWhenPlacing[Main.tile[k1 - 1, l1].type])
								{
									tuples12.Add(new Tuple<int, int>(k1 - 1, l1));
								}
								if ((!Main.tile[k1 - 1, l1 + 1].active() || Main.tileCut[Main.tile[k1 - 1, l1 + 1].type] || TileID.Sets.BreakableWhenPlacing[Main.tile[k1 - 1, l1 + 1].type]) && (flag5 || !flag4))
								{
									tuples12.Add(new Tuple<int, int>(k1 - 1, l1 + 1));
								}
								if ((!Main.tile[k1 + 1, l1 - 1].active() || Main.tileCut[Main.tile[k1 + 1, l1 - 1].type] || TileID.Sets.BreakableWhenPlacing[Main.tile[k1 + 1, l1 - 1].type]) && (flag6 || !flag7))
								{
									tuples12.Add(new Tuple<int, int>(k1 + 1, l1 - 1));
								}
								if (!Main.tile[k1 + 1, l1].active() || Main.tileCut[Main.tile[k1 + 1, l1].type] || TileID.Sets.BreakableWhenPlacing[Main.tile[k1 + 1, l1].type])
								{
									tuples12.Add(new Tuple<int, int>(k1 + 1, l1));
								}
								if ((!Main.tile[k1 + 1, l1 + 1].active() || Main.tileCut[Main.tile[k1 + 1, l1 + 1].type] || TileID.Sets.BreakableWhenPlacing[Main.tile[k1 + 1, l1 + 1].type]) && (flag7 || !flag6))
								{
									tuples12.Add(new Tuple<int, int>(k1 + 1, l1 + 1));
								}
							}
						}
					}
				}
				if (tuples12.Count > 0)
				{
					float single14 = -1f;
					Tuple<int, int> tuple7 = tuples12[0];
					for (int m1 = 0; m1 < tuples12.Count; m1++)
					{
						if ((!Main.tile[tuples12[m1].Item1, tuples12[m1].Item2 - 1].active() || Main.tile[tuples12[m1].Item1, tuples12[m1].Item2 - 1].type != 314) && (!Main.tile[tuples12[m1].Item1, tuples12[m1].Item2 + 1].active() || Main.tile[tuples12[m1].Item1, tuples12[m1].Item2 + 1].type != 314))
						{
							float single15 = Vector2.Distance((new Vector2((float)tuples12[m1].Item1, (float)tuples12[m1].Item2) * 16f) + (Vector2.One * 8f), vector2);
							if (single14 == -1f || single15 < single14)
							{
								single14 = single15;
								tuple7 = tuples12[m1];
							}
						}
					}
					if (Collision.InTileBounds(tuple7.Item1, tuple7.Item2, x, y, x1, y1) && single14 != -1f)
					{
						item1 = tuple7.Item1;
						item2 = tuple7.Item2;
					}
				}
				tuples12.Clear();
			}
			if (item.type == ItemID.PressureTrack && item1 == -1 && item2 == -1)
			{
				List<Tuple<int, int>> tuples13 = new List<Tuple<int, int>>();
				bool flag8 = false;
				if (Main.tile[num1, num2].active() && Main.tile[num1, num2].type == TileID.MinecartTrack)
				{
					flag8 = true;
				}
				if (!flag8)
				{
					for (int n1 = x; n1 <= x1; n1++)
					{
						for (int o1 = y; o1 <= y1; o1++)
						{
							Tile tile8 = Main.tile[n1, o1];
							if (tile8.active() && tile8.type == 314)
							{
								if (!Main.tile[n1 - 1, o1].active() || Main.tileCut[Main.tile[n1 - 1, o1].type] || TileID.Sets.BreakableWhenPlacing[Main.tile[n1 - 1, o1].type])
								{
									tuples13.Add(new Tuple<int, int>(n1 - 1, o1));
								}
								if (!Main.tile[n1 + 1, o1].active() || Main.tileCut[Main.tile[n1 + 1, o1].type] || TileID.Sets.BreakableWhenPlacing[Main.tile[n1 + 1, o1].type])
								{
									tuples13.Add(new Tuple<int, int>(n1 + 1, o1));
								}
							}
						}
					}
				}
				if (tuples13.Count > 0)
				{
					float single16 = -1f;
					Tuple<int, int> item8 = tuples13[0];
					for (int p1 = 0; p1 < tuples13.Count; p1++)
					{
						if ((!Main.tile[tuples13[p1].Item1, tuples13[p1].Item2 - 1].active() || Main.tile[tuples13[p1].Item1, tuples13[p1].Item2 - 1].type != 314) && (!Main.tile[tuples13[p1].Item1, tuples13[p1].Item2 + 1].active() || Main.tile[tuples13[p1].Item1, tuples13[p1].Item2 + 1].type != 314))
						{
							float single17 = Vector2.Distance((new Vector2((float)tuples13[p1].Item1, (float)tuples13[p1].Item2) * 16f) + (Vector2.One * 8f), vector2);
							if (single16 == -1f || single17 < single16)
							{
								single16 = single17;
								item8 = tuples13[p1];
							}
						}
					}
					if (Collision.InTileBounds(item8.Item1, item8.Item2, x, y, x1, y1) && single16 != -1f)
					{
						item1 = item8.Item1;
						item2 = item8.Item2;
					}
				}
				tuples13.Clear();
			}
			if (item.createWall > 0 && item1 == -1 && item2 == -1)
			{
				List<Tuple<int, int>> tuples14 = new List<Tuple<int, int>>();
				for (int q1 = x; q1 <= x1; q1++)
				{
					for (int r1 = y; r1 <= y1; r1++)
					{
						Tile tile9 = Main.tile[q1, r1];
						if (tile9.wall == 0 && (!tile9.active() || !Main.tileSolid[tile9.type] || Main.tileSolidTop[tile9.type]) && Collision.CanHitWithCheck(this.position, this.width, this.height, new Vector2((float)q1, (float)r1) * 16f, 16, 16, new Terraria.Utils.PerLinePoint(DelegateMethods.NotDoorStand)))
						{
							bool flag9 = false;
							if (Main.tile[q1 - 1, r1].active() || Main.tile[q1 - 1, r1].wall > 0)
							{
								flag9 = true;
							}
							if (Main.tile[q1 + 1, r1].active() || Main.tile[q1 + 1, r1].wall > 0)
							{
								flag9 = true;
							}
							if (Main.tile[q1, r1 - 1].active() || Main.tile[q1, r1 - 1].wall > 0)
							{
								flag9 = true;
							}
							if (Main.tile[q1, r1 + 1].active() || Main.tile[q1, r1 + 1].wall > 0)
							{
								flag9 = true;
							}
							if (Main.tile[q1, r1].active() && Main.tile[q1, r1].type == TileID.OpenDoor && (Main.tile[q1, r1].frameX < 18 || Main.tile[q1, r1].frameX >= 54))
							{
								flag9 = false;
							}
							if (flag9)
							{
								tuples14.Add(new Tuple<int, int>(q1, r1));
							}
						}
					}
				}
				if (tuples14.Count > 0)
				{
					float single18 = -1f;
					Tuple<int, int> tuple8 = tuples14[0];
					for (int s1 = 0; s1 < tuples14.Count; s1++)
					{
						float single19 = Vector2.Distance((new Vector2((float)tuples14[s1].Item1, (float)tuples14[s1].Item2) * 16f) + (Vector2.One * 8f), vector2);
						if (single18 == -1f || single19 < single18)
						{
							single18 = single19;
							tuple8 = tuples14[s1];
						}
					}
					if (Collision.InTileBounds(tuple8.Item1, tuple8.Item2, x, y, x1, y1))
					{
						item1 = tuple8.Item1;
						item2 = tuple8.Item2;
					}
				}
				tuples14.Clear();
			}
			if (Player.SmartCursorSettings.SmartBlocksEnabled && item.createTile > -1 && item.type != ItemID.StaffofRegrowth && Main.tileSolid[item.createTile] && !Main.tileSolidTop[item.createTile] && !Main.tileFrameImportant[item.createTile] && item1 == -1 && item2 == -1)
			{
				List<Tuple<int, int>> tuples15 = new List<Tuple<int, int>>();
				bool flag10 = false;
				if (Main.tile[num1, num2].active())
				{
					flag10 = true;
				}
				if (!Collision.InTileBounds(num1, num2, x, y, x1, y1))
				{
					flag10 = true;
				}
				if (!flag10)
				{
					for (int t1 = x; t1 <= x1; t1++)
					{
						for (int u1 = y; u1 <= y1; u1++)
						{
							Tile tile10 = Main.tile[t1, u1];
							if (!tile10.active() || Main.tileCut[tile10.type] || TileID.Sets.BreakableWhenPlacing[tile10.type])
							{
								bool flag11 = false;
								if (Main.tile[t1 - 1, u1].active() && Main.tileSolid[Main.tile[t1 - 1, u1].type] && !Main.tileSolidTop[Main.tile[t1 - 1, u1].type])
								{
									flag11 = true;
								}
								if (Main.tile[t1 + 1, u1].active() && Main.tileSolid[Main.tile[t1 + 1, u1].type] && !Main.tileSolidTop[Main.tile[t1 + 1, u1].type])
								{
									flag11 = true;
								}
								if (Main.tile[t1, u1 - 1].active() && Main.tileSolid[Main.tile[t1, u1 - 1].type] && !Main.tileSolidTop[Main.tile[t1, u1 - 1].type])
								{
									flag11 = true;
								}
								if (Main.tile[t1, u1 + 1].active() && Main.tileSolid[Main.tile[t1, u1 + 1].type] && !Main.tileSolidTop[Main.tile[t1, u1 + 1].type])
								{
									flag11 = true;
								}
								if (flag11)
								{
									tuples15.Add(new Tuple<int, int>(t1, u1));
								}
							}
						}
					}
				}
				if (tuples15.Count > 0)
				{
					float single20 = -1f;
					Tuple<int, int> item9 = tuples15[0];
					for (int v1 = 0; v1 < tuples15.Count; v1++)
					{
						if (Collision.EmptyTile(tuples15[v1].Item1, tuples15[v1].Item2, false))
						{
							float single21 = Vector2.Distance((new Vector2((float)tuples15[v1].Item1, (float)tuples15[v1].Item2) * 16f) + (Vector2.One * 8f), vector2);
							if (single20 == -1f || single21 < single20)
							{
								single20 = single21;
								item9 = tuples15[v1];
							}
						}
					}
					if (Collision.InTileBounds(item9.Item1, item9.Item2, x, y, x1, y1) && single20 != -1f)
					{
						item1 = item9.Item1;
						item2 = item9.Item2;
					}
				}
				tuples15.Clear();
			}
			if ((item.type == ItemID.PaintRoller || item.type == ItemID.SpectrePaintRoller) && num4 != 0 && item1 == -1 && item2 == -1)
			{
				List<Tuple<int, int>> tuples16 = new List<Tuple<int, int>>();
				for (int w1 = x; w1 <= x1; w1++)
				{
					for (int x11 = y; x11 <= y1; x11++)
					{
						Tile tile11 = Main.tile[w1, x11];
						if (tile11.wall > 0 && tile11.wallColor() != num4 && (!tile11.active() || !Main.tileSolid[tile11.type] || Main.tileSolidTop[tile11.type]))
						{
							tuples16.Add(new Tuple<int, int>(w1, x11));
						}
					}
				}
				if (tuples16.Count > 0)
				{
					float single22 = -1f;
					Tuple<int, int> tuple9 = tuples16[0];
					for (int y11 = 0; y11 < tuples16.Count; y11++)
					{
						float single23 = Vector2.Distance((new Vector2((float)tuples16[y11].Item1, (float)tuples16[y11].Item2) * 16f) + (Vector2.One * 8f), vector2);
						if (single22 == -1f || single23 < single22)
						{
							single22 = single23;
							tuple9 = tuples16[y11];
						}
					}
					if (Collision.InTileBounds(tuple9.Item1, tuple9.Item2, x, y, x1, y1))
					{
						item1 = tuple9.Item1;
						item2 = tuple9.Item2;
					}
				}
				tuples16.Clear();
			}
			if ((item.type == ItemID.Paintbrush || item.type == ItemID.SpectrePaintbrush) && num4 != 0 && item1 == -1 && item2 == -1)
			{
				List<Tuple<int, int>> tuples17 = new List<Tuple<int, int>>();
				for (int a1 = x; a1 <= x1; a1++)
				{
					for (int b1 = y; b1 <= y1; b1++)
					{
						Tile tile12 = Main.tile[a1, b1];
						if (tile12.active() && tile12.color() != num4)
						{
							tuples17.Add(new Tuple<int, int>(a1, b1));
						}
					}
				}
				if (tuples17.Count > 0)
				{
					float single24 = -1f;
					Tuple<int, int> item10 = tuples17[0];
					for (int c1 = 0; c1 < tuples17.Count; c1++)
					{
						float single25 = Vector2.Distance((new Vector2((float)tuples17[c1].Item1, (float)tuples17[c1].Item2) * 16f) + (Vector2.One * 8f), vector2);
						if (single24 == -1f || single25 < single24)
						{
							single24 = single25;
							item10 = tuples17[c1];
						}
					}
					if (Collision.InTileBounds(item10.Item1, item10.Item2, x, y, x1, y1))
					{
						item1 = item10.Item1;
						item2 = item10.Item2;
					}
				}
				tuples17.Clear();
			}
			if ((item.type == ItemID.PaintScraper || item.type == ItemID.SpectrePaintScraper) && item1 == -1 && item2 == -1)
			{
				List<Tuple<int, int>> tuples18 = new List<Tuple<int, int>>();
				for (int d1 = x; d1 <= x1; d1++)
				{
					for (int e1 = y; e1 <= y1; e1++)
					{
						Tile tile13 = Main.tile[d1, e1];
						if (tile13.active() && tile13.color() > 0 || tile13.wall > 0 && tile13.wallColor() > 0)
						{
							tuples18.Add(new Tuple<int, int>(d1, e1));
						}
					}
				}
				if (tuples18.Count > 0)
				{
					float single26 = -1f;
					Tuple<int, int> tuple10 = tuples18[0];
					for (int f1 = 0; f1 < tuples18.Count; f1++)
					{
						float single27 = Vector2.Distance((new Vector2((float)tuples18[f1].Item1, (float)tuples18[f1].Item2) * 16f) + (Vector2.One * 8f), vector2);
						if (single26 == -1f || single27 < single26)
						{
							single26 = single27;
							tuple10 = tuples18[f1];
						}
					}
					if (Collision.InTileBounds(tuple10.Item1, tuple10.Item2, x, y, x1, y1))
					{
						item1 = tuple10.Item1;
						item2 = tuple10.Item2;
					}
				}
				tuples18.Clear();
			}
			if (item.type == ItemID.Acorn && item1 == -1 && item2 == -1 && y > 20)
			{
				List<Tuple<int, int>> tuples19 = new List<Tuple<int, int>>();
				for (int g1 = x; g1 <= x1; g1++)
				{
					for (int h1 = y; h1 <= y1; h1++)
					{
						Tile tile14 = Main.tile[g1, h1];
						Tile tile15 = Main.tile[g1, h1 - 1];
						Tile tile16 = Main.tile[g1, h1 + 1];
						Tile tile17 = Main.tile[g1 - 1, h1];
						Tile tile18 = Main.tile[g1 + 1, h1];
						if ((!tile14.active() || Main.tileCut[tile14.type] || TileID.Sets.BreakableWhenPlacing[tile14.type]) && (!tile15.active() || Main.tileCut[tile15.type] || TileID.Sets.BreakableWhenPlacing[tile15.type]) && (!tile17.active() || tile17.type != 20) && (!tile18.active() || tile18.type != 20) && tile16.active() && WorldGen.SolidTile2(tile16))
						{
							num = tile16.type;
							if (num > 109)
							{
								if (num > 116)
								{
									if (num == 147 || num == 199 || num == 234)
									{
										goto Label4;
									}
									continue;
								}
								else
								{
									if (num == 112 || num == 116)
									{
										goto Label4;
									}
									continue;
								}
							}
							else if (num <= 23)
							{
								if (num == 2 || num == 23)
								{
									goto Label4;
								}
								continue;
							}
							else if (num != 53)
							{
								if (num != 60)
								{
									if (num == 109)
									{
										goto Label4;
									}
									continue;
								}
								else if (WorldGen.EmptyTileCheck(g1 - 2, g1 + 2, h1 - 20, h1, 20))
								{
									tuples19.Add(new Tuple<int, int>(g1, h1));
									continue;
								}
								else
								{
									continue;
								}
							}
						Label4:
							if (tile17.liquid == 0 && tile14.liquid == 0 && tile18.liquid == 0 && WorldGen.EmptyTileCheck(g1 - 2, g1 + 2, h1 - 20, h1, 20))
							{
								tuples19.Add(new Tuple<int, int>(g1, h1));
							}
						}
					}
				}
				List<Tuple<int, int>> tuples20 = new List<Tuple<int, int>>();
				for (int i2 = 0; i2 < tuples19.Count; i2++)
				{
					bool flag12 = false;
					for (int j2 = -1; j2 < 2; j2 = j2 + 2)
					{
						Tile tile19 = Main.tile[tuples19[i2].Item1 + j2, tuples19[i2].Item2 + 1];
						if (tile19.active())
						{
							num = tile19.type;
							if (num <= 109)
							{
								if (num > 23)
								{
									if (num == 53 || num == 60 || num == 109)
									{
										goto Label6;
									}
									continue;
								}
								else
								{
									if (num == 2 || num == 23)
									{
										goto Label6;
									}
									continue;
								}
							}
							else if (num <= 116)
							{
								if (num == 112 || num == 116)
								{
									goto Label6;
								}
								continue;
							}
							else if (num != 147 && num != 199 && num != 234)
							{
								continue;
							}
						Label6:
							flag12 = true;
						}
					}
					if (!flag12)
					{
						tuples20.Add(tuples19[i2]);
					}
				}
				for (int k2 = 0; k2 < tuples20.Count; k2++)
				{
					tuples19.Remove(tuples20[k2]);
				}
				tuples20.Clear();
				if (tuples19.Count > 0)
				{
					float single28 = -1f;
					Tuple<int, int> item11 = tuples19[0];
					for (int l2 = 0; l2 < tuples19.Count; l2++)
					{
						float single29 = Vector2.Distance((new Vector2((float)tuples19[l2].Item1, (float)tuples19[l2].Item2) * 16f) + (Vector2.One * 8f), vector2);
						if (single28 == -1f || single29 < single28)
						{
							single28 = single29;
							item11 = tuples19[l2];
						}
					}
					if (Collision.InTileBounds(item11.Item1, item11.Item2, x, y, x1, y1))
					{
						item1 = item11.Item1;
						item2 = item11.Item2;
					}
				}
				tuples19.Clear();
			}
			if (item.type == ItemID.EmptyBucket && item1 == -1 && item2 == -1)
			{
				List<Tuple<int, int>> tuples21 = new List<Tuple<int, int>>();
				for (int m2 = x; m2 <= x1; m2++)
				{
					for (int n2 = y; n2 <= y1; n2++)
					{
						Tile tile20 = Main.tile[m2, n2];
						if (tile20.liquid > 0)
						{
							int num26 = tile20.liquidType();
							int num27 = 0;
							for (int o2 = m2 - 1; o2 <= m2 + 1; o2++)
							{
								for (int p2 = n2 - 1; p2 <= n2 + 1; p2++)
								{
									if (Main.tile[o2, p2].liquidType() == num26)
									{
										num27 = num27 + Main.tile[o2, p2].liquid;
									}
								}
							}
							if (num27 > 100)
							{
								tuples21.Add(new Tuple<int, int>(m2, n2));
							}
						}
					}
				}
				if (tuples21.Count > 0)
				{
					float single30 = -1f;
					Tuple<int, int> tuple11 = tuples21[0];
					for (int q2 = 0; q2 < tuples21.Count; q2++)
					{
						float single31 = Vector2.Distance((new Vector2((float)tuples21[q2].Item1, (float)tuples21[q2].Item2) * 16f) + (Vector2.One * 8f), vector2);
						if (single30 == -1f || single31 < single30)
						{
							single30 = single31;
							tuple11 = tuples21[q2];
						}
					}
					if (Collision.InTileBounds(tuple11.Item1, tuple11.Item2, x, y, x1, y1))
					{
						item1 = tuple11.Item1;
						item2 = tuple11.Item2;
					}
				}
				tuples21.Clear();
			}
			if (item.type == ItemID.Actuator && item1 == -1 && item2 == -1)
			{
				List<Tuple<int, int>> tuples22 = new List<Tuple<int, int>>();
				for (int r2 = x; r2 <= x1; r2++)
				{
					for (int s2 = y; s2 <= y1; s2++)
					{
						Tile tile21 = Main.tile[r2, s2];
						if ((tile21.wire() || tile21.wire2() || tile21.wire3()) && !tile21.actuator() && tile21.active())
						{
							tuples22.Add(new Tuple<int, int>(r2, s2));
						}
					}
				}
				if (tuples22.Count > 0)
				{
					float single32 = -1f;
					Tuple<int, int> item12 = tuples22[0];
					for (int t2 = 0; t2 < tuples22.Count; t2++)
					{
						float single33 = Vector2.Distance((new Vector2((float)tuples22[t2].Item1, (float)tuples22[t2].Item2) * 16f) + (Vector2.One * 8f), vector2);
						if (single32 == -1f || single33 < single32)
						{
							single32 = single33;
							item12 = tuples22[t2];
						}
					}
					if (Collision.InTileBounds(item12.Item1, item12.Item2, x, y, x1, y1))
					{
						item1 = item12.Item1;
						item2 = item12.Item2;
					}
				}
				tuples22.Clear();
			}
			if (item.createTile == 82 && item1 == -1 && item2 == -1)
			{
				int num28 = item.placeStyle;
				List<Tuple<int, int>> tuples23 = new List<Tuple<int, int>>();
				for (int u2 = x; u2 <= x1; u2++)
				{
					for (int v2 = y; v2 <= y1; v2++)
					{
						Tile tile22 = Main.tile[u2, v2];
						Tile tile23 = Main.tile[u2, v2 + 1];
						if ((!tile22.active() || TileID.Sets.BreakableWhenPlacing[tile22.type] || Main.tileCut[tile22.type] && tile22.type != 82 && tile22.type != 83) && tile23.nactive() && !tile23.halfBrick() && tile23.slope() == 0)
						{
							if (num28 == 0)
							{
								if (tile23.type == 78 || tile23.type == 380 || tile23.type == 2 || tile23.type == 109)
								{
									if (tile22.liquid <= 0)
									{
										goto Label8;
									}
									continue;
								}
								else
								{
									continue;
								}
							}
							else if (num28 == 1)
							{
								if (tile23.type == 78 || tile23.type == 380 || tile23.type == 60)
								{
									if (tile22.liquid <= 0)
									{
										goto Label8;
									}
									continue;
								}
								else
								{
									continue;
								}
							}
							else if (num28 == 2)
							{
								if (tile23.type == 78 || tile23.type == 380 || tile23.type == 0 || tile23.type == 59)
								{
									if (tile22.liquid <= 0)
									{
										goto Label8;
									}
									continue;
								}
								else
								{
									continue;
								}
							}
							else if (num28 == 3)
							{
								if (tile23.type == 78 || tile23.type == 380 || tile23.type == 203 || tile23.type == 199 || tile23.type == 23 || tile23.type == 25)
								{
									if (tile22.liquid <= 0)
									{
										goto Label8;
									}
									continue;
								}
								else
								{
									continue;
								}
							}
							else if (num28 == 4)
							{
								if (tile23.type == 78 || tile23.type == 380 || tile23.type == 53 || tile23.type == 116)
								{
									if (tile22.liquid <= 0 || !tile22.lava())
									{
										goto Label8;
									}
									continue;
								}
								else
								{
									continue;
								}
							}
							else if (num28 == 5)
							{
								if (tile23.type == 78 || tile23.type == 380 || tile23.type == 57)
								{
									if (tile22.liquid <= 0 || tile22.lava())
									{
										goto Label8;
									}
									continue;
								}
								else
								{
									continue;
								}
							}
							else if (num28 == 6 && (tile23.type != 78 && tile23.type != 380 && tile23.type != 147 && tile23.type != 161 && tile23.type != 163 && tile23.type != 164 && tile23.type != 200 || tile22.liquid > 0 && tile22.lava()))
							{
								continue;
							}
						Label8:
							tuples23.Add(new Tuple<int, int>(u2, v2));
						}
					}
				}
				if (tuples23.Count > 0)
				{
					float single34 = -1f;
					Tuple<int, int> tuple12 = tuples23[0];
					for (int w2 = 0; w2 < tuples23.Count; w2++)
					{
						float single35 = Vector2.Distance((new Vector2((float)tuples23[w2].Item1, (float)tuples23[w2].Item2) * 16f) + (Vector2.One * 8f), vector2);
						if (single34 == -1f || single35 < single34)
						{
							single34 = single35;
							tuple12 = tuples23[w2];
						}
					}
					if (Collision.InTileBounds(tuple12.Item1, tuple12.Item2, x, y, x1, y1))
					{
						item1 = tuple12.Item1;
						item2 = tuple12.Item2;
					}
				}
				tuples23.Clear();
			}
			if (item.createTile == 380 && item1 == -1 && item2 == -1)
			{
				List<Tuple<int, int>> tuples24 = new List<Tuple<int, int>>();
				bool flag13 = false;
				if (Main.tile[num1, num2].active() && Main.tile[num1, num2].type == TileID.PlanterBox)
				{
					flag13 = true;
				}
				if (!flag13)
				{
					for (int x21 = x; x21 <= x1; x21++)
					{
						for (int y21 = y; y21 <= y1; y21++)
						{
							Tile tile24 = Main.tile[x21, y21];
							if (tile24.active() && tile24.type == 380)
							{
								if (!Main.tile[x21 - 1, y21].active() || Main.tileCut[Main.tile[x21 - 1, y21].type] || TileID.Sets.BreakableWhenPlacing[Main.tile[x21 - 1, y21].type])
								{
									tuples24.Add(new Tuple<int, int>(x21 - 1, y21));
								}
								if (!Main.tile[x21 + 1, y21].active() || Main.tileCut[Main.tile[x21 + 1, y21].type] || TileID.Sets.BreakableWhenPlacing[Main.tile[x21 + 1, y21].type])
								{
									tuples24.Add(new Tuple<int, int>(x21 + 1, y21));
								}
							}
						}
					}
				}
				if (tuples24.Count > 0)
				{
					float single36 = -1f;
					Tuple<int, int> item13 = tuples24[0];
					for (int a2 = 0; a2 < tuples24.Count; a2++)
					{
						float single37 = Vector2.Distance((new Vector2((float)tuples24[a2].Item1, (float)tuples24[a2].Item2) * 16f) + (Vector2.One * 8f), vector2);
						if (single36 == -1f || single37 < single36)
						{
							single36 = single37;
							item13 = tuples24[a2];
						}
					}
					if (Collision.InTileBounds(item13.Item1, item13.Item2, x, y, x1, y1) && single36 != -1f)
					{
						item1 = item13.Item1;
						item2 = item13.Item2;
					}
				}
				tuples24.Clear();
			}
			if (item.createTile == 78 && item1 == -1 && item2 == -1)
			{
				List<Tuple<int, int>> tuples25 = new List<Tuple<int, int>>();
				bool flag14 = false;
				if (Main.tile[num1, num2].active())
				{
					flag14 = true;
				}
				if (!Collision.InTileBounds(num1, num2, x, y, x1, y1))
				{
					flag14 = true;
				}
				if (!flag14)
				{
					for (int b2 = x; b2 <= x1; b2++)
					{
						for (int c2 = y; c2 <= y1; c2++)
						{
							Tile tile25 = Main.tile[b2, c2];
							Tile tile26 = Main.tile[b2, c2 + 1];
							if ((!tile25.active() || Main.tileCut[tile25.type] || TileID.Sets.BreakableWhenPlacing[tile25.type]) && tile26.nactive() && !tile26.halfBrick() && tile26.slope() == 0 && Main.tileSolid[tile26.type])
							{
								tuples25.Add(new Tuple<int, int>(b2, c2));
							}
						}
					}
				}
				if (tuples25.Count > 0)
				{
					float single38 = -1f;
					Tuple<int, int> tuple13 = tuples25[0];
					for (int d2 = 0; d2 < tuples25.Count; d2++)
					{
						if (Collision.EmptyTile(tuples25[d2].Item1, tuples25[d2].Item2, true))
						{
							float single39 = Vector2.Distance((new Vector2((float)tuples25[d2].Item1, (float)tuples25[d2].Item2) * 16f) + (Vector2.One * 8f), vector2);
							if (single38 == -1f || single39 < single38)
							{
								single38 = single39;
								tuple13 = tuples25[d2];
							}
						}
					}
					if (Collision.InTileBounds(tuple13.Item1, tuple13.Item2, x, y, x1, y1) && single38 != -1f)
					{
						item1 = tuple13.Item1;
						item2 = tuple13.Item2;
					}
				}
				tuples25.Clear();
			}
			if (item.type == ItemID.StaffofRegrowth && item1 == -1 && item2 == -1)
			{
				List<Tuple<int, int>> tuples26 = new List<Tuple<int, int>>();
				for (int e2 = x; e2 <= x1; e2++)
				{
					for (int f2 = y; f2 <= y1; f2++)
					{
						Tile tile27 = Main.tile[e2, f2];
						bool flag15 = (!Main.tile[e2 - 1, f2].active() || !Main.tile[e2, f2 + 1].active() || !Main.tile[e2 + 1, f2].active() ? true : !Main.tile[e2, f2 - 1].active());
						bool flag16 = (!Main.tile[e2 - 1, f2 - 1].active() || !Main.tile[e2 - 1, f2 + 1].active() || !Main.tile[e2 + 1, f2 + 1].active() ? true : !Main.tile[e2 + 1, f2 - 1].active());
						if (tile27.active() && !tile27.inActive() && (tile27.type == 0 || tile27.type == 1) && (flag15 || tile27.type == 0 && flag16))
						{
							tuples26.Add(new Tuple<int, int>(e2, f2));
						}
					}
				}
				if (tuples26.Count > 0)
				{
					float single40 = -1f;
					Tuple<int, int> item14 = tuples26[0];
					for (int g2 = 0; g2 < tuples26.Count; g2++)
					{
						float single41 = Vector2.Distance((new Vector2((float)tuples26[g2].Item1, (float)tuples26[g2].Item2) * 16f) + (Vector2.One * 8f), vector2);
						if (single40 == -1f || single41 < single40)
						{
							single40 = single41;
							item14 = tuples26[g2];
						}
					}
					if (Collision.InTileBounds(item14.Item1, item14.Item2, x, y, x1, y1))
					{
						item1 = item14.Item1;
						item2 = item14.Item2;
					}
				}
				tuples26.Clear();
			}
			if (item1 != -1 && item2 != -1)
			{
				int num29 = item1;
				Player.tileTargetX = num29;
				Main.smartDigX = num29;
				int num30 = item2;
				Player.tileTargetY = num30;
				Main.smartDigY = num30;
				Main.smartDigShowing = true;
			}
			tuples.Clear();
		}

		public void SmartitemLookup()
		{
			if (!this.controlTorch || this.itemAnimation != 0)
			{
				if (this.nonTorch > -1 && this.itemAnimation == 0)
				{
					this.selectedItem = this.nonTorch;
					this.nonTorch = -1;
				}
				return;
			}
			int num = 0;
			int x = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
			int y = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
			if (this.gravDir == -1f)
			{
				y = (int)((Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16f);
			}
			int num1 = -10;
			int num2 = -10;
			int num3 = -10;
			int num4 = -10;
			int num5 = -10;
			for (int i = 0; i < 50; i++)
			{
				if (this.inventory[i].pick > 0 && num1 == -10)
				{
					num1 = this.inventory[i].tileBoost;
				}
				if (this.inventory[i].axe > 0 && num2 == -10)
				{
					num2 = this.inventory[i].tileBoost;
				}
				if (this.inventory[i].hammer > 0 && num3 == -10)
				{
					num3 = this.inventory[i].tileBoost;
				}
				if ((this.inventory[i].type == 929 || this.inventory[i].type == 1338 || this.inventory[i].type == 1345) && num4 == -10)
				{
					num4 = this.inventory[i].tileBoost;
				}
				if ((this.inventory[i].type == 424 || this.inventory[i].type == 1103) && num5 == -10)
				{
					num5 = this.inventory[i].tileBoost;
				}
			}
			int x1 = 0;
			int y1 = 0;
			if (this.position.X / 16f >= (float)x)
			{
				x1 = (int)(this.position.X / 16f) - x;
			}
			if ((this.position.X + (float)this.width) / 16f <= (float)x)
			{
				x1 = x - (int)((this.position.X + (float)this.width) / 16f);
			}
			if (this.position.Y / 16f >= (float)y)
			{
				y1 = (int)(this.position.Y / 16f) - y;
			}
			if ((this.position.Y + (float)this.height) / 16f <= (float)y)
			{
				y1 = y - (int)((this.position.Y + (float)this.height) / 16f);
			}
			bool flag = false;
			bool flag1 = false;
			try
			{
				flag1 = Main.tile[x, y].liquid > 0;
				if (Main.tile[x, y].active())
				{
					int num6 = Main.tile[x, y].type;
					if (num6 == 219 && x1 <= num5 + Player.tileRangeX && y1 <= num5 + Player.tileRangeY)
					{
						num = 7;
						flag = true;
					}
					else if (num6 == 209 && x1 <= num4 + Player.tileRangeX && y1 <= num4 + Player.tileRangeY)
					{
						num = 6;
						flag = true;
					}
					else if (Main.tileHammer[num6] && x1 <= num3 + Player.tileRangeX && y1 <= num3 + Player.tileRangeY)
					{
						num = 1;
						flag = true;
					}
					else if (Main.tileAxe[num6] && x1 <= num2 + Player.tileRangeX && y1 <= num2 + Player.tileRangeY)
					{
						num = 2;
						flag = true;
					}
					else if (x1 <= num1 + Player.tileRangeX && y1 <= num1 + Player.tileRangeY)
					{
						num = 3;
						flag = true;
					}
				}
				else if (flag1 && this.wet)
				{
					num = 4;
					flag = true;
				}
			}
			catch (Exception ex)
			{
#if DEBUG
				Console.WriteLine(ex);
				System.Diagnostics.Debugger.Break();

#endif
			}
			if (!flag && this.wet)
			{
				num = 4;
			}
			if (num == 0 || num == 4)
			{
				float single = Math.Abs((float)Main.mouseX + Main.screenPosition.X - (this.position.X + (float)(this.width / 2)));
				float single1 = Math.Abs((float)Main.mouseY + Main.screenPosition.Y - (this.position.Y + (float)(this.height / 2))) * 1.3f;
				if ((float)Math.Sqrt((double)(single * single + single1 * single1)) > 200f)
				{
					num = 5;
				}
			}
			for (int j = 0; j < 50; j++)
			{
				int num7 = this.inventory[j].type;
				if (num == 0)
				{
					if (num7 == 8 || num7 == 427 || num7 == 428 || num7 == 429 || num7 == 430 || num7 == 431 || num7 == 432 || num7 == 433 || num7 == 523 || num7 == 974 || num7 == 1245 || num7 == 1333 || num7 == 2274 || num7 == 3004 || num7 == 3045 || num7 == 3114)
					{
						if (this.nonTorch == -1)
						{
							this.nonTorch = this.selectedItem;
						}
						this.selectedItem = j;
						return;
					}
					if (num7 == 282 || num7 == 286 || num7 == 3002 || num7 == 3112)
					{
						if (this.nonTorch == -1)
						{
							this.nonTorch = this.selectedItem;
						}
						this.selectedItem = j;
					}
				}
				else if (num == 1)
				{
					if (this.inventory[j].hammer > 0)
					{
						if (this.nonTorch == -1)
						{
							this.nonTorch = this.selectedItem;
						}
						this.selectedItem = j;
						return;
					}
				}
				else if (num == 2)
				{
					if (this.inventory[j].axe > 0)
					{
						if (this.nonTorch == -1)
						{
							this.nonTorch = this.selectedItem;
						}
						this.selectedItem = j;
						return;
					}
				}
				else if (num == 3)
				{
					if (this.inventory[j].pick > 0)
					{
						if (this.nonTorch == -1)
						{
							this.nonTorch = this.selectedItem;
						}
						this.selectedItem = j;
						return;
					}
				}
				else if (num == 4)
				{
					if (this.inventory[j].type == 282 || this.inventory[j].type == 286 || this.inventory[j].type == 3002 || this.inventory[j].type == 3112 || this.inventory[j].type == 930 || num7 != 8 && num7 != 427 && num7 != 428 && num7 != 429 && num7 != 430 && num7 != 431 && num7 != 432 && num7 != 433 && num7 != 974 && num7 != 1245 && num7 != 2274 && num7 != 3004 && num7 != 3045 && num7 != 3114)
					{
						if ((num7 == 282 || num7 == 286 || num7 == 3002 || num7 == 3112) && flag1)
						{
							if (this.nonTorch == -1)
							{
								this.nonTorch = this.selectedItem;
							}
							this.selectedItem = j;
							return;
						}
						if (num7 == 930 && flag1)
						{
							bool flag2 = false;
							int num8 = 57;
							while (num8 >= 0)
							{
								if (this.inventory[num8].ammo != this.inventory[j].useAmmo)
								{
									num8--;
								}
								else
								{
									flag2 = true;
									break;
								}
							}
							if (flag2)
							{
								if (this.nonTorch == -1)
								{
									this.nonTorch = this.selectedItem;
								}
								this.selectedItem = j;
								return;
							}
						}
						else if (num7 == 1333 || num7 == 523)
						{
							if (this.nonTorch == -1)
							{
								this.nonTorch = this.selectedItem;
							}
							this.selectedItem = j;
							return;
						}
					}
					else
					{
						if (this.nonTorch == -1)
						{
							this.nonTorch = this.selectedItem;
						}
						if (this.inventory[this.selectedItem].createTile != 4)
						{
							this.selectedItem = j;
						}
					}
				}
				else if (num != 5)
				{
					if (num == 6)
					{
						int num9 = 929;
						if (Main.tile[x, y].frameX >= 144)
						{
							num9 = 1345;
						}
						else if (Main.tile[x, y].frameX >= 72)
						{
							num9 = 1338;
						}
						if (num7 == num9)
						{
							if (this.nonTorch == -1)
							{
								this.nonTorch = this.selectedItem;
							}
							this.selectedItem = j;
							return;
						}
					}
					else if (num == 7 && ItemID.Sets.ExtractinatorMode[num7] >= 0)
					{
						if (this.nonTorch == -1)
						{
							this.nonTorch = this.selectedItem;
						}
						this.selectedItem = j;
						return;
					}
				}
				else if (num7 == 8 || num7 == 427 || num7 == 428 || num7 == 429 || num7 == 430 || num7 == 431 || num7 == 432 || num7 == 433 || num7 == 523 || num7 == 974 || num7 == 1245 || num7 == 1333 || num7 == 2274 || num7 == 3004 || num7 == 3045 || num7 == 3114)
				{
					if (this.nonTorch == -1)
					{
						this.nonTorch = this.selectedItem;
					}
					if (this.inventory[this.selectedItem].createTile != 4)
					{
						this.selectedItem = j;
					}
				}
				else if (num7 == 930)
				{
					bool flag3 = false;
					int num10 = 57;
					while (num10 >= 0)
					{
						if (this.inventory[num10].ammo != this.inventory[j].useAmmo)
						{
							num10--;
						}
						else
						{
							flag3 = true;
							break;
						}
					}
					if (flag3)
					{
						if (this.nonTorch == -1)
						{
							this.nonTorch = this.selectedItem;
						}
						this.selectedItem = j;
						return;
					}
				}
				else if (num7 == 282 || num7 == 286 || num7 == 3002 || num7 == 3112)
				{
					if (this.nonTorch == -1)
					{
						this.nonTorch = this.selectedItem;
					}
					this.selectedItem = j;
					return;
				}
			}
		}

		public void Spawn()
		{
			Main.InitLifeBytes();
			if (this.whoAmI == Main.myPlayer)
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
			if (Main.netMode == 1 && this.whoAmI == Main.myPlayer)
			{
				NetMessage.SendData((int)PacketTypes.PlayerSpawn, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
				Main.gameMenu = false;
			}
			this.headPosition = Vector2.Zero;
			this.bodyPosition = Vector2.Zero;
			this.legPosition = Vector2.Zero;
			this.headRotation = 0f;
			this.bodyRotation = 0f;
			this.legRotation = 0f;
			this.lavaTime = this.lavaMax;
			if (this.statLife <= 0)
			{
				int num = this.statLifeMax2 / 2;
				this.statLife = 100;
				if (num > this.statLife)
				{
					this.statLife = num;
				}
				this.breath = this.breathMax;
				if (this.spawnMax)
				{
					this.statLife = this.statLifeMax2;
					this.statMana = this.statManaMax2;
				}
			}
			this.immune = true;
			this.dead = false;
			this.immuneTime = 0;
			this.active = true;
			if (this.SpawnX < 0 || this.SpawnY < 0)
			{
				this.position.X = (float)(Main.spawnTileX * 16 + 8 - this.width / 2);
				this.position.Y = (float)(Main.spawnTileY * 16 - this.height);
				for (int i = Main.spawnTileX - 1; i < Main.spawnTileX + 2; i++)
				{
					for (int j = Main.spawnTileY - 3; j < Main.spawnTileY; j++)
					{
						if (Main.tileSolid[Main.tile[i, j].type] && !Main.tileSolidTop[Main.tile[i, j].type])
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
			else
			{
				this.position.X = (float)(this.SpawnX * 16 + 8 - this.width / 2);
				this.position.Y = (float)(this.SpawnY * 16 - this.height);
			}
			this.wet = false;
			this.wetCount = 0;
			this.lavaWet = false;
			this.fallStart = (int)(this.position.Y / 16f);
			this.fallStart2 = this.fallStart;
			this.velocity.X = 0f;
			this.velocity.Y = 0f;
			for (int k = 0; k < 3; k++)
			{
				this.UpdateSocialShadow();
			}
			this.oldPosition = this.position;
			this.talkNPC = -1;
			if (this.whoAmI == Main.myPlayer)
			{
				Main.npcChatCornerItem = 0;
			}
			if (!this.pvpDeath)
			{
				this.immuneTime = 60;
			}
			else
			{
				this.pvpDeath = false;
				this.immuneTime = 300;
				this.statLife = this.statLifeMax;
			}
			if (this.whoAmI == Main.myPlayer)
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

		private void SporeSac()
		{
			int num = 70;
			float single = 1.5f;
			if (Main.rand.Next(15) == 0)
			{
				int num1 = 0;
				for (int i = 0; i < 1000; i++)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == this.whoAmI && (Main.projectile[i].type == ProjectileID.SporeTrap || Main.projectile[i].type == ProjectileID.SporeTrap2))
					{
						num1++;
					}
				}
				if (Main.rand.Next(15) >= num1 && num1 < 10)
				{
					int num2 = 50;
					int num3 = 24;
					int num4 = 90;
					for (int j = 0; j < num2; j++)
					{
						int num5 = Main.rand.Next(200 - j * 2, 400 + j * 2);
						Vector2 center = base.Center;
						center.X = center.X + (float)Main.rand.Next(-num5, num5 + 1);
						center.Y = center.Y + (float)Main.rand.Next(-num5, num5 + 1);
						if (!Collision.SolidCollision(center, num3, num3) && !Collision.WetCollision(center, num3, num3))
						{
							center.X = center.X + (float)(num3 / 2);
							center.Y = center.Y + (float)(num3 / 2);
							if (Collision.CanHit(new Vector2(base.Center.X, this.position.Y), 1, 1, center, 1, 1) || Collision.CanHit(new Vector2(base.Center.X, this.position.Y - 50f), 1, 1, center, 1, 1))
							{
								int x = (int)center.X / 16;
								int y = (int)center.Y / 16;
								bool flag = false;
								if (Main.rand.Next(3) != 0 || Main.tile[x, y] == null || Main.tile[x, y].wall <= WallID.None)
								{
									center.X = center.X - (float)(num4 / 2);
									center.Y = center.Y - (float)(num4 / 2);
									if (Collision.SolidCollision(center, num4, num4))
									{
										center.X = center.X + (float)(num4 / 2);
										center.Y = center.Y + (float)(num4 / 2);
										flag = true;
									}
								}
								else
								{
									flag = true;
								}
								if (flag)
								{
									int num6 = 0;
									while (num6 < 1000)
									{
										if (!Main.projectile[num6].active || Main.projectile[num6].owner != this.whoAmI || Main.projectile[num6].aiStyle != 105 || (center - Main.projectile[num6].Center).Length() >= 48f)
										{
											num6++;
										}
										else
										{
											flag = false;
											break;
										}
									}
									if (flag)
									{
										Projectile.NewProjectile(center.X, center.Y, 0f, 0f, 567 + Main.rand.Next(2), num, single, this.whoAmI, 0f, 0f);
										return;
									}
								}
							}
						}
					}
				}
			}
		}

		public void StatusNPC(int type, int i)
		{
			if (this.meleeEnchant > 0)
			{
				if (this.meleeEnchant == 1)
				{
					Main.npc[i].AddBuff(BuffID.Venom, 60 * Main.rand.Next(5, 10), false);
				}
				if (this.meleeEnchant == 2)
				{
					Main.npc[i].AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(3, 7), false);
				}
				if (this.meleeEnchant == 3)
				{
					Main.npc[i].AddBuff(BuffID.OnFire, 60 * Main.rand.Next(3, 7), false);
				}
				if (this.meleeEnchant == 5)
				{
					Main.npc[i].AddBuff(BuffID.Ichor, 60 * Main.rand.Next(10, 20), false);
				}
				if (this.meleeEnchant == 6)
				{
					Main.npc[i].AddBuff(BuffID.Confused, 60 * Main.rand.Next(1, 4), false);
				}
				if (this.meleeEnchant == 8)
				{
					Main.npc[i].AddBuff(BuffID.Poisoned, 60 * Main.rand.Next(5, 10), false);
				}
				if (this.meleeEnchant == 4)
				{
					Main.npc[i].AddBuff(BuffID.Midas, 120, false);
				}
			}
			if (this.frostBurn)
			{
				Main.npc[i].AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(5, 15), false);
			}
			if (this.magmaStone)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.npc[i].AddBuff(BuffID.OnFire, 360, false);
				}
				else if (Main.rand.Next(2) != 0)
				{
					Main.npc[i].AddBuff(BuffID.OnFire, 120, false);
				}
				else
				{
					Main.npc[i].AddBuff(BuffID.OnFire, 240, false);
				}
			}
			if (type == 3211)
			{
				Main.npc[i].AddBuff(BuffID.Ichor, 60 * Main.rand.Next(5, 10), false);
			}
			if (type == 121)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(BuffID.OnFire, 180, false);
					return;
				}
			}
			else if (type == 122)
			{
				if (Main.rand.Next(10) == 0)
				{
					Main.npc[i].AddBuff(BuffID.OnFire, 180, false);
					return;
				}
			}
			else if (type == 190)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.npc[i].AddBuff(BuffID.Poisoned, 420, false);
					return;
				}
			}
			else if (type == 217)
			{
				if (Main.rand.Next(5) == 0)
				{
					Main.npc[i].AddBuff(BuffID.OnFire, 180, false);
					return;
				}
			}
			else if (type == 1123 && Main.rand.Next(10) != 0)
			{
				Main.npc[i].AddBuff(BuffID.Confused, 120, false);
			}
		}

		public void StatusPlayer(NPC npc)
		{
			if (Main.expertMode && (npc.type == 266 && Main.rand.Next(3) == 0 || npc.type == 267))
			{
				int num = Main.rand.Next(9);
				if (num == 2 || num == 4)
				{
					num = Main.rand.Next(9);
				}
				float single = (float)Main.rand.Next(75, 150) * 0.01f;
				if (num == 0)
				{
					this.AddBuff(BuffID.Poisoned, (int)(60f * single * 3.5f), true);
				}
				else if (num == 1)
				{
					this.AddBuff(BuffID.Darkness, (int)(60f * single * 2f), true);
				}
				else if (num == 2)
				{
					this.AddBuff(BuffID.Cursed, (int)(60f * single * 0.5f), true);
				}
				else if (num == 3)
				{
					this.AddBuff(BuffID.Bleeding, (int)(60f * single * 5f), true);
				}
				else if (num == 4)
				{
					this.AddBuff(BuffID.Confused, (int)(60f * single * 1f), true);
				}
				else if (num == 5)
				{
					this.AddBuff(BuffID.Slow, (int)(60f * single * 3.5f), true);
				}
				else if (num == 6)
				{
					this.AddBuff(BuffID.Weak, (int)(60f * single * 7.5f), true);
				}
				else if (num == 7)
				{
					this.AddBuff(BuffID.Silenced, (int)(60f * single * 1f), true);
				}
				else if (num == 8)
				{
					this.AddBuff(BuffID.BrokenArmor, (int)((double)(60f * single) * 6.5), true);
				}
			}
			if (npc.type == 159 || npc.type == 158)
			{
				this.AddBuff(BuffID.Bleeding, Main.rand.Next(300, 600), true);
			}
			if (npc.type == 525)
			{
				this.AddBuff(BuffID.CursedInferno, 420, true);
			}
			if (npc.type == 526)
			{
				this.AddBuff(BuffID.Ichor, 420, true);
			}
			if (npc.type == 527)
			{
				this.AddBuff(BuffID.Confused, 840, true);
			}
			if (Main.expertMode && (npc.type == 49 || npc.type == 93 || npc.type == 51 || npc.type == 152) && Main.rand.Next(10) == 0)
			{
				this.AddBuff(BuffID.Rabies, Main.rand.Next(1800, 5400), true);
			}
			if (Main.expertMode && npc.type == 222)
			{
				this.AddBuff(BuffID.Poisoned, Main.rand.Next(60, 240), true);
			}
			if (Main.expertMode && (npc.type == 210 || npc.type == 211))
			{
				this.AddBuff(BuffID.Poisoned, Main.rand.Next(60, 180), true);
			}
			if (Main.expertMode && npc.type == 35)
			{
				this.AddBuff(BuffID.Bleeding, Main.rand.Next(180, 300), true);
			}
			if (Main.expertMode && npc.type == 36 && Main.rand.Next(2) == 0)
			{
				this.AddBuff(BuffID.Slow, Main.rand.Next(30, 60), true);
			}
			if (npc.type >= 269 && npc.type <= 272)
			{
				if (Main.rand.Next(3) == 0)
				{
					this.AddBuff(BuffID.Bleeding, 600, true);
				}
				else if (Main.rand.Next(3) == 0)
				{
					this.AddBuff(BuffID.Slow, 300, true);
				}
			}
			if (npc.type >= 273 && npc.type <= 276 && Main.rand.Next(2) == 0)
			{
				this.AddBuff(BuffID.BrokenArmor, 600, true);
			}
			if (npc.type >= 277 && npc.type <= 280)
			{
				this.AddBuff(BuffID.OnFire, 600, true);
			}
			if (npc.type == 371)
			{
				this.AddBuff(BuffID.Wet, 60 * Main.rand.Next(3, 8), true);
			}
			if (npc.type == 370 && Main.expertMode)
			{
				Random random = Main.rand;
				int[] numArray = new int[] { 0, 148, 30 };
				int num1 = Terraria.Utils.SelectRandom<int>(random, numArray);
				if (num1 != 0)
				{
					this.AddBuff(num1, 60 * Main.rand.Next(3, 11), true);
				}
			}
			if ((npc.type == 1 && npc.name == "Black Slime" || npc.type == 81 || npc.type == 79) && Main.rand.Next(4) == 0)
			{
				this.AddBuff(BuffID.Darkness, 900, true);
			}
			if ((npc.type == 23 || npc.type == 25) && Main.rand.Next(3) == 0)
			{
				this.AddBuff(BuffID.OnFire, 420, true);
			}
			if ((npc.type == 34 || npc.type == 83 || npc.type == 84) && Main.rand.Next(3) == 0)
			{
				this.AddBuff(BuffID.Cursed, 240, true);
			}
			if ((npc.type == 104 || npc.type == 102) && Main.rand.Next(8) == 0)
			{
				this.AddBuff(BuffID.Bleeding, 2700, true);
			}
			if (npc.type == 75 && Main.rand.Next(10) == 0)
			{
				this.AddBuff(BuffID.Silenced, 420, true);
			}
			if ((npc.type == 163 || npc.type == 238) && Main.rand.Next(10) == 0)
			{
				this.AddBuff(BuffID.Venom, 480, true);
			}
			if ((npc.type == 79 || npc.type == 103) && Main.rand.Next(5) == 0)
			{
				this.AddBuff(BuffID.Silenced, 420, true);
			}
			if ((npc.type == 75 || npc.type == 78 || npc.type == 82) && Main.rand.Next(8) == 0)
			{
				this.AddBuff(BuffID.Slow, 900, true);
			}
			if ((npc.type == 93 || npc.type == 109 || npc.type == 80) && Main.rand.Next(14) == 0)
			{
				this.AddBuff(BuffID.Confused, 300, true);
			}
			if (npc.type >= 305 && npc.type <= 314 && Main.rand.Next(10) == 0)
			{
				this.AddBuff(BuffID.Weak, 3600, true);
			}
			if (npc.type == 77 && Main.rand.Next(6) == 0)
			{
				this.AddBuff(BuffID.BrokenArmor, 7200, true);
			}
			if (npc.type == 112 && Main.rand.Next(20) == 0)
			{
				this.AddBuff(BuffID.Weak, 18000, true);
			}
			if (npc.type == 182 && Main.rand.Next(25) == 0)
			{
				this.AddBuff(BuffID.Weak, 7200, true);
			}
			if (npc.type == 141 && Main.rand.Next(2) == 0)
			{
				this.AddBuff(BuffID.Poisoned, 600, true);
			}
			if (npc.type == 147 && !this.frozen && Main.rand.Next(12) == 0)
			{
				this.AddBuff(BuffID.Chilled, 600, true);
			}
			if (npc.type == 150)
			{
				if (Main.rand.Next(2) == 0)
				{
					this.AddBuff(BuffID.Chilled, 900, true);
				}
				if (!this.frozen && Main.rand.Next(35) == 0)
				{
					this.AddBuff(BuffID.Frozen, 60, true);
				}
				else if (!this.frozen && Main.expertMode && Main.rand.Next(35) == 0)
				{
					this.AddBuff(BuffID.Frozen, 60, true);
				}
			}
			if (npc.type == 184)
			{
				this.AddBuff(BuffID.Chilled, 1200, true);
				if (!this.frozen && Main.rand.Next(15) == 0)
				{
					this.AddBuff(BuffID.Frozen, 60, true);
					return;
				}
				if (!this.frozen && Main.expertMode && Main.rand.Next(25) == 0)
				{
					this.AddBuff(BuffID.Frozen, 60, true);
				}
			}
		}

		public void StatusPvP(int type, int i)
		{
			if (this.meleeEnchant > 0)
			{
				if (this.meleeEnchant == 1)
				{
					Main.player[i].AddBuff(BuffID.Venom, 60 * Main.rand.Next(5, 10), true);
				}
				if (this.meleeEnchant == 2)
				{
					Main.player[i].AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(3, 7), true);
				}
				if (this.meleeEnchant == 3)
				{
					Main.player[i].AddBuff(BuffID.OnFire, 60 * Main.rand.Next(3, 7), true);
				}
				if (this.meleeEnchant == 5)
				{
					Main.player[i].AddBuff(BuffID.Ichor, 60 * Main.rand.Next(10, 20), true);
				}
				if (this.meleeEnchant == 6)
				{
					Main.player[i].AddBuff(BuffID.Confused, 60 * Main.rand.Next(1, 4), true);
				}
				if (this.meleeEnchant == 8)
				{
					Main.player[i].AddBuff(BuffID.Poisoned, 60 * Main.rand.Next(5, 10), true);
				}
			}
			if (this.frostBurn)
			{
				Main.player[i].AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(1, 8), true);
			}
			if (this.magmaStone)
			{
				if (Main.rand.Next(7) == 0)
				{
					Main.player[i].AddBuff(BuffID.OnFire, 360, true);
				}
				else if (Main.rand.Next(3) != 0)
				{
					Main.player[i].AddBuff(BuffID.OnFire, 60, true);
				}
				else
				{
					Main.player[i].AddBuff(BuffID.OnFire, 120, true);
				}
			}
			if (type == 121)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(BuffID.OnFire, 180, false);
					return;
				}
			}
			else if (type == 122)
			{
				if (Main.rand.Next(10) == 0)
				{
					Main.player[i].AddBuff(BuffID.OnFire, 180, false);
					return;
				}
			}
			else if (type == 190)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.player[i].AddBuff(BuffID.Poisoned, 420, false);
					return;
				}
			}
			else if (type == 217)
			{
				if (Main.rand.Next(5) == 0)
				{
					Main.player[i].AddBuff(BuffID.OnFire, 180, false);
					return;
				}
			}
			else if (type == 1123 && Main.rand.Next(9) != 0)
			{
				Main.player[i].AddBuff(BuffID.Confused, 120, false);
			}
		}

		public void StickyMovement()
		{
			bool flag = false;
			if (this.mount.Type == 6 && Math.Abs(this.velocity.X) > 5f)
			{
				flag = true;
			}
			if (this.mount.Type == 13 && Math.Abs(this.velocity.X) > 5f)
			{
				flag = true;
			}
			if (this.mount.Type == 11 && Math.Abs(this.velocity.X) > 5f)
			{
				flag = true;
			}
			int num = this.width / 2;
			int num1 = this.height / 2;
			Vector2 vector2 = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num / 2), this.position.Y + (float)(this.height / 2) - (float)(num1 / 2));
			Vector2 vector21 = Collision.StickyTiles(this.position, this.velocity, this.width, this.height);
			if (vector21.Y == -1f || vector21.X == -1f)
			{
				this.stickyBreak = 0;
			}
			else
			{
				int x = (int)vector21.X;
				int y = (int)vector21.Y;
				int num2 = Main.tile[x, y].type;
				if (this.whoAmI == Main.myPlayer && num2 == 51 && (this.velocity.X != 0f || this.velocity.Y != 0f))
				{
					Player player = this;
					player.stickyBreak = player.stickyBreak + 1;
					if (this.stickyBreak > Main.rand.Next(20, 100) || flag)
					{
						this.stickyBreak = 0;
						WorldGen.KillTile(x, y, false, false, false);
						if (Main.netMode == 1 && !Main.tile[x, y].active() && Main.netMode == 1)
						{
							NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)x, (float)y, 0f, 0, 0, 0);
						}
					}
				}
				if (flag)
				{
					return;
				}
				this.fallStart = (int)(this.position.Y / 16f);
				if (num2 != 229)
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
				if (this.velocity.Y >= 0f)
				{
					this.velocity.Y = this.velocity.Y * 0.3f;
				}
				else
				{
					this.velocity.Y = this.velocity.Y * 0.96f;
				}
				if (num2 == 229 && Main.rand.Next(5) == 0 && ((double)this.velocity.Y > 0.15 || this.velocity.Y < 0f))
				{
					if (Main.tile[x, y + 1] != null && Main.tile[x, y + 1].type == 229 && this.position.Y + (float)this.height > (float)((y + 1) * 16))
					{
					}
					if (Main.tile[x, y + 2] != null && Main.tile[x, y + 2].type == 229 && this.position.Y + (float)this.height > (float)((y + 2) * 16))
					{
						return;
					}
				}
			}
		}

		public bool SummonItemCheck()
		{
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && (this.inventory[this.selectedItem].type == 43 && Main.npc[i].type == NPCID.EyeofCthulhu || this.inventory[this.selectedItem].type == 70 && Main.npc[i].type == NPCID.EaterofWorldsHead || this.inventory[this.selectedItem].type == 560 & Main.npc[i].type == NPCID.KingSlime || this.inventory[this.selectedItem].type == 544 && Main.npc[i].type == NPCID.Retinazer || this.inventory[this.selectedItem].type == 544 && Main.npc[i].type == NPCID.Spazmatism || this.inventory[this.selectedItem].type == 556 && Main.npc[i].type == NPCID.TheDestroyer || this.inventory[this.selectedItem].type == 557 && Main.npc[i].type == NPCID.SkeletronPrime || this.inventory[this.selectedItem].type == 1133 && Main.npc[i].type == NPCID.QueenBee || this.inventory[this.selectedItem].type == 1331 && Main.npc[i].type == NPCID.BrainofCthulhu))
				{
					return false;
				}
			}
			return true;
		}

		public void TakeUnityPotion()
		{
			for (int i = 0; i < 400; i++)
			{
				if (this.inventory[i].type == 2997 && this.inventory[i].stack > 0)
				{
					Item item = this.inventory[i];
					item.stack = item.stack - 1;
					if (this.inventory[i].stack <= 0)
					{
						this.inventory[i].SetDefaults(0, false);
					}
					return;
				}
			}
		}

		public void Teleport(Vector2 newPos, int Style = 0, int extraInfo = 0)
		{
			try
			{
				this.grappling[0] = -1;
				this.grapCount = 0;
				for (int i = 0; i < 1000; i++)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == this.whoAmI && Main.projectile[i].aiStyle == 7)
					{
						Main.projectile[i].Kill();
					}
				}
				int num = 0;
				if (Style == 4)
				{
					num = this.lastPortalColorIndex;
				}
				Main.TeleportEffect(this.getRect(), Style, num);
				this.position = newPos;
				this.fallStart = (int)(this.position.Y / 16f);
				if (this.whoAmI == Main.myPlayer)
				{
					Main.BlackFadeIn = 255;
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
				if (Style == 4)
				{
					this.lastPortalColorIndex = extraInfo;
					num = this.lastPortalColorIndex;
					this.justGotOutOfPortal = true;
					this.gravity = 0f;
				}
				for (int j = 0; j < 3; j++)
				{
					this.UpdateSocialShadow();
				}
				this.oldPosition = this.position;
				Main.TeleportEffect(this.getRect(), Style, num);
				this.teleportTime = 1f;
				this.teleportStyle = Style;
			}
			catch (Exception ex)
			{
#if DEBUG
				Console.WriteLine(ex);
				System.Diagnostics.Debugger.Break();

#endif
			}
		}

		public void TeleportationPotion()
		{
			bool flag = false;
			int num = 0;
			int num1 = 0;
			int num2 = 0;
			int num3 = this.width;
			Vector2 vector2 = (new Vector2((float)num1, (float)num2) * 16f) + new Vector2((float)(-num3 / 2 + 8), (float)(-this.height));
			while (!flag && num < 1000)
			{
				num++;
				num1 = 100 + Main.rand.Next(Main.maxTilesX - 200);
				num2 = 100 + Main.rand.Next(Main.maxTilesY - 200);
				vector2 = (new Vector2((float)num1, (float)num2) * 16f) + new Vector2((float)(-num3 / 2 + 8), (float)(-this.height));
				if (Collision.SolidCollision(vector2, num3, this.height))
				{
					continue;
				}
				if (Main.tile[num1, num2] == null)
				{
					Main.tile[num1, num2] = new Tile();
				}
				if (Main.tile[num1, num2].wall == WallID.LihzahrdBrickUnsafe && (double)num2 > Main.worldSurface && !NPC.downedPlantBoss || Main.wallDungeon[Main.tile[num1, num2].wall] && (double)num2 > Main.worldSurface && !NPC.downedBoss3)
				{
					continue;
				}
				int num4 = 0;
				while (num4 < 100)
				{
					if (Main.tile[num1, num2 + num4] == null)
					{
						Main.tile[num1, num2 + num4] = new Tile();
					}
					Tile tile = Main.tile[num1, num2 + num4];
					vector2 = (new Vector2((float)num1, (float)(num2 + num4)) * 16f) + new Vector2((float)(-num3 / 2 + 8), (float)(-this.height));
					Vector4 vector4 = Collision.SlopeCollision(vector2, this.velocity, num3, this.height, this.gravDir, false);
					bool flag1 = !Collision.SolidCollision(vector2, num3, this.height);
					if (vector4.Z == this.velocity.X)
					{
						float y = this.velocity.Y;
					}
					if (!flag1)
					{
						if (tile.active() && !tile.inActive() && Main.tileSolid[tile.type])
						{
							break;
						}
						num4++;
					}
					else
					{
						num4++;
					}
				}
				if (Collision.LavaCollision(vector2, num3, this.height) || Collision.HurtTiles(vector2, this.velocity, num3, this.height, false).Y > 0f)
				{
					continue;
				}
				Collision.SlopeCollision(vector2, this.velocity, num3, this.height, this.gravDir, false);
				if (!Collision.SolidCollision(vector2, num3, this.height) || num4 >= 99)
				{
					continue;
				}
				Vector2 unitX = Vector2.UnitX * 16f;
				if (Collision.TileCollision(vector2 - unitX, unitX, this.width, this.height, false, false, (int)this.gravDir) != unitX)
				{
					continue;
				}
				unitX = -Vector2.UnitX * 16f;
				if (Collision.TileCollision(vector2 - unitX, unitX, this.width, this.height, false, false, (int)this.gravDir) != unitX)
				{
					continue;
				}
				unitX = Vector2.UnitY * 16f;
				if (Collision.TileCollision(vector2 - unitX, unitX, this.width, this.height, false, false, (int)this.gravDir) != unitX)
				{
					continue;
				}
				unitX = -Vector2.UnitY * 16f;
				if (Collision.TileCollision(vector2 - unitX, unitX, this.width, this.height, false, false, (int)this.gravDir) != unitX)
				{
					continue;
				}
				flag = true;
				num2 = num2 + num4;
				break;
			}
			if (flag)
			{
				Vector2 vector21 = vector2;
				this.Teleport(vector21, 2, 0);
				this.velocity = Vector2.Zero;
				if (Main.netMode == 2)
				{
					RemoteClient.CheckSection(this.whoAmI, this.position, 1);
					NetMessage.SendData((int)PacketTypes.Teleport, -1, -1, "", 0, (float)this.whoAmI, vector21.X, vector21.Y, 3, 0, 0);
				}
			}
		}

		public void ToggleInv()
		{
			if (Main.ingameOptionsWindow)
			{
				IngameOptions.Close();
				return;
			}
			if (Main.achievementsWindow)
			{
				return;
			}
			if (this.talkNPC >= 0)
			{
				this.talkNPC = -1;
				Main.npcChatCornerItem = 0;
				Main.npcChatText = "";
				return;
			}
			if (this.sign >= 0)
			{
				this.sign = -1;
				Main.editSign = false;
				Main.npcChatText = "";
				return;
			}
			if (Main.clothesWindow)
			{
				Main.CancelClothesWindow(false);
				return;
			}
			if (Main.playerInventory)
			{
				Main.playerInventory = false;
				Main.EquipPageSelected = 0;
				return;
			}
			Recipe.FindRecipes();
			Main.playerInventory = true;
			Main.EquipPageSelected = 0;
		}

		public void ToggleLight()
		{
			this.hideMisc[1] = !this.hideMisc[1];
			if (this.hideMisc[1])
			{
				this.ClearBuff(this.miscEquips[1].buffType);
				if (this.miscEquips[1].buffType == 27)
				{
					this.ClearBuff(102);
					this.ClearBuff(101);
				}
			}
		}

		public void TogglePet()
		{
			this.hideMisc[0] = !this.hideMisc[0];
			if (this.hideMisc[0])
			{
				this.ClearBuff(this.miscEquips[0].buffType);
			}
		}

		private void TryBouncingBlocks(bool Falling)
		{
			if ((this.velocity.Y >= 5f || this.velocity.Y <= -5f) && !this.wet)
			{
				int y = 0;
				bool flag = false;
				foreach (Point touchedTile in this.TouchedTiles)
				{
					Tile tile = Main.tile[touchedTile.X, touchedTile.Y];
					if (tile == null || !tile.active() || !tile.nactive() || !Main.tileBouncy[tile.type])
					{
						continue;
					}
					flag = true;
					y = touchedTile.Y;
					break;
				}
				if (flag)
				{
					this.velocity.Y = this.velocity.Y * -0.8f;
					if (this.controlJump)
					{
						this.velocity.Y = MathHelper.Clamp(this.velocity.Y, -13f, 13f);
					}
					this.position.Y = (float)(y * 16 - (this.velocity.Y < 0f ? this.height : -16));
					this.FloorVisuals(Falling);
					this.velocity.Y = MathHelper.Clamp(this.velocity.Y, -20f, 20f);
					if (this.velocity.Y * this.gravDir < 0f)
					{
						this.fallStart = (int)this.position.Y / 16;
					}
				}
			}
		}

		private void TryGettingDevArmor()
		{
			if (Main.rand.Next(20) != 0)
			{
				return;
			}
			Main.rand.Next(7);
			switch (Main.rand.Next(12))
			{
				case 0:
				{
					this.QuickSpawnItem(666, 1);
					this.QuickSpawnItem(667, 1);
					this.QuickSpawnItem(668, 1);
					this.QuickSpawnItem(665, 1);
					return;
				}
				case 1:
				{
					this.QuickSpawnItem(1554, 1);
					this.QuickSpawnItem(1555, 1);
					this.QuickSpawnItem(1556, 1);
					this.QuickSpawnItem(1586, 1);
					return;
				}
				case 2:
				{
					this.QuickSpawnItem(1587, 1);
					this.QuickSpawnItem(1588, 1);
					this.QuickSpawnItem(1586, 1);
					return;
				}
				case 3:
				{
					this.QuickSpawnItem(1557, 1);
					this.QuickSpawnItem(1558, 1);
					this.QuickSpawnItem(1559, 1);
					this.QuickSpawnItem(1585, 1);
					return;
				}
				case 4:
				{
					this.QuickSpawnItem(1560, 1);
					this.QuickSpawnItem(1561, 1);
					this.QuickSpawnItem(1562, 1);
					this.QuickSpawnItem(1584, 1);
					return;
				}
				case 5:
				{
					this.QuickSpawnItem(1563, 1);
					this.QuickSpawnItem(1564, 1);
					this.QuickSpawnItem(1565, 1);
					this.QuickSpawnItem(3582, 1);
					return;
				}
				case 6:
				{
					this.QuickSpawnItem(1566, 1);
					this.QuickSpawnItem(1567, 1);
					this.QuickSpawnItem(1568, 1);
					return;
				}
				case 7:
				{
					this.QuickSpawnItem(1580, 1);
					this.QuickSpawnItem(1581, 1);
					this.QuickSpawnItem(1582, 1);
					this.QuickSpawnItem(1583, 1);
					return;
				}
				case 8:
				{
					this.QuickSpawnItem(3226, 1);
					this.QuickSpawnItem(3227, 1);
					this.QuickSpawnItem(3228, 1);
					return;
				}
				case 9:
				{
					this.QuickSpawnItem(3583, 1);
					this.QuickSpawnItem(3581, 1);
					this.QuickSpawnItem(3578, 1);
					this.QuickSpawnItem(3579, 1);
					this.QuickSpawnItem(3580, 1);
					return;
				}
				case 10:
				{
					this.QuickSpawnItem(3585, 1);
					this.QuickSpawnItem(3586, 1);
					this.QuickSpawnItem(3587, 1);
					this.QuickSpawnItem(3588, 1);
					this.QuickSpawnItem(3024, 4);
					return;
				}
				case 11:
				{
					this.QuickSpawnItem(3589, 1);
					this.QuickSpawnItem(3590, 1);
					this.QuickSpawnItem(3591, 1);
					this.QuickSpawnItem(3592, 1);
					this.QuickSpawnItem(3599, 4);
					return;
				}
				default:
				{
					return;
				}
			}
		}

		private void TryLandingOnDetonator()
		{
			if (this.whoAmI != Main.myPlayer)
			{
				return;
			}
			if (this.velocity.Y >= 3f)
			{
				Point tileCoordinates = (base.Bottom + new Vector2(0f, 0.01f)).ToTileCoordinates();
				Tile tileSafely = Framing.GetTileSafely(tileCoordinates.X, tileCoordinates.Y);
				if (tileSafely.active() && tileSafely.type == 411 && tileSafely.frameY == 0 && tileSafely.frameX < 36)
				{
					Wiring.HitSwitch(tileCoordinates.X, tileCoordinates.Y);
					NetMessage.SendData((int)PacketTypes.HitSwitch, -1, -1, "", tileCoordinates.X, (float)tileCoordinates.Y, 0f, 0f, 0, 0, 0);
				}
			}
		}

		public void TryPortalJumping()
		{
			if (this.mount.Active || this.dead)
			{
				return;
			}
			PortalHelper.TryGoingThroughPortals(this);
		}

		public void UnityTeleport(Vector2 telePos)
		{
			int num = 3;
			if (Main.netMode == 0)
			{
				this.Teleport(telePos, num, 0);
				return;
			}
			NetMessage.SendData((int)PacketTypes.Teleport, -1, -1, "", 2, (float)this.whoAmI, telePos.X, telePos.Y, num, 0, 0);
		}

		public void Update(int i)
		{
			Vector2 touchDamageHot;
			float single;
			int type;
			bool flag;
			if (this.launcherWait > 0)
			{
				Player player = this;
				player.launcherWait = player.launcherWait - 1;
			}
			this.maxFallSpeed = 10f;
			this.gravity = Player.defaultGravity;
			Player.jumpHeight = 15;
			Player.jumpSpeed = 5.01f;
			this.maxRunSpeed = 3f;
			this.runAcceleration = 0.08f;
			this.runSlowdown = 0.2f;
			this.accRunSpeed = this.maxRunSpeed;
			if (!this.mount.Active || !this.mount.Cart)
			{
				this.onWrongGround = false;
			}
			this.heldProj = -1;
			if (this.PortalPhysicsEnabled)
			{
				this.maxFallSpeed = 30f;
			}
			if (this.wet)
			{
				if (this.honeyWet)
				{
					this.gravity = 0.1f;
					this.maxFallSpeed = 3f;
				}
				else if (!this.merman)
				{
					this.gravity = 0.2f;
					this.maxFallSpeed = 5f;
					Player.jumpHeight = 30;
					Player.jumpSpeed = 6.01f;
				}
				else
				{
					this.gravity = 0.3f;
					this.maxFallSpeed = 7f;
				}
			}
			if (this.vortexDebuff)
			{
				this.gravity = 0f;
			}
			Player player1 = this;
			player1.maxFallSpeed = player1.maxFallSpeed + 0.01f;
			bool flag1 = false;
			if (Main.myPlayer == i)
			{
				TileObject.objectPreview.Reset();
			}
			if (this.active)
			{
				if (this.ghostDmg > 0f)
				{
					Player player2 = this;
					player2.ghostDmg = player2.ghostDmg - 2.5f;
				}
				if (this.ghostDmg < 0f)
				{
					this.ghostDmg = 0f;
				}
				if (!Main.expertMode)
				{
					if (this.lifeSteal < 80f)
					{
						Player player3 = this;
						player3.lifeSteal = player3.lifeSteal + 0.6f;
					}
					if (this.lifeSteal > 80f)
					{
						this.lifeSteal = 80f;
					}
				}
				else
				{
					if (this.lifeSteal < 70f)
					{
						Player player4 = this;
						player4.lifeSteal = player4.lifeSteal + 0.5f;
					}
					if (this.lifeSteal > 70f)
					{
						this.lifeSteal = 70f;
					}
				}
				if (!this.mount.Active)
				{
					this.position.Y = this.position.Y + (float)this.height;
					this.height = 42;
					this.position.Y = this.position.Y - (float)this.height;
				}
				else
				{
					this.position.Y = this.position.Y + (float)this.height;
					this.height = 42 + this.mount.HeightBoost;
					this.position.Y = this.position.Y - (float)this.height;
				}
				Main.numPlayers = Main.numPlayers + 1;
				this.outOfRange = false;
				if (this.whoAmI != Main.myPlayer)
				{
					int x1 = (int)(this.position.X + (float)(this.width / 2)) / 16;
					int y1 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
					if (!WorldGen.InWorld(x1, y1, 4))
					{
						flag1 = true;
					}
					else if (Main.tile[x1, y1] == null)
					{
						flag1 = true;
					}
					else if (Main.tile[x1 - 3, y1] == null)
					{
						flag1 = true;
					}
					else if (Main.tile[x1 + 3, y1] == null)
					{
						flag1 = true;
					}
					else if (Main.tile[x1, y1 - 3] == null)
					{
						flag1 = true;
					}
					else if (Main.tile[x1, y1 + 3] == null)
					{
						flag1 = true;
					}
					if (flag1)
					{
						this.outOfRange = true;
						this.numMinions = 0;
						this.slotsMinions = 0f;
						this.itemAnimation = 0;
						this.PlayerFrame();
					}
				}
				if (this.tankPet >= 0)
				{
					if (this.tankPetReset)
					{
						this.tankPet = -1;
					}
					else
					{
						this.tankPetReset = true;
					}
				}
			}
			if (this.chatOverhead.timeLeft > 0)
			{
				this.chatOverhead.timeLeft = this.chatOverhead.timeLeft - 1;
			}
			if (!this.active || flag1)
			{
				return;
			}
			Player player5 = this;
			player5.miscCounter = player5.miscCounter + 1;
			if (this.miscCounter >= 300)
			{
				this.miscCounter = 0;
			}
			Player player6 = this;
			player6.infernoCounter = player6.infernoCounter + 1;
			if (this.infernoCounter >= 180)
			{
				this.infernoCounter = 0;
			}
			float single1 = (float)(Main.maxTilesX / 4200);
			single1 = single1 * single1;
			float y2 = (float)((double)(this.position.Y / 16f - (60f + 10f * single1)) / (Main.worldSurface / 6));
			if ((double)y2 < 0.25)
			{
				y2 = 0.25f;
			}
			if (y2 > 1f)
			{
				y2 = 1f;
			}
			Player player7 = this;
			player7.gravity = player7.gravity * y2;
			this.maxRegenDelay = (1f - (float)this.statMana / (float)this.statManaMax2) * 60f * 4f + 45f;
			Player player8 = this;
			player8.maxRegenDelay = player8.maxRegenDelay * 0.7f;
			this.UpdateSocialShadow();
			this.whoAmI = i;
			if (this.whoAmI == Main.myPlayer)
			{
				this.TryPortalJumping();
			}
			if (this.runSoundDelay > 0)
			{
				Player player9 = this;
				player9.runSoundDelay = player9.runSoundDelay - 1;
			}
			if (this.attackCD > 0)
			{
				Player player10 = this;
				player10.attackCD = player10.attackCD - 1;
			}
			if (this.itemAnimation == 0)
			{
				this.attackCD = 0;
			}
			if (this.potionDelay > 0)
			{
				Player player11 = this;
				player11.potionDelay = player11.potionDelay - 1;
			}
			if (i == Main.myPlayer)
			{
				if (Main.trashItem.type >= ItemID.LargeAmethyst && Main.trashItem.type <= ItemID.LargeDiamond)
				{
					Main.trashItem.SetDefaults(0, false);
				}
				this.UpdateBiomes();
				this.UpdateMinionTarget();
			}
			if (this.ghost)
			{
				this.Ghost();
				return;
			}
			if (this.dead)
			{
				this.UpdateDead();
				return;
			}
			if (i == Main.myPlayer)
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
				this.controlSmart = false;
				this.controlMount = false;
				this.mapStyle = false;
				this.mapAlphaDown = false;
				this.mapAlphaUp = false;
				this.mapFullScreen = false;
				this.mapZoomIn = false;
				this.mapZoomOut = false;
				if (this.selectedItem != 58)
				{
					this.SmartitemLookup();
				}
				else
				{
					this.nonTorch = -1;
				}
				if (this.stoned != this.lastStoned)
				{
					if (this.whoAmI == Main.myPlayer && this.stoned)
					{
						int num8 = (int)(20 * (double)Main.damageMultiplier);
						this.Hurt(num8, 0, false, false, Lang.deathMsg(-1, -1, -1, 4), false);
					}
				}
				this.lastStoned = this.stoned;
				if (this.frozen || this.webbed || this.stoned)
				{
					this.controlJump = false;
					this.controlDown = false;
					this.controlLeft = false;
					this.controlRight = false;
					this.controlUp = false;
					this.controlUseItem = false;
					this.controlUseTile = false;
					this.controlThrow = false;
					this.gravDir = 1f;
				}
				if (this.controlThrow)
				{
					this.releaseThrow = false;
				}
				else
				{
					this.releaseThrow = true;
				}
				if (Main.netMode == 1)
				{
					bool flag15 = false;
					if (this.controlUp != Main.clientPlayer.controlUp)
					{
						flag15 = true;
					}
					if (this.controlDown != Main.clientPlayer.controlDown)
					{
						flag15 = true;
					}
					if (this.controlLeft != Main.clientPlayer.controlLeft)
					{
						flag15 = true;
					}
					if (this.controlRight != Main.clientPlayer.controlRight)
					{
						flag15 = true;
					}
					if (this.controlJump != Main.clientPlayer.controlJump)
					{
						flag15 = true;
					}
					if (this.controlUseItem != Main.clientPlayer.controlUseItem)
					{
						flag15 = true;
					}
					if (this.selectedItem != Main.clientPlayer.selectedItem)
					{
						flag15 = true;
					}
					if (flag15)
					{
						NetMessage.SendData((int)PacketTypes.PlayerUpdate, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.playerInventory)
				{
					this.AdjTiles();
				}
				if (this.chest == -1)
				{
					this.flyingPigChest = -1;
				}
				else
				{
					if (this.chest != -2)
					{
						this.flyingPigChest = -1;
					}
					if (this.flyingPigChest < 0)
					{
						int x2 = (int)(((double)this.position.X + (double)this.width * 0.5) / 16);
						int y3 = (int)(((double)this.position.Y + (double)this.height * 0.5) / 16);
						if (x2 < this.chestX - Player.tileRangeX || x2 > this.chestX + Player.tileRangeX + 1 || y3 < this.chestY - Player.tileRangeY || y3 > this.chestY + Player.tileRangeY + 1)
						{
							this.chest = -1;
							Recipe.FindRecipes();
						}
						else if (!Main.tile[this.chestX, this.chestY].active())
						{
							this.chest = -1;
							Recipe.FindRecipes();
						}
					}
					else if (!Main.projectile[this.flyingPigChest].active || Main.projectile[this.flyingPigChest].type != 525)
					{
						this.chest = -1;
						Recipe.FindRecipes();
					}
					else
					{
						int x3 = (int)(((double)this.position.X + (double)this.width * 0.5) / 16);
						int y4 = (int)(((double)this.position.Y + (double)this.height * 0.5) / 16);
						this.chestX = (int)Main.projectile[this.flyingPigChest].Center.X / 16;
						this.chestY = (int)Main.projectile[this.flyingPigChest].Center.Y / 16;
						if (x3 < this.chestX - Player.tileRangeX || x3 > this.chestX + Player.tileRangeX + 1 || y4 < this.chestY - Player.tileRangeY || y4 > this.chestY + Player.tileRangeY + 1)
						{
							this.chest = -1;
							Recipe.FindRecipes();
						}
					}
				}
				if (this.velocity.Y <= 0f)
				{
					this.fallStart2 = (int)(this.position.Y / 16f);
				}
				if (this.velocity.Y == 0f)
				{
					int num12 = 25;
					num12 = num12 + this.extraFall;
					int y5 = (int)(this.position.Y / 16f) - this.fallStart;
					if (this.mount.CanFly)
					{
						y5 = 0;
					}
					if (this.mount.Cart && Minecart.OnTrack(this.position, this.width, this.height))
					{
						y5 = 0;
					}
					if (this.mount.Type == 1)
					{
						y5 = 0;
					}
					this.mount.FatigueRecovery();
					bool flag16 = false;
					for (int o = 3; o < 10; o++)
					{
						if (this.armor[o].stack > 0 && this.armor[o].wingSlot > -1)
						{
							flag16 = true;
						}
					}
					if (this.stoned)
					{
						int num13 = (int)(((float)y5 * this.gravDir - 2f) * 20f);
						if (num13 > 0)
						{
							this.Hurt(num13, 0, false, false, Lang.deathMsg(-1, -1, -1, 4), false);
							this.immune = false;
						}
					}
					else if ((this.gravDir == 1f && y5 > num12 || this.gravDir == -1f && y5 < -num12) && !this.noFallDmg && !flag16)
					{
						this.immune = false;
						int fallDamage = (int)((float)y5 * this.gravDir - (float)num12) * 10;
						if (this.mount.Active)
						{
							fallDamage = (int)((float)fallDamage * this.mount.FallDamage);
						}
						this.Hurt(fallDamage, 0, false, false, Lang.deathMsg(-1, -1, -1, 0), false);
						if (!this.dead && this.statLife <= this.statLifeMax2 / 10)
						{
							AchievementsHelper.HandleSpecialEvent(this, 8);
						}
					}
					this.fallStart = (int)(this.position.Y / 16f);
				}
				if (this.jump > 0 || this.rocketDelay > 0 || this.wet || this.slowFall || (double)y2 < 0.8 || this.tongued)
				{
					this.fallStart = (int)(this.position.Y / 16f);
				}
			}
			if (Main.netMode != 1)
			{
				if (this.chest == -1 && this.lastChest >= 0 && Main.chest[this.lastChest] != null && Main.chest[this.lastChest] != null)
				{
					int num14 = Main.chest[this.lastChest].x;
					int num15 = Main.chest[this.lastChest].y;
					NPC.BigMimicSummonCheck(num14, num15);
				}
				this.lastChest = this.chest;
			}
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
			if (Player.tileTargetX >= Main.maxTilesX - 5)
			{
				Player.tileTargetX = Main.maxTilesX - 5;
			}
			if (Player.tileTargetY >= Main.maxTilesY - 5)
			{
				Player.tileTargetY = Main.maxTilesY - 5;
			}
			if (Player.tileTargetX < 5)
			{
				Player.tileTargetX = 5;
			}
			if (Player.tileTargetY < 5)
			{
				Player.tileTargetY = 5;
			}
			if (Main.tile[Player.tileTargetX - 1, Player.tileTargetY] == null)
			{
				Main.tile[Player.tileTargetX - 1, Player.tileTargetY] = new Tile();
			}
			if (Main.tile[Player.tileTargetX + 1, Player.tileTargetY] == null)
			{
				Main.tile[Player.tileTargetX + 1, Player.tileTargetY] = new Tile();
			}
			if (Main.tile[Player.tileTargetX, Player.tileTargetY] == null)
			{
				Main.tile[Player.tileTargetX, Player.tileTargetY] = new Tile();
			}
			if (!Main.tile[Player.tileTargetX, Player.tileTargetY].active())
			{
				if (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active() && Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type == 323)
				{
					int num16 = Main.tile[Player.tileTargetX - 1, Player.tileTargetY].frameY;
					if (num16 < -4)
					{
						Player.tileTargetX = Player.tileTargetX + 1;
					}
					if (num16 > 4)
					{
						Player.tileTargetX = Player.tileTargetX - 1;
					}
				}
				else if (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active() && Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type == 323)
				{
					int num17 = Main.tile[Player.tileTargetX + 1, Player.tileTargetY].frameY;
					if (num17 < -4)
					{
						Player.tileTargetX = Player.tileTargetX + 1;
					}
					if (num17 > 4)
					{
						Player.tileTargetX = Player.tileTargetX - 1;
					}
				}
			}
			this.SmartCursorLookup();
			this.UpdateImmunity();
			if (this.petalTimer > 0)
			{
				Player player15 = this;
				player15.petalTimer = player15.petalTimer - 1;
			}
			if (this.shadowDodgeTimer > 0)
			{
				Player player16 = this;
				player16.shadowDodgeTimer = player16.shadowDodgeTimer - 1;
			}
			if (this.jump > 0 || this.velocity.Y != 0f)
			{
				this.slippy = false;
				this.slippy2 = false;
				this.powerrun = false;
				this.sticky = false;
			}
			this.potionDelayTime = Item.potionDelay;
			this.restorationDelayTime = Item.restorationDelay;
			if (this.pStone)
			{
				this.potionDelayTime = (int)((double)this.potionDelayTime * 0.75);
				this.restorationDelayTime = (int)((double)this.restorationDelayTime * 0.75);
			}
			if (this.yoraiz0rEye > 0)
			{
				this.Yoraiz0rEye();
			}
			this.ResetEffects();
			this.UpdateDyes(i);
			Player player17 = this;
			player17.meleeCrit = player17.meleeCrit + this.inventory[this.selectedItem].crit;
			Player player18 = this;
			player18.magicCrit = player18.magicCrit + this.inventory[this.selectedItem].crit;
			Player player19 = this;
			player19.rangedCrit = player19.rangedCrit + this.inventory[this.selectedItem].crit;
			Player player20 = this;
			player20.thrownCrit = player20.thrownCrit + this.inventory[this.selectedItem].crit;
			if (this.whoAmI == Main.myPlayer)
			{
				Main.musicBox2 = -1;
				if (Main.waterCandles > 0)
				{
					this.AddBuff(BuffID.WaterCandle, 2, false);
				}
				if (Main.peaceCandles > 0)
				{
					this.AddBuff(BuffID.PeaceCandle, 2, false);
				}
				if (Main.campfire)
				{
					this.AddBuff(BuffID.Campfire, 2, false);
				}
				if (Main.starInBottle)
				{
					this.AddBuff(BuffID.StarInBottle, 2, false);
				}
				if (Main.heartLantern)
				{
					this.AddBuff(BuffID.HeartLamp, 2, false);
				}
				if (Main.sunflower)
				{
					this.AddBuff(BuffID.Sunflower, 2, false);
				}
				if (this.hasBanner)
				{
					this.AddBuff(BuffID.MonsterBanner, 2, false);
				}
			}
			for (int p = 0; p < 191; p++)
			{
				this.buffImmune[p] = false;
			}
			this.UpdateBuffs(i);
			if (this.whoAmI == Main.myPlayer)
			{
				if (!this.onFire && !this.poisoned)
				{
					this.trapDebuffSource = false;
				}
				this.UpdatePet(i);
				this.UpdatePetLight(i);
			}
			bool flag18 = this.wet && !this.lavaWet && (!this.mount.Active || this.mount.Type != 3);
			if (this.accMerman && flag18)
			{
				this.releaseJump = true;
				this.wings = 0;
				this.merman = true;
				this.accFlipper = true;
				this.AddBuff(BuffID.Merfolk, 2, true);
			}
			else
			{
				this.merman = false;
			}
			if (!flag18 && this.forceWerewolf)
			{
				this.forceMerman = false;
			}
			if (this.forceMerman && flag18)
			{
				this.wings = 0;
			}
			this.accMerman = false;
			this.hideMerman = false;
			this.forceMerman = false;
			if (this.wolfAcc && !this.merman && !Main.dayTime && !this.wereWolf)
			{
				this.AddBuff(BuffID.Werewolf, 60, true);
			}
			this.wolfAcc = false;
			this.hideWolf = false;
			this.forceWerewolf = false;
			if (this.whoAmI == Main.myPlayer)
			{
				for (int q = 0; q < 22; q++)
				{
					if (this.buffType[q] > 0 && this.buffTime[q] <= 0)
					{
						this.DelBuff(q);
					}
				}
			}
			this.beetleDefense = false;
			this.beetleOffense = false;
			this.doubleJumpCloud = false;
			this.setSolar = false;
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
			if (this.MountFishronSpecialCounter > 0f)
			{
				Player mountFishronSpecialCounter = this;
				mountFishronSpecialCounter.MountFishronSpecialCounter = mountFishronSpecialCounter.MountFishronSpecialCounter - 1f;
			}
			if (this._portalPhysicsTime > 0)
			{
				Player player21 = this;
				player21._portalPhysicsTime = player21._portalPhysicsTime - 1;
			}
			this.UpdateEquips(i);
			if (this.inventory[this.selectedItem].type == 3384)
			{
				this._portalPhysicsTime = 30;
			}
			if (this.mount.Active)
			{
				this.mount.UpdateEffects(this);
			}
			Player player22 = this;
			player22.gemCount = player22.gemCount + 1;
			if (this.gemCount >= 10)
			{
				this.gem = -1;
				this.gemCount = 0;
				for (int r = 0; r <= 58; r++)
				{
					if (this.inventory[r].type == 0 || this.inventory[r].stack == 0)
					{
						this.inventory[r].type = 0;
						this.inventory[r].stack = 0;
						this.inventory[r].name = "";
						this.inventory[r].netID = 0;
					}
					if (this.inventory[r].type >= 1522 && this.inventory[r].type <= 1527)
					{
						this.gem = this.inventory[r].type - 1522;
					}
				}
			}
			this.UpdateArmorSets(i);
			if ((this.merman || this.forceMerman) && flag18)
			{
				this.wings = 0;
			}
			if (this.invis)
			{
				if (this.itemAnimation == 0 && this.aggro > -750)
				{
					this.aggro = -750;
				}
				else if (this.aggro > -250)
				{
					this.aggro = -250;
				}
			}
			if (this.inventory[this.selectedItem].type == 3106)
			{
				if (this.itemAnimation > 0)
				{
					this.stealthTimer = 15;
					if (this.stealth > 0f)
					{
						Player player23 = this;
						player23.stealth = player23.stealth + 0.1f;
					}
				}
				else if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1 && (double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1 && !this.mount.Active)
				{
					if (this.stealthTimer == 0 && this.stealth > 0f)
					{
						Player player24 = this;
						player24.stealth = player24.stealth - 0.02f;
						if ((double)this.stealth <= 0)
						{
							this.stealth = 0f;
							if (Main.netMode == 1)
							{
								NetMessage.SendData((int)PacketTypes.PlayerStealth, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
							}
						}
					}
				}
				else
				{
					if (this.stealth > 0f)
					{
						this.stealth += 0.1f;
					}
					if (this.mount.Active)
					{
						this.stealth = 1f;
					}
				}
				if (this.stealth > 1f)
				{
					this.stealth = 1f;
				}
				this.meleeDamage += (1f - this.stealth) * 3f;
				this.meleeCrit += (int)((1f - this.stealth) * 30f);
				if (this.meleeCrit > 100)
				{
					this.meleeCrit = 100;
				}
				this.aggro -= (int)((1f - this.stealth) * 750f);
				if (this.stealthTimer > 0)
				{
					this.stealthTimer--;
				}
			}
			else if (this.shroomiteStealth)
			{
				if (this.itemAnimation > 0)
				{
					this.stealthTimer = 5;
				}
				if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1 && (double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1 && !this.mount.Active)
				{
					if (this.stealthTimer == 0 && this.stealth > 0f)
					{
						this.stealth -= 0.015f;
						if ((double)this.stealth <= 0.0)
						{
							this.stealth = 0f;
							if (Main.netMode == 1)
							{
								NetMessage.SendData((int)PacketTypes.PlayerStealth, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
							}
						}
					}
				}
				else
				{
					float num45 = Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y);
					this.stealth += num45 * 0.0075f;
					if (this.stealth > 1f)
					{
						this.stealth = 1f;
					}
					if (this.mount.Active)
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
			else if (this.setVortex)
			{
				if (this.vortexStealthActive)
				{
					float num46 = this.stealth;
					this.stealth -= 0.04f;
					if (this.stealth < 0f)
					{
						this.stealth = 0f;
					}
					if (this.stealth == 0f && num46 != this.stealth && Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.PlayerStealth, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
					}
					this.rangedDamage += (1f - this.stealth) * 0.8f;
					this.rangedCrit += (int)((1f - this.stealth) * 20f);
					this.aggro -= (int)((1f - this.stealth) * 1200f);
					this.moveSpeed *= 0.3f;
					if (this.mount.Active)
					{
						this.vortexStealthActive = false;
					}
				}
				else
				{
					float num47 = this.stealth;
					this.stealth += 0.04f;
					if (this.stealth > 1f)
					{
						this.stealth = 1f;
					}
					if (this.stealth == 1f && num47 != this.stealth && Main.netMode == 1)
					{
						NetMessage.SendData((int)PacketTypes.PlayerStealth, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
					}
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
			if (this.statManaMax2 > 400)
			{
				this.statManaMax2 = 400;
			}
			if (this.statDefense < 0)
			{
				this.statDefense = 0;
			}
			if (this.dazed)
			{
				this.moveSpeed /= 3f;
			}
			else if (this.slow)
			{
				this.moveSpeed /= 2f;
			}
			else if (this.chilled)
			{
				this.moveSpeed *= 0.75f;
			}
			this.meleeSpeed = 1f / this.meleeSpeed;
			this.UpdateLifeRegen();
			this.soulDrain = 0;
			this.UpdateManaRegen();
			if (this.manaRegenCount < 0)
			{
				this.manaRegenCount = 0;
			}
			if (this.statMana > this.statManaMax2)
			{
				this.statMana = this.statManaMax2;
			}
			this.runAcceleration *= this.moveSpeed;
			this.maxRunSpeed *= this.moveSpeed;
			this.UpdateJumpHeight();
			for (int s = 0; s < 22; s++)
			{
				if (this.buffType[s] > 0 && this.buffTime[s] > 0 && this.buffImmune[this.buffType[s]])
				{
					this.DelBuff(s);
				}
			}
			if (this.brokenArmor)
			{
				this.statDefense = this.statDefense / 2;
			}
			this.lastTileRangeX = Player.tileRangeX;
			this.lastTileRangeY = Player.tileRangeY;
			if (!this.mount.Active || !this.mount.BlockExtraJumps)
			{
				if (!this.doubleJumpCloud)
				{
					this.jumpAgainCloud = false;
				}
				else if (this.velocity.Y == 0f || this.sliding)
				{
					this.jumpAgainCloud = true;
				}
				if (!this.doubleJumpSandstorm)
				{
					this.jumpAgainSandstorm = false;
				}
				else if (this.velocity.Y == 0f || this.sliding)
				{
					this.jumpAgainSandstorm = true;
				}
				if (!this.doubleJumpBlizzard)
				{
					this.jumpAgainBlizzard = false;
				}
				else if (this.velocity.Y == 0f || this.sliding)
				{
					this.jumpAgainBlizzard = true;
				}
				if (!this.doubleJumpFart)
				{
					this.jumpAgainFart = false;
				}
				else if (this.velocity.Y == 0f || this.sliding)
				{
					this.jumpAgainFart = true;
				}
				if (!this.doubleJumpSail)
				{
					this.jumpAgainSail = false;
				}
				else if (this.velocity.Y == 0f || this.sliding)
				{
					this.jumpAgainSail = true;
				}
				if (!this.doubleJumpUnicorn)
				{
					this.jumpAgainUnicorn = false;
				}
				else if (this.velocity.Y == 0f || this.sliding)
				{
					this.jumpAgainUnicorn = true;
				}
			}
			else
			{
				this.jumpAgainCloud = false;
				this.jumpAgainSandstorm = false;
				this.jumpAgainBlizzard = false;
				this.jumpAgainFart = false;
				this.jumpAgainSail = false;
				this.jumpAgainUnicorn = false;
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
				Player player48 = this;
				player48.ropeCount = player48.ropeCount - 1;
			}
			if (!this.pulley && !this.frozen && !this.webbed && !this.stoned && !this.controlJump && this.gravDir == 1f && this.ropeCount == 0 && this.grappling[0] == -1 && !this.tongued && !this.mount.Active)
			{
				this.FindPulley();
			}
			if (this.pulley)
			{
				if (this.mount.Active)
				{
					this.pulley = false;
				}
				this.sandStorm = false;
				this.dJumpEffectCloud = false;
				this.dJumpEffectSandstorm = false;
				this.dJumpEffectBlizzard = false;
				this.dJumpEffectFart = false;
				this.dJumpEffectSail = false;
				this.dJumpEffectUnicorn = false;
				int x7 = (int)(this.position.X + (float)(this.width / 2)) / 16;
				int y9 = (int)(this.position.Y - 8f) / 16;
				bool flag19 = false;
				if (this.pulleyDir == 0)
				{
					this.pulleyDir = 1;
				}
				if (this.pulleyDir != 1)
				{
					if (this.pulleyDir == 2)
					{
						if (this.direction == 1 && this.controlLeft)
						{
							flag19 = true;
							if (!Collision.SolidCollision(new Vector2((float)(x7 * 16 + 8 - this.width / 2), this.position.Y), this.width, this.height))
							{
								this.pulleyDir = 1;
								this.direction = -1;
								flag19 = true;
							}
						}
						if (this.direction == -1 && this.controlRight)
						{
							flag19 = true;
							if (!Collision.SolidCollision(new Vector2((float)(x7 * 16 + 8 - this.width / 2), this.position.Y), this.width, this.height))
							{
								this.pulleyDir = 1;
								this.direction = 1;
								flag19 = true;
							}
						}
					}
				}
				else if (this.direction == -1 && this.controlLeft && (this.releaseLeft || this.leftTimer == 0))
				{
					this.pulleyDir = 2;
					flag19 = true;
				}
				else if ((this.direction != 1 || !this.controlRight || !this.releaseRight) && this.rightTimer != 0)
				{
					if (this.direction == 1 && this.controlLeft)
					{
						this.direction = -1;
						flag19 = true;
					}
					if (this.direction == -1 && this.controlRight)
					{
						this.direction = 1;
						flag19 = true;
					}
				}
				else
				{
					this.pulleyDir = 2;
					flag19 = true;
				}
				bool flag20 = false;
				if (!flag19 && (this.controlLeft && (this.releaseLeft || this.leftTimer == 0) || this.controlRight && (this.releaseRight || this.rightTimer == 0)))
				{
					int num18 = 1;
					if (this.controlLeft)
					{
						num18 = -1;
					}
					int num19 = x7 + num18;
					if (Main.tile[num19, y9].active() && Main.tileRope[Main.tile[num19, y9].type])
					{
						this.pulleyDir = 1;
						this.direction = num18;
						int num20 = num19 * 16 + 8 - this.width / 2;
						float y10 = this.position.Y;
						y10 = (float)(y9 * 16 + 22);
						if ((!Main.tile[num19, y9 - 1].active() || !Main.tileRope[Main.tile[num19, y9 - 1].type]) && (!Main.tile[num19, y9 + 1].active() || !Main.tileRope[Main.tile[num19, y9 + 1].type]))
						{
							y10 = (float)(y9 * 16 + 22);
						}
						if (Collision.SolidCollision(new Vector2((float)num20, y10), this.width, this.height))
						{
							this.pulleyDir = 2;
							this.direction = -num18;
							num20 = (this.direction != 1 ? num19 * 16 + 8 - this.width / 2 + -6 : num19 * 16 + 8 - this.width / 2 + 6);
						}
						if (i == Main.myPlayer)
						{
							Main.cameraX = Main.cameraX + this.position.X - (float)num20;
						}
						this.position.X = (float)num20;
						this.gfxOffY = this.position.Y - y10;
						this.position.Y = y10;
						flag20 = true;
					}
				}
				if (!flag20 && !flag19 && !this.controlUp && (this.controlLeft && this.releaseLeft || this.controlRight && this.releaseRight))
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
				if (Main.tile[x7, y9] == null)
				{
					Main.tile[x7, y9] = new Tile();
				}
				if (!Main.tile[x7, y9].active() || !Main.tileRope[Main.tile[x7, y9].type])
				{
					this.pulley = false;
				}
				if (this.gravDir != 1f)
				{
					this.pulley = false;
				}
				if (this.frozen || this.webbed || this.stoned)
				{
					this.pulley = false;
				}
				if (!this.pulley)
				{
					this.velocity.Y = this.velocity.Y - this.gravity;
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
				int x8 = (int)(this.position.X + (float)(this.width / 2)) / 16;
				int y11 = (int)(this.position.Y - 16f) / 16;
				int y12 = (int)(this.position.Y - 8f) / 16;
				bool flag20 = true;
				bool flag21 = false;
				if (Main.tile[x8, y12 - 1].active() && Main.tileRope[Main.tile[x8, y12 - 1].type] || Main.tile[x8, y12 + 1].active() && Main.tileRope[Main.tile[x8, y12 + 1].type])
				{
					flag21 = true;
				}
				if (Main.tile[x8, y11] == null)
				{
					Main.tile[x8, y11] = new Tile();
				}
				if (!Main.tile[x8, y11].active() || !Main.tileRope[Main.tile[x8, y11].type])
				{
					flag20 = false;
					if (this.velocity.Y < 0f)
					{
						this.velocity.Y = 0f;
					}
				}
				if (!flag21)
				{
					if (!this.controlDown)
					{
						this.velocity.Y = 0f;
						this.position.Y = (float)(y11 * 16 + 22);
					}
					else
					{
						this.ropeCount = 10;
						this.pulley = false;
						this.velocity.Y = 1f;
					}
				}
				else if (this.controlUp && flag20)
				{
					float x9 = this.position.X;
					float y13 = this.position.Y - Math.Abs(this.velocity.Y) - 2f;
					if (Collision.SolidCollision(new Vector2(x9, y13), this.width, this.height))
					{
						x9 = (float)(x8 * 16 + 8 - this.width / 2 + 6);
						if (Collision.SolidCollision(new Vector2(x9, y13), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
						{
							x9 = (float)(x8 * 16 + 8 - this.width / 2 + -6);
							if (!Collision.SolidCollision(new Vector2(x9, y13), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
							{
								if (i == Main.myPlayer)
								{
									Main.cameraX = Main.cameraX + this.position.X - x9;
								}
								this.pulleyDir = 2;
								this.direction = -1;
								this.position.X = x9;
								this.velocity.X = 0f;
							}
						}
						else
						{
							if (i == Main.myPlayer)
							{
								Main.cameraX = Main.cameraX + this.position.X - x9;
							}
							this.pulleyDir = 2;
							this.direction = 1;
							this.position.X = x9;
							this.velocity.X = 0f;
						}
					}
					if (this.velocity.Y > 0f)
					{
						this.velocity.Y = this.velocity.Y * 0.7f;
					}
					if (this.velocity.Y <= -3f)
					{
						this.velocity.Y = this.velocity.Y - 0.02f;
					}
					else
					{
						this.velocity.Y = this.velocity.Y - 0.2f;
					}
					if (this.velocity.Y < -8f)
					{
						this.velocity.Y = -8f;
					}
				}
				else if (!this.controlDown)
				{
					this.velocity.Y = this.velocity.Y * 0.7f;
					if ((double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1)
					{
						this.velocity.Y = 0f;
					}
				}
				else
				{
					float x10 = this.position.X;
					float y14 = this.position.Y;
					if (Collision.SolidCollision(new Vector2(x10, y14), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
					{
						x10 = (float)(x8 * 16 + 8 - this.width / 2 + 6);
						if (Collision.SolidCollision(new Vector2(x10, y14), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
						{
							x10 = (float)(x8 * 16 + 8 - this.width / 2 + -6);
							if (!Collision.SolidCollision(new Vector2(x10, y14), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
							{
								if (i == Main.myPlayer)
								{
									Main.cameraX = Main.cameraX + this.position.X - x10;
								}
								this.pulleyDir = 2;
								this.direction = -1;
								this.position.X = x10;
								this.velocity.X = 0f;
							}
						}
						else
						{
							if (i == Main.myPlayer)
							{
								Main.cameraX = Main.cameraX + this.position.X - x10;
							}
							this.pulleyDir = 2;
							this.direction = 1;
							this.position.X = x10;
							this.velocity.X = 0f;
						}
					}
					if (this.velocity.Y < 0f)
					{
						this.velocity.Y = this.velocity.Y * 0.7f;
					}
					if (this.velocity.Y >= 3f)
					{
						this.velocity.Y = this.velocity.Y + 0.1f;
					}
					else
					{
						this.velocity.Y = this.velocity.Y + 0.2f;
					}
					if (this.velocity.Y > this.maxFallSpeed)
					{
						this.velocity.Y = this.maxFallSpeed;
					}
				}
				float single19 = (float)(x8 * 16 + 8 - this.width / 2);
				if (this.pulleyDir == 1)
				{
					single19 = (float)(x8 * 16 + 8 - this.width / 2);
				}
				if (this.pulleyDir == 2)
				{
					single19 = (float)(x8 * 16 + 8 - this.width / 2 + 6 * this.direction);
				}
				if (i == Main.myPlayer)
				{
					Main.cameraX = Main.cameraX + this.position.X - single19;
				}
				this.position.X = single19;
				Player player49 = this;
				player49.pulleyFrameCounter = player49.pulleyFrameCounter + Math.Abs(this.velocity.Y * 0.75f);
				if (this.velocity.Y != 0f)
				{
					Player player50 = this;
					player50.pulleyFrameCounter = player50.pulleyFrameCounter + 0.75f;
				}
				if (this.pulleyFrameCounter > 10f)
				{
					Player player51 = this;
					player51.pulleyFrame = player51.pulleyFrame + 1;
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
				if (this.wingsLogic > 0 && this.velocity.Y != 0f && !this.merman)
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
						if (!this.controlDown || !this.controlJump || this.wingTime <= 0f)
						{
							this.accRunSpeed = 6.25f;
						}
						else
						{
							this.accRunSpeed = 10f;
							Player player52 = this;
							player52.runAcceleration = player52.runAcceleration * 10f;
						}
					}
					if (this.wingsLogic == 30)
					{
						if (!this.controlDown || !this.controlJump || this.wingTime <= 0f)
						{
							this.accRunSpeed = 6.5f;
							Player player53 = this;
							player53.runAcceleration = player53.runAcceleration * 1.5f;
						}
						else
						{
							this.accRunSpeed = 12f;
							Player player54 = this;
							player54.runAcceleration = player54.runAcceleration * 12f;
						}
					}
					if (this.wingsLogic == 32)
					{
						if (!this.controlDown || !this.controlJump || this.wingTime <= 0f)
						{
							this.accRunSpeed = 5.5f;
							Player player55 = this;
							player55.runAcceleration = player55.runAcceleration * 1.1f;
						}
						else
						{
							this.accRunSpeed = 7.5f;
							Player player56 = this;
							player56.runAcceleration = player56.runAcceleration * 5f;
						}
					}
					if (this.wingsLogic == 26)
					{
						this.accRunSpeed = 8f;
						Player player57 = this;
						player57.runAcceleration = player57.runAcceleration * 2f;
					}
					if (this.wingsLogic == 29)
					{
						this.accRunSpeed = 9f;
						Player player58 = this;
						player58.runAcceleration = player58.runAcceleration * 2.5f;
					}
					if (this.wingsLogic == 12)
					{
						this.accRunSpeed = 7.75f;
					}
					if (this.wingsLogic == 16 || this.wingsLogic == 17 || this.wingsLogic == 18 || this.wingsLogic == 19 || this.wingsLogic == 34 || this.wingsLogic == 3 || this.wingsLogic == 28 || this.wingsLogic == 33 || this.wingsLogic == 34 || this.wingsLogic == 35 || this.wingsLogic == 36)
					{
						this.accRunSpeed = 7f;
					}
				}
				if (this.sticky)
				{
					Player player59 = this;
					player59.maxRunSpeed = player59.maxRunSpeed * 0.25f;
					Player player60 = this;
					player60.runAcceleration = player60.runAcceleration * 0.25f;
					Player player61 = this;
					player61.runSlowdown = player61.runSlowdown * 2f;
					if (this.velocity.X > this.maxRunSpeed)
					{
						this.velocity.X = this.maxRunSpeed;
					}
					if (this.velocity.X < -this.maxRunSpeed)
					{
						this.velocity.X = -this.maxRunSpeed;
					}
				}
				else if (this.powerrun)
				{
					Player player62 = this;
					player62.maxRunSpeed = player62.maxRunSpeed * 3.5f;
					Player player63 = this;
					player63.runAcceleration = player63.runAcceleration * 1f;
					Player player64 = this;
					player64.runSlowdown = player64.runSlowdown * 2f;
				}
				else if (this.slippy2)
				{
					Player player65 = this;
					player65.runAcceleration = player65.runAcceleration * 0.6f;
					this.runSlowdown = 0f;
					if (this.iceSkate)
					{
						Player player66 = this;
						player66.runAcceleration = player66.runAcceleration * 3.5f;
						Player player67 = this;
						player67.maxRunSpeed = player67.maxRunSpeed * 1.25f;
					}
				}
				else if (this.slippy)
				{
					Player player68 = this;
					player68.runAcceleration = player68.runAcceleration * 0.7f;
					if (!this.iceSkate)
					{
						Player player69 = this;
						player69.runSlowdown = player69.runSlowdown * 0.1f;
					}
					else
					{
						Player player70 = this;
						player70.runAcceleration = player70.runAcceleration * 3.5f;
						Player player71 = this;
						player71.maxRunSpeed = player71.maxRunSpeed * 1.25f;
					}
				}
				if (this.sandStorm)
				{
					Player player72 = this;
					player72.runAcceleration = player72.runAcceleration * 1.5f;
					Player player73 = this;
					player73.maxRunSpeed = player73.maxRunSpeed * 2f;
				}
				if (this.dJumpEffectBlizzard && this.doubleJumpBlizzard)
				{
					Player player74 = this;
					player74.runAcceleration = player74.runAcceleration * 3f;
					Player player75 = this;
					player75.maxRunSpeed = player75.maxRunSpeed * 1.5f;
				}
				if (this.dJumpEffectFart && this.doubleJumpFart)
				{
					Player player76 = this;
					player76.runAcceleration = player76.runAcceleration * 3f;
					Player player77 = this;
					player77.maxRunSpeed = player77.maxRunSpeed * 1.75f;
				}
				if (this.dJumpEffectUnicorn && this.doubleJumpUnicorn)
				{
					Player player78 = this;
					player78.runAcceleration = player78.runAcceleration * 3f;
					Player player79 = this;
					player79.maxRunSpeed = player79.maxRunSpeed * 1.5f;
				}
				if (this.dJumpEffectSail && this.doubleJumpSail)
				{
					Player player80 = this;
					player80.runAcceleration = player80.runAcceleration * 1.5f;
					Player player81 = this;
					player81.maxRunSpeed = player81.maxRunSpeed * 1.25f;
				}
				if (this.carpetFrame != -1)
				{
					Player player82 = this;
					player82.runAcceleration = player82.runAcceleration * 1.25f;
					Player player83 = this;
					player83.maxRunSpeed = player83.maxRunSpeed * 1.5f;
				}
				if (this.inventory[this.selectedItem].type == 3106 && this.stealth < 1f)
				{
					float single20 = this.maxRunSpeed / 2f * (1f - this.stealth);
					Player player84 = this;
					player84.maxRunSpeed = player84.maxRunSpeed - single20;
					this.accRunSpeed = this.maxRunSpeed;
				}
				if (this.mount.Active)
				{
					this.rocketBoots = 0;
					this.wings = 0;
					this.wingsLogic = 0;
					this.maxRunSpeed = this.mount.RunSpeed;
					this.accRunSpeed = this.mount.DashSpeed;
					this.runAcceleration = this.mount.Acceleration;
					if (this.mount.Type == 12 && !this.MountFishronSpecial)
					{
						Player player85 = this;
						player85.runAcceleration = player85.runAcceleration / 2f;
						Player player86 = this;
						player86.maxRunSpeed = player86.maxRunSpeed / 2f;
					}
					this.mount.AbilityRecovery();
					if (this.mount.Cart && this.velocity.Y == 0f)
					{
						if (Minecart.OnTrack(this.position, this.width, this.height))
						{
							this.runSlowdown = this.runAcceleration;
							this.onWrongGround = false;
						}
						else
						{
							this.fullRotation = 0f;
							this.onWrongGround = true;
							this.runSlowdown = 0.2f;
							if (this.controlLeft && this.releaseLeft || this.controlRight && this.releaseRight)
							{
								this.mount.Dismount(this);
							}
						}
					}
					if (this.mount.Type == 8)
					{
						this.mount.UpdateDrill(this, this.controlUp, this.controlDown);
					}
				}
				this.HorizontalMovement();
				if (this.gravControl)
				{
					if (this.controlUp && this.releaseUp)
					{
						if (this.gravDir != 1f)
						{
							this.gravDir = 1f;
							this.fallStart = (int)(this.position.Y / 16f);
							this.jump = 0;
						}
						else
						{
							this.gravDir = -1f;
							this.fallStart = (int)(this.position.Y / 16f);
							this.jump = 0;
						}
					}
				}
				else if (!this.gravControl2)
				{
					this.gravDir = 1f;
				}
				else if (this.controlUp && this.releaseUp && this.velocity.Y == 0f)
				{
					if (this.gravDir != 1f)
					{
						this.gravDir = 1f;
						this.fallStart = (int)(this.position.Y / 16f);
						this.jump = 0;
					}
					else
					{
						this.gravDir = -1f;
						this.fallStart = (int)(this.position.Y / 16f);
						this.jump = 0;
					}
				}
				if (this.velocity.Y == 0f && this.mount.Active && this.mount.CanHover && this.controlUp && this.releaseUp)
				{
					this.velocity.Y = -(this.mount.Acceleration + this.gravity + 0.001f);
				}
				if (!this.controlUp)
				{
					this.releaseUp = true;
				}
				else
				{
					this.releaseUp = false;
				}
				this.sandStorm = false;
				this.JumpMovement();
				if (this.wingsLogic == 0)
				{
					this.wingTime = 0f;
				}
				if (this.rocketBoots == 0)
				{
					this.rocketTime = 0;
				}
				if (this.jump == 0)
				{
					this.dJumpEffectCloud = false;
					this.dJumpEffectSandstorm = false;
					this.dJumpEffectBlizzard = false;
					this.dJumpEffectFart = false;
					this.dJumpEffectSail = false;
					this.dJumpEffectUnicorn = false;
				}
				this.DashMovement();
				this.WallslideMovement();
				this.CarpetMovement();
				if (this.wings > 0 || this.mount.Active)
				{
					this.sandStorm = false;
				}
				if ((this.gravDir == 1f && this.velocity.Y > -Player.jumpSpeed || this.gravDir == -1f && this.velocity.Y < Player.jumpSpeed) && this.velocity.Y != 0f)
				{
					this.canRocket = true;
				}
				bool flag22 = false;
				if ((this.velocity.Y == 0f || this.sliding) && this.releaseJump || this.autoJump && this.justJumped)
				{
					this.mount.ResetFlightTime(this.velocity.X);
					this.wingTime = (float)this.wingTimeMax;
				}
				if (this.wingsLogic > 0 && this.controlJump && this.wingTime > 0f && !this.jumpAgainCloud && this.jump == 0 && this.velocity.Y != 0f)
				{
					flag22 = true;
				}
				if ((this.wingsLogic == 22 || this.wingsLogic == 28 || this.wingsLogic == 30 || this.wingsLogic == 32 || this.wingsLogic == 33 || this.wingsLogic == 35) && this.controlJump && this.controlDown && this.wingTime > 0f)
				{
					flag22 = true;
				}
				if (this.frozen || this.webbed || this.stoned)
				{
					if (this.mount.Active)
					{
						this.mount.Dismount(this);
					}
					this.velocity.Y = this.velocity.Y + this.gravity;
					if (this.velocity.Y > this.maxFallSpeed)
					{
						this.velocity.Y = this.maxFallSpeed;
					}
					this.sandStorm = false;
					this.dJumpEffectCloud = false;
					this.dJumpEffectSandstorm = false;
					this.dJumpEffectBlizzard = false;
					this.dJumpEffectFart = false;
					this.dJumpEffectSail = false;
					this.dJumpEffectUnicorn = false;
				}
				else
				{
					if (flag22)
					{
						this.WingMovement();
					}
					if (this.wings == 4)
					{
						if (flag22 || this.jump > 0)
						{
							Player player87 = this;
							player87.rocketDelay2 = player87.rocketDelay2 - 1;
							if (this.rocketDelay2 <= 0)
							{
								this.rocketDelay2 = 60;
							}
							int num42 = 2;
							if (this.controlUp)
							{
								num42 = 4;
							}
							for (int t = 0; t < num42; t++)
							{
								if (this.head == 41)
								{
									int num44 = this.body;
								}
								float x11 = this.position.X + (float)(this.width / 2) + 16f;
								if (this.direction > 0)
								{
									x11 = this.position.X + (float)(this.width / 2) - 26f;
								}
								float y18 = this.position.Y + (float)this.height - 18f;
								if (t == 1 || t == 3)
								{
									x11 = this.position.X + (float)(this.width / 2) + 8f;
									if (this.direction > 0)
									{
										x11 = this.position.X + (float)(this.width / 2) - 20f;
									}
									y18 = y18 + 6f;
								}
								if (t > 1)
								{
									y18 = y18 + this.velocity.Y;
								}
							}
							Player player88 = this;
							player88.wingFrameCounter = player88.wingFrameCounter + 1;
							if (this.wingFrameCounter > 4)
							{
								Player player89 = this;
								player89.wingFrame = player89.wingFrame + 1;
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
						else if (this.wingTime <= 0f)
						{
							Player player90 = this;
							player90.wingFrameCounter = player90.wingFrameCounter + 1;
							int num47 = 6;
							if (this.wingFrameCounter < num47)
							{
								this.wingFrame = 4;
							}
							else if (this.wingFrameCounter < num47 * 2)
							{
								this.wingFrame = 5;
							}
							else if (this.wingFrameCounter >= num47 * 3 - 1)
							{
								this.wingFrame = 4;
								this.wingFrameCounter = 0;
							}
							else
							{
								this.wingFrame = 4;
							}
						}
						else if (!this.controlDown)
						{
							Player player91 = this;
							player91.wingFrameCounter = player91.wingFrameCounter + 1;
							int num48 = 2;
							if (this.wingFrameCounter < num48)
							{
								this.wingFrame = 4;
							}
							else if (this.wingFrameCounter < num48 * 2)
							{
								this.wingFrame = 5;
							}
							else if (this.wingFrameCounter < num48 * 3)
							{
								this.wingFrame = 6;
							}
							else if (this.wingFrameCounter >= num48 * 4 - 1)
							{
								this.wingFrame = 5;
								this.wingFrameCounter = 0;
							}
							else
							{
								this.wingFrame = 5;
							}
						}
						else if (this.velocity.X == 0f)
						{
							Player player92 = this;
							player92.wingFrameCounter = player92.wingFrameCounter + 1;
							int num49 = 6;
							if (this.wingFrameCounter < num49)
							{
								this.wingFrame = 4;
							}
							else if (this.wingFrameCounter < num49 * 2)
							{
								this.wingFrame = 5;
							}
							else if (this.wingFrameCounter >= num49 * 3 - 1)
							{
								this.wingFrame = 4;
								this.wingFrameCounter = 0;
							}
							else
							{
								this.wingFrame = 4;
							}
						}
						else
						{
							Player player93 = this;
							player93.wingFrameCounter = player93.wingFrameCounter + 1;
							int num50 = 2;
							if (this.wingFrameCounter < num50)
							{
								this.wingFrame = 1;
							}
							else if (this.wingFrameCounter < num50 * 2)
							{
								this.wingFrame = 2;
							}
							else if (this.wingFrameCounter < num50 * 3)
							{
								this.wingFrame = 3;
							}
							else if (this.wingFrameCounter >= num50 * 4 - 1)
							{
								this.wingFrame = 2;
								this.wingFrameCounter = 0;
							}
							else
							{
								this.wingFrame = 2;
							}
						}
					}
					else if (this.wings == 12)
					{
						if (flag22 || this.jump > 0)
						{
							Player player94 = this;
							player94.wingFrameCounter = player94.wingFrameCounter + 1;
							int num51 = 5;
							if (this.wingFrameCounter < num51)
							{
								this.wingFrame = 1;
							}
							else if (this.wingFrameCounter < num51 * 2)
							{
								this.wingFrame = 2;
							}
							else if (this.wingFrameCounter < num51 * 3)
							{
								this.wingFrame = 3;
							}
							else if (this.wingFrameCounter >= num51 * 4 - 1)
							{
								this.wingFrame = 2;
								this.wingFrameCounter = 0;
							}
							else
							{
								this.wingFrame = 2;
							}
						}
						else if (this.velocity.Y == 0f)
						{
							this.wingFrame = 0;
						}
						else
						{
							this.wingFrame = 2;
						}
					}
					else if (this.wings == 24)
					{
						if (flag22 || this.jump > 0)
						{
							Player player95 = this;
							player95.wingFrameCounter = player95.wingFrameCounter + 1;
							int num52 = 1;
							if (this.wingFrameCounter < num52)
							{
								this.wingFrame = 1;
							}
							else if (this.wingFrameCounter < num52 * 2)
							{
								this.wingFrame = 2;
							}
							else if (this.wingFrameCounter >= num52 * 3)
							{
								this.wingFrame = 2;
								if (this.wingFrameCounter >= num52 * 4 - 1)
								{
									this.wingFrameCounter = 0;
								}
							}
							else
							{
								this.wingFrame = 3;
							}
						}
						else if (this.velocity.Y == 0f)
						{
							this.wingFrame = 0;
						}
						else if (this.controlJump)
						{
							Player player96 = this;
							player96.wingFrameCounter = player96.wingFrameCounter + 1;
							int num53 = 3;
							if (this.wingFrameCounter < num53)
							{
								this.wingFrame = 1;
							}
							else if (this.wingFrameCounter < num53 * 2)
							{
								this.wingFrame = 2;
							}
							else if (this.wingFrameCounter >= num53 * 3)
							{
								this.wingFrame = 2;
								if (this.wingFrameCounter >= num53 * 4 - 1)
								{
									this.wingFrameCounter = 0;
								}
							}
							else
							{
								this.wingFrame = 3;
							}
						}
						else if (this.wingTime != 0f)
						{
							this.wingFrame = 1;
						}
						else
						{
							this.wingFrame = 0;
						}
					}
					else if (this.wings == 30)
					{
						bool flag23 = false;
						if (flag22 || this.jump > 0)
						{
							Player player97 = this;
							player97.wingFrameCounter = player97.wingFrameCounter + 1;
							int num54 = 2;
							if (this.wingFrameCounter >= num54 * 3)
							{
								this.wingFrameCounter = 0;
							}
							this.wingFrame = 1 + this.wingFrameCounter / num54;
							flag23 = true;
						}
						else if (this.velocity.Y == 0f)
						{
							this.wingFrame = 0;
						}
						else if (this.controlJump)
						{
							Player player98 = this;
							player98.wingFrameCounter = player98.wingFrameCounter + 1;
							int num55 = 2;
							if (this.wingFrameCounter >= num55 * 3)
							{
								this.wingFrameCounter = 0;
							}
							this.wingFrame = 1 + this.wingFrameCounter / num55;
							flag23 = true;
						}
						else if (this.wingTime != 0f)
						{
							this.wingFrame = 0;
						}
						else
						{
							this.wingFrame = 0;
						}
						if (flag23)
						{
						}
					}
					else if (this.wings != 34)
					{
						if (this.wings != 33)
						{
							int num56 = 4;
							if (this.wings == 32)
							{
								num56 = 3;
							}
							if (flag22 || this.jump > 0)
							{
								Player player99 = this;
								player99.wingFrameCounter = player99.wingFrameCounter + 1;
								if (this.wingFrameCounter > num56)
								{
									Player player100 = this;
									player100.wingFrame = player100.wingFrame + 1;
									this.wingFrameCounter = 0;
									if (this.wingFrame >= 4)
									{
										this.wingFrame = 0;
									}
								}
							}
							else if (this.velocity.Y == 0f)
							{
								this.wingFrame = 0;
							}
							else
							{
								this.wingFrame = 1;
								if (this.wings == 32)
								{
									this.wingFrame = 3;
								}
							}
						}
						else
						{
							bool flag24 = false;
							if (flag22 || this.jump > 0)
							{
								flag24 = true;
							}
							else if (this.velocity.Y != 0f && this.controlJump)
							{
								flag24 = true;
							}
							if (flag24)
							{
								Color rgb = Main.HslToRgb(Main.RgbToHsl(this.eyeColor).X, 1f, 0.5f);
								int num59 = (this.direction == 1 ? 0 : -4);
							}
						}
					}
					else if (flag22 || this.jump > 0)
					{
						Player player101 = this;
						player101.wingFrameCounter = player101.wingFrameCounter + 1;
						int num60 = 4;
						if (this.wingFrameCounter >= num60 * 6)
						{
							this.wingFrameCounter = 0;
						}
						this.wingFrame = this.wingFrameCounter / num60;
					}
					else if (this.velocity.Y == 0f)
					{
						Player player102 = this;
						player102.wingFrameCounter = player102.wingFrameCounter + 1;
						int num61 = 4;
						if (this.wingFrameCounter >= num61 * 6)
						{
							this.wingFrameCounter = 0;
						}
						this.wingFrame = this.wingFrameCounter / num61;
					}
					else if (!this.controlJump)
					{
						Player player103 = this;
						player103.wingFrameCounter = player103.wingFrameCounter + 1;
						int num62 = 6;
						if (this.wingFrameCounter >= num62 * 6)
						{
							this.wingFrameCounter = 0;
						}
						this.wingFrame = this.wingFrameCounter / num62;
					}
					else
					{
						Player player104 = this;
						player104.wingFrameCounter = player104.wingFrameCounter + 1;
						int num63 = 9;
						if (this.wingFrameCounter >= num63 * 6)
						{
							this.wingFrameCounter = 0;
						}
						this.wingFrame = this.wingFrameCounter / num63;
					}
					if (this.wingsLogic > 0 && this.rocketBoots > 0 && this.velocity.Y != 0f)
					{
						Player player105 = this;
						player105.wingTime = player105.wingTime + (float)(this.rocketTime * 6);
						this.rocketTime = 0;
					}
					if (this.velocity.Y == 0f || this.sliding || this.autoJump && this.justJumped)
					{
						this.rocketTime = this.rocketTimeMax;
					}
					if ((this.wingTime == 0f || this.wingsLogic == 0) && this.rocketBoots > 0 && this.controlJump && this.rocketDelay == 0 && this.canRocket && this.rocketRelease && !this.jumpAgainCloud)
					{
						if (this.rocketTime <= 0)
						{
							this.canRocket = false;
						}
						else
						{
							Player player106 = this;
							player106.rocketTime = player106.rocketTime - 1;
							this.rocketDelay = 10;
							if (this.rocketDelay2 <= 0)
							{
								if (this.rocketBoots == 1)
								{
									this.rocketDelay2 = 30;
								}
								else if (this.rocketBoots == 2 || this.rocketBoots == 3)
								{
									this.rocketDelay2 = 15;
								}
							}
						}
					}
					if (this.rocketDelay2 > 0)
					{
						Player player107 = this;
						player107.rocketDelay2 = player107.rocketDelay2 - 1;
					}
					if (this.rocketDelay == 0)
					{
						this.rocketFrame = false;
					}
					if (this.rocketDelay > 0)
					{
						int num64 = this.height;
						if (this.gravDir == -1f)
						{
							num64 = 4;
						}
						this.rocketFrame = true;
						if (this.rocketDelay == 0)
						{
							this.releaseJump = true;
						}
						Player player108 = this;
						player108.rocketDelay = player108.rocketDelay - 1;
						this.velocity.Y = this.velocity.Y - 0.1f * this.gravDir;
						if (this.gravDir != 1f)
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
						else
						{
							if (this.velocity.Y > 0f)
							{
								this.velocity.Y = this.velocity.Y - 0.5f;
							}
							else if ((double)this.velocity.Y > (double)(-Player.jumpSpeed) * 0.5)
							{
								this.velocity.Y = this.velocity.Y - 0.1f;
							}
							if (this.velocity.Y < -Player.jumpSpeed * 1.5f)
							{
								this.velocity.Y = -Player.jumpSpeed * 1.5f;
							}
						}
					}
					else if (!flag22)
					{
						if (this.mount.CanHover)
						{
							this.mount.Hover(this);
						}
						else if (this.mount.CanFly && this.controlJump && this.jump == 0)
						{
							if (!this.mount.Flight())
							{
								this.velocity.Y = this.velocity.Y + this.gravity / 3f * this.gravDir;
								if (this.gravDir == 1f)
								{
									if (this.velocity.Y > this.maxFallSpeed / 3f && !this.controlDown)
									{
										this.velocity.Y = this.maxFallSpeed / 3f;
									}
								}
								else if (this.velocity.Y < -this.maxFallSpeed / 3f && !this.controlUp)
								{
									this.velocity.Y = -this.maxFallSpeed / 3f;
								}
							}
							else if (!this.controlDown)
							{
								if (this.velocity.Y > 0f)
								{
									this.velocity.Y = this.velocity.Y - 0.5f;
								}
								else if ((double)this.velocity.Y > (double)(-Player.jumpSpeed) * 1.5)
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
								this.velocity.Y = this.velocity.Y * 0.9f;
								if (this.velocity.Y > -1f && (double)this.velocity.Y < 0.5)
								{
									this.velocity.Y = 1E-05f;
								}
							}
						}
						else if (this.slowFall && (!this.controlDown && this.gravDir == 1f || !this.controlDown && this.gravDir == -1f))
						{
							if ((!this.controlUp || this.gravDir != 1f) && (!this.controlUp || this.gravDir != -1f))
							{
								this.gravity = this.gravity / 3f * this.gravDir;
							}
							else
							{
								this.gravity = this.gravity / 10f * this.gravDir;
							}
							this.velocity.Y = this.velocity.Y + this.gravity;
						}
						else if (this.wingsLogic > 0 && this.controlJump && this.velocity.Y > 0f)
						{
							this.fallStart = (int)(this.position.Y / 16f);
							if (this.velocity.Y > 0f)
							{
								if (this.wings == 4)
								{
									Player player109 = this;
									player109.rocketDelay2 = player109.rocketDelay2 - 1;
									if (this.rocketDelay2 <= 0)
									{
										this.rocketDelay2 = 60;
									}
									float x13 = this.position.X + (float)(this.width / 2) + 16f;
									if (this.direction > 0)
									{
										x13 = this.position.X + (float)(this.width / 2) - 26f;
									}
									float y19 = this.position.Y + (float)this.height - 18f;
									if (Main.rand.Next(2) == 1)
									{
										x13 = this.position.X + (float)(this.width / 2) + 8f;
										if (this.direction > 0)
										{
											x13 = this.position.X + (float)(this.width / 2) - 20f;
										}
										y19 = y19 + 6f;
									}
									Player player110 = this;
									player110.wingFrameCounter = player110.wingFrameCounter + 1;
									if (this.wingFrameCounter > 4)
									{
										Player player111 = this;
										player111.wingFrame = player111.wingFrame + 1;
										this.wingFrameCounter = 0;
										if (this.wingFrame >= 3)
										{
											this.wingFrame = 0;
										}
									}
								}
								else if (this.wings != 22 && this.wings != 28)
								{
									if (this.wings == 30)
									{
										Player player112 = this;
										player112.wingFrameCounter = player112.wingFrameCounter + 1;
										int num85 = 5;
										if (this.wingFrameCounter >= num85 * 3)
										{
											this.wingFrameCounter = 0;
										}
										this.wingFrame = 1 + this.wingFrameCounter / num85;
									}
									else if (this.wings == 34)
									{
										Player player113 = this;
										player113.wingFrameCounter = player113.wingFrameCounter + 1;
										int num86 = 7;
										if (this.wingFrameCounter >= num86 * 6)
										{
											this.wingFrameCounter = 0;
										}
										this.wingFrame = this.wingFrameCounter / num86;
									}
									else if (this.wings == 26)
									{
										this.wingFrame = 2;
									}
									else if (this.wings != 24)
									{
										if (this.wings != 12)
										{
											this.wingFrame = 2;
										}
										else
										{
											this.wingFrame = 3;
										}
									}
								}
							}
							this.velocity.Y = this.velocity.Y + this.gravity / 3f * this.gravDir;
							if (this.gravDir == 1f)
							{
								if (this.velocity.Y > this.maxFallSpeed / 3f && !this.controlDown)
								{
									this.velocity.Y = this.maxFallSpeed / 3f;
								}
							}
							else if (this.velocity.Y < -this.maxFallSpeed / 3f && !this.controlUp)
							{
								this.velocity.Y = -this.maxFallSpeed / 3f;
							}
						}
						else if (this.cartRampTime > 0)
						{
							Player player114 = this;
							player114.cartRampTime = player114.cartRampTime - 1;
						}
						else
						{
							this.velocity.Y = this.velocity.Y + this.gravity * this.gravDir;
						}
					}
					if (!this.mount.Active || this.mount.Type != 5)
					{
						if (this.gravDir != 1f)
						{
							if (this.velocity.Y < -this.maxFallSpeed)
							{
								this.velocity.Y = -this.maxFallSpeed;
							}
							if (this.slowFall && this.velocity.Y < -this.maxFallSpeed / 3f && !this.controlDown)
							{
								this.velocity.Y = -this.maxFallSpeed / 3f;
							}
							if (this.slowFall && this.velocity.Y < -this.maxFallSpeed / 5f && this.controlUp)
							{
								this.velocity.Y = -this.maxFallSpeed / 10f;
							}
						}
						else
						{
							if (this.velocity.Y > this.maxFallSpeed)
							{
								this.velocity.Y = this.maxFallSpeed;
							}
							if (this.slowFall && this.velocity.Y > this.maxFallSpeed / 3f && !this.controlDown)
							{
								this.velocity.Y = this.maxFallSpeed / 3f;
							}
							if (this.slowFall && this.velocity.Y > this.maxFallSpeed / 5f && this.controlUp)
							{
								this.velocity.Y = this.maxFallSpeed / 10f;
							}
						}
					}
				}
			}
			if (this.mount.Active)
			{
				this.wingFrame = 0;
			}
			if ((this.wingsLogic == 22 || this.wingsLogic == 28 || this.wingsLogic == 30 || this.wingsLogic == 32 || this.wingsLogic == 33 || this.wingsLogic == 35) && this.controlDown && this.controlJump && this.wingTime > 0f && !this.merman)
			{
				this.velocity.Y = this.velocity.Y * 0.9f;
				if (this.velocity.Y > -2f && this.velocity.Y < 1f)
				{
					this.velocity.Y = 1E-05f;
				}
			}
			this.GrabItems(i);
			if (!Main.mapFullscreen)
			{
				if (this.position.X / 16f - (float)Player.tileRangeX > (float)Player.tileTargetX || (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX - 1f < (float)Player.tileTargetX || this.position.Y / 16f - (float)Player.tileRangeY > (float)Player.tileTargetY || (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY - 2f < (float)Player.tileTargetY)
				{
					if (Main.tile[Player.tileTargetX, Player.tileTargetY] == null)
					{
						Main.tile[Player.tileTargetX, Player.tileTargetY] = new Tile();
					}
					if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 21)
					{
						Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
						int num91 = Player.tileTargetX;
						int num92 = Player.tileTargetY;
						if (tile.frameX % 36 != 0)
						{
							num91--;
						}
						if (tile.frameY % 36 != 0)
						{
							num92--;
						}
						int num93 = Chest.FindChest(num91, num92);
						this.showItemIcon2 = -1;
						if (num93 >= 0)
						{
							if (Main.chest[num93].name == "")
							{
								this.showItemIconText = Lang.chestType[tile.frameX / 36];
							}
							else
							{
								this.showItemIconText = Main.chest[num93].name;
							}
							if (this.showItemIconText == Lang.chestType[tile.frameX / 36])
							{
								this.showItemIcon2 = Chest.chestTypeToIcon[tile.frameX / 36];
								this.showItemIconText = "";
							}
						}
						else
						{
							this.showItemIconText = Lang.chestType[0];
						}
						this.noThrow = 2;
						this.showItemIcon = true;
						if (this.showItemIconText == "")
						{
							this.showItemIcon = false;
							this.showItemIcon2 = 0;
						}
					}
					if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 88)
					{
						Tile tile1 = Main.tile[Player.tileTargetX, Player.tileTargetY];
						int num94 = Player.tileTargetX;
						int num95 = Player.tileTargetY;
						num94 = num94 - tile1.frameX % 54 / 18;
						if (tile1.frameY % 36 != 0)
						{
							num95--;
						}
						int num96 = Chest.FindChest(num94, num95);
						this.showItemIcon2 = -1;
						if (num96 >= 0)
						{
							if (Main.chest[num96].name == "")
							{
								this.showItemIconText = Lang.dresserType[tile1.frameX / 54];
							}
							else
							{
								this.showItemIconText = Main.chest[num96].name;
							}
							if (this.showItemIconText == Lang.dresserType[tile1.frameX / 54])
							{
								this.showItemIcon2 = Chest.dresserTypeToIcon[tile1.frameX / 54];
								this.showItemIconText = "";
							}
						}
						else
						{
							this.showItemIconText = Lang.dresserType[0];
						}
						this.noThrow = 2;
						this.showItemIcon = true;
						if (this.showItemIconText == "")
						{
							this.showItemIcon = false;
							this.showItemIcon2 = 0;
						}
					}
					if (Main.tileSign[Main.tile[Player.tileTargetX, Player.tileTargetY].type])
					{
						this.noThrow = 2;
						int num97 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18;
						int num98 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18;
						num97 = num97 % 2;
						int num99 = Player.tileTargetX - num97;
						int num100 = Player.tileTargetY - num98;
						Main.signBubble = true;
						Main.signX = num99 * 16 + 16;
						Main.signY = num100 * 16;
						int num101 = Sign.ReadSign(num99, num100, true);
						if (num101 != -1)
						{
							Main.signHover = num101;
							this.showItemIcon = false;
							this.showItemIcon2 = -1;
						}
					}
				}
				else
				{
					if (Main.tile[Player.tileTargetX, Player.tileTargetY] == null)
					{
						Main.tile[Player.tileTargetX, Player.tileTargetY] = new Tile();
					}
					if (Main.tile[Player.tileTargetX, Player.tileTargetY].active())
					{
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 79)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							int num102 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 36;
							if (num102 == 0)
							{
								this.showItemIcon2 = 224;
							}
							else if (num102 == 1)
							{
								this.showItemIcon2 = 644;
							}
							else if (num102 == 2)
							{
								this.showItemIcon2 = 645;
							}
							else if (num102 == 3)
							{
								this.showItemIcon2 = 646;
							}
							else if (num102 == 4)
							{
								this.showItemIcon2 = 920;
							}
							else if (num102 == 5)
							{
								this.showItemIcon2 = 1470;
							}
							else if (num102 == 6)
							{
								this.showItemIcon2 = 1471;
							}
							else if (num102 == 7)
							{
								this.showItemIcon2 = 1472;
							}
							else if (num102 == 8)
							{
								this.showItemIcon2 = 1473;
							}
							else if (num102 == 9)
							{
								this.showItemIcon2 = 1719;
							}
							else if (num102 == 10)
							{
								this.showItemIcon2 = 1720;
							}
							else if (num102 == 11)
							{
								this.showItemIcon2 = 1721;
							}
							else if (num102 == 12)
							{
								this.showItemIcon2 = 1722;
							}
							else if (num102 >= 13 && num102 <= 18)
							{
								this.showItemIcon2 = 2066 + num102 - 13;
							}
							else if (num102 >= 19 && num102 <= 20)
							{
								this.showItemIcon2 = 2139 + num102 - 19;
							}
							else if (num102 == 21)
							{
								this.showItemIcon2 = 2231;
							}
							else if (num102 == 22)
							{
								this.showItemIcon2 = 2520;
							}
							else if (num102 == 23)
							{
								this.showItemIcon2 = 2538;
							}
							else if (num102 == 24)
							{
								this.showItemIcon2 = 2553;
							}
							else if (num102 == 25)
							{
								this.showItemIcon2 = 2568;
							}
							else if (num102 == 26)
							{
								this.showItemIcon2 = 2669;
							}
							else if (num102 == 27)
							{
								this.showItemIcon2 = 2811;
							}
							else if (num102 == 28)
							{
								this.showItemIcon2 = 3162;
							}
							else if (num102 == 29)
							{
								this.showItemIcon2 = 3164;
							}
							else if (num102 != 30)
							{
								this.showItemIcon2 = 646;
							}
							else
							{
								this.showItemIcon2 = 3163;
							}
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 33)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							this.showItemIcon2 = 105;
							int num103 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 22;
							if (num103 == 1)
							{
								this.showItemIcon2 = 1405;
							}
							if (num103 == 2)
							{
								this.showItemIcon2 = 1406;
							}
							if (num103 == 3)
							{
								this.showItemIcon2 = 1407;
							}
							if (num103 >= 4 && num103 <= 13)
							{
								this.showItemIcon2 = 2045 + num103 - 4;
							}
							if (num103 >= 14 && num103 <= 16)
							{
								this.showItemIcon2 = 2153 + num103 - 14;
							}
							if (num103 == 17)
							{
								this.showItemIcon2 = 2236;
							}
							if (num103 == 18)
							{
								this.showItemIcon2 = 2523;
							}
							if (num103 == 19)
							{
								this.showItemIcon2 = 2542;
							}
							if (num103 == 20)
							{
								this.showItemIcon2 = 2556;
							}
							if (num103 == 21)
							{
								this.showItemIcon2 = 2571;
							}
							if (num103 == 22)
							{
								this.showItemIcon2 = 2648;
							}
							if (num103 == 23)
							{
								this.showItemIcon2 = 2649;
							}
							if (num103 == 24)
							{
								this.showItemIcon2 = 2650;
							}
							if (num103 == 25)
							{
								this.showItemIcon2 = 2651;
							}
							else if (num103 == 26)
							{
								this.showItemIcon2 = 2818;
							}
							else if (num103 == 27)
							{
								this.showItemIcon2 = 3171;
							}
							else if (num103 == 28)
							{
								this.showItemIcon2 = 3173;
							}
							else if (num103 == 29)
							{
								this.showItemIcon2 = 3172;
							}
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 21)
						{
							Tile tile2 = Main.tile[Player.tileTargetX, Player.tileTargetY];
							int num104 = Player.tileTargetX;
							int num105 = Player.tileTargetY;
							if (tile2.frameX % 36 != 0)
							{
								num104--;
							}
							if (tile2.frameY % 36 != 0)
							{
								num105--;
							}
							int num106 = Chest.FindChest(num104, num105);
							this.showItemIcon2 = -1;
							if (num106 >= 0)
							{
								if (Main.chest[num106].name == "")
								{
									this.showItemIconText = Lang.chestType[tile2.frameX / 36];
								}
								else
								{
									this.showItemIconText = Main.chest[num106].name;
								}
								if (this.showItemIconText == Lang.chestType[tile2.frameX / 36])
								{
									this.showItemIcon2 = Chest.chestTypeToIcon[tile2.frameX / 36];
									this.showItemIconText = "";
								}
							}
							else
							{
								this.showItemIconText = Lang.chestType[0];
							}
							this.noThrow = 2;
							this.showItemIcon = true;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 88)
						{
							Tile tile3 = Main.tile[Player.tileTargetX, Player.tileTargetY];
							int num107 = Player.tileTargetX;
							int num108 = Player.tileTargetY;
							num107 = num107 - tile3.frameX % 54 / 18;
							if (tile3.frameY % 36 != 0)
							{
								num108--;
							}
							int num109 = Chest.FindChest(num107, num108);
							this.showItemIcon2 = -1;
							if (num109 >= 0)
							{
								if (Main.chest[num109].name == "")
								{
									this.showItemIconText = Lang.dresserType[tile3.frameX / 54];
								}
								else
								{
									this.showItemIconText = Main.chest[num109].name;
								}
								if (this.showItemIconText == Lang.dresserType[tile3.frameX / 54])
								{
									this.showItemIcon2 = Chest.dresserTypeToIcon[tile3.frameX / 54];
									this.showItemIconText = "";
								}
							}
							else
							{
								this.showItemIconText = Lang.dresserType[0];
							}
							this.noThrow = 2;
							this.showItemIcon = true;
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY > 0)
							{
								this.showItemIcon2 = 269;
							}
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 10 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 11)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							int num110 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
							int num111 = 0;
							while (num110 >= 54)
							{
								num110 = num110 - 54;
								num111++;
							}
							if (num111 == 0)
							{
								this.showItemIcon2 = 25;
							}
							else if (num111 == 9)
							{
								this.showItemIcon2 = 837;
							}
							else if (num111 == 10)
							{
								this.showItemIcon2 = 912;
							}
							else if (num111 == 11)
							{
								this.showItemIcon2 = 1141;
							}
							else if (num111 == 12)
							{
								this.showItemIcon2 = 1137;
							}
							else if (num111 == 13)
							{
								this.showItemIcon2 = 1138;
							}
							else if (num111 == 14)
							{
								this.showItemIcon2 = 1139;
							}
							else if (num111 == 15)
							{
								this.showItemIcon2 = 1140;
							}
							else if (num111 == 16)
							{
								this.showItemIcon2 = 1411;
							}
							else if (num111 == 17)
							{
								this.showItemIcon2 = 1412;
							}
							else if (num111 == 18)
							{
								this.showItemIcon2 = 1413;
							}
							else if (num111 == 19)
							{
								this.showItemIcon2 = 1458;
							}
							else if (num111 >= 20 && num111 <= 23)
							{
								this.showItemIcon2 = 1709 + num111 - 20;
							}
							else if (num111 == 24)
							{
								this.showItemIcon2 = 1793;
							}
							else if (num111 == 25)
							{
								this.showItemIcon2 = 1815;
							}
							else if (num111 == 26)
							{
								this.showItemIcon2 = 1924;
							}
							else if (num111 == 27)
							{
								this.showItemIcon2 = 2044;
							}
							else if (num111 == 28)
							{
								this.showItemIcon2 = 2265;
							}
							else if (num111 == 29)
							{
								this.showItemIcon2 = 2528;
							}
							else if (num111 == 30)
							{
								this.showItemIcon2 = 2561;
							}
							else if (num111 == 31)
							{
								this.showItemIcon2 = 2576;
							}
							else if (num111 == 32)
							{
								this.showItemIcon2 = 2815;
							}
							else if (num111 == 33)
							{
								this.showItemIcon2 = 3129;
							}
							else if (num111 == 34)
							{
								this.showItemIcon2 = 3131;
							}
							else if (num111 == 35)
							{
								this.showItemIcon2 = 3130;
							}
							else if (num111 < 4 || num111 > 8)
							{
								this.showItemIcon2 = 649 + num111;
							}
							else
							{
								this.showItemIcon2 = 812 + num111;
							}
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 104)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							int num112 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 36;
							type = num112;
							switch (type)
							{
								case 0:
								{
									this.showItemIcon2 = 359;
									break;
								}
								case 1:
								{
									this.showItemIcon2 = 2237;
									break;
								}
								case 2:
								{
									this.showItemIcon2 = 2238;
									break;
								}
								case 3:
								{
									this.showItemIcon2 = 2239;
									break;
								}
								case 4:
								{
									this.showItemIcon2 = 2240;
									break;
								}
								case 5:
								{
									this.showItemIcon2 = 2241;
									break;
								}
								case 6:
								{
									this.showItemIcon2 = 2560;
									break;
								}
								case 7:
								{
									this.showItemIcon2 = 2575;
									break;
								}
								case 8:
								{
									this.showItemIcon2 = 2591;
									break;
								}
								case 9:
								{
									this.showItemIcon2 = 2592;
									break;
								}
								case 10:
								{
									this.showItemIcon2 = 2593;
									break;
								}
								case 11:
								{
									this.showItemIcon2 = 2594;
									break;
								}
								case 12:
								{
									this.showItemIcon2 = 2595;
									break;
								}
								case 13:
								{
									this.showItemIcon2 = 2596;
									break;
								}
								case 14:
								{
									this.showItemIcon2 = 2597;
									break;
								}
								case 15:
								{
									this.showItemIcon2 = 2598;
									break;
								}
								case 16:
								{
									this.showItemIcon2 = 2599;
									break;
								}
								case 17:
								{
									this.showItemIcon2 = 2600;
									break;
								}
								case 18:
								{
									this.showItemIcon2 = 2601;
									break;
								}
								case 19:
								{
									this.showItemIcon2 = 2602;
									break;
								}
								case 20:
								{
									this.showItemIcon2 = 2603;
									break;
								}
								case 21:
								{
									this.showItemIcon2 = 2604;
									break;
								}
								case 22:
								{
									this.showItemIcon2 = 2605;
									break;
								}
								case 23:
								{
									this.showItemIcon2 = 2606;
									break;
								}
								case 24:
								{
									this.showItemIcon2 = 2809;
									break;
								}
								case 25:
								{
									this.showItemIcon2 = 3126;
									break;
								}
								case 26:
								{
									this.showItemIcon2 = 3128;
									break;
								}
								case 27:
								{
									this.showItemIcon2 = 3127;
									break;
								}
							}
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 356)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							this.showItemIcon2 = 3064;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 377)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							this.showItemIcon2 = 3198;
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
							else if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 216)
							{
								this.showItemIcon2 = 3369;
							}
							int num113 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18;
							while (num113 >= 4)
							{
								num113 = num113 - 4;
							}
							if (num113 >= 2)
							{
								this.showItemIconR = false;
							}
							else
							{
								this.showItemIconR = true;
							}
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 216)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							int num114 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
							int num115 = 0;
							while (num114 >= 40)
							{
								num114 = num114 - 40;
								num115++;
							}
							this.showItemIcon2 = 970 + num115;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 387 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 386)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							int num116 = 0;
							int num117 = 0;
							WorldGen.GetTopLeftAndStyles(ref num116, ref num117, 2, 1 + (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 386).ToInt(), 18, 18);
							this.showItemIcon2 = 3239;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 389 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 388)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							this.showItemIcon2 = 3240;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 335)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							this.showItemIcon2 = 2700;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 410)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							this.showItemIcon2 = 3536 + Math.Min(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 36, 3);
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 411 && Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 36)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							this.showItemIcon2 = 3545;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 338)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							this.showItemIcon2 = 2738;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 219 && (this.inventory[this.selectedItem].type == 424 || this.inventory[this.selectedItem].type == 1103))
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							this.showItemIcon2 = this.inventory[this.selectedItem].type;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 212)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							this.showItemIcon2 = 949;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 314 && this.gravDir == 1f)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							this.showItemIcon2 = 2343;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 215)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							int num118 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 48;
							if (num118 == 0)
							{
								this.showItemIcon2 = 966;
							}
							else if (num118 != 6)
							{
								this.showItemIcon2 = 3046 + num118 - 1;
							}
							else
							{
								this.showItemIcon2 = 3050;
							}
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 4)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							int num119 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 22;
							if (num119 == 0)
							{
								this.showItemIcon2 = 8;
							}
							else if (num119 == 8)
							{
								this.showItemIcon2 = 523;
							}
							else if (num119 == 9)
							{
								this.showItemIcon2 = 974;
							}
							else if (num119 == 10)
							{
								this.showItemIcon2 = 1245;
							}
							else if (num119 == 11)
							{
								this.showItemIcon2 = 1333;
							}
							else if (num119 == 12)
							{
								this.showItemIcon2 = 2274;
							}
							else if (num119 == 13)
							{
								this.showItemIcon2 = 3004;
							}
							else if (num119 == 14)
							{
								this.showItemIcon2 = 3045;
							}
							else if (num119 != 15)
							{
								this.showItemIcon2 = 426 + num119;
							}
							else
							{
								this.showItemIcon2 = 3114;
							}
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 13)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							int num120 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18;
							if (num120 == 1)
							{
								this.showItemIcon2 = 28;
							}
							else if (num120 == 2)
							{
								this.showItemIcon2 = 110;
							}
							else if (num120 == 3)
							{
								this.showItemIcon2 = 350;
							}
							else if (num120 == 4)
							{
								this.showItemIcon2 = 351;
							}
							else if (num120 == 5)
							{
								this.showItemIcon2 = 2234;
							}
							else if (num120 == 6)
							{
								this.showItemIcon2 = 2244;
							}
							else if (num120 == 7)
							{
								this.showItemIcon2 = 2257;
							}
							else if (num120 != 8)
							{
								this.showItemIcon2 = 31;
							}
							else
							{
								this.showItemIcon2 = 2258;
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
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 49)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							this.showItemIcon2 = 148;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 174)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							this.showItemIcon2 = 713;
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
							int num121 = Player.tileTargetX;
							int num122 = Player.tileTargetY;
							int num123 = 0;
							for (int y21 = Main.tile[num121, num122].frameY / 18; y21 >= 2; y21 = y21 - 2)
							{
								num123++;
							}
							this.showItemIcon = true;
							if (num123 == 28)
							{
								this.showItemIcon2 = 1963;
							}
							else if (num123 == 29)
							{
								this.showItemIcon2 = 1964;
							}
							else if (num123 == 30)
							{
								this.showItemIcon2 = 1965;
							}
							else if (num123 == 31)
							{
								this.showItemIcon2 = 2742;
							}
							else if (num123 == 32)
							{
								this.showItemIcon2 = 3044;
							}
							else if (num123 == 33)
							{
								this.showItemIcon2 = 3235;
							}
							else if (num123 == 34)
							{
								this.showItemIcon2 = 3236;
							}
							else if (num123 == 35)
							{
								this.showItemIcon2 = 3237;
							}
							else if (num123 == 36)
							{
								this.showItemIcon2 = 3370;
							}
							else if (num123 == 37)
							{
								this.showItemIcon2 = 3371;
							}
							else if (num123 < 13)
							{
								this.showItemIcon2 = 562 + num123;
							}
							else
							{
								this.showItemIcon2 = 1596 + num123 - 13;
							}
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 207)
						{
							this.noThrow = 2;
							int num124 = Player.tileTargetX;
							int num125 = Player.tileTargetY;
							int num126 = 0;
							for (int a = Main.tile[num124, num125].frameX / 18; a >= 2; a = a - 2)
							{
								num126++;
							}
							this.showItemIcon = true;
							if (num126 == 0)
							{
								this.showItemIcon2 = 909;
							}
							else if (num126 == 1)
							{
								this.showItemIcon2 = 910;
							}
							else if (num126 == 2)
							{
								this.showItemIcon2 = 940;
							}
							else if (num126 == 3)
							{
								this.showItemIcon2 = 941;
							}
							else if (num126 == 4)
							{
								this.showItemIcon2 = 942;
							}
							else if (num126 == 5)
							{
								this.showItemIcon2 = 943;
							}
							else if (num126 == 6)
							{
								this.showItemIcon2 = 944;
							}
							else if (num126 == 7)
							{
								this.showItemIcon2 = 945;
							}
						}
						if (Main.tileSign[Main.tile[Player.tileTargetX, Player.tileTargetY].type])
						{
							this.noThrow = 2;
							int num127 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18;
							int num128 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18;
							num127 = num127 % 2;
							int num129 = Player.tileTargetX - num127;
							int num130 = Player.tileTargetY - num128;
							Main.signBubble = true;
							Main.signX = num129 * 16 + 16;
							Main.signY = num130 * 16;
							int num131 = Sign.ReadSign(num129, num130, false);
							if (num131 != -1)
							{
								Main.signHover = num131;
							}
							if (num131 != -1)
							{
								Main.signHover = num131;
								this.showItemIcon = false;
								this.showItemIcon2 = -1;
							}
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 237)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							this.showItemIcon2 = 1293;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 125)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							this.showItemIcon2 = 487;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 354)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							this.showItemIcon2 = 2999;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 287)
						{
							this.noThrow = 2;
							this.showItemIcon = true;
							this.showItemIcon2 = 2177;
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
							this.showItemIcon2 = 583 + Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18;
						}
						if (!this.controlUseTile)
						{
							this.releaseUseTile = true;
						}
						else
						{
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 212 && this.launcherWait <= 0)
							{
								int num132 = Player.tileTargetX;
								int num133 = Player.tileTargetY;
								bool flag25 = false;
								int num134 = 0;
								while (num134 < 58)
								{
									if (this.inventory[num134].type != 949 || this.inventory[num134].stack <= 0)
									{
										num134++;
									}
									else
									{
										Item item = this.inventory[num134];
										item.stack = item.stack - 1;
										if (this.inventory[num134].stack <= 0)
										{
											this.inventory[num134].SetDefaults(0, false);
										}
										flag25 = true;
										break;
									}
								}
								if (flag25)
								{
									this.launcherWait = 10;
									int num135 = Main.tile[num132, num133].frameX / 18;
									int num136 = 0;
									while (num135 >= 3)
									{
										num136++;
										num135 = num135 - 3;
									}
									num135 = num132 - num135;
									int num137 = Main.tile[num132, num133].frameY / 18;
									while (num137 >= 3)
									{
										num137 = num137 - 3;
									}
									num137 = num133 - num137;
									float single24 = 12f + (float)Main.rand.Next(450) * 0.01f;
									float single25 = (float)Main.rand.Next(85, 105);
									float single26 = (float)Main.rand.Next(-35, 11);
									int num138 = 166;
									int num139 = 35;
									float single27 = 3.5f;
									Vector2 x14 = new Vector2((float)((num135 + 2) * 16 - 8), (float)((num137 + 2) * 16 - 8));
									if (num136 != 0)
									{
										x14.X = x14.X + 12f;
									}
									else
									{
										single25 = single25 * -1f;
										x14.X = x14.X - 12f;
									}
									float single28 = single25;
									float single29 = single26;
									float single30 = (float)Math.Sqrt((double)(single28 * single28 + single29 * single29));
									single30 = single24 / single30;
									single28 = single28 * single30;
									single29 = single29 * single30;
									Projectile.NewProjectile(x14.X, x14.Y, single28, single29, num138, num139, single27, Main.myPlayer, 0f, 0f);
								}
							}
							if (this.releaseUseTile)
							{
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 132 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 136 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 144)
								{
									Wiring.HitSwitch(Player.tileTargetX, Player.tileTargetY);
									NetMessage.SendData((int)PacketTypes.HitSwitch, -1, -1, "", Player.tileTargetX, (float)Player.tileTargetY, 0f, 0f, 0, 0, 0);
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 139)
								{
									WorldGen.SwitchMB(Player.tileTargetX, Player.tileTargetY);
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 215)
								{
									int num140 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameX % 54 / 18;
									int num141 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameY % 36 / 18;
									int num142 = Player.tileTargetX - num140;
									int num143 = Player.tileTargetY - num141;
									int num144 = 36;
									if (Main.tile[num142, num143].frameY >= 36)
									{
										num144 = -36;
									}
									for (int b = num142; b < num142 + 3; b++)
									{
										for (int c = num143; c < num143 + 2; c++)
										{
											Main.tile[b, c].frameY = (short)(Main.tile[b, c].frameY + num144);
										}
									}
									NetMessage.SendTileSquare(-1, num142 + 1, num143 + 1, 3);
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 207)
								{
									WorldGen.SwitchFountain(Player.tileTargetX, Player.tileTargetY);
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 410)
								{
									WorldGen.SwitchMonolith(Player.tileTargetX, Player.tileTargetY);
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 216)
								{
									WorldGen.LaunchRocket(Player.tileTargetX, Player.tileTargetY);
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 386 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 387)
								{
									bool flag26 = Main.tile[Player.tileTargetX, Player.tileTargetY].type == 387;
									int num145 = WorldGen.ShiftTrapdoor(Player.tileTargetX, Player.tileTargetY, (float)(Player.tileTargetY * 16) > base.Center.Y, -1).ToInt();
									if (num145 == 0)
									{
										num145 = -WorldGen.ShiftTrapdoor(Player.tileTargetX, Player.tileTargetY, (float)(Player.tileTargetY * 16) <= base.Center.Y, -1).ToInt();
									}
									if (num145 != 0)
									{
										NetMessage.SendData((int)PacketTypes.DoorUse, -1, -1, "", 2 + flag26.ToInt(), (float)Player.tileTargetX, (float)Player.tileTargetY, (float)(num145 * Math.Sign((float)(Player.tileTargetY * 16) - base.Center.Y)), 0, 0, 0);
									}
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 388 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 389)
								{
									bool flag27 = Main.tile[Player.tileTargetX, Player.tileTargetY].type == 389;
									WorldGen.ShiftTallGate(Player.tileTargetX, Player.tileTargetY, flag27);
									NetMessage.SendData((int)PacketTypes.DoorUse, -1, -1, "", 4 + flag27.ToInt(), (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 335)
								{
									WorldGen.LaunchRocketSmall(Player.tileTargetX, Player.tileTargetY);
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 411 && Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 36)
								{
									Wiring.HitSwitch(Player.tileTargetX, Player.tileTargetY);
									NetMessage.SendData((int)PacketTypes.HitSwitch, -1, -1, "", Player.tileTargetX, (float)Player.tileTargetY, 0f, 0f, 0, 0, 0);
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 338)
								{
									int num146 = Player.tileTargetX;
									int num147 = Player.tileTargetY;
									if (Main.tile[num146, num147].frameY == 18)
									{
										num147--;
									}
									bool flag28 = false;
									int num148 = 0;
									while (num148 < 1000)
									{
										if (!Main.projectile[num148].active || Main.projectile[num148].aiStyle != 73 || Main.projectile[num148].ai[0] != (float)num146 || Main.projectile[num148].ai[1] != (float)num147)
										{
											num148++;
										}
										else
										{
											flag28 = true;
											break;
										}
									}
									if (!flag28)
									{
										Projectile.NewProjectile((float)(num146 * 16 + 8), (float)(num147 * 16 + 2), 0f, 0f, 419 + Main.rand.Next(4), 0, 0f, this.whoAmI, (float)num146, (float)num147);
									}
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 4 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 13 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 33 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 49 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 50 && Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 90 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 174)
								{
									WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
									if (Main.netMode == 1)
									{
										NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
									}
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 334)
								{
									if (!this.ItemFitsWeaponRack(this.inventory[this.selectedItem]))
									{
										int num149 = Player.tileTargetX;
										int num150 = Player.tileTargetY;
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY == 0)
										{
											num150++;
										}
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY == 36)
										{
											num150--;
										}
										int num151 = Main.tile[Player.tileTargetX, num150].frameX;
										int num152 = Main.tile[Player.tileTargetX, num150].frameX;
										int num153 = 0;
										while (num152 >= 5000)
										{
											num152 = num152 - 5000;
											num153++;
										}
										if (num153 != 0)
										{
											num152 = (num153 - 1) * 18;
										}
										num152 = num152 % 54;
										if (num152 == 18)
										{
											num151 = Main.tile[Player.tileTargetX - 1, num150].frameX;
											num149--;
										}
										if (num152 == 36)
										{
											num151 = Main.tile[Player.tileTargetX - 2, num150].frameX;
											num149 = num149 - 2;
										}
										if (num151 >= 5000)
										{
											WorldGen.KillTile(Player.tileTargetX, num150, true, false, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)Player.tileTargetX, (float)num150, 1f, 0, 0, 0);
											}
										}
									}
									else
									{
										this.PlaceWeapon(Player.tileTargetX, Player.tileTargetY);
									}
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 395 && !this.inventory[this.selectedItem].favorited)
								{
									if (!this.ItemFitsItemFrame(this.inventory[this.selectedItem]))
									{
										int num154 = Player.tileTargetX;
										int num155 = Player.tileTargetY;
										if (Main.tile[num154, num155].frameX % 36 != 0)
										{
											num154--;
										}
										if (Main.tile[num154, num155].frameY % 36 != 0)
										{
											num155--;
										}
										int num156 = TEItemFrame.Find(num154, num155);
										if (num156 != -1 && ((TEItemFrame)TileEntity.ByID[num156]).item.stack > 0)
										{
											WorldGen.KillTile(Player.tileTargetX, num155, true, false, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)Player.tileTargetX, (float)num155, 1f, 0, 0, 0);
											}
										}
									}
									else
									{
										this.PlaceItemInFrame(Player.tileTargetX, Player.tileTargetY);
									}
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 125)
								{
									this.AddBuff(BuffID.Clairvoyance, 36000, true);
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 377)
								{
									this.AddBuff(BuffID.Sharpened, 36000, true);
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 354)
								{
									this.AddBuff(BuffID.Bewitched, 36000, true);
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 287)
								{
									this.AddBuff(BuffID.AmmoBox, 36000, true);
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 356)
								{
									if (!Main.fastForwardTime && (Main.netMode == 1 || Main.sundialCooldown == 0))
									{
										Main.Sundialing();
									}
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 79)
								{
									int num157 = Player.tileTargetX;
									int num158 = Player.tileTargetY;
									num157 = num157 + Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18 * -1;
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 72)
									{
										num157 = num157 + 2;
									}
									else
									{
										num157 = num157 + 4;
										num157++;
									}
									int num159 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18;
									int num160 = 0;
									while (num159 > 1)
									{
										num159 = num159 - 2;
										num160++;
									}
									num158 = num158 - num159;
									num158 = num158 + 2;
									this.FindSpawn();
									if (this.SpawnX == num157 && this.SpawnY == num158)
									{
										this.RemoveSpawn();
										Main.NewText("Spawn point removed!", 255, 240, 20, false);
									}
									else if (Player.CheckSpawn(num157, num158))
									{
										this.ChangeSpawn(num157, num158);
										Main.NewText("Spawn point set!", 255, 240, 20, false);
									}
								}
								else if (Main.tileSign[Main.tile[Player.tileTargetX, Player.tileTargetY].type])
								{
									bool flag29 = true;
									if (this.sign >= 0 && Sign.ReadSign(Player.tileTargetX, Player.tileTargetY, true) == this.sign)
									{
										this.sign = -1;
										Main.npcChatText = "";
										Main.editSign = false;
										flag29 = false;
									}
									if (flag29)
									{
										if (Main.netMode != 0)
										{
											int num161 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18;
											int num162 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18;
											while (num161 > 1)
											{
												num161 = num161 - 2;
											}
											int num163 = Player.tileTargetX - num161;
											int num164 = Player.tileTargetY - num162;
											if (Main.tileSign[Main.tile[num163, num164].type])
											{
												NetMessage.SendData((int)PacketTypes.SignRead, -1, -1, "", num163, (float)num164, 0f, 0f, 0, 0, 0);
											}
										}
										else
										{
											this.talkNPC = -1;
											Main.npcChatCornerItem = 0;
											Main.playerInventory = false;
											Main.editSign = false;
											int num165 = Sign.ReadSign(Player.tileTargetX, Player.tileTargetY, true);
											this.sign = num165;
											Main.npcChatText = Main.sign[num165].text;
										}
									}
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 104)
								{
									string str1 = "AM";
									double num166 = Main.time;
									if (!Main.dayTime)
									{
										num166 = num166 + 54000;
									}
									num166 = num166 / 86400 * 24;
									num166 = num166 - 7.5 - 12;
									if (num166 < 0)
									{
										num166 = num166 + 24;
									}
									if (num166 >= 12)
									{
										str1 = "PM";
									}
									int num167 = (int)num166;
									double num168 = num166 - (double)num167;
									num168 = (double)((int)(num168 * 60));
									string str2 = string.Concat(num168);
									if (num168 < 10)
									{
										str2 = string.Concat("0", str2);
									}
									if (num167 > 12)
									{
										num167 = num167 - 12;
									}
									if (num167 == 0)
									{
										num167 = 12;
									}
									object[] objArray = new object[] { "Time: ", num167, ":", str2, " ", str1 };
									string str3 = string.Concat(objArray);
									Main.NewText(str3, 255, 240, 20, false);
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 237)
								{
									bool flag30 = false;
									if (!NPC.AnyNPCs(NPCID.Golem) && Main.hardMode && NPC.downedPlantBoss)
									{
										int num169 = 0;
										while (num169 < 58)
										{
											if (this.inventory[num169].type != 1293)
											{
												num169++;
											}
											else
											{
												Item item1 = this.inventory[num169];
												item1.stack = item1.stack - 1;
												if (this.inventory[num169].stack <= 0)
												{
													this.inventory[num169].SetDefaults(0, false);
												}
												flag30 = true;
												break;
											}
										}
									}
									if (flag30)
									{
										if (Main.netMode == 1)
										{
											NetMessage.SendData((int)PacketTypes.SpawnBossorInvasion, -1, -1, "", this.whoAmI, 245f, 0f, 0f, 0, 0, 0);
										}
										else
										{
											NPC.SpawnOnPlayer(i, 245);
										}
									}
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 10)
								{
									int num170 = Player.tileTargetX;
									int num171 = Player.tileTargetY;
									if (Main.tile[num170, num171].frameY < 594 || Main.tile[num170, num171].frameY > 646)
									{
										WorldGen.OpenDoor(Player.tileTargetX, Player.tileTargetY, this.direction);
										NetMessage.SendData((int)PacketTypes.DoorUse, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.direction, 0, 0, 0);
									}
									else
									{
										int num172 = 1141;
										for (int d = 0; d < 58; d++)
										{
											if (this.inventory[d].type == num172 && this.inventory[d].stack > 0)
											{
												Item item2 = this.inventory[d];
												item2.stack = item2.stack - 1;
												if (this.inventory[d].stack <= 0)
												{
													this.inventory[d] = new Item();
												}
												WorldGen.UnlockDoor(num170, num171);
												if (Main.netMode == 1)
												{
													NetMessage.SendData((int)PacketTypes.ChestUnlock, -1, -1, "", this.whoAmI, 2f, (float)num170, (float)num171, 0, 0, 0);
												}
											}
										}
									}
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 11 && WorldGen.CloseDoor(Player.tileTargetX, Player.tileTargetY, false))
								{
									NetMessage.SendData((int)PacketTypes.DoorUse, -1, -1, "", 1, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.direction, 0, 0, 0);
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 88)
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY != 0)
									{
										Main.playerInventory = false;
										this.chest = -1;
										Main.dresserX = Player.tileTargetX;
										Main.dresserY = Player.tileTargetY;
										Main.OpenClothesWindow();
									}
									else
									{
										Main.CancelClothesWindow(true);
										Main.mouseRightRelease = false;
										int num173 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18;
										num173 = num173 % 3;
										num173 = Player.tileTargetX - num173;
										int num174 = Player.tileTargetY - Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18;
										if (this.sign > -1)
										{
											this.sign = -1;
											Main.editSign = false;
											Main.npcChatText = string.Empty;
										}
										if (Main.editChest)
										{
											Main.editChest = false;
											Main.npcChatText = string.Empty;
										}
										if (this.editedChestName)
										{
											NetMessage.SendData((int)PacketTypes.ChestOpen, -1, -1, Main.chest[this.chest].name, this.chest, 1f, 0f, 0f, 0, 0, 0);
											this.editedChestName = false;
										}
										if (Main.netMode != 1)
										{
											this.flyingPigChest = -1;
											int num175 = Chest.FindChest(num173, num174);
											if (num175 != -1)
											{
												Main.stackSplit = 600;
												if (num175 == this.chest)
												{
													this.chest = -1;
												}
												else if (num175 == this.chest || this.chest != -1)
												{
													this.chest = num175;
													Main.playerInventory = true;
													Main.recBigList = false;
													this.chestX = num173;
													this.chestY = num174;
												}
												else
												{
													this.chest = num175;
													Main.playerInventory = true;
													Main.recBigList = false;
													this.chestX = num173;
													this.chestY = num174;
												}
												Recipe.FindRecipes();
											}
										}
										else if (num173 != this.chestX || num174 != this.chestY || this.chest == -1)
										{
											NetMessage.SendData((int)PacketTypes.ChestGetContents, -1, -1, "", num173, (float)num174, 0f, 0f, 0, 0, 0);
											Main.stackSplit = 600;
										}
										else
										{
											this.chest = -1;
										}
									}
								}
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 209)
								{
									WorldGen.SwitchCannon(Player.tileTargetX, Player.tileTargetY);
								}
								else if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 21 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 29 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 97) && this.talkNPC == -1)
								{
									Main.mouseRightRelease = false;
									int num176 = 0;
									int num177 = Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18;
									while (num177 > 1)
									{
										num177 = num177 - 2;
									}
									num177 = Player.tileTargetX - num177;
									int num178 = Player.tileTargetY - Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18;
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 29)
									{
										num176 = 1;
									}
									else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 97)
									{
										num176 = 2;
									}
									if (this.sign > -1)
									{
										this.sign = -1;
										Main.editSign = false;
										Main.npcChatText = string.Empty;
									}
									if (Main.editChest)
									{
										Main.editChest = false;
										Main.npcChatText = string.Empty;
									}
									if (this.editedChestName)
									{
										NetMessage.SendData((int)PacketTypes.ChestOpen, -1, -1, Main.chest[this.chest].name, this.chest, 1f, 0f, 0f, 0, 0, 0);
										this.editedChestName = false;
									}
									if (Main.netMode != 1 || num176 != 0 || Main.tile[num177, num178].frameX >= 72 && Main.tile[num177, num178].frameX <= 106 || Main.tile[num177, num178].frameX >= 144 && Main.tile[num177, num178].frameX <= 178 || Main.tile[num177, num178].frameX >= 828 && Main.tile[num177, num178].frameX <= 1006 || Main.tile[num177, num178].frameX >= 1296 && Main.tile[num177, num178].frameX <= 1330 || Main.tile[num177, num178].frameX >= 1368 && Main.tile[num177, num178].frameX <= 1402 || Main.tile[num177, num178].frameX >= 1440 && Main.tile[num177, num178].frameX <= 1474)
									{
										int num179 = -1;
										if (num176 == 1)
										{
											num179 = -2;
										}
										else if (num176 != 2)
										{
											bool flag31 = false;
											if (Chest.isLocked(num177, num178))
											{
												int num180 = 327;
												if (Main.tile[num177, num178].frameX >= 144 && Main.tile[num177, num178].frameX <= 178)
												{
													num180 = 329;
												}
												if (Main.tile[num177, num178].frameX >= 828 && Main.tile[num177, num178].frameX <= 1006)
												{
													int num181 = Main.tile[num177, num178].frameX / 18;
													int num182 = 0;
													while (num181 >= 2)
													{
														num181 = num181 - 2;
														num182++;
													}
													num182 = num182 - 23;
													num180 = 1533 + num182;
												}
												flag31 = true;
												for (int e = 0; e < 58; e++)
												{
													if (this.inventory[e].type == num180 && this.inventory[e].stack > 0 && Chest.Unlock(num177, num178))
													{
														if (num180 != 329)
														{
															Item item3 = this.inventory[e];
															item3.stack = item3.stack - 1;
															if (this.inventory[e].stack <= 0)
															{
																this.inventory[e] = new Item();
															}
														}
														if (Main.netMode == 1)
														{
															NetMessage.SendData((int)PacketTypes.ChestUnlock, -1, -1, "", this.whoAmI, 1f, (float)num177, (float)num178, 0, 0, 0);
														}
													}
												}
											}
											if (!flag31)
											{
												num179 = Chest.FindChest(num177, num178);
											}
										}
										else
										{
											num179 = -3;
										}
										if (num179 != -1)
										{
											Main.stackSplit = 600;
											if (num179 == this.chest)
											{
												this.chest = -1;
											}
											else if (num179 == this.chest || this.chest != -1)
											{
												this.chest = num179;
												Main.playerInventory = true;
												Main.recBigList = false;
												this.chestX = num177;
												this.chestY = num178;
											}
											else
											{
												this.chest = num179;
												Main.playerInventory = true;
												Main.recBigList = false;
												this.chestX = num177;
												this.chestY = num178;
												if (Main.tile[num177, num178].frameX >= 36 && Main.tile[num177, num178].frameX < 72)
												{
													AchievementsHelper.HandleSpecialEvent(this, 16);
												}
											}
											Recipe.FindRecipes();
										}
									}
									else if (num177 != this.chestX || num178 != this.chestY || this.chest == -1)
									{
										NetMessage.SendData((int)PacketTypes.ChestGetContents, -1, -1, "", num177, (float)num178, 0f, 0f, 0, 0, 0);
										Main.stackSplit = 600;
									}
									else
									{
										this.chest = -1;
									}
								}
								else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 314 && this.gravDir == 1f)
								{
									bool flag32 = true;
									if (this.mount.Active)
									{
										if (!this.mount.Cart)
										{
											this.mount.Dismount(this);
										}
										else
										{
											flag32 = false;
										}
									}
									if (flag32)
									{
										Vector2 vector232 = new Vector2((float)Main.mouseX + Main.screenPosition.X, (float)Main.mouseY + Main.screenPosition.Y);
										if (this.direction <= 0)
										{
											this.minecartLeft = true;
										}
										else
										{
											this.minecartLeft = false;
										}
										this.grappling[0] = -1;
										this.grapCount = 0;
										for (int f = 0; f < 1000; f++)
										{
											if (Main.projectile[f].active && Main.projectile[f].owner == this.whoAmI && Main.projectile[f].aiStyle == 7)
											{
												Main.projectile[f].Kill();
											}
										}
										Projectile.NewProjectile(vector232.X, vector232.Y, 0f, 0f, 403, 0, 0f, this.whoAmI, 0f, 0f);
									}
								}
							}
							this.releaseUseTile = false;
						}
					}
				}
			}
			if (this.tongued)
			{
				bool flag33 = false;
				if (Main.wof < 0)
				{
					flag33 = true;
				}
				else
				{
					float x15 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2);
					x15 = x15 + (float)(Main.npc[Main.wof].direction * 200);
					float y22 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2);
					Vector2 vector233 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float x16 = x15 - vector233.X;
					float y23 = y22 - vector233.Y;
					float single31 = (float)Math.Sqrt((double)(x16 * x16 + y23 * y23));
					float single32 = 11f;
					float single33 = single31;
					if (single31 <= single32)
					{
						single33 = 1f;
						flag33 = true;
					}
					else
					{
						single33 = single32 / single31;
					}
					x16 = x16 * single33;
					y23 = y23 * single33;
					this.velocity.X = x16;
					this.velocity.Y = y23;
				}
				if (flag33 && Main.myPlayer == this.whoAmI)
				{
					for (int g = 0; g < 22; g++)
					{
						if (this.buffType[g] == BuffID.TheTongue)
						{
							this.DelBuff(g);
						}
					}
				}
			}
			if (Main.myPlayer == this.whoAmI)
			{
				this.WOFTongue();
				if (!this.controlHook)
				{
					this.releaseHook = true;
				}
				else
				{
					if (this.releaseHook)
					{
						this.QuickGrapple();
					}
					this.releaseHook = false;
				}
				if (this.talkNPC >= 0)
				{
					Rectangle rectangle1 = new Rectangle((int)(this.position.X + (float)(this.width / 2) - (float)(Player.tileRangeX * 16)), (int)(this.position.Y + (float)(this.height / 2) - (float)(Player.tileRangeY * 16)), Player.tileRangeX * 16 * 2, Player.tileRangeY * 16 * 2);
					Rectangle rectangle2 = new Rectangle((int)Main.npc[this.talkNPC].position.X, (int)Main.npc[this.talkNPC].position.Y, Main.npc[this.talkNPC].width, Main.npc[this.talkNPC].height);
					if (!rectangle1.Intersects(rectangle2) || this.chest != -1 || !Main.npc[this.talkNPC].active)
					{
						this.talkNPC = -1;
						Main.npcChatCornerItem = 0;
						Main.npcChatText = "";
					}
				}
				if (this.sign >= 0)
				{
					Rectangle rectangle3 = new Rectangle((int)(this.position.X + (float)(this.width / 2) - (float)(Player.tileRangeX * 16)), (int)(this.position.Y + (float)(this.height / 2) - (float)(Player.tileRangeY * 16)), Player.tileRangeX * 16 * 2, Player.tileRangeY * 16 * 2);
					try
					{
						bool flag34 = false;
						if (Main.sign[this.sign] == null)
						{
							flag34 = true;
						}
						if (!flag34 && !(new Rectangle(Main.sign[this.sign].x * 16, Main.sign[this.sign].y * 16, 32, 32)).Intersects(rectangle3))
						{
							flag34 = true;
						}
						if (flag34)
						{
							this.sign = -1;
							Main.editSign = false;
							Main.npcChatText = "";
						}
					}
					catch
					{
						this.sign = -1;
						Main.editSign = false;
						Main.npcChatText = "";
					}
				}
				if (Main.editSign)
				{
					if (this.sign != -1)
					{
						Main.npcChatText = Main.GetInputText(Main.npcChatText);
						if (Main.inputTextEnter)
						{
							byte[] numArray = new byte[] { 10 };
							Main.npcChatText = string.Concat(Main.npcChatText, Encoding.ASCII.GetString(numArray));
						}
						else if (Main.inputTextEscape)
						{
							Main.editSign = false;
							Main.npcChatText = Main.sign[this.sign].text;
						}
					}
					else
					{
						Main.editSign = false;
					}
				}
				else if (Main.editChest)
				{
					string inputText = Main.GetInputText(Main.npcChatText);
					if (Main.inputTextEnter)
					{
						Main.editChest = false;
						int num183 = Main.player[Main.myPlayer].chest;
						if (Main.npcChatText == Main.defaultChestName)
						{
							Main.npcChatText = "";
						}
						if (Main.chest[num183].name != Main.npcChatText)
						{
							Main.chest[num183].name = Main.npcChatText;
							if (Main.netMode == 1)
							{
								this.editedChestName = true;
							}
						}
					}
					else if (Main.inputTextEscape)
					{
						Main.editChest = false;
						Main.npcChatText = string.Empty;
					}
					else if (inputText.Length <= 20)
					{
						Main.npcChatText = inputText;
					}
				}
				if (this.mount.Active && this.mount.Cart && Math.Abs(this.velocity.X) > 4f)
				{
					Rectangle rectangle4 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
					for (int h = 0; h < 200; h++)
					{
						if (Main.npc[h].active && !Main.npc[h].friendly && Main.npc[h].damage > 0 && Main.npc[h].immune[i] == 0 && rectangle4.Intersects(new Rectangle((int)Main.npc[h].position.X, (int)Main.npc[h].position.Y, Main.npc[h].width, Main.npc[h].height)))
						{
							float single34 = (float)this.meleeCrit;
							if (single34 < (float)this.rangedCrit)
							{
								single34 = (float)this.rangedCrit;
							}
							if (single34 < (float)this.magicCrit)
							{
								single34 = (float)this.magicCrit;
							}
							bool flag35 = false;
							if ((float)Main.rand.Next(1, 101) <= single34)
							{
								flag35 = true;
							}
							float single35 = Math.Abs(this.velocity.X) / this.maxRunSpeed;
							int num184 = Main.DamageVar(25f + 55f * single35);
							if (this.mount.Type == 11)
							{
								num184 = Main.DamageVar(50f + 100f * single35);
							}
							if (this.mount.Type == 13)
							{
								num184 = Main.DamageVar(15f + 30f * single35);
							}
							float single36 = 5f + 25f * single35;
							int num185 = 1;
							if (this.velocity.X < 0f)
							{
								num185 = -1;
							}
							Main.npc[h].StrikeNPC(num184, single36, num185, flag35, false, false, this);
							if (Main.netMode != 0)
							{
								NetMessage.SendData((int)PacketTypes.NpcStrike, -1, -1, "", h, (float)num184, single36, (float)(-num185), 0, 0, 0);
							}
							Main.npc[h].immune[i] = 30;
							if (!Main.npc[h].active)
							{
								AchievementsHelper.HandleSpecialEvent(this, 9);
							}
						}
					}
				}
				if (!this.immune)
				{
					Rectangle rectangle5 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
					for (int i11 = 0; i11 < 200; i11++)
					{
						if (Main.npc[i11].active && !Main.npc[i11].friendly && Main.npc[i11].damage > 0 && (this.dash != 2 || i11 != this.eocHit || this.eocDash <= 0) && !this.npcTypeNoAggro[Main.npc[i11].type])
						{
							float single37 = 1f;
							Rectangle width1 = new Rectangle((int)Main.npc[i11].position.X, (int)Main.npc[i11].position.Y, Main.npc[i11].width, Main.npc[i11].height);
							if (Main.npc[i11].type >= NPCID.ArmedZombie && Main.npc[i11].type <= NPCID.ArmedZombieCenx && Main.npc[i11].ai[2] > 5f)
							{
								int num186 = 34;
								if (Main.npc[i11].spriteDirection >= 0)
								{
									width1.Width = width1.Width + num186;
								}
								else
								{
									width1.X = width1.X - num186;
									width1.Width = width1.Width + num186;
								}
								single37 = single37 * 1.25f;
							}
							else if (Main.npc[i11].type >= NPCID.Crawdad && Main.npc[i11].type <= NPCID.Crawdad2 && Main.npc[i11].ai[2] > 5f)
							{
								int num187 = 18;
								if (Main.npc[i11].spriteDirection >= 0)
								{
									width1.Width = width1.Width + num187;
								}
								else
								{
									width1.X = width1.X - num187;
									width1.Width = width1.Width + num187;
								}
								single37 = single37 * 1.25f;
							}
							else if (Main.npc[i11].type == NPCID.Butcher)
							{
								Rectangle rectangle6 = new Rectangle(0, 0, 30, 14)
								{
									X = (int)Main.npc[i11].Center.X
								};
								if (Main.npc[i11].direction < 0)
								{
									rectangle6.X = rectangle6.X - rectangle6.Width;
								}
								rectangle6.Y = (int)Main.npc[i11].position.Y + Main.npc[i11].height - 20;
								if (rectangle5.Intersects(rectangle6))
								{
									width1 = rectangle6;
									single37 = single37 * 1.35f;
								}
							}
							else if (Main.npc[i11].type == NPCID.SolarSroller && Main.npc[i11].ai[0] == 6f && Main.npc[i11].ai[3] > 0f && Main.npc[i11].ai[3] < 4f)
							{
								Rectangle rectangle7 = Terraria.Utils.CenteredRectangle(Main.npc[i11].Center, new Vector2(100f));
								if (rectangle5.Intersects(rectangle7))
								{
									width1 = rectangle7;
									single37 = single37 * 1.35f;
								}
							}
							else if (Main.npc[i11].type == NPCID.Psycho)
							{
								Rectangle rectangle8 = new Rectangle(0, 0, 30, 8)
								{
									X = (int)Main.npc[i11].Center.X
								};
								if (Main.npc[i11].direction < 0)
								{
									rectangle8.X = rectangle8.X - rectangle8.Width;
								}
								rectangle8.Y = (int)Main.npc[i11].position.Y + Main.npc[i11].height - 32;
								if (rectangle5.Intersects(rectangle8))
								{
									width1 = rectangle8;
									single37 = single37 * 1.75f;
								}
							}
							if (rectangle5.Intersects(width1) && !this.npcTypeNoAggro[Main.npc[i11].type])
							{
								int num188 = -1;
								if (Main.npc[i11].position.X + (float)(Main.npc[i11].width / 2) < this.position.X + (float)(this.width / 2))
								{
									num188 = 1;
								}
								int num189 = Main.DamageVar((float)Main.npc[i11].damage * single37);
								int num190 = Item.NPCtoBanner(Main.npc[i11].BannerID());
								if (num190 > 0 && this.NPCBannerBuff[num190])
								{
									if (Main.expertMode)
									{
										num189 = (int)((double)num189 * 0.5);
									}
									else
									{
										num189 = (int)((double)num189 * 0.75);
									}
								}
								int type5 = Main.npc[i11].type;
								if (this.whoAmI == Main.myPlayer && this.thorns > 0f && !this.immune && !Main.npc[i11].dontTakeDamage)
								{
									int num191 = (int)((float)num189 * this.thorns);
									int num192 = 10;
									if (this.turtleThorns)
									{
										num191 = num189;
									}
									Main.npc[i11].StrikeNPC(num191, (float)num192, -num188, false, false, false, this);
									if (Main.netMode != 0)
									{
										NetMessage.SendData((int)PacketTypes.NpcStrike, -1, -1, "", i11, (float)num191, (float)num192, (float)(-num188), 0, 0, 0);
									}
								}
								if (this.resistCold && Main.npc[i11].coldDamage)
								{
									num189 = (int)((float)num189 * 0.7f);
								}
								if (!this.immune)
								{
									this.StatusPlayer(Main.npc[i11]);
								}
								this.Hurt(num189, num188, false, false, Lang.deathMsg(-1, i11, -1, -1), false);
							}
						}
					}
				}
				touchDamageHot = (!this.mount.Active || !this.mount.Cart ? Collision.HurtTiles(this.position, this.velocity, this.width, this.height, this.fireWalk) : Collision.HurtTiles(this.position, this.velocity, this.width, this.height - 16, this.fireWalk));
				if (touchDamageHot.Y == 0f && !this.fireWalk)
				{
					foreach (Point touchedTile in this.TouchedTiles)
					{
						Tile tile4 = Main.tile[touchedTile.X, touchedTile.Y];
						if (tile4 == null || !tile4.active() || !tile4.nactive() || this.fireWalk || TileID.Sets.TouchDamageHot[tile4.type] == 0)
						{
							continue;
						}
						touchDamageHot.Y = (float)TileID.Sets.TouchDamageHot[tile4.type];
						touchDamageHot.X = (float)((base.Center.X / 16f < (float)touchedTile.X + 0.5f ? -1 : 1));
						break;
					}
				}
				if (touchDamageHot.Y == 20f)
				{
					this.AddBuff(BuffID.Burning, 20, true);
				}
				else if (touchDamageHot.Y == 15f)
				{
					if (this.suffocateDelay >= 5)
					{
						this.AddBuff(BuffID.Suffocation, 1, true);
					}
					else
					{
						Player player115 = this;
						player115.suffocateDelay = (byte)(player115.suffocateDelay + 1);
					}
				}
				else if (touchDamageHot.Y == 0f)
				{
					this.suffocateDelay = 0;
				}
				else
				{
					int num193 = Main.DamageVar(touchDamageHot.Y);
					this.Hurt(num193, 0, false, false, Lang.deathMsg(-1, -1, -1, 3), false);
				}
			}
			if (!this.controlRight)
			{
				this.releaseRight = true;
				this.rightTimer = 7;
			}
			else
			{
				this.releaseRight = false;
			}
			if (!this.controlLeft)
			{
				this.releaseLeft = true;
				this.leftTimer = 7;
			}
			else
			{
				this.releaseLeft = false;
			}
			this.releaseDown = !this.controlDown;
			if (this.rightTimer > 0)
			{
				Player player116 = this;
				player116.rightTimer = player116.rightTimer - 1;
			}
			else if (this.controlRight)
			{
				this.rightTimer = 7;
			}
			if (this.leftTimer > 0)
			{
				Player player117 = this;
				player117.leftTimer = player117.leftTimer - 1;
			}
			else if (this.controlLeft)
			{
				this.leftTimer = 7;
			}
			this.GrappleMovement();
			this.StickyMovement();
			this.CheckDrowning();
			if (this.gravDir == -1f)
			{
				this.waterWalk = false;
				this.waterWalk2 = false;
			}
			int num194 = this.height;
			if (this.waterWalk)
			{
				num194 = num194 - 6;
			}
			bool flag36 = Collision.LavaCollision(this.position, this.width, num194);
			if (!flag36)
			{
				this.lavaWet = false;
				if (this.lavaTime < this.lavaMax)
				{
					Player player118 = this;
					player118.lavaTime = player118.lavaTime + 1;
				}
			}
			else
			{
				if (!this.lavaImmune && Main.myPlayer == i && !this.immune)
				{
					if (this.lavaTime > 0)
					{
						Player player119 = this;
						player119.lavaTime = player119.lavaTime - 1;
					}
					else if (!this.lavaRose)
					{
						this.Hurt(80, 0, false, false, Lang.deathMsg(-1, -1, -1, 2), false);
						this.AddBuff(BuffID.OnFire, 420, true);
					}
					else
					{
						this.Hurt(50, 0, false, false, Lang.deathMsg(-1, -1, -1, 2), false);
						this.AddBuff(BuffID.OnFire, 210, true);
					}
				}
				this.lavaWet = true;
			}
			if (this.lavaTime > this.lavaMax)
			{
				this.lavaTime = this.lavaMax;
			}
			if (this.waterWalk2 && !this.waterWalk)
			{
				num194 = num194 - 6;
			}
			bool flag37 = Collision.WetCollision(this.position, this.width, this.height);
			bool flag38 = Collision.honey;
			if (flag38)
			{
				this.AddBuff(BuffID.Honey, 1800, true);
				this.honeyWet = true;
			}
			if (flag37)
			{
				if (this.onFire && !this.lavaWet)
				{
					for (int j1 = 0; j1 < 22; j1++)
					{
						if (this.buffType[j1] == BuffID.OnFire)
						{
							this.DelBuff(j1);
						}
					}
				}
				if (!this.wet)
				{
					if (this.wetCount == 0)
					{
						this.wetCount = 10;
					}
					this.wet = true;
				}
			}
			else if (this.wet)
			{
				this.wet = false;
				if (this.jump > Player.jumpHeight / 5 && this.wetSlime == 0)
				{
					this.jump = Player.jumpHeight / 5;
				}
				if (this.wetCount == 0)
				{
					this.wetCount = 10;
				}
			}
			if (!flag38)
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
				Player player120 = this;
				player120.wetCount = (byte)(player120.wetCount - 1);
			}
			if (this.wetSlime > 0)
			{
				Player player121 = this;
				player121.wetSlime = (byte)(player121.wetSlime - 1);
			}
			if (this.wet && this.mount.Active)
			{
				type = this.mount.Type;
				switch (type)
				{
					case 3:
					{
						this.wetSlime = 30;
						if (this.velocity.Y > 2f)
						{
							this.velocity.Y = this.velocity.Y * 0.9f;
						}
						this.velocity.Y = this.velocity.Y - 0.5f;
						if (this.velocity.Y >= -4f)
						{
							break;
						}
						this.velocity.Y = -4f;
						break;
					}
					case 5:
					case 7:
					{
						if (this.whoAmI != Main.myPlayer)
						{
							break;
						}
						this.mount.Dismount(this);
						break;
					}
				}
			}
			if (Main.expertMode && this.ZoneSnow && this.wet && !this.lavaWet && !this.honeyWet && !this.arcticDivingGear)
			{
				this.AddBuff(BuffID.Chilled, 150, true);
			}
			float single38 = 1f + Math.Abs(this.velocity.X) / 3f;
			if (this.gfxOffY > 0f)
			{
				Player player122 = this;
				player122.gfxOffY = player122.gfxOffY - single38 * this.stepSpeed;
				if (this.gfxOffY < 0f)
				{
					this.gfxOffY = 0f;
				}
			}
			else if (this.gfxOffY < 0f)
			{
				Player player123 = this;
				player123.gfxOffY = player123.gfxOffY + single38 * this.stepSpeed;
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
			if (Main.myPlayer == i && !this.iceSkate)
			{
				this.CheckIceBreak();
			}
			this.SlopeDownMovement();
			bool flag39 = (this.mount.Type == 7 || this.mount.Type == 8 ? true : this.mount.Type == 12);
			if (this.velocity.Y == this.gravity && (!this.mount.Active || !this.mount.Cart && !flag39))
			{
				int num203 = this.width;
				int num204 = this.height;
				int num205 = (int)this.gravDir;
				flag = (this.waterWalk ? true : this.waterWalk2);
				Collision.StepDown(ref this.position, ref this.velocity, num203, num204, ref this.stepSpeed, ref this.gfxOffY, num205, flag);
			}
			if (this.gravDir == -1f)
			{
				if ((this.carpetFrame != -1 || this.velocity.Y <= this.gravity) && !this.controlUp)
				{
					Collision.StepUp(ref this.position, ref this.velocity, this.width, this.height, ref this.stepSpeed, ref this.gfxOffY, (int)this.gravDir, this.controlUp, 0);
				}
			}
			else if (flag39 || (this.carpetFrame != -1 || this.velocity.Y >= this.gravity) && !this.controlDown && !this.mount.Cart)
			{
				Collision.StepUp(ref this.position, ref this.velocity, this.width, this.height, ref this.stepSpeed, ref this.gfxOffY, (int)this.gravDir, this.controlUp, 0);
			}
			this.oldPosition = this.position;
			this.oldDirection = this.direction;
			bool flag40 = false;
			if (this.velocity.Y > this.gravity)
			{
				flag40 = true;
			}
			if (this.velocity.Y < -this.gravity)
			{
				flag40 = true;
			}
			Vector2 vector240 = this.velocity;
			this.slideDir = 0;
			bool flag41 = false;
			bool flag42 = this.controlDown;
			if (this.gravDir == -1f || this.mount.Active && this.mount.Cart || this.GoingDownWithGrapple)
			{
				flag41 = true;
				flag42 = true;
			}
			this.onTrack = false;
			bool flag43 = false;
			if (this.mount.Active && this.mount.Cart)
			{
				if (this.ignoreWater || this.merman)
				{
					single = 1f;
				}
				else if (!this.honeyWet)
				{
					single = (!this.wet ? 1f : 0.5f);
				}
				else
				{
					single = 0.25f;
				}
				Player player124 = this;
				player124.velocity = player124.velocity * single;
				DelegateMethods.Minecart.rotation = this.fullRotation;
				DelegateMethods.Minecart.rotationOrigin = this.fullRotationOrigin;
				
			}
			bool flag44 = (this.whoAmI != Main.myPlayer ? false : !this.mount.Active);
			Vector2 vector241 = this.position;
			if (this.vortexDebuff)
			{
				this.velocity.Y = this.velocity.Y * 0.8f + (float)Math.Cos((double)(base.Center.X % 120f / 120f * 6.28318548f)) * 5f * 0.2f;
			}
			if (this.wingsLogic == 3 && this.controlUp && this.controlDown)
			{
				Player player128 = this;
				player128.position = player128.position + this.velocity;
			}
			else if (this.tongued)
			{
				Player player129 = this;
				player129.position = player129.position + this.velocity;
				flag44 = false;
			}
			else if (this.honeyWet && !this.ignoreWater)
			{
				this.HoneyCollision(flag42, flag41);
			}
			else if (!this.wet || this.merman || this.ignoreWater)
			{
				this.DryCollision(flag42, flag41);
				if (this.mount.Active && this.mount.Type == 3 && this.velocity.Y != 0f && !this.SlimeDontHyperJump)
				{
					Vector2 vector242 = this.velocity;
					this.velocity.X = 0f;
					this.DryCollision(flag42, flag41);
					this.velocity.X = vector242.X;
				}
			}
			else
			{
				this.WaterCollision(flag42, flag41);
			}
			this.UpdateTouchingTiles();
			this.TryBouncingBlocks(flag40);
			this.TryLandingOnDetonator();
			if (this.wingsLogic != 3 || !this.controlUp || !this.controlDown)
			{
				this.SlopingCollision(flag42);
			}
			if (flag44 && this.velocity.Y == 0f)
			{
				AchievementsHelper.HandleRunning(Math.Abs(this.position.X - vector241.X));
			}
			if (flag43)
			{
				NetMessage.SendData((int)PacketTypes.PlayerUpdate, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
				Minecart.HitTrackSwitch(new Vector2(this.position.X, this.position.Y), this.width, this.height);
			}
			if (vector240.X != this.velocity.X)
			{
				if (vector240.X < 0f)
				{
					this.slideDir = -1;
				}
				else if (vector240.X > 0f)
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
				this.FloorVisuals(flag40);
			}
			Collision.SwitchTiles(this, this.position, this.width, this.height, this.oldPosition, 1);
			this.BordersMovement();
			this.numMinions = 0;
			this.slotsMinions = 0f;
			if (this.altFunctionUse == 0 && this.selectedItem != 58 && this.controlUseTile && this.releaseUseItem && !this.controlUseItem && !this.mouseInterface && this.inventory[this.selectedItem].type == 3384)
			{
				this.altFunctionUse = 1;
				this.controlUseItem = true;
			}
			if (!this.controlUseItem && this.altFunctionUse == 1)
			{
				this.altFunctionUse = 0;
			}
			if (!Main.ignoreErrors)
			{
				this.ItemCheck(i);
			}
			else
			{
				try
				{
					this.ItemCheck(i);
				}
				catch (Exception ex)
				{
#if DEBUG
					Console.WriteLine(ex);
					System.Diagnostics.Debugger.Break();

#endif
				}
			}
			this.PlayerFrame();
			if (this.mount.Type == 8)
			{
				this.mount.UseDrill(this);
			}
			if (this.statLife > this.statLifeMax2)
			{
				this.statLife = this.statLifeMax2;
			}
			if (this.statMana > this.statManaMax2)
			{
				this.statMana = this.statManaMax2;
			}
			this.grappling[0] = -1;
			this.grapCount = 0;
		}

		public void UpdateArmorSets(int i)
		{
			this.setBonus = "";
			if (this.body == 67 && this.legs == 56 && this.head >= 103 && this.head <= 105)
			{
				this.setBonus = Lang.setBonus(31, false);
				this.shroomiteStealth = true;
			}
			if (this.head == 52 && this.body == 32 && this.legs == 31 || this.head == 53 && this.body == 33 && this.legs == 32 || this.head == 54 && this.body == 34 && this.legs == 33 || this.head == 55 && this.body == 35 && this.legs == 34 || this.head == 70 && this.body == 46 && this.legs == 42 || this.head == 71 && this.body == 47 && this.legs == 43 || this.head == 166 && this.body == 173 && this.legs == 108 || this.head == 167 && this.body == 174 && this.legs == 109)
			{
				this.setBonus = Lang.setBonus(20, false);
				Player player = this;
				player.statDefense = player.statDefense + 1;
			}
			if (this.head == 1 && this.body == 1 && this.legs == 1 || (this.head == 72 || this.head == 2) && this.body == 2 && this.legs == 2 || this.head == 47 && this.body == 28 && this.legs == 27)
			{
				this.setBonus = Lang.setBonus(0, false);
				Player player1 = this;
				player1.statDefense = player1.statDefense + 2;
			}
			if (this.head == 3 && this.body == 3 && this.legs == 3 || (this.head == 73 || this.head == 4) && this.body == 4 && this.legs == 4 || this.head == 48 && this.body == 29 && this.legs == 28 || this.head == 49 && this.body == 30 && this.legs == 29)
			{
				this.setBonus = Lang.setBonus(1, false);
				Player player2 = this;
				player2.statDefense = player2.statDefense + 3;
			}
			if (this.head == 188 && this.body == 189 && this.legs == 129)
			{
				this.setBonus = Lang.setBonus(42, false);
				this.thrownCost50 = true;
			}
			if (this.head == 50 && this.body == 31 && this.legs == 30)
			{
				this.setBonus = Lang.setBonus(32, false);
				Player player3 = this;
				player3.statDefense = player3.statDefense + 4;
			}
			if (this.head == 112 && this.body == 75 && this.legs == 64)
			{
				this.setBonus = Lang.setBonus(33, false);
				Player player4 = this;
				player4.meleeDamage = player4.meleeDamage + 0.1f;
				Player player5 = this;
				player5.magicDamage = player5.magicDamage + 0.1f;
				Player player6 = this;
				player6.rangedDamage = player6.rangedDamage + 0.1f;
				Player player7 = this;
				player7.thrownDamage = player7.thrownDamage + 0.1f;
			}
			if (this.head == 22 && this.body == 14 && this.legs == 14)
			{
				this.thrownCost33 = true;
				this.setBonus = Lang.setBonus(41, false);
			}
			if (this.head == 157 && this.body == 105 && this.legs == 98)
			{
				int num = 0;
				this.setBonus = Lang.setBonus(38, false);
				this.beetleOffense = true;
				Player player8 = this;
				player8.beetleCounter = player8.beetleCounter - 3f;
				Player player9 = this;
				player9.beetleCounter = player9.beetleCounter - (float)(this.beetleCountdown / 10);
				Player player10 = this;
				player10.beetleCountdown = player10.beetleCountdown + 1;
				if (this.beetleCounter < 0f)
				{
					this.beetleCounter = 0f;
				}
				int num1 = 400;
				int num2 = 1200;
				int num3 = 4600;
				if (this.beetleCounter > (float)(num1 + num2 + num3 + num2))
				{
					this.beetleCounter = (float)(num1 + num2 + num3 + num2);
				}
				if (this.beetleCounter > (float)(num1 + num2 + num3))
				{
					this.AddBuff(BuffID.BeetleMight3, 5, false);
					num = 3;
				}
				else if (this.beetleCounter > (float)(num1 + num2))
				{
					this.AddBuff(BuffID.BeetleMight2, 5, false);
					num = 2;
				}
				else if (this.beetleCounter > (float)num1)
				{
					this.AddBuff(BuffID.BeetleMight1, 5, false);
					num = 1;
				}
				if (num < this.beetleOrbs)
				{
					this.beetleCountdown = 0;
				}
				else if (num > this.beetleOrbs)
				{
					Player player11 = this;
					player11.beetleCounter = player11.beetleCounter + 200f;
				}
				if (num != this.beetleOrbs && this.beetleOrbs > 0)
				{
					for (int i1 = 0; i1 < 22; i1++)
					{
						if (this.buffType[i1] >= BuffID.BeetleMight1 && this.buffType[i1] <= BuffID.BeetleMight3 && this.buffType[i1] != BuffID.BeetleEndurance3 + num)
						{
							this.DelBuff(i1);
						}
					}
				}
			}
			else if (this.head == 157 && this.body == 106 && this.legs == 98)
			{
				this.setBonus = Lang.setBonus(37, false);
				this.beetleDefense = true;
				Player player12 = this;
				player12.beetleCounter = player12.beetleCounter + 1f;
				int num4 = 180;
				if (this.beetleCounter >= (float)num4)
				{
					if (this.beetleOrbs > 0 && this.beetleOrbs < 3)
					{
						for (int j = 0; j < 22; j++)
						{
							if (this.buffType[j] >= BuffID.BeetleEndurance1 && this.buffType[j] <= BuffID.BeetleEndurance2)
							{
								this.DelBuff(j);
							}
						}
					}
					if (this.beetleOrbs >= 3)
					{
						this.beetleCounter = (float)num4;
					}
					else
					{
						this.AddBuff(BuffID.BeetleEndurance1 + this.beetleOrbs, 5, false);
						this.beetleCounter = 0f;
					}
				}
			}
			if (this.beetleDefense || this.beetleOffense)
			{
				Player player13 = this;
				player13.beetleFrameCounter = player13.beetleFrameCounter + 1;
				if (this.beetleFrameCounter >= 1)
				{
					this.beetleFrameCounter = 0;
					Player player14 = this;
					player14.beetleFrame = player14.beetleFrame + 1;
					if (this.beetleFrame > 2)
					{
						this.beetleFrame = 0;
					}
				}
				for (int k = this.beetleOrbs; k < 3; k++)
				{
					this.beetlePos[k].X = 0f;
					this.beetlePos[k].Y = 0f;
				}
				for (int l = 0; l < this.beetleOrbs; l++)
				{
					this.beetlePos[l] = this.beetlePos[l] + this.beetleVel[l];
					this.beetleVel[l].X = this.beetleVel[l].X + (float)Main.rand.Next(-100, 101) * 0.005f;
					this.beetleVel[l].Y = this.beetleVel[l].Y + (float)Main.rand.Next(-100, 101) * 0.005f;
					float x = this.beetlePos[l].X;
					float y = this.beetlePos[l].Y;
					float single = (float)Math.Sqrt((double)(x * x + y * y));
					if (single > 100f)
					{
						single = 20f / single;
						x = x * -single;
						y = y * -single;
						int num5 = 10;
						this.beetleVel[l].X = (this.beetleVel[l].X * (float)(num5 - 1) + x) / (float)num5;
						this.beetleVel[l].Y = (this.beetleVel[l].Y * (float)(num5 - 1) + y) / (float)num5;
					}
					else if (single > 30f)
					{
						single = 10f / single;
						x = x * -single;
						y = y * -single;
						int num6 = 20;
						this.beetleVel[l].X = (this.beetleVel[l].X * (float)(num6 - 1) + x) / (float)num6;
						this.beetleVel[l].Y = (this.beetleVel[l].Y * (float)(num6 - 1) + y) / (float)num6;
					}
					x = this.beetleVel[l].X;
					y = this.beetleVel[l].Y;
					single = (float)Math.Sqrt((double)(x * x + y * y));
					if (single > 2f)
					{
						this.beetleVel[l] = this.beetleVel[l] * 0.9f;
					}
					this.beetlePos[l] = this.beetlePos[l] - (this.velocity * 0.25f);
				}
			}
			else
			{
				this.beetleCounter = 0f;
			}
			if (this.head == 14 && (this.body >= 58 && this.body <= 63 || this.body == 167))
			{
				this.setBonus = Lang.setBonus(28, false);
				Player player15 = this;
				player15.magicCrit = player15.magicCrit + 10;
			}
			if (this.head == 159 && (this.body >= 58 && this.body <= 63 || this.body == 167))
			{
				this.setBonus = Lang.setBonus(36, false);
				Player player16 = this;
				player16.statManaMax2 = player16.statManaMax2 + 60;
			}
			if ((this.head == 5 || this.head == 74) && (this.body == 5 || this.body == 48) && (this.legs == 5 || this.legs == 44))
			{
				this.setBonus = Lang.setBonus(2, false);
				Player player17 = this;
				player17.moveSpeed = player17.moveSpeed + 0.15f;
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
				this.frostArmor = true;
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
				Player player18 = this;
				player18.manaCost = player18.manaCost - 0.16f;
			}
			if (this.head == 9 && this.body == 9 && this.legs == 9)
			{
				this.setBonus = Lang.setBonus(6, false);
				Player player19 = this;
				player19.meleeDamage = player19.meleeDamage + 0.17f;
			}
			if (this.head == 11 && this.body == 20 && this.legs == 19)
			{
				this.setBonus = Lang.setBonus(7, false);
				Player player20 = this;
				player20.pickSpeed = player20.pickSpeed - 0.3f;
			}
			if ((this.head == 78 || this.head == 79 || this.head == 80) && this.body == 51 && this.legs == 47)
			{
				this.setBonus = Lang.setBonus(27, false);
				this.AddBuff(BuffID.LeafCrystal, 18000, true);
			}
			else if (this.crystalLeaf)
			{
				for (int m = 0; m < 22; m++)
				{
					if (this.buffType[m] == BuffID.LeafCrystal)
					{
						this.DelBuff(m);
					}
				}
			}
			if (this.head == 99 && this.body == 65 && this.legs == 54)
			{
				this.setBonus = Lang.setBonus(29, false);
				this.thorns = 1f;
				this.turtleThorns = true;
			}
			if (this.body == 17 && this.legs == 16)
			{
				if (this.head == 29)
				{
					this.setBonus = Lang.setBonus(8, false);
					Player player21 = this;
					player21.manaCost = player21.manaCost - 0.14f;
				}
				else if (this.head == 30)
				{
					this.setBonus = Lang.setBonus(9, false);
					Player player22 = this;
					player22.meleeSpeed = player22.meleeSpeed + 0.15f;
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
					Player player23 = this;
					player23.manaCost = player23.manaCost - 0.17f;
				}
				else if (this.head == 33)
				{
					this.setBonus = Lang.setBonus(12, false);
					Player player24 = this;
					player24.meleeCrit = player24.meleeCrit + 5;
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
					Player player25 = this;
					player25.manaCost = player25.manaCost - 0.19f;
				}
				else if (this.head == 36)
				{
					this.setBonus = Lang.setBonus(15, false);
					Player player26 = this;
					player26.meleeSpeed = player26.meleeSpeed + 0.18f;
					Player player27 = this;
					player27.moveSpeed = player27.moveSpeed + 0.18f;
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
					Player player28 = this;
					player28.manaCost = player28.manaCost - 0.2f;
				}
				else if (this.head == 43)
				{
					this.setBonus = Lang.setBonus(18, false);
					Player player29 = this;
					player29.meleeSpeed = player29.meleeSpeed + 0.19f;
					Player player30 = this;
					player30.moveSpeed = player30.moveSpeed + 0.19f;
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
				Player player31 = this;
				player31.maxMinions = player31.maxMinions + 1;
			}
			if (this.head == 134 && this.body == 95 && this.legs == 79)
			{
				this.setBonus = Lang.setBonus(34, false);
				Player player32 = this;
				player32.minionDamage = player32.minionDamage + 0.25f;
			}
			if (this.head == 160 && this.body == 168 && this.legs == 103)
			{
				this.setBonus = Lang.setBonus(39, false);
				Player player33 = this;
				player33.minionDamage = player33.minionDamage + 0.1f;
				if (this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 1121)
				{
					AchievementsHelper.HandleSpecialEvent(this, 3);
				}
			}
			if (this.head == 162 && this.body == 170 && this.legs == 105)
			{
				this.setBonus = Lang.setBonus(40, false);
				Player player34 = this;
				player34.minionDamage = player34.minionDamage + 0.12f;
			}
			if (this.head != 171 || this.body != 177 || this.legs != 112)
			{
				this.solarCounter = 0;
			}
			else
			{
				this.setSolar = true;
				this.setBonus = Lang.setBonus(43, false);
				Player player35 = this;
				player35.solarCounter = player35.solarCounter + 1;
				int num7 = 240;
				if (this.solarCounter >= num7)
				{
					if (this.solarShields > 0 && this.solarShields < 3)
					{
						for (int n = 0; n < 22; n++)
						{
							if (this.buffType[n] >= BuffID.SolarShield1 && this.buffType[n] <= BuffID.SolarShield2)
							{
								this.DelBuff(n);
							}
						}
					}
					if (this.solarShields >= 3)
					{
						this.solarCounter = num7;
					}
					else
					{
						this.AddBuff(BuffID.SolarShield1 + this.solarShields, 5, false);
						this.solarCounter = 0;
					}
				}
				for (int p = this.solarShields; p < 3; p++)
				{
					this.solarShieldPos[p] = Vector2.Zero;
				}
				for (int q = 0; q < this.solarShields; q++)
				{
					this.solarShieldPos[q] = this.solarShieldPos[q] + this.solarShieldVel[q];
					Vector2 rotationVector2 = ((float)this.miscCounter / 100f * 6.28318548f + (float)q * (6.28318548f / (float)this.solarShields)).ToRotationVector2() * 6f;
					rotationVector2.X = (float)(this.direction * 20);
					this.solarShieldVel[q] = (rotationVector2 - this.solarShieldPos[q]) * 0.2f;
				}
				if (this.dashDelay >= 0)
				{
					this.solarDashing = false;
					this.solarDashConsumedFlare = false;
				}
				if (this.solarShields > 0 || (!this.solarDashing ? false : this.dashDelay < 0))
				{
					this.dash = 3;
				}
			}
			if (this.head != 169 || this.body != 175 || this.legs != 110)
			{
				this.vortexStealthActive = false;
			}
			else
			{
				this.setVortex = true;
				this.setBonus = Lang.setBonus(44, false);
			}
			if (this.head == 170 && this.body == 176 && this.legs == 111)
			{
				if (this.nebulaCD > 0)
				{
					Player player36 = this;
					player36.nebulaCD = player36.nebulaCD - 1;
				}
				this.setNebula = true;
				this.setBonus = Lang.setBonus(45, false);
			}
			if (this.head == 189 && this.body == 190 && this.legs == 130)
			{
				this.setBonus = Lang.setBonus(46, false);
				this.setStardust = true;
				if (this.whoAmI == Main.myPlayer)
				{
					if (this.HasBuff(BuffID.StardustGuardianMinion) == -1)
					{
						this.AddBuff(BuffID.StardustGuardianMinion, 3600, true);
					}
					if (this.ownedProjectileCounts[ProjectileID.StardustGuardian] < 1)
					{
						Projectile.NewProjectile(base.Center.X, base.Center.Y, 0f, -1f, 623, 0, 0f, Main.myPlayer, 0f, 0f);
						return;
					}
				}
			}
			else if (this.HasBuff(BuffID.StardustGuardianMinion) != -1)
			{
				this.DelBuff(this.HasBuff(BuffID.StardustGuardianMinion));
			}
		}

		public void UpdateBiomes()
		{
			this.ZoneDungeon = false;
			if (Main.dungeonTiles >= 250 && (double)this.position.Y > Main.worldSurface * 16)
			{
				int x = (int)this.position.X / 16;
				int y = (int)this.position.Y / 16;
				if (Main.wallDungeon[Main.tile[x, y].wall])
				{
					this.ZoneDungeon = true;
				}
			}
			if (Main.sandTiles <= 1000 || this.position.Y <= 3200f)
			{
				this.ZoneUndergroundDesert = false;
			}
			else
			{
				Point tileCoordinates = base.Center.ToTileCoordinates();
				Tile tileSafely = Framing.GetTileSafely(tileCoordinates.X, tileCoordinates.Y);
				if (WallID.Sets.Conversion.Sandstone[tileSafely.wall] || WallID.Sets.Conversion.HardenedSand[tileSafely.wall])
				{
					this.ZoneUndergroundDesert = true;
				}
			}
			this.ZoneCorrupt = Main.evilTiles >= 200;
			this.ZoneHoly = Main.holyTiles >= 100;
			this.ZoneMeteor = Main.meteorTiles >= 50;
			this.ZoneJungle = Main.jungleTiles >= 80;
			this.ZoneSnow = Main.snowTiles >= 300;
			this.ZoneCrimson = Main.bloodTiles >= 200;
			this.ZoneWaterCandle = Main.waterCandles > 0;
			this.ZonePeaceCandle = Main.peaceCandles > 0;
			this.ZoneDesert = Main.sandTiles > 1000;
			this.ZoneGlowshroom = Main.shroomTiles > 100;
			bool flag = false;
			this.ZoneTowerStardust = false;
			bool flag1 = flag;
			bool flag2 = flag1;
			this.ZoneTowerNebula = flag1;
			bool flag3 = flag2;
			bool flag4 = flag3;
			this.ZoneTowerVortex = flag3;
			this.ZoneTowerSolar = flag4;
			Vector2 zero = Vector2.Zero;
			Vector2 center = Vector2.Zero;
			Vector2 vector2 = Vector2.Zero;
			Vector2 zero1 = Vector2.Zero;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active)
				{
					if (Main.npc[i].type == NPCID.LunarTowerStardust)
					{
						if (base.Distance(Main.npc[i].Center) <= 4000f)
						{
							this.ZoneTowerStardust = true;
							zero1 = Main.npc[i].Center;
						}
					}
					else if (Main.npc[i].type == NPCID.LunarTowerNebula)
					{
						if (base.Distance(Main.npc[i].Center) <= 4000f)
						{
							this.ZoneTowerNebula = true;
							vector2 = Main.npc[i].Center;
						}
					}
					else if (Main.npc[i].type == NPCID.LunarTowerVortex)
					{
						if (base.Distance(Main.npc[i].Center) <= 4000f)
						{
							this.ZoneTowerVortex = true;
							center = Main.npc[i].Center;
						}
					}
					else if (Main.npc[i].type == NPCID.LunarTowerSolar && base.Distance(Main.npc[i].Center) <= 4000f)
					{
						this.ZoneTowerSolar = true;
						zero = Main.npc[i].Center;
					}
				}
			}
			this.ManageSpecialBiomeVisuals("Stardust", this.ZoneTowerStardust, zero1 - new Vector2(0f, 10f));
			this.ManageSpecialBiomeVisuals("Nebula", this.ZoneTowerNebula, vector2 - new Vector2(0f, 10f));
			this.ManageSpecialBiomeVisuals("Vortex", this.ZoneTowerVortex, center - new Vector2(0f, 10f));
			this.ManageSpecialBiomeVisuals("Solar", this.ZoneTowerSolar, zero - new Vector2(0f, 10f));
			this.ManageSpecialBiomeVisuals("MoonLord", NPC.AnyNPCs(NPCID.MoonLordCore), new Vector2());
			this.ManageSpecialBiomeVisuals("BloodMoon", Main.bloodMoon, new Vector2());
			Point point = base.Center.ToTileCoordinates();
			if (WorldGen.InWorld(point.X, point.Y, 1))
			{
				int num1 = 0;
				if (Main.tile[point.X, point.Y] != null)
				{
					num1 = Main.tile[point.X, point.Y].wall;
				}
				int num2 = num1;
				if (num2 == 62)
				{
					AchievementsHelper.HandleSpecialEvent(this, 13);
				}
				else if (num2 == 86)
				{
					AchievementsHelper.HandleSpecialEvent(this, 12);
				}
			}
			if (this._funkytownCheckCD > 0)
			{
				this._funkytownCheckCD--;
			}
			if (this.position.Y / 16f > (float)(Main.maxTilesY - 200))
			{
				AchievementsHelper.HandleSpecialEvent(this, 14);
				return;
			}
			if (this._funkytownCheckCD == 0 && (double)(this.position.Y / 16f) < Main.worldSurface && Main.shroomTiles >= 200)
			{
				AchievementsHelper.HandleSpecialEvent(this, 15);
				return;
			}
			this._funkytownCheckCD = 100;
		}

		public void UpdateBuffs(int i)
		{
			if (this.soulDrain > 0 && this.whoAmI == Main.myPlayer)
			{
				this.AddBuff(BuffID.SoulDrain, 2, true);
			}
			for (int num = 0; num < 1000; num++)
			{
				if (Main.projectile[num].active && Main.projectile[num].owner == i)
				{
					this.ownedProjectileCounts[Main.projectile[num].type] = this.ownedProjectileCounts[Main.projectile[num].type] + 1;
				}
			}
			for (int j = 0; j < 22; j++)
			{
				if (this.buffType[j] > 0 && this.buffTime[j] > 0)
				{
					if (this.whoAmI == Main.myPlayer && this.buffType[j] != BuffID.Werewolf)
					{
						this.buffTime[j] = this.buffTime[j] - 1;
					}
					if (this.buffType[j] == BuffID.ObsidianSkin)
					{
						this.lavaImmune = true;
						this.fireWalk = true;
						this.buffImmune[BuffID.OnFire] = true;
					}
					else if (this.buffType[j] == BuffID.StarInBottle)
					{
						Player player = this;
						player.manaRegen = player.manaRegen + 2;
					}
					else if (this.buffType[j] == BuffID.Sharpened && this.inventory[this.selectedItem].melee)
					{
						this.armorPenetration = 4;
					}
					else if (this.buffType[j] == BuffID.Regeneration)
					{
						Player player1 = this;
						player1.lifeRegen = player1.lifeRegen + 4;
					}
					else if (this.buffType[j] == BuffID.Swiftness)
					{
						Player player2 = this;
						player2.moveSpeed = player2.moveSpeed + 0.25f;
					}
					else if (this.buffType[j] == BuffID.Gills)
					{
						this.gills = true;
					}
					else if (this.buffType[j] == BuffID.Ironskin)
					{
						Player player3 = this;
						player3.statDefense = player3.statDefense + 8;
					}
					else if (this.buffType[j] == BuffID.ManaRegeneration)
					{
						this.manaRegenBuff = true;
					}
					else if (this.buffType[j] == BuffID.MagicPower)
					{
						Player player4 = this;
						player4.magicDamage = player4.magicDamage + 0.2f;
					}
					else if (this.buffType[j] == BuffID.Featherfall)
					{
						this.slowFall = true;
					}
					else if (this.buffType[j] == BuffID.Spelunker)
					{
						this.findTreasure = true;
					}
					else if (this.buffType[j] == BuffID.Invisibility)
					{
						this.invis = true;
					}
					else if (this.buffType[j] == BuffID.NightOwl)
					{
						this.nightVision = true;
					}
					else if (this.buffType[j] == BuffID.Battle)
					{
						this.enemySpawns = true;
					}
					else if (this.buffType[j] == BuffID.Thorns)
					{
						if (this.thorns < 1f)
						{
							this.thorns = 0.333333343f;
						}
					}
					else if (this.buffType[j] == BuffID.WaterWalking)
					{
						this.waterWalk = true;
					}
					else if (this.buffType[j] == BuffID.Archery)
					{
						this.archery = true;
					}
					else if (this.buffType[j] == BuffID.Hunter)
					{
						this.detectCreature = true;
					}
					else if (this.buffType[j] == BuffID.Gravitation)
					{
						this.gravControl = true;
					}
					else if (this.buffType[j] == BuffID.Bleeding)
					{
						this.bleed = true;
					}
					else if (this.buffType[j] == BuffID.Confused)
					{
						this.confused = true;
					}
					else if (this.buffType[j] == BuffID.Slow)
					{
						this.slow = true;
					}
					else if (this.buffType[j] == BuffID.Silenced)
					{
						this.silence = true;
					}
					else if (this.buffType[j] == BuffID.Dazed)
					{
						this.dazed = true;
					}
					else if (this.buffType[j] == BuffID.Chilled)
					{
						this.chilled = true;
					}
					else if (this.buffType[j] == BuffID.Frozen)
					{
						this.frozen = true;
					}
					else if (this.buffType[j] == BuffID.Stoned)
					{
						this.stoned = true;
					}
					else if (this.buffType[j] == BuffID.Ichor)
					{
						this.ichor = true;
						Player player5 = this;
						player5.statDefense = player5.statDefense - 20;
					}
					else if (this.buffType[j] == BuffID.BrokenArmor)
					{
						this.brokenArmor = true;
					}
					else if (this.buffType[j] == BuffID.Honey)
					{
						this.honey = true;
					}
					else if (this.buffType[j] == BuffID.ShadowDodge)
					{
						this.shadowDodge = true;
					}
					else if (this.buffType[j] == BuffID.AmmoBox)
					{
						this.ammoBox = true;
					}
					else if (this.buffType[j] == BuffID.RapidHealing)
					{
						this.palladiumRegen = true;
					}
					else if (this.buffType[j] == BuffID.ChaosState)
					{
						this.chaosState = true;
					}
					else if (this.buffType[j] == BuffID.Panic)
					{
						Player player6 = this;
						player6.moveSpeed = player6.moveSpeed + 1f;
					}
					else if (this.buffType[j] == BuffID.Mining)
					{
						Player player7 = this;
						player7.pickSpeed = player7.pickSpeed - 0.25f;
					}
					else if (this.buffType[j] == BuffID.Heartreach)
					{
						this.lifeMagnet = true;
					}
					else if (this.buffType[j] == BuffID.Calm)
					{
						this.calmed = true;
					}
					else if (this.buffType[j] == BuffID.Fishing)
					{
						Player player8 = this;
						player8.fishingSkill = player8.fishingSkill + 15;
					}
					else if (this.buffType[j] == BuffID.Sonar)
					{
						this.sonarPotion = true;
					}
					else if (this.buffType[j] == BuffID.Crate)
					{
						this.cratePotion = true;
					}
					else if (this.buffType[j] == BuffID.Builder)
					{
						Player player9 = this;
						player9.tileSpeed = player9.tileSpeed + 0.25f;
						Player player10 = this;
						player10.wallSpeed = player10.wallSpeed + 0.25f;
						Player player11 = this;
						player11.blockRange = player11.blockRange + 1;
					}
					else if (this.buffType[j] == BuffID.Titan)
					{
						this.kbBuff = true;
					}
					else if (this.buffType[j] == BuffID.Flipper)
					{
						this.ignoreWater = true;
						this.accFlipper = true;
					}
					else if (this.buffType[j] == BuffID.Summoning)
					{
						Player player12 = this;
						player12.maxMinions = player12.maxMinions + 1;
					}
					else if (this.buffType[j] == BuffID.Bewitched)
					{
						Player player13 = this;
						player13.maxMinions = player13.maxMinions + 1;
					}
					else if (this.buffType[j] == BuffID.Dangersense)
					{
						this.dangerSense = true;
					}
					else if (this.buffType[j] == BuffID.AmmoReservation)
					{
						this.ammoPotion = true;
					}
					else if (this.buffType[j] == BuffID.Lifeforce)
					{
						this.lifeForce = true;
						Player player14 = this;
						player14.statLifeMax2 = player14.statLifeMax2 + this.statLifeMax / 5 / 20 * 20;
					}
					else if (this.buffType[j] == BuffID.Endurance)
					{
						Player player15 = this;
						player15.endurance = player15.endurance + 0.1f;
					}
					else if (this.buffType[j] == BuffID.Rage)
					{
						Player player16 = this;
						player16.meleeCrit = player16.meleeCrit + 10;
						Player player17 = this;
						player17.rangedCrit = player17.rangedCrit + 10;
						Player player18 = this;
						player18.magicCrit = player18.magicCrit + 10;
						Player player19 = this;
						player19.thrownCrit = player19.thrownCrit + 10;
					}
					else if (this.buffType[j] == BuffID.Inferno)
					{
						this.inferno = true;
						int num1 = 24;
						float single = 200f;
						bool flag = this.infernoCounter % 60 == 0;
						int num2 = 10;
						if (this.whoAmI == Main.myPlayer)
						{
							for (int k = 0; k < 200; k++)
							{
								NPC nPC = Main.npc[k];
								if (nPC.active && !nPC.friendly && nPC.damage > 0 && !nPC.dontTakeDamage && !nPC.buffImmune[num1] && Vector2.Distance(base.Center, nPC.Center) <= single)
								{
									if (nPC.HasBuff(num1) == -1)
									{
										nPC.AddBuff(num1, 120, false);
									}
									if (flag)
									{
										nPC.StrikeNPC(num2, 0f, 0, false, false, false, this);
										if (Main.netMode != 0)
										{
											NetMessage.SendData((int)PacketTypes.NpcStrike, -1, -1, "", k, (float)num2, 0f, 0f, 0, 0, 0);
										}
									}
								}
							}
							if (this.hostile)
							{
								for (int l = 0; l < 255; l++)
								{
									Player player20 = Main.player[l];
									if (player20 != this && player20.active && !player20.dead && player20.hostile && !player20.buffImmune[num1] && (player20.team != this.team || player20.team == 0) && Vector2.Distance(base.Center, player20.Center) <= single)
									{
										if (player20.HasBuff(num1) == -1)
										{
											player20.AddBuff(num1, 120, true);
										}
										if (flag)
										{
											player20.Hurt(num2, 0, true, false, "", false);
											if (Main.netMode != 0)
											{
												NetMessage.SendData((int)PacketTypes.PlayerDamage, -1, -1, Lang.deathMsg(this.whoAmI, -1, -1, -1), l, 0f, (float)num2, 1f, 0, 0, 0);
											}
										}
									}
								}
							}
						}
					}
					else if (this.buffType[j] == BuffID.Wrath)
					{
						Player player21 = this;
						player21.thrownDamage = player21.thrownDamage + 0.1f;
						Player player22 = this;
						player22.meleeDamage = player22.meleeDamage + 0.1f;
						Player player23 = this;
						player23.rangedDamage = player23.rangedDamage + 0.1f;
						Player player24 = this;
						player24.magicDamage = player24.magicDamage + 0.1f;
						Player player25 = this;
						player25.minionDamage = player25.minionDamage + 0.1f;
					}
					else if (this.buffType[j] == BuffID.Lovestruck)
					{
						this.loveStruck = true;
					}
					else if (this.buffType[j] == BuffID.Stinky)
					{
						this.stinky = true;
					}
					else if (this.buffType[j] == BuffID.Warmth)
					{
						this.resistCold = true;
					}
					else if (this.buffType[j] == BuffID.DryadsWard)
					{
						Player player26 = this;
						player26.lifeRegen = player26.lifeRegen + 6;
						Player player27 = this;
						player27.statDefense = player27.statDefense + 8;
						this.dryadWard = true;
						if (this.thorns < 1f)
						{
							Player player28 = this;
							player28.thorns = player28.thorns + 0.2f;
						}
					}
					else if (this.buffType[j] == BuffID.Electrified)
					{
						this.electrified = true;
					}
					else if (this.buffType[j] == BuffID.ManaSickness)
					{
						this.manaSick = true;
						this.manaSickReduction = Player.manaSickLessDmg * ((float)this.buffTime[j] / (float)Player.manaSickTime);
					}
					else if (this.buffType[j] >= BuffID.BeetleEndurance1 && this.buffType[j] <= BuffID.BeetleEndurance3)
					{
						this.buffTime[j] = 5;
						int num3 = (byte)(1 + this.buffType[j] - 95);
						if (this.beetleOrbs > 0 && this.beetleOrbs != num3)
						{
							if (this.beetleOrbs <= num3)
							{
								for (int m = 0; m < 22; m++)
								{
									if (this.buffType[m] >= BuffID.BeetleEndurance1 && this.buffType[m] <= BuffID.BeetleEndurance1 + num3 - 1)
									{
										this.DelBuff(m);
										m--;
									}
								}
							}
							else
							{
								this.DelBuff(j);
								j--;
							}
						}
						this.beetleOrbs = num3;
						if (this.beetleDefense)
						{
							this.beetleBuff = true;
						}
						else
						{
							this.beetleOrbs = 0;
							this.DelBuff(j);
							j--;
						}
					}
					else if (this.buffType[j] >= BuffID.SolarShield1 && this.buffType[j] <= BuffID.SolarShield3)
					{
						this.buffTime[j] = 5;
						int num4 = (byte)(1 + this.buffType[j] - 170);
						if (this.solarShields > 0 && this.solarShields != num4)
						{
							if (this.solarShields <= num4)
							{
								for (int n = 0; n < 22; n++)
								{
									if (this.buffType[n] >= BuffID.SolarShield1 && this.buffType[n] <= BuffID.SolarShield1 + num4 - 1)
									{
										this.DelBuff(n);
										n--;
									}
								}
							}
							else
							{
								this.DelBuff(j);
								j--;
							}
						}
						this.solarShields = num4;
						if (!this.setSolar)
						{
							this.solarShields = 0;
							this.DelBuff(j);
							j--;
						}
					}
					else if (this.buffType[j] >= BuffID.BeetleMight1 && this.buffType[j] <= BuffID.BeetleMight3)
					{
						int num5 = (byte)(1 + this.buffType[j] - 98);
						if (this.beetleOrbs > 0 && this.beetleOrbs != num5)
						{
							if (this.beetleOrbs <= num5)
							{
								for (int o = 0; o < 22; o++)
								{
									if (this.buffType[o] >= BuffID.BeetleMight1 && this.buffType[o] <= BuffID.BeetleMight1 + num5 - 1)
									{
										this.DelBuff(o);
										o--;
									}
								}
							}
							else
							{
								this.DelBuff(j);
								j--;
							}
						}
						this.beetleOrbs = num5;
						Player player29 = this;
						player29.meleeDamage = player29.meleeDamage + 0.1f * (float)this.beetleOrbs;
						Player player30 = this;
						player30.meleeSpeed = player30.meleeSpeed + 0.1f * (float)this.beetleOrbs;
						if (this.beetleOffense)
						{
							this.beetleBuff = true;
						}
						else
						{
							this.beetleOrbs = 0;
							this.DelBuff(j);
							j--;
						}
					}
					else if (this.buffType[j] >= BuffID.NebulaUpMana1 && this.buffType[j] <= BuffID.NebulaUpMana3)
					{
						int num6 = this.nebulaLevelMana;
						int num7 = (byte)(1 + this.buffType[j] - 176);
						if (num6 > 0 && num6 != num7)
						{
							if (num6 <= num7)
							{
								for (int p = 0; p < 22; p++)
								{
									if (this.buffType[p] >= BuffID.NebulaUpMana1 && this.buffType[p] <= BuffID.NebulaUpMana3 + num7 - 1)
									{
										this.DelBuff(p);
										p--;
									}
								}
							}
							else
							{
								this.DelBuff(j);
								j--;
							}
						}
						this.nebulaLevelMana = num7;
						if (this.buffTime[j] == 2 && this.nebulaLevelMana > 1)
						{
							Player player31 = this;
							player31.nebulaLevelMana = player31.nebulaLevelMana - 1;
							this.buffType[j] = this.buffType[j] - 1;
							this.buffTime[j] = 480;
						}
					}
					else if (this.buffType[j] >= BuffID.NebulaUpLife1 && this.buffType[j] <= BuffID.NebulaUpLife3)
					{
						int num8 = this.nebulaLevelLife;
						int num9 = (byte)(1 + this.buffType[j] - 173);
						if (num8 > 0 && num8 != num9)
						{
							if (num8 <= num9)
							{
								for (int q = 0; q < 22; q++)
								{
									if (this.buffType[q] >= BuffID.NebulaUpLife1 && this.buffType[q] <= BuffID.NebulaUpLife3 + num9 - 1)
									{
										this.DelBuff(q);
										q--;
									}
								}
							}
							else
							{
								this.DelBuff(j);
								j--;
							}
						}
						this.nebulaLevelLife = num9;
						if (this.buffTime[j] == 2 && this.nebulaLevelLife > 1)
						{
							Player player32 = this;
							player32.nebulaLevelLife = player32.nebulaLevelLife - 1;
							this.buffType[j] = this.buffType[j] - 1;
							this.buffTime[j] = 480;
						}
						Player player33 = this;
						player33.lifeRegen = player33.lifeRegen + 10 * this.nebulaLevelLife;
					}
					else if (this.buffType[j] >= BuffID.NebulaUpDmg1 && this.buffType[j] <= BuffID.NebulaUpDmg3)
					{
						int num10 = this.nebulaLevelDamage;
						int num11 = (byte)(1 + this.buffType[j] - 179);
						if (num10 > 0 && num10 != num11)
						{
							if (num10 <= num11)
							{
								for (int r = 0; r < 22; r++)
								{
									if (this.buffType[r] >= BuffID.NebulaUpDmg1 && this.buffType[r] <= BuffID.NebulaUpDmg3 + num11 - 1)
									{
										this.DelBuff(r);
										r--;
									}
								}
							}
							else
							{
								this.DelBuff(j);
								j--;
							}
						}
						this.nebulaLevelDamage = num11;
						if (this.buffTime[j] == 2 && this.nebulaLevelDamage > 1)
						{
							Player player34 = this;
							player34.nebulaLevelDamage = player34.nebulaLevelDamage - 1;
							this.buffType[j] = this.buffType[j] - 1;
							this.buffTime[j] = 480;
						}
						float single1 = 0.15f * (float)this.nebulaLevelDamage;
						Player player35 = this;
						player35.meleeDamage = player35.meleeDamage + single1;
						Player player36 = this;
						player36.rangedDamage = player36.rangedDamage + single1;
						Player player37 = this;
						player37.magicDamage = player37.magicDamage + single1;
						Player player38 = this;
						player38.minionDamage = player38.minionDamage + single1;
						Player player39 = this;
						player39.thrownDamage = player39.thrownDamage + single1;
					}
					else if (this.buffType[j] == BuffID.IceBarrier)
					{
						if ((double)this.statLife > (double)this.statLifeMax2 * 0.5)
						{
							this.DelBuff(j);
							j--;
						}
						else
						{
							this.iceBarrier = true;
							Player player40 = this;
							player40.endurance = player40.endurance + 0.25f;
							Player player41 = this;
							player41.iceBarrierFrameCounter = (byte)(player41.iceBarrierFrameCounter + 1);
							if (this.iceBarrierFrameCounter > 2)
							{
								this.iceBarrierFrameCounter = 0;
								Player player42 = this;
								player42.iceBarrierFrame = (byte)(player42.iceBarrierFrame + 1);
								if (this.iceBarrierFrame >= 12)
								{
									this.iceBarrierFrame = 0;
								}
							}
						}
					}
					else if (this.buffType[j] == BuffID.Pygmies)
					{
						for (int s = 191; s <= 194; s++)
						{
							if (this.ownedProjectileCounts[s] > 0)
							{
								this.pygmy = true;
							}
						}
						if (this.pygmy)
						{
							this.buffTime[j] = 18000;
						}
						else
						{
							this.DelBuff(j);
							j--;
						}
					}
					else if (this.buffType[j] == BuffID.Ravens)
					{
						if (this.ownedProjectileCounts[ProjectileID.Raven] > 0)
						{
							this.raven = true;
						}
						if (this.raven)
						{
							this.buffTime[j] = 18000;
						}
						else
						{
							this.DelBuff(j);
							j--;
						}
					}
					else if (this.buffType[j] == BuffID.BabySlime)
					{
						if (this.ownedProjectileCounts[ProjectileID.BabySlime] > 0)
						{
							this.slime = true;
						}
						if (this.slime)
						{
							this.buffTime[j] = 18000;
						}
						else
						{
							this.DelBuff(j);
							j--;
						}
					}
					else if (this.buffType[j] == BuffID.HornetMinion)
					{
						if (this.ownedProjectileCounts[ProjectileID.Hornet] > 0)
						{
							this.hornetMinion = true;
						}
						if (this.hornetMinion)
						{
							this.buffTime[j] = 18000;
						}
						else
						{
							this.DelBuff(j);
							j--;
						}
					}
					else if (this.buffType[j] == BuffID.ImpMinion)
					{
						if (this.ownedProjectileCounts[ProjectileID.FlyingImp] > 0)
						{
							this.impMinion = true;
						}
						if (this.impMinion)
						{
							this.buffTime[j] = 18000;
						}
						else
						{
							this.DelBuff(j);
							j--;
						}
					}
					else if (this.buffType[j] == BuffID.SpiderMinion)
					{
						if (this.ownedProjectileCounts[ProjectileID.VenomSpider] > 0 || this.ownedProjectileCounts[ProjectileID.JumperSpider] > 0 || this.ownedProjectileCounts[ProjectileID.DangerousSpider] > 0)
						{
							this.spiderMinion = true;
						}
						if (this.spiderMinion)
						{
							this.buffTime[j] = 18000;
						}
						else
						{
							this.DelBuff(j);
							j--;
						}
					}
					else if (this.buffType[j] == BuffID.TwinEyesMinion)
					{
						if (this.ownedProjectileCounts[ProjectileID.Retanimini] > 0 || this.ownedProjectileCounts[ProjectileID.Spazmamini] > 0)
						{
							this.twinsMinion = true;
						}
						if (this.twinsMinion)
						{
							this.buffTime[j] = 18000;
						}
						else
						{
							this.DelBuff(j);
							j--;
						}
					}
					else if (this.buffType[j] == BuffID.PirateMinion)
					{
						if (this.ownedProjectileCounts[ProjectileID.OneEyedPirate] > 0 || this.ownedProjectileCounts[ProjectileID.SoulscourgePirate] > 0 || this.ownedProjectileCounts[ProjectileID.PirateCaptain] > 0)
						{
							this.pirateMinion = true;
						}
						if (this.pirateMinion)
						{
							this.buffTime[j] = 18000;
						}
						else
						{
							this.DelBuff(j);
							j--;
						}
					}
					else if (this.buffType[j] == BuffID.SharknadoMinion)
					{
						if (this.ownedProjectileCounts[ProjectileID.Tempest] > 0)
						{
							this.sharknadoMinion = true;
						}
						if (this.sharknadoMinion)
						{
							this.buffTime[j] = 18000;
						}
						else
						{
							this.DelBuff(j);
							j--;
						}
					}
					else if (this.buffType[j] == BuffID.UFOMinion)
					{
						if (this.ownedProjectileCounts[ProjectileID.UFOMinion] > 0)
						{
							this.UFOMinion = true;
						}
						if (this.UFOMinion)
						{
							this.buffTime[j] = 18000;
						}
						else
						{
							this.DelBuff(j);
							j--;
						}
					}
					else if (this.buffType[j] == BuffID.StardustMinion)
					{
						if (this.ownedProjectileCounts[ProjectileID.StardustCellMinion] > 0)
						{
							this.stardustMinion = true;
						}
						if (this.stardustMinion)
						{
							this.buffTime[j] = 18000;
						}
						else
						{
							this.DelBuff(j);
							j--;
						}
					}
					else if (this.buffType[j] == BuffID.StardustGuardianMinion)
					{
						if (this.ownedProjectileCounts[ProjectileID.StardustGuardian] > 0)
						{
							this.stardustGuardian = true;
						}
						if (this.stardustGuardian)
						{
							this.buffTime[j] = 18000;
						}
						else
						{
							this.DelBuff(j);
							j--;
						}
					}
					else if (this.buffType[j] == BuffID.StardustDragonMinion)
					{
						if (this.ownedProjectileCounts[ProjectileID.StardustDragon1] > 0)
						{
							this.stardustDragon = true;
						}
						if (this.stardustDragon)
						{
							this.buffTime[j] = 18000;
						}
						else
						{
							this.DelBuff(j);
							j--;
						}
					}
					else if (this.buffType[j] == BuffID.DeadlySphere)
					{
						if (this.ownedProjectileCounts[ProjectileID.DeadlySphere] > 0)
						{
							this.DeadlySphereMinion = true;
						}
						if (this.DeadlySphereMinion)
						{
							this.buffTime[j] = 18000;
						}
						else
						{
							this.DelBuff(j);
							j--;
						}
					}
					else if (this.buffType[j] == BuffID.Rudolph)
					{
						this.mount.SetMount(0, this, false);
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == BuffID.BunnyMount)
					{
						this.mount.SetMount(1, this, false);
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == BuffID.PigronMount)
					{
						this.mount.SetMount(2, this, false);
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == BuffID.SlimeMount)
					{
						this.mount.SetMount(3, this, false);
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == BuffID.MinecartLeft)
					{
						this.mount.SetMount(6, this, true);
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == BuffID.MinecartRight)
					{
						this.mount.SetMount(6, this, false);
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == BuffID.MinecartLeftMech)
					{
						this.mount.SetMount(11, this, true);
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == BuffID.MinecartRightMech)
					{
						this.mount.SetMount(11, this, false);
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == BuffID.MinecartLeftWood)
					{
						this.mount.SetMount(13, this, true);
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == BuffID.MinecartRightWood)
					{
						this.mount.SetMount(13, this, false);
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == BuffID.TurtleMount)
					{
						this.ignoreWater = true;
						this.accFlipper = true;
						this.mount.SetMount(4, this, false);
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == BuffID.BeeMount)
					{
						this.mount.SetMount(5, this, false);
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == BuffID.CuteFishronMount)
					{
						this.ignoreWater = true;
						this.accFlipper = true;
						this.mount.SetMount(12, this, false);
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == BuffID.UFOMount)
					{
						this.mount.SetMount(7, this, false);
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == BuffID.DrillMount)
					{
						this.mount.SetMount(8, this, false);
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == BuffID.ScutlixMount)
					{
						this.mount.SetMount(9, this, false);
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == BuffID.UnicornMount)
					{
						this.mount.SetMount(10, this, false);
						this.buffTime[j] = 10;
					}
					else if (this.buffType[j] == BuffID.Horrified)
					{
						if (Main.wof < 0 || Main.npc[Main.wof].type != 113)
						{
							this.DelBuff(j);
							j--;
						}
						else
						{
							this.gross = true;
							this.buffTime[j] = 10;
						}
					}
					else if (this.buffType[j] == BuffID.TheTongue)
					{
						this.buffTime[j] = 10;
						this.tongued = true;
					}
					else if (this.buffType[j] == BuffID.Sunflower)
					{
						Player player43 = this;
						player43.moveSpeed = player43.moveSpeed + 0.1f;
						Player player44 = this;
						player44.moveSpeed = player44.moveSpeed * 1.1f;
						this.sunflower = true;
					}
					else if (this.buffType[j] == BuffID.ShadowOrb)
					{
						this.buffTime[j] = 18000;
						this.lightOrb = true;
						bool flag1 = true;
						if (this.ownedProjectileCounts[ProjectileID.ShadowOrb] > 0)
						{
							flag1 = false;
						}
						if (flag1)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 18, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.CrimsonHeart)
					{
						this.buffTime[j] = 18000;
						this.crimsonHeart = true;
						bool flag2 = true;
						if (this.ownedProjectileCounts[ProjectileID.CrimsonHeart] > 0)
						{
							flag2 = false;
						}
						if (flag2)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 500, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.SuspiciousTentacle)
					{
						this.buffTime[j] = 18000;
						this.suspiciouslookingTentacle = true;
						bool flag3 = true;
						if (this.ownedProjectileCounts[ProjectileID.SuspiciousTentacle] > 0)
						{
							flag3 = false;
						}
						if (flag3)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 650, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.FairyBlue || this.buffType[j] == BuffID.FairyRed || this.buffType[j] == BuffID.FairyGreen)
					{
						this.buffTime[j] = 18000;
						bool flag4 = true;
						int num12 = 72;
						if (this.buffType[j] == BuffID.FairyBlue)
						{
							this.blueFairy = true;
						}
						if (this.buffType[j] == BuffID.FairyRed)
						{
							num12 = 86;
							this.redFairy = true;
						}
						if (this.buffType[j] == BuffID.FairyGreen)
						{
							num12 = 87;
							this.greenFairy = true;
						}
						if (this.head == 45 && this.body == 26 && this.legs == 25)
						{
							num12 = 72;
						}
						if (this.ownedProjectileCounts[num12] > 0)
						{
							flag4 = false;
						}
						if (flag4)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, num12, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.PetBunny)
					{
						this.buffTime[j] = 18000;
						this.bunny = true;
						bool flag5 = true;
						if (this.ownedProjectileCounts[ProjectileID.Bunny] > 0)
						{
							flag5 = false;
						}
						if (flag5)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 111, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.Rabies)
					{
						this.rabid = true;
						if (Main.rand.Next(1200) == 0)
						{
							int num13 = Main.rand.Next(6);
							float single2 = (float)Main.rand.Next(60, 100) * 0.01f;
							if (num13 == 0)
							{
								this.AddBuff(BuffID.Darkness, (int)(60f * single2 * 3f), true);
							}
							else if (num13 == 1)
							{
								this.AddBuff(BuffID.Cursed, (int)(60f * single2 * 0.75f), true);
							}
							else if (num13 == 2)
							{
								this.AddBuff(BuffID.Confused, (int)(60f * single2 * 1.5f), true);
							}
							else if (num13 == 3)
							{
								this.AddBuff(BuffID.Slow, (int)(60f * single2 * 3.5f), true);
							}
							else if (num13 == 4)
							{
								this.AddBuff(BuffID.Weak, (int)(60f * single2 * 5f), true);
							}
							else if (num13 == 5)
							{
								this.AddBuff(BuffID.Silenced, (int)(60f * single2 * 1f), true);
							}
						}
						Player player45 = this;
						player45.meleeDamage = player45.meleeDamage + 0.2f;
						Player player46 = this;
						player46.magicDamage = player46.magicDamage + 0.2f;
						Player player47 = this;
						player47.rangedDamage = player47.rangedDamage + 0.2f;
						Player player48 = this;
						player48.thrownDamage = player48.thrownDamage + 0.2f;
						Player player49 = this;
						player49.minionDamage = player49.minionDamage + 0.2f;
					}
					else if (this.buffType[j] == BuffID.BabyPenguin)
					{
						this.buffTime[j] = 18000;
						this.penguin = true;
						bool flag6 = true;
						if (this.ownedProjectileCounts[ProjectileID.Penguin] > 0)
						{
							flag6 = false;
						}
						if (flag6)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 112, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.MagicLantern)
					{
						this.buffTime[j] = 18000;
						this.magicLantern = true;
						if (this.ownedProjectileCounts[ProjectileID.MagicLantern] == 0)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 492, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.Puppy)
					{
						this.buffTime[j] = 18000;
						this.puppy = true;
						bool flag7 = true;
						if (this.ownedProjectileCounts[ProjectileID.Puppy] > 0)
						{
							flag7 = false;
						}
						if (flag7)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 334, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.BabyGrinch)
					{
						this.buffTime[j] = 18000;
						this.grinch = true;
						bool flag8 = true;
						if (this.ownedProjectileCounts[ProjectileID.BabyGrinch] > 0)
						{
							flag8 = false;
						}
						if (flag8)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 353, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.BlackCat)
					{
						this.buffTime[j] = 18000;
						this.blackCat = true;
						bool flag9 = true;
						if (this.ownedProjectileCounts[ProjectileID.BlackCat] > 0)
						{
							flag9 = false;
						}
						if (flag9)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 319, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.BabyDinosaur)
					{
						this.buffTime[j] = 18000;
						this.dino = true;
						bool flag10 = true;
						if (this.ownedProjectileCounts[ProjectileID.BabyDino] > 0)
						{
							flag10 = false;
						}
						if (flag10)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 236, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.BabyFaceMonster)
					{
						this.buffTime[j] = 18000;
						this.babyFaceMonster = true;
						bool flag11 = true;
						if (this.ownedProjectileCounts[ProjectileID.BabyFaceMonster] > 0)
						{
							flag11 = false;
						}
						if (flag11)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 499, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.EyeballSpring)
					{
						this.buffTime[j] = 18000;
						this.eyeSpring = true;
						bool flag12 = true;
						if (this.ownedProjectileCounts[ProjectileID.EyeSpring] > 0)
						{
							flag12 = false;
						}
						if (flag12)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 268, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.BabySnowman)
					{
						this.buffTime[j] = 18000;
						this.snowman = true;
						bool flag13 = true;
						if (this.ownedProjectileCounts[ProjectileID.BabySnowman] > 0)
						{
							flag13 = false;
						}
						if (flag13)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 269, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.PetTurtle)
					{
						this.buffTime[j] = 18000;
						this.turtle = true;
						bool flag14 = true;
						if (this.ownedProjectileCounts[ProjectileID.Turtle] > 0)
						{
							flag14 = false;
						}
						if (flag14)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 127, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.BabyEater)
					{
						this.buffTime[j] = 18000;
						this.eater = true;
						bool flag15 = true;
						if (this.ownedProjectileCounts[ProjectileID.BabyEater] > 0)
						{
							flag15 = false;
						}
						if (flag15)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 175, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.BabySkeletronHead)
					{
						this.buffTime[j] = 18000;
						this.skeletron = true;
						bool flag16 = true;
						if (this.ownedProjectileCounts[ProjectileID.BabySkeletronHead] > 0)
						{
							flag16 = false;
						}
						if (flag16)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 197, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.BabyHornet)
					{
						this.buffTime[j] = 18000;
						this.hornet = true;
						bool flag17 = true;
						if (this.ownedProjectileCounts[ProjectileID.BabyHornet] > 0)
						{
							flag17 = false;
						}
						if (flag17)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 198, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.TikiSpirit)
					{
						this.buffTime[j] = 18000;
						this.tiki = true;
						bool flag18 = true;
						if (this.ownedProjectileCounts[ProjectileID.TikiSpirit] > 0)
						{
							flag18 = false;
						}
						if (flag18)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 199, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.PetLizard)
					{
						this.buffTime[j] = 18000;
						this.lizard = true;
						bool flag19 = true;
						if (this.ownedProjectileCounts[ProjectileID.PetLizard] > 0)
						{
							flag19 = false;
						}
						if (flag19)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 200, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.PetParrot)
					{
						this.buffTime[j] = 18000;
						this.parrot = true;
						bool flag20 = true;
						if (this.ownedProjectileCounts[ProjectileID.Parrot] > 0)
						{
							flag20 = false;
						}
						if (flag20)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 208, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.BabyTruffle)
					{
						this.buffTime[j] = 18000;
						this.truffle = true;
						bool flag21 = true;
						if (this.ownedProjectileCounts[ProjectileID.Truffle] > 0)
						{
							flag21 = false;
						}
						if (flag21)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 209, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.PetSapling)
					{
						this.buffTime[j] = 18000;
						this.sapling = true;
						bool flag22 = true;
						if (this.ownedProjectileCounts[ProjectileID.Sapling] > 0)
						{
							flag22 = false;
						}
						if (flag22)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 210, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.CursedSapling)
					{
						this.buffTime[j] = 18000;
						this.cSapling = true;
						bool flag23 = true;
						if (this.ownedProjectileCounts[ProjectileID.CursedSapling] > 0)
						{
							flag23 = false;
						}
						if (flag23)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 324, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.PetSpider)
					{
						this.buffTime[j] = 18000;
						this.spider = true;
						bool flag24 = true;
						if (this.ownedProjectileCounts[ProjectileID.Spider] > 0)
						{
							flag24 = false;
						}
						if (flag24)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 313, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.Squashling)
					{
						this.buffTime[j] = 18000;
						this.squashling = true;
						bool flag25 = true;
						if (this.ownedProjectileCounts[ProjectileID.Squashling] > 0)
						{
							flag25 = false;
						}
						if (flag25)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 314, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.Wisp)
					{
						this.buffTime[j] = 18000;
						this.wisp = true;
						bool flag26 = true;
						if (this.ownedProjectileCounts[ProjectileID.Wisp] > 0)
						{
							flag26 = false;
						}
						if (flag26)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 211, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.LeafCrystal)
					{
						this.buffTime[j] = 18000;
						this.crystalLeaf = true;
						bool flag27 = true;
						for (int t = 0; t < 1000; t++)
						{
							if (Main.projectile[t].active && Main.projectile[t].owner == this.whoAmI && Main.projectile[t].type == ProjectileID.CrystalLeaf)
							{
								if (!flag27)
								{
									Main.projectile[t].Kill();
								}
								flag27 = false;
							}
						}
						if (flag27)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 226, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == 127)
					{
						this.buffTime[j] = 18000;
						this.zephyrfish = true;
						bool flag28 = true;
						if (this.ownedProjectileCounts[ProjectileID.ZephyrFish] > 0)
						{
							flag28 = false;
						}
						if (flag28)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 380, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.MiniMinotaur)
					{
						this.buffTime[j] = 18000;
						this.miniMinotaur = true;
						bool flag29 = true;
						if (this.ownedProjectileCounts[ProjectileID.MiniMinotaur] > 0)
						{
							flag29 = false;
						}
						if (flag29)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 398, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[j] == BuffID.Venom)
					{
						this.venom = true;
					}
					else if (this.buffType[j] == BuffID.Poisoned)
					{
						this.poisoned = true;
					}
					else if (this.buffType[j] == BuffID.PotionSickness)
					{
						this.potionDelay = this.buffTime[j];
					}
					else if (this.buffType[j] == BuffID.Darkness)
					{
						this.blind = true;
					}
					else if (this.buffType[j] == BuffID.Blackout)
					{
						this.blackout = true;
					}
					else if (this.buffType[j] == BuffID.Cursed)
					{
						this.noItems = true;
					}
					else if (this.buffType[j] == BuffID.OnFire)
					{
						this.onFire = true;
					}
					else if (this.buffType[j] == BuffID.Wet)
					{
						this.dripping = true;
					}
					else if (this.buffType[j] == BuffID.Slimed)
					{
						this.drippingSlime = true;
					}
					else if (this.buffType[j] == BuffID.Burning)
					{
						this.burned = true;
					}
					else if (this.buffType[j] == BuffID.Suffocation)
					{
						this.suffocating = true;
					}
					else if (this.buffType[j] == BuffID.CursedInferno)
					{
						this.onFire2 = true;
					}
					else if (this.buffType[j] == BuffID.Frostburn)
					{
						this.onFrostBurn = true;
					}
					else if (this.buffType[j] == BuffID.Obstructed)
					{
						this.headcovered = true;
						this.bleed = true;
					}
					else if (this.buffType[j] == BuffID.VortexDebuff)
					{
						this.vortexDebuff = true;
					}
					else if (this.buffType[j] == BuffID.MoonLeech)
					{
						bool flag30 = false;
						int num14 = 0;
						while (num14 < 1000)
						{
							Projectile projectile = Main.projectile[num14];
							if (!projectile.active || projectile.type != ProjectileID.MoonLeech || projectile.ai[1] != (float)this.whoAmI)
							{
								num14++;
							}
							else
							{
								flag30 = true;
								break;
							}
						}
						if (!flag30)
						{
							this.DelBuff(j);
						}
						else
						{
							this.moonLeech = true;
						}
					}
					else if (this.buffType[j] == BuffID.Webbed)
					{
						this.webbed = true;
						if (this.velocity.Y == 0f)
						{
							this.velocity = Vector2.Zero;
						}
						else
						{
							this.velocity = new Vector2(0f, 1E-06f);
						}
						Player.jumpHeight = 0;
						this.gravity = 0f;
						this.moveSpeed = 0f;
						this.dash = 0;
						this.noKnockback = true;
						this.grappling[0] = -1;
						this.grapCount = 0;
						for (int u = 0; u < 1000; u++)
						{
							if (Main.projectile[u].active && Main.projectile[u].owner == this.whoAmI && Main.projectile[u].aiStyle == 7)
							{
								Main.projectile[u].Kill();
							}
						}
					}
					else if (this.buffType[j] == BuffID.PaladinsShield)
					{
						this.paladinBuff = true;
					}
					else if (this.buffType[j] == BuffID.Clairvoyance)
					{
						Player player50 = this;
						player50.magicCrit = player50.magicCrit + 2;
						Player player51 = this;
						player51.magicDamage = player51.magicDamage + 0.05f;
						Player player52 = this;
						player52.statManaMax2 = player52.statManaMax2 + 20;
						Player player53 = this;
						player53.manaCost = player53.manaCost - 0.02f;
					}
					else if (this.buffType[j] == BuffID.Werewolf)
					{
						if (Main.dayTime || !this.wolfAcc || this.merman)
						{
							this.DelBuff(j);
							j--;
						}
						else
						{
							Player player54 = this;
							player54.lifeRegen = player54.lifeRegen + 1;
							this.wereWolf = true;
							Player player55 = this;
							player55.meleeCrit = player55.meleeCrit + 2;
							Player player56 = this;
							player56.meleeDamage = player56.meleeDamage + 0.051f;
							Player player57 = this;
							player57.meleeSpeed = player57.meleeSpeed + 0.051f;
							Player player58 = this;
							player58.statDefense = player58.statDefense + 3;
							Player player59 = this;
							player59.moveSpeed = player59.moveSpeed + 0.05f;
						}
					}
					else if (this.buffType[j] == BuffID.Weak)
					{
						Player player60 = this;
						player60.meleeDamage = player60.meleeDamage - 0.051f;
						Player player61 = this;
						player61.meleeSpeed = player61.meleeSpeed - 0.051f;
						Player player62 = this;
						player62.statDefense = player62.statDefense - 4;
						Player player63 = this;
						player63.moveSpeed = player63.moveSpeed - 0.1f;
					}
					else if (this.buffType[j] == BuffID.Tipsy)
					{
						Player player64 = this;
						player64.statDefense = player64.statDefense - 4;
						Player player65 = this;
						player65.meleeCrit = player65.meleeCrit + 2;
						Player player66 = this;
						player66.meleeDamage = player66.meleeDamage + 0.1f;
						Player player67 = this;
						player67.meleeSpeed = player67.meleeSpeed + 0.1f;
					}
					else if (this.buffType[j] == BuffID.WellFed)
					{
						this.wellFed = true;
						Player player68 = this;
						player68.statDefense = player68.statDefense + 2;
						Player player69 = this;
						player69.meleeCrit = player69.meleeCrit + 2;
						Player player70 = this;
						player70.meleeDamage = player70.meleeDamage + 0.05f;
						Player player71 = this;
						player71.meleeSpeed = player71.meleeSpeed + 0.05f;
						Player player72 = this;
						player72.magicCrit = player72.magicCrit + 2;
						Player player73 = this;
						player73.magicDamage = player73.magicDamage + 0.05f;
						Player player74 = this;
						player74.rangedCrit = player74.rangedCrit + 2;
						Player player75 = this;
						player75.rangedDamage = player75.rangedDamage + 0.05f;
						Player player76 = this;
						player76.thrownCrit = player76.thrownCrit + 2;
						Player player77 = this;
						player77.thrownDamage = player77.thrownDamage + 0.05f;
						Player player78 = this;
						player78.minionDamage = player78.minionDamage + 0.05f;
						Player player79 = this;
						player79.minionKB = player79.minionKB + 0.5f;
						Player player80 = this;
						player80.moveSpeed = player80.moveSpeed + 0.2f;
					}
					else if (this.buffType[j] == BuffID.WeaponImbueVenom)
					{
						this.meleeEnchant = 1;
					}
					else if (this.buffType[j] == BuffID.WeaponImbueCursedFlames)
					{
						this.meleeEnchant = 2;
					}
					else if (this.buffType[j] == BuffID.WeaponImbueFire)
					{
						this.meleeEnchant = 3;
					}
					else if (this.buffType[j] == BuffID.WeaponImbueGold)
					{
						this.meleeEnchant = 4;
					}
					else if (this.buffType[j] == BuffID.WeaponImbueIchor)
					{
						this.meleeEnchant = 5;
					}
					else if (this.buffType[j] == BuffID.WeaponImbueNanites)
					{
						this.meleeEnchant = 6;
					}
					else if (this.buffType[j] == BuffID.WeaponImbueConfetti)
					{
						this.meleeEnchant = 7;
					}
					else if (this.buffType[j] == BuffID.WeaponImbuePoison)
					{
						this.meleeEnchant = 8;
					}
				}
			}
		}

		public void UpdateDead()
		{
			this._portalPhysicsTime = 0;
			this.MountFishronSpecialCounter = 0f;
			this.gem = -1;
			this.slippy = false;
			this.slippy2 = false;
			this.powerrun = false;
			this.wings = 0;
			this.wingsLogic = 0;
			int num = 0;
			sbyte num1 = (sbyte)num;
			this.shield = (sbyte)num;
			sbyte num2 = num1;
			sbyte num3 = num2;
			this.balloon = num2;
			sbyte num4 = num3;
			sbyte num5 = num4;
			this.waist = num4;
			sbyte num6 = num5;
			sbyte num7 = num6;
			this.shoe = num6;
			sbyte num8 = num7;
			sbyte num9 = num8;
			this.handon = num8;
			sbyte num10 = num9;
			sbyte num11 = num10;
			this.handoff = num10;
			sbyte num12 = num11;
			sbyte num13 = num12;
			this.front = num12;
			sbyte num14 = num13;
			sbyte num15 = num14;
			this.back = num14;
			sbyte num16 = num15;
			sbyte num17 = num16;
			this.neck = num16;
			this.face = num17;
			this.poisoned = false;
			this.venom = false;
			this.onFire = false;
			this.dripping = false;
			this.drippingSlime = false;
			this.burned = false;
			this.suffocating = false;
			this.onFire2 = false;
			this.onFrostBurn = false;
			this.blind = false;
			this.blackout = false;
			this.loveStruck = false;
			this.dryadWard = false;
			this.stinky = false;
			this.resistCold = false;
			this.electrified = false;
			this.moonLeech = false;
			this.headcovered = false;
			this.vortexDebuff = false;
			bool flag = false;
			this.setStardust = false;
			bool flag1 = flag;
			bool flag2 = flag1;
			this.setNebula = flag1;
			bool flag3 = flag2;
			bool flag4 = flag3;
			this.setVortex = flag3;
			this.setSolar = flag4;
			int num19 = 0;
			int num20 = num19;
			this.nebulaLevelMana = num19;
			int num21 = num20;
			int num22 = num21;
			this.nebulaLevelLife = num21;
			this.nebulaLevelDamage = num22;
			this.trapDebuffSource = false;
			this.yoraiz0rEye = 0;
			this.yoraiz0rDarkness = false;
			this.gravDir = 1f;
			for (int i = 0; i < 22; i++)
			{
				if (this.buffType[i] <= 0 || !Main.persistentBuff[this.buffType[i]])
				{
					this.buffTime[i] = 0;
					this.buffType[i] = 0;
				}
			}
			if (this.whoAmI == Main.myPlayer)
			{
				Main.npcChatText = "";
				Main.editSign = false;
			}
			this.grappling[0] = -1;
			this.grappling[1] = -1;
			this.grappling[2] = -1;
			this.sign = -1;
			this.talkNPC = -1;
			Main.npcChatCornerItem = 0;
			this.statLife = 0;
			this.channel = false;
			this.potionDelay = 0;
			this.chest = -1;
			this.changeItem = -1;
			this.itemAnimation = 0;
			Player player = this;
			player.immuneAlpha = player.immuneAlpha + 2;
			if (this.immuneAlpha > 255)
			{
				this.immuneAlpha = 255;
			}
			Player player1 = this;
			player1.headPosition = player1.headPosition + this.headVelocity;
			Player player2 = this;
			player2.bodyPosition = player2.bodyPosition + this.bodyVelocity;
			Player player3 = this;
			player3.legPosition = player3.legPosition + this.legVelocity;
			Player x = this;
			x.headRotation = x.headRotation + this.headVelocity.X * 0.1f;
			Player x1 = this;
			x1.bodyRotation = x1.bodyRotation + this.bodyVelocity.X * 0.1f;
			Player x2 = this;
			x2.legRotation = x2.legRotation + this.legVelocity.X * 0.1f;
			this.headVelocity.Y = this.headVelocity.Y + 0.1f;
			this.bodyVelocity.Y = this.bodyVelocity.Y + 0.1f;
			this.legVelocity.Y = this.legVelocity.Y + 0.1f;
			this.headVelocity.X = this.headVelocity.X * 0.99f;
			this.bodyVelocity.X = this.bodyVelocity.X * 0.99f;
			this.legVelocity.X = this.legVelocity.X * 0.99f;
			for (int j = 0; j < (int)this.npcTypeNoAggro.Length; j++)
			{
				this.npcTypeNoAggro[j] = false;
			}
			if (this.difficulty != 2)
			{
				Player player4 = this;
				player4.respawnTimer = player4.respawnTimer - 1;
				if (this.respawnTimer <= 0 && Main.myPlayer == this.whoAmI)
				{
					if (Main.mouseItem.type > 0)
					{
						Main.playerInventory = true;
					}
					this.Spawn();
				}
			}
			else
			{
				if (this.respawnTimer > 0)
				{
					Player player5 = this;
					player5.respawnTimer = player5.respawnTimer - 1;
					return;
				}
				if (this.whoAmI == Main.myPlayer || Main.netMode == 2)
				{
					this.ghost = true;
					return;
				}
			}
		}

		public void UpdateDyes(int plr)
		{
			this.cHead = 0;
			this.cBody = 0;
			this.cLegs = 0;
			this.cHandOn = 0;
			this.cHandOff = 0;
			this.cBack = 0;
			this.cFront = 0;
			this.cShoe = 0;
			this.cWaist = 0;
			this.cShield = 0;
			this.cNeck = 0;
			this.cFace = 0;
			this.cBalloon = 0;
			this.cWings = 0;
			this.cCarpet = 0;
			int num = 0;
			int num1 = num;
			this.cYorai = num;
			int num2 = num1;
			int num3 = num2;
			this.cLight = num2;
			int num4 = num3;
			int num5 = num4;
			this.cPet = num4;
			int num6 = num5;
			int num7 = num6;
			this.cMinecart = num6;
			int num8 = num7;
			int num9 = num8;
			this.cMount = num8;
			this.cGrapple = num9;
			if (this.dye[0] != null)
			{
				this.cHead = this.dye[0].dye;
			}
			if (this.dye[1] != null)
			{
				this.cBody = this.dye[1].dye;
			}
			if (this.dye[2] != null)
			{
				this.cLegs = this.dye[2].dye;
			}
			if (this.wearsRobe)
			{
				this.cLegs = this.cBody;
			}
			if (this.miscDyes[0] != null)
			{
				this.cPet = this.miscDyes[0].dye;
			}
			if (this.miscDyes[1] != null)
			{
				this.cLight = this.miscDyes[1].dye;
			}
			if (this.miscDyes[2] != null)
			{
				this.cMinecart = this.miscDyes[2].dye;
			}
			if (this.miscDyes[3] != null)
			{
				this.cMount = this.miscDyes[3].dye;
			}
			if (this.miscDyes[4] != null)
			{
				this.cGrapple = this.miscDyes[4].dye;
			}
			for (int i = 0; i < 20; i++)
			{
				int num10 = i % 10;
				if (this.dye[num10] != null && this.armor[i].type > 0 && this.armor[i].stack > 0 && (i / 10 >= 1 || !this.hideVisual[num10] || this.armor[i].wingSlot > 0 || this.armor[i].type == 934))
				{
					if (this.armor[i].handOnSlot > 0 && this.armor[i].handOnSlot < 19)
					{
						this.cHandOn = this.dye[num10].dye;
					}
					if (this.armor[i].handOffSlot > 0 && this.armor[i].handOffSlot < 12)
					{
						this.cHandOff = this.dye[num10].dye;
					}
					if (this.armor[i].backSlot > 0 && this.armor[i].backSlot < 10)
					{
						this.cBack = this.dye[num10].dye;
					}
					if (this.armor[i].frontSlot > 0 && this.armor[i].frontSlot < 5)
					{
						this.cFront = this.dye[num10].dye;
					}
					if (this.armor[i].shoeSlot > 0 && this.armor[i].shoeSlot < 18)
					{
						this.cShoe = this.dye[num10].dye;
					}
					if (this.armor[i].waistSlot > 0 && this.armor[i].waistSlot < 12)
					{
						this.cWaist = this.dye[num10].dye;
					}
					if (this.armor[i].shieldSlot > 0 && this.armor[i].shieldSlot < 6)
					{
						this.cShield = this.dye[num10].dye;
					}
					if (this.armor[i].neckSlot > 0 && this.armor[i].neckSlot < 9)
					{
						this.cNeck = this.dye[num10].dye;
					}
					if (this.armor[i].faceSlot > 0 && this.armor[i].faceSlot < 9)
					{
						this.cFace = this.dye[num10].dye;
					}
					if (this.armor[i].balloonSlot > 0 && this.armor[i].balloonSlot < 16)
					{
						this.cBalloon = this.dye[num10].dye;
					}
					if (this.armor[i].wingSlot > 0 && this.armor[i].wingSlot < 37)
					{
						this.cWings = this.dye[num10].dye;
					}
					if (this.armor[i].type == 934)
					{
						this.cCarpet = this.dye[num10].dye;
					}
				}
			}
			this.cYorai = this.cPet;
		}

		public void UpdateEquips(int i)
		{
			for (int num = 0; num < 58; num++)
			{
				int num1 = this.inventory[num].type;
				if ((num1 == 15 || num1 == 707) && this.accWatch < 1)
				{
					this.accWatch = 1;
				}
				if ((num1 == 16 || num1 == 708) && this.accWatch < 2)
				{
					this.accWatch = 2;
				}
				if ((num1 == 17 || num1 == 709) && this.accWatch < 3)
				{
					this.accWatch = 3;
				}
				if (num1 == 393)
				{
					this.accCompass = 1;
				}
				if (num1 == 18)
				{
					this.accDepthMeter = 1;
				}
				if (num1 == 395 || num1 == 3123 || num1 == 3124)
				{
					this.accWatch = 3;
					this.accDepthMeter = 1;
					this.accCompass = 1;
				}
				if (num1 == 3120 || num1 == 3036 || num1 == 3123 || num1 == 3124)
				{
					this.accFishFinder = true;
				}
				if (num1 == 3037 || num1 == 3036 || num1 == 3123 || num1 == 3124)
				{
					this.accWeatherRadio = true;
				}
				if (num1 == 3096 || num1 == 3036 || num1 == 3123 || num1 == 3124)
				{
					this.accCalendar = true;
				}
				if (num1 == 3084 || num1 == 3122 || num1 == 3123 || num1 == 3124)
				{
					this.accThirdEye = true;
				}
				if (num1 == 3095 || num1 == 3122 || num1 == 3123 || num1 == 3124)
				{
					this.accJarOfSouls = true;
				}
				if (num1 == 3118 || num1 == 3122 || num1 == 3123 || num1 == 3124)
				{
					this.accCritterGuide = true;
				}
				if (num1 == 3099 || num1 == 3121 || num1 == 3123 || num1 == 3124)
				{
					this.accStopwatch = true;
				}
				if (num1 == 3102 || num1 == 3121 || num1 == 3123 || num1 == 3124)
				{
					this.accOreFinder = true;
				}
				if (num1 == 3119 || num1 == 3121 || num1 == 3123 || num1 == 3124)
				{
					this.accDreamCatcher = true;
				}
			}
			for (int j = 0; j < 8 + this.extraAccessorySlots; j++)
			{
				if (!this.armor[j].expertOnly || Main.expertMode)
				{
					int num2 = this.armor[j].type;
					if ((num2 == 15 || num2 == 707) && this.accWatch < 1)
					{
						this.accWatch = 1;
					}
					if ((num2 == 16 || num2 == 708) && this.accWatch < 2)
					{
						this.accWatch = 2;
					}
					if ((num2 == 17 || num2 == 709) && this.accWatch < 3)
					{
						this.accWatch = 3;
					}
					if (num2 == 393)
					{
						this.accCompass = 1;
					}
					if (num2 == 18)
					{
						this.accDepthMeter = 1;
					}
					if (num2 == 395 || num2 == 3123 || num2 == 3124)
					{
						this.accWatch = 3;
						this.accDepthMeter = 1;
						this.accCompass = 1;
					}
					if (num2 == 3120 || num2 == 3036 || num2 == 3123 || num2 == 3124)
					{
						this.accFishFinder = true;
					}
					if (num2 == 3037 || num2 == 3036 || num2 == 3123 || num2 == 3124)
					{
						this.accWeatherRadio = true;
					}
					if (num2 == 3096 || num2 == 3036 || num2 == 3123 || num2 == 3124)
					{
						this.accCalendar = true;
					}
					if (num2 == 3084 || num2 == 3122 || num2 == 3123 || num2 == 3124)
					{
						this.accThirdEye = true;
					}
					if (num2 == 3095 || num2 == 3122 || num2 == 3123 || num2 == 3124)
					{
						this.accJarOfSouls = true;
					}
					if (num2 == 3118 || num2 == 3122 || num2 == 3123 || num2 == 3124)
					{
						this.accCritterGuide = true;
					}
					if (num2 == 3099 || num2 == 3121 || num2 == 3123 || num2 == 3124)
					{
						this.accStopwatch = true;
					}
					if (num2 == 3102 || num2 == 3121 || num2 == 3123 || num2 == 3124)
					{
						this.accOreFinder = true;
					}
					if (num2 == 3119 || num2 == 3121 || num2 == 3123 || num2 == 3124)
					{
						this.accDreamCatcher = true;
					}
					if (this.armor[j].type == 3017 && this.whoAmI == Main.myPlayer && this.velocity.Y == 0f && this.grappling[0] == -1)
					{
						int x = (int)base.Center.X / 16;
						int y = (int)(this.position.Y + (float)this.height - 1f) / 16;
						if (Main.tile[x, y] == null)
						{
							Main.tile[x, y] = new Tile();
						}
						if (!Main.tile[x, y].active() && Main.tile[x, y].liquid == 0 && Main.tile[x, y + 1] != null && WorldGen.SolidTile(x, y + 1))
						{
							Main.tile[x, y].frameY = 0;
							Main.tile[x, y].slope(0);
							Main.tile[x, y].halfBrick(false);
							if (Main.tile[x, y + 1].type == 2)
							{
								if (Main.rand.Next(2) != 0)
								{
									Main.tile[x, y].active(true);
									Main.tile[x, y].type = 73;
									Main.tile[x, y].frameX = (short)(18 * Main.rand.Next(6, 21));
									while (Main.tile[x, y].frameX == 144)
									{
										Main.tile[x, y].frameX = (short)(18 * Main.rand.Next(6, 21));
									}
								}
								else
								{
									Main.tile[x, y].active(true);
									Main.tile[x, y].type = 3;
									Main.tile[x, y].frameX = (short)(18 * Main.rand.Next(6, 11));
									while (Main.tile[x, y].frameX == 144)
									{
										Main.tile[x, y].frameX = (short)(18 * Main.rand.Next(6, 11));
									}
								}
								if (Main.netMode == 1)
								{
									NetMessage.SendTileSquare(-1, x, y, 1);
								}
							}
							else if (Main.tile[x, y + 1].type == 109)
							{
								if (Main.rand.Next(2) != 0)
								{
									Main.tile[x, y].active(true);
									Main.tile[x, y].type = 113;
									Main.tile[x, y].frameX = (short)(18 * Main.rand.Next(2, 8));
									while (Main.tile[x, y].frameX == 90)
									{
										Main.tile[x, y].frameX = (short)(18 * Main.rand.Next(2, 8));
									}
								}
								else
								{
									Main.tile[x, y].active(true);
									Main.tile[x, y].type = 110;
									Main.tile[x, y].frameX = (short)(18 * Main.rand.Next(4, 7));
									while (Main.tile[x, y].frameX == 90)
									{
										Main.tile[x, y].frameX = (short)(18 * Main.rand.Next(4, 7));
									}
								}
								if (Main.netMode == 1)
								{
									NetMessage.SendTileSquare(-1, x, y, 1);
								}
							}
							else if (Main.tile[x, y + 1].type == 60)
							{
								Main.tile[x, y].active(true);
								Main.tile[x, y].type = 74;
								Main.tile[x, y].frameX = (short)(18 * Main.rand.Next(9, 17));
								if (Main.netMode == 1)
								{
									NetMessage.SendTileSquare(-1, x, y, 1);
								}
							}
						}
					}
					Player player = this;
					player.statDefense = player.statDefense + this.armor[j].defense;
					Player player1 = this;
					player1.lifeRegen = player1.lifeRegen + this.armor[j].lifeRegen;
					if (this.armor[j].type == 268)
					{
						this.accDivingHelm = true;
					}
					if (this.armor[j].type == 238)
					{
						Player player2 = this;
						player2.magicDamage = player2.magicDamage + 0.15f;
					}
					if (this.armor[j].type == 3212)
					{
						Player player3 = this;
						player3.armorPenetration = player3.armorPenetration + 5;
					}
					if (this.armor[j].type == 2277)
					{
						Player player4 = this;
						player4.magicDamage = player4.magicDamage + 0.05f;
						Player player5 = this;
						player5.meleeDamage = player5.meleeDamage + 0.05f;
						Player player6 = this;
						player6.rangedDamage = player6.rangedDamage + 0.05f;
						Player player7 = this;
						player7.thrownDamage = player7.thrownDamage + 0.05f;
						Player player8 = this;
						player8.magicCrit = player8.magicCrit + 5;
						Player player9 = this;
						player9.rangedCrit = player9.rangedCrit + 5;
						Player player10 = this;
						player10.meleeCrit = player10.meleeCrit + 5;
						Player player11 = this;
						player11.thrownCrit = player11.thrownCrit + 5;
						Player player12 = this;
						player12.meleeSpeed = player12.meleeSpeed + 0.1f;
						Player player13 = this;
						player13.moveSpeed = player13.moveSpeed + 0.1f;
					}
					if (this.armor[j].type == 2279)
					{
						Player player14 = this;
						player14.magicDamage = player14.magicDamage + 0.06f;
						Player player15 = this;
						player15.magicCrit = player15.magicCrit + 6;
						Player player16 = this;
						player16.manaCost = player16.manaCost - 0.1f;
					}
					if (this.armor[j].type == 3109)
					{
						this.nightVision = true;
					}
					if (this.armor[j].type == 256)
					{
						Player player17 = this;
						player17.thrownVelocity = player17.thrownVelocity + 0.15f;
					}
					if (this.armor[j].type == 257)
					{
						Player player18 = this;
						player18.thrownDamage = player18.thrownDamage + 0.15f;
					}
					if (this.armor[j].type == 258)
					{
						Player player19 = this;
						player19.thrownCrit = player19.thrownCrit + 10;
					}
					if (this.armor[j].type == 3374)
					{
						Player player20 = this;
						player20.thrownVelocity = player20.thrownVelocity + 0.2f;
					}
					if (this.armor[j].type == 3375)
					{
						Player player21 = this;
						player21.thrownDamage = player21.thrownDamage + 0.2f;
					}
					if (this.armor[j].type == 3376)
					{
						Player player22 = this;
						player22.thrownCrit = player22.thrownCrit + 15;
					}
					if (this.armor[j].type == 2275)
					{
						Player player23 = this;
						player23.magicDamage = player23.magicDamage + 0.07f;
						Player player24 = this;
						player24.magicCrit = player24.magicCrit + 7;
					}
					if (this.armor[j].type == 123 || this.armor[j].type == 124 || this.armor[j].type == 125)
					{
						Player player25 = this;
						player25.magicDamage = player25.magicDamage + 0.07f;
					}
					if (this.armor[j].type == 151 || this.armor[j].type == 152 || this.armor[j].type == 153 || this.armor[j].type == 959)
					{
						Player player26 = this;
						player26.rangedDamage = player26.rangedDamage + 0.05f;
					}
					if (this.armor[j].type == 111 || this.armor[j].type == 228 || this.armor[j].type == 229 || this.armor[j].type == 230 || this.armor[j].type == 960 || this.armor[j].type == 961 || this.armor[j].type == 962)
					{
						Player player27 = this;
						player27.statManaMax2 = player27.statManaMax2 + 20;
					}
					if (this.armor[j].type == 228 || this.armor[j].type == 960)
					{
						Player player28 = this;
						player28.statManaMax2 = player28.statManaMax2 + 20;
					}
					if (this.armor[j].type == 228 || this.armor[j].type == 229 || this.armor[j].type == 230 || this.armor[j].type == 960 || this.armor[j].type == 961 || this.armor[j].type == 962)
					{
						Player player29 = this;
						player29.magicCrit = player29.magicCrit + 4;
					}
					if (this.armor[j].type == 100 || this.armor[j].type == 101 || this.armor[j].type == 102)
					{
						Player player30 = this;
						player30.meleeSpeed = player30.meleeSpeed + 0.07f;
					}
					if (this.armor[j].type == 956 || this.armor[j].type == 957 || this.armor[j].type == 958)
					{
						Player player31 = this;
						player31.meleeSpeed = player31.meleeSpeed + 0.07f;
					}
					if (this.armor[j].type == 792 || this.armor[j].type == 793 || this.armor[j].type == 794)
					{
						Player player32 = this;
						player32.meleeDamage = player32.meleeDamage + 0.02f;
						Player player33 = this;
						player33.rangedDamage = player33.rangedDamage + 0.02f;
						Player player34 = this;
						player34.magicDamage = player34.magicDamage + 0.02f;
						Player player35 = this;
						player35.thrownDamage = player35.thrownDamage + 0.02f;
					}
					if (this.armor[j].type == 371)
					{
						Player player36 = this;
						player36.magicCrit = player36.magicCrit + 9;
						Player player37 = this;
						player37.statManaMax2 = player37.statManaMax2 + 40;
					}
					if (this.armor[j].type == 372)
					{
						Player player38 = this;
						player38.moveSpeed = player38.moveSpeed + 0.07f;
						Player player39 = this;
						player39.meleeSpeed = player39.meleeSpeed + 0.12f;
					}
					if (this.armor[j].type == 373)
					{
						Player player40 = this;
						player40.rangedDamage = player40.rangedDamage + 0.1f;
						Player player41 = this;
						player41.rangedCrit = player41.rangedCrit + 6;
					}
					if (this.armor[j].type == 374)
					{
						Player player42 = this;
						player42.magicCrit = player42.magicCrit + 3;
						Player player43 = this;
						player43.meleeCrit = player43.meleeCrit + 3;
						Player player44 = this;
						player44.rangedCrit = player44.rangedCrit + 3;
					}
					if (this.armor[j].type == 375)
					{
						Player player45 = this;
						player45.moveSpeed = player45.moveSpeed + 0.1f;
					}
					if (this.armor[j].type == 376)
					{
						Player player46 = this;
						player46.magicDamage = player46.magicDamage + 0.15f;
						Player player47 = this;
						player47.statManaMax2 = player47.statManaMax2 + 60;
					}
					if (this.armor[j].type == 377)
					{
						Player player48 = this;
						player48.meleeCrit = player48.meleeCrit + 5;
						Player player49 = this;
						player49.meleeDamage = player49.meleeDamage + 0.1f;
					}
					if (this.armor[j].type == 378)
					{
						Player player50 = this;
						player50.rangedDamage = player50.rangedDamage + 0.12f;
						Player player51 = this;
						player51.rangedCrit = player51.rangedCrit + 7;
					}
					if (this.armor[j].type == 379)
					{
						Player player52 = this;
						player52.rangedDamage = player52.rangedDamage + 0.05f;
						Player player53 = this;
						player53.meleeDamage = player53.meleeDamage + 0.05f;
						Player player54 = this;
						player54.magicDamage = player54.magicDamage + 0.05f;
					}
					if (this.armor[j].type == 380)
					{
						Player player55 = this;
						player55.magicCrit = player55.magicCrit + 3;
						Player player56 = this;
						player56.meleeCrit = player56.meleeCrit + 3;
						Player player57 = this;
						player57.rangedCrit = player57.rangedCrit + 3;
					}
					if (this.armor[j].type >= 2367 && this.armor[j].type <= 2369)
					{
						Player player58 = this;
						player58.fishingSkill = player58.fishingSkill + 5;
					}
					if (this.armor[j].type == 400)
					{
						Player player59 = this;
						player59.magicDamage = player59.magicDamage + 0.11f;
						Player player60 = this;
						player60.magicCrit = player60.magicCrit + 11;
						Player player61 = this;
						player61.statManaMax2 = player61.statManaMax2 + 80;
					}
					if (this.armor[j].type == 401)
					{
						Player player62 = this;
						player62.meleeCrit = player62.meleeCrit + 7;
						Player player63 = this;
						player63.meleeDamage = player63.meleeDamage + 0.14f;
					}
					if (this.armor[j].type == 402)
					{
						Player player64 = this;
						player64.rangedDamage = player64.rangedDamage + 0.14f;
						Player player65 = this;
						player65.rangedCrit = player65.rangedCrit + 8;
					}
					if (this.armor[j].type == 403)
					{
						Player player66 = this;
						player66.rangedDamage = player66.rangedDamage + 0.06f;
						Player player67 = this;
						player67.meleeDamage = player67.meleeDamage + 0.06f;
						Player player68 = this;
						player68.magicDamage = player68.magicDamage + 0.06f;
					}
					if (this.armor[j].type == 404)
					{
						Player player69 = this;
						player69.magicCrit = player69.magicCrit + 4;
						Player player70 = this;
						player70.meleeCrit = player70.meleeCrit + 4;
						Player player71 = this;
						player71.rangedCrit = player71.rangedCrit + 4;
						Player player72 = this;
						player72.moveSpeed = player72.moveSpeed + 0.05f;
					}
					if (this.armor[j].type == 1205)
					{
						Player player73 = this;
						player73.meleeDamage = player73.meleeDamage + 0.08f;
						Player player74 = this;
						player74.meleeSpeed = player74.meleeSpeed + 0.12f;
					}
					if (this.armor[j].type == 1206)
					{
						Player player75 = this;
						player75.rangedDamage = player75.rangedDamage + 0.09f;
						Player player76 = this;
						player76.rangedCrit = player76.rangedCrit + 9;
					}
					if (this.armor[j].type == 1207)
					{
						Player player77 = this;
						player77.magicDamage = player77.magicDamage + 0.07f;
						Player player78 = this;
						player78.magicCrit = player78.magicCrit + 7;
						Player player79 = this;
						player79.statManaMax2 = player79.statManaMax2 + 60;
					}
					if (this.armor[j].type == 1208)
					{
						Player player80 = this;
						player80.meleeDamage = player80.meleeDamage + 0.03f;
						Player player81 = this;
						player81.rangedDamage = player81.rangedDamage + 0.03f;
						Player player82 = this;
						player82.magicDamage = player82.magicDamage + 0.03f;
						Player player83 = this;
						player83.magicCrit = player83.magicCrit + 2;
						Player player84 = this;
						player84.meleeCrit = player84.meleeCrit + 2;
						Player player85 = this;
						player85.rangedCrit = player85.rangedCrit + 2;
					}
					if (this.armor[j].type == 1209)
					{
						Player player86 = this;
						player86.meleeDamage = player86.meleeDamage + 0.02f;
						Player player87 = this;
						player87.rangedDamage = player87.rangedDamage + 0.02f;
						Player player88 = this;
						player88.magicDamage = player88.magicDamage + 0.02f;
						Player player89 = this;
						player89.magicCrit = player89.magicCrit + 1;
						Player player90 = this;
						player90.meleeCrit = player90.meleeCrit + 1;
						Player player91 = this;
						player91.rangedCrit = player91.rangedCrit + 1;
					}
					if (this.armor[j].type == 1210)
					{
						Player player92 = this;
						player92.meleeDamage = player92.meleeDamage + 0.07f;
						Player player93 = this;
						player93.meleeSpeed = player93.meleeSpeed + 0.07f;
						Player player94 = this;
						player94.moveSpeed = player94.moveSpeed + 0.07f;
					}
					if (this.armor[j].type == 1211)
					{
						Player player95 = this;
						player95.rangedCrit = player95.rangedCrit + 15;
						Player player96 = this;
						player96.moveSpeed = player96.moveSpeed + 0.08f;
					}
					if (this.armor[j].type == 1212)
					{
						Player player97 = this;
						player97.magicCrit = player97.magicCrit + 18;
						Player player98 = this;
						player98.statManaMax2 = player98.statManaMax2 + 80;
					}
					if (this.armor[j].type == 1213)
					{
						Player player99 = this;
						player99.magicCrit = player99.magicCrit + 6;
						Player player100 = this;
						player100.meleeCrit = player100.meleeCrit + 6;
						Player player101 = this;
						player101.rangedCrit = player101.rangedCrit + 6;
					}
					if (this.armor[j].type == 1214)
					{
						Player player102 = this;
						player102.moveSpeed = player102.moveSpeed + 0.11f;
					}
					if (this.armor[j].type == 1215)
					{
						Player player103 = this;
						player103.meleeDamage = player103.meleeDamage + 0.08f;
						Player player104 = this;
						player104.meleeCrit = player104.meleeCrit + 8;
						Player player105 = this;
						player105.meleeSpeed = player105.meleeSpeed + 0.08f;
					}
					if (this.armor[j].type == 1216)
					{
						Player player106 = this;
						player106.rangedDamage = player106.rangedDamage + 0.16f;
						Player player107 = this;
						player107.rangedCrit = player107.rangedCrit + 7;
					}
					if (this.armor[j].type == 1217)
					{
						Player player108 = this;
						player108.magicDamage = player108.magicDamage + 0.16f;
						Player player109 = this;
						player109.magicCrit = player109.magicCrit + 7;
						Player player110 = this;
						player110.statManaMax2 = player110.statManaMax2 + 100;
					}
					if (this.armor[j].type == 1218)
					{
						Player player111 = this;
						player111.meleeDamage = player111.meleeDamage + 0.04f;
						Player player112 = this;
						player112.rangedDamage = player112.rangedDamage + 0.04f;
						Player player113 = this;
						player113.magicDamage = player113.magicDamage + 0.04f;
						Player player114 = this;
						player114.magicCrit = player114.magicCrit + 3;
						Player player115 = this;
						player115.meleeCrit = player115.meleeCrit + 3;
						Player player116 = this;
						player116.rangedCrit = player116.rangedCrit + 3;
					}
					if (this.armor[j].type == 1219)
					{
						Player player117 = this;
						player117.meleeDamage = player117.meleeDamage + 0.03f;
						Player player118 = this;
						player118.rangedDamage = player118.rangedDamage + 0.03f;
						Player player119 = this;
						player119.magicDamage = player119.magicDamage + 0.03f;
						Player player120 = this;
						player120.magicCrit = player120.magicCrit + 3;
						Player player121 = this;
						player121.meleeCrit = player121.meleeCrit + 3;
						Player player122 = this;
						player122.rangedCrit = player122.rangedCrit + 3;
						Player player123 = this;
						player123.moveSpeed = player123.moveSpeed + 0.06f;
					}
					if (this.armor[j].type == 558)
					{
						Player player124 = this;
						player124.magicDamage = player124.magicDamage + 0.12f;
						Player player125 = this;
						player125.magicCrit = player125.magicCrit + 12;
						Player player126 = this;
						player126.statManaMax2 = player126.statManaMax2 + 100;
					}
					if (this.armor[j].type == 559)
					{
						Player player127 = this;
						player127.meleeCrit = player127.meleeCrit + 10;
						Player player128 = this;
						player128.meleeDamage = player128.meleeDamage + 0.1f;
						Player player129 = this;
						player129.meleeSpeed = player129.meleeSpeed + 0.1f;
					}
					if (this.armor[j].type == 553)
					{
						Player player130 = this;
						player130.rangedDamage = player130.rangedDamage + 0.15f;
						Player player131 = this;
						player131.rangedCrit = player131.rangedCrit + 8;
					}
					if (this.armor[j].type == 551)
					{
						Player player132 = this;
						player132.magicCrit = player132.magicCrit + 7;
						Player player133 = this;
						player133.meleeCrit = player133.meleeCrit + 7;
						Player player134 = this;
						player134.rangedCrit = player134.rangedCrit + 7;
					}
					if (this.armor[j].type == 552)
					{
						Player player135 = this;
						player135.rangedDamage = player135.rangedDamage + 0.07f;
						Player player136 = this;
						player136.meleeDamage = player136.meleeDamage + 0.07f;
						Player player137 = this;
						player137.magicDamage = player137.magicDamage + 0.07f;
						Player player138 = this;
						player138.moveSpeed = player138.moveSpeed + 0.08f;
					}
					if (this.armor[j].type == 1001)
					{
						Player player139 = this;
						player139.meleeDamage = player139.meleeDamage + 0.16f;
						Player player140 = this;
						player140.meleeCrit = player140.meleeCrit + 6;
					}
					if (this.armor[j].type == 1002)
					{
						Player player141 = this;
						player141.rangedDamage = player141.rangedDamage + 0.16f;
						this.ammoCost80 = true;
					}
					if (this.armor[j].type == 1003)
					{
						Player player142 = this;
						player142.statManaMax2 = player142.statManaMax2 + 80;
						Player player143 = this;
						player143.manaCost = player143.manaCost - 0.17f;
						Player player144 = this;
						player144.magicDamage = player144.magicDamage + 0.16f;
					}
					if (this.armor[j].type == 1004)
					{
						Player player145 = this;
						player145.meleeDamage = player145.meleeDamage + 0.05f;
						Player player146 = this;
						player146.magicDamage = player146.magicDamage + 0.05f;
						Player player147 = this;
						player147.rangedDamage = player147.rangedDamage + 0.05f;
						Player player148 = this;
						player148.magicCrit = player148.magicCrit + 7;
						Player player149 = this;
						player149.meleeCrit = player149.meleeCrit + 7;
						Player player150 = this;
						player150.rangedCrit = player150.rangedCrit + 7;
					}
					if (this.armor[j].type == 1005)
					{
						Player player151 = this;
						player151.magicCrit = player151.magicCrit + 8;
						Player player152 = this;
						player152.meleeCrit = player152.meleeCrit + 8;
						Player player153 = this;
						player153.rangedCrit = player153.rangedCrit + 8;
						Player player154 = this;
						player154.moveSpeed = player154.moveSpeed + 0.05f;
					}
					if (this.armor[j].type == 2189)
					{
						Player player155 = this;
						player155.statManaMax2 = player155.statManaMax2 + 60;
						Player player156 = this;
						player156.manaCost = player156.manaCost - 0.13f;
						Player player157 = this;
						player157.magicDamage = player157.magicDamage + 0.05f;
						Player player158 = this;
						player158.magicCrit = player158.magicCrit + 5;
					}
					if (this.armor[j].type == 1503)
					{
						Player player159 = this;
						player159.magicDamage = player159.magicDamage - 0.4f;
					}
					if (this.armor[j].type == 1504)
					{
						Player player160 = this;
						player160.magicDamage = player160.magicDamage + 0.07f;
						Player player161 = this;
						player161.magicCrit = player161.magicCrit + 7;
					}
					if (this.armor[j].type == 1505)
					{
						Player player162 = this;
						player162.magicDamage = player162.magicDamage + 0.08f;
						Player player163 = this;
						player163.moveSpeed = player163.moveSpeed + 0.08f;
					}
					if (this.armor[j].type == 1546)
					{
						Player player164 = this;
						player164.rangedCrit = player164.rangedCrit + 5;
						Player player165 = this;
						player165.arrowDamage = player165.arrowDamage + 0.15f;
					}
					if (this.armor[j].type == 1547)
					{
						Player player166 = this;
						player166.rangedCrit = player166.rangedCrit + 5;
						Player player167 = this;
						player167.bulletDamage = player167.bulletDamage + 0.15f;
					}
					if (this.armor[j].type == 1548)
					{
						Player player168 = this;
						player168.rangedCrit = player168.rangedCrit + 5;
						Player player169 = this;
						player169.rocketDamage = player169.rocketDamage + 0.15f;
					}
					if (this.armor[j].type == 1549)
					{
						Player player170 = this;
						player170.rangedCrit = player170.rangedCrit + 13;
						Player player171 = this;
						player171.rangedDamage = player171.rangedDamage + 0.13f;
						this.ammoCost80 = true;
					}
					if (this.armor[j].type == 1550)
					{
						Player player172 = this;
						player172.rangedCrit = player172.rangedCrit + 7;
						Player player173 = this;
						player173.moveSpeed = player173.moveSpeed + 0.12f;
					}
					if (this.armor[j].type == 1282)
					{
						Player player174 = this;
						player174.statManaMax2 = player174.statManaMax2 + 20;
						Player player175 = this;
						player175.manaCost = player175.manaCost - 0.05f;
					}
					if (this.armor[j].type == 1283)
					{
						Player player176 = this;
						player176.statManaMax2 = player176.statManaMax2 + 40;
						Player player177 = this;
						player177.manaCost = player177.manaCost - 0.07f;
					}
					if (this.armor[j].type == 1284)
					{
						Player player178 = this;
						player178.statManaMax2 = player178.statManaMax2 + 40;
						Player player179 = this;
						player179.manaCost = player179.manaCost - 0.09f;
					}
					if (this.armor[j].type == 1285)
					{
						Player player180 = this;
						player180.statManaMax2 = player180.statManaMax2 + 60;
						Player player181 = this;
						player181.manaCost = player181.manaCost - 0.11f;
					}
					if (this.armor[j].type == 1286)
					{
						Player player182 = this;
						player182.statManaMax2 = player182.statManaMax2 + 60;
						Player player183 = this;
						player183.manaCost = player183.manaCost - 0.13f;
					}
					if (this.armor[j].type == 1287)
					{
						Player player184 = this;
						player184.statManaMax2 = player184.statManaMax2 + 80;
						Player player185 = this;
						player185.manaCost = player185.manaCost - 0.15f;
					}
					if (this.armor[j].type == 1316 || this.armor[j].type == 1317 || this.armor[j].type == 1318)
					{
						Player player186 = this;
						player186.aggro = player186.aggro + 250;
					}
					if (this.armor[j].type == 1316)
					{
						Player player187 = this;
						player187.meleeDamage = player187.meleeDamage + 0.06f;
					}
					if (this.armor[j].type == 1317)
					{
						Player player188 = this;
						player188.meleeDamage = player188.meleeDamage + 0.08f;
						Player player189 = this;
						player189.meleeCrit = player189.meleeCrit + 8;
					}
					if (this.armor[j].type == 1318)
					{
						Player player190 = this;
						player190.meleeCrit = player190.meleeCrit + 4;
					}
					if (this.armor[j].type == 2199 || this.armor[j].type == 2202)
					{
						Player player191 = this;
						player191.aggro = player191.aggro + 250;
					}
					if (this.armor[j].type == 2201)
					{
						Player player192 = this;
						player192.aggro = player192.aggro + 400;
					}
					if (this.armor[j].type == 2199)
					{
						Player player193 = this;
						player193.meleeDamage = player193.meleeDamage + 0.06f;
					}
					if (this.armor[j].type == 2200)
					{
						Player player194 = this;
						player194.meleeDamage = player194.meleeDamage + 0.08f;
						Player player195 = this;
						player195.meleeCrit = player195.meleeCrit + 8;
						Player player196 = this;
						player196.meleeSpeed = player196.meleeSpeed + 0.06f;
						Player player197 = this;
						player197.moveSpeed = player197.moveSpeed + 0.06f;
					}
					if (this.armor[j].type == 2201)
					{
						Player player198 = this;
						player198.meleeDamage = player198.meleeDamage + 0.05f;
						Player player199 = this;
						player199.meleeCrit = player199.meleeCrit + 5;
					}
					if (this.armor[j].type == 2202)
					{
						Player player200 = this;
						player200.meleeSpeed = player200.meleeSpeed + 0.06f;
						Player player201 = this;
						player201.moveSpeed = player201.moveSpeed + 0.06f;
					}
					if (this.armor[j].type == 684)
					{
						Player player202 = this;
						player202.rangedDamage = player202.rangedDamage + 0.16f;
						Player player203 = this;
						player203.meleeDamage = player203.meleeDamage + 0.16f;
					}
					if (this.armor[j].type == 685)
					{
						Player player204 = this;
						player204.meleeCrit = player204.meleeCrit + 11;
						Player player205 = this;
						player205.rangedCrit = player205.rangedCrit + 11;
					}
					if (this.armor[j].type == 686)
					{
						Player player206 = this;
						player206.moveSpeed = player206.moveSpeed + 0.08f;
						Player player207 = this;
						player207.meleeSpeed = player207.meleeSpeed + 0.07f;
					}
					if (this.armor[j].type == 2361)
					{
						Player player208 = this;
						player208.maxMinions = player208.maxMinions + 1;
						Player player209 = this;
						player209.minionDamage = player209.minionDamage + 0.04f;
					}
					if (this.armor[j].type == 2362)
					{
						Player player210 = this;
						player210.maxMinions = player210.maxMinions + 1;
						Player player211 = this;
						player211.minionDamage = player211.minionDamage + 0.04f;
					}
					if (this.armor[j].type == 2363)
					{
						Player player212 = this;
						player212.minionDamage = player212.minionDamage + 0.05f;
					}
					if (this.armor[j].type >= 1158 && this.armor[j].type <= 1161)
					{
						Player player213 = this;
						player213.maxMinions = player213.maxMinions + 1;
					}
					if (this.armor[j].type >= 1159 && this.armor[j].type <= 1161)
					{
						Player player214 = this;
						player214.minionDamage = player214.minionDamage + 0.1f;
					}
					if (this.armor[j].type >= 2370 && this.armor[j].type <= 2371)
					{
						Player player215 = this;
						player215.minionDamage = player215.minionDamage + 0.05f;
						Player player216 = this;
						player216.maxMinions = player216.maxMinions + 1;
					}
					if (this.armor[j].type == 2372)
					{
						Player player217 = this;
						player217.minionDamage = player217.minionDamage + 0.06f;
						Player player218 = this;
						player218.maxMinions = player218.maxMinions + 1;
					}
					if (this.armor[j].type == 3381 || this.armor[j].type == 3382 || this.armor[j].type == 3383)
					{
						if (this.armor[j].type != 3381)
						{
							Player player219 = this;
							player219.maxMinions = player219.maxMinions + 1;
						}
						Player player220 = this;
						player220.maxMinions = player220.maxMinions + 1;
						Player player221 = this;
						player221.minionDamage = player221.minionDamage + 0.22f;
					}
					if (this.armor[j].type == 2763)
					{
						Player player222 = this;
						player222.aggro = player222.aggro + 300;
						Player player223 = this;
						player223.meleeCrit = player223.meleeCrit + 17;
					}
					if (this.armor[j].type == 2764)
					{
						Player player224 = this;
						player224.aggro = player224.aggro + 300;
						Player player225 = this;
						player225.meleeDamage = player225.meleeDamage + 0.22f;
					}
					if (this.armor[j].type == 2765)
					{
						Player player226 = this;
						player226.aggro = player226.aggro + 300;
						Player player227 = this;
						player227.meleeSpeed = player227.meleeSpeed + 0.15f;
						Player player228 = this;
						player228.moveSpeed = player228.moveSpeed + 0.15f;
					}
					if (this.armor[j].type == 2757)
					{
						Player player229 = this;
						player229.rangedCrit = player229.rangedCrit + 7;
						Player player230 = this;
						player230.rangedDamage = player230.rangedDamage + 0.16f;
					}
					if (this.armor[j].type == 2758)
					{
						this.ammoCost75 = true;
						Player player231 = this;
						player231.rangedCrit = player231.rangedCrit + 12;
						Player player232 = this;
						player232.rangedDamage = player232.rangedDamage + 0.12f;
					}
					if (this.armor[j].type == 2759)
					{
						Player player233 = this;
						player233.rangedCrit = player233.rangedCrit + 8;
						Player player234 = this;
						player234.rangedDamage = player234.rangedDamage + 0.08f;
						Player player235 = this;
						player235.moveSpeed = player235.moveSpeed + 0.1f;
					}
					if (this.armor[j].type == 2760)
					{
						Player player236 = this;
						player236.statManaMax2 = player236.statManaMax2 + 60;
						Player player237 = this;
						player237.manaCost = player237.manaCost - 0.15f;
						Player player238 = this;
						player238.magicCrit = player238.magicCrit + 7;
						Player player239 = this;
						player239.magicDamage = player239.magicDamage + 0.07f;
					}
					if (this.armor[j].type == 2761)
					{
						Player player240 = this;
						player240.magicDamage = player240.magicDamage + 0.09f;
						Player player241 = this;
						player241.magicCrit = player241.magicCrit + 9;
					}
					if (this.armor[j].type == 2762)
					{
						Player player242 = this;
						player242.moveSpeed = player242.moveSpeed + 0.1f;
						Player player243 = this;
						player243.magicDamage = player243.magicDamage + 0.1f;
					}
					if (this.armor[j].type >= 1832 && this.armor[j].type <= 1834)
					{
						Player player244 = this;
						player244.maxMinions = player244.maxMinions + 1;
					}
					if (this.armor[j].type >= 1832 && this.armor[j].type <= 1834)
					{
						Player player245 = this;
						player245.minionDamage = player245.minionDamage + 0.11f;
					}
					if (this.armor[j].prefix == 62)
					{
						Player player246 = this;
						player246.statDefense = player246.statDefense + 1;
					}
					if (this.armor[j].prefix == 63)
					{
						Player player247 = this;
						player247.statDefense = player247.statDefense + 2;
					}
					if (this.armor[j].prefix == 64)
					{
						Player player248 = this;
						player248.statDefense = player248.statDefense + 3;
					}
					if (this.armor[j].prefix == 65)
					{
						Player player249 = this;
						player249.statDefense = player249.statDefense + 4;
					}
					if (this.armor[j].prefix == 66)
					{
						Player player250 = this;
						player250.statManaMax2 = player250.statManaMax2 + 20;
					}
					if (this.armor[j].prefix == 67)
					{
						Player player251 = this;
						player251.meleeCrit = player251.meleeCrit + 2;
						Player player252 = this;
						player252.rangedCrit = player252.rangedCrit + 2;
						Player player253 = this;
						player253.magicCrit = player253.magicCrit + 2;
						Player player254 = this;
						player254.thrownCrit = player254.thrownCrit + 2;
					}
					if (this.armor[j].prefix == 68)
					{
						Player player255 = this;
						player255.meleeCrit = player255.meleeCrit + 4;
						Player player256 = this;
						player256.rangedCrit = player256.rangedCrit + 4;
						Player player257 = this;
						player257.magicCrit = player257.magicCrit + 4;
						Player player258 = this;
						player258.thrownCrit = player258.thrownCrit + 4;
					}
					if (this.armor[j].prefix == 69)
					{
						Player player259 = this;
						player259.meleeDamage = player259.meleeDamage + 0.01f;
						Player player260 = this;
						player260.rangedDamage = player260.rangedDamage + 0.01f;
						Player player261 = this;
						player261.magicDamage = player261.magicDamage + 0.01f;
						Player player262 = this;
						player262.minionDamage = player262.minionDamage + 0.01f;
						Player player263 = this;
						player263.thrownDamage = player263.thrownDamage + 0.01f;
					}
					if (this.armor[j].prefix == 70)
					{
						Player player264 = this;
						player264.meleeDamage = player264.meleeDamage + 0.02f;
						Player player265 = this;
						player265.rangedDamage = player265.rangedDamage + 0.02f;
						Player player266 = this;
						player266.magicDamage = player266.magicDamage + 0.02f;
						Player player267 = this;
						player267.minionDamage = player267.minionDamage + 0.02f;
						Player player268 = this;
						player268.thrownDamage = player268.thrownDamage + 0.02f;
					}
					if (this.armor[j].prefix == 71)
					{
						Player player269 = this;
						player269.meleeDamage = player269.meleeDamage + 0.03f;
						Player player270 = this;
						player270.rangedDamage = player270.rangedDamage + 0.03f;
						Player player271 = this;
						player271.magicDamage = player271.magicDamage + 0.03f;
						Player player272 = this;
						player272.minionDamage = player272.minionDamage + 0.03f;
						Player player273 = this;
						player273.thrownDamage = player273.thrownDamage + 0.03f;
					}
					if (this.armor[j].prefix == 72)
					{
						Player player274 = this;
						player274.meleeDamage = player274.meleeDamage + 0.04f;
						Player player275 = this;
						player275.rangedDamage = player275.rangedDamage + 0.04f;
						Player player276 = this;
						player276.magicDamage = player276.magicDamage + 0.04f;
						Player player277 = this;
						player277.minionDamage = player277.minionDamage + 0.04f;
						Player player278 = this;
						player278.thrownDamage = player278.thrownDamage + 0.04f;
					}
					if (this.armor[j].prefix == 73)
					{
						Player player279 = this;
						player279.moveSpeed = player279.moveSpeed + 0.01f;
					}
					if (this.armor[j].prefix == 74)
					{
						Player player280 = this;
						player280.moveSpeed = player280.moveSpeed + 0.02f;
					}
					if (this.armor[j].prefix == 75)
					{
						Player player281 = this;
						player281.moveSpeed = player281.moveSpeed + 0.03f;
					}
					if (this.armor[j].prefix == 76)
					{
						Player player282 = this;
						player282.moveSpeed = player282.moveSpeed + 0.04f;
					}
					if (this.armor[j].prefix == 77)
					{
						Player player283 = this;
						player283.meleeSpeed = player283.meleeSpeed + 0.01f;
					}
					if (this.armor[j].prefix == 78)
					{
						Player player284 = this;
						player284.meleeSpeed = player284.meleeSpeed + 0.02f;
					}
					if (this.armor[j].prefix == 79)
					{
						Player player285 = this;
						player285.meleeSpeed = player285.meleeSpeed + 0.03f;
					}
					if (this.armor[j].prefix == 80)
					{
						Player player286 = this;
						player286.meleeSpeed = player286.meleeSpeed + 0.04f;
					}
				}
			}
			bool flag = false;
			bool flag1 = false;
			bool flag2 = false;
			for (int k = 3; k < 8 + this.extraAccessorySlots; k++)
			{
				if (!this.armor[k].expertOnly || Main.expertMode)
				{
					if (this.armor[k].type == 3015)
					{
						Player player287 = this;
						player287.aggro = player287.aggro - 400;
						Player player288 = this;
						player288.meleeCrit = player288.meleeCrit + 5;
						Player player289 = this;
						player289.magicCrit = player289.magicCrit + 5;
						Player player290 = this;
						player290.rangedCrit = player290.rangedCrit + 5;
						Player player291 = this;
						player291.thrownCrit = player291.thrownCrit + 5;
						Player player292 = this;
						player292.meleeDamage = player292.meleeDamage + 0.05f;
						Player player293 = this;
						player293.magicDamage = player293.magicDamage + 0.05f;
						Player player294 = this;
						player294.rangedDamage = player294.rangedDamage + 0.05f;
						Player player295 = this;
						player295.thrownDamage = player295.thrownDamage + 0.05f;
						Player player296 = this;
						player296.minionDamage = player296.minionDamage + 0.05f;
					}
					if (this.armor[k].type == 3016)
					{
						Player player297 = this;
						player297.aggro = player297.aggro + 400;
					}
					if (this.armor[k].type == 2373)
					{
						this.accFishingLine = true;
					}
					if (this.armor[k].type == 2374)
					{
						Player player298 = this;
						player298.fishingSkill = player298.fishingSkill + 10;
					}
					if (this.armor[k].type == 2375)
					{
						this.accTackleBox = true;
					}
					if (this.armor[k].type == 3090)
					{
						this.npcTypeNoAggro[1] = true;
						this.npcTypeNoAggro[16] = true;
						this.npcTypeNoAggro[59] = true;
						this.npcTypeNoAggro[71] = true;
						this.npcTypeNoAggro[81] = true;
						this.npcTypeNoAggro[138] = true;
						this.npcTypeNoAggro[121] = true;
						this.npcTypeNoAggro[122] = true;
						this.npcTypeNoAggro[141] = true;
						this.npcTypeNoAggro[147] = true;
						this.npcTypeNoAggro[183] = true;
						this.npcTypeNoAggro[184] = true;
						this.npcTypeNoAggro[204] = true;
						this.npcTypeNoAggro[225] = true;
						this.npcTypeNoAggro[244] = true;
						this.npcTypeNoAggro[302] = true;
						this.npcTypeNoAggro[333] = true;
						this.npcTypeNoAggro[335] = true;
						this.npcTypeNoAggro[334] = true;
						this.npcTypeNoAggro[336] = true;
						this.npcTypeNoAggro[537] = true;
					}
					if (this.armor[k].stringColor > 0)
					{
						this.yoyoString = true;
					}
					if (this.armor[k].type == 3366)
					{
						this.counterWeight = 556 + Main.rand.Next(6);
						this.yoyoGlove = true;
						this.yoyoString = true;
					}
					if (this.armor[k].type >= 3309 && this.armor[k].type <= 3314)
					{
						this.counterWeight = 556 + this.armor[k].type - 3309;
					}
					if (this.armor[k].type == 3334)
					{
						this.yoyoGlove = true;
					}
					if (this.armor[k].type == 3337)
					{
						this.shinyStone = true;
					}
					if (this.armor[k].type == 3336)
					{
						this.SporeSac();
						this.sporeSac = true;
					}
					if (this.armor[k].type == 2423)
					{
						this.autoJump = true;
						Player player299 = this;
						player299.jumpSpeedBoost = player299.jumpSpeedBoost + 2.4f;
						Player player300 = this;
						player300.extraFall = player300.extraFall + 15;
					}
					if (this.armor[k].type == 857)
					{
						this.doubleJumpSandstorm = true;
					}
					if (this.armor[k].type == 983)
					{
						this.doubleJumpSandstorm = true;
						this.jumpBoost = true;
					}
					if (this.armor[k].type == 987)
					{
						this.doubleJumpBlizzard = true;
					}
					if (this.armor[k].type == 1163)
					{
						this.doubleJumpBlizzard = true;
						this.jumpBoost = true;
					}
					if (this.armor[k].type == 1724)
					{
						this.doubleJumpFart = true;
					}
					if (this.armor[k].type == 1863)
					{
						this.doubleJumpFart = true;
						this.jumpBoost = true;
					}
					if (this.armor[k].type == 1164)
					{
						this.doubleJumpCloud = true;
						this.doubleJumpSandstorm = true;
						this.doubleJumpBlizzard = true;
						this.jumpBoost = true;
					}
					if (this.armor[k].type == 1250)
					{
						this.jumpBoost = true;
						this.doubleJumpCloud = true;
						this.noFallDmg = true;
					}
					if (this.armor[k].type == 1252)
					{
						this.doubleJumpSandstorm = true;
						this.jumpBoost = true;
						this.noFallDmg = true;
					}
					if (this.armor[k].type == 1251)
					{
						this.doubleJumpBlizzard = true;
						this.jumpBoost = true;
						this.noFallDmg = true;
					}
					if (this.armor[k].type == 3250)
					{
						this.doubleJumpFart = true;
						this.jumpBoost = true;
						this.noFallDmg = true;
					}
					if (this.armor[k].type == 3252)
					{
						this.doubleJumpSail = true;
						this.jumpBoost = true;
						this.noFallDmg = true;
					}
					if (this.armor[k].type == 3251)
					{
						this.jumpBoost = true;
						this.bee = true;
						this.noFallDmg = true;
					}
					if (this.armor[k].type == 1249)
					{
						this.jumpBoost = true;
						this.bee = true;
					}
					if (this.armor[k].type == 3241)
					{
						this.jumpBoost = true;
						this.doubleJumpSail = true;
					}
					if (this.armor[k].type == 1253 && (double)this.statLife <= (double)this.statLifeMax2 * 0.5)
					{
						this.AddBuff(BuffID.IceBarrier, 5, true);
					}
					if (this.armor[k].type == 1290)
					{
						this.panic = true;
					}
					if ((this.armor[k].type == 1300 || this.armor[k].type == 1858) && (this.inventory[this.selectedItem].useAmmo == 14 || this.inventory[this.selectedItem].useAmmo == 311 || this.inventory[this.selectedItem].useAmmo == 323 || this.inventory[this.selectedItem].useAmmo == 23))
					{
						this.scope = true;
					}
					if (this.armor[k].type == 1858)
					{
						Player player301 = this;
						player301.rangedCrit = player301.rangedCrit + 10;
						Player player302 = this;
						player302.rangedDamage = player302.rangedDamage + 0.1f;
					}
					if (this.armor[k].type == 1301)
					{
						Player player303 = this;
						player303.meleeCrit = player303.meleeCrit + 8;
						Player player304 = this;
						player304.rangedCrit = player304.rangedCrit + 8;
						Player player305 = this;
						player305.magicCrit = player305.magicCrit + 8;
						Player player306 = this;
						player306.thrownCrit = player306.thrownCrit + 8;
						Player player307 = this;
						player307.meleeDamage = player307.meleeDamage + 0.1f;
						Player player308 = this;
						player308.rangedDamage = player308.rangedDamage + 0.1f;
						Player player309 = this;
						player309.magicDamage = player309.magicDamage + 0.1f;
						Player player310 = this;
						player310.minionDamage = player310.minionDamage + 0.1f;
						Player player311 = this;
						player311.thrownDamage = player311.thrownDamage + 0.1f;
					}
					if (this.armor[k].type == 982)
					{
						Player player312 = this;
						player312.statManaMax2 = player312.statManaMax2 + 20;
						Player player313 = this;
						player313.manaRegenDelayBonus = player313.manaRegenDelayBonus + 1;
						Player player314 = this;
						player314.manaRegenBonus = player314.manaRegenBonus + 25;
					}
					if (this.armor[k].type == 1595)
					{
						Player player315 = this;
						player315.statManaMax2 = player315.statManaMax2 + 20;
						this.magicCuffs = true;
					}
					if (this.armor[k].type == 2219)
					{
						this.manaMagnet = true;
					}
					if (this.armor[k].type == 2220)
					{
						this.manaMagnet = true;
						Player player316 = this;
						player316.magicDamage = player316.magicDamage + 0.15f;
					}
					if (this.armor[k].type == 2221)
					{
						this.manaMagnet = true;
						this.magicCuffs = true;
					}
					if (this.whoAmI == Main.myPlayer && this.armor[k].type == 1923)
					{
						Player.tileRangeX = Player.tileRangeX + 1;
						Player.tileRangeY = Player.tileRangeY + 1;
					}
					if (this.armor[k].type == 1247)
					{
						this.starCloak = true;
						this.bee = true;
					}
					if (this.armor[k].type == 1248)
					{
						Player player317 = this;
						player317.meleeCrit = player317.meleeCrit + 10;
						Player player318 = this;
						player318.rangedCrit = player318.rangedCrit + 10;
						Player player319 = this;
						player319.magicCrit = player319.magicCrit + 10;
						Player player320 = this;
						player320.thrownCrit = player320.thrownCrit + 10;
					}
					if (this.armor[k].type == 854)
					{
						this.discount = true;
					}
					if (this.armor[k].type == 855)
					{
						this.coins = true;
					}
					if (this.armor[k].type == 3033)
					{
						this.goldRing = true;
					}
					if (this.armor[k].type == 3034)
					{
						this.goldRing = true;
						this.coins = true;
					}
					if (this.armor[k].type == 3035)
					{
						this.goldRing = true;
						this.coins = true;
						this.discount = true;
					}
					if (this.armor[k].type == 53)
					{
						this.doubleJumpCloud = true;
					}
					if (this.armor[k].type == 3201)
					{
						this.doubleJumpSail = true;
					}
					if (this.armor[k].type == 54)
					{
						this.accRunSpeed = 6f;
					}
					if (this.armor[k].type == 3068)
					{
						this.cordage = true;
					}
					if (this.armor[k].type == 1579)
					{
						this.accRunSpeed = 6f;
						this.coldDash = true;
					}
					if (this.armor[k].type == 3200)
					{
						this.accRunSpeed = 6f;
						this.sailDash = true;
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
						Player player321 = this;
						player321.spikedBoots = player321.spikedBoots + 1;
					}
					if (this.armor[k].type == 975)
					{
						Player player322 = this;
						player322.spikedBoots = player322.spikedBoots + 1;
					}
					if (this.armor[k].type == 976)
					{
						Player player323 = this;
						player323.spikedBoots = player323.spikedBoots + 2;
					}
					if (this.armor[k].type == 977)
					{
						this.dash = 1;
					}
					if (this.armor[k].type == 3097)
					{
						this.dash = 2;
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
					if (this.armor[k].type == 3224)
					{
						Player player324 = this;
						player324.endurance = player324.endurance + 0.17f;
					}
					if (this.armor[k].type == 3223)
					{
						this.brainOfConfusion = true;
					}
					if (this.armor[k].type == 950)
					{
						this.iceSkate = true;
					}
					if (this.armor[k].type == 159)
					{
						this.jumpBoost = true;
					}
					if (this.armor[k].type == 3225)
					{
						this.jumpBoost = true;
					}
					if (this.armor[k].type == 187)
					{
						this.accFlipper = true;
					}
					if (this.armor[k].type == 211)
					{
						Player player325 = this;
						player325.meleeSpeed = player325.meleeSpeed + 0.12f;
					}
					if (this.armor[k].type == 223)
					{
						Player player326 = this;
						player326.manaCost = player326.manaCost - 0.06f;
					}
					if (this.armor[k].type == 285)
					{
						Player player327 = this;
						player327.moveSpeed = player327.moveSpeed + 0.05f;
					}
					if (this.armor[k].type == 212)
					{
						Player player328 = this;
						player328.moveSpeed = player328.moveSpeed + 0.1f;
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
						if (this.hideVisual[k])
						{
							this.hideMerman = true;
							this.hideWolf = true;
						}
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
						Player player329 = this;
						player329.lavaMax = player329.lavaMax + 420;
					}
					if (this.armor[k].type == 906)
					{
						Player player330 = this;
						player330.lavaMax = player330.lavaMax + 420;
					}
					if (this.armor[k].type == 485)
					{
						this.wolfAcc = true;
						if (this.hideVisual[k])
						{
							this.hideWolf = true;
						}
					}

					if (this.armor[k].type == 486 && !this.hideVisual[k])
					{
						this.rulerLine = true;
					}
					if (this.armor[k].type == 2799 && !this.hideVisual[k])
					{
						this.rulerGrid = true;
					}
					if (this.armor[k].type == 394)
					{
						this.accFlipper = true;
						this.accDivingHelm = true;
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
						this.doubleJumpCloud = true;
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
						this.arcticDivingGear = true;
						this.accFlipper = true;
						this.accDivingHelm = true;
						this.iceSkate = true;
					}
					if (this.armor[k].type == 2214)
					{
						flag1 = true;
					}
					if (this.armor[k].type == 2215)
					{
						flag2 = true;
					}
					if (this.armor[k].type == 2216)
					{
						this.autoPaint = true;
					}
					if (this.armor[k].type == 2217)
					{
						flag = true;
					}
					if (this.armor[k].type == 3061)
					{
						flag = true;
						flag1 = true;
						this.autoPaint = true;
						flag2 = true;
					}
					if (this.armor[k].type == 897)
					{
						this.kbGlove = true;
						Player player331 = this;
						player331.meleeSpeed = player331.meleeSpeed + 0.12f;
					}
					if (this.armor[k].type == 1343)
					{
						this.kbGlove = true;
						Player player332 = this;
						player332.meleeSpeed = player332.meleeSpeed + 0.1f;
						Player player333 = this;
						player333.meleeDamage = player333.meleeDamage + 0.1f;
						this.magmaStone = true;
					}
					if (this.armor[k].type == 1167)
					{
						Player player334 = this;
						player334.minionKB = player334.minionKB + 2f;
						Player player335 = this;
						player335.minionDamage = player335.minionDamage + 0.15f;
					}
					if (this.armor[k].type == 1864)
					{
						Player player336 = this;
						player336.minionKB = player336.minionKB + 2f;
						Player player337 = this;
						player337.minionDamage = player337.minionDamage + 0.15f;
						Player player338 = this;
						player338.maxMinions = player338.maxMinions + 1;
					}
					if (this.armor[k].type == 1845)
					{
						Player player339 = this;
						player339.minionDamage = player339.minionDamage + 0.1f;
						Player player340 = this;
						player340.maxMinions = player340.maxMinions + 1;
					}
					if (this.armor[k].type == 1321)
					{
						this.magicQuiver = true;
						Player player341 = this;
						player341.arrowDamage = player341.arrowDamage + 0.1f;
					}
					if (this.armor[k].type == 1322)
					{
						this.magmaStone = true;
					}
					if (this.armor[k].type == 1323)
					{
						this.lavaRose = true;
					}
					if (this.armor[k].type == 3333)
					{
						this.strongBees = true;
					}
					if (this.armor[k].type == 938)
					{
						this.noKnockback = true;
						if ((double)this.statLife > (double)this.statLifeMax2 * 0.25)
						{
							if (i == Main.myPlayer)
							{
								this.paladinGive = true;
							}
							else if (this.miscCounter % 5 == 0)
							{
								int num3 = Main.myPlayer;
								if (Main.player[num3].team == this.team && this.team != 0)
								{
									float single = this.position.X - Main.player[num3].position.X;
									float y1 = this.position.Y - Main.player[num3].position.Y;
									if ((float)Math.Sqrt((double)(single * single + y1 * y1)) < 800f)
									{
										Main.player[num3].AddBuff(BuffID.PaladinsShield, 10, true);
									}
								}
							}
						}
					}
					if (this.armor[k].type == 936)
					{
						this.kbGlove = true;
						Player player342 = this;
						player342.meleeSpeed = player342.meleeSpeed + 0.12f;
						Player player343 = this;
						player343.meleeDamage = player343.meleeDamage + 0.12f;
					}
					if (this.armor[k].type == 898)
					{
						this.accRunSpeed = 6.75f;
						this.rocketBoots = 2;
						Player player344 = this;
						player344.moveSpeed = player344.moveSpeed + 0.08f;
					}
					if (this.armor[k].type == 1862)
					{
						this.accRunSpeed = 6.75f;
						this.rocketBoots = 3;
						Player player345 = this;
						player345.moveSpeed = player345.moveSpeed + 0.08f;
						this.iceSkate = true;
					}
					if (this.armor[k].type == 3110)
					{
						this.accMerman = true;
						this.wolfAcc = true;
						if (this.hideVisual[k])
						{
							this.hideMerman = true;
							this.hideWolf = true;
						}
					}
					if (this.armor[k].type == 1865 || this.armor[k].type == 3110)
					{
						Player player346 = this;
						player346.lifeRegen = player346.lifeRegen + 2;
						Player player347 = this;
						player347.statDefense = player347.statDefense + 4;
						Player player348 = this;
						player348.meleeSpeed = player348.meleeSpeed + 0.1f;
						Player player349 = this;
						player349.meleeDamage = player349.meleeDamage + 0.1f;
						Player player350 = this;
						player350.meleeCrit = player350.meleeCrit + 2;
						Player player351 = this;
						player351.rangedDamage = player351.rangedDamage + 0.1f;
						Player player352 = this;
						player352.rangedCrit = player352.rangedCrit + 2;
						Player player353 = this;
						player353.magicDamage = player353.magicDamage + 0.1f;
						Player player354 = this;
						player354.magicCrit = player354.magicCrit + 2;
						Player player355 = this;
						player355.pickSpeed = player355.pickSpeed - 0.15f;
						Player player356 = this;
						player356.minionDamage = player356.minionDamage + 0.1f;
						Player player357 = this;
						player357.minionKB = player357.minionKB + 0.5f;
						Player player358 = this;
						player358.thrownDamage = player358.thrownDamage + 0.1f;
						Player player359 = this;
						player359.thrownCrit = player359.thrownCrit + 2;
					}
					if (this.armor[k].type == 899 && Main.dayTime)
					{
						Player player360 = this;
						player360.lifeRegen = player360.lifeRegen + 2;
						Player player361 = this;
						player361.statDefense = player361.statDefense + 4;
						Player player362 = this;
						player362.meleeSpeed = player362.meleeSpeed + 0.1f;
						Player player363 = this;
						player363.meleeDamage = player363.meleeDamage + 0.1f;
						Player player364 = this;
						player364.meleeCrit = player364.meleeCrit + 2;
						Player player365 = this;
						player365.rangedDamage = player365.rangedDamage + 0.1f;
						Player player366 = this;
						player366.rangedCrit = player366.rangedCrit + 2;
						Player player367 = this;
						player367.magicDamage = player367.magicDamage + 0.1f;
						Player player368 = this;
						player368.magicCrit = player368.magicCrit + 2;
						Player player369 = this;
						player369.pickSpeed = player369.pickSpeed - 0.15f;
						Player player370 = this;
						player370.minionDamage = player370.minionDamage + 0.1f;
						Player player371 = this;
						player371.minionKB = player371.minionKB + 0.5f;
						Player player372 = this;
						player372.thrownDamage = player372.thrownDamage + 0.1f;
						Player player373 = this;
						player373.thrownCrit = player373.thrownCrit + 2;
					}
					if (this.armor[k].type == 900 && (!Main.dayTime || Main.eclipse))
					{
						Player player374 = this;
						player374.lifeRegen = player374.lifeRegen + 2;
						Player player375 = this;
						player375.statDefense = player375.statDefense + 4;
						Player player376 = this;
						player376.meleeSpeed = player376.meleeSpeed + 0.1f;
						Player player377 = this;
						player377.meleeDamage = player377.meleeDamage + 0.1f;
						Player player378 = this;
						player378.meleeCrit = player378.meleeCrit + 2;
						Player player379 = this;
						player379.rangedDamage = player379.rangedDamage + 0.1f;
						Player player380 = this;
						player380.rangedCrit = player380.rangedCrit + 2;
						Player player381 = this;
						player381.magicDamage = player381.magicDamage + 0.1f;
						Player player382 = this;
						player382.magicCrit = player382.magicCrit + 2;
						Player player383 = this;
						player383.pickSpeed = player383.pickSpeed - 0.15f;
						Player player384 = this;
						player384.minionDamage = player384.minionDamage + 0.1f;
						Player player385 = this;
						player385.minionKB = player385.minionKB + 0.5f;
						Player player386 = this;
						player386.thrownDamage = player386.thrownDamage + 0.1f;
						Player player387 = this;
						player387.thrownCrit = player387.thrownCrit + 2;
					}
					if (this.armor[k].type == 407)
					{
						this.blockRange = 1;
					}
					if (this.armor[k].type == 489)
					{
						Player player388 = this;
						player388.magicDamage = player388.magicDamage + 0.15f;
					}
					if (this.armor[k].type == 490)
					{
						Player player389 = this;
						player389.meleeDamage = player389.meleeDamage + 0.15f;
					}
					if (this.armor[k].type == 491)
					{
						Player player390 = this;
						player390.rangedDamage = player390.rangedDamage + 0.15f;
					}
					if (this.armor[k].type == 2998)
					{
						Player player391 = this;
						player391.minionDamage = player391.minionDamage + 0.15f;
					}
					if (this.armor[k].type == 935)
					{
						Player player392 = this;
						player392.magicDamage = player392.magicDamage + 0.12f;
						Player player393 = this;
						player393.meleeDamage = player393.meleeDamage + 0.12f;
						Player player394 = this;
						player394.rangedDamage = player394.rangedDamage + 0.12f;
						Player player395 = this;
						player395.minionDamage = player395.minionDamage + 0.12f;
						Player player396 = this;
						player396.thrownDamage = player396.thrownDamage + 0.12f;
					}
					if (this.armor[k].type == 492)
					{
						this.wingTimeMax = 100;
					}
					if (this.armor[k].type == 493)
					{
						this.wingTimeMax = 100;
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
					if (this.armor[k].type == 2494)
					{
						this.wingTimeMax = 100;
					}
					if (this.armor[k].type == 2609)
					{
						this.wingTimeMax = 180;
						this.ignoreWater = true;
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
					if (this.armor[k].type == 665)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[k].type == 1583)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[k].type == 1584)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[k].type == 1585)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[k].type == 1586)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[k].type == 3228)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[k].type == 3580)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[k].type == 3582)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[k].type == 3588)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[k].type == 3592)
					{
						this.wingTimeMax = 150;
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
					if (this.armor[k].type == 2770)
					{
						this.wingTimeMax = 160;
					}
					if (this.armor[k].type == 3468)
					{
						this.wingTimeMax = 180;
					}
					if (this.armor[k].type == 3469)
					{
						this.wingTimeMax = 160;
					}
					if (this.armor[k].type == 3470)
					{
						this.wingTimeMax = 180;
					}
					if (this.armor[k].type == 3471)
					{
						this.wingTimeMax = 220;
					}
					if (this.armor[k].type == 885)
					{
						this.buffImmune[BuffID.Bleeding] = true;
					}
					if (this.armor[k].type == 886)
					{
						this.buffImmune[BuffID.BrokenArmor] = true;
					}
					if (this.armor[k].type == 887)
					{
						this.buffImmune[BuffID.Poisoned] = true;
					}
					if (this.armor[k].type == 888)
					{
						this.buffImmune[BuffID.Darkness] = true;
					}
					if (this.armor[k].type == 889)
					{
						this.buffImmune[BuffID.Slow] = true;
					}
					if (this.armor[k].type == 890)
					{
						this.buffImmune[BuffID.Silenced] = true;
					}
					if (this.armor[k].type == 891)
					{
						this.buffImmune[BuffID.Cursed] = true;
					}
					if (this.armor[k].type == 892)
					{
						this.buffImmune[BuffID.Weak] = true;
					}
					if (this.armor[k].type == 893)
					{
						this.buffImmune[BuffID.Confused] = true;
					}
					if (this.armor[k].type == 901)
					{
						this.buffImmune[BuffID.Weak] = true;
						this.buffImmune[BuffID.BrokenArmor] = true;
					}
					if (this.armor[k].type == 902)
					{
						this.buffImmune[BuffID.Bleeding] = true;
						this.buffImmune[BuffID.Poisoned] = true;
					}
					if (this.armor[k].type == 903)
					{
						this.buffImmune[BuffID.Slow] = true;
						this.buffImmune[BuffID.Confused] = true;
					}
					if (this.armor[k].type == 904)
					{
						this.buffImmune[BuffID.Silenced] = true;
						this.buffImmune[BuffID.Cursed] = true;
					}
					if (this.armor[k].type == 1921)
					{
						this.buffImmune[BuffID.Chilled] = true;
						this.buffImmune[BuffID.Frozen] = true;
					}
					if (this.armor[k].type == 1612)
					{
						this.buffImmune[BuffID.Weak] = true;
						this.buffImmune[BuffID.BrokenArmor] = true;
						this.buffImmune[BuffID.Bleeding] = true;
						this.buffImmune[BuffID.Poisoned] = true;
						this.buffImmune[BuffID.Slow] = true;
						this.buffImmune[BuffID.Confused] = true;
						this.buffImmune[BuffID.Silenced] = true;
						this.buffImmune[BuffID.Cursed] = true;
						this.buffImmune[BuffID.Darkness] = true;
					}
					if (this.armor[k].type == 1613)
					{
						this.buffImmune[BuffID.Chilled] = true;
						this.noKnockback = true;
						this.fireWalk = true;
						this.buffImmune[BuffID.Weak] = true;
						this.buffImmune[BuffID.BrokenArmor] = true;
						this.buffImmune[BuffID.Bleeding] = true;
						this.buffImmune[BuffID.Poisoned] = true;
						this.buffImmune[BuffID.Slow] = true;
						this.buffImmune[BuffID.Confused] = true;
						this.buffImmune[BuffID.Silenced] = true;
						this.buffImmune[BuffID.Cursed] = true;
						this.buffImmune[BuffID.Darkness] = true;
					}
					if (this.armor[k].type == 497)
					{
						this.accMerman = true;
						if (this.hideVisual[k])
						{
							this.hideMerman = true;
						}
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
						Player player397 = this;
						player397.manaCost = player397.manaCost - 0.08f;
					}
					if (Main.myPlayer == this.whoAmI)
					{
						if (this.armor[k].type == 576 && Main.rand.Next(10800) == 0 && Main.curMusic > 0 && Main.curMusic <= 39)
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
							if (Main.curMusic == 28)
							{
								this.armor[k].SetDefaults(1963, false);
							}
							else if (Main.curMusic == 29)
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
							else if (Main.curMusic == 33)
							{
								this.armor[k].SetDefaults(2742, false);
							}
							else if (Main.curMusic == 34)
							{
								this.armor[k].SetDefaults(3370, false);
							}
							else if (Main.curMusic == 35)
							{
								this.armor[k].SetDefaults(3236, false);
							}
							else if (Main.curMusic == 36)
							{
								this.armor[k].SetDefaults(3237, false);
							}
							else if (Main.curMusic == 37)
							{
								this.armor[k].SetDefaults(3235, false);
							}
							else if (Main.curMusic == 38)
							{
								this.armor[k].SetDefaults(3044, false);
							}
							else if (Main.curMusic == 39)
							{
								this.armor[k].SetDefaults(3371, false);
							}
							else if (Main.curMusic <= 13)
							{
								this.armor[k].SetDefaults(num4 + 562, false);
							}
							else
							{
								this.armor[k].SetDefaults(1596 + Main.curMusic - 14, false);
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
						if (this.armor[k].type == 2742)
						{
							Main.musicBox2 = 31;
						}
						if (this.armor[k].type == 3044)
						{
							Main.musicBox2 = 32;
						}
						if (this.armor[k].type == 3235)
						{
							Main.musicBox2 = 33;
						}
						if (this.armor[k].type == 3236)
						{
							Main.musicBox2 = 34;
						}
						if (this.armor[k].type == 3237)
						{
							Main.musicBox2 = 35;
						}
						if (this.armor[k].type == 3370)
						{
							Main.musicBox2 = 36;
						}
						if (this.armor[k].type == 3371)
						{
							Main.musicBox2 = 37;
						}
					}
				}
			}
			for (int l = 3; l < 8 + this.extraAccessorySlots; l++)
			{
				if (this.armor[l].wingSlot > 0)
				{
					if (!this.hideVisual[l] || this.velocity.Y != 0f && !this.mount.Active)
					{
						this.wings = this.armor[l].wingSlot;
					}
					this.wingsLogic = this.armor[l].wingSlot;
				}
			}
			for (int m = 13; m < 18 + this.extraAccessorySlots; m++)
			{
				int type3 = this.armor[m].type;
				if (this.armor[m].wingSlot > 0)
				{
					this.wings = this.armor[m].wingSlot;
				}
				if (type3 == 861 || type3 == 3110 || type3 == 485)
				{
					this.hideWolf = false;
					this.forceWerewolf = true;
				}
				if (((this.wet && !this.lavaWet && (!this.mount.Active || this.mount.Type != 3)) || !this.forceWerewolf) && (type3 == 861 || type3 == 3110 || type3 == 497))
				{
					this.hideMerman = false;
					this.forceMerman = true;
				}

			}
			if (this.whoAmI == Main.myPlayer && Main.clock && this.accWatch < 3)
			{
				Player player398 = this;
				player398.accWatch = player398.accWatch + 1;
			}
			if (flag1)
			{
				Player player399 = this;
				player399.tileSpeed = player399.tileSpeed + 0.5f;
			}
			if (flag)
			{
				Player player400 = this;
				player400.wallSpeed = player400.wallSpeed + 0.5f;
			}
			if (flag2 && this.whoAmI == Main.myPlayer)
			{
				Player.tileRangeX = Player.tileRangeX + 3;
				Player.tileRangeY = Player.tileRangeY + 2;
			}
			if (!this.accThirdEye)
			{
				this.accThirdEyeCounter = 0;
			}
			if (Main.netMode == 1 && this.whoAmI == Main.myPlayer)
			{
				for (int n = 0; n < 255; n++)
				{
					if (n != this.whoAmI && Main.player[n].active && !Main.player[n].dead && Main.player[n].team == this.team && Main.player[n].team != 0 && (Main.player[n].Center - base.Center).Length() < (float)800)
					{
						if (Main.player[n].accWatch > this.accWatch)
						{
							this.accWatch = Main.player[n].accWatch;
						}
						if (Main.player[n].accCompass > this.accCompass)
						{
							this.accCompass = Main.player[n].accCompass;
						}
						if (Main.player[n].accDepthMeter > this.accDepthMeter)
						{
							this.accDepthMeter = Main.player[n].accDepthMeter;
						}
						if (Main.player[n].accFishFinder)
						{
							this.accFishFinder = true;
						}
						if (Main.player[n].accWeatherRadio)
						{
							this.accWeatherRadio = true;
						}
						if (Main.player[n].accThirdEye)
						{
							this.accThirdEye = true;
						}
						if (Main.player[n].accJarOfSouls)
						{
							this.accJarOfSouls = true;
						}
						if (Main.player[n].accCalendar)
						{
							this.accCalendar = true;
						}
						if (Main.player[n].accStopwatch)
						{
							this.accStopwatch = true;
						}
						if (Main.player[n].accOreFinder)
						{
							this.accOreFinder = true;
						}
						if (Main.player[n].accCritterGuide)
						{
							this.accCritterGuide = true;
						}
						if (Main.player[n].accDreamCatcher)
						{
							this.accDreamCatcher = true;
						}
					}
				}
			}
			if (!this.accDreamCatcher && this.dpsStarted)
			{
				this.dpsStarted = false;
				this.dpsEnd = DateTime.Now;
			}
		}

		public void UpdateImmunity()
		{
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
			for (int i = 0; i < this.hurtCooldowns.Length; i++)
			{
				if (this.hurtCooldowns[i] > 0)
				{
					this.hurtCooldowns[i]--;
				}
			}
		}

		public void UpdateJumpHeight()
		{
			if (!this.mount.Active)
			{
				if (this.jumpBoost)
				{
					Player.jumpHeight = 20;
					Player.jumpSpeed = 6.51f;
				}
				if (this.wereWolf)
				{
					Player.jumpHeight = Player.jumpHeight + 2;
					Player.jumpSpeed = Player.jumpSpeed + 0.2f;
				}
				Player.jumpSpeed = Player.jumpSpeed + this.jumpSpeedBoost;
			}
			else
			{
				Player.jumpHeight = this.mount.JumpHeight(this.velocity.X);
				Player.jumpSpeed = this.mount.JumpSpeed(this.velocity.X);
			}
			if (this.sticky)
			{
				Player.jumpHeight = Player.jumpHeight / 10;
				Player.jumpSpeed = Player.jumpSpeed / 5f;
			}
			if (this.dazed)
			{
				Player.jumpHeight = Player.jumpHeight / 5;
				Player.jumpSpeed = Player.jumpSpeed / 2f;
			}
		}

		public void UpdateLifeRegen()
		{
			bool flag = false;
			if (this.shinyStone && (double)Math.Abs(this.velocity.X) < 0.05 && (double)Math.Abs(this.velocity.Y) < 0.05 && this.itemAnimation == 0)
			{
				flag = true;
			}
			if (this.poisoned)
			{
				if (this.lifeRegen > 0)
				{
					this.lifeRegen = 0;
				}
				this.lifeRegenTime = 0;
				Player player = this;
				player.lifeRegen = player.lifeRegen - 4;
			}
			if (this.venom)
			{
				if (this.lifeRegen > 0)
				{
					this.lifeRegen = 0;
				}
				this.lifeRegenTime = 0;
				Player player1 = this;
				player1.lifeRegen = player1.lifeRegen - 12;
			}
			if (this.onFire)
			{
				if (this.lifeRegen > 0)
				{
					this.lifeRegen = 0;
				}
				this.lifeRegenTime = 0;
				Player player2 = this;
				player2.lifeRegen = player2.lifeRegen - 8;
			}
			if (this.onFrostBurn)
			{
				if (this.lifeRegen > 0)
				{
					this.lifeRegen = 0;
				}
				this.lifeRegenTime = 0;
				Player player3 = this;
				player3.lifeRegen = player3.lifeRegen - 12;
			}
			if (this.onFire2)
			{
				if (this.lifeRegen > 0)
				{
					this.lifeRegen = 0;
				}
				this.lifeRegenTime = 0;
				Player player4 = this;
				player4.lifeRegen = player4.lifeRegen - 12;
			}
			if (this.burned)
			{
				if (this.lifeRegen > 0)
				{
					this.lifeRegen = 0;
				}
				this.lifeRegenTime = 0;
				Player player5 = this;
				player5.lifeRegen = player5.lifeRegen - 60;
				Player player6 = this;
				player6.moveSpeed = player6.moveSpeed * 0.5f;
			}
			if (this.suffocating)
			{
				if (this.lifeRegen > 0)
				{
					this.lifeRegen = 0;
				}
				this.lifeRegenTime = 0;
				Player player7 = this;
				player7.lifeRegen = player7.lifeRegen - 40;
			}
			if (this.electrified)
			{
				if (this.lifeRegen > 0)
				{
					this.lifeRegen = 0;
				}
				this.lifeRegenTime = 0;
				Player player8 = this;
				player8.lifeRegen = player8.lifeRegen - 8;
				if (this.controlLeft || this.controlRight)
				{
					Player player9 = this;
					player9.lifeRegen = player9.lifeRegen - 32;
				}
			}
			if (this.tongued && Main.expertMode)
			{
				if (this.lifeRegen > 0)
				{
					this.lifeRegen = 0;
				}
				this.lifeRegenTime = 0;
				Player player10 = this;
				player10.lifeRegen = player10.lifeRegen - 100;
			}
			if (this.honey && this.lifeRegen < 0)
			{
				Player player11 = this;
				player11.lifeRegen = player11.lifeRegen + 4;
				if (this.lifeRegen > 0)
				{
					this.lifeRegen = 0;
				}
			}
			if (this.lifeRegen < 0 && this.nebulaLevelLife > 0)
			{
				this.lifeRegen = 0;
			}
			if (flag && this.lifeRegen < 0)
			{
				Player player12 = this;
				player12.lifeRegen = player12.lifeRegen / 2;
			}
			Player player13 = this;
			player13.lifeRegenTime = player13.lifeRegenTime + 1;
			if (this.crimsonRegen)
			{
				Player player14 = this;
				player14.lifeRegenTime = player14.lifeRegenTime + 1;
			}
			if (this.soulDrain > 0)
			{
				Player player15 = this;
				player15.lifeRegenTime = player15.lifeRegenTime + 2;
			}
			if (flag)
			{
				if (this.lifeRegenTime > 90 && this.lifeRegenTime < 1800)
				{
					this.lifeRegenTime = 1800;
				}
				Player player16 = this;
				player16.lifeRegenTime = player16.lifeRegenTime + 4;
				Player player17 = this;
				player17.lifeRegen = player17.lifeRegen + 4;
			}
			if (this.honey)
			{
				Player player18 = this;
				player18.lifeRegenTime = player18.lifeRegenTime + 2;
				Player player19 = this;
				player19.lifeRegen = player19.lifeRegen + 2;
			}
			if (this.soulDrain > 0)
			{
				int num = (5 + this.soulDrain) / 2;
				Player player20 = this;
				player20.lifeRegenTime = player20.lifeRegenTime + num;
				Player player21 = this;
				player21.lifeRegen = player21.lifeRegen + num;
			}
			if (this.whoAmI == Main.myPlayer && Main.campfire)
			{
				Player player22 = this;
				player22.lifeRegen = player22.lifeRegen + 1;
			}
			if (this.whoAmI == Main.myPlayer && Main.heartLantern)
			{
				Player player23 = this;
				player23.lifeRegen = player23.lifeRegen + 2;
			}
			if (this.bleed)
			{
				this.lifeRegenTime = 0;
			}
			float single = 0f;
			if (this.lifeRegenTime >= 300)
			{
				single = single + 1f;
			}
			if (this.lifeRegenTime >= 600)
			{
				single = single + 1f;
			}
			if (this.lifeRegenTime >= 900)
			{
				single = single + 1f;
			}
			if (this.lifeRegenTime >= 1200)
			{
				single = single + 1f;
			}
			if (this.lifeRegenTime >= 1500)
			{
				single = single + 1f;
			}
			if (this.lifeRegenTime >= 1800)
			{
				single = single + 1f;
			}
			if (this.lifeRegenTime >= 2400)
			{
				single = single + 1f;
			}
			if (this.lifeRegenTime >= 3000)
			{
				single = single + 1f;
			}
			if (flag)
			{
				float single1 = (float)(this.lifeRegenTime - 3000);
				single1 = single1 / 300f;
				if (single1 > 0f)
				{
					if (single1 > 30f)
					{
						single1 = 30f;
					}
					single = single + single1;
				}
			}
			else if (this.lifeRegenTime >= 3600)
			{
				single = single + 1f;
				this.lifeRegenTime = 3600;
			}
			single = (this.velocity.X == 0f || this.grappling[0] > 0 ? single * 1.25f : single * 0.5f);
			if (this.crimsonRegen)
			{
				single = single * 1.5f;
			}
			if (this.shinyStone)
			{
				single = single * 1.1f;
			}
			if (this.whoAmI == Main.myPlayer && Main.campfire)
			{
				single = single * 1.1f;
			}
			if (Main.expertMode && !this.wellFed)
			{
				single = (!this.shinyStone ? single / 2f : single * 0.75f);
			}
			if (this.rabid)
			{
				single = (!this.shinyStone ? single / 2f : single * 0.75f);
			}
			float single2 = (float)this.statLifeMax2 / 400f * 0.85f + 0.15f;
			single = single * single2;
			Player player24 = this;
			player24.lifeRegen = player24.lifeRegen + (int)Math.Round((double)single);
			Player player25 = this;
			player25.lifeRegenCount = player25.lifeRegenCount + this.lifeRegen;
			if (this.palladiumRegen)
			{
				Player player26 = this;
				player26.lifeRegenCount = player26.lifeRegenCount + 6;
			}
			if (flag && this.lifeRegen > 0 && this.statLife < this.statLifeMax2)
			{
				Player player27 = this;
				player27.lifeRegenCount = player27.lifeRegenCount + 1;
			}
			while (this.lifeRegenCount >= 120)
			{
				Player player28 = this;
				player28.lifeRegenCount = player28.lifeRegenCount - 120;
				if (this.statLife < this.statLifeMax2)
				{
					Player player29 = this;
					player29.statLife = player29.statLife + 1;
				}
				if (this.statLife <= this.statLifeMax2)
				{
					continue;
				}
				this.statLife = this.statLifeMax2;
			}
			if (!this.burned && !this.suffocating)
			{
				if (!this.tongued || !Main.expertMode)
				{
					while (this.lifeRegenCount <= -120)
					{
						if (this.lifeRegenCount <= -480)
						{
							Player player30 = this;
							player30.lifeRegenCount = player30.lifeRegenCount + 480;
							Player player31 = this;
							player31.statLife = player31.statLife - 4;
							CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), CombatText.LifeRegen, string.Concat(4), false, true);
						}
						else if (this.lifeRegenCount <= -360)
						{
							Player player32 = this;
							player32.lifeRegenCount = player32.lifeRegenCount + 360;
							Player player33 = this;
							player33.statLife = player33.statLife - 3;
							CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), CombatText.LifeRegen, string.Concat(3), false, true);
						}
						else if (this.lifeRegenCount > -240)
						{
							Player player34 = this;
							player34.lifeRegenCount = player34.lifeRegenCount + 120;
							Player player35 = this;
							player35.statLife = player35.statLife - 1;
							CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), CombatText.LifeRegen, string.Concat(1), false, true);
						}
						else
						{
							Player player36 = this;
							player36.lifeRegenCount = player36.lifeRegenCount + 240;
							Player player37 = this;
							player37.statLife = player37.statLife - 2;
							CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), CombatText.LifeRegen, string.Concat(2), false, true);
						}
						if (this.statLife > 0 || this.whoAmI != Main.myPlayer)
						{
							continue;
						}
						if (this.poisoned || this.venom)
						{
							this.KillMe(10, 0, false, string.Concat(" ", Lang.dt[0]));
						}
						else if (!this.electrified)
						{
							this.KillMe(10, 0, false, string.Concat(" ", Lang.dt[1]));
						}
						else
						{
							this.KillMe(10, 0, false, string.Concat(" ", Lang.dt[3]));
						}
					}
					return;
				}
			}
			while (this.lifeRegenCount <= -600)
			{
				Player player38 = this;
				player38.lifeRegenCount = player38.lifeRegenCount + 600;
				Player player39 = this;
				player39.statLife = player39.statLife - 5;
				CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), CombatText.LifeRegen, string.Concat(5), false, true);
				if (this.statLife > 0 || this.whoAmI != Main.myPlayer)
				{
					continue;
				}
				if (!this.suffocating)
				{
					this.KillMe(10, 0, false, string.Concat(" ", Lang.dt[1]));
				}
				else
				{
					this.KillMe(10, 0, false, string.Concat(" ", Lang.dt[2]));
				}
			}
		}

		public void UpdateManaRegen()
		{
			if (this.nebulaLevelMana <= 0)
			{
				this.nebulaManaCounter = 0;
			}
			else
			{
				int num = 6;
				Player player = this;
				player.nebulaManaCounter = player.nebulaManaCounter + this.nebulaLevelMana;
				if (this.nebulaManaCounter >= num)
				{
					Player player1 = this;
					player1.nebulaManaCounter = player1.nebulaManaCounter - num;
					Player player2 = this;
					player2.statMana = player2.statMana + 1;
					if (this.statMana >= this.statManaMax2)
					{
						this.statMana = this.statManaMax2;
					}
				}
			}
			if (this.manaRegenDelay > 0)
			{
				Player player3 = this;
				player3.manaRegenDelay = player3.manaRegenDelay - 1;
				Player player4 = this;
				player4.manaRegenDelay = player4.manaRegenDelay - this.manaRegenDelayBonus;
				if (this.velocity.X == 0f && this.velocity.Y == 0f || this.grappling[0] >= 0 || this.manaRegenBuff)
				{
					Player player5 = this;
					player5.manaRegenDelay = player5.manaRegenDelay - 1;
				}
			}
			if (this.manaRegenBuff && this.manaRegenDelay > 20)
			{
				this.manaRegenDelay = 20;
			}
			if (this.manaRegenDelay > 0)
			{
				this.manaRegen = 0;
			}
			else
			{
				this.manaRegenDelay = 0;
				this.manaRegen = this.statManaMax2 / 7 + 1 + this.manaRegenBonus;
				if (this.velocity.X == 0f && this.velocity.Y == 0f || this.grappling[0] >= 0 || this.manaRegenBuff)
				{
					Player player6 = this;
					player6.manaRegen = player6.manaRegen + this.statManaMax2 / 2;
				}
				float single = (float)this.statMana / (float)this.statManaMax2 * 0.8f + 0.2f;
				if (this.manaRegenBuff)
				{
					single = 1f;
				}
				this.manaRegen = (int)((double)((float)this.manaRegen * single) * 1.15);
			}
			Player player7 = this;
			player7.manaRegenCount = player7.manaRegenCount + this.manaRegen;
			while (this.manaRegenCount >= 120)
			{
				bool flag = false;
				Player player8 = this;
				player8.manaRegenCount = player8.manaRegenCount - 120;
				if (this.statMana < this.statManaMax2)
				{
					Player player9 = this;
					player9.statMana = player9.statMana + 1;
					flag = true;
				}
				if (this.statMana < this.statManaMax2)
				{
					continue;
				}
				if (this.whoAmI == Main.myPlayer && flag)
				{
				}
				this.statMana = this.statManaMax2;
			}
		}

		public void UpdateMinionTarget()
		{
			if (this.whoAmI != Main.myPlayer)
			{
				return;
			}
			if (base.Distance(this.MinionTargetPoint) > 1000f)
			{
				this.MinionTargetPoint = Vector2.Zero;
			}
		}

		public void UpdatePet(int i)
		{
			if (i != Main.myPlayer)
			{
				return;
			}
			if (this.miscEquips[0].buffType < 1 || this.miscEquips[0].stack < 1)
			{
				return;
			}
			int num = this.miscEquips[0].buffType;
			if (!Main.vanityPet[num] && !Main.lightPet[num])
			{
				return;
			}
			if (this.hideMisc[0])
			{
				return;
			}
			if (this.miscEquips[0].type == 603 && !Main.cEd)
			{
				return;
			}
			if (this.HasBuff(num) == -1)
			{
				this.AddBuff(num, 3600, true);
			}
		}

		public void UpdatePetLight(int i)
		{
			if (i != Main.myPlayer)
			{
				return;
			}
			if (this.miscEquips[1].buffType < 1 || this.miscEquips[1].stack < 1)
			{
				return;
			}
			int num = this.miscEquips[1].buffType;
			if (!Main.vanityPet[num] && !Main.lightPet[num])
			{
				return;
			}
			if (this.hideMisc[1])
			{
				return;
			}
			if (this.miscEquips[1].type == 603 && !Main.cEd)
			{
				return;
			}
			int num1 = this.HasBuff(num);
			if (num == 27 && num1 == -1)
			{
				num1 = this.HasBuff(BuffID.FairyGreen);
			}
			if (num == 27 && num1 == -1)
			{
				num1 = this.HasBuff(BuffID.FairyRed);
			}
			if (num1 == -1)
			{
				if (num == 27)
				{
					Random random = Main.rand;
					int[] numArray = new int[] { 27, 102, 101 };
					num = Terraria.Utils.SelectRandom<int>(random, numArray);
				}
				this.AddBuff(num, 3600, true);
			}
		}

		public void UpdateSocialShadow()
		{
			for (int i = 2; i > 0; i--)
			{
				this.shadowDirection[i] = this.shadowDirection[i - 1];
			}
			this.shadowDirection[0] = this.direction;
			Player player = this;
			player.shadowCount = player.shadowCount + 1;
			if (this.shadowCount == 1)
			{
				this.shadowPos[2] = this.shadowPos[1];
				this.shadowRotation[2] = this.shadowRotation[1];
				this.shadowOrigin[2] = this.shadowOrigin[1];
				return;
			}
			if (this.shadowCount == 2)
			{
				this.shadowPos[1] = this.shadowPos[0];
				this.shadowRotation[1] = this.shadowRotation[0];
				this.shadowOrigin[1] = this.shadowOrigin[0];
				return;
			}
			if (this.shadowCount >= 3)
			{
				this.shadowCount = 0;
				this.shadowPos[0] = this.position;
				this.shadowPos[0].Y = this.shadowPos[0].Y + this.gfxOffY;
				this.shadowRotation[0] = this.fullRotation;
				this.shadowOrigin[0] = this.fullRotationOrigin;
			}
		}

		public void UpdateTouchingTiles()
		{
			this.TouchedTiles.Clear();
			List<Point> points = null;
			List<Point> points1 = null;
			if (!Collision.IsClearSpotHack(this.position + this.velocity, 16f, this.width, this.height, false, false, (int)this.gravDir, true, true))
			{
				points = Collision.FindCollisionTile((Math.Sign(this.velocity.Y) == 1 ? 2 : 3), this.position + this.velocity, 16f, this.width, this.height, false, false, (int)this.gravDir, true, false);
			}
			if (!Collision.IsClearSpotHack(this.position, Math.Abs(this.velocity.Y), this.width, this.height, false, false, (int)this.gravDir, true, true))
			{
				points1 = Collision.FindCollisionTile((Math.Sign(this.velocity.Y) == 1 ? 2 : 3), this.position, Math.Abs(this.velocity.Y), this.width, this.height, false, false, (int)this.gravDir, true, true);
			}
			if (points != null && points1 != null)
			{
				for (int i = 0; i < points1.Count; i++)
				{
					if (!points.Contains(points1[i]))
					{
						points.Add(points1[i]);
					}
				}
			}
			if (points == null && points1 != null)
			{
				points = points1;
			}
			if (points != null)
			{
				this.TouchedTiles = points;
			}
		}

		public void WallslideMovement()
		{
			this.sliding = false;
			if (this.slideDir != 0 && this.spikedBoots > 0 && !this.mount.Active && (this.controlLeft && this.slideDir == -1 || this.controlRight && this.slideDir == 1))
			{
				bool flag = false;
				float x = this.position.X;
				if (this.slideDir == 1)
				{
					x = x + (float)this.width;
				}
				x = x + (float)this.slideDir;
				float y = this.position.Y + (float)this.height + 1f;
				if (this.gravDir < 0f)
				{
					y = this.position.Y - 1f;
				}
				x = x / 16f;
				y = y / 16f;
				if (WorldGen.SolidTile((int)x, (int)y) && WorldGen.SolidTile((int)x, (int)y - 1))
				{
					flag = true;
				}
				if (this.spikedBoots >= 2)
				{
					if (flag && (this.velocity.Y > 0f && this.gravDir == 1f || this.velocity.Y < this.gravity && this.gravDir == -1f))
					{
						float single = this.gravity;
						if (this.slowFall)
						{
							single = (!this.controlUp ? this.gravity / 3f * this.gravDir : this.gravity / 10f * this.gravDir);
						}
						this.fallStart = (int)(this.position.Y / 16f);
						if (this.controlDown && this.gravDir == 1f || this.controlUp && this.gravDir == -1f)
						{ 
						}
						else if (this.gravDir != -1f)
						{
							this.velocity.Y = (-single + 1E-05f) * this.gravDir;
						}
						else
						{
							this.velocity.Y = (-single + 1E-05f) * this.gravDir;
						}
						this.sliding = true;
						return;
					}
				}
				else if (flag && (double)this.velocity.Y > 0.5 && this.gravDir == 1f || (double)this.velocity.Y < -0.5 && this.gravDir == -1f)
				{
					this.fallStart = (int)(this.position.Y / 16f);
					if (!this.controlDown)
					{
						this.velocity.Y = 0.5f * this.gravDir;
					}
					else
					{
						this.velocity.Y = 4f * this.gravDir;
					}
					this.sliding = true;
				}
			}
		}

		public void WaterCollision(bool fallThrough, bool ignorePlats)
		{
			int num;
			num = (!this.onTrack ? this.height : this.height - 20);
			Vector2 vector2 = this.velocity;
			this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, num, fallThrough, ignorePlats, (int)this.gravDir);
			Vector2 x = this.velocity * 0.5f;
			if (this.velocity.X != vector2.X)
			{
				x.X = this.velocity.X;
			}
			if (this.velocity.Y != vector2.Y)
			{
				x.Y = this.velocity.Y;
			}
			Player player = this;
			player.position = player.position + x;
		}

		public void WingMovement()
		{
			if (this.wingsLogic == 4 && this.controlUp)
			{
				this.velocity.Y = this.velocity.Y - 0.2f * this.gravDir;
				if (this.gravDir != 1f)
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
				else
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
				Player player = this;
				player.wingTime = player.wingTime - 2f;
				return;
			}
			float single = 0.1f;
			float single1 = 0.5f;
			float single2 = 1.5f;
			float single3 = 0.5f;
			float single4 = 0.1f;
			if (this.wingsLogic == 26)
			{
				single1 = 0.75f;
				single4 = 0.15f;
				single3 = 1f;
				single2 = 2.5f;
				single = 0.125f;
			}
			if (this.wingsLogic == 29)
			{
				single1 = 0.85f;
				single4 = 0.15f;
				single3 = 1f;
				single2 = 3f;
				single = 0.135f;
			}
			if (this.wingsLogic == 30)
			{
				single3 = 1f;
				single2 = 2f;
				single = 0.15f;
			}
			if (this.wingsLogic == 31)
			{
				single1 = 0.75f;
				single4 = 0.15f;
				single3 = 1f;
				single2 = 3f;
				single = 0.125f;
			}
			if (this.wingsLogic == 32)
			{
				single3 = 0.6f;
				single2 = 1.5f;
				single = 0.125f;
			}
			this.velocity.Y = this.velocity.Y - single * this.gravDir;
			if (this.gravDir != 1f)
			{
				if (this.velocity.Y < 0f)
				{
					this.velocity.Y = this.velocity.Y + single1;
				}
				else if (this.velocity.Y < Player.jumpSpeed * single3)
				{
					this.velocity.Y = this.velocity.Y + single4;
				}
				if (this.velocity.Y > Player.jumpSpeed * single2)
				{
					this.velocity.Y = Player.jumpSpeed * single2;
				}
			}
			else
			{
				if (this.velocity.Y > 0f)
				{
					this.velocity.Y = this.velocity.Y - single1;
				}
				else if (this.velocity.Y > -Player.jumpSpeed * single3)
				{
					this.velocity.Y = this.velocity.Y - single4;
				}
				if (this.velocity.Y < -Player.jumpSpeed * single2)
				{
					this.velocity.Y = -Player.jumpSpeed * single2;
				}
			}
			if (this.wingsLogic != 22 && this.wingsLogic != 28 && this.wingsLogic != 30 && this.wingsLogic != 32 || !this.controlDown || this.controlLeft || this.controlRight)
			{
				Player player1 = this;
				player1.wingTime = player1.wingTime - 1f;
				return;
			}
			Player player2 = this;
			player2.wingTime = player2.wingTime - 0.5f;
		}

		public void WOFTongue()
		{
			if (Main.wof >= 0 && Main.npc[Main.wof].active)
			{
				float x = Main.npc[Main.wof].position.X + 40f;
				if (Main.npc[Main.wof].direction > 0)
				{
					x = x - 96f;
				}
				if (this.position.X + (float)this.width > x && this.position.X < x + 140f && this.gross)
				{
					this.noKnockback = false;
					this.Hurt(50, Main.npc[Main.wof].direction, false, false, " was slain...", false);
				}
				if (!this.gross && this.position.Y > (float)((Main.maxTilesY - 250) * 16) && this.position.X > x - 1920f && this.position.X < x + 1920f)
				{
					this.AddBuff(BuffID.Horrified, 10, true);
				}
				if (this.gross)
				{
					if (this.position.Y < (float)((Main.maxTilesY - 200) * 16))
					{
						this.AddBuff(BuffID.TheTongue, 10, true);
					}
					if (Main.npc[Main.wof].direction < 0)
					{
						if (this.position.X + (float)(this.width / 2) > Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) + 40f)
						{
							this.AddBuff(BuffID.TheTongue, 10, true);
						}
					}
					else if (this.position.X + (float)(this.width / 2) < Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) - 40f)
					{
						this.AddBuff(BuffID.TheTongue, 10, true);
					}
				}
				if (this.tongued)
				{
					this.controlHook = false;
					this.controlUseItem = false;
					for (int i = 0; i < 1000; i++)
					{
						if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].aiStyle == 7)
						{
							Main.projectile[i].Kill();
						}
					}
					Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float single = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) - vector2.X;
					float y = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2) - vector2.Y;
					if ((float)Math.Sqrt((double)(single * single + y * y)) > 3000f)
					{
						this.KillMe(1000, 0, false, " tried to escape.");
						return;
					}
					if (Main.npc[Main.wof].position.X < 608f || Main.npc[Main.wof].position.X > (float)((Main.maxTilesX - 38) * 16))
					{
						this.KillMe(1000, 0, false, " was licked.");
					}
				}
			}
		}

		public void Yoraiz0rEye()
		{
			int y = 0;
			y = y + this.bodyFrame.Y / 56;
			if (y >= (int)Main.OffsetsPlayerHeadgear.Length)
			{
				y = 0;
			}
			Vector2 vector2 = ((new Vector2((float)(3 * this.direction - (this.direction == 1 ? 1 : 0)), -11.5f * this.gravDir) + (Vector2.UnitY * this.gfxOffY)) + (base.Size / 2f)) + Main.OffsetsPlayerHeadgear[y];
			Vector2 vector21 = (new Vector2((float)(3 * this.shadowDirection[1] - (this.direction == 1 ? 1 : 0)), -11.5f * this.gravDir) + (base.Size / 2f)) + Main.OffsetsPlayerHeadgear[y];
			Vector2 zero = Vector2.Zero;
			if (this.mount.Active && this.mount.Cart)
			{
				int num = Math.Sign(this.velocity.X);
				if (num == 0)
				{
					num = this.direction;
				}
				zero = (new Vector2(MathHelper.Lerp(0f, -8f, this.fullRotation / 0.7853982f), MathHelper.Lerp(0f, 2f, Math.Abs(this.fullRotation / 0.7853982f)))).RotatedBy((double)this.fullRotation, new Vector2());
				if (num == Math.Sign(this.fullRotation))
				{
					zero = zero * MathHelper.Lerp(1f, 0.6f, Math.Abs(this.fullRotation / 0.7853982f));
				}
			}
			if (this.fullRotation != 0f)
			{
				vector2 = vector2.RotatedBy((double)this.fullRotation, this.fullRotationOrigin);
				vector21 = vector21.RotatedBy((double)this.fullRotation, this.fullRotationOrigin);
			}
			Vector2 vector22 = (this.position + vector2) + zero;
			Vector2 vector23 = (this.oldPosition + vector21) + zero;
			float single = 1f;
			switch (this.yoraiz0rEye % 10)
			{
				case 1:
				{
					return;
				}
				case 2:
				{
					single = 0.5f;
					break;
				}
				case 3:
				{
					single = 0.625f;
					break;
				}
				case 4:
				{
					single = 0.75f;
					break;
				}
				case 5:
				{
					single = 0.875f;
					break;
				}
				case 6:
				{
					single = 1f;
					break;
				}
				case 7:
				{
					single = 1.1f;
					break;
				}
			}
			if (this.yoraiz0rEye < 7)
			{
				Color rgb = Main.HslToRgb(Main.RgbToHsl(this.eyeColor).X, 1f, 0.5f);
				DelegateMethods.v3_1 = (rgb.ToVector3() * 0.5f) * single;
			}
			int num1 = (int)Vector2.Distance(vector22, vector23) / 3 + 1;
			if (Vector2.Distance(vector22, vector23) % 3f != 0f)
			{
				num1++;
			}
		}

		public static event Action<Player> OnEnterWorld;

		public struct OverheadMessage
		{
			public string chatText;


			public int timeLeft;

			public void NewMessage(string message, int displayTime)
			{
				this.chatText = message;
				this.timeLeft = displayTime;
			}
		}

		public class SmartCursorSettings
		{
			public static bool SmartBlocksEnabled;

			static SmartCursorSettings()
			{
			}

			public SmartCursorSettings()
			{
			}
		}
	}
}
