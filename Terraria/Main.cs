using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using TerrariaApi.Server;

namespace Terraria
{
	public class Main
	{
		public static int maxItemTypes = 2289;
		public static int maxProjectileTypes = 360;
		public static int maxNPCTypes = 369;
		public static int maxTileSets = 314;
		public static int maxWallTypes = 145;
		public static int maxGoreTypes = 573;
		public static int numArmorHead = 160;
		public static int numArmorBody = 168;
		public static int numArmorLegs = 103;
		public static int numAccHandsOn = 18;
		public static int numAccHandsOff = 11;
		public static int numAccNeck = 7;
		public static int numAccBack = 8;
		public static int numAccFront = 5;
		public static int numAccShoes = 15;
		public static int numAccWaist = 11;
		public static int numAccShield = 5;
		public static int numAccFace = 8;
		public static int numAccBalloon = 11;
		public static int maxBuffs = 104;
		public static int maxWings = 25;
		public static int maxBackgrounds = 185;
		private static int MF_BYPOSITION = 1024;
		public static int sectionWidth = 200;
		public static int sectionHeight = 150;
		public static int maxDust = 6000;
		public static int maxCombatText = 100;
		public static int maxItemText = 20;
		public static int maxPlayers = 255;
		public static int maxChests = 1000;
		public static int maxItems = 400;
		public static int maxProjectiles = 1000;
		public static int maxNPCs = 200;
		public static int maxGore = 500;
		public static int realInventory = 50;
		public static int maxInventory = 58;
		public static int maxItemSounds = 51;
		public static int maxNPCHitSounds = 13;
		public static int maxNPCKilledSounds = 19;
		public static int maxLiquidTypes = 12;
		public static int maxMusic = 33;
		public static double dayLength = 54000.0;
		public static double nightLength = 32400.0;
		public static int maxStars = 130;
		public static int maxStarTypes = 5;
		public static int maxClouds = 200;
		public static int maxCloudTypes = 22;
		public static int maxHair = 123;
		public static int maxCharSelectHair = 51;
		public static int curRelease = 94;
		public static string versionNumber = "v1.2.3.1";
		public static string versionNumber2 = "v1.2.3.1";
		public static WorldSections sectionManager;
		public static bool ServerSideCharacter = false;
		public static string clientUUID;
		public static int maxMsg = 74;
		public static int npcStreamSpeed = 60;
		public static int musicError = 0;
		public static bool dedServFPS = false;
		public static int dedServCount1 = 0;
		public static int dedServCount2 = 0;
		public static bool superFast = false;
		public static bool[] hairLoaded = new bool[123];
		public static bool[] wingsLoaded = new bool[25];
		public static bool[] goreLoaded = new bool[573];
		public static bool[] projectileLoaded = new bool[360];
		public static bool[] itemFlameLoaded = new bool[2289];
		public static bool[] backgroundLoaded = new bool[185];
		public static bool[] tileSetsLoaded = new bool[314];
		public static bool[] wallLoaded = new bool[145];
		public static bool[] NPCLoaded = new bool[369];
		public static bool[] armorHeadLoaded = new bool[160];
		public static bool[] armorBodyLoaded = new bool[168];
		public static bool[] armorLegsLoaded = new bool[103];
		public static bool[] accHandsOnLoaded = new bool[18];
		public static bool[] accHandsOffLoaded = new bool[11];
		public static bool[] accBackLoaded = new bool[8];
		public static bool[] accFrontLoaded = new bool[5];
		public static bool[] accShoesLoaded = new bool[15];
		public static bool[] accWaistLoaded = new bool[11];
		public static bool[] accShieldLoaded = new bool[5];
		public static bool[] accNeckLoaded = new bool[7];
		public static bool[] accFaceLoaded = new bool[8];
		public static bool[] accballoonLoaded = new bool[11];
		public static Vector2[] offHandOffsets = new Vector2[]
		{
			new Vector2(14f, 20f),
			new Vector2(14f, 20f),
			new Vector2(14f, 20f),
			new Vector2(14f, 18f),
			new Vector2(14f, 20f),
			new Vector2(16f, 4f),
			new Vector2(16f, 16f),
			new Vector2(18f, 14f),
			new Vector2(18f, 14f),
			new Vector2(18f, 14f),
			new Vector2(16f, 16f),
			new Vector2(16f, 16f),
			new Vector2(16f, 16f),
			new Vector2(16f, 16f),
			new Vector2(14f, 14f),
			new Vector2(14f, 14f),
			new Vector2(12f, 14f),
			new Vector2(14f, 16f),
			new Vector2(16f, 16f),
			new Vector2(16f, 16f)
		};
		public static float zoomX;
		public static float zoomY;
		public static float sunCircle;
		public static int BlackFadeIn = 0;
		public static bool noWindowBorder = false;
		public static int ugBack = 0;
		public static int oldUgBack = 0;
		public static int[] bgFrame = new int[1];
		public static int[] bgFrameCounter = new int[1];
		public static bool skipMenu = false;
		public static bool verboseNetplay = false;
		public static bool stopTimeOuts = false;
		public static bool showSpam = false;
		public static bool showItemOwner = false;
		public static int oldTempLightCount = 0;
		public static bool[] nextNPC = new bool[369];
		public static int musicBox = -1;
		public static int musicBox2 = -1;
		public static byte hbPosition = 1;
		public static bool cEd = false;
		public static float wFrCounter = 0f;
		public static float wFrame = 0f;
		public static float upTimer;
		public static float upTimerMax;
		public static float upTimerMaxDelay;
		public static float[] drawTimer = new float[10];
		public static float[] drawTimerMax = new float[10];
		public static float[] drawTimerMaxDelay = new float[10];
		public static float[] renderTimer = new float[10];
		public static float[] lightTimer = new float[10];
		public static bool drawDiag = false;
		public static bool drawRelease = false;
		public static int debugToggle = 0;
		public static bool toggleRelease = false;
		public static bool drawBetterDebug = false;
		public static bool betterDebugRelease = false;
		public static bool renderNow = false;
		public static bool drawToScreen = false;
		public static bool targetSet = false;
		public static int mouseX;
		public static int mouseY;
		public static bool mouseLeft;
		public static bool mouseRight;
		public static float essScale = 1f;
		public static int essDir = -1;
		public static float[] cloudBGX = new float[2];
		public static float cloudBGAlpha;
		public static float cloudBGActive;
		public static int[] cloudBG = new int[]
		{
			112,
			113
		};
		public static int[] treeMntBG = new int[2];
		public static int[] treeBG = new int[3];
		public static int[] corruptBG = new int[3];
		public static int[] jungleBG = new int[3];
		public static int[] snowMntBG = new int[2];
		public static int[] snowBG = new int[3];
		public static int[] hallowBG = new int[3];
		public static int[] crimsonBG = new int[3];
		public static int[] desertBG = new int[2];
		public static int oceanBG;
		public static int[] treeX = new int[4];
		public static int[] treeStyle = new int[4];
		public static int[] caveBackX = new int[4];
		public static int[] caveBackStyle = new int[4];
		public static int iceBackStyle;
		public static int hellBackStyle;
		public static int jungleBackStyle;
		public static string debugWords = "";
		public static bool gamePad = false;
		public static bool xMas = false;
		public static bool halloween = false;
		public static int snowDust = 0;
		public static bool chTitle = false;
		public static bool hairWindow = false;
		public static bool clothesWindow = false;
		public static bool ingameOptionsWindow = false;
		public static int keyCount = 0;
		public static string[] keyString = new string[10];
		public static int[] keyInt = new int[10];
		public static byte gFade = 0;
		public static float gFader = 0f;
		public static byte gFadeDir = 1;
		public static bool netDiag = false;
		public static int txData = 0;
		public static int rxData = 0;
		public static int txMsg = 0;
		public static int rxMsg = 0;
		public static int[] rxMsgType = new int[Main.maxMsg];
		public static int[] rxDataType = new int[Main.maxMsg];
		public static int[] txMsgType = new int[Main.maxMsg];
		public static int[] txDataType = new int[Main.maxMsg];
		public static float uCarry = 0f;
		public static bool drawSkip = false;
		public static int fpsCount = 0;
		public static Stopwatch fpsTimer = new Stopwatch();
		public static Stopwatch updateTimer = new Stopwatch();
		public bool gammaTest;
		public static int fountainColor = -1;
		public static bool showSplash = true;
		public static bool ignoreErrors = true;
		public static string defaultIP = "";
		public static int dayRate = 1;
		public static int maxScreenW = 1920;
		public static int minScreenW = 800;
		public static int maxScreenH = 1200;
		public static int minScreenH = 600;
		public static float iS = 1f;
		public static bool render = false;
		public static int qaStyle = 0;
		public static int zoneX = 99;
		public static int zoneY = 87;
		public static float harpNote = 0f;
		public static bool[] projHostile = new bool[360];
		public static bool[] pvpBuff = new bool[104];
		public static bool[] vanityPet = new bool[104];
		public static bool[] lightPet = new bool[104];
		public static bool[] meleeBuff = new bool[104];
		public static bool[] debuff = new bool[104];
		public static string[] buffName = new string[104];
		public static string[] buffTip = new string[104];
		public static int maxMP = 10;
		public static string[] recentWorld = new string[Main.maxMP];
		public static string[] recentIP = new string[Main.maxMP];
		public static int[] recentPort = new int[Main.maxMP];
		public static bool shortRender = true;
		public static bool owBack = true;
		public static int quickBG = 2;
		public static int bgDelay = 0;
		public static int bgStyle = 0;
		public static float[] bgAlpha = new float[10];
		public static float[] bgAlpha2 = new float[10];
		public bool showNPCs;
		public int mouseNPC = -1;
		public static int wof = -1;
		public static int wofT;
		public static int wofB;
		public static int wofF = 0;
		public static int offScreenRange = 200;
		public static int maxMapUpdates = 250000;
		public static bool refreshMap = false;
		public static int loadMapLastX = 0;
		public static bool loadMapLock = false;
		public static bool loadMap = false;
		public static bool mapReady = false;
		public static int textureMaxWidth = 2000;
		public static int textureMaxHeight = 1800;
		public static bool updateMap = false;
		public static int mapMinX = 0;
		public static int mapMaxX = 0;
		public static int mapMinY = 0;
		public static int mapMaxY = 0;
		public static int mapTimeMax = 30;
		public static int mapTime = Main.mapTimeMax;
		public static bool clearMap;
		public static int mapTargetX = 5;
		public static int mapTargetY = 2;
		public static bool mapInit = false;
		public static bool mapEnabled = true;
		public static int mapStyle = 1;
		public static float grabMapX = 0f;
		public static float grabMapY = 0f;
		public static int miniMapX = 0;
		public static int miniMapY = 0;
		public static int miniMapWidth = 0;
		public static int miniMapHeight = 0;
		public static float mapMinimapScale = 1.25f;
		public static float mapMinimapAlpha = 1f;
		public static float mapOverlayScale = 2.5f;
		public static float mapOverlayAlpha = 0.35f;
		public static bool mapFullscreen = false;
		public static bool resetMapFull = false;
		public static float mapFullscreenScale = 4f;
		public static Vector2 mapFullscreenPos = new Vector2(-1f, -1f);
		private int firstTileX;
		private int lastTileX;
		private int firstTileY;
		private int lastTileY;
		private double bgParrallax;
		private int bgStart;
		private int bgLoops;
		private int bgStartY;
		private int bgLoopsY;
		private int bgTop;
		public static int renderCount = 99;
		private Process tServer = new Process();
		private static Stopwatch saveTime = new Stopwatch();
		public static Color mcColor = new Color(125, 125, 255);
		public static Color hcColor = new Color(200, 125, 255);
		public static Color highVersionColor = new Color(255, 255, 0);
		public static Color errorColor = new Color(255, 0, 0);
		public static Color bgColor;
		public static bool mouseHC = false;
		public static bool craftingHide = false;
		public static bool armorHide = false;
		public static float craftingAlpha = 1f;
		public static float armorAlpha = 1f;
		public static float[] buffAlpha = new float[104];
		public static Item trashItem = new Item();
		public static bool hardMode = false;
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
		public static bool drawScene = false;
		public static Vector2 sceneWaterPos = default(Vector2);
		public static Vector2 sceneTilePos = default(Vector2);
		public static Vector2 sceneTile2Pos = default(Vector2);
		public static Vector2 sceneWallPos = default(Vector2);
		public static Vector2 sceneBackgroundPos = default(Vector2);
		public static bool maxQ = true;
		public static float gfxQuality = 1f;
		public static float gfxRate = 0.01f;
		public int DiscoStyle;
		public static int DiscoR = 255;
		public static int DiscoB = 0;
		public static int DiscoG = 0;
		public static int teamCooldown = 0;
		public static int teamCooldownLen = 300;
		public static bool gamePaused = false;
		public static bool gameInactive = false;
		public static int updateTime = 0;
		public static int drawTime = 0;
		public static int uCount = 0;
		public static int updateRate = 0;
		public static int frameRate = 0;
		public static bool RGBRelease = false;
		public static bool qRelease = false;
		public static bool netRelease = false;
		public static bool frameRelease = false;
		public static bool showFrameRate = false;
		public static int magmaBGFrame = 0;
		public static int magmaBGFrameCounter = 0;
		public static int saveTimer = 0;
		public static bool autoJoin = false;
		public static bool serverStarting = false;
		public static float leftWorld = 0f;
		public static float rightWorld = 134400f;
		public static float topWorld = 0f;
		public static float bottomWorld = 38400f;
		public static int maxTilesX = (int)Main.rightWorld / 16 + 1;
		public static int maxTilesY = (int)Main.bottomWorld / 16 + 1;
		public static int maxSectionsX = Main.maxTilesX / 200;
		public static int maxSectionsY = Main.maxTilesY / 150;
		public static int numDust = 6000;
		public static int numPlayers = 0;
		public static int maxNetPlayers = 255;
		public static int maxRain = 750;
		public int invBottom = 210;
		public static float cameraX = 0f;
		public static bool drewLava = false;
		public static float[] liquidAlpha = new float[12];
		public static int waterStyle = 0;
		public static int worldRate = 1;
		public static float caveParrallax = 1f;
		public static int dungeonX;
		public static int dungeonY;
		public static Liquid[] liquid = new Liquid[Liquid.resLiquid];
		public static LiquidBuffer[] liquidBuffer = new LiquidBuffer[10000];
		public static bool dedServ = false;
		public static int spamCount = 0;
		public static int curMusic = 0;
		public static int dayMusic = 0;
		public static int ugMusic = 0;
		public int newMusic;
		public static bool showItemText = true;
		public static bool autoSave = true;
		public static bool validateSaves = true;
		public static string buffString = "";
		public static string libPath = "";
		public static int lo = 0;
		public static int LogoA = 255;
		public static int LogoB = 0;
		public static bool LogoT = false;
		public static string statusText = "";
		public static string worldName = "";
		public static int worldID;
		public static int background = 0;
		public static int caveBackground = 0;
		public static float ugBackTransition = 0f;
		public static Color tileColor;
		public static double worldSurface;
		public static double rockLayer;
		public static Color[] teamColor = new Color[5];
		public static bool dayTime = true;
		public static double time = 13500.0;
		public static int moonPhase = 0;
		public static short sunModY = 0;
		public static short moonModY = 0;
		public static bool grabSky = false;
		public static bool bloodMoon = false;
		public static bool pumpkinMoon = false;
		public static bool snowMoon = false;
		public static float cloudAlpha = 0f;
		public static float maxRaining = 0f;
		public static float oldMaxRaining = 0f;
		public static int rainTime = 0;
		public static bool raining = false;
		public static bool eclipse = false;
		public static float eclipseLight = 0f;
		public static int checkForSpawns = 0;
		public static int helpText = 0;
		public static bool autoGen = false;
		public static bool autoPause = false;
		public static int[] projFrames = new int[360];
		public static bool[] projPet = new bool[360];
		public static float demonTorch = 1f;
		public static int demonTorchDir = 1;
		public static int numStars;
		public static int weatherCounter = 0;
		public static int cloudLimit = 200;
		public static int numClouds = Main.cloudLimit;
		public static int numCloudsTemp = Main.numClouds;
		public static float windSpeedTemp = 0f;
		public static float windSpeed = 0f;
		public static float windSpeedSet = 0f;
		public static float windSpeedSpeed = 0f;
		public static bool resetClouds = true;
		public static int sandTiles;
		public static int evilTiles;
		public static int shroomTiles;
		public static float shroomLight;
		public static int snowTiles;
		public static int holyTiles;
		public static int waterCandles;
		public static int meteorTiles;
		public static int bloodTiles;
		public static int jungleTiles;
		public static int dungeonTiles;
		public static bool campfire;
		public static bool heartLantern;
		public static int fadeCounter = 0;
		public static float invAlpha = 1f;
		public static float invDir = 1f;
		[ThreadStatic]
		public static Random rand;
		public static int maxMoons = 3;
		public static int moonType = 0;
		public static int numTileColors = 31;
		public static bool[] tileLighted = new bool[314];
		public static bool[] tileMergeDirt = new bool[314];
		public static bool[] tileCut = new bool[314];
		public static bool[] tileAlch = new bool[314];
		public static int[] tileShine = new int[314];
		public static bool[] tileShine2 = new bool[314];
		public static bool[] wallHouse = new bool[145];
		public static bool[] wallDungeon = new bool[145];
		public static bool[] wallLight = new bool[145];
		public static int[] wallBlend = new int[145];
		public static bool[] tileStone = new bool[314];
		public static bool[] tilePick = new bool[314];
		public static bool[] tileAxe = new bool[314];
		public static bool[] tileHammer = new bool[314];
		public static bool[] tileWaterDeath = new bool[314];
		public static bool[] tileLavaDeath = new bool[314];
		public static bool[] tileTable = new bool[314];
		public static bool[] tileBlockLight = new bool[314];
		public static bool[] tileNoSunLight = new bool[314];
		public static bool[] tileDungeon = new bool[314];
		public static bool[] tileSolidTop = new bool[314];
		public static bool[] tileSolid = new bool[314];
		public static byte[] tileLargeFrames = new byte[314];
		public static bool[] tileRope = new bool[314];
		public static bool[] tileBrick = new bool[314];
		public static bool[] tileMoss = new bool[314];
		public static bool[] tileNoAttach = new bool[314];
		public static bool[] tileNoFail = new bool[314];
		public static bool[] tileObsidianKill = new bool[314];
		public static bool[] tileFrameImportant = new bool[314];
		public static int cageFrames = 25;
		public static bool critterCage = false;
		public static int[] bunnyCageFrame = new int[Main.cageFrames];
		public static int[] bunnyCageFrameCounter = new int[Main.cageFrames];
		public static int[] squirrelCageFrame = new int[Main.cageFrames];
		public static int[] squirrelCageFrameCounter = new int[Main.cageFrames];
		public static int[] mallardCageFrame = new int[Main.cageFrames];
		public static int[] mallardCageFrameCounter = new int[Main.cageFrames];
		public static int[] duckCageFrame = new int[Main.cageFrames];
		public static int[] duckCageFrameCounter = new int[Main.cageFrames];
		public static int[] birdCageFrame = new int[Main.cageFrames];
		public static int[] birdCageFrameCounter = new int[Main.cageFrames];
		public static int[] redBirdCageFrame = new int[Main.cageFrames];
		public static int[] redBirdCageFrameCounter = new int[Main.cageFrames];
		public static int[] blueBirdCageFrame = new int[Main.cageFrames];
		public static int[] blueBirdCageFrameCounter = new int[Main.cageFrames];
		public static byte[,] butterflyCageMode = new byte[8, Main.cageFrames];
		public static int[,] butterflyCageFrame = new int[8, Main.cageFrames];
		public static int[,] butterflyCageFrameCounter = new int[8, Main.cageFrames];
		public static int[,] scorpionCageFrame = new int[2, Main.cageFrames];
		public static int[,] scorpionCageFrameCounter = new int[2, Main.cageFrames];
		public static int[] snailCageFrame = new int[Main.cageFrames];
		public static int[] snailCageFrameCounter = new int[Main.cageFrames];
		public static int[] snail2CageFrame = new int[Main.cageFrames];
		public static int[] snail2CageFrameCounter = new int[Main.cageFrames];
		public static byte[] fishBowlFrameMode = new byte[Main.cageFrames];
		public static int[] fishBowlFrame = new int[Main.cageFrames];
		public static int[] fishBowlFrameCounter = new int[Main.cageFrames];
		public static int[] frogCageFrame = new int[Main.cageFrames];
		public static int[] frogCageFrameCounter = new int[Main.cageFrames];
		public static int[] mouseCageFrame = new int[Main.cageFrames];
		public static int[] mouseCageFrameCounter = new int[Main.cageFrames];
		public static int[] wormCageFrame = new int[Main.cageFrames];
		public static int[] wormCageFrameCounter = new int[Main.cageFrames];
		public static int[] penguinCageFrame = new int[Main.cageFrames];
		public static int[] penguinCageFrameCounter = new int[Main.cageFrames];
		public static bool[] tileSand = new bool[314];
		public static bool[] tileFlame = new bool[314];
		public static bool[] npcCatchable = new bool[369];
		public static int[] tileFrame = new int[314];
		public static int[] tileFrameCounter = new int[314];
		public static byte[] wallFrame = new byte[145];
		public static byte[] wallFrameCounter = new byte[145];
		public static int[] backgroundWidth = new int[185];
		public static int[] backgroundHeight = new int[185];
		public static bool tilesLoaded = false;
		public static Tile[,] tile = new Tile[Main.maxTilesX, Main.maxTilesY];
		public static Dust[] dust = new Dust[6001];
		public static Star[] star = new Star[130];
		public static Item[] item = new Item[401];
		public static NPC[] npc = new NPC[201];
		public static Gore[] gore = new Gore[501];
		public static Rain[] rain = new Rain[Main.maxRain + 1];
		public static Projectile[] projectile = new Projectile[1001];
		public static Chest[] chest = new Chest[1000];
		public static Sign[] sign = new Sign[1000];
		public static Vector2 screenPosition;
		public static Vector2 screenLastPosition;
		public static int screenWidth = 1152;
		public static int screenHeight = 864;
		public static bool screenMaximized = false;
		public static int chatLength = 600;
		public static bool chatMode = false;
		public static bool chatRelease = false;
		public static int showCount = 10;
		public static int numChatLines = 500;
		public static int startChatLine = 0;
		public static string chatText = "";
		public static bool inputTextEnter = false;
		public static bool inputTextEscape = false;
		public static float[] hotbarScale = new float[]
		{
			1f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f
		};
		public static byte mouseTextColor = 0;
		public static int mouseTextColorChange = 1;
		public static bool mouseLeftRelease = false;
		public static bool mouseRightRelease = false;
		public static bool playerInventory = false;
		public static int stackSplit;
		public static int stackCounter = 0;
		public static int stackDelay = 7;
		public static int superFastStack = 0;
		public static Item mouseItem = new Item();
		public static Item guideItem = new Item();
		public static Item reforgeItem = new Item();
		private static float inventoryScale = 0.75f;
		public static bool hasFocus = true;
		public static bool recFastScroll = false;
		public static bool recBigList = false;
		public static int recStart = 0;
		public static Recipe[] recipe = new Recipe[Recipe.maxRecipes];
		public static int[] availableRecipe = new int[Recipe.maxRecipes];
		public static float[] availableRecipeY = new float[Recipe.maxRecipes];
		public static int numAvailableRecipes;
		public static int focusRecipe;
		public static int myPlayer = 0;
		public static Player[] player = new Player[256];
		public static int spawnTileX;
		public static int spawnTileY;
		public static bool npcChatRelease = false;
		public static bool editSign = false;
		public static bool editChest = false;
		public static bool blockInput = false;
		public static string defaultChestName = string.Empty;
		public static string signText = "";
		public static string npcChatText = "";
		public static bool npcChatFocus1 = false;
		public static bool npcChatFocus2 = false;
		public static bool npcChatFocus3 = false;
		public static int npcShop = 0;
		public static int numShops = 20;
		public Chest[] shop = new Chest[Main.numShops];
		public static int[] travelShop = new int[Chest.maxItems];
		public static bool craftGuide = false;
		public static bool reforge = false;
		private static Item toolTip = new Item();
		private static int backSpaceCount = 0;
		public static string motd = "";
		public static bool toggleFullscreen;
		public static int numDisplayModes = 0;
		public static int[] displayWidth = new int[99];
		public static int[] displayHeight = new int[99];
		public static bool gameMenu = true;
		private static int maxLoadPlayer = 1000;
		private static int maxLoadWorld = 1000;
		public static Player[] loadPlayer = new Player[Main.maxLoadPlayer];
		public static string[] loadPlayerPath = new string[Main.maxLoadPlayer];
		private static int numLoadPlayers = 0;
		public static string playerPathName;
		public static string[] loadWorld = new string[Main.maxLoadWorld];
		public static string[] loadWorldPath = new string[Main.maxLoadWorld];
		private static int numLoadWorlds = 0;
		public static string worldPathName;
		public static string SavePath = string.Concat(new object[]
		{
			Environment.GetFolderPath(Environment.SpecialFolder.Personal),
			Path.DirectorySeparatorChar,
			"My Games",
			Path.DirectorySeparatorChar,
			"Terraria"
		});
		public static string WorldPath = Main.SavePath + Path.DirectorySeparatorChar + "Worlds";
		public static string PlayerPath = Main.SavePath + Path.DirectorySeparatorChar + "Players";
		public static string[] itemName = new string[2289];
		public static string[] npcName = new string[369];
		public static int invasionType = 0;
		public static double invasionX = 0.0;
		public static int invasionSize = 0;
		public static int invasionDelay = 0;
		public static int invasionWarn = 0;
		public static int[] npcFrameCount = new int[]
		{
			1,
			2,
			2,
			3,
			6,
			2,
			2,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			16,
			14,
			16,
			14,
			15,
			16,
			2,
			10,
			1,
			16,
			16,
			16,
			3,
			1,
			15,
			3,
			1,
			3,
			1,
			1,
			16,
			16,
			1,
			1,
			1,
			3,
			3,
			15,
			3,
			7,
			7,
			4,
			5,
			5,
			5,
			3,
			3,
			16,
			6,
			3,
			6,
			6,
			2,
			5,
			3,
			2,
			7,
			7,
			4,
			2,
			8,
			1,
			5,
			1,
			2,
			4,
			16,
			5,
			4,
			4,
			15,
			15,
			15,
			15,
			2,
			4,
			6,
			6,
			24,
			16,
			1,
			1,
			1,
			1,
			1,
			1,
			4,
			3,
			1,
			1,
			1,
			1,
			1,
			1,
			5,
			6,
			7,
			16,
			1,
			1,
			16,
			16,
			12,
			20,
			21,
			1,
			2,
			2,
			3,
			6,
			1,
			1,
			1,
			15,
			4,
			11,
			1,
			14,
			6,
			6,
			3,
			1,
			2,
			2,
			1,
			3,
			4,
			1,
			2,
			1,
			4,
			2,
			1,
			15,
			3,
			16,
			4,
			5,
			7,
			3,
			2,
			12,
			12,
			4,
			4,
			4,
			8,
			8,
			9,
			2,
			6,
			4,
			15,
			16,
			3,
			3,
			8,
			5,
			4,
			3,
			15,
			12,
			4,
			14,
			14,
			3,
			2,
			5,
			3,
			2,
			3,
			14,
			5,
			14,
			16,
			5,
			2,
			2,
			12,
			3,
			3,
			3,
			3,
			2,
			2,
			2,
			2,
			2,
			7,
			14,
			15,
			16,
			8,
			3,
			15,
			15,
			15,
			2,
			3,
			20,
			16,
			14,
			16,
			4,
			4,
			16,
			16,
			20,
			20,
			20,
			2,
			2,
			2,
			2,
			8,
			12,
			3,
			4,
			2,
			4,
			16,
			16,
			15,
			6,
			3,
			3,
			3,
			3,
			3,
			3,
			4,
			4,
			5,
			4,
			6,
			7,
			15,
			4,
			7,
			6,
			1,
			1,
			2,
			4,
			3,
			5,
			3,
			3,
			3,
			4,
			5,
			6,
			4,
			2,
			1,
			8,
			4,
			4,
			1,
			8,
			1,
			4,
			15,
			15,
			15,
			15,
			15,
			15,
			15,
			15,
			15,
			15,
			15,
			15,
			3,
			3,
			3,
			3,
			3,
			3,
			15,
			3,
			6,
			12,
			20,
			20,
			20,
			15,
			15,
			15,
			5,
			5,
			6,
			6,
			5,
			2,
			7,
			2,
			6,
			6,
			6,
			6,
			6,
			15,
			15,
			15,
			15,
			15,
			11,
			4,
			2,
			2,
			3,
			3,
			3,
			15,
			15,
			15,
			10,
			14,
			12,
			1,
			10,
			8,
			3,
			3,
			2,
			2,
			2,
			2,
			7,
			15,
			15,
			15,
			6,
			3,
			10,
			10,
			6,
			9,
			8,
			9,
			8,
			20,
			10,
			6,
			14,
			1,
			4,
			24,
			2,
			4,
			6,
			6,
			10,
			15,
			15,
			15,
			15,
			4,
			4,
			16
		};
		private static bool mouseExit = false;
		private static float exitScale = 0.8f;
		private static bool mouseReforge = false;
		private static float reforgeScale = 0.8f;
		public static Player clientPlayer = new Player();
		public static string getIP = Main.defaultIP;
		public static string getPort = Convert.ToString(Netplay.serverPort);
		public static bool menuMultiplayer = false;
		public static bool menuServer = false;
		public static int netMode = 0;
		public static int timeOut = 120;
		public static int netPlayCounter;
		public static int lastNPCUpdate;
		public static int lastItemUpdate;
		public static int maxNPCUpdates = 5;
		public static int maxItemUpdates = 5;
		public static string cUp = "W";
		public static string cLeft = "A";
		public static string cDown = "S";
		public static string cRight = "D";
		public static string cJump = "Space";
		public static string cThrowItem = "T";
		public static string cHeal = "H";
		public static string cMana = "J";
		public static string cBuff = "B";
		public static string cHook = "E";
		public static string cTorch = "LeftShift";
		public static string cInv = "Escape";
		public static string cMapZoomIn = "Add";
		public static string cMapZoomOut = "Subtract";
		public static string cMapAlphaUp = "PageUp";
		public static string cMapAlphaDown = "PageDown";
		public static string cMapFull = "M";
		public static string cMapStyle = "Tab";
		public static Color mouseColor = new Color(255, 50, 95);
		public static Color cursorColor = Color.White;
		public static int cursorColorDirection = 1;
		public static float cursorAlpha = 0f;
		public static float cursorScale = 0f;
		public static bool signBubble = false;
		public static int signX = 0;
		public static int signY = 0;
		public static bool hideUI = false;
		public static bool releaseUI = false;
		public static bool fixedTiming = false;
		private int splashCounter;
		public static string oldStatusText = "";
		public static bool autoShutdown = false;
		public int a;
		public int b;
		public static float ambientWaterfallX = -1f;
		public static float ambientWaterfallY = -1f;
		public static float ambientWaterfallStrength = 0f;
		public static float ambientLavafallX = -1f;
		public static float ambientLavafallY = -1f;
		public static float ambientLavafallStrength = 0f;
		public static float ambientLavaX = -1f;
		public static float ambientLavaY = -1f;
		public static float ambientLavaStrength = 0f;
		public static int ambientCounter = 0;
		private float logoRotation;
		private float logoRotationDirection = 1f;
		private float logoRotationSpeed = 1f;
		private float logoScale = 1f;
		private float logoScaleDirection = 1f;
		private float logoScaleSpeed = 1f;
		private static int maxMenuItems = 14;
		private float[] menuItemScale = new float[Main.maxMenuItems];
		private int focusMenu = -1;
		private int selectedMenu = -1;
		private int selectedMenu2 = -1;
		private int selectedPlayer;
		private int selectedWorld;
		public static int menuMode = 0;
		public static int menuSkip = 0;
		private static Item cpItem = new Item();
		private int textBlinkerCount;
		private int textBlinkerState;
		public static string newWorldName = "";
		private static int dyeSlotCount = 0;
		private static int accSlotCount = 0;
		private static string hoverItemName = "";
		private static Color inventoryBack = new Color(220, 220, 220, 220);
		private static bool mouseText = false;
		private static int mH = 0;
		private static int sX = Main.screenWidth - 800;
		private static int starMana = 20;
		private static float heartLife = 20f;
		private static int rare = 0;
		private static int hairStart = 0;
		private static int oldHairStyle;
		private static Color oldHairColor;
		private static int selClothes = 0;
		private static Color[] oldClothesColor = new Color[4];
		public static int dresserX;
		public static int dresserY;
		public static Color selColor = Color.White;
		public static int focusColor = 0;
		public static int colorDelay = 0;
		public static int setKey = -1;
		public static int bgScroll = 0;
		public static bool autoPass = false;
		public static int menuFocus = 0;
		private static float hBar = -1f;
		private static float sBar = -1f;
		private static float lBar = 1f;
		private int grabColorSlider;
		public static bool blockMouse = false;
		private bool[] menuWide = new bool[100];
		private static float tranSpeed = 0.05f;
		private static float atmo = 0f;
		private static float bgScale = 1f;
		private static int bgW = (int)(1024f * Main.bgScale);
		private static Color backColor = Color.White;
		private static Color trueBackColor = Main.backColor;
		private float screenOff;
		private float scAdj;
		private float cTop;
		public static bool runningMono = false;
		public static bool forceUpdate = false;
		[DllImport("User32")]
		private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
		[DllImport("User32")]
		private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
		[DllImport("User32")]
		private static extern int GetMenuItemCount(IntPtr hWnd);
		[DllImport("kernel32.dll")]
		public static extern IntPtr LoadLibrary(string dllToLoad);
		public static void LoadWorlds()
		{
			Directory.CreateDirectory(Main.WorldPath);
			string[] files = Directory.GetFiles(Main.WorldPath, "*.wld");
			int num = files.Length;
			if (!Main.dedServ && num > Main.maxLoadWorld)
			{
				num = Main.maxLoadWorld;
			}
			for (int i = 0; i < num; i++)
			{
				Main.loadWorldPath[i] = files[i];
				Main.loadWorld[i] = WorldFile.GetWorldName(Main.loadWorldPath[i]);
			}
			Main.numLoadWorlds = num;
		}
		public static void SaveRecent()
		{
			Directory.CreateDirectory(Main.SavePath);
			try
			{
				File.SetAttributes(Main.SavePath + Path.DirectorySeparatorChar + "servers.dat", FileAttributes.Normal);
			}
			catch
			{
			}
			try
			{
				using (FileStream fileStream = new FileStream(Main.SavePath + Path.DirectorySeparatorChar + "servers.dat", FileMode.Create))
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
			catch
			{
			}
		}
		private static void EraseWorld(int i)
		{
			try
			{
				File.Delete(Main.loadWorldPath[i]);
				File.Delete(Main.loadWorldPath[i] + ".bak");
				Main.LoadWorlds();
			}
			catch
			{
			}
		}
		private static string getWorldPathName(string worldName)
		{
			string text = "";
			for (int i = 0; i < worldName.Length; i++)
			{
				string text2 = worldName.Substring(i, 1);
				string str;
				if (text2 == "a" || text2 == "b" || text2 == "c" || text2 == "d" || text2 == "e" || text2 == "f" || text2 == "g" || text2 == "h" || text2 == "i" || text2 == "j" || text2 == "k" || text2 == "l" || text2 == "m" || text2 == "n" || text2 == "o" || text2 == "p" || text2 == "q" || text2 == "r" || text2 == "s" || text2 == "t" || text2 == "u" || text2 == "v" || text2 == "w" || text2 == "x" || text2 == "y" || text2 == "z" || text2 == "A" || text2 == "B" || text2 == "C" || text2 == "D" || text2 == "E" || text2 == "F" || text2 == "G" || text2 == "H" || text2 == "I" || text2 == "J" || text2 == "K" || text2 == "L" || text2 == "M" || text2 == "N" || text2 == "O" || text2 == "P" || text2 == "Q" || text2 == "R" || text2 == "S" || text2 == "T" || text2 == "U" || text2 == "V" || text2 == "W" || text2 == "X" || text2 == "Y" || text2 == "Z" || text2 == "1" || text2 == "2" || text2 == "3" || text2 == "4" || text2 == "5" || text2 == "6" || text2 == "7" || text2 == "8" || text2 == "9" || text2 == "0")
				{
					str = text2;
				}
				else if (text2 == " ")
				{
					str = "_";
				}
				else
				{
					str = "-";
				}
				text += str;
			}
			if (File.Exists(string.Concat(new object[]
			{
				Main.WorldPath,
				Path.DirectorySeparatorChar,
				text,
				".wld"
			})))
			{
				int num = 2;
				while (File.Exists(string.Concat(new object[]
				{
					Main.WorldPath,
					Path.DirectorySeparatorChar,
					text,
					num,
					".wld"
				})))
				{
					num++;
				}
				text += num;
			}
			return string.Concat(new object[]
			{
				Main.WorldPath,
				Path.DirectorySeparatorChar,
				text,
				".wld"
			});
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
		public void NewMOTD(string newMOTD)
		{
			Main.motd = newMOTD;
		}
		public void LoadDedConfig(string configPath)
		{
			if (File.Exists(configPath))
			{
				using (StreamReader streamReader = new StreamReader(configPath))
				{
					string text;
					while ((text = streamReader.ReadLine()) != null)
					{
						try
						{
							if (text.Length > 6 && text.Substring(0, 6).ToLower() == "world=")
							{
								string text2 = text.Substring(6);
								Main.worldPathName = text2;
							}
							if (text.Length > 5 && text.Substring(0, 5).ToLower() == "port=")
							{
								string value = text.Substring(5);
								try
								{
									int serverPort = Convert.ToInt32(value);
									Netplay.serverPort = serverPort;
								}
								catch
								{
								}
							}
							if (text.Length > 11 && text.Substring(0, 11).ToLower() == "maxplayers=")
							{
								string value2 = text.Substring(11);
								try
								{
									int num = Convert.ToInt32(value2);
									Main.maxNetPlayers = num;
								}
								catch
								{
								}
							}
							if (text.Length > 11 && text.Substring(0, 9).ToLower() == "priority=")
							{
								string value3 = text.Substring(9);
								try
								{
									int num2 = Convert.ToInt32(value3);
									if (num2 >= 0 && num2 <= 5)
									{
										Process currentProcess = Process.GetCurrentProcess();
										if (num2 == 0)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.RealTime;
										}
										else if (num2 == 1)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.High;
										}
										else if (num2 == 2)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.AboveNormal;
										}
										else if (num2 == 3)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.Normal;
										}
										else if (num2 == 4)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.BelowNormal;
										}
										else if (num2 == 5)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.Idle;
										}
									}
								}
								catch
								{
								}
							}
							if (text.Length > 9 && text.Substring(0, 9).ToLower() == "password=")
							{
								string password = text.Substring(9);
								Netplay.password = password;
							}
							if (text.Length > 5 && text.Substring(0, 5).ToLower() == "motd=")
							{
								string text3 = text.Substring(5);
								Main.motd = text3;
							}
							if (text.Length > 5 && text.Substring(0, 5).ToLower() == "lang=")
							{
								string value4 = text.Substring(5);
								Lang.lang = Convert.ToInt32(value4);
							}
							if (text.Length >= 10 && text.Substring(0, 10).ToLower() == "worldpath=")
							{
								string worldPath = text.Substring(10);
								Main.WorldPath = worldPath;
							}
							if (text.Length >= 10 && text.Substring(0, 10).ToLower() == "worldname=")
							{
								string text4 = text.Substring(10);
								Main.worldName = text4;
							}
							if (text.Length > 8 && text.Substring(0, 8).ToLower() == "banlist=")
							{
								string banFile = text.Substring(8);
								Netplay.banFile = banFile;
							}
							if (text.Length > 11 && text.Substring(0, 11).ToLower() == "autocreate=")
							{
								string text5 = text.Substring(11);
								if (text5 == "0")
								{
									Main.autoGen = false;
								}
								else if (text5 == "1")
								{
									Main.maxTilesX = 4200;
									Main.maxTilesY = 1200;
									Main.autoGen = true;
								}
								else if (text5 == "2")
								{
									Main.maxTilesX = 6300;
									Main.maxTilesY = 1800;
									Main.autoGen = true;
								}
								else if (text5 == "3")
								{
									Main.maxTilesX = 8400;
									Main.maxTilesY = 2400;
									Main.autoGen = true;
								}
							}
							if (text.Length > 7 && text.Substring(0, 7).ToLower() == "secure=")
							{
								string text6 = text.Substring(7);
								if (text6 == "1")
								{
									Netplay.spamCheck = true;
								}
							}
							if (text.Length > 5 && text.Substring(0, 5).ToLower() == "upnp=")
							{
								string text7 = text.Substring(5);
								if (text7 != "1")
								{
									Netplay.uPNP = false;
								}
							}
							if (text.Length > 5 && text.Substring(0, 10).ToLower() == "npcstream=")
							{
								string value5 = text.Substring(10);
								try
								{
									int num3 = Convert.ToInt32(value5);
									Main.npcStreamSpeed = num3;
								}
								catch
								{
								}
							}
						}
						catch
						{
						}
					}
				}
			}
		}
		public void SetNetPlayers(int mPlayers)
		{
			Main.maxNetPlayers = mPlayers;
		}
		public void SetWorld(string wrold)
		{
			Main.worldPathName = wrold;
		}
		public void SetWorldName(string wrold)
		{
			Main.worldName = wrold;
		}
		public void autoShut()
		{
			Main.autoShutdown = true;
		}
		[DllImport("user32.dll")]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
		[DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		public void AutoPass()
		{
			Main.autoPass = true;
		}
		public void AutoJoin(string IP)
		{
			Main.defaultIP = IP;
			Main.getIP = IP;
			Netplay.SetIP(Main.defaultIP);
			Main.autoJoin = true;
		}
		public void AutoHost()
		{
			Main.menuMultiplayer = true;
			Main.menuServer = true;
			Main.menuMode = 1;
		}
		public void loadLib(string path)
		{
			Main.libPath = path;
			Main.LoadLibrary(Main.libPath);
		}
		public void DedServ()
		{
			Type t = Type.GetType("Mono.Runtime");
			Main.runningMono = (t != null);
			ServerApi.Hooks.InvokeGameInitialize();
			Main.rand = new Random();
			if (Main.autoShutdown)
			{
				string text = "terraria" + Main.rand.Next(2147483647);
				Console.Title = text;
				IntPtr intPtr = Main.FindWindow(null, text);
				if (intPtr != IntPtr.Zero)
				{
					Main.ShowWindow(intPtr, 0);
				}
			}
			else
			{
				Console.Title = "Terraria Server " + Main.versionNumber2;
			}
			Main.dedServ = true;
			Main.showSplash = false;
			this.Initialize();
			Lang.setLang(false);
			for (int i = 0; i < 369; i++)
			{
				NPC nPC = new NPC();
				nPC.SetDefaults(i, -1f);
				Main.npcName[i] = nPC.name;
			}
			while (Main.worldPathName == null || Main.worldPathName == "")
			{
				Main.LoadWorlds();
				bool flag = true;
				while (flag)
				{
					Console.WriteLine("Terraria Server " + Main.versionNumber2);
					Console.WriteLine("");
					for (int j = 0; j < Main.numLoadWorlds; j++)
					{
						Console.WriteLine(string.Concat(new object[]
						{
							j + 1,
							'\t',
							'\t',
							Main.loadWorld[j]
						}));
					}
					Console.WriteLine(string.Concat(new object[]
					{
						"n",
						'\t',
						'\t',
						"New World"
					}));
					Console.WriteLine("d <number>" + '\t' + "Delete World");
					Console.WriteLine("");
					Console.Write("Choose World: ");
					string text2 = Console.ReadLine();
					try
					{
						Console.Clear();
					}
					catch
					{
					}
					if (text2.Length >= 2 && text2.Substring(0, 2).ToLower() == "d ")
					{
						try
						{
							int num = Convert.ToInt32(text2.Substring(2)) - 1;
							if (num < Main.numLoadWorlds)
							{
								Console.WriteLine("Terraria Server " + Main.versionNumber2);
								Console.WriteLine("");
								Console.WriteLine("Really delete " + Main.loadWorld[num] + "?");
								Console.Write("(y/n): ");
								string text3 = Console.ReadLine();
								if (text3.ToLower() == "y")
								{
									Main.EraseWorld(num);
								}
							}
						}
						catch
						{
						}
						try
						{
							Console.Clear();
							continue;
						}
						catch
						{
							continue;
						}
					}
					if (text2 == "n" || text2 == "N")
					{
						bool flag2 = true;
						while (flag2)
						{
							Console.WriteLine("Terraria Server " + Main.versionNumber2);
							Console.WriteLine("");
							Console.WriteLine("1" + '\t' + "Small");
							Console.WriteLine("2" + '\t' + "Medium");
							Console.WriteLine("3" + '\t' + "Large");
							Console.WriteLine("");
							Console.Write("Choose size: ");
							string value = Console.ReadLine();
							try
							{
								int num2 = Convert.ToInt32(value);
								if (num2 == 1)
								{
									Main.maxTilesX = 4200;
									Main.maxTilesY = 1200;
									flag2 = false;
								}
								else if (num2 == 2)
								{
									Main.maxTilesX = 6400;
									Main.maxTilesY = 1800;
									flag2 = false;
								}
								else if (num2 == 3)
								{
									Main.maxTilesX = 8400;
									Main.maxTilesY = 2400;
									flag2 = false;
								}
							}
							catch
							{
							}
							try
							{
								Console.Clear();
							}
							catch
							{
							}
						}
						flag2 = true;
						while (flag2)
						{
							Console.WriteLine("Terraria Server " + Main.versionNumber2);
							Console.WriteLine("");
							Console.Write("Enter world name: ");
							Main.newWorldName = Console.ReadLine();
							if (Main.newWorldName != "" && Main.newWorldName != " " && Main.newWorldName != null)
							{
								flag2 = false;
							}
							try
							{
								Console.Clear();
							}
							catch
							{
							}
						}
						Main.worldName = Main.newWorldName;
						Main.worldPathName = Main.getWorldPathName(Main.worldName);
						Main.menuMode = 10;
						WorldGen.CreateNewWorld();
						flag2 = false;
						while (Main.menuMode == 10)
						{
							if (Main.oldStatusText != Main.statusText)
							{
								Main.oldStatusText = Main.statusText;
								Console.WriteLine(Main.statusText);
							}
						}
						try
						{
							Console.Clear();
							continue;
						}
						catch
						{
							continue;
						}
					}
					try
					{
						int num3 = Convert.ToInt32(text2);
						num3--;
						if (num3 >= 0 && num3 < Main.numLoadWorlds)
						{
							bool flag3 = true;
							while (flag3)
							{
								Console.WriteLine("Terraria Server " + Main.versionNumber2);
								Console.WriteLine("");
								Console.Write("Server port (press enter for 7777): ");
								string value3 = Console.ReadLine();
								try
								{
									if (value3 == "")
									{
										value3 = "7777";
									}
									int num5 = Convert.ToInt32(value3);
									if (num5 <= 65535)
									{
										Netplay.serverPort = num5;
										flag3 = false;
									}
								}
								catch
								{
								}
								try
								{
									Console.Clear();
								}
								catch
								{
								}
							}
							Main.worldPathName = Main.loadWorldPath[num3];
							flag = false;
							try
							{
								Console.Clear();
							}
							catch
							{
							}
						}
					}
					catch
					{
					}
				}
			}
			try
			{
				Console.Clear();
			}
			catch
			{
			}
			WorldGen.serverLoadWorld();
			Console.WriteLine("Terraria Server " + Main.versionNumber);
			Console.WriteLine("");
			while (!Netplay.ServerUp)
			{
				if (Main.oldStatusText != Main.statusText)
				{
					Main.oldStatusText = Main.statusText;
					Console.WriteLine(Main.statusText);
				}
			}
			try
			{
				Console.Clear();
			}
			catch
			{
			}
			Console.WriteLine("Terraria Server " + Main.versionNumber);
			Console.WriteLine("");
			Console.WriteLine("Listening on port " + Netplay.serverPort);
			Console.WriteLine("Type 'help' for a list of commands.");
			Console.WriteLine("");
			Console.Title = "Terraria Server: " + Main.worldName;
			Stopwatch stopwatch = new Stopwatch();
			if (!Main.autoShutdown)
			{
				Main.startDedInput();
			}
			ServerApi.Hooks.InvokeGamePostInitialize();
			stopwatch.Start();
			double num6 = 16.666666666666668;
			double num7 = 0.0;
			int num8 = 0;
			Stopwatch stopwatch2 = new Stopwatch();
			stopwatch2.Start();
			while (!Netplay.disconnect)
			{
				double num9 = (double)stopwatch.ElapsedMilliseconds;
				if (num9 + num7 >= num6)
				{
					num8++;
					num7 += num9 - num6;
					stopwatch.Reset();
					stopwatch.Start();
					if (Main.oldStatusText != Main.statusText)
					{
						Main.oldStatusText = Main.statusText;
						Console.WriteLine(Main.statusText);
					}
					if (Netplay.anyClients || forceUpdate)
					{
						ServerApi.Hooks.InvokeGameUpdate();
						this.Update();
						ServerApi.Hooks.InvokeGamePostUpdate();
					}
					double num10 = (double)stopwatch.ElapsedMilliseconds + num7;
					if (num10 < num6)
					{
						int num11 = (int)(num6 - num10) - 1;
						if (num11 > 1)
						{
							Thread.Sleep(num11 - 1);
							if (!Netplay.anyClients)
							{
								num7 = 0.0;
								Thread.Sleep(10);
							}
						}
					}
				}
				Thread.Sleep(0);
			}
		}
		public static void startDedInput()
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(Main.startDedInputCallBack), 1);
		}
		public static void startDedInputCallBack(object threadContext)
		{
			while (!Netplay.disconnect)
			{
				Console.Write(": ");
				string text = Console.ReadLine();
				string text2 = text;
				text = text.ToLower();
				if (!ServerApi.Hooks.InvokeServerCommand(text2))
				{
				try
				{
					if (text == "help")
					{
						Console.WriteLine("Available commands:");
						Console.WriteLine("");
						Console.WriteLine(string.Concat(new object[]
						{
							"help ",
							'\t',
							'\t',
							" Displays a list of commands."
						}));
						Console.WriteLine("playing " + '\t' + " Shows the list of players");
						Console.WriteLine(string.Concat(new object[]
						{
							"clear ",
							'\t',
							'\t',
							" Clear the console window."
						}));
						Console.WriteLine(string.Concat(new object[]
						{
							"exit ",
							'\t',
							'\t',
							" Shutdown the server and save."
						}));
						Console.WriteLine("exit-nosave " + '\t' + " Shutdown the server without saving.");
						Console.WriteLine(string.Concat(new object[]
						{
							"save ",
							'\t',
							'\t',
							" Save the game world."
						}));
						Console.WriteLine("kick <player> " + '\t' + " Kicks a player from the server.");
						Console.WriteLine("ban <player> " + '\t' + " Bans a player from the server.");
						Console.WriteLine("password" + '\t' + " Show password.");
						Console.WriteLine("password <pass>" + '\t' + " Change password.");
						Console.WriteLine(string.Concat(new object[]
						{
							"version",
							'\t',
							'\t',
							" Print version number."
						}));
						Console.WriteLine(string.Concat(new object[]
						{
							"time",
							'\t',
							'\t',
							" Display game time."
						}));
						Console.WriteLine(string.Concat(new object[]
						{
							"port",
							'\t',
							'\t',
							" Print the listening port."
						}));
						Console.WriteLine("maxplayers" + '\t' + " Print the max number of players.");
						Console.WriteLine("say <words>" + '\t' + " Send a message.");
						Console.WriteLine(string.Concat(new object[]
						{
							"motd",
							'\t',
							'\t',
							" Print MOTD."
						}));
						Console.WriteLine("motd <words>" + '\t' + " Change MOTD.");
						Console.WriteLine(string.Concat(new object[]
						{
							"dawn",
							'\t',
							'\t',
							" Change time to dawn."
						}));
						Console.WriteLine(string.Concat(new object[]
						{
							"noon",
							'\t',
							'\t',
							" Change time to noon."
						}));
						Console.WriteLine(string.Concat(new object[]
						{
							"dusk",
							'\t',
							'\t',
							" Change time to dusk."
						}));
						Console.WriteLine("midnight" + '\t' + " Change time to midnight.");
						Console.WriteLine(string.Concat(new object[]
						{
							"settle",
							'\t',
							'\t',
							" Settle all water."
						}));
					}
					else if (text == "settle")
					{
						if (!Liquid.panicMode)
						{
							Liquid.StartPanic();
						}
						else
						{
							Console.WriteLine("Water is already settling");
						}
					}
					else if (text == "dawn")
					{
						Main.dayTime = true;
						Main.time = 0.0;
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
					}
					else if (text == "dusk")
					{
						Main.dayTime = false;
						Main.time = 0.0;
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
					}
					else if (text == "noon")
					{
						Main.dayTime = true;
						Main.time = 27000.0;
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
					}
					else if (text == "midnight")
					{
						Main.dayTime = false;
						Main.time = 16200.0;
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
					}
					else if (text == "exit-nosave")
					{
						Netplay.disconnect = true;
					}
					else if (text == "exit")
					{
						WorldFile.saveWorld(false);
						Netplay.disconnect = true;
					}
					else if (text == "fps")
					{
						if (!Main.dedServFPS)
						{
							Main.dedServFPS = true;
							Main.fpsTimer.Reset();
						}
						else
						{
							Main.dedServCount1 = 0;
							Main.dedServCount2 = 0;
							Main.dedServFPS = false;
						}
					}
					else if (text == "save")
					{
						WorldFile.saveWorld(false);
					}
					else if (text == "time")
					{
						string text3 = "AM";
						double num = Main.time;
						if (!Main.dayTime)
						{
							num += 54000.0;
						}
						num = num / 86400.0 * 24.0;
						double num2 = 7.5;
						num = num - num2 - 12.0;
						if (num < 0.0)
						{
							num += 24.0;
						}
						if (num >= 12.0)
						{
							text3 = "PM";
						}
						int num3 = (int)num;
						double num4 = num - (double)num3;
						num4 = (double)((int)(num4 * 60.0));
						string text4 = string.Concat(num4);
						if (num4 < 10.0)
						{
							text4 = "0" + text4;
						}
						if (num3 > 12)
						{
							num3 -= 12;
						}
						if (num3 == 0)
						{
							num3 = 12;
						}
						Console.WriteLine(string.Concat(new object[]
						{
							"Time: ",
							num3,
							":",
							text4,
							" ",
							text3
						}));
					}
					else if (text == "maxplayers")
					{
						Console.WriteLine("Player limit: " + Main.maxNetPlayers);
					}
					else if (text == "port")
					{
						Console.WriteLine("Port: " + Netplay.serverPort);
					}
					else if (text == "version")
					{
						Console.WriteLine("Terraria Server " + Main.versionNumber);
					}
					else
					{
						if (text == "clear")
						{
							try
							{
								Console.Clear();
								continue;
							}
							catch
							{
								continue;
							}
						}
						if (text == "playing")
						{
							int num5 = 0;
							for (int i = 0; i < 255; i++)
							{
								if (Main.player[i].active)
								{
									num5++;
									Console.WriteLine(string.Concat(new object[]
									{
										Main.player[i].name,
										" (",
										Netplay.serverSock[i].tcpClient.Client.RemoteEndPoint,
										")"
									}));
								}
							}
							if (num5 == 0)
							{
								Console.WriteLine("No players connected.");
							}
							else if (num5 == 1)
							{
								Console.WriteLine("1 player connected.");
							}
							else
							{
								Console.WriteLine(num5 + " players connected.");
							}
						}
						else if (!(text == ""))
						{
							if (text == "motd")
							{
								if (Main.motd == "")
								{
									Console.WriteLine("Welcome to " + Main.worldName + "!");
								}
								else
								{
									Console.WriteLine("MOTD: " + Main.motd);
								}
							}
							else if (text.Length >= 5 && text.Substring(0, 5) == "motd ")
							{
								string text5 = text2.Substring(5);
								Main.motd = text5;
							}
							else if (text.Length == 8 && text.Substring(0, 8) == "password")
							{
								if (Netplay.password == "")
								{
									Console.WriteLine("No password set.");
								}
								else
								{
									Console.WriteLine("Password: " + Netplay.password);
								}
							}
							else if (text.Length >= 9 && text.Substring(0, 9) == "password ")
							{
								string password = text2.Substring(9);
								if (password == "")
								{
									Netplay.password = "";
									Console.WriteLine("Password disabled.");
								}
								else
								{
									Netplay.password = password;
									Console.WriteLine("Password: " + Netplay.password);
								}
							}
							else if (text == "say")
							{
								Console.WriteLine("Usage: say <words>");
							}
							else if (text.Length >= 4 && text.Substring(0, 4) == "say ")
							{
								string str = text2.Substring(4);
								if (str == "")
								{
									Console.WriteLine("Usage: say <words>");
								}
								else
								{
									Console.WriteLine("<Server> " + str);
									NetMessage.SendData(25, -1, -1, "<Server> " + str, 255, 255f, 240f, 20f, 0);
								}
							}
							else if (text.Length == 4 && text.Substring(0, 4) == "kick")
							{
								Console.WriteLine("Usage: kick <player>");
							}
							else if (text.Length >= 5 && text.Substring(0, 5) == "kick ")
							{
								string text6 = text.Substring(5);
								text6 = text6.ToLower();
								if (text6 == "")
								{
									Console.WriteLine("Usage: kick <player>");
								}
								else
								{
									for (int j = 0; j < 255; j++)
									{
										if (Main.player[j].active && Main.player[j].name.ToLower() == text6)
										{
											NetMessage.SendData(2, j, -1, "Kicked from server.", 0, 0f, 0f, 0f, 0);
										}
									}
								}
							}
							else if (text.Length == 3 && text.Substring(0, 3) == "ban")
							{
								Console.WriteLine("Usage: ban <player>");
							}
							else if (text.Length >= 4 && text.Substring(0, 4) == "ban ")
							{
								string text7 = text.Substring(4);
								text7 = text7.ToLower();
								if (text7 == "")
								{
									Console.WriteLine("Usage: ban <player>");
								}
								else
								{
									for (int k = 0; k < 255; k++)
									{
										if (Main.player[k].active && Main.player[k].name.ToLower() == text7)
										{
											Netplay.AddBan(k);
											NetMessage.SendData(2, k, -1, "Banned from server.", 0, 0f, 0f, 0f, 0);
										}
									}
								}
							}
							else
							{
								Console.WriteLine("Invalid command.");
							}
						}
					}
				}
				catch
				{
					Console.WriteLine("Invalid command.");
				}
			}}
		}
		public void Initialize()
		{
			Chest.Initialize();
			WorldGen.randomBackgrounds();
			WorldGen.setCaveBacks();
			WorldGen.randMoon();
			Main.bgAlpha[0] = 1f;
			Main.bgAlpha2[0] = 1f;
			this.invBottom = 258;
			for (int i = 0; i < 360; i++)
			{
				Main.projFrames[i] = 1;
			}
			Main.projFrames[334] = 11;
			Main.projFrames[324] = 10;
			Main.projFrames[351] = 2;
			Main.projFrames[349] = 5;
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
			Main.tileLighted[237] = true;
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
			Main.pvpBuff[20] = true;
			Main.pvpBuff[24] = true;
			Main.pvpBuff[31] = true;
			Main.pvpBuff[39] = true;
			Main.pvpBuff[44] = true;
			Main.pvpBuff[20] = true;
			Main.pvpBuff[69] = true;
			Main.pvpBuff[103] = true;
			Main.meleeBuff[71] = true;
			Main.meleeBuff[73] = true;
			Main.meleeBuff[74] = true;
			Main.meleeBuff[75] = true;
			Main.meleeBuff[76] = true;
			Main.meleeBuff[77] = true;
			Main.meleeBuff[78] = true;
			Main.meleeBuff[79] = true;
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
			Main.vanityPet[65] = true;
			Main.vanityPet[66] = true;
			Main.vanityPet[81] = true;
			Main.vanityPet[82] = true;
			Main.vanityPet[84] = true;
			Main.vanityPet[85] = true;
			Main.vanityPet[91] = true;
			Main.vanityPet[92] = true;
			Main.lightPet[19] = true;
			Main.lightPet[27] = true;
			Main.lightPet[57] = true;
			Main.lightPet[101] = true;
			Main.lightPet[102] = true;
			Main.tileFlame[4] = true;
			Main.tileFlame[33] = true;
			Main.tileFlame[34] = true;
			Main.tileFlame[35] = true;
			Main.tileFlame[49] = true;
			Main.tileFlame[93] = true;
			Main.tileFlame[98] = true;
			Main.tileFlame[100] = true;
			Main.tileFlame[173] = true;
			Main.tileFlame[174] = true;
			Main.tileRope[213] = true;
			Main.tileRope[214] = true;
			for (int j = 0; j < 369; j++)
			{
				Main.npcCatchable[j] = false;
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
			Main.tileSolid[232] = true;
			Main.tileSolid[311] = true;
			Main.tileSolid[312] = true;
			Main.tileSolid[313] = true;
			Main.tileMergeDirt[311] = true;
			Main.tileShine[239] = 1100;
			Main.tileSolid[239] = true;
			Main.tileSolidTop[239] = true;
			Main.tileFrameImportant[300] = true;
			Main.tileFrameImportant[301] = true;
			Main.tileFrameImportant[302] = true;
			Main.tileFrameImportant[303] = true;
			Main.tileFrameImportant[304] = true;
			Main.tileFrameImportant[305] = true;
			Main.tileFrameImportant[306] = true;
			Main.tileFrameImportant[307] = true;
			Main.tileFrameImportant[308] = true;
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
			Main.tileLargeFrames[284] = 1;
			Main.tileSolid[284] = true;
			Main.tileBlockLight[284] = true;
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
			Main.tileFrameImportant[309] = true;
			Main.tileFrameImportant[310] = true;
			Main.tileLighted[286] = true;
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
			for (int k = 255; k <= 268; k++)
			{
				Main.tileSolid[k] = true;
				if (k > 261)
				{
					Main.tileLighted[k] = true;
					Main.tileShine2[k] = true;
				}
			}
			Main.tileFrameImportant[269] = true;
			Main.wallHouse[142] = true;
			Main.wallHouse[143] = true;
			Main.wallHouse[144] = true;
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
			for (int l = 0; l < 145; l++)
			{
				Main.wallDungeon[l] = false;
			}
			Main.wallLight[0] = true;
			Main.wallLight[21] = true;
			Main.wallLight[106] = true;
			Main.wallLight[107] = true;
			Main.wallDungeon[7] = true;
			Main.wallDungeon[8] = true;
			Main.wallDungeon[9] = true;
			Main.wallDungeon[94] = true;
			Main.wallDungeon[95] = true;
			Main.wallDungeon[96] = true;
			Main.wallDungeon[97] = true;
			Main.wallDungeon[98] = true;
			Main.wallDungeon[99] = true;
			for (int m = 0; m < 10; m++)
			{
				Main.recentWorld[m] = "";
				Main.recentIP[m] = "";
				Main.recentPort[m] = 0;
			}
			if (Main.rand == null)
			{
				Main.rand = new Random((int)DateTime.Now.Ticks);
			}
			if (WorldGen.genRand == null)
			{
				WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
			}
			Main.lo = Main.rand.Next(6);
			Main.critterCage = true;
			for (int n = 0; n < 3600; n++)
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
			Main.tileNoFail[129] = true;
			Main.tileNoFail[192] = true;
			Main.tileHammer[26] = true;
			Main.tileHammer[31] = true;
			Main.tileAxe[5] = true;
			Main.tileAxe[72] = true;
			Main.tileAxe[80] = true;
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
			Main.tileFrameImportant[141] = true;
			Main.tileFrameImportant[270] = true;
			Main.tileFrameImportant[271] = true;
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
			for (int num = 0; num < 314; num++)
			{
				if (Main.tileLavaDeath[num])
				{
					Main.tileObsidianKill[num] = true;
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
			for (int num2 = 0; num2 < 145; num2++)
			{
				if (num2 == 20)
				{
					Main.wallBlend[num2] = 14;
				}
				else if (num2 == 19)
				{
					Main.wallBlend[num2] = 9;
				}
				else if (num2 == 18)
				{
					Main.wallBlend[num2] = 8;
				}
				else if (num2 == 17)
				{
					Main.wallBlend[num2] = 7;
				}
				else if (num2 == 16 || num2 == 59)
				{
					Main.wallBlend[num2] = 2;
				}
				else if (num2 == 1 || (num2 >= 48 && num2 <= 53))
				{
					Main.wallBlend[num2] = 1;
				}
				else
				{
					Main.wallBlend[num2] = num2;
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
			for (int num3 = 0; num3 < 314; num3++)
			{
				if (Main.tileSolid[num3])
				{
					Main.tileNoSunLight[num3] = true;
				}
				Main.tileFrame[num3] = 0;
				Main.tileFrameCounter[num3] = 0;
			}
			Main.tileNoSunLight[19] = false;
			Main.tileNoSunLight[11] = true;
			Main.tileNoSunLight[189] = false;
			Main.tileNoSunLight[196] = false;
			for (int num4 = 0; num4 < Main.maxMenuItems; num4++)
			{
				this.menuItemScale[num4] = 0.8f;
			}
			for (int num5 = 0; num5 < 6001; num5++)
			{
				Main.dust[num5] = new Dust();
			}
			for (int num6 = 0; num6 < 401; num6++)
			{
				Main.item[num6] = new Item();
			}
			for (int num7 = 0; num7 < 201; num7++)
			{
				Main.npc[num7] = new NPC();
				Main.npc[num7].whoAmI = num7;
			}
			for (int num8 = 0; num8 < 256; num8++)
			{
				Main.player[num8] = new Player();
			}
			for (int num9 = 0; num9 < 1001; num9++)
			{
				Main.projectile[num9] = new Projectile();
			}
			for (int num10 = 0; num10 < 501; num10++)
			{
				Main.gore[num10] = new Gore();
			}
			for (int num11 = 0; num11 < Main.maxRain + 1; num11++)
			{
				Main.rain[num11] = new Rain();
			}
			for (int num15 = 0; num15 < 2289; num15++)
			{
				Item item = new Item();
				item.SetDefaults(num15, false);
				Main.itemName[num15] = item.name;
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
			}
			for (int num16 = 0; num16 < Recipe.maxRecipes; num16++)
			{
				Main.recipe[num16] = new Recipe();
				Main.availableRecipeY[num16] = (float)(65 * num16);
			}
			Recipe.SetupRecipes();
			for (int num18 = 0; num18 < Liquid.resLiquid; num18++)
			{
				Main.liquid[num18] = new Liquid();
			}
			for (int num19 = 0; num19 < 10000; num19++)
			{
				Main.liquidBuffer[num19] = new LiquidBuffer();
			}
			this.shop[0] = new Chest(false);
			Chest.SetupTravelShop();
			for (int num20 = 1; num20 < Main.numShops; num20++)
			{
				this.shop[num20] = new Chest(false);
				this.shop[num20].SetupShop(num20);
			}
			Main.teamColor[0] = Color.White;
			Main.teamColor[1] = new Color(230, 40, 20);
			Main.teamColor[2] = new Color(20, 200, 30);
			Main.teamColor[3] = new Color(75, 90, 255);
			Main.teamColor[4] = new Color(200, 180, 0);
			for (int num21 = 1; num21 < 360; num21++)
			{
				Projectile projectile = new Projectile();
				projectile.SetDefaults(num21);
				if (projectile.hostile)
				{
					Main.projHostile[num21] = true;
				}
			}
			Netplay.Init();
			if (Main.skipMenu)
			{
				WorldGen.clearWorld();
				Main.gameMenu = false;
				Main.player[Main.myPlayer] = (Player)Main.loadPlayer[0].Clone();
				Main.PlayerPath = Main.loadPlayerPath[0];
				Main.LoadWorlds();
				WorldGen.generateWorld(-1);
				WorldGen.EveryTileFrame();
				Main.player[Main.myPlayer].Spawn();
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
		public static void startPumpkinMoon()
		{
			Main.pumpkinMoon = true;
			Main.snowMoon = false;
			Main.bloodMoon = false;
			if (Main.netMode != 1)
			{
				NPC.waveKills = 0f;
				NPC.waveCount = 1;
				string text = "First Wave: " + Main.npcName[305];
				if (Main.netMode == 0)
				{
					Main.NewText(text, 175, 75, 255, false);
					return;
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(25, -1, -1, text, 255, 175f, 75f, 255f, 0);
				}
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
				string text = "First Wave: Zombie Elf and Gingerbread Man";
				if (Main.netMode == 0)
				{
					Main.NewText(text, 175, 75, 255, false);
					return;
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(25, -1, -1, text, 255, 175f, 75f, 255f, 0);
				}
			}
		}
		public static void snowing()
		{
			if (Main.gamePaused)
			{
				return;
			}
			if (Main.snowTiles > 0 && (double)Main.player[Main.myPlayer].position.Y < Main.worldSurface * 16.0)
			{
				int maxValue = 800 / Main.snowTiles;
				float num = (float)Main.screenWidth / 1920f;
				int num2 = (int)(500f * num);
				num2 = (int)((float)num2 * (1f + 2f * Main.cloudAlpha));
				float num3 = 1f + 50f * Main.cloudAlpha;
				int num4 = 0;
				while ((float)num4 < num3)
				{
					try
					{
						if ((float)Main.snowDust >= (float)num2 * (Main.gfxQuality / 2f + 0.5f) + (float)num2 * 0.1f)
						{
							break;
						}
						if (Main.rand.Next(maxValue) == 0)
						{
							int num5 = Main.rand.Next(Main.screenWidth + 1000) - 500;
							int num6 = (int)Main.screenPosition.Y - Main.rand.Next(50);
							if (Main.player[Main.myPlayer].velocity.Y > 0f)
							{
								num6 -= (int)Main.player[Main.myPlayer].velocity.Y;
							}
							if (Main.rand.Next(5) == 0)
							{
								num5 = Main.rand.Next(500) - 500;
							}
							else if (Main.rand.Next(5) == 0)
							{
								num5 = Main.rand.Next(500) + Main.screenWidth;
							}
							if (num5 < 0 || num5 > Main.screenWidth)
							{
								num6 += Main.rand.Next((int)((double)Main.screenHeight * 0.5)) + (int)((double)Main.screenHeight * 0.1);
							}
							num5 += (int)Main.screenPosition.X;
							int num7 = num5 / 16;
							int num8 = num6 / 16;
							if (Main.tile[num7, num8] != null && Main.tile[num7, num8].wall == 0)
							{
								int num9 = Dust.NewDust(new Vector2((float)num5, (float)num6), 10, 10, 76, 0f, 0f, 0, default(Color), 1f);
								Main.dust[num9].scale += Main.cloudAlpha * 0.2f;
								Main.dust[num9].velocity.Y = 3f + (float)Main.rand.Next(30) * 0.1f;
								Dust expr_291_cp_0 = Main.dust[num9];
								expr_291_cp_0.velocity.Y = expr_291_cp_0.velocity.Y * Main.dust[num9].scale;
								Main.dust[num9].velocity.X = Main.windSpeed + (float)Main.rand.Next(-10, 10) * 0.1f;
								Dust expr_2E4_cp_0 = Main.dust[num9];
								expr_2E4_cp_0.velocity.X = expr_2E4_cp_0.velocity.X + Main.windSpeed * Main.cloudAlpha * 10f;
								Dust expr_30E_cp_0 = Main.dust[num9];
								expr_30E_cp_0.velocity.Y = expr_30E_cp_0.velocity.Y * (1f + 0.3f * Main.cloudAlpha);
								Main.dust[num9].scale += Main.cloudAlpha * 0.2f;
								Main.dust[num9].velocity *= 1f + Main.cloudAlpha * 0.5f;
							}
						}
					}
					catch
					{
					}
					num4++;
				}
			}
		}
		public static void checkXMas()
		{
			DateTime now = DateTime.Now;
			int day = now.Day;
			int month = now.Month;
			bool xmas = ((day >= 15) && (month == 12));

			ServerApi.Hooks.InvokeWorldChristmasCheck(ref xmas);

			Main.xMas = xmas;
		}
		public static void checkHalloween()
		{
			DateTime now = DateTime.Now;
			int day = now.Day;
			int month = now.Month;
			bool halloween = (((day >= 20) && (month == 10)) || ((day <= 10) && (month == 11)));

			ServerApi.Hooks.InvokeWorldHalloweenCheck(ref halloween);

			Main.halloween = halloween;
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
			int num2 = num / 24;
			float num3 = 1f + 4f * Main.cloudAlpha;
			if (Main.cloudBGActive > 0f)
			{
				if (Main.cloudBGActive > 1f)
				{
					Main.cloudBGActive -= (float)Main.dayRate / num3;
				}
				if (Main.cloudBGActive < 1f)
				{
					Main.cloudBGActive = 1f;
				}
				if (Main.cloudBGActive == 1f && Main.rand.Next((int)((float)(num2 * 2 / Main.dayRate) * num3)) == 0)
				{
					Main.cloudBGActive = (float)(-(float)Main.rand.Next(num2 * 4, num * 4));
					if (Main.netMode == 2)
					{
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
						return;
					}
				}
			}
			else
			{
				if (Main.cloudBGActive < 0f)
				{
					Main.cloudBGActive += (float)Main.dayRate * num3;
					if (Main.raining)
					{
						Main.cloudBGActive += (float)(2 * Main.dayRate) * num3;
					}
				}
				if (Main.cloudBGActive > 0f)
				{
					Main.cloudBGActive = 0f;
				}
				if (Main.cloudBGActive == 0f && Main.rand.Next((int)((float)(num2 * 8 / Main.dayRate) / num3)) == 0)
				{
					Main.cloudBGActive = (float)Main.rand.Next(num2 * 3, num * 2);
					if (Main.netMode == 2)
					{
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
					}
				}
			}
		}
		public static void TeleportEffect(Rectangle effectRect, int Style)
		{
			if (Style == 1)
			{
				Main.PlaySound(2, effectRect.X + effectRect.Width / 2, effectRect.Y + effectRect.Height / 2, 8);
				int num = effectRect.Width * effectRect.Height / 5;
				for (int i = 0; i < num; i++)
				{
					int num2 = Dust.NewDust(new Vector2((float)effectRect.X, (float)effectRect.Y), effectRect.Width, effectRect.Height, 164, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num2].scale = (float)Main.rand.Next(20, 70) * 0.01f;
					if (i < 10)
					{
						Main.dust[num2].scale += 0.25f;
					}
					if (i < 5)
					{
						Main.dust[num2].scale += 0.25f;
					}
				}
				return;
			}
			Main.PlaySound(2, effectRect.X + effectRect.Width / 2, effectRect.Y + effectRect.Height / 2, 6);
			int num3 = effectRect.Width * effectRect.Height / 5;
			for (int j = 0; j < num3; j++)
			{
				int num4 = Dust.NewDust(new Vector2((float)effectRect.X, (float)effectRect.Y), effectRect.Width, effectRect.Height, 159, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num4].scale = (float)Main.rand.Next(20, 70) * 0.01f;
				if (j < 10)
				{
					Main.dust[num4].scale += 0.25f;
				}
				if (j < 5)
				{
					Main.dust[num4].scale += 0.25f;
				}
			}
		}
		public static void Ambience()
		{
			Main.ambientCounter++;
			if (Main.ambientCounter >= 15)
			{
				Main.ambientCounter = 0;
				Main.PlaySound(34, (int)Main.ambientWaterfallX, (int)Main.ambientWaterfallY, (int)Main.ambientWaterfallStrength);
				float num = Math.Abs(Main.ambientLavaX - (Main.screenPosition.X + (float)(Main.screenWidth / 2))) + Math.Abs(Main.ambientLavaY - (Main.screenPosition.Y + (float)(Main.screenHeight / 2)));
				float num2 = Math.Abs(Main.ambientLavafallX - (Main.screenPosition.X + (float)(Main.screenWidth / 2))) + Math.Abs(Main.ambientLavafallY - (Main.screenPosition.Y + (float)(Main.screenHeight / 2)));
				float num3 = Main.ambientLavaX;
				float num4 = Main.ambientLavaY;
				if (num2 < num)
				{
					num3 = Main.ambientLavafallX;
					num4 = Main.ambientLavafallY;
				}
				float num5 = Main.ambientLavafallStrength + Main.ambientLavaStrength;
				Main.PlaySound(35, (int)num3, (int)num4, (int)num5);
			}
		}
		public unsafe static void CritterCages()
		{
			if (Main.critterCage)
			{
				for (int i = 0; i < Main.cageFrames; i++)
				{
					if (Main.bunnyCageFrame[i] == 0)
					{
						Main.bunnyCageFrameCounter[i]++;
						if (Main.bunnyCageFrameCounter[i] > Main.rand.Next(30, 900))
						{
							if (Main.rand.Next(3) != 0)
							{
								int num = Main.rand.Next(7);
								if (num == 0)
								{
									Main.bunnyCageFrame[i] = 4;
								}
								else if (num <= 2)
								{
									Main.bunnyCageFrame[i] = 2;
								}
								else
								{
									Main.bunnyCageFrame[i] = 1;
								}
							}
							Main.bunnyCageFrameCounter[i] = 0;
						}
					}
					else if (Main.bunnyCageFrame[i] == 1)
					{
						Main.bunnyCageFrameCounter[i]++;
						if (Main.bunnyCageFrameCounter[i] >= 10)
						{
							Main.bunnyCageFrameCounter[i] = 0;
							Main.bunnyCageFrame[i] = 0;
						}
					}
					else if (Main.bunnyCageFrame[i] >= 2 && Main.bunnyCageFrame[i] <= 3)
					{
						Main.bunnyCageFrameCounter[i]++;
						if (Main.bunnyCageFrameCounter[i] >= 10)
						{
							Main.bunnyCageFrameCounter[i] = 0;
							Main.bunnyCageFrame[i]++;
						}
						if (Main.bunnyCageFrame[i] > 3)
						{
							Main.bunnyCageFrame[i] = 0;
						}
					}
					else if (Main.bunnyCageFrame[i] >= 4 && Main.bunnyCageFrame[i] <= 10)
					{
						Main.bunnyCageFrameCounter[i]++;
						if (Main.bunnyCageFrameCounter[i] >= 5)
						{
							Main.bunnyCageFrameCounter[i] = 0;
							Main.bunnyCageFrame[i]++;
						}
					}
					else if (Main.bunnyCageFrame[i] == 11)
					{
						Main.bunnyCageFrameCounter[i]++;
						if (Main.bunnyCageFrameCounter[i] > Main.rand.Next(30, 900))
						{
							if (Main.rand.Next(3) != 0)
							{
								if (Main.rand.Next(7) == 0)
								{
									Main.bunnyCageFrame[i] = 13;
								}
								else
								{
									Main.bunnyCageFrame[i] = 12;
								}
							}
							Main.bunnyCageFrameCounter[i] = 0;
						}
					}
					else if (Main.bunnyCageFrame[i] == 12)
					{
						Main.bunnyCageFrameCounter[i]++;
						if (Main.bunnyCageFrameCounter[i] >= 10)
						{
							Main.bunnyCageFrameCounter[i] = 0;
							Main.bunnyCageFrame[i] = 11;
						}
					}
					else if (Main.bunnyCageFrame[i] >= 13)
					{
						Main.bunnyCageFrameCounter[i]++;
						if (Main.bunnyCageFrameCounter[i] >= 5)
						{
							Main.bunnyCageFrameCounter[i] = 0;
							Main.bunnyCageFrame[i]++;
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
						Main.squirrelCageFrameCounter[j]++;
						if (Main.squirrelCageFrameCounter[j] > Main.rand.Next(30, 900))
						{
							if (Main.rand.Next(3) != 0)
							{
								int num = Main.rand.Next(7);
								if (num == 0)
								{
									Main.squirrelCageFrame[j] = 4;
								}
								else if (num <= 2)
								{
									Main.squirrelCageFrame[j] = 2;
								}
								else
								{
									Main.squirrelCageFrame[j] = 1;
								}
							}
							Main.squirrelCageFrameCounter[j] = 0;
						}
					}
					else if (Main.squirrelCageFrame[j] == 1)
					{
						Main.squirrelCageFrameCounter[j]++;
						if (Main.squirrelCageFrameCounter[j] >= 10)
						{
							Main.squirrelCageFrameCounter[j] = 0;
							Main.squirrelCageFrame[j] = 0;
						}
					}
					else if (Main.squirrelCageFrame[j] >= 2 && Main.squirrelCageFrame[j] <= 3)
					{
						Main.squirrelCageFrameCounter[j]++;
						if (Main.squirrelCageFrameCounter[j] >= 5)
						{
							Main.squirrelCageFrameCounter[j] = 0;
							Main.squirrelCageFrame[j]++;
						}
						if (Main.squirrelCageFrame[j] > 3)
						{
							if (Main.rand.Next(5) == 0)
							{
								Main.squirrelCageFrame[j] = 0;
							}
							else
							{
								Main.squirrelCageFrame[j] = 2;
							}
						}
					}
					else if (Main.squirrelCageFrame[j] >= 4 && Main.squirrelCageFrame[j] <= 8)
					{
						Main.squirrelCageFrameCounter[j]++;
						if (Main.squirrelCageFrameCounter[j] >= 5)
						{
							Main.squirrelCageFrameCounter[j] = 0;
							Main.squirrelCageFrame[j]++;
						}
					}
					else if (Main.squirrelCageFrame[j] == 9)
					{
						Main.squirrelCageFrameCounter[j]++;
						if (Main.squirrelCageFrameCounter[j] > Main.rand.Next(30, 900))
						{
							if (Main.rand.Next(3) != 0)
							{
								int num = Main.rand.Next(7);
								if (num == 0)
								{
									Main.squirrelCageFrame[j] = 13;
								}
								else if (num <= 2)
								{
									Main.squirrelCageFrame[j] = 11;
								}
								else
								{
									Main.squirrelCageFrame[j] = 10;
								}
							}
							Main.squirrelCageFrameCounter[j] = 0;
						}
					}
					else if (Main.squirrelCageFrame[j] == 10)
					{
						Main.squirrelCageFrameCounter[j]++;
						if (Main.squirrelCageFrameCounter[j] >= 10)
						{
							Main.squirrelCageFrameCounter[j] = 0;
							Main.squirrelCageFrame[j] = 9;
						}
					}
					else if (Main.squirrelCageFrame[j] == 11 || Main.squirrelCageFrame[j] == 12)
					{
						Main.squirrelCageFrameCounter[j]++;
						if (Main.squirrelCageFrameCounter[j] >= 5)
						{
							Main.squirrelCageFrame[j]++;
							if (Main.squirrelCageFrame[j] > 12)
							{
								if (Main.rand.Next(5) != 0)
								{
									Main.squirrelCageFrame[j] = 11;
								}
								else
								{
									Main.squirrelCageFrame[j] = 9;
								}
							}
							Main.squirrelCageFrameCounter[j] = 0;
						}
					}
					else if (Main.squirrelCageFrame[j] >= 13)
					{
						Main.squirrelCageFrameCounter[j]++;
						if (Main.squirrelCageFrameCounter[j] >= 5)
						{
							Main.squirrelCageFrameCounter[j] = 0;
							Main.squirrelCageFrame[j]++;
						}
						if (Main.squirrelCageFrame[j] > 17)
						{
							Main.squirrelCageFrame[j] = 0;
						}
					}
				}
				for (int k = 0; k < Main.cageFrames; k++)
				{
					if (Main.mallardCageFrame[k] == 0 || Main.mallardCageFrame[k] == 4)
					{
						Main.mallardCageFrameCounter[k]++;
						if (Main.mallardCageFrameCounter[k] > Main.rand.Next(45, 2700))
						{
							if ((Main.mallardCageFrame[k] == 0 && Main.rand.Next(3) != 0) || (Main.mallardCageFrame[k] == 4 && Main.rand.Next(5) == 0))
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.mallardCageFrame[k] = 5;
								}
								else if (Main.rand.Next(3) == 0)
								{
									if (Main.mallardCageFrame[k] == 4)
									{
										Main.mallardCageFrame[k] = 0;
									}
									else
									{
										Main.mallardCageFrame[k] = 4;
									}
								}
								else
								{
									Main.mallardCageFrame[k] = 1;
								}
							}
							Main.mallardCageFrameCounter[k] = 0;
						}
					}
					else if (Main.mallardCageFrame[k] >= 1 && Main.mallardCageFrame[k] <= 3)
					{
						Main.mallardCageFrameCounter[k]++;
						if (Main.mallardCageFrameCounter[k] >= 5)
						{
							Main.mallardCageFrameCounter[k] = 0;
							Main.mallardCageFrame[k]++;
						}
						if (Main.mallardCageFrame[k] > 3)
						{
							if (Main.rand.Next(5) == 0)
							{
								Main.mallardCageFrame[k] = 0;
							}
							else
							{
								Main.mallardCageFrame[k] = 1;
							}
						}
					}
					else if (Main.mallardCageFrame[k] >= 5 && Main.mallardCageFrame[k] <= 11)
					{
						Main.mallardCageFrameCounter[k]++;
						if (Main.mallardCageFrameCounter[k] >= 5)
						{
							Main.mallardCageFrameCounter[k] = 0;
							Main.mallardCageFrame[k]++;
						}
					}
					else if (Main.mallardCageFrame[k] == 12 || Main.mallardCageFrame[k] == 16)
					{
						Main.mallardCageFrameCounter[k]++;
						if (Main.mallardCageFrameCounter[k] > Main.rand.Next(45, 2700))
						{
							if ((Main.mallardCageFrame[k] == 12 && Main.rand.Next(3) != 0) || (Main.mallardCageFrame[k] == 16 && Main.rand.Next(5) == 0))
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.mallardCageFrame[k] = 17;
								}
								else if (Main.rand.Next(3) == 0)
								{
									if (Main.mallardCageFrame[k] == 16)
									{
										Main.mallardCageFrame[k] = 12;
									}
									else
									{
										Main.mallardCageFrame[k] = 16;
									}
								}
								else
								{
									Main.mallardCageFrame[k] = 13;
								}
							}
							Main.mallardCageFrameCounter[k] = 0;
						}
					}
					else if (Main.mallardCageFrame[k] >= 13 && Main.mallardCageFrame[k] <= 15)
					{
						Main.mallardCageFrameCounter[k]++;
						if (Main.mallardCageFrameCounter[k] >= 5)
						{
							Main.mallardCageFrame[k]++;
							if (Main.mallardCageFrame[k] > 15)
							{
								if (Main.rand.Next(5) != 0)
								{
									Main.mallardCageFrame[k] = 12;
								}
								else
								{
									Main.mallardCageFrame[k] = 13;
								}
							}
							Main.mallardCageFrameCounter[k] = 0;
						}
					}
					else if (Main.mallardCageFrame[k] >= 17)
					{
						Main.mallardCageFrameCounter[k]++;
						if (Main.mallardCageFrameCounter[k] >= 5)
						{
							Main.mallardCageFrameCounter[k] = 0;
							Main.mallardCageFrame[k]++;
						}
						if (Main.mallardCageFrame[k] > 23)
						{
							Main.mallardCageFrame[k] = 0;
						}
					}
				}
				for (int l = 0; l < Main.cageFrames; l++)
				{
					if (Main.duckCageFrame[l] == 0 || Main.duckCageFrame[l] == 4)
					{
						Main.duckCageFrameCounter[l]++;
						if (Main.duckCageFrameCounter[l] > Main.rand.Next(45, 2700))
						{
							if ((Main.duckCageFrame[l] == 0 && Main.rand.Next(3) != 0) || (Main.duckCageFrame[l] == 4 && Main.rand.Next(5) == 0))
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.duckCageFrame[l] = 5;
								}
								else if (Main.rand.Next(3) == 0)
								{
									if (Main.duckCageFrame[l] == 4)
									{
										Main.duckCageFrame[l] = 0;
									}
									else
									{
										Main.duckCageFrame[l] = 4;
									}
								}
								else
								{
									Main.duckCageFrame[l] = 1;
								}
							}
							Main.duckCageFrameCounter[l] = 0;
						}
					}
					else if (Main.duckCageFrame[l] >= 1 && Main.duckCageFrame[l] <= 3)
					{
						Main.duckCageFrameCounter[l]++;
						if (Main.duckCageFrameCounter[l] >= 5)
						{
							Main.duckCageFrameCounter[l] = 0;
							Main.duckCageFrame[l]++;
						}
						if (Main.duckCageFrame[l] > 3)
						{
							if (Main.rand.Next(5) == 0)
							{
								Main.duckCageFrame[l] = 0;
							}
							else
							{
								Main.duckCageFrame[l] = 1;
							}
						}
					}
					else if (Main.duckCageFrame[l] >= 5 && Main.duckCageFrame[l] <= 11)
					{
						Main.duckCageFrameCounter[l]++;
						if (Main.duckCageFrameCounter[l] >= 5)
						{
							Main.duckCageFrameCounter[l] = 0;
							Main.duckCageFrame[l]++;
						}
					}
					else if (Main.duckCageFrame[l] == 12 || Main.duckCageFrame[l] == 16)
					{
						Main.duckCageFrameCounter[l]++;
						if (Main.duckCageFrameCounter[l] > Main.rand.Next(45, 2700))
						{
							if ((Main.duckCageFrame[l] == 12 && Main.rand.Next(3) != 0) || (Main.duckCageFrame[l] == 16 && Main.rand.Next(5) == 0))
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.duckCageFrame[l] = 17;
								}
								else if (Main.rand.Next(3) == 0)
								{
									if (Main.duckCageFrame[l] == 16)
									{
										Main.duckCageFrame[l] = 12;
									}
									else
									{
										Main.duckCageFrame[l] = 16;
									}
								}
								else
								{
									Main.duckCageFrame[l] = 13;
								}
							}
							Main.duckCageFrameCounter[l] = 0;
						}
					}
					else if (Main.duckCageFrame[l] >= 13 && Main.duckCageFrame[l] <= 15)
					{
						Main.duckCageFrameCounter[l]++;
						if (Main.duckCageFrameCounter[l] >= 5)
						{
							Main.duckCageFrame[l]++;
							if (Main.duckCageFrame[l] > 15)
							{
								if (Main.rand.Next(5) != 0)
								{
									Main.duckCageFrame[l] = 12;
								}
								else
								{
									Main.duckCageFrame[l] = 13;
								}
							}
							Main.duckCageFrameCounter[l] = 0;
						}
					}
					else if (Main.duckCageFrame[l] >= 17)
					{
						Main.duckCageFrameCounter[l]++;
						if (Main.duckCageFrameCounter[l] >= 5)
						{
							Main.duckCageFrameCounter[l] = 0;
							Main.duckCageFrame[l]++;
						}
						if (Main.duckCageFrame[l] > 23)
						{
							Main.duckCageFrame[l] = 0;
						}
					}
				}
				for (int m = 0; m < Main.cageFrames; m++)
				{
					if (Main.birdCageFrame[m] == 0)
					{
						Main.birdCageFrameCounter[m]++;
						if (Main.birdCageFrameCounter[m] > Main.rand.Next(30, 2700))
						{
							if (Main.rand.Next(3) != 0)
							{
								if (Main.rand.Next(3) != 0)
								{
									Main.birdCageFrame[m] = 2;
								}
								else
								{
									Main.birdCageFrame[m] = 1;
								}
							}
							Main.birdCageFrameCounter[m] = 0;
						}
					}
					else if (Main.birdCageFrame[m] == 1)
					{
						Main.birdCageFrameCounter[m]++;
						if (Main.birdCageFrameCounter[m] > Main.rand.Next(900, 18000) && Main.rand.Next(3) == 0)
						{
							Main.birdCageFrameCounter[m] = 0;
							Main.birdCageFrame[m] = 0;
						}
					}
					else if (Main.birdCageFrame[m] >= 2 && Main.birdCageFrame[m] <= 5)
					{
						Main.birdCageFrameCounter[m]++;
						if (Main.birdCageFrameCounter[m] >= 5)
						{
							Main.birdCageFrameCounter[m] = 0;
							if (Main.birdCageFrame[m] == 3 && Main.rand.Next(3) == 0)
							{
								Main.birdCageFrame[m] = 13;
							}
							else
							{
								Main.birdCageFrame[m]++;
							}
						}
					}
					else if (Main.birdCageFrame[m] == 6)
					{
						Main.birdCageFrameCounter[m]++;
						if (Main.birdCageFrameCounter[m] > Main.rand.Next(45, 2700))
						{
							if (Main.rand.Next(3) != 0)
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.birdCageFrame[m] = 7;
								}
								else if (Main.rand.Next(6) == 0)
								{
									Main.birdCageFrame[m] = 11;
								}
							}
							Main.birdCageFrameCounter[m] = 0;
						}
					}
					else if (Main.birdCageFrame[m] >= 7 && Main.birdCageFrame[m] <= 10)
					{
						Main.birdCageFrameCounter[m]++;
						if (Main.birdCageFrameCounter[m] >= 5)
						{
							Main.birdCageFrame[m]++;
							if (Main.birdCageFrame[m] > 10)
							{
								Main.birdCageFrame[m] = 0;
							}
							Main.birdCageFrameCounter[m] = 0;
						}
					}
					else if (Main.birdCageFrame[m] >= 11 && Main.birdCageFrame[m] <= 13)
					{
						Main.birdCageFrameCounter[m]++;
						if (Main.birdCageFrameCounter[m] >= 5)
						{
							Main.birdCageFrame[m]++;
							Main.birdCageFrameCounter[m] = 0;
						}
					}
					else if (Main.birdCageFrame[m] == 14)
					{
						Main.birdCageFrameCounter[m]++;
						if (Main.birdCageFrameCounter[m] > Main.rand.Next(5, 600))
						{
							if (Main.rand.Next(20) == 0)
							{
								Main.birdCageFrame[m] = 16;
							}
							else if (Main.rand.Next(20) == 0)
							{
								Main.birdCageFrame[m] = 4;
							}
							else
							{
								Main.birdCageFrame[m] = 15;
							}
							Main.birdCageFrameCounter[m] = 0;
						}
					}
					else if (Main.birdCageFrame[m] == 15)
					{
						Main.birdCageFrameCounter[m]++;
						if (Main.birdCageFrameCounter[m] >= 10)
						{
							Main.birdCageFrameCounter[m] = 0;
							Main.birdCageFrame[m] = 14;
						}
					}
					else if (Main.birdCageFrame[m] >= 16 && Main.birdCageFrame[m] <= 18)
					{
						Main.birdCageFrameCounter[m]++;
						if (Main.birdCageFrameCounter[m] >= 5)
						{
							Main.birdCageFrame[m]++;
							if (Main.birdCageFrame[m] > 18)
							{
								Main.birdCageFrame[m] = 0;
							}
							Main.birdCageFrameCounter[m] = 0;
						}
					}
				}
				for (int n = 0; n < Main.cageFrames; n++)
				{
					if (Main.blueBirdCageFrame[n] == 0)
					{
						Main.blueBirdCageFrameCounter[n]++;
						if (Main.blueBirdCageFrameCounter[n] > Main.rand.Next(30, 2700))
						{
							if (Main.rand.Next(3) != 0)
							{
								if (Main.rand.Next(3) != 0)
								{
									Main.blueBirdCageFrame[n] = 2;
								}
								else
								{
									Main.blueBirdCageFrame[n] = 1;
								}
							}
							Main.blueBirdCageFrameCounter[n] = 0;
						}
					}
					else if (Main.blueBirdCageFrame[n] == 1)
					{
						Main.blueBirdCageFrameCounter[n]++;
						if (Main.blueBirdCageFrameCounter[n] > Main.rand.Next(900, 18000) && Main.rand.Next(3) == 0)
						{
							Main.blueBirdCageFrameCounter[n] = 0;
							Main.blueBirdCageFrame[n] = 0;
						}
					}
					else if (Main.blueBirdCageFrame[n] >= 2 && Main.blueBirdCageFrame[n] <= 5)
					{
						Main.blueBirdCageFrameCounter[n]++;
						if (Main.blueBirdCageFrameCounter[n] >= 5)
						{
							Main.blueBirdCageFrameCounter[n] = 0;
							if (Main.blueBirdCageFrame[n] == 3 && Main.rand.Next(3) == 0)
							{
								Main.blueBirdCageFrame[n] = 13;
							}
							else
							{
								Main.blueBirdCageFrame[n]++;
							}
						}
					}
					else if (Main.blueBirdCageFrame[n] == 6)
					{
						Main.blueBirdCageFrameCounter[n]++;
						if (Main.blueBirdCageFrameCounter[n] > Main.rand.Next(45, 2700))
						{
							if (Main.rand.Next(3) != 0)
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.blueBirdCageFrame[n] = 7;
								}
								else if (Main.rand.Next(6) == 0)
								{
									Main.blueBirdCageFrame[n] = 11;
								}
							}
							Main.blueBirdCageFrameCounter[n] = 0;
						}
					}
					else if (Main.blueBirdCageFrame[n] >= 7 && Main.blueBirdCageFrame[n] <= 10)
					{
						Main.blueBirdCageFrameCounter[n]++;
						if (Main.blueBirdCageFrameCounter[n] >= 5)
						{
							Main.blueBirdCageFrame[n]++;
							if (Main.blueBirdCageFrame[n] > 10)
							{
								Main.blueBirdCageFrame[n] = 0;
							}
							Main.blueBirdCageFrameCounter[n] = 0;
						}
					}
					else if (Main.blueBirdCageFrame[n] >= 11 && Main.blueBirdCageFrame[n] <= 13)
					{
						Main.blueBirdCageFrameCounter[n]++;
						if (Main.blueBirdCageFrameCounter[n] >= 5)
						{
							Main.blueBirdCageFrame[n]++;
							Main.blueBirdCageFrameCounter[n] = 0;
						}
					}
					else if (Main.blueBirdCageFrame[n] == 14)
					{
						Main.blueBirdCageFrameCounter[n]++;
						if (Main.blueBirdCageFrameCounter[n] > Main.rand.Next(5, 600))
						{
							if (Main.rand.Next(20) == 0)
							{
								Main.blueBirdCageFrame[n] = 16;
							}
							else if (Main.rand.Next(20) == 0)
							{
								Main.blueBirdCageFrame[n] = 4;
							}
							else
							{
								Main.blueBirdCageFrame[n] = 15;
							}
							Main.blueBirdCageFrameCounter[n] = 0;
						}
					}
					else if (Main.blueBirdCageFrame[n] == 15)
					{
						Main.blueBirdCageFrameCounter[n]++;
						if (Main.blueBirdCageFrameCounter[n] >= 10)
						{
							Main.blueBirdCageFrameCounter[n] = 0;
							Main.blueBirdCageFrame[n] = 14;
						}
					}
					else if (Main.blueBirdCageFrame[n] >= 16 && Main.blueBirdCageFrame[n] <= 18)
					{
						Main.blueBirdCageFrameCounter[n]++;
						if (Main.blueBirdCageFrameCounter[n] >= 5)
						{
							Main.blueBirdCageFrame[n]++;
							if (Main.blueBirdCageFrame[n] > 18)
							{
								Main.blueBirdCageFrame[n] = 0;
							}
							Main.blueBirdCageFrameCounter[n] = 0;
						}
					}
				}
				for (int num2 = 0; num2 < Main.cageFrames; num2++)
				{
					if (Main.redBirdCageFrame[num2] == 0)
					{
						Main.redBirdCageFrameCounter[num2]++;
						if (Main.redBirdCageFrameCounter[num2] > Main.rand.Next(30, 2700))
						{
							if (Main.rand.Next(3) != 0)
							{
								if (Main.rand.Next(3) != 0)
								{
									Main.redBirdCageFrame[num2] = 2;
								}
								else
								{
									Main.redBirdCageFrame[num2] = 1;
								}
							}
							Main.redBirdCageFrameCounter[num2] = 0;
						}
					}
					else if (Main.redBirdCageFrame[num2] == 1)
					{
						Main.redBirdCageFrameCounter[num2]++;
						if (Main.redBirdCageFrameCounter[num2] > Main.rand.Next(900, 18000) && Main.rand.Next(3) == 0)
						{
							Main.redBirdCageFrameCounter[num2] = 0;
							Main.redBirdCageFrame[num2] = 0;
						}
					}
					else if (Main.redBirdCageFrame[num2] >= 2 && Main.redBirdCageFrame[num2] <= 5)
					{
						Main.redBirdCageFrameCounter[num2]++;
						if (Main.redBirdCageFrameCounter[num2] >= 5)
						{
							Main.redBirdCageFrameCounter[num2] = 0;
							if (Main.redBirdCageFrame[num2] == 3 && Main.rand.Next(3) == 0)
							{
								Main.redBirdCageFrame[num2] = 13;
							}
							else
							{
								Main.redBirdCageFrame[num2]++;
							}
						}
					}
					else if (Main.redBirdCageFrame[num2] == 6)
					{
						Main.redBirdCageFrameCounter[num2]++;
						if (Main.redBirdCageFrameCounter[num2] > Main.rand.Next(45, 2700))
						{
							if (Main.rand.Next(3) != 0)
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.redBirdCageFrame[num2] = 7;
								}
								else if (Main.rand.Next(6) == 0)
								{
									Main.redBirdCageFrame[num2] = 11;
								}
							}
							Main.redBirdCageFrameCounter[num2] = 0;
						}
					}
					else if (Main.redBirdCageFrame[num2] >= 7 && Main.redBirdCageFrame[num2] <= 10)
					{
						Main.redBirdCageFrameCounter[num2]++;
						if (Main.redBirdCageFrameCounter[num2] >= 5)
						{
							Main.redBirdCageFrame[num2]++;
							if (Main.redBirdCageFrame[num2] > 10)
							{
								Main.redBirdCageFrame[num2] = 0;
							}
							Main.redBirdCageFrameCounter[num2] = 0;
						}
					}
					else if (Main.redBirdCageFrame[num2] >= 11 && Main.redBirdCageFrame[num2] <= 13)
					{
						Main.redBirdCageFrameCounter[num2]++;
						if (Main.redBirdCageFrameCounter[num2] >= 5)
						{
							Main.redBirdCageFrame[num2]++;
							Main.redBirdCageFrameCounter[num2] = 0;
						}
					}
					else if (Main.redBirdCageFrame[num2] == 14)
					{
						Main.redBirdCageFrameCounter[num2]++;
						if (Main.redBirdCageFrameCounter[num2] > Main.rand.Next(5, 600))
						{
							if (Main.rand.Next(20) == 0)
							{
								Main.redBirdCageFrame[num2] = 16;
							}
							else if (Main.rand.Next(20) == 0)
							{
								Main.redBirdCageFrame[num2] = 4;
							}
							else
							{
								Main.redBirdCageFrame[num2] = 15;
							}
							Main.redBirdCageFrameCounter[num2] = 0;
						}
					}
					else if (Main.redBirdCageFrame[num2] == 15)
					{
						Main.redBirdCageFrameCounter[num2]++;
						if (Main.redBirdCageFrameCounter[num2] >= 10)
						{
							Main.redBirdCageFrameCounter[num2] = 0;
							Main.redBirdCageFrame[num2] = 14;
						}
					}
					else if (Main.redBirdCageFrame[num2] >= 16 && Main.redBirdCageFrame[num2] <= 18)
					{
						Main.redBirdCageFrameCounter[num2]++;
						if (Main.redBirdCageFrameCounter[num2] >= 5)
						{
							Main.redBirdCageFrame[num2]++;
							if (Main.redBirdCageFrame[num2] > 18)
							{
								Main.redBirdCageFrame[num2] = 0;
							}
							Main.redBirdCageFrameCounter[num2] = 0;
						}
					}
				}
				for (int num3 = 0; num3 < 2; num3++)
				{
					for (int num4 = 0; num4 < Main.cageFrames; num4++)
					{
						if (Main.scorpionCageFrame[num3, num4] == 0 || Main.scorpionCageFrame[num3, num4] == 7)
						{
							Main.scorpionCageFrameCounter[num3, num4]++;
							if (Main.scorpionCageFrameCounter[num3, num4] > Main.rand.Next(30, 3600))
							{
								if (Main.scorpionCageFrame[num3, num4] == 7)
								{
									Main.scorpionCageFrame[num3, num4] = 0;
								}
								else if (Main.rand.Next(3) == 0)
								{
									if (Main.rand.Next(7) == 0)
									{
										Main.scorpionCageFrame[num3, num4] = 1;
									}
									else if (Main.rand.Next(4) == 0)
									{
										Main.scorpionCageFrame[num3, num4] = 8;
									}
									else if (Main.rand.Next(3) == 0)
									{
										Main.scorpionCageFrame[num3, num4] = 7;
									}
									else
									{
										Main.scorpionCageFrame[num3, num4] = 14;
									}
								}
								Main.scorpionCageFrameCounter[num3, num4] = 0;
							}
						}
						else if (Main.scorpionCageFrame[num3, num4] >= 1 && Main.scorpionCageFrame[num3, num4] <= 2)
						{
							Main.scorpionCageFrameCounter[num3, num4]++;
							if (Main.scorpionCageFrameCounter[num3, num4] >= 10)
							{
								Main.scorpionCageFrameCounter[num3, num4] = 0;
								Main.scorpionCageFrame[num3, num4]++;
							}
						}
						else if (Main.scorpionCageFrame[num3, num4] >= 8 && Main.scorpionCageFrame[num3, num4] <= 10)
						{
							Main.scorpionCageFrameCounter[num3, num4]++;
							if (Main.scorpionCageFrameCounter[num3, num4] >= 10)
							{
								Main.scorpionCageFrameCounter[num3, num4] = 0;
								Main.scorpionCageFrame[num3, num4]++;
							}
						}
						else if (Main.scorpionCageFrame[num3, num4] == 11)
						{
							Main.scorpionCageFrameCounter[num3, num4]++;
							if (Main.scorpionCageFrameCounter[num3, num4] > Main.rand.Next(45, 5400))
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.scorpionCageFrame[num3, num4] = 12;
								}
								Main.scorpionCageFrameCounter[num3, num4] = 0;
							}
						}
						else if (Main.scorpionCageFrame[num3, num4] >= 12 && Main.scorpionCageFrame[num3, num4] <= 13)
						{
							Main.scorpionCageFrameCounter[num3, num4]++;
							if (Main.scorpionCageFrameCounter[num3, num4] >= 10)
							{
								Main.scorpionCageFrameCounter[num3, num4] = 0;
								Main.scorpionCageFrame[num3, num4]++;
								if (Main.scorpionCageFrame[num3, num4] > 13)
								{
									Main.scorpionCageFrame[num3, num4] = 0;
								}
							}
						}
						else if (Main.scorpionCageFrame[num3, num4] >= 14 && Main.scorpionCageFrame[num3, num4] <= 15)
						{
							Main.scorpionCageFrameCounter[num3, num4]++;
							if (Main.scorpionCageFrameCounter[num3, num4] >= 5)
							{
								Main.scorpionCageFrameCounter[num3, num4] = 0;
								Main.scorpionCageFrame[num3, num4]++;
								if (Main.scorpionCageFrame[num3, num4] > 15)
								{
									Main.scorpionCageFrame[num3, num4] = 14;
								}
								if (Main.rand.Next(5) == 0)
								{
									Main.scorpionCageFrame[num3, num4] = 0;
								}
							}
						}
						else if (Main.scorpionCageFrame[num3, num4] == 4 || Main.scorpionCageFrame[num3, num4] == 3)
						{
							Main.scorpionCageFrameCounter[num3, num4]++;
							if (Main.scorpionCageFrameCounter[num3, num4] > Main.rand.Next(30, 3600))
							{
								if (Main.scorpionCageFrame[num3, num4] == 3)
								{
									Main.scorpionCageFrame[num3, num4] = 4;
								}
								else if (Main.rand.Next(3) == 0)
								{
									if (Main.rand.Next(5) == 0)
									{
										Main.scorpionCageFrame[num3, num4] = 5;
									}
									else if (Main.rand.Next(3) == 0)
									{
										Main.scorpionCageFrame[num3, num4] = 3;
									}
									else
									{
										Main.scorpionCageFrame[num3, num4] = 16;
									}
								}
								Main.scorpionCageFrameCounter[num3, num4] = 0;
							}
						}
						else if (Main.scorpionCageFrame[num3, num4] >= 5 && Main.scorpionCageFrame[num3, num4] <= 6)
						{
							Main.scorpionCageFrameCounter[num3, num4]++;
							if (Main.scorpionCageFrameCounter[num3, num4] >= 10)
							{
								Main.scorpionCageFrameCounter[num3, num4] = 0;
								Main.scorpionCageFrame[num3, num4]++;
								if (Main.scorpionCageFrame[num3, num4] > 7)
								{
									Main.scorpionCageFrame[num3, num4] = 0;
								}
							}
						}
						else if (Main.scorpionCageFrame[num3, num4] >= 16 && Main.scorpionCageFrame[num3, num4] <= 17)
						{
							Main.scorpionCageFrameCounter[num3, num4]++;
							if (Main.scorpionCageFrameCounter[num3, num4] >= 5)
							{
								Main.scorpionCageFrameCounter[num3, num4] = 0;
								Main.scorpionCageFrame[num3, num4]++;
								if (Main.scorpionCageFrame[num3, num4] > 17)
								{
									Main.scorpionCageFrame[num3, num4] = 16;
								}
								if (Main.rand.Next(5) == 0)
								{
									Main.scorpionCageFrame[num3, num4] = 4;
								}
							}
						}
					}
				}
				for (int num5 = 0; num5 < Main.cageFrames; num5++)
				{
					if (Main.penguinCageFrame[num5] == 0)
					{
						Main.penguinCageFrameCounter[num5]++;
						if (Main.penguinCageFrameCounter[num5] > Main.rand.Next(30, 1800))
						{
							if (Main.rand.Next(2) == 0)
							{
								if (Main.rand.Next(10) == 0)
								{
									Main.penguinCageFrame[num5] = 4;
								}
								else if (Main.rand.Next(7) == 0)
								{
									Main.penguinCageFrame[num5] = 15;
								}
								else if (Main.rand.Next(3) == 0)
								{
									Main.penguinCageFrame[num5] = 2;
								}
								else
								{
									Main.penguinCageFrame[num5] = 1;
								}
							}
							Main.penguinCageFrameCounter[num5] = 0;
						}
					}
					else if (Main.penguinCageFrame[num5] == 1)
					{
						Main.penguinCageFrameCounter[num5]++;
						if (Main.penguinCageFrameCounter[num5] >= 10)
						{
							Main.penguinCageFrameCounter[num5] = 0;
							Main.penguinCageFrame[num5] = 0;
						}
					}
					else if (Main.penguinCageFrame[num5] >= 2 && Main.penguinCageFrame[num5] <= 3)
					{
						Main.penguinCageFrameCounter[num5]++;
						if (Main.penguinCageFrameCounter[num5] >= 5)
						{
							Main.penguinCageFrameCounter[num5] = 0;
							Main.penguinCageFrame[num5]++;
							if (Main.penguinCageFrame[num5] > 3)
							{
								if (Main.rand.Next(3) == 0)
								{
									Main.penguinCageFrame[num5] = 0;
								}
								else
								{
									Main.penguinCageFrame[num5] = 2;
								}
							}
						}
					}
					else if (Main.penguinCageFrame[num5] >= 4 && Main.penguinCageFrame[num5] <= 6)
					{
						Main.penguinCageFrameCounter[num5]++;
						if (Main.penguinCageFrameCounter[num5] >= 10)
						{
							Main.penguinCageFrameCounter[num5] = 0;
							Main.penguinCageFrame[num5]++;
						}
					}
					else if (Main.penguinCageFrame[num5] == 15)
					{
						Main.penguinCageFrameCounter[num5]++;
						if (Main.penguinCageFrameCounter[num5] > Main.rand.Next(10, 1800))
						{
							if (Main.rand.Next(2) == 0)
							{
								Main.penguinCageFrame[num5] = 0;
							}
							Main.penguinCageFrameCounter[num5] = 0;
						}
					}
					else if (Main.penguinCageFrame[num5] == 8)
					{
						Main.penguinCageFrameCounter[num5]++;
						if (Main.penguinCageFrameCounter[num5] > Main.rand.Next(30, 3600))
						{
							if (Main.rand.Next(2) == 0)
							{
								if (Main.rand.Next(10) == 0)
								{
									Main.penguinCageFrame[num5] = 12;
								}
								else if (Main.rand.Next(7) == 0)
								{
									Main.penguinCageFrame[num5] = 7;
								}
								else if (Main.rand.Next(3) == 0)
								{
									Main.penguinCageFrame[num5] = 10;
								}
								else
								{
									Main.penguinCageFrame[num5] = 9;
								}
							}
							Main.penguinCageFrameCounter[num5] = 0;
						}
					}
					else if (Main.penguinCageFrame[num5] == 9)
					{
						Main.penguinCageFrameCounter[num5]++;
						if (Main.penguinCageFrameCounter[num5] >= 10)
						{
							Main.penguinCageFrameCounter[num5] = 0;
							Main.penguinCageFrame[num5] = 8;
						}
					}
					else if (Main.penguinCageFrame[num5] >= 10 && Main.penguinCageFrame[num5] <= 11)
					{
						Main.penguinCageFrameCounter[num5]++;
						if (Main.penguinCageFrameCounter[num5] >= 5)
						{
							Main.penguinCageFrameCounter[num5] = 0;
							Main.penguinCageFrame[num5]++;
							if (Main.penguinCageFrame[num5] > 3)
							{
								if (Main.rand.Next(3) == 0)
								{
									Main.penguinCageFrame[num5] = 8;
								}
								else
								{
									Main.penguinCageFrame[num5] = 10;
								}
							}
						}
					}
					else if (Main.penguinCageFrame[num5] >= 12 && Main.penguinCageFrame[num5] <= 14)
					{
						Main.penguinCageFrameCounter[num5]++;
						if (Main.penguinCageFrameCounter[num5] >= 10)
						{
							Main.penguinCageFrameCounter[num5] = 0;
							Main.penguinCageFrame[num5]++;
						}
					}
					else if (Main.penguinCageFrame[num5] == 7)
					{
						Main.penguinCageFrameCounter[num5]++;
						if (Main.penguinCageFrameCounter[num5] > Main.rand.Next(10, 3600))
						{
							if (Main.rand.Next(2) == 0)
							{
								Main.penguinCageFrame[num5] = 8;
							}
							Main.penguinCageFrameCounter[num5] = 0;
						}
					}
				}
				for (int num6 = 0; num6 < Main.cageFrames; num6++)
				{
					if (Main.snailCageFrame[num6] >= 0 && Main.snailCageFrame[num6] <= 13)
					{
						Main.snailCageFrameCounter[num6]++;
						if (Main.snailCageFrameCounter[num6] > Main.rand.Next(45, 3600))
						{
							if (Main.snailCageFrame[num6] == 8 && Main.rand.Next(2) == 0)
							{
								Main.snailCageFrame[num6] = 14;
							}
							else if (Main.snailCageFrame[num6] == 1 && Main.rand.Next(3) == 0)
							{
								Main.snailCageFrame[num6] = 19;
							}
							else if (Main.snailCageFrame[num6] == 1 && Main.rand.Next(3) == 0)
							{
								Main.snailCageFrame[num6] = 20;
							}
							else
							{
								Main.snailCageFrame[num6]++;
								if (Main.snailCageFrame[num6] > 13)
								{
									Main.snailCageFrame[num6] = 0;
								}
							}
							Main.snailCageFrameCounter[num6] = 0;
						}
					}
					else if (Main.snailCageFrame[num6] >= 14 && Main.snailCageFrame[num6] <= 18)
					{
						Main.snailCageFrameCounter[num6]++;
						if (Main.snailCageFrameCounter[num6] >= 5)
						{
							Main.snailCageFrameCounter[num6] = 0;
							Main.snailCageFrame[num6]++;
						}
						if (Main.snailCageFrame[num6] > 18)
						{
							Main.snailCageFrame[num6] = 20;
						}
					}
					else if (Main.snailCageFrame[num6] == 19 || Main.snailCageFrame[num6] == 20)
					{
						Main.snailCageFrameCounter[num6]++;
						if (Main.snailCageFrameCounter[num6] > Main.rand.Next(60, 7200))
						{
							Main.snailCageFrameCounter[num6] = 0;
							if (Main.rand.Next(4) == 0)
							{
								if (Main.rand.Next(3) == 0)
								{
									Main.snailCageFrame[num6] = 2;
								}
								else if (Main.snailCageFrame[num6] == 19)
								{
									Main.snailCageFrame[num6] = 20;
								}
								else
								{
									Main.snailCageFrame[num6] = 19;
								}
							}
						}
					}
				}
				for (int num7 = 0; num7 < Main.cageFrames; num7++)
				{
					if (Main.snail2CageFrame[num7] >= 0 && Main.snail2CageFrame[num7] <= 13)
					{
						Main.snail2CageFrameCounter[num7]++;
						if (Main.snail2CageFrameCounter[num7] > Main.rand.Next(30, 2700))
						{
							if (Main.snail2CageFrame[num7] == 8 && Main.rand.Next(2) == 0)
							{
								Main.snail2CageFrame[num7] = 14;
							}
							else if (Main.snail2CageFrame[num7] == 1 && Main.rand.Next(3) == 0)
							{
								Main.snail2CageFrame[num7] = 19;
							}
							else if (Main.snail2CageFrame[num7] == 1 && Main.rand.Next(3) == 0)
							{
								Main.snail2CageFrame[num7] = 20;
							}
							else
							{
								Main.snail2CageFrame[num7]++;
								if (Main.snail2CageFrame[num7] > 13)
								{
									Main.snail2CageFrame[num7] = 0;
								}
							}
							Main.snail2CageFrameCounter[num7] = 0;
						}
					}
					else if (Main.snail2CageFrame[num7] >= 14 && Main.snail2CageFrame[num7] <= 18)
					{
						Main.snail2CageFrameCounter[num7]++;
						if (Main.snail2CageFrameCounter[num7] >= 5)
						{
							Main.snail2CageFrameCounter[num7] = 0;
							Main.snail2CageFrame[num7]++;
						}
						if (Main.snail2CageFrame[num7] > 18)
						{
							Main.snail2CageFrame[num7] = 20;
						}
					}
					else if (Main.snail2CageFrame[num7] == 19 || Main.snail2CageFrame[num7] == 20)
					{
						Main.snail2CageFrameCounter[num7]++;
						if (Main.snail2CageFrameCounter[num7] > Main.rand.Next(45, 5400))
						{
							Main.snail2CageFrameCounter[num7] = 0;
							if (Main.rand.Next(4) == 0)
							{
								if (Main.rand.Next(3) == 0)
								{
									Main.snail2CageFrame[num7] = 2;
								}
								else if (Main.snail2CageFrame[num7] == 19)
								{
									Main.snail2CageFrame[num7] = 20;
								}
								else
								{
									Main.snail2CageFrame[num7] = 19;
								}
							}
						}
					}
				}
				for (int num8 = 0; num8 < Main.cageFrames; num8++)
				{
					if (Main.frogCageFrame[num8] == 0)
					{
						Main.frogCageFrameCounter[num8]++;
						if (Main.frogCageFrameCounter[num8] > Main.rand.Next(45, 3600))
						{
							if (Main.rand.Next(10) == 0)
							{
								Main.frogCageFrame[num8] = 1;
							}
							else
							{
								Main.frogCageFrame[num8] = 12;
							}
							Main.frogCageFrameCounter[num8] = 0;
						}
					}
					else if (Main.frogCageFrame[num8] >= 1 && Main.frogCageFrame[num8] <= 5)
					{
						Main.frogCageFrameCounter[num8]++;
						if (Main.frogCageFrameCounter[num8] >= 5)
						{
							Main.frogCageFrame[num8]++;
							Main.frogCageFrameCounter[num8] = 0;
						}
					}
					else if (Main.frogCageFrame[num8] >= 12 && Main.frogCageFrame[num8] <= 17)
					{
						Main.frogCageFrameCounter[num8]++;
						if (Main.frogCageFrameCounter[num8] >= 5)
						{
							Main.frogCageFrameCounter[num8] = 0;
							Main.frogCageFrame[num8]++;
						}
						if (Main.frogCageFrame[num8] > 17)
						{
							if (Main.rand.Next(3) == 0)
							{
								Main.frogCageFrame[num8] = 0;
							}
							else
							{
								Main.frogCageFrame[num8] = 12;
							}
						}
					}
					else if (Main.frogCageFrame[num8] == 6)
					{
						Main.frogCageFrameCounter[num8]++;
						if (Main.frogCageFrameCounter[num8] > Main.rand.Next(45, 3600))
						{
							if (Main.rand.Next(10) == 0)
							{
								Main.frogCageFrame[num8] = 7;
							}
							else
							{
								Main.frogCageFrame[num8] = 18;
							}
							Main.frogCageFrameCounter[num8] = 0;
						}
					}
					else if (Main.frogCageFrame[num8] >= 7 && Main.frogCageFrame[num8] <= 11)
					{
						Main.frogCageFrameCounter[num8]++;
						if (Main.frogCageFrameCounter[num8] >= 5)
						{
							Main.frogCageFrame[num8]++;
							Main.frogCageFrameCounter[num8] = 0;
							if (Main.frogCageFrame[num8] > 11)
							{
								Main.frogCageFrame[num8] = 0;
							}
						}
					}
					else if (Main.frogCageFrame[num8] >= 18 && Main.frogCageFrame[num8] <= 23)
					{
						Main.frogCageFrameCounter[num8]++;
						if (Main.frogCageFrameCounter[num8] >= 5)
						{
							Main.frogCageFrameCounter[num8] = 0;
							Main.frogCageFrame[num8]++;
						}
						if (Main.frogCageFrame[num8] > 17)
						{
							if (Main.rand.Next(3) == 0)
							{
								Main.frogCageFrame[num8] = 6;
							}
							else
							{
								Main.frogCageFrame[num8] = 18;
							}
						}
					}
				}
				for (int num9 = 0; num9 < Main.cageFrames; num9++)
				{
					if (Main.mouseCageFrame[num9] >= 0 && Main.mouseCageFrame[num9] <= 1)
					{
						Main.mouseCageFrameCounter[num9]++;
						if (Main.mouseCageFrameCounter[num9] >= 5)
						{
							Main.mouseCageFrame[num9]++;
							if (Main.mouseCageFrame[num9] > 1)
							{
								Main.mouseCageFrame[num9] = 0;
							}
							Main.mouseCageFrameCounter[num9] = 0;
							if (Main.rand.Next(15) == 0)
							{
								Main.mouseCageFrame[num9] = 4;
							}
						}
					}
					else if (Main.mouseCageFrame[num9] >= 4 && Main.mouseCageFrame[num9] <= 7)
					{
						Main.mouseCageFrameCounter[num9]++;
						if (Main.mouseCageFrameCounter[num9] >= 5)
						{
							Main.mouseCageFrameCounter[num9] = 0;
							Main.mouseCageFrame[num9]++;
						}
						if (Main.mouseCageFrame[num9] > 7)
						{
							Main.mouseCageFrame[num9] = 2;
						}
					}
					else if (Main.mouseCageFrame[num9] >= 2 && Main.mouseCageFrame[num9] <= 3)
					{
						Main.mouseCageFrameCounter[num9]++;
						if (Main.mouseCageFrameCounter[num9] >= 5)
						{
							Main.mouseCageFrame[num9]++;
							if (Main.mouseCageFrame[num9] > 3)
							{
								Main.mouseCageFrame[num9] = 2;
							}
							Main.mouseCageFrameCounter[num9] = 0;
							if (Main.rand.Next(15) == 0)
							{
								Main.mouseCageFrame[num9] = 8;
							}
							else if (Main.rand.Next(15) == 0)
							{
								Main.mouseCageFrame[num9] = 12;
							}
						}
					}
					else if (Main.mouseCageFrame[num9] >= 8 && Main.mouseCageFrame[num9] <= 11)
					{
						Main.mouseCageFrameCounter[num9]++;
						if (Main.mouseCageFrameCounter[num9] >= 5)
						{
							Main.mouseCageFrameCounter[num9] = 0;
							Main.mouseCageFrame[num9]++;
						}
						if (Main.mouseCageFrame[num9] > 11)
						{
							Main.mouseCageFrame[num9] = 0;
						}
					}
					else if (Main.mouseCageFrame[num9] >= 12 && Main.mouseCageFrame[num9] <= 13)
					{
						Main.mouseCageFrameCounter[num9]++;
						if (Main.mouseCageFrameCounter[num9] >= 5)
						{
							Main.mouseCageFrameCounter[num9] = 0;
							Main.mouseCageFrame[num9]++;
						}
					}
					else if (Main.mouseCageFrame[num9] >= 14 && Main.mouseCageFrame[num9] <= 17)
					{
						Main.mouseCageFrameCounter[num9]++;
						if (Main.mouseCageFrameCounter[num9] >= 5)
						{
							Main.mouseCageFrameCounter[num9] = 0;
							Main.mouseCageFrame[num9]++;
							if (Main.mouseCageFrame[num9] > 17 && Main.rand.Next(20) != 0)
							{
								Main.mouseCageFrame[num9] = 14;
							}
						}
					}
					else if (Main.mouseCageFrame[num9] >= 18 && Main.mouseCageFrame[num9] <= 19)
					{
						Main.mouseCageFrameCounter[num9]++;
						if (Main.mouseCageFrameCounter[num9] >= 5)
						{
							Main.mouseCageFrameCounter[num9] = 0;
							Main.mouseCageFrame[num9]++;
							if (Main.mouseCageFrame[num9] > 19)
							{
								Main.mouseCageFrame[num9] = 0;
							}
						}
					}
				}
				for (int num10 = 0; num10 < Main.cageFrames; num10++)
				{
					Main.wormCageFrameCounter[num10]++;
					if (Main.wormCageFrameCounter[num10] >= Main.rand.Next(30, 91))
					{
						Main.wormCageFrameCounter[num10] = 0;
						if (Main.rand.Next(4) == 0)
						{
							Main.wormCageFrame[num10]++;
							if (Main.wormCageFrame[num10] == 9 && Main.rand.Next(2) == 0)
							{
								Main.wormCageFrame[num10] = 0;
							}
							if (Main.wormCageFrame[num10] > 18)
							{
								if (Main.rand.Next(2) == 0)
								{
									Main.wormCageFrame[num10] = 9;
								}
								else
								{
									Main.wormCageFrame[num10] = 0;
								}
							}
						}
					}
				}
				for (int num11 = 0; num11 < Main.cageFrames; num11++)
				{
					byte maxValue = 5;
					if (Main.fishBowlFrameMode[num11] == 1)
					{
						if (Main.rand.Next(900) == 0)
						{
							Main.fishBowlFrameMode[num11] = (byte)Main.rand.Next((int)maxValue);
						}
						Main.fishBowlFrameCounter[num11]++;
						if (Main.fishBowlFrameCounter[num11] >= 5)
						{
							Main.fishBowlFrameCounter[num11] = 0;
							if (Main.fishBowlFrame[num11] == 10)
							{
								if (Main.rand.Next(20) == 0)
								{
									Main.fishBowlFrame[num11] = 11;
									Main.fishBowlFrameMode[num11] = 0;
								}
								else
								{
									Main.fishBowlFrame[num11] = 1;
								}
							}
							else
							{
								Main.fishBowlFrame[num11]++;
							}
						}
					}
					else if (Main.fishBowlFrameMode[num11] == 2)
					{
						if (Main.rand.Next(3600) == 0)
						{
							Main.fishBowlFrameMode[num11] = (byte)Main.rand.Next((int)maxValue);
						}
						Main.fishBowlFrameCounter[num11]++;
						if (Main.fishBowlFrameCounter[num11] >= 20)
						{
							Main.fishBowlFrameCounter[num11] = 0;
							if (Main.fishBowlFrame[num11] == 10)
							{
								if (Main.rand.Next(20) == 0)
								{
									Main.fishBowlFrame[num11] = 11;
									Main.fishBowlFrameMode[num11] = 0;
								}
								else
								{
									Main.fishBowlFrame[num11] = 1;
								}
							}
							else
							{
								Main.fishBowlFrame[num11]++;
							}
						}
					}
					else if (Main.fishBowlFrameMode[num11] == 3)
					{
						if (Main.rand.Next(3600) == 0)
						{
							Main.fishBowlFrameMode[num11] = (byte)Main.rand.Next((int)maxValue);
						}
						Main.fishBowlFrameCounter[num11]++;
						if (Main.fishBowlFrameCounter[num11] >= Main.rand.Next(5, 3600))
						{
							Main.fishBowlFrameCounter[num11] = 0;
							if (Main.fishBowlFrame[num11] == 10)
							{
								if (Main.rand.Next(20) == 0)
								{
									Main.fishBowlFrame[num11] = 11;
									Main.fishBowlFrameMode[num11] = 0;
								}
								else
								{
									Main.fishBowlFrame[num11] = 1;
								}
							}
							else
							{
								Main.fishBowlFrame[num11]++;
							}
						}
					}
					else if (Main.fishBowlFrame[num11] <= 10)
					{
						if (Main.rand.Next(3600) == 0)
						{
							Main.fishBowlFrameMode[num11] = (byte)Main.rand.Next((int)maxValue);
						}
						Main.fishBowlFrameCounter[num11]++;
						if (Main.fishBowlFrameCounter[num11] >= 10)
						{
							Main.fishBowlFrameCounter[num11] = 0;
							if (Main.fishBowlFrame[num11] == 10)
							{
								if (Main.rand.Next(12) == 0)
								{
									Main.fishBowlFrame[num11] = 11;
								}
								else
								{
									Main.fishBowlFrame[num11] = 1;
								}
							}
							else
							{
								Main.fishBowlFrame[num11]++;
							}
						}
					}
					else if (Main.fishBowlFrame[num11] == 12 || Main.fishBowlFrame[num11] == 13)
					{
						Main.fishBowlFrameCounter[num11]++;
						if (Main.fishBowlFrameCounter[num11] >= 10)
						{
							Main.fishBowlFrameCounter[num11] = 0;
							Main.fishBowlFrame[num11]++;
							if (Main.fishBowlFrame[num11] > 13)
							{
								if (Main.rand.Next(20) == 0)
								{
									Main.fishBowlFrame[num11] = 14;
								}
								else
								{
									Main.fishBowlFrame[num11] = 12;
								}
							}
						}
					}
					else if (Main.fishBowlFrame[num11] >= 11)
					{
						Main.fishBowlFrameCounter[num11]++;
						if (Main.fishBowlFrameCounter[num11] >= 10)
						{
							Main.fishBowlFrameCounter[num11] = 0;
							Main.fishBowlFrame[num11]++;
							if (Main.fishBowlFrame[num11] > 16)
							{
								Main.fishBowlFrame[num11] = 4;
							}
						}
					}
				}
				for (int num12 = 0; num12 < 8; num12++)
				{
					for (int num13 = 0; num13 < Main.cageFrames; num13++)
					{
						Main.butterflyCageFrameCounter[num12, num13]++;
						if (Main.rand.Next(3600) == 0)
						{
							Main.butterflyCageMode[num12, num13] = (byte)Main.rand.Next(5);
							if (Main.rand.Next(2) == 0)
							{
								Main.butterflyCageMode[num12, num13] += 10;
							}
						}
						int num14 = Main.rand.Next(3, 16);
						if (Main.butterflyCageMode[num12, num13] == 1 || Main.butterflyCageMode[num12, num13] == 11)
						{
							num14 = 3;
						}
						if (Main.butterflyCageMode[num12, num13] == 2 || Main.butterflyCageMode[num12, num13] == 12)
						{
							num14 = 5;
						}
						if (Main.butterflyCageMode[num12, num13] == 3 || Main.butterflyCageMode[num12, num13] == 13)
						{
							num14 = 10;
						}
						if (Main.butterflyCageMode[num12, num13] == 4 || Main.butterflyCageMode[num12, num13] == 14)
						{
							num14 = 15;
						}
						if (Main.butterflyCageMode[num12, num13] >= 10)
						{
							if (Main.butterflyCageFrame[num12, num13] <= 7)
							{
								if (Main.butterflyCageFrameCounter[num12, num13] >= num14)
								{
									Main.butterflyCageFrameCounter[num12, num13] = 0;
									Main.butterflyCageFrame[num12, num13]--;
									if (Main.butterflyCageFrame[num12, num13] < 0)
									{
										Main.butterflyCageFrame[num12, num13] = 7;
									}
									if (Main.butterflyCageFrame[num12, num13] == 1 || Main.butterflyCageFrame[num12, num13] == 4 || Main.butterflyCageFrame[num12, num13] == 6)
									{
										if (Main.rand.Next(20) == 0)
										{
											Main.butterflyCageFrame[num12, num13] += 8;
										}
										else if (Main.rand.Next(6) == 0)
										{
											if (Main.butterflyCageMode[num12, num13] >= 10)
											{
												Main.butterflyCageMode[num12, num13] += 10;
											}
											else
											{
												Main.butterflyCageMode[num12, num13] += 10;
											}
										}
									}
								}
							}
							else if (Main.butterflyCageFrameCounter[num12, num13] >= num14)
							{
								Main.butterflyCageFrameCounter[num12, num13] = 0;
								Main.butterflyCageFrame[num12, num13]--;
								if (Main.butterflyCageFrame[num12, num13] < 8)
								{
									Main.butterflyCageFrame[num12, num13] = 14;
								}
								if (Main.butterflyCageFrame[num12, num13] == 9 || Main.butterflyCageFrame[num12, num13] == 12 || Main.butterflyCageFrame[num12, num13] == 14)
								{
									if (Main.rand.Next(20) == 0)
									{
										Main.butterflyCageFrame[num12, num13] -= 8;
									}
									else if (Main.rand.Next(6) == 0)
									{
										if (Main.butterflyCageMode[num12, num13] >= 10)
										{
											Main.butterflyCageMode[num12, num13] -= 10;
										}
										else
										{
											Main.butterflyCageMode[num12, num13] += 10;
										}
									}
								}
							}
						}
						else if (Main.butterflyCageFrame[num12, num13] <= 7)
						{
							if (Main.butterflyCageFrameCounter[num12, num13] >= num14)
							{
								Main.butterflyCageFrameCounter[num12, num13] = 0;
								Main.butterflyCageFrame[num12, num13]++;
								if (Main.butterflyCageFrame[num12, num13] > 7)
								{
									Main.butterflyCageFrame[num12, num13] = 0;
								}
								if ((Main.butterflyCageFrame[num12, num13] == 1 || Main.butterflyCageFrame[num12, num13] == 4 || Main.butterflyCageFrame[num12, num13] == 6) && Main.rand.Next(10) == 0)
								{
									Main.butterflyCageFrame[num12, num13] += 8;
								}
							}
						}
						else if (Main.butterflyCageFrameCounter[num12, num13] >= num14)
						{
							Main.butterflyCageFrameCounter[num12, num13] = 0;
							Main.butterflyCageFrame[num12, num13]++;
							if (Main.butterflyCageFrame[num12, num13] > 15)
							{
								Main.butterflyCageFrame[num12, num13] = 8;
							}
							if ((Main.butterflyCageFrame[num12, num13] == 9 || Main.butterflyCageFrame[num12, num13] == 12 || Main.butterflyCageFrame[num12, num13] == 14) && Main.rand.Next(10) == 0)
							{
								Main.butterflyCageFrame[num12, num13] -= 8;
							}
						}
					}
				}
			}
		}
		public void Update()
		{
			Main.ignoreErrors = true;
			if (Main.netMode == 2)
			{
				Main.cloudAlpha = Main.maxRaining;
			}
			if (Main.cloudAlpha > 0f)
			{
				Rain.MakeRain();
			}
			if (Main.netMode != 1)
			{
				this.updateCloudLayer();
			}
			this.UpdateWeather();
			Main.Ambience();
			if (Main.netMode != 2)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.snowing();
						goto IL_76;
					}
					catch
					{
						goto IL_76;
					}
				}
				Main.snowing();
			}
			IL_76:
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			WorldGen.destroyObject = false;
			if (Main.gameMenu)
			{
				Main.mapFullscreen = false;
			}
			if (Main.dedServ)
			{
				if (Main.dedServFPS)
				{
					Main.updateTime++;
					if (!Main.fpsTimer.IsRunning)
					{
						Main.fpsTimer.Restart();
					}
					if (Main.fpsTimer.ElapsedMilliseconds >= 1000L)
					{
						Main.dedServCount1 += Main.updateTime;
						Main.dedServCount2++;
						float num = (float)Main.dedServCount1 / (float)Main.dedServCount2;
						Console.WriteLine(string.Concat(new object[]
						{
							Main.updateTime,
							"  (",
							num,
							")"
						}));
						Main.updateTime = 0;
						Main.fpsTimer.Restart();
					}
				}
				else
				{
					if (Main.fpsTimer.IsRunning)
					{
						Main.fpsTimer.Stop();
					}
					Main.updateTime = 0;
				}
			}
			Main.gamePaused = false;
			Main.numPlayers = 0;
			int m = 0;
			while (m < 255)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.player[m].UpdatePlayer(m);
						goto IL_3365;
					}
					catch
					{
						goto IL_3365;
					}
					goto IL_3356;
				}
				goto IL_3356;
				IL_3365:
				m++;
				continue;
				IL_3356:
				Main.player[m].UpdatePlayer(m);
				goto IL_3365;
			}
			if (Main.netMode != 1)
			{
				try
				{
					NPC.SpawnNPC();
				}
				catch
				{
				}
			}
			for (int n = 0; n < 255; n++)
			{
				Main.player[n].activeNPCs = 0f;
				Main.player[n].townNPCs = 0f;
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
			int num9 = 0;
			while (num9 < 200)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.npc[num9].UpdateNPC(num9);
						goto IL_347A;
					}
					catch (Exception)
					{
						Main.npc[num9] = new NPC();
						goto IL_347A;
					}
					goto IL_346B;
				}
				goto IL_346B;
				IL_347A:
				num9++;
				continue;
				IL_346B:
				Main.npc[num9].UpdateNPC(num9);
				goto IL_347A;
			}
			int num10 = 0;
			while (num10 < 500)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.gore[num10].Update();
						goto IL_34C1;
					}
					catch
					{
						Main.gore[num10] = new Gore();
						goto IL_34C1;
					}
					goto IL_34B4;
				}
				goto IL_34B4;
				IL_34C1:
				num10++;
				continue;
				IL_34B4:
				Main.gore[num10].Update();
				goto IL_34C1;
			}
			int num11 = 0;
			while (num11 < 1000)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.projectile[num11].Update(num11);
						goto IL_350C;
					}
					catch
					{
						Main.projectile[num11] = new Projectile();
						goto IL_350C;
					}
					goto IL_34FD;
				}
				goto IL_34FD;
				IL_350C:
				num11++;
				continue;
				IL_34FD:
				Main.projectile[num11].Update(num11);
				goto IL_350C;
			}
			int num12 = 0;
			while (num12 < 400)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.item[num12].UpdateItem(num12);
						goto IL_3557;
					}
					catch
					{
						Main.item[num12] = new Item();
						goto IL_3557;
					}
					goto IL_3548;
				}
				goto IL_3548;
				IL_3557:
				num12++;
				continue;
				IL_3548:
				Main.item[num12].UpdateItem(num12);
				goto IL_3557;
			}
			if (Main.ignoreErrors)
			{
				try
				{
					Dust.UpdateDust();
					goto IL_359D;
				}
				catch
				{
					for (int num13 = 0; num13 < 6000; num13++)
					{
						Main.dust[num13] = new Dust();
					}
					goto IL_359D;
				}
			}
			Dust.UpdateDust();
			IL_359D:
			if (Main.ignoreErrors)
			{
				try
				{
					Main.UpdateTime();
					goto IL_35CB;
				}
				catch
				{
					Main.checkForSpawns = 0;
					goto IL_35CB;
				}
			}
			Main.UpdateTime();
			IL_35CB:
			if (Main.netMode != 1)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						WorldGen.UpdateWorld();
						Main.UpdateInvasion();
						goto IL_35F3;
					}
					catch
					{
						goto IL_35F3;
					}
				}
				WorldGen.UpdateWorld();
				Main.UpdateInvasion();
			}
			IL_35F3:
			if (Main.ignoreErrors)
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
					goto IL_363B;
				}
				catch
				{
					int arg_361E_0 = Main.netMode;
					goto IL_363B;
				}
			}
			if (Main.netMode == 2)
			{
				Main.UpdateServer();
			}
			if (Main.netMode == 1)
			{
				Main.UpdateClient();
			}
			IL_363B:
			IL_36DA:
			Main.upTimer = (float)stopwatch.Elapsed.TotalMilliseconds;
			if (Main.upTimerMaxDelay > 0f)
			{
				Main.upTimerMaxDelay -= 1f;
			}
			else
			{
				Main.upTimerMax = 0f;
			}
			if (Main.upTimer > Main.upTimerMax)
			{
				Main.upTimerMax = Main.upTimer;
				Main.upTimerMaxDelay = 400f;
			}
		}
		private static void UpdateMenu()
		{
			Main.playerInventory = false;
			Main.exitScale = 0.8f;
			if (Main.netMode == 0)
			{
				Main.maxRaining = 0f;
				Main.raining = false;
				if (!Main.grabSky)
				{
					Main.time += 86.4;
					if (!Main.dayTime)
					{
						if (Main.time > 32400.0)
						{
							Main.bloodMoon = false;
							Main.time = 0.0;
							Main.dayTime = true;
							Main.moonPhase++;
							if (Main.moonPhase >= 8)
							{
								Main.moonPhase = 0;
								return;
							}
						}
					}
					else if (Main.time > 54000.0)
					{
						Main.time = 0.0;
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
		public static void clrInput()
		{
			Main.keyCount = 0;
		}
		public static Color shine(Color newColor, int type)
		{
			int num = (int)newColor.R;
			int num2 = (int)newColor.G;
			int num3 = (int)newColor.B;
			float num4 = 0.6f;
			if (type == 25)
			{
				num = (int)((float)newColor.R * 0.95f);
				num2 = (int)((float)newColor.G * 0.85f);
				num3 = (int)((double)((float)newColor.B) * 1.1);
			}
			else if (type == 117)
			{
				num = (int)((float)newColor.R * 1.1f);
				num2 = (int)((float)newColor.G * 1f);
				num3 = (int)((double)((float)newColor.B) * 1.2);
			}
			else
			{
				if (type == 204)
				{
					num4 = 0.3f + (float)Main.mouseTextColor / 300f;
					num = (int)((float)newColor.R * (1.3f * num4));
					if (num > 255)
					{
						num = 255;
					}
					return new Color(num, num2, num3, 255);
				}
				if (type == 211)
				{
					num4 = 0.3f + (float)Main.mouseTextColor / 300f;
					num2 = (int)((float)newColor.G * (1.5f * num4));
					num3 = (int)((float)newColor.B * (1.1f * num4));
				}
				else if (type == 147 || type == 161)
				{
					num = (int)((float)newColor.R * 1.1f);
					num2 = (int)((float)newColor.G * 1.12f);
					num3 = (int)((double)((float)newColor.B) * 1.15);
				}
				else if (type == 163)
				{
					num = (int)((float)newColor.R * 1.05f);
					num2 = (int)((float)newColor.G * 1.1f);
					num3 = (int)((double)((float)newColor.B) * 1.15);
				}
				else if (type == 164)
				{
					num = (int)((float)newColor.R * 1.1f);
					num2 = (int)((float)newColor.G * 1.1f);
					num3 = (int)((double)((float)newColor.B) * 1.2);
				}
				else if (type == 178)
				{
					num4 = 0.5f;
					num = (int)((float)newColor.R * (1f + num4));
					num2 = (int)((float)newColor.G * (1f + num4));
					num3 = (int)((float)newColor.B * (1f + num4));
				}
				else if (type == 185 || type == 186)
				{
					num4 = 0.3f;
					num = (int)((float)newColor.R * (1f + num4));
					num2 = (int)((float)newColor.G * (1f + num4));
					num3 = (int)((float)newColor.B * (1f + num4));
				}
				else if (type >= 262 && type <= 268)
				{
					num3 += 100;
					num += 100;
					num2 += 100;
				}
				else
				{
					num = (int)((float)newColor.R * (1f + num4));
					num2 = (int)((float)newColor.G * (1f + num4));
					num3 = (int)((float)newColor.B * (1f + num4));
				}
			}
			if (num > 255)
			{
				num = 255;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			if (num3 > 255)
			{
				num3 = 255;
			}
			newColor.R = (byte)num;
			newColor.G = (byte)num2;
			newColor.B = (byte)num3;
			return new Color((int)((byte)num), (int)((byte)num2), (int)((byte)num3), (int)newColor.A);
		}
		public static float NPCAddHeight(int i)
		{
			float num = 0f;
			if (Main.npc[i].type == 125)
			{
				num = 30f;
			}
			else if (Main.npc[i].type == 205)
			{
				num = 8f;
			}
			else if (Main.npc[i].type == 182)
			{
				num = 24f;
			}
			else if (Main.npc[i].type == 178)
			{
				num = 2f;
			}
			else if (Main.npc[i].type == 126)
			{
				num = 30f;
			}
			else if (Main.npc[i].type == 6 || Main.npc[i].type == 173)
			{
				num = 26f;
			}
			else if (Main.npc[i].type == 94)
			{
				num = 14f;
			}
			else if (Main.npc[i].type == 7 || Main.npc[i].type == 8 || Main.npc[i].type == 9)
			{
				num = 13f;
			}
			else if (Main.npc[i].type == 98 || Main.npc[i].type == 99 || Main.npc[i].type == 100)
			{
				num = 13f;
			}
			else if (Main.npc[i].type == 95 || Main.npc[i].type == 96 || Main.npc[i].type == 97)
			{
				num = 13f;
			}
			else if (Main.npc[i].type == 10 || Main.npc[i].type == 11 || Main.npc[i].type == 12)
			{
				num = 8f;
			}
			else if (Main.npc[i].type == 13 || Main.npc[i].type == 14 || Main.npc[i].type == 15)
			{
				num = 26f;
			}
			else if (Main.npc[i].type == 175)
			{
				num = 4f;
			}
			else if (Main.npc[i].type == 48)
			{
				num = 32f;
			}
			else if (Main.npc[i].type == 49 || Main.npc[i].type == 51)
			{
				num = 4f;
			}
			else if (Main.npc[i].type == 60)
			{
				num = 10f;
			}
			else if (Main.npc[i].type == 62 || Main.npc[i].type == 66 || Main.npc[i].type == 156)
			{
				num = 14f;
			}
			else if (Main.npc[i].type == 63 || Main.npc[i].type == 64 || Main.npc[i].type == 103)
			{
				num = 4f;
			}
			else if (Main.npc[i].type == 65)
			{
				num = 14f;
			}
			else if (Main.npc[i].type == 69)
			{
				num = 4f;
			}
			else if (Main.npc[i].type == 70)
			{
				num = -4f;
			}
			else if (Main.npc[i].type == 72)
			{
				num = -2f;
			}
			else if (Main.npc[i].type == 83 || Main.npc[i].type == 84)
			{
				num = 20f;
			}
			else if (Main.npc[i].type == 150 || Main.npc[i].type == 151 || Main.npc[i].type == 158)
			{
				num = 10f;
			}
			else if (Main.npc[i].type == 152)
			{
				num = 6f;
			}
			else if (Main.npc[i].type == 153 || Main.npc[i].type == 154)
			{
				num = 4f;
			}
			else if (Main.npc[i].type == 165 || Main.npc[i].type == 237 || Main.npc[i].type == 238 || Main.npc[i].type == 240)
			{
				num = 10f;
			}
			else if (Main.npc[i].type == 39 || Main.npc[i].type == 40 || Main.npc[i].type == 41)
			{
				num = 26f;
			}
			else if (Main.npc[i].type >= 87 && Main.npc[i].type <= 92)
			{
				num = 56f;
			}
			else if (Main.npc[i].type >= 134 && Main.npc[i].type <= 136)
			{
				num = 30f;
			}
			else if (Main.npc[i].type == 169)
			{
				num = 8f;
			}
			else if (Main.npc[i].type == 174)
			{
				num = 6f;
			}
			return num * Main.npc[i].scale;
		}
		private static void HelpText()
		{
			bool flag = false;
			if (Main.player[Main.myPlayer].statLifeMax > 100)
			{
				flag = true;
			}
			bool flag2 = false;
			if (Main.player[Main.myPlayer].statManaMax > 0)
			{
				flag2 = true;
			}
			bool flag3 = true;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			bool flag8 = false;
			bool flag9 = false;
			for (int i = 0; i < 58; i++)
			{
				if (Main.player[Main.myPlayer].inventory[i].pick > 0 && Main.player[Main.myPlayer].inventory[i].name != "Copper Pickaxe")
				{
					flag3 = false;
				}
				if (Main.player[Main.myPlayer].inventory[i].axe > 0 && Main.player[Main.myPlayer].inventory[i].name != "Copper Axe")
				{
					flag3 = false;
				}
				if (Main.player[Main.myPlayer].inventory[i].hammer > 0)
				{
					flag3 = false;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 11 || Main.player[Main.myPlayer].inventory[i].type == 12 || Main.player[Main.myPlayer].inventory[i].type == 13 || Main.player[Main.myPlayer].inventory[i].type == 14)
				{
					flag4 = true;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 19 || Main.player[Main.myPlayer].inventory[i].type == 20 || Main.player[Main.myPlayer].inventory[i].type == 21 || Main.player[Main.myPlayer].inventory[i].type == 22)
				{
					flag5 = true;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 75)
				{
					flag6 = true;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 38)
				{
					flag7 = true;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 68 || Main.player[Main.myPlayer].inventory[i].type == 70)
				{
					flag8 = true;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 84)
				{
					flag9 = true;
				}
			}
			bool flag10 = false;
			bool flag11 = false;
			bool flag12 = false;
			bool flag13 = false;
			bool flag14 = false;
			bool flag15 = false;
			bool flag16 = false;
			bool flag17 = false;
			bool flag18 = false;
			for (int j = 0; j < 200; j++)
			{
				if (Main.npc[j].active)
				{
					if (Main.npc[j].type == 17)
					{
						flag10 = true;
					}
					if (Main.npc[j].type == 18)
					{
						flag11 = true;
					}
					if (Main.npc[j].type == 19)
					{
						flag13 = true;
					}
					if (Main.npc[j].type == 20)
					{
						flag12 = true;
					}
					if (Main.npc[j].type == 54)
					{
						flag18 = true;
					}
					if (Main.npc[j].type == 124)
					{
						flag15 = true;
					}
					if (Main.npc[j].type == 107)
					{
						flag14 = true;
					}
					if (Main.npc[j].type == 108)
					{
						flag16 = true;
					}
					if (Main.npc[j].type == 38)
					{
						flag17 = true;
					}
				}
			}
			while (true)
			{
				Main.helpText++;
				if (flag3)
				{
					if (Main.helpText == 1)
					{
						break;
					}
					if (Main.helpText == 2)
					{
						goto Block_31;
					}
					if (Main.helpText == 3)
					{
						goto Block_32;
					}
					if (Main.helpText == 4)
					{
						goto Block_33;
					}
					if (Main.helpText == 5)
					{
						goto Block_34;
					}
					if (Main.helpText == 6)
					{
						goto Block_35;
					}
				}
				if (flag3 && !flag4 && !flag5 && Main.helpText == 11)
				{
					goto Block_39;
				}
				if (flag3 && flag4 && !flag5)
				{
					if (Main.helpText == 21)
					{
						goto Block_43;
					}
					if (Main.helpText == 22)
					{
						goto Block_44;
					}
				}
				if (flag3 && flag5)
				{
					if (Main.helpText == 31)
					{
						goto Block_47;
					}
					if (Main.helpText == 32)
					{
						goto Block_48;
					}
				}
				if (!flag && Main.helpText == 41)
				{
					goto Block_50;
				}
				if (!flag2 && Main.helpText == 42)
				{
					goto Block_52;
				}
				if (!flag2 && !flag6 && Main.helpText == 43)
				{
					goto Block_55;
				}
				if (!flag10 && !flag11)
				{
					if (Main.helpText == 51)
					{
						goto Block_58;
					}
					if (Main.helpText == 52)
					{
						goto Block_59;
					}
					if (Main.helpText == 53)
					{
						goto Block_60;
					}
					if (Main.helpText == 54)
					{
						goto Block_61;
					}
				}
				if (!flag10 && Main.helpText == 61)
				{
					goto Block_63;
				}
				if (!flag11 && Main.helpText == 62)
				{
					goto Block_65;
				}
				if (!flag13 && Main.helpText == 63)
				{
					goto Block_67;
				}
				if (!flag12 && Main.helpText == 64)
				{
					goto Block_69;
				}
				if (!flag15 && Main.helpText == 65 && NPC.downedBoss3)
				{
					goto Block_72;
				}
				if (!flag18 && Main.helpText == 66 && NPC.downedBoss3)
				{
					goto Block_75;
				}
				if (!flag14 && Main.helpText == 67)
				{
					goto Block_77;
				}
				if (!flag17 && NPC.downedBoss2 && Main.helpText == 68)
				{
					goto Block_80;
				}
				if (!flag16 && Main.hardMode && Main.helpText == 69)
				{
					goto Block_83;
				}
				if (flag7 && Main.helpText == 71)
				{
					goto Block_85;
				}
				if (flag8 && Main.helpText == 72)
				{
					goto Block_87;
				}
				if ((flag7 || flag8) && Main.helpText == 80)
				{
					goto Block_89;
				}
				if (!flag9 && Main.helpText == 201 && !Main.hardMode && !NPC.downedBoss3 && !NPC.downedBoss2)
				{
					goto Block_94;
				}
				if (Main.helpText == 1000 && !NPC.downedBoss1 && !NPC.downedBoss2)
				{
					goto Block_97;
				}
				if (Main.helpText == 1001 && !NPC.downedBoss1 && !NPC.downedBoss2)
				{
					goto Block_100;
				}
				if (Main.helpText == 1002 && !NPC.downedBoss2)
				{
					goto Block_102;
				}
				if (Main.helpText == 1050 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statLifeMax < 200)
				{
					goto Block_106;
				}
				if (Main.helpText == 1051 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statDefense <= 10)
				{
					goto Block_109;
				}
				if (Main.helpText == 1052 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statLifeMax >= 200 && Main.player[Main.myPlayer].statDefense > 10)
				{
					goto Block_113;
				}
				if (Main.helpText == 1053 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax < 300)
				{
					goto Block_117;
				}
				if (Main.helpText == 1054 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax >= 300)
				{
					goto Block_121;
				}
				if (Main.helpText == 1055 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax >= 300)
				{
					goto Block_125;
				}
				if (Main.helpText == 1056 && NPC.downedBoss1 && NPC.downedBoss2 && !NPC.downedBoss3)
				{
					goto Block_129;
				}
				if (Main.helpText == 1057 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax < 400)
				{
					goto Block_135;
				}
				if (Main.helpText == 1058 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
				{
					goto Block_141;
				}
				if (Main.helpText == 1059 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
				{
					goto Block_147;
				}
				if (Main.helpText == 1060 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
				{
					goto Block_153;
				}
				if (Main.helpText == 1061 && Main.hardMode)
				{
					goto Block_155;
				}
				if (Main.helpText == 1062 && Main.hardMode)
				{
					goto Block_157;
				}
				if (Main.helpText > 1100)
				{
					Main.helpText = 0;
				}
			}
			Main.npcChatText = Lang.dialog(177, false);
			return;
			Block_31:
			Main.npcChatText = Lang.dialog(178, false);
			return;
			Block_32:
			Main.npcChatText = Lang.dialog(179, false);
			return;
			Block_33:
			Main.npcChatText = Lang.dialog(180, false);
			return;
			Block_34:
			Main.npcChatText = Lang.dialog(181, false);
			return;
			Block_35:
			Main.npcChatText = Lang.dialog(182, false);
			return;
			Block_39:
			Main.npcChatText = Lang.dialog(183, false);
			return;
			Block_43:
			Main.npcChatText = Lang.dialog(184, false);
			return;
			Block_44:
			Main.npcChatText = Lang.dialog(185, false);
			return;
			Block_47:
			Main.npcChatText = Lang.dialog(186, false);
			return;
			Block_48:
			Main.npcChatText = Lang.dialog(187, false);
			return;
			Block_50:
			Main.npcChatText = Lang.dialog(188, false);
			return;
			Block_52:
			Main.npcChatText = Lang.dialog(189, false);
			return;
			Block_55:
			Main.npcChatText = Lang.dialog(190, false);
			return;
			Block_58:
			Main.npcChatText = Lang.dialog(191, false);
			return;
			Block_59:
			Main.npcChatText = Lang.dialog(192, false);
			return;
			Block_60:
			Main.npcChatText = Lang.dialog(193, false);
			return;
			Block_61:
			Main.npcChatText = Lang.dialog(194, false);
			return;
			Block_63:
			Main.npcChatText = Lang.dialog(195, false);
			return;
			Block_65:
			Main.npcChatText = Lang.dialog(196, false);
			return;
			Block_67:
			Main.npcChatText = Lang.dialog(197, false);
			return;
			Block_69:
			Main.npcChatText = Lang.dialog(198, false);
			return;
			Block_72:
			Main.npcChatText = Lang.dialog(199, false);
			return;
			Block_75:
			Main.npcChatText = Lang.dialog(200, false);
			return;
			Block_77:
			Main.npcChatText = Lang.dialog(201, false);
			return;
			Block_80:
			Main.npcChatText = Lang.dialog(202, false);
			return;
			Block_83:
			Main.npcChatText = Lang.dialog(203, false);
			return;
			Block_85:
			Main.npcChatText = Lang.dialog(204, false);
			return;
			Block_87:
			Main.npcChatText = Lang.dialog(205, false);
			return;
			Block_89:
			Main.npcChatText = Lang.dialog(206, false);
			return;
			Block_94:
			Main.npcChatText = Lang.dialog(207, false);
			return;
			Block_97:
			Main.npcChatText = Lang.dialog(208, false);
			return;
			Block_100:
			Main.npcChatText = Lang.dialog(209, false);
			return;
			Block_102:
			if (WorldGen.crimson)
			{
				Main.npcChatText = Lang.dialog(331, false);
				return;
			}
			Main.npcChatText = Lang.dialog(210, false);
			return;
			Block_106:
			Main.npcChatText = Lang.dialog(211, false);
			return;
			Block_109:
			Main.npcChatText = Lang.dialog(212, false);
			return;
			Block_113:
			Main.npcChatText = Lang.dialog(213, false);
			return;
			Block_117:
			Main.npcChatText = Lang.dialog(214, false);
			return;
			Block_121:
			Main.npcChatText = Lang.dialog(215, false);
			return;
			Block_125:
			Main.npcChatText = Lang.dialog(216, false);
			return;
			Block_129:
			Main.npcChatText = Lang.dialog(217, false);
			return;
			Block_135:
			Main.npcChatText = Lang.dialog(218, false);
			return;
			Block_141:
			Main.npcChatText = Lang.dialog(219, false);
			return;
			Block_147:
			Main.npcChatText = Lang.dialog(220, false);
			return;
			Block_153:
			Main.npcChatText = Lang.dialog(221, false);
			return;
			Block_155:
			Main.npcChatText = Lang.dialog(222, false);
			return;
			Block_157:
			Main.npcChatText = Lang.dialog(223, false);
		}
		private static bool AccCheck(Item newItem, int slot)
		{
			if (Main.player[Main.myPlayer].armor[slot].IsTheSameAs(newItem))
			{
				return false;
			}
			for (int i = 0; i < Main.player[Main.myPlayer].armor.Length; i++)
			{
				if (newItem.IsTheSameAs(Main.player[Main.myPlayer].armor[i]))
				{
					return true;
				}
			}
			return false;
		}
		public static Item dyeSwap(Item newItem)
		{
			if (newItem.dye <= 0)
			{
				return newItem;
			}
			for (int i = 0; i < 8; i++)
			{
				if (Main.player[Main.myPlayer].dye[i].type == 0)
				{
					Main.dyeSlotCount = i;
					break;
				}
			}
			if (Main.dyeSlotCount >= 8)
			{
				Main.dyeSlotCount = 0;
			}
			if (Main.dyeSlotCount < 0)
			{
				Main.dyeSlotCount = 7;
			}
			Item result = Main.player[Main.myPlayer].dye[Main.dyeSlotCount].Clone();
			Main.player[Main.myPlayer].dye[Main.dyeSlotCount] = newItem.Clone();
			Main.dyeSlotCount++;
			if (Main.dyeSlotCount >= 8)
			{
				Main.accSlotCount = 0;
			}
			Main.PlaySound(7, -1, -1, 1);
			Recipe.FindRecipes();
			return result;
		}
		public static Item armorSwap(Item newItem)
		{
			for (int i = 0; i < Main.player[Main.myPlayer].armor.Length; i++)
			{
				if (newItem.IsTheSameAs(Main.player[Main.myPlayer].armor[i]))
				{
					Main.accSlotCount = i;
				}
			}
			if (newItem.headSlot == -1 && newItem.bodySlot == -1 && newItem.legSlot == -1 && !newItem.accessory)
			{
				return newItem;
			}
			Item result = newItem;
			if (newItem.headSlot != -1)
			{
				result = Main.player[Main.myPlayer].armor[0].Clone();
				Main.player[Main.myPlayer].armor[0] = newItem.Clone();
			}
			else if (newItem.bodySlot != -1)
			{
				result = Main.player[Main.myPlayer].armor[1].Clone();
				Main.player[Main.myPlayer].armor[1] = newItem.Clone();
			}
			else if (newItem.legSlot != -1)
			{
				result = Main.player[Main.myPlayer].armor[2].Clone();
				Main.player[Main.myPlayer].armor[2] = newItem.Clone();
			}
			else if (newItem.accessory)
			{
				for (int j = 3; j < 8; j++)
				{
					if (Main.player[Main.myPlayer].armor[j].type == 0)
					{
						Main.accSlotCount = j - 3;
						break;
					}
				}
				for (int k = 0; k < Main.player[Main.myPlayer].armor.Length; k++)
				{
					if (newItem.IsTheSameAs(Main.player[Main.myPlayer].armor[k]))
					{
						Main.accSlotCount = k - 3;
					}
				}
				if (Main.accSlotCount >= 5)
				{
					Main.accSlotCount = 0;
				}
				if (Main.accSlotCount < 0)
				{
					Main.accSlotCount = 4;
				}
				result = Main.player[Main.myPlayer].armor[3 + Main.accSlotCount].Clone();
				Main.player[Main.myPlayer].armor[3 + Main.accSlotCount] = newItem.Clone();
				Main.accSlotCount++;
				if (Main.accSlotCount >= 5)
				{
					Main.accSlotCount = 0;
				}
			}
			Main.PlaySound(7, -1, -1, 1);
			Recipe.FindRecipes();
			return result;
		}
		public static void MoveCoins(Item[] pInv, Item[] cInv)
		{
			int[] array = new int[4];
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			bool flag = false;
			int[] array2 = new int[]
			{
				-1,
				-1,
				-1,
				-1
			};
			for (int i = 0; i < cInv.Length; i++)
			{
				if (cInv[i].stack < 1 || cInv[i].type < 1)
				{
					list2.Add(i);
					cInv[i] = new Item();
				}
				if (cInv[i] != null && cInv[i].stack > 0)
				{
					int num = 0;
					if (cInv[i].type == 71)
					{
						num = 1;
						array2[0] = i;
					}
					if (cInv[i].type == 72)
					{
						num = 2;
						array2[1] = i;
					}
					if (cInv[i].type == 73)
					{
						num = 3;
						array2[2] = i;
					}
					if (cInv[i].type == 74)
					{
						num = 4;
						array2[3] = i;
					}
					if (num > 0)
					{
						array[num - 1] += cInv[i].stack;
						list2.Add(i);
						cInv[i] = new Item();
						flag = true;
					}
				}
			}
			if (!flag)
			{
				return;
			}
			Main.PlaySound(7, -1, -1, 1);
			for (int j = 0; j < pInv.Length; j++)
			{
				if (pInv[j] != null && pInv[j].stack > 0)
				{
					int num2 = 0;
					if (pInv[j].type == 71)
					{
						num2 = 1;
					}
					if (pInv[j].type == 72)
					{
						num2 = 2;
					}
					if (pInv[j].type == 73)
					{
						num2 = 3;
					}
					if (pInv[j].type == 74)
					{
						num2 = 4;
					}
					if (num2 > 0)
					{
						array[num2 - 1] += pInv[j].stack;
						list.Add(j);
						pInv[j] = new Item();
					}
				}
			}
			for (int k = 0; k < 3; k++)
			{
				while (array[k] > 100)
				{
					array[k] -= 100;
					array[k + 1]++;
				}
			}
			for (int l = 0; l < 4; l++)
			{
				if (array2[l] >= 0)
				{
					int num3 = array2[l];
					int num4 = l;
					if (array[num4] > 0)
					{
						cInv[num3].SetDefaults(71 + num4, false);
						cInv[num3].stack = array[num4];
						if (cInv[num3].stack > cInv[num3].maxStack)
						{
							cInv[num3].stack = cInv[num3].maxStack;
						}
						array[num4] -= cInv[num3].stack;
					}
					if (Main.netMode == 1 && Main.player[Main.myPlayer].chest > -1)
					{
						NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)list2[0], 0f, 0f, 0);
					}
				}
			}
			while (list2.Count > 0)
			{
				int num5 = list2[0];
				for (int m = 3; m >= 0; m--)
				{
					if (array[m] > 0)
					{
						cInv[num5].SetDefaults(71 + m, false);
						cInv[num5].stack = array[m];
						if (cInv[num5].stack > cInv[num5].maxStack)
						{
							cInv[num5].stack = cInv[num5].maxStack;
						}
						array[m] -= cInv[num5].stack;
						break;
					}
				}
				if (Main.netMode == 1 && Main.player[Main.myPlayer].chest > -1)
				{
					NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)list2[0], 0f, 0f, 0);
				}
				list2.RemoveAt(0);
			}
			while (list.Count > 0)
			{
				int num6 = list[0];
				for (int n = 3; n >= 0; n--)
				{
					if (array[n] > 0)
					{
						pInv[num6].SetDefaults(71 + n, false);
						pInv[num6].stack = array[n];
						if (pInv[num6].stack > pInv[num6].maxStack)
						{
							pInv[num6].stack = pInv[num6].maxStack;
						}
						array[n] -= pInv[num6].stack;
					}
				}
				list.RemoveAt(0);
			}
		}
		public static int GetTreeStyle(int X)
		{
			int num;
			if (X <= Main.treeX[0])
			{
				num = Main.treeStyle[0];
			}
			else if (X <= Main.treeX[1])
			{
				num = Main.treeStyle[1];
			}
			else if (X <= Main.treeX[2])
			{
				num = Main.treeStyle[2];
			}
			else
			{
				num = Main.treeStyle[3];
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
		public void UpdateWeather()
		{
			Main.cloudLimit = 200;
			if (Main.windSpeed < Main.windSpeedSet)
			{
				Main.windSpeed += 0.001f * (float)Main.dayRate;
				if (Main.windSpeed > Main.windSpeedSet)
				{
					Main.windSpeed = Main.windSpeedSet;
				}
			}
			else if (Main.windSpeed > Main.windSpeedSet)
			{
				Main.windSpeed -= 0.001f * (float)Main.dayRate;
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
			Main.windSpeedSpeed += (float)Main.rand.Next(-10, 11) * 0.0001f;
			if (!Main.dayTime)
			{
				Main.windSpeedSpeed += (float)Main.rand.Next(-10, 11) * 0.0002f;
			}
			if ((double)Main.windSpeedSpeed < -0.002)
			{
				Main.windSpeedSpeed = -0.002f;
			}
			if ((double)Main.windSpeedSpeed > 0.002)
			{
				Main.windSpeedSpeed = 0.002f;
			}
			Main.windSpeedTemp += Main.windSpeedSpeed;
			if (Main.raining)
			{
				Main.windSpeedTemp += Main.windSpeedSpeed * 2f;
			}
			float num = 0.3f + 0.5f * Main.cloudAlpha;
			if (Main.windSpeedTemp < -num)
			{
				Main.windSpeedTemp = -num;
			}
			if (Main.windSpeedTemp > num)
			{
				Main.windSpeedTemp = num;
			}
			if (Main.rand.Next(60) == 0)
			{
				Main.numCloudsTemp += Main.rand.Next(-1, 2);
			}
			if ((float)Main.rand.Next(1000) < 50f * Main.cloudBGAlpha)
			{
				Main.numCloudsTemp++;
			}
			if ((float)Main.rand.Next(1000) < 25f * (1f - Main.cloudBGAlpha))
			{
				Main.numCloudsTemp--;
			}
			if ((float)Main.rand.Next(1000) < 200f * Main.cloudAlpha && Main.numCloudsTemp < Main.cloudLimit / 2)
			{
				Main.numCloudsTemp++;
			}
			if ((float)Main.rand.Next(1000) < 50f * Main.cloudAlpha)
			{
				Main.numCloudsTemp++;
			}
			if (Main.numCloudsTemp > Main.cloudLimit / 4 && Main.rand.Next(100) == 0)
			{
				Main.numCloudsTemp -= Main.rand.Next(1, 3);
			}
			if (Main.numCloudsTemp < Main.cloudLimit / 4 && Main.rand.Next(100) == 0)
			{
				Main.numCloudsTemp += Main.rand.Next(1, 3);
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
			Main.weatherCounter -= Main.dayRate;
			if (Main.weatherCounter <= 0)
			{
				Main.numClouds = Main.numCloudsTemp;
				Main.windSpeedSet = Main.windSpeedTemp;
				Main.weatherCounter = Main.rand.Next(3600, 18000);
				if (Main.netMode == 2)
				{
					NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
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
							NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
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
					Main.InvasionWarning();
					Main.invasionType = 0;
					Main.invasionDelay = 7;
				}
				if (Main.invasionX == (double)Main.spawnTileX)
				{
					return;
				}
				float num = (float)Main.dayRate;
				if (Main.invasionX > (double)Main.spawnTileX)
				{
					Main.invasionX -= (double)num;
					if (Main.invasionX <= (double)Main.spawnTileX)
					{
						Main.invasionX = (double)Main.spawnTileX;
						Main.InvasionWarning();
					}
					else
					{
						Main.invasionWarn--;
					}
				}
				else if (Main.invasionX < (double)Main.spawnTileX)
				{
					Main.invasionX += (double)num;
					if (Main.invasionX >= (double)Main.spawnTileX)
					{
						Main.invasionX = (double)Main.spawnTileX;
						Main.InvasionWarning();
					}
					else
					{
						Main.invasionWarn--;
					}
				}
				if (Main.invasionWarn <= 0)
				{
					Main.invasionWarn = 3600;
					Main.InvasionWarning();
				}
			}
		}
		private static void InvasionWarning()
		{
			string text;
			if (Main.invasionSize <= 0)
			{
				if (Main.invasionType == 2)
				{
					text = Lang.misc[4];
				}
				else if (Main.invasionType == 3)
				{
					text = Lang.misc[24];
				}
				else
				{
					text = Lang.misc[0];
				}
			}
			else if (Main.invasionX < (double)Main.spawnTileX)
			{
				if (Main.invasionType == 2)
				{
					text = Lang.misc[5];
				}
				else if (Main.invasionType == 3)
				{
					text = Lang.misc[25];
				}
				else
				{
					text = Lang.misc[1];
				}
			}
			else if (Main.invasionX > (double)Main.spawnTileX)
			{
				if (Main.invasionType == 2)
				{
					text = Lang.misc[6];
				}
				else if (Main.invasionType == 3)
				{
					text = Lang.misc[26];
				}
				else
				{
					text = Lang.misc[2];
				}
			}
			else if (Main.invasionType == 2)
			{
				text = Lang.misc[7];
			}
			else if (Main.invasionType == 3)
			{
				text = Lang.misc[27];
			}
			else
			{
				text = Lang.misc[3];
			}
			if (Main.netMode == 0)
			{
				Main.NewText(text, 175, 75, 255, false);
				return;
			}
			if (Main.netMode == 2)
			{
				NetMessage.SendData(25, -1, -1, text, 255, 175f, 75f, 255f, 0);
			}
		}
		public static void StartInvasion(int type = 1)
		{
			if (Main.invasionType == 0 && Main.invasionDelay == 0)
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
					Main.invasionSize = 80 + 40 * num;
					if (type == 3)
					{
						Main.invasionSize += 40 + 20 * num;
					}
					Main.invasionWarn = 0;
					if (Main.rand.Next(2) == 0)
					{
						Main.invasionX = 0.0;
						return;
					}
					Main.invasionX = (double)Main.maxTilesX;
				}
			}
		}
		private static void UpdateClient()
		{
			if (Main.myPlayer == 255)
			{
				Netplay.disconnect = true;
			}
			Main.netPlayCounter++;
			if (Main.netPlayCounter > 3600)
			{
				Main.netPlayCounter = 0;
			}
			if (Math.IEEERemainder((double)Main.netPlayCounter, 420.0) == 0.0)
			{
				NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
			}
			if (Math.IEEERemainder((double)Main.netPlayCounter, 900.0) == 0.0)
			{
				NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				NetMessage.SendData(16, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				NetMessage.SendData(40, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
			}
			if (Netplay.clientSock.active)
			{
				Netplay.clientSock.timeOut++;
				if (!Main.stopTimeOuts && Netplay.clientSock.timeOut > 60 * Main.timeOut)
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
		private static void UpdateServer()
		{
			Main.netPlayCounter++;
			if (Main.netPlayCounter > 3600)
			{
				NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
				NetMessage.syncPlayers();
				Main.netPlayCounter = 0;
			}
			for (int i = 0; i < Main.maxNetPlayers; i++)
			{
				if (Main.player[i].active && Netplay.serverSock[i].active)
				{
					Netplay.serverSock[i].SpamUpdate();
				}
			}
			if (Math.IEEERemainder((double)Main.netPlayCounter, 900.0) == 0.0)
			{
				bool flag = true;
				int num = Main.lastItemUpdate;
				int num2 = 0;
				while (flag)
				{
					num++;
					if (num >= 400)
					{
						num = 0;
					}
					num2++;
					if (!Main.item[num].active || Main.item[num].owner == 255)
					{
						NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0);
					}
					if (num2 >= Main.maxItemUpdates || num == Main.lastItemUpdate)
					{
						flag = false;
					}
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
				if (Netplay.serverSock[k].active)
				{
					Netplay.serverSock[k].timeOut++;
					if (!Main.stopTimeOuts && Netplay.serverSock[k].timeOut > 60 * Main.timeOut)
					{
						Netplay.serverSock[k].kill = true;
					}
				}
				if (Main.player[k].active)
				{
					ServerSock.CheckSection(k, Main.player[k].position);
				}
			}
		}
		public static void NewText(string newText, byte R = 255, byte G = 255, byte B = 255, bool force = false)
		{
		}
		public static void StopRain()
		{
			Main.rainTime = 0;
			Main.raining = false;
			Main.maxRaining = 0f;
		}
		public static void StartRain()
		{
			int num = 86400;
			int num2 = num / 24;
			Main.rainTime = Main.rand.Next(num2 * 8, num);
			if (Main.rand.Next(3) == 0)
			{
				Main.rainTime += Main.rand.Next(0, num2);
			}
			if (Main.rand.Next(4) == 0)
			{
				Main.rainTime += Main.rand.Next(0, num2 * 2);
			}
			if (Main.rand.Next(5) == 0)
			{
				Main.rainTime += Main.rand.Next(0, num2 * 2);
			}
			if (Main.rand.Next(6) == 0)
			{
				Main.rainTime += Main.rand.Next(0, num2 * 3);
			}
			if (Main.rand.Next(7) == 0)
			{
				Main.rainTime += Main.rand.Next(0, num2 * 4);
			}
			if (Main.rand.Next(8) == 0)
			{
				Main.rainTime += Main.rand.Next(0, num2 * 5);
			}
			float num3 = 1f;
			if (Main.rand.Next(2) == 0)
			{
				num3 += 0.05f;
			}
			if (Main.rand.Next(3) == 0)
			{
				num3 += 0.1f;
			}
			if (Main.rand.Next(4) == 0)
			{
				num3 += 0.15f;
			}
			if (Main.rand.Next(5) == 0)
			{
				num3 += 0.2f;
			}
			Main.rainTime = (int)((float)Main.rainTime * num3);
			Main.ChangeRain();
			Main.raining = true;
		}
		private static void ChangeRain()
		{
			if (Main.cloudBGActive >= 1f || (double)Main.numClouds > 150.0)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.maxRaining = (float)Main.rand.Next(20, 90) * 0.01f;
					return;
				}
				Main.maxRaining = (float)Main.rand.Next(40, 90) * 0.01f;
				return;
			}
			else if ((double)Main.numClouds > 100.0)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.maxRaining = (float)Main.rand.Next(10, 70) * 0.01f;
					return;
				}
				Main.maxRaining = (float)Main.rand.Next(20, 60) * 0.01f;
				return;
			}
			else
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.maxRaining = (float)Main.rand.Next(5, 40) * 0.01f;
					return;
				}
				Main.maxRaining = (float)Main.rand.Next(5, 30) * 0.01f;
				return;
			}
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
			if ((Main.netMode != 1 && !Main.gameMenu) || Main.netMode == 2)
			{
				if (Main.raining)
				{
					Main.rainTime -= Main.dayRate;
					int num = 86400;
					num /= Main.dayRate;
					int num2 = num / 24;
					if (Main.rainTime <= 0)
					{
						Main.StopRain();
					}
					else if (Main.rand.Next(num2 * 2) == 0)
					{
						Main.ChangeRain();
					}
				}
				else
				{
					int num3 = 86400;
					num3 /= Main.dayRate;
					if (Main.rand.Next((int)((double)num3 * 5.5)) == 0)
					{
						Main.StartRain();
					}
					else if (Main.cloudBGActive >= 1f && Main.rand.Next(num3 * 4) == 0)
					{
						Main.StartRain();
					}
				}
			}
			if (Main.maxRaining != Main.oldMaxRaining)
			{
				if (Main.netMode == 2)
				{
					NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
				}
				Main.oldMaxRaining = Main.maxRaining;
			}
			Main.time += (double)Main.dayRate;
			if (Main.netMode != 1)
			{
				if (NPC.travelNPC)
				{
					if (!Main.dayTime || Main.time > 48600.0)
					{
						WorldGen.UnspawnTravelNPC();
					}
				}
				else if (Main.dayTime && Main.time < 27000.0)
				{
					int num4 = (int)(27000.0 / (double)Main.dayRate);
					num4 *= 4;
					if (Main.rand.Next(num4) == 0)
					{
						int num5 = 0;
						for (int i = 0; i < 200; i++)
						{
							if (Main.npc[i].active && Main.npc[i].townNPC && Main.npc[i].type != 37)
							{
								num5++;
							}
						}
						if (num5 >= 2)
						{
							WorldGen.SpawnTravelNPC();
						}
					}
				}
				NPC.travelNPC = false;
			}
			if (!Main.dayTime)
			{
				Main.eclipse = false;
				if (WorldGen.spawnHardBoss > 0 && Main.netMode != 1 && Main.time > 4860.0)
				{
					bool flag = false;
					for (int k = 0; k < 200; k++)
					{
						if (Main.npc[k].active && Main.npc[k].boss)
						{
							flag = true;
						}
					}
					if (!flag)
					{
						int l = 0;
						while (l < 255)
						{
							if (Main.player[l].active && !Main.player[l].dead && (double)Main.player[l].position.Y < Main.worldSurface * 16.0)
							{
								if (WorldGen.spawnHardBoss == 1)
								{
									NPC.SpawnOnPlayer(l, 134);
									break;
								}
								if (WorldGen.spawnHardBoss == 2)
								{
									NPC.SpawnOnPlayer(l, 125);
									NPC.SpawnOnPlayer(l, 126);
									break;
								}
								if (WorldGen.spawnHardBoss == 3)
								{
									NPC.SpawnOnPlayer(l, 127);
									break;
								}
								break;
							}
							else
							{
								l++;
							}
						}
					}
					WorldGen.spawnHardBoss = 0;
				}
				if (Main.time > 32400.0)
				{
					Main.checkXMas();
					Main.checkHalloween();
					if (Main.invasionDelay > 0)
					{
						Main.invasionDelay--;
					}
					WorldGen.spawnNPC = 0;
					Main.checkForSpawns = 0;
					Main.time = 0.0;
					Main.bloodMoon = false;
					Main.stopMoonEvent();
					Main.dayTime = true;
					Main.moonPhase++;
					if (Main.moonPhase >= 8)
					{
						Main.moonPhase = 0;
					}
					if (Main.netMode == 2)
					{
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
						WorldGen.saveAndPlay();
					}
					if (Main.netMode != 1 && WorldGen.shadowOrbSmashed)
					{
						if (!NPC.downedGoblins)
						{
							if (Main.rand.Next(3) == 0)
							{
								Main.StartInvasion(1);
							}
						}
						else if ((Main.hardMode && Main.rand.Next(60) == 0) || (!Main.hardMode && Main.rand.Next(30) == 0))
						{
							Main.StartInvasion(1);
						}
						if (Main.invasionType == 0 && Main.hardMode && ((NPC.downedPirates && Main.rand.Next(50) == 0) || (!NPC.downedPirates && Main.rand.Next(30) == 0)))
						{
							Main.StartInvasion(3);
						}
					}
					if (Main.hardMode && NPC.downedMechBossAny && Main.rand.Next(25) == 0 && Main.netMode != 1)
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
								NetMessage.SendData(25, -1, -1, Lang.misc[20], 255, 50f, 255f, 130f, 0);
							}
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
						}
					}
				}
				if (Main.time > 16200.0 && WorldGen.spawnMeteor)
				{
					WorldGen.spawnMeteor = false;
					WorldGen.dropMeteor();
					return;
				}
			}
			else
			{
				Main.bloodMoon = false;
				Main.stopMoonEvent();
				if (Main.time > 54000.0)
				{
					NPC.setFireFlyChance();
					WorldGen.spawnNPC = 0;
					Main.checkForSpawns = 0;
					if (Main.rand.Next(50) == 0 && Main.netMode != 1 && WorldGen.shadowOrbSmashed)
					{
						WorldGen.spawnMeteor = true;
					}
					Main.eclipse = false;
					if (!NPC.downedBoss1 && Main.netMode != 1)
					{
						bool flag = false;
						for (int l = 0; l < 255; l++)
						{
							if (Main.player[l].active && Main.player[l].statLifeMax >= 200 && Main.player[l].statDefense > 10)
							{
								flag = true;
								break;
							}
						}
						if (flag && Main.rand.Next(3) == 0)
						{
							int num6 = 0;
							for (int m = 0; m < 200; m++)
							{
								if (Main.npc[m].active && Main.npc[m].townNPC)
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
									NetMessage.SendData(25, -1, -1, Lang.misc[9], 255, 50f, 255f, 130f, 0);
								}
							}
						}
					}
					if (Main.netMode != 1 && !Main.pumpkinMoon && !Main.snowMoon && WorldGen.altarCount > 0 && Main.hardMode && !WorldGen.spawnEye && Main.rand.Next(10) == 0)
					{
						bool flag3 = false;
						for (int num7 = 0; num7 < 200; num7++)
						{
							if (Main.npc[num7].active && Main.npc[num7].boss)
							{
								flag3 = true;
							}
						}
						if (!flag3 && (!NPC.downedMechBoss1 || !NPC.downedMechBoss2 || !NPC.downedMechBoss3))
						{
							int num8 = 0;
							while (num8 < 1000)
							{
								int num9 = Main.rand.Next(3) + 1;
								if (num9 == 1 && !NPC.downedMechBoss1)
								{
									WorldGen.spawnHardBoss = num9;
									if (Main.netMode == 0)
									{
										Main.NewText(Lang.misc[28], 50, 255, 130, false);
										break;
									}
									if (Main.netMode == 2)
									{
										NetMessage.SendData(25, -1, -1, Lang.misc[28], 255, 50f, 255f, 130f, 0);
										break;
									}
									break;
								}
								else if (num9 == 2 && !NPC.downedMechBoss2)
								{
									WorldGen.spawnHardBoss = num9;
									if (Main.netMode == 0)
									{
										Main.NewText(Lang.misc[29], 50, 255, 130, false);
										break;
									}
									if (Main.netMode == 2)
									{
										NetMessage.SendData(25, -1, -1, Lang.misc[29], 255, 50f, 255f, 130f, 0);
										break;
									}
									break;
								}
								else if (num9 == 3 && !NPC.downedMechBoss3)
								{
									WorldGen.spawnHardBoss = num9;
									if (Main.netMode == 0)
									{
										Main.NewText(Lang.misc[30], 50, 255, 130, false);
										break;
									}
									if (Main.netMode == 2)
									{
										NetMessage.SendData(25, -1, -1, Lang.misc[30], 255, 50f, 255f, 130f, 0);
										break;
									}
									break;
								}
								else
								{
									num8++;
								}
							}
						}
					}
					if (!WorldGen.spawnEye && Main.moonPhase != 4 && Main.rand.Next(9) == 0 && Main.netMode != 1)
					{
						for (int num10 = 0; num10 < 255; num10++)
						{
							if (Main.player[num10].active && Main.player[num10].statLifeMax > 120)
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
								NetMessage.SendData(25, -1, -1, Lang.misc[8], 255, 50f, 255f, 130f, 0);
							}
						}
					}
					Main.time = 0.0;
					Main.dayTime = false;
					if (Main.netMode == 2)
					{
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
					}
				}
				if (Main.netMode != 1 && Main.worldRate > 0)
				{
					Main.checkForSpawns++;
					if (Main.checkForSpawns >= 7200 / Main.worldRate)
					{
						int num11 = 0;
						for (int num12 = 0; num12 < 255; num12++)
						{
							if (Main.player[num12].active)
							{
								num11++;
							}
						}
						for (int num13 = 0; num13 < 369; num13++)
						{
							Main.nextNPC[num13] = false;
						}
						Main.checkForSpawns = 0;
						WorldGen.spawnNPC = 0;
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
						int num35 = 0;
						for (int num36 = 0; num36 < 200; num36++)
						{
							if (Main.npc[num36].active && Main.npc[num36].townNPC)
							{
								if (Main.npc[num36].type != 368 && Main.npc[num36].type != 37 && !Main.npc[num36].homeless)
								{
									WorldGen.QuickFindHome(num36);
								}
								if (Main.npc[num36].type == 37)
								{
									num19++;
								}
								if (Main.npc[num36].type == 17)
								{
									num14++;
								}
								if (Main.npc[num36].type == 18)
								{
									num15++;
								}
								if (Main.npc[num36].type == 19)
								{
									num17++;
								}
								if (Main.npc[num36].type == 20)
								{
									num16++;
								}
								if (Main.npc[num36].type == 22)
								{
									num18++;
								}
								if (Main.npc[num36].type == 38)
								{
									num20++;
								}
								if (Main.npc[num36].type == 54)
								{
									num21++;
								}
								if (Main.npc[num36].type == 107)
								{
									num23++;
								}
								if (Main.npc[num36].type == 108)
								{
									num22++;
								}
								if (Main.npc[num36].type == 124)
								{
									num24++;
								}
								if (Main.npc[num36].type == 142)
								{
									num25++;
								}
								if (Main.npc[num36].type == 160)
								{
									num26++;
								}
								if (Main.npc[num36].type == 178)
								{
									num27++;
								}
								if (Main.npc[num36].type == 207)
								{
									num28++;
								}
								if (Main.npc[num36].type == 208)
								{
									num29++;
								}
								if (Main.npc[num36].type == 209)
								{
									num30++;
								}
								if (Main.npc[num36].type == 227)
								{
									num31++;
								}
								if (Main.npc[num36].type == 228)
								{
									num32++;
								}
								if (Main.npc[num36].type == 229)
								{
									num33++;
								}
								if (Main.npc[num36].type == 353)
								{
									num34++;
								}
								num35++;
							}
						}
						if (WorldGen.spawnNPC == 0)
						{
							int num37 = 0;
							bool flag4 = false;
							int num38 = 0;
							bool flag5 = false;
							bool flag6 = false;
							bool flag7 = false;
							for (int num39 = 0; num39 < 255; num39++)
							{
								if (Main.player[num39].active)
								{
									for (int num40 = 0; num40 < 58; num40++)
									{
										if (Main.player[num39].inventory[num40] != null & Main.player[num39].inventory[num40].stack > 0)
										{
											if (num37 < 2000000000)
											{
												if (Main.player[num39].inventory[num40].type == 71)
												{
													num37 += Main.player[num39].inventory[num40].stack;
												}
												if (Main.player[num39].inventory[num40].type == 72)
												{
													num37 += Main.player[num39].inventory[num40].stack * 100;
												}
												if (Main.player[num39].inventory[num40].type == 73)
												{
													num37 += Main.player[num39].inventory[num40].stack * 10000;
												}
												if (Main.player[num39].inventory[num40].type == 74)
												{
													num37 += Main.player[num39].inventory[num40].stack * 1000000;
												}
											}
											if (Main.player[num39].inventory[num40].ammo == 14 || Main.player[num39].inventory[num40].useAmmo == 14)
											{
												flag5 = true;
											}
											if (Main.player[num39].inventory[num40].type == 166 || Main.player[num39].inventory[num40].type == 167 || Main.player[num39].inventory[num40].type == 168 || Main.player[num39].inventory[num40].type == 235)
											{
												flag6 = true;
											}
											if (Main.player[num39].inventory[num40].dye > 0 || (Main.player[num39].inventory[num40].type >= 1107 && Main.player[num39].inventory[num40].type <= 1120))
											{
												flag7 = true;
											}
										}
									}
									int num41 = Main.player[num39].statLifeMax / 20;
									if (num41 > 5)
									{
										flag4 = true;
									}
									num38 += num41;
									if (!flag7)
									{
										for (int num42 = 0; num42 < 3; num42++)
										{
											if (Main.player[num39].dye[num42] != null && Main.player[num39].dye[num42].stack > 0 && Main.player[num39].dye[num42].dye > 0)
											{
												flag7 = true;
											}
										}
									}
								}
							}
							if (!NPC.downedBoss3 && num19 == 0)
							{
								int num43 = NPC.NewNPC(Main.dungeonX * 16 + 8, Main.dungeonY * 16, 37, 0);
								Main.npc[num43].homeless = false;
								Main.npc[num43].homeTileX = Main.dungeonX;
								Main.npc[num43].homeTileY = Main.dungeonY;
							}
							bool flag8 = false;
							if (Main.rand.Next(50) == 0)
							{
								flag8 = true;
							}
							if (num18 < 1)
							{
								Main.nextNPC[22] = true;
							}
							if ((double)num37 > 5000.0 && num14 < 1)
							{
								Main.nextNPC[17] = true;
							}
							if (flag4 && num15 < 1 && num14 > 0)
							{
								Main.nextNPC[18] = true;
							}
							if (flag5 && num17 < 1)
							{
								Main.nextNPC[19] = true;
							}
							if ((NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && num16 < 1)
							{
								Main.nextNPC[20] = true;
							}
							if (flag6 && num14 > 0 && num20 < 1)
							{
								Main.nextNPC[38] = true;
							}
							if (NPC.savedStylist && num34 < 1)
							{
								Main.nextNPC[353] = true;
							}
							if (NPC.downedBoss3 && num21 < 1)
							{
								Main.nextNPC[54] = true;
							}
							if (NPC.savedGoblin && num23 < 1)
							{
								Main.nextNPC[107] = true;
							}
							if (NPC.savedWizard && num22 < 1)
							{
								Main.nextNPC[108] = true;
							}
							if (NPC.savedMech && num24 < 1)
							{
								Main.nextNPC[124] = true;
							}
							if (NPC.downedFrost && num25 < 1 && Main.xMas)
							{
								Main.nextNPC[142] = true;
							}
							if (NPC.downedMechBossAny && num27 < 1)
							{
								Main.nextNPC[178] = true;
							}
							if (flag7 && num28 < 1)
							{
								Main.nextNPC[207] = true;
							}
							if (NPC.downedQueenBee && num32 < 1)
							{
								Main.nextNPC[228] = true;
							}
							if (NPC.downedPirates && num33 < 1)
							{
								Main.nextNPC[229] = true;
							}
							if (num26 < 1 && Main.hardMode)
							{
								Main.nextNPC[160] = true;
							}
							if (Main.hardMode && NPC.downedPlantBoss && num30 < 1)
							{
								Main.nextNPC[209] = true;
							}
							if (num35 >= 4 && num31 < 1)
							{
								Main.nextNPC[227] = true;
							}
							if (flag8 && num29 < 1 && num35 >= 8)
							{
								Main.nextNPC[208] = true;
							}
							if (WorldGen.spawnNPC == 0 && num18 < 1)
							{
								WorldGen.spawnNPC = 22;
							}
							if (WorldGen.spawnNPC == 0 && (double)num37 > 5000.0 && num14 < 1)
							{
								WorldGen.spawnNPC = 17;
							}
							if (WorldGen.spawnNPC == 0 && flag4 && num15 < 1 && num14 > 0)
							{
								WorldGen.spawnNPC = 18;
							}
							if (WorldGen.spawnNPC == 0 && flag5 && num17 < 1)
							{
								WorldGen.spawnNPC = 19;
							}
							if (WorldGen.spawnNPC == 0 && (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && num16 < 1)
							{
								WorldGen.spawnNPC = 20;
							}
							if (WorldGen.spawnNPC == 0 && flag6 && num14 > 0 && num20 < 1)
							{
								WorldGen.spawnNPC = 38;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedStylist && num34 < 1)
							{
								WorldGen.spawnNPC = 353;
							}
							if (WorldGen.spawnNPC == 0 && NPC.downedBoss3 && num21 < 1)
							{
								WorldGen.spawnNPC = 54;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedGoblin && num23 < 1)
							{
								WorldGen.spawnNPC = 107;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedWizard && num22 < 1)
							{
								WorldGen.spawnNPC = 108;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedMech && num24 < 1)
							{
								WorldGen.spawnNPC = 124;
							}
							if (WorldGen.spawnNPC == 0 && NPC.downedFrost && num25 < 1 && Main.xMas)
							{
								WorldGen.spawnNPC = 142;
							}
							if (WorldGen.spawnNPC == 0 && NPC.downedMechBossAny && num27 < 1)
							{
								WorldGen.spawnNPC = 178;
							}
							if (WorldGen.spawnNPC == 0 && flag7 && num28 < 1)
							{
								WorldGen.spawnNPC = 207;
							}
							if (WorldGen.spawnNPC == 0 && NPC.downedQueenBee && num32 < 1)
							{
								WorldGen.spawnNPC = 228;
							}
							if (WorldGen.spawnNPC == 0 && NPC.downedPirates && num33 < 1)
							{
								WorldGen.spawnNPC = 229;
							}
							if (WorldGen.spawnNPC == 0 && Main.hardMode && num26 < 1)
							{
								WorldGen.spawnNPC = 160;
							}
							if (WorldGen.spawnNPC == 0 && Main.hardMode && NPC.downedPlantBoss && num30 < 1)
							{
								WorldGen.spawnNPC = 209;
							}
							if (WorldGen.spawnNPC == 0 && num35 >= 4 && num31 < 1)
							{
								WorldGen.spawnNPC = 227;
							}
							if (WorldGen.spawnNPC == 0 && flag8 && num35 >= 8 && num29 < 1)
							{
								WorldGen.spawnNPC = 208;
							}
						}
					}
				}
			}
		}
		public static int DamageVar(float dmg)
		{
			float num = dmg * (1f + (float)Main.rand.Next(-15, 16) * 0.01f);
			return (int)Math.Round((double)num);
		}
		public static double CalculateDamage(int Damage, int Defense)
		{
			double num = (double)Damage - (double)Defense * 0.5;
			if (num < 1.0)
			{
				num = 1.0;
			}
			return num;
		}
		public static void PlaySound(int type, int x = -1, int y = -1, int Style = 1)
		{
		}
	}
}
