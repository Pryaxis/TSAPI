using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Utilities;
using Terraria.World.Generation;

namespace Terraria
{
	public class Player : Entity
	{
		public bool CCed
		{
			get
			{
				return this.frozen || this.webbed || this.stoned;
			}
		}

		public Vector2 DefaultSize
		{
			get
			{
				return new Vector2(20f, 42f);
			}
		}

		public Item HeldItem
		{
			get
			{
				return this.inventory[this.selectedItem];
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
				return PlayerVariantID.Sets.Male[this.skinVariant];
			}
			set
			{
				if (value)
				{
					if (!this.Male)
					{
						this.skinVariant = PlayerVariantID.Sets.AltGenderReference[this.skinVariant];
						return;
					}
				}
				else if (this.Male)
				{
					this.skinVariant = PlayerVariantID.Sets.AltGenderReference[this.skinVariant];
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
				return this.statLife < this.statLifeMax2 / 2 || (this.wet && !this.lavaWet && !this.honeyWet) || this.dripping || this.MountFishronSpecialCounter > 0f;
			}
		}
		public bool HasMinionRestTarget
		{
			get
			{
				return this.MinionRestTargetPoint != Vector2.Zero;
			}
		}
		public bool HasMinionAttackTargetNPC
		{
			get
			{
				return this.MinionAttackTargetNPC != -1;
			}
		}

		public bool PortalPhysicsEnabled
		{
			get
			{
				return this._portalPhysicsTime > 0 && !this.mount.Active;
			}
		}

		public bool SlimeDontHyperJump
		{
			get
			{
				return this.mount.Active && this.mount.Type == 3 && this.wetSlime > 0 && !this.controlJump;
			}
		}
		public bool ZoneBeach
		{
			get
			{
				return this.zone3[5];
			}
			set
			{
				this.zone3[5] = value;
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
		public bool ZoneDirtLayerHeight
		{
			get
			{
				return this.zone3[2];
			}
			set
			{
				this.zone3[2] = value;
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
		public bool ZoneOverworldHeight
		{
			get
			{
				return this.zone3[1];
			}
			set
			{
				this.zone3[1] = value;
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
		public bool ZoneRain
		{
			get
			{
				return this.zone3[6];
			}
			set
			{
				this.zone3[6] = value;
			}
		}

		public bool ZoneRockLayerHeight
		{
			get
			{
				return this.zone3[3];
			}
			set
			{
				this.zone3[3] = value;
			}
		}

		public bool ZoneSandstorm
		{
			get
			{
				return this.zone3[7];
			}
			set
			{
				this.zone3[7] = value;
			}
		}
		public bool ZoneOldOneArmy
		{
			get
			{
				return this.zone4[0];
			}
			set
			{
				this.zone4[0] = value;
			}
		}
		public bool ZoneSkyHeight
		{
			get
			{
				return this.zone3[0];
			}
			set
			{
				this.zone3[0] = value;
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
		public bool ZoneUnderworldHeight
		{
			get
			{
				return this.zone3[4];
			}
			set
			{
				this.zone3[4] = value;
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

		public bool accCalendar;

		public int accCompass;

		public bool accCritterGuide;

		public byte accCritterGuideCounter;

		public byte accCritterGuideNumber;

		public int accDepthMeter;

		public bool accDivingHelm;

		public bool accDreamCatcher;

		public bool accFishFinder;

		public bool accFishingLine;

		public bool accFlipper;

		public bool accJarOfSouls;

		public bool accMerman;

		public bool accOreFinder;

		public float accRunSpeed;

		public bool accStopwatch;

		public bool accTackleBox;

		public bool accThirdEye;

		public byte accThirdEyeCounter;

		public byte accThirdEyeNumber;

		public int accWatch;

		public bool accWeatherRadio;

		public float activeNPCs;

		public bool ActuationRodLock;

		public bool ActuationRodLockSetting;

		public bool adjHoney;

		public bool adjLava;

		public bool[] adjTile;

		public bool adjWater;

		public int aggro;

		public bool alchemyTable;

		public int altFunctionUse;

		public bool ammoBox;

		public bool ammoCost75;

		public bool ammoCost80;

		public bool ammoPotion;

		public int anglerQuestsFinished;

		public int bartenderQuestLog;

		public bool downedDD2EventAnyDifficulty;

		public bool archery;

		public bool arcticDivingGear;

		public Item[] armor;

		public int armorPenetration;

		public float arrowDamage;

		public int attackCD;

		public bool autoActuator;

		public bool autoJump;

		public bool autoPaint;

		public bool babyFaceMonster;

		public sbyte back;

		public sbyte balloon;

		public Chest bank;

		public Chest bank2;

		public Chest bank3;

		public float basiliskCharge;

		public bool bee;

		public bool beetleBuff;

		public int beetleCountdown;

		public float beetleCounter;

		public bool beetleDefense;

		public int beetleFrame;

		public int beetleFrameCounter;

		public bool beetleOffense;

		public int beetleOrbs;

		public Vector2[] beetlePos;

		public Vector2[] beetleVel;

		public bool behindBackWall;

		public int bestOre;

		public bool blackBelt;

		public bool blackCat;

		public bool blackout;

		public bool bleed;

		public bool blind;

		public int blockRange;

		public bool blueFairy;

		public int body;

		public Rectangle bodyFrame;

		public double bodyFrameCounter;

		public Vector2 bodyPosition;

		public float bodyRotation;

		public Vector2 bodyVelocity;

		public bool boneArmor;

		public bool brainOfConfusion;

		public int breath;

		public int breathCD;

		public int breathMax;

		public bool brokenArmor;

		public bool[] buffImmune;

		public int[] buffTime;

		public int[] buffType;

		public int[] builderAccStatus;

		public float bulletDamage;

		public bool bunny;

		public bool burned;

		public bool calmed;

		public bool canCarpet;

		public bool canRocket;

		public bool carpet;

		public int carpetFrame;

		public float carpetFrameCounter;

		public int carpetTime;

		public bool cartFlip;

		public int cartRampTime;

		private int cBack;

		private int cBalloon;

		private int cBody;

		private int cCarpet;

		private int cFace;

		private int cFront;

		public int cGrapple;

		private int cHandOff;

		private int cHandOn;

		public int changeItem;

		public bool channel;

		public bool chaosState;

		public int cHead;

		public int chest;

		public int chestX;

		public int chestY;

		public bool chilled;

		public Player.SelectionRadial CircularRadial = new Player.SelectionRadial(Player.SelectionRadial.SelectionMode.RadialCircular);

		public int cLegs;

		public int cLight;

		public int cMinecart;

		public int cMount;

		public int cNeck;

		public bool coins;

		public bool coldDash;

		public bool companionCube;

		public bool confused;

		public bool controlDown;

		public bool controlHook;

		public bool controlInv;

		public bool controlJump;

		public bool controlLeft;

		public bool controlMap;

		public bool controlMount;

		public bool controlQuickHeal;

		public bool controlQuickMana;

		public bool controlRight;

		public bool controlSmart;

		public bool controlThrow;

		public bool controlTorch;

		public bool controlUp;

		public bool controlUseItem;

		public bool controlUseTile;

		public bool cordage;

		public int counterWeight;

		public int cPet;

		public bool cratePotion;

		public bool crimsonHeart;

		public bool crimsonRegen;

		public bool crystalLeaf;

		public static int crystalLeafDamage = 100;

		public static int crystalLeafKB = 10;

		public bool cSapling;

		public int cShield;

		public int cShoe;

		public int cWaist;

		public int cWings;

		public int cYorai;

		public bool dangerSense;

		public int dash;

		public int dashDelay;

		public int dashTime;

		public bool dazed;

		public bool dead;

		public static bool deadForGood = false;

		public bool DeadlySphereMinion;

		public static float defaultGravity = 0.4f;

		public const int defaultHeight = 42;

		public const int shadowMax = 3;

		public const int SHIELD_PARRY_DURATION = 20;

		public const int SHIELD_PARRY_DURATION_DRAWING_TWEAKER = 20;

		public const int SHIELD_PARRY_DAMAGE_BUFF_MULTIPLIER = 5;

		public static int defaultItemGrabRange = 38;

		public const int defaultWidth = 20;

		public bool defendedByPaladin;

		public bool delayUseItem;

		public bool detectCreature;

		public byte difficulty;

		public bool dino;

		public bool discount;

		public string displayedFishingInfo;

		public bool dJumpEffectBlizzard;

		public bool dJumpEffectCloud;

		public bool dJumpEffectFart;

		public bool dJumpEffectSail;

		public bool dJumpEffectSandstorm;

		public bool dJumpEffectUnicorn;

		public bool doubleJumpBlizzard;

		public bool doubleJumpCloud;

		public bool doubleJumpFart;

		public bool doubleJumpSail;

		public bool doubleJumpSandstorm;

		public bool doubleJumpUnicorn;

		public int[] doubleTapCardinalTimer;

		public Player.SelectionRadial DpadRadial = new Player.SelectionRadial(Player.SelectionRadial.SelectionMode.Dpad4);

		public int dpsDamage;

		public DateTime dpsEnd;

		public DateTime dpsLastHit;

		public DateTime dpsStart;

		public bool dpsStarted;

		public float drainBoost;

		public bool dd2Accessory;

		public bool dripping;

		public bool drippingSlime;

		public bool dryadWard;

		public Item[] dye;

		public bool eater;

		public bool editedChestName;

		public bool electrified;

		private static byte[] ENCRYPTION_KEY = new UnicodeEncoding().GetBytes("h3y_gUyZ");

		public float endurance;

		public bool enemySpawns;

		public int eocDash;

		public int eocHit;

		public bool extraAccessory;

		public int extraAccessorySlots;

		public int extraFall;

		public Color eyeColor;

		public bool eyeSpring;

		public sbyte face;

		public int fallStart;

		public int fallStart2;

		public bool findTreasure;

		public bool fireWalk;

		public int fishingSkill;

		public byte flameRingAlpha;

		public byte flameRingFrame;

		public float flameRingRot;

		public float flameRingScale;

		public bool flapSound;

		public int flyingPigChest;

		public bool forceMerman;

		public bool forceWerewolf;

		public sbyte front;

		public bool frostArmor;

		public bool frostBurn;

		public bool frozen;

		public float fullRotation;

		public Vector2 fullRotationOrigin;

		public int gem;

		public int gemCount;

		public float gfxOffY;

		public bool ghost;

		public float ghostDir;

		public float ghostDmg;

		public float ghostFade;

		public int ghostFrame;

		public int ghostFrameCounter;

		public bool ghostHeal;

		public bool ghostHurt;

		public bool gills;

		public bool GoingDownWithGrapple;

		public bool goldRing;

		public int grapCount;

		public int[] grappling;

		public bool gravControl;

		public bool gravControl2;

		public float gravDir;

		public float gravity;

		public bool greenFairy;

		public bool grinch;

		public bool gross;

		public int hair;

		public Color hairColor;

		public byte hairDye;

		public Color hairDyeColor;

		public float hairDyeVar;

		public Rectangle hairFrame;

		public sbyte handoff;

		public sbyte handon;

		public bool hasBanner;

		public bool hasPaladinShield;

		public bool hbLocked;

		public int head;

		public bool headcovered;

		public Rectangle headFrame;

		public double headFrameCounter;

		public Vector2 headPosition;

		public float headRotation;

		public Vector2 headVelocity;

		public int heldProj;

		public bool[] hideInfo = new bool[13];

		public bool hideMerman;

		public BitsByte hideMisc;

		public bool[] hideVisual;

		public bool hideWolf;

		public HitTile hitTile;

		public int[] holdDownCardinalTimer;

		public bool honey;

		public bool hornet;

		public bool hornetMinion;

		public bool hostile;

		public int HotbarOffset;

		public int[] hurtCooldowns;

		public bool iceBarrier;

		public byte iceBarrierFrame;

		public byte iceBarrierFrameCounter;

		public bool iceSkate;

		public bool ichor;

		public bool ignoreWater;

		public bool immune;

		public int immuneAlpha;

		public int immuneAlphaDirection;

		public int immuneTime;

		public bool immuneNoBlink;

		public bool impMinion;

		public bool inferno;

		public int infernoCounter;

		public bool InfoAccMechShowWires;

		public const int InitialAccSlotCount = 5;

		public Item[] inventory;

		public bool[] inventoryChestStack;

		public bool invis;

		public int itemAnimation;

		public int itemAnimationMax;

		public int itemFlameCount;

		public Vector2[] itemFlamePos;

		private static float itemGrabSpeed = 0.45f;

		private static float itemGrabSpeedMax = 4f;

		public int itemHeight;

		public Vector2 itemLocation;

		public float itemRotation;

		public int itemTime;

		public int itemWidth;

		public int jump;

		public bool jumpAgainBlizzard;

		public bool jumpAgainCloud;

		public bool jumpAgainFart;

		public bool jumpAgainSail;

		public bool jumpAgainSandstorm;

		public bool jumpAgainUnicorn;

		public bool jumpBoost;

		public static int jumpHeight = 15;

		public static float jumpSpeed = 5.01f;

		public float jumpSpeedBoost;

		public bool justJumped;

		public bool kbBuff;

		public bool kbGlove;

		public bool killClothier;

		public bool killGuide;

		public Vector2 lastBoost;

		public int lastChest;

		public int lastCreatureHit;

		public Vector2 lastDeathPostion;

		public DateTime lastDeathTime;

		public bool lastMouseInterface;

		public int lastPortalColorIndex;

		public static bool lastPound = true;

		public bool lastStoned;

		public int lastTileRangeX;

		public int lastTileRangeY;

		public int launcherWait;

		public int lavaCD;

		public bool lavaImmune;

		public int lavaMax;

		public bool lavaRose;

		public int lavaTime;

		public int leftTimer;

		public Rectangle legFrame;

		public double legFrameCounter;

		public Vector2 legPosition;

		public float legRotation;

		public int legs;

		public Vector2 legVelocity;

		public bool lifeForce;

		public bool lifeMagnet;

		public int lifeRegen;

		public int lifeRegenCount;

		public int lifeRegenTime;

		public float lifeSteal;

		public bool lightOrb;

		public bool lizard;

		public int loadStatus;

		public bool longInvince;

		public int lostCoins;

		public string lostCoinString;

		public bool loveStruck;

		public int magicCrit;

		public bool magicCuffs;

		public float magicDamage;

		public bool magicLantern;

		public bool magicQuiver;

		public bool magmaStone;

		private bool makeStrongBee;

		public float manaCost;

		public bool manaFlower;

		public bool manaMagnet;

		public int manaRegen;

		public int manaRegenBonus;

		public bool manaRegenBuff;

		public int manaRegenCount;

		public int manaRegenDelay;

		public int manaRegenDelayBonus;

		public bool manaSick;

		public static float manaSickLessDmg = 0.25f;

		public float manaSickReduction;

		public static int manaSickTime = 300;

		public static int manaSickTimeMax = 600;

		public bool mapAlphaDown;

		public bool mapAlphaUp;

		public bool mapFullScreen;

		public bool mapStyle;

		public bool mapZoomIn;

		public bool mapZoomOut;

		public const int maxBuffs = 22;

		public float maxFallSpeed;

		public int maxMinions;

		public float maxRegenDelay;

		public float maxRunSpeed;

		public const int maxSolarShields = 3;

		public int meleeCrit;

		public float meleeDamage;

		public byte meleeEnchant;

		public float meleeSpeed;

		public bool merman;

		public bool minecartLeft;

		public bool miniMinotaur;

		public float minionDamage;

		public float minionKB;

		public Vector2 MinionTargetPoint;

		public int MinionAttackTargetNPC;

		public int miscCounter;

		public Item[] miscDyes;

		public Item[] miscEquips;

		public const int miscSlotCart = 2;

		public const int miscSlotHook = 4;

		public const int miscSlotLight = 1;

		public const int miscSlotMount = 3;

		public const int miscSlotPet = 0;

		public int miscTimer;

		public bool moonLeech;

		public Mount mount;

		public float MountFishronSpecialCounter;

		public bool mouseInterface;

		public float moveSpeed;

		public static int nameLen = 20;

		public int nebulaCD;

		public int nebulaLevelDamage;

		public int nebulaLevelLife;

		public int nebulaLevelMana;

		public int nebulaManaCounter;

		public const int nebulaMaxLevel = 3;

		public sbyte neck;

		public bool netLife;

		public int netLifeTime;

		public bool netMana;

		public int netManaTime;

		public int netSkip;

		public bool nightVision;

		public bool noFallDmg;

		public bool noItems;

		public bool noKnockback;

		public int nonTorch;

		public int noThrow;

		public bool[] NPCBannerBuff;

		public bool[] npcTypeNoAggro;

		public int numMinions;

		public bool oldAdjHoney;

		public bool oldAdjLava;

		public bool[] oldAdjTile;

		public bool oldAdjWater;

		public int oldSelectItem;

		public bool onFire;

		public bool onFire2;

		public bool onFrostBurn;

		public bool onHitDodge;

		public bool onHitPetal;

		public bool onHitRegen;

		public bool onTrack;

		public bool onWrongGround;

		public bool outOfRange;

		public BitsByte ownedLargeGems;

		public int[] ownedProjectileCounts;

		public bool palladiumRegen;

		public bool panic;

		public Color pantsColor;

		public bool parrot;

		public bool penguin;

		public int petalTimer;

		public int phantasmTime;

		public float pickSpeed;

		public bool pirateMinion;

		public bool poisoned;

		public bool portalPhysicsFlag;

		public int potionDelay;

		public int potionDelayTime;

		public bool poundRelease;

		public bool powerrun;

		public bool pStone;

		public bool pulley;

		public byte pulleyDir;

		public int pulleyFrame;

		public float pulleyFrameCounter;

		public bool puppy;

		public bool pvpDeath;

		public bool pygmy;

		public Player.SelectionRadial QuicksRadial = new Player.SelectionRadial(Player.SelectionRadial.SelectionMode.RadialQuicks);

		public bool rabid;

		public int rangedCrit;

		public float rangedDamage;

		public bool raven;

		public bool redFairy;

		public bool releaseDown;

		public bool releaseHook;

		public bool releaseInventory;

		public bool releaseJump;

		public bool releaseLeft;

		public bool releaseMapFullscreen;

		public bool releaseMapStyle;

		public bool releaseMount;

		public bool releaseQuickHeal;

		public bool releaseQuickMana;

		public bool releaseRight;

		public bool releaseSmart;

		public bool releaseThrow;

		public bool releaseUp;

		public bool releaseUseItem;

		public bool releaseUseTile;

		public bool resistCold;

		public int respawnTimer;

		public int restorationDelayTime;

		public int reuseDelay;

		public int rightTimer;

		public int rocketBoots;

		public float rocketDamage;

		public int rocketDelay;

		public int rocketDelay2;

		public bool rocketFrame;

		public bool rocketRelease;

		public int rocketTime;

		public int rocketTimeMax;

		public int ropeCount;

		public bool rulerGrid;

		public bool rulerLine;

		public float runAcceleration;

		public float runSlowdown;

		public int runSoundDelay;

		public bool sailDash;

		public bool sandStorm;

		public bool sapling;

		public bool scope;

		public int selectedItem;

		public string setBonus;

		public bool setNebula;

		public bool setSolar;

		public bool setStardust;

		public bool setForbidden;

		public bool setForbiddenCooldownLocked;

		public bool setSquireT3;

		public bool setHuntressT3;

		public bool setApprenticeT3;

		public bool setMonkT3;

		public bool setSquireT2;

		public bool setHuntressT2;

		public bool setApprenticeT2;

		public bool setMonkT2;

		public int maxTurrets;

		public int maxTurretsOld;

		public bool setVortex;

		public float shadow;

		public int shadowCount;

		public int[] shadowDirection;

		public bool shadowDodge;

		public float shadowDodgeCount;

		public int shadowDodgeTimer;

		public int phantomPhoneixCounter;

		public Vector2[] shadowOrigin;

		public Vector2[] shadowPos;

		public float[] shadowRotation;

		public bool sharknadoMinion;

		public sbyte shield;

		public bool shinyStone;

		public Color shirtColor;

		public sbyte shoe;

		public Color shoeColor;

		public bool showItemIcon;

		public int showItemIcon2;

		public bool showItemIconR;

		public string showItemIconText;

		public bool showLastDeath;

		public bool shroomiteStealth;

		public int sign;

		public bool silence;

		public bool skeletron;

		public Color skinColor;

		public int skinVariant;

		public int slideDir;

		public bool sliding;

		public bool slime;

		public bool slippy;

		public bool slippy2;

		public bool sloping;

		public float slotsMinions;

		public bool slow;

		public bool slowFall;

		public bool snowman;

		public bool socialGhost;

		public bool socialIgnoreLight;

		public bool socialShadow;

		public int solarCounter;

		public bool solarDashConsumedFlare;

		public bool solarDashing;

		public Vector2[] solarShieldPos;

		public int solarShields;

		public Vector2[] solarShieldVel;

		public bool sonarPotion;

		public int soulDrain;

		public bool spaceGun;

		public bool spawnMax;

		public int SpawnX;

		public int SpawnY;

		public float[] speedSlice;

		public byte spelunkerTimer;

		public int[] spI;

		public bool spider;

		public bool spiderArmor;

		public bool spiderMinion;

		public int spikedBoots;

		public string[] spN;

		public bool sporeSac;

		public int[] spX;

		public int[] spY;

		public bool squashling;

		public bool petFlagDD2Gato;

		public bool petFlagDD2Ghost;

		public bool petFlagDD2Dragon;

		public bool stairFall;

		public bool starCloak;

		public bool stardustDragon;

		public bool stardustGuardian;

		public bool stardustMinion;

		public int statDefense;

		public int statLife;

		public int statLifeMax;

		public int statLifeMax2;

		public int statMana;

		public int statManaMax;

		public int statManaMax2;

		public float stealth;

		public int stealthTimer;

		public int step;

		public float stepSpeed;

		public bool sticky;

		public int stickyBreak;

		public bool stinky;

		public bool stoned;

		public static int StopMoneyTroughFromWorking = 3;

		public int stringColor;

		public bool strongBees;

		public byte suffocateDelay;

		public bool suffocating;

		public bool sunflower;

		public const int SupportedSlotsAccs = 7;

		public const int SupportedSlotsArmor = 3;

		public const int SupportedSlotSets = 10;

		public bool suspiciouslookingTentacle;

		public int swimTime;

		public int talkNPC;

		public int tankPet;

		public bool tankPetReset;

		public int taxMoney;

		public static int taxRate = 3600;

		public int taxTimer;

		public int team;

		public bool teleporting;

		public int teleportStyle;

		public float teleportTime;

		public float thorns;

		public bool thrownCost33;

		public bool thrownCost50;

		public int thrownCrit;

		public float thrownDamage;

		public float thrownVelocity;

		public bool tiki;

		public static int tileRangeX = 5;

		public static int tileRangeY = 4;

		public float tileSpeed;

		public static int tileTargetX;

		public static int tileTargetY;

		public bool tongued;

		public int toolTime;

		public List<Point> TouchedTiles;

		public float townNPCs;

		public float trackBoost;

		public bool trapDebuffSource;

		public bool witheredArmor;

		public bool witheredWeapon;

		public bool slowOgreSpit;

		public bool parryDamageBuff;

		public bool ballistaPanic;

		public Item trashItem;

		public bool truffle;

		public bool turtle;

		public bool turtleArmor;

		public bool turtleThorns;

		public bool twinsMinion;

		public bool UFOMinion;

		public Color underShirtColor;

		public bool venom;

		public bool vortexDebuff;

		public bool vortexStealthActive;

		public sbyte waist;

		public float wallSpeed;

		public bool waterWalk;

		public bool waterWalk2;

		public bool wearsRobe;

		public bool webbed;

		public bool noBuilding;

		public bool wellFed;

		public bool wereWolf;

		public byte wetSlime;

		public bool windPushed;

		public int wingFrame;

		public int wingFrameCounter;

		public int wings;

		public int wingsLogic;

		public float wingTime;

		public int wingTimeMax;

		public int wireOperationsCooldown;

		public bool wisp;

		public bool wolfAcc;

		public bool yoraiz0rDarkness;

		public int yoraiz0rEye;

		public bool yoyoGlove;

		public bool yoyoString;

		public bool zephyrfish;

		public BitsByte zone1;

		public BitsByte zone2;

		public BitsByte zone3;

		public BitsByte zone4;

		public int _funkytownCheckCD;

		public int _portalPhysicsTime;

		private int _quickGrappleCooldown;

		public bool hasRaisableShield;

		public bool shieldRaised;

		public int shieldParryTimeLeft;

		public int shield_parry_cooldown;

		public bool tileInteractAttempted;

		public bool tileInteractionHappened;

		public Vector2 MinionRestTargetPoint;

		public Player()
		{
			int[] array = new int[10];
			this.builderAccStatus = array;
			this.lostCoinString = "";
			this.NPCBannerBuff = new bool[257];
			this.extraAccessorySlots = 2;
			this.tankPet = -1;
			this.solarShieldPos = new Vector2[3];
			this.solarShieldVel = new Vector2[3];
			this.flameRingScale = 1f;
			this.beetlePos = new Vector2[3];
			this.beetleVel = new Vector2[3];
			this.itemFlamePos = new Vector2[7];
			this.lifeSteal = 99999f;
			this.gem = -1;
			this.carpetFrame = -1;
			this.maxMinions = 1;
			this.zone1 = 0;
			this.zone2 = 0;
			this.zone3 = 0;
			this.zone4 = 0;
			this.doubleTapCardinalTimer = new int[4];
			this.holdDownCardinalTimer = new int[4];
			this.speedSlice = new float[60];
			this.sign = -1;
			this.changeItem = -1;
			this.armor = new Item[20];
			this.dye = new Item[10];
			this.miscEquips = new Item[5];
			this.miscDyes = new Item[5];
			this.trashItem = new Item();
			this.ghostDir = 1f;
			this.buffType = new int[22];
			this.buffTime = new int[22];
			this.buffImmune = new bool[Main.maxBuffTypes];
			this.heldProj = -1;
			this.breathMax = 200;
			this.breath = 200;
			this.stealth = 1f;
			this.setBonus = "";
			this.inventory = new Item[59];
			this.inventoryChestStack = new bool[59];
			this.bank = new Chest(true);
			this.bank2 = new Chest(true);
			this.bank3 = new Chest(true);
			this.fullRotationOrigin = Vector2.Zero;
			this.nonTorch = -1;
			this.stepSpeed = 1f;
			this.head = -1;
			this.body = -1;
			this.legs = -1;
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
			this.hideVisual = new bool[10];
			this.hideMisc = 0;
			this.showItemIconText = "";
			this.shadowPos = new Vector2[3];
			this.shadowRotation = new float[3];
			this.shadowOrigin = new Vector2[3];
			this.shadowDirection = new int[3];
			this.manaCost = 1f;
			this.step = -1;
			this.statLifeMax = 100;
			this.statLifeMax2 = 100;
			this.statLife = 100;
			this.gravDir = 1f;
			this.lastBoost = Vector2.Zero;
			this.meleeCrit = 4;
			this.rangedCrit = 4;
			this.magicCrit = 4;
			this.thrownCrit = 4;
			this.meleeDamage = 1f;
			this.rangedDamage = 1f;
			this.thrownDamage = 1f;
			this.bulletDamage = 1f;
			this.arrowDamage = 1f;
			this.rocketDamage = 1f;
			this.magicDamage = 1f;
			this.minionDamage = 1f;
			this.meleeSpeed = 1f;
			this.thrownVelocity = 1f;
			this.moveSpeed = 1f;
			this.pickSpeed = 1f;
			this.wallSpeed = 1f;
			this.tileSpeed = 1f;
			this.SpawnX = -1;
			this.SpawnY = -1;
			this.spX = new int[200];
			this.spY = new int[200];
			this.spN = new string[200];
			this.spI = new int[200];
			this.gravity = Player.defaultGravity;
			this.maxFallSpeed = 10f;
			this.maxRunSpeed = 3f;
			this.runAcceleration = 0.08f;
			this.runSlowdown = 0.2f;
			this.adjTile = new bool[Main.maxTileSets];
			this.oldAdjTile = new bool[Main.maxTileSets];
			this.hairDyeColor = Color.Transparent;
			this.hairColor = new Color(215, 90, 55);
			this.skinColor = new Color(255, 125, 90);
			this.eyeColor = new Color(105, 90, 75);
			this.shirtColor = new Color(175, 165, 140);
			this.underShirtColor = new Color(160, 180, 215);
			this.pantsColor = new Color(255, 230, 175);
			this.shoeColor = new Color(160, 105, 60);
			this.lastCreatureHit = -1;
			this.bestOre = -1;
			this.displayedFishingInfo = "";
			this.grappling = new int[20];
			this.rocketTimeMax = 7;
			this.maxTurrets = 1;
			this.maxTurretsOld = 1;
			this.flyingPigChest = -1;
			this.chest = -1;
			this.talkNPC = -1;
			this.potionDelayTime = Item.potionDelay;
			this.restorationDelayTime = Item.restorationDelay;
			this.ownedProjectileCounts = new int[Main.maxProjectileTypes];
			this.npcTypeNoAggro = new bool[Main.maxNPCTypes];
			this.MinionTargetPoint = Vector2.Zero;
			this.MinionAttackTargetNPC = -1;
			this.TouchedTiles = new List<Point>();
			int[] array2 = new int[2];
			this.hurtCooldowns = array2;
			this.width = 20;
			this.height = 42;
			this.name = string.Empty;
			for (int i = 0; i < 59; i++)
			{
				if (i < this.armor.Length)
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
				this.bank3.item[j] = new Item();
				this.bank3.item[j].name = "";
			}
			for (int k = 0; k < this.dye.Length; k++)
			{
				this.dye[k] = new Item();
			}
			for (int l = 0; l < this.miscEquips.Length; l++)
			{
				this.miscEquips[l] = new Item();
			}
			for (int m = 0; m < this.miscDyes.Length; m++)
			{
				this.miscDyes[m] = new Item();
			}
			this.trashItem = new Item();
			this.grappling[0] = -1;
			this.inventory[0].SetDefaults("Copper Shortsword");
			this.inventory[1].SetDefaults("Copper Pickaxe");
			this.inventory[2].SetDefaults("Copper Axe");
			this.statManaMax = 20;
			this.extraAccessory = false;
			if (Main.cEd)
			{
				this.inventory[3].SetDefaults(603, false);
			}
			for (int n = 0; n < Main.maxTileSets; n++)
			{
				this.adjTile[n] = false;
				this.oldAdjTile[n] = false;
			}
			this.hitTile = new HitTile();
			this.mount = new Mount();
		}

		public void AddBuff(int type, int time1, bool quiet = true)
		{
			if (this.buffImmune[type])
			{
				return;
			}
			int num = time1;
			if (Main.expertMode && this.whoAmI == Main.myPlayer && (type == 20 || type == 22 || type == 23 || type == 24 || type == 30 || type == 31 || type == 32 || type == 33 || type == 35 || type == 36 || type == 39 || type == 44 || type == 46 || type == 47 || type == 69 || type == 70 || type == 80))
			{
				num = (int)(Main.expertDebuffTime * (float)num);
			}
			if (!quiet && Main.netMode == 1)
			{
				bool flag = true;
				for (int i = 0; i < 22; i++)
				{
					if (this.buffType[i] == type)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					NetMessage.SendData(55, -1, -1, "", this.whoAmI, (float)type, (float)num, 0f, 0, 0, 0);
				}
			}
			int num2 = -1;
			for (int j = 0; j < 22; j++)
			{
				if (this.buffType[j] == type)
				{
					if (type == 94)
					{
						this.buffTime[j] += num;
						if (this.buffTime[j] > Player.manaSickTimeMax)
						{
							this.buffTime[j] = Player.manaSickTimeMax;
							return;
						}
					}
					else if (this.buffTime[j] < num)
					{
						this.buffTime[j] = num;
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
			while (num2 == -1)
			{
				int num3 = -1;
				for (int l = 0; l < 22; l++)
				{
					if (!Main.debuff[this.buffType[l]])
					{
						num3 = l;
						break;
					}
				}
				if (num3 == -1)
				{
					return;
				}
				for (int m = num3; m < 22; m++)
				{
					if (this.buffType[m] == 0)
					{
						num2 = m;
						break;
					}
				}
				if (num2 == -1)
				{
					this.DelBuff(num3);
				}
			}
			this.buffType[num2] = type;
			this.buffTime[num2] = num;
			if (Main.meleeBuff[type])
			{
				for (int n = 0; n < 22; n++)
				{
					if (n != num2 && Main.meleeBuff[this.buffType[n]])
					{
						this.DelBuff(n);
					}
				}
			}
		}

		public void addDPS(int dmg)
		{
			if (this.dpsStarted)
			{
				this.dpsLastHit = DateTime.Now;
				this.dpsDamage += dmg;
				this.dpsEnd = DateTime.Now;
				return;
			}
			this.dpsStarted = true;
			this.dpsStart = DateTime.Now;
			this.dpsEnd = DateTime.Now;
			this.dpsLastHit = DateTime.Now;
			this.dpsDamage = dmg;
		}

		public void AdjTiles()
		{
			int num = 4;
			int num2 = 3;
			for (int i = 0; i < Main.maxTileSets; i++)
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
						if (Main.tile[j, k].type == 354)
						{
							this.adjTile[14] = true;
						}
						if (Main.tile[j, k].type == 355)
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
				for (int l = 0; l < Main.maxTileSets; l++)
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

		private void ApplyAnimation(Item sItem)
		{
		}

		public void ApplyDamageToNPC(NPC npc, int damage, float knockback, int direction, bool crit)
		{
			npc.StrikeNPC(damage, knockback, direction, crit, false, false);
			if (Main.netMode != 0)
			{
				NetMessage.SendData(28, -1, -1, "", npc.whoAmI, (float)damage, knockback, (float)direction, crit.ToInt(), 0, 0);
			}
			int num = Item.NPCtoBanner(npc.BannerID());
			if (num >= 0)
			{
				this.lastCreatureHit = num;
			}
		}

		public int ArmorSetDye()
		{
			switch (Main.rand.Next(3))
			{
				case 0:
					return this.cHead;
				case 1:
					return this.cBody;
				case 2:
					return this.cLegs;
				default:
					return this.cBody;
			}
		}

		public int beeDamage(int dmg)
		{
			if (this.makeStrongBee)
			{
				return dmg + Main.rand.Next(1, 4);
			}
			return dmg + Main.rand.Next(2);
		}

		public float beeKB(float KB)
		{
			if (this.makeStrongBee)
			{
				return 0.5f + KB * 1.1f;
			}
			return KB;
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
			}
			if (this.position.Y > Main.bottomWorld - 640f - 150f - (float)this.height)
			{
				AchievementsHelper.HandleSpecialEvent(this, 10);
			}
		}

		public bool BuyItem(int price, int customCurrency = -1)
		{
			if (customCurrency != -1)
			{
				return CustomCurrencyManager.BuyItem(this, price, customCurrency);
			}
			bool flag;
			long num = Utils.CoinsCount(out flag, this.inventory, new int[]
			{
				58,
				57,
				56,
				55,
				54
			});
			long num2 = Utils.CoinsCount(out flag, this.bank.item, new int[0]);
			long num3 = Utils.CoinsCount(out flag, this.bank2.item, new int[0]);
			long num4 = Utils.CoinsCount(out flag, this.bank3.item, new int[0]);
			long num5 = Utils.CoinsCombineStacks(out flag, new long[]
			{
				num,
				num2,
				num3,
				num4
			});
			if (num5 < (long)price)
			{
				return false;
			}
			List<Item[]> list = new List<Item[]>();
			Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
			List<Point> list2 = new List<Point>();
			List<Point> list3 = new List<Point>();
			List<Point> list4 = new List<Point>();
			List<Point> list5 = new List<Point>();
			List<Point> list6 = new List<Point>();
			list.Add(this.inventory);
			list.Add(this.bank.item);
			list.Add(this.bank2.item);
			list.Add(this.bank3.item);
			for (int i = 0; i < list.Count; i++)
			{
				dictionary[i] = new List<int>();
			}
			dictionary[0] = new List<int>
			{
				58,
				57,
				56,
				55,
				54
			};
			for (int j = 0; j < list.Count; j++)
			{
				for (int k = 0; k < list[j].Length; k++)
				{
					if (!dictionary[j].Contains(k) && list[j][k].type >= 71 && list[j][k].type <= 74)
					{
						list3.Add(new Point(j, k));
					}
				}
			}
			int num6 = 0;
			for (int l = list[num6].Length - 1; l >= 0; l--)
			{
				if (!dictionary[num6].Contains(l) && (list[num6][l].type == 0 || list[num6][l].stack == 0))
				{
					list2.Add(new Point(num6, l));
				}
			}
			num6 = 1;
			for (int m = list[num6].Length - 1; m >= 0; m--)
			{
				if (!dictionary[num6].Contains(m) && (list[num6][m].type == 0 || list[num6][m].stack == 0))
				{
					list4.Add(new Point(num6, m));
				}
			}
			num6 = 2;
			for (int n = list[num6].Length - 1; n >= 0; n--)
			{
				if (!dictionary[num6].Contains(n) && (list[num6][n].type == 0 || list[num6][n].stack == 0))
				{
					list5.Add(new Point(num6, n));
				}
			}
			num6 = 3;
			for (int num7 = list[num6].Length - 1; num7 >= 0; num7--)
			{
				if (!dictionary[num6].Contains(num7) && (list[num6][num7].type == 0 || list[num6][num7].stack == 0))
				{
					list6.Add(new Point(num6, num7));
				}
			}
			bool flag2 = Player.TryPurchasing(price, list, list3, list2, list4, list5, list6);
			return !flag2;
		}
		private static bool TryPurchasing(int price, List<Item[]> inv, List<Point> slotCoins, List<Point> slotsEmpty, List<Point> slotEmptyBank, List<Point> slotEmptyBank2, List<Point> slotEmptyBank3)
		{
			long num = (long)price;
			Dictionary<Point, Item> dictionary = new Dictionary<Point, Item>();
			bool result = false;
			while (num > 0L)
			{
				long num2 = 1000000L;
				for (int i = 0; i < 4; i++)
				{
					if (num >= num2)
					{
						foreach (Point current in slotCoins)
						{
							if (inv[current.X][current.Y].type == 74 - i)
							{
								long num3 = num / num2;
								dictionary[current] = inv[current.X][current.Y].Clone();
								if (num3 < (long)inv[current.X][current.Y].stack)
								{
									inv[current.X][current.Y].stack -= (int)num3;
								}
								else
								{
									inv[current.X][current.Y].SetDefaults(0, false);
									slotsEmpty.Add(current);
								}
								num -= num2 * (long)(dictionary[current].stack - inv[current.X][current.Y].stack);
							}
						}
					}
					num2 /= 100L;
				}
				if (num > 0L)
				{
					if (slotsEmpty.Count <= 0)
					{
						foreach (KeyValuePair<Point, Item> current2 in dictionary)
						{
							inv[current2.Key.X][current2.Key.Y] = current2.Value.Clone();
						}
						result = true;
						break;
					}
					slotsEmpty.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
					Point item = new Point(-1, -1);
					for (int j = 0; j < inv.Count; j++)
					{
						num2 = 10000L;
						for (int k = 0; k < 3; k++)
						{
							if (num >= num2)
							{
								foreach (Point current3 in slotCoins)
								{
									if (current3.X == j && inv[current3.X][current3.Y].type == 74 - k && inv[current3.X][current3.Y].stack >= 1)
									{
										List<Point> list = slotsEmpty;
										if (j == 1 && slotEmptyBank.Count > 0)
										{
											list = slotEmptyBank;
										}
										if (j == 2 && slotEmptyBank2.Count > 0)
										{
											list = slotEmptyBank2;
										}
										if (--inv[current3.X][current3.Y].stack <= 0)
										{
											inv[current3.X][current3.Y].SetDefaults(0, false);
											list.Add(current3);
										}
										dictionary[list[0]] = inv[list[0].X][list[0].Y].Clone();
										inv[list[0].X][list[0].Y].SetDefaults(73 - k, false);
										inv[list[0].X][list[0].Y].stack = 100;
										item = list[0];
										list.RemoveAt(0);
										break;
									}
								}
							}
							if (item.X != -1 || item.Y != -1)
							{
								break;
							}
							num2 /= 100L;
						}
						for (int l = 0; l < 2; l++)
						{
							if (item.X == -1 && item.Y == -1)
							{
								foreach (Point current4 in slotCoins)
								{
									if (current4.X == j && inv[current4.X][current4.Y].type == 73 + l && inv[current4.X][current4.Y].stack >= 1)
									{
										List<Point> list2 = slotsEmpty;
										if (j == 1 && slotEmptyBank.Count > 0)
										{
											list2 = slotEmptyBank;
										}
										if (j == 2 && slotEmptyBank2.Count > 0)
										{
											list2 = slotEmptyBank2;
										}
										if (j == 3 && slotEmptyBank3.Count > 0)
										{
											list2 = slotEmptyBank3;
										}
										if (--inv[current4.X][current4.Y].stack <= 0)
										{
											inv[current4.X][current4.Y].SetDefaults(0, false);
											list2.Add(current4);
										}
										dictionary[list2[0]] = inv[list2[0].X][list2[0].Y].Clone();
										inv[list2[0].X][list2[0].Y].SetDefaults(72 + l, false);
										inv[list2[0].X][list2[0].Y].stack = 100;
										item = list2[0];
										list2.RemoveAt(0);
										break;
									}
								}
							}
						}
						if (item.X != -1 && item.Y != -1)
						{
							slotCoins.Add(item);
							break;
						}
					}
					slotsEmpty.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
					slotEmptyBank.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
					slotEmptyBank2.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
					slotEmptyBank3.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
				}
			}
			return result;
		}

		public bool BuyItemOld(int price)
		{
			if (price == 0)
			{
				return true;
			}
			long num = 0L;
			Item[] array = new Item[54];
			for (int i = 0; i < 54; i++)
			{
				array[i] = new Item();
				array[i] = this.inventory[i].Clone();
				if (this.inventory[i].type == 71)
				{
					num += (long)this.inventory[i].stack;
				}
				if (this.inventory[i].type == 72)
				{
					num += (long)(this.inventory[i].stack * 100);
				}
				if (this.inventory[i].type == 73)
				{
					num += (long)(this.inventory[i].stack * 10000);
				}
				if (this.inventory[i].type == 74)
				{
					num += (long)(this.inventory[i].stack * 1000000);
				}
			}
			if (num >= (long)price)
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

		public bool CanHit(Entity ent)
		{
			return Collision.CanHit(this.position, this.width, this.height, ent.position, ent.width, ent.height) || Collision.CanHitLine(base.Center + new Vector2((float)(this.direction * this.width / 2), this.gravDir * (float)(-(float)this.height) / 3f), 0, 0, ent.Center + new Vector2(0f, (float)(-(float)ent.height / 3)), 0, 0) || Collision.CanHitLine(base.Center + new Vector2((float)(this.direction * this.width / 2), this.gravDir * (float)(-(float)this.height) / 3f), 0, 0, ent.Center, 0, 0) || Collision.CanHitLine(base.Center + new Vector2((float)(this.direction * this.width / 2), 0f), 0, 0, ent.Center + new Vector2(0f, (float)(ent.height / 3)), 0, 0);
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
					this.carpetTime--;
					float num = this.gravity;
					if (this.gravDir == 1f && this.velocity.Y > -num)
					{
						this.velocity.Y = -(num + 1E-06f);
					}
					else if (this.gravDir == -1f && this.velocity.Y < num)
					{
						this.velocity.Y = num + 1E-06f;
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
			int num = (int)(this.position.X + (float)(this.width / 2)) / 16;
			int num2 = num * 16 + 8 - this.width / 2;
			if (!Collision.SolidCollision(new Vector2((float)num2, this.position.Y), this.width, this.height))
			{
				if (this.whoAmI == Main.myPlayer)
				{
					Main.cameraX = Main.cameraX + this.position.X - (float)num2;
				}
				this.pulleyDir = 1;
				this.position.X = (float)num2;
				this.direction = dir;
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
					int num = (int)((this.position.X + (float)(this.width / 2) + (float)(6 * this.direction)) / 16f);
					int num2 = 0;
					if (this.gravDir == -1f)
					{
						num2 = this.height;
					}
					int num3 = (int)((this.position.Y + (float)num2 - 44f * this.gravDir) / 16f);
					if (Main.tile[num, num3].liquid < 128)
					{
						if (Main.tile[num, num3] == null)
						{
							Main.tile[num, num3] = new Tile();
						}
						if (!Main.tile[num, num3].active() || !Main.tileSolid[(int)Main.tile[num, num3].type] || Main.tileSolidTop[(int)Main.tile[num, num3].type])
						{
							flag = false;
						}
					}
				}
				catch
				{
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
				if (flag)
				{
					this.breathCD++;
					int num4 = 7;
					if (this.inventory[this.selectedItem].type == 186)
					{
						num4 *= 2;
					}
					if (this.accDivingHelm)
					{
						num4 *= 4;
					}
					if (this.breathCD >= num4)
					{
						this.breathCD = 0;
						this.breath--;
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
			if (flag && Main.rand.Next(20) == 0 && !this.lavaWet && !this.honeyWet)
			{
				int num5 = 0;
				if (this.gravDir == -1f)
				{
					num5 += this.height - 12;
				}
			}
		}

		public void CheckIceBreak()
		{
			if (this.velocity.Y > 7f)
			{
				Vector2 vector = this.position + this.velocity;
				int num = (int)(vector.X / 16f);
				int num2 = (int)((vector.X + (float)this.width) / 16f);
				int num3 = (int)((this.position.Y + (float)this.height + 1f) / 16f);
				for (int i = num; i <= num2; i++)
				{
					for (int j = num3; j <= num3 + 1; j++)
					{
						if (Main.tile[i, j].nactive() && Main.tile[i, j].type == 162 && !WorldGen.SolidTile(i, j - 1))
						{
							WorldGen.KillTile(i, j, false, false, false);
							if (Main.netMode == 1)
							{
								NetMessage.SendData(17, -1, -1, "", 0, (float)i, (float)j, 0f, 0, 0, 0);
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
					this.statMana -= num;
				}
				return true;
			}
			if (!this.manaFlower || blockQuickMana)
			{
				return false;
			}
			this.QuickMana();
			if (this.statMana >= num)
			{
				if (pay)
				{
					this.statMana -= num;
				}
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
						Main.NewText("Your bed is obstructed.", 255, 240, 20, false);
						return false;
					}
				}
			}
			return WorldGen.StartRoomCheck(x, y - 1);
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
			Player player = new Player();
			player.zone1 = this.zone1;
			player.zone2 = this.zone2;
			player.zone3 = this.zone3;
			player.zone4 = this.zone4;
			player.extraAccessory = this.extraAccessory;
			player.MinionTargetPoint = this.MinionTargetPoint;
			player.MinionAttackTargetNPC = this.MinionAttackTargetNPC;
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
			player.hideMisc = this.hideMisc;
			for (int i = 0; i < 59; i++)
			{
				player.inventory[i] = this.inventory[i].Clone();
				if (i < this.armor.Length)
				{
					player.armor[i] = this.armor[i].Clone();
				}
				if (i < this.dye.Length)
				{
					player.dye[i] = this.dye[i].Clone();
				}
				if (i < this.miscEquips.Length)
				{
					player.miscEquips[i] = this.miscEquips[i].Clone();
				}
				if (i < this.miscDyes.Length)
				{
					player.miscDyes[i] = this.miscDyes[i].Clone();
				}
				if (i < this.bank.item.Length)
				{
					player.bank.item[i] = this.bank.item[i].Clone();
				}
				if (i < this.bank2.item.Length)
				{
					player.bank2.item[i] = this.bank2.item[i].Clone();
				}
				if (i < this.bank3.item.Length)
				{
					player.bank3.item[i] = this.bank3.item[i].Clone();
				}
			}
			player.trashItem = this.trashItem.Clone();
			for (int j = 0; j < 22; j++)
			{
				player.buffType[j] = this.buffType[j];
				player.buffTime[j] = this.buffTime[j];
			}
			this.DpadRadial.CopyTo(player.DpadRadial);
			this.CircularRadial.CopyTo(player.CircularRadial);
			return player;
		}

		public object Clone()
		{
			return base.MemberwiseClone();
		}

		public void CollectTaxes()
		{
			int num = Item.buyPrice(0, 0, 0, 50);
			int num2 = Item.buyPrice(0, 10, 0, 0);
			if (!NPC.taxCollector)
			{
				return;
			}
			if (this.taxMoney >= num2)
			{
				return;
			}
			int num3 = 0;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && !Main.npc[i].homeless && NPC.TypeToNum(Main.npc[i].type) > 0)
				{
					num3++;
				}
			}
			this.taxMoney += num * num3;
			if (this.taxMoney > num2)
			{
				this.taxMoney = num2;
			}
		}
		private int CollideWithNPCs(Rectangle myRect, float Damage, float Knockback, int NPCImmuneTime, int PlayerImmuneTime)
		{
			int num = 0;
			for (int i = 0; i < 200; i++)
			{
				NPC nPC = Main.npc[i];
				if (nPC.active && !nPC.dontTakeDamage && !nPC.friendly && nPC.immune[this.whoAmI] == 0)
				{
					Rectangle rect = nPC.getRect();
					if (myRect.Intersects(rect) && (nPC.noTileCollide || Collision.CanHit(this.position, this.width, this.height, nPC.position, nPC.width, nPC.height)))
					{
						int direction = this.direction;
						if (this.velocity.X < 0f)
						{
							direction = -1;
						}
						if (this.velocity.X > 0f)
						{
							direction = 1;
						}
						if (this.whoAmI == Main.myPlayer)
						{
							this.ApplyDamageToNPC(nPC, (int)Damage, Knockback, direction, false);
						}
						nPC.immune[this.whoAmI] = NPCImmuneTime;
						this.immune = true;
						this.immuneTime = PlayerImmuneTime;
						num++;
						break;
					}
				}
			}
			return num;
		}
		public bool consumeItem(int type)
		{
			for (int i = 0; i < 58; i++)
			{
				if (this.inventory[i].stack > 0 && this.inventory[i].type == type)
				{
					this.inventory[i].stack--;
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
			this.solarShields--;
			for (int i = 0; i < 22; i++)
			{
				if (this.buffType[i] >= 170 && this.buffType[i] <= 172)
				{
					this.DelBuff(i);
				}
			}
			if (this.solarShields > 0)
			{
				this.AddBuff(170 + this.solarShields - 1, 5, false);
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
		private void CommonPetBuffHandle(int buffIndex, ref bool petBool, int petProjID)
		{
			this.buffTime[buffIndex] = 18000;
			petBool = true;
			bool flag = true;
			if (this.ownedProjectileCounts[petProjID] > 0)
			{
				flag = false;
			}
			if (flag && this.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, petProjID, 0, 0f, this.whoAmI, 0f, 0f);
			}
		}
		public void Counterweight(Vector2 hitPos, int dmg, float kb)
		{
			if (!this.yoyoGlove && this.counterWeight <= 0)
			{
				return;
			}
			int num = -1;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < 1000; i++)
			{
				if (Main.projectile[i].active && Main.projectile[i].owner == this.whoAmI)
				{
					if (Main.projectile[i].counterweight)
					{
						num3++;
					}
					else if (Main.projectile[i].aiStyle == 99)
					{
						num2++;
						num = i;
					}
				}
			}
			if (this.yoyoGlove && num2 < 2)
			{
				if (num >= 0)
				{
					Vector2 value = hitPos - base.Center;
					value.Normalize();
					value *= 16f;
					Projectile.NewProjectile(base.Center.X, base.Center.Y, value.X, value.Y, Main.projectile[num].type, Main.projectile[num].damage, Main.projectile[num].knockBack, this.whoAmI, 1f, 0f);
					return;
				}
			}
			else if (num3 < num2)
			{
				Vector2 value2 = hitPos - base.Center;
				value2.Normalize();
				value2 *= 16f;
				float knockBack = (kb + 6f) / 2f;
				if (num3 > 0)
				{
					Projectile.NewProjectile(base.Center.X, base.Center.Y, value2.X, value2.Y, this.counterWeight, (int)((double)dmg * 0.8), knockBack, this.whoAmI, 1f, 0f);
					return;
				}
				Projectile.NewProjectile(base.Center.X, base.Center.Y, value2.X, value2.Y, this.counterWeight, (int)((double)dmg * 0.8), knockBack, this.whoAmI, 0f, 0f);
			}
		}

		public void DashMovement()
		{
			if (this.dash == 2 && this.eocDash > 0)
			{
				if (this.eocHit < 0)
				{
					Rectangle rectangle = new Rectangle((int)((double)this.position.X + (double)this.velocity.X * 0.5 - 4.0), (int)((double)this.position.Y + (double)this.velocity.Y * 0.5 - 4.0), this.width + 8, this.height + 8);
					for (int i = 0; i < 200; i++)
					{
						if (Main.npc[i].active && !Main.npc[i].dontTakeDamage && !Main.npc[i].friendly)
						{
							NPC nPC = Main.npc[i];
							Rectangle rect = nPC.getRect();
							if (rectangle.Intersects(rect) && (nPC.noTileCollide || this.CanHit(nPC)))
							{
								float num = 30f * this.meleeDamage;
								float num2 = 9f;
								bool crit = false;
								if (this.kbGlove)
								{
									num2 *= 2f;
								}
								if (this.kbBuff)
								{
									num2 *= 1.5f;
								}
								if (Main.rand.Next(100) < this.meleeCrit)
								{
									crit = true;
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
									this.ApplyDamageToNPC(nPC, (int)num, num2, num3, crit);
								}
								this.eocDash = 10;
								this.dashDelay = 30;
								this.velocity.X = (float)(-(float)num3 * 9);
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
				Rectangle rectangle2 = new Rectangle((int)((double)this.position.X + (double)this.velocity.X * 0.5 - 4.0), (int)((double)this.position.Y + (double)this.velocity.Y * 0.5 - 4.0), this.width + 8, this.height + 8);
				for (int j = 0; j < 200; j++)
				{
					if (Main.npc[j].active && !Main.npc[j].dontTakeDamage && !Main.npc[j].friendly && Main.npc[j].immune[this.whoAmI] <= 0)
					{
						NPC nPC2 = Main.npc[j];
						Rectangle rect2 = nPC2.getRect();
						if (rectangle2.Intersects(rect2) && (nPC2.noTileCollide || this.CanHit(nPC2)))
						{
							if (!this.solarDashConsumedFlare)
							{
								this.solarDashConsumedFlare = true;
								this.ConsumeSolarFlare();
							}
							float num4 = 150f * this.meleeDamage;
							float num5 = 9f;
							bool crit2 = false;
							if (this.kbGlove)
							{
								num5 *= 2f;
							}
							if (this.kbBuff)
							{
								num5 *= 1.5f;
							}
							if (Main.rand.Next(100) < this.meleeCrit)
							{
								crit2 = true;
							}
							int direction = this.direction;
							if (this.velocity.X < 0f)
							{
								direction = -1;
							}
							if (this.velocity.X > 0f)
							{
								direction = 1;
							}
							if (this.whoAmI == Main.myPlayer)
							{
								this.ApplyDamageToNPC(nPC2, (int)num4, num5, direction, crit2);
								int num6 = Projectile.NewProjectile(base.Center.X, base.Center.Y, 0f, 0f, 608, 150, 15f, Main.myPlayer, 0f, 0f);
								Main.projectile[num6].Kill();
							}
							nPC2.immune[this.whoAmI] = 6;
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
					this.eocDash--;
				}
				if (this.eocDash == 0)
				{
					this.eocHit = -1;
				}
				this.dashDelay--;
				return;
			}
			if (this.dashDelay < 0)
			{
				float num7 = 12f;
				float num8 = 0.992f;
				float num9 = Math.Max(this.accRunSpeed, this.maxRunSpeed);
				float num10 = 0.96f;
				int num11 = 20;
				if (this.dash == 2)
				{
					num8 = 0.985f;
					num10 = 0.94f;
					num11 = 30;
				}
				else if (this.dash == 3)
				{
					num7 = 14f;
					num8 = 0.985f;
					num10 = 0.94f;
					num11 = 20;
				}
				else if (this.dash == 4)
				{
					num8 = 0.985f;
					num10 = 0.94f;
					num11 = 20;
				}
				if (this.dash > 0)
				{
					this.vortexStealthActive = false;
					if (this.velocity.X > num7 || this.velocity.X < -num7)
					{
						this.velocity.X = this.velocity.X * num8;
						return;
					}
					if (this.velocity.X > num9 || this.velocity.X < -num9)
					{
						this.velocity.X = this.velocity.X * num10;
						return;
					}
					this.dashDelay = num11;
					if (this.velocity.X < 0f)
					{
						this.velocity.X = -num9;
						return;
					}
					if (this.velocity.X > 0f)
					{
						this.velocity.X = num9;
						return;
					}
				}
			}
			else if (this.dash > 0 && !this.mount.Active)
			{
				if (this.dash == 1)
				{
					int num16 = 0;
					bool flag = false;
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
							num16 = 1;
							flag = true;
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
							num16 = -1;
							flag = true;
							this.dashTime = 0;
						}
						else
						{
							this.dashTime = -15;
						}
					}
					if (flag)
					{
						this.velocity.X = 16.9f * (float)num16;
						Point point = (base.Center + new Vector2((float)(num16 * this.width / 2 + 2), this.gravDir * (float)(-(float)this.height) / 2f + this.gravDir * 2f)).ToTileCoordinates();
						Point point2 = (base.Center + new Vector2((float)(num16 * this.width / 2 + 2), 0f)).ToTileCoordinates();
						if (WorldGen.SolidOrSlopedTile(point.X, point.Y) || WorldGen.SolidOrSlopedTile(point2.X, point2.Y))
						{
							this.velocity.X = this.velocity.X / 2f;
						}
						this.dashDelay = -1;
						return;
					}
				}
				else if (this.dash == 2)
				{
					int num20 = 0;
					bool flag2 = false;
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
							num20 = 1;
							flag2 = true;
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
							num20 = -1;
							flag2 = true;
							this.dashTime = 0;
						}
						else
						{
							this.dashTime = -15;
						}
					}
					if (flag2)
					{
						this.velocity.X = 14.5f * (float)num20;
						Point point3 = (base.Center + new Vector2((float)(num20 * this.width / 2 + 2), this.gravDir * (float)(-(float)this.height) / 2f + this.gravDir * 2f)).ToTileCoordinates();
						Point point4 = (base.Center + new Vector2((float)(num20 * this.width / 2 + 2), 0f)).ToTileCoordinates();
						if (WorldGen.SolidOrSlopedTile(point3.X, point3.Y) || WorldGen.SolidOrSlopedTile(point4.X, point4.Y))
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
					int num23 = 0;
					bool flag3 = false;
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
							num23 = 1;
							flag3 = true;
							this.dashTime = 0;
							this.solarDashing = true;
							this.solarDashConsumedFlare = false;
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
							num23 = -1;
							flag3 = true;
							this.dashTime = 0;
							this.solarDashing = true;
							this.solarDashConsumedFlare = false;
						}
						else
						{
							this.dashTime = -15;
						}
					}
					if (flag3)
					{
						this.velocity.X = 21.9f * (float)num23;
						Point point5 = (base.Center + new Vector2((float)(num23 * this.width / 2 + 2), this.gravDir * (float)(-(float)this.height) / 2f + this.gravDir * 2f)).ToTileCoordinates();
						Point point6 = (base.Center + new Vector2((float)(num23 * this.width / 2 + 2), 0f)).ToTileCoordinates();
						if (WorldGen.SolidOrSlopedTile(point5.X, point5.Y) || WorldGen.SolidOrSlopedTile(point6.X, point6.Y))
						{
							this.velocity.X = this.velocity.X / 2f;
						}
						this.dashDelay = -1;
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

		public void DoubleJumpVisuals()
		{
			if (this.dJumpEffectCloud && this.doubleJumpCloud && !this.jumpAgainCloud && (this.jumpAgainSandstorm || !this.doubleJumpSandstorm) && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
			{
				int num = this.height;
				if (this.gravDir == -1f)
				{
					num = -6;
				}
			}
			if (this.dJumpEffectSandstorm && this.doubleJumpSandstorm && !this.jumpAgainSandstorm && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
			{
				int num3 = this.height;
				if (this.gravDir == -1f)
				{
					num3 = -6;
				}
				float num4 = ((float)this.jump / 75f + 1f) / 2f;
				this.sandStorm = true;
			}
			if (this.dJumpEffectFart && this.doubleJumpFart && !this.jumpAgainFart && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
			{
				int num7 = this.height;
				if (this.gravDir == -1f)
				{
					num7 = -6;
				}
			}
			if (this.dJumpEffectSail && this.doubleJumpSail && !this.jumpAgainSail && ((this.gravDir == 1f && this.velocity.Y < 1f) || (this.gravDir == -1f && this.velocity.Y > 1f)))
			{
				int num9 = 1;
				if (this.jump > 0)
				{
					num9 = 2;
				}
				int num10 = this.height - 6;
				if (this.gravDir == -1f)
				{
					num10 = 6;
				}
			}
			if (this.dJumpEffectBlizzard && this.doubleJumpBlizzard && !this.jumpAgainBlizzard && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)))
			{
				int num12 = this.height - 6;
				if (this.gravDir == -1f)
				{
					num12 = 6;
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
					int num2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[i].type, 1, false, 0, false, false);
					int num3 = this.inventory[i].stack / 2;
					if (Main.expertMode)
					{
						num3 = (int)((double)this.inventory[i].stack * 0.25);
					}
					num3 = this.inventory[i].stack - num3;
					this.inventory[i].stack -= num3;
					if (this.inventory[i].type == 71)
					{
						num += num3;
					}
					if (this.inventory[i].type == 72)
					{
						num += num3 * 100;
					}
					if (this.inventory[i].type == 73)
					{
						num += num3 * 10000;
					}
					if (this.inventory[i].type == 74)
					{
						num += num3 * 1000000;
					}
					if (this.inventory[i].stack <= 0)
					{
						this.inventory[i] = new Item();
					}
					Main.item[num2].stack = num3;
					Main.item[num2].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
					Main.item[num2].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
					Main.item[num2].noGrabDelay = 100;
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", num2, 0f, 0f, 0f, 0, 0, 0);
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
				this.noThrow--;
			}
			bool flag = true;
			if (flag && this.selectedItem == 58 && this.itemTime == 0 && this.itemAnimation == 0)
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
				Item item3 = this.GetItem(this.whoAmI, Main.mouseItem, false, true);
				if (item3.stack > 0)
				{
					int num3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item3.type, item3.stack, false, 0, true, false);
					Main.item[num3].newAndShiny = false;
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", num3, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				Main.mouseItem = new Item();
				this.inventory[58] = new Item();
				Recipe.FindRecipes();
			}
		}

		public void DropItems()
		{
			for (int i = 0; i < 59; i++)
			{
				if (this.inventory[i].stack > 0 && this.inventory[i].name != "Copper Pickaxe" && this.inventory[i].name != "Copper Axe" && this.inventory[i].name != "Copper Shortsword")
				{
					int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[i].type, 1, false, 0, false, false);
					Main.item[num].netDefaults(this.inventory[i].netID);
					Main.item[num].Prefix((int)this.inventory[i].prefix);
					Main.item[num].stack = this.inventory[i].stack;
					Main.item[num].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
					Main.item[num].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
					Main.item[num].noGrabDelay = 100;
					Main.item[num].newAndShiny = false;
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				this.inventory[i] = new Item();
				if (i < this.armor.Length)
				{
					if (this.armor[i].stack > 0)
					{
						int num2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.armor[i].type, 1, false, 0, false, false);
						Main.item[num2].netDefaults(this.armor[i].netID);
						Main.item[num2].Prefix((int)this.armor[i].prefix);
						Main.item[num2].stack = this.armor[i].stack;
						Main.item[num2].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
						Main.item[num2].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
						Main.item[num2].noGrabDelay = 100;
						Main.item[num2].newAndShiny = false;
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", num2, 0f, 0f, 0f, 0, 0, 0);
						}
					}
					this.armor[i] = new Item();
				}
				if (i < this.dye.Length)
				{
					if (this.dye[i].stack > 0)
					{
						int num3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.dye[i].type, 1, false, 0, false, false);
						Main.item[num3].netDefaults(this.dye[i].netID);
						Main.item[num3].Prefix((int)this.dye[i].prefix);
						Main.item[num3].stack = this.dye[i].stack;
						Main.item[num3].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
						Main.item[num3].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
						Main.item[num3].noGrabDelay = 100;
						Main.item[num3].newAndShiny = false;
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", num3, 0f, 0f, 0f, 0, 0, 0);
						}
					}
					this.dye[i] = new Item();
				}
				if (i < this.miscEquips.Length)
				{
					if (this.miscEquips[i].stack > 0)
					{
						int num4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.miscEquips[i].type, 1, false, 0, false, false);
						Main.item[num4].netDefaults(this.miscEquips[i].netID);
						Main.item[num4].Prefix((int)this.miscEquips[i].prefix);
						Main.item[num4].stack = this.miscEquips[i].stack;
						Main.item[num4].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
						Main.item[num4].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
						Main.item[num4].noGrabDelay = 100;
						Main.item[num4].newAndShiny = false;
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", num4, 0f, 0f, 0f, 0, 0, 0);
						}
					}
					this.miscEquips[i] = new Item();
				}
				if (i < this.miscDyes.Length)
				{
					if (this.miscDyes[i].stack > 0)
					{
						int num5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.miscDyes[i].type, 1, false, 0, false, false);
						Main.item[num5].netDefaults(this.miscDyes[i].netID);
						Main.item[num5].Prefix((int)this.miscDyes[i].prefix);
						Main.item[num5].stack = this.miscDyes[i].stack;
						Main.item[num5].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
						Main.item[num5].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
						Main.item[num5].noGrabDelay = 100;
						Main.item[num5].newAndShiny = false;
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", num5, 0f, 0f, 0f, 0, 0, 0);
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

		public void DropSelectedItem()
		{
			bool flag = false;
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
					flag = true;
				}
			}
			if (!flag)
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
				int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[this.selectedItem].type, 1, false, 0, false, false);
				if (!flag2 && this.inventory[this.selectedItem].type == 8 && this.inventory[this.selectedItem].stack > 1)
				{
					this.inventory[this.selectedItem].stack--;
				}
				else
				{
					this.inventory[this.selectedItem].position = Main.item[num].position;
					Main.item[num] = this.inventory[this.selectedItem];
					this.inventory[this.selectedItem] = new Item();
					if (this.selectedItem == 58)
					{
						Main.mouseItem = new Item();
					}
				}
				if (Main.netMode == 0)
				{
					Main.item[num].noGrabDelay = 100;
				}
				Main.item[num].velocity.Y = -2f;
				Main.item[num].velocity.X = (float)(4 * this.direction) + this.velocity.X;
				Main.item[num].favorited = false;
				Main.item[num].newAndShiny = false;
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
					NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0, 0, 0);
				}
			}
		}

		public void DropTombstone(int coinsOwned, string deathText, int hitDirection)
		{
			if (Main.netMode != 1)
			{
				float num = (float)Main.rand.Next(-35, 36) * 0.1f;
				while (num < 2f && num > -2f)
				{
					num += (float)Main.rand.Next(-30, 31) * 0.1f;
				}
				int num2 = Main.rand.Next(6);
				if (coinsOwned > 100000)
				{
					num2 = Main.rand.Next(5);
					num2 += 527;
				}
				else if (num2 == 0)
				{
					num2 = 43;
				}
				else
				{
					num2 = 200 + num2;
				}
				int num3 = Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), (float)Main.rand.Next(10, 30) * 0.1f * (float)hitDirection + num, (float)Main.rand.Next(-40, -20) * 0.1f, num2, 0, 0f, Main.myPlayer, 0f, 0f);
				Main.projectile[num3].miscText = this.name + deathText;
			}
		}

		public void DryCollision(bool fallThrough, bool ignorePlats)
		{
			int height;
			if (this.onTrack)
			{
				height = this.height - 10;
			}
			else
			{
				height = this.height;
			}
			if (this.velocity.Length() > 16f)
			{
				Vector2 vector = Collision.TileCollision(this.position, this.velocity, this.width, height, fallThrough, ignorePlats, (int)this.gravDir);
				float num = this.velocity.Length();
				Vector2 value = Vector2.Normalize(this.velocity);
				if (vector.Y == 0f)
				{
					value.Y = 0f;
				}
				Vector2 vector2 = Vector2.Zero;
				bool flag = this.mount.Type == 7 || this.mount.Type == 8 || this.mount.Type == 12;
				Vector2 arg_C0_0 = Vector2.Zero;
				while (num > 0f)
				{
					float num2 = num;
					if (num2 > 16f)
					{
						num2 = 16f;
					}
					num -= num2;
					Vector2 velocity = value * num2;
					this.velocity = velocity;
					this.SlopeDownMovement();
					velocity = this.velocity;
					if (this.velocity.Y == this.gravity && (!this.mount.Active || (!this.mount.Cart && !flag)))
					{
						Collision.StepDown(ref this.position, ref velocity, this.width, this.height, ref this.stepSpeed, ref this.gfxOffY, (int)this.gravDir, this.waterWalk || this.waterWalk2);
					}
					if (this.gravDir == -1f)
					{
						if ((this.carpetFrame != -1 || this.velocity.Y <= this.gravity) && !this.controlUp)
						{
							Collision.StepUp(ref this.position, ref velocity, this.width, this.height, ref this.stepSpeed, ref this.gfxOffY, (int)this.gravDir, this.controlUp, 0);
						}
					}
					else if (flag || ((this.carpetFrame != -1 || this.velocity.Y >= this.gravity) && !this.controlDown && !this.mount.Cart))
					{
						Collision.StepUp(ref this.position, ref velocity, this.width, this.height, ref this.stepSpeed, ref this.gfxOffY, (int)this.gravDir, this.controlUp, 0);
					}
					Vector2 vector3 = Collision.TileCollision(this.position, velocity, this.width, height, fallThrough, ignorePlats, (int)this.gravDir);
					if (Collision.up && this.gravDir == 1f)
					{
						this.jump = 0;
					}
					if (this.waterWalk || this.waterWalk2)
					{
						Vector2 velocity2 = this.velocity;
						vector3 = Collision.WaterCollision(this.position, vector3, this.width, this.height, fallThrough, false, this.waterWalk);
						if (velocity2 != this.velocity)
						{
							this.fallStart = (int)(this.position.Y / 16f);
						}
					}
					this.position += vector3;
					bool falling = false;
					if (vector3.Y > this.gravity)
					{
						falling = true;
					}
					if (vector3.Y < -this.gravity)
					{
						falling = true;
					}
					this.velocity = vector3;
					this.UpdateTouchingTiles();
					this.TryBouncingBlocks(falling);
					this.TryLandingOnDetonator();
					this.SlopingCollision(fallThrough);
					Collision.StepConveyorBelt(this, this.gravDir);
					vector3 = this.velocity;
					vector2 += vector3;
				}
				this.velocity = vector2;
				return;
			}
			this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, height, fallThrough, ignorePlats, (int)this.gravDir);
			if (Collision.up && this.gravDir == 1f)
			{
				this.jump = 0;
			}
			if (this.waterWalk || this.waterWalk2)
			{
				Vector2 velocity3 = this.velocity;
				this.velocity = Collision.WaterCollision(this.position, this.velocity, this.width, this.height, fallThrough, false, this.waterWalk);
				if (velocity3 != this.velocity)
				{
					this.fallStart = (int)(this.position.Y / 16f);
				}
			}
			this.position += this.velocity;
		}
		public static event Action<Player> OnEnterWorld;
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
			int num2 = 25;
			int num3 = 50;
			int num4 = -1;
			if (extractType == 1)
			{
				num /= 3;
				num2 *= 2;
				num3 /= 2;
				num4 = 10;
			}
			int num5 = 1;
			int num6;
			if (num4 != -1 && Main.rand.Next(num4) == 0)
			{
				num6 = 3380;
				if (Main.rand.Next(5) == 0)
				{
					num5 += Main.rand.Next(2);
				}
				if (Main.rand.Next(10) == 0)
				{
					num5 += Main.rand.Next(3);
				}
				if (Main.rand.Next(15) == 0)
				{
					num5 += Main.rand.Next(4);
				}
			}
			else if (Main.rand.Next(2) == 0)
			{
				if (Main.rand.Next(12000) == 0)
				{
					num6 = 74;
					if (Main.rand.Next(14) == 0)
					{
						num5 += Main.rand.Next(0, 2);
					}
					if (Main.rand.Next(14) == 0)
					{
						num5 += Main.rand.Next(0, 2);
					}
					if (Main.rand.Next(14) == 0)
					{
						num5 += Main.rand.Next(0, 2);
					}
				}
				else if (Main.rand.Next(800) == 0)
				{
					num6 = 73;
					if (Main.rand.Next(6) == 0)
					{
						num5 += Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(6) == 0)
					{
						num5 += Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(6) == 0)
					{
						num5 += Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(6) == 0)
					{
						num5 += Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(6) == 0)
					{
						num5 += Main.rand.Next(1, 20);
					}
				}
				else if (Main.rand.Next(60) == 0)
				{
					num6 = 72;
					if (Main.rand.Next(4) == 0)
					{
						num5 += Main.rand.Next(5, 26);
					}
					if (Main.rand.Next(4) == 0)
					{
						num5 += Main.rand.Next(5, 26);
					}
					if (Main.rand.Next(4) == 0)
					{
						num5 += Main.rand.Next(5, 26);
					}
					if (Main.rand.Next(4) == 0)
					{
						num5 += Main.rand.Next(5, 25);
					}
				}
				else
				{
					num6 = 71;
					if (Main.rand.Next(3) == 0)
					{
						num5 += Main.rand.Next(10, 26);
					}
					if (Main.rand.Next(3) == 0)
					{
						num5 += Main.rand.Next(10, 26);
					}
					if (Main.rand.Next(3) == 0)
					{
						num5 += Main.rand.Next(10, 26);
					}
					if (Main.rand.Next(3) == 0)
					{
						num5 += Main.rand.Next(10, 25);
					}
				}
			}
			else if (num != -1 && Main.rand.Next(num) == 0)
			{
				num6 = 1242;
			}
			else if (num2 != -1 && Main.rand.Next(num2) == 0)
			{
				num6 = Main.rand.Next(6);
				if (num6 == 0)
				{
					num6 = 181;
				}
				else if (num6 == 1)
				{
					num6 = 180;
				}
				else if (num6 == 2)
				{
					num6 = 177;
				}
				else if (num6 == 3)
				{
					num6 = 179;
				}
				else if (num6 == 4)
				{
					num6 = 178;
				}
				else
				{
					num6 = 182;
				}
				if (Main.rand.Next(20) == 0)
				{
					num5 += Main.rand.Next(0, 2);
				}
				if (Main.rand.Next(30) == 0)
				{
					num5 += Main.rand.Next(0, 3);
				}
				if (Main.rand.Next(40) == 0)
				{
					num5 += Main.rand.Next(0, 4);
				}
				if (Main.rand.Next(50) == 0)
				{
					num5 += Main.rand.Next(0, 5);
				}
				if (Main.rand.Next(60) == 0)
				{
					num5 += Main.rand.Next(0, 6);
				}
			}
			else if (num3 != -1 && Main.rand.Next(num3) == 0)
			{
				num6 = 999;
				if (Main.rand.Next(20) == 0)
				{
					num5 += Main.rand.Next(0, 2);
				}
				if (Main.rand.Next(30) == 0)
				{
					num5 += Main.rand.Next(0, 3);
				}
				if (Main.rand.Next(40) == 0)
				{
					num5 += Main.rand.Next(0, 4);
				}
				if (Main.rand.Next(50) == 0)
				{
					num5 += Main.rand.Next(0, 5);
				}
				if (Main.rand.Next(60) == 0)
				{
					num5 += Main.rand.Next(0, 6);
				}
			}
			else if (Main.rand.Next(3) == 0)
			{
				if (Main.rand.Next(5000) == 0)
				{
					num6 = 74;
					if (Main.rand.Next(10) == 0)
					{
						num5 += Main.rand.Next(0, 3);
					}
					if (Main.rand.Next(10) == 0)
					{
						num5 += Main.rand.Next(0, 3);
					}
					if (Main.rand.Next(10) == 0)
					{
						num5 += Main.rand.Next(0, 3);
					}
					if (Main.rand.Next(10) == 0)
					{
						num5 += Main.rand.Next(0, 3);
					}
					if (Main.rand.Next(10) == 0)
					{
						num5 += Main.rand.Next(0, 3);
					}
				}
				else if (Main.rand.Next(400) == 0)
				{
					num6 = 73;
					if (Main.rand.Next(5) == 0)
					{
						num5 += Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(5) == 0)
					{
						num5 += Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(5) == 0)
					{
						num5 += Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(5) == 0)
					{
						num5 += Main.rand.Next(1, 21);
					}
					if (Main.rand.Next(5) == 0)
					{
						num5 += Main.rand.Next(1, 20);
					}
				}
				else if (Main.rand.Next(30) == 0)
				{
					num6 = 72;
					if (Main.rand.Next(3) == 0)
					{
						num5 += Main.rand.Next(5, 26);
					}
					if (Main.rand.Next(3) == 0)
					{
						num5 += Main.rand.Next(5, 26);
					}
					if (Main.rand.Next(3) == 0)
					{
						num5 += Main.rand.Next(5, 26);
					}
					if (Main.rand.Next(3) == 0)
					{
						num5 += Main.rand.Next(5, 25);
					}
				}
				else
				{
					num6 = 71;
					if (Main.rand.Next(2) == 0)
					{
						num5 += Main.rand.Next(10, 26);
					}
					if (Main.rand.Next(2) == 0)
					{
						num5 += Main.rand.Next(10, 26);
					}
					if (Main.rand.Next(2) == 0)
					{
						num5 += Main.rand.Next(10, 26);
					}
					if (Main.rand.Next(2) == 0)
					{
						num5 += Main.rand.Next(10, 25);
					}
				}
			}
			else
			{
				num6 = Main.rand.Next(8);
				if (num6 == 0)
				{
					num6 = 12;
				}
				else if (num6 == 1)
				{
					num6 = 11;
				}
				else if (num6 == 2)
				{
					num6 = 14;
				}
				else if (num6 == 3)
				{
					num6 = 13;
				}
				else if (num6 == 4)
				{
					num6 = 699;
				}
				else if (num6 == 5)
				{
					num6 = 700;
				}
				else if (num6 == 6)
				{
					num6 = 701;
				}
				else
				{
					num6 = 702;
				}
				if (Main.rand.Next(20) == 0)
				{
					num5 += Main.rand.Next(0, 2);
				}
				if (Main.rand.Next(30) == 0)
				{
					num5 += Main.rand.Next(0, 3);
				}
				if (Main.rand.Next(40) == 0)
				{
					num5 += Main.rand.Next(0, 4);
				}
				if (Main.rand.Next(50) == 0)
				{
					num5 += Main.rand.Next(0, 5);
				}
				if (Main.rand.Next(60) == 0)
				{
					num5 += Main.rand.Next(0, 6);
				}
			}
			if (num6 > 0)
			{
				Vector2 vector = Main.ReverseGravitySupport(Main.MouseScreen, 0f) + Main.screenPosition;
				int number = Item.NewItem((int)vector.X, (int)vector.Y, 1, 1, num6, num5, false, -1, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0, 0, 0);
				}
			}
		}

		public Item FillAmmo(int plr, Item newItem, bool noText = false)
		{
			for (int i = 54; i < 58; i++)
			{
				if (this.inventory[i].type > 0 && this.inventory[i].stack < this.inventory[i].maxStack && newItem.IsTheSameAs(this.inventory[i]))
				{
					if (newItem.stack + this.inventory[i].stack <= this.inventory[i].maxStack)
					{
						this.inventory[i].stack += newItem.stack;
						if (!noText)
						{
							ItemText.NewText(newItem, newItem.stack, false, false);
						}
						this.DoCoins(i);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						return new Item();
					}
					newItem.stack -= this.inventory[i].maxStack - this.inventory[i].stack;
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
			if (newItem.bait <= 0 && newItem.type != 169 && newItem.type != 75 && newItem.type != 23 && newItem.type != 408 && newItem.type != 370 && newItem.type != 1246 && newItem.type != 154 && !newItem.notAmmo)
			{
				for (int j = 54; j < 58; j++)
				{
					if (this.inventory[j].type == 0)
					{
						this.inventory[j] = newItem;
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
			return newItem;
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
				int num = (int)(this.position.X + (float)(this.width / 2)) / 16;
				int num2 = (int)(this.position.Y - 8f) / 16;
				if (Main.tile[num, num2] != null && Main.tile[num, num2].active() && Main.tileRope[(int)Main.tile[num, num2].type])
				{
					float num3 = this.position.Y;
					if (Main.tile[num, num2 - 1] == null)
					{
						Main.tile[num, num2 - 1] = new Tile();
					}
					if (Main.tile[num, num2 + 1] == null)
					{
						Main.tile[num, num2 + 1] = new Tile();
					}
					if ((!Main.tile[num, num2 - 1].active() || !Main.tileRope[(int)Main.tile[num, num2 - 1].type]) && (!Main.tile[num, num2 + 1].active() || !Main.tileRope[(int)Main.tile[num, num2 + 1].type]))
					{
						num3 = (float)(num2 * 16 + 22);
					}
					float num4 = (float)(num * 16 + 8 - this.width / 2 + 6 * this.direction);
					int num5 = num * 16 + 8 - this.width / 2 + 6;
					int num6 = num * 16 + 8 - this.width / 2;
					int num7 = num * 16 + 8 - this.width / 2 + -6;
					int num8 = 1;
					float num9 = Math.Abs(this.position.X - (float)num5);
					if (Math.Abs(this.position.X - (float)num6) < num9)
					{
						num8 = 2;
						num9 = Math.Abs(this.position.X - (float)num6);
					}
					if (Math.Abs(this.position.X - (float)num7) < num9)
					{
						num8 = 3;
						num9 = Math.Abs(this.position.X - (float)num7);
					}
					if (num8 == 1)
					{
						num4 = (float)num5;
						this.pulleyDir = 2;
						this.direction = 1;
					}
					if (num8 == 2)
					{
						num4 = (float)num6;
						this.pulleyDir = 1;
					}
					if (num8 == 3)
					{
						num4 = (float)num7;
						this.pulleyDir = 2;
						this.direction = -1;
					}
					if (!Collision.SolidCollision(new Vector2(num4, this.position.Y), this.width, this.height))
					{
						if (this.whoAmI == Main.myPlayer)
						{
							Main.cameraX = Main.cameraX + this.position.X - num4;
						}
						this.pulley = true;
						this.position.X = num4;
						this.gfxOffY = this.position.Y - num3;
						this.stepSpeed = 2.5f;
						this.position.Y = num3;
						this.velocity.X = 0f;
						return;
					}
					num4 = (float)num5;
					this.pulleyDir = 2;
					this.direction = 1;
					if (!Collision.SolidCollision(new Vector2(num4, this.position.Y), this.width, this.height))
					{
						if (this.whoAmI == Main.myPlayer)
						{
							Main.cameraX = Main.cameraX + this.position.X - num4;
						}
						this.pulley = true;
						this.position.X = num4;
						this.gfxOffY = this.position.Y - num3;
						this.stepSpeed = 2.5f;
						this.position.Y = num3;
						this.velocity.X = 0f;
						return;
					}
					num4 = (float)num7;
					this.pulleyDir = 2;
					this.direction = -1;
					if (!Collision.SolidCollision(new Vector2(num4, this.position.Y), this.width, this.height))
					{
						if (this.whoAmI == Main.myPlayer)
						{
							Main.cameraX = Main.cameraX + this.position.X - num4;
						}
						this.pulley = true;
						this.position.X = num4;
						this.gfxOffY = this.position.Y - num3;
						this.stepSpeed = 2.5f;
						this.position.Y = num3;
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
			int fishingPole = this.inventory[this.selectedItem].fishingPole;
			if (fishingPole == 0)
			{
				for (int i = 0; i < 58; i++)
				{
					if (this.inventory[i].fishingPole > fishingPole)
					{
						fishingPole = this.inventory[i].fishingPole;
					}
				}
			}
			int j = 0;
			while (j < 58)
			{
				if (this.inventory[j].stack > 0 && this.inventory[j].bait > 0)
				{
					if (this.inventory[j].type == 2673)
					{
						return -1;
					}
					num = this.inventory[j].bait;
					break;
				}
				else
				{
					j++;
				}
			}
			if (num == 0 || fishingPole == 0)
			{
				return 0;
			}
			int num2 = num + fishingPole + this.fishingSkill;
			if (Main.raining)
			{
				num2 = (int)((float)num2 * 1.2f);
			}
			if (Main.cloudBGAlpha > 0f)
			{
				num2 = (int)((float)num2 * 1.1f);
			}
			if (Main.dayTime && (Main.time < 5400.0 || Main.time > 48600.0))
			{
				num2 = (int)((float)num2 * 1.3f);
			}
			if (Main.dayTime && Main.time > 16200.0 && Main.time < 37800.0)
			{
				num2 = (int)((float)num2 * 0.8f);
			}
			if (!Main.dayTime && Main.time > 6480.0 && Main.time < 25920.0)
			{
				num2 = (int)((float)num2 * 0.8f);
			}
			if (Main.moonPhase == 0)
			{
				num2 = (int)((float)num2 * 1.1f);
			}
			if (Main.moonPhase == 1 || Main.moonPhase == 7)
			{
				num2 = (int)((float)num2 * 1.05f);
			}
			if (Main.moonPhase == 3 || Main.moonPhase == 5)
			{
				num2 = (int)((float)num2 * 0.95f);
			}
			if (Main.moonPhase == 4)
			{
				num2 = (int)((float)num2 * 0.9f);
			}
			return num2;
		}
		public void FloorVisuals(bool Falling)
		{
			int num = (int)((this.position.X + (float)(this.width / 2)) / 16f);
			int num2 = (int)((this.position.Y + (float)this.height) / 16f);
			if (this.gravDir == -1f)
			{
				num2 = (int)(this.position.Y - 0.1f) / 16;
			}
			int num3 = -1;
			if (Main.tile[num - 1, num2] == null)
			{
				Main.tile[num - 1, num2] = new Tile();
			}
			if (Main.tile[num + 1, num2] == null)
			{
				Main.tile[num + 1, num2] = new Tile();
			}
			if (Main.tile[num, num2] == null)
			{
				Main.tile[num, num2] = new Tile();
			}
			if (Main.tile[num, num2].nactive() && Main.tileSolid[(int)Main.tile[num, num2].type])
			{
				num3 = (int)Main.tile[num, num2].type;
			}
			else if (Main.tile[num - 1, num2].nactive() && Main.tileSolid[(int)Main.tile[num - 1, num2].type])
			{
				num3 = (int)Main.tile[num - 1, num2].type;
			}
			else if (Main.tile[num + 1, num2].nactive() && Main.tileSolid[(int)Main.tile[num + 1, num2].type])
			{
				num3 = (int)Main.tile[num + 1, num2].type;
			}
			if (num3 <= -1)
			{
				this.slippy = false;
				this.slippy2 = false;
				this.sticky = false;
				this.powerrun = false;
				return;
			}
			this.sticky = (num3 == 229);
			this.slippy = (num3 == 161 || num3 == 162 || num3 == 163 || num3 == 164 || num3 == 200 || num3 == 127);
			this.slippy2 = (num3 == 197);
			this.powerrun = (num3 == 198);
		}
		public void GetAnglerReward()
		{
			Item item = new Item();
			item.type = 0;
			float num = 1f;
			if (this.anglerQuestsFinished <= 50)
			{
				num -= (float)this.anglerQuestsFinished * 0.01f;
			}
			else if (this.anglerQuestsFinished <= 100)
			{
				num = 0.5f - (float)(this.anglerQuestsFinished - 50) * 0.005f;
			}
			else if (this.anglerQuestsFinished <= 150)
			{
				num = 0.25f - (float)(this.anglerQuestsFinished - 100) * 0.002f;
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
			else if (this.anglerQuestsFinished > 75 && Main.rand.Next((int)(250f * num)) == 0)
			{
				item.SetDefaults(2294, false);
			}
			else if (Main.hardMode && this.anglerQuestsFinished > 25 && Main.rand.Next((int)(100f * num)) == 0)
			{
				item.SetDefaults(2422, false);
			}
			else if (Main.hardMode && this.anglerQuestsFinished > 10 && Main.rand.Next((int)(70f * num)) == 0)
			{
				item.SetDefaults(2494, false);
			}
			else if (Main.hardMode && this.anglerQuestsFinished > 10 && Main.rand.Next((int)(70f * num)) == 0)
			{
				item.SetDefaults(3031, false);
			}
			else if (Main.hardMode && this.anglerQuestsFinished > 10 && Main.rand.Next((int)(70f * num)) == 0)
			{
				item.SetDefaults(3032, false);
			}
			else if (Main.rand.Next((int)(80f * num)) == 0)
			{
				item.SetDefaults(3183, false);
			}
			else if (Main.rand.Next((int)(60f * num)) == 0)
			{
				item.SetDefaults(2360, false);
			}
			else if (Main.rand.Next((int)(40f * num)) == 0)
			{
				item.SetDefaults(2373, false);
			}
			else if (Main.rand.Next((int)(40f * num)) == 0)
			{
				item.SetDefaults(2374, false);
			}
			else if (Main.rand.Next((int)(40f * num)) == 0)
			{
				item.SetDefaults(2375, false);
			}
			else if (Main.rand.Next((int)(40f * num)) == 0)
			{
				item.SetDefaults(3120, false);
			}
			else if (Main.rand.Next((int)(40f * num)) == 0)
			{
				item.SetDefaults(3037, false);
			}
			else if (Main.rand.Next((int)(40f * num)) == 0)
			{
				item.SetDefaults(3096, false);
			}
			else if (Main.rand.Next((int)(40f * num)) == 0)
			{
				item.SetDefaults(2417, false);
			}
			else if (Main.rand.Next((int)(40f * num)) == 0)
			{
				item.SetDefaults(2498, false);
			}
			else
			{
				int num2 = Main.rand.Next(70);
				if (num2 == 0)
				{
					item.SetDefaults(2442, false);
				}
				else if (num2 == 1)
				{
					item.SetDefaults(2443, false);
				}
				else if (num2 == 2)
				{
					item.SetDefaults(2444, false);
				}
				else if (num2 == 3)
				{
					item.SetDefaults(2445, false);
				}
				else if (num2 == 4)
				{
					item.SetDefaults(2497, false);
				}
				else if (num2 == 5)
				{
					item.SetDefaults(2495, false);
				}
				else if (num2 == 6)
				{
					item.SetDefaults(2446, false);
				}
				else if (num2 == 7)
				{
					item.SetDefaults(2447, false);
				}
				else if (num2 == 8)
				{
					item.SetDefaults(2448, false);
				}
				else if (num2 == 9)
				{
					item.SetDefaults(2449, false);
				}
				else if (num2 == 10)
				{
					item.SetDefaults(2490, false);
				}
				else if (num2 == 11)
				{
					item.SetDefaults(2435, false);
					item.stack = Main.rand.Next(50, 151);
				}
				else if (num2 == 12)
				{
					item.SetDefaults(2496, false);
				}
				else
				{
					int num3 = Main.rand.Next(3);
					if (num3 == 0)
					{
						item.SetDefaults(2354, false);
						item.stack = Main.rand.Next(2, 6);
					}
					else if (num3 == 1)
					{
						item.SetDefaults(2355, false);
						item.stack = Main.rand.Next(2, 6);
					}
					else
					{
						item.SetDefaults(2356, false);
						item.stack = Main.rand.Next(2, 6);
					}
				}
			}
			item.position = base.Center;
			Item item2 = this.GetItem(this.whoAmI, item, true, false);
			if (item2.stack > 0)
			{
				int number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item2.type, item2.stack, false, 0, true, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0, 0, 0);
				}
			}
			if (item.type == 2417)
			{
				Item item3 = new Item();
				Item item4 = new Item();
				item3.SetDefaults(2418, false);
				item3.position = base.Center;
				item2 = this.GetItem(this.whoAmI, item3, true, false);
				if (item2.stack > 0)
				{
					int number2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item2.type, item2.stack, false, 0, true, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number2, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				item4.SetDefaults(2419, false);
				item4.position = base.Center;
				item2 = this.GetItem(this.whoAmI, item4, true, false);
				if (item2.stack > 0)
				{
					int number3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item2.type, item2.stack, false, 0, true, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number3, 1f, 0f, 0f, 0, 0, 0);
					}
				}
			}
			else if (item.type == 2498)
			{
				Item item5 = new Item();
				Item item6 = new Item();
				item5.SetDefaults(2499, false);
				item5.position = base.Center;
				item2 = this.GetItem(this.whoAmI, item5, true, false);
				if (item2.stack > 0)
				{
					int number4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item2.type, item2.stack, false, 0, true, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number4, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				item6.SetDefaults(2500, false);
				item6.position = base.Center;
				item2 = this.GetItem(this.whoAmI, item6, true, false);
				if (item2.stack > 0)
				{
					int number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item2.type, item2.stack, false, 0, true, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0, 0, 0);
					}
				}
			}
			Item item7 = new Item();
			int num4 = (this.anglerQuestsFinished + 50) / 2;
			num4 = (int)((float)(num4 * Main.rand.Next(50, 201)) * 0.015f);
			num4 = (int)((double)num4 * 1.5);
			if (Main.expertMode)
			{
				num4 *= 2;
			}
			if (num4 > 100)
			{
				num4 /= 100;
				if (num4 > 10)
				{
					num4 = 10;
				}
				if (num4 < 1)
				{
					num4 = 1;
				}
				item7.SetDefaults(73, false);
				item7.stack = num4;
			}
			else
			{
				if (num4 > 99)
				{
					num4 = 99;
				}
				if (num4 < 1)
				{
					num4 = 1;
				}
				item7.SetDefaults(72, false);
				item7.stack = num4;
			}
			item7.position = base.Center;
			item2 = this.GetItem(this.whoAmI, item7, true, false);
			if (item2.stack > 0)
			{
				int number6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item2.type, item2.stack, false, 0, true, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number6, 1f, 0f, 0f, 0, 0, 0);
				}
			}
			if (Main.rand.Next((int)(100f * num)) <= 50)
			{
				Item item8 = new Item();
				if (Main.rand.Next((int)(15f * num)) == 0)
				{
					item8.SetDefaults(2676, false);
				}
				else if (Main.rand.Next((int)(5f * num)) == 0)
				{
					item8.SetDefaults(2675, false);
				}
				else
				{
					item8.SetDefaults(2674, false);
				}
				if (Main.rand.Next(25) <= this.anglerQuestsFinished)
				{
					item8.stack++;
				}
				if (Main.rand.Next(50) <= this.anglerQuestsFinished)
				{
					item8.stack++;
				}
				if (Main.rand.Next(100) <= this.anglerQuestsFinished)
				{
					item8.stack++;
				}
				if (Main.rand.Next(150) <= this.anglerQuestsFinished)
				{
					item8.stack++;
				}
				if (Main.rand.Next(200) <= this.anglerQuestsFinished)
				{
					item8.stack++;
				}
				if (Main.rand.Next(250) <= this.anglerQuestsFinished)
				{
					item8.stack++;
				}
				item8.position = base.Center;
				item2 = this.GetItem(this.whoAmI, item8, true, false);
				if (item2.stack > 0)
				{
					int number7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item2.type, item2.stack, false, 0, true, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number7, 1f, 0f, 0f, 0, 0, 0);
					}
				}
			}
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

		public int getDPS()
		{
			TimeSpan timeSpan = this.dpsEnd - this.dpsStart;
			float num = (float)timeSpan.Milliseconds / 1000f;
			num += (float)timeSpan.Seconds;
			num += (float)timeSpan.Minutes / 60f;
			if (num >= 3f)
			{
				this.dpsStart = DateTime.Now;
				this.dpsStart = this.dpsStart.AddSeconds(-1.0);
				this.dpsDamage = (int)((float)this.dpsDamage / num);
				timeSpan = this.dpsEnd - this.dpsStart;
				num = (float)timeSpan.Milliseconds / 1000f;
				num += (float)timeSpan.Seconds;
				num += (float)timeSpan.Minutes / 60f;
			}
			if (num < 1f)
			{
				num = 1f;
			}
			float num2 = (float)this.dpsDamage / num;
			return (int)num2;
		}

		public void GetDyeTraderReward()
		{
			List<int> list = new List<int>
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
			if (Main.hardMode)
			{
				list.Add(3039);
				list.Add(3038);
				list.Add(3598);
				list.Add(3597);
				list.Add(3600);
				list.Add(3042);
				list.Add(3533);
				list.Add(3561);
				if (NPC.downedMechBossAny)
				{
					list.Add(2883);
					list.Add(2869);
					list.Add(2873);
					list.Add(2870);
				}
				if (NPC.downedPlantBoss)
				{
					list.Add(2878);
					list.Add(2879);
					list.Add(2884);
					list.Add(2885);
				}
				if (NPC.downedMartians)
				{
					list.Add(2864);
					list.Add(3556);
				}
				if (NPC.downedMoonlord)
				{
					list.Add(3024);
				}
			}
			int type = list[Main.rand.Next(list.Count)];
			Item item = new Item();
			item.SetDefaults(type, false);
			item.stack = 3;
			item.position = base.Center;
			Item item2 = this.GetItem(this.whoAmI, item, true, false);
			if (item2.stack > 0)
			{
				int number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item2.type, item2.stack, false, 0, true, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0, 0, 0);
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
			float num = (float)(255 - this.immuneAlpha) / 255f;
			if (alphaReduction > 0f)
			{
				num *= 1f - alphaReduction;
			}
			if (this.immuneAlpha > 125)
			{
				return Color.Transparent;
			}
			return Color.Multiply(newColor, num);
		}

		public Color GetImmuneAlphaPure(Color newColor, float alphaReduction)
		{
			float num = (float)(255 - this.immuneAlpha) / 255f;
			if (alphaReduction > 0f)
			{
				num *= 1f - alphaReduction;
			}
			return Color.Multiply(newColor, num);
		}

		public Item GetItem(int plr, Item newItem, bool longText = false, bool noText = false)
		{
			bool flag = newItem.type >= 71 && newItem.type <= 74;
			Item item = newItem;
			int num = 50;
			if (newItem.noGrabDelay > 0)
			{
				return item;
			}
			int num2 = 0;
			if (newItem.uniqueStack && this.HasItem(newItem.type))
			{
				return item;
			}
			if (newItem.type == 71 || newItem.type == 72 || newItem.type == 73 || newItem.type == 74)
			{
				num2 = -4;
				num = 54;
			}
			if (((item.ammo > 0 || item.bait > 0) && !item.notAmmo) || item.type == 530)
			{
				item = this.FillAmmo(plr, item, noText);
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
					if (item.stack + this.inventory[num3].stack <= this.inventory[num3].maxStack)
					{
						this.inventory[num3].stack += item.stack;
						if (!noText)
						{
							ItemText.NewText(newItem, item.stack, false, longText);
						}
						this.DoCoins(num3);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						AchievementsHelper.NotifyItemPickup(this, item);
						return new Item();
					}
					AchievementsHelper.NotifyItemPickup(this, item, this.inventory[num3].maxStack - this.inventory[num3].stack);
					item.stack -= this.inventory[num3].maxStack - this.inventory[num3].stack;
					if (!noText)
					{
						ItemText.NewText(newItem, this.inventory[num3].maxStack - this.inventory[num3].stack, false, longText);
					}
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
			if (newItem.favorited)
			{
				for (int k = 0; k < num; k++)
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
				for (int l = num - 1; l >= 0; l--)
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
		}

		private void GrabItems(int i)
		{
			for (int j = 0; j < 400; j++)
			{
				if (Main.item[j].active && Main.item[j].noGrabDelay == 0 && Main.item[j].owner == i)
				{
					int num = Player.defaultItemGrabRange;
					if (this.goldRing && Main.item[j].type >= 71 && Main.item[j].type <= 74)
					{
						num += Item.coinGrabRange;
					}
					if (this.manaMagnet && (Main.item[j].type == 184 || Main.item[j].type == 1735 || Main.item[j].type == 1868))
					{
						num += Item.manaGrabRange;
					}
					if (this.lifeMagnet && (Main.item[j].type == 58 || Main.item[j].type == 1734 || Main.item[j].type == 1867))
					{
						num += Item.lifeGrabRange;
					}
					if (ItemID.Sets.NebulaPickup[Main.item[j].type])
					{
						num += 100;
					}
					if (new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height).Intersects(new Rectangle((int)Main.item[j].position.X, (int)Main.item[j].position.Y, Main.item[j].width, Main.item[j].height)))
					{
						if (i == Main.myPlayer && (this.inventory[this.selectedItem].type != 0 || this.itemAnimation <= 0))
						{
							if (ItemID.Sets.NebulaPickup[Main.item[j].type])
							{
								int num2 = Main.item[j].buffType;
								Main.item[j] = new Item();
								if (Main.netMode == 1)
								{
									NetMessage.SendData(102, -1, -1, "", i, (float)num2, base.Center.X, base.Center.Y, 0, 0, 0);
									NetMessage.SendData(21, -1, -1, "", j, 0f, 0f, 0f, 0, 0, 0);
								}
								else
								{
									this.NebulaLevelup(num2);
								}
							}
							if (Main.item[j].type == 58 || Main.item[j].type == 1734 || Main.item[j].type == 1867)
							{
								this.statLife += 20;
								if (Main.myPlayer == this.whoAmI)
								{
									this.HealEffect(20, true);
								}
								if (this.statLife > this.statLifeMax2)
								{
									this.statLife = this.statLifeMax2;
								}
								Main.item[j] = new Item();
								if (Main.netMode == 1)
								{
									NetMessage.SendData(21, -1, -1, "", j, 0f, 0f, 0f, 0, 0, 0);
								}
							}
							else if (Main.item[j].type == 184 || Main.item[j].type == 1735 || Main.item[j].type == 1868)
							{
								this.statMana += 100;
								if (Main.myPlayer == this.whoAmI)
								{
									this.ManaEffect(100);
								}
								if (this.statMana > this.statManaMax2)
								{
									this.statMana = this.statManaMax2;
								}
								Main.item[j] = new Item();
								if (Main.netMode == 1)
								{
									NetMessage.SendData(21, -1, -1, "", j, 0f, 0f, 0f, 0, 0, 0);
								}
							}
							else
							{
								Main.item[j] = this.GetItem(i, Main.item[j], false, false);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(21, -1, -1, "", j, 0f, 0f, 0f, 0, 0, 0);
								}
							}
						}
					}
					else if (new Rectangle((int)this.position.X - num, (int)this.position.Y - num, this.width + num * 2, this.height + num * 2).Intersects(new Rectangle((int)Main.item[j].position.X, (int)Main.item[j].position.Y, Main.item[j].width, Main.item[j].height)) && this.ItemSpace(Main.item[j]))
					{
						Main.item[j].beingGrabbed = true;
						if (this.manaMagnet && (Main.item[j].type == 184 || Main.item[j].type == 1735 || Main.item[j].type == 1868))
						{
							float num3 = 12f;
							Vector2 vector = new Vector2(Main.item[j].position.X + (float)(Main.item[j].width / 2), Main.item[j].position.Y + (float)(Main.item[j].height / 2));
							float num4 = base.Center.X - vector.X;
							float num5 = base.Center.Y - vector.Y;
							float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
							num6 = num3 / num6;
							num4 *= num6;
							num5 *= num6;
							int num7 = 5;
							Main.item[j].velocity.X = (Main.item[j].velocity.X * (float)(num7 - 1) + num4) / (float)num7;
							Main.item[j].velocity.Y = (Main.item[j].velocity.Y * (float)(num7 - 1) + num5) / (float)num7;
						}
						else if (this.lifeMagnet && (Main.item[j].type == 58 || Main.item[j].type == 1734 || Main.item[j].type == 1867))
						{
							float num8 = 15f;
							Vector2 vector2 = new Vector2(Main.item[j].position.X + (float)(Main.item[j].width / 2), Main.item[j].position.Y + (float)(Main.item[j].height / 2));
							float num9 = base.Center.X - vector2.X;
							float num10 = base.Center.Y - vector2.Y;
							float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
							num11 = num8 / num11;
							num9 *= num11;
							num10 *= num11;
							int num12 = 5;
							Main.item[j].velocity.X = (Main.item[j].velocity.X * (float)(num12 - 1) + num9) / (float)num12;
							Main.item[j].velocity.Y = (Main.item[j].velocity.Y * (float)(num12 - 1) + num10) / (float)num12;
						}
						else if (this.goldRing && Main.item[j].type >= 71 && Main.item[j].type <= 74)
						{
							float num13 = 12f;
							Vector2 vector3 = new Vector2(Main.item[j].position.X + (float)(Main.item[j].width / 2), Main.item[j].position.Y + (float)(Main.item[j].height / 2));
							float num14 = base.Center.X - vector3.X;
							float num15 = base.Center.Y - vector3.Y;
							float num16 = (float)Math.Sqrt((double)(num14 * num14 + num15 * num15));
							num16 = num13 / num16;
							num14 *= num16;
							num15 *= num16;
							int num17 = 5;
							Main.item[j].velocity.X = (Main.item[j].velocity.X * (float)(num17 - 1) + num14) / (float)num17;
							Main.item[j].velocity.Y = (Main.item[j].velocity.Y * (float)(num17 - 1) + num15) / (float)num17;
						}
						else if (ItemID.Sets.NebulaPickup[Main.item[j].type])
						{
							float num18 = 12f;
							Vector2 vector4 = new Vector2(Main.item[j].position.X + (float)(Main.item[j].width / 2), Main.item[j].position.Y + (float)(Main.item[j].height / 2));
							float num19 = base.Center.X - vector4.X;
							float num20 = base.Center.Y - vector4.Y;
							float num21 = (float)Math.Sqrt((double)(num19 * num19 + num20 * num20));
							num21 = num18 / num21;
							num19 *= num21;
							num20 *= num21;
							int num22 = 5;
							Main.item[j].velocity.X = (Main.item[j].velocity.X * (float)(num22 - 1) + num19) / (float)num22;
							Main.item[j].velocity.Y = (Main.item[j].velocity.Y * (float)(num22 - 1) + num20) / (float)num22;
						}
						else
						{
							if ((double)this.position.X + (double)this.width * 0.5 > (double)Main.item[j].position.X + (double)Main.item[j].width * 0.5)
							{
								if (Main.item[j].velocity.X < Player.itemGrabSpeedMax + this.velocity.X)
								{
									Item expr_A6E_cp_0 = Main.item[j];
									expr_A6E_cp_0.velocity.X = expr_A6E_cp_0.velocity.X + Player.itemGrabSpeed;
								}
								if (Main.item[j].velocity.X < 0f)
								{
									Item expr_AA6_cp_0 = Main.item[j];
									expr_AA6_cp_0.velocity.X = expr_AA6_cp_0.velocity.X + Player.itemGrabSpeed * 0.75f;
								}
							}
							else
							{
								if (Main.item[j].velocity.X > -Player.itemGrabSpeedMax + this.velocity.X)
								{
									Item expr_AF0_cp_0 = Main.item[j];
									expr_AF0_cp_0.velocity.X = expr_AF0_cp_0.velocity.X - Player.itemGrabSpeed;
								}
								if (Main.item[j].velocity.X > 0f)
								{
									Item expr_B25_cp_0 = Main.item[j];
									expr_B25_cp_0.velocity.X = expr_B25_cp_0.velocity.X - Player.itemGrabSpeed * 0.75f;
								}
							}
							if ((double)this.position.Y + (double)this.height * 0.5 > (double)Main.item[j].position.Y + (double)Main.item[j].height * 0.5)
							{
								if (Main.item[j].velocity.Y < Player.itemGrabSpeedMax)
								{
									Item expr_BAA_cp_0 = Main.item[j];
									expr_BAA_cp_0.velocity.Y = expr_BAA_cp_0.velocity.Y + Player.itemGrabSpeed;
								}
								if (Main.item[j].velocity.Y < 0f)
								{
									Item expr_BE2_cp_0 = Main.item[j];
									expr_BE2_cp_0.velocity.Y = expr_BE2_cp_0.velocity.Y + Player.itemGrabSpeed * 0.75f;
								}
							}
							else
							{
								if (Main.item[j].velocity.Y > -Player.itemGrabSpeedMax)
								{
									Item expr_C20_cp_0 = Main.item[j];
									expr_C20_cp_0.velocity.Y = expr_C20_cp_0.velocity.Y - Player.itemGrabSpeed;
								}
								if (Main.item[j].velocity.Y > 0f)
								{
									Item expr_C55_cp_0 = Main.item[j];
									expr_C55_cp_0.velocity.Y = expr_C55_cp_0.velocity.Y - Player.itemGrabSpeed * 0.75f;
								}
							}
						}
					}
				}
			}
		}

		public void GrappleMovement()
		{
			if (this.grappling[0] >= 0)
			{
				if (Main.myPlayer == this.whoAmI && this.mount.Active)
				{
					this.mount.Dismount(this);
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
				if (this.wings == 30)
				{
					this.wingFrame = 0;
				}
				this.wingTime = (float)this.wingTimeMax;
				this.rocketTime = this.rocketTimeMax;
				this.rocketDelay = 0;
				this.rocketFrame = false;
				this.canRocket = false;
				this.rocketRelease = false;
				this.fallStart = (int)(this.position.Y / 16f);
				int num = -1;
				float num2 = 0f;
				float num3 = 0f;
				for (int i = 0; i < this.grapCount; i++)
				{
					Projectile projectile = Main.projectile[this.grappling[i]];
					num2 += projectile.position.X + (float)(projectile.width / 2);
					num3 += projectile.position.Y + (float)(projectile.height / 2);
					if (projectile.type == 403)
					{
						num = i;
					}
					else if (projectile.type == 446)
					{
						Vector2 vector = new Vector2((float)(this.controlRight.ToInt() - this.controlLeft.ToInt()), (float)(this.controlDown.ToInt() - this.controlUp.ToInt()) * this.gravDir);
						if (vector != Vector2.Zero)
						{
							vector.Normalize();
						}
						vector *= 100f;
						Vector2 vector2 = Vector2.Normalize(base.Center - projectile.Center + vector);
						if (float.IsNaN(vector2.X) || float.IsNaN(vector2.Y))
						{
							vector2 = -Vector2.UnitY;
						}
						float num4 = 200f;
						num2 += vector2.X * num4;
						num3 += vector2.Y * num4;
					}
					else if (projectile.type == 652)
					{
						Vector2 vector3 = new Vector2((float)(this.controlRight.ToInt() - this.controlLeft.ToInt()), (float)(this.controlDown.ToInt() - this.controlUp.ToInt()) * this.gravDir);
						if (vector3 != Vector2.Zero)
						{
							vector3.Normalize();
						}
						Vector2 vector4 = projectile.Center - base.Center;
						Vector2 vector5 = vector4;
						if (vector5 != Vector2.Zero)
						{
							vector5.Normalize();
						}
						Vector2 value = Vector2.Zero;
						if (vector3 != Vector2.Zero)
						{
							value = vector5 * Vector2.Dot(vector5, vector3);
						}
						float num5 = 6f;
						if (Vector2.Dot(value, vector4) < 0f && vector4.Length() >= 600f)
						{
							num5 = 0f;
						}
						num2 += -vector4.X + value.X * num5;
						num3 += -vector4.Y + value.Y * num5;
					}
				}
				num2 /= (float)this.grapCount;
				num3 /= (float)this.grapCount;
				Vector2 vector6 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num6 = num2 - vector6.X;
				float num7 = num3 - vector6.Y;
				float num8 = (float)Math.Sqrt((double)(num6 * num6 + num7 * num7));
				float num9 = 11f;
				if (Main.projectile[this.grappling[0]].type == 315)
				{
					num9 = 16f;
				}
				if (Main.projectile[this.grappling[0]].type >= 646 && Main.projectile[this.grappling[0]].type <= 649)
				{
					num9 = 13f;
				}
				float num10;
				if (num8 > num9)
				{
					num10 = num9 / num8;
				}
				else
				{
					num10 = 1f;
				}
				num6 *= num10;
				num7 *= num10;
				if (num7 > 0f)
				{
					this.GoingDownWithGrapple = true;
				}
				this.velocity.X = num6;
				this.velocity.Y = num7;
				if (num != -1)
				{
					Projectile projectile2 = Main.projectile[this.grappling[num]];
					if (projectile2.position.X < this.position.X + (float)this.width && projectile2.position.X + (float)projectile2.width >= this.position.X && projectile2.position.Y < this.position.Y + (float)this.height && projectile2.position.Y + (float)projectile2.height >= this.position.Y)
					{
						int num11 = (int)(projectile2.position.X + (float)(projectile2.width / 2)) / 16;
						int num12 = (int)(projectile2.position.Y + (float)(projectile2.height / 2)) / 16;
						this.velocity = Vector2.Zero;
						if (Main.tile[num11, num12].type == 314)
						{
							Vector2 position;
							position.X = projectile2.position.X + (float)(projectile2.width / 2) - (float)(this.width / 2);
							position.Y = projectile2.position.Y + (float)(projectile2.height / 2) - (float)(this.height / 2);
							this.grappling[0] = -1;
							this.grapCount = 0;
							for (int j = 0; j < 1000; j++)
							{
								if (Main.projectile[j].active && Main.projectile[j].owner == this.whoAmI && Main.projectile[j].aiStyle == 7)
								{
									Main.projectile[j].Kill();
								}
							}
							int num13 = 13;
							if (this.miscEquips[2].stack > 0 && this.miscEquips[2].mountType >= 0 && MountID.Sets.Cart[this.miscEquips[2].mountType] && (!this.miscEquips[2].expertOnly || Main.expertMode))
							{
								num13 = this.miscEquips[2].mountType;
							}
							int num14 = this.height + Mount.GetHeightBoost(num13);
							if (Minecart.GetOnTrack(num11, num12, ref position, this.width, num14) && !Collision.SolidCollision(position, this.width, num14 - 20))
							{
								this.position = position;
								DelegateMethods.Minecart.rotation = this.fullRotation;
								DelegateMethods.Minecart.rotationOrigin = this.fullRotationOrigin;
								this.mount.SetMount(num13, this, this.minecartLeft);
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
				else
				{
					this.releaseJump = true;
				}
			}
		}
		public bool HasAmmo(Item sItem, bool canUse)
		{
			if (sItem.useAmmo > 0)
			{
				canUse = false;
				for (int i = 0; i < 58; i++)
				{
					if (this.inventory[i].ammo == sItem.useAmmo && this.inventory[i].stack > 0)
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
				NetMessage.SendData(35, -1, -1, "", this.whoAmI, (float)healAmount, 0f, 0f, 0, 0, 0);
			}
		}

		public void HoneyCollision(bool fallThrough, bool ignorePlats)
		{
			int height;
			if (this.onTrack)
			{
				height = this.height - 20;
			}
			else
			{
				height = this.height;
			}
			Vector2 velocity = this.velocity;
			this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, height, fallThrough, ignorePlats, (int)this.gravDir);
			Vector2 value = this.velocity * 0.25f;
			if (this.velocity.X != velocity.X)
			{
				value.X = this.velocity.X;
			}
			if (this.velocity.Y != velocity.Y)
			{
				value.Y = this.velocity.Y;
			}
			this.position += value;
		}

		public void HorizontalMovement()
		{
			if (this.chilled)
			{
				this.accRunSpeed = this.maxRunSpeed;
			}
			bool flag = (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn) && this.mount.AllowDirectionChange;
			bool flag2 = this.controlLeft || this.controlRight;
			float num = (this.accRunSpeed + this.maxRunSpeed) / 2f;
			float num2 = 0f;
			bool flag3 = false;
			if (this.windPushed && (!this.mount.Active || this.velocity.Y != 0f || !flag2))
			{
				num2 = (float)Math.Sign(Main.windSpeed) * 0.07f;
				if (Math.Abs(Main.windSpeed) > 0.5f)
				{
					num2 *= 1.37f;
				}
				if (this.velocity.Y != 0f)
				{
					num2 *= 1.5f;
				}
				if (flag2)
				{
					num2 *= 0.8f;
				}
				flag3 = true;
				if (Math.Sign(this.direction) != Math.Sign(num2))
				{
					num -= Math.Abs(num2) * 40f;
				}
			}
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
					if (this.velocity.X < -this.runSlowdown)
					{
						this.velocity.X = this.velocity.X + this.runSlowdown;
					}
					else
					{
						this.velocity.X = 0f;
					}
				}
				if (this.mount.Active && this.mount.Cart && !this.onWrongGround)
				{
					if (this.velocity.X < 0f && flag)
					{
						this.direction = -1;
					}
					else if (this.itemAnimation <= 0 && this.velocity.Y == 0f)
					{
						DelegateMethods.Minecart.rotation = this.fullRotation;
						DelegateMethods.Minecart.rotationOrigin = this.fullRotationOrigin;
					}
				}
				else if (!this.sandStorm && (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn) && this.mount.AllowDirectionChange)
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
					if (this.velocity.X > this.runSlowdown)
					{
						this.velocity.X = this.velocity.X - this.runSlowdown;
					}
					else
					{
						this.velocity.X = 0f;
					}
				}
				if (this.mount.Active && this.mount.Cart && !this.onWrongGround)
				{
					if (this.velocity.X > 0f && flag)
					{
						this.direction = 1;
					}
					else if (this.itemAnimation <= 0 && this.velocity.Y == 0f)
					{
						DelegateMethods.Minecart.rotation = this.fullRotation;
						DelegateMethods.Minecart.rotationOrigin = this.fullRotationOrigin;
					}
				}
				else if (!this.sandStorm && (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn) && this.mount.AllowDirectionChange)
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
					if (this.velocity.X < this.runSlowdown)
					{
						this.velocity.X = this.velocity.X + this.runSlowdown;
					}
					else
					{
						this.velocity.X = 0f;
					}
				}
				if (this.velocity.X < -num && this.velocity.Y == 0f && !this.mount.Active)
				{
					int num3 = 0;
					if (this.gravDir == -1f)
					{
						num3 -= this.height;
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
					if (this.velocity.X > this.runSlowdown)
					{
						this.velocity.X = this.velocity.X - this.runSlowdown;
					}
					else
					{
						this.velocity.X = 0f;
					}
				}
				if (this.velocity.X > num && this.velocity.Y == 0f && !this.mount.Active)
				{
					int num8 = 0;
					if (this.gravDir == -1f)
					{
						num8 -= this.height;
					}
				}
			}
			else if (this.mount.Active && this.mount.Cart && Math.Abs(this.velocity.X) >= 1f)
			{
				if (this.onWrongGround)
				{
					if (this.velocity.X > 0f)
					{
						if (this.velocity.X > this.runSlowdown)
						{
							this.velocity.X = this.velocity.X - this.runSlowdown;
						}
						else
						{
							this.velocity.X = 0f;
						}
					}
					else if (this.velocity.X < 0f)
					{
						if (this.velocity.X < -this.runSlowdown)
						{
							this.velocity.X = this.velocity.X + this.runSlowdown;
						}
						else
						{
							this.velocity.X = 0f;
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
			else if (this.velocity.Y == 0f)
			{
				if (this.velocity.X > this.runSlowdown)
				{
					this.velocity.X = this.velocity.X - this.runSlowdown;
				}
				else if (this.velocity.X < -this.runSlowdown)
				{
					this.velocity.X = this.velocity.X + this.runSlowdown;
				}
				else
				{
					this.velocity.X = 0f;
				}
			}
			else if (!this.PortalPhysicsEnabled)
			{
				if ((double)this.velocity.X > (double)this.runSlowdown * 0.5)
				{
					this.velocity.X = this.velocity.X - this.runSlowdown * 0.5f;
				}
				else if ((double)this.velocity.X < (double)(-(double)this.runSlowdown) * 0.5)
				{
					this.velocity.X = this.velocity.X + this.runSlowdown * 0.5f;
				}
				else
				{
					this.velocity.X = 0f;
				}
			}
			if (flag3)
			{
				if (num2 < 0f && this.velocity.X > num2)
				{
					this.velocity.X = this.velocity.X + num2;
					if (this.velocity.X < num2)
					{
						this.velocity.X = num2;
					}
				}
				if (num2 > 0f && this.velocity.X < num2)
				{
					this.velocity.X = this.velocity.X + num2;
					if (this.velocity.X > num2)
					{
						this.velocity.X = num2;
					}
				}
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
				float damage = 80f * this.minionDamage;
				float knockback = 10f;
				int nPCImmuneTime = 30;
				int playerImmuneTime = 6;
				this.CollideWithNPCs(rect, damage, knockback, nPCImmuneTime, playerImmuneTime);
			}
			if (this.mount.Active && this.mount.Type == 14 && Math.Abs(this.velocity.X) > this.mount.RunSpeed / 2f)
			{
				Rectangle rect2 = this.getRect();
				if (this.direction == 1)
				{
					rect2.Offset(this.width - 1, 0);
				}
				rect2.Width = 2;
				rect2.Inflate(6, 12);
				float damage2 = 90f * this.minionDamage;
				float knockback2 = 10f;
				int nPCImmuneTime2 = 30;
				int playerImmuneTime2 = 6;
				this.CollideWithNPCs(rect2, damage2, knockback2, nPCImmuneTime2, playerImmuneTime2);
			}
		}

		public double Hurt(int Damage, int hitDirection, bool pvp = false, bool quiet = false, string deathText = " was slain...", bool Crit = false, int cooldownCounter = -1)
		{
			bool flag = !this.immune;
			bool flag2 = false;
			int number = cooldownCounter;
			if (cooldownCounter == 0)
			{
				flag = (this.hurtCooldowns[cooldownCounter] <= 0);
			}
			if (cooldownCounter == 1)
			{
				flag = (this.hurtCooldowns[cooldownCounter] <= 0);
			}
			if (cooldownCounter == 2)
			{
				flag2 = true;
				cooldownCounter = -1;
			}
			if (!flag)
			{
				return 0.0;
			}
			if (this.whoAmI == Main.myPlayer && this.blackBelt && Main.rand.Next(10) == 0)
			{
				this.NinjaDodge();
				return 0.0;
			}
			if (this.whoAmI == Main.myPlayer && this.shadowDodge)
			{
				this.ShadowDodge();
				return 0.0;
			}
			if (this.whoAmI == Main.myPlayer && this.panic)
			{
				this.AddBuff(63, 300, true);
			}
			this.stealth = 1f;
			if (Main.netMode == 1)
			{
				NetMessage.SendData(84, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
			}
			int num = Damage;
			double num2 = Main.CalculatePlayerDamage(num, this.statDefense);
			if (Crit)
			{
				num *= 2;
			}
			if (num2 >= 1.0)
			{
				if (this.invis)
				{
					for (int i = 0; i < 22; i++)
					{
						if (this.buffType[i] == 10)
						{
							this.DelBuff(i);
						}
					}
				}
				num2 = (double)((int)((double)(1f - this.endurance) * num2));
				if (num2 < 1.0)
				{
					num2 = 1.0;
				}
				if (this.ConsumeSolarFlare())
				{
					float num3 = 0.3f;
					num2 = (double)((int)((double)(1f - num3) * num2));
					if (num2 < 1.0)
					{
						num2 = 1.0;
					}
					if (this.whoAmI == Main.myPlayer)
					{
						int num4 = Projectile.NewProjectile(base.Center.X, base.Center.Y, 0f, 0f, 608, 150, 15f, Main.myPlayer, 0f, 0f);
						Main.projectile[num4].Kill();
					}
				}
				if (this.beetleDefense && this.beetleOrbs > 0)
				{
					float num5 = 0.15f * (float)this.beetleOrbs;
					num2 = (double)((int)((double)(1f - num5) * num2));
					this.beetleOrbs--;
					for (int j = 0; j < 22; j++)
					{
						if (this.buffType[j] >= 95 && this.buffType[j] <= 97)
						{
							this.DelBuff(j);
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
					int num6 = num;
					this.statMana += num6;
					if (this.statMana > this.statManaMax2)
					{
						this.statMana = this.statManaMax2;
					}
					this.ManaEffect(num6);
				}
				if (this.defendedByPaladin)
				{
					if (this.whoAmI != Main.myPlayer)
					{
						if (Main.player[Main.myPlayer].hasPaladinShield)
						{
							Player player = Main.player[Main.myPlayer];
							if (player.team == this.team && this.team != 0)
							{
								float num7 = player.Distance(base.Center);
								bool flag2b = num7 < 800f;
								if (flag2b)
								{
									for (int k = 0; k < 255; k++)
									{
										if (k != Main.myPlayer && Main.player[k].active && !Main.player[k].dead && !Main.player[k].immune && Main.player[k].hasPaladinShield && Main.player[k].team == this.team && (float)Main.player[k].statLife > (float)Main.player[k].statLifeMax2 * 0.25f)
										{
											float num8 = Main.player[k].Distance(base.Center);
											if (num7 > num8 || (num7 == num8 && k < Main.myPlayer))
											{
												flag2b = false;
												break;
											}
										}
									}
								}
								if (flag2b)
								{
									int damage = (int)(num2 * 0.25);
									num2 = (double)((int)(num2 * 0.75));
									player.Hurt(damage, 0, false, false, "", false, -1);
								}
							}
						}
					}
					else
					{
						bool flag3 = false;
						for (int l = 0; l < 255; l++)
						{
							if (l != Main.myPlayer && Main.player[l].active && !Main.player[l].dead && !Main.player[l].immune && Main.player[l].hasPaladinShield && Main.player[l].team == this.team && (float)Main.player[l].statLife > (float)Main.player[l].statLifeMax2 * 0.25f)
							{
								flag3 = true;
								break;
							}
						}
						if (flag3)
						{
							num2 = (double)((int)(num2 * 0.75));
						}
					}
				}
				if (this.brainOfConfusion && Main.myPlayer == this.whoAmI)
				{
					for (int m = 0; m < 200; m++)
					{
						if (Main.npc[m].active && !Main.npc[m].friendly)
						{
							int num9 = 300;
							num9 += (int)num2 * 2;
							if (Main.rand.Next(500) < num9)
							{
								float num10 = (Main.npc[m].Center - base.Center).Length();
								float num11 = (float)Main.rand.Next(200 + (int)num2 / 2, 301 + (int)num2 * 2);
								if (num11 > 500f)
								{
									num11 = 500f + (num11 - 500f) * 0.75f;
								}
								if (num11 > 700f)
								{
									num11 = 700f + (num11 - 700f) * 0.5f;
								}
								if (num11 > 900f)
								{
									num11 = 900f + (num11 - 900f) * 0.25f;
								}
								if (num10 < num11)
								{
									float num12 = (float)Main.rand.Next(90 + (int)num2 / 3, 300 + (int)num2 / 2);
									Main.npc[m].AddBuff(31, (int)num12, false);
								}
							}
						}
					}
					Projectile.NewProjectile(base.Center.X + (float)Main.rand.Next(-40, 40), base.Center.Y - (float)Main.rand.Next(20, 60), this.velocity.X * 0.3f, this.velocity.Y * 0.3f, 565, 0, 0f, this.whoAmI, 0f, 0f);
				}
				Color color = Crit ? CombatText.DamagedFriendlyCrit : CombatText.DamagedFriendly;
				CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), color, string.Concat((int)num2), Crit, false);
				this.statLife -= (int)num2;
				if (cooldownCounter == -1)
				{
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
					if (pvp)
					{
						this.immuneTime = 8;
					}
				}
				else if (cooldownCounter == 0)
				{
					if (num2 == 1.0)
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
					if (num2 == 1.0)
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
						for (int n = 0; n < 3; n++)
						{
							float x = this.position.X + (float)Main.rand.Next(-400, 400);
							float y = this.position.Y - (float)Main.rand.Next(500, 800);
							Vector2 vector = new Vector2(x, y);
							float num14 = this.position.X + (float)(this.width / 2) - vector.X;
							float num15 = this.position.Y + (float)(this.height / 2) - vector.Y;
							num14 += (float)Main.rand.Next(-100, 101);
							int num16 = 23;
							float num17 = (float)Math.Sqrt((double)(num14 * num14 + num15 * num15));
							num17 = (float)num16 / num17;
							num14 *= num17;
							num15 *= num17;
							int num18 = Projectile.NewProjectile(x, y, num14, num15, 92, 30, 5f, this.whoAmI, 0f, 0f);
							Main.projectile[num18].ai[1] = this.position.Y;
						}
					}
					if (this.bee)
					{
						int num19 = 1;
						if (Main.rand.Next(3) == 0)
						{
							num19++;
						}
						if (Main.rand.Next(3) == 0)
						{
							num19++;
						}
						if (this.strongBees && Main.rand.Next(3) == 0)
						{
							num19++;
						}
						for (int num20 = 0; num20 < num19; num20++)
						{
							float speedX = (float)Main.rand.Next(-35, 36) * 0.02f;
							float speedY = (float)Main.rand.Next(-35, 36) * 0.02f;
							Projectile.NewProjectile(this.position.X, this.position.Y, speedX, speedY, this.beeType(), this.beeDamage(7), this.beeKB(0f), Main.myPlayer, 0f, 0f);
						}
					}
				}
				if (flag2 && hitDirection != 0)
				{
					if (!this.mount.Active || !this.mount.Cart)
					{
						float num21 = 10.5f;
						float y2 = -7.5f;
						if (this.noKnockback)
						{
							num21 = 2.5f;
							y2 = -1.5f;
						}
						this.velocity.X = num21 * (float)hitDirection;
						this.velocity.Y = y2;
					}
				}
				else if (!this.noKnockback && hitDirection != 0 && (!this.mount.Active || !this.mount.Cart))
				{
					this.velocity.X = 4.5f * (float)hitDirection;
					this.velocity.Y = -3.5f;
				}
				if (this.statLife > 0)
				{
				}
				else
				{
					this.statLife = 0;
					if (this.whoAmI == Main.myPlayer)
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

		public bool IsStackingItems()
		{
			for (int i = 0; i < this.inventoryChestStack.Length; i++)
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
			if (this.webbed || this.frozen || this.stoned)
			{
				return;
			}
			bool flag = false;
			float num = (float)this.mount.PlayerOffsetHitbox;
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
					if (item.shoot > 0 && this.whoAmI != Main.myPlayer && this.controlUseItem && item.useStyle == 5)
					{
						this.ApplyAnimation(item);
					}
					else
					{
						this.itemAnimation = 0;
					}
				}
			}
			if (item.fishingPole > 0)
			{
				item.holdStyle = 0;
				if (this.itemTime == 0 && this.itemAnimation == 0)
				{
					for (int j = 0; j < 1000; j++)
					{
						if (Main.projectile[j].active && Main.projectile[j].owner == this.whoAmI && Main.projectile[j].bobber)
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
					if (Main.tile[num2, num3].active() && (Main.tile[num2, num3].type == 128 || Main.tile[num2, num3].type == 269))
					{
						int num4 = (int)Main.tile[num2, num3].frameY;
						int k = 0;
						if (item.bodySlot >= 0)
						{
							k = 1;
						}
						if (item.legSlot >= 0)
						{
							k = 2;
						}
						num4 /= 18;
						while (k > num4)
						{
							num3++;
							num4 = (int)Main.tile[num2, num3].frameY;
							num4 /= 18;
						}
						while (k < num4)
						{
							num3--;
							num4 = (int)Main.tile[num2, num3].frameY;
							num4 /= 18;
						}
						int l;
						for (l = (int)Main.tile[num2, num3].frameX; l >= 100; l -= 100)
						{
						}
						if (l >= 36)
						{
							l -= 36;
						}
						num2 -= l / 18;
						int m = (int)Main.tile[num2, num3].frameX;
						WorldGen.KillTile(num2, num3, true, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 0, (float)num2, (float)num3, 1f, 0, 0, 0);
						}
						while (m >= 100)
						{
							m -= 100;
						}
						if (num4 == 0 && item.headSlot >= 0)
						{
							Main.blockMouse = true;
							Main.tile[num2, num3].frameX = (short)(m + item.headSlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num2, num3, 1, TileChangeType.None);
							}
							item.stack--;
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
						else if (num4 == 1 && item.bodySlot >= 0)
						{
							Main.blockMouse = true;
							Main.tile[num2, num3].frameX = (short)(m + item.bodySlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num2, num3, 1, TileChangeType.None);
							}
							item.stack--;
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
						else if (num4 == 2 && item.legSlot >= 0 && !ArmorIDs.Legs.Sets.MannequinIncompatible.Contains(item.legSlot))
						{
							Main.blockMouse = true;
							Main.tile[num2, num3].frameX = (short)(m + item.legSlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num2, num3, 1, TileChangeType.None);
							}
							item.stack--;
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
				TileObject tileObject;
				TileObject.CanPlace(Player.tileTargetX, Player.tileTargetY, item.createTile, item.placeStyle, this.direction, out tileObject, true);
			}
			if (this.itemAnimation == 0 && this.altFunctionUse == 2)
			{
				this.altFunctionUse = 0;
			}
			if (this.controlUseItem && this.itemAnimation == 0 && this.releaseUseItem && item.useStyle > 0)
			{
				if (this.altFunctionUse == 1)
				{
					this.altFunctionUse = 2;
				}
				bool flag2 = true;
				if (item.shoot == 0)
				{
					this.itemRotation = 0f;
				}
				if (item.type == 3335 && (this.extraAccessory || !Main.expertMode))
				{
					flag2 = false;
				}
				if (this.pulley && item.fishingPole > 0)
				{
					flag2 = false;
				}
				if (item.type == 3611 && (WiresUI.Settings.ToolMode & (WiresUI.Settings.MultiToolMode.Red | WiresUI.Settings.MultiToolMode.Green | WiresUI.Settings.MultiToolMode.Blue | WiresUI.Settings.MultiToolMode.Yellow | WiresUI.Settings.MultiToolMode.Actuator)) == (WiresUI.Settings.MultiToolMode)0)
				{
					flag2 = false;
				}
				if ((item.type == 3611 || item.type == 3625) && this.wireOperationsCooldown > 0)
				{
					flag2 = false;
				}
				if (!this.CheckDD2CrystalPaymentLock(item))
				{
					flag2 = false;
				}
				if (item.shoot > -1 && ProjectileID.Sets.IsADD2Turret[item.shoot] && !this.downedDD2EventAnyDifficulty && !DD2Event.Ongoing)
				{
					flag2 = false;
				}
				if (item.shoot > -1 && ProjectileID.Sets.IsADD2Turret[item.shoot] && DD2Event.Ongoing && i == Main.myPlayer)
				{
					int worldX;
					int worldY;
					int num5;
					this.FindSentryRestingSpot(item.shoot, out worldX, out worldY, out num5);
					if (Player.WouldSpotOverlapWithSentry(worldX, worldY))
					{
						flag2 = false;
					}
				}
				if (item.shoot > -1 && ProjectileID.Sets.IsADD2Turret[item.shoot] && i == Main.myPlayer)
				{
					int num6;
					int num7;
					int num8;
					this.FindSentryRestingSpot(item.shoot, out num6, out num7, out num8);
					num6 /= 16;
					num7 /= 16;
					num7--;
					if (WorldGen.SolidTile(num6, num7))
					{
						flag2 = false;
					}
				}
				if (this.wet && (item.shoot == 85 || item.shoot == 15 || item.shoot == 34))
				{
					flag2 = false;
				}
				if (item.makeNPC > 0 && !NPC.CanReleaseNPCs(this.whoAmI))
				{
					flag2 = false;
				}
				if (this.whoAmI == Main.myPlayer && item.type == 603 && !Main.cEd)
				{
					flag2 = false;
				}
				if (item.type == 1071 || item.type == 1072)
				{
					bool flag3 = false;
					for (int n = 0; n < 58; n++)
					{
						if (this.inventory[n].paint > 0)
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
				if (item.tileWand > 0)
				{
					int tileWand = item.tileWand;
					flag2 = false;
					for (int num5 = 0; num5 < 58; num5++)
					{
						if (tileWand == this.inventory[num5].type && this.inventory[num5].stack > 0)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (item.fishingPole > 0)
				{
					for (int num6 = 0; num6 < 1000; num6++)
					{
						if (Main.projectile[num6].active && Main.projectile[num6].owner == this.whoAmI && Main.projectile[num6].bobber)
						{
							flag2 = false;
							if (this.whoAmI == Main.myPlayer && Main.projectile[num6].ai[0] == 0f)
							{
								Main.projectile[num6].ai[0] = 1f;
								float num7 = -10f;
								if (Main.projectile[num6].wet && Main.projectile[num6].velocity.Y > num7)
								{
									Main.projectile[num6].velocity.Y = num7;
								}
								Main.projectile[num6].netUpdate2 = true;
								if (Main.projectile[num6].ai[1] < 0f && Main.projectile[num6].localAI[1] != 0f)
								{
									bool flag4 = false;
									int num8 = 0;
									for (int num9 = 0; num9 < 58; num9++)
									{
										if (this.inventory[num9].stack > 0 && this.inventory[num9].bait > 0)
										{
											bool flag5 = false;
											int num10 = 1 + this.inventory[num9].bait / 5;
											if (num10 < 1)
											{
												num10 = 1;
											}
											if (this.accTackleBox)
											{
												num10++;
											}
											if (Main.rand.Next(num10) == 0)
											{
												flag5 = true;
											}
											if (Main.projectile[num6].localAI[1] < 0f)
											{
												flag5 = true;
											}
											if (Main.projectile[num6].localAI[1] > 0f)
											{
												Item item2 = new Item();
												item2.SetDefaults((int)Main.projectile[num6].localAI[1], false);
												if (item2.rare < 0)
												{
													flag5 = false;
												}
											}
											if (flag5)
											{
												num8 = this.inventory[num9].type;
												this.inventory[num9].stack--;
												if (this.inventory[num9].stack <= 0)
												{
													this.inventory[num9].SetDefaults(0, false);
												}
											}
											flag4 = true;
											break;
										}
									}
									if (flag4)
									{
										if (num8 == 2673)
										{
											if (Main.netMode != 1)
											{
												NPC.SpawnOnPlayer(this.whoAmI, 370);
											}
											else
											{
												NetMessage.SendData(61, -1, -1, "", this.whoAmI, 370f, 0f, 0f, 0, 0, 0);
											}
											Main.projectile[num6].ai[0] = 2f;
										}
										else if (Main.rand.Next(7) == 0 && !this.accFishingLine)
										{
											Main.projectile[num6].ai[0] = 2f;
										}
										else
										{
											Main.projectile[num6].ai[1] = Main.projectile[num6].localAI[1];
										}
										Main.projectile[num6].netUpdate = true;
									}
								}
							}
						}
					}
				}
				if (item.shoot == 6 || item.shoot == 19 || item.shoot == 33 || item.shoot == 52 || item.shoot == 113 || item.shoot == 320 || item.shoot == 333 || item.shoot == 383 || item.shoot == 491)
				{
					for (int num11 = 0; num11 < 1000; num11++)
					{
						if (Main.projectile[num11].active && Main.projectile[num11].owner == Main.myPlayer && Main.projectile[num11].type == item.shoot)
						{
							flag2 = false;
						}
					}
				}
				if (item.shoot == 106)
				{
					int num12 = 0;
					for (int num13 = 0; num13 < 1000; num13++)
					{
						if (Main.projectile[num13].active && Main.projectile[num13].owner == Main.myPlayer && Main.projectile[num13].type == item.shoot)
						{
							num12++;
						}
					}
					if (num12 >= item.stack)
					{
						flag2 = false;
					}
				}
				if (item.shoot == 272)
				{
					int num14 = 0;
					for (int num15 = 0; num15 < 1000; num15++)
					{
						if (Main.projectile[num15].active && Main.projectile[num15].owner == Main.myPlayer && Main.projectile[num15].type == item.shoot)
						{
							num14++;
						}
					}
					if (num14 >= item.stack)
					{
						flag2 = false;
					}
				}
				if (item.shoot == 13 || item.shoot == 32 || (item.shoot >= 230 && item.shoot <= 235) || item.shoot == 315 || item.shoot == 331 || item.shoot == 372)
				{
					for (int num16 = 0; num16 < 1000; num16++)
					{
						if (Main.projectile[num16].active && Main.projectile[num16].owner == Main.myPlayer && Main.projectile[num16].type == item.shoot && Main.projectile[num16].ai[0] != 2f)
						{
							flag2 = false;
						}
					}
				}
				if (item.shoot == 332)
				{
					int num17 = 0;
					for (int num18 = 0; num18 < 1000; num18++)
					{
						if (Main.projectile[num18].active && Main.projectile[num18].owner == Main.myPlayer && Main.projectile[num18].type == item.shoot && Main.projectile[num18].ai[0] != 2f)
						{
							num17++;
						}
					}
					if (num17 >= 3)
					{
						flag2 = false;
					}
				}
				if (item.potion && flag2)
				{
					if (this.potionDelay <= 0)
					{
						if (item.type == 227)
						{
							this.potionDelay = this.restorationDelayTime;
							this.AddBuff(21, this.potionDelay, true);
						}
						else
						{
							this.potionDelay = this.potionDelayTime;
							this.AddBuff(21, this.potionDelay, true);
						}
					}
					else
					{
						flag2 = false;
					}
				}
				if (item.mana > 0 && this.silence)
				{
					flag2 = false;
				}
				if (item.mana > 0 && flag2)
				{
					bool flag6 = false;
					if (item.type == 2795)
					{
						flag6 = true;
					}
					if (item.shoot > 0 && ProjectileID.Sets.TurretFeature[item.shoot] && this.altFunctionUse == 2)
					{
						flag6 = true;
					}
					if (item.shoot > 0 && ProjectileID.Sets.MinionTargettingFeature[item.shoot] && this.altFunctionUse == 2)
					{
						flag6 = true;
					}
					if (item.type != 127 || !this.spaceGun)
					{
						if (this.statMana >= (int)((float)item.mana * this.manaCost))
						{
							if (!flag6)
							{
								this.statMana -= (int)((float)item.mana * this.manaCost);
							}
						}
						else if (this.manaFlower)
						{
							this.QuickMana();
							if (this.statMana >= (int)((float)item.mana * this.manaCost))
							{
								if (!flag6)
								{
									this.statMana -= (int)((float)item.mana * this.manaCost);
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
					if (this.whoAmI == Main.myPlayer && item.buffType != 0 && flag2)
					{
						this.AddBuff(item.buffType, item.buffTime, true);
					}
				}
				if (this.whoAmI == Main.myPlayer && item.type == 603 && Main.cEd)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 669)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 115)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 3060)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 3628)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 3062)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 3577)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 425)
				{
					int num19 = Main.rand.Next(3);
					if (num19 == 0)
					{
						num19 = 27;
					}
					if (num19 == 1)
					{
						num19 = 101;
					}
					if (num19 == 2)
					{
						num19 = 102;
					}
					for (int num20 = 0; num20 < 22; num20++)
					{
						if (this.buffType[num20] == 27 || this.buffType[num20] == 101 || this.buffType[num20] == 102)
						{
							this.DelBuff(num20);
							num20--;
						}
					}
					this.AddBuff(num19, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 753)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 994)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1169)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1170)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1171)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1172)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1180)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1181)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1182)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1183)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1242)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1157)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1309)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1311)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1837)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1312)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1798)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1799)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1802)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1810)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1927)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 1959)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 2364)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 2365)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 3043)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 2420)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 2535)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 2551)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 2584)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 2587)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 2621)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 2749)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 3249)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 3474)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && item.type == 3531)
				{
					this.AddBuff(item.buffType, 3600, true);
				}
				if (this.whoAmI == Main.myPlayer && this.gravDir == 1f && item.mountType != -1 && this.mount.CanMount(item.mountType, this))
				{
					this.mount.SetMount(item.mountType, this, false);
				}
				if (item.type == 43 && Main.dayTime)
				{
					flag2 = false;
				}
				if (item.type == 544 && Main.dayTime)
				{
					flag2 = false;
				}
				if (item.type == 556 && Main.dayTime)
				{
					flag2 = false;
				}
				if (item.type == 557 && Main.dayTime)
				{
					flag2 = false;
				}
				if (item.type == 70 && !this.ZoneCorrupt)
				{
					flag2 = false;
				}
				if (item.type == 1133 && !this.ZoneJungle)
				{
					flag2 = false;
				}
				if (item.type == 1844 && (Main.dayTime || Main.pumpkinMoon || Main.snowMoon || DD2Event.Ongoing))
				{
					flag2 = false;
				}
				if (item.type == 1958 && (Main.dayTime || Main.pumpkinMoon || Main.snowMoon || DD2Event.Ongoing))
				{
					flag2 = false;
				}
				if (item.type == 2767 && (!Main.dayTime || Main.eclipse || !Main.hardMode))
				{
					flag2 = false;
				}
				if (item.type == 3601 && (!NPC.downedGolemBoss || !Main.hardMode || NPC.AnyDanger() || NPC.AnyoneNearCultists()))
				{
					flag2 = false;
				}
				if (!this.SummonItemCheck())
				{
					flag2 = false;
				}
				if (item.shoot == 17 && flag2 && i == Main.myPlayer)
				{
					int num21 = (int)((float)Main.mouseX + Main.screenPosition.X) / 16;
					int num22 = (int)((float)Main.mouseY + Main.screenPosition.Y) / 16;
					if (this.gravDir == -1f)
					{
						num22 = (int)(Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16;
					}
					Tile tile = Main.tile[num21, num22];
					if (tile.active() && (tile.type == 0 || tile.type == 2 || tile.type == 23 || tile.type == 109 || tile.type == 199))
					{
						WorldGen.KillTile(num21, num22, false, false, true);
						if (!Main.tile[num21, num22].active())
						{
							if (Main.netMode == 1)
							{
								NetMessage.SendData(17, -1, -1, "", 4, (float)num21, (float)num22, 0f, 0, 0, 0);
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
				if (flag2)
				{
					flag2 = this.HasAmmo(item, flag2);
				}
				if (flag2)
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
				if (flag2 && this.whoAmI == Main.myPlayer && item.shoot >= 0 && item.shoot < 662 && (ProjectileID.Sets.LightPet[item.shoot] || Main.projPet[item.shoot]))
				{
					if (ProjectileID.Sets.MinionSacrificable[item.shoot])
					{
						List<int> list = new List<int>();
						float num23 = 0f;
						for (int num24 = 0; num24 < 1000; num24++)
						{
							if (Main.projectile[num24].active && Main.projectile[num24].owner == i && Main.projectile[num24].minion)
							{
								int num25;
								for (num25 = 0; num25 < list.Count; num25++)
								{
									if (Main.projectile[list[num25]].minionSlots > Main.projectile[num24].minionSlots)
									{
										list.Insert(num25, num24);
										break;
									}
								}
								if (num25 == list.Count)
								{
									list.Add(num24);
								}
								num23 += Main.projectile[num24].minionSlots;
							}
						}
						float num26 = (float)ItemID.Sets.StaffMinionSlotsRequired[item.type];
						float num27 = 0f;
						int num28 = 388;
						int num29 = -1;
						for (int num30 = 0; num30 < list.Count; num30++)
						{
							int type = Main.projectile[list[num30]].type;
							if (type == 626)
							{
								list.RemoveAt(num30);
								num30--;
							}
							if (type == 627)
							{
								if (Main.projectile[(int)Main.projectile[list[num30]].localAI[1]].type == 628)
								{
									num29 = list[num30];
								}
								list.RemoveAt(num30);
								num30--;
							}
						}
						if (num29 != -1)
						{
							list.Add(num29);
							list.Add(Projectile.GetByUUID(Main.projectile[num29].owner, Main.projectile[num29].ai[0]));
						}
						int num31 = 0;
						while (num31 < list.Count && num23 - num27 > (float)this.maxMinions - num26)
						{
							int type2 = Main.projectile[list[num31]].type;
							if (type2 != num28 && type2 != 625 && type2 != 628 && type2 != 623)
							{
								if (type2 == 388 && num28 == 387)
								{
									num28 = 388;
								}
								if (type2 == 387 && num28 == 388)
								{
									num28 = 387;
								}
								num27 += Main.projectile[list[num31]].minionSlots;
								if (type2 == 626 || type2 == 627)
								{
									int byUUID = Projectile.GetByUUID(Main.projectile[list[num31]].owner, Main.projectile[list[num31]].ai[0]);
									if (byUUID >= 0)
									{
										Projectile projectile = Main.projectile[byUUID];
										if (projectile.type != 625)
										{
											projectile.localAI[1] = Main.projectile[list[num31]].localAI[1];
										}
										projectile = Main.projectile[(int)Main.projectile[list[num31]].localAI[1]];
										projectile.ai[0] = Main.projectile[list[num31]].ai[0];
										projectile.ai[1] = 1f;
										projectile.netUpdate = true;
									}
								}
								Main.projectile[list[num31]].Kill();
							}
							num31++;
						}
						list.Clear();
						if (num23 + num26 >= 9f)
						{
							AchievementsHelper.HandleSpecialEvent(this, 6);
						}
					}
					else
					{
						for (int num32 = 0; num32 < 1000; num32++)
						{
							if (Main.projectile[num32].active && Main.projectile[num32].owner == i && Main.projectile[num32].type == item.shoot)
							{
								Main.projectile[num32].Kill();
							}
							if (item.shoot == 72)
							{
								if (Main.projectile[num32].active && Main.projectile[num32].owner == i && Main.projectile[num32].type == 86)
								{
									Main.projectile[num32].Kill();
								}
								if (Main.projectile[num32].active && Main.projectile[num32].owner == i && Main.projectile[num32].type == 87)
								{
									Main.projectile[num32].Kill();
								}
							}
						}
					}
				}
			}
			if (!this.controlUseItem)
			{
				bool arg_1FA5_0 = this.channel;
				this.channel = false;
			}
			if (this.itemAnimation > 0)
			{
				if (item.melee)
				{
					this.itemAnimationMax = (int)((float)item.useAnimation * this.meleeSpeed);
				}
				else
				{
					this.itemAnimationMax = item.useAnimation;
				}
				if (item.mana > 0 && !flag && (item.type != 127 || !this.spaceGun))
				{
					this.manaRegenDelay = (int)this.maxRegenDelay;
				}
				if (Main.dedServ)
				{
					this.itemHeight = item.height;
					this.itemWidth = item.width;
				}
				this.itemAnimation--;
			}
			else if (item.holdStyle == 1 && !this.pulley)
			{
				if (Main.dedServ)
				{
					this.itemLocation.X = this.position.X + (float)this.width * 0.5f + 20f * (float)this.direction;
				}
				else if (item.type == 930)
				{
					this.itemLocation.X = this.position.X + (float)(this.width / 2) * 0.5f - 12f - (float)(2 * this.direction);
					float num41 = this.position.X + (float)(this.width / 2) + (float)(38 * this.direction);
					if (this.direction == 1)
					{
						num41 -= 10f;
					}
					float num42 = this.MountedCenter.Y - 4f * this.gravDir;
					if (this.gravDir == -1f)
					{
						num42 -= 8f;
					}
					this.RotateRelativePoint(ref num41, ref num42);
					int num43 = 0;
					for (int num44 = 54; num44 < 58; num44++)
					{
						if (this.inventory[num44].stack > 0 && this.inventory[num44].ammo == 931)
						{
							num43 = this.inventory[num44].type;
							break;
						}
					}
					if (num43 == 0)
					{
						for (int num45 = 0; num45 < 54; num45++)
						{
							if (this.inventory[num45].stack > 0 && this.inventory[num45].ammo == 931)
							{
								num43 = this.inventory[num45].type;
								break;
							}
						}
					}
					if (num43 == 931)
					{
						num43 = 127;
					}
					else if (num43 == 1614)
					{
						num43 = 187;
					}
				}
			}
			else if (item.holdStyle == 2 && !this.pulley)
			{
				if (item.type == 946)
				{
					this.itemRotation = 0f;
					this.itemLocation.X = this.position.X + (float)this.width * 0.5f - (float)(16 * this.direction);
					this.itemLocation.Y = this.position.Y + 22f + num;
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
					this.itemRotation = 0.79f * (float)(-(float)this.direction);
					if (this.gravDir == -1f)
					{
						this.itemRotation = -this.itemRotation;
					}
				}
			}
			else if (item.holdStyle == 3 && !this.pulley && !Main.dedServ)
			{
				this.itemRotation = 0f;
			}
			if ((((item.type == 974 || item.type == 8 || item.type == 1245 || item.type == 2274 || item.type == 3004 || item.type == 3045 || item.type == 3114 || (item.type >= 427 && item.type <= 433)) && !this.wet) || item.type == 523 || item.type == 1333) && !this.pulley)
			{
				float num50 = 1f;
				float num51 = 0.95f;
				float num52 = 0.8f;
				int num53 = 0;
				if (item.type == 523)
				{
					num53 = 8;
				}
				else if (item.type == 974)
				{
					num53 = 9;
				}
				else if (item.type == 1245)
				{
					num53 = 10;
				}
				else if (item.type == 1333)
				{
					num53 = 11;
				}
				else if (item.type == 2274)
				{
					num53 = 12;
				}
				else if (item.type == 3004)
				{
					num53 = 13;
				}
				else if (item.type == 3045)
				{
					num53 = 14;
				}
				else if (item.type == 3114)
				{
					num53 = 15;
				}
				else if (item.type >= 427)
				{
					num53 = item.type - 426;
				}
				if (num53 == 1)
				{
					num50 = 0f;
					num51 = 0.1f;
					num52 = 1.3f;
				}
				else if (num53 == 2)
				{
					num50 = 1f;
					num51 = 0.1f;
					num52 = 0.1f;
				}
				else if (num53 == 3)
				{
					num50 = 0f;
					num51 = 1f;
					num52 = 0.1f;
				}
				else if (num53 == 4)
				{
					num50 = 0.9f;
					num51 = 0f;
					num52 = 0.9f;
				}
				else if (num53 == 5)
				{
					num50 = 1.3f;
					num51 = 1.3f;
					num52 = 1.3f;
				}
				else if (num53 == 6)
				{
					num50 = 0.9f;
					num51 = 0.9f;
					num52 = 0f;
				}
				else if (num53 == 7)
				{
					num50 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
					num51 = 0.3f;
					num52 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
				}
				else if (num53 == 8)
				{
					num52 = 0.7f;
					num50 = 0.85f;
					num51 = 1f;
				}
				else if (num53 == 9)
				{
					num52 = 1f;
					num50 = 0.7f;
					num51 = 0.85f;
				}
				else if (num53 == 10)
				{
					num52 = 0f;
					num50 = 1f;
					num51 = 0.5f;
				}
				else if (num53 == 11)
				{
					num52 = 0.8f;
					num50 = 1.25f;
					num51 = 1.25f;
				}
				else if (num53 == 12)
				{
					num50 *= 0.75f;
					num51 *= 1.3499999f;
					num52 *= 1.5f;
				}
				else if (num53 == 13)
				{
					num50 = 0.95f;
					num51 = 0.65f;
					num52 = 1.3f;
				}
				else if (num53 == 14)
				{
					num50 = (float)Main.DiscoR / 255f;
					num51 = (float)Main.DiscoG / 255f;
					num52 = (float)Main.DiscoB / 255f;
				}
				else if (num53 == 15)
				{
					num50 = 1f;
					num51 = 0f;
					num52 = 1f;
				}
				int num54 = num53;
				if (num54 == 0)
				{
					num54 = 6;
				}
				else if (num54 == 8)
				{
					num54 = 75;
				}
				else if (num54 == 9)
				{
					num54 = 135;
				}
				else if (num54 == 10)
				{
					num54 = 158;
				}
				else if (num54 == 11)
				{
					num54 = 169;
				}
				else if (num54 == 12)
				{
					num54 = 156;
				}
				else if (num54 == 13)
				{
					num54 = 234;
				}
				else if (num54 == 14)
				{
					num54 = 66;
				}
				else if (num54 == 15)
				{
					num54 = 242;
				}
				else
				{
					num54 = 58 + num54;
				}
				int maxValue = 30;
				if (this.itemAnimation > 0)
				{
					maxValue = 7;
				}
			}
			if ((item.type == 105 || item.type == 713) && !this.wet && !this.pulley)
			{
				int maxValue2 = 20;
				if (this.itemAnimation > 0)
				{
					maxValue2 = 7;
				}
			}
			else if (item.type == 148 && !this.wet)
			{
				int maxValue3 = 10;
				if (this.itemAnimation > 0)
				{
					maxValue3 = 7;
				}
			}
			else if (item.type == 3117 && !this.wet)
			{
				this.itemLocation.X = this.itemLocation.X - (float)(this.direction * 4);
				int maxValue4 = 10;
				if (this.itemAnimation > 0)
				{
					maxValue4 = 7;
				}
			}
			if (item.type == 3002 && !this.pulley)
			{
				this.spelunkerTimer += 1;
				if (this.spelunkerTimer >= 10)
				{
					this.spelunkerTimer = 0;
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
			}
			if (i == Main.myPlayer)
			{
				bool flag8 = true;
				int type4 = item.type;
				if ((type4 == 65 || type4 == 676 || type4 == 723 || type4 == 724 || type4 == 757 || type4 == 674 || type4 == 675 || type4 == 989 || type4 == 1226 || type4 == 1227) && this.itemAnimation != this.itemAnimationMax - 1)
				{
					flag8 = false;
				}
				if (item.shoot > 0 && this.itemAnimation > 0 && this.itemTime == 0 && flag8)
				{
					int num71 = item.shoot;
					float num72 = item.shootSpeed;
					if (this.inventory[this.selectedItem].thrown && num72 < 16f)
					{
						num72 *= this.thrownVelocity;
						if (num72 > 16f)
						{
							num72 = 16f;
						}
					}
					if (item.melee && num71 != 25 && num71 != 26 && num71 != 35)
					{
						num72 /= this.meleeSpeed;
					}
					bool flag9 = false;
					int num73 = weaponDamage;
					float num74 = item.knockBack;
					if (num71 == 13 || num71 == 32 || num71 == 315 || (num71 >= 230 && num71 <= 235) || num71 == 331)
					{
						this.grappling[0] = -1;
						this.grapCount = 0;
						for (int num75 = 0; num75 < 1000; num75++)
						{
							if (Main.projectile[num75].active && Main.projectile[num75].owner == i)
							{
								if (Main.projectile[num75].type == 13)
								{
									Main.projectile[num75].Kill();
								}
								if (Main.projectile[num75].type == 331)
								{
									Main.projectile[num75].Kill();
								}
								if (Main.projectile[num75].type == 315)
								{
									Main.projectile[num75].Kill();
								}
								if (Main.projectile[num75].type >= 230 && Main.projectile[num75].type <= 235)
								{
									Main.projectile[num75].Kill();
								}
							}
						}
					}
					if (item.useAmmo > 0)
					{
						this.PickAmmo(item, ref num71, ref num72, ref flag9, ref num73, ref num74, ItemID.Sets.gunProj[item.type]);
					}
					else
					{
						flag9 = true;
					}
					if (item.type == 3475 || item.type == 3540)
					{
						num74 = item.knockBack;
						num73 = weaponDamage;
						num72 = item.shootSpeed;
					}
					if (item.type == 71)
					{
						flag9 = false;
					}
					if (item.type == 72)
					{
						flag9 = false;
					}
					if (item.type == 73)
					{
						flag9 = false;
					}
					if (item.type == 74)
					{
						flag9 = false;
					}
					if (item.type == 1254 && num71 == 14)
					{
						num71 = 242;
					}
					if (item.type == 1255 && num71 == 14)
					{
						num71 = 242;
					}
					if (item.type == 1265 && num71 == 14)
					{
						num71 = 242;
					}
					if (item.type == 3542)
					{
						bool flag10 = Main.rand.Next(100) < 20;
						if (flag10)
						{
							num71++;
							num73 *= 3;
						}
						else
						{
							num72 -= 1f;
						}
					}
					if (num71 == 73)
					{
						for (int num76 = 0; num76 < 1000; num76++)
						{
							if (Main.projectile[num76].active && Main.projectile[num76].owner == i)
							{
								if (Main.projectile[num76].type == 73)
								{
									num71 = 74;
								}
								if (num71 == 74 && Main.projectile[num76].type == 74)
								{
									flag9 = false;
								}
							}
						}
					}
					if (flag9)
					{
						num74 = this.GetWeaponKnockback(item, num74);
						if (num71 == 228)
						{
							num74 = 0f;
						}
						if (num71 == 1 && item.type == 120)
						{
							num71 = 2;
						}
						if (item.type == 682)
						{
							num71 = 117;
						}
						if (item.type == 725)
						{
							num71 = 120;
						}
						if (item.type == 2796)
						{
							num71 = 442;
						}
						if (item.type == 2223)
						{
							num71 = 357;
						}
						this.itemTime = item.useTime;
						Vector2 vector2 = this.RotatedRelativePoint(this.MountedCenter, true);
						bool flag11 = true;
						int type5 = item.type;
						if (type5 == 3611)
						{
							flag11 = false;
						}
						Vector2 value = Vector2.UnitX.RotatedBy((double)this.fullRotation, default(Vector2));
						Vector2 vector3 = Main.MouseWorld - vector2;
						if (vector3 != Vector2.Zero)
						{
							vector3.Normalize();
						}
						float num77 = Vector2.Dot(value, vector3);
						if (flag11)
						{
							if (num77 > 0f)
							{
								this.ChangeDir(1);
							}
							else
							{
								this.ChangeDir(-1);
							}
						}
						if (item.type == 3094 || item.type == 3378 || item.type == 3543)
						{
							vector2.Y = this.position.Y + (float)(this.height / 3);
						}
						if (item.type == 2611)
						{
							Vector2 vector4 = vector3;
							if (vector4 != Vector2.Zero)
							{
								vector4.Normalize();
							}
							vector2 += vector4;
						}
						if (num71 == 9)
						{
							vector2 = new Vector2(this.position.X + (float)this.width * 0.5f + (float)(Main.rand.Next(201) * -(float)this.direction) + ((float)Main.mouseX + Main.screenPosition.X - this.position.X), this.MountedCenter.Y - 600f);
							num74 = 0f;
							num73 *= 2;
						}
						if (item.type == 986 || item.type == 281)
						{
							vector2.X += (float)(6 * this.direction);
							vector2.Y -= 6f * this.gravDir;
						}
						if (item.type == 3007)
						{
							vector2.X -= (float)(4 * this.direction);
							vector2.Y -= 1f * this.gravDir;
						}
						float num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
						float num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
						if (this.gravDir == -1f)
						{
							num79 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector2.Y;
						}
						float num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
						float num81 = num80;
						if ((float.IsNaN(num78) && float.IsNaN(num79)) || (num78 == 0f && num79 == 0f))
						{
							num78 = (float)this.direction;
							num79 = 0f;
							num80 = num72;
						}
						else
						{
							num80 = num72 / num80;
						}
						if (item.type == 1929 || item.type == 2270)
						{
							num78 += (float)Main.rand.Next(-50, 51) * 0.03f / num80;
							num79 += (float)Main.rand.Next(-50, 51) * 0.03f / num80;
						}
						num78 *= num80;
						num79 *= num80;
						if (item.type == 757)
						{
							num73 = (int)((float)num73 * 1.25f);
						}
						if (num71 == 250)
						{
							for (int num82 = 0; num82 < 1000; num82++)
							{
								if (Main.projectile[num82].active && Main.projectile[num82].owner == this.whoAmI && (Main.projectile[num82].type == 250 || Main.projectile[num82].type == 251))
								{
									Main.projectile[num82].Kill();
								}
							}
						}
						if (num71 == 12)
						{
							vector2.X += num78 * 3f;
							vector2.Y += num79 * 3f;
						}
						if (item.useStyle == 5)
						{
							if (item.type == 3029)
							{
								Vector2 vector5 = new Vector2(num78, num79);
								vector5.X = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
								vector5.Y = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y - 1000f;
								this.itemRotation = (float)Math.Atan2((double)(vector5.Y * (float)this.direction), (double)(vector5.X * (float)this.direction));
								NetMessage.SendData(13, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
								NetMessage.SendData(41, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
							}
							else if (item.type == 3779)
							{
								this.itemRotation = 0f;
								NetMessage.SendData(13, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
								NetMessage.SendData(41, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
							}
							else
							{
								this.itemRotation = (float)Math.Atan2((double)(num79 * (float)this.direction), (double)(num78 * (float)this.direction)) - this.fullRotation;
								NetMessage.SendData(13, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
								NetMessage.SendData(41, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
							}
						}
						if (num71 == 17)
						{
							vector2.X = (float)Main.mouseX + Main.screenPosition.X;
							vector2.Y = (float)Main.mouseY + Main.screenPosition.Y;
							if (this.gravDir == -1f)
							{
								vector2.Y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY;
							}
						}
						if (num71 == 76)
						{
							num71 += Main.rand.Next(3);
							num81 /= (float)(Main.screenHeight / 2);
							if (num81 > 1f)
							{
								num81 = 1f;
							}
							float num83 = num78 + (float)Main.rand.Next(-40, 41) * 0.01f;
							float num84 = num79 + (float)Main.rand.Next(-40, 41) * 0.01f;
							num83 *= num81 + 0.25f;
							num84 *= num81 + 0.25f;
							int num85 = Projectile.NewProjectile(vector2.X, vector2.Y, num83, num84, num71, num73, num74, i, 0f, 0f);
							Main.projectile[num85].ai[1] = 1f;
							num81 = num81 * 2f - 1f;
							if (num81 < -1f)
							{
								num81 = -1f;
							}
							if (num81 > 1f)
							{
								num81 = 1f;
							}
							Main.projectile[num85].ai[0] = num81;
							NetMessage.SendData(27, -1, -1, "", num85, 0f, 0f, 0f, 0, 0, 0);
						}
						else if (item.type == 3029)
						{
							int num86 = 3;
							if (Main.rand.Next(3) == 0)
							{
								num86++;
							}
							for (int num87 = 0; num87 < num86; num87++)
							{
								vector2 = new Vector2(this.position.X + (float)this.width * 0.5f + (float)(Main.rand.Next(201) * -(float)this.direction) + ((float)Main.mouseX + Main.screenPosition.X - this.position.X), this.MountedCenter.Y - 600f);
								vector2.X = (vector2.X * 10f + base.Center.X) / 11f + (float)Main.rand.Next(-100, 101);
								vector2.Y -= (float)(150 * num87);
								num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
								num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
								if (num79 < 0f)
								{
									num79 *= -1f;
								}
								if (num79 < 20f)
								{
									num79 = 20f;
								}
								num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
								num80 = num72 / num80;
								num78 *= num80;
								num79 *= num80;
								float num88 = num78 + (float)Main.rand.Next(-40, 41) * 0.03f;
								float speedY = num79 + (float)Main.rand.Next(-40, 41) * 0.03f;
								num88 *= (float)Main.rand.Next(75, 150) * 0.01f;
								vector2.X += (float)Main.rand.Next(-50, 51);
								int num89 = Projectile.NewProjectile(vector2.X, vector2.Y, num88, speedY, num71, num73, num74, i, 0f, 0f);
								Main.projectile[num89].noDropItem = true;
							}
						}
						else if (item.type == 98 || item.type == 533)
						{
							float speedX = num78 + (float)Main.rand.Next(-40, 41) * 0.01f;
							float speedY2 = num79 + (float)Main.rand.Next(-40, 41) * 0.01f;
							Projectile.NewProjectile(vector2.X, vector2.Y, speedX, speedY2, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 1319)
						{
							float speedX2 = num78 + (float)Main.rand.Next(-40, 41) * 0.02f;
							float speedY3 = num79 + (float)Main.rand.Next(-40, 41) * 0.02f;
							int num90 = Projectile.NewProjectile(vector2.X, vector2.Y, speedX2, speedY3, num71, num73, num74, i, 0f, 0f);
							Main.projectile[num90].ranged = true;
							Main.projectile[num90].thrown = false;
						}
						else if (item.type == 3107)
						{
							float speedX3 = num78 + (float)Main.rand.Next(-40, 41) * 0.02f;
							float speedY4 = num79 + (float)Main.rand.Next(-40, 41) * 0.02f;
							Projectile.NewProjectile(vector2.X, vector2.Y, speedX3, speedY4, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 3053)
						{
							Vector2 value2 = new Vector2(num78, num79);
							value2.Normalize();
							Vector2 value3 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
							value3.Normalize();
							value2 = value2 * 4f + value3;
							value2.Normalize();
							value2 *= item.shootSpeed;
							float num91 = (float)Main.rand.Next(10, 80) * 0.001f;
							if (Main.rand.Next(2) == 0)
							{
								num91 *= -1f;
							}
							float num92 = (float)Main.rand.Next(10, 80) * 0.001f;
							if (Main.rand.Next(2) == 0)
							{
								num92 *= -1f;
							}
							Projectile.NewProjectile(vector2.X, vector2.Y, value2.X, value2.Y, num71, num73, num74, i, num92, num91);
						}
						else if (item.type == 3019)
						{
							Vector2 value4 = new Vector2(num78, num79);
							float num93 = value4.Length();
							value4.X += (float)Main.rand.Next(-100, 101) * 0.01f * num93 * 0.15f;
							value4.Y += (float)Main.rand.Next(-100, 101) * 0.01f * num93 * 0.15f;
							float num94 = num78 + (float)Main.rand.Next(-40, 41) * 0.03f;
							float num95 = num79 + (float)Main.rand.Next(-40, 41) * 0.03f;
							value4.Normalize();
							value4 *= num93;
							num94 *= (float)Main.rand.Next(50, 150) * 0.01f;
							num95 *= (float)Main.rand.Next(50, 150) * 0.01f;
							Vector2 value5 = new Vector2(num94, num95);
							value5.X += (float)Main.rand.Next(-100, 101) * 0.025f;
							value5.Y += (float)Main.rand.Next(-100, 101) * 0.025f;
							value5.Normalize();
							value5 *= num93;
							num94 = value5.X;
							num95 = value5.Y;
							Projectile.NewProjectile(vector2.X, vector2.Y, num94, num95, num71, num73, num74, i, value4.X, value4.Y);
						}
						else if (item.type == 2797)
						{
							Vector2 value6 = Vector2.Normalize(new Vector2(num78, num79)) * 40f * item.scale;
							if (Collision.CanHit(vector2, 0, 0, vector2 + value6, 0, 0))
							{
								vector2 += value6;
							}
							float ai = new Vector2(num78, num79).ToRotation();
							float num96 = 2.09439516f;
							int num97 = Main.rand.Next(4, 5);
							if (Main.rand.Next(4) == 0)
							{
								num97++;
							}
							for (int num98 = 0; num98 < num97; num98++)
							{
								float scaleFactor2 = (float)Main.rand.NextDouble() * 0.2f + 0.05f;
								Vector2 vector6 = new Vector2(num78, num79).RotatedBy((double)(num96 * (float)Main.rand.NextDouble() - num96 / 2f), default(Vector2)) * scaleFactor2;
								int num99 = Projectile.NewProjectile(vector2.X, vector2.Y, vector6.X, vector6.Y, 444, num73, num74, i, ai, 0f);
								Main.projectile[num99].localAI[0] = (float)num71;
								Main.projectile[num99].localAI[1] = num72;
							}
						}
						else if (item.type == 2270)
						{
							float num100 = num78 + (float)Main.rand.Next(-40, 41) * 0.05f;
							float num101 = num79 + (float)Main.rand.Next(-40, 41) * 0.05f;
							if (Main.rand.Next(3) == 0)
							{
								num100 *= 1f + (float)Main.rand.Next(-30, 31) * 0.02f;
								num101 *= 1f + (float)Main.rand.Next(-30, 31) * 0.02f;
							}
							Projectile.NewProjectile(vector2.X, vector2.Y, num100, num101, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 1930)
						{
							int num102 = 2 + Main.rand.Next(3);
							for (int num103 = 0; num103 < num102; num103++)
							{
								float num104 = num78;
								float num105 = num79;
								float num106 = 0.025f * (float)num103;
								num104 += (float)Main.rand.Next(-35, 36) * num106;
								num105 += (float)Main.rand.Next(-35, 36) * num106;
								num80 = (float)Math.Sqrt((double)(num104 * num104 + num105 * num105));
								num80 = num72 / num80;
								num104 *= num80;
								num105 *= num80;
								float x = vector2.X + num78 * (float)(num102 - num103) * 1.75f;
								float y = vector2.Y + num79 * (float)(num102 - num103) * 1.75f;
								Projectile.NewProjectile(x, y, num104, num105, num71, num73, num74, i, (float)Main.rand.Next(0, 10 * (num103 + 1)), 0f);
							}
						}
						else if (item.type == 1931)
						{
							int num107 = 2;
							for (int num108 = 0; num108 < num107; num108++)
							{
								vector2 = new Vector2(this.position.X + (float)this.width * 0.5f + (float)(Main.rand.Next(201) * -(float)this.direction) + ((float)Main.mouseX + Main.screenPosition.X - this.position.X), this.MountedCenter.Y - 600f);
								vector2.X = (vector2.X + base.Center.X) / 2f + (float)Main.rand.Next(-200, 201);
								vector2.Y -= (float)(100 * num108);
								num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
								num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
								if (num79 < 0f)
								{
									num79 *= -1f;
								}
								if (num79 < 20f)
								{
									num79 = 20f;
								}
								num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
								num80 = num72 / num80;
								num78 *= num80;
								num79 *= num80;
								float speedX4 = num78 + (float)Main.rand.Next(-40, 41) * 0.02f;
								float speedY5 = num79 + (float)Main.rand.Next(-40, 41) * 0.02f;
								Projectile.NewProjectile(vector2.X, vector2.Y, speedX4, speedY5, num71, num73, num74, i, 0f, (float)Main.rand.Next(5));
							}
						}
						else if (item.type == 2750)
						{
							int num109 = 1;
							for (int num110 = 0; num110 < num109; num110++)
							{
								vector2 = new Vector2(this.position.X + (float)this.width * 0.5f + (float)(Main.rand.Next(201) * -(float)this.direction) + ((float)Main.mouseX + Main.screenPosition.X - this.position.X), this.MountedCenter.Y - 600f);
								vector2.X = (vector2.X + base.Center.X) / 2f + (float)Main.rand.Next(-200, 201);
								vector2.Y -= (float)(100 * num110);
								num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X + (float)Main.rand.Next(-40, 41) * 0.03f;
								num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
								if (num79 < 0f)
								{
									num79 *= -1f;
								}
								if (num79 < 20f)
								{
									num79 = 20f;
								}
								num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
								num80 = num72 / num80;
								num78 *= num80;
								num79 *= num80;
								float num111 = num78;
								float num112 = num79 + (float)Main.rand.Next(-40, 41) * 0.02f;
								Projectile.NewProjectile(vector2.X, vector2.Y, num111 * 0.75f, num112 * 0.75f, num71 + Main.rand.Next(3), num73, num74, i, 0f, 0.5f + (float)Main.rand.NextDouble() * 0.3f);
							}
						}
						else if (item.type == 3570)
						{
							int num113 = 3;
							for (int num114 = 0; num114 < num113; num114++)
							{
								vector2 = new Vector2(this.position.X + (float)this.width * 0.5f + (float)(Main.rand.Next(201) * -(float)this.direction) + ((float)Main.mouseX + Main.screenPosition.X - this.position.X), this.MountedCenter.Y - 600f);
								vector2.X = (vector2.X + base.Center.X) / 2f + (float)Main.rand.Next(-200, 201);
								vector2.Y -= (float)(100 * num114);
								num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
								num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
								float ai2 = num79 + vector2.Y;
								if (num79 < 0f)
								{
									num79 *= -1f;
								}
								if (num79 < 20f)
								{
									num79 = 20f;
								}
								num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
								num80 = num72 / num80;
								num78 *= num80;
								num79 *= num80;
								Vector2 vector7 = new Vector2(num78, num79) / 2f;
								Projectile.NewProjectile(vector2.X, vector2.Y, vector7.X, vector7.Y, num71, num73, num74, i, 0f, ai2);
							}
						}
						else if (item.type == 3065)
						{
							Vector2 value7 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
							float num115 = value7.Y;
							if (num115 > base.Center.Y - 200f)
							{
								num115 = base.Center.Y - 200f;
							}
							for (int num116 = 0; num116 < 3; num116++)
							{
								vector2 = base.Center + new Vector2((float)(-(float)Main.rand.Next(0, 401) * this.direction), -600f);
								vector2.Y -= (float)(100 * num116);
								Vector2 value8 = value7 - vector2;
								if (value8.Y < 0f)
								{
									value8.Y *= -1f;
								}
								if (value8.Y < 20f)
								{
									value8.Y = 20f;
								}
								value8.Normalize();
								value8 *= num72;
								num78 = value8.X;
								num79 = value8.Y;
								float speedX5 = num78;
								float speedY6 = num79 + (float)Main.rand.Next(-40, 41) * 0.02f;
								Projectile.NewProjectile(vector2.X, vector2.Y, speedX5, speedY6, num71, num73 * 2, num74, i, 0f, num115);
							}
						}
						else if (item.type == 2624)
						{
							float num117 = 0.314159274f;
							int num118 = 5;
							Vector2 vector8 = new Vector2(num78, num79);
							vector8.Normalize();
							vector8 *= 40f;
							bool flag12 = Collision.CanHit(vector2, 0, 0, vector2 + vector8, 0, 0);
							for (int num119 = 0; num119 < num118; num119++)
							{
								float num120 = (float)num119 - ((float)num118 - 1f) / 2f;
								Vector2 value9 = vector8.RotatedBy((double)(num117 * num120), default(Vector2));
								if (!flag12)
								{
									value9 -= vector8;
								}
								int num121 = Projectile.NewProjectile(vector2.X + value9.X, vector2.Y + value9.Y, num78, num79, num71, num73, num74, i, 0f, 0f);
								Main.projectile[num121].noDropItem = true;
							}
						}
						else if (item.type == 1929)
						{
							float speedX6 = num78 + (float)Main.rand.Next(-40, 41) * 0.03f;
							float speedY7 = num79 + (float)Main.rand.Next(-40, 41) * 0.03f;
							Projectile.NewProjectile(vector2.X, vector2.Y, speedX6, speedY7, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 1553)
						{
							float speedX7 = num78 + (float)Main.rand.Next(-40, 41) * 0.005f;
							float speedY8 = num79 + (float)Main.rand.Next(-40, 41) * 0.005f;
							Projectile.NewProjectile(vector2.X, vector2.Y, speedX7, speedY8, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 518)
						{
							float num122 = num78;
							float num123 = num79;
							num122 += (float)Main.rand.Next(-40, 41) * 0.04f;
							num123 += (float)Main.rand.Next(-40, 41) * 0.04f;
							Projectile.NewProjectile(vector2.X, vector2.Y, num122, num123, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 1265)
						{
							float num124 = num78;
							float num125 = num79;
							num124 += (float)Main.rand.Next(-30, 31) * 0.03f;
							num125 += (float)Main.rand.Next(-30, 31) * 0.03f;
							Projectile.NewProjectile(vector2.X, vector2.Y, num124, num125, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 534)
						{
							int num126 = Main.rand.Next(4, 6);
							for (int num127 = 0; num127 < num126; num127++)
							{
								float num128 = num78;
								float num129 = num79;
								num128 += (float)Main.rand.Next(-40, 41) * 0.05f;
								num129 += (float)Main.rand.Next(-40, 41) * 0.05f;
								Projectile.NewProjectile(vector2.X, vector2.Y, num128, num129, num71, num73, num74, i, 0f, 0f);
							}
						}
						else if (item.type == 2188)
						{
							int num130 = 4;
							if (Main.rand.Next(3) == 0)
							{
								num130++;
							}
							if (Main.rand.Next(4) == 0)
							{
								num130++;
							}
							if (Main.rand.Next(5) == 0)
							{
								num130++;
							}
							for (int num131 = 0; num131 < num130; num131++)
							{
								float num132 = num78;
								float num133 = num79;
								float num134 = 0.05f * (float)num131;
								num132 += (float)Main.rand.Next(-35, 36) * num134;
								num133 += (float)Main.rand.Next(-35, 36) * num134;
								num80 = (float)Math.Sqrt((double)(num132 * num132 + num133 * num133));
								num80 = num72 / num80;
								num132 *= num80;
								num133 *= num80;
								float x2 = vector2.X;
								float y2 = vector2.Y;
								Projectile.NewProjectile(x2, y2, num132, num133, num71, num73, num74, i, 0f, 0f);
							}
						}
						else if (item.type == 1308)
						{
							int num135 = 3;
							if (Main.rand.Next(3) == 0)
							{
								num135++;
							}
							for (int num136 = 0; num136 < num135; num136++)
							{
								float num137 = num78;
								float num138 = num79;
								float num139 = 0.05f * (float)num136;
								num137 += (float)Main.rand.Next(-35, 36) * num139;
								num138 += (float)Main.rand.Next(-35, 36) * num139;
								num80 = (float)Math.Sqrt((double)(num137 * num137 + num138 * num138));
								num80 = num72 / num80;
								num137 *= num80;
								num138 *= num80;
								float x3 = vector2.X;
								float y3 = vector2.Y;
								Projectile.NewProjectile(x3, y3, num137, num138, num71, num73, num74, i, 0f, 0f);
							}
						}
						else if (item.type == 1258)
						{
							float num140 = num78;
							float num141 = num79;
							num140 += (float)Main.rand.Next(-40, 41) * 0.01f;
							num141 += (float)Main.rand.Next(-40, 41) * 0.01f;
							vector2.X += (float)Main.rand.Next(-40, 41) * 0.05f;
							vector2.Y += (float)Main.rand.Next(-45, 36) * 0.05f;
							Projectile.NewProjectile(vector2.X, vector2.Y, num140, num141, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 964)
						{
							int num142 = Main.rand.Next(3, 5);
							for (int num143 = 0; num143 < num142; num143++)
							{
								float num144 = num78;
								float num145 = num79;
								num144 += (float)Main.rand.Next(-35, 36) * 0.04f;
								num145 += (float)Main.rand.Next(-35, 36) * 0.04f;
								Projectile.NewProjectile(vector2.X, vector2.Y, num144, num145, num71, num73, num74, i, 0f, 0f);
							}
						}
						else if (item.type == 1569)
						{
							int num146 = 4;
							if (Main.rand.Next(2) == 0)
							{
								num146++;
							}
							if (Main.rand.Next(4) == 0)
							{
								num146++;
							}
							if (Main.rand.Next(8) == 0)
							{
								num146++;
							}
							if (Main.rand.Next(16) == 0)
							{
								num146++;
							}
							for (int num147 = 0; num147 < num146; num147++)
							{
								float num148 = num78;
								float num149 = num79;
								float num150 = 0.05f * (float)num147;
								num148 += (float)Main.rand.Next(-35, 36) * num150;
								num149 += (float)Main.rand.Next(-35, 36) * num150;
								num80 = (float)Math.Sqrt((double)(num148 * num148 + num149 * num149));
								num80 = num72 / num80;
								num148 *= num80;
								num149 *= num80;
								float x4 = vector2.X;
								float y4 = vector2.Y;
								Projectile.NewProjectile(x4, y4, num148, num149, num71, num73, num74, i, 0f, 0f);
							}
						}
						else if (item.type == 1244 || item.type == 1256)
						{
							int num154 = Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71, num73, num74, i, 0f, 0f);
							Main.projectile[num154].ai[0] = (float)Main.mouseX + Main.screenPosition.X;
							Main.projectile[num154].ai[1] = (float)Main.mouseY + Main.screenPosition.Y;
						}
						else if (item.type == 1229)
						{
							int num155 = Main.rand.Next(2, 4);
							if (Main.rand.Next(5) == 0)
							{
								num155++;
							}
							for (int num156 = 0; num156 < num155; num156++)
							{
								float num157 = num78;
								float num158 = num79;
								if (num156 > 0)
								{
									num157 += (float)Main.rand.Next(-35, 36) * 0.04f;
									num158 += (float)Main.rand.Next(-35, 36) * 0.04f;
								}
								if (num156 > 1)
								{
									num157 += (float)Main.rand.Next(-35, 36) * 0.04f;
									num158 += (float)Main.rand.Next(-35, 36) * 0.04f;
								}
								if (num156 > 2)
								{
									num157 += (float)Main.rand.Next(-35, 36) * 0.04f;
									num158 += (float)Main.rand.Next(-35, 36) * 0.04f;
								}
								int num159 = Projectile.NewProjectile(vector2.X, vector2.Y, num157, num158, num71, num73, num74, i, 0f, 0f);
								Main.projectile[num159].noDropItem = true;
							}
						}
						else if (item.type == 1121)
						{
							int num160 = Main.rand.Next(1, 4);
							if (Main.rand.Next(6) == 0)
							{
								num160++;
							}
							if (Main.rand.Next(6) == 0)
							{
								num160++;
							}
							if (this.strongBees && Main.rand.Next(3) == 0)
							{
								num160++;
							}
							for (int num161 = 0; num161 < num160; num161++)
							{
								float num162 = num78;
								float num163 = num79;
								num162 += (float)Main.rand.Next(-35, 36) * 0.02f;
								num163 += (float)Main.rand.Next(-35, 36) * 0.02f;
								int num164 = Projectile.NewProjectile(vector2.X, vector2.Y, num162, num163, this.beeType(), this.beeDamage(num73), this.beeKB(num74), i, 0f, 0f);
								Main.projectile[num164].magic = true;
							}
						}
						else if (item.type == 1155)
						{
							int num165 = Main.rand.Next(2, 5);
							if (Main.rand.Next(5) == 0)
							{
								num165++;
							}
							if (Main.rand.Next(5) == 0)
							{
								num165++;
							}
							for (int num166 = 0; num166 < num165; num166++)
							{
								float num167 = num78;
								float num168 = num79;
								num167 += (float)Main.rand.Next(-35, 36) * 0.02f;
								num168 += (float)Main.rand.Next(-35, 36) * 0.02f;
								Projectile.NewProjectile(vector2.X, vector2.Y, num167, num168, num71, num73, num74, i, 0f, 0f);
							}
						}
						else if (item.type == 1801)
						{
							int num169 = Main.rand.Next(1, 4);
							for (int num170 = 0; num170 < num169; num170++)
							{
								float num171 = num78;
								float num172 = num79;
								num171 += (float)Main.rand.Next(-35, 36) * 0.05f;
								num172 += (float)Main.rand.Next(-35, 36) * 0.05f;
								Projectile.NewProjectile(vector2.X, vector2.Y, num171, num172, num71, num73, num74, i, 0f, 0f);
							}
						}
						else if (item.type == 679)
						{
							for (int num173 = 0; num173 < 6; num173++)
							{
								float num174 = num78;
								float num175 = num79;
								num174 += (float)Main.rand.Next(-40, 41) * 0.05f;
								num175 += (float)Main.rand.Next(-40, 41) * 0.05f;
								Projectile.NewProjectile(vector2.X, vector2.Y, num174, num175, num71, num73, num74, i, 0f, 0f);
							}
						}
						else if (item.type == 2623)
						{
							for (int num176 = 0; num176 < 3; num176++)
							{
								float num177 = num78;
								float num178 = num79;
								num177 += (float)Main.rand.Next(-40, 41) * 0.1f;
								num178 += (float)Main.rand.Next(-40, 41) * 0.1f;
								Projectile.NewProjectile(vector2.X, vector2.Y, num177, num178, num71, num73, num74, i, 0f, 0f);
							}
						}
						else if (item.type == 3210)
						{
							Vector2 value10 = new Vector2(num78, num79);
							value10.X += (float)Main.rand.Next(-30, 31) * 0.04f;
							value10.Y += (float)Main.rand.Next(-30, 31) * 0.03f;
							value10.Normalize();
							value10 *= (float)Main.rand.Next(70, 91) * 0.1f;
							value10.X += (float)Main.rand.Next(-30, 31) * 0.04f;
							value10.Y += (float)Main.rand.Next(-30, 31) * 0.03f;
							Projectile.NewProjectile(vector2.X, vector2.Y, value10.X, value10.Y, num71, num73, num74, i, (float)Main.rand.Next(20), 0f);
						}
						else if (item.type == 434)
						{
							float num179 = num78;
							float num180 = num79;
							if (this.itemAnimation < 5)
							{
								num179 += (float)Main.rand.Next(-40, 41) * 0.01f;
								num180 += (float)Main.rand.Next(-40, 41) * 0.01f;
								num179 *= 1.1f;
								num180 *= 1.1f;
							}
							else if (this.itemAnimation < 10)
							{
								num179 += (float)Main.rand.Next(-20, 21) * 0.01f;
								num180 += (float)Main.rand.Next(-20, 21) * 0.01f;
								num179 *= 1.05f;
								num180 *= 1.05f;
							}
							Projectile.NewProjectile(vector2.X, vector2.Y, num179, num180, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 1157)
						{
							num71 = Main.rand.Next(191, 195);
							num78 = 0f;
							num79 = 0f;
							vector2.X = (float)Main.mouseX + Main.screenPosition.X;
							vector2.Y = (float)Main.mouseY + Main.screenPosition.Y;
							int num181 = Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71, num73, num74, i, 0f, 0f);
							Main.projectile[num181].localAI[0] = 30f;
						}
						else if (item.type == 1802)
						{
							num78 = 0f;
							num79 = 0f;
							vector2.X = (float)Main.mouseX + Main.screenPosition.X;
							vector2.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 2364 || item.type == 2365)
						{
							num78 = 0f;
							num79 = 0f;
							vector2.X = (float)Main.mouseX + Main.screenPosition.X;
							vector2.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 2535)
						{
							num78 = 0f;
							num79 = 0f;
							vector2.X = (float)Main.mouseX + Main.screenPosition.X;
							vector2.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Vector2 spinningpoint = new Vector2(num78, num79);
							spinningpoint = spinningpoint.RotatedBy(1.5707963705062866, default(Vector2));
							Projectile.NewProjectile(vector2.X + spinningpoint.X, vector2.Y + spinningpoint.Y, spinningpoint.X, spinningpoint.Y, num71, num73, num74, i, 0f, 0f);
							spinningpoint = spinningpoint.RotatedBy(-3.1415927410125732, default(Vector2));
							Projectile.NewProjectile(vector2.X + spinningpoint.X, vector2.Y + spinningpoint.Y, spinningpoint.X, spinningpoint.Y, num71 + 1, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 2551)
						{
							num78 = 0f;
							num79 = 0f;
							vector2.X = (float)Main.mouseX + Main.screenPosition.X;
							vector2.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71 + Main.rand.Next(3), num73, num74, i, 0f, 0f);
						}
						else if (item.type == 2584)
						{
							num78 = 0f;
							num79 = 0f;
							vector2.X = (float)Main.mouseX + Main.screenPosition.X;
							vector2.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71 + Main.rand.Next(3), num73, num74, i, 0f, 0f);
						}
						else if (item.type == 2621)
						{
							num78 = 0f;
							num79 = 0f;
							vector2.X = (float)Main.mouseX + Main.screenPosition.X;
							vector2.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 2749 || item.type == 3249 || item.type == 3474)
						{
							num78 = 0f;
							num79 = 0f;
							vector2.X = (float)Main.mouseX + Main.screenPosition.X;
							vector2.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 3531)
						{
							int num182 = -1;
							int num183 = -1;
							for (int num184 = 0; num184 < 1000; num184++)
							{
								if (Main.projectile[num184].active && Main.projectile[num184].owner == Main.myPlayer)
								{
									if (num182 == -1 && Main.projectile[num184].type == 625)
									{
										num182 = num184;
									}
									if (num183 == -1 && Main.projectile[num184].type == 628)
									{
										num183 = num184;
									}
									if (num182 != -1 && num183 != -1)
									{
										break;
									}
								}
							}
							if (num182 == -1 && num183 == -1)
							{
								num78 = 0f;
								num79 = 0f;
								vector2.X = (float)Main.mouseX + Main.screenPosition.X;
								vector2.Y = (float)Main.mouseY + Main.screenPosition.Y;
								int num185 = Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71, num73, num74, i, 0f, 0f);
								num185 = Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71 + 1, num73, num74, i, (float)num185, 0f);
								int num186 = num185;
								num185 = Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71 + 2, num73, num74, i, (float)num185, 0f);
								Main.projectile[num186].localAI[1] = (float)num185;
								num186 = num185;
								num185 = Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71 + 3, num73, num74, i, (float)num185, 0f);
								Main.projectile[num186].localAI[1] = (float)num185;
							}
							else if (num182 != -1 && num183 != -1)
							{
								int num187 = Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71 + 1, num73, num74, i, (float)Projectile.GetByUUID(Main.myPlayer, Main.projectile[num183].ai[0]), 0f);
								int num188 = num187;
								num187 = Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71 + 2, num73, num74, i, (float)num187, 0f);
								Main.projectile[num188].localAI[1] = (float)num187;
								Main.projectile[num188].netUpdate = true;
								Main.projectile[num188].ai[1] = 1f;
								Main.projectile[num187].localAI[1] = (float)num183;
								Main.projectile[num187].netUpdate = true;
								Main.projectile[num187].ai[1] = 1f;
								Main.projectile[num183].ai[0] = (float)Main.projectile[num187].projUUID;
								Main.projectile[num183].netUpdate = true;
								Main.projectile[num183].ai[1] = 1f;
							}
						}
						else if (item.type == 1309)
						{
							num78 = 0f;
							num79 = 0f;
							vector2.X = (float)Main.mouseX + Main.screenPosition.X;
							vector2.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.shoot > 0 && (Main.projPet[item.shoot] || item.shoot == 72 || item.shoot == 18 || item.shoot == 500 || item.shoot == 650) && !item.summon)
						{
							for (int num189 = 0; num189 < 1000; num189++)
							{
								if (Main.projectile[num189].active && Main.projectile[num189].owner == this.whoAmI)
								{
									if (item.shoot == 72)
									{
										if (Main.projectile[num189].type == 72 || Main.projectile[num189].type == 86 || Main.projectile[num189].type == 87)
										{
											Main.projectile[num189].Kill();
										}
									}
									else if (item.shoot == Main.projectile[num189].type)
									{
										Main.projectile[num189].Kill();
									}
								}
							}
							Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 3006)
						{
							Vector2 vector9;
							vector9.X = (float)Main.mouseX + Main.screenPosition.X;
							vector9.Y = (float)Main.mouseY + Main.screenPosition.Y;
							while (Collision.CanHitLine(this.position, this.width, this.height, vector2, 1, 1))
							{
								vector2.X += num78;
								vector2.Y += num79;
								if ((vector2 - vector9).Length() < 20f + Math.Abs(num78) + Math.Abs(num79))
								{
									vector2 = vector9;
									break;
								}
							}
							Projectile.NewProjectile(vector2.X, vector2.Y, 0f, 0f, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 3014)
						{
							Vector2 vector10;
							vector10.X = (float)Main.mouseX + Main.screenPosition.X;
							vector10.Y = (float)Main.mouseY + Main.screenPosition.Y;
							while (Collision.CanHitLine(this.position, this.width, this.height, vector2, 1, 1))
							{
								vector2.X += num78;
								vector2.Y += num79;
								if ((vector2 - vector10).Length() < 20f + Math.Abs(num78) + Math.Abs(num79))
								{
									vector2 = vector10;
									break;
								}
							}
							bool flag14 = false;
							int num190 = (int)vector2.Y / 16;
							int num191 = (int)vector2.X / 16;
							int num192 = num190;
							while (num190 < Main.maxTilesY - 10 && num190 - num192 < 30 && !WorldGen.SolidTile(num191, num190) && !TileID.Sets.Platforms[(int)Main.tile[num191, num190].type])
							{
								num190++;
							}
							if (!WorldGen.SolidTile(num191, num190) && !TileID.Sets.Platforms[(int)Main.tile[num191, num190].type])
							{
								flag14 = true;
							}
							float num193 = (float)(num190 * 16);
							num190 = num192;
							while (num190 > 10 && num192 - num190 < 30 && !WorldGen.SolidTile(num191, num190))
							{
								num190--;
							}
							float num194 = (float)(num190 * 16 + 16);
							float num195 = num193 - num194;
							int num196 = 10;
							if (num195 > (float)(16 * num196))
							{
								num195 = (float)(16 * num196);
							}
							num194 = num193 - num195;
							vector2.X = (float)((int)(vector2.X / 16f) * 16);
							if (!flag14)
							{
								Projectile.NewProjectile(vector2.X, vector2.Y, 0f, 0f, num71, num73, num74, i, num194, num195);
							}
						}
						else if (item.type == 3384)
						{
							int num197 = (this.altFunctionUse == 2) ? 1 : 0;
							Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71, num73, num74, i, 0f, (float)num197);
						}
						else if (item.type == 3473)
						{
							float ai3 = (Main.rand.NextFloat() - 0.5f) * 0.7853982f;
							Vector2 vector11 = new Vector2(num78, num79);
							Projectile.NewProjectile(vector2.X, vector2.Y, vector11.X, vector11.Y, num71, num73, num74, i, 0f, ai3);
						}
						else if (item.type == 3542)
						{
							float num198 = (Main.rand.NextFloat() - 0.5f) * 0.7853982f * 0.7f;
							int num199 = 0;
							while (num199 < 10 && !Collision.CanHit(vector2, 0, 0, vector2 + new Vector2(num78, num79).RotatedBy((double)num198, default(Vector2)) * 100f, 0, 0))
							{
								num198 = (Main.rand.NextFloat() - 0.5f) * 0.7853982f * 0.7f;
								num199++;
							}
							Vector2 vector12 = new Vector2(num78, num79).RotatedBy((double)num198, default(Vector2)) * (0.95f + Main.rand.NextFloat() * 0.3f);
							Projectile.NewProjectile(vector2.X, vector2.Y, vector12.X, vector12.Y, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 3779)
						{
							float num200 = Main.rand.NextFloat() * 6.28318548f;
							int num201 = 0;
							while (num201 < 10 && !Collision.CanHit(vector2, 0, 0, vector2 + new Vector2(num78, num79).RotatedBy((double)num200, default(Vector2)) * 100f, 0, 0))
							{
								num200 = Main.rand.NextFloat() * 6.28318548f;
								num201++;
							}
							Vector2 value11 = new Vector2(num78, num79).RotatedBy((double)num200, default(Vector2)) * (0.95f + Main.rand.NextFloat() * 0.3f);
							Projectile.NewProjectile(vector2 + value11 * 30f, Vector2.Zero, num71, num73, num74, i, -2f, 0f);
						}
						else if (item.type == 3787)
						{
							float f = Main.rand.NextFloat() * 6.28318548f;
							float value12 = 20f;
							float value13 = 60f;
							Vector2 vector13 = vector2 + f.ToRotationVector2() * MathHelper.Lerp(value12, value13, Main.rand.NextFloat());
							for (int num202 = 0; num202 < 50; num202++)
							{
								vector13 = vector2 + f.ToRotationVector2() * MathHelper.Lerp(value12, value13, Main.rand.NextFloat());
								if (Collision.CanHit(vector2, 0, 0, vector13 + (vector13 - vector2).SafeNormalize(Vector2.UnitX) * 8f, 0, 0))
								{
									break;
								}
								f = Main.rand.NextFloat() * 6.28318548f;
							}
							Vector2 mouseWorld = Main.MouseWorld;
							Vector2 vector14 = mouseWorld - vector13;
							Vector2 vector15 = new Vector2(num78, num79).SafeNormalize(Vector2.UnitY) * num72;
							vector14 = vector14.SafeNormalize(vector15) * num72;
							vector14 = Vector2.Lerp(vector14, vector15, 0.25f);
							Projectile.NewProjectile(vector13, vector14, num71, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 3788)
						{
							Vector2 vector16 = new Vector2(num78, num79);
							float num203 = 0.7853982f;
							for (int num204 = 0; num204 < 2; num204++)
							{
								Projectile.NewProjectile(vector2, vector16 + vector16.SafeNormalize(Vector2.Zero).RotatedBy((double)(num203 * (Main.rand.NextFloat() * 0.5f + 0.5f)), default(Vector2)) * Main.rand.NextFloatDirection() * 2f, num71, num73, num74, i, 0f, 0f);
								Projectile.NewProjectile(vector2, vector16 + vector16.SafeNormalize(Vector2.Zero).RotatedBy((double)(-(double)num203 * (Main.rand.NextFloat() * 0.5f + 0.5f)), default(Vector2)) * Main.rand.NextFloatDirection() * 2f, num71, num73, num74, i, 0f, 0f);
							}
							Projectile.NewProjectile(vector2, vector16.SafeNormalize(Vector2.UnitX * (float)this.direction) * (num72 * 1.3f), 661, num73 * 2, num74, i, 0f, 0f);
						}
						else if (item.type == 3475)
						{
							Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, 615, num73, num74, i, (float)(5 * Main.rand.Next(0, 20)), 0f);
						}
						else if (item.type == 3540)
						{
							Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, 630, num73, num74, i, 0f, 0f);
						}
						else if (item.type == 3546)
						{
							for (int num205 = 0; num205 < 2; num205++)
							{
								float num206 = num78;
								float num207 = num79;
								num206 += (float)Main.rand.Next(-40, 41) * 0.05f;
								num207 += (float)Main.rand.Next(-40, 41) * 0.05f;
								Vector2 vector17 = vector2 + Vector2.Normalize(new Vector2(num206, num207).RotatedBy((double)(-1.57079637f * (float)this.direction), default(Vector2))) * 6f;
								Projectile.NewProjectile(vector17.X, vector17.Y, num206, num207, 167 + Main.rand.Next(4), num73, num74, i, 0f, 1f);
							}
						}
						else if (item.type == 3350)
						{
							float num208 = num78;
							float num209 = num79;
							num208 += (float)Main.rand.Next(-1, 2) * 0.5f;
							num209 += (float)Main.rand.Next(-1, 2) * 0.5f;
							if (Collision.CanHitLine(base.Center, 0, 0, vector2 + new Vector2(num208, num209) * 2f, 0, 0))
							{
								vector2 += new Vector2(num208, num209);
							}
							Projectile.NewProjectile(vector2.X, vector2.Y - this.gravDir * 4f, num208, num209, num71, num73, num74, i, 0f, (float)Main.rand.Next(12) / 6f);
						}
						else
						{
							int num210 = Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, num71, num73, num74, i, 0f, 0f);
							if (item.type == 726)
							{
								Main.projectile[num210].magic = true;
							}
							if (item.type == 724 || item.type == 676)
							{
								Main.projectile[num210].melee = true;
							}
							if (num71 == 80)
							{
								Main.projectile[num210].ai[0] = (float)Player.tileTargetX;
								Main.projectile[num210].ai[1] = (float)Player.tileTargetY;
							}
							if (num71 == 442)
							{
								Main.projectile[num210].ai[0] = (float)Player.tileTargetX;
								Main.projectile[num210].ai[1] = (float)Player.tileTargetY;
							}
							if ((this.thrownCost50 || this.thrownCost33) && this.inventory[this.selectedItem].thrown)
							{
								Main.projectile[num210].noDropItem = true;
							}
							if (Main.projectile[num210].aiStyle == 99)
							{
								AchievementsHelper.HandleSpecialEvent(this, 7);
							}
						}
					}
					else if (item.useStyle == 5)
					{
						this.itemRotation = 0f;
						NetMessage.SendData(41, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				if (this.whoAmI == Main.myPlayer && (item.type == 509 || item.type == 510 || item.type == 849 || item.type == 850 || item.type == 851 || item.type == 3612 || item.type == 3620 || item.type == 3625) && this.position.X / 16f - (float)Player.tileRangeX - (float)item.tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)item.tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)item.tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)item.tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
				{
					if (this.itemAnimation > 0 && this.itemTime == 0 && this.controlUseItem)
					{
						int num211 = Player.tileTargetX;
						int num212 = Player.tileTargetY;
						if (item.type == 509)
						{
							int num213 = -1;
							for (int num214 = 0; num214 < 58; num214++)
							{
								if (this.inventory[num214].stack > 0 && this.inventory[num214].type == 530)
								{
									num213 = num214;
									break;
								}
							}
							if (num213 >= 0 && WorldGen.PlaceWire(num211, num212))
							{
								this.inventory[num213].stack--;
								if (this.inventory[num213].stack <= 0)
								{
									this.inventory[num213].SetDefaults(0, false);
								}
								this.itemTime = item.useTime;
								NetMessage.SendData(17, -1, -1, "", 5, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
							}
						}
						else if (item.type == 850)
						{
							int num215 = -1;
							for (int num216 = 0; num216 < 58; num216++)
							{
								if (this.inventory[num216].stack > 0 && this.inventory[num216].type == 530)
								{
									num215 = num216;
									break;
								}
							}
							if (num215 >= 0 && WorldGen.PlaceWire2(num211, num212))
							{
								this.inventory[num215].stack--;
								if (this.inventory[num215].stack <= 0)
								{
									this.inventory[num215].SetDefaults(0, false);
								}
								this.itemTime = item.useTime;
								NetMessage.SendData(17, -1, -1, "", 10, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
							}
						}
						if (item.type == 851)
						{
							int num217 = -1;
							for (int num218 = 0; num218 < 58; num218++)
							{
								if (this.inventory[num218].stack > 0 && this.inventory[num218].type == 530)
								{
									num217 = num218;
									break;
								}
							}
							if (num217 >= 0 && WorldGen.PlaceWire3(num211, num212))
							{
								this.inventory[num217].stack--;
								if (this.inventory[num217].stack <= 0)
								{
									this.inventory[num217].SetDefaults(0, false);
								}
								this.itemTime = item.useTime;
								NetMessage.SendData(17, -1, -1, "", 12, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
							}
						}
						if (item.type == 3612)
						{
							int num219 = -1;
							for (int num220 = 0; num220 < 58; num220++)
							{
								if (this.inventory[num220].stack > 0 && this.inventory[num220].type == 530)
								{
									num219 = num220;
									break;
								}
							}
							if (num219 >= 0 && WorldGen.PlaceWire4(num211, num212))
							{
								this.inventory[num219].stack--;
								if (this.inventory[num219].stack <= 0)
								{
									this.inventory[num219].SetDefaults(0, false);
								}
								this.itemTime = item.useTime;
								NetMessage.SendData(17, -1, -1, "", 16, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
							}
						}
						else if (item.type == 510)
						{
							if (WorldGen.KillActuator(num211, num212))
							{
								this.itemTime = item.useTime;
								NetMessage.SendData(17, -1, -1, "", 9, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
							}
							else if (WorldGen.KillWire4(num211, num212))
							{
								this.itemTime = item.useTime;
								NetMessage.SendData(17, -1, -1, "", 17, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
							}
							else if (WorldGen.KillWire3(num211, num212))
							{
								this.itemTime = item.useTime;
								NetMessage.SendData(17, -1, -1, "", 13, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
							}
							else if (WorldGen.KillWire2(num211, num212))
							{
								this.itemTime = item.useTime;
								NetMessage.SendData(17, -1, -1, "", 11, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
							}
							else if (WorldGen.KillWire(num211, num212))
							{
								this.itemTime = item.useTime;
								NetMessage.SendData(17, -1, -1, "", 6, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
							}
						}
						else if (item.type == 849 && item.stack > 0 && WorldGen.PlaceActuator(num211, num212))
						{
							this.itemTime = item.useTime;
							NetMessage.SendData(17, -1, -1, "", 8, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
							item.stack--;
							if (item.stack <= 0)
							{
								item.SetDefaults(0, false);
							}
						}
						if (item.type == 3620)
						{
							Tile tile2 = Main.tile[num211, num212];
							if (tile2 != null && tile2.actuator())
							{
								bool flag15 = tile2.inActive();
								if ((!this.ActuationRodLock || this.ActuationRodLockSetting == tile2.inActive()) && Wiring.Actuate(num211, num212) && flag15 != tile2.inActive())
								{
									this.ActuationRodLock = true;
									this.ActuationRodLockSetting = !tile2.inActive();
									this.itemTime = item.useTime;
									NetMessage.SendData(17, -1, -1, "", 19, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
								}
							}
						}
						if (item.type == 3625)
						{
							Point point = new Point(Player.tileTargetX, Player.tileTargetY);
							this.itemTime = item.useTime;
							WiresUI.Settings.MultiToolMode toolMode = WiresUI.Settings.ToolMode;
							WiresUI.Settings.ToolMode &= ~WiresUI.Settings.MultiToolMode.Actuator;
							if (Main.netMode == 1)
							{
								NetMessage.SendData(109, -1, -1, "", point.X, (float)point.Y, (float)point.X, (float)point.Y, (int)WiresUI.Settings.ToolMode, 0, 0);
							}
							else
							{
								Wiring.MassWireOperation(point, point, this);
							}
							WiresUI.Settings.ToolMode = toolMode;
						}
					}
				}
				if (this.itemAnimation > 0 && this.itemTime == 0 && (item.type == 507 || item.type == 508))
				{
					this.itemTime = item.useTime;
					Vector2 vector18 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
					float num221 = (float)Main.mouseX + Main.screenPosition.X - vector18.X;
					float num222 = (float)Main.mouseY + Main.screenPosition.Y - vector18.Y;
					float num223 = (float)Math.Sqrt((double)(num221 * num221 + num222 * num222));
					num223 /= (float)(Main.screenHeight / 2);
					if (num223 > 1f)
					{
						num223 = 1f;
					}
					num223 = num223 * 2f - 1f;
					if (num223 < -1f)
					{
						num223 = -1f;
					}
					if (num223 > 1f)
					{
						num223 = 1f;
					}
					Main.harpNote = num223;
					int style = 26;
					if (item.type == 507)
					{
						style = 35;
					}
					NetMessage.SendData(58, -1, -1, "", this.whoAmI, num223, 0f, 0f, 0, 0, 0);
				}
				if (((item.type >= 205 && item.type <= 207) || item.type == 1128 || item.type == 3031 || item.type == 3032) && this.position.X / 16f - (float)Player.tileRangeX - (float)item.tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)item.tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)item.tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)item.tileBoost - 2f >= (float)Player.tileTargetY)
				{
					if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
					{
						if (item.type == 205 || (item.type == 3032 && Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 0))
						{
							int num224 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType();
							int num225 = 0;
							for (int num226 = Player.tileTargetX - 1; num226 <= Player.tileTargetX + 1; num226++)
							{
								for (int num227 = Player.tileTargetY - 1; num227 <= Player.tileTargetY + 1; num227++)
								{
									if ((int)Main.tile[num226, num227].liquidType() == num224)
									{
										num225 += (int)Main.tile[num226, num227].liquid;
									}
								}
							}
							if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0 && (num225 > 100 || item.type == 3032))
							{
								int liquidType = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType();
								if (item.type != 3032)
								{
									if (!Main.tile[Player.tileTargetX, Player.tileTargetY].lava())
									{
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].honey())
										{
											item.stack--;
											this.PutItemInInventory(1128, this.selectedItem);
										}
										else
										{
											item.stack--;
											this.PutItemInInventory(206, this.selectedItem);
										}
									}
									else
									{
										item.stack--;
										this.PutItemInInventory(207, this.selectedItem);
									}
								}
								this.itemTime = item.useTime;
								int num228 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquid;
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
								for (int num229 = Player.tileTargetX - 1; num229 <= Player.tileTargetX + 1; num229++)
								{
									for (int num230 = Player.tileTargetY - 1; num230 <= Player.tileTargetY + 1; num230++)
									{
										if (num228 < 256 && (int)Main.tile[num229, num230].liquidType() == num224)
										{
											int num231 = (int)Main.tile[num229, num230].liquid;
											if (num231 + num228 > 255)
											{
												num231 = 255 - num228;
											}
											num228 += num231;
											Tile expr_A0F9 = Main.tile[num229, num230];
											expr_A0F9.liquid -= (byte)num231;
											Main.tile[num229, num230].liquidType(liquidType);
											if (Main.tile[num229, num230].liquid == 0)
											{
												Main.tile[num229, num230].lava(false);
												Main.tile[num229, num230].honey(false);
											}
											WorldGen.SquareTileFrame(num229, num230, false);
											if (Main.netMode == 1)
											{
												NetMessage.sendWater(num229, num230);
											}
											else
											{
												Liquid.AddWater(num229, num230);
											}
										}
									}
								}
							}
						}
						else if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid < 200 && (!Main.tile[Player.tileTargetX, Player.tileTargetY].nactive() || !Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tileSolidTop[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
						{
							if (item.type == 207)
							{
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 1)
								{
									Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType(1);
									Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 255;
									WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
									item.stack--;
									this.PutItemInInventory(205, this.selectedItem);
									this.itemTime = item.useTime;
									if (Main.netMode == 1)
									{
										NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
									}
								}
							}
							else if (item.type == 206 || item.type == 3031)
							{
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 0)
								{
									Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType(0);
									Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 255;
									WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
									if (item.type != 3031)
									{
										item.stack--;
										this.PutItemInInventory(205, this.selectedItem);
									}
									this.itemTime = item.useTime;
									if (Main.netMode == 1)
									{
										NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
									}
								}
							}
							else if (item.type == 1128 && (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType() == 2))
							{
								Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType(2);
								Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 255;
								WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
								item.stack--;
								this.PutItemInInventory(205, this.selectedItem);
								this.itemTime = item.useTime;
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
						if (item.pick > 0)
						{
							this.toolTime = item.useTime;
						}
						else
						{
							this.toolTime = (int)((float)item.useTime * this.pickSpeed);
						}
					}
				}
				if (item.pick > 0 || item.axe > 0 || item.hammer > 0)
				{
					bool flag16 = this.position.X / 16f - (float)Player.tileRangeX - (float)item.tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)item.tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)item.tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)item.tileBoost - 2f >= (float)Player.tileTargetY;
					if (this.noBuilding)
					{
						flag16 = false;
					}
					if (flag16)
					{
						int num232 = 0;
						bool flag17 = true;
						if (this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem && (!Main.tile[Player.tileTargetX, Player.tileTargetY].active() || (!Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] && !Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] && Main.tile[Player.tileTargetX, Player.tileTargetY].type != 314 && Main.tile[Player.tileTargetX, Player.tileTargetY].type != 424 && Main.tile[Player.tileTargetX, Player.tileTargetY].type != 442 && Main.tile[Player.tileTargetX, Player.tileTargetY].type != 351)))
						{
							this.poundRelease = false;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].active())
						{
							if ((item.pick > 0 && !Main.tileAxe[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] && !Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]) || (item.axe > 0 && Main.tileAxe[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]) || (item.hammer > 0 && Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
							{
								flag17 = false;
							}
							if (this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
							{
								int tileId = this.hitTile.HitObject(Player.tileTargetX, Player.tileTargetY, 1);
								if (Main.tileNoFail[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
								{
									num232 = 100;
								}
								if (Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
								{
									flag17 = false;
									if (item.hammer > 0)
									{
										num232 += item.hammer;
										if (!WorldGen.CanKillTile(Player.tileTargetX, Player.tileTargetY))
										{
											num232 = 0;
										}
										if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 26 && (item.hammer < 80 || !Main.hardMode))
										{
											num232 = 0;
											this.Hurt(this.statLife / 2, -this.direction, false, false, Lang.deathMsg(-1, -1, -1, 4, 0, 0), false, -1);
										}
										AchievementsHelper.CurrentlyMining = true;
										if (this.hitTile.AddDamage(tileId, num232, true) >= 100)
										{
											this.hitTile.Clear(tileId);
											WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
											}
										}
										else
										{
											WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0, 0, 0);
											}
										}
										if (num232 != 0)
										{
											this.hitTile.Prune();
										}
										this.itemTime = item.useTime;
										AchievementsHelper.CurrentlyMining = false;
									}
								}
								else if (Main.tileAxe[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
								{
									if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 80)
									{
										num232 += item.axe * 3;
									}
									else
									{
										num232 += item.axe;
									}
									if (item.axe > 0)
									{
										AchievementsHelper.CurrentlyMining = true;
										if (!WorldGen.CanKillTile(Player.tileTargetX, Player.tileTargetY))
										{
											num232 = 0;
										}
										if (this.hitTile.AddDamage(tileId, num232, true) >= 100)
										{
											this.hitTile.Clear(tileId);
											WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
											}
										}
										else
										{
											WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0, 0, 0);
											}
										}
										if (num232 != 0)
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
								if (item.hammer > 0 && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && ((Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] && Main.tile[Player.tileTargetX, Player.tileTargetY].type != 10) || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 314 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 351 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 424 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 442) && this.poundRelease)
								{
									flag17 = false;
									this.itemTime = item.useTime;
									num232 += (int)((double)item.hammer * 1.25);
									num232 = 100;
									if (Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active() && Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type == 10)
									{
										num232 = 0;
									}
									if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active() && Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type == 10)
									{
										num232 = 0;
									}
									if (this.hitTile.AddDamage(tileId, num232, true) >= 100)
									{
										this.hitTile.Clear(tileId);
										if (this.poundRelease)
										{
											int num233 = Player.tileTargetX;
											int num234 = Player.tileTargetY;
											if (TileID.Sets.Platforms[(int)Main.tile[num233, num234].type])
											{
												if (Main.tile[num233, num234].halfBrick())
												{
													WorldGen.PoundTile(num233, num234);
													if (Main.netMode == 1)
													{
														NetMessage.SendData(17, -1, -1, "", 7, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0, 0, 0);
													}
												}
												else
												{
													int num235 = 1;
													int slope = 2;
													if (TileID.Sets.Platforms[(int)Main.tile[num233 + 1, num234 - 1].type] || TileID.Sets.Platforms[(int)Main.tile[num233 - 1, num234 + 1].type] || (WorldGen.SolidTile(num233 + 1, num234) && !WorldGen.SolidTile(num233 - 1, num234)))
													{
														num235 = 2;
														slope = 1;
													}
													if (Main.tile[num233, num234].slope() == 0)
													{
														WorldGen.SlopeTile(num233, num234, num235);
														int num236 = (int)Main.tile[num233, num234].slope();
														if (Main.netMode == 1)
														{
															NetMessage.SendData(17, -1, -1, "", 14, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)num236, 0, 0, 0);
														}
													}
													else if ((int)Main.tile[num233, num234].slope() == num235)
													{
														WorldGen.SlopeTile(num233, num234, slope);
														int num237 = (int)Main.tile[num233, num234].slope();
														if (Main.netMode == 1)
														{
															NetMessage.SendData(17, -1, -1, "", 14, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)num237, 0, 0, 0);
														}
													}
													else
													{
														WorldGen.SlopeTile(num233, num234, 0);
														int num238 = (int)Main.tile[num233, num234].slope();
														if (Main.netMode == 1)
														{
															NetMessage.SendData(17, -1, -1, "", 14, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)num238, 0, 0, 0);
														}
														WorldGen.PoundTile(num233, num234);
														if (Main.netMode == 1)
														{
															NetMessage.SendData(17, -1, -1, "", 7, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0, 0, 0);
														}
													}
												}
											}
											else if (Main.tile[num233, num234].type == 314)
											{
												if (Minecart.FrameTrack(num233, num234, true, false) && Main.netMode == 1)
												{
													NetMessage.SendData(17, -1, -1, "", 15, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0, 0, 0);
												}
											}
											else if (Main.tile[num233, num234].type == 137)
											{
												int num239 = 0;
												switch (Main.tile[num233, num234].frameY / 18)
												{
													case 0:
													case 1:
													case 2:
														switch (Main.tile[num233, num234].frameX / 18)
														{
															case 0:
																num239 = 2;
																break;
															case 1:
																num239 = 3;
																break;
															case 2:
																num239 = 4;
																break;
															case 3:
																num239 = 5;
																break;
															case 4:
																num239 = 1;
																break;
															case 5:
																num239 = 0;
																break;
														}
														break;
													case 3:
													case 4:
														switch (Main.tile[num233, num234].frameX / 18)
														{
															case 0:
															case 1:
																num239 = 3;
																break;
															case 2:
																num239 = 4;
																break;
															case 3:
																num239 = 2;
																break;
															case 4:
																num239 = 0;
																break;
														}
														break;
												}
												Main.tile[num233, num234].frameX = (short)(num239 * 18);
												if (Main.netMode == 1)
												{
													NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 1, TileChangeType.None);
												}
											}
											else if (Main.tile[num233, num234].type == 424)
											{
												if (Main.tile[num233, num234].frameX == 0)
												{
													Main.tile[num233, num234].frameX = 18;
												}
												else if (Main.tile[num233, num234].frameX == 18)
												{
													Main.tile[num233, num234].frameX = 36;
												}
												else
												{
													Main.tile[num233, num234].frameX = 0;
												}
												if (Main.netMode == 1)
												{
													NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 1, TileChangeType.None);
												}
											}
											else if (Main.tile[num233, num234].type == 442)
											{
												Tile tile3 = Main.tile[num233, num234 - 1];
												Tile tile4 = Main.tile[num233, num234 + 1];
												Tile tile5 = Main.tile[num233 - 1, num234];
												Tile tile6 = Main.tile[num233 + 1, num234];
												Tile tile7 = Main.tile[num233 - 1, num234 + 1];
												Tile tile8 = Main.tile[num233 + 1, num234 + 1];
												Tile tile9 = Main.tile[num233 - 1, num234 - 1];
												Tile tile10 = Main.tile[num233 + 1, num234 - 1];
												int num240 = -1;
												int num241 = -1;
												int num242 = -1;
												int num243 = -1;
												int num244 = -1;
												int num245 = -1;
												int num246 = -1;
												int num247 = -1;
												if (tile3 != null && tile3.nactive() && !tile3.bottomSlope())
												{
													num241 = (int)tile3.type;
												}
												if (tile4 != null && tile4.nactive() && !tile4.halfBrick() && !tile4.topSlope())
												{
													num240 = (int)tile4.type;
												}
												if (tile5 != null && tile5.nactive() && (tile5.slope() == 0 || tile5.slope() % 2 != 1))
												{
													num242 = (int)tile5.type;
												}
												if (tile6 != null && tile6.nactive() && (tile6.slope() == 0 || tile6.slope() % 2 != 0))
												{
													num243 = (int)tile6.type;
												}
												if (tile7 != null && tile7.nactive())
												{
													num244 = (int)tile7.type;
												}
												if (tile8 != null && tile8.nactive())
												{
													num245 = (int)tile8.type;
												}
												if (tile9 != null && tile9.nactive())
												{
													num246 = (int)tile9.type;
												}
												if (tile10 != null && tile10.nactive())
												{
													num247 = (int)tile10.type;
												}
												bool flag18 = false;
												bool flag19 = false;
												bool flag20 = false;
												bool flag21 = false;
												if (num240 >= 0 && Main.tileSolid[num240] && (!Main.tileNoAttach[num240] || TileID.Sets.Platforms[num240]) && (tile4.bottomSlope() || tile4.slope() == 0) && !tile4.halfBrick())
												{
													flag21 = true;
												}
												if (num241 >= 0 && Main.tileSolid[num241] && (!Main.tileNoAttach[num241] || (TileID.Sets.Platforms[num241] && tile3.halfBrick())) && (tile3.topSlope() || tile3.slope() == 0 || tile3.halfBrick()))
												{
													flag18 = true;
												}
												if ((num242 >= 0 && Main.tileSolid[num242] && !Main.tileNoAttach[num242] && (tile5.leftSlope() || tile5.slope() == 0) && !tile5.halfBrick()) || num242 == 124 || (num242 == 5 && num246 == 5 && num244 == 5))
												{
													flag19 = true;
												}
												if ((num243 >= 0 && Main.tileSolid[num243] && !Main.tileNoAttach[num243] && (tile6.rightSlope() || tile6.slope() == 0) && !tile6.halfBrick()) || num243 == 124 || (num243 == 5 && num247 == 5 && num245 == 5))
												{
													flag20 = true;
												}
												int num248 = (int)(Main.tile[num233, num234].frameX / 22);
												short num249 = -2;
												switch (num248)
												{
													case 0:
														if (flag19)
														{
															num249 = 2;
														}
														else if (flag18)
														{
															num249 = 1;
														}
														else if (flag20)
														{
															num249 = 3;
														}
														else
														{
															num249 = -1;
														}
														break;
													case 1:
														if (flag20)
														{
															num249 = 3;
														}
														else if (flag21)
														{
															num249 = 0;
														}
														else if (flag19)
														{
															num249 = 2;
														}
														else
														{
															num249 = -1;
														}
														break;
													case 2:
														if (flag18)
														{
															num249 = 1;
														}
														else if (flag20)
														{
															num249 = 3;
														}
														else if (flag21)
														{
															num249 = 0;
														}
														else
														{
															num249 = -1;
														}
														break;
													case 3:
														if (flag21)
														{
															num249 = 0;
														}
														else if (flag19)
														{
															num249 = 2;
														}
														else if (flag18)
														{
															num249 = 1;
														}
														else
														{
															num249 = -1;
														}
														break;
												}
												if (num249 != -1)
												{
													if (num249 == -2)
													{
														num249 = 0;
													}
													Main.tile[num233, num234].frameX = (short)(22 * num249);
													if (Main.netMode == 1)
													{
														NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 1, TileChangeType.None);
													}
												}
											}
											else if ((Main.tile[num233, num234].halfBrick() || Main.tile[num233, num234].slope() != 0) && !Main.tileSolidTop[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
											{
												int num250 = 1;
												int num251 = 1;
												int num252 = 2;
												if ((WorldGen.SolidTile(num233 + 1, num234) || Main.tile[num233 + 1, num234].slope() == 1 || Main.tile[num233 + 1, num234].slope() == 3) && !WorldGen.SolidTile(num233 - 1, num234))
												{
													num251 = 2;
													num252 = 1;
												}
												if (WorldGen.SolidTile(num233, num234 - 1) && !WorldGen.SolidTile(num233, num234 + 1))
												{
													num250 = -1;
												}
												if (num250 == 1)
												{
													if (Main.tile[num233, num234].slope() == 0)
													{
														WorldGen.SlopeTile(num233, num234, num251);
													}
													else if ((int)Main.tile[num233, num234].slope() == num251)
													{
														WorldGen.SlopeTile(num233, num234, num252);
													}
													else if ((int)Main.tile[num233, num234].slope() == num252)
													{
														WorldGen.SlopeTile(num233, num234, num251 + 2);
													}
													else if ((int)Main.tile[num233, num234].slope() == num251 + 2)
													{
														WorldGen.SlopeTile(num233, num234, num252 + 2);
													}
													else
													{
														WorldGen.SlopeTile(num233, num234, 0);
													}
												}
												else if (Main.tile[num233, num234].slope() == 0)
												{
													WorldGen.SlopeTile(num233, num234, num251 + 2);
												}
												else if ((int)Main.tile[num233, num234].slope() == num251 + 2)
												{
													WorldGen.SlopeTile(num233, num234, num252 + 2);
												}
												else if ((int)Main.tile[num233, num234].slope() == num252 + 2)
												{
													WorldGen.SlopeTile(num233, num234, num251);
												}
												else if ((int)Main.tile[num233, num234].slope() == num251)
												{
													WorldGen.SlopeTile(num233, num234, num252);
												}
												else
												{
													WorldGen.SlopeTile(num233, num234, 0);
												}
												int num253 = (int)Main.tile[num233, num234].slope();
												if (Main.netMode == 1)
												{
													NetMessage.SendData(17, -1, -1, "", 14, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)num253, 0, 0, 0);
												}
											}
											else
											{
												WorldGen.PoundTile(num233, num234);
												if (Main.netMode == 1)
												{
													NetMessage.SendData(17, -1, -1, "", 7, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0, 0, 0);
												}
											}
											this.poundRelease = false;
										}
									}
									else
									{
										WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, true, false);
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
						int num254 = Player.tileTargetX;
						int num255 = Player.tileTargetY;
						bool flag22 = true;
						if (Main.tile[num254, num255].wall > 0)
						{
							if (!Main.wallHouse[(int)Main.tile[num254, num255].wall])
							{
								for (int num256 = num254 - 1; num256 < num254 + 2; num256++)
								{
									for (int num257 = num255 - 1; num257 < num255 + 2; num257++)
									{
										if (Main.tile[num256, num257].wall != Main.tile[num254, num255].wall)
										{
											flag22 = false;
											break;
										}
									}
								}
							}
							else
							{
								flag22 = false;
							}
						}
						if (flag22 && !Main.tile[num254, num255].active())
						{
							int num258 = -1;
							if ((double)(((float)Main.mouseX + Main.screenPosition.X) / 16f) < Math.Round((double)(((float)Main.mouseX + Main.screenPosition.X) / 16f)))
							{
								num258 = 0;
							}
							int num259 = -1;
							if ((double)(((float)Main.mouseY + Main.screenPosition.Y) / 16f) < Math.Round((double)(((float)Main.mouseY + Main.screenPosition.Y) / 16f)))
							{
								num259 = 0;
							}
							for (int num260 = Player.tileTargetX + num258; num260 <= Player.tileTargetX + num258 + 1; num260++)
							{
								for (int num261 = Player.tileTargetY + num259; num261 <= Player.tileTargetY + num259 + 1; num261++)
								{
									if (flag22)
									{
										num254 = num260;
										num255 = num261;
										if (Main.tile[num254, num255].wall > 0)
										{
											if (!Main.wallHouse[(int)Main.tile[num254, num255].wall])
											{
												for (int num262 = num254 - 1; num262 < num254 + 2; num262++)
												{
													for (int num263 = num255 - 1; num263 < num255 + 2; num263++)
													{
														if (Main.tile[num262, num263].wall != Main.tile[num254, num255].wall)
														{
															flag22 = false;
															break;
														}
													}
												}
											}
											else
											{
												flag22 = false;
											}
										}
									}
								}
							}
						}
						if (flag17 && Main.tile[num254, num255].wall > 0 && (!Main.tile[num254, num255].active() || num254 != Player.tileTargetX || num255 != Player.tileTargetY || (!Main.tileHammer[(int)Main.tile[num254, num255].type] && !this.poundRelease)) && this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem && item.hammer > 0)
						{
							bool flag23 = true;
							if (!Main.wallHouse[(int)Main.tile[num254, num255].wall])
							{
								flag23 = false;
								for (int num264 = num254 - 1; num264 < num254 + 2; num264++)
								{
									for (int num265 = num255 - 1; num265 < num255 + 2; num265++)
									{
										if (Main.tile[num264, num265].wall == 0 || Main.wallHouse[(int)Main.tile[num264, num265].wall])
										{
											flag23 = true;
											break;
										}
									}
								}
							}
							if (flag23)
							{
								int tileId = this.hitTile.HitObject(num254, num255, 2);
								num232 += (int)((float)item.hammer * 1.5f);
								if (this.hitTile.AddDamage(tileId, num232, true) >= 100)
								{
									this.hitTile.Clear(tileId);
									WorldGen.KillWall(num254, num255, false);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 2, (float)num254, (float)num255, 0f, 0, 0, 0);
									}
								}
								else
								{
									WorldGen.KillWall(num254, num255, true);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 2, (float)num254, (float)num255, 1f, 0, 0, 0);
									}
								}
								if (num232 != 0)
								{
									this.hitTile.Prune();
								}
								this.itemTime = item.useTime / 2;
							}
						}
					}
				}
				if (Main.myPlayer == this.whoAmI && item.type == 1326 && this.itemAnimation > 0 && this.itemTime == 0)
				{
					this.itemTime = item.useTime;
					Vector2 vector19;
					vector19.X = (float)Main.mouseX + Main.screenPosition.X;
					if (this.gravDir == 1f)
					{
						vector19.Y = (float)Main.mouseY + Main.screenPosition.Y - (float)this.height;
					}
					else
					{
						vector19.Y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY;
					}
					vector19.X -= (float)(this.width / 2);
					if (vector19.X > 50f && vector19.X < (float)(Main.maxTilesX * 16 - 50) && vector19.Y > 50f && vector19.Y < (float)(Main.maxTilesY * 16 - 50))
					{
						int num266 = (int)(vector19.X / 16f);
						int num267 = (int)(vector19.Y / 16f);
						if ((Main.tile[num266, num267].wall != 87 || (double)num267 <= Main.worldSurface || NPC.downedPlantBoss) && !Collision.SolidCollision(vector19, this.width, this.height))
						{
							this.Teleport(vector19, 1, 0);
							NetMessage.SendData(65, -1, -1, "", 0, (float)this.whoAmI, vector19.X, vector19.Y, 1, 0, 0);
							if (this.chaosState)
							{
								this.statLife -= this.statLifeMax2 / 7;
								if (Lang.lang <= 1)
								{
									string deathText = Language.GetTextValue("Deaths.Teleport_1");
									if (Main.rand.Next(2) == 0)
									{
										if (this.Male)
										{
											deathText = Language.GetTextValue("Deaths.Teleport_2_Male");
										}
										else
										{
											deathText = Language.GetTextValue("Deaths.Teleport_2_Female");
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
							this.AddBuff(88, 360, true);
						}
					}
				}
				if (item.type == 29 && this.itemAnimation > 0 && this.statLifeMax < 400 && this.itemTime == 0)
				{
					this.itemTime = item.useTime;
					this.statLifeMax += 20;
					this.statLifeMax2 += 20;
					this.statLife += 20;
					if (Main.myPlayer == this.whoAmI)
					{
						this.HealEffect(20, true);
					}
					AchievementsHelper.HandleSpecialEvent(this, 0);
				}
				if (item.type == 1291 && this.itemAnimation > 0 && this.statLifeMax >= 400 && this.statLifeMax < 500 && this.itemTime == 0)
				{
					this.itemTime = item.useTime;
					this.statLifeMax += 5;
					this.statLifeMax2 += 5;
					this.statLife += 5;
					if (Main.myPlayer == this.whoAmI)
					{
						this.HealEffect(5, true);
					}
					AchievementsHelper.HandleSpecialEvent(this, 2);
				}
				if (item.type == 109 && this.itemAnimation > 0 && this.statManaMax < 200 && this.itemTime == 0)
				{
					this.itemTime = item.useTime;
					this.statManaMax += 20;
					this.statManaMax2 += 20;
					this.statMana += 20;
					if (Main.myPlayer == this.whoAmI)
					{
						this.ManaEffect(20);
					}
					AchievementsHelper.HandleSpecialEvent(this, 1);
				}
				if (item.type == 3335 && this.itemAnimation > 0 && !this.extraAccessory && Main.expertMode && this.itemTime == 0)
				{
					this.itemTime = item.useTime;
					this.extraAccessory = true;
					NetMessage.SendData(4, -1, -1, Main.player[this.whoAmI].name, this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
				}
				this.PlaceThing();
			}
			if (((item.damage >= 0 && item.type > 0 && !item.noMelee) || item.type == 1450 || item.type == 1991 || item.type == 3183 || item.type == 3542 || item.type == 3779) && this.itemAnimation > 0)
			{
				bool flag24 = false;
				Rectangle r2 = new Rectangle((int)this.itemLocation.X, (int)this.itemLocation.Y, 32, 32);
				r2.Width = (int)((float)r2.Width * item.scale);
				r2.Height = (int)((float)r2.Height * item.scale);
				if (this.direction == -1)
				{
					r2.X -= r2.Width;
				}
				if (this.gravDir == 1f)
				{
					r2.Y -= r2.Height;
				}
				if (item.useStyle == 1)
				{
					if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
					{
						if (this.direction == -1)
						{
							r2.X -= (int)((double)r2.Width * 1.4 - (double)r2.Width);
						}
						r2.Width = (int)((double)r2.Width * 1.4);
						r2.Y += (int)((double)r2.Height * 0.5 * (double)this.gravDir);
						r2.Height = (int)((double)r2.Height * 1.1);
					}
					else if ((double)this.itemAnimation >= (double)this.itemAnimationMax * 0.666)
					{
						if (this.direction == 1)
						{
							r2.X -= (int)((double)r2.Width * 1.2);
						}
						r2.Width *= 2;
						r2.Y -= (int)(((double)r2.Height * 1.4 - (double)r2.Height) * (double)this.gravDir);
						r2.Height = (int)((double)r2.Height * 1.4);
					}
				}
				else if (item.useStyle == 3)
				{
					if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.666)
					{
						flag24 = true;
					}
					else
					{
						if (this.direction == -1)
						{
							r2.X -= (int)((double)r2.Width * 1.4 - (double)r2.Width);
						}
						r2.Width = (int)((double)r2.Width * 1.4);
						r2.Y += (int)((double)r2.Height * 0.6);
						r2.Height = (int)((double)r2.Height * 0.6);
					}
				}
				if (!flag24)
				{
					if (Main.myPlayer == i && (item.damage > 0 || item.type == 3183))
					{
						int num304 = (int)((float)item.damage * this.meleeDamage);
						float num305 = item.knockBack;
						float num306 = 1f;
						if (this.kbGlove)
						{
							num306 += 1f;
						}
						if (this.kbBuff)
						{
							num306 += 0.5f;
						}
						num305 *= num306;
						if (this.inventory[this.selectedItem].type == 3106)
						{
							num305 += num305 * (1f - this.stealth);
						}
						List<ushort> list2 = null;
						int type5 = item.type;
						if (type5 == 213)
						{
							list2 = new List<ushort>(new ushort[]
							{
								3,
								24,
								52,
								61,
								62,
								71,
								73,
								74,
								82,
								83,
								84,
								110,
								113,
								115,
								184,
								205,
								201
							});
						}
						int num307 = r2.X / 16;
						int num308 = (r2.X + r2.Width) / 16 + 1;
						int num309 = r2.Y / 16;
						int num310 = (r2.Y + r2.Height) / 16 + 1;
						for (int num311 = num307; num311 < num308; num311++)
						{
							for (int num312 = num309; num312 < num310; num312++)
							{
								if (Main.tile[num311, num312] != null && Main.tileCut[(int)Main.tile[num311, num312].type] && (list2 == null || !list2.Contains(Main.tile[num311, num312].type)) && Main.tile[num311, num312 + 1] != null && Main.tile[num311, num312 + 1].type != 78 && Main.tile[num311, num312 + 1].type != 380)
								{
									if (item.type == 1786)
									{
										int type9 = (int)Main.tile[num311, num312].type;
										WorldGen.KillTile(num311, num312, false, false, false);
										if (!Main.tile[num311, num312].active())
										{
											int num313 = 0;
											if (type9 == 3 || type9 == 24 || type9 == 61 || type9 == 110 || type9 == 201)
											{
												num313 = Main.rand.Next(1, 3);
											}
											if (type9 == 73 || type9 == 74 || type9 == 113)
											{
												num313 = Main.rand.Next(2, 5);
											}
											if (num313 > 0)
											{
												int number = Item.NewItem(num311 * 16, num312 * 16, 16, 16, 1727, num313, false, 0, false, false);
												if (Main.netMode == 1)
												{
													NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0, 0, 0);
												}
											}
										}
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)num311, (float)num312, 0f, 0, 0, 0);
										}
									}
									else
									{
										WorldGen.KillTile(num311, num312, false, false, false);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)num311, (float)num312, 0f, 0, 0, 0);
										}
									}
								}
							}
						}
						if (item.type != 3183)
						{
							for (int num314 = 0; num314 < 200; num314++)
							{
								if (Main.npc[num314].active && Main.npc[num314].immune[i] == 0 && this.attackCD == 0)
								{
									if (!Main.npc[num314].dontTakeDamage)
									{
										if (!Main.npc[num314].friendly || (Main.npc[num314].type == 22 && this.killGuide) || (Main.npc[num314].type == 54 && this.killClothier))
										{
											Rectangle value16 = new Rectangle((int)Main.npc[num314].position.X, (int)Main.npc[num314].position.Y, Main.npc[num314].width, Main.npc[num314].height);
											if (r2.Intersects(value16) && (Main.npc[num314].noTileCollide || this.CanHit(Main.npc[num314])))
											{
												bool flag25 = false;
												if (Main.rand.Next(1, 101) <= this.meleeCrit)
												{
													flag25 = true;
												}
												int num315 = Item.NPCtoBanner(Main.npc[num314].BannerID());
												if (num315 > 0 && this.NPCBannerBuff[num315])
												{
													if (Main.expertMode)
													{
														num304 = (int)((float)num304 * ItemID.Sets.BannerStrength[Item.BannerToItem(num315)].ExpertDamageDealt);
													}
													else
													{
														num304 = (int)((float)num304 * ItemID.Sets.BannerStrength[Item.BannerToItem(num315)].NormalDamageDealt);
													}
												}
												if (this.parryDamageBuff)
												{
													num304 *= 5;
													this.parryDamageBuff = false;
													this.ClearBuff(198);
												}
												int num316 = Main.DamageVar((float)num304);
												this.StatusNPC(item.type, num314);
												this.OnHit(Main.npc[num314].Center.X, Main.npc[num314].Center.Y, Main.npc[num314]);
												if (this.armorPenetration > 0)
												{
													num316 += Main.npc[num314].checkArmorPenetration(this.armorPenetration);
												}
												int num317 = (int)Main.npc[num314].StrikeNPC(num316, num305, this.direction, flag25, false, false);
												if (this.inventory[this.selectedItem].type == 3211)
												{
													Vector2 value17 = new Vector2((float)(this.direction * 100 + Main.rand.Next(-25, 26)), (float)Main.rand.Next(-75, 76));
													value17.Normalize();
													value17 *= (float)Main.rand.Next(30, 41) * 0.1f;
													Vector2 value18 = new Vector2((float)(r2.X + Main.rand.Next(r2.Width)), (float)(r2.Y + Main.rand.Next(r2.Height)));
													value18 = (value18 + Main.npc[num314].Center * 2f) / 3f;
													Projectile.NewProjectile(value18.X, value18.Y, value17.X, value17.Y, 524, (int)((double)num304 * 0.7), num305 * 0.7f, this.whoAmI, 0f, 0f);
												}
												bool flag26 = !Main.npc[num314].immortal;
												if (this.beetleOffense && flag26)
												{
													this.beetleCounter += (float)num317;
													this.beetleCountdown = 0;
												}
												if (item.type == 1826 && (Main.npc[num314].value > 0f || (Main.npc[num314].damage > 0 && !Main.npc[num314].friendly)))
												{
													this.pumpkinSword(num314, (int)((double)num304 * 1.5), num305);
												}
												if (this.meleeEnchant == 7)
												{
													Projectile.NewProjectile(Main.npc[num314].Center.X, Main.npc[num314].Center.Y, Main.npc[num314].velocity.X, Main.npc[num314].velocity.Y, 289, 0, 0f, this.whoAmI, 0f, 0f);
												}
												if (this.inventory[this.selectedItem].type == 3106)
												{
													this.stealth = 1f;
													if (Main.netMode == 1)
													{
														NetMessage.SendData(84, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
													}
												}
												if (item.type == 1123 && flag26)
												{
													int num318 = Main.rand.Next(1, 4);
													if (this.strongBees && Main.rand.Next(3) == 0)
													{
														num318++;
													}
													for (int num319 = 0; num319 < num318; num319++)
													{
														float num320 = (float)(this.direction * 2) + (float)Main.rand.Next(-35, 36) * 0.02f;
														float num321 = (float)Main.rand.Next(-35, 36) * 0.02f;
														num320 *= 0.2f;
														num321 *= 0.2f;
														Projectile.NewProjectile((float)(r2.X + r2.Width / 2), (float)(r2.Y + r2.Height / 2), num320, num321, this.beeType(), this.beeDamage(num316 / 3), this.beeKB(0f), i, 0f, 0f);
													}
												}
												if (Main.npc[num314].value > 0f && this.coins && Main.rand.Next(5) == 0)
												{
													int type10 = 71;
													if (Main.rand.Next(10) == 0)
													{
														type10 = 72;
													}
													if (Main.rand.Next(100) == 0)
													{
														type10 = 73;
													}
													int num322 = Item.NewItem((int)Main.npc[num314].position.X, (int)Main.npc[num314].position.Y, Main.npc[num314].width, Main.npc[num314].height, type10, 1, false, 0, false, false);
													Main.item[num322].stack = Main.rand.Next(1, 11);
													Main.item[num322].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
													Main.item[num322].velocity.X = (float)Main.rand.Next(10, 31) * 0.2f * (float)this.direction;
													if (Main.netMode == 1)
													{
														NetMessage.SendData(21, -1, -1, "", num322, 0f, 0f, 0f, 0, 0, 0);
													}
												}
												int num323 = Item.NPCtoBanner(Main.npc[num314].BannerID());
												if (num323 >= 0)
												{
													this.lastCreatureHit = num323;
												}
												if (Main.netMode != 0)
												{
													if (flag25)
													{
														NetMessage.SendData(28, -1, -1, "", num314, (float)num316, num305, (float)this.direction, 1, 0, 0);
													}
													else
													{
														NetMessage.SendData(28, -1, -1, "", num314, (float)num316, num305, (float)this.direction, 0, 0, 0);
													}
												}
												if (this.accDreamCatcher)
												{
													this.addDPS(num316);
												}
												Main.npc[num314].immune[i] = this.itemAnimation;
												this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
											}
										}
									}
									else if (Main.npc[num314].type == 63 || Main.npc[num314].type == 64 || Main.npc[num314].type == 103 || Main.npc[num314].type == 242)
									{
										Rectangle value19 = new Rectangle((int)Main.npc[num314].position.X, (int)Main.npc[num314].position.Y, Main.npc[num314].width, Main.npc[num314].height);
										if (r2.Intersects(value19) && (Main.npc[num314].noTileCollide || this.CanHit(Main.npc[num314])))
										{
											this.Hurt((int)((double)Main.npc[num314].damage * 1.3), -this.direction, false, false, " was slain...", false, -1);
											Main.npc[num314].immune[i] = this.itemAnimation;
											this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
										}
									}
								}
							}
							if (this.hostile)
							{
								for (int num324 = 0; num324 < 255; num324++)
								{
									if (num324 != i && Main.player[num324].active && Main.player[num324].hostile && !Main.player[num324].immune && !Main.player[num324].dead && (Main.player[i].team == 0 || Main.player[i].team != Main.player[num324].team))
									{
										Rectangle value20 = new Rectangle((int)Main.player[num324].position.X, (int)Main.player[num324].position.Y, Main.player[num324].width, Main.player[num324].height);
										if (r2.Intersects(value20) && this.CanHit(Main.player[num324]))
										{
											bool flag27 = false;
											if (Main.rand.Next(1, 101) <= 10)
											{
												flag27 = true;
											}
											int num325 = Main.DamageVar((float)num304);
											this.StatusPvP(item.type, num324);
											this.OnHit(Main.player[num324].Center.X, Main.player[num324].Center.Y, Main.player[num324]);
											int num326 = (int)Main.player[num324].Hurt(num325, this.direction, true, false, "", flag27, -1);
											if (this.inventory[this.selectedItem].type == 3211)
											{
												Vector2 value21 = new Vector2((float)(this.direction * 100 + Main.rand.Next(-25, 26)), (float)Main.rand.Next(-75, 76));
												value21.Normalize();
												value21 *= (float)Main.rand.Next(30, 41) * 0.1f;
												Vector2 value22 = new Vector2((float)(r2.X + Main.rand.Next(r2.Width)), (float)(r2.Y + Main.rand.Next(r2.Height)));
												value22 = (value22 + Main.player[num324].Center * 2f) / 3f;
												Projectile.NewProjectile(value22.X, value22.Y, value21.X, value21.Y, 524, (int)((double)num304 * 0.7), num305 * 0.7f, this.whoAmI, 0f, 0f);
											}
											if (this.beetleOffense)
											{
												this.beetleCounter += (float)num326;
												this.beetleCountdown = 0;
											}
											if (this.meleeEnchant == 7)
											{
												Projectile.NewProjectile(Main.player[num324].Center.X, Main.player[num324].Center.Y, Main.player[num324].velocity.X, Main.player[num324].velocity.Y, 289, 0, 0f, this.whoAmI, 0f, 0f);
											}
											if (item.type == 1123)
											{
												int num327 = Main.rand.Next(1, 4);
												if (this.strongBees && Main.rand.Next(3) == 0)
												{
													num327++;
												}
												for (int num328 = 0; num328 < num327; num328++)
												{
													float num329 = (float)(this.direction * 2) + (float)Main.rand.Next(-35, 36) * 0.02f;
													float num330 = (float)Main.rand.Next(-35, 36) * 0.02f;
													num329 *= 0.2f;
													num330 *= 0.2f;
													Projectile.NewProjectile((float)(r2.X + r2.Width / 2), (float)(r2.Y + r2.Height / 2), num329, num330, this.beeType(), this.beeDamage(num325 / 3), this.beeKB(0f), i, 0f, 0f);
												}
											}
											if (this.inventory[this.selectedItem].type == 3106)
											{
												this.stealth = 1f;
												if (Main.netMode == 1)
												{
													NetMessage.SendData(84, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
												}
											}
											if (item.type == 1826 && Main.npc[num324].value > 0f)
											{
												this.pumpkinSword(num324, (int)((double)num304 * 1.5), num305);
											}
											if (Main.netMode != 0)
											{
												if (flag27)
												{
													NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.whoAmI, -1, -1, -1, 0, 0), num324, (float)this.direction, (float)num325, 1f, 1, 0, 0);
												}
												else
												{
													NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.whoAmI, -1, -1, -1, 0, 0), num324, (float)this.direction, (float)num325, 1f, 0, 0, 0);
												}
											}
											this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
										}
									}
								}
							}
							if (item.type == 787 && (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.5) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7) || this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9)))
							{
								float num331 = 0f;
								float num332 = 0f;
								float num333 = 0f;
								float num334 = 0f;
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9))
								{
									num331 = -7f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
								{
									num331 = -6f;
									num332 = 2f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.5))
								{
									num331 = -4f;
									num332 = 4f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3))
								{
									num331 = -2f;
									num332 = 6f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1))
								{
									num332 = 7f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
								{
									num334 = 26f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.3))
								{
									num334 -= 4f;
									num333 -= 20f;
								}
								if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.1))
								{
									num333 += 6f;
								}
								if (this.direction == -1)
								{
									if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.9))
									{
										num334 -= 8f;
									}
									if (this.itemAnimation == (int)((double)this.itemAnimationMax * 0.7))
									{
										num334 -= 6f;
									}
								}
								num331 *= 1.5f;
								num332 *= 1.5f;
								num334 *= (float)this.direction;
								num333 *= this.gravDir;
								Projectile.NewProjectile((float)(r2.X + r2.Width / 2) + num334, (float)(r2.Y + r2.Height / 2) + num333, (float)this.direction * num332, num331 * this.gravDir, 131, num304 / 2, 0f, i, 0f, 0f);
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
						NetMessage.SendData(4, -1, -1, Main.player[this.whoAmI].name, this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				if (item.healLife > 0)
				{
					this.statLife += item.healLife;
					this.itemTime = item.useTime;
					if (Main.myPlayer == this.whoAmI)
					{
						this.HealEffect(item.healLife, true);
					}
				}
				if (item.healMana > 0)
				{
					this.statMana += item.healMana;
					this.itemTime = item.useTime;
					if (Main.myPlayer == this.whoAmI)
					{
						this.AddBuff(94, Player.manaSickTime, true);
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
				if (item.type == 678)
				{
					this.itemTime = item.useTime;
					if (this.whoAmI == Main.myPlayer)
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
			if (this.whoAmI == Main.myPlayer)
			{
				if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == 361 && Main.CanStartInvasion(1, true))
				{
					this.itemTime = item.useTime;
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
						NetMessage.SendData(61, -1, -1, "", this.whoAmI, -1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == 602 && Main.CanStartInvasion(2, true))
				{
					this.itemTime = item.useTime;
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
						NetMessage.SendData(61, -1, -1, "", this.whoAmI, -2f, 0f, 0f, 0, 0, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == 1315 && Main.CanStartInvasion(3, true))
				{
					this.itemTime = item.useTime;
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
						NetMessage.SendData(61, -1, -1, "", this.whoAmI, -3f, 0f, 0f, 0, 0, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == 1844 && !Main.dayTime && !Main.pumpkinMoon && !Main.snowMoon)
				{
					this.itemTime = item.useTime;
					if (Main.netMode != 1)
					{
						Main.NewText(Lang.misc[31], 50, 255, 130, false);
						Main.startPumpkinMoon();
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", this.whoAmI, -4f, 0f, 0f, 0, 0, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == 2767 && Main.dayTime && !Main.eclipse)
				{
					this.itemTime = item.useTime;
					if (Main.netMode == 0)
					{
						Main.eclipse = true;
						Main.NewText(Lang.misc[20], 50, 255, 130, false);
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", this.whoAmI, -6f, 0f, 0f, 0, 0, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == 3601 && NPC.downedGolemBoss && Main.hardMode && !NPC.AnyDanger() && !NPC.AnyoneNearCultists())
				{
					this.itemTime = item.useTime;
					if (Main.netMode == 0)
					{
						WorldGen.StartImpendingDoom();
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", this.whoAmI, -8f, 0f, 0f, 0, 0, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && item.type == 1958 && !Main.dayTime && !Main.pumpkinMoon && !Main.snowMoon)
				{
					this.itemTime = item.useTime;
					if (Main.netMode != 1)
					{
						Main.NewText(Lang.misc[34], 50, 255, 130, false);
						Main.startSnowMoon();
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", this.whoAmI, -5f, 0f, 0f, 0, 0, 0);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && item.makeNPC > 0 && this.controlUseItem && this.position.X / 16f - (float)Player.tileRangeX - (float)item.tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)item.tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)item.tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)item.tileBoost - 2f >= (float)Player.tileTargetY)
				{
					int num335 = Main.mouseX + (int)Main.screenPosition.X;
					int num336 = Main.mouseY + (int)Main.screenPosition.Y;
					this.itemTime = item.useTime;
					int i2 = num335 / 16;
					int j2 = num336 / 16;
					if (!WorldGen.SolidTile(i2, j2))
					{
						NPC.ReleaseNPC(num335, num336, (int)item.makeNPC, item.placeStyle, this.whoAmI);
					}
				}
				if (this.itemTime == 0 && this.itemAnimation > 0 && (item.type == 43 || item.type == 70 || item.type == 544 || item.type == 556 || item.type == 557 || item.type == 560 || item.type == 1133 || item.type == 1331) && this.SummonItemCheck())
				{
					if (item.type == 560)
					{
						this.itemTime = item.useTime;
						if (Main.netMode != 1)
						{
							NPC.SpawnOnPlayer(i, 50);
						}
						else
						{
							NetMessage.SendData(61, -1, -1, "", this.whoAmI, 50f, 0f, 0f, 0, 0, 0);
						}
					}
					else if (item.type == 43)
					{
						if (!Main.dayTime)
						{
							this.itemTime = item.useTime;
							if (Main.netMode != 1)
							{
								NPC.SpawnOnPlayer(i, 4);
							}
							else
							{
								NetMessage.SendData(61, -1, -1, "", this.whoAmI, 4f, 0f, 0f, 0, 0, 0);
							}
						}
					}
					else if (item.type == 70)
					{
						if (this.ZoneCorrupt)
						{
							this.itemTime = item.useTime;
							if (Main.netMode != 1)
							{
								NPC.SpawnOnPlayer(i, 13);
							}
							else
							{
								NetMessage.SendData(61, -1, -1, "", this.whoAmI, 13f, 0f, 0f, 0, 0, 0);
							}
						}
					}
					else if (item.type == 544)
					{
						if (!Main.dayTime)
						{
							this.itemTime = item.useTime;
							if (Main.netMode != 1)
							{
								NPC.SpawnOnPlayer(i, 125);
								NPC.SpawnOnPlayer(i, 126);
							}
							else
							{
								NetMessage.SendData(61, -1, -1, "", this.whoAmI, 125f, 0f, 0f, 0, 0, 0);
								NetMessage.SendData(61, -1, -1, "", this.whoAmI, 126f, 0f, 0f, 0, 0, 0);
							}
						}
					}
					else if (item.type == 556)
					{
						if (!Main.dayTime)
						{
							this.itemTime = item.useTime;
							if (Main.netMode != 1)
							{
								NPC.SpawnOnPlayer(i, 134);
							}
							else
							{
								NetMessage.SendData(61, -1, -1, "", this.whoAmI, 134f, 0f, 0f, 0, 0, 0);
							}
						}
					}
					else if (item.type == 557)
					{
						if (!Main.dayTime)
						{
							this.itemTime = item.useTime;
							if (Main.netMode != 1)
							{
								NPC.SpawnOnPlayer(i, 127);
							}
							else
							{
								NetMessage.SendData(61, -1, -1, "", this.whoAmI, 127f, 0f, 0f, 0, 0, 0);
							}
						}
					}
					else if (item.type == 1133)
					{
						this.itemTime = item.useTime;
						if (Main.netMode != 1)
						{
							NPC.SpawnOnPlayer(i, 222);
						}
						else
						{
							NetMessage.SendData(61, -1, -1, "", this.whoAmI, 222f, 0f, 0f, 0, 0, 0);
						}
					}
					else if (item.type == 1331 && this.ZoneCrimson)
					{
						this.itemTime = item.useTime;
						if (Main.netMode != 1)
						{
							NPC.SpawnOnPlayer(i, 266);
						}
						else
						{
							NetMessage.SendData(61, -1, -1, "", this.whoAmI, 266f, 0f, 0f, 0, 0, 0);
						}
					}
				}
			}
			if ((item.type == 50 || item.type == 3124 || item.type == 3199) && this.itemAnimation > 0)
			{
				if (this.itemTime == 0)
				{
					this.itemTime = item.useTime;
				}
				else if (this.itemTime == item.useTime / 2)
				{
					this.grappling[0] = -1;
					this.grapCount = 0;
					for (int num338 = 0; num338 < 1000; num338++)
					{
						if (Main.projectile[num338].active && Main.projectile[num338].owner == i && Main.projectile[num338].aiStyle == 7)
						{
							Main.projectile[num338].Kill();
						}
					}
					this.Spawn();
				}
			}
			if (item.type == 2350 && this.itemAnimation > 0)
			{
				if (this.itemTime == 0)
				{
					this.itemTime = item.useTime;
				}
				else if (this.itemTime == 2)
				{
					this.grappling[0] = -1;
					this.grapCount = 0;
					for (int num341 = 0; num341 < 1000; num341++)
					{
						if (Main.projectile[num341].active && Main.projectile[num341].owner == i && Main.projectile[num341].aiStyle == 7)
						{
							Main.projectile[num341].Kill();
						}
					}
					bool flag28 = this.immune;
					int num342 = this.immuneTime;
					this.Spawn();
					this.immune = flag28;
					this.immuneTime = num342;
					if (item.stack > 0)
					{
						item.stack--;
					}
				}
			}
			if (item.type == 2351 && this.itemAnimation > 0)
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
						NetMessage.SendData(73, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
					}
					if (item.stack > 0)
					{
						item.stack--;
					}
				}
			}
			if (item.type == 2756 && this.itemAnimation > 0)
			{
				if (this.itemTime == 0)
				{
					this.itemTime = item.useTime;
				}
				else if (this.itemTime == 2)
				{
					if (this.whoAmI == Main.myPlayer)
					{
						this.Male = !this.Male;
						if (Main.netMode == 1)
						{
							NetMessage.SendData(4, -1, -1, this.name, this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
						}
					}
					if (item.stack > 0)
					{
						item.stack--;
					}
				}
			}
			if (i == Main.myPlayer)
			{
				if (this.itemTime == (int)((float)item.useTime * this.tileSpeed) && item.tileWand > 0)
				{
					int tileWand2 = item.tileWand;
					int num349 = 0;
					while (num349 < 58)
					{
						if (tileWand2 == this.inventory[num349].type && this.inventory[num349].stack > 0)
						{
							this.inventory[num349].stack--;
							if (this.inventory[num349].stack <= 0)
							{
								this.inventory[num349] = new Item();
								break;
							}
							break;
						}
						else
						{
							num349++;
						}
					}
				}
				int num350;
				if (item.createTile >= 0)
				{
					num350 = (int)((float)item.useTime * this.tileSpeed);
				}
				else if (item.createWall > 0)
				{
					num350 = (int)((float)item.useTime * this.wallSpeed);
				}
				else
				{
					num350 = item.useTime;
				}
				if (this.itemTime == num350 && item.consumable)
				{
					bool flag29 = true;
					if (item.type == 2350 || item.type == 2351)
					{
						flag29 = false;
					}
					if (item.type == 2756)
					{
						flag29 = false;
					}
					if (item.ranged)
					{
						if (this.ammoCost80 && Main.rand.Next(5) == 0)
						{
							flag29 = false;
						}
						if (this.ammoCost75 && Main.rand.Next(4) == 0)
						{
							flag29 = false;
						}
					}
					if (item.thrown)
					{
						if (this.thrownCost50 && Main.rand.Next(100) < 50)
						{
							flag29 = false;
						}
						if (this.thrownCost33 && Main.rand.Next(100) < 33)
						{
							flag29 = false;
						}
					}
					if (item.type >= 71 && item.type <= 74)
					{
						flag29 = true;
					}
					if (flag29)
					{
						if (item.stack > 0)
						{
							item.stack--;
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
		public static bool WouldSpotOverlapWithSentry(int worldX, int worldY)
		{
			Point value = new Point(worldX, worldY - 8);
			Point value2 = new Point(worldX + 16, worldY - 8);
			Point value3 = new Point(worldX - 16, worldY - 8);
			bool result = false;
			for (int i = 0; i < 1000; i++)
			{
				Projectile projectile = Main.projectile[i];
				if (projectile.active && projectile.sentry)
				{
					Rectangle hitbox = projectile.Hitbox;
					if (hitbox.Contains(value) || hitbox.Contains(value2) || hitbox.Contains(value3))
					{
						result = true;
						break;
					}
				}
			}
			return result;
		}
		public void FindSentryRestingSpot(int checkProj, out int worldX, out int worldY, out int pushYUp)
		{
			bool flag = false;
			int num = (int)((float)Main.mouseX + Main.screenPosition.X) / 16;
			int num2 = (int)((float)Main.mouseY + Main.screenPosition.Y) / 16;
			if (this.gravDir == -1f)
			{
				num2 = (int)(Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16;
			}
			worldX = num * 16 + 8;
			pushYUp = 41;
			switch (checkProj)
			{
				case 663:
					worldX += this.direction;
					break;
				case 664:
				case 666:
					break;
				case 665:
					pushYUp += 2;
					break;
				case 667:
					pushYUp += 3;
					break;
				default:
					switch (checkProj)
					{
						case 677:
							worldX += this.direction;
							break;
						case 678:
							worldX += this.direction;
							break;
						case 679:
							break;
						default:
							switch (checkProj)
							{
								case 691:
								case 692:
								case 693:
									pushYUp = 20;
									worldX += this.direction;
									pushYUp += 2;
									break;
							}
							break;
					}
					break;
			}
			if (!flag)
			{
				while (num2 < Main.maxTilesY - 10 && Main.tile[num, num2] != null && !WorldGen.SolidTile2(num, num2) && Main.tile[num - 1, num2] != null && !WorldGen.SolidTile2(num - 1, num2) && Main.tile[num + 1, num2] != null && !WorldGen.SolidTile2(num + 1, num2))
				{
					num2++;
				}
				num2++;
			}
			num2--;
			pushYUp -= 14;
			worldY = num2 * 16;
		}
		public void WipeOldestTurret()
		{
			List<Projectile> list = new List<Projectile>();
			for (int i = 0; i < 1000; i++)
			{
				if (Main.projectile[i].WipableTurret)
				{
					list.Add(Main.projectile[i]);
				}
			}
			if (list.Count == 0)
			{
				return;
			}
			Projectile projectile = list[0];
			for (int j = 1; j < list.Count; j++)
			{
				if (list[j].timeLeft < projectile.timeLeft)
				{
					projectile = list[j];
				}
			}
			projectile.Kill();
		}
		public void UpdateMaxTurrets()
		{
			List<Projectile> list = new List<Projectile>();
			for (int i = 0; i < 1000; i++)
			{
				if (Main.projectile[i].WipableTurret)
				{
					list.Add(Main.projectile[i]);
				}
			}
			int num = 0;
			while (list.Count > this.maxTurrets)
			{
				if (++num >= 1000)
				{
					return;
				}
				Projectile projectile = list[0];
				for (int j = 1; j < list.Count; j++)
				{
					if (list[j].timeLeft < projectile.timeLeft)
					{
						projectile = list[j];
					}
				}
				projectile.Kill();
				list.Remove(projectile);
			}
		}
		private void ItemCheckWrapped(int i)
		{
			if (Main.ignoreErrors)
			{
				try
				{
					this.ItemCheck(i);
				}
				catch
				{
				}
			}
			else
				this.ItemCheck(i);
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
			int netID = i.netID;
			if (netID == 905 || netID == 1326)
			{
				flag = true;
			}
			return (i.damage > 0 || flag) && i.useStyle > 0 && i.stack > 0;
		}

		public bool ItemSpace(Item newItem)
		{
			if (newItem.uniqueStack && this.HasItem(newItem.type))
			{
				return false;
			}
			if (newItem.type == 58 || newItem.type == 184 || newItem.type == 1734 || newItem.type == 1735 || newItem.type == 1867 || newItem.type == 1868)
			{
				return true;
			}
			if (ItemID.Sets.NebulaPickup[newItem.type])
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
				if (newItem.type != 75 && newItem.type != 169 && newItem.type != 23 && newItem.type != 408 && newItem.type != 370 && newItem.type != 1246)
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
			for (int m = 54; m < 58; m++)
			{
				if (this.inventory[m].type > 0 && this.inventory[m].stack < this.inventory[m].maxStack && newItem.IsTheSameAs(this.inventory[m]))
				{
					return true;
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
				for (int i = 0; i < 200; i++)
				{
					NPC nPC = Main.npc[i];
					if (nPC.active && !nPC.dontTakeDamage && !nPC.friendly && nPC.immune[this.whoAmI] == 0)
					{
						Rectangle rect2 = nPC.getRect();
						if (rect.Intersects(rect2) && (nPC.noTileCollide || Collision.CanHit(this.position, this.width, this.height, nPC.position, nPC.width, nPC.height)))
						{
							float num = 40f * this.minionDamage;
							float knockback = 5f;
							int direction = this.direction;
							if (this.velocity.X < 0f)
							{
								direction = -1;
							}
							if (this.velocity.X > 0f)
							{
								direction = 1;
							}
							if (this.whoAmI == Main.myPlayer)
							{
								this.ApplyDamageToNPC(nPC, (int)num, knockback, direction, false);
							}
							nPC.immune[this.whoAmI] = 10;
							this.velocity.Y = -10f;
							this.immune = true;
							this.immuneTime = 6;
							break;
						}
					}
				}
			}
			if (this.controlJump)
			{
				bool flag = false;
				if (this.mount.Active && this.mount.Type == 3 && this.wetSlime > 0)
				{
					flag = true;
				}
				if (this.jump > 0)
				{
					if (this.velocity.Y == 0f)
					{
						this.jump = 0;
					}
					else
					{
						this.velocity.Y = -Player.jumpSpeed * this.gravDir;
						if (this.merman && (!this.mount.Active || !this.mount.Cart))
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
				else if ((this.sliding || this.velocity.Y == 0f || flag || this.jumpAgainCloud || this.jumpAgainSandstorm || this.jumpAgainBlizzard || this.jumpAgainFart || this.jumpAgainSail || this.jumpAgainUnicorn || (this.wet && this.accFlipper && (!this.mount.Active || !this.mount.Cart))) && (this.releaseJump || (this.autoJump && (this.velocity.Y == 0f || this.sliding))))
				{
					if (this.sliding || this.velocity.Y == 0f)
					{
						this.justJumped = true;
					}
					bool flag2 = false;
					if (this.wet && this.accFlipper)
					{
						if (this.swimTime == 0)
						{
							this.swimTime = 30;
						}
						flag2 = true;
					}
					bool flag3 = false;
					bool flag4 = false;
					bool flag5 = false;
					bool flag6 = false;
					bool flag7 = false;
					if (!flag)
					{
						if (this.jumpAgainUnicorn)
						{
							flag7 = true;
							this.jumpAgainUnicorn = false;
						}
						else if (this.jumpAgainSandstorm)
						{
							flag3 = true;
							this.jumpAgainSandstorm = false;
						}
						else if (this.jumpAgainBlizzard)
						{
							flag4 = true;
							this.jumpAgainBlizzard = false;
						}
						else if (this.jumpAgainFart)
						{
							this.jumpAgainFart = false;
							flag5 = true;
						}
						else if (this.jumpAgainSail)
						{
							this.jumpAgainSail = false;
							flag6 = true;
						}
						else
						{
							this.jumpAgainCloud = false;
						}
					}
					this.canRocket = false;
					this.rocketRelease = false;
					if ((this.velocity.Y == 0f || this.sliding || (this.autoJump && this.justJumped)) && this.doubleJumpCloud)
					{
						this.jumpAgainCloud = true;
					}
					if ((this.velocity.Y == 0f || this.sliding || (this.autoJump && this.justJumped)) && this.doubleJumpSandstorm)
					{
						this.jumpAgainSandstorm = true;
					}
					if ((this.velocity.Y == 0f || this.sliding || (this.autoJump && this.justJumped)) && this.doubleJumpBlizzard)
					{
						this.jumpAgainBlizzard = true;
					}
					if ((this.velocity.Y == 0f || this.sliding || (this.autoJump && this.justJumped)) && this.doubleJumpFart)
					{
						this.jumpAgainFart = true;
					}
					if ((this.velocity.Y == 0f || this.sliding || (this.autoJump && this.justJumped)) && this.doubleJumpSail)
					{
						this.jumpAgainSail = true;
					}
					if ((this.velocity.Y == 0f || this.sliding || (this.autoJump && this.justJumped)) && this.doubleJumpUnicorn)
					{
						this.jumpAgainUnicorn = true;
					}
					if (this.velocity.Y == 0f || flag2 || this.sliding || flag)
					{
						this.velocity.Y = -Player.jumpSpeed * this.gravDir;
						this.jump = Player.jumpHeight;
						if (this.sliding)
						{
							this.velocity.X = (float)(3 * -(float)this.slideDir);
						}
					}
					else if (flag3)
					{
						this.dJumpEffectSandstorm = true;
						int arg_5B2_0 = this.height;
						float arg_5BF_0 = this.gravDir;
						this.velocity.Y = -Player.jumpSpeed * this.gravDir;
						this.jump = Player.jumpHeight * 3;
					}
					else if (flag4)
					{
						this.dJumpEffectBlizzard = true;
						int arg_61B_0 = this.height;
						float arg_628_0 = this.gravDir;
						this.velocity.Y = -Player.jumpSpeed * this.gravDir;
						this.jump = (int)((double)Player.jumpHeight * 1.5);
					}
					else if (flag6)
					{
						this.dJumpEffectSail = true;
						int num2 = this.height;
						if (this.gravDir == -1f)
						{
							num2 = 0;
						}
						this.velocity.Y = -Player.jumpSpeed * this.gravDir;
						this.jump = (int)((double)Player.jumpHeight * 1.25);
					}
					else if (flag5)
					{
						this.dJumpEffectFart = true;
						int num4 = this.height;
						if (this.gravDir == -1f)
						{
							num4 = 0;
						}
						this.velocity.Y = -Player.jumpSpeed * this.gravDir;
						this.jump = Player.jumpHeight * 2;
					}
					else if (flag7)
					{
						this.dJumpEffectUnicorn = true;
						int arg_CE4_0 = this.height;
						float arg_CF1_0 = this.gravDir;
						this.velocity.Y = -Player.jumpSpeed * this.gravDir;
						this.jump = Player.jumpHeight * 2;
					}
					else
					{
						this.dJumpEffectCloud = true;
						int num9 = this.height;
						if (this.gravDir == -1f)
						{
							num9 = 0;
						}
						this.velocity.Y = -Player.jumpSpeed * this.gravDir;
						this.jump = (int)((double)Player.jumpHeight * 0.75);
					}
				}
				this.releaseJump = false;
				return;
			}
			this.jump = 0;
			this.releaseJump = true;
			this.rocketRelease = true;
		}

		public void KeyDoubleTap(int keyDir)
		{
			int num = 0;
			if (keyDir == num)
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
			int num = 0;
			if (keyDir == num && this.setStardust && holdTime >= 60)
			{
				this.MinionTargetPoint = Vector2.Zero;
			}
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
			if (this.trapDebuffSource)
			{
				AchievementsHelper.HandleSpecialEvent(this, 4);
			}
			this.lastDeathPostion = base.Center;
			this.lastDeathTime = DateTime.Now;
			this.showLastDeath = true;
			bool flag;
			int coinsOwned = (int)Utils.CoinsCount(out flag, this.inventory, new int[0]);
			if (Main.myPlayer == this.whoAmI)
			{
				this.lostCoins = coinsOwned;
				this.lostCoinString = Main.ValueToCoins(this.lostCoins);
			}
			if (Main.myPlayer == this.whoAmI)
			{
				Main.mapFullscreen = false;
			}
			if (Main.myPlayer == this.whoAmI)
			{
				this.trashItem.SetDefaults(0, false);
				if (this.difficulty == 0)
				{
					for (int i = 0; i < 59; i++)
					{
						bool flag2 = this.inventory[i].stack > 0 && ((this.inventory[i].type >= 1522 && this.inventory[i].type <= 1527) || this.inventory[i].type == 3643);
						if (flag2)
						{
							int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[i].type, 1, false, 0, false, false);
							Main.item[num].netDefaults(this.inventory[i].netID);
							Main.item[num].Prefix((int)this.inventory[i].prefix);
							Main.item[num].stack = this.inventory[i].stack;
							Main.item[num].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
							Main.item[num].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
							Main.item[num].noGrabDelay = 100;
							Main.item[num].favorited = false;
							Main.item[num].newAndShiny = false;
							if (Main.netMode == 1)
							{
								NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0, 0, 0);
							}
							this.inventory[i].SetDefaults(0, false);
						}
					}
				}
				else if (this.difficulty == 1)
				{
					this.DropItems();
				}
				else if (this.difficulty == 2)
				{
					this.DropItems();
					this.KillMeForGood();
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
			bool flag3 = false;
			if (Main.netMode != 0 && !pvp)
			{
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && (Main.npc[k].boss || Main.npc[k].type == 13 || Main.npc[k].type == 14 || Main.npc[k].type == 15) && Math.Abs(base.Center.X - Main.npc[k].Center.X) + Math.Abs(base.Center.Y - Main.npc[k].Center.Y) < 4000f)
					{
						flag3 = true;
						break;
					}
				}
			}
			if (flag3)
			{
				this.respawnTimer += 600;
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
				NetMessage.SendData(25, -1, -1, this.name + deathText, 255, 225f, 25f, 25f, 0, 0, 0);
			}
			else if (Main.netMode == 0)
			{
				Main.NewText(this.name + deathText, 225, 25, 25, false);
			}
			if (Main.netMode == 1 && this.whoAmI == Main.myPlayer)
			{
				int num4 = 0;
				if (pvp)
				{
					num4 = 1;
				}
				NetMessage.SendData(44, -1, -1, deathText, this.whoAmI, (float)hitDirection, (float)((int)dmg), (float)num4, 0, 0, 0);
			}
			if (this.whoAmI == Main.myPlayer && this.difficulty == 0)
			{
				if (!pvp)
				{
					this.DropCoins();
				}
				else
				{
					this.lostCoins = 0;
					this.lostCoinString = Main.ValueToCoins(this.lostCoins);
				}
			}
			this.DropTombstone(coinsOwned, deathText, hitDirection);
			if (this.whoAmI == Main.myPlayer)
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

		public void KillMeForGood()
		{
			if (FileUtilities.Exists(Main.playerPathName))
			{
				FileUtilities.Delete(Main.playerPathName);
			}
			if (FileUtilities.Exists(Main.playerPathName + ".bak"))
			{
				FileUtilities.Delete(Main.playerPathName + ".bak");
			}
			Main.ActivePlayerFileData = new PlayerFileData();
		}

		private void LaunchMinecartHook(int myX, int myY)
		{
			Vector2 vector = new Vector2((float)Main.mouseX + Main.screenPosition.X, (float)Main.mouseY + Main.screenPosition.Y);
			vector = new Vector2((float)(myX * 16 + 8), (float)(myY * 16 + 8));
			if (this.direction > 0)
			{
				this.minecartLeft = false;
			}
			else
			{
				this.minecartLeft = true;
			}
			this.grappling[0] = -1;
			this.grapCount = 0;
			for (int i = 0; i < 1000; i++)
			{
				if (Main.projectile[i].active && Main.projectile[i].owner == this.whoAmI && Main.projectile[i].aiStyle == 7)
				{
					Main.projectile[i].Kill();
				}
			}
			Projectile.NewProjectile(vector.X, vector.Y, 0f, 0f, 403, 0, 0f, this.whoAmI, 0f, 0f);
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
				NetMessage.SendData(43, -1, -1, "", this.whoAmI, (float)manaAmount, 0f, 0f, 0, 0, 0);
			}
		}
		public void MinionTargetAim()
		{
			Vector2 mouseWorld = Main.MouseWorld;
			float y = mouseWorld.Y;
			int num = (int)mouseWorld.X / 16;
			int num2 = (int)y / 16;
			int num3 = 0;
			bool flag = Main.tile[num, num2].nactive() && Main.tileSolid[(int)Main.tile[num, num2].type] && !Main.tileSolidTop[(int)Main.tile[num, num2].type];
			if (flag)
			{
				int num4 = 0;
				int num5 = 0;
				while (num5 > -20 && num2 + num5 > 1)
				{
					int num6 = num2 + num5;
					bool flag2 = Main.tile[num, num6].nactive() && Main.tileSolid[(int)Main.tile[num, num6].type] && !Main.tileSolidTop[(int)Main.tile[num, num6].type];
					if (!flag2)
					{
						num4 = num5;
						break;
					}
					num4 = num5;
					num5--;
				}
				int num7 = 0;
				int num8 = 0;
				while (num8 < 20 && num2 + num8 < Main.maxTilesY)
				{
					int num9 = num2 + num8;
					bool flag3 = Main.tile[num, num9].nactive() && Main.tileSolid[(int)Main.tile[num, num9].type] && !Main.tileSolidTop[(int)Main.tile[num, num9].type];
					if (!flag3)
					{
						num7 = num8;
						break;
					}
					num7 = num8;
					num8++;
				}
				bool flag4 = num7 > -num4;
				if (flag4)
				{
					num3 = num4 - 2;
				}
				else
				{
					num3 = num7 + 3;
				}
			}
			int num10 = num2 + num3;
			bool flag5 = false;
			for (int i = num10; i < num10 + 5; i++)
			{
				if (WorldGen.SolidTileAllowBottomSlope(num, i))
				{
					flag5 = true;
				}
			}
			while (!flag5)
			{
				num10++;
				for (int j = num10; j < num10 + 5; j++)
				{
					if (WorldGen.SolidTileAllowBottomSlope(num, j))
					{
						flag5 = true;
					}
				}
			}
			Vector2 vector = new Vector2((float)(num * 16 + 8), (float)(num10 * 16));
			if (base.Distance(vector) <= 1000f)
			{
				this.MinionTargetPoint = vector;
			}
		}

		public void MoonLeechRope()
		{
			int num = -1;
			for (int i = 0; i < 1000; i++)
			{
				if (Main.projectile[i].active && Main.projectile[i].type == 456 && Main.projectile[i].ai[1] == (float)this.whoAmI)
				{
					num = i;
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
			Vector2 value = new Vector2(0f, 216f);
			Vector2 value2 = Main.npc[(int)Math.Abs(projectile.ai[0]) - 1].Center - base.Center + value;
			if (value2.Length() > 200f)
			{
				Vector2 value3 = Vector2.Normalize(value2);
				this.position += value3 * (value2.Length() - 200f);
			}
		}

		public void NebulaLevelup(int type)
		{
			if (this.whoAmI == Main.myPlayer)
			{
				int time = 480;
				for (int i = 0; i < 22; i++)
				{
					if (this.buffType[i] >= type && this.buffType[i] < type + 3)
					{
						this.DelBuff(i);
					}
				}
				if (type == 173)
				{
					this.nebulaLevelLife = (int)MathHelper.Clamp((float)(this.nebulaLevelLife + 1), 0f, 3f);
					this.AddBuff(type + this.nebulaLevelLife - 1, time, true);
					return;
				}
				if (type == 176)
				{
					this.nebulaLevelMana = (int)MathHelper.Clamp((float)(this.nebulaLevelMana + 1), 0f, 3f);
					this.AddBuff(type + this.nebulaLevelMana - 1, time, true);
					return;
				}
				if (type != 179)
				{
					return;
				}
				this.nebulaLevelDamage = (int)MathHelper.Clamp((float)(this.nebulaLevelDamage + 1), 0f, 3f);
				this.AddBuff(type + this.nebulaLevelDamage - 1, time, true);
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
			for (int i = 0; i < this.hurtCooldowns.Length; i++)
			{
				this.hurtCooldowns[i] = this.immuneTime;
			}
			if (this.whoAmI == Main.myPlayer)
			{
				NetMessage.SendData(62, -1, -1, "", this.whoAmI, 1f, 0f, 0f, 0, 0, 0);
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
				this.AddBuff(59, 1800, true);
			}
			if (this.onHitRegen)
			{
				this.AddBuff(58, 300, true);
			}
			if (this.stardustMinion && victim is NPC)
			{
				for (int i = 0; i < 1000; i++)
				{
					Projectile projectile = Main.projectile[i];
					if (projectile.active && projectile.owner == this.whoAmI && projectile.type == 613 && projectile.localAI[1] <= 0f && Main.rand.Next(2) == 0)
					{
						Vector2 value = new Vector2(x, y) - projectile.Center;
						if (value.Length() > 0f)
						{
							value.Normalize();
						}
						value *= 20f;
						Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, value.X, value.Y, 614, projectile.damage / 3, 0f, projectile.owner, 0f, (float)victim.whoAmI);
						projectile.localAI[1] = (float)(30 + Main.rand.Next(4) * 10);
					}
				}
			}
			if (this.onHitPetal && this.petalTimer == 0)
			{
				this.petalTimer = 20;
				if (x < this.position.X + (float)(this.width / 2))
				{
				}
				int direction = this.direction;
				float num = Main.screenPosition.X;
				if (direction < 0)
				{
					num += (float)Main.screenWidth;
				}
				float num2 = Main.screenPosition.Y;
				num2 += (float)Main.rand.Next(Main.screenHeight);
				Vector2 vector = new Vector2(num, num2);
				float num3 = x - vector.X;
				float num4 = y - vector.Y;
				num3 += (float)Main.rand.Next(-50, 51) * 0.1f;
				num4 += (float)Main.rand.Next(-50, 51) * 0.1f;
				int num5 = 24;
				float num6 = (float)Math.Sqrt((double)(num3 * num3 + num4 * num4));
				num6 = (float)num5 / num6;
				num3 *= num6;
				num4 *= num6;
				Projectile.NewProjectile(num, num2, num3, num4, 221, 36, 0f, this.whoAmI, 0f, 0f);
			}
			if (this.crystalLeaf && this.petalTimer == 0)
			{
				int arg_2D2_0 = this.inventory[this.selectedItem].type;
				for (int j = 0; j < 1000; j++)
				{
					if (Main.projectile[j].owner == this.whoAmI && Main.projectile[j].type == 226)
					{
						this.petalTimer = 50;
						float num7 = 12f;
						Vector2 vector2 = new Vector2(Main.projectile[j].position.X + (float)this.width * 0.5f, Main.projectile[j].position.Y + (float)this.height * 0.5f);
						float num8 = x - vector2.X;
						float num9 = y - vector2.Y;
						float num10 = (float)Math.Sqrt((double)(num8 * num8 + num9 * num9));
						num10 = num7 / num10;
						num8 *= num10;
						num9 *= num10;
						Projectile.NewProjectile(Main.projectile[j].Center.X - 4f, Main.projectile[j].Center.Y, num8, num9, 227, Player.crystalLeafDamage, (float)Player.crystalLeafKB, this.whoAmI, 0f, 0f);
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
				int num2;
				for (num2 = Main.rand.Next(256, 259); num2 == num; num2 = Main.rand.Next(256, 259))
				{
				}
				this.QuickSpawnItem(num, 1);
				this.QuickSpawnItem(num2, 1);
				if (Main.rand.Next(2) == 0)
				{
					this.QuickSpawnItem(2610, 1);
				}
				else
				{
					this.QuickSpawnItem(2585, 1);
				}
				this.QuickSpawnItem(998, 1);
				this.QuickSpawnItem(3090, 1);
			}
			else if (type == 3319)
			{
				if (this.difficulty == 2)
				{
					this.QuickSpawnItem(3763, 1);
				}
				if (Main.rand.Next(7) == 0)
				{
					this.QuickSpawnItem(2112, 1);
				}
				if (Main.rand.Next(30) == 0)
				{
					this.QuickSpawnItem(1299, 1);
				}
				if (WorldGen.crimson)
				{
					int num3 = Main.rand.Next(20) + 10;
					num3 += Main.rand.Next(20) + 10;
					num3 += Main.rand.Next(20) + 10;
					this.QuickSpawnItem(880, num3);
					num3 = Main.rand.Next(3) + 1;
					this.QuickSpawnItem(2171, num3);
				}
				else
				{
					int num4 = Main.rand.Next(20) + 10;
					num4 += Main.rand.Next(20) + 10;
					num4 += Main.rand.Next(20) + 10;
					this.QuickSpawnItem(56, num4);
					num4 = Main.rand.Next(3) + 1;
					this.QuickSpawnItem(59, num4);
					num4 = Main.rand.Next(30) + 20;
					this.QuickSpawnItem(47, num4);
				}
				this.QuickSpawnItem(3097, 1);
			}
			else if (type == 3320)
			{
				int num5 = Main.rand.Next(15, 30);
				num5 += Main.rand.Next(15, 31);
				this.QuickSpawnItem(56, num5);
				num5 = Main.rand.Next(10, 20);
				this.QuickSpawnItem(86, num5);
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
				int num6 = Main.rand.Next(20, 46);
				num6 += Main.rand.Next(20, 46);
				this.QuickSpawnItem(880, num6);
				num6 = Main.rand.Next(10, 20);
				this.QuickSpawnItem(1329, num6);
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
				int num7 = Main.rand.Next(3);
				if (num7 == 0)
				{
					num7 = 1121;
				}
				else if (num7 == 1)
				{
					num7 = 1123;
				}
				else if (num7 == 2)
				{
					num7 = 2888;
				}
				this.QuickSpawnItem(num7, 1);
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
				int num8 = Main.rand.Next(3);
				if (num8 == 0)
				{
					this.QuickSpawnItem(1281, 1);
				}
				else if (num8 == 1)
				{
					this.QuickSpawnItem(1273, 1);
				}
				else
				{
					this.QuickSpawnItem(1313, 1);
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
				int num9 = Main.rand.Next(4);
				if (num9 == 3)
				{
					num9 = 2998;
				}
				else
				{
					num9 = 489 + num9;
				}
				this.QuickSpawnItem(num9, 1);
				int num10 = Main.rand.Next(3);
				if (num10 == 0)
				{
					this.QuickSpawnItem(514, 1);
				}
				else if (num10 == 1)
				{
					this.QuickSpawnItem(426, 1);
				}
				else if (num10 == 2)
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
				int num11 = Main.rand.Next(7);
				if (num11 == 0)
				{
					this.QuickSpawnItem(758, 1);
					this.QuickSpawnItem(771, Main.rand.Next(50, 150));
				}
				else if (num11 == 1)
				{
					this.QuickSpawnItem(1255, 1);
				}
				else if (num11 == 2)
				{
					this.QuickSpawnItem(788, 1);
				}
				else if (num11 == 3)
				{
					this.QuickSpawnItem(1178, 1);
				}
				else if (num11 == 4)
				{
					this.QuickSpawnItem(1259, 1);
				}
				else if (num11 == 5)
				{
					this.QuickSpawnItem(1155, 1);
				}
				else if (num11 == 6)
				{
					this.QuickSpawnItem(3018, 1);
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
				int num12 = Main.rand.Next(8);
				if (num12 == 0)
				{
					this.QuickSpawnItem(1258, 1);
					this.QuickSpawnItem(1261, Main.rand.Next(60, 100));
				}
				else if (num12 == 1)
				{
					this.QuickSpawnItem(1122, 1);
				}
				else if (num12 == 2)
				{
					this.QuickSpawnItem(899, 1);
				}
				else if (num12 == 3)
				{
					this.QuickSpawnItem(1248, 1);
				}
				else if (num12 == 4)
				{
					this.QuickSpawnItem(1294, 1);
				}
				else if (num12 == 5)
				{
					this.QuickSpawnItem(1295, 1);
				}
				else if (num12 == 6)
				{
					this.QuickSpawnItem(1296, 1);
				}
				else if (num12 == 7)
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
				int num13 = Main.rand.Next(5);
				if (num13 == 0)
				{
					this.QuickSpawnItem(2611, 1);
				}
				else if (num13 == 1)
				{
					this.QuickSpawnItem(2624, 1);
				}
				else if (num13 == 2)
				{
					this.QuickSpawnItem(2622, 1);
				}
				else if (num13 == 3)
				{
					this.QuickSpawnItem(2621, 1);
				}
				else if (num13 == 4)
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
			else if (type == 3860)
			{
				this.TryGettingDevArmor();
				if (Main.rand.Next(7) == 0)
				{
					this.QuickSpawnItem(3863, 1);
				}
				int num14b = Main.rand.Next(4);
				if (num14b == 0)
				{
					this.QuickSpawnItem(3859, 1);
				}
				else if (num14b == 1)
				{
					this.QuickSpawnItem(3827, 1);
				}
				else if (num14b == 2)
				{
					this.QuickSpawnItem(3870, 1);
				}
				else
				{
					this.QuickSpawnItem(3858, 1);
				}
				if (Main.rand.Next(4) == 0)
				{
					this.QuickSpawnItem(3883, 1);
				}
				this.QuickSpawnItem(3817, Main.rand.Next(30, 50));
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
				int item = Utils.SelectRandom<int>(Main.rand, new int[]
				{
					3063,
					3389,
					3065,
					1553,
					3546,
					3541,
					3570,
					3571,
					3569
				});
				this.QuickSpawnItem(item, 1);
			}
			int num14 = -1;
			if (type == 3318)
			{
				num14 = 50;
			}
			if (type == 3319)
			{
				num14 = 4;
			}
			if (type == 3320)
			{
				num14 = 13;
			}
			if (type == 3321)
			{
				num14 = 266;
			}
			if (type == 3322)
			{
				num14 = 222;
			}
			if (type == 3323)
			{
				num14 = 35;
			}
			if (type == 3324)
			{
				num14 = 113;
			}
			if (type == 3325)
			{
				num14 = 134;
			}
			if (type == 3326)
			{
				num14 = 125;
			}
			if (type == 3327)
			{
				num14 = 127;
			}
			if (type == 3328)
			{
				num14 = 262;
			}
			if (type == 3329)
			{
				num14 = 245;
			}
			if (type == 3330)
			{
				num14 = 370;
			}
			if (type == 3331)
			{
				num14 = 439;
			}
			if (type == 3332)
			{
				num14 = 398;
			}
			if (type == 3860)
			{
				num14 = 551;
			}
			if (type == 3861)
			{
				num14 = 576;
			}
			if (type == 3862)
			{
				num14 = 564;
			}
			if (num14 > 0)
			{
				NPC nPC = new NPC();
				nPC.SetDefaults(num14, -1f);
				float num15 = nPC.value;
				num15 *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
				if (Main.rand.Next(5) == 0)
				{
					num15 *= 1f + (float)Main.rand.Next(5, 11) * 0.01f;
				}
				if (Main.rand.Next(10) == 0)
				{
					num15 *= 1f + (float)Main.rand.Next(10, 21) * 0.01f;
				}
				if (Main.rand.Next(15) == 0)
				{
					num15 *= 1f + (float)Main.rand.Next(15, 31) * 0.01f;
				}
				if (Main.rand.Next(20) == 0)
				{
					num15 *= 1f + (float)Main.rand.Next(20, 41) * 0.01f;
				}
				while ((int)num15 > 0)
				{
					if (num15 > 1000000f)
					{
						int num16 = (int)(num15 / 1000000f);
						num15 -= (float)(1000000 * num16);
						this.QuickSpawnItem(74, num16);
					}
					else if (num15 > 10000f)
					{
						int num17 = (int)(num15 / 10000f);
						num15 -= (float)(10000 * num17);
						this.QuickSpawnItem(73, num17);
					}
					else if (num15 > 100f)
					{
						int num18 = (int)(num15 / 100f);
						num15 -= (float)(100 * num18);
						this.QuickSpawnItem(72, num18);
					}
					else
					{
						int num19 = (int)num15;
						if (num19 < 1)
						{
							num19 = 1;
						}
						num15 -= (float)num19;
						this.QuickSpawnItem(71, num19);
					}
				}
			}
		}

		public void openCrate(int type)
		{
			int num = type - 2334;
			if (type >= 3203)
			{
				num = type - 3203 + 3;
			}
			if (num == 0)
			{
				bool flag = true;
				while (flag)
				{
					if (Main.hardMode && flag && Main.rand.Next(200) == 0)
					{
						int number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 3064, 1, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (flag && Main.rand.Next(40) == 0)
					{
						int type2 = 3200;
						int stack = 1;
						int number2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type2, stack, false, -1, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number2, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (flag && Main.rand.Next(40) == 0)
					{
						int type3 = 3201;
						int stack2 = 1;
						int number3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type3, stack2, false, -1, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number3, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (Main.hardMode && flag && Main.rand.Next(25) == 0)
					{
						int type4 = 2424;
						int stack3 = 1;
						int number4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type4, stack3, false, -1, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number4, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (Main.rand.Next(45) == 0)
					{
						int num2 = Main.rand.Next(5);
						if (num2 == 0)
						{
							num2 = 285;
						}
						else if (num2 == 1)
						{
							num2 = 953;
						}
						else if (num2 == 2)
						{
							num2 = 946;
						}
						else if (num2 == 3)
						{
							num2 = 3068;
						}
						else if (num2 == 4)
						{
							num2 = 3084;
						}
						int number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num2, 1, false, -1, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (!Main.hardMode && flag && Main.rand.Next(50) == 0)
					{
						int type5 = 997;
						int stack4 = 1;
						int number6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type5, stack4, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number6, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (Main.rand.Next(7) == 0)
					{
						int type6;
						int stack5;
						if (Main.rand.Next(3) == 0)
						{
							type6 = 73;
							stack5 = Main.rand.Next(1, 6);
						}
						else
						{
							type6 = 72;
							stack5 = Main.rand.Next(20, 91);
						}
						int number7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type6, stack5, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number7, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (Main.rand.Next(7) == 0)
					{
						int num3 = Main.rand.Next(8);
						if (num3 == 0)
						{
							num3 = 12;
						}
						else if (num3 == 1)
						{
							num3 = 11;
						}
						else if (num3 == 2)
						{
							num3 = 14;
						}
						else if (num3 == 3)
						{
							num3 = 13;
						}
						else if (num3 == 4)
						{
							num3 = 699;
						}
						else if (num3 == 5)
						{
							num3 = 700;
						}
						else if (num3 == 6)
						{
							num3 = 701;
						}
						else if (num3 == 7)
						{
							num3 = 702;
						}
						if (Main.hardMode && Main.rand.Next(2) == 0)
						{
							num3 = Main.rand.Next(6);
							if (num3 == 0)
							{
								num3 = 364;
							}
							else if (num3 == 1)
							{
								num3 = 365;
							}
							else if (num3 == 2)
							{
								num3 = 366;
							}
							else if (num3 == 3)
							{
								num3 = 1104;
							}
							else if (num3 == 4)
							{
								num3 = 1105;
							}
							else if (num3 == 5)
							{
								num3 = 1106;
							}
						}
						int stack6 = Main.rand.Next(8, 21);
						int number8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num3, stack6, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number8, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (Main.rand.Next(8) == 0)
					{
						int num4 = Main.rand.Next(8);
						if (num4 == 0)
						{
							num4 = 20;
						}
						else if (num4 == 1)
						{
							num4 = 22;
						}
						else if (num4 == 2)
						{
							num4 = 21;
						}
						else if (num4 == 3)
						{
							num4 = 19;
						}
						else if (num4 == 4)
						{
							num4 = 703;
						}
						else if (num4 == 5)
						{
							num4 = 704;
						}
						else if (num4 == 6)
						{
							num4 = 705;
						}
						else if (num4 == 7)
						{
							num4 = 706;
						}
						int num5 = Main.rand.Next(2, 8);
						if (Main.hardMode && Main.rand.Next(2) == 0)
						{
							num4 = Main.rand.Next(6);
							if (num4 == 0)
							{
								num4 = 381;
							}
							else if (num4 == 1)
							{
								num4 = 382;
							}
							else if (num4 == 2)
							{
								num4 = 391;
							}
							else if (num4 == 3)
							{
								num4 = 1184;
							}
							else if (num4 == 4)
							{
								num4 = 1191;
							}
							else if (num4 == 5)
							{
								num4 = 1198;
							}
							num5 -= Main.rand.Next(2);
						}
						int number9 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num4, num5, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number9, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
					if (Main.rand.Next(7) == 0)
					{
						int num6 = Main.rand.Next(10);
						if (num6 == 0)
						{
							num6 = 288;
						}
						else if (num6 == 1)
						{
							num6 = 290;
						}
						else if (num6 == 2)
						{
							num6 = 292;
						}
						else if (num6 == 3)
						{
							num6 = 299;
						}
						else if (num6 == 4)
						{
							num6 = 298;
						}
						else if (num6 == 5)
						{
							num6 = 304;
						}
						else if (num6 == 6)
						{
							num6 = 291;
						}
						else if (num6 == 7)
						{
							num6 = 2322;
						}
						else if (num6 == 8)
						{
							num6 = 2323;
						}
						else if (num6 == 9)
						{
							num6 = 2329;
						}
						int stack7 = Main.rand.Next(1, 4);
						int number10 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num6, stack7, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number10, 1f, 0f, 0f, 0, 0, 0);
						}
						flag = false;
					}
				}
				if (Main.rand.Next(3) == 0)
				{
					int num7 = Main.rand.Next(2);
					if (num7 == 0)
					{
						num7 = 28;
					}
					else if (num7 == 1)
					{
						num7 = 110;
					}
					int stack8 = Main.rand.Next(5, 16);
					int number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num7, stack8, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.rand.Next(3) == 0)
				{
					int type7;
					if (Main.rand.Next(3) == 0)
					{
						type7 = 2675;
					}
					else
					{
						type7 = 2674;
					}
					int stack9 = Main.rand.Next(1, 5);
					int number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type7, stack9, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
			}
			else if (num == 1)
			{
				bool flag2 = true;
				while (flag2)
				{
					if (Main.hardMode && flag2 && Main.rand.Next(60) == 0)
					{
						int number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 3064, 1, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0, 0, 0);
						}
						flag2 = false;
					}
					if (flag2 && Main.rand.Next(25) == 0)
					{
						int type8 = 2501;
						int stack10 = 1;
						int number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type8, stack10, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0, 0, 0);
						}
						flag2 = false;
					}
					if (flag2 && Main.rand.Next(20) == 0)
					{
						int type9 = 2587;
						int stack11 = 1;
						int number15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type9, stack11, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number15, 1f, 0f, 0f, 0, 0, 0);
						}
						flag2 = false;
					}
					if (flag2 && Main.rand.Next(15) == 0)
					{
						int type10 = 2608;
						int stack12 = 1;
						int number16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type10, stack12, false, -1, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number16, 1f, 0f, 0f, 0, 0, 0);
						}
						flag2 = false;
					}
					if (flag2 && Main.rand.Next(20) == 0)
					{
						int type11 = 3200;
						int stack13 = 1;
						int number17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type11, stack13, false, -1, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number17, 1f, 0f, 0f, 0, 0, 0);
						}
						flag2 = false;
					}
					if (flag2 && Main.rand.Next(20) == 0)
					{
						int type12 = 3201;
						int stack14 = 1;
						int number18 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type12, stack14, false, -1, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number18, 1f, 0f, 0f, 0, 0, 0);
						}
						flag2 = false;
					}
					if (Main.rand.Next(4) == 0)
					{
						int type13 = 73;
						int stack15 = Main.rand.Next(5, 11);
						int number19 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type13, stack15, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number19, 1f, 0f, 0f, 0, 0, 0);
						}
						flag2 = false;
					}
					if (Main.rand.Next(4) == 0)
					{
						int num8 = Main.rand.Next(8);
						if (num8 == 0)
						{
							num8 = 20;
						}
						else if (num8 == 1)
						{
							num8 = 22;
						}
						else if (num8 == 2)
						{
							num8 = 21;
						}
						else if (num8 == 3)
						{
							num8 = 19;
						}
						else if (num8 == 4)
						{
							num8 = 703;
						}
						else if (num8 == 5)
						{
							num8 = 704;
						}
						else if (num8 == 6)
						{
							num8 = 705;
						}
						else if (num8 == 7)
						{
							num8 = 706;
						}
						int num9 = Main.rand.Next(6, 15);
						if (Main.hardMode && Main.rand.Next(3) != 0)
						{
							num8 = Main.rand.Next(6);
							if (num8 == 0)
							{
								num8 = 381;
							}
							else if (num8 == 1)
							{
								num8 = 382;
							}
							else if (num8 == 2)
							{
								num8 = 391;
							}
							else if (num8 == 3)
							{
								num8 = 1184;
							}
							else if (num8 == 4)
							{
								num8 = 1191;
							}
							else if (num8 == 5)
							{
								num8 = 1198;
							}
							num9 -= Main.rand.Next(2);
						}
						int number20 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num8, num9, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number20, 1f, 0f, 0f, 0, 0, 0);
						}
						flag2 = false;
					}
					if (Main.rand.Next(4) == 0)
					{
						int num10 = Main.rand.Next(8);
						if (num10 == 0)
						{
							num10 = 288;
						}
						else if (num10 == 1)
						{
							num10 = 296;
						}
						else if (num10 == 2)
						{
							num10 = 304;
						}
						else if (num10 == 3)
						{
							num10 = 305;
						}
						else if (num10 == 4)
						{
							num10 = 2322;
						}
						else if (num10 == 5)
						{
							num10 = 2323;
						}
						else if (num10 == 6)
						{
							num10 = 2324;
						}
						else if (num10 == 7)
						{
							num10 = 2327;
						}
						int stack16 = Main.rand.Next(2, 5);
						int number21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num10, stack16, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number21, 1f, 0f, 0f, 0, 0, 0);
						}
						flag2 = false;
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					int type14 = Main.rand.Next(188, 190);
					int stack17 = Main.rand.Next(5, 16);
					int number22 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type14, stack17, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number22, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					int type15;
					if (Main.rand.Next(3) == 0)
					{
						type15 = 2676;
					}
					else
					{
						type15 = 2675;
					}
					int stack18 = Main.rand.Next(2, 5);
					int number23 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type15, stack18, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number23, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
			}
			else if (num == 2)
			{
				bool flag3 = true;
				while (flag3)
				{
					if (Main.hardMode && flag3 && Main.rand.Next(20) == 0)
					{
						int number24 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 3064, 1, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number24, 1f, 0f, 0f, 0, 0, 0);
						}
						flag3 = false;
					}
					if (flag3 && Main.rand.Next(10) == 0)
					{
						int type16 = 2491;
						int stack19 = 1;
						int number25 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type16, stack19, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number25, 1f, 0f, 0f, 0, 0, 0);
						}
						flag3 = false;
					}
					if (Main.rand.Next(3) == 0)
					{
						int type17 = 73;
						int stack20 = Main.rand.Next(8, 21);
						int number26 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type17, stack20, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number26, 1f, 0f, 0f, 0, 0, 0);
						}
						flag3 = false;
					}
					if (Main.rand.Next(3) == 0)
					{
						int num11 = Main.rand.Next(4);
						if (num11 == 0)
						{
							num11 = 21;
						}
						else if (num11 == 1)
						{
							num11 = 19;
						}
						else if (num11 == 2)
						{
							num11 = 705;
						}
						else if (num11 == 3)
						{
							num11 = 706;
						}
						if (Main.hardMode && Main.rand.Next(3) != 0)
						{
							num11 = Main.rand.Next(4);
							if (num11 == 0)
							{
								num11 = 382;
							}
							else if (num11 == 1)
							{
								num11 = 391;
							}
							else if (num11 == 2)
							{
								num11 = 1191;
							}
							else if (num11 == 3)
							{
								num11 = 1198;
							}
						}
						int stack21 = Main.rand.Next(15, 31);
						int number27 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num11, stack21, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number27, 1f, 0f, 0f, 0, 0, 0);
						}
						flag3 = false;
					}
				}
				if (Main.rand.Next(3) == 0)
				{
					int num12 = Main.rand.Next(5);
					if (num12 == 0)
					{
						num12 = 288;
					}
					else if (num12 == 1)
					{
						num12 = 296;
					}
					else if (num12 == 2)
					{
						num12 = 305;
					}
					else if (num12 == 3)
					{
						num12 = 2322;
					}
					else if (num12 == 4)
					{
						num12 = 2323;
					}
					int stack22 = Main.rand.Next(2, 6);
					int number28 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num12, stack22, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number28, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					int type18 = Main.rand.Next(499, 501);
					int stack23 = Main.rand.Next(5, 21);
					int number29 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type18, stack23, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number29, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.rand.Next(3) != 0)
				{
					int type19 = 2676;
					int stack24 = Main.rand.Next(3, 8);
					int number30 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type19, stack24, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number30, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
			}
			else
			{
				int maxValue = 6;
				bool flag4 = true;
				while (flag4)
				{
					if (num == 3 && flag4 && Main.rand.Next(maxValue) == 0)
					{
						int num13 = Main.rand.Next(5);
						if (num13 == 0)
						{
							num13 = 162;
						}
						else if (num13 == 1)
						{
							num13 = 111;
						}
						else if (num13 == 2)
						{
							num13 = 96;
						}
						else if (num13 == 3)
						{
							num13 = 115;
						}
						else
						{
							num13 = 64;
						}
						int number31 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num13, 1, false, -1, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number31, 1f, 0f, 0f, 0, 0, 0);
						}
						flag4 = false;
					}
					if (num == 4 && flag4 && Main.rand.Next(maxValue) == 0)
					{
						int num14 = Main.rand.Next(5);
						if (num14 == 0)
						{
							num14 = 800;
						}
						else if (num14 == 1)
						{
							num14 = 802;
						}
						else if (num14 == 2)
						{
							num14 = 1256;
						}
						else if (num14 == 3)
						{
							num14 = 1290;
						}
						else
						{
							num14 = 3062;
						}
						int number32 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num14, 1, false, -1, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number32, 1f, 0f, 0f, 0, 0, 0);
						}
						flag4 = false;
					}
					if (num == 5 && flag4 && Main.rand.Next(maxValue) == 0)
					{
						int type20 = 3085;
						int number33 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type20, 1, false, -1, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number33, 1f, 0f, 0f, 0, 0, 0);
						}
						flag4 = false;
					}
					if (num == 6 && flag4 && Main.rand.Next(maxValue) == 0)
					{
						int num15 = Main.rand.Next(3);
						if (num15 == 0)
						{
							num15 = 158;
						}
						else if (num15 == 1)
						{
							num15 = 65;
						}
						else
						{
							num15 = 159;
						}
						int number34 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num15, 1, false, -1, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number34, 1f, 0f, 0f, 0, 0, 0);
						}
						flag4 = false;
					}
					if (num == 8 && flag4 && Main.rand.Next(maxValue) == 0)
					{
						int num16 = Main.rand.Next(5);
						if (num16 == 0)
						{
							num16 = 212;
						}
						else if (num16 == 1)
						{
							num16 = 964;
						}
						else if (num16 == 2)
						{
							num16 = 211;
						}
						else if (num16 == 3)
						{
							num16 = 213;
						}
						else
						{
							num16 = 2292;
						}
						int number35 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num16, 1, false, -1, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number35, 1f, 0f, 0f, 0, 0, 0);
						}
						flag4 = false;
					}
					if (Main.rand.Next(4) == 0)
					{
						int type21 = 73;
						int stack25 = Main.rand.Next(5, 13);
						int number36 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type21, stack25, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number36, 1f, 0f, 0f, 0, 0, 0);
						}
						flag4 = false;
					}
					if (Main.rand.Next(4) == 0)
					{
						int num17 = Main.rand.Next(6);
						if (num17 == 0)
						{
							num17 = 22;
						}
						else if (num17 == 1)
						{
							num17 = 21;
						}
						else if (num17 == 2)
						{
							num17 = 19;
						}
						else if (num17 == 3)
						{
							num17 = 704;
						}
						else if (num17 == 4)
						{
							num17 = 705;
						}
						else if (num17 == 5)
						{
							num17 = 706;
						}
						int num18 = Main.rand.Next(10, 21);
						if (Main.hardMode && Main.rand.Next(3) != 0)
						{
							num17 = Main.rand.Next(6);
							if (num17 == 0)
							{
								num17 = 381;
							}
							else if (num17 == 1)
							{
								num17 = 382;
							}
							else if (num17 == 2)
							{
								num17 = 391;
							}
							else if (num17 == 3)
							{
								num17 = 1184;
							}
							else if (num17 == 4)
							{
								num17 = 1191;
							}
							else if (num17 == 5)
							{
								num17 = 1198;
							}
							num18 -= Main.rand.Next(3);
						}
						int number37 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num17, num18, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number37, 1f, 0f, 0f, 0, 0, 0);
						}
						flag4 = false;
					}
				}
				if (Main.rand.Next(4) == 0)
				{
					int num19 = Main.rand.Next(6);
					if (num19 == 0)
					{
						num19 = 288;
					}
					else if (num19 == 1)
					{
						num19 = 296;
					}
					else if (num19 == 2)
					{
						num19 = 304;
					}
					else if (num19 == 3)
					{
						num19 = 305;
					}
					else if (num19 == 4)
					{
						num19 = 2322;
					}
					else if (num19 == 5)
					{
						num19 = 2323;
					}
					int stack26 = Main.rand.Next(2, 5);
					int number38 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num19, stack26, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number38, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					int type22 = Main.rand.Next(188, 190);
					int stack27 = Main.rand.Next(5, 18);
					int number39 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type22, stack27, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number39, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					int type23;
					if (Main.rand.Next(2) == 0)
					{
						type23 = 2676;
					}
					else
					{
						type23 = 2675;
					}
					int stack28 = Main.rand.Next(2, 7);
					int number40 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type23, stack28, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number40, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (num == 3 || num == 4 || num == 7)
				{
					if (Main.hardMode && Main.rand.Next(2) == 0)
					{
						int type24 = 521;
						if (num == 7)
						{
							type24 = 520;
						}
						int stack29 = Main.rand.Next(2, 6);
						int number41 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type24, stack29, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number41, 1f, 0f, 0f, 0, 0, 0);
						}
					}
					if (Main.hardMode && Main.rand.Next(2) == 0)
					{
						int type25 = 522;
						int stack30 = Main.rand.Next(2, 6);
						if (num == 4)
						{
							type25 = 1332;
						}
						else if (num == 7)
						{
							type25 = 502;
							stack30 = Main.rand.Next(4, 11);
						}
						int number42 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type25, stack30, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number42, 1f, 0f, 0f, 0, 0, 0);
						}
					}
				}
			}
		}

		public void openGoodieBag()
		{
			if (Main.rand.Next(150) == 0)
			{
				int number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1810, 1, false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int number2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1800, 1, false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number2, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(4) == 0)
			{
				int number3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1809, Main.rand.Next(10, 41), false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number3, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(10) == 0)
			{
				int number4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Main.rand.Next(1846, 1851), 1, false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number4, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else
			{
				int num = Main.rand.Next(19);
				if (num == 0)
				{
					int number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1749, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0, 0, 0);
					}
					number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1750, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0, 0, 0);
					}
					number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1751, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 1)
				{
					int number6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1746, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number6, 1f, 0f, 0f, 0, 0, 0);
					}
					number6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1747, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number6, 1f, 0f, 0f, 0, 0, 0);
					}
					number6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1748, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number6, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 2)
				{
					int number7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1752, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number7, 1f, 0f, 0f, 0, 0, 0);
					}
					number7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1753, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number7, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 3)
				{
					int number8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1767, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number8, 1f, 0f, 0f, 0, 0, 0);
					}
					number8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1768, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number8, 1f, 0f, 0f, 0, 0, 0);
					}
					number8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1769, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number8, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 4)
				{
					int number9 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1770, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number9, 1f, 0f, 0f, 0, 0, 0);
					}
					number9 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1771, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number9, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 5)
				{
					int number10 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1772, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number10, 1f, 0f, 0f, 0, 0, 0);
					}
					number10 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1773, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number10, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 6)
				{
					int number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1754, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0, 0, 0);
					}
					number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1755, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0, 0, 0);
					}
					number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1756, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 7)
				{
					int number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1757, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0, 0, 0);
					}
					number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1758, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0, 0, 0);
					}
					number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1759, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 8)
				{
					int number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1760, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0, 0, 0);
					}
					number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1761, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0, 0, 0);
					}
					number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1762, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 9)
				{
					int number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1763, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0, 0, 0);
					}
					number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1764, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0, 0, 0);
					}
					number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1765, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 10)
				{
					int number15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1766, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number15, 1f, 0f, 0f, 0, 0, 0);
					}
					number15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1775, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number15, 1f, 0f, 0f, 0, 0, 0);
					}
					number15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1776, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number15, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 11)
				{
					int number16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1777, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number16, 1f, 0f, 0f, 0, 0, 0);
					}
					number16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1778, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number16, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 12)
				{
					int number17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1779, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number17, 1f, 0f, 0f, 0, 0, 0);
					}
					number17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1780, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number17, 1f, 0f, 0f, 0, 0, 0);
					}
					number17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1781, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number17, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 13)
				{
					int number18 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1819, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number18, 1f, 0f, 0f, 0, 0, 0);
					}
					number18 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1820, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number18, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 14)
				{
					int number19 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1821, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number19, 1f, 0f, 0f, 0, 0, 0);
					}
					number19 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1822, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number19, 1f, 0f, 0f, 0, 0, 0);
					}
					number19 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1823, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number19, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 15)
				{
					int number20 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1824, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number20, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 16)
				{
					int number21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1838, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number21, 1f, 0f, 0f, 0, 0, 0);
					}
					number21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1839, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number21, 1f, 0f, 0f, 0, 0, 0);
					}
					number21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1840, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number21, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 17)
				{
					int number22 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1841, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number22, 1f, 0f, 0f, 0, 0, 0);
					}
					number22 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1842, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number22, 1f, 0f, 0f, 0, 0, 0);
					}
					number22 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1843, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number22, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 18)
				{
					int number23 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1851, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number23, 1f, 0f, 0f, 0, 0, 0);
					}
					number23 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1852, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number23, 1f, 0f, 0f, 0, 0, 0);
					}
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
				int num2 = Main.rand.Next(14);
				if (num2 == 0)
				{
					num2 = 313;
				}
				if (num2 == 1)
				{
					num2 = 314;
				}
				if (num2 == 2)
				{
					num2 = 315;
				}
				if (num2 == 3)
				{
					num2 = 317;
				}
				if (num2 == 4)
				{
					num2 = 316;
				}
				if (num2 == 5)
				{
					num2 = 318;
				}
				if (num2 == 6)
				{
					num2 = 2358;
				}
				if (num2 == 7)
				{
					num2 = 307;
				}
				if (num2 == 8)
				{
					num2 = 308;
				}
				if (num2 == 9)
				{
					num2 = 309;
				}
				if (num2 == 10)
				{
					num2 = 311;
				}
				if (num2 == 11)
				{
					num2 = 310;
				}
				if (num2 == 12)
				{
					num2 = 312;
				}
				if (num2 == 13)
				{
					num2 = 2357;
				}
				int num3 = Main.rand.Next(2, 5);
				if (Main.rand.Next(3) == 0)
				{
					num3 += Main.rand.Next(1, 5);
				}
				int number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num2, num3, false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0, 0, 0);
				}
			}
		}
		public int CountItem(int type, int stopCountingAt = 0)
		{
			int num = 0;
			for (int num2 = 0; num2 != 58; num2++)
			{
				if (this.inventory[num2].stack > 0 && this.inventory[num2].type == type)
				{
					num += this.inventory[num2].stack;
					if (num >= stopCountingAt)
					{
						return num;
					}
				}
			}
			return num;
		}
		public bool ConsumeItem(int type, bool reverseOrder = false)
		{
			int num = 0;
			int num2 = 58;
			int num3 = 1;
			if (reverseOrder)
			{
				num = 57;
				num2 = -1;
				num3 = -1;
			}
			for (int num4 = num; num4 != num2; num4 += num3)
			{
				if (this.inventory[num4].stack > 0 && this.inventory[num4].type == type)
				{
					this.inventory[num4].stack--;
					if (this.inventory[num4].stack <= 0)
					{
						this.inventory[num4].SetDefaults(0, false);
					}
					return true;
				}
			}
			return false;
		}
		public void openLockBox()
		{
			bool flag = true;
			while (flag)
			{
				flag = false;
				int num = Main.rand.Next(7);
				int type;
				if (num == 1)
				{
					type = 329;
				}
				else if (num == 2)
				{
					type = 155;
				}
				else if (num == 3)
				{
					type = 156;
				}
				else if (num == 4)
				{
					type = 157;
				}
				else if (num == 5)
				{
					type = 163;
				}
				else if (num == 6)
				{
					type = 113;
				}
				else
				{
					type = 164;
				}
				int number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type, 1, false, -1, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0, 0, 0);
				}
				if (Main.rand.Next(3) == 0)
				{
					flag = false;
					int num2 = Main.rand.Next(1, 4);
					if (Main.rand.Next(2) == 0)
					{
						num2 += Main.rand.Next(2);
					}
					if (Main.rand.Next(3) == 0)
					{
						num2 += Main.rand.Next(3);
					}
					if (Main.rand.Next(4) == 0)
					{
						num2 += Main.rand.Next(3);
					}
					if (Main.rand.Next(5) == 0)
					{
						num2 += Main.rand.Next(1, 3);
					}
					int number2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 73, num2, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number2, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					flag = false;
					int number3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 72, Main.rand.Next(10, 100), false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number3, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.rand.Next(3) == 0)
				{
					flag = false;
					int number4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 188, Main.rand.Next(2, 6), false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number4, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.rand.Next(3) == 0)
				{
					flag = false;
					int num3 = Main.rand.Next(9);
					if (num3 == 0)
					{
						num3 = 296;
					}
					else if (num3 == 1)
					{
						num3 = 2346;
					}
					else if (num3 == 2)
					{
						num3 = 305;
					}
					else if (num3 == 3)
					{
						num3 = 2323;
					}
					else if (num3 == 4)
					{
						num3 = 292;
					}
					else if (num3 == 5)
					{
						num3 = 294;
					}
					else if (num3 == 6)
					{
						num3 = 288;
					}
					else if (Main.netMode == 1)
					{
						num3 = 2997;
					}
					else
					{
						num3 = 2350;
					}
					int number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num3, Main.rand.Next(1, 4), false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0, 0, 0);
					}
				}
			}
		}

		public void openPresent()
		{
			if (Main.rand.Next(15) == 0 && Main.hardMode)
			{
				int number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 602, 1, false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(30) == 0)
			{
				int number2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1922, 1, false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number2, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(400) == 0)
			{
				int number3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1927, 1, false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number3, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int number4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1870, 1, false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number4, 1f, 0f, 0f, 0, 0, 0);
				}
				number4 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 97, Main.rand.Next(30, 61), false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number4, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int number5 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1909, 1, false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number5, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int number6 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1917, 1, false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number6, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int number7 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1915, 1, false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number7, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int number8 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1918, 1, false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number8, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(150) == 0)
			{
				int number9 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1921, 1, false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number9, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(300) == 0)
			{
				int number10 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1923, 1, false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number10, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(40) == 0)
			{
				int number11 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1907, 1, false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number11, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(10) == 0)
			{
				int number12 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1908, 1, false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number12, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(15) == 0)
			{
				int num = Main.rand.Next(5);
				if (num == 0)
				{
					int number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1932, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0, 0, 0);
					}
					number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1933, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0, 0, 0);
					}
					number13 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1934, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 1)
				{
					int number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1935, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0, 0, 0);
					}
					number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1936, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0, 0, 0);
					}
					number14 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1937, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number14, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 2)
				{
					int number15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1940, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number15, 1f, 0f, 0f, 0, 0, 0);
					}
					number15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1941, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number15, 1f, 0f, 0f, 0, 0, 0);
					}
					number15 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1942, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number15, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 3)
				{
					int number16 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1938, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number16, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num == 4)
				{
					int number17 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1939, 1, false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number17, 1f, 0f, 0f, 0, 0, 0);
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
				int number18 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num2, 1, false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number18, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(8) == 0)
			{
				int number19 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1912, Main.rand.Next(1, 4), false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number19, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.rand.Next(9) == 0)
			{
				int number20 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1913, Main.rand.Next(20, 41), false, 0, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number20, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else
			{
				int num3 = Main.rand.Next(3);
				if (num3 == 0)
				{
					int number21 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 1872, Main.rand.Next(20, 50), false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number21, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else if (num3 == 1)
				{
					int number22 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 586, Main.rand.Next(20, 50), false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number22, 1f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				else
				{
					int number23 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 591, Main.rand.Next(20, 50), false, 0, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number23, 1f, 0f, 0f, 0, 0, 0);
					}
				}
			}
		}

		public void PickAmmo(Item sItem, ref int shoot, ref float speed, ref bool canShoot, ref int Damage, ref float KnockBack, bool dontConsume = false)
		{
			Item item = new Item();
			bool flag = false;
			for (int i = 54; i < 58; i++)
			{
				if (this.inventory[i].ammo == sItem.useAmmo && this.inventory[i].stack > 0)
				{
					item = this.inventory[i];
					canShoot = true;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				for (int j = 0; j < 54; j++)
				{
					if (this.inventory[j].ammo == sItem.useAmmo && this.inventory[j].stack > 0)
					{
						item = this.inventory[j];
						canShoot = true;
						break;
					}
				}
			}
			if (canShoot)
			{
				if (sItem.type == 1946)
				{
					shoot = 338 + item.type - 771;
				}
				else if (sItem.useAmmo == 771)
				{
					shoot += item.shoot;
				}
				else if (sItem.useAmmo == 780)
				{
					shoot += item.shoot;
				}
				else if (item.shoot > 0)
				{
					shoot = item.shoot;
				}
				if (sItem.type == 3019 && shoot == 1)
				{
					shoot = 485;
				}
				if (sItem.type == 3052)
				{
					shoot = 495;
				}
				if (sItem.type == 3245 && shoot == 21)
				{
					shoot = 532;
				}
				if (shoot == 42)
				{
					if (item.type == 370)
					{
						shoot = 65;
						Damage += 5;
					}
					else if (item.type == 408)
					{
						shoot = 68;
						Damage += 5;
					}
					else if (item.type == 1246)
					{
						shoot = 354;
						Damage += 5;
					}
				}
				if (this.inventory[this.selectedItem].type == 2888 && shoot == 1)
				{
					shoot = 469;
				}
				if (this.magicQuiver && (sItem.useAmmo == 1 || sItem.useAmmo == 323))
				{
					KnockBack = (float)((int)((double)KnockBack * 1.1));
					speed *= 1.1f;
				}
				speed += item.shootSpeed;
				if (item.ranged)
				{
					if (item.damage > 0)
					{
						Damage += (int)((float)item.damage * this.rangedDamage);
					}
				}
				else
				{
					Damage += item.damage;
				}
				if (sItem.useAmmo == 1 && this.archery)
				{
					if (speed < 20f)
					{
						speed *= 1.2f;
						if (speed > 20f)
						{
							speed = 20f;
						}
					}
					Damage = (int)((double)((float)Damage) * 1.2);
				}
				KnockBack += item.knockBack;
				bool flag2 = dontConsume;
				if (sItem.type == 3245)
				{
					if (Main.rand.Next(3) == 0)
					{
						flag2 = true;
					}
					else if (this.thrownCost33 && Main.rand.Next(100) < 33)
					{
						flag2 = true;
					}
					else if (this.thrownCost50 && Main.rand.Next(100) < 50)
					{
						flag2 = true;
					}
				}
				if (sItem.type == 3475 && Main.rand.Next(3) != 0)
				{
					flag2 = true;
				}
				if (sItem.type == 3540 && Main.rand.Next(3) != 0)
				{
					flag2 = true;
				}
				if (this.magicQuiver && sItem.useAmmo == 1 && Main.rand.Next(5) == 0)
				{
					flag2 = true;
				}
				if (this.ammoBox && Main.rand.Next(5) == 0)
				{
					flag2 = true;
				}
				if (this.ammoPotion && Main.rand.Next(5) == 0)
				{
					flag2 = true;
				}
				if (sItem.type == 1782 && Main.rand.Next(3) == 0)
				{
					flag2 = true;
				}
				if (sItem.type == 98 && Main.rand.Next(3) == 0)
				{
					flag2 = true;
				}
				if (sItem.type == 2270 && Main.rand.Next(2) == 0)
				{
					flag2 = true;
				}
				if (sItem.type == 533 && Main.rand.Next(2) == 0)
				{
					flag2 = true;
				}
				if (sItem.type == 1929 && Main.rand.Next(2) == 0)
				{
					flag2 = true;
				}
				if (sItem.type == 1553 && Main.rand.Next(2) == 0)
				{
					flag2 = true;
				}
				if (sItem.type == 434 && this.itemAnimation < sItem.useAnimation - 2)
				{
					flag2 = true;
				}
				if (this.ammoCost80 && Main.rand.Next(5) == 0)
				{
					flag2 = true;
				}
				if (this.ammoCost75 && Main.rand.Next(4) == 0)
				{
					flag2 = true;
				}
				if (shoot == 85 && this.itemAnimation < this.itemAnimationMax - 6)
				{
					flag2 = true;
				}
				if ((shoot == 145 || shoot == 146 || shoot == 147 || shoot == 148 || shoot == 149) && this.itemAnimation < this.itemAnimationMax - 5)
				{
					flag2 = true;
				}
				if (!flag2 && item.consumable)
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

		public void PickTile(int x, int y, int pickPower)
		{
			int num = 0;
			int tileId = this.hitTile.HitObject(x, y, 1);
			Tile tile = Main.tile[x, y];
			if (Main.tileNoFail[(int)tile.type])
			{
				num = 100;
			}
			if (Main.tileDungeon[(int)tile.type] || tile.type == 25 || tile.type == 58 || tile.type == 117 || tile.type == 203)
			{
				num += pickPower / 2;
			}
			else if (tile.type == 48 || tile.type == 232)
			{
				num += pickPower / 4;
			}
			else if (tile.type == 226)
			{
				num += pickPower / 4;
			}
			else if (tile.type == 107 || tile.type == 221)
			{
				num += pickPower / 2;
			}
			else if (tile.type == 108 || tile.type == 222)
			{
				num += pickPower / 3;
			}
			else if (tile.type == 111 || tile.type == 223)
			{
				num += pickPower / 4;
			}
			else if (tile.type == 211)
			{
				num += pickPower / 5;
			}
			else
			{
				num += pickPower;
			}
			if (tile.type == 211 && pickPower < 200)
			{
				num = 0;
			}
			if ((tile.type == 25 || tile.type == 203) && pickPower < 65)
			{
				num = 0;
			}
			else if (tile.type == 117 && pickPower < 65)
			{
				num = 0;
			}
			else if (tile.type == 37 && pickPower < 50)
			{
				num = 0;
			}
			else if (tile.type == 404 && pickPower < 65)
			{
				num = 0;
			}
			else if ((tile.type == 22 || tile.type == 204) && (double)y > Main.worldSurface && pickPower < 55)
			{
				num = 0;
			}
			else if (tile.type == 56 && pickPower < 65)
			{
				num = 0;
			}
			else if (tile.type == 58 && pickPower < 65)
			{
				num = 0;
			}
			else if ((tile.type == 226 || tile.type == 237) && pickPower < 210)
			{
				num = 0;
			}
			else if (Main.tileDungeon[(int)tile.type] && pickPower < 65)
			{
				if ((double)x < (double)Main.maxTilesX * 0.35 || (double)x > (double)Main.maxTilesX * 0.65)
				{
					num = 0;
				}
			}
			else if (tile.type == 107 && pickPower < 100)
			{
				num = 0;
			}
			else if (tile.type == 108 && pickPower < 110)
			{
				num = 0;
			}
			else if (tile.type == 111 && pickPower < 150)
			{
				num = 0;
			}
			else if (tile.type == 221 && pickPower < 100)
			{
				num = 0;
			}
			else if (tile.type == 222 && pickPower < 110)
			{
				num = 0;
			}
			else if (tile.type == 223 && pickPower < 150)
			{
				num = 0;
			}
			if (tile.type == 147 || tile.type == 0 || tile.type == 40 || tile.type == 53 || tile.type == 57 || tile.type == 59 || tile.type == 123 || tile.type == 224 || tile.type == 397)
			{
				num += pickPower;
			}
			if (tile.type == 165 || Main.tileRope[(int)tile.type] || tile.type == 199 || Main.tileMoss[(int)tile.type])
			{
				num = 100;
			}
			if (this.hitTile.AddDamage(tileId, num, false) >= 100 && (tile.type == 2 || tile.type == 23 || tile.type == 60 || tile.type == 70 || tile.type == 109 || tile.type == 199 || Main.tileMoss[(int)tile.type]))
			{
				num = 0;
			}
			if (tile.type == 128 || tile.type == 269)
			{
				if (tile.frameX == 18 || tile.frameX == 54)
				{
					x--;
					tile = Main.tile[x, y];
					this.hitTile.UpdatePosition(tileId, x, y);
				}
				if (tile.frameX >= 100)
				{
					num = 0;
					Main.blockMouse = true;
				}
			}
			if (tile.type == 334)
			{
				if (tile.frameY == 0)
				{
					y++;
					tile = Main.tile[x, y];
					this.hitTile.UpdatePosition(tileId, x, y);
				}
				if (tile.frameY == 36)
				{
					y--;
					tile = Main.tile[x, y];
					this.hitTile.UpdatePosition(tileId, x, y);
				}
				int i = (int)tile.frameX;
				bool flag = i >= 5000;
				bool flag2 = false;
				if (!flag)
				{
					int num2 = i / 18;
					num2 %= 3;
					x -= num2;
					tile = Main.tile[x, y];
					if (tile.frameX >= 5000)
					{
						flag = true;
					}
				}
				if (flag)
				{
					i = (int)tile.frameX;
					int num3 = 0;
					while (i >= 5000)
					{
						i -= 5000;
						num3++;
					}
					if (num3 != 0)
					{
						flag2 = true;
					}
				}
				if (flag2)
				{
					num = 0;
					Main.blockMouse = true;
				}
			}
			if (!WorldGen.CanKillTile(x, y))
			{
				num = 0;
			}
			if (this.hitTile.AddDamage(tileId, num, true) >= 100)
			{
				AchievementsHelper.CurrentlyMining = true;
				this.hitTile.Clear(tileId);
				if (Main.netMode == 1 && Main.tileContainer[(int)Main.tile[x, y].type])
				{
					WorldGen.KillTile(x, y, true, false, false);
					NetMessage.SendData(17, -1, -1, "", 0, (float)x, (float)y, 1f, 0, 0, 0);
					if (Main.tile[x, y].type == 21)
					{
						NetMessage.SendData(34, -1, -1, "", 1, (float)x, (float)y, 0f, 0, 0, 0);
					}
					if (Main.tile[x, y].type == 88)
					{
						NetMessage.SendData(34, -1, -1, "", 3, (float)x, (float)y, 0f, 0, 0, 0);
					}
				}
				else
				{
					int num4 = y;
					Main.tile[x, num4].active();
					WorldGen.KillTile(x, num4, false, false, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(17, -1, -1, "", 0, (float)x, (float)num4, 0f, 0, 0, 0);
					}
				}
				AchievementsHelper.CurrentlyMining = false;
			}
			else
			{
				WorldGen.KillTile(x, y, true, false, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(17, -1, -1, "", 0, (float)x, (float)y, 1f, 0, 0, 0);
				}
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
					NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)y, 1f, 0, 0, 0);
				}
			}
			if (Main.netMode == 1)
			{
				NetMessage.SendData(89, -1, -1, "", x, (float)y, (float)this.selectedItem, (float)this.whoAmI, 0, 0, 0);
			}
			else
			{
				TEItemFrame.TryPlacing(x, y, this.inventory[this.selectedItem].netID, (int)this.inventory[this.selectedItem].prefix, this.inventory[this.selectedItem].stack);
			}
			this.inventory[this.selectedItem].stack--;
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
			if ((this.inventory[this.selectedItem].type == 929 || this.inventory[this.selectedItem].type == 1338 || this.inventory[this.selectedItem].type == 1345) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
			{
				int num13 = Player.tileTargetX;
				int num14 = Player.tileTargetY;
				if (Main.tile[num13, num14].active() && Main.tile[num13, num14].type == 209)
				{
					this.ShootFromCannon(num13, num14);
				}
			}
			if (this.inventory[this.selectedItem].type >= 1874 && this.inventory[this.selectedItem].type <= 1905 && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 171 && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
			{
				int num15 = this.inventory[this.selectedItem].type;
				if (num15 >= 1874 && num15 <= 1877)
				{
					num15 -= 1873;
					if (WorldGen.checkXmasTreeDrop(Player.tileTargetX, Player.tileTargetY, 0) != num15)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						WorldGen.dropXmasTree(Player.tileTargetX, Player.tileTargetY, 0);
						WorldGen.setXmasTree(Player.tileTargetX, Player.tileTargetY, 0, num15);
						int num16 = Player.tileTargetX;
						int num17 = Player.tileTargetY;
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 10)
						{
							num16 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameX;
							num17 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
						}
						NetMessage.SendTileSquare(-1, num16, num17, 1, TileChangeType.None);
					}
				}
				else if (num15 >= 1878 && num15 <= 1883)
				{
					num15 -= 1877;
					if (WorldGen.checkXmasTreeDrop(Player.tileTargetX, Player.tileTargetY, 1) != num15)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						WorldGen.dropXmasTree(Player.tileTargetX, Player.tileTargetY, 1);
						WorldGen.setXmasTree(Player.tileTargetX, Player.tileTargetY, 1, num15);
						int num18 = Player.tileTargetX;
						int num19 = Player.tileTargetY;
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 10)
						{
							num18 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameX;
							num19 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
						}
						NetMessage.SendTileSquare(-1, num18, num19, 1, TileChangeType.None);
					}
				}
				else if (num15 >= 1884 && num15 <= 1894)
				{
					num15 -= 1883;
					if (WorldGen.checkXmasTreeDrop(Player.tileTargetX, Player.tileTargetY, 2) != num15)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						WorldGen.dropXmasTree(Player.tileTargetX, Player.tileTargetY, 2);
						WorldGen.setXmasTree(Player.tileTargetX, Player.tileTargetY, 2, num15);
						int num20 = Player.tileTargetX;
						int num21 = Player.tileTargetY;
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 10)
						{
							num20 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameX;
							num21 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
						}
						NetMessage.SendTileSquare(-1, num20, num21, 1, TileChangeType.None);
					}
				}
				else if (num15 >= 1895 && num15 <= 1905)
				{
					num15 -= 1894;
					if (WorldGen.checkXmasTreeDrop(Player.tileTargetX, Player.tileTargetY, 3) != num15)
					{
						this.itemTime = this.inventory[this.selectedItem].useTime;
						WorldGen.dropXmasTree(Player.tileTargetX, Player.tileTargetY, 3);
						WorldGen.setXmasTree(Player.tileTargetX, Player.tileTargetY, 3, num15);
						int num22 = Player.tileTargetX;
						int num23 = Player.tileTargetY;
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX < 10)
						{
							num22 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameX;
							num23 -= (int)Main.tile[Player.tileTargetX, Player.tileTargetY].frameY;
						}
						NetMessage.SendTileSquare(-1, num22, num23, 1, TileChangeType.None);
					}
				}
			}
			if (ItemID.Sets.ExtractinatorMode[this.inventory[this.selectedItem].type] >= 0 && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 219)
			{
				if (this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
				{
					this.itemTime = this.inventory[this.selectedItem].useTime;
					int extractType = ItemID.Sets.ExtractinatorMode[this.inventory[this.selectedItem].type];
					Player.ExtractinatorUse(extractType);
				}
			}
			else if (!this.noBuilding && this.inventory[this.selectedItem].createTile >= 0 && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
			{
				this.showItemIcon = true;
				bool flag = false;
				if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0 && Main.tile[Player.tileTargetX, Player.tileTargetY].lava())
				{
					if (Main.tileSolid[this.inventory[this.selectedItem].createTile])
					{
						flag = true;
					}
					else if (!TileObjectData.CheckLiquidPlacement(this.inventory[this.selectedItem].createTile, this.inventory[this.selectedItem].placeStyle, Main.tile[Player.tileTargetX, Player.tileTargetY]))
					{
						flag = true;
					}
				}
				bool flag2 = true;
				if (this.inventory[this.selectedItem].tileWand > 0)
				{
					int tileWand = this.inventory[this.selectedItem].tileWand;
					flag2 = false;
					for (int k = 0; k < 58; k++)
					{
						if (tileWand == this.inventory[k].type && this.inventory[k].stack > 0)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (Main.tileRope[this.inventory[this.selectedItem].createTile] && flag2 && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tileRope[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
				{
					int num24 = Player.tileTargetY;
					int num25 = Player.tileTargetX;
					int arg_135F_0 = this.inventory[this.selectedItem].createTile;
					while (Main.tile[num25, num24].active() && Main.tileRope[(int)Main.tile[num25, num24].type] && num24 < Main.maxTilesX - 5 && Main.tile[num25, num24 + 2] != null && !Main.tile[num25, num24 + 1].lava())
					{
						num24++;
						if (Main.tile[num25, num24] == null)
						{
							flag2 = false;
							num24 = Player.tileTargetY;
						}
					}
					if (!Main.tile[num25, num24].active())
					{
						Player.tileTargetY = num24;
					}
				}
				if (flag2 && ((!Main.tile[Player.tileTargetX, Player.tileTargetY].active() && !flag) || (Main.tileCut[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || (Main.tile[Player.tileTargetX, Player.tileTargetY].type >= 373 && Main.tile[Player.tileTargetX, Player.tileTargetY].type <= 375)) || this.inventory[this.selectedItem].createTile == 199 || this.inventory[this.selectedItem].createTile == 23 || this.inventory[this.selectedItem].createTile == 2 || this.inventory[this.selectedItem].createTile == 109 || this.inventory[this.selectedItem].createTile == 60 || this.inventory[this.selectedItem].createTile == 70 || TileID.Sets.BreakableWhenPlacing[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]) && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
				{
					bool flag3 = false;
					bool flag4 = false;
					TileObject tileObject = default(TileObject);
					if (TileObjectData.CustomPlace(this.inventory[this.selectedItem].createTile, this.inventory[this.selectedItem].placeStyle) && this.inventory[this.selectedItem].createTile != 82)
					{
						flag4 = true;
						flag3 = TileObject.CanPlace(Player.tileTargetX, Player.tileTargetY, (int)((ushort)this.inventory[this.selectedItem].createTile), this.inventory[this.selectedItem].placeStyle, this.direction, out tileObject, false);
						int num26 = 0;
						int num27 = 0;
						int x = 0;
						int y = 0;
						int type = tileObject.type;
						if (type != 138)
						{
							if (type == 235)
							{
								num26 = 48;
								num27 = 16;
								x = tileObject.xCoord * 16;
								y = tileObject.yCoord * 16;
							}
						}
						else
						{
							num26 = 32;
							num27 = 32;
							x = tileObject.xCoord * 16;
							y = tileObject.yCoord * 16;
						}
						if (num26 != 0 && num27 != 0)
						{
							Rectangle value = new Rectangle(x, y, num26, num27);
							for (int l = 0; l < 255; l++)
							{
								Player player = Main.player[l];
								if (player.active && !player.dead && player.Hitbox.Intersects(value))
								{
									flag3 = false;
									break;
								}
							}
						}
						if (tileObject.type == 454)
						{
							for (int m = -2; m < 2; m++)
							{
								Tile tile = Main.tile[Player.tileTargetX + m, Player.tileTargetY];
								if (tile.active() && tile.type == 454)
								{
									flag3 = false;
								}
							}
						}
						if (tileObject.type == 254)
						{
							for (int n = -1; n < 1; n++)
							{
								for (int num28 = -1; num28 < 1; num28++)
								{
									if (!WorldGen.CanCutTile(Player.tileTargetX + num28, Player.tileTargetY + n, TileCuttingContext.AttackMelee))
									{
										flag3 = false;
									}
								}
							}
						}
					}
					else
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
							int num28 = Player.tileTargetX;
							int num29 = Player.tileTargetY - 1;
							if (Main.tile[num28, num29].nactive() && Main.tileSolid[(int)Main.tile[num28, num29].type] && !Main.tileSolidTop[(int)Main.tile[num28, num29].type])
							{
								flag3 = true;
							}
						}
						else if (this.inventory[this.selectedItem].createTile == 461)
						{
							int num30 = Player.tileTargetX;
							int num31 = Player.tileTargetY - 1;
							if (Main.tile[num30, num31].nactive() && Main.tileSolid[(int)Main.tile[num30, num31].type] && !Main.tileSolidTop[(int)Main.tile[num30, num31].type])
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
										if (!TileID.Sets.Platforms[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type])
										{
											WorldGen.SlopeTile(Player.tileTargetX, Player.tileTargetY + 1, 0);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 14, (float)Player.tileTargetX, (float)(Player.tileTargetY + 1), 0f, 0, 0, 0);
											}
										}
									}
									else if (!WorldGen.SolidTileNoAttach(Player.tileTargetX, Player.tileTargetY + 1) && !WorldGen.SolidTileNoAttach(Player.tileTargetX - 1, Player.tileTargetY) && (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].halfBrick() || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].slope() != 0))
									{
										if (!TileID.Sets.Platforms[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type])
										{
											WorldGen.SlopeTile(Player.tileTargetX - 1, Player.tileTargetY, 0);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 14, (float)(Player.tileTargetX - 1), (float)Player.tileTargetY, 0f, 0, 0, 0);
											}
										}
									}
									else if (!WorldGen.SolidTileNoAttach(Player.tileTargetX, Player.tileTargetY + 1) && !WorldGen.SolidTileNoAttach(Player.tileTargetX - 1, Player.tileTargetY) && !WorldGen.SolidTileNoAttach(Player.tileTargetX + 1, Player.tileTargetY) && (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].halfBrick() || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].slope() != 0) && TileID.Sets.Platforms[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type])
									{
										WorldGen.SlopeTile(Player.tileTargetX + 1, Player.tileTargetY, 0);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 14, (float)(Player.tileTargetX + 1), (float)Player.tileTargetY, 0f, 0, 0, 0);
										}
									}
								}
								int num30 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type;
								if (Main.tile[Player.tileTargetX, Player.tileTargetY].halfBrick())
								{
									num30 = -1;
								}
								int num31 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type;
								int num32 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type;
								int num33 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
								int num34 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].type;
								int num35 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
								int num36 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].type;
								if (!Main.tile[Player.tileTargetX, Player.tileTargetY + 1].nactive())
								{
									num30 = -1;
								}
								if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY].nactive())
								{
									num31 = -1;
								}
								if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY].nactive())
								{
									num32 = -1;
								}
								if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].nactive())
								{
									num33 = -1;
								}
								if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].nactive())
								{
									num34 = -1;
								}
								if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY + 1].nactive())
								{
									num35 = -1;
								}
								if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].nactive())
								{
									num36 = -1;
								}
								if (num30 >= 0 && Main.tileSolid[num30] && (!Main.tileNoAttach[num30] || (num30 >= 0 && TileID.Sets.Platforms[num30])))
								{
									flag3 = true;
								}
								else if ((num31 >= 0 && Main.tileSolid[num31] && !Main.tileNoAttach[num31]) || (num31 == 5 && num33 == 5 && num35 == 5) || num31 == 124)
								{
									flag3 = true;
								}
								else if ((num32 >= 0 && Main.tileSolid[num32] && !Main.tileNoAttach[num32]) || (num32 == 5 && num34 == 5 && num36 == 5) || num32 == 124)
								{
									flag3 = true;
								}
							}
						}
						else if (this.inventory[this.selectedItem].createTile == 78 || this.inventory[this.selectedItem].createTile == 98 || this.inventory[this.selectedItem].createTile == 100 || this.inventory[this.selectedItem].createTile == 173 || this.inventory[this.selectedItem].createTile == 174 || this.inventory[this.selectedItem].createTile == 324)
						{
							if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].nactive() && (Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type] || Main.tileTable[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type]))
							{
								flag3 = true;
							}
						}
						else if (this.inventory[this.selectedItem].createTile == 419)
						{
							if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active() && (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type == 419 || (this.inventory[this.selectedItem].placeStyle != 2 && Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type == 420)))
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
						else if (this.inventory[this.selectedItem].createTile == 51 || this.inventory[this.selectedItem].createTile == 330 || this.inventory[this.selectedItem].createTile == 331 || this.inventory[this.selectedItem].createTile == 332 || this.inventory[this.selectedItem].createTile == 333 || this.inventory[this.selectedItem].createTile == 336 || this.inventory[this.selectedItem].createTile == 340 || this.inventory[this.selectedItem].createTile == 342 || this.inventory[this.selectedItem].createTile == 341 || this.inventory[this.selectedItem].createTile == 343 || this.inventory[this.selectedItem].createTile == 344 || this.inventory[this.selectedItem].createTile == 379 || this.inventory[this.selectedItem].createTile == 351)
						{
							if (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active() || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active() || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active() || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active() || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0)
							{
								flag3 = true;
							}
						}
						else if (this.inventory[this.selectedItem].createTile == 314)
						{
							for (int m = Player.tileTargetX - 1; m <= Player.tileTargetX + 1; m++)
							{
								for (int n = Player.tileTargetY - 1; n <= Player.tileTargetY + 1; n++)
								{
									Tile tile = Main.tile[m, n];
									if (tile.active() || tile.wall > 0)
									{
										flag3 = true;
										break;
									}
								}
							}
						}
						else
						{
							Tile tile2 = Main.tile[Player.tileTargetX - 1, Player.tileTargetY];
							Tile tile3 = Main.tile[Player.tileTargetX + 1, Player.tileTargetY];
							Tile tile4 = Main.tile[Player.tileTargetX, Player.tileTargetY - 1];
							Tile tile5 = Main.tile[Player.tileTargetX, Player.tileTargetY + 1];
							if ((tile3.active() && (Main.tileSolid[(int)tile3.type] || Main.tileRope[(int)tile3.type] || tile3.type == 314)) || (tile3.wall > 0 || (tile2.active() && (Main.tileSolid[(int)tile2.type] || Main.tileRope[(int)tile2.type] || tile2.type == 314))) || (tile2.wall > 0 || (tile5.active() && (Main.tileSolid[(int)tile5.type] || tile5.type == 124 || Main.tileRope[(int)tile5.type] || tile5.type == 314))) || (tile5.wall > 0 || (tile4.active() && (Main.tileSolid[(int)tile4.type] || tile4.type == 124 || Main.tileRope[(int)tile4.type] || tile4.type == 314))) || tile4.wall > 0)
							{
								flag3 = true;
							}
						}
						if (this.inventory[this.selectedItem].type == 213 && Main.tile[Player.tileTargetX, Player.tileTargetY].active())
						{
							int num37 = Player.tileTargetX;
							int num38 = Player.tileTargetY;
							if (Main.tile[num37, num38].type == 3 || Main.tile[num37, num38].type == 73 || Main.tile[num37, num38].type == 84)
							{
								WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
								if (!Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
								}
							}
							else if (Main.tile[num37, num38].type == 83)
							{
								bool flag5 = false;
								int num39 = (int)(Main.tile[num37, num38].frameX / 18);
								if (num39 == 0 && Main.dayTime)
								{
									flag5 = true;
								}
								if (num39 == 1 && !Main.dayTime)
								{
									flag5 = true;
								}
								if (num39 == 3 && !Main.dayTime && (Main.bloodMoon || Main.moonPhase == 0))
								{
									flag5 = true;
								}
								if (num39 == 4 && (Main.raining || Main.cloudAlpha > 0f))
								{
									flag5 = true;
								}
								if (num39 == 5 && !Main.raining && Main.dayTime && Main.time > 40500.0)
								{
									flag5 = true;
								}
								if (flag5)
								{
									WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
									NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
								}
							}
						}
						if (Main.tileAlch[this.inventory[this.selectedItem].createTile])
						{
							flag3 = true;
						}
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].active() && (Main.tileCut[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || TileID.Sets.BreakableWhenPlacing[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || (Main.tile[Player.tileTargetX, Player.tileTargetY].type >= 373 && Main.tile[Player.tileTargetX, Player.tileTargetY].type <= 375) || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 461))
						{
							if ((int)Main.tile[Player.tileTargetX, Player.tileTargetY].type != this.inventory[this.selectedItem].createTile)
							{
								if ((Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type != 78 && Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type != 380) || ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 3 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 73) && Main.tileAlch[this.inventory[this.selectedItem].createTile]))
								{
									WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
									if (!Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 4, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
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
						if (!flag3 && this.inventory[this.selectedItem].createTile >= 0 && TileID.Sets.Platforms[this.inventory[this.selectedItem].createTile])
						{
							for (int num40 = Player.tileTargetX - 1; num40 <= Player.tileTargetX + 1; num40++)
							{
								for (int num41 = Player.tileTargetY - 1; num41 <= Player.tileTargetY + 1; num41++)
								{
									if (Main.tile[num40, num41].active())
									{
										flag3 = true;
										break;
									}
								}
							}
						}
					}
					if (flag3)
					{
						int num42 = this.inventory[this.selectedItem].placeStyle;
						if (!flag4)
						{
							if (this.inventory[this.selectedItem].createTile == 36)
							{
								num42 = Main.rand.Next(7);
							}
							if (this.inventory[this.selectedItem].createTile == 212 && this.direction > 0)
							{
								num42 = 1;
							}
							if (this.inventory[this.selectedItem].createTile == 141)
							{
								num42 = Main.rand.Next(2);
							}
							if (this.inventory[this.selectedItem].createTile == 128 || this.inventory[this.selectedItem].createTile == 269 || this.inventory[this.selectedItem].createTile == 334)
							{
								if (this.direction < 0)
								{
									num42 = -1;
								}
								else
								{
									num42 = 1;
								}
							}
							if (this.inventory[this.selectedItem].createTile == 241 && this.inventory[this.selectedItem].placeStyle == 0)
							{
								num42 = Main.rand.Next(0, 9);
							}
							if (this.inventory[this.selectedItem].createTile == 35 && this.inventory[this.selectedItem].placeStyle == 0)
							{
								num42 = Main.rand.Next(9);
							}
						}
						if (this.inventory[this.selectedItem].createTile == 314 && num42 == 2 && this.direction == 1)
						{
							num42++;
						}
						int[,] array = null;
						if (this.autoPaint || this.autoActuator)
						{
							array = new int[11, 11];
							for (int num43 = 0; num43 < 11; num43++)
							{
								for (int num44 = 0; num44 < 11; num44++)
								{
									int num45 = Player.tileTargetX - 5 + num43;
									int num46 = Player.tileTargetY - 5 + num44;
									if (Main.tile[num45, num46].active())
									{
										array[num43, num44] = (int)Main.tile[num45, num46].type;
									}
									else
									{
										array[num43, num44] = -1;
									}
								}
							}
						}
						bool forced = false;
						bool flag6;
						if (flag4)
						{
							flag6 = TileObject.Place(tileObject);
							WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
						}
						else
						{
							flag6 = WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createTile, false, forced, this.whoAmI, num42);
						}
						if (this.inventory[this.selectedItem].type == 213 && !flag6 && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 1 && Main.tile[Player.tileTargetX, Player.tileTargetY].active())
						{
							int num47 = 0;
							int num48 = 0;
							Point point = base.Center.ToTileCoordinates();
							Dictionary<ushort, int> dictionary = new Dictionary<ushort, int>();
							WorldUtils.Gen(new Point(point.X - 25, point.Y - 25), new Shapes.Rectangle(50, 50), new Actions.TileScanner(new ushort[]
							{
								182,
								180,
								179,
								183,
								181,
								381
							}).Output(dictionary));
							foreach (KeyValuePair<ushort, int> current in dictionary)
							{
								if (current.Value > num48)
								{
									num48 = current.Value;
									num47 = (int)current.Key;
								}
							}
							if (num48 == 0)
							{
								num47 = Utils.SelectRandom<int>(Main.rand, new int[]
								{
									182,
									180,
									179,
									183,
									181
								});
							}
							if (num47 != 0)
							{
								Main.tile[Player.tileTargetX, Player.tileTargetY].type = (ushort)num47;
								WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
								NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 1, TileChangeType.None);
								flag6 = true;
							}
						}
						if (flag6)
						{
							this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.tileSpeed);
							if (flag4)
							{
								TileObjectData.CallPostPlacementPlayerHook(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createTile, num42, this.direction, tileObject);
								if (Main.netMode == 1 && !Main.tileContainer[this.inventory[this.selectedItem].createTile])
								{
									NetMessage.SendObjectPlacment(-1, Player.tileTargetX, Player.tileTargetY, tileObject.type, tileObject.style, tileObject.alternate, tileObject.random, this.direction);
								}
							}
							else
							{
								NetMessage.SendData(17, -1, -1, "", 1, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.inventory[this.selectedItem].createTile, num42, 0, 0);
								if (this.inventory[this.selectedItem].createTile == 15)
								{
									if (this.direction == 1)
									{
										Tile expr_2F6D = Main.tile[Player.tileTargetX, Player.tileTargetY];
										expr_2F6D.frameX += 18;
										Tile expr_2F92 = Main.tile[Player.tileTargetX, Player.tileTargetY - 1];
										expr_2F92.frameX += 18;
									}
									if (Main.netMode == 1)
									{
										NetMessage.SendTileSquare(-1, Player.tileTargetX - 1, Player.tileTargetY - 1, 3, TileChangeType.None);
									}
								}
								else if ((this.inventory[this.selectedItem].createTile == 79 || this.inventory[this.selectedItem].createTile == 90) && Main.netMode == 1)
								{
									NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 5, TileChangeType.None);
								}
							}
							if (this.inventory[this.selectedItem].createTile == 137)
							{
								if (this.direction == 1)
								{
									Tile expr_303B = Main.tile[Player.tileTargetX, Player.tileTargetY];
									expr_303B.frameX += 18;
								}
								if (Main.netMode == 1)
								{
									NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 1, TileChangeType.None);
								}
							}
							if (this.inventory[this.selectedItem].createTile == 419)
							{
								if (Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 18, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
								}
								else
								{
									Wiring.PokeLogicGate(Player.tileTargetX, Player.tileTargetY);
								}
							}
							if (Main.tileSolid[this.inventory[this.selectedItem].createTile] && (this.inventory[this.selectedItem].createTile < 0 || !TileID.Sets.Platforms[this.inventory[this.selectedItem].createTile]))
							{
								int num62 = Player.tileTargetX;
								int num63 = Player.tileTargetY + 1;
								if (Main.tile[num62, num63] != null && !TileID.Sets.Platforms[(int)Main.tile[num62, num63].type] && (Main.tile[num62, num63].topSlope() || Main.tile[num62, num63].halfBrick()))
								{
									WorldGen.SlopeTile(num62, num63, 0);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 14, (float)num62, (float)num63, 0f, 0, 0, 0);
									}
								}
								num62 = Player.tileTargetX;
								num63 = Player.tileTargetY - 1;
								if (Main.tile[num62, num63] != null && !TileID.Sets.Platforms[(int)Main.tile[num62, num63].type] && Main.tile[num62, num63].bottomSlope())
								{
									WorldGen.SlopeTile(num62, num63, 0);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 14, (float)num62, (float)num63, 0f, 0, 0, 0);
									}
								}
							}
							if (Main.tileSolid[this.inventory[this.selectedItem].createTile])
							{
								for (int num64 = Player.tileTargetX - 1; num64 <= Player.tileTargetX + 1; num64++)
								{
									for (int num65 = Player.tileTargetY - 1; num65 <= Player.tileTargetY + 1; num65++)
									{
										if (Main.tile[num64, num65].active() && this.inventory[this.selectedItem].createTile != (int)Main.tile[num64, num65].type && (Main.tile[num64, num65].type == 2 || Main.tile[num64, num65].type == 23 || Main.tile[num64, num65].type == 60 || Main.tile[num64, num65].type == 70 || Main.tile[num64, num65].type == 109 || Main.tile[num64, num65].type == 199))
										{
											bool flag10 = true;
											for (int num66 = num64 - 1; num66 <= num64 + 1; num66++)
											{
												for (int num67 = num65 - 1; num67 <= num65 + 1; num67++)
												{
													if (!WorldGen.SolidTile(num66, num67))
													{
														flag10 = false;
													}
												}
											}
											if (flag10)
											{
												WorldGen.KillTile(num64, num65, true, false, false);
												if (Main.netMode == 1)
												{
													NetMessage.SendData(17, -1, -1, "", 0, (float)num64, (float)num65, 1f, 0, 0, 0);
												}
											}
										}
									}
								}
							}
							if (this.autoPaint || this.autoActuator)
							{
								int num68 = 0;
								int num69 = 0;
								int num70 = 11;
								int num71 = 11;
								if (!Main.tileFrameImportant[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
								{
									num69 = (num68 = 5);
									num71 = (num70 = 6);
								}
								for (int num72 = num68; num72 < num70; num72++)
								{
									for (int num73 = num69; num73 < num71; num73++)
									{
										int num74 = Player.tileTargetX - 5 + num72;
										int num75 = Player.tileTargetY - 5 + num73;
										if ((Main.tile[num74, num75].active() || array[num72, num73] != -1) && (!Main.tile[num74, num75].active() || (array[num72, num73] != (int)Main.tile[num74, num75].type && (int)Main.tile[num74, num75].type == this.inventory[this.selectedItem].createTile)))
										{
											if (this.autoPaint && this.builderAccStatus[3] == 0)
											{
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
												if (num76 > 0 && (int)Main.tile[num74, num75].color() != num76 && WorldGen.paintTile(num74, num75, (byte)num76, true))
												{
													int num79 = num77;
													this.inventory[num79].stack--;
													if (this.inventory[num79].stack <= 0)
													{
														this.inventory[num79].SetDefaults(0, false);
													}
													this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.tileSpeed);
												}
											}
											if (this.autoActuator && this.builderAccStatus[2] == 0)
											{
												bool flag11 = Main.tileSolid[(int)Main.tile[num74, num75].type] && !TileID.Sets.NotReallySolid[(int)Main.tile[num74, num75].type];
												ushort type2 = Main.tile[num74, num75].type;
												if (type2 == 314)
												{
													goto IL_3E4F;
												}
												switch (type2)
												{
													case 386:
													case 387:
													case 388:
													case 389:
														goto IL_3E4F;
												}
												IL_3E52:
												if (!flag11)
												{
													goto IL_3EEE;
												}
												int num80 = this.FindItem(849);
												if (num80 > -1 && WorldGen.PlaceActuator(num74, num75))
												{
													NetMessage.SendData(17, -1, -1, "", 8, (float)num74, (float)num75, 0f, 0, 0, 0);
													this.inventory[num80].stack--;
													if (this.inventory[num80].stack <= 0)
													{
														this.inventory[num80].SetDefaults(0, false);
													}
													this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.tileSpeed);
													goto IL_3EEE;
												}
												goto IL_3EEE;
												IL_3E4F:
												flag11 = false;
												goto IL_3E52;
											}
										}
										IL_3EEE:;
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
					if (Player.SmartCursorSettings.SmartWallReplacement && Main.tile[Player.tileTargetX, Player.tileTargetY].wall != 0 && WorldGen.NearFriendlyWall(Player.tileTargetX, Player.tileTargetY))
					{
						WorldGen.KillWall(Player.tileTargetX, Player.tileTargetY, false);
						if (Main.tile[Player.tileTargetX, Player.tileTargetY].wall == 0 && Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 2, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0, 0, 0);
						}
						if (this.inventory[this.selectedItem].consumable)
						{
							this.inventory[this.selectedItem].stack++;
						}
						this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.wallSpeed);
						return;
					}
					WorldGen.PlaceWall(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createWall, false);
					if ((int)Main.tile[Player.tileTargetX, Player.tileTargetY].wall == this.inventory[this.selectedItem].createWall)
					{
						this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.wallSpeed);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 3, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.inventory[this.selectedItem].createWall, 0, 0, 0);
						}
						if (this.inventory[this.selectedItem].stack > 1)
						{
							int createWall = this.inventory[this.selectedItem].createWall;
							for (int num81 = 0; num81 < 4; num81++)
							{
								int num82 = Player.tileTargetX;
								int num83 = Player.tileTargetY;
								if (num81 == 0)
								{
									num82--;
								}
								if (num81 == 1)
								{
									num82++;
								}
								if (num81 == 2)
								{
									num83--;
								}
								if (num81 == 3)
								{
									num83++;
								}
								if (Main.tile[num82, num83].wall == 0)
								{
									int num84 = 0;
									for (int num85 = 0; num85 < 4; num85++)
									{
										int num86 = num82;
										int num87 = num83;
										if (num85 == 0)
										{
											num86--;
										}
										if (num85 == 1)
										{
											num86++;
										}
										if (num85 == 2)
										{
											num87--;
										}
										if (num85 == 3)
										{
											num87++;
										}
										if ((int)Main.tile[num86, num87].wall == createWall)
										{
											num84++;
										}
									}
									if (num84 == 4)
									{
										WorldGen.PlaceWall(num82, num83, createWall, false);
										if ((int)Main.tile[num82, num83].wall == createWall)
										{
											this.inventory[this.selectedItem].stack--;
											if (this.inventory[this.selectedItem].stack == 0)
											{
												this.inventory[this.selectedItem].SetDefaults(0, false);
											}
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 3, (float)num82, (float)num83, (float)createWall, 0, 0, 0);
											}
											if (this.autoPaint && this.builderAccStatus[3] == 0)
											{
												int num88 = num82;
												int num89 = num83;
												int num90 = -1;
												int num91 = -1;
												for (int num92 = 0; num92 < 58; num92++)
												{
													if (this.inventory[num92].stack > 0 && this.inventory[num92].paint > 0)
													{
														num90 = (int)this.inventory[num92].paint;
														num91 = num92;
														break;
													}
												}
												if (num90 > 0 && (int)Main.tile[num88, num89].wallColor() != num90 && WorldGen.paintWall(num88, num89, (byte)num90, true))
												{
													int num93 = num91;
													this.inventory[num93].stack--;
													if (this.inventory[num93].stack <= 0)
													{
														this.inventory[num93].SetDefaults(0, false);
													}
													this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.wallSpeed);
												}
											}
										}
									}
								}
							}
						}
						if (this.autoPaint && this.builderAccStatus[3] == 0)
						{
							int num94 = Player.tileTargetX;
							int num95 = Player.tileTargetY;
							int num96 = -1;
							int num97 = -1;
							for (int num98 = 0; num98 < 58; num98++)
							{
								if (this.inventory[num98].stack > 0 && this.inventory[num98].paint > 0)
								{
									num96 = (int)this.inventory[num98].paint;
									num97 = num98;
									break;
								}
							}
							if (num96 > 0 && (int)Main.tile[num94, num95].wallColor() != num96 && WorldGen.paintWall(num94, num95, (byte)num96, true))
							{
								int num99 = num97;
								this.inventory[num99].stack--;
								if (this.inventory[num99].stack <= 0)
								{
									this.inventory[num99].SetDefaults(0, false);
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
			if (!Main.tile[x, y].active() || Main.tile[x, y].type != 334)
			{
				return;
			}
			int num = (int)Main.tile[x, y].frameY;
			int i = 1;
			num /= 18;
			while (i > num)
			{
				y++;
				num = (int)Main.tile[x, y].frameY;
				num /= 18;
			}
			while (i < num)
			{
				y--;
				num = (int)Main.tile[x, y].frameY;
				num /= 18;
			}
			int j = (int)Main.tile[x, y].frameX;
			int num2 = 0;
			while (j >= 5000)
			{
				j -= 5000;
				num2++;
			}
			if (num2 != 0)
			{
				j = (num2 - 1) * 18;
			}
			bool flag = false;
			if (j >= 54)
			{
				j -= 54;
				flag = true;
			}
			x -= j / 18;
			int k = (int)Main.tile[x, y].frameX;
			WorldGen.KillTile(x, y, true, false, false);
			if (Main.netMode == 1)
			{
				NetMessage.SendData(17, -1, -1, "", 0, (float)x, (float)y, 1f, 0, 0, 0);
			}
			if (Main.netMode == 1)
			{
				NetMessage.SendData(17, -1, -1, "", 0, (float)(x + 1), (float)y, 1f, 0, 0, 0);
			}
			while (k >= 5000)
			{
				k -= 5000;
			}
			Main.blockMouse = true;
			int num3 = 5000;
			int num4 = 10000;
			if (flag)
			{
				num3 = 20000;
				num4 = 25000;
			}
			Main.tile[x, y].frameX = (short)(this.inventory[this.selectedItem].netID + num3 + 100);
			Main.tile[x + 1, y].frameX = (short)((int)this.inventory[this.selectedItem].prefix + num4);
			if (Main.netMode == 1)
			{
				NetMessage.SendTileSquare(-1, x, y, 1, TileChangeType.None);
			}
			if (Main.netMode == 1)
			{
				NetMessage.SendTileSquare(-1, x + 1, y, 1, TileChangeType.None);
			}
			this.inventory[this.selectedItem].stack--;
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
				this.swimTime--;
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
				if (this.armor[i].shieldSlot == 5 && this.eocDash > 0 && this.shield == -1)
				{
					this.shield = this.armor[i].shieldSlot;
				}
				if (this.shieldRaised && this.shield == -1 && this.armor[i].shieldSlot != -1)
				{
					this.shield = this.armor[i].shieldSlot;
				}
				if ((this.shield <= 0 || this.armor[i].frontSlot < 1 || this.armor[i].frontSlot > 4) && (this.front < 1 || this.front > 4 || this.armor[i].shieldSlot <= 0))
				{
					if (this.armor[i].wingSlot > 0)
					{
						if (this.hideVisual[i] && (this.velocity.Y == 0f || this.mount.Active))
						{
							goto IL_33F;
						}
						this.wings = (int)this.armor[i].wingSlot;
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
				IL_33F:;
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
					this.wings = (int)this.armor[j].wingSlot;
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
			bool flag = false;
			int num = Player.SetMatch(1, this.body, this.Male, ref this.wearsRobe);
			if (num != -1)
			{
				this.legs = num;
			}
			num = Player.SetMatch(2, this.legs, this.Male, ref flag);
			if (num != -1)
			{
				this.legs = num;
			}
			num = Player.SetMatch(0, this.head, this.Male, ref flag);
			if (num != -1)
			{
				this.head = num;
			}
			if (this.body == 93)
			{
				this.shield = 0;
				this.handoff = 0;
			}
			if (this.body == 206 && this.back == -1)
			{
				this.back = 12;
			}
			if (this.body == 207 && this.back == -1)
			{
				this.back = 13;
			}
			if (this.body == 205 && this.back == -1)
			{
				this.back = 11;
			}
			if (this.legs == 67)
			{
				this.shoe = 0;
			}
			if (this.legs == 140)
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
			this.socialIgnoreLight = false;
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
				this.legFrameCounter = 0.0;
				this.legFrame.Y = this.legFrame.Height * 6;
				if (this.velocity.Y != 0f)
				{
					if (this.mount.FlyTime > 0 && this.jump == 0 && this.controlJump && !this.mount.CanHover)
					{
						this.mount.UpdateFrame(this, 3, this.velocity);
					}
					else if (this.wet)
					{
						this.mount.UpdateFrame(this, 4, this.velocity);
					}
					else
					{
						this.mount.UpdateFrame(this, 2, this.velocity);
					}
				}
				else if (this.velocity.X == 0f || ((this.slippy || this.slippy2 || this.windPushed) && !this.controlLeft && !this.controlRight))
				{
					this.mount.UpdateFrame(this, 0, this.velocity);
				}
				else
				{
					this.mount.UpdateFrame(this, 1, this.velocity);
				}
			}
			else if (this.legs == 140)
			{
				this.legFrameCounter = 0.0;
				this.legFrame.Y = this.legFrame.Height * (this.velocity.Y != 0f).ToInt();
				if (this.wings == 22 || this.wings == 28)
				{
					this.legFrame.Y = 0;
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
				if (this.wings == 22 || this.wings == 28)
				{
					this.legFrame.Y = 0;
				}
			}
			else if (this.velocity.X != 0f)
			{
				if ((this.slippy || this.slippy2 || this.windPushed) && !this.controlLeft && !this.controlRight)
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
			if (this.itemAnimation > 0 && this.inventory[this.selectedItem].useStyle != 10)
			{
				if (this.inventory[this.selectedItem].useStyle == 1 || this.inventory[this.selectedItem].type == 0)
				{
					if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
						return;
					}
					if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.666)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 2;
						return;
					}
					this.bodyFrame.Y = this.bodyFrame.Height;
					return;
				}
				else if (this.inventory[this.selectedItem].useStyle == 2)
				{
					if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.5)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
						return;
					}
					this.bodyFrame.Y = this.bodyFrame.Height * 2;
					return;
				}
				else if (this.inventory[this.selectedItem].useStyle == 3)
				{
					if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.666)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
						return;
					}
					this.bodyFrame.Y = this.bodyFrame.Height * 3;
					return;
				}
				else
				{
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
						float num18 = this.itemRotation * (float)this.direction;
						this.bodyFrame.Y = this.bodyFrame.Height * 3;
						if ((double)num18 < -0.75)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 2;
							if (this.gravDir == -1f)
							{
								this.bodyFrame.Y = this.bodyFrame.Height * 4;
							}
						}
						if ((double)num18 > 0.6)
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
			else
			{
				if (this.mount.Active)
				{
					this.bodyFrameCounter = 0.0;
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
				else
				{
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
					if (this.shieldRaised)
					{
						this.bodyFrame.Y = this.bodyFrame.Height * 10;
						return;
					}
					if (this.grappling[0] >= 0)
					{
						this.sandStorm = false;
						this.dJumpEffectCloud = false;
						this.dJumpEffectSandstorm = false;
						this.dJumpEffectBlizzard = false;
						this.dJumpEffectFart = false;
						this.dJumpEffectSail = false;
						this.dJumpEffectUnicorn = false;
						Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
						float num19 = 0f;
						float num20 = 0f;
						for (int num21 = 0; num21 < this.grapCount; num21++)
						{
							num19 += Main.projectile[this.grappling[num21]].position.X + (float)(Main.projectile[this.grappling[num21]].width / 2);
							num20 += Main.projectile[this.grappling[num21]].position.Y + (float)(Main.projectile[this.grappling[num21]].height / 2);
						}
						num19 /= (float)this.grapCount;
						num20 /= (float)this.grapCount;
						num19 -= vector.X;
						num20 -= vector.Y;
						if (num20 < 0f && Math.Abs(num20) > Math.Abs(num19))
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 2;
							if (this.gravDir == -1f)
							{
								this.bodyFrame.Y = this.bodyFrame.Height * 4;
								return;
							}
						}
						else
						{
							if (num20 <= 0f || Math.Abs(num20) <= Math.Abs(num19))
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
					}
					else if (this.swimTime > 0)
					{
						if (this.swimTime > 20)
						{
							this.bodyFrame.Y = 0;
							return;
						}
						if (this.swimTime > 10)
						{
							this.bodyFrame.Y = this.bodyFrame.Height * 5;
							return;
						}
						this.bodyFrame.Y = 0;
						return;
					}
					else
					{
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
							else if (this.wings > 0)
							{
								if (this.wings == 22 || this.wings == 28)
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
							return;
						}
						if (this.velocity.X != 0f)
						{
							if (this.legs != 140)
							{
								this.bodyFrameCounter += (double)Math.Abs(this.velocity.X) * 1.5;
								this.bodyFrame.Y = this.legFrame.Y;
								return;
							}
							this.bodyFrameCounter += (double)(Math.Abs(this.velocity.X) * 0.5f);
							while (this.bodyFrameCounter > 8.0)
							{
								this.bodyFrameCounter -= 8.0;
								this.bodyFrame.Y = this.bodyFrame.Y + this.bodyFrame.Height;
							}
							if (this.bodyFrame.Y < this.bodyFrame.Height * 7)
							{
								this.bodyFrame.Y = this.bodyFrame.Height * 19;
								return;
							}
							if (this.bodyFrame.Y > this.bodyFrame.Height * 19)
							{
								this.bodyFrame.Y = this.bodyFrame.Height * 7;
								return;
							}
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
			Projectile.NewProjectile((float)num, (float)num2, num4, num5, 321, dmg, kb, this.whoAmI, (float)i, 0f);
		}

		public void PutItemInInventory(int type, int selItem = -1)
		{
			for (int i = 0; i < 58; i++)
			{
				Item item = this.inventory[i];
				if (item.stack > 0 && item.type == type && item.stack < item.maxStack)
				{
					item.stack++;
					return;
				}
			}
			if (selItem >= 0 && (this.inventory[selItem].type == 0 || this.inventory[selItem].stack <= 0))
			{
				this.inventory[selItem].SetDefaults(type, false);
				return;
			}
			Item item2 = new Item();
			item2.SetDefaults(type, false);
			Item item3 = this.GetItem(this.whoAmI, item2, false, false);
			if (item3.stack > 0)
			{
				int number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, type, 1, false, 0, true, false);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else
			{
				item2.position.X = base.Center.X - (float)(item2.width / 2);
				item2.position.Y = base.Center.Y - (float)(item2.height / 2);
				item2.active = true;
				ItemText.NewText(item2, 0, false, false);
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
					int num2 = this.inventory[i].buffType;
					bool flag = true;
					for (int j = 0; j < 22; j++)
					{
						if (num2 == 27 && (this.buffType[j] == num2 || this.buffType[j] == 101 || this.buffType[j] == 102))
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
					if (this.whoAmI == Main.myPlayer && this.inventory[i].type == 603 && !Main.cEd)
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
				for (int i = 0; i < 58; i++)
				{
					if (Main.projHook[this.inventory[i].shoot])
					{
						item = this.inventory[i];
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
				int num = 0;
				for (int j = 0; j < 1000; j++)
				{
					if (Main.projectile[j].active && Main.projectile[j].owner == Main.myPlayer && (Main.projectile[j].type == 73 || Main.projectile[j].type == 74))
					{
						num++;
					}
				}
				if (num > 1)
				{
					item = null;
				}
			}
			else if (item.shoot == 165)
			{
				int num2 = 0;
				for (int k = 0; k < 1000; k++)
				{
					if (Main.projectile[k].active && Main.projectile[k].owner == Main.myPlayer && Main.projectile[k].type == 165)
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
				for (int l = 0; l < 1000; l++)
				{
					if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == 372)
					{
						num3++;
					}
				}
				if (num3 > 2)
				{
					item = null;
				}
			}
			else if (item.shoot == 652)
			{
				int num4 = 0;
				for (int m = 0; m < 1000; m++)
				{
					if (Main.projectile[m].active && Main.projectile[m].owner == Main.myPlayer && Main.projectile[m].type == 652)
					{
						num4++;
					}
				}
				if (num4 > 1)
				{
					item = null;
				}
			}
			else if (item.type == 3572)
			{
				int num5 = 0;
				bool flag3 = false;
				for (int n = 0; n < 1000; n++)
				{
					if (Main.projectile[n].active && Main.projectile[n].owner == Main.myPlayer && Main.projectile[n].type >= 646 && Main.projectile[n].type <= 649)
					{
						num5++;
						if (Main.projectile[n].ai[0] == 2f)
						{
							flag3 = true;
						}
					}
				}
				if (num5 > 4 || (!flag3 && num5 > 3))
				{
					item = null;
				}
			}
			else
			{
				for (int num6 = 0; num6 < 1000; num6++)
				{
					if (Main.projectile[num6].active && Main.projectile[num6].owner == Main.myPlayer && Main.projectile[num6].type == item.shoot && Main.projectile[num6].ai[0] != 2f)
					{
						item = null;
						break;
					}
				}
			}
			if (item != null)
			{
				if (Main.netMode == 1 && this.whoAmI == Main.myPlayer)
				{
					NetMessage.SendData(51, -1, -1, "", this.whoAmI, 2f, 0f, 0f, 0, 0, 0);
				}
				int num7 = item.shoot;
				float shootSpeed = item.shootSpeed;
				int damage = item.damage;
				float knockBack = item.knockBack;
				if (num7 == 13 || num7 == 32 || num7 == 315 || (num7 >= 230 && num7 <= 235) || num7 == 331)
				{
					this.grappling[0] = -1;
					this.grapCount = 0;
					for (int num8 = 0; num8 < 1000; num8++)
					{
						if (Main.projectile[num8].active && Main.projectile[num8].owner == this.whoAmI)
						{
							if (Main.projectile[num8].type == 13)
							{
								Main.projectile[num8].Kill();
							}
							if (Main.projectile[num8].type == 331)
							{
								Main.projectile[num8].Kill();
							}
							if (Main.projectile[num8].type == 315)
							{
								Main.projectile[num8].Kill();
							}
							if (Main.projectile[num8].type >= 230 && Main.projectile[num8].type <= 235)
							{
								Main.projectile[num8].Kill();
							}
						}
					}
				}
				if (num7 == 256)
				{
					int num9 = 0;
					int num10 = -1;
					int num11 = 100000;
					for (int num12 = 0; num12 < 1000; num12++)
					{
						if (Main.projectile[num12].active && Main.projectile[num12].owner == this.whoAmI && Main.projectile[num12].type == 256)
						{
							num9++;
							if (Main.projectile[num12].timeLeft < num11)
							{
								num10 = num12;
								num11 = Main.projectile[num12].timeLeft;
							}
						}
					}
					if (num9 > 1)
					{
						Main.projectile[num10].Kill();
					}
				}
				if (num7 == 652)
				{
					int num13 = 0;
					int num14 = -1;
					int num15 = 100000;
					for (int num16 = 0; num16 < 1000; num16++)
					{
						if (Main.projectile[num16].active && Main.projectile[num16].owner == this.whoAmI && Main.projectile[num16].type == 652)
						{
							num13++;
							if (Main.projectile[num16].timeLeft < num15)
							{
								num14 = num16;
								num15 = Main.projectile[num16].timeLeft;
							}
						}
					}
					if (num13 > 1)
					{
						Main.projectile[num14].Kill();
					}
				}
				if (num7 == 73)
				{
					for (int num17 = 0; num17 < 1000; num17++)
					{
						if (Main.projectile[num17].active && Main.projectile[num17].owner == this.whoAmI && Main.projectile[num17].type == 73)
						{
							num7 = 74;
						}
					}
				}
				if (item.type == 3572)
				{
					int num18 = -1;
					int num19 = -1;
					for (int num20 = 0; num20 < 1000; num20++)
					{
						Projectile projectile = Main.projectile[num20];
						if (projectile.active && projectile.owner == this.whoAmI && projectile.type >= 646 && projectile.type <= 649 && (num19 == -1 || num19 < projectile.timeLeft))
						{
							num18 = projectile.type;
							num19 = projectile.timeLeft;
						}
					}
					int num21 = num18;
					if (num21 != -1)
					{
						switch (num21)
						{
							case 646:
								num7 = 647;
								goto IL_820;
							case 647:
								num7 = 648;
								goto IL_820;
							case 648:
								num7 = 649;
								goto IL_820;
							case 649:
								break;
							default:
								goto IL_820;
						}
					}
					num7 = 646;
				}
				IL_820:
				Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
				float num22 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
				float num23 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
				if (this.gravDir == -1f)
				{
					num23 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector.Y;
				}
				float num24 = (float)Math.Sqrt((double)(num22 * num22 + num23 * num23));
				if ((float.IsNaN(num22) && float.IsNaN(num23)) || (num22 == 0f && num23 == 0f))
				{
					num22 = (float)this.direction;
					num23 = 0f;
					num24 = shootSpeed;
				}
				else
				{
					num24 = shootSpeed / num24;
				}
				num22 *= num24;
				num23 *= num24;
				Projectile.NewProjectile(vector.X, vector.Y, num22, num23, num7, damage, knockBack, this.whoAmI, 0f, 0f);
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
			Item item = this.QuickHeal_GetItemToUse();
			if (item == null)
			{
				return;
			}
			if (item.potion)
			{
				if (item.type == 227)
				{
					this.potionDelay = this.restorationDelayTime;
					this.AddBuff(21, this.potionDelay, true);
				}
				else
				{
					this.potionDelay = this.potionDelayTime;
					this.AddBuff(21, this.potionDelay, true);
				}
			}
			this.statLife += item.healLife;
			this.statMana += item.healMana;
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
			item.stack--;
			if (item.stack <= 0)
			{
				item.type = 0;
				item.name = "";
			}
			Recipe.FindRecipes();
		}

		public Item QuickHeal_GetItemToUse()
		{
			int num = this.statLifeMax2 - this.statLife;
			Item result = null;
			int num2 = -this.statLifeMax2;
			for (int i = 0; i < 58; i++)
			{
				Item item = this.inventory[i];
				if (item.stack > 0 && item.type > 0 && item.potion && item.healLife > 0)
				{
					int num3 = item.healLife - num;
					if (num2 < 0)
					{
						if (num3 > num2)
						{
							result = item;
							num2 = num3;
						}
					}
					else if (num3 < num2 && num3 >= 0)
					{
						result = item;
						num2 = num3;
					}
				}
			}
			return result;
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
						if (this.inventory[i].type == 227)
						{
							this.potionDelay = this.restorationDelayTime;
							this.AddBuff(21, this.potionDelay, true);
						}
						else
						{
							this.potionDelay = this.potionDelayTime;
							this.AddBuff(21, this.potionDelay, true);
						}
					}
					this.statLife += this.inventory[i].healLife;
					this.statMana += this.inventory[i].healMana;
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
						this.AddBuff(94, Player.manaSickTime, true);
						if (Main.myPlayer == this.whoAmI)
						{
							this.ManaEffect(this.inventory[i].healMana);
						}
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

		public Item QuickMana_GetItemToUse()
		{
			for (int i = 0; i < 58; i++)
			{
				if (this.inventory[i].stack > 0 && this.inventory[i].type > 0 && this.inventory[i].healMana > 0 && (this.potionDelay == 0 || !this.inventory[i].potion))
				{
					return this.inventory[i];
				}
			}
			return null;
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
			Item item = this.QuickMount_GetItemToUse();
			if (item != null && item.mountType != -1 && this.mount.CanMount(item.mountType, this))
			{
				bool flag = false;
				List<Point> tilesIn = Collision.GetTilesIn(base.TopLeft - new Vector2(24f), base.BottomRight + new Vector2(24f));
				if (tilesIn.Count > 0)
				{
					Point? point = null;
					Rectangle arg_CD_0 = base.Hitbox;
					for (int i = 0; i < tilesIn.Count; i++)
					{
						Point point2 = tilesIn[i];
						Tile tileSafely = Framing.GetTileSafely(point2.X, point2.Y);
						if (tileSafely.active() && tileSafely.type == 314)
						{
							Vector2 vector = tilesIn[i].ToVector2() * 16f + new Vector2(8f);
							if (!point.HasValue || (base.Distance(vector) < base.Distance(point.Value.ToVector2() * 16f + new Vector2(8f)) && Collision.CanHitLine(base.Center, 0, 0, vector, 0, 0)))
							{
								point = new Point?(tilesIn[i]);
							}
						}
					}
					if (point.HasValue)
					{
						this.LaunchMinecartHook(point.Value.X, point.Value.Y);
						flag = true;
					}
				}
				if (!flag)
				{
					this.mount.SetMount(item.mountType, this, false);
				}
			}
			else
			{
				int num = 0;
				int num2 = (int)(this.position.X / 16f) - Player.tileRangeX - num + 1;
				int num3 = (int)((this.position.X + (float)this.width) / 16f) + Player.tileRangeX + num - 1;
				int num4 = (int)(this.position.Y / 16f) - Player.tileRangeY - num + 1;
				int num5 = (int)((this.position.Y + (float)this.height) / 16f) + Player.tileRangeY + num - 2;
				num2 = Utils.Clamp<int>(num2, 10, Main.maxTilesX - 10);
				num3 = Utils.Clamp<int>(num3, 10, Main.maxTilesX - 10);
				num4 = Utils.Clamp<int>(num4, 10, Main.maxTilesY - 10);
				num5 = Utils.Clamp<int>(num5, 10, Main.maxTilesY - 10);
				List<Point> tilesIn2 = Collision.GetTilesIn(new Vector2((float)num2, (float)num4) * 16f, new Vector2((float)(num3 + 1), (float)(num5 + 1)) * 16f);
				if (tilesIn2.Count > 0)
				{
					Point? point3 = null;
					Rectangle arg_34B_0 = base.Hitbox;
					for (int j = 0; j < tilesIn2.Count; j++)
					{
						Point point4 = tilesIn2[j];
						Tile tileSafely2 = Framing.GetTileSafely(point4.X, point4.Y);
						if (tileSafely2.active() && tileSafely2.type == 314)
						{
							Vector2 vector2 = tilesIn2[j].ToVector2() * 16f + new Vector2(8f);
							if (!point3.HasValue || (base.Distance(vector2) < base.Distance(point3.Value.ToVector2() * 16f + new Vector2(8f)) && Collision.CanHitLine(base.Center, 0, 0, vector2, 0, 0)))
							{
								point3 = new Point?(tilesIn2[j]);
							}
						}
					}
					if (point3.HasValue)
					{
						this.LaunchMinecartHook(point3.Value.X, point3.Value.Y);
					}
				}
			}
		}

		public Item QuickMount_GetItemToUse()
		{
			Item item = null;
			if (item == null && this.miscEquips[3].mountType != -1 && !MountID.Sets.Cart[this.miscEquips[3].mountType])
			{
				item = this.miscEquips[3];
			}
			if (item == null)
			{
				for (int i = 0; i < 58; i++)
				{
					if (this.inventory[i].mountType != -1 && !MountID.Sets.Cart[this.inventory[i].mountType])
					{
						item = this.inventory[i];
						break;
					}
				}
			}
			return item;
		}

		public void QuickSpawnItem(int item, int stack = 1)
		{
			int number = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, item, stack, false, -1, false, false);
			if (Main.netMode == 1)
			{
				NetMessage.SendData(21, -1, -1, "", number, 1f, 0f, 0f, 0, 0, 0);
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
					if (this.inventory[i].type > 0 && this.inventory[i].stack > 0 && !this.inventory[i].favorited && (this.inventory[i].type < 71 || this.inventory[i].type > 74))
					{
						NetMessage.SendData(5, -1, -1, "", this.whoAmI, (float)i, (float)this.inventory[i].prefix, 0f, 0, 0, 0);
						NetMessage.SendData(85, -1, -1, "", i, 0f, 0f, 0f, 0, 0, 0);
						this.inventoryChestStack[i] = true;
					}
				}
				return;
			}
			bool flag = false;
			for (int j = 10; j < 50; j++)
			{
				if (this.inventory[j].type > 0 && this.inventory[j].stack > 0 && !this.inventory[j].favorited)
				{
					int type = this.inventory[j].type;
					int stack = this.inventory[j].stack;
					this.inventory[j] = Chest.PutItemInNearbyChest(this.inventory[j], base.Center, this);
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
			if (this.extraAccessory && (Main.expertMode || Main.gameMenu))
			{
				this.extraAccessorySlots = 1;
			}
			else
			{
				this.extraAccessorySlots = 0;
			}
			this.arcticDivingGear = false;
			this.noBuilding = false;
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
			this.maxTurrets = 1;
			this.ammoBox = false;
			this.ammoPotion = false;
			this.penguin = false;
			this.sporeSac = false;
			this.shinyStone = false;
			this.dd2Accessory = false;
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
			this.InfoAccMechShowWires = false;
			this.accJarOfSouls = false;
			this.accCalendar = false;
			this.accStopwatch = false;
			this.accOreFinder = false;
			this.accCritterGuide = false;
			this.accDreamCatcher = false;
			this.wallSpeed = 1f;
			this.tileSpeed = 1f;
			this.autoPaint = false;
			this.autoActuator = false;
			this.petFlagDD2Gato = false;
			this.petFlagDD2Dragon = false;
			this.petFlagDD2Ghost = false;
			this.companionCube = false;
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
			this.hasRaisableShield = false;
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
			this.witheredArmor = false;
			this.witheredWeapon = false;
			this.parryDamageBuff = false;
			this.slowOgreSpit = false;
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
			this.windPushed = false;
			this.ballistaPanic = false;
			this.setVortex = (this.setNebula = (this.setStardust = false));
			this.setForbidden = false;
			this.setHuntressT3 = false;
			this.setSquireT3 = false;
			this.setMonkT3 = false;
			this.setApprenticeT3 = false;
			this.setHuntressT2 = false;
			this.setSquireT2 = false;
			this.setMonkT2 = false;
			this.setApprenticeT2 = false;
			this.setForbiddenCooldownLocked = false;
			this.nebulaLevelDamage = (this.nebulaLevelLife = (this.nebulaLevelMana = 0));
			this.ignoreWater = false;
			this.meleeEnchant = 0;
			this.discount = false;
			this.coins = false;
			this.doubleJumpSail = false;
			this.doubleJumpSandstorm = false;
			this.doubleJumpBlizzard = false;
			this.doubleJumpFart = false;
			this.doubleJumpUnicorn = false;
			this.defendedByPaladin = false;
			this.hasPaladinShield = false;
			this.autoJump = false;
			this.justJumped = false;
			this.jumpSpeedBoost = 0f;
			this.extraFall = 0;
			if (this.phantasmTime > 0)
			{
				this.phantasmTime--;
			}
			if (this.wireOperationsCooldown > 0)
			{
				this.wireOperationsCooldown--;
			}
			if (this.releaseUseItem)
			{
				this.ActuationRodLock = false;
			}
			for (int i = 0; i < this.npcTypeNoAggro.Length; i++)
			{
				this.npcTypeNoAggro[i] = false;
			}
			for (int j = 0; j < this.ownedProjectileCounts.Length; j++)
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
			Vector2 value = this.position + this.fullRotationOrigin;
			Matrix matrix = Matrix.CreateRotationZ(this.fullRotation * (float)rotateForward.ToInt());
			pos -= this.position + this.fullRotationOrigin;
			pos = Vector2.Transform(pos, matrix);
			return pos + value;
		}

		public void RotateRelativePoint(ref float x, ref float y)
		{
			Vector2 vector = this.RotatedRelativePoint(new Vector2(x, y), true);
			x = vector.X;
			y = vector.Y;
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

		public void ScrollHotbar(int Offset)
		{
			while (Offset > 9)
			{
				Offset -= 10;
			}
			while (Offset < 0)
			{
				Offset += 10;
			}
			this.selectedItem += Offset;
			if (Offset != 0)
			{
				int num = this.selectedItem - Offset;
				this.DpadRadial.ChangeSelection(-1);
				this.CircularRadial.ChangeSelection(-1);
				this.selectedItem = num + Offset;
				this.nonTorch = -1;
			}
			if (this.changeItem >= 0)
			{
				this.selectedItem = this.changeItem;
				this.changeItem = -1;
			}
			if (this.itemAnimation == 0 && this.selectedItem != 58)
			{
				while (this.selectedItem > 9)
				{
					this.selectedItem -= 10;
				}
				while (this.selectedItem < 0)
				{
					this.selectedItem += 10;
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
			if (j < 1)
			{
				j = 1;
			}
			j *= stack;
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

		public static int SetMatch(int armorslot, int type, bool male, ref bool somethingSpecial)
		{
			int num = -1;
			if (armorslot == 0 && type == 201)
			{
				num = (male ? 201 : 202);
			}
			if (armorslot == 1)
			{
				if (type <= 63)
				{
					if (type <= 36)
					{
						if (type != 15)
						{
							if (type == 36)
							{
								num = 89;
							}
						}
						else
						{
							num = 88;
						}
					}
					else
					{
						switch (type)
						{
							case 41:
								num = 97;
								break;
							case 42:
								num = 90;
								break;
							default:
								switch (type)
								{
									case 58:
										num = 91;
										break;
									case 59:
										num = 92;
										break;
									case 60:
										num = 93;
										break;
									case 61:
										num = 94;
										break;
									case 62:
										num = 95;
										break;
									case 63:
										num = 96;
										break;
								}
								break;
						}
					}
				}
				else if (type <= 167)
				{
					if (type != 77)
					{
						switch (type)
						{
							case 165:
								if (male)
								{
									num = 118;
								}
								else
								{
									num = 99;
								}
								break;
							case 166:
								if (male)
								{
									num = 119;
								}
								else
								{
									num = 100;
								}
								break;
							case 167:
								if (!male)
								{
									num = 102;
								}
								else
								{
									num = 101;
								}
								break;
						}
					}
					else
					{
						num = 121;
					}
				}
				else
				{
					switch (type)
					{
						case 180:
							num = 115;
							break;
						case 181:
							num = 116;
							break;
						case 182:
							break;
						case 183:
							num = (male ? 136 : 123);
							break;
						default:
							if (type == 191)
							{
								num = 131;
							}
							break;
					}
				}
				if (num != -1)
				{
					somethingSpecial = true;
				}
			}
			if (armorslot == 2)
			{
				if (type <= 84)
				{
					if (type != 57)
					{
						switch (type)
						{
							case 83:
								if (male)
								{
									num = 117;
								}
								break;
							case 84:
								if (male)
								{
									num = 120;
								}
								break;
						}
					}
					else if (male)
					{
						num = 137;
					}
				}
				else if (type != 132)
				{
					if (type != 146)
					{
						if (type == 154)
						{
							num = (male ? 155 : 154);
						}
					}
					else
					{
						num = (male ? 146 : 147);
					}
				}
				else if (male)
				{
					num = 135;
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
				this.immuneTime += 40;
			}
			for (int i = 0; i < this.hurtCooldowns.Length; i++)
			{
				this.hurtCooldowns[i] = this.immuneTime;
			}
			if (this.whoAmI == Main.myPlayer)
			{
				for (int j = 0; j < 22; j++)
				{
					if (this.buffTime[j] > 0 && this.buffType[j] == 59)
					{
						this.DelBuff(j);
					}
				}
				NetMessage.SendData(62, -1, -1, "", this.whoAmI, 2f, 0f, 0f, 0, 0, 0);
			}
		}

		private void ShootFromCannon(int x, int y)
		{
			int num = 0;
			if (Main.tile[x, y].frameX < 72)
			{
				if (this.inventory[this.selectedItem].type == 929)
				{
					num = 1;
				}
			}
			else if (Main.tile[x, y].frameX < 144)
			{
				if (this.inventory[this.selectedItem].type == 1338)
				{
					num = 2;
				}
			}
			else if (Main.tile[x, y].frameX < 288 && this.inventory[this.selectedItem].type == 1345)
			{
				num = 3;
			}
			if (num > 0)
			{
				this.showItemIcon = true;
				if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
				{
					int i = (int)(Main.tile[x, y].frameX / 18);
					int num2 = 0;
					int num3 = 0;
					while (i >= 4)
					{
						num2++;
						i -= 4;
					}
					i = x - i;
					int j;
					for (j = (int)(Main.tile[x, y].frameY / 18); j >= 3; j -= 3)
					{
						num3++;
					}
					j = y - j;
					this.itemTime = this.inventory[this.selectedItem].useTime;
					WorldGen.ShootFromCannon(i, j, num3, num, this.inventory[this.selectedItem].damage, 8f, Main.myPlayer);
				}
			}
		}

		public void SlopeDownMovement()
		{
			this.sloping = false;
			float y = this.velocity.Y;
			Vector4 vector = Collision.WalkDownSlope(this.position, this.velocity, this.width, this.height, this.gravity * this.gravDir);
			this.position.X = vector.X;
			this.position.Y = vector.Y;
			this.velocity.X = vector.Z;
			this.velocity.Y = vector.W;
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
			Vector4 vector = Collision.SlopeCollision(this.position, this.velocity, this.width, this.height, this.gravity, this.stairFall);
			if (Collision.stairFall)
			{
				this.stairFall = true;
			}
			else if (!fallThrough)
			{
				this.stairFall = false;
			}
			if (Collision.stair && Math.Abs(vector.Y - this.position.Y) > 8f + Math.Abs(this.velocity.X))
			{
				this.gfxOffY -= vector.Y - this.position.Y;
				this.stepSpeed = 4f;
			}
			float arg_D8_0 = this.velocity.Y;
			this.position.X = vector.X;
			this.position.Y = vector.Y;
			this.velocity.X = vector.Z;
			this.velocity.Y = vector.W;
			if (this.gravDir == -1f && this.velocity.Y == 0.0101f)
			{
				this.velocity.Y = 0f;
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
				NetMessage.SendData(12, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
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
						if (Main.tile[i, j] != null)
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
			this.oldPosition = this.position + this.BlehOldPositionFixer;
			this.talkNPC = -1;
			if (this.whoAmI == Main.myPlayer)
			{
				Main.npcChatCornerItem = 0;
			}
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
			int damage = 70;
			float knockBack = 1.5f;
			if (Main.rand.Next(15) == 0)
			{
				int num = 0;
				for (int i = 0; i < 1000; i++)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == this.whoAmI && (Main.projectile[i].type == 567 || Main.projectile[i].type == 568))
					{
						num++;
					}
				}
				if (Main.rand.Next(15) >= num && num < 10)
				{
					int num2 = 50;
					int num3 = 24;
					int num4 = 90;
					for (int j = 0; j < num2; j++)
					{
						int num5 = Main.rand.Next(200 - j * 2, 400 + j * 2);
						Vector2 center = base.Center;
						center.X += (float)Main.rand.Next(-num5, num5 + 1);
						center.Y += (float)Main.rand.Next(-num5, num5 + 1);
						if (!Collision.SolidCollision(center, num3, num3) && !Collision.WetCollision(center, num3, num3))
						{
							center.X += (float)(num3 / 2);
							center.Y += (float)(num3 / 2);
							if (Collision.CanHit(new Vector2(base.Center.X, this.position.Y), 1, 1, center, 1, 1) || Collision.CanHit(new Vector2(base.Center.X, this.position.Y - 50f), 1, 1, center, 1, 1))
							{
								int num6 = (int)center.X / 16;
								int num7 = (int)center.Y / 16;
								bool flag = false;
								if (Main.rand.Next(3) == 0 && Main.tile[num6, num7] != null && Main.tile[num6, num7].wall > 0)
								{
									flag = true;
								}
								else
								{
									center.X -= (float)(num4 / 2);
									center.Y -= (float)(num4 / 2);
									if (Collision.SolidCollision(center, num4, num4))
									{
										center.X += (float)(num4 / 2);
										center.Y += (float)(num4 / 2);
										flag = true;
									}
								}
								if (flag)
								{
									for (int k = 0; k < 1000; k++)
									{
										if (Main.projectile[k].active && Main.projectile[k].owner == this.whoAmI && Main.projectile[k].aiStyle == 105 && (center - Main.projectile[k].Center).Length() < 48f)
										{
											flag = false;
											break;
										}
									}
									if (flag && Main.myPlayer == this.whoAmI)
									{
										Projectile.NewProjectile(center.X, center.Y, 0f, 0f, 567 + Main.rand.Next(2), damage, knockBack, this.whoAmI, 0f, 0f);
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
					Main.npc[i].AddBuff(72, 120, false);
				}
			}
			if (this.frostBurn)
			{
				Main.npc[i].AddBuff(44, 60 * Main.rand.Next(5, 15), false);
			}
			if (this.magmaStone)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.npc[i].AddBuff(24, 360, false);
				}
				else if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(24, 240, false);
				}
				else
				{
					Main.npc[i].AddBuff(24, 120, false);
				}
			}
			if (type == 3211)
			{
				Main.npc[i].AddBuff(69, 60 * Main.rand.Next(5, 10), false);
			}
			if (type == 121)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(24, 180, false);
					return;
				}
			}
			else if (type == 3823)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.npc[i].AddBuff(24, 300, false);
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

		public void StatusPlayer(NPC npc)
		{
			if (Main.expertMode && ((npc.type == 266 && Main.rand.Next(3) == 0) || npc.type == 267))
			{
				int num = Main.rand.Next(9);
				if (num == 2 || num == 4)
				{
					num = Main.rand.Next(9);
				}
				float num2 = (float)Main.rand.Next(75, 150) * 0.01f;
				if (num == 0)
				{
					this.AddBuff(20, (int)(60f * num2 * 3.5f), true);
				}
				else if (num == 1)
				{
					this.AddBuff(22, (int)(60f * num2 * 2f), true);
				}
				else if (num == 2)
				{
					this.AddBuff(23, (int)(60f * num2 * 0.5f), true);
				}
				else if (num == 3)
				{
					this.AddBuff(30, (int)(60f * num2 * 5f), true);
				}
				else if (num == 4)
				{
					this.AddBuff(31, (int)(60f * num2 * 1f), true);
				}
				else if (num == 5)
				{
					this.AddBuff(32, (int)(60f * num2 * 3.5f), true);
				}
				else if (num == 6)
				{
					this.AddBuff(33, (int)(60f * num2 * 7.5f), true);
				}
				else if (num == 7)
				{
					this.AddBuff(35, (int)(60f * num2 * 1f), true);
				}
				else if (num == 8)
				{
					this.AddBuff(36, (int)((double)(60f * num2) * 6.5), true);
				}
			}
			if (npc.type == 530 || npc.type == 531)
			{
				this.AddBuff(70, Main.rand.Next(240, 481), true);
			}
			if (npc.type == 159 || npc.type == 158)
			{
				this.AddBuff(30, Main.rand.Next(300, 600), true);
			}
			if (npc.type == 525)
			{
				this.AddBuff(39, 420, true);
			}
			if (npc.type == 526)
			{
				this.AddBuff(69, 420, true);
			}
			if (npc.type == 527)
			{
				this.AddBuff(31, 840, true);
			}
			if (Main.expertMode && (npc.type == 49 || npc.type == 93 || npc.type == 51 || npc.type == 152) && Main.rand.Next(10) == 0)
			{
				this.AddBuff(148, Main.rand.Next(1800, 5400), true);
			}
			if (Main.expertMode && npc.type == 222)
			{
				this.AddBuff(20, Main.rand.Next(60, 240), true);
			}
			if (Main.expertMode && (npc.type == 210 || npc.type == 211))
			{
				this.AddBuff(20, Main.rand.Next(60, 180), true);
			}
			if (Main.expertMode && npc.type == 35)
			{
				this.AddBuff(30, Main.rand.Next(180, 300), true);
			}
			if (Main.expertMode && npc.type == 36 && Main.rand.Next(2) == 0)
			{
				this.AddBuff(32, Main.rand.Next(30, 60), true);
			}
			if (npc.type >= 269 && npc.type <= 272)
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
			if (npc.type >= 273 && npc.type <= 276 && Main.rand.Next(2) == 0)
			{
				this.AddBuff(36, 600, true);
			}
			if (npc.type >= 277 && npc.type <= 280)
			{
				this.AddBuff(24, 600, true);
			}
			if (npc.type == 371)
			{
				this.AddBuff(103, 60 * Main.rand.Next(3, 8), true);
			}
			if (npc.type == 370 && Main.expertMode)
			{
				int num3 = Utils.SelectRandom<int>(Main.rand, new int[]
				{
					0,
					148,
					30
				});
				if (num3 != 0)
				{
					this.AddBuff(num3, 60 * Main.rand.Next(3, 11), true);
				}
			}
			if (((npc.type == 1 && npc.netID == -6) || npc.type == 81 || npc.type == 79) && Main.rand.Next(4) == 0)
			{
				this.AddBuff(22, 900, true);
			}
			if ((npc.type == 23 || npc.type == 25) && Main.rand.Next(3) == 0)
			{
				this.AddBuff(24, 420, true);
			}
			if ((npc.type == 34 || npc.type == 83 || npc.type == 84) && Main.rand.Next(3) == 0)
			{
				this.AddBuff(23, 240, true);
			}
			if ((npc.type == 104 || npc.type == 102) && Main.rand.Next(8) == 0)
			{
				this.AddBuff(30, 2700, true);
			}
			if (npc.type == 75 && Main.rand.Next(10) == 0)
			{
				this.AddBuff(35, 420, true);
			}
			if ((npc.type == 163 || npc.type == 238) && Main.rand.Next(10) == 0)
			{
				this.AddBuff(70, 480, true);
			}
			if ((npc.type == 79 || npc.type == 103) && Main.rand.Next(5) == 0)
			{
				this.AddBuff(35, 420, true);
			}
			if ((npc.type == 75 || npc.type == 78 || npc.type == 82) && Main.rand.Next(8) == 0)
			{
				this.AddBuff(32, 900, true);
			}
			if ((npc.type == 93 || npc.type == 109 || npc.type == 80) && Main.rand.Next(14) == 0)
			{
				this.AddBuff(31, 300, true);
			}
			if (npc.type >= 305 && npc.type <= 314 && Main.rand.Next(10) == 0)
			{
				this.AddBuff(33, 3600, true);
			}
			if (npc.type == 77 && Main.rand.Next(6) == 0)
			{
				this.AddBuff(36, 7200, true);
			}
			if (npc.type == 112 && Main.rand.Next(20) == 0)
			{
				this.AddBuff(33, 18000, true);
			}
			if (npc.type == 182 && Main.rand.Next(25) == 0)
			{
				this.AddBuff(33, 7200, true);
			}
			if (npc.type == 141 && Main.rand.Next(2) == 0)
			{
				this.AddBuff(20, 600, true);
			}
			if (npc.type == 147 && !this.frozen && Main.rand.Next(12) == 0)
			{
				this.AddBuff(46, 600, true);
			}
			if (npc.type == 150)
			{
				if (Main.rand.Next(2) == 0)
				{
					this.AddBuff(46, 900, true);
				}
				if (!this.frozen && Main.rand.Next(35) == 0)
				{
					this.AddBuff(47, 60, true);
				}
				else if (!this.frozen && Main.expertMode && Main.rand.Next(35) == 0)
				{
					this.AddBuff(47, 60, true);
				}
			}
			if (npc.type == 184)
			{
				this.AddBuff(46, 1200, true);
				if (!this.frozen && Main.rand.Next(15) == 0)
				{
					this.AddBuff(47, 60, true);
					return;
				}
				if (!this.frozen && Main.expertMode && Main.rand.Next(25) == 0)
				{
					this.AddBuff(47, 60, true);
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
			else if (type == 3823)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.player[i].AddBuff(24, 300, true);
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
			int num2 = this.height / 2;
			new Vector2(this.position.X + (float)(this.width / 2) - (float)(num / 2), this.position.Y + (float)(this.height / 2) - (float)(num2 / 2));
			Vector2 vector = Collision.StickyTiles(this.position, this.velocity, this.width, this.height);
			if (vector.Y != -1f && vector.X != -1f)
			{
				int num3 = (int)vector.X;
				int num4 = (int)vector.Y;
				int type = (int)Main.tile[num3, num4].type;
				if (this.whoAmI == Main.myPlayer && type == 51 && (this.velocity.X != 0f || this.velocity.Y != 0f))
				{
					this.stickyBreak++;
					if (this.stickyBreak > Main.rand.Next(20, 100) || flag)
					{
						this.stickyBreak = 0;
						WorldGen.KillTile(num3, num4, false, false, false);
						if (Main.netMode == 1 && !Main.tile[num3, num4].active() && Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 0, (float)num3, (float)num4, 0f, 0, 0, 0);
						}
					}
				}
				if (flag)
				{
					return;
				}
				this.fallStart = (int)(this.position.Y / 16f);
				if (type != 229)
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
			}
			else
			{
				this.stickyBreak = 0;
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

		public void TakeUnityPotion()
		{
			for (int i = 0; i < 400; i++)
			{
				if (this.inventory[i].type == 2997 && this.inventory[i].stack > 0)
				{
					this.inventory[i].stack--;
					if (this.inventory[i].stack <= 0)
					{
						this.inventory[i].SetDefaults(0, false);
					}
					return;
				}
			}
		}

		public bool TeamChangeAllowed()
		{
			return true;
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
				int extraInfo2 = 0;
				if (Style == 4)
				{
					extraInfo2 = this.lastPortalColorIndex;
				}
				PressurePlateHelper.UpdatePlayerPosition(this);
				this.position = newPos;
				this.fallStart = (int)(this.position.Y / 16f);
				if (Style == 4)
				{
					this.lastPortalColorIndex = extraInfo;
					extraInfo2 = this.lastPortalColorIndex;
					this.portalPhysicsFlag = true;
					this.gravity = 0f;
				}
				PressurePlateHelper.UpdatePlayerPosition(this);
				for (int j = 0; j < 3; j++)
				{
					this.UpdateSocialShadow();
				}
				this.oldPosition = this.position + this.BlehOldPositionFixer;
				this.teleportTime = 1f;
				this.teleportStyle = Style;
			}
			catch
			{
			}
		}

		public void TeleportationPotion()
		{
			bool flag = false;
			int teleportStartX = 100;
			int teleportRangeX = Main.maxTilesX - 200;
			int teleportStartY = 100;
			int teleportRangeY = Main.maxTilesY - 200;
			Vector2 vector = this.TestTeleport(ref flag, teleportStartX, teleportRangeX, teleportStartY, teleportRangeY);
			if (flag)
			{
				Vector2 newPos = vector;
				this.Teleport(newPos, 2, 0);
				this.velocity = Vector2.Zero;
				if (Main.netMode == 2)
				{
					RemoteClient.CheckSection(this.whoAmI, this.position, 1);
					NetMessage.SendData(65, -1, -1, "", 0, (float)this.whoAmI, newPos.X, newPos.Y, 3, 0, 0);
				}
			}
		}
		private Vector2 TestTeleport(ref bool canSpawn, int teleportStartX, int teleportRangeX, int teleportStartY, int teleportRangeY)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int width = this.width;
			Vector2 vector = new Vector2((float)num2, (float)num3) * 16f + new Vector2((float)(-(float)width / 2 + 8), (float)(-(float)this.height));
			while (!canSpawn && num < 1000)
			{
				num++;
				num2 = teleportStartX + Main.rand.Next(teleportRangeX);
				num3 = teleportStartY + Main.rand.Next(teleportRangeY);
				vector = new Vector2((float)num2, (float)num3) * 16f + new Vector2((float)(-(float)width / 2 + 8), (float)(-(float)this.height));
				if (!Collision.SolidCollision(vector, width, this.height))
				{
					if (Main.tile[num2, num3] == null)
					{
						Main.tile[num2, num3] = new Tile();
					}
					if ((Main.tile[num2, num3].wall != 87 || (double)num3 <= Main.worldSurface || NPC.downedPlantBoss) && (!Main.wallDungeon[(int)Main.tile[num2, num3].wall] || (double)num3 <= Main.worldSurface || NPC.downedBoss3))
					{
						int i = 0;
						while (i < 100)
						{
							if (Main.tile[num2, num3 + i] == null)
							{
								Main.tile[num2, num3 + i] = new Tile();
							}
							Tile tile = Main.tile[num2, num3 + i];
							vector = new Vector2((float)num2, (float)(num3 + i)) * 16f + new Vector2((float)(-(float)width / 2 + 8), (float)(-(float)this.height));
							Vector4 vector2 = Collision.SlopeCollision(vector, this.velocity, width, this.height, this.gravDir, false);
							bool flag = !Collision.SolidCollision(vector, width, this.height);
							if (vector2.Z == this.velocity.X)
							{
								float arg_1D4_0 = this.velocity.Y;
							}
							if (flag)
							{
								i++;
							}
							else
							{
								if (tile.active() && !tile.inActive() && Main.tileSolid[(int)tile.type])
								{
									break;
								}
								i++;
							}
						}
						if (!Collision.LavaCollision(vector, width, this.height) && Collision.HurtTiles(vector, this.velocity, width, this.height, false).Y <= 0f)
						{
							Collision.SlopeCollision(vector, this.velocity, width, this.height, this.gravDir, false);
							if (Collision.SolidCollision(vector, width, this.height) && i < 99)
							{
								Vector2 vector3 = Vector2.UnitX * 16f;
								if (!(Collision.TileCollision(vector - vector3, vector3, this.width, this.height, false, false, (int)this.gravDir) != vector3))
								{
									vector3 = -Vector2.UnitX * 16f;
									if (!(Collision.TileCollision(vector - vector3, vector3, this.width, this.height, false, false, (int)this.gravDir) != vector3))
									{
										vector3 = Vector2.UnitY * 16f;
										if (!(Collision.TileCollision(vector - vector3, vector3, this.width, this.height, false, false, (int)this.gravDir) != vector3))
										{
											vector3 = -Vector2.UnitY * 16f;
											if (!(Collision.TileCollision(vector - vector3, vector3, this.width, this.height, false, false, (int)this.gravDir) != vector3))
											{
												canSpawn = true;
												num3 += i;
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
			return vector;
		}

		public void TileInteractionsCheck(int myX, int myY)
		{
			if (Main.tile[myX, myY] == null)
			{
				Main.tile[myX, myY] = new Tile();
			}
			if (Main.tile[myX, myY].active())
			{
				this.TileInteractionsMouseOver(myX, myY);
				this.TileInteractionsUse(myX, myY);
			}
		}

		private void TileInteractionsCheckLongDistance(int myX, int myY)
		{
			if (Main.tile[myX, myY] == null)
			{
				Main.tile[myX, myY] = new Tile();
			}
			if (Main.tile[myX, myY].type == 21)
			{
				Tile tile = Main.tile[myX, myY];
				int num = myX;
				int num2 = myY;
				if (tile.frameX % 36 != 0)
				{
					num--;
				}
				if (tile.frameY % 36 != 0)
				{
					num2--;
				}
				int num3 = Chest.FindChest(num, num2);
				this.showItemIcon2 = -1;
				if (num3 < 0)
				{
					this.showItemIconText = Lang.chestType[0];
				}
				else
				{
					if (Main.chest[num3].name != "")
					{
						this.showItemIconText = Main.chest[num3].name;
					}
					else
					{
						this.showItemIconText = Lang.chestType[(int)(tile.frameX / 36)];
					}
					if (this.showItemIconText == Lang.chestType[(int)(tile.frameX / 36)])
					{
						this.showItemIcon2 = Chest.chestTypeToIcon[(int)(tile.frameX / 36)];
						this.showItemIconText = "";
					}
				}
				this.noThrow = 2;
				this.showItemIcon = true;
				if (this.showItemIconText == "")
				{
					this.showItemIcon = false;
					this.showItemIcon2 = 0;
				}
			}
			if (Main.tile[myX, myY].type == 88)
			{
				Tile tile2 = Main.tile[myX, myY];
				int num4 = myY;
				int x = myX - (int)(tile2.frameX % 54 / 18);
				if (tile2.frameY % 36 != 0)
				{
					num4--;
				}
				int num5 = Chest.FindChest(x, num4);
				this.showItemIcon2 = -1;
				if (num5 < 0)
				{
					this.showItemIconText = Lang.dresserType[0];
				}
				else
				{
					if (Main.chest[num5].name != "")
					{
						this.showItemIconText = Main.chest[num5].name;
					}
					else
					{
						this.showItemIconText = Lang.dresserType[(int)(tile2.frameX / 54)];
					}
					if (this.showItemIconText == Lang.dresserType[(int)(tile2.frameX / 54)])
					{
						this.showItemIcon2 = Chest.dresserTypeToIcon[(int)(tile2.frameX / 54)];
						this.showItemIconText = "";
					}
				}
				this.noThrow = 2;
				this.showItemIcon = true;
				if (this.showItemIconText == "")
				{
					this.showItemIcon = false;
					this.showItemIcon2 = 0;
				}
			}
			if (Main.tileSign[(int)Main.tile[myX, myY].type])
			{
				this.noThrow = 2;
				int num6 = (int)(Main.tile[myX, myY].frameX / 18);
				int num7 = (int)(Main.tile[myX, myY].frameY / 18);
				num6 %= 2;
				int num8 = myX - num6;
				int num9 = myY - num7;
				Main.signBubble = true;
				Main.signX = num8 * 16 + 16;
				Main.signY = num9 * 16;
				int num10 = Sign.ReadSign(num8, num9, true);
				if (num10 != -1)
				{
					Main.signHover = num10;
					this.showItemIcon = false;
					this.showItemIcon2 = -1;
				}
			}
		}

		private void TileInteractionsMouseOver(int myX, int myY)
		{
		}

		private void TileInteractionsUse(int myX, int myY)
		{
			if (WiresUI.Open)
			{
				return;
			}
			if (this.ownedProjectileCounts[651] > 0)
			{
				return;
			}
			bool flag = this.controlUseTile;
			bool flag2 = this.releaseUseTile;
			if (flag)
			{
				if (Main.tile[myX, myY].type == 212 && this.launcherWait <= 0)
				{
					bool flag3 = false;
					for (int i = 0; i < 58; i++)
					{
						if (this.inventory[i].type == 949 && this.inventory[i].stack > 0)
						{
							this.inventory[i].stack--;
							if (this.inventory[i].stack <= 0)
							{
								this.inventory[i].SetDefaults(0, false);
							}
							flag3 = true;
							break;
						}
					}
					if (flag3)
					{
						this.launcherWait = 10;
						int j = (int)(Main.tile[myX, myY].frameX / 18);
						int num = 0;
						while (j >= 3)
						{
							num++;
							j -= 3;
						}
						j = myX - j;
						int k;
						for (k = (int)(Main.tile[myX, myY].frameY / 18); k >= 3; k -= 3)
						{
						}
						k = myY - k;
						float num2 = 12f + (float)Main.rand.Next(450) * 0.01f;
						float num3 = (float)Main.rand.Next(85, 105);
						float num4 = (float)Main.rand.Next(-35, 11);
						int type = 166;
						int damage = 35;
						float knockBack = 3.5f;
						Vector2 vector = new Vector2((float)((j + 2) * 16 - 8), (float)((k + 2) * 16 - 8));
						if (num == 0)
						{
							num3 *= -1f;
							vector.X -= 12f;
						}
						else
						{
							vector.X += 12f;
						}
						float num5 = num3;
						float num6 = num4;
						float num7 = (float)Math.Sqrt((double)(num5 * num5 + num6 * num6));
						num7 = num2 / num7;
						num5 *= num7;
						num6 *= num7;
						Projectile.NewProjectile(vector.X, vector.Y, num5, num6, type, damage, knockBack, Main.myPlayer, 0f, 0f);
					}
				}
				if (flag2)
				{
					if (Main.tile[myX, myY].type == 132 || Main.tile[myX, myY].type == 136 || Main.tile[myX, myY].type == 144)
					{
						Wiring.HitSwitch(myX, myY);
						NetMessage.SendData(59, -1, -1, "", myX, (float)myY, 0f, 0f, 0, 0, 0);
					}
					else if (Main.tile[myX, myY].type == 441)
					{
						int l;
						for (l = (int)(Main.tile[myX, myY].frameX / 18); l > 1; l -= 2)
						{
						}
						l = myX - l;
						int num8 = myY - (int)(Main.tile[myX, myY].frameY / 18);
						Animation.NewTemporaryAnimation(2, 441, l, num8);
						NetMessage.SendTemporaryAnimation(-1, 2, 441, l, num8);
						Wiring.HitSwitch(myX, myY);
						NetMessage.SendData(59, -1, -1, "", myX, (float)myY, 0f, 0f, 0, 0, 0);
					}
					else if (Main.tile[myX, myY].type == 139)
					{
						WorldGen.SwitchMB(myX, myY);
					}
					else if (Main.tile[myX, myY].type == 215)
					{
						int num9 = (int)(Main.tile[myX, myY].frameX % 54 / 18);
						int num10 = (int)(Main.tile[myX, myY].frameY % 36 / 18);
						int num11 = myX - num9;
						int num12 = myY - num10;
						int num13 = 36;
						if (Main.tile[num11, num12].frameY >= 36)
						{
							num13 = -36;
						}
						for (int m = num11; m < num11 + 3; m++)
						{
							for (int n = num12; n < num12 + 2; n++)
							{
								Main.tile[m, n].frameY = (short)((int)Main.tile[m, n].frameY + num13);
							}
						}
						NetMessage.SendTileSquare(-1, num11 + 1, num12 + 1, 3, TileChangeType.None);
					}
					else if (Main.tile[myX, myY].type == 207)
					{
						WorldGen.SwitchFountain(myX, myY);
					}
					else if (Main.tile[myX, myY].type == 410)
					{
						WorldGen.SwitchMonolith(myX, myY);
					}
					else if (Main.tile[myX, myY].type == 455)
					{
						BirthdayParty.ToggleManualParty();
					}
					else if (Main.tile[myX, myY].type == 216)
					{
						WorldGen.LaunchRocket(myX, myY);
					}
					else if (Main.tile[myX, myY].type == 386 || Main.tile[myX, myY].type == 387)
					{
						bool value = Main.tile[myX, myY].type == 387;
						int num14 = WorldGen.ShiftTrapdoor(myX, myY, (float)(myY * 16) > base.Center.Y, -1).ToInt();
						if (num14 == 0)
						{
							num14 = -WorldGen.ShiftTrapdoor(myX, myY, (float)(myY * 16) <= base.Center.Y, -1).ToInt();
						}
						if (num14 != 0)
						{
							NetMessage.SendData(19, -1, -1, "", 2 + value.ToInt(), (float)myX, (float)myY, (float)(num14 * Math.Sign((float)(myY * 16) - base.Center.Y)), 0, 0, 0);
						}
					}
					else if (Main.tile[myX, myY].type == 388 || Main.tile[myX, myY].type == 389)
					{
						bool flag4 = Main.tile[myX, myY].type == 389;
						WorldGen.ShiftTallGate(myX, myY, flag4);
						NetMessage.SendData(19, -1, -1, "", 4 + flag4.ToInt(), (float)myX, (float)myY, 0f, 0, 0, 0);
					}
					else if (Main.tile[myX, myY].type == 335)
					{
						WorldGen.LaunchRocketSmall(myX, myY);
					}
					else if (Main.tile[myX, myY].type == 411 && Main.tile[myX, myY].frameX < 36)
					{
						Wiring.HitSwitch(myX, myY);
						NetMessage.SendData(59, -1, -1, "", myX, (float)myY, 0f, 0f, 0, 0, 0);
					}
					else if (Main.tile[myX, myY].type == 338)
					{
						int num15 = myY;
						if (Main.tile[myX, num15].frameY == 18)
						{
							num15--;
						}
						bool flag5 = false;
						for (int num16 = 0; num16 < 1000; num16++)
						{
							if (Main.projectile[num16].active && Main.projectile[num16].aiStyle == 73 && Main.projectile[num16].ai[0] == (float)myX && Main.projectile[num16].ai[1] == (float)num15)
							{
								flag5 = true;
								break;
							}
						}
						if (!flag5)
						{
							Projectile.NewProjectile((float)(myX * 16 + 8), (float)(num15 * 16 + 2), 0f, 0f, 419 + Main.rand.Next(4), 0, 0f, this.whoAmI, (float)myX, (float)num15);
						}
					}
					else if (Main.tile[myX, myY].type == 4 || Main.tile[myX, myY].type == 13 || Main.tile[myX, myY].type == 33 || Main.tile[myX, myY].type == 49 || (Main.tile[myX, myY].type == 50 && Main.tile[myX, myY].frameX == 90) || Main.tile[myX, myY].type == 174)
					{
						WorldGen.KillTile(myX, myY, false, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 0, (float)myX, (float)myY, 0f, 0, 0, 0);
						}
					}
					else if (Main.tile[myX, myY].type == 466)
					{
						flag2 = true;
						bool flag6 = !DD2Event.Ongoing && !NPC.AnyNPCs(548);
						if (flag6)
						{
							flag6 = this.HasItem(3828);
						}
						if (flag6)
						{
							flag6 = !DD2Event.WouldFailSpawningHere(myX, myY);
							if (!flag6)
							{
								DD2Event.FailureMessage(-1);
							}
						}
						if (flag6)
						{
							flag6 = this.ConsumeItem(3828, true);
						}
						if (flag6)
						{
							DD2Event.SummonCrystal(myX, myY);
						}
					}
					else if (Main.tile[myX, myY].type == 334)
					{
						if (this.ItemFitsWeaponRack(this.inventory[this.selectedItem]))
						{
							this.PlaceWeapon(myX, myY);
						}
						else
						{
							int num17 = myX;
							int num18 = myY;
							if (Main.tile[myX, myY].frameY == 0)
							{
								num18++;
							}
							if (Main.tile[myX, myY].frameY == 36)
							{
								num18--;
							}
							int frameX = (int)Main.tile[myX, num18].frameX;
							int num19 = (int)Main.tile[myX, num18].frameX;
							int num20 = 0;
							while (num19 >= 5000)
							{
								num19 -= 5000;
								num20++;
							}
							if (num20 != 0)
							{
								num19 = (num20 - 1) * 18;
							}
							num19 %= 54;
							if (num19 == 18)
							{
								frameX = (int)Main.tile[myX - 1, num18].frameX;
								num17--;
							}
							if (num19 == 36)
							{
								frameX = (int)Main.tile[myX - 2, num18].frameX;
								num17 -= 2;
							}
							if (frameX >= 5000)
							{
								WorldGen.KillTile(myX, num18, true, false, false);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 0, (float)myX, (float)num18, 1f, 0, 0, 0);
								}
							}
						}
					}
					if (Main.tile[myX, myY].type == 440)
					{
						int num21 = (int)(Main.tile[myX, myY].frameX / 54);
						int num22 = (int)(Main.tile[myX, myY].frameY / 54);
						int num23 = -1;
						switch (num21)
						{
						case 0:
							num23 = 1526;
							break;
						case 1:
							num23 = 1524;
							break;
						case 2:
							num23 = 1525;
							break;
						case 3:
							num23 = 1523;
							break;
						case 4:
							num23 = 1522;
							break;
						case 5:
							num23 = 1527;
							break;
						case 6:
							num23 = 3643;
							break;
						}
						if (num23 != -1)
						{
							if (num22 == 0 && this.HasItem(num23) && this.selectedItem != 58)
							{
								if (Main.netMode != 1)
								{
									this.consumeItem(num23);
									WorldGen.ToggleGemLock(myX, myY, true);
								}
								else
								{
									this.consumeItem(num23);
									NetMessage.SendData(105, -1, -1, "", myX, (float)myY, 1f, 0f, 0, 0, 0);
								}
							}
							else if (num22 == 1)
							{
								if (Main.netMode != 1)
								{
									WorldGen.ToggleGemLock(myX, myY, false);
								}
								else
								{
									NetMessage.SendData(105, -1, -1, "", myX, (float)myY, 0f, 0f, 0, 0, 0);
								}
							}
						}
					}
					else if (Main.tile[myX, myY].type == 395)
					{
						if (this.ItemFitsItemFrame(this.inventory[this.selectedItem]) && !this.inventory[this.selectedItem].favorited)
						{
							this.PlaceItemInFrame(myX, myY);
						}
						else
						{
							int num24 = myX;
							int num25 = myY;
							if (Main.tile[num24, num25].frameX % 36 != 0)
							{
								num24--;
							}
							if (Main.tile[num24, num25].frameY % 36 != 0)
							{
								num25--;
							}
							int num26 = TEItemFrame.Find(num24, num25);
							if (num26 != -1 && ((TEItemFrame)TileEntity.ByID[num26]).item.stack > 0)
							{
								WorldGen.KillTile(myX, num25, true, false, false);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 0, (float)myX, (float)num25, 1f, 0, 0, 0);
								}
							}
						}
					}
					else if (Main.tile[myX, myY].type == 125)
					{
						this.AddBuff(29, 36000, true);
					}
					else if (Main.tile[myX, myY].type == 377)
					{
						this.AddBuff(159, 36000, true);
					}
					else if (Main.tile[myX, myY].type == 354)
					{
						this.AddBuff(150, 36000, true);
					}
					else if (Main.tile[myX, myY].type == 287)
					{
						this.AddBuff(93, 36000, true);
					}
					else if (Main.tile[myX, myY].type == 356)
					{
						if (!Main.fastForwardTime && (Main.netMode == 1 || Main.sundialCooldown == 0))
						{
							Main.Sundialing();
						}
					}
					else if (Main.tile[myX, myY].type == 79)
					{
						int num27 = myX + (int)(Main.tile[myX, myY].frameX / 18 * -1);
						if (Main.tile[myX, myY].frameX >= 72)
						{
							num27 += 4;
							num27++;
						}
						else
						{
							num27 += 2;
						}
						int num28 = (int)(Main.tile[myX, myY].frameY / 18);
						int num29 = 0;
						while (num28 > 1)
						{
							num28 -= 2;
							num29++;
						}
						int num30 = myY - num28;
						num30 += 2;
						this.FindSpawn();
						if (this.SpawnX == num27 && this.SpawnY == num30)
						{
							this.RemoveSpawn();
							Main.NewText(Language.GetTextValue("Game.SpawnPointRemoved"), 255, 240, 20, false);
						}
						else if (Player.CheckSpawn(num27, num30))
						{
							this.ChangeSpawn(num27, num30);
							Main.NewText(Language.GetTextValue("Game.SpawnPointSet"), 255, 240, 20, false);
						}
					}
					else if (Main.tileSign[(int)Main.tile[myX, myY].type])
					{
						bool flag6 = true;
						if (this.sign >= 0)
						{
							int num31 = Sign.ReadSign(myX, myY, true);
							if (num31 == this.sign)
							{
								this.sign = -1;
								Main.npcChatText = "";
								Main.editSign = false;
								flag6 = false;
							}
						}
						if (flag6)
						{
							if (Main.netMode == 0)
							{
								this.talkNPC = -1;
								Main.npcChatCornerItem = 0;
								Main.playerInventory = false;
								Main.editSign = false;
								int num32 = Sign.ReadSign(myX, myY, true);
								this.sign = num32;
								Main.npcChatText = Main.sign[num32].text;
							}
							else
							{
								int num33 = (int)(Main.tile[myX, myY].frameX / 18);
								int num34 = (int)(Main.tile[myX, myY].frameY / 18);
								while (num33 > 1)
								{
									num33 -= 2;
								}
								int num35 = myX - num33;
								int num36 = myY - num34;
								if (Main.tileSign[(int)Main.tile[num35, num36].type])
								{
									NetMessage.SendData(46, -1, -1, "", num35, (float)num36, 0f, 0f, 0, 0, 0);
								}
							}
						}
					}
					else if (Main.tile[myX, myY].type == 104)
					{
						string text = "AM";
						double num37 = Main.time;
						if (!Main.dayTime)
						{
							num37 += 54000.0;
						}
						num37 = num37 / 86400.0 * 24.0;
						double num38 = 7.5;
						num37 = num37 - num38 - 12.0;
						if (num37 < 0.0)
						{
							num37 += 24.0;
						}
						if (num37 >= 12.0)
						{
							text = "PM";
						}
						int num39 = (int)num37;
						double num40 = num37 - (double)num39;
						num40 = (double)((int)(num40 * 60.0));
						string text2 = string.Concat(num40);
						if (num40 < 10.0)
						{
							text2 = "0" + text2;
						}
						if (num39 > 12)
						{
							num39 -= 12;
						}
						if (num39 == 0)
						{
							num39 = 12;
						}
						string newText = string.Concat(new object[]
						{
							"Time: ",
							num39,
							":",
							text2,
							" ",
							text
						});
						Main.NewText(newText, 255, 240, 20, false);
					}
					else if (Main.tile[myX, myY].type == 237)
					{
						bool flag7 = false;
						if (!NPC.AnyNPCs(245) && Main.hardMode && NPC.downedPlantBoss)
						{
							for (int num41 = 0; num41 < 58; num41++)
							{
								if (this.inventory[num41].type == 1293)
								{
									this.inventory[num41].stack--;
									if (this.inventory[num41].stack <= 0)
									{
										this.inventory[num41].SetDefaults(0, false);
									}
									flag7 = true;
									break;
								}
							}
						}
						if (flag7)
						{
							if (Main.netMode != 1)
							{
								NPC.SpawnOnPlayer(this.whoAmI, 245);
							}
							else
							{
								NetMessage.SendData(61, -1, -1, "", this.whoAmI, 245f, 0f, 0f, 0, 0, 0);
							}
						}
					}
					else if (Main.tile[myX, myY].type == 10)
					{
						if (Main.tile[myX, myY].frameY >= 594 && Main.tile[myX, myY].frameY <= 646)
						{
							int num42 = 1141;
							for (int num43 = 0; num43 < 58; num43++)
							{
								if (this.inventory[num43].type == num42 && this.inventory[num43].stack > 0)
								{
									this.inventory[num43].stack--;
									if (this.inventory[num43].stack <= 0)
									{
										this.inventory[num43] = new Item();
									}
									WorldGen.UnlockDoor(myX, myY);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(52, -1, -1, "", this.whoAmI, 2f, (float)myX, (float)myY, 0, 0, 0);
									}
								}
							}
						}
						else
						{
							WorldGen.OpenDoor(myX, myY, this.direction);
							NetMessage.SendData(19, -1, -1, "", 0, (float)myX, (float)myY, (float)this.direction, 0, 0, 0);
						}
					}
					else if (Main.tile[myX, myY].type == 11 && WorldGen.CloseDoor(myX, myY, false))
					{
						NetMessage.SendData(19, -1, -1, "", 1, (float)myX, (float)myY, (float)this.direction, 0, 0, 0);
					}
					if (Main.tile[myX, myY].type == 88)
					{
						if (Main.tile[myX, myY].frameY == 0)
						{
							Main.CancelClothesWindow(true);
							Main.mouseRightRelease = false;
							int num44 = (int)(Main.tile[myX, myY].frameX / 18);
							num44 %= 3;
							num44 = myX - num44;
							int num45 = myY - (int)(Main.tile[myX, myY].frameY / 18);
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
								NetMessage.SendData(33, -1, -1, Main.chest[this.chest].name, this.chest, 1f, 0f, 0f, 0, 0, 0);
								this.editedChestName = false;
							}
							if (Main.netMode == 1)
							{
								if (num44 == this.chestX && num45 == this.chestY && this.chest != -1)
								{
									this.chest = -1;
									Recipe.FindRecipes();
								}
								else
								{
									NetMessage.SendData(31, -1, -1, "", num44, (float)num45, 0f, 0f, 0, 0, 0);
									Main.stackSplit = 600;
								}
							}
							else
							{
								this.flyingPigChest = -1;
								int num46 = Chest.FindChest(num44, num45);
								if (num46 != -1)
								{
									Main.stackSplit = 600;
									if (num46 == this.chest)
									{
										this.chest = -1;
										Recipe.FindRecipes();
									}
									else if (num46 != this.chest && this.chest == -1)
									{
										this.chest = num46;
										Main.playerInventory = true;
										Main.recBigList = false;
										this.chestX = num44;
										this.chestY = num45;
									}
									else
									{
										this.chest = num46;
										Main.playerInventory = true;
										Main.recBigList = false;
										this.chestX = num44;
										this.chestY = num45;
									}
									Recipe.FindRecipes();
								}
							}
						}
						else
						{
							Main.playerInventory = false;
							this.chest = -1;
							Recipe.FindRecipes();
							Main.dresserX = myX;
							Main.dresserY = myY;
							Main.OpenClothesWindow();
						}
					}
					if (Main.tile[myX, myY].type == 209)
					{
						Tile tile = Main.tile[myX, myY];
						int num47 = (int)(tile.frameX % 72 / 18);
						int num48 = (int)(tile.frameY % 54 / 18);
						int num49 = myX - num47;
						int num50 = myY - num48;
						int num51 = (int)(tile.frameY / 54);
						int num52 = (int)(tile.frameX / 72);
						int num53 = -1;
						if (num47 == 1 || num47 == 2)
						{
							num53 = num48;
						}
						int num54 = 0;
						if (num47 == 3 || (num47 == 2 && num52 != 3 && num52 != 4))
						{
							num54 = -54;
						}
						if (num47 == 0 || (num47 == 1 && num52 != 3 && num52 != 4))
						{
							num54 = 54;
						}
						if (num51 >= 8 && num54 > 0)
						{
							num54 = 0;
						}
						if (num51 == 0 && num54 < 0)
						{
							num54 = 0;
						}
						bool flag8 = false;
						if (num54 != 0)
						{
							for (int num55 = num49; num55 < num49 + 4; num55++)
							{
								for (int num56 = num50; num56 < num50 + 3; num56++)
								{
									Main.tile[num55, num56].frameY = (short)((int)Main.tile[num55, num56].frameY + num54);
								}
							}
							flag8 = true;
						}
						if ((num52 == 3 || num52 == 4) && (num53 == 1 || num53 == 0))
						{
							num54 = ((num52 == 3) ? 72 : -72);
							for (int num57 = num49; num57 < num49 + 4; num57++)
							{
								for (int num58 = num50; num58 < num50 + 3; num58++)
								{
									Main.tile[num57, num58].frameX = (short)((int)Main.tile[num57, num58].frameX + num54);
								}
							}
							flag8 = true;
						}
						if (flag8)
						{
							NetMessage.SendTileSquare(-1, num49 + 1, num50 + 1, 4, TileChangeType.None);
						}
						if (num53 != -1)
						{
							bool flag9 = false;
							if ((num52 == 3 || num52 == 4) && num53 == 2)
							{
								flag9 = true;
							}
							if (flag9)
							{
								WorldGen.ShootFromCannon(num49, num50, num51, num52 + 1, 0, 0f, this.whoAmI);
							}
						}
					}
					else if ((Main.tile[myX, myY].type == 21 || Main.tile[myX, myY].type == 29 || Main.tile[myX, myY].type == 97 || Main.tile[myX, myY].type == 463) && this.talkNPC == -1)
					{
						Main.mouseRightRelease = false;
						int num59 = 0;
						int num60;
						for (num60 = (int)(Main.tile[myX, myY].frameX / 18); num60 > 1; num60 -= 2)
						{
						}
						num60 = myX - num60;
						int num61 = myY - (int)(Main.tile[myX, myY].frameY / 18);
						if (Main.tile[myX, myY].type == 29)
						{
							num59 = 1;
						}
						else if (Main.tile[myX, myY].type == 97)
						{
							num59 = 2;
						}
						else if (Main.tile[myX, myY].type == 463)
						{
							num59 = 3;
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
							NetMessage.SendData(33, -1, -1, Main.chest[this.chest].name, this.chest, 1f, 0f, 0f, 0, 0, 0);
							this.editedChestName = false;
						}
						if (Main.netMode == 1 && num59 == 0 && (Main.tile[num60, num61].frameX < 72 || Main.tile[num60, num61].frameX > 106) && (Main.tile[num60, num61].frameX < 144 || Main.tile[num60, num61].frameX > 178) && (Main.tile[num60, num61].frameX < 828 || Main.tile[num60, num61].frameX > 1006) && (Main.tile[num60, num61].frameX < 1296 || Main.tile[num60, num61].frameX > 1330) && (Main.tile[num60, num61].frameX < 1368 || Main.tile[num60, num61].frameX > 1402) && (Main.tile[num60, num61].frameX < 1440 || Main.tile[num60, num61].frameX > 1474))
						{
							if (num60 == this.chestX && num61 == this.chestY && this.chest != -1)
							{
								this.chest = -1;
								Recipe.FindRecipes();
							}
							else
							{
								NetMessage.SendData(31, -1, -1, "", num60, (float)num61, 0f, 0f, 0, 0, 0);
								Main.stackSplit = 600;
							}
						}
						else
						{
							int num62 = -1;
							if (num59 == 1)
							{
								num62 = -2;
							}
							else if (num59 == 2)
							{
								num62 = -3;
							}
							else if (num59 == 3)
							{
								num62 = -4;
							}
							else
							{
								bool flag10 = false;
								if (Chest.isLocked(num60, num61))
								{
									int num63 = 327;
									if (Main.tile[num60, num61].frameX >= 144 && Main.tile[num60, num61].frameX <= 178)
									{
										num63 = 329;
									}
									if (Main.tile[num60, num61].frameX >= 828 && Main.tile[num60, num61].frameX <= 1006)
									{
										int num64 = (int)(Main.tile[num60, num61].frameX / 18);
										int num65 = 0;
										while (num64 >= 2)
										{
											num64 -= 2;
											num65++;
										}
										num65 -= 23;
										num63 = 1533 + num65;
									}
									flag10 = true;
									for (int num66 = 0; num66 < 58; num66++)
									{
										if (this.inventory[num66].type == num63 && this.inventory[num66].stack > 0 && Chest.Unlock(num60, num61))
										{
											if (num63 != 329)
											{
												this.inventory[num66].stack--;
												if (this.inventory[num66].stack <= 0)
												{
													this.inventory[num66] = new Item();
												}
											}
											if (Main.netMode == 1)
											{
												NetMessage.SendData(52, -1, -1, "", this.whoAmI, 1f, (float)num60, (float)num61, 0, 0, 0);
											}
										}
									}
								}
								if (!flag10)
								{
									num62 = Chest.FindChest(num60, num61);
								}
							}
							if (num62 != -1)
							{
								Main.stackSplit = 600;
								if (num62 == this.chest)
								{
									this.chest = -1;
								}
								else if (num62 != this.chest && this.chest == -1)
								{
									this.chest = num62;
									Main.playerInventory = true;
									Main.recBigList = false;
									this.chestX = num60;
									this.chestY = num61;
									if (Main.tile[num60, num61].frameX >= 36 && Main.tile[num60, num61].frameX < 72)
									{
										AchievementsHelper.HandleSpecialEvent(this, 16);
									}
								}
								else
								{
									this.chest = num62;
									Main.playerInventory = true;
									Main.recBigList = false;
									this.chestX = num60;
									this.chestY = num61;
								}
								Recipe.FindRecipes();
							}
						}
					}
					else if (Main.tile[myX, myY].type == 314 && this.gravDir == 1f)
					{
						bool flag11 = true;
						if (this.mount.Active)
						{
							if (this.mount.Cart)
							{
								flag11 = false;
							}
							else
							{
								this.mount.Dismount(this);
							}
						}
						if (flag11)
						{
							this.LaunchMinecartHook(myX, myY);
						}
					}
				}
				this.releaseUseTile = false;
				return;
			}
			this.releaseUseTile = true;
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
				int num = 0;
				bool flag = false;
				foreach (Point current in this.TouchedTiles)
				{
					Tile tile = Main.tile[current.X, current.Y];
					if (tile != null && tile.active() && tile.nactive() && Main.tileBouncy[(int)tile.type])
					{
						flag = true;
						num = current.Y;
						break;
					}
				}
				if (flag)
				{
					this.velocity.Y = this.velocity.Y * -0.8f;
					if (this.controlJump)
					{
						this.velocity.Y = MathHelper.Clamp(this.velocity.Y, -13f, 13f);
					}
					this.position.Y = (float)(num * 16 - ((this.velocity.Y < 0f) ? this.height : -16));
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
			switch (Main.rand.Next(12))
			{
			case 0:
				this.QuickSpawnItem(666, 1);
				this.QuickSpawnItem(667, 1);
				this.QuickSpawnItem(668, 1);
				this.QuickSpawnItem(665, 1);
				this.QuickSpawnItem(3287, 1);
				return;
			case 1:
				this.QuickSpawnItem(1554, 1);
				this.QuickSpawnItem(1555, 1);
				this.QuickSpawnItem(1556, 1);
				this.QuickSpawnItem(1586, 1);
				return;
			case 2:
				this.QuickSpawnItem(1587, 1);
				this.QuickSpawnItem(1588, 1);
				this.QuickSpawnItem(1586, 1);
				return;
			case 3:
				this.QuickSpawnItem(1557, 1);
				this.QuickSpawnItem(1558, 1);
				this.QuickSpawnItem(1559, 1);
				this.QuickSpawnItem(1585, 1);
				return;
			case 4:
				this.QuickSpawnItem(1560, 1);
				this.QuickSpawnItem(1561, 1);
				this.QuickSpawnItem(1562, 1);
				this.QuickSpawnItem(1584, 1);
				return;
			case 5:
				this.QuickSpawnItem(1563, 1);
				this.QuickSpawnItem(1564, 1);
				this.QuickSpawnItem(1565, 1);
				this.QuickSpawnItem(3582, 1);
				return;
			case 6:
				this.QuickSpawnItem(1566, 1);
				this.QuickSpawnItem(1567, 1);
				this.QuickSpawnItem(1568, 1);
				return;
			case 7:
				this.QuickSpawnItem(1580, 1);
				this.QuickSpawnItem(1581, 1);
				this.QuickSpawnItem(1582, 1);
				this.QuickSpawnItem(1583, 1);
				return;
			case 8:
				this.QuickSpawnItem(3226, 1);
				this.QuickSpawnItem(3227, 1);
				this.QuickSpawnItem(3228, 1);
				this.QuickSpawnItem(3288, 1);
				return;
			case 9:
				this.QuickSpawnItem(3583, 1);
				this.QuickSpawnItem(3581, 1);
				this.QuickSpawnItem(3578, 1);
				this.QuickSpawnItem(3579, 1);
				this.QuickSpawnItem(3580, 1);
				return;
			case 10:
				this.QuickSpawnItem(3585, 1);
				this.QuickSpawnItem(3586, 1);
				this.QuickSpawnItem(3587, 1);
				this.QuickSpawnItem(3588, 1);
				this.QuickSpawnItem(3024, 4);
				return;
			case 11:
				this.QuickSpawnItem(3589, 1);
				this.QuickSpawnItem(3590, 1);
				this.QuickSpawnItem(3591, 1);
				this.QuickSpawnItem(3592, 1);
				this.QuickSpawnItem(3599, 4);
				return;
			default:
				return;
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
				Point point = (base.Bottom + new Vector2(0f, 0.01f)).ToTileCoordinates();
				Tile tileSafely = Framing.GetTileSafely(point.X, point.Y);
				if (tileSafely.active() && tileSafely.type == 411 && tileSafely.frameY == 0 && tileSafely.frameX < 36)
				{
					Wiring.HitSwitch(point.X, point.Y);
					NetMessage.SendData(59, -1, -1, "", point.X, (float)point.Y, 0f, 0f, 0, 0, 0);
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
			NetMessage.SendData(65, -1, -1, "", 2, (float)this.whoAmI, telePos.X, telePos.Y, num, 0, 0);
		}
		private void PayDD2CrystalsBeforeUse(Item item)
		{
			int requiredDD2CrystalsToUse = this.GetRequiredDD2CrystalsToUse(item);
			for (int i = 0; i < requiredDD2CrystalsToUse; i++)
			{
				this.ConsumeItem(3822, true);
			}
		}
		private bool CheckDD2CrystalPaymentLock(Item item)
		{
			if (!DD2Event.Ongoing)
			{
				return true;
			}
			int requiredDD2CrystalsToUse = this.GetRequiredDD2CrystalsToUse(item);
			return this.CountItem(3822, requiredDD2CrystalsToUse) >= requiredDD2CrystalsToUse;
		}
		private int GetRequiredDD2CrystalsToUse(Item item)
		{
			switch (item.type)
			{
				case 3818:
				case 3819:
				case 3820:
					return 10;
				case 3824:
				case 3825:
				case 3826:
					return 10;
				case 3829:
				case 3830:
				case 3831:
					return 10;
				case 3832:
				case 3833:
				case 3834:
					return 10;
			}
			return 0;
		}
		public void Update(int i)
		{
			if (this.launcherWait > 0)
			{
				this.launcherWait--;
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
				this.maxFallSpeed = 35f;
			}
			if (this.wet)
			{
				if (this.honeyWet)
				{
					this.gravity = 0.1f;
					this.maxFallSpeed = 3f;
				}
				else if (this.merman)
				{
					this.gravity = 0.3f;
					this.maxFallSpeed = 7f;
				}
				else
				{
					this.gravity = 0.2f;
					this.maxFallSpeed = 5f;
					Player.jumpHeight = 30;
					Player.jumpSpeed = 6.01f;
				}
			}
			if (this.vortexDebuff)
			{
				this.gravity = 0f;
			}
			this.maxFallSpeed += 0.01f;
			bool flag = false;
			if (Main.mapFullscreen)
			{
			}
			else if (this._quickGrappleCooldown > 0)
			{
				this._quickGrappleCooldown--;
			}
			if (Main.myPlayer == i)
			{
				TileObject.objectPreview.Reset();
			}
			if (this.active)
			{
				if (this.ghostDmg > 0f)
				{
					this.ghostDmg -= 2.5f;
				}
				if (this.ghostDmg < 0f)
				{
					this.ghostDmg = 0f;
				}
				if (Main.expertMode)
				{
					if (this.lifeSteal < 70f)
					{
						this.lifeSteal += 0.5f;
					}
					if (this.lifeSteal > 70f)
					{
						this.lifeSteal = 70f;
					}
				}
				else
				{
					if (this.lifeSteal < 80f)
					{
						this.lifeSteal += 0.6f;
					}
					if (this.lifeSteal > 80f)
					{
						this.lifeSteal = 80f;
					}
				}
				if (this.mount.Active)
				{
					this.position.Y = this.position.Y + (float)this.height;
					this.height = 42 + this.mount.HeightBoost;
					this.position.Y = this.position.Y - (float)this.height;
					if (this.mount.Type == 0)
					{
						int num = (int)(this.position.X + (float)(this.width / 2)) / 16;
						int j = (int)(this.position.Y + (float)(this.height / 2) - 14f) / 16;

					}
				}
				else
				{
					this.position.Y = this.position.Y + (float)this.height;
					this.height = 42;
					this.position.Y = this.position.Y - (float)this.height;
				}
				Main.numPlayers++;
				this.outOfRange = false;
				if (this.whoAmI != Main.myPlayer)
				{
					int num2 = (int)(this.position.X + (float)(this.width / 2)) / 16;
					int num3 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
					if (!WorldGen.InWorld(num2, num3, 4))
					{
						flag = true;
					}
					else if (Main.tile[num2, num3] == null)
					{
						flag = true;
					}
					else if (Main.tile[num2 - 3, num3] == null)
					{
						flag = true;
					}
					else if (Main.tile[num2 + 3, num3] == null)
					{
						flag = true;
					}
					else if (Main.tile[num2, num3 - 3] == null)
					{
						flag = true;
					}
					else if (Main.tile[num2, num3 + 3] == null)
					{
						flag = true;
					}
					if (flag)
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
					if (!this.tankPetReset)
					{
						this.tankPetReset = true;
					}
					else
					{
						this.tankPet = -1;
					}
				}
			}
			if (!this.active || flag)
			{
				return;
			}
			this.miscCounter++;
			if (this.miscCounter >= 300)
			{
				this.miscCounter = 0;
			}
			this.infernoCounter++;
			if (this.infernoCounter >= 180)
			{
				this.infernoCounter = 0;
			}
			float num4 = (float)(Main.maxTilesX / 4200);
			num4 *= num4;
			float num5 = (float)((double)(this.position.Y / 16f - (60f + 10f * num4)) / (Main.worldSurface / 6.0));
			if ((double)num5 < 0.25)
			{
				num5 = 0.25f;
			}
			if (num5 > 1f)
			{
				num5 = 1f;
			}
			this.gravity *= num5;
			this.maxRegenDelay = (1f - (float)this.statMana / (float)this.statManaMax2) * 60f * 4f + 45f;
			this.maxRegenDelay *= 0.7f;
			this.UpdateSocialShadow();
			this.UpdateTeleportVisuals();
			this.whoAmI = i;
			if (this.whoAmI == Main.myPlayer)
			{
				this.TryPortalJumping();
			}
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
			if (this.potionDelay > 0)
			{
				this.potionDelay--;
			}
			if (i == Main.myPlayer)
			{
				if (this.trashItem.type >= 1522 && this.trashItem.type <= 1527)
				{
					this.trashItem.SetDefaults(0, false);
				}
				if (this.trashItem.type == 3643)
				{
					this.trashItem.SetDefaults(0, false);
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
				this.controlQuickHeal = false;
				this.controlQuickMana = false;
				this.mapStyle = false;
				this.mapAlphaDown = false;
				this.mapAlphaUp = false;
				this.mapFullScreen = false;
				this.mapZoomIn = false;
				this.mapZoomOut = false;
				if (Main.hasFocus)
				{
					if (this.confused)
					{
						bool flag2 = this.controlLeft;
						bool flag3 = this.controlUp;
						this.controlLeft = this.controlRight;
						this.controlRight = flag2;
						this.controlUp = this.controlRight;
						this.controlDown = flag3;
					}
					else if (this.cartFlip)
					{
						if (this.controlRight || this.controlLeft)
						{
							bool flag4 = this.controlLeft;
							this.controlLeft = this.controlRight;
							this.controlRight = flag4;
						}
						else
						{
							this.cartFlip = false;
						}
					}
					for (int k = 0; k < this.doubleTapCardinalTimer.Length; k++)
					{
						this.doubleTapCardinalTimer[k]--;
						if (this.doubleTapCardinalTimer[k] < 0)
						{
							this.doubleTapCardinalTimer[k] = 0;
						}
					}
					for (int l = 0; l < 4; l++)
					{
						bool flag5 = false;
						bool flag6 = false;
						switch (l)
						{
						case 0:
							flag5 = (this.controlDown && this.releaseDown);
							flag6 = this.controlDown;
							break;
						case 1:
							flag5 = (this.controlUp && this.releaseUp);
							flag6 = this.controlUp;
							break;
						case 2:
							flag5 = (this.controlRight && this.releaseRight);
							flag6 = this.controlRight;
							break;
						case 3:
							flag5 = (this.controlLeft && this.releaseLeft);
							flag6 = this.controlLeft;
							break;
						}
						if (flag5)
						{
							if (this.doubleTapCardinalTimer[l] > 0)
							{
								this.KeyDoubleTap(l);
							}
							else
							{
								this.doubleTapCardinalTimer[l] = 15;
							}
						}
						if (flag6)
						{
							this.holdDownCardinalTimer[l]++;
							this.KeyHoldDown(l, this.holdDownCardinalTimer[l]);
						}
						else
						{
							this.holdDownCardinalTimer[l] = 0;
						}
					}
					if (this.controlInv)
					{
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
					if (this.itemAnimation == 0 && this.itemTime == 0 && this.reuseDelay == 0)
					{
						this.dropItemCheck();
						int num6 = this.selectedItem;
						bool flag7 = false;
						
						
					}
				}
				if (this.selectedItem == 58)
				{
					this.nonTorch = -1;
				}
				if (this.stoned != this.lastStoned)
				{
					if (this.whoAmI == Main.myPlayer && this.stoned)
					{
						int damage = (int)(20.0 * (double)Main.damageMultiplier);
						this.Hurt(damage, 0, false, false, Lang.deathMsg(-1, -1, -1, 4), false, -1);
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
					bool flag11 = false;
					if (this.controlUp != Main.clientPlayer.controlUp)
					{
						flag11 = true;
					}
					if (this.controlDown != Main.clientPlayer.controlDown)
					{
						flag11 = true;
					}
					if (this.controlLeft != Main.clientPlayer.controlLeft)
					{
						flag11 = true;
					}
					if (this.controlRight != Main.clientPlayer.controlRight)
					{
						flag11 = true;
					}
					if (this.controlJump != Main.clientPlayer.controlJump)
					{
						flag11 = true;
					}
					if (this.controlUseItem != Main.clientPlayer.controlUseItem)
					{
						flag11 = true;
					}
					if (this.selectedItem != Main.clientPlayer.selectedItem)
					{
						flag11 = true;
					}
					if (flag11)
					{
						NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.playerInventory)
				{
					this.AdjTiles();
				}
				if (this.chest != -1)
				{
					if (this.chest != -2)
					{
						this.flyingPigChest = -1;
					}
					if (this.flyingPigChest >= 0)
					{
						if (!Main.projectile[this.flyingPigChest].active || Main.projectile[this.flyingPigChest].type != 525)
						{
							this.chest = -1;
							Recipe.FindRecipes();
						}
						else
						{
							int num17 = (int)(((double)this.position.X + (double)this.width * 0.5) / 16.0);
							int num18 = (int)(((double)this.position.Y + (double)this.height * 0.5) / 16.0);
							this.chestX = (int)Main.projectile[this.flyingPigChest].Center.X / 16;
							this.chestY = (int)Main.projectile[this.flyingPigChest].Center.Y / 16;
							if (num17 < this.chestX - Player.tileRangeX || num17 > this.chestX + Player.tileRangeX + 1 || num18 < this.chestY - Player.tileRangeY || num18 > this.chestY + Player.tileRangeY + 1)
							{
								this.chest = -1;
								Recipe.FindRecipes();
							}
						}
					}
					else
					{
						int num19 = (int)(((double)this.position.X + (double)this.width * 0.5) / 16.0);
						int num20 = (int)(((double)this.position.Y + (double)this.height * 0.5) / 16.0);
						if (num19 < this.chestX - Player.tileRangeX || num19 > this.chestX + Player.tileRangeX + 1 || num20 < this.chestY - Player.tileRangeY || num20 > this.chestY + Player.tileRangeY + 1)
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
				}
				else
				{
					this.flyingPigChest = -1;
				}
				if (this.velocity.Y <= 0f)
				{
					this.fallStart2 = (int)(this.position.Y / 16f);
				}
				if (this.velocity.Y == 0f)
				{
					int num21 = 25;
					num21 += this.extraFall;
					int num22 = (int)(this.position.Y / 16f) - this.fallStart;
					if (this.mount.CanFly)
					{
						num22 = 0;
					}
					if (this.mount.Cart && Minecart.OnTrack(this.position, this.width, this.height))
					{
						num22 = 0;
					}
					if (this.mount.Type == 1)
					{
						num22 = 0;
					}
					this.mount.FatigueRecovery();
					bool flag12 = false;
					for (int n = 3; n < 10; n++)
					{
						if (this.armor[n].stack > 0 && this.armor[n].wingSlot > -1)
						{
							flag12 = true;
						}
					}
					if (this.stoned)
					{
						int num23 = (int)(((float)num22 * this.gravDir - 2f) * 20f);
						if (num23 > 0)
						{
							this.Hurt(num23, 0, false, false, Lang.deathMsg(-1, -1, -1, 4), false, -1);
							this.immune = false;
						}
					}
					else if (((this.gravDir == 1f && num22 > num21) || (this.gravDir == -1f && num22 < -num21)) && !this.noFallDmg && !flag12)
					{
						this.immune = false;
						int num24 = (int)((float)num22 * this.gravDir - (float)num21) * 10;
						if (this.mount.Active)
						{
							num24 = (int)((float)num24 * this.mount.FallDamage);
						}
						this.Hurt(num24, 0, false, false, Lang.deathMsg(-1, -1, -1, 0), false, -1);
						if (!this.dead && this.statLife <= this.statLifeMax2 / 10)
						{
							AchievementsHelper.HandleSpecialEvent(this, 8);
						}
					}
					this.fallStart = (int)(this.position.Y / 16f);
				}
				if (this.jump > 0 || this.rocketDelay > 0 || this.wet || this.slowFall || (double)num5 < 0.8 || this.tongued)
				{
					this.fallStart = (int)(this.position.Y / 16f);
				}
			}
			if (Main.netMode != 1)
			{
				if (this.chest == -1 && this.lastChest >= 0 && Main.chest[this.lastChest] != null && Main.chest[this.lastChest] != null)
				{
					int x2 = Main.chest[this.lastChest].x;
					int y2 = Main.chest[this.lastChest].y;
					NPC.BigMimicSummonCheck(x2, y2);
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
					int frameY = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY].frameY;
					if (frameY < -4)
					{
						Player.tileTargetX++;
					}
					if (frameY > 4)
					{
						Player.tileTargetX--;
					}
				}
				else if (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active() && Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type == 323)
				{
					int frameY2 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY].frameY;
					if (frameY2 < -4)
					{
						Player.tileTargetX++;
					}
					if (frameY2 > 4)
					{
						Player.tileTargetX--;
					}
				}
			}
			this.UpdateImmunity();
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
			this.restorationDelayTime = Item.restorationDelay;
			if (this.pStone)
			{
				this.potionDelayTime = (int)((double)this.potionDelayTime * 0.75);
				this.restorationDelayTime = (int)((double)this.restorationDelayTime * 0.75);
			}
			this.ResetEffects();
			this.UpdateDyes(i);
			this.meleeCrit += this.inventory[this.selectedItem].crit;
			this.magicCrit += this.inventory[this.selectedItem].crit;
			this.rangedCrit += this.inventory[this.selectedItem].crit;
			this.thrownCrit += this.inventory[this.selectedItem].crit;
			if (this.whoAmI == Main.myPlayer)
			{
				Main.musicBox2 = -1;
				if (Main.waterCandles > 0)
				{
					this.AddBuff(86, 2, false);
				}
				if (Main.peaceCandles > 0)
				{
					this.AddBuff(157, 2, false);
				}
				if (Main.campfire)
				{
					this.AddBuff(87, 2, false);
				}
				if (Main.starInBottle)
				{
					this.AddBuff(158, 2, false);
				}
				if (Main.heartLantern)
				{
					this.AddBuff(89, 2, false);
				}
				if (Main.sunflower)
				{
					this.AddBuff(146, 2, false);
				}
				if (this.hasBanner)
				{
					this.AddBuff(147, 2, false);
				}
				if (!this.behindBackWall && this.ZoneSandstorm)
				{
					this.AddBuff(194, 2, false);
				}
			}
			for (int num25 = 0; num25 < Main.maxBuffTypes; num25++)
			{
				this.buffImmune[num25] = false;
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
			bool flag13 = this.wet && !this.lavaWet && (!this.mount.Active || this.mount.Type != 3);
			if (this.accMerman && flag13)
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
			if (!flag13 && this.forceWerewolf)
			{
				this.forceMerman = false;
			}
			if (this.forceMerman && flag13)
			{
				this.wings = 0;
			}
			this.accMerman = false;
			this.hideMerman = false;
			this.forceMerman = false;
			if (this.wolfAcc && !this.merman && !Main.dayTime && !this.wereWolf)
			{
				this.AddBuff(28, 60, true);
			}
			this.wolfAcc = false;
			this.hideWolf = false;
			this.forceWerewolf = false;
			if (this.whoAmI == Main.myPlayer)
			{
				for (int num26 = 0; num26 < 22; num26++)
				{
					if (this.buffType[num26] > 0 && this.buffTime[num26] <= 0)
					{
						this.DelBuff(num26);
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
				this.MountFishronSpecialCounter -= 1f;
			}
			if (this._portalPhysicsTime > 0)
			{
				this._portalPhysicsTime--;
			}
			this.UpdateEquips(i);
			if (this.velocity.Y == 0f || this.controlJump)
			{
				this.portalPhysicsFlag = false;
			}
			if (this.inventory[this.selectedItem].type == 3384 || this.portalPhysicsFlag)
			{
				this._portalPhysicsTime = 30;
			}
			if (this.mount.Active)
			{
				this.mount.UpdateEffects(this);
			}
			this.gemCount++;
			if (this.gemCount >= 10)
			{
				this.gem = -1;
				this.ownedLargeGems = 0;
				this.gemCount = 0;
				for (int num27 = 0; num27 <= 58; num27++)
				{
					if (this.inventory[num27].type == 0 || this.inventory[num27].stack == 0)
					{
						this.inventory[num27].type = 0;
						this.inventory[num27].stack = 0;
						this.inventory[num27].name = "";
						this.inventory[num27].netID = 0;
					}
					if (this.inventory[num27].type >= 1522 && this.inventory[num27].type <= 1527)
					{
						this.gem = this.inventory[num27].type - 1522;
						this.ownedLargeGems[this.gem] = true;
					}
					if (this.inventory[num27].type == 3643)
					{
						this.gem = 6;
						this.ownedLargeGems[this.gem] = true;
					}
				}
			}
			this.UpdateArmorSets(i);
			if (this.maxTurretsOld != this.maxTurrets)
			{
				this.UpdateMaxTurrets();
				this.maxTurretsOld = this.maxTurrets;
			}
			if (this.shieldRaised)
			{
				this.statDefense += 20;
			}
			if ((this.merman || this.forceMerman) && flag13)
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
						this.stealth += 0.1f;
					}
				}
				else if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1 && (double)this.velocity.Y > -0.1 && (double)this.velocity.Y < 0.1 && !this.mount.Active)
				{
					if (this.stealthTimer == 0 && this.stealth > 0f)
					{
						this.stealth -= 0.02f;
						if ((double)this.stealth <= 0.0)
						{
							this.stealth = 0f;
							if (Main.netMode == 1)
							{
								NetMessage.SendData(84, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
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
								NetMessage.SendData(84, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
							}
						}
					}
				}
				else
				{
					float num41 = Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y);
					this.stealth += num41 * 0.0075f;
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
				bool flag14 = false;
				if (this.vortexStealthActive)
				{
					float num42 = this.stealth;
					this.stealth -= 0.04f;
					if (this.stealth < 0f)
					{
						this.stealth = 0f;
					}
					else
					{
						flag14 = true;
					}
					if (this.stealth == 0f && num42 != this.stealth && Main.netMode == 1)
					{
						NetMessage.SendData(84, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
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
					float num43 = this.stealth;
					this.stealth += 0.04f;
					if (this.stealth > 1f)
					{
						this.stealth = 1f;
					}
					else
					{
						flag14 = true;
					}
					if (this.stealth == 1f && num43 != this.stealth && Main.netMode == 1)
					{
						NetMessage.SendData(84, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
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
			if (this.slowOgreSpit)
			{
				this.moveSpeed /= 3f;
				if (this.velocity.Y == 0f && Math.Abs(this.velocity.X) > 1f)
				{
					this.velocity.X = this.velocity.X / 2f;
				}
			}
			else if (this.dazed)
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
			if (this.shieldRaised)
			{
				this.moveSpeed /= 3f;
				if (this.velocity.Y == 0f && Math.Abs(this.velocity.X) > 3f)
				{
					this.velocity.X = this.velocity.X / 2f;
				}
			}
			if (DD2Event.Ongoing)
			{
				DD2Event.FindArenaHitbox();
				if (DD2Event.ShouldBlockBuilding(base.Center))
				{
					this.noBuilding = true;
					this.AddBuff(199, 3, true);
				}
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
			for (int num44 = 0; num44 < 22; num44++)
			{
				if (this.buffType[num44] > 0 && this.buffTime[num44] > 0 && this.buffImmune[this.buffType[num44]])
				{
					this.DelBuff(num44);
				}
			}
			if (this.brokenArmor)
			{
				this.statDefense /= 2;
			}
			if (this.witheredArmor)
			{
				this.statDefense /= 2;
			}
			if (this.witheredWeapon)
			{
				this.meleeDamage *= 0.5f;
				this.rangedDamage *= 0.5f;
				this.magicDamage *= 0.5f;
				this.minionDamage *= 0.5f;
				this.thrownDamage *= 0.5f;
			}
			this.lastTileRangeX = Player.tileRangeX;
			this.lastTileRangeY = Player.tileRangeY;
			if (this.mount.Active && this.mount.BlockExtraJumps)
			{
				this.jumpAgainCloud = false;
				this.jumpAgainSandstorm = false;
				this.jumpAgainBlizzard = false;
				this.jumpAgainFart = false;
				this.jumpAgainSail = false;
				this.jumpAgainUnicorn = false;
			}
			else
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
				int num45 = (int)(this.position.X + (float)(this.width / 2)) / 16;
				int num46 = (int)(this.position.Y - 8f) / 16;
				bool flag15 = false;
				if (this.pulleyDir == 0)
				{
					this.pulleyDir = 1;
				}
				if (this.pulleyDir == 1)
				{
					if (this.direction == -1 && this.controlLeft && (this.releaseLeft || this.leftTimer == 0))
					{
						this.pulleyDir = 2;
						flag15 = true;
					}
					else if ((this.direction == 1 && this.controlRight && this.releaseRight) || this.rightTimer == 0)
					{
						this.pulleyDir = 2;
						flag15 = true;
					}
					else
					{
						if (this.direction == 1 && this.controlLeft)
						{
							this.direction = -1;
							flag15 = true;
						}
						if (this.direction == -1 && this.controlRight)
						{
							this.direction = 1;
							flag15 = true;
						}
					}
				}
				else if (this.pulleyDir == 2)
				{
					if (this.direction == 1 && this.controlLeft)
					{
						flag15 = true;
						int num47 = num45 * 16 + 8 - this.width / 2;
						if (!Collision.SolidCollision(new Vector2((float)num47, this.position.Y), this.width, this.height))
						{
							this.pulleyDir = 1;
							this.direction = -1;
							flag15 = true;
						}
					}
					if (this.direction == -1 && this.controlRight)
					{
						flag15 = true;
						int num48 = num45 * 16 + 8 - this.width / 2;
						if (!Collision.SolidCollision(new Vector2((float)num48, this.position.Y), this.width, this.height))
						{
							this.pulleyDir = 1;
							this.direction = 1;
							flag15 = true;
						}
					}
				}
				bool flag16 = false;
				if (!flag15 && ((this.controlLeft && (this.releaseLeft || this.leftTimer == 0)) || (this.controlRight && (this.releaseRight || this.rightTimer == 0))))
				{
					int num49 = 1;
					if (this.controlLeft)
					{
						num49 = -1;
					}
					int num50 = num45 + num49;
					if (Main.tile[num50, num46].active() && Main.tileRope[(int)Main.tile[num50, num46].type])
					{
						this.pulleyDir = 1;
						this.direction = num49;
						int num51 = num50 * 16 + 8 - this.width / 2;
						float num52 = this.position.Y;
						num52 = (float)(num46 * 16 + 22);
						if ((!Main.tile[num50, num46 - 1].active() || !Main.tileRope[(int)Main.tile[num50, num46 - 1].type]) && (!Main.tile[num50, num46 + 1].active() || !Main.tileRope[(int)Main.tile[num50, num46 + 1].type]))
						{
							num52 = (float)(num46 * 16 + 22);
						}
						if (Collision.SolidCollision(new Vector2((float)num51, num52), this.width, this.height))
						{
							this.pulleyDir = 2;
							this.direction = -num49;
							if (this.direction == 1)
							{
								num51 = num50 * 16 + 8 - this.width / 2 + 6;
							}
							else
							{
								num51 = num50 * 16 + 8 - this.width / 2 + -6;
							}
						}
						if (i == Main.myPlayer)
						{
							Main.cameraX = Main.cameraX + this.position.X - (float)num51;
						}
						this.position.X = (float)num51;
						this.gfxOffY = this.position.Y - num52;
						this.position.Y = num52;
						flag16 = true;
					}
				}
				if (!flag16 && !flag15 && !this.controlUp && ((this.controlLeft && this.releaseLeft) || (this.controlRight && this.releaseRight)))
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
				if (Main.tile[num45, num46] == null)
				{
					Main.tile[num45, num46] = new Tile();
				}
				if (!Main.tile[num45, num46].active() || !Main.tileRope[(int)Main.tile[num45, num46].type])
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
				int num53 = (int)(this.position.X + (float)(this.width / 2)) / 16;
				int num54 = (int)(this.position.Y - 16f) / 16;
				int num55 = (int)(this.position.Y - 8f) / 16;
				bool flag17 = true;
				bool flag18 = false;
				if ((Main.tile[num53, num55 - 1].active() && Main.tileRope[(int)Main.tile[num53, num55 - 1].type]) || (Main.tile[num53, num55 + 1].active() && Main.tileRope[(int)Main.tile[num53, num55 + 1].type]))
				{
					flag18 = true;
				}
				if (Main.tile[num53, num54] == null)
				{
					Main.tile[num53, num54] = new Tile();
				}
				if (!Main.tile[num53, num54].active() || !Main.tileRope[(int)Main.tile[num53, num54].type])
				{
					flag17 = false;
					if (this.velocity.Y < 0f)
					{
						this.velocity.Y = 0f;
					}
				}
				if (flag18)
				{
					if (this.controlUp && flag17)
					{
						float num56 = this.position.X;
						float y3 = this.position.Y - Math.Abs(this.velocity.Y) - 2f;
						if (Collision.SolidCollision(new Vector2(num56, y3), this.width, this.height))
						{
							num56 = (float)(num53 * 16 + 8 - this.width / 2 + 6);
							if (!Collision.SolidCollision(new Vector2(num56, y3), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
							{
								if (i == Main.myPlayer)
								{
									Main.cameraX = Main.cameraX + this.position.X - num56;
								}
								this.pulleyDir = 2;
								this.direction = 1;
								this.position.X = num56;
								this.velocity.X = 0f;
							}
							else
							{
								num56 = (float)(num53 * 16 + 8 - this.width / 2 + -6);
								if (!Collision.SolidCollision(new Vector2(num56, y3), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
								{
									if (i == Main.myPlayer)
									{
										Main.cameraX = Main.cameraX + this.position.X - num56;
									}
									this.pulleyDir = 2;
									this.direction = -1;
									this.position.X = num56;
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
						float num57 = this.position.X;
						float y4 = this.position.Y;
						if (Collision.SolidCollision(new Vector2(num57, y4), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
						{
							num57 = (float)(num53 * 16 + 8 - this.width / 2 + 6);
							if (!Collision.SolidCollision(new Vector2(num57, y4), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
							{
								if (i == Main.myPlayer)
								{
									Main.cameraX = Main.cameraX + this.position.X - num57;
								}
								this.pulleyDir = 2;
								this.direction = 1;
								this.position.X = num57;
								this.velocity.X = 0f;
							}
							else
							{
								num57 = (float)(num53 * 16 + 8 - this.width / 2 + -6);
								if (!Collision.SolidCollision(new Vector2(num57, y4), this.width, (int)((float)this.height + Math.Abs(this.velocity.Y) + 2f)))
								{
									if (i == Main.myPlayer)
									{
										Main.cameraX = Main.cameraX + this.position.X - num57;
									}
									this.pulleyDir = 2;
									this.direction = -1;
									this.position.X = num57;
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
						if (this.velocity.Y > this.maxFallSpeed)
						{
							this.velocity.Y = this.maxFallSpeed;
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
					this.position.Y = (float)(num54 * 16 + 22);
				}
				float num58 = (float)(num53 * 16 + 8 - this.width / 2);
				if (this.pulleyDir == 1)
				{
					num58 = (float)(num53 * 16 + 8 - this.width / 2);
				}
				if (this.pulleyDir == 2)
				{
					num58 = (float)(num53 * 16 + 8 - this.width / 2 + 6 * this.direction);
				}
				if (i == Main.myPlayer)
				{
					Main.cameraX = Main.cameraX + this.position.X - num58;
				}
				this.position.X = num58;
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
				this.DashMovement();
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
						if (this.controlDown && this.controlJump && this.wingTime > 0f)
						{
							this.accRunSpeed = 10f;
							this.runAcceleration *= 10f;
						}
						else
						{
							this.accRunSpeed = 6.25f;
						}
					}
					if (this.wingsLogic == 30 || this.wingsLogic == 31)
					{
						if (this.controlDown && this.controlJump && this.wingTime > 0f)
						{
							this.accRunSpeed = 12f;
							this.runAcceleration *= 12f;
						}
						else
						{
							this.accRunSpeed = 6.5f;
							this.runAcceleration *= 1.5f;
						}
					}
					if (this.wingsLogic == 26)
					{
						this.accRunSpeed = 8f;
						this.runAcceleration *= 2f;
					}
					if (this.wingsLogic == 37)
					{
						if (this.controlDown && this.controlJump && this.wingTime > 0f)
						{
							this.accRunSpeed = 12f;
							this.runAcceleration *= 12f;
						}
						else
						{
							this.accRunSpeed = 6f;
							this.runAcceleration *= 2.5f;
						}
					}
					if (this.wingsLogic == 29 || this.wingsLogic == 32)
					{
						this.accRunSpeed = 9f;
						this.runAcceleration *= 2.5f;
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
					this.maxRunSpeed *= 0.25f;
					this.runAcceleration *= 0.25f;
					this.runSlowdown *= 2f;
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
					this.maxRunSpeed *= 3.5f;
					this.runAcceleration *= 1f;
					this.runSlowdown *= 2f;
				}
				else if (this.slippy2)
				{
					this.runAcceleration *= 0.6f;
					this.runSlowdown = 0f;
					if (this.iceSkate)
					{
						this.runAcceleration *= 3.5f;
						this.maxRunSpeed *= 1.25f;
					}
				}
				else if (this.slippy)
				{
					this.runAcceleration *= 0.7f;
					if (this.iceSkate)
					{
						this.runAcceleration *= 3.5f;
						this.maxRunSpeed *= 1.25f;
					}
					else
					{
						this.runSlowdown *= 0.1f;
					}
				}
				if (this.sandStorm)
				{
					this.runAcceleration *= 1.5f;
					this.maxRunSpeed *= 2f;
				}
				if (this.dJumpEffectBlizzard && this.doubleJumpBlizzard)
				{
					this.runAcceleration *= 3f;
					this.maxRunSpeed *= 1.5f;
				}
				if (this.dJumpEffectFart && this.doubleJumpFart)
				{
					this.runAcceleration *= 3f;
					this.maxRunSpeed *= 1.75f;
				}
				if (this.dJumpEffectUnicorn && this.doubleJumpUnicorn)
				{
					this.runAcceleration *= 3f;
					this.maxRunSpeed *= 1.5f;
				}
				if (this.dJumpEffectSail && this.doubleJumpSail)
				{
					this.runAcceleration *= 1.5f;
					this.maxRunSpeed *= 1.25f;
				}
				if (this.carpetFrame != -1)
				{
					this.runAcceleration *= 1.25f;
					this.maxRunSpeed *= 1.5f;
				}
				if (this.inventory[this.selectedItem].type == 3106 && this.stealth < 1f)
				{
					float num59 = this.maxRunSpeed / 2f * (1f - this.stealth);
					this.maxRunSpeed -= num59;
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
						this.runAcceleration /= 2f;
						this.maxRunSpeed /= 2f;
					}
					this.mount.AbilityRecovery();
					if (this.mount.Cart && this.velocity.Y == 0f)
					{
						if (!Minecart.OnTrack(this.position, this.width, this.height))
						{
							this.fullRotation = 0f;
							this.onWrongGround = true;
							this.runSlowdown = 0.2f;
							if ((this.controlLeft && this.releaseLeft) || (this.controlRight && this.releaseRight))
							{
								this.mount.Dismount(this);
							}
						}
						else
						{
							this.runSlowdown = this.runAcceleration;
							this.onWrongGround = false;
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
						if (this.gravDir == 1f)
						{
							this.gravDir = -1f;
							this.fallStart = (int)(this.position.Y / 16f);
							this.jump = 0;
						}
						else
						{
							this.gravDir = 1f;
							this.fallStart = (int)(this.position.Y / 16f);
							this.jump = 0;
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
						}
						else
						{
							this.gravDir = 1f;
							this.fallStart = (int)(this.position.Y / 16f);
							this.jump = 0;
						}
					}
				}
				else
				{
					this.gravDir = 1f;
				}
				if (this.velocity.Y == 0f && this.mount.Active && this.mount.CanHover && this.controlUp && this.releaseUp)
				{
					this.velocity.Y = -(this.mount.Acceleration + this.gravity + 0.001f);
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
				this.DoubleJumpVisuals();
				if (this.wings > 0 || this.mount.Active)
				{
					this.sandStorm = false;
				}
				if (((this.gravDir == 1f && this.velocity.Y > -Player.jumpSpeed) || (this.gravDir == -1f && this.velocity.Y < Player.jumpSpeed)) && this.velocity.Y != 0f)
				{
					this.canRocket = true;
				}
				bool flag19 = false;
				if (((this.velocity.Y == 0f || this.sliding) && this.releaseJump) || (this.autoJump && this.justJumped))
				{
					this.mount.ResetFlightTime(this.velocity.X);
					this.wingTime = (float)this.wingTimeMax;
				}
				if (this.wingsLogic > 0 && this.controlJump && this.wingTime > 0f && !this.jumpAgainCloud && this.jump == 0 && this.velocity.Y != 0f)
				{
					flag19 = true;
				}
				if ((this.wingsLogic == 22 || this.wingsLogic == 28 || this.wingsLogic == 30 || this.wingsLogic == 32 || this.wingsLogic == 29 || this.wingsLogic == 33 || this.wingsLogic == 35 || this.wingsLogic == 37) && this.controlJump && this.controlDown && this.wingTime > 0f)
				{
					flag19 = true;
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
					if (flag19)
					{
						this.WingMovement();
					}
					if (this.wings == 4)
					{
						if (flag19 || this.jump > 0)
						{
							this.rocketDelay2--;
							if (this.rocketDelay2 <= 0)
							{
								this.rocketDelay2 = 60;
							}
							int num80 = 2;
							if (this.controlUp)
							{
								num80 = 4;
							}
							for (int num81 = 0; num81 < num80; num81++)
							{
								int type = 6;
								if (this.head == 41)
								{
									int arg_59F8_0 = this.body;
								}
								float scale = 1.75f;
								int alpha = 100;
								float x3 = this.position.X + (float)(this.width / 2) + 16f;
								if (this.direction > 0)
								{
									x3 = this.position.X + (float)(this.width / 2) - 26f;
								}
								float num82 = this.position.Y + (float)this.height - 18f;
								if (num81 == 1 || num81 == 3)
								{
									x3 = this.position.X + (float)(this.width / 2) + 8f;
									if (this.direction > 0)
									{
										x3 = this.position.X + (float)(this.width / 2) - 20f;
									}
									num82 += 6f;
								}
								if (num81 > 1)
								{
									num82 += this.velocity.Y;
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
									int num84 = 2;
									if (this.wingFrameCounter < num84)
									{
										this.wingFrame = 1;
									}
									else if (this.wingFrameCounter < num84 * 2)
									{
										this.wingFrame = 2;
									}
									else if (this.wingFrameCounter < num84 * 3)
									{
										this.wingFrame = 3;
									}
									else if (this.wingFrameCounter < num84 * 4 - 1)
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
									int num85 = 6;
									if (this.wingFrameCounter < num85)
									{
										this.wingFrame = 4;
									}
									else if (this.wingFrameCounter < num85 * 2)
									{
										this.wingFrame = 5;
									}
									else if (this.wingFrameCounter < num85 * 3 - 1)
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
								int num86 = 2;
								if (this.wingFrameCounter < num86)
								{
									this.wingFrame = 4;
								}
								else if (this.wingFrameCounter < num86 * 2)
								{
									this.wingFrame = 5;
								}
								else if (this.wingFrameCounter < num86 * 3)
								{
									this.wingFrame = 6;
								}
								else if (this.wingFrameCounter < num86 * 4 - 1)
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
							int num87 = 6;
							if (this.wingFrameCounter < num87)
							{
								this.wingFrame = 4;
							}
							else if (this.wingFrameCounter < num87 * 2)
							{
								this.wingFrame = 5;
							}
							else if (this.wingFrameCounter < num87 * 3 - 1)
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
						if (flag19 || this.jump > 0)
						{
							this.wingFrameCounter++;
							int num88 = 5;
							if (this.wingFrameCounter < num88)
							{
								this.wingFrame = 1;
							}
							else if (this.wingFrameCounter < num88 * 2)
							{
								this.wingFrame = 2;
							}
							else if (this.wingFrameCounter < num88 * 3)
							{
								this.wingFrame = 3;
							}
							else if (this.wingFrameCounter < num88 * 4 - 1)
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
						if (flag19 || this.jump > 0)
						{
							this.wingFrameCounter++;
							int num89 = 1;
							if (this.wingFrameCounter < num89)
							{
								this.wingFrame = 1;
							}
							else if (this.wingFrameCounter < num89 * 2)
							{
								this.wingFrame = 2;
							}
							else if (this.wingFrameCounter < num89 * 3)
							{
								this.wingFrame = 3;
							}
							else
							{
								this.wingFrame = 2;
								if (this.wingFrameCounter >= num89 * 4 - 1)
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
								int num90 = 3;
								if (this.wingFrameCounter < num90)
								{
									this.wingFrame = 1;
								}
								else if (this.wingFrameCounter < num90 * 2)
								{
									this.wingFrame = 2;
								}
								else if (this.wingFrameCounter < num90 * 3)
								{
									this.wingFrame = 3;
								}
								else
								{
									this.wingFrame = 2;
									if (this.wingFrameCounter >= num90 * 4 - 1)
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
					else if (this.wings == 30)
					{
						bool flag20 = false;
						if (flag19 || this.jump > 0)
						{
							this.wingFrameCounter++;
							int num91 = 2;
							if (this.wingFrameCounter >= num91 * 3)
							{
								this.wingFrameCounter = 0;
							}
							this.wingFrame = 1 + this.wingFrameCounter / num91;
							flag20 = true;
						}
						else if (this.velocity.Y != 0f)
						{
							if (this.controlJump)
							{
								this.wingFrameCounter++;
								int num92 = 2;
								if (this.wingFrameCounter >= num92 * 3)
								{
									this.wingFrameCounter = 0;
								}
								this.wingFrame = 1 + this.wingFrameCounter / num92;
								flag20 = true;
							}
							else if (this.wingTime == 0f)
							{
								this.wingFrame = 0;
							}
							else
							{
								this.wingFrame = 0;
							}
						}
						else
						{
							this.wingFrame = 0;
						}
					}
					else if (this.wings == 34)
					{
						if (flag19 || this.jump > 0)
						{
							this.wingFrameCounter++;
							int num95 = 4;
							if (this.wingFrameCounter >= num95 * 6)
							{
								this.wingFrameCounter = 0;
							}
							this.wingFrame = this.wingFrameCounter / num95;
						}
						else if (this.velocity.Y != 0f)
						{
							if (this.controlJump)
							{
								this.wingFrameCounter++;
								int num96 = 9;
								if (this.wingFrameCounter >= num96 * 6)
								{
									this.wingFrameCounter = 0;
								}
								this.wingFrame = this.wingFrameCounter / num96;
							}
							else
							{
								this.wingFrameCounter++;
								int num97 = 6;
								if (this.wingFrameCounter >= num97 * 6)
								{
									this.wingFrameCounter = 0;
								}
								this.wingFrame = this.wingFrameCounter / num97;
							}
						}
						else
						{
							this.wingFrameCounter++;
							int num98 = 4;
							if (this.wingFrameCounter >= num98 * 6)
							{
								this.wingFrameCounter = 0;
							}
							this.wingFrame = this.wingFrameCounter / num98;
						}
					}
					else
					{
						int num102 = 4;
						if (this.wings == 32)
						{
							num102 = 3;
						}
						if (flag19 || this.jump > 0)
						{
							this.wingFrameCounter++;
							if (this.wingFrameCounter > num102)
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
							if (this.wings == 32)
							{
								this.wingFrame = 3;
							}
						}
						else
						{
							this.wingFrame = 0;
						}
					}
					if (this.wingsLogic > 0 && this.rocketBoots > 0 && this.velocity.Y != 0f)
					{
						int num105 = 6;
						this.wingTime += (float)(this.rocketTime * num105);
						if (this.wingTime > (float)(this.wingTimeMax + this.rocketTimeMax * num105))
						{
							this.wingTime = (float)(this.wingTimeMax + this.rocketTimeMax * num105);
						}
						this.rocketTime = 0;
					}
					if (this.velocity.Y == 0f || this.sliding || (this.autoJump && this.justJumped))
					{
						this.rocketTime = this.rocketTimeMax;
					}
					if ((this.wingTime == 0f || this.wingsLogic == 0) && this.rocketBoots > 0 && this.controlJump && this.rocketDelay == 0 && this.canRocket && this.rocketRelease && !this.jumpAgainCloud)
					{
						if (this.rocketTime > 0)
						{
							this.rocketTime--;
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
						int num106 = this.height;
						if (this.gravDir == -1f)
						{
							num106 = 4;
						}
						this.rocketFrame = true;
						for (int num107 = 0; num107 < 2; num107++)
						{
							int type2 = 6;
							float scale2 = 2.5f;
							int alpha2 = 100;
							if (this.rocketBoots == 2)
							{
								type2 = 16;
								scale2 = 1.5f;
								alpha2 = 20;
							}
							else if (this.rocketBoots == 3)
							{
								type2 = 76;
								scale2 = 1f;
								alpha2 = 20;
							}
							else if (this.socialShadow)
							{
								type2 = 27;
								scale2 = 1.5f;
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
					else if (!flag19)
					{
						if (this.mount.CanHover)
						{
							this.mount.Hover(this);
						}
						else if (this.mount.CanFly && this.controlJump && this.jump == 0)
						{
							if (this.mount.Flight())
							{
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
						}
						else if (this.slowFall && ((!this.controlDown && this.gravDir == 1f) || (!this.controlDown && this.gravDir == -1f)))
						{
							if ((this.controlUp && this.gravDir == 1f) || (this.controlUp && this.gravDir == -1f))
							{
								this.gravity = this.gravity / 10f * this.gravDir;
							}
							else
							{
								this.gravity = this.gravity / 3f * this.gravDir;
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
									this.rocketDelay2--;
									if (this.rocketDelay2 <= 0)
									{
										this.rocketDelay2 = 60;
									}
									int type3 = 6;
									float scale3 = 1.5f;
									int alpha3 = 100;
									float x4 = this.position.X + (float)(this.width / 2) + 16f;
									if (this.direction > 0)
									{
										x4 = this.position.X + (float)(this.width / 2) - 26f;
									}
									float num122 = this.position.Y + (float)this.height - 18f;
									if (Main.rand.Next(2) == 1)
									{
										x4 = this.position.X + (float)(this.width / 2) + 8f;
										if (this.direction > 0)
										{
											x4 = this.position.X + (float)(this.width / 2) - 20f;
										}
										num122 += 6f;
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
								else if (this.wings != 22 && this.wings != 28)
								{
									if (this.wings == 30)
									{
										this.wingFrameCounter++;
										int num124 = 5;
										if (this.wingFrameCounter >= num124 * 3)
										{
											this.wingFrameCounter = 0;
										}
										this.wingFrame = 1 + this.wingFrameCounter / num124;
									}
									else if (this.wings == 34)
									{
										this.wingFrameCounter++;
										int num125 = 7;
										if (this.wingFrameCounter >= num125 * 6)
										{
											this.wingFrameCounter = 0;
										}
										this.wingFrame = this.wingFrameCounter / num125;
									}
									else if (this.wings == 26)
									{
										this.wingFrame = 2;
									}
									else if (this.wings != 24)
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
						else if (this.cartRampTime <= 0)
						{
							this.velocity.Y = this.velocity.Y + this.gravity * this.gravDir;
						}
						else
						{
							this.cartRampTime--;
						}
					}
					if (!this.mount.Active || this.mount.Type != 5)
					{
						if (this.gravDir == 1f)
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
						else
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
					}
				}
			}
			if (this.mount.Active)
			{
				this.wingFrame = 0;
			}
			if ((this.wingsLogic == 22 || this.wingsLogic == 28 || this.wingsLogic == 30 || this.wingsLogic == 31 || this.wingsLogic == 33 || this.wingsLogic == 35) && this.controlDown && this.controlJump && this.wingTime > 0f && !this.merman)
			{
				this.velocity.Y = this.velocity.Y * 0.9f;
				if (this.velocity.Y > -2f && this.velocity.Y < 1f)
				{
					this.velocity.Y = 1E-05f;
				}
			}
			if (this.wingsLogic == 37 && this.controlDown && this.controlJump && this.wingTime > 0f && !this.merman)
			{
				this.velocity.Y = this.velocity.Y * 0.92f;
				if (this.velocity.Y > -2f && this.velocity.Y < 1f)
				{
					this.velocity.Y = 1E-05f;
				}
			}
			this.GrabItems(i);
			if (!Main.mapFullscreen)
			{
				int smartInteractX = Player.tileTargetX;
				int smartInteractY = Player.tileTargetY;
				if (this.position.X / 16f - (float)Player.tileRangeX <= (float)smartInteractX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX - 1f >= (float)smartInteractX && this.position.Y / 16f - (float)Player.tileRangeY <= (float)smartInteractY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY - 2f >= (float)smartInteractY)
				{
					this.TileInteractionsCheckLongDistance(Player.tileTargetX, Player.tileTargetY);
					this.TileInteractionsCheck(smartInteractX, smartInteractY);
				}
				else
				{
					this.TileInteractionsCheckLongDistance(smartInteractX, smartInteractY);
				}
			}
			if (this.tongued)
			{
				bool flag22 = false;
				if (Main.wof >= 0)
				{
					float num129 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2);
					num129 += (float)(Main.npc[Main.wof].direction * 200);
					float num130 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2);
					Vector2 center = base.Center;
					float num131 = num129 - center.X;
					float num132 = num130 - center.Y;
					float num133 = (float)Math.Sqrt((double)(num131 * num131 + num132 * num132));
					float num134 = 11f;
					float num135;
					if (num133 > num134)
					{
						num135 = num134 / num133;
					}
					else
					{
						num135 = 1f;
						flag22 = true;
					}
					num131 *= num135;
					num132 *= num135;
					this.velocity.X = num131;
					this.velocity.Y = num132;
				}
				else
				{
					flag22 = true;
				}
				if (flag22 && Main.myPlayer == this.whoAmI)
				{
					for (int num136 = 0; num136 < 22; num136++)
					{
						if (this.buffType[num136] == 38)
						{
							this.DelBuff(num136);
						}
					}
				}
			}
			if (Main.myPlayer == this.whoAmI)
			{
				this.WOFTongue();
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
					Rectangle value3 = new Rectangle((int)Main.npc[this.talkNPC].position.X, (int)Main.npc[this.talkNPC].position.Y, Main.npc[this.talkNPC].width, Main.npc[this.talkNPC].height);
					if (!rectangle.Intersects(value3) || this.chest != -1 || !Main.npc[this.talkNPC].active)
					{
						this.talkNPC = -1;
						Main.npcChatCornerItem = 0;
						Main.npcChatText = "";
					}
				}
				if (this.sign >= 0)
				{
					Rectangle value4 = new Rectangle((int)(this.position.X + (float)(this.width / 2) - (float)(Player.tileRangeX * 16)), (int)(this.position.Y + (float)(this.height / 2) - (float)(Player.tileRangeY * 16)), Player.tileRangeX * 16 * 2, Player.tileRangeY * 16 * 2);
					try
					{
						bool flag23 = false;
						if (Main.sign[this.sign] == null)
						{
							flag23 = true;
						}
						if (!flag23 && !new Rectangle(Main.sign[this.sign].x * 16, Main.sign[this.sign].y * 16, 32, 32).Intersects(value4))
						{
							flag23 = true;
						}
						if (flag23)
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
				if (this.mount.Active && this.mount.Cart && Math.Abs(this.velocity.X) > 4f)
				{
					Rectangle rectangle2 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
					for (int num137 = 0; num137 < 200; num137++)
					{
						if (Main.npc[num137].active && !Main.npc[num137].dontTakeDamage && !Main.npc[num137].friendly && Main.npc[num137].immune[i] == 0 && rectangle2.Intersects(new Rectangle((int)Main.npc[num137].position.X, (int)Main.npc[num137].position.Y, Main.npc[num137].width, Main.npc[num137].height)))
						{
							float num138 = (float)this.meleeCrit;
							if (num138 < (float)this.rangedCrit)
							{
								num138 = (float)this.rangedCrit;
							}
							if (num138 < (float)this.magicCrit)
							{
								num138 = (float)this.magicCrit;
							}
							bool crit = false;
							if ((float)Main.rand.Next(1, 101) <= num138)
							{
								crit = true;
							}
							float num139 = Math.Abs(this.velocity.X) / this.maxRunSpeed;
							int damage2 = Main.DamageVar(25f + 55f * num139);
							if (this.mount.Type == 11)
							{
								damage2 = Main.DamageVar(50f + 100f * num139);
							}
							if (this.mount.Type == 13)
							{
								damage2 = Main.DamageVar(15f + 30f * num139);
							}
							float knockback = 5f + 25f * num139;
							int direction = 1;
							if (this.velocity.X < 0f)
							{
								direction = -1;
							}
							if (this.whoAmI == Main.myPlayer)
							{
								this.ApplyDamageToNPC(Main.npc[num137], damage2, knockback, direction, crit);
							}
							Main.npc[num137].immune[i] = 30;
							if (!Main.npc[num137].active)
							{
								AchievementsHelper.HandleSpecialEvent(this, 9);
							}
						}
					}
				}
				Rectangle rectangle3 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
				for (int num140 = 0; num140 < 200; num140++)
				{
					if (Main.npc[num140].active && !Main.npc[num140].friendly && Main.npc[num140].damage > 0)
					{
						int num141 = -1;
						int type4 = Main.npc[num140].type;
						if (type4 == 398 || type4 == 400 || type4 == 397 || type4 == 396 || type4 == 401)
						{
							num141 = 1;
						}
						if ((num141 != -1 || !this.immune) && (this.dash != 2 || num140 != this.eocHit || this.eocDash <= 0) && !this.npcTypeNoAggro[Main.npc[num140].type])
						{
							float num142 = 1f;
							Rectangle value5 = new Rectangle((int)Main.npc[num140].position.X, (int)Main.npc[num140].position.Y, Main.npc[num140].width, Main.npc[num140].height);
							if (Main.npc[num140].type >= 430 && Main.npc[num140].type <= 436 && Main.npc[num140].ai[2] > 5f)
							{
								int num143 = 34;
								if (Main.npc[num140].spriteDirection < 0)
								{
									value5.X -= num143;
									value5.Width += num143;
								}
								else
								{
									value5.Width += num143;
								}
								num142 *= 1.25f;
							}
							else if (Main.npc[num140].type >= 494 && Main.npc[num140].type <= 495 && Main.npc[num140].ai[2] > 5f)
							{
								int num144 = 18;
								if (Main.npc[num140].spriteDirection < 0)
								{
									value5.X -= num144;
									value5.Width += num144;
								}
								else
								{
									value5.Width += num144;
								}
								num142 *= 1.25f;
							}
							else if (Main.npc[num140].type == 460)
							{
								Rectangle rectangle4 = new Rectangle(0, 0, 30, 14);
								rectangle4.X = (int)Main.npc[num140].Center.X;
								if (Main.npc[num140].direction < 0)
								{
									rectangle4.X -= rectangle4.Width;
								}
								rectangle4.Y = (int)Main.npc[num140].position.Y + Main.npc[num140].height - 20;
								if (rectangle3.Intersects(rectangle4))
								{
									value5 = rectangle4;
									num142 *= 1.35f;
								}
							}
							else if (Main.npc[num140].type == 417 && Main.npc[num140].ai[0] == 6f && Main.npc[num140].ai[3] > 0f && Main.npc[num140].ai[3] < 4f)
							{
								Rectangle rectangle5 = Utils.CenteredRectangle(Main.npc[num140].Center, new Vector2(100f));
								if (rectangle3.Intersects(rectangle5))
								{
									value5 = rectangle5;
									num142 *= 1.35f;
								}
							}
							else if (Main.npc[num140].type == 466)
							{
								Rectangle rectangle6 = new Rectangle(0, 0, 30, 8);
								rectangle6.X = (int)Main.npc[num140].Center.X;
								if (Main.npc[num140].direction < 0)
								{
									rectangle6.X -= rectangle6.Width;
								}
								rectangle6.Y = (int)Main.npc[num140].position.Y + Main.npc[num140].height - 32;
								if (rectangle3.Intersects(rectangle6))
								{
									value5 = rectangle6;
									num142 *= 1.75f;
								}
							}
							if (rectangle3.Intersects(value5) && !this.npcTypeNoAggro[Main.npc[num140].type])
							{
								int num145 = -1;
								if (Main.npc[num140].position.X + (float)(Main.npc[num140].width / 2) < this.position.X + (float)(this.width / 2))
								{
									num145 = 1;
								}
								int num146 = Main.DamageVar((float)Main.npc[num140].damage * num142);
								int num147 = Item.NPCtoBanner(Main.npc[num140].BannerID());
								if (num147 > 0 && this.NPCBannerBuff[num147])
								{
									if (Main.expertMode)
									{
										num146 = (int)((double)num146 * 0.5);
									}
									else
									{
										num146 = (int)((double)num146 * 0.75);
									}
								}
								if (this.whoAmI == Main.myPlayer && this.thorns > 0f && !this.immune && !Main.npc[num140].dontTakeDamage)
								{
									int damage3 = (int)((float)num146 * this.thorns);
									int num148 = 10;
									if (this.turtleThorns)
									{
										damage3 = num146;
									}
									this.ApplyDamageToNPC(Main.npc[num140], damage3, (float)num148, -num145, false);
								}
								if (this.resistCold && Main.npc[num140].coldDamage)
								{
									num146 = (int)((float)num146 * 0.7f);
								}
								if (!this.immune)
								{
									this.StatusPlayer(Main.npc[num140]);
								}
								this.Hurt(num146, num145, false, false, Lang.deathMsg(-1, num140, -1, -1), false, num141);
							}
						}
					}
				}
				this.Update_NPCCollision();
				Vector2 vector3;
				if (!this.mount.Active || !this.mount.Cart)
				{
					vector3 = Collision.HurtTiles(this.position, this.velocity, this.width, this.height, this.fireWalk);
				}
				else
				{
					vector3 = Collision.HurtTiles(this.position, this.velocity, this.width, this.height - 16, this.fireWalk);
				}
				if (vector3.Y == 0f && !this.fireWalk)
				{
					foreach (Point current in this.TouchedTiles)
					{
						Tile tile = Main.tile[current.X, current.Y];
						if (tile != null && tile.active() && tile.nactive() && !this.fireWalk && TileID.Sets.TouchDamageHot[(int)tile.type] != 0)
						{
							vector3.Y = (float)TileID.Sets.TouchDamageHot[(int)tile.type];
							vector3.X = (float)((base.Center.X / 16f < (float)current.X + 0.5f) ? -1 : 1);
							break;
						}
					}
				}
				if (vector3.Y == 20f)
				{
					this.AddBuff(67, 20, true);
				}
				else if (vector3.Y == 15f)
				{
					if (this.suffocateDelay < 5)
					{
						this.suffocateDelay += 1;
					}
					else
					{
						this.AddBuff(68, 1, true);
					}
				}
				else if (vector3.Y != 0f)
				{
					int damage4 = Main.DamageVar(vector3.Y);
					this.Hurt(damage4, 0, false, false, Lang.deathMsg(-1, -1, -1, 3), false, 0);
				}
				else
				{
					this.suffocateDelay = 0;
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
			this.releaseDown = !this.controlDown;
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
			this.GrappleMovement();
			this.StickyMovement();
			this.CheckDrowning();
			if (this.gravDir == -1f)
			{
				this.waterWalk = false;
				this.waterWalk2 = false;
			}
			int num149 = this.height;
			if (this.waterWalk)
			{
				num149 -= 6;
			}
			bool flag24 = Collision.LavaCollision(this.position, this.width, num149);
			if (flag24)
			{
				if (!this.lavaImmune && Main.myPlayer == i && !this.immune)
				{
					if (this.lavaTime > 0)
					{
						this.lavaTime--;
					}
					else if (this.lavaRose)
					{
						this.Hurt(50, 0, false, false, Lang.deathMsg(-1, -1, -1, 2), false, -1);
						this.AddBuff(24, 210, true);
					}
					else
					{
						this.Hurt(80, 0, false, false, Lang.deathMsg(-1, -1, -1, 2), false, -1);
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
				num149 -= 6;
			}
			bool flag25 = Collision.WetCollision(this.position, this.width, this.height);
			bool flag26 = Collision.honey;
			if (flag26)
			{
				this.AddBuff(48, 1800, true);
				this.honeyWet = true;
			}
			if (flag25)
			{
				if (this.onFire && !this.lavaWet)
				{
					for (int num150 = 0; num150 < 22; num150++)
					{
						if (this.buffType[num150] == 24)
						{
							this.DelBuff(num150);
						}
					}
				}
				if (!this.wet)
				{
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
			if (!flag26)
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
				this.wetCount -= 1;
			}
			if (this.wetSlime > 0)
			{
				this.wetSlime -= 1;
			}
			if (this.wet && this.mount.Active)
			{
				switch (this.mount.Type)
				{
				case 3:
					this.wetSlime = 30;
					if (this.velocity.Y > 2f)
					{
						this.velocity.Y = this.velocity.Y * 0.9f;
					}
					this.velocity.Y = this.velocity.Y - 0.5f;
					if (this.velocity.Y < -4f)
					{
						this.velocity.Y = -4f;
					}
					break;
				case 5:
				case 7:
					if (this.whoAmI == Main.myPlayer)
					{
						this.mount.Dismount(this);
					}
					break;
				}
			}
			if (Main.expertMode && this.ZoneSnow && this.wet && !this.lavaWet && !this.honeyWet && !this.arcticDivingGear)
			{
				this.AddBuff(46, 150, true);
			}
			float num163 = 1f + Math.Abs(this.velocity.X) / 3f;
			if (this.gfxOffY > 0f)
			{
				this.gfxOffY -= num163 * this.stepSpeed;
				if (this.gfxOffY < 0f)
				{
					this.gfxOffY = 0f;
				}
			}
			else if (this.gfxOffY < 0f)
			{
				this.gfxOffY += num163 * this.stepSpeed;
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
			bool flag27 = this.mount.Type == 7 || this.mount.Type == 8 || this.mount.Type == 12;
			if (this.velocity.Y == this.gravity && (!this.mount.Active || (!this.mount.Cart && !flag27)))
			{
				Collision.StepDown(ref this.position, ref this.velocity, this.width, this.height, ref this.stepSpeed, ref this.gfxOffY, (int)this.gravDir, this.waterWalk || this.waterWalk2);
			}
			if (this.gravDir == -1f)
			{
				if ((this.carpetFrame != -1 || this.velocity.Y <= this.gravity) && !this.controlUp)
				{
					Collision.StepUp(ref this.position, ref this.velocity, this.width, this.height, ref this.stepSpeed, ref this.gfxOffY, (int)this.gravDir, this.controlUp, 0);
				}
			}
			else if (flag27 || ((this.carpetFrame != -1 || this.velocity.Y >= this.gravity) && !this.controlDown && !this.mount.Cart))
			{
				Collision.StepUp(ref this.position, ref this.velocity, this.width, this.height, ref this.stepSpeed, ref this.gfxOffY, (int)this.gravDir, this.controlUp, 0);
			}
			this.oldPosition = this.position;
			this.oldDirection = this.direction;
			bool falling = false;
			if (this.velocity.Y > this.gravity)
			{
				falling = true;
			}
			if (this.velocity.Y < -this.gravity)
			{
				falling = true;
			}
			Vector2 velocity = this.velocity;
			this.slideDir = 0;
			bool ignorePlats = false;
			bool fallThrough = this.controlDown;
			if (this.gravDir == -1f || (this.mount.Active && this.mount.Cart) || this.GoingDownWithGrapple)
			{
				ignorePlats = true;
				fallThrough = true;
			}
			this.onTrack = false;
			bool flag28 = false;
			if (this.mount.Active && this.mount.Cart)
			{
				float num164;
				if (!this.ignoreWater && !this.merman)
				{
					if (this.honeyWet)
					{
						num164 = 0.25f;
					}
					else if (this.wet)
					{
						num164 = 0.5f;
					}
					else
					{
						num164 = 1f;
					}
				}
				else
				{
					num164 = 1f;
				}
				this.velocity *= num164;
				DelegateMethods.Minecart.rotation = this.fullRotation;
				DelegateMethods.Minecart.rotationOrigin = this.fullRotationOrigin;
			}
			bool flag29 = this.whoAmI == Main.myPlayer && !this.mount.Active;
			Vector2 position = this.position;
			if (this.vortexDebuff)
			{
				this.velocity.Y = this.velocity.Y * 0.8f + (float)Math.Cos((double)(base.Center.X % 120f / 120f * 6.28318548f)) * 5f * 0.2f;
			}
			if (this.tongued)
			{
				this.position += this.velocity;
				flag29 = false;
			}
			else if (this.honeyWet && !this.ignoreWater)
			{
				this.HoneyCollision(fallThrough, ignorePlats);
			}
			else if (this.wet && !this.merman && !this.ignoreWater)
			{
				this.WaterCollision(fallThrough, ignorePlats);
			}
			else
			{
				this.DryCollision(fallThrough, ignorePlats);
				if (this.mount.Active && this.mount.Type == 3 && this.velocity.Y != 0f && !this.SlimeDontHyperJump)
				{
					Vector2 velocity2 = this.velocity;
					this.velocity.X = 0f;
					this.DryCollision(fallThrough, ignorePlats);
					this.velocity.X = velocity2.X;
				}
			}
			this.UpdateTouchingTiles();
			this.TryBouncingBlocks(falling);
			this.TryLandingOnDetonator();
			this.SlopingCollision(fallThrough);
			Collision.StepConveyorBelt(this, this.gravDir);
			if (flag29 && this.velocity.Y == 0f)
			{
				AchievementsHelper.HandleRunning(Math.Abs(this.position.X - position.X));
			}
			if (flag28)
			{
				NetMessage.SendData(13, -1, -1, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
				Minecart.HitTrackSwitch(new Vector2(this.position.X, this.position.Y), this.width, this.height);
			}
			if (velocity.X != this.velocity.X)
			{
				if (velocity.X < 0f)
				{
					this.slideDir = -1;
				}
				else if (velocity.X > 0f)
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
				this.FloorVisuals(falling);
			}
			//Collision.SwitchTiles(this.position, this.width, this.height, this.oldPosition, 1);
			PressurePlateHelper.UpdatePlayerPosition(this);
			this.BordersMovement();
			this.numMinions = 0;
			this.slotsMinions = 0f;
			if (!this.controlUseItem && this.altFunctionUse == 1)
			{
				this.altFunctionUse = 0;
			}
			this.ItemCheckWrapped(i);
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
		private void Update_NPCCollision()
		{
			Rectangle rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && !Main.npc[i].friendly && Main.npc[i].damage > 0)
				{
					int num = -1;
					int type = Main.npc[i].type;
					if (type == 398 || type == 400 || type == 397 || type == 396 || type == 401)
					{
						num = 1;
					}
					if ((num != -1 || !this.immune) && (this.dash != 2 || i != this.eocHit || this.eocDash <= 0) && !this.npcTypeNoAggro[Main.npc[i].type])
					{
						float num2 = 1f;
						Rectangle rectangle2 = new Rectangle((int)Main.npc[i].position.X, (int)Main.npc[i].position.Y, Main.npc[i].width, Main.npc[i].height);
						NPC.GetMeleeCollisionData(rectangle, i, ref num, ref num2, ref rectangle2);
						if (rectangle.Intersects(rectangle2) && !this.npcTypeNoAggro[Main.npc[i].type])
						{
							bool flag = true;
							bool flag2 = false;
							bool flag3 = this.CanParryAgainst(rectangle, rectangle2, Main.npc[i].velocity);
							float num3 = this.thorns;
							float knockback = 10f;
							if (this.turtleThorns)
							{
								num3 = 1f;
							}
							if (flag3)
							{
								num3 = 2f;
								knockback = 5f;
								flag = false;
								flag2 = true;
							}
							int num4 = -1;
							if (Main.npc[i].position.X + (float)(Main.npc[i].width / 2) < this.position.X + (float)(this.width / 2))
							{
								num4 = 1;
							}
							int num5 = Main.DamageVar((float)Main.npc[i].damage * num2);
							int num6 = Item.NPCtoBanner(Main.npc[i].BannerID());
							if (num6 > 0 && this.NPCBannerBuff[num6])
							{
								if (Main.expertMode)
								{
									num5 = (int)((float)num5 * ItemID.Sets.BannerStrength[Item.BannerToItem(num6)].ExpertDamageReceived);
								}
								else
								{
									num5 = (int)((float)num5 * ItemID.Sets.BannerStrength[Item.BannerToItem(num6)].NormalDamageReceived);
								}
							}
							if (this.whoAmI == Main.myPlayer && num3 > 0f && !this.immune && !Main.npc[i].dontTakeDamage)
							{
								int damage = (int)((float)num5 * num3);
								this.ApplyDamageToNPC(Main.npc[i], damage, knockback, -num4, false);
							}
							if (this.resistCold && Main.npc[i].coldDamage)
							{
								num5 = (int)((float)num5 * 0.7f);
							}
							if (!this.immune && !flag2)
							{
								this.StatusPlayer(Main.npc[i]);
							}
							if (flag)
							{
								this.Hurt(num5, num4, false, false, Lang.deathMsg(-1, i, -1, -1, 0, 0), false, num);
							}
							if (flag3)
							{
								this.immune = true;
								this.immuneNoBlink = true;
								this.immuneTime = 30;
								if (this.longInvince)
								{
									this.immuneTime = 60;
								}
								this.AddBuff(198, 300, false);
							}
						}
					}
				}
			}
		}
		public bool CanParryAgainst(Rectangle blockingPlayerRect, Rectangle enemyRect, Vector2 enemyVelocity)
		{
			return this.shieldParryTimeLeft > 0 && Math.Sign(enemyRect.Center.X - blockingPlayerRect.Center.X) == this.direction && enemyVelocity != Vector2.Zero && !this.immune;
		}
		private void PurgeDD2EnergyCrystals()
		{
			for (int i = 0; i < 58; i++)
			{
				Item item = this.inventory[i];
				if (item.stack > 0 && item.type == 3822)
				{
					item.stack = 0;
					item.type = 0;
				}
			}
			if (this.chest == -2)
			{
				Chest chest = this.bank;
				for (int j = 0; j < 40; j++)
				{
					if (chest.item[j].stack > 0 && chest.item[j].type == 3822)
					{
						chest.item[j].stack = 0;
						chest.item[j].type = 0;
					}
				}
			}
			if (this.chest == -4)
			{
				Chest chest2 = this.bank3;
				for (int k = 0; k < 40; k++)
				{
					if (chest2.item[k].stack > 0 && chest2.item[k].type == 3822)
					{
						chest2.item[k].stack = 0;
						chest2.item[k].type = 0;
					}
				}
			}
			if (this.chest == -3)
			{
				Chest chest3 = this.bank2;
				for (int l = 0; l < 40; l++)
				{
					if (chest3.item[l].stack > 0 && chest3.item[l].type == 3822)
					{
						chest3.item[l].stack = 0;
						chest3.item[l].type = 0;
					}
				}
			}
			if (this.chest > -1)
			{
				Chest chest4 = Main.chest[this.chest];
				for (int m = 0; m < 40; m++)
				{
					if (chest4.item[m].stack > 0 && chest4.item[m].type == 3822)
					{
						chest4.item[m].stack = 0;
						chest4.item[m].type = 0;
						if (Main.netMode == 1)
						{
							NetMessage.SendData(32, -1, -1, "", this.chest, (float)m, 0f, 0f, 0, 0, 0);
						}
					}
				}
			}
		}
		public void ItemCheck_ManageRightClickFeatures()
		{
		}
		public void ItemCheck_ManageRightClickFeatures_ShieldRaise(bool theGeneralCheck)
		{
		}

		public void UpdateArmorSets(int i)
		{
			this.setBonus = "";
			if (this.body == 67 && this.legs == 56 && this.head >= 103 && this.head <= 105)
			{
				this.setBonus = Lang.setBonus(31, false);
				this.shroomiteStealth = true;
			}
			if ((this.head == 52 && this.body == 32 && this.legs == 31) || (this.head == 53 && this.body == 33 && this.legs == 32) || (this.head == 54 && this.body == 34 && this.legs == 33) || (this.head == 55 && this.body == 35 && this.legs == 34) || (this.head == 70 && this.body == 46 && this.legs == 42) || (this.head == 71 && this.body == 47 && this.legs == 43) || (this.head == 166 && this.body == 173 && this.legs == 108) || (this.head == 167 && this.body == 174 && this.legs == 109))
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
			if (this.head == 188 && this.body == 189 && this.legs == 129)
			{
				this.setBonus = Lang.setBonus(42, false);
				this.thrownCost50 = true;
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
				this.thrownDamage += 0.1f;
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
					Vector2[] expr_6EC_cp_0 = this.beetleVel;
					int expr_6EC_cp_1 = m;
					expr_6EC_cp_0[expr_6EC_cp_1].X = expr_6EC_cp_0[expr_6EC_cp_1].X + (float)Main.rand.Next(-100, 101) * 0.005f;
					Vector2[] expr_71A_cp_0 = this.beetleVel;
					int expr_71A_cp_1 = m;
					expr_71A_cp_0[expr_71A_cp_1].Y = expr_71A_cp_0[expr_71A_cp_1].Y + (float)Main.rand.Next(-100, 101) * 0.005f;
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
				this.thorns = 1f;
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
			if (this.head == 160 && this.body == 168 && this.legs == 103)
			{
				this.setBonus = Lang.setBonus(39, false);
				this.minionDamage += 0.1f;
				if (this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 1121)
				{
					AchievementsHelper.HandleSpecialEvent(this, 3);
				}
			}
			if (this.head == 162 && this.body == 170 && this.legs == 105)
			{
				this.setBonus = Lang.setBonus(40, false);
				this.minionDamage += 0.12f;
			}
			if (this.head == 171 && this.body == 177 && this.legs == 112)
			{
				this.setSolar = true;
				this.setBonus = Lang.setBonus(43, false);
				this.solarCounter++;
				int num11 = 240;
				if (this.solarCounter >= num11)
				{
					if (this.solarShields > 0 && this.solarShields < 3)
					{
						for (int num12 = 0; num12 < 22; num12++)
						{
							if (this.buffType[num12] >= 170 && this.buffType[num12] <= 171)
							{
								this.DelBuff(num12);
							}
						}
					}
					if (this.solarShields < 3)
					{
						this.AddBuff(170 + this.solarShields, 5, false);
						this.solarCounter = 0;
					}
					else
					{
						this.solarCounter = num11;
					}
				}
				for (int num14 = this.solarShields; num14 < 3; num14++)
				{
					this.solarShieldPos[num14] = Vector2.Zero;
				}
				for (int num15 = 0; num15 < this.solarShields; num15++)
				{
					this.solarShieldPos[num15] += this.solarShieldVel[num15];
					Vector2 value = ((float)this.miscCounter / 100f * 6.28318548f + (float)num15 * (6.28318548f / (float)this.solarShields)).ToRotationVector2() * 6f;
					value.X = (float)(this.direction * 20);
					this.solarShieldVel[num15] = (value - this.solarShieldPos[num15]) * 0.2f;
				}
				if (this.dashDelay >= 0)
				{
					this.solarDashing = false;
					this.solarDashConsumedFlare = false;
				}
				bool flag = this.solarDashing && this.dashDelay < 0;
				if (this.solarShields > 0 || flag)
				{
					this.dash = 3;
				}
			}
			else
			{
				this.solarCounter = 0;
			}
			if (this.head == 169 && this.body == 175 && this.legs == 110)
			{
				this.setVortex = true;
				this.setBonus = Lang.setBonus(44, false);
			}
			else
			{
				this.vortexStealthActive = false;
			}
			if (this.head == 170 && this.body == 176 && this.legs == 111)
			{
				if (this.nebulaCD > 0)
				{
					this.nebulaCD--;
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
					if (this.HasBuff(187) == -1)
					{
						this.AddBuff(187, 3600, true);
					}
					if (this.ownedProjectileCounts[623] < 1)
					{
						Projectile.NewProjectile(base.Center.X, base.Center.Y, 0f, -1f, 623, 0, 0f, Main.myPlayer, 0f, 0f);
						return;
					}
				}
			}
			else if (this.HasBuff(187) != -1)
			{
				this.DelBuff(this.HasBuff(187));
			}
			if (this.head == 200 && this.body == 198 && this.legs == 142)
			{
				this.setBonus = Lang.setBonus(47, false);
				this.setForbidden = true;
				this.UpdateForbiddenSetLock();
			}
			if (this.head == 204 && this.body == 201 && this.legs == 145)
			{
				this.setBonus = Lang.setBonus(52, false);
				this.setSquireT2 = true;
				this.maxTurrets++;
			}
			if (this.head == 203 && this.body == 200 && this.legs == 144)
			{
				this.setBonus = Lang.setBonus(53, false);
				this.setApprenticeT2 = true;
				this.maxTurrets++;
			}
			if (this.head == 205 && this.body == 202 && (this.legs == 147 || this.legs == 146))
			{
				this.setBonus = Lang.setBonus(54, false);
				this.setHuntressT2 = true;
				this.maxTurrets++;
			}
			if (this.head == 206 && this.body == 203 && this.legs == 148)
			{
				this.setBonus = Lang.setBonus(55, false);
				this.setMonkT2 = true;
				this.maxTurrets++;
			}
			if (this.head == 210 && this.body == 204 && this.legs == 152)
			{
				this.setBonus = Lang.setBonus(48, false);
				this.setSquireT3 = true;
				this.setSquireT2 = true;
				this.maxTurrets++;
			}
			if (this.head == 211 && this.body == 205 && this.legs == 153)
			{
				this.setBonus = Lang.setBonus(49, false);
				this.setApprenticeT3 = true;
				this.setApprenticeT2 = true;
				this.maxTurrets++;
			}
			if (this.head == 212 && this.body == 206 && (this.legs == 154 || this.legs == 155))
			{
				this.setBonus = Lang.setBonus(50, false);
				this.setHuntressT3 = true;
				this.setHuntressT2 = true;
				this.maxTurrets++;
			}
			if (this.head == 213 && this.body == 207 && this.legs == 156)
			{
				this.setBonus = Lang.setBonus(51, false);
				this.setMonkT3 = true;
				this.setMonkT2 = true;
				this.maxTurrets++;
			}
		}

		public void UpdateBiomes()
		{
			this.ZoneDungeon = false;
			if (Main.dungeonTiles >= 250 && (double)base.Center.Y > Main.worldSurface * 16.0)
			{
				int num = (int)base.Center.X / 16;
				int num2 = (int)base.Center.Y / 16;
				if (Main.wallDungeon[(int)Main.tile[num, num2].wall])
				{
					this.ZoneDungeon = true;
				}
			}
			if (Main.sandTiles > 1000 && base.Center.Y > 3200f)
			{
				Point point = base.Center.ToTileCoordinates();
				Tile tileSafely = Framing.GetTileSafely(point.X, point.Y);
				if (WallID.Sets.Conversion.Sandstone[(int)tileSafely.wall] || WallID.Sets.Conversion.HardenedSand[(int)tileSafely.wall])
				{
					this.ZoneUndergroundDesert = true;
				}
			}
			else
			{
				this.ZoneUndergroundDesert = false;
			}
			this.ZoneCorrupt = (Main.evilTiles >= 200);
			this.ZoneHoly = (Main.holyTiles >= 100);
			this.ZoneMeteor = (Main.meteorTiles >= 50);
			this.ZoneJungle = (Main.jungleTiles >= 80);
			this.ZoneSnow = (Main.snowTiles >= 300);
			this.ZoneCrimson = (Main.bloodTiles >= 200);
			this.ZoneWaterCandle = (Main.waterCandles > 0);
			this.ZonePeaceCandle = (Main.peaceCandles > 0);
			this.ZoneDesert = (Main.sandTiles > 1000);
			this.ZoneGlowshroom = (Main.shroomTiles > 100);
			this.ZoneTowerSolar = (this.ZoneTowerVortex = (this.ZoneTowerNebula = (this.ZoneTowerStardust = false)));
			this.ZoneOldOneArmy = false;
			Vector2 value = Vector2.Zero;
			Vector2 value2 = Vector2.Zero;
			Vector2 value3 = Vector2.Zero;
			Vector2 value4 = Vector2.Zero;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active)
				{
					if (Main.npc[i].type == 493)
					{
						if (base.Distance(Main.npc[i].Center) <= 4000f)
						{
							this.ZoneTowerStardust = true;
							value4 = Main.npc[i].Center;
						}
					}
					else if (Main.npc[i].type == 507)
					{
						if (base.Distance(Main.npc[i].Center) <= 4000f)
						{
							this.ZoneTowerNebula = true;
							value3 = Main.npc[i].Center;
						}
					}
					else if (Main.npc[i].type == 422)
					{
						if (base.Distance(Main.npc[i].Center) <= 4000f)
						{
							this.ZoneTowerVortex = true;
							value2 = Main.npc[i].Center;
						}
					}
					else if (Main.npc[i].type == 517)
					{
						if (base.Distance(Main.npc[i].Center) <= 4000f)
						{
							this.ZoneTowerSolar = true;
							value = Main.npc[i].Center;
						}
					}
					else if (Main.npc[i].type == 549 && base.Distance(Main.npc[i].Center) <= 4000f)
					{
						this.ZoneOldOneArmy = true;
						value = Main.npc[i].Center;
					}
				}
			}
			if (!this.dead)
			{
				Point point2 = base.Center.ToTileCoordinates();
				if (WorldGen.InWorld(point2.X, point2.Y, 1))
				{
					int num3 = 0;
					if (Main.tile[point2.X, point2.Y] != null)
					{
						num3 = (int)Main.tile[point2.X, point2.Y].wall;
					}
					int num4 = num3;
					if (num4 != 62)
					{
						if (num4 == 86)
						{
							AchievementsHelper.HandleSpecialEvent(this, 12);
						}
					}
					else
					{
						AchievementsHelper.HandleSpecialEvent(this, 13);
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
			}
			else
			{
				this._funkytownCheckCD = 100;
			}
		}

		public void UpdateBuffs(int i)
		{
			if (this.soulDrain > 0 && this.whoAmI == Main.myPlayer)
			{
				this.AddBuff(151, 2, true);
			}
			for (int j = 0; j < 1000; j++)
			{
				if (Main.projectile[j].active && Main.projectile[j].owner == i)
				{
					this.ownedProjectileCounts[Main.projectile[j].type]++;
				}
			}
			for (int k = 0; k < 22; k++)
			{
				if (this.buffType[k] > 0 && this.buffTime[k] > 0)
				{
					if (this.whoAmI == Main.myPlayer && this.buffType[k] != 28)
					{
						this.buffTime[k]--;
					}
					if (this.buffType[k] == 1)
					{
						this.lavaImmune = true;
						this.fireWalk = true;
						this.buffImmune[24] = true;
					}
					else if (this.buffType[k] == 158)
					{
						this.manaRegenBonus += 2;
					}
					else if (this.buffType[k] == 159 && this.inventory[this.selectedItem].melee)
					{
						this.armorPenetration = 4;
					}
					else if (this.buffType[k] == 2)
					{
						this.lifeRegen += 4;
					}
					else if (this.buffType[k] == 3)
					{
						this.moveSpeed += 0.25f;
					}
					else if (this.buffType[k] == 4)
					{
						this.gills = true;
					}
					else if (this.buffType[k] == 5)
					{
						this.statDefense += 8;
					}
					else if (this.buffType[k] == 6)
					{
						this.manaRegenBuff = true;
					}
					else if (this.buffType[k] == 7)
					{
						this.magicDamage += 0.2f;
					}
					else if (this.buffType[k] == 8)
					{
						this.slowFall = true;
					}
					else if (this.buffType[k] == 9)
					{
						this.findTreasure = true;
					}
					else if (this.buffType[k] == 10)
					{
						this.invis = true;
					}
					else if (this.buffType[k] == 12)
					{
						this.nightVision = true;
					}
					else if (this.buffType[k] == 13)
					{
						this.enemySpawns = true;
					}
					else if (this.buffType[k] == 14)
					{
						if (this.thorns < 1f)
						{
							this.thorns = 0.333333343f;
						}
					}
					else if (this.buffType[k] == 15)
					{
						this.waterWalk = true;
					}
					else if (this.buffType[k] == 16)
					{
						this.archery = true;
					}
					else if (this.buffType[k] == 17)
					{
						this.detectCreature = true;
					}
					else if (this.buffType[k] == 18)
					{
						this.gravControl = true;
					}
					else if (this.buffType[k] == 30)
					{
						this.bleed = true;
					}
					else if (this.buffType[k] == 31)
					{
						this.confused = true;
					}
					else if (this.buffType[k] == 32)
					{
						this.slow = true;
					}
					else if (this.buffType[k] == 35)
					{
						this.silence = true;
					}
					else if (this.buffType[k] == 160)
					{
						this.dazed = true;
					}
					else if (this.buffType[k] == 46)
					{
						this.chilled = true;
					}
					else if (this.buffType[k] == 47)
					{
						this.frozen = true;
					}
					else if (this.buffType[k] == 156)
					{
						this.stoned = true;
					}
					else if (this.buffType[k] == 69)
					{
						this.ichor = true;
						this.statDefense -= 20;
					}
					else if (this.buffType[k] == 36)
					{
						this.brokenArmor = true;
					}
					else if (this.buffType[k] == 48)
					{
						this.honey = true;
					}
					else if (this.buffType[k] == 59)
					{
						this.shadowDodge = true;
					}
					else if (this.buffType[k] == 93)
					{
						this.ammoBox = true;
					}
					else if (this.buffType[k] == 58)
					{
						this.palladiumRegen = true;
					}
					else if (this.buffType[k] == 88)
					{
						this.chaosState = true;
					}
					else if (this.buffType[k] == 63)
					{
						this.moveSpeed += 1f;
					}
					else if (this.buffType[k] == 104)
					{
						this.pickSpeed -= 0.25f;
					}
					else if (this.buffType[k] == 105)
					{
						this.lifeMagnet = true;
					}
					else if (this.buffType[k] == 106)
					{
						this.calmed = true;
					}
					else if (this.buffType[k] == 121)
					{
						this.fishingSkill += 15;
					}
					else if (this.buffType[k] == 122)
					{
						this.sonarPotion = true;
					}
					else if (this.buffType[k] == 123)
					{
						this.cratePotion = true;
					}
					else if (this.buffType[k] == 107)
					{
						this.tileSpeed += 0.25f;
						this.wallSpeed += 0.25f;
						this.blockRange++;
					}
					else if (this.buffType[k] == 108)
					{
						this.kbBuff = true;
					}
					else if (this.buffType[k] == 109)
					{
						this.ignoreWater = true;
						this.accFlipper = true;
					}
					else if (this.buffType[k] == 110)
					{
						this.maxMinions++;
					}
					else if (this.buffType[k] == 150)
					{
						this.maxMinions++;
					}
					else if (this.buffType[k] == 111)
					{
						this.dangerSense = true;
					}
					else if (this.buffType[k] == 112)
					{
						this.ammoPotion = true;
					}
					else if (this.buffType[k] == 113)
					{
						this.lifeForce = true;
						this.statLifeMax2 += this.statLifeMax / 5 / 20 * 20;
					}
					else if (this.buffType[k] == 114)
					{
						this.endurance += 0.1f;
					}
					else if (this.buffType[k] == 115)
					{
						this.meleeCrit += 10;
						this.rangedCrit += 10;
						this.magicCrit += 10;
						this.thrownCrit += 10;
					}
					else if (this.buffType[k] == 116)
					{
						this.inferno = true;
						int num = 24;
						float num2 = 200f;
						bool flag = this.infernoCounter % 60 == 0;
						int num3 = 10;
						if (this.whoAmI == Main.myPlayer)
						{
							for (int l = 0; l < 200; l++)
							{
								NPC nPC = Main.npc[l];
								if (nPC.active && !nPC.friendly && nPC.damage > 0 && !nPC.dontTakeDamage && !nPC.buffImmune[num] && Vector2.Distance(base.Center, nPC.Center) <= num2)
								{
									if (nPC.HasBuff(num) == -1)
									{
										nPC.AddBuff(num, 120, false);
									}
									if (flag)
									{
										this.ApplyDamageToNPC(nPC, num3, 0f, 0, false);
									}
								}
							}
							if (this.hostile)
							{
								for (int m = 0; m < 255; m++)
								{
									Player player = Main.player[m];
									if (player != this && player.active && !player.dead && player.hostile && !player.buffImmune[num] && (player.team != this.team || player.team == 0) && Vector2.Distance(base.Center, player.Center) <= num2)
									{
										if (player.HasBuff(num) == -1)
										{
											player.AddBuff(num, 120, true);
										}
										if (flag)
										{
											player.Hurt(num3, 0, true, false, "", false, -1);
											if (Main.netMode != 0)
											{
												NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.whoAmI, -1, -1, -1), m, 0f, (float)num3, 1f, 0, 0, 0);
											}
										}
									}
								}
							}
						}
					}
					else if (this.buffType[k] == 117)
					{
						this.thrownDamage += 0.1f;
						this.meleeDamage += 0.1f;
						this.rangedDamage += 0.1f;
						this.magicDamage += 0.1f;
						this.minionDamage += 0.1f;
					}
					else if (this.buffType[k] == 119)
					{
						this.loveStruck = true;
					}
					else if (this.buffType[k] == 120)
					{
						this.stinky = true;
					}
					else if (this.buffType[k] == 124)
					{
						this.resistCold = true;
					}
					else if (this.buffType[k] == 165)
					{
						this.lifeRegen += 6;
						this.statDefense += 8;
						this.dryadWard = true;
						if (this.thorns < 1f)
						{
							this.thorns += 0.2f;
						}
					}
					else if (this.buffType[k] == 144)
					{
						this.electrified = true;
					}
					else if (this.buffType[k] == 94)
					{
						this.manaSick = true;
						this.manaSickReduction = Player.manaSickLessDmg * ((float)this.buffTime[k] / (float)Player.manaSickTime);
					}
					else if (this.buffType[k] >= 95 && this.buffType[k] <= 97)
					{
						this.buffTime[k] = 5;
						int num4 = (int)((byte)(1 + this.buffType[k] - 95));
						if (this.beetleOrbs > 0 && this.beetleOrbs != num4)
						{
							if (this.beetleOrbs > num4)
							{
								this.DelBuff(k);
								k--;
							}
							else
							{
								for (int n = 0; n < 22; n++)
								{
									if (this.buffType[n] >= 95 && this.buffType[n] <= 95 + num4 - 1)
									{
										this.DelBuff(n);
										n--;
									}
								}
							}
						}
						this.beetleOrbs = num4;
						if (!this.beetleDefense)
						{
							this.beetleOrbs = 0;
							this.DelBuff(k);
							k--;
						}
						else
						{
							this.beetleBuff = true;
						}
					}
					else if (this.buffType[k] >= 170 && this.buffType[k] <= 172)
					{
						this.buffTime[k] = 5;
						int num5 = (int)((byte)(1 + this.buffType[k] - 170));
						if (this.solarShields > 0 && this.solarShields != num5)
						{
							if (this.solarShields > num5)
							{
								this.DelBuff(k);
								k--;
							}
							else
							{
								for (int num6 = 0; num6 < 22; num6++)
								{
									if (this.buffType[num6] >= 170 && this.buffType[num6] <= 170 + num5 - 1)
									{
										this.DelBuff(num6);
										num6--;
									}
								}
							}
						}
						this.solarShields = num5;
						if (!this.setSolar)
						{
							this.solarShields = 0;
							this.DelBuff(k);
							k--;
						}
					}
					else if (this.buffType[k] >= 98 && this.buffType[k] <= 100)
					{
						int num7 = (int)((byte)(1 + this.buffType[k] - 98));
						if (this.beetleOrbs > 0 && this.beetleOrbs != num7)
						{
							if (this.beetleOrbs > num7)
							{
								this.DelBuff(k);
								k--;
							}
							else
							{
								for (int num8 = 0; num8 < 22; num8++)
								{
									if (this.buffType[num8] >= 98 && this.buffType[num8] <= 98 + num7 - 1)
									{
										this.DelBuff(num8);
										num8--;
									}
								}
							}
						}
						this.beetleOrbs = num7;
						this.meleeDamage += 0.1f * (float)this.beetleOrbs;
						this.meleeSpeed += 0.1f * (float)this.beetleOrbs;
						if (!this.beetleOffense)
						{
							this.beetleOrbs = 0;
							this.DelBuff(k);
							k--;
						}
						else
						{
							this.beetleBuff = true;
						}
					}
					else if (this.buffType[k] >= 176 && this.buffType[k] <= 178)
					{
						int num9 = this.nebulaLevelMana;
						int num10 = (int)((byte)(1 + this.buffType[k] - 176));
						if (num9 > 0 && num9 != num10)
						{
							if (num9 > num10)
							{
								this.DelBuff(k);
								k--;
							}
							else
							{
								for (int num11 = 0; num11 < 22; num11++)
								{
									if (this.buffType[num11] >= 176 && this.buffType[num11] <= 178 + num10 - 1)
									{
										this.DelBuff(num11);
										num11--;
									}
								}
							}
						}
						this.nebulaLevelMana = num10;
						if (this.buffTime[k] == 2 && this.nebulaLevelMana > 1)
						{
							this.nebulaLevelMana--;
							this.buffType[k]--;
							this.buffTime[k] = 480;
						}
					}
					else if (this.buffType[k] >= 173 && this.buffType[k] <= 175)
					{
						int num12 = this.nebulaLevelLife;
						int num13 = (int)((byte)(1 + this.buffType[k] - 173));
						if (num12 > 0 && num12 != num13)
						{
							if (num12 > num13)
							{
								this.DelBuff(k);
								k--;
							}
							else
							{
								for (int num14 = 0; num14 < 22; num14++)
								{
									if (this.buffType[num14] >= 173 && this.buffType[num14] <= 175 + num13 - 1)
									{
										this.DelBuff(num14);
										num14--;
									}
								}
							}
						}
						this.nebulaLevelLife = num13;
						if (this.buffTime[k] == 2 && this.nebulaLevelLife > 1)
						{
							this.nebulaLevelLife--;
							this.buffType[k]--;
							this.buffTime[k] = 480;
						}
						this.lifeRegen += 10 * this.nebulaLevelLife;
					}
					else if (this.buffType[k] >= 179 && this.buffType[k] <= 181)
					{
						int num15 = this.nebulaLevelDamage;
						int num16 = (int)((byte)(1 + this.buffType[k] - 179));
						if (num15 > 0 && num15 != num16)
						{
							if (num15 > num16)
							{
								this.DelBuff(k);
								k--;
							}
							else
							{
								for (int num17 = 0; num17 < 22; num17++)
								{
									if (this.buffType[num17] >= 179 && this.buffType[num17] <= 181 + num16 - 1)
									{
										this.DelBuff(num17);
										num17--;
									}
								}
							}
						}
						this.nebulaLevelDamage = num16;
						if (this.buffTime[k] == 2 && this.nebulaLevelDamage > 1)
						{
							this.nebulaLevelDamage--;
							this.buffType[k]--;
							this.buffTime[k] = 480;
						}
						float num18 = 0.15f * (float)this.nebulaLevelDamage;
						this.meleeDamage += num18;
						this.rangedDamage += num18;
						this.magicDamage += num18;
						this.minionDamage += num18;
						this.thrownDamage += num18;
					}
					else if (this.buffType[k] == 62)
					{
						if ((double)this.statLife <= (double)this.statLifeMax2 * 0.5)
						{
							this.iceBarrier = true;
							this.endurance += 0.25f;
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
							this.DelBuff(k);
							k--;
						}
					}
					else if (this.buffType[k] == 49)
					{
						for (int num19 = 191; num19 <= 194; num19++)
						{
							if (this.ownedProjectileCounts[num19] > 0)
							{
								this.pygmy = true;
							}
						}
						if (!this.pygmy)
						{
							this.DelBuff(k);
							k--;
						}
						else
						{
							this.buffTime[k] = 18000;
						}
					}
					else if (this.buffType[k] == 83)
					{
						if (this.ownedProjectileCounts[317] > 0)
						{
							this.raven = true;
						}
						if (!this.raven)
						{
							this.DelBuff(k);
							k--;
						}
						else
						{
							this.buffTime[k] = 18000;
						}
					}
					else if (this.buffType[k] == 64)
					{
						if (this.ownedProjectileCounts[266] > 0)
						{
							this.slime = true;
						}
						if (!this.slime)
						{
							this.DelBuff(k);
							k--;
						}
						else
						{
							this.buffTime[k] = 18000;
						}
					}
					else if (this.buffType[k] == 125)
					{
						if (this.ownedProjectileCounts[373] > 0)
						{
							this.hornetMinion = true;
						}
						if (!this.hornetMinion)
						{
							this.DelBuff(k);
							k--;
						}
						else
						{
							this.buffTime[k] = 18000;
						}
					}
					else if (this.buffType[k] == 126)
					{
						if (this.ownedProjectileCounts[375] > 0)
						{
							this.impMinion = true;
						}
						if (!this.impMinion)
						{
							this.DelBuff(k);
							k--;
						}
						else
						{
							this.buffTime[k] = 18000;
						}
					}
					else if (this.buffType[k] == 133)
					{
						if (this.ownedProjectileCounts[390] > 0 || this.ownedProjectileCounts[391] > 0 || this.ownedProjectileCounts[392] > 0)
						{
							this.spiderMinion = true;
						}
						if (!this.spiderMinion)
						{
							this.DelBuff(k);
							k--;
						}
						else
						{
							this.buffTime[k] = 18000;
						}
					}
					else if (this.buffType[k] == 134)
					{
						if (this.ownedProjectileCounts[387] > 0 || this.ownedProjectileCounts[388] > 0)
						{
							this.twinsMinion = true;
						}
						if (!this.twinsMinion)
						{
							this.DelBuff(k);
							k--;
						}
						else
						{
							this.buffTime[k] = 18000;
						}
					}
					else if (this.buffType[k] == 135)
					{
						if (this.ownedProjectileCounts[393] > 0 || this.ownedProjectileCounts[394] > 0 || this.ownedProjectileCounts[395] > 0)
						{
							this.pirateMinion = true;
						}
						if (!this.pirateMinion)
						{
							this.DelBuff(k);
							k--;
						}
						else
						{
							this.buffTime[k] = 18000;
						}
					}
					else if (this.buffType[k] == 139)
					{
						if (this.ownedProjectileCounts[407] > 0)
						{
							this.sharknadoMinion = true;
						}
						if (!this.sharknadoMinion)
						{
							this.DelBuff(k);
							k--;
						}
						else
						{
							this.buffTime[k] = 18000;
						}
					}
					else if (this.buffType[k] == 140)
					{
						if (this.ownedProjectileCounts[423] > 0)
						{
							this.UFOMinion = true;
						}
						if (!this.UFOMinion)
						{
							this.DelBuff(k);
							k--;
						}
						else
						{
							this.buffTime[k] = 18000;
						}
					}
					else if (this.buffType[k] == 182)
					{
						if (this.ownedProjectileCounts[613] > 0)
						{
							this.stardustMinion = true;
						}
						if (!this.stardustMinion)
						{
							this.DelBuff(k);
							k--;
						}
						else
						{
							this.buffTime[k] = 18000;
						}
					}
					else if (this.buffType[k] == 187)
					{
						if (this.ownedProjectileCounts[623] > 0)
						{
							this.stardustGuardian = true;
						}
						if (!this.stardustGuardian)
						{
							this.DelBuff(k);
							k--;
						}
						else
						{
							this.buffTime[k] = 18000;
						}
					}
					else if (this.buffType[k] == 188)
					{
						if (this.ownedProjectileCounts[625] > 0)
						{
							this.stardustDragon = true;
						}
						if (!this.stardustDragon)
						{
							this.DelBuff(k);
							k--;
						}
						else
						{
							this.buffTime[k] = 18000;
						}
					}
					else if (this.buffType[k] == 161)
					{
						if (this.ownedProjectileCounts[533] > 0)
						{
							this.DeadlySphereMinion = true;
						}
						if (!this.DeadlySphereMinion)
						{
							this.DelBuff(k);
							k--;
						}
						else
						{
							this.buffTime[k] = 18000;
						}
					}
					else if (this.buffType[k] == 90)
					{
						this.mount.SetMount(0, this, false);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 128)
					{
						this.mount.SetMount(1, this, false);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 129)
					{
						this.mount.SetMount(2, this, false);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 130)
					{
						this.mount.SetMount(3, this, false);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 118)
					{
						this.mount.SetMount(6, this, true);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 138)
					{
						this.mount.SetMount(6, this, false);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 167)
					{
						this.mount.SetMount(11, this, true);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 166)
					{
						this.mount.SetMount(11, this, false);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 184)
					{
						this.mount.SetMount(13, this, true);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 185)
					{
						this.mount.SetMount(13, this, false);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 131)
					{
						this.ignoreWater = true;
						this.accFlipper = true;
						this.mount.SetMount(4, this, false);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 132)
					{
						this.mount.SetMount(5, this, false);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 168)
					{
						this.ignoreWater = true;
						this.accFlipper = true;
						this.mount.SetMount(12, this, false);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 141)
					{
						this.mount.SetMount(7, this, false);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 142)
					{
						this.mount.SetMount(8, this, false);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 143)
					{
						this.mount.SetMount(9, this, false);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 162)
					{
						this.mount.SetMount(10, this, false);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 193)
					{
						this.mount.SetMount(14, this, false);
						this.buffTime[k] = 10;
					}
					else if (this.buffType[k] == 37)
					{
						if (Main.wof >= 0 && Main.npc[Main.wof].type == 113)
						{
							this.gross = true;
							this.buffTime[k] = 10;
						}
						else
						{
							this.DelBuff(k);
							k--;
						}
					}
					else if (this.buffType[k] == 38)
					{
						this.buffTime[k] = 10;
						this.tongued = true;
					}
					else if (this.buffType[k] == 146)
					{
						this.moveSpeed += 0.1f;
						this.moveSpeed *= 1.1f;
						this.sunflower = true;
					}
					else if (this.buffType[k] == 19)
					{
						this.buffTime[k] = 18000;
						this.lightOrb = true;
						bool flag2 = true;
						if (this.ownedProjectileCounts[18] > 0)
						{
							flag2 = false;
						}
						if (flag2 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 18, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 155)
					{
						this.buffTime[k] = 18000;
						this.crimsonHeart = true;
						bool flag3 = true;
						if (this.ownedProjectileCounts[500] > 0)
						{
							flag3 = false;
						}
						if (flag3 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 500, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 191)
					{
						this.CommonPetBuffHandle(k, ref this.companionCube, 653);
					}
					else if (this.buffType[k] == 202)
					{
						this.CommonPetBuffHandle(k, ref this.petFlagDD2Dragon, 701);
					}
					else if (this.buffType[k] == 200)
					{
						this.CommonPetBuffHandle(k, ref this.petFlagDD2Gato, 703);
					}
					else if (this.buffType[k] == 201)
					{
						this.CommonPetBuffHandle(k, ref this.petFlagDD2Ghost, 702);
					}
					else if (this.buffType[k] == 190)
					{
						this.buffTime[k] = 18000;
						this.suspiciouslookingTentacle = true;
						bool flag5 = true;
						if (this.ownedProjectileCounts[650] > 0)
						{
							flag5 = false;
						}
						if (flag5 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 650, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 27 || this.buffType[k] == 101 || this.buffType[k] == 102)
					{
						this.buffTime[k] = 18000;
						bool flag6 = true;
						int num20 = 72;
						if (this.buffType[k] == 27)
						{
							this.blueFairy = true;
						}
						if (this.buffType[k] == 101)
						{
							num20 = 86;
							this.redFairy = true;
						}
						if (this.buffType[k] == 102)
						{
							num20 = 87;
							this.greenFairy = true;
						}
						if (this.head == 45 && this.body == 26 && this.legs == 25)
						{
							num20 = 72;
						}
						if (this.ownedProjectileCounts[num20] > 0)
						{
							flag6 = false;
						}
						if (flag6 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, num20, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 40)
					{
						this.buffTime[k] = 18000;
						this.bunny = true;
						bool flag7 = true;
						if (this.ownedProjectileCounts[111] > 0)
						{
							flag7 = false;
						}
						if (flag7 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 111, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 148)
					{
						this.rabid = true;
						if (Main.rand.Next(1200) == 0)
						{
							int num21 = Main.rand.Next(6);
							float num22 = (float)Main.rand.Next(60, 100) * 0.01f;
							if (num21 == 0)
							{
								this.AddBuff(22, (int)(60f * num22 * 3f), true);
							}
							else if (num21 == 1)
							{
								this.AddBuff(23, (int)(60f * num22 * 0.75f), true);
							}
							else if (num21 == 2)
							{
								this.AddBuff(31, (int)(60f * num22 * 1.5f), true);
							}
							else if (num21 == 3)
							{
								this.AddBuff(32, (int)(60f * num22 * 3.5f), true);
							}
							else if (num21 == 4)
							{
								this.AddBuff(33, (int)(60f * num22 * 5f), true);
							}
							else if (num21 == 5)
							{
								this.AddBuff(35, (int)(60f * num22 * 1f), true);
							}
						}
						this.meleeDamage += 0.2f;
						this.magicDamage += 0.2f;
						this.rangedDamage += 0.2f;
						this.thrownDamage += 0.2f;
						this.minionDamage += 0.2f;
					}
					else if (this.buffType[k] == 41)
					{
						this.buffTime[k] = 18000;
						this.penguin = true;
						bool flag8 = true;
						if (this.ownedProjectileCounts[112] > 0)
						{
							flag8 = false;
						}
						if (flag8 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 112, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 152)
					{
						this.buffTime[k] = 18000;
						this.magicLantern = true;
						if (this.ownedProjectileCounts[492] == 0 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 492, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 91)
					{
						this.buffTime[k] = 18000;
						this.puppy = true;
						bool flag9 = true;
						if (this.ownedProjectileCounts[334] > 0)
						{
							flag9 = false;
						}
						if (flag9 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 334, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 92)
					{
						this.buffTime[k] = 18000;
						this.grinch = true;
						bool flag10 = true;
						if (this.ownedProjectileCounts[353] > 0)
						{
							flag10 = false;
						}
						if (flag10 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 353, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 84)
					{
						this.buffTime[k] = 18000;
						this.blackCat = true;
						bool flag11 = true;
						if (this.ownedProjectileCounts[319] > 0)
						{
							flag11 = false;
						}
						if (flag11 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 319, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 61)
					{
						this.buffTime[k] = 18000;
						this.dino = true;
						bool flag12 = true;
						if (this.ownedProjectileCounts[236] > 0)
						{
							flag12 = false;
						}
						if (flag12 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 236, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 154)
					{
						this.buffTime[k] = 18000;
						this.babyFaceMonster = true;
						bool flag13 = true;
						if (this.ownedProjectileCounts[499] > 0)
						{
							flag13 = false;
						}
						if (flag13 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 499, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 65)
					{
						this.buffTime[k] = 18000;
						this.eyeSpring = true;
						bool flag14 = true;
						if (this.ownedProjectileCounts[268] > 0)
						{
							flag14 = false;
						}
						if (flag14 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 268, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 66)
					{
						this.buffTime[k] = 18000;
						this.snowman = true;
						bool flag15 = true;
						if (this.ownedProjectileCounts[269] > 0)
						{
							flag15 = false;
						}
						if (flag15 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 269, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 42)
					{
						this.buffTime[k] = 18000;
						this.turtle = true;
						bool flag16 = true;
						if (this.ownedProjectileCounts[127] > 0)
						{
							flag16 = false;
						}
						if (flag16 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 127, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 45)
					{
						this.buffTime[k] = 18000;
						this.eater = true;
						bool flag17 = true;
						if (this.ownedProjectileCounts[175] > 0)
						{
							flag17 = false;
						}
						if (flag17 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 175, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 50)
					{
						this.buffTime[k] = 18000;
						this.skeletron = true;
						bool flag18 = true;
						if (this.ownedProjectileCounts[197] > 0)
						{
							flag18 = false;
						}
						if (flag18 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 197, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 51)
					{
						this.buffTime[k] = 18000;
						this.hornet = true;
						bool flag19 = true;
						if (this.ownedProjectileCounts[198] > 0)
						{
							flag19 = false;
						}
						if (flag19 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 198, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 52)
					{
						this.buffTime[k] = 18000;
						this.tiki = true;
						bool flag20 = true;
						if (this.ownedProjectileCounts[199] > 0)
						{
							flag20 = false;
						}
						if (flag20 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 199, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 53)
					{
						this.buffTime[k] = 18000;
						this.lizard = true;
						bool flag21 = true;
						if (this.ownedProjectileCounts[200] > 0)
						{
							flag21 = false;
						}
						if (flag21 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 200, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 54)
					{
						this.buffTime[k] = 18000;
						this.parrot = true;
						bool flag22 = true;
						if (this.ownedProjectileCounts[208] > 0)
						{
							flag22 = false;
						}
						if (flag22 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 208, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 55)
					{
						this.buffTime[k] = 18000;
						this.truffle = true;
						bool flag23 = true;
						if (this.ownedProjectileCounts[209] > 0)
						{
							flag23 = false;
						}
						if (flag23 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 209, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 56)
					{
						this.buffTime[k] = 18000;
						this.sapling = true;
						bool flag24 = true;
						if (this.ownedProjectileCounts[210] > 0)
						{
							flag24 = false;
						}
						if (flag24 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 210, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 85)
					{
						this.buffTime[k] = 18000;
						this.cSapling = true;
						bool flag25 = true;
						if (this.ownedProjectileCounts[324] > 0)
						{
							flag25 = false;
						}
						if (flag25 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 324, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 81)
					{
						this.buffTime[k] = 18000;
						this.spider = true;
						bool flag26 = true;
						if (this.ownedProjectileCounts[313] > 0)
						{
							flag26 = false;
						}
						if (flag26 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 313, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 82)
					{
						this.buffTime[k] = 18000;
						this.squashling = true;
						bool flag27 = true;
						if (this.ownedProjectileCounts[314] > 0)
						{
							flag27 = false;
						}
						if (flag27 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 314, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 57)
					{
						this.buffTime[k] = 18000;
						this.wisp = true;
						bool flag28 = true;
						if (this.ownedProjectileCounts[211] > 0)
						{
							flag28 = false;
						}
						if (flag28 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 211, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 60)
					{
						this.buffTime[k] = 18000;
						this.crystalLeaf = true;
						bool flag29 = true;
						for (int num23 = 0; num23 < 1000; num23++)
						{
							if (Main.projectile[num23].active && Main.projectile[num23].owner == this.whoAmI && Main.projectile[num23].type == 226)
							{
								if (!flag29)
								{
									Main.projectile[num23].Kill();
								}
								flag29 = false;
							}
						}
						if (flag29 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 226, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 127)
					{
						this.buffTime[k] = 18000;
						this.zephyrfish = true;
						bool flag30 = true;
						if (this.ownedProjectileCounts[380] > 0)
						{
							flag30 = false;
						}
						if (flag30 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 380, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 136)
					{
						this.buffTime[k] = 18000;
						this.miniMinotaur = true;
						bool flag31 = true;
						if (this.ownedProjectileCounts[398] > 0)
						{
							flag31 = false;
						}
						if (flag31 && this.whoAmI == Main.myPlayer)
						{
							Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 398, 0, 0f, this.whoAmI, 0f, 0f);
						}
					}
					else if (this.buffType[k] == 70)
					{
						this.venom = true;
					}
					else if (this.buffType[k] == 20)
					{
						this.poisoned = true;
					}
					else if (this.buffType[k] == 21)
					{
						this.potionDelay = this.buffTime[k];
					}
					else if (this.buffType[k] == 22)
					{
						this.blind = true;
					}
					else if (this.buffType[k] == 80)
					{
						this.blackout = true;
					}
					else if (this.buffType[k] == 23)
					{
						this.noItems = true;
					}
					else if (this.buffType[k] == 24)
					{
						this.onFire = true;
					}
					else if (this.buffType[k] == 103)
					{
						this.dripping = true;
					}
					else if (this.buffType[k] == 137)
					{
						this.drippingSlime = true;
					}
					else if (this.buffType[k] == 67)
					{
						this.burned = true;
					}
					else if (this.buffType[k] == 68)
					{
						this.suffocating = true;
					}
					else if (this.buffType[k] == 39)
					{
						this.onFire2 = true;
					}
					else if (this.buffType[k] == 44)
					{
						this.onFrostBurn = true;
					}
					else if (this.buffType[k] == 163)
					{
						this.headcovered = true;
						this.bleed = true;
					}
					else if (this.buffType[k] == 164)
					{
						this.vortexDebuff = true;
					}
					else if (this.buffType[k] == 194)
					{
						this.windPushed = true;
					}
					else if (this.buffType[k] == 195)
					{
						this.witheredArmor = true;
					}
					else if (this.buffType[k] == 205)
					{
						this.ballistaPanic = true;
					}
					else if (this.buffType[k] == 196)
					{
						this.witheredWeapon = true;
					}
					else if (this.buffType[k] == 197)
					{
						this.slowOgreSpit = true;
					}
					else if (this.buffType[k] == 198)
					{
						this.parryDamageBuff = true;
					}
					else if (this.buffType[k] == 145)
					{
						this.moonLeech = true;
					}
					else if (this.buffType[k] == 149)
					{
						this.webbed = true;
						if (this.velocity.Y != 0f)
						{
							this.velocity = new Vector2(0f, 1E-06f);
						}
						else
						{
							this.velocity = Vector2.Zero;
						}
						Player.jumpHeight = 0;
						this.gravity = 0f;
						this.moveSpeed = 0f;
						this.dash = 0;
						this.noKnockback = true;
						this.grappling[0] = -1;
						this.grapCount = 0;
						for (int num24 = 0; num24 < 1000; num24++)
						{
							if (Main.projectile[num24].active && Main.projectile[num24].owner == this.whoAmI && Main.projectile[num24].aiStyle == 7)
							{
								Main.projectile[num24].Kill();
							}
						}
					}
					else if (this.buffType[k] == 43)
					{
						this.defendedByPaladin = true;
					}
					else if (this.buffType[k] == 29)
					{
						this.magicCrit += 2;
						this.magicDamage += 0.05f;
						this.statManaMax2 += 20;
						this.manaCost -= 0.02f;
					}
					else if (this.buffType[k] == 28)
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
							this.DelBuff(k);
							k--;
						}
					}
					else if (this.buffType[k] == 33)
					{
						this.meleeDamage -= 0.051f;
						this.meleeSpeed -= 0.051f;
						this.statDefense -= 4;
						this.moveSpeed -= 0.1f;
					}
					else if (this.buffType[k] == 25)
					{
						this.statDefense -= 4;
						this.meleeCrit += 2;
						this.meleeDamage += 0.1f;
						this.meleeSpeed += 0.1f;
					}
					else if (this.buffType[k] == 26)
					{
						this.wellFed = true;
						this.statDefense += 2;
						this.meleeCrit += 2;
						this.meleeDamage += 0.05f;
						this.meleeSpeed += 0.05f;
						this.magicCrit += 2;
						this.magicDamage += 0.05f;
						this.rangedCrit += 2;
						this.rangedDamage += 0.05f;
						this.thrownCrit += 2;
						this.thrownDamage += 0.05f;
						this.minionDamage += 0.05f;
						this.minionKB += 0.5f;
						this.moveSpeed += 0.2f;
					}
					else if (this.buffType[k] == 71)
					{
						this.meleeEnchant = 1;
					}
					else if (this.buffType[k] == 73)
					{
						this.meleeEnchant = 2;
					}
					else if (this.buffType[k] == 74)
					{
						this.meleeEnchant = 3;
					}
					else if (this.buffType[k] == 75)
					{
						this.meleeEnchant = 4;
					}
					else if (this.buffType[k] == 76)
					{
						this.meleeEnchant = 5;
					}
					else if (this.buffType[k] == 77)
					{
						this.meleeEnchant = 6;
					}
					else if (this.buffType[k] == 78)
					{
						this.meleeEnchant = 7;
					}
					else if (this.buffType[k] == 79)
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
			this.ownedLargeGems = 0;
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
			this.windPushed = false; this.ballistaPanic = false;
			this.setVortex = (this.setNebula = (this.setStardust = false));
			this.setForbidden = false;
			this.setHuntressT3 = false;
			this.setSquireT3 = false;
			this.setMonkT3 = false;
			this.setApprenticeT3 = false;
			this.setHuntressT2 = false;
			this.setSquireT2 = false;
			this.setMonkT2 = false;
			this.setApprenticeT2 = false;
			this.setForbiddenCooldownLocked = false;
			this.setSolar = (this.setVortex = (this.setNebula = (this.setStardust = false)));
			this.nebulaLevelDamage = (this.nebulaLevelLife = (this.nebulaLevelMana = 0));
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
			for (int j = 0; j < this.npcTypeNoAggro.Length; j++)
			{
				this.npcTypeNoAggro[j] = false;
			}
			if (this.difficulty == 2)
			{
				if (this.respawnTimer > 0)
				{
					this.respawnTimer--;
					return;
				}
				if (this.whoAmI == Main.myPlayer || Main.netMode == 2)
				{
					this.ghost = true;
					return;
				}
			}
			else
			{
				this.respawnTimer--;
				if (this.respawnTimer <= 0 && Main.myPlayer == this.whoAmI)
				{
					if (Main.mouseItem.type > 0)
					{
						Main.playerInventory = true;
					}
					this.Spawn();
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
			this.cGrapple = (this.cMount = (this.cMinecart = (this.cPet = (this.cLight = (this.cYorai = 0)))));
			if (this.dye[0] != null)
			{
				this.cHead = (int)this.dye[0].dye;
			}
			if (this.dye[1] != null)
			{
				this.cBody = (int)this.dye[1].dye;
			}
			if (this.dye[2] != null)
			{
				this.cLegs = (int)this.dye[2].dye;
			}
			if (this.wearsRobe)
			{
				this.cLegs = this.cBody;
			}
			if (this.miscDyes[0] != null)
			{
				this.cPet = (int)this.miscDyes[0].dye;
			}
			if (this.miscDyes[1] != null)
			{
				this.cLight = (int)this.miscDyes[1].dye;
			}
			if (this.miscDyes[2] != null)
			{
				this.cMinecart = (int)this.miscDyes[2].dye;
			}
			if (this.miscDyes[3] != null)
			{
				this.cMount = (int)this.miscDyes[3].dye;
			}
			if (this.miscDyes[4] != null)
			{
				this.cGrapple = (int)this.miscDyes[4].dye;
			}
			for (int i = 0; i < 20; i++)
			{
				int num = i % 10;
				if (this.dye[num] != null && this.armor[i].type > 0 && this.armor[i].stack > 0 && (i / 10 >= 1 || !this.hideVisual[num] || this.armor[i].wingSlot > 0 || this.armor[i].type == 934))
				{
					if (this.armor[i].handOnSlot > 0 && this.armor[i].handOnSlot < 20)
					{
						this.cHandOn = (int)this.dye[num].dye;
					}
					if (this.armor[i].handOffSlot > 0 && this.armor[i].handOffSlot < 12)
					{
						this.cHandOff = (int)this.dye[num].dye;
					}
					if (this.armor[i].backSlot > 0 && this.armor[i].backSlot < 14)
					{
						this.cBack = (int)this.dye[num].dye;
					}
					if (this.armor[i].frontSlot > 0 && this.armor[i].frontSlot < 5)
					{
						this.cFront = (int)this.dye[num].dye;
					}
					if (this.armor[i].shoeSlot > 0 && this.armor[i].shoeSlot < 18)
					{
						this.cShoe = (int)this.dye[num].dye;
					}
					if (this.armor[i].waistSlot > 0 && this.armor[i].waistSlot < 13)
					{
						this.cWaist = (int)this.dye[num].dye;
					}
					if (this.armor[i].shieldSlot > 0 && this.armor[i].shieldSlot < 7)
					{
						this.cShield = (int)this.dye[num].dye;
					}
					if (this.armor[i].neckSlot > 0 && this.armor[i].neckSlot < 10)
					{
						this.cNeck = (int)this.dye[num].dye;
					}
					if (this.armor[i].faceSlot > 0 && this.armor[i].faceSlot < 9)
					{
						this.cFace = (int)this.dye[num].dye;
					}
					if (this.armor[i].balloonSlot > 0 && this.armor[i].balloonSlot < 18)
					{
						this.cBalloon = (int)this.dye[num].dye;
					}
					if (this.armor[i].wingSlot > 0 && this.armor[i].wingSlot < wings)
					{
						this.cWings = (int)this.dye[num].dye;
					}
					if (this.armor[i].type == 934)
					{
						this.cCarpet = (int)this.dye[num].dye;
					}
				}
			}
			this.cYorai = this.cPet;
		}

		public void UpdateEquips(int i)
		{
			for (int j = 0; j < 58; j++)
			{
				int type = this.inventory[j].type;
				if ((type == 15 || type == 707) && this.accWatch < 1)
				{
					this.accWatch = 1;
				}
				if ((type == 16 || type == 708) && this.accWatch < 2)
				{
					this.accWatch = 2;
				}
				if ((type == 17 || type == 709) && this.accWatch < 3)
				{
					this.accWatch = 3;
				}
				if (type == 393)
				{
					this.accCompass = 1;
				}
				if (type == 18)
				{
					this.accDepthMeter = 1;
				}
				if (type == 395 || type == 3123 || type == 3124)
				{
					this.accWatch = 3;
					this.accDepthMeter = 1;
					this.accCompass = 1;
				}
				if (type == 3120 || type == 3036 || type == 3123 || type == 3124)
				{
					this.accFishFinder = true;
				}
				if (type == 3037 || type == 3036 || type == 3123 || type == 3124)
				{
					this.accWeatherRadio = true;
				}
				if (type == 3096 || type == 3036 || type == 3123 || type == 3124)
				{
					this.accCalendar = true;
				}
				if (type == 3084 || type == 3122 || type == 3123 || type == 3124)
				{
					this.accThirdEye = true;
				}
				if (type == 3095 || type == 3122 || type == 3123 || type == 3124)
				{
					this.accJarOfSouls = true;
				}
				if (type == 3118 || type == 3122 || type == 3123 || type == 3124)
				{
					this.accCritterGuide = true;
				}
				if (type == 3099 || type == 3121 || type == 3123 || type == 3124)
				{
					this.accStopwatch = true;
				}
				if (type == 3102 || type == 3121 || type == 3123 || type == 3124)
				{
					this.accOreFinder = true;
				}
				if (type == 3119 || type == 3121 || type == 3123 || type == 3124)
				{
					this.accDreamCatcher = true;
				}
				if (type == 3619 || type == 3611)
				{
					this.InfoAccMechShowWires = true;
				}
				if (type == 486 || type == 3611)
				{
					this.rulerLine = true;
				}
				if (type == 2799)
				{
					this.rulerGrid = true;
				}
				if (type == 2216 || type == 3061)
				{
					this.autoPaint = true;
				}
				if (type == 3624)
				{
					this.autoActuator = true;
				}
			}
			for (int k = 0; k < 8 + this.extraAccessorySlots; k++)
			{
				if (!this.armor[k].expertOnly || Main.expertMode)
				{
					int type2 = this.armor[k].type;
					if ((type2 == 15 || type2 == 707) && this.accWatch < 1)
					{
						this.accWatch = 1;
					}
					if ((type2 == 16 || type2 == 708) && this.accWatch < 2)
					{
						this.accWatch = 2;
					}
					if ((type2 == 17 || type2 == 709) && this.accWatch < 3)
					{
						this.accWatch = 3;
					}
					if (type2 == 393)
					{
						this.accCompass = 1;
					}
					if (type2 == 18)
					{
						this.accDepthMeter = 1;
					}
					if (type2 == 395 || type2 == 3123 || type2 == 3124)
					{
						this.accWatch = 3;
						this.accDepthMeter = 1;
						this.accCompass = 1;
					}
					if (type2 == 3120 || type2 == 3036 || type2 == 3123 || type2 == 3124)
					{
						this.accFishFinder = true;
					}
					if (type2 == 3037 || type2 == 3036 || type2 == 3123 || type2 == 3124)
					{
						this.accWeatherRadio = true;
					}
					if (type2 == 3096 || type2 == 3036 || type2 == 3123 || type2 == 3124)
					{
						this.accCalendar = true;
					}
					if (type2 == 3084 || type2 == 3122 || type2 == 3123 || type2 == 3124)
					{
						this.accThirdEye = true;
					}
					if (type2 == 3095 || type2 == 3122 || type2 == 3123 || type2 == 3124)
					{
						this.accJarOfSouls = true;
					}
					if (type2 == 3118 || type2 == 3122 || type2 == 3123 || type2 == 3124)
					{
						this.accCritterGuide = true;
					}
					if (type2 == 3099 || type2 == 3121 || type2 == 3123 || type2 == 3124)
					{
						this.accStopwatch = true;
					}
					if (type2 == 3102 || type2 == 3121 || type2 == 3123 || type2 == 3124)
					{
						this.accOreFinder = true;
					}
					if (type2 == 3119 || type2 == 3121 || type2 == 3123 || type2 == 3124)
					{
						this.accDreamCatcher = true;
					}
					if (type2 == 3619)
					{
						this.InfoAccMechShowWires = true;
					}
					if (this.armor[k].type == 3017 && this.whoAmI == Main.myPlayer && this.velocity.Y == 0f && this.grappling[0] == -1)
					{
						int num = (int)base.Center.X / 16;
						int num2 = (int)(this.position.Y + (float)this.height - 1f) / 16;
						if (Main.tile[num, num2] == null)
						{
							Main.tile[num, num2] = new Tile();
						}
						if (!Main.tile[num, num2].active() && Main.tile[num, num2].liquid == 0 && Main.tile[num, num2 + 1] != null && WorldGen.SolidTile(num, num2 + 1))
						{
							Main.tile[num, num2].frameY = 0;
							Main.tile[num, num2].slope(0);
							Main.tile[num, num2].halfBrick(false);
							if (Main.tile[num, num2 + 1].type == 2)
							{
								if (Main.rand.Next(2) == 0)
								{
									Main.tile[num, num2].active(true);
									Main.tile[num, num2].type = 3;
									Main.tile[num, num2].frameX = (short)(18 * Main.rand.Next(6, 11));
									while (Main.tile[num, num2].frameX == 144)
									{
										Main.tile[num, num2].frameX = (short)(18 * Main.rand.Next(6, 11));
									}
								}
								else
								{
									Main.tile[num, num2].active(true);
									Main.tile[num, num2].type = 73;
									Main.tile[num, num2].frameX = (short)(18 * Main.rand.Next(6, 21));
									while (Main.tile[num, num2].frameX == 144)
									{
										Main.tile[num, num2].frameX = (short)(18 * Main.rand.Next(6, 21));
									}
								}
								if (Main.netMode == 1)
								{
									NetMessage.SendTileSquare(-1, num, num2, 1, TileChangeType.None);
								}
							}
							else if (Main.tile[num, num2 + 1].type == 109)
							{
								if (Main.rand.Next(2) == 0)
								{
									Main.tile[num, num2].active(true);
									Main.tile[num, num2].type = 110;
									Main.tile[num, num2].frameX = (short)(18 * Main.rand.Next(4, 7));
									while (Main.tile[num, num2].frameX == 90)
									{
										Main.tile[num, num2].frameX = (short)(18 * Main.rand.Next(4, 7));
									}
								}
								else
								{
									Main.tile[num, num2].active(true);
									Main.tile[num, num2].type = 113;
									Main.tile[num, num2].frameX = (short)(18 * Main.rand.Next(2, 8));
									while (Main.tile[num, num2].frameX == 90)
									{
										Main.tile[num, num2].frameX = (short)(18 * Main.rand.Next(2, 8));
									}
								}
								if (Main.netMode == 1)
								{
									NetMessage.SendTileSquare(-1, num, num2, 1, TileChangeType.None);
								}
							}
							else if (Main.tile[num, num2 + 1].type == 60)
							{
								Main.tile[num, num2].active(true);
								Main.tile[num, num2].type = 74;
								Main.tile[num, num2].frameX = (short)(18 * Main.rand.Next(9, 17));
								if (Main.netMode == 1)
								{
									NetMessage.SendTileSquare(-1, num, num2, 1, TileChangeType.None);
								}
							}
						}
					}
					this.statDefense += this.armor[k].defense;
					this.lifeRegen += this.armor[k].lifeRegen;
					if (this.armor[k].shieldSlot > 0)
					{
						this.hasRaisableShield = true;
					}
					int type3 = this.armor[k].type;
					int num3 = type3;
					switch (num3)
					{
						case 3797:
							this.maxTurrets++;
							this.manaCost -= 0.1f;
							break;
						case 3798:
							this.magicDamage += 0.1f;
							this.minionDamage += 0.2f;
							break;
						case 3799:
							this.minionDamage += 0.1f;
							this.magicCrit += 20;
							break;
						case 3800:
							this.maxTurrets++;
							this.lifeRegen += 8;
							break;
						case 3801:
							this.meleeDamage += 0.15f;
							this.minionDamage += 0.15f;
							break;
						case 3802:
							this.minionDamage += 0.15f;
							this.meleeCrit += 20;
							this.moveSpeed += 0.2f;
							break;
						case 3803:
							this.maxTurrets++;
							this.rangedCrit += 10;
							break;
						case 3804:
							this.rangedDamage += 0.2f;
							this.minionDamage += 0.2f;
							break;
						case 3805:
							this.minionDamage += 0.1f;
							this.moveSpeed += 0.2f;
							break;
						case 3806:
							this.maxTurrets++;
							this.meleeSpeed += 0.2f;
							break;
						case 3807:
							this.meleeDamage += 0.2f;
							this.minionDamage += 0.2f;
							break;
						case 3808:
							this.minionDamage += 0.1f;
							this.meleeCrit += 10;
							this.moveSpeed += 0.2f;
							break;
						default:
							switch (num3)
							{
								case 3871:
									this.maxTurrets += 2;
									this.minionDamage += 0.1f;
									break;
								case 3872:
									this.minionDamage += 0.3f;
									this.lifeRegen += 16;
									break;
								case 3873:
									this.minionDamage += 0.2f;
									this.meleeCrit += 20;
									this.moveSpeed += 0.3f;
									break;
								case 3874:
									this.maxTurrets += 2;
									this.magicDamage += 0.1f;
									this.minionDamage += 0.1f;
									break;
								case 3875:
									this.minionDamage += 0.3f;
									this.magicDamage += 0.15f;
									break;
								case 3876:
									this.minionDamage += 0.2f;
									this.magicCrit += 25;
									break;
								case 3877:
									this.maxTurrets += 2;
									this.minionDamage += 0.1f;
									this.rangedCrit += 10;
									break;
								case 3878:
									this.minionDamage += 0.25f;
									this.rangedDamage += 0.25f;
									break;
								case 3879:
									this.minionDamage += 0.25f;
									this.moveSpeed += 0.2f;
									break;
								case 3880:
									this.maxTurrets += 2;
									this.minionDamage += 0.2f;
									this.meleeDamage += 0.2f;
									break;
								case 3881:
									this.meleeSpeed += 0.2f;
									this.minionDamage += 0.2f;
									break;
								case 3882:
									this.minionDamage += 0.2f;
									this.meleeCrit += 20;
									this.moveSpeed += 0.2f;
									break;
							}
							break;
					}
					if (this.armor[k].type == 268)
					{
						this.accDivingHelm = true;
					}
					if (this.armor[k].type == 238)
					{
						this.magicDamage += 0.15f;
					}
					if (this.armor[k].type == 3770)
					{
						this.slowFall = true;
					}
					if (this.armor[k].type == 3776)
					{
						this.magicDamage += 0.15f;
						this.minionDamage += 0.15f;
					}
					if (this.armor[k].type == 3777)
					{
						this.statManaMax2 += 80;
					}
					if (this.armor[k].type == 3778)
					{
						this.maxMinions += 2;
					}
					if (this.armor[k].type == 3212)
					{
						this.armorPenetration += 5;
					}
					if (this.armor[k].type == 2277)
					{
						this.magicDamage += 0.05f;
						this.meleeDamage += 0.05f;
						this.rangedDamage += 0.05f;
						this.thrownDamage += 0.05f;
						this.magicCrit += 5;
						this.rangedCrit += 5;
						this.meleeCrit += 5;
						this.thrownCrit += 5;
						this.meleeSpeed += 0.1f;
						this.moveSpeed += 0.1f;
					}
					if (this.armor[k].type == 2279)
					{
						this.magicDamage += 0.06f;
						this.magicCrit += 6;
						this.manaCost -= 0.1f;
					}
					if (this.armor[k].type == 3109)
					{
						this.nightVision = true;
					}
					if (this.armor[k].type == 256)
					{
						this.thrownVelocity += 0.15f;
					}
					if (this.armor[k].type == 257)
					{
						this.thrownDamage += 0.15f;
					}
					if (this.armor[k].type == 258)
					{
						this.thrownCrit += 10;
					}
					if (this.armor[k].type == 3374)
					{
						this.thrownVelocity += 0.2f;
					}
					if (this.armor[k].type == 3375)
					{
						this.thrownDamage += 0.2f;
					}
					if (this.armor[k].type == 3376)
					{
						this.thrownCrit += 15;
					}
					if (this.armor[k].type == 2275)
					{
						this.magicDamage += 0.07f;
						this.magicCrit += 7;
					}
					if (this.armor[k].type == 123 || this.armor[k].type == 124 || this.armor[k].type == 125)
					{
						this.magicDamage += 0.07f;
					}
					if (this.armor[k].type == 151 || this.armor[k].type == 152 || this.armor[k].type == 153 || this.armor[k].type == 959)
					{
						this.rangedDamage += 0.05f;
					}
					if (this.armor[k].type == 111 || this.armor[k].type == 228 || this.armor[k].type == 229 || this.armor[k].type == 230 || this.armor[k].type == 960 || this.armor[k].type == 961 || this.armor[k].type == 962)
					{
						this.statManaMax2 += 20;
					}
					if (this.armor[k].type == 228 || this.armor[k].type == 960)
					{
						this.statManaMax2 += 20;
					}
					if (this.armor[k].type == 228 || this.armor[k].type == 229 || this.armor[k].type == 230 || this.armor[k].type == 960 || this.armor[k].type == 961 || this.armor[k].type == 962)
					{
						this.magicCrit += 4;
					}
					if (this.armor[k].type == 100 || this.armor[k].type == 101 || this.armor[k].type == 102)
					{
						this.meleeSpeed += 0.07f;
					}
					if (this.armor[k].type == 956 || this.armor[k].type == 957 || this.armor[k].type == 958)
					{
						this.meleeSpeed += 0.07f;
					}
					if (this.armor[k].type == 792 || this.armor[k].type == 793 || this.armor[k].type == 794)
					{
						this.meleeDamage += 0.02f;
						this.rangedDamage += 0.02f;
						this.magicDamage += 0.02f;
						this.thrownDamage += 0.02f;
					}
					if (this.armor[k].type == 371)
					{
						this.magicCrit += 9;
						this.statManaMax2 += 40;
					}
					if (this.armor[k].type == 372)
					{
						this.moveSpeed += 0.07f;
						this.meleeSpeed += 0.12f;
					}
					if (this.armor[k].type == 373)
					{
						this.rangedDamage += 0.1f;
						this.rangedCrit += 6;
					}
					if (this.armor[k].type == 374)
					{
						this.magicCrit += 3;
						this.meleeCrit += 3;
						this.rangedCrit += 3;
					}
					if (this.armor[k].type == 375)
					{
						this.moveSpeed += 0.1f;
					}
					if (this.armor[k].type == 376)
					{
						this.magicDamage += 0.15f;
						this.statManaMax2 += 60;
					}
					if (this.armor[k].type == 377)
					{
						this.meleeCrit += 5;
						this.meleeDamage += 0.1f;
					}
					if (this.armor[k].type == 378)
					{
						this.rangedDamage += 0.12f;
						this.rangedCrit += 7;
					}
					if (this.armor[k].type == 379)
					{
						this.rangedDamage += 0.05f;
						this.meleeDamage += 0.05f;
						this.magicDamage += 0.05f;
					}
					if (this.armor[k].type == 380)
					{
						this.magicCrit += 3;
						this.meleeCrit += 3;
						this.rangedCrit += 3;
					}
					if (this.armor[k].type >= 2367 && this.armor[k].type <= 2369)
					{
						this.fishingSkill += 5;
					}
					if (this.armor[k].type == 400)
					{
						this.magicDamage += 0.11f;
						this.magicCrit += 11;
						this.statManaMax2 += 80;
					}
					if (this.armor[k].type == 401)
					{
						this.meleeCrit += 7;
						this.meleeDamage += 0.14f;
					}
					if (this.armor[k].type == 402)
					{
						this.rangedDamage += 0.14f;
						this.rangedCrit += 8;
					}
					if (this.armor[k].type == 403)
					{
						this.rangedDamage += 0.06f;
						this.meleeDamage += 0.06f;
						this.magicDamage += 0.06f;
					}
					if (this.armor[k].type == 404)
					{
						this.magicCrit += 4;
						this.meleeCrit += 4;
						this.rangedCrit += 4;
						this.moveSpeed += 0.05f;
					}
					if (this.armor[k].type == 1205)
					{
						this.meleeDamage += 0.08f;
						this.meleeSpeed += 0.12f;
					}
					if (this.armor[k].type == 1206)
					{
						this.rangedDamage += 0.09f;
						this.rangedCrit += 9;
					}
					if (this.armor[k].type == 1207)
					{
						this.magicDamage += 0.07f;
						this.magicCrit += 7;
						this.statManaMax2 += 60;
					}
					if (this.armor[k].type == 1208)
					{
						this.meleeDamage += 0.03f;
						this.rangedDamage += 0.03f;
						this.magicDamage += 0.03f;
						this.magicCrit += 2;
						this.meleeCrit += 2;
						this.rangedCrit += 2;
					}
					if (this.armor[k].type == 1209)
					{
						this.meleeDamage += 0.02f;
						this.rangedDamage += 0.02f;
						this.magicDamage += 0.02f;
						this.magicCrit++;
						this.meleeCrit++;
						this.rangedCrit++;
					}
					if (this.armor[k].type == 1210)
					{
						this.meleeDamage += 0.07f;
						this.meleeSpeed += 0.07f;
						this.moveSpeed += 0.07f;
					}
					if (this.armor[k].type == 1211)
					{
						this.rangedCrit += 15;
						this.moveSpeed += 0.08f;
					}
					if (this.armor[k].type == 1212)
					{
						this.magicCrit += 18;
						this.statManaMax2 += 80;
					}
					if (this.armor[k].type == 1213)
					{
						this.magicCrit += 6;
						this.meleeCrit += 6;
						this.rangedCrit += 6;
					}
					if (this.armor[k].type == 1214)
					{
						this.moveSpeed += 0.11f;
					}
					if (this.armor[k].type == 1215)
					{
						this.meleeDamage += 0.08f;
						this.meleeCrit += 8;
						this.meleeSpeed += 0.08f;
					}
					if (this.armor[k].type == 1216)
					{
						this.rangedDamage += 0.16f;
						this.rangedCrit += 7;
					}
					if (this.armor[k].type == 1217)
					{
						this.magicDamage += 0.16f;
						this.magicCrit += 7;
						this.statManaMax2 += 100;
					}
					if (this.armor[k].type == 1218)
					{
						this.meleeDamage += 0.04f;
						this.rangedDamage += 0.04f;
						this.magicDamage += 0.04f;
						this.magicCrit += 3;
						this.meleeCrit += 3;
						this.rangedCrit += 3;
					}
					if (this.armor[k].type == 1219)
					{
						this.meleeDamage += 0.03f;
						this.rangedDamage += 0.03f;
						this.magicDamage += 0.03f;
						this.magicCrit += 3;
						this.meleeCrit += 3;
						this.rangedCrit += 3;
						this.moveSpeed += 0.06f;
					}
					if (this.armor[k].type == 558)
					{
						this.magicDamage += 0.12f;
						this.magicCrit += 12;
						this.statManaMax2 += 100;
					}
					if (this.armor[k].type == 559)
					{
						this.meleeCrit += 10;
						this.meleeDamage += 0.1f;
						this.meleeSpeed += 0.1f;
					}
					if (this.armor[k].type == 553)
					{
						this.rangedDamage += 0.15f;
						this.rangedCrit += 8;
					}
					if (this.armor[k].type == 551)
					{
						this.magicCrit += 7;
						this.meleeCrit += 7;
						this.rangedCrit += 7;
					}
					if (this.armor[k].type == 552)
					{
						this.rangedDamage += 0.07f;
						this.meleeDamage += 0.07f;
						this.magicDamage += 0.07f;
						this.moveSpeed += 0.08f;
					}
					if (this.armor[k].type == 1001)
					{
						this.meleeDamage += 0.16f;
						this.meleeCrit += 6;
					}
					if (this.armor[k].type == 1002)
					{
						this.rangedDamage += 0.16f;
						this.ammoCost80 = true;
					}
					if (this.armor[k].type == 1003)
					{
						this.statManaMax2 += 80;
						this.manaCost -= 0.17f;
						this.magicDamage += 0.16f;
					}
					if (this.armor[k].type == 1004)
					{
						this.meleeDamage += 0.05f;
						this.magicDamage += 0.05f;
						this.rangedDamage += 0.05f;
						this.magicCrit += 7;
						this.meleeCrit += 7;
						this.rangedCrit += 7;
					}
					if (this.armor[k].type == 1005)
					{
						this.magicCrit += 8;
						this.meleeCrit += 8;
						this.rangedCrit += 8;
						this.moveSpeed += 0.05f;
					}
					if (this.armor[k].type == 2189)
					{
						this.statManaMax2 += 60;
						this.manaCost -= 0.13f;
						this.magicDamage += 0.05f;
						this.magicCrit += 5;
					}
					if (this.armor[k].type == 1503)
					{
						this.magicDamage -= 0.4f;
					}
					if (this.armor[k].type == 1504)
					{
						this.magicDamage += 0.07f;
						this.magicCrit += 7;
					}
					if (this.armor[k].type == 1505)
					{
						this.magicDamage += 0.08f;
						this.moveSpeed += 0.08f;
					}
					if (this.armor[k].type == 1546)
					{
						this.rangedCrit += 5;
						this.arrowDamage += 0.15f;
					}
					if (this.armor[k].type == 1547)
					{
						this.rangedCrit += 5;
						this.bulletDamage += 0.15f;
					}
					if (this.armor[k].type == 1548)
					{
						this.rangedCrit += 5;
						this.rocketDamage += 0.15f;
					}
					if (this.armor[k].type == 1549)
					{
						this.rangedCrit += 13;
						this.rangedDamage += 0.13f;
						this.ammoCost80 = true;
					}
					if (this.armor[k].type == 1550)
					{
						this.rangedCrit += 7;
						this.moveSpeed += 0.12f;
					}
					if (this.armor[k].type == 1282)
					{
						this.statManaMax2 += 20;
						this.manaCost -= 0.05f;
					}
					if (this.armor[k].type == 1283)
					{
						this.statManaMax2 += 40;
						this.manaCost -= 0.07f;
					}
					if (this.armor[k].type == 1284)
					{
						this.statManaMax2 += 40;
						this.manaCost -= 0.09f;
					}
					if (this.armor[k].type == 1285)
					{
						this.statManaMax2 += 60;
						this.manaCost -= 0.11f;
					}
					if (this.armor[k].type == 1286)
					{
						this.statManaMax2 += 60;
						this.manaCost -= 0.13f;
					}
					if (this.armor[k].type == 1287)
					{
						this.statManaMax2 += 80;
						this.manaCost -= 0.15f;
					}
					if (this.armor[k].type == 1316 || this.armor[k].type == 1317 || this.armor[k].type == 1318)
					{
						this.aggro += 250;
					}
					if (this.armor[k].type == 1316)
					{
						this.meleeDamage += 0.06f;
					}
					if (this.armor[k].type == 1317)
					{
						this.meleeDamage += 0.08f;
						this.meleeCrit += 8;
					}
					if (this.armor[k].type == 1318)
					{
						this.meleeCrit += 4;
					}
					if (this.armor[k].type == 2199 || this.armor[k].type == 2202)
					{
						this.aggro += 250;
					}
					if (this.armor[k].type == 2201)
					{
						this.aggro += 400;
					}
					if (this.armor[k].type == 2199)
					{
						this.meleeDamage += 0.06f;
					}
					if (this.armor[k].type == 2200)
					{
						this.meleeDamage += 0.08f;
						this.meleeCrit += 8;
						this.meleeSpeed += 0.06f;
						this.moveSpeed += 0.06f;
					}
					if (this.armor[k].type == 2201)
					{
						this.meleeDamage += 0.05f;
						this.meleeCrit += 5;
					}
					if (this.armor[k].type == 2202)
					{
						this.meleeSpeed += 0.06f;
						this.moveSpeed += 0.06f;
					}
					if (this.armor[k].type == 684)
					{
						this.rangedDamage += 0.16f;
						this.meleeDamage += 0.16f;
					}
					if (this.armor[k].type == 685)
					{
						this.meleeCrit += 11;
						this.rangedCrit += 11;
					}
					if (this.armor[k].type == 686)
					{
						this.moveSpeed += 0.08f;
						this.meleeSpeed += 0.07f;
					}
					if (this.armor[k].type == 2361)
					{
						this.maxMinions++;
						this.minionDamage += 0.04f;
					}
					if (this.armor[k].type == 2362)
					{
						this.maxMinions++;
						this.minionDamage += 0.04f;
					}
					if (this.armor[k].type == 2363)
					{
						this.minionDamage += 0.05f;
					}
					if (this.armor[k].type >= 1158 && this.armor[k].type <= 1161)
					{
						this.maxMinions++;
					}
					if (this.armor[k].type >= 1159 && this.armor[k].type <= 1161)
					{
						this.minionDamage += 0.1f;
					}
					if (this.armor[k].type >= 2370 && this.armor[k].type <= 2371)
					{
						this.minionDamage += 0.05f;
						this.maxMinions++;
					}
					if (this.armor[k].type == 2372)
					{
						this.minionDamage += 0.06f;
						this.maxMinions++;
					}
					if (this.armor[k].type == 3381 || this.armor[k].type == 3382 || this.armor[k].type == 3383)
					{
						if (this.armor[k].type != 3381)
						{
							this.maxMinions++;
						}
						this.maxMinions++;
						this.minionDamage += 0.22f;
					}
					if (this.armor[k].type == 2763)
					{
						this.aggro += 300;
						this.meleeCrit += 17;
					}
					if (this.armor[k].type == 2764)
					{
						this.aggro += 300;
						this.meleeDamage += 0.22f;
					}
					if (this.armor[k].type == 2765)
					{
						this.aggro += 300;
						this.meleeSpeed += 0.15f;
						this.moveSpeed += 0.15f;
					}
					if (this.armor[k].type == 2757)
					{
						this.rangedCrit += 7;
						this.rangedDamage += 0.16f;
					}
					if (this.armor[k].type == 2758)
					{
						this.ammoCost75 = true;
						this.rangedCrit += 12;
						this.rangedDamage += 0.12f;
					}
					if (this.armor[k].type == 2759)
					{
						this.rangedCrit += 8;
						this.rangedDamage += 0.08f;
						this.moveSpeed += 0.1f;
					}
					if (this.armor[k].type == 2760)
					{
						this.statManaMax2 += 60;
						this.manaCost -= 0.15f;
						this.magicCrit += 7;
						this.magicDamage += 0.07f;
					}
					if (this.armor[k].type == 2761)
					{
						this.magicDamage += 0.09f;
						this.magicCrit += 9;
					}
					if (this.armor[k].type == 2762)
					{
						this.moveSpeed += 0.1f;
						this.magicDamage += 0.1f;
					}
					if (this.armor[k].type >= 1832 && this.armor[k].type <= 1834)
					{
						this.maxMinions++;
					}
					if (this.armor[k].type >= 1832 && this.armor[k].type <= 1834)
					{
						this.minionDamage += 0.11f;
					}
					if (this.armor[k].prefix == 62)
					{
						this.statDefense++;
					}
					if (this.armor[k].prefix == 63)
					{
						this.statDefense += 2;
					}
					if (this.armor[k].prefix == 64)
					{
						this.statDefense += 3;
					}
					if (this.armor[k].prefix == 65)
					{
						this.statDefense += 4;
					}
					if (this.armor[k].prefix == 66)
					{
						this.statManaMax2 += 20;
					}
					if (this.armor[k].prefix == 67)
					{
						this.meleeCrit += 2;
						this.rangedCrit += 2;
						this.magicCrit += 2;
						this.thrownCrit += 2;
					}
					if (this.armor[k].prefix == 68)
					{
						this.meleeCrit += 4;
						this.rangedCrit += 4;
						this.magicCrit += 4;
						this.thrownCrit += 4;
					}
					if (this.armor[k].prefix == 69)
					{
						this.meleeDamage += 0.01f;
						this.rangedDamage += 0.01f;
						this.magicDamage += 0.01f;
						this.minionDamage += 0.01f;
						this.thrownDamage += 0.01f;
					}
					if (this.armor[k].prefix == 70)
					{
						this.meleeDamage += 0.02f;
						this.rangedDamage += 0.02f;
						this.magicDamage += 0.02f;
						this.minionDamage += 0.02f;
						this.thrownDamage += 0.02f;
					}
					if (this.armor[k].prefix == 71)
					{
						this.meleeDamage += 0.03f;
						this.rangedDamage += 0.03f;
						this.magicDamage += 0.03f;
						this.minionDamage += 0.03f;
						this.thrownDamage += 0.03f;
					}
					if (this.armor[k].prefix == 72)
					{
						this.meleeDamage += 0.04f;
						this.rangedDamage += 0.04f;
						this.magicDamage += 0.04f;
						this.minionDamage += 0.04f;
						this.thrownDamage += 0.04f;
					}
					if (this.armor[k].prefix == 73)
					{
						this.moveSpeed += 0.01f;
					}
					if (this.armor[k].prefix == 74)
					{
						this.moveSpeed += 0.02f;
					}
					if (this.armor[k].prefix == 75)
					{
						this.moveSpeed += 0.03f;
					}
					if (this.armor[k].prefix == 76)
					{
						this.moveSpeed += 0.04f;
					}
					if (this.armor[k].prefix == 77)
					{
						this.meleeSpeed += 0.01f;
					}
					if (this.armor[k].prefix == 78)
					{
						this.meleeSpeed += 0.02f;
					}
					if (this.armor[k].prefix == 79)
					{
						this.meleeSpeed += 0.03f;
					}
					if (this.armor[k].prefix == 80)
					{
						this.meleeSpeed += 0.04f;
					}
				}
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			for (int l = 3; l < 8 + this.extraAccessorySlots; l++)
			{
				if (!this.armor[l].expertOnly || Main.expertMode)
				{
					if (this.armor[l].type == 3810 || this.armor[l].type == 3809 || this.armor[l].type == 3812 || this.armor[l].type == 3811)
					{
						this.dd2Accessory = true;
					}
					if (this.armor[l].type == 3015)
					{
						this.aggro -= 400;
						this.meleeCrit += 5;
						this.magicCrit += 5;
						this.rangedCrit += 5;
						this.thrownCrit += 5;
						this.meleeDamage += 0.05f;
						this.magicDamage += 0.05f;
						this.rangedDamage += 0.05f;
						this.thrownDamage += 0.05f;
						this.minionDamage += 0.05f;
					}
					if (this.armor[l].type == 3016)
					{
						this.aggro += 400;
					}
					if (this.armor[l].type == 2373)
					{
						this.accFishingLine = true;
					}
					if (this.armor[l].type == 2374)
					{
						this.fishingSkill += 10;
					}
					if (this.armor[l].type == 2375)
					{
						this.accTackleBox = true;
					}
					if (this.armor[l].type == 3721)
					{
						this.accFishingLine = true;
						this.accTackleBox = true;
						this.fishingSkill += 10;
					}
					if (this.armor[l].type == 3090)
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
					if (this.armor[l].stringColor > 0)
					{
						this.yoyoString = true;
					}
					if (this.armor[l].type == 3366)
					{
						this.counterWeight = 556 + Main.rand.Next(6);
						this.yoyoGlove = true;
						this.yoyoString = true;
					}
					if (this.armor[l].type >= 3309 && this.armor[l].type <= 3314)
					{
						this.counterWeight = 556 + this.armor[l].type - 3309;
					}
					if (this.armor[l].type == 3334)
					{
						this.yoyoGlove = true;
					}
					if (this.armor[l].type == 3337)
					{
						this.shinyStone = true;
					}
					if (this.armor[l].type == 3336)
					{
						this.SporeSac();
						this.sporeSac = true;
					}
					if (this.armor[l].type == 2423)
					{
						this.autoJump = true;
						this.jumpSpeedBoost += 2.4f;
						this.extraFall += 15;
					}
					if (this.armor[l].type == 857)
					{
						this.doubleJumpSandstorm = true;
					}
					if (this.armor[l].type == 983)
					{
						this.doubleJumpSandstorm = true;
						this.jumpBoost = true;
					}
					if (this.armor[l].type == 987)
					{
						this.doubleJumpBlizzard = true;
					}
					if (this.armor[l].type == 1163)
					{
						this.doubleJumpBlizzard = true;
						this.jumpBoost = true;
					}
					if (this.armor[l].type == 1724)
					{
						this.doubleJumpFart = true;
					}
					if (this.armor[l].type == 1863)
					{
						this.doubleJumpFart = true;
						this.jumpBoost = true;
					}
					if (this.armor[l].type == 1164)
					{
						this.doubleJumpCloud = true;
						this.doubleJumpSandstorm = true;
						this.doubleJumpBlizzard = true;
						this.jumpBoost = true;
					}
					if (this.armor[l].type == 1250)
					{
						this.jumpBoost = true;
						this.doubleJumpCloud = true;
						this.noFallDmg = true;
					}
					if (this.armor[l].type == 1252)
					{
						this.doubleJumpSandstorm = true;
						this.jumpBoost = true;
						this.noFallDmg = true;
					}
					if (this.armor[l].type == 1251)
					{
						this.doubleJumpBlizzard = true;
						this.jumpBoost = true;
						this.noFallDmg = true;
					}
					if (this.armor[l].type == 3250)
					{
						this.doubleJumpFart = true;
						this.jumpBoost = true;
						this.noFallDmg = true;
					}
					if (this.armor[l].type == 3252)
					{
						this.doubleJumpSail = true;
						this.jumpBoost = true;
						this.noFallDmg = true;
					}
					if (this.armor[l].type == 3251)
					{
						this.jumpBoost = true;
						this.bee = true;
						this.noFallDmg = true;
					}
					if (this.armor[l].type == 1249)
					{
						this.jumpBoost = true;
						this.bee = true;
					}
					if (this.armor[l].type == 3241)
					{
						this.jumpBoost = true;
						this.doubleJumpSail = true;
					}
					if (this.armor[l].type == 1253 && (double)this.statLife <= (double)this.statLifeMax2 * 0.5)
					{
						this.AddBuff(62, 5, true);
					}
					if (this.armor[l].type == 1290)
					{
						this.panic = true;
					}
					if ((this.armor[l].type == 1300 || this.armor[l].type == 1858) && (this.inventory[this.selectedItem].useAmmo == 14 || this.inventory[this.selectedItem].useAmmo == 311 || this.inventory[this.selectedItem].useAmmo == 323 || this.inventory[this.selectedItem].useAmmo == 23))
					{
						this.scope = true;
					}
					if (this.armor[l].type == 1858)
					{
						this.rangedCrit += 10;
						this.rangedDamage += 0.1f;
					}
					if (this.armor[l].type == 1301)
					{
						this.meleeCrit += 8;
						this.rangedCrit += 8;
						this.magicCrit += 8;
						this.thrownCrit += 8;
						this.meleeDamage += 0.1f;
						this.rangedDamage += 0.1f;
						this.magicDamage += 0.1f;
						this.minionDamage += 0.1f;
						this.thrownDamage += 0.1f;
					}
					if (this.armor[l].type == 982)
					{
						this.statManaMax2 += 20;
						this.manaRegenDelayBonus++;
						this.manaRegenBonus += 25;
					}
					if (this.armor[l].type == 1595)
					{
						this.statManaMax2 += 20;
						this.magicCuffs = true;
					}
					if (this.armor[l].type == 2219)
					{
						this.manaMagnet = true;
					}
					if (this.armor[l].type == 2220)
					{
						this.manaMagnet = true;
						this.magicDamage += 0.15f;
					}
					if (this.armor[l].type == 2221)
					{
						this.manaMagnet = true;
						this.magicCuffs = true;
					}
					if (this.whoAmI == Main.myPlayer && this.armor[l].type == 1923)
					{
						Player.tileRangeX++;
						Player.tileRangeY++;
					}
					if (this.armor[l].type == 1247)
					{
						this.starCloak = true;
						this.bee = true;
					}
					if (this.armor[l].type == 1248)
					{
						this.meleeCrit += 10;
						this.rangedCrit += 10;
						this.magicCrit += 10;
						this.thrownCrit += 10;
					}
					if (this.armor[l].type == 854)
					{
						this.discount = true;
					}
					if (this.armor[l].type == 855)
					{
						this.coins = true;
					}
					if (this.armor[l].type == 3033)
					{
						this.goldRing = true;
					}
					if (this.armor[l].type == 3034)
					{
						this.goldRing = true;
						this.coins = true;
					}
					if (this.armor[l].type == 3035)
					{
						this.goldRing = true;
						this.coins = true;
						this.discount = true;
					}
					if (this.armor[l].type == 53)
					{
						this.doubleJumpCloud = true;
					}
					if (this.armor[l].type == 3201)
					{
						this.doubleJumpSail = true;
					}
					if (this.armor[l].type == 54)
					{
						this.accRunSpeed = 6f;
					}
					if (this.armor[l].type == 3068)
					{
						this.cordage = true;
					}
					if (this.armor[l].type == 1579)
					{
						this.accRunSpeed = 6f;
						this.coldDash = true;
					}
					if (this.armor[l].type == 3200)
					{
						this.accRunSpeed = 6f;
						this.sailDash = true;
					}
					if (this.armor[l].type == 128)
					{
						this.rocketBoots = 1;
					}
					if (this.armor[l].type == 156)
					{
						this.noKnockback = true;
					}
					if (this.armor[l].type == 158)
					{
						this.noFallDmg = true;
					}
					if (this.armor[l].type == 934)
					{
						this.carpet = true;
					}
					if (this.armor[l].type == 953)
					{
						this.spikedBoots++;
					}
					if (this.armor[l].type == 975)
					{
						this.spikedBoots++;
					}
					if (this.armor[l].type == 976)
					{
						this.spikedBoots += 2;
					}
					if (this.armor[l].type == 977)
					{
						this.dash = 1;
					}
					if (this.armor[l].type == 3097)
					{
						this.dash = 2;
					}
					if (this.armor[l].type == 963)
					{
						this.blackBelt = true;
					}
					if (this.armor[l].type == 984)
					{
						this.blackBelt = true;
						this.dash = 1;
						this.spikedBoots = 2;
					}
					if (this.armor[l].type == 1131)
					{
						this.gravControl2 = true;
					}
					if (this.armor[l].type == 1132)
					{
						this.bee = true;
					}
					if (this.armor[l].type == 1578)
					{
						this.bee = true;
						this.panic = true;
					}
					if (this.armor[l].type == 3224)
					{
						this.endurance += 0.17f;
					}
					if (this.armor[l].type == 3223)
					{
						this.brainOfConfusion = true;
					}
					if (this.armor[l].type == 950)
					{
						this.iceSkate = true;
					}
					if (this.armor[l].type == 159)
					{
						this.jumpBoost = true;
					}
					if (this.armor[l].type == 3225)
					{
						this.jumpBoost = true;
					}
					if (this.armor[l].type == 187)
					{
						this.accFlipper = true;
					}
					if (this.armor[l].type == 211)
					{
						this.meleeSpeed += 0.12f;
					}
					if (this.armor[l].type == 223)
					{
						this.manaCost -= 0.06f;
					}
					if (this.armor[l].type == 285)
					{
						this.moveSpeed += 0.05f;
					}
					if (this.armor[l].type == 212)
					{
						this.moveSpeed += 0.1f;
					}
					if (this.armor[l].type == 267)
					{
						this.killGuide = true;
					}
					if (this.armor[l].type == 1307)
					{
						this.killClothier = true;
					}
					if (this.armor[l].type == 193)
					{
						this.fireWalk = true;
					}
					if (this.armor[l].type == 861)
					{
						this.accMerman = true;
						this.wolfAcc = true;
						if (this.hideVisual[l])
						{
							this.hideMerman = true;
							this.hideWolf = true;
						}
					}
					if (this.armor[l].type == 862)
					{
						this.starCloak = true;
						this.longInvince = true;
					}
					if (this.armor[l].type == 860)
					{
						this.pStone = true;
					}
					if (this.armor[l].type == 863)
					{
						this.waterWalk2 = true;
					}
					if (this.armor[l].type == 907)
					{
						this.waterWalk2 = true;
						this.fireWalk = true;
					}
					if (this.armor[l].type == 908)
					{
						this.waterWalk = true;
						this.fireWalk = true;
						this.lavaMax += 420;
					}
					if (this.armor[l].type == 906)
					{
						this.lavaMax += 420;
					}
					if (this.armor[l].type == 485)
					{
						this.wolfAcc = true;
						if (this.hideVisual[l])
						{
							this.hideWolf = true;
						}
					}
					if (this.armor[l].type == 486)
					{
						this.rulerLine = true;
					}
					if (this.armor[l].type == 2799)
					{
						this.rulerGrid = true;
					}
					if (this.armor[l].type == 394)
					{
						this.accFlipper = true;
						this.accDivingHelm = true;
					}
					if (this.armor[l].type == 396)
					{
						this.noFallDmg = true;
						this.fireWalk = true;
					}
					if (this.armor[l].type == 397)
					{
						this.noKnockback = true;
						this.fireWalk = true;
					}
					if (this.armor[l].type == 399)
					{
						this.jumpBoost = true;
						this.doubleJumpCloud = true;
					}
					if (this.armor[l].type == 405)
					{
						this.accRunSpeed = 6f;
						this.rocketBoots = 2;
					}
					if (this.armor[l].type == 1860)
					{
						this.accFlipper = true;
						this.accDivingHelm = true;
					}
					if (this.armor[l].type == 1861)
					{
						this.arcticDivingGear = true;
						this.accFlipper = true;
						this.accDivingHelm = true;
						this.iceSkate = true;
					}
					if (this.armor[l].type == 2214)
					{
						flag2 = true;
					}
					if (this.armor[l].type == 2215)
					{
						flag3 = true;
					}
					if (this.armor[l].type == 2216)
					{
						this.autoPaint = true;
					}
					if (this.armor[l].type == 2217)
					{
						flag = true;
					}
					if (this.armor[l].type == 3061)
					{
						flag = true;
						flag2 = true;
						this.autoPaint = true;
						flag3 = true;
					}
					if (this.armor[l].type == 3624)
					{
						this.autoActuator = true;
					}
					if (this.armor[l].type == 897)
					{
						this.kbGlove = true;
						this.meleeSpeed += 0.12f;
					}
					if (this.armor[l].type == 1343)
					{
						this.kbGlove = true;
						this.meleeSpeed += 0.1f;
						this.meleeDamage += 0.1f;
						this.magmaStone = true;
					}
					if (this.armor[l].type == 1167)
					{
						this.minionKB += 2f;
						this.minionDamage += 0.15f;
					}
					if (this.armor[l].type == 1864)
					{
						this.minionKB += 2f;
						this.minionDamage += 0.15f;
						this.maxMinions++;
					}
					if (this.armor[l].type == 1845)
					{
						this.minionDamage += 0.1f;
						this.maxMinions++;
					}
					if (this.armor[l].type == 1321)
					{
						this.magicQuiver = true;
						this.arrowDamage += 0.1f;
					}
					if (this.armor[l].type == 1322)
					{
						this.magmaStone = true;
					}
					if (this.armor[l].type == 1323)
					{
						this.lavaRose = true;
					}
					if (this.armor[l].type == 3333)
					{
						this.strongBees = true;
					}
					if (this.armor[l].type == 938)
					{
						this.noKnockback = true;
						if ((float)this.statLife > (float)this.statLifeMax2 * 0.25f)
						{
							this.hasPaladinShield = true;
							if (i != Main.myPlayer && this.miscCounter % 10 == 0)
							{
								int myPlayer = Main.myPlayer;
								if (Main.player[myPlayer].team == this.team && this.team != 0)
								{
									float num3 = this.position.X - Main.player[myPlayer].position.X;
									float num4 = this.position.Y - Main.player[myPlayer].position.Y;
									float num5 = (float)Math.Sqrt((double)(num3 * num3 + num4 * num4));
									if (num5 < 800f)
									{
										Main.player[myPlayer].AddBuff(43, 20, true);
									}
								}
							}
						}
					}
					if (this.armor[l].type == 936)
					{
						this.kbGlove = true;
						this.meleeSpeed += 0.12f;
						this.meleeDamage += 0.12f;
					}
					if (this.armor[l].type == 898)
					{
						this.accRunSpeed = 6.75f;
						this.rocketBoots = 2;
						this.moveSpeed += 0.08f;
					}
					if (this.armor[l].type == 1862)
					{
						this.accRunSpeed = 6.75f;
						this.rocketBoots = 3;
						this.moveSpeed += 0.08f;
						this.iceSkate = true;
					}
					if (this.armor[l].type == 3110)
					{
						this.accMerman = true;
						this.wolfAcc = true;
						if (this.hideVisual[l])
						{
							this.hideMerman = true;
							this.hideWolf = true;
						}
					}
					if (this.armor[l].type == 1865 || this.armor[l].type == 3110)
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
						this.thrownDamage += 0.1f;
						this.thrownCrit += 2;
					}
					if (this.armor[l].type == 899 && Main.dayTime)
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
						this.thrownDamage += 0.1f;
						this.thrownCrit += 2;
					}
					if (this.armor[l].type == 900 && (!Main.dayTime || Main.eclipse))
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
						this.thrownDamage += 0.1f;
						this.thrownCrit += 2;
					}
					if (this.armor[l].type == 407)
					{
						this.blockRange = 1;
					}
					if (this.armor[l].type == 489)
					{
						this.magicDamage += 0.15f;
					}
					if (this.armor[l].type == 490)
					{
						this.meleeDamage += 0.15f;
					}
					if (this.armor[l].type == 491)
					{
						this.rangedDamage += 0.15f;
					}
					if (this.armor[l].type == 2998)
					{
						this.minionDamage += 0.15f;
					}
					if (this.armor[l].type == 935)
					{
						this.magicDamage += 0.12f;
						this.meleeDamage += 0.12f;
						this.rangedDamage += 0.12f;
						this.minionDamage += 0.12f;
						this.thrownDamage += 0.12f;
					}
					if (this.armor[l].type == 492)
					{
						this.wingTimeMax = 100;
					}
					if (this.armor[l].type == 493)
					{
						this.wingTimeMax = 100;
					}
					if (this.armor[l].type == 748)
					{
						this.wingTimeMax = 115;
					}
					if (this.armor[l].type == 749)
					{
						this.wingTimeMax = 130;
					}
					if (this.armor[l].type == 761)
					{
						this.wingTimeMax = 130;
					}
					if (this.armor[l].type == 785)
					{
						this.wingTimeMax = 140;
					}
					if (this.armor[l].type == 786)
					{
						this.wingTimeMax = 140;
					}
					if (this.armor[l].type == 821)
					{
						this.wingTimeMax = 160;
					}
					if (this.armor[l].type == 822)
					{
						this.wingTimeMax = 160;
					}
					if (this.armor[l].type == 823)
					{
						this.wingTimeMax = 160;
					}
					if (this.armor[l].type == 2280)
					{
						this.wingTimeMax = 160;
					}
					if (this.armor[l].type == 2494)
					{
						this.wingTimeMax = 100;
					}
					if (this.armor[l].type == 2609)
					{
						this.wingTimeMax = 180;
						this.ignoreWater = true;
					}
					if (this.armor[l].type == 948)
					{
						this.wingTimeMax = 180;
					}
					if (this.armor[l].type == 1162)
					{
						this.wingTimeMax = 160;
					}
					if (this.armor[l].type == 1165)
					{
						this.wingTimeMax = 140;
					}
					if (this.armor[l].type == 1515)
					{
						this.wingTimeMax = 130;
					}
					if (this.armor[l].type == 665)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[l].type == 1583)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[l].type == 1584)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[l].type == 1585)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[l].type == 1586)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[l].type == 3228)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[l].type == 3580)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[l].type == 3582)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[l].type == 3588)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[l].type == 3592)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[l].type == 1797)
					{
						this.wingTimeMax = 180;
					}
					if (this.armor[l].type == 1830)
					{
						this.wingTimeMax = 180;
					}
					if (this.armor[l].type == 1866)
					{
						this.wingTimeMax = 170;
					}
					if (this.armor[l].type == 1871)
					{
						this.wingTimeMax = 170;
					}
					if (this.armor[l].type == 2770)
					{
						this.wingTimeMax = 160;
					}
					if (this.armor[l].type == 3468)
					{
						this.wingTimeMax = 180;
					}
					if (this.armor[l].type == 3469)
					{
						this.wingTimeMax = 160;
					}
					if (this.armor[l].type == 3470)
					{
						this.wingTimeMax = 160;
					}
					if (this.armor[l].type == 3471)
					{
						this.wingTimeMax = 180;
					}
					if (this.armor[l].type == 3883)
					{
						this.wingTimeMax = 150;
					}
					if (this.armor[l].type == 885)
					{
						this.buffImmune[30] = true;
					}
					if (this.armor[l].type == 886)
					{
						this.buffImmune[36] = true;
					}
					if (this.armor[l].type == 887)
					{
						this.buffImmune[20] = true;
					}
					if (this.armor[l].type == 888)
					{
						this.buffImmune[22] = true;
					}
					if (this.armor[l].type == 889)
					{
						this.buffImmune[32] = true;
					}
					if (this.armor[l].type == 890)
					{
						this.buffImmune[35] = true;
					}
					if (this.armor[l].type == 891)
					{
						this.buffImmune[23] = true;
					}
					if (this.armor[l].type == 892)
					{
						this.buffImmune[33] = true;
					}
					if (this.armor[l].type == 893)
					{
						this.buffImmune[31] = true;
					}
					if (this.armor[l].type == 3781)
					{
						this.buffImmune[156] = true;
					}
					if (this.armor[l].type == 901)
					{
						this.buffImmune[33] = true;
						this.buffImmune[36] = true;
					}
					if (this.armor[l].type == 902)
					{
						this.buffImmune[30] = true;
						this.buffImmune[20] = true;
					}
					if (this.armor[l].type == 903)
					{
						this.buffImmune[32] = true;
						this.buffImmune[31] = true;
					}
					if (this.armor[l].type == 904)
					{
						this.buffImmune[35] = true;
						this.buffImmune[23] = true;
					}
					if (this.armor[l].type == 1921)
					{
						this.buffImmune[46] = true;
						this.buffImmune[47] = true;
					}
					if (this.armor[l].type == 1612)
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
					if (this.armor[l].type == 1613)
					{
						this.buffImmune[46] = true;
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
					if (this.armor[l].type == 497)
					{
						this.accMerman = true;
						if (this.hideVisual[l])
						{
							this.hideMerman = true;
						}
					}
					if (this.armor[l].type == 535)
					{
						this.pStone = true;
					}
					if (this.armor[l].type == 536)
					{
						this.kbGlove = true;
					}
					if (this.armor[l].type == 532)
					{
						this.starCloak = true;
					}
					if (this.armor[l].type == 554)
					{
						this.longInvince = true;
					}
					if (this.armor[l].type == 555)
					{
						this.manaFlower = true;
						this.manaCost -= 0.08f;
					}
					if (Main.myPlayer == this.whoAmI)
					{
						if (this.armor[l].type == 576 && Main.rand.Next(10800) == 0 && Main.curMusic > 0 && Main.curMusic <= 41)
						{
							int num6 = 0;
							if (Main.curMusic == 1)
							{
								num6 = 0;
							}
							if (Main.curMusic == 2)
							{
								num6 = 1;
							}
							if (Main.curMusic == 3)
							{
								num6 = 2;
							}
							if (Main.curMusic == 4)
							{
								num6 = 4;
							}
							if (Main.curMusic == 5)
							{
								num6 = 5;
							}
							if (Main.curMusic == 6)
							{
								num6 = 3;
							}
							if (Main.curMusic == 7)
							{
								num6 = 6;
							}
							if (Main.curMusic == 8)
							{
								num6 = 7;
							}
							if (Main.curMusic == 9)
							{
								num6 = 9;
							}
							if (Main.curMusic == 10)
							{
								num6 = 8;
							}
							if (Main.curMusic == 11)
							{
								num6 = 11;
							}
							if (Main.curMusic == 12)
							{
								num6 = 10;
							}
							if (Main.curMusic == 13)
							{
								num6 = 12;
							}
							if (Main.curMusic == 28)
							{
								this.armor[l].SetDefaults(1963, false);
							}
							else if (Main.curMusic == 29)
							{
								this.armor[l].SetDefaults(1610, false);
							}
							else if (Main.curMusic == 30)
							{
								this.armor[l].SetDefaults(1963, false);
							}
							else if (Main.curMusic == 31)
							{
								this.armor[l].SetDefaults(1964, false);
							}
							else if (Main.curMusic == 32)
							{
								this.armor[l].SetDefaults(1965, false);
							}
							else if (Main.curMusic == 33)
							{
								this.armor[l].SetDefaults(2742, false);
							}
							else if (Main.curMusic == 34)
							{
								this.armor[l].SetDefaults(3370, false);
							}
							else if (Main.curMusic == 35)
							{
								this.armor[l].SetDefaults(3236, false);
							}
							else if (Main.curMusic == 36)
							{
								this.armor[l].SetDefaults(3237, false);
							}
							else if (Main.curMusic == 37)
							{
								this.armor[l].SetDefaults(3235, false);
							}
							else if (Main.curMusic == 38)
							{
								this.armor[l].SetDefaults(3044, false);
							}
							else if (Main.curMusic == 39)
							{
								this.armor[l].SetDefaults(3371, false);
							}
							else if (Main.curMusic > 13)
							{
								this.armor[l].SetDefaults(1596 + Main.curMusic - 14, false);
							}
							else
							{
								this.armor[l].SetDefaults(num6 + 562, false);
							}
						}
						if (this.armor[l].type >= 562 && this.armor[l].type <= 574)
						{
							Main.musicBox2 = this.armor[l].type - 562;
						}
						if (this.armor[l].type >= 1596 && this.armor[l].type <= 1609)
						{
							Main.musicBox2 = this.armor[l].type - 1596 + 13;
						}
						if (this.armor[l].type == 1610)
						{
							Main.musicBox2 = 27;
						}
						if (this.armor[l].type == 1963)
						{
							Main.musicBox2 = 28;
						}
						if (this.armor[l].type == 1964)
						{
							Main.musicBox2 = 29;
						}
						if (this.armor[l].type == 1965)
						{
							Main.musicBox2 = 30;
						}
						if (this.armor[l].type == 2742)
						{
							Main.musicBox2 = 31;
						}
						if (this.armor[l].type == 3044)
						{
							Main.musicBox2 = 32;
						}
						if (this.armor[l].type == 3235)
						{
							Main.musicBox2 = 33;
						}
						if (this.armor[l].type == 3236)
						{
							Main.musicBox2 = 34;
						}
						if (this.armor[l].type == 3237)
						{
							Main.musicBox2 = 35;
						}
						if (this.armor[l].type == 3370)
						{
							Main.musicBox2 = 36;
						}
						if (this.armor[l].type == 3371)
						{
							Main.musicBox2 = 37;
						}
					}
				}
			}
			if (this.dd2Accessory)
			{
				this.minionDamage += 0.1f;
				this.maxTurrets++;
			}
			for (int m = 3; m < 8 + this.extraAccessorySlots; m++)
			{
				if (this.armor[m].wingSlot > 0)
				{
					if (!this.hideVisual[m] || (this.velocity.Y != 0f && !this.mount.Active))
					{
						this.wings = (int)this.armor[m].wingSlot;
					}
					this.wingsLogic = (int)this.armor[m].wingSlot;
				}
			}
			for (int n = 13; n < 18 + this.extraAccessorySlots; n++)
			{
				int type3 = this.armor[n].type;
				if (this.armor[n].wingSlot > 0)
				{
					this.wings = (int)this.armor[n].wingSlot;
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
				this.accWatch++;
			}
			if (flag2)
			{
				this.tileSpeed += 0.5f;
			}
			if (flag)
			{
				this.wallSpeed += 0.5f;
			}
			if (flag3 && this.whoAmI == Main.myPlayer)
			{
				Player.tileRangeX += 3;
				Player.tileRangeY += 2;
			}
			if (!this.accThirdEye)
			{
				this.accThirdEyeCounter = 0;
			}
			if (Main.netMode == 1 && this.whoAmI == Main.myPlayer)
			{
				for (int num7 = 0; num7 < 255; num7++)
				{
					if (num7 != this.whoAmI && Main.player[num7].active && !Main.player[num7].dead && Main.player[num7].team == this.team && Main.player[num7].team != 0)
					{
						int num8 = 800;
						if ((Main.player[num7].Center - base.Center).Length() < (float)num8)
						{
							if (Main.player[num7].accWatch > this.accWatch)
							{
								this.accWatch = Main.player[num7].accWatch;
							}
							if (Main.player[num7].accCompass > this.accCompass)
							{
								this.accCompass = Main.player[num7].accCompass;
							}
							if (Main.player[num7].accDepthMeter > this.accDepthMeter)
							{
								this.accDepthMeter = Main.player[num7].accDepthMeter;
							}
							if (Main.player[num7].accFishFinder)
							{
								this.accFishFinder = true;
							}
							if (Main.player[num7].accWeatherRadio)
							{
								this.accWeatherRadio = true;
							}
							if (Main.player[num7].accThirdEye)
							{
								this.accThirdEye = true;
							}
							if (Main.player[num7].accJarOfSouls)
							{
								this.accJarOfSouls = true;
							}
							if (Main.player[num7].accCalendar)
							{
								this.accCalendar = true;
							}
							if (Main.player[num7].accStopwatch)
							{
								this.accStopwatch = true;
							}
							if (Main.player[num7].accOreFinder)
							{
								this.accOreFinder = true;
							}
							if (Main.player[num7].accCritterGuide)
							{
								this.accCritterGuide = true;
							}
							if (Main.player[num7].accDreamCatcher)
							{
								this.accDreamCatcher = true;
							}
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

		public void UpdateForbiddenSetLock()
		{
			List<int> list = new List<int>();
			for (int i = 0; i < 1000; i++)
			{
				Projectile projectile = Main.projectile[i];
				if (projectile.active && projectile.type == 656 && projectile.owner == this.whoAmI)
				{
					list.Add(i);
				}
			}
			this.setForbiddenCooldownLocked = (list.Count > 1);
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
			if (this.mount.Active)
			{
				Player.jumpHeight = this.mount.JumpHeight(this.velocity.X);
				Player.jumpSpeed = this.mount.JumpSpeed(this.velocity.X);
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
				Player.jumpSpeed += this.jumpSpeedBoost;
			}
			if (this.sticky)
			{
				Player.jumpHeight /= 10;
				Player.jumpSpeed /= 5f;
			}
			if (this.dazed)
			{
				Player.jumpHeight /= 5;
				Player.jumpSpeed /= 2f;
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
				this.lifeRegen -= 4;
			}
			if (this.venom)
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
			if (this.electrified)
			{
				if (this.lifeRegen > 0)
				{
					this.lifeRegen = 0;
				}
				this.lifeRegenTime = 0;
				this.lifeRegen -= 8;
				if (this.controlLeft || this.controlRight)
				{
					this.lifeRegen -= 32;
				}
			}
			if (this.tongued && Main.expertMode)
			{
				if (this.lifeRegen > 0)
				{
					this.lifeRegen = 0;
				}
				this.lifeRegenTime = 0;
				this.lifeRegen -= 100;
			}
			if (this.honey && this.lifeRegen < 0)
			{
				this.lifeRegen += 4;
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
				this.lifeRegen /= 2;
			}
			this.lifeRegenTime++;
			if (this.crimsonRegen)
			{
				this.lifeRegenTime++;
			}
			if (this.soulDrain > 0)
			{
				this.lifeRegenTime += 2;
			}
			if (flag)
			{
				if (this.lifeRegenTime > 90 && this.lifeRegenTime < 1800)
				{
					this.lifeRegenTime = 1800;
				}
				this.lifeRegenTime += 4;
				this.lifeRegen += 4;
			}
			if (this.honey)
			{
				this.lifeRegenTime += 2;
				this.lifeRegen += 2;
			}
			if (this.soulDrain > 0)
			{
				int num = (5 + this.soulDrain) / 2;
				this.lifeRegenTime += num;
				this.lifeRegen += num;
			}
			if (this.whoAmI == Main.myPlayer && Main.campfire)
			{
				this.lifeRegen++;
			}
			if (this.whoAmI == Main.myPlayer && Main.heartLantern)
			{
				this.lifeRegen += 2;
			}
			if (this.bleed)
			{
				this.lifeRegenTime = 0;
			}
			float num2 = 0f;
			if (this.lifeRegenTime >= 300)
			{
				num2 += 1f;
			}
			if (this.lifeRegenTime >= 600)
			{
				num2 += 1f;
			}
			if (this.lifeRegenTime >= 900)
			{
				num2 += 1f;
			}
			if (this.lifeRegenTime >= 1200)
			{
				num2 += 1f;
			}
			if (this.lifeRegenTime >= 1500)
			{
				num2 += 1f;
			}
			if (this.lifeRegenTime >= 1800)
			{
				num2 += 1f;
			}
			if (this.lifeRegenTime >= 2400)
			{
				num2 += 1f;
			}
			if (this.lifeRegenTime >= 3000)
			{
				num2 += 1f;
			}
			if (flag)
			{
				float num3 = (float)(this.lifeRegenTime - 3000);
				num3 /= 300f;
				if (num3 > 0f)
				{
					if (num3 > 30f)
					{
						num3 = 30f;
					}
					num2 += num3;
				}
			}
			else if (this.lifeRegenTime >= 3600)
			{
				num2 += 1f;
				this.lifeRegenTime = 3600;
			}
			if (this.velocity.X == 0f || this.grappling[0] > 0)
			{
				num2 *= 1.25f;
			}
			else
			{
				num2 *= 0.5f;
			}
			if (this.crimsonRegen)
			{
				num2 *= 1.5f;
			}
			if (this.shinyStone)
			{
				num2 *= 1.1f;
			}
			if (this.whoAmI == Main.myPlayer && Main.campfire)
			{
				num2 *= 1.1f;
			}
			if (Main.expertMode && !this.wellFed)
			{
				if (this.shinyStone)
				{
					num2 *= 0.75f;
				}
				else
				{
					num2 /= 2f;
				}
			}
			if (this.rabid)
			{
				if (this.shinyStone)
				{
					num2 *= 0.75f;
				}
				else
				{
					num2 /= 2f;
				}
			}
			float num4 = (float)this.statLifeMax2 / 400f * 0.85f + 0.15f;
			num2 *= num4;
			this.lifeRegen += (int)Math.Round((double)num2);
			this.lifeRegenCount += this.lifeRegen;
			if (this.palladiumRegen)
			{
				this.lifeRegenCount += 6;
			}
			if (flag && this.lifeRegen > 0 && this.statLife < this.statLifeMax2)
			{
				this.lifeRegenCount++;
			}
			while (this.lifeRegenCount >= 120)
			{
				this.lifeRegenCount -= 120;
				if (this.statLife < this.statLifeMax2)
				{
					this.statLife++;
				}
				if (this.statLife > this.statLifeMax2)
				{
					this.statLife = this.statLifeMax2;
				}
			}
			if (!this.burned && !this.suffocating)
			{
				if (!this.tongued || !Main.expertMode)
				{
					while (this.lifeRegenCount <= -120)
					{
						if (this.lifeRegenCount <= -480)
						{
							this.lifeRegenCount += 480;
							this.statLife -= 4;
							CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), CombatText.LifeRegen, string.Concat(4), false, true);
						}
						else if (this.lifeRegenCount <= -360)
						{
							this.lifeRegenCount += 360;
							this.statLife -= 3;
							CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), CombatText.LifeRegen, string.Concat(3), false, true);
						}
						else if (this.lifeRegenCount <= -240)
						{
							this.lifeRegenCount += 240;
							this.statLife -= 2;
							CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), CombatText.LifeRegen, string.Concat(2), false, true);
						}
						else
						{
							this.lifeRegenCount += 120;
							this.statLife--;
							CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), CombatText.LifeRegen, string.Concat(1), false, true);
						}
						if (this.statLife <= 0 && this.whoAmI == Main.myPlayer)
						{
							if (this.poisoned || this.venom)
							{
								this.KillMe(10.0, 0, false, " " + Lang.dt[0]);
							}
							else if (this.electrified)
							{
								this.KillMe(10.0, 0, false, " " + Lang.dt[3]);
							}
							else
							{
								this.KillMe(10.0, 0, false, " " + Lang.dt[1]);
							}
						}
					}
					return;
				}
			}
			while (this.lifeRegenCount <= -600)
			{
				this.lifeRegenCount += 600;
				this.statLife -= 5;
				CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), CombatText.LifeRegen, string.Concat(5), false, true);
				if (this.statLife <= 0 && this.whoAmI == Main.myPlayer)
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
		}

		public void UpdateManaRegen()
		{
			if (this.nebulaLevelMana > 0)
			{
				int num = 6;
				this.nebulaManaCounter += this.nebulaLevelMana;
				if (this.nebulaManaCounter >= num)
				{
					this.nebulaManaCounter -= num;
					this.statMana++;
					if (this.statMana >= this.statManaMax2)
					{
						this.statMana = this.statManaMax2;
					}
				}
			}
			else
			{
				this.nebulaManaCounter = 0;
			}
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
				float num2 = (float)this.statMana / (float)this.statManaMax2 * 0.8f + 0.2f;
				if (this.manaRegenBuff)
				{
					num2 = 1f;
				}
				this.manaRegen = (int)((double)((float)this.manaRegen * num2) * 1.15);
			}
			else
			{
				this.manaRegen = 0;
			}
			this.manaRegenCount += this.manaRegen;
			while (this.manaRegenCount >= 120)
			{
				bool flag = false;
				this.manaRegenCount -= 120;
				if (this.statMana < this.statManaMax2)
				{
					this.statMana++;
					flag = true;
				}
				if (this.statMana >= this.statManaMax2)
				{
					this.statMana = this.statManaMax2;
				}
			}
		}
		public void MinionNPCTargetAim()
		{
			Vector2 mouseWorld = Main.MouseWorld;
			int num = -1;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].CanBeChasedBy(this, false) && (num == -1 || Main.npc[i].Hitbox.Distance(mouseWorld) < Main.npc[num].Hitbox.Distance(mouseWorld)))
				{
					num = i;
				}
			}
			if (this.MinionAttackTargetNPC == num)
			{
				this.MinionAttackTargetNPC = -1;
				return;
			}
			this.MinionAttackTargetNPC = num;
		}
		public void UpdateMinionTarget()
		{
			if (this.whoAmI != Main.myPlayer)
			{
				return;
			}
			if (base.Distance(this.MinionRestTargetPoint) > 1000f)
			{
				this.MinionRestTargetPoint = Vector2.Zero;
			}
			if (this.MinionAttackTargetNPC != -1 && (!Main.npc[this.MinionAttackTargetNPC].CanBeChasedBy(this, false) || Main.npc[this.MinionAttackTargetNPC].Hitbox.Distance(base.Center) > 3000f))
			{
				this.MinionAttackTargetNPC = -1;
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
			int num2 = this.HasBuff(num);
			if (num2 == -1)
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
			int num2 = this.HasBuff(num);
			if (num == 27 && num2 == -1)
			{
				num2 = this.HasBuff(102);
			}
			if (num == 27 && num2 == -1)
			{
				num2 = this.HasBuff(101);
			}
			if (num2 == -1)
			{
				if (num == 27)
				{
					num = Utils.SelectRandom<int>(Main.rand, new int[]
					{
						27,
						102,
						101
					});
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
			this.shadowCount++;
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
				Vector2[] expr_129_cp_0 = this.shadowPos;
				int expr_129_cp_1 = 0;
				expr_129_cp_0[expr_129_cp_1].Y = expr_129_cp_0[expr_129_cp_1].Y + this.gfxOffY;
				this.shadowRotation[0] = this.fullRotation;
				this.shadowOrigin[0] = this.fullRotationOrigin;
			}
		}

		public void UpdateTeleportVisuals()
		{
			if (this.teleportTime > 0f)
			{
				if (this.teleportStyle == 0)
				{
				}
				else if (this.teleportStyle == 1)
				{
				}
				else if (this.teleportStyle == 2)
				{
					this.teleportTime = 0.005f;
				}
				else if (this.teleportStyle == 3)
				{
					this.teleportTime = 0.005f;
				}
				else if (this.teleportStyle == 4)
				{
					this.teleportTime -= 0.02f;
				}
				this.teleportTime -= 0.005f;
			}
		}

		public void UpdateTouchingTiles()
		{
			this.TouchedTiles.Clear();
			List<Point> list = null;
			List<Point> list2 = null;
			if (!Collision.IsClearSpotHack(this.position + this.velocity, 16f, this.width, this.height, false, false, (int)this.gravDir, true, true))
			{
				list = Collision.FindCollisionTile((Math.Sign(this.velocity.Y) == 1) ? 2 : 3, this.position + this.velocity, 16f, this.width, this.height, false, false, (int)this.gravDir, true, false);
			}
			if (!Collision.IsClearSpotHack(this.position, Math.Abs(this.velocity.Y), this.width, this.height, false, false, (int)this.gravDir, true, true))
			{
				list2 = Collision.FindCollisionTile((Math.Sign(this.velocity.Y) == 1) ? 2 : 3, this.position, Math.Abs(this.velocity.Y), this.width, this.height, false, false, (int)this.gravDir, true, true);
			}
			if (list != null && list2 != null)
			{
				for (int i = 0; i < list2.Count; i++)
				{
					if (!list.Contains(list2[i]))
					{
						list.Add(list2[i]);
					}
				}
			}
			if (list == null && list2 != null)
			{
				list = list2;
			}
			if (list != null)
			{
				this.TouchedTiles = list;
			}
		}

		public void WallslideMovement()
		{
			this.sliding = false;
			if (this.slideDir != 0 && this.spikedBoots > 0 && !this.mount.Active && ((this.controlLeft && this.slideDir == -1) || (this.controlRight && this.slideDir == 1)))
			{
				bool flag = false;
				float num = this.position.X;
				if (this.slideDir == 1)
				{
					num += (float)this.width;
				}
				num += (float)this.slideDir;
				float num2 = this.position.Y + (float)this.height + 1f;
				if (this.gravDir < 0f)
				{
					num2 = this.position.Y - 1f;
				}
				num /= 16f;
				num2 /= 16f;
				if (WorldGen.SolidTile((int)num, (int)num2) && WorldGen.SolidTile((int)num, (int)num2 - 1))
				{
					flag = true;
				}
				if (this.spikedBoots >= 2)
				{
					if (flag && ((this.velocity.Y > 0f && this.gravDir == 1f) || (this.velocity.Y < this.gravity && this.gravDir == -1f)))
					{
						float num3 = this.gravity;
						if (this.slowFall)
						{
							if (this.controlUp)
							{
								num3 = this.gravity / 10f * this.gravDir;
							}
							else
							{
								num3 = this.gravity / 3f * this.gravDir;
							}
						}
						this.fallStart = (int)(this.position.Y / 16f);
						if ((this.controlDown && this.gravDir == 1f) || (this.controlUp && this.gravDir == -1f))
						{
							this.velocity.Y = 4f * this.gravDir;
						}
						else if (this.gravDir == -1f)
						{
							this.velocity.Y = (-num3 + 1E-05f) * this.gravDir;
						}
						else
						{
							this.velocity.Y = (-num3 + 1E-05f) * this.gravDir;
						}
						this.sliding = true;
						return;
					}
				}
				else if ((flag && (double)this.velocity.Y > 0.5 && this.gravDir == 1f) || ((double)this.velocity.Y < -0.5 && this.gravDir == -1f))
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
				}
			}
		}

		public void WaterCollision(bool fallThrough, bool ignorePlats)
		{
			int height;
			if (this.onTrack)
			{
				height = this.height - 20;
			}
			else
			{
				height = this.height;
			}
			Vector2 velocity = this.velocity;
			this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, height, fallThrough, ignorePlats, (int)this.gravDir);
			Vector2 value = this.velocity * 0.5f;
			if (this.velocity.X != velocity.X)
			{
				value.X = this.velocity.X;
			}
			if (this.velocity.Y != velocity.Y)
			{
				value.Y = this.velocity.Y;
			}
			this.position += value;
		}

		public void WingMovement()
		{
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
				return;
			}
			float num = 0.1f;
			float num2 = 0.5f;
			float num3 = 1.5f;
			float num4 = 0.5f;
			float num5 = 0.1f;
			if (this.wingsLogic == 26)
			{
				num2 = 0.75f;
				num5 = 0.15f;
				num4 = 1f;
				num3 = 2.5f;
				num = 0.125f;
			}
			if (this.wingsLogic == 37)
			{
				num2 = 0.75f;
				num5 = 0.15f;
				num4 = 1f;
				num3 = 2.5f;
				num = 0.125f;
			}
			if (this.wingsLogic == 29 || this.wingsLogic == 32)
			{
				num2 = 0.85f;
				num5 = 0.15f;
				num4 = 1f;
				num3 = 3f;
				num = 0.135f;
			}
			if (this.wingsLogic == 30 || this.wingsLogic == 31)
			{
				num4 = 1f;
				num3 = 2f;
				num = 0.15f;
			}
			this.velocity.Y = this.velocity.Y - num * this.gravDir;
			if (this.gravDir == 1f)
			{
				if (this.velocity.Y > 0f)
				{
					this.velocity.Y = this.velocity.Y - num2;
				}
				else if (this.velocity.Y > -Player.jumpSpeed * num4)
				{
					this.velocity.Y = this.velocity.Y - num5;
				}
				if (this.velocity.Y < -Player.jumpSpeed * num3)
				{
					this.velocity.Y = -Player.jumpSpeed * num3;
				}
			}
			else
			{
				if (this.velocity.Y < 0f)
				{
					this.velocity.Y = this.velocity.Y + num2;
				}
				else if (this.velocity.Y < Player.jumpSpeed * num4)
				{
					this.velocity.Y = this.velocity.Y + num5;
				}
				if (this.velocity.Y > Player.jumpSpeed * num3)
				{
					this.velocity.Y = Player.jumpSpeed * num3;
				}
			}
			if ((this.wingsLogic == 22 || this.wingsLogic == 28 || this.wingsLogic == 30 || this.wingsLogic == 31 || this.wingsLogic == 37) && this.controlDown && !this.controlLeft && !this.controlRight)
			{
				this.wingTime -= 0.5f;
				return;
			}
			this.wingTime -= 1f;
		}

		public void WOFTongue()
		{
			if (Main.wof >= 0 && Main.npc[Main.wof].active)
			{
				float num = Main.npc[Main.wof].position.X + 40f;
				if (Main.npc[Main.wof].direction > 0)
				{
					num -= 96f;
				}
				if (this.position.X + (float)this.width > num && this.position.X < num + 140f && this.gross)
				{
					this.noKnockback = false;
					this.Hurt(50, Main.npc[Main.wof].direction, false, false, " was slain...", false, -1);
				}
				if (!this.gross && this.position.Y > (float)((Main.maxTilesY - 250) * 16) && this.position.X > num - 1920f && this.position.X < num + 1920f)
				{
					this.AddBuff(37, 10, true);
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
					for (int i = 0; i < 1000; i++)
					{
						if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].aiStyle == 7)
						{
							Main.projectile[i].Kill();
						}
					}
					Vector2 center = base.Center;
					float num2 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) - center.X;
					float num3 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2) - center.Y;
					float num4 = (float)Math.Sqrt((double)(num2 * num2 + num3 * num3));
					if (num4 > 3000f)
					{
						this.KillMe(1000.0, 0, false, Language.GetTextValue("Deaths.TriedToEscape"));
						return;
					}
					if (Main.npc[Main.wof].position.X < 608f || Main.npc[Main.wof].position.X > (float)((Main.maxTilesX - 38) * 16))
					{
						this.KillMe(1000.0, 0, false, Language.GetTextValue("Deaths.WasLicked"));
					}
				}
			}
		}

		private Vector2 BlehOldPositionFixer
		{
			get
			{
				return -Vector2.UnitY;
			}
		}

		

		public static class Hooks
		{
			public static void EnterWorld(int playerIndex)
			{
				if (Player.Hooks.OnEnterWorld != null)
				{
					Player.Hooks.OnEnterWorld(Main.player[playerIndex]);
				}
			}

			public static void PlayerConnect(int playerIndex)
			{
				PressurePlateHelper.ResetPlayer(playerIndex);
			}

			public static void PlayerDisconnect(int playerIndex)
			{
				PressurePlateHelper.ResetPlayer(playerIndex);
			}


			public static event Action<Player> OnEnterWorld;
		}
		public class SelectionRadial
		{
			public SelectionRadial(Player.SelectionRadial.SelectionMode mode = Player.SelectionRadial.SelectionMode.Dpad4)
			{
				this.Mode = mode;
				int radialCount = 0;
				switch (mode)
				{
				case Player.SelectionRadial.SelectionMode.Dpad4:
					radialCount = 4;
					break;
				case Player.SelectionRadial.SelectionMode.RadialCircular:
					radialCount = 10;
					break;
				case Player.SelectionRadial.SelectionMode.RadialQuicks:
					radialCount = 3;
					break;
				}
				this.RadialCount = radialCount;
				this.Bindings = new int[this.RadialCount];
				for (int i = 0; i < this.RadialCount; i++)
				{
					this.Bindings[i] = -1;
				}
			}
			public void ChangeSelection(int to)
			{
			}

			public void CopyTo(Player.SelectionRadial that)
			{
			}

			public int[] Bindings;

			public Player.SelectionRadial.SelectionMode Mode;

			public int RadialCount;

			private int _SelectedBinding = -1;

			public enum SelectionMode
			{
				Dpad4,
				RadialCircular,
				RadialQuicks
			}
		}

		public class SmartCursorSettings
		{
			public static bool SmartAxeAfterPickaxe = false;

			public static bool SmartBlocksEnabled = false;

			public static bool SmartWallReplacement = true;
		}
	}
}
