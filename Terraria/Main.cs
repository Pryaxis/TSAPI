using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Terraria.Achievements;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.ID;
using Terraria.Initializers;
using Terraria.IO;
//using Terraria.Map;
using Terraria.Net;
using Terraria.Net.Sockets;
using Terraria.ObjectData;
using Terraria.Utilities;
using Terraria.World.Generation;
using TerrariaApi.Server;

namespace Terraria
{
	public class Main
	{
		public const int offLimitBorderTiles = 40;

		public const int maxItemTypes = ItemID.Count;

		public const int maxProjectileTypes = ProjectileID.Count;

		public const int maxNPCTypes = NPCID.Count;

		public const int maxTileSets = TileID.Count;

		public const int maxWallTypes = WallID.Count;

		public const int maxBuffTypes = BuffID.Count;

		public const int maxGlowMasks = 214;

		public const int maxExtras = 69;

		public const int maxGoreTypes = 907;

		public const int numBannerTypes = 251;

		public const int numArmorHead = 194;

		public const int numArmorBody = 195;

		public const int numArmorLegs = 135;

		public const int numAccHandsOn = 19;

		public const int numAccHandsOff = 12;

		public const int numAccNeck = 9;

		public const int numAccBack = 10;

		public const int numAccFront = 5;

		public const int numAccShoes = 18;

		public const int numAccWaist = 12;

		public const int numAccShield = 6;

		public const int numAccFace = 9;

		public const int numAccBalloon = 16;

		public const int maxWings = 37;

		public const int maxBackgrounds = 207;

		public const int numInfoIcons = 13;

		private const int MF_BYPOSITION = 1024;

		public const int sectionWidth = 200;

		public const int sectionHeight = 150;

		public const int maxDust = 6000;

		public const int maxCombatText = 100;

		public const int maxItemText = 20;

		public const int maxPlayers = 255;

		public const int maxChests = 1000;

		public const int maxItems = 400;

		public const int maxProjectiles = 1000;

		public const int maxNPCs = 200;

		private const double slimeRainMaxTime = 54000;

		private const double slimeRainMinTime = 32400;

		private const double slimeRainMaxDelay = 604800;

		private const double slimeRainMinDelay = 302400;

		private const double slimeRainChance = 1728000;

		public const int maxGore = 500;

		public const int realInventory = 50;

		public const int maxInventory = 58;

		public const int maxItemSounds = 125;

		public const int maxNPCHitSounds = 57;

		public const int maxNPCKilledSounds = 62;

		public const int maxLiquidTypes = 12;

		public const int maxMusic = 40;

		public const double dayLength = 54000;

		public const double nightLength = 32400;

		public const int maxStars = 130;

		public const int maxStarTypes = 5;

		public const int maxClouds = 200;

		public const int maxCloudTypes = 22;

		public const int maxHair = 134;

		public const int maxCharSelectHair = 51;

		public const int MaxTimeout = 120;

		public bool unityMouseOver;

		public static Main instance;

		public static int curRelease;

		public static string versionNumber;

		public static string versionNumber2;

		public static Vector2 destroyerHB;

		public static FileMetadata WorldFileMetadata;

		public static FileMetadata MapFileMetadata;

		private static Main.OnPlayerSelected _pendingCharacterSelect;

		public static bool drawBackGore;

		public static ulong LobbyId = 0uL;

		public static float expertLife;

		public static float expertDamage;

		public static float expertDebuffTime;

		public static float expertKnockBack;

		public static float expertNPCDamage;

		public static float knockBackMultiplier;

		public static float damageMultiplier;

		public WaterfallManager waterfallManager;

		public static WorldSections sectionManager;

		public static bool ServerSideCharacter;

		public static string clientUUID;

		public static bool ContentLoaded;

		public static int maxMsg;

		public static float GlobalTime;

		public static bool GlobalTimerPaused;

		private static ulong _tileFrameSeed;

		public static int npcStreamSpeed;

		public static int musicError;

		public static bool dedServFPS;

		public static int dedServCount1;

		public static int dedServCount2;

		public static bool superFast;

		public static bool[] hairLoaded;

		public static bool[] wingsLoaded;

		public static bool[] goreLoaded;

		public static bool[] projectileLoaded;

		public static bool[] itemFlameLoaded;

		public static bool[] backgroundLoaded;

		public static bool[] tileSetsLoaded;

		public static bool[] wallLoaded;

		public static bool[] NPCLoaded;

		public static bool[] armorHeadLoaded;

		public static bool[] armorBodyLoaded;

		public static bool[] armorLegsLoaded;

		public static bool[] accHandsOnLoaded;

		public static bool[] accHandsOffLoaded;

		public static bool[] accBackLoaded;

		public static bool[] accFrontLoaded;

		public static bool[] accShoesLoaded;

		public static bool[] accWaistLoaded;

		public static bool[] accShieldLoaded;

		public static bool[] accNeckLoaded;

		public static bool[] accFaceLoaded;

		public static bool[] accballoonLoaded;

		public static Vector2[] OffsetsNPCOffhand;

		public static Vector2[] OffsetsPlayerOffhand;

		public static Vector2[] OffsetsPlayerOnhand;

		public static Vector2[] OffsetsPlayerHeadgear;

		public static float zoomX;

		public static float zoomY;

		public static float sunCircle;

		public static int BlackFadeIn;

		public static bool noWindowBorder;

		private Matrix Transform = Matrix.CreateScale(1f, 1f, 1f) * Matrix.CreateRotationZ(0f) * Matrix.CreateTranslation(new Vector3(0f, 0f, 0f));

		public static int ugBack;

		public static int oldUgBack;

		public static int[] bgFrame;

		public static int[] bgFrameCounter;

		public static bool skipMenu;

		public static bool verboseNetplay;

		public static bool stopTimeOuts;

		public static bool showSpam;

		public static bool showItemOwner;

		public static bool[] nextNPC;

		public static int musicBox;

		public static int musicBox2;

		public static byte hbPosition;

		public static bool cEd;

		public static float wFrCounter;

		public static float wFrame;

		public static float upTimer;

		public static float upTimerMax;

		public static float upTimerMaxDelay;

		public static bool drawDiag;

		public static bool drawRelease;

		public static bool drawBetterDebug;

		public static bool betterDebugRelease;

		public static bool renderNow;

		public static bool drawToScreen;

		public static bool targetSet;

		public static int mouseX;

		public static int mouseY;

		public static int lastMouseX;

		public static int lastMouseY;

		public static bool mouseLeft;

		public static bool mouseRight;

		public static float essScale;

		public static int essDir;

		public static float[] cloudBGX;

		public static float cloudBGAlpha;

		public static float cloudBGActive;

		public static int[] cloudBG;

		public static int[] treeMntBG;

		public static int[] treeBG;

		public static int[] corruptBG;

		public static int[] jungleBG;

		public static int[] snowMntBG;

		public static int[] snowBG;

		public static int[] hallowBG;

		public static int[] crimsonBG;

		public static int[] desertBG;

		public static int oceanBG;

		public static int[] treeX;

		public static int[] treeStyle;

		public static int[] caveBackX;

		public static int[] caveBackStyle;

		public static int iceBackStyle;

		public static int hellBackStyle;

		public static int jungleBackStyle;

		public static string debugWords;

		public static bool gamePad;

		public static bool xMas;

		public static bool halloween;

		public static int snowDust;

		public static bool chTitle;

		public static bool hairWindow;

		public static bool clothesWindow;

		public static bool ingameOptionsWindow;

		public static bool achievementsWindow;

		public static int keyCount;

		public static string[] keyString;

		public static int[] keyInt;

		public static byte gFade;

		public static float gFader;

		public static byte gFadeDir;

		public static bool netDiag;

		public static long txData;

		public static long rxData;

		public static long txMsg;

		public static long rxMsg;

		public static float uCarry;

		public static bool drawSkip;

		public static int fpsCount;

		public static Stopwatch fpsTimer;

		public static Stopwatch updateTimer;

		public bool gammaTest;

		public static int fountainColor;

		public static int monolithType;

		public static bool showSplash;

		public static bool ignoreErrors;

		public static string defaultIP;

		public static int dayRate;

		public static int maxScreenW;

		public static int minScreenW;

		public static int maxScreenH;

		public static int minScreenH;

		public static float iS;

		public static bool render;

		public static int qaStyle;

		public static int zoneX;

		public static int zoneY;

		public static float harpNote;

		public static bool[] projHostile;

		public static bool[] projHook;

		public static bool[] pvpBuff;

		public static bool[] persistentBuff;

		public static bool[] vanityPet;

		public static bool[] lightPet;

		public static bool[] meleeBuff;

		public static bool[] debuff;

		public static string[] buffName;

		public static string[] buffTip;

		public static bool[] buffNoSave;

		public static bool[] buffNoTimeDisplay;

		public static bool[] buffDoubleApply;

		public static int maxMP;

		public static string[] recentWorld;

		public static string[] recentIP;

		public static int[] recentPort;

		public static bool shortRender;

		public static bool owBack;

		public static int quickBG;

		public static int bgDelay;

		public static int bgStyle;

		public static float[] bgAlpha;

		public static float[] bgAlpha2;

		public static int EquipPage;

		public static int EquipPageSelected;

		public int mouseNPC = -1;

		public static int wof;

		public static int wofT;

		public static int wofB;

		public static int wofF;

		public static int offScreenRange;

		public static int maxMapUpdates;

		public static bool refreshMap;

		public static int loadMapLastX;

		public static bool loadMapLock;

		public static bool loadMap;

		public static bool mapReady;

		public static int textureMaxWidth;

		public static int textureMaxHeight;

		public static bool updateMap;

		public static int mapMinX;

		public static int mapMaxX;

		public static int mapMinY;

		public static int mapMaxY;

		public static int mapTimeMax;

		public static int mapTime;

		public static bool clearMap;

		public static int mapTargetX;

		public static int mapTargetY;

		private static bool flameRingLoaded;

		public static bool[,] initMap;

		public static bool[,] mapWasContentLost;

		public static Color OurFavoriteColor;

		public static bool mapInit;

		public static bool mapEnabled;

		public static int mapStyle;

		public static float grabMapX;

		public static float grabMapY;

		public static int miniMapX;

		public static int miniMapY;

		public static int miniMapWidth;

		public static int miniMapHeight;

		public static float mapMinimapScale;

		public static float mapMinimapAlpha;

		public static float mapOverlayScale;

		public static float mapOverlayAlpha;

		public static bool mapFullscreen;

		public static bool resetMapFull;

		public static float mapFullscreenScale;

		public static Vector2 mapFullscreenPos;

		public static int renderCount;

		private Process tServer = new Process();

		private static Stopwatch saveTime;

		public static int oldMouseWheel;

		public static Color mcColor;

		public static Color hcColor;

		public static Color highVersionColor;

		public static Color errorColor;

		public static Color bgColor;

		public static bool mouseHC;

		public static bool craftingHide;

		public static bool armorHide;

		public static float craftingAlpha;

		public static float armorAlpha;

		public static float[] buffAlpha;

		public static Item trashItem;

		public static bool hardMode;

		public float chestLootScale = 1f;

		public bool chestLootHover;

		public float chestStackScale = 1f;

		public bool chestStackHover;

		public float chestDepositScale = 1f;

		public bool chestDepositHover;

		public float chestRenameScale = 1f;

		public bool chestRenameHover;

		public float chestCancelScale = 1f;

		public bool chestCancelHover;

		public static Vector2 sceneWaterPos;

		public static Vector2 sceneTilePos;

		public static Vector2 sceneTile2Pos;

		public static Vector2 sceneWallPos;

		public static Vector2 sceneBackgroundPos;

		public static bool maxQ;

		public static float gfxQuality;

		public static float gfxRate;

		public int DiscoStyle;

		public static int DiscoR;

		public static int DiscoB;

		public static int DiscoG;

		public static int teamCooldown;

		public static int teamCooldownLen;

		public static bool gamePaused;

		public static bool gameInactive;

		public static int updateTime;

		public static int drawTime;

		public static int uCount;

		public static int updateRate;

		public static int frameRate;

		public static bool RGBRelease;

		public static bool qRelease;

		public static bool netRelease;

		public static bool frameRelease;

		public static bool showFrameRate;

		public static int magmaBGFrame;

		public static int magmaBGFrameCounter;

		public static int saveTimer;

		public static bool autoJoin;

		public static bool serverStarting;

		public static float leftWorld;

		public static float rightWorld;

		public static float topWorld;

		public static float bottomWorld;

		public static int maxTilesX;

		public static int maxTilesY;

		public static int maxSectionsX;

		public static int maxSectionsY;

		public static int numDust;

		public static int numPlayers;

		public static int maxNetPlayers;

		public static int maxRain;

		public static int slimeWarningTime;

		public static int slimeWarningDelay;

		public static float slimeRainNPCSlots;

		public static bool[] slimeRainNPC;

		public static double slimeRainTime;

		public static bool slimeRain;

		public static int slimeRainKillCount;

		public int invBottom = 210;

		public static float cameraX;

		public static bool drewLava;

		public static float[] liquidAlpha;

		public static int waterStyle;

		public static int worldRate;

		public static float caveParallax;

		public static int dungeonX;

		public static int dungeonY;

		public static Liquid[] liquid;

		public static LiquidBuffer[] liquidBuffer;

		public static bool dedServ;

		public static int spamCount;

		public static int curMusic;

		public static int dayMusic;

		public static int ugMusic;

		public int newMusic;

		public static bool showItemText;

		public static bool autoSave;

		public static bool validateSaves;

		public static bool bannerMouseOver;

		public static string buffString;

		public static string libPath;

		public static int lo;

		public static int LogoA;

		public static int LogoB;

		public static bool LogoT;

		public static string statusText;

		public static string worldName;

		public static int worldID;

		public static int background;

		public static int caveBackground;

		public static float ugBackTransition;

		public static Color tileColor;

		public static double worldSurface;

		public static double rockLayer;

		public static Color[] teamColor;

		public static bool dayTime;

		public static double time;

		public static int moonPhase;

		public static short sunModY;

		public static short moonModY;

		public static bool grabSky;

		public static bool bloodMoon;

		public static bool pumpkinMoon;

		public static bool snowMoon;

		public static float cloudAlpha;

		public static float maxRaining;

		public static float oldMaxRaining;

		public static int rainTime;

		public static bool raining;

		public static bool eclipse;

		public static float eclipseLight;

		public static int checkForSpawns;

		public static int helpText;

		public static bool autoGen;

		public static bool autoPause;

		public static int[] projFrames;

		public static bool[] projPet;

		public static float demonTorch;

		public static int demonTorchDir;

		public static float martianLight;

		public static int martianLightDir;

		public static bool placementPreview;

		public static int numStars;

		public static int weatherCounter;

		public static int cloudLimit;

		public static int numClouds;

		public static int numCloudsTemp;

		public static float windSpeedTemp;

		public static float windSpeed;

		public static float windSpeedSet;

		public static float windSpeedSpeed;

		public static Cloud[] cloud;

		public static bool resetClouds;

		public static int sandTiles;

		public static int evilTiles;

		public static int shroomTiles;

		public static float shroomLight;

		public static int snowTiles;

		public static int holyTiles;

		public static int waterCandles;

		public static int peaceCandles;

		public static int meteorTiles;

		public static int bloodTiles;

		public static int jungleTiles;

		public static int dungeonTiles;

		public static bool sunflower;

		public static bool clock;

		public static bool campfire;

		public static bool starInBottle;

		public static bool heartLantern;

		public static int fadeCounter;

		public static float invAlpha;

		public static float invDir;

		[ThreadStatic]
		public static Random rand;

		public static int maxMoons;

		public static int moonType;

		public static int numTileColors;

		public static bool[,] tileAltTextureInit;

		public static bool[,] tileAltTextureDrawn;

		public static int numTreeStyles;

		public static bool[,] treeAltTextureInit;

		public static bool[,] treeAltTextureDrawn;

		public static bool[,] checkTreeAlt;

		public static bool[,] wallAltTextureInit;

		public static bool[,] wallAltTextureDrawn;

		public static float[] musicFade;

		public static float musicVolume;

		public static float ambientVolume;

		public static float soundVolume;

		public static ServerSocialMode MenuServerMode;

		public static bool[] tileLighted;

		public static bool[] tileMergeDirt;

		public static bool[] tileCut;

		public static bool[] tileAlch;

		public static int[] tileShine;

		public static bool[] tileShine2;

		public static bool[] wallHouse;

		public static bool[] wallDungeon;

		public static bool[] wallLight;

		public static int[] wallBlend;

		public static bool[] tileStone;

		public static bool[] tileAxe;

		public static bool[] tileHammer;

		public static bool[] tileWaterDeath;

		public static bool[] tileLavaDeath;

		public static bool[] tileTable;

		public static bool[] tileBlockLight;

		public static bool[] tileNoSunLight;

		public static bool[] tileDungeon;

		public static bool[] tileSpelunker;

		public static bool[] tileSolidTop;

		public static bool[] tileSolid;

		public static bool[] tileBouncy;

		public static short[] tileValue;

		public static byte[] tileLargeFrames;

		public static byte[] wallLargeFrames;

		public static bool[] tileRope;

		public static bool[] tileBrick;

		public static bool[] tileMoss;

		public static bool[] tileNoAttach;

		public static bool[] tileNoFail;

		public static bool[] tileObsidianKill;

		public static bool[] tileFrameImportant;

		public static bool[] tilePile;

		public static bool[] tileBlendAll;

		public static short[] tileGlowMask;

		public static bool[] tileContainer;

		public static bool[] tileSign;

		public static bool[][] tileMerge;

		public static int cageFrames;

		public static bool critterCage;

		public static int[] bunnyCageFrame;

		public static int[] bunnyCageFrameCounter;

		public static int[] squirrelCageFrame;

		public static int[] squirrelCageFrameCounter;

		public static int[] squirrelCageFrameOrange;

		public static int[] squirrelCageFrameCounterOrange;

		public static int[] mallardCageFrame;

		public static int[] mallardCageFrameCounter;

		public static int[] duckCageFrame;

		public static int[] duckCageFrameCounter;

		public static int[] birdCageFrame;

		public static int[] birdCageFrameCounter;

		public static int[] redBirdCageFrame;

		public static int[] redBirdCageFrameCounter;

		public static int[] blueBirdCageFrame;

		public static int[] blueBirdCageFrameCounter;

		public static byte[,] butterflyCageMode;

		public static int[,] butterflyCageFrame;

		public static int[,] butterflyCageFrameCounter;

		public static int[,] scorpionCageFrame;

		public static int[,] scorpionCageFrameCounter;

		public static int[] snailCageFrame;

		public static int[] snailCageFrameCounter;

		public static int[] snail2CageFrame;

		public static int[] snail2CageFrameCounter;

		public static byte[] fishBowlFrameMode;

		public static int[] fishBowlFrame;

		public static int[] fishBowlFrameCounter;

		public static int[] frogCageFrame;

		public static int[] frogCageFrameCounter;

		public static int[] mouseCageFrame;

		public static int[] mouseCageFrameCounter;

		public static byte[,] jellyfishCageMode;

		public static int[,] jellyfishCageFrame;

		public static int[,] jellyfishCageFrameCounter;

		public static int[] wormCageFrame;

		public static int[] wormCageFrameCounter;

		public static int[] penguinCageFrame;

		public static int[] penguinCageFrameCounter;

		public static int[,] slugCageFrame;

		public static int[,] slugCageFrameCounter;

		public static int[] grasshopperCageFrame;

		public static int[] grasshopperCageFrameCounter;

		public static bool[] tileSand;

		public static bool[] tileFlame;

		public static bool[] npcCatchable;

		public static int[] tileFrame;

		public static int[] tileFrameCounter;

		public static byte[] wallFrame;

		public static byte[] wallFrameCounter;

		public static int[] backgroundWidth;

		public static int[] backgroundHeight;

		public static bool tilesLoaded;

		//public static WorldMap Map;

		public static TileProvider tile;

		public static Star[] star;

		public static Item[] item;

		public static int[] itemLockoutTime;

		public static NPC[] npc;

		public static Projectile[] projectile;

		public static int[,] projectileIdentity;

		public static CombatText[] combatText;

		public static ItemText[] itemText;

		public static Chest[] chest;

		public static Sign[] sign;

		public static int[] itemFrame;

		public static int[] itemFrameCounter;

		public static DrawAnimation[] itemAnimations;

		public static List<int> itemAnimationsRegistered;

		public static Vector2 screenPosition;

		public static Vector2 screenLastPosition;

		public static int screenWidth;

		public static int screenHeight;

		public static bool screenMaximized;

		public static int chatLength;

		public static bool chatMode;

		public static bool chatRelease;

		public static int showCount;

		public static int numChatLines;

		public static int startChatLine;

		public static string chatText;

		public static bool inputTextEnter;

		public static bool inputTextEscape;

		public static float[] hotbarScale;

		public static byte mouseTextColor;

		public static int mouseTextColorChange;

		public static bool mouseLeftRelease;

		public static bool mouseRightRelease;

		public static bool playerInventory;

		public static int stackSplit;

		public static int stackCounter;

		public static int stackDelay;

		public static int superFastStack;

		public static Item mouseItem;

		public static Item guideItem;

		public static Item reforgeItem;

		public static float inventoryScale;

		public static bool hasFocus;

		public static bool recFastScroll;

		public static bool recBigList;

		public static int recStart;

		public static Recipe[] recipe;

		public static int[] availableRecipe;

		public static float[] availableRecipeY;

		public static int numAvailableRecipes;

		public static int focusRecipe;

		public static int myPlayer;

		public static Player[] player;

		public static List<int> playerDrawDust;

		public static List<int> playerDrawGore;

		public static int spawnTileX;

		public static int spawnTileY;

		public static bool npcChatRelease;

		public static bool editSign;

		public static bool editChest;

		public static bool blockInput;

		public static string defaultChestName;

		public static string npcChatText;

		public static bool npcChatFocus1;

		public static bool npcChatFocus2;

		public static bool npcChatFocus3;

		public static int npcShop;

		public static int numShops;

		public static int npcChatCornerItem;

		public Chest[] shop = new Chest[Main.numShops];

		public static int[] travelShop;

		public static List<string> anglerWhoFinishedToday;

		public static bool anglerQuestFinished;

		public static int anglerQuest;

		public static int[] anglerQuestItemNetIDs;

		public static bool craftGuide;

		public static bool reforge;

		public static Item toolTip;

		public static string motd;

		public static bool toggleFullscreen;

		public static int numDisplayModes;

		public static int[] displayWidth;

		public static int[] displayHeight;

		public static bool gameMenu;

		private static int maxLoadPlayer;

		private static int maxLoadWorld;

		public static List<PlayerFileData> PlayerList;

		public static PlayerFileData ActivePlayerFileData;

		public static Player PendingPlayer;

		public static List<WorldFileData> WorldList;

		public static WorldFileData ActiveWorldFileData;

		public static string SavePath;

		public static string WorldPath;

		public static string CloudWorldPath;

		public static string PlayerPath;

		public static string CloudPlayerPath;

		public static Preferences Configuration;

		public static string[] itemName;

		public static string[] npcName;

		public static int PendingResolutionWidth;

		public static int PendingResolutionHeight;

		public static int invasionType;

		public static double invasionX;

		public static int invasionSize;

		public static int invasionDelay;

		public static int invasionWarn;

		public static int invasionSizeStart;

		public static bool invasionProgressNearInvasion;

		public static int invasionProgressMode;

		public static int invasionProgressIcon;

		public static int invasionProgress;

		public static int invasionProgressMax;

		public static int invasionProgressWave;

		public static int invasionProgressDisplayLeft;

		public static float invasionProgressAlpha;

		public static int[] npcFrameCount;

		public static Dictionary<int, byte> npcLifeBytes;

		public static Player clientPlayer;

		public static string getIP;

		public static string getPort;

		public static bool menuMultiplayer;

		public static bool menuServer;

		public static int netMode;

		private static int _targetNetMode;

		private static bool _hasPendingNetmodeChange;

		public static int netPlayCounter;

		public static int lastNPCUpdate;

		public static int lastItemUpdate;

		public static int maxNPCUpdates;

		public static int maxItemUpdates;

		public static string cUp;

		public static string cLeft;

		public static string cDown;

		public static string cRight;

		public static string cJump;

		public static string cThrowItem;

		public static string cHeal;

		public static string cMana;

		public static string cBuff;

		public static string cHook;

		public static string cTorch;

		public static string cInv;

		public static string cSmart;

		public static string cMount;

		public static bool cSmartToggle;

		public static bool smartDigEnabled;

		public static bool smartDigShowing;

		public static int smartDigX;

		public static int smartDigY;

		public static int cursorOverride;

		public static int signHover;

		public static string cMapZoomIn;

		public static string cMapZoomOut;

		public static string cMapAlphaUp;

		public static string cMapAlphaDown;

		public static string cMapFull;

		public static string cMapStyle;

		public static Color mouseColor;

		public static Color cursorColor;

		public static int cursorColorDirection;

		public static float cursorAlpha;

		public static float cursorScale;

		public static bool signBubble;

		public static int signX;

		public static int signY;

		public static bool hideUI;

		public static bool releaseUI;

		public static bool fixedTiming;

		public List<int> DrawCacheNPCsMoonMoon = new List<int>(200);

		public List<int> DrawCacheNPCsOverPlayers = new List<int>(200);

		public List<int> DrawCacheProjsBehindNPCsAndTiles = new List<int>(1000);

		public List<int> DrawCacheProjsBehindNPCs = new List<int>(1000);

		public List<int> DrawCacheProjsBehindProjectiles = new List<int>(1000);

		public List<int> DrawCacheNPCProjectiles = new List<int>(200);

		public static string oldStatusText;

		public static bool autoShutdown;

		public static bool serverGenLock;

		public static int sundialCooldown;

		public static bool fastForwardTime;

		public static float ambientWaterfallX;

		public static float ambientWaterfallY;

		public static float ambientWaterfallStrength;

		public static float ambientLavafallX;

		public static float ambientLavafallY;

		public static float ambientLavafallStrength;

		public static float ambientLavaX;

		public static float ambientLavaY;

		public static float ambientLavaStrength;

		public static int ambientCounter;

		public static int ProjectileUpdateLoopIndex;

		private static int maxMenuItems;

		private float[] menuItemScale = new float[Main.maxMenuItems];

		public static int selectedPlayer;

		public static int selectedWorld;

		public static int menuMode;

		public static int menuSkip;

		private static Item cpItem;

		public int textBlinkerCount;

		public int textBlinkerState;

		public static string newWorldName;

		public static string hoverItemName;

		public static Color inventoryBack;

		public static bool mouseText;

		private static int sX;

		private static Color[] oldClothesColor;

		public static int dresserX;

		public static int dresserY;

		public static Color selColor;

		public static int focusColor;

		public static int colorDelay;

		public static int setKey;

		public static int bgScroll;

		public static bool autoPass;

		public static int menuFocus;

		public static bool blockMouse;

		private bool[] menuWide = new bool[100];

		private static string[] MonolithFilterNames;

		private static string[] MonolithSkyNames;

		private static float bgScale;

		private static int bgW;

		private static Color backColor;

		private static Color trueBackColor;

		public static AchievementManager Achievements
		{
			get
			{
				return null;
			}
		}

		public static bool expertMode
		{
			get
			{
				return Main.ActiveWorldFileData != null && Main.ActiveWorldFileData.IsExpertMode;
			}
			set
			{
				if (Main.ActiveWorldFileData == null)
				{
					return;
				}
				Main.ActiveWorldFileData.IsExpertMode = value;
			}
		}

		public static Vector2 MouseScreen
		{
			get
			{
				return new Vector2((float)Main.mouseX, (float)Main.mouseY);
			}
		}

		public static Vector2 MouseWorld
		{
			get
			{
				Vector2 mouseScreen = Main.MouseScreen + Main.screenPosition;
				if (Main.player[Main.myPlayer].gravDir == -1f)
				{
					mouseScreen.Y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY;
				}
				return mouseScreen;
			}
		}

		public static string playerPathName
		{
			get
			{
				return Main.ActivePlayerFileData.Path;
			}
		}

		public static string worldPathName
		{
			get
			{
				return Main.ActiveWorldFileData.Path;
			}
			set
			{
				Main.ActiveWorldFileData.Path = value;
			}
		}

		static Main()
		{
			Main.curRelease = 156;
			Main.versionNumber = "v1.3.0.8";
			Main.versionNumber2 = "v1.3.0.8";
			Main.destroyerHB = new Vector2(0f, 0f);
			Main.drawBackGore = false;
			Main.expertLife = 2f;
			Main.expertDamage = 2f;
			Main.expertDebuffTime = 2f;
			Main.expertKnockBack = 0.9f;
			Main.expertNPCDamage = 1.5f;
			Main.knockBackMultiplier = 1f;
			Main.damageMultiplier = 1f;
			Main.ServerSideCharacter = false;
			Main.ContentLoaded = false;
			Main.maxMsg = 106;
			Main.GlobalTime = 0f;
			Main.GlobalTimerPaused = false;
			Main._tileFrameSeed = (ulong)Guid.NewGuid().GetHashCode();
			Main.npcStreamSpeed = 60;
			Main.musicError = 0;
			Main.dedServFPS = false;
			Main.dedServCount1 = 0;
			Main.dedServCount2 = 0;
			Main.superFast = false;
			Main.hairLoaded = new bool[134];
			Main.wingsLoaded = new bool[37];
			Main.goreLoaded = new bool[907];
			Main.projectileLoaded = new bool[Main.maxProjectileTypes];
			Main.itemFlameLoaded = new bool[Main.maxItemTypes];
			Main.backgroundLoaded = new bool[207];
			Main.tileSetsLoaded = new bool[Main.maxTileSets];
			Main.wallLoaded = new bool[Main.maxWallTypes];
			Main.NPCLoaded = new bool[Main.maxNPCTypes];
			Main.armorHeadLoaded = new bool[194];
			Main.armorBodyLoaded = new bool[195];
			Main.armorLegsLoaded = new bool[135];
			Main.accHandsOnLoaded = new bool[19];
			Main.accHandsOffLoaded = new bool[12];
			Main.accBackLoaded = new bool[10];
			Main.accFrontLoaded = new bool[5];
			Main.accShoesLoaded = new bool[18];
			Main.accWaistLoaded = new bool[12];
			Main.accShieldLoaded = new bool[6];
			Main.accNeckLoaded = new bool[9];
			Main.accFaceLoaded = new bool[9];
			Main.accballoonLoaded = new bool[16];
			Vector2[] vector2 = new Vector2[] { new Vector2(14f, 34f), new Vector2(14f, 32f), new Vector2(14f, 26f), new Vector2(14f, 22f), new Vector2(14f, 18f) };
			Main.OffsetsNPCOffhand = vector2;
			Vector2[] vector2Array = new Vector2[] { new Vector2(14f, 20f), new Vector2(14f, 20f), new Vector2(14f, 20f), new Vector2(14f, 18f), new Vector2(14f, 20f), new Vector2(16f, 4f), new Vector2(16f, 16f), new Vector2(18f, 14f), new Vector2(18f, 14f), new Vector2(18f, 14f), new Vector2(16f, 16f), new Vector2(16f, 16f), new Vector2(16f, 16f), new Vector2(16f, 16f), new Vector2(14f, 14f), new Vector2(14f, 14f), new Vector2(12f, 14f), new Vector2(14f, 16f), new Vector2(16f, 16f), new Vector2(16f, 16f) };
			Main.OffsetsPlayerOffhand = vector2Array;
			Vector2[] vector21 = new Vector2[] { new Vector2(6f, 19f), new Vector2(5f, 10f), new Vector2(12f, 10f), new Vector2(13f, 17f), new Vector2(12f, 19f), new Vector2(5f, 10f), new Vector2(7f, 17f), new Vector2(6f, 16f), new Vector2(6f, 16f), new Vector2(6f, 16f), new Vector2(6f, 17f), new Vector2(7f, 17f), new Vector2(7f, 17f), new Vector2(7f, 17f), new Vector2(8f, 17f), new Vector2(9f, 16f), new Vector2(9f, 12f), new Vector2(8f, 17f), new Vector2(7f, 17f), new Vector2(7f, 17f) };
			Main.OffsetsPlayerOnhand = vector21;
			Vector2[] vector2Array1 = new Vector2[] { new Vector2(0f, 2f), new Vector2(0f, 2f), new Vector2(0f, 2f), new Vector2(0f, 2f), new Vector2(0f, 2f), new Vector2(0f, 2f), new Vector2(0f, 2f), new Vector2(0f, 0f), new Vector2(0f, 0f), new Vector2(0f, 0f), new Vector2(0f, 2f), new Vector2(0f, 2f), new Vector2(0f, 2f), new Vector2(0f, 2f), new Vector2(0f, 0f), new Vector2(0f, 0f), new Vector2(0f, 0f), new Vector2(0f, 2f), new Vector2(0f, 2f), new Vector2(0f, 2f) };
			Main.OffsetsPlayerHeadgear = vector2Array1;
			Main.BlackFadeIn = 0;
			Main.noWindowBorder = false;
			Main.ugBack = 0;
			Main.oldUgBack = 0;
			Main.bgFrame = new int[1];
			Main.bgFrameCounter = new int[1];
			Main.skipMenu = false;
			Main.verboseNetplay = false;
			Main.stopTimeOuts = false;
			Main.showSpam = false;
			Main.showItemOwner = false;
			Main.nextNPC = new bool[Main.maxNPCTypes];
			Main.musicBox = -1;
			Main.musicBox2 = -1;
			Main.hbPosition = 1;
			Main.cEd = false;
			Main.wFrCounter = 0f;
			Main.wFrame = 0f;
			Main.drawDiag = false;
			Main.drawRelease = false;
			Main.drawBetterDebug = false;
			Main.betterDebugRelease = false;
			Main.renderNow = false;
			Main.drawToScreen = false;
			Main.targetSet = false;
			Main.essScale = 1f;
			Main.essDir = -1;
			Main.cloudBGX = new float[2];
			Main.cloudBG = new int[] { 112, 113 };
			Main.treeMntBG = new int[2];
			Main.treeBG = new int[3];
			Main.corruptBG = new int[3];
			Main.jungleBG = new int[3];
			Main.snowMntBG = new int[2];
			Main.snowBG = new int[3];
			Main.hallowBG = new int[3];
			Main.crimsonBG = new int[3];
			Main.desertBG = new int[2];
			Main.treeX = new int[4];
			Main.treeStyle = new int[4];
			Main.caveBackX = new int[4];
			Main.caveBackStyle = new int[4];
			Main.debugWords = "";
			Main.gamePad = false;
			Main.xMas = false;
			Main.halloween = false;
			Main.snowDust = 0;
			Main.chTitle = false;
			Main.hairWindow = false;
			Main.clothesWindow = false;
			Main.ingameOptionsWindow = false;
			Main.achievementsWindow = false;
			Main.keyCount = 0;
			Main.keyString = new string[10];
			Main.keyInt = new int[10];
			Main.gFade = 0;
			Main.gFader = 0f;
			Main.gFadeDir = 1;
			Main.netDiag = false;
			Main.txData = 0;
			Main.rxData = 0;
			Main.txMsg = 0;
			Main.rxMsg = 0;
			Main.uCarry = 0f;
			Main.drawSkip = false;
			Main.fpsCount = 0;
			Main.fpsTimer = new Stopwatch();
			Main.updateTimer = new Stopwatch();
			Main.fountainColor = -1;
			Main.monolithType = -1;
			Main.showSplash = true;
			Main.ignoreErrors = true;
			Main.defaultIP = "";
			Main.dayRate = 1;
			Main.maxScreenW = 1920;
			Main.minScreenW = 800;
			Main.maxScreenH = 1200;
			Main.minScreenH = 600;
			Main.iS = 1f;
			Main.render = false;
			Main.qaStyle = 0;
			Main.zoneX = 99;
			Main.zoneY = 87;
			Main.harpNote = 0f;
			Main.projHostile = new bool[Main.maxProjectileTypes];
			Main.projHook = new bool[Main.maxProjectileTypes];
			Main.pvpBuff = new bool[Main.maxBuffTypes];
			Main.persistentBuff = new bool[Main.maxBuffTypes];
			Main.vanityPet = new bool[191];
			Main.lightPet = new bool[191];
			Main.meleeBuff = new bool[Main.maxBuffTypes];
			Main.debuff = new bool[Main.maxBuffTypes];
			Main.buffName = new string[Main.maxBuffTypes];
			Main.buffTip = new string[Main.maxBuffTypes];
			Main.buffNoSave = new bool[Main.maxBuffTypes];
			Main.buffNoTimeDisplay = new bool[Main.maxBuffTypes];
			Main.buffDoubleApply = new bool[Main.maxBuffTypes];
			Main.maxMP = 10;
			Main.recentWorld = new string[Main.maxMP];
			Main.recentIP = new string[Main.maxMP];
			Main.recentPort = new int[Main.maxMP];
			Main.shortRender = true;
			Main.owBack = true;
			Main.quickBG = 2;
			Main.bgDelay = 0;
			Main.bgStyle = 0;
			Main.bgAlpha = new float[10];
			Main.bgAlpha2 = new float[10];
			Main.EquipPage = 0;
			Main.EquipPageSelected = 0;
			Main.wof = -1;
			Main.wofF = 0;
			Main.offScreenRange = 200;
			Main.maxMapUpdates = 250000;
			Main.refreshMap = false;
			Main.loadMapLastX = 0;
			Main.loadMapLock = false;
			Main.loadMap = false;
			Main.mapReady = false;
			Main.textureMaxWidth = 2000;
			Main.textureMaxHeight = 1800;
			Main.updateMap = false;
			Main.mapMinX = 0;
			Main.mapMaxX = 0;
			Main.mapMinY = 0;
			Main.mapMaxY = 0;
			Main.mapTimeMax = 30;
			Main.mapTime = Main.mapTimeMax;
			Main.mapTargetX = 5;
			Main.mapTargetY = 2;
			Main.initMap = new bool[Main.mapTargetX, Main.mapTargetY];
			Main.mapWasContentLost = new bool[Main.mapTargetX, Main.mapTargetY];
			Main.OurFavoriteColor = new Color(255, 231, 69);
			Main.mapInit = false;
			Main.mapEnabled = true;
			Main.mapStyle = 1;
			Main.grabMapX = 0f;
			Main.grabMapY = 0f;
			Main.miniMapX = 0;
			Main.miniMapY = 0;
			Main.miniMapWidth = 0;
			Main.miniMapHeight = 0;
			Main.mapMinimapScale = 1.25f;
			Main.mapMinimapAlpha = 1f;
			Main.mapOverlayScale = 2.5f;
			Main.mapOverlayAlpha = 0.35f;
			Main.mapFullscreen = false;
			Main.resetMapFull = false;
			Main.mapFullscreenScale = 4f;
			Main.mapFullscreenPos = new Vector2(-1f, -1f);
			Main.renderCount = 99;
			Main.saveTime = new Stopwatch();
			Main.mcColor = new Color(125, 125, 255);
			Main.hcColor = new Color(200, 125, 255);
			Main.highVersionColor = new Color(255, 255, 0);
			Main.errorColor = new Color(255, 0, 0);
			Main.mouseHC = false;
			Main.craftingHide = false;
			Main.armorHide = false;
			Main.craftingAlpha = 1f;
			Main.armorAlpha = 1f;
			Main.buffAlpha = new float[Main.maxBuffTypes];
			Main.trashItem = new Item();
			Main.hardMode = false;
			Main.sceneWaterPos = Vector2.Zero;
			Main.sceneTilePos = Vector2.Zero;
			Main.sceneTile2Pos = Vector2.Zero;
			Main.sceneWallPos = Vector2.Zero;
			Main.sceneBackgroundPos = Vector2.Zero;
			Main.maxQ = true;
			Main.gfxQuality = 1f;
			Main.gfxRate = 0.01f;
			Main.DiscoR = 255;
			Main.DiscoB = 0;
			Main.DiscoG = 0;
			Main.teamCooldown = 0;
			Main.teamCooldownLen = 300;
			Main.gamePaused = false;
			Main.gameInactive = false;
			Main.updateTime = 0;
			Main.drawTime = 0;
			Main.uCount = 0;
			Main.updateRate = 0;
			Main.frameRate = 0;
			Main.RGBRelease = false;
			Main.qRelease = false;
			Main.netRelease = false;
			Main.frameRelease = false;
			Main.showFrameRate = false;
			Main.magmaBGFrame = 0;
			Main.magmaBGFrameCounter = 0;
			Main.saveTimer = 0;
			Main.autoJoin = false;
			Main.serverStarting = false;
			Main.leftWorld = 0f;
			Main.rightWorld = 134400f;
			Main.topWorld = 0f;
			Main.bottomWorld = 38400f;
			Main.maxTilesX = (int)Main.rightWorld / 16 + 1;
			Main.maxTilesY = (int)Main.bottomWorld / 16 + 1;
			Main.maxSectionsX = Main.maxTilesX / 200;
			Main.maxSectionsY = Main.maxTilesY / 150;
			Main.numDust = 6000;
			Main.numPlayers = 0;
			Main.maxNetPlayers = 255;
			Main.maxRain = 750;
			Main.slimeWarningTime = 0;
			Main.slimeWarningDelay = 420;
			Main.slimeRainNPCSlots = 0.65f;
			Main.slimeRainNPC = new bool[Main.maxNPCTypes];
			Main.slimeRainTime = 0;
			Main.slimeRain = false;
			Main.slimeRainKillCount = 0;
			Main.cameraX = 0f;
			Main.drewLava = false;
			Main.liquidAlpha = new float[12];
			Main.waterStyle = 0;
			Main.worldRate = 1;
			Main.caveParallax = 0.88f;
			Main.liquid = new Liquid[Liquid.resLiquid];
			Main.liquidBuffer = new LiquidBuffer[10000];
			Main.dedServ = false;
			Main.spamCount = 0;
			Main.curMusic = 0;
			Main.dayMusic = 0;
			Main.ugMusic = 0;
			Main.showItemText = true;
			Main.autoSave = true;
			Main.validateSaves = true;
			Main.bannerMouseOver = false;
			Main.buffString = "";
			Main.libPath = "";
			Main.lo = 0;
			Main.LogoA = 255;
			Main.LogoB = 0;
			Main.LogoT = false;
			Main.statusText = "";
			Main.worldName = "";
			Main.background = 0;
			Main.caveBackground = 0;
			Main.ugBackTransition = 0f;
			Main.teamColor = new Color[6];
			Main.dayTime = true;
			Main.time = 13500;
			Main.moonPhase = 0;
			Main.sunModY = 0;
			Main.moonModY = 0;
			Main.grabSky = false;
			Main.bloodMoon = false;
			Main.pumpkinMoon = false;
			Main.snowMoon = false;
			Main.cloudAlpha = 0f;
			Main.maxRaining = 0f;
			Main.oldMaxRaining = 0f;
			Main.rainTime = 0;
			Main.raining = false;
			Main.eclipse = false;
			Main.eclipseLight = 0f;
			Main.checkForSpawns = 0;
			Main.helpText = 0;
			Main.autoGen = false;
			Main.autoPause = false;
			Main.projFrames = new int[Main.maxProjectileTypes];
			Main.projPet = new bool[Main.maxProjectileTypes];
			Main.demonTorch = 1f;
			Main.demonTorchDir = 1;
			Main.martianLight = 1f;
			Main.martianLightDir = 1;
			Main.placementPreview = true;
			Main.weatherCounter = 0;
			Main.cloudLimit = 200;
			Main.numClouds = Main.cloudLimit;
			Main.numCloudsTemp = Main.numClouds;
			Main.windSpeedTemp = 0f;
			Main.windSpeed = 0f;
			Main.windSpeedSet = 0f;
			Main.windSpeedSpeed = 0f;
			Main.cloud = new Cloud[200];
			Main.resetClouds = true;
			Main.fadeCounter = 0;
			Main.invAlpha = 1f;
			Main.invDir = 1f;
			Main.maxMoons = 3;
			Main.moonType = 0;
			Main.numTileColors = 31;
			Main.tileAltTextureInit = new bool[Main.maxTileSets, Main.numTileColors];
			Main.tileAltTextureDrawn = new bool[Main.maxTileSets, Main.numTileColors];
			Main.numTreeStyles = 19;
			Main.treeAltTextureInit = new bool[Main.numTreeStyles, Main.numTileColors];
			Main.treeAltTextureDrawn = new bool[Main.numTreeStyles, Main.numTileColors];
			Main.checkTreeAlt = new bool[Main.numTreeStyles, Main.numTileColors];
			Main.wallAltTextureInit = new bool[Main.maxWallTypes, Main.numTileColors];
			Main.wallAltTextureDrawn = new bool[Main.maxWallTypes, Main.numTileColors];
			Main.musicFade = new float[40];
			Main.musicVolume = 0.75f;
			Main.ambientVolume = 0.75f;
			Main.soundVolume = 1f;
			Main.MenuServerMode = ServerSocialMode.None;
			Main.tileLighted = new bool[Main.maxTileSets];
			Main.tileMergeDirt = new bool[Main.maxTileSets];
			Main.tileCut = new bool[Main.maxTileSets];
			Main.tileAlch = new bool[Main.maxTileSets];
			Main.tileShine = new int[Main.maxTileSets];
			Main.tileShine2 = new bool[Main.maxTileSets];
			Main.wallHouse = new bool[Main.maxWallTypes];
			Main.wallDungeon = new bool[Main.maxWallTypes];
			Main.wallLight = new bool[Main.maxWallTypes];
			Main.wallBlend = new int[Main.maxWallTypes];
			Main.tileStone = new bool[Main.maxTileSets];
			Main.tileAxe = new bool[Main.maxTileSets];
			Main.tileHammer = new bool[Main.maxTileSets];
			Main.tileWaterDeath = new bool[Main.maxTileSets];
			Main.tileLavaDeath = new bool[Main.maxTileSets];
			Main.tileTable = new bool[Main.maxTileSets];
			Main.tileBlockLight = new bool[Main.maxTileSets];
			Main.tileNoSunLight = new bool[Main.maxTileSets];
			Main.tileDungeon = new bool[Main.maxTileSets];
			Main.tileSpelunker = new bool[Main.maxTileSets];
			Main.tileSolidTop = new bool[Main.maxTileSets];
			Main.tileSolid = new bool[Main.maxTileSets];
			Main.tileBouncy = new bool[Main.maxTileSets];
			Main.tileValue = new short[Main.maxTileSets];
			Main.tileLargeFrames = new byte[Main.maxTileSets];
			Main.wallLargeFrames = new byte[Main.maxWallTypes];
			Main.tileRope = new bool[Main.maxTileSets];
			Main.tileBrick = new bool[Main.maxTileSets];
			Main.tileMoss = new bool[Main.maxTileSets];
			Main.tileNoAttach = new bool[Main.maxTileSets];
			Main.tileNoFail = new bool[Main.maxTileSets];
			Main.tileObsidianKill = new bool[Main.maxTileSets];
			Main.tileFrameImportant = new bool[Main.maxTileSets];
			Main.tilePile = new bool[Main.maxTileSets];
			Main.tileBlendAll = new bool[Main.maxTileSets];
			Main.tileGlowMask = new short[Main.maxTileSets];
			Main.tileContainer = new bool[Main.maxTileSets];
			Main.tileSign = new bool[Main.maxTileSets];
			Main.tileMerge = new bool[Main.maxTileSets][];
			Main.cageFrames = 25;
			Main.critterCage = false;
			Main.bunnyCageFrame = new int[Main.cageFrames];
			Main.bunnyCageFrameCounter = new int[Main.cageFrames];
			Main.squirrelCageFrame = new int[Main.cageFrames];
			Main.squirrelCageFrameCounter = new int[Main.cageFrames];
			Main.squirrelCageFrameOrange = new int[Main.cageFrames];
			Main.squirrelCageFrameCounterOrange = new int[Main.cageFrames];
			Main.mallardCageFrame = new int[Main.cageFrames];
			Main.mallardCageFrameCounter = new int[Main.cageFrames];
			Main.duckCageFrame = new int[Main.cageFrames];
			Main.duckCageFrameCounter = new int[Main.cageFrames];
			Main.birdCageFrame = new int[Main.cageFrames];
			Main.birdCageFrameCounter = new int[Main.cageFrames];
			Main.redBirdCageFrame = new int[Main.cageFrames];
			Main.redBirdCageFrameCounter = new int[Main.cageFrames];
			Main.blueBirdCageFrame = new int[Main.cageFrames];
			Main.blueBirdCageFrameCounter = new int[Main.cageFrames];
			Main.butterflyCageMode = new byte[9, Main.cageFrames];
			Main.butterflyCageFrame = new int[9, Main.cageFrames];
			Main.butterflyCageFrameCounter = new int[9, Main.cageFrames];
			Main.scorpionCageFrame = new int[2, Main.cageFrames];
			Main.scorpionCageFrameCounter = new int[2, Main.cageFrames];
			Main.snailCageFrame = new int[Main.cageFrames];
			Main.snailCageFrameCounter = new int[Main.cageFrames];
			Main.snail2CageFrame = new int[Main.cageFrames];
			Main.snail2CageFrameCounter = new int[Main.cageFrames];
			Main.fishBowlFrameMode = new byte[Main.cageFrames];
			Main.fishBowlFrame = new int[Main.cageFrames];
			Main.fishBowlFrameCounter = new int[Main.cageFrames];
			Main.frogCageFrame = new int[Main.cageFrames];
			Main.frogCageFrameCounter = new int[Main.cageFrames];
			Main.mouseCageFrame = new int[Main.cageFrames];
			Main.mouseCageFrameCounter = new int[Main.cageFrames];
			Main.jellyfishCageMode = new byte[3, Main.cageFrames];
			Main.jellyfishCageFrame = new int[3, Main.cageFrames];
			Main.jellyfishCageFrameCounter = new int[3, Main.cageFrames];
			Main.wormCageFrame = new int[Main.cageFrames];
			Main.wormCageFrameCounter = new int[Main.cageFrames];
			Main.penguinCageFrame = new int[Main.cageFrames];
			Main.penguinCageFrameCounter = new int[Main.cageFrames];
			Main.slugCageFrame = new int[3, Main.cageFrames];
			Main.slugCageFrameCounter = new int[3, Main.cageFrames];
			Main.grasshopperCageFrame = new int[Main.cageFrames];
			Main.grasshopperCageFrameCounter = new int[Main.cageFrames];
			Main.tileSand = new bool[Main.maxTileSets];
			Main.tileFlame = new bool[Main.maxTileSets];
			Main.npcCatchable = new bool[Main.maxNPCTypes];
			Main.tileFrame = new int[Main.maxTileSets];
			Main.tileFrameCounter = new int[Main.maxTileSets];
			Main.wallFrame = new byte[Main.maxWallTypes];
			Main.wallFrameCounter = new byte[Main.maxWallTypes];
			Main.backgroundWidth = new int[207];
			Main.backgroundHeight = new int[207];
			Main.tilesLoaded = false;
			//Main.Map = new WorldMap(Main.maxTilesX, Main.maxTilesY);
            //Main.tile = new Tile[Main.maxTilesX, Main.maxTilesY];
            Main.tile = new TileProvider();
			Main.star = new Star[130];
			Main.item = new Item[401];
			Main.itemLockoutTime = new int[401];
			Main.npc = new NPC[201];
			Main.projectile = new Projectile[1001];
			Main.projectileIdentity = new int[256, 1001];
			Main.combatText = new CombatText[100];
			Main.itemText = new ItemText[20];
			Main.chest = new Chest[1000];
			Main.sign = new Sign[1000];
			Main.itemFrame = new int[401];
			Main.itemFrameCounter = new int[401];
			Main.itemAnimations = new DrawAnimation[Main.maxItemTypes];
			Main.itemAnimationsRegistered = new List<int>();
			Main.screenWidth = 1152;
			Main.screenHeight = 864;
			Main.screenMaximized = false;
			Main.chatLength = 600;
			Main.chatMode = false;
			Main.chatRelease = false;
			Main.showCount = 10;
			Main.numChatLines = 500;
			Main.startChatLine = 0;
			Main.chatText = "";
			Main.inputTextEnter = false;
			Main.inputTextEscape = false;
			Main.hotbarScale = new float[] { 1f, 0.75f, 0.75f, 0.75f, 0.75f, 0.75f, 0.75f, 0.75f, 0.75f, 0.75f };
			Main.mouseTextColor = 0;
			Main.mouseTextColorChange = 1;
			Main.mouseLeftRelease = false;
			Main.mouseRightRelease = false;
			Main.playerInventory = false;
			Main.stackCounter = 0;
			Main.stackDelay = 7;
			Main.superFastStack = 0;
			Main.mouseItem = new Item();
			Main.guideItem = new Item();
			Main.reforgeItem = new Item();
			Main.inventoryScale = 0.75f;
			Main.hasFocus = true;
			Main.recFastScroll = false;
			Main.recBigList = false;
			Main.recStart = 0;
			Main.recipe = new Recipe[Recipe.maxRecipes];
			Main.availableRecipe = new int[Recipe.maxRecipes];
			Main.availableRecipeY = new float[Recipe.maxRecipes];
			Main.myPlayer = 0;
			Main.player = new Player[256];
			Main.playerDrawDust = new List<int>();
			Main.playerDrawGore = new List<int>();
			Main.npcChatRelease = false;
			Main.editSign = false;
			Main.editChest = false;
			Main.blockInput = false;
			Main.defaultChestName = string.Empty;
			Main.npcChatText = "";
			Main.npcChatFocus1 = false;
			Main.npcChatFocus2 = false;
			Main.npcChatFocus3 = false;
			Main.npcShop = 0;
			Main.numShops = 21;
			Main.npcChatCornerItem = 0;
			Main.travelShop = new int[40];
			Main.anglerWhoFinishedToday = new List<string>();
			Main.anglerQuest = 0;
			Main.anglerQuestItemNetIDs = new int[] { 2450, 2451, 2452, 2453, 2454, 2455, 2456, 2457, 2458, 2459, 2460, 2461, 2462, 2463, 2464, 2465, 2466, 2467, 2468, 2469, 2470, 2471, 2472, 2473, 2474, 2475, 2476, 2477, 2478, 2479, 2480, 2481, 2482, 2483, 2484, 2485, 2486, 2487, 2488 };
			Main.craftGuide = false;
			Main.reforge = false;
			Main.toolTip = new Item();
			Main.motd = "";
			Main.numDisplayModes = 0;
			Main.displayWidth = new int[99];
			Main.displayHeight = new int[99];
			Main.gameMenu = true;
			Main.maxLoadPlayer = 1000;
			Main.maxLoadWorld = 1000;
			Main.PlayerList = new List<PlayerFileData>();
			Main.ActivePlayerFileData = new PlayerFileData();
			Main.PendingPlayer = null;
			Main.WorldList = new List<WorldFileData>();
			Main.ActiveWorldFileData = new WorldFileData();
			object[] objArray = new object[] { Environment.GetFolderPath(Environment.SpecialFolder.Personal), Path.DirectorySeparatorChar, "My Games", Path.DirectorySeparatorChar, "Terraria" };
			Main.SavePath = string.Concat(objArray);
			Main.WorldPath = string.Concat(Main.SavePath, Path.DirectorySeparatorChar, "Worlds");
			Main.CloudWorldPath = "worlds";
			Main.PlayerPath = string.Concat(Main.SavePath, Path.DirectorySeparatorChar, "Players");
			Main.CloudPlayerPath = "players";
			Main.Configuration = new Preferences(string.Concat(Main.SavePath, Path.DirectorySeparatorChar, "config.json"), false, false);
			Main.itemName = new string[Main.maxItemTypes];
			Main.npcName = new string[Main.maxNPCTypes];
			Main.PendingResolutionWidth = 800;
			Main.PendingResolutionHeight = 600;
			Main.invasionType = 0;
			Main.invasionX = 0;
			Main.invasionSize = 0;
			Main.invasionDelay = 0;
			Main.invasionWarn = 0;
			Main.invasionSizeStart = 0;
			Main.invasionProgressNearInvasion = false;
			Main.invasionProgressMode = 2;
			Main.invasionProgressIcon = 0;
			Main.invasionProgress = 0;
			Main.invasionProgressMax = 0;
			Main.invasionProgressWave = 0;
			Main.invasionProgressDisplayLeft = 0;
			Main.invasionProgressAlpha = 0f;
			Main.npcFrameCount = new int[] { 1, 2, 2, 3, 6, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 25, 23, 25, 21, 15, 26, 2, 10, 1, 16, 16, 16, 3, 1, 15, 3, 1, 3, 1, 1, 21, 25, 1, 1, 1, 3, 3, 15, 3, 7, 7, 4, 5, 6, 5, 3, 3, 23, 6, 3, 6, 6, 2, 5, 3, 2, 7, 7, 4, 2, 8, 1, 5, 1, 2, 4, 16, 5, 4, 4, 15, 15, 15, 15, 2, 4, 6, 6, 24, 16, 1, 1, 1, 1, 1, 1, 4, 3, 1, 1, 1, 1, 1, 1, 5, 6, 7, 16, 1, 1, 25, 23, 12, 20, 21, 1, 2, 2, 3, 6, 1, 1, 1, 15, 4, 11, 1, 23, 6, 6, 3, 1, 2, 2, 1, 3, 4, 1, 2, 1, 4, 2, 1, 15, 3, 25, 4, 5, 7, 3, 2, 12, 12, 4, 4, 4, 8, 8, 9, 5, 6, 4, 15, 23, 3, 3, 8, 5, 4, 13, 15, 12, 4, 14, 14, 3, 2, 5, 3, 2, 3, 23, 5, 14, 16, 5, 2, 2, 12, 3, 3, 3, 3, 2, 2, 2, 2, 2, 7, 14, 15, 16, 8, 3, 15, 15, 15, 2, 3, 20, 25, 23, 26, 4, 4, 16, 16, 20, 20, 20, 2, 2, 2, 2, 8, 12, 3, 4, 2, 4, 25, 26, 26, 6, 3, 3, 3, 3, 3, 3, 4, 4, 5, 4, 6, 7, 15, 4, 7, 6, 1, 1, 2, 4, 3, 5, 3, 3, 3, 4, 5, 6, 4, 2, 1, 8, 4, 4, 1, 8, 1, 4, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 3, 3, 3, 3, 3, 3, 15, 3, 6, 12, 20, 20, 20, 15, 15, 15, 5, 5, 6, 6, 5, 2, 7, 2, 6, 6, 6, 6, 6, 15, 15, 15, 15, 15, 11, 4, 2, 2, 3, 3, 3, 15, 15, 15, 10, 14, 12, 1, 10, 8, 3, 3, 2, 2, 2, 2, 7, 15, 15, 15, 6, 3, 10, 10, 6, 9, 8, 9, 8, 20, 10, 6, 23, 1, 4, 24, 2, 4, 6, 6, 10, 15, 15, 15, 15, 4, 4, 26, 23, 8, 2, 4, 4, 4, 4, 2, 2, 4, 12, 12, 9, 9, 9, 1, 9, 11, 2, 2, 9, 5, 6, 4, 18, 8, 11, 1, 4, 5, 8, 4, 1, 1, 1, 1, 4, 2, 5, 4, 11, 5, 11, 1, 1, 1, 10, 10, 15, 8, 17, 6, 6, 1, 12, 12, 13, 15, 9, 5, 10, 7, 7, 7, 7, 7, 7, 7, 4, 4, 16, 16, 25, 5, 7, 3, 10, 2, 6, 2, 19, 19, 19, 19, 26, 3, 1, 1, 1, 1, 1, 16, 21, 9, 16, 7, 6, 18, 13, 20, 12, 12, 20, 6, 14, 14, 14, 14, 6, 1, 3, 25, 19, 20, 22, 2, 4, 4, 4, 11, 9, 8, 1, 9, 1, 8, 8, 12, 12, 11, 11, 11, 11, 11, 11, 11, 11, 11, 1, 6, 9, 1, 1, 1, 1, 1, 1, 4, 1, 10, 1, 8, 4, 1, 5, 8, 8, 8, 8, 9, 9, 5, 4, 8, 16, 8, 2, 3, 3, 6, 6 };
			Main.npcLifeBytes = new Dictionary<int, byte>();
			Main.clientPlayer = new Player();
			Main.getIP = Main.defaultIP;
			Main.getPort = Convert.ToString(Netplay.ListenPort);
			Main.menuMultiplayer = false;
			Main.menuServer = false;
			Main.netMode = 0;
			Main._targetNetMode = 0;
			Main._hasPendingNetmodeChange = false;
			Main.maxNPCUpdates = 5;
			Main.maxItemUpdates = 5;
			Main.cUp = "W";
			Main.cLeft = "A";
			Main.cDown = "S";
			Main.cRight = "D";
			Main.cJump = "Space";
			Main.cThrowItem = "T";
			Main.cHeal = "H";
			Main.cMana = "J";
			Main.cBuff = "B";
			Main.cHook = "E";
			Main.cTorch = "LeftShift";
			Main.cInv = "Escape";
			Main.cSmart = "LeftControl";
			Main.cMount = "R";
			Main.cSmartToggle = true;
			Main.smartDigEnabled = false;
			Main.smartDigShowing = false;
			Main.cursorOverride = -1;
			Main.signHover = -1;
			Main.cMapZoomIn = "Add";
			Main.cMapZoomOut = "Subtract";
			Main.cMapAlphaUp = "PageUp";
			Main.cMapAlphaDown = "PageDown";
			Main.cMapFull = "M";
			Main.cMapStyle = "Tab";
			Main.mouseColor = new Color(255, 50, 95);
			Main.cursorColor = Color.White;
			Main.cursorColorDirection = 1;
			Main.cursorAlpha = 0f;
			Main.cursorScale = 0f;
			Main.signBubble = false;
			Main.signX = 0;
			Main.signY = 0;
			Main.hideUI = false;
			Main.releaseUI = false;
			Main.fixedTiming = true;
			Main.oldStatusText = "";
			Main.autoShutdown = false;
			Main.serverGenLock = false;
			Main.sundialCooldown = 0;
			Main.fastForwardTime = false;
			Main.ambientWaterfallX = -1f;
			Main.ambientWaterfallY = -1f;
			Main.ambientWaterfallStrength = 0f;
			Main.ambientLavafallX = -1f;
			Main.ambientLavafallY = -1f;
			Main.ambientLavafallStrength = 0f;
			Main.ambientLavaX = -1f;
			Main.ambientLavaY = -1f;
			Main.ambientLavaStrength = 0f;
			Main.ambientCounter = 0;
			Main.ProjectileUpdateLoopIndex = -1;
			Main.maxMenuItems = 16;
			Main.selectedPlayer = 0;
			Main.selectedWorld = 0;
			Main.menuMode = 0;
			Main.menuSkip = 0;
			Main.cpItem = new Item();
			Main.newWorldName = "";
			Main.hoverItemName = "";
			Main.inventoryBack = new Color(220, 220, 220, 220);
			Main.mouseText = false;
			Main.sX = Main.screenWidth - 800;
			Main.oldClothesColor = new Color[4];
			Main.selColor = Color.White;
			Main.focusColor = 0;
			Main.colorDelay = 0;
			Main.setKey = -1;
			Main.bgScroll = 0;
			Main.autoPass = false;
			Main.menuFocus = 0;
			Main.blockMouse = false;
			string[] strArrays = new string[] { "MonolithVortex", "MonolithNebula", "MonolithStardust", "MonolithSolar" };
			Main.MonolithFilterNames = strArrays;
			string[] strArrays1 = new string[] { "MonolithVortex", "MonolithNebula", "MonolithStardust", "MonolithSolar" };
			Main.MonolithSkyNames = strArrays1;
			Main.bgScale = 1f;
			Main.bgW = (int)(1024f * Main.bgScale);
			Main.backColor = Color.White;
			Main.trueBackColor = Main.backColor;
		}

		public Main()
		{
			Main.instance = this;
		}

		public static void Ambience()
		{
		}

		public static void AnglerQuestSwap()
		{
			if (Main.netMode == 1)
			{
				return;
			}
			Main.anglerWhoFinishedToday.Clear();
			Main.anglerQuestFinished = false;
			bool flag = true;
			while (flag)
			{
				flag = false;
				Main.anglerQuest = Main.rand.Next((int)Main.anglerQuestItemNetIDs.Length);
				int num = Main.anglerQuestItemNetIDs[Main.anglerQuest];
				if (num == 2454 && (!Main.hardMode || WorldGen.crimson))
				{
					flag = true;
				}
				if (num == 2457 && WorldGen.crimson)
				{
					flag = true;
				}
				if (num == 2462 && !Main.hardMode)
				{
					flag = true;
				}
				if (num == 2463 && (!Main.hardMode || !WorldGen.crimson))
				{
					flag = true;
				}
				if (num == 2465 && !Main.hardMode)
				{
					flag = true;
				}
				if (num == 2468 && !Main.hardMode)
				{
					flag = true;
				}
				if (num == 2471 && !Main.hardMode)
				{
					flag = true;
				}
				if (num == 2473 && !Main.hardMode)
				{
					flag = true;
				}
				if (num == 2477 && !WorldGen.crimson)
				{
					flag = true;
				}
				if (num == 2480 && !Main.hardMode)
				{
					flag = true;
				}
				if (num == 2483 && !Main.hardMode)
				{
					flag = true;
				}
				if (num == 2484 && !Main.hardMode)
				{
					flag = true;
				}
				if (num != 2485 || !WorldGen.crimson)
				{
					continue;
				}
				flag = true;
			}
			NetMessage.SendAnglerQuest();
		}

		public void autoCreate(string newOpt)
		{
			if (newOpt == "0")
			{
				Main.autoGen = false;
				return;
			}
			if (newOpt == "1")
			{
				Main.maxTilesX = 4200;
				Main.maxTilesY = 1200;
				Main.autoGen = true;
				return;
			}
			if (newOpt == "2")
			{
				Main.maxTilesX = 6300;
				Main.maxTilesY = 1800;
				Main.autoGen = true;
				return;
			}
			if (newOpt == "3")
			{
				Main.maxTilesX = 8400;
				Main.maxTilesY = 2400;
				Main.autoGen = true;
			}
		}

		public void AutoHost()
		{
			Main.menuMultiplayer = true;
			Main.menuServer = true;
			Main.menuMode = 1;
		}

		public void AutoJoin(string IP)
		{
			Main.defaultIP = IP;
			Main.getIP = IP;
			Netplay.SetRemoteIP(Main.defaultIP);
			Main.autoJoin = true;
		}

		public void AutoPass()
		{
			Main.autoPass = true;
		}

		public void autoShut()
		{
			Main.autoShutdown = true;
		}

		private static Color buffColor(Color newColor, float R, float G, float B, float A)
		{
			newColor.R = (byte)((float)newColor.R * R);
			newColor.G = (byte)((float)newColor.G * G);
			newColor.B = (byte)((float)newColor.B * B);
			newColor.A = (byte)((float)newColor.A * A);
			return newColor;
		}

		public static void BuyHairWindow()
		{
			Main.hairWindow = false;
			Main.player[Main.myPlayer].talkNPC = -1;
			Main.npcChatCornerItem = 0;
			NetMessage.SendData((int)PacketTypes.PlayerInfo, -1, -1, Main.player[Main.myPlayer].name, Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
		}

		protected void CacheNPCDraws()
		{
			this.DrawCacheNPCsMoonMoon.Clear();
			this.DrawCacheNPCsOverPlayers.Clear();
			this.DrawCacheNPCProjectiles.Clear();
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active)
				{
					if (Main.npc[i].type == NPCID.MoonLordCore && Main.npc[i].ai[0] >= 0f)
					{
						int num = i;
						int num1 = -1;
						int num2 = -1;
						int num3 = -1;
						for (int j = 0; j < 200; j++)
						{
							if (Main.npc[j].active && Main.npc[j].ai[3] == (float)num)
							{
								if (num1 == -1 && Main.npc[j].type == NPCID.MoonLordHand && Main.npc[j].ai[2] == 0f)
								{
									num1 = j;
								}
								if (num2 == -1 && Main.npc[j].type == NPCID.MoonLordHand && Main.npc[j].ai[2] == 1f)
								{
									num2 = j;
								}
								if (num3 == -1 && Main.npc[j].type == NPCID.MoonLordHead)
								{
									num3 = j;
								}
								if (num1 != -1 && num2 != -1 && num3 != -1)
								{
									break;
								}
							}
						}
						if (num1 != -1 && num2 != -1 && num3 != -1)
						{
							this.DrawCacheNPCsMoonMoon.Add(num);
							if (num1 != -1)
							{
								this.DrawCacheNPCsMoonMoon.Add(num1);
							}
							if (num2 != -1)
							{
								this.DrawCacheNPCsMoonMoon.Add(num2);
							}
							if (num3 != -1)
							{
								this.DrawCacheNPCsMoonMoon.Add(num3);
							}
						}
					}
					else if (Main.npc[i].type == NPCID.NebulaHeadcrab && Main.npc[i].ai[0] == 5f)
					{
						this.DrawCacheNPCsOverPlayers.Add(i);
					}
					else if (Main.npc[i].type == NPCID.SolarFlare || Main.npc[i].type == NPCID.SolarGoop)
					{
						this.DrawCacheNPCProjectiles.Add(i);
					}
				}
			}
		}

		protected void CacheProjDraws()
		{
			this.DrawCacheProjsBehindNPCsAndTiles.Clear();
			this.DrawCacheProjsBehindNPCs.Clear();
			this.DrawCacheProjsBehindProjectiles.Clear();
			for (int i = 0; i < 1000; i++)
			{
				if (Main.projectile[i].active)
				{
					if (Main.projectile[i].type == ProjectileID.VortexVortexLightning || Main.projectile[i].type == ProjectileID.VortexVortexPortal || Main.projectile[i].type == ProjectileID.MoonlordTurret || Main.projectile[i].type == ProjectileID.BoneJavelin || Main.projectile[i].type == ProjectileID.NebulaArcanum || Main.projectile[i].type == ProjectileID.Daybreak)
					{
						this.DrawCacheProjsBehindNPCsAndTiles.Add(i);
					}
					if (Main.projectile[i].type == ProjectileID.StardustDragon1 || Main.projectile[i].type == ProjectileID.StardustDragon2 || Main.projectile[i].type == ProjectileID.StardustDragon3 || Main.projectile[i].type == ProjectileID.StardustDragon4)
					{
						this.DrawCacheProjsBehindProjectiles.Add(i);
					}
					if (Main.projectile[i].type == ProjectileID.Daybreak || Main.projectile[i].type == ProjectileID.BoneJavelin)
					{
						bool flag = true;
						if (Main.projectile[i].ai[0] == 1f)
						{
							int num = (int)Main.projectile[i].ai[1];
							if (num >= 0 && num < 200 && Main.npc[num].active)
							{
								if (Main.npc[num].behindTiles)
								{
									this.DrawCacheProjsBehindNPCsAndTiles.Add(i);
								}
								else
								{
									this.DrawCacheProjsBehindNPCs.Add(i);
								}
								flag = false;
							}
						}
						if (flag)
						{
							this.DrawCacheProjsBehindProjectiles.Add(i);
						}
					}
				}
			}
		}

		public static double CalculateDamage(int Damage, int Defense)
		{
			double damage = (double)Damage - (double)Defense * 0.5;
			if (damage < 1)
			{
				damage = 1;
			}
			return damage;
		}

		public static double CalculatePlayerDamage(int Damage, int Defense)
		{
			double damage = (double)Damage - (double)Defense * 0.5;
			if (Main.expertMode)
			{
				damage = (double)Damage - (double)Defense * 0.75;
			}
			if (damage < 1)
			{
				damage = 1;
			}
			return damage;
		}

		public static void CancelClothesWindow(bool quiet = false)
		{
			if (!Main.clothesWindow)
			{
				return;
			}
			Main.clothesWindow = false;
			Main.player[Main.myPlayer].shirtColor = Main.oldClothesColor[0];
			Main.player[Main.myPlayer].underShirtColor = Main.oldClothesColor[1];
			Main.player[Main.myPlayer].pantsColor = Main.oldClothesColor[2];
			Main.player[Main.myPlayer].shoeColor = Main.oldClothesColor[3];
		}

		public static void CancelHairWindow()
		{
			if (!Main.hairWindow)
			{
				return;
			}
			Main.hairWindow = false;
			if (Main.player[Main.myPlayer].talkNPC > -1 && Main.npc[Main.player[Main.myPlayer].talkNPC].type == 353)
			{
				Main.player[Main.myPlayer].talkNPC = -1;
			}
		}

		public static bool canDrawColorTile(int i, int j)
		{
			return false;
		}

		public static bool canDrawColorTile(ushort type, int color)
		{
			return false;
		}

		public static bool canDrawColorTree(int i, int j, int treeColor)
		{
			return true;
		}

		public static bool canDrawColorWall(int i, int j)
		{
			return false;
		}

		public static bool CanStartInvasion(int type = 1, bool ignoreDelay = false)
		{
			if (Main.invasionType != 0)
			{
				return false;
			}
			if (Main.invasionDelay != 0 && !ignoreDelay)
			{
				return false;
			}
			int num = 0;
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active && Main.player[i].statLifeMax >= 200)
				{
					num++;
				}
			}
			return num > 0;
		}

		private static void ChangeRain()
		{
			if (Main.cloudBGActive >= 1f || (double)Main.numClouds > 150)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.maxRaining = (float)Main.rand.Next(20, 90) * 0.01f;
					return;
				}
				Main.maxRaining = (float)Main.rand.Next(40, 90) * 0.01f;
				return;
			}
			if ((double)Main.numClouds > 100)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.maxRaining = (float)Main.rand.Next(10, 70) * 0.01f;
					return;
				}
				Main.maxRaining = (float)Main.rand.Next(20, 60) * 0.01f;
				return;
			}
			if (Main.rand.Next(3) == 0)
			{
				Main.maxRaining = (float)Main.rand.Next(5, 40) * 0.01f;
				return;
			}
			Main.maxRaining = (float)Main.rand.Next(5, 30) * 0.01f;
		}

		protected void CheckBunny()
		{
			try
			{
				RegistryKey currentUser = Registry.CurrentUser;
				currentUser = currentUser.CreateSubKey("Software\\Terraria");
				if (currentUser != null && currentUser.GetValue("Bunny") != null && currentUser.GetValue("Bunny").ToString() == "1")
				{
					Main.cEd = true;
				}
			}
			catch
			{
				Main.cEd = false;
			}
		}

		public static void checkHalloween()
		{
			DateTime now = DateTime.Now;
			int day = now.Day;
			int month = now.Month;
			bool _halloween = false;
			if (day >= 20 && month == 10)
			{
				_halloween = true;
				return;
			}
			if (day <= 10 && month == 11)
			{
				_halloween = true;
				return;
			}

			ServerApi.Hooks.InvokeWorldHalloweenCheck(ref _halloween);

			Main.halloween = _halloween;
		}

		public static void CheckInvasionProgressDisplay()
		{
			if (Main.invasionProgressMode != 2)
			{
				Main.invasionProgressNearInvasion = false;
				return;
			}
			bool flag = false;
			Player player = Main.player[Main.myPlayer];
			Rectangle rectangle = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
			int num = 5000;
			int num1 = 0;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active)
				{
					num1 = 0;
					int num2 = Main.npc[i].type;
					if (num2 > 145)
					{
						if (num2 > 350)
						{
							switch (num2)
							{
								case 381:
								case 382:
								case 383:
								case 385:
								case 386:
								case 388:
								case 389:
								case 390:
								case 391:
								case 395:
									{
										num1 = 6;
										goto Label0;
									}
								case 384:
								case 387:
								case 392:
								case 393:
								case 394:
									{
										goto Label0;
									}
								default:
									{
										if (num2 == 491)
										{
											break;
										}
										goto Label0;
									}
							}
						}
						else
						{
							switch (num2)
							{
								case 212:
								case 213:
								case 214:
								case 215:
								case 216:
									{
										break;
									}
								default:
									{
										switch (num2)
										{
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
											case 315:
											case 325:
											case 326:
											case 327:
											case 329:
											case 330:
												{
													num1 = 2;
													goto Label0;
												}
											case 338:
											case 339:
											case 340:
											case 341:
											case 342:
											case 343:
											case 344:
											case 345:
											case 346:
											case 347:
											case 348:
											case 349:
											case 350:
												{
													num1 = 1;
													goto Label0;
												}
											default:
												{
													goto Label0;
												}
										}
									}
							}
						}
						num1 = 5;
					}
					else
					{
						switch (num2)
						{
							case 26:
							case 27:
							case 28:
							case 29:
								{
									num1 = 3;
									break;
								}
							default:
								{
									if (num2 == 111)
									{
										goto case 29;
									}
									switch (num2)
									{
										case 143:
										case 144:
										case 145:
											{
												num1 = 4;
												break;
											}
									}
									break;
								}
						}
					}
					Label0:
					if (num1 != 0 && (num1 != 1 || (double)player.position.Y <= Main.worldSurface * 16 && !Main.dayTime && Main.snowMoon) && (num1 != 2 || (double)player.position.Y <= Main.worldSurface * 16 && !Main.dayTime && Main.pumpkinMoon) && (num1 <= 2 || (double)player.position.Y <= Main.worldSurface * 16 && Main.invasionType == num1 - 2))
					{
						Rectangle rectangle1 = new Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
						if (rectangle.Intersects(rectangle1))
						{
							flag = true;
							break;
						}
					}
				}
			}
			Main.invasionProgressNearInvasion = flag;
			if (flag && Main.invasionProgressIcon == 0)
			{
				if (Main.snowMoon)
				{
					int num3 = (new int[] { 0, 25, 15, 10, 30, 100, 160, 180, 200, 250, 300, 375, 450, 525, 675, 850, 1025, 1325, 1550, 2000, 0 })[NPC.waveCount];
					Main.ReportInvasionProgress((int)NPC.waveKills, num3, 1, NPC.waveCount);
					return;
				}
				if (Main.pumpkinMoon)
				{
					int num4 = (new int[] { 0, 25, 40, 50, 80, 100, 160, 180, 200, 250, 300, 375, 450, 525, 675, 0 })[NPC.waveCount];
					Main.ReportInvasionProgress((int)NPC.waveKills, num4, 2, NPC.waveCount);
					return;
				}
				int num5 = 1;
				if (Main.invasionType != 0 && Main.invasionSizeStart != 0)
				{
					num5 = Main.invasionSizeStart;
				}
				Main.ReportInvasionProgress(Main.invasionSizeStart - Main.invasionSize, num5, num1, 0);
			}
		}

		protected bool checkMap(int i, int j)
		{
			return true;
		}

		private static void CheckMonoliths()
		{
		}

		public static void CheckXMas()
		{
			DateTime now = DateTime.Now;
			bool xmas = false;
			if (now.Day >= 15 && now.Month == 12)
			{
				xmas = true;
				return;
			}

			ServerApi.Hooks.InvokeWorldChristmasCheck(ref xmas);

			Main.xMas = xmas;
		}

		public static void ClearInput()
		{
			Main.keyCount = 0;
		}

		public static void CritterCages()
		{
			int num;
			if (Main.critterCage)
			{
				for (int i = 0; i < Main.cageFrames; i++)
				{
					if (Main.bunnyCageFrame[i] == 0)
					{
						Main.bunnyCageFrameCounter[i] = Main.bunnyCageFrameCounter[i] + 1;
						if (Main.bunnyCageFrameCounter[i] > Main.rand.Next(30, 900))
						{
							if (Main.rand.Next(3) != 0)
							{
								num = Main.rand.Next(7);
								if (num == 0)
								{
									Main.bunnyCageFrame[i] = 4;
								}
								else if (num > 2)
								{
									Main.bunnyCageFrame[i] = 1;
								}
								else
								{
									Main.bunnyCageFrame[i] = 2;
								}
							}
							Main.bunnyCageFrameCounter[i] = 0;
						}
					}
					else if (Main.bunnyCageFrame[i] == 1)
					{
						Main.bunnyCageFrameCounter[i] = Main.bunnyCageFrameCounter[i] + 1;
						if (Main.bunnyCageFrameCounter[i] >= 10)
						{
							Main.bunnyCageFrameCounter[i] = 0;
							Main.bunnyCageFrame[i] = 0;
						}
					}
					else if (Main.bunnyCageFrame[i] >= 2 && Main.bunnyCageFrame[i] <= 3)
					{
						Main.bunnyCageFrameCounter[i] = Main.bunnyCageFrameCounter[i] + 1;
						if (Main.bunnyCageFrameCounter[i] >= 10)
						{
							Main.bunnyCageFrameCounter[i] = 0;
							Main.bunnyCageFrame[i] = Main.bunnyCageFrame[i] + 1;
						}
						if (Main.bunnyCageFrame[i] > 3)
						{
							Main.bunnyCageFrame[i] = 0;
						}
					}
					else if (Main.bunnyCageFrame[i] >= 4 && Main.bunnyCageFrame[i] <= 10)
					{
						Main.bunnyCageFrameCounter[i] = Main.bunnyCageFrameCounter[i] + 1;
						if (Main.bunnyCageFrameCounter[i] >= 5)
						{
							Main.bunnyCageFrameCounter[i] = 0;
							Main.bunnyCageFrame[i] = Main.bunnyCageFrame[i] + 1;
						}
					}
					else if (Main.bunnyCageFrame[i] == 11)
					{
						Main.bunnyCageFrameCounter[i] = Main.bunnyCageFrameCounter[i] + 1;
						if (Main.bunnyCageFrameCounter[i] > Main.rand.Next(30, 900))
						{
							if (Main.rand.Next(3) != 0)
							{
								num = Main.rand.Next(7);
								if (num != 0)
								{
									Main.bunnyCageFrame[i] = 12;
								}
								else
								{
									Main.bunnyCageFrame[i] = 13;
								}
							}
							Main.bunnyCageFrameCounter[i] = 0;
						}
					}
					else if (Main.bunnyCageFrame[i] == 12)
					{
						Main.bunnyCageFrameCounter[i] = Main.bunnyCageFrameCounter[i] + 1;
						if (Main.bunnyCageFrameCounter[i] >= 10)
						{
							Main.bunnyCageFrameCounter[i] = 0;
							Main.bunnyCageFrame[i] = 11;
						}
					}
					else if (Main.bunnyCageFrame[i] >= 13)
					{
						Main.bunnyCageFrameCounter[i] = Main.bunnyCageFrameCounter[i] + 1;
						if (Main.bunnyCageFrameCounter[i] >= 5)
						{
							Main.bunnyCageFrameCounter[i] = 0;
							Main.bunnyCageFrame[i] = Main.bunnyCageFrame[i] + 1;
						}
						if (Main.bunnyCageFrame[i] > 21)
						{
							Main.bunnyCageFrame[i] = 0;
						}
					}
				}
				for (int j = 0; j < Main.cageFrames; j++)
				{
					if (Main.squirrelCageFrame[j] == 0)
					{
						Main.squirrelCageFrameCounter[j] = Main.squirrelCageFrameCounter[j] + 1;
						if (Main.squirrelCageFrameCounter[j] > Main.rand.Next(30, 900))
						{
							if (Main.rand.Next(3) != 0)
							{
								num = Main.rand.Next(7);
								if (num == 0)
								{
									Main.squirrelCageFrame[j] = 4;
								}
								else if (num > 2)
								{
									Main.squirrelCageFrame[j] = 1;
								}
								else
								{
									Main.squirrelCageFrame[j] = 2;
								}
							}
							Main.squirrelCageFrameCounter[j] = 0;
						}
					}
					else if (Main.squirrelCageFrame[j] == 1)
					{
						Main.squirrelCageFrameCounter[j] = Main.squirrelCageFrameCounter[j] + 1;
						if (Main.squirrelCageFrameCounter[j] >= 10)
						{
							Main.squirrelCageFrameCounter[j] = 0;
							Main.squirrelCageFrame[j] = 0;
						}
					}
					else if (Main.squirrelCageFrame[j] >= 2 && Main.squirrelCageFrame[j] <= 3)
					{
						Main.squirrelCageFrameCounter[j] = Main.squirrelCageFrameCounter[j] + 1;
						if (Main.squirrelCageFrameCounter[j] >= 5)
						{
							Main.squirrelCageFrameCounter[j] = 0;
							Main.squirrelCageFrame[j] = Main.squirrelCageFrame[j] + 1;
						}
						if (Main.squirrelCageFrame[j] > 3)
						{
							if (Main.rand.Next(5) != 0)
							{
								Main.squirrelCageFrame[j] = 2;
							}
							else
							{
								Main.squirrelCageFrame[j] = 0;
							}
						}
					}
					else if (Main.squirrelCageFrame[j] >= 4 && Main.squirrelCageFrame[j] <= 8)
					{
						Main.squirrelCageFrameCounter[j] = Main.squirrelCageFrameCounter[j] + 1;
						if (Main.squirrelCageFrameCounter[j] >= 5)
						{
							Main.squirrelCageFrameCounter[j] = 0;
							Main.squirrelCageFrame[j] = Main.squirrelCageFrame[j] + 1;
						}
					}
					else if (Main.squirrelCageFrame[j] == 9)
					{
						Main.squirrelCageFrameCounter[j] = Main.squirrelCageFrameCounter[j] + 1;
						if (Main.squirrelCageFrameCounter[j] > Main.rand.Next(30, 900))
						{
							if (Main.rand.Next(3) != 0)
							{
								num = Main.rand.Next(7);
								if (num == 0)
								{
									Main.squirrelCageFrame[j] = 13;
								}
								else if (num > 2)
								{
									Main.squirrelCageFrame[j] = 10;
								}
								else
								{
									Main.squirrelCageFrame[j] = 11;
								}
							}
							Main.squirrelCageFrameCounter[j] = 0;
						}
					}
					else if (Main.squirrelCageFrame[j] == 10)
					{
						Main.squirrelCageFrameCounter[j] = Main.squirrelCageFrameCounter[j] + 1;
						if (Main.squirrelCageFrameCounter[j] >= 10)
						{
							Main.squirrelCageFrameCounter[j] = 0;
							Main.squirrelCageFrame[j] = 9;
						}
					}
					else if (Main.squirrelCageFrame[j] == 11 || Main.squirrelCageFrame[j] == 12)
					{
						Main.squirrelCageFrameCounter[j] = Main.squirrelCageFrameCounter[j] + 1;
						if (Main.squirrelCageFrameCounter[j] >= 5)
						{
							Main.squirrelCageFrame[j] = Main.squirrelCageFrame[j] + 1;
							if (Main.squirrelCageFrame[j] > 12)
							{
								if (Main.rand.Next(5) == 0)
								{
									Main.squirrelCageFrame[j] = 9;
								}
								else
								{
									Main.squirrelCageFrame[j] = 11;
								}
							}
							Main.squirrelCageFrameCounter[j] = 0;
						}
					}
					else if (Main.squirrelCageFrame[j] >= 13)
					{
						Main.squirrelCageFrameCounter[j] = Main.squirrelCageFrameCounter[j] + 1;
						if (Main.squirrelCageFrameCounter[j] >= 5)
						{
							Main.squirrelCageFrameCounter[j] = 0;
							Main.squirrelCageFrame[j] = Main.squirrelCageFrame[j] + 1;
						}
						if (Main.squirrelCageFrame[j] > 17)
						{
							Main.squirrelCageFrame[j] = 0;
						}
					}
				}
				for (int k = 0; k < Main.cageFrames; k++)
				{
					if (Main.squirrelCageFrameOrange[k] == 0)
					{
						Main.squirrelCageFrameCounterOrange[k] = Main.squirrelCageFrameCounterOrange[k] + 1;
						if (Main.squirrelCageFrameCounterOrange[k] > Main.rand.Next(30, 900))
						{
							if (Main.rand.Next(3) != 0)
							{
								num = Main.rand.Next(7);
								if (num == 0)
								{
									Main.squirrelCageFrameOrange[k] = 4;
								}
								else if (num > 2)
								{
									Main.squirrelCageFrameOrange[k] = 1;
								}
								else
								{
									Main.squirrelCageFrameOrange[k] = 2;
								}
							}
							Main.squirrelCageFrameCounterOrange[k] = 0;
						}
					}
					else if (Main.squirrelCageFrameOrange[k] == 1)
					{
						Main.squirrelCageFrameCounterOrange[k] = Main.squirrelCageFrameCounterOrange[k] + 1;
						if (Main.squirrelCageFrameCounterOrange[k] >= 10)
						{
							Main.squirrelCageFrameCounterOrange[k] = 0;
							Main.squirrelCageFrameOrange[k] = 0;
						}
					}
					else if (Main.squirrelCageFrameOrange[k] >= 2 && Main.squirrelCageFrameOrange[k] <= 3)
					{
						Main.squirrelCageFrameCounterOrange[k] = Main.squirrelCageFrameCounterOrange[k] + 1;
						if (Main.squirrelCageFrameCounterOrange[k] >= 5)
						{
							Main.squirrelCageFrameCounterOrange[k] = 0;
							Main.squirrelCageFrameOrange[k] = Main.squirrelCageFrameOrange[k] + 1;
						}
						if (Main.squirrelCageFrameOrange[k] > 3)
						{
							if (Main.rand.Next(5) != 0)
							{
								Main.squirrelCageFrameOrange[k] = 2;
							}
							else
							{
								Main.squirrelCageFrameOrange[k] = 0;
							}
						}
					}
					else if (Main.squirrelCageFrameOrange[k] >= 4 && Main.squirrelCageFrameOrange[k] <= 8)
					{
						Main.squirrelCageFrameCounterOrange[k] = Main.squirrelCageFrameCounterOrange[k] + 1;
						if (Main.squirrelCageFrameCounterOrange[k] >= 5)
						{
							Main.squirrelCageFrameCounterOrange[k] = 0;
							Main.squirrelCageFrameOrange[k] = Main.squirrelCageFrameOrange[k] + 1;
						}
					}
					else if (Main.squirrelCageFrameOrange[k] == 9)
					{
						Main.squirrelCageFrameCounterOrange[k] = Main.squirrelCageFrameCounterOrange[k] + 1;
						if (Main.squirrelCageFrameCounterOrange[k] > Main.rand.Next(30, 900))
						{
							if (Main.rand.Next(3) != 0)
							{
								num = Main.rand.Next(7);
								if (num == 0)
								{
									Main.squirrelCageFrameOrange[k] = 13;
								}
								else if (num > 2)
								{
									Main.squirrelCageFrameOrange[k] = 10;
								}
								else
								{
									Main.squirrelCageFrameOrange[k] = 11;
								}
							}
							Main.squirrelCageFrameCounterOrange[k] = 0;
						}
					}
					else if (Main.squirrelCageFrameOrange[k] == 10)
					{
						Main.squirrelCageFrameCounterOrange[k] = Main.squirrelCageFrameCounterOrange[k] + 1;
						if (Main.squirrelCageFrameCounterOrange[k] >= 10)
						{
							Main.squirrelCageFrameCounterOrange[k] = 0;
							Main.squirrelCageFrameOrange[k] = 9;
						}
					}
					else if (Main.squirrelCageFrameOrange[k] == 11 || Main.squirrelCageFrameOrange[k] == 12)
					{
						Main.squirrelCageFrameCounterOrange[k] = Main.squirrelCageFrameCounterOrange[k] + 1;
						if (Main.squirrelCageFrameCounterOrange[k] >= 5)
						{
							Main.squirrelCageFrameOrange[k] = Main.squirrelCageFrameOrange[k] + 1;
							if (Main.squirrelCageFrameOrange[k] > 12)
							{
								if (Main.rand.Next(5) == 0)
								{
									Main.squirrelCageFrameOrange[k] = 9;
								}
								else
								{
									Main.squirrelCageFrameOrange[k] = 11;
								}
							}
							Main.squirrelCageFrameCounterOrange[k] = 0;
						}
					}
					else if (Main.squirrelCageFrameOrange[k] >= 13)
					{
						Main.squirrelCageFrameCounterOrange[k] = Main.squirrelCageFrameCounterOrange[k] + 1;
						if (Main.squirrelCageFrameCounterOrange[k] >= 5)
						{
							Main.squirrelCageFrameCounterOrange[k] = 0;
							Main.squirrelCageFrameOrange[k] = Main.squirrelCageFrameOrange[k] + 1;
						}
						if (Main.squirrelCageFrameOrange[k] > 17)
						{
							Main.squirrelCageFrameOrange[k] = 0;
						}
					}
				}
				for (int l = 0; l < Main.cageFrames; l++)
				{
					if (Main.mallardCageFrame[l] == 0 || Main.mallardCageFrame[l] == 4)
					{
						Main.mallardCageFrameCounter[l] = Main.mallardCageFrameCounter[l] + 1;
						if (Main.mallardCageFrameCounter[l] > Main.rand.Next(45, 2700))
						{
							if (Main.mallardCageFrame[l] == 0 && Main.rand.Next(3) != 0 || Main.mallardCageFrame[l] == 4 && Main.rand.Next(5) == 0)
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.mallardCageFrame[l] = 5;
								}
								else if (Main.rand.Next(3) != 0)
								{
									Main.mallardCageFrame[l] = 1;
								}
								else if (Main.mallardCageFrame[l] != 4)
								{
									Main.mallardCageFrame[l] = 4;
								}
								else
								{
									Main.mallardCageFrame[l] = 0;
								}
							}
							Main.mallardCageFrameCounter[l] = 0;
						}
					}
					else if (Main.mallardCageFrame[l] >= 1 && Main.mallardCageFrame[l] <= 3)
					{
						Main.mallardCageFrameCounter[l] = Main.mallardCageFrameCounter[l] + 1;
						if (Main.mallardCageFrameCounter[l] >= 5)
						{
							Main.mallardCageFrameCounter[l] = 0;
							Main.mallardCageFrame[l] = Main.mallardCageFrame[l] + 1;
						}
						if (Main.mallardCageFrame[l] > 3)
						{
							if (Main.rand.Next(5) != 0)
							{
								Main.mallardCageFrame[l] = 1;
							}
							else
							{
								Main.mallardCageFrame[l] = 0;
							}
						}
					}
					else if (Main.mallardCageFrame[l] >= 5 && Main.mallardCageFrame[l] <= 11)
					{
						Main.mallardCageFrameCounter[l] = Main.mallardCageFrameCounter[l] + 1;
						if (Main.mallardCageFrameCounter[l] >= 5)
						{
							Main.mallardCageFrameCounter[l] = 0;
							Main.mallardCageFrame[l] = Main.mallardCageFrame[l] + 1;
						}
					}
					else if (Main.mallardCageFrame[l] == 12 || Main.mallardCageFrame[l] == 16)
					{
						Main.mallardCageFrameCounter[l] = Main.mallardCageFrameCounter[l] + 1;
						if (Main.mallardCageFrameCounter[l] > Main.rand.Next(45, 2700))
						{
							if (Main.mallardCageFrame[l] == 12 && Main.rand.Next(3) != 0 || Main.mallardCageFrame[l] == 16 && Main.rand.Next(5) == 0)
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.mallardCageFrame[l] = 17;
								}
								else if (Main.rand.Next(3) != 0)
								{
									Main.mallardCageFrame[l] = 13;
								}
								else if (Main.mallardCageFrame[l] != 16)
								{
									Main.mallardCageFrame[l] = 16;
								}
								else
								{
									Main.mallardCageFrame[l] = 12;
								}
							}
							Main.mallardCageFrameCounter[l] = 0;
						}
					}
					else if (Main.mallardCageFrame[l] >= 13 && Main.mallardCageFrame[l] <= 15)
					{
						Main.mallardCageFrameCounter[l] = Main.mallardCageFrameCounter[l] + 1;
						if (Main.mallardCageFrameCounter[l] >= 5)
						{
							Main.mallardCageFrame[l] = Main.mallardCageFrame[l] + 1;
							if (Main.mallardCageFrame[l] > 15)
							{
								if (Main.rand.Next(5) == 0)
								{
									Main.mallardCageFrame[l] = 13;
								}
								else
								{
									Main.mallardCageFrame[l] = 12;
								}
							}
							Main.mallardCageFrameCounter[l] = 0;
						}
					}
					else if (Main.mallardCageFrame[l] >= 17)
					{
						Main.mallardCageFrameCounter[l] = Main.mallardCageFrameCounter[l] + 1;
						if (Main.mallardCageFrameCounter[l] >= 5)
						{
							Main.mallardCageFrameCounter[l] = 0;
							Main.mallardCageFrame[l] = Main.mallardCageFrame[l] + 1;
						}
						if (Main.mallardCageFrame[l] > 23)
						{
							Main.mallardCageFrame[l] = 0;
						}
					}
				}
				for (int m = 0; m < Main.cageFrames; m++)
				{
					if (Main.duckCageFrame[m] == 0 || Main.duckCageFrame[m] == 4)
					{
						Main.duckCageFrameCounter[m] = Main.duckCageFrameCounter[m] + 1;
						if (Main.duckCageFrameCounter[m] > Main.rand.Next(45, 2700))
						{
							if (Main.duckCageFrame[m] == 0 && Main.rand.Next(3) != 0 || Main.duckCageFrame[m] == 4 && Main.rand.Next(5) == 0)
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.duckCageFrame[m] = 5;
								}
								else if (Main.rand.Next(3) != 0)
								{
									Main.duckCageFrame[m] = 1;
								}
								else if (Main.duckCageFrame[m] != 4)
								{
									Main.duckCageFrame[m] = 4;
								}
								else
								{
									Main.duckCageFrame[m] = 0;
								}
							}
							Main.duckCageFrameCounter[m] = 0;
						}
					}
					else if (Main.duckCageFrame[m] >= 1 && Main.duckCageFrame[m] <= 3)
					{
						Main.duckCageFrameCounter[m] = Main.duckCageFrameCounter[m] + 1;
						if (Main.duckCageFrameCounter[m] >= 5)
						{
							Main.duckCageFrameCounter[m] = 0;
							Main.duckCageFrame[m] = Main.duckCageFrame[m] + 1;
						}
						if (Main.duckCageFrame[m] > 3)
						{
							if (Main.rand.Next(5) != 0)
							{
								Main.duckCageFrame[m] = 1;
							}
							else
							{
								Main.duckCageFrame[m] = 0;
							}
						}
					}
					else if (Main.duckCageFrame[m] >= 5 && Main.duckCageFrame[m] <= 11)
					{
						Main.duckCageFrameCounter[m] = Main.duckCageFrameCounter[m] + 1;
						if (Main.duckCageFrameCounter[m] >= 5)
						{
							Main.duckCageFrameCounter[m] = 0;
							Main.duckCageFrame[m] = Main.duckCageFrame[m] + 1;
						}
					}
					else if (Main.duckCageFrame[m] == 12 || Main.duckCageFrame[m] == 16)
					{
						Main.duckCageFrameCounter[m] = Main.duckCageFrameCounter[m] + 1;
						if (Main.duckCageFrameCounter[m] > Main.rand.Next(45, 2700))
						{
							if (Main.duckCageFrame[m] == 12 && Main.rand.Next(3) != 0 || Main.duckCageFrame[m] == 16 && Main.rand.Next(5) == 0)
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.duckCageFrame[m] = 17;
								}
								else if (Main.rand.Next(3) != 0)
								{
									Main.duckCageFrame[m] = 13;
								}
								else if (Main.duckCageFrame[m] != 16)
								{
									Main.duckCageFrame[m] = 16;
								}
								else
								{
									Main.duckCageFrame[m] = 12;
								}
							}
							Main.duckCageFrameCounter[m] = 0;
						}
					}
					else if (Main.duckCageFrame[m] >= 13 && Main.duckCageFrame[m] <= 15)
					{
						Main.duckCageFrameCounter[m] = Main.duckCageFrameCounter[m] + 1;
						if (Main.duckCageFrameCounter[m] >= 5)
						{
							Main.duckCageFrame[m] = Main.duckCageFrame[m] + 1;
							if (Main.duckCageFrame[m] > 15)
							{
								if (Main.rand.Next(5) == 0)
								{
									Main.duckCageFrame[m] = 13;
								}
								else
								{
									Main.duckCageFrame[m] = 12;
								}
							}
							Main.duckCageFrameCounter[m] = 0;
						}
					}
					else if (Main.duckCageFrame[m] >= 17)
					{
						Main.duckCageFrameCounter[m] = Main.duckCageFrameCounter[m] + 1;
						if (Main.duckCageFrameCounter[m] >= 5)
						{
							Main.duckCageFrameCounter[m] = 0;
							Main.duckCageFrame[m] = Main.duckCageFrame[m] + 1;
						}
						if (Main.duckCageFrame[m] > 23)
						{
							Main.duckCageFrame[m] = 0;
						}
					}
				}
				for (int n = 0; n < Main.cageFrames; n++)
				{
					if (Main.birdCageFrame[n] == 0)
					{
						Main.birdCageFrameCounter[n] = Main.birdCageFrameCounter[n] + 1;
						if (Main.birdCageFrameCounter[n] > Main.rand.Next(30, 2700))
						{
							if (Main.rand.Next(3) != 0)
							{
								if (Main.rand.Next(3) == 0)
								{
									Main.birdCageFrame[n] = 1;
								}
								else
								{
									Main.birdCageFrame[n] = 2;
								}
							}
							Main.birdCageFrameCounter[n] = 0;
						}
					}
					else if (Main.birdCageFrame[n] == 1)
					{
						Main.birdCageFrameCounter[n] = Main.birdCageFrameCounter[n] + 1;
						if (Main.birdCageFrameCounter[n] > Main.rand.Next(900, 18000) && Main.rand.Next(3) == 0)
						{
							Main.birdCageFrameCounter[n] = 0;
							Main.birdCageFrame[n] = 0;
						}
					}
					else if (Main.birdCageFrame[n] >= 2 && Main.birdCageFrame[n] <= 5)
					{
						Main.birdCageFrameCounter[n] = Main.birdCageFrameCounter[n] + 1;
						if (Main.birdCageFrameCounter[n] >= 5)
						{
							Main.birdCageFrameCounter[n] = 0;
							if (Main.birdCageFrame[n] != 3 || Main.rand.Next(3) != 0)
							{
								Main.birdCageFrame[n] = Main.birdCageFrame[n] + 1;
							}
							else
							{
								Main.birdCageFrame[n] = 13;
							}
						}
					}
					else if (Main.birdCageFrame[n] == 6)
					{
						Main.birdCageFrameCounter[n] = Main.birdCageFrameCounter[n] + 1;
						if (Main.birdCageFrameCounter[n] > Main.rand.Next(45, 2700))
						{
							if (Main.rand.Next(3) != 0)
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.birdCageFrame[n] = 7;
								}
								else if (Main.rand.Next(6) == 0)
								{
									Main.birdCageFrame[n] = 11;
								}
							}
							Main.birdCageFrameCounter[n] = 0;
						}
					}
					else if (Main.birdCageFrame[n] >= 7 && Main.birdCageFrame[n] <= 10)
					{
						Main.birdCageFrameCounter[n] = Main.birdCageFrameCounter[n] + 1;
						if (Main.birdCageFrameCounter[n] >= 5)
						{
							Main.birdCageFrame[n] = Main.birdCageFrame[n] + 1;
							if (Main.birdCageFrame[n] > 10)
							{
								Main.birdCageFrame[n] = 0;
							}
							Main.birdCageFrameCounter[n] = 0;
						}
					}
					else if (Main.birdCageFrame[n] >= 11 && Main.birdCageFrame[n] <= 13)
					{
						Main.birdCageFrameCounter[n] = Main.birdCageFrameCounter[n] + 1;
						if (Main.birdCageFrameCounter[n] >= 5)
						{
							Main.birdCageFrame[n] = Main.birdCageFrame[n] + 1;
							Main.birdCageFrameCounter[n] = 0;
						}
					}
					else if (Main.birdCageFrame[n] == 14)
					{
						Main.birdCageFrameCounter[n] = Main.birdCageFrameCounter[n] + 1;
						if (Main.birdCageFrameCounter[n] > Main.rand.Next(5, 600))
						{
							if (Main.rand.Next(20) == 0)
							{
								Main.birdCageFrame[n] = 16;
							}
							else if (Main.rand.Next(20) != 0)
							{
								Main.birdCageFrame[n] = 15;
							}
							else
							{
								Main.birdCageFrame[n] = 4;
							}
							Main.birdCageFrameCounter[n] = 0;
						}
					}
					else if (Main.birdCageFrame[n] == 15)
					{
						Main.birdCageFrameCounter[n] = Main.birdCageFrameCounter[n] + 1;
						if (Main.birdCageFrameCounter[n] >= 10)
						{
							Main.birdCageFrameCounter[n] = 0;
							Main.birdCageFrame[n] = 14;
						}
					}
					else if (Main.birdCageFrame[n] >= 16 && Main.birdCageFrame[n] <= 18)
					{
						Main.birdCageFrameCounter[n] = Main.birdCageFrameCounter[n] + 1;
						if (Main.birdCageFrameCounter[n] >= 5)
						{
							Main.birdCageFrame[n] = Main.birdCageFrame[n] + 1;
							if (Main.birdCageFrame[n] > 18)
							{
								Main.birdCageFrame[n] = 0;
							}
							Main.birdCageFrameCounter[n] = 0;
						}
					}
				}
				for (int o = 0; o < Main.cageFrames; o++)
				{
					if (Main.blueBirdCageFrame[o] == 0)
					{
						Main.blueBirdCageFrameCounter[o] = Main.blueBirdCageFrameCounter[o] + 1;
						if (Main.blueBirdCageFrameCounter[o] > Main.rand.Next(30, 2700))
						{
							if (Main.rand.Next(3) != 0)
							{
								if (Main.rand.Next(3) == 0)
								{
									Main.blueBirdCageFrame[o] = 1;
								}
								else
								{
									Main.blueBirdCageFrame[o] = 2;
								}
							}
							Main.blueBirdCageFrameCounter[o] = 0;
						}
					}
					else if (Main.blueBirdCageFrame[o] == 1)
					{
						Main.blueBirdCageFrameCounter[o] = Main.blueBirdCageFrameCounter[o] + 1;
						if (Main.blueBirdCageFrameCounter[o] > Main.rand.Next(900, 18000) && Main.rand.Next(3) == 0)
						{
							Main.blueBirdCageFrameCounter[o] = 0;
							Main.blueBirdCageFrame[o] = 0;
						}
					}
					else if (Main.blueBirdCageFrame[o] >= 2 && Main.blueBirdCageFrame[o] <= 5)
					{
						Main.blueBirdCageFrameCounter[o] = Main.blueBirdCageFrameCounter[o] + 1;
						if (Main.blueBirdCageFrameCounter[o] >= 5)
						{
							Main.blueBirdCageFrameCounter[o] = 0;
							if (Main.blueBirdCageFrame[o] != 3 || Main.rand.Next(3) != 0)
							{
								Main.blueBirdCageFrame[o] = Main.blueBirdCageFrame[o] + 1;
							}
							else
							{
								Main.blueBirdCageFrame[o] = 13;
							}
						}
					}
					else if (Main.blueBirdCageFrame[o] == 6)
					{
						Main.blueBirdCageFrameCounter[o] = Main.blueBirdCageFrameCounter[o] + 1;
						if (Main.blueBirdCageFrameCounter[o] > Main.rand.Next(45, 2700))
						{
							if (Main.rand.Next(3) != 0)
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.blueBirdCageFrame[o] = 7;
								}
								else if (Main.rand.Next(6) == 0)
								{
									Main.blueBirdCageFrame[o] = 11;
								}
							}
							Main.blueBirdCageFrameCounter[o] = 0;
						}
					}
					else if (Main.blueBirdCageFrame[o] >= 7 && Main.blueBirdCageFrame[o] <= 10)
					{
						Main.blueBirdCageFrameCounter[o] = Main.blueBirdCageFrameCounter[o] + 1;
						if (Main.blueBirdCageFrameCounter[o] >= 5)
						{
							Main.blueBirdCageFrame[o] = Main.blueBirdCageFrame[o] + 1;
							if (Main.blueBirdCageFrame[o] > 10)
							{
								Main.blueBirdCageFrame[o] = 0;
							}
							Main.blueBirdCageFrameCounter[o] = 0;
						}
					}
					else if (Main.blueBirdCageFrame[o] >= 11 && Main.blueBirdCageFrame[o] <= 13)
					{
						Main.blueBirdCageFrameCounter[o] = Main.blueBirdCageFrameCounter[o] + 1;
						if (Main.blueBirdCageFrameCounter[o] >= 5)
						{
							Main.blueBirdCageFrame[o] = Main.blueBirdCageFrame[o] + 1;
							Main.blueBirdCageFrameCounter[o] = 0;
						}
					}
					else if (Main.blueBirdCageFrame[o] == 14)
					{
						Main.blueBirdCageFrameCounter[o] = Main.blueBirdCageFrameCounter[o] + 1;
						if (Main.blueBirdCageFrameCounter[o] > Main.rand.Next(5, 600))
						{
							if (Main.rand.Next(20) == 0)
							{
								Main.blueBirdCageFrame[o] = 16;
							}
							else if (Main.rand.Next(20) != 0)
							{
								Main.blueBirdCageFrame[o] = 15;
							}
							else
							{
								Main.blueBirdCageFrame[o] = 4;
							}
							Main.blueBirdCageFrameCounter[o] = 0;
						}
					}
					else if (Main.blueBirdCageFrame[o] == 15)
					{
						Main.blueBirdCageFrameCounter[o] = Main.blueBirdCageFrameCounter[o] + 1;
						if (Main.blueBirdCageFrameCounter[o] >= 10)
						{
							Main.blueBirdCageFrameCounter[o] = 0;
							Main.blueBirdCageFrame[o] = 14;
						}
					}
					else if (Main.blueBirdCageFrame[o] >= 16 && Main.blueBirdCageFrame[o] <= 18)
					{
						Main.blueBirdCageFrameCounter[o] = Main.blueBirdCageFrameCounter[o] + 1;
						if (Main.blueBirdCageFrameCounter[o] >= 5)
						{
							Main.blueBirdCageFrame[o] = Main.blueBirdCageFrame[o] + 1;
							if (Main.blueBirdCageFrame[o] > 18)
							{
								Main.blueBirdCageFrame[o] = 0;
							}
							Main.blueBirdCageFrameCounter[o] = 0;
						}
					}
				}
				for (int p = 0; p < Main.cageFrames; p++)
				{
					if (Main.redBirdCageFrame[p] == 0)
					{
						Main.redBirdCageFrameCounter[p] = Main.redBirdCageFrameCounter[p] + 1;
						if (Main.redBirdCageFrameCounter[p] > Main.rand.Next(30, 2700))
						{
							if (Main.rand.Next(3) != 0)
							{
								if (Main.rand.Next(3) == 0)
								{
									Main.redBirdCageFrame[p] = 1;
								}
								else
								{
									Main.redBirdCageFrame[p] = 2;
								}
							}
							Main.redBirdCageFrameCounter[p] = 0;
						}
					}
					else if (Main.redBirdCageFrame[p] == 1)
					{
						Main.redBirdCageFrameCounter[p] = Main.redBirdCageFrameCounter[p] + 1;
						if (Main.redBirdCageFrameCounter[p] > Main.rand.Next(900, 18000) && Main.rand.Next(3) == 0)
						{
							Main.redBirdCageFrameCounter[p] = 0;
							Main.redBirdCageFrame[p] = 0;
						}
					}
					else if (Main.redBirdCageFrame[p] >= 2 && Main.redBirdCageFrame[p] <= 5)
					{
						Main.redBirdCageFrameCounter[p] = Main.redBirdCageFrameCounter[p] + 1;
						if (Main.redBirdCageFrameCounter[p] >= 5)
						{
							Main.redBirdCageFrameCounter[p] = 0;
							if (Main.redBirdCageFrame[p] != 3 || Main.rand.Next(3) != 0)
							{
								Main.redBirdCageFrame[p] = Main.redBirdCageFrame[p] + 1;
							}
							else
							{
								Main.redBirdCageFrame[p] = 13;
							}
						}
					}
					else if (Main.redBirdCageFrame[p] == 6)
					{
						Main.redBirdCageFrameCounter[p] = Main.redBirdCageFrameCounter[p] + 1;
						if (Main.redBirdCageFrameCounter[p] > Main.rand.Next(45, 2700))
						{
							if (Main.rand.Next(3) != 0)
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.redBirdCageFrame[p] = 7;
								}
								else if (Main.rand.Next(6) == 0)
								{
									Main.redBirdCageFrame[p] = 11;
								}
							}
							Main.redBirdCageFrameCounter[p] = 0;
						}
					}
					else if (Main.redBirdCageFrame[p] >= 7 && Main.redBirdCageFrame[p] <= 10)
					{
						Main.redBirdCageFrameCounter[p] = Main.redBirdCageFrameCounter[p] + 1;
						if (Main.redBirdCageFrameCounter[p] >= 5)
						{
							Main.redBirdCageFrame[p] = Main.redBirdCageFrame[p] + 1;
							if (Main.redBirdCageFrame[p] > 10)
							{
								Main.redBirdCageFrame[p] = 0;
							}
							Main.redBirdCageFrameCounter[p] = 0;
						}
					}
					else if (Main.redBirdCageFrame[p] >= 11 && Main.redBirdCageFrame[p] <= 13)
					{
						Main.redBirdCageFrameCounter[p] = Main.redBirdCageFrameCounter[p] + 1;
						if (Main.redBirdCageFrameCounter[p] >= 5)
						{
							Main.redBirdCageFrame[p] = Main.redBirdCageFrame[p] + 1;
							Main.redBirdCageFrameCounter[p] = 0;
						}
					}
					else if (Main.redBirdCageFrame[p] == 14)
					{
						Main.redBirdCageFrameCounter[p] = Main.redBirdCageFrameCounter[p] + 1;
						if (Main.redBirdCageFrameCounter[p] > Main.rand.Next(5, 600))
						{
							if (Main.rand.Next(20) == 0)
							{
								Main.redBirdCageFrame[p] = 16;
							}
							else if (Main.rand.Next(20) != 0)
							{
								Main.redBirdCageFrame[p] = 15;
							}
							else
							{
								Main.redBirdCageFrame[p] = 4;
							}
							Main.redBirdCageFrameCounter[p] = 0;
						}
					}
					else if (Main.redBirdCageFrame[p] == 15)
					{
						Main.redBirdCageFrameCounter[p] = Main.redBirdCageFrameCounter[p] + 1;
						if (Main.redBirdCageFrameCounter[p] >= 10)
						{
							Main.redBirdCageFrameCounter[p] = 0;
							Main.redBirdCageFrame[p] = 14;
						}
					}
					else if (Main.redBirdCageFrame[p] >= 16 && Main.redBirdCageFrame[p] <= 18)
					{
						Main.redBirdCageFrameCounter[p] = Main.redBirdCageFrameCounter[p] + 1;
						if (Main.redBirdCageFrameCounter[p] >= 5)
						{
							Main.redBirdCageFrame[p] = Main.redBirdCageFrame[p] + 1;
							if (Main.redBirdCageFrame[p] > 18)
							{
								Main.redBirdCageFrame[p] = 0;
							}
							Main.redBirdCageFrameCounter[p] = 0;
						}
					}
				}
				for (int q = 0; q < 2; q++)
				{
					for (int r = 0; r < Main.cageFrames; r++)
					{
						if (Main.scorpionCageFrame[q, r] == 0 || Main.scorpionCageFrame[q, r] == 7)
						{
							Main.scorpionCageFrameCounter[q, r] = Main.scorpionCageFrameCounter[q, r] + 1;
							if (Main.scorpionCageFrameCounter[q, r] > Main.rand.Next(30, 3600))
							{
								if (Main.scorpionCageFrame[q, r] == 7)
								{
									Main.scorpionCageFrame[q, r] = 0;
								}
								else if (Main.rand.Next(3) == 0)
								{
									if (Main.rand.Next(7) == 0)
									{
										Main.scorpionCageFrame[q, r] = 1;
									}
									else if (Main.rand.Next(4) == 0)
									{
										Main.scorpionCageFrame[q, r] = 8;
									}
									else if (Main.rand.Next(3) != 0)
									{
										Main.scorpionCageFrame[q, r] = 14;
									}
									else
									{
										Main.scorpionCageFrame[q, r] = 7;
									}
								}
								Main.scorpionCageFrameCounter[q, r] = 0;
							}
						}
						else if (Main.scorpionCageFrame[q, r] >= 1 && Main.scorpionCageFrame[q, r] <= 2)
						{
							Main.scorpionCageFrameCounter[q, r] = Main.scorpionCageFrameCounter[q, r] + 1;
							if (Main.scorpionCageFrameCounter[q, r] >= 10)
							{
								Main.scorpionCageFrameCounter[q, r] = 0;
								Main.scorpionCageFrame[q, r] = Main.scorpionCageFrame[q, r] + 1;
							}
						}
						else if (Main.scorpionCageFrame[q, r] >= 8 && Main.scorpionCageFrame[q, r] <= 10)
						{
							Main.scorpionCageFrameCounter[q, r] = Main.scorpionCageFrameCounter[q, r] + 1;
							if (Main.scorpionCageFrameCounter[q, r] >= 10)
							{
								Main.scorpionCageFrameCounter[q, r] = 0;
								Main.scorpionCageFrame[q, r] = Main.scorpionCageFrame[q, r] + 1;
							}
						}
						else if (Main.scorpionCageFrame[q, r] == 11)
						{
							Main.scorpionCageFrameCounter[q, r] = Main.scorpionCageFrameCounter[q, r] + 1;
							if (Main.scorpionCageFrameCounter[q, r] > Main.rand.Next(45, 5400))
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.scorpionCageFrame[q, r] = 12;
								}
								Main.scorpionCageFrameCounter[q, r] = 0;
							}
						}
						else if (Main.scorpionCageFrame[q, r] >= 12 && Main.scorpionCageFrame[q, r] <= 13)
						{
							Main.scorpionCageFrameCounter[q, r] = Main.scorpionCageFrameCounter[q, r] + 1;
							if (Main.scorpionCageFrameCounter[q, r] >= 10)
							{
								Main.scorpionCageFrameCounter[q, r] = 0;
								Main.scorpionCageFrame[q, r] = Main.scorpionCageFrame[q, r] + 1;
								if (Main.scorpionCageFrame[q, r] > 13)
								{
									Main.scorpionCageFrame[q, r] = 0;
								}
							}
						}
						else if (Main.scorpionCageFrame[q, r] >= 14 && Main.scorpionCageFrame[q, r] <= 15)
						{
							Main.scorpionCageFrameCounter[q, r] = Main.scorpionCageFrameCounter[q, r] + 1;
							if (Main.scorpionCageFrameCounter[q, r] >= 5)
							{
								Main.scorpionCageFrameCounter[q, r] = 0;
								Main.scorpionCageFrame[q, r] = Main.scorpionCageFrame[q, r] + 1;
								if (Main.scorpionCageFrame[q, r] > 15)
								{
									Main.scorpionCageFrame[q, r] = 14;
								}
								if (Main.rand.Next(5) == 0)
								{
									Main.scorpionCageFrame[q, r] = 0;
								}
							}
						}
						else if (Main.scorpionCageFrame[q, r] == 4 || Main.scorpionCageFrame[q, r] == 3)
						{
							Main.scorpionCageFrameCounter[q, r] = Main.scorpionCageFrameCounter[q, r] + 1;
							if (Main.scorpionCageFrameCounter[q, r] > Main.rand.Next(30, 3600))
							{
								if (Main.scorpionCageFrame[q, r] == 3)
								{
									Main.scorpionCageFrame[q, r] = 4;
								}
								else if (Main.rand.Next(3) == 0)
								{
									if (Main.rand.Next(5) == 0)
									{
										Main.scorpionCageFrame[q, r] = 5;
									}
									else if (Main.rand.Next(3) != 0)
									{
										Main.scorpionCageFrame[q, r] = 16;
									}
									else
									{
										Main.scorpionCageFrame[q, r] = 3;
									}
								}
								Main.scorpionCageFrameCounter[q, r] = 0;
							}
						}
						else if (Main.scorpionCageFrame[q, r] >= 5 && Main.scorpionCageFrame[q, r] <= 6)
						{
							Main.scorpionCageFrameCounter[q, r] = Main.scorpionCageFrameCounter[q, r] + 1;
							if (Main.scorpionCageFrameCounter[q, r] >= 10)
							{
								Main.scorpionCageFrameCounter[q, r] = 0;
								Main.scorpionCageFrame[q, r] = Main.scorpionCageFrame[q, r] + 1;
								if (Main.scorpionCageFrame[q, r] > 7)
								{
									Main.scorpionCageFrame[q, r] = 0;
								}
							}
						}
						else if (Main.scorpionCageFrame[q, r] >= 16 && Main.scorpionCageFrame[q, r] <= 17)
						{
							Main.scorpionCageFrameCounter[q, r] = Main.scorpionCageFrameCounter[q, r] + 1;
							if (Main.scorpionCageFrameCounter[q, r] >= 5)
							{
								Main.scorpionCageFrameCounter[q, r] = 0;
								Main.scorpionCageFrame[q, r] = Main.scorpionCageFrame[q, r] + 1;
								if (Main.scorpionCageFrame[q, r] > 17)
								{
									Main.scorpionCageFrame[q, r] = 16;
								}
								if (Main.rand.Next(5) == 0)
								{
									Main.scorpionCageFrame[q, r] = 4;
								}
							}
						}
					}
				}
				for (int s = 0; s < Main.cageFrames; s++)
				{
					if (Main.penguinCageFrame[s] == 0)
					{
						Main.penguinCageFrameCounter[s] = Main.penguinCageFrameCounter[s] + 1;
						if (Main.penguinCageFrameCounter[s] > Main.rand.Next(30, 1800))
						{
							if (Main.rand.Next(2) == 0)
							{
								if (Main.rand.Next(10) == 0)
								{
									Main.penguinCageFrame[s] = 4;
								}
								else if (Main.rand.Next(7) == 0)
								{
									Main.penguinCageFrame[s] = 15;
								}
								else if (Main.rand.Next(3) != 0)
								{
									Main.penguinCageFrame[s] = 1;
								}
								else
								{
									Main.penguinCageFrame[s] = 2;
								}
							}
							Main.penguinCageFrameCounter[s] = 0;
						}
					}
					else if (Main.penguinCageFrame[s] == 1)
					{
						Main.penguinCageFrameCounter[s] = Main.penguinCageFrameCounter[s] + 1;
						if (Main.penguinCageFrameCounter[s] >= 10)
						{
							Main.penguinCageFrameCounter[s] = 0;
							Main.penguinCageFrame[s] = 0;
						}
					}
					else if (Main.penguinCageFrame[s] >= 2 && Main.penguinCageFrame[s] <= 3)
					{
						Main.penguinCageFrameCounter[s] = Main.penguinCageFrameCounter[s] + 1;
						if (Main.penguinCageFrameCounter[s] >= 5)
						{
							Main.penguinCageFrameCounter[s] = 0;
							Main.penguinCageFrame[s] = Main.penguinCageFrame[s] + 1;
							if (Main.penguinCageFrame[s] > 3)
							{
								if (Main.rand.Next(3) != 0)
								{
									Main.penguinCageFrame[s] = 2;
								}
								else
								{
									Main.penguinCageFrame[s] = 0;
								}
							}
						}
					}
					else if (Main.penguinCageFrame[s] >= 4 && Main.penguinCageFrame[s] <= 6)
					{
						Main.penguinCageFrameCounter[s] = Main.penguinCageFrameCounter[s] + 1;
						if (Main.penguinCageFrameCounter[s] >= 10)
						{
							Main.penguinCageFrameCounter[s] = 0;
							Main.penguinCageFrame[s] = Main.penguinCageFrame[s] + 1;
						}
					}
					else if (Main.penguinCageFrame[s] == 15)
					{
						Main.penguinCageFrameCounter[s] = Main.penguinCageFrameCounter[s] + 1;
						if (Main.penguinCageFrameCounter[s] > Main.rand.Next(10, 1800))
						{
							if (Main.rand.Next(2) == 0)
							{
								Main.penguinCageFrame[s] = 0;
							}
							Main.penguinCageFrameCounter[s] = 0;
						}
					}
					else if (Main.penguinCageFrame[s] == 8)
					{
						Main.penguinCageFrameCounter[s] = Main.penguinCageFrameCounter[s] + 1;
						if (Main.penguinCageFrameCounter[s] > Main.rand.Next(30, 3600))
						{
							if (Main.rand.Next(2) == 0)
							{
								if (Main.rand.Next(10) == 0)
								{
									Main.penguinCageFrame[s] = 12;
								}
								else if (Main.rand.Next(7) == 0)
								{
									Main.penguinCageFrame[s] = 7;
								}
								else if (Main.rand.Next(3) != 0)
								{
									Main.penguinCageFrame[s] = 9;
								}
								else
								{
									Main.penguinCageFrame[s] = 10;
								}
							}
							Main.penguinCageFrameCounter[s] = 0;
						}
					}
					else if (Main.penguinCageFrame[s] == 9)
					{
						Main.penguinCageFrameCounter[s] = Main.penguinCageFrameCounter[s] + 1;
						if (Main.penguinCageFrameCounter[s] >= 10)
						{
							Main.penguinCageFrameCounter[s] = 0;
							Main.penguinCageFrame[s] = 8;
						}
					}
					else if (Main.penguinCageFrame[s] >= 10 && Main.penguinCageFrame[s] <= 11)
					{
						Main.penguinCageFrameCounter[s] = Main.penguinCageFrameCounter[s] + 1;
						if (Main.penguinCageFrameCounter[s] >= 5)
						{
							Main.penguinCageFrameCounter[s] = 0;
							Main.penguinCageFrame[s] = Main.penguinCageFrame[s] + 1;
							if (Main.penguinCageFrame[s] > 3)
							{
								if (Main.rand.Next(3) != 0)
								{
									Main.penguinCageFrame[s] = 10;
								}
								else
								{
									Main.penguinCageFrame[s] = 8;
								}
							}
						}
					}
					else if (Main.penguinCageFrame[s] >= 12 && Main.penguinCageFrame[s] <= 14)
					{
						Main.penguinCageFrameCounter[s] = Main.penguinCageFrameCounter[s] + 1;
						if (Main.penguinCageFrameCounter[s] >= 10)
						{
							Main.penguinCageFrameCounter[s] = 0;
							Main.penguinCageFrame[s] = Main.penguinCageFrame[s] + 1;
						}
					}
					else if (Main.penguinCageFrame[s] == 7)
					{
						Main.penguinCageFrameCounter[s] = Main.penguinCageFrameCounter[s] + 1;
						if (Main.penguinCageFrameCounter[s] > Main.rand.Next(10, 3600))
						{
							if (Main.rand.Next(2) == 0)
							{
								Main.penguinCageFrame[s] = 8;
							}
							Main.penguinCageFrameCounter[s] = 0;
						}
					}
				}
				for (int t = 0; t < Main.cageFrames; t++)
				{
					if (Main.snailCageFrame[t] >= 0 && Main.snailCageFrame[t] <= 13)
					{
						Main.snailCageFrameCounter[t] = Main.snailCageFrameCounter[t] + 1;
						if (Main.snailCageFrameCounter[t] > Main.rand.Next(45, 3600))
						{
							if (Main.snailCageFrame[t] == 8 && Main.rand.Next(2) == 0)
							{
								Main.snailCageFrame[t] = 14;
							}
							else if (Main.snailCageFrame[t] == 1 && Main.rand.Next(3) == 0)
							{
								Main.snailCageFrame[t] = 19;
							}
							else if (Main.snailCageFrame[t] != 1 || Main.rand.Next(3) != 0)
							{
								Main.snailCageFrame[t] = Main.snailCageFrame[t] + 1;
								if (Main.snailCageFrame[t] > 13)
								{
									Main.snailCageFrame[t] = 0;
								}
							}
							else
							{
								Main.snailCageFrame[t] = 20;
							}
							Main.snailCageFrameCounter[t] = 0;
						}
					}
					else if (Main.snailCageFrame[t] >= 14 && Main.snailCageFrame[t] <= 18)
					{
						Main.snailCageFrameCounter[t] = Main.snailCageFrameCounter[t] + 1;
						if (Main.snailCageFrameCounter[t] >= 5)
						{
							Main.snailCageFrameCounter[t] = 0;
							Main.snailCageFrame[t] = Main.snailCageFrame[t] + 1;
						}
						if (Main.snailCageFrame[t] > 18)
						{
							Main.snailCageFrame[t] = 20;
						}
					}
					else if (Main.snailCageFrame[t] == 19 || Main.snailCageFrame[t] == 20)
					{
						Main.snailCageFrameCounter[t] = Main.snailCageFrameCounter[t] + 1;
						if (Main.snailCageFrameCounter[t] > Main.rand.Next(60, 7200))
						{
							Main.snailCageFrameCounter[t] = 0;
							if (Main.rand.Next(4) == 0)
							{
								if (Main.rand.Next(3) == 0)
								{
									Main.snailCageFrame[t] = 2;
								}
								else if (Main.snailCageFrame[t] != 19)
								{
									Main.snailCageFrame[t] = 19;
								}
								else
								{
									Main.snailCageFrame[t] = 20;
								}
							}
						}
					}
				}
				for (int u = 0; u < Main.cageFrames; u++)
				{
					if (Main.snail2CageFrame[u] >= 0 && Main.snail2CageFrame[u] <= 13)
					{
						Main.snail2CageFrameCounter[u] = Main.snail2CageFrameCounter[u] + 1;
						if (Main.snail2CageFrameCounter[u] > Main.rand.Next(30, 2700))
						{
							if (Main.snail2CageFrame[u] == 8 && Main.rand.Next(2) == 0)
							{
								Main.snail2CageFrame[u] = 14;
							}
							else if (Main.snail2CageFrame[u] == 1 && Main.rand.Next(3) == 0)
							{
								Main.snail2CageFrame[u] = 19;
							}
							else if (Main.snail2CageFrame[u] != 1 || Main.rand.Next(3) != 0)
							{
								Main.snail2CageFrame[u] = Main.snail2CageFrame[u] + 1;
								if (Main.snail2CageFrame[u] > 13)
								{
									Main.snail2CageFrame[u] = 0;
								}
							}
							else
							{
								Main.snail2CageFrame[u] = 20;
							}
							Main.snail2CageFrameCounter[u] = 0;
						}
					}
					else if (Main.snail2CageFrame[u] >= 14 && Main.snail2CageFrame[u] <= 18)
					{
						Main.snail2CageFrameCounter[u] = Main.snail2CageFrameCounter[u] + 1;
						if (Main.snail2CageFrameCounter[u] >= 5)
						{
							Main.snail2CageFrameCounter[u] = 0;
							Main.snail2CageFrame[u] = Main.snail2CageFrame[u] + 1;
						}
						if (Main.snail2CageFrame[u] > 18)
						{
							Main.snail2CageFrame[u] = 20;
						}
					}
					else if (Main.snail2CageFrame[u] == 19 || Main.snail2CageFrame[u] == 20)
					{
						Main.snail2CageFrameCounter[u] = Main.snail2CageFrameCounter[u] + 1;
						if (Main.snail2CageFrameCounter[u] > Main.rand.Next(45, 5400))
						{
							Main.snail2CageFrameCounter[u] = 0;
							if (Main.rand.Next(4) == 0)
							{
								if (Main.rand.Next(3) == 0)
								{
									Main.snail2CageFrame[u] = 2;
								}
								else if (Main.snail2CageFrame[u] != 19)
								{
									Main.snail2CageFrame[u] = 19;
								}
								else
								{
									Main.snail2CageFrame[u] = 20;
								}
							}
						}
					}
				}
				for (int v = 0; v < Main.cageFrames; v++)
				{
					if (Main.frogCageFrame[v] == 0)
					{
						Main.frogCageFrameCounter[v] = Main.frogCageFrameCounter[v] + 1;
						if (Main.frogCageFrameCounter[v] > Main.rand.Next(45, 3600))
						{
							if (Main.rand.Next(10) != 0)
							{
								Main.frogCageFrame[v] = 12;
							}
							else
							{
								Main.frogCageFrame[v] = 1;
							}
							Main.frogCageFrameCounter[v] = 0;
						}
					}
					else if (Main.frogCageFrame[v] >= 1 && Main.frogCageFrame[v] <= 5)
					{
						Main.frogCageFrameCounter[v] = Main.frogCageFrameCounter[v] + 1;
						if (Main.frogCageFrameCounter[v] >= 5)
						{
							Main.frogCageFrame[v] = Main.frogCageFrame[v] + 1;
							Main.frogCageFrameCounter[v] = 0;
						}
					}
					else if (Main.frogCageFrame[v] >= 12 && Main.frogCageFrame[v] <= 17)
					{
						Main.frogCageFrameCounter[v] = Main.frogCageFrameCounter[v] + 1;
						if (Main.frogCageFrameCounter[v] >= 5)
						{
							Main.frogCageFrameCounter[v] = 0;
							Main.frogCageFrame[v] = Main.frogCageFrame[v] + 1;
						}
						if (Main.frogCageFrame[v] > 17)
						{
							if (Main.rand.Next(3) != 0)
							{
								Main.frogCageFrame[v] = 12;
							}
							else
							{
								Main.frogCageFrame[v] = 0;
							}
						}
					}
					else if (Main.frogCageFrame[v] == 6)
					{
						Main.frogCageFrameCounter[v] = Main.frogCageFrameCounter[v] + 1;
						if (Main.frogCageFrameCounter[v] > Main.rand.Next(45, 3600))
						{
							if (Main.rand.Next(10) != 0)
							{
								Main.frogCageFrame[v] = 18;
							}
							else
							{
								Main.frogCageFrame[v] = 7;
							}
							Main.frogCageFrameCounter[v] = 0;
						}
					}
					else if (Main.frogCageFrame[v] >= 7 && Main.frogCageFrame[v] <= 11)
					{
						Main.frogCageFrameCounter[v] = Main.frogCageFrameCounter[v] + 1;
						if (Main.frogCageFrameCounter[v] >= 5)
						{
							Main.frogCageFrame[v] = Main.frogCageFrame[v] + 1;
							Main.frogCageFrameCounter[v] = 0;
							if (Main.frogCageFrame[v] > 11)
							{
								Main.frogCageFrame[v] = 0;
							}
						}
					}
					else if (Main.frogCageFrame[v] >= 18 && Main.frogCageFrame[v] <= 23)
					{
						Main.frogCageFrameCounter[v] = Main.frogCageFrameCounter[v] + 1;
						if (Main.frogCageFrameCounter[v] >= 5)
						{
							Main.frogCageFrameCounter[v] = 0;
							Main.frogCageFrame[v] = Main.frogCageFrame[v] + 1;
						}
						if (Main.frogCageFrame[v] > 17)
						{
							if (Main.rand.Next(3) != 0)
							{
								Main.frogCageFrame[v] = 18;
							}
							else
							{
								Main.frogCageFrame[v] = 6;
							}
						}
					}
				}
				for (int w = 0; w < Main.cageFrames; w++)
				{
					if (Main.mouseCageFrame[w] >= 0 && Main.mouseCageFrame[w] <= 1)
					{
						Main.mouseCageFrameCounter[w] = Main.mouseCageFrameCounter[w] + 1;
						if (Main.mouseCageFrameCounter[w] >= 5)
						{
							Main.mouseCageFrame[w] = Main.mouseCageFrame[w] + 1;
							if (Main.mouseCageFrame[w] > 1)
							{
								Main.mouseCageFrame[w] = 0;
							}
							Main.mouseCageFrameCounter[w] = 0;
							if (Main.rand.Next(15) == 0)
							{
								Main.mouseCageFrame[w] = 4;
							}
						}
					}
					else if (Main.mouseCageFrame[w] >= 4 && Main.mouseCageFrame[w] <= 7)
					{
						Main.mouseCageFrameCounter[w] = Main.mouseCageFrameCounter[w] + 1;
						if (Main.mouseCageFrameCounter[w] >= 5)
						{
							Main.mouseCageFrameCounter[w] = 0;
							Main.mouseCageFrame[w] = Main.mouseCageFrame[w] + 1;
						}
						if (Main.mouseCageFrame[w] > 7)
						{
							Main.mouseCageFrame[w] = 2;
						}
					}
					else if (Main.mouseCageFrame[w] >= 2 && Main.mouseCageFrame[w] <= 3)
					{
						Main.mouseCageFrameCounter[w] = Main.mouseCageFrameCounter[w] + 1;
						if (Main.mouseCageFrameCounter[w] >= 5)
						{
							Main.mouseCageFrame[w] = Main.mouseCageFrame[w] + 1;
							if (Main.mouseCageFrame[w] > 3)
							{
								Main.mouseCageFrame[w] = 2;
							}
							Main.mouseCageFrameCounter[w] = 0;
							if (Main.rand.Next(15) == 0)
							{
								Main.mouseCageFrame[w] = 8;
							}
							else if (Main.rand.Next(15) == 0)
							{
								Main.mouseCageFrame[w] = 12;
							}
						}
					}
					else if (Main.mouseCageFrame[w] >= 8 && Main.mouseCageFrame[w] <= 11)
					{
						Main.mouseCageFrameCounter[w] = Main.mouseCageFrameCounter[w] + 1;
						if (Main.mouseCageFrameCounter[w] >= 5)
						{
							Main.mouseCageFrameCounter[w] = 0;
							Main.mouseCageFrame[w] = Main.mouseCageFrame[w] + 1;
						}
						if (Main.mouseCageFrame[w] > 11)
						{
							Main.mouseCageFrame[w] = 0;
						}
					}
					else if (Main.mouseCageFrame[w] >= 12 && Main.mouseCageFrame[w] <= 13)
					{
						Main.mouseCageFrameCounter[w] = Main.mouseCageFrameCounter[w] + 1;
						if (Main.mouseCageFrameCounter[w] >= 5)
						{
							Main.mouseCageFrameCounter[w] = 0;
							Main.mouseCageFrame[w] = Main.mouseCageFrame[w] + 1;
						}
					}
					else if (Main.mouseCageFrame[w] >= 14 && Main.mouseCageFrame[w] <= 17)
					{
						Main.mouseCageFrameCounter[w] = Main.mouseCageFrameCounter[w] + 1;
						if (Main.mouseCageFrameCounter[w] >= 5)
						{
							Main.mouseCageFrameCounter[w] = 0;
							Main.mouseCageFrame[w] = Main.mouseCageFrame[w] + 1;
							if (Main.mouseCageFrame[w] > 17 && Main.rand.Next(20) != 0)
							{
								Main.mouseCageFrame[w] = 14;
							}
						}
					}
					else if (Main.mouseCageFrame[w] >= 18 && Main.mouseCageFrame[w] <= 19)
					{
						Main.mouseCageFrameCounter[w] = Main.mouseCageFrameCounter[w] + 1;
						if (Main.mouseCageFrameCounter[w] >= 5)
						{
							Main.mouseCageFrameCounter[w] = 0;
							Main.mouseCageFrame[w] = Main.mouseCageFrame[w] + 1;
							if (Main.mouseCageFrame[w] > 19)
							{
								Main.mouseCageFrame[w] = 0;
							}
						}
					}
				}
				for (int x = 0; x < Main.cageFrames; x++)
				{
					Main.wormCageFrameCounter[x] = Main.wormCageFrameCounter[x] + 1;
					if (Main.wormCageFrameCounter[x] >= Main.rand.Next(30, 91))
					{
						Main.wormCageFrameCounter[x] = 0;
						if (Main.rand.Next(4) == 0)
						{
							Main.wormCageFrame[x] = Main.wormCageFrame[x] + 1;
							if (Main.wormCageFrame[x] == 9 && Main.rand.Next(2) == 0)
							{
								Main.wormCageFrame[x] = 0;
							}
							if (Main.wormCageFrame[x] > 18)
							{
								if (Main.rand.Next(2) != 0)
								{
									Main.wormCageFrame[x] = 0;
								}
								else
								{
									Main.wormCageFrame[x] = 9;
								}
							}
						}
					}
				}
				int num1 = 0;
				for (int y = 0; y < 3; y++)
				{
					switch (y)
					{
						case 0:
							{
								num1 = 24;
								break;
							}
						case 1:
							{
								num1 = 31;
								break;
							}
						case 2:
							{
								num1 = 34;
								break;
							}
					}
					for (int a = 0; a < Main.cageFrames; a++)
					{
						int num2 = Main.slugCageFrameCounter[y, a] + 1;
						int num3 = num2;
						Main.slugCageFrameCounter[y, a] = num2;
						if (num3 >= Main.rand.Next(5, 15))
						{
							Main.slugCageFrameCounter[y, a] = 0;
							int num4 = Main.slugCageFrame[y, a] + 1;
							int num5 = num4;
							Main.slugCageFrame[y, a] = num4;
							if (num5 >= num1)
							{
								Main.slugCageFrame[y, a] = 0;
							}
						}
					}
				}
				for (int b = 0; b < Main.cageFrames; b++)
				{
					if (Main.grasshopperCageFrame[b] >= 0 && Main.grasshopperCageFrame[b] <= 1)
					{
						Main.grasshopperCageFrameCounter[b] = Main.grasshopperCageFrameCounter[b] + 1;
						if (Main.grasshopperCageFrameCounter[b] >= 5)
						{
							Main.grasshopperCageFrame[b] = Main.grasshopperCageFrame[b] + 1;
							if (Main.grasshopperCageFrame[b] > 1)
							{
								Main.grasshopperCageFrame[b] = 0;
							}
							Main.grasshopperCageFrameCounter[b] = 0;
							if (Main.rand.Next(15) == 0)
							{
								Main.grasshopperCageFrame[b] = 2;
							}
						}
					}
					else if (Main.grasshopperCageFrame[b] >= 2 && Main.grasshopperCageFrame[b] <= 5)
					{
						Main.grasshopperCageFrameCounter[b] = Main.grasshopperCageFrameCounter[b] + 1;
						if (Main.grasshopperCageFrameCounter[b] >= 5)
						{
							Main.grasshopperCageFrameCounter[b] = 0;
							Main.grasshopperCageFrame[b] = Main.grasshopperCageFrame[b] + 1;
						}
						if (Main.grasshopperCageFrame[b] > 5)
						{
							Main.grasshopperCageFrame[b] = 6;
						}
					}
					else if (Main.grasshopperCageFrame[b] >= 6 && Main.grasshopperCageFrame[b] <= 7)
					{
						Main.grasshopperCageFrameCounter[b] = Main.grasshopperCageFrameCounter[b] + 1;
						if (Main.grasshopperCageFrameCounter[b] >= 5)
						{
							Main.grasshopperCageFrame[b] = Main.grasshopperCageFrame[b] + 1;
							if (Main.grasshopperCageFrame[b] > 7)
							{
								Main.grasshopperCageFrame[b] = 6;
							}
							Main.grasshopperCageFrameCounter[b] = 0;
							if (Main.rand.Next(15) == 0)
							{
								Main.grasshopperCageFrame[b] = 8;
							}
						}
					}
					else if (Main.grasshopperCageFrame[b] >= 8 && Main.grasshopperCageFrame[b] <= 11)
					{
						Main.grasshopperCageFrameCounter[b] = Main.grasshopperCageFrameCounter[b] + 1;
						if (Main.grasshopperCageFrameCounter[b] >= 5)
						{
							Main.grasshopperCageFrameCounter[b] = 0;
							Main.grasshopperCageFrame[b] = Main.grasshopperCageFrame[b] + 1;
						}
						if (Main.grasshopperCageFrame[b] > 11)
						{
							Main.grasshopperCageFrame[b] = 0;
						}
					}
				}
				for (int c = 0; c < Main.cageFrames; c++)
				{
					byte num6 = 5;
					if (Main.fishBowlFrameMode[c] == 1)
					{
						if (Main.rand.Next(900) == 0)
						{
							Main.fishBowlFrameMode[c] = (byte)Main.rand.Next((int)num6);
						}
						Main.fishBowlFrameCounter[c] = Main.fishBowlFrameCounter[c] + 1;
						if (Main.fishBowlFrameCounter[c] >= 5)
						{
							Main.fishBowlFrameCounter[c] = 0;
							if (Main.fishBowlFrame[c] != 10)
							{
								Main.fishBowlFrame[c] = Main.fishBowlFrame[c] + 1;
							}
							else if (Main.rand.Next(20) != 0)
							{
								Main.fishBowlFrame[c] = 1;
							}
							else
							{
								Main.fishBowlFrame[c] = 11;
								Main.fishBowlFrameMode[c] = 0;
							}
						}
					}
					else if (Main.fishBowlFrameMode[c] == 2)
					{
						if (Main.rand.Next(3600) == 0)
						{
							Main.fishBowlFrameMode[c] = (byte)Main.rand.Next((int)num6);
						}
						Main.fishBowlFrameCounter[c] = Main.fishBowlFrameCounter[c] + 1;
						if (Main.fishBowlFrameCounter[c] >= 20)
						{
							Main.fishBowlFrameCounter[c] = 0;
							if (Main.fishBowlFrame[c] != 10)
							{
								Main.fishBowlFrame[c] = Main.fishBowlFrame[c] + 1;
							}
							else if (Main.rand.Next(20) != 0)
							{
								Main.fishBowlFrame[c] = 1;
							}
							else
							{
								Main.fishBowlFrame[c] = 11;
								Main.fishBowlFrameMode[c] = 0;
							}
						}
					}
					else if (Main.fishBowlFrameMode[c] == 3)
					{
						if (Main.rand.Next(3600) == 0)
						{
							Main.fishBowlFrameMode[c] = (byte)Main.rand.Next((int)num6);
						}
						Main.fishBowlFrameCounter[c] = Main.fishBowlFrameCounter[c] + 1;
						if (Main.fishBowlFrameCounter[c] >= Main.rand.Next(5, 3600))
						{
							Main.fishBowlFrameCounter[c] = 0;
							if (Main.fishBowlFrame[c] != 10)
							{
								Main.fishBowlFrame[c] = Main.fishBowlFrame[c] + 1;
							}
							else if (Main.rand.Next(20) != 0)
							{
								Main.fishBowlFrame[c] = 1;
							}
							else
							{
								Main.fishBowlFrame[c] = 11;
								Main.fishBowlFrameMode[c] = 0;
							}
						}
					}
					else if (Main.fishBowlFrame[c] <= 10)
					{
						if (Main.rand.Next(3600) == 0)
						{
							Main.fishBowlFrameMode[c] = (byte)Main.rand.Next((int)num6);
						}
						Main.fishBowlFrameCounter[c] = Main.fishBowlFrameCounter[c] + 1;
						if (Main.fishBowlFrameCounter[c] >= 10)
						{
							Main.fishBowlFrameCounter[c] = 0;
							if (Main.fishBowlFrame[c] != 10)
							{
								Main.fishBowlFrame[c] = Main.fishBowlFrame[c] + 1;
							}
							else if (Main.rand.Next(12) != 0)
							{
								Main.fishBowlFrame[c] = 1;
							}
							else
							{
								Main.fishBowlFrame[c] = 11;
							}
						}
					}
					else if (Main.fishBowlFrame[c] == 12 || Main.fishBowlFrame[c] == 13)
					{
						Main.fishBowlFrameCounter[c] = Main.fishBowlFrameCounter[c] + 1;
						if (Main.fishBowlFrameCounter[c] >= 10)
						{
							Main.fishBowlFrameCounter[c] = 0;
							Main.fishBowlFrame[c] = Main.fishBowlFrame[c] + 1;
							if (Main.fishBowlFrame[c] > 13)
							{
								if (Main.rand.Next(20) != 0)
								{
									Main.fishBowlFrame[c] = 12;
								}
								else
								{
									Main.fishBowlFrame[c] = 14;
								}
							}
						}
					}
					else if (Main.fishBowlFrame[c] >= 11)
					{
						Main.fishBowlFrameCounter[c] = Main.fishBowlFrameCounter[c] + 1;
						if (Main.fishBowlFrameCounter[c] >= 10)
						{
							Main.fishBowlFrameCounter[c] = 0;
							Main.fishBowlFrame[c] = Main.fishBowlFrame[c] + 1;
							if (Main.fishBowlFrame[c] > 16)
							{
								Main.fishBowlFrame[c] = 4;
							}
						}
					}
				}
				for (int d = 0; d < 9; d++)
				{
					for (int e = 0; e < Main.cageFrames; e++)
					{
						Main.butterflyCageFrameCounter[d, e] = Main.butterflyCageFrameCounter[d, e] + 1;
						if (Main.rand.Next(3600) == 0)
						{
							Main.butterflyCageMode[d, e] = (byte)Main.rand.Next(5);
							if (Main.rand.Next(2) == 0)
							{
								Main.butterflyCageMode[d, e] = (byte)(Main.butterflyCageMode[d, e] + 10);
							}
						}
						int num7 = Main.rand.Next(3, 16);
						if (Main.butterflyCageMode[d, e] == 1 || Main.butterflyCageMode[d, e] == 11)
						{
							num7 = 3;
						}
						if (Main.butterflyCageMode[d, e] == 2 || Main.butterflyCageMode[d, e] == 12)
						{
							num7 = 5;
						}
						if (Main.butterflyCageMode[d, e] == 3 || Main.butterflyCageMode[d, e] == 13)
						{
							num7 = 10;
						}
						if (Main.butterflyCageMode[d, e] == 4 || Main.butterflyCageMode[d, e] == 14)
						{
							num7 = 15;
						}
						if (Main.butterflyCageMode[d, e] >= 10)
						{
							if (Main.butterflyCageFrame[d, e] <= 7)
							{
								if (Main.butterflyCageFrameCounter[d, e] >= num7)
								{
									Main.butterflyCageFrameCounter[d, e] = 0;
									Main.butterflyCageFrame[d, e] = Main.butterflyCageFrame[d, e] - 1;
									if (Main.butterflyCageFrame[d, e] < 0)
									{
										Main.butterflyCageFrame[d, e] = 7;
									}
									if (Main.butterflyCageFrame[d, e] == 1 || Main.butterflyCageFrame[d, e] == 4 || Main.butterflyCageFrame[d, e] == 6)
									{
										if (Main.rand.Next(20) == 0)
										{
											Main.butterflyCageFrame[d, e] = Main.butterflyCageFrame[d, e] + 8;
										}
										else if (Main.rand.Next(6) == 0)
										{
											if (Main.butterflyCageMode[d, e] < 10)
											{
												Main.butterflyCageMode[d, e] = (byte)(Main.butterflyCageMode[d, e] + 10);
											}
											else
											{
												Main.butterflyCageMode[d, e] = (byte)(Main.butterflyCageMode[d, e] - 10);
											}
										}
									}
								}
							}
							else if (Main.butterflyCageFrameCounter[d, e] >= num7)
							{
								Main.butterflyCageFrameCounter[d, e] = 0;
								Main.butterflyCageFrame[d, e] = Main.butterflyCageFrame[d, e] - 1;
								if (Main.butterflyCageFrame[d, e] < 8)
								{
									Main.butterflyCageFrame[d, e] = 14;
								}
								if (Main.butterflyCageFrame[d, e] == 9 || Main.butterflyCageFrame[d, e] == 12 || Main.butterflyCageFrame[d, e] == 14)
								{
									if (Main.rand.Next(20) == 0)
									{
										Main.butterflyCageFrame[d, e] = Main.butterflyCageFrame[d, e] - 8;
									}
									else if (Main.rand.Next(6) == 0)
									{
										if (Main.butterflyCageMode[d, e] < 10)
										{
											Main.butterflyCageMode[d, e] = (byte)(Main.butterflyCageMode[d, e] + 10);
										}
										else
										{
											Main.butterflyCageMode[d, e] = (byte)(Main.butterflyCageMode[d, e] - 10);
										}
									}
								}
							}
						}
						else if (Main.butterflyCageFrame[d, e] <= 7)
						{
							if (Main.butterflyCageFrameCounter[d, e] >= num7)
							{
								Main.butterflyCageFrameCounter[d, e] = 0;
								Main.butterflyCageFrame[d, e] = Main.butterflyCageFrame[d, e] + 1;
								if (Main.butterflyCageFrame[d, e] > 7)
								{
									Main.butterflyCageFrame[d, e] = 0;
								}
								if ((Main.butterflyCageFrame[d, e] == 1 || Main.butterflyCageFrame[d, e] == 4 || Main.butterflyCageFrame[d, e] == 6) && Main.rand.Next(10) == 0)
								{
									Main.butterflyCageFrame[d, e] = Main.butterflyCageFrame[d, e] + 8;
								}
							}
						}
						else if (Main.butterflyCageFrameCounter[d, e] >= num7)
						{
							Main.butterflyCageFrameCounter[d, e] = 0;
							Main.butterflyCageFrame[d, e] = Main.butterflyCageFrame[d, e] + 1;
							if (Main.butterflyCageFrame[d, e] > 15)
							{
								Main.butterflyCageFrame[d, e] = 8;
							}
							if ((Main.butterflyCageFrame[d, e] == 9 || Main.butterflyCageFrame[d, e] == 12 || Main.butterflyCageFrame[d, e] == 14) && Main.rand.Next(10) == 0)
							{
								Main.butterflyCageFrame[d, e] = Main.butterflyCageFrame[d, e] - 8;
							}
						}
					}
				}
				for (int f = 0; f < 3; f++)
				{
					for (int g = 0; g < Main.cageFrames; g++)
					{
						Main.jellyfishCageFrameCounter[f, g] = Main.jellyfishCageFrameCounter[f, g] + 1;
						if (Main.jellyfishCageMode[f, g] == 0 && Main.rand.Next(1800) == 0)
						{
							Main.jellyfishCageMode[f, g] = 1;
						}
						if (Main.jellyfishCageMode[f, g] == 2 && Main.rand.Next(60) == 0)
						{
							Main.jellyfishCageMode[f, g] = 3;
						}
						int num8 = 1;
						if (Main.jellyfishCageMode[f, g] == 0)
						{
							num8 = Main.rand.Next(10, 20);
						}
						if (Main.jellyfishCageMode[f, g] == 1)
						{
							num8 = Main.rand.Next(15, 25);
						}
						if (Main.jellyfishCageMode[f, g] == 2)
						{
							num8 = Main.rand.Next(4, 9);
						}
						if (Main.jellyfishCageMode[f, g] == 3)
						{
							num8 = Main.rand.Next(15, 25);
						}
						if (Main.jellyfishCageMode[f, g] == 0 && Main.jellyfishCageFrame[f, g] <= 3 && Main.jellyfishCageFrameCounter[f, g] >= num8)
						{
							Main.jellyfishCageFrameCounter[f, g] = 0;
							Main.jellyfishCageFrame[f, g] = Main.jellyfishCageFrame[f, g] + 1;
							if (Main.jellyfishCageFrame[f, g] >= 4)
							{
								Main.jellyfishCageFrame[f, g] = 0;
							}
						}
						if (Main.jellyfishCageMode[f, g] == 1 && Main.jellyfishCageFrame[f, g] <= 7 && Main.jellyfishCageFrameCounter[f, g] >= num8)
						{
							Main.jellyfishCageFrameCounter[f, g] = 0;
							Main.jellyfishCageFrame[f, g] = Main.jellyfishCageFrame[f, g] + 1;
							if (Main.jellyfishCageFrame[f, g] >= 7)
							{
								Main.jellyfishCageMode[f, g] = 2;
							}
						}
						if (Main.jellyfishCageMode[f, g] == 2 && Main.jellyfishCageFrame[f, g] <= 9 && Main.jellyfishCageFrameCounter[f, g] >= num8)
						{
							Main.jellyfishCageFrameCounter[f, g] = 0;
							Main.jellyfishCageFrame[f, g] = Main.jellyfishCageFrame[f, g] + 1;
							if (Main.jellyfishCageFrame[f, g] >= 9)
							{
								Main.jellyfishCageFrame[f, g] = 7;
							}
						}
						if (Main.jellyfishCageMode[f, g] == 3 && Main.jellyfishCageFrame[f, g] <= 10 && Main.jellyfishCageFrameCounter[f, g] >= num8)
						{
							Main.jellyfishCageFrameCounter[f, g] = 0;
							Main.jellyfishCageFrame[f, g] = Main.jellyfishCageFrame[f, g] + 1;
							if (Main.jellyfishCageFrame[f, g] >= 10)
							{
								Main.jellyfishCageFrame[f, g] = 3;
								Main.jellyfishCageMode[f, g] = 0;
							}
						}
					}
				}
			}
		}

		public static void CursorColor()
		{
			Main.cursorAlpha = Main.cursorAlpha + (float)Main.cursorColorDirection * 0.015f;
			if (Main.cursorAlpha >= 1f)
			{
				Main.cursorAlpha = 1f;
				Main.cursorColorDirection = -1;
			}
			if ((double)Main.cursorAlpha <= 0.6)
			{
				Main.cursorAlpha = 0.6f;
				Main.cursorColorDirection = 1;
			}
			float single = Main.cursorAlpha * 0.3f + 0.7f;
			byte r = (byte)((float)Main.mouseColor.R * Main.cursorAlpha);
			byte g = (byte)((float)Main.mouseColor.G * Main.cursorAlpha);
			byte b = (byte)((float)Main.mouseColor.B * Main.cursorAlpha);
			byte num = (byte)(255f * single);
			Main.cursorColor = new Color((int)r, (int)g, (int)b, (int)num);
			Main.cursorScale = Main.cursorAlpha * 0.3f + 0.7f + 0.1f;
		}

		public static int DamageVar(float dmg)
		{
			float single = dmg * (1f + (float)Main.rand.Next(-15, 16) * 0.01f);
			return (int)Math.Round((double)single);
		}

		public void DedServ()
		{
			ServerApi.Hooks.InvokeGameInitialize();
			string str;
			Main.rand = new Random();
			Console.Title = string.Concat("Terraria Server ", Main.versionNumber2);
			Main.dedServ = true;
			Main.showSplash = false;
			if (Main.autoGen)
			{
				Main.ActiveWorldFileData = new WorldFileData();
				Main.ActiveWorldFileData.Path = Main.WorldPathClassic;
			}
			this.Initialize();
			Lang.setLang(false);
			for (int i = 0; i < 540; i++)
			{
				NPC nPC = new NPC();
				nPC.SetDefaults(i, -1f);
				Main.npcName[i] = nPC.name;
			}

			if (Console.IsInputRedirected == true && string.IsNullOrEmpty(Main.WorldPathClassic) == true && !Main.autoGen)
			{
				throw new Exception("When running in the background, the world must be specified with -world <path>");
			}

			while (string.IsNullOrEmpty(Main.worldPathName))
			{
				bool flag = true;
				while (flag)
				{
					Main.LoadWorlds();
					Console.WriteLine(string.Concat("Terraria Server ", Main.versionNumber2));
					Console.WriteLine("");
					for (int j = 0; j < Main.WorldList.Count; j++)
					{
						object[] name = new object[]
						{
							j + 1,
							'\t',
							'\t', Main.WorldList[j].Name
						};
						Console.WriteLine("{0,-4}{1,-22}{2}, {3}, {4,-6}{5}",
							j + 1,
							Main.WorldList[j].Name,
							Main.WorldList[j].IsHardMode ? "hard" : "norm",
							Main.WorldList[j].HasCrimson ? "crim" : "corr",
							Main.WorldList[j].IsExpertMode ? "exp" : "norm",
							String.Format("Last used: {0}",
								File.GetLastWriteTime(Main.WorldList[j].Path).ToString("g")));
					}
					Console.WriteLine();
					Console.WriteLine("n           \tNew World");
					Console.WriteLine("d   <number>\tDelete World");
					Console.WriteLine("");
					Console.Write("Choose World: ");
					string str2 = Console.ReadLine() ?? "";
					try
					{
						Console.Clear();
					}
					catch (Exception ex)
					{
#if DEBUG
						Console.WriteLine(ex);
						System.Diagnostics.Debugger.Break();

#endif
					}
					if (str2.Length >= 2 && str2.Substring(0, 2).ToLower() == "d ")
					{
						try
						{
							int num = Convert.ToInt32(str2.Substring(2)) - 1;
							if (num < Main.WorldList.Count)
							{
								Console.WriteLine(string.Concat("Terraria Server ", Main.versionNumber2));
								Console.WriteLine("");
								Console.WriteLine(string.Concat("Really delete ", Main.WorldList[num].Name, "?"));
								Console.Write("(y/n): ");
								if (Console.ReadLine().ToLower() == "y")
								{
									Main.EraseWorld(num);
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
						try
						{
							Console.Clear();
						}
						catch (Exception ex)
						{
#if DEBUG
							Console.WriteLine(ex);
							System.Diagnostics.Debugger.Break();

#endif
						}
					}
					else if (str2 == "n" || str2 == "N")
					{
						bool flag1 = true;
						while (flag1)
						{
							Console.WriteLine(string.Concat("Terraria Server ", Main.versionNumber2));
							Console.WriteLine("");
							Console.WriteLine(string.Concat("1", '\t', "Small"));
							Console.WriteLine(string.Concat("2", '\t', "Medium"));
							Console.WriteLine(string.Concat("3", '\t', "Large"));
							Console.WriteLine("");
							Console.Write("Choose size: ");
							str = Console.ReadLine();
							try
							{
								int num1 = Convert.ToInt32(str);
								if (num1 == 1)
								{
									Main.maxTilesX = 4200;
									Main.maxTilesY = 1200;
									flag1 = false;
								}
								else if (num1 == 2)
								{
									Main.maxTilesX = 6400;
									Main.maxTilesY = 1800;
									flag1 = false;
								}
								else if (num1 == 3)
								{
									Main.maxTilesX = 8400;
									Main.maxTilesY = 2400;
									flag1 = false;
								}
							}
							catch (Exception ex)
							{
#if DEBUG
								Console.WriteLine(ex);
								System.Diagnostics.Debugger.Break();

#endif
							}
							try
							{
								Console.Clear();
							}
							catch (Exception ex)
							{
#if DEBUG
								Console.WriteLine(ex);
								System.Diagnostics.Debugger.Break();

#endif
							}
						}
						flag1 = true;
						while (flag1)
						{
							Console.WriteLine(string.Concat("Terraria Server ", Main.versionNumber2));
							Console.WriteLine("");
							Console.WriteLine(string.Concat("1", '\t', "Normal"));
							Console.WriteLine(string.Concat("2", '\t', "Expert"));
							Console.WriteLine("");
							Console.Write("Choose difficulty: ");
							str = Console.ReadLine();
							try
							{
								int num2 = Convert.ToInt32(str);
								if (num2 == 1)
								{
									Main.expertMode = false;
									flag1 = false;
								}
								else if (num2 == 2)
								{
									Main.expertMode = true;
									flag1 = false;
								}
							}
							catch (Exception ex)
							{
#if DEBUG
								Console.WriteLine(ex);
								System.Diagnostics.Debugger.Break();

#endif
							}
							try
							{
								Console.Clear();
							}
							catch (Exception ex)
							{
#if DEBUG
								Console.WriteLine(ex);
								System.Diagnostics.Debugger.Break();

#endif
							}
						}
						flag1 = true;
						while (flag1)
						{
							Console.WriteLine(string.Concat("Terraria Server ", Main.versionNumber2));
							Console.WriteLine("");
							Console.Write("Enter world name: ");
							Main.newWorldName = Console.ReadLine();
							if (Main.newWorldName != "" && Main.newWorldName != " " && Main.newWorldName != null)
							{
								if (Main.newWorldName.Length > 20)
								{
									Main.newWorldName = Main.newWorldName.Substring(0, 20);
								}
								flag1 = false;
							}
							try
							{
								Console.Clear();
							}
							catch (Exception ex)
							{
#if DEBUG
								Console.WriteLine(ex);
								System.Diagnostics.Debugger.Break();

#endif
							}
						}
						Main.worldName = Main.newWorldName;
						Main.ActiveWorldFileData = WorldFile.CreateMetadata(Main.worldName, Main.expertMode);
						Main.menuMode = 10;
						Main.serverGenLock = true;
						GenerationProgress generationProgress = new GenerationProgress();
						WorldGen.CreateNewWorld(generationProgress);
						flag1 = false;
						while (Main.menuMode == 10)
						{
							if (Main.oldStatusText == Main.statusText)
							{
								continue;
							}
							Main.oldStatusText = Main.statusText;
							Console.WriteLine(Main.statusText);
						}
						try
						{
							Console.Clear();
						}
						catch (Exception ex)
						{
#if DEBUG
							Console.WriteLine(ex);
							System.Diagnostics.Debugger.Break();

#endif
						}

                        int oldProgress = 0;
                        int oldValue = 0;

						while (Main.serverGenLock)
						{

                            if ((int)(generationProgress.TotalProgress * 100) != oldProgress || (int)(generationProgress.Value * 100) != oldValue)
                            {
                                Main.statusText = string.Format(string.Concat("{0:0%} - ", generationProgress.Message, " - {1:0%}"), generationProgress.TotalProgress, generationProgress.Value);
                                Main.oldStatusText = Main.statusText;
                                oldProgress = (int)(generationProgress.TotalProgress * 100);
                                oldValue = (int)(generationProgress.Value * 100);
                                Console.WriteLine(Main.statusText);
                            }
						}
					}
					else
					{
						try
						{
							int num3 = Convert.ToInt32(str2);
							num3--;
							if (num3 >= 0 && num3 < Main.WorldList.Count)
							{
								bool flag2 = true;
								while (flag2)
								{
									Console.WriteLine(string.Concat("Terraria Server ", Main.versionNumber2));
									Console.WriteLine("");
									Console.Write("Max players (press enter for {0}): ", Main.maxNetPlayers);
									string str3 = Console.ReadLine();
									try
									{
										if (str3 == "")
										{
											str3 = Main.maxNetPlayers.ToString();
										}
										int num4 = Convert.ToInt32(str3);
										if (num4 <= 255 && num4 >= 1)
										{
											Main.maxNetPlayers = num4;
											flag2 = false;
										}
										flag2 = false;
									}
									catch (Exception ex)
									{
#if DEBUG
										Console.WriteLine(ex);
										System.Diagnostics.Debugger.Break();

#endif
									}
									try
									{
										Console.Clear();
									}
									catch (Exception ex)
									{
#if DEBUG
										Console.WriteLine(ex);
										System.Diagnostics.Debugger.Break();

#endif
									}
								}
								flag2 = true;
								while (flag2)
								{
									if (Netplay.ListenPort != 7777) //If the port has been changed by the API do not allow it to be changed.
									{
										flag2 = false;
										break;
									}
									Console.WriteLine(string.Concat("Terraria Server ", Main.versionNumber2));
									Console.WriteLine("");
									Console.Write("Server port (press enter for 7777): ");
									string str4 = Console.ReadLine();
									try
									{
										if (str4 == "")
										{
											str4 = "7777";
										}
										int num5 = Convert.ToInt32(str4);
										if (num5 <= 65535)
										{
											Netplay.ListenPort = num5;
											flag2 = false;
										}
									}
									catch (Exception ex)
									{
#if DEBUG
										Console.WriteLine(ex);
										System.Diagnostics.Debugger.Break();

#endif
									}
									try
									{
										Console.Clear();
									}
									catch (Exception ex)
									{
#if DEBUG
										Console.WriteLine(ex);
										System.Diagnostics.Debugger.Break();

#endif
									}
								}
								Main.ActiveWorldFileData = Main.WorldList[num3];
								flag = false;
								try
								{
									Console.Clear();
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
						catch (Exception ex)
						{
#if DEBUG
							Console.WriteLine(ex);
							System.Diagnostics.Debugger.Break();

#endif
						}
					}
				}
			}
			try
			{
				Console.Clear();
			}
			catch (Exception ex)
			{
#if DEBUG
				Console.WriteLine(ex);
				System.Diagnostics.Debugger.Break();

#endif
			}
			WorldGen.serverLoadWorld();
			Console.WriteLine(string.Concat("Terraria Server ", Main.versionNumber));
			Console.WriteLine("");
			while (!Netplay.IsServerRunning)
			{
				if (Main.oldStatusText == Main.statusText)
				{
					continue;
				}
				Main.oldStatusText = Main.statusText;
				Console.WriteLine(Main.statusText);
			}
			try
			{
				Console.Clear();
			}
			catch (Exception ex)
			{
#if DEBUG
				Console.WriteLine(ex);
				System.Diagnostics.Debugger.Break();

#endif
			}
			Console.WriteLine(string.Concat("Terraria Server ", Main.versionNumber));
			Console.WriteLine("");
			Console.WriteLine(string.Concat("Listening on port ", Netplay.ListenPort));
			Console.WriteLine("Type 'help' for a list of commands.");
			Console.WriteLine("");
			Console.Title = string.Concat("Terraria Server: ", Main.worldName);

			Stopwatch stopwatch = new Stopwatch();
			if (!Main.autoShutdown)
			{
				Main.startDedInput();
			}
			ServerApi.Hooks.InvokeGamePostInitialize();
			stopwatch.Start();
			double num6 = 16.6666666666667;
			double num7 = 0;
			int num8 = 0;
			while (!Netplay.disconnect)
			{
				double elapsedMilliseconds = (double)stopwatch.ElapsedMilliseconds;
				if (elapsedMilliseconds + num7 >= num6)
				{
					num8++;
					num7 = num7 + (elapsedMilliseconds - num6);
					stopwatch.Reset();
					stopwatch.Start();
					if (Main.oldStatusText != Main.statusText)
					{
						Main.oldStatusText = Main.statusText;
						Console.WriteLine(Main.statusText);
					}
					if (Netplay.anyClients || ServerApi.ForceUpdate)
					{
						ServerApi.Hooks.InvokeGameUpdate();
						this.Update();
						ServerApi.Hooks.InvokeGamePostUpdate();
					}
					double elapsedMilliseconds1 = (double)stopwatch.ElapsedMilliseconds + num7;
					if (elapsedMilliseconds1 < num6)
					{
						int num9 = (int)(num6 - elapsedMilliseconds1) - 1;
						if (num9 > 1)
						{
							Thread.Sleep(num9 - 1);
							if (!Netplay.anyClients)
							{
								num7 = 0;
								Thread.Sleep(10);
							}
						}
					}
				}
				Thread.Sleep(0);
			}
		}

		protected void Draw()
		{
		}

		protected void DrawBackground()
		{
		}

		protected void DrawBlack(bool force = false)
		{
		}

		private static void DrawBreath(int heartCount)
		{
		}

		protected void DrawCachedNPCs(List<int> npcCache, bool behindTiles)
		{
		}

		protected void DrawCachedProjs(List<int> projCache)
		{
		}

		public void DrawCapture(Rectangle area)
		{
		}

		protected void DrawClothesWindow()
		{
		}

		protected void DrawDust()
		{
		}

		protected void DrawFPS()
		{
		}

		protected void DrawGhost(Player drawPlayer, Vector2 Position, float shadow = 0f)
		{
		}

		protected void DrawGore()
		{
		}

		protected void DrawGoreBehind()
		{
		}

		protected void DrawHairWindow()
		{
		}

		protected void DrawHealthBar(float X, float Y, int Health, int MaxHealth, float alpha, float scale = 1f)
		{
		}

		public void DrawInfernoRings()
		{
		}

		private void DrawInfoAccs()
		{
		}

		protected void DrawInterface()
		{
		}

		public static void DrawInvasionProgress()
		{
		}

		protected void DrawInventory()
		{
		}

		protected void DrawItem(Item item, int whoami)
		{
		}

		public void DrawItems()
		{
		}

		protected void DrawMap()
		{
		}

		protected void DrawMenu()
		{
		}

		public void DrawMouseOver()
		{
		}

		protected void DrawNPC(int i, bool behindTiles)
		{
		}

		protected void DrawNPCExtras(NPC n, bool beforeDraw, float addHeight, float addY, Color npcColor, Vector2 halfSize)
		{
		}

		protected void DrawNPCHouse()
		{
		}

		protected void DrawNPCs(bool behindTiles = false)
		{
		}

		private static int DrawPageIcons()
		{
			return 0;
		}

		public void DrawPlayer(Player drawPlayer, Vector2 Position, float rotation, Vector2 rotationOrigin, float shadow = 0f)
		{
		}

		protected void DrawPlayerChat()
		{
		}

		protected void DrawPlayerHead(Player drawPlayer, float X, float Y, float Alpha = 1f, float Scale = 1f)
		{
		}

		protected Vector2 DrawPlayerItemPos(float gravdir, int itemtype)
		{
			return Vector2.Zero;
		}

		protected void DrawPlayers()
		{
		}

		protected void DrawPlayerStoned(Player drawPlayer, Vector2 Position)
		{
		}

		public void DrawProj(int i)
		{
		}

		protected void DrawProjectiles()
		{
		}

		private static void DrawPVPIcons()
		{
		}

		protected void DrawRain()
		{
		}

		public void DrawSimpleSurfaceBackground()
		{
		}

		protected void DrawSplash()
		{
		}

		protected void DrawSurfaceBG()
		{
		}

		private void DrawTileCracks(int crackType)
		{
		}

		protected void DrawTiles(bool solidOnly = true, int waterStyleOverride = -1)
		{
		}

		protected void DrawToMap()
		{
		}

		protected void DrawToMap_Section(int secX, int secY)
		{
		}

		protected void DrawUnderworldBackground(bool flat)
		{
		}

		protected void DrawWalls()
		{
		}

		protected void DrawWater(bool bg = false, int Style = 0, float Alpha = 1f)
		{
		}

		protected void drawWaters(bool bg = false, int styleOverride = -1, bool allowUpdate = true)
		{
		}

		protected void DrawWires()
		{
		}

		protected void DrawWoF()
		{
		}

		protected void EnsureRenderTargetContent()
		{
		}

		private static void ErasePlayer(int i)
		{
		}

		private static void EraseWorld(int i)
		{
			try
			{
				File.Delete(Main.WorldList[i].Path);
				File.Delete(Main.WorldList[i].Path + ".bak");
				Main.LoadWorlds();
			}
			catch (Exception ex)
			{
#if DEBUG
				Console.WriteLine(ex);
				System.Diagnostics.Debugger.Break();

#endif
			}
		}

		public static void FakeLoadInvasionStart()
		{
			int num = 0;
			int num1 = 0;
			switch (Main.invasionType)
			{
				case 1:
				case 2:
					{
						num = 80;
						num1 = 40;
						break;
					}
				case 3:
					{
						num = 120;
						num1 = 60;
						break;
					}
				case 4:
					{
						num = 160;
						num1 = 40;
						break;
					}
			}
			int num2 = (int)Math.Ceiling((double)((float)(Main.invasionSize - num) / (float)num1));
			Main.invasionSizeStart = num;
			if (num2 > 0)
			{
				Main.invasionSizeStart = Main.invasionSizeStart + num2 * num1;
			}
		}

		protected bool FullTile(int x, int y)
		{
			if (Main.tile[x - 1, y] == null || Main.tile[x - 1, y].blockType() != 0 || Main.tile[x + 1, y] == null || Main.tile[x + 1, y].blockType() != 0)
			{
				return false;
			}
			Tile tile = Main.tile[x, y];
			if (tile == null)
			{
				return false;
			}
			if (tile.active())
			{
				ushort num = tile.type;
				if (num <= 138)
				{
					if (num <= 48)
					{
						if (num == 10 || num == 48)
						{
							return false;
						}
						goto Label0;
					}
					else if (num != 54)
					{
						switch (num)
						{
							case 137:
							case 138:
								{
									break;
								}
							default:
								{
									goto Label0;
								}
						}
					}
				}
				else if (num <= 191)
				{
					if (num == 162 || num == 191)
					{
						return false;
					}
					goto Label0;
				}
				else if (num != 232 && num != 328)
				{
					switch (num)
					{
						case 387:
						case 388:
							{
								break;
							}
						default:
							{
								goto Label0;
							}
					}
				}
				return false;
			}
			return false;
			Label0:
			if (Main.tileSolid[tile.type] && !Main.tileSolidTop[tile.type])
			{
				int num1 = tile.frameX;
				int num2 = tile.frameY;
				if (Main.tileLargeFrames[tile.type] == 1)
				{
					if (num2 == 18 || num2 == 108)
					{
						if (num1 >= 18 && num1 <= 54)
						{
							return true;
						}
						if (num1 >= 108 && num1 <= 144)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
				else if (num2 == 18)
				{
					if (num1 >= 18 && num1 <= 54)
					{
						return true;
					}
					if (num1 >= 108 && num1 <= 144)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else if (num2 >= 90 && num2 <= 196)
				{
					if (num1 <= 70)
					{
						return true;
					}
					if (num1 >= 144 && num1 <= 232)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public static string GetInputText(string oldString)
		{
			return "";
		}

		public static string GetPlayerPathFromName(string playerName)
		{
			string str = "";
			for (int i = 0; i < playerName.Length; i++)
			{
				string str1 = playerName.Substring(i, 1);
				string str2 = "";
				if (str1 == "a" || str1 == "b" || str1 == "c" || str1 == "d" || str1 == "e" || str1 == "f" || str1 == "g" || str1 == "h" || str1 == "i" || str1 == "j" || str1 == "k" || str1 == "l" || str1 == "m" || str1 == "n" || str1 == "o" || str1 == "p" || str1 == "q" || str1 == "r" || str1 == "s" || str1 == "t" || str1 == "u" || str1 == "v" || str1 == "w" || str1 == "x" || str1 == "y" || str1 == "z" || str1 == "A" || str1 == "B" || str1 == "C" || str1 == "D" || str1 == "E" || str1 == "F" || str1 == "G" || str1 == "H" || str1 == "I" || str1 == "J" || str1 == "K" || str1 == "L" || str1 == "M" || str1 == "N" || str1 == "O" || str1 == "P" || str1 == "Q" || str1 == "R" || str1 == "S" || str1 == "T" || str1 == "U" || str1 == "V" || str1 == "W" || str1 == "X" || str1 == "Y" || str1 == "Z" || str1 == "1" || str1 == "2" || str1 == "3" || str1 == "4" || str1 == "5" || str1 == "6" || str1 == "7" || str1 == "8" || str1 == "9" || str1 == "0")
				{
					str2 = str1;
				}
				else
				{
					str2 = (str1 != " " ? "-" : "_");
				}
				str = string.Concat(str, str2);
			}
			string str3 = Main.PlayerPath;
			object[] directorySeparatorChar = new object[] { str3, Path.DirectorySeparatorChar, str, ".plr" };
			if (FileUtilities.GetFullPath(string.Concat(directorySeparatorChar)).StartsWith("\\\\.\\", StringComparison.Ordinal))
			{
				str = string.Concat(str, "_");
			}
			object[] objArray = new object[] { str3, Path.DirectorySeparatorChar, str, ".plr" };
			if (FileUtilities.Exists(string.Concat(objArray)))
			{
				int num = 2;
				while (true)
				{
					object[] directorySeparatorChar1 = new object[] { str3, Path.DirectorySeparatorChar, str, num, ".plr" };
					if (!FileUtilities.Exists(string.Concat(directorySeparatorChar1)))
					{
						break;
					}
					num++;
				}
				str = string.Concat(str, num);
			}
			object[] objArray1 = new object[] { str3, Path.DirectorySeparatorChar, str, ".plr" };
			return string.Concat(objArray1);
		}

		public static int GetTreeStyle(int X)
		{
			int num = 0;
			if (X <= Main.treeX[0])
			{
				num = Main.treeStyle[0];
			}
			else if (X > Main.treeX[1])
			{
				num = (X > Main.treeX[2] ? Main.treeStyle[3] : Main.treeStyle[2]);
			}
			else
			{
				num = Main.treeStyle[1];
			}
			if (num == 0)
			{
				return 0;
			}
			if (num == 5)
			{
				return 10;
			}
			return 5 + num;
		}

		protected static int GetTreeVariant(int x, int y)
		{
			if (Main.tile[x, y] == null || !Main.tile[x, y].active())
			{
				return -1;
			}
			int num = Main.tile[x, y].type;
			if (num > 70)
			{
				if (num == 109)
				{
					return 2;
				}
				if (num == 147)
				{
					return 3;
				}
				if (num == 199)
				{
					return 4;
				}
			}
			else
			{
				if (num == 23)
				{
					return 0;
				}
				if (num == 60)
				{
					if ((double)y <= Main.worldSurface)
					{
						return 1;
					}
					return 5;
				}
				if (num == 70)
				{
					return 6;
				}
			}
			return -1;
		}

		public static string GetWorldPathFromName(string worldName)
		{
			string str = worldName;
			string str1 = "";
			for (int i = 0; i < str.Length; i++)
			{
				string str2 = str.Substring(i, 1);
				string str3 = "";
				if (str2 == "a" || str2 == "b" || str2 == "c" || str2 == "d" || str2 == "e" || str2 == "f" || str2 == "g" || str2 == "h" || str2 == "i" || str2 == "j" || str2 == "k" || str2 == "l" || str2 == "m" || str2 == "n" || str2 == "o" || str2 == "p" || str2 == "q" || str2 == "r" || str2 == "s" || str2 == "t" || str2 == "u" || str2 == "v" || str2 == "w" || str2 == "x" || str2 == "y" || str2 == "z" || str2 == "A" || str2 == "B" || str2 == "C" || str2 == "D" || str2 == "E" || str2 == "F" || str2 == "G" || str2 == "H" || str2 == "I" || str2 == "J" || str2 == "K" || str2 == "L" || str2 == "M" || str2 == "N" || str2 == "O" || str2 == "P" || str2 == "Q" || str2 == "R" || str2 == "S" || str2 == "T" || str2 == "U" || str2 == "V" || str2 == "W" || str2 == "X" || str2 == "Y" || str2 == "Z" || str2 == "1" || str2 == "2" || str2 == "3" || str2 == "4" || str2 == "5" || str2 == "6" || str2 == "7" || str2 == "8" || str2 == "9" || str2 == "0")
				{
					str3 = str2;
				}
				else
				{
					str3 = (str2 != " " ? "-" : "_");
				}
				str1 = string.Concat(str1, str3);
			}
			string str4 = Main.WorldPath;
			object[] directorySeparatorChar = new object[] { str4, Path.DirectorySeparatorChar, str1, ".wld" };
			if (FileUtilities.GetFullPath(string.Concat(directorySeparatorChar)).StartsWith("\\\\.\\", StringComparison.Ordinal))
			{
				str1 = string.Concat(str1, "_");
			}
			object[] objArray = new object[] { str4, Path.DirectorySeparatorChar, str1, ".wld" };
			if (FileUtilities.Exists(string.Concat(objArray)))
			{
				int num = 2;
				while (true)
				{
					object[] directorySeparatorChar1 = new object[] { str4, Path.DirectorySeparatorChar, str1, num, ".wld" };
					if (!FileUtilities.Exists(string.Concat(directorySeparatorChar1)))
					{
						break;
					}
					num++;
				}
				str1 = string.Concat(str1, num);
			}
			object[] objArray1 = new object[] { str4, Path.DirectorySeparatorChar, str1, ".wld" };
			return string.Concat(objArray1);
		}

		public void GUIBarsDraw()
		{
			if (!Main.ignoreErrors)
			{
				this.GUIBarsDrawInner();
			}
			else
			{
				try
				{
					this.GUIBarsDrawInner();
				}
				catch (Exception exception)
				{
					TimeLogger.DrawException(exception);
				}
			}
		}

		protected void GUIBarsDrawInner()
		{
		}

		private void GUIBarsMouseOverLife()
		{
		}

		private void GUIBarsMouseOverMana()
		{
		}

		private void GUIChatDraw()
		{
		}

		protected void GUIChatDrawInner()
		{
		}

		private void GUIHotbarDraw()
		{
		}

		protected void GUIHotbarDrawInner()
		{
		}

		private static void HelpText()
		{
		}

		public static Color HslToRgb(float Hue, float Saturation, float Luminosity)
		{
			byte num;
			byte num1;
			byte num2;
			double num3;
			if (Saturation != 0f)
			{
				double hue = (double)Hue;
				num3 = ((double)Luminosity >= 0.5 ? (double)(Luminosity + Saturation - Luminosity * Saturation) : (double)Luminosity * (1 + (double)Saturation));
				double luminosity = 2 * (double)Luminosity - num3;
				double num4 = hue + 0.333333333333333;
				double num5 = hue;
				double num6 = hue - 0.333333333333333;
				num4 = Main.hue2rgb(num4, luminosity, num3);
				num5 = Main.hue2rgb(num5, luminosity, num3);
				num6 = Main.hue2rgb(num6, luminosity, num3);
				num = (byte)Math.Round(num4 * 255);
				num1 = (byte)Math.Round(num5 * 255);
				num2 = (byte)Math.Round(num6 * 255);
			}
			else
			{
				num = (byte)Math.Round((double)Luminosity * 255);
				num1 = (byte)Math.Round((double)Luminosity * 255);
				num2 = (byte)Math.Round((double)Luminosity * 255);
			}
			return new Color((int)num, (int)num1, (int)num2);
		}

		public static double hue2rgb(double c, double t1, double t2)
		{
			if (c < 0)
			{
				c = c + 1;
			}
			if (c > 1)
			{
				c = c - 1;
			}
			if (6 * c < 1)
			{
				return t1 + (t2 - t1) * 6 * c;
			}
			if (2 * c < 1)
			{
				return t2;
			}
			if (3 * c >= 2)
			{
				return t1;
			}
			return t1 + (t2 - t1) * (0.666666666666667 - c) * 6;
		}

		protected void Initialize()
		{
			Item item;
			Main.netMode = 2;
			TileObjectData.Initialize();
			Animation.Initialize();
			Chest.Initialize();
			Wiring.Initialize();
			Framing.Initialize();
			TileEntity.InitializeAll();
			Main.InitializeItemAnimations();
			Mount.Initialize();
			Minecart.Initialize();
			WorldGen.RandomizeBackgrounds();
			WorldGen.RandomizeCaveBackgrounds();
			WorldGen.RandomizeMoonState();
			Main.bgAlpha[0] = 1f;
			Main.bgAlpha2[0] = 1f;
			this.invBottom = 258;
			for (int i = 0; i < 651; i++)
			{
				Main.projFrames[i] = 1;
			}
			Main.projFrames[643] = 8;
			Main.projFrames[566] = 4;
			Main.projFrames[565] = 4;
			Main.projFrames[525] = 5;
			Main.projFrames[519] = 4;
			Main.projFrames[509] = 2;
			Main.projFrames[485] = 5;
			Main.projFrames[492] = 8;
			Main.projFrames[500] = 4;
			Main.projFrames[499] = 12;
			Main.projFrames[518] = 4;
			Main.projFrames[585] = 4;
			Main.projFrames[593] = 4;
			Main.projFrames[595] = 28;
			Main.projFrames[596] = 4;
			Main.projFrames[612] = 5;
			Main.projFrames[613] = 4;
			Main.projFrames[614] = 4;
			Main.projFrames[615] = 7;
			Main.projFrames[623] = 12;
			Main.projFrames[633] = 5;
			Main.projFrames[645] = 7;
			Main.projFrames[650] = 4;
			Main.projFrames[384] = 6;
			Main.projFrames[385] = 3;
			Main.projFrames[386] = 6;
			Main.projFrames[390] = 11;
			Main.projFrames[391] = 11;
			Main.projFrames[392] = 11;
			Main.projFrames[393] = 15;
			Main.projFrames[394] = 15;
			Main.projFrames[395] = 15;
			Main.projFrames[398] = 10;
			Main.projFrames[407] = 6;
			Main.projFrames[408] = 2;
			Main.projFrames[409] = 3;
			Main.projFrames[387] = 3;
			Main.projFrames[388] = 3;
			Main.projFrames[334] = 11;
			Main.projFrames[324] = 10;
			Main.projFrames[351] = 2;
			Main.projFrames[349] = 5;
			Main.projFrames[423] = 4;
			Main.projFrames[435] = 4;
			Main.projFrames[436] = 4;
			Main.projFrames[439] = 6;
			Main.projFrames[443] = 4;
			Main.projFrames[447] = 4;
			Main.projFrames[448] = 3;
			Main.projFrames[450] = 5;
			Main.projFrames[454] = 2;
			Main.projFrames[456] = 4;
			Main.projFrames[459] = 3;
			Main.projFrames[462] = 5;
			Main.projFrames[465] = 4;
			Main.projFrames[467] = 4;
			Main.projFrames[468] = 4;
			Main.projFrames[533] = 21;
			Main.projFrames[535] = 12;
			Main.projFrames[539] = 4;
			Main.projFrames[575] = 4;
			Main.projFrames[574] = 2;
			Main.projFrames[634] = 4;
			Main.projFrames[635] = 4;
			Main.projFrames[353] = 14;
			Main.projFrames[346] = 2;
			Main.projFrames[347] = 2;
			Main.projFrames[335] = 4;
			Main.projFrames[344] = 3;
			Main.projFrames[337] = 5;
			Main.projFrames[317] = 8;
			Main.projFrames[321] = 3;
			Main.projFrames[308] = 10;
			Main.projFrames[316] = 4;
			Main.projFrames[275] = 2;
			Main.projFrames[276] = 2;
			Main.projFrames[254] = 5;
			Main.projFrames[307] = 2;
			Main.projFrames[72] = 4;
			Main.projFrames[86] = 4;
			Main.projFrames[87] = 4;
			Main.projFrames[102] = 2;
			Main.projFrames[111] = 8;
			Main.projFrames[112] = 3;
			Main.projFrames[127] = 16;
			Main.projFrames[175] = 2;
			Main.projFrames[181] = 4;
			Main.projFrames[189] = 4;
			Main.projFrames[191] = 18;
			Main.projFrames[192] = 18;
			Main.projFrames[193] = 18;
			Main.projFrames[194] = 18;
			Main.projFrames[190] = 4;
			Main.projFrames[198] = 4;
			Main.projFrames[199] = 8;
			Main.projFrames[200] = 10;
			Main.projFrames[206] = 5;
			Main.projFrames[208] = 5;
			Main.projFrames[209] = 12;
			Main.projFrames[210] = 12;
			Main.projFrames[211] = 10;
			Main.projFrames[221] = 3;
			Main.projFrames[237] = 4;
			Main.projFrames[238] = 6;
			Main.projFrames[221] = 3;
			Main.projFrames[228] = 5;
			Main.projFrames[229] = 4;
			Main.projFrames[236] = 13;
			Main.projFrames[243] = 4;
			Main.projFrames[244] = 6;
			Main.projFrames[249] = 5;
			Main.projFrames[252] = 4;
			Main.projFrames[266] = 6;
			Main.projFrames[268] = 8;
			Main.projFrames[269] = 7;
			Main.projFrames[270] = 3;
			Main.projFrames[313] = 12;
			Main.projFrames[314] = 13;
			Main.projFrames[319] = 11;
			Main.projFrames[373] = 3;
			Main.projFrames[375] = 8;
			Main.projFrames[377] = 9;
			Main.projFrames[379] = 4;
			Main.projFrames[380] = 4;
			Main.projFrames[601] = 2;
			Main.projFrames[602] = 4;
			Main.projPet[492] = true;
			Main.projPet[499] = true;
			Main.projPet[319] = true;
			Main.projPet[334] = true;
			Main.projPet[324] = true;
			Main.projPet[266] = true;
			Main.projPet[313] = true;
			Main.projPet[314] = true;
			Main.projPet[317] = true;
			Main.projPet[175] = true;
			Main.projPet[111] = true;
			Main.projPet[112] = true;
			Main.projPet[127] = true;
			Main.projPet[191] = true;
			Main.projPet[192] = true;
			Main.projPet[193] = true;
			Main.projPet[194] = true;
			Main.projPet[197] = true;
			Main.projPet[198] = true;
			Main.projPet[199] = true;
			Main.projPet[200] = true;
			Main.projPet[208] = true;
			Main.projPet[209] = true;
			Main.projPet[210] = true;
			Main.projPet[211] = true;
			Main.projPet[236] = true;
			Main.projPet[268] = true;
			Main.projPet[269] = true;
			Main.projPet[353] = true;
			Main.projPet[373] = true;
			Main.projPet[375] = true;
			Main.projPet[377] = true;
			Main.projPet[380] = true;
			Main.projPet[387] = true;
			Main.projPet[388] = true;
			Main.projPet[390] = true;
			Main.projPet[391] = true;
			Main.projPet[392] = true;
			Main.projPet[393] = true;
			Main.projPet[394] = true;
			Main.projPet[395] = true;
			Main.projPet[398] = true;
			Main.projPet[407] = true;
			Main.projPet[423] = true;
			Main.projPet[533] = true;
			Main.projPet[613] = true;
			Main.projPet[623] = true;
			Main.projPet[625] = true;
			Main.projPet[626] = true;
			Main.projPet[627] = true;
			Main.projPet[628] = true;
			Main.tileLighted[TileID.LihzahrdAltar] = true;
			Main.tileLighted[TileID.Sunflower] = true;
			Main.tileLighted[TileID.LavaMoss] = true;
			Main.tileLighted[TileID.LongMoss] = true;
			Main.slimeRainNPC[1] = true;
			Main.debuff[BuffID.StarInBottle] = true;
			Main.debuff[BuffID.Dazed] = true;
			Main.debuff[BuffID.Poisoned] = true;
			Main.debuff[BuffID.PotionSickness] = true;
			Main.debuff[BuffID.Darkness] = true;
			Main.debuff[BuffID.Cursed] = true;
			Main.debuff[BuffID.OnFire] = true;
			Main.debuff[BuffID.Tipsy] = true;
			Main.debuff[BuffID.Werewolf] = true;
			Main.debuff[BuffID.Bleeding] = true;
			Main.debuff[BuffID.Confused] = true;
			Main.debuff[BuffID.Slow] = true;
			Main.debuff[BuffID.Weak] = true;
			Main.debuff[BuffID.Merfolk] = true;
			Main.debuff[BuffID.Silenced] = true;
			Main.debuff[BuffID.BrokenArmor] = true;
			Main.debuff[BuffID.Horrified] = true;
			Main.debuff[BuffID.TheTongue] = true;
			Main.debuff[BuffID.CursedInferno] = true;
			Main.debuff[BuffID.Frostburn] = true;
			Main.debuff[BuffID.Chilled] = true;
			Main.debuff[BuffID.Frozen] = true;
			Main.debuff[BuffID.Burning] = true;
			Main.debuff[BuffID.Suffocation] = true;
			Main.debuff[BuffID.Ichor] = true;
			Main.debuff[BuffID.Venom] = true;
			Main.debuff[BuffID.Blackout] = true;
			Main.debuff[BuffID.WaterCandle] = true;
			Main.debuff[BuffID.Campfire] = true;
			Main.debuff[BuffID.ChaosState] = true;
			Main.debuff[BuffID.HeartLamp] = true;
			Main.debuff[BuffID.ManaSickness] = true;
			Main.debuff[BuffID.Wet] = true;
			Main.debuff[BuffID.Lovestruck] = true;
			Main.debuff[BuffID.Stinky] = true;
			Main.debuff[BuffID.Slimed] = true;
			Main.debuff[BuffID.MoonLeech] = true;
			Main.debuff[BuffID.Sunflower] = true;
			Main.debuff[BuffID.MonsterBanner] = true;
			Main.debuff[BuffID.Rabies] = true;
			Main.debuff[BuffID.Webbed] = true;
			Main.debuff[BuffID.Stoned] = true;
			Main.debuff[BuffID.PeaceCandle] = true;
			Main.debuff[BuffID.Obstructed] = true;
			Main.debuff[BuffID.VortexDebuff] = true;
			Main.debuff[BuffID.Electrified] = true;
			Main.pvpBuff[BuffID.Poisoned] = true;
			Main.pvpBuff[BuffID.OnFire] = true;
			Main.pvpBuff[BuffID.Confused] = true;
			Main.pvpBuff[BuffID.CursedInferno] = true;
			Main.pvpBuff[BuffID.Frostburn] = true;
			Main.pvpBuff[BuffID.Poisoned] = true;
			Main.pvpBuff[BuffID.Ichor] = true;
			Main.pvpBuff[BuffID.Wet] = true;
			Main.pvpBuff[BuffID.Lovestruck] = true;
			Main.pvpBuff[BuffID.Stinky] = true;
			Main.pvpBuff[BuffID.Slimed] = true;
			Main.meleeBuff[BuffID.WeaponImbueVenom] = true;
			Main.meleeBuff[BuffID.WeaponImbueCursedFlames] = true;
			Main.meleeBuff[BuffID.WeaponImbueFire] = true;
			Main.meleeBuff[BuffID.WeaponImbueGold] = true;
			Main.meleeBuff[BuffID.WeaponImbueIchor] = true;
			Main.meleeBuff[BuffID.WeaponImbueNanites] = true;
			Main.meleeBuff[BuffID.WeaponImbueConfetti] = true;
			Main.meleeBuff[BuffID.WeaponImbuePoison] = true;
			Main.buffNoSave[BuffID.Poisoned] = true;
			Main.buffNoSave[BuffID.Darkness] = true;
			Main.buffNoSave[BuffID.Cursed] = true;
			Main.buffNoSave[BuffID.OnFire] = true;
			Main.buffNoSave[BuffID.Werewolf] = true;
			Main.buffNoSave[BuffID.Bleeding] = true;
			Main.buffNoSave[BuffID.Confused] = true;
			Main.buffNoSave[BuffID.Merfolk] = true;
			Main.buffNoSave[BuffID.Silenced] = true;
			Main.buffNoSave[BuffID.Horrified] = true;
			Main.buffNoSave[BuffID.TheTongue] = true;
			Main.buffNoSave[BuffID.CursedInferno] = true;
			Main.buffNoSave[BuffID.PaladinsShield] = true;
			Main.buffNoSave[BuffID.Frostburn] = true;
			Main.buffNoSave[BuffID.Chilled] = true;
			Main.buffNoSave[BuffID.Frozen] = true;
			Main.buffNoSave[BuffID.Honey] = true;
			Main.buffNoSave[BuffID.RapidHealing] = true;
			Main.buffNoSave[BuffID.ShadowDodge] = true;
			Main.buffNoSave[BuffID.LeafCrystal] = true;
			Main.buffNoSave[BuffID.IceBarrier] = true;
			Main.buffNoSave[BuffID.Panic] = true;
			Main.buffNoSave[BuffID.BabySlime] = true;
			Main.buffNoSave[BuffID.Burning] = true;
			Main.buffNoSave[BuffID.Suffocation] = true;
			Main.buffNoSave[BuffID.Ichor] = true;
			Main.buffNoSave[BuffID.Venom] = true;
			Main.buffNoSave[BuffID.Midas] = true;
			Main.buffNoSave[BuffID.Blackout] = true;
			Main.buffNoSave[BuffID.Campfire] = true;
			Main.buffNoSave[BuffID.StarInBottle] = true;
			Main.buffNoSave[BuffID.Sunflower] = true;
			Main.buffNoSave[BuffID.MonsterBanner] = true;
			Main.buffNoSave[BuffID.ChaosState] = true;
			Main.buffNoSave[BuffID.HeartLamp] = true;
			Main.buffNoSave[BuffID.ManaSickness] = true;
			Main.buffNoSave[BuffID.BeetleEndurance1] = true;
			Main.buffNoSave[BuffID.BeetleEndurance2] = true;
			Main.buffNoSave[BuffID.BeetleEndurance3] = true;
			Main.buffNoSave[BuffID.BeetleMight1] = true;
			Main.buffNoSave[BuffID.BeetleMight2] = true;
			Main.buffNoSave[BuffID.BeetleMight3] = true;
			Main.buffNoSave[BuffID.Wet] = true;
			Main.buffNoSave[BuffID.MinecartLeft] = true;
			Main.buffNoSave[BuffID.MinecartRight] = true;
			Main.buffNoSave[BuffID.MinecartLeftMech] = true;
			Main.buffNoSave[BuffID.MinecartRightMech] = true;
			Main.buffNoSave[BuffID.MinecartLeftWood] = true;
			Main.buffNoSave[BuffID.MinecartRightWood] = true;
			Main.buffNoSave[BuffID.Lovestruck] = true;
			Main.buffNoSave[BuffID.Stinky] = true;
			Main.buffNoSave[BuffID.Rudolph] = true;
			Main.buffNoSave[BuffID.HornetMinion] = true;
			Main.buffNoSave[BuffID.ImpMinion] = true;
			Main.buffNoSave[BuffID.BunnyMount] = true;
			Main.buffNoSave[BuffID.PigronMount] = true;
			Main.buffNoSave[BuffID.SlimeMount] = true;
			Main.buffNoSave[BuffID.TurtleMount] = true;
			Main.buffNoSave[BuffID.BeeMount] = true;
			Main.buffNoSave[BuffID.SpiderMinion] = true;
			Main.buffNoSave[BuffID.TwinEyesMinion] = true;
			Main.buffNoSave[BuffID.PirateMinion] = true;
			Main.buffNoSave[BuffID.SharknadoMinion] = true;
			Main.buffNoSave[BuffID.UFOMinion] = true;
			Main.buffNoSave[BuffID.UFOMount] = true;
			Main.buffNoSave[BuffID.DrillMount] = true;
			Main.buffNoSave[BuffID.ScutlixMount] = true;
			Main.buffNoSave[BuffID.Slimed] = true;
			Main.buffNoSave[BuffID.Electrified] = true;
			Main.buffNoSave[BuffID.DeadlySphere] = true;
			Main.buffNoSave[BuffID.UnicornMount] = true;
			Main.buffNoSave[BuffID.Obstructed] = true;
			Main.buffNoSave[BuffID.VortexDebuff] = true;
			Main.buffNoSave[BuffID.CuteFishronMount] = true;
			Main.buffNoSave[BuffID.SolarShield1] = true;
			Main.buffNoSave[BuffID.SolarShield2] = true;
			Main.buffNoSave[BuffID.SolarShield3] = true;
			Main.buffNoSave[BuffID.StardustMinion] = true;
			Main.buffNoSave[BuffID.StardustGuardianMinion] = true;
			Main.buffNoSave[BuffID.StardustDragonMinion] = true;
			for (int j = 173; j <= 181; j++)
			{
				Main.buffNoSave[j] = true;
			}
			Main.buffNoTimeDisplay[BuffID.ShadowOrb] = true;
			Main.buffNoTimeDisplay[BuffID.FairyBlue] = true;
			Main.buffNoTimeDisplay[BuffID.Werewolf] = true;
			Main.buffNoTimeDisplay[BuffID.Merfolk] = true;
			Main.buffNoTimeDisplay[BuffID.Horrified] = true;
			Main.buffNoTimeDisplay[BuffID.TheTongue] = true;
			Main.buffNoTimeDisplay[BuffID.PetBunny] = true;
			Main.buffNoTimeDisplay[BuffID.BabyPenguin] = true;
			Main.buffNoTimeDisplay[BuffID.PetTurtle] = true;
			Main.buffNoTimeDisplay[BuffID.PaladinsShield] = true;
			Main.buffNoTimeDisplay[BuffID.BabyEater] = true;
			Main.buffNoTimeDisplay[BuffID.Pygmies] = true;
			Main.buffNoTimeDisplay[BuffID.LeafCrystal] = true;
			Main.buffNoTimeDisplay[BuffID.IceBarrier] = true;
			Main.buffNoTimeDisplay[BuffID.BabySlime] = true;
			Main.buffNoTimeDisplay[BuffID.Suffocation] = true;
			Main.buffNoTimeDisplay[BuffID.PetSpider] = true;
			Main.buffNoTimeDisplay[BuffID.Squashling] = true;
			Main.buffNoTimeDisplay[BuffID.Ravens] = true;
			Main.buffNoTimeDisplay[BuffID.Rudolph] = true;
			Main.buffNoTimeDisplay[BuffID.BeetleEndurance1] = true;
			Main.buffNoTimeDisplay[BuffID.BeetleEndurance2] = true;
			Main.buffNoTimeDisplay[BuffID.BeetleEndurance3] = true;
			Main.buffNoTimeDisplay[BuffID.BeetleMight1] = true;
			Main.buffNoTimeDisplay[BuffID.BeetleMight2] = true;
			Main.buffNoTimeDisplay[BuffID.BeetleMight3] = true;
			Main.buffNoTimeDisplay[BuffID.FairyRed] = true;
			Main.buffNoTimeDisplay[BuffID.FairyGreen] = true;
			Main.buffNoTimeDisplay[BuffID.MinecartLeft] = true;
			Main.buffNoTimeDisplay[BuffID.MinecartRight] = true;
			Main.buffNoTimeDisplay[BuffID.MinecartLeftMech] = true;
			Main.buffNoTimeDisplay[BuffID.MinecartRightMech] = true;
			Main.buffNoTimeDisplay[BuffID.MinecartLeftWood] = true;
			Main.buffNoTimeDisplay[BuffID.MinecartRightWood] = true;
			Main.buffNoTimeDisplay[BuffID.HornetMinion] = true;
			Main.buffNoTimeDisplay[BuffID.ImpMinion] = true;
			Main.buffNoTimeDisplay[BuffID.BunnyMount] = true;
			Main.buffNoTimeDisplay[BuffID.PigronMount] = true;
			Main.buffNoTimeDisplay[BuffID.SlimeMount] = true;
			Main.buffNoTimeDisplay[BuffID.TurtleMount] = true;
			Main.buffNoTimeDisplay[BuffID.BeeMount] = true;
			Main.buffNoTimeDisplay[BuffID.SpiderMinion] = true;
			Main.buffNoTimeDisplay[BuffID.TwinEyesMinion] = true;
			Main.buffNoTimeDisplay[BuffID.PirateMinion] = true;
			Main.buffNoTimeDisplay[BuffID.MiniMinotaur] = true;
			Main.buffNoTimeDisplay[BuffID.SharknadoMinion] = true;
			Main.buffNoTimeDisplay[BuffID.UFOMinion] = true;
			Main.buffNoTimeDisplay[BuffID.UFOMount] = true;
			Main.buffNoTimeDisplay[BuffID.DrillMount] = true;
			Main.buffNoTimeDisplay[BuffID.ScutlixMount] = true;
			Main.buffNoTimeDisplay[BuffID.Slimed] = true;
			Main.buffNoTimeDisplay[BuffID.MoonLeech] = true;
			Main.buffNoTimeDisplay[BuffID.DeadlySphere] = true;
			Main.buffNoTimeDisplay[BuffID.UnicornMount] = true;
			Main.buffNoTimeDisplay[BuffID.Obstructed] = true;
			Main.buffNoTimeDisplay[BuffID.CuteFishronMount] = true;
			Main.buffNoTimeDisplay[BuffID.SolarShield1] = true;
			Main.buffNoTimeDisplay[BuffID.SolarShield2] = true;
			Main.buffNoTimeDisplay[BuffID.SolarShield3] = true;
			Main.buffNoTimeDisplay[BuffID.StardustMinion] = true;
			Main.buffNoTimeDisplay[BuffID.DryadsWard] = true;
			Main.buffNoTimeDisplay[BuffID.DryadsWardDebuff] = true;
			Main.buffNoTimeDisplay[BuffID.StardustGuardianMinion] = true;
			Main.buffNoTimeDisplay[BuffID.StardustDragonMinion] = true;
			Main.persistentBuff[BuffID.WeaponImbueVenom] = true;
			Main.persistentBuff[BuffID.WeaponImbueCursedFlames] = true;
			Main.persistentBuff[BuffID.WeaponImbueFire] = true;
			Main.persistentBuff[BuffID.WeaponImbueGold] = true;
			Main.persistentBuff[BuffID.WeaponImbueIchor] = true;
			Main.persistentBuff[BuffID.WeaponImbueNanites] = true;
			Main.persistentBuff[BuffID.WeaponImbueConfetti] = true;
			Main.persistentBuff[BuffID.WeaponImbuePoison] = true;
			Main.vanityPet[40] = true;
			Main.vanityPet[41] = true;
			Main.vanityPet[42] = true;
			Main.vanityPet[45] = true;
			Main.vanityPet[50] = true;
			Main.vanityPet[51] = true;
			Main.vanityPet[52] = true;
			Main.vanityPet[53] = true;
			Main.vanityPet[54] = true;
			Main.vanityPet[55] = true;
			Main.vanityPet[56] = true;
			Main.vanityPet[61] = true;
			Main.vanityPet[154] = true;
			Main.vanityPet[65] = true;
			Main.vanityPet[66] = true;
			Main.vanityPet[81] = true;
			Main.vanityPet[82] = true;
			Main.vanityPet[84] = true;
			Main.vanityPet[85] = true;
			Main.vanityPet[91] = true;
			Main.vanityPet[92] = true;
			Main.vanityPet[127] = true;
			Main.vanityPet[136] = true;
			Main.lightPet[19] = true;
			Main.lightPet[155] = true;
			Main.lightPet[27] = true;
			Main.lightPet[101] = true;
			Main.lightPet[102] = true;
			Main.lightPet[57] = true;
			Main.lightPet[190] = true;
			Main.lightPet[152] = true;
			Main.tileFlame[TileID.Torches] = true;
			Main.tileFlame[TileID.Candles] = true;
			Main.tileFlame[TileID.Chandeliers] = true;
			Main.tileFlame[TileID.Jackolanterns] = true;
			Main.tileFlame[TileID.HangingLanterns] = true;
			Main.tileFlame[TileID.WaterCandle] = true;
			Main.tileFlame[TileID.Lamps] = true;
			Main.tileFlame[TileID.SkullLanterns] = true;
			Main.tileFlame[TileID.Candelabras] = true;
			Main.tileFlame[TileID.PlatinumCandelabra] = true;
			Main.tileFlame[TileID.PlatinumCandle] = true;
			Main.tileFlame[TileID.PeaceCandle] = true;
			Main.tileRope[TileID.Rope] = true;
			Main.tileRope[TileID.Chain] = true;
			Main.tileRope[TileID.VineRope] = true;
			Main.tileRope[TileID.SilkRope] = true;
			Main.tileRope[TileID.WebRope] = true;
			Main.tilePile[TileID.CopperCoinPile] = true;
			Main.tilePile[TileID.SilverCoinPile] = true;
			Main.tilePile[TileID.GoldCoinPile] = true;
			Main.tilePile[TileID.PlatinumCoinPile] = true;
			for (int k = 0; k < 540; k++)
			{
				Main.npcCatchable[k] = false;
			}
			Main.npcCatchable[46] = true;
			Main.npcCatchable[55] = true;
			Main.npcCatchable[74] = true;
			Main.npcCatchable[148] = true;
			Main.npcCatchable[149] = true;
			Main.npcCatchable[297] = true;
			Main.npcCatchable[298] = true;
			Main.npcCatchable[299] = true;
			Main.npcCatchable[300] = true;
			Main.npcCatchable[355] = true;
			Main.npcCatchable[356] = true;
			Main.npcCatchable[357] = true;
			Main.npcCatchable[358] = true;
			Main.npcCatchable[359] = true;
			Main.npcCatchable[360] = true;
			Main.npcCatchable[361] = true;
			Main.npcCatchable[362] = true;
			Main.npcCatchable[363] = true;
			Main.npcCatchable[364] = true;
			Main.npcCatchable[365] = true;
			Main.npcCatchable[366] = true;
			Main.npcCatchable[367] = true;
			Main.npcCatchable[374] = true;
			Main.npcCatchable[377] = true;
			Main.npcCatchable[539] = true;
			Main.npcCatchable[538] = true;
			Main.npcCatchable[484] = true;
			Main.npcCatchable[485] = true;
			Main.npcCatchable[486] = true;
			Main.npcCatchable[487] = true;
			for (int l = 442; l <= 448; l++)
			{
				Main.npcCatchable[l] = true;
			}
			Main.SetTileValue();
			Main.tileSpelunker[TileID.Iron] = true;
			Main.tileSpelunker[TileID.Copper] = true;
			Main.tileSpelunker[TileID.Gold] = true;
			Main.tileSpelunker[TileID.Silver] = true;
			Main.tileSpelunker[TileID.Heart] = true;
			Main.tileSpelunker[TileID.Containers] = true;
			Main.tileSpelunker[TileID.Pots] = true;
			Main.tileSpelunker[TileID.Cobalt] = true;
			Main.tileSpelunker[TileID.Mythril] = true;
			Main.tileSpelunker[TileID.Adamantite] = true;
			Main.tileSpelunker[TileID.Sapphire] = true;
			Main.tileSpelunker[TileID.Ruby] = true;
			Main.tileSpelunker[TileID.Emerald] = true;
			Main.tileSpelunker[TileID.Topaz] = true;
			Main.tileSpelunker[TileID.Amethyst] = true;
			Main.tileSpelunker[TileID.Diamond] = true;
			Main.tileSpelunker[TileID.Tin] = true;
			Main.tileSpelunker[TileID.Lead] = true;
			Main.tileSpelunker[TileID.Tungsten] = true;
			Main.tileSpelunker[TileID.Platinum] = true;
			Main.tileSpelunker[TileID.ExposedGems] = true;
			Main.tileSpelunker[TileID.Chlorophyte] = true;
			Main.tileSpelunker[TileID.Palladium] = true;
			Main.tileSpelunker[TileID.Orichalcum] = true;
			Main.tileSpelunker[TileID.Titanium] = true;
			Main.tileSpelunker[TileID.LifeFruit] = true;
			Main.tileSpelunker[TileID.Meteorite] = true;
			Main.tileSpelunker[TileID.FossilOre] = true;
			Main.tileSpelunker[TileID.DyePlants] = true;
			Main.SetupTileMerge();
			Main.tileSolid[TileID.Bubble] = true;
			Main.tileSolid[TileID.PinkSlimeBlock] = true;
			Main.tileMergeDirt[TileID.PinkSlimeBlock] = true;
			Main.tileBlockLight[TileID.PinkSlimeBlock] = true;
			Main.tileBouncy[TileID.PinkSlimeBlock] = true;
			Main.tileFrameImportant[TileID.SharpeningStation] = true;
			Main.tileFrameImportant[TileID.WaterDrip] = true;
			Main.tileFrameImportant[TileID.HoneyDrip] = true;
			Main.tileFrameImportant[TileID.LavaDrip] = true;
			Main.tileLighted[TileID.PeaceCandle] = true;
			Main.tileFrameImportant[TileID.PeaceCandle] = true;
			Main.tileWaterDeath[TileID.PeaceCandle] = true;
			Main.tileLavaDeath[TileID.PeaceCandle] = true;
			Main.tileSolid[TileID.MarbleBlock] = true;
			Main.tileBrick[TileID.MarbleBlock] = true;
			Main.tileSolid[TileID.LunarOre] = true;
			Main.tileMergeDirt[TileID.LunarOre] = true;
			Main.tileBrick[TileID.LunarOre] = true;
			Main.tileSolid[TileID.LunarBrick] = true;
			Main.tileBrick[TileID.LunarBrick] = true;
			Main.tileSolid[TileID.LunarBlockSolar] = true;
			Main.tileBrick[TileID.LunarBlockSolar] = true;
			Main.tileLighted[TileID.LunarBlockSolar] = true;
			Main.tileSolid[TileID.LunarBlockVortex] = true;
			Main.tileBrick[TileID.LunarBlockVortex] = true;
			Main.tileLighted[TileID.LunarBlockVortex] = true;
			Main.tileSolid[TileID.LunarBlockNebula] = true;
			Main.tileBrick[TileID.LunarBlockNebula] = true;
			Main.tileLighted[TileID.LunarBlockNebula] = true;
			Main.tileSolid[TileID.LunarBlockStardust] = true;
			Main.tileBrick[TileID.LunarBlockStardust] = true;
			Main.tileLighted[TileID.LunarBlockStardust] = true;
			Main.tileBrick[TileID.Meteorite] = true;
			Main.tileBrick[TileID.Pearlstone] = true;
			Main.tileBrick[TileID.Ebonstone] = true;
			Main.tileBrick[TileID.Crimstone] = true;
			Main.tileSolid[TileID.WoodenSpikes] = true;
			Main.tileSolid[TileID.DynastyWood] = true;
			Main.tileSolid[TileID.RedDynastyShingles] = true;
			Main.tileSolid[TileID.BlueDynastyShingles] = true;
			Main.tileMergeDirt[TileID.DynastyWood] = true;
			Main.tileSolid[TileID.Coralstone] = true;
			Main.tileMergeDirt[TileID.Coralstone] = true;
			Main.tileSolid[TileID.BorealWood] = true;
			Main.tileSolid[TileID.PalmWood] = true;
			Main.tileBlockLight[TileID.BorealWood] = true;
			Main.tileBlockLight[TileID.PalmWood] = true;
			Main.tileMergeDirt[TileID.BorealWood] = true;
			Main.tileMergeDirt[TileID.PalmWood] = true;
			Main.tileBrick[TileID.BorealWood] = true;
			Main.tileBrick[TileID.PalmWood] = true;
			Main.tileShine[TileID.MetalBars] = 1100;
			Main.tileSolid[TileID.MetalBars] = true;
			Main.tileSolidTop[TileID.MetalBars] = true;
			Main.tileSolid[TileID.PlanterBox] = true;
			Main.tileSolidTop[TileID.PlanterBox] = true;
			Main.tileFrameImportant[TileID.GoldBirdCage] = true;
			Main.tileFrameImportant[TileID.GoldBunnyCage] = true;
			Main.tileFrameImportant[TileID.GoldButterflyCage] = true;
			Main.tileFrameImportant[TileID.GoldFrogCage] = true;
			Main.tileFrameImportant[TileID.GoldGrasshopperCage] = true;
			Main.tileFrameImportant[TileID.GoldMouseCage] = true;
			Main.tileFrameImportant[TileID.GoldWormCage] = true;
			Main.tileFrameImportant[TileID.CageEnchantedNightcrawler] = true;
			Main.tileLighted[TileID.CageEnchantedNightcrawler] = true;
			Main.tileFrameImportant[TileID.CageBuggy] = true;
			Main.tileFrameImportant[TileID.CageGrubby] = true;
			Main.tileFrameImportant[TileID.CageSluggy] = true;
			Main.tileFrameImportant[TileID.Sundial] = true;
			Main.tileFrameImportant[TileID.WeaponsRack] = true;
			Main.tileFrameImportant[TileID.BoneWelder] = true;
			Main.tileFrameImportant[TileID.FleshCloningVat] = true;
			Main.tileFrameImportant[TileID.GlassKiln] = true;
			Main.tileFrameImportant[TileID.LihzahrdFurnace] = true;
			Main.tileFrameImportant[TileID.LivingLoom] = true;
			Main.tileFrameImportant[TileID.SkyMill] = true;
			Main.tileFrameImportant[TileID.IceMachine] = true;
			Main.tileFrameImportant[TileID.SteampunkBoiler] = true;
			Main.tileFrameImportant[TileID.HoneyDispenser] = true;
			Main.tileFrameImportant[TileID.BewitchingTable] = true;
			Main.tileFrameImportant[TileID.AlchemyTable] = true;
			Main.tileFrameImportant[TileID.BeachPiles] = true;
			Main.tileObsidianKill[TileID.BeachPiles] = true;
			Main.tileLavaDeath[TileID.BeachPiles] = true;
			Main.tileFrameImportant[TileID.HeavyWorkBench] = true;
			Main.tileFrameImportant[TileID.MonarchButterflyJar] = true;
			Main.tileFrameImportant[TileID.PurpleEmperorButterflyJar] = true;
			Main.tileFrameImportant[TileID.RedAdmiralButterflyJar] = true;
			Main.tileFrameImportant[TileID.UlyssesButterflyJar] = true;
			Main.tileFrameImportant[TileID.SulphurButterflyJar] = true;
			Main.tileFrameImportant[TileID.TreeNymphButterflyJar] = true;
			Main.tileFrameImportant[TileID.ZebraSwallowtailButterflyJar] = true;
			Main.tileFrameImportant[TileID.JuliaButterflyJar] = true;
			Main.tileFrameImportant[TileID.ScorpionCage] = true;
			Main.tileFrameImportant[TileID.BlackScorpionCage] = true;
			Main.tileFrameImportant[TileID.BlueJellyfishBowl] = true;
			Main.tileFrameImportant[TileID.GreenJellyfishBowl] = true;
			Main.tileFrameImportant[TileID.PinkJellyfishBowl] = true;
			Main.tileLargeFrames[TileID.CopperPlating] = 1;
			Main.wallHouse[WallID.LunarBrickWall] = true;
			Main.wallLargeFrames[WallID.LunarBrickWall] = 2;
			Main.tileLargeFrames[TileID.LunarBrick] = 1;
			Main.tileFrameImportant[TileID.LunarMonolith] = true;
			Main.wallHouse[WallID.ChlorophyteBrick] = true;
			Main.wallHouse[WallID.Marble] = true;
			Main.wallHouse[WallID.MarbleBlock] = true;
			Main.wallLargeFrames[WallID.MarbleBlock] = 1;
			Main.tileSolid[TileID.Marble] = true;
			Main.tileBlockLight[TileID.Marble] = true;
			Main.tileMergeDirt[TileID.Marble] = true;
			Main.tileSolid[TileID.MarbleBlock] = true;
			Main.tileBlockLight[TileID.MarbleBlock] = true;
			Main.tileLargeFrames[TileID.MarbleBlock] = 1;
			Main.tileBlendAll[TileID.MarbleBlock] = true;
			Main.wallHouse[WallID.Granite] = true;
			Main.wallHouse[WallID.GraniteBlock] = true;
			Main.tileSolid[TileID.Granite] = true;
			Main.tileBlockLight[TileID.Granite] = true;
			Main.tileMergeDirt[TileID.Granite] = true;
			Main.tileSolid[TileID.GraniteBlock] = true;
			Main.tileBlockLight[TileID.GraniteBlock] = true;
			Main.tileBrick[TileID.GraniteBlock] = true;
			Main.tileMergeDirt[TileID.GraniteBlock] = true;
			Main.wallHouse[WallID.Crystal] = true;
			Main.tileLargeFrames[TileID.TinPlating] = 1;
			Main.tileSolid[TileID.TinPlating] = true;
			Main.tileBlockLight[TileID.TinPlating] = true;
			Main.wallLargeFrames[WallID.CopperPlating] = 1;
			Main.wallLargeFrames[WallID.StoneSlab] = 1;
			Main.wallLargeFrames[WallID.TinPlating] = 1;
			Main.wallLargeFrames[WallID.Cave8Unsafe] = 2;
			Main.tileSolid[TileID.Waterfall] = true;
			Main.tileBlockLight[TileID.Waterfall] = true;
			Main.tileSolid[TileID.Lavafall] = true;
			Main.tileBlockLight[TileID.Lavafall] = true;
			Main.tileSolid[TileID.Honeyfall] = true;
			Main.tileBlockLight[TileID.Honeyfall] = true;
			Main.tileLighted[TileID.Lavafall] = true;
			Main.tileSolid[TileID.Confetti] = true;
			Main.tileBrick[TileID.Confetti] = true;
			Main.tileSolid[TileID.ConfettiBlack] = true;
			Main.tileBrick[TileID.ConfettiBlack] = true;
			Main.tileBlockLight[TileID.ConfettiBlack] = true;
			Main.tileLighted[TileID.LivingFire] = true;
			Main.tileLighted[TileID.LivingCursedFire] = true;
			Main.tileLighted[TileID.LivingDemonFire] = true;
			Main.tileLighted[TileID.LivingFrostFire] = true;
			Main.tileLighted[TileID.LivingIchor] = true;
			Main.tileLighted[TileID.LivingUltrabrightFire] = true;
			Main.tileLighted[TileID.MushroomStatue] = true;
			Main.tileSolid[TileID.CopperPlating] = true;
			Main.tileBlockLight[TileID.CopperPlating] = true;
			Main.tileSolid[TileID.ChlorophyteBrick] = true;
			Main.tileBlockLight[TileID.ChlorophyteBrick] = true;
			Main.tileLighted[TileID.ChlorophyteBrick] = true;
			Main.tileShine[TileID.ChlorophyteBrick] = 2000;
			Main.tileShine2[TileID.ChlorophyteBrick] = true;
			Main.tileBrick[TileID.ChlorophyteBrick] = true;
			Main.tileMergeDirt[TileID.ChlorophyteBrick] = true;
			Main.tileSolid[TileID.CrimtaneBrick] = true;
			Main.tileBlockLight[TileID.CrimtaneBrick] = true;
			Main.tileLighted[TileID.CrimtaneBrick] = true;
			Main.tileShine[TileID.CrimtaneBrick] = 1900;
			Main.tileShine2[TileID.CrimtaneBrick] = true;
			Main.tileBrick[TileID.CrimtaneBrick] = true;
			Main.tileMergeDirt[TileID.CrimtaneBrick] = true;
			Main.tileSolid[TileID.ShroomitePlating] = true;
			Main.tileBlockLight[TileID.ShroomitePlating] = true;
			Main.tileLighted[TileID.ShroomitePlating] = true;
			Main.tileShine[TileID.ShroomitePlating] = 1800;
			Main.tileShine2[TileID.ShroomitePlating] = true;
			Main.tileBrick[TileID.ShroomitePlating] = true;
			Main.tileMergeDirt[TileID.ShroomitePlating] = true;
			Main.tileSolid[TileID.MartianConduitPlating] = true;
			Main.tileBlockLight[TileID.MartianConduitPlating] = true;
			Main.tileLighted[TileID.MartianConduitPlating] = true;
			Main.tileBrick[TileID.MartianConduitPlating] = true;
			Main.tileMergeDirt[TileID.MartianConduitPlating] = true;
			Main.tileGlowMask[TileID.MartianConduitPlating] = 94;
			Main.tileGlowMask[TileID.LavaLamp] = 130;
			Main.tileGlowMask[TileID.LavaMoss] = 126;
			Main.tileGlowMask[TileID.MeteoriteBrick] = 111;
			Main.tileGlowMask[TileID.CageEnchantedNightcrawler] = 131;
			Main.tileGlowMask[TileID.LunarMonolith] = 201;
			Main.tileSolid[TileID.MeteoriteBrick] = true;
			Main.tileBlockLight[TileID.MeteoriteBrick] = true;
			Main.tileLighted[TileID.MeteoriteBrick] = true;
			Main.tileShine[TileID.MeteoriteBrick] = 1900;
			Main.tileShine2[TileID.MeteoriteBrick] = true;
			Main.tileBrick[TileID.MeteoriteBrick] = true;
			Main.tileMergeDirt[TileID.MeteoriteBrick] = true;
			Main.tileContainer[TileID.Containers] = true;
			Main.tileContainer[TileID.Dressers] = true;
			Main.tileSign[TileID.Signs] = true;
			Main.tileSign[TileID.Tombstones] = true;
			Main.tileSolid[TileID.LivingMahogany] = true;
			Main.tileBrick[TileID.LivingMahogany] = true;
			Main.tileBlockLight[TileID.LivingMahogany] = true;
			Main.tileSolid[TileID.CrystalBlock] = true;
			Main.tileBrick[TileID.CrystalBlock] = true;
			Main.tileBlockLight[TileID.CrystalBlock] = true;
			Main.tileSolid[TileID.Sandstone] = true;
			Main.tileBlockLight[TileID.Sandstone] = true;
			Main.tileSolid[TileID.HardenedSand] = true;
			Main.tileBlockLight[TileID.HardenedSand] = true;
			Main.tileSolid[TileID.CrimsonHardenedSand] = true;
			Main.tileBlockLight[TileID.CrimsonHardenedSand] = true;
			Main.tileSolid[TileID.CrimsonSandstone] = true;
			Main.tileBlockLight[TileID.CrimsonSandstone] = true;
			Main.tileSolid[TileID.CorruptHardenedSand] = true;
			Main.tileBlockLight[TileID.CorruptHardenedSand] = true;
			Main.tileSolid[TileID.CorruptSandstone] = true;
			Main.tileBlockLight[TileID.CorruptSandstone] = true;
			Main.tileSolid[TileID.HallowHardenedSand] = true;
			Main.tileBlockLight[TileID.HallowHardenedSand] = true;
			Main.tileSolid[TileID.HallowSandstone] = true;
			Main.tileBlockLight[TileID.HallowSandstone] = true;
			Main.tileSolid[TileID.DesertFossil] = true;
			Main.tileBlockLight[TileID.DesertFossil] = true;
			Main.tileSolid[TileID.FossilOre] = true;
			Main.tileBlockLight[TileID.FossilOre] = true;
			Main.tileShine2[TileID.FossilOre] = true;
			Main.tileShine[TileID.FossilOre] = 1000;
			Main.tileFrameImportant[TileID.Presents] = true;
			Main.tileFrameImportant[TileID.BunnyCage] = true;
			Main.tileFrameImportant[TileID.SquirrelCage] = true;
			Main.tileFrameImportant[TileID.MallardDuckCage] = true;
			Main.tileFrameImportant[TileID.DuckCage] = true;
			Main.tileFrameImportant[TileID.BirdCage] = true;
			Main.tileFrameImportant[TileID.BlueJay] = true;
			Main.tileFrameImportant[TileID.CardinalCage] = true;
			Main.tileFrameImportant[TileID.FishBowl] = true;
			Main.tileFrameImportant[TileID.SnailCage] = true;
			Main.tileFrameImportant[TileID.GlowingSnailCage] = true;
			Main.tileFrameImportant[TileID.SquirrelGoldCage] = true;
			Main.tileFrameImportant[TileID.SquirrelOrangeCage] = true;
			Main.tileFrameImportant[TileID.PenguinCage] = true;
			Main.tileFrameImportant[TileID.WormCage] = true;
			Main.tileFrameImportant[TileID.GrasshopperCage] = true;
			Main.tileLighted[TileID.GlowingSnailCage] = true;
			Main.tileLighted[TileID.GlassKiln] = true;
			Main.tileFrameImportant[TileID.FrogCage] = true;
			Main.tileFrameImportant[TileID.MouseCage] = true;
			Main.tileSolid[TileID.PineTree] = true;
			Main.tileFrameImportant[TileID.ChristmasTree] = true;
			Main.tileLighted[TileID.ChristmasTree] = true;
			Main.tileFrameImportant[TileID.Autohammer] = true;
			Main.tileFrameImportant[TileID.Painting2X3] = true;
			Main.tileFrameImportant[TileID.Painting3X2] = true;
			Main.tileFrameImportant[TileID.MetalBars] = true;
			Main.tileFrameImportant[TileID.Painting3X3] = true;
			Main.tileFrameImportant[TileID.Painting4X3] = true;
			Main.tileFrameImportant[TileID.Painting6X4] = true;
			Main.tileFrameImportant[TileID.ImbuingStation] = true;
			Main.tileFrameImportant[TileID.BubbleMachine] = true;
			Main.tileFrameImportant[TileID.Pumpkins] = true;
			Main.tileSolid[TileID.Palladium] = true;
			Main.tileBlockLight[TileID.Palladium] = true;
			Main.tileMergeDirt[TileID.Palladium] = true;
			Main.tileLighted[TileID.CookingPots] = true;
			Main.tileMergeDirt[TileID.Titanstone] = true;
			Main.tileSolid[TileID.Cog] = true;
			Main.tileBlockLight[TileID.Cog] = true;
			Main.tileSolid[TileID.HoneyBlock] = true;
			Main.tileBlockLight[TileID.HoneyBlock] = true;
			Main.tileMergeDirt[TileID.HoneyBlock] = true;
			Main.tileSolid[TileID.CrispyHoneyBlock] = true;
			Main.tileBlockLight[TileID.CrispyHoneyBlock] = true;
			Main.tileMergeDirt[TileID.CrispyHoneyBlock] = true;
			Main.tileSolid[TileID.Orichalcum] = true;
			Main.tileBlockLight[TileID.Orichalcum] = true;
			Main.tileMergeDirt[TileID.Orichalcum] = true;
			Main.tileSolid[TileID.Titanium] = true;
			Main.tileBlockLight[TileID.Titanium] = true;
			Main.tileMergeDirt[TileID.Titanium] = true;
			Main.tileSolid[TileID.Slush] = true;
			Main.tileBlockLight[TileID.Slush] = true;
			Main.tileFrameImportant[TileID.LihzahrdAltar] = true;
			Main.tileFrameImportant[TileID.PlanteraBulb] = true;
			Main.tileSolid[TileID.Hive] = true;
			Main.tileBlockLight[TileID.Hive] = true;
			Main.tileBrick[TileID.Hive] = true;
			Main.tileSolid[TileID.LihzahrdBrick] = true;
			Main.tileBlockLight[TileID.LihzahrdBrick] = true;
			Main.tileBrick[TileID.LihzahrdBrick] = true;
			Main.tileSolid[TileID.Teleporter] = true;
			Main.tileBlockLight[TileID.Teleporter] = true;
			Main.tileFrameImportant[TileID.Teleporter] = true;
			Main.tileLighted[TileID.PlanteraBulb] = true;
			Main.tileFrameImportant[TileID.LifeFruit] = true;
			Main.tileCut[TileID.LifeFruit] = true;
			Main.tileSolid[TileID.LivingWood] = true;
			Main.tileBrick[TileID.LivingWood] = true;
			Main.tileBlockLight[TileID.LivingWood] = true;
			Main.tileSolid[TileID.Chlorophyte] = true;
			Main.tileBlockLight[TileID.Chlorophyte] = true;
			Main.tileSolid[TileID.Shadewood] = true;
			Main.tileBrick[TileID.Shadewood] = true;
			Main.tileBlockLight[TileID.Shadewood] = true;
			Main.tileSolid[TileID.LeafBlock] = true;
			Main.tileBrick[TileID.LeafBlock] = true;
			Main.tileBlockLight[TileID.LeafBlock] = true;
			Main.tileSolid[TileID.SlimeBlock] = true;
			Main.tileBrick[TileID.SlimeBlock] = true;
			Main.tileBlockLight[TileID.SlimeBlock] = true;
			Main.tileMergeDirt[TileID.SlimeBlock] = true;
			Main.tileSolid[TileID.BoneBlock] = true;
			Main.tileBrick[TileID.BoneBlock] = true;
			Main.tileBlockLight[TileID.BoneBlock] = true;
			Main.tileSolid[TileID.FleshBlock] = true;
			Main.tileBrick[TileID.FleshBlock] = true;
			Main.tileMergeDirt[TileID.FleshBlock] = true;
			Main.tileBlockLight[TileID.FleshBlock] = true;
			Main.tileBlockLight[TileID.FleshIce] = true;
			Main.tileSolid[TileID.FleshIce] = true;
			Main.tileBrick[TileID.FleshIce] = true;
			Main.tileBlockLight[TileID.Crimstone] = true;
			Main.tileSolid[TileID.Crimstone] = true;
			Main.tileMergeDirt[TileID.Crimstone] = true;
			Main.tileBlockLight[TileID.Crimtane] = true;
			Main.tileSolid[TileID.Crimtane] = true;
			Main.tileMergeDirt[TileID.Crimtane] = true;
			Main.tileBlockLight[TileID.Stalactite] = true;
			Main.tileShine2[TileID.SnowBlock] = true;
			Main.tileShine2[TileID.IceBlock] = true;
			Main.tileShine2[TileID.CorruptIce] = true;
			Main.tileShine2[TileID.HallowedIce] = true;
			Main.tileSolid[TileID.Cloud] = true;
			Main.tileBlockLight[TileID.Cobweb] = true;
			Main.tileLighted[TileID.Crimtane] = true;
			Main.tileShine[TileID.Crimtane] = 1150;
			Main.tileShine2[TileID.Crimtane] = true;
			Main.tileSolid[TileID.MushroomBlock] = true;
			Main.tileBlockLight[TileID.MushroomBlock] = true;
			Main.tileBrick[TileID.MushroomBlock] = true;
			Main.tileSolid[TileID.Asphalt] = true;
			Main.tileMergeDirt[TileID.Asphalt] = true;
			Main.tileBrick[TileID.Asphalt] = true;
			Main.tileBlockLight[TileID.Asphalt] = true;
			Main.tileSolid[TileID.IceBrick] = true;
			Main.tileBlockLight[TileID.IceBrick] = true;
			Main.tileMergeDirt[TileID.IceBrick] = true;
			Main.tileBrick[TileID.IceBrick] = true;
			Main.tileBlockLight[TileID.Crimsand] = true;
			Main.tileSolid[TileID.PalladiumColumn] = true;
			Main.tileSolid[TileID.BubblegumBlock] = true;
			Main.tileSolid[TileID.Titanstone] = true;
			Main.tileBrick[TileID.PalladiumColumn] = true;
			Main.tileBrick[TileID.BubblegumBlock] = true;
			Main.tileBrick[TileID.Titanstone] = true;
			Main.tileSolid[TileID.PumpkinBlock] = true;
			Main.tileSolid[TileID.HayBlock] = true;
			Main.tileBrick[TileID.HayBlock] = true;
			Main.tileSolid[TileID.SpookyWood] = true;
			Main.tileBrick[TileID.SpookyWood] = true;
			Main.tileMergeDirt[TileID.PumpkinBlock] = true;
			Main.tileMergeDirt[TileID.HayBlock] = true;
			Main.tileMergeDirt[TileID.SpookyWood] = true;
			Main.tileBlockLight[TileID.PumpkinBlock] = true;
			Main.tileBlockLight[TileID.HayBlock] = true;
			Main.tileBlockLight[TileID.SpookyWood] = true;
			Main.tileBlockLight[TileID.PalladiumColumn] = true;
			Main.tileBlockLight[TileID.BubblegumBlock] = true;
			Main.tileBlockLight[TileID.Titanstone] = true;
			Main.tileLargeFrames[TileID.StoneSlab] = 1;
			Main.tileSolid[TileID.StoneSlab] = true;
			Main.tileBlockLight[TileID.StoneSlab] = true;
			Main.tileLargeFrames[TileID.SandStoneSlab] = 1;
			Main.tileSolid[TileID.SandStoneSlab] = true;
			Main.tileBlockLight[TileID.SandStoneSlab] = true;
			for (int m = 255; m <= 268; m++)
			{
				Main.tileSolid[m] = true;
				if (m > 261)
				{
					Main.tileLighted[m] = true;
					Main.tileShine2[m] = true;
				}
			}
			Main.tileFrameImportant[TileID.Womannequin] = true;
			Main.tileFrameImportant[TileID.WeaponsRack] = true;
			Main.tileFrameImportant[TileID.LavaLamp] = true;
			Main.tileNoAttach[TileID.LavaLamp] = true;
			Main.tileLavaDeath[TileID.LavaLamp] = true;
			Main.tileLighted[TileID.LavaLamp] = true;
			Main.wallHouse[WallID.Confetti] = true;
			Main.wallHouse[WallID.ConfettiBlack] = true;
			Main.wallHouse[WallID.WhiteDynasty] = true;
			Main.wallHouse[WallID.BlueDynasty] = true;
			Main.wallHouse[WallID.ArcaneRunes] = true;
			Main.wallHouse[WallID.BorealWood] = true;
			Main.wallHouse[WallID.PalmWood] = true;
			Main.wallHouse[WallID.BorealWoodFence] = true;
			Main.wallHouse[WallID.PalmWoodFence] = true;
			Main.wallHouse[WallID.ShroomitePlating] = true;
			Main.wallHouse[WallID.MartianConduit] = true;
			Main.wallHouse[WallID.MeteoriteBrick] = true;
			for (int n = 153; n < 167; n++)
			{
				Main.wallHouse[n] = true;
			}
			Main.wallHouse[WallID.CopperPlating] = true;
			Main.wallHouse[WallID.StoneSlab] = true;
			Main.wallHouse[WallID.BorealWood] = true;
			Main.wallHouse[WallID.TinPlating] = true;
			Main.wallHouse[WallID.Confetti] = true;
			Main.wallHouse[WallID.BubbleWallpaper] = true;
			Main.wallHouse[WallID.CopperPipeWallpaper] = true;
			Main.wallHouse[WallID.DuckyWallpaper] = true;
			Main.wallHouse[WallID.Waterfall] = true;
			Main.wallHouse[WallID.Lavafall] = true;
			Main.wallHouse[WallID.Bone] = true;
			Main.wallHouse[WallID.Slime] = true;
			Main.wallHouse[WallID.LivingWood] = true;
			Main.wallHouse[WallID.DiscWall] = true;
			Main.wallHouse[WallID.Flesh] = true;
			Main.wallHouse[WallID.Stone] = true;
			Main.wallHouse[WallID.Wood] = true;
			Main.wallHouse[WallID.GrayBrick] = true;
			Main.wallHouse[WallID.RedBrick] = true;
			Main.wallHouse[WallID.GoldBrick] = true;
			Main.wallHouse[WallID.SilverBrick] = true;
			Main.wallHouse[WallID.CopperBrick] = true;
			Main.wallHouse[WallID.Dirt] = true;
			Main.wallHouse[WallID.BlueDungeon] = true;
			Main.wallHouse[WallID.GreenDungeon] = true;
			Main.wallHouse[WallID.PinkDungeon] = true;
			Main.wallHouse[WallID.ObsidianBrick] = true;
			Main.wallHouse[WallID.Glass] = true;
			Main.wallHouse[WallID.PearlstoneBrick] = true;
			Main.wallHouse[WallID.IridescentBrick] = true;
			Main.wallHouse[WallID.MudstoneBrick] = true;
			Main.wallHouse[WallID.CobaltBrick] = true;
			Main.wallHouse[WallID.MythrilBrick] = true;
			Main.wallHouse[WallID.Planked] = true;
			Main.wallHouse[WallID.CandyCane] = true;
			Main.wallHouse[WallID.GreenCandyCane] = true;
			Main.wallHouse[WallID.SnowBrick] = true;
			Main.wallHouse[WallID.AdamantiteBeam] = true;
			Main.wallHouse[WallID.DemoniteBrick] = true;
			Main.wallHouse[WallID.SandstoneBrick] = true;
			Main.wallHouse[WallID.EbonstoneBrick] = true;
			Main.wallHouse[WallID.RedStucco] = true;
			Main.wallHouse[WallID.YellowStucco] = true;
			Main.wallHouse[WallID.GreenStucco] = true;
			Main.wallHouse[WallID.Gray] = true;
			Main.wallHouse[WallID.Ebonwood] = true;
			Main.wallHouse[WallID.RichMaogany] = true;
			Main.wallHouse[WallID.Pearlwood] = true;
			Main.wallHouse[WallID.RainbowBrick] = true;
			Main.wallHouse[WallID.TinBrick] = true;
			Main.wallHouse[WallID.TungstenBrick] = true;
			Main.wallHouse[WallID.PlatinumBrick] = true;
			Main.wallHouse[WallID.LivingLeaf] = true;
			Main.wallHouse[WallID.Grass] = true;
			Main.wallHouse[WallID.Jungle] = true;
			Main.wallHouse[WallID.Flower] = true;
			Main.wallHouse[WallID.Cactus] = true;
			Main.wallHouse[WallID.Cloud] = true;
			Main.wallHouse[WallID.MetalFence] = true;
			Main.wallHouse[WallID.WoodenFence] = true;
			Main.wallHouse[WallID.PalladiumColumn] = true;
			Main.wallHouse[WallID.BubblegumBlock] = true;
			Main.wallHouse[WallID.TitanstoneBlock] = true;
			Main.wallHouse[WallID.LihzahrdBrick] = true;
			Main.wallHouse[WallID.Pumpkin] = true;
			Main.wallHouse[WallID.Hay] = true;
			Main.wallHouse[WallID.SpookyWood] = true;
			Main.wallHouse[WallID.ChristmasTreeWallpaper] = true;
			Main.wallHouse[WallID.OrnamentWallpaper] = true;
			Main.wallHouse[WallID.CandyCaneWallpaper] = true;
			Main.wallHouse[WallID.FestiveWallpaper] = true;
			Main.wallHouse[WallID.StarsWallpaper] = true;
			Main.wallHouse[WallID.SquigglesWallpaper] = true;
			Main.wallHouse[WallID.SnowflakeWallpaper] = true;
			Main.wallHouse[WallID.KrampusHornWallpaper] = true;
			Main.wallHouse[WallID.BluegreenWallpaper] = true;
			Main.wallHouse[WallID.GrinchFingerWallpaper] = true;
			Main.wallHouse[WallID.Hive] = true;
			Main.wallHouse[WallID.BlueDungeonSlab] = true;
			Main.wallHouse[WallID.BlueDungeonTile] = true;
			Main.wallHouse[WallID.PinkDungeonSlab] = true;
			Main.wallHouse[WallID.PinkDungeonTile] = true;
			Main.wallHouse[WallID.GreenDungeonSlab] = true;
			Main.wallHouse[WallID.GreenDungeonTile] = true;
			Main.wallHouse[WallID.IceBrick] = true;
			Main.wallHouse[WallID.Mushroom] = true;
			Main.wallHouse[WallID.Shadewood] = true;
			Main.wallHouse[WallID.PurpleStainedGlass] = true;
			Main.wallHouse[WallID.YellowStainedGlass] = true;
			Main.wallHouse[WallID.BlueStainedGlass] = true;
			Main.wallHouse[WallID.GreenStainedGlass] = true;
			Main.wallHouse[WallID.RedStainedGlass] = true;
			Main.wallHouse[WallID.RainbowStainedGlass] = true;
			Main.wallHouse[WallID.FancyGrayWallpaper] = true;
			Main.wallHouse[WallID.IceFloeWallpaper] = true;
			Main.wallHouse[WallID.MusicWallpaper] = true;
			Main.wallHouse[WallID.PurpleRainWallpaper] = true;
			Main.wallHouse[WallID.RainbowWallpaper] = true;
			Main.wallHouse[WallID.SparkleStoneWallpaper] = true;
			Main.wallHouse[WallID.StarlitHeavenWallpaper] = true;
			Main.wallHouse[WallID.EbonwoodFence] = true;
			Main.wallHouse[WallID.RichMahoganyFence] = true;
			Main.wallHouse[WallID.PearlwoodFence] = true;
			Main.wallHouse[WallID.ShadewoodFence] = true;
			Main.wallHouse[WallID.HellstoneBrick] = true;
			Main.wallHouse[WallID.Honeyfall] = true;
			Main.wallHouse[WallID.CrimtaneBrick] = true;
			Main.wallHouse[WallID.DesertFossil] = true;
			Main.wallLight[WallID.None] = true;
			Main.wallLight[WallID.Glass] = true;
			Main.wallLight[WallID.WoodenFence] = true;
			Main.wallLight[WallID.MetalFence] = true;
			Main.wallLight[WallID.EbonwoodFence] = true;
			Main.wallLight[WallID.PearlwoodFence] = true;
			Main.wallLight[WallID.ShadewoodFence] = true;
			Main.wallLight[WallID.RichMahoganyFence] = true;
			Main.wallLight[WallID.IronFence] = true;
			Main.wallLight[WallID.BorealWoodFence] = true;
			Main.wallLight[WallID.PalmWoodFence] = true;
			Main.wallLight[WallID.Confetti] = true;
			for (int o = 0; o < 225; o++)
			{
				Main.wallDungeon[o] = false;
			}
			Main.wallDungeon[WallID.BlueDungeonUnsafe] = true;
			Main.wallDungeon[WallID.GreenDungeonUnsafe] = true;
			Main.wallDungeon[WallID.PinkDungeonUnsafe] = true;
			Main.wallDungeon[WallID.BlueDungeonSlabUnsafe] = true;
			Main.wallDungeon[WallID.BlueDungeonTileUnsafe] = true;
			Main.wallDungeon[WallID.PinkDungeonSlabUnsafe] = true;
			Main.wallDungeon[WallID.PinkDungeonTileUnsafe] = true;
			Main.wallDungeon[WallID.GreenDungeonSlabUnsafe] = true;
			Main.wallDungeon[WallID.GreenDungeonTileUnsafe] = true;
			for (int p = 0; p < 10; p++)
			{
				Main.recentWorld[p] = "";
				Main.recentIP[p] = "";
				Main.recentPort[p] = 0;
			}
			if (Main.rand == null)
			{
				Main.rand = new Random((int)DateTime.Now.Ticks);
			}
			if (WorldGen.genRand == null)
			{
				WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
			}
			this.SetTitle();
			Main.lo = Main.rand.Next(6);
			Main.critterCage = true;
			for (int q = 0; q < 3600; q++)
			{
				Main.CritterCages();
			}
			Main.critterCage = false;
			Main.tileBrick[TileID.Stone] = true;
			Main.tileBrick[TileID.Glass] = true;
			Main.tileBrick[TileID.PearlstoneBrick] = true;
			Main.tileBrick[TileID.IridescentBrick] = true;
			Main.tileBrick[TileID.Mudstone] = true;
			Main.tileBrick[TileID.CobaltBrick] = true;
			Main.tileBrick[TileID.MythrilBrick] = true;
			Main.tileBrick[TileID.DemoniteBrick] = true;
			Main.tileBrick[TileID.SnowBrick] = true;
			Main.tileBrick[TileID.AdamantiteBeam] = true;
			Main.tileBrick[TileID.SandstoneBrick] = true;
			Main.tileBrick[TileID.EbonstoneBrick] = true;
			Main.tileBrick[TileID.WoodBlock] = true;
			Main.tileBrick[TileID.GrayBrick] = true;
			Main.tileBrick[TileID.RedBrick] = true;
			Main.tileBrick[TileID.BlueDungeonBrick] = true;
			Main.tileBrick[TileID.GreenDungeonBrick] = true;
			Main.tileBrick[TileID.PinkDungeonBrick] = true;
			Main.tileBrick[TileID.GoldBrick] = true;
			Main.tileBrick[TileID.SilverBrick] = true;
			Main.tileBrick[TileID.CopperBrick] = true;
			Main.tileBrick[TileID.ObsidianBrick] = true;
			Main.tileBrick[TileID.HellstoneBrick] = true;
			Main.tileBrick[TileID.RainbowBrick] = true;
			Main.tileBrick[TileID.Grass] = true;
			Main.tileBrick[TileID.FleshGrass] = true;
			Main.tileBrick[TileID.CorruptGrass] = true;
			Main.tileBrick[TileID.JungleGrass] = true;
			Main.tileBrick[TileID.MushroomGrass] = true;
			Main.tileBrick[TileID.HallowedGrass] = true;
			Main.tileBrick[TileID.Sand] = true;
			Main.tileBrick[TileID.Pearlsand] = true;
			Main.tileBrick[TileID.Crimsand] = true;
			Main.tileBrick[TileID.Ebonsand] = true;
			Main.tileBrick[TileID.SnowBlock] = true;
			Main.tileBrick[TileID.RedStucco] = true;
			Main.tileBrick[TileID.YellowStucco] = true;
			Main.tileBrick[TileID.GreenStucco] = true;
			Main.tileBrick[TileID.GrayStucco] = true;
			Main.tileBrick[TileID.Ebonwood] = true;
			Main.tileBrick[TileID.RichMahogany] = true;
			Main.tileBrick[TileID.Pearlwood] = true;
			Main.tileMergeDirt[TileID.Sunplate] = true;
			Main.tileBrick[TileID.Sunplate] = true;
			Main.tileSolid[TileID.Sunplate] = true;
			Main.tileBlockLight[TileID.Sunplate] = true;
			Main.tileBrick[TileID.IceBlock] = true;
			Main.tileBlockLight[TileID.IceBlock] = true;
			Main.tileBlockLight[TileID.CorruptIce] = true;
			Main.tileBlockLight[TileID.HallowedIce] = true;
			Main.tileSolid[TileID.CactusBlock] = true;
			Main.tileBlockLight[TileID.CactusBlock] = true;
			Main.tileBrick[TileID.CactusBlock] = true;
			Main.tileMergeDirt[TileID.CactusBlock] = true;
			Main.tileBrick[TileID.GreenMoss] = true;
			Main.tileSolid[TileID.GreenMoss] = true;
			Main.tileBlockLight[TileID.GreenMoss] = true;
			Main.tileMoss[TileID.GreenMoss] = true;
			Main.tileBrick[TileID.LavaMoss] = true;
			Main.tileSolid[TileID.LavaMoss] = true;
			Main.tileBlockLight[TileID.LavaMoss] = true;
			Main.tileMoss[TileID.LavaMoss] = true;
			Main.tileBrick[TileID.BrownMoss] = true;
			Main.tileSolid[TileID.BrownMoss] = true;
			Main.tileBlockLight[TileID.BrownMoss] = true;
			Main.tileMoss[TileID.BrownMoss] = true;
			Main.tileBrick[TileID.RedMoss] = true;
			Main.tileSolid[TileID.RedMoss] = true;
			Main.tileBlockLight[TileID.RedMoss] = true;
			Main.tileMoss[TileID.RedMoss] = true;
			Main.tileBrick[TileID.BlueMoss] = true;
			Main.tileSolid[TileID.BlueMoss] = true;
			Main.tileBlockLight[TileID.BlueMoss] = true;
			Main.tileMoss[TileID.BlueMoss] = true;
			Main.tileBrick[TileID.PurpleMoss] = true;
			Main.tileSolid[TileID.PurpleMoss] = true;
			Main.tileBlockLight[TileID.PurpleMoss] = true;
			Main.tileMoss[TileID.PurpleMoss] = true;
			Main.tileMergeDirt[TileID.PlatinumBrick] = true;
			Main.tileMergeDirt[TileID.MushroomBlock] = true;
			Main.tileSolid[TileID.RainCloud] = true;
			Main.tileSolid[TileID.FrozenSlimeBlock] = true;
			Main.tileMergeDirt[TileID.FrozenSlimeBlock] = true;
			Main.tileBlockLight[TileID.FrozenSlimeBlock] = true;
			Main.tileNoSunLight[TileID.FrozenSlimeBlock] = true;
			Main.tileBrick[TileID.TinBrick] = true;
			Main.tileSolid[TileID.TinBrick] = true;
			Main.tileBlockLight[TileID.TinBrick] = true;
			Main.tileBrick[TileID.TungstenBrick] = true;
			Main.tileSolid[TileID.TungstenBrick] = true;
			Main.tileBlockLight[TileID.TungstenBrick] = true;
			Main.tileBrick[TileID.PlatinumBrick] = true;
			Main.tileSolid[TileID.PlatinumBrick] = true;
			Main.tileBlockLight[TileID.PlatinumBrick] = true;
			Main.tileBrick[TileID.Hive] = true;
			Main.tileBrick[TileID.HoneyBlock] = true;
			Main.tileShine[TileID.Palladium] = 925;
			Main.tileShine[TileID.Orichalcum] = 875;
			Main.tileShine[TileID.Titanium] = 825;
			Main.tileShine2[TileID.Palladium] = true;
			Main.tileShine2[TileID.Orichalcum] = true;
			Main.tileShine2[TileID.Titanium] = true;
			Main.tileMergeDirt[TileID.TinBrick] = true;
			Main.tileMergeDirt[TileID.TungstenBrick] = true;
			Main.tileMergeDirt[TileID.PlatinumBrick] = true;
			Main.tileMergeDirt[TileID.Shadewood] = true;
			Main.tileBrick[TileID.BreakableIce] = true;
			Main.tileSolid[TileID.BreakableIce] = true;
			Main.tileBlockLight[TileID.BreakableIce] = false;
			Main.tileBrick[TileID.CorruptIce] = true;
			Main.tileSolid[TileID.CorruptIce] = true;
			Main.tileBrick[TileID.HallowedIce] = true;
			Main.tileSolid[TileID.HallowedIce] = true;
			Main.tileShine2[TileID.Iron] = true;
			Main.tileShine2[TileID.Copper] = true;
			Main.tileShine2[TileID.Gold] = true;
			Main.tileShine2[TileID.Silver] = true;
			Main.tileShine2[TileID.Tin] = true;
			Main.tileShine2[TileID.Lead] = true;
			Main.tileShine2[TileID.Tungsten] = true;
			Main.tileShine2[TileID.Platinum] = true;
			Main.tileShine2[TileID.Heart] = true;
			Main.tileShine2[TileID.Containers] = true;
			Main.tileShine2[TileID.Demonite] = true;
			Main.tileShine2[TileID.Ebonstone] = true;
			Main.tileShine2[TileID.GoldBrick] = true;
			Main.tileShine2[TileID.SilverBrick] = true;
			Main.tileShine2[TileID.CopperBrick] = true;
			Main.tileShine2[TileID.Sapphire] = true;
			Main.tileShine2[TileID.Ruby] = true;
			Main.tileShine2[TileID.Emerald] = true;
			Main.tileShine2[TileID.Topaz] = true;
			Main.tileShine2[TileID.Amethyst] = true;
			Main.tileShine2[TileID.Diamond] = true;
			Main.tileShine2[TileID.Cobalt] = true;
			Main.tileShine2[TileID.Mythril] = true;
			Main.tileShine2[TileID.Adamantite] = true;
			Main.tileShine2[TileID.CobaltBrick] = true;
			Main.tileShine2[TileID.MythrilBrick] = true;
			Main.tileShine2[TileID.Pearlstone] = true;
			Main.tileShine2[TileID.Chlorophyte] = true;
			Main.tileShine[TileID.Crystals] = 300;
			Main.tileNoFail[TileID.CopperCoinPile] = true;
			Main.tileNoFail[TileID.SilverCoinPile] = true;
			Main.tileNoFail[TileID.GoldCoinPile] = true;
			Main.tileNoFail[TileID.PlatinumCoinPile] = true;
			Main.tileNoFail[TileID.Crystals] = true;
			Main.tileNoFail[TileID.LeafBlock] = true;
			Main.tileHammer[TileID.DemonAltar] = true;
			Main.tileHammer[TileID.ShadowOrbs] = true;
			Main.tileAxe[TileID.Trees] = true;
			Main.tileAxe[TileID.MushroomTrees] = true;
			Main.tileAxe[TileID.Cactus] = true;
			Main.tileAxe[TileID.PalmTree] = true;
			Main.tileBrick[TileID.Mud] = true;
			Main.tileBrick[TileID.Crimsand] = true;
			Main.tileSolid[TileID.Crimsand] = true;
			Main.tileMergeDirt[TileID.Crimsand] = true;
			Main.tileSand[TileID.Sand] = true;
			Main.tileSand[TileID.Ebonsand] = true;
			Main.tileSand[TileID.Pearlsand] = true;
			Main.tileSand[TileID.Crimsand] = true;
			Main.tileFrameImportant[TileID.PlantDetritus] = true;
			Main.tileLighted[TileID.Campfire] = true;
			Main.tileFrameImportant[TileID.DyePlants] = true;
			Main.tileFrameImportant[TileID.DyeVat] = true;
			Main.tileFrameImportant[TileID.Larva] = true;
			Main.tileCut[TileID.Larva] = true;
			Main.tileFrameImportant[TileID.Firework] = true;
			Main.tileFrameImportant[TileID.Blendomatic] = true;
			Main.tileFrameImportant[TileID.MeatGrinder] = true;
			Main.tileFrameImportant[TileID.Extractinator] = true;
			Main.tileFrameImportant[TileID.Solidifier] = true;
			Main.tileFrameImportant[TileID.FireworkFountain] = true;
			Main.tileFrameImportant[TileID.Stalactite] = true;
			Main.tileFrameImportant[TileID.Cannon] = true;
			Main.tileFrameImportant[TileID.Campfire] = true;
			Main.tileFrameImportant[TileID.LandMine] = true;
			Main.tileFrameImportant[TileID.SnowballLauncher] = true;
			Main.tileFrameImportant[TileID.WaterFountain] = true;
			Main.tileFrameImportant[TileID.ExposedGems] = true;
			Main.tileFrameImportant[TileID.LongMoss] = true;
			Main.tileFrameImportant[TileID.SmallPiles] = true;
			Main.tileFrameImportant[TileID.LargePiles] = true;
			Main.tileFrameImportant[TileID.LargePiles2] = true;
			Main.tileFrameImportant[TileID.PlatinumCandelabra] = true;
			Main.tileFrameImportant[TileID.PlatinumCandle] = true;
			Main.tileLighted[TileID.PlatinumCandelabra] = true;
			Main.tileLighted[TileID.PlatinumCandle] = true;
			Main.tileFrameImportant[TileID.MusicBoxes] = true;
			Main.tileLighted[TileID.RainbowBrick] = true;
			Main.tileLighted[TileID.HolidayLights] = true;
			Main.tileFrameImportant[TileID.HolidayLights] = true;
			Main.tileFrameImportant[TileID.InletPump] = true;
			Main.tileFrameImportant[TileID.OutletPump] = true;
			Main.tileFrameImportant[TileID.Timers] = true;
			Main.tileStone[TileID.InactiveStoneBlock] = true;
			Main.tileFrameImportant[TileID.Switches] = true;
			Main.tileFrameImportant[TileID.Traps] = true;
			Main.tileFrameImportant[TileID.Boulder] = true;
			Main.tileBlockLight[TileID.Traps] = true;
			Main.tileSolid[TileID.Traps] = true;
			Main.tileBlockLight[TileID.RainbowBrick] = true;
			Main.tileSolid[TileID.RainbowBrick] = true;
			Main.tileMergeDirt[TileID.RainbowBrick] = true;
			Main.tileBlockLight[TileID.IceBlock] = true;
			Main.tileSolid[TileID.IceBlock] = true;
			Main.tileBlockLight[TileID.CandyCaneBlock] = true;
			Main.tileSolid[TileID.CandyCaneBlock] = true;
			Main.tileMergeDirt[TileID.CandyCaneBlock] = true;
			Main.tileBlockLight[TileID.GreenCandyCaneBlock] = true;
			Main.tileSolid[TileID.GreenCandyCaneBlock] = true;
			Main.tileMergeDirt[TileID.GreenCandyCaneBlock] = true;
			Main.tileBlockLight[TileID.SnowBlock] = true;
			Main.tileSolid[TileID.SnowBlock] = true;
			Main.tileBlockLight[TileID.SnowBrick] = true;
			Main.tileSolid[TileID.SnowBrick] = true;
			Main.tileMergeDirt[TileID.SnowBrick] = true;
			Main.tileBlockLight[TileID.Boulder] = true;
			Main.tileSolid[TileID.Boulder] = true;
			Main.tileBlockLight[TileID.DemoniteBrick] = true;
			Main.tileSolid[TileID.DemoniteBrick] = true;
			Main.tileBlockLight[TileID.SandstoneBrick] = true;
			Main.tileSolid[TileID.SandstoneBrick] = true;
			Main.tileMergeDirt[TileID.SandstoneBrick] = true;
			Main.tileBlockLight[TileID.EbonstoneBrick] = true;
			Main.tileSolid[TileID.EbonstoneBrick] = true;
			Main.tileMergeDirt[TileID.EbonstoneBrick] = true;
			Main.tileBlockLight[TileID.RedStucco] = true;
			Main.tileSolid[TileID.RedStucco] = true;
			Main.tileMergeDirt[TileID.RedStucco] = true;
			Main.tileBlockLight[TileID.YellowStucco] = true;
			Main.tileSolid[TileID.YellowStucco] = true;
			Main.tileMergeDirt[TileID.YellowStucco] = true;
			Main.tileBlockLight[TileID.GreenStucco] = true;
			Main.tileSolid[TileID.GreenStucco] = true;
			Main.tileMergeDirt[TileID.GreenStucco] = true;
			Main.tileBlockLight[TileID.GrayStucco] = true;
			Main.tileSolid[TileID.GrayStucco] = true;
			Main.tileMergeDirt[TileID.GrayStucco] = true;
			Main.tileMergeDirt[TileID.AdamantiteBeam] = true;
			Main.tileBlockLight[TileID.Ebonwood] = true;
			Main.tileSolid[TileID.Ebonwood] = true;
			Main.tileMergeDirt[TileID.Ebonwood] = true;
			Main.tileBlockLight[TileID.RichMahogany] = true;
			Main.tileSolid[TileID.RichMahogany] = true;
			Main.tileMergeDirt[TileID.RichMahogany] = true;
			Main.tileBlockLight[TileID.Pearlwood] = true;
			Main.tileSolid[TileID.Pearlwood] = true;
			Main.tileMergeDirt[TileID.Pearlwood] = true;
			Main.tileFrameImportant[TileID.SeaweedPlanter] = true;
			Main.tileShine[TileID.Demonite] = 1150;
			Main.tileShine[TileID.Iron] = 1150;
			Main.tileShine[TileID.Copper] = 1100;
			Main.tileShine[TileID.Gold] = 1000;
			Main.tileShine[TileID.Silver] = 1050;
			Main.tileShine[TileID.Tin] = 1125;
			Main.tileShine[TileID.Lead] = 1075;
			Main.tileShine[TileID.Tungsten] = 1025;
			Main.tileShine[TileID.Platinum] = 975;
			Main.tileShine[TileID.ExposedGems] = 500;
			Main.tileShine2[TileID.ExposedGems] = true;
			Main.tileShine[TileID.Heart] = 300;
			Main.tileShine[TileID.Containers] = 1200;
			Main.tileShine[TileID.Sapphire] = 900;
			Main.tileShine[TileID.Ruby] = 900;
			Main.tileShine[TileID.Emerald] = 900;
			Main.tileShine[TileID.Topaz] = 900;
			Main.tileShine[TileID.Amethyst] = 900;
			Main.tileShine[TileID.Diamond] = 900;
			Main.tileShine[TileID.GoldBrick] = 1900;
			Main.tileShine[TileID.SilverBrick] = 2000;
			Main.tileShine[TileID.CopperBrick] = 2100;
			Main.tileShine[TileID.MythrilBrick] = 1800;
			Main.tileShine[TileID.CobaltBrick] = 1850;
			Main.tileShine[TileID.CrystalBall] = 600;
			Main.tileShine[TileID.HallowedGrass] = 9000;
			Main.tileShine[TileID.HallowedPlants] = 9000;
			Main.tileShine[TileID.Pearlsand] = 9000;
			Main.tileShine[TileID.Pearlstone] = 9000;
			Main.tileShine[TileID.PearlstoneBrick] = 8000;
			Main.tileShine[TileID.Cobalt] = 950;
			Main.tileShine[TileID.Mythril] = 900;
			Main.tileShine[TileID.Adamantite] = 850;
			Main.tileShine[TileID.Chlorophyte] = 800;
			Main.tileLighted[TileID.Torches] = true;
			Main.tileLighted[TileID.Furnaces] = true;
			Main.tileLighted[TileID.AdamantiteForge] = true;
			Main.tileLighted[TileID.ShadowOrbs] = true;
			Main.tileLighted[TileID.Candles] = true;
			Main.tileLighted[TileID.Chandeliers] = true;
			Main.tileLighted[TileID.Jackolanterns] = true;
			Main.tileLighted[TileID.Meteorite] = true;
			Main.tileLighted[TileID.HangingLanterns] = true;
			Main.tileLighted[TileID.WaterCandle] = true;
			Main.tileLighted[TileID.Hellstone] = true;
			Main.tileLighted[TileID.JunglePlants] = true;
			Main.tileLighted[TileID.MushroomGrass] = true;
			Main.tileLighted[TileID.MushroomPlants] = true;
			Main.tileLighted[TileID.MushroomTrees] = true;
			Main.tileLighted[TileID.HellstoneBrick] = true;
			Main.tileLighted[TileID.Hellforge] = true;
			Main.tileLighted[TileID.Platforms] = true;
			Main.tileLighted[TileID.Demonite] = true;
			Main.tileLighted[TileID.DemonAltar] = true;
			Main.tileLighted[TileID.MatureHerbs] = true;
			Main.tileLighted[TileID.BloomingHerbs] = true;
			Main.tileLighted[TileID.Lampposts] = true;
			Main.tileLighted[TileID.Lamps] = true;
			Main.tileLighted[TileID.ChineseLanterns] = true;
			Main.tileLighted[TileID.SkullLanterns] = true;
			Main.tileLighted[TileID.Candelabras] = true;
			Main.tileLighted[TileID.HallowedGrass] = true;
			Main.tileLighted[TileID.CrystalBall] = true;
			Main.tileLighted[TileID.DiscoBall] = true;
			Main.tileLighted[TileID.Crystals] = true;
			Main.tileLighted[TileID.DemoniteBrick] = true;
			Main.tileLighted[TileID.FireflyinaBottle] = true;
			Main.tileLighted[TileID.LightningBuginaBottle] = true;
			Main.tileMergeDirt[TileID.Stone] = true;
			Main.tileMergeDirt[TileID.Iron] = true;
			Main.tileMergeDirt[TileID.Copper] = true;
			Main.tileMergeDirt[TileID.Gold] = true;
			Main.tileMergeDirt[TileID.Silver] = true;
			Main.tileMergeDirt[TileID.Tin] = true;
			Main.tileMergeDirt[TileID.Lead] = true;
			Main.tileMergeDirt[TileID.Tungsten] = true;
			Main.tileMergeDirt[TileID.Platinum] = true;
			Main.tileMergeDirt[TileID.Demonite] = true;
			Main.tileMergeDirt[TileID.Ebonstone] = true;
			Main.tileMergeDirt[TileID.WoodBlock] = true;
			Main.tileMergeDirt[TileID.Meteorite] = true;
			Main.tileMergeDirt[TileID.GrayBrick] = true;
			Main.tileMergeDirt[TileID.ClayBlock] = true;
			Main.tileMergeDirt[TileID.Sand] = true;
			Main.tileMergeDirt[TileID.Obsidian] = true;
			Main.tileMergeDirt[TileID.Cobalt] = true;
			Main.tileMergeDirt[TileID.Mythril] = true;
			Main.tileMergeDirt[TileID.Adamantite] = true;
			Main.tileMergeDirt[TileID.Ebonsand] = true;
			Main.tileMergeDirt[TileID.Pearlsand] = true;
			Main.tileMergeDirt[TileID.Pearlstone] = true;
			Main.tileMergeDirt[TileID.Silt] = true;
			Main.tileMergeDirt[TileID.DemoniteBrick] = true;
			Main.tileMergeDirt[TileID.RedBrick] = true;
			Main.tileMergeDirt[TileID.MythrilBrick] = true;
			Main.tileMergeDirt[TileID.CobaltBrick] = true;
			Main.tileMergeDirt[TileID.Mudstone] = true;
			Main.tileMergeDirt[TileID.IridescentBrick] = true;
			Main.tileMergeDirt[TileID.PearlstoneBrick] = true;
			Main.tileMergeDirt[TileID.CopperBrick] = true;
			Main.tileMergeDirt[TileID.SilverBrick] = true;
			Main.tileMergeDirt[TileID.GoldBrick] = true;
			Main.tileMergeDirt[TileID.PinkDungeonBrick] = true;
			Main.tileMergeDirt[TileID.GreenDungeonBrick] = true;
			Main.tileMergeDirt[TileID.BlueDungeonBrick] = true;
			Main.tileFrameImportant[TileID.PlanterBox] = true;
			Main.tileFrameImportant[TileID.FleshWeeds] = true;
			Main.tileFrameImportant[TileID.Plants] = true;
			Main.tileFrameImportant[TileID.Torches] = true;
			Main.tileFrameImportant[TileID.Trees] = true;
			Main.tileFrameImportant[TileID.ClosedDoor] = true;
			Main.tileFrameImportant[TileID.OpenDoor] = true;
			Main.tileFrameImportant[TileID.Heart] = true;
			Main.tileFrameImportant[TileID.Bottles] = true;
			Main.tileFrameImportant[TileID.Tables] = true;
			Main.tileFrameImportant[TileID.Chairs] = true;
			Main.tileFrameImportant[TileID.Anvils] = true;
			Main.tileFrameImportant[TileID.Furnaces] = true;
			Main.tileFrameImportant[TileID.WorkBenches] = true;
			Main.tileFrameImportant[TileID.Platforms] = true;
			Main.tileFrameImportant[TileID.Saplings] = true;
			Main.tileFrameImportant[TileID.Containers] = true;
			Main.tileFrameImportant[TileID.CorruptPlants] = true;
			Main.tileFrameImportant[TileID.DemonAltar] = true;
			Main.tileFrameImportant[TileID.Sunflower] = true;
			Main.tileFrameImportant[TileID.Pots] = true;
			Main.tileFrameImportant[TileID.PiggyBank] = true;
			Main.tileFrameImportant[TileID.ShadowOrbs] = true;
			Main.tileFrameImportant[TileID.Candles] = true;
			Main.tileFrameImportant[TileID.Chandeliers] = true;
			Main.tileFrameImportant[TileID.Jackolanterns] = true;
			Main.tileFrameImportant[TileID.HangingLanterns] = true;
			Main.tileFrameImportant[TileID.Books] = true;
			Main.tileFrameImportant[TileID.Signs] = true;
			Main.tileFrameImportant[TileID.JunglePlants] = true;
			Main.tileFrameImportant[TileID.MushroomPlants] = true;
			Main.tileFrameImportant[TileID.MushroomTrees] = true;
			Main.tileFrameImportant[TileID.Plants2] = true;
			Main.tileFrameImportant[TileID.JunglePlants2] = true;
			Main.tileFrameImportant[TileID.Hellforge] = true;
			Main.tileFrameImportant[TileID.ClayPot] = true;
			Main.tileFrameImportant[TileID.Beds] = true;
			Main.tileFrameImportant[TileID.Coral] = true;
			Main.tileFrameImportant[TileID.ImmatureHerbs] = true;
			Main.tileFrameImportant[TileID.MatureHerbs] = true;
			Main.tileFrameImportant[TileID.BloomingHerbs] = true;
			Main.tileFrameImportant[TileID.Tombstones] = true;
			Main.tileFrameImportant[TileID.Loom] = true;
			Main.tileFrameImportant[TileID.Pianos] = true;
			Main.tileFrameImportant[TileID.Dressers] = true;
			Main.tileFrameImportant[TileID.Benches] = true;
			Main.tileFrameImportant[TileID.Bathtubs] = true;
			Main.tileFrameImportant[TileID.Banners] = true;
			Main.tileFrameImportant[TileID.Lampposts] = true;
			Main.tileFrameImportant[TileID.Lamps] = true;
			Main.tileFrameImportant[TileID.Kegs] = true;
			Main.tileFrameImportant[TileID.ChineseLanterns] = true;
			Main.tileFrameImportant[TileID.CookingPots] = true;
			Main.tileFrameImportant[TileID.Safes] = true;
			Main.tileFrameImportant[TileID.SkullLanterns] = true;
			Main.tileFrameImportant[TileID.TrashCan] = true;
			Main.tileFrameImportant[TileID.Bookcases] = true;
			Main.tileFrameImportant[TileID.Thrones] = true;
			Main.tileFrameImportant[TileID.Bowls] = true;
			Main.tileFrameImportant[TileID.GrandfatherClocks] = true;
			Main.tileFrameImportant[TileID.Statues] = true;
			Main.tileFrameImportant[TileID.Candelabras] = true;
			Main.tileFrameImportant[TileID.Sawmill] = true;
			Main.tileFrameImportant[TileID.HallowedPlants] = true;
			Main.tileFrameImportant[TileID.HallowedPlants2] = true;
			Main.tileFrameImportant[TileID.TinkerersWorkbench] = true;
			Main.tileFrameImportant[TileID.CrystalBall] = true;
			Main.tileFrameImportant[TileID.AmmoBox] = true;
			Main.tileFrameImportant[TileID.DiscoBall] = true;
			Main.tileFrameImportant[TileID.Mannequin] = true;
			Main.tileFrameImportant[TileID.Crystals] = true;
			Main.tileFrameImportant[TileID.Lever] = true;
			Main.tileFrameImportant[TileID.AdamantiteForge] = true;
			Main.tileFrameImportant[TileID.MythrilAnvil] = true;
			Main.tileFrameImportant[TileID.PressurePlates] = true;
			Main.tileFrameImportant[TileID.Sinks] = true;
			Main.tileFrameImportant[TileID.ShipInABottle] = true;
			Main.tileFrameImportant[TileID.PalmTree] = true;
			Main.tileFrameImportant[TileID.FireworksBox] = true;
			Main.tileFrameImportant[TileID.AlphabetStatues] = true;
			Main.tileFrameImportant[TileID.MushroomStatue] = true;
			Main.tileFrameImportant[TileID.FishingCrate] = true;
			Main.tileFrameImportant[TileID.TargetDummy] = true;
			Main.tileFrameImportant[TileID.Explosives] = true;
			Main.tileFrameImportant[TileID.FireflyinaBottle] = true;
			Main.tileFrameImportant[TileID.LightningBuginaBottle] = true;
			Main.tileFrameImportant[TileID.MinecartTrack] = true;
			Main.tileSolidTop[TileID.FishingCrate] = true;
			Main.tileTable[TileID.FishingCrate] = true;
			Main.tileTable[TileID.PlanterBox] = true;
			Main.tileCut[TileID.FleshWeeds] = true;
			Main.tileCut[TileID.Plants] = true;
			Main.tileCut[TileID.CorruptPlants] = true;
			Main.tileCut[TileID.Pots] = true;
			Main.tileCut[TileID.CorruptThorns] = true;
			Main.tileCut[TileID.Cobweb] = true;
			Main.tileCut[TileID.Vines] = true;
			Main.tileCut[TileID.JunglePlants] = true;
			Main.tileCut[TileID.JungleVines] = true;
			Main.tileCut[TileID.JungleThorns] = true;
			Main.tileCut[TileID.MushroomPlants] = true;
			Main.tileCut[TileID.Plants2] = true;
			Main.tileCut[TileID.JunglePlants2] = true;
			Main.tileCut[TileID.ImmatureHerbs] = true;
			Main.tileCut[TileID.MatureHerbs] = true;
			Main.tileCut[TileID.BloomingHerbs] = true;
			Main.tileCut[TileID.HallowedPlants] = true;
			Main.tileCut[TileID.HallowedPlants2] = true;
			Main.tileCut[TileID.HallowedVines] = true;
			Main.tileCut[TileID.LongMoss] = true;
			Main.tileCut[TileID.CrimsonVines] = true;
			Main.tileCut[TileID.CrimtaneThorns] = true;
			Main.tileCut[TileID.VineFlowers] = true;
			Main.tileAlch[TileID.ImmatureHerbs] = true;
			Main.tileAlch[TileID.MatureHerbs] = true;
			Main.tileAlch[TileID.BloomingHerbs] = true;
			Main.tileSolid[TileID.MagicalIceBlock] = true;
			Main.tileSolid[TileID.ActiveStoneBlock] = true;
			Main.tileBlockLight[TileID.ActiveStoneBlock] = true;
			Main.tileBlockLight[TileID.InactiveStoneBlock] = true;
			Main.tileNoAttach[TileID.WoodenSpikes] = true;
			Main.tileSolid[TileID.Cobalt] = true;
			Main.tileBlockLight[TileID.Cobalt] = true;
			Main.tileSolid[TileID.Mythril] = true;
			Main.tileBlockLight[TileID.Mythril] = true;
			Main.tileSolid[TileID.Adamantite] = true;
			Main.tileBlockLight[TileID.Adamantite] = true;
			Main.tileSolid[TileID.HallowedGrass] = true;
			Main.tileBlockLight[TileID.HallowedGrass] = true;
			Main.tileSolid[TileID.HallowedPlants] = false;
			Main.tileNoAttach[TileID.HallowedPlants] = true;
			Main.tileNoFail[TileID.HallowedPlants] = true;
			Main.tileSolid[TileID.Ebonsand] = true;
			Main.tileBlockLight[TileID.Ebonsand] = true;
			Main.tileSolid[TileID.Pearlsand] = true;
			Main.tileBlockLight[TileID.Pearlsand] = true;
			Main.tileBrick[TileID.Pearlstone] = true;
			Main.tileBrick[TileID.Ebonstone] = true;
			Main.tileBrick[TileID.Crimstone] = true;
			Main.tileSolid[TileID.Pearlstone] = true;
			Main.tileBlockLight[TileID.Pearlstone] = true;
			Main.tileSolid[TileID.Silt] = true;
			Main.tileBlockLight[TileID.Silt] = true;
			Main.tileNoFail[TileID.Stalactite] = true;
			Main.tileNoFail[TileID.LongMoss] = true;
			Main.tileNoFail[TileID.SmallPiles] = true;
			Main.tileNoFail[TileID.LargePiles] = true;
			Main.tileNoFail[TileID.LargePiles2] = true;
			Main.tileSolid[TileID.PearlstoneBrick] = true;
			Main.tileBlockLight[TileID.PearlstoneBrick] = true;
			Main.tileSolid[TileID.IridescentBrick] = true;
			Main.tileBlockLight[TileID.IridescentBrick] = true;
			Main.tileSolid[TileID.Mudstone] = true;
			Main.tileBlockLight[TileID.Mudstone] = true;
			Main.tileSolid[TileID.CobaltBrick] = true;
			Main.tileBlockLight[TileID.CobaltBrick] = true;
			Main.tileSolid[TileID.MythrilBrick] = true;
			Main.tileBlockLight[TileID.MythrilBrick] = true;
			Main.tileSolid[TileID.AdamantiteBeam] = true;
			Main.tileBlockLight[TileID.AdamantiteBeam] = true;
			Main.tileBlockLight[TileID.HallowedVines] = true;
			Main.tileSolid[TileID.FleshGrass] = true;
			Main.tileBlockLight[TileID.FleshGrass] = true;
			Main.tileNoFail[TileID.BreakableIce] = true;
			Main.tileSolid[TileID.Dirt] = true;
			Main.tileBlockLight[TileID.Dirt] = true;
			Main.tileSolid[TileID.Stone] = true;
			Main.tileBlockLight[TileID.Stone] = true;
			Main.tileSolid[TileID.Grass] = true;
			Main.tileBlockLight[TileID.Grass] = true;
			Main.tileSolid[TileID.Plants] = false;
			Main.tileNoAttach[TileID.Plants] = true;
			Main.tileNoFail[TileID.Plants] = true;
			Main.tileNoFail[TileID.FleshWeeds] = true;
			Main.tileSolid[TileID.Torches] = false;
			Main.tileNoAttach[TileID.Torches] = true;
			Main.tileNoFail[TileID.Torches] = true;
			Main.tileNoFail[TileID.CorruptPlants] = true;
			Main.tileSolid[TileID.Trees] = false;
			Main.tileSolid[TileID.Iron] = true;
			Main.tileBlockLight[TileID.Iron] = true;
			Main.tileSolid[TileID.Copper] = true;
			Main.tileBlockLight[TileID.Copper] = true;
			Main.tileSolid[TileID.Gold] = true;
			Main.tileBlockLight[TileID.Gold] = true;
			Main.tileSolid[TileID.Silver] = true;
			Main.tileBlockLight[TileID.Silver] = true;
			Main.tileSolid[TileID.Tin] = true;
			Main.tileBlockLight[TileID.Tin] = true;
			Main.tileSolid[TileID.Lead] = true;
			Main.tileBlockLight[TileID.Lead] = true;
			Main.tileSolid[TileID.Tungsten] = true;
			Main.tileBlockLight[TileID.Tungsten] = true;
			Main.tileSolid[TileID.Platinum] = true;
			Main.tileBlockLight[TileID.Platinum] = true;
			Main.tileBlockLight[TileID.ClosedDoor] = true;
			Main.tileSolid[TileID.ClosedDoor] = true;
			Main.tileNoAttach[TileID.ClosedDoor] = true;
			Main.tileBlockLight[TileID.ClosedDoor] = true;
			Main.tileSolid[TileID.OpenDoor] = false;
			Main.tileSolidTop[TileID.Platforms] = true;
			Main.tileSolid[TileID.Platforms] = true;
			Main.tileSolid[TileID.Demonite] = true;
			Main.tileSolid[TileID.CorruptGrass] = true;
			Main.tileSolid[TileID.Ebonstone] = true;
			Main.tileSolid[TileID.WoodBlock] = true;
			Main.tileNoFail[TileID.CorruptThorns] = true;
			Main.tileBlockLight[TileID.CorruptThorns] = true;
			Main.tileNoFail[TileID.CrimtaneThorns] = true;
			Main.tileBlockLight[TileID.CrimtaneThorns] = true;
			Main.tileSolid[TileID.Meteorite] = true;
			Main.tileBlockLight[TileID.Meteorite] = true;
			Main.tileSolid[TileID.GrayBrick] = true;
			Main.tileBlockLight[TileID.GrayBrick] = true;
			Main.tileSolid[TileID.RedBrick] = true;
			Main.tileBlockLight[TileID.RedBrick] = true;
			Main.tileSolid[TileID.ClayBlock] = true;
			Main.tileBlockLight[TileID.ClayBlock] = true;
			Main.tileSolid[TileID.BlueDungeonBrick] = true;
			Main.tileBlockLight[TileID.BlueDungeonBrick] = true;
			Main.tileSolid[TileID.GreenDungeonBrick] = true;
			Main.tileBlockLight[TileID.GreenDungeonBrick] = true;
			Main.tileSolid[TileID.PinkDungeonBrick] = true;
			Main.tileBlockLight[TileID.PinkDungeonBrick] = true;
			Main.tileSolid[TileID.GoldBrick] = true;
			Main.tileBlockLight[TileID.GoldBrick] = true;
			Main.tileSolid[TileID.SilverBrick] = true;
			Main.tileBlockLight[TileID.SilverBrick] = true;
			Main.tileSolid[TileID.CopperBrick] = true;
			Main.tileBlockLight[TileID.CopperBrick] = true;
			Main.tileSolid[TileID.Spikes] = true;
			Main.tileBlockLight[TileID.Spikes] = true;
			Main.tileSolid[TileID.Sand] = true;
			Main.tileBlockLight[TileID.Sand] = true;
			Main.tileSolid[TileID.Glass] = true;
			Main.tileBlockLight[TileID.Vines] = true;
			Main.tileBlockLight[TileID.CrimsonVines] = true;
			Main.tileSolid[TileID.Obsidian] = true;
			Main.tileBlockLight[TileID.Obsidian] = true;
			Main.tileSolid[TileID.Ash] = true;
			Main.tileBlockLight[TileID.Ash] = true;
			Main.tileSolid[TileID.Hellstone] = true;
			Main.tileBlockLight[TileID.Hellstone] = true;
			Main.tileBlockLight[TileID.VineFlowers] = true;
			Main.tileSolid[TileID.Mud] = true;
			Main.tileBlockLight[TileID.Mud] = true;
			Main.tileSolid[TileID.JungleGrass] = true;
			Main.tileBlockLight[TileID.JungleGrass] = true;
			Main.tileSolid[TileID.Sapphire] = true;
			Main.tileBlockLight[TileID.Sapphire] = true;
			Main.tileStone[TileID.Sapphire] = true;
			Main.tileStone[TileID.ActiveStoneBlock] = true;
			Main.tileSolid[TileID.Ruby] = true;
			Main.tileBlockLight[TileID.Ruby] = true;
			Main.tileStone[TileID.Ruby] = true;
			Main.tileSolid[TileID.Emerald] = true;
			Main.tileBlockLight[TileID.Emerald] = true;
			Main.tileStone[TileID.Emerald] = true;
			Main.tileSolid[TileID.Topaz] = true;
			Main.tileBlockLight[TileID.Topaz] = true;
			Main.tileStone[TileID.Topaz] = true;
			Main.tileSolid[TileID.Amethyst] = true;
			Main.tileBlockLight[TileID.Amethyst] = true;
			Main.tileStone[TileID.Amethyst] = true;
			Main.tileSolid[TileID.Diamond] = true;
			Main.tileBlockLight[TileID.Diamond] = true;
			Main.tileStone[TileID.Diamond] = true;
			Main.tileSolid[TileID.ObsidianBrick] = true;
			Main.tileBlockLight[TileID.ObsidianBrick] = true;
			Main.tileSolid[TileID.HellstoneBrick] = true;
			Main.tileBlockLight[TileID.HellstoneBrick] = true;
			Main.tileSolid[TileID.MushroomGrass] = true;
			Main.tileBlockLight[TileID.MushroomGrass] = true;
			Main.tileNoFail[TileID.Books] = true;
			Main.tileNoAttach[TileID.Books] = true;
			Main.tileDungeon[TileID.BlueDungeonBrick] = true;
			Main.tileDungeon[TileID.GreenDungeonBrick] = true;
			Main.tileDungeon[TileID.PinkDungeonBrick] = true;
			Main.tileBlockLight[TileID.WoodBlock] = true;
			Main.tileBlockLight[TileID.Ebonstone] = true;
			Main.tileBlockLight[TileID.CorruptGrass] = true;
			Main.tileBlockLight[TileID.Demonite] = true;
			Main.tileBlockLight[TileID.JungleVines] = true;
			Main.tileSolidTop[TileID.WorkBenches] = true;
			Main.tileSolidTop[TileID.Tables] = true;
			Main.tileSolidTop[TileID.Anvils] = true;
			Main.tileSolidTop[TileID.MythrilAnvil] = true;
			Main.tileSolidTop[TileID.TinkerersWorkbench] = true;
			Main.tileNoAttach[TileID.Saplings] = true;
			Main.tileNoAttach[TileID.Platforms] = true;
			Main.tileNoAttach[TileID.Bottles] = true;
			Main.tileNoAttach[TileID.Tables] = true;
			Main.tileNoAttach[TileID.Chairs] = true;
			Main.tileNoAttach[TileID.Anvils] = true;
			Main.tileNoAttach[TileID.MythrilAnvil] = true;
			Main.tileNoAttach[TileID.Furnaces] = true;
			Main.tileNoAttach[TileID.WorkBenches] = true;
			Main.tileNoAttach[TileID.Platforms] = true;
			Main.tileNoAttach[TileID.Containers] = true;
			Main.tileNoAttach[TileID.Sunflower] = true;
			Main.tileNoAttach[TileID.TinkerersWorkbench] = true;
			Main.tileTable[TileID.Tables] = true;
			Main.tileTable[TileID.WorkBenches] = true;
			Main.tileTable[TileID.Platforms] = true;
			Main.tileTable[TileID.TinkerersWorkbench] = true;
			Main.tileNoAttach[TileID.Loom] = true;
			Main.tileNoAttach[TileID.Pianos] = true;
			Main.tileNoAttach[TileID.Dressers] = true;
			Main.tileNoAttach[TileID.Benches] = true;
			Main.tileNoAttach[TileID.Bathtubs] = true;
			Main.tileTable[TileID.Bookcases] = true;
			Main.tileNoAttach[TileID.Bookcases] = true;
			Main.tileNoAttach[TileID.Thrones] = true;
			Main.tileNoAttach[TileID.Kegs] = true;
			Main.tileNoAttach[TileID.ChineseLanterns] = true;
			Main.tileNoAttach[TileID.CookingPots] = true;
			Main.tileNoAttach[TileID.Safes] = true;
			Main.tileNoAttach[TileID.SkullLanterns] = true;
			Main.tileNoAttach[TileID.TrashCan] = true;
			Main.tileTable[TileID.Pianos] = true;
			Main.tileTable[TileID.Dressers] = true;
			Main.tileSolidTop[TileID.Pianos] = true;
			Main.tileSolidTop[TileID.Dressers] = true;
			Main.tileSolidTop[TileID.Bookcases] = true;
			Main.tileNoAttach[TileID.Banners] = true;
			Main.tileNoAttach[TileID.Lampposts] = true;
			Main.tileNoAttach[TileID.Lamps] = true;
			Main.tileLighted[TileID.MushroomBlock] = true;
			Main.tileBlockLight[TileID.LeafBlock] = true;
			Main.tileBrick[TileID.LeafBlock] = false;
			Main.tileWaterDeath[TileID.Campfire] = true;
			Main.tileWaterDeath[TileID.Torches] = true;
			Main.tileWaterDeath[TileID.Cobweb] = true;
			Main.tileWaterDeath[TileID.Lamps] = true;
			Main.tileWaterDeath[TileID.SkullLanterns] = true;
			Main.tileLavaDeath[TileID.Plants] = true;
			Main.tileLavaDeath[TileID.Trees] = true;
			Main.tileLavaDeath[TileID.ClosedDoor] = true;
			Main.tileLavaDeath[TileID.OpenDoor] = true;
			Main.tileLavaDeath[TileID.Heart] = true;
			Main.tileLavaDeath[TileID.Bottles] = true;
			Main.tileLavaDeath[TileID.Tables] = true;
			Main.tileLavaDeath[TileID.Chairs] = true;
			Main.tileLavaDeath[TileID.Anvils] = true;
			Main.tileLavaDeath[TileID.Furnaces] = true;
			Main.tileLavaDeath[TileID.WorkBenches] = true;
			Main.tileLavaDeath[TileID.Platforms] = true;
			Main.tileLavaDeath[TileID.Saplings] = true;
			Main.tileLavaDeath[TileID.CorruptPlants] = true;
			Main.tileLavaDeath[TileID.Sunflower] = true;
			Main.tileLavaDeath[TileID.Pots] = true;
			Main.tileLavaDeath[TileID.PiggyBank] = true;
			Main.tileLavaDeath[TileID.CorruptThorns] = true;
			Main.tileLavaDeath[TileID.Candles] = true;
			Main.tileLavaDeath[TileID.Chandeliers] = true;
			Main.tileLavaDeath[TileID.Jackolanterns] = true;
			Main.tileLavaDeath[TileID.Presents] = true;
			Main.tileLavaDeath[TileID.HangingLanterns] = true;
			Main.tileLavaDeath[TileID.WaterCandle] = true;
			Main.tileLavaDeath[TileID.Books] = true;
			Main.tileLavaDeath[TileID.Cobweb] = true;
			Main.tileLavaDeath[TileID.Vines] = true;
			Main.tileLavaDeath[TileID.Signs] = true;
			Main.tileLavaDeath[TileID.JunglePlants] = true;
			Main.tileLavaDeath[TileID.JungleVines] = true;
			Main.tileLavaDeath[TileID.JungleThorns] = true;
			Main.tileLavaDeath[TileID.MushroomPlants] = true;
			Main.tileLavaDeath[TileID.MushroomTrees] = true;
			Main.tileLavaDeath[TileID.Plants2] = true;
			Main.tileLavaDeath[TileID.JunglePlants2] = true;
			Main.tileLavaDeath[TileID.Beds] = true;
			Main.tileLavaDeath[TileID.Cactus] = true;
			Main.tileLavaDeath[TileID.Coral] = true;
			Main.tileLavaDeath[TileID.Loom] = true;
			Main.tileLavaDeath[TileID.Pianos] = true;
			Main.tileLavaDeath[TileID.Dressers] = true;
			Main.tileLavaDeath[TileID.Benches] = true;
			Main.tileLavaDeath[TileID.Bathtubs] = true;
			Main.tileLavaDeath[TileID.Banners] = true;
			Main.tileLavaDeath[TileID.Lampposts] = true;
			Main.tileLavaDeath[TileID.Lamps] = true;
			Main.tileLavaDeath[TileID.Kegs] = true;
			Main.tileLavaDeath[TileID.ChineseLanterns] = true;
			Main.tileLavaDeath[TileID.CookingPots] = true;
			Main.tileLavaDeath[TileID.Safes] = true;
			Main.tileLavaDeath[TileID.SkullLanterns] = true;
			Main.tileLavaDeath[TileID.Candelabras] = true;
			Main.tileLavaDeath[TileID.Bookcases] = true;
			Main.tileLavaDeath[TileID.Thrones] = true;
			Main.tileLavaDeath[TileID.Bowls] = true;
			Main.tileLavaDeath[TileID.GrandfatherClocks] = true;
			Main.tileLavaDeath[TileID.Sawmill] = true;
			Main.tileLavaDeath[TileID.HallowedPlants] = true;
			Main.tileLavaDeath[TileID.HallowedPlants2] = true;
			Main.tileLavaDeath[TileID.HallowedVines] = true;
			Main.tileLavaDeath[TileID.CrystalBall] = true;
			Main.tileLavaDeath[TileID.DiscoBall] = true;
			Main.tileLavaDeath[TileID.Mannequin] = true;
			Main.tileLavaDeath[TileID.HolidayLights] = true;
			Main.tileLavaDeath[TileID.Sinks] = true;
			Main.tileLavaDeath[TileID.PlatinumCandelabra] = true;
			Main.tileLavaDeath[TileID.PlatinumCandle] = true;
			Main.tileLavaDeath[TileID.LongMoss] = true;
			Main.tileLavaDeath[TileID.FleshWeeds] = true;
			Main.tileLavaDeath[TileID.CrimsonVines] = true;
			Main.tileLavaDeath[TileID.FleshWeeds] = true;
			Main.tileLavaDeath[TileID.Cannon] = true;
			Main.tileLavaDeath[TileID.LandMine] = true;
			Main.tileLavaDeath[TileID.SnowballLauncher] = true;
			Main.tileLavaDeath[TileID.Rope] = true;
			Main.tileLavaDeath[TileID.VineRope] = true;
			Main.tileLavaDeath[TileID.Chain] = true;
			Main.tileLavaDeath[TileID.Campfire] = true;
			Main.tileLavaDeath[TileID.Firework] = true;
			Main.tileLavaDeath[TileID.Blendomatic] = true;
			Main.tileLavaDeath[TileID.MeatGrinder] = true;
			Main.tileLavaDeath[TileID.Extractinator] = true;
			Main.tileLavaDeath[TileID.Solidifier] = true;
			Main.tileLavaDeath[TileID.DyePlants] = true;
			Main.tileLavaDeath[TileID.DyeVat] = true;
			Main.tileLavaDeath[TileID.PlantDetritus] = true;
			Main.tileLavaDeath[TileID.LifeFruit] = true;
			Main.tileLavaDeath[TileID.PlanteraBulb] = true;
			Main.tileLavaDeath[TileID.Painting3X3] = true;
			Main.tileLavaDeath[TileID.Painting4X3] = true;
			Main.tileLavaDeath[TileID.Painting6X4] = true;
			Main.tileLavaDeath[TileID.ImbuingStation] = true;
			Main.tileLavaDeath[TileID.BubbleMachine] = true;
			Main.tileLavaDeath[TileID.Painting2X3] = true;
			Main.tileLavaDeath[TileID.Painting3X2] = true;
			Main.tileLavaDeath[TileID.Autohammer] = true;
			Main.tileLavaDeath[TileID.Pumpkins] = true;
			Main.tileLavaDeath[TileID.Womannequin] = true;
			Main.tileLavaDeath[TileID.FireflyinaBottle] = true;
			Main.tileLavaDeath[TileID.LightningBuginaBottle] = true;
			Main.tileLavaDeath[TileID.BunnyCage] = true;
			Main.tileLavaDeath[TileID.SquirrelOrangeCage] = true;
			Main.tileLavaDeath[TileID.SquirrelCage] = true;
			Main.tileLavaDeath[TileID.MallardDuckCage] = true;
			Main.tileLavaDeath[TileID.DuckCage] = true;
			Main.tileLavaDeath[TileID.BirdCage] = true;
			Main.tileLavaDeath[TileID.BlueJay] = true;
			Main.tileLavaDeath[TileID.CardinalCage] = true;
			Main.tileLavaDeath[TileID.FishBowl] = true;
			Main.tileLavaDeath[TileID.HeavyWorkBench] = true;
			Main.tileLavaDeath[TileID.SnailCage] = true;
			Main.tileLavaDeath[TileID.GlowingSnailCage] = true;
			Main.tileLavaDeath[TileID.AmmoBox] = true;
			Main.tileLavaDeath[TileID.MonarchButterflyJar] = true;
			Main.tileLavaDeath[TileID.PurpleEmperorButterflyJar] = true;
			Main.tileLavaDeath[TileID.RedAdmiralButterflyJar] = true;
			Main.tileLavaDeath[TileID.UlyssesButterflyJar] = true;
			Main.tileLavaDeath[TileID.SulphurButterflyJar] = true;
			Main.tileLavaDeath[TileID.TreeNymphButterflyJar] = true;
			Main.tileLavaDeath[TileID.ZebraSwallowtailButterflyJar] = true;
			Main.tileLavaDeath[TileID.JuliaButterflyJar] = true;
			Main.tileLavaDeath[TileID.ScorpionCage] = true;
			Main.tileLavaDeath[TileID.BlackScorpionCage] = true;
			Main.tileLavaDeath[TileID.FrogCage] = true;
			Main.tileLavaDeath[TileID.MouseCage] = true;
			Main.tileLavaDeath[TileID.BoneWelder] = true;
			Main.tileLavaDeath[TileID.FleshCloningVat] = true;
			Main.tileLavaDeath[TileID.GlassKiln] = true;
			Main.tileLavaDeath[TileID.LihzahrdFurnace] = true;
			Main.tileLavaDeath[TileID.LivingLoom] = true;
			Main.tileLavaDeath[TileID.SkyMill] = true;
			Main.tileLavaDeath[TileID.IceMachine] = true;
			Main.tileLavaDeath[TileID.SteampunkBoiler] = true;
			Main.tileLavaDeath[TileID.HoneyDispenser] = true;
			Main.tileLavaDeath[TileID.PenguinCage] = true;
			Main.tileLavaDeath[TileID.WormCage] = true;
			Main.tileLavaDeath[TileID.BlueJellyfishBowl] = true;
			Main.tileLavaDeath[TileID.GreenJellyfishBowl] = true;
			Main.tileLavaDeath[TileID.PinkJellyfishBowl] = true;
			Main.tileLavaDeath[TileID.ShipInABottle] = true;
			Main.tileLavaDeath[TileID.BewitchingTable] = true;
			Main.tileLavaDeath[TileID.AlchemyTable] = true;
			Main.tileLavaDeath[TileID.PalmTree] = true;
			Main.tileLavaDeath[TileID.FireworksBox] = true;
			Main.tileLavaDeath[TileID.FireworkFountain] = true;
			Main.tileLavaDeath[TileID.GrasshopperCage] = true;
			Main.tileLavaDeath[TileID.CrimtaneThorns] = true;
			Main.tileLavaDeath[TileID.VineFlowers] = true;
			Main.tileLighted[TileID.BlueJellyfishBowl] = true;
			Main.tileLighted[TileID.GreenJellyfishBowl] = true;
			Main.tileLighted[TileID.PinkJellyfishBowl] = true;
			for (int r = 0; r < 419; r++)
			{
				if (Main.tileLavaDeath[r])
				{
					Main.tileObsidianKill[r] = true;
				}
			}
			Main.tileObsidianKill[TileID.Hellforge] = true;
			Main.tileObsidianKill[TileID.ClayPot] = true;
			Main.tileObsidianKill[TileID.ImmatureHerbs] = true;
			Main.tileObsidianKill[TileID.MatureHerbs] = true;
			Main.tileObsidianKill[TileID.BloomingHerbs] = true;
			Main.tileObsidianKill[TileID.Tombstones] = true;
			Main.tileObsidianKill[TileID.Statues] = true;
			Main.tileObsidianKill[TileID.Crystals] = true;
			Main.tileObsidianKill[TileID.Lever] = true;
			Main.tileObsidianKill[TileID.AdamantiteForge] = true;
			Main.tileObsidianKill[TileID.MythrilAnvil] = true;
			Main.tileObsidianKill[TileID.PressurePlates] = true;
			Main.tileObsidianKill[TileID.Switches] = true;
			Main.tileObsidianKill[TileID.MusicBoxes] = true;
			Main.tileObsidianKill[TileID.Stalactite] = true;
			Main.tileObsidianKill[TileID.ExposedGems] = true;
			Main.tileObsidianKill[TileID.SmallPiles] = true;
			Main.tileObsidianKill[TileID.LargePiles] = true;
			Main.tileObsidianKill[TileID.LargePiles2] = true;
			Main.tileObsidianKill[TileID.Larva] = true;
			Main.tileObsidianKill[TileID.AlphabetStatues] = true;
			Main.tileObsidianKill[TileID.MushroomStatue] = true;
			Main.tileSolid[TileID.LivingMahoganyLeaves] = true;
			Main.tileBlockLight[TileID.LivingMahoganyLeaves] = true;
			Main.tileNoFail[TileID.LivingMahoganyLeaves] = true;
			Main.tileFrameImportant[TileID.ItemFrame] = true;
			Main.tileLavaDeath[TileID.ItemFrame] = true;
			Main.tileFrameImportant[TileID.Fireplace] = true;
			Main.tileLavaDeath[TileID.Fireplace] = true;
			Main.tileSolidTop[TileID.Fireplace] = true;
			Main.tileTable[TileID.Fireplace] = true;
			Main.tileLighted[TileID.Fireplace] = true;
			Main.tileWaterDeath[TileID.Fireplace] = true;
			Main.tileFrameImportant[TileID.Chimney] = true;
			Main.tileLavaDeath[TileID.Chimney] = true;
			Main.tileFrameImportant[TileID.Detonator] = true;
			Main.tileLavaDeath[TileID.Detonator] = true;
			Main.tileFrameImportant[TileID.LunarCraftingStation] = true;
			for (int s = 0; s < 225; s++)
			{
				if (s == 20)
				{
					Main.wallBlend[s] = 14;
				}
				else if (s == 19)
				{
					Main.wallBlend[s] = 9;
				}
				else if (s == 18)
				{
					Main.wallBlend[s] = 8;
				}
				else if (s == 17)
				{
					Main.wallBlend[s] = 7;
				}
				else if (s == 16 || s == 59)
				{
					Main.wallBlend[s] = 2;
				}
				else if (s == 1 || s >= 48 && s <= 53)
				{
					Main.wallBlend[s] = 1;
				}
				else
				{
					Main.wallBlend[s] = s;
				}
			}
			Main.wallBlend[WallID.FlowerUnsafe] = 63;
			Main.wallBlend[WallID.Grass] = 63;
			Main.wallBlend[WallID.Flower] = 63;
			Main.wallBlend[WallID.Jungle] = 64;
			Main.wallBlend[WallID.MushroomUnsafe] = 74;
			Main.wallBlend[WallID.CrimsonGrassUnsafe] = 77;
			Main.wallBlend[WallID.BlueDungeonSlabUnsafe] = 7;
			Main.wallBlend[WallID.BlueDungeonTileUnsafe] = 7;
			Main.wallBlend[WallID.BlueDungeonSlab] = 7;
			Main.wallBlend[WallID.BlueDungeonTile] = 7;
			Main.wallBlend[WallID.PinkDungeonSlabUnsafe] = 8;
			Main.wallBlend[WallID.PinkDungeonTileUnsafe] = 8;
			Main.wallBlend[WallID.PinkDungeonSlab] = 8;
			Main.wallBlend[WallID.PinkDungeonTile] = 8;
			Main.wallBlend[WallID.GreenDungeonSlabUnsafe] = 9;
			Main.wallBlend[WallID.GreenDungeonTileUnsafe] = 9;
			Main.wallBlend[WallID.GreenDungeonSlab] = 9;
			Main.wallBlend[WallID.GreenDungeonTile] = 9;
			Main.tileNoFail[TileID.CorruptPlants] = true;
			Main.tileNoFail[TileID.Plants] = true;
			Main.tileNoFail[TileID.Vines] = true;
			Main.tileNoFail[TileID.JungleVines] = true;
			Main.tileNoFail[TileID.CorruptThorns] = true;
			Main.tileNoFail[TileID.JunglePlants] = true;
			Main.tileNoFail[TileID.JungleThorns] = true;
			Main.tileNoFail[TileID.Plants2] = true;
			Main.tileNoFail[TileID.JunglePlants2] = true;
			Main.tileNoFail[TileID.ImmatureHerbs] = true;
			Main.tileNoFail[TileID.MatureHerbs] = true;
			Main.tileNoFail[TileID.BloomingHerbs] = true;
			Main.tileNoFail[TileID.HallowedPlants] = true;
			Main.tileNoFail[TileID.HallowedPlants2] = true;
			Main.tileNoFail[TileID.HallowedVines] = true;
			Main.tileNoFail[TileID.Stalactite] = true;
			Main.tileNoFail[TileID.LongMoss] = true;
			Main.tileNoFail[TileID.FleshWeeds] = true;
			Main.tileNoFail[TileID.CrimsonVines] = true;
			Main.tileNoFail[TileID.DyePlants] = true;
			Main.tileNoFail[TileID.PlantDetritus] = true;
			Main.tileNoFail[TileID.CrimtaneThorns] = true;
			Main.tileNoFail[TileID.VineFlowers] = true;
			Main.tileFrameImportant[TileID.TrapdoorClosed] = true;
			Main.tileSolid[TileID.TrapdoorClosed] = true;
			Main.tileBlockLight[TileID.TrapdoorClosed] = true;
			Main.tileNoAttach[TileID.TrapdoorClosed] = true;
			Main.tileLavaDeath[TileID.TrapdoorClosed] = true;
			Main.tileFrameImportant[TileID.TrapdoorOpen] = true;
			Main.tileLavaDeath[TileID.TrapdoorOpen] = true;
			Main.tileNoSunLight[TileID.TrapdoorOpen] = true;
			Main.tileFrameImportant[TileID.TallGateClosed] = true;
			Main.tileSolid[TileID.TallGateClosed] = true;
			Main.tileBlockLight[TileID.TallGateClosed] = true;
			Main.tileNoAttach[TileID.TallGateClosed] = true;
			Main.tileLavaDeath[TileID.TallGateClosed] = true;
			Main.tileFrameImportant[TileID.TallGateOpen] = true;
			Main.tileLavaDeath[TileID.TallGateOpen] = true;
			Main.tileNoSunLight[TileID.TallGateOpen] = true;
			for (int t = 0; t < 419; t++)
			{
				if (Main.tileSolid[t])
				{
					Main.tileNoSunLight[t] = true;
				}
				Main.tileFrame[t] = 0;
				Main.tileFrameCounter[t] = 0;
			}
			Main.tileNoSunLight[TileID.Bubble] = false;
			Main.tileNoSunLight[TileID.Glass] = false;
			Main.tileNoSunLight[TileID.Confetti] = false;
			Main.tileNoSunLight[TileID.Platforms] = false;
			Main.tileNoSunLight[TileID.OpenDoor] = true;
			Main.tileNoSunLight[TileID.Cloud] = false;
			Main.tileNoSunLight[TileID.RainCloud] = false;
			for (int u = 0; u < Main.maxMenuItems; u++)
			{
				this.menuItemScale[u] = 0.8f;
			}
			for (int w = 0; w < 401; w++)
			{
				Main.item[w] = new Item();
			}
			for (int x = 0; x < 201; x++)
			{
				Main.npc[x] = new NPC();
				Main.npc[x].whoAmI = x;
			}
			for (int y = 0; y < 256; y++)
			{
				Main.player[y] = new Player();
			}
			for (int a = 0; a < 1001; a++)
			{
				Main.projectile[a] = new Projectile();
			}
			for (int d = 0; d < 200; d++)
			{
				Main.cloud[d] = new Cloud();
			}
			for (int e = 0; e < 100; e++)
			{
				Main.combatText[e] = new CombatText();
			}
			for (int f = 0; f < 20; f++)
			{
				Main.itemText[f] = new ItemText();
			}
			int num = 0;
			Label3:
			while (num < Main.maxItemTypes)
			{
				item = new Item();
				item.SetDefaults(num, false);
				Main.itemName[num] = item.name;
				if (item.headSlot > 0)
				{
					Item.headType[item.headSlot] = item.type;
				}
				if (item.bodySlot > 0)
				{
					Item.bodyType[item.bodySlot] = item.type;
				}
				if (item.legSlot > 0)
				{
					Item.legType[item.legSlot] = item.type;
				}
				int num1 = item.type;
				if (num1 <= 1827)
				{
					if (num1 > 788)
					{
						if (num1 > 1326)
						{
							switch (num1)
							{
								case 1444:
								case 1445:
								case 1446:
									{
										break;
									}
								default:
									{
										if (num1 == 1801)
										{
											break;
										}
										if (num1 == 1827)
										{
											goto Label1;
										}
										goto Label0;
									}
							}
						}
						else
						{
							if (num1 == 1308 || num1 == 1326)
							{
								goto Label2;
							}
							goto Label0;
						}
					}
					else if (num1 <= 723)
					{
						if (num1 == 683 || num1 == 723)
						{
							goto Label2;
						}
						goto Label0;
					}
					else if (num1 != 726)
					{
						switch (num1)
						{
							case 739:
							case 740:
							case 741:
							case 742:
							case 743:
							case 744:
								{
									break;
								}
							default:
								{
									if (num1 == 788)
									{
										break;
									}
									goto Label0;
								}
						}
					}
				}
				else if (num1 <= 3051)
				{
					if (num1 > 2188)
					{
						if (num1 == 2750 || num1 == 3006 || num1 == 3051)
						{
							goto Label2;
						}
						goto Label0;
					}
					else
					{
						switch (num1)
						{
							case 1930:
							case 1931:
								{
									break;
								}
							default:
								{
									if (num1 == 2188)
									{
										break;
									}
									goto Label0;
								}
						}
					}
				}
				else if (num1 <= 3245)
				{
					switch (num1)
					{
						case 3209:
						case 3210:
							{
								break;
							}
						default:
							{
								if (num1 == 3245)
								{
									goto Label1;
								}
								goto Label0;
							}
					}
				}
				else if (num1 != 3377 && num1 != 3476)
				{
					switch (num1)
					{
						case 3569:
						case 3571:
							{
								break;
							}
						default:
							{
								goto Label0;
							}
					}
				}
				Label2:
				Item.staff[item.type] = true;
				goto Label0;
			}
			Main.InitLifeBytes();
			for (int g = 0; g < Recipe.maxRecipes; g++)
			{
				Main.recipe[g] = new Recipe();
				Main.availableRecipeY[g] = (float)(65 * g);
			}
			Recipe.SetupRecipes();
			for (int i1 = 0; i1 < Liquid.resLiquid; i1++)
			{
				Main.liquid[i1] = new Liquid();
			}
			for (int j1 = 0; j1 < 10000; j1++)
			{
				Main.liquidBuffer[j1] = new LiquidBuffer();
			}
			this.waterfallManager = new WaterfallManager();
			this.shop[0] = new Chest(false);
			Chest.SetupTravelShop();
			for (int k1 = 1; k1 < Main.numShops; k1++)
			{
				this.shop[k1] = new Chest(false);
				this.shop[k1].SetupShop(k1);
			}
			Main.teamColor[0] = Color.White;
			Main.teamColor[1] = new Color(218, 59, 59);
			Main.teamColor[2] = new Color(59, 218, 85);
			Main.teamColor[3] = new Color(59, 149, 218);
			Main.teamColor[4] = new Color(242, 221, 100);
			Main.teamColor[5] = new Color(224, 100, 242);
			if (Main.menuMode == 1)
			{
				Main.LoadPlayers();
			}
			for (int l1 = 1; l1 < 651; l1++)
			{
				Projectile projectile = new Projectile();
				projectile.SetDefaults(l1);
				if (projectile.hostile)
				{
					Main.projHostile[l1] = true;
				}
				if (projectile.aiStyle == 7)
				{
					Main.projHook[l1] = true;
				}
			}
			Netplay.Initialize();
			NetworkInitializer.Load();
			/*if (!Main.skipMenu)
			{
			}
			else
			{
				WorldGen.clearWorld();
				Main.gameMenu = false;
				Main.LoadPlayers();
				Main.PlayerList[0].SetAsActive();
				Main.LoadWorlds();
				WorldGen.generateWorld(-1, null);
				WorldGen.EveryTileFrame();
				Main.player[Main.myPlayer].Spawn();
				Main.ActivePlayerFileData.StartPlayTimer();
				Player.EnterWorld(Main.player[Main.myPlayer]);
			}*/
			if (Main.dedServ)
			{
				Main.clientUUID = Guid.NewGuid().ToString();
				return;
			}
			/*
			if (Lang.lang > 1)
			{
				Lang.setLang(true);
			}
			Lang.setLang(false);
			if (Lang.lang == 0)
			{
				Main.menuMode = 1212;
			}
			this.SetTitle();
			Star.SpawnStars();
			WorldGen.RandomizeWeather();
			return;*/
			Label0:
			num++;
			goto Label3;
			Label1:
			Item.claw[item.type] = true;
			goto Label0;
		}

		public static void InitializeItemAnimations()
		{
		}

		public static void InitLifeBytes()
		{
			NPC nPC = new NPC();
			for (int i = -65; i < 540; i++)
			{
				if (i != 0)
				{
					nPC.netDefaults(i);
					if (nPC.lifeMax > 32767)
					{
						Main.npcLifeBytes[i] = 4;
					}
					else if (nPC.lifeMax <= 127)
					{
						Main.npcLifeBytes[i] = 1;
					}
					else
					{
						Main.npcLifeBytes[i] = 2;
					}
				}
			}
			nPC = null;
		}

		protected void InitMap()
		{
		}

		protected void InitTargets()
		{
		}

		protected void InitTargets(int width, int height)
		{
		}

		private static void InvasionWarning()
		{
			string str = "";
			if (Main.invasionSize <= 0)
			{
				if (Main.invasionType == 2)
				{
					str = Lang.misc[4];
				}
				else if (Main.invasionType == 3)
				{
					str = Lang.misc[24];
				}
				else if (Main.invasionType != 4)
				{
					string str1 = Lang.misc[0];
					str = str1;
					str = str1;
				}
				else
				{
					str = Lang.misc[42];
				}
			}
			else if (Main.invasionX < (double)Main.spawnTileX)
			{
				if (Main.invasionType == 2)
				{
					str = Lang.misc[5];
				}
				else if (Main.invasionType == 3)
				{
					str = Lang.misc[25];
				}
				else if (Main.invasionType != 4)
				{
					string str2 = Lang.misc[1];
					str = str2;
					str = str2;
				}
				else
				{
					str = "";
				}
			}
			else if (Main.invasionX > (double)Main.spawnTileX)
			{
				if (Main.invasionType == 2)
				{
					str = Lang.misc[6];
				}
				else if (Main.invasionType == 3)
				{
					str = Lang.misc[26];
				}
				else if (Main.invasionType != 4)
				{
					string str3 = Lang.misc[2];
					str = str3;
					str = str3;
				}
				else
				{
					str = "";
				}
			}
			else if (Main.invasionType == 2)
			{
				str = Lang.misc[7];
			}
			else if (Main.invasionType == 3)
			{
				str = Lang.misc[27];
			}
			else if (Main.invasionType != 4)
			{
				string str4 = Lang.misc[3];
				str = str4;
				str = str4;
			}
			else
			{
				str = Lang.misc[41];
			}
			if (Main.netMode == 0)
			{
				Main.NewText(str, 175, 75, 255, false);
				return;
			}
			if (Main.netMode == 2)
			{
				NetMessage.SendData((int)PacketTypes.ChatText, -1, -1, str, 255, 175f, 75f, 255f, 0, 0, 0);
			}
		}

		protected void LoadAccBack(int i)
		{
			if (!Main.accBackLoaded[i])
			{
				Main.accBackLoaded[i] = true;
			}
		}

		protected void LoadAccBalloon(int i)
		{
			if (!Main.accballoonLoaded[i])
			{
				Main.accballoonLoaded[i] = true;
			}
		}

		protected void LoadAccFace(int i)
		{
			if (!Main.accFaceLoaded[i])
			{
				Main.accFaceLoaded[i] = true;
			}
		}

		protected void LoadAccFront(int i)
		{
			if (!Main.accFrontLoaded[i])
			{
				Main.accFrontLoaded[i] = true;
			}
		}

		protected void LoadAccHandsOff(int i)
		{
			if (!Main.accHandsOffLoaded[i])
			{
				Main.accHandsOffLoaded[i] = true;
			}
		}

		protected void LoadAccHandsOn(int i)
		{
			if (!Main.accHandsOnLoaded[i])
			{
				Main.accHandsOnLoaded[i] = true;
			}
		}

		protected void LoadAccNeck(int i)
		{
			if (!Main.accNeckLoaded[i])
			{
				Main.accNeckLoaded[i] = true;
			}
		}

		protected void LoadAccShield(int i)
		{
			if (!Main.accShieldLoaded[i])
			{
				Main.accShieldLoaded[i] = true;
			}
		}

		protected void LoadAccShoes(int i)
		{
			if (!Main.accShoesLoaded[i])
			{
				Main.accShoesLoaded[i] = true;
			}
		}

		protected void LoadAccWaist(int i)
		{
			if (!Main.accWaistLoaded[i])
			{
				Main.accWaistLoaded[i] = true;
			}
		}

		protected void LoadArmorBody(int i)
		{
			if (!Main.armorBodyLoaded[i])
			{
				Main.armorBodyLoaded[i] = true;
			}
		}

		protected void LoadArmorHead(int i)
		{
			if (!Main.armorHeadLoaded[i])
			{
				Main.armorHeadLoaded[i] = true;
			}
		}

		protected void LoadArmorLegs(int i)
		{
			if (!Main.armorLegsLoaded[i])
			{
				Main.armorLegsLoaded[i] = true;
			}
		}

		public void LoadBackground(int i)
		{
			if (i >= 0 && !Main.backgroundLoaded[i])
			{
				Main.backgroundLoaded[i] = true;
			}
		}

		protected void LoadContent()
		{
		}

		public void LoadDedConfig(string configPath)
		{
			if (File.Exists(configPath))
			{
				using (StreamReader streamReader = new StreamReader(configPath))
				{
					while (true)
					{
						string str = streamReader.ReadLine();
						string str1 = str;
						if (str == null)
						{
							break;
						}
						try
						{
							if (str1.Length > 6 && str1.Substring(0, 6).ToLower() == "world=")
							{
								string str2 = str1.Substring(6);
								Main.ActiveWorldFileData = WorldFile.GetAllMetadata(str2);
							}
							if (str1.Length > 5 && str1.Substring(0, 5).ToLower() == "port=")
							{
								string str3 = str1.Substring(5);
								try
								{
									Netplay.ListenPort = Convert.ToInt32(str3);
								}
								catch (Exception ex)
								{
#if DEBUG
									Console.WriteLine(ex);
									System.Diagnostics.Debugger.Break();

#endif
								}
							}
							if (str1.Length > 11 && str1.Substring(0, 11).ToLower() == "maxplayers=")
							{
								string str4 = str1.Substring(11);
								try
								{
									Main.maxNetPlayers = Convert.ToInt32(str4);
								}
								catch (Exception ex)
								{
#if DEBUG
									Console.WriteLine(ex);
									System.Diagnostics.Debugger.Break();

#endif
								}
							}
#if !MONO
							if (str1.Length > 9 && str1.Substring(0, 9).ToLower() == "priority=")
							{
								string str5 = str1.Substring(9);
								try
								{
									int num = Convert.ToInt32(str5);
									if (num >= 0 && num <= 5)
									{
										Process currentProcess = Process.GetCurrentProcess();
										if (num == 0)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.RealTime;
										}
										else if (num == 1)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.High;
										}
										else if (num == 2)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.AboveNormal;
										}
										else if (num == 3)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.Normal;
										}
										else if (num == 4)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.BelowNormal;
										}
										else if (num == 5)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.Idle;
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
#endif
							if (str1.Length > 9 && str1.Substring(0, 9).ToLower() == "password=")
							{
								Netplay.ServerPassword = str1.Substring(9);
							}
							if (str1.Length > 5 && str1.Substring(0, 5).ToLower() == "motd=")
							{
								Main.motd = str1.Substring(5);
							}
							if (str1.Length > 5 && str1.Substring(0, 5).ToLower() == "lang=")
							{
								Lang.lang = Convert.ToInt32(str1.Substring(5));
							}
							if (str1.Length >= 10 && str1.Substring(0, 10).ToLower() == "worldpath=")
							{
								Main.WorldPath = str1.Substring(10);
							}
							if (str1.Length >= 10 && str1.Substring(0, 10).ToLower() == "worldname=")
							{
								Main.worldName = str1.Substring(10);
							}
							if (str1.Length > 8 && str1.Substring(0, 8).ToLower() == "banlist=")
							{
								Netplay.BanFilePath = str1.Substring(8);
							}
							if (str1.Length > 11 && str1.Substring(0, 11).ToLower() == "difficulty=")
							{
								string str6 = str1.Substring(11);
								if (str6 == "0")
								{
									Main.expertMode = false;
								}
								else if (str6 == "1")
								{
									Main.expertMode = true;
								}
							}
							if (str1.Length > 11 && str1.Substring(0, 11).ToLower() == "autocreate=")
							{
								string str7 = str1.Substring(11);
								if (str7 == "0")
								{
									Main.autoGen = false;
								}
								else if (str7 == "1")
								{
									Main.maxTilesX = 4200;
									Main.maxTilesY = 1200;
									Main.autoGen = true;
								}
								else if (str7 == "2")
								{
									Main.maxTilesX = 6300;
									Main.maxTilesY = 1800;
									Main.autoGen = true;
								}
								else if (str7 == "3")
								{
									Main.maxTilesX = 8400;
									Main.maxTilesY = 2400;
									Main.autoGen = true;
								}
							}
							if (str1.Length > 7 && str1.Substring(0, 7).ToLower() == "secure=" && str1.Substring(7) == "1")
							{
								Netplay.spamCheck = true;
							}
							if (str1.Length > 10 && str1.Substring(0, 10).ToLower() == "npcstream=")
							{
								string str8 = str1.Substring(10);
								try
								{
									Main.npcStreamSpeed = Convert.ToInt32(str8);
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
						catch (Exception ex)
						{
#if DEBUG
							Console.WriteLine(ex);
							System.Diagnostics.Debugger.Break();

#endif
						}
					}
				}
			}
		}

		protected void LoadFlameRing()
		{
			if (!Main.flameRingLoaded)
			{
				Main.flameRingLoaded = true;
			}
		}

		/*protected void LoadGore(int i)
		{
			if (!Main.goreLoaded[i])
			{
				Main.goreLoaded[i] = true;
			}
		}*/

		protected void LoadHair(int i)
		{
			if (!Main.hairLoaded[i])
			{
				Main.hairLoaded[i] = true;
			}
		}

		protected void LoadItemFlames(int i)
		{
			if (!Main.itemFlameLoaded[i])
			{
				try
				{
				}
				catch (Exception ex)
				{
#if DEBUG
					Console.WriteLine(ex);
					System.Diagnostics.Debugger.Break();

#endif
				}
				Main.itemFlameLoaded[i] = true;
			}
		}

		public void loadLib(string path)
		{
		}

		protected void LoadNPC(int i)
		{
			if (!Main.NPCLoaded[i])
			{
				Main.NPCLoaded[i] = true;
			}
		}

		public static void LoadPlayers()
		{
			Main.PlayerList.Clear();
			Directory.CreateDirectory(Main.PlayerPath);
			string[] files = Directory.GetFiles(Main.PlayerPath, "*.plr");
			int num = Math.Min(Main.maxLoadPlayer, (int)files.Length);
			for (int i = 0; i < num; i++)
			{
				PlayerFileData fileData = Player.GetFileData(files[i]);
				if (fileData != null)
				{
					Main.PlayerList.Add(fileData);
				}
			}

			Main.PlayerList.Sort(new Comparison<PlayerFileData>(Main.PlayerListSortMethod));
		}

		protected void LoadProjectile(int i)
		{
			if (!Main.projectileLoaded[i])
			{
				Main.projectileLoaded[i] = true;
			}
		}

		protected void LoadTiles(int i)
		{
			if (!Main.tileSetsLoaded[i])
			{
				Main.tileSetsLoaded[i] = true;
			}
		}

		protected void LoadWall(int i)
		{
			if (!Main.wallLoaded[i])
			{
				Main.wallLoaded[i] = true;
			}
		}

		protected void LoadWings(int i)
		{
			if (!Main.wingsLoaded[i])
			{
				Main.wingsLoaded[i] = true;
			}
		}

		public static void LoadWorlds()
		{
			Main.WorldList.Clear();
			Directory.CreateDirectory(Main.WorldPath);
			string[] files = Directory.GetFiles(Main.WorldPath, "*.wld");
			int num = Math.Min((int)files.Length, Main.maxLoadWorld);
			for (int i = 0; i < num; i++)
			{
				WorldFileData allMetadata = WorldFile.GetAllMetadata(files[i]);
				if (allMetadata != null)
				{
					Main.WorldList.Add(allMetadata);
				}
			}
			Main.WorldList.Sort(new Comparison<WorldFileData>(Main.WorldListSortMethod));
		}

		protected void lookForColorTiles()
		{
			int x = (int)(Main.screenPosition.X / 16f - 2f);
			int num = (int)((Main.screenPosition.X + (float)Main.screenWidth) / 16f) + 3;
			int y = (int)(Main.screenPosition.Y / 16f - 2f);
			int y1 = (int)((Main.screenPosition.Y + (float)Main.screenHeight) / 16f) + 3;
			if (x < 1)
			{
				x = 1;
			}
			if (num > Main.maxTilesX - 2)
			{
				num = Main.maxTilesX - 2;
			}
			for (int i = x; i < num; i++)
			{
				if (i > 0)
				{
					for (int j = y; j < y1; j++)
					{
						if (Main.tile[i, j] != null)
						{
							int treeVariant = Main.GetTreeVariant(i, j);
							if (treeVariant != -1)
							{
								this.woodColorCheck(treeVariant, (int)Main.tile[i, j].color());
							}
							if (Main.tile[i, j].active() && Main.tile[i, j].color() > 0)
							{
								this.tileColorCheck((int)Main.tile[i, j].type, (int)Main.tile[i, j].color());
							}
							if (Main.tile[i, j].wall > 0 && Main.tile[i, j].wallColor() > 0)
							{
								this.wallColorCheck((int)Main.tile[i, j].wall, (int)Main.tile[i, j].wallColor());
							}
						}
					}
				}
			}
			for (int k = 0; k < Main.numTreeStyles; k++)
			{
				for (int l = 0; l < Main.numTileColors; l++)
				{
					if (Main.checkTreeAlt[k, l])
					{
						this.treeColorCheck(k, l);
						Main.checkTreeAlt[k, l] = false;
					}
				}
			}
		}

		public void MouseText(string cursorText, int rare = 0, byte diff = 0)
		{
		}

		public static void MoveCoins(Item[] pInv, Item[] cInv)
		{
			int[] numArray = new int[4];
			List<int> nums = new List<int>();
			List<int> nums1 = new List<int>();
			bool flag = false;
			int[] numArray1 = new int[40];
			for (int i = 0; i < (int)cInv.Length; i++)
			{
				numArray1[i] = -1;
				if (cInv[i].stack < 1 || cInv[i].type < 1)
				{
					nums1.Add(i);
					cInv[i] = new Item();
				}
				if (cInv[i] != null && cInv[i].stack > 0)
				{
					int num = 0;
					if (cInv[i].type == 71)
					{
						num = 1;
					}
					if (cInv[i].type == 72)
					{
						num = 2;
					}
					if (cInv[i].type == 73)
					{
						num = 3;
					}
					if (cInv[i].type == 74)
					{
						num = 4;
					}
					numArray1[i] = num - 1;
					if (num > 0)
					{
						numArray[num - 1] = numArray[num - 1] + cInv[i].stack;
						nums1.Add(i);
						cInv[i] = new Item();
						flag = true;
					}
				}
			}
			if (!flag)
			{
				return;
			}
			for (int j = 0; j < (int)pInv.Length; j++)
			{
				if (j != 58 && pInv[j] != null && pInv[j].stack > 0)
				{
					int num1 = 0;
					if (pInv[j].type == 71)
					{
						num1 = 1;
					}
					if (pInv[j].type == 72)
					{
						num1 = 2;
					}
					if (pInv[j].type == 73)
					{
						num1 = 3;
					}
					if (pInv[j].type == 74)
					{
						num1 = 4;
					}
					if (num1 > 0)
					{
						numArray[num1 - 1] = numArray[num1 - 1] + pInv[j].stack;
						nums.Add(j);
						pInv[j] = new Item();
					}
				}
			}
			for (int k = 0; k < 3; k++)
			{
				while (numArray[k] >= 100)
				{
					numArray[k] = numArray[k] - 100;
					numArray[k + 1] = numArray[k + 1] + 1;
				}
			}
			for (int l = 0; l < 40; l++)
			{
				if (numArray1[l] >= 0 && cInv[l].type == 0)
				{
					int num2 = l;
					int num3 = numArray1[l];
					if (numArray[num3] > 0)
					{
						cInv[num2].SetDefaults(71 + num3, false);
						cInv[num2].stack = numArray[num3];
						if (cInv[num2].stack > cInv[num2].maxStack)
						{
							cInv[num2].stack = cInv[num2].maxStack;
						}
						numArray[num3] = numArray[num3] - cInv[num2].stack;
						numArray1[l] = -1;
					}
					if (Main.netMode == 1 && Main.player[Main.myPlayer].chest > -1)
					{
						NetMessage.SendData((int)PacketTypes.ChestItem, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num2, 0f, 0f, 0, 0, 0);
					}
					nums1.Remove(num2);
				}
			}
			for (int m = 0; m < 40; m++)
			{
				if (numArray1[m] >= 0 && cInv[m].type == 0)
				{
					int num4 = m;
					int num5 = 3;
					while (num5 >= 0)
					{
						if (numArray[num5] <= 0)
						{
							num5--;
						}
						else
						{
							cInv[num4].SetDefaults(71 + num5, false);
							cInv[num4].stack = numArray[num5];
							if (cInv[num4].stack > cInv[num4].maxStack)
							{
								cInv[num4].stack = cInv[num4].maxStack;
							}
							numArray[num5] = numArray[num5] - cInv[num4].stack;
							numArray1[m] = -1;
							break;
						}
					}
					if (Main.netMode == 1 && Main.player[Main.myPlayer].chest > -1)
					{
						NetMessage.SendData((int)PacketTypes.ChestItem, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num4, 0f, 0f, 0, 0, 0);
					}
					nums1.Remove(num4);
				}
			}
			while (nums1.Count > 0)
			{
				int item = nums1[0];
				int num6 = 3;
				while (num6 >= 0)
				{
					if (numArray[num6] <= 0)
					{
						num6--;
					}
					else
					{
						cInv[item].SetDefaults(71 + num6, false);
						cInv[item].stack = numArray[num6];
						if (cInv[item].stack > cInv[item].maxStack)
						{
							cInv[item].stack = cInv[item].maxStack;
						}
						numArray[num6] = numArray[num6] - cInv[item].stack;
						break;
					}
				}
				if (Main.netMode == 1 && Main.player[Main.myPlayer].chest > -1)
				{
					NetMessage.SendData((int)PacketTypes.ChestItem, -1, -1, "", Main.player[Main.myPlayer].chest, (float)nums1[0], 0f, 0f, 0, 0, 0);
				}
				nums1.RemoveAt(0);
			}
			while (nums.Count > 0)
			{
				int item1 = nums[0];
				for (int n = 3; n >= 0; n--)
				{
					if (numArray[n] > 0)
					{
						pInv[item1].SetDefaults(71 + n, false);
						pInv[item1].stack = numArray[n];
						if (pInv[item1].stack > pInv[item1].maxStack)
						{
							pInv[item1].stack = pInv[item1].maxStack;
						}
						numArray[n] = numArray[n] - pInv[item1].stack;
					}
				}
				nums.RemoveAt(0);
			}
		}

		public void NewMOTD(string newMOTD)
		{
			Main.motd = newMOTD;
		}

		public static void NewText(string newText, byte R = 255, byte G = 255, byte B = 255, bool force = false)
		{
		}

		public static float NPCAddHeight(int i)
		{
			float single = 0f;
			if (Main.npc[i].type == NPCID.Retinazer)
			{
				single = 30f;
			}
			else if (Main.npc[i].type == NPCID.Clothier)
			{
				single = 2f;
			}
			else if (Main.npc[i].type == NPCID.Moth)
			{
				single = 8f;
			}
			else if (Main.npc[i].type == NPCID.FloatyGross)
			{
				single = 24f;
			}
			else if (Main.npc[i].type == NPCID.Steampunker)
			{
				single = 2f;
			}
			else if (Main.npc[i].type == NPCID.Spazmatism)
			{
				single = 30f;
			}
			else if (Main.npc[i].type == NPCID.EaterofSouls || Main.npc[i].type == NPCID.Crimera)
			{
				single = 26f;
			}
			else if (Main.npc[i].type == NPCID.Corruptor)
			{
				single = 14f;
			}
			else if (Main.npc[i].type == NPCID.DevourerHead || Main.npc[i].type == NPCID.DevourerBody || Main.npc[i].type == NPCID.DevourerTail)
			{
				single = 13f;
			}
			else if (Main.npc[i].type == NPCID.SeekerHead || Main.npc[i].type == NPCID.SeekerBody || Main.npc[i].type == NPCID.SeekerTail)
			{
				single = 13f;
			}
			else if (Main.npc[i].type == NPCID.DiggerHead || Main.npc[i].type == NPCID.DiggerBody || Main.npc[i].type == NPCID.DiggerTail)
			{
				single = 13f;
			}
			else if (Main.npc[i].type == NPCID.GiantWormHead || Main.npc[i].type == NPCID.GiantWormBody || Main.npc[i].type == NPCID.GiantWormTail)
			{
				single = 8f;
			}
			else if (Main.npc[i].type == NPCID.EaterofWorldsHead || Main.npc[i].type == NPCID.EaterofWorldsBody || Main.npc[i].type == NPCID.EaterofWorldsTail)
			{
				single = 26f;
			}
			else if (Main.npc[i].type == NPCID.AngryTrapper)
			{
				single = 4f;
			}
			else if (Main.npc[i].type == NPCID.MartianWalker)
			{
				single = 2f;
			}
			else if (Main.npc[i].type >= NPCID.SolarCrawltipedeHead && Main.npc[i].type <= NPCID.SolarCrawltipedeTail)
			{
				single = 18f;
			}
			else if (Main.npc[i].type == NPCID.Harpy)
			{
				single = 32f;
			}
			else if (Main.npc[i].type == NPCID.CaveBat || Main.npc[i].type == NPCID.JungleBat)
			{
				single = 4f;
			}
			else if (Main.npc[i].type == NPCID.Hellbat)
			{
				single = 10f;
			}
			else if (Main.npc[i].type == NPCID.Demon || Main.npc[i].type == NPCID.VoodooDemon || Main.npc[i].type == NPCID.RedDevil)
			{
				single = 14f;
			}
			else if (Main.npc[i].type == NPCID.BlueJellyfish || Main.npc[i].type == NPCID.PinkJellyfish || Main.npc[i].type == NPCID.GreenJellyfish)
			{
				single = 4f;
			}
			else if (Main.npc[i].type == NPCID.Shark)
			{
				single = 14f;
			}
			else if (Main.npc[i].type == NPCID.Antlion)
			{
				single = 4f;
			}
			else if (Main.npc[i].type == NPCID.SpikeBall)
			{
				single = -4f;
			}
			else if (Main.npc[i].type == NPCID.BlazingWheel)
			{
				single = -2f;
			}
			else if (Main.npc[i].type == NPCID.CursedHammer || Main.npc[i].type == NPCID.EnchantedSword)
			{
				single = 20f;
			}
			else if (Main.npc[i].type == NPCID.IceBat || Main.npc[i].type == NPCID.Lavabat || Main.npc[i].type == NPCID.VampireBat)
			{
				single = 10f;
			}
			else if (Main.npc[i].type == NPCID.GiantFlyingFox)
			{
				single = 6f;
			}
			else if (Main.npc[i].type == NPCID.GiantTortoise || Main.npc[i].type == NPCID.IceTortoise)
			{
				single = 4f;
			}
			else if (Main.npc[i].type == NPCID.WallCreeperWall || Main.npc[i].type == NPCID.JungleCreeperWall || Main.npc[i].type == NPCID.BlackRecluseWall || Main.npc[i].type == NPCID.BloodCrawlerWall)
			{
				single = 10f;
			}
			else if (Main.npc[i].type == NPCID.BoneSerpentHead || Main.npc[i].type == NPCID.BoneSerpentBody || Main.npc[i].type == NPCID.BoneSerpentTail)
			{
				single = 26f;
			}
			else if (Main.npc[i].type >= NPCID.WyvernHead && Main.npc[i].type <= NPCID.WyvernTail)
			{
				single = 56f;
			}
			else if (Main.npc[i].type >= NPCID.TheDestroyer && Main.npc[i].type <= NPCID.TheDestroyerTail)
			{
				single = 30f;
			}
			else if (Main.npc[i].type == NPCID.IceElemental)
			{
				single = 8f;
			}
			else if (Main.npc[i].type == NPCID.Herpling)
			{
				single = 6f;
			}
			else if (Main.npc[i].type == NPCID.Angler)
			{
				single = 2f;
			}
			else if (Main.npc[i].type == NPCID.SleepingAngler)
			{
				single = 6f;
			}
			if (Main.npc[i].townNPC && Main.npc[i].ai[0] == 5f)
			{
				single = single - 4f;
			}
			single = single * Main.npc[i].scale;
			return single;
		}

		protected void OldDrawBackground()
		{
		}

		public void oldDrawWater(bool bg = false, int Style = 0, float Alpha = 1f)
		{
		}

		public static void OpenClothesWindow()
		{
		}

		public static void OpenHairWindow()
		{
		}

		protected void OpenLegacySettings()
		{
			try
			{
				if (File.Exists(string.Concat(Main.SavePath, Path.DirectorySeparatorChar, "config.dat")))
				{
					using (FileStream fileStream = new FileStream(string.Concat(Main.SavePath, Path.DirectorySeparatorChar, "config.dat"), FileMode.Open))
					{
						using (BinaryReader binaryReader = new BinaryReader(fileStream))
						{
							int num = binaryReader.ReadInt32();
							if (num >= 68)
							{
								if (num >= 67)
								{
									Main.clientUUID = binaryReader.ReadString();
								}
								bool flag = binaryReader.ReadBoolean();
								Main.mouseColor.R = binaryReader.ReadByte();
								Main.mouseColor.G = binaryReader.ReadByte();
								Main.mouseColor.B = binaryReader.ReadByte();
								Main.soundVolume = binaryReader.ReadSingle();
								if (num >= 90)
								{
									Main.ambientVolume = binaryReader.ReadSingle();
								}
								Main.musicVolume = binaryReader.ReadSingle();
								Main.cUp = binaryReader.ReadString();
								Main.cDown = binaryReader.ReadString();
								Main.cLeft = binaryReader.ReadString();
								Main.cRight = binaryReader.ReadString();
								Main.cJump = binaryReader.ReadString();
								Main.cThrowItem = binaryReader.ReadString();
								if (num >= 1)
								{
									Main.cInv = binaryReader.ReadString();
								}
								if (num >= 12)
								{
									Main.cHeal = binaryReader.ReadString();
									Main.cMana = binaryReader.ReadString();
									Main.cBuff = binaryReader.ReadString();
								}
								if (num >= 13)
								{
									Main.cHook = binaryReader.ReadString();
								}
								Main.caveParallax = binaryReader.ReadSingle();
								if (num >= 2)
								{
									Main.fixedTiming = binaryReader.ReadBoolean();
								}
								if (num >= 91)
								{
									binaryReader.ReadBoolean();
								}
								if (num >= 4)
								{
									Main.SetDisplayMode(binaryReader.ReadInt32(), binaryReader.ReadInt32(), flag);
								}
								if (num >= 8)
								{
									Main.autoSave = binaryReader.ReadBoolean();
								}
								if (num >= 9)
								{
									Main.autoPause = binaryReader.ReadBoolean();
								}
								if (num >= 19)
								{
									Main.showItemText = binaryReader.ReadBoolean();
								}
								if (num >= 30)
								{
									Main.cTorch = binaryReader.ReadString();
									binaryReader.ReadByte();
									Main.qaStyle = binaryReader.ReadByte();
								}
								if (num >= 37)
								{
									Main.owBack = binaryReader.ReadBoolean();
								}
								if (num >= 39)
								{
									Lang.lang = binaryReader.ReadByte();
								}
								if (num >= 46)
								{
									Main.mapEnabled = binaryReader.ReadBoolean();
									Main.cMapStyle = binaryReader.ReadString();
									Main.cMapFull = binaryReader.ReadString();
									Main.cMapZoomIn = binaryReader.ReadString();
									Main.cMapZoomOut = binaryReader.ReadString();
									Main.cMapAlphaUp = binaryReader.ReadString();
									Main.cMapAlphaDown = binaryReader.ReadString();
								}
								if (num >= 89)
								{
									binaryReader.ReadInt32();
								}
								if (num >= 100)
								{
									Main.cSmart = binaryReader.ReadString();
									Main.cSmartToggle = binaryReader.ReadBoolean();
								}
								if (num >= 107)
								{
									Main.invasionProgressMode = binaryReader.ReadByte();
								}
								if (num >= 111)
								{
									Main.placementPreview = binaryReader.ReadBoolean();
								}
								if (num >= 111)
								{
									Main.placementPreview = binaryReader.ReadBoolean();
								}
								Main.SetFullScreen(flag);
							}
							binaryReader.Close();
						}
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

		public static void OpenPlayerSelect(Main.OnPlayerSelected method)
		{
			if (Main.gameMenu && (Main.menuMode == 10 || Main.menuMode == 14))
			{
				return;
			}
			Main._pendingCharacterSelect = method;
			if (Main.gameMenu)
			{
				Main.LoadPlayers();
				Main.menuMode = 1;
				return;
			}
			WorldGen.SaveAndQuit(() =>
				{
					Main.LoadPlayers();
					Main.menuMode = 1;
				});
		}

		protected void OpenRecent()
		{
			try
			{
				if (File.Exists(string.Concat(Main.SavePath, Path.DirectorySeparatorChar, "servers.dat")))
				{
					using (FileStream fileStream = new FileStream(string.Concat(Main.SavePath, Path.DirectorySeparatorChar, "servers.dat"), FileMode.Open))
					{
						using (BinaryReader binaryReader = new BinaryReader(fileStream))
						{
							binaryReader.ReadInt32();
							for (int i = 0; i < 10; i++)
							{
								Main.recentWorld[i] = binaryReader.ReadString();
								Main.recentIP[i] = binaryReader.ReadString();
								Main.recentPort[i] = binaryReader.ReadInt32();
							}
						}
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

		protected void OpenSettings()
		{
			if (File.Exists(string.Concat(Main.SavePath, Path.DirectorySeparatorChar, "config.dat")))
			{
				this.OpenLegacySettings();
				if (Main.SaveSettings())
				{
					File.Delete(string.Concat(Main.SavePath, Path.DirectorySeparatorChar, "config.dat"));
				}
				return;
			}
			Main.Configuration.Load();
			Main.Configuration.Get<bool>("SmartCursorToggle", ref Main.cSmartToggle);
			Main.Configuration.Get<bool>("MapEnabled", ref Main.mapEnabled);
			Main.Configuration.Get<int>("InvasionBarMode", ref Main.invasionProgressMode);
			Main.Configuration.Get<bool>("AutoSave", ref Main.autoSave);
			Main.Configuration.Get<bool>("AutoPause", ref Main.autoPause);
			Main.Configuration.Get<int>("Language", ref Lang.lang);
			Main.Configuration.Get<bool>("PlacementPreview", ref Main.placementPreview);
			Main.Configuration.Get<bool>("GoreVisualsAllowed", ref ChildSafety.Disabled);
			Main.Configuration.Get<float>("VolumeSound", ref Main.soundVolume);
			Main.Configuration.Get<float>("VolumeAmbient", ref Main.ambientVolume);
			Main.Configuration.Get<float>("VolumeMusic", ref Main.musicVolume);
			Main.Configuration.Get<string>("KeyUp", ref Main.cUp);
			Main.Configuration.Get<string>("KeyDown", ref Main.cDown);
			Main.Configuration.Get<string>("KeyLeft", ref Main.cLeft);
			Main.Configuration.Get<string>("KeyRight", ref Main.cRight);
			Main.Configuration.Get<string>("KeyJump", ref Main.cJump);
			Main.Configuration.Get<string>("KeyThrowItem", ref Main.cThrowItem);
			Main.Configuration.Get<string>("KeyInventory", ref Main.cInv);
			Main.Configuration.Get<string>("KeyQuickHeal", ref Main.cHeal);
			Main.Configuration.Get<string>("KeyQuickMana", ref Main.cMana);
			Main.Configuration.Get<string>("KeyQuickBuff", ref Main.cBuff);
			Main.Configuration.Get<string>("KeyUseHook", ref Main.cHook);
			Main.Configuration.Get<string>("KeyAutoSelect", ref Main.cTorch);
			Main.Configuration.Get<string>("KeySmartCursor", ref Main.cSmart);
			Main.Configuration.Get<string>("KeyMount", ref Main.cMount);
			Main.Configuration.Get<string>("KeyMapStyle", ref Main.cMapStyle);
			Main.Configuration.Get<string>("KeyFullscreenMap", ref Main.cMapFull);
			Main.Configuration.Get<string>("KeyMapZoomIn", ref Main.cMapZoomIn);
			Main.Configuration.Get<string>("KeyMapZoomOut", ref Main.cMapZoomOut);
			Main.Configuration.Get<string>("KeyMapAlphaUp", ref Main.cMapAlphaUp);
			Main.Configuration.Get<string>("KeyMapAlphaDown", ref Main.cMapAlphaDown);
			Main.Configuration.Get<bool>("WindowMaximized", ref Main.screenMaximized);
			Main.Configuration.Get<int>("GraphicsQuality", ref Main.qaStyle);
			Main.Configuration.Get<bool>("BackgroundEnabled", ref Main.owBack);
			Main.Configuration.Get<bool>("FrameSkip", ref Main.fixedTiming);
			Main.Configuration.Get<float>("Parallax", ref Main.caveParallax);
			Main.Configuration.Get<bool>("ShowItemText", ref Main.showItemText);
			Main.Configuration.Get<bool>("UseSmartCursorForCommonBlocks", ref Player.SmartCursorSettings.SmartBlocksEnabled);
			bool flag = false;
			Main.Configuration.Get<bool>("Fullscreen", ref flag);
			int preferredBackBufferWidth = 0, preferredBackBufferHeight = 0;
			Main.Configuration.Get<int>("DisplayWidth", ref preferredBackBufferWidth);
			Main.Configuration.Get<int>("DisplayHeight", ref preferredBackBufferHeight);
			Main.mouseColor.R = Main.Configuration.Get<byte>("MouseColorR", Main.mouseColor.R);
			Main.mouseColor.G = Main.Configuration.Get<byte>("MouseColorG", Main.mouseColor.G);
			Main.mouseColor.B = Main.Configuration.Get<byte>("MouseColorB", Main.mouseColor.B);
			Main.SetDisplayMode(preferredBackBufferWidth, preferredBackBufferHeight, flag);
			int num = 0;
			Main.Configuration.Get<int>("LastLaunchedVersion", ref num);
			if (num != Main.curRelease)
			{
				Main.SaveSettings();
			}
		}

		private static int PlayerListSortMethod(PlayerFileData data1, PlayerFileData data2)
		{
			return data1.Name.CompareTo(data2.Name);
		}

		protected Color QuickAlpha(Color oldColor, float Alpha)
		{
			Color r = oldColor;
			r.R = (byte)((float)r.R * Alpha);
			r.G = (byte)((float)r.G * Alpha);
			r.B = (byte)((float)r.B * Alpha);
			r.A = (byte)((float)r.A * Alpha);
			return r;
		}

		protected void QuitGame()
		{
			Main.SaveSettings();
		}

		protected Color RandColor()
		{
			int i;
			int num = 0;
			int num1 = 0;
			for (i = 0; num + i + num1 <= 150; i = Main.rand.Next(256))
			{
				num = Main.rand.Next(256);
				num1 = Main.rand.Next(256);
			}
			return new Color(num, num1, i, 255);
		}

		public static void RegisterItemAnimation(int index, DrawAnimation animation)
		{
		}

		protected void ReleaseTargets()
		{
		}

		protected void RenderBackground()
		{
		}

		protected void RenderBlack()
		{
		}

		public void RenderFrameBuffers()
		{
		}

		protected void RenderTiles()
		{
		}

		protected void RenderTiles2()
		{
		}

		protected void RenderWalls()
		{
		}

		protected void RenderWater()
		{
		}

		public static void ReportInvasionProgress(int progress, int progressMax, int icon, int progressWave)
		{
			Main.invasionProgress = progress;
			Main.invasionProgressMax = progressMax;
			Main.invasionProgressIcon = icon;
			Main.invasionProgressWave = progressWave;
			Main.invasionProgressDisplayLeft = 160;
		}

		public static void ResetKeyBindings()
		{
			Main.cUp = "W";
			Main.cDown = "S";
			Main.cLeft = "A";
			Main.cRight = "D";
			Main.cJump = "Space";
			Main.cThrowItem = "T";
			Main.cInv = "Escape";
			Main.cHeal = "H";
			Main.cMana = "J";
			Main.cBuff = "B";
			Main.cHook = "E";
			Main.cTorch = "LeftShift";
			Main.cSmart = "LeftControl";
			Main.cMount = "R";
		}

		public static Vector2 ReverseGravitySupport(Vector2 pos, float height = 0f)
		{
			if (Main.player[Main.myPlayer].gravDir != -1f)
			{
				return pos;
			}
			pos.Y = (float)Main.screenHeight - pos.Y - height;
			return pos;
		}

		public static Point ReverseGravitySupport(Point pos, int height = 0)
		{
			if (Main.player[Main.myPlayer].gravDir != -1f)
			{
				return pos;
			}
			pos.Y = Main.screenHeight - pos.Y - height;
			return pos;
		}

		public static Rectangle ReverseGravitySupport(Rectangle box)
		{
			if (Main.player[Main.myPlayer].gravDir != -1f)
			{
				return box;
			}
			box.Y = Main.screenHeight - box.Y - box.Height;
			return box;
		}

		public static Vector3 RgbToHsl(Color newColor)
		{
			float single;
			float r = (float)newColor.R;
			float g = (float)newColor.G;
			float b = (float)newColor.B;
			r = r / 255f;
			g = g / 255f;
			b = b / 255f;
			float single1 = Math.Max(r, g);
			single1 = Math.Max(single1, b);
			float single2 = Math.Min(r, g);
			single2 = Math.Min(single2, b);
			float single3 = 0f;
			float single4 = (single1 + single2) / 2f;
			if (single1 != single2)
			{
				float single5 = single1 - single2;
				single = ((double)single4 > 0.5 ? single5 / (2f - single1 - single2) : single5 / (single1 + single2));
				if (single1 == r)
				{
					float single6 = (g - b) / single5;
					float single7 = 0;
					if (g < b)
					{
						single7 = 6;
					}
					single3 = single6 + (float)single7;
				}
				if (single1 == g)
				{
					single3 = (b - r) / single5 + 2f;
				}
				if (single1 == b)
				{
					single3 = (r - g) / single5 + 4f;
				}
				single3 = single3 / 6f;
			}
			else
			{
				float single7 = 0f;
				single = single7;
				single3 = single7;
			}
			return new Vector3(single3, single, single4);
		}

		public static void SaveClothesWindow()
		{
			Main.clothesWindow = false;
			NetMessage.SendData((int)PacketTypes.PlayerInfo, -1, -1, Main.player[Main.myPlayer].name, Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
		}

		public static void SaveRecent()
		{
			Directory.CreateDirectory(Main.SavePath);
			try
			{
				File.SetAttributes(string.Concat(Main.SavePath, Path.DirectorySeparatorChar, "servers.dat"), FileAttributes.Normal);
			}
			catch (Exception ex)
			{
#if DEBUG
				Console.WriteLine(ex);
				System.Diagnostics.Debugger.Break();

#endif
			}
			try
			{
				using (FileStream fileStream = new FileStream(string.Concat(Main.SavePath, Path.DirectorySeparatorChar, "servers.dat"), FileMode.Create))
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
					{
						binaryWriter.Write(Main.curRelease);
						for (int i = 0; i < 10; i++)
						{
							binaryWriter.Write(Main.recentWorld[i]);
							binaryWriter.Write(Main.recentIP[i]);
							binaryWriter.Write(Main.recentPort[i]);
						}
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

		public static bool SaveSettings()
		{
			Main.Configuration.Put("SmartCursorToggle", Main.cSmartToggle);
			Main.Configuration.Put("MapEnabled", Main.mapEnabled);
			Main.Configuration.Put("InvasionBarMode", Main.invasionProgressMode);
			Main.Configuration.Put("AutoSave", Main.autoSave);
			Main.Configuration.Put("AutoPause", Main.autoPause);
			Main.Configuration.Put("Language", Lang.lang);
			Main.Configuration.Put("PlacementPreview", Main.placementPreview);
			Main.Configuration.Put("GoreVisualsAllowed", ChildSafety.Disabled);
			Main.Configuration.Put("VolumeSound", Main.soundVolume);
			Main.Configuration.Put("VolumeAmbient", Main.ambientVolume);
			Main.Configuration.Put("VolumeMusic", Main.musicVolume);
			Main.Configuration.Put("KeyUp", Main.cUp);
			Main.Configuration.Put("KeyDown", Main.cDown);
			Main.Configuration.Put("KeyLeft", Main.cLeft);
			Main.Configuration.Put("KeyRight", Main.cRight);
			Main.Configuration.Put("KeyJump", Main.cJump);
			Main.Configuration.Put("KeyThrowItem", Main.cThrowItem);
			Main.Configuration.Put("KeyInventory", Main.cInv);
			Main.Configuration.Put("KeyQuickHeal", Main.cHeal);
			Main.Configuration.Put("KeyQuickMana", Main.cMana);
			Main.Configuration.Put("KeyQuickBuff", Main.cBuff);
			Main.Configuration.Put("KeyUseHook", Main.cHook);
			Main.Configuration.Put("KeyAutoSelect", Main.cTorch);
			Main.Configuration.Put("KeySmartCursor", Main.cSmart);
			Main.Configuration.Put("KeyMount", Main.cMount);
			Main.Configuration.Put("KeyMapStyle", Main.cMapStyle);
			Main.Configuration.Put("KeyFullscreenMap", Main.cMapFull);
			Main.Configuration.Put("KeyMapZoomIn", Main.cMapZoomIn);
			Main.Configuration.Put("KeyMapZoomOut", Main.cMapZoomOut);
			Main.Configuration.Put("KeyMapAlphaUp", Main.cMapAlphaUp);
			Main.Configuration.Put("KeyMapAlphaDown", Main.cMapAlphaDown);
			Main.Configuration.Put("Fullscreen", false);
			Main.Configuration.Put("WindowMaximized", Main.screenMaximized);
			Main.Configuration.Put("DisplayWidth", 0);
			Main.Configuration.Put("DisplayHeight", 0);
			Main.Configuration.Put("GraphicsQuality", Main.qaStyle);
			Main.Configuration.Put("BackgroundEnabled", Main.owBack);
			Main.Configuration.Put("FrameSkip", Main.fixedTiming);
			Main.Configuration.Put("MouseColorR", Main.mouseColor.R);
			Main.Configuration.Put("MouseColorG", Main.mouseColor.G);
			Main.Configuration.Put("MouseColorB", Main.mouseColor.B);
			Main.Configuration.Put("Parallax", Main.caveParallax);
			Main.Configuration.Put("ShowItemText", Main.showItemText);
			Main.Configuration.Put("LastLaunchedVersion", Main.curRelease);
			Main.Configuration.Put("UseSmartCursorForCommonBlocks", Player.SmartCursorSettings.SmartBlocksEnabled);
			return Main.Configuration.Save(true);
		}

		public static void SelectPlayer(PlayerFileData data)
		{
			if (Main._pendingCharacterSelect != null)
			{
				Main._pendingCharacterSelect(data);
				Main._pendingCharacterSelect = null;
				return;
			}
			if (!Main.menuMultiplayer)
			{
				Main.ServerSideCharacter = false;
				Main.myPlayer = 0;
				data.SetAsActive();
				Main.player[Main.myPlayer].position = Vector2.Zero;
				Main.LoadWorlds();
				Main.menuMode = 6;
				return;
			}
			Main.ServerSideCharacter = false;
			data.SetAsActive();
			if (Main.autoJoin)
			{
				if (Netplay.SetRemoteIP(Main.getIP))
				{
					Main.menuMode = 10;
					Netplay.StartTcpClient();
				}
				Main.autoJoin = false;
				return;
			}
			if (Main.menuServer)
			{
				Main.LoadWorlds();
				Main.menuMode = 6;
				return;
			}
			Main.menuMode = 13;
			Main.ClearInput();
		}

		public static void SetDisplayMode(int width, int height, bool fullscreen)
		{
		}

		public static void SetFullScreen(bool fullscreen)
		{
			Main.SetDisplayMode(Main.PendingResolutionWidth, Main.PendingResolutionHeight, fullscreen);
		}

		public void SetNetPlayers(int mPlayers)
		{
			Main.maxNetPlayers = mPlayers;
		}

		public static void SetResolution(int width, int height)
		{
			Main.SetDisplayMode(width, height, false);
		}

		private static void SetTileValue()
		{
			Main.tileValue[TileID.Pots] = 100;
			Main.tileValue[TileID.Copper] = 200;
			Main.tileValue[TileID.Tin] = 210;
			Main.tileValue[TileID.Iron] = 220;
			Main.tileValue[TileID.Lead] = 230;
			Main.tileValue[TileID.Silver] = 240;
			Main.tileValue[TileID.Tungsten] = 250;
			Main.tileValue[TileID.Meteorite] = 300;
			Main.tileValue[TileID.Demonite] = 310;
			Main.tileValue[TileID.Crimtane] = 320;
			Main.tileValue[TileID.FossilOre] = 350;
			Main.tileValue[TileID.Gold] = 400;
			Main.tileValue[TileID.Platinum] = 410;
			Main.tileValue[TileID.Containers] = 500;
			Main.tileValue[TileID.Cobalt] = 600;
			Main.tileValue[TileID.Palladium] = 610;
			Main.tileValue[TileID.Mythril] = 620;
			Main.tileValue[TileID.Orichalcum] = 630;
			Main.tileValue[TileID.Adamantite] = 640;
			Main.tileValue[TileID.Titanium] = 650;
			Main.tileValue[TileID.Chlorophyte] = 700;
			Main.tileValue[TileID.Heart] = 800;
			Main.tileValue[TileID.LifeFruit] = 810;
		}

		protected void SetTitle()
		{
			Console.Title = Lang.title();
		}

		public static void SetupTileMerge()
		{
			int num = 419;
			Main.tileMerge = new bool[num][];
			for (int i = 0; i < (int)Main.tileMerge.Length; i++)
			{
				Main.tileMerge[i] = new bool[num];
			}
		}

		public void SetWorld(string world)
		{
			Main.ActiveWorldFileData = WorldFile.GetAllMetadata(world);
			Main.WorldPathClassic = world;
		}

		public void SetWorldName(string world)
		{
			Main.worldName = world;
		}

		public static Color shine(Color newColor, int type)
		{
			int r = newColor.R;
			int g = newColor.G;
			int b = newColor.B;
			float single = 0.6f;
			if (type == 25)
			{
				r = (int)((float)newColor.R * 0.95f);
				g = (int)((float)newColor.G * 0.85f);
				b = (int)((double)((float)newColor.B) * 1.1);
			}
			else if (type != 117)
			{
				if (type == 204)
				{
					single = 0.3f + (float)Main.mouseTextColor / 300f;
					r = (int)((float)newColor.R * (1.3f * single));
					if (r > 255)
					{
						r = 255;
					}
					return new Color(r, g, b, 255);
				}
				if (type == 211)
				{
					single = 0.3f + (float)Main.mouseTextColor / 300f;
					g = (int)((float)newColor.G * (1.5f * single));
					b = (int)((float)newColor.B * (1.1f * single));
				}
				else if (type == 147 || type == 161)
				{
					r = (int)((float)newColor.R * 1.1f);
					g = (int)((float)newColor.G * 1.12f);
					b = (int)((double)((float)newColor.B) * 1.15);
				}
				else if (type == 163)
				{
					r = (int)((float)newColor.R * 1.05f);
					g = (int)((float)newColor.G * 1.1f);
					b = (int)((double)((float)newColor.B) * 1.15);
				}
				else if (type == 164)
				{
					r = (int)((float)newColor.R * 1.1f);
					g = (int)((float)newColor.G * 1.1f);
					b = (int)((double)((float)newColor.B) * 1.2);
				}
				else if (type == 178)
				{
					single = 0.5f;
					r = (int)((float)newColor.R * (1f + single));
					g = (int)((float)newColor.G * (1f + single));
					b = (int)((float)newColor.B * (1f + single));
				}
				else if (type == 185 || type == 186)
				{
					single = 0.3f;
					r = (int)((float)newColor.R * (1f + single));
					g = (int)((float)newColor.G * (1f + single));
					b = (int)((float)newColor.B * (1f + single));
				}
				else if (type < 262 || type > 268)
				{
					r = (int)((float)newColor.R * (1f + single));
					g = (int)((float)newColor.G * (1f + single));
					b = (int)((float)newColor.B * (1f + single));
				}
				else
				{
					b = b + 100;
					r = r + 100;
					g = g + 100;
				}
			}
			else
			{
				r = (int)((float)newColor.R * 1.1f);
				g = (int)((float)newColor.G * 1f);
				b = (int)((double)((float)newColor.B) * 1.2);
			}
			if (r > 255)
			{
				r = 255;
			}
			if (g > 255)
			{
				g = 255;
			}
			if (b > 255)
			{
				b = 255;
			}
			newColor.R = (byte)r;
			newColor.G = (byte)g;
			newColor.B = (byte)b;
			return new Color((int)r, (int)g, (int)b, (int)newColor.A);
		}

		public static void snowing()
		{
			if (Main.gamePaused)
			{
				return;
			}
			if (Main.snowTiles > 0 && (double)Main.player[Main.myPlayer].position.Y < Main.worldSurface * 16)
			{
				int num = 800 / Main.snowTiles;
				int num1 = (int)(500f * ((float)Main.screenWidth / 1920f));
				num1 = (int)((float)num1 * (1f + 2f * Main.cloudAlpha));
				float single = 1f + 50f * Main.cloudAlpha;
				for (int i = 0; (float)i < single; i++)
				{
					try
					{
						if ((float)Main.snowDust >= (float)num1 * (Main.gfxQuality / 2f + 0.5f) + (float)num1 * 0.1f)
						{
							break;
						}
						else if (Main.rand.Next(num) == 0)
						{
							int x = Main.rand.Next(Main.screenWidth + 1000) - 500;
							int y = (int)Main.screenPosition.Y - Main.rand.Next(50);
							if (Main.player[Main.myPlayer].velocity.Y > 0f)
							{
								y = y - (int)Main.player[Main.myPlayer].velocity.Y;
							}
							if (Main.rand.Next(5) == 0)
							{
								x = Main.rand.Next(500) - 500;
							}
							else if (Main.rand.Next(5) == 0)
							{
								x = Main.rand.Next(500) + Main.screenWidth;
							}
							if (x < 0 || x > Main.screenWidth)
							{
								y = y + Main.rand.Next((int)((double)Main.screenHeight * 0.5)) + (int)((double)Main.screenHeight * 0.1);
							}
							x = x + (int)Main.screenPosition.X;
							int num2 = x / 16;
							int num3 = y / 16;
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
			}
		}

		protected void SortDrawCacheWorms()
		{
			List<int> drawCacheProjsBehindProjectiles = this.DrawCacheProjsBehindProjectiles;
			if (drawCacheProjsBehindProjectiles.Count == 0)
			{
				return;
			}
			List<List<int>> list = new List<List<int>>();
			for (int i = 0; i < drawCacheProjsBehindProjectiles.Count; i++)
			{
				int num = drawCacheProjsBehindProjectiles[i];
				if (Main.projectile[num].type == ProjectileID.StardustDragon4)
				{
					drawCacheProjsBehindProjectiles.Remove(num);
					List<int> list2 = new List<int>();
					list2.Insert(0, num);
					int byUUID = Projectile.GetByUUID(Main.projectile[num].owner, Main.projectile[num].ai[0]);
					while (byUUID >= 0 && !list2.Contains(byUUID) && Main.projectile[byUUID].active && Main.projectile[byUUID].type >= ProjectileID.StardustDragon1 && Main.projectile[byUUID].type <= ProjectileID.StardustDragon3)
					{
						list2.Insert(0, byUUID);
						drawCacheProjsBehindProjectiles.Remove(byUUID);
						byUUID = Projectile.GetByUUID(Main.projectile[byUUID].owner, Main.projectile[byUUID].ai[0]);
					}
					list.Add(list2);
					i = -1;
				}
			}
			List<int> list3 = new List<int>(this.DrawCacheProjsBehindProjectiles);
			list.Add(list3);
			this.DrawCacheProjsBehindProjectiles.Clear();
			for (int j = 0; j < list.Count; j++)
			{
				for (int k = 0; k < list[j].Count; k++)
				{
					this.DrawCacheProjsBehindProjectiles.Add(list[j][k]);
				}
			}
			for (int l = 0; l < this.DrawCacheProjsBehindProjectiles.Count; l++)
			{
				Projectile projectile = Main.projectile[this.DrawCacheProjsBehindProjectiles[l]];
				int byUUID2 = Projectile.GetByUUID(projectile.owner, projectile.ai[0]);
				if (projectile.type >= ProjectileID.StardustDragon2 && projectile.type <= ProjectileID.StardustDragon4 && byUUID2 >= 0 && ProjectileID.Sets.StardustDragon[Main.projectile[byUUID2].type])
				{
					Vector2 vector = Main.projectile[byUUID2].Center - projectile.Center;
					if (vector != Vector2.Zero)
					{
						float num2 = Main.projectile[byUUID2].scale * 16f;
						float num3 = vector.Length();
						float num4 = num2 - num3;
						if (num4 != 0f)
						{
							projectile.Center += Vector2.Normalize(vector) * -num4;
						}
					}
				}
			}
		}

		public static void startDedInput()
		{
			if (Console.IsInputRedirected == true)
			{
				Console.WriteLine("TerrariaServer is running in the background and input is disabled.");
				return;
			}
			ThreadPool.QueueUserWorkItem(new WaitCallback(Main.startDedInputCallBack), 1);
		}

		public static void startDedInputCallBack(object threadContext)
		{
			while (!Netplay.disconnect)
			{
				Console.Write(": ");
				string str = Console.ReadLine();
				if (str == null)
				{
					Console.WriteLine("Quit");
					WorldFile.saveWorld();
					Netplay.disconnect = true;
					break;
				}
				string lower = str.ToLower();
				if (!ServerApi.Hooks.InvokeServerCommand(str))
				{
					try
					{

						if (lower == "help")
						{
							Console.WriteLine("Available commands:");
							Console.WriteLine("");
							object[] objArray = new object[] { "help ", '\t', '\t', " Displays a list of commands." };
							Console.WriteLine(string.Concat(objArray));
							Console.WriteLine(string.Concat("playing ", '\t', " Shows the list of players"));
							object[] objArray1 = new object[] { "clear ", '\t', '\t', " Clear the console window." };
							Console.WriteLine(string.Concat(objArray1));
							object[] objArray2 = new object[] { "exit ", '\t', '\t', " Shutdown the server and save." };
							Console.WriteLine(string.Concat(objArray2));
							Console.WriteLine(string.Concat("exit-nosave ", '\t', " Shutdown the server without saving."));
							object[] objArray3 = new object[] { "save ", '\t', '\t', " Save the game world." };
							Console.WriteLine(string.Concat(objArray3));
							Console.WriteLine(string.Concat("kick <player> ", '\t', " Kicks a player from the server."));
							Console.WriteLine(string.Concat("ban <player> ", '\t', " Bans a player from the server."));
							Console.WriteLine(string.Concat("password", '\t', " Show password."));
							Console.WriteLine(string.Concat("password <pass>", '\t', " Change password."));
							object[] objArray4 = new object[] { "version", '\t', '\t', " Print version number." };
							Console.WriteLine(string.Concat(objArray4));
							object[] objArray5 = new object[] { "time", '\t', '\t', " Display game time." };
							Console.WriteLine(string.Concat(objArray5));
							object[] objArray6 = new object[] { "port", '\t', '\t', " Print the listening port." };
							Console.WriteLine(string.Concat(objArray6));
							Console.WriteLine(string.Concat("maxplayers", '\t', " Print the max number of players."));
							Console.WriteLine(string.Concat("say <words>", '\t', " Send a message."));
							object[] objArray7 = new object[] { "motd", '\t', '\t', " Print MOTD." };
							Console.WriteLine(string.Concat(objArray7));
							Console.WriteLine(string.Concat("motd <words>", '\t', " Change MOTD."));
							object[] objArray8 = new object[] { "dawn", '\t', '\t', " Change time to dawn." };
							Console.WriteLine(string.Concat(objArray8));
							object[] objArray9 = new object[] { "noon", '\t', '\t', " Change time to noon." };
							Console.WriteLine(string.Concat(objArray9));
							object[] objArray10 = new object[] { "dusk", '\t', '\t', " Change time to dusk." };
							Console.WriteLine(string.Concat(objArray10));
							Console.WriteLine(string.Concat("midnight", '\t', " Change time to midnight."));
							object[] objArray11 = new object[] { "settle", '\t', '\t', " Settle all water." };
							Console.WriteLine(string.Concat(objArray11));
						}
						else if (lower == "settle")
						{
							if (Liquid.panicMode)
							{
								Console.WriteLine("Water is already settling");
							}
							else
							{
								Liquid.StartPanic();
							}
						}
						else if (lower == "dawn")
						{
							Main.dayTime = true;
							Main.time = 0;
							NetMessage.SendData((int)PacketTypes.WorldInfo, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						}
						else if (lower == "dusk")
						{
							Main.dayTime = false;
							Main.time = 0;
							NetMessage.SendData((int)PacketTypes.WorldInfo, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						}
						else if (lower == "noon")
						{
							Main.dayTime = true;
							Main.time = 27000;
							NetMessage.SendData((int)PacketTypes.WorldInfo, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						}
						else if (lower == "midnight")
						{
							Main.dayTime = false;
							Main.time = 16200;
							NetMessage.SendData((int)PacketTypes.WorldInfo, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						}
						else if (lower == "exit-nosave")
						{
							Netplay.disconnect = true;
						}
						else if (lower == "exit")
						{
							WorldFile.saveWorld();
							Netplay.disconnect = true;
						}
						else if (lower == "fps")
						{
							if (Main.dedServFPS)
							{
								Main.dedServCount1 = 0;
								Main.dedServCount2 = 0;
								Main.dedServFPS = false;
							}
							else
							{
								Main.dedServFPS = true;
								Main.fpsTimer.Reset();
							}
						}
						else if (lower == "save")
						{
							WorldFile.saveWorld();
						}
						else if (lower == "time")
						{
							string str1 = "AM";
							double num = Main.time;
							if (!Main.dayTime)
							{
								num = num + 54000;
							}
							num = num / 86400 * 24;
							num = num - 7.5 - 12;
							if (num < 0)
							{
								num = num + 24;
							}
							if (num >= 12)
							{
								str1 = "PM";
							}
							int num1 = (int)num;
							double num2 = num - (double)num1;
							num2 = (double)((int)(num2 * 60));
							string str2 = string.Concat(num2);
							if (num2 < 10)
							{
								str2 = string.Concat("0", str2);
							}
							if (num1 > 12)
							{
								num1 = num1 - 12;
							}
							if (num1 == 0)
							{
								num1 = 12;
							}
							object[] objArray12 = new object[] { "Time: ", num1, ":", str2, " ", str1 };
							Console.WriteLine(string.Concat(objArray12));
						}
						else if (lower == "maxplayers")
						{
							Console.WriteLine(string.Concat("Player limit: ", Main.maxNetPlayers));
						}
						else if (lower == "port")
						{
							Console.WriteLine(string.Concat("Port: ", Netplay.ListenPort));
						}
						else if (lower == "version")
						{
							Console.WriteLine(string.Concat("Terraria Server ", Main.versionNumber));
						}
						else if (lower == "clear")
						{
							try
							{
								Console.Clear();
							}
							catch (Exception ex)
							{
#if DEBUG
								Console.WriteLine(ex);
								System.Diagnostics.Debugger.Break();

#endif
							}
						}
						else if (lower == "playing")
						{
							int num3 = 0;
							for (int i = 0; i < 255; i++)
							{
								if (Main.player[i].active)
								{
									num3++;
									object[] remoteAddress = new object[]
									{ Main.player[i].name, " (", Netplay.Clients[i].Socket.GetRemoteAddress(), ")" };
									Console.WriteLine(string.Concat(remoteAddress));
								}
							}
							if (num3 == 0)
							{
								Console.WriteLine("No players connected.");
							}
							else if (num3 != 1)
							{
								Console.WriteLine(string.Concat(num3, " players connected."));
							}
							else
							{
								Console.WriteLine("1 player connected.");
							}
						}
						else if (lower != "")
						{
							if (lower == "motd")
							{
								if (Main.motd != "")
								{
									Console.WriteLine(string.Concat("MOTD: ", Main.motd));
								}
								else
								{
									Console.WriteLine(string.Concat("Welcome to ", Main.worldName, "!"));
								}
							}
							else if (lower.Length >= 5 && lower.Substring(0, 5) == "motd ")
							{
								Main.motd = str.Substring(5);
							}
							else if (lower.Length == 8 && lower.Substring(0, 8) == "password")
							{
								if (Netplay.ServerPassword != "")
								{
									Console.WriteLine(string.Concat("Password: ", Netplay.ServerPassword));
								}
								else
								{
									Console.WriteLine("No password set.");
								}
							}
							else if (lower.Length >= 9 && lower.Substring(0, 9) == "password ")
							{
								string str3 = str.Substring(9);
								if (str3 != "")
								{
									Netplay.ServerPassword = str3;
									Console.WriteLine(string.Concat("Password: ", Netplay.ServerPassword));
								}
								else
								{
									Netplay.ServerPassword = "";
									Console.WriteLine("Password disabled.");
								}
							}
							else if (lower == "say")
							{
								Console.WriteLine("Usage: say <words>");
							}
							else if (lower.Length >= 4 && lower.Substring(0, 4) == "say ")
							{
								string str4 = str.Substring(4);
								if (str4 != "")
								{
									Console.WriteLine(string.Concat("<Server> ", str4));
									NetMessage.SendData((int)PacketTypes.ChatText, -1, -1, string.Concat("<Server> ", str4), 255, 255f, 240f, 20f, 0, 0, 0);
								}
								else
								{
									Console.WriteLine("Usage: say <words>");
								}
							}
							else if (lower.Length == 4 && lower.Substring(0, 4) == "kick")
							{
								Console.WriteLine("Usage: kick <player>");
							}
							else if (lower.Length >= 5 && lower.Substring(0, 5) == "kick ")
							{
								string lower1 = lower.Substring(5);
								lower1 = lower1.ToLower();
								if (lower1 != "")
								{
									for (int j = 0; j < 255; j++)
									{
										if (Main.player[j].active && Main.player[j].name.ToLower() == lower1)
										{
											NetMessage.SendData((int)PacketTypes.Disconnect, j, -1, "Kicked from server.", 0, 0f, 0f, 0f, 0, 0, 0);
										}
									}
								}
								else
								{
									Console.WriteLine("Usage: kick <player>");
								}
							}
							else if (lower.Length == 3 && lower.Substring(0, 3) == "ban")
							{
								Console.WriteLine("Usage: ban <player>");
							}
							else if (lower.Length < 4 || !(lower.Substring(0, 4) == "ban "))
							{
								Console.WriteLine("Invalid command.");
							}
							else
							{
								string lower2 = lower.Substring(4);
								lower2 = lower2.ToLower();
								if (lower2 != "")
								{
									for (int k = 0; k < 255; k++)
									{
										if (Main.player[k].active && Main.player[k].name.ToLower() == lower2)
										{
											Netplay.AddBan(k);
											NetMessage.SendData((int)PacketTypes.Disconnect, k, -1, "Banned from server.", 0, 0f, 0f, 0f, 0, 0, 0);
										}
									}
								}
								else
								{
									Console.WriteLine("Usage: ban <player>");
								}
							}
						}
					}
					catch
					{
						Console.WriteLine("Invalid command.");
					}
				}
			}
		}

		public static void StartInvasion(int type = 1, int? invasionSize = null)
		{
			if (Main.invasionType == 0)
			{
				int num = 0;
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active && Main.player[i].statLifeMax >= 200)
					{
						num++;
					}
				}
				if (num > 0)
				{
					Main.invasionType = type;

					if (invasionSize.HasValue == true) 
					{
						Main.invasionSize = invasionSize.Value;
					} 
					else
					{
						Main.invasionSize = 80 + 40 * num;
					}

					if (type == 3)
					{
						Main.invasionSize = Main.invasionSize + 40 + 20 * num;
					}
					if (type == 4)
					{
						Main.invasionSize = 160 + 40 * num;
					}
					Main.invasionSizeStart = Main.invasionSize;
					Main.invasionProgress = 0;
					Main.invasionProgressIcon = type + 2;
					Main.invasionProgressWave = 0;
					Main.invasionProgressMax = Main.invasionSizeStart;
					Main.invasionWarn = 0;
					if (type == 4)
					{
						Main.invasionX = (double)(Main.spawnTileX - 1);
						Main.invasionWarn = 2;
						return;
					}
					if (Main.rand.Next(2) == 0)
					{
						Main.invasionX = 0;
						return;
					}
					Main.invasionX = (double)Main.maxTilesX;
				}
			}
		}

		public static void startPumpkinMoon()
		{
			Main.pumpkinMoon = true;
			Main.snowMoon = false;
			Main.bloodMoon = false;
			if (Main.netMode != 1)
			{
				NPC.waveKills = 0f;
				NPC.waveCount = 1;
				string str = string.Concat("First Wave: ", Main.npcName[305]);
				if (Main.netMode == 0)
				{
					Main.NewText(str, 175, 75, 255, false);
					return;
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData((int)PacketTypes.ChatText, -1, -1, str, 255, 175f, 75f, 255f, 0, 0, 0);
				}
			}
		}

		public static void StartRain()
		{
			int num = 86400;
			int num1 = num / 24;
			Main.rainTime = Main.rand.Next(num1 * 8, num);
			if (Main.rand.Next(3) == 0)
			{
				Main.rainTime = Main.rainTime + Main.rand.Next(0, num1);
			}
			if (Main.rand.Next(4) == 0)
			{
				Main.rainTime = Main.rainTime + Main.rand.Next(0, num1 * 2);
			}
			if (Main.rand.Next(5) == 0)
			{
				Main.rainTime = Main.rainTime + Main.rand.Next(0, num1 * 2);
			}
			if (Main.rand.Next(6) == 0)
			{
				Main.rainTime = Main.rainTime + Main.rand.Next(0, num1 * 3);
			}
			if (Main.rand.Next(7) == 0)
			{
				Main.rainTime = Main.rainTime + Main.rand.Next(0, num1 * 4);
			}
			if (Main.rand.Next(8) == 0)
			{
				Main.rainTime = Main.rainTime + Main.rand.Next(0, num1 * 5);
			}
			float single = 1f;
			if (Main.rand.Next(2) == 0)
			{
				single = single + 0.05f;
			}
			if (Main.rand.Next(3) == 0)
			{
				single = single + 0.1f;
			}
			if (Main.rand.Next(4) == 0)
			{
				single = single + 0.15f;
			}
			if (Main.rand.Next(5) == 0)
			{
				single = single + 0.2f;
			}
			Main.rainTime = (int)((float)Main.rainTime * single);
			Main.ChangeRain();
			Main.raining = true;
		}

		public static void StartSlimeRain(bool announce = true)
		{
			if (Main.slimeRain)
			{
				return;
			}
			if (Main.netMode == 1)
			{
				Main.slimeRainTime = 54000;
				Main.slimeRain = true;
				return;
			}
			if (Main.raining)
			{
				return;
			}
			Main.slimeRainTime = (double)Main.rand.Next(32400, 54000);
			Main.slimeRain = true;
			Main.slimeRainKillCount = 0;
			if (Main.netMode == 0)
			{
				if (announce)
				{
					Main.slimeWarningTime = Main.slimeWarningDelay;
					return;
				}
			}
			else if (announce)
			{
				Main.slimeWarningTime = Main.slimeWarningDelay;
				NetMessage.SendData((int)PacketTypes.WorldInfo, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
			}
		}

		public static void startSnowMoon()
		{
			Main.snowMoon = true;
			Main.pumpkinMoon = false;
			Main.bloodMoon = false;
			if (Main.netMode != 1)
			{
				NPC.waveKills = 0f;
				NPC.waveCount = 1;
				string str = "First Wave: Zombie Elf and Gingerbread Man";
				if (Main.netMode == 0)
				{
					Main.NewText(str, 175, 75, 255, false);
					return;
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData((int)PacketTypes.ChatText, -1, -1, str, 255, 175f, 75f, 255f, 0, 0, 0);
				}
			}
		}

		public static void stopMoonEvent()
		{
			if (Main.pumpkinMoon)
			{
				Main.pumpkinMoon = false;
				if (Main.netMode != 1)
				{
					NPC.waveKills = 0f;
					NPC.waveCount = 0;
				}
			}
			if (Main.snowMoon)
			{
				Main.snowMoon = false;
				if (Main.netMode != 1)
				{
					NPC.waveKills = 0f;
					NPC.waveCount = 0;
				}
			}
		}

		public static void StopRain()
		{
			Main.rainTime = 0;
			Main.raining = false;
			Main.maxRaining = 0f;
		}

		public static void StopSlimeRain(bool announce = true)
		{
			if (!Main.slimeRain)
			{
				return;
			}
			if (Main.netMode == 1)
			{
				Main.slimeRainTime = 0;
				Main.slimeRain = false;
				return;
			}
			int num = 86400 * 7;
			if (Main.hardMode)
			{
				num = num * 2;
			}
			Main.slimeRainTime = (double)(-Main.rand.Next(3024, 6048) * 100);
			Main.slimeRain = false;
			if (Main.netMode == 0)
			{
				if (announce)
				{
					Main.slimeWarningTime = Main.slimeWarningDelay;
				}
				return;
			}
			if (announce)
			{
				Main.slimeWarningTime = Main.slimeWarningDelay;
				NetMessage.SendData((int)PacketTypes.WorldInfo, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
			}
		}

		public static void Sundialing()
		{
			if (Main.sundialCooldown == 0)
			{
				if (Main.netMode == 1)
				{
					NetMessage.SendData((int)PacketTypes.NpcSpecial, -1, -1, "", Main.myPlayer, 3f, 0f, 0f, 0, 0, 0);
					return;
				}
				Main.fastForwardTime = true;
				Main.sundialCooldown = 8;
				NetMessage.SendData((int)PacketTypes.WorldInfo, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
			}
		}

		public static void SwitchNetMode(int mode)
		{
			if (mode >= 0 && mode <= 2)
			{
				Main._targetNetMode = mode;
				Main._hasPendingNetmodeChange = true;
			}
		}

		public static void SyncAnInvasion(int toWho)
		{
			if (Main.snowMoon)
			{
				int num = (new int[] { 0, 25, 15, 10, 30, 100, 160, 180, 200, 250, 300, 375, 450, 525, 675, 850, 1025, 1325, 1550, 2000, 0 })[NPC.waveCount];
				NetMessage.SendData((int)PacketTypes.ReportInvasionProgress, toWho, -1, "", (int)NPC.waveKills, (float)num, 1f, (float)NPC.waveCount, 0, 0, 0);
				return;
			}
			if (Main.pumpkinMoon)
			{
				int num1 = (new int[] { 0, 25, 40, 50, 80, 100, 160, 180, 200, 250, 300, 375, 450, 525, 675, 0 })[NPC.waveCount];
				NetMessage.SendData((int)PacketTypes.ReportInvasionProgress, toWho, -1, "", (int)NPC.waveKills, (float)num1, 2f, (float)NPC.waveCount, 0, 0, 0);
				return;
			}
			if (Main.invasionType > 0)
			{
				int num2 = 1;
				if (Main.invasionType != 0 && Main.invasionSizeStart != 0)
				{
					num2 = Main.invasionSizeStart;
				}
				NetMessage.SendData((int)PacketTypes.ReportInvasionProgress, toWho, -1, "", Main.invasionSizeStart - Main.invasionSize, (float)num2, (float)(Main.invasionType + 2), 0f, 0, 0, 0);
			}
		}

		public static void TeleportEffect(Rectangle effectRect, int Style, int extraInfo = 0)
		{

		}

		protected void tileColorCheck(int t, int c)
		{
		}

		public static void ToggleFullScreen()
		{
		}

		protected void treeColorCheck(int t, int c)
		{
		}

		protected void UnloadContent()
		{
		}

		protected void Update()
		{
			if (Main._hasPendingNetmodeChange)
			{
				Main.netMode = Main._targetNetMode;
				Main._hasPendingNetmodeChange = false;
			}
			Main.tileNoFail[TileID.LivingMahoganyLeaves] = true;
			Main.ignoreErrors = true;
			if (!Main.expertMode)
			{
				Main.damageMultiplier = 1f;
				Main.knockBackMultiplier = 1f;
			}
			else
			{
				Main.damageMultiplier = Main.expertDamage;
				Main.knockBackMultiplier = Main.expertKnockBack;
			}
			if (!Main.GlobalTimerPaused)
			{
				Main.GlobalTime = Main.GlobalTime + 0.0166666675f;
				if (Main.GlobalTime > 3600f)
				{
					Main.GlobalTime = Main.GlobalTime - 3600f;
				}
			}
			if (Main.netMode == 2)
			{
				Main.cloudAlpha = Main.maxRaining;
			}
			if (Main.netMode != 1)
			{
				this.updateCloudLayer();
			}
			this.UpdateWeather();
			Main.Ambience();
			if (Main.netMode != 2)
			{
				if (!Main.ignoreErrors)
				{
					Main.snowing();
				}
				else
				{
					try
					{
						Main.snowing();
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
			if (Main.chTitle)
			{
				Main.chTitle = false;
				this.SetTitle();
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			WorldGen.destroyObject = false;
			if (Main.gameMenu)
			{
				Main.mapFullscreen = false;
			}
			if (Main.dedServ)
			{
				if (!Main.dedServFPS)
				{
					if (Main.fpsTimer.IsRunning)
					{
						Main.fpsTimer.Stop();
					}
					Main.updateTime = 0;
				}
				else
				{
					Main.updateTime = Main.updateTime + 1;
					if (!Main.fpsTimer.IsRunning)
					{
						Main.fpsTimer.Restart();
					}
					if (Main.fpsTimer.ElapsedMilliseconds >= (long)1000)
					{
						Main.dedServCount1 = Main.dedServCount1 + Main.updateTime;
						Main.dedServCount2 = Main.dedServCount2 + 1;
						float single = (float)Main.dedServCount1 / (float)Main.dedServCount2;
						object[] objArray = new object[] { Main.updateTime, "  (", single, ")" };
						Console.WriteLine(string.Concat(objArray));
						Main.updateTime = 0;
						Main.fpsTimer.Restart();
					}
				}
			}
			if (!Main.dedServ)
			{

				if (Main.treeMntBG[1] == 94 || Main.treeMntBG[1] >= 114 && Main.treeMntBG[1] <= 116)
				{
					Main.bgFrameCounter[0] = Main.bgFrameCounter[0] + 1;
					if (Main.bgFrameCounter[0] >= 6)
					{
						Main.bgFrameCounter[0] = 0;
						Main.bgFrame[0] = Main.bgFrame[0] + 1;
						if (Main.bgFrame[0] >= 4)
						{
							Main.bgFrame[0] = 0;
						}
					}
					if (Main.bgFrame[0] == 0)
					{
						Main.treeMntBG[1] = 94;
					}
					else if (Main.bgFrame[0] == 1)
					{
						Main.treeMntBG[1] = 114;
					}
					else if (Main.bgFrame[0] != 2)
					{
						Main.treeMntBG[1] = 116;
					}
					else
					{
						Main.treeMntBG[1] = 115;
					}
					if (Main.bgFrame[0] == 0)
					{
						Main.treeMntBG[0] = 93;
					}
					else if (Main.bgFrame[0] == 1)
					{
						Main.treeMntBG[0] = 168;
					}
					else if (Main.bgFrame[0] != 2)
					{
						Main.treeMntBG[0] = 170;
					}
					else
					{
						Main.treeMntBG[0] = 169;
					}
				}
				if (Main.treeMntBG[1] >= 180 && Main.treeMntBG[1] <= 183)
				{
					Main.bgFrameCounter[0] = Main.bgFrameCounter[0] + 1;
					if (Main.bgFrameCounter[0] >= 6)
					{
						Main.bgFrameCounter[0] = 0;
						Main.bgFrame[0] = Main.bgFrame[0] + 1;
						if (Main.bgFrame[0] >= 4)
						{
							Main.bgFrame[0] = 0;
						}
					}
					if (Main.bgFrame[0] == 0)
					{
						Main.treeMntBG[1] = 180;
					}
					else if (Main.bgFrame[0] == 1)
					{
						Main.treeMntBG[1] = 181;
					}
					else if (Main.bgFrame[0] != 2)
					{
						Main.treeMntBG[1] = 183;
					}
					else
					{
						Main.treeMntBG[1] = 182;
					}
				}
				Animation.UpdateAll();
				this.UpdateMusic();
				if (Main.showSplash)
				{
					return;
				}
				if (!Main.gameMenu && Main.netMode == 1)
				{
					if (!Main.saveTime.IsRunning)
					{
						Main.saveTime.Start();
					}
					if (Main.saveTime.ElapsedMilliseconds > (long)300000)
					{
						Main.saveTime.Reset();
						WorldGen.saveToonWhilePlaying();
					}
				}
				else if (!Main.gameMenu && Main.autoSave)
				{
					if (!Main.saveTime.IsRunning)
					{
						Main.saveTime.Start();
					}
					if (Main.saveTime.ElapsedMilliseconds > (long)600000)
					{
						Main.saveTime.Reset();
						WorldGen.saveToonWhilePlaying();
						WorldGen.saveAndPlay();
					}
				}
				else if (Main.saveTime.IsRunning)
				{
					Main.saveTime.Stop();
				}
				if (Main.teamCooldown > 0)
				{
					Main.teamCooldown = Main.teamCooldown - 1;
				}
				Main.updateTime = Main.updateTime + 1;
				if (Main.fpsTimer.ElapsedMilliseconds >= (long)1000)
				{
					if ((float)Main.fpsCount >= 30f + 30f * Main.gfxQuality)
					{
						Main.gfxQuality = Main.gfxQuality + Main.gfxRate;
						Main.gfxRate = Main.gfxRate + 0.005f;
					}
					else if ((float)Main.fpsCount < 29f + 30f * Main.gfxQuality)
					{
						Main.gfxRate = 0.01f;
						Main.gfxQuality = Main.gfxQuality - 0.1f;
					}
					if (Main.gfxQuality < 0f)
					{
						Main.gfxQuality = 0f;
					}
					if (Main.gfxQuality > 1f)
					{
						Main.gfxQuality = 1f;
					}
					Main.updateRate = Main.uCount;
					Main.frameRate = Main.fpsCount;
					Main.fpsCount = 0;
					Main.fpsTimer.Restart();
					Main.updateTime = 0;
					Main.drawTime = 0;
					Main.uCount = 0;
					if ((double)Main.gfxQuality >= 0.8)
					{
						Main.mapTimeMax = 0;
					}
					else
					{
						Main.mapTimeMax = (int)((1f - Main.gfxQuality) * 60f);
					}
					int num = Main.netMode;
				}
				if (Main.fixedTiming)
				{
					float single1 = 16f;
					float elapsedMilliseconds = (float)Main.updateTimer.ElapsedMilliseconds;
					if (elapsedMilliseconds + Main.uCarry < single1 && !Main.superFast)
					{
						Main.drawSkip = true;
						return;
					}
					Main.uCarry = Main.uCarry + (elapsedMilliseconds - single1);
					if (Main.uCarry > 1000f)
					{
						Main.uCarry = 1000f;
					}
					Main.updateTimer.Restart();
				}
				Main.uCount = Main.uCount + 1;
				Main.drawSkip = false;
				if (Main.qaStyle == 1)
				{
					Main.gfxQuality = 1f;
				}
				else if (Main.qaStyle == 2)
				{
					Main.gfxQuality = 0.5f;
				}
				else if (Main.qaStyle == 3)
				{
					Main.gfxQuality = 0f;
				}
				Main.numDust = (int)(6000f * (Main.gfxQuality * 0.7f + 0.3f));
				if ((double)Main.gfxQuality < 0.9)
				{
					Main.numDust = (int)((float)Main.numDust * Main.gfxQuality);
				}
				if (Main.numDust < 1000)
				{
					Main.numDust = 1000;
				}
				Liquid.maxLiquid = (int)(2500f + 2500f * Main.gfxQuality);
				Liquid.cycles = (int)(17f - 10f * Main.gfxQuality);
				if (Liquid.quickSettle)
				{
					Liquid.maxLiquid = Liquid.resLiquid;
					Liquid.cycles = 1;
				}
				Main.hasFocus = true;
				if (!Main.gameMenu || Main.netMode == 2)
				{
					WorldFile.tempRaining = Main.raining;
					WorldFile.tempRainTime = Main.rainTime;
					WorldFile.tempMaxRain = Main.maxRaining;
				}
				ScreenObstruction.Update();
				ScreenDarkness.Update();
				MoonlordDeathDrama.Update();
				Main.CursorColor();
				Main.mouseTextColor = (byte)(Main.mouseTextColor + (byte)Main.mouseTextColorChange);
				if (Main.mouseTextColor >= 250)
				{
					Main.mouseTextColorChange = -4;
				}
				if (Main.mouseTextColor <= 175)
				{
					Main.mouseTextColorChange = 4;
				}
				Main.demonTorch = Main.demonTorch + (float)Main.demonTorchDir * 0.01f;
				if (Main.demonTorch > 1f)
				{
					Main.demonTorch = 1f;
					Main.demonTorchDir = -1;
				}
				if (Main.demonTorch < 0f)
				{
					Main.demonTorch = 0f;
					Main.demonTorchDir = 1;
				}
				Main.martianLight = Main.martianLight + (float)Main.martianLightDir * 0.015f;
				if (Main.martianLight > 1f)
				{
					Main.martianLight = 1f;
					Main.martianLightDir = -1;
				}
				if (Main.martianLight < 0f)
				{
					Main.martianLight = 0f;
					Main.martianLightDir = 1;
				}
				int num1 = 7;
				if (this.DiscoStyle == 0)
				{
					Main.DiscoG = Main.DiscoG + num1;
					if (Main.DiscoG >= 255)
					{
						Main.DiscoG = 255;
						Main discoStyle = this;
						discoStyle.DiscoStyle = discoStyle.DiscoStyle + 1;
					}
				}
				if (this.DiscoStyle == 1)
				{
					Main.DiscoR = Main.DiscoR - num1;
					if (Main.DiscoR <= 0)
					{
						Main.DiscoR = 0;
						Main main = this;
						main.DiscoStyle = main.DiscoStyle + 1;
					}
				}
				if (this.DiscoStyle == 2)
				{
					Main.DiscoB = Main.DiscoB + num1;
					if (Main.DiscoB >= 255)
					{
						Main.DiscoB = 255;
						Main discoStyle1 = this;
						discoStyle1.DiscoStyle = discoStyle1.DiscoStyle + 1;
					}
				}
				if (this.DiscoStyle == 3)
				{
					Main.DiscoG = Main.DiscoG - num1;
					if (Main.DiscoG <= 0)
					{
						Main.DiscoG = 0;
						Main main1 = this;
						main1.DiscoStyle = main1.DiscoStyle + 1;
					}
				}
				if (this.DiscoStyle == 4)
				{
					Main.DiscoR = Main.DiscoR + num1;
					if (Main.DiscoR >= 255)
					{
						Main.DiscoR = 255;
						Main discoStyle2 = this;
						discoStyle2.DiscoStyle = discoStyle2.DiscoStyle + 1;
					}
				}
				if (this.DiscoStyle == 5)
				{
					Main.DiscoB = Main.DiscoB - num1;
					if (Main.DiscoB <= 0)
					{
						Main.DiscoB = 0;
						this.DiscoStyle = 0;
					}
				}
				if (Main.gFadeDir != 1)
				{
					Main.gFader = Main.gFader - 0.1f;
					Main.gFade = (byte)Main.gFader;
					if (Main.gFade < 100)
					{
						Main.gFadeDir = 1;
					}
				}
				else
				{
					Main.gFader = Main.gFader + 0.1f;
					Main.gFade = (byte)Main.gFader;
					if (Main.gFade > 150)
					{
						Main.gFadeDir = 0;
					}
				}
				Main.wFrCounter = Main.wFrCounter + Main.windSpeed * 2f;
				if (Main.wFrCounter > 4f)
				{
					Main.wFrCounter = 0f;
					Main.wFrame = Main.wFrame + 1f;
				}
				if (Main.wFrCounter < 0f)
				{
					Main.wFrCounter = 4f;
					Main.wFrame = Main.wFrame - 1f;
				}
				if (Main.wFrame > 16f)
				{
					Main.wFrame = 1f;
				}
				if (Main.wFrame < 1f)
				{
					Main.wFrame = 16f;
				}
				this.waterfallManager.UpdateFrame();
				Main.wallFrameCounter[WallID.Waterfall] = (byte)(Main.wallFrameCounter[WallID.Waterfall] + 1);
				if (Main.wallFrameCounter[WallID.Waterfall] >= 5)
				{
					Main.wallFrameCounter[WallID.Waterfall] = 0;
					Main.wallFrame[WallID.Waterfall] = (byte)(Main.wallFrame[WallID.Waterfall] + 1);
					if (Main.wallFrame[WallID.Waterfall] > 7)
					{
						Main.wallFrame[WallID.Waterfall] = 0;
					}
				}
				Main.wallFrameCounter[WallID.Lavafall] = (byte)(Main.wallFrameCounter[WallID.Lavafall] + 1);
				if (Main.wallFrameCounter[WallID.Lavafall] >= 10)
				{
					Main.wallFrameCounter[WallID.Lavafall] = 0;
					Main.wallFrame[WallID.Lavafall] = (byte)(Main.wallFrame[WallID.Lavafall] + 1);
					if (Main.wallFrame[WallID.Lavafall] > 7)
					{
						Main.wallFrame[WallID.Lavafall] = 0;
					}
				}
				Main.wallFrameCounter[WallID.Honeyfall] = (byte)(Main.wallFrameCounter[WallID.Honeyfall] + 1);
				if (Main.wallFrameCounter[WallID.Honeyfall] >= 10)
				{
					Main.wallFrameCounter[WallID.Honeyfall] = 0;
					Main.wallFrame[WallID.Honeyfall] = (byte)(Main.wallFrame[WallID.Honeyfall] + 1);
					if (Main.wallFrame[WallID.Honeyfall] > 7)
					{
						Main.wallFrame[WallID.Honeyfall] = 0;
					}
				}
				Main.wallFrameCounter[WallID.Confetti] = (byte)(Main.wallFrameCounter[WallID.Confetti] + 1);
				if (Main.wallFrameCounter[WallID.Confetti] >= 5)
				{
					Main.wallFrameCounter[WallID.Confetti] = 0;
					Main.wallFrame[WallID.Confetti] = (byte)(Main.wallFrame[WallID.Confetti] + 1);
					if (Main.wallFrame[WallID.Confetti] > 7)
					{
						Main.wallFrame[WallID.Confetti] = 0;
					}
				}
				Main.wallFrameCounter[WallID.ConfettiBlack] = (byte)(Main.wallFrameCounter[WallID.ConfettiBlack] + 1);
				if (Main.wallFrameCounter[WallID.ConfettiBlack] >= 5)
				{
					Main.wallFrameCounter[WallID.ConfettiBlack] = 0;
					Main.wallFrame[WallID.ConfettiBlack] = (byte)(Main.wallFrame[WallID.ConfettiBlack] + 1);
					if (Main.wallFrame[WallID.ConfettiBlack] > 7)
					{
						Main.wallFrame[WallID.ConfettiBlack] = 0;
					}
				}
				Main.wallFrameCounter[WallID.ArcaneRunes] = (byte)(Main.wallFrameCounter[WallID.ArcaneRunes] + 1);
				int num2 = 5;
				int num3 = 10;
				if (Main.wallFrameCounter[WallID.ArcaneRunes] < num2)
				{
					Main.wallFrame[WallID.ArcaneRunes] = 0;
				}
				else if (Main.wallFrameCounter[WallID.ArcaneRunes] < num2)
				{
					Main.wallFrame[WallID.ArcaneRunes] = 1;
				}
				else if (Main.wallFrameCounter[WallID.ArcaneRunes] < num2 * 2)
				{
					Main.wallFrame[WallID.ArcaneRunes] = 2;
				}
				else if (Main.wallFrameCounter[WallID.ArcaneRunes] < num2 * 3)
				{
					Main.wallFrame[WallID.ArcaneRunes] = 3;
				}
				else if (Main.wallFrameCounter[WallID.ArcaneRunes] < num2 * 4)
				{
					Main.wallFrame[WallID.ArcaneRunes] = 4;
				}
				else if (Main.wallFrameCounter[WallID.ArcaneRunes] < num2 * 5)
				{
					Main.wallFrame[WallID.ArcaneRunes] = 5;
				}
				else if (Main.wallFrameCounter[WallID.ArcaneRunes] < num2 * 6)
				{
					Main.wallFrame[WallID.ArcaneRunes] = 6;
				}
				else if (Main.wallFrameCounter[WallID.ArcaneRunes] < num2 * 7)
				{
					Main.wallFrame[WallID.ArcaneRunes] = 7;
				}
				else if (Main.wallFrameCounter[WallID.ArcaneRunes] < num2 * (8 + num3))
				{
					Main.wallFrame[WallID.ArcaneRunes] = 8;
				}
				else if (Main.wallFrameCounter[WallID.ArcaneRunes] < num2 * (9 + num3))
				{
					Main.wallFrame[WallID.ArcaneRunes] = 7;
				}
				else if (Main.wallFrameCounter[WallID.ArcaneRunes] < num2 * (10 + num3))
				{
					Main.wallFrame[WallID.ArcaneRunes] = 6;
				}
				else if (Main.wallFrameCounter[WallID.ArcaneRunes] < num2 * (11 + num3))
				{
					Main.wallFrame[WallID.ArcaneRunes] = 5;
				}
				else if (Main.wallFrameCounter[WallID.ArcaneRunes] < num2 * (12 + num3))
				{
					Main.wallFrame[WallID.ArcaneRunes] = 4;
				}
				else if (Main.wallFrameCounter[WallID.ArcaneRunes] < num2 * (13 + num3))
				{
					Main.wallFrame[WallID.ArcaneRunes] = 3;
				}
				else if (Main.wallFrameCounter[WallID.ArcaneRunes] < num2 * (14 + num3))
				{
					Main.wallFrame[WallID.ArcaneRunes] = 2;
				}
				else if (Main.wallFrameCounter[WallID.ArcaneRunes] >= num2 * (15 + num3))
				{
					Main.wallFrame[WallID.ArcaneRunes] = 0;
					if (Main.wallFrameCounter[WallID.ArcaneRunes] > num2 * (16 + num3 * 2))
					{
						Main.wallFrameCounter[WallID.ArcaneRunes] = 0;
					}
				}
				else
				{
					Main.wallFrame[WallID.ArcaneRunes] = 1;
				}
				Main.tileFrameCounter[TileID.Heart] = Main.tileFrameCounter[TileID.Heart] + 1;
				if (Main.tileFrameCounter[TileID.Heart] > 5)
				{
					Main.tileFrameCounter[TileID.Heart] = 0;
					Main.tileFrame[TileID.Heart] = Main.tileFrame[TileID.Heart] + 1;
					if (Main.tileFrame[TileID.Heart] >= 10)
					{
						Main.tileFrame[TileID.Heart] = 0;
					}
				}
				Main.tileFrameCounter[TileID.Furnaces] = Main.tileFrameCounter[TileID.Furnaces] + 1;
				if (Main.tileFrameCounter[TileID.Furnaces] > 5)
				{
					Main.tileFrameCounter[TileID.Furnaces] = 0;
					Main.tileFrame[TileID.Furnaces] = Main.tileFrame[TileID.Furnaces] + 1;
					if (Main.tileFrame[TileID.Furnaces] >= 12)
					{
						Main.tileFrame[TileID.Furnaces] = 0;
					}
				}
				int num4 = Main.tileFrameCounter[TileID.AdamantiteForge] + 1;
				int num5 = num4;
				Main.tileFrameCounter[TileID.AdamantiteForge] = num4;
				if (num5 >= 4)
				{
					Main.tileFrameCounter[TileID.AdamantiteForge] = 0;
					int num6 = Main.tileFrame[TileID.AdamantiteForge] + 1;
					int num7 = num6;
					Main.tileFrame[TileID.AdamantiteForge] = num6;
					if (num7 >= 6)
					{
						Main.tileFrame[TileID.AdamantiteForge] = 0;
					}
				}
				Main.tileFrameCounter[TileID.ShadowOrbs] = Main.tileFrameCounter[TileID.ShadowOrbs] + 1;
				if (Main.tileFrameCounter[TileID.ShadowOrbs] > 10)
				{
					Main.tileFrameCounter[TileID.ShadowOrbs] = 0;
					Main.tileFrame[TileID.ShadowOrbs] = Main.tileFrame[TileID.ShadowOrbs] + 1;
					if (Main.tileFrame[TileID.ShadowOrbs] > 1)
					{
						Main.tileFrame[TileID.ShadowOrbs] = 0;
					}
				}
				Main.tileFrameCounter[TileID.Hellforge] = Main.tileFrameCounter[TileID.Hellforge] + 1;
				if (Main.tileFrameCounter[TileID.Hellforge] > 5)
				{
					Main.tileFrameCounter[TileID.Hellforge] = 0;
					Main.tileFrame[TileID.Hellforge] = Main.tileFrame[TileID.Hellforge] + 1;
					if (Main.tileFrame[TileID.Hellforge] >= 12)
					{
						Main.tileFrame[TileID.Hellforge] = 0;
					}
				}
				Main.tileFrameCounter[TileID.Sawmill] = Main.tileFrameCounter[TileID.Sawmill] + 1;
				if (Main.tileFrameCounter[TileID.Sawmill] > 4)
				{
					Main.tileFrameCounter[TileID.Sawmill] = 0;
					Main.tileFrame[TileID.Sawmill] = Main.tileFrame[TileID.Sawmill] + 1;
					if (Main.tileFrame[TileID.Sawmill] >= 2)
					{
						Main.tileFrame[TileID.Sawmill] = 0;
					}
				}
				Main.tileFrameCounter[TileID.WaterFountain] = Main.tileFrameCounter[TileID.WaterFountain] + 1;
				if (Main.tileFrameCounter[TileID.WaterFountain] > 4)
				{
					Main.tileFrameCounter[TileID.WaterFountain] = 0;
					Main.tileFrame[TileID.WaterFountain] = Main.tileFrame[TileID.WaterFountain] + 1;
					if (Main.tileFrame[TileID.WaterFountain] >= 6)
					{
						Main.tileFrame[TileID.WaterFountain] = 0;
					}
				}
				Main.tileFrameCounter[TileID.Campfire] = Main.tileFrameCounter[TileID.Campfire] + 1;
				if (Main.tileFrameCounter[TileID.Campfire] >= 4)
				{
					Main.tileFrameCounter[TileID.Campfire] = 0;
					Main.tileFrame[TileID.Campfire] = Main.tileFrame[TileID.Campfire] + 1;
					if (Main.tileFrame[TileID.Campfire] >= 8)
					{
						Main.tileFrame[TileID.Campfire] = 0;
					}
				}
				Main.tileFrameCounter[TileID.Blendomatic] = Main.tileFrameCounter[TileID.Blendomatic] + 1;
				if (Main.tileFrameCounter[TileID.Blendomatic] > 4)
				{
					Main.tileFrameCounter[TileID.Blendomatic] = 0;
					Main.tileFrame[TileID.Blendomatic] = Main.tileFrame[TileID.Blendomatic] + 1;
					if (Main.tileFrame[TileID.Blendomatic] >= 5)
					{
						Main.tileFrame[TileID.Blendomatic] = 0;
					}
				}
				Main.tileFrameCounter[TileID.MeatGrinder] = Main.tileFrameCounter[TileID.MeatGrinder] + 1;
				if (Main.tileFrameCounter[TileID.MeatGrinder] > 4)
				{
					Main.tileFrameCounter[TileID.MeatGrinder] = 0;
					Main.tileFrame[TileID.MeatGrinder] = Main.tileFrame[TileID.MeatGrinder] + 1;
					if (Main.tileFrame[TileID.MeatGrinder] >= 2)
					{
						Main.tileFrame[TileID.MeatGrinder] = 0;
					}
				}
				Main.tileFrameCounter[TileID.Extractinator] = Main.tileFrameCounter[TileID.Extractinator] + 1;
				if (Main.tileFrameCounter[TileID.Extractinator] > 4)
				{
					Main.tileFrameCounter[TileID.Extractinator] = 0;
					Main.tileFrame[TileID.Extractinator] = Main.tileFrame[TileID.Extractinator] + 1;
					if (Main.tileFrame[TileID.Extractinator] >= 10)
					{
						Main.tileFrame[TileID.Extractinator] = 0;
					}
				}
				Main.tileFrameCounter[TileID.Solidifier] = Main.tileFrameCounter[TileID.Solidifier] + 1;
				if (Main.tileFrameCounter[TileID.Solidifier] > 4)
				{
					Main.tileFrameCounter[TileID.Solidifier] = 0;
					Main.tileFrame[TileID.Solidifier] = Main.tileFrame[TileID.Solidifier] + 1;
					if (Main.tileFrame[TileID.Solidifier] >= 4)
					{
						Main.tileFrame[TileID.Solidifier] = 0;
					}
				}
				Main.tileFrameCounter[TileID.Larva] = Main.tileFrameCounter[TileID.Larva] + 1;
				if (Main.tileFrameCounter[TileID.Larva] > 16)
				{
					Main.tileFrameCounter[TileID.Larva] = 0;
					Main.tileFrame[TileID.Larva] = Main.tileFrame[TileID.Larva] + 1;
					if (Main.tileFrame[TileID.Larva] >= 7)
					{
						Main.tileFrame[TileID.Larva] = 0;
					}
				}
				Main.tileFrameCounter[TileID.Teleporter] = Main.tileFrameCounter[TileID.Teleporter] + 1;
				if (Main.tileFrameCounter[TileID.Teleporter] > 20)
				{
					Main.tileFrameCounter[TileID.Teleporter] = 0;
					Main.tileFrame[TileID.Teleporter] = Main.tileFrame[TileID.Teleporter] + 1;
					if (Main.tileFrame[TileID.Teleporter] >= 4)
					{
						Main.tileFrame[TileID.Teleporter] = 0;
					}
					if (Main.tileFrame[TileID.Teleporter] <= 1)
					{
						Main.tileLighted[TileID.Teleporter] = false;
					}
					else
					{
						Main.tileLighted[TileID.Teleporter] = true;
					}
				}
				Main.tileFrameCounter[TileID.PlanteraBulb] = Main.tileFrameCounter[TileID.PlanteraBulb] + 1;
				if (Main.tileFrameCounter[TileID.PlanteraBulb] > 20)
				{
					Main.tileFrameCounter[TileID.PlanteraBulb] = 0;
					Main.tileFrame[TileID.PlanteraBulb] = Main.tileFrame[TileID.PlanteraBulb] + 1;
					if (Main.tileFrame[TileID.PlanteraBulb] >= 4)
					{
						Main.tileFrame[TileID.PlanteraBulb] = 0;
					}
				}
				Main.tileFrameCounter[TileID.ImbuingStation] = Main.tileFrameCounter[TileID.ImbuingStation] + 1;
				if (Main.tileFrameCounter[TileID.ImbuingStation] > 4)
				{
					Main.tileFrameCounter[TileID.ImbuingStation] = 0;
					Main.tileFrame[TileID.ImbuingStation] = Main.tileFrame[TileID.ImbuingStation] + 1;
					if (Main.tileFrame[TileID.ImbuingStation] >= 6)
					{
						Main.tileFrame[TileID.ImbuingStation] = 0;
					}
				}
				Main.tileFrameCounter[TileID.BubbleMachine] = Main.tileFrameCounter[TileID.BubbleMachine] + 1;
				if (Main.tileFrameCounter[TileID.BubbleMachine] > 4)
				{
					Main.tileFrameCounter[TileID.BubbleMachine] = 0;
					Main.tileFrame[TileID.BubbleMachine] = Main.tileFrame[TileID.BubbleMachine] + 1;
					if (Main.tileFrame[TileID.BubbleMachine] >= 6)
					{
						Main.tileFrame[TileID.BubbleMachine] = 0;
					}
				}
				Main.tileFrameCounter[TileID.Autohammer] = Main.tileFrameCounter[TileID.Autohammer] + 1;
				if (Main.tileFrameCounter[TileID.Autohammer] > 4)
				{
					Main.tileFrameCounter[TileID.Autohammer] = 0;
					Main.tileFrame[TileID.Autohammer] = Main.tileFrame[TileID.Autohammer] + 1;
					if (Main.tileFrame[TileID.Autohammer] > 7)
					{
						Main.tileFrame[TileID.Autohammer] = 0;
					}
				}
				Main.tileFrameCounter[TileID.CookingPots] = Main.tileFrameCounter[TileID.CookingPots] + 1;
				if (Main.tileFrameCounter[TileID.CookingPots] > 4)
				{
					Main.tileFrameCounter[TileID.CookingPots] = 0;
					Main.tileFrame[TileID.CookingPots] = Main.tileFrame[TileID.CookingPots] + 1;
					if (Main.tileFrame[TileID.CookingPots] > 3)
					{
						Main.tileFrame[TileID.CookingPots] = 0;
					}
				}
				Main.tileFrameCounter[TileID.ChristmasTree] = Main.tileFrameCounter[TileID.ChristmasTree] + 1;
				if (Main.tileFrameCounter[TileID.ChristmasTree] > 16)
				{
					Main.tileFrameCounter[TileID.ChristmasTree] = 0;
					Main.tileFrame[TileID.ChristmasTree] = Main.tileFrame[TileID.ChristmasTree] + 1;
					if (Main.tileFrame[TileID.ChristmasTree] > 3)
					{
						Main.tileFrame[TileID.ChristmasTree] = 0;
					}
				}
				Main.tileFrameCounter[TileID.FireflyinaBottle] = Main.tileFrameCounter[TileID.FireflyinaBottle] + 1;
				if (Main.tileFrameCounter[TileID.FireflyinaBottle] > 8)
				{
					Main.tileFrameCounter[TileID.FireflyinaBottle] = 0;
					Main.tileFrame[TileID.FireflyinaBottle] = Main.tileFrame[TileID.FireflyinaBottle] + 1;
					if (Main.tileFrame[TileID.FireflyinaBottle] > 5)
					{
						Main.tileFrame[TileID.FireflyinaBottle] = 0;
					}
				}
				Main.tileFrame[TileID.LightningBuginaBottle] = Main.tileFrame[TileID.FireflyinaBottle];
				Main.tileFrameCounter[TileID.Cog] = Main.tileFrameCounter[TileID.Cog] + 1;
				if (Main.tileFrameCounter[TileID.Cog] >= 10)
				{
					Main.tileFrameCounter[TileID.Cog] = 0;
					Main.tileFrame[TileID.Cog] = Main.tileFrame[TileID.Cog] + 1;
					if (Main.tileFrame[TileID.Cog] > 1)
					{
						Main.tileFrame[TileID.Cog] = 0;
					}
				}
				Main.tileFrameCounter[TileID.BoneWelder] = Main.tileFrameCounter[TileID.BoneWelder] + 1;
				if (Main.tileFrameCounter[TileID.BoneWelder] >= 5)
				{
					Main.tileFrameCounter[TileID.BoneWelder] = 0;
					Main.tileFrame[TileID.BoneWelder] = Main.tileFrame[TileID.BoneWelder] + 1;
					if (Main.tileFrame[TileID.BoneWelder] > 6)
					{
						Main.tileFrame[TileID.BoneWelder] = 0;
					}
				}
				Main.tileFrameCounter[TileID.FleshCloningVat] = Main.tileFrameCounter[TileID.FleshCloningVat] + 1;
				if (Main.tileFrameCounter[TileID.FleshCloningVat] >= 5)
				{
					Main.tileFrameCounter[TileID.FleshCloningVat] = 0;
					Main.tileFrame[TileID.FleshCloningVat] = Main.tileFrame[TileID.FleshCloningVat] + 1;
					if (Main.tileFrame[TileID.FleshCloningVat] > 7)
					{
						Main.tileFrame[TileID.FleshCloningVat] = 0;
					}
				}
				Main.tileFrameCounter[TileID.GlassKiln] = Main.tileFrameCounter[TileID.GlassKiln] + 1;
				if (Main.tileFrameCounter[TileID.GlassKiln] >= 5)
				{
					Main.tileFrameCounter[TileID.GlassKiln] = 0;
					Main.tileFrame[TileID.GlassKiln] = Main.tileFrame[TileID.GlassKiln] + 1;
					if (Main.tileFrame[TileID.GlassKiln] > 3)
					{
						Main.tileFrame[TileID.GlassKiln] = 0;
					}
				}
				Main.tileFrameCounter[TileID.LihzahrdFurnace] = Main.tileFrameCounter[TileID.LihzahrdFurnace] + 1;
				if (Main.tileFrameCounter[TileID.LihzahrdFurnace] >= 5)
				{
					Main.tileFrameCounter[TileID.LihzahrdFurnace] = 0;
					Main.tileFrame[TileID.LihzahrdFurnace] = Main.tileFrame[TileID.LihzahrdFurnace] + 1;
					if (Main.tileFrame[TileID.LihzahrdFurnace] > 4)
					{
						Main.tileFrame[TileID.LihzahrdFurnace] = 0;
					}
				}
				Main.tileFrameCounter[TileID.SkyMill] = Main.tileFrameCounter[TileID.SkyMill] + 1;
				if (Main.tileFrameCounter[TileID.SkyMill] >= 5)
				{
					Main.tileFrameCounter[TileID.SkyMill] = 0;
					Main.tileFrame[TileID.SkyMill] = Main.tileFrame[TileID.SkyMill] + 1;
					if (Main.tileFrame[TileID.SkyMill] > 11)
					{
						Main.tileFrame[TileID.SkyMill] = 0;
					}
				}
				Main.tileFrameCounter[TileID.IceMachine] = Main.tileFrameCounter[TileID.IceMachine] + 1;
				if (Main.tileFrameCounter[TileID.IceMachine] >= 5)
				{
					Main.tileFrameCounter[TileID.IceMachine] = 0;
					Main.tileFrame[TileID.IceMachine] = Main.tileFrame[TileID.IceMachine] + 1;
					if (Main.tileFrame[TileID.IceMachine] > 11)
					{
						Main.tileFrame[TileID.IceMachine] = 0;
					}
				}
				Main.tileFrameCounter[TileID.SteampunkBoiler] = Main.tileFrameCounter[TileID.SteampunkBoiler] + 1;
				if (Main.tileFrameCounter[TileID.SteampunkBoiler] >= 5)
				{
					Main.tileFrameCounter[TileID.SteampunkBoiler] = 0;
					Main.tileFrame[TileID.SteampunkBoiler] = Main.tileFrame[TileID.SteampunkBoiler] + 1;
					if (Main.tileFrame[TileID.SteampunkBoiler] > 1)
					{
						Main.tileFrame[TileID.SteampunkBoiler] = 0;
					}
				}
				Main.tileFrameCounter[TileID.HoneyDispenser] = Main.tileFrameCounter[TileID.HoneyDispenser] + 1;
				if (Main.tileFrameCounter[TileID.HoneyDispenser] >= 5)
				{
					Main.tileFrameCounter[TileID.HoneyDispenser] = 0;
					Main.tileFrame[TileID.HoneyDispenser] = Main.tileFrame[TileID.HoneyDispenser] + 1;
					if (Main.tileFrame[TileID.HoneyDispenser] > 7)
					{
						Main.tileFrame[TileID.HoneyDispenser] = 0;
					}
				}
				Main.tileFrameCounter[TileID.MinecartTrack] = Main.tileFrameCounter[TileID.MinecartTrack] + 1;
				if (Main.tileFrameCounter[TileID.MinecartTrack] >= 10)
				{
					Main.tileFrameCounter[TileID.MinecartTrack] = 0;
					Main.tileFrame[TileID.MinecartTrack] = Main.tileFrame[TileID.MinecartTrack] + 1;
					if (Main.tileFrame[TileID.MinecartTrack] > 4)
					{
						Main.tileFrame[TileID.MinecartTrack] = 0;
					}
				}
				Main.tileFrameCounter[TileID.Waterfall] = Main.tileFrameCounter[TileID.Waterfall] + 1;
				if (Main.tileFrameCounter[TileID.Waterfall] >= 5)
				{
					Main.tileFrameCounter[TileID.Waterfall] = 0;
					Main.tileFrame[TileID.Waterfall] = Main.tileFrame[TileID.Waterfall] + 1;
					if (Main.tileFrame[TileID.Waterfall] > 7)
					{
						Main.tileFrame[TileID.Waterfall] = 0;
					}
				}
				Main.tileFrameCounter[TileID.Lavafall] = Main.tileFrameCounter[TileID.Lavafall] + 1;
				if (Main.tileFrameCounter[TileID.Lavafall] >= 10)
				{
					Main.tileFrameCounter[TileID.Lavafall] = 0;
					Main.tileFrame[TileID.Lavafall] = Main.tileFrame[TileID.Lavafall] + 1;
					if (Main.tileFrame[TileID.Lavafall] > 7)
					{
						Main.tileFrame[TileID.Lavafall] = 0;
					}
				}
				Main.tileFrameCounter[TileID.Honeyfall] = Main.tileFrameCounter[TileID.Honeyfall] + 1;
				if (Main.tileFrameCounter[TileID.Honeyfall] >= 10)
				{
					Main.tileFrameCounter[TileID.Honeyfall] = 0;
					Main.tileFrame[TileID.Honeyfall] = Main.tileFrame[TileID.Honeyfall] + 1;
					if (Main.tileFrame[TileID.Honeyfall] > 7)
					{
						Main.tileFrame[TileID.Honeyfall] = 0;
					}
				}
				Main.tileFrameCounter[TileID.LivingFire] = Main.tileFrameCounter[TileID.LivingFire] + 1;
				if (Main.tileFrameCounter[TileID.LivingFire] >= 5)
				{
					Main.tileFrameCounter[TileID.LivingFire] = 0;
					Main.tileFrame[TileID.LivingFire] = Main.tileFrame[TileID.LivingFire] + 1;
					if (Main.tileFrame[TileID.LivingFire] > 3)
					{
						Main.tileFrame[TileID.LivingFire] = 0;
					}
				}
				Main.tileFrameCounter[TileID.Confetti] = Main.tileFrameCounter[TileID.Confetti] + 1;
				if (Main.tileFrameCounter[TileID.Confetti] >= 5)
				{
					Main.tileFrameCounter[TileID.Confetti] = 0;
					Main.tileFrame[TileID.Confetti] = Main.tileFrame[TileID.Confetti] + 1;
					if (Main.tileFrame[TileID.Confetti] > 7)
					{
						Main.tileFrame[TileID.Confetti] = 0;
					}
				}
				Main.tileFrameCounter[TileID.ConfettiBlack] = Main.tileFrameCounter[TileID.ConfettiBlack] + 1;
				if (Main.tileFrameCounter[TileID.ConfettiBlack] >= 5)
				{
					Main.tileFrameCounter[TileID.ConfettiBlack] = 0;
					Main.tileFrame[TileID.ConfettiBlack] = Main.tileFrame[TileID.ConfettiBlack] + 1;
					if (Main.tileFrame[TileID.ConfettiBlack] > 7)
					{
						Main.tileFrame[TileID.ConfettiBlack] = 0;
					}
				}
				for (int i = 340; i <= 344; i++)
				{
					Main.tileFrameCounter[i] = Main.tileFrameCounter[i] + 1;
					if (Main.tileFrameCounter[i] >= 5)
					{
						Main.tileFrameCounter[i] = 0;
						Main.tileFrame[i] = Main.tileFrame[i] + 1;
						if (Main.tileFrame[i] > 3)
						{
							Main.tileFrame[i] = 0;
						}
					}
				}
				Main.tileFrameCounter[TileID.ChimneySmoke] = Main.tileFrameCounter[TileID.ChimneySmoke] + 1;
				if (Main.tileFrameCounter[TileID.ChimneySmoke] >= 5)
				{
					Main.tileFrameCounter[TileID.ChimneySmoke] = 0;
					Main.tileFrame[TileID.ChimneySmoke] = Main.tileFrame[TileID.ChimneySmoke] + 1;
					if (Main.tileFrame[TileID.ChimneySmoke] > 2)
					{
						Main.tileFrame[TileID.ChimneySmoke] = 0;
					}
				}
				Main.tileFrameCounter[TileID.BewitchingTable] = Main.tileFrameCounter[TileID.BewitchingTable] + 1;
				if (Main.tileFrameCounter[TileID.BewitchingTable] >= 5)
				{
					Main.tileFrameCounter[TileID.BewitchingTable] = 0;
					Main.tileFrame[TileID.BewitchingTable] = Main.tileFrame[TileID.BewitchingTable] + 1;
					if (Main.tileFrame[TileID.BewitchingTable] >= 8)
					{
						Main.tileFrame[TileID.BewitchingTable] = 0;
					}
				}
				Main.tileFrame[TileID.AlchemyTable] = Main.tileFrame[TileID.BewitchingTable];
				Main.tileFrameCounter[TileID.SharpeningStation] = Main.tileFrameCounter[TileID.SharpeningStation] + 1;
				if (Main.tileFrameCounter[TileID.SharpeningStation] >= 5)
				{
					Main.tileFrameCounter[TileID.SharpeningStation] = 0;
					Main.tileFrame[TileID.SharpeningStation] = Main.tileFrame[TileID.SharpeningStation] + 1;
					if (Main.tileFrame[TileID.SharpeningStation] >= 4)
					{
						Main.tileFrame[TileID.SharpeningStation] = 0;
					}
				}
				Main.tileFrameCounter[TileID.Bubble] = Main.tileFrameCounter[TileID.Bubble] + 1;
				if (Main.tileFrameCounter[TileID.Bubble] >= 10)
				{
					Main.tileFrameCounter[TileID.Bubble] = 0;
					Main.tileFrame[TileID.Bubble] = Main.tileFrame[TileID.Bubble] + 1;
					if (Main.tileFrame[TileID.Bubble] >= 4)
					{
						Main.tileFrame[TileID.Bubble] = 0;
					}
				}
				int num8 = Main.tileFrameCounter[TileID.LavaLamp] + 1;
				int num9 = num8;
				Main.tileFrameCounter[TileID.LavaLamp] = num8;
				if (num9 >= 8)
				{
					Main.tileFrameCounter[TileID.LavaLamp] = 0;
					int num10 = Main.tileFrame[TileID.LavaLamp] + 1;
					int num11 = num10;
					Main.tileFrame[TileID.LavaLamp] = num10;
					if (num11 >= 7)
					{
						Main.tileFrame[TileID.LavaLamp] = 0;
					}
				}
				int num12 = Main.tileFrameCounter[TileID.DyeVat] + 1;
				int num13 = num12;
				Main.tileFrameCounter[TileID.DyeVat] = num12;
				if (num13 >= 5)
				{
					Main.tileFrameCounter[TileID.DyeVat] = 0;
					int num14 = Main.tileFrame[TileID.DyeVat] + 1;
					int num15 = num14;
					Main.tileFrame[TileID.DyeVat] = num14;
					if (num15 >= 3)
					{
						Main.tileFrame[TileID.DyeVat] = 0;
					}
				}
				int num16 = Main.tileFrameCounter[TileID.Fireplace] + 1;
				int num17 = num16;
				Main.tileFrameCounter[TileID.Fireplace] = num16;
				if (num17 >= 5)
				{
					Main.tileFrameCounter[TileID.Fireplace] = 0;
					int num18 = Main.tileFrame[TileID.Fireplace] + 1;
					int num19 = num18;
					Main.tileFrame[TileID.Fireplace] = num18;
					if (num19 >= 8)
					{
						Main.tileFrame[TileID.Fireplace] = 0;
					}
				}
				int num20 = Main.tileFrameCounter[TileID.Chimney] + 1;
				int num21 = num20;
				Main.tileFrameCounter[TileID.Chimney] = num20;
				if (num21 >= 8)
				{
					Main.tileFrameCounter[TileID.Chimney] = 0;
					int num22 = Main.tileFrame[TileID.Chimney] + 1;
					int num23 = num22;
					Main.tileFrame[TileID.Chimney] = num22;
					if (num23 >= 6)
					{
						Main.tileFrame[TileID.Chimney] = 0;
					}
				}
				int num24 = Main.tileFrame[TileID.LunarCraftingStation] + 1;
				int num25 = num24;
				Main.tileFrame[TileID.LunarCraftingStation] = num24;
				if (num25 >= 240)
				{
					Main.tileFrame[TileID.LunarCraftingStation] = 0;
				}
				int num26 = Main.tileFrameCounter[TileID.LunarMonolith] + 1;
				num5 = num26;
				Main.tileFrameCounter[TileID.LunarMonolith] = num26;
				if (num5 >= 8)
				{
					Main.tileFrameCounter[TileID.LunarMonolith] = 0;
					int num27 = Main.tileFrame[TileID.LunarMonolith] + 1;
					num5 = num27;
					Main.tileFrame[TileID.LunarMonolith] = num27;
					if (num5 >= 8)
					{
						Main.tileFrame[TileID.LunarMonolith] = 0;
					}
				}
				Main.CritterCages();
				Main.UpdateDrawAnimations();

				if (!Main.gamePad || Main.gameMenu)
				{

				}
				Main.CheckInvasionProgressDisplay();
			}
			if (Main.netMode == 1)
			{
				for (int j = 0; j < 59; j++)
				{
					if (Main.player[Main.myPlayer].inventory[j].IsNotTheSameAs(Main.clientPlayer.inventory[j]))
					{
						NetMessage.SendData((int)PacketTypes.PlayerSlot, -1, -1, Main.player[Main.myPlayer].inventory[j].name, Main.myPlayer, (float)j, (float)Main.player[Main.myPlayer].inventory[j].prefix, 0f, 0, 0, 0);
					}
				}
				for (int k = 0; k < (int)Main.player[Main.myPlayer].armor.Length; k++)
				{
					if (Main.player[Main.myPlayer].armor[k].IsNotTheSameAs(Main.clientPlayer.armor[k]))
					{
						NetMessage.SendData((int)PacketTypes.PlayerSlot, -1, -1, Main.player[Main.myPlayer].armor[k].name, Main.myPlayer, (float)(59 + k), (float)Main.player[Main.myPlayer].armor[k].prefix, 0f, 0, 0, 0);
					}
				}
				for (int l = 0; l < (int)Main.player[Main.myPlayer].miscEquips.Length; l++)
				{
					if (Main.player[Main.myPlayer].miscEquips[l].IsNotTheSameAs(Main.clientPlayer.miscEquips[l]))
					{
						NetMessage.SendData((int)PacketTypes.PlayerSlot, -1, -1, "", Main.myPlayer, (float)(58 + (int)Main.player[Main.myPlayer].armor.Length + (int)Main.player[Main.myPlayer].dye.Length + 1 + l), (float)Main.player[Main.myPlayer].miscEquips[l].prefix, 0f, 0, 0, 0);
					}
				}
				for (int m = 0; m < (int)Main.player[Main.myPlayer].miscDyes.Length; m++)
				{
					if (Main.player[Main.myPlayer].miscDyes[m].IsNotTheSameAs(Main.clientPlayer.miscDyes[m]))
					{
						NetMessage.SendData((int)PacketTypes.PlayerSlot, -1, -1, "", Main.myPlayer, (float)(58 + (int)Main.player[Main.myPlayer].armor.Length + (int)Main.player[Main.myPlayer].dye.Length + (int)Main.player[Main.myPlayer].miscEquips.Length + 1 + m), (float)Main.player[Main.myPlayer].miscDyes[m].prefix, 0f, 0, 0, 0);
					}
				}
				for (int n = 0; n < (int)Main.player[Main.myPlayer].bank.item.Length; n++)
				{
					if (Main.player[Main.myPlayer].bank.item[n].IsNotTheSameAs(Main.clientPlayer.bank.item[n]))
					{
						NetMessage.SendData((int)PacketTypes.PlayerSlot, -1, -1, "", Main.myPlayer, (float)(58 + (int)Main.player[Main.myPlayer].armor.Length + (int)Main.player[Main.myPlayer].dye.Length + (int)Main.player[Main.myPlayer].miscEquips.Length + (int)Main.player[Main.myPlayer].miscDyes.Length + 1 + n), (float)Main.player[Main.myPlayer].bank.item[n].prefix, 0f, 0, 0, 0);
					}
				}
				for (int o = 0; o < (int)Main.player[Main.myPlayer].bank2.item.Length; o++)
				{
					if (Main.player[Main.myPlayer].bank2.item[o].IsNotTheSameAs(Main.clientPlayer.bank2.item[o]))
					{
						NetMessage.SendData((int)PacketTypes.PlayerSlot, -1, -1, "", Main.myPlayer, (float)(58 + (int)Main.player[Main.myPlayer].armor.Length + (int)Main.player[Main.myPlayer].dye.Length + (int)Main.player[Main.myPlayer].miscEquips.Length + (int)Main.player[Main.myPlayer].miscDyes.Length + (int)Main.player[Main.myPlayer].bank.item.Length + 1 + o), (float)Main.player[Main.myPlayer].bank2.item[o].prefix, 0f, 0, 0, 0);
					}
				}
				for (int p = 0; p < (int)Main.player[Main.myPlayer].dye.Length; p++)
				{
					if (Main.player[Main.myPlayer].dye[p].IsNotTheSameAs(Main.clientPlayer.dye[p]))
					{
						NetMessage.SendData((int)PacketTypes.PlayerSlot, -1, -1, Main.player[Main.myPlayer].dye[0].name, Main.myPlayer, (float)(58 + (int)Main.player[Main.myPlayer].armor.Length + 1 + p), (float)Main.player[Main.myPlayer].dye[p].prefix, 0f, 0, 0, 0);
					}
				}
				if (Main.player[Main.myPlayer].chest != Main.clientPlayer.chest && Main.player[Main.myPlayer].chest < 0)
				{
					if (!Main.player[Main.myPlayer].editedChestName)
					{
						NetMessage.SendData((int)PacketTypes.ChestOpen, -1, -1, "", Main.player[Main.myPlayer].chest, 0f, 0f, 0f, 0, 0, 0);
					}
					else
					{
						if (Main.chest[Main.clientPlayer.chest] == null)
						{
							NetMessage.SendData((int)PacketTypes.ChestOpen, -1, -1, "", Main.player[Main.myPlayer].chest, 0f, 0f, 0f, 0, 0, 0);
						}
						else
						{
							NetMessage.SendData((int)PacketTypes.ChestOpen, -1, -1, Main.chest[Main.clientPlayer.chest].name, Main.player[Main.myPlayer].chest, 1f, 0f, 0f, 0, 0, 0);
						}
						Main.player[Main.myPlayer].editedChestName = false;
					}
				}
				if (Main.player[Main.myPlayer].talkNPC != Main.clientPlayer.talkNPC)
				{
					NetMessage.SendData((int)PacketTypes.NpcTalk, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
				}
				bool flag = false;
				if (Main.player[Main.myPlayer].zone1 != Main.clientPlayer.zone1)
				{
					flag = true;
				}
				if (Main.player[Main.myPlayer].zone2 != Main.clientPlayer.zone2)
				{
					flag = true;
				}
				if (flag)
				{
					NetMessage.SendData((int)PacketTypes.Zones, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
				}
				if (Main.player[Main.myPlayer].statLife != Main.clientPlayer.statLife || Main.player[Main.myPlayer].statLifeMax != Main.clientPlayer.statLifeMax)
				{
					Main.player[Main.myPlayer].netLife = true;
				}
				if (Main.player[Main.myPlayer].netLifeTime > 0)
				{
					Player player = Main.player[Main.myPlayer];
					player.netLifeTime = player.netLifeTime - 1;
				}
				else if (Main.player[Main.myPlayer].netLife)
				{
					Main.player[Main.myPlayer].netLife = false;
					Main.player[Main.myPlayer].netLifeTime = 60;
					NetMessage.SendData((int)PacketTypes.PlayerHp, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
				}
				if (Main.player[Main.myPlayer].statMana != Main.clientPlayer.statMana || Main.player[Main.myPlayer].statManaMax != Main.clientPlayer.statManaMax)
				{
					Main.player[Main.myPlayer].netMana = true;
				}
				if (Main.player[Main.myPlayer].netManaTime > 0)
				{
					Player player1 = Main.player[Main.myPlayer];
					player1.netManaTime = player1.netManaTime - 1;
				}
				else if (Main.player[Main.myPlayer].netMana)
				{
					Main.player[Main.myPlayer].netMana = false;
					Main.player[Main.myPlayer].netManaTime = 60;
					NetMessage.SendData((int)PacketTypes.PlayerMana, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
				}
				bool flag1 = false;
				for (int q = 0; q < 22; q++)
				{
					if (Main.player[Main.myPlayer].buffType[q] != Main.clientPlayer.buffType[q])
					{
						flag1 = true;
					}
				}
				if (flag1)
				{
					NetMessage.SendData((int)PacketTypes.PlayerBuff, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
					NetMessage.SendData((int)PacketTypes.PlayerUpdate, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
				}
				bool flag2 = false;
				if (Main.player[Main.myPlayer].MinionTargetPoint != Main.clientPlayer.MinionTargetPoint)
				{
					flag2 = true;
				}
				if (flag2)
				{
					NetMessage.SendData((int)PacketTypes.UpdateMinionTarget, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
				}
			}
			if (Main.netMode == 1)
			{
				Main.clientPlayer = (Player)Main.player[Main.myPlayer].clientClone();
			}
			if (Main.netMode != 0 || !Main.playerInventory && !(Main.npcChatText != "") && Main.player[Main.myPlayer].sign < 0 && !Main.ingameOptionsWindow && !Main.achievementsWindow || !Main.autoPause)
			{
				Main.gamePaused = false;
				if (!Main.dedServ && (double)Main.screenPosition.Y < Main.worldSurface * 16 + 16 && Main.netMode != 2)
				{
					Star.UpdateStars();
					Cloud.UpdateClouds();
				}
				PortalHelper.UpdatePortalPoints();
				Main.tileSolid[TileID.Bubble] = false;
				Main.numPlayers = 0;
				for (int r = 0; r < 255; r++)
				{
					if (!Main.ignoreErrors)
					{
						Main.player[r].Update(r);
					}
					else
					{
						try
						{
							Main.player[r].Update(r);
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
				if (Main.netMode != 1)
				{
					try
					{
						NPC.SpawnNPC();
					}
					catch (Exception ex)
					{
#if DEBUG
						Console.WriteLine(ex);
						System.Diagnostics.Debugger.Break();

#endif
					}
				}
				for (int s = 0; s < 255; s++)
				{
					Main.player[s].activeNPCs = 0f;
					Main.player[s].townNPCs = 0f;
				}
				if (Main.wof >= 0 && !Main.npc[Main.wof].active)
				{
					Main.wof = -1;
				}
				if (NPC.golemBoss >= 0 && !Main.npc[NPC.golemBoss].active)
				{
					NPC.golemBoss = -1;
				}
				if (NPC.plantBoss >= 0 && !Main.npc[NPC.plantBoss].active)
				{
					NPC.plantBoss = -1;
				}
				if (NPC.crimsonBoss >= 0 && !Main.npc[NPC.crimsonBoss].active)
				{
					NPC.crimsonBoss = -1;
				}
				NPC.taxCollector = false;
				for (int t = 0; t < 200; t++)
				{
					if (!Main.ignoreErrors)
					{
						Main.npc[t].UpdateNPC(t);
					}
					else
					{
						try
						{
							Main.npc[t].UpdateNPC(t);
						}
						catch (Exception)
						{
							Main.npc[t] = new NPC();
						}
					}
				}
				for (int v = 0; v < 1000; v++)
				{
					if (Main.projectile[v].active)
					{
						Main.projectileIdentity[Main.projectile[v].owner, Main.projectile[v].identity] = v;
					}
				}
				for (int v = 0; v < 1000; v++)
				{
					if (Main.projectile[v].active)
					{
						Main.projectileIdentity[Main.projectile[v].owner, Main.projectile[v].identity] = v;
					}
				}
				for (int w = 0; w < 1000; w++)
				{
					Main.ProjectileUpdateLoopIndex = w;
					if (!Main.ignoreErrors)
					{
						if (Main.projectile[w].active)
						{
							Main.projectileIdentity[Main.projectile[w].owner, Main.projectile[w].identity] = w;
						}
						Main.projectile[w].Update(w);
					}
					else
					{
						try
						{
							if (Main.projectile[w].active)
							{
								Main.projectileIdentity[Main.projectile[w].owner, Main.projectile[w].identity] = w;
							}
							Main.projectile[w].Update(w);
						}
						catch
						{
							Main.projectile[w] = new Projectile();
						}
					}
				}
				Main.ProjectileUpdateLoopIndex = -1;
				for (int w = 0; w < 400; w++)
				{
					if (!Main.ignoreErrors)
					{
						Main.item[w].UpdateItem(w);
					}
					else
					{
						try
						{
							Main.item[w].UpdateItem(w);
						}
						catch
						{
							Main.item[w] = new Item();
						}
					}
				}

				if (Main.netMode != 2)
				{
					CombatText.UpdateCombatText();
					ItemText.UpdateItemText();
				}
				if (!Main.ignoreErrors)
				{
					Main.UpdateTime();
				}
				else
				{
					try
					{
						Main.UpdateTime();
					}
					catch
					{
						Main.checkForSpawns = 0;
					}
				}
				Main.tileSolid[TileID.Bubble] = true;
				if (Main.netMode != 1)
				{
					if (!Main.ignoreErrors)
					{
						WorldGen.UpdateWorld();
						Main.UpdateInvasion();
					}
					else
					{
						try
						{
							WorldGen.UpdateWorld();
							Main.UpdateInvasion();
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
				if (!Main.ignoreErrors)
				{
					if (Main.netMode == 2)
					{
						Main.UpdateServer();
					}
					if (Main.netMode == 1)
					{
						Main.UpdateClient();
					}
				}
				else
				{
					try
					{
						if (Main.netMode == 2)
						{
							Main.UpdateServer();
						}
						if (Main.netMode == 1)
						{
							Main.UpdateClient();
						}
					}
					catch
					{
						int num29 = Main.netMode;
					}
				}
				Main.upTimer = (float)stopwatch.Elapsed.TotalMilliseconds;
				if (Main.upTimerMaxDelay <= 0f)
				{
					Main.upTimerMax = 0f;
				}
				else
				{
					Main.upTimerMaxDelay = Main.upTimerMaxDelay - 1f;
				}
				if (Main.upTimer > Main.upTimerMax)
				{
					Main.upTimerMax = Main.upTimer;
					Main.upTimerMaxDelay = 400f;
				}
				Chest.UpdateChestFrames();
				return;
			}
		}

		private static void UpdateClient()
		{
			if (Main.myPlayer == 255)
			{
				Netplay.disconnect = true;
			}
			Main.netPlayCounter = Main.netPlayCounter + 1;
			if (Main.netPlayCounter > 3600)
			{
				Main.netPlayCounter = 0;
			}
			if (Main.netPlayCounter % 420 == 0)
			{
				NetMessage.SendData((int)PacketTypes.PlayerUpdate, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
			}
			if (Main.netPlayCounter % 900 == 0)
			{
				NetMessage.SendData((int)PacketTypes.Zones, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
				NetMessage.SendData((int)PacketTypes.PlayerHp, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
				NetMessage.SendData((int)PacketTypes.NpcTalk, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
			}
			if (Netplay.Connection.IsActive)
			{
				RemoteServer connection = Netplay.Connection;
				connection.TimeOutTimer = connection.TimeOutTimer + 1;
				if (!Main.stopTimeOuts && Netplay.Connection.TimeOutTimer > 7200)
				{
					Main.statusText = Lang.inter[43];
					Netplay.disconnect = true;
				}
			}
			for (int i = 0; i < 400; i++)
			{
				if (Main.item[i].active && Main.item[i].owner == Main.myPlayer)
				{
					Main.item[i].FindOwner(i);
				}
			}
		}

		public void updateCloudLayer()
		{
			if (Main.netMode == 1)
			{
				return;
			}
			if (Main.netMode == 0 && Main.gameMenu)
			{
				return;
			}
			int num = 86400;
			int num1 = num / 24;
			float single = Math.Max(1f, 1f + 4f * Main.cloudAlpha);
			if (Main.cloudBGActive <= 0f)
			{
				if (Main.cloudBGActive < 0f)
				{
					Main.cloudBGActive = Main.cloudBGActive + (float)Main.dayRate * single;
					if (Main.raining)
					{
						Main.cloudBGActive = Main.cloudBGActive + (float)(2 * Main.dayRate) * single;
					}
				}
				if (Main.cloudBGActive > 0f)
				{
					Main.cloudBGActive = 0f;
				}
				if (Main.cloudBGActive == 0f)
				{
					if (Main.rand.Next((int)((float)(num1 * 8 / (Main.dayRate == 0 ? 1 : Main.dayRate)) / single)) == 0)
					{
						Main.cloudBGActive = (float)Main.rand.Next(num1 * 3, num * 2);
						if (Main.netMode == 2)
						{
							NetMessage.SendData((int)PacketTypes.WorldInfo, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						}
					}
				}
			}
			else
			{
				if (Main.cloudBGActive > 1f)
				{
					Main.cloudBGActive = Main.cloudBGActive - (float)Main.dayRate / single;
				}
				if (Main.cloudBGActive < 1f)
				{
					Main.cloudBGActive = 1f;
				}
				if (Main.cloudBGActive == 1f && Main.rand.Next((int)((float)(num1 * 2 / Math.Max(Main.dayRate, 1)) * single)) == 0)
				{
					Main.cloudBGActive = (float)(-Main.rand.Next(num1 * 4, num * 4));
					if (Main.netMode == 2)
					{
						NetMessage.SendData((int)PacketTypes.WorldInfo, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
			}
		}

		public void UpdateDisplaySettings()
		{
		}

		public static void UpdateDrawAnimations()
		{
			for (int i = 0; i < Main.itemAnimationsRegistered.Count; i++)
			{
				int item = Main.itemAnimationsRegistered[i];
				if (Main.itemAnimations[item] != null)
				{
					Main.itemAnimations[item].Update();
				}
			}
		}

		private static void UpdateInvasion()
		{
			if (Main.invasionType > 0)
			{
				if (Main.invasionSize <= 0)
				{
					if (Main.invasionType == 1)
					{
						NPC.downedGoblins = true;
						if (Main.netMode == 2)
						{
							NetMessage.SendData((int)PacketTypes.WorldInfo, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						}
						AchievementsHelper.NotifyProgressionEvent(10);
					}
					else if (Main.invasionType == 2)
					{
						NPC.downedFrost = true;
						AchievementsHelper.NotifyProgressionEvent(12);
					}
					else if (Main.invasionType == 3)
					{
						NPC.downedPirates = true;
						AchievementsHelper.NotifyProgressionEvent(11);
					}
					else if (Main.invasionType == 4)
					{
						NPC.downedMartians = true;
						AchievementsHelper.NotifyProgressionEvent(13);
					}
					Main.InvasionWarning();
					Main.invasionType = 0;
					Main.invasionDelay = 0;
				}
				if (Main.invasionX == (double)Main.spawnTileX)
				{
					return;
				}
				float single = (float)Main.dayRate;
				if (Main.invasionX > (double)Main.spawnTileX)
				{
					Main.invasionX = Main.invasionX - (double)single;
					if (Main.invasionX > (double)Main.spawnTileX)
					{
						Main.invasionWarn = Main.invasionWarn - 1;
					}
					else
					{
						Main.invasionX = (double)Main.spawnTileX;
						Main.InvasionWarning();
					}
				}
				else if (Main.invasionX < (double)Main.spawnTileX)
				{
					Main.invasionX = Main.invasionX + (double)single;
					if (Main.invasionX < (double)Main.spawnTileX)
					{
						Main.invasionWarn = Main.invasionWarn - 1;
					}
					else
					{
						Main.invasionX = (double)Main.spawnTileX;
						Main.InvasionWarning();
					}
				}
				if (Main.invasionWarn <= 0)
				{
					Main.invasionWarn = 3600;
					Main.InvasionWarning();
				}
			}
		}

		private static void UpdateMenu()
		{
			Main.playerInventory = false;
			if (Main.netMode == 0)
			{
				Main.maxRaining = 0f;
				Main.raining = false;
				if (!Main.grabSky)
				{
					Main.time = Main.time + 86.4;
					if (!Main.dayTime)
					{
						if (Main.time > 32400)
						{
							Main.bloodMoon = false;
							Main.time = 0;
							Main.dayTime = true;
							Main.moonPhase = Main.moonPhase + 1;
							if (Main.moonPhase >= 8)
							{
								Main.moonPhase = 0;
								return;
							}
						}
					}
					else if (Main.time > 54000)
					{
						Main.time = 0;
						Main.dayTime = false;
						return;
					}
				}
			}
			else if (Main.netMode == 1)
			{
				Main.UpdateTime();
			}
		}

		protected void UpdateMusic()
		{
			int num;
			if (Main.musicVolume == 0f)
			{
				Main.curMusic = 0;
			}
			try
			{
				if (!Main.dedServ)
				{
					if (Main.curMusic > 0)
					{
					}
					bool flag = false;
					bool flag1 = false;
					bool flag2 = false;
					bool flag3 = false;
					bool flag4 = false;
					bool flag5 = false;
					bool flag6 = false;
					bool flag7 = false;
					bool flag8 = false;
					bool flag9 = false;
					bool flag10 = false;
					Rectangle rectangle = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
					int num1 = 5000;
					for (int k = 0; k < 200; k++)
					{
						if (Main.npc[k].active)
						{
							num = 0;
							int num2 = Main.npc[k].type;
							if (num2 > 245)
							{
								if (num2 <= 439)
								{
									if (num2 > 398)
									{
										if (num2 == 422)
										{
											goto Label4;
										}
										switch (num2)
										{
											case 438:
												{
													if (Main.npc[k].ai[1] != 1f)
													{
														goto Label3;
													}
													num = 4;
													goto Label3;
												}
											case 439:
												{
													num = 4;
													goto Label3;
												}
											default:
												{
													goto Label3;
												}
										}
									}
									else
									{
										switch (num2)
										{
											case 262:
											case 263:
											case 264:
												{
													num = 6;
													goto Label3;
												}
											case 265:
												{
													goto Label3;
												}
											case 266:
												{
													num = 3;
													goto Label3;
												}
											case 381:
											case 382:
											case 383:
											case 385:
											case 386:
											case 388:
											case 389:
											case 390:
											case 391:
											case 395:
												{
													num = 9;
													goto Label3;
												}
											case 398:
												{
													num = 7;
													goto Label3;
												}
											default:
												{
													goto Label3;
												}
										}
									}
								}
								else if (num2 > 507)
								{
									if (num2 == 517)
									{
										goto Label4;
									}
									if (num2 == 520)
									{
										num = 9;
									}
									goto Label3;
								}
								else
								{
									switch (num2)
									{
										case 491:
											{
												num = 8;
												goto Label3;
											}
										case 492:
											{
												goto Label3;
											}
										case 493:
											{
												break;
											}
										case 507:
											{
												break;
											}
										default:
											{
												goto Label3;
											}
									}
								}
								Label4:
								num = 10;
							}
							else if (num2 <= 126)
							{
								if (num2 > 29)
								{
									switch (num2)
									{
										case 111:
											{
												break;
											}
										case 112:
											{
												goto Label3;
											}
										case 113:
										case 114:
											{
												num = 2;
												goto Label3;
											}
										case 125:
										case 126:
											{
												goto case 113;
											}
										default:
											{
												goto Label3;
											}
									}
								}
								else
								{
									switch (num2)
									{
										case 13:
										case 14:
										case 15:
											{
												num = 1;
												goto Label3;
											}
										case 26:
										case 27:
										case 28:
										case 29:
											{
												break;
											}
										default:
											{
												goto Label3;
											}
									}
									break;
								}
								num = 11;
							}
							else if (num2 > 145)
							{
								switch (num2)
								{
									case 212:
									case 213:
									case 214:
									case 215:
									case 216:
										{
											num = 8;
											goto Label3;
										}
									case 217:
									case 218:
									case 219:
									case 220:
									case 221:
										{
											break;
										}
									case 222:
										{
											num = 5;
											break;
										}
									case 245:
										{
											num = 4;
											break;
										}
									default:
										{
											break;
										}
								}
							}
							else if (num2 != 134)
							{
								switch (num2)
								{
									case 143:
									case 144:
									case 145:
										{
											num = 3;
											goto Label3;
										}
								}
							}
							else
							{
								num = 3;
								goto Label3;
							}
							Label3:
							if (num == 0 && Main.npc[k].boss)
							{
								num = 1;
							}
							if (num != 0)
							{
								Rectangle rectangle1 = new Rectangle((int)(Main.npc[k].position.X + (float)(Main.npc[k].width / 2)) - num1, (int)(Main.npc[k].position.Y + (float)(Main.npc[k].height / 2)) - num1, num1 * 2, num1 * 2);
								if (rectangle.Intersects(rectangle1))
								{
									if (num == 1)
									{
										flag = true;
										break;
									}
									else if (num == 2)
									{
										flag1 = true;
										break;
									}
									else if (num == 3)
									{
										flag2 = true;
										break;
									}
									else if (num == 4)
									{
										flag3 = true;
										break;
									}
									else if (num == 5)
									{
										flag4 = true;
										break;
									}
									else if (num == 6)
									{
										flag5 = true;
										break;
									}
									else if (num == 7)
									{
										flag6 = true;
										break;
									}
									else if (num == 8)
									{
										flag7 = true;
										break;
									}
									else if (num == 9)
									{
										flag8 = true;
										break;
									}
									else if (num != 10)
									{
										if (num != 11)
										{
											break;
										}
										flag10 = true;
										break;
									}
									else
									{
										flag9 = true;
										break;
									}
								}
							}
						}
					}
					int x = (int)((Main.screenPosition.X + (float)(Main.screenWidth / 2)) / 16f);
					if (Main.musicVolume == 0f)
					{
						this.newMusic = 0;
					}
					else if (!Main.gameMenu)
					{
						float single = (float)(Main.maxTilesX / 4200);
						single = single * single;
						float y = (float)((double)((Main.screenPosition.Y + (float)(Main.screenHeight / 2)) / 16f - (65f + 10f * single)) / (Main.worldSurface / 5));
						if (flag6)
						{
							this.newMusic = 38;
						}
						else if (flag8)
						{
							this.newMusic = 37;
						}
						else if (flag9)
						{
							this.newMusic = 34;
						}
						else if (flag5)
						{
							this.newMusic = 24;
						}
						else if (flag1)
						{
							this.newMusic = 12;
						}
						else if (flag)
						{
							this.newMusic = 5;
						}
						else if (flag2)
						{
							this.newMusic = 13;
						}
						else if (flag3)
						{
							this.newMusic = 17;
						}
						else if (flag4)
						{
							this.newMusic = 25;
						}
						else if (flag7)
						{
							this.newMusic = 35;
						}
						else if (flag10)
						{
							this.newMusic = 39;
						}
						else if (Main.player[Main.myPlayer].position.Y > (float)((Main.maxTilesY - 200) * 16))
						{
							this.newMusic = 36;
						}
						else if (Main.eclipse && (double)Main.player[Main.myPlayer].position.Y < Main.worldSurface * 16 + (double)(Main.screenHeight / 2))
						{
							this.newMusic = 27;
						}
						else if (y < 1f)
						{
							this.newMusic = 15;
						}
						else if (Main.tile[(int)(Main.player[Main.myPlayer].Center.X / 16f), (int)(Main.player[Main.myPlayer].Center.Y / 16f)].wall == 87)
						{
							this.newMusic = 26;
						}
						else if (Main.bgStyle == 9 && (double)Main.player[Main.myPlayer].position.Y < Main.worldSurface * 16 + (double)(Main.screenHeight / 2) || Main.ugBack == 2)
						{
							this.newMusic = 29;
						}
						else if (Main.player[Main.myPlayer].ZoneCorrupt)
						{
							if ((double)Main.player[Main.myPlayer].position.Y <= Main.worldSurface * 16 + (double)(Main.screenHeight / 2))
							{
								this.newMusic = 8;
							}
							else
							{
								this.newMusic = 10;
							}
						}
						else if (Main.player[Main.myPlayer].ZoneCrimson)
						{
							if ((double)Main.player[Main.myPlayer].position.Y <= Main.worldSurface * 16 + (double)(Main.screenHeight / 2))
							{
								this.newMusic = 16;
							}
							else
							{
								this.newMusic = 33;
							}
						}
						else if (Main.player[Main.myPlayer].ZoneDungeon)
						{
							this.newMusic = 23;
						}
						else if (Main.player[Main.myPlayer].ZoneMeteor)
						{
							this.newMusic = 2;
						}
						else if (Main.player[Main.myPlayer].ZoneJungle)
						{
							this.newMusic = 7;
						}
						else if (Main.player[Main.myPlayer].ZoneSnow)
						{
							if ((double)Main.player[Main.myPlayer].position.Y <= Main.worldSurface * 16 + (double)(Main.screenHeight / 2))
							{
								this.newMusic = 14;
							}
							else
							{
								this.newMusic = 20;
							}
						}
						else if ((double)Main.player[Main.myPlayer].position.Y > Main.worldSurface * 16 + (double)(Main.screenHeight / 2))
						{
							if (Main.player[Main.myPlayer].ZoneHoly)
							{
								this.newMusic = 11;
							}
							else if (Main.sandTiles <= 2200)
							{
								if (Main.ugMusic == 0)
								{
									Main.ugMusic = 4;
								}

								this.newMusic = Main.ugMusic;
							}
							else
							{
								this.newMusic = 21;
							}
						}
						else if (Main.dayTime && Main.player[Main.myPlayer].ZoneHoly)
						{
							if (Main.cloudAlpha <= 0f || Main.gameMenu)
							{
								this.newMusic = 9;
							}
							else
							{
								this.newMusic = 19;
							}
						}
						else if ((double)(Main.screenPosition.Y / 16f) < Main.worldSurface + 10 && (x < 380 || x > Main.maxTilesX - 380))
						{
							this.newMusic = 22;
						}
						else if (Main.sandTiles > 1000)
						{
							this.newMusic = 21;
						}
						else if (Main.dayTime)
						{
							if (Main.cloudAlpha <= 0f || Main.gameMenu)
							{
								if (Main.dayMusic == 0)
								{
									Main.dayMusic = 1;
								}

								this.newMusic = Main.dayMusic;
							}
							else
							{
								this.newMusic = 19;
							}
						}
						else if (!Main.dayTime)
						{
							if (Main.bloodMoon)
							{
								this.newMusic = 2;
							}
							else if (Main.cloudAlpha <= 0f || Main.gameMenu)
							{
								this.newMusic = 3;
							}
							else
							{
								this.newMusic = 19;
							}
						}
						if ((double)(Main.screenPosition.Y / 16f) < Main.worldSurface + 10 && Main.pumpkinMoon)
						{
							this.newMusic = 30;
						}
						if ((double)(Main.screenPosition.Y / 16f) < Main.worldSurface + 10 && Main.snowMoon)
						{
							this.newMusic = 32;
						}
					}
					else if (Main.netMode == 2)
					{
						this.newMusic = 0;
					}
					else
					{
						this.newMusic = 6;
					}
					if (Main.gameMenu || Main.musicVolume == 0f)
					{
						Main.musicBox2 = -1;
						Main.musicBox = -1;
					}
					if (Main.musicBox2 >= 0)
					{
						Main.musicBox = Main.musicBox2;
					}
					if (Main.musicBox >= 0)
					{
						if (Main.musicBox == 0)
						{
							this.newMusic = 1;
						}
						if (Main.musicBox == 1)
						{
							this.newMusic = 2;
						}
						if (Main.musicBox == 2)
						{
							this.newMusic = 3;
						}
						if (Main.musicBox == 4)
						{
							this.newMusic = 4;
						}
						if (Main.musicBox == 5)
						{
							this.newMusic = 5;
						}
						if (Main.musicBox == 3)
						{
							this.newMusic = 6;
						}
						if (Main.musicBox == 6)
						{
							this.newMusic = 7;
						}
						if (Main.musicBox == 7)
						{
							this.newMusic = 8;
						}
						if (Main.musicBox == 9)
						{
							this.newMusic = 9;
						}
						if (Main.musicBox == 8)
						{
							this.newMusic = 10;
						}
						if (Main.musicBox == 11)
						{
							this.newMusic = 11;
						}
						if (Main.musicBox == 10)
						{
							this.newMusic = 12;
						}
						if (Main.musicBox == 12)
						{
							this.newMusic = 13;
						}
						if (Main.musicBox == 13)
						{
							this.newMusic = 14;
						}
						if (Main.musicBox == 14)
						{
							this.newMusic = 15;
						}
						if (Main.musicBox == 15)
						{
							this.newMusic = 16;
						}
						if (Main.musicBox == 16)
						{
							this.newMusic = 17;
						}
						if (Main.musicBox == 17)
						{
							this.newMusic = 18;
						}
						if (Main.musicBox == 18)
						{
							this.newMusic = 19;
						}
						if (Main.musicBox == 19)
						{
							this.newMusic = 20;
						}
						if (Main.musicBox == 20)
						{
							this.newMusic = 21;
						}
						if (Main.musicBox == 21)
						{
							this.newMusic = 22;
						}
						if (Main.musicBox == 22)
						{
							this.newMusic = 23;
						}
						if (Main.musicBox == 23)
						{
							this.newMusic = 24;
						}
						if (Main.musicBox == 24)
						{
							this.newMusic = 25;
						}
						if (Main.musicBox == 25)
						{
							this.newMusic = 26;
						}
						if (Main.musicBox == 26)
						{
							this.newMusic = 27;
						}
						if (Main.musicBox == 27)
						{
							this.newMusic = 29;
						}
						if (Main.musicBox == 28)
						{
							this.newMusic = 30;
						}
						if (Main.musicBox == 29)
						{
							this.newMusic = 31;
						}
						if (Main.musicBox == 30)
						{
							this.newMusic = 32;
						}
						if (Main.musicBox == 31)
						{
							this.newMusic = 33;
						}
						if (Main.musicBox == 32)
						{
							this.newMusic = 38;
						}
						if (Main.musicBox == 33)
						{
							this.newMusic = 37;
						}
						if (Main.musicBox == 34)
						{
							this.newMusic = 35;
						}
						if (Main.musicBox == 35)
						{
							this.newMusic = 36;
						}
						if (Main.musicBox == 36)
						{
							this.newMusic = 34;
						}
						if (Main.musicBox == 37)
						{
							this.newMusic = 39;
						}
					}
					Main.curMusic = this.newMusic;
					float moonLordCountdown = 1f;
					if (NPC.MoonLordCountdown > 0)
					{
						moonLordCountdown = (float)NPC.MoonLordCountdown / 3600f;
						moonLordCountdown = moonLordCountdown * moonLordCountdown;
						if (NPC.MoonLordCountdown <= 720)
						{
							moonLordCountdown = 0f;
							Main.curMusic = 0;
						}
						else
						{
							moonLordCountdown = MathHelper.Lerp(0f, 1f, moonLordCountdown);
						}
						if (NPC.MoonLordCountdown == 1 && Main.curMusic >= 1 && Main.curMusic < 40)
						{
							Main.musicFade[Main.curMusic] = 0f;
						}
					}
					for (int l = 1; l < 40; l++)
					{
						if (l != 28)
						{
							if (l == Main.curMusic)
							{

							}
							else
							{
								if (Main.musicFade[Main.curMusic] > 0.25f)
								{
									Main.musicFade[l] = Main.musicFade[l] - 0.005f;
								}
								else if (Main.curMusic == 0)
								{
									Main.musicFade[l] = 0f;
								}

							}
						}
						else if (Main.cloudAlpha <= 0f || (double)Main.player[Main.myPlayer].position.Y >= Main.worldSurface * 16 + (double)(Main.screenHeight / 2) || Main.player[Main.myPlayer].ZoneSnow)
						{

						}
						else if (Main.ambientVolume == 0f)
						{
						}
					}
					if (Main.musicError > 0)
					{
						Main.musicError = Main.musicError - 1;
					}
				}
			}
			catch
			{
				Main.musicError = Main.musicError + 1;
				if (Main.musicError >= 100)
				{
					Main.musicError = 0;
					Main.musicVolume = 0f;
				}
			}
			return;
		}

		private static void UpdateServer()
		{
			Main.netPlayCounter = Main.netPlayCounter + 1;
			if (Main.netPlayCounter > 3600)
			{
				NetMessage.SendData((int)PacketTypes.WorldInfo, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
				NetMessage.syncPlayers();
				Main.netPlayCounter = 0;
			}
			for (int i = 0; i < Main.maxNetPlayers; i++)
			{
				if (Main.player[i].active && Netplay.Clients[i].IsActive)
				{
					Netplay.Clients[i].SpamUpdate();
				}
			}
			if (Math.IEEERemainder((double)Main.netPlayCounter, 900) == 0)
			{
				bool flag = true;
				int num = Main.lastItemUpdate;
				int num1 = 0;
				while (flag)
				{
					num++;
					if (num >= 400)
					{
						num = 0;
					}
					num1++;
					if (!Main.item[num].active || Main.item[num].owner == 255)
					{
						NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num, 0f, 0f, 0f, 0, 0, 0);
					}
					if (num1 < Main.maxItemUpdates && num != Main.lastItemUpdate)
					{
						continue;
					}
					flag = false;
				}
				Main.lastItemUpdate = num;
			}
			for (int j = 0; j < 400; j++)
			{
				if (Main.item[j].active && (Main.item[j].owner == 255 || !Main.player[Main.item[j].owner].active))
				{
					Main.item[j].FindOwner(j);
				}
			}
			for (int k = 0; k < 255; k++)
			{
				if (Netplay.Clients[k].IsActive)
				{
					RemoteClient clients = Netplay.Clients[k];
					clients.TimeOutTimer = clients.TimeOutTimer + 1;
					if (!Main.stopTimeOuts && Netplay.Clients[k].TimeOutTimer > 7200)
					{
						Netplay.Clients[k].PendingTermination = true;
					}
				}
				if (Main.player[k].active)
				{
					RemoteClient.CheckSection(k, Main.player[k].position, 1);
				}
			}
		}

		public static void UpdateSundial()
		{
			if (Main.fastForwardTime)
			{
				Main.dayRate = 60;
				return;
			}
			Main.dayRate = 1;
		}

		private static void UpdateTime()
		{
			if (Main.pumpkinMoon)
			{
				Main.bloodMoon = false;
				Main.snowMoon = false;
			}
			if (Main.snowMoon)
			{
				Main.bloodMoon = false;
			}
			if (Main.netMode != 1 && !Main.gameMenu || Main.netMode == 2)
			{
				if (Main.slimeRainTime > 0)
				{
					Main.slimeRainTime = Main.slimeRainTime - (double)Main.dayRate;
					if (Main.slimeRainTime <= 0)
					{
						Main.StopSlimeRain(true);
					}
				}
				else if (Main.slimeRainTime < 0)
				{
					Main.slimeRainTime = Main.slimeRainTime + (double)Main.dayRate;
					if (Main.slimeRainTime > 0)
					{
						Main.slimeRainTime = 0;
					}
				}
				if (Main.raining)
				{
					Main.rainTime = Main.rainTime - Main.dayRate;
					if (Main.dayRate > 0)
					{
						int num = 86400 / Main.dayRate / 24;
						if (Main.rainTime <= 0)
						{
							Main.StopRain();
						}
						else if (Main.rand.Next(num * 2) == 0)
						{
							Main.ChangeRain();
						}
					}
				}
				else if (!Main.slimeRain)
				{
					int num1 = 86400;
					num1 = num1 / (Main.dayRate != 0 ? Main.dayRate : 1);
					if (Main.rand.Next((int)((double)num1 * 5.5)) == 0)
					{
						Main.StartRain();
					}
					else if (Main.cloudBGActive >= 1f && Main.rand.Next(num1 * 4) == 0)
					{
						Main.StartRain();
					}
					if (!Main.raining && Main.slimeRainTime == 0 && !Main.bloodMoon && !Main.eclipse && !Main.snowMoon && !Main.pumpkinMoon && Main.invasionType == 0)
					{
						int num2 = (int)(1728000 / (double)Main.dayRate);
						if (!NPC.downedSlimeKing)
						{
							num2 = num2 / 2;
						}
						if (Main.hardMode)
						{
							num2 = (int)((double)num2 * 1.5);
						}
						bool flag = false;
						for (int i = 0; i < 255; i++)
						{
							if (Main.player[i].active && Main.player[i].statLifeMax > 140 && Main.player[i].statDefense > 8)
							{
								flag = true;
							}
						}
						if (!flag)
						{
							num2 = num2 * 5;
						}
						if (Main.dayRate > 0 && num2 > 0 && (flag || Main.expertMode) && Main.rand.Next(num2) == 0)
						{
							Main.StartSlimeRain(true);
						}
					}
				}
			}
			if (Main.maxRaining != Main.oldMaxRaining)
			{
				if (Main.netMode == 2)
				{
					NetMessage.SendData((int)PacketTypes.WorldInfo, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
				}
				Main.oldMaxRaining = Main.maxRaining;
			}
			Main.UpdateSundial();
			Main.time = Main.time + (double)Main.dayRate;
			CultistRitual.UpdateTime();
			if (NPC.MoonLordCountdown > 0)
			{
				NPC.MoonLordCountdown = NPC.MoonLordCountdown - 1;
				if (NPC.MoonLordCountdown <= 0 && Main.netMode != 1)
				{
					NPC.SpawnOnPlayer((int)Player.FindClosest(new Vector2((float)(Main.maxTilesX / 2), (float)Main.worldSurface / 2f) * 16f, 0, 0), 398);
				}
			}
			if (NPC.taxCollector && Main.netMode != 2 && !Main.gameMenu)
			{
				Player player = Main.player[Main.myPlayer];
				player.taxTimer = player.taxTimer + Main.dayRate;
				if (Main.player[Main.myPlayer].taxTimer >= Player.taxRate)
				{
					Player player1 = Main.player[Main.myPlayer];
					player1.taxTimer = player1.taxTimer - Player.taxRate;
					Main.player[Main.myPlayer].CollectTaxes();
				}
			}
			if (Main.netMode != 1 && Main.slimeWarningTime > 0)
			{
				Main.slimeWarningTime = Main.slimeWarningTime - 1;
				if (Main.slimeWarningTime <= 0)
				{
					if (Main.netMode == 0)
					{
						if (Main.slimeRainTime <= 0)
						{
							Main.NewText(Lang.gen[75], 50, 255, 130, false);
						}
						else
						{
							Main.NewText(Lang.gen[74], 50, 255, 130, false);
						}
					}
					else if (Main.slimeRainTime <= 0)
					{
						NetMessage.SendData((int)PacketTypes.ChatText, -1, -1, Lang.gen[75], 255, 50f, 255f, 130f, 0, 0, 0);
					}
					else
					{
						NetMessage.SendData((int)PacketTypes.ChatText, -1, -1, Lang.gen[74], 255, 50f, 255f, 130f, 0, 0, 0);
					}
				}
			}
			if (Main.netMode != 1)
			{
				if (NPC.travelNPC)
				{
					if (!Main.dayTime || Main.time > 48600)
					{
						WorldGen.UnspawnTravelNPC();
					}
				}
				else if (!Main.fastForwardTime && Main.dayTime && Main.time < 27000)
				{
					int num3 = (int)(27000 / (double)Main.dayRate);
					if (Main.rand.Next(num3 * 4) == 0)
					{
						int num4 = 0;
						for (int j = 0; j < 200; j++)
						{
							if (Main.npc[j].active && Main.npc[j].townNPC && Main.npc[j].type != NPCID.OldMan && Main.npc[j].type != NPCID.SkeletonMerchant)
							{
								num4++;
							}
						}
						if (num4 >= 2)
						{
							WorldGen.SpawnTravelNPC();
						}
					}
				}
				NPC.travelNPC = false;
			}
			if (Main.dayTime)
			{
				Main.bloodMoon = false;
				Main.stopMoonEvent();
				if (Main.time > 54000)
				{
					NPC.setFireFlyChance();
					WorldGen.spawnNPC = 0;
					Main.checkForSpawns = 0;
					if (Main.rand.Next(50) == 0 && Main.netMode != 1 && WorldGen.shadowOrbSmashed)
					{
						WorldGen.spawnMeteor = true;
					}
					if (Main.eclipse && Main.netMode != 1)
					{
						AchievementsHelper.NotifyProgressionEvent(3);
					}
					Main.eclipse = false;
					if (Main.netMode != 1)
					{
						AchievementsHelper.NotifyProgressionEvent(0);
					}
					if (!Main.fastForwardTime)
					{
						if (!NPC.downedBoss1 && Main.netMode != 1)
						{
							bool flag1 = false;
							int num5 = 0;
							while (num5 < 255)
							{
								if (!Main.player[num5].active || Main.player[num5].statLifeMax < 200 || Main.player[num5].statDefense <= 10)
								{
									num5++;
								}
								else
								{
									flag1 = true;
									break;
								}
							}
							if (flag1 && Main.rand.Next(3) == 0)
							{
								int num6 = 0;
								for (int k = 0; k < 200; k++)
								{
									if (Main.npc[k].active && Main.npc[k].townNPC)
									{
										num6++;
									}
								}
								if (num6 >= 4)
								{
									WorldGen.spawnEye = true;
									if (Main.netMode == 0)
									{
										Main.NewText(Lang.misc[9], 50, 255, 130, false);
									}
									else if (Main.netMode == 2)
									{
										NetMessage.SendData((int)PacketTypes.ChatText, -1, -1, Lang.misc[9], 255, 50f, 255f, 130f, 0, 0, 0);
									}
								}
							}
						}
						if (Main.netMode != 1 && !Main.pumpkinMoon && !Main.snowMoon && WorldGen.altarCount > 0 && Main.hardMode && !WorldGen.spawnEye && Main.rand.Next(10) == 0)
						{
							bool flag2 = false;
							for (int l = 0; l < 200; l++)
							{
								if (Main.npc[l].active && Main.npc[l].boss)
								{
									flag2 = true;
								}
							}
							if (!flag2 && (!NPC.downedMechBoss1 || !NPC.downedMechBoss2 || !NPC.downedMechBoss3))
							{
								int num7 = 0;
								while (num7 < 1000)
								{
									int num8 = Main.rand.Next(3) + 1;
									if (num8 == 1 && !NPC.downedMechBoss1)
									{
										WorldGen.spawnHardBoss = num8;
										if (Main.netMode != 0)
										{
											if (Main.netMode != 2)
											{
												break;
											}
											NetMessage.SendData((int)PacketTypes.ChatText, -1, -1, Lang.misc[28], 255, 50f, 255f, 130f, 0, 0, 0);
											break;
										}
										else
										{
											Main.NewText(Lang.misc[28], 50, 255, 130, false);
											break;
										}
									}
									else if (num8 == 2 && !NPC.downedMechBoss2)
									{
										WorldGen.spawnHardBoss = num8;
										if (Main.netMode != 0)
										{
											if (Main.netMode != 2)
											{
												break;
											}
											NetMessage.SendData((int)PacketTypes.ChatText, -1, -1, Lang.misc[29], 255, 50f, 255f, 130f, 0, 0, 0);
											break;
										}
										else
										{
											Main.NewText(Lang.misc[29], 50, 255, 130, false);
											break;
										}
									}
									else if (num8 != 3 || NPC.downedMechBoss3)
									{
										num7++;
									}
									else
									{
										WorldGen.spawnHardBoss = num8;
										if (Main.netMode != 0)
										{
											if (Main.netMode != 2)
											{
												break;
											}
											NetMessage.SendData((int)PacketTypes.ChatText, -1, -1, Lang.misc[30], 255, 50f, 255f, 130f, 0, 0, 0);
											break;
										}
										else
										{
											Main.NewText(Lang.misc[30], 50, 255, 130, false);
											break;
										}
									}
								}
							}
						}
						if (!WorldGen.spawnEye && Main.moonPhase != 4 && Main.rand.Next(9) == 0 && Main.netMode != 1)
						{
							int num9 = 0;
							while (num9 < 255)
							{
								if (!Main.player[num9].active || Main.player[num9].statLifeMax <= 120)
								{
									num9++;
								}
								else
								{
									Main.bloodMoon = true;
									break;
								}
							}
							if (Main.bloodMoon)
							{
								AchievementsHelper.NotifyProgressionEvent(4);
								if (Main.netMode == 0)
								{
									Main.NewText(Lang.misc[8], 50, 255, 130, false);
								}
								else if (Main.netMode == 2)
								{
									NetMessage.SendData((int)PacketTypes.ChatText, -1, -1, Lang.misc[8], 255, 50f, 255f, 130f, 0, 0, 0);
								}
							}
						}
					}
					Main.time = 0;
					Main.dayTime = false;
					if (Main.netMode == 2)
					{
						NetMessage.SendData((int)PacketTypes.WorldInfo, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
					}
				}
				if (Main.netMode != 1 && Main.worldRate > 0)
				{
					Main.checkForSpawns = Main.checkForSpawns + 1;
					if (Main.checkForSpawns >= 7200 / Main.worldRate)
					{
						int num10 = 0;
						for (int m = 0; m < 255; m++)
						{
							if (Main.player[m].active)
							{
								num10++;
							}
						}
						for (int n = 0; n < 540; n++)
						{
							Main.nextNPC[n] = false;
						}
						Main.checkForSpawns = 0;
						WorldGen.spawnNPC = 0;
						int num11 = 0;
						int num12 = 0;
						int num13 = 0;
						int num14 = 0;
						int num15 = 0;
						int num16 = 0;
						int num17 = 0;
						int num18 = 0;
						int num19 = 0;
						int num20 = 0;
						int num21 = 0;
						int num22 = 0;
						int num23 = 0;
						int num24 = 0;
						int num25 = 0;
						int num26 = 0;
						int num27 = 0;
						int num28 = 0;
						int num29 = 0;
						int num30 = 0;
						int num31 = 0;
						int num32 = 0;
						int num33 = 0;
						int num34 = 0;
						for (int o = 0; o < 200; o++)
						{
							if (Main.npc[o].active && Main.npc[o].townNPC)
							{
								if (Main.npc[o].type != NPCID.TravellingMerchant && Main.npc[o].type != NPCID.OldMan && Main.npc[o].type != NPCID.SkeletonMerchant && !Main.npc[o].homeless)
								{
									WorldGen.QuickFindHome(o);
								}
								if (Main.npc[o].type == NPCID.OldMan)
								{
									num16++;
								}
								if (Main.npc[o].type == NPCID.Merchant)
								{
									num11++;
								}
								if (Main.npc[o].type == NPCID.Nurse)
								{
									num12++;
								}
								if (Main.npc[o].type == NPCID.ArmsDealer)
								{
									num14++;
								}
								if (Main.npc[o].type == NPCID.Dryad)
								{
									num13++;
								}
								if (Main.npc[o].type == NPCID.Guide)
								{
									num15++;
								}
								if (Main.npc[o].type == NPCID.Demolitionist)
								{
									num17++;
								}
								if (Main.npc[o].type == NPCID.Clothier)
								{
									num18++;
								}
								if (Main.npc[o].type == NPCID.GoblinTinkerer)
								{
									num20++;
								}
								if (Main.npc[o].type == NPCID.Wizard)
								{
									num19++;
								}
								if (Main.npc[o].type == NPCID.Mechanic)
								{
									num21++;
								}
								if (Main.npc[o].type == NPCID.SantaClaus)
								{
									num22++;
								}
								if (Main.npc[o].type == NPCID.Truffle)
								{
									num23++;
								}
								if (Main.npc[o].type == NPCID.Steampunker)
								{
									num24++;
								}
								if (Main.npc[o].type == NPCID.DyeTrader)
								{
									num25++;
								}
								if (Main.npc[o].type == NPCID.PartyGirl)
								{
									num26++;
								}
								if (Main.npc[o].type == NPCID.Cyborg)
								{
									num27++;
								}
								if (Main.npc[o].type == NPCID.Painter)
								{
									num28++;
								}
								if (Main.npc[o].type == NPCID.WitchDoctor)
								{
									num29++;
								}
								if (Main.npc[o].type == NPCID.Pirate)
								{
									num30++;
								}
								if (Main.npc[o].type == NPCID.Stylist)
								{
									num31++;
								}
								if (Main.npc[o].type == NPCID.Angler)
								{
									num32++;
								}
								if (Main.npc[o].type == NPCID.TaxCollector)
								{
									num33++;
								}
								num34++;
							}
						}
						if (WorldGen.spawnNPC == 0)
						{
							int num35 = 0;
							bool flag3 = false;
							int num36 = 0;
							bool flag4 = false;
							bool flag5 = false;
							bool flag6 = false;
							bool flag7 = false;
							for (int p = 0; p < 255; p++)
							{
								if (Main.player[p].active)
								{
									for (int q = 0; q < 58; q++)
									{
										if (Main.player[p].inventory[q] != null & Main.player[p].inventory[q].stack > 0)
										{
											if (num35 < 2000000000)
											{
												if (Main.player[p].inventory[q].type == 71)
												{
													num35 = num35 + Main.player[p].inventory[q].stack;
												}
												if (Main.player[p].inventory[q].type == 72)
												{
													num35 = num35 + Main.player[p].inventory[q].stack * 100;
												}
												if (Main.player[p].inventory[q].type == 73)
												{
													num35 = num35 + Main.player[p].inventory[q].stack * 10000;
												}
												if (Main.player[p].inventory[q].type == 74)
												{
													num35 = num35 + Main.player[p].inventory[q].stack * 1000000;
												}
											}
											if (Main.player[p].inventory[q].ammo == 14 || Main.player[p].inventory[q].useAmmo == 14)
											{
												flag4 = true;
											}
											if (Main.player[p].inventory[q].type == 166 || Main.player[p].inventory[q].type == 167 || Main.player[p].inventory[q].type == 168 || Main.player[p].inventory[q].type == 235 || Main.player[p].inventory[q].type == 2896 || Main.player[p].inventory[q].type == 3547)
											{
												flag5 = true;
											}
											if (Main.player[p].inventory[q].dye > 0 || Main.player[p].inventory[q].type >= 1107 && Main.player[p].inventory[q].type <= 1120 || Main.player[p].inventory[q].type >= 3385 && Main.player[p].inventory[q].type <= 3388)
											{
												if (Main.player[p].inventory[q].type >= 3385 && Main.player[p].inventory[q].type <= 3388)
												{
													flag7 = true;
												}
												flag6 = true;
											}
										}
									}
									int num37 = Main.player[p].statLifeMax / 20;
									if (num37 > 5)
									{
										flag3 = true;
									}
									num36 = num36 + num37;
									if (!flag6)
									{
										for (int r = 0; r < 3; r++)
										{
											if (Main.player[p].dye[r] != null && Main.player[p].dye[r].stack > 0 && Main.player[p].dye[r].dye > 0)
											{
												flag6 = true;
											}
										}
									}
								}
							}
							if (!NPC.downedBoss3 && num16 == 0)
							{
								int num38 = NPC.NewNPC(Main.dungeonX * 16 + 8, Main.dungeonY * 16, 37, 0, 0f, 0f, 0f, 0f, 255);
								Main.npc[num38].homeless = false;
								Main.npc[num38].homeTileX = Main.dungeonX;
								Main.npc[num38].homeTileY = Main.dungeonY;
							}
							bool flag8 = false;
							if (Main.rand.Next(40) == 0)
							{
								flag8 = true;
							}
							if (num15 < 1)
							{
								Main.nextNPC[22] = true;
							}
							if ((double)num35 > 5000 && num11 < 1)
							{
								Main.nextNPC[17] = true;
							}
							if (flag3 && num12 < 1 && num11 > 0)
							{
								Main.nextNPC[18] = true;
							}
							if (flag4 && num14 < 1)
							{
								Main.nextNPC[19] = true;
							}
							if ((NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && num13 < 1)
							{
								Main.nextNPC[20] = true;
							}
							if (flag5 && num11 > 0 && num17 < 1)
							{
								Main.nextNPC[38] = true;
							}
							if (NPC.savedStylist && num31 < 1)
							{
								Main.nextNPC[353] = true;
							}
							if (NPC.savedAngler && num32 < 1)
							{
								Main.nextNPC[369] = true;
							}
							if (NPC.downedBoss3 && num18 < 1)
							{
								Main.nextNPC[54] = true;
							}
							if (NPC.savedGoblin && num20 < 1)
							{
								Main.nextNPC[107] = true;
							}
							if (NPC.savedTaxCollector && num33 < 1)
							{
								Main.nextNPC[441] = true;
							}
							if (NPC.savedWizard && num19 < 1)
							{
								Main.nextNPC[108] = true;
							}
							if (NPC.savedMech && num21 < 1)
							{
								Main.nextNPC[124] = true;
							}
							if (NPC.downedFrost && num22 < 1 && Main.xMas)
							{
								Main.nextNPC[142] = true;
							}
							if (NPC.downedMechBossAny && num24 < 1)
							{
								Main.nextNPC[178] = true;
							}
							if (flag6 && num25 < 1 && (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3 || flag7))
							{
								Main.nextNPC[207] = true;
							}
							if (NPC.downedQueenBee && num29 < 1)
							{
								Main.nextNPC[228] = true;
							}
							if (NPC.downedPirates && num30 < 1)
							{
								Main.nextNPC[229] = true;
							}
							if (num23 < 1 && Main.hardMode)
							{
								Main.nextNPC[160] = true;
							}
							if (Main.hardMode && NPC.downedPlantBoss && num27 < 1)
							{
								Main.nextNPC[209] = true;
							}
							if (num34 >= 8 && num28 < 1)
							{
								Main.nextNPC[227] = true;
							}
							if (flag8 && num26 < 1 && num34 >= 14)
							{
								Main.nextNPC[208] = true;
							}
							if (WorldGen.spawnNPC == 0 && num15 < 1)
							{
								WorldGen.spawnNPC = 22;
							}
							if (WorldGen.spawnNPC == 0 && (double)num35 > 5000 && num11 < 1)
							{
								WorldGen.spawnNPC = 17;
							}
							if (WorldGen.spawnNPC == 0 && flag3 && num12 < 1 && num11 > 0)
							{
								WorldGen.spawnNPC = 18;
							}
							if (WorldGen.spawnNPC == 0 && flag4 && num14 < 1)
							{
								WorldGen.spawnNPC = 19;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedGoblin && num20 < 1)
							{
								WorldGen.spawnNPC = 107;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedTaxCollector && num33 < 1)
							{
								WorldGen.spawnNPC = 441;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedWizard && num19 < 1)
							{
								WorldGen.spawnNPC = 108;
							}
							if (WorldGen.spawnNPC == 0 && Main.hardMode && num23 < 1)
							{
								WorldGen.spawnNPC = 160;
							}
							if (WorldGen.spawnNPC == 0 && (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && num13 < 1)
							{
								WorldGen.spawnNPC = 20;
							}
							if (WorldGen.spawnNPC == 0 && flag5 && num11 > 0 && num17 < 1)
							{
								WorldGen.spawnNPC = 38;
							}
							if (WorldGen.spawnNPC == 0 && NPC.downedQueenBee && num29 < 1)
							{
								WorldGen.spawnNPC = 228;
							}
							if (WorldGen.spawnNPC == 0 && NPC.downedMechBossAny && num24 < 1)
							{
								WorldGen.spawnNPC = 178;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedMech && num21 < 1)
							{
								WorldGen.spawnNPC = 124;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedAngler && num32 < 1)
							{
								WorldGen.spawnNPC = 369;
							}
							if (WorldGen.spawnNPC == 0 && Main.hardMode && NPC.downedPlantBoss && num27 < 1)
							{
								WorldGen.spawnNPC = 209;
							}
							if (WorldGen.spawnNPC == 0 && NPC.downedPirates && num30 < 1)
							{
								WorldGen.spawnNPC = 229;
							}
							if (WorldGen.spawnNPC == 0 && NPC.downedBoss3 && num18 < 1)
							{
								WorldGen.spawnNPC = 54;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedStylist && num31 < 1)
							{
								WorldGen.spawnNPC = 353;
							}
							if (WorldGen.spawnNPC == 0 && flag6 && num25 < 1)
							{
								WorldGen.spawnNPC = 207;
							}
							if (WorldGen.spawnNPC == 0 && num34 >= 8 && num28 < 1)
							{
								WorldGen.spawnNPC = 227;
							}
							if (WorldGen.spawnNPC == 0 && flag8 && num34 >= 14 && num26 < 1)
							{
								WorldGen.spawnNPC = 208;
							}
							if (WorldGen.spawnNPC == 0 && NPC.downedFrost && num22 < 1 && Main.xMas)
							{
								WorldGen.spawnNPC = 142;
							}
						}
					}
				}
			}
			else
			{
				Main.eclipse = false;
				if (!Main.fastForwardTime)
				{
					if (WorldGen.spawnEye && Main.netMode != 1 && Main.time > 4860)
					{
						int num39 = 0;
						while (num39 < 255)
						{
							if (!Main.player[num39].active || Main.player[num39].dead || (double)Main.player[num39].position.Y >= Main.worldSurface * 16)
							{
								num39++;
							}
							else
							{
								NPC.SpawnOnPlayer(num39, 4);
								WorldGen.spawnEye = false;
								break;
							}
						}
					}
					if (WorldGen.spawnHardBoss > 0 && Main.netMode != 1 && Main.time > 4860)
					{
						bool flag9 = false;
						for (int s = 0; s < 200; s++)
						{
							if (Main.npc[s].active && Main.npc[s].boss)
							{
								flag9 = true;
							}
						}
						if (!flag9)
						{
							int num40 = 0;
							while (num40 < 255)
							{
								if (!Main.player[num40].active || Main.player[num40].dead || (double)Main.player[num40].position.Y >= Main.worldSurface * 16)
								{
									num40++;
								}
								else if (WorldGen.spawnHardBoss == 1)
								{
									NPC.SpawnOnPlayer(num40, 134);
									break;
								}
								else if (WorldGen.spawnHardBoss != 2)
								{
									if (WorldGen.spawnHardBoss != 3)
									{
										break;
									}
									NPC.SpawnOnPlayer(num40, 127);
									break;
								}
								else
								{
									NPC.SpawnOnPlayer(num40, 125);
									NPC.SpawnOnPlayer(num40, 126);
									break;
								}
							}
						}
						WorldGen.spawnHardBoss = 0;
					}
				}
				if (Main.time > 32400)
				{
					if (Main.fastForwardTime)
					{
						Main.fastForwardTime = false;
						Main.UpdateSundial();
					}
					Main.CheckXMas();
					Main.checkHalloween();
					Main.AnglerQuestSwap();
					if (Main.invasionDelay > 0)
					{
						Main.invasionDelay = Main.invasionDelay - 1;
					}
					WorldGen.spawnNPC = 0;
					Main.checkForSpawns = 0;
					Main.time = 0;
					if (Main.bloodMoon && Main.netMode != 1)
					{
						AchievementsHelper.NotifyProgressionEvent(5);
					}
					Main.bloodMoon = false;
					Main.stopMoonEvent();
					Main.dayTime = true;
					if (Main.sundialCooldown > 0)
					{
						Main.sundialCooldown = Main.sundialCooldown - 1;
					}
					Main.moonPhase = Main.moonPhase + 1;
					if (Main.moonPhase >= 8)
					{
						Main.moonPhase = 0;
					}
					if (Main.netMode == 2)
					{
						NetMessage.SendData((int)PacketTypes.WorldInfo, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						WorldGen.saveAndPlay();
					}
					if (Main.netMode != 1)
					{
						AchievementsHelper.NotifyProgressionEvent(1);
						if (Main.hardMode && NPC.downedMechBossAny && Main.rand.Next(14) == 0)
						{
							Main.eclipse = true;
							AchievementsHelper.NotifyProgressionEvent(2);
							if (Main.eclipse)
							{
								if (Main.netMode == 0)
								{
									Main.NewText(Lang.misc[20], 50, 255, 130, false);
								}
								else if (Main.netMode == 2)
								{
									NetMessage.SendData((int)PacketTypes.ChatText, -1, -1, Lang.misc[20], 255, 50f, 255f, 130f, 0, 0, 0);
								}
							}
							if (Main.netMode == 2)
							{
								NetMessage.SendData((int)PacketTypes.WorldInfo, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
							}
						}
						else if (!Main.snowMoon && !Main.pumpkinMoon)
						{
							if (WorldGen.shadowOrbSmashed)
							{
								if (!NPC.downedGoblins)
								{
									if (Main.rand.Next(3) == 0)
									{
										Main.StartInvasion(1);
									}
								}
								else if (Main.hardMode && Main.rand.Next(60) == 0 || !Main.hardMode && Main.rand.Next(30) == 0)
								{
									Main.StartInvasion(1);
								}
							}
							if (Main.invasionType == 0 && Main.hardMode && WorldGen.altarCount > 0 && (NPC.downedPirates && Main.rand.Next(50) == 0 || !NPC.downedPirates && Main.rand.Next(30) == 0))
							{
								Main.StartInvasion(3);
							}
						}
					}
				}
				if (Main.time > 16200 && WorldGen.spawnMeteor)
				{
					WorldGen.spawnMeteor = false;
					WorldGen.dropMeteor();
					return;
				}
			}
		}

		public void UpdateWeather()
		{
			Main.cloudLimit = 200;
			if (Main.windSpeed < Main.windSpeedSet)
			{
				Main.windSpeed = Main.windSpeed + 0.001f * (float)Main.dayRate;
				if (Main.windSpeed > Main.windSpeedSet)
				{
					Main.windSpeed = Main.windSpeedSet;
				}
			}
			else if (Main.windSpeed > Main.windSpeedSet)
			{
				Main.windSpeed = Main.windSpeed - 0.001f * (float)Main.dayRate;
				if (Main.windSpeed < Main.windSpeedSet)
				{
					Main.windSpeed = Main.windSpeedSet;
				}
			}
			if (Main.netMode == 1)
			{
				return;
			}
			if (Main.netMode != 2 && Main.gameMenu)
			{
				return;
			}
			Main.windSpeedSpeed = Main.windSpeedSpeed + (float)Main.rand.Next(-10, 11) * 0.0001f;
			if (!Main.dayTime)
			{
				Main.windSpeedSpeed = Main.windSpeedSpeed + (float)Main.rand.Next(-10, 11) * 0.0002f;
			}
			if ((double)Main.windSpeedSpeed < -0.002)
			{
				Main.windSpeedSpeed = -0.002f;
			}
			if ((double)Main.windSpeedSpeed > 0.002)
			{
				Main.windSpeedSpeed = 0.002f;
			}
			Main.windSpeedTemp = Main.windSpeedTemp + Main.windSpeedSpeed;
			if (Main.raining)
			{
				Main.windSpeedTemp = Main.windSpeedTemp + Main.windSpeedSpeed * 2f;
			}
			float single = 0.3f + 0.5f * Main.cloudAlpha;
			if (Main.windSpeedTemp < -single)
			{
				Main.windSpeedTemp = -single;
			}
			if (Main.windSpeedTemp > single)
			{
				Main.windSpeedTemp = single;
			}
			if (Main.rand.Next(60) == 0)
			{
				Main.numCloudsTemp = Main.numCloudsTemp + Main.rand.Next(-1, 2);
			}
			if ((float)Main.rand.Next(1000) < 50f * Main.cloudBGAlpha)
			{
				Main.numCloudsTemp = Main.numCloudsTemp + 1;
			}
			if ((float)Main.rand.Next(1000) < 25f * (1f - Main.cloudBGAlpha))
			{
				Main.numCloudsTemp = Main.numCloudsTemp - 1;
			}
			if ((float)Main.rand.Next(1000) < 200f * Main.cloudAlpha && Main.numCloudsTemp < Main.cloudLimit / 2)
			{
				Main.numCloudsTemp = Main.numCloudsTemp + 1;
			}
			if ((float)Main.rand.Next(1000) < 50f * Main.cloudAlpha)
			{
				Main.numCloudsTemp = Main.numCloudsTemp + 1;
			}
			if (Main.numCloudsTemp > Main.cloudLimit / 4 && Main.rand.Next(100) == 0)
			{
				Main.numCloudsTemp = Main.numCloudsTemp - Main.rand.Next(1, 3);
			}
			if (Main.numCloudsTemp < Main.cloudLimit / 4 && Main.rand.Next(100) == 0)
			{
				Main.numCloudsTemp = Main.numCloudsTemp + Main.rand.Next(1, 3);
			}
			if (Main.cloudBGActive <= 0f && Main.numCloudsTemp > Main.cloudLimit / 2 && Main.cloudAlpha == 0f)
			{
				Main.numCloudsTemp = Main.cloudLimit / 2;
			}
			if (Main.numCloudsTemp < 0)
			{
				Main.numCloudsTemp = 0;
			}
			if (Main.numCloudsTemp > Main.cloudLimit)
			{
				Main.numCloudsTemp = Main.cloudLimit;
			}
			Main.weatherCounter = Main.weatherCounter - Main.dayRate;
			if (Main.weatherCounter <= 0)
			{
				Main.numClouds = Main.numCloudsTemp;
				Main.windSpeedSet = Main.windSpeedTemp;
				Main.weatherCounter = Main.rand.Next(3600, 18000);
				if (Main.netMode == 2)
				{
					NetMessage.SendData((int)PacketTypes.WorldInfo, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
				}
			}
		}

		public static string ValueToCoins(int value)
		{
			int num = value;
			int num1 = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			while (num >= 1000000)
			{
				num = num - 1000000;
				num1++;
			}
			while (num >= 10000)
			{
				num = num - 10000;
				num2++;
			}
			while (num >= 100)
			{
				num = num - 100;
				num3++;
			}
			num4 = num;
			string str = "";
			if (num1 > 0)
			{
				str = string.Concat(str, num1, " platinum ");
			}
			if (num2 > 0)
			{
				str = string.Concat(str, num2, " gold ");
			}
			if (num3 > 0)
			{
				str = string.Concat(str, num3, " silver ");
			}
			if (num4 > 0)
			{
				str = string.Concat(str, num4, " copper ");
			}
			if (str.Length > 0)
			{
				str = str.Substring(0, str.Length - 1);
			}
			return str;
		}

		protected void wallColorCheck(int t, int c)
		{
		}

		protected void woodColorCheck(int t, int c)
		{
		}

		private static int WorldListSortMethod(WorldFileData data1, WorldFileData data2)
		{
			return data1.Name.CompareTo(data2.Name);
		}

		public delegate void OnPlayerSelected(PlayerFileData player);

		public static string WorldPathClassic { get; set; }
	}
}
