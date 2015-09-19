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
using Terraria.DataStructures;
using Terraria.GameContent;
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

		public const int maxItemTypes = 3602;

		public const int maxProjectileTypes = 651;

		public const int maxNPCTypes = 540;

		public const int maxTileSets = 419;

		public const int maxWallTypes = 225;

		public const int maxBuffTypes = 191;

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
			Main.projectileLoaded = new bool[651];
			Main.itemFlameLoaded = new bool[Main.maxItemTypes];
			Main.backgroundLoaded = new bool[207];
			Main.tileSetsLoaded = new bool[419];
			Main.wallLoaded = new bool[225];
			Main.NPCLoaded = new bool[540];
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
			Main.nextNPC = new bool[540];
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
			Main.projHostile = new bool[651];
			Main.projHook = new bool[651];
			Main.pvpBuff = new bool[191];
			Main.persistentBuff = new bool[191];
			Main.vanityPet = new bool[191];
			Main.lightPet = new bool[191];
			Main.meleeBuff = new bool[191];
			Main.debuff = new bool[191];
			Main.buffName = new string[191];
			Main.buffTip = new string[191];
			Main.buffNoSave = new bool[191];
			Main.buffNoTimeDisplay = new bool[191];
			Main.buffDoubleApply = new bool[191];
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
			Main.buffAlpha = new float[191];
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
			Main.slimeRainNPC = new bool[540];
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
			Main.projFrames = new int[651];
			Main.projPet = new bool[651];
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
			Main.tileAltTextureInit = new bool[419, Main.numTileColors];
			Main.tileAltTextureDrawn = new bool[419, Main.numTileColors];
			Main.numTreeStyles = 19;
			Main.treeAltTextureInit = new bool[Main.numTreeStyles, Main.numTileColors];
			Main.treeAltTextureDrawn = new bool[Main.numTreeStyles, Main.numTileColors];
			Main.checkTreeAlt = new bool[Main.numTreeStyles, Main.numTileColors];
			Main.wallAltTextureInit = new bool[225, Main.numTileColors];
			Main.wallAltTextureDrawn = new bool[225, Main.numTileColors];
			Main.musicFade = new float[40];
			Main.musicVolume = 0.75f;
			Main.ambientVolume = 0.75f;
			Main.soundVolume = 1f;
			Main.MenuServerMode = ServerSocialMode.None;
			Main.tileLighted = new bool[419];
			Main.tileMergeDirt = new bool[419];
			Main.tileCut = new bool[419];
			Main.tileAlch = new bool[419];
			Main.tileShine = new int[419];
			Main.tileShine2 = new bool[419];
			Main.wallHouse = new bool[225];
			Main.wallDungeon = new bool[225];
			Main.wallLight = new bool[225];
			Main.wallBlend = new int[225];
			Main.tileStone = new bool[419];
			Main.tileAxe = new bool[419];
			Main.tileHammer = new bool[419];
			Main.tileWaterDeath = new bool[419];
			Main.tileLavaDeath = new bool[419];
			Main.tileTable = new bool[419];
			Main.tileBlockLight = new bool[419];
			Main.tileNoSunLight = new bool[419];
			Main.tileDungeon = new bool[419];
			Main.tileSpelunker = new bool[419];
			Main.tileSolidTop = new bool[419];
			Main.tileSolid = new bool[419];
			Main.tileBouncy = new bool[419];
			Main.tileValue = new short[419];
			Main.tileLargeFrames = new byte[419];
			Main.wallLargeFrames = new byte[225];
			Main.tileRope = new bool[419];
			Main.tileBrick = new bool[419];
			Main.tileMoss = new bool[419];
			Main.tileNoAttach = new bool[419];
			Main.tileNoFail = new bool[419];
			Main.tileObsidianKill = new bool[419];
			Main.tileFrameImportant = new bool[419];
			Main.tilePile = new bool[419];
			Main.tileBlendAll = new bool[419];
			Main.tileGlowMask = new short[419];
			Main.tileContainer = new bool[419];
			Main.tileSign = new bool[419];
			Main.tileMerge = new bool[419][];
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
			Main.tileSand = new bool[419];
			Main.tileFlame = new bool[419];
			Main.npcCatchable = new bool[540];
			Main.tileFrame = new int[419];
			Main.tileFrameCounter = new int[419];
			Main.wallFrame = new byte[225];
			Main.wallFrameCounter = new byte[225];
			Main.backgroundWidth = new int[207];
			Main.backgroundHeight = new int[207];
			Main.tilesLoaded = false;
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
			Main.npcName = new string[540];
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
			NetMessage.SendData(4, -1, -1, Main.player[Main.myPlayer].name, Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
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
					if (Main.npc[i].type == 398 && Main.npc[i].ai[0] >= 0f)
					{
						int num = i;
						int num1 = -1;
						int num2 = -1;
						int num3 = -1;
						for (int j = 0; j < 200; j++)
						{
							if (Main.npc[j].active && Main.npc[j].ai[3] == (float)num)
							{
								if (num1 == -1 && Main.npc[j].type == 397 && Main.npc[j].ai[2] == 0f)
								{
									num1 = j;
								}
								if (num2 == -1 && Main.npc[j].type == 397 && Main.npc[j].ai[2] == 1f)
								{
									num2 = j;
								}
								if (num3 == -1 && Main.npc[j].type == 396)
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
					else if (Main.npc[i].type == 421 && Main.npc[i].ai[0] == 5f)
					{
						this.DrawCacheNPCsOverPlayers.Add(i);
					}
					else if (Main.npc[i].type == 516 || Main.npc[i].type == 519)
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
					if (Main.projectile[i].type == 578 || Main.projectile[i].type == 579 || Main.projectile[i].type == 641 || Main.projectile[i].type == 598 || Main.projectile[i].type == 617 || Main.projectile[i].type == 636)
					{
						this.DrawCacheProjsBehindNPCsAndTiles.Add(i);
					}
					if (Main.projectile[i].type == 625 || Main.projectile[i].type == 626 || Main.projectile[i].type == 627 || Main.projectile[i].type == 628)
					{
						this.DrawCacheProjsBehindProjectiles.Add(i);
					}
					if (Main.projectile[i].type == 636 || Main.projectile[i].type == 598)
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
			Main.tileLighted[237] = true;
			Main.tileLighted[27] = true;
			Main.tileLighted[381] = true;
			Main.tileLighted[184] = true;
			Main.slimeRainNPC[1] = true;
			Main.debuff[158] = true;
			Main.debuff[160] = true;
			Main.debuff[20] = true;
			Main.debuff[21] = true;
			Main.debuff[22] = true;
			Main.debuff[23] = true;
			Main.debuff[24] = true;
			Main.debuff[25] = true;
			Main.debuff[28] = true;
			Main.debuff[30] = true;
			Main.debuff[31] = true;
			Main.debuff[32] = true;
			Main.debuff[33] = true;
			Main.debuff[34] = true;
			Main.debuff[35] = true;
			Main.debuff[36] = true;
			Main.debuff[37] = true;
			Main.debuff[38] = true;
			Main.debuff[39] = true;
			Main.debuff[44] = true;
			Main.debuff[46] = true;
			Main.debuff[47] = true;
			Main.debuff[67] = true;
			Main.debuff[68] = true;
			Main.debuff[69] = true;
			Main.debuff[70] = true;
			Main.debuff[80] = true;
			Main.debuff[86] = true;
			Main.debuff[87] = true;
			Main.debuff[88] = true;
			Main.debuff[89] = true;
			Main.debuff[94] = true;
			Main.debuff[103] = true;
			Main.debuff[119] = true;
			Main.debuff[120] = true;
			Main.debuff[137] = true;
			Main.debuff[145] = true;
			Main.debuff[146] = true;
			Main.debuff[147] = true;
			Main.debuff[148] = true;
			Main.debuff[149] = true;
			Main.debuff[156] = true;
			Main.debuff[157] = true;
			Main.debuff[163] = true;
			Main.debuff[164] = true;
			Main.debuff[144] = true;
			Main.pvpBuff[20] = true;
			Main.pvpBuff[24] = true;
			Main.pvpBuff[31] = true;
			Main.pvpBuff[39] = true;
			Main.pvpBuff[44] = true;
			Main.pvpBuff[20] = true;
			Main.pvpBuff[69] = true;
			Main.pvpBuff[103] = true;
			Main.pvpBuff[119] = true;
			Main.pvpBuff[120] = true;
			Main.pvpBuff[137] = true;
			Main.meleeBuff[71] = true;
			Main.meleeBuff[73] = true;
			Main.meleeBuff[74] = true;
			Main.meleeBuff[75] = true;
			Main.meleeBuff[76] = true;
			Main.meleeBuff[77] = true;
			Main.meleeBuff[78] = true;
			Main.meleeBuff[79] = true;
			Main.buffNoSave[20] = true;
			Main.buffNoSave[22] = true;
			Main.buffNoSave[23] = true;
			Main.buffNoSave[24] = true;
			Main.buffNoSave[28] = true;
			Main.buffNoSave[30] = true;
			Main.buffNoSave[31] = true;
			Main.buffNoSave[34] = true;
			Main.buffNoSave[35] = true;
			Main.buffNoSave[37] = true;
			Main.buffNoSave[38] = true;
			Main.buffNoSave[39] = true;
			Main.buffNoSave[43] = true;
			Main.buffNoSave[44] = true;
			Main.buffNoSave[46] = true;
			Main.buffNoSave[47] = true;
			Main.buffNoSave[48] = true;
			Main.buffNoSave[58] = true;
			Main.buffNoSave[59] = true;
			Main.buffNoSave[60] = true;
			Main.buffNoSave[62] = true;
			Main.buffNoSave[63] = true;
			Main.buffNoSave[64] = true;
			Main.buffNoSave[67] = true;
			Main.buffNoSave[68] = true;
			Main.buffNoSave[69] = true;
			Main.buffNoSave[70] = true;
			Main.buffNoSave[72] = true;
			Main.buffNoSave[80] = true;
			Main.buffNoSave[87] = true;
			Main.buffNoSave[158] = true;
			Main.buffNoSave[146] = true;
			Main.buffNoSave[147] = true;
			Main.buffNoSave[88] = true;
			Main.buffNoSave[89] = true;
			Main.buffNoSave[94] = true;
			Main.buffNoSave[95] = true;
			Main.buffNoSave[96] = true;
			Main.buffNoSave[97] = true;
			Main.buffNoSave[98] = true;
			Main.buffNoSave[99] = true;
			Main.buffNoSave[100] = true;
			Main.buffNoSave[103] = true;
			Main.buffNoSave[118] = true;
			Main.buffNoSave[138] = true;
			Main.buffNoSave[167] = true;
			Main.buffNoSave[166] = true;
			Main.buffNoSave[184] = true;
			Main.buffNoSave[185] = true;
			Main.buffNoSave[119] = true;
			Main.buffNoSave[120] = true;
			Main.buffNoSave[90] = true;
			Main.buffNoSave[125] = true;
			Main.buffNoSave[126] = true;
			Main.buffNoSave[128] = true;
			Main.buffNoSave[129] = true;
			Main.buffNoSave[130] = true;
			Main.buffNoSave[131] = true;
			Main.buffNoSave[132] = true;
			Main.buffNoSave[133] = true;
			Main.buffNoSave[134] = true;
			Main.buffNoSave[135] = true;
			Main.buffNoSave[139] = true;
			Main.buffNoSave[140] = true;
			Main.buffNoSave[141] = true;
			Main.buffNoSave[142] = true;
			Main.buffNoSave[143] = true;
			Main.buffNoSave[137] = true;
			Main.buffNoSave[144] = true;
			Main.buffNoSave[161] = true;
			Main.buffNoSave[162] = true;
			Main.buffNoSave[163] = true;
			Main.buffNoSave[164] = true;
			Main.buffNoSave[168] = true;
			Main.buffNoSave[170] = true;
			Main.buffNoSave[171] = true;
			Main.buffNoSave[172] = true;
			Main.buffNoSave[182] = true;
			Main.buffNoSave[187] = true;
			Main.buffNoSave[188] = true;
			for (int j = 173; j <= 181; j++)
			{
				Main.buffNoSave[j] = true;
			}
			Main.buffNoTimeDisplay[19] = true;
			Main.buffNoTimeDisplay[27] = true;
			Main.buffNoTimeDisplay[28] = true;
			Main.buffNoTimeDisplay[34] = true;
			Main.buffNoTimeDisplay[37] = true;
			Main.buffNoTimeDisplay[38] = true;
			Main.buffNoTimeDisplay[40] = true;
			Main.buffNoTimeDisplay[41] = true;
			Main.buffNoTimeDisplay[42] = true;
			Main.buffNoTimeDisplay[43] = true;
			Main.buffNoTimeDisplay[45] = true;
			Main.buffNoTimeDisplay[49] = true;
			Main.buffNoTimeDisplay[60] = true;
			Main.buffNoTimeDisplay[62] = true;
			Main.buffNoTimeDisplay[64] = true;
			Main.buffNoTimeDisplay[68] = true;
			Main.buffNoTimeDisplay[81] = true;
			Main.buffNoTimeDisplay[82] = true;
			Main.buffNoTimeDisplay[83] = true;
			Main.buffNoTimeDisplay[90] = true;
			Main.buffNoTimeDisplay[95] = true;
			Main.buffNoTimeDisplay[96] = true;
			Main.buffNoTimeDisplay[97] = true;
			Main.buffNoTimeDisplay[98] = true;
			Main.buffNoTimeDisplay[99] = true;
			Main.buffNoTimeDisplay[100] = true;
			Main.buffNoTimeDisplay[101] = true;
			Main.buffNoTimeDisplay[102] = true;
			Main.buffNoTimeDisplay[118] = true;
			Main.buffNoTimeDisplay[138] = true;
			Main.buffNoTimeDisplay[167] = true;
			Main.buffNoTimeDisplay[166] = true;
			Main.buffNoTimeDisplay[184] = true;
			Main.buffNoTimeDisplay[185] = true;
			Main.buffNoTimeDisplay[125] = true;
			Main.buffNoTimeDisplay[126] = true;
			Main.buffNoTimeDisplay[128] = true;
			Main.buffNoTimeDisplay[129] = true;
			Main.buffNoTimeDisplay[130] = true;
			Main.buffNoTimeDisplay[131] = true;
			Main.buffNoTimeDisplay[132] = true;
			Main.buffNoTimeDisplay[133] = true;
			Main.buffNoTimeDisplay[134] = true;
			Main.buffNoTimeDisplay[135] = true;
			Main.buffNoTimeDisplay[136] = true;
			Main.buffNoTimeDisplay[139] = true;
			Main.buffNoTimeDisplay[140] = true;
			Main.buffNoTimeDisplay[141] = true;
			Main.buffNoTimeDisplay[142] = true;
			Main.buffNoTimeDisplay[143] = true;
			Main.buffNoTimeDisplay[137] = true;
			Main.buffNoTimeDisplay[145] = true;
			Main.buffNoTimeDisplay[161] = true;
			Main.buffNoTimeDisplay[162] = true;
			Main.buffNoTimeDisplay[163] = true;
			Main.buffNoTimeDisplay[168] = true;
			Main.buffNoTimeDisplay[170] = true;
			Main.buffNoTimeDisplay[171] = true;
			Main.buffNoTimeDisplay[172] = true;
			Main.buffNoTimeDisplay[182] = true;
			Main.buffNoTimeDisplay[165] = true;
			Main.buffNoTimeDisplay[186] = true;
			Main.buffNoTimeDisplay[187] = true;
			Main.buffNoTimeDisplay[188] = true;
			Main.persistentBuff[71] = true;
			Main.persistentBuff[73] = true;
			Main.persistentBuff[74] = true;
			Main.persistentBuff[75] = true;
			Main.persistentBuff[76] = true;
			Main.persistentBuff[77] = true;
			Main.persistentBuff[78] = true;
			Main.persistentBuff[79] = true;
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
			Main.tileFlame[4] = true;
			Main.tileFlame[33] = true;
			Main.tileFlame[34] = true;
			Main.tileFlame[35] = true;
			Main.tileFlame[42] = true;
			Main.tileFlame[49] = true;
			Main.tileFlame[93] = true;
			Main.tileFlame[98] = true;
			Main.tileFlame[100] = true;
			Main.tileFlame[173] = true;
			Main.tileFlame[174] = true;
			Main.tileFlame[372] = true;
			Main.tileRope[213] = true;
			Main.tileRope[214] = true;
			Main.tileRope[353] = true;
			Main.tileRope[365] = true;
			Main.tileRope[366] = true;
			Main.tilePile[330] = true;
			Main.tilePile[331] = true;
			Main.tilePile[332] = true;
			Main.tilePile[333] = true;
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
			Main.tileSpelunker[6] = true;
			Main.tileSpelunker[7] = true;
			Main.tileSpelunker[8] = true;
			Main.tileSpelunker[9] = true;
			Main.tileSpelunker[12] = true;
			Main.tileSpelunker[21] = true;
			Main.tileSpelunker[28] = true;
			Main.tileSpelunker[107] = true;
			Main.tileSpelunker[108] = true;
			Main.tileSpelunker[111] = true;
			Main.tileSpelunker[63] = true;
			Main.tileSpelunker[64] = true;
			Main.tileSpelunker[65] = true;
			Main.tileSpelunker[66] = true;
			Main.tileSpelunker[67] = true;
			Main.tileSpelunker[68] = true;
			Main.tileSpelunker[166] = true;
			Main.tileSpelunker[167] = true;
			Main.tileSpelunker[168] = true;
			Main.tileSpelunker[169] = true;
			Main.tileSpelunker[178] = true;
			Main.tileSpelunker[211] = true;
			Main.tileSpelunker[221] = true;
			Main.tileSpelunker[222] = true;
			Main.tileSpelunker[223] = true;
			Main.tileSpelunker[236] = true;
			Main.tileSpelunker[37] = true;
			Main.tileSpelunker[407] = true;
			Main.tileSpelunker[227] = true;
			Main.SetupTileMerge();
			Main.tileSolid[379] = true;
			Main.tileSolid[371] = true;
			Main.tileMergeDirt[371] = true;
			Main.tileBlockLight[371] = true;
			Main.tileBouncy[371] = true;
			Main.tileFrameImportant[377] = true;
			Main.tileFrameImportant[373] = true;
			Main.tileFrameImportant[375] = true;
			Main.tileFrameImportant[374] = true;
			Main.tileLighted[372] = true;
			Main.tileFrameImportant[372] = true;
			Main.tileWaterDeath[372] = true;
			Main.tileLavaDeath[372] = true;
			Main.tileSolid[357] = true;
			Main.tileBrick[357] = true;
			Main.tileSolid[408] = true;
			Main.tileMergeDirt[408] = true;
			Main.tileBrick[408] = true;
			Main.tileSolid[409] = true;
			Main.tileBrick[409] = true;
			Main.tileSolid[415] = true;
			Main.tileBrick[415] = true;
			Main.tileLighted[415] = true;
			Main.tileSolid[416] = true;
			Main.tileBrick[416] = true;
			Main.tileLighted[416] = true;
			Main.tileSolid[417] = true;
			Main.tileBrick[417] = true;
			Main.tileLighted[417] = true;
			Main.tileSolid[418] = true;
			Main.tileBrick[418] = true;
			Main.tileLighted[418] = true;
			Main.tileBrick[37] = true;
			Main.tileBrick[117] = true;
			Main.tileBrick[25] = true;
			Main.tileBrick[203] = true;
			Main.tileSolid[232] = true;
			Main.tileSolid[311] = true;
			Main.tileSolid[312] = true;
			Main.tileSolid[313] = true;
			Main.tileMergeDirt[311] = true;
			Main.tileSolid[315] = true;
			Main.tileMergeDirt[315] = true;
			Main.tileSolid[321] = true;
			Main.tileSolid[322] = true;
			Main.tileBlockLight[321] = true;
			Main.tileBlockLight[322] = true;
			Main.tileMergeDirt[321] = true;
			Main.tileMergeDirt[322] = true;
			Main.tileBrick[321] = true;
			Main.tileBrick[322] = true;
			Main.tileShine[239] = 1100;
			Main.tileSolid[239] = true;
			Main.tileSolidTop[239] = true;
			Main.tileSolid[380] = true;
			Main.tileSolidTop[380] = true;
			Main.tileFrameImportant[358] = true;
			Main.tileFrameImportant[359] = true;
			Main.tileFrameImportant[360] = true;
			Main.tileFrameImportant[361] = true;
			Main.tileFrameImportant[362] = true;
			Main.tileFrameImportant[363] = true;
			Main.tileFrameImportant[364] = true;
			Main.tileFrameImportant[391] = true;
			Main.tileLighted[391] = true;
			Main.tileFrameImportant[392] = true;
			Main.tileFrameImportant[393] = true;
			Main.tileFrameImportant[394] = true;
			Main.tileFrameImportant[356] = true;
			Main.tileFrameImportant[334] = true;
			Main.tileFrameImportant[300] = true;
			Main.tileFrameImportant[301] = true;
			Main.tileFrameImportant[302] = true;
			Main.tileFrameImportant[303] = true;
			Main.tileFrameImportant[304] = true;
			Main.tileFrameImportant[305] = true;
			Main.tileFrameImportant[306] = true;
			Main.tileFrameImportant[307] = true;
			Main.tileFrameImportant[308] = true;
			Main.tileFrameImportant[354] = true;
			Main.tileFrameImportant[355] = true;
			Main.tileFrameImportant[324] = true;
			Main.tileObsidianKill[324] = true;
			Main.tileLavaDeath[324] = true;
			Main.tileFrameImportant[283] = true;
			Main.tileFrameImportant[288] = true;
			Main.tileFrameImportant[289] = true;
			Main.tileFrameImportant[290] = true;
			Main.tileFrameImportant[291] = true;
			Main.tileFrameImportant[292] = true;
			Main.tileFrameImportant[293] = true;
			Main.tileFrameImportant[294] = true;
			Main.tileFrameImportant[295] = true;
			Main.tileFrameImportant[296] = true;
			Main.tileFrameImportant[297] = true;
			Main.tileFrameImportant[316] = true;
			Main.tileFrameImportant[317] = true;
			Main.tileFrameImportant[318] = true;
			Main.tileLargeFrames[284] = 1;
			Main.wallHouse[224] = true;
			Main.wallLargeFrames[224] = 2;
			Main.tileLargeFrames[409] = 1;
			Main.tileFrameImportant[410] = true;
			Main.wallHouse[173] = true;
			Main.wallHouse[183] = true;
			Main.wallHouse[179] = true;
			Main.wallLargeFrames[179] = 1;
			Main.tileSolid[367] = true;
			Main.tileBlockLight[367] = true;
			Main.tileMergeDirt[367] = true;
			Main.tileSolid[357] = true;
			Main.tileBlockLight[357] = true;
			Main.tileLargeFrames[357] = 1;
			Main.tileBlendAll[357] = true;
			Main.wallHouse[184] = true;
			Main.wallHouse[181] = true;
			Main.tileSolid[368] = true;
			Main.tileBlockLight[368] = true;
			Main.tileMergeDirt[368] = true;
			Main.tileSolid[369] = true;
			Main.tileBlockLight[369] = true;
			Main.tileBrick[369] = true;
			Main.tileMergeDirt[369] = true;
			Main.wallHouse[186] = true;
			Main.tileLargeFrames[325] = 1;
			Main.tileSolid[325] = true;
			Main.tileBlockLight[325] = true;
			Main.wallLargeFrames[146] = 1;
			Main.wallLargeFrames[147] = 1;
			Main.wallLargeFrames[167] = 1;
			Main.wallLargeFrames[185] = 2;
			Main.tileSolid[326] = true;
			Main.tileBlockLight[326] = true;
			Main.tileSolid[327] = true;
			Main.tileBlockLight[327] = true;
			Main.tileSolid[345] = true;
			Main.tileBlockLight[345] = true;
			Main.tileLighted[327] = true;
			Main.tileSolid[328] = true;
			Main.tileBrick[328] = true;
			Main.tileSolid[329] = true;
			Main.tileBrick[329] = true;
			Main.tileBlockLight[329] = true;
			Main.tileLighted[336] = true;
			Main.tileLighted[340] = true;
			Main.tileLighted[341] = true;
			Main.tileLighted[342] = true;
			Main.tileLighted[343] = true;
			Main.tileLighted[344] = true;
			Main.tileLighted[349] = true;
			Main.tileSolid[284] = true;
			Main.tileBlockLight[284] = true;
			Main.tileSolid[346] = true;
			Main.tileBlockLight[346] = true;
			Main.tileLighted[346] = true;
			Main.tileShine[346] = 2000;
			Main.tileShine2[346] = true;
			Main.tileBrick[346] = true;
			Main.tileMergeDirt[346] = true;
			Main.tileSolid[347] = true;
			Main.tileBlockLight[347] = true;
			Main.tileLighted[347] = true;
			Main.tileShine[347] = 1900;
			Main.tileShine2[347] = true;
			Main.tileBrick[347] = true;
			Main.tileMergeDirt[347] = true;
			Main.tileSolid[348] = true;
			Main.tileBlockLight[348] = true;
			Main.tileLighted[348] = true;
			Main.tileShine[348] = 1800;
			Main.tileShine2[348] = true;
			Main.tileBrick[348] = true;
			Main.tileMergeDirt[348] = true;
			Main.tileSolid[350] = true;
			Main.tileBlockLight[350] = true;
			Main.tileLighted[350] = true;
			Main.tileBrick[350] = true;
			Main.tileMergeDirt[350] = true;
			Main.tileGlowMask[350] = 94;
			Main.tileGlowMask[390] = 130;
			Main.tileGlowMask[381] = 126;
			Main.tileGlowMask[370] = 111;
			Main.tileGlowMask[391] = 131;
			Main.tileGlowMask[410] = 201;
			Main.tileSolid[370] = true;
			Main.tileBlockLight[370] = true;
			Main.tileLighted[370] = true;
			Main.tileShine[370] = 1900;
			Main.tileShine2[370] = true;
			Main.tileBrick[370] = true;
			Main.tileMergeDirt[370] = true;
			Main.tileContainer[21] = true;
			Main.tileContainer[88] = true;
			Main.tileSign[55] = true;
			Main.tileSign[85] = true;
			Main.tileSolid[383] = true;
			Main.tileBrick[383] = true;
			Main.tileBlockLight[383] = true;
			Main.tileSolid[385] = true;
			Main.tileBrick[385] = true;
			Main.tileBlockLight[385] = true;
			Main.tileSolid[396] = true;
			Main.tileBlockLight[396] = true;
			Main.tileSolid[397] = true;
			Main.tileBlockLight[397] = true;
			Main.tileSolid[399] = true;
			Main.tileBlockLight[399] = true;
			Main.tileSolid[401] = true;
			Main.tileBlockLight[401] = true;
			Main.tileSolid[398] = true;
			Main.tileBlockLight[398] = true;
			Main.tileSolid[400] = true;
			Main.tileBlockLight[400] = true;
			Main.tileSolid[402] = true;
			Main.tileBlockLight[402] = true;
			Main.tileSolid[403] = true;
			Main.tileBlockLight[403] = true;
			Main.tileSolid[404] = true;
			Main.tileBlockLight[404] = true;
			Main.tileSolid[407] = true;
			Main.tileBlockLight[407] = true;
			Main.tileShine2[407] = true;
			Main.tileShine[407] = 1000;
			Main.tileFrameImportant[36] = true;
			Main.tileFrameImportant[275] = true;
			Main.tileFrameImportant[276] = true;
			Main.tileFrameImportant[277] = true;
			Main.tileFrameImportant[278] = true;
			Main.tileFrameImportant[279] = true;
			Main.tileFrameImportant[280] = true;
			Main.tileFrameImportant[281] = true;
			Main.tileFrameImportant[282] = true;
			Main.tileFrameImportant[285] = true;
			Main.tileFrameImportant[286] = true;
			Main.tileFrameImportant[414] = true;
			Main.tileFrameImportant[413] = true;
			Main.tileFrameImportant[309] = true;
			Main.tileFrameImportant[310] = true;
			Main.tileFrameImportant[339] = true;
			Main.tileLighted[286] = true;
			Main.tileLighted[302] = true;
			Main.tileFrameImportant[298] = true;
			Main.tileFrameImportant[299] = true;
			Main.tileSolid[170] = true;
			Main.tileFrameImportant[171] = true;
			Main.tileLighted[171] = true;
			Main.tileFrameImportant[247] = true;
			Main.tileFrameImportant[245] = true;
			Main.tileFrameImportant[246] = true;
			Main.tileFrameImportant[239] = true;
			Main.tileFrameImportant[240] = true;
			Main.tileFrameImportant[241] = true;
			Main.tileFrameImportant[242] = true;
			Main.tileFrameImportant[243] = true;
			Main.tileFrameImportant[244] = true;
			Main.tileFrameImportant[254] = true;
			Main.tileSolid[221] = true;
			Main.tileBlockLight[221] = true;
			Main.tileMergeDirt[221] = true;
			Main.tileLighted[96] = true;
			Main.tileMergeDirt[250] = true;
			Main.tileSolid[272] = true;
			Main.tileBlockLight[272] = true;
			Main.tileSolid[229] = true;
			Main.tileBlockLight[229] = true;
			Main.tileMergeDirt[229] = true;
			Main.tileSolid[230] = true;
			Main.tileBlockLight[230] = true;
			Main.tileMergeDirt[230] = true;
			Main.tileSolid[222] = true;
			Main.tileBlockLight[222] = true;
			Main.tileMergeDirt[222] = true;
			Main.tileSolid[223] = true;
			Main.tileBlockLight[223] = true;
			Main.tileMergeDirt[223] = true;
			Main.tileSolid[224] = true;
			Main.tileBlockLight[224] = true;
			Main.tileFrameImportant[237] = true;
			Main.tileFrameImportant[238] = true;
			Main.tileSolid[225] = true;
			Main.tileBlockLight[225] = true;
			Main.tileBrick[225] = true;
			Main.tileSolid[226] = true;
			Main.tileBlockLight[226] = true;
			Main.tileBrick[226] = true;
			Main.tileSolid[235] = true;
			Main.tileBlockLight[235] = true;
			Main.tileFrameImportant[235] = true;
			Main.tileLighted[238] = true;
			Main.tileFrameImportant[236] = true;
			Main.tileCut[236] = true;
			Main.tileSolid[191] = true;
			Main.tileBrick[191] = true;
			Main.tileBlockLight[191] = true;
			Main.tileSolid[211] = true;
			Main.tileBlockLight[211] = true;
			Main.tileSolid[208] = true;
			Main.tileBrick[208] = true;
			Main.tileBlockLight[208] = true;
			Main.tileSolid[192] = true;
			Main.tileBrick[192] = true;
			Main.tileBlockLight[192] = true;
			Main.tileSolid[193] = true;
			Main.tileBrick[193] = true;
			Main.tileBlockLight[193] = true;
			Main.tileMergeDirt[193] = true;
			Main.tileSolid[194] = true;
			Main.tileBrick[194] = true;
			Main.tileBlockLight[194] = true;
			Main.tileSolid[195] = true;
			Main.tileBrick[195] = true;
			Main.tileMergeDirt[195] = true;
			Main.tileBlockLight[195] = true;
			Main.tileBlockLight[200] = true;
			Main.tileSolid[200] = true;
			Main.tileBrick[200] = true;
			Main.tileBlockLight[203] = true;
			Main.tileSolid[203] = true;
			Main.tileMergeDirt[203] = true;
			Main.tileBlockLight[204] = true;
			Main.tileSolid[204] = true;
			Main.tileMergeDirt[204] = true;
			Main.tileBlockLight[165] = true;
			Main.tileShine2[147] = true;
			Main.tileShine2[161] = true;
			Main.tileShine2[163] = true;
			Main.tileShine2[164] = true;
			Main.tileSolid[189] = true;
			Main.tileBlockLight[51] = true;
			Main.tileLighted[204] = true;
			Main.tileShine[204] = 1150;
			Main.tileShine2[204] = true;
			Main.tileSolid[190] = true;
			Main.tileBlockLight[190] = true;
			Main.tileBrick[190] = true;
			Main.tileSolid[198] = true;
			Main.tileMergeDirt[198] = true;
			Main.tileBrick[198] = true;
			Main.tileBlockLight[198] = true;
			Main.tileSolid[206] = true;
			Main.tileBlockLight[206] = true;
			Main.tileMergeDirt[206] = true;
			Main.tileBrick[206] = true;
			Main.tileBlockLight[234] = true;
			Main.tileSolid[248] = true;
			Main.tileSolid[249] = true;
			Main.tileSolid[250] = true;
			Main.tileBrick[248] = true;
			Main.tileBrick[249] = true;
			Main.tileBrick[250] = true;
			Main.tileSolid[251] = true;
			Main.tileSolid[252] = true;
			Main.tileBrick[252] = true;
			Main.tileSolid[253] = true;
			Main.tileBrick[253] = true;
			Main.tileMergeDirt[251] = true;
			Main.tileMergeDirt[252] = true;
			Main.tileMergeDirt[253] = true;
			Main.tileBlockLight[251] = true;
			Main.tileBlockLight[252] = true;
			Main.tileBlockLight[253] = true;
			Main.tileBlockLight[248] = true;
			Main.tileBlockLight[249] = true;
			Main.tileBlockLight[250] = true;
			Main.tileLargeFrames[273] = 1;
			Main.tileSolid[273] = true;
			Main.tileBlockLight[273] = true;
			Main.tileLargeFrames[274] = 1;
			Main.tileSolid[274] = true;
			Main.tileBlockLight[274] = true;
			for (int m = 255; m <= 268; m++)
			{
				Main.tileSolid[m] = true;
				if (m > 261)
				{
					Main.tileLighted[m] = true;
					Main.tileShine2[m] = true;
				}
			}
			Main.tileFrameImportant[269] = true;
			Main.tileFrameImportant[334] = true;
			Main.tileFrameImportant[390] = true;
			Main.tileNoAttach[390] = true;
			Main.tileLavaDeath[390] = true;
			Main.tileLighted[390] = true;
			Main.wallHouse[168] = true;
			Main.wallHouse[169] = true;
			Main.wallHouse[142] = true;
			Main.wallHouse[143] = true;
			Main.wallHouse[144] = true;
			Main.wallHouse[149] = true;
			Main.wallHouse[151] = true;
			Main.wallHouse[150] = true;
			Main.wallHouse[152] = true;
			Main.wallHouse[175] = true;
			Main.wallHouse[176] = true;
			Main.wallHouse[182] = true;
			for (int n = 153; n < 167; n++)
			{
				Main.wallHouse[n] = true;
			}
			Main.wallHouse[146] = true;
			Main.wallHouse[147] = true;
			Main.wallHouse[149] = true;
			Main.wallHouse[167] = true;
			Main.wallHouse[168] = true;
			Main.wallHouse[133] = true;
			Main.wallHouse[134] = true;
			Main.wallHouse[135] = true;
			Main.wallHouse[136] = true;
			Main.wallHouse[137] = true;
			Main.wallHouse[75] = true;
			Main.wallHouse[76] = true;
			Main.wallHouse[78] = true;
			Main.wallHouse[82] = true;
			Main.wallHouse[77] = true;
			Main.wallHouse[1] = true;
			Main.wallHouse[4] = true;
			Main.wallHouse[5] = true;
			Main.wallHouse[6] = true;
			Main.wallHouse[10] = true;
			Main.wallHouse[11] = true;
			Main.wallHouse[12] = true;
			Main.wallHouse[16] = true;
			Main.wallHouse[17] = true;
			Main.wallHouse[18] = true;
			Main.wallHouse[19] = true;
			Main.wallHouse[20] = true;
			Main.wallHouse[21] = true;
			Main.wallHouse[22] = true;
			Main.wallHouse[23] = true;
			Main.wallHouse[24] = true;
			Main.wallHouse[25] = true;
			Main.wallHouse[26] = true;
			Main.wallHouse[27] = true;
			Main.wallHouse[29] = true;
			Main.wallHouse[30] = true;
			Main.wallHouse[31] = true;
			Main.wallHouse[32] = true;
			Main.wallHouse[33] = true;
			Main.wallHouse[34] = true;
			Main.wallHouse[35] = true;
			Main.wallHouse[36] = true;
			Main.wallHouse[37] = true;
			Main.wallHouse[38] = true;
			Main.wallHouse[39] = true;
			Main.wallHouse[41] = true;
			Main.wallHouse[42] = true;
			Main.wallHouse[43] = true;
			Main.wallHouse[44] = true;
			Main.wallHouse[45] = true;
			Main.wallHouse[46] = true;
			Main.wallHouse[47] = true;
			Main.wallHouse[66] = true;
			Main.wallHouse[67] = true;
			Main.wallHouse[68] = true;
			Main.wallHouse[72] = true;
			Main.wallHouse[73] = true;
			Main.wallHouse[107] = true;
			Main.wallHouse[106] = true;
			Main.wallHouse[109] = true;
			Main.wallHouse[110] = true;
			Main.wallHouse[111] = true;
			Main.wallHouse[112] = true;
			Main.wallHouse[113] = true;
			Main.wallHouse[114] = true;
			Main.wallHouse[115] = true;
			Main.wallHouse[116] = true;
			Main.wallHouse[117] = true;
			Main.wallHouse[118] = true;
			Main.wallHouse[119] = true;
			Main.wallHouse[120] = true;
			Main.wallHouse[121] = true;
			Main.wallHouse[122] = true;
			Main.wallHouse[123] = true;
			Main.wallHouse[124] = true;
			Main.wallHouse[125] = true;
			Main.wallHouse[108] = true;
			Main.wallHouse[100] = true;
			Main.wallHouse[101] = true;
			Main.wallHouse[102] = true;
			Main.wallHouse[103] = true;
			Main.wallHouse[104] = true;
			Main.wallHouse[105] = true;
			Main.wallHouse[84] = true;
			Main.wallHouse[74] = true;
			Main.wallHouse[85] = true;
			Main.wallHouse[88] = true;
			Main.wallHouse[89] = true;
			Main.wallHouse[90] = true;
			Main.wallHouse[91] = true;
			Main.wallHouse[92] = true;
			Main.wallHouse[93] = true;
			Main.wallHouse[126] = true;
			Main.wallHouse[127] = true;
			Main.wallHouse[128] = true;
			Main.wallHouse[129] = true;
			Main.wallHouse[130] = true;
			Main.wallHouse[131] = true;
			Main.wallHouse[132] = true;
			Main.wallHouse[138] = true;
			Main.wallHouse[139] = true;
			Main.wallHouse[140] = true;
			Main.wallHouse[141] = true;
			Main.wallHouse[177] = true;
			Main.wallHouse[172] = true;
			Main.wallHouse[174] = true;
			Main.wallHouse[223] = true;
			Main.wallLight[0] = true;
			Main.wallLight[21] = true;
			Main.wallLight[106] = true;
			Main.wallLight[107] = true;
			Main.wallLight[138] = true;
			Main.wallLight[140] = true;
			Main.wallLight[141] = true;
			Main.wallLight[139] = true;
			Main.wallLight[145] = true;
			Main.wallLight[150] = true;
			Main.wallLight[152] = true;
			Main.wallLight[168] = true;
			for (int o = 0; o < 225; o++)
			{
				Main.wallDungeon[o] = false;
			}
			Main.wallDungeon[7] = true;
			Main.wallDungeon[8] = true;
			Main.wallDungeon[9] = true;
			Main.wallDungeon[94] = true;
			Main.wallDungeon[95] = true;
			Main.wallDungeon[96] = true;
			Main.wallDungeon[97] = true;
			Main.wallDungeon[98] = true;
			Main.wallDungeon[99] = true;
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
			Main.tileBrick[1] = true;
			Main.tileBrick[54] = true;
			Main.tileBrick[118] = true;
			Main.tileBrick[119] = true;
			Main.tileBrick[120] = true;
			Main.tileBrick[121] = true;
			Main.tileBrick[122] = true;
			Main.tileBrick[140] = true;
			Main.tileBrick[148] = true;
			Main.tileBrick[150] = true;
			Main.tileBrick[151] = true;
			Main.tileBrick[152] = true;
			Main.tileBrick[30] = true;
			Main.tileBrick[38] = true;
			Main.tileBrick[39] = true;
			Main.tileBrick[41] = true;
			Main.tileBrick[43] = true;
			Main.tileBrick[44] = true;
			Main.tileBrick[45] = true;
			Main.tileBrick[46] = true;
			Main.tileBrick[47] = true;
			Main.tileBrick[75] = true;
			Main.tileBrick[76] = true;
			Main.tileBrick[160] = true;
			Main.tileBrick[2] = true;
			Main.tileBrick[199] = true;
			Main.tileBrick[23] = true;
			Main.tileBrick[60] = true;
			Main.tileBrick[70] = true;
			Main.tileBrick[109] = true;
			Main.tileBrick[53] = true;
			Main.tileBrick[116] = true;
			Main.tileBrick[234] = true;
			Main.tileBrick[112] = true;
			Main.tileBrick[147] = true;
			Main.tileBrick[153] = true;
			Main.tileBrick[154] = true;
			Main.tileBrick[155] = true;
			Main.tileBrick[156] = true;
			Main.tileBrick[157] = true;
			Main.tileBrick[158] = true;
			Main.tileBrick[159] = true;
			Main.tileMergeDirt[202] = true;
			Main.tileBrick[202] = true;
			Main.tileSolid[202] = true;
			Main.tileBlockLight[202] = true;
			Main.tileBrick[161] = true;
			Main.tileBlockLight[161] = true;
			Main.tileBlockLight[163] = true;
			Main.tileBlockLight[164] = true;
			Main.tileSolid[188] = true;
			Main.tileBlockLight[188] = true;
			Main.tileBrick[188] = true;
			Main.tileMergeDirt[188] = true;
			Main.tileBrick[179] = true;
			Main.tileSolid[179] = true;
			Main.tileBlockLight[179] = true;
			Main.tileMoss[179] = true;
			Main.tileBrick[381] = true;
			Main.tileSolid[381] = true;
			Main.tileBlockLight[381] = true;
			Main.tileMoss[381] = true;
			Main.tileBrick[180] = true;
			Main.tileSolid[180] = true;
			Main.tileBlockLight[180] = true;
			Main.tileMoss[180] = true;
			Main.tileBrick[181] = true;
			Main.tileSolid[181] = true;
			Main.tileBlockLight[181] = true;
			Main.tileMoss[181] = true;
			Main.tileBrick[182] = true;
			Main.tileSolid[182] = true;
			Main.tileBlockLight[182] = true;
			Main.tileMoss[182] = true;
			Main.tileBrick[183] = true;
			Main.tileSolid[183] = true;
			Main.tileBlockLight[183] = true;
			Main.tileMoss[183] = true;
			Main.tileMergeDirt[177] = true;
			Main.tileMergeDirt[190] = true;
			Main.tileSolid[196] = true;
			Main.tileSolid[197] = true;
			Main.tileMergeDirt[197] = true;
			Main.tileBlockLight[197] = true;
			Main.tileNoSunLight[197] = true;
			Main.tileBrick[175] = true;
			Main.tileSolid[175] = true;
			Main.tileBlockLight[175] = true;
			Main.tileBrick[176] = true;
			Main.tileSolid[176] = true;
			Main.tileBlockLight[176] = true;
			Main.tileBrick[177] = true;
			Main.tileSolid[177] = true;
			Main.tileBlockLight[177] = true;
			Main.tileBrick[225] = true;
			Main.tileBrick[229] = true;
			Main.tileShine[221] = 925;
			Main.tileShine[222] = 875;
			Main.tileShine[223] = 825;
			Main.tileShine2[221] = true;
			Main.tileShine2[222] = true;
			Main.tileShine2[223] = true;
			Main.tileMergeDirt[175] = true;
			Main.tileMergeDirt[176] = true;
			Main.tileMergeDirt[177] = true;
			Main.tileMergeDirt[208] = true;
			Main.tileBrick[162] = true;
			Main.tileSolid[162] = true;
			Main.tileBlockLight[162] = false;
			Main.tileBrick[163] = true;
			Main.tileSolid[163] = true;
			Main.tileBrick[164] = true;
			Main.tileSolid[164] = true;
			Main.tileShine2[6] = true;
			Main.tileShine2[7] = true;
			Main.tileShine2[8] = true;
			Main.tileShine2[9] = true;
			Main.tileShine2[166] = true;
			Main.tileShine2[167] = true;
			Main.tileShine2[168] = true;
			Main.tileShine2[169] = true;
			Main.tileShine2[12] = true;
			Main.tileShine2[21] = true;
			Main.tileShine2[22] = true;
			Main.tileShine2[25] = true;
			Main.tileShine2[45] = true;
			Main.tileShine2[46] = true;
			Main.tileShine2[47] = true;
			Main.tileShine2[63] = true;
			Main.tileShine2[64] = true;
			Main.tileShine2[65] = true;
			Main.tileShine2[66] = true;
			Main.tileShine2[67] = true;
			Main.tileShine2[68] = true;
			Main.tileShine2[107] = true;
			Main.tileShine2[108] = true;
			Main.tileShine2[111] = true;
			Main.tileShine2[121] = true;
			Main.tileShine2[122] = true;
			Main.tileShine2[117] = true;
			Main.tileShine2[211] = true;
			Main.tileShine[129] = 300;
			Main.tileNoFail[330] = true;
			Main.tileNoFail[331] = true;
			Main.tileNoFail[332] = true;
			Main.tileNoFail[333] = true;
			Main.tileNoFail[129] = true;
			Main.tileNoFail[192] = true;
			Main.tileHammer[26] = true;
			Main.tileHammer[31] = true;
			Main.tileAxe[5] = true;
			Main.tileAxe[72] = true;
			Main.tileAxe[80] = true;
			Main.tileAxe[323] = true;
			Main.tileBrick[59] = true;
			Main.tileBrick[234] = true;
			Main.tileSolid[234] = true;
			Main.tileMergeDirt[234] = true;
			Main.tileSand[53] = true;
			Main.tileSand[112] = true;
			Main.tileSand[116] = true;
			Main.tileSand[234] = true;
			Main.tileFrameImportant[233] = true;
			Main.tileLighted[215] = true;
			Main.tileFrameImportant[227] = true;
			Main.tileFrameImportant[228] = true;
			Main.tileFrameImportant[231] = true;
			Main.tileCut[231] = true;
			Main.tileFrameImportant[216] = true;
			Main.tileFrameImportant[217] = true;
			Main.tileFrameImportant[218] = true;
			Main.tileFrameImportant[219] = true;
			Main.tileFrameImportant[220] = true;
			Main.tileFrameImportant[338] = true;
			Main.tileFrameImportant[165] = true;
			Main.tileFrameImportant[209] = true;
			Main.tileFrameImportant[215] = true;
			Main.tileFrameImportant[210] = true;
			Main.tileFrameImportant[212] = true;
			Main.tileFrameImportant[207] = true;
			Main.tileFrameImportant[178] = true;
			Main.tileFrameImportant[184] = true;
			Main.tileFrameImportant[185] = true;
			Main.tileFrameImportant[186] = true;
			Main.tileFrameImportant[187] = true;
			Main.tileFrameImportant[173] = true;
			Main.tileFrameImportant[174] = true;
			Main.tileLighted[173] = true;
			Main.tileLighted[174] = true;
			Main.tileFrameImportant[139] = true;
			Main.tileLighted[160] = true;
			Main.tileLighted[149] = true;
			Main.tileFrameImportant[149] = true;
			Main.tileFrameImportant[142] = true;
			Main.tileFrameImportant[143] = true;
			Main.tileFrameImportant[144] = true;
			Main.tileStone[131] = true;
			Main.tileFrameImportant[136] = true;
			Main.tileFrameImportant[137] = true;
			Main.tileFrameImportant[138] = true;
			Main.tileBlockLight[137] = true;
			Main.tileSolid[137] = true;
			Main.tileBlockLight[160] = true;
			Main.tileSolid[160] = true;
			Main.tileMergeDirt[160] = true;
			Main.tileBlockLight[161] = true;
			Main.tileSolid[161] = true;
			Main.tileBlockLight[145] = true;
			Main.tileSolid[145] = true;
			Main.tileMergeDirt[145] = true;
			Main.tileBlockLight[146] = true;
			Main.tileSolid[146] = true;
			Main.tileMergeDirt[146] = true;
			Main.tileBlockLight[147] = true;
			Main.tileSolid[147] = true;
			Main.tileBlockLight[148] = true;
			Main.tileSolid[148] = true;
			Main.tileMergeDirt[148] = true;
			Main.tileBlockLight[138] = true;
			Main.tileSolid[138] = true;
			Main.tileBlockLight[140] = true;
			Main.tileSolid[140] = true;
			Main.tileBlockLight[151] = true;
			Main.tileSolid[151] = true;
			Main.tileMergeDirt[151] = true;
			Main.tileBlockLight[152] = true;
			Main.tileSolid[152] = true;
			Main.tileMergeDirt[152] = true;
			Main.tileBlockLight[153] = true;
			Main.tileSolid[153] = true;
			Main.tileMergeDirt[153] = true;
			Main.tileBlockLight[154] = true;
			Main.tileSolid[154] = true;
			Main.tileMergeDirt[154] = true;
			Main.tileBlockLight[155] = true;
			Main.tileSolid[155] = true;
			Main.tileMergeDirt[155] = true;
			Main.tileBlockLight[156] = true;
			Main.tileSolid[156] = true;
			Main.tileMergeDirt[156] = true;
			Main.tileMergeDirt[150] = true;
			Main.tileBlockLight[157] = true;
			Main.tileSolid[157] = true;
			Main.tileMergeDirt[157] = true;
			Main.tileBlockLight[158] = true;
			Main.tileSolid[158] = true;
			Main.tileMergeDirt[158] = true;
			Main.tileBlockLight[159] = true;
			Main.tileSolid[159] = true;
			Main.tileMergeDirt[159] = true;
			Main.tileFrameImportant[320] = true;
			Main.tileShine[22] = 1150;
			Main.tileShine[6] = 1150;
			Main.tileShine[7] = 1100;
			Main.tileShine[8] = 1000;
			Main.tileShine[9] = 1050;
			Main.tileShine[166] = 1125;
			Main.tileShine[167] = 1075;
			Main.tileShine[168] = 1025;
			Main.tileShine[169] = 975;
			Main.tileShine[178] = 500;
			Main.tileShine2[178] = true;
			Main.tileShine[12] = 300;
			Main.tileShine[21] = 1200;
			Main.tileShine[63] = 900;
			Main.tileShine[64] = 900;
			Main.tileShine[65] = 900;
			Main.tileShine[66] = 900;
			Main.tileShine[67] = 900;
			Main.tileShine[68] = 900;
			Main.tileShine[45] = 1900;
			Main.tileShine[46] = 2000;
			Main.tileShine[47] = 2100;
			Main.tileShine[122] = 1800;
			Main.tileShine[121] = 1850;
			Main.tileShine[125] = 600;
			Main.tileShine[109] = 9000;
			Main.tileShine[110] = 9000;
			Main.tileShine[116] = 9000;
			Main.tileShine[117] = 9000;
			Main.tileShine[118] = 8000;
			Main.tileShine[107] = 950;
			Main.tileShine[108] = 900;
			Main.tileShine[111] = 850;
			Main.tileShine[211] = 800;
			Main.tileLighted[4] = true;
			Main.tileLighted[17] = true;
			Main.tileLighted[133] = true;
			Main.tileLighted[31] = true;
			Main.tileLighted[33] = true;
			Main.tileLighted[34] = true;
			Main.tileLighted[35] = true;
			Main.tileLighted[37] = true;
			Main.tileLighted[42] = true;
			Main.tileLighted[49] = true;
			Main.tileLighted[58] = true;
			Main.tileLighted[61] = true;
			Main.tileLighted[70] = true;
			Main.tileLighted[71] = true;
			Main.tileLighted[72] = true;
			Main.tileLighted[76] = true;
			Main.tileLighted[77] = true;
			Main.tileLighted[19] = true;
			Main.tileLighted[22] = true;
			Main.tileLighted[26] = true;
			Main.tileLighted[83] = true;
			Main.tileLighted[84] = true;
			Main.tileLighted[92] = true;
			Main.tileLighted[93] = true;
			Main.tileLighted[95] = true;
			Main.tileLighted[98] = true;
			Main.tileLighted[100] = true;
			Main.tileLighted[109] = true;
			Main.tileLighted[125] = true;
			Main.tileLighted[126] = true;
			Main.tileLighted[129] = true;
			Main.tileLighted[140] = true;
			Main.tileLighted[270] = true;
			Main.tileLighted[271] = true;
			Main.tileMergeDirt[1] = true;
			Main.tileMergeDirt[6] = true;
			Main.tileMergeDirt[7] = true;
			Main.tileMergeDirt[8] = true;
			Main.tileMergeDirt[9] = true;
			Main.tileMergeDirt[166] = true;
			Main.tileMergeDirt[167] = true;
			Main.tileMergeDirt[168] = true;
			Main.tileMergeDirt[169] = true;
			Main.tileMergeDirt[22] = true;
			Main.tileMergeDirt[25] = true;
			Main.tileMergeDirt[30] = true;
			Main.tileMergeDirt[37] = true;
			Main.tileMergeDirt[38] = true;
			Main.tileMergeDirt[40] = true;
			Main.tileMergeDirt[53] = true;
			Main.tileMergeDirt[56] = true;
			Main.tileMergeDirt[107] = true;
			Main.tileMergeDirt[108] = true;
			Main.tileMergeDirt[111] = true;
			Main.tileMergeDirt[112] = true;
			Main.tileMergeDirt[116] = true;
			Main.tileMergeDirt[117] = true;
			Main.tileMergeDirt[123] = true;
			Main.tileMergeDirt[140] = true;
			Main.tileMergeDirt[39] = true;
			Main.tileMergeDirt[122] = true;
			Main.tileMergeDirt[121] = true;
			Main.tileMergeDirt[120] = true;
			Main.tileMergeDirt[119] = true;
			Main.tileMergeDirt[118] = true;
			Main.tileMergeDirt[47] = true;
			Main.tileMergeDirt[46] = true;
			Main.tileMergeDirt[45] = true;
			Main.tileMergeDirt[44] = true;
			Main.tileMergeDirt[43] = true;
			Main.tileMergeDirt[41] = true;
			Main.tileFrameImportant[380] = true;
			Main.tileFrameImportant[201] = true;
			Main.tileFrameImportant[3] = true;
			Main.tileFrameImportant[4] = true;
			Main.tileFrameImportant[5] = true;
			Main.tileFrameImportant[10] = true;
			Main.tileFrameImportant[11] = true;
			Main.tileFrameImportant[12] = true;
			Main.tileFrameImportant[13] = true;
			Main.tileFrameImportant[14] = true;
			Main.tileFrameImportant[15] = true;
			Main.tileFrameImportant[16] = true;
			Main.tileFrameImportant[17] = true;
			Main.tileFrameImportant[18] = true;
			Main.tileFrameImportant[19] = true;
			Main.tileFrameImportant[20] = true;
			Main.tileFrameImportant[21] = true;
			Main.tileFrameImportant[24] = true;
			Main.tileFrameImportant[26] = true;
			Main.tileFrameImportant[27] = true;
			Main.tileFrameImportant[28] = true;
			Main.tileFrameImportant[29] = true;
			Main.tileFrameImportant[31] = true;
			Main.tileFrameImportant[33] = true;
			Main.tileFrameImportant[34] = true;
			Main.tileFrameImportant[35] = true;
			Main.tileFrameImportant[42] = true;
			Main.tileFrameImportant[50] = true;
			Main.tileFrameImportant[55] = true;
			Main.tileFrameImportant[61] = true;
			Main.tileFrameImportant[71] = true;
			Main.tileFrameImportant[72] = true;
			Main.tileFrameImportant[73] = true;
			Main.tileFrameImportant[74] = true;
			Main.tileFrameImportant[77] = true;
			Main.tileFrameImportant[78] = true;
			Main.tileFrameImportant[79] = true;
			Main.tileFrameImportant[81] = true;
			Main.tileFrameImportant[82] = true;
			Main.tileFrameImportant[83] = true;
			Main.tileFrameImportant[84] = true;
			Main.tileFrameImportant[85] = true;
			Main.tileFrameImportant[86] = true;
			Main.tileFrameImportant[87] = true;
			Main.tileFrameImportant[88] = true;
			Main.tileFrameImportant[89] = true;
			Main.tileFrameImportant[90] = true;
			Main.tileFrameImportant[91] = true;
			Main.tileFrameImportant[92] = true;
			Main.tileFrameImportant[93] = true;
			Main.tileFrameImportant[94] = true;
			Main.tileFrameImportant[95] = true;
			Main.tileFrameImportant[96] = true;
			Main.tileFrameImportant[97] = true;
			Main.tileFrameImportant[98] = true;
			Main.tileFrameImportant[99] = true;
			Main.tileFrameImportant[101] = true;
			Main.tileFrameImportant[102] = true;
			Main.tileFrameImportant[103] = true;
			Main.tileFrameImportant[104] = true;
			Main.tileFrameImportant[105] = true;
			Main.tileFrameImportant[100] = true;
			Main.tileFrameImportant[106] = true;
			Main.tileFrameImportant[110] = true;
			Main.tileFrameImportant[113] = true;
			Main.tileFrameImportant[114] = true;
			Main.tileFrameImportant[125] = true;
			Main.tileFrameImportant[287] = true;
			Main.tileFrameImportant[126] = true;
			Main.tileFrameImportant[128] = true;
			Main.tileFrameImportant[129] = true;
			Main.tileFrameImportant[132] = true;
			Main.tileFrameImportant[133] = true;
			Main.tileFrameImportant[134] = true;
			Main.tileFrameImportant[135] = true;
			Main.tileFrameImportant[172] = true;
			Main.tileFrameImportant[319] = true;
			Main.tileFrameImportant[323] = true;
			Main.tileFrameImportant[335] = true;
			Main.tileFrameImportant[337] = true;
			Main.tileFrameImportant[349] = true;
			Main.tileFrameImportant[376] = true;
			Main.tileFrameImportant[378] = true;
			Main.tileFrameImportant[141] = true;
			Main.tileFrameImportant[270] = true;
			Main.tileFrameImportant[271] = true;
			Main.tileFrameImportant[314] = true;
			Main.tileSolidTop[376] = true;
			Main.tileTable[376] = true;
			Main.tileTable[380] = true;
			Main.tileCut[201] = true;
			Main.tileCut[3] = true;
			Main.tileCut[24] = true;
			Main.tileCut[28] = true;
			Main.tileCut[32] = true;
			Main.tileCut[51] = true;
			Main.tileCut[52] = true;
			Main.tileCut[61] = true;
			Main.tileCut[62] = true;
			Main.tileCut[69] = true;
			Main.tileCut[71] = true;
			Main.tileCut[73] = true;
			Main.tileCut[74] = true;
			Main.tileCut[82] = true;
			Main.tileCut[83] = true;
			Main.tileCut[84] = true;
			Main.tileCut[110] = true;
			Main.tileCut[113] = true;
			Main.tileCut[115] = true;
			Main.tileCut[184] = true;
			Main.tileCut[205] = true;
			Main.tileCut[352] = true;
			Main.tileCut[382] = true;
			Main.tileAlch[82] = true;
			Main.tileAlch[83] = true;
			Main.tileAlch[84] = true;
			Main.tileSolid[127] = true;
			Main.tileSolid[130] = true;
			Main.tileBlockLight[130] = true;
			Main.tileBlockLight[131] = true;
			Main.tileNoAttach[232] = true;
			Main.tileSolid[107] = true;
			Main.tileBlockLight[107] = true;
			Main.tileSolid[108] = true;
			Main.tileBlockLight[108] = true;
			Main.tileSolid[111] = true;
			Main.tileBlockLight[111] = true;
			Main.tileSolid[109] = true;
			Main.tileBlockLight[109] = true;
			Main.tileSolid[110] = false;
			Main.tileNoAttach[110] = true;
			Main.tileNoFail[110] = true;
			Main.tileSolid[112] = true;
			Main.tileBlockLight[112] = true;
			Main.tileSolid[116] = true;
			Main.tileBlockLight[116] = true;
			Main.tileBrick[117] = true;
			Main.tileBrick[25] = true;
			Main.tileBrick[203] = true;
			Main.tileSolid[117] = true;
			Main.tileBlockLight[117] = true;
			Main.tileSolid[123] = true;
			Main.tileBlockLight[123] = true;
			Main.tileNoFail[165] = true;
			Main.tileNoFail[184] = true;
			Main.tileNoFail[185] = true;
			Main.tileNoFail[186] = true;
			Main.tileNoFail[187] = true;
			Main.tileSolid[118] = true;
			Main.tileBlockLight[118] = true;
			Main.tileSolid[119] = true;
			Main.tileBlockLight[119] = true;
			Main.tileSolid[120] = true;
			Main.tileBlockLight[120] = true;
			Main.tileSolid[121] = true;
			Main.tileBlockLight[121] = true;
			Main.tileSolid[122] = true;
			Main.tileBlockLight[122] = true;
			Main.tileSolid[150] = true;
			Main.tileBlockLight[150] = true;
			Main.tileBlockLight[115] = true;
			Main.tileSolid[199] = true;
			Main.tileBlockLight[199] = true;
			Main.tileNoFail[162] = true;
			Main.tileSolid[0] = true;
			Main.tileBlockLight[0] = true;
			Main.tileSolid[1] = true;
			Main.tileBlockLight[1] = true;
			Main.tileSolid[2] = true;
			Main.tileBlockLight[2] = true;
			Main.tileSolid[3] = false;
			Main.tileNoAttach[3] = true;
			Main.tileNoFail[3] = true;
			Main.tileNoFail[201] = true;
			Main.tileSolid[4] = false;
			Main.tileNoAttach[4] = true;
			Main.tileNoFail[4] = true;
			Main.tileNoFail[24] = true;
			Main.tileSolid[5] = false;
			Main.tileSolid[6] = true;
			Main.tileBlockLight[6] = true;
			Main.tileSolid[7] = true;
			Main.tileBlockLight[7] = true;
			Main.tileSolid[8] = true;
			Main.tileBlockLight[8] = true;
			Main.tileSolid[9] = true;
			Main.tileBlockLight[9] = true;
			Main.tileSolid[166] = true;
			Main.tileBlockLight[166] = true;
			Main.tileSolid[167] = true;
			Main.tileBlockLight[167] = true;
			Main.tileSolid[168] = true;
			Main.tileBlockLight[168] = true;
			Main.tileSolid[169] = true;
			Main.tileBlockLight[169] = true;
			Main.tileBlockLight[10] = true;
			Main.tileSolid[10] = true;
			Main.tileNoAttach[10] = true;
			Main.tileBlockLight[10] = true;
			Main.tileSolid[11] = false;
			Main.tileSolidTop[19] = true;
			Main.tileSolid[19] = true;
			Main.tileSolid[22] = true;
			Main.tileSolid[23] = true;
			Main.tileSolid[25] = true;
			Main.tileSolid[30] = true;
			Main.tileNoFail[32] = true;
			Main.tileBlockLight[32] = true;
			Main.tileNoFail[352] = true;
			Main.tileBlockLight[352] = true;
			Main.tileSolid[37] = true;
			Main.tileBlockLight[37] = true;
			Main.tileSolid[38] = true;
			Main.tileBlockLight[38] = true;
			Main.tileSolid[39] = true;
			Main.tileBlockLight[39] = true;
			Main.tileSolid[40] = true;
			Main.tileBlockLight[40] = true;
			Main.tileSolid[41] = true;
			Main.tileBlockLight[41] = true;
			Main.tileSolid[43] = true;
			Main.tileBlockLight[43] = true;
			Main.tileSolid[44] = true;
			Main.tileBlockLight[44] = true;
			Main.tileSolid[45] = true;
			Main.tileBlockLight[45] = true;
			Main.tileSolid[46] = true;
			Main.tileBlockLight[46] = true;
			Main.tileSolid[47] = true;
			Main.tileBlockLight[47] = true;
			Main.tileSolid[48] = true;
			Main.tileBlockLight[48] = true;
			Main.tileSolid[53] = true;
			Main.tileBlockLight[53] = true;
			Main.tileSolid[54] = true;
			Main.tileBlockLight[52] = true;
			Main.tileBlockLight[205] = true;
			Main.tileSolid[56] = true;
			Main.tileBlockLight[56] = true;
			Main.tileSolid[57] = true;
			Main.tileBlockLight[57] = true;
			Main.tileSolid[58] = true;
			Main.tileBlockLight[58] = true;
			Main.tileBlockLight[382] = true;
			Main.tileSolid[59] = true;
			Main.tileBlockLight[59] = true;
			Main.tileSolid[60] = true;
			Main.tileBlockLight[60] = true;
			Main.tileSolid[63] = true;
			Main.tileBlockLight[63] = true;
			Main.tileStone[63] = true;
			Main.tileStone[130] = true;
			Main.tileSolid[64] = true;
			Main.tileBlockLight[64] = true;
			Main.tileStone[64] = true;
			Main.tileSolid[65] = true;
			Main.tileBlockLight[65] = true;
			Main.tileStone[65] = true;
			Main.tileSolid[66] = true;
			Main.tileBlockLight[66] = true;
			Main.tileStone[66] = true;
			Main.tileSolid[67] = true;
			Main.tileBlockLight[67] = true;
			Main.tileStone[67] = true;
			Main.tileSolid[68] = true;
			Main.tileBlockLight[68] = true;
			Main.tileStone[68] = true;
			Main.tileSolid[75] = true;
			Main.tileBlockLight[75] = true;
			Main.tileSolid[76] = true;
			Main.tileBlockLight[76] = true;
			Main.tileSolid[70] = true;
			Main.tileBlockLight[70] = true;
			Main.tileNoFail[50] = true;
			Main.tileNoAttach[50] = true;
			Main.tileDungeon[41] = true;
			Main.tileDungeon[43] = true;
			Main.tileDungeon[44] = true;
			Main.tileBlockLight[30] = true;
			Main.tileBlockLight[25] = true;
			Main.tileBlockLight[23] = true;
			Main.tileBlockLight[22] = true;
			Main.tileBlockLight[62] = true;
			Main.tileSolidTop[18] = true;
			Main.tileSolidTop[14] = true;
			Main.tileSolidTop[16] = true;
			Main.tileSolidTop[134] = true;
			Main.tileSolidTop[114] = true;
			Main.tileNoAttach[20] = true;
			Main.tileNoAttach[19] = true;
			Main.tileNoAttach[13] = true;
			Main.tileNoAttach[14] = true;
			Main.tileNoAttach[15] = true;
			Main.tileNoAttach[16] = true;
			Main.tileNoAttach[134] = true;
			Main.tileNoAttach[17] = true;
			Main.tileNoAttach[18] = true;
			Main.tileNoAttach[19] = true;
			Main.tileNoAttach[21] = true;
			Main.tileNoAttach[27] = true;
			Main.tileNoAttach[114] = true;
			Main.tileTable[14] = true;
			Main.tileTable[18] = true;
			Main.tileTable[19] = true;
			Main.tileTable[114] = true;
			Main.tileNoAttach[86] = true;
			Main.tileNoAttach[87] = true;
			Main.tileNoAttach[88] = true;
			Main.tileNoAttach[89] = true;
			Main.tileNoAttach[90] = true;
			Main.tileTable[101] = true;
			Main.tileNoAttach[101] = true;
			Main.tileNoAttach[102] = true;
			Main.tileNoAttach[94] = true;
			Main.tileNoAttach[95] = true;
			Main.tileNoAttach[96] = true;
			Main.tileNoAttach[97] = true;
			Main.tileNoAttach[98] = true;
			Main.tileNoAttach[99] = true;
			Main.tileTable[87] = true;
			Main.tileTable[88] = true;
			Main.tileSolidTop[87] = true;
			Main.tileSolidTop[88] = true;
			Main.tileSolidTop[101] = true;
			Main.tileNoAttach[91] = true;
			Main.tileNoAttach[92] = true;
			Main.tileNoAttach[93] = true;
			Main.tileLighted[190] = true;
			Main.tileBlockLight[192] = true;
			Main.tileBrick[192] = false;
			Main.tileWaterDeath[215] = true;
			Main.tileWaterDeath[4] = true;
			Main.tileWaterDeath[51] = true;
			Main.tileWaterDeath[93] = true;
			Main.tileWaterDeath[98] = true;
			Main.tileLavaDeath[3] = true;
			Main.tileLavaDeath[5] = true;
			Main.tileLavaDeath[10] = true;
			Main.tileLavaDeath[11] = true;
			Main.tileLavaDeath[12] = true;
			Main.tileLavaDeath[13] = true;
			Main.tileLavaDeath[14] = true;
			Main.tileLavaDeath[15] = true;
			Main.tileLavaDeath[16] = true;
			Main.tileLavaDeath[17] = true;
			Main.tileLavaDeath[18] = true;
			Main.tileLavaDeath[19] = true;
			Main.tileLavaDeath[20] = true;
			Main.tileLavaDeath[24] = true;
			Main.tileLavaDeath[27] = true;
			Main.tileLavaDeath[28] = true;
			Main.tileLavaDeath[29] = true;
			Main.tileLavaDeath[32] = true;
			Main.tileLavaDeath[33] = true;
			Main.tileLavaDeath[34] = true;
			Main.tileLavaDeath[35] = true;
			Main.tileLavaDeath[36] = true;
			Main.tileLavaDeath[42] = true;
			Main.tileLavaDeath[49] = true;
			Main.tileLavaDeath[50] = true;
			Main.tileLavaDeath[51] = true;
			Main.tileLavaDeath[52] = true;
			Main.tileLavaDeath[55] = true;
			Main.tileLavaDeath[61] = true;
			Main.tileLavaDeath[62] = true;
			Main.tileLavaDeath[69] = true;
			Main.tileLavaDeath[71] = true;
			Main.tileLavaDeath[72] = true;
			Main.tileLavaDeath[73] = true;
			Main.tileLavaDeath[74] = true;
			Main.tileLavaDeath[79] = true;
			Main.tileLavaDeath[80] = true;
			Main.tileLavaDeath[81] = true;
			Main.tileLavaDeath[86] = true;
			Main.tileLavaDeath[87] = true;
			Main.tileLavaDeath[88] = true;
			Main.tileLavaDeath[89] = true;
			Main.tileLavaDeath[90] = true;
			Main.tileLavaDeath[91] = true;
			Main.tileLavaDeath[92] = true;
			Main.tileLavaDeath[93] = true;
			Main.tileLavaDeath[94] = true;
			Main.tileLavaDeath[95] = true;
			Main.tileLavaDeath[96] = true;
			Main.tileLavaDeath[97] = true;
			Main.tileLavaDeath[98] = true;
			Main.tileLavaDeath[100] = true;
			Main.tileLavaDeath[101] = true;
			Main.tileLavaDeath[102] = true;
			Main.tileLavaDeath[103] = true;
			Main.tileLavaDeath[104] = true;
			Main.tileLavaDeath[106] = true;
			Main.tileLavaDeath[110] = true;
			Main.tileLavaDeath[113] = true;
			Main.tileLavaDeath[115] = true;
			Main.tileLavaDeath[125] = true;
			Main.tileLavaDeath[126] = true;
			Main.tileLavaDeath[128] = true;
			Main.tileLavaDeath[149] = true;
			Main.tileLavaDeath[172] = true;
			Main.tileLavaDeath[173] = true;
			Main.tileLavaDeath[174] = true;
			Main.tileLavaDeath[184] = true;
			Main.tileLavaDeath[201] = true;
			Main.tileLavaDeath[205] = true;
			Main.tileLavaDeath[201] = true;
			Main.tileLavaDeath[209] = true;
			Main.tileLavaDeath[210] = true;
			Main.tileLavaDeath[212] = true;
			Main.tileLavaDeath[213] = true;
			Main.tileLavaDeath[353] = true;
			Main.tileLavaDeath[214] = true;
			Main.tileLavaDeath[215] = true;
			Main.tileLavaDeath[216] = true;
			Main.tileLavaDeath[217] = true;
			Main.tileLavaDeath[218] = true;
			Main.tileLavaDeath[219] = true;
			Main.tileLavaDeath[220] = true;
			Main.tileLavaDeath[227] = true;
			Main.tileLavaDeath[228] = true;
			Main.tileLavaDeath[233] = true;
			Main.tileLavaDeath[236] = true;
			Main.tileLavaDeath[238] = true;
			Main.tileLavaDeath[240] = true;
			Main.tileLavaDeath[241] = true;
			Main.tileLavaDeath[242] = true;
			Main.tileLavaDeath[243] = true;
			Main.tileLavaDeath[244] = true;
			Main.tileLavaDeath[245] = true;
			Main.tileLavaDeath[246] = true;
			Main.tileLavaDeath[247] = true;
			Main.tileLavaDeath[254] = true;
			Main.tileLavaDeath[269] = true;
			Main.tileLavaDeath[270] = true;
			Main.tileLavaDeath[271] = true;
			Main.tileLavaDeath[275] = true;
			Main.tileLavaDeath[413] = true;
			Main.tileLavaDeath[276] = true;
			Main.tileLavaDeath[277] = true;
			Main.tileLavaDeath[278] = true;
			Main.tileLavaDeath[279] = true;
			Main.tileLavaDeath[280] = true;
			Main.tileLavaDeath[281] = true;
			Main.tileLavaDeath[282] = true;
			Main.tileLavaDeath[283] = true;
			Main.tileLavaDeath[285] = true;
			Main.tileLavaDeath[286] = true;
			Main.tileLavaDeath[287] = true;
			Main.tileLavaDeath[288] = true;
			Main.tileLavaDeath[289] = true;
			Main.tileLavaDeath[290] = true;
			Main.tileLavaDeath[291] = true;
			Main.tileLavaDeath[292] = true;
			Main.tileLavaDeath[293] = true;
			Main.tileLavaDeath[294] = true;
			Main.tileLavaDeath[295] = true;
			Main.tileLavaDeath[296] = true;
			Main.tileLavaDeath[297] = true;
			Main.tileLavaDeath[298] = true;
			Main.tileLavaDeath[299] = true;
			Main.tileLavaDeath[300] = true;
			Main.tileLavaDeath[301] = true;
			Main.tileLavaDeath[302] = true;
			Main.tileLavaDeath[303] = true;
			Main.tileLavaDeath[304] = true;
			Main.tileLavaDeath[305] = true;
			Main.tileLavaDeath[306] = true;
			Main.tileLavaDeath[307] = true;
			Main.tileLavaDeath[308] = true;
			Main.tileLavaDeath[309] = true;
			Main.tileLavaDeath[310] = true;
			Main.tileLavaDeath[316] = true;
			Main.tileLavaDeath[317] = true;
			Main.tileLavaDeath[318] = true;
			Main.tileLavaDeath[319] = true;
			Main.tileLavaDeath[354] = true;
			Main.tileLavaDeath[355] = true;
			Main.tileLavaDeath[323] = true;
			Main.tileLavaDeath[335] = true;
			Main.tileLavaDeath[338] = true;
			Main.tileLavaDeath[339] = true;
			Main.tileLavaDeath[352] = true;
			Main.tileLavaDeath[382] = true;
			Main.tileLighted[316] = true;
			Main.tileLighted[317] = true;
			Main.tileLighted[318] = true;
			for (int r = 0; r < 419; r++)
			{
				if (Main.tileLavaDeath[r])
				{
					Main.tileObsidianKill[r] = true;
				}
			}
			Main.tileObsidianKill[77] = true;
			Main.tileObsidianKill[78] = true;
			Main.tileObsidianKill[82] = true;
			Main.tileObsidianKill[83] = true;
			Main.tileObsidianKill[84] = true;
			Main.tileObsidianKill[85] = true;
			Main.tileObsidianKill[105] = true;
			Main.tileObsidianKill[129] = true;
			Main.tileObsidianKill[132] = true;
			Main.tileObsidianKill[133] = true;
			Main.tileObsidianKill[134] = true;
			Main.tileObsidianKill[135] = true;
			Main.tileObsidianKill[136] = true;
			Main.tileObsidianKill[139] = true;
			Main.tileObsidianKill[165] = true;
			Main.tileObsidianKill[178] = true;
			Main.tileObsidianKill[185] = true;
			Main.tileObsidianKill[186] = true;
			Main.tileObsidianKill[187] = true;
			Main.tileObsidianKill[231] = true;
			Main.tileObsidianKill[337] = true;
			Main.tileObsidianKill[349] = true;
			Main.tileSolid[384] = true;
			Main.tileBlockLight[384] = true;
			Main.tileNoFail[384] = true;
			Main.tileFrameImportant[395] = true;
			Main.tileLavaDeath[395] = true;
			Main.tileFrameImportant[405] = true;
			Main.tileLavaDeath[405] = true;
			Main.tileSolidTop[405] = true;
			Main.tileTable[405] = true;
			Main.tileLighted[405] = true;
			Main.tileWaterDeath[405] = true;
			Main.tileFrameImportant[406] = true;
			Main.tileLavaDeath[406] = true;
			Main.tileFrameImportant[411] = true;
			Main.tileLavaDeath[411] = true;
			Main.tileFrameImportant[412] = true;
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
			Main.wallBlend[65] = 63;
			Main.wallBlend[66] = 63;
			Main.wallBlend[68] = 63;
			Main.wallBlend[67] = 64;
			Main.wallBlend[80] = 74;
			Main.wallBlend[81] = 77;
			Main.wallBlend[94] = 7;
			Main.wallBlend[95] = 7;
			Main.wallBlend[100] = 7;
			Main.wallBlend[101] = 7;
			Main.wallBlend[96] = 8;
			Main.wallBlend[97] = 8;
			Main.wallBlend[102] = 8;
			Main.wallBlend[103] = 8;
			Main.wallBlend[98] = 9;
			Main.wallBlend[99] = 9;
			Main.wallBlend[104] = 9;
			Main.wallBlend[105] = 9;
			Main.tileNoFail[24] = true;
			Main.tileNoFail[3] = true;
			Main.tileNoFail[52] = true;
			Main.tileNoFail[62] = true;
			Main.tileNoFail[32] = true;
			Main.tileNoFail[61] = true;
			Main.tileNoFail[69] = true;
			Main.tileNoFail[73] = true;
			Main.tileNoFail[74] = true;
			Main.tileNoFail[82] = true;
			Main.tileNoFail[83] = true;
			Main.tileNoFail[84] = true;
			Main.tileNoFail[110] = true;
			Main.tileNoFail[113] = true;
			Main.tileNoFail[115] = true;
			Main.tileNoFail[165] = true;
			Main.tileNoFail[184] = true;
			Main.tileNoFail[201] = true;
			Main.tileNoFail[205] = true;
			Main.tileNoFail[227] = true;
			Main.tileNoFail[233] = true;
			Main.tileNoFail[352] = true;
			Main.tileNoFail[382] = true;
			Main.tileFrameImportant[387] = true;
			Main.tileSolid[387] = true;
			Main.tileBlockLight[387] = true;
			Main.tileNoAttach[387] = true;
			Main.tileLavaDeath[387] = true;
			Main.tileFrameImportant[386] = true;
			Main.tileLavaDeath[386] = true;
			Main.tileNoSunLight[386] = true;
			Main.tileFrameImportant[388] = true;
			Main.tileSolid[388] = true;
			Main.tileBlockLight[388] = true;
			Main.tileNoAttach[388] = true;
			Main.tileLavaDeath[388] = true;
			Main.tileFrameImportant[389] = true;
			Main.tileLavaDeath[389] = true;
			Main.tileNoSunLight[389] = true;
			for (int t = 0; t < 419; t++)
			{
				if (Main.tileSolid[t])
				{
					Main.tileNoSunLight[t] = true;
				}
				Main.tileFrame[t] = 0;
				Main.tileFrameCounter[t] = 0;
			}
			Main.tileNoSunLight[379] = false;
			Main.tileNoSunLight[54] = false;
			Main.tileNoSunLight[328] = false;
			Main.tileNoSunLight[19] = false;
			Main.tileNoSunLight[11] = true;
			Main.tileNoSunLight[189] = false;
			Main.tileNoSunLight[196] = false;
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
				NetMessage.SendData(25, -1, -1, str, 255, 175f, 75f, 255f, 0, 0, 0);
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
						NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num2, 0f, 0f, 0, 0, 0);
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
						NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num4, 0f, 0f, 0, 0, 0);
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
					NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)nums1[0], 0f, 0f, 0, 0, 0);
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
			if (Main.npc[i].type == 125)
			{
				single = 30f;
			}
			else if (Main.npc[i].type == 54)
			{
				single = 2f;
			}
			else if (Main.npc[i].type == 205)
			{
				single = 8f;
			}
			else if (Main.npc[i].type == 182)
			{
				single = 24f;
			}
			else if (Main.npc[i].type == 178)
			{
				single = 2f;
			}
			else if (Main.npc[i].type == 126)
			{
				single = 30f;
			}
			else if (Main.npc[i].type == 6 || Main.npc[i].type == 173)
			{
				single = 26f;
			}
			else if (Main.npc[i].type == 94)
			{
				single = 14f;
			}
			else if (Main.npc[i].type == 7 || Main.npc[i].type == 8 || Main.npc[i].type == 9)
			{
				single = 13f;
			}
			else if (Main.npc[i].type == 98 || Main.npc[i].type == 99 || Main.npc[i].type == 100)
			{
				single = 13f;
			}
			else if (Main.npc[i].type == 95 || Main.npc[i].type == 96 || Main.npc[i].type == 97)
			{
				single = 13f;
			}
			else if (Main.npc[i].type == 10 || Main.npc[i].type == 11 || Main.npc[i].type == 12)
			{
				single = 8f;
			}
			else if (Main.npc[i].type == 13 || Main.npc[i].type == 14 || Main.npc[i].type == 15)
			{
				single = 26f;
			}
			else if (Main.npc[i].type == 175)
			{
				single = 4f;
			}
			else if (Main.npc[i].type == 520)
			{
				single = 2f;
			}
			else if (Main.npc[i].type >= 412 && Main.npc[i].type <= 414)
			{
				single = 18f;
			}
			else if (Main.npc[i].type == 48)
			{
				single = 32f;
			}
			else if (Main.npc[i].type == 49 || Main.npc[i].type == 51)
			{
				single = 4f;
			}
			else if (Main.npc[i].type == 60)
			{
				single = 10f;
			}
			else if (Main.npc[i].type == 62 || Main.npc[i].type == 66 || Main.npc[i].type == 156)
			{
				single = 14f;
			}
			else if (Main.npc[i].type == 63 || Main.npc[i].type == 64 || Main.npc[i].type == 103)
			{
				single = 4f;
			}
			else if (Main.npc[i].type == 65)
			{
				single = 14f;
			}
			else if (Main.npc[i].type == 69)
			{
				single = 4f;
			}
			else if (Main.npc[i].type == 70)
			{
				single = -4f;
			}
			else if (Main.npc[i].type == 72)
			{
				single = -2f;
			}
			else if (Main.npc[i].type == 83 || Main.npc[i].type == 84)
			{
				single = 20f;
			}
			else if (Main.npc[i].type == 150 || Main.npc[i].type == 151 || Main.npc[i].type == 158)
			{
				single = 10f;
			}
			else if (Main.npc[i].type == 152)
			{
				single = 6f;
			}
			else if (Main.npc[i].type == 153 || Main.npc[i].type == 154)
			{
				single = 4f;
			}
			else if (Main.npc[i].type == 165 || Main.npc[i].type == 237 || Main.npc[i].type == 238 || Main.npc[i].type == 240)
			{
				single = 10f;
			}
			else if (Main.npc[i].type == 39 || Main.npc[i].type == 40 || Main.npc[i].type == 41)
			{
				single = 26f;
			}
			else if (Main.npc[i].type >= 87 && Main.npc[i].type <= 92)
			{
				single = 56f;
			}
			else if (Main.npc[i].type >= 134 && Main.npc[i].type <= 136)
			{
				single = 30f;
			}
			else if (Main.npc[i].type == 169)
			{
				single = 8f;
			}
			else if (Main.npc[i].type == 174)
			{
				single = 6f;
			}
			else if (Main.npc[i].type == 369)
			{
				single = 2f;
			}
			else if (Main.npc[i].type == 376)
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
			NetMessage.SendData(4, -1, -1, Main.player[Main.myPlayer].name, Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
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
			Main.tileValue[28] = 100;
			Main.tileValue[7] = 200;
			Main.tileValue[166] = 210;
			Main.tileValue[6] = 220;
			Main.tileValue[167] = 230;
			Main.tileValue[9] = 240;
			Main.tileValue[168] = 250;
			Main.tileValue[37] = 300;
			Main.tileValue[22] = 310;
			Main.tileValue[204] = 320;
			Main.tileValue[407] = 350;
			Main.tileValue[8] = 400;
			Main.tileValue[169] = 410;
			Main.tileValue[21] = 500;
			Main.tileValue[107] = 600;
			Main.tileValue[221] = 610;
			Main.tileValue[108] = 620;
			Main.tileValue[222] = 630;
			Main.tileValue[111] = 640;
			Main.tileValue[223] = 650;
			Main.tileValue[211] = 700;
			Main.tileValue[12] = 800;
			Main.tileValue[236] = 810;
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
				if (Main.projectile[num].type == 628)
				{
					drawCacheProjsBehindProjectiles.Remove(num);
					List<int> list2 = new List<int>();
					list2.Insert(0, num);
					int byUUID = Projectile.GetByUUID(Main.projectile[num].owner, Main.projectile[num].ai[0]);
					while (byUUID >= 0 && !list2.Contains(byUUID) && Main.projectile[byUUID].active && Main.projectile[byUUID].type >= 625 && Main.projectile[byUUID].type <= 627)
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
				if (projectile.type >= 626 && projectile.type <= 628 && byUUID2 >= 0 && ProjectileID.Sets.StardustDragon[Main.projectile[byUUID2].type])
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
							NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						}
						else if (lower == "dusk")
						{
							Main.dayTime = false;
							Main.time = 0;
							NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						}
						else if (lower == "noon")
						{
							Main.dayTime = true;
							Main.time = 27000;
							NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						}
						else if (lower == "midnight")
						{
							Main.dayTime = false;
							Main.time = 16200;
							NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
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
									NetMessage.SendData(25, -1, -1, string.Concat("<Server> ", str4), 255, 255f, 240f, 20f, 0, 0, 0);
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
											NetMessage.SendData(2, j, -1, "Kicked from server.", 0, 0f, 0f, 0f, 0, 0, 0);
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
											NetMessage.SendData(2, k, -1, "Banned from server.", 0, 0f, 0f, 0f, 0, 0, 0);
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
					NetMessage.SendData(25, -1, -1, str, 255, 175f, 75f, 255f, 0, 0, 0);
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
				NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
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
					NetMessage.SendData(25, -1, -1, str, 255, 175f, 75f, 255f, 0, 0, 0);
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
				NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
			}
		}

		public static void Sundialing()
		{
			if (Main.sundialCooldown == 0)
			{
				if (Main.netMode == 1)
				{
					NetMessage.SendData(51, -1, -1, "", Main.myPlayer, 3f, 0f, 0f, 0, 0, 0);
					return;
				}
				Main.fastForwardTime = true;
				Main.sundialCooldown = 8;
				NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
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
				NetMessage.SendData(78, toWho, -1, "", (int)NPC.waveKills, (float)num, 1f, (float)NPC.waveCount, 0, 0, 0);
				return;
			}
			if (Main.pumpkinMoon)
			{
				int num1 = (new int[] { 0, 25, 40, 50, 80, 100, 160, 180, 200, 250, 300, 375, 450, 525, 675, 0 })[NPC.waveCount];
				NetMessage.SendData(78, toWho, -1, "", (int)NPC.waveKills, (float)num1, 2f, (float)NPC.waveCount, 0, 0, 0);
				return;
			}
			if (Main.invasionType > 0)
			{
				int num2 = 1;
				if (Main.invasionType != 0 && Main.invasionSizeStart != 0)
				{
					num2 = Main.invasionSizeStart;
				}
				NetMessage.SendData(78, toWho, -1, "", Main.invasionSizeStart - Main.invasionSize, (float)num2, (float)(Main.invasionType + 2), 0f, 0, 0, 0);
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
			Main.tileNoFail[384] = true;
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
				Main.wallFrameCounter[136] = (byte)(Main.wallFrameCounter[136] + 1);
				if (Main.wallFrameCounter[136] >= 5)
				{
					Main.wallFrameCounter[136] = 0;
					Main.wallFrame[136] = (byte)(Main.wallFrame[136] + 1);
					if (Main.wallFrame[136] > 7)
					{
						Main.wallFrame[136] = 0;
					}
				}
				Main.wallFrameCounter[137] = (byte)(Main.wallFrameCounter[137] + 1);
				if (Main.wallFrameCounter[137] >= 10)
				{
					Main.wallFrameCounter[137] = 0;
					Main.wallFrame[137] = (byte)(Main.wallFrame[137] + 1);
					if (Main.wallFrame[137] > 7)
					{
						Main.wallFrame[137] = 0;
					}
				}
				Main.wallFrameCounter[172] = (byte)(Main.wallFrameCounter[172] + 1);
				if (Main.wallFrameCounter[172] >= 10)
				{
					Main.wallFrameCounter[172] = 0;
					Main.wallFrame[172] = (byte)(Main.wallFrame[172] + 1);
					if (Main.wallFrame[172] > 7)
					{
						Main.wallFrame[172] = 0;
					}
				}
				Main.wallFrameCounter[168] = (byte)(Main.wallFrameCounter[168] + 1);
				if (Main.wallFrameCounter[168] >= 5)
				{
					Main.wallFrameCounter[168] = 0;
					Main.wallFrame[168] = (byte)(Main.wallFrame[168] + 1);
					if (Main.wallFrame[168] > 7)
					{
						Main.wallFrame[168] = 0;
					}
				}
				Main.wallFrameCounter[169] = (byte)(Main.wallFrameCounter[169] + 1);
				if (Main.wallFrameCounter[169] >= 5)
				{
					Main.wallFrameCounter[169] = 0;
					Main.wallFrame[169] = (byte)(Main.wallFrame[169] + 1);
					if (Main.wallFrame[169] > 7)
					{
						Main.wallFrame[169] = 0;
					}
				}
				Main.wallFrameCounter[144] = (byte)(Main.wallFrameCounter[144] + 1);
				int num2 = 5;
				int num3 = 10;
				if (Main.wallFrameCounter[144] < num2)
				{
					Main.wallFrame[144] = 0;
				}
				else if (Main.wallFrameCounter[144] < num2)
				{
					Main.wallFrame[144] = 1;
				}
				else if (Main.wallFrameCounter[144] < num2 * 2)
				{
					Main.wallFrame[144] = 2;
				}
				else if (Main.wallFrameCounter[144] < num2 * 3)
				{
					Main.wallFrame[144] = 3;
				}
				else if (Main.wallFrameCounter[144] < num2 * 4)
				{
					Main.wallFrame[144] = 4;
				}
				else if (Main.wallFrameCounter[144] < num2 * 5)
				{
					Main.wallFrame[144] = 5;
				}
				else if (Main.wallFrameCounter[144] < num2 * 6)
				{
					Main.wallFrame[144] = 6;
				}
				else if (Main.wallFrameCounter[144] < num2 * 7)
				{
					Main.wallFrame[144] = 7;
				}
				else if (Main.wallFrameCounter[144] < num2 * (8 + num3))
				{
					Main.wallFrame[144] = 8;
				}
				else if (Main.wallFrameCounter[144] < num2 * (9 + num3))
				{
					Main.wallFrame[144] = 7;
				}
				else if (Main.wallFrameCounter[144] < num2 * (10 + num3))
				{
					Main.wallFrame[144] = 6;
				}
				else if (Main.wallFrameCounter[144] < num2 * (11 + num3))
				{
					Main.wallFrame[144] = 5;
				}
				else if (Main.wallFrameCounter[144] < num2 * (12 + num3))
				{
					Main.wallFrame[144] = 4;
				}
				else if (Main.wallFrameCounter[144] < num2 * (13 + num3))
				{
					Main.wallFrame[144] = 3;
				}
				else if (Main.wallFrameCounter[144] < num2 * (14 + num3))
				{
					Main.wallFrame[144] = 2;
				}
				else if (Main.wallFrameCounter[144] >= num2 * (15 + num3))
				{
					Main.wallFrame[144] = 0;
					if (Main.wallFrameCounter[144] > num2 * (16 + num3 * 2))
					{
						Main.wallFrameCounter[144] = 0;
					}
				}
				else
				{
					Main.wallFrame[144] = 1;
				}
				Main.tileFrameCounter[12] = Main.tileFrameCounter[12] + 1;
				if (Main.tileFrameCounter[12] > 5)
				{
					Main.tileFrameCounter[12] = 0;
					Main.tileFrame[12] = Main.tileFrame[12] + 1;
					if (Main.tileFrame[12] >= 10)
					{
						Main.tileFrame[12] = 0;
					}
				}
				Main.tileFrameCounter[17] = Main.tileFrameCounter[17] + 1;
				if (Main.tileFrameCounter[17] > 5)
				{
					Main.tileFrameCounter[17] = 0;
					Main.tileFrame[17] = Main.tileFrame[17] + 1;
					if (Main.tileFrame[17] >= 12)
					{
						Main.tileFrame[17] = 0;
					}
				}
				int num4 = Main.tileFrameCounter[133] + 1;
				int num5 = num4;
				Main.tileFrameCounter[133] = num4;
				if (num5 >= 4)
				{
					Main.tileFrameCounter[133] = 0;
					int num6 = Main.tileFrame[133] + 1;
					int num7 = num6;
					Main.tileFrame[133] = num6;
					if (num7 >= 6)
					{
						Main.tileFrame[133] = 0;
					}
				}
				Main.tileFrameCounter[31] = Main.tileFrameCounter[31] + 1;
				if (Main.tileFrameCounter[31] > 10)
				{
					Main.tileFrameCounter[31] = 0;
					Main.tileFrame[31] = Main.tileFrame[31] + 1;
					if (Main.tileFrame[31] > 1)
					{
						Main.tileFrame[31] = 0;
					}
				}
				Main.tileFrameCounter[77] = Main.tileFrameCounter[77] + 1;
				if (Main.tileFrameCounter[77] > 5)
				{
					Main.tileFrameCounter[77] = 0;
					Main.tileFrame[77] = Main.tileFrame[77] + 1;
					if (Main.tileFrame[77] >= 12)
					{
						Main.tileFrame[77] = 0;
					}
				}
				Main.tileFrameCounter[106] = Main.tileFrameCounter[106] + 1;
				if (Main.tileFrameCounter[106] > 4)
				{
					Main.tileFrameCounter[106] = 0;
					Main.tileFrame[106] = Main.tileFrame[106] + 1;
					if (Main.tileFrame[106] >= 2)
					{
						Main.tileFrame[106] = 0;
					}
				}
				Main.tileFrameCounter[207] = Main.tileFrameCounter[207] + 1;
				if (Main.tileFrameCounter[207] > 4)
				{
					Main.tileFrameCounter[207] = 0;
					Main.tileFrame[207] = Main.tileFrame[207] + 1;
					if (Main.tileFrame[207] >= 6)
					{
						Main.tileFrame[207] = 0;
					}
				}
				Main.tileFrameCounter[215] = Main.tileFrameCounter[215] + 1;
				if (Main.tileFrameCounter[215] >= 4)
				{
					Main.tileFrameCounter[215] = 0;
					Main.tileFrame[215] = Main.tileFrame[215] + 1;
					if (Main.tileFrame[215] >= 8)
					{
						Main.tileFrame[215] = 0;
					}
				}
				Main.tileFrameCounter[217] = Main.tileFrameCounter[217] + 1;
				if (Main.tileFrameCounter[217] > 4)
				{
					Main.tileFrameCounter[217] = 0;
					Main.tileFrame[217] = Main.tileFrame[217] + 1;
					if (Main.tileFrame[217] >= 5)
					{
						Main.tileFrame[217] = 0;
					}
				}
				Main.tileFrameCounter[218] = Main.tileFrameCounter[218] + 1;
				if (Main.tileFrameCounter[218] > 4)
				{
					Main.tileFrameCounter[218] = 0;
					Main.tileFrame[218] = Main.tileFrame[218] + 1;
					if (Main.tileFrame[218] >= 2)
					{
						Main.tileFrame[218] = 0;
					}
				}
				Main.tileFrameCounter[219] = Main.tileFrameCounter[219] + 1;
				if (Main.tileFrameCounter[219] > 4)
				{
					Main.tileFrameCounter[219] = 0;
					Main.tileFrame[219] = Main.tileFrame[219] + 1;
					if (Main.tileFrame[219] >= 10)
					{
						Main.tileFrame[219] = 0;
					}
				}
				Main.tileFrameCounter[220] = Main.tileFrameCounter[220] + 1;
				if (Main.tileFrameCounter[220] > 4)
				{
					Main.tileFrameCounter[220] = 0;
					Main.tileFrame[220] = Main.tileFrame[220] + 1;
					if (Main.tileFrame[220] >= 4)
					{
						Main.tileFrame[220] = 0;
					}
				}
				Main.tileFrameCounter[231] = Main.tileFrameCounter[231] + 1;
				if (Main.tileFrameCounter[231] > 16)
				{
					Main.tileFrameCounter[231] = 0;
					Main.tileFrame[231] = Main.tileFrame[231] + 1;
					if (Main.tileFrame[231] >= 7)
					{
						Main.tileFrame[231] = 0;
					}
				}
				Main.tileFrameCounter[235] = Main.tileFrameCounter[235] + 1;
				if (Main.tileFrameCounter[235] > 20)
				{
					Main.tileFrameCounter[235] = 0;
					Main.tileFrame[235] = Main.tileFrame[235] + 1;
					if (Main.tileFrame[235] >= 4)
					{
						Main.tileFrame[235] = 0;
					}
					if (Main.tileFrame[235] <= 1)
					{
						Main.tileLighted[235] = false;
					}
					else
					{
						Main.tileLighted[235] = true;
					}
				}
				Main.tileFrameCounter[238] = Main.tileFrameCounter[238] + 1;
				if (Main.tileFrameCounter[238] > 20)
				{
					Main.tileFrameCounter[238] = 0;
					Main.tileFrame[238] = Main.tileFrame[238] + 1;
					if (Main.tileFrame[238] >= 4)
					{
						Main.tileFrame[238] = 0;
					}
				}
				Main.tileFrameCounter[243] = Main.tileFrameCounter[243] + 1;
				if (Main.tileFrameCounter[243] > 4)
				{
					Main.tileFrameCounter[243] = 0;
					Main.tileFrame[243] = Main.tileFrame[243] + 1;
					if (Main.tileFrame[243] >= 6)
					{
						Main.tileFrame[243] = 0;
					}
				}
				Main.tileFrameCounter[244] = Main.tileFrameCounter[244] + 1;
				if (Main.tileFrameCounter[244] > 4)
				{
					Main.tileFrameCounter[244] = 0;
					Main.tileFrame[244] = Main.tileFrame[244] + 1;
					if (Main.tileFrame[244] >= 6)
					{
						Main.tileFrame[244] = 0;
					}
				}
				Main.tileFrameCounter[247] = Main.tileFrameCounter[247] + 1;
				if (Main.tileFrameCounter[247] > 4)
				{
					Main.tileFrameCounter[247] = 0;
					Main.tileFrame[247] = Main.tileFrame[247] + 1;
					if (Main.tileFrame[247] > 7)
					{
						Main.tileFrame[247] = 0;
					}
				}
				Main.tileFrameCounter[96] = Main.tileFrameCounter[96] + 1;
				if (Main.tileFrameCounter[96] > 4)
				{
					Main.tileFrameCounter[96] = 0;
					Main.tileFrame[96] = Main.tileFrame[96] + 1;
					if (Main.tileFrame[96] > 3)
					{
						Main.tileFrame[96] = 0;
					}
				}
				Main.tileFrameCounter[171] = Main.tileFrameCounter[171] + 1;
				if (Main.tileFrameCounter[171] > 16)
				{
					Main.tileFrameCounter[171] = 0;
					Main.tileFrame[171] = Main.tileFrame[171] + 1;
					if (Main.tileFrame[171] > 3)
					{
						Main.tileFrame[171] = 0;
					}
				}
				Main.tileFrameCounter[270] = Main.tileFrameCounter[270] + 1;
				if (Main.tileFrameCounter[270] > 8)
				{
					Main.tileFrameCounter[270] = 0;
					Main.tileFrame[270] = Main.tileFrame[270] + 1;
					if (Main.tileFrame[270] > 5)
					{
						Main.tileFrame[270] = 0;
					}
				}
				Main.tileFrame[271] = Main.tileFrame[270];
				Main.tileFrameCounter[272] = Main.tileFrameCounter[272] + 1;
				if (Main.tileFrameCounter[272] >= 10)
				{
					Main.tileFrameCounter[272] = 0;
					Main.tileFrame[272] = Main.tileFrame[272] + 1;
					if (Main.tileFrame[272] > 1)
					{
						Main.tileFrame[272] = 0;
					}
				}
				Main.tileFrameCounter[300] = Main.tileFrameCounter[300] + 1;
				if (Main.tileFrameCounter[300] >= 5)
				{
					Main.tileFrameCounter[300] = 0;
					Main.tileFrame[300] = Main.tileFrame[300] + 1;
					if (Main.tileFrame[300] > 6)
					{
						Main.tileFrame[300] = 0;
					}
				}
				Main.tileFrameCounter[301] = Main.tileFrameCounter[301] + 1;
				if (Main.tileFrameCounter[301] >= 5)
				{
					Main.tileFrameCounter[301] = 0;
					Main.tileFrame[301] = Main.tileFrame[301] + 1;
					if (Main.tileFrame[301] > 7)
					{
						Main.tileFrame[301] = 0;
					}
				}
				Main.tileFrameCounter[302] = Main.tileFrameCounter[302] + 1;
				if (Main.tileFrameCounter[302] >= 5)
				{
					Main.tileFrameCounter[302] = 0;
					Main.tileFrame[302] = Main.tileFrame[302] + 1;
					if (Main.tileFrame[302] > 3)
					{
						Main.tileFrame[302] = 0;
					}
				}
				Main.tileFrameCounter[303] = Main.tileFrameCounter[303] + 1;
				if (Main.tileFrameCounter[303] >= 5)
				{
					Main.tileFrameCounter[303] = 0;
					Main.tileFrame[303] = Main.tileFrame[303] + 1;
					if (Main.tileFrame[303] > 4)
					{
						Main.tileFrame[303] = 0;
					}
				}
				Main.tileFrameCounter[305] = Main.tileFrameCounter[305] + 1;
				if (Main.tileFrameCounter[305] >= 5)
				{
					Main.tileFrameCounter[305] = 0;
					Main.tileFrame[305] = Main.tileFrame[305] + 1;
					if (Main.tileFrame[305] > 11)
					{
						Main.tileFrame[305] = 0;
					}
				}
				Main.tileFrameCounter[306] = Main.tileFrameCounter[306] + 1;
				if (Main.tileFrameCounter[306] >= 5)
				{
					Main.tileFrameCounter[306] = 0;
					Main.tileFrame[306] = Main.tileFrame[306] + 1;
					if (Main.tileFrame[306] > 11)
					{
						Main.tileFrame[306] = 0;
					}
				}
				Main.tileFrameCounter[307] = Main.tileFrameCounter[307] + 1;
				if (Main.tileFrameCounter[307] >= 5)
				{
					Main.tileFrameCounter[307] = 0;
					Main.tileFrame[307] = Main.tileFrame[307] + 1;
					if (Main.tileFrame[307] > 1)
					{
						Main.tileFrame[307] = 0;
					}
				}
				Main.tileFrameCounter[308] = Main.tileFrameCounter[308] + 1;
				if (Main.tileFrameCounter[308] >= 5)
				{
					Main.tileFrameCounter[308] = 0;
					Main.tileFrame[308] = Main.tileFrame[308] + 1;
					if (Main.tileFrame[308] > 7)
					{
						Main.tileFrame[308] = 0;
					}
				}
				Main.tileFrameCounter[314] = Main.tileFrameCounter[314] + 1;
				if (Main.tileFrameCounter[314] >= 10)
				{
					Main.tileFrameCounter[314] = 0;
					Main.tileFrame[314] = Main.tileFrame[314] + 1;
					if (Main.tileFrame[314] > 4)
					{
						Main.tileFrame[314] = 0;
					}
				}
				Main.tileFrameCounter[326] = Main.tileFrameCounter[326] + 1;
				if (Main.tileFrameCounter[326] >= 5)
				{
					Main.tileFrameCounter[326] = 0;
					Main.tileFrame[326] = Main.tileFrame[326] + 1;
					if (Main.tileFrame[326] > 7)
					{
						Main.tileFrame[326] = 0;
					}
				}
				Main.tileFrameCounter[327] = Main.tileFrameCounter[327] + 1;
				if (Main.tileFrameCounter[327] >= 10)
				{
					Main.tileFrameCounter[327] = 0;
					Main.tileFrame[327] = Main.tileFrame[327] + 1;
					if (Main.tileFrame[327] > 7)
					{
						Main.tileFrame[327] = 0;
					}
				}
				Main.tileFrameCounter[345] = Main.tileFrameCounter[345] + 1;
				if (Main.tileFrameCounter[345] >= 10)
				{
					Main.tileFrameCounter[345] = 0;
					Main.tileFrame[345] = Main.tileFrame[345] + 1;
					if (Main.tileFrame[345] > 7)
					{
						Main.tileFrame[345] = 0;
					}
				}
				Main.tileFrameCounter[336] = Main.tileFrameCounter[336] + 1;
				if (Main.tileFrameCounter[336] >= 5)
				{
					Main.tileFrameCounter[336] = 0;
					Main.tileFrame[336] = Main.tileFrame[336] + 1;
					if (Main.tileFrame[336] > 3)
					{
						Main.tileFrame[336] = 0;
					}
				}
				Main.tileFrameCounter[328] = Main.tileFrameCounter[328] + 1;
				if (Main.tileFrameCounter[328] >= 5)
				{
					Main.tileFrameCounter[328] = 0;
					Main.tileFrame[328] = Main.tileFrame[328] + 1;
					if (Main.tileFrame[328] > 7)
					{
						Main.tileFrame[328] = 0;
					}
				}
				Main.tileFrameCounter[329] = Main.tileFrameCounter[329] + 1;
				if (Main.tileFrameCounter[329] >= 5)
				{
					Main.tileFrameCounter[329] = 0;
					Main.tileFrame[329] = Main.tileFrame[329] + 1;
					if (Main.tileFrame[329] > 7)
					{
						Main.tileFrame[329] = 0;
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
				Main.tileFrameCounter[351] = Main.tileFrameCounter[351] + 1;
				if (Main.tileFrameCounter[351] >= 5)
				{
					Main.tileFrameCounter[351] = 0;
					Main.tileFrame[351] = Main.tileFrame[351] + 1;
					if (Main.tileFrame[351] > 2)
					{
						Main.tileFrame[351] = 0;
					}
				}
				Main.tileFrameCounter[354] = Main.tileFrameCounter[354] + 1;
				if (Main.tileFrameCounter[354] >= 5)
				{
					Main.tileFrameCounter[354] = 0;
					Main.tileFrame[354] = Main.tileFrame[354] + 1;
					if (Main.tileFrame[354] >= 8)
					{
						Main.tileFrame[354] = 0;
					}
				}
				Main.tileFrame[355] = Main.tileFrame[354];
				Main.tileFrameCounter[377] = Main.tileFrameCounter[377] + 1;
				if (Main.tileFrameCounter[377] >= 5)
				{
					Main.tileFrameCounter[377] = 0;
					Main.tileFrame[377] = Main.tileFrame[377] + 1;
					if (Main.tileFrame[377] >= 4)
					{
						Main.tileFrame[377] = 0;
					}
				}
				Main.tileFrameCounter[379] = Main.tileFrameCounter[379] + 1;
				if (Main.tileFrameCounter[379] >= 10)
				{
					Main.tileFrameCounter[379] = 0;
					Main.tileFrame[379] = Main.tileFrame[379] + 1;
					if (Main.tileFrame[379] >= 4)
					{
						Main.tileFrame[379] = 0;
					}
				}
				int num8 = Main.tileFrameCounter[390] + 1;
				int num9 = num8;
				Main.tileFrameCounter[390] = num8;
				if (num9 >= 8)
				{
					Main.tileFrameCounter[390] = 0;
					int num10 = Main.tileFrame[390] + 1;
					int num11 = num10;
					Main.tileFrame[390] = num10;
					if (num11 >= 7)
					{
						Main.tileFrame[390] = 0;
					}
				}
				int num12 = Main.tileFrameCounter[228] + 1;
				int num13 = num12;
				Main.tileFrameCounter[228] = num12;
				if (num13 >= 5)
				{
					Main.tileFrameCounter[228] = 0;
					int num14 = Main.tileFrame[228] + 1;
					int num15 = num14;
					Main.tileFrame[228] = num14;
					if (num15 >= 3)
					{
						Main.tileFrame[228] = 0;
					}
				}
				int num16 = Main.tileFrameCounter[405] + 1;
				int num17 = num16;
				Main.tileFrameCounter[405] = num16;
				if (num17 >= 5)
				{
					Main.tileFrameCounter[405] = 0;
					int num18 = Main.tileFrame[405] + 1;
					int num19 = num18;
					Main.tileFrame[405] = num18;
					if (num19 >= 8)
					{
						Main.tileFrame[405] = 0;
					}
				}
				int num20 = Main.tileFrameCounter[406] + 1;
				int num21 = num20;
				Main.tileFrameCounter[406] = num20;
				if (num21 >= 8)
				{
					Main.tileFrameCounter[406] = 0;
					int num22 = Main.tileFrame[406] + 1;
					int num23 = num22;
					Main.tileFrame[406] = num22;
					if (num23 >= 6)
					{
						Main.tileFrame[406] = 0;
					}
				}
				int num24 = Main.tileFrame[412] + 1;
				int num25 = num24;
				Main.tileFrame[412] = num24;
				if (num25 >= 240)
				{
					Main.tileFrame[412] = 0;
				}
				int num26 = Main.tileFrameCounter[410] + 1;
				num5 = num26;
				Main.tileFrameCounter[410] = num26;
				if (num5 >= 8)
				{
					Main.tileFrameCounter[410] = 0;
					int num27 = Main.tileFrame[410] + 1;
					num5 = num27;
					Main.tileFrame[410] = num27;
					if (num5 >= 8)
					{
						Main.tileFrame[410] = 0;
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
						NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].inventory[j].name, Main.myPlayer, (float)j, (float)Main.player[Main.myPlayer].inventory[j].prefix, 0f, 0, 0, 0);
					}
				}
				for (int k = 0; k < (int)Main.player[Main.myPlayer].armor.Length; k++)
				{
					if (Main.player[Main.myPlayer].armor[k].IsNotTheSameAs(Main.clientPlayer.armor[k]))
					{
						NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[k].name, Main.myPlayer, (float)(59 + k), (float)Main.player[Main.myPlayer].armor[k].prefix, 0f, 0, 0, 0);
					}
				}
				for (int l = 0; l < (int)Main.player[Main.myPlayer].miscEquips.Length; l++)
				{
					if (Main.player[Main.myPlayer].miscEquips[l].IsNotTheSameAs(Main.clientPlayer.miscEquips[l]))
					{
						NetMessage.SendData(5, -1, -1, "", Main.myPlayer, (float)(58 + (int)Main.player[Main.myPlayer].armor.Length + (int)Main.player[Main.myPlayer].dye.Length + 1 + l), (float)Main.player[Main.myPlayer].miscEquips[l].prefix, 0f, 0, 0, 0);
					}
				}
				for (int m = 0; m < (int)Main.player[Main.myPlayer].miscDyes.Length; m++)
				{
					if (Main.player[Main.myPlayer].miscDyes[m].IsNotTheSameAs(Main.clientPlayer.miscDyes[m]))
					{
						NetMessage.SendData(5, -1, -1, "", Main.myPlayer, (float)(58 + (int)Main.player[Main.myPlayer].armor.Length + (int)Main.player[Main.myPlayer].dye.Length + (int)Main.player[Main.myPlayer].miscEquips.Length + 1 + m), (float)Main.player[Main.myPlayer].miscDyes[m].prefix, 0f, 0, 0, 0);
					}
				}
				for (int n = 0; n < (int)Main.player[Main.myPlayer].bank.item.Length; n++)
				{
					if (Main.player[Main.myPlayer].bank.item[n].IsNotTheSameAs(Main.clientPlayer.bank.item[n]))
					{
						NetMessage.SendData(5, -1, -1, "", Main.myPlayer, (float)(58 + (int)Main.player[Main.myPlayer].armor.Length + (int)Main.player[Main.myPlayer].dye.Length + (int)Main.player[Main.myPlayer].miscEquips.Length + (int)Main.player[Main.myPlayer].miscDyes.Length + 1 + n), (float)Main.player[Main.myPlayer].bank.item[n].prefix, 0f, 0, 0, 0);
					}
				}
				for (int o = 0; o < (int)Main.player[Main.myPlayer].bank2.item.Length; o++)
				{
					if (Main.player[Main.myPlayer].bank2.item[o].IsNotTheSameAs(Main.clientPlayer.bank2.item[o]))
					{
						NetMessage.SendData(5, -1, -1, "", Main.myPlayer, (float)(58 + (int)Main.player[Main.myPlayer].armor.Length + (int)Main.player[Main.myPlayer].dye.Length + (int)Main.player[Main.myPlayer].miscEquips.Length + (int)Main.player[Main.myPlayer].miscDyes.Length + (int)Main.player[Main.myPlayer].bank.item.Length + 1 + o), (float)Main.player[Main.myPlayer].bank2.item[o].prefix, 0f, 0, 0, 0);
					}
				}
				for (int p = 0; p < (int)Main.player[Main.myPlayer].dye.Length; p++)
				{
					if (Main.player[Main.myPlayer].dye[p].IsNotTheSameAs(Main.clientPlayer.dye[p]))
					{
						NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[0].name, Main.myPlayer, (float)(58 + (int)Main.player[Main.myPlayer].armor.Length + 1 + p), (float)Main.player[Main.myPlayer].dye[p].prefix, 0f, 0, 0, 0);
					}
				}
				if (Main.player[Main.myPlayer].chest != Main.clientPlayer.chest && Main.player[Main.myPlayer].chest < 0)
				{
					if (!Main.player[Main.myPlayer].editedChestName)
					{
						NetMessage.SendData(33, -1, -1, "", Main.player[Main.myPlayer].chest, 0f, 0f, 0f, 0, 0, 0);
					}
					else
					{
						if (Main.chest[Main.clientPlayer.chest] == null)
						{
							NetMessage.SendData(33, -1, -1, "", Main.player[Main.myPlayer].chest, 0f, 0f, 0f, 0, 0, 0);
						}
						else
						{
							NetMessage.SendData(33, -1, -1, Main.chest[Main.clientPlayer.chest].name, Main.player[Main.myPlayer].chest, 1f, 0f, 0f, 0, 0, 0);
						}
						Main.player[Main.myPlayer].editedChestName = false;
					}
				}
				if (Main.player[Main.myPlayer].talkNPC != Main.clientPlayer.talkNPC)
				{
					NetMessage.SendData(40, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
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
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
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
					NetMessage.SendData(16, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
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
					NetMessage.SendData(42, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
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
					NetMessage.SendData(50, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
					NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
				}
				bool flag2 = false;
				if (Main.player[Main.myPlayer].MinionTargetPoint != Main.clientPlayer.MinionTargetPoint)
				{
					flag2 = true;
				}
				if (flag2)
				{
					NetMessage.SendData(99, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
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
				Main.tileSolid[379] = false;
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
				Main.tileSolid[379] = true;
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
				NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
			}
			if (Main.netPlayCounter % 900 == 0)
			{
				NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
				NetMessage.SendData(16, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
				NetMessage.SendData(40, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
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
							NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
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
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
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
							NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						}
					}
					else if (Main.invasionType == 2)
					{
						NPC.downedFrost = true;
					}
					else if (Main.invasionType == 3)
					{
						NPC.downedPirates = true;
					}
					else if (Main.invasionType == 4)
					{
						NPC.downedMartians = true;
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
				NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
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
						NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0, 0, 0);
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
					NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
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
						NetMessage.SendData(25, -1, -1, Lang.gen[75], 255, 50f, 255f, 130f, 0, 0, 0);
					}
					else
					{
						NetMessage.SendData(25, -1, -1, Lang.gen[74], 255, 50f, 255f, 130f, 0, 0, 0);
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
							if (Main.npc[j].active && Main.npc[j].townNPC && Main.npc[j].type != 37 && Main.npc[j].type != 453)
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
					Main.eclipse = false;
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
										NetMessage.SendData(25, -1, -1, Lang.misc[9], 255, 50f, 255f, 130f, 0, 0, 0);
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
											NetMessage.SendData(25, -1, -1, Lang.misc[28], 255, 50f, 255f, 130f, 0, 0, 0);
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
											NetMessage.SendData(25, -1, -1, Lang.misc[29], 255, 50f, 255f, 130f, 0, 0, 0);
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
											NetMessage.SendData(25, -1, -1, Lang.misc[30], 255, 50f, 255f, 130f, 0, 0, 0);
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
								if (Main.netMode == 0)
								{
									Main.NewText(Lang.misc[8], 50, 255, 130, false);
								}
								else if (Main.netMode == 2)
								{
									NetMessage.SendData(25, -1, -1, Lang.misc[8], 255, 50f, 255f, 130f, 0, 0, 0);
								}
							}
						}
					}
					Main.time = 0;
					Main.dayTime = false;
					if (Main.netMode == 2)
					{
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
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
								if (Main.npc[o].type != 368 && Main.npc[o].type != 37 && Main.npc[o].type != 453 && !Main.npc[o].homeless)
								{
									WorldGen.QuickFindHome(o);
								}
								if (Main.npc[o].type == 37)
								{
									num16++;
								}
								if (Main.npc[o].type == 17)
								{
									num11++;
								}
								if (Main.npc[o].type == 18)
								{
									num12++;
								}
								if (Main.npc[o].type == 19)
								{
									num14++;
								}
								if (Main.npc[o].type == 20)
								{
									num13++;
								}
								if (Main.npc[o].type == 22)
								{
									num15++;
								}
								if (Main.npc[o].type == 38)
								{
									num17++;
								}
								if (Main.npc[o].type == 54)
								{
									num18++;
								}
								if (Main.npc[o].type == 107)
								{
									num20++;
								}
								if (Main.npc[o].type == 108)
								{
									num19++;
								}
								if (Main.npc[o].type == 124)
								{
									num21++;
								}
								if (Main.npc[o].type == 142)
								{
									num22++;
								}
								if (Main.npc[o].type == 160)
								{
									num23++;
								}
								if (Main.npc[o].type == 178)
								{
									num24++;
								}
								if (Main.npc[o].type == 207)
								{
									num25++;
								}
								if (Main.npc[o].type == 208)
								{
									num26++;
								}
								if (Main.npc[o].type == 209)
								{
									num27++;
								}
								if (Main.npc[o].type == 227)
								{
									num28++;
								}
								if (Main.npc[o].type == 228)
								{
									num29++;
								}
								if (Main.npc[o].type == 229)
								{
									num30++;
								}
								if (Main.npc[o].type == 353)
								{
									num31++;
								}
								if (Main.npc[o].type == 369)
								{
									num32++;
								}
								if (Main.npc[o].type == 441)
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
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						WorldGen.saveAndPlay();
					}
					if (Main.netMode != 1)
					{
						if (Main.hardMode && NPC.downedMechBossAny && Main.rand.Next(14) == 0)
						{
							Main.eclipse = true;
							if (Main.eclipse)
							{
								if (Main.netMode == 0)
								{
									Main.NewText(Lang.misc[20], 50, 255, 130, false);
								}
								else if (Main.netMode == 2)
								{
									NetMessage.SendData(25, -1, -1, Lang.misc[20], 255, 50f, 255f, 130f, 0, 0, 0);
								}
							}
							if (Main.netMode == 2)
							{
								NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
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
					NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
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

		public static event Action OnEngineLoad;

		public delegate void OnPlayerSelected(PlayerFileData player);

		public static string WorldPathClassic { get; set; }
	}
}
